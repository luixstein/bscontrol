Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Catalogo_Negociantes_Cxc
    Private oNegociante As New Class_CatNegociantesCxc
    Public sCodigoCliente As String

#Region "Campos"

#Region "Campos ligados a la tabla"

#End Region

#Region "Campos públicos"
    Public sEstado As String
    Public iCodigoNegociante As Integer = 0
#End Region

#Region "Campos privados"
    'Public Enum enumEstados
    '    NUEVO
    '    EDICION
    '    CONSULTA
    'End Enum


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
            Me.msgElemento = "Negociante"
            Me.msgElementos = "Negociantes"
            Me.Run = False
            'Me.lstbElementos.ContextMenuStrip = Me.cMenuStripAccion
            'Estado = enumEstados.CONSULTA
            'Me.Cambia_Estado()
            'Me.DesplegarElementos()
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
    'Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.Estado = enumEstados.NUEVO
    '    Me.Cambia_Estado()
    '    Me.TxtCodigo.Text = Me.oNegociante.CodigoSiguiente
    'End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.Estado = enumEstados.EDICION
        'Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Grabar_Elemento() = True Then
            Me.Close()
        End If
    End Sub

    'Private Sub tsbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.Estado = enumEstados.CONSULTA
    '    Me.Cambia_Estado()
    'End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbImprimirListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.oNegociante.Imprimir_Listado()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Public Sub Cambia_Estado()
        'Dim iIndex As Integer
        Select Case sEstado
            Case "NUEVO"
                Me.tssLabelEstado.Text = "Agregando nuevo " & Me.msgElemento
                Me.TxtNombre.Focus()

            Case "EDICION"
                Me.LlenaElemento(iCodigoNegociante)
                Me.tssLabelEstado.Text = "Edición"
                Me.TxtNombre.Focus()
        End Select
        Application.DoEvents()
    End Sub

    Private Sub InicializaElemento()
        Me.TxtNombre.Text = ""
        'Me.txtCliente.Text = ""
        Me.txtEmail.Text = ""
        Me.txtPuesto.Text = ""
        Me.txtTelefono.Text = ""
        Me.txtCelular.Text = ""
    End Sub

    'Private Sub DesplegarElementos()
    '    With Me.lstbElementos
    '        .DisplayMember = "NOMBRE_NEGOCIANTE"

    '        .ValueMember = "CODIGO_NEGOCIANTE"

    '        Dim dView As New Data.DataView(Me.oNegociante.ObtenerElementos)
    '        dView.Sort = "NOMBRE_NEGOCIANTE"
    '        .DataSource = dView
    '        If dView.Count > 0 Then
    '            .SelectedIndex = 0
    '        End If
    '    End With

    'End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As Integer)
        Me.oNegociante.CODIGO_NEGOCIANTE = iCodigo_Elemento
        If Me.oNegociante.Consultar Then
            With Me.oNegociante
                Me.TxtNombre.Text = .NOMBRE_NEGOCIANTE.ToString
                'Me.txtCliente.Text = .CODIGO_CLIENTE
                Me.txtEmail.Text = .EMAIL
                Me.txtPuesto.Text = .PUESTO
                Me.txtTelefono.Text = .TELEFONO
                Me.txtCelular.Text = .CELULAR
            End With
        End If
    End Sub

    Private Function Grabar_Elemento() As Boolean
        Dim Grabado As Boolean = False
        'Select Case Me.Estado
        'Case enumEstados.NUEVO, enumEstados.EDICION
        Try
            If txtLEN(Me.TxtNombre.Text) = False Then
                MsgBox("Asígne el nombre del negociante.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtNombre.Focus()
                Exit Function
            End If

            With Me.oNegociante
                .CODIGO_NEGOCIANTE = iCodigoNegociante
                .NOMBRE_NEGOCIANTE = Me.TxtNombre.Text.ToUpper
                .CODIGO_CLIENTE = sCodigoCliente
                .EMAIL = Me.txtEmail.Text.ToUpper
                .PUESTO = Me.txtPuesto.Text.ToUpper
                .TELEFONO = Me.txtTelefono.Text
                .CELULAR = Me.txtCelular.Text

                Select Case Me.sEstado
                    Case "NUEVO"
                        If .Insertar() = False Then
                            Exit Function
                        End If
                        iCodigoNegociante = .CODIGO_NEGOCIANTE
                    Case "EDICION"
                        If .Actualizar() = False Then
                            Exit Function
                        End If
                End Select

                MsgBox(Me.msgElemento & " Grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
                Grabar_Elemento = True

            End With
        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
            Me.Cambia_Estado()
        Finally

        End Try
        'End Select
    End Function

#End Region

#Region "Eventos de objetos"
#Region "Eventos de la lista de elementos"
    'Private Sub lstbElementos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstbElementos.DoubleClick
    '    Me.Estado = enumEstados.EDICION
    '    Me.Cambia_Estado()
    'End Sub

    'Private Sub lstbElementos_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstbElementos.Enter
    '    If Me.lstbElementos.Items.Count > 0 Then
    '        'Me.tsbEditar.Enabled = True
    '    End If
    'End Sub

    'Private Sub lstbElementos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstbElementos.LostFocus
    '    'Me.tsbEditar.Enabled = False
    'End Sub

    'Private Sub lstbElementos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstbElementos.SelectedIndexChanged
    '    If Me.lstbElementos.SelectedIndex >= 0 Then
    '        Me.LlenaElemento(CInt(Me.lstbElementos.SelectedValue))
    '    End If
    'End Sub
#End Region

#Region "Eventos Genericos"

    Private Sub CboEstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            tsbGrabar.PerformClick()
        End If
    End Sub
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        txtNoBeep(e)
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
            Me.ErrorProvider.Clear()
        End If
    End Sub
#End Region


#Region "Keydown específicos"

#End Region

#Region "Validating específicos"

#End Region

#End Region

    Private Sub gBoxInformacion_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gBoxInformacion.Enter

    End Sub

    Private Sub txtEmail_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTelefono.KeyDown, txtPuesto.KeyDown, TxtNombre.KeyDown, txtEmail.KeyDown, txtCelular.KeyDown
        txtTAB(e)
    End Sub

    Private Sub txtEmail_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefono.KeyPress, txtPuesto.KeyPress, TxtNombre.KeyPress, txtEmail.KeyPress, txtCelular.KeyPress
        txtNoBeep(e)
    End Sub
End Class