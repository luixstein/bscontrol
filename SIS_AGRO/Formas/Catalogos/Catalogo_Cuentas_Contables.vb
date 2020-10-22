Option Strict On

Public Class Catalogo_Cuentas_Contables

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_Nomina_Concepto As Integer
    Private _Nombre_Nomina_Concepto As String
    Private _ESTATUS_DOCUMENTO As String
#End Region

#Region "Campos privados"
    Private Enum enumEstados
        NUEVO
        EDICION
        CONSULTA
    End Enum

    Private Estado As enumEstados
    Private Run As Boolean
    Private msgElemento As String
    Private msgElementos As String
#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Nombre_Reporte As String
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property ID_Nomina_Concepto() As Integer
        Get
            Return Me._ID_Nomina_Concepto
        End Get
        Set(ByVal value As Integer)
            Me._ID_Nomina_Concepto = value
        End Set
    End Property

    Public Property Nombre_Nomina_Concepto() As String
        Get
            Return Me._Nombre_Nomina_Concepto
        End Get
        Set(ByVal value As String)
            Me._Nombre_Nomina_Concepto = value
        End Set
    End Property

    Public Property ESTATUS_DOCUMENTO() As String
        Get
            Return Me._ESTATUS_DOCUMENTO
        End Get
        Set(ByVal value As String)
            Me._ESTATUS_DOCUMENTO = value
        End Set
    End Property
#End Region

#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Catalogo() As String
        Get
            Return Me._Nombre_Catalogo
        End Get
    End Property

    Public Property Nombre_Reporte() As String
        Get
            Return Me._Nombre_Reporte
        End Get
        Set(ByVal value As String)
            Me._Nombre_Reporte = value
        End Set
    End Property

#End Region

#End Region

#Region "Constructor y destructor"
    Sub New()
        InitializeComponent()

        Try
            Me.msgElemento = "Cuenta Contable"
            Me.msgElementos = "Cuentas Contables"
            Me.Run = False
            'Me.lstbElementos.ContextMenuStrip = Me.cMenuStripAccion
            Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
            Me.DesplegaTiposContabilidad()
            Me.DesplegaPlazas()
            Me.DesplegarElementos()
            Me.rdbNombreCuenta.Checked = True

            Me.cboFiltroCodigoAgrupador.Items.Add("TODAS")
            Me.cboFiltroCodigoAgrupador.Items.Add("SIN CODIGO AGRUPADOR")
            Me.cboFiltroCodigoAgrupador.Items.Add("CON CODIGO AGRUPADOR")
            Me.cboFiltroCodigoAgrupador.Text = "TODAS"

            Me.Run = True
        Catch ex As Exception
            HandleError(Me.Name, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Estado = enumEstados.NUEVO
        Me.Cambia_Estado()
        Me.TxtNivel1.Focus()
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        If Usuario.PERMISO_CON_CAT_CUENTAS = "0" Then
            MsgBox("No tiene permiso para realizar este movimiento.", MsgBoxStyle.Exclamation, Me.Name)
            Me.Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
            Exit Sub
        End If

        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones de la " & Me.msgElemento & " : " & Me.LblCuenta.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el " & Me.msgElemento & " : " & Me.LblCuenta.Text
        End Select
        sMsg = "Deseas " & sMsg & " ?"
        If MsgBox(sMsg, CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle)) = MsgBoxResult.Yes Then
            Call Grabar_Elemento()
        End If
    End Sub

    Private Sub tsbEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEliminar.Click
        If Usuario.PERMISO_CON_CAT_CUENTAS = "0" Then
            MsgBox("No tiene permiso para realizar este movimiento.", MsgBoxStyle.Exclamation, Me.Name)
            Me.Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
            Exit Sub
        End If

        If MsgBox("Desea Eliminar esta Cuenta Contable", MsgBoxStyle.YesNo, "Eliminar Cuenta Contables") = MsgBoxResult.Yes Then
            Dim oElemento As New Class_CatCuentas
            oElemento.CUENTA_CONTABLE = Me.LblCuenta.Text
            If oElemento.Eliminar Then
                MsgBox("La cuenta contable fue Eliminada con Exito")
            Else
                MsgBox("La cuenta contable no puede ser Eliminada, es probable que tenga Movimientos")
            End If
        End If
        Me.Refrescar()
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbCancelar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
        Me.Estado = enumEstados.CONSULTA
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbImprimirListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirListado.Click
        Dim oElementos As New Class_CatCuentas
        oElementos.Imprimir_Listado()
        oElementos = Nothing
    End Sub

    Private Sub btnActualizarCodigoAgrupador_Click(sender As Object, e As EventArgs) Handles btnActualizarCodigoAgrupador.Click
        Me.ActualizaCodigoAgrupador
    End Sub
