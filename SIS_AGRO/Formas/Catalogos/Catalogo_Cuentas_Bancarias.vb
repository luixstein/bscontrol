Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Catalogo_Cuentas_Bancarias
    Private oProveedor As New Class_CatProveedores

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_Cuenta_Bancaria As Integer
    Private _Nombre_Cuenta_Bancaria As String
    Private _Estatus As String
#End Region

#Region "Campos ligados a la tabla"

#End Region

#Region "Campos públicos"

#End Region

#Region "Campos privados"
    Private Enum enumEstados
        NUEVO
        EDICION
        CONSULTA
    End Enum

    Private Estado As enumEstados
    'Private Run As Boolean
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

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property ID_Cuenta_Bancaria() As Integer
        Get
            Return Me._ID_Cuenta_Bancaria
        End Get
        Set(ByVal value As Integer)
            Me._ID_Cuenta_Bancaria = value
        End Set
    End Property

    Public Property Nombre_Cuenta_Bancaria() As String
        Get
            Return Me._Nombre_Cuenta_Bancaria
        End Get
        Set(ByVal value As String)
            Me._Nombre_Cuenta_Bancaria = value
        End Set
    End Property

    Public Property Estatus() As String
        Get
            Return Me._Estatus
        End Get
        Set(ByVal value As String)
            Me._Estatus = value
        End Set
    End Property


#End Region

#Region "Propiedades de campos ligados a la tabla"

