Option Explicit On

Public Class ModoSistema

    Private Sub ModoSistema_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.cboModoSistema.Items.Add("Integral")
        Me.cboModoSistema.Items.Add("Reportes")
        Me.cboModoSistema.Text = My.Settings.ModoSistema
    End Sub

    Private Sub cboServerName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboModoSistema.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.Continuar()
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Continuar()
    End Sub

    Private Sub Continuar()
        Me.Hide()
        My.Settings.ModoSistema = Me.cboModoSistema.Text
        My.Settings.Save()
        My.Settings.Reload()

        'If My.Settings.MostrarEmpresas = "1" Then
        '    Dim f As New SeleccionEmpresa
        '    f.ShowDialog()
        '    f.Dispose()
        'End If
    End Sub
End Class