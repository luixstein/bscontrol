Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class Catalogo_Folios_Documentos

#Region "Campos"


#Region "Campos de la tabla"
    Private _CODIGO_TIPO_DOCUMENTO As String
    Private _Folio As String
#End Region

#Region "Campos ligados a la tabla"

#End Region

#Region "Campos públicos"

#End Region

#Region "Campos privados"
    Private Enum enumEstados
        NUEVO
        EDICION
        CONSULTA
    End Enum

    Private Estado As enumEstados
    Private Run As Boolean
    Private msgElemento As String
    Private msgElementos As String
#End Region
#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Nombre_Reporte As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"

#End Region

#Region "Propiedades de campos ligados a la tabla"

#End Region

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

#End Region
#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Catalogo() As String
        Get
            Return Me._Nombre_Catalogo
        End Get
    End Property

    Public Property Nombre_Reporte() As String
        Get
            Return Me._Nombre_Reporte
        End Get
        Set(ByVal value As String)
            Me._Nombre_Reporte = value
        End Set
    End Property

#End Region

#End Region

#Region "Constructor y destructor"
    'Inicializa al objeto.
    Dim Forma As Boolean
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Try

        Catch ex As Exception
            HandleError(Me.Name, "New", ex)
        End Try

    End Sub
    Private Sub cboPLAZAS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCentros.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.Escape

        End Select
    End Sub
    Private Sub cboPLAZAS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        If Forma Then
            DesplegarDocumentos()
        End If
    End Sub
    Private Sub CmbDocumento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbDocumento.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.Escape
                cboCentros.Focus()
        End Select
    End Sub

    Private Sub CmbDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbDocumento.SelectedIndexChanged
        If CmbDocumento.SelectedIndex >= 0 Then
            'TxtFolio.Text = "" & GeneraFolioDocumento(CmbDocumento.SelectedValue.ToString).uno
            TxtFolioNuevo.Text = Strings.Right(TxtFolio.Text, Len(TxtFolio.Text) - (Len(CmbDocumento.SelectedValue.ToString) + 1))
        End If
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub

#End Region

#Region "Opciones"
    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Estado = enumEstados.EDICION
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        sMsg = " cambiar el folio al Documento: " & CmbDocumento.Text & " en el PLAZA: " & cboCentros.Text
        sMsg = "Deseas " & sMsg & " ?"
        If MsgBox(sMsg, CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle)) = MsgBoxResult.Yes Then
            Call Grabar_Elemento()
            MsgBox("El folio fue Modificado con Exito.", MsgBoxStyle.Information, "Modificación de Folios")
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbImprimirListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirListado.Click
        'Dim oElementos As New Class_SisDeportes
        'oElementos.Imprimir_Listado()
        'oElementos = Nothing
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Private Sub InicializaElemento()
        'If CmbDocumento.SelectedIndex >= 0 Then TxtFolio.Text = "" & GeneraFolioDocumento(CmbDocumento.SelectedValue.ToString).uno
    End Sub
    Private Sub Grabar_Elemento()
        Dim Conexion As New SqlConnection, Error1 As String = ""
        Conexion.ConnectionString = Empresa_Sistema.conexion
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_ACTUALIZA_FOLIOS_DOCUMENTOS"
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = "" & CmbDocumento.SelectedValue.ToString()
            sqlParametro = .Parameters.Add("@FOLIO", SqlDbType.NVarChar, 15) : sqlParametro.Value = TxtFolioNuevo.Text
            Try
                Conexion.Open()
                .ExecuteNonQuery()
            Catch ex As Exception
                HandleError("Actualizar Documentos, Error al Actualizar el Folio del Documento", "Grabar", ex)
            Finally
                Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

    End Sub

#End Region

#Region "Eventos de objetos"
#Region "Eventos de la lista de elementos"

#End Region

#Region " Eventos de TxtFiltro"
#End Region

#Region "Eventos Genericos"

    Private Sub CboEstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            tsbGrabar.PerformClick()
        End If
    End Sub
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            Select Case Me.Estado
                Case enumEstados.EDICION
                    SendKeys.Send("{TAB}")
                Case enumEstados.NUEVO
                    tsbGrabar.PerformClick()
            End Select
        End If
    End Sub

    Private Sub txtNumericos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumericos_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim t As TextBox
        t = CType(sender, TextBox)
        If Not IsNumeric(t.Text) Then
            t.Text = Val(t.Text).ToString
        Else
            Me.ErrorProvider.Clear()
        End If
    End Sub
#End Region


#Region "Keydown específicos"

#End Region

#Region "Validating específicos"

#End Region

#End Region
    Private Sub Catalogo_Folios_Documentos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DesplegarPLAZAS()
        Forma = True
        cboCentros.SelectedItem = 0
        DesplegarDocumentos()
    End Sub

    Private Sub DesplegarPLAZAS()
        Dim oPLAZA As New Class_SisPlazas
        'oPLAZA.CODIGO_PLAZA = Usuario.CODIGO_PLAZA
        'cboPLAZAS.DataSource = oPLAZA.ObtenerPLAZASPorUsuario
        cboCentros.DisplayMember = "NOMBRE_PLAZA"
        cboCentros.ValueMember = "CODIGO_PLAZA"
        oPLAZA = Nothing
    End Sub

    Private Sub DesplegarDocumentos()
        CmbDocumento.DataSource = Nothing
        CmbDocumento.Items.Clear()
        Dim oElementos As New Class_CatDocumentos
        With Me.CmbDocumento
            .DisplayMember = "NOMBRE_TIPO_DOCUMENTO"

            .ValueMember = "CODIGO_TIPO_DOCUMENTO"

            Dim dView As New Data.DataView(oElementos.ObtenerCodigosDocumentos("", Me.cboCentros.SelectedValue.ToString, " ESTATUS_EJERCICIO='A'"))
            dView.Sort = "NOMBRE_TIPO_DOCUMENTO"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub TxtFolioNuevo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFolioNuevo.KeyPress
        txtNoBeep(e)
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = CChar("")
        End If
    End Sub
End Class