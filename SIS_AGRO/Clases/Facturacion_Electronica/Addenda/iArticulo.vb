Option Strict Off
Option Explicit On

Public Class iArticulo
    Public Id As String
    Public RowOrder As String

    'Articulos
    Public Proveedor As String
    Public Remision As String
    Public FolioPedido As String
    Public Tienda As Integer

    Public Codigo As Decimal
    Public CantidadUnidadCompra As Decimal
    Public CostoNetoUnidadCompra As Decimal
    Public PorcentajeIEPS As Decimal
    Public PorcentajeIVA As Decimal
End Class
