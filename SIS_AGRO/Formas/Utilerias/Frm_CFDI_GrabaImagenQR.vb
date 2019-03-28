Public Class Frm_CFDI_GrabaImagenQR
    Private Sub Frm_CFDI_GrabaImagenQR_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.cboTipoDocumento.Items.Add("FACTURA_VENTA")
        Me.cboTipoDocumento.Items.Add("NOTA_CREDITO_CXC")
        Me.cboTipoDocumento.Items.Add("PAGO_CXC")
        Me.cboTipoDocumento.Items.Add("DEVOLUCION_CXC")
        Me.cboTipoDocumento.Text = "PAGO_CXC"
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If CFDI_GrabaImagenQR(Me.cboTipoDocumento.Text, Me.txtFolio.Text) = True Then
            MsgBox("Imagen grabada correctamente.", MsgBoxStyle.Information)
        End If
    End Sub
End Class