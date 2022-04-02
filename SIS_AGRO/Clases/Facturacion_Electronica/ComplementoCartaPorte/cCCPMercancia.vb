Option Explicit On

Friend Class cCCPMercancia
    Private Const NombreClase As String = "cCCPMercancia"

    Public BienesTransp As String
    Public ClaveSTCC As String
    Public Descripcion As String
    Public Cantidad As String
    Public ClaveUnidad As String
    Public Unidad As String
    Public Dimensiones As String
    Public MaterialPeligroso As String
    Public CveMaterialPeligroso As String
    Public Embalaje As String
    Public DescripEmbalaje As String
    Public PesoEnKg As String
    Public ValorMercancia As String
    Public Moneda As String
    Public FraccionArancelaria As String
    Public UUIDComercioExt As String

    Public Pedimentos As New cCCPPedimentos 'Colección, permite más de uno
    Public GuiasIdentificacion As New cCCPGuiasIdentificacion 'Colección, permite más de uno
    Public CantidadesTransporta As New cCCPCantidadesTransporta 'Colección, permite más de uno

    Public bTieneDetalleMercancia As Boolean
    Public DetalleMercancia As New cCCPDetalleMercancia
End Class
