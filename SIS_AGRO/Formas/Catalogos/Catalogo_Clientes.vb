Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Catalogo_Clientes
    Dim oClientes As New Class_CatClientes

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
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
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

#Region "Constructor y destructor"
    'Inicializa al objeto.
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Try
            Me.msgElemento = "Cliente"
            Me.msgElementos = "Clientes"
            Me.Run = False
            'Me.lstbElementos.ContextMenuStrip = Me.cMenuStripAccion
            Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
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

        'Me.txtCodigoCliente.Text = Me.oClientes.CodigoSiguiente(Me.cboTipoMercado.SelectedValue.ToString)
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        If Usuario.PERMISO_CAT_CLIENTES = "0" Then
            MsgBox("No tiene permiso para realizar este movimiento.", MsgBoxStyle.Exclamation, Me.Name)
            Me.Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
            Exit Sub
        End If

        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del " & Me.msgElemento & " : " & Me.TxtNombreCliente.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el " & Me.msgElemento & " : " & Me.TxtNombreCliente.Text
        End Select
        sMsg = "Deseas " & sMsg & " ?"
        If MsgBox(sMsg, CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle)) = MsgBoxResult.Yes Then
            Me.Grabar_Elemento()
        End If
    End Sub

    Private Sub tsbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
        Me.Estado = enumEstados.CONSULTA
        Me.Cambia_Estado()
        'Me.oClientes.CodigoSiguiente(Me.cboTipoMercado.SelectedValue.ToString)
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbImprimirListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirListado.Click
        Dim oElementos As New Class_CatClientes

        oElementos.Imprimir_Listado()

        oElementos = Nothing
    End Sub

    Private Sub tsbEliminar_Click(sender As Object, e As EventArgs) Handles tsbEliminar.Click
        Dim sMsg As String = ""
        If Usuario.PERMISO_CAT_CLIENTES = "0" Then
            MsgBox("No tiene permiso para realizar este movimiento.", MsgBoxStyle.Exclamation, Me.Name)
            Me.Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
            Exit Sub
        End If

        sMsg = "Deseas eliminar el " & Me.msgElemento & " : " & Me.txtCodigoCliente.Text & "?"
        If MsgBox(sMsg, CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle)) = MsgBoxResult.Yes Then
            Me.Elimina_Elemento()
        End If
    End Sub

#End Region

#Region "Eventos de objetos"
#Region "Eventos"

    Private Sub txtLocalidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocalidad.Click
        If txtLEN(Me.txtLocalidad.Text) = False Then
            Me.txtLocalidad.Text = Me.txtCiudad.Text
        End If
    End Sub

    Private Sub cboMetodoPago_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMetodoPago.SelectedValueChanged
        Dim oMetodoPago As New Class_CFD_CatMetodosPago
        If Me.cboMetodoPago.SelectedValue Is Nothing Then
            Exit Sub
        End If
        oMetodoPago = New Class_CFD_CatMetodosPago(Me.cboMetodoPago.SelectedValue.ToString)

        If Me.Estado = enumEstados.CONSULTA Then
            Exit Sub
        End If
        If oMetodoPago.REQUIERE_NUMERO_CUENTA_PAGO = 1 Then
            Me.txtNumeroCuenta.Enabled = True
            Me.txtNumeroCuenta.Focus()
        Else
            Me.txtNumeroCuenta.Enabled = False
        End If
    End Sub

    Private Sub cboMetodoPagoDlls_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMetodoPagoDlls.SelectedValueChanged
        Dim oMetodoPago As New Class_CFD_CatMetodosPago
        If Me.cboMetodoPagoDlls.SelectedValue Is Nothing Then
            Exit Sub
        End If
        oMetodoPago = New Class_CFD_CatMetodosPago(Me.cboMetodoPagoDlls.SelectedValue.ToString)

        If Me.Estado = enumEstados.CONSULTA Then
            Exit Sub
        End If
        If oMetodoPago.REQUIERE_NUMERO_CUENTA_PAGO = 1 Then
            Me.txtNumeroCuentaDolares.Enabled = True
            Me.txtNumeroCuentaDolares.Focus()
        Else
            Me.txtNumeroCuentaDolares.Enabled = False
        End If
    End Sub

    Private Sub cboTipoMercado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoMercado.SelectedIndexChanged
        If Me.Estado.ToString = "NUEVO" Then
            'Me.txtCodigoCliente.Text = Me.oClientes.CodigoSiguiente(Me.cboTipoMercado.SelectedValue.ToString)
            'Me.cboZona.SelectedValue = Me.cboTipoMercado.SelectedValue.ToString
        End If
        'If Me.cboTipoMercado.Text = "NACIONAL" Then
        '    Me.txtPais.Text = "MEXICO"
        'Else
        '    Me.txtPais.Text = ""
        'End If
        'Me.cboZona.SelectedValue = CInt(Me.cboTipoMercado.SelectedValue.ToString)
    End Sub

    Private Sub cboZona_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZona.SelectedIndexChanged
        'If Me.Estado.ToString = "NUEVO" Then
        '    'Me.txtCodigoCliente.Text = Me.oClientes.CodigoSiguiente(Me.cboTipoMercado.SelectedValue.ToString)
        '    'Me.cboZona.SelectedValue = Me.cboTipoMercado.SelectedValue.ToString
        '    Me.cboTipoMercado.SelectedValue = Me.cboZona.SelectedValue.ToString
        'End If
    End Sub

    Private Sub BtnGeneraCuentaContableDolares_Click(sender As Object, e As EventArgs) Handles BtnGeneraCuentaContableDolares.Click
        Me.GeneraCuentaContableDolares()
    End Sub

    Private Sub cboPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPais.SelectedIndexChanged
        Me.DesplegarEstados()
    End Sub

    Private Sub cboEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstado.SelectedIndexChanged
        Me.DesplegarMunicipios()
    End Sub
#End Region

