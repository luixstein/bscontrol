Option Strict Off
Option Explicit On
'Imports System.Xml
Imports System.Data
Imports System.Data.SqlClient

Public Class cAddenda

    Public RemisionN As iRemision
    Public Pedidos As iPedidos
    Public Articulos As iArticulos
    Public TipoAddenda As String

    Dim AnexoNodo As String

    Private Sub Class_Initialize_Renamed()
        RemisionN = New iRemision
        Pedidos = New iPedidos
        Articulos = New iArticulos
        AnexoNodo = "cfdi:"
    End Sub

    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub

    Public Function GeneraXMLAddenda() As String
        Dim sResultado As String = ""
        Dim Doc As MSXML2.DOMDocument60 'Documento

        'Dim NdRaiz As MSXML2.IXMLDOMElement 'Raiz
        Doc = New MSXML2.DOMDocument60

        Try
            Doc.async = False
            Doc.validateOnParse = False
            Doc.resolveExternals = False
            Doc.preserveWhiteSpace = True

            '*******NODOS

            'NdRaiz = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "Raiz", "")
            'Doc.appendChild(NdRaiz)

            Dim NdAddenda As MSXML2.IXMLDOMElement 'Addenda
            NdAddenda = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "Addenda", "") ' 

            'NODO DsCargaRemisionProv****************************************************************
            Dim NdDsCargaRemisionProv As MSXML2.IXMLDOMElement 'Nodo DsCargaRemisionProv
            NdDsCargaRemisionProv = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "DSCargaRemisionProv", "")
            NdAddenda.appendChild(NdDsCargaRemisionProv)

            'NODO Remision****************************************************************
            Dim NdRemision As MSXML2.IXMLDOMElement 'Nodo Remision 
            NdRemision = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "Remision", "")

            With NdRemision
                .setAttribute("Id", RemisionN.Id)
                .setAttribute("RowOrder", RemisionN.RowOrder)
            End With

            Dim NdProveedor As MSXML2.IXMLDOMElement 'Nodo Remision
            NdProveedor = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "Proveedor", "")
            NdProveedor.nodeTypedValue = RemisionN.Proveedor
            NdRemision.appendChild(NdProveedor) 'agreagar al nodo emisor

            Dim NdRemisionN As MSXML2.IXMLDOMElement 'Nodo Remision
            NdRemisionN = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "Remision", "")
            NdRemisionN.nodeTypedValue = RemisionN.Remision
            NdRemision.appendChild(NdRemisionN) 'agreagar al nodo emisor

            Dim NdConsecutivo As MSXML2.IXMLDOMElement 'Nodo Remision
            NdConsecutivo = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "Consecutivo", "")
            NdConsecutivo.nodeTypedValue = RemisionN.Consecutivo
            NdRemision.appendChild(NdConsecutivo) 'agreagar al nodo emisor

            Dim NdFechaRemision As MSXML2.IXMLDOMElement 'Nodo Remision
            NdFechaRemision = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "FechaRemision", "")
            NdFechaRemision.nodeTypedValue = RemisionN.FechaRemision
            NdRemision.appendChild(NdFechaRemision) 'agreagar al nodo emisor

            Dim NdTienda As MSXML2.IXMLDOMElement 'Nodo Remision
            NdTienda = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "Tienda", "")
            NdTienda.nodeTypedValue = RemisionN.Tienda
            NdRemision.appendChild(NdTienda) 'agreagar al nodo emisor

            Dim NdTipoMoneda As MSXML2.IXMLDOMElement 'Nodo Remision
            NdTipoMoneda = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "TipoMoneda", "")
            NdTipoMoneda.nodeTypedValue = RemisionN.TipoMoneda
            NdRemision.appendChild(NdTipoMoneda) 'agreagar al nodo emisor

            Dim NdTipoBulto As MSXML2.IXMLDOMElement 'Nodo Remision
            NdTipoBulto = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "TipoBulto", "")
            NdTipoBulto.nodeTypedValue = RemisionN.TipoBulto
            NdRemision.appendChild(NdTipoBulto) 'agreagar al nodo emisor

            Dim NdEntregaMercancia As MSXML2.IXMLDOMElement 'Nodo Remision
            NdEntregaMercancia = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "EntregaMercancia", "")
            NdEntregaMercancia.nodeTypedValue = RemisionN.EntregaMercancia
            NdRemision.appendChild(NdEntregaMercancia) 'agreagar al nodo emisor

            Dim NdCumpleReqFiscales As MSXML2.IXMLDOMElement 'Nodo Remision
            NdCumpleReqFiscales = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "CumpleReqFiscales", "")
            NdCumpleReqFiscales.nodeTypedValue = RemisionN.CumpleReqFiscales
            NdRemision.appendChild(NdCumpleReqFiscales) 'agreagar al nodo emisor

            Dim NdCantidadBultos As MSXML2.IXMLDOMElement 'Nodo Remision
            NdCantidadBultos = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "CantidadBultos", "")
            NdCantidadBultos.nodeTypedValue = RemisionN.CantidadBultos
            NdRemision.appendChild(NdCantidadBultos) 'agreagar al nodo emisor

            Dim NdSubtotal As MSXML2.IXMLDOMElement 'Nodo Remision
            NdSubtotal = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "Subtotal", "")
            NdSubtotal.nodeTypedValue = RemisionN.SubTotal
            NdRemision.appendChild(NdSubtotal) 'agreagar al nodo emisor

            Dim NdDescuentos As MSXML2.IXMLDOMElement 'Nodo Remision
            NdDescuentos = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "Descuentos", "")
            NdDescuentos.nodeTypedValue = RemisionN.Descuentos
            NdRemision.appendChild(NdDescuentos) 'agreagar al nodo emisor

            Dim NdIEPS As MSXML2.IXMLDOMElement 'Nodo Remision
            NdIEPS = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "IEPS", "")
            NdIEPS.nodeTypedValue = RemisionN.IEPS
            NdRemision.appendChild(NdIEPS) 'agreagar al nodo emisor

            Dim NdIVA As MSXML2.IXMLDOMElement 'Nodo Remision
            NdIVA = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "IVA", "")
            NdIVA.nodeTypedValue = RemisionN.IVA
            NdRemision.appendChild(NdIVA) 'agreagar al nodo emisor

            Dim NdOtrosImpuestos As MSXML2.IXMLDOMElement 'Nodo Remision
            NdOtrosImpuestos = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "OtrosImpuestos", "")
            NdOtrosImpuestos.nodeTypedValue = RemisionN.OtrosImpuestos
            NdRemision.appendChild(NdOtrosImpuestos) 'agreagar al nodo emisor

            Dim NdTotal As MSXML2.IXMLDOMElement 'Nodo Remision
            NdTotal = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "Total", "")
            NdTotal.nodeTypedValue = RemisionN.Total
            NdRemision.appendChild(NdTotal) 'agreagar al nodo emisor

            Dim NdCantidadPedidos As MSXML2.IXMLDOMElement 'Nodo Remision
            NdCantidadPedidos = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "CantidadPedidos", "")
            NdCantidadPedidos.nodeTypedValue = RemisionN.CantidadPedidos
            NdRemision.appendChild(NdCantidadPedidos) 'agreagar al nodo emisor

            Dim NdFechaEntregaMercancia As MSXML2.IXMLDOMElement 'Nodo Remision
            NdFechaEntregaMercancia = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "FechaEntregaMercancia", "")
            NdFechaEntregaMercancia.nodeTypedValue = RemisionN.FechaEntregaMercancia
            NdRemision.appendChild(NdFechaEntregaMercancia) 'agreagar al nodo emisor

            'If RemisionN.Cita.Length > 0 Then 'Es addenda normal
            'ElseIf RemisionN.FolioNotaEntrada.Length > 0 Then 'Es addenda extemporanea
            'Else
            'MsgBox("Tipo de addenda no reconcida, ni normal ni extemporánea.", MsgBoxStyle.Exclamation, "cAddenda")
            'End If

            Select Case Me.TipoAddenda
                Case "N" 'Addenda normal
                    Dim NdCita As MSXML2.IXMLDOMElement 'Nodo Remision
                    NdCita = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "Cita", "")
                    NdCita.nodeTypedValue = RemisionN.Cita
                    NdRemision.appendChild(NdCita) 'agreagar al nodo emisor
                Case "E" 'Addenda extemporanea
                    Dim NdFolioNotaEntrada As MSXML2.IXMLDOMElement 'Nodo Remision
                    NdFolioNotaEntrada = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "FolioNotaEntrada", "")
                    NdFolioNotaEntrada.nodeTypedValue = RemisionN.FolioNotaEntrada
                    NdRemision.appendChild(NdFolioNotaEntrada) 'agreagar al nodo emisor
            End Select

            NdDsCargaRemisionProv.appendChild(NdRemision)

            'NODO Redidos****************************************************************
            Dim NdPedidos As MSXML2.IXMLDOMElement 'Nodo Pedidos
            NdPedidos = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "Pedidos", "")

            With NdPedidos
                .setAttribute("Id", Pedidos.Id)
                .setAttribute("RowOrder", Pedidos.RowOrder)
            End With

            Dim NdPedidosProveedor As MSXML2.IXMLDOMElement 'Nodo Pedidos
            NdPedidosProveedor = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "Proveedor", "")
            NdPedidosProveedor.nodeTypedValue = Pedidos.Proveedor
            NdPedidos.appendChild(NdPedidosProveedor) 'agreagar al nodo Pedidos

            Dim NdPedidosRemision As MSXML2.IXMLDOMElement 'Nodo Pedidos
            NdPedidosRemision = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "Remision", "")
            NdPedidosRemision.nodeTypedValue = Pedidos.Remision
            NdPedidos.appendChild(NdPedidosRemision) 'agreagar al nodo Pedidos

            Dim NdFolioPedido As MSXML2.IXMLDOMElement 'Nodo Pedidos
            NdFolioPedido = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "FolioPedido", "")
            NdFolioPedido.nodeTypedValue = Pedidos.FolioPedido
            NdPedidos.appendChild(NdFolioPedido) 'agreagar al nodo Pedidos

            Dim NdPedidoTienda As MSXML2.IXMLDOMElement 'Nodo Pedidos
            NdPedidoTienda = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "Tienda", "")
            NdPedidoTienda.nodeTypedValue = Pedidos.Tienda
            NdPedidos.appendChild(NdPedidoTienda) 'agreagar al nodo Pedidos

            Dim NdCantidadArticulos As MSXML2.IXMLDOMElement 'Nodo Pedidos
            NdCantidadArticulos = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "CantidadArticulos", "")
            NdCantidadArticulos.nodeTypedValue = Pedidos.CantidadArticulos
            NdPedidos.appendChild(NdCantidadArticulos) 'agreagar al nodo Pedidos

            'If RemisionN.FolioNotaEntrada.Length > 0 Then 'Es addenda extemporanea
            Select Case Me.TipoAddenda
                Case "N" 'Addenda normal
                    'No lleva este nodo de NdPedidoEmitidoProveedor
                Case "E" 'Addenda extemporanea
                    Dim NdPedidoEmitidoProveedor As MSXML2.IXMLDOMElement 'Nodo Pedidos
                    NdPedidoEmitidoProveedor = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "PedidoEmitidoProveedor", "")
                    NdPedidoEmitidoProveedor.nodeTypedValue = "SI"
                    NdPedidos.appendChild(NdPedidoEmitidoProveedor) 'agreagar al nodo Pedidos
            End Select

            NdDsCargaRemisionProv.appendChild(NdPedidos)

            'NODO Articulos****************************************************************
            'barrer coleccion de Articulos

            Dim i As Integer
            For i = 1 To CInt(Pedidos.CantidadArticulos)
                Dim NdArticulos As MSXML2.IXMLDOMElement 'Nodo Articulo
                NdArticulos = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "Articulos", "")

                With NdArticulos
                    .setAttribute("Id", Articulos.Item(i).Id)
                    .setAttribute("RowOrder", i.ToString)
                End With

                Dim NdArticulosProveedor As MSXML2.IXMLDOMElement 'Nodo articulo
                NdArticulosProveedor = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "Proveedor", "")
                NdArticulosProveedor.nodeTypedValue = Articulos.Item(i).Proveedor
                NdArticulos.appendChild(NdArticulosProveedor) 'agreagar al nodo articulo

                Dim NdArticulosRemision As MSXML2.IXMLDOMElement 'Nodo articulo
                NdArticulosRemision = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "Remision", "")
                NdArticulosRemision.nodeTypedValue = Articulos.Item(i).Remision
                NdArticulos.appendChild(NdArticulosRemision) 'agreagar al nodo articulo

                Dim NdArticulosFolioPedido As MSXML2.IXMLDOMElement 'Nodo articulo
                NdArticulosFolioPedido = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "FolioPedido", "")
                NdArticulosFolioPedido.nodeTypedValue = Articulos.Item(i).FolioPedido
                NdArticulos.appendChild(NdArticulosFolioPedido) 'agreagar al nodo articulo

                Dim NdArticulosPedidoTienda As MSXML2.IXMLDOMElement 'Nodo articulo
                NdArticulosPedidoTienda = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "Tienda", "")
                NdArticulosPedidoTienda.nodeTypedValue = Articulos.Item(i).Tienda
                NdArticulos.appendChild(NdArticulosPedidoTienda) 'agreagar al nodo articulo

                Dim NdCodigo As MSXML2.IXMLDOMElement 'Nodo articulo
                NdCodigo = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "Codigo", "")
                NdCodigo.nodeTypedValue = Articulos.Item(i).Codigo
                NdArticulos.appendChild(NdCodigo) 'agreagar al nodo articulo

                Dim NdCantidadUnidadCompra As MSXML2.IXMLDOMElement 'Nodo articulo
                NdCantidadUnidadCompra = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "CantidadUnidadCompra", "")
                NdCantidadUnidadCompra.nodeTypedValue = Articulos.Item(i).CantidadUnidadCompra
                NdArticulos.appendChild(NdCantidadUnidadCompra) 'agreagar al nodo articulo

                Dim NdCostoNetoUnidadCompra As MSXML2.IXMLDOMElement 'Nodo articulo
                NdCostoNetoUnidadCompra = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "CostoNetoUnidadCompra", "")
                NdCostoNetoUnidadCompra.nodeTypedValue = Articulos.Item(i).CostoNetoUnidadCompra
                NdArticulos.appendChild(NdCostoNetoUnidadCompra) 'agreagar al nodo articulo

                Dim NdPorcentajeIEPS As MSXML2.IXMLDOMElement 'Nodo articulo
                NdPorcentajeIEPS = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "PorcentajeIEPS", "")
                NdPorcentajeIEPS.nodeTypedValue = Articulos.Item(i).PorcentajeIEPS
                NdArticulos.appendChild(NdPorcentajeIEPS) 'agreagar al nodo articulo

                Dim PorcentajeIVA As MSXML2.IXMLDOMElement 'Nodo articulo
                PorcentajeIVA = Doc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, "PorcentajeIVA", "")
                PorcentajeIVA.nodeTypedValue = Articulos.Item(i).PorcentajeIVA
                NdArticulos.appendChild(PorcentajeIVA) 'agreagar al nodo articulo

                NdDsCargaRemisionProv.appendChild(NdArticulos)
            Next
            Doc.appendChild(NdAddenda)

            sResultado = Doc.xml

        Catch ex As Exception
            HandleError("cAddenda", "Addenda", ex)
        End Try

        Return sResultado
    End Function

End Class
