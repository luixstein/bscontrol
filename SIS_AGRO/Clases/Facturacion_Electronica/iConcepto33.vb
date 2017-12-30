Option Explicit On

Friend Class iConcepto33
    Public ClaveProdServ As String
    Public NoIdentificacion As String
    Public Cantidad As String
    Public ClaveUnidad As String
    Public Unidad As String
    Public Descripcion As String
    Public ValorUnitario As String
    Public Importe As String
    Public Descuento As String

    Public Traslados As New iConceptoImpuestoTraslados33
    Public Retenciones As New iConceptoImpuestoRetenciones33
End Class


