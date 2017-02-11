Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Cxp_Detalle_Cheques_Transferencias
    Private oProveedores As New Class_CatProveedores

#Region "Constructor y destructor"
    Public Sub New()
        InitializeComponent()
        Me.DesplegarEjercicios()
        Me.DesplegarTipoDocumento()
        Me.DesplegarEstatus()
        Me.DesplegarConceptosPago()
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
#End Region

#Region "Métodos y procedimientos"

    Private Sub Inicializa()
        Me.CmbEjercicio.SelectedValue = Plaza.ID_CON_EJERCICIO
        Me.DtFechaDesde.Value = Plaza.FECHA_INICIO
        Me.DtFechaHasta.Value = Plaza.FECHA_FINAL
        Me.CboDocumento.SelectedValue = "T"
        Me.CboEstatus.SelectedValue = "A"
    End Sub

    Private Sub DesplegarEjercicios()
        Dim oElementos As New Class_Contabilidad_Ejercicios
        With Me.CmbEjercicio
            .DisplayMember = "NOMBRE_EJERCICIO"
            .ValueMember = "ID_CON_EJERCICIO"
            Dim dView As New Data.DataView(oElementos.ObtenerEjercicios)
            ' dView.Sort = "NOMBRE_EJERCICIO"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub DesplegarTipoDocumento()
        Dim oElementos As New Class_SisTiposDocumentos
        With Me.CboDocumento
            .DisplayMember = "NOMBRE_TIPO_DOCUMENTO"
            .ValueMember = "CODIGO_TIPO_DOCUMENTO"

            Dim dView As New Data.DataView(oElementos.ObtenerTiposDocumentosCxpParaReporte)
            dView.Sort = "NOMBRE_TIPO_DOCUMENTO"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub DesplegarEstatus()
        Dim oElementos As New Class_CatEstatus
        With Me.CboEstatus
            .DisplayMember = "ESTATUS"
            .ValueMember = "CODIGO_ESTATUS"

            Dim dView As New Data.DataView(oElementos.EstatusParaReportes)
            dView.Sort = "ESTATUS"
            .DataSource = dView
            If dView.Count > 0 Then
                '.SelectedIndex = 0
                .SelectedValue = "A"
            End If
        End With
    End Sub

    Private Sub DesplegarConceptosPago()
        Try
            Dim oElementos As New Class_CXPCatalogoConceptosPagos
            With Me.cboConceptoPago
                .DisplayMember = "NOMBRE_CONCEPTO_PAGO_CXP"
                .ValueMember = "CODIGO_CONCEPTO_PAGO_CXP"

                Dim dView As New Data.DataView(oElementos.ObtenerElementosParaReportes)
                dView.Sort = "NOMBRE_CONCEPTO_PAGO_CXP"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = 0 '0=TODOS
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarConceptosPago", ex)
        End Try
    End Sub

    Private Function ValidarPeriodo() As Boolean
        Me.DtFechaDesde.Enabled = False
        Me.DtFechaHasta.Enabled = False
        Me.DtFechaDesde.Enabled = True
        Me.DtFechaHasta.Enabled = True

        If Me.DtFechaDesde.Value > Me.DtFechaHasta.Value Then
            MsgBox("Rango de fechas inválidas.", MsgBoxStyle.Exclamation, Me.Name)
            Me.DtFechaDesde.Focus()
            Exit Function
        End If
        ValidarPeriodo = True
    End Function

    Private Sub CmbEjercicio_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEjercicio.SelectedIndexChanged
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Me.CmbEjercicio.SelectedValue.ToString)
        Me.DtFechaDesde.Value = CDate(sql.Result1)
        Me.DtFechaHasta.Value = CDate(sql.Result2)
        ' Me.CmbEjercicio.SelectedValue = EmpresaParametros.ID_CON_EJERCICIO
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

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            If Me.ValidarPeriodo = False Then
                Exit Sub
            End If

            If Me.rbFormatoDetallado.Checked = True Then
                oReporte = New Class_Reporte("RPT_CXP_DETALLE_TRANS_CHEQUES_PROVEEDORES", Rpt)
            ElseIf Me.rbFormatoPorConcepto.Checked = True Then
                oReporte = New Class_Reporte("RPT_CXP_DETALLE_TRANS_CHEQUES_PROVEEDORES_X_CONCEPTO_PAGO", Rpt)
            ElseIf Me.RbtFormatoPorProveedor.Checked = True Then
                oReporte = New Class_Reporte("RPT_CXP_DETALLE_TRANS_CHEQUES_PROVEEDORES_X_PROVEEDOR", Rpt)
            Else
                MsgBox("Opción no válida.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If

            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@CODIGO_PROVEEDOR", "" & Me.txtCodigoProveedor.Text)
            Rpt.SetParameterValue("@FECHA_INICIO", Format(DtFechaDesde.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA_FINAL", Format(DtFechaHasta.Value, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@ESTATUS", Me.CboEstatus.SelectedValue)
            Rpt.SetParameterValue("@ID_CUENTA_BANCARIA", valorNumerico(Me.txtCuentaBancaria.Text))
            Rpt.SetParameterValue("@CODIGO_PLAZA", Usuario.Codigo_Plaza)
            Rpt.SetParameterValue("@CODIGO_TIPO_DOCUMENTO", Me.CboDocumento.SelectedValue)
            Rpt.SetParameterValue("@CODIGO_CONCEPTO_PAGO_CXP", Me.cboConceptoPago.SelectedValue)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Reporte de detalle de cheques/transferencias", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

#End Region

    Private Sub txtCuentaBancaria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuentaBancaria.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
busqueda_Visual:
                Dim oIdCodigoBanco As New Class_CatCuentasBancarias
                Dim sIdCodigoBanco As String = oIdCodigoBanco.BusquedaVisual_PorDescripcion
                If txtLEN(sIdCodigoBanco) = True Then
                    Me.txtCuentaBancaria.Text = sIdCodigoBanco
                    sIdCodigoBanco = Replace(sIdCodigoBanco, "'", "''")
                    Dim sql As New Class_find("Select NOMBRE_CUENTA_BANCARIA From CAT_CUENTAS_BANCARIAS Where ID_CUENTA_BANCARIA=" & sIdCodigoBanco & "")
                    Me.txtCuentaBancaria.Text = sIdCodigoBanco.ToString
                    Me.lblCuentaBancaria.Text = sql.Result1
                End If

            Case Keys.Return
                Dim sql As New Class_find("Select NOMBRE_CUENTA_BANCARIA From CAT_CUENTAS_BANCARIAS Where ID_CUENTA_BANCARIA=" & valorNumerico(Me.txtCuentaBancaria.Text) & "")
                If sql.Result1 = "" Then
                    Me.lblBancaria.Text = ""
                    'GoTo busqueda_Visual
                Else
                    Me.lblCuentaBancaria.Text = sql.Result1
                    Me.txtCodigoProveedor.Focus()
                End If
                sql = Nothing
        End Select
    End Sub

    Private Sub TxtCodigoProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoProveedor.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oProveedores.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.txtCodigoProveedor.Text = sText
            Case Keys.Enter
                If txtLEN(Me.txtCodigoProveedor.Text) = False Then
                    Me.lblProveedor.Text = ""
                    'GoTo Buscar : Exit Sub
                    'Me.tsbImprimir.PerformClick()
                    Me.cboConceptoPago.Focus()
                    Exit Sub
                End If

                Me.oProveedores = New Class_CatProveedores(Me.txtCodigoProveedor.Text)
                If Me.oProveedores.Existe = False Then
                    Me.lblProveedor.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblProveedor.Text = Me.oProveedores.Nombre_Proveedor
        End Select
    End Sub

    Private Sub cboConceptoPago_KeyDown(sender As Object, e As KeyEventArgs) Handles cboConceptoPago.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.tsbImprimir.PerformClick()
        End If
    End Sub

End Class