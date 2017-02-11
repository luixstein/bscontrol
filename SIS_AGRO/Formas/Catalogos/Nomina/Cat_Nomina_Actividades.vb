Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Cat_Nomina_Actividades
    Private oActividad As New Class_CatActividades
    Private _ChildParaGrabar As Boolean

#Region "Campos"

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

    Private _CodigoConcepto As String

    Public Property CodigoConcepto() As String
        Set(ByVal value As String)
            Me._CodigoConcepto = value
        End Set
        Get
            Return Me._CodigoConcepto
        End Get
    End Property

#End Region

#Region "Propiedades"
    Public WriteOnly Property ChildParaGrabar() As Boolean
        Set(ByVal Value As Boolean)
            Me._ChildParaGrabar = Value
        End Set
    End Property
#End Region

#Region "Constructor y destructor"
    'Inicializa al objeto.
    Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Try
            Me.msgElemento = "Actividad"
            Me.msgElementos = "Actividades"
            Me.Run = False
            'Me.lstbElementos.ContextMenuStrip = Me.cMenuStripAccion
            Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
            'Me.DesplegarElementos()

            Me.Run = True
        Catch ex As Exception
            HandleError(Me.Name, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Cat_Nomina_Actividades_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtCodigoConcepto.Text = Me._CodigoConcepto
        Me.InicializaElemento()
        Me.DesplegarElementos()
        If Me._ChildParaGrabar = True Then
            Me.oActividad.CODIGO_CONCEPTO_ACTIVIDAD = Me._CodigoConcepto
            Me.tsbNuevo.PerformClick()
        Else
            Estado = enumEstados.EDICION
            Me.Cambia_Estado()
        End If
    End Sub
#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Estado = enumEstados.NUEVO
        Me.Cambia_Estado()
        'Me.TxtCodigoActividad.Text = Me.oActividad.CodigoSiguiente
        Me.txtCodigoSubActividad.Text = Me.oActividad.CodigoSiguienteSubActividad
        Me.TxtCodigoActividad.Text = Me.txtCodigoSubActividad.Text
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del " & Me.msgElemento & " : " & Me.TxtCodigoActividad.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el " & Me.msgElemento & " : " & Me.TxtCodigoActividad.Text
        End Select
        sMsg = "Deseas " & sMsg & " ?"
        If (CInt(Me.txtCostoJornal.Text)) > 0 Then
            If MsgBox(sMsg, CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle)) = MsgBoxResult.Yes Then
                Me.Grabar_Elemento()
            End If
        Else
            MsgBox("El costo jornal no puede ser menor a 1", MsgBoxStyle.Exclamation)
            Me.txtCostoJornal.Focus()
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
        Me.oActividad.Imprimir_Listado()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub Refrescar()
        Me.DesplegarElementos()
    End Sub

    Private Sub Cambia_Estado()
        Select Case Me.Estado
            Case enumEstados.NUEVO
                Me.gBoxInformacion.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Agregando una nueva " & Me.msgElemento
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtCodigoActividad.Enabled = False
                Me.TxtNombreActividad.Enabled = True
                Me.CboEstatus.Enabled = False
                Me.InicializaElemento()
                Me.TxtCodigoActividad.Focus()

            Case enumEstados.EDICION
                Me.gBoxInformacion.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Edición"
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtCodigoActividad.Enabled = False
                Me.TxtNombreActividad.Enabled = True
                Me.CboEstatus.Enabled = True
                Me.TxtNombreActividad.Focus()

            Case enumEstados.CONSULTA
                Me.gBoxInformacion.Enabled = False
                Me.gBoxBusquedaRapida.Enabled = True
                Me.tssLabelEstado.Text = "Consulta"
                Me.tsbNuevo.Enabled = True
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = False
                Me.tsbCancelar.Enabled = False
                Me.txtFiltro.Focus()
        End Select
        Application.DoEvents()
    End Sub

    Private Sub InicializaElemento()
        Me.TxtCodigoActividad.Text = ""
        Me.TxtNombreActividad.Text = ""
        Me.CboEstatus.Text = "A"""
        Me.txtCodigoSubActividad.Text = ""
        Me.txtCostoJornal.Text = ""
    End Sub

    Private Sub DesplegarElementos()
        With Me.Grid
            .DataSource = Me.oActividad.ObtenerElementosSubActividades(Me.txtCodigoConcepto.Text)
            .Columns("CODIGO_ACTIVIDAD").Width = 120
            .Columns("NOMBRE_ACTIVIDAD").Width = 300
        End With
    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As String)
        'Dim sCodigo As String
        Me.oActividad.CODIGO_ACTIVIDAD = CInt(iCodigo_Elemento)
        If Me.oActividad.Consultar Then
            With Me.oActividad
                'sCodigo = "000" + iCodigo_Elemento
                'Me.TxtCodigoActividad.Text = sCodigo.Substring(Len(sCodigo) - 3).ToString
                Me.TxtNombreActividad.Text = .NOMBRE_ACTIVIDAD.ToString
                Me.CboEstatus.Text = .ESTATUS_ACTIVIDAD.ToString
                Me.txtCodigoConcepto.Text = .CODIGO_CONCEPTO_ACTIVIDAD.ToString
                Me.txtCodigoSubActividad.Text = .CODIGO_SUB_ACTIVIDAD.ToString
                Me.TxtCodigoActividad.Text = .CODIGO_ACTIVIDAD.ToString
                Me.txtCostoJornal.Text = .COSTO_JORNAL.ToString
            End With
        End If
    End Sub

    Private Sub Grabar_Elemento()
        Dim Grabado As Boolean = False

        If txtLEN(Me.TxtNombreActividad.Text) = False Then
            MsgBox("Asigne un nombre a la actividad.", MsgBoxStyle.Exclamation, Me.Name)
            Exit Sub
        End If

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                Me.oActividad = New Class_CatActividades
                Try
                    With Me.oActividad
                        .CODIGO_ACTIVIDAD = CInt(Me.TxtCodigoActividad.Text)
                        .NOMBRE_ACTIVIDAD = Me.TxtNombreActividad.Text
                        .ESTATUS_ACTIVIDAD = Me.CboEstatus.Text
                        .CODIGO_CONCEPTO_ACTIVIDAD = Me.txtCodigoConcepto.Text
                        .CODIGO_SUB_ACTIVIDAD = Me.txtCodigoSubActividad.Text
                        If Len(Me.txtCostoJornal.Text) > 0 Then
                            .COSTO_JORNAL = valorNumerico(Me.txtCostoJornal.Text)
                        Else
                            .COSTO_JORNAL = 0
                        End If


                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                If .Insertar() Then
                                    Grabado = True
                                    Me.Estado = enumEstados.NUEVO
                                End If
                            Case enumEstados.EDICION
                                If .Actualizar() Then
                                    Grabado = True
                                    Me.Estado = enumEstados.CONSULTA
                                End If
                        End Select

                        If Grabado Then
                            MsgBox(Me.msgElemento & " Grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
                            Me.Refrescar()
                            Me.Cambia_Estado()
                            'If Me.Estado = enumEstados.NUEVO Then
                            '    Me.TxtCodigoActividad.Text = .CodigoSiguienteSubActividad.ToString
                            'Else
                            '    Me.lstbElementos.SelectedValue = .CODIGO_ACTIVIDAD
                            'End If
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
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_ACTIVIDAD").Value.ToString)
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellDoubleClick
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub
    'Private Sub lstbElementos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Me.Estado = enumEstados.EDICION
    '    Me.Cambia_Estado()
    'End Sub

    'Private Sub lstbElementos_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.lstbElementos.Items.Count > 0 Then
    '        Me.tsbEditar.Enabled = True
    '    End If
    'End Sub

    'Private Sub lstbElementos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Me.tsbEditar.Enabled = False
    'End Sub

    'Private Sub lstbElementos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.lstbElementos.SelectedIndex >= 0 Then
    '        Me.LlenaElemento(Me.lstbElementos.SelectedValue.ToString)
    '    End If
    'End Sub
#End Region

#Region " Eventos de TxtFiltro"
    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Dim oElementos As New Class_CatActividades

        Me.Grid.DataSource = Nothing

        With Me.Grid
            .DataSource = oElementos.ObtenerElementosFiltro(Me.txtFiltro.Text)
            .Columns("CODIGO_ACTIVIDAD").Width = 120
            .Columns("NOMBRE_ACTIVIDAD").Width = 300
        End With
    End Sub

    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        Dim oElementosFiltro As New Class_CatActividades
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
            Me.Grid.DataSource = Nothing

            With Me.Grid
                .DataSource = oElementosFiltro.ObtenerElementosFiltro(Me.txtFiltro.Text)
                .Columns("CODIGO_ACTIVIDAD").Width = 120
                .Columns("NOMBRE_ACTIVIDAD").Width = 300
            End With
        End If
    End Sub
#End Region

#Region "Eventos Genericos"

    Private Sub CboEstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboEstatus.KeyDown
        If e.KeyCode = Keys.Return Then
            tsbGrabar.PerformClick()
        End If
    End Sub

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboEstatus.KeyPress, TxtNombreActividad.KeyPress, txtCostoJornal.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombreActividad.KeyDown
        If e.KeyCode = Keys.Return Then
            Select Case Me.Estado
                Case enumEstados.EDICION
                    SendKeys.Send("{TAB}")
                Case enumEstados.NUEVO
                    SendKeys.Send("{TAB}")
            End Select
        End If
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoActividad.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosDecimalesKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCostoJornal.KeyPress
        Dim textBox As TextBox
        textBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, textBox.Text)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumericos_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim textBox As TextBox
        textBox = CType(sender, TextBox)
        If Not IsNumeric(textBox.Text) Then
            textBox.Text = Val(textBox.Text).ToString
        Else
            'Me.ErrorProvider.Clear()
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