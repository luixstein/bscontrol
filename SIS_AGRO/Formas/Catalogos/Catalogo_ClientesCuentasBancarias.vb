Option Strict On

Public Class Catalogo_ClientesCuentasBancarias

#Region "Campos"
    Private _CODIGO_CLIENTE As String
    Private _ID_CUENTA As String

    Enum EACCION
        AGREGAR
        EDITAR
    End Enum

    Private _ACCION As EACCION
#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public WriteOnly Property CODIGO_CLIENTE() As String
        Set(ByVal Value As String)
            Me._CODIGO_CLIENTE = Value
        End Set
    End Property

    Public Property ID_CUENTA() As String
        Get
            Return Me._ID_CUENTA
        End Get
        Set(ByVal Value As String)
            Me._ID_CUENTA = Value
        End Set
    End Property

    Public WriteOnly Property ACCION() As EACCION
        Set(ByVal Value As EACCION)
            Me._ACCION = Value
        End Set
    End Property

#End Region

#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.txtCuentaEmisor.Focus()
    End Sub

    Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
        If Me.Grabar = True Then
            Me.Hide()
        End If
    End Sub

    Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos de objetos"

    Private Sub Catalogo_ClientesCuentasBancarias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DesplegarFormasPago()
        If txtLEN(Me._ID_CUENTA) = True Then
            Me.Consultar()
        End If
        Me.CenterToParent()
    End Sub

    Private Sub txtRFCEmisor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRFCEmisor.KeyDown
        Dim sText As String, oCliente As Class_CatClientes
        Try
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    oCliente = New Class_CatClientes
                    sText = oCliente.BusquedaVisual_PorDescripcionRegresandoRFC
                    If txtLEN(sText) = True Then Me.txtRFCEmisor.Text = sText

                Case Keys.Enter
                    If txtLEN(Me.txtRFCEmisor.Text) = False Then
                        GoTo Buscar : Exit Sub
                    End If

            End Select
        Catch ex As Exception
            HandleError(Me.Name, "txtRFCEmisor_KeyDown", ex)
        End Try
    End Sub

    Private Sub txtBanco_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBancoCodigo.KeyDown
        Dim sText As String, oBancos As Class_CatBancos
        Try
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    oBancos = New Class_CatBancos
                    sText = oBancos.BusquedaVisual_PorDescripcion
                    If txtLEN(sText) = True Then Me.txtBancoCodigo.Text = sText

                Case Keys.Enter
                    If txtLEN(Me.txtBancoCodigo.Text) = False Then
                        Me.txtBancoAlias.Text = ""
                        Me.txtBancoNombre.Text = ""
                        GoTo Buscar : Return
                    End If
                    oBancos = New Class_CatBancos(Me.txtBancoCodigo.Text)
                    If oBancos.EXISTE = True Then
                        Me.txtBancoAlias.Text = oBancos.NOMBRE_BANCO
                        Me.txtBancoNombre.Text = oBancos.NOMBRE_LARGO
                    Else
                        GoTo Buscar : Return
                    End If
            End Select

            oBancos = Nothing
        Catch ex As Exception
            HandleError(Me.Name, "txtBanco_KeyDown", ex)
        End Try
    End Sub

    Private Sub chkEsBancoExtranjero_CheckedChanged(sender As Object, e As EventArgs) Handles chkEsBancoExtranjero.CheckedChanged
        Try
            Me.txtBancoCodigo.Text = ""
            Me.txtBancoNombre.Text = ""
            Me.txtBancoAlias.Text = ""

            Select Case Me.chkEsBancoExtranjero.Checked
                Case False  'Es nacional
                    Me.txtBancoCodigo.Visible = True : Me.lblDisplayBancoCodigo.Visible = True
                    Me.txtBancoNombre.Enabled = False
                    Me.txtBancoAlias.Visible = True : Me.lblDisplayBancoAlias.Visible = True
                    Me.lblMsgBancoExtranjero.Visible = False
                Case True 'Es extranjero
                    Me.txtBancoCodigo.Visible = False : Me.lblDisplayBancoCodigo.Visible = False
                    Me.txtBancoNombre.Enabled = True
                    Me.txtBancoAlias.Visible = False : Me.lblDisplayBancoAlias.Visible = False
                    Me.lblMsgBancoExtranjero.Visible = True
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "txtBanco_KeyDown", ex)
        End Try

    End Sub

