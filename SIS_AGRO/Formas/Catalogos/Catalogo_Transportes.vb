Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Catalogo_transportes
    Private oTransportes As New Class_CatTransportes

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

#End Region

#Region "Propiedades"

#End Region

#Region "Constructor y destructor"
    'Inicializa al objeto.
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Try
            Me.msgElemento = "Transporte"
            Me.msgElementos = "Transportes "
            Me.Run = False
            'Me.lstbElementos.ContextMenuStrip = Me.cMenuStripAccion
            Estado = enumEstados.CONSULTA
            Me.DesplegarElementos()
            Me.Cambia_Estado()
            Me.CboEstatus.Text = "A"
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
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Estado = enumEstados.NUEVO
        Me.Cambia_Estado()

        Me.TxtCodTransporte.Text = Me.oTransportes.CodigoSiguiente
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del " & Me.msgElemento & " : " & Me.TxtCodTransporte.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el " & Me.msgElemento & " : " & Me.TxtCodTransporte.Text
        End Select
        sMsg = "Deseas " & sMsg & " ?"
        If MsgBox(sMsg, CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle)) = MsgBoxResult.Yes Then
            Me.Grabar_Elemento()
        End If
    End Sub

    Private Sub tsbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
        Me.Estado = enumEstados.CONSULTA
        Me.Cambia_Estado()
        Me.Refrescar()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbImprimirListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirListado.Click
        Dim oElementos As New Class_CatTransportes
        oElementos.Imprimir_Listado()
        oElementos = Nothing
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
                Me.tssLabelEstado.Text = "Agregando nuevo " & Me.msgElemento
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtCodTransporte.Enabled = False
                Me.TxtLinea.Enabled = True
                Me.TxtMarca.Enabled = True
                Me.txtModelo.Enabled = True
                Me.txtPlaca.Enabled = True
                Me.TxtSerie.Enabled = True
                Me.txtScac.Enabled = True
                Me.TxtFda.Enabled = True
                Me.CboEstatus.Enabled = False
                Me.InicializaElemento()

            Case enumEstados.EDICION
                Me.gBoxInformacion.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Edición"
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtCodTransporte.Enabled = False
                Me.TxtLinea.Enabled = True
                Me.TxtMarca.Enabled = True
                Me.txtModelo.Enabled = True
                Me.txtPlaca.Enabled = True
                Me.TxtSerie.Enabled = True
                Me.txtScac.Enabled = True
                Me.TxtFda.Enabled = True
                Me.CboEstatus.Enabled = True

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
        Me.TxtCodTransporte.Text = ""
        Me.TxtLinea.Text = ""
        Me.lblNombreLineaTransporte.Text = ""
        Me.TxtMarca.Text = ""
        Me.lblMarcaTransporte.Text = ""
        Me.txtModelo.Text = ""
        Me.txtPlaca.Text = ""
        Me.TxtSerie.Text = ""
        Me.txtScac.Text = ""
        Me.TxtFda.Text = ""
        Me.CboEstatus.Text = "A"
    End Sub

    Private Sub DesplegarElementos()
        Dim oElementos As New Class_CatTransportes
        With Me.Grid
            .DataSource = oElementos.ObtenerElementosN
            .Columns("CODIGO_TRANSPORTE").Width = 50
            .Columns("PLACA").Width = 200
        End With

    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As String)
        Dim oElemento As New Class_CatTransportes
        oElemento.CODIGO_TRANSPORTE = iCodigo_Elemento
        Dim oMarca As New Class_CatMarcasTransportes
        Dim oLinea As New Class_CatLineasTransportes

        If oElemento.Consultar Then
            With oElemento
                Me.TxtCodTransporte.Text = .CODIGO_TRANSPORTE.ToString
                Me.TxtLinea.Text = .CODIGO_LINEA_TRANSPORTE.ToString
                oLinea = New Class_CatLineasTransportes
                oLinea.CODIGO_LINEA_TRANSPORTE = .CODIGO_LINEA_TRANSPORTE.ToString
                oLinea.Consultar()
                Me.lblNombreLineaTransporte.Text = oLinea.NOMBRE_LINEA_TRANSPORTE.ToString

                Me.TxtMarca.Text = .CODIGO_MARCA.ToString
                oMarca = New Class_CatMarcasTransportes()
                oMarca.CODIGO_MARCA = .CODIGO_MARCA.ToString
                oMarca.Consultar()
                Me.lblMarcaTransporte.Text = oMarca.MARCA.ToString
                Me.txtModelo.Text = .MODELO.ToString
                Me.txtPlaca.Text = .PLACA.ToString
                Me.TxtSerie.Text = .SERIE.ToString
                Me.txtScac.Text = .SCAC.ToString
                Me.TxtFda.Text = .FDA.ToString

            End With
        End If
        oElemento = Nothing
    End Sub

    Private Sub Grabar_Elemento()
        Dim oElemento As New Class_CatTransportes
        Dim Grabado As Boolean = False

        If txtLEN(Me.TxtLinea.Text) = False Then
            MsgBox("Asígne la linea del transporte", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtLinea.Focus()
            Exit Sub
        End If

        If txtLEN(Me.TxtMarca.Text) = False Then
            MsgBox("Asígne la marca del transporte", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtMarca.Focus()
            Exit Sub
        End If

        If txtLEN(Me.txtPlaca.Text) = False Then
            MsgBox("Asígne la placa del transporte", MsgBoxStyle.Exclamation, Me.Text)
            Me.txtPlaca.Focus()
            Exit Sub
        End If

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                oElemento = New Class_CatTransportes
                Try
                    With oElemento
                        .CODIGO_TRANSPORTE = Me.TxtCodTransporte.Text.ToUpper
                        .CODIGO_LINEA_TRANSPORTE = Me.TxtLinea.Text.ToUpper
                        .CODIGO_MARCA = Me.TxtMarca.Text.ToUpper
                        .MODELO = Me.txtModelo.Text.ToUpper
                        .SERIE = Me.TxtSerie.Text.ToUpper
                        .PLACA = Me.txtPlaca.Text.ToUpper
                        .SCAC = Me.txtScac.Text.ToUpper
                        .FDA = Me.TxtFda.Text.ToUpper
                        .Estatus = Me.CboEstatus.Text.ToUpper

                        Select Case Me.Estado

                            Case enumEstados.NUEVO
                                If .Insertar() Then
                                    Grabado = True
                                    Me.Estado = enumEstados.CONSULTA
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
                        End If

                    End With
                Catch ex As Exception
                    HandleError(Me.Name, "Grabar", ex)
                    Me.Estado = enumEstados.CONSULTA
                    Me.Cambia_Estado()
                Finally
                    oElemento = Nothing
                End Try
        End Select
    End Sub

#End Region

#Region "Eventos de objetos"
#Region "Eventos de la lista de elementos"
    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_TRANSPORTE").Value.ToString)
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellDoubleClick
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub
    'Private Sub lstbElementos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstbElementos.DoubleClick
    '    Me.Estado = enumEstados.EDICION
    '    Me.Cambia_Estado()
    'End Sub

    'Private Sub lstbElementos_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstbElementos.Enter
    '    If Me.lstbElementos.Items.Count > 0 Then
    '        Me.tsbEditar.Enabled = True
    '    End If
    'End Sub

    'Private Sub lstbElementos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstbElementos.LostFocus
    '    Me.tsbEditar.Enabled = False
    'End Sub

    'Private Sub lstbElementos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstbElementos.SelectedIndexChanged
    '    If Me.lstbElementos.SelectedIndex >= 0 Then
    '        Me.LlenaElemento(Me.lstbElementos.SelectedValue.ToString)
    '    End If
    'End Sub
#End Region

#Region " Eventos de TxtFiltro"
    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Dim oElementos As New Class_CatTransportes
        Me.Grid.DataSource = Nothing

        With Me.Grid
            .DataSource = oElementos.ObtenerElementosFiltro(Me.txtFiltro.Text)
            .Columns("CODIGO_TRANSPORTE").Width = 50
            .Columns("PLACA").Width = 200
        End With
    End Sub
    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub
    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        Dim oElementosFiltro As New Class_CatTransportes
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
            Me.Grid.DataSource = Nothing

            With Me.Grid
                .DataSource = oElementosFiltro.ObtenerElementosFiltro(Me.txtFiltro.Text)
                .Columns("CODIGO_TRANSPORTE").Width = 50
                .Columns("PLACA").Width = 200
            End With
        End If
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLinea.KeyPress, _
  TxtMarca.KeyPress, txtModelo.KeyPress, TxtMarca.KeyPress, TxtSerie.KeyPress, txtPlaca.KeyPress, txtScac.KeyPress, TxtFda.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtModelo.KeyDown, txtPlaca.KeyDown, _
    TxtSerie.KeyDown, txtScac.KeyDown
        If e.KeyCode = Keys.Return Then
            Select Case Me.Estado
                Case enumEstados.EDICION
                    SendKeys.Send("{TAB}")
                Case enumEstados.NUEVO
                    SendKeys.Send("{TAB}")
            End Select
        End If
    End Sub

#End Region


#Region "Keydown específicos"
    Private Sub TxtCodTransporte_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodTransporte.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                txtTAB(e)
            Case Keys.Escape
        End Select
    End Sub

    Private Sub txtCodigoPostal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFda.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                If Me.Estado = enumEstados.NUEVO Then
                    tsbGrabar.PerformClick()
                Else
                    txtTAB(e)
                End If
            Case Keys.Escape
                Me.txtScac.Focus()
        End Select
    End Sub

    Private Sub CboEstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboEstatus.KeyDown
        If e.KeyCode = Keys.Return Then
            tsbGrabar.PerformClick()
        End If
    End Sub

    Private Sub TxtLinea_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLinea.KeyDown
        Dim oLineasTransportes As New Class_CatLineasTransportes
        oLineasTransportes = New Class_CatLineasTransportes
        Select Case e.KeyCode
            Case Keys.F6
busqueda_Visual:

                Dim sLineasTransportes As String = oLineasTransportes.BusquedaVisual_PorDescripcion
                If sLineasTransportes.Length > 0 Then
                    Me.TxtLinea.Text = sLineasTransportes
                    sLineasTransportes = Replace(sLineasTransportes, "'", "''")
                    Dim sql As New Class_find("Select CODIGO_LINEA_TRANSPORTE,NOMBRE_LINEA_TRANSPORTE From CAT_LINEAS_TRANSPORTES Where CODIGO_LINEA_TRANSPORTE='" & sLineasTransportes & "' ")
                    Me.TxtLinea.Text = sLineasTransportes
                    Me.lblNombreLineaTransporte.Text = sql.Result2
                    sql = Nothing
                End If
            Case Keys.Return
                Dim sql As New Class_find("Select CODIGO_LINEA_TRANSPORTE,NOMBRE_LINEA_TRANSPORTE From CAT_LINEAS_TRANSPORTES Where CODIGO_LINEA_TRANSPORTE='" & Me.TxtLinea.Text & "' ")
                If sql.Result1 = "" Then
                    GoTo busqueda_Visual
                Else
                    Me.TxtLinea.Text = sql.Result1
                    Me.lblNombreLineaTransporte.Text = sql.Result2
                End If

                sql = Nothing

                txtTAB(e)

        End Select
    End Sub

    Private Sub TxtMarca_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMarca.KeyDown
        Dim oMarcasTransportes As New Class_CatMarcasTransportes
        oMarcasTransportes = New Class_CatMarcasTransportes
        Select Case e.KeyCode
            Case Keys.F6
busqueda_Visual:

                Dim sMarcasTransportes As String = oMarcasTransportes.BusquedaVisual_PorDescripcion
                If sMarcasTransportes.Length > 0 Then
                    Me.TxtMarca.Text = sMarcasTransportes
                    sMarcasTransportes = Replace(sMarcasTransportes, "'", "''")
                    Dim sql As New Class_find("Select CODIGO_MARCA,MARCA_TRANSPORTE From CAT_MARCAS_TRANSPORTES Where CODIGO_MARCA='" & sMarcasTransportes & "' ")
                    Me.TxtMarca.Text = sMarcasTransportes
                    Me.lblMarcaTransporte.Text = sql.Result2
                    sql = Nothing
                End If
            Case Keys.Return
                Dim sql As New Class_find("Select CODIGO_MARCA,MARCA_TRANSPORTE From CAT_MARCAS_TRANSPORTES Where CODIGO_MARCA='" & Me.TxtMarca.Text & "' ")
                If sql.Result1 = "" Then
                    GoTo busqueda_Visual
                Else
                    Me.TxtMarca.Text = sql.Result1
                    Me.lblMarcaTransporte.Text = sql.Result2
                End If

                sql = Nothing

                txtTAB(e)

        End Select
    End Sub
#End Region

#Region "Validating específicos"

#End Region

    Private Sub CboFiltroHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Refrescar()
    End Sub

#End Region

End Class


