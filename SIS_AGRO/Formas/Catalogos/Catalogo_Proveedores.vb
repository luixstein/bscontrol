Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Catalogo_Proveedores
    Private oProveedores As New Class_CatProveedores

#Region "Campos"


#Region "Campos de la tabla"

    Private _Codigo_Proveedor As String
    Private _Nombre_Proveedor As String
    Private _Plazo As Integer
    Private _Status As String
    Private _Domicilio As String
    Private _RFC As String
    Private _Telefono As String
    Private _Fax As String
    Private _Celular As String
    Private _Correo_Electronico As String
    Private _Saldo As Double
    Private _Fecha_Apertura As Date
    Private _CCON As String
    Private _Codigo_Tipo_Proveedor As String
    Private _Contacto As String

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

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property Codigo_Proveedor() As String
        Get
            Return Me._Codigo_Proveedor
        End Get
        Set(ByVal Value As String)
            Me._Codigo_Proveedor = Value
        End Set
    End Property

    Public Property Nombre_Proveedor() As String
        Get
            Return Me._Nombre_Proveedor
        End Get
        Set(ByVal Value As String)
            Me._Nombre_Proveedor = Value
        End Set
    End Property

    Public Property Plazo() As Integer
        Get
            Return Me._Plazo
        End Get
        Set(ByVal Value As Integer)
            Me._Plazo = Value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return Me._Status
        End Get
        Set(ByVal Value As String)
            Me._Status = Value
        End Set
    End Property

    Public Property Domicilio() As String
        Get
            Return Me._Domicilio
        End Get
        Set(ByVal Value As String)
            Me._Domicilio = Value
        End Set
    End Property

    Public Property RFC() As String
        Get
            Return Me._RFC
        End Get
        Set(ByVal Value As String)
            Me._RFC = Value
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return Me._Telefono
        End Get
        Set(ByVal Value As String)
            Me._Telefono = Value
        End Set
    End Property

    Public Property Fax() As String
        Get
            Return Me._Fax
        End Get
        Set(ByVal Value As String)
            Me._Fax = Value
        End Set
    End Property

    Public Property Celular() As String
        Get
            Return Me._Celular
        End Get
        Set(ByVal Value As String)
            Me._Celular = Value
        End Set
    End Property

    Public Property Correo_Electronico() As String
        Get
            Return Me._Correo_Electronico
        End Get
        Set(ByVal Value As String)
            Me._Correo_Electronico = Value
        End Set
    End Property

    Public Property Saldo() As Double
        Get
            Return Me._Saldo
        End Get
        Set(ByVal Value As Double)
            Me._Saldo = Value
        End Set
    End Property

    Public Property Fecha_Apertura() As Date
        Get
            Return Me._Fecha_Apertura
        End Get
        Set(ByVal Value As Date)
            Me._Fecha_Apertura = Value
        End Set
    End Property

    Public Property CCON() As String
        Get
            Return Me._CCON
        End Get
        Set(ByVal Value As String)
            Me._CCON = Value
        End Set
    End Property

    Public Property Codigo_Tipo_Proveedor() As String
        Get
            Return Me._Codigo_Tipo_Proveedor
        End Get
        Set(ByVal Value As String)
            Me._Codigo_Tipo_Proveedor = Value
        End Set
    End Property

    Public Property Contacto() As String
        Get
            Return Me._Contacto
        End Get
        Set(ByVal Value As String)
            Me._Contacto = Value
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
            Me.msgElemento = "Proveedor"
            Me.msgElementos = "Proveedores"
            Me.Run = False
            'Me.lstbElementos.ContextMenuStrip = Me.cMenuStripAccion
            Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
            Me.DesplegarElementos()
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

        'Me.TxtCodProveedor.Text = Me.oProveedores.CodigoSiguiente 'se movio al inicializaelemento
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del " & Me.msgElemento & " : " & Me.TxtCodProveedor.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el " & Me.msgElemento & " : " & Me.TxtCodProveedor.Text
        End Select
        sMsg = "Deseas " & sMsg & " ?"
        If MsgBox(sMsg, CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle)) = MsgBoxResult.Yes Then
            Me.Grabar_Elemento()
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
        Dim oElementos As New Class_CatProveedores

        oElementos.Imprimir_Listado()

        oElementos = Nothing
    End Sub

    Private Sub tsbEliminar_Click(sender As Object, e As EventArgs) Handles tsbEliminar.Click
        Dim sMsg As String = ""
        sMsg = "Deseas eliminar el " & Me.msgElemento & " : " & Me.TxtCodProveedor.Text & " ?"
        If MsgBox(sMsg, CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle)) = MsgBoxResult.Yes Then
            Me.Elimina_Elemento()
        End If
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub Refrescar()

        Me.DesplegarElementos()

    End Sub

    Private Sub Cambia_Estado()
        Select Case Me.Estado
            Case enumEstados.NUEVO
                Me.gBoxInformacion.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Agregando nuevo " & Me.msgElemento
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True
                Me.tsbEliminar.Enabled = False

                Me.TxtCodProveedor.Enabled = False
                Me.TxtNomProveedor.Enabled = True
                Me.txtDomicilio.Enabled = True
                Me.txtRFC.Enabled = True
                Me.txtTelefono.Enabled = True
                Me.txtCelular.Enabled = True
                Me.txtCorreoElectronico.Enabled = True
                Me.txtFax.Enabled = True
                Me.TxtPlazo.Enabled = True
                Me.txtSaldo.Enabled = False
                Me.DTPFechaApertura.Enabled = False
                Me.txtCuentaContable.Enabled = False
                Me.txtCuentaContableDolares.Enabled = False
                Me.btnGenerarCuentaDolares.Enabled = False
                Me.cboTipoProveedor.Enabled = True
                Me.txtContactoNombre.Enabled = True
                Me.txtContactoTelefonoCelular.Enabled = True
                Me.CboEstatus.Enabled = False

                Me.InicializaElemento()

            Case enumEstados.EDICION
                Me.gBoxInformacion.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Edición"
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True
                Me.tsbEliminar.Enabled = True

                Me.TxtCodProveedor.Enabled = False
                Me.TxtNomProveedor.Enabled = True
                Me.txtDomicilio.Enabled = True
                Me.txtRFC.Enabled = True
                Me.txtTelefono.Enabled = True
                Me.txtCelular.Enabled = True
                Me.txtCorreoElectronico.Enabled = True
                Me.txtFax.Enabled = True
                Me.TxtPlazo.Enabled = True
                Me.txtSaldo.Enabled = False
                Me.DTPFechaApertura.Enabled = False
                Me.txtCuentaContable.Enabled = False
                Me.txtCuentaContableDolares.Enabled = False
                Me.btnGenerarCuentaDolares.Enabled = False
                Me.cboTipoProveedor.Enabled = False
                Me.txtContactoNombre.Enabled = True
                Me.txtContactoTelefonoCelular.Enabled = True
                Me.CboEstatus.Enabled = True
                If txtLEN(Me.txtCuentaContableDolares.Text) = False Then
                    Me.btnGenerarCuentaDolares.Enabled = True
                End If

            Case enumEstados.CONSULTA
                Me.gBoxInformacion.Enabled = False
                Me.gBoxBusquedaRapida.Enabled = True
                Me.tssLabelEstado.Text = "Consulta"
                Me.tsbNuevo.Enabled = True
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = False
                Me.tsbCancelar.Enabled = False
                Me.tsbEliminar.Enabled = False
                Me.txtFiltro.Focus()
                Me.CboEstatusFiltro.SelectedIndex = 0
        End Select
        Application.DoEvents()
    End Sub

    Private Sub InicializaElemento()
        Try
            Me.TxtCodProveedor.Text = ""
            Me.TxtNomProveedor.Text = ""
            Me.txtDomicilio.Text = ""
            Me.txtRFC.Text = ""
            Me.txtTelefono.Text = ""
            Me.txtCelular.Text = ""
            Me.txtCorreoElectronico.Text = ""
            Me.txtFax.Text = ""
            Me.TxtPlazo.Text = "0"
            Me.txtSaldo.Text = "0"
            Me.DTPFechaApertura.Text = Date.Now.ToString()
            Me.txtCuentaContable.Text = ""
            Me.txtCuentaContableDolares.Text = ""
            'Me.cboTipoProveedor.SelectedIndex = 0
            Me.txtContactoNombre.Text = ""
            Me.txtContactoTelefonoCelular.Text = ""
            Me.CboEstatus.SelectedIndex = 0
            Me.lblCuenta.Text = ""
            Me.lblCuentaContabledolares.Text = ""
            Me.txtCuentaContable.Enabled = False

            'Me.TxtCodProveedor.Text = Me.oProveedores.CodigoSiguiente
        Catch ex As Exception
            HandleError(Me.Name, "InicializaElemento", ex)
        End Try
    End Sub

    Private Sub DesplegarElementos()
        Dim oElementos As New Class_CatProveedores
        With Me.Grid
            .DataSource = oElementos.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.CboEstatusFiltro.Text)
            .Columns("CODIGO_PROVEEDOR").Width = 70
            .Columns("NOMBRE_PROVEEDOR").Width = 350
        End With

    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As String)
        Dim oElemento As New Class_CatProveedores
        oElemento.Codigo_Proveedor = iCodigo_Elemento
        If oElemento.Consultar Then
            With oElemento
                Me.TxtCodProveedor.Text = .Codigo_Proveedor.ToString
                Me.TxtNomProveedor.Text = .Nombre_Proveedor.ToString
                Me.txtDomicilio.Text = .Domicilio.ToString
                Me.txtRFC.Text = .RFC.ToString
                Me.txtTelefono.Text = .Telefono.ToString
                Me.txtCelular.Text = .Celular.ToString
                Me.txtCorreoElectronico.Text = .Correo_Electronico.ToString
                Me.txtFax.Text = .Fax.ToString
                Me.TxtPlazo.Text = .Plazo.ToString
                Me.txtSaldo.Text = .Saldo.ToString
                Me.DTPFechaApertura.Text = .FECHA_ALTA.ToString("s")
                Me.txtCuentaContable.Text = .CUENTA_CONTABLE.ToString
                Me.txtCuentaContableDolares.Text = .CUENTA_CONTABLE_DOLARES.ToString
                Me.cboTipoProveedor.SelectedValue = .Codigo_Tipo_Proveedor.ToString
                Me.txtContactoNombre.Text = .Contacto.ToString
                Me.txtContactoTelefonoCelular.Text = .Contacto_Telefono_Celular.ToString
                If .Estatus = "A" Then
                    Me.CboEstatus.SelectedIndex = 0
                Else
                    Me.CboEstatus.SelectedIndex = 1
                End If

                Dim sql As New Class_find("Select NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & Me.txtCuentaContable.Text & "' ")
                Me.lblCuenta.Text = sql.Result1

                sql = New Class_find("Select NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & Me.txtCuentaContableDolares.Text & "' ")
                Me.lblCuentaContabledolares.Text = sql.Result1

            End With

            If txtLEN(Me.txtCuentaContableDolares.Text) = False Then
                Me.btnGenerarCuentaDolares.Enabled = True
            End If
        End If
        oElemento = Nothing
    End Sub

    Private Sub Grabar_Elemento()
        Dim oElemento As New Class_CatProveedores
        Dim Grabado As Boolean = False

        If txtLEN(Me.TxtNomProveedor.Text) = False Then
            MsgBox("Asígne el nombre del proveedor", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtNomProveedor.Focus()
            Exit Sub
        End If

        If txtLEN(Me.txtDomicilio.Text) = False Then
            MsgBox("Asígne el domicilio del proveedor", MsgBoxStyle.Exclamation, Me.Text)
            Me.txtDomicilio.Focus()
            Exit Sub
        End If

        If txtLEN(Me.txtRFC.Text) = False Then
            MsgBox("Asígne el RFC del proveedor", MsgBoxStyle.Exclamation, Me.Text)
            Me.txtRFC.Focus()
            Exit Sub
        End If

        If txtLEN(Me.TxtPlazo.Text) = False Then
            MsgBox("Asígne el plazo del proveedor", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtPlazo.Focus()
            Exit Sub
        End If

        'If txtLEN(Me.txtCuentaContable.Text) = False Then
        '    MsgBox("Asígne la cuenta contable del proveedor.", MsgBoxStyle.Exclamation, Me.Text)
        '    Me.txtCuentaContable.Focus()
        '    Exit Sub
        'End If

        Dim oCuentas As New Class_CatCuentas
        oCuentas.CUENTA_CONTABLE = Me.txtCuentaContable.Text

        'If oCuentas.Consultar() = False Then
        '    MsgBox("La cuenta contable no existe.", MsgBoxStyle.Exclamation, Me.Text)
        '    Me.txtCuentaContable.Focus()
        '    Exit Sub
        'End If

        'If Me.TxtNomProveedor.Text <> oCuentas.NOMBRE_CUENTA Then
        '    MsgBox("El nombre de la cuenta contable debe de ser igual al nombre del proveedor.", MsgBoxStyle.Exclamation, Me.Text)
        '    Me.txtCuentaContable.Focus()
        '    Exit Sub
        'End If

        'If oCuentas.isCuentaContableValida(Me.txtCuentaContable.Text) = False Then
        '    MsgBox("La cuenta contable debe de ser de operación.", MsgBoxStyle.Exclamation, Me.Text)
        '    Me.txtCuentaContable.Focus()
        '    Exit Sub
        'End If

        'If Me.ValidarCuentaTipoProveedor() = False Then
        '    Me.txtCuentaContable.Focus()
        '    Exit Sub
        'End If

        If txtLEN(Me.txtCuentaContableDolares.Text) = True Then
            oCuentas.CUENTA_CONTABLE = Me.txtCuentaContableDolares.Text

            If oCuentas.Consultar() = False Then
                MsgBox("La cuenta contable en dolares no existe.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtCuentaContableDolares.Focus()
                Exit Sub
            End If

            'If Me.TxtNomProveedor.Text.ToUpper <> oCuentas.NOMBRE_CUENTA Then
            '    MsgBox("El nombre de la cuenta contable en dolares debe de ser igual al nombre del proveedor.", MsgBoxStyle.Exclamation, Me.Text)
            '    Me.txtCuentaContable.Focus()
            '    Exit Sub
            'End If

            If oCuentas.isCuentaContableValida(Me.txtCuentaContableDolares.Text) = False Then
                MsgBox("La cuenta contable en dolares debe de ser de operación.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtCuentaContable.Focus()
                Exit Sub
            End If
        End If

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                oElemento = New Class_CatProveedores
                Try
                    With oElemento
                        .Codigo_Proveedor = Me.TxtCodProveedor.Text.ToUpper
                        .Nombre_Proveedor = Me.TxtNomProveedor.Text.ToUpper
                        .Domicilio = Me.txtDomicilio.Text.ToUpper
                        .RFC = Me.txtRFC.Text.ToUpper
                        .Telefono = Me.txtTelefono.Text
                        .Celular = Me.txtCelular.Text
                        .Correo_Electronico = Me.txtCorreoElectronico.Text.ToUpper
                        .Fax = Me.txtFax.Text
                        .Plazo = Convert.ToInt32(Me.TxtPlazo.Text)
                        .Saldo = Convert.ToDouble(Me.txtSaldo.Text)
                        .FECHA_ALTA = Convert.ToDateTime(Me.DTPFechaApertura.Text)
                        .CUENTA_CONTABLE = Me.txtCuentaContable.Text
                        .CUENTA_CONTABLE_DOLARES = Me.txtCuentaContableDolares.Text
                        .Codigo_Tipo_Proveedor = Me.cboTipoProveedor.SelectedValue.ToString
                        .Contacto = Me.txtContactoNombre.Text.ToUpper
                        .Contacto_Telefono_Celular = Me.txtContactoTelefonoCelular.Text
                        .Estatus = Strings.Left(Me.CboEstatus.Text, 1)
                        .CODIGO_PLAZA = Usuario.Codigo_Plaza
                        .CURP = Me.txtCURP.Text.ToUpper

                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                If .Insertar() Then
                                    Grabado = True
                                    Me.Estado = enumEstados.CONSULTA

                                End If
                            Case enumEstados.EDICION
                                If .Actualizar() Then
                                    Grabado = True
                                    Me.Estado = enumEstados.CONSULTA
                                End If
                        End Select

                        If Grabado = True Then
                            MsgBox(Me.msgElemento & " Grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
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
    End Sub

    Private Sub Elimina_Elemento()
        Dim oElemento As New Class_CatProveedores
        Dim Eliminado As Boolean = False

        Try
            With oElemento
                .Codigo_Proveedor = Me.TxtCodProveedor.Text
                .CUENTA_CONTABLE = Me.txtCuentaContable.Text
                .CUENTA_CONTABLE_DOLARES = Me.txtCuentaContableDolares.Text

                If .EliminarProveedor() Then
                    Eliminado = True
                    Me.Estado = enumEstados.NUEVO
                End If
            End With

            If Eliminado = True Then
                MsgBox(Me.msgElemento & " Eliminado satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
                'Me.Refrescar()
                Me.Cambia_Estado()
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Elimina", ex)
            Me.Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
        Finally
            oElemento = Nothing
        End Try
    End Sub

    Private Sub GrabaCuentaContableDolares()
        Dim oElemento As New Class_CatProveedores
        Try
            With oElemento
                .Nombre_Proveedor = Me.TxtNomProveedor.Text
                .Codigo_Proveedor = Me.TxtCodProveedor.Text
                .CODIGO_PLAZA = Plaza.CODIGO_PLAZA

                If .InsertarCuentaContableDolares() = True Then
                    MsgBox("Grabado satisfactoriamente.", MsgBoxStyle.Information)
                    Me.Refrescar()
                    Me.Estado = enumEstados.CONSULTA
                    Me.Cambia_Estado()
                End If

            End With

        Catch ex As Exception
            HandleError(Me.Name, "GrabaCuentaContableDolares", ex)
            Me.Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
        Finally
            oProveedores = Nothing
        End Try
    End Sub

    Public Function ValidarCuentaTipoProveedor() As Boolean
        Dim sCuentaContable As String
        Dim sql As New Class_find("SELECT CUENTA_CONTABLE, NOMBRE_TIPO_PROVEEDOR FROM SIS_TIPOS_PROVEEDORES WHERE CODIGO_TIPO_PROVEEDOR='" & Me.cboTipoProveedor.SelectedValue.ToString & "' ")

        sCuentaContable = Me.txtCuentaContable.Text.Substring(0, 4)
        If txtLEN(sql.Result1) = True Then
            If sCuentaContable <> sql.Result1 Then
                MsgBox("La cuenta contable del " & sql.Result2.ToString & " debe iniciar con " & sql.Result1.ToString & ".", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtCuentaContable.Focus()
                Exit Function
            End If
        End If
        ValidarCuentaTipoProveedor = True
    End Function

#End Region

#Region "Eventos de objetos"
#Region "Eventos de la lista de elementos"
    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_PROVEEDOR").Value.ToString)
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellDoubleClick
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub
    'Private Sub lstbElementos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Me.Estado = enumEstados.EDICION
    '    Me.Cambia_Estado()
    'End Sub

    'Private Sub lstbElementos_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.lstbElementos.Items.Count > 0 Then
    '        Me.tsbEditar.Enabled = True
    '    End If
    'End Sub

    'Private Sub lstbElementos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Me.tsbEditar.Enabled = False
    'End Sub

    'Private Sub lstbElementos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.lstbElementos.SelectedIndex >= 0 Then
    '        Me.LlenaElemento(Me.lstbElementos.SelectedValue.ToString)
    '    End If
    'End Sub
#End Region

#Region " Eventos de TxtFiltro y CboEstatusFiltro"
    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Dim oElementos As New Class_CatProveedores
        Me.Grid.DataSource = Nothing

        With Me.Grid
            If Me.rbtNombreProveedor.Checked = True Then
                .DataSource = oElementos.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.CboEstatusFiltro.Text)
            Else
                .DataSource = oElementos.ObtenerElementosFiltroCodigo(Me.txtFiltro.Text, Me.CboEstatusFiltro.Text)
            End If
            .Columns("CODIGO_PROVEEDOR").Width = 70
            .Columns("NOMBRE_PROVEEDOR").Width = 350
        End With
    End Sub
    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub
    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        Dim oElementosFiltro As New Class_CatProveedores
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
            Me.Grid.DataSource = Nothing

            With Me.Grid
                If Me.rbtNombreProveedor.Checked = True Then
                    .DataSource = oElementosFiltro.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.CboEstatusFiltro.Text)
                Else
                    .DataSource = oElementosFiltro.ObtenerElementosFiltroCodigo(Me.txtFiltro.Text, Me.CboEstatusFiltro.Text)
                End If
                .Columns("CODIGO_PROVEEDOR").Width = 70
                .Columns("NOMBRE_PROVEEDOR").Width = 350
            End With
        End If
    End Sub
    Private Sub CboEstatusFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboEstatusFiltro.SelectedIndexChanged
        Dim oElementos As New Class_CatProveedores
        Me.Grid.DataSource = Nothing

        With Me.Grid
            If Me.rbtNombreProveedor.Checked = True Then
                .DataSource = oElementos.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.CboEstatusFiltro.Text)
            Else
                .DataSource = oElementos.ObtenerElementosFiltroCodigo(Me.txtFiltro.Text, Me.CboEstatusFiltro.Text)
            End If
            .Columns("CODIGO_PROVEEDOR").Width = 70
            .Columns("NOMBRE_PROVEEDOR").Width = 350
        End With
    End Sub
#End Region

#Region "Eventos Genericos"

    Private Sub CboEstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboEstatus.KeyDown
        If e.KeyCode = Keys.Return Then
            tsbGrabar.PerformClick()
        End If
        If e.KeyCode = Keys.Escape Then
            txtContactoNombre.Focus()
        End If
    End Sub
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboEstatus.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNomProveedor.KeyDown
        If e.KeyCode = Keys.Return Then
            Select Case Me.Estado
                Case enumEstados.EDICION
                    SendKeys.Send("{TAB}")
                Case enumEstados.NUEVO
                    SendKeys.Send("{TAB}")
            End Select
        End If
        If e.KeyCode = Keys.Escape Then
            TxtCodProveedor.Focus()
        End If
    End Sub

    Private Sub txtNumericos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
            'Me.ErrorProvider.Clear()
        End If
    End Sub
#End Region


#Region "Keydown específicos"

#End Region

#Region "Validating específicos"

#End Region

    Private Sub CboFiltroHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Refrescar()
    End Sub

#End Region

    Private Sub Catalogo_Articulos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DesplegaTiposProveedores()
    End Sub

    Private Sub DesplegaTiposProveedores()
        Dim oElementos As New Class_CatProveedores
        With Me.cboTipoProveedor
            .DisplayMember = "NOMBRE_TIPO_PROVEEDOR"
            .ValueMember = "CODIGO_TIPO_PROVEEDOR"
            Dim dView As New Data.DataView(oElementos.ObtenerTiposProveedores)
            dView.Sort = "NOMBRE_TIPO_PROVEEDOR"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub TxtCodProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodProveedor.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                txtTAB(e)
            Case Keys.Escape

        End Select
    End Sub

    Private Sub txtDomicilio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDomicilio.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                txtTAB(e)
            Case Keys.Escape
                TxtNomProveedor.Focus()
        End Select
    End Sub

    Private Sub txtRFC_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRFC.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                txtTAB(e)
            Case Keys.Escape
                txtDomicilio.Focus()
        End Select
    End Sub

    Private Sub txtTelefono_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTelefono.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                txtTAB(e)
            Case Keys.Escape
                txtRFC.Focus()
        End Select
    End Sub

    Private Sub txtCelular_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCelular.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                txtTAB(e)
            Case Keys.Escape
                txtTelefono.Focus()
        End Select
    End Sub

    Private Sub txtCorreoElectronico_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCorreoElectronico.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                txtTAB(e)
            Case Keys.Escape
                txtCelular.Focus()
        End Select
    End Sub

    Private Sub txtFax_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFax.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                txtTAB(e)
            Case Keys.Escape
                txtCorreoElectronico.Focus()
        End Select
    End Sub

    Private Sub TxtPlazo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPlazo.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                txtTAB(e)
            Case Keys.Escape
                txtFax.Focus()
        End Select
    End Sub

    Private Sub txtSaldo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSaldo.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                txtTAB(e)
            Case Keys.Escape
                TxtPlazo.Focus()
        End Select
    End Sub

    Private Sub DTPFechaApertura_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DTPFechaApertura.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                txtTAB(e)
            Case Keys.Escape
                txtSaldo.Focus()
        End Select
    End Sub

    Private Sub txtCuentaContable_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuentaContable.KeyDown
        Dim oCuenta As New Class_CatCuentas
        oCuenta = New Class_CatCuentas
        Select Case e.KeyCode
            Case Keys.F6
busqueda_Visual:

                Dim sCuenta As String = oCuenta.BusquedaVisual_PorDescripcion
                If sCuenta.Length > 0 Then
                    Me.txtCuentaContable.Text = sCuenta
                    sCuenta = Replace(sCuenta, "'", "''")
                    Dim sql As New Class_find("Select CUENTA_CONTABLE,NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & sCuenta & "' ")
                    Me.txtCuentaContable.Text = sCuenta
                    LblCuenta.Text = sql.Result2
                    sql = Nothing
                End If
                Me.ValidarCuentaTipoProveedor()

            Case Keys.F7
                Dim sCuenta As String = oCuenta.BusquedaVisual_PorCodigoFiltrandoTipoOperacion
                If sCuenta.Length > 0 Then
                    Me.txtCuentaContable.Text = sCuenta
                    sCuenta = Replace(sCuenta, "'", "''")
                    Dim sql As New Class_find("Select CUENTA_CONTABLE,NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & sCuenta & "' ")
                    Me.txtCuentaContable.Text = sCuenta
                    lblCuenta.Text = sql.Result2
                    sql = Nothing
                End If
                Me.ValidarCuentaTipoProveedor()

            Case Keys.Return
                If oCuenta.isCuentaContableValida(Me.txtCuentaContable.Text) = False Then
                    MsgBox("La cuenta contable del almacen debe de ser de operación", MsgBoxStyle.Exclamation, Me.Text)
                    Me.txtCuentaContable.Focus()
                    Exit Sub
                End If
                Dim sql As New Class_find("Select NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & txtCuentaContable.Text & "' ")
                If sql.Result1 = "" Then
                    GoTo busqueda_Visual
                Else
                    lblCuenta.Text = sql.Result1
                End If

                sql = Nothing

                txtTAB(e)
                Me.ValidarCuentaTipoProveedor()
        End Select

        If txtLEN(Me.txtCuentaContable.Text) = False Then
            Exit Sub
        End If

    End Sub

    Private Sub txtCuentaContableDolares_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuentaContableDolares.KeyDown
        Dim oCuenta As New Class_CatCuentas
        oCuenta = New Class_CatCuentas
        Select Case e.KeyCode
            Case Keys.F6
busqueda_Visual:

                Dim sCuenta As String = oCuenta.BusquedaVisual_PorDescripcion
                If sCuenta.Length > 0 Then
                    Me.txtCuentaContableDolares.Text = sCuenta
                    sCuenta = Replace(sCuenta, "'", "''")
                    Dim sql As New Class_find("Select CUENTA_CONTABLE,NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & sCuenta & "' ")
                    Me.txtCuentaContableDolares.Text = sCuenta
                    lblCuentaContabledolares.Text = sql.Result2
                    sql = Nothing
                End If
            Case Keys.Return
                If txtLEN(Me.txtCuentaContableDolares.Text) = True Then
                    If oCuenta.isCuentaContableValida(Me.txtCuentaContableDolares.Text) = False Then
                        MsgBox("La cuenta contable del almacen debe de ser de operación", MsgBoxStyle.Exclamation, Me.Text)
                        Me.txtCuentaContableDolares.Focus()
                        Exit Sub
                    End If
                    Dim sql As New Class_find("Select NOMBRE_CUENTA From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & Me.txtCuentaContableDolares.Text & "' ")
                    If sql.Result1 = "" Then
                        GoTo busqueda_Visual
                    Else
                        lblCuentaContabledolares.Text = sql.Result1
                    End If

                    sql = Nothing
                End If

                txtTAB(e)

        End Select
    End Sub

    Private Sub TxtCodProveedor_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCURP.KeyPress, txtTelefono.KeyPress, txtCuentaContableDolares.KeyPress, txtSaldo.KeyPress, txtRFC.KeyPress, TxtPlazo.KeyPress, TxtNomProveedor.KeyPress, txtFax.KeyPress, txtDomicilio.KeyPress, txtCuentaContable.KeyPress, txtCorreoElectronico.KeyPress, txtContactoTelefonoCelular.KeyPress, txtContactoNombre.KeyPress, TxtCodProveedor.KeyPress, txtCelular.KeyPress, DTPFechaApertura.KeyPress, cboTipoProveedor.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub cboTipoProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipoProveedor.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                txtTAB(e)
            Case Keys.Escape
                txtCuentaContable.Focus()
        End Select
    End Sub

    Private Sub txtContacto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Return
                txtTAB(e)
            Case Keys.Escape
                cboTipoProveedor.Focus()
        End Select
    End Sub

    Private Sub txtContactoNombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtContactoNombre.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                txtTAB(e)
            Case Keys.Escape
                txtFax.Focus()
        End Select
    End Sub

    Private Sub txtContactoTelefonoCelular_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtContactoTelefonoCelular.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                txtTAB(e)
            Case Keys.Escape
                txtFax.Focus()
        End Select
    End Sub

    Private Sub txtCURP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCURP.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                txtTAB(e)
        End Select
    End Sub

    Private Sub rbtNombreProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles rbtNombreProveedor.CheckedChanged
        Me.txtFiltro.Focus()
    End Sub

    Private Sub btnGenerarCuentaDolares_Click(sender As Object, e As EventArgs) Handles btnGenerarCuentaDolares.Click
        GrabaCuentaContableDolares()
    End Sub
End Class