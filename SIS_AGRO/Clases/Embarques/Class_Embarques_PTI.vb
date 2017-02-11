
Public Class Class_Embarques_PTI
    Public Shared Function VoicePicker1(ByVal GTIN14 As String, ByVal Lote As String, ByVal FechaEmpaque As Date) As String
        Return Mid(PTI_dll.VoiceCode.compute(GTIN14, Lote, FechaEmpaque), 1, 2)
    End Function

    Public Shared Function VoicePicker2(ByVal GTIN14 As String, ByVal Lote As String, ByVal FechaEmpaque As Date) As String
        Return Mid(PTI_dll.VoiceCode.compute(GTIN14, Lote, FechaEmpaque), 3, 2)
    End Function

    Public Shared Function Lote(ByVal FechaEmpaque As Date) As String
        Dim oSQl As New Class_find("SELECT LOTE FROM EMB_CAT_LOTES_PROPIOS_POR_FECHA WHERE FECHA='" & Format(FechaEmpaque, "yyyy-dd-MM") & "'")
        Dim sLote As String = oSQl.Result1
        Return sLote
    End Function
End Class