#Region "Eventos Genericos"

    'Private Sub txt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles    _
    '        _
    '         _

    '    txtTAB(e)
    'End Sub

    'Private Sub txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles  _
    '      _
    '      _
    '       _
    '       _

    '    txtNoBeep(e)
    'End Sub

    Private Sub txt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRfc.KeyDown, txtPais.KeyDown, txtNumeroTelefono.KeyDown, _
    txtNumeroInterior.KeyDown, txtNumeroExterior.KeyDown, txtNumeroCelular.KeyDown, TxtNombreCliente.KeyDown, txtLocalidad.KeyDown, txtLimiteCredito.KeyDown, txtDiasPlazo.KeyDown, txtCurp.KeyDown, _
    txtColonia.KeyDown, txtCodigoCliente.KeyDown, txtCalle.KeyDown, DpFecha.KeyDown, chkPermitirVentaCredito.KeyDown, cboZona.KeyDown, cboVendedor.KeyDown, cboTipoPersona.KeyDown, _
    cboTipoMercado.KeyDown, CboEstatus.KeyDown, cboEstado.KeyDown, cboMetodoPago.KeyDown, txtNumeroCuenta.KeyDown, txtCiudad.KeyDown, txtCorreoCliente.KeyDown, cboMetodoPagoDlls.KeyDown, txtNumeroCuentaDolares.KeyDown, _
    txtNumeroRegistroIdentificadorExtranjero.KeyDown, cboPais.KeyDown, cboMunicipio.KeyDown, chkEsContribuyenteIEPS.KeyDown, cboNombreXML.KeyDown
        txtTAB(e)
    End Sub

    Private Sub txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRfc.KeyPress, _
    txtPais.KeyPress, txtNumeroTelefono.KeyPress, txtNumeroInterior.KeyPress, txtNumeroExterior.KeyPress, txtNumeroCelular.KeyPress, TxtNombreCliente.KeyPress, _
    txtLocalidad.KeyPress, txtLimiteCredito.KeyPress, txtDiasPlazo.KeyPress, txtCurp.KeyPress, txtCuentaContableDolares.KeyPress, txtCuentaContable.KeyPress, _
    txtColonia.KeyPress, txtCodigoPostal.KeyPress, txtCodigoCliente.KeyPress, txtCiudad.KeyPress, txtCalle.KeyPress, DpFecha.KeyPress, chkPermitirVentaCredito.KeyPress, _
    cboZona.KeyPress, cboVendedor.KeyPress, cboTipoPersona.KeyPress, cboTipoMercado.KeyPress, CboEstatus.KeyPress, cboEstado.KeyPress, txtCorreoCliente.KeyPress, _
    cboMetodoPago.KeyPress, cboMetodoPagoDlls.KeyPress, txtNumeroRegistroIdentificadorExtranjero.KeyPress, cboPais.KeyPress, cboMunicipio.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroCuentaDolares.KeyPress, TxtCodigoAlmacen.KeyPress, TxtCodigoPropietario.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

#End Region

#Region "Keydown específicos"
    Private Sub txtCuentaContableDolares_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuentaContableDolares.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
