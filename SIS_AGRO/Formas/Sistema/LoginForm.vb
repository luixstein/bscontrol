Public Class LoginForm

#Region "Campos"

#Region "Campos de la tabla"

#End Region

#Region "Campos ligados a la tabla"

#End Region

#Region "Campos p˙blicos"

#End Region

#Region "Campos privados"

#End Region

#Region "Campos de sistema"
    Private bLogueado As Boolean
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"

#End Region

#Region "Propiedades de campos ligados a la tabla"

#End Region

#Region "Propiedades p˙blicos"

#End Region

#Region "Propiedades de campos privados"

#End Region

#Region "Propiedades de campos de sistema"

#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        InitializeComponent()
        Try
            Usuario.Nombre_Usuario = My.Settings.Usuario
            Me.txtNombreUsuario.Text = Usuario.Nombre_Usuario

        Catch ex As Exception
            HandleError("LoginForm", "New", ex)
        End Try
    End Sub

    Public Sub New(ByVal idCodigoUsuario As Integer)
        Me.New()
        Usuario.Codigo_Usuario = idCodigoUsuario
        Try
            If Usuario.Consultar = True Then
                'Usuario._Existe = True
                'Else
                '   Throw New Exception("La cuenta bancaria no existe.")
            End If
        Catch ex As Exception
            HandleError("LoginForm", "New", ex)
        End Try
    End Sub

#End Region

