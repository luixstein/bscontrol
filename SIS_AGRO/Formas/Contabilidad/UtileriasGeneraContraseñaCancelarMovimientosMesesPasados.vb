Public Class UtileriasGeneraContraseñaCancelarMovimientosMesesPasados

    Private Sub UtileriasGeneraContraseñaCancelarMovimientosMesesPasados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DtFecha.Value = Now
    End Sub

    Private Sub DtFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFecha.KeyDown
        txtTAB(e)
    End Sub

    Private Sub TxtFolio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFolio.GotFocus
        Me.txtContraseña.Text = ""
        Focus()
    End Sub

    Private Sub TxtFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFolio.KeyDown
        If e.KeyCode = Keys.Return Then
            If txtLEN(Me.TxtFolio.Text) = True Then
                txtTAB(e)
            Else
                MsgBox("Asígne el folio del documento que se cancelará con la contraseña.", vbExclamation, Me.Text)
                Me.TxtFolio.Focus()
            End If
        End If
    End Sub

    Private Sub cmdGeneraContraseña_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGeneraContraseña.Click
        GeneraContraseña()
    End Sub

    Private Sub cmdCopiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopiar.Click
        CopiarContraseña()
    End Sub

    Private Sub GeneraContraseña()
        Try
            Me.txtContraseña.Text = ""

            If txtLEN(Me.TxtFolio.Text) = False Then
                MsgBox("Asígne el folio del documento que se cancelará con la contraseña.", vbExclamation, Me.Text)
                Me.TxtFolio.Focus()
                Exit Sub
            End If

            Dim sql As New Class_find("SELECT DBO.FN_SIS_CONTRASEÑA_CANCELACION_MOVIMIENTOS_FUERA_PERIODO" & _
            "('" & sReplace(Me.TxtFolio.Text) & "','" & Format(Me.DtFecha.Value, "yyyy-dd-MM") & "')")
            If sql.Result1 <> "" Then
                Me.txtContraseña.Text = sql.Result1
            Else
                MsgBox("No se logró generar la contraseña, verifíque los datos.", vbExclamation, Me.Text)
                Me.TxtFolio.Focus()
            End If
            sql = Nothing


        Catch ex As Exception
            HandleError(Me.Text, "GeneraContraseña", ex)
        End Try
    End Sub

    Private Sub CopiarContraseña()
        Try
            Clipboard.Clear()
            Clipboard.SetText(Me.txtContraseña.Text)
        Catch ex As Exception
            HandleError(Me.Text, "CopiarContraseña", ex)
        End Try
    End Sub
End Class