busqueda_Visual:
                Dim oCuenta As New Class_CatCuentas
                Dim sCuenta As String = oCuenta.BusquedaVisual_PorCodigoFiltrandoTipoOperacion()
                If sCuenta.Length > 0 Then
                    Me.txtCuentaContableDolares.Text = sCuenta
                    sCuenta = Replace(sCuenta, "'", "''")
                    Dim sql As New Class_find("SELECT NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & sCuenta & "'")
                    Me.txtCuentaContableDolares.Text = sCuenta
                    'Me.LblCuenta.Text = sql.Result1
                    Me.txtCuentaContableDolares.Focus()
                    sql = Nothing
                Else
                    Me.txtCuentaContableDolares.Text = ""
                    'Me.LblCuenta.Text = ""
                    Me.txtCuentaContableDolares.Focus()
                End If

            Case Keys.F7
                Dim oCuenta As New Class_CatCuentas
                Dim sCuenta As String = oCuenta.BusquedaVisual_PorNombreFiltrandoTipoOperacion()
                If sCuenta.Length > 0 Then
                    Me.txtCuentaContableDolares.Text = sCuenta
                    sCuenta = Replace(sCuenta, "'", "''")
                    Dim sql As New Class_find("Select CUENTA_CONTABLE,NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & sCuenta & "' AND ESMAYOR=0 ")
                    Me.txtCuentaContableDolares.Text = sCuenta
                    'Me.LblCuenta.Text = sql.Result2
                    Me.txtCuentaContableDolares.Focus()
                    sql = Nothing
                Else
                    Me.txtCuentaContableDolares.Text = ""
                    'Me.LblCuenta.Text = ""
                    Me.txtCuentaContableDolares.Focus()
                End If

            Case Keys.Return
                Dim sql As New Class_find("Select NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & Me.txtCuentaContableDolares.Text & "' AND ESMAYOR=0 ")
                If sql.Result1 = "" Then
                    Me.txtCuentaContableDolares.Text = ""
                    'Me.LblCuenta.Text = ""
                    Me.txtCuentaContableDolares.Focus()
                    GoTo busqueda_Visual
                Else
                    txtTAB(e)
                End If
                sql = Nothing

        End Select
    End Sub

    Private Sub txtCiudad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCiudad.KeyDown
        If e.KeyCode = Keys.Return Then
            If txtLEN(Me.txtLocalidad.Text) = False Then
                Me.txtLocalidad.Text = Me.txtCiudad.Text
                txtTAB(e)
            End If
        End If
    End Sub

    Private Sub txtCodigoPostal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoPostal.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.cboVendedor.Focus()
        End If
    End Sub

    Private Sub cboMetodoPagoDlls_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMetodoPagoDlls.KeyDown
        If e.KeyCode = Keys.Return Then
            tsbGrabar.PerformClick()
        End If
    End Sub

    Private Sub txtCodigoCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F6
busca:
                Me.txtCodigoCliente.Text = Me.oClientes.BusquedaVisual_PorDescripcion
            Case Keys.Enter
                If Consultar() = False Then
                    GoTo busca
                End If
        End Select
        txtTAB(e)
    End Sub

    Private Sub TxtCodigoAlmacen_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigoAlmacen.KeyDown
        Dim oAlmacenes As New Class_CatAlmacenes
        Select Case e.KeyCode
            Case Keys.F6
busca:
                Me.TxtCodigoAlmacen.Text = oAlmacenes.BusquedaVisual_PorDescripcion
            Case Keys.Enter
                oAlmacenes.Codigo_Almacen = Me.TxtCodigoAlmacen.Text
                If oAlmacenes.Consultar() = False Then
                    GoTo busca
                End If
        End Select
        txtTAB(e)
    End Sub

    Private Sub TxtCodigoPropietario_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigoPropietario.KeyDown
        Dim oPropietario As New Class_CatPropietarios
        Select Case e.KeyCode
            Case Keys.F6
busca:
                Me.TxtCodigoPropietario.Text = oPropietario.BusquedaVisual_PorDescripcion
                If txtLEN(Me.TxtCodigoPropietario.Text) = True Then
                    Dim sql As New Class_find("SELECT NOMBRE_PROPIETARIO FROM CAT_PROPIETARIOS WHERE CODIGO_PROPIETARIO=" & Me.TxtCodigoPropietario.Text)
                    Me.LblNombrePropietario.Text = sql.Result1.ToString
                End If
            Case Keys.Enter
                If txtLEN(Me.TxtCodigoPropietario.Text) = True Then
                    oPropietario.CODIGO_PROPIETARIO = CInt(Me.TxtCodigoPropietario.Text)
                    If oPropietario.Consultar() = True Then
                        Me.LblNombrePropietario.Text = oPropietario.NOMBRE_PROPIETARIO
                    Else
                        GoTo busca
                    End If
                End If
        End Select
        txtTAB(e)
    End Sub

#End Region

#Region "Eventos de la lista de elementos"
    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        Me.txtCodigoCliente.Text = Me.Grid.CurrentRow.Cells("CODIGO_CLIENTE").Value.ToString
        Me.Consultar()
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellDoubleClick
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    'Private Sub lstbElementos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstbElementos.Click

    'End Sub
    'Private Sub lstbElementos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstbElementos.DoubleClick
    '    Me.Estado = enumEstados.EDICION
    '    Me.Cambia_Estado()
    'End Sub

    'Private Sub lstbElementos_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstbElementos.Enter
    '    If Me.lstbElementos.Items.Count > 0 Then
    '        Me.tsbEditar.Enabled = True
    '    End If
    'End Sub

    'Private Sub lstbElementos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstbElementos.SelectedIndexChanged
    '    If Me.lstbElementos.SelectedIndex >= 0 Then
    '        Me.txtCodigoCliente.Text = Me.lstbElementos.SelectedValue.ToString
    '        Me.Consultar()
    '    End If
    'End Sub

#Region " Eventos de TxtFiltro y CboEstatusFiltro"
    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Me.Grid.DataSource = Nothing

        With Me.Grid
            If Me.rbtNombreCliente.Checked = True Then
                .DataSource = oClientes.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.CboEstatusFiltro.Text)
            Else
                .DataSource = oClientes.ObtenerElementosFiltroCodigoCliente(Me.txtFiltro.Text, Me.CboEstatusFiltro.Text)
            End If
            .Columns("CODIGO_CLIENTE").Width = 50
            .Columns("NOMBRE_CLIENTE").Width = 350
        End With
    End Sub

    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
            Me.Grid.DataSource = Nothing

            With Me.Grid
                If Me.rbtNombreCliente.Checked = True Then
                    .DataSource = oClientes.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.CboEstatusFiltro.Text)
                Else
                    .DataSource = oClientes.ObtenerElementosFiltroCodigoCliente(Me.txtFiltro.Text, Me.CboEstatusFiltro.Text)
                End If
                .Columns("CODIGO_CLIENTE").Width = 50
                .Columns("NOMBRE_CLIENTE").Width = 350
            End With
        End If
    End Sub
    Private Sub CboEstatusFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboEstatusFiltro.SelectedIndexChanged
        Me.Grid.DataSource = Nothing

        With Me.Grid
            If Me.rbtNombreCliente.Checked = True Then
                .DataSource = oClientes.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.CboEstatusFiltro.Text)
            Else
                .DataSource = oClientes.ObtenerElementosFiltroCodigoCliente(Me.txtFiltro.Text, Me.CboEstatusFiltro.Text)
            End If
            .Columns("CODIGO_CLIENTE").Width = 50
            .Columns("NOMBRE_CLIENTE").Width = 350
        End With
    End Sub
#End Region

    Private Sub rbtNombreCliente_CheckedChanged(sender As Object, e As EventArgs) Handles rbtNombreCliente.CheckedChanged
        Me.txtFiltro.Focus()
    End Sub

#End Region

#End Region

