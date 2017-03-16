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

    Public xmlns As String = "http://www.sat.gob.mx/ComercioExterior"

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
        'AnexoNodo = "cce:"
    End Sub

    Public Function GenerarCadenaXMLComercioExterior() As String
        Dim sResultado As String = ""
        Try
            Dim Doc As New MSXML2.DOMDocument60

            Doc.async = False
            Doc.validateOnParse = False
            Doc.resolveExternals = False
            Doc.preserveWhiteSpace = True

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''ComercioExterior
            Dim NdComercioExterior As MSXML2.IXMLDOMElement 'Comprobante
            NdComercioExterior = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "cce:ComercioExterior", xmlns)

            With NdComercioExterior
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
                Dim NdEmisor As MSXML2.IXMLDOMElement
                NdEmisor = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "cce:Emisor", xmlns)

                If txtLEN(Me.Emisor.Curp) = True Then
                    NdEmisor.setAttribute("Curp", Me.Emisor.Curp)
                End If

                NdComercioExterior.appendChild(NdEmisor)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Receptor
            Dim NdReceptor As MSXML2.IXMLDOMElement
            NdReceptor = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "cce:Receptor", xmlns)

            If txtLEN(Me.Receptor.Curp) = True Then
                NdReceptor.setAttribute("Curp", Me.Receptor.Curp)
            End If

            If txtLEN(Me.Receptor.NumRegIdTrib) = True Then
                NdReceptor.setAttribute("NumRegIdTrib", Me.Receptor.NumRegIdTrib)
            Else
                MsgBox("El valor de Receptor.NumRegIdTrib es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                Return ""
            End If

            NdComercioExterior.appendChild(NdReceptor)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Destinatario,opcional
            If bTieneDestinatario = True Then
                Dim NdDestinatario As MSXML2.IXMLDOMElement
                NdDestinatario = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "cce:Destinatario", xmlns)

                If txtLEN(Me.Destinatario.NumRegIdTrib) = True Then
                    NdDestinatario.setAttribute("NumRegIdTrib", Me.Destinatario.NumRegIdTrib)
                End If
                If txtLEN(Me.Destinatario.Rfc) = True Then
                    NdDestinatario.setAttribute("Rfc", Me.Destinatario.Rfc)
                End If
                If txtLEN(Me.Destinatario.Curp) = True Then
                    NdDestinatario.setAttribute("Curp", Me.Destinatario.Curp)
                End If
                If txtLEN(Me.Destinatario.Nombre) = True Then
                    NdDestinatario.setAttribute("Nombre", Me.Destinatario.Nombre)
                End If

                Dim NdDomicilioDestinatario As MSXML2.IXMLDOMElement
                NdDomicilioDestinatario = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "cce:Domicilio", xmlns)

                If txtLEN(Me.Destinatario.Domicilio.Calle) = True Then
                    NdDomicilioDestinatario.setAttribute("Calle", Me.Destinatario.Domicilio.Calle)
                Else
                    MsgBox("El valor de Destinatario.Domicilio.Calle es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                    Return ""
                End If

                If txtLEN(Me.Destinatario.Domicilio.NumeroExterior) = True Then
                    NdDomicilioDestinatario.setAttribute("NumeroExterior", Me.Destinatario.Domicilio.NumeroExterior)
                End If
                If txtLEN(Me.Destinatario.Domicilio.NumeroInterior) = True Then
                    NdDomicilioDestinatario.setAttribute("NumeroInterior", Me.Destinatario.Domicilio.NumeroInterior)
                End If
                If txtLEN(Me.Destinatario.Domicilio.Colonia) = True Then
                    NdDomicilioDestinatario.setAttribute("Colonia", Me.Destinatario.Domicilio.Colonia)
                End If
                If txtLEN(Me.Destinatario.Domicilio.Localidad) = True Then
                    NdDomicilioDestinatario.setAttribute("Localidad", Me.Destinatario.Domicilio.Localidad)
                End If
                If txtLEN(Me.Destinatario.Domicilio.Referencia) = True Then
                    NdDomicilioDestinatario.setAttribute("Referencia", Me.Destinatario.Domicilio.Referencia)
                End If
                If txtLEN(Me.Destinatario.Domicilio.Municipio) = True Then
                    NdDomicilioDestinatario.setAttribute("Municipio", Me.Destinatario.Domicilio.Municipio)
                End If

                If txtLEN(Me.Destinatario.Domicilio.Estado) = True Then
                    NdDomicilioDestinatario.setAttribute("Estado", Me.Destinatario.Domicilio.Estado)
                Else
                    MsgBox("El valor de Destinatario.Domicilio.Estado es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                    Return ""
                End If

                If txtLEN(Me.Destinatario.Domicilio.Pais) = True Then
                    NdDomicilioDestinatario.setAttribute("Pais", Me.Destinatario.Domicilio.Pais)
                Else
                    MsgBox("El valor de Destinatario.Domicilio.Pais es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                    Return ""
                End If

                If txtLEN(Me.Destinatario.Domicilio.CodigoPostal) = True Then
                    NdDomicilioDestinatario.setAttribute("CodigoPostal", Me.Destinatario.Domicilio.CodigoPostal)
                Else
                    MsgBox("El valor de Destinatario.Domicilio.CodigoPostal es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                    Return ""
                End If

                NdDestinatario.appendChild(NdDomicilioDestinatario)

                NdComercioExterior.appendChild(NdDestinatario)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Mercancias

            Dim NdMercancias As MSXML2.IXMLDOMElement
            NdMercancias = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "cce:Mercancias", Me.xmlns)

            Dim NdMercancia As MSXML2.IXMLDOMElement
            Dim i As Integer = 0

            For i = 1 To CInt(Me.Mercancia.Count)

                NdMercancia = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "cce:Mercancia", Me.xmlns)
                With NdMercancia

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
                        .setAttribute("CantidadAduana", Me.Mercancia.Item(i).CantidadAduana)
                    End If
                    If txtLEN(Me.Mercancia.Item(i).UnidadAduana) = True Then
                        .setAttribute("UnidadAduana", Me.Mercancia.Item(i).UnidadAduana)
                    End If
                    If txtLEN(Me.Mercancia.Item(i).ValorUnitarioAduana) = True Then
                        .setAttribute("ValorUnitarioAduana", Me.Mercancia.Item(i).ValorUnitarioAduana)
                    End If
                    If txtLEN(Me.Mercancia.Item(i).ValorDolares) = True Then
                        .setAttribute("ValorDolares", Me.Mercancia.Item(i).ValorDolares)
                    Else
                        MsgBox("El valor de Mercancia.ValorDolares es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                        Return ""
                    End If

                End With
                NdMercancias.appendChild(NdMercancia)

                'CfdAddenda.Articulos.Add(row("CODIGO_ARTICULO"))
            Next

            If Me.Mercancia.Count > 0 Then
                NdComercioExterior.appendChild(NdMercancias)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Doc.appendChild(NdComercioExterior)

            'MsgBox(Doc.xml)

            sResultado = Doc.xml

        Catch ex As Exception
            HandleError(Me.NombreClase, "GenerarCadenaXMLComercioExterior", ex)
        End Try

        Return sResultado

    End Function

End Class
