Option Explicit On

Friend Class iImpuestos33
    Public Traslados As iImpuestosTraslados33
    Public Retenciones As iImpuestosRetenciones33

    Private Sub Class_Initialize_Renamed()
        Traslados = New iImpuestosTraslados33
        Retenciones = New iImpuestosRetenciones33
    End Sub

    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub

End Class




