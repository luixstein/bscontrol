Option Strict On

Public Class Catalogo_Clientes_ActualizaCorreo

#Region "Campos"
    Private _bActualizado As Boolean = False
    Private _oCliente As Class_CatClientes
#End Region

#Region "Propiedades"
    Public ReadOnly Property bActualizado As Boolean
        Get
            Return Me._bActualizado
        End Get
    End Property
#End Region

#Region "Opciones"
    Private Sub btnActualizaCorreo_Click(sender As Object, e As EventArgs) Handles btnActualizaCorreo.Click
        Me.ActualizaCorreo()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me._bActualizado = False
        Me.Hide()
    End Sub
#End Region

#Region "Eventos de objetos"

#End Region

#Region "Métodos y procedimientos"
    Public Sub New(ByRef oCliente As Class_CatClientes) ' aqui si es byref para editarlo en memoria y regresarlo editado '(ByVal sCodigoCliente As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'Me._oCliente = New Class_CatClientes(sCodigoCliente)

        Me._oCliente = oCliente

        Me.txtCodigoCliente.Text = Me._oCliente.CODIGO_CLIENTE
        Me.lblNombreCliente.Text = Me._oCliente.NOMBRE_CLIENTE
        Me.txtCorreoCliente.Text = Trim(Me._oCliente.CORREO_CLIENTE)
    End Sub

    Private Function ActualizaCorreo() As Boolean
        Dim tabla() As String
        Try
            Me.txtCorreoCliente.Text = Trim(Me.txtCorreoCliente.Text)
            tabla = Split(Me.txtCorreoCliente.Text, ";")

            For n = 0 To UBound(tabla, 1)
                If IsEmailSyntaxValid(tabla(n)) = False Then
                    MsgBox("El correo no es válido, favor de verificar.", MsgBoxStyle.Exclamation, "Validación")
                    Return False
                End If
            Next

            Me._oCliente.CORREO_CLIENTE = Trim(Me.txtCorreoCliente.Text)
            If Me._oCliente.ActualizarCorreo = True Then
                Me._bActualizado = True
                Me.Hide()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "ActualizaCorreo", ex)
        End Try
    End Function
#End Region

End Class