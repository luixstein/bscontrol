Imports System.Data.SqlClient
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class Frm_Nomina_Credenciales

    'Private Sub btnAgregaFoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'PrintForm1.PrinterSettings.DefaultPageSettings.Color = False
    '    'PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Left = 2
    '    'PrintForm1.PrinterSettings.DefaultPageSettings.PrinterResolution.Kind = Printing.PrinterResolutionKind.High
    '    'PrintForm1.Print()
    'End Sub

    'Private Sub txtCiudad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoTrabajador.KeyDown
    '    If e.KeyCode = Keys.Return Then
    '        If txtLEN(Me.txtCodigoTrabajador.Text) = True Then
    '            Me.TextBox1.Text = "*" & Me.txtCodigoTrabajador.Text & "*"
    '            Me.Label1.Text = "*" & Me.txtCodigoTrabajador.Text & "*"
    '            Me.Label2.Text = "*" & Me.txtCodigoTrabajador.Text & "*"
    '            txtTAB(e)
    '        End If
    '    End If
    'End Sub

    'Private Declare Function PrintWindow Lib "user32.dll" (ByVal _
    'hwnd As IntPtr, ByVal hdcBlt As IntPtr, ByVal nFlags As  _
    'UInt32) As Boolean
    'Dim screenGrab As Bitmap

    'Private Sub CaptureScreen()
    '    'captures Form1 into screenGrab
    '    screenGrab = New Bitmap(Me.Width, Me.Height)
    '    Dim g As Graphics = Graphics.FromImage(screenGrab)
    '    Dim hdc As IntPtr = g.GetHdc
    '    Frm_Nomina_Credenciales.PrintWindow(Me.Handle, hdc, Nothing)
    '    g.ReleaseHdc(hdc)
    '    g.Flush()
    '    g.Dispose()

    'End Sub

    'Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
    '    e.Graphics.DrawImage(screenGrab, 0, 0)
    'End Sub

    'Private Sub PrintButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregaFoto.Click
    '    '---CaptureScreen()
    '    'make landscape print if width > height
    '    PrintDocument1.DefaultPageSettings.Landscape = screenGrab.Width > screenGrab.Height
    '    '---PrintPreviewDialog1.Document = PrintDocument1
    '    '---PrintPreviewDialog1.ShowDialog()

    'End Sub

    Private Sub btnAgregaFoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Me.ImprimirCreedenciales()
    End Sub

    Private Sub Frm_Nomina_Credenciales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtCodigoTrabajador1.Focus()
    End Sub

    Private Sub txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoTrabajador1.KeyPress, txtCodigoTrabajador2.KeyPress, txtCodigoTrabajador3.KeyPress, txtCodigoTrabajador4.KeyPress, btnImprimir.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtCodigoTrabajador1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoTrabajador1.KeyDown
        Dim sCodigo As String
        Dim oTrabajador As New Class_CatTrabajadores

        Select Case e.KeyCode
            Case Keys.F6
                sCodigo = oTrabajador.BusquedaVisual_PorCodigo

                If txtLEN(sCodigo) = True Then
                    Me.txtCodigoTrabajador1.Text = sCodigo
                End If

            Case Keys.Return
                If txtLEN(Me.txtCodigoTrabajador1.Text) = False Then
                    Me.txtCodigoTrabajador2.Focus()
                    Exit Sub
                End If

                oTrabajador = New Class_CatTrabajadores(Me.txtCodigoTrabajador1.Text)
                If oTrabajador.Existe = True Then
                    Me.txtCodigoTrabajador2.Focus()
                    Me.ImprimirCreedenciales()
                    Me.txtCodigoTrabajador2.Focus()
                Else
                    Me.txtCodigoTrabajador2.Focus()
                End If
        End Select
    End Sub

    Private Sub txtCodigoTrabajador2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoTrabajador2.KeyDown
        Dim sCodigo As String
        Dim oTrabajador As New Class_CatTrabajadores

        Select Case e.KeyCode
            Case Keys.F6
                sCodigo = oTrabajador.BusquedaVisual_PorCodigo

                If txtLEN(sCodigo) = True Then
                    Me.txtCodigoTrabajador2.Text = sCodigo
                End If

            Case Keys.Return
                If txtLEN(Me.txtCodigoTrabajador2.Text) = False Then
                    Me.txtCodigoTrabajador3.Focus()
                    Exit Sub
                End If

                oTrabajador = New Class_CatTrabajadores(Me.txtCodigoTrabajador2.Text)
                If oTrabajador.Existe = True Then
                    Me.txtCodigoTrabajador3.Focus()
                    Me.ImprimirCreedenciales()
                    Me.txtCodigoTrabajador3.Focus()
                Else
                    Me.txtCodigoTrabajador3.Focus()
                End If
        End Select
    End Sub

    Private Sub txtCodigoTrabajador3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoTrabajador3.KeyDown
        Dim sCodigo As String
        Dim oTrabajador As New Class_CatTrabajadores

        Select Case e.KeyCode
            Case Keys.F6
                sCodigo = oTrabajador.BusquedaVisual_PorCodigo

                If txtLEN(sCodigo) = True Then
                    Me.txtCodigoTrabajador3.Text = sCodigo
                End If

            Case Keys.Return
                If txtLEN(Me.txtCodigoTrabajador3.Text) = False Then
                    Me.txtCodigoTrabajador4.Focus()
                    Exit Sub
                End If

                oTrabajador = New Class_CatTrabajadores(Me.txtCodigoTrabajador3.Text)
                If oTrabajador.Existe = True Then
                    Me.txtCodigoTrabajador4.Focus()
                    Me.ImprimirCreedenciales()
                    Me.txtCodigoTrabajador4.Focus()
                Else
                    Me.txtCodigoTrabajador4.Focus()
                End If
        End Select
    End Sub

    Private Sub txtCodigoTrabajador4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoTrabajador4.KeyDown
        Dim sCodigo As String
        Dim oTrabajador As New Class_CatTrabajadores

        Select Case e.KeyCode
            Case Keys.F6
                sCodigo = oTrabajador.BusquedaVisual_PorCodigo

                If txtLEN(sCodigo) = True Then
                    Me.txtCodigoTrabajador4.Text = sCodigo
                End If

            Case Keys.Return
                If txtLEN(Me.txtCodigoTrabajador4.Text) = False Then
                    Me.btnImprimir.Focus()
                    Exit Sub
                End If

                oTrabajador = New Class_CatTrabajadores(Me.txtCodigoTrabajador4.Text)
                If oTrabajador.Existe = True Then
                    Me.ImprimirCreedenciales()
                Else
                    Me.btnImprimir.Focus()
                End If
        End Select
    End Sub

    Private Sub ImprimirCreedenciales()
        Dim x As New dsTrabajadores
        Dim oTemporada As New Class_NominaTemporada
        oTemporada.Consultar()

        Dim _Conexion As New SqlConnection(Empresa_Sistema.conexion)

        Dim sql As String = "SELECT " & _
        "DBO.FN_SIS_EMPRESA_NOMBRE_RAZON_SOCIAL() AS EMPRESA_NOMBRE,DBO.FN_SIS_EMPRESA_DOMICILIO() AS EMPRESA_DOMICILIO,   " & _
        "DBO.FN_SIS_EMPRESA_CIUDAD() AS EMPRESA_CIUDAD,DBO.FN_SIS_EMPRESA_ESTADO() AS EMPRESA_ESTADO, " & _
        "DBO.FN_SIS_EMPRESA_RFC() AS EMPRESA_RFC,DBO.FN_SIS_EMPRESA_TELEFONO() AS EMPRESA_TELEFONO,  " & _
        "T.CODIGO_TRABAJADOR,T.NOMBRE_COMPLETO_NOMBRE,T.NOMBRE_TEMPORADA, " & _
        "T.CODIGO_SEXO, T.NOMBRE_SEXO, T.FECHA_NACIMIENTO, DATEDIFF(DAY,T.FECHA_NACIMIENTO,GETDATE())/365 EDAD, " & _
        "T.NUMERO_REGISTRO_IMSS, T.RFC, T.CURP,T.CODIGO_ESTADO_NACIMIENTO, T.NOMBRE_ESTADO, " & _
        "T.CODIGO_PUESTO, T.NOMBRE_PUESTO, T.CODIGO_PUNTO_PAGO, T.NOMBRE_PUNTO_PAGO,'" & _
        oTemporada.NOMBRE_TEMPORADA.ToString & "' TEMPORADA_ACTUAL " & _
        "FROM VW_NOMINA_CAT_TRABAJADORES_EXTENDIDA T " & _
        "WHERE T.CODIGO_TRABAJADOR IN('" & Me.txtCodigoTrabajador1.Text & "','" & Me.txtCodigoTrabajador2.Text & "','" & Me.txtCodigoTrabajador3.Text & "','" & Me.txtCodigoTrabajador4.Text & "') " & _
        "ORDER BY CODIGO_TRABAJADOR"

        Dim da As New SqlDataAdapter(sql, _Conexion)
        da.Fill(x, x.Tables(0).TableName)

        Dim dt As New DataTable
        da.Fill(dt)
        Dim i As Integer = 0
        Dim PathArchivo As String
        Dim im As System.Drawing.Image
        Dim ms As MemoryStream

        For Each drow As DataRow In dt.Rows
            PathArchivo = Plaza.oSisPlazaNomina.NOMINA_RUTA_FOTOS_TRABAJADORES.ToString & "\" & drow(6).ToString & ".jpg"
            If isExisteArchivo(PathArchivo) = True Then
                Dim sPathNew As String = Path.ChangeExtension(PathArchivo, "jpg")
                FileSystem.Rename(PathArchivo, sPathNew)

                Application.DoEvents()

                im = Image.FromFile(PathArchivo)
                ms = New MemoryStream
                im.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                x.Tables(0)(i)("IMAGEN") = ms.ToArray
                im.Dispose()
                ms.Dispose()
                im = Nothing
                ms = Nothing
            End If
            i = i + 1
        Next

        x.AcceptChanges()

        Dim rpt As New rptCredenciales()
        rpt.SetDataSource(x)
        CrystalReportViewer1.ReportSource = rpt
    End Sub
End Class