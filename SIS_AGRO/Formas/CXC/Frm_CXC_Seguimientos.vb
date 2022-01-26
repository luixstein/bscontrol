Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Frm_CXC_Seguimientos
    Dim oSeguimientos As New Class_CXC_Seguimientos
    Public sCodigoCliente As String

#Region "Constructor y destructor"
    Public Sub New()
        InitializeComponent()
        Inicializa()
        DesplegarNombreNegociante()
        DesplegarTipoAcuerdo()
        DesplegarContantadoPor()
    End Sub

    Public Sub New(ByVal sCliente As String)
        sCodigoCliente = sCliente
        InitializeComponent()
        Inicializa()
        DesplegarNombreNegociante()
        DesplegarTipoAcuerdo()
        DesplegarContantadoPor()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"

    Private Sub tsbSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Enum enumEstados
        NUEVO
        EDICION
    End Enum

    Private Sub Inicializa()
        Me.txtNegocio.Text = ""
        Me.lblNombreNegocio.Text = ""
        Me.txtSeguimiento.Text = ""
        Me.DtpFecha.Value = Now
        Me.DtpHora.Value = Now
        Me.txtSeguimiento.Focus()
    End Sub

    Private Sub DesplegarTipoAcuerdo()
        Dim oElementos As New Class_CXC_Seguimientos
        With Me.cboTipoAcuerdo
            .DisplayMember = "NOMBRE_TIPO_ACUERDO"
            .ValueMember = "CODIGO_TIPO_ACUERDO"
            Dim dView As New Data.DataView(oElementos.ObtenerTipoAcuerdo)
            ' dView.Sort = "NOMBRE_EJERCICIO"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub DesplegarNombreNegociante()
        Dim oElementos As New Class_CXC_Seguimientos
        With Me.cboNombreNegociante
            .DisplayMember = "NOMBRE_NEGOCIANTE"
            .ValueMember = "CODIGO_NEGOCIANTE"
            Dim dView As New Data.DataView(oElementos.ObtenerNombreNegociante(sCodigoCliente))
            ' dView.Sort = "NOMBRE_EJERCICIO"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub DesplegarContantadoPor()
        Me.cbocontactadoPor.Items.Add("TELEFONO")
        Me.cbocontactadoPor.Items.Add("VISITA")

        Me.cbocontactadoPor.Text = "TELEFONO"
    End Sub

#End Region

#Region "Eventos Genericos"

#End Region

#Region "Keydown específicos"

#End Region

    Private Sub txtNegocio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNegocio.KeyDown
        Dim sText As String
        Dim oUsuarios As New Class_sisUsuarios
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = oUsuarios.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.txtNegocio.Text = sText
            Case Keys.Enter
                If txtLEN(Me.txtNegocio.Text) = False Then
                    Me.lblNombreNegocio.Text = "" : GoTo Buscar : Exit Sub
                End If

                oUsuarios = New Class_sisUsuarios(CInt(Me.txtNegocio.Text))
                If oUsuarios.Existe = False Then
                    Me.lblNombreNegocio.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblNombreNegocio.Text = oUsuarios.Nombre_Usuario

                txtTAB(e)
        End Select
    End Sub

    Private Sub btnAgregarNegociante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarNegociante.Click
        Dim Child As New Catalogo_Negociantes_Cxc
        Child.sCodigoCliente = sCodigoCliente
        Child.sEstado = "NUEVO"
        Child.Cambia_Estado()
        Child.ShowDialog()
        DesplegarNombreNegociante()
        Me.cboNombreNegociante.SelectedValue = Child.iCodigoNegociante
        Child.Dispose()

    End Sub

    Private Sub btnEdiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdiar.Click
        Dim Child As New Catalogo_Negociantes_Cxc
        If txtLEN(Me.cboNombreNegociante.Text) = True Then
            Child.iCodigoNegociante = CInt(valorNumerico(Me.cboNombreNegociante.SelectedValue.ToString))
            Child.sCodigoCliente = sCodigoCliente
            Child.sEstado = "EDICION"
            Child.Cambia_Estado()
            Child.ShowDialog()
            DesplegarNombreNegociante()
            Me.cboNombreNegociante.SelectedValue = Child.iCodigoNegociante
            Child.Dispose()
        End If
    End Sub

    Private Sub txtSeguimiento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSeguimiento.KeyDown, DtpHora.KeyDown, DtpFecha.KeyDown, cboTipoAcuerdo.KeyDown, cboNombreNegociante.KeyDown, cbocontactadoPor.KeyDown
        txtTAB(e)
    End Sub

    Private Sub txtSeguimiento_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSeguimiento.KeyPress, DtpHora.KeyPress, DtpFecha.KeyPress, cboTipoAcuerdo.KeyPress, cboNombreNegociante.KeyPress, cbocontactadoPor.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Grabar_Seguimiento() = True Then
            Me.Close()
        End If
    End Sub

    Private Function Grabar_Seguimiento() As Boolean
        Dim Grabado As Boolean = False, dfecha As Date
        Dim oSeguimientos As New Class_CXC_Seguimientos
        Try
            If txtLEN(Me.txtNegocio.Text) = False Then
                MsgBox("Asígne el usuario que negocio.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtNegocio.Focus()
                Exit Function
            End If

            If txtLEN(Me.txtSeguimiento.Text) = False Then
                MsgBox("Asígne el seguimiento de la negociación.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtSeguimiento.Focus()
                Exit Function
            End If

            If txtLEN(Me.cboNombreNegociante.Text) = False Then
                MsgBox("Asígne el negociante.", MsgBoxStyle.Exclamation, Me.Text)
                Me.cboNombreNegociante.Focus()
                Exit Function
            End If

            dfecha = CDate(Format(Me.DtpFecha.Value, "dd/MM/yyyy ") + Format(Me.DtpHora.Value, "hh:mm"))

            If dfecha < CDate(Format(Now, "dd/MM/yyyy hh:mm")) Then
                MsgBox("La fecha y hora deben de ser mayores a la actual.", MsgBoxStyle.Exclamation, Me.Text)
                Me.DtpFecha.Focus()
                Exit Function
            End If

            With Me.oSeguimientos
                .FECHA = dfecha
                .SEGUIMIENTO = Me.txtSeguimiento.Text.ToUpper
                .CODIGO_USUARIO = CInt(Me.txtNegocio.Text)
                .CODIGO_NEGOCIANTE = CInt(Me.cboNombreNegociante.SelectedValue.ToString)
                .CONTACTADO_POR = Me.cbocontactadoPor.Text
                .CODIGO_TIPO_ACUERDO = CInt(Me.cboTipoAcuerdo.SelectedValue.ToString)
                .CODIGO_CLIENTE = Me.sCodigoCliente

                If .Insertar() = False Then
                    Exit Function
                End If

                MsgBox("Seguimiento Grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
                Grabar_Seguimiento = True

            End With
        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        Finally

        End Try
    End Function

    Private Sub txtNegocio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNegocio.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtNegocio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNegocio.TextChanged

    End Sub
End Class