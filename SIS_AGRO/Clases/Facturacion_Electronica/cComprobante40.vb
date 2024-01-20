Option Explicit On
Imports System.Math

Friend Class cComprobante40

    Private Const NombreClase As String = "cComprobante40"

    Private xmlDoc As MSXML2.DOMDocument60

#Region "Campos auxiliares"
    'Private TipoDocumento As String
    Private tipoComprobante As TipoComprobante
    Private RutaXML As String ', RutaXMLTimbrado As String
    Public FolioCompleto As String
    Public bEvitarRecalcularUSD As Boolean
#End Region

#Region "Campos xml"
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private AnexoNodo As String
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private xmlns As String
    Private xmlnsxsi As String
    Private xsischemaLocation As String
    Private xmlnscfdi As String
    Private xmlnspago20 As String
    Private xmlnsine As String
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Version As String
    Public Serie As String
    Public Folio As String
    Public Fecha As String
    Public Sello As String
    Public FormaPago As String
    Public NoCertificado As String
    Public Certificado As String
    Public CondicionesDePago As String
    Public SubTotal As String
    Public Descuento As String
    Public Moneda As String
    Public TipoCambio As String
    Public Total As String
    Public TipoDeComprobante As String
    Public Exportacion As String
    Public MetodoPago As String
    Public LugarExpedicion As String
    Public Confirmacion As String

    Public Emisor As iEmisor40
    Public Receptor As iReceptor40
    Public Conceptos As iConceptos40
    Public Impuestos As iImpuestos40
    Public CfdiRelacionados As cCfdiRelacionados

    'Public ComplementoCCE10 As cComplementoCCE10
    Public ComplementoPagos20 As cComplementoPagos20
    Public ComplementoINE11 As cComplementoINE11

    Public XmlComplementoComercioExterior As String
#End Region

