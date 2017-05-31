Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Sis_Documentos
    Private oTiposDocumentos As New Class_SisTiposDocumentos

#Region "Campos"

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
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Try
            Me.msgElemento = "Tipo de documento"
            Me.msgElementos = "Tipos de documentos"
            Me.Run = False
            'Me.lstbElementos.ContextMenuStrip = Me.cMenuStripAccion
            Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
            Me.DesplegarElementos()
            Me.CboEstatusFiltro.SelectedIndex = 0
            Me.InicializaElemento()
            Me.Run = True
        Catch ex As Exception
            HandleError(Me.Name, "New", ex)
        End Try

    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub

#End Region

#Region "Opciones"
    'Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.Estado = enumEstados.NUEVO
    '    Me.Cambia_Estado()
    'End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = " grabar las modificaciones del " & Me.msgElemento & " : " & Me.LblCodigoDocumento.Text
        sMsg = "Deseas " & sMsg & " ?"
        If MsgBox(sMsg, CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle)) = MsgBoxResult.Yes Then
            Call Grabar_Elemento()
        End If
    End Sub

    Private Sub tsbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
        Me.Estado = enumEstados.CONSULTA
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbImprimirListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirListado.Click
        'Me.oEtiquetas.Imprimir_Listado()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub Refrescar()

        Me.DesplegarElementos()

    End Sub

    Private Sub Cambia_Estado()
        Select Case Me.Estado
            Case enumEstados.NUEVO

            Case enumEstados.EDICION
                Me.gBoxInformacion.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Editando"
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtFolio.Enabled = True
                Me.TxtNombreFormato.Enabled = True

            Case enumEstados.CONSULTA
                Me.gBoxInformacion.Enabled = False
                Me.gBoxBusquedaRapida.Enabled = True
                Me.tssLabelEstado.Text = "Consultando"
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = False
                Me.tsbCancelar.Enabled = False
                Me.txtFiltro.Focus()
        End Select
        Application.DoEvents()
    End Sub

    Private Sub InicializaElemento()
        Me.LblCodigoDocumento.Text = ""
        Me.LblEstatusDocumento.Text = ""
        Me.LblTipoDocumento.Text = ""
        Me.LblCodigoPlaza.Text = ""
        Me.LblConsecutivo.Text = ""
        Me.LblAsientoRepetitivo.Text = ""
        Me.TxtFolio.Text = ""
        Me.TxtNombreFormato.Text = ""
    End Sub

    Private Sub DesplegarElementos()
        With Me.Grid
            .DataSource = oTiposDocumentos.ObtenerElementosFiltro(Me.txtFiltro.Text, Me.CboEstatusFiltro.Text)
            .Columns("CODIGO_DOCUMENTO").Width = 200
        End With

    End Sub

    Private Sub LlenaElemento(ByVal sCodigo_Elemento As String)
        Me.oTiposDocumentos.CODIGO_DOCUMENTO = sCodigo_Elemento
        If Me.oTiposDocumentos.Consultar Then
            With Me.oTiposDocumentos
                Me.LblCodigoDocumento.Text = .CODIGO_DOCUMENTO.ToString
                Me.LblEstatusDocumento.Text = .ESTATUS_DOCUMENTO.ToString
                Me.LblTipoDocumento.Text = .CODIGO_TIPO_DOCUMENTO.ToString
                Me.LblCodigoPlaza.Text = .CODIGO_PLAZA.ToString
                Me.LblConsecutivo.Text = .CONSECUTIVO.ToString
                Me.LblAsientoRepetitivo.Text = .CODIGO_ASIENTO_REPETITIVO.ToString
                Me.TxtFolio.Text = .FOLIO.ToString
                Me.TxtNombreFormato.Text = .NOMBRE_FORMATO.ToString
            End With
        End If
    End Sub

    Private Sub Grabar_Elemento()
        Dim Grabado As Boolean = False
        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                Try
                    With Me.oTiposDocumentos
                        .CODIGO_DOCUMENTO = Me.LblCodigoDocumento.Text
                        .FOLIO = Me.TxtFolio.Text
                        .NOMBRE_FORMATO = Me.TxtNombreFormato.Text

                        If .Actualizar() Then
                            Grabado = True
                        End If

                        Me.Estado = enumEstados.CONSULTA

                        If Grabado Then
                            MsgBox(Me.msgElemento & " Grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
                            Me.Refrescar()
                            Me.Cambia_Estado()
                        End If
                    End With
                Catch ex As Exception
                    HandleError(Me.Name, "Grabar", ex)
                    Me.Estado = enumEstados.CONSULTA
                    Me.Cambia_Estado()
                Finally

                End Try
        End Select
    End Sub

#End Region

#Region "Eventos de objetos"
#Region "Eventos de la lista de elementos"
    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_DOCUMENTO").Value.ToString)
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellDoubleClick
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub
#End Region

#Region " Eventos de TxtFiltro"
    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Me.DesplegarElementos()
    End Sub
    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub
    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        Me.DesplegarElementos()
    End Sub

    Private Sub CboEstatusFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboEstatusFiltro.SelectedIndexChanged
        Me.DesplegarElementos()
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFolio.KeyPress, TxtNombreFormato.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFolio.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNombreFormato_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombreFormato.KeyDown
        If e.KeyCode = Keys.Return Then
            tsbGrabar.PerformClick()
        End If
    End Sub
#End Region


#Region "Keydown específicos"

#End Region

#Region "Validating específicos"

#End Region

    Private Sub CboFiltroHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Refrescar()
    End Sub

#End Region
End Class