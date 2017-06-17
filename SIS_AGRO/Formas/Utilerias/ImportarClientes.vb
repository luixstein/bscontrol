Public Class ImportarClientes

    Private Sub ImportarClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DesplegarZonas()
    End Sub

    Private Sub txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoClienteOrigen.KeyPress, CboZonas.KeyPress, BtnImportar.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub TxtCodigoClienteOrigen_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigoClienteOrigen.KeyDown
        Dim oClientes As New Class_CatClientes

        If e.KeyCode = Keys.F6 Then
Buscar:
            Me.TxtCodigoClienteOrigen.Text = oClientes.BusquedaVisual_PorDescripcionFiltradoZona(Me.CboZonas.SelectedValue)

            If txtLEN(Me.TxtCodigoClienteOrigen.Text) = True Then
                Dim sql As New Class_find("SELECT NOMBRE_CLIENTE FROM CAT_CLIENTES WHERE CODIGO_CLIENTE='" & Me.TxtCodigoClienteOrigen.Text & "'")
                Me.LblNombreCliente.Text = sql.Result1.ToString
            End If
        End If

        If e.KeyCode = Keys.Return Then
            If txtLEN(Me.TxtCodigoClienteOrigen.Text) = True Then
                oClientes.CODIGO_CLIENTE = Me.TxtCodigoClienteOrigen.Text

                If oClientes.Consultar() = True Then
                    Me.CboZonas.SelectedValue = oClientes.CODIGO_ZONA
                    Me.LblNombreCliente.Text = oClientes.NOMBRE_CLIENTE
                Else
                    GoTo Buscar
                End If
            Else
                Me.LblNombreCliente.Text = ""
            End If
        End If

        txtTAB(e)

    End Sub

    Private Sub DesplegarZonas()
        Dim oZonas As New Class_CatZonas
        With Me.CboZonas
            .DataSource = oZonas.ObtenerElementos
            .ValueMember = ("CODIGO_ZONA")
            .DisplayMember = ("NOMBRE_ZONA")

            If .Items.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Function Validar() As Boolean
        If txtLEN(Me.TxtCodigoClienteOrigen.Text) = False Then
            Me.TxtCodigoClienteOrigen.Focus()
            Return False
        End If

        'Dim sql As New Class_find("SELECT CODIGO_ZONA FROM CAT_CLIENTES WHERE CODIGO_CLIENTE='" & Me.TxtCodigoClienteOrigen.Text & "'")
        If Me.CboZonas.SelectedValue = Usuario.Codigo_Plaza Then
            MsgBox("El cliente " & Me.TxtCodigoClienteOrigen.Text & " ya existe en la zona: " & Usuario.Codigo_Plaza)
        End If
    End Function

End Class