#Region "Métodos y procedimientos"
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub

    Private Sub Class_Initialize_Renamed()
        Me.Emisor = New iEmisor40
        Me.Receptor = New iReceptor40
        Me.Conceptos = New iConceptos40
        Me.Impuestos = New iImpuestos40
        Me.CfdiRelacionados = New cCfdiRelacionados
        'Me.ComplementoCCE10 = New cComplementoCCE10
        'Me.ComplementoPagos10 = New cComplementoPagos 'No se debe inicializar para que este en nothing

        Me.AnexoNodo = "cfdi:"
        Me.xmlns = "http://www.sat.gob.mx/cfd/4"
        Me.xmlnsxsi = "http://www.w3.org/2001/XMLSchema-instance"
        'Me.xsischemaLocation = "http://www.sat.gob.mx/cfd/4 http://www.sat.gob.mx/sitio_internet/cfd/4/cfdv40.xsd" 'ahora se gestiona en el ConstruyeXML
        Me.xmlnscfdi = "http://www.sat.gob.mx/cfd/4"
        Me.xmlnspago20 = "http://www.sat.gob.mx/Pagos20"
        Me.xmlnsine = "http://www.sat.gob.mx/ine"

        Me.xmlDoc = New MSXML2.DOMDocument60
    End Sub

    Public Function GeneraCFD(ByVal tipoComprobante As TipoComprobante, ByVal sRutaXML As String) As Boolean
        Const sProcedure As String = "GeneraCFD"
        Dim bResultado As Boolean = False

        Try
            'TipoDocumento = sTipoDocumento
            Me.tipoComprobante = tipoComprobante
            Me.RutaXML = sRutaXML
            'RutaXMLTimbrado = sRutaXMLTimbrado

            If Me.ConstruyeXML() = False Then
                Return False
            End If

            If Me.ValidaComprobante() = False Then
                Return False
            End If

            If Me.AgregarCertificado() = False Then
                Return False
            End If

            Me.xmlDoc.save(RutaXML)
            ConvierteXMLUTF8(RutaXML)

            If Timbrar(Me.FolioCompleto, sRutaXML, Me.tipoComprobante) = False Then
                MsgBox("No se guardó el XML en la base de datos, avíse al depto. de sistemas.", vbExclamation, sProcedure)
                Return False
            End If

            bResultado = True

            Me.xmlDoc = Nothing

        Catch ex As Exception
            HandleError(NombreClase, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ConstruyeXML() As Boolean 'Construye el documento xml con nodos
        Const sProcedure As String = "ConstruyeXML"
        Dim bResultado As Boolean = False

        Try
            Dim i As Integer, j As Integer
            Dim NodoComprobante As MSXML2.IXMLDOMElement

            xmlDoc.async = False
            xmlDoc.validateOnParse = False
            xmlDoc.resolveExternals = False
            xmlDoc.preserveWhiteSpace = True

            Dim NodoVersion As MSXML2.IXMLDOMProcessingInstruction
            NodoVersion = xmlDoc.createProcessingInstruction("xml", "version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34))

            xmlDoc.appendChild(NodoVersion)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Nodo Comprobante
            NodoComprobante = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Comprobante", xmlns)
            With NodoComprobante
                .setAttribute("xmlns:xsi", xmlnsxsi)
                .setAttribute("xmlns:cfdi", xmlnscfdi)

                Select Case Me.tipoComprobante
                    Case TipoComprobante.FACTURA_VENTA, TipoComprobante.NOTA_CREDITO_CXC, TipoComprobante.DEVOLUCION_CXC

                        If Not (Me.ComplementoINE11 Is Nothing) Then 'Si le pasó el complemento de pagos
                            Me.xsischemaLocation = "http://www.sat.gob.mx/cfd/4 http://www.sat.gob.mx/sitio_internet/cfd/4/cfdv40.xsd " &
                            "http://www.sat.gob.mx/ine http://www.sat.gob.mx/sitio_internet/cfd/ine/ine11.xsd"

                            .setAttribute("xmlns:ine", xmlnsine)
                        Else
                            Me.xsischemaLocation = "http://www.sat.gob.mx/cfd/4 http://www.sat.gob.mx/sitio_internet/cfd/4/cfdv40.xsd"
                        End If

                    Case TipoComprobante.PAGO_CXC
                        Me.xsischemaLocation = "http://www.sat.gob.mx/cfd/4 http://www.sat.gob.mx/sitio_internet/cfd/4/cfdv40.xsd " &
                                                "http://www.sat.gob.mx/Pagos20 http://www.sat.gob.mx/sitio_internet/cfd/Pagos/Pagos20.xsd"

                        .setAttribute("xmlns:pago20", xmlnspago20)

                    Case Else
                        MsgBox("No se indicó el tipo de documento.", vbInformation, sProcedure)
                End Select

                .setAttribute("xsi:schemaLocation", xsischemaLocation)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If txtLEN(Trim(Me.Version)) = True Then
                    .setAttribute("Version", Trim(Me.Version)) 'required
                Else
                    MsgBox("El valor de Comprobante.Version es un dato requerido.", vbExclamation, sProcedure) : Return False
                End If

                If txtLEN(Trim(Me.Serie)) = True Then
                    .setAttribute("Serie", Trim(Me.Serie)) 'optional
                End If

                If txtLEN(Trim(Me.Folio)) = True Then
                    .setAttribute("Folio", Trim(Me.Folio)) 'optional
                End If

                If txtLEN(Trim(Me.Fecha)) = True Then
                    .setAttribute("Fecha", Trim(Me.Fecha)) 'required
                Else
                    MsgBox("El valor de Comprobante.Fecha es un dato requerido.", vbExclamation, sProcedure) : Return False
                End If

                '    If txtLEN(Trim(Me.Sello)) = True Then
                '        .setAttribute("Sello", Trim(Me.Sello) 'required
                '    Else
                '        MsgBox ("El valor de Comprobante.Sello es un dato requerido.", vbExclamation, NombreClase): Return False
                '    End If
                .setAttribute("Sello", "") 'required , lo forzamos a vacio , mas delante se generará, debe de estar porque si se quita fallaria al no existir el atributo

                If txtLEN(Trim(Me.FormaPago)) = True Then
                    .setAttribute("FormaPago", Trim(Me.FormaPago)) 'optional
                End If

                '    If txtLEN(Trim(Me.NoCertificado)) = True Then
                '        .setAttribute("NoCertificado", Trim(Me.NoCertificado) 'required
                '    Else
                '        MsgBox ("El valor de Comprobante.NoCertificado es un dato requerido.", vbExclamation, NombreClase): Return False
                '    End If
                .setAttribute("NoCertificado", "") 'required , lo forzamos a vacio , mas delante se generará, debe de estar porque si se quita fallaria al no existir el atributo

                '    If txtLEN(Trim(Me.Certificado)) = True Then
                '        .setAttribute("Certificado", Trim(Me.Certificado) 'required
                '    Else
                '        MsgBox ("El valor de Comprobante.Certificado es un dato requerido.", vbExclamation, NombreClase): Return False
                '    End If
                .setAttribute("Certificado", "") 'required , lo forzamos a vacio , mas delante se generará, debe de estar porque si se quita fallaria al no existir el atributo

                If txtLEN(Trim(Me.CondicionesDePago)) = True Then
                    .setAttribute("CondicionesDePago", Trim(Me.CondicionesDePago)) 'optional
                End If

                If txtLEN(Trim(Me.SubTotal)) = True Then
                    .setAttribute("SubTotal", Trim(Me.SubTotal)) 'required
                Else
                    MsgBox("El valor de Comprobante.SubTotal es un dato requerido.", vbExclamation, sProcedure) : Return False
                End If

                If txtLEN(Trim(Me.Descuento)) = True Then
                    .setAttribute("Descuento", Trim(Me.Descuento)) 'optional
                End If

                If txtLEN(Trim(Me.Moneda)) = True Then
                    .setAttribute("Moneda", Trim(Me.Moneda)) 'required
                Else
                    MsgBox("El valor de Comprobante.Moneda es un dato requerido.", vbExclamation, sProcedure) : Return False
                End If

                If txtLEN(Trim(Me.TipoCambio)) = True Then
                    .setAttribute("TipoCambio", Trim(Me.TipoCambio)) 'optional
                End If

                If txtLEN(Trim(Me.Total)) = True Then
                    .setAttribute("Total", Trim(Me.Total)) 'required
                Else
                    MsgBox("El valor de Comprobante.Total es un dato requerido.", vbExclamation, sProcedure) : Return False
                End If

                If txtLEN(Trim(Me.TipoDeComprobante)) = True Then
                    .setAttribute("TipoDeComprobante", Trim(Me.TipoDeComprobante)) 'required
                Else
                    MsgBox("El valor de Comprobante.TipoDeComprobante es un dato requerido.", vbExclamation, sProcedure) : Return False
                End If

                If txtLEN(Trim(Me.Exportacion)) = True Then
                    .setAttribute("Exportacion", Trim(Me.Exportacion)) 'required
                Else
                    MsgBox("El valor de Comprobante.Exportacion es un dato requerido.", vbExclamation, sProcedure) : Return False
                End If

                If txtLEN(Trim(Me.MetodoPago)) = True Then
                    .setAttribute("MetodoPago", Trim(Me.MetodoPago)) 'optional
                End If

                If txtLEN(Trim(Me.LugarExpedicion)) = True Then
                    .setAttribute("LugarExpedicion", Trim(Me.LugarExpedicion))  'required
                Else
                    MsgBox("El valor de Comprobante.LugarExpedicion es un dato requerido.", vbExclamation, sProcedure) : Return False
                End If

                If txtLEN(Trim(Me.Confirmacion)) = True Then
                    .setAttribute("Confirmacion", Trim(Me.Confirmacion)) 'optional
                End If
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Nodo CfdiRelacionados

            If Me.CfdiRelacionados.Count > 0 Then
                Dim NodoCfdiRelacionados As MSXML2.IXMLDOMElement, NodoCfdiRelacionado As MSXML2.IXMLDOMElement
                NodoCfdiRelacionados = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "CfdiRelacionados", xmlns)

                If txtLEN(Trim(Me.CfdiRelacionados.TipoRelacion)) = True Then
                    NodoCfdiRelacionados.setAttribute("TipoRelacion", Trim(Me.CfdiRelacionados.TipoRelacion)) 'required
                Else
                    MsgBox("El valor de CfdiRelacionados.TipoRelacion es un dato requerido.", vbExclamation, sProcedure) : Return False
                End If

                For i = 1 To Me.CfdiRelacionados.Count
                    NodoCfdiRelacionado = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "CfdiRelacionado", xmlns)

                    If txtLEN(Trim(Me.CfdiRelacionados.Item(i).UUID)) = True Then
                        NodoCfdiRelacionado.setAttribute("UUID", Trim(Me.CfdiRelacionados.Item(i).UUID)) 'optional
                    End If

                    NodoCfdiRelacionados.appendChild(NodoCfdiRelacionado)
                Next

                NodoComprobante.appendChild(NodoCfdiRelacionados)
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Nodo Emisor
            Dim NodoEmisor As MSXML2.IXMLDOMElement
            NodoEmisor = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Emisor", xmlns)

            With NodoEmisor
                If txtLEN(Trim(Me.Emisor.Rfc)) = True Then
                    .setAttribute("Rfc", Me.Emisor.Rfc) 'required
                Else
                    MsgBox("El valor de Emisor.Rfc es un dato requerido.", vbExclamation, sProcedure) : Return False
                End If

                If txtLEN(Trim(Me.Emisor.Nombre)) = True Then
                    .setAttribute("Nombre", Trim(Me.Emisor.Nombre)) 'required
                Else
                    MsgBox("El valor de Emisor.Nombre es un dato requerido.", vbExclamation, sProcedure) : Return False
                End If

                If txtLEN(Trim(Me.Emisor.RegimenFiscal)) = True Then
                    .setAttribute("RegimenFiscal", Trim(Me.Emisor.RegimenFiscal)) 'required
                Else
                    MsgBox("El valor de Emisor.RegimenFiscal es un dato requerido.", vbExclamation, sProcedure) : Return False
                End If

                If txtLEN(Trim(Me.Emisor.FacAtrAdquirente)) = True Then
                    .setAttribute("FacAtrAdquirente", Trim(Me.Emisor.FacAtrAdquirente)) 'required
                End If
            End With

            NodoComprobante.appendChild(NodoEmisor)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Nodo Receptor
            Dim NodoReceptor As MSXML2.IXMLDOMElement
            NodoReceptor = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Receptor", xmlns)

            With NodoReceptor
                If txtLEN(Trim(Me.Receptor.Rfc)) = True Then
                    .setAttribute("Rfc", Trim(Me.Receptor.Rfc)) 'required
                Else
                    MsgBox("El valor de Receptor.Rfc es un dato requerido.", vbExclamation, sProcedure) : Return False
                End If

                If txtLEN(Trim(Me.Receptor.Nombre)) = True Then
                    .setAttribute("Nombre", Trim(Me.Receptor.Nombre)) 'required
                Else
                    MsgBox("El valor de Receptor.Nombre es un dato requerido.", vbExclamation, sProcedure) : Return False
                End If

                If txtLEN(Trim(Me.Receptor.DomicilioFiscalReceptor)) = True Then
                    .setAttribute("DomicilioFiscalReceptor", Trim(Me.Receptor.DomicilioFiscalReceptor)) 'required
                Else
                    MsgBox("El valor de Receptor.DomicilioFiscalReceptor es un dato requerido.", vbExclamation, sProcedure) : Return False
                End If

                If txtLEN(Trim(Me.Receptor.ResidenciaFiscal)) = True Then
                    .setAttribute("ResidenciaFiscal", Trim(Me.Receptor.ResidenciaFiscal)) 'optional
                End If

                If txtLEN(Trim(Me.Receptor.NumRegIdTrib)) = True Then
                    .setAttribute("NumRegIdTrib", Trim(Me.Receptor.NumRegIdTrib)) 'optional
                End If

                If txtLEN(Trim(Me.Receptor.RegimenFiscalReceptor)) = True Then
                    .setAttribute("RegimenFiscalReceptor", Trim(Me.Receptor.RegimenFiscalReceptor)) 'required
                Else
                    MsgBox("El valor de Receptor.RegimenFiscalReceptor es un dato requerido.", vbExclamation, sProcedure) : Return False
                End If

                If txtLEN(Trim(Me.Receptor.UsoCFDI)) = True Then
                    .setAttribute("UsoCFDI", Trim(Me.Receptor.UsoCFDI)) 'required
                Else
                    MsgBox("El valor de Receptor.UsoCFDI es un dato requerido.", vbExclamation, sProcedure) : Return False
                End If
            End With

            NodoComprobante.appendChild(NodoReceptor)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Nodo Conceptos
            Dim NodoConceptos As MSXML2.IXMLDOMElement, NodoConcepto As MSXML2.IXMLDOMElement

            NodoConceptos = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Conceptos", xmlns)

            For i = 1 To Conceptos.Count
                NodoConcepto = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Concepto", xmlns)

                With NodoConcepto

                    If txtLEN(Trim(Me.Conceptos.Item(i).ClaveProdServ)) = True Then
                        .setAttribute("ClaveProdServ", Trim(Me.Conceptos.Item(i).ClaveProdServ)) 'required
                    Else
                        MsgBox("El valor de Concepto.ClaveProdServ es un dato requerido.", vbExclamation, sProcedure) : Return False
                    End If

                    If txtLEN(Trim(Me.Conceptos.Item(i).NoIdentificacion)) = True Then
                        .setAttribute("NoIdentificacion", Trim(Me.Conceptos.Item(i).NoIdentificacion)) 'optional
                    End If

                    If txtLEN(Trim(Me.Conceptos.Item(i).Cantidad)) = True Then
                        .setAttribute("Cantidad", Trim(Me.Conceptos.Item(i).Cantidad)) 'required
                    Else
                        MsgBox("El valor de Concepto.Cantidad es un dato requerido.", vbExclamation, sProcedure) : Return False
                    End If

                    If txtLEN(Trim(Me.Conceptos.Item(i).ClaveUnidad)) = True Then
                        .setAttribute("ClaveUnidad", Trim(Me.Conceptos.Item(i).ClaveUnidad)) 'required
                    Else
                        MsgBox("El valor de Concepto.ClaveUnidad es un dato requerido.", vbExclamation, sProcedure) : Return False
                    End If

                    If txtLEN(Trim(Me.Conceptos.Item(i).Unidad)) = True Then
                        .setAttribute("Unidad", Trim(Me.Conceptos.Item(i).Unidad)) 'optional
                    End If

                    If txtLEN(Trim(Me.Conceptos.Item(i).Descripcion)) = True Then
                        .setAttribute("Descripcion", Trim(Me.Conceptos.Item(i).Descripcion)) 'required
                    Else
                        MsgBox("El valor de Concepto.Descripcion es un dato requerido.", vbExclamation, sProcedure) : Return False
                    End If

                    If txtLEN(Trim(Me.Conceptos.Item(i).ValorUnitario)) = True Then
                        .setAttribute("ValorUnitario", Trim(Me.Conceptos.Item(i).ValorUnitario)) 'required
                    Else
                        MsgBox("El valor de Concepto.ValorUnitario es un dato requerido.", vbExclamation, sProcedure) : Return False
                    End If

                    If txtLEN(Trim(Me.Conceptos.Item(i).Importe)) = True Then
                        .setAttribute("Importe", Trim(Me.Conceptos.Item(i).Importe)) 'required
                    Else
                        MsgBox("El valor de Concepto.Importe es un dato requerido.", vbExclamation, sProcedure) : Return False
                    End If

                    If txtLEN(Trim(Me.Conceptos.Item(i).Descuento)) = True Then
                        .setAttribute("Descuento", Trim(Me.Conceptos.Item(i).Descuento)) 'optional
                    End If

                    If txtLEN(Trim(Me.Conceptos.Item(i).ObjetoImp)) = True Then
                        .setAttribute("ObjetoImp", Trim(Me.Conceptos.Item(i).ObjetoImp)) 'required
                    Else
                        MsgBox("El valor de Concepto.ObjetoImp es un dato requerido.", vbExclamation, sProcedure) : Return False
                    End If

                    Dim NodoConceptoImpuestos As MSXML2.IXMLDOMElement
                    NodoConceptoImpuestos = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Impuestos", xmlns)

                    Dim NodoConceptoTraslados As MSXML2.IXMLDOMElement, NodoConceptoTraslado As MSXML2.IXMLDOMElement
                    Dim NodoConceptoRetenciones As MSXML2.IXMLDOMElement, NodoConceptoRetencion As MSXML2.IXMLDOMElement

                    If Me.Conceptos.Item(i).Traslados.Count > 0 Then
                        NodoConceptoTraslados = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Traslados", xmlns)
                        For j = 1 To Me.Conceptos.Item(i).Traslados.Count
                            NodoConceptoTraslado = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Traslado", xmlns)

                            If txtLEN(Trim(Me.Conceptos.Item(i).Traslados.Item(j).Base)) = True Then
                                NodoConceptoTraslado.setAttribute("Base", Trim(Me.Conceptos.Item(i).Traslados.Item(j).Base)) 'required
                            Else
                                MsgBox("El valor de Concepto.Impuestos.Traslados.Traslado.Base es un dato requerido.", vbExclamation, sProcedure) : Return False
                            End If

                            If txtLEN(Trim(Me.Conceptos.Item(i).Traslados.Item(j).Impuesto)) = True Then
                                NodoConceptoTraslado.setAttribute("Impuesto", Trim(Me.Conceptos.Item(i).Traslados.Item(j).Impuesto)) 'required
                            Else
                                MsgBox("El valor de Concepto.Impuestos.Traslados.Traslado.Impuesto es un dato requerido.", vbExclamation, sProcedure) : Return False
                            End If

                            If txtLEN(Trim(Me.Conceptos.Item(i).Traslados.Item(j).TipoFactor)) = True Then
                                NodoConceptoTraslado.setAttribute("TipoFactor", Trim(Me.Conceptos.Item(i).Traslados.Item(j).TipoFactor)) 'required
                            Else
                                MsgBox("El valor de Concepto.Impuestos.Traslados.Traslado.TipoFactor es un dato requerido.", vbExclamation, sProcedure) : Return False
                            End If

                            If txtLEN(Trim(Me.Conceptos.Item(i).Traslados.Item(j).TasaOCuota)) = True Then
                                NodoConceptoTraslado.setAttribute("TasaOCuota", Trim(Me.Conceptos.Item(i).Traslados.Item(j).TasaOCuota)) 'optional
                            End If

                            If txtLEN(Trim(Me.Conceptos.Item(i).Traslados.Item(j).Importe)) = True Then
                                NodoConceptoTraslado.setAttribute("Importe", Trim(Me.Conceptos.Item(i).Traslados.Item(j).Importe)) 'optional
                            End If

                            NodoConceptoTraslados.appendChild(NodoConceptoTraslado)
                        Next

                        NodoConceptoImpuestos.appendChild(NodoConceptoTraslados)
                    End If

                    If Me.Conceptos.Item(i).Retenciones.Count > 0 Then
                        NodoConceptoRetenciones = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Retenciones", xmlns)
                        For j = 1 To Me.Conceptos.Item(i).Retenciones.Count
                            NodoConceptoRetencion = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Retencion", xmlns)

                            If txtLEN(Trim(Me.Conceptos.Item(i).Retenciones.Item(j).Base)) = True Then
                                NodoConceptoRetencion.setAttribute("Base", Trim(Me.Conceptos.Item(i).Retenciones.Item(j).Base)) 'required
                            Else
                                MsgBox("El valor de Concepto.Impuestos.Retenciones.Retencion.Base es un dato requerido.", vbExclamation, sProcedure) : Return False
                            End If

                            If txtLEN(Trim(Me.Conceptos.Item(i).Retenciones.Item(j).Impuesto)) = True Then
                                NodoConceptoRetencion.setAttribute("Impuesto", Trim(Me.Conceptos.Item(i).Retenciones.Item(j).Impuesto)) 'required
                            Else
                                MsgBox("El valor de Concepto.Impuestos.Retenciones.Retencion.Impuesto es un dato requerido.", vbExclamation, sProcedure) : Return False
                            End If

                            If txtLEN(Trim(Me.Conceptos.Item(i).Retenciones.Item(j).TipoFactor)) = True Then
                                NodoConceptoRetencion.setAttribute("TipoFactor", Trim(Me.Conceptos.Item(i).Retenciones.Item(j).TipoFactor)) 'required
                            Else
                                MsgBox("El valor de Concepto.Impuestos.Retenciones.Retencion.TipoFactor es un dato requerido.", vbExclamation, sProcedure) : Return False
                            End If

                            If txtLEN(Trim(Me.Conceptos.Item(i).Retenciones.Item(j).TasaOCuota)) = True Then
                                NodoConceptoRetencion.setAttribute("TasaOCuota", Trim(Me.Conceptos.Item(i).Retenciones.Item(j).TasaOCuota)) 'required
                            Else
                                MsgBox("El valor de Concepto.Impuestos.Retenciones.Retencion.TasaOCuota es un dato requerido.", vbExclamation, sProcedure) : Return False
                            End If

                            If txtLEN(Trim(Me.Conceptos.Item(i).Retenciones.Item(j).Importe)) = True Then
                                NodoConceptoRetencion.setAttribute("Importe", Trim(Me.Conceptos.Item(i).Retenciones.Item(j).Importe)) 'required
                            Else
                                MsgBox("El valor de Concepto.Impuestos.Retenciones.Retencion.Importe es un dato requerido.", vbExclamation, sProcedure) : Return False
                            End If

                            NodoConceptoRetenciones.appendChild(NodoConceptoRetencion)
                        Next

                        NodoConceptoImpuestos.appendChild(NodoConceptoRetenciones)
                    End If

                    If NodoConceptoImpuestos.childNodes.length > 0 Then
                        NodoConcepto.appendChild(NodoConceptoImpuestos)
                    End If

                End With

                NodoConceptos.appendChild(NodoConcepto)

            Next

            NodoComprobante.appendChild(NodoConceptos)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Nodo Impuestos

            Dim NodoImpuestos As MSXML2.IXMLDOMElement
            NodoImpuestos = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Impuestos", xmlns)

            'Retenciones
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
                            MsgBox("El valor de Impuestos.Retenciones.Retencion.Impuesto es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Trim(Me.Impuestos.Retenciones.Item(i).Importe)) = True Then
                            .setAttribute("Importe", Me.Impuestos.Retenciones.Item(i).Importe) 'required
                        Else
                            MsgBox("El valor de Impuestos.Retenciones.Retencion.Importe es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If
                    End With
                    NodoRetenciones.appendChild(NodoRetencion)
                Next

                NodoImpuestos.setAttribute("TotalImpuestosRetenidos", TotalImpuestosRetenidos)

                NodoImpuestos.appendChild(NodoRetenciones)
            End If

            'Traslados
            If Me.Impuestos.Traslados.Count > 0 Then
                Dim NodoTraslados As MSXML2.IXMLDOMElement
                NodoTraslados = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Traslados", xmlns)

                Dim NodoTraslado As MSXML2.IXMLDOMElement
                For i = 1 To Me.Impuestos.Traslados.Count
                    NodoTraslado = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Traslado", xmlns)
                    With NodoTraslado
                        If txtLEN(Trim(Me.Impuestos.Traslados.Item(i).Base)) = True Then
                            .setAttribute("Base", Me.Impuestos.Traslados.Item(i).Base) 'required
                        Else
                            MsgBox("El valor de Impuestos.Traslados.Traslado.Base es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Trim(Me.Impuestos.Traslados.Item(i).Impuesto)) = True Then
                            .setAttribute("Impuesto", Me.Impuestos.Traslados.Item(i).Impuesto) 'required
                        Else
                            MsgBox("El valor de Impuestos.Traslados.Traslado.Impuesto es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Trim(Me.Impuestos.Traslados.Item(i).TipoFactor)) = True Then
                            .setAttribute("TipoFactor", Me.Impuestos.Traslados.Item(i).TipoFactor) 'required
                        Else
                            MsgBox("El valor de Impuestos.Traslados.Traslado.TipoFactor es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If Me.Impuestos.Traslados.Item(i).TipoFactor <> "Exento" Then
                            If txtLEN(Trim(Me.Impuestos.Traslados.Item(i).TasaOCuota)) = True Then
                                .setAttribute("TasaOCuota", Me.Impuestos.Traslados.Item(i).TasaOCuota) 'required
                            Else
                                MsgBox("El valor de Impuestos.Traslados.Traslado.TasaOCuota es un dato requerido.", vbExclamation, sProcedure) : Return False
                            End If

                            If txtLEN(Trim(Me.Impuestos.Traslados.Item(i).Importe)) = True Then
                                .setAttribute("Importe", Me.Impuestos.Traslados.Item(i).Importe) 'required
                            Else
                                MsgBox("El valor de Impuestos.Traslados.Traslado.Importe es un dato requerido.", vbExclamation, sProcedure) : Return False
                            End If
                        End If

                    End With
                    NodoTraslados.appendChild(NodoTraslado)
                Next

                NodoImpuestos.setAttribute("TotalImpuestosTrasladados", TotalImpuestosTrasladados)

                NodoImpuestos.appendChild(NodoTraslados)
            End If

            If NodoImpuestos.childNodes.length > 0 Then
                NodoComprobante.appendChild(NodoImpuestos)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim NodoComplemento As MSXML2.IXMLDOMElement
            NodoComplemento = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Complemento", xmlns)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Complemento de pagos
            If Not (Me.ComplementoPagos20 Is Nothing) Then 'Si le pasó el complemento de pagos
                If Me.ComplementoPagos20.GenerarNodoComplementoPagos = True Then
                    NodoComplemento.appendChild(Me.ComplementoPagos20.Complemento)
                Else
                    Return False
                End If

                'If Me.ComplementoPagos10.ComplementoGenerado = False Then
                '    MsgBox("No se pudo generar el complemento de pagos.", vbExclamation, sProcedure)
                '    Return False
                'End If
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not (Me.ComplementoINE11 Is Nothing) Then 'Si le pasó el complemento de pagos
                If Me.ComplementoINE11.GenerarNodoComplementoINE = True Then
                    NodoComplemento.appendChild(Me.ComplementoINE11.Complemento)
                Else
                    Return False
                End If
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Si hubiera mas complementos, aqui se agregarian
            'If Not (Me.ComplementoXX Is Nothing) Then
            '    NodoComplemento.appendChild Me.ComplementoXX.GenerarNodoComplementoXX
            'End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If NodoComplemento.childNodes.length > 0 Then
                NodoComprobante.appendChild(NodoComplemento)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            xmlDoc.appendChild(NodoComprobante)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Complemento cce
            If tipoComprobante = TipoComprobante.FACTURA_VENTA Then
                If txtLEN(XmlComplementoComercioExterior) = True Then
                    Dim sXmlTemp As String = Me.xmlDoc.xml
                    sXmlTemp = Replace(sXmlTemp, "</cfdi:Comprobante>", "") 'quitamos la terminación del comprobante para pegarle el completo, y al final se la volvemos a poner.

                    'Pegar el xml base con el complemento
                    sXmlTemp = sXmlTemp & "<cfdi:Complemento>" & XmlComplementoComercioExterior & "</cfdi:Complemento></cfdi:Comprobante>"

                    Me.xmlDoc.loadXML(sXmlTemp)
                End If
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'MsgBox xmlDoc.selectSingleNode("//@sello")

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

    Private Function AgregarCertificado() As Boolean
        Const sProcedure As String = "AgregarCertificado"
        Dim bResultado As Boolean = False
        Try
            Dim CKCert As New CHILKATCERTIFICATELib.ChilkatCert, dFechaServidor As Date
            Dim dFecha As Date

            CKCert.LoadFromFile(sFelectronicaArchivoCERLocal)

            dFecha = ConvierteFechaTipoXML(xmlDoc.childNodes(1).attributes.getNamedItem("Fecha").text)

            dFechaServidor = Empresa_Sistema.FechaActualServidor

            If CKCert.ValidTo < dFechaServidor Then
                MsgBox("El certificado esta caducado desde el " & Format(CKCert.ValidTo, "dd-MM-yyyy") & ".", vbExclamation, sProcedure)
                Return False
            End If

            'If CDate(Format(dFecha, "yyyy-MM-dd")) > CDate(Format(CKCert.ValidTo, "yyyy-MM-dd")) Or CDate(Format(dFecha, "yyyy-MM-dd")) < CDate(Format(CKCert.ValidFrom, "yyyy-MM-dd")) Then
            If dFecha > CKCert.ValidTo Or dFecha < CKCert.ValidFrom Then
                MsgBox("La fecha del documento no esta dentro del rango de fechas del certificado.", vbExclamation, sProcedure)
                Return False
            End If

            'Ahora si se ocupa NoCertificado para sellar(ver cadenaoriginal_3_3.xslt)
            xmlDoc.childNodes(1).attributes.getNamedItem("NoCertificado").text = GeneraNumeroCertificado(CKCert.SerialNumber)
            xmlDoc.childNodes(1).attributes.getNamedItem("Certificado").text = Mid(CKCert.GetEncoded(), 1, Len(CKCert.GetEncoded()) - 2)

            bResultado = True

        Catch ex As Exception
            HandleError(NombreClase, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidaComprobante() As Boolean
        Const sProcedure As String = "ValidaComprobante"
        Dim bResultado As Boolean = False

        Try
            Dim dSumaConceptosImportes As Double, dSumaConceptosDescuentos As Double, i As Integer, j As Integer, sMsg As String

            'Nota, las validaciones de datos requerido(obligatorios) ya se validan al ir contruyendo el xml, estas validaciones son las que harpa el proveedor pac.

            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            If ValidacionesRFC(Me.Receptor.Rfc) = False Then
                Return False
            End If
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------

            'SubTotal
            If valorNumerico(Me.SubTotal) < 0 Then
                MsgBox("SubTotal : No se permiten valores negativos.", vbExclamation, sProcedure) : Return False
            End If

            For i = 1 To Me.Conceptos.Count
                dSumaConceptosImportes = dSumaConceptosImportes + valorNumerico(Conceptos.Item(i).Importe)
                dSumaConceptosDescuentos = dSumaConceptosDescuentos + valorNumerico(Conceptos.Item(i).Descuento)
            Next
            dSumaConceptosImportes = Redondear(dSumaConceptosImportes, 2)
            dSumaConceptosDescuentos = Redondear(dSumaConceptosDescuentos, 2)

            If Me.TipoDeComprobante = "I" Or Me.TipoDeComprobante = "E" Or Me.TipoDeComprobante = "N" Then
                'If dSumaConceptosImportes <> valorNumerico(Me.subTotal) Then
                If Abs(dSumaConceptosImportes - valorNumerico(Me.SubTotal)) > 0.020001 Then
                    MsgBox("SubTotal: Cuando el TipoDeComprobante sea I, E o N, el importe registrado en el atributo debe ser igual a la suma de los importes de los conceptos registrados." &
                    vbCrLf & "SumaImportes=" & dSumaConceptosImportes & vbCrLf & "Subtotal=" & Me.SubTotal, vbExclamation, sProcedure) : Return False
                End If
            End If

            If Me.TipoDeComprobante = "T" Or Me.TipoDeComprobante = "P" Then
                If valorNumerico(Me.SubTotal) <> 0 Then
                    MsgBox("SubTotal : Cuando el TipoDeComprobante sea T o P el importe registrado en el atributo debe ser igual a cero.", vbExclamation, sProcedure) : Return False
                End If
            End If
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Descuento
            If valorNumerico(Me.Descuento) < 0 Then
                MsgBox("Descuento : No se permiten valores negativos.", vbExclamation, sProcedure) : Return False
            End If

            If valorNumerico(Me.Descuento) > 0 Then
                If Not (valorNumerico(Me.Descuento) <= valorNumerico(Me.SubTotal)) Then
                    MsgBox("Descuento : El valor registrado debe ser menor o igual que el atributo Subtotal.", vbExclamation, sProcedure) : Return False
                End If
            End If

            If Me.TipoDeComprobante = "I" Or Me.TipoDeComprobante = "E" Or Me.TipoDeComprobante = "N" Then
                If valorNumerico(Me.Descuento) <> dSumaConceptosDescuentos Then
                    MsgBox("Descuento : debe ser igual a la suma de los atributos Descuento registrados en los conceptos.", vbExclamation, sProcedure) : Return False
                End If
            Else
                If txtLEN(Me.Descuento) = True Then
                    MsgBox("Descuento : Cuando el TipoDeComprobante sea I, E o N y algún concepto incluya el atributo Descuento, debe existir este atributo y debe ser igual a la suma " &
                    "de los atributos Descuento registrados en los conceptos; en otro caso se debe omitir este atributo.", vbExclamation, sProcedure) : Return False
                End If
            End If
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Moneda

            If Not (Me.Moneda = "MXN" Or Me.Moneda = "XXX") Then
                If valorNumerico(Me.TipoCambio) <= 0 Then
                    MsgBox("Moneda : Si es diferente de MXN o XXX, debe existir el tipo de cambio.", vbExclamation, sProcedure) : Return False
                End If
            Else
                If Me.Moneda = "XXX" And txtLEN(Me.TipoCambio) = True Then
                    MsgBox("Moneda : Si es XXX no debe existir el tipo de cambio.", vbExclamation, sProcedure) : Return False
                ElseIf Me.Moneda = "MXN" Then
                    If valorNumerico(Me.TipoCambio) > 1 Then
                        MsgBox("Moneda : si es MXN puede omitirse el atributo TipoCambio y si se incluye debe tener el valor ""1"".", vbExclamation, sProcedure) : Return False
                    End If
                End If
            End If
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Total
            If valorNumerico(Me.Total) < 0 Then
                MsgBox("Total : No se permiten valores negativos.", vbExclamation, sProcedure) : Return False
            End If

            If Me.TipoDeComprobante = "T" Or Me.TipoDeComprobante = "P" Then
                If valorNumerico(Me.Total) <> 0 Then
                    MsgBox("Total : Cuando el TipoDeComprobante sea T o P, el importe registrado en el atributo debe ser igual a cero.", vbExclamation, sProcedure) : Return False
                End If
            End If

            Dim dDiferencia As Decimal = Me.Total - (valorNumerico(Me.SubTotal) - valorNumerico(Me.Descuento) + valorNumerico(TotalImpuestosTrasladados) - valorNumerico(TotalImpuestosRetenidos))

            If Abs(dDiferencia) > 0.010001 Then
                MsgBox("Total: El valor del atributo debe ser igual al subtotal menos descuentos más las contribuciones recibidas " &
                    "(impuestos trasladados - federales o locales, derechos, productos, aprovechamientos, aportaciones de seguridad social, contribuciones de mejoras) " &
                    "menos los impuestos retenidos." & vbCrLf &
                    "+SubTotal " & Me.SubTotal & vbCrLf & "-Descuento " & Me.Descuento & vbCrLf & "+TotalImpuestosTrasladados " & TotalImpuestosTrasladados() & vbCrLf & "-TotalImpuestosRetenidos " & TotalImpuestosRetenidos() & vbCrLf &
                    "Total " & Me.Total & vbCrLf & "Diferencia=" & dDiferencia, vbExclamation, sProcedure) : Return False
                Return False
            End If
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            'TipoDeComprobante
            If Me.TipoDeComprobante = "T" Or Me.TipoDeComprobante = "P" Or Me.TipoDeComprobante = "N" Then
                If txtLEN(Me.CondicionesDePago) = True Then
                    MsgBox("TipoDeComprobante: Se debe omitir el atributo CondicionesDePago cuando el TipoDeComprobante es T, P o N.", vbExclamation, sProcedure) : Return False
                End If

                If Me.Impuestos.Retenciones.Count > 0 Or Me.Impuestos.Traslados.Count > 0 Then
                    MsgBox("TipoDeComprobante: Se debe omitir el elemento Impuestos cuando el TipoDeComprobante es T, P o N.", vbExclamation, sProcedure) : Return False
                End If

            End If

            If Me.TipoDeComprobante = "T" Or Me.TipoDeComprobante = "P" Then
                If dSumaConceptosDescuentos <> 0 Then
                    MsgBox("TipoDeComprobante: Se debe omitir el atributo Descuento de los conceptos cuando el TipoDeComprobante es T o P.", vbExclamation, sProcedure) : Return False
                End If

                If txtLEN(Me.FormaPago) = True Then
                    MsgBox("TipoDeComprobante: Se debe omitir los atributos FormaPago y MetodoPago cuando el TipoDeComprobante es T o P.", vbExclamation, sProcedure) : Return False
                End If

                If txtLEN(Me.MetodoPago) = True Then
                    MsgBox("TipoDeComprobante: Se debe omitir los atributos FormaPago y MetodoPago cuando el TipoDeComprobante es T o P.", vbExclamation, sProcedure) : Return False
                End If
            End If
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Exportacion
            If Me.Exportacion = "02" Then
                If txtLEN(XmlComplementoComercioExterior) = False Then
                    MsgBox("Exportacion: Si es 02 debe existir el Complemento para Comercio Exterior.", vbExclamation, sProcedure) : Return False
                End If
            End If
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------
            'FormaPago
            If Me.FormaPago <> "99" Then
                If Me.MetodoPago = "PPD" Then
                    MsgBox("FormaPago: Debe ser 99 cuando el atributo MetodoPago=PPD.", vbExclamation, sProcedure) : Return False
                End If
            End If
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------
            'MetodoPago
            If Not (Me.ComplementoPagos20 Is Nothing) Then 'Si le pasó el complemento de pagos
                If Me.ComplementoPagos20.ComplementoGenerado = True Then
                    If txtLEN(Me.MetodoPago) = True Then
                        MsgBox("MetodoPago: Si existe el complemento para recepción de pagos en este CFDI este atributo no debe existir.", vbExclamation, sProcedure) : Return False
                    End If
                End If
            End If
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Omitidas para que ese proceso lo lleve el proveedor de timbre, son mas complejas de validar para nosotros
            'LugarExpedicion, Debe corresponder con una clave de código postal incluida en el catálogo publicado en la página del SAT.
            'Confirmacion, Si los atributos TipoCambio y Total están dentro del rango válido, no debe existir este atributo.
            'El Proveedor de Certificación debe verificar que el emisor le haya solicitado esta clave de confirmación y que no se utilice en más de un comprobante.
            'El Proveedor de Certificación debe enviar una notificación al emisor de que ya se utilizó esta clave de confirmación.

            'Aunque esta si se pudiera validar la omitimos porque hay que tener en memoria el catálogo de regímenes en memoria como los médotos/formas de pago para validar.
            'Emisor.RegimenFiscal, El régimen fiscal que se registre en este atributo debe corresponder con el tipo de persona del emisor, es decir, si el RFC tiene longitud de 12 posiciones,
            'debe ser de persona moral y si tiene longitud de 13 posiciones debe ser de persona física.

            'Receptor.Rfc, Cuando no se utilice un RFC genérico, el RFC debe estar en la lista de RFC inscritos no cancelados en el SAT.
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Emisor
            'Falta validar lo de que si Emisor.RFC es 12 o 13 el Emisor.RegimenFiscal debe ser aplicable según el tipo de persona.
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------
            If Receptor.Rfc = "XAXX010101000" Or Receptor.Rfc = "XEXX010101000" Then
                If Receptor.DomicilioFiscalReceptor <> Me.LugarExpedicion Then
                    MsgBox("Receptor.DomicilioFiscalReceptor: Si el RFC del receptor es XAXX010101000 o XEXX010101000 este atributo debe ser igual al valor del atributo Comprobante.LugarExpedicion.", vbExclamation, sProcedure) : Return False
                End If

                If Receptor.RegimenFiscalReceptor <> "616" Then
                    MsgBox("Receptor.RegimenFiscalReceptor: Si el RFC del receptor es XAXX010101000 o XEXX010101000 en este atributo se debe registrar la clave 616.", vbExclamation, sProcedure) : Return False
                End If
            End If
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Receptor.ResidenciaFiscal
            If Me.Receptor.Rfc <> Empresa_Sistema.RFC_EXTRANJERO Then
                If txtLEN(Me.Receptor.ResidenciaFiscal) = True Then
                    MsgBox("Receptor.ResidenciaFiscal: Si el RFC del receptor es de un RFC registrado en el SAT o un RFC genérico nacional, no se debe registrar este atributo.",
                           vbExclamation, sProcedure) : Return False
                End If
            Else 'Si es extranjero
                If txtLEN(XmlComplementoComercioExterior) = True Or txtLEN(Me.Receptor.NumRegIdTrib) = True Then
                    'If (Not (Me.ComplementoCCE10 Is Nothing) AndAlso txtLEN(Me.ComplementoCCE10.CadenaComplementoExterior) = True) Or txtLEN(Me.Receptor.NumRegIdTrib) = True Then
                    If Not (txtLEN(Me.Receptor.ResidenciaFiscal) = True And Me.Receptor.ResidenciaFiscal <> "MEX") Then
                        MsgBox("Receptor.ResidenciaFiscal: " &
                                "Si el RFC del receptor es un RFC genérico extranjero y el comprobante incluye el complemento de comercio exterior, o se registró el atributo NumRegIdTrib," &
                                "este atributo debe existir y la clave debe ser distinta de MEX; en otro caso puede omitirse.", vbExclamation, sProcedure) : Return False
                    End If
                End If
            End If
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Omitidas
            'Receptor.NumRegIdTrib
            'Si el valor del atributo es un RFC inscrito no cancelado en el SAT o un RFC genérico nacional, no se debe registrar este atributo. Si no existe el atributo ResidenciaFiscal, este atributo puede omitirse.

            If Me.Receptor.Rfc = Empresa_Sistema.RFC_EXTRANJERO And txtLEN(XmlComplementoComercioExterior) = True Then
                If txtLEN(Me.Receptor.NumRegIdTrib) = False Then
                    MsgBox("Receptor.NumRegIdTrib: Si el RFC del receptor es un RFC genérico extranjero y el comprobante incluye el complemento de comercio exterior, " &
                            "el atributo debe existir.", vbExclamation, sProcedure) : Return False
                End If
            End If

            If Me.Receptor.Nombre = "PUBLICO EN GENERAL" Then
                If Receptor.Rfc <> "XAXX010101000" Then
                    MsgBox("Receptor.Nombre: Si el valor registrado es PUBLICO EN GENERAL el valor XAXX010101000 debe existir en Receptor.RFC", vbExclamation, sProcedure) : Return False
                End If
            End If

            'Falta validar lo de que si Receptor.RFC es 12 o 13 el Receptor.RegimenFiscal debe ser aplicable según el tipo de persona.

            'Omitidas
            'Si el atributo ResidenciaFiscal corresponde a una clave de pais incluida en el catalogo c_Pais publicado en la pagina del SAT, se deben verificar las columnas correspondientes a dicha clave:
            'Si tiene mecanismo de verificacion en linea incluido en la columna "Validacion del Registro de Identidad Tributaria" del mismo catalogo de c_Pais, debe existir en el registro del pais.
            'Si no tiene mecanismo de verificacion en linea, debe cumplir con el patron correspondiente incluido en la columna "Formato de Registro de Identidad Tributaria" que se publique en el mismo catalogo c_Pais.
            'En otro caso no se aplica esta validacion.
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------
            'UsoCFDI
            sMsg = "Receptor.UsoCFDI: El valor que se registre en este atributo debe aplicar para el tipo de persona del receptor, es decir, si el RFC tiene longitud de 12 posiciones, debe ser de persona moral y si tiene longitud de 13 posiciones debe ser de persona física."

            'Se busca en físicas porque estas tienen todos los elementos(aunque el cte sea persona moral)
            Dim dRow() As DataRow = dtUsosCFDIPersonasFisicas.Select("CODIGO_USO_CFDI='" & Me.Receptor.UsoCFDI & "'")
            If dRow.Length = 0 Then
                MsgBox("No se encontró en memoria el uso CFDI " & Me.Receptor.UsoCFDI & " .", vbExclamation, sProcedure)
                Exit Function
            End If

            Select Case Len(Me.Receptor.Rfc)
                Case 12 'Moral
                    'If dtUsosCFDI.Item(Me.Receptor.UsoCFDI).APLICA_TIPO_MORAL = False Then
                    If CBool(dRow(0)("APLICA_TIPO_MORAL").ToString) = False Then
                        MsgBox(sMsg, vbExclamation, sProcedure) : Return False
                    End If
                Case 13 'Física
                    'If dtUsosCFDI.Item(Me.Receptor.UsoCFDI).APLICA_TIPO_FISICA = False Then
                    If CBool(dRow(0)("APLICA_TIPO_FISICA").ToString) = False Then
                        MsgBox(sMsg, vbExclamation, sProcedure) : Return False
                    End If
            End Select

            '----------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Conceptos.Concepto: varias omitidas ClaveProdServ,ValorUnitario,Importe

            For i = 1 To Me.Conceptos.Count
                'Descuento
                If Not (valorNumerico(Me.Conceptos.Item(i).Descuento) <= valorNumerico(Me.Conceptos.Item(i).Importe)) Then
                    MsgBox("Comprobante.Conceptos.Descuento: El valor registrado debe ser menor o igual al atributo Importe." & vbCrLf &
                            "NoIdentificacion=" & Me.Conceptos.Item(i).NoIdentificacion & " Descripcion=" & Me.Conceptos.Item(i).Descripcion &
                            " Importe=" & Me.Conceptos.Item(i).Importe & " Descuento=" & Me.Conceptos.Item(i).Descuento, vbExclamation, sProcedure) : Return False
                End If

                'Impuestos
                'Base,falta El valor de este atributo debe tener hasta la cantidad de decimales que soporte la moneda.
                For j = 1 To Me.Conceptos.Item(i).Traslados.Count
                    'Base
                    If valorNumerico(Me.Conceptos.Item(i).Traslados.Item(j).Base) <= 0 Then
                        MsgBox("Conceptos.Traslados.Base: Debe ser mayor que cero.", vbExclamation, sProcedure) : Return False
                    End If

                    'TipoFactor
                    If Me.Conceptos.Item(i).Traslados.Item(j).TipoFactor = "Exento" Then
                        If txtLEN(Me.Conceptos.Item(i).Traslados.Item(j).TasaOCuota) = True Or txtLEN(Me.Conceptos.Item(i).Traslados.Item(j).Importe) = True Then
                            MsgBox("Conceptos.Traslados.TipoFactor: Si el valor registrado es Exento no se deben registrar los atributos TasaOCuota ni Importe.", vbExclamation, sProcedure) : Return False
                        End If
                    End If

                    If Me.Conceptos.Item(i).Traslados.Item(j).TipoFactor = "Tasa" Or Me.Conceptos.Item(i).Traslados.Item(j).TipoFactor = "Cuota" Then
                        If Not (txtLEN(Me.Conceptos.Item(i).Traslados.Item(j).TasaOCuota) = True And txtLEN(Me.Conceptos.Item(i).Traslados.Item(j).Importe)) = True Then
                            MsgBox("Conceptos.Traslados.TipoFactor: Si el valor registrado es Tasa o Cuota, se deben registrar los atributos TasaOCuota e Importe.", vbExclamation, sProcedure) : Return False
                        End If
                    End If

                Next

                'Impuesto,falta, Deben existir los campos para sumarizar el total de impuestos trasladados y el detalle de impuestos trasladados. ? no entendí
                'TasaOCuota,faltan
                'Importe,faltan

            Next
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Conceptos.Concepto.Impuestos

            '----------------------------------------------------------------------------------------------------------------------------------------------------------------
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------
            'MsgBox ("falta mas validaciones tomadas del pdf cfdv33_dof.pdf , quedé en página 66"

            '----------------------------------------------------------------------------------------------------------------------------------------------------------------

            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------

            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------

            bResultado = True

        Catch ex As Exception
            HandleError(NombreClase, sProcedure, ex)
        End Try

        Return bResultado
    End Function

#End Region

End Class
