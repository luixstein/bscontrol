Option Strict On

Public Class Frm_Contraseña_Cambio_Periodo
    Public bContraseñaValida As Boolean = False

    Enum eTipoContraseña
        CambioPeriodo
        PrecioMenorCosto
    End Enum

    Public TipoContraseña As eTipoContraseña = eTipoContraseña.CambioPeriodo
    Public Mensaje As String = ""

    Private Sub Frm_Contraseña_Cambio_Periodo_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.lblMensaje.Text = Mensaje
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.ValidaContraseña() = True Then
            bContraseñaValida = True
            Me.Visible = False
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtCambioPeriodo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCambioPeriodo.KeyDown
        If e.KeyCode = Keys.Return Then
            btnAceptar.PerformClick()
            'If txtLEN(Me.txtCambioPeriodo.Text) = True Then
            ' Me.btnAceptar.Focus()
            'End If
        End If
    End Sub

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCambioPeriodo.KeyPress
        txtNoBeep(e)
    End Sub

#Region "Métodos y procedimientos"
    Private Function ValidaContraseña() As Boolean
        Try
            Dim ValidaPass As Class_find = Nothing
            Select Case Me.TipoContraseña
                Case eTipoContraseña.CambioPeriodo
                    ValidaPass = New Class_find("SELECT CONTRASEÑA_PERIODO_TRABAJO_CONTABLE FROM SIS_EMPRESA")
                Case eTipoContraseña.PrecioMenorCosto
                    ValidaPass = New Class_find("SELECT CONTRASEÑA_PRECIO_MENOR_COSTO FROM SIS_EMPRESA")
            End Select

            If ValidaPass.Result1 = Me.txtCambioPeriodo.Text Then
                ValidaContraseña = True
            Else
                MsgBox("La contraseña es incorrecta intente de nuevo.", MsgBoxStyle.Information, "ValidaContraseña")
                Me.txtCambioPeriodo.Text = ""
            End If
        Catch ex As Exception
            HandleError(Me.Name, "ValidaContraseña", ex)
        End Try
    End Function
#End Region

End Class