#Region "Opciones"
    Private Sub btnIniciarSesion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIniciarSesion.Click
        Try
            If My.Settings.ModoExeCarpetaUsuario = "1" Then
                If txtLEN(Me.txtRFC.Text) = False Then
                    MsgBox("Capt˙re el RFC de la empresa por favor.", MsgBoxStyle.Exclamation, Me.Text)
                    Me.txtRFC.Focus()
                    Return
                End If
            End If

            If txtLEN(Me.txtNombreUsuario.Text) = False Then
                MsgBox("Capt˙re el nombre de usuario por favor.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtNombreUsuario.Focus()
                Return
            End If

            If txtLEN(Me.txtPassword.Text) = False Then
                MsgBox("Capt˙re la contraseÒa por favor.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtPassword.Focus()
                Return
            End If

            If My.Settings.ModoExeCarpetaUsuario = "1" Then
                Me.GestionaInicioSesionModoRemoteAPP()
            Else
                Usuario.Nombre_Usuario = Me.txtNombreUsuario.Text
                Me.Login()
            End If

            'btnEntrarAlSistema_Click(sender, e)

        Catch ex As Exception
            HandleError(Me.Name, "btnIniciarSesion_Click", ex)
        End Try
    End Sub

    Private Sub btnEntrarAlSistema_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEntrarAlSistema.Click
        Try
            Usuario.Codigo_Plaza = cboPlazas.SelectedValue

            My.Settings.Usuario = Usuario.Nombre_Usuario
            My.Settings.Save()

            'Empresa_Sistema = New Class_sisEmpresa("Empresa", My.Settings.BaseDatos, My.Settings.Servidor, Decrypt("zü¿¢õΩ•ôè©®", "n98"), Decrypt("ä©Àõyñ©†Œ", "v67"))
            Plaza = New Class_SisPlazas(Me.cboPlazas.SelectedValue.ToString)

            If Empresa_Sistema.FELECTRONICA_ACTIVA = True Then
                'If Not (My.Computer.Name = "PCSISTEMASJORGE" Or My.Computer.Name = "ERNESTOA") Then
                GestionaExistanCertificadosFacturaElectronica()
                'End If
            End If

            TDelegateCrystal()

            Dim oUsosCFDI As New Class_CFD_CatUsosCFDI
            dtUsosCFDIPersonasFisicas = oUsosCFDI.ObtenerElementosPersonasFisicas
            dtUsosCFDIPersonasMorales = oUsosCFDI.ObtenerElementosPersonasMorales
            oUsosCFDI = Nothing

            Dim oFormasPago As New Class_CFD_CatFormasPago
            dtFormasPagoActivas = oFormasPago.ObtenerElementos
            dtFormasPagoTodas = oFormasPago.ObtenerTodas()
            oFormasPago = Nothing

            Dim oMetodosPago As New Class_CFD_CatMetodosPago
            dtMetodosPago = oMetodosPago.ObtenerElementos
            oMetodosPago = Nothing

            Dim oTiposRelacionCFDI As New Class_CFD_CatTiposRelacionCFDI
            dtTiposRelacionCFDI = oTiposRelacionCFDI.ObtenerElementos
            oTiposRelacionCFDI = Nothing

            If My.Settings.ModoSistema = "Reportes" Then
                My.Forms.AppMenuReportes.Show()
            Else
                My.Forms.AppMenu.Show()
            End If

            Me.Hide()
        Catch ex As Exception
            HandleError(Me.Name, "btnEntrarAlSistema", ex)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Mod_main.Finaliza()
    End Sub
#End Region

#Region "Eventos de objetos"

    Private Sub LoginForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If My.Computer.Name = "PCSISTEMASJORGE" Then
            Me.txtPassword.Text = Decrypt("¶°®", "871")
            Me.LogoPictureBox.Image = Nothing
            Me.Label1.Text = ""
        End If

        'If My.Computer.Name = Decrypt("¨ãâ°ääõ{éßÜ", "ex8") Then
        '    Me.txtNombreUsuario.Text = Decrypt("™•", "r45711")
        '    Me.txtPassword.Text = Decrypt("£ù´ƒæ¬^", "p-4hpo")

        '    btnIniciarSesion_Click(New Object, EventArgs.Empty)
        '    btnEntrarAlSistema_Click(New Object, EventArgs.Empty)
        'End If

        If Me.bLogueado = True Then
            Me.Hide()
        End If

        '#If DEBUG Then
        '        If My.Computer.Name = "ERNESTO-PC" Then
        '            Usuario.Consultar(1)
        '            My.Forms.AppMenu.Show()
        '            Me.Hide()
        '        End If
        '#End If

    End Sub

    Private Sub LoginForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If My.Settings.ModoExeCarpetaUsuario = "1" Then
            Me.txtRFC.Focus()
        Else
            Me.txtPassword.Focus()
        End If
    End Sub

    Private Sub LoginForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.lblVersion.Text = "VersiÛn exe : " & My.Application.Info.Version.Revision

            If isSistemaValidaConfiguracionRegional() = False Then
                End
            End If

            If My.Settings.ModoExeCarpetaUsuario = "1" Then
                Me.LoadInicioSesionModoRemoteAPP()
            Else
                Me.LoadInicioSesionNormal(sender, e)
            End If

        Catch ex As Exception
            HandleError(Me.Name, "LoginForm_Load", ex)
        End Try
    End Sub

    Private Sub cboPlazas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPlazas.KeyDown
        txtTAB(e)
    End Sub

    Private Sub CboUsuarios_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboUsuarios.SelectedValueChanged
        If txtLEN(Me.CboUsuarios.Text) = True Then
            Me.txtNombreUsuario.Text = Me.CboUsuarios.Text
            Me.txtPassword.Text = Me.CboUsuarios.SelectedValue.ToString
            Me.btnIniciarSesion.Focus()
        End If
    End Sub

#Region "Eventos Genericos"
    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombreUsuario.KeyDown, txtPassword.KeyDown, txtRFC.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TextFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombreUsuario.Enter, txtPassword.Enter, txtRFC.Enter
        Dim T As TextBox = CType(sender, TextBox)
        T.SelectAll()
    End Sub

    Private Sub txtNombreUsuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreUsuario.KeyPress, txtPassword.KeyPress, txtRFC.KeyPress
        txtNoBeep(e)
    End Sub
#End Region

#End Region

#Region "MÈtodos y procedimientos"
    Private Sub Preinicio()
        Empresa_Sistema = New Class_sisEmpresa("Empresa", My.Settings.BaseDatos, My.Settings.Servidor, sCongif1, sCongif2)
        EmpresaParametros = New Class_SisContabilidadParametros
        Usuario = New Class_sisUsuarios
        Plaza = New Class_SisPlazas

        If Empresa_Sistema.VERSION_AGROCONTROL <> My.Application.Info.Version.Revision Then
            MsgBox("La versiÛn no esta actualizada. Version Basedatos: " & Empresa_Sistema.VERSION_AGROCONTROL & " VersiÛn aplicaciÛn: " & My.Application.Info.Version.Revision, MsgBoxStyle.Exclamation,
                   "Servidor=" & My.Settings.Servidor & " Basedatos=" & My.Settings.BaseDatos)
            Finaliza(False)
            Exit Sub
        End If
    End Sub

    Private Sub LoadInicioSesionNormal(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If My.Settings.MostrarServidores = "1" Then
                Dim f As New Servidor
                f.ShowDialog()
            End If

            My.Settings.Save()

            If bSistemaDirecto = True Then
                'My.Settings.BaseDatos = "AGRINET_LAND_TEST"
            Else
                If My.Settings.MostrarEmpresas = "1" Then
                    Dim f As New SeleccionEmpresa
                    f.ShowDialog()
                    f.Dispose()
                End If
            End If

            Me.Preinicio()

            'My.Settings.ModoSistema = "Integral"
            'If bSistemaDirecto = True Then
            '    My.Settings.ModoSistema = "Integral"
            'Else
            '    If My.Settings.MostrarModoSistema = "1" Then
            '        Dim f As New ModoSistema
            '        f.ShowDialog()
            '    End If
            'End If

            If My.Settings.PrecargarLogins = "1" And (My.Computer.Name = "PCSISTEMASJORGE" Or My.Computer.Name = "ERNESTOA") Then
                Me.DespliegaUsuarios()
                Me.CboUsuarios.Visible = True
                Me.CboUsuarios.Text = "dba"

                If bSistemaDirecto = True Then
                    btnIniciarSesion_Click(sender, e)
                    btnEntrarAlSistema_Click(sender, e)
                    Me.bLogueado = True
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, "LoadInicioSesionNormal", ex)
        End Try
    End Sub

    Private Sub LoadInicioSesionModoRemoteAPP()
        Try
            Dim misparametros() As String = Split(Command(), ",")

            If txtLEN(misparametros(0).ToString) = False Then 'RemoteApp sin parametro, para gestionar abrir el exe de usuario(cerrando este, abriendo con parametro)
                GestionaExeCarpetaUsuario()
            Else
                'RemoteApp con parametro, para que no se cicle
            End If

            Me.txtNombreUsuario.Text = Environ("USERNAME")
            Me.txtRFC.Visible = True
            Me.lblDisplayRFC.Visible = True
        Catch ex As Exception
            HandleError(Me.Name, "LoadInicioSesionModoRemoteAPP", ex)
        End Try
    End Sub

    Private Function Login() As Boolean
        Try
            If Usuario.Consultar(Usuario.Nombre_Usuario) = True Then
                If Usuario.Estatus = "B" Then
                    MsgBox("Acceso denegado. Usuario dado de baja.", MsgBoxStyle.Exclamation, Me.Text)
                    Me.txtPassword.Text = ""
                    Return False
                End If

                If Usuario.ValidaContraseÒa(Me.txtPassword.Text) = True Then
                    Me.GpbCentro.Enabled = True
                    Me.txtNombreUsuario.Enabled = False
                    Me.txtPassword.Enabled = False
                    Me.txtRFC.Enabled = False
                    Me.btnIniciarSesion.Enabled = False

                    Dim oPlazas As New Class_SisPlazas
                    oPlazas.CODIGO_PLAZA = Usuario.Codigo_Plaza
                    cboPlazas.DataSource = oPlazas.ObtenerPlazasPorUsuario
                    cboPlazas.DisplayMember = "NOMBRE_PLAZA"
                    cboPlazas.ValueMember = "CODIGO_PLAZA"
                    cboPlazas.SelectedValue = oPlazas.CODIGO_PLAZA
                    oPlazas = Nothing
                    My.Settings.Usuario = Usuario.Nombre_Usuario
                    Me.cboPlazas.Focus()
                Else
                    MsgBox("Acceso denegado. Verifique su usuario y contraseÒa.", MsgBoxStyle.Exclamation, Me.Text)
                    Me.txtPassword.Text = ""
                    Me.txtPassword.Focus()
                    Return False
                End If
            Else
                MsgBox("Acceso denegado. Verifique su usuario y contraseÒa.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtPassword.Text = ""
                Me.txtPassword.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            HandleError(Me.Name, "Login", ex)
        End Try
    End Function

    Private Function GestionaInicioSesionModoRemoteAPP() As Boolean
        Try
            If txtLEN(Me.txtRFC.Text) = False Then
                MsgBox("Capt˙re el RFC de la empresa por favor.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtRFC.Focus()
                Return False
            End If

            Dim Empresas As New Class_sisEmpresas("BS_EMPRESAS", My.Settings.Servidor, Me.txtRFC.Text)

            If Empresas.Existe = False Then
                MsgBox("No se encontrÛ el RFC de la empresa, verifique.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtRFC.Focus()
                Return False
            End If

            My.Settings.BaseDatos = Empresas.NOMBRE_DB

            Me.Preinicio()

            Usuario.Nombre_Usuario = Me.txtNombreUsuario.Text

            If Me.Login = True Then
                Return True
            End If

        Catch ex As Exception
            HandleError(Me.Name, "GestionaInicioSesionModoRemoteAPP", ex)
        End Try
    End Function

    Private Sub DespliegaUsuarios()
        Try
            Dim oElementos As New Class_sisUsuarios
            With Me.CboUsuarios
                .DisplayMember = "NOMBRE_USUARIO"
                .ValueMember = "CLAVE"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_USUARIO"
                .DataSource = dView
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DespliegaUsuarios", ex)
        End Try
    End Sub

    Private Sub LoginForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True AndAlso e.Control = True AndAlso e.Shift = True Then
            Select Case e.KeyCode
                Case Keys.A
                    Me.txtRFC.Text = "ATL140226IQ6"
                Case Keys.S
                    Me.txtRFC.Text = "PSIN0507192F3"
                Case Keys.L
                    Me.txtRFC.Text = "LEL680425AJ7"
            End Select
        End If
    End Sub

#End Region

End Class


