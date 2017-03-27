Public Class Ventas_Comentarios

    Private _Aceptar As Boolean = False

    Public Property Aceptar() As Boolean
        Get
            Return Me._Aceptar
        End Get
        Set(ByVal Value As Boolean)
            Me._Aceptar = Value
        End Set
    End Property

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Close()
        Me._Aceptar = True
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me._Aceptar = False
    End Sub
End Class