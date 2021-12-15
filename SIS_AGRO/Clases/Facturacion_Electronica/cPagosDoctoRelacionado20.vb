Option Explicit On

Friend Class cPagosDoctoRelacionado20
    Private Const nombreModulo As String = "cPagosDoctoRelacionado20"

    Public IdDocumento As String
    Public Serie As String
    Public Folio As String
    Public MonedaDR As String
    Public EquivalenciaDR As String
    Public NumParcialidad As String
    Public ImpSaldoAnt As String
    Public ImpPagado As String
    Public ImpSaldoInsoluto As String
    Public ObjetoImpDR As String

    Public TrasladosDR As New iImpuestosTrasladosDR40
    Public RetencionesDR As New iImpuestosRetencionesDR40
End Class
