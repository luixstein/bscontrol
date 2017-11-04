Option Strict Off
Option Explicit On

Friend Class Class_CFDI_cce_ComercioExterior11

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
    Public MotivoTraslado As String
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
    Public bTienePropietario As Boolean = False
    Public bTieneReceptor As Boolean = False
    Public bTieneDestinatario As Boolean = False

    Public Emisor As New Class_CFDI_cce_Emisor11
    Public Propietario As New Class_CFDI_cce_Propietario11
    Public Receptor As New Class_CFDI_cce_Receptor11
    Public Destinatario As New Class_CFDI_cce_Destinatario11
    Public Mercancia As New Class_CFDI_cce_Mercancias11

    Private AnexoNodo As String = ""

    Public Sub New()
        AnexoNodo = "cce11:"
        xmlns = "http://www.sat.gob.mx/ComercioExterior11"
        xsischemaLocation = "http://www.sat.gob.mx/ComercioExterior11 http://www.sat.gob.mx/sitio_internet/cfd/ComercioExterior11/ComercioExterior11.xsd"
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

                If txtLEN(Me.Version) = True Then
                    .setAttribute("Version", Me.Version)
                Else
                    MsgBox("El valor de Version es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                    Return ""
                End If

                If txtLEN(Me.MotivoTraslado) = True Then
                    .setAttribute("MotivoTraslado", Me.MotivoTraslado)
                End If

                If txtLEN(Me.TipoOperacion) = True Then
                    .setAttribute("TipoOperacion", Me.TipoOperacion)
                Else
                    MsgBox("El valor de TipoOperacion es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                    Return ""
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

                Dim NodoEmisorDomicilio As MSXML2.IXMLDOMElement
                NodoEmisorDomicilio = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, Me.AnexoNodo & "Domicilio", Me.xmlns)

                With NodoEmisorDomicilio
                    If txtLEN(Me.Emisor.Domicilio.Calle) = True Then
                        .setAttribute("Calle", Me.Emisor.Domicilio.Calle)
                    Else
                        MsgBox("El valor de Emisor.Domicilio.Calle es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                        Return ""
                    End If

                    If txtLEN(Me.Emisor.Domicilio.NumeroExterior) = True Then
                        .setAttribute("NumeroExterior", Me.Emisor.Domicilio.NumeroExterior)
                    End If

                    If txtLEN(Me.Emisor.Domicilio.Colonia) = True Then
                        .setAttribute("Colonia", Me.Emisor.Domicilio.Colonia)
                    End If

                    If txtLEN(Me.Emisor.Domicilio.Localidad) = True Then
                        .setAttribute("Localidad", Me.Emisor.Domicilio.Localidad)
                    End If

                    If txtLEN(Me.Emisor.Domicilio.Referencia) = True Then
                        .setAttribute("Referencia", Me.Emisor.Domicilio.Referencia)
                    End If

                    If txtLEN(Me.Emisor.Domicilio.Municipio) = True Then
                        .setAttribute("Municipio", Me.Emisor.Domicilio.Municipio)
                    End If

                    If txtLEN(Me.Emisor.Domicilio.Estado) = True Then
                        .setAttribute("Estado", Me.Emisor.Domicilio.Estado)
                    Else
                        MsgBox("El valor de Emisor.Domicilio.Estado es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                        Return ""
                    End If

                    If txtLEN(Me.Emisor.Domicilio.Pais) = True Then
                        .setAttribute("Pais", Me.Emisor.Domicilio.Pais)
                    Else
                        MsgBox("El valor de Emisor.Domicilio.Pais es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                        Return ""
                    End If

                    If txtLEN(Me.Emisor.Domicilio.CodigoPostal) = True Then
                        .setAttribute("CodigoPostal", Me.Emisor.Domicilio.CodigoPostal)
                    End If
                End With

                NodoEmisor.appendChild(NodoEmisorDomicilio)

                NodoComercioExterior.appendChild(NodoEmisor)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Propietario 
            'Nodo condicional para capturar los datos del o los propietarios de la mercancía que se traslada y ésta no sea objeto de enajenación o siéndolo sea a título gratuito, cuando el emisor del CFDI es un tercero.

            If Me.bTienePropietario = True Then
                Dim NodoPropietario As MSXML2.IXMLDOMElement
                NodoPropietario = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, Me.AnexoNodo & "Propietario", Me.xmlns)

                With NodoPropietario
                    If txtLEN(Me.Propietario.NumRegIdTrib) = True Then
                        .setAttribute("NumRegIdTrib", Me.Propietario.NumRegIdTrib)
                    Else
                        MsgBox("El valor de Propietario.NumRegIdTrib es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                        Return ""
                    End If

                    If txtLEN(Me.Propietario.ResidenciaFiscal) = True Then
                        .setAttribute("ResidenciaFiscal", Me.Propietario.ResidenciaFiscal)
                    Else
                        MsgBox("El valor de Propietario.ResidenciaFiscal es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                        Return ""
                    End If
                End With

                NodoComercioExterior.appendChild(NodoPropietario)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Receptor
            If Me.bTieneReceptor = True Then
                Dim NodoReceptor As MSXML2.IXMLDOMElement
                NodoReceptor = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, Me.AnexoNodo & "Receptor", Me.xmlns)

                'En la guia de cce11 dice que Receptor.NumRegIdTrib Este campo no debe registrarse.
                'If txtLEN(Me.Receptor.NumRegIdTrib) = True Then
                '    NodoReceptor.setAttribute("NumRegIdTrib", Me.Receptor.NumRegIdTrib)
                'Else
                '    MsgBox("El valor de Receptor.NumRegIdTrib es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                '    Return ""
                'End If

                Dim NodoReceptorDomicilio As MSXML2.IXMLDOMElement
                NodoReceptorDomicilio = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, Me.AnexoNodo & "Domicilio", Me.xmlns)

                With NodoReceptorDomicilio
                    If txtLEN(Me.Receptor.Domicilio.Calle) = True Then
                        .setAttribute("Calle", Me.Receptor.Domicilio.Calle)
                    Else
                        MsgBox("El valor de Receptor.Domicilio.Calle es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                        Return ""
                    End If

                    If txtLEN(Me.Receptor.Domicilio.NumeroExterior) = True Then
                        .setAttribute("NumeroExterior", Me.Receptor.Domicilio.NumeroExterior)
                    End If

                    If txtLEN(Me.Receptor.Domicilio.Colonia) = True Then
                        .setAttribute("Colonia", Me.Receptor.Domicilio.Colonia)
                    End If

                    If txtLEN(Me.Receptor.Domicilio.Localidad) = True Then
                        .setAttribute("Localidad", Me.Receptor.Domicilio.Localidad)
                    End If

                    If txtLEN(Me.Receptor.Domicilio.Referencia) = True Then
                        .setAttribute("Referencia", Me.Receptor.Domicilio.Referencia)
                    End If

                    If txtLEN(Me.Receptor.Domicilio.Municipio) = True Then
                        .setAttribute("Municipio", Me.Receptor.Domicilio.Municipio)
                    End If

                    If txtLEN(Me.Receptor.Domicilio.Estado) = True Then
                        .setAttribute("Estado", Me.Receptor.Domicilio.Estado)
                    Else
                        MsgBox("El valor de Receptor.Domicilio.Estado es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                        Return ""
                    End If

                    If txtLEN(Me.Receptor.Domicilio.Pais) = True Then
                        .setAttribute("Pais", Me.Receptor.Domicilio.Pais)
                    Else
                        MsgBox("El valor de Receptor.Domicilio.Pais es un dato requerido.", MsgBoxStyle.Exclamation, Me.NombreClase)
                        Return ""
                    End If

                    If txtLEN(Me.Receptor.Domicilio.CodigoPostal) = True Then
                        .setAttribute("CodigoPostal", Me.Receptor.Domicilio.CodigoPostal)
                    End If
                End With

                NodoReceptor.appendChild(NodoReceptorDomicilio)

                NodoComercioExterior.appendChild(NodoReceptor)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Destinatario,opcional
            If bTieneDestinatario = True Then
                Dim NodoDestinatario As MSXML2.IXMLDOMElement
                NodoDestinatario = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, Me.AnexoNodo & "Destinatario", Me.xmlns)

                If txtLEN(Me.Destinatario.NumRegIdTrib) = True Then
                    NodoDestinatario.setAttribute("NumRegIdTrib", Me.Destinatario.NumRegIdTrib)
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

    Public  Function ValidacionesProveedorComplementoExterior() As Boolean
        Dim bResultado As Boolean = False
        Try


            MsgBox("falta meter aqui validaciones tipo proveedor, revisat pdf 1.1, al parecrer si se tiene que poner a fuerza algunos domicilios en 3.3")



            MsgBox("falta validar los datos del domicilio, ya no son del nodo del receptor, hay que ver el cce versión 1.1")
            Return False

            'Dim oPais As New Class_CatPaises(Me.Receptor.Domicilio.Pais)
            'If oPais.Existe = False OrElse Me.Receptor.Domicilio.Pais = "MEX" Then
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
            HandleError(Me.NombreClase, "ValidacionesProveedorComplementoExterior", ex)
        End Try

        Return bResultado
    End Function

End Class
