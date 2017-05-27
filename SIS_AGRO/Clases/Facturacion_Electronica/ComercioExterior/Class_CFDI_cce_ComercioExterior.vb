Option Strict Off
Option Explicit On
'Imports System.Xml
Imports System.Data
Imports System.Data.SqlClient

Friend Class Class_CFDI_cce_ComercioExterior

#Region "Propiedades"
#Region "Propiedad Nombre de Clase"
    Private ReadOnly Property NombreClase() As String
        Get
            NombreClase = "Class_CFDI_ComercioExterior"
        End Get
    End Property
#End Region
#End Region

    Private xmlns As String
    Private xsischemaLocation As String

    Public Version As String
    Public TipoOperacion As String
    Public ClaveDePedimento As String
    Public CertificadoOrigen As String
    Public NumCertificadoOrigen As String
    Public NumeroExportadorConfiable As String
    Public Incoterm As String
    Public Subdivision As String
    Public Observaciones As String
    Public TipoCambioUSD As String
    Public TotalUSD As String

    Public bTieneEmisor As Boolean = False
    Public bTieneDestinatario As Boolean = False

    Public Emisor As New Class_CFDI_cce_Emisor
    Public Receptor As New Class_CFDI_cce_Receptor
    Public Destinatario As New Class_CFDI_cce_Destinatario
    Public Mercancia As New Class_CFDI_cce_Mercancias

    Private AnexoNodo As String = ""

    Public Sub New()
        AnexoNodo = "cce:"
        xmlns = "http://www.sat.gob.mx/ComercioExterior"
        xsischemaLocation = "http://www.sat.gob.mx/ComercioExterior http://www.sat.gob.mx/sitio_internet/cfd/ComercioExterior/ComercioExterior10.xsd"
    End Sub

    Public Function GenerarCadenaXMLComercioExterior() As String
        Const sProcedure As String = "GenerarCadenaXMLComercioExterior"
        Dim sResultado As String = ""
        Try
            Dim xmlDoc As New MSXML2.DOMDocument60

            xmlDoc.async = False
            xmlDoc.validateOnParse = False
            xmlDoc.resolveExternals = False
            xmlDoc.preserveWhiteSpace = True

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''ComercioExterior
            Dim NodoComercioExterior As MSXML2.IXMLDOMElement 'Comprobante
            NodoComercioExterior = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, Me.AnexoNodo & "ComercioExterior", Me.xmlns)

            With NodoComercioExterior
                .setAttribute("xsi:schemaLocation", xsischemaLocation)

                If txtLEN(Me.Version) = False Then
                    MsgBox("El valor de Version es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                    Return ""
                Else
                    .setAttribute("Version", Me.Version)
                End If

                If txtLEN(Me.TipoOperacion) = False Then
                    MsgBox("El valor de TipoOperacion es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                    Return ""
                Else
                    .setAttribute("TipoOperacion", Me.TipoOperacion)
                End If

                If txtLEN(Me.ClaveDePedimento) = True Then
                    .setAttribute("ClaveDePedimento", Me.ClaveDePedimento)
                End If
                If txtLEN(Me.CertificadoOrigen) = True Then
                    .setAttribute("CertificadoOrigen", Me.CertificadoOrigen)
                End If
                If txtLEN(Me.NumCertificadoOrigen) = True Then
                    .setAttribute("NumCertificadoOrigen", Me.NumCertificadoOrigen)
                End If
                If txtLEN(Me.NumeroExportadorConfiable) = True Then
                    .setAttribute("NumeroExportadorConfiable", Me.NumeroExportadorConfiable)
                End If
                If txtLEN(Me.Incoterm) = True Then
                    .setAttribute("Incoterm", Me.Incoterm)
                End If
                If txtLEN(Me.Subdivision) = True Then
                    .setAttribute("Subdivision", Me.Subdivision)
                End If
                If txtLEN(Me.Observaciones) = True Then
                    .setAttribute("Observaciones", Me.Observaciones)
                End If
                If txtLEN(Me.TipoCambioUSD) = True Then
                    .setAttribute("TipoCambioUSD", Me.TipoCambioUSD)
                End If
                If txtLEN(Me.TotalUSD) = True Then
                    .setAttribute("TotalUSD", Me.TotalUSD)
                End If
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Emisor, opcional
            If bTieneEmisor = True Then
                Dim NodoEmisor As MSXML2.IXMLDOMElement
                NodoEmisor = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, Me.AnexoNodo & "Emisor", Me.xmlns)

                If txtLEN(Me.Emisor.Curp) = True Then
                    NodoEmisor.setAttribute("Curp", Me.Emisor.Curp)
                End If

                NodoComercioExterior.appendChild(NodoEmisor)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Receptor
            Dim NodoReceptor As MSXML2.IXMLDOMElement
            NodoReceptor = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, Me.AnexoNodo & "Receptor", Me.xmlns)

            If txtLEN(Me.Receptor.Curp) = True Then
                NodoReceptor.setAttribute("Curp", Me.Receptor.Curp)
            End If

            If txtLEN(Me.Receptor.NumRegIdTrib) = True Then
                NodoReceptor.setAttribute("NumRegIdTrib", Me.Receptor.NumRegIdTrib)
            Else
                MsgBox("El valor de Receptor.NumRegIdTrib es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                Return ""
            End If

            NodoComercioExterior.appendChild(NodoReceptor)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Destinatario,opcional
            If bTieneDestinatario = True Then
                Dim NodoDestinatario As MSXML2.IXMLDOMElement
                NodoDestinatario = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, Me.AnexoNodo & "Destinatario", Me.xmlns)

                If txtLEN(Me.Destinatario.NumRegIdTrib) = True Then
                    NodoDestinatario.setAttribute("NumRegIdTrib", Me.Destinatario.NumRegIdTrib)
                End If
                If txtLEN(Me.Destinatario.Rfc) = True Then
                    NodoDestinatario.setAttribute("Rfc", Me.Destinatario.Rfc)
                End If
                If txtLEN(Me.Destinatario.Curp) = True Then
                    NodoDestinatario.setAttribute("Curp", Me.Destinatario.Curp)
                End If
                If txtLEN(Me.Destinatario.Nombre) = True Then
                    NodoDestinatario.setAttribute("Nombre", Me.Destinatario.Nombre)
                End If

                Dim NodoDomicilioDestinatario As MSXML2.IXMLDOMElement
                NodoDomicilioDestinatario = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, Me.AnexoNodo & "Domicilio", Me.xmlns)

                With NodoDomicilioDestinatario
                    If txtLEN(Me.Destinatario.Domicilio.Calle) = True Then
                        .setAttribute("Calle", Me.Destinatario.Domicilio.Calle)
                    Else
                        MsgBox("El valor de Destinatario.Domicilio.Calle es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                        Return ""
                    End If

                    If txtLEN(Me.Destinatario.Domicilio.NumeroExterior) = True Then
                        .setAttribute("NumeroExterior", Me.Destinatario.Domicilio.NumeroExterior)
                    End If

                    If txtLEN(Me.Destinatario.Domicilio.NumeroInterior) = True Then
                        .setAttribute("NumeroInterior", Me.Destinatario.Domicilio.NumeroInterior)
                    End If

                    If txtLEN(Me.Destinatario.Domicilio.Colonia) = True Then
                        .setAttribute("Colonia", Me.Destinatario.Domicilio.Colonia)
                    End If

                    If txtLEN(Me.Destinatario.Domicilio.Localidad) = True Then
                        .setAttribute("Localidad", Me.Destinatario.Domicilio.Localidad)
                    End If

                    If txtLEN(Me.Destinatario.Domicilio.Referencia) = True Then
                        .setAttribute("Referencia", Me.Destinatario.Domicilio.Referencia)
                    End If

                    If txtLEN(Me.Destinatario.Domicilio.Municipio) = True Then
                        .setAttribute("Municipio", Me.Destinatario.Domicilio.Municipio)
                    End If

                    If txtLEN(Me.Destinatario.Domicilio.Estado) = True Then
                        .setAttribute("Estado", Me.Destinatario.Domicilio.Estado)
                    Else
                        MsgBox("El valor de Destinatario.Domicilio.Estado es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                        Return ""
                    End If

                    If txtLEN(Me.Destinatario.Domicilio.Pais) = True Then
                        .setAttribute("Pais", Me.Destinatario.Domicilio.Pais)
                    Else
                        MsgBox("El valor de Destinatario.Domicilio.Pais es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                        Return ""
                    End If

                    If txtLEN(Me.Destinatario.Domicilio.CodigoPostal) = True Then
                        .setAttribute("CodigoPostal", Me.Destinatario.Domicilio.CodigoPostal)
                    Else
                        MsgBox("El valor de Destinatario.Domicilio.CodigoPostal es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                        Return ""
                    End If
                End With

                NodoDestinatario.appendChild(NodoDomicilioDestinatario)

                NodoComercioExterior.appendChild(NodoDestinatario)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Mercancias

            Dim NodoMercancias As MSXML2.IXMLDOMElement
            NodoMercancias = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, Me.AnexoNodo & "Mercancias", Me.xmlns)

            Dim NodoMercancia As MSXML2.IXMLDOMElement
            Dim i As Integer = 0

            For i = 1 To CInt(Me.Mercancia.Count)

                NodoMercancia = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, Me.AnexoNodo & "Mercancia", Me.xmlns)

                With NodoMercancia

                    If txtLEN(Me.Mercancia.Item(i).NoIdentificacion) = True Then
                        .setAttribute("NoIdentificacion", Me.Mercancia.Item(i).NoIdentificacion)
                    Else
                        MsgBox("El valor de Mercancia.NoIdentificacion es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                        Return ""
                    End If
                    If txtLEN(Me.Mercancia.Item(i).FraccionArancelaria) = True Then
                        .setAttribute("FraccionArancelaria", Me.Mercancia.Item(i).FraccionArancelaria)
                    End If
                    If txtLEN(Me.Mercancia.Item(i).CantidadAduana) = True Then
                        .setAttribute("CantidadAduana", Format(Me.Mercancia.Item(i).CantidadAduana, "######.000"))
                    End If
                    If txtLEN(Me.Mercancia.Item(i).UnidadAduana) = True Then
                        .setAttribute("UnidadAduana", Me.Mercancia.Item(i).UnidadAduana)
                    End If
                    If txtLEN(Me.Mercancia.Item(i).ValorUnitarioAduana) = True Then
                        .setAttribute("ValorUnitarioAduana", Format(Me.Mercancia.Item(i).ValorUnitarioAduana, "######.00"))
                    End If
                    If txtLEN(Me.Mercancia.Item(i).ValorDolares) = True Then
                        .setAttribute("ValorDolares", Format(Me.Mercancia.Item(i).ValorDolares, "######.00"))
                    Else
                        MsgBox("El valor de Mercancia.ValorDolares es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                        Return ""
                    End If

                End With
                NodoMercancias.appendChild(NodoMercancia)

                'CfdAddenda.Articulos.Add(row("CODIGO_ARTICULO"))
            Next

            If Me.Mercancia.Count > 0 Then
                NodoComercioExterior.appendChild(NodoMercancias)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            xmlDoc.appendChild(NodoComercioExterior)

            'MsgBox(Doc.xml)

            sResultado = xmlDoc.xml

        Catch ex As Exception
            HandleError(Me.NombreClase, sProcedure, ex)
        End Try

        Return sResultado

    End Function

End Class
