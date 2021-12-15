Option Explicit On

Friend Class iImpuestos40
    Public Traslados As iImpuestosTraslados40
    Public Retenciones As iImpuestosRetenciones40

    Private Sub Class_Initialize_Renamed()
        Traslados = New iImpuestosTraslados40
        Retenciones = New iImpuestosRetenciones40
    End Sub

    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub
End Class




