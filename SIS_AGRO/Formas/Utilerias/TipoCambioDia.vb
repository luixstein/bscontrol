Public Class TipoCambioDia
    Dim oTipoCambioDia As New Class_CatTiposCambio

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.Label1.Text = "Tipo de cambio de hoy " & Date.Now.ToShortDateString & " :"
        Consultar()

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

        oTipoCambioDia.FECHA = Date.Now
        If oTipoCambioDia.Consultar = True And oTipoCambioDia.TIPO_DE_CAMBIO <> 0 Then
            Me.TxtTipoCambio.Text = oTipoCambioDia.TIPO_DE_CAMBIO.ToString
            Me.tsbGrabar.Enabled = False
            Me.TxtTipoCambio.Enabled = False

        Else
            Me.TxtTipoCambio.Text = "0"
            Me.tsbGrabar.Enabled = True
            Me.TxtTipoCambio.Enabled = True
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

        oTipoCambioDia = New Class_CatTiposCambio()
        Try
            With Me.oTipoCambioDia
                .FECHA = Date.Now
                .TIPO_DE_CAMBIO = CDec(Me.TxtTipoCambio.Text)

                If .GrabarTipoCambio() = False Then
                    MsgBox("Error al intentar grabar el tipo de cambio del día.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                End If
            End With

        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try

        Return bResultado
    End Function

    Private Sub TxtTipoCambio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtTipoCambio.KeyPress
        txtSoloNumerosDecimales(e, Me.TxtTipoCambio.Text)
        txtNoBeep(e)
    End Sub
End Class