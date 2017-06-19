Option Strict On

Public Class ImportarClientes

#Region "Opciones"
    Private Sub BtnImportar_Click(sender As Object, e As EventArgs) Handles BtnImportar.Click
        Me.Importar()
    End Sub
#End Region

#Region "Eventos de objetos"
    Private Sub ImportarClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DesplegarZonas()
        Me.CboZonas.SelectedValue = Plaza.CODIGO_ZONA_PRINCIPAL
    End Sub

    Private Sub txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoClienteOrigen.KeyPress, CboZonas.KeyPress, BtnImportar.KeyPress, txtVendedor.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub TxtCodigoClienteOrigen_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigoClienteOrigen.KeyDown
        Dim oCliente As New Class_CatClientes

        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                Me.TxtCodigoClienteOrigen.Text = oCliente.BusquedaVisual_PorDescripcionSinFiltroZona()

                If txtLEN(Me.TxtCodigoClienteOrigen.Text) = True Then
                    GoTo Enter : Exit Sub
                End If

            Case Keys.Return
Enter:
                If txtLEN(Me.TxtCodigoClienteOrigen.Text) = False Then
                    Me.LblNombreCliente.Text = "" : GoTo Buscar : Exit Sub
                End If

                oCliente = New Class_CatClientes(Me.TxtCodigoClienteOrigen.Text)

                If oCliente.Existe = True Then
                    Me.LblNombreCliente.Text = oCliente.NOMBRE_CLIENTE
                Else
                    GoTo Buscar : Exit Sub
                End If

                Me.CboZonas.Focus()
        End Select

    End Sub

    Private Sub txtVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVendedor.KeyDown
        Dim oVendedor As New Class_CatVendedores

        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                Me.txtVendedor.Text = oVendedor.BusquedaVisual_PorDescripcion
                If txtLEN(Me.txtVendedor.Text) = True Then
                    GoTo Enter : Exit Sub
                End If

            Case Keys.Return
Enter:
                If txtLEN(Me.txtVendedor.Text) = False Then
                    Me.lblVendedor.Text = "" : GoTo Buscar : Exit Sub
                End If

                oVendedor = New Class_CatVendedores(Me.txtVendedor.Text)

                If oVendedor.Existe = True Then
                    Me.lblVendedor.Text = oVendedor.NOMBRE_VENDEDOR
                Else
                    GoTo Buscar : Exit Sub
                End If

                Me.BtnImportar.Focus()
        End Select
    End Sub

#End Region

#Region "Métodos y procedimientos"
    Private Sub DesplegarZonas()
        Try
            Dim oZonas As New Class_CatZonas
            With Me.CboZonas
                .DataSource = oZonas.ObtenerElementos
                .ValueMember = ("CODIGO_ZONA")
                .DisplayMember = ("NOMBRE_ZONA")
                If .Items.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarZonas", ex)
        End Try
    End Sub

    Private Function Importar() As Boolean
        Dim bResultado As Boolean = False
        Try
            If MsgBox("Desea importar el cliente en la zona seleccionada ?", vbYesNo Or MsgBoxStyle.Question, Me.Text) = MsgBoxResult.No Then
                Return False
            End If

            If txtLEN(Me.TxtCodigoClienteOrigen.Text) = False Then
                MsgBox("Asígne el cliente origen.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoClienteOrigen.Focus()
                Return False
            End If

            Dim oCliente As New Class_CatClientes(Me.TxtCodigoClienteOrigen.Text)

            If oCliente.Existe = False Then
                MsgBox("El cliente origen no existe.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoClienteOrigen.Focus()
                Return False
            End If

            If Me.CboZonas.SelectedIndex = -1 Then
                MsgBox("Seleccione la zona destino.", MsgBoxStyle.Exclamation, Me.Text)
                Me.CboZonas.Focus()
                Return False
            End If

            If txtLEN(Me.txtVendedor.Text) = False Then
                MsgBox("Asígne el vendedor.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtVendedor.Focus()
                Return False
            End If

            bResultado = oCliente.ImportaClienteSucursal(Me.TxtCodigoClienteOrigen.Text, Me.CboZonas.SelectedValue.ToString, Me.txtVendedor.Text)

            If bResultado = True Then
                MsgBox("Cliente importado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Importar", ex)
        End Try
        Return bResultado
    End Function


#End Region

End Class