#End Region

#Region "Eventos de objetos"
    Private Sub Catalogo_Cuentas_Contables_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.DesplegaTiposContabilidad()
        'Me.DesplegaPlazas()
    End Sub

    Private Sub cmbTipoContabilidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbTipoContabilidad.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cboPlazaParaFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPlazaParaFiltro.SelectedIndexChanged
        If Me.Run = True Then
            Me.DesplegarElementos()
        End If
    End Sub

    Private Sub txtCodigoAgrupador_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoAgrupador.KeyDown
        Dim sText As String
        Try
            Dim oCuentaSAT As Class_CatCuentasSAT
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    oCuentaSAT = New Class_CatCuentasSAT
                    sText = oCuentaSAT.BusquedaVisual_PorDescripcion
                    If txtLEN(sText) = True Then Me.txtCodigoAgrupador.Text = sText
                Case Keys.Return
                    If txtLEN(Me.txtCodigoAgrupador.Text) = False Then
                        Me.lblNombreCuentaSAT.Text = ""
                        GoTo Buscar : Exit Sub
                    End If

                    oCuentaSAT = New Class_CatCuentasSAT(Me.txtCodigoAgrupador.Text)
                    If oCuentaSAT.Existe = False Then
                        Me.lblNombreCuentaSAT.Text = "" : GoTo Buscar : Exit Sub
                    Else
                        Me.lblNombreCuentaSAT.Text = oCuentaSAT.NOMBRE_CUENTA_SAT
                    End If

                    Me.chkClonarCodigoAgrupador.Focus()
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "txtCodigoAgrupador_KeyDown", ex)
        End Try
    End Sub

    Private Sub cboFiltroCodigoAgrupador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFiltroCodigoAgrupador.SelectedIndexChanged
        If Me.Run = True Then
            Me.DesplegarElementos()
        End If
    End Sub

#Region "Eventos de la lista de elementos"

    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CUENTA_CONTABLE").Value.ToString)
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellDoubleClick
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    'Private Sub lstbElementos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstbElementos.DoubleClick
    '    Me.Estado = enumEstados.EDICION
    '    Me.Cambia_Estado()
    'End Sub

    'Private Sub lstbElementos_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstbElementos.Enter
    '    If Me.lstbElementos.Items.Count > 0 Then
    '        Me.tsbEditar.Enabled = True
    '    End If
    'End Sub

    'Private Sub lstbElementos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstbElementos.LostFocus
    '    Me.tsbEditar.Enabled = False
    'End Sub

    'Private Sub lstbElementos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstbElementos.SelectedIndexChanged
    '    If Me.lstbElementos.SelectedIndex >= 0 Then
    '        Me.LlenaElemento(CType(Me.lstbElementos.SelectedValue.ToString, String))
    '    End If
    'End Sub
#End Region

