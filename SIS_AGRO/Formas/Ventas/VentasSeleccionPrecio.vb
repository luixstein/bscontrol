Option Strict On

Public Class VentasSeleccionPrecio

    Private oPrecio As Class_CatPreciosVenta

#Region "Opciones"

    Private Sub btnPrecio1_Click(sender As Object, e As EventArgs) Handles btnPrecio1.Click

    End Sub

    Private Sub btnPrecio2_Click(sender As Object, e As EventArgs) Handles btnPrecio2.Click

    End Sub

    Private Sub btnPrecio3_Click(sender As Object, e As EventArgs) Handles btnPrecio3.Click

    End Sub

    Private Sub btnPrecio4_Click(sender As Object, e As EventArgs) Handles btnPrecio4.Click

    End Sub

    Private Sub btnPrecio5_Click(sender As Object, e As EventArgs) Handles btnPrecio5.Click

    End Sub

#End Region

#Region "Eventos de objetos"
    Private Sub VentasSeleccionPrecio_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Inicializa()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Function Inicializa() As Boolean
        Try
            Me.oPrecio = New Class_CatPreciosVenta()
        Catch ex As Exception

        End Try
    End Function
#End Region

End Class