#Region "Métodos y procedimientos"
    Private Sub Catalogo_Clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DesplegarPaises()
        'Me.DesplegarEstados()
        Me.DesplegarVendedores()
        Me.DesplegarZonas()
        Me.DesplegarTiposMercados()
        Me.DesplegarElementos()
        Me.DesplegarMetodoPago()
        Me.DesplegarMetodoPagoDolares()
    End Sub

    Private Sub Cambia_Estado()
        Try
            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.cboTipoMercado.Enabled = True
                    Me.gBoxInformacion.Enabled = True

                    Me.tssLabelEstado.Text = "Agregando"
                    Me.tsbNuevo.Enabled = True
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = True
                    Me.tsbEliminar.Enabled = False

                    Me.TxtCodigoPropietario.Enabled = True

                    Me.txtCodigoCliente.Enabled = False
                    Me.TxtNombreCliente.Enabled = True
                    Me.txtRfc.Enabled = True
                    Me.txtCurp.Enabled = True
                    Me.txtNumeroCelular.Enabled = True
                    Me.txtNumeroExterior.Enabled = True
                    Me.txtNumeroInterior.Enabled = True
                    Me.txtNumeroTelefono.Enabled = True
                    Me.txtCalle.Enabled = True
                    Me.txtCiudad.Enabled = True
                    Me.txtCodigoPostal.Enabled = True
                    Me.txtColonia.Enabled = True
                    Me.txtLocalidad.Enabled = True
                    Me.txtPais.Enabled = True
                    Me.cboPais.Enabled = True
                    Me.cboEstado.Enabled = True
                    Me.cboMunicipio.Enabled = True
                    'Me.txtCuentaContable.Enabled = True
                    Me.txtCuentaContableDolares.Enabled = False
                    Me.BtnGeneraCuentaContableDolares.Enabled = False
                    Me.txtDiasPlazo.Enabled = True
                    Me.txtLimiteCredito.Enabled = True
                    Me.txtCorreoCliente.Enabled = True
                    Me.txtNumeroCuenta.Enabled = False
                    Me.txtNumeroCuentaDolares.Enabled = False
                    Me.txtNumeroRegistroIdentificadorExtranjero.Enabled = True

                    Me.cboMetodoPago.Enabled = True
                    Me.cboMetodoPagoDlls.Enabled = True
                    Me.CboEstatus.Enabled = False
                    Me.cboEstado.Enabled = True
                    Me.cboTipoPersona.Enabled = True
                    'Me.cboZona.Enabled = True
                    Me.cboVendedor.Enabled = True
                    Me.cboNombreXML.Enabled = True
                    Me.chkPermitirVentaCredito.Enabled = True
                    Me.TxtCodigoAlmacen.Enabled = True

                    Me.InicializaElemento()

                    Me.TxtNombreCliente.Focus()

                Case enumEstados.EDICION
                    Me.cboTipoMercado.Enabled = True
                    Me.gBoxInformacion.Enabled = True
                    Me.tssLabelEstado.Text = "Editando"
                    Me.tsbNuevo.Enabled = False
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = True
                    Me.tsbEliminar.Enabled = True

                    Me.TxtCodigoPropietario.Enabled = True

                    Me.txtCodigoCliente.Enabled = False
                    Me.TxtNombreCliente.Enabled = True
                    Me.txtRfc.Enabled = True
                    Me.txtCurp.Enabled = True
                    Me.txtNumeroCelular.Enabled = True
                    Me.txtNumeroExterior.Enabled = True
                    Me.txtNumeroInterior.Enabled = True
                    Me.txtNumeroTelefono.Enabled = True
                    Me.txtCalle.Enabled = True
                    Me.txtCiudad.Enabled = True
                    Me.txtCodigoPostal.Enabled = True
                    Me.txtColonia.Enabled = True
                    Me.txtLocalidad.Enabled = True
                    Me.txtPais.Enabled = True
                    Me.cboPais.Enabled = True
                    Me.cboEstado.Enabled = True
                    Me.cboMunicipio.Enabled = True
                    Me.txtCuentaContableDolares.Enabled = False
                    Me.BtnGeneraCuentaContableDolares.Enabled = False
                    Me.txtDiasPlazo.Enabled = True
                    Me.txtLimiteCredito.Enabled = True
                    Me.chkPermitirVentaCredito.Enabled = True
                    Me.txtCorreoCliente.Enabled = True
                    Me.txtNumeroCuenta.Enabled = False
                    Me.txtNumeroCuentaDolares.Enabled = False
                    Me.txtNumeroRegistroIdentificadorExtranjero.Enabled = True

                    Me.cboMetodoPago.Enabled = True
                    Me.cboMetodoPagoDlls.Enabled = True
                    Me.CboEstatus.Enabled = True
                    Me.cboEstado.Enabled = True
                    Me.cboTipoPersona.Enabled = True
                    'Me.cboZona.Enabled = True
                    Me.cboVendedor.Enabled = True
                    Me.cboNombreXML.Enabled = True
                    Me.TxtCodigoAlmacen.Enabled = True

                    If txtLEN(Me.txtCuentaContableDolares.Text) = False Then
                        Me.BtnGeneraCuentaContableDolares.Enabled = True
                    End If

                    Me.TxtNombreCliente.Focus()

                Case enumEstados.CONSULTA
                    Me.tsbNuevo.Enabled = True
                    Me.tsbEditar.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.tsbEliminar.Enabled = False

                    Me.TxtCodigoPropietario.Enabled = False

                    Me.cboTipoMercado.Enabled = False
                    Me.txtCodigoCliente.Enabled = False
                    Me.TxtNombreCliente.Enabled = False
                    Me.txtRfc.Enabled = False
                    Me.txtCurp.Enabled = False
                    Me.txtNumeroCelular.Enabled = False
                    Me.txtNumeroExterior.Enabled = False
                    Me.txtNumeroInterior.Enabled = False
                    Me.txtNumeroTelefono.Enabled = False
                    Me.txtCalle.Enabled = False
                    Me.txtCiudad.Enabled = False
                    Me.txtCodigoPostal.Enabled = False
                    Me.txtColonia.Enabled = False
                    Me.txtLocalidad.Enabled = False
                    Me.txtPais.Enabled = False
                    Me.cboPais.Enabled = False
                    Me.cboEstado.Enabled = False
                    Me.cboMunicipio.Enabled = False
                    Me.txtCuentaContableDolares.Enabled = False
                    Me.BtnGeneraCuentaContableDolares.Enabled = False
                    Me.txtDiasPlazo.Enabled = False
                    Me.txtLimiteCredito.Enabled = False
                    Me.tssLabelEstado.Text = "Consultando"
                    Me.txtCorreoCliente.Enabled = False
                    Me.txtNumeroCuenta.Enabled = False
                    Me.txtNumeroCuentaDolares.Enabled = False
                    Me.txtNumeroRegistroIdentificadorExtranjero.Enabled = False

                    Me.cboMetodoPagoDlls.Enabled = False
                    Me.cboMetodoPago.Enabled = False
                    Me.CboEstatus.Enabled = False
                    Me.cboEstado.Enabled = False
                    Me.cboTipoPersona.Enabled = False
                    'Me.cboZona.Enabled = False
                    Me.cboVendedor.Enabled = False
                    Me.cboNombreXML.Enabled = False
                    Me.chkPermitirVentaCredito.Enabled = False
                    Me.TxtCodigoAlmacen.Enabled = False
                    Me.txtFiltro.Focus()
                    Me.CboEstatusFiltro.SelectedIndex = 0
            End Select
            Application.DoEvents()

        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Sub InicializaElemento()
        Try
            Me.TxtCodigoPropietario.Text = ""
            Me.LblNombrePropietario.Text = ""
            Me.TxtIdRelacion.Text = ""
            Me.txtCodigoCliente.Text = ""
            Me.TxtNombreCliente.Text = ""
            Me.txtRfc.Text = ""
            Me.txtCurp.Text = ""
            Me.txtNumeroCelular.Text = ""
            Me.txtNumeroExterior.Text = ""
            Me.txtNumeroInterior.Text = ""
            Me.txtNumeroTelefono.Text = ""
            Me.txtCalle.Text = ""
            Me.txtCiudad.Text = ""
            Me.txtCodigoPostal.Text = ""
            Me.txtColonia.Text = ""
            Me.txtLocalidad.Text = ""
            Me.txtPais.Text = "MEXICO"
            Me.txtCuentaContable.Text = ""
            Me.txtCuentaContableDolares.Text = ""
            Me.txtDiasPlazo.Text = ""
            Me.txtLimiteCredito.Text = ""
            Me.txtCorreoCliente.Text = ""
            Me.txtNumeroCuenta.Text = ""
            Me.txtNumeroCuentaDolares.Text = ""
            Me.cboPais.SelectedIndex = -1
            Me.cboEstado.SelectedIndex = -1
            Me.cboMunicipio.SelectedIndex = -1

            Me.CboEstatus.SelectedIndex = 0
            Me.cboEstado.SelectedValue = "SIN"
            Me.cboTipoPersona.SelectedItem = "MORAL"
            Me.cboZona.SelectedValue = Plaza.CODIGO_ZONA_PRINCIPAL
            Me.cboVendedor.SelectedValue = "1"
            Me.cboMetodoPago.SelectedValue = "NA"
            Me.cboMetodoPagoDlls.SelectedValue = "NA"
            Me.cboNombreXML.SelectedValue = ""
            Me.cboNombreXML.Text = ""
            Me.chkPermitirVentaCredito.Checked = False
            Me.DpFecha.Value = Now
            Me.txtNumeroRegistroIdentificadorExtranjero.Text = ""
            Me.TxtCodigoAlmacen.Text = ""
            Me.chkEsContribuyenteIEPS.Checked = False
        Catch ex As Exception
            HandleError(Me.Name, "InicializaElemento", ex)
        End Try
    End Sub

    'Private Sub LlenaElemento(ByVal iCodigo_Elemento As String)
    '    Dim oElemento As New Class_CatClientes
    '    oElemento.CODIGO_CLIENTE = iCodigo_Elemento
    '    If oElemento.Consultar Then
    '        With oElemento
    '            Me.txtCodigoCliente.Text = .CODIGO_CLIENTE
    '            Me.TxtNombreCliente.Text = .NOMBRE_CLIENTE
    '            Me.txtRfc.Text = .RFC
    '            Me.txtCurp.Text = .CURP
    '            Me.txtNumeroCelular.Text = .CELULAR
    '            Me.txtNumeroExterior.Text = .NUMERO_EXTERIOR
    '            Me.txtNumeroInterior.Text = .NUMERO_INTERIOR
    '            Me.txtNumeroTelefono.Text = .TELEFONO
    '            Me.txtCalle.Text = .CALLE
    '            Me.txtCiudad.Text = .CIUDAD
    '            Me.txtCodigoPostal.Text = .CODIGO_POSTAL
    '            Me.txtColonia.Text = .COLONIA
    '            Me.txtLocalidad.Text = .LOCALIDAD
    '            Me.txtPais.Text = .PAIS
    '            Me.txtCuentaContable.Text = .CUENTA_CONTABLE
    '            Me.txtCuentaContableDolares.Text = .CUENTA_CONTABLE_DOLARES
    '            Me.txtDiasPlazo.Text = .DIAS_PLAZO.ToString
    '            Me.txtLimiteCredito.Text = .LIMITE_CREDITO.ToString

    '            Me.CboEstatus.Text = .Estatus
    '            Me.cboEstado.Text = .ESTADO
    '            Me.cboVendedor.SelectedValue = .CODIGO_VENDEDOR
    '            Me.cboZona.SelectedValue = .CODIGO_ZONA

    '            If .TIPO_PERSONA = "M" Then
    '                Me.cboTipoPersona.Text = "MORAL"
    '            Else
    '                Me.cboTipoPersona.Text = "FISICA"
    '            End If

    '            If .PERMITIR_VENTA_CREDITO = "1" Then
    '                Me.chkPermitirVentaCredito.Checked = True
    '            Else
    '                Me.chkPermitirVentaCredito.Checked = False
    '            End If

    '            If Me.txtCodigoCliente.Text.Remove(1, 4) = "N" Then
    '                Me.cboTipoMercado.SelectedIndex = 1
    '            Else
    '                Me.cboTipoMercado.SelectedIndex = 0
    '            End If

    '            Me.DpFecha.Value = .FECHA_ALTA
    '        End With
    '    End If
    '    oElemento = Nothing
    'End Sub

    Private Sub Grabar_Elemento()
        Dim oElemento As New Class_CatClientes
        Dim oMetodoPago As New Class_CFD_CatMetodosPago
        Dim Grabado As Boolean = False, tabla() As String, n As Integer

        Try
            If txtLEN(Me.TxtNombreCliente.Text) = False Then
                MsgBox("Asígne el nombre del cliente.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtNombreCliente.Focus()
                Exit Sub
            End If

            If txtLEN(Me.txtCorreoCliente.Text) = True Then
                tabla = Split(Me.txtCorreoCliente.Text, ";")

                For n = 0 To UBound(tabla, 1)
                    If IsEmailSyntaxValid(tabla(n)) = False Then
                        MsgBox("El correo del cliente es inválido, favor de verificar.", MsgBoxStyle.Exclamation, Me.Text)
                        Me.txtCorreoCliente.Focus()
                        Exit Sub
                    End If
                Next

            End If

            If Me.cboPais.SelectedIndex = -1 Then
                MsgBox("Seleccione por favor el pais del cliente.", MsgBoxStyle.Exclamation, Me.Name)
                Me.cboPais.Focus()
                Return
            End If

            If Me.cboPais.SelectedValue.ToString <> "MEX" Then
                If Me.cboEstado.SelectedIndex = -1 Then
                    MsgBox("Seleccione por favor el estado del cliente(es obligatorio si es pais<>mexico).", MsgBoxStyle.Exclamation, Me.Name)
                    Me.cboEstado.Focus()
                    Return
                End If
            End If

            If Me.cboMetodoPago.SelectedValue Is Nothing Then
                MsgBox("Seleccione el método de pago.", MsgBoxStyle.Exclamation, Me.Text)
                Me.cboMetodoPago.Focus()
                Return
            End If

            oMetodoPago = New Class_CFD_CatMetodosPago(Me.cboMetodoPago.SelectedValue.ToString)

            If oMetodoPago.REQUIERE_NUMERO_CUENTA_PAGO = 1 Then
                If txtLEN(Me.txtNumeroCuenta.Text) = False Then
                    'Actualmente es opcional
                    'MsgBox("El método de pago requiere número de cuenta, favor de verificar.", MsgBoxStyle.Exclamation, Me.Text)
                    'Me.txtNumeroCuenta.Focus()
                    'Exit Sub
                Else
                    If Len(Me.txtNumeroCuenta.Text) <> 4 Then
                        MsgBox("El número de cuenta debe ser de 4 caracteres, favor de verificar.", MsgBoxStyle.Exclamation, Me.Text)
                        Me.txtNumeroCuenta.Focus()
                        Exit Sub
                    End If
                End If
            End If

            'If Me.cboMetodoPagoDlls.SelectedValue Is Nothing Then
            '    MsgBox("Seleccione el método de pago en dólares.", MsgBoxStyle.Exclamation, Me.Text)
            '    Me.cboMetodoPagoDlls.Focus()
            '    Return
            'End If

            If Not (Me.cboMetodoPagoDlls.SelectedValue Is Nothing) Then
                oMetodoPago = New Class_CFD_CatMetodosPago(Me.cboMetodoPagoDlls.SelectedValue.ToString)

                If oMetodoPago.REQUIERE_NUMERO_CUENTA_PAGO = 1 Then
                    If txtLEN(Me.txtNumeroCuentaDolares.Text) = False Then
                        MsgBox("El método de pago requiere número de cuenta dólares, favor de verificar.", MsgBoxStyle.Exclamation, Me.Text)
                        Me.txtNumeroCuentaDolares.Focus()
                        Exit Sub
                    Else
                        If Len(Me.txtNumeroCuentaDolares.Text) <> 4 Then
                            MsgBox("El número de cuenta dólares debe ser de 4 caracteres, favor de verificar.", MsgBoxStyle.Exclamation, Me.Text)
                            Me.txtNumeroCuentaDolares.Focus()
                            Exit Sub
                        End If
                    End If
                End If
            End If

            Select Case Me.Estado
                Case enumEstados.NUEVO, enumEstados.EDICION
                    oElemento = New Class_CatClientes
                    With oElemento
                        .CODIGO_CLIENTE = Me.txtCodigoCliente.Text
                        .NOMBRE_CLIENTE = Me.TxtNombreCliente.Text
                        .Status = Strings.Left(Me.CboEstatus.Text, 1)
                        .RFC = Me.txtRfc.Text
                        If Me.cboTipoPersona.Text = "MORAL" Then
                            .TIPO_PERSONA = "M"
                        Else
                            .TIPO_PERSONA = "F"
                        End If
                        .CURP = Me.txtCurp.Text
                        .TELEFONO = Me.txtNumeroTelefono.Text
                        .CELULAR = Me.txtNumeroCelular.Text
                        .CALLE = Me.txtCalle.Text
                        .NUMERO_EXTERIOR = Me.txtNumeroExterior.Text
                        .NUMERO_INTERIOR = Me.txtNumeroInterior.Text
                        .COLONIA = Me.txtColonia.Text
                        .CIUDAD = Me.txtCiudad.Text
                        .LOCALIDAD = Me.txtLocalidad.Text
                        .ESTADO = Me.cboEstado.Text
                        .PAIS = Me.txtPais.Text
                        .CODIGO_POSTAL = Me.txtCodigoPostal.Text
                        .CODIGO_ZONA = Me.cboZona.SelectedValue.ToString
                        .CODIGO_VENDEDOR = Me.cboVendedor.SelectedValue.ToString
                        .CUENTA_CONTABLE_DOLARES = Me.txtCuentaContableDolares.Text
                        .LIMITE_CREDITO = valorNumerico(Me.txtLimiteCredito.Text)
                        .DIAS_PLAZO = valorNumerico(Me.txtDiasPlazo.Text)
                        .PERMITIR_VENTA_CREDITO = Convert.ToInt32(Me.chkPermitirVentaCredito.Checked).ToString
                        .FECHA_ALTA = Me.DpFecha.Value
                        .PLAZA = Usuario.Codigo_Plaza.ToString
                        .CORREO_CLIENTE = Me.txtCorreoCliente.Text
                        .CODIGO_METODO_PAGO = Me.cboMetodoPago.SelectedValue.ToString
                        .NUMERO_CUENTA_PAGO = Me.txtNumeroCuenta.Text
                        If Not (Me.cboMetodoPagoDlls.SelectedValue Is Nothing) Then
                            .CODIGO_METODO_PAGO_DOLARES = Me.cboMetodoPagoDlls.SelectedValue.ToString
                        Else
                            .CODIGO_METODO_PAGO_DOLARES = ""
                        End If
                        .NUMERO_CUENTA_PAGO_DOLARES = Me.txtNumeroCuentaDolares.Text
                        .CODIGO_TIPO_MERCADO = Me.cboTipoMercado.SelectedValue.ToString
                        .FORMATO_NOMBRE_XML = Me.cboNombreXML.Text
                        .NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO = Me.txtNumeroRegistroIdentificadorExtranjero.Text.Trim
                        .CODIGO_ALMACEN = Me.TxtCodigoAlmacen.Text
                        .CODIGO_PAIS_SAT = Me.cboPais.SelectedValue.ToString
                        If Me.cboEstado.SelectedIndex <> -1 Then
                            .CODIGO_ESTADO = Me.cboEstado.SelectedValue.ToString
                        Else
                            .CODIGO_ESTADO = ""
                        End If

                        If Me.cboMunicipio.SelectedIndex <> -1 Then
                            .CODIGO_MUNICIPIO = Me.cboMunicipio.SelectedValue.ToString
                        Else
                            .CODIGO_MUNICIPIO = "0"
                        End If

                        .ES_CONTRIBUYENTE_IEPS = Convert.ToInt32(Me.chkEsContribuyenteIEPS.Checked).ToString

                        If txtLEN(Me.TxtCodigoPropietario.Text) = True Then
                            .CODIGO_PROPIETARIO = Me.TxtCodigoPropietario.Text

                            If txtLEN(Me.TxtIdRelacion.Text) = True Then
                                .ID = Me.TxtIdRelacion.Text
                            Else
                                .ID = "0"
                            End If
                        End If

                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                .AGREGAR = "1"
                                If .Insertar() = False Then
                                    Exit Sub
                                End If
                            Case enumEstados.EDICION
                                .AGREGAR = "0"
                                If .Actualizar() = False Then
                                    Exit Sub
                                End If
                        End Select


                        MsgBox(Me.msgElemento & " Grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
                        Me.Estado = enumEstados.CONSULTA
                        Me.Cambia_Estado()
                        Me.DesplegarElementos()

                    End With

            End Select

        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
            Me.Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
        Finally
            oElemento = Nothing
        End Try

    End Sub

    Private Sub GeneraCuentaContableDolares()
        Dim generado As Boolean = False
        Try
            With oClientes
                .CODIGO_CLIENTE = Me.txtCodigoCliente.Text
                .NOMBRE_CLIENTE = Me.TxtNombreCliente.Text

                If .EstablecerCuentaContableDolares() Then
                    generado = True
                End If

                If generado Then
                    MsgBox("Cuenta contable en dolares creada satisfactoriamente.", MsgBoxStyle.Information)
                    Me.Estado = enumEstados.CONSULTA
                    Me.Cambia_Estado()
                    DesplegarElementos()
                End If
            End With

        Catch ex As Exception
            HandleError(Me.Name, "GeneraCuentaContableDolares", ex)
            Me.Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
        Finally
            oClientes = Nothing
        End Try
    End Sub

    Private Sub Elimina_Elemento()
        Dim oElemento As New Class_CatClientes
        Dim Eliminado As Boolean = False
        Try
            With oElemento
                .CODIGO_CLIENTE = Me.txtCodigoCliente.Text
                .CUENTA_CONTABLE = Me.txtCuentaContable.Text
                .CUENTA_CONTABLE_DOLARES = Me.txtCuentaContableDolares.Text

                If .EliminarCliente() Then
                    Eliminado = True
                End If
            End With

            If Eliminado = True Then
                MsgBox(Me.msgElemento & " Eliminado satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
                Me.Estado = enumEstados.NUEVO
                Me.Cambia_Estado()
                DesplegarElementos()
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Eliminar", ex)
            Me.Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
        Finally
            oElemento = Nothing
        End Try
    End Sub

    Private Function IsEmailSyntaxValid(ByVal emailToValidate As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(emailToValidate, "^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
    End Function

    Private Function LlenaComboEstatus() As Boolean
        Me.CboEstatus.Items.Add("A")
        Me.CboEstatus.Items.Add("B")

        Me.CboEstatus.SelectedItem = "A"
    End Function

    Private Function LlenaComboTipoPersona() As Boolean
        Me.cboTipoPersona.Items.Add("MORAL")
        Me.cboTipoPersona.Items.Add("FISICA")
    End Function

    Private Sub DesplegarZonas()
        Try
            Dim oElementos As New Class_CatZonas
            With Me.cboZona
                .DisplayMember = "NOMBRE_ZONA"
                .ValueMember = "CODIGO_ZONA"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_ZONA"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarZonas", ex)
        End Try
    End Sub

    Private Sub DesplegarTiposMercados()
        Try
            Dim oElementos As New Class_TiposMercados
            With Me.cboTipoMercado
                .DisplayMember = "NOMBRE_TIPO_MERCADO"
                .ValueMember = "CODIGO_TIPO_MERCADO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_TIPO_MERCADO"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarTiposMercados", ex)
        End Try
    End Sub

    Private Sub DesplegarVendedores()
        Try
            Dim oElementos As New Class_CatVendedores
            With Me.cboVendedor
                .DisplayMember = "Nombre_Vendedor"
                .ValueMember = "CODIGO_Vendedor"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "Nombre_Vendedor"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarVendedores", ex)
        End Try
    End Sub

    Private Function Consultar() As Boolean
        Dim bResultado As Boolean = False

        Try
            Dim sFolio As String = Me.txtCodigoCliente.Text
            Me.InicializaElemento()
            Me.oClientes = New Class_CatClientes()
            Me.oClientes.CODIGO_CLIENTE = sFolio

            If Me.oClientes.Consultar = False Then
                Me.Estado = enumEstados.NUEVO
                Me.Cambia_Estado()
                Exit Function
            Else
                With Me.oClientes
                    Me.txtCodigoCliente.Text = .CODIGO_CLIENTE
                    Me.TxtNombreCliente.Text = .NOMBRE_CLIENTE
                    Me.txtRfc.Text = .RFC
                    Me.txtCurp.Text = .CURP
                    Me.txtNumeroCelular.Text = .CELULAR
                    Me.txtNumeroExterior.Text = .NUMERO_EXTERIOR
                    Me.txtNumeroInterior.Text = .NUMERO_INTERIOR
                    Me.txtNumeroTelefono.Text = .TELEFONO
                    Me.txtCalle.Text = .CALLE
                    Me.txtCiudad.Text = .CIUDAD
                    Me.txtCodigoPostal.Text = .CODIGO_POSTAL
                    Me.txtColonia.Text = .COLONIA
                    Me.txtLocalidad.Text = .LOCALIDAD
                    Me.txtPais.Text = .PAIS
                    'Me.cboEstado.SelectedValue = .ESTADO

                    If txtLEN(.CODIGO_PAIS_SAT) = True Then
                        Me.cboPais.SelectedValue = .CODIGO_PAIS_SAT

                        If txtLEN(.CODIGO_ESTADO) = True Then
                            Me.cboEstado.SelectedValue = .CODIGO_ESTADO

                            If txtLEN(.CODIGO_MUNICIPIO) = True Then
                                Me.cboMunicipio.SelectedValue = .CODIGO_MUNICIPIO
                            End If
                        End If
                    End If
                    Me.txtCuentaContable.Text = .CUENTA_CONTABLE
                    Me.txtCuentaContableDolares.Text = .CUENTA_CONTABLE_DOLARES
                    Me.txtDiasPlazo.Text = .DIAS_PLAZO.ToString
                    Me.txtLimiteCredito.Text = FormatImporteContable(CDbl(.LIMITE_CREDITO.ToString), True)

                    If .Estatus = "A" Then
                        Me.CboEstatus.SelectedIndex = 0
                    Else
                        Me.CboEstatus.SelectedIndex = 1
                    End If
                    Me.cboVendedor.SelectedValue = .CODIGO_VENDEDOR
                    Me.cboZona.SelectedValue = .CODIGO_ZONA
                    Me.txtCorreoCliente.Text = .CORREO_CLIENTE.ToString

                    If .TIPO_PERSONA = "M" Then
                        Me.cboTipoPersona.Text = "MORAL"
                    Else
                        Me.cboTipoPersona.Text = "FISICA"
                    End If

                    If .PERMITIR_VENTA_CREDITO = "1" Then
                        Me.chkPermitirVentaCredito.Checked = True
                    Else
                        Me.chkPermitirVentaCredito.Checked = False
                    End If

                    Me.DpFecha.Value = .FECHA_ALTA

                    Me.cboTipoMercado.SelectedValue = .CODIGO_TIPO_MERCADO.ToString

                    Me.cboMetodoPago.SelectedValue = .CODIGO_METODO_PAGO
                    Me.txtNumeroCuenta.Text = .NUMERO_CUENTA_PAGO.ToString
                    Me.cboMetodoPagoDlls.SelectedValue = .CODIGO_METODO_PAGO_DOLARES
                    Me.txtNumeroCuentaDolares.Text = .NUMERO_CUENTA_PAGO_DOLARES.ToString
                    Me.cboNombreXML.SelectedValue = .FORMATO_NOMBRE_XML
                    Me.txtNumeroRegistroIdentificadorExtranjero.Text = .NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO
                    Me.TxtCodigoAlmacen.Text = .CODIGO_ALMACEN
                    Me.chkEsContribuyenteIEPS.Checked = CBool(.ES_CONTRIBUYENTE_IEPS)

                End With

                Dim sql As New Class_find("SELECT R.ID,R.CODIGO_PROPIETARIO,P.NOMBRE_PROPIETARIO FROM CAT_PROPIETARIOS_RELACION_CLIENTES R INNER JOIN CAT_PROPIETARIOS P ON(R.CODIGO_PROPIETARIO=P.CODIGO_PROPIETARIO) " _
                                          & "WHERE R.CODIGO_CLIENTE='" & Me.txtCodigoCliente.Text & "'")

                If sql.Result1 = "" Then
                    Me.TxtCodigoPropietario.Text = ""
                    Me.LblNombrePropietario.Text = ""
                    Me.TxtIdRelacion.Text = ""
                Else
                    Me.TxtIdRelacion.Text = sql.Result1
                    Me.TxtCodigoPropietario.Text = sql.Result2
                    Me.LblNombrePropietario.Text = sql.Result3
                End If

            End If
            bResultado = True

            'Me.Estado = enumEstados.EDICION
            'Me.Cambia_Estado()
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try

        Return bResultado
    End Function

    Private Sub DesplegarElementos()
        Try
            With Me.Grid
                .DataSource = oClientes.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.CboEstatusFiltro.Text)
                .Columns("CODIGO_CLIENTE").Width = 50
                .Columns("NOMBRE_CLIENTE").Width = 350
            End With

        Catch ex As Exception
            HandleError(Me.Name, "DesplegarElementos", ex)
        End Try
    End Sub

    Private Sub DesplegarMetodoPago()
        Try
            Dim oElementos As New Class_CFD_CatMetodosPago
            With Me.cboMetodoPago
                .DisplayMember = "NOMBRE_METODO_PAGO"
                .ValueMember = "CODIGO_METODO_PAGO"

                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_METODO_PAGO"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = "NA"
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarMetodoPago", ex)
        End Try
    End Sub

    Private Sub DesplegarMetodoPagoDolares()
        Try
            Dim oElementos As New Class_CFD_CatMetodosPago
            With Me.cboMetodoPagoDlls
                .DisplayMember = "NOMBRE_METODO_PAGO"
                .ValueMember = "CODIGO_METODO_PAGO"

                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_METODO_PAGO"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = "NA"
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarMetodoPagoDolares", ex)
        End Try
    End Sub

    Private Sub DesplegarPaises()
        Try
            Me.cboEstado.DataSource = Nothing
            Me.cboMunicipio.DataSource = Nothing
            Dim oElementos As New Class_CatPaises
            With Me.cboPais
                .DisplayMember = "NOMBRE_PAIS"
                .ValueMember = "CODIGO_PAIS_SAT"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_PAIS"
                .DataSource = dView
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarPaises", ex)
        End Try
    End Sub

    Private Sub DesplegarEstados()
        Try
            Me.cboEstado.DataSource = Nothing
            Me.cboMunicipio.DataSource = Nothing
            If Me.cboPais.SelectedIndex = -1 Then
                Return
            End If
            Dim oElementos As New Class_SisEstados
            With Me.cboEstado
                .DisplayMember = "NOMBRE_ESTADO"
                .ValueMember = "CODIGO_ESTADO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos(Me.cboPais.SelectedValue.ToString))
                dView.Sort = "NOMBRE_ESTADO"
                .DataSource = dView
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarEstados", ex)
        End Try
    End Sub

    Private Sub DesplegarMunicipios()
        Try
            Me.cboMunicipio.DataSource = Nothing
            If Me.cboEstado.SelectedIndex = -1 Then
                Return
            End If
            Dim oElementos As New Class_CatMunicipios
            With Me.cboMunicipio
                .DisplayMember = "NOMBRE_MUNICIPIO"
                .ValueMember = "CODIGO_MUNICIPIO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos(Me.cboEstado.SelectedValue.ToString))
                dView.Sort = "NOMBRE_MUNICIPIO"
                .DataSource = dView
                .SelectedIndex = -1
            End With
            If Me.cboMunicipio.Items.Count = 0 Then
                Me.txtCiudad.ReadOnly = False
            Else
                Me.txtCiudad.ReadOnly = True
            End If
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarMunicipios", ex)
        End Try
    End Sub

#End Region

End Class