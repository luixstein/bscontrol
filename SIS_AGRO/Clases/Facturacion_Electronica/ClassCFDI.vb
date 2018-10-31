Option Strict On

Imports System.Xml
Imports ThoughtWorks.QRCode.Codec
Imports System.IO
Imports System.Text.RegularExpressions

Public Class ClassCFDI
    Public ComplementoTFD As clsComplementoTimbreFiscalDigital
    Public Comprobante As clsComprobante
    Public Emisor As ComprobanteEmisor
    Public Receptor As ComprobanteReceptor
    Public Impuestos As ComprobanteImpuestos
    Public ImpuestosLocales As ComprobanteImpuestosLocales
    Public ImpuestosAerolineas As ComprobanteImpuestosAerolineas
    Public sError As String = ""

    Private _XMLConDeclaracion As String = ""
    Private _XMLSinDeclaracion As String = ""

    Private xmlDoc As XmlDocument
    Private _XMLCargado As Boolean = False
    Private _TipoCFD As String = ""

#Region "Propiedades"
    Public ReadOnly Property NombreClase() As String
        Get
            NombreClase = "ClassCFDI"
        End Get
    End Property

    Public ReadOnly Property TipoCFD As String
        Get
            Return Me._TipoCFD
        End Get
    End Property

    Public ReadOnly Property XMLCargado() As Boolean
        Get
            Return Me._XMLCargado
        End Get
    End Property

    Public ReadOnly Property XMLConDeclaracion() As String
        Get
            Return Me._XMLConDeclaracion
        End Get
    End Property

    Public ReadOnly Property XMLSinDeclaracion() As String
        Get
            Return Me._XMLSinDeclaracion
        End Get
    End Property
#End Region

