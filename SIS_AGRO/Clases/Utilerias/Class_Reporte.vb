Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows

'CLASE PARA CARGAR UN REPORTE BASADO EN SQL SERVER
Public Class Class_Reporte

#Region "Campos"

#Region "Campos públicos"
    Private _RptCargado As Boolean
#End Region

#Region "Campos privados"
    Private FileRpt As String
    Private FolderRpt As String
    Private sRptLocal As String
    Private sRptServidor As String
#End Region

#End Region

#Region "Propiedades"
    Private ReadOnly Property NombreClase()
        Get
            NombreClase = "Class_Reporte"
        End Get
    End Property

    Public ReadOnly Property RptCargado() As Boolean
        Get
            Return Me._RptCargado
        End Get
    End Property

#End Region

#Region "Constructor y destructor"
    Public Sub New()

    End Sub

    Public Sub New(ByVal NameRpt As String, ByRef Rpt As ReportDocument, Optional ByVal Reporte As Boolean = True)
        Try
            Dim sNombreServidor As String = Split(My.Settings.Servidor, "\")(0)
            Me.FileRpt = NameRpt & ".rpt"
            If Reporte Then
                Me.FolderRpt = "\RPT\"
            Else
                Me.FolderRpt = "\FORMATOS\"
            End If

            Me.sRptLocal = My.Settings.Ruta & FolderRpt & FileRpt
            Me.sRptServidor = "\\" & Split(My.Settings.Servidor, "\")(0) & "\" & IO.Path.GetFileName(My.Settings.Ruta) & FolderRpt & FileRpt

            'MsgBox(sNombreServidor & "-" & System.Windows.Forms.SystemInformation.ComputerName)

            If sNombreServidor.ToUpper <> System.Windows.Forms.SystemInformation.ComputerName.ToUpper Then
                'If System.IO.File.Exists(sRptLocal) = False Then
                Me.CopiaRptServidor()
                'End If
            End If

            Me.CargarRpt(Rpt)
        Catch ex As Exception
            HandleError(Me.NombreClase, "New", ex)
        End Try
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub CopiaRptServidor()
        Try
            If System.IO.File.Exists(sRptServidor) = True Then
                IO.File.Copy(sRptServidor, sRptLocal, True)
            End If
        Catch ex As Exception
            HandleError(Me.NombreClase, "CopiaRptServidor", ex)
        End Try
    End Sub

    Private Sub LogonRpt(ByRef reporte As ReportDocument)
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As CrystalDecisions.CrystalReports.Engine.Tables 'Dim CrTables As Tables
        Dim CrTable As CrystalDecisions.CrystalReports.Engine.Table 'Dim CrTable As Table

        Try
            crConnectionInfo = Loginfo
            CrTables = reporte.Database.Tables

            For Each CrTable In CrTables
                crtableLogoninfo = CrTable.LogOnInfo
                crtableLogoninfo.ConnectionInfo = crConnectionInfo
                CrTable.ApplyLogOnInfo(crtableLogoninfo)
                If CrTable.Location.IndexOf("Proc(") > -1 Then
                    CrTable.Location = crConnectionInfo.DatabaseName & ".dbo." & CrTable.Location.Substring(CrTable.Location.IndexOf("Proc(") + 5, CrTable.Location.LastIndexOf(";1)") - 5)
                Else
                    CrTable.Location = crConnectionInfo.DatabaseName & ".dbo." & CrTable.Location.Substring(CrTable.Location.LastIndexOf(".") + 1)
                End If
            Next

        Catch ex As Exception
            HandleError(Me.NombreClase, "LogonRpt", ex)
        End Try
    End Sub

    Public Sub CargarRpt(ByRef Rpt As ReportDocument)
        Try
            Dim OpenFileDialog1 As New OpenFileDialog()

            With OpenFileDialog1
                .InitialDirectory = My.Settings.Ruta & FolderRpt
                .Filter = "rpt files (*.rpt)|"

                .FilterIndex = 2
                .RestoreDirectory = True
                .FileName = FileRpt
                .Multiselect = False
                .DefaultExt = ".rpt"

                If System.IO.File.Exists(sRptLocal) = True Then
                    Rpt.Load(sRptLocal)
                    LogonRpt(Rpt)
                Else
                    If .ShowDialog() = DialogResult.OK Then
                        Rpt.Load(.FileName)
                        LogonRpt(Rpt)
                    Else
                        Exit Sub
                    End If
                End If

            End With

            Me._RptCargado = True
        Catch ex As Exception
            HandleError(Me.NombreClase, "CargarRpt", ex)
        End Try
    End Sub

#Region "Etc"
    'Private Shared Function genpar(ByVal ParamArray matriz() As String) As ParameterFields
    '    Dim c As Long, p1, p2 As String, l As Integer
    '    Dim parametros As New ParameterFields
    '    For c = 0 To matriz.Length - 1
    '        l = InStr(matriz(CInt(c)), ";")
    '        If l > 0 Then
    '            p1 = Mid(matriz(CInt(c)), 1, l - 1)
    '            p2 = Mid(matriz(CInt(c)), l + 1, Len(matriz(CInt(c))) - l)
    '            Dim parametro As New ParameterField
    '            Dim dVal As New ParameterDiscreteValue
    '            parametro.ParameterFieldName = p1
    '            dVal.Value = p2
    '            parametro.CurrentValues.Add(dVal)
    '            parametros.Add(parametro)
    '        End If
    '    Next
    '    Return (parametros)
    'End Function

    'Public Overloads Shared Sub printrpt(ByVal nombrereporte As String, ByVal ParamArray par() As String)
    'Dim forma As New frmprint
    'Dim rpt As New ReportDocument
    'With forma.CrystalReportViewer1
    'If par.Length > 0 Then
    '.ParameterFieldInfo = genpar(par)
    'End If
    'If rutaRpt.Trim.Length = 0 Then
    'rpt.Load(nombrereporte, OpenReportMethod.OpenReportByDefault)
    'ElseIf Mid(rutaRpt.Trim, rutaRpt.Trim.Length, 1) = "\" Then
    '    rpt.Load(rutaRpt & nombrereporte, OpenReportMethod.OpenReportByDefault)
    'Else
    '    rpt.Load(rutaRpt & "\" & nombrereporte, OpenReportMethod.OpenReportByDefault)
    'End If
    'logonrpt(rpt)
    ''Configurar aquí cualquier opción de exportación 

    'Dim opt As New ExportOptions
    'opt = rpt.ExportOptions
    ''Configurar aquí cualquier opción de impresión 
    'Dim prn As PrintOptions
    'prn = rpt.PrintOptions
    '.ReportSource = rpt
    ''Visualizar el reporte en una ventana nueva 
    'forma.Text = custTitle
    'forma.Show()
    'End With
    'End Sub

    'Public Overloads Shared Sub printrpt(ByVal nombrereporte As String)
    'Dim forma As New frmprint
    'Dim rpt As New ReportDocument
    'With forma.CrystalReportViewer1
    'If rutaRpt.Trim.Length = 0 Then
    'rpt.Load(nombrereporte, OpenReportMethod.OpenReportByDefault)
    'ElseIf Mid(rutaRpt.Trim, rutaRpt.Trim.Length, 1) = "\" Then
    '    rpt.Load(rutaRpt & nombrereporte, OpenReportMethod.OpenReportByDefault)
    'Else
    '    rpt.Load(rutaRpt & "\" & nombrereporte, OpenReportMethod.OpenReportByDefault)
    'End If
    'logonrpt(rpt)
    ''Configurar aquí cualquier opción de exportación 
    'Dim opt As New ExportOptions
    'opt = rpt.ExportOptions
    ''Configurar aquí cualquier opción de impresión
    'Dim prn As PrintOptions
    'prn = rpt.PrintOptions
    '.ReportSource = rpt
    'forma.Show()
    'End With
    'End Sub

    '1)     Invocar la rutina conectar utilizando los parámetros de esta forma:  CR.conectar(SERVIDOR, BASEDATOS, USUARIO, PASSWORD)
    '2)     Especificar la ruta a utilizar para abrir el reporte fijando CR.RPT = Ruta de los reportes
    '3)     Llamar a la rutina CR.printrpt, de cualquiera de las dos formas siguientes:
    '   a)     Si el reporte no utiliza parámetros, solamente debe llamarse CR.printrpt(“reporte.rpt”)
    '   b)     Si el reporte utiliza parámetros, llamarlo de esta forma: CR.printrpt (“reporte.rpt”, “par1;valor”, “par2;valor”, “parN;valor”……)
    '   Por ejemplo: CR.printrpt (“reporte.rpt”, “year;2004”, “mes;10”)
    '   Esto abrirá el reporte y le pasará los parámetros con los valores respectivos.

#End Region

#End Region

End Class


