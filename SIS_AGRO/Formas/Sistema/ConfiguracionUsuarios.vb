Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class ConfiguracionUsuarios
    Private oUsuarios As New Class_sisUsuarios
    Private dtMenus As DataTable
    Private sParent As String = ""
    Private bPadre As Boolean = False

#Region "Campos privados"
    Private Enum enumEstados
        NUEVO
        EDICION
        CONSULTA
    End Enum

    Private Estado As enumEstados
    Private Run As Boolean
    Private msgElemento As String
#End Region

#Region "Constructor y destructor"
    'Inicializa al objeto.
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Try
            Me.msgElemento = "Usuarios"
            Me.Run = False
            Estado = enumEstados.CONSULTA
            Me.DesplegarElementos()
            Me.DesplegarAlmacen()
            Me.DesplegarAlmacen2()
            Me.DesplegarAlmacen3()
            Me.DesplegarAlmacen4()
            Me.DesplegarPlazas()
            Me.DesplegarPlazas2()
            Me.DesplegarModulos()
            Me.DesplegarModulos2()
            Me.llenalistview()
            Me.llenalistview3()
            Me.llenalistview5()

            Me.Cambia_Estado()
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
        Me.TxtCodigoUsuario.Text = Me.oUsuarios.CodigoSiguiente
        Me.ConsultaPermisos()
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del " & Me.msgElemento & " : " & Me.TxtCodigoUsuario.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el " & Me.msgElemento & " : " & Me.TxtCodigoUsuario.Text
        End Select
        sMsg = "Deseas " & sMsg & " ?"
        If MsgBox(sMsg, CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle)) = MsgBoxResult.Yes Then
            Me.Grabar_Elemento()
        End If
    End Sub

    Private Sub tsbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
        Me.LlenaElemento(CInt(Me.TxtCodigoUsuario.Text))
        Me.Estado = enumEstados.CONSULTA
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnImportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnImportar.Click
        Me.ImportarPermisos()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub Refrescar()
        Me.DesplegarElementos()
    End Sub

    Private Sub Cambia_Estado()
        Dim iIndex As Integer
        Select Case Me.Estado
            Case enumEstados.NUEVO
                Me.gbInformacion.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Agregando nuevo " & Me.msgElemento
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtCodigoUsuario.Enabled = False
                Me.TxtNombreUsuario.Enabled = True
                Me.txtClave.Enabled = True
                Me.cboPlazas.Enabled = True
                Me.CboEstatus.Enabled = False
                Me.InicializaElemento()
                Me.TxtNombreUsuario.Focus()
                Me.BtnActualizar.Enabled = False
                Me.BtnRecurperar.Enabled = False

                If Empresa_Sistema.CODIGO_VENDEDOR_POR_USUARIO = True Then
                    Me.gpVendedor.Visible = True
                Else
                    Me.gpVendedor.Visible = False
                End If

            Case enumEstados.EDICION
                Me.gbInformacion.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Edición"
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtCodigoUsuario.Enabled = False
                Me.TxtNombreUsuario.Enabled = True
                Me.txtClave.Enabled = True
                Me.cboPlazas.Enabled = True
                Me.CboEstatus.Enabled = True
                Me.TxtNombreUsuario.Focus()
                Me.BtnActualizar.Enabled = True
                Me.BtnRecurperar.Enabled = True

                If Empresa_Sistema.CODIGO_VENDEDOR_POR_USUARIO = True Then
                    Me.gpVendedor.Visible = True
                Else
                    Me.gpVendedor.Visible = False
                End If

            Case Else
                Me.gbInformacion.Enabled = False
                Me.gBoxBusquedaRapida.Enabled = True
                Me.tssLabelEstado.Text = "Consulta"
                Me.tsbNuevo.Enabled = True
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = False
                Me.tsbCancelar.Enabled = False

                If Me.Run Then
                    If Me.lstbElementos.SelectedIndex < 0 Then
                        Exit Sub 'Me.lstbElementos.SelectedIndex = 0
                    Else
                        iIndex = Me.lstbElementos.SelectedIndex
                        Me.lstbElementos.SelectedIndex = -1
                        Me.lstbElementos.SelectedIndex = iIndex
                    End If
                End If

                If Empresa_Sistema.CODIGO_VENDEDOR_POR_USUARIO = True Then
                    Me.gpVendedor.Visible = True
                Else
                    Me.gpVendedor.Visible = False
                End If

                Me.txtFiltro.Focus()

        End Select
        Application.DoEvents()
    End Sub

    Private Sub InicializaElemento()
        Me.TxtCodigoUsuario.Text = ""
        Me.TxtNombreUsuario.Text = ""
        Me.txtClave.Text = ""
        Me.TxtConfirmaClave.Text = ""

        Me.CboEstatus.Text = "A"
        Me.ckbCuentas.Checked = False
        Me.ckbArticulos.Checked = False
        Me.CkbAdministrador.Checked = False
        Me.CkbClientes.Checked = False
        Me.CkbArmadoPalet.Checked = False

        Me.txtCodigoVendedor.Text = ""
        Me.lblNombreVendedor.Text = ""

        If Empresa_Sistema.CODIGO_VENDEDOR_POR_USUARIO = True Then
            Me.gpVendedor.Visible = True
        Else
            Me.gpVendedor.Visible = False
        End If

    End Sub

    Private Sub DesplegarElementos()
        Dim oElementos As New Class_sisUsuarios
        Try
            With Me.lstbElementos
                .DisplayMember = "NOMBRE_USUARIO"
                .ValueMember = "CODIGO_USUARIO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_USUARIO"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarElementos", ex)
        End Try
    End Sub

    Private Sub DesplegarPlazas()
        Dim oPlazas As New Class_SisPlazas
        Try
            With Me.cboPlazas
                .DisplayMember = "NOMBRE_PLAZA"
                .ValueMember = "CODIGO_PLAZA"
                Dim dView As New Data.DataView(oPlazas.ObtenerElementos())
                dView.Sort = "NOMBRE_PLAZA DESC"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarPlazas", ex)
        End Try
    End Sub

    Private Sub DesplegarPlazas2()
        Dim oPlazas As New Class_SisPlazas
        Try
            With Me.CboPlazasPermiso
                .DisplayMember = "NOMBRE_PLAZA"
                .ValueMember = "CODIGO_PLAZA"
                Dim dView As New Data.DataView(oPlazas.ObtenerElementos())
                dView.Sort = "NOMBRE_PLAZA DESC"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = Usuario.Codigo_Plaza '.SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarPlazas", ex)
        End Try
    End Sub

    Private Sub DesplegarAlmacen()
        Dim oAlmacen As New Class_CatAlmacenes
        Try
            With Me.CboAlmacen
                .DisplayMember = "NOMBRE_ALMACEN"
                .ValueMember = "CODIGO_ALMACEN"
                Dim dView As New Data.DataView(oAlmacen.ObtenerElementos())
                dView.Sort = "NOMBRE_ALMACEN DESC"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = Plaza.CODIGO_ALMACEN_PRINCIPAL '.SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAlmacen", ex)
        End Try
    End Sub

    Private Sub DesplegarAlmacen2()
        Dim oAlmacen As New Class_CatAlmacenes
        Try
            With Me.CboAlmacen2
                .DisplayMember = "NOMBRE_ALMACEN"
                .ValueMember = "CODIGO_ALMACEN"
                Dim dView As New Data.DataView(oAlmacen.ObtenerElementos())
                dView.Sort = "NOMBRE_ALMACEN DESC"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = Plaza.CODIGO_ALMACEN_PRINCIPAL '.SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAlmacen", ex)
        End Try
    End Sub

    Private Sub DesplegarAlmacen3()
        Dim oAlmacen As New Class_CatAlmacenes
        Try
            With Me.CboAlmacen3
                .DisplayMember = "NOMBRE_ALMACEN"
                .ValueMember = "CODIGO_ALMACEN"
                Dim dView As New Data.DataView(oAlmacen.ObtenerElementos())
                dView.Sort = "NOMBRE_ALMACEN DESC"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = Plaza.CODIGO_ALMACEN_PRINCIPAL '.SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAlmacen", ex)
        End Try
    End Sub

    Private Sub DesplegarAlmacen4()
        Dim oAlmacen As New Class_CatAlmacenes
        Try
            With Me.CboAlmacen4
                .DisplayMember = "NOMBRE_ALMACEN"
                .ValueMember = "CODIGO_ALMACEN"
                Dim dView As New Data.DataView(oAlmacen.ObtenerElementos())
                dView.Sort = "NOMBRE_ALMACEN DESC"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = Plaza.CODIGO_ALMACEN_PRINCIPAL '.SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAlmacen", ex)
        End Try
    End Sub

    Private Sub DesplegarModulos()
        Dim oElementos As New Class_SisModulos
        Try
            With Me.CboModulos
                .DisplayMember = "NOMBRE_MODULO"
                .ValueMember = "CODIGO_MODULO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos())
                dView.Sort = "NOMBRE_MODULO ASC"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarModulos", ex)
        End Try
    End Sub

    Private Sub DesplegarModulos2()
        Dim oElementos As New Class_SisModulos
        Try
            With Me.CboModulos2
                .DisplayMember = "NOMBRE_MODULO"
                .ValueMember = "CODIGO_MODULO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos())
                dView.Sort = "NOMBRE_MODULO ASC"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarModulos3", ex)
        End Try
    End Sub

    'Private Sub DesplegarDocuemtos()
    '    'Dim oElementos As New Class_CatDocumentos
    '    Try
    '        '    With Me.LstVDocumentos2
    '        '        .DisplayMember = "NOMBRE_TIPO_DOCUMENTO"
    '        '        .ValueMember = "CODIGO_DOCUMENTO"
    '        '        Dim dView As New Data.DataView(oElementos.ObtenerCodigosDocumentos(Me.CboModulos.SelectedValue.ToString, Me.cboPlazas.SelectedValue.ToString, "AFECTA_INVENTARIOS='1'"))
    '        '        dView.Sort = "NOMBRE_TIPO_DOCUMENTO"
    '        '        .DataSource = dView
    '        '        If dView.Count > 0 Then
    '        '            .SelectedIndex = 0
    '        '        End If
    '        '    End With
    '        Me.llenalistview()
    '    Catch ex As Exception
    '        HandleError(Me.Name, "DesplegarDocuemtos", ex)
    '    End Try
    'End Sub

    'Private Sub DesplegarDocuemtos2()
    '    'Dim oElementos As New Class_CatDocumentos
    '    Try
    '        'With Me.LstVDocumentos3
    '        '    .DisplayMember = "NOMBRE_TIPO_DOCUMENTO"
    '        '    .ValueMember = "CODIGO_DOCUMENTO"
    '        '    Dim dView As New Data.DataView(oElementos.ObtenerCodigosDocumentos(Me.CboModulos.SelectedValue.ToString, Me.cboPlazas.SelectedValue.ToString, "AFECTA_INVENTARIOS='0'"))
    '        '    dView.Sort = "NOMBRE_TIPO_DOCUMENTO"
    '        '    .DataSource = dView
    '        '    If dView.Count > 0 Then
    '        '        .SelectedIndex = 0
    '        '    End If
    '        'End With
    '        Me.llenalistview3()
    '    Catch ex As Exception
    '        HandleError(Me.Name, "DesplegarDocuemtos", ex)
    '    End Try
    'End Sub

    Private Function LlenaComboEstatus() As Boolean
        Me.CboEstatus.Items.Add("A")
        Me.CboEstatus.Items.Add("B")

        Me.CboEstatus.SelectedItem = "A"
    End Function

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As Integer)
        Dim oElemento As New Class_sisUsuarios
        oElemento.Codigo_Usuario = iCodigo_Elemento
        If oElemento.Consultar Then
            With oElemento
                Me.TxtCodigoUsuario.Text = .Codigo_Usuario.ToString
                Me.TxtNombreUsuario.Text = .Nombre_Usuario.ToString
                Me.txtClave.Text = .Clave.ToString
                Me.TxtConfirmaClave.Text = .Clave.ToString
                Me.cboPlazas.SelectedValue = .Codigo_Plaza
                Me.CboAlmacen.SelectedValue = .Codigo_Almacen
                Me.CboEstatus.Text = .Estatus.ToString
                Me.ckbArticulos.Checked = CBool(.PERMISO_CAT_ARTICULOS)
                Me.CkbAdministrador.Checked = CBool(.PERMISO_ADMINISTRADOR)
                Me.CkbArmadoPalet.Checked = CBool(.PERMISO_ARMADO_PALET)
                Me.CkbClientes.Checked = CBool(.PERMISO_CAT_CLIENTES)
                Me.ckbCuentas.Checked = CBool(.PERMISO_CON_CAT_CUENTAS)
                Me.txtCorreoUsuario.Text = .CORREO_USUARIO.ToString
                Me.txtClaveCorreo.Text = .CLAVE_CORREO.ToString
                Me.CkbAdmonCreditos.Checked = CBool(.ADMON_CREDITOS)
                Me.ckbVerCostos.Checked = CBool(.VER_COSTOS)
                Me.txtCodigoVendedor.Text = .CODIGO_VENDEDOR

                If txtLEN(Me.txtCodigoVendedor.Text) = True Then
                    Dim oVendedor As New Class_CatVendedores(Me.txtCodigoVendedor.Text)
                    If oVendedor.Existe = True Then Me.lblNombreVendedor.Text = oVendedor.NOMBRE_VENDEDOR
                Else
                    Me.lblNombreVendedor.Text = ""
                End If

            End With
        End If
        Me.TreeMenus()
        Me.ConsultaPermisos()
        Me.ConsultaPermisosMenus()
        oElemento = Nothing
    End Sub

    Private Sub Grabar_Elemento()
        Dim oElemento As New Class_sisUsuarios
        Dim Grabado As Boolean = False
        Dim iIndex As Integer = Me.lstbElementos.SelectedIndex

        If txtLEN(Me.TxtNombreUsuario.Text) = False Then
            MsgBox("Asígne el nombre del usuario", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtNombreUsuario.Focus()
            Exit Sub
        End If

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                oElemento = New Class_sisUsuarios
                Try
                    With oElemento
                        .Codigo_Usuario = CInt(Me.TxtCodigoUsuario.Text)
                        .Nombre_Usuario = Me.TxtNombreUsuario.Text
                        .Clave = Me.txtClave.Text
                        .Codigo_Plaza = CInt(Me.cboPlazas.SelectedValue)
                        .Codigo_Almacen = Me.CboAlmacen.SelectedValue.ToString
                        .PERMISO_ADMINISTRADOR = Convert.ToInt32(Me.CkbAdministrador.Checked).ToString
                        .PERMISO_ARMADO_PALET = Convert.ToInt32(Me.CkbArmadoPalet.Checked).ToString
                        .PERMISO_CAT_ARTICULOS = Convert.ToInt32(Me.ckbArticulos.Checked).ToString
                        .PERMISO_CAT_CLIENTES = Convert.ToInt32(Me.CkbClientes.Checked).ToString
                        .PERMISO_CON_CAT_CUENTAS = Convert.ToInt32(Me.ckbCuentas.Checked).ToString
                        .Estatus = Me.CboEstatus.Text
                        .CORREO_USUARIO = Me.txtCorreoUsuario.Text
                        .CLAVE_CORREO = Me.txtClaveCorreo.Text
                        .ADMON_CREDITOS = Convert.ToInt32(Me.CkbAdmonCreditos.Checked)
                        .VER_COSTOS = ckbVerCostos.Checked
                        .CODIGO_VENDEDOR = Me.txtCodigoVendedor.Text

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
                        .EliminaPermisoDocumentos()

                        If Grabado Then
                            Me.GrabaPermisosMenus()
                            Me.GrabaPermisosDocumentos()
                            Me.GrabaPermisosTipoDocumentos()
                            MsgBox(Me.msgElemento & " Grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
                            Me.Refrescar()
                            Me.lstbElementos.SelectedValue = .Codigo_Usuario
                            Me.Cambia_Estado()
                        End If

                    End With
                Catch ex As Exception
                    HandleError(Me.Name, "Grabar", ex)
                    Me.Estado = enumEstados.CONSULTA
                    Me.Cambia_Estado()
                    Me.lstbElementos.SelectedIndex = -1
                    Me.lstbElementos.SelectedIndex = iIndex
                Finally
                    oElemento = Nothing
                End Try
        End Select
    End Sub

    Private Sub GrabaPermisosMenus()
        Dim oElementos As New Class_sisUsuarios(CInt(Me.TxtCodigoUsuario.Text))
        oElementos.EliminaPermisoMenu()

        Try
            Dim nodes As TreeNodeCollection = Me.TreeViewMenus.Nodes

            For Each tn As TreeNode In nodes
                If tn.Checked = True Then
                    oElementos.InsertarPermisoMenu(tn.Tag.ToString)
                End If
                Me.GrabaPermisosSubMenus(tn)
            Next

        Catch ex As Exception
            HandleError(Me.Name, "GrabaPermisosMenus", ex)
        End Try
    End Sub

    Private Sub GrabaPermisosSubMenus(ByVal treeNode As TreeNode)
        Dim oElementos As New Class_sisUsuarios(CInt(Me.TxtCodigoUsuario.Text))
        Try
            For Each tn As TreeNode In treeNode.Nodes
                If tn.Checked = True Then
                    oElementos.InsertarPermisoMenu(tn.Tag.ToString)
                End If
                Me.GrabaPermisosSubMenus(tn)
            Next
        Catch ex As Exception
            HandleError(Me.Name, "GrabaPermisosSubMenus", ex)
        End Try
    End Sub

    Private Sub GrabaPermisosDocumentos()
        Dim oElementos As New Class_sisUsuarios(CInt(Me.TxtCodigoUsuario.Text))

        Try
            Dim i As Integer
            If (Me.LstVDocumentos2.Items.Count) >= 0 Then

                For i = 0 To Me.LstVDocumentos2.Items.Count - 1
                    oElementos.GrabaPermisoDocumentos(Me.LstVDocumentos2.Items(i).SubItems(0).Text, Me.LstVDocumentos2.Items(i).SubItems(2).Text)
                Next
            End If

            If (Me.LstVDocumentos4.Items.Count) >= 0 Then
                For i = 0 To Me.LstVDocumentos4.Items.Count - 1
                    oElementos.GrabaPermisoDocumentos(LstVDocumentos4.Items(i).SubItems(0).Text)
                Next
            End If

        Catch ex As Exception
            HandleError(Me.Name, "GrabaPermisosDocumentos", ex)
        End Try
    End Sub

    Private Sub GrabaPermisosTipoDocumentos()
        Dim oElementos As New Class_sisUsuarios(CInt(Me.TxtCodigoUsuario.Text))

        Try
            Dim i As Integer
            If (Me.LstVDocumentos6.Items.Count) >= 0 Then
                For i = 0 To Me.LstVDocumentos6.Items.Count - 1
                    oElementos.GrabaPermisosTipoDocumentos(Me.LstVDocumentos6.Items(i).SubItems(0).Text, Me.LstVDocumentos6.Items(i).SubItems(2).Text, Me.LstVDocumentos6.Items(i).SubItems(3).Text)
                Next
            End If
        Catch ex As Exception
            HandleError(Me.Name, "GrabaPermisosTipoDocumentos", ex)
        End Try
    End Sub

    Private Sub ConsultaPermisos(Optional ByVal iCodigo_Elemento As Integer = 0)
        'Dim iCodigoUsuario As Integer

        'If iCodigo_Elemento = 0 Then
        '    iCodigoUsuario = CInt(Me.TxtCodigoUsuario.Text)
        'Else
        '    iCodigoUsuario = iCodigo_Elemento
        'End If

        'Dim oElementos As New Class_sisUsuarios(iCodigoUsuario)
        'Try
        '    With Me.LstbDocumentosUsuario
        '        .DisplayMember = "NOMBRE_TIPO_DOCUMENTO"
        '        .ValueMember = "CODIGO_DOCUMENTO"
        '        Dim dView As New Data.DataView(oElementos.ObtenerDetallePermisos(CInt(Me.CboPlazasPermiso.SelectedValue)))
        '        dView.Sort = "NOMBRE_TIPO_DOCUMENTO"
        '        .DataSource = dView
        '        If dView.Count > 0 Then
        '            .SelectedIndex = 0
        '        End If
        '    End With
        'Catch ex As Exception
        '    HandleError(Me.Name, "ConsultaPermisos", ex)
        'End Try
        Me.llenalistview2()
        Me.llenalistview4()
        Me.llenalistview6()
    End Sub

    Private Function ValidarContraseña() As Boolean
        If Me.txtClave.Text = "" Or Len(Me.txtClave.Text) < 5 Then
            MsgBox("La contraseña nueva debe tener al menos 5 caracteres", vbExclamation)
            Me.TxtConfirmaClave.Text = ""
            Me.txtClave.Text = ""
            Me.txtClave.Focus()
            Exit Function
        End If

        If Me.TxtConfirmaClave.Text <> Me.txtClave.Text Then
            MsgBox("La contraseña no coincide con la confirmacion.", vbExclamation)
            Me.TxtConfirmaClave.Text = ""
            Me.txtClave.Text = ""
            Me.txtClave.Focus()
            Exit Function
        End If
        ValidarContraseña = True
    End Function

    Private Sub CambiarContraseña()
        If Me.ValidarContraseña() = False Then
            Exit Sub
        End If

        Try
            If Usuario.CambiarContraseña(CInt(Me.TxtCodigoUsuario.Text), Me.txtClave.Text) = True Then
                MsgBox("La contraseña se actualizado correctamente.", vbInformation, Me.Text)
                Me.txtClave.Text = ""
                Me.TxtConfirmaClave.Text = ""
            End If

        Catch ex As Exception
            HandleError(Me.Name, "BtnRecurperar", ex)
        End Try
    End Sub

    Private Sub TreeMenus()
        Try
            Me.TreeViewMenus.Nodes.Clear()
            For Each tsmi As ToolStripMenuItem In My.Forms.AppMenu.MenuStrip.Items   'Me.MenuStrip.Items
                Dim tn As New TreeNode(tsmi.Name)
                tn.Text = Replace(tsmi.Text, "&", "")
                tn.Tag = tsmi.Name
                Me.TreeViewMenus.Nodes.Add(tn)
                Me.SubTreeMenus(tn, tsmi.DropDownItems)
                tsmi.Enabled = False
            Next
        Catch ex As Exception
            HandleError(Me.Name, "TreeMenus", ex)
        End Try
    End Sub

    Private Sub SubTreeMenus(ByVal parentNode As TreeNode, ByVal items As ToolStripItemCollection)
        For Each item As ToolStripItem In items
            If item.GetType().ToString <> "System.Windows.Forms.ToolStripSeparator" Then
                'if item.GetType() = typeof(System.Windows.Forms.ToolStripMenuIte) then
                Dim child As New TreeNode(item.Text)
                child.Text = Replace(item.Text, "&", "")
                child.Tag = item.Name
                parentNode.Nodes.Add(child)
                Me.SubTreeMenus(child, DirectCast(item, ToolStripMenuItem).DropDownItems)
                item.Enabled = False
            End If
        Next
    End Sub

    Private Sub ConsultaPermisosMenus(Optional ByVal iCodigo_Elemento As Integer = 0)
        Dim iCodigoUsuario As Integer

        If iCodigo_Elemento = 0 Then
            iCodigoUsuario = CInt(Me.TxtCodigoUsuario.Text)
        Else
            iCodigoUsuario = iCodigo_Elemento
        End If

        Dim oElementos As New Class_sisUsuarios(iCodigoUsuario)
        Me.dtMenus = oElementos.ObtenerDetallePermisosMenus()

        Try
            Dim nodes As TreeNodeCollection = TreeViewMenus.Nodes

            For Each tn As TreeNode In nodes
                For Each dRow As DataRow In dtMenus.Rows
                    If tn.Tag.ToString = dRow("NOMBRE_MENU").ToString Then
                        tn.Checked = True
                    End If
                Next
                Me.ConsultaPermisosSubMenus(tn)
            Next
        Catch ex As Exception
            HandleError(Me.Name, "ConsultaPermisosMenus", ex)
        End Try
    End Sub

    Private Sub ConsultaPermisosSubMenus(ByVal treeNode As TreeNode)
        Try
            For Each tn As TreeNode In treeNode.Nodes
                For Each dRow As DataRow In dtMenus.Rows
                    If tn.Tag.ToString = dRow("NOMBRE_MENU").ToString Then
                        tn.Checked = True
                    End If
                Next
                Me.ConsultaPermisosSubMenus(tn)
            Next
        Catch ex As Exception
            HandleError(Me.Name, "ConsultaPermisosSubMenus", ex)
        End Try
    End Sub

    Private Sub HabilitaMenus()
        Try
            Me.dtMenus = Usuario.ObtenerDetallePermisosMenus()

            For Each tsmi As ToolStripMenuItem In My.Forms.AppMenu.MenuStrip.Items
                For Each dRow As DataRow In dtMenus.Rows
                    If tsmi.Name = dRow("NOMBRE_MENU").ToString Then
                        tsmi.Enabled = True
                    End If
                Next

                Me.HabilitaSubMenus(tsmi.DropDownItems)
            Next
        Catch ex As Exception
            HandleError(Me.Name, "HabilitaMenus", ex)
        End Try
    End Sub

    Private Sub HabilitaSubMenus(ByVal items As ToolStripItemCollection)
        Try
            For Each item As ToolStripItem In items
                If item.GetType().ToString <> "System.Windows.Forms.ToolStripSeparator" Then
                    For Each dRow As DataRow In dtMenus.Rows
                        If item.Name = dRow("NOMBRE_MENU").ToString Then
                            item.Enabled = True
                        End If
                    Next
                    Me.HabilitaSubMenus(DirectCast(item, ToolStripMenuItem).DropDownItems)
                End If
            Next
        Catch ex As Exception
            HandleError(Me.Name, "HabilitaSubMenus", ex)
        End Try
    End Sub
#End Region

#Region "Eventos de objetos"

#Region "Eventos de la lista de elementos"
    Private Sub lstbElementos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstbElementos.DoubleClick
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub lstbElementos_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstbElementos.Enter
        If Me.lstbElementos.Items.Count > 0 Then
            Me.tsbEditar.Enabled = True
        End If
    End Sub

    Private Sub lstbElementos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstbElementos.LostFocus
        Me.tsbEditar.Enabled = False
    End Sub

    Private Sub lstbElementos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstbElementos.SelectedIndexChanged
        If Me.lstbElementos.SelectedIndex >= 0 Then
            Me.LlenaElemento(CInt(Me.lstbElementos.SelectedValue))
        End If
    End Sub
#End Region

#Region " Eventos de TxtFiltro"
    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Dim sFiltro As String = Replace(txtFiltro.Text, "'", "''")
        Dim i As Short
        i = CType(Me.lstbElementos.FindString(sFiltro), Short)
        If i >= 0 Then Me.lstbElementos.SelectedIndex = i
    End Sub
    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub
    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Then
            If Me.lstbElementos.Items.Count > 0 Then
                Me.lstbElementos.SelectedIndex = 0
                Me.lstbElementos.Focus()
            End If
        End If
    End Sub
#End Region

#Region "Eventos Genericos"

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombreUsuario.KeyDown, txtClave.KeyDown, _
    CboAlmacen.KeyDown, cboPlazas.KeyDown, CboEstatus.KeyDown, CkbAdministrador.KeyDown, CkbArmadoPalet.KeyDown, ckbArticulos.KeyDown, CkbClientes.KeyDown, ckbCuentas.KeyDown, TxtCodigoUsuarioImporta.KeyDown
        If e.KeyCode = Keys.Return Then
            Select Case Me.Estado
                Case enumEstados.EDICION
                    SendKeys.Send("{TAB}")
                Case enumEstados.NUEVO
                    SendKeys.Send("{TAB}")
            End Select
        End If
    End Sub

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoUsuario.KeyPress, _
    TxtNombreUsuario.KeyPress, txtClave.KeyPress, TxtConfirmaClave.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub TxtCodigoUsuarioImporta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoUsuarioImporta.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oUsuarios.BusquedaVisual_PorDescripcion()
                If txtLEN(sText) = True Then Me.TxtCodigoUsuarioImporta.Text = sText
            Case Keys.Enter
                If txtLEN(Me.TxtCodigoUsuarioImporta.Text) = False Then
                    Me.LblNombreUsuario.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.oUsuarios = New Class_sisUsuarios(CInt(Me.TxtCodigoUsuarioImporta.Text))
                If Me.oUsuarios.Existe = False Then 
                    Me.LblNombreUsuario.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.TxtNombreUsuarioImportar.Text = Me.oUsuarios.Nombre_Usuario.ToString
        End Select
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoUsuarioImporta.KeyPress, txtCodigoVendedor.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

#End Region

    Private Sub TxtCodigoVendedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoVendedor.KeyDown
        Dim sText As String
        Dim oVendedor As New Class_CatVendedores
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = oVendedor.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.txtCodigoVendedor.Text = sText
            Case Keys.Enter
                If txtLEN(Me.txtCodigoVendedor.Text) = False Then
                    Me.lblNombreVendedor.Text = "" : GoTo Buscar : Exit Sub
                End If

                oVendedor = New Class_CatVendedores(Me.txtCodigoVendedor.Text)
                If oVendedor.Existe = False Then
                    Me.lblNombreVendedor.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblNombreVendedor.Text = oVendedor.NOMBRE_VENDEDOR
        End Select
    End Sub
    Private Sub CboModulos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboModulos.SelectedIndexChanged
        If Me.Visible = True Then
            Me.llenalistview()
            Me.llenalistview3()
        End If
    End Sub

    Private Sub CboModulos2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboModulos2.SelectedIndexChanged
        If Me.Visible = True Then
            Me.llenalistview5()
        End If
    End Sub

    Private Sub CboPlazasPermiso_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboPlazasPermiso.SelectedIndexChanged
        If Me.Visible = True Then
            Me.llenalistview()
            Me.llenalistview3()
        End If
    End Sub

    Private Sub BtnRecurperar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRecurperar.Click
        Try
            Dim oElemento As New Class_sisUsuarios
            oElemento.Codigo_Usuario = CInt(Me.TxtCodigoUsuario.Text)
            If oElemento.Consultar Then
                MsgBox(oElemento.Clave.ToString, MsgBoxStyle.Information, Me.Text)
            End If
        Catch ex As Exception
            HandleError(Me.Name, "BtnRecurperar", ex)
        End Try
    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        Me.CambiarContraseña()
    End Sub

    Private Sub TreeViewMenus_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeViewMenus.AfterCheck
        Dim oNodo As TreeNode

        If Me.Estado = enumEstados.CONSULTA Then
            Exit Sub
        End If

        If Me.bPadre = True Then
            Exit Sub
        End If

        'Esto chequea o deschequea los hijos del nodo marcado
        For Each oNodo In e.Node.Nodes
            oNodo.Checked = e.Node.Checked
        Next

        ''Si un nodo es marcado, marca al padre y al abuelo 
        ''solo funciona hasta con 3 niveles
        If Not e.Node.Parent Is Nothing Then
            If sParent <> e.Node.Parent.Tag.ToString Then
                sParent = e.Node.Parent.Tag.ToString
                If e.Node.Checked = True Then
                    Me.bPadre = True
                    e.Node.Parent.Checked = True
                    If Not e.Node.Parent.Parent Is Nothing Then
                        Me.bPadre = True
                        e.Node.Parent.Parent.Checked = True
                    End If
                    Me.bPadre = False
                End If
            End If
        End If
    End Sub

#End Region

    Private Sub ConfiguracionUsuarios_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.HabilitaMenus()
    End Sub

    Private Sub ConfiguracionUsuarios_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TreeMenus()
    End Sub

    Public Function ImportarPermisos() As Boolean

        If txtLEN(Me.TxtCodigoUsuarioImporta.Text) = False Then
            MsgBox("Asígne un usuario válido del que desea importar los permisos.", MsgBoxStyle.Information, Me.Name)
            Exit Function
        End If

        Dim oElemento As New Class_sisUsuarios
        oElemento.Codigo_Usuario = CInt(Me.TxtCodigoUsuarioImporta.Text)
        If oElemento.Consultar Then
            With oElemento
                'Me.cboPlazas.SelectedValue = .Codigo_Plaza
                Me.CboAlmacen.SelectedValue = .Codigo_Almacen
                'Me.CboEstatus.Text = .Estatus.ToString
                Me.ckbArticulos.Checked = CBool(.PERMISO_CAT_ARTICULOS)
                Me.CkbAdministrador.Checked = CBool(.PERMISO_ADMINISTRADOR)
                Me.CkbArmadoPalet.Checked = CBool(.PERMISO_ARMADO_PALET)
                Me.CkbClientes.Checked = CBool(.PERMISO_CAT_CLIENTES)
                Me.ckbCuentas.Checked = CBool(.PERMISO_CON_CAT_CUENTAS)
            End With
        End If
        Me.TreeMenus()
        Me.ConsultaPermisos(CInt(Me.TxtCodigoUsuarioImporta.Text))
        Me.ConsultaPermisosMenus(CInt(Me.TxtCodigoUsuarioImporta.Text))
        oElemento = Nothing
    End Function

    'Botón 1 para copiar los elementos desde el listview 1 hacia el listview 2  
    Private Sub BtnAgregar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar1.Click
        Dim R2 As Integer
        Dim bEncuentra As Boolean, bSeleccionado As Boolean
        Try
            If (Me.LstVDocumentos2.Items.Count) >= 0 Then
                If (Me.LstVDocumentos1.Items.Count) = 0 Then
                    Exit Sub
                Else
                    Dim i As Integer
                    For i = 0 To (Me.LstVDocumentos1.Items.Count - 1)
                        If Me.LstVDocumentos1.Items(i).Selected = False Then
                            bSeleccionado = False
                        Else
                            bSeleccionado = True
                            Exit For
                        End If
                    Next
                End If

                If bSeleccionado = False Then
                    Exit Sub
                End If

                For R2 = 0 To (Me.LstVDocumentos2.Items.Count - 1)
                    Me.LstVDocumentos2.Items(R2).Selected = True
                    Me.LstVDocumentos2.Select()
                    If Me.LstVDocumentos1.SelectedItems(0).SubItems(0).Text = Me.LstVDocumentos2.SelectedItems(0).SubItems(0).Text And Me.CboAlmacen2.SelectedValue.ToString = Me.LstVDocumentos2.SelectedItems(0).SubItems(2).Text Then
                        Bencuentra = True
                        Exit For
                    Else
                        Bencuentra = False
                    End If
                Next R2

                If Bencuentra = False Then
                    Me.LstVDocumentos2.Items.Add(New ListViewItem(New String() {Me.LstVDocumentos1.SelectedItems(0).SubItems(0).Text, Me.LstVDocumentos1.SelectedItems(0).SubItems(1).Text, Me.CboAlmacen2.SelectedValue.ToString}))
                End If
                Bencuentra = False
            End If
        Catch ex As Exception
            HandleError(Me.Name, "BtnAgregar1", ex)
        End Try
    End Sub

    'Botón 2 para copiar los elementos desde el listview 3 hacia el listview 4  
    Private Sub BtnAgregar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar2.Click
        Dim R2 As Integer
        Dim bEncuentra As Boolean, bSeleccionado As Boolean
        Try
            If (Me.LstVDocumentos4.Items.Count) >= 0 Then
                If (Me.LstVDocumentos3.Items.Count) = 0 Then
                    Exit Sub
                Else
                    Dim i As Integer
                    For i = 0 To (Me.LstVDocumentos3.Items.Count - 1)
                        If Me.LstVDocumentos3.Items(i).Selected = False Then
                            bSeleccionado = False
                        Else
                            bSeleccionado = True
                            Exit For
                        End If
                    Next
                End If

                If bSeleccionado = False Then
                    Exit Sub
                End If

                For R2 = 0 To (Me.LstVDocumentos4.Items.Count - 1)
                    Me.LstVDocumentos4.Items(R2).Selected = True
                    Me.LstVDocumentos4.Select()
                    If Me.LstVDocumentos3.SelectedItems(0).SubItems(0).Text = Me.LstVDocumentos4.SelectedItems(0).SubItems(0).Text Then
                        Bencuentra = True
                        Exit For
                    Else
                        Bencuentra = False
                    End If
                Next R2

                If Bencuentra = False Then
                    Me.LstVDocumentos4.Items.Add(New ListViewItem(New String() {Me.LstVDocumentos3.SelectedItems(0).SubItems(0).Text, Me.LstVDocumentos3.SelectedItems(0).SubItems(1).Text}))
                End If
                bEncuentra = False
            End If
        Catch ex As Exception
            HandleError(Me.Name, "BtnAgregar2", ex)
        End Try
    End Sub

    'Botón 1 para copiar los elementos desde el listview 3 hacia el listview 4  
    Private Sub BtnAgregar3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar3.Click
        Dim R2 As Integer
        Dim Bencuentra As Boolean, bSeleccionado As Boolean

        Try
            If (Me.LstVDocumentos6.Items.Count) >= 0 Then
                If (Me.LstVDocumentos5.Items.Count) = 0 Then
                    Exit Sub
                Else
                    Dim i As Integer
                    For i = 0 To (Me.LstVDocumentos5.Items.Count - 1)
                        If Me.LstVDocumentos5.Items(i).Selected = False Then
                            bSeleccionado = False
                        Else
                            bSeleccionado = True
                            Exit For
                        End If
                    Next
                End If

                If bSeleccionado = False Then
                    Exit Sub
                End If

                For R2 = 0 To (Me.LstVDocumentos6.Items.Count - 1)
                    Me.LstVDocumentos6.Items(R2).Selected = True
                    Me.LstVDocumentos6.Select()
                    If Me.LstVDocumentos5.SelectedItems(0).SubItems(0).Text = Me.LstVDocumentos6.SelectedItems(0).SubItems(0).Text And Me.LstVDocumentos6.SelectedItems(0).SubItems(2).Text = Me.CboAlmacen4.SelectedValue.ToString And Me.LstVDocumentos6.SelectedItems(0).SubItems(3).Text = Me.CboAlmacen3.SelectedValue.ToString Then
                        Bencuentra = True
                        Exit For
                    Else
                        Bencuentra = False
                    End If
                Next R2

                If Bencuentra = False Then
                    Me.LstVDocumentos6.Items.Add(New ListViewItem(New String() {Me.LstVDocumentos5.SelectedItems(0).SubItems(0).Text, Me.LstVDocumentos5.SelectedItems(0).SubItems(1).Text, Me.CboAlmacen4.SelectedValue.ToString, Me.CboAlmacen3.SelectedValue.ToString}))
                End If

                Bencuentra = False
            End If
        Catch ex As Exception
            HandleError(Me.Name, "BtnAgregar3", ex)
        End Try
    End Sub

    Private Sub BtnQuitar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQuitar1.Click
        For i As Integer = Me.LstVDocumentos2.SelectedItems.Count - 1 To 0 Step -1
            Me.LstVDocumentos2.SelectedItems(i).Remove()
        Next
    End Sub

    Private Sub BtnQuitar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQuitar2.Click
        For i As Integer = Me.LstVDocumentos4.SelectedItems.Count - 1 To 0 Step -1
            Me.LstVDocumentos4.SelectedItems(i).Remove()
        Next
    End Sub

    Private Sub BtnQuitar3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQuitar3.Click
        For i As Integer = Me.LstVDocumentos6.SelectedItems.Count - 1 To 0 Step -1
            Me.LstVDocumentos6.SelectedItems(i).Remove()
        Next
    End Sub

    Private Sub llenalistview()
        Dim dt As DataTable
        Dim oElementos As New Class_CatDocumentos
        Try
            dt = oElementos.ObtenerCodigosDocumentos(Me.CboModulos.SelectedValue.ToString, Me.CboPlazasPermiso.SelectedValue.ToString, "AFECTA_INVENTARIOS='1'")

            ' Propiedades del ListView  
            With Me.LstVDocumentos1
                .Items.Clear()
                .Columns.Clear()
                .View = View.Details
                .GridLines = True
                .FullRowSelect = True
                ' añadir los nombres de columnas  
                For c As Integer = 0 To dt.Columns.Count - 1 'DataSet.Tables("tabla").Columns.Count - 1
                    .Columns.Add(dt.Columns(c).ToString) '.Columns(c)))
                Next
            End With

            For Each dRow As DataRow In dt.Rows
                Me.LstVDocumentos1.Items.Add(New ListViewItem(New String() {dRow(0).ToString, dRow(1).ToString}))
            Next

            If (Me.LstVDocumentos1.Items.Count) = 0 Then
                Exit Sub
            Else
                Me.LstVDocumentos1.Items(0).Selected = True
                Me.LstVDocumentos1.Select()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarDocuemtos", ex)
        End Try
    End Sub

    Private Sub llenalistview2()
        Dim dt As DataTable
        Dim oElementos As New Class_sisUsuarios(CInt(Me.TxtCodigoUsuario.Text))
        Try
            dt = oElementos.ObtenerDetallePermisosUsuarioDocumentosConAfectaInventarios(CInt(Me.CboPlazasPermiso.SelectedValue))
            'oElementos.ObtenerCodigosDocumentos(Me.CboModulos.SelectedValue.ToString, Me.cboPlazas.SelectedValue.ToString, "AFECTA_INVENTARIOS='1'")

            ' Propiedades del ListView  
            With Me.LstVDocumentos2
                .Items.Clear()
                .Columns.Clear()
                .View = View.Details
                .GridLines = True
                .FullRowSelect = True
                ' añadir los nombres de columnas  
                For c As Integer = 0 To dt.Columns.Count - 1 'DataSet.Tables("tabla").Columns.Count - 1
                    .Columns.Add(dt.Columns(c).ToString) '.Columns(c)))
                Next
            End With

            'Me.ListView1.Items.Count = 1
            For Each dRow As DataRow In dt.Rows
                'Me.LstVDocumentos2.Items.Add(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9))
                Me.LstVDocumentos2.Items.Add(New ListViewItem(New String() {dRow(0).ToString, dRow(1).ToString, dRow(2).ToString}))
            Next
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarDocuemtos", ex)
        End Try
    End Sub

    Private Sub llenalistview3()
        Dim dt As DataTable
        Dim oElementos As New Class_CatDocumentos
        Try
            dt = oElementos.ObtenerCodigosDocumentos(Me.CboModulos.SelectedValue.ToString, Me.CboPlazasPermiso.SelectedValue.ToString, "AFECTA_INVENTARIOS='0'")

            ' Propiedades del ListView  
            With Me.LstVDocumentos3
                .Items.Clear()
                .Columns.Clear()
                .View = View.Details
                .GridLines = True
                .FullRowSelect = True
                ' añadir los nombres de columnas  
                For c As Integer = 0 To dt.Columns.Count - 1 'DataSet.Tables("tabla").Columns.Count - 1
                    .Columns.Add(dt.Columns(c).ToString) '.Columns(c)))
                Next
            End With

            For Each dRow As DataRow In dt.Rows
                 Me.LstVDocumentos3.Items.Add(New ListViewItem(New String() {dRow(0).ToString, dRow(1).ToString}))
            Next

            If (Me.LstVDocumentos3.Items.Count) = 0 Then
                Exit Sub
            Else
                Me.LstVDocumentos3.Items(0).Selected = True
                Me.LstVDocumentos3.Select()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarDocuemtos", ex)
        End Try
    End Sub

    Private Sub llenalistview4()
        Dim dt As DataTable
        Dim oElementos As New Class_sisUsuarios(CInt(Me.TxtCodigoUsuario.Text))
        Try
            dt = oElementos.ObtenerDetallePermisosUsuarioDocumentosSinAfectaInventarios(CInt(Me.CboPlazasPermiso.SelectedValue))
           
            ' Propiedades del ListView  
            With Me.LstVDocumentos4
                .Items.Clear()
                .Columns.Clear()
                .View = View.Details
                .GridLines = True
                .FullRowSelect = True
                ' añadir los nombres de columnas  
                For c As Integer = 0 To dt.Columns.Count - 1 'DataSet.Tables("tabla").Columns.Count - 1
                    .Columns.Add(dt.Columns(c).ToString) '.Columns(c)))
                Next
            End With

            For Each dRow As DataRow In dt.Rows
                Me.LstVDocumentos4.Items.Add(New ListViewItem(New String() {dRow(0).ToString, dRow(1).ToString}))
            Next

        Catch ex As Exception
            HandleError(Me.Name, "DesplegarDocuemtos", ex)
        End Try
    End Sub

    Private Sub llenalistview5()
        Dim dt As DataTable
        Dim oElementos As New Class_CatDocumentos
        Try
            dt = oElementos.ObtenerTipoDocumentos(Me.CboModulos2.SelectedValue.ToString, Me.cboPlazas.SelectedValue.ToString, "AFECTA_INVENTARIOS='1' AND ESTATUS_DOCUMENTO='A'")

            ' Propiedades del ListView  
            With Me.LstVDocumentos5
                .Items.Clear()
                .Columns.Clear()
                .View = View.Details
                .GridLines = True
                .FullRowSelect = True
                ' añadir los nombres de columnas  
                For c As Integer = 0 To dt.Columns.Count - 1 'DataSet.Tables("tabla").Columns.Count - 1
                    .Columns.Add(dt.Columns(c).ToString) '.Columns(c)))
                Next
            End With

            'Me.ListView1.Items.Count = 1
            For Each dRow As DataRow In dt.Rows
                'Me.ListView1.Items.Add(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9))
                Me.LstVDocumentos5.Items.Add(New ListViewItem(New String() {dRow(0).ToString, dRow(1).ToString}))
            Next

            If (Me.LstVDocumentos5.Items.Count) = 0 Then
                Exit Sub
            Else
                Me.LstVDocumentos5.Items(0).Selected = True
                Me.LstVDocumentos5.Select()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarDocuemtos", ex)
        End Try
    End Sub

    Private Sub llenalistview6()
        Dim dt As DataTable
        Dim oElementos As New Class_sisUsuarios(CInt(Me.TxtCodigoUsuario.Text))
        Try
            dt = oElementos.ObtenerDetallePermisosUsuarioTipoDocumentosConAfectaInventarios()
            'oElementos.ObtenerCodigosDocumentos(Me.CboModulos.SelectedValue.ToString, Me.cboPlazas.SelectedValue.ToString, "AFECTA_INVENTARIOS='1'")

            ' Propiedades del ListView  
            With Me.LstVDocumentos6
                .Items.Clear()
                .Columns.Clear()
                .View = View.Details
                .GridLines = True
                .FullRowSelect = True
                ' añadir los nombres de columnas  
                For c As Integer = 0 To dt.Columns.Count - 1 'DataSet.Tables("tabla").Columns.Count - 1
                    .Columns.Add(dt.Columns(c).ToString) '.Columns(c)))
                Next
            End With

            For Each dRow As DataRow In dt.Rows
                Me.LstVDocumentos6.Items.Add(New ListViewItem(New String() {dRow(0).ToString, dRow(1).ToString, dRow(2).ToString, dRow(3).ToString}))
            Next

        Catch ex As Exception
            HandleError(Me.Name, "DesplegarDocuemtos", ex)
        End Try
    End Sub

    Private Function IsEmailSyntaxValid(ByVal emailToValidate As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(emailToValidate, "^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
    End Function

    Private Sub btnActualizarCorreo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarCorreo.Click
        Dim oUsuario As New Class_sisUsuarios
        If txtLEN(Me.txtCorreoUsuario.Text) = False Then
            MsgBox("Favor de capturar un correo. ", MsgBoxStyle.Information, Me.Text)
            Me.txtCorreoUsuario.Focus()
            Exit Sub
        End If

        If IsEmailSyntaxValid(Me.txtCorreoUsuario.Text) = False Then
            MsgBox("El correo no es valido, favor de verificar.", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        oUsuario.Codigo_Usuario = CInt(Me.TxtCodigoUsuario.Text)
        oUsuario.CORREO_USUARIO = Me.txtCorreoUsuario.Text
        oUsuario.CLAVE_CORREO = Me.txtClaveCorreo.Text

        If oUsuario.ActualizarCorreo() = True Then
            MsgBox("El correo del usuario se a actualizado correctamente. ", MsgBoxStyle.Information, Me.Text)
        End If
    End Sub
End Class