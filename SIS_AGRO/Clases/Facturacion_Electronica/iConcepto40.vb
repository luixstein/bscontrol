Option Explicit On

Friend Class iConcepto40
    Private Const nombreModulo As String = "iConcepto40"

    Public ClaveProdServ As String
    Public NoIdentificacion As String
    Public Cantidad As String
    Public ClaveUnidad As String
    Public Unidad As String
    Public Descripcion As String
    Public ValorUnitario As String
    Public Importe As String
    Public Descuento As String
    Public ObjetoImp As String

    Public Traslados As New iConceptoImpuestoTraslados40
    Public Retenciones As New iConceptoImpuestoRetenciones40
End Class
