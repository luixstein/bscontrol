Option Strict Off
Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Friend Class cComprobante
    Public xmlns As String
    Public xmlnsxsi As String
    Public xsischemaLocation As String
    Public xmlnscfdi As String
    Public version As String
    Public serie As String
    Public Folio As String
    Public fecha As String
    Public noAprobacion As String
    Public anoAprobacion As String
    Public formaDePago As String
    Public condicionesDePago As String
    Public subTotal As String
    Public Descuento As String
    Public TipoCambio As String
    Public Moneda As String
    Public total As String
    Public tipoDeComprobante As String
    Public noCertificado As String
    Public certificado As String
    Public sello As String
    'CFD
    Public metodoDePago As String
    Public Regimen As String
    Public LugarExpedicion As String
    Public NumCtaPago As String

    Public Emisor As iEmisor
    Public Receptor As iReceptor
    Public Conceptos As iConceptos
    Public Impuestos As iImpuestos

    Public sFolioFacturaSistema As String
    Public sRequiereNumPago As String

    Private i As Integer
    Private AnexoNodo As String

    Enum TipoComprobante
        FACTURA_VENTA
        NOTA_CREDITO_CXC
    End Enum

    'UPGRADE_NOTE: CLASS_INITIALIZE was upgraded to CLASS_INITIALIZE_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Initialize_Renamed()
        Emisor = New iEmisor
        Receptor = New iReceptor
        Conceptos = New iConceptos
        Impuestos = New iImpuestos
        AnexoNodo = "cfdi:"
    End Sub

    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub

    Public Function Sellar(ByVal sRutaXML As String, ByVal TipoComprobante As TipoComprobante, ByVal bMostrarUnidadVenta As Boolean, Optional ByVal XmlComplementoComercioExterior As String = "", _
                           Optional ByVal EsPorEmbarqueExtranjero As Boolean = False) As Boolean
        Dim bResultado As Boolean = False
        Dim Doc As MSXML2.DOMDocument60 'Documento

        '*******NODOS
        Dim NdCom As MSXML2.IXMLDOMElement 'Comprobante
        Doc = New MSXML2.DOMDocument60
        Try
            Doc.async = False
            Doc.validateOnParse = False
            Doc.resolveExternals = False
            Doc.preserveWhiteSpace = True

            Dim version As MSXML2.IXMLDOMProcessingInstruction '<?xml version="1.0"?>
            version = Doc.createProcessingInstruction("xml", "version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34))
            'UPGRADE_WARNING: Couldn't resolve default property of object version. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Doc.appendChild(version)

            'Dim cokenoCertificado As String, cokeCertificado As String, cokeSello As String

            '    cokenoCertificado = "00001000000102088326"

            '    cokeCertificado = "" & _
            ''    "MIIEEjCCAvqgAwIBAgIUMDAwMDEwMDAwMDAxMDIwODgzMjYwDQYJKoZIhvcNAQEFBQAwggE2MTgwNgYDVQQDDC9BLkMuIGRlbCBTZXJ2aWNpbyBkZSBBZG1pbmlzdHJhY2nDs24gVHJpYnV0YXJpYTE" & _
            ''    "vMC0GA1UECgwmU2VydmljaW8gZGUgQWRtaW5pc3RyYWNpw7NuIFRyaWJ1dGFyaWExHzAdBgkqhkiG9w0BCQEWEGFjb2RzQHNhdC5nb2IubXgxJjAkBgNVBAkMHUF2LiBIaWRhbGdvIDc3LCBDb2wuIE" & _
            ''    "d1ZXJyZXJvMQ4wDAYDVQQRDAUwNjMwMDELMAkGA1UEBhMCTVgxGTAXBgNVBAgMEERpc3RyaXRvIEZlZGVyYWwxEzARBgNVBAcMCkN1YXVodGVtb2MxMzAxBgkqhkiG9w0BCQIMJFJlc3BvbnNhYmxlO" & _
            ''    "iBGZXJuYW5kbyBNYXJ0w61uZXogQ29zczAeFw0xMDEwMTgxNjMzNDNaFw0xMjEwMTcxNjMzNDNaMIGyMRwwGgYDVQQDExNQQVFBIFNDIERFIFJMIERFIENWMRwwGgYDVQQpExNQQVFBIFNDIERFIFJM" & _
            ''    "IERFIENWMRwwGgYDVQQKExNQQVFBIFNDIERFIFJMIERFIENWMSUwIwYDVQQtExxQQVEwNjA3MjZUOTMgLyBMQVJMNzQwODMxRFg4MR4wHAYDVQQFExUgLyBMQVJMNzQwODMxSFNMUkRTMDgxDzANBgN" & _
            ''    "VBAsTBlVOSURBRDCBnzANBgkqhkiG9w0BAQEFAAOBjQAwgYkCgYEArHYdQF9GkuGWVQpN8V+JaaxOjLk+b0t2h5lv1RL5KGtwX9Cbz+L9Yrx7D8Ryv/NQO7QvjpXN9K3HjmbIthkDVpVct9KGXtEhnW" & _
            ''    "dFixD0nVctMu01tGHBoFyhh3lzOU0FCEz1I99mBxlnxwnsfVWPLMSFc9Xu6V7YDlV+hHN3JWUCAwEAAaMdMBswDAYDVR0TAQH/BAIwADALBgNVHQ8EBAMCBsAwDQYJKoZIhvcNAQEFBQADggEBADZ6a" & _
            ''    "iTvuq8WOEbz0kQTCdfNrA91S9q+il7uea+0XIABqvz/B2JogXBE2rRn0+t8gxetEfno7CmomNpR7GBlMETmBI5puplYc5P0wZxgkRQA6BFfPfyWFO2Tles1glW9Qi9cMQ9vrifnpamnGUaQlwc4pgAQ" & _
            ''    "Eo+q8kjtX/kaFi5X9eDMs8jcJDWIn0GEQCWP+Ok19dae2vajz3D4r2jn1daMNWDxkhewK9Sycbil3k/5Cx0hQGRbDhpeUgXgLdbTBoWL3qKXQJWU4rfzAQ0wS3s9NM+vDe32Yy2gRr9yT3VTEm4m0hA" & _
            ''    "Gwpmew4q9m4baprDFD9uUJfHyWwribO/IJrA="

            '    cokeSello = "kunreTGjYOtiPA4m8s/AqXxil8ltVHzSZMmIofnGAHmdO1SO0uQK9hOYNdYTVKiS3PO3QBrwsInRu2DDELeHhR42ACTTGbjIuyjnGQiZYWe0NoKIdGQ5PruWhg9Ibln3u7kg1XsRBO1qD4ZZZiLM8CWVk2pkThl6/fL0KLnr7Vo="
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            Dim dSumaImportes As Double = 0

            If EsPorEmbarqueExtranjero = True Then
                'No se hace nada con los totales, ya vienen correctos y no lleva impuestos.
            Else
                If Me.Moneda = "USD" Then
                    Me.subTotal = Redondear(valorNumerico(Me.subTotal) / valorNumerico(Me.TipoCambio), 2)
                    Me.Descuento = Redondear(valorNumerico(Me.Descuento) / valorNumerico(Me.TipoCambio), 2)
                    Me.total = Redondear(valorNumerico(Me.total) / valorNumerico(Me.TipoCambio), 2)

                    'LA FUNCION TotalImpuestosTransladados LO CALCULA INTERNAMENTE
                    For Me.i = 1 To Me.Impuestos.Traslados.Count 'AQUI DENTRO YA VA EL IVA Y EL IEPS
                        Impuestos.Traslados.Item(Me.i).importe = Redondear(valorNumerico(Impuestos.Traslados.Item(Me.i).importe) / valorNumerico(Me.TipoCambio), 2)
                    Next
                End If

                For Me.i = 1 To Conceptos.Count 'barrer la coleccion de conceptos
                    If Me.Moneda = "USD" Then
                        Conceptos.Item(Me.i).importe = valorNumerico(Conceptos.Item(Me.i).importe) / valorNumerico(Me.TipoCambio) 'NO SE REDONDEA AQUI PORQUE SE REDONDEA MAS ABAJO
                        Conceptos.Item(Me.i).valorUnitario = Redondear(valorNumerico(Conceptos.Item(Me.i).valorUnitario) / valorNumerico(Me.TipoCambio), 3)
                    End If

                    Conceptos.Item(Me.i).importe = Redondear(Conceptos.Item(Me.i).importe, 2)
                    'EL VALOR UNITARIO YA VIENE REDONDEADO CUANDO SON PESOS

                Next
            End If

            For Me.i = 1 To Conceptos.Count 'barrer la coleccion de conceptos
                dSumaImportes = dSumaImportes + valorNumerico(Conceptos.Item(Me.i).importe)
            Next

            dSumaImportes = Redondear(dSumaImportes, 2)

            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------

            'VALIDACIONES
            'SUMA DE IMPORTES=SUBTOTAL
            'If dSumaImportes <> valorNumerico(Me.subTotal) Then
            If Abs(dSumaImportes - valorNumerico(Me.subTotal)) > 0.2 Then
                MsgBox("La suma de los importes del detalle no es igual al subtotal.", vbExclamation, "cComprobante")
                Exit Function
            End If

            'TOTAL=SUBTOTAL-DESCUENTOS+DIFERENTES IMPUESTOS(TotalImpuestosTransladados)
            If Abs(Me.total - (valorNumerico(Me.subTotal) - valorNumerico(Me.Descuento) + valorNumerico(TotalImpuestosTransladados))) > 0.010001 Then
                MsgBox("La suma del subtotal y los impuestos menos los descuentos son diferentes al total.", vbExclamation, "cComprobante")
                Exit Function
            End If

            'VALIDAR QUE EL RFC SEA DE 12 O 13
            If Len(Receptor.rfc) < 12 Or Len(Receptor.rfc) > 13 Then
                MsgBox("El RFC del cliente no cumple con la longitud requerida.", vbExclamation, "cComprobante")
                Exit Function
            End If

            'AQUI SE SUSTITUYE EL AMPERSON POR UNOS CARACTERES ESPECIALES PARA QUE PERMITA TIMBRAR
            '    Receptor.nombre = CaracterEspecial(Receptor.nombre)
            '    Receptor.rfc = CaracterEspecial(Receptor.rfc)

            'VALIDAR QUE EL RFC SEA DIFERENTE 111111111111,1111111111111,000000000000,0000000000000
            If Receptor.rfc = "111111111111" Or Receptor.rfc = "1111111111111" Or Receptor.rfc = "000000000000" Or Receptor.rfc = "0000000000000" Then
                MsgBox("El RFC del cliente es inválido.", vbExclamation, "cComprobante")
                Exit Function
            End If

            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------

            '*****************************************************************************
            'NODO COMPROBANTE************************************************************
            NdCom = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Comprobante", Me.xmlns)
            With NdCom
                .setAttribute("xmlns:xsi", Me.xmlnsxsi)
                .setAttribute("xmlns:cfdi", Me.xmlnscfdi)
                .setAttribute("xsi:schemaLocation", Me.xsischemaLocation)
                .setAttribute("version", Me.version)
                .setAttribute("serie", Me.serie)
                .setAttribute("folio", Me.Folio)
                .setAttribute("fecha", Me.fecha)
                '.setAttribute("noAprobacion", Me.noAprobacion)
                '.setAttribute("anoAprobacion", Me.anoAprobacion)
                .setAttribute("formaDePago", Me.formaDePago)
                If txtLEN(Me.condicionesDePago) = True Then
                    .setAttribute("condicionesDePago", Me.condicionesDePago)
                End If
                .setAttribute("subTotal", Me.subTotal)
                If TipoComprobante = TipoComprobante.FACTURA_VENTA Then 'EL NODO DESCUENTOS SOLO ES PARA LAS FACTURAS
                    .setAttribute("descuento", Me.Descuento)
                    If EsPorEmbarqueExtranjero = True Then
                        .setAttribute("motivoDescuento", "Exportacion a consignacion")
                    End If
                End If
                If valorNumerico(Me.TipoCambio) > 0 Then
                    .setAttribute("TipoCambio", Me.TipoCambio)
                End If
                .setAttribute("Moneda", Me.Moneda)
                .setAttribute("total", Me.total)
                .setAttribute("tipoDeComprobante", Me.tipoDeComprobante)
                .setAttribute("noCertificado", "")
                .setAttribute("certificado", "")
                .setAttribute("sello", "")
                'CFD
                .setAttribute("metodoDePago", Me.metodoDePago)
                .setAttribute("LugarExpedicion", Me.LugarExpedicion)
                If sRequiereNumPago = "1" And txtLEN(Me.NumCtaPago) = True Then
                    .setAttribute("NumCtaPago", Me.NumCtaPago)
                End If
            End With

            'NODO EMISOR****************************************************************
            Dim NdEmisor As MSXML2.IXMLDOMElement 'Nodo Emissor
            NdEmisor = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Emisor", Me.xmlns)

            NdEmisor.setAttribute("nombre", Emisor.nombre)
            NdEmisor.setAttribute("rfc", Emisor.rfc)

            'NODO HIJO Domicilio Fiscal
            Dim NdDomFis As MSXML2.IXMLDOMElement
            NdDomFis = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "DomicilioFiscal", Me.xmlns)
            With NdDomFis
                .setAttribute("calle", Emisor.DomicilioFiscal.calle)
                .setAttribute("codigoPostal", Emisor.DomicilioFiscal.codigoPostal)

                If txtLEN(Emisor.DomicilioFiscal.colonia) = True Then
                    .setAttribute("colonia", Emisor.DomicilioFiscal.colonia)
                End If

                .setAttribute("estado", Emisor.DomicilioFiscal.estado)
                If txtLEN(Emisor.DomicilioFiscal.localidad) = True Then
                    .setAttribute("localidad", Emisor.DomicilioFiscal.localidad)
                End If
                .setAttribute("municipio", Emisor.DomicilioFiscal.municipio)
                .setAttribute("noExterior", Emisor.DomicilioFiscal.noExterior)
                If Trim(Emisor.DomicilioFiscal.noInterior) <> "" Then
                    .setAttribute("noInterior", Emisor.DomicilioFiscal.noInterior)
                End If
                .setAttribute("pais", Emisor.DomicilioFiscal.pais)
            End With
            'UPGRADE_WARNING: Couldn't resolve default property of object NdDomFis. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            NdEmisor.appendChild(NdDomFis) 'agregar al nodo emisor

            Dim NdExpedidoEn As MSXML2.IXMLDOMElement
            If Emisor.ExpedidoEn.USADO Then 'en caso de que el lugar de expedicion sea diferente al fiscal
                'NODO HIJO Domicilio Fiscal
                NdExpedidoEn = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "ExpedidoEn", Me.xmlns)
                With NdExpedidoEn
                    .setAttribute("calle", Emisor.ExpedidoEn.calle)
                    .setAttribute("codigoPostal", Emisor.ExpedidoEn.codigoPostal)

                    If txtLEN(Emisor.ExpedidoEn.colonia) = True Then
                        .setAttribute("colonia", Emisor.ExpedidoEn.colonia)
                    End If

                    .setAttribute("estado", Emisor.ExpedidoEn.estado)
                    If txtLEN(Emisor.ExpedidoEn.localidad) = True Then
                        .setAttribute("localidad", Emisor.ExpedidoEn.localidad)
                    End If
                    .setAttribute("municipio", Emisor.ExpedidoEn.municipio)
                    .setAttribute("noExterior", Emisor.ExpedidoEn.noExterior)
                    If Trim(Emisor.ExpedidoEn.noInterior) <> "" Then
                        .setAttribute("noInterior", Emisor.ExpedidoEn.noInterior)
                    End If
                    .setAttribute("pais", Emisor.ExpedidoEn.pais)
                End With
                'UPGRADE_WARNING: Couldn't resolve default property of object NdExpedidoEn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                NdEmisor.appendChild(NdExpedidoEn) 'agregar al nodo emisor
            End If

            'CFD
            'NODO HIJO RegimenFiscal
            Dim NdRegimenFiscal As MSXML2.IXMLDOMElement
            NdRegimenFiscal = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "RegimenFiscal", Me.xmlns)
            With NdRegimenFiscal
                .setAttribute("Regimen", Me.Regimen)
                '.setAttribute("metodoDePago", Me.metodoDePago)
                '.setAttribute("LugarExpedicion", Me.LugarExpedicion)
                'If sRequiereNumPago = "1" Then
                '    .setAttribute("NumCtaPago", Me.NumCtaPago)
                'End If
            End With
            NdEmisor.appendChild(NdRegimenFiscal) 'agreagar al nodo emisor

            'UPGRADE_WARNING: Couldn't resolve default property of object NdEmisor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            NdCom.appendChild(NdEmisor) 'AGREGAR EL NODO EMISOR AL NODO COMPROBANTE

            'NODO RECEPTOR******************************************************
            Dim NdReceptor As MSXML2.IXMLDOMElement 'Nodo Emissor
            NdReceptor = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Receptor", Me.xmlns)

            NdReceptor.setAttribute("nombre", Receptor.nombre)
            NdReceptor.setAttribute("rfc", Receptor.rfc)

            'NODO HIJO RECEPTOR.Domicilio
            Dim NdDom As MSXML2.IXMLDOMElement
            NdDom = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Domicilio", Me.xmlns)
            With NdDom
                If txtLEN(Receptor.Domicilio.calle.Trim) = True Then
                    .setAttribute("calle", Receptor.Domicilio.calle)
                End If

                If txtLEN(Receptor.Domicilio.codigoPostal.Trim) = True Then
                    .setAttribute("codigoPostal", Receptor.Domicilio.codigoPostal)
                End If

                If txtLEN(Receptor.Domicilio.colonia.Trim) = True Then
                    .setAttribute("colonia", Receptor.Domicilio.colonia)
                End If

                If txtLEN(Receptor.Domicilio.estado.Trim) = True Then
                    .setAttribute("estado", Receptor.Domicilio.estado)
                End If

                If txtLEN(Receptor.Domicilio.localidad.Trim) = True Then
                    .setAttribute("localidad", Receptor.Domicilio.localidad)
                End If

                If txtLEN(Receptor.Domicilio.municipio.Trim) = True Then
                    .setAttribute("municipio", Receptor.Domicilio.municipio)
                End If

                If txtLEN(Receptor.Domicilio.noExterior.Trim) = True Then
                    .setAttribute("noExterior", Receptor.Domicilio.noExterior)
                End If

                If txtLEN(Receptor.Domicilio.noInterior.Trim) = True Then
                    .setAttribute("noInterior", Receptor.Domicilio.noInterior)
                End If

                .setAttribute("pais", Receptor.Domicilio.pais)
            End With
            'UPGRADE_WARNING: Couldn't resolve default property of object NdDom. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            NdReceptor.appendChild(NdDom) 'agreagar al nodo emisor

            'UPGRADE_WARNING: Couldn't resolve default property of object NdReceptor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            NdCom.appendChild(NdReceptor) 'AGREGAR EL NODO RECEPTOR AL NODO COMPROBANTE

            'NODO Conceptos*************************************************
            Dim NdConceptos As MSXML2.IXMLDOMElement 'Nodo Conceptos
            NdConceptos = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Conceptos", Me.xmlns)

            Dim NdConcepto As MSXML2.IXMLDOMElement
            Dim i As Integer = 0

            For i = 1 To Conceptos.Count 'barrer la coleccion de conceptos
                NdConcepto = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Concepto", Me.xmlns)
                With NdConcepto
                    If txtLEN(Conceptos.Item(i).noIdentificacion) = True Then
                        .setAttribute("noIdentificacion", Conceptos.Item(i).noIdentificacion)
                    End If
                    .setAttribute("cantidad", Conceptos.Item(i).cantidad)
                    .setAttribute("descripcion", Conceptos.Item(i).descripcion)
                    .setAttribute("importe", Conceptos.Item(i).importe)
                    'If bMostrarUnidadVenta = True Then
                    '    .setAttribute("unidad", Conceptos.Item(i).unidad)
                    'End If
                    'CFD
                    If txtLEN(Trim(Conceptos.Item(i).unidad)) = False Then
                        MsgBox("No se puede generar el comprobante electrónico, el artículo tiene que tener obligatoriamente una unidad de venta.", vbExclamation, "FacturacionElectronica-Sellar")
                        Exit Function
                    End If
                    .setAttribute("unidad", Conceptos.Item(i).unidad)

                    .setAttribute("valorUnitario", Conceptos.Item(i).valorUnitario)
                End With
                NdConceptos.appendChild(NdConcepto) 'agreagar al nodo Conceptos
            Next
            NdCom.appendChild(NdConceptos) 'agregar el Nodo CONCEPTOS al nodo COMPROBANTE

            'NODO Impuestos***********************************************************************
            Dim NdImpuestos As MSXML2.IXMLDOMElement 'Nodo Impuestos
            NdImpuestos = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Impuestos", Me.xmlns)

            NdImpuestos.setAttribute("totalImpuestosTrasladados", TotalImpuestosTransladados) 'jorgeglez 20may11 agregó esta funcionalidad

            'NODO Retenciones***********************************************************************
            If Me.Impuestos.Retenciones.Count > 0 Then
                Dim NdRetenciones As MSXML2.IXMLDOMElement 'Nodo RETENCIONES
                NdRetenciones = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Retenciones", Me.xmlns)
                Dim NdRetencion As MSXML2.IXMLDOMElement 'Nodo Traslado

                'barrer coleccion de retenciones
                For i = 1 To Me.Impuestos.Retenciones.Count
                    NdRetencion = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Retencion", Me.xmlns)
                    With NdRetencion
                        .setAttribute("impuesto", Impuestos.Retenciones.Item(i).impuesto)
                        .setAttribute("importe", Impuestos.Retenciones.Item(i).importe)
                    End With
                    NdRetenciones.appendChild(NdRetencion)
                Next
                NdImpuestos.appendChild(NdRetenciones) 'agregar el nodo retenciones a IMPUESTOS
            End If 'NODO Retenciones********************************************************

            Dim NdTraslados As MSXML2.IXMLDOMElement
            Dim NdTraslado As MSXML2.IXMLDOMElement 'Nodo Traslado 'Nodo Traslados
            If Impuestos.Traslados.USADO Then 'si se agreago algun impuesto trasladado
                NdTraslados = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Traslados", Me.xmlns)

                'barrer coleccion de trasladados
                For i = 1 To Me.Impuestos.Traslados.Count
                    NdTraslado = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Traslado", Me.xmlns)
                    With NdTraslado
                        .setAttribute("impuesto", Impuestos.Traslados.Item(i).impuesto)
                        .setAttribute("tasa", Impuestos.Traslados.Item(i).tasa)
                        .setAttribute("importe", Impuestos.Traslados.Item(i).importe)
                    End With
                    'UPGRADE_WARNING: Couldn't resolve default property of object NdTraslado. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    NdTraslados.appendChild(NdTraslado)
                Next
                'UPGRADE_WARNING: Couldn't resolve default property of object NdTraslados. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                NdImpuestos.appendChild(NdTraslados) 'agregar el nodo Traslados a IMPUESTOS
            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object NdImpuestos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            NdCom.appendChild(NdImpuestos) 'agregar el nodo Impuestos a COMPROBANTE
            'UPGRADE_WARNING: Couldn't resolve default property of object NdCom. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Doc.appendChild(NdCom)
            'Doc.save App.Path & "\" + NombreXml

            'Doc.Save sRutaXML ' coke

            If TipoComprobante = TipoComprobante.FACTURA_VENTA Then
                If txtLEN(XmlComplementoComercioExterior) = True Then

                    Dim sXmlTemp As String = Doc.xml
                    sXmlTemp = Replace(sXmlTemp, "</cfdi:Comprobante>", "") 'quitamos la terminación del comprobante para pegarle el completo, y al final se la volvemos a poner.

                    'Pegar el xml base con el complemento
                    sXmlTemp = sXmlTemp & "<cfdi:Complemento>" & XmlComplementoComercioExterior & "</cfdi:Complemento></cfdi:Comprobante>"

                    Doc.loadXML(sXmlTemp)

                End If
            End If

            If SellarFactura(Doc, sFolioFacturaSistema, Me.serie, Me.Folio, sRutaXML, TipoComprobante) = True Then
                bResultado = True
            End If

        Catch ex As Exception
            HandleError("Comprobante", "Sellar", ex)
        End Try

        Return bResultado
    End Function

    Private Function TotalImpuestosTransladados() As String
        Dim sResultado As String = ""
        Dim i As Short
        Dim dTotal As Double
        Try
            'barrer coleccion de trasladados
            For i = 1 To Me.Impuestos.Traslados.Count
                dTotal = dTotal + valorNumerico(Impuestos.Traslados.Item(i).importe)
            Next
            sResultado = Format(dTotal, "#0.00")
        Catch ex As Exception
            HandleError("Comprobante", "TotalImpuestosTransladados", ex)
        End Try
        Return sResultado
    End Function

End Class