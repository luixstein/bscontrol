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
        Me.DesplegarMetodosPago()
        If txtLEN(Me._ID_CUENTA) = True Then
            Me.CargaDatos()
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

    Private Sub txtBanco_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBanco.KeyDown
        Dim sText As String, oBancos As Class_CatBancos
        Try
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    oBancos = New Class_CatBancos
                    sText = oBancos.BusquedaVisual_PorDescripcion
                    If txtLEN(sText) = True Then Me.txtBanco.Text = sText

                Case Keys.Enter
                    If txtLEN(Me.txtBanco.Text) = False Then
                        Me.lblBanco.Text = "" : GoTo Buscar : Exit Sub
                    End If
                    oBancos = New Class_CatBancos(Me.txtBanco.Text)
                    Me.lblBanco.Text = oBancos.NOMBRE_BANCO

            End Select

            oBancos = Nothing
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

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuentaEmisor.KeyPress, txtBanco.KeyPress
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
            Me.txtBanco.Text = ""
            Me.lblBanco.Text = ""
        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub DesplegarMetodosPago()
        Try
            Dim oElementos As New Class_CFD_CatFormasPago
            With Me.cboFormaPago
                .DisplayMember = "NOMBRE_METODO_PAGO"
                .ValueMember = "CODIGO_METODO_PAGO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos())
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Text, "DesplegarMetodosPago", ex)
        End Try
    End Sub

    Private Function CargaDatos() As Boolean
        Try
            Dim oCuenta As New Class_CatClientesCuentasBancarias(Me._ID_CUENTA)
            With oCuenta
                Me.txtCuentaEmisor.Text = .CUENTA
                Me.cboFormaPago.SelectedValue = .CODIGO_METODO_PAGO
                Me.txtRFCEmisor.Text = .RFC_EMISOR
                Me.txtBanco.Text = .CODIGO_BANCO
                Me.lblBanco.Text = .NOMBRE_BANCO
            End With
            oCuenta = Nothing
        Catch ex As Exception
            HandleError(Me.Name, "CargaDatos", ex)
        End Try
    End Function

    Private Function Grabar() As Boolean
        Dim bResultado As Boolean = False
        Try
            If Me.cboFormaPago.SelectedIndex = -1 Then
                MsgBox("Asígne el método de pago.", MsgBoxStyle.Exclamation, Me.Name)
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

            If Me.cboFormaPago.SelectedValue.ToString = "02" Or Me.cboFormaPago.SelectedValue.ToString = "03" Then '02=CHEQUE NOMINATIVO, 03=TRANSFERENCIA ELECTRONICA DE FONDOS
                If txtLEN(Me.txtBanco.Text) = False Then
                    MsgBox("Asígne el banco de la cuenta bancaria.", vbExclamation, Me.Name)
                    Me.txtBanco.Focus()
                    Return False
                End If
                Dim oBanco As New Class_CatBancos(Me.txtBanco.Text)
                If oBanco.EXISTE = False Then
                    MsgBox("El banco seleccionado no existe.", vbExclamation, Me.Name)
                    Me.txtBanco.Focus()
                    Return False
                End If
                oBanco = Nothing

                'If Me.cboFormaPago.SelectedValue.ToString = "02" Then '02=CHEQUE NOMINATIVO
                '    If txtLEN(Me.txtCuentaEmisor.Text) = False Then
                '        MsgBox("Asígne la cuenta del emisor.", vbExclamation, Me.Name)
                '        Me.txtCuentaEmisor.Focus()
                '        Return False
                '    End If
                'End If

                If txtLEN(Me.txtCuentaEmisor.Text) = False Then
                    MsgBox("Asígne la cuenta del emisor.", vbExclamation, Me.Name)
                    Me.txtCuentaEmisor.Focus()
                    Return False
                End If

            End If

            'si es transferencia la cuenta emisor es opcional(en la contabilidad electrónica, aunque en el complemento de pagos es opcional, es una ambiguedad por eso se pide como oblitario en ch/tr)
            If txtLEN(Me.txtCuentaEmisor.Text) = True And Len(Me.txtCuentaEmisor.Text) < 10 Then
                MsgBox("La cuenta del emisor debe ser de mínimamente de 10 dígitos, si no la tiene puede dejarla en blanco(cuando no es ch/tr).", vbExclamation, Me.Name)
                Return False
            End If

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
                .CODIGO_BANCO = Me.txtBanco.Text.ToUpper

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