#Region "Eventos de TxtFiltro"
    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Me.DesplegarElementos()
    End Sub

    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub CboPlazas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPlaza.KeyDown
        If e.KeyCode = Keys.Return Then
            tsbGrabar.PerformClick()
        End If
    End Sub

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNombreCuenta.KeyPress, CmbNaturaleza.KeyPress, txtCodigoAgrupador.KeyPress, chkClonarCodigoAgrupador.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombreCuenta.KeyDown, TxtNivel5.KeyDown, TxtNivel4.KeyDown, TxtNivel3.KeyDown, TxtNivel2.KeyDown, TxtNivel1.KeyDown, CmbNaturaleza.KeyDown
        If e.KeyCode = Keys.Return Then
            Select Case Me.Estado
                Case enumEstados.EDICION
                    SendKeys.Send("{TAB}")
                Case enumEstados.NUEVO
                    SendKeys.Send("{TAB}")
            End Select
        End If
    End Sub

    Private Sub Txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNivel5.LostFocus, TxtNivel4.LostFocus, TxtNivel3.LostFocus, TxtNivel2.LostFocus, TxtNivel1.LostFocus
        'Me.LblCuenta.Text = Me.TxtMayor.Text & Me.TxtSubcuenta.Text & Me.TxtNivel3.Text
    End Sub

    Private Sub Txt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNivel4.LostFocus, TxtNivel5.LostFocus, TxtNivel3.Leave, TxtNivel2.Leave, TxtNivel1.Leave
        'Me.LblCuenta.Text = Me.TxtMayor.Text & Me.TxtSubcuenta.Text & Me.TxtNivel3.Text
    End Sub

    'Private Sub txtNumericos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMayor.KeyPress, TxtNivel3.KeyPress, TxtSubcuenta.KeyPress
    '    Dim txt As TextBox = CType(sender, TextBox)
    '    txtSoloNumeros(e, txt.Text)
    '    txtNoBeep(e)
    'End Sub

    Private Sub TxtNivel3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNivel3.TextChanged, TxtNivel2.TextChanged, TxtNivel1.TextChanged
        Me.LblCuenta.Text = Me.TxtNivel1.Text & Me.TxtNivel2.Text & Me.TxtNivel3.Text & Me.TxtNivel4.Text & Me.TxtNivel5.Text
        Application.DoEvents()
    End Sub

    Private Sub txtSaltoAutomatico_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNivel5.KeyPress, TxtNivel4.KeyPress, TxtNivel3.KeyPress, TxtNivel2.KeyPress, TxtNivel1.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        Dim oCuenta As Class_CatCuentas

        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)

        If IsNumeric(e.KeyChar) And txt.SelectionLength = 0 Then
            Select Case txt.Name
                Case "TxtNivel1"
                    If txt.TextLength = EmpresaParametros.LEN_CUENTA_CONTABLE_NIVEL1 - 1 Then
                        oCuenta = New Class_CatCuentas(txt.Text & e.KeyChar.ToString)
                        Me.lblNivel1NombreCuenta.Text = oCuenta.NOMBRE_CUENTA
                        Me.TxtNivel2.Focus()
                    End If
                Case "TxtNivel2"
                    If txt.TextLength = EmpresaParametros.LEN_CUENTA_CONTABLE_NIVEL2 - 1 Then
                        oCuenta = New Class_CatCuentas(Me.TxtNivel1.Text & txt.Text & e.KeyChar.ToString)
                        Me.lblNivel2NombreCuenta.Text = oCuenta.NOMBRE_CUENTA
                        Me.TxtNivel3.Focus()
                    End If
                Case "TxtNivel3"
                    If txt.TextLength = EmpresaParametros.LEN_CUENTA_CONTABLE_NIVEL3 - 1 Then
                        oCuenta = New Class_CatCuentas(Me.TxtNivel1.Text & Me.TxtNivel2.Text & txt.Text & e.KeyChar.ToString)
                        Me.lblNivel3NombreCuenta.Text = oCuenta.NOMBRE_CUENTA
                        Me.TxtNivel4.Focus()
                    End If
                Case "TxtNivel4"
                    If txt.TextLength = EmpresaParametros.LEN_CUENTA_CONTABLE_NIVEL4 - 1 Then
                        oCuenta = New Class_CatCuentas(Me.TxtNivel1.Text & Me.TxtNivel2.Text & Me.TxtNivel3.Text & txt.Text & e.KeyChar.ToString)
                        Me.lblNivel4NombreCuenta.Text = oCuenta.NOMBRE_CUENTA
                        Me.TxtNivel5.Focus()
                    End If
                Case "TxtNivel5"
                    If txt.TextLength = EmpresaParametros.LEN_CUENTA_CONTABLE_NIVEL5 - 1 Then
                        Me.TxtNombreCuenta.Focus()
                    End If
            End Select

            oCuenta = Nothing

        ElseIf Asc(e.KeyChar) = 8 And txt.TextLength = 0 And txt.SelectionLength = 0 Then
            Select Case txt.Name
                Case "TxtNivel2"
                    Me.TxtNivel1.Focus()
                Case "TxtNivel3"
                    Me.TxtNivel2.Focus()
                Case "TxtNivel4"
                    Me.TxtNivel3.Focus()
                Case "TxtNivel5"
                    Me.TxtNivel4.Focus()
            End Select
        End If

        Application.DoEvents()
    End Sub

    Private Sub CboFiltroHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Refrescar()
    End Sub

    Private Sub rdbCuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbCuenta.Click
        Me.txtFiltro.Focus()
    End Sub

    Private Sub rdbNombreCuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbNombreCuenta.Click
        Me.txtFiltro.Focus()
    End Sub

