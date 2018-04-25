Imports System.Data.SqlClient
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class Frm_Nomina_Credenciales

#Region "Opciones"
    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        'Me.ImprimirCreedenciales()
        Me.ImprimirCreedencialesSP()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Me.Agregar()
    End Sub
#End Region

#Region "Eventos"
    Private Sub Frm_Nomina_Credenciales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.FormateaGrid()

        Me.txtCodigoTrabajador1.Focus()
    End Sub

    Private Sub txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoTrabajador1.KeyPress, txtCodigoTrabajador2.KeyPress, txtCodigoTrabajador3.KeyPress, txtCodigoTrabajador4.KeyPress, _
        btnImprimir.KeyPress, txtTrabajador.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtCodigoTrabajador1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoTrabajador1.KeyDown
        Dim sCodigo As String
        Dim oTrabajador As New Class_CatTrabajadores

        Select Case e.KeyCode
            Case Keys.F6
                sCodigo = oTrabajador.BusquedaVisual_PorDescripcion

                If txtLEN(sCodigo) = True Then
                    Me.txtCodigoTrabajador1.Text = sCodigo
                End If

            Case Keys.Return
                If txtLEN(Me.txtCodigoTrabajador1.Text) = False Then
                    Me.txtCodigoTrabajador2.Focus()
                    Exit Sub
                End If

                oTrabajador = New Class_CatTrabajadores(Me.txtCodigoTrabajador1.Text, True)
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

    Private Sub txtTrabajador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTrabajador.KeyDown
        Dim sCodigo As String
        Dim oTrabajador As New Class_CatTrabajadores

        Select Case e.KeyCode
            Case Keys.F6
busca:
                sCodigo = oTrabajador.BusquedaVisual_PorDescripcion

                If txtLEN(sCodigo) = True Then
                    Me.txtTrabajador.Text = sCodigo
                    GoTo enter
                End If

            Case Keys.F7
                sCodigo = oTrabajador.BusquedaVisual_PorCodigo

                If txtLEN(sCodigo) = True Then
                    Me.txtTrabajador.Text = sCodigo
                    GoTo enter
                End If

            Case Keys.Return
enter:
                If txtLEN(Me.txtTrabajador.Text) = False Then
                    Exit Sub
                End If

                oTrabajador = New Class_CatTrabajadores(Me.txtTrabajador.Text, True)
                If oTrabajador.Existe = True Then
                    Me.lblTrabajador.Text = oTrabajador.NOMBRE_COMPLETO_NOMBRE
                    Me.btnAgregar.Focus()
                Else
                    Me.lblTrabajador.Text = ""
                    GoTo busca : Exit Sub
                End If
        End Select
    End Sub

    Private Sub GridTrabajadores_KeyDown(Sender As Object, e As KeyEventArgs) Handles GridTrabajadores.KeyDown
        Select Case e.KeyCode
            Case Keys.F8, Keys.Delete
                If Me.GridTrabajadores.Rows > 1 Then
                    Me.GridTrabajadores.Selection.DeleteByRow()
                    e.SuppressKeyPress = True
                    Me.GridTrabajadores.Refresh()
                End If
        End Select
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub ImprimirCreedenciales()
        Try
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

        Catch ex As Exception
            HandleError(Me.Name, "ImprimirCreedenciales", ex)
        End Try
    End Sub

    Private Sub ImprimirCreedencialesSP()
        Try

            Dim Rpt As New ReportDocument
            Dim oReporte As Class_Reporte

            oReporte = New Class_Reporte("RPT_NOMINA_CREDENCIALES", Rpt)
            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Dim sListado As String = ""

            For i As Integer = 1 To Me.GridTrabajadores.Rows - 1
                sListado += Me.GridTrabajadores.Cell(i, 1).Text & "|"
            Next

            Rpt.SetParameterValue("@ID_NOMINA_TEMPORADA_ACTUAL", Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA)
            Rpt.SetParameterValue("@LISTA_TRABAJADORES", sListado)

            'Rpt.SetParameterValue("@LISTA_TRABAJADORES", "00003|00004|00001")

            CrystalReportViewer1.ReportSource = Rpt

        Catch ex As Exception
            HandleError(Me.Name, "ImprimirCreedencialesSP", ex)
        End Try
    End Sub

    Private Function Agregar() As Boolean
        Try
            Dim oTrabajador As Class_CatTrabajadores

            If txtLEN(Me.txtTrabajador.Text) = False Then
                MsgBox("Asígne primero un código de trabajador.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtTrabajador.Focus()
                Exit Function
            End If

            oTrabajador = New Class_CatTrabajadores(Me.txtTrabajador.Text, True)
            If oTrabajador.Existe = True Then
                ' oTrabajador.NOMBRE_COMPLETO_NOMBRE
                Me.GridTrabajadores.AddItem(oTrabajador.CODIGO_X_TEMPORADA & Chr(9) & oTrabajador.NOMBRE_COMPLETO_NOMBRE & Chr(9))
            Else
                MsgBox("El trabajador asignado no existe.", MsgBoxStyle.Exclamation, Me.Text)
                Me.lblTrabajador.Text = ""
                Me.txtTrabajador.Focus()
                Exit Function
            End If

            Me.lblTrabajador.Text = ""
            Me.txtTrabajador.Text = ""
            Me.txtTrabajador.Focus()

            Return True

        Catch ex As Exception
            HandleError(Me.Name, "Agregar", ex)
        End Try
    End Function

    Private Sub FormateaGrid()
        Try
            With Me.GridTrabajadores
                .Cols = 3
                .Rows = 1
                .Refresh()

                .Column(1).Width = 70
                .Column(2).Width = 200

                .Cell(0, 1).Text = "Código"
                .Cell(0, 2).Text = "Nombre"
            End With
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

#End Region

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


End Class