Option Explicit On

Friend Class cComplementoPagos20

    Private Const NombreClase As String = "cComplementoPagos20"

    Private xmlns As String
    Private xmlnspago20 As String
    Private xsischemaLocation As String
    Private AnexoNodo As String

    Public CfdComprobanteLectura As cComprobante40 'Se necesita para validar algunos datos del comprobante en este complemento

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

    Public Totales As New cPagosTotales20
    Public DoctoRelacionados As cPagosDoctoRelacionados20
    Public ImpuestosP As iImpuestos40

    Public ComplementoGenerado As Boolean

    Private _Complemento As MSXML2.IXMLDOMElement

    Public ReadOnly Property Complemento As MSXML2.IXMLDOMElement
        Get
            Return Me._Complemento
        End Get
    End Property

    Private Sub Class_Initialize_Renamed()
        Const sProcedure As String = "Class_Initialize_Renamed"
        Try
            AnexoNodo = "pago20:"

            xmlns = "http://www.sat.gob.mx/Pagos20"
            xmlnspago20 = "http://www.sat.gob.mx/Pagos20"
            xsischemaLocation = "http://www.sat.gob.mx/Pagos20 http://www.sat.gob.mx/sitio_internet/cfd/Pagos/Pagos20.xsd"

            DoctoRelacionados = New cPagosDoctoRelacionados20
            ImpuestosP = New iImpuestos40

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
                '.setAttribute ("xmlns:pago20", xmlnspago20) 'Da lo mismo ponerlo o no, si se omite lo pone automáticamente al hacer Set NodoPagos =

                If txtLEN(Me.Version) = False Then
                    MsgBox("El valor de Version es un dato requerido.", vbExclamation, sProcedure) : Return False
                Else
                    .setAttribute("Version", Me.Version) 'required
                End If
            End With
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim NodoTotales As MSXML2.IXMLDOMElement
            NodoTotales = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Totales", xmlns)

            With NodoTotales
                If txtLEN(Me.Totales.TotalRetencionesIVA) = True And valorNumericoD(Me.Totales.TotalRetencionesIVA) > 0 Then
                    .setAttribute("TotalRetencionesIVA", Me.Totales.TotalRetencionesIVA) 'optional
                End If

                If txtLEN(Me.Totales.TotalRetencionesISR) = True And valorNumericoD(Me.Totales.TotalRetencionesISR) > 0 Then
                    .setAttribute("TotalRetencionesISR", Me.Totales.TotalRetencionesISR) 'optional
                End If

                If txtLEN(Me.Totales.TotalRetencionesIEPS) = True And valorNumericoD(Me.Totales.TotalRetencionesIEPS) > 0 Then
                    .setAttribute("TotalRetencionesIEPS", Me.Totales.TotalRetencionesIEPS) 'optional
                End If

                If txtLEN(Me.Totales.TotalTrasladosBaseIVA16) = True And valorNumericoD(Me.Totales.TotalTrasladosBaseIVA16) > 0 Then
                    .setAttribute("TotalTrasladosBaseIVA16", Me.Totales.TotalTrasladosBaseIVA16) 'optional
                End If

                If txtLEN(Me.Totales.TotalTrasladosImpuestoIVA16) = True And valorNumericoD(Me.Totales.TotalTrasladosImpuestoIVA16) > 0 Then
                    .setAttribute("TotalTrasladosImpuestoIVA16", Me.Totales.TotalTrasladosImpuestoIVA16) 'optional
                End If

                If txtLEN(Me.Totales.TotalTrasladosBaseIVA8) = True And valorNumericoD(Me.Totales.TotalTrasladosBaseIVA8) > 0 Then
                    .setAttribute("TotalTrasladosBaseIVA8", Me.Totales.TotalTrasladosBaseIVA8) 'optional
                End If

                If txtLEN(Me.Totales.TotalTrasladosImpuestoIVA8) = True And valorNumericoD(Me.Totales.TotalTrasladosImpuestoIVA8) > 0 Then
                    .setAttribute("TotalTrasladosImpuestoIVA8", Me.Totales.TotalTrasladosImpuestoIVA8) 'optional
                End If

                If txtLEN(Me.Totales.TotalTrasladosBaseIVA0) = True And valorNumericoD(Me.Totales.TotalTrasladosBaseIVA0) > 0 Then
                    .setAttribute("TotalTrasladosBaseIVA0", Me.Totales.TotalTrasladosBaseIVA0) 'optional
                End If

                'Puede tener TotalTrasladosBaseIVA0>0 y sabemos que TotalTrasladosImpuestoIVA0 siempre será 0 pero en este caso si
                'lo ponemos aún con 0 ó el SAT nos marcaria error.
                If (txtLEN(Me.Totales.TotalTrasladosImpuestoIVA0) = True And valorNumericoD(Me.Totales.TotalTrasladosImpuestoIVA0) > 0) _
                    Or valorNumericoD(Me.Totales.TotalTrasladosBaseIVA0) > 0 Then
                    .setAttribute("TotalTrasladosImpuestoIVA0", Me.Totales.TotalTrasladosImpuestoIVA0) 'optional
                End If

                If txtLEN(Me.Totales.TotalTrasladosBaseIVAExento) = True And valorNumericoD(Me.Totales.TotalTrasladosBaseIVAExento) > 0 Then
                    .setAttribute("TotalTrasladosBaseIVAExento", Me.Totales.TotalTrasladosBaseIVAExento) 'optional
                End If

                If txtLEN(Me.Totales.MontoTotalPagos) = False Then
                    MsgBox("El valor de Totales.MontoTotalPagos es un dato requerido.", vbExclamation, sProcedure) : Return False
                Else
                    .setAttribute("MontoTotalPagos", Me.Totales.MontoTotalPagos) 'required
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

                    If txtLEN(Me.DoctoRelacionados.Item(i).EquivalenciaDR) = True Then
                        .setAttribute("EquivalenciaDR", Me.DoctoRelacionados.Item(i).EquivalenciaDR)
                    End If

                    If txtLEN(Me.DoctoRelacionados.Item(i).NumParcialidad) = True Then
                        .setAttribute("NumParcialidad", Me.DoctoRelacionados.Item(i).NumParcialidad)
                    End If

                    If txtLEN(Me.DoctoRelacionados.Item(i).ImpSaldoAnt) = True Then
                        .setAttribute("ImpSaldoAnt", Me.DoctoRelacionados.Item(i).ImpSaldoAnt)
                    Else
                        MsgBox("El valor de DoctoRelacionados.ImpSaldoAnt es un dato requerido.", vbExclamation, sProcedure)
                        Return False
                    End If

                    If txtLEN(Me.DoctoRelacionados.Item(i).ImpPagado) = True Then
                        .setAttribute("ImpPagado", Me.DoctoRelacionados.Item(i).ImpPagado)
                    Else
                        MsgBox("El valor de DoctoRelacionados.ImpPagado es un dato requerido.", vbExclamation, sProcedure)
                        Return False
                    End If

                    If txtLEN(Me.DoctoRelacionados.Item(i).ImpSaldoInsoluto) = True Then
                        .setAttribute("ImpSaldoInsoluto", Me.DoctoRelacionados.Item(i).ImpSaldoInsoluto)
                    Else
                        MsgBox("El valor de DoctoRelacionados.ImpSaldoInsoluto es un dato requerido.", vbExclamation, sProcedure)
                        Return False
                    End If

                    If txtLEN(Me.DoctoRelacionados.Item(i).ObjetoImpDR) = True Then
                        .setAttribute("ObjetoImpDR", Me.DoctoRelacionados.Item(i).ObjetoImpDR)
                    Else
                        MsgBox("El valor de DoctoRelacionados.ObjetoImpDR es un dato requerido.", vbExclamation, sProcedure)
                        Return False
                    End If
                End With

                Dim NodoImpuestosDR As MSXML2.IXMLDOMElement
                NodoImpuestosDR = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "ImpuestosDR", xmlns)

                Dim NodoTrasladosDR As MSXML2.IXMLDOMElement, NodoTrasladoDR As MSXML2.IXMLDOMElement
                Dim NodoRetencionesDR As MSXML2.IXMLDOMElement, NodoRetencionDR As MSXML2.IXMLDOMElement

                If Me.DoctoRelacionados.Item(i).TrasladosDR.Count > 0 Then
                    NodoTrasladosDR = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "TrasladosDR", xmlns)
                    For j = 1 To Me.DoctoRelacionados.Item(i).TrasladosDR.Count
                        NodoTrasladoDR = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "TrasladoDR", xmlns)

                        If txtLEN(Trim(Me.DoctoRelacionados.Item(i).TrasladosDR.Item(j).BaseDR)) = True Then
                            NodoTrasladoDR.setAttribute("BaseDR", Trim(Me.DoctoRelacionados.Item(i).TrasladosDR.Item(j).BaseDR)) 'required
                        Else
                            MsgBox("El valor de DoctoRelacionado.ImpuestosDR.TrasladosDR.TrasladoDR.BaseDR es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Trim(Me.DoctoRelacionados.Item(i).TrasladosDR.Item(j).ImpuestoDR)) = True Then
                            NodoTrasladoDR.setAttribute("ImpuestoDR", Trim(Me.DoctoRelacionados.Item(i).TrasladosDR.Item(j).ImpuestoDR)) 'required
                        Else
                            MsgBox("El valor de DoctoRelacionado.ImpuestosDR.TrasladosDR.TrasladoDR.ImpuestoDR es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Trim(Me.DoctoRelacionados.Item(i).TrasladosDR.Item(j).TipoFactorDR)) = True Then
                            NodoTrasladoDR.setAttribute("TipoFactorDR", Trim(Me.DoctoRelacionados.Item(i).TrasladosDR.Item(j).TipoFactorDR)) 'required
                        Else
                            MsgBox("El valor de DoctoRelacionado.ImpuestosDR.TrasladosDR.TrasladoDR.TipoFactorDR es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Trim(Me.DoctoRelacionados.Item(i).TrasladosDR.Item(j).TasaOCuotaDR)) = True Then
                            NodoTrasladoDR.setAttribute("TasaOCuotaDR", Trim(Me.DoctoRelacionados.Item(i).TrasladosDR.Item(j).TasaOCuotaDR)) 'optional
                        End If

                        If txtLEN(Trim(Me.DoctoRelacionados.Item(i).TrasladosDR.Item(j).ImporteDR)) = True Then
                            NodoTrasladoDR.setAttribute("ImporteDR", Trim(Me.DoctoRelacionados.Item(i).TrasladosDR.Item(j).ImporteDR)) 'optional
                        End If

                        NodoTrasladosDR.appendChild(NodoTrasladoDR)
                    Next

                    NodoImpuestosDR.appendChild(NodoTrasladosDR)
                End If

                If Me.DoctoRelacionados.Item(i).RetencionesDR.Count > 0 Then
                    NodoRetencionesDR = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "RetencionesDR", xmlns)
                    For j = 1 To Me.DoctoRelacionados.Item(i).RetencionesDR.Count
                        NodoRetencionDR = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "RetencionDR", xmlns)

                        If txtLEN(Trim(Me.DoctoRelacionados.Item(i).RetencionesDR.Item(j).BaseDR)) = True Then
                            NodoRetencionDR.setAttribute("BaseDR", Trim(Me.DoctoRelacionados.Item(i).RetencionesDR.Item(j).BaseDR)) 'required
                        Else
                            MsgBox("El valor de DoctoRelacionado.ImpuestosDR.RetencionesDR.RetencionDR.Base es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Trim(Me.DoctoRelacionados.Item(i).RetencionesDR.Item(j).ImpuestoDR)) = True Then
                            NodoRetencionDR.setAttribute("ImpuestoDR", Trim(Me.DoctoRelacionados.Item(i).RetencionesDR.Item(j).ImpuestoDR)) 'required
                        Else
                            MsgBox("El valor de DoctoRelacionado.ImpuestosDR.RetencionesDR.RetencionDR.ImpuestoDR es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Trim(Me.DoctoRelacionados.Item(i).RetencionesDR.Item(j).TipoFactorDR)) = True Then
                            NodoRetencionDR.setAttribute("TipoFactorDR", Trim(Me.DoctoRelacionados.Item(i).RetencionesDR.Item(j).TipoFactorDR)) 'required
                        Else
                            MsgBox("El valor de DoctoRelacionado.ImpuestosDR.RetencionesDR.RetencionDR.TipoFactorDR es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Trim(Me.DoctoRelacionados.Item(i).RetencionesDR.Item(j).TasaOCuotaDR)) = True Then
                            NodoRetencionDR.setAttribute("TasaOCuotaDR", Trim(Me.DoctoRelacionados.Item(i).RetencionesDR.Item(j).TasaOCuotaDR)) 'required
                        Else
                            MsgBox("El valor de DoctoRelacionado.ImpuestosDR.RetencionesDR.RetencionDR.TasaOCuotaDR es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Trim(Me.DoctoRelacionados.Item(i).RetencionesDR.Item(j).ImporteDR)) = True Then
                            NodoRetencionDR.setAttribute("ImporteDR", Trim(Me.DoctoRelacionados.Item(i).RetencionesDR.Item(j).ImporteDR)) 'required
                        Else
                            MsgBox("El valor de DoctoRelacionado.ImpuestosDR.RetencionesDR.RetencionDR.ImporteDR es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        NodoRetencionesDR.appendChild(NodoRetencionDR)
                    Next

                    NodoImpuestosDR.appendChild(NodoRetencionesDR)
                End If

                If NodoImpuestosDR.childNodes.length > 0 Then
                    NodoDoctoRelacionado.appendChild(NodoImpuestosDR)
                End If

                NodoPago.appendChild(NodoDoctoRelacionado)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Nodo Impuestos

            'Nota no se creó la clase iImpuestosP y reutilizamos la misma de facturación iImpuestos40 ya que tiene la misma estructura

            Dim NodoImpuestosP As MSXML2.IXMLDOMElement
            NodoImpuestosP = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "ImpuestosP", xmlns)

            If Me.ImpuestosP.Retenciones.Count > 0 Then
                Dim NodoRetencionesP As MSXML2.IXMLDOMElement
                NodoRetencionesP = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "RetencionesP", xmlns)

                Dim NodoRetencionP As MSXML2.IXMLDOMElement
                For i = 1 To Me.ImpuestosP.Retenciones.Count
                    NodoRetencionP = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "RetencionP", xmlns)
                    With NodoRetencionP
                        If txtLEN(Trim(Me.ImpuestosP.Retenciones.Item(i).Impuesto)) = True Then
                            .setAttribute("ImpuestoP", Me.ImpuestosP.Retenciones.Item(i).Impuesto) 'required
                        Else
                            MsgBox("El valor de ImpuestosP.RetencionesP.RetencionP.ImpuestoP es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Trim(Me.ImpuestosP.Retenciones.Item(i).Importe)) = True Then
                            .setAttribute("ImporteP", Me.ImpuestosP.Retenciones.Item(i).Importe) 'required
                        Else
                            MsgBox("El valor de ImpuestosP.RetencionesP.RetencionP.ImporteP es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If
                    End With
                    NodoRetencionesP.appendChild(NodoRetencionP)
                Next

                'Aqui no hay totales de impuestos como en una factura
                'NodoImpuestosP.setAttribute "TotalImpuestosRetenidos", TotalImpuestosRetenidos

                NodoImpuestosP.appendChild(NodoRetencionesP)
            End If

            If Me.ImpuestosP.Traslados.Count > 0 Then
                Dim NodoTrasladosP As MSXML2.IXMLDOMElement
                NodoTrasladosP = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "TrasladosP", xmlns)

                Dim NodoTrasladoP As MSXML2.IXMLDOMElement
                For i = 1 To Me.ImpuestosP.Traslados.Count
                    NodoTrasladoP = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "TrasladoP", xmlns)
                    With NodoTrasladoP
                        If txtLEN(Trim(Me.ImpuestosP.Traslados.Item(i).Base)) = True Then
                            .setAttribute("BaseP", Me.ImpuestosP.Traslados.Item(i).Base) 'required
                        Else
                            MsgBox("El valor de ImpuestosP.TrasladosP.TrasladoP.BaseP es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Trim(Me.ImpuestosP.Traslados.Item(i).Impuesto)) = True Then
                            .setAttribute("ImpuestoP", Me.ImpuestosP.Traslados.Item(i).Impuesto) 'required
                        Else
                            MsgBox("El valor de ImpuestosP.TrasladosP.TrasladoP.ImpuestoP es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Trim(Me.ImpuestosP.Traslados.Item(i).TipoFactor)) = True Then
                            .setAttribute("TipoFactorP", Me.ImpuestosP.Traslados.Item(i).TipoFactor) 'required
                        Else
                            MsgBox("El valor de ImpuestosP.TrasladosP.TrasladoP.TipoFactorP es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Trim(Me.ImpuestosP.Traslados.Item(i).TasaOCuota)) = True Then
                            .setAttribute("TasaOCuotaP", Me.ImpuestosP.Traslados.Item(i).TasaOCuota) 'optional
                        End If

                        If txtLEN(Trim(Me.ImpuestosP.Traslados.Item(i).Importe)) = True Then
                            .setAttribute("ImporteP", Me.ImpuestosP.Traslados.Item(i).Importe) 'optional
                        End If
                    End With
                    NodoTrasladosP.appendChild(NodoTrasladoP)
                Next

                'Aqui no hay totales de impuestos como en una factura
                'NodoImpuestosP.setAttribute "TotalImpuestosTrasladados", TotalImpuestosTrasladados

                NodoImpuestosP.appendChild(NodoTrasladosP)
            End If

            If NodoImpuestosP.childNodes.length > 0 Then
                NodoPago.appendChild(NodoImpuestosP)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            NodoPagos.appendChild(NodoTotales)

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

        'MsgBox("falta revisar si hay mas validaciones de proveedor hacer")
        'MsgBox("y falta comparar con las de abacosql ya que aqui se pusieron una copia de la del 33")

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

            If Me.MonedaP <> "MXN" Then
                If txtLEN(Me.TipoCambioP) = False Then
                    MsgBox("MonedaP : Si el atributo MonedaP es diferente de MXN, debe existir información en el atributo TipoCambioP.", vbExclamation, sProcedure) : Exit Function
                End If
            Else 'Entonces es igual a MXN
                If valorNumerico(Me.TipoCambioP) <> 1 Then
                    MsgBox("MonedaP : Si el atributo MonedaP es MXN, se debe registrar el valor 1 en el atributo TipoCambioP.", vbExclamation, sProcedure) : Exit Function
                End If
            End If

            If valorNumerico(Me.Monto) <= 0 Then
                MsgBox("Monto : Debe ser mayor a cero.", vbExclamation, sProcedure) : Exit Function
            End If

            Dim dPagoDR As Decimal = 0
            For i = 1 To Me.DoctoRelacionados.Count
                'dSumaPagado = dSumaPagado + valorNumerico(Me.DoctoRelacionados.Item(i).ImpPagado)

                If Me.DoctoRelacionados.Item(i).MonedaDR <> Me.MonedaP Then
                    dPagoDR = RedondearD(valorNumericoD(Me.DoctoRelacionados.Item(i).ImpPagado) / valorNumericoD(Me.DoctoRelacionados.Item(i).EquivalenciaDR), 2)
                Else
                    dPagoDR = valorNumericoD(Me.DoctoRelacionados.Item(i).ImpPagado)
                End If

                dSumaPagado = dSumaPagado + dPagoDR
                dSumaPagado = Redondear(dSumaPagado, 2)
            Next

            'MsgBox ("duda: NumOperacion , validar que la lleve si es spei ?, no esta claro si deba ser obligatorio a llevar la clave de rastreo en caso de ser SPEI(Dice en la guia NumOperacion)"

            '******Esta validación ya no se necesitara, la hace el proveedor de timbres ******
            'If dSumaPagado <> valorNumerico(Me.Monto) Then
            'If Math.Abs(dSumaPagado - valorNumericoD(Me.Monto)) > 10 Then 'El sat permite una variación que calcula, de momento validamos 10 pesos fijos.
            '    'If dSumaPagado > valorNumerico(Me.Monto) Then
            '    'MsgBox("Monto : La suma de los valores registrados en el nodo DoctoRelacionados, atributo ImpPagado, sea menor o igual que el valor de este atributo." & vbCrLf &
            '    MsgBox("Monto : La suma de los valores registrados en el nodo DoctoRelacionados, atributo ImpPagado, sea igual que el valor de este atributo." & vbCrLf &
            '           "Pago.Monto=" & Me.Monto & vbCrLf & "Suma DoctoRelacionados.ImpPagado=" & dSumaPagado.ToString, vbExclamation, sProcedure) : Exit Function
            'End If

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
                If valorNumerico(Me.DoctoRelacionados.Item(1).EquivalenciaDR) > 0 Then
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
                    If valorNumerico(Me.DoctoRelacionados.Item(i).EquivalenciaDR) <= 0 Then
                        MsgBox("DoctoRelacionados.EquivalenciaDR : Si el valor del atributo MonedaDR es diferente al valor registrado en el atributo MonedaP, " &
                        "se debe registrar información en el atributo EquivalenciaDR.", vbExclamation, sProcedure) : Exit Function
                    End If
                ElseIf Me.DoctoRelacionados.Item(i).MonedaDR = Me.MonedaP Then
                    If valorNumerico(Me.DoctoRelacionados.Item(i).EquivalenciaDR) <> "1" Then
                        MsgBox("DoctoRelacionados.EquivalenciaDR : Si el valor del atributo MonedaDR es igual al valor registrado en el atributo MonedaP, " &
                        "se debe registrar el valor 1 en el atributo EquivalenciaDR.", vbExclamation, sProcedure) : Exit Function
                    End If
                End If

                msgGenerico = "DoctoRelacionados.MetodoDePagoDR: " & vbCrLf & " Si el valor de este campo es ""Pago en parcialidades o diferido"" o ""Pago inicial y parcialidades"" " &
                                "se deben registrar los atributos ""NumParcialidad"" ""ImpSaldoAnt"" ""ImpSaldoInsoluto"" " & vbCrLf

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

            With Me.ImpuestosP.Retenciones
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

            With Me.ImpuestosP.Traslados
                msgGenerico = "ImpuestosP.TrasladosP.TrasladoP " & vbCrLf & "Tiene vacio el atributo "
                For i = 1 To .Count
                    If txtLEN(.Item(i).Impuesto) = False Then
                        MsgBox(msgGenerico & "Impuesto", vbExclamation, sProcedure) : Exit Function
                    End If

                    If txtLEN(.Item(i).TipoFactor) = False Then
                        MsgBox(msgGenerico & "TipoFactor", vbExclamation, sProcedure) : Exit Function
                    End If

                    If .Item(i).TipoFactor <> "Exento" Then
                        If txtLEN(.Item(i).TasaOCuota) = False Then
                            MsgBox(msgGenerico & "TasaOCuota", vbExclamation, sProcedure) : Exit Function
                        End If

                        If txtLEN(.Item(i).Importe) = False Then
                            MsgBox(msgGenerico & "Importe", vbExclamation, sProcedure) : Exit Function
                        End If
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

            For i = 1 To Me.ImpuestosP.Retenciones.Count
                dTotal = dTotal + valorNumerico(ImpuestosP.Retenciones.Item(i).Importe)
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

            For i = 1 To Me.ImpuestosP.Traslados.Count
                dTotal = dTotal + valorNumerico(ImpuestosP.Traslados.Item(i).Importe)
            Next

            sResultado = Format(dTotal, "#0.00")
        Catch ex As Exception
            HandleError(NombreClase, sProcedure, ex)
        End Try

        Return sResultado
    End Function

End Class