#Region "Constructor y destructor"
    Public Sub New()

    End Sub

    Public Sub New(ByVal sXML As String, ByVal bEsRuta As Boolean)
        Try
            xmlDoc = New XmlDocument

            ComplementoTFD = New clsComplementoTimbreFiscalDigital
            Comprobante = New clsComprobante
            Emisor = New ComprobanteEmisor
            Receptor = New ComprobanteReceptor
            Impuestos = New ComprobanteImpuestos
            ImpuestosLocales = New ComprobanteImpuestosLocales
            ImpuestosAerolineas = New ComprobanteImpuestosAerolineas

            If bEsRuta = True Then
                Dim sr As StreamReader = New StreamReader(sXML)
                Dim sCadenaXML As String

                sCadenaXML = sr.ReadToEnd
                sr.Close()

                'Revisa si el xml empieza con , ejemplo ?<?xml version="1.0" encoding="utf-8"?>, de modo que el primer ?, esta demás, necesitamos quitarlo.
                If InStr(sCadenaXML, "<?xml") - 1 > 0 Then
                    sCadenaXML = sCadenaXML.Substring(InStr(sCadenaXML, "<?xml") - 1) 'Removemos en ? que está de demás.
                    xmlDoc.LoadXml(sCadenaXML) 'Leemos el xml como cadena con el signo removido
                Else
                    xmlDoc.Load(sXML) 'Leemos el archivo directo de la ruta
                End If
            Else
                xmlDoc.LoadXml(sXML) 'Leemos el xml como cadena
            End If

            '------------------------------------------------------------------------------
            'Método 1 para quitar comentarios usando expresiones regulares
            Dim pattern As String = String.Empty
            pattern = "(<!--.*?--\>)"
            xmlDoc.InnerXml = Regex.Replace(xmlDoc.InnerXml, pattern, String.Empty, RegexOptions.Singleline)
            '------------------------------------------------------------------------------
            'Método 2(implica grabar el archivo en físico.
            'Dim sRutaTemp As String = Path.GetTempFileName
            'xmlDoc.Save(sRutaTemp)
            'Dim readerSettings As New XmlReaderSettings()
            'readerSettings.IgnoreComments = True
            'Dim reader As XmlReader
            'reader = XmlReader.Create(sRutaTemp, readerSettings)
            'xmlDoc.Load(reader)
            'reader.Close()
            'File.Delete(sRutaTemp)
            '------------------------------------------------------------------------------

            If xmlDoc.FirstChild.NodeType = XmlNodeType.XmlDeclaration Then
                xmlDoc.RemoveChild(xmlDoc.FirstChild)
            End If
            Me._XMLSinDeclaracion = xmlDoc.InnerXml

            'Crea el nodo principal o primera linea <?xml version="1.0"?>
            Dim Nodo As Xml.XmlDeclaration
            Nodo = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", Nothing)
            'Agrega el nodo al documento
            Dim root As Xml.XmlElement = xmlDoc.DocumentElement
            xmlDoc.InsertBefore(Nodo, root)

            Me._XMLConDeclaracion = xmlDoc.InnerXml

            Dim sVersion As String = "", sTAG As String = "", sTagTFD As String = "", sTagImpLocal As String = "", sTagAerolineas As String = ""

            If IsNothing(xmlDoc.Item("cfdi:Comprobante").Attributes("version")) = False Then
                sVersion = xmlDoc.Item("cfdi:Comprobante").Attributes("version").Value
            Else
                sVersion = xmlDoc.Item("cfdi:Comprobante").Attributes("Version").Value
            End If

            sTAG = "cfdi:"
            sTagTFD = "tfd:"
            sTagImpLocal = "implocal:"
            sTagAerolineas = "aerolineas:"
            Me._TipoCFD = "CFDI"

            If txtLEN(sVersion) = False Then
                'Es posible que sea un xml 3.2 , pero sin las etiquetas cfdi: dentro del(ha pasado en algunos casos)
                If IsNothing(xmlDoc.Item("Comprobante").Attributes("version")) = False Then
                    sVersion = xmlDoc.Item("Comprobante").Attributes("version").Value.ToString

                    sTAG = ""
                    sTagTFD = ""
                    sTagImpLocal = ""
                    sTagAerolineas = ""
                    Me._TipoCFD = "CFD"
                End If
            End If

            'Se desconoce para que se usó este código. 06jul17,jorgegc le preguntó a fernando y no sabe.
            'Try
            '    sVersion = xmlDoc.DocumentElement.Name
            '    If sVersion.ToUpper = "ACUSE" Then
            '        Me._TipoCFD = "ACUSE"
            '        Exit Sub
            '    Else
            '        sError = "El XML no tiene la versión del cfdi/cfd."
            '        Exit Sub
            '    End If
            'Catch ex3 As Exception
            '    sError = "El XML no tiene la versión del cfdi/cfd."
            '    Exit Sub
            'End Try

            If txtLEN(sVersion) = False Then
                sError = "No se encontró la versión del XML."
                Throw New System.Exception(sError)
            End If

            Select Case sVersion
                Case "3.2"
                    'Continua
                Case "3.3"
                    'Continua
                Case Else
                    sError = "Versión : " & sVersion & " del XML no soportada."
                    Throw New System.Exception(sError)
            End Select

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If TieneValorXML(xmlDoc.Item(sTAG & "Comprobante").Item(sTAG & "Complemento")) = False OrElse
                TieneValorXML(xmlDoc.Item(sTAG & "Comprobante").Item(sTAG & "Complemento").Item(sTagTFD & "TimbreFiscalDigital")) = False Then
                sError = "El XML no esta timbrado."
                Throw New System.Exception(sError)
            End If

            'this.sVersion = this.XmlDoc.GetElementsByTagName("cfdi:Comprobante").Item(0).Attributes.GetNamedItem("version").Value

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim NodoComprobante As XmlNode = xmlDoc.Item(sTAG & "Comprobante")

            Select Case sVersion
                Case "3.2"
                    With NodoComprobante
                        Me.Comprobante.version = LeeValorXML(.Attributes("version"))
                        Me.Comprobante.serie = LeeValorXML(.Attributes("serie"))
                        Me.Comprobante.folio = LeeValorXML(.Attributes("folio"))
                        Me.Comprobante.fecha = CDate(LeeValorXML(.Attributes("fecha")))
                        Me.Comprobante.sello = LeeValorXML(.Attributes("sello"))
                        Me.Comprobante.formaDePago = LeeValorXML(.Attributes("formaDePago"))
                        Me.Comprobante.noCertificado = LeeValorXML(.Attributes("noCertificado"))
                        Me.Comprobante.certificado = LeeValorXML(.Attributes("certificado"))
                        Me.Comprobante.condicionesDePago = LeeValorXML(.Attributes("condicionesDePago"))
                        Me.Comprobante.subTotal = valorNumerico(LeeValorXML(.Attributes("subTotal")))
                        Me.Comprobante.descuento = valorNumerico(LeeValorXML(.Attributes("descuento")))
                        Me.Comprobante.motivoDescuento = LeeValorXML(.Attributes("motivoDescuento"))
                        Me.Comprobante.TipoCambio = LeeValorXML(.Attributes("TipoCambio"))
                        Me.Comprobante.Moneda = LeeValorXML(.Attributes("Moneda"))
                        Me.Comprobante.total = valorNumerico(LeeValorXML(.Attributes("total")))
                        Me.Comprobante.tipoDeComprobante = LeeValorXML(.Attributes("tipoDeComprobante"))
                        Me.Comprobante.metodoDePago = LeeValorXML(.Attributes("metodoDePago"))
                        Me.Comprobante.LugarExpedicion = LeeValorXML(.Attributes("LugarExpedicion"))
                        Me.Comprobante.NumCtaPago = LeeValorXML(.Attributes("NumCtaPago"))
                    End With

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim NodoEmisor As XmlNode = xmlDoc.Item(sTAG & "Comprobante").Item(sTAG & "Emisor")
                    Dim NodoEmisorDomicilioFiscal As XmlNode = NodoEmisor.Item(sTAG & "DomicilioFiscal")
                    Dim NodoEmisorExpedidoEn As XmlNode = NodoEmisor.Item(sTAG & "EmisorExpedidoEn")
                    Dim NodoEmisorRegimenFiscal As XmlNode = NodoEmisor.Item(sTAG & "RegimenFiscal")
                    With NodoEmisor
                        Me.Emisor.rfc = LeeValorXML(.Attributes("rfc"))
                        Me.Emisor.nombre = LeeValorXML(.Attributes("nombre"))
                    End With
                    If TieneValorXML(NodoEmisorDomicilioFiscal) = True Then
                        With NodoEmisorDomicilioFiscal
                            Me.Emisor.DomicilioFiscal.calle = LeeValorXML(.Attributes("calle"))
                            Me.Emisor.DomicilioFiscal.noExterior = LeeValorXML(.Attributes("noExterior"))
                            Me.Emisor.DomicilioFiscal.noInterior = LeeValorXML(.Attributes("noInterior"))
                            Me.Emisor.DomicilioFiscal.colonia = LeeValorXML(.Attributes("colonia"))
                            Me.Emisor.DomicilioFiscal.localidad = LeeValorXML(.Attributes("localidad"))
                            Me.Emisor.DomicilioFiscal.referencia = LeeValorXML(.Attributes("referencia"))
                            Me.Emisor.DomicilioFiscal.municipio = LeeValorXML(.Attributes("municipio"))
                            Me.Emisor.DomicilioFiscal.estado = LeeValorXML(.Attributes("estado"))
                            Me.Emisor.DomicilioFiscal.pais = LeeValorXML(.Attributes("pais"))
                            Me.Emisor.DomicilioFiscal.codigoPostal = LeeValorXML(.Attributes("codigoPostal"))
                        End With
                    End If

                    If TieneValorXML(NodoEmisorExpedidoEn) = True Then
                        With NodoEmisorExpedidoEn
                            Me.Emisor.ExpedidoEn.calle = LeeValorXML(.Attributes("calle"))
                            Me.Emisor.ExpedidoEn.noExterior = LeeValorXML(.Attributes("noExterior"))
                            Me.Emisor.ExpedidoEn.noInterior = LeeValorXML(.Attributes("noInterior"))
                            Me.Emisor.ExpedidoEn.colonia = LeeValorXML(.Attributes("colonia"))
                            Me.Emisor.ExpedidoEn.localidad = LeeValorXML(.Attributes("localidad"))
                            Me.Emisor.ExpedidoEn.referencia = LeeValorXML(.Attributes("referencia"))
                            Me.Emisor.ExpedidoEn.municipio = LeeValorXML(.Attributes("municipio"))
                            Me.Emisor.ExpedidoEn.estado = LeeValorXML(.Attributes("estado"))
                            Me.Emisor.ExpedidoEn.pais = LeeValorXML(.Attributes("pais"))
                            Me.Emisor.ExpedidoEn.codigoPostal = LeeValorXML(.Attributes("codigoPostal"))
                        End With
                    End If
                    If TieneValorXML(NodoEmisorRegimenFiscal) = True Then
                        With NodoEmisorRegimenFiscal
                            Me.Emisor.RegimenFiscal.Regimen = LeeValorXML(.Attributes("Regimen"))
                        End With
                    Else
                        NodoEmisorRegimenFiscal = NodoEmisor.Item("RegimenFiscal")
                        If TieneValorXML(NodoEmisorRegimenFiscal) = True Then
                            Throw New Exception("El XML tiene RegimenFiscal sin etiqueta cfdi:.")
                        Else
                            Throw New Exception("El XML no trae el nodo cfdi:RegimenFiscal.")
                        End If
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim NodoReceptor As XmlNode = xmlDoc.Item(sTAG & "Comprobante").Item(sTAG & "Receptor")
                    Dim NodoReceptorDomicilio As XmlNode = NodoReceptor.Item(sTAG & "Domicilio")
                    With NodoReceptor
                        Me.Receptor.rfc = LeeValorXML(.Attributes("rfc"))
                        Me.Receptor.nombre = LeeValorXML(.Attributes("nombre"))
                    End With

                    If TieneValorXML(NodoReceptor.Item(sTAG & "Domicilio")) = True Then
                        With NodoReceptorDomicilio
                            Me.Receptor.Domicilio.calle = LeeValorXML(.Attributes("calle"))
                            Me.Receptor.Domicilio.noExterior = LeeValorXML(.Attributes("noExterior"))
                            Me.Receptor.Domicilio.noInterior = LeeValorXML(.Attributes("noInterior"))
                            Me.Receptor.Domicilio.colonia = LeeValorXML(.Attributes("colonia"))
                            Me.Receptor.Domicilio.localidad = LeeValorXML(.Attributes("localidad"))
                            Me.Receptor.Domicilio.referencia = LeeValorXML(.Attributes("referencia"))
                            Me.Receptor.Domicilio.municipio = LeeValorXML(.Attributes("municipio"))
                            Me.Receptor.Domicilio.estado = LeeValorXML(.Attributes("estado"))
                            Me.Receptor.Domicilio.pais = LeeValorXML(.Attributes("pais"))
                            Me.Receptor.Domicilio.codigoPostal = LeeValorXML(.Attributes("codigoPostal"))
                        End With
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim NodoComplemento As XmlNode = xmlDoc.Item(sTAG & "Comprobante").Item(sTAG & "Complemento").Item(sTagTFD & "TimbreFiscalDigital")
                    With NodoComplemento
                        Me.ComplementoTFD.UUID = LeeValorXML(.Attributes("UUID"))
                        Me.ComplementoTFD.FechaTimbrado = LeeValorXML(.Attributes("FechaTimbrado"))
                        Me.ComplementoTFD.SelloCFD = LeeValorXML(.Attributes("selloCFD"))
                        Me.ComplementoTFD.NoCertificadoSAT = LeeValorXML(.Attributes("noCertificadoSAT"))
                        Me.ComplementoTFD.SelloSAT = LeeValorXML(.Attributes("selloSAT"))
                    End With

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim NodoImpuestos As XmlNode = xmlDoc.Item(sTAG & "Comprobante").Item(sTAG & "Impuestos")
                    Dim Retenciones As New List(Of ComprobanteImpuestosRetencion)
                    Dim Traslados As New List(Of ComprobanteImpuestosTraslado)

                    If TieneValorXML(NodoImpuestos) = True Then
                        With NodoImpuestos
                            Me.Impuestos.totalImpuestosRetenidos = valorNumerico(LeeValorXML(.Attributes("totalImpuestosRetenidos")))
                            Me.Impuestos.totalImpuestosTrasladados = valorNumerico(LeeValorXML(.Attributes("totalImpuestosTrasladados")))

                            If TieneValorXML(.Item(sTAG & "Traslados")) = True Then
                                For Each x As XmlNode In .Item(sTAG & "Traslados").ChildNodes
                                    Traslados.Add(New ComprobanteImpuestosTraslado With {.impuesto = LeeValorXML(x.Attributes("impuesto")),
                                                                                         .importe = CDbl(LeeValorXML(x.Attributes("importe"))),
                                                                                         .tasa = CDbl(LeeValorXML(x.Attributes("tasa")))})
                                Next
                            End If
                            'VALIDAR QUE SI LOS TOTALES DE IMPUESTOS ESTAN EN CEROS, PERO SI TIENE LOS NODOS DE TRASLADOS
                            'SI ES ASI MANDAR MSGBOX DICIENDO QUE ESTA MAL CALCULADO LOS NODOS DEL IVA

                            'If Traslados.Count > 0 Then
                            Me.Impuestos.Traslados = Traslados.ToArray
                            'End If

                            If TieneValorXML(.Item(sTAG & "Retenciones")) Then
                                For Each x As XmlNode In .Item(sTAG & "Retenciones").ChildNodes
                                    Retenciones.Add(New ComprobanteImpuestosRetencion With {.impuesto = LeeValorXML(x.Attributes("impuesto")),
                                                                                         .importe = CDbl(LeeValorXML(x.Attributes("importe")))})
                                Next
                            End If

                            'If Retenciones.Count > 0 Then
                            Me.Impuestos.Retenciones = Retenciones.ToArray
                            'End If
                        End With
                    End If

                    Dim NodoImpuestosLocales As XmlNode = xmlDoc.Item(sTAG & "Comprobante").Item(sTAG & "Complemento").Item(sTagImpLocal & "ImpuestosLocales")
                    If TieneValorXML(NodoImpuestosLocales) = True Then
                        With NodoImpuestosLocales
                            Me.ImpuestosLocales.TotaldeRetenciones = valorNumerico(LeeValorXML(.Attributes("TotaldeRetenciones")))
                            Me.ImpuestosLocales.TotaldeTraslados = valorNumerico(LeeValorXML(.Attributes("TotaldeTraslados")))
                        End With
                    End If

                    Dim NodoImpuestosAerolineas As XmlNode = xmlDoc.Item(sTAG & "Comprobante").Item(sTAG & "Complemento").Item(sTagAerolineas & "Aerolineas")
                    If TieneValorXML(NodoImpuestosAerolineas) = True Then
                        With NodoImpuestosAerolineas
                            Me.ImpuestosAerolineas.TUA = valorNumerico(LeeValorXML(.Attributes("TUA")))
                        End With

                        If Me.ImpuestosAerolineas.TUA > 0 Then
                            If (Me.Comprobante.subTotal + Me.Impuestos.totalImpuestosTrasladados) = Me.Comprobante.total Then
                                Me.ImpuestosAerolineas.TieneTUADesglosado = False
                            Else
                                Me.ImpuestosAerolineas.TieneTUADesglosado = True
                            End If
                        End If

                        'Dim NodoImpuestosAerolineasOtrosCargos As XmlNode = NodoImpuestosAerolineas.Item("aerolineas:OtrosCargos")
                        'If TieneValorXML(NodoImpuestosAerolineasOtrosCargos) = True Then
                        '    With NodoImpuestosAerolineasOtrosCargos
                        '        If valorNumerico(LeeValorXML(.Attributes("TotalCargos"))) > 0 Then
                        '            Me.ImpuestosAerolineas.TieneTUADesglosado = True
                        '        End If
                        '    End With
                        'End If
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    'Se movió al final el régimen porque ciertos xmls cfdi si lo tienen pero sin la etiqueta de cfdi, y para que así cargue primero los demás datos y no se salte.
                    If TieneValorXML(NodoEmisorRegimenFiscal) = True Then
                        With NodoEmisorRegimenFiscal
                            Me.Emisor.RegimenFiscal.Regimen = LeeValorXML(.Attributes("Regimen"))
                        End With
                    Else
                        NodoEmisorRegimenFiscal = NodoEmisor.Item("RegimenFiscal")
                        If TieneValorXML(NodoEmisorRegimenFiscal) = True Then
                            Throw New Exception("El XML tiene RegimenFiscal sin etiqueta cfdi:.")
                        Else
                            Throw New Exception("El XML no trae el nodo cfdi:RegimenFiscal.")
                        End If
                    End If

                Case "3.3"
                    With NodoComprobante
                        Me.Comprobante.version = LeeValorXML(.Attributes("Version"))
                        Me.Comprobante.serie = LeeValorXML(.Attributes("Serie"))
                        Me.Comprobante.folio = LeeValorXML(.Attributes("Folio"))
                        Me.Comprobante.fecha = CDate(LeeValorXML(.Attributes("Fecha")))
                        Me.Comprobante.sello = LeeValorXML(.Attributes("Sello"))
                        Me.Comprobante.formaDePago = LeeValorXML(.Attributes("FormaPago"))
                        Me.Comprobante.noCertificado = LeeValorXML(.Attributes("NoCertificado"))
                        Me.Comprobante.certificado = LeeValorXML(.Attributes("Certificado"))
                        Me.Comprobante.condicionesDePago = LeeValorXML(.Attributes("CondicionesDePago"))
                        Me.Comprobante.subTotal = valorNumerico(LeeValorXML(.Attributes("SubTotal")))
                        Me.Comprobante.descuento = valorNumerico(LeeValorXML(.Attributes("Descuento")))
                        Me.Comprobante.Moneda = LeeValorXML(.Attributes("Moneda"))
                        Me.Comprobante.TipoCambio = LeeValorXML(.Attributes("TipoCambio"))
                        Me.Comprobante.total = valorNumerico(LeeValorXML(.Attributes("Total")))
                        Me.Comprobante.tipoDeComprobante = LeeValorXML(.Attributes("TipoDeComprobante"))
                        Me.Comprobante.metodoDePago = LeeValorXML(.Attributes("MetodoPago"))
                        Me.Comprobante.LugarExpedicion = LeeValorXML(.Attributes("LugarExpedicion"))
                        Me.Comprobante.Confirmacion = LeeValorXML(.Attributes("Confirmacion"))
                    End With
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim NodoEmisor As XmlNode = xmlDoc.Item(sTAG & "Comprobante").Item(sTAG & "Emisor")
                    With NodoEmisor
                        Me.Emisor.rfc = LeeValorXML(.Attributes("Rfc"))
                        Me.Emisor.nombre = LeeValorXML(.Attributes("Nombre"))
                        'Me.Emisor.RegimenFiscal = LeeValorXML(.Attributes("RegimenFiscal"))'De momento es incompatible este campo por ser string en el 33
                    End With

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim NodoReceptor As XmlNode = xmlDoc.Item(sTAG & "Comprobante").Item(sTAG & "Receptor")
                    With NodoReceptor
                        Me.Receptor.rfc = LeeValorXML(.Attributes("Rfc"))
                        Me.Receptor.nombre = LeeValorXML(.Attributes("Nombre"))
                        Me.Receptor.ResidenciaFiscal = LeeValorXML(.Attributes("ResidenciaFiscal"))
                        Me.Receptor.NumRegIdTrib = LeeValorXML(.Attributes("NumRegIdTrib"))
                        Me.Receptor.UsoCFDI = LeeValorXML(.Attributes("UsoCFDI"))
                    End With

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim NodoComplemento As XmlNode = xmlDoc.Item(sTAG & "Comprobante").Item(sTAG & "Complemento").Item(sTagTFD & "TimbreFiscalDigital")
                    With NodoComplemento
                        Me.ComplementoTFD.Version = LeeValorXML(.Attributes("Version"))
                        Me.ComplementoTFD.UUID = LeeValorXML(.Attributes("UUID"))
                        Me.ComplementoTFD.FechaTimbrado = LeeValorXML(.Attributes("FechaTimbrado"))
                        Me.ComplementoTFD.RfcProvCertif = LeeValorXML(.Attributes("RfcProvCertif"))
                        Me.ComplementoTFD.Leyenda = LeeValorXML(.Attributes("Leyenda"))
                        Me.ComplementoTFD.SelloCFD = LeeValorXML(.Attributes("SelloCFD"))
                        Me.ComplementoTFD.NoCertificadoSAT = LeeValorXML(.Attributes("NoCertificadoSAT"))
                        Me.ComplementoTFD.SelloSAT = LeeValorXML(.Attributes("SelloSAT"))
                    End With

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim NodoImpuestos As XmlNode = xmlDoc.Item(sTAG & "Comprobante").Item(sTAG & "Impuestos")
                    Dim Retenciones As New List(Of ComprobanteImpuestosRetencion)
                    Dim Traslados As New List(Of ComprobanteImpuestosTraslado)

                    If TieneValorXML(NodoImpuestos) = True Then
                        With NodoImpuestos
                            Me.Impuestos.totalImpuestosRetenidos = valorNumerico(LeeValorXML(.Attributes("TotalImpuestosRetenidos")))
                            Me.Impuestos.totalImpuestosTrasladados = valorNumerico(LeeValorXML(.Attributes("TotalImpuestosTrasladados")))
                        End With
                    End If

                    'Nota de momento no se cargan completos los impuestos , porque se adaptó el 3.3 para el proceso de sincronización de xml
            End Select

            Me._XMLCargado = True
        Catch ex As Exception
            HandleError(Me.NombreClase, "New", ex)
        End Try
    End Sub

