Option Strict On

Module FacturacionElectronica33
    Private Const nombreModulo As String = "FacturacionElectronica33"

    Public dtUsosCFDIPersonasFisicas As DataTable
    Public dtUsosCFDIPersonasMorales As DataTable

    Public dtFormasPagoTodas As DataTable
    Public dtFormasPagoActivas As DataTable

    Public dtMetodosPago As DataTable

    Private tPlazaFacturaElectronica As Class_SisPlazas

    Private Function ValidaDatosGenerales(ByVal dFecha As Date, ByVal sCER As String, ByVal sKEY As String, ByVal sPassCER As String) As Boolean
        Const sProcedure As String = "ValidaDatosGenerales"
        Dim bResultado As Boolean = False

        Try
            Dim dFechaServidor As Date = Empresa_Sistema.FechaActualServidor

            Dim sqlResult As New Class_find("SELECT E.VERSION,S.VERSION_CFDI_DLL FROM VERSION_ESQUEMA_CFD E,SIS_EMPRESA S WHERE '" & Format(dFecha, "yyyy-dd-MM hh:mm") & "'  BETWEEN E.FECHA_INICIAL AND E.FECHA_FINAL")

            'Nota1, no la copia en automático, porque ya lo debió haber hecho el gestionaArchivosCertificados
            'Nota2, se valida la versión que tenga el servidor en el instante por si tenemos fallo en la dll y se pare el timbrado.
            If sqlResult.Result2 <> VersionArchivo(sFelectronicaDLLCFDILocal).ToString Then
                MsgBox("La versión del archivo cfdi.dll(v " & VersionArchivo(sFelectronicaDLLCFDILocal) & ") es diferente del servidor(v " & Empresa_Sistema.VERSION_CFDI_DLL & "). " & vbCrLf &
                "No se podrán generar facturas electrónicas en este equipo. Avíse al depto. de sistemas.", vbExclamation, sProcedure)
                Return False
            End If

            If sqlResult.Result1 <> Empresa_Sistema.VERSION_ESQUEMA_CFD Then
                MsgBox("El esquema de documento es diferente al actual.", vbExclamation, sProcedure)
                Return False
            End If

            If CDate(Format(dFecha, "dd/MM/yyyy hh:mm:ss")) < dFechaServidor.AddDays(-3) Then
                MsgBox("La fecha del documento es mayor de 72 horas de la fecha actual, el SAT no permite timbrar con fecha de más de 3 días.", vbExclamation, sProcedure)
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
                dSubTotal = CDec(oVenta.TOTAL_DOLARES)
                dDescuento = CDec(oVenta.DESCUENTO_USD)
                dTotal = 0
            Else
                dSubTotal = CDec(oVenta.SUBTOTAL)
                dDescuento = CDec(oVenta.DESCUENTO)
                dTotal = CDec(oVenta.TOTAL)

                If oVenta.CODIGO_MONEDA_SAT = "USD" Then
                    dSubTotal = RedondearD(dSubTotal / dTIPO_DE_CAMBIO, 2)
                    dDescuento = RedondearD(dDescuento / dTIPO_DE_CAMBIO, 2)
                    dTotal = RedondearD(dTotal / dTIPO_DE_CAMBIO, 2)
                End If
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
                    .TipoCambio = FormatTipoCambio(oVenta.TIPO_DE_CAMBIO)
                End If
                .TipoDeComprobante = "I" 'Ingreso
                .MetodoPago = oVenta.CODIGO_METODO_PAGO_EVENTO
                .LugarExpedicion = tPlazaFacturaElectronica.CODIGO_POSTAL
                .Confirmacion = ""
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''CfdiRelacionados''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Cfd.CfdiRelacionados.TipoRelacion = "01"
            'Cfd.CfdiRelacionados.Add ("F664C038-474C-414E-B40D-2E8C4A3EFCAC")

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
            'Dim ConceptoImpuestoRetenciones As iConceptoImpuestoRetenciones33

            Dim drImporte As Decimal, drPrecio As Decimal, drCantidad As Decimal, drDESCUENTO_IMPORTE As Decimal, drIMPUESTO_PORCENTAJE As Decimal
            Dim drBASE_IEPS As Decimal, drBASE_IVA As Decimal, drIMPUESTO_IMPORTE As Decimal, drIEPS_IMPORTE As Decimal, drIEPS_PORCENTAJE As Decimal

            For Each row As DataRow In oVenta.ObtenerDetalleParaCFDI.Rows
                drCantidad = CDec(row("CANTIDAD").ToString)
                drIMPUESTO_PORCENTAJE = CDec(row("IMPUESTO_PORCENTAJE").ToString) / CDec("100.00")
                drIEPS_PORCENTAJE = CDec(row("IEPS_PORCENTAJE").ToString) / CDec("100.00")
                If oVenta.ES_FACTURA_EMBARQUE_EXTRANJERO = True Then
                    drPrecio = CDec(row("PRECIO_USD").ToString)
                    drImporte = CDec(row("IMPORTE_USD").ToString)
                    drDESCUENTO_IMPORTE = CDec(row("IMPORTE_USD").ToString)
                Else
                    drPrecio = CDec(row("PRECIO_TOTAL").ToString)
                    drImporte = CDec(row("IMPORTE").ToString)
                    drDESCUENTO_IMPORTE = CDec("0.00")

                    If oVenta.CODIGO_MONEDA_SAT = "USD" Then
                        drPrecio = RedondearD(drPrecio / dTIPO_DE_CAMBIO, 3)
                        drImporte = RedondearD(drImporte / dTIPO_DE_CAMBIO, 2)
                        drDESCUENTO_IMPORTE = RedondearD(drDESCUENTO_IMPORTE / dTIPO_DE_CAMBIO, 2)
                    End If
                End If

                ConceptoImpuestoTraslados = New iConceptoImpuestoTraslados33

                '003=IEPS,002=IVA

                If oVenta.IEPS_TOTAL_DESGLOSADO > 0 Then 'Solamente si se le desglosan los ieps se mencionan, si es incluido no(como si no tuviera), por eso se pregunta por el total y no del renglón porque al ser inc si va tener ieps pero no es parte del xml
                    If CDec(row("IEPS_PORCENTAJE").ToString) > 0 Then 'Este viene como 6,7,9
                        drBASE_IEPS = CDec(row("BASE_IEPS").ToString)
                        drIEPS_IMPORTE = CDec(row("IEPS_IMPORTE").ToString)

                        If oVenta.CODIGO_MONEDA_SAT = "USD" Then
                            drBASE_IEPS = RedondearD(drBASE_IEPS / dTIPO_DE_CAMBIO, 2)
                            drIEPS_IMPORTE = RedondearD(drIEPS_IMPORTE / dTIPO_DE_CAMBIO, 2)
                        End If

                        ConceptoImpuestoTraslados.Add(Format(drBASE_IEPS, "##0.00"), "003", "Tasa", Format(drIEPS_PORCENTAJE, "0.#00000"), Format(drIEPS_IMPORTE, "##0.00"))
                    End If
                End If

                If drIMPUESTO_PORCENTAJE > 0 Then
                    drBASE_IVA = CDec(row("BASE_IVA").ToString)
                    drIMPUESTO_IMPORTE = CDec(row("IMPUESTO_IMPORTE").ToString)

                    If oVenta.CODIGO_MONEDA_SAT = "USD" Then
                        drBASE_IVA = RedondearD(drBASE_IVA / dTIPO_DE_CAMBIO, 2)
                        drIMPUESTO_IMPORTE = RedondearD(drIMPUESTO_IMPORTE / dTIPO_DE_CAMBIO, 2)
                    End If

                    ConceptoImpuestoTraslados.Add(Format(drBASE_IVA, "##0.00"), "002", "Tasa", Format(drIMPUESTO_PORCENTAJE, "0.#00000"), Format(drIMPUESTO_IMPORTE, "##0.00"))
                End If

                Cfd.Conceptos.Add(row("CODIGO_PRODUCTO_SERVICIO").ToString, row("CODIGO_ARTICULO").ToString,
                                  Format(drCantidad, "##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CANTIDAD)),
                                  row("CODIGO_UNIDAD").ToString, row("UNIDAD_VENTA").ToString, fElectronicaValidaCampo(row("DESCRIPCION").ToString),
                                  Format(drPrecio, "##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)),
                                  Format(drImporte, "##0.00"),
                                  IIf(drDESCUENTO_IMPORTE > 0, Format(drDESCUENTO_IMPORTE, "##0.00"), "").ToString, ConceptoImpuestoTraslados,)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Impuestos'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim arr() As iImpuestosTraslado33, dImpuestoIEPSImporte As Decimal, dImpuestoIVAImporte As Decimal

            ''IEPS, deben acumularse, puede ser que mas de un artículo tenga el mismo % de ieps, de modo que aquí se juntan en uno sólo.
            If oVenta.IEPS_TOTAL_DESGLOSADO > 0 Then 'Solamente si se le desglosan los ieps se mencionan, si es incluido no(como si no tuviera), por eso se pregunta por el total y no del renglón porque al ser inc si va tener ieps pero no es parte del xml
                arr = ImpuestosTrasladoAgrupados(Cfd)

                For i = 1 To UBound(arr)
                    dImpuestoIEPSImporte = CDec(arr(i).Importe)

                    'Nota, no es necesario preguntar si es en USD y dividir por el tipo de cambio porque este valor se llena con el desglose x concepto el cual ya esta en USD

                    Cfd.Impuestos.Traslados.Add(arr(i).Impuesto, arr(i).TipoFactor, arr(i).TasaOCuota, Format(dImpuestoIEPSImporte, "#0.00")) 'arr(i).TasaOCuota ya esta formateado
                Next
            End If

            ''IVA
            'Nota el total de iva ya esta acumulado y es un sólo tipo de iva por se obtiene directamente del documento(a diferencia del ieps)
            If oVenta.IMPUESTO > 0 Then
                'rsDocumento!IMPUESTO_PORCENTAJE viene como 16, se ocupa dividir

                dImpuestoIVAImporte = CDec(oVenta.IMPUESTO)

                If oVenta.CODIGO_MONEDA_SAT = "USD" Then
                    dImpuestoIVAImporte = RedondearD(dImpuestoIVAImporte / dTIPO_DE_CAMBIO, 2)
                End If

                Cfd.Impuestos.Traslados.Add("002", "Tasa", Format(oVenta.IMPUESTO_PORCENTAJE / CDec("100.00"), "0.#00000"), Format(dImpuestoIVAImporte, "#0.00"))
            End If


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''CCE COMPLEMENTO COMERCIO EXTERIOR''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim sXmlComercioExterior As String = ""

            If Empresa_Sistema.FELECTRONICA_CCE_HABILITADO = True And oVenta.ES_FACTURA_EMBARQUE_EXTRANJERO = True Then
                sXmlComercioExterior = oVenta.GeneraXmlComercioExterior11

                If txtLEN(sXmlComercioExterior) = False Then
                    Return False 'Abortamos
                End If

                Cfd.XmlComplementoComercioExterior = sXmlComercioExterior
            End If

            'Fin de llenado de nodos del comprobante''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Cfd.GeneraCFD(TipoComprobante.FACTURA_VENTA, sRutaXML) = True Then
                bResultado = True
                If bMostrarMensaje = True Then
                    MsgBox("Factura sellada satisfactoriamente.", vbInformation, sProcedure)
                End If
            End If

        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ImpuestosTrasladoAgrupados(ByVal Cfd As cComprobante33) As iImpuestosTraslado33()
        Const sProcedure As String = "ImpuestosTrasladoAgrupados"
        Dim arr() As iImpuestosTraslado33

        Try

            Dim i As Integer, j As Integer, c As Collection, X As Integer
            Dim arrCount As Integer, bEncontrado As Boolean

            c = New Collection

            ''IEPS, deben acumularse, puede ser que mas de un artículo tenga el mismo % de ieps, de modo que aquí se juntan en uno sólo.

            For i = 1 To Cfd.Conceptos.Count
                For j = 1 To Cfd.Conceptos.Item(i).Traslados.Count
                    If Cfd.Conceptos.Item(i).Traslados.Item(j).Impuesto = "003" Then '003=ieps
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

        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try

        Return arr
    End Function

    Public Function FormatTipoCambio(ByVal dTipoCambio As Double, Optional ByVal bConSignoMoneda As Boolean = True) As String
        Const sProcedure As String = "FormatTipoCambio"
        Dim sResultado As String = ""
        Try
            If bConSignoMoneda = True Then
                sResultado = Format(dTipoCambio, "$ ##0." & CerosEnCadena(4))
            Else
                sResultado = Format(dTipoCambio, "##0." & CerosEnCadena(4))
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

            If ValidaDatosGenerales(oPago.FECHA_PAGO, oPago.FELECTRONICA_CER, oPago.FELECTRONICA_KEY, oPago.FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA) = False Then
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

            'Nota en el comprobante va la fecha del depósito.
            ComprobanteFecha = Format(oBanco.FECHA, "yyyy-MM-dd") & "T" & Format(oBanco.FECHA_SERVIDOR, "hh:mm:ss")
            PagoFechaPago = Format(oPago.FECHA_PAGO, "yyyy-MM-dd") & "T" & Format(oPago.FECHA_PAGO, "hh:mm:ss")

            'No funcionó poder las 12 por ser antes que la fecha del comprobante(si es que es del mismo dia), ya la propia fecha_pago tiene la hora grabada necesaria
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
                    .TipoCambioP = FormatTipoCambio(oBanco.TIPO_DE_CAMBIO)
                End If

                .Monto = Format(oBancoDetalle.MONTO, "#0.00")
                .NumOperacion = oBancoDetalle.FOLIO_DETALLE
                .RfcEmisorCtaOrd = ""
                .NomBancoOrdExt = ""
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

                    .DoctoRelacionados.Add(oPagoDetalle.FACTURA_FOLIO_FISCAL_SAT, oPagoDetalle.FACTURA_SERIE, oPagoDetalle.FACTURA_FOLIO_NUMERICO,
                                           oPagoDetalle.CODIGO_MONEDA_SAT_DR,
                                           IIf(oPagoDetalle.CODIGO_MONEDA_SAT_DR <> complementoPagos.MonedaP, FormatTipoCambio(oPagoDetalle.TIPO_CAMBIO_DR), "").ToString,
                                           oPagoDetalle.CODIGO_METODO_PAGO_EVENTO_DR, oPagoDetalle.NUMERO_PARCIALIDAD,
                                           Format(oPagoDetalle.IMPORTE_SALDO_ANTERIOR, "#0.00"), Format(oPagoDetalle.IMPORTE_PAGADO, "#0.00"), Format(oPagoDetalle.IMPORTE_SALDO_INSOLUTO, "#0.00"))
                Next

            End With

            Cfd.ComplementoPagos10 = complementoPagos

            'Fin de llenado de nodos del comprobante''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Cfd.GeneraCFD(TipoComprobante.PAGO_CXC, sRutaXML) = True Then
                bResultado = True
                If bMostrarMensaje = True Then
                    MsgBox("Pago sellado satisfactoriamente.", vbInformation, sProcedure)
                End If
            End If

            oBanco = Nothing
            oBancoDetalle = Nothing

        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try

        Return bResultado
    End Function

End Module

