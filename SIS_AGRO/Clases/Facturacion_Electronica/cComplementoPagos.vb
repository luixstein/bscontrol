Option Explicit On

Friend Class cComplementoPagos

    Private Const NombreClase As String = "cComplementoPagos"

    Private xmlns As String
    Private xmlnspago10 As String
    Private xsischemaLocation As String
    Private AnexoNodo As String

    Public CfdComprobanteLectura As cComprobante33 'Se necesita para validar algunos datos del comprobante en este complemento

    Public Version As String
    Public FechaPago As String
    Public FormaDePagoP As String
    Public MonedaP As String
    Public TipoCambioP As String
    Public Monto As String
    Public NumOperacion As String
    Public RfcEmisorCtaOrd As String
    Public NomBancoOrdExt As String
    Public CtaOrdenante As String
    Public RfcEmisorCtaBen As String
    Public CtaBeneficiario As String
    Public TipoCadPago As String
    Public CertPago As String
    Public CadPago As String
    Public SelloPago As String

    Public DoctoRelacionados As cPagosDoctoRelacionados

    Public Impuestos As iImpuestos33

    Public ComplementoGenerado As Boolean

    Private _Complemento As MSXML2.IXMLDOMElement

    Public ReadOnly Property Complemento As MSXML2.IXMLDOMElement
        Get
            Return Me._Complemento
        End Get
    End Property

    Private Sub Class_Initialize_Renamed()
        Const sProcedure As String = "New"
        Try
            AnexoNodo = "pago10:"

            xmlns = "http://www.sat.gob.mx/Pagos"
            xmlnspago10 = "http://www.sat.gob.mx/Pagos"
            xsischemaLocation = "http://www.sat.gob.mx/Pagos http://www.sat.gob.mx/sitio_internet/cfd/Pagos/Pagos10.xsd"

            DoctoRelacionados = New cPagosDoctoRelacionados
            Impuestos = New iImpuestos33

            ComplementoGenerado = False

        Catch ex As Exception
            HandleError(NombreClase, sProcedure, ex)
        End Try
    End Sub

    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub

    Public Function GenerarNodoComplementoPagos() As Boolean
        Const sProcedure As String = "GenerarNodoComplementoPagos"
        Dim bResultado As Boolean = False
        Dim mResultado As MSXML2.IXMLDOMElement

        Try
            Dim xmlDoc As New MSXML2.DOMDocument60

            xmlDoc.async = False
            xmlDoc.validateOnParse = False
            xmlDoc.resolveExternals = False
            xmlDoc.preserveWhiteSpace = True

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim NodoPagos As MSXML2.IXMLDOMElement
            NodoPagos = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Pagos", xmlns)

            With NodoPagos
                .setAttribute("xsi:schemaLocation", xsischemaLocation)
                '.setAttribute ("xmlns:pago10", xmlnspago10 'Da lo mismo ponerlo o no, si se omite lo pone automáticamente al hacer Set NodoPagos =

                If txtLEN(Me.Version) = False Then
                    MsgBox("El valor de Version es un dato requerido.", vbExclamation, sProcedure) : Return False
                Else
                    .setAttribute("Version", Me.Version) 'required
                End If
            End With
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim NodoPago As MSXML2.IXMLDOMElement
            NodoPago = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Pago", xmlns)

            With NodoPago
                If txtLEN(Me.FechaPago) = False Then
                    MsgBox("El valor de FechaPago es un dato requerido.", vbExclamation, sProcedure) : Return False
                Else
                    .setAttribute("FechaPago", Me.FechaPago) 'required
                End If

                If txtLEN(Me.FormaDePagoP) = False Then
                    MsgBox("El valor de FormaDePagoP es un dato requerido.", vbExclamation, sProcedure) : Return False
                Else
                    .setAttribute("FormaDePagoP", Me.FormaDePagoP) 'required
                End If

                If txtLEN(Me.MonedaP) = False Then
                    MsgBox("El valor de MonedaP es un dato requerido.", vbExclamation, sProcedure) : Return False
                Else
                    .setAttribute("MonedaP", Me.MonedaP) 'required
                End If

                If txtLEN(Me.TipoCambioP) = True Then
                    .setAttribute("TipoCambioP", Me.TipoCambioP) 'optional
                End If

                If txtLEN(Me.Monto) = False Then
                    MsgBox("El valor de Monto es un dato requerido.", vbExclamation, sProcedure) : Return False
                Else
                    .setAttribute("Monto", Me.Monto) 'required
                End If

                If txtLEN(Me.NumOperacion) = True Then
                    .setAttribute("NumOperacion", Me.NumOperacion) 'optional
                End If

                If txtLEN(Me.RfcEmisorCtaOrd) = True Then
                    .setAttribute("RfcEmisorCtaOrd", Me.RfcEmisorCtaOrd) 'optional
                End If

                If txtLEN(Me.NomBancoOrdExt) = True Then
                    .setAttribute("NomBancoOrdExt", Me.NomBancoOrdExt) 'optional
                End If

                If txtLEN(Me.CtaOrdenante) = True Then
                    .setAttribute("CtaOrdenante", Me.CtaOrdenante) 'optional
                End If

                If txtLEN(Me.RfcEmisorCtaBen) = True Then
                    .setAttribute("RfcEmisorCtaBen", Me.RfcEmisorCtaBen) 'optional
                End If

                If txtLEN(Me.CtaBeneficiario) = True Then
                    .setAttribute("CtaBeneficiario", Me.CtaBeneficiario) 'optional
                End If

                If txtLEN(Me.TipoCadPago) = True Then
                    .setAttribute("TipoCadPago", Me.TipoCadPago) 'optional
                End If

                If txtLEN(Me.CertPago) = True Then
                    .setAttribute("CertPago", Me.CertPago) 'optional
                End If

                If txtLEN(Me.CadPago) = True Then
                    .setAttribute("CadPago", Me.CadPago) 'optional
                End If

                If txtLEN(Me.SelloPago) = True Then
                    .setAttribute("SelloPago", Me.SelloPago) 'optional
                End If
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Este nodo no forma parte de una colección como lo son los conceptos, se insertan directamente en el nodo de Pago
            Dim NodoDoctoRelacionado As MSXML2.IXMLDOMElement

            Dim i As Integer
            For i = 1 To CInt(Me.DoctoRelacionados.Count)
                NodoDoctoRelacionado = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "DoctoRelacionado", xmlns)

                With NodoDoctoRelacionado
                    If txtLEN(Me.DoctoRelacionados.Item(i).IdDocumento) = True Then
                        .setAttribute("IdDocumento", Me.DoctoRelacionados.Item(i).IdDocumento)
                    Else
                        MsgBox("El valor de DoctoRelacionados.IdDocumento es un dato requerido.", vbExclamation, sProcedure)
                        Return False
                    End If

                    If txtLEN(Me.DoctoRelacionados.Item(i).Serie) = True Then
                        .setAttribute("Serie", Me.DoctoRelacionados.Item(i).Serie)
                    End If

                    If txtLEN(Me.DoctoRelacionados.Item(i).Folio) = True Then
                        .setAttribute("Folio", Me.DoctoRelacionados.Item(i).Folio)
                    End If

                    If txtLEN(Me.DoctoRelacionados.Item(i).MonedaDR) = True Then
                        .setAttribute("MonedaDR", Me.DoctoRelacionados.Item(i).MonedaDR)
                    Else
                        MsgBox("El valor de DoctoRelacionados.MonedaDR es un dato requerido.", vbExclamation, sProcedure)
                        Return False
                    End If

                    If txtLEN(Me.DoctoRelacionados.Item(i).TipoCambioDR) = True Then
                        .setAttribute("TipoCambioDR", Me.DoctoRelacionados.Item(i).TipoCambioDR)
                    End If

                    If txtLEN(Me.DoctoRelacionados.Item(i).MetodoDePagoDR) = True Then
                        .setAttribute("MetodoDePagoDR", Me.DoctoRelacionados.Item(i).MetodoDePagoDR)
                    Else
                        MsgBox("El valor de DoctoRelacionados.MetodoDePagoDR es un dato requerido.", vbExclamation, sProcedure)
                        Return False
                    End If

                    If txtLEN(Me.DoctoRelacionados.Item(i).NumParcialidad) = True Then
                        .setAttribute("NumParcialidad", Me.DoctoRelacionados.Item(i).NumParcialidad)
                    End If

                    If txtLEN(Me.DoctoRelacionados.Item(i).ImpSaldoAnt) = True Then
                        .setAttribute("ImpSaldoAnt", Me.DoctoRelacionados.Item(i).ImpSaldoAnt)
                    End If

                    If txtLEN(Me.DoctoRelacionados.Item(i).ImpPagado) = True Then
                        .setAttribute("ImpPagado", Me.DoctoRelacionados.Item(i).ImpPagado)
                    End If

                    If txtLEN(Me.DoctoRelacionados.Item(i).ImpSaldoInsoluto) = True Then
                        .setAttribute("ImpSaldoInsoluto", Me.DoctoRelacionados.Item(i).ImpSaldoInsoluto)
                    End If
                End With

                NodoPago.appendChild(NodoDoctoRelacionado)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Nodo Impuestos

            Dim NodoImpuestos As MSXML2.IXMLDOMElement
            NodoImpuestos = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Impuestos", xmlns)

            If Me.Impuestos.Retenciones.Count > 0 Then
                Dim NodoRetenciones As MSXML2.IXMLDOMElement
                NodoRetenciones = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Retenciones", xmlns)

                Dim NodoRetencion As MSXML2.IXMLDOMElement
                For i = 1 To Me.Impuestos.Retenciones.Count
                    NodoRetencion = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Retencion", xmlns)
                    With NodoRetencion
                        If txtLEN(Trim(Me.Impuestos.Retenciones.Item(i).Impuesto)) = True Then
                            .setAttribute("Impuesto", Me.Impuestos.Retenciones.Item(i).Impuesto) 'required
                        Else
                            MsgBox("El valor de Impuestos.Retenciones.Retencion.Impuesto es un dato requerido.", vbExclamation, NombreClase) : Return False
                        End If

                        If txtLEN(Trim(Me.Impuestos.Retenciones.Item(i).Importe)) = True Then
                            .setAttribute("Importe", Me.Impuestos.Retenciones.Item(i).Importe) 'required
                        Else
                            MsgBox("El valor de Impuestos.Retenciones.Retencion.Importe es un dato requerido.", vbExclamation, NombreClase) : Return False
                        End If
                    End With
                    NodoRetenciones.appendChild(NodoRetencion)
                Next

                NodoImpuestos.setAttribute("TotalImpuestosRetenidos", TotalImpuestosRetenidos)

                NodoImpuestos.appendChild(NodoRetenciones)
            End If

            If Me.Impuestos.Traslados.Count > 0 Then
                Dim NodoTraslados As MSXML2.IXMLDOMElement
                NodoTraslados = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Traslados", xmlns)

                Dim NodoTraslado As MSXML2.IXMLDOMElement
                For i = 1 To Me.Impuestos.Traslados.Count
                    NodoTraslado = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Traslado", xmlns)
                    With NodoTraslado
                        If txtLEN(Trim(Me.Impuestos.Traslados.Item(i).Impuesto)) = True Then
                            .setAttribute("Impuesto", Me.Impuestos.Traslados.Item(i).Impuesto) 'required
                        Else
                            MsgBox("El valor de Impuestos.Traslados.Traslado.Impuesto es un dato requerido.", vbExclamation, NombreClase) : Return False
                        End If

                        If txtLEN(Trim(Me.Impuestos.Traslados.Item(i).TipoFactor)) = True Then
                            .setAttribute("TipoFactor", Me.Impuestos.Traslados.Item(i).TipoFactor) 'required
                        Else
                            MsgBox("El valor de Impuestos.Traslados.Traslado.TipoFactor es un dato requerido.", vbExclamation, NombreClase) : Return False
                        End If

                        If txtLEN(Trim(Me.Impuestos.Traslados.Item(i).TasaOCuota)) = True Then
                            .setAttribute("TasaOCuota", Me.Impuestos.Traslados.Item(i).TasaOCuota) 'required
                        Else
                            MsgBox("El valor de Impuestos.Traslados.Traslado.TasaOCuota es un dato requerido.", vbExclamation, NombreClase) : Return False
                        End If

                        If txtLEN(Trim(Me.Impuestos.Traslados.Item(i).Importe)) = True Then
                            .setAttribute("Importe", Me.Impuestos.Traslados.Item(i).Importe) 'required
                        Else
                            MsgBox("El valor de Impuestos.Traslados.Traslado.Importe es un dato requerido.", vbExclamation, NombreClase) : Return False
                        End If
                    End With
                    NodoTraslados.appendChild(NodoTraslado)
                Next

                NodoImpuestos.setAttribute("TotalImpuestosTrasladados", TotalImpuestosTrasladados)

                NodoImpuestos.appendChild(NodoTraslados)
            End If

            If NodoImpuestos.childNodes.length > 0 Then
                NodoPago.appendChild(NodoImpuestos)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            NodoPagos.appendChild(NodoPago)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Me.ValidaComplementoPagos() = True Then
                'MsgBox NodoPago.xml
                bResultado = True
                mResultado = NodoPagos
                Me.ComplementoGenerado = True

                Me._Complemento = mResultado
            End If

        Catch ex As Exception
            HandleError(NombreClase, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidaComplementoPagos() As Boolean
        Const sProcedure As String = "ValidaComplementoPagos"
        Dim bResultado As Boolean = False

        Try
            Dim i As Integer, dSumaPagado As Double
            Dim msgGenerico As String, bObligaImpPagado As Boolean
            Dim MesAnioFechaPago As Double, MesAnioFechaCFDI As Double, MesAnteriorAnioFechaCFDI As Double, diaFechaCFDI As Integer

            'MsgBox dtFormasPago.Item("01").NOMBRE_METODO_PAGO

            'Estas validaciones son de limites de longitudes de algunos campos.''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Se quitaron estas validaciones, cuando se graba el pago se validan
            'If txtLEN(Me.CtaOrdenante) = True And Len(Me.CtaOrdenante) < 10 Then
            '    MsgBox("CtaOrdenante(Emisor) : La longitud mínima de este campo es de 10 dígitos." & vbCrLf &
            '               "El valor asignado es " & Me.CtaOrdenante, vbExclamation, sProcedure) : Exit Function
            'End If

            'If txtLEN(Me.CtaBeneficiario) = True And Len(Me.CtaBeneficiario) < 10 Then
            '    MsgBox("CtaBeneficiario(Destino) : La longitud mínima de este campo es de 10 dígitos." & vbCrLf &
            '               "El valor asignado es " & Me.CtaBeneficiario, vbExclamation, sProcedure) : Exit Function
            'End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            MesAnioFechaPago = Year(FechaSatAFechaNormal(Me.FechaPago)) & "." & Right("00" & Month(FechaSatAFechaNormal(Me.FechaPago)), 2)
            MesAnioFechaCFDI = Year(FechaSatAFechaNormal(Me.CfdComprobanteLectura.Fecha)) & "." & Right("00" & Month(FechaSatAFechaNormal(Me.CfdComprobanteLectura.Fecha)), 2)
            MesAnteriorAnioFechaCFDI = Year(DateAdd("m", -1, FechaSatAFechaNormal(Me.CfdComprobanteLectura.Fecha))) & "." & Right("00" & Month(DateAdd("m", -1, FechaSatAFechaNormal(Me.CfdComprobanteLectura.Fecha))), 2)
            diaFechaCFDI = FechaSatAFechaNormal(Me.CfdComprobanteLectura.Fecha).Day

            msgGenerico = "FechaPago=" & FormatFechaLarga(FechaSatAFechaNormal(Me.FechaPago)) & " CFDI:Fecha=" & FormatFechaLarga(FechaSatAFechaNormal(Me.CfdComprobanteLectura.Fecha))

            'If Not (FechaSatAFechaNormal(Me.FechaPago) <= FechaSatAFechaNormal(Me.CfdComprobanteLectura.Fecha)) Then
            '    MsgBox("FechaPago : Debe ser menor o igual al atributo CFDI:Fecha." & vbCrLf & msgGenerico, vbExclamation, sProcedure) : Exit Function
            'ElseIf (FechaSatAFechaNormal(Me.FechaPago) < FechaSatAFechaNormal(Me.CfdComprobanteLectura.Fecha)) Then
            '    If Not ((MesAnioFechaPago = MesAnioFechaCFDI) Or (MesAnioFechaPago = MesAnteriorAnioFechaCFDI And diaFechaCFDI <= 10)) Then
            '        MsgBox("FechaPago : La fecha del pago puede estar dentro del mes pasado durante los primeros 10 dias de la fecha del cfdi." & vbCrLf & msgGenerico, vbExclamation, sProcedure) : Exit Function
            '    End If
            'End If

            If FechaSatAFechaNormal(Me.FechaPago) > FechaSatAFechaNormal(Me.CfdComprobanteLectura.Fecha) Then
                MsgBox("FechaPago : Debe ser menor o igual al atributo CFDI:Fecha." & vbCrLf & msgGenerico, vbExclamation, sProcedure) : Exit Function
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim dRow() As DataRow = dtFormasPagoTodas.Select("CODIGO_METODO_PAGO='" & Me.FormaDePagoP & "'")
            If dRow.Length = 0 Then
                MsgBox("No se encontró en memoria la forma de pago " & Me.FormaDePagoP & " .", vbExclamation, sProcedure)
                Exit Function
            End If

            If Me.FormaDePagoP = "99" Then
                MsgBox("FormaDePagoP : El valor debe ser diferente de 99.", vbExclamation, sProcedure) : Exit Function
            Else
                '1
                'If dtFormasPago.Item(Me.FormaDePagoP).REQUIERE_NUMERO_OPERACION, es opcional
                'If dRow(0)("REQUIERE_NUMERO_OPERACION").ToString, es opcional

                '2
                'If dtFormasPago.Item(Me.FormaDePagoP).REQUIERE_RFC_EMISOR_CUENTA_ORDENANTE = "0" Then
                If dRow(0)("REQUIERE_RFC_EMISOR_CUENTA_ORDENANTE").ToString = "0" Then
                    If txtLEN(Me.RfcEmisorCtaOrd) = True Then
                        MsgBox("RfcEmisorCtaOrd : Este valor no es requerido según la forma de pago indicada.", vbExclamation, sProcedure) : Exit Function
                    End If
                End If
                '3
                'If dtFormasPago.Item(Me.FormaDePagoP).REQUIERE_CUENTA_ORDENANTE = "0" Then
                If dRow(0)("REQUIERE_CUENTA_ORDENANTE").ToString = "0" Then
                    If txtLEN(Me.CtaOrdenante) = True Then
                        MsgBox("CtaOrdenante : Este valor no es requerido según la forma de pago indicada.", vbExclamation, sProcedure) : Exit Function
                    End If
                End If
                '4
                'If dtFormasPago.Item(Me.FormaDePagoP).REQUIERE_RFC_EMISOR_CUENTA_ORDENANTE = "0" Then
                If dRow(0)("REQUIERE_RFC_EMISOR_CUENTA_ORDENANTE").ToString = "0" Then
                    If txtLEN(Me.CtaOrdenante) = True Then
                        MsgBox("CtaOrdenante : Este valor no es requerido según la forma de pago indicada.", vbExclamation, sProcedure) : Exit Function
                    End If
                End If
                '5
                'If dtFormasPago.Item(Me.FormaDePagoP).REQUIERE_CUENTA_BENEFICIARIO = "0" Then
                If dRow(0)("REQUIERE_CUENTA_BENEFICIARIO").ToString = "0" Then
                    If txtLEN(Me.CtaBeneficiario) = True Then
                        MsgBox("CtaBeneficiario : Este valor no es requerido según la forma de pago indicada.", vbExclamation, sProcedure) : Exit Function
                    End If
                End If
                '6
                'If dtFormasPago.Item(Me.FormaDePagoP).REQUIERE_TIPO_CADENA_PAGO = "0" Then
                If dRow(0)("REQUIERE_TIPO_CADENA_PAGO").ToString = "0" Then
                    If txtLEN(Me.TipoCadPago) = True Then
                        MsgBox("TipoCadPago : Este valor no es requerido según la forma de pago indicada.", vbExclamation, sProcedure) : Exit Function
                    End If
                End If
                '7
                'If dtFormasPago.Item(Me.FormaDePagoP).REQUIERE_NOMBRE_BANCO_EXTRANJERO_ORIGEN = "1" And Me.RfcEmisorCtaOrd = "XEXX010101000" Then
                If dRow(0)("REQUIERE_NOMBRE_BANCO_EXTRANJERO_ORIGEN").ToString = "1" And Me.RfcEmisorCtaOrd = "XEXX010101000" Then
                    If txtLEN(Me.NomBancoOrdExt) = False Then
                        MsgBox("NomBancoOrdExt : Si el RFC del emisor de la cuenta ordenante(origen) es XEXX010101000, este campo es obligatorio.") : Exit Function
                    End If
                End If
            End If

            If Not (Me.MonedaP = "MXN" Or Me.MonedaP = "XXX") Then
                If valorNumerico(Me.TipoCambioP) <= 0 Then
                    MsgBox("MonedaP : Si es diferente de MXN o XXX, debe existir información en el atributo TipoCambioP.", vbExclamation, sProcedure) : Exit Function
                End If
            Else
                If txtLEN(Me.TipoCambioP) = True Then
                    MsgBox("MonedaP : Si es MXN o XXX, no debe existir información en el atributo TipoCambioP.", vbExclamation, sProcedure) : Exit Function
                End If
            End If

            If valorNumerico(Me.Monto) <= 0 Then
                MsgBox("Monto : Debe ser mayor a cero.", vbExclamation, sProcedure) : Exit Function
            End If

            For i = 1 To Me.DoctoRelacionados.Count
                dSumaPagado = dSumaPagado + valorNumerico(Me.DoctoRelacionados.Item(i).ImpPagado)
                dSumaPagado = Redondear(dSumaPagado, 2)
            Next

            'MsgBox ("duda: NumOperacion , validar que la lleve si es spei ?, no esta claro si deba ser obligatorio a llevar la clave de rastreo en caso de ser SPEI(Dice en la guia NumOperacion)"

            If dSumaPagado <> valorNumerico(Me.Monto) Then
                'If dSumaPagado > valorNumerico(Me.Monto) Then
                'MsgBox("Monto : La suma de los valores registrados en el nodo DoctoRelacionados, atributo ImpPagado, sea menor o igual que el valor de este atributo." & vbCrLf &
                MsgBox("Monto : La suma de los valores registrados en el nodo DoctoRelacionados, atributo ImpPagado, sea igual que el valor de este atributo." & vbCrLf &
                       "Pago.Monto=" & Me.Monto & vbCrLf & "Suma DoctoRelacionados.ImpPagado=" & dSumaPagado.ToString, vbExclamation, sProcedure) : Exit Function
            End If

            If dRow(0)("ES_BANCARIZADO").ToString = "0" And txtLEN(Me.TipoCadPago) = True Then
                MsgBox("TipoCadPago : Se debe omitir si la forma de pago no es bancarizada.", vbExclamation, sProcedure) : Exit Function
            End If

            msgGenerico = "TipoCadPago : Si existe este campo es obligatorio registrar los campos ""CertificadoPago"",""CadenaPago"" y ""SelloPago"", en otro caso estos atributos no deben existir."

            'Nota Se pone la leyenda 3 veces repetidas(en vez de poner un solo if con x or x or x) para poner el texto original del sat.
            If txtLEN(Me.TipoCadPago) = True Then
                If txtLEN(Me.CertPago) = False Then
                    MsgBox(msgGenerico & vbCrLf & "Tiene vacio el atributo CertificadoPago", vbExclamation, sProcedure) : Exit Function
                End If

                If txtLEN(Me.CadPago) = False Then
                    MsgBox(msgGenerico & vbCrLf & "Tiene vacio el atributo CadenaPago", vbExclamation, sProcedure) : Exit Function
                End If

                If txtLEN(Me.CertPago) = False Or txtLEN(Me.CadPago) = False Or txtLEN(Me.SelloPago) = False Then
                    MsgBox(msgGenerico & vbCrLf & "Tiene vacio el atributo SelloPago", vbExclamation, sProcedure) : Exit Function
                End If
            Else
                If txtLEN(Me.CertPago) = True Then
                    MsgBox(msgGenerico & vbCrLf & "No debe existir información en el atributo CertificadoPago", vbExclamation, sProcedure) : Exit Function
                End If

                If txtLEN(Me.CadPago) = True Then
                    MsgBox(msgGenerico & vbCrLf & "No debe existir información en el atributo CadenaPago", vbExclamation, sProcedure) : Exit Function
                End If

                If txtLEN(Me.CertPago) = True Then
                    MsgBox(msgGenerico & vbCrLf & "No debe existir información en el atributo SelloPago", vbExclamation, sProcedure) : Exit Function
                End If
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Validaciones de DoctoRelacionados
            If (Me.CfdComprobanteLectura.TipoDeComprobante = "I" Or Me.CfdComprobanteLectura.TipoDeComprobante = "E") And Me.DoctoRelacionados.Count > 0 Then
                MsgBox("DoctoRelacionados: Si el tipo de comprobante es ingreso o egreso no se debe incluir este nodo.", vbExclamation, sProcedure) : Exit Function
            End If

            If Me.DoctoRelacionados.Count > 1 Then
                bObligaImpPagado = True
            ElseIf Me.DoctoRelacionados.Count = 1 Then
                If valorNumerico(Me.DoctoRelacionados.Item(1).TipoCambioDR) > 0 Then
                    bObligaImpPagado = True
                End If
            End If

            For i = 1 To Me.DoctoRelacionados.Count
                If txtLEN(Me.DoctoRelacionados.Item(i).IdDocumento) = False Then
                    MsgBox("DoctoRelacionados.IdDocumento : Atributo requerido para expresar el identificador del documento relacionado con el pago. " &
                    "Este dato puede ser un Folio Fiscal de la Factura Electrónica o bien el número de operación de un documento digital.", vbExclamation, sProcedure)
                    Exit Function
                End If

                If Me.DoctoRelacionados.Item(i).MonedaDR = "XXX" Then
                    MsgBox("DoctoRelacionados.ModenaDR : No debe contener el valor ""XXX"".", vbExclamation, sProcedure) : Exit Function
                End If

                If Me.DoctoRelacionados.Item(i).MonedaDR <> Me.MonedaP Then
                    If valorNumerico(Me.DoctoRelacionados.Item(i).TipoCambioDR) <= 0 Then
                        MsgBox("DoctoRelacionados.ModenaDR : si el valor de este campo es diferente al valor registrado en el campo MonedaP, " &
                            "se debe registrar información en el campo TipoCambioDR.", vbExclamation, sProcedure) : Exit Function
                    End If
                ElseIf Me.DoctoRelacionados.Item(i).MonedaDR = "MXN" And Me.MonedaP = "MXN" Then
                    If txtLEN(Me.DoctoRelacionados.Item(i).TipoCambioDR) = True Then
                        MsgBox("DoctoRelacionados.ModenaDR : si el valor de este campo y el campo MonedaP es MXN(Pesos Mexicanos) no debe registrar inforamación en el campo TipoCambioDR.", vbExclamation, sProcedure) : Exit Function
                    End If
                End If

                msgGenerico = "DoctoRelacionados.MetodoDePagoDR: " & vbCrLf & " Si el valor de este campo es ""Pago en parcialidades o diferido"" o ""Pago inicial y parcialidades"" " &
                                "se deben registrar los atributos ""NumParcialidad"" ""ImpSaldoAnt"" ""ImpSaldoInsoluto"" " & vbCrLf

                If Me.DoctoRelacionados.Item(i).MetodoDePagoDR = "PPD" Or Me.DoctoRelacionados.Item(i).MetodoDePagoDR = "PIP" Then
                    If txtLEN(Me.DoctoRelacionados.Item(i).NumParcialidad) = False Then
                        MsgBox(msgGenerico & "El atributo NumParcialidad esta vacío.", vbExclamation, sProcedure) : Exit Function
                    End If
                    If valorNumerico(Me.DoctoRelacionados.Item(i).ImpSaldoAnt) <= 0 Then
                        MsgBox(msgGenerico & "El atributo ImpSaldoAnt debe ser mayor a 0.", vbExclamation, sProcedure) : Exit Function
                    End If
                    If txtLEN(Me.DoctoRelacionados.Item(i).ImpSaldoInsoluto) = False Then
                        MsgBox(msgGenerico & "El atributo ImpSaldoInsoluto debe ser mayor a 0.", vbExclamation, sProcedure) : Exit Function
                    End If
                End If

                If bObligaImpPagado = True Then
                    If valorNumerico(Me.DoctoRelacionados.Item(i).ImpPagado) <= 0 Then
                        MsgBox("DoctoRelacionados.ImpPagado : Debe ser mayor a 0.", vbExclamation, sProcedure) : Exit Function
                    End If
                End If
                'Si no entonces es opcional

                If txtLEN(Me.DoctoRelacionados.Item(i).ImpPagado) = True Then 'Se pregunta otra vez sobre este campo por ser opcional, aqui primero se fija si trae algo
                    If valorNumerico(Me.DoctoRelacionados.Item(i).ImpPagado) <= 0 Then
                        MsgBox("DoctoRelacionados.ImpPagado : Debe ser mayor a 0.", vbExclamation, sProcedure) : Exit Function
                    End If
                End If

                Dim sTexto As String

                If txtLEN(Me.DoctoRelacionados.Item(i).ImpSaldoInsoluto) = True Then
                    Dim SaldoInsoluto As Double

                    If txtLEN(Me.DoctoRelacionados.Item(i).ImpPagado) = True Then
                        SaldoInsoluto = Me.DoctoRelacionados.Item(i).ImpSaldoAnt - Me.DoctoRelacionados.Item(i).ImpPagado
                        sTexto = Me.DoctoRelacionados.Item(i).ImpSaldoAnt & "-" & Me.DoctoRelacionados.Item(i).ImpPagado & "<>" & Me.DoctoRelacionados.Item(i).ImpSaldoInsoluto
                    Else
                        SaldoInsoluto = Me.DoctoRelacionados.Item(i).ImpSaldoAnt - Me.Monto
                        sTexto = Me.DoctoRelacionados.Item(i).ImpSaldoAnt & "-" & Me.Monto & "<>" & Me.DoctoRelacionados.Item(i).ImpSaldoInsoluto
                    End If

                    SaldoInsoluto = Redondear(SaldoInsoluto, 2)

                    If Me.DoctoRelacionados.Item(i).ImpSaldoInsoluto <> SaldoInsoluto Then
                        MsgBox("DoctoRelacionados.ImpSaldoInsoluto: Debe calcularse de los atributos ImpSaldoAnt menos el ImpPagado(o si no esta este valor, entonces del monto)" & vbCrLf &
                                "Operación realizada : " & vbCrLf & sTexto, vbExclamation, sProcedure) : Exit Function
                    End If
                End If
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With Me.Impuestos.Retenciones
                msgGenerico = "Impuestos.Retenciones.Retencion: " & vbCrLf & "Tiene vacio el atributo "
                For i = 1 To .Count
                    If txtLEN(.Item(i).Impuesto) = False Then
                        MsgBox(msgGenerico & "Impuesto", vbExclamation, sProcedure) : Exit Function
                    End If

                    If txtLEN(.Item(i).Importe) = False Then
                        MsgBox(msgGenerico & "Importe", vbExclamation, sProcedure) : Exit Function
                    End If
                Next
            End With

            With Me.Impuestos.Traslados
                msgGenerico = "Impuestos.Retenciones.Traslado: "
                For i = 1 To .Count
                    If txtLEN(.Item(i).Impuesto) = False Then
                        MsgBox(msgGenerico & "Impuesto", vbExclamation, sProcedure) : Exit Function
                    End If

                    If txtLEN(.Item(i).TipoFactor) = False Then
                        MsgBox(msgGenerico & "TipoFactor", vbExclamation, sProcedure) : Exit Function
                    End If

                    If txtLEN(.Item(i).TasaOCuota) = False Then
                        MsgBox(msgGenerico & "TasaOCuota", vbExclamation, sProcedure) : Exit Function
                    End If

                    If txtLEN(.Item(i).Importe) = False Then
                        MsgBox(msgGenerico & "Importe", vbExclamation, sProcedure) : Exit Function
                    End If
                Next
            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            bResultado = True

        Catch ex As Exception
            HandleError(NombreClase, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function TotalImpuestosRetenidos() As String
        Const sProcedure As String = "TotalImpuestosRetenidos"
        Dim sResultado As String = ""
        Try
            Dim i As Integer, dTotal As Double

            For i = 1 To Me.Impuestos.Retenciones.Count
                dTotal = dTotal + valorNumerico(Impuestos.Retenciones.Item(i).Importe)
            Next

            sResultado = Format(dTotal, "#0.00")
        Catch ex As Exception
            HandleError(NombreClase, sProcedure, ex)
        End Try

        Return sResultado
    End Function

    Private Function TotalImpuestosTrasladados() As String
        Const sProcedure As String = "TotalImpuestosTrasladados"
        Dim sResultado As String = ""
        Try
            Dim i As Integer, dTotal As Double

            For i = 1 To Me.Impuestos.Traslados.Count
                dTotal = dTotal + valorNumerico(Impuestos.Traslados.Item(i).Importe)
            Next

            sResultado = Format(dTotal, "#0.00")
        Catch ex As Exception
            HandleError(NombreClase, sProcedure, ex)
        End Try

        Return sResultado
    End Function

End Class