#Region "Eventos Genericos"
    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuentaEmisor.KeyDown, cboFormaPago.KeyDown, txtRFCEmisor.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuentaEmisor.KeyPress, txtBancoCodigo.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFormaPago.KeyPress, txtRFCEmisor.KeyPress
        txtNoBeep(e)
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.txtCuentaEmisor.Text = ""
            Me.cboFormaPago.SelectedIndex = -1
            Me.txtRFCEmisor.Text = ""
            Me.txtBancoCodigo.Text = ""
            Me.txtBancoNombre.Text = ""
            Me.txtBancoAlias.Text = ""
            Me.chkEsBancoExtranjero.Checked = False
        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub DesplegarFormasPago()
        Try
            Dim oElementos As New Class_CFD_CatFormasPago
            With Me.cboFormaPago
                .DisplayMember = "NOMBRE_METODO_PAGO"
                .ValueMember = "CODIGO_METODO_PAGO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosParaCuentasBancarias)
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Text, "DesplegarFormasPago", ex)
        End Try
    End Sub

    Private Function Consultar() As Boolean
        Try
            Dim oCuenta As New Class_CatClientesCuentasBancarias(Me._ID_CUENTA)
            With oCuenta
                Me.txtCuentaEmisor.Text = .CUENTA
                Me.cboFormaPago.SelectedValue = .CODIGO_METODO_PAGO
                Me.txtRFCEmisor.Text = .RFC_EMISOR

                Me.chkEsBancoExtranjero.Checked = CBool(.ES_BANCO_EXTRANJERO)

                'Va primero porque gestiona controles en su check
                If .ES_BANCO_EXTRANJERO = False Then
                    Me.txtBancoCodigo.Text = .CODIGO_BANCO
                    Me.txtBancoAlias.Text = .NOMBRE_BANCO
                    Me.txtBancoNombre.Text = .NOMBRE_BANCO_LARGO
                Else
                    Me.txtBancoNombre.Text = .NOMBRE_BANCO_EMISOR_EXTRANJERO
                End If

            End With
            oCuenta = Nothing
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try
    End Function

    Private Function Grabar() As Boolean
        Dim bResultado As Boolean = False
        Try
            If Me.cboFormaPago.SelectedIndex = -1 Then
                MsgBox("Seleccione la forma de pago.", MsgBoxStyle.Exclamation, Me.Name)
                Me.cboFormaPago.Focus()
                Return False
            End If

            If txtLEN(Me.txtRFCEmisor.Text) = False Then
                MsgBox("Asígne el RFC del emisor.", MsgBoxStyle.Exclamation, Me.Name)
                Me.txtRFCEmisor.Focus()
                Return False
            End If

            If Len(Me.txtRFCEmisor.Text) < 12 Then
                MsgBox("RFC del emisor inválido.", vbExclamation, Me.Name)
                Me.txtRFCEmisor.Focus()
                Return False
            End If

            Dim oFormaPago As New Class_CFD_CatFormasPago(Me.cboFormaPago.SelectedValue.ToString)

            If oFormaPago.ES_BANCARIZADO = True Then

                If txtLEN(Me.txtCuentaEmisor.Text) = False Then
                    MsgBox("Asígne la cuenta del emisor.", vbExclamation, Me.Name)
                    Me.txtCuentaEmisor.Focus()
                    Return False
                End If

                If Len(Me.txtCuentaEmisor.Text) <> oFormaPago.DIGITOS Then
                    MsgBox("La cuenta del emisor debe ser de " & oFormaPago.DIGITOS.ToString & " dígitos para esta forma de pago.", vbExclamation, Me.Name)
                    Me.txtCuentaEmisor.Focus()
                    Return False
                End If

                If Me.txtCuentaEmisor.Text.Length = 18 Then 'Si es clabe interbancaria
                    If ValidarCLABEInterbancaria(Me.txtCuentaEmisor.Text) = False Then
                        If MsgBox("La clabe interbancaria es muy probable que este incorrecta, seguro desea grabarla así ?", vbQuestion Or vbYesNo, "Validar") = vbNo Then
                            Return False
                        End If
                    End If
                End If

                If Me.chkEsBancoExtranjero.Checked = False Then 'Banco mexicano
                    If txtLEN(Me.txtBancoCodigo.Text) = False Then
                        MsgBox("Asígne el banco de la cuenta bancaria.", vbExclamation, Me.Name)
                        Me.txtBancoCodigo.Focus()
                        Return False
                    End If

                    Dim oBanco As New Class_CatBancos(Me.txtBancoCodigo.Text)
                    If oBanco.EXISTE = False Then
                        MsgBox("El banco seleccionado no existe.", vbExclamation, Me.Name)
                        Me.txtBancoCodigo.Focus()
                        Return False
                    End If
                    oBanco = Nothing

                Else 'Banco extranjero, no se valida el código del banco, pero si el nombre
                    If txtLEN(Me.txtBancoNombre.Text) = False Then
                        MsgBox("Capture el nombre del banco extranjero.", vbExclamation, Me.Name)
                        Me.txtBancoNombre.Focus()
                        Exit Function
                    End If
                End If

            End If

            'If Me.cboFormaPago.SelectedValue.ToString = "02" Or Me.cboFormaPago.SelectedValue.ToString = "03" Then '02=CHEQUE NOMINATIVO, 03=TRANSFERENCIA ELECTRONICA DE FONDOS
            '    If txtLEN(Me.txtBanco.Text) = False Then
            '        MsgBox("Asígne el banco de la cuenta bancaria.", vbExclamation, Me.Name)
            '        Me.txtBanco.Focus()
            '        Return False
            '    End If
            '    Dim oBanco As New Class_CatBancos(Me.txtBanco.Text)
            '    If oBanco.EXISTE = False Then
            '        MsgBox("El banco seleccionado no existe.", vbExclamation, Me.Name)
            '        Me.txtBanco.Focus()
            '        Return False
            '    End If
            '    oBanco = Nothing

            '    'If Me.cboFormaPago.SelectedValue.ToString = "02" Then '02=CHEQUE NOMINATIVO
            '    '    If txtLEN(Me.txtCuentaEmisor.Text) = False Then
            '    '        MsgBox("Asígne la cuenta del emisor.", vbExclamation, Me.Name)
            '    '        Me.txtCuentaEmisor.Focus()
            '    '        Return False
            '    '    End If
            '    'End If

            '    If txtLEN(Me.txtCuentaEmisor.Text) = False Then
            '        MsgBox("Asígne la cuenta del emisor.", vbExclamation, Me.Name)
            '        Me.txtCuentaEmisor.Focus()
            '        Return False
            '    End If

            'End If

            ''si es transferencia la cuenta emisor es opcional(en la contabilidad electrónica, aunque en el complemento de pagos es opcional, es una ambiguedad por eso se pide como oblitario en ch/tr)
            'If txtLEN(Me.txtCuentaEmisor.Text) = True And Len(Me.txtCuentaEmisor.Text) < 10 Then
            '    MsgBox("La cuenta del emisor debe ser de mínimamente de 10 dígitos, si no la tiene puede dejarla en blanco(cuando no es ch/tr).", vbExclamation, Me.Name)
            '    Return False
            'End If

            Dim oCuenta As New Class_CatClientesCuentasBancarias

            'Para el agregar no se necesita un new con parámetro
            If Me._ACCION = EACCION.EDITAR Then
                oCuenta = New Class_CatClientesCuentasBancarias(Me._ID_CUENTA)
            End If

            With oCuenta
                .CODIGO_CLIENTE = Me._CODIGO_CLIENTE
                .CUENTA = Me.txtCuentaEmisor.Text.ToUpper
                .CODIGO_METODO_PAGO = Me.cboFormaPago.SelectedValue.ToString
                .RFC_EMISOR = Me.txtRFCEmisor.Text.ToUpper
                .CODIGO_BANCO = Me.txtBancoCodigo.Text.ToUpper
                .ES_BANCO_EXTRANJERO = Me.chkEsBancoExtranjero.Checked
                .NOMBRE_BANCO_EMISOR_EXTRANJERO = Me.txtBancoNombre.Text

                Select Case Me._ACCION
                    Case EACCION.AGREGAR
                        bResultado = .Grabar("1")
                    Case EACCION.EDITAR
                        bResultado = .Grabar("0")
                End Select

                Me._ID_CUENTA = .ID_CUENTA
            End With

            oCuenta = Nothing

        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try
        Return bResultado
    End Function

#End Region

End Class