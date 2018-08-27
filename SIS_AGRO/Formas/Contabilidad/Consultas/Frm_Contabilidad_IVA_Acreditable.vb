Option Strict On
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_Contabilidad_IVA_Acreditable

    Private FormatoDeReporte As String

#Region "Constructor y destructor"
    Public Sub New()
        InitializeComponent()
        DesplegarEjercicios()
        EmpresaParametros = New Class_SisContabilidadParametros
        Inicializa()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region

#Region "Opciones"
    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub cmdGeneraArchivoBatch_Click(sender As Object, e As EventArgs) Handles cmdGeneraArchivoBatch.Click
        Me.GeneraArchivoBatch()
    End Sub
#End Region

#Region "Eventos"

    Private Sub CmbEjercicio_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEjercicio.SelectedIndexChanged
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Me.CmbEjercicio.SelectedValue.ToString)
        Me.DtFechaDesde.Value = CDate(sql.Result1)
        Me.DtFechaHasta.Value = CDate(sql.Result2)
    End Sub

    Private Sub DtFechaHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFechaHasta.ValueChanged
        If Me.Visible = False Then
            Exit Sub
        End If
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue.ToString & "'")
        If Me.DtFechaHasta.Value < CDate(sql.Result1) Then
            Me.DtFechaHasta.Value = CDate(sql.Result1)
        End If
        If Me.DtFechaHasta.Value > CDate(sql.Result2) Then
            Me.DtFechaHasta.Value = CDate(sql.Result2)
        End If
    End Sub

    Private Sub DtFechaDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFechaDesde.ValueChanged
        If Me.Visible = False Then
            Exit Sub
        End If
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue.ToString & "'")
        If Me.DtFechaDesde.Value < CDate(sql.Result1) Then
            Me.DtFechaDesde.Value = CDate(sql.Result1)
        End If
        If Me.DtFechaDesde.Value > CDate(sql.Result2) Then
            Me.DtFechaDesde.Value = CDate(sql.Result2)
        End If
    End Sub

    Private Sub txtCodigoProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoProveedor.KeyDown

        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                Dim Busqueda = New Busqueda_General("CODIGO_PROVEEDOR AS CODIGO,NOMBRE_PROVEEDOR AS NOMBRE", "Cat_Proveedores", " 1=1 and Estatus='A' ", "Nombre", "Nombre_Proveedor")
                Busqueda.ShowDialog()
                Me.txtCodigoProveedor.Text = "" & Busqueda.Tag.ToString
                Busqueda.Dispose()

            Case Keys.Enter
                If txtLEN(Me.txtCodigoProveedor.Text) = False Then
                    Me.lblNombreProveedor.Text = ""
                    Me.txtCodigoProveedor.Focus()
                    'GoTo Buscar
                    Me.RdbDetalle.Focus()
                    Exit Sub
                End If
                Dim sql As New Class_find("Select NOMBRE_PROVEEDOR From CAT_PROVEEDORES Where CODIGO_PROVEEDOR='" & Me.txtCodigoProveedor.Text & "' and Estatus='A'")
                If sql.Result1 = "" Then
                    MsgBox("El código de proveedor que intenta buscar no existe o esta dado de baja, favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de Proveedores")
                    Me.lblNombreProveedor.Text = ""
                    GoTo Buscar : Exit Sub
                Else
                    Me.lblNombreProveedor.Text = sql.Result1
                End If
                sql = Nothing

            Case Keys.F4
                Dim Child As New Catalogo_Proveedores()
                Child.tsbNuevo.PerformClick()
                Child.ShowDialog()
                Child.Dispose()
        End Select
    End Sub

    Private Sub rbFormatoSAT_CheckedChanged(sender As Object, e As EventArgs) Handles rbFormatoSAT.CheckedChanged
        If Me.rbFormatoSAT.Checked = True Then
            Me.gbAgrupado.Visible = False
        Else
            Me.gbAgrupado.Visible = True
        End If
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Private Sub Inicializa()
        Me.CmbEjercicio.SelectedValue = Plaza.ID_CON_EJERCICIO
        Me.DtFechaDesde.Value = Plaza.FECHA_INICIO
        Me.DtFechaHasta.Value = Plaza.FECHA_FINAL
        Me.txtCodigoProveedor.Text = ""
        Me.lblNombreProveedor.Text = ""
        Me.CmbEstatusIva.SelectedIndex = 0
        Me.CmbEstatusPoliza.SelectedIndex = 0
    End Sub

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            If Me.ValidarPeriodo = False Then
                Exit Sub
            End If

            If Me.RdbDetalle.Checked = True And Me.RdbProveedor.Checked = True Then
                Me.FormatoDeReporte = "RPT_CONTABILIDAD_IVA_ACREDITABLE_DETALLE_11_16"
            ElseIf Me.RdbDetalle.Checked = True And Me.RdbPoliza.Checked = True Then
                Me.FormatoDeReporte = "RPT_CONTABILIDAD_IVA_ACREDITABLE_DETALLE_POLIZA"
            ElseIf Me.RdbGlobal.Checked = True And Me.RdbProveedor.Checked = True Then
                Me.FormatoDeReporte = "RPT_CONTABILIDAD_IVA_ACREDITABLE_GLOBAL_11_16"
            ElseIf Me.RdbGlobal.Checked = True And Me.RdbPoliza.Checked = True Then
                Me.FormatoDeReporte = "RPT_CONTABILIDAD_IVA_ACREDITABLE_GLOBAL_POLIZA"
            ElseIf Me.rbFormatoSAT.Checked = True Then
                Me.FormatoDeReporte = "RPT_CONTABILIDAD_IVA_ACREDITABLE_DETALLE_SAT"
            Else
                MsgBox("Formato no válido.", MsgBoxStyle.Exclamation, "Imprimir")
                Exit Sub
            End If

            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)
            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@FECHA_INICIO", Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA_FINAL", Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@ID_CON_EJERCICIO", Me.CmbEjercicio.SelectedValue)
            Rpt.SetParameterValue("@CODIGO_PROVEEDOR", "" & Me.txtCodigoProveedor.Text)
            Rpt.SetParameterValue("@ESTATUS_IVA", Me.CmbEstatusIva.Text)
            Rpt.SetParameterValue("@ESTATUS_POLIZA", Me.CmbEstatusPoliza.Text)
            Rpt.SetParameterValue("@USAR_FECHA_COBRO", Convert.ToInt32(Me.chkFilrarCobradosMes.Checked))

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub DesplegarEjercicios()
        Dim oElementos As New Class_Contabilidad_Ejercicios
        With Me.CmbEjercicio
            .DisplayMember = "NOMBRE_EJERCICIO"
            .ValueMember = "ID_CON_EJERCICIO"
            Dim dView As New Data.DataView(oElementos.ObtenerEjercicios)
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Function ValidarPeriodo() As Boolean
        Me.DtFechaDesde.Enabled = False
        Me.DtFechaDesde.Enabled = True
        Me.DtFechaHasta.Enabled = False
        Me.DtFechaHasta.Enabled = True

        If Me.DtFechaDesde.Value > Me.DtFechaHasta.Value Then
            MsgBox("Rango de fechas inválidas.", MsgBoxStyle.Exclamation, Me.Name)
            Me.DtFechaDesde.Focus()
            Exit Function
        End If

        Return True
    End Function

    Private Function GeneraArchivoBatch() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim oIVA As New Class_Contabilidad_IVA_Acreditable_DIOT()
            bResultado = oIVA.GeneraArchivoBatch(Format(Me.DtFechaDesde.Value, "yyyy-dd-MM"), Format(Me.DtFechaHasta.Value, "yyyy-dd-MM"), _
                                    Convert.ToInt32(Me.chkFilrarCobradosMes.Checked).ToString)

            Me.lblTotalActos0.Text = FormatImporteContable(oIVA.TotalActos0)
            Me.lblTotalActos16.Text = FormatImporteContable(oIVA.TotalActos16)
            Me.lblTotalActos.Text = FormatImporteContable(oIVA.TotalActos)
            Me.lblTotalIVAAcreditable16.Text = FormatImporteContable(oIVA.TotalIVAAcreditable16)
            Me.lblTotalIVARetenido4.Text = FormatImporteContable(oIVA.TotalIVARetenido4)

            oIVA = Nothing
        Catch ex As Exception
            HandleError(Me.Name, "GeneraArchivoBatch", ex)
        End Try
        Return bResultado
    End Function
#End Region


End Class