Option Strict Off
Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Imports System.Xml.XmlDocument

Public Class Addenda
    Private docXmlFactura As Xml.XmlDocument 'AS docXmlFactura = NEW XML.XMLDOCUMENT
    Private XMLAddenda As String
    Private _sRutaXML As String

    Private oVenta As Class_Ventas_Global

    Private Const nombreModulo As String = "Addenda"

    Private CfdAddenda As New cAddenda
    'Dim oVenta As New Class_Ventas_Global
    Dim oTiendaSoriana As New Class_CatTiendasSoriana




#Region "Campos de sistema"
    Private _Nombre_Catalogo As String = "AddendaFacturacionElectronica"
    Private _Conexion As New SqlConnection(Empresa_Sistema.conexion)
#End Region


    Public Sub New(ByVal oVenta As Class_Ventas_Global, ByVal sRuta As String)
        Try
            Me.oVenta = oVenta
            Me._sRutaXML = sRuta

        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "New", ex)
        End Try
    End Sub

    Public Function GeneraAddenda() As Boolean
        Try
            Dim oCatAddenda As New Class_CatAddenda(oVenta.FOLIO_VENTA)

            CfdAddenda = New cAddenda

            CfdAddenda.TipoAddenda = oCatAddenda.TIPO_ADDENDA
            CfdAddenda.RemisionN.Id = "Remision0"
            CfdAddenda.RemisionN.RowOrder = "0"

            CfdAddenda.RemisionN.Proveedor = Empresa_Sistema.CODIGO_PROVEDOR_SORIANA
            CfdAddenda.RemisionN.Remision = oVenta.FOLIO_VENTA
            CfdAddenda.RemisionN.Consecutivo = "0"
            CfdAddenda.RemisionN.FechaRemision = Format(oVenta.FECHA, "yyyy-MM-dd") & "T" & "00:00:00"
            CfdAddenda.RemisionN.Tienda = oCatAddenda.CODIGO_TIENDA_SORIANA
            CfdAddenda.RemisionN.TipoMoneda = oCatAddenda.TIPO_MONEDA
            CfdAddenda.RemisionN.TipoBulto = oCatAddenda.TIPO_BULTO
            oTiendaSoriana = New Class_CatTiendasSoriana(oCatAddenda.CODIGO_TIENDA_SORIANA.ToString)
            CfdAddenda.RemisionN.EntregaMercancia = oTiendaSoriana.ID_TIENDA_SORIANA
            CfdAddenda.RemisionN.CumpleReqFiscales = "true"
            'Dim CantidadBultosVenta As New Class_find("SELECT sum(CANTIDAD) FROM VENTA_DETALLE WHERE FOLIO_VENTA='" & sFolio & "' ")
            'CfdAddenda.RemisionN.CantidadBultos = CantidadBultosVenta.Result1
            CfdAddenda.RemisionN.CantidadBultos = oCatAddenda.CANTIDAD_BULTOS
            CfdAddenda.RemisionN.SubTotal = oVenta.SUBTOTAL
            CfdAddenda.RemisionN.Descuentos = 0
            CfdAddenda.RemisionN.IEPS = 0
            CfdAddenda.RemisionN.IVA = oVenta.IMPUESTO
            CfdAddenda.RemisionN.OtrosImpuestos = 0
            CfdAddenda.RemisionN.Total = oVenta.TOTAL
            CfdAddenda.RemisionN.CantidadPedidos = 1
            CfdAddenda.RemisionN.FechaEntregaMercancia = Format(oCatAddenda.FECHA_ENTREGA, "yyyy-MM-dd") & "T" & "00:00:00"
            CfdAddenda.RemisionN.Cita = oCatAddenda.CITA
            CfdAddenda.RemisionN.FolioNotaEntrada = oCatAddenda.FOLIO_NOTA_ENTRADA

            ''Pedidos
            CfdAddenda.Pedidos.Id = "Pedidos1"
            CfdAddenda.Pedidos.RowOrder = "1"

            CfdAddenda.Pedidos.Proveedor = Empresa_Sistema.CODIGO_PROVEDOR_SORIANA
            CfdAddenda.Pedidos.Remision = oVenta.FOLIO_VENTA
            CfdAddenda.Pedidos.FolioPedido = oCatAddenda.FOLIO_PEDIDO
            CfdAddenda.Pedidos.Tienda = oCatAddenda.CODIGO_TIENDA_SORIANA

            Dim CantidadArticulos As New Class_find("SELECT count(*) FROM VENTA_DETALLE WHERE FOLIO_VENTA='" & oVenta.FOLIO_VENTA & "' ")
            CfdAddenda.Pedidos.CantidadArticulos = CantidadArticulos.Result1

            For Each row As DataRow In oVenta.ObtenerDetalle.Rows
                'CfdAddenda.Articulos.Id = row("CODIGO_ARTICULO")
                CfdAddenda.Articulos.Proveedor = Empresa_Sistema.CODIGO_PROVEDOR_SORIANA
                CfdAddenda.Articulos.Remision = oVenta.FOLIO_VENTA
                CfdAddenda.Articulos.FolioPedido = oCatAddenda.FOLIO_PEDIDO
                CfdAddenda.Articulos.Tienda = oCatAddenda.CODIGO_TIENDA_SORIANA
                CfdAddenda.Articulos.Codigo = row("CODIGO_ARTICULO")

                If row("ES_PRODUCTO_KILOS") = "1" Then
                    CfdAddenda.Articulos.CantidadUnidadCompra = row("CANTIDAD_KILOS")
                    CfdAddenda.Articulos.CostoNetoUnidadCompra = row("PRECIO_KILOS")
                Else
                    CfdAddenda.Articulos.CantidadUnidadCompra = row("CANTIDAD")
                    CfdAddenda.Articulos.CostoNetoUnidadCompra = row("PRECIO")
                End If
                CfdAddenda.Articulos.PorcentajeIEPS = row("IMPUESTO_PORCENTAJE")
                CfdAddenda.Articulos.PorcentajeIVA = row("IMPUESTO_PORCENTAJE")

                CfdAddenda.Articulos.Add(row("CODIGO_ARTICULO"))
            Next

            Me.XMLAddenda = CfdAddenda.GeneraXMLAddenda()

            If txtLEN(Me.XMLAddenda) = False Then
                MsgBox("No se pudo generar XML de la Addenda.", MsgBoxStyle.Exclamation, Me._Nombre_Catalogo)
                Exit Function
            End If

            If Me.RecuperaXMLSinAddenda() = False Then
                MsgBox("No se puedo recuperar XML sin Addenda.", MsgBoxStyle.Exclamation, Me._Nombre_Catalogo)
                Exit Function
            End If

            Me.GeneraXMLAddenda()

            GeneraAddenda = True
            'CfdAddenda = New cAddenda 'vaciar el comprobante

        Catch ex As Exception
            _Conexion.Close()
            HandleError(_Nombre_Catalogo, "GeneraAddenda", ex)
        End Try
    End Function

    Public Function RecuperaXMLSinAddenda() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter

        _Conexion.Close()

        Try

            With cmd
                .Connection = _Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure

                .Parameters.Clear()

                .CommandText = "MP_VENTAS_CFD_RECUPERA_CADENA_XML"

                sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me.oVenta.FOLIO_VENTA
                sqlParametro = .Parameters.Add("@CADENA_XML", SqlDbType.Xml) : sqlParametro.Direction = ParameterDirection.Output : sqlParametro.Value = "" 'XmlDoc.OuterXml

                _Conexion.Open()
                .ExecuteNonQuery()

                'Agrega al documento XML la cadena que ya esta grabada
                docXmlFactura = New Xml.XmlDocument
                docXmlFactura.LoadXml(.Parameters("@CADENA_XML").Value.ToString)

                'Crea el nodo principal o primera linea <?xml version="1.0"?>
                Dim Nodo As Xml.XmlDeclaration
                Nodo = docXmlFactura.CreateXmlDeclaration("1.0", "utf-8", Nothing)
                'Agrega el nodo al documento
                Dim root As Xml.XmlElement = docXmlFactura.DocumentElement
                docXmlFactura.InsertBefore(Nodo, root)
                'docXmlFactura.Save(sRutaXML)

                If txtLEN(Me.docXmlFactura.InnerXml) = True Then
                    RecuperaXMLSinAddenda = True
                End If

            End With
            cmd = Nothing
            _Conexion.Close()
            Exit Function

        Catch ex As Exception
            HandleError(_Nombre_Catalogo, "RecuperaXMLSinAddenda", ex)
        End Try
    End Function

    Private Function ConvierteXMLUTF8(ByVal sRutaXML As String) As Boolean
        Try
            Dim Var As Object
            Var = Shell(sFelectronicaConvierteUTF8Local & " """ & sRutaXML & """", AppWinStyle.MinimizedFocus)

            ConvierteXMLUTF8 = True

        Catch ex As Exception
            HandleError(_Nombre_Catalogo, "ConvierteXMLUTF8", ex)
        End Try
    End Function

    Private Function GrabarAdenda() As Boolean
        Try
            Dim sCadenaXml As String
            sCadenaXml = Me.docXmlFactura.InnerXml.Replace("<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & "?>", "")

            Dim cmd As New SqlCommand
            Dim sqlParametro As SqlParameter
            _Conexion.Close()

            With cmd
                .Connection = _Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure

                .CommandText = "MP_VENTA_GRABA_ADENDA_XML"
                sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me.oVenta.FOLIO_VENTA
                sqlParametro = .Parameters.Add("@CADENA_XML", SqlDbType.Xml) : sqlParametro.Value = sCadenaXml

                _Conexion.Open()
                .ExecuteNonQuery()
            End With
            cmd = Nothing

            GrabarAdenda = True

            Exit Function
        Catch ex As Exception
            _Conexion.Close()
            HandleError(_Nombre_Catalogo, "GrabarAdenda", ex)
        End Try
    End Function

    Public Function GeneraXMLAddenda() As Boolean
        Try
            Dim namespaces As New XmlNamespaceManager(docXmlFactura.NameTable)
            namespaces.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")

            'Quitamos el nodo Addenda en caso de que ya lo tenga.
            Dim child As XmlNode
            child = docXmlFactura.SelectSingleNode("//cfdi:Addenda", namespaces)
            If Not child Is Nothing Then
                docXmlFactura.SelectSingleNode("//cfdi:Comprobante", namespaces).RemoveChild(child)
            End If
            'child = docXmlFactura.SelectSingleNode("/")

            'Concatenamos al xml sin addenda la addenda
            Dim s As String
            s = docXmlFactura.InnerXml
            s = Replace(s, "</cfdi:Comprobante>", "")
            s += Replace(Me.docXmlFactura.InnerText + Me.XMLAddenda, "Addenda", "cfdi:Addenda") + "</cfdi:Comprobante>"

            docXmlFactura.LoadXml(s)

            'Antes teniamos, pero no funciona con el prefijo cfdi
            'Dim AddendaXml As Xml.XmlDocument = New Xml.XmlDocument
            'AddendaXml.LoadXml(xmlDoc.xml)
            'Dim nodoAddenda As XmlNode = docXmlFactura.ImportNode(AddendaXml.DocumentElement, True)
            'docXmlFactura.DocumentElement.AppendChild(nodoAddenda)

            docXmlFactura.Save(Me._sRutaXML)
            ConvierteXMLUTF8(Me._sRutaXML)

            GeneraXMLAddenda = Me.GrabarAdenda()

        Catch ex As Exception
            HandleError(_Nombre_Catalogo, "GeneraXMLAddenda", ex)
        End Try
    End Function

End Class