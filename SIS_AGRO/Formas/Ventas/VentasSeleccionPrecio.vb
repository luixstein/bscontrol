Option Strict On

Public Class VentasSeleccionPrecio

    Private oPrecio As Class_CatPreciosVenta
    Private _CodigoArticulo As String
    Private _PrecioSeleccionado As Decimal = 0

    Public ReadOnly Property PrecioSeleccionado() As Decimal
        Get
            Return Me._PrecioSeleccionado
        End Get
    End Property

#Region "Constructor y destructor"
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal CodigoArticulo As String)
        Me.New()
        Me._CodigoArticulo = CodigoArticulo
        Me.Consultar()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"

    Private Sub btnPrecio1_Click(sender As Object, e As EventArgs) Handles btnPrecio1.Click
        Me._PrecioSeleccionado = valorNumericoD(Me.txtPrecio1.Text)
        Me.Hide()
    End Sub

    Private Sub btnPrecio2_Click(sender As Object, e As EventArgs) Handles btnPrecio2.Click
        Me._PrecioSeleccionado = valorNumericoD(Me.txtPrecio2.Text)
        Me.Hide()
    End Sub

    Private Sub btnPrecio3_Click(sender As Object, e As EventArgs) Handles btnPrecio3.Click
        Me._PrecioSeleccionado = valorNumericoD(Me.txtPrecio3.Text)
        Me.Hide()
    End Sub

    Private Sub btnPrecio4_Click(sender As Object, e As EventArgs) Handles btnPrecio4.Click
        Me._PrecioSeleccionado = valorNumericoD(Me.txtPrecio4.Text)
        Me.Hide()
    End Sub

    Private Sub btnPrecio5_Click(sender As Object, e As EventArgs) Handles btnPrecio5.Click
        Me._PrecioSeleccionado = valorNumericoD(Me.txtPrecio5.Text)
        Me.Hide()
    End Sub

#End Region

#Region "Eventos de objetos"
    Private Sub VentasSeleccionPrecio_Load(sender As Object, e As EventArgs) Handles Me.Load
        '
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Function Consultar() As Boolean
        Try
            Me.oPrecio = New Class_CatPreciosVenta(Me._CodigoArticulo)
            If Me.oPrecio.Existe = True Then
                Me.txtPrecio1.Text = FormatPrecio(Me.oPrecio.PRECIO1)
                Me.txtPrecio2.Text = FormatPrecio(Me.oPrecio.PRECIO2)
                Me.txtPrecio3.Text = FormatPrecio(Me.oPrecio.PRECIO3)
                Me.txtPrecio4.Text = FormatPrecio(Me.oPrecio.PRECIO4)
                Me.txtPrecio5.Text = FormatPrecio(Me.oPrecio.PRECIO5)
                Me.txtPrecio1_IEPS.Text = FormatPrecio(Me.oPrecio.PRECIO1_IEPS)
                Me.txtPrecio2_IEPS.Text = FormatPrecio(Me.oPrecio.PRECIO2_IEPS)
                Me.txtPrecio3_IEPS.Text = FormatPrecio(Me.oPrecio.PRECIO3_IEPS)
                Me.txtPrecio4_IEPS.Text = FormatPrecio(Me.oPrecio.PRECIO4_IEPS)
                Me.txtPrecio5_IEPS.Text = FormatPrecio(Me.oPrecio.PRECIO5_IEPS)
                Me.txtIEPSPtje.Text = Format(Me.oPrecio.IEPS_PORCENTAJE, "0.00") & " %"
            End If
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try
    End Function
#End Region

End Class