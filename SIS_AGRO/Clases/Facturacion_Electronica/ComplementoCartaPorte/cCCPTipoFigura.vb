Option Explicit On

Friend Class cCCPTipoFigura
    Private Const NombreClase As String = "cCCPTipoFigura"

    Public TipoFigura As String
    Public RFCFigura As String
    Public NumLicencia As String
    Public NombreFigura As String
    Public NumRegIdTribFigura As String
    Public ResidenciaFiscalFigura As String

    Public PartesTransporte As New cCCPPartesTransporte

    Public bTieneDomicilio As Boolean
    Public Domicilio As New cCCPDomicilio
End Class
