Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports System.Data.OleDb


Public Class Frm_NumeroSeguro

    'Dim m_Excel As Excel.application
    'Dim oExcel As Excel.ApplicationClass
    'Dim oBooks As Excel.Workbooks
    'Dim oBook As Excel.WorkbookClass
    'Dim oSheet As Excel.Worksheet

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dTabla As DataTable
        Dim sRenglon As String = Nothing
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim PathArchivo As String = "", sCarpeta As String = ""
        Dim sNombreTxt As String = ""
        Const DELIMITADOR As String = ","


        Dim oSemana As Class_NominaSemana
        oSemana = New Class_NominaSemana(Plaza.oSisPlazaNomina.NOMINA_NUMERO_SEMANA_ACTUAL)

        sCarpeta = "C:\AGROCONTROL\NOMINA\CULIACAN\ALTAS_IMSS\" & "SEM" & oSemana.NUMERO_SEMANA.ToString

        If Directory.Exists(sCarpeta) = False Then ' si no existe la carpeta se crea
            Directory.CreateDirectory(sCarpeta)
        Else
            'Elimina todos los txt que empiezan con la palabra ALTA_
            For Each fichero As String In Directory.GetFiles(sCarpeta, "archivo_*.csv")
                File.Delete(fichero)
            Next
        End If

        sNombreTxt = "archivo_" & Plaza.oSisPlazaNomina.NOMINA_NUMERO_SEMANA_ACTUAL

        PathArchivo = sCarpeta & "\" & sNombreTxt & ".csv"

        If isExisteArchivo(PathArchivo) = True Then
            File.Delete(PathArchivo)
            strStreamW = File.Create(PathArchivo)
        Else
            strStreamW = File.Create(PathArchivo)
        End If

        strStreamWriter = New StreamWriter(strStreamW) ', System.Text.Encoding.Default

        Try
            Dim oSua As New Class_Nomina_SUA

            'Using archivo As StreamWriter = New StreamWriter(PathArchivo)
            ' variable para almacenar la línea actual del dataview
            'Dim linea As String = String.Empty

            dTabla = oSua.ObtenerTrabajadoresSinIMSS
            strStreamWriter.WriteLine("Código trabajador" & DELIMITADOR & "Nombre " & DELIMITADOR & "Apellido Paterno" & DELIMITADOR & "Apellido Materno" & DELIMITADOR & _
                                   "Sexo" & DELIMITADOR & "Fecha nacimiento" & DELIMITADOR & "Estado" & DELIMITADOR & "Afiliable")
            With dTabla
                ' Recorrer las filas del dataGridView
                For Each drow As DataRow In dTabla.Rows
                    ' vaciar la línea
                    'linea = String.Empty
                    ' Recorrer la cantidad de columnas que contiene el dataGridView
                    'For col As Integer = 0 To .Columns.Count - 1
                    '    ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador
                    '    linea = linea & drow(col).ToString & DELIMITADOR
                    'Next
                    '' Escribir una línea con el método WriteLine
                    'With archivo
                    '    ' eliminar el último caracter ";" de la cadena
                    '    linea = linea.Remove(linea.Length - 1).ToString
                    '    ' escribir la fila
                    '    .WriteLine(linea.ToString)
                    'End With
                    strStreamWriter.WriteLine(drow(0).ToString & DELIMITADOR & drow(1).ToString & DELIMITADOR & drow(2).ToString & DELIMITADOR & drow(3).ToString & DELIMITADOR & _
                                   drow(4).ToString & DELIMITADOR & drow(5).ToString & DELIMITADOR & drow(6).ToString & DELIMITADOR & drow(7).ToString)
                Next
            End With
            ' End Using
            strStreamWriter.Close() 'Cerramos
            ' Abrir con Process.Start el archivo de texto
            Process.Start(PathArchivo)
            'error
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class