#End Region

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

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
    'Inicializa al objeto.
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Try
            Me.msgElemento = "Cuenta_Bancaria"
            Me.msgElementos = "Cuenta_Bancarias"
            'Me.Run = False
            'Me.lstbElementos.ContextMenuStrip = Me.cMenuStripAccion
            InicializaElemento()
            Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
            Me.DesplegarElementos()
            Me.DesplegarCboCodigoMoneda()
            'Me.Run = True
            Me.CboEstatus.SelectedIndex = 0
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
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        If txtLEN(Me.TxtNombreCuenta.Text) = True Then
            Me.Estado = enumEstados.EDICION
        Else
            Me.Estado = enumEstados.NUEVO
        End If

        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del " & Me.msgElemento & " : " & Me.TxtIDCuenta.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el " & Me.msgElemento & " : " & Me.TxtIDCuenta.Text
        End Select

        sMsg = "Deseas " & sMsg & " ?"
        If MsgBox(sMsg, CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle)) = MsgBoxResult.Yes Then
            Call Grabar_Elemento()
        End If

    End Sub

    Private Sub tsbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
        Me.Estado = enumEstados.CONSULTA
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbImprimirListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirListado.Click
        Dim oElementos As New Class_CatCuentasBancarias

        oElementos.Imprimir_Listado()

        oElementos = Nothing
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub Refrescar()
        Me.DesplegarElementos()
        Me.DesplegarCboCodigoMoneda()
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
                    Me.tsbCancelar.Enabled = True

                    Me.TxtIDCuenta.Enabled = False
                    Me.TxtNombreCuenta.Enabled = True
                    Me.CboEstatus.Enabled = False
                    Me.txtCuentaContableDolares.Enabled = False

                    Me.InicializaElemento()

                Case enumEstados.EDICION
                    Me.gBoxInformacion.Enabled = True
                    Me.gBoxBusquedaRapida.Enabled = False
                    Me.tssLabelEstado.Text = "Editando"
                    Me.tsbNuevo.Enabled = False
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = True
                    Me.TxtCodigoProveedor.Enabled = False
                    Me.txtCuentaContable.Enabled = False
                    Me.txtCuentaContableDolares.Enabled = False


                    Me.TxtIDCuenta.Enabled = False
                    Me.TxtNombreCuenta.Enabled = True
                    Me.CboEstatus.Enabled = True

                Case enumEstados.CONSULTA
                    Me.gBoxInformacion.Enabled = False
                    Me.gBoxBusquedaRapida.Enabled = True
                    Me.tssLabelEstado.Text = "Consultando"
                    Me.tsbNuevo.Enabled = True
                    Me.tsbEditar.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.cboEstatusFiltro.SelectedIndex = 0
                    'If Me.Run Then
                    '    If Me.lstbElementos.SelectedIndex < 0 Then
                    '        Me.lstbElementos.SelectedIndex = 0
                    '    Else
                    '        iIndex = Me.lstbElementos.SelectedIndex
                    '        Me.lstbElementos.SelectedIndex = -1
                    '        Me.lstbElementos.SelectedIndex = iIndex
                    '    End If
                    'End If
                    Me.txtFiltro.Focus()
            End Select
            Application.DoEvents()

        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Sub InicializaElemento()
        Me.TxtIDCuenta.Text = CodigoSiguiente().ToString
        Me.TxtNombreCuenta.Text = ""
        Me.TxtNumeroCuenta.Text = ""
        Me.TxtSucursal.Text = ""
        Me.TxtTelefono.Text = ""
        Me.TxtBanco.Text = ""
        Me.LblBanco.Text = ""
        Me.TxtSaldo.Text = ""
        Me.TxtFolioCheque.Text = ""
        Me.txtCuentaContable.Text = ""
        Me.txtCuentaContableDolares.Text = ""
        Me.LblCuenta.Text = ""
        Me.LblCuentaDolares.Text = ""
        Me.TxtFormatoReporte.Text = ""
        Me.CboEstatus.SelectedIndex = 0
        Me.TxtCodigoProveedor.Text = "" 'oProveedor.CodigoSiguiente
        Me.TxtCodigoProveedor.Enabled = False
        Me.txtCuentaContable.Enabled = False
        Me.LblNombreProveedor.Text = ""
        Me.CboCodigoMoneda.SelectedIndex = 0
    End Sub

    Private Sub DesplegarElementos()
        Try
            Dim oElementos As New Class_CatCuentasBancarias
            With Me.Grid
                .DataSource = oElementos.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
                .Columns("ID_CUENTA_BANCARIA").Width = 150
                .Columns("NOMBRE_CUENTA_BANCARIA").Width = 200
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarElementos", ex)
        End Try
    End Sub

    Private Sub DesplegarCboCodigoMoneda()
        Try
            Dim oElementos As New Class_CatMonedas
            With Me.CboCodigoMoneda
                .DisplayMember = "NOMBRE"
                .ValueMember = "CODIGO_MONEDA"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "CODIGO_MONEDA"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarCboCodigoMoneda", ex)
        End Try
    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As Integer)
        Try
            Dim oElemento As New Class_CatCuentasBancarias
            oElemento.ID_CUENTA_BANCARIA = iCodigo_Elemento
            If oElemento.Consultar Then
                With oElemento
                    Me.TxtIDCuenta.Text = .ID_CUENTA_BANCARIA.ToString
                    Me.TxtNombreCuenta.Text = .NOMBRE_CUENTA_BANCARIA.ToString
                    Me.TxtNumeroCuenta.Text = .NUMERO_CUENTA_BANCARIA
                    Me.TxtSucursal.Text = .SUCURSAL
                    Me.TxtTelefono.Text = .TELEFONO
                    Me.TxtBanco.Text = .CODIGO_BANCO
                    Dim sql As New Class_find("SELECT NOMBRE_BANCO FROM CAT_BANCOS WHERE CODIGO_BANCO='" & Me.TxtBanco.Text & "' AND ESTATUS_BANCO='A' AND PROTEGIDO='0'")
                    Me.LblBanco.Text = sql.Result1
                    Me.TxtCodigoProveedor.Text = .CODIGO_PROVEEDOR
                    If txtLEN(Me.TxtCodigoProveedor.Text) Then
                        Dim sql3 As New Class_find("SELECT NOMBRE_PROVEEDOR FROM CAT_PROVEEDORES WHERE CODIGO_PROVEEDOR='" & Me.TxtCodigoProveedor.Text & "'")
                        Me.LblNombreProveedor.Text = sql3.Result1
                    End If

                    Me.TxtSaldo.Text = .SALDO.ToString
                    Me.TxtFolioCheque.Text = .FOLIO_CHEQUE

                    Me.txtCuentaContable.Text = .CUENTA_CONTABLE_PESOS
                    Dim sql1 As New Class_find("SELECT NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & Me.txtCuentaContable.Text & "'")
                    Me.LblCuenta.Text = sql1.Result1

                    Me.txtCuentaContableDolares.Text = .CUENTA_CONTABLE_DOLARES
                    If txtLEN(Me.txtCuentaContableDolares.Text) Then
                        Dim sql2 As New Class_find("SELECT NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & Me.txtCuentaContableDolares.Text & "'")
                        Me.LblCuentaDolares.Text = sql2.Result1
                    Else
                        Me.LblCuentaDolares.Text = ""
                    End If

                    Me.CboCodigoMoneda.SelectedValue = .CODIGO_MONEDA
                    Me.TxtFormatoReporte.Text = .NOMBRE_FORMATO
                    If .ESTATUS_CUENTA_BANCARIA = "A" Then
                        Me.CboEstatus.SelectedIndex = 0
                    Else
                        Me.CboEstatus.SelectedIndex = 1
                    End If
                End With

            End If
            oElemento = Nothing
        Catch ex As Exception
            HandleError(Me.Name, "LlenaElemento", ex)
        End Try
    End Sub

    Public Function CodigoSiguiente() As Integer
        Dim Resultado As Integer
        Dim sql As New Class_find("SELECT MAX(ID_Cuenta_Bancaria) FROM CAT_CUENTAS_BANCARIAS")

        Resultado = CType(valorNumerico(sql.Result1), Integer) + 1
        CodigoSiguiente = Resultado
    End Function

    Private Function GrabaProveedor() As Boolean
        Dim bResultado As Boolean = False
        oProveedor = New Class_CatProveedores
        Dim sql As New Class_find("SELECT CODIGO_TIPO_PROVEEDOR_CUENTA_BANCARIA FROM SIS_EMPRESA WHERE NOMBRE_EMPRESA ='" & Empresa_Sistema.NOMBRE_EMPRESA & "'")
        Dim codigoTipoProveedorCuentaBancaria As String = sql.Result1
        Try
            With oProveedor
                .Codigo_Proveedor = Me.TxtCodigoProveedor.Text
                .Nombre_Proveedor = Me.TxtNombreCuenta.Text
                .Plazo = 0
                .Domicilio = "N/A"
                .RFC = "N/A"
                .CURP = "N/A"
                .Telefono = "N/A"
                .Fax = "N/A"
                .Celular = "N/A"
                .Correo_Electronico = "N/A"
                .CUENTA_CONTABLE = ""
                .CUENTA_CONTABLE_DOLARES = Me.txtCuentaContableDolares.Text
                .Codigo_Tipo_Proveedor = codigoTipoProveedorCuentaBancaria
                .Contacto = "N/A"
                .Contacto_Telefono_Celular = "N/A"
                .CODIGO_PLAZA = Usuario.Codigo_Plaza

                If .Insertar() = True Then
                    bResultado = True
                End If

            End With
        Catch ex As Exception
            HandleError(Me.Name, "GrabaProveedor", ex)
        End Try

        Return bResultado

    End Function

    Private Sub Grabar_Elemento()

        If Me.Validar() = False Then
            Exit Sub
        End If

        Dim oElemento As New Class_CatCuentasBancarias
        Dim Grabado As Boolean = False
        'Dim iIndex As Integer = Me.lstbElementos.SelectedIndex
        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                oElemento = New Class_CatCuentasBancarias
                Try
                    With oElemento
                        .ID_CUENTA_BANCARIA = CInt(0 & Me.TxtIDCuenta.Text)
                        .NOMBRE_CUENTA_BANCARIA = Me.TxtNombreCuenta.Text
                        .SUCURSAL = Me.TxtSucursal.Text
                        .NUMERO_CUENTA_BANCARIA = Me.TxtNumeroCuenta.Text
                        .TELEFONO = Me.TxtTelefono.Text
                        .SALDO = 0 'CONVERT.TODECIMAL(0 & ME.TXTSALDO.TEXT)
                        .CODIGO_BANCO = Me.TxtBanco.Text
                        .FOLIO_CHEQUE = Me.TxtFolioCheque.Text
                        .CUENTA_CONTABLE_PESOS = Me.txtCuentaContable.Text
                        .CUENTA_CONTABLE_DOLARES = Me.txtCuentaContableDolares.Text
                        .NOMBRE_FORMATO = Me.TxtFormatoReporte.Text
                        .ESTATUS_CUENTA_BANCARIA = Strings.Left(Me.CboEstatus.Text, 1)
                        .CODIGO_PROVEEDOR = Me.TxtCodigoProveedor.Text
                        .CODIGO_MONEDA = (Me.CboCodigoMoneda.SelectedValue).ToString
                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                'If GrabaProveedor() = True Then
                                '    oProveedor.Codigo_Proveedor = Strings.Left(Me.TxtCodigoProveedor.Text, 2) & Strings.Right("0000" & CInt(Me.TxtCodigoProveedor.Text).ToString, 4)
                                '    oProveedor.Consultar()
                                '    .CUENTA_CONTABLE_PESOS = oProveedor.CUENTA_CONTABLE
                                If .Insertar() Then
                                    Grabado = True
                                    Me.Estado = enumEstados.NUEVO
                                    oProveedor = Nothing
                                End If
                                'End If

                            Case enumEstados.EDICION
                                If .Actualizar() Then
                                    Grabado = True
                                    Me.Estado = enumEstados.CONSULTA
                                End If
                        End Select

                        If Grabado Then
                            MsgBox(Me.msgElemento & " Grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
                            Me.Refrescar()
                            Me.Cambia_Estado()
                        End If

                    End With
                Catch ex As Exception
                    HandleError(Me.Name, "Grabar", ex)
                    Me.Estado = enumEstados.CONSULTA
                    Me.Cambia_Estado()
                    'Me.lstbElementos.SelectedIndex = -1
                    'Me.lstbElementos.SelectedIndex = iIndex
                Finally
                    oElemento = Nothing
                End Try
        End Select
    End Sub

    Private Function Validar() As Boolean
        Try
            'If PLAZA.ValidarPeriodoTrabajo(Me.DtpFechaFactura.Value) = False Then
            '    Exit Function
            'End If

            'If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.CmbDocumento.SelectedValue.ToString) = False Then
            '    MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
            '    Exit Function
            'End If

            If txtLEN(Me.TxtNombreCuenta.Text) = False Then
                MsgBox("Asígne un nombre a la cuenta bancaria.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtNombreCuenta.Focus()
                Return False
            End If

            Dim sql0 As New Class_find("SELECT 1 FROM CAT_BANCOS WHERE CODIGO_BANCO='" & Me.TxtBanco.Text & "' ")
            If sql0.Result1 = "" Then
                MsgBox("El codigo de Banco que intenta buscar no existe, favor de intentar con otro codigo", MsgBoxStyle.Critical, "Validación de Bancoes")
                Me.LblBanco.Text = ""
                Me.TxtBanco.Focus()
                Return False
            End If

            'Dim sql1 As New Class_find("SELECT 1 FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & Me.txtCuentaContable.Text & "' AND ESMAYOR=0 ")
            'If sql1.Result1 = "" Then
            '    MsgBox("La cuenta contable que intenta guardar no es valida, favor de revisar", MsgBoxStyle.Critical, "Validación de la cuenta contable")
            '    Me.txtCuentaContable.Focus()
            '    Me.LblCuenta.Text = ""
            '    sql1 = Nothing
            '    Exit Function
            'End If
            'sql1 = Nothing

            If txtLEN(Me.txtCuentaContableDolares.Text) = True Then
                Dim sql2 As New Class_find("SELECT 1 FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & Me.txtCuentaContableDolares.Text & "' AND ESMAYOR=0 ")
                If sql2.Result1 = "" Then
                    MsgBox("La cuenta contable que intenta guardar no es valida, favor de revisar", MsgBoxStyle.Critical, "Validación de la cuenta contable")
                    Me.txtCuentaContableDolares.Focus()
                    Me.LblCuentaDolares.Text = ""
                    sql2 = Nothing
                    Return False
                End If
                sql2 = Nothing
            End If

            'If Me.LblCuenta.Text <> Me.TxtNombreCuenta.Text Then
            '    MsgBox("El nombre de la cuenta bancaria es diferente de la cuenta contable, favor de revisar", MsgBoxStyle.Critical, "Validación de la cuenta bancaria")
            '    Exit Function
            'End If

            If Me.Estado = enumEstados.EDICION Then
                If txtLEN(Me.TxtCodigoProveedor.Text) = False Then
                    MsgBox("Ingrese un código de proveedor.", MsgBoxStyle.Exclamation, Me.Text)
                    Me.TxtCodigoProveedor.Focus()
                    Return False
                End If
            End If

            Return True
        Catch ex As Exception
            HandleError(Me.Name, "Validar", ex)
        End Try
    End Function

#End Region

#Region "Eventos de objetos"
#Region "Eventos de Grid"
    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        Me.LlenaElemento(CInt(Me.Grid.CurrentRow.Cells("ID_CUENTA_BANCARIA").Value.ToString))
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
    '    InicializaElemento()
    '    If Me.lstbElementos.SelectedIndex >= 0 Then
    '        Me.LlenaElemento(CType(valorNumerico(Me.lstbElementos.SelectedValue.ToString), Integer))
    '    End If
    'End Sub
#End Region

#Region " Eventos de TxtFiltro"
    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Dim oElementos As New Class_CatCuentasBancarias
        Me.Grid.DataSource = Nothing

        With Me.Grid
            .DataSource = oElementos.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
            .Columns("ID_CUENTA_BANCARIA").Width = 150
            .Columns("NOMBRE_CUENTA_BANCARIA").Width = 200
        End With
    End Sub
    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub
    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        Dim oElementosFiltro As New Class_CatCuentasBancarias
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
            Me.Grid.DataSource = Nothing

            With Me.Grid
                .DataSource = oElementosFiltro.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
                .Columns("ID_CUENTA_BANCARIA").Width = 150
                .Columns("NOMBRE_CUENTA_BANCARIA").Width = 200
            End With
        End If
    End Sub

    Private Sub CboEstatusFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstatusFiltro.SelectedIndexChanged
        Dim oElementos As New Class_CatCuentasBancarias
        Me.Grid.DataSource = Nothing

        With Me.Grid
            .DataSource = oElementos.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.cboEstatusFiltro.Text)
            .Columns("ID_CUENTA_BANCARIA").Width = 150
            .Columns("NOMBRE_CUENTA_BANCARIA").Width = 200
        End With
    End Sub
#End Region

#Region "Eventos Genericos"

    Private Sub CboEstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboEstatus.KeyDown
        If e.KeyCode = Keys.Return Then
            tsbGrabar.PerformClick()
        End If
    End Sub
    Private Sub txtFormatoReporte_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFormatoReporte.KeyDown
        If e.KeyCode = Keys.Return Then
            Select Case Me.Estado
                Case enumEstados.NUEVO
                    tsbGrabar.PerformClick()
                Case enumEstados.EDICION
                    SendKeys.Send("{TAB}")
            End Select

        End If
    End Sub

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboEstatus.KeyPress, TxtNombreCuenta.KeyPress, TxtNumeroCuenta.KeyPress, TxtSucursal.KeyPress, TxtTelefono.KeyPress, TxtFolioCheque.KeyPress, TxtBanco.KeyPress, TxtFormatoReporte.KeyPress, txtCuentaContableDolares.KeyPress, TxtCodigoProveedor.KeyPress, CboCodigoMoneda.KeyPress, txtCuentaContable.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombreCuenta.KeyDown, TxtSucursal.KeyDown, TxtNumeroCuenta.KeyDown, TxtTelefono.KeyDown, TxtFolioCheque.KeyDown, txtCuentaContableDolares.KeyDown, CboCodigoMoneda.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNumericos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtIDCuenta.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumericos_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim t As TextBox
        t = CType(sender, TextBox)
        If Not IsNumeric(t.Text) Then
            t.Text = Val(t.Text).ToString
        Else
            Me.ErrorProvider.Clear()
        End If
    End Sub
#End Region

#Region "Keydown específicos"
    Private Sub TxtBanco_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBanco.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
                Dim Busqueda = New Busqueda_General("CODIGO_BANCO AS CODIGO,NOMBRE_BANCO AS NOMBRE", "CAT_BANCOS", " 1=1 AND ESTATUS_BANCO='A' AND PROTEGIDO='0' ", "NOMBRE", "NOMBRE_BANCO")
                Busqueda.ShowDialog()
                Me.TxtBanco.Text = "" & Busqueda.Tag.ToString
                Busqueda.Dispose()
            Case Keys.Return
                Dim sql As New Class_find("SELECT NOMBRE_BANCO FROM CAT_BANCOS WHERE CODIGO_BANCO='" & Me.TxtBanco.Text & "' AND ESTATUS_BANCO='A' AND PROTEGIDO='0'")
                If sql.Result1 = "" Then
                    MsgBox("El codigo de Banco que intenta buscar no existe o esta dado de Baja, favor de intentar con otro codigo", MsgBoxStyle.Critical, "Validación de Bancoes")
                    Me.LblBanco.Text = ""
                    Me.TxtBanco.Focus()
                    Exit Sub
                Else
                    Me.LblBanco.Text = sql.Result1
                    Me.TxtFolioCheque.Focus()
                End If
            Case Keys.Escape
                Me.TxtTelefono.Focus()
        End Select

    End Sub

    Private Sub txtCuentaContable_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuentaContable.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
busqueda_Visual:
                Dim oCuenta As New Class_CatCuentas
                Dim sCuenta As String = oCuenta.BusquedaVisual_PorCodigoFiltrandoTipoOperacion()
                If sCuenta.Length > 0 Then
                    Me.txtCuentaContable.Text = sCuenta
                    sCuenta = Replace(sCuenta, "'", "''")
                    Dim sql As New Class_find("SELECT NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & sCuenta & "'")
                    Me.txtCuentaContable.Text = sCuenta
                    Me.LblCuenta.Text = sql.Result1
                    Me.txtCuentaContableDolares.Focus()
                    sql = Nothing
                Else
                    Me.txtCuentaContable.Text = ""
                    Me.LblCuenta.Text = ""
                    Me.txtCuentaContable.Focus()
                End If

            Case Keys.F7
                Dim oCuenta As New Class_CatCuentas
                Dim sCuenta As String = oCuenta.BusquedaVisual_PorNombreFiltrandoTipoOperacion()
                If sCuenta.Length > 0 Then
                    Me.txtCuentaContable.Text = sCuenta
                    sCuenta = Replace(sCuenta, "'", "''")
                    Dim sql As New Class_find("Select CUENTA_CONTABLE,NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & sCuenta & "' AND ESMAYOR=0 ")
                    Me.txtCuentaContable.Text = sCuenta
                    Me.LblCuenta.Text = sql.Result2
                    Me.txtCuentaContableDolares.Focus()
                    sql = Nothing
                Else
                    Me.txtCuentaContable.Text = ""
                    Me.LblCuenta.Text = ""
                    Me.txtCuentaContable.Focus()
                End If

            Case Keys.Return
                Dim sql As New Class_find("Select NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & Me.txtCuentaContable.Text & "' AND ESMAYOR=0 ")
                If sql.Result1 = "" Then
                    Me.txtCuentaContable.Text = ""
                    Me.LblCuenta.Text = ""
                    Me.txtCuentaContable.Focus()
                    GoTo busqueda_Visual
                Else
                    Me.LblCuenta.Text = sql.Result1
                    Me.txtCuentaContableDolares.Focus()
                End If

                sql = Nothing

            Case Keys.Escape
                Me.TxtFolioCheque.Focus()
        End Select

    End Sub

    Private Sub txtCuentaContableDolares_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuentaContableDolares.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
busqueda_Visual:
                Dim oCuenta As New Class_CatCuentas
                Dim sCuenta As String = oCuenta.BusquedaVisual_PorCodigoFiltrandoTipoOperacion
                If sCuenta.Length > 0 Then
                    Me.txtCuentaContableDolares.Text = sCuenta
                    sCuenta = Replace(sCuenta, "'", "''")
                    Dim sql As New Class_find("Select CUENTA_CONTABLE,NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & sCuenta & "' AND ESMAYOR=0 ")
                    Me.txtCuentaContableDolares.Text = sCuenta
                    Me.LblCuentaDolares.Text = sql.Result2
                    sql = Nothing
                End If

            Case Keys.F7
                Dim oCuenta As New Class_CatCuentas
                Dim sCuenta As String = oCuenta.BusquedaVisual_PorNombreFiltrandoTipoOperacion
                If sCuenta.Length > 0 Then
                    Me.txtCuentaContableDolares.Text = sCuenta
                    sCuenta = Replace(sCuenta, "'", "''")
                    Dim sql As New Class_find("Select CUENTA_CONTABLE,NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & sCuenta & "' AND ESMAYOR=0 ")
                    Me.txtCuentaContableDolares.Text = sCuenta
                    Me.LblCuentaDolares.Text = sql.Result2
                    sql = Nothing
                End If

            Case Keys.Return
                Dim sql As New Class_find("Select NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & Me.txtCuentaContableDolares.Text & "' AND ESMAYOR=0  ")
                If sql.Result1 = "" Then
                    Me.txtCuentaContableDolares.Text = ""
                    Me.LblCuentaDolares.Text = ""
                    GoTo busqueda_Visual
                Else
                    Me.LblCuentaDolares.Text = sql.Result1
                End If

                sql = Nothing

                'SendKeys.Send("{TAB}")

            Case Keys.Escape
                Me.txtCuentaContable.Focus()
        End Select

    End Sub

    Private Sub TxtCodigoProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigoProveedor.KeyDown
        Dim oProveedor As Class_CatProveedores
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                oProveedor = New Class_CatProveedores
                Dim sProveedor As String = oProveedor.BusquedaVisual_PorDescripcion()
                If txtLEN(sProveedor) = True Then Me.TxtCodigoProveedor.Text = sProveedor
            Case Keys.Return
                If txtLEN(Me.TxtCodigoProveedor.Text) = False Then
                    Me.LblNombreProveedor.Text = ""
                    GoTo Buscar : Exit Sub
                End If
                oProveedor = New Class_CatProveedores(Me.TxtCodigoProveedor.Text)
                If oProveedor.Existe = False Then
                    Me.LblNombreProveedor.Text = ""
                    GoTo Buscar : Exit Sub
                End If
                Me.LblNombreProveedor.Text = oProveedor.Nombre_Proveedor
                txtTAB(e)

        End Select
    End Sub

#End Region

#Region "Validating específicos"

#End Region

    Private Sub CboFiltroHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Refrescar()
    End Sub

#End Region


End Class