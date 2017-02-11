Option Strict On

Public Class Frm_CXP_PagosCobrados

    Private iGyFolio As Integer = 1
    Private iGyFecha As Integer = 2
    Private iGyConcepto As Integer = 3
    Private iGyBanco As Integer = 4
    Private iGyTotal As Integer = 5
    Private iGySucursal As Integer = 6
    Private iGyCobrado As Integer = 7

#Region "Opciones"
    Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
        Me.Grabar()
    End Sub

    Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
        Me.Refrescar()
    End Sub

    Private Sub btnMarcarTodos_Click(sender As Object, e As EventArgs) Handles btnMarcarTodos.Click
        Me.MarcarTodos()
    End Sub
#End Region

#Region "Eventos de objetos"
    Private Sub Frm_CXP_PagosCobrados_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Inicializa()
    End Sub

    Private Sub dtFechaMes_ValueChanged(sender As Object, e As EventArgs) Handles dtFechaMes.ValueChanged
        Me.Refrescar()
    End Sub

    Private Sub chkMostrarCobradosMes_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarCobradosMes.CheckedChanged
        Me.Refrescar()
    End Sub

    Private Sub Grid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.DoubleClick
        Dim Columna As Integer, Renglon As Integer, vdg As String

        Columna = Me.Grid.Selection.FirstCol
        Renglon = Me.Grid.Selection.FirstRow
        If Columna = Me.iGyCobrado Then
            Exit Sub
        End If
        vdg = Me.Grid.Cell(Renglon, Me.iGyFolio).Text
        If txtLEN(vdg) = False Then
            Exit Sub
        End If
        Dim Child As New Frm_Contabilidad_Captura_Polizas()
        Child.FolioPolizaConsultaExterior = vdg.ToString
        Child.ShowDialog()
        Child.Dispose()
        'Me.tsbConsultar.PerformClick()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Me.dtFechaMes.Value = Date.Now
        Me.OcultarGrabado()
    End Sub

    Private Sub Refrescar()
        Dim oBancos As New Class_Bancos_CXP()
        Try
            Me.OcultarGrabado()
            Me.Grid.DataSource = oBancos.ObtienePagosGestionCobrados(Me.chkMostrarCobradosMes.Checked, Format(Me.dtFechaMes.Value, "yyyy-dd-MM"))
            Me.FormateaGrid()
            Me.Grid.Visible = True
        Catch ex As Exception
            HandleError(Me.Name, "Refrescar", ex)
            Me.Grid.Visible = True
        End Try
        oBancos = Nothing
    End Sub

    Private Sub FormateaGrid()
        Try
            With Me.Grid
                .Cell(0, Me.iGyFolio).Text = "Folio"
                .Cell(0, Me.iGyFecha).Text = "Fecha"
                .Cell(0, Me.iGyConcepto).Text = "Concepto"
                .Cell(0, Me.iGyBanco).Text = "Banco"
                .Cell(0, Me.iGyTotal).Text = "Total"
                .Cell(0, Me.iGySucursal).Text = "Sucursal"
                .Cell(0, Me.iGyCobrado).Text = "Cobrado"

                .Column(Me.iGyFecha).CellType = FlexCell.CellTypeEnum.DateTime
                .Column(Me.iGyFecha).FormatString = "dd-MMM-yy"

                .Column(Me.iGyCobrado).CellType = FlexCell.CellTypeEnum.CheckBox

                .Column(Me.iGyFolio).Width = 80
                .Column(Me.iGyConcepto).Width = 300
                .Column(Me.iGyBanco).Width = 170

                .Column(Me.iGyFolio).Locked = True
                .Column(Me.iGyFecha).Locked = True
                .Column(Me.iGyConcepto).Locked = True
                .Column(Me.iGyBanco).Locked = True
                .Column(Me.iGyTotal).Locked = True
                .Column(Me.iGySucursal).Locked = True

                '.Locked = True
                .Refresh()

                .Row(.Rows - 1).Locked = True
                .Row(.Rows - 1).Visible = False
            End With

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

    Private Function Grabar() As Boolean
        Dim oBancos As New Class_Bancos_CXP()
        Try
            Me.tsbGrabar.Enabled = False

            Me.OcultarGrabado()
            Me.ProgressBar.Visible = True

            For i As Integer = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.iGyFolio).Text) = True Then
                    oBancos.FOLIO_BANCO = Me.Grid.Cell(i, Me.iGyFolio).Text
                    oBancos.GrabaPagoEstaCobrado(CBool(Me.Grid.Cell(i, Me.iGyCobrado).Text), Me.dtFechaMes.Value)
                End If
                Me.ProgressBar.Value += 1
            Next

            Grabar = True

            Me.lblMsgGrabado.Visible = True
            Me.tsbGrabar.Enabled = True

        Catch ex As Exception
            HandleError(Me.Name, "GrabarEstaCobrado", ex)
            Me.lblMsgGrabado.Visible = False
            Me.tsbGrabar.Enabled = True
        End Try
        oBancos = Nothing
    End Function

    Private Sub OcultarGrabado()
        Me.lblMsgGrabado.Visible = False
        Me.ProgressBar.Value = 0
        Me.ProgressBar.Maximum = Me.Grid.Rows - 1
        Me.ProgressBar.Visible = False
    End Sub

    Private Sub MarcarTodos()
        Try
            For i As Integer = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.iGyFolio).Text) = True Then
                    Me.Grid.Cell(i, Me.iGyCobrado).Text = "1"
                End If
            Next
        Catch ex As Exception
            HandleError(Me.Name, "MarcarTodos", ex)
        End Try
    End Sub
#End Region


End Class