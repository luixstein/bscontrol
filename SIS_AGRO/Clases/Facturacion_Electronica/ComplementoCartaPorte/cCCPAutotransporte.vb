Option Explicit On

Friend Class cCCPAutotransporte
    Private Const NombreClase As String = "cCCPAutotransporte"

    Public PermSCT As String
    Public NumPermisoSCT As String

    Public IdentificacionVehicular As New cCCPIdentificacionVehicular
    Public Seguros As New cCCPSeguros
    Public Remolques As New cCCPRemolques
End Class
