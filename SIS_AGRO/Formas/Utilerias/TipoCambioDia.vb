Public Class TipoCambioDia
    Dim oTipoCambioDia As New Class_TipoCambioDia
   
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.Label1.Text = "Tipo de cambio de hoy " & Date.Now.ToShortDateString & " :"
        Consultar()

    End Sub

    Private Sub tsbEditar_Click(sender As Object, e As EventArgs) Handles tsbEditar.Click
        Me.txtTipoCambio.Enabled = True
        Me.tsbGrabar.Enabled = True
        Me.tsbEditar.Enabled = False
    End Sub

    Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
        If MsgBox("Deseas grabar el tipo de cambio del día ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Grabar") = MsgBoxResult.Yes Then
            If Me.Grabar() = True Then
                MsgBox("Tipo de cambio del día grabado correctamente.", MsgBoxStyle.Information, Me.Name)
                Me.Consultar()
            End If

        End If

    End Sub

    Private Sub txtTipoCambio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTipoCambio.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.tsbGrabar.PerformClick()
        End If
    End Sub

    Private Sub Consultar()

        oTipoCambioDia.FECHA_TIPO_CAMBIO = Format(Date.Now, "yyyy-dd-MM")
        If oTipoCambioDia.Consultar = True Then
            Me.txtId.Text = oTipoCambioDia.ID.ToString
            Me.txtTipoCambio.Text = oTipoCambioDia.TIPO_CAMBIO.ToString

            Dim sql = New Class_find("SELECT NOMBRE_USUARIO FROM SIS_USUARIOS WHERE CODIGO_USUARIO =" & oTipoCambioDia.CODIGO_ULTIMO_USUARIO_GRABO.ToString)
            Me.tsslUsuarioGrabo.Text = "Ultimo usuario modifico : " & sql.Result1
            Me.tsbGrabar.Enabled = False
            Me.tsbEditar.Enabled = True
            Me.txtTipoCambio.Enabled = False

        Else
            Me.txtTipoCambio.Text = "0"
            Me.tsbGrabar.Enabled = True
            Me.tsbEditar.Enabled = False
            Me.txtTipoCambio.Enabled = True
        End If

    End Sub

    Private Function Grabar() As Boolean
        Dim bResultado As Boolean = True

        If txtLEN(Me.txtTipoCambio.Text) = True Then
            If CDec(Me.txtTipoCambio.Text) = 0 Then
                MsgBox("El tipo de cambio no puede ser 0.", MsgBoxStyle.Exclamation, Me.Name)
                Me.txtTipoCambio.Focus()
                Return False
            End If
        Else
            MsgBox("Capture el tipo de cambio.", MsgBoxStyle.Exclamation, Me.Name)
            Me.txtTipoCambio.Focus()
            Return False
        End If

        Try
            With Me.oTipoCambioDia
                If txtLEN(Me.txtId.Text) = False Then 'Insertar
                    .TIPO_CAMBIO = CDec(Me.txtTipoCambio.Text)
                    .CODIGO_ULTIMO_USUARIO_GRABO = Usuario.Codigo_Usuario

                    If oTipoCambioDia.Insertar() = False Then
                        MsgBox("Error al grabar el tipo de cambio del día.", MsgBoxStyle.Exclamation, Me.Name)
                        bResultado = False
                    End If

                Else 'Editar
                    .ID = CInt(Me.txtId.Text)
                    .TIPO_CAMBIO = CDec(Me.txtTipoCambio.Text)
                    .CODIGO_ULTIMO_USUARIO_GRABO = Usuario.Codigo_Usuario

                    If oTipoCambioDia.Actualizar() = False Then
                        MsgBox("Error al actualizar el tipo de cambio del día.", MsgBoxStyle.Exclamation, Me.Name)
                        bResultado = False
                    End If
                End If

            End With

        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try

        Return bResultado
    End Function

End Class