#End Region

#Region "Métodos y procedimientos"
    Private Function ConceptosXML(ByVal xmlDoc As XmlDocument) As System.Collections.Generic.List(Of clsConcepto)
        Dim list As New System.Collections.Generic.List(Of clsConcepto)()
        If xmlDoc.DocumentElement.Name = "cfdi:Comprobante" OrElse xmlDoc.DocumentElement.Name = "Comprobante" Then
            For i As Integer = 0 To xmlDoc.DocumentElement.ChildNodes.Count - 1
                If xmlDoc.DocumentElement.ChildNodes(i).Name = "cfdi:Conceptos" OrElse xmlDoc.DocumentElement.ChildNodes(i).Name = "Conceptos" Then
                    For j As Integer = 0 To xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes.Count - 1
                        If xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).Name = "cfdi:Concepto" OrElse xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).Name = "Concepto" Then
                            Dim concepto As New clsConcepto()
                            concepto.Cantidad = System.Convert.ToDouble(xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).Attributes("cantidad").Value)
                            Try
                                concepto.Unidad = xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).Attributes("unidad").Value
                            Catch msgx As System.Exception
                                concepto.Unidad = ""
                            End Try
                            concepto.Descripcion = xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).Attributes("descripcion").Value.Replace(vbLf, "")
                            concepto.valorUnitario = System.Convert.ToDouble(xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).Attributes("valorUnitario").Value)
                            concepto.Importe = System.Convert.ToDouble(xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).Attributes("importe").Value)
                            list.Add(concepto)
                        End If
                    Next
                End If
            Next
        End If
        Return list
    End Function

    Private Function GenerarCodigoBD() As Byte()

        Dim text As String = String.Concat(New String() {"?re=", Me.Emisor.rfc, "&rr=", Me.Receptor.rfc, "&tt=", Me.Comprobante.total.ToString, "&id=", Me.ComplementoTFD.UUID})

        'Dim vbCreoImagen As Boolean, vlRutaBidimensional As String = "C:\Users\JorgeGC\Desktop\cbb.jpg"
        'vbCreoImagen = Bidimensional.CreaBidimensional(text, vlRutaBidimensional, "Byte", 4, 7, "M", "Jpeg")
        'Dim fsFoto As System.IO.FileStream
        'fsFoto = New System.IO.FileStream(vlRutaBidimensional, FileMode.OpenOrCreate, FileAccess.Read)
        'Dim fiFoto As FileInfo = New FileInfo(vlRutaBidimensional)
        'Dim Temp As Long = fiFoto.Length
        'Dim lung As Long = Convert.ToInt32(Temp)
        'Dim picture(CInt(lung)) As Byte
        'fsFoto.Read(picture, 0, CInt(lung))
        'fsFoto.Close()

        'Dim im As System.Drawing.Image
        'Dim ms As MemoryStream
        'im = System.Drawing.Image.FromFile(vlRutaBidimensional)
        'ms = New MemoryStream
        'im.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
        'GenerarCodigoBD = ms.ToArray
        'im.Dispose()
        'ms.Dispose()
        'im = Nothing
        'ms = Nothing


        Dim qRCodeEncoder As New QRCodeEncoder()

        qRCodeEncoder.QRCodeEncodeMode = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ENCODE_MODE.BYTE
        qRCodeEncoder.QRCodeScale = 3
        qRCodeEncoder.QRCodeVersion = 0
        qRCodeEncoder.QRCodeErrorCorrect = 0

        Dim image As System.Drawing.Image = qRCodeEncoder.Encode(text)
        Dim memoryStream As New System.IO.MemoryStream()
        image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png)
        Return memoryStream.ToArray()
    End Function

#End Region

End Class
