Option Explicit On

Friend Class cCCPUbicacion
    Private Const NombreClase As String = "cCCPUbicacion"

    Public TipoUbicacion As String
    Public IDUbicacion As String
    Public RFCRemitenteDestinatario As String
    Public NombreRemitenteDestinatario As String
    Public NumRegIdTrib As String
    Public ResidenciaFiscal As String
    Public NumEstacion As String
    Public NombreEstacion As String
    Public NavegacionTrafico As String
    Public FechaHoraSalidaLlegada As String
    Public TipoEstacion As String
    Public DistanciaRecorrida As String

    Public Domicilio As New cCCPDomicilio
    Public bTieneDomicilio As Boolean
End Class
