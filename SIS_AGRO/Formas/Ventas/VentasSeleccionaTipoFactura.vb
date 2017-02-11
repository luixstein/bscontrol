Option Strict On

Public Class VentasSeleccionaTipoFactura
    Private Sub VentasSeleccionaTipoFactura_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CargarDocumentos()
    End Sub

    Private Sub CargarDocumentos()
        Try
            Dim oDocumentos As New Class_CatDocumentos
            With Me.CboDocumento
                .DisplayMember = "NOMBRE_TIPO_DOCUMENTO"
                .ValueMember = "CODIGO_DOCUMENTO"
                Dim dView As New Data.DataView(oDocumentos.ObtenerTiposFacturas)
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "CargarDocumentos", ex)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Hide()
    End Sub
End Class