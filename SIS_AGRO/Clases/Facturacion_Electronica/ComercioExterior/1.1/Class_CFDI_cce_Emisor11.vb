Option Strict Off
Option Explicit On

Friend Class Class_CFDI_cce_Emisor11
    Public Curp As String

    Public Domicilio As Class_CFDI_cce_EmisorDomicilio11

    'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Initialize_Renamed()
        Domicilio = New Class_CFDI_cce_EmisorDomicilio11
    End Sub

    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub
End Class