#End Region

#End Region

#Region "Métodos y procedimientos"
    Private Sub Refrescar()
        Me.DesplegarElementos()
    End Sub

    Private Sub Cambia_Estado()
        Try
            'Dim iIndex As Integer
            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.gBoxInformacion.Enabled = True
                    Me.gBoxBusquedaRapida.Enabled = False
                    Me.tssLabelEstado.Text = "Agregando"
                    Me.tsbNuevo.Enabled = False
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = True
                    Me.tsbEliminar.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.btnActualizarCodigoAgrupador.Enabled = False

                    Me.TxtNivel1.Enabled = True
                    Me.TxtNivel2.Enabled = True
                    Me.TxtNivel3.Enabled = True
                    Me.TxtNivel4.Enabled = True
                    Me.TxtNivel5.Enabled = True
                    Me.TxtNombreCuenta.Enabled = True
                    Me.CmbMayor.Enabled = False
                    Me.CmbNaturaleza.Enabled = False

                    Me.InicializaElemento()

                    Me.TxtNivel1.Focus()

                Case enumEstados.EDICION
                    Me.gBoxInformacion.Enabled = True
                    Me.gBoxBusquedaRapida.Enabled = False
                    Me.tssLabelEstado.Text = "Editando"
                    Me.tsbNuevo.Enabled = False
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = True
                    Me.tsbEliminar.Enabled = True
                    Me.tsbCancelar.Enabled = True
                    Me.btnActualizarCodigoAgrupador.Enabled = True

                    Me.TxtNivel1.Enabled = False
                    Me.TxtNivel2.Enabled = False
                    Me.TxtNivel3.Enabled = False
                    Me.TxtNivel4.Enabled = False
                    Me.TxtNivel5.Enabled = False
                    Me.TxtNombreCuenta.Enabled = True
                    Me.CmbMayor.Enabled = False
                    Me.CmbNaturaleza.Enabled = False

                Case enumEstados.CONSULTA
                    Me.gBoxInformacion.Enabled = False
                    Me.gBoxBusquedaRapida.Enabled = True
                    Me.tssLabelEstado.Text = "Consultando"
                    Me.tsbNuevo.Enabled = True
                    Me.tsbEditar.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbEliminar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.btnActualizarCodigoAgrupador.Enabled = False

                    Me.txtFiltro.Focus()

            End Select
            Application.DoEvents()

        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Sub InicializaElemento()
        Try
            Me.TxtNombreCuenta.Text = ""
            Me.TxtNivel2.Text = "" : Me.lblNivel1NombreCuenta.Text = ""
            Me.TxtNivel3.Text = "" : Me.lblNivel2NombreCuenta.Text = ""
            Me.TxtNivel4.Text = "" : Me.lblNivel3NombreCuenta.Text = ""
            Me.TxtNivel5.Text = "" : Me.lblNivel4NombreCuenta.Text = ""
            Me.LblCuenta.Text = ""
            Me.cmbTipoContabilidad.SelectedValue = "NM"
            Me.txtCodigoAgrupador.Text = ""
            Me.lblNombreCuentaSAT.Text = ""
            'Me.rdbNombreCuenta.Checked = True
            Me.chkClonarCodigoAgrupador.Checked = False
            'Me.lblMsg.Visible = False
            Me.cboFiltroCodigoAgrupador.Text = "TODAS"
        Catch ex As Exception
            HandleError(Me.Name, "InicializaElemento", ex)
        End Try
    End Sub

    Private Sub DesplegarElementos()
        Try
            Dim oElementos As New Class_CatCuentas
            With Me.Grid
                If Me.rdbCuenta.Checked = True Then
                    .DataSource = oElementos.ObtenerElementosN(Class_CatCuentas.FiltroCuenta.CODIGO_CUENTA, Me.txtFiltro.Text, Me.cboFiltroCodigoAgrupador.Text, IIf(Me.cboPlazaParaFiltro.SelectedValue.ToString <> "0", Me.cboPlazaParaFiltro.SelectedValue.ToString, "").ToString)
                Else
                    .DataSource = oElementos.ObtenerElementosN(Class_CatCuentas.FiltroCuenta.NOMBRE_CUENTA, Me.txtFiltro.Text, Me.cboFiltroCodigoAgrupador.Text, IIf(Me.cboPlazaParaFiltro.SelectedValue.ToString <> "0", Me.cboPlazaParaFiltro.SelectedValue.ToString, "").ToString)
                End If

                .Columns("CUENTA_CONTABLE").Width = 120
                .Columns("NOMBRE_CUENTA").Width = 300
                .Columns("NOMBRE_PLAZA").Width = 100
                .Columns("CODIGO_AGRUPADOR").Width = 50
                .Columns("NOMBRE_CUENTA_SAT").Width = 200
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarElementos", ex)
        End Try
    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As String)
        Try
            Dim oElemento As New Class_CatCuentas
            oElemento.CUENTA_CONTABLE = iCodigo_Elemento
            If oElemento.Consultar Then
                With oElemento

                    Dim oSubCuentas As New Class_find("SELECT " &
                "(SELECT NOMBRE_CUENTA FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE=C.NIVEL1), " &
                "CASE WHEN LEN(C.NIVEL2)>0 THEN (SELECT NOMBRE_CUENTA FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE=C.NIVEL1+C.NIVEL2)						ELSE '' END, " &
                "CASE WHEN LEN(C.NIVEL3)>0 THEN (SELECT NOMBRE_CUENTA FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE=C.NIVEL1+C.NIVEL2+C.NIVEL3)			ELSE '' END, " &
                "CASE WHEN LEN(C.NIVEL4)>0 THEN (SELECT NOMBRE_CUENTA FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE=C.NIVEL1+C.NIVEL2+C.NIVEL3+C.NIVEL4)	ELSE '' END " &
                "FROM CON_CAT_CUENTAS C WHERE CUENTA_CONTABLE='" & .CUENTA_CONTABLE & "'")

                    Me.TxtNivel1.Text = .NIVEL1
                    Me.TxtNivel2.Text = .NIVEL2
                    Me.TxtNivel3.Text = .NIVEL3
                    Me.TxtNivel4.Text = .NIVEL4
                    Me.TxtNivel5.Text = .NIVEL5

                    Me.lblNivel1NombreCuenta.Text = oSubCuentas.Result1
                    Me.lblNivel2NombreCuenta.Text = oSubCuentas.Result2
                    Me.lblNivel3NombreCuenta.Text = oSubCuentas.Result3
                    Me.lblNivel4NombreCuenta.Text = oSubCuentas.Result4

                    Me.TxtNombreCuenta.Text = .NOMBRE_CUENTA
                    Me.LblCuenta.Text = .CUENTA_CONTABLE
                    If .NATURALEZA_CONTABLE = "D" Then
                        Me.CmbNaturaleza.Text = "DEUDOR"
                    Else
                        Me.CmbNaturaleza.Text = "ACREEDOR"
                    End If
                    If .ESMAYOR = "1" Then
                        Me.CmbMayor.Text = "MAYOR"
                    Else
                        Me.CmbMayor.Text = "ACEPTA CARGOS"
                    End If
                    Me.cmbTipoContabilidad.SelectedValue = .TIPO_CONTABILIDAD
                    Me.cboPlaza.SelectedValue = .CODIGO_PLAZA

                    Me.txtCodigoAgrupador.Text = .CODIGO_AGRUPADOR
                    Me.lblNombreCuentaSAT.Text = .NOMBRE_CUENTA_SAT
                End With
            End If
            oElemento = Nothing
        Catch ex As Exception
            HandleError(Me.Name, "LlenaElemento", ex)
        End Try
    End Sub

    Private Function ValidaLongitudNiveles() As Boolean
        If Me.TxtNivel1.TextLength > 0 Then
            If Me.TxtNivel1.TextLength < EmpresaParametros.LEN_CUENTA_CONTABLE_NIVEL1 Then
                MsgBox("El 1er nivel debe de ser de " & EmpresaParametros.LEN_CUENTA_CONTABLE_NIVEL1 & " caracteres.", vbExclamation, Me.Text)
                Me.TxtNivel1.Focus()
                Return False
            End If
        End If
        If Me.TxtNivel2.TextLength > 0 Then
            If Me.TxtNivel2.TextLength < EmpresaParametros.LEN_CUENTA_CONTABLE_NIVEL1 Then
                MsgBox("El 2do nivel debe de ser de " & EmpresaParametros.LEN_CUENTA_CONTABLE_NIVEL2 & " caracteres.", vbExclamation, Me.Text)
                Me.TxtNivel2.Focus()
                Return False
            End If
        End If
        If Me.TxtNivel3.TextLength > 0 Then
            If Me.TxtNivel3.TextLength < EmpresaParametros.LEN_CUENTA_CONTABLE_NIVEL2 Then
                MsgBox("El 3er nivel debe de ser de " & EmpresaParametros.LEN_CUENTA_CONTABLE_NIVEL3 & " caracteres.", vbExclamation, Me.Text)
                Me.TxtNivel3.Focus()
                Return False
            End If
        End If
        If Me.TxtNivel4.TextLength > 0 Then
            If Me.TxtNivel4.TextLength < EmpresaParametros.LEN_CUENTA_CONTABLE_NIVEL3 Then
                MsgBox("El 4to nivel debe de ser de " & EmpresaParametros.LEN_CUENTA_CONTABLE_NIVEL4 & " caracteres.", vbExclamation, Me.Text)
                Me.TxtNivel4.Focus()
                Return False
            End If
        End If
        If Me.TxtNivel5.TextLength > 0 Then
            If Me.TxtNivel5.TextLength < EmpresaParametros.LEN_CUENTA_CONTABLE_NIVEL4 Then
                MsgBox("El 5to nivel debe de ser de " & EmpresaParametros.LEN_CUENTA_CONTABLE_NIVEL5 & " caracteres.", vbExclamation, Me.Text)
                Me.TxtNivel5.Focus()
                Return False
            End If
        End If
        If (Me.TxtNivel2.TextLength > 0 Or Me.TxtNivel3.TextLength > 0) And Me.TxtNivel1.TextLength = 0 Then
            MsgBox("Formato inválido, no capturó la cuenta de mayor.", vbExclamation, Me.Text)
            Me.TxtNivel1.Focus()
            Return False
        End If
        If Me.TxtNivel3.TextLength > 0 And Me.TxtNivel2.TextLength = 0 Then
            MsgBox("Formato inválido, no capturó la subcuenta.", vbExclamation, Me.Text)
            Me.TxtNivel2.Focus()
            Return False
        End If

        Return True
    End Function

    Private Function Grabar_Elemento() As Boolean
        Dim oElemento As New Class_CatCuentas
        Dim bResultado As Boolean = False
        'Dim iIndex As Integer = Me.lstbElementos.SelectedIndex

        Me.LblCuenta.Text = Me.TxtNivel1.Text & Me.TxtNivel2.Text & Me.TxtNivel3.Text & Me.TxtNivel4.Text & Me.TxtNivel5.Text

        If txtLEN(Me.TxtNombreCuenta.Text) = False Then
            MsgBox("Captúre el nombre de la cuenta contable.", MsgBoxStyle.Exclamation, Me.Name)
            Return False
        End If

        'If ValidaLongitudNiveles() = False Then
        '    Exit Sub
        'End If

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                oElemento = New Class_CatCuentas
                Try
                    With oElemento
                        .NIVEL1 = Me.TxtNivel1.Text
                        .NIVEL2 = Me.TxtNivel2.Text
                        .NIVEL3 = Me.TxtNivel3.Text
                        .NIVEL4 = Me.TxtNivel4.Text
                        .NIVEL5 = Me.TxtNivel5.Text
                        .NOMBRE_CUENTA = Me.TxtNombreCuenta.Text
                        .CUENTA_CONTABLE = Me.LblCuenta.Text
                        .ESMAYOR = Strings.Left(Me.CmbMayor.Text, 1)
                        .NATURALEZA_CONTABLE = Strings.Left(Me.CmbNaturaleza.Text, 1)
                        If CmbMayor.Text = "MAYOR" Then
                            .ESMAYOR = "1"
                        Else
                            .ESMAYOR = "0"
                        End If
                        .TIPO_CONTABILIDAD = Me.cmbTipoContabilidad.SelectedValue.ToString
                        .CODIGO_PLAZA = CInt(Me.cboPlaza.SelectedValue)
                        .CODIGO_AGRUPADOR = Me.txtCodigoAgrupador.Text
                        .CLONAR_CODIGO_AGRUPADOR_MISMO_NIVEL = Convert.ToInt32(Me.chkClonarCodigoAgrupador.Checked).ToString

                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                If .Grabar("INSERTAR") Then
                                    bResultado = True
                                    Me.Estado = enumEstados.NUEVO
                                End If
                            Case enumEstados.EDICION
                                If .Grabar("ACTUALIZAR") Then
                                    bResultado = True
                                    Me.Estado = enumEstados.CONSULTA
                                End If
                        End Select

                        If bResultado = True Then
                            MsgBox(Me.msgElemento & " grabada satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
                            Me.Refrescar()
                            Me.Cambia_Estado()
                        End If

                    End With
                Catch ex As Exception
                    HandleError(Me.Name, "Grabar", ex)
                    Me.Estado = enumEstados.CONSULTA
                    Me.Cambia_Estado()
                Finally
                    oElemento = Nothing
                End Try
        End Select

        Return bResultado
    End Function

    Private Sub DesplegaTiposContabilidad()
        Try
            Dim oElementos As New Class_CatTiposContabilidad
            With Me.cmbTipoContabilidad
                .DisplayMember = "NOMBRE_TIPO_CONTABILIDAD"
                .ValueMember = "TIPO_CONTABILIDAD"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_TIPO_CONTABILIDAD"
                .DataSource = dView
                If dView.Count > 0 Then
                    '.SelectedIndex = 0
                    .SelectedValue = "NM"
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegaTiposContabilidad", ex)
        End Try
    End Sub

    Private Sub DesplegaPlazas()
        Try
            Dim oElementos As New Class_SisPlazas
            With Me.cboPlaza
                .DisplayMember = "NOMBRE_PLAZA"
                .ValueMember = "CODIGO_PLAZA"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosParaReporte)
                dView.Sort = "NOMBRE_PLAZA"
                .DataSource = dView
            End With

            With Me.cboPlazaParaFiltro
                .DisplayMember = "NOMBRE_PLAZA"
                .ValueMember = "CODIGO_PLAZA"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosParaReporte)
                dView.Sort = "NOMBRE_PLAZA"
                .DataSource = dView
                .SelectedValue = 0
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegaPlazas", ex)
        End Try
    End Sub

    Private Function ActualizaCodigoAgrupador() As Boolean
        Const sProcedure As String = "ActualizaCodigoAgrupador"
        Dim bResultado As Boolean = False
        Try
            If txtLEN(Me.txtCodigoAgrupador.Text) = False Then
                MsgBox("Asígne el código agrupador SAT.", vbExclamation, sProcedure)
                Return False
            End If

            Dim oCuentaSAT As New Class_CatCuentasSAT(Me.txtCodigoAgrupador.Text)
            If oCuentaSAT.Existe = False Then
                MsgBox("El código agrupador SAT no existe.", vbExclamation, sProcedure)
                Return False
            End If

            Dim oCuenta As New Class_CatCuentas(Me.LblCuenta.Text)
            oCuenta.CODIGO_AGRUPADOR = Me.txtCodigoAgrupador.Text
            oCuenta.CLONAR_CODIGO_AGRUPADOR_MISMO_NIVEL = Convert.ToInt32(Me.chkClonarCodigoAgrupador.Checked).ToString
            bResultado = oCuenta.ActualizaCodigoAgrupador()

            oCuenta = Nothing
            oCuentaSAT = Nothing

            If bResultado = True Then
                MsgBox("Código agrupador SAT actualizado correctamente.", MsgBoxStyle.Information, sProcedure)
                Me.Refrescar()
            End If

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

#End Region

End Class