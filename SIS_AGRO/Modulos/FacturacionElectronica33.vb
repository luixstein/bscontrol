Option Strict On

Module FacturacionElectronica33
    Private Const nombreModulo As String = "FacturacionElectronica33"

    Public dtUsosCFDIPersonasFisicas As DataTable
    Public dtUsosCFDIPersonasMorales As DataTable

    Public dtFormasPagoTodas As DataTable
    Public dtFormasPagoActivas As DataTable

    Public dtMetodosPago As DataTable
    Public dtTiposRelacionCFDI As DataTable

    Private tPlazaFacturaElectronica As Class_SisPlazas

    Private Function ValidaDatosGenerales(ByVal dFecha As Date, ByVal sCER As String, ByVal sKEY As String, ByVal sPassCER As String) As Boolean
        Const sProcedure As String = "ValidaDatosGenerales"
        Dim bResultado As Boolean = False

        Try
            Dim dFechaServidor As Date = Empresa_Sistema.FechaActualServidor

            Dim sqlResult As New Class_find("SELECT E.VERSION,S.VERSION_CFDI_DLL FROM VERSION_ESQUEMA_CFD E,SIS_EMPRESA S WHERE '" & Format(dFecha, "yyyy-dd-MM HH:mm") & "'  BETWEEN E.FECHA_INICIAL AND E.FECHA_FINAL")

            'Nota1, no la copia en automático, porque ya lo debió haber hecho el gestionaArchivosCertificados
            'Nota2, se valida la versión que tenga el servidor en el instante por si tenemos fallo en la dll y se pare el timbrado.
            If txtLEN(sqlResult.Result2) = False Then
                MsgBox("No se encontró el dato VERSION_CFDI_DLL de acuerdo a la fecha de emisión.", vbExclamation, sProcedure)
                Return False
            End If

            If sqlResult.Result2 <> VersionArchivo(sFelectronicaDLLCFDILocal).ToString Then
                MsgBox("La versión del archivo cfdi.dll(v " & VersionArchivo(sFelectronicaDLLCFDILocal) & ") es diferente del servidor(v " & sqlResult.Result2 & "). " & vbCrLf &
                "No se podrán generar facturas electrónicas en este equipo. Avíse al depto. de sistemas.", vbExclamation, sProcedure)
                Return False
            End If

            If sqlResult.Result1 <> Empresa_Sistema.VERSION_ESQUEMA_CFD Then
                MsgBox("El esquema de documento(" & sqlResult.Result1 & ") es diferente al actual(" & Empresa_Sistema.VERSION_ESQUEMA_CFD & ").", vbExclamation, sProcedure)
                Return False
            End If

            If CDate(Format(dFecha, "dd/MM/yyyy HH:mm:ss")) < dFechaServidor.AddDays(-3) Then
                MsgBox("La fecha del documento(" & CDate(Format(dFecha, "dd/MM/yyyy HH:mm:ss")).ToString & ") es mayor de 72 horas de la fecha actual(" & dFechaServidor.AddDays(-3) & "), el SAT no permite timbrar con fecha de más de 3 días.", vbExclamation, sProcedure)
                Return False
            End If

            If DateDiff("d", dFechaServidor, dFecha) >= 1 Then
                MsgBox("La fecha del documento es mayor que la fecha actual.", vbExclamation, sProcedure)
                Return False
            End If

            'ya esta desenc. sPassCER = IIf(txtLEN(sPassCER) = True, Decrypt(sPassCER, "r7"), "").ToString

            If fElectronicaValidaArchivosCertificadoLocal(sCER, sKEY, sPassCER) = False Then
                Return False
            End If

            bResultado = True

        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Public Function GeneraFacturaElectronica33(ByVal oVenta As Class_Ventas_Global, ByVal bMostrarMensaje As Boolean, ByVal sRutaXML As String) As Boolean
        Const sProcedure As String = "GeneraFacturaElectronica33"
        Dim bResultado As Boolean = False

        Dim sPlaza As String
        Dim Cfd As New cComprobante33

        Try
            If ValidaDatosGenerales(oVenta.FECHA, oVenta.FELECTRONICA_CER, oVenta.FELECTRONICA_KEY, oVenta.FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA) = False Then
                Return False
            End If

            If oVenta.ES_FACTURA_EMBARQUE_EXTRANJERO = True And (oVenta.IMPUESTO > 0 Or oVenta.IEPS_TOTAL_DESGLOSADO > 0 Or oVenta.IEPS_TOTAL_YA_INCLUIDO > 0) Then
                MsgBox("No esta soportado actualmente por este sistema que lo embarques extranjeros lleven impuestos iva/ieps.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            'If Empresa_Sistema.FELECTRONICA_CCE_HABILITADO = True And oVenta.ES_FACTURA_EMBARQUE_EXTRANJERO = True Then
            '    If ValidaComplementoExterior(Cfd) = False Then
            '        Return False
            '    End If
            'End If

            sPlaza = oVenta.CODIGO_PLAZA.ToString

            If sPlaza <> Usuario.Codigo_Plaza.ToString Then
                If sPlaza <> Plaza.CODIGO_PLAZA.ToString Then 'Si ya estaba cargada la plaza de la factura, no se cargará de nuevo para evitar consultas.
                    tPlazaFacturaElectronica = New Class_SisPlazas(CInt(sPlaza))
                End If
            Else
                tPlazaFacturaElectronica = Plaza 'Plaza ya cargada en el inicio de sesión del usuario.
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Datos globales''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim dSubTotal As Decimal, dDescuento As Decimal, dTotal As Decimal, dTIPO_DE_CAMBIO As Decimal

            dTIPO_DE_CAMBIO = CDec(oVenta.TIPO_DE_CAMBIO)

            If oVenta.ES_FACTURA_EMBARQUE_EXTRANJERO = True Then
                MsgBox("De momento no se pueden timbrar facturas de embarques extranjeros", vbExclamation, sProcedure)
                Return False
                '    dSubTotal = CDec(oVenta.TOTAL_DOLARES)
                '    dDescuento = CDec(oVenta.DESCUENTO_USD)
                '    dTotal = 0
                'Else
                '    dSubTotal = CDec(oVenta.SUBTOTAL)
                '    dDescuento = CDec(oVenta.DESCUENTO)
                '    dTotal = CDec(oVenta.TOTAL)

                '    If oVenta.CODIGO_MONEDA_SAT = "USD" Then
                '        dSubTotal = RedondearD(dSubTotal / dTIPO_DE_CAMBIO, 2)
                '        dDescuento = RedondearD(dDescuento / dTIPO_DE_CAMBIO, 2)
                '        dTotal = RedondearD(dTotal / dTIPO_DE_CAMBIO, 2)
                '    End If
            End If

            If oVenta.CODIGO_MONEDA_SAT = "MXN" Or oVenta.CODIGO_MONEDA_SAT = "XXX" Then
                dSubTotal = CDec(oVenta.SUBTOTAL)
                dDescuento = CDec(oVenta.DESCUENTO)
                dTotal = CDec(oVenta.TOTAL)
            ElseIf oVenta.CODIGO_MONEDA_SAT = "USD" Then
                dSubTotal = CDec(oVenta.SUBTOTAL_USD)
                dDescuento = CDec(oVenta.DESCUENTO_USD)
                dTotal = CDec(oVenta.TOTAL_DOLARES)
            Else
                MsgBox("Moneda SAT inválida no se pueden timbrar facturas de embarques extranjeros", vbExclamation, sProcedure)
            End If

            With Cfd
                .FolioCompleto = oVenta.FOLIO_VENTA
                .Version = Empresa_Sistema.VERSION_ESQUEMA_CFD
                .Serie = oVenta.SERIE
                .Folio = oVenta.FOLIO_NUMERICO.ToString
                .Fecha = Format(oVenta.FECHA, "yyyy-MM-dd") & "T" & Format(oVenta.FECHA, "HH:mm:ss")
                .Sello = ""                     'Inicialmente va en blanco, posteriormente se genera
                .FormaPago = oVenta.CODIGO_METODO_PAGO
                .NoCertificado = ""             'Se llenan dentro de Cfd.Sellar(clase comprobante) y dentro se llama a SellarFactura(modulo FacturacionElectronica)
                .Certificado = ""               'Igual que el anterior
                .CondicionesDePago = ""         'De momento no lo vamos usar, podria llevar frases como crédito 30 dias, etc
                .SubTotal = Format(dSubTotal, "#0.00")
                .Descuento = IIf(dDescuento > 0, Format(dDescuento, "#0.00"), "").ToString
                .Total = Format(dTotal, "#0.00")
                .Moneda = oVenta.CODIGO_MONEDA_SAT
                If oVenta.TIPO_DE_CAMBIO > 0 Then
                    .TipoCambio = FormatTipoCambio(oVenta.TIPO_DE_CAMBIO, False)
                End If
                If oVenta.CODIGO_TIPO_DOCUMENTO = "FT" Then 'Factura de traslado
                    .TipoDeComprobante = "T" 'Traslado
                Else
                    .TipoDeComprobante = "I" 'Ingreso
                End If
                .MetodoPago = oVenta.CODIGO_METODO_PAGO_EVENTO
                .LugarExpedicion = tPlazaFacturaElectronica.CODIGO_POSTAL
                .Confirmacion = ""
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''CfdiRelacionados''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Se pregunta por que no todas las facturas tienen relación.
            If txtLEN("" & oVenta.CODIGO_TIPO_RELACION_CFDI) = True Then
                Cfd.CfdiRelacionados.TipoRelacion = oVenta.CODIGO_TIPO_RELACION_CFDI

                Dim dtFacturasRelacionadas As DataTable = oVenta.ObtieneFacturasRelacionadas
                Dim FaltanUUIDRelacionados As Boolean = False

                If dtFacturasRelacionadas.Rows.Count = 0 Then
                    MsgBox("No se encontraron los cfdis relacionados(facturas) a la factura.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                For Each dRow As DataRow In dtFacturasRelacionadas.Rows
                    If txtLEN("" & dRow("FOLIO_FISCAL_SAT").ToString) = False Then
                        MsgBox("La factura " & dRow("FOLIO_VENTA").ToString & " no tiene UUID(posiblemente no esta timbrada).", vbExclamation, sProcedure)
                        FaltanUUIDRelacionados = True
                    End If

                    Cfd.CfdiRelacionados.Add(dRow("FOLIO_FISCAL_SAT").ToString) 'uuids
                Next

                'En caso de que alguna factura no este timbrada se aborta el proceso.
                If FaltanUUIDRelacionados = True Then
                    Return False
                End If
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Emisor''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With Cfd.Emisor
                .Rfc = fElectronicaValidaCampo(Empresa_Sistema.RFC)
                .Nombre = fElectronicaValidaCampo(Empresa_Sistema.NOMBRE_EMPRESA)
                .RegimenFiscal = fElectronicaValidaCampo(oVenta.CODIGO_REGIMEN_FISCAL.ToString)
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Receptor''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim oCliente As New Class_CatClientes(oVenta.CODIGO_CLIENTE.ToString)
            Dim sReceptorRFC As String, sReceptorNombre As String

            If oCliente.Existe = False Then
                MsgBox("Cliente no encontrado.", MsgBoxStyle.Exclamation, nombreModulo)
                Return False
            End If

            If oVenta.ES_VENTA_PUBLICO_GENERAL = "1" Then
                sReceptorNombre = "PUBLICO GENERAL"
                sReceptorRFC = Empresa_Sistema.RFC_VENTA_PUBLICO_GENERAL
            Else
                sReceptorNombre = fElectronicaValidaCampo(oCliente.NOMBRE_CLIENTE)
                sReceptorRFC = fElectronicaValidaCampo(Replace(oCliente.RFC, "-", ""))
            End If

            With Cfd.Receptor
                .Rfc = sReceptorRFC
                .Nombre = sReceptorNombre

                If Empresa_Sistema.FELECTRONICA_CCE_HABILITADO = True And oVenta.ES_FACTURA_EMBARQUE_EXTRANJERO = True Then
                    .ResidenciaFiscal = oCliente.CODIGO_PAIS_SAT  'usarlo sólo cuando el rfc sea extranjero y haya cce o numregid
                    .NumRegIdTrib = oCliente.NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO
                End If

                .UsoCFDI = oVenta.CODIGO_USO_CFDI
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Conceptos'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim ConceptoImpuestoTraslados As iConceptoImpuestoTraslados33
            Dim ConceptoImpuestoRetenciones As iConceptoImpuestoRetenciones33

            Dim drImporte As Decimal, drPrecio As Decimal, drCantidad As Decimal, drDESCUENTO_IMPORTE As Decimal, drIMPUESTO_PORCENTAJE As Decimal
            Dim drBASE_IEPS As Decimal, drBASE_IVA As Decimal, drIMPUESTO_IMPORTE As Decimal, drIEPS_IMPORTE As Decimal, drIEPS_PORCENTAJE As Decimal
            'Dim drRetencionIVA As Decimal, drRetencionPorcentaje As Decimal

            Dim drRETENCION_IVA_PORCENTAJE As Decimal = 0, drRETENCION_IVA_BASE As Decimal = 0, drRETENCION_IVA_IMPORTE As Decimal = 0
            Dim drRETENCION_ISR_PORCENTAJE As Decimal = 0, drRETENCION_ISR_BASE As Decimal = 0, drRETENCION_ISR_IMPORTE As Decimal = 0

            For Each row As DataRow In oVenta.ObtenerDetalleParaCFDI(oVenta.FOLIO_VENTA).Rows
                drCantidad = CDec(row("CANTIDAD").ToString)
                drIMPUESTO_PORCENTAJE = CDec(row("IMPUESTO_PORCENTAJE").ToString) / CDec("100.00")
                drIEPS_PORCENTAJE = CDec(row("IEPS_PORCENTAJE").ToString) / CDec("100.00")
                'drRetencionPorcentaje = CDec(row("RETENCION_IVA_PORCENTAJE").ToString) / CDec("100.00")

                drRETENCION_IVA_PORCENTAJE = CDec(row("RETENCION_IVA_PORCENTAJE").ToString)
                drRETENCION_ISR_PORCENTAJE = CDec(row("RETENCION_ISR_PORCENTAJE").ToString)

                'Ver nota principal sobre embarques de extranjero
                'If oVenta.ES_FACTURA_EMBARQUE_EXTRANJERO = True Then
                '    drPrecio = CDec(row("PRECIO_USD").ToString)
                '    drImporte = CDec(row("IMPORTE_USD").ToString)
                '    drDESCUENTO_IMPORTE = CDec(row("IMPORTE_USD").ToString)
                'Else
                '    drPrecio = CDec(row("PRECIO_TOTAL").ToString)
                '    drImporte = CDec(row("IMPORTE").ToString)
                '    drDESCUENTO_IMPORTE = CDec(row("DESCUENTO_IMPORTE").ToString)

                '    If oVenta.CODIGO_MONEDA_SAT = "USD" Then
                '        drPrecio = RedondearD(drPrecio / dTIPO_DE_CAMBIO, 3)
                '        drImporte = RedondearD(drImporte / dTIPO_DE_CAMBIO, 2)
                '        drDESCUENTO_IMPORTE = RedondearD(drDESCUENTO_IMPORTE / dTIPO_DE_CAMBIO, 2)
                '    End If
                'End If

                If oVenta.CODIGO_MONEDA_SAT = "MXN" Then
                    drPrecio = CDec(row("PRECIO_TOTAL").ToString)
                    drImporte = CDec(row("IMPORTE").ToString)
                    drDESCUENTO_IMPORTE = CDec(row("DESCUENTO_IMPORTE").ToString)
                    drRETENCION_IVA_BASE = CDec(row("RETENCION_IVA_BASE").ToString)
                    drRETENCION_ISR_BASE = CDec(row("RETENCION_ISR_BASE").ToString)
                    drRETENCION_IVA_IMPORTE = CDec(row("RETENCION_IVA_IMPORTE").ToString)
                    drRETENCION_ISR_IMPORTE = CDec(row("RETENCION_ISR_IMPORTE").ToString)
                ElseIf oVenta.CODIGO_MONEDA_SAT = "USD" Then
                    drPrecio = CDec(row("PRECIO_TOTAL_USD").ToString)
                    drImporte = CDec(row("IMPORTE_USD").ToString)
                    drDESCUENTO_IMPORTE = CDec(row("DESCUENTO_IMPORTE_USD").ToString)
                    drRETENCION_IVA_BASE = CDec(row("RETENCION_IVA_BASE_USD").ToString)
                    drRETENCION_ISR_BASE = CDec(row("RETENCION_ISR_BASE_USD").ToString)
                    drRETENCION_IVA_IMPORTE = CDec(row("RETENCION_IVA_IMPORTE_USD").ToString)
                    drRETENCION_ISR_IMPORTE = CDec(row("RETENCION_ISR_IMPORTE_USD").ToString)
                End If

                ConceptoImpuestoTraslados = New iConceptoImpuestoTraslados33
                ConceptoImpuestoRetenciones = New iConceptoImpuestoRetenciones33

                If Cfd.TipoDeComprobante = "I" Then 'Para los tipo I-Ingreso si hay impuestos, pero para los tipo T-Traslados no debe haber.
                    '003=IEPS,002=IVA
                    If oVenta.TIENE_IEPS_DESGLOSADO = True Then
                        If row("GRADO_TOXICIDAD").ToString <> "0" Then '0=no graba ieps, <>0 significa que si graba ieps : 1-4=con alguna tasa,5=Exento(aún siendo exento hay que llenar la base ieps)
                            'drBASE_IEPS = CDec(row("BASE_IEPS").ToString)
                            'drIEPS_IMPORTE = CDec(row("IEPS_IMPORTE").ToString)

                            'If oVenta.CODIGO_MONEDA_SAT = "USD" Then
                            '    drBASE_IEPS = RedondearD(drBASE_IEPS / dTIPO_DE_CAMBIO, 2)
                            '    drIEPS_IMPORTE = RedondearD(drIEPS_IMPORTE / dTIPO_DE_CAMBIO, 2)
                            'End If

                            If oVenta.CODIGO_MONEDA_SAT = "MXN" Then
                                drBASE_IEPS = CDec(row("BASE_IEPS").ToString)
                                drIEPS_IMPORTE = CDec(row("IEPS_IMPORTE").ToString)
                            ElseIf oVenta.CODIGO_MONEDA_SAT = "USD" Then
                                drBASE_IEPS = CDec(row("BASE_IEPS_USD").ToString)
                                drIEPS_IMPORTE = CDec(row("IEPS_IMPORTE_USD").ToString)
                            End If

                            If row("GRADO_TOXICIDAD").ToString = "5" Then '5=Ieps Exento
                                'ConceptoImpuestoTraslados.Add(Format(drBASE_IEPS, "##0.00"), "003", "Exento", "", "")
                                ConceptoImpuestoTraslados.Add(Format(drBASE_IEPS, "##0.000000"), "003", "Exento", "", "")
                            Else
                                'ConceptoImpuestoTraslados.Add(Format(drBASE_IEPS, "##0.00"), "003", "Tasa", Format(drIEPS_PORCENTAJE, "0.#00000"), Format(drIEPS_IMPORTE, "##0.00"))
                                ConceptoImpuestoTraslados.Add(Format(drBASE_IEPS, "##0.000000"), "003", "Tasa", Format(drIEPS_PORCENTAJE, "0.#00000"), Format(drIEPS_IMPORTE, "##0.00"))
                            End If
                        End If
                    End If

                    If row("ID_SIS_CAT_IMPUESTOS").ToString <> "N" Then 'N=No grava iva, si es <>N = Si grava iva ya sea al 0,16,Exento(aún siendo exento ó 0 hay que llenar la base iva)
                        'drBASE_IVA = CDec(row("BASE_IVA").ToString)
                        'drIMPUESTO_IMPORTE = CDec(row("IMPUESTO_IMPORTE").ToString)
                        'drRetencionIVA = CDec(row("RETENCION_IVA_IMPORTE").ToString)

                        'If oVenta.CODIGO_MONEDA_SAT = "USD" Then
                        '    drBASE_IVA = RedondearD(drBASE_IVA / dTIPO_DE_CAMBIO, 2)
                        '    drIMPUESTO_IMPORTE = RedondearD(drIMPUESTO_IMPORTE / dTIPO_DE_CAMBIO, 2)
                        '    drRetencionIVA = RedondearD(drRetencionIVA / dTIPO_DE_CAMBIO, 2)
                        'End If

                        If oVenta.CODIGO_MONEDA_SAT = "MXN" Then
                            drBASE_IVA = CDec(row("BASE_IVA").ToString)
                            drIMPUESTO_IMPORTE = CDec(row("IMPUESTO_IMPORTE").ToString)
                            'drRetencionIVA = CDec(row("RETENCION_IVA_IMPORTE").ToString)
                        ElseIf oVenta.CODIGO_MONEDA_SAT = "USD" Then
                            drBASE_IVA = CDec(row("BASE_IVA_USD").ToString)
                            drIMPUESTO_IMPORTE = CDec(row("IMPUESTO_IMPORTE_USD").ToString)
                            'drRetencionIVA = CDec(row("RETENCION_IVA_IMPORTE_USD").ToString)
                        End If

                        If row("ID_SIS_CAT_IMPUESTOS").ToString = "E" Then 'E=Iva Exento
                            'ConceptoImpuestoTraslados.Add(Format(drBASE_IVA, "##0.00"), "002", "Exento", "", "")
                            ConceptoImpuestoTraslados.Add(Format(drBASE_IVA, "##0.000000"), "002", "Exento", "", "")
                        Else
                            'ConceptoImpuestoTraslados.Add(Format(drBASE_IVA, "##0.00"), "002", "Tasa", Format(drIMPUESTO_PORCENTAJE, "0.#00000"), Format(drIMPUESTO_IMPORTE, "##0.00"))
                            ConceptoImpuestoTraslados.Add(Format(drBASE_IVA, "##0.000000"), "002", "Tasa", Format(drIMPUESTO_PORCENTAJE, "0.#00000"), Format(drIMPUESTO_IMPORTE, "##0.00"))

                            'If row("ID_SIS_CAT_IMPUESTOS_FLETE").ToString <> "0" Then
                            '    ConceptoImpuestoRetenciones.Add(Format(drBASE_IVA, "##0.000000"), "002", "Tasa", Format(drRetencionPorcentaje, "0.#00000"), Format(drRetencionIVA, "##0.00"))
                            'End If
                        End If

                    End If

                    If drRETENCION_IVA_IMPORTE > 0 Then
                        ConceptoImpuestoRetenciones.Add(Format(drRETENCION_IVA_BASE, "##0.00"), "002", "Tasa", Format(drRETENCION_IVA_PORCENTAJE, "0.#00000"), Format(drRETENCION_IVA_IMPORTE, "##0.00")) '002=IVA
                    End If

                    If drRETENCION_ISR_IMPORTE > 0 Then
                        ConceptoImpuestoRetenciones.Add(Format(drRETENCION_ISR_BASE, "##0.00"), "001", "Tasa", Format(drRETENCION_ISR_PORCENTAJE, "0.#00000"), Format(drRETENCION_ISR_IMPORTE, "##0.00")) '001=ISR
                    End If

                    'If oVenta.IEPS_TOTAL_DESGLOSADO > 0 Then 'Solamente si se le desglosan los ieps se mencionan, si es incluido no(como si no tuviera), por eso se pregunta por el total y no del renglón porque al ser inc si va tener ieps pero no es parte del xml
                    '    If CDec(row("IEPS_PORCENTAJE").ToString) > 0 Then 'Este viene como 6,7,9
                    '        drBASE_IEPS = CDec(row("BASE_IEPS").ToString)
                    '        drIEPS_IMPORTE = CDec(row("IEPS_IMPORTE").ToString)

                    '        If oVenta.CODIGO_MONEDA_SAT = "USD" Then
                    '            drBASE_IEPS = RedondearD(drBASE_IEPS / dTIPO_DE_CAMBIO, 2)
                    '            drIEPS_IMPORTE = RedondearD(drIEPS_IMPORTE / dTIPO_DE_CAMBIO, 2)
                    '        End If

                    '        ConceptoImpuestoTraslados.Add(Format(drBASE_IEPS, "##0.00"), "003", "Tasa", Format(drIEPS_PORCENTAJE, "0.#00000"), Format(drIEPS_IMPORTE, "##0.00"))
                    '    End If
                    'End If

                    'If drIMPUESTO_PORCENTAJE > 0 Then
                    '    drBASE_IVA = CDec(row("BASE_IVA").ToString)
                    '    drIMPUESTO_IMPORTE = CDec(row("IMPUESTO_IMPORTE").ToString)

                    '    If oVenta.CODIGO_MONEDA_SAT = "USD" Then
                    '        drBASE_IVA = RedondearD(drBASE_IVA / dTIPO_DE_CAMBIO, 2)
                    '        drIMPUESTO_IMPORTE = RedondearD(drIMPUESTO_IMPORTE / dTIPO_DE_CAMBIO, 2)
                    '    End If

                    '    ConceptoImpuestoTraslados.Add(Format(drBASE_IVA, "##0.00"), "002", "Tasa", Format(drIMPUESTO_PORCENTAJE, "0.#00000"), Format(drIMPUESTO_IMPORTE, "##0.00"))
                    'End If
                End If

                'Format(drPrecio, "##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO))
                Cfd.Conceptos.Add(row("CODIGO_PRODUCTO_SERVICIO").ToString, row("CODIGO_ARTICULO").ToString,
                                  Format(drCantidad, "##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CANTIDAD)),
                                  row("CODIGO_UNIDAD").ToString, row("UNIDAD_VENTA").ToString, fElectronicaValidaCampo(row("DESCRIPCION").ToString),
                                  Format(drPrecio, "##0." & StrDup(6, "0")),
                                  Format(drImporte, "##0.00"),
                                  IIf(drDESCUENTO_IMPORTE > 0, Format(drDESCUENTO_IMPORTE, "##0.00"), "").ToString, ConceptoImpuestoTraslados, ConceptoImpuestoRetenciones)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Impuestos'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim arr() As iImpuestosTraslado33, dImpuestoIEPSImporte As Decimal, dImpuestoIVAImporte As Decimal, iEncontrados As Integer = 0
            Dim arr2() As iImpuestosRetencion33, dRetencionIvaImporte As Decimal

            ''IEPS, deben acumularse, puede ser que mas de un artículo tenga el mismo % de ieps, de modo que aquí se juntan en uno sólo.
            iEncontrados = 0
            arr = ImpuestosTrasladoAgrupados(Cfd, "003", iEncontrados)

            If iEncontrados > 0 Then
                For i = 1 To UBound(arr)
                    dImpuestoIEPSImporte = CDec(arr(i).Importe)

                    'Nota, no es necesario preguntar si es en USD y dividir por el tipo de cambio porque este valor se llena con el desglose x concepto el cual ya esta en USD

                    Cfd.Impuestos.Traslados.Add(arr(i).Impuesto, arr(i).TipoFactor, arr(i).TasaOCuota, Format(dImpuestoIEPSImporte, "#0.00")) 'arr(i).TasaOCuota ya esta formateado
                Next
            End If

            ''IVA
            iEncontrados = 0
            arr = ImpuestosTrasladoAgrupados(Cfd, "002", iEncontrados) 'comprobar aqui que agrupe 0 y 16 pero no exentos."

            If iEncontrados > 0 Then
                For i = 1 To UBound(arr)
                    dImpuestoIVAImporte = CDec(arr(i).Importe)

                    Cfd.Impuestos.Traslados.Add(arr(i).Impuesto, arr(i).TipoFactor, arr(i).TasaOCuota, Format(dImpuestoIVAImporte, "#0.00")) 'arr(i).TasaOCuota ya esta formateado
                Next
            End If

            ''RETENCION IVA
            iEncontrados = 0
            arr2 = ImpuestosRetenidosAgrupados(Cfd, iEncontrados)

            If iEncontrados > 0 Then
                For i = 1 To UBound(arr2)
                    dRetencionIvaImporte = CDec(arr2(i).Importe)
                    Cfd.Impuestos.Retenciones.Add(arr2(i).Impuesto, Format(dRetencionIvaImporte, "#0.00"))
                Next
            End If

            ''IEPS, deben acumularse, puede ser que mas de un artículo tenga el mismo % de ieps, de modo que aquí se juntan en uno sólo.
            'If oVenta.IEPS_TOTAL_DESGLOSADO > 0 Then 'Solamente si se le desglosan los ieps se mencionan, si es incluido no(como si no tuviera), por eso se pregunta por el total y no del renglón porque al ser inc si va tener ieps pero no es parte del xml
            '    arr = ImpuestosTrasladoAgrupados(Cfd)

            '    For i = 1 To UBound(arr)
            '        dImpuestoIEPSImporte = CDec(arr(i).Importe)

            '        'Nota, no es necesario preguntar si es en USD y dividir por el tipo de cambio porque este valor se llena con el desglose x concepto el cual ya esta en USD

            '        Cfd.Impuestos.Traslados.Add(arr(i).Impuesto, arr(i).TipoFactor, arr(i).TasaOCuota, Format(dImpuestoIEPSImporte, "#0.00")) 'arr(i).TasaOCuota ya esta formateado
            '    Next
            'End If

            ''IVA
            ''Nota el total de iva ya esta acumulado y es un sólo tipo de iva por se obtiene directamente del documento(a diferencia del ieps)
            'If oVenta.IMPUESTO > 0 Then
            '    'rsDocumento!IMPUESTO_PORCENTAJE viene como 16, se ocupa dividir

            '    dImpuestoIVAImporte = CDec(oVenta.IMPUESTO)

            '    If oVenta.CODIGO_MONEDA_SAT = "USD" Then
            '        dImpuestoIVAImporte = RedondearD(dImpuestoIVAImporte / dTIPO_DE_CAMBIO, 2)
            '    End If

            '    Cfd.Impuestos.Traslados.Add("002", "Tasa", Format(oVenta.IMPUESTO_PORCENTAJE / CDec("100.00"), "0.#00000"), Format(dImpuestoIVAImporte, "#0.00"))
            'End If


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''CCE COMPLEMENTO COMERCIO EXTERIOR''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim sXmlComercioExterior As String = ""

            If Empresa_Sistema.FELECTRONICA_CCE_HABILITADO = True And oVenta.ES_FACTURA_EMBARQUE_EXTRANJERO = True Then
                sXmlComercioExterior = oVenta.GeneraXmlComercioExterior11(TipoCCE.Agricola)

                If txtLEN(sXmlComercioExterior) = False Then
                    Return False 'Abortamos
                End If

                Cfd.XmlComplementoComercioExterior = sXmlComercioExterior
            End If

            'Fin de llenado de nodos del comprobante''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Cfd.GeneraCFD(TipoComprobante.FACTURA_VENTA, sRutaXML) = True Then
                bResultado = True
                If bMostrarMensaje = True Then
                    MsgBox("Factura timbrada satisfactoriamente.", vbInformation, sProcedure)
                End If
            End If

        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ImpuestosTrasladoAgrupados(ByVal Cfd As cComprobante33, ByVal sTipoImpuesto As String, ByRef iEncontrados As Integer) As iImpuestosTraslado33()
        Const sProcedure As String = "ImpuestosTrasladoAgrupados"
        'Dim arr() As iImpuestosTraslado33
        Dim arr As iImpuestosTraslado33() = New iImpuestosTraslado33(-1) {} 'Para que no marque warning de null

        Try

            Dim i As Integer, j As Integer, X As Integer
            Dim arrCount As Integer, bEncontrado As Boolean

            iEncontrados = 0 'Este esta byref para regresarse tipo output

            ''IEPS, deben acumularse, puede ser que mas de un artículo tenga el mismo % de ieps, de modo que aquí se juntan en uno sólo.

            For i = 1 To Cfd.Conceptos.Count
                For j = 1 To Cfd.Conceptos.Item(i).Traslados.Count
                    If Cfd.Conceptos.Item(i).Traslados.Item(j).Impuesto = sTipoImpuesto And Cfd.Conceptos.Item(i).Traslados.Item(j).TipoFactor <> "Exento" Then '003=ieps,002=iva
                        If arrCount = 0 Then
                            arrCount = arrCount + 1
                            ReDim Preserve arr(arrCount)

                            arr(arrCount) = New iImpuestosTraslado33
                            arr(arrCount).Impuesto = Cfd.Conceptos.Item(i).Traslados.Item(j).Impuesto
                            arr(arrCount).Importe = Cfd.Conceptos.Item(i).Traslados.Item(j).Importe
                            arr(arrCount).TasaOCuota = Cfd.Conceptos.Item(i).Traslados.Item(j).TasaOCuota
                            arr(arrCount).TipoFactor = Cfd.Conceptos.Item(i).Traslados.Item(j).TipoFactor
                        Else
                            For X = 1 To arrCount
                                If arr(X).TasaOCuota = Cfd.Conceptos.Item(i).Traslados.Item(j).TasaOCuota Then
                                    arr(X).Importe = (valorNumerico(arr(X).Importe) + valorNumerico(Cfd.Conceptos.Item(i).Traslados.Item(j).Importe)).ToString  'Son strings por eso el cast
                                    bEncontrado = True
                                    Exit For
                                End If
                            Next

                            If bEncontrado = False Then
                                arrCount = arrCount + 1
                                ReDim Preserve arr(arrCount)

                                arr(arrCount) = New iImpuestosTraslado33
                                arr(arrCount).Impuesto = Cfd.Conceptos.Item(i).Traslados.Item(j).Impuesto
                                arr(arrCount).Importe = Cfd.Conceptos.Item(i).Traslados.Item(j).Importe
                                arr(arrCount).TasaOCuota = Cfd.Conceptos.Item(i).Traslados.Item(j).TasaOCuota
                                arr(arrCount).TipoFactor = Cfd.Conceptos.Item(i).Traslados.Item(j).TipoFactor
                            End If

                            bEncontrado = False
                        End If
                    End If
                Next
            Next

            iEncontrados = arrCount

        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try

        Return arr
    End Function

    Private Function ImpuestosRetenidosAgrupados(ByVal Cfd As cComprobante33, ByRef iEncontrados As Integer) As iImpuestosRetencion33()
        Const sProcedure As String = "ImpuestosRetenidosAgrupados"
        Dim arr As iImpuestosRetencion33() = New iImpuestosRetencion33(-1) {} 'Para que no marque warning de null, arrCount As Integer, bEncontrado As Boolean

        Try
            Dim i As Integer, j As Integer, x As Integer
            Dim arrCount As Integer, bEncontrado As Boolean

            iEncontrados = 0 'Este esta byref para regresarse tipo output

            For i = 1 To Cfd.Conceptos.Count
                For j = 1 To Cfd.Conceptos.Item(i).Retenciones.Count
                    'Cfd.Conceptos.Item(i).Retenciones.Item(j)

                    If arrCount = 0 Then
                        arrCount = arrCount + 1
                        ReDim Preserve arr(arrCount)

                        arr(arrCount) = New iImpuestosRetencion33
                        arr(arrCount).Impuesto = Cfd.Conceptos.Item(i).Retenciones.Item(j).Impuesto
                        arr(arrCount).Importe = Cfd.Conceptos.Item(i).Retenciones.Item(j).Importe
                    Else
                        For x = 1 To arrCount
                            If arr(x).Impuesto = Cfd.Conceptos.Item(i).Retenciones.Item(j).Impuesto Then
                                arr(x).Importe = (valorNumerico(arr(x).Importe) + valorNumerico(Cfd.Conceptos.Item(i).Retenciones.Item(j).Importe)).ToString  'Son strings por eso el cast
                                bEncontrado = True
                                Exit For
                            End If
                        Next

                        If bEncontrado = False Then
                            arrCount = arrCount + 1
                            ReDim Preserve arr(arrCount)

                            arr(arrCount) = New iImpuestosRetencion33
                            arr(arrCount).Impuesto = Cfd.Conceptos.Item(i).Retenciones.Item(j).Impuesto
                            arr(arrCount).Importe = Cfd.Conceptos.Item(i).Retenciones.Item(j).Importe
                        End If

                        bEncontrado = False
                    End If
                Next
            Next

            iEncontrados = arrCount

        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try

        Return arr
    End Function

    Public Function FormatTipoCambio(ByVal dTipoCambio As Double, Optional ByVal bConSignoMoneda As Boolean = True, Optional ByVal dDecimales As Integer = 4) As String
        Const sProcedure As String = "FormatTipoCambio"
        Dim sResultado As String = ""
        Try
            If bConSignoMoneda = True Then
                sResultado = Format(dTipoCambio, "$ ##0." & CerosEnCadena(dDecimales))
            Else
                sResultado = Format(dTipoCambio, "##0." & CerosEnCadena(dDecimales))
            End If

        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try
        Return sResultado
    End Function

    Public Function FechaSatAFechaNormal(ByVal fechaSAT As String) As Date
        Const sProcedure As String = "FechaSatAFechaNormal"
        Dim dResultado As Date
        Try
            dResultado = CDate(Replace(fechaSAT, "T", " "))
        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try
        Return dResultado
    End Function

    Private Function ValidaComplementoExterior(ByRef Cfd As cComprobante33) As Boolean
        Try

            MsgBox("falta validar los datos del domicilio, ya no son del nodo del receptor, hay que ver el cce versión 1.1")
            Return False

            'Dim oPais As New Class_CatPaises(Cfd.Receptor.Domicilio.pais)
            'If oPais.Existe = False OrElse Cfd.Receptor.Domicilio.pais = "MEX" Then
            '    MsgBox("Receptor.Domicilio.pais - La clave en el atributo [pais] debe existir en el catálogo c_pais y debe ser diferente de {MEX}.", MsgBoxStyle.Exclamation, nombreModulo)
            '    Return False
            'End If
            'Dim oEstado As New Class_SisEstados(Cfd.Receptor.Domicilio.estado, Cfd.Receptor.Domicilio.pais)

            'If oEstado.Existe = False Then
            '    MsgBox("Receptor.Domicilio.estado - Si la clave de país es {ZZZ} o la clave del país no existe en la columna c_Pais del catálogo c_Estado, se podrá registrar texto libremente. " & vbCrLf &
            '               "En otro caso, debe contener una clave del catálogo c_Estado, donde la columna clave de país sea igual a la clave de país registrada en el atributo [pais].", MsgBoxStyle.Exclamation, nombreModulo)
            '    Return False
            'End If

        Catch ex As Exception
            HandleError(nombreModulo, "ValidaDatoFacturaElectronica", ex)
        End Try
    End Function

    Public Function GeneraPagoElectronico33Prueba() As Boolean
        Const sProcedure As String = "GeneraPagoElectronico33Prueba"
        Dim bResultado As Boolean = False

        Dim ComprobanteFecha As String, PagoFechaPago As String
        Dim Cfd As New cComprobante33
        Dim sRutaXML As String = "C:\Agrinet\FELECTRONICA\AGRINET_LAND\Xmls_Pdfs\CULIACAN\PX-1.xml"

        Try
            ComprobanteFecha = Format(Date.Now, "yyyy-MM-dd") & "T" & Format(Date.Now, "HH:mm:ss")
            PagoFechaPago = Format(Date.Now.AddDays(-1), "yyyy-MM-dd") & "T" & Format(Date.Now.AddDays(-1), "HH:mm:ss")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Datos globales''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With Cfd
                .FolioCompleto = "PX-1"
                .Version = "3.3"
                .Serie = "PX"
                .Folio = "1"
                .Fecha = ComprobanteFecha
                .Sello = ""                     'Inicialmente va en blanco, posteriormente se genera
                .FormaPago = ""                 'Sat dice Omitir
                .NoCertificado = ""             'Se llenan dentro de Cfd.Sellar(clase comprobante) y dentro se llama a SellarFactura(modulo FacturacionElectronica)
                .Certificado = ""               'Igual que el anterior
                .CondicionesDePago = ""         'Sat dice Omitir
                .SubTotal = "0"                 'Sat dice 0
                .Descuento = ""                 'Sat dice Omitir
                .Moneda = "XXX"                 'Sat dice XXX
                .TipoCambio = ""                'Sat dice Omitir
                .Total = "0"                    'Sat dice 0
                .TipoDeComprobante = "P"        'Sat dice P
                .MetodoPago = ""                'Sat dice Omitir
                .LugarExpedicion = "80430"
                .Confirmacion = ""              'Nosotros no lo usaremos de momento
            End With
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''CfdiRelacionados''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Nota en caso de pagos aqui no van las facturas que pagan, iria mas bien algún uuid que esta sustituyendo.
            'Cfd.CfdiRelacionados.TipoRelacion = "04" '04=Sustitución de los CFDI previos
            'Cfd.CfdiRelacionados.Add("F664C038-474C-414E-B40D-2E8C4A3EFCAC")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Emisor''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With Cfd.Emisor
                .Rfc = fElectronicaValidaCampo(Empresa_Sistema.RFC)
                .Nombre = fElectronicaValidaCampo(Empresa_Sistema.NOMBRE_EMPRESA)
                .RegimenFiscal = fElectronicaValidaCampo("601")
            End With
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Receptor''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim sReceptorRFC As String, sReceptorNombre As String

            sReceptorNombre = "PUBLICO GENERAL"
            sReceptorRFC = Empresa_Sistema.RFC_VENTA_PUBLICO_GENERAL

            With Cfd.Receptor
                .Rfc = sReceptorRFC
                .Nombre = sReceptorNombre
                .UsoCFDI = "P01"
            End With
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Conceptos'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim ConceptoImpuestoTraslados As New iConceptoImpuestoTraslados33 'El SAT dice en la guia de complemento de pagos : Este nodo no debe existir , solamente le hacemos new
            Dim ConceptoImpuestoRetenciones As New iConceptoImpuestoRetenciones33 'El SAT dice en la guia de complemento de pagos : Este nodo no debe existir , solamente le hacemos new

            'El sat en la guia dice que debe llevar sólo un renglón del siguiente modo:
            Cfd.Conceptos.Add("84111506", "", "1", "ACT", "", "Pago", "0", "0", "", ConceptoImpuestoTraslados, ConceptoImpuestoRetenciones)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Impuestos'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Nodo: Impuestos(del nodo comprobante),El SAT dice en la guia de complemento de pagos : Este nodo no debe existir
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Complemento pagos'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim complementoPagos As New cComplementoPagos

            complementoPagos.CfdComprobanteLectura = Cfd 'Se ocupan validar ciertos datos del comprobante, por ello se le pasa el objeto

            With complementoPagos
                .Version = "1.0"
                .FechaPago = PagoFechaPago
                .FormaDePagoP = "03"
                .MonedaP = "MXN"
                .Monto = Format(CDec("70"), "#0.00")
                .NumOperacion = "XXX111"
                .RfcEmisorCtaOrd = ""
                .NomBancoOrdExt = ""
                .CtaOrdenante = "123456789012345666"
                .RfcEmisorCtaBen = ""
                .CtaBeneficiario = "123456789012345777"

                .TipoCadPago = "01" 'Omitir de momento
                .CertPago = "00000200002000002868" 'Omitir de momento
                .CadPago = "||01|18052017|18052017|101822|40012|BANORTE/IXE|CONECCIONES AGRICOLAS S DE RL DE CV|40|072730006388659501|CAG091015DQ8|BBVA BANCOMER|PAQA SC DE RL DE CV|40|012730001527605177|PAQ060726T93|PAGO EFECTUADO|000000000000000.00|000000000010000.00|00000200002000002868||t9VZFki7mZJgM5emr5/mJpTHKDI8bhcX+rdxqjcWKn2fsAcxfzlVf4sL2AAjtOj/OtcYCIuEvvOr9AngRPdeQLKb9KlWXO+mM8HkVALeGjZ2iAoC/P2o8SUoJoPMi9yZGy+lbC+hiJxtx+WoN1Icdis/HcNFF66poWl+oSMHQrM=" 'Omitir de momento
                .SelloPago = "t9VZFki7mZJgM5emr5/mJpTHKDI8bhcX+rdxqjcWKn2fsAcxfzlVf4sL2AAjtOj/OtcYCIuEvvOr9AngRPdeQLKb9KlWXO+mM8HkVALeGjZ2iAoC/P2o8SUoJoPMi9yZGy+lbC+hiJxtx+WoN1Icdis/HcNFF66poWl+oSMHQrM=" 'Omitir de momento

                .DoctoRelacionados.Add("1454CD62-7425-4547-A346-744186C912F5", "F", "666", "MXN", "", "PPD", "1", Format(CDec("100"), "#0.00"), Format(CDec("70"), "#0.00"), Format(CDec("30"), "#0.00"))
            End With

            Cfd.ComplementoPagos10 = complementoPagos

            'Fin de llenado de nodos del comprobante''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Cfd.GeneraCFD(TipoComprobante.PAGO_CXC, sRutaXML) = True Then
                bResultado = True
                MsgBox("Pago timbrado satisfactoriamente.", vbInformation, sProcedure)
            End If

        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Public Function GeneraPagoElectronico33(ByVal oPago As Class_CXC_Pago_CFDI_Global, ByVal bMostrarMensaje As Boolean, ByVal sRutaXML As String) As Boolean
        Const sProcedure As String = "GeneraPagoElectronico33"
        Dim bResultado As Boolean = False

        Dim sPlaza As String, ComprobanteFecha As String, PagoFechaPago As String
        Dim Cfd As New cComprobante33

        Try
            Dim oBanco As New Class_Bancos_CXC(oPago.FOLIO_BANCO)
            Dim oBancoDetalle As New Class_Bancos_CXC_Detalle(oPago.FOLIO_BANCO)

            If oBanco.Existe = False Then
                MsgBox("No se encontró el movimento de bancos global.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If oBancoDetalle.EXISTE = False Then
                MsgBox("No se encontró el movimento de bancos detalle.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            'Nota en el comprobante va la fecha del depósito.
            'ComprobanteFecha = Format(oBanco.FECHA, "yyyy-MM-dd") & "T" & Format(oBanco.FECHA_SERVIDOR, "HH:mm:ss")
            ComprobanteFecha = Format(oBanco.FECHA_EMISION_CFDI, "yyyy-MM-dd") & "T" & Format(oBanco.FECHA_EMISION_CFDI, "HH:mm:ss")

            'Debemos validar la fecha del comprobante y no la del pago.
            If ValidaDatosGenerales(FechaSatAFechaNormal(ComprobanteFecha), oPago.FELECTRONICA_CER, oPago.FELECTRONICA_KEY, oPago.FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA) = False Then
                Return False
            End If

            sPlaza = oPago.CODIGO_PLAZA.ToString

            If sPlaza <> Usuario.Codigo_Plaza.ToString Then
                If sPlaza <> Plaza.CODIGO_PLAZA.ToString Then 'Si ya estaba cargada la plaza de la factura, no se cargará de nuevo para evitar consultas.
                    tPlazaFacturaElectronica = New Class_SisPlazas(CInt(sPlaza))
                End If
            Else
                tPlazaFacturaElectronica = Plaza 'Plaza ya cargada en el inicio de sesión del usuario.
            End If

            PagoFechaPago = Format(oPago.FECHA_PAGO, "yyyy-MM-dd") & "T" & Format(oPago.FECHA_PAGO, "HH:mm:ss")

            'No funcionó poner las 12 por ser antes que la fecha del comprobante(si es que es del mismo dia), ya la propia fecha_pago tiene la hora grabada necesaria
            'PagoFechaPago = Format(oPago.FECHA_PAGO, "yyyy-MM-dd") & "T" & "12:00:00" 'Fijos a las 12 todos para no pedir la hora de pago al cliente

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Datos globales''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With Cfd
                .FolioCompleto = oPago.FOLIO_PAGO
                .Version = Empresa_Sistema.VERSION_ESQUEMA_CFD
                .Serie = oPago.SERIE
                .Folio = oPago.FOLIO_NUMERICO
                .Fecha = ComprobanteFecha
                .Sello = ""                     'Inicialmente va en blanco, posteriormente se genera
                .FormaPago = ""                 'Sat dice Omitir
                .NoCertificado = ""             'Se llenan dentro de Cfd.Sellar(clase comprobante) y dentro se llama a SellarFactura(modulo FacturacionElectronica)
                .Certificado = ""               'Igual que el anterior
                .CondicionesDePago = ""         'Sat dice Omitir
                .SubTotal = "0"                 'Sat dice 0
                .Descuento = ""                 'Sat dice Omitir
                .Moneda = "XXX"                 'Sat dice XXX
                .TipoCambio = ""                'Sat dice Omitir
                .Total = "0"                    'Sat dice 0
                .TipoDeComprobante = "P"        'Sat dice P
                .MetodoPago = ""                'Sat dice Omitir
                .LugarExpedicion = tPlazaFacturaElectronica.CODIGO_POSTAL
                .Confirmacion = ""              'Nosotros no lo usaremos de momento
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''CfdiRelacionados''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Nota en caso de pagos aqui no van las facturas que pagan, iria mas bien algún uuid que esta sustituyendo.
            'Cfd.CfdiRelacionados.TipoRelacion = "01"
            'Cfd.CfdiRelacionados.Add ("F664C038-474C-414E-B40D-2E8C4A3EFCAC")

            'Se pregunta por que no todas las facturas tienen relación.
            If txtLEN("" & oBanco.CODIGO_TIPO_RELACION_CFDI) = True Then
                Cfd.CfdiRelacionados.TipoRelacion = oBanco.CODIGO_TIPO_RELACION_CFDI

                Dim dtPagosRelacionados As DataTable = oBanco.ObtienePagosRelacionados()
                Dim FaltanUUIDRelacionados As Boolean = False

                If dtPagosRelacionados.Rows.Count = 0 Then
                    MsgBox("No se encontraron los cfdis relacionados(pagos) al pago.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                For Each dRow As DataRow In dtPagosRelacionados.Rows
                    If txtLEN("" & dRow("FOLIO_FISCAL_SAT").ToString) = False Then
                        MsgBox("El pago " & dRow("FOLIO_PAGO").ToString & " no tiene UUID(posiblemente no esta timbrada).", vbExclamation, sProcedure)
                        FaltanUUIDRelacionados = True
                    End If

                    Cfd.CfdiRelacionados.Add(dRow("FOLIO_FISCAL_SAT").ToString) 'uuids
                Next

                'En caso de que alguna factura no este timbrada se aborta el proceso.
                If FaltanUUIDRelacionados = True Then
                    Return False
                End If
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Emisor''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With Cfd.Emisor
                .Rfc = fElectronicaValidaCampo(Empresa_Sistema.RFC)
                .Nombre = fElectronicaValidaCampo(Empresa_Sistema.NOMBRE_EMPRESA)
                .RegimenFiscal = fElectronicaValidaCampo(oPago.CODIGO_REGIMEN_FISCAL)
            End With
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Receptor''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim oCliente As New Class_CatClientes(oPago.CODIGO_CLIENTE.ToString)
            Dim sReceptorRFC As String, sReceptorNombre As String

            If oCliente.Existe = False Then
                MsgBox("Cliente no encontrado.", MsgBoxStyle.Exclamation, nombreModulo)
                Return False
            End If

            If oPago.ES_A_PUBLICO_GENERAL = True Then
                sReceptorNombre = "PUBLICO GENERAL"
                sReceptorRFC = Empresa_Sistema.RFC_VENTA_PUBLICO_GENERAL
            Else
                sReceptorNombre = fElectronicaValidaCampo(oCliente.NOMBRE_CLIENTE)
                sReceptorRFC = fElectronicaValidaCampo(Replace(oCliente.RFC, "-", ""))
            End If

            With Cfd.Receptor
                .Rfc = sReceptorRFC
                .Nombre = sReceptorNombre

                'De momento no estan soportados las notas de crédito de facturas de embarques(con complemento CCE)
                'If Empresa_Sistema.FELECTRONICA_CCE_HABILITADO = True And oDescuento.ES_FACTURA_EMBARQUE_EXTRANJERO = True Then
                '    .ResidenciaFiscal = oCliente.CODIGO_PAIS_SAT  'usarlo sólo cuando el rfc sea extranjero y haya cce o numregid
                '    .NumRegIdTrib = oCliente.NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO
                'End If

                .UsoCFDI = oPago.CODIGO_USO_CFDI 'SAT dice P01, así se graba en la tabla
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Conceptos'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim ConceptoImpuestoTraslados As New iConceptoImpuestoTraslados33 'El SAT dice en la guia de complemento de pagos : Este nodo no debe existir , solamente le hacemos new
            Dim ConceptoImpuestoRetenciones As New iConceptoImpuestoRetenciones33 'El SAT dice en la guia de complemento de pagos : Este nodo no debe existir , solamente le hacemos new

            'El sat en la guia dice que debe llevar sólo un renglón del siguiente modo:
            Cfd.Conceptos.Add("84111506", "", "1", "ACT", "", "Pago", "0", "0", "", ConceptoImpuestoTraslados, ConceptoImpuestoRetenciones)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Impuestos'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Nodo: Impuestos(del nodo comprobante),El SAT dice en la guia de complemento de pagos : Este nodo no debe existir

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Complemento pagos'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim complementoPagos As New cComplementoPagos

            complementoPagos.CfdComprobanteLectura = Cfd 'Se ocupan validar ciertos datos del comprobante, por ello se le pasa el objeto

            With complementoPagos
                .Version = "1.0"
                .FechaPago = PagoFechaPago
                .FormaDePagoP = oBancoDetalle.CODIGO_METODO_PAGO
                .MonedaP = oBancoDetalle.CODIGO_MONEDA_SAT

                If .MonedaP <> "MXN" Then 'Dice el SAT, Si la clave es MXN (Peso Mexicano), no debe existir información en el campo TipoCambioP.
                    .TipoCambioP = FormatTipoCambio(oBanco.TIPO_DE_CAMBIO, False)
                End If

                .Monto = Format(oPago.MONTO, "#0.00")
                .NumOperacion = oBancoDetalle.FOLIO_DETALLE
                .RfcEmisorCtaOrd = ""
                .NomBancoOrdExt = oBancoDetalle.NOMBRE_BANCO_EMISOR_EXTRANJERO
                .CtaOrdenante = oBancoDetalle.CUENTA_EMISOR
                .RfcEmisorCtaBen = ""
                .CtaBeneficiario = oBancoDetalle.CUENTA_DESTINO

                .TipoCadPago = "" 'Omitir de momento
                .CertPago = "" 'Omitir de momento
                .CadPago = "" 'Omitir de momento
                .SelloPago = "" 'Omitir de momento

                Dim dTablaPagosDetalle As DataTable = oPago.ObtenerPagosDetalle

                If dTablaPagosDetalle.Rows.Count = 0 Then
                    MsgBox("No se encontró el detalle del pago " & oPago.FOLIO_PAGO, MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                For Each dRow As DataRow In dTablaPagosDetalle.Rows

                    Dim oPagoDetalle As New Class_CXC_Pago_CFDI_Detalle(dRow("FOLIO_CXC").ToString)

                    If oPagoDetalle.EXISTE = False Then
                        MsgBox("No se encontró el detalle del subpago " & dRow("FOLIO_CXC").ToString, MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If

                    '.DoctoRelacionados.Add(oPagoDetalle.FACTURA_FOLIO_FISCAL_SAT, oPagoDetalle.FACTURA_SERIE, oPagoDetalle.FACTURA_FOLIO_NUMERICO,
                    '                       "USD",
                    '                       FormatTipoCambio(0.043244, False, 6).ToString,
                    '                       oPagoDetalle.CODIGO_METODO_PAGO_EVENTO_DR, oPagoDetalle.NUMERO_PARCIALIDAD,
                    '                       Format(487.44, "#0.00"), Format(487.44, "#0.00"), Format(oPagoDetalle.IMPORTE_SALDO_INSOLUTO, "#0.00"))

                    .DoctoRelacionados.Add(oPagoDetalle.FACTURA_FOLIO_FISCAL_SAT, oPagoDetalle.FACTURA_SERIE, oPagoDetalle.FACTURA_FOLIO_NUMERICO,
                                           oPagoDetalle.CODIGO_MONEDA_SAT_DR,
                                           IIf(oPagoDetalle.CODIGO_MONEDA_SAT_DR <> complementoPagos.MonedaP, FormatTipoCambio(oPagoDetalle.TIPO_CAMBIO_DR, False, 6), "").ToString,
                                           oPagoDetalle.CODIGO_METODO_PAGO_EVENTO_DR, oPagoDetalle.NUMERO_PARCIALIDAD,
                                           Format(oPagoDetalle.IMPORTE_SALDO_ANTERIOR, "#0.00"), Format(oPagoDetalle.IMPORTE_PAGADO, "#0.00"), Format(oPagoDetalle.IMPORTE_SALDO_INSOLUTO, "#0.00"))
                Next

            End With

            Cfd.ComplementoPagos10 = complementoPagos

            'Fin de llenado de nodos del comprobante''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Cfd.GeneraCFD(TipoComprobante.PAGO_CXC, sRutaXML) = True Then
                bResultado = True
                If bMostrarMensaje = True Then
                    MsgBox("Pago timbrado satisfactoriamente.", vbInformation, sProcedure)
                End If
            End If

            oBanco = Nothing
            oBancoDetalle = Nothing

        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Public Function GeneraNotaCreditoCXCElectronica33(ByVal oDescuento As Class_CXC_Descuento, ByVal bMostrarMensaje As Boolean, ByVal sRutaXML As String) As Boolean
        Const sProcedure As String = "GeneraNotaCreditoCXCElectronica33"
        Dim bResultado As Boolean = False

        Dim sPlaza As String
        Dim Cfd As New cComprobante33

        Try
            If ValidaDatosGenerales(oDescuento.FECHA, oDescuento.FELECTRONICA_CER, oDescuento.FELECTRONICA_KEY, oDescuento.FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA) = False Then
                Return False
            End If

            sPlaza = oDescuento.CODIGO_PLAZA.ToString

            If sPlaza <> Usuario.Codigo_Plaza.ToString Then
                If sPlaza <> Plaza.CODIGO_PLAZA.ToString Then 'Si ya estaba cargada la plaza de la factura, no se cargará de nuevo para evitar consultas.
                    tPlazaFacturaElectronica = New Class_SisPlazas(CInt(sPlaza))
                End If
            Else
                tPlazaFacturaElectronica = Plaza 'Plaza ya cargada en el inicio de sesión del usuario.
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Datos globales''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim dSubTotal As Decimal, dDescuento As Decimal, dTotal As Decimal, dTIPO_DE_CAMBIO As Decimal

            dTIPO_DE_CAMBIO = CDec(oDescuento.TIPO_DE_CAMBIO)

            'Dim oDocumento As New Class_CatDocumentos(oDescuento.CODIGO_DOCUMENTO)
            'If oDocumento.

            dSubTotal = CDec(oDescuento.SUBTOTAL)
            dDescuento = CDec(0)
            dTotal = CDec(oDescuento.TOTAL)

            If oDescuento.CODIGO_MONEDA_SAT = "USD" Then
                'Si es un descuento por anticipo en usd los valores en dólares salen directamente de campos de descuentos.
                If oDescuento.SUBTOTAL_MXN_ANTICIPO > 0 Then
                    dSubTotal = oDescuento.SUBTOTAL_USD
                    dDescuento = 0
                    dTotal = oDescuento.TOTAL_USD
                Else
                    dSubTotal = RedondearD(dSubTotal / dTIPO_DE_CAMBIO, 2)
                    dDescuento = RedondearD(dDescuento / dTIPO_DE_CAMBIO, 2)
                    dTotal = RedondearD(dTotal / dTIPO_DE_CAMBIO, 2)
                End If
            End If

            With Cfd
                .FolioCompleto = oDescuento.FOLIO_DESCUENTO
                .Version = Empresa_Sistema.VERSION_ESQUEMA_CFD
                .Serie = oDescuento.SERIE
                .Folio = oDescuento.FOLIO_NUMERICO.ToString
                .Fecha = Format(oDescuento.FECHA, "yyyy-MM-dd") & "T" & Format(oDescuento.FECHA, "HH:mm:ss")
                .Sello = ""                     'Inicialmente va en blanco, posteriormente se genera
                .FormaPago = oDescuento.CODIGO_METODO_PAGO
                .NoCertificado = ""             'Se llenan dentro de Cfd.Sellar(clase comprobante) y dentro se llama a SellarFactura(modulo FacturacionElectronica)
                .Certificado = ""               'Igual que el anterior
                .CondicionesDePago = ""         'De momento no lo vamos usar, podria llevar frases como crédito 30 dias, etc
                .SubTotal = Format(dSubTotal, "#0.00")
                .Descuento = IIf(dDescuento > 0, Format(dDescuento, "#0.00"), "").ToString
                .Total = Format(dTotal, "#0.00")
                .Moneda = oDescuento.CODIGO_MONEDA_SAT
                If oDescuento.TIPO_DE_CAMBIO > 0 Then
                    .TipoCambio = Format(oDescuento.TIPO_DE_CAMBIO, "#0.0000")
                End If
                .TipoDeComprobante = "E" 'Egreso
                .MetodoPago = oDescuento.CODIGO_METODO_PAGO_EVENTO
                .LugarExpedicion = tPlazaFacturaElectronica.CODIGO_POSTAL
                .Confirmacion = ""
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''CfdiRelacionados''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Cfd.CfdiRelacionados.TipoRelacion = oDescuento.CODIGO_TIPO_RELACION_CFDI

            Dim dtFacturasRelacionadas As DataTable = oDescuento.ObtieneFacturasRelacionadas
            Dim FaltanUUIDRelacionados As Boolean = False

            If dtFacturasRelacionadas.Rows.Count = 0 Then
                MsgBox("No se encontraron los cfdis relacionados(facturas) a la nota de crédito.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            For Each dRow As DataRow In dtFacturasRelacionadas.Rows
                If txtLEN("" & dRow("FOLIO_FISCAL_SAT").ToString) = False Then
                    MsgBox("La factura " & dRow("FOLIO_VENTA").ToString & " no tiene UUID(posiblemente no esta timbrada).", vbExclamation, sProcedure)
                    FaltanUUIDRelacionados = True
                End If

                Cfd.CfdiRelacionados.Add(dRow("FOLIO_FISCAL_SAT").ToString) 'uuids
            Next

            'En caso de que alguna factura no este timbrada se aborta el proceso.
            If FaltanUUIDRelacionados = True Then
                Return False
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Emisor''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With Cfd.Emisor
                .Rfc = fElectronicaValidaCampo(Empresa_Sistema.RFC)
                .Nombre = fElectronicaValidaCampo(Empresa_Sistema.NOMBRE_EMPRESA)
                .RegimenFiscal = fElectronicaValidaCampo(oDescuento.CODIGO_REGIMEN_FISCAL.ToString)
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Receptor''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim oCliente As New Class_CatClientes(oDescuento.CODIGO_CLIENTE.ToString)
            Dim sReceptorRFC As String, sReceptorNombre As String

            If oCliente.Existe = False Then
                MsgBox("Cliente no encontrado.", MsgBoxStyle.Exclamation, nombreModulo)
                Return False
            End If

            If oDescuento.ES_VENTA_PUBLICO_GENERAL = "1" Then
                sReceptorNombre = "PUBLICO GENERAL"
                sReceptorRFC = Empresa_Sistema.RFC_VENTA_PUBLICO_GENERAL
            Else
                sReceptorNombre = fElectronicaValidaCampo(oCliente.NOMBRE_CLIENTE)
                sReceptorRFC = fElectronicaValidaCampo(Replace(oCliente.RFC, "-", ""))
            End If

            With Cfd.Receptor
                .Rfc = sReceptorRFC
                .Nombre = sReceptorNombre

                'De momento no estan soportados las notas de crédito de facturas de embarques(con complemento CCE)
                'If Empresa_Sistema.FELECTRONICA_CCE_HABILITADO = True And oDescuento.ES_FACTURA_EMBARQUE_EXTRANJERO = True Then
                '    .ResidenciaFiscal = oCliente.CODIGO_PAIS_SAT  'usarlo sólo cuando el rfc sea extranjero y haya cce o numregid
                '    .NumRegIdTrib = oCliente.NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO
                'End If

                .UsoCFDI = oDescuento.CODIGO_USO_CFDI
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Conceptos'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim ConceptoImpuestoTraslados As iConceptoImpuestoTraslados33
            Dim ConceptoImpuestoRetenciones As iConceptoImpuestoRetenciones33

            Dim drImporte As Decimal, drPrecio As Decimal, drCantidad As Decimal, drDESCUENTO_IMPORTE As Decimal, drIMPUESTO_PORCENTAJE As Decimal
            Dim drBASE_IEPS As Decimal = 0, drBASE_IVA As Decimal, drIMPUESTO_IMPORTE As Decimal, drIEPS_IMPORTE As Decimal = 0, drIEPS_PORCENTAJE As Decimal = 0
            Dim drRetencionIVA As Decimal, drRetencionPorcentaje As Decimal

            'Es una nota de crédito directa y llevará un sólo concepto.
            drCantidad = 1
            drPrecio = CDec(oDescuento.SUBTOTAL)
            drImporte = CDec(oDescuento.SUBTOTAL)

            If oDescuento.CODIGO_MONEDA_SAT = "USD" Then
                'Si es un descuento por anticipo en usd los valores en dólares salen directamente de campos de descuentos.
                If oDescuento.SUBTOTAL_MXN_ANTICIPO > 0 Then
                    drPrecio = oDescuento.SUBTOTAL_USD
                    drImporte = oDescuento.SUBTOTAL_USD
                Else
                    drPrecio = RedondearD(drPrecio / dTIPO_DE_CAMBIO, 2)
                    drImporte = RedondearD(drImporte / dTIPO_DE_CAMBIO, 2)
                End If
            End If

            drDESCUENTO_IMPORTE = CDec(0)
            drIMPUESTO_PORCENTAJE = CDec(oDescuento.IMPUESTO_PORCENTAJE) / 100

            If oDescuento.CODIGO_MONEDA_SAT = "USD" AndAlso oDescuento.SUBTOTAL_MXN_ANTICIPO > 0 Then
                drIMPUESTO_IMPORTE = oDescuento.IVA_USD
            Else
                drIMPUESTO_IMPORTE = CDec(oDescuento.IVA)
            End If

            If drIMPUESTO_PORCENTAJE > 0 Then
                drBASE_IVA = RedondearD(drIMPUESTO_IMPORTE / drIMPUESTO_PORCENTAJE, 2) 'Se obtiene hacia atras para no tener complicaciones de calculos
            End If

            'De momento se permiten descuentos por antipo con retenciones.
            drRetencionIVA = CDec(oDescuento.RETENCION_IVA)
            drRetencionPorcentaje = CDec(oDescuento.RETENCION_IVA_PORCENTAJE) / 100

            ConceptoImpuestoTraslados = New iConceptoImpuestoTraslados33
            ConceptoImpuestoRetenciones = New iConceptoImpuestoRetenciones33

            If oDescuento.IEPS_DESGLOSADO > 0 Then
                Dim dtIEPS As DataTable
                dtIEPS = oDescuento.ObtieneDetalleIEPS

                For Each dRow As DataRow In dtIEPS.Rows

                    drIEPS_IMPORTE = CDec(dRow("IEPS_IMPORTE"))
                    drIEPS_PORCENTAJE = CDec(dRow("IEPS_PORCENTAJE")) / CDec("100.00") 'Este viene como 6,7,9
                    drBASE_IEPS = RedondearD(drIEPS_IMPORTE / drIEPS_PORCENTAJE, 2) 'Se obtiene hacia atras para no tener complicaciones de calculos

                    If oDescuento.CODIGO_MONEDA_SAT = "USD" Then
                        drBASE_IEPS = RedondearD(drBASE_IEPS / dTIPO_DE_CAMBIO, 2)
                        drIEPS_IMPORTE = RedondearD(drIEPS_IMPORTE / dTIPO_DE_CAMBIO, 2)
                    End If

                    ConceptoImpuestoTraslados.Add(Format(drBASE_IEPS, "##0.00"), "003", "Tasa", Format(drIEPS_PORCENTAJE, "0.#00000"), Format(drIEPS_IMPORTE, "##0.00"))
                Next
            End If

            If drIMPUESTO_IMPORTE > 0 Then 'IVA
                If oDescuento.CODIGO_MONEDA_SAT = "USD" Then

                    If oDescuento.SUBTOTAL_MXN_ANTICIPO > 0 Then
                        'drBASE_IVA y drIMPUESTO_IMPORTE ya vienen un usd
                    Else
                        drBASE_IVA = RedondearD(drBASE_IVA / dTIPO_DE_CAMBIO, 2)
                        drIMPUESTO_IMPORTE = RedondearD(drIMPUESTO_IMPORTE / dTIPO_DE_CAMBIO, 2)
                    End If

                    If drRetencionIVA > 0 Then
                        drRetencionIVA = RedondearD(drRetencionIVA / dTIPO_DE_CAMBIO, 2)
                    End If
                End If

                ConceptoImpuestoTraslados.Add(Format(drBASE_IVA, "##0.00"), "002", "Tasa", Format(drIMPUESTO_PORCENTAJE, "0.#00000"), Format(drIMPUESTO_IMPORTE, "##0.00"))

                If drRetencionIVA > 0 Then
                    ConceptoImpuestoRetenciones.Add(Format(drBASE_IVA, "##0.000000"), "002", "Tasa", Format(drRetencionPorcentaje, "0.#00000"), Format(drRetencionIVA, "##0.00"))
                End If

            End If

            Cfd.Conceptos.Add("84111506", "",
                                    Format(drCantidad, "##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CANTIDAD)),
                                    "ACT", "NO APLICA", fElectronicaValidaCampo(oDescuento.CONCEPTO1),
                                    Format(drPrecio, "##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)),
                                    Format(drImporte, "##0.00"),
                                    IIf(drDESCUENTO_IMPORTE > 0, Format(drDESCUENTO_IMPORTE, "##0.00"), "").ToString, ConceptoImpuestoTraslados, ConceptoImpuestoRetenciones)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Impuestos'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim arr() As iImpuestosTraslado33, dImpuestoIEPSImporte As Decimal, dImpuestoIVAImporte As Decimal, iEncontrados As Integer = 0
            Dim arr2() As iImpuestosRetencion33, dRetencionIvaImporte As Decimal

            'IEPS, deben acumularse, puede ser que mas de un artículo tenga el mismo % de ieps, de modo que aquí se juntan en uno sólo.
            iEncontrados = 0
            arr = ImpuestosTrasladoAgrupados(Cfd, "003", iEncontrados)

            If iEncontrados > 0 Then
                For i = 1 To UBound(arr)
                    dImpuestoIEPSImporte = CDec(arr(i).Importe)

                    'Nota, no es necesario preguntar si es en USD y dividir por el tipo de cambio porque este valor se llena con el desglose x concepto el cual ya esta en USD

                    Cfd.Impuestos.Traslados.Add(arr(i).Impuesto, arr(i).TipoFactor, arr(i).TasaOCuota, Format(dImpuestoIEPSImporte, "#0.00")) 'arr(i).TasaOCuota ya esta formateado
                Next
            End If

            'Aqui no hay de momento ivas al 0 o exento, esto es un descuento directo, hay otra función para las notas de crédito x devolución
            ''IVA
            'Nota el total de iva ya esta acumulado y es un sólo tipo de iva por se obtiene directamente del documento(a diferencia del ieps)
            If oDescuento.IVA > 0 Then
                'rsDocumento!IMPUESTO_PORCENTAJE viene como 16, se ocupa dividir

                dImpuestoIVAImporte = CDec(oDescuento.IVA)

                If oDescuento.CODIGO_MONEDA_SAT = "USD" Then
                    If oDescuento.SUBTOTAL_MXN_ANTICIPO > 0 Then
                        dImpuestoIVAImporte = oDescuento.IVA_USD
                    Else
                        dImpuestoIVAImporte = RedondearD(dImpuestoIVAImporte / dTIPO_DE_CAMBIO, 2)
                    End If
                End If

                Cfd.Impuestos.Traslados.Add("002", "Tasa", Format(oDescuento.IMPUESTO_PORCENTAJE / CDec("100.00"), "0.#00000"), Format(dImpuestoIVAImporte, "#0.00"))
            End If

            ''RETENCION IVA
            iEncontrados = 0
            arr2 = ImpuestosRetenidosAgrupados(Cfd, iEncontrados)

            If iEncontrados > 0 Then
                For i = 1 To UBound(arr2)
                    dRetencionIvaImporte = CDec(arr2(i).Importe)
                    Cfd.Impuestos.Retenciones.Add(arr2(i).Impuesto, Format(dRetencionIvaImporte, "#0.00"))
                Next
            End If

            'Fin de llenado de nodos del comprobante''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Cfd.GeneraCFD(TipoComprobante.NOTA_CREDITO_CXC, sRutaXML) = True Then
                bResultado = True
                If bMostrarMensaje = True Then
                    MsgBox("Nota de crédito timbrada satisfactoriamente.", vbInformation, sProcedure)
                End If
            End If

        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Public Function GeneraDevolucionElectronica33(ByVal oDevolucion As Class_CXC_Devoluciones_Global, ByVal bMostrarMensaje As Boolean, ByVal sRutaXML As String) As Boolean
        Const sProcedure As String = "GeneraDevolucionElectronica33"
        Dim bResultado As Boolean = False

        Dim sPlaza As String
        Dim Cfd As New cComprobante33
        Dim oVenta As Class_Ventas_Global

        Try
            If ValidaDatosGenerales(oDevolucion.FECHA, oDevolucion.FELECTRONICA_CER, oDevolucion.FELECTRONICA_KEY, oDevolucion.FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA) = False Then
                Return False
            End If

            sPlaza = oDevolucion.CODIGO_PLAZA.ToString

            If sPlaza <> Usuario.Codigo_Plaza.ToString Then
                If sPlaza <> Plaza.CODIGO_PLAZA.ToString Then 'Si ya estaba cargada la plaza de la factura, no se cargará de nuevo para evitar consultas.
                    tPlazaFacturaElectronica = New Class_SisPlazas(CInt(sPlaza))
                End If
            Else
                tPlazaFacturaElectronica = Plaza 'Plaza ya cargada en el inicio de sesión del usuario.
            End If

            oVenta = New Class_Ventas_Global(oDevolucion.FOLIO_VENTA)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Datos globales''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim dSubTotal As Decimal, dDescuento As Decimal, dTotal As Decimal, dTIPO_DE_CAMBIO As Decimal

            dTIPO_DE_CAMBIO = CDec(oDevolucion.TIPO_DE_CAMBIO)

            dSubTotal = CDec(oDevolucion.SUBTOTAL)
            dDescuento = CDec(0)
            dTotal = CDec(oDevolucion.TOTAL)

            If oDevolucion.CODIGO_MONEDA_SAT = "USD" Then
                dSubTotal = RedondearD(dSubTotal / dTIPO_DE_CAMBIO, 2)
                dDescuento = RedondearD(dDescuento / dTIPO_DE_CAMBIO, 2)
                dTotal = RedondearD(dTotal / dTIPO_DE_CAMBIO, 2)
            End If

            With Cfd
                .FolioCompleto = oDevolucion.FOLIO_DEVOLUCION
                .Version = Empresa_Sistema.VERSION_ESQUEMA_CFD
                .Serie = oDevolucion.SERIE
                .Folio = oDevolucion.FOLIO_NUMERICO.ToString
                .Fecha = Format(oDevolucion.FECHA, "yyyy-MM-dd") & "T" & Format(oDevolucion.FECHA, "HH:mm:ss")
                .Sello = ""                     'Inicialmente va en blanco, posteriormente se genera
                .FormaPago = oDevolucion.CODIGO_METODO_PAGO
                .NoCertificado = ""             'Se llenan dentro de Cfd.Sellar(clase comprobante) y dentro se llama a SellarFactura(modulo FacturacionElectronica)
                .Certificado = ""               'Igual que el anterior
                .CondicionesDePago = ""         'De momento no lo vamos usar, podria llevar frases como crédito 30 dias, etc
                .SubTotal = Format(dSubTotal, "#0.00")
                .Descuento = IIf(dDescuento > 0, Format(dDescuento, "#0.00"), "").ToString
                .Total = Format(dTotal, "#0.00")
                .Moneda = oDevolucion.CODIGO_MONEDA_SAT
                If oDevolucion.TIPO_DE_CAMBIO > 0 Then
                    .TipoCambio = FormatTipoCambio(oDevolucion.TIPO_DE_CAMBIO, False)
                End If
                .TipoDeComprobante = "E" 'E=Engreso
                .MetodoPago = oDevolucion.CODIGO_METODO_PAGO_EVENTO
                .LugarExpedicion = tPlazaFacturaElectronica.CODIGO_POSTAL
                .Confirmacion = ""
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''CfdiRelacionados''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Cfd.CfdiRelacionados.TipoRelacion = oDevolucion.CODIGO_TIPO_RELACION_CFDI

            If txtLEN(oVenta.FOLIO_FISCAL_SAT) = False Then
                MsgBox("La factura " & oDevolucion.FOLIO_VENTA & " no tiene UUID(tal vez no este timbrada). No se podrá timbrar la devolución.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            Cfd.CfdiRelacionados.Add(oVenta.FOLIO_FISCAL_SAT)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Emisor''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With Cfd.Emisor
                .Rfc = fElectronicaValidaCampo(Empresa_Sistema.RFC)
                .Nombre = fElectronicaValidaCampo(Empresa_Sistema.NOMBRE_EMPRESA)
                .RegimenFiscal = fElectronicaValidaCampo(oDevolucion.CODIGO_REGIMEN_FISCAL.ToString)
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Receptor''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim oCliente As New Class_CatClientes(oDevolucion.CODIGO_CLIENTE.ToString)
            Dim sReceptorRFC As String, sReceptorNombre As String

            If oCliente.Existe = False Then
                MsgBox("Cliente no encontrado.", MsgBoxStyle.Exclamation, nombreModulo)
                Return False
            End If

            If oDevolucion.ES_A_PUBLICO_GENERAL = "1" Then
                sReceptorNombre = "PUBLICO GENERAL"
                sReceptorRFC = Empresa_Sistema.RFC_VENTA_PUBLICO_GENERAL
            Else
                sReceptorNombre = fElectronicaValidaCampo(oCliente.NOMBRE_CLIENTE)
                sReceptorRFC = fElectronicaValidaCampo(Replace(oCliente.RFC, "-", ""))
            End If

            With Cfd.Receptor
                .Rfc = sReceptorRFC
                .Nombre = sReceptorNombre
                .ResidenciaFiscal = ""
                .NumRegIdTrib = ""
                .UsoCFDI = oDevolucion.CODIGO_USO_CFDI
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Conceptos'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim ConceptoImpuestoTraslados As iConceptoImpuestoTraslados33
            Dim ConceptoImpuestoRetenciones As iConceptoImpuestoRetenciones33

            Dim drImporte As Decimal, drPrecio As Decimal, drCantidad As Decimal, drDESCUENTO_IMPORTE As Decimal, drIMPUESTO_PORCENTAJE As Decimal
            Dim drBASE_IEPS As Decimal, drBASE_IVA As Decimal, drIMPUESTO_IMPORTE As Decimal, drIEPS_IMPORTE As Decimal, drIEPS_PORCENTAJE As Decimal

            Dim drRETENCION_IVA_PORCENTAJE As Decimal = 0, drRETENCION_IVA_BASE As Decimal = 0, drRETENCION_IVA_IMPORTE As Decimal = 0
            Dim drRETENCION_ISR_PORCENTAJE As Decimal = 0, drRETENCION_ISR_BASE As Decimal = 0, drRETENCION_ISR_IMPORTE As Decimal = 0

            For Each row As DataRow In oDevolucion.ObtenerDetalleParaCFDI.Rows
                drCantidad = CDec(row("CANTIDAD").ToString)
                drIMPUESTO_PORCENTAJE = CDec(row("IMPUESTO_PORCENTAJE").ToString) / CDec("100.00")
                drIEPS_PORCENTAJE = CDec(row("IEPS_PORCENTAJE").ToString) / CDec("100.00")

                drRETENCION_IVA_PORCENTAJE = CDec(row("RETENCION_IVA_PORCENTAJE").ToString)
                drRETENCION_IVA_BASE = CDec(row("RETENCION_IVA_BASE").ToString)
                drRETENCION_IVA_IMPORTE = CDec(row("RETENCION_IVA_IMPORTE").ToString)

                drRETENCION_ISR_PORCENTAJE = CDec(row("RETENCION_ISR_PORCENTAJE").ToString)
                drRETENCION_ISR_BASE = CDec(row("RETENCION_ISR_BASE").ToString)
                drRETENCION_ISR_IMPORTE = CDec(row("RETENCION_ISR_IMPORTE").ToString)

                drPrecio = CDec(row("PRECIO_TOTAL").ToString)
                drImporte = CDec(row("IMPORTE").ToString)
                drDESCUENTO_IMPORTE = CDec("0.00")

                If oDevolucion.CODIGO_MONEDA_SAT = "USD" Then
                    drPrecio = RedondearD(drPrecio / dTIPO_DE_CAMBIO, 3)
                    drImporte = RedondearD(drImporte / dTIPO_DE_CAMBIO, 2)
                    drDESCUENTO_IMPORTE = RedondearD(drDESCUENTO_IMPORTE / dTIPO_DE_CAMBIO, 2)
                End If

                ConceptoImpuestoTraslados = New iConceptoImpuestoTraslados33
                ConceptoImpuestoRetenciones = New iConceptoImpuestoRetenciones33

                '003=IEPS,002=IVA

                If oDevolucion.TIENE_IEPS_DESGLOSADO = True Then
                    If row("GRADO_TOXICIDAD").ToString <> "0" Then '0=no graba ieps, <>0 significa que si graba ieps : 1-4=con alguna tasa,5=Exento(aún siendo exento hay que llenar la base ieps)
                        drBASE_IEPS = CDec(row("BASE_IEPS").ToString)
                        drIEPS_IMPORTE = CDec(row("IEPS_IMPORTE").ToString)

                        If oDevolucion.CODIGO_MONEDA_SAT = "USD" Then
                            drBASE_IEPS = RedondearD(drBASE_IEPS / dTIPO_DE_CAMBIO, 2)
                            drIEPS_IMPORTE = RedondearD(drIEPS_IMPORTE / dTIPO_DE_CAMBIO, 2)
                        End If

                        If row("GRADO_TOXICIDAD").ToString = "5" Then '5=Ieps Exento
                            'ConceptoImpuestoTraslados.Add(Format(drBASE_IEPS, "##0.00"), "003", "Exento", "", "")
                            ConceptoImpuestoTraslados.Add(Format(drBASE_IEPS, "##0.000000"), "003", "Exento", "", "")
                        Else
                            'ConceptoImpuestoTraslados.Add(Format(drBASE_IEPS, "##0.00"), "003", "Tasa", Format(drIEPS_PORCENTAJE, "0.#00000"), Format(drIEPS_IMPORTE, "##0.00"))
                            ConceptoImpuestoTraslados.Add(Format(drBASE_IEPS, "##0.000000"), "003", "Tasa", Format(drIEPS_PORCENTAJE, "0.#00000"), Format(drIEPS_IMPORTE, "##0.00"))
                        End If
                    End If
                End If

                If row("ID_SIS_CAT_IMPUESTOS").ToString <> "N" Then 'N=No grava iva, si es <>N = Si grava iva ya sea al 0,16,Exento(aún siendo exento ó 0 hay que llenar la base iva)
                    drBASE_IVA = CDec(row("BASE_IVA").ToString)
                    drIMPUESTO_IMPORTE = CDec(row("IMPUESTO_IMPORTE").ToString)

                    If oDevolucion.CODIGO_MONEDA_SAT = "USD" Then
                        drBASE_IVA = RedondearD(drBASE_IVA / dTIPO_DE_CAMBIO, 2)
                        drIMPUESTO_IMPORTE = RedondearD(drIMPUESTO_IMPORTE / dTIPO_DE_CAMBIO, 2)
                    End If

                    If row("ID_SIS_CAT_IMPUESTOS").ToString = "E" Then 'E=Iva Exento
                        'ConceptoImpuestoTraslados.Add(Format(drBASE_IVA, "##0.00"), "002", "Exento", "", "")
                        ConceptoImpuestoTraslados.Add(Format(drBASE_IVA, "##0.000000"), "002", "Exento", "", "")
                    Else
                        'ConceptoImpuestoTraslados.Add(Format(drBASE_IVA, "##0.00"), "002", "Tasa", Format(drIMPUESTO_PORCENTAJE, "0.#00000"), Format(drIMPUESTO_IMPORTE, "##0.00"))
                        ConceptoImpuestoTraslados.Add(Format(drBASE_IVA, "##0.000000"), "002", "Tasa", Format(drIMPUESTO_PORCENTAJE, "0.#00000"), Format(drIMPUESTO_IMPORTE, "##0.00"))
                    End If
                End If

                If drRETENCION_IVA_IMPORTE > 0 Then
                    If oDevolucion.CODIGO_MONEDA_SAT = "USD" Then
                        drRETENCION_IVA_BASE = RedondearD(drRETENCION_IVA_BASE / dTIPO_DE_CAMBIO, 2)
                        drRETENCION_IVA_IMPORTE = RedondearD(drRETENCION_IVA_IMPORTE / dTIPO_DE_CAMBIO, 2)
                    End If

                    ConceptoImpuestoRetenciones.Add(Format(drRETENCION_IVA_BASE, "##0.00"), "002", "Tasa", Format(drRETENCION_IVA_PORCENTAJE, "0.#00000"), Format(drRETENCION_IVA_IMPORTE, "##0.00")) '002=IVA
                End If

                If drRETENCION_ISR_IMPORTE > 0 Then
                    If oDevolucion.CODIGO_MONEDA_SAT = "USD" Then
                        drRETENCION_ISR_BASE = RedondearD(drRETENCION_ISR_BASE / dTIPO_DE_CAMBIO, 2)
                        drRETENCION_ISR_IMPORTE = RedondearD(drRETENCION_ISR_IMPORTE / dTIPO_DE_CAMBIO, 2)
                    End If

                    ConceptoImpuestoRetenciones.Add(Format(drRETENCION_ISR_BASE, "##0.00"), "001", "Tasa", Format(drRETENCION_ISR_PORCENTAJE, "0.#00000"), Format(drRETENCION_ISR_IMPORTE, "##0.00")) '001=ISR
                End If

                'If oDevolucion.IEPS_DESGLOSADO > 0 Then 'Solamente si se le desglosan los ieps se mencionan, si es incluido no(como si no tuviera), por eso se pregunta por el total y no del renglón porque al ser inc si va tener ieps pero no es parte del xml
                '    If CDec(row("IEPS_PORCENTAJE").ToString) > 0 Then 'Este viene como 6,7,9
                '        drBASE_IEPS = CDec(row("BASE_IEPS").ToString)
                '        drIEPS_IMPORTE = CDec(row("IEPS_IMPORTE").ToString)

                '        If oDevolucion.CODIGO_MONEDA_SAT = "USD" Then
                '            drBASE_IEPS = RedondearD(drBASE_IEPS / dTIPO_DE_CAMBIO, 2)
                '            drIEPS_IMPORTE = RedondearD(drIEPS_IMPORTE / dTIPO_DE_CAMBIO, 2)
                '        End If

                '        ConceptoImpuestoTraslados.Add(Format(drBASE_IEPS, "##0.00"), "003", "Tasa", Format(drIEPS_PORCENTAJE, "0.#00000"), Format(drIEPS_IMPORTE, "##0.00"))
                '    End If
                'End If

                'If drIMPUESTO_PORCENTAJE > 0 Then
                '    drBASE_IVA = CDec(row("BASE_IVA").ToString)
                '    drIMPUESTO_IMPORTE = CDec(row("IMPUESTO_IMPORTE").ToString)

                '    If oDevolucion.CODIGO_MONEDA_SAT = "USD" Then
                '        drBASE_IVA = RedondearD(drBASE_IVA / dTIPO_DE_CAMBIO, 2)
                '        drIMPUESTO_IMPORTE = RedondearD(drIMPUESTO_IMPORTE / dTIPO_DE_CAMBIO, 2)
                '    End If

                '    ConceptoImpuestoTraslados.Add(Format(drBASE_IVA, "##0.00"), "002", "Tasa", Format(drIMPUESTO_PORCENTAJE, "0.#00000"), Format(drIMPUESTO_IMPORTE, "##0.00"))
                'End If

                'Format(drPrecio, "##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO))
                Cfd.Conceptos.Add(row("CODIGO_PRODUCTO_SERVICIO").ToString, row("CODIGO_ARTICULO").ToString,
                                  Format(drCantidad, "##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CANTIDAD)),
                                  row("CODIGO_UNIDAD").ToString, row("UNIDAD_VENTA").ToString, fElectronicaValidaCampo(row("DESCRIPCION").ToString),
                                  Format(drPrecio, "##0." & StrDup(6, "0")),
                                  Format(drImporte, "##0.00"),
                                  IIf(drDESCUENTO_IMPORTE > 0, Format(drDESCUENTO_IMPORTE, "##0.00"), "").ToString, ConceptoImpuestoTraslados, ConceptoImpuestoRetenciones)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Impuestos'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim arr() As iImpuestosTraslado33, dImpuestoIEPSImporte As Decimal, dImpuestoIVAImporte As Decimal, iEncontrados As Integer = 0
            Dim arr2() As iImpuestosRetencion33, dRetencionIvaImporte As Decimal

            ''IEPS, deben acumularse, puede ser que mas de un artículo tenga el mismo % de ieps, de modo que aquí se juntan en uno sólo.
            iEncontrados = 0
            arr = ImpuestosTrasladoAgrupados(Cfd, "003", iEncontrados)

            If iEncontrados > 0 Then
                For i = 1 To UBound(arr)
                    dImpuestoIEPSImporte = CDec(arr(i).Importe)

                    'Nota, no es necesario preguntar si es en USD y dividir por el tipo de cambio porque este valor se llena con el desglose x concepto el cual ya esta en USD

                    Cfd.Impuestos.Traslados.Add(arr(i).Impuesto, arr(i).TipoFactor, arr(i).TasaOCuota, Format(dImpuestoIEPSImporte, "#0.00")) 'arr(i).TasaOCuota ya esta formateado
                Next
            End If

            ''IVA
            iEncontrados = 0
            arr = ImpuestosTrasladoAgrupados(Cfd, "002", iEncontrados) 'comprobar aqui que agrupe 0 y 16 pero no exentos."

            If iEncontrados > 0 Then
                For i = 1 To UBound(arr)
                    dImpuestoIVAImporte = CDec(arr(i).Importe)

                    Cfd.Impuestos.Traslados.Add(arr(i).Impuesto, arr(i).TipoFactor, arr(i).TasaOCuota, Format(dImpuestoIVAImporte, "#0.00")) 'arr(i).TasaOCuota ya esta formateado
                Next
            End If

            ''RETENCION IVA
            iEncontrados = 0
            arr2 = ImpuestosRetenidosAgrupados(Cfd, iEncontrados)

            If iEncontrados > 0 Then
                For i = 1 To UBound(arr2)
                    dRetencionIvaImporte = CDec(arr2(i).Importe)
                    Cfd.Impuestos.Retenciones.Add(arr2(i).Impuesto, Format(dRetencionIvaImporte, "#0.00"))
                Next
            End If

            ''IEPS, deben acumularse, puede ser que mas de un artículo tenga el mismo % de ieps, de modo que aquí se juntan en uno sólo.
            'If oDevolucion.IEPS_DESGLOSADO > 0 Then 'Solamente si se le desglosan los ieps se mencionan, si es incluido no(como si no tuviera), por eso se pregunta por el total y no del renglón porque al ser inc si va tener ieps pero no es parte del xml
            '    arr = ImpuestosTrasladoAgrupados(Cfd)

            '    For i = 1 To UBound(arr)
            '        dImpuestoIEPSImporte = CDec(arr(i).Importe)

            '        'Nota, no es necesario preguntar si es en USD y dividir por el tipo de cambio porque este valor se llena con el desglose x concepto el cual ya esta en USD

            '        Cfd.Impuestos.Traslados.Add(arr(i).Impuesto, arr(i).TipoFactor, arr(i).TasaOCuota, Format(dImpuestoIEPSImporte, "#0.00")) 'arr(i).TasaOCuota ya esta formateado
            '    Next
            'End If

            ''IVA
            ''Nota el total de iva ya esta acumulado y es un sólo tipo de iva por se obtiene directamente del documento(a diferencia del ieps)
            'If oDevolucion.IMPUESTO > 0 Then
            '    'rsDocumento!IMPUESTO_PORCENTAJE viene como 16, se ocupa dividir

            '    dImpuestoIVAImporte = CDec(oDevolucion.IMPUESTO)

            '    If oDevolucion.CODIGO_MONEDA_SAT = "USD" Then
            '        dImpuestoIVAImporte = RedondearD(dImpuestoIVAImporte / dTIPO_DE_CAMBIO, 2)
            '    End If

            '    Cfd.Impuestos.Traslados.Add("002", "Tasa", Format(oDevolucion.IMPUESTO_PORCENTAJE / CDec("100.00"), "0.#00000"), Format(dImpuestoIVAImporte, "#0.00"))
            'End If

            'Fin de llenado de nodos del comprobante''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Cfd.GeneraCFD(TipoComprobante.DEVOLUCION_CXC, sRutaXML) = True Then
                bResultado = True
                If bMostrarMensaje = True Then
                    MsgBox("Devolución timbrada satisfactoriamente.", vbInformation, sProcedure)
                End If
            End If

        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Public Function GeneraFacturaTrasladoElectronica33(ByVal oVenta As Class_Ventas_Global, ByVal bMostrarMensaje As Boolean, ByVal sRutaXML As String) As Boolean
        Const sProcedure As String = "GeneraFacturaTrasladoElectronica33"
        Dim bResultado As Boolean = False

        Dim sPlaza As String
        Dim Cfd As New cComprobante33

        Try
            If ValidaDatosGenerales(oVenta.FECHA, oVenta.FELECTRONICA_CER, oVenta.FELECTRONICA_KEY, oVenta.FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA) = False Then
                Return False
            End If

            If oVenta.ES_FACTURA_EMBARQUE_EXTRANJERO = True And (oVenta.IMPUESTO > 0 Or oVenta.IEPS_TOTAL_DESGLOSADO > 0 Or oVenta.IEPS_TOTAL_YA_INCLUIDO > 0) Then
                MsgBox("No esta soportado actualmente por este sistema que lo embarques extranjeros lleven impuestos iva/ieps.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            'If Empresa_Sistema.FELECTRONICA_CCE_HABILITADO = True And oVenta.ES_FACTURA_EMBARQUE_EXTRANJERO = True Then
            '    If ValidaComplementoExterior(Cfd) = False Then
            '        Return False
            '    End If
            'End If

            sPlaza = oVenta.CODIGO_PLAZA.ToString

            If sPlaza <> Usuario.Codigo_Plaza.ToString Then
                If sPlaza <> Plaza.CODIGO_PLAZA.ToString Then 'Si ya estaba cargada la plaza de la factura, no se cargará de nuevo para evitar consultas.
                    tPlazaFacturaElectronica = New Class_SisPlazas(CInt(sPlaza))
                End If
            Else
                tPlazaFacturaElectronica = Plaza 'Plaza ya cargada en el inicio de sesión del usuario.
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Datos globales''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim dSubTotal As Decimal, dDescuento As Decimal, dTotal As Decimal, dTIPO_DE_CAMBIO As Decimal

            dTIPO_DE_CAMBIO = CDec(oVenta.TIPO_DE_CAMBIO)

            If oVenta.ES_FACTURA_EMBARQUE_EXTRANJERO = True Then
                MsgBox("De momento no se pueden timbrar facturas de embarques extranjeros", vbExclamation, sProcedure)
                Return False
                '    dSubTotal = CDec(oVenta.TOTAL_DOLARES)
                '    dDescuento = CDec(oVenta.DESCUENTO_USD)
                '    dTotal = 0
                'Else
                '    dSubTotal = CDec(oVenta.SUBTOTAL)
                '    dDescuento = CDec(oVenta.DESCUENTO)
                '    dTotal = CDec(oVenta.TOTAL)

                '    If oVenta.CODIGO_MONEDA_SAT = "USD" Then
                '        dSubTotal = RedondearD(dSubTotal / dTIPO_DE_CAMBIO, 2)
                '        dDescuento = RedondearD(dDescuento / dTIPO_DE_CAMBIO, 2)
                '        dTotal = RedondearD(dTotal / dTIPO_DE_CAMBIO, 2)
                '    End If
            End If

            If oVenta.CODIGO_MONEDA_SAT = "MXN" Or oVenta.CODIGO_MONEDA_SAT = "XXX" Then
                dSubTotal = CDec(oVenta.SUBTOTAL)
                dDescuento = CDec(oVenta.DESCUENTO)
                dTotal = CDec(oVenta.TOTAL)
            ElseIf oVenta.CODIGO_MONEDA_SAT = "USD" Then
                dSubTotal = CDec(oVenta.SUBTOTAL_USD)
                dDescuento = CDec(oVenta.DESCUENTO_USD)
                dTotal = CDec(oVenta.TOTAL_DOLARES)
            Else
                MsgBox("Moneda SAT inválida no se pueden timbrar facturas de embarques extranjeros", vbExclamation, sProcedure)
            End If

            'If oVenta.CODIGO_TIPO_DOCUMENTO = "FT" Then 'Factura de traslado

            With Cfd
                .FolioCompleto = oVenta.FOLIO_VENTA
                .Version = Empresa_Sistema.VERSION_ESQUEMA_CFD
                .Serie = oVenta.SERIE
                .Folio = oVenta.FOLIO_NUMERICO.ToString
                .Fecha = Format(oVenta.FECHA, "yyyy-MM-dd") & "T" & Format(oVenta.FECHA, "HH:mm:ss")
                .Sello = ""                     'Inicialmente va en blanco, posteriormente se genera
                .FormaPago = "" & oVenta.CODIGO_METODO_PAGO
                .NoCertificado = ""             'Se llenan dentro de Cfd.Sellar(clase comprobante) y dentro se llama a SellarFactura(modulo FacturacionElectronica)
                .Certificado = ""               'Igual que el anterior
                .CondicionesDePago = ""         'De momento no lo vamos usar, podria llevar frases como crédito 30 dias, etc
                .SubTotal = Format(dSubTotal, "#0.00")
                .Descuento = IIf(dDescuento > 0, Format(dDescuento, "#0.00"), "").ToString
                .Total = Format(dTotal, "#0.00")
                .Moneda = oVenta.CODIGO_MONEDA_SAT
                If oVenta.TIPO_DE_CAMBIO > 0 Then
                    .TipoCambio = FormatTipoCambio(oVenta.TIPO_DE_CAMBIO, False)
                End If
                If oVenta.CODIGO_TIPO_DOCUMENTO = "FT" Then 'Factura de traslado
                    .TipoDeComprobante = "T" 'Traslado
                Else
                    .TipoDeComprobante = "I" 'Ingreso
                End If
                .MetodoPago = "" & oVenta.CODIGO_METODO_PAGO_EVENTO
                .LugarExpedicion = tPlazaFacturaElectronica.CODIGO_POSTAL
                .Confirmacion = ""
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''CfdiRelacionados''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Se pregunta por que no todas las facturas tienen relación.
            If txtLEN("" & oVenta.CODIGO_TIPO_RELACION_CFDI) = True Then
                Cfd.CfdiRelacionados.TipoRelacion = oVenta.CODIGO_TIPO_RELACION_CFDI

                Dim dtFacturasRelacionadas As DataTable = oVenta.ObtieneFacturasRelacionadas
                Dim FaltanUUIDRelacionados As Boolean = False

                If dtFacturasRelacionadas.Rows.Count = 0 Then
                    MsgBox("No se encontraron los cfdis relacionados(facturas) a la factura.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                For Each dRow As DataRow In dtFacturasRelacionadas.Rows
                    If txtLEN("" & dRow("FOLIO_FISCAL_SAT").ToString) = False Then
                        MsgBox("La factura " & dRow("FOLIO_VENTA").ToString & " no tiene UUID(posiblemente no esta timbrada).", vbExclamation, sProcedure)
                        FaltanUUIDRelacionados = True
                    End If

                    Cfd.CfdiRelacionados.Add(dRow("FOLIO_FISCAL_SAT").ToString) 'uuids
                Next

                'En caso de que alguna factura no este timbrada se aborta el proceso.
                If FaltanUUIDRelacionados = True Then
                    Return False
                End If
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Emisor''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With Cfd.Emisor
                .Rfc = fElectronicaValidaCampo(Empresa_Sistema.RFC)
                .Nombre = fElectronicaValidaCampo(Empresa_Sistema.NOMBRE_EMPRESA)
                .RegimenFiscal = fElectronicaValidaCampo(oVenta.CODIGO_REGIMEN_FISCAL.ToString)
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Receptor''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim oCliente As New Class_CatClientes(oVenta.CODIGO_CLIENTE.ToString)
            Dim sReceptorRFC As String, sReceptorNombre As String

            If oCliente.Existe = False Then
                MsgBox("Cliente no encontrado.", MsgBoxStyle.Exclamation, nombreModulo)
                Return False
            End If

            If oVenta.ES_VENTA_PUBLICO_GENERAL = "1" Then
                sReceptorNombre = "PUBLICO GENERAL"
                sReceptorRFC = Empresa_Sistema.RFC_VENTA_PUBLICO_GENERAL
            Else
                sReceptorNombre = fElectronicaValidaCampo(oCliente.NOMBRE_CLIENTE)
                sReceptorRFC = fElectronicaValidaCampo(Replace(oCliente.RFC, "-", ""))
            End If

            With Cfd.Receptor
                .Rfc = sReceptorRFC
                .Nombre = sReceptorNombre

                MsgBox("FALTA algo para llenar residencia fiscal y numregid cuando es factura de traslado con cce")

                If Empresa_Sistema.FELECTRONICA_CCE_HABILITADO = True And oVenta.ES_FACTURA_EMBARQUE_EXTRANJERO = True Then
                    .ResidenciaFiscal = oCliente.CODIGO_PAIS_SAT  'usarlo sólo cuando el rfc sea extranjero y haya cce o numregid
                    .NumRegIdTrib = oCliente.NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO
                End If

                .UsoCFDI = oVenta.CODIGO_USO_CFDI
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Conceptos'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim ConceptoImpuestoTraslados As New iConceptoImpuestoTraslados33
            Dim ConceptoImpuestoRetenciones As New iConceptoImpuestoRetenciones33

            Dim drImporte As Decimal, drPrecio As Decimal, drCantidad As Decimal, drDESCUENTO_IMPORTE As Decimal, drIMPUESTO_PORCENTAJE As Decimal
            Dim drBASE_IEPS As Decimal, drBASE_IVA As Decimal, drIMPUESTO_IMPORTE As Decimal, drIEPS_IMPORTE As Decimal, drIEPS_PORCENTAJE As Decimal
            'Dim drRetencionIVA As Decimal, drRetencionPorcentaje As Decimal

            Dim drRETENCION_IVA_PORCENTAJE As Decimal = 0, drRETENCION_IVA_BASE As Decimal = 0, drRETENCION_IVA_IMPORTE As Decimal = 0
            Dim drRETENCION_ISR_PORCENTAJE As Decimal = 0, drRETENCION_ISR_BASE As Decimal = 0, drRETENCION_ISR_IMPORTE As Decimal = 0

            For Each row As DataRow In oVenta.ObtenerDetalleParaCFDI(oVenta.FOLIO_VENTA).Rows
                drCantidad = CDec(row("CANTIDAD").ToString)

                If oVenta.CODIGO_TIPO_DOCUMENTO = "FT" Then 'Factura de traslado, omitimos los impuestos
                    GoTo ImpuestosConceptos
                End If

                drIMPUESTO_PORCENTAJE = CDec(row("IMPUESTO_PORCENTAJE").ToString) / CDec("100.00")
                drIEPS_PORCENTAJE = CDec(row("IEPS_PORCENTAJE").ToString) / CDec("100.00")
                'drRetencionPorcentaje = CDec(row("RETENCION_IVA_PORCENTAJE").ToString) / CDec("100.00")

                drRETENCION_IVA_PORCENTAJE = CDec(row("RETENCION_IVA_PORCENTAJE").ToString)
                drRETENCION_ISR_PORCENTAJE = CDec(row("RETENCION_ISR_PORCENTAJE").ToString)

                'Ver nota principal sobre embarques de extranjero
                'If oVenta.ES_FACTURA_EMBARQUE_EXTRANJERO = True Then
                '    drPrecio = CDec(row("PRECIO_USD").ToString)
                '    drImporte = CDec(row("IMPORTE_USD").ToString)
                '    drDESCUENTO_IMPORTE = CDec(row("IMPORTE_USD").ToString)
                'Else
                '    drPrecio = CDec(row("PRECIO_TOTAL").ToString)
                '    drImporte = CDec(row("IMPORTE").ToString)
                '    drDESCUENTO_IMPORTE = CDec(row("DESCUENTO_IMPORTE").ToString)

                '    If oVenta.CODIGO_MONEDA_SAT = "USD" Then
                '        drPrecio = RedondearD(drPrecio / dTIPO_DE_CAMBIO, 3)
                '        drImporte = RedondearD(drImporte / dTIPO_DE_CAMBIO, 2)
                '        drDESCUENTO_IMPORTE = RedondearD(drDESCUENTO_IMPORTE / dTIPO_DE_CAMBIO, 2)
                '    End If
                'End If

                If oVenta.CODIGO_MONEDA_SAT = "MXN" Then
                    drPrecio = CDec(row("PRECIO_TOTAL").ToString)
                    drImporte = CDec(row("IMPORTE").ToString)
                    drDESCUENTO_IMPORTE = CDec(row("DESCUENTO_IMPORTE").ToString)
                    drRETENCION_IVA_BASE = CDec(row("RETENCION_IVA_BASE").ToString)
                    drRETENCION_ISR_BASE = CDec(row("RETENCION_ISR_BASE").ToString)
                    drRETENCION_IVA_IMPORTE = CDec(row("RETENCION_IVA_IMPORTE").ToString)
                    drRETENCION_ISR_IMPORTE = CDec(row("RETENCION_ISR_IMPORTE").ToString)
                ElseIf oVenta.CODIGO_MONEDA_SAT = "USD" Then
                    drPrecio = CDec(row("PRECIO_TOTAL_USD").ToString)
                    drImporte = CDec(row("IMPORTE_USD").ToString)
                    drDESCUENTO_IMPORTE = CDec(row("DESCUENTO_IMPORTE_USD").ToString)
                    drRETENCION_IVA_BASE = CDec(row("RETENCION_IVA_BASE_USD").ToString)
                    drRETENCION_ISR_BASE = CDec(row("RETENCION_ISR_BASE_USD").ToString)
                    drRETENCION_IVA_IMPORTE = CDec(row("RETENCION_IVA_IMPORTE_USD").ToString)
                    drRETENCION_ISR_IMPORTE = CDec(row("RETENCION_ISR_IMPORTE_USD").ToString)
                End If

                '003=IEPS,002=IVA

                If oVenta.TIENE_IEPS_DESGLOSADO = True Then
                    If row("GRADO_TOXICIDAD").ToString <> "0" Then '0=no graba ieps, <>0 significa que si graba ieps : 1-4=con alguna tasa,5=Exento(aún siendo exento hay que llenar la base ieps)
                        'drBASE_IEPS = CDec(row("BASE_IEPS").ToString)
                        'drIEPS_IMPORTE = CDec(row("IEPS_IMPORTE").ToString)

                        'If oVenta.CODIGO_MONEDA_SAT = "USD" Then
                        '    drBASE_IEPS = RedondearD(drBASE_IEPS / dTIPO_DE_CAMBIO, 2)
                        '    drIEPS_IMPORTE = RedondearD(drIEPS_IMPORTE / dTIPO_DE_CAMBIO, 2)
                        'End If

                        If oVenta.CODIGO_MONEDA_SAT = "MXN" Then
                            drBASE_IEPS = CDec(row("BASE_IEPS").ToString)
                            drIEPS_IMPORTE = CDec(row("IEPS_IMPORTE").ToString)
                        ElseIf oVenta.CODIGO_MONEDA_SAT = "USD" Then
                            drBASE_IEPS = CDec(row("BASE_IEPS_USD").ToString)
                            drIEPS_IMPORTE = CDec(row("IEPS_IMPORTE_USD").ToString)
                        End If

                        If row("GRADO_TOXICIDAD").ToString = "5" Then '5=Ieps Exento
                            'ConceptoImpuestoTraslados.Add(Format(drBASE_IEPS, "##0.00"), "003", "Exento", "", "")
                            ConceptoImpuestoTraslados.Add(Format(drBASE_IEPS, "##0.000000"), "003", "Exento", "", "")
                        Else
                            'ConceptoImpuestoTraslados.Add(Format(drBASE_IEPS, "##0.00"), "003", "Tasa", Format(drIEPS_PORCENTAJE, "0.#00000"), Format(drIEPS_IMPORTE, "##0.00"))
                            ConceptoImpuestoTraslados.Add(Format(drBASE_IEPS, "##0.000000"), "003", "Tasa", Format(drIEPS_PORCENTAJE, "0.#00000"), Format(drIEPS_IMPORTE, "##0.00"))
                        End If
                    End If
                End If

                If row("ID_SIS_CAT_IMPUESTOS").ToString <> "N" Then 'N=No grava iva, si es <>N = Si grava iva ya sea al 0,16,Exento(aún siendo exento ó 0 hay que llenar la base iva)
                    'drBASE_IVA = CDec(row("BASE_IVA").ToString)
                    'drIMPUESTO_IMPORTE = CDec(row("IMPUESTO_IMPORTE").ToString)
                    'drRetencionIVA = CDec(row("RETENCION_IVA_IMPORTE").ToString)

                    'If oVenta.CODIGO_MONEDA_SAT = "USD" Then
                    '    drBASE_IVA = RedondearD(drBASE_IVA / dTIPO_DE_CAMBIO, 2)
                    '    drIMPUESTO_IMPORTE = RedondearD(drIMPUESTO_IMPORTE / dTIPO_DE_CAMBIO, 2)
                    '    drRetencionIVA = RedondearD(drRetencionIVA / dTIPO_DE_CAMBIO, 2)
                    'End If

                    If oVenta.CODIGO_MONEDA_SAT = "MXN" Then
                        drBASE_IVA = CDec(row("BASE_IVA").ToString)
                        drIMPUESTO_IMPORTE = CDec(row("IMPUESTO_IMPORTE").ToString)
                        'drRetencionIVA = CDec(row("RETENCION_IVA_IMPORTE").ToString)
                    ElseIf oVenta.CODIGO_MONEDA_SAT = "USD" Then
                        drBASE_IVA = CDec(row("BASE_IVA_USD").ToString)
                        drIMPUESTO_IMPORTE = CDec(row("IMPUESTO_IMPORTE_USD").ToString)
                        'drRetencionIVA = CDec(row("RETENCION_IVA_IMPORTE_USD").ToString)
                    End If

                    If row("ID_SIS_CAT_IMPUESTOS").ToString = "E" Then 'E=Iva Exento
                        'ConceptoImpuestoTraslados.Add(Format(drBASE_IVA, "##0.00"), "002", "Exento", "", "")
                        ConceptoImpuestoTraslados.Add(Format(drBASE_IVA, "##0.000000"), "002", "Exento", "", "")
                    Else
                        'ConceptoImpuestoTraslados.Add(Format(drBASE_IVA, "##0.00"), "002", "Tasa", Format(drIMPUESTO_PORCENTAJE, "0.#00000"), Format(drIMPUESTO_IMPORTE, "##0.00"))
                        ConceptoImpuestoTraslados.Add(Format(drBASE_IVA, "##0.000000"), "002", "Tasa", Format(drIMPUESTO_PORCENTAJE, "0.#00000"), Format(drIMPUESTO_IMPORTE, "##0.00"))

                        'If row("ID_SIS_CAT_IMPUESTOS_FLETE").ToString <> "0" Then
                        '    ConceptoImpuestoRetenciones.Add(Format(drBASE_IVA, "##0.000000"), "002", "Tasa", Format(drRetencionPorcentaje, "0.#00000"), Format(drRetencionIVA, "##0.00"))
                        'End If
                    End If

                End If

                If drRETENCION_IVA_IMPORTE > 0 Then
                    ConceptoImpuestoRetenciones.Add(Format(drRETENCION_IVA_BASE, "##0.00"), "002", "Tasa", Format(drRETENCION_IVA_PORCENTAJE, "0.#00000"), Format(drRETENCION_IVA_IMPORTE, "##0.00")) '002=IVA
                End If

                If drRETENCION_ISR_IMPORTE > 0 Then
                    ConceptoImpuestoRetenciones.Add(Format(drRETENCION_ISR_BASE, "##0.00"), "001", "Tasa", Format(drRETENCION_ISR_PORCENTAJE, "0.#00000"), Format(drRETENCION_ISR_IMPORTE, "##0.00")) '001=ISR
                End If

                'If oVenta.IEPS_TOTAL_DESGLOSADO > 0 Then 'Solamente si se le desglosan los ieps se mencionan, si es incluido no(como si no tuviera), por eso se pregunta por el total y no del renglón porque al ser inc si va tener ieps pero no es parte del xml
                '    If CDec(row("IEPS_PORCENTAJE").ToString) > 0 Then 'Este viene como 6,7,9
                '        drBASE_IEPS = CDec(row("BASE_IEPS").ToString)
                '        drIEPS_IMPORTE = CDec(row("IEPS_IMPORTE").ToString)

                '        If oVenta.CODIGO_MONEDA_SAT = "USD" Then
                '            drBASE_IEPS = RedondearD(drBASE_IEPS / dTIPO_DE_CAMBIO, 2)
                '            drIEPS_IMPORTE = RedondearD(drIEPS_IMPORTE / dTIPO_DE_CAMBIO, 2)
                '        End If

                '        ConceptoImpuestoTraslados.Add(Format(drBASE_IEPS, "##0.00"), "003", "Tasa", Format(drIEPS_PORCENTAJE, "0.#00000"), Format(drIEPS_IMPORTE, "##0.00"))
                '    End If
                'End If

                'If drIMPUESTO_PORCENTAJE > 0 Then
                '    drBASE_IVA = CDec(row("BASE_IVA").ToString)
                '    drIMPUESTO_IMPORTE = CDec(row("IMPUESTO_IMPORTE").ToString)

                '    If oVenta.CODIGO_MONEDA_SAT = "USD" Then
                '        drBASE_IVA = RedondearD(drBASE_IVA / dTIPO_DE_CAMBIO, 2)
                '        drIMPUESTO_IMPORTE = RedondearD(drIMPUESTO_IMPORTE / dTIPO_DE_CAMBIO, 2)
                '    End If

                '    ConceptoImpuestoTraslados.Add(Format(drBASE_IVA, "##0.00"), "002", "Tasa", Format(drIMPUESTO_PORCENTAJE, "0.#00000"), Format(drIMPUESTO_IMPORTE, "##0.00"))
                'End If

ImpuestosConceptos:
                'Format(drPrecio, "##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO))
                Cfd.Conceptos.Add(row("CODIGO_PRODUCTO_SERVICIO").ToString, row("CODIGO_ARTICULO").ToString,
                                  Format(drCantidad, "##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CANTIDAD)),
                                  row("CODIGO_UNIDAD").ToString, row("UNIDAD_VENTA").ToString, fElectronicaValidaCampo(row("DESCRIPCION").ToString),
                                  Format(drPrecio, "##0." & StrDup(6, "0")),
                                  Format(drImporte, "##0.00"),
                                  IIf(drDESCUENTO_IMPORTE > 0, Format(drDESCUENTO_IMPORTE, "##0.00"), "").ToString, ConceptoImpuestoTraslados, ConceptoImpuestoRetenciones)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Impuestos'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim arr() As iImpuestosTraslado33, dImpuestoIEPSImporte As Decimal, dImpuestoIVAImporte As Decimal, iEncontrados As Integer = 0
            Dim arr2() As iImpuestosRetencion33, dRetencionIvaImporte As Decimal

            ''IEPS, deben acumularse, puede ser que mas de un artículo tenga el mismo % de ieps, de modo que aquí se juntan en uno sólo.
            iEncontrados = 0
            arr = ImpuestosTrasladoAgrupados(Cfd, "003", iEncontrados)

            If iEncontrados > 0 Then
                For i = 1 To UBound(arr)
                    dImpuestoIEPSImporte = CDec(arr(i).Importe)

                    'Nota, no es necesario preguntar si es en USD y dividir por el tipo de cambio porque este valor se llena con el desglose x concepto el cual ya esta en USD

                    Cfd.Impuestos.Traslados.Add(arr(i).Impuesto, arr(i).TipoFactor, arr(i).TasaOCuota, Format(dImpuestoIEPSImporte, "#0.00")) 'arr(i).TasaOCuota ya esta formateado
                Next
            End If

            ''IVA
            iEncontrados = 0
            arr = ImpuestosTrasladoAgrupados(Cfd, "002", iEncontrados) 'comprobar aqui que agrupe 0 y 16 pero no exentos."

            If iEncontrados > 0 Then
                For i = 1 To UBound(arr)
                    dImpuestoIVAImporte = CDec(arr(i).Importe)

                    Cfd.Impuestos.Traslados.Add(arr(i).Impuesto, arr(i).TipoFactor, arr(i).TasaOCuota, Format(dImpuestoIVAImporte, "#0.00")) 'arr(i).TasaOCuota ya esta formateado
                Next
            End If

            ''RETENCION IVA
            iEncontrados = 0
            arr2 = ImpuestosRetenidosAgrupados(Cfd, iEncontrados)

            If iEncontrados > 0 Then
                For i = 1 To UBound(arr2)
                    dRetencionIvaImporte = CDec(arr2(i).Importe)
                    Cfd.Impuestos.Retenciones.Add(arr2(i).Impuesto, Format(dRetencionIvaImporte, "#0.00"))
                Next
            End If

            ''IEPS, deben acumularse, puede ser que mas de un artículo tenga el mismo % de ieps, de modo que aquí se juntan en uno sólo.
            'If oVenta.IEPS_TOTAL_DESGLOSADO > 0 Then 'Solamente si se le desglosan los ieps se mencionan, si es incluido no(como si no tuviera), por eso se pregunta por el total y no del renglón porque al ser inc si va tener ieps pero no es parte del xml
            '    arr = ImpuestosTrasladoAgrupados(Cfd)

            '    For i = 1 To UBound(arr)
            '        dImpuestoIEPSImporte = CDec(arr(i).Importe)

            '        'Nota, no es necesario preguntar si es en USD y dividir por el tipo de cambio porque este valor se llena con el desglose x concepto el cual ya esta en USD

            '        Cfd.Impuestos.Traslados.Add(arr(i).Impuesto, arr(i).TipoFactor, arr(i).TasaOCuota, Format(dImpuestoIEPSImporte, "#0.00")) 'arr(i).TasaOCuota ya esta formateado
            '    Next
            'End If

            ''IVA
            ''Nota el total de iva ya esta acumulado y es un sólo tipo de iva por se obtiene directamente del documento(a diferencia del ieps)
            'If oVenta.IMPUESTO > 0 Then
            '    'rsDocumento!IMPUESTO_PORCENTAJE viene como 16, se ocupa dividir

            '    dImpuestoIVAImporte = CDec(oVenta.IMPUESTO)

            '    If oVenta.CODIGO_MONEDA_SAT = "USD" Then
            '        dImpuestoIVAImporte = RedondearD(dImpuestoIVAImporte / dTIPO_DE_CAMBIO, 2)
            '    End If

            '    Cfd.Impuestos.Traslados.Add("002", "Tasa", Format(oVenta.IMPUESTO_PORCENTAJE / CDec("100.00"), "0.#00000"), Format(dImpuestoIVAImporte, "#0.00"))
            'End If


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''CCE COMPLEMENTO COMERCIO EXTERIOR''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim sXmlComercioExterior As String = ""

            If Empresa_Sistema.FELECTRONICA_CCE_HABILITADO = True And oVenta.ES_FACTURA_EMBARQUE_EXTRANJERO = True Then
                sXmlComercioExterior = oVenta.GeneraXmlComercioExterior11(TipoCCE.Agricola)

                If txtLEN(sXmlComercioExterior) = False Then
                    Return False 'Abortamos
                End If

                Cfd.XmlComplementoComercioExterior = sXmlComercioExterior
            ElseIf oVenta.CODIGO_TIPO_DOCUMENTO = "FT" And oVenta.TIENE_COMPLEMENTO_COMERCIO_EXTERIOR = True Then
                sXmlComercioExterior = oVenta.GeneraXmlComercioExterior11(TipoCCE.Acuicola)

                If txtLEN(sXmlComercioExterior) = False Then
                    Return False 'Abortamos
                End If

                Cfd.XmlComplementoComercioExterior = sXmlComercioExterior
            End If

            'If oVenta.CODIGO_TIPO_DOCUMENTO = "FT" Then 'Factura de traslado, omitimos los impuestos
            If oVenta.TIENE_COMPLEMENTO_CARTA_PORTE = True Then
                Cfd.ComplementoCartaPorte20 = oVenta.CargaValoresComplementoCartaPorte20 'No genera el complemento, sólo carga los valores
                If Cfd.ComplementoCartaPorte20.ValoresComplementoCargados = False Then
                    Return False 'Abortamos
                End If
            End If

            'Fin de llenado de nodos del comprobante''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Cfd.GeneraCFD(TipoComprobante.FACTURA_VENTA, sRutaXML) = True Then
                bResultado = True
                If bMostrarMensaje = True Then
                    MsgBox("Factura timbrada satisfactoriamente.", vbInformation, sProcedure)
                End If
            End If

        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try

        Return bResultado
    End Function
End Module

