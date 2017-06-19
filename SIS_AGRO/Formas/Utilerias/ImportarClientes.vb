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

    Private Sub txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoClienteOrigen.KeyPress, CboZonas.KeyPress, BtnImportar.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub TxtCodigoClienteOrigen_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigoClienteOrigen.KeyDown
        Dim oClientes As New Class_CatClientes

        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                Me.TxtCodigoClienteOrigen.Text = oClientes.BusquedaVisual_PorDescripcionSinFiltroZona()

                If txtLEN(Me.TxtCodigoClienteOrigen.Text) = True Then
                    Dim sql As New Class_find("SELECT NOMBRE_CLIENTE FROM CAT_CLIENTES WHERE CODIGO_CLIENTE='" & Me.TxtCodigoClienteOrigen.Text & "'")
                    Me.LblNombreCliente.Text = sql.Result1.ToString
                End If

            Case Keys.Return
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
        End Select

        txtTAB(e)

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

            bResultado = oCliente.ImportaClienteSucursal(Me.TxtCodigoClienteOrigen.Text, Me.CboZonas.SelectedValue.ToString)

        Catch ex As Exception
            HandleError(Me.Name, "Importar", ex)
        End Try
        Return bResultado
    End Function
#End Region

End Class