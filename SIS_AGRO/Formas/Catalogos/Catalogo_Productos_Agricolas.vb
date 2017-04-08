Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Catalogo_Productos_Agricolas

    Dim oFormulasEmpaque As New Class_CatProductosAgricolasFormulasEmpaque
    Dim oCodigoEmbarque As Class_CatArticulos

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

    Private igyClave As Short = 1
    Private igyUnidad As Short = 2
    Private igyCodigoEmpaque As Short = 3
    Private igyNombreArticulo As Short = 4
    Private igyCantidad As Short = 5
    Private igyEditable As Short = 6
    Private igyEsMillar As Short = 7
    Private igyCostoUnitario As Short = 8
    Private igyUnidadVenta As Short = 9

#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Nombre_Reporte As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
#End Region

#Region "Propiedades"

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
        InitializeComponent()
        Try
            Me.msgElemento = "Articulo"
            Me.msgElementos = "Articulos"
            Me.Run = False
            Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
            Me.Run = True
        Catch ex As Exception
            HandleError(Me.Name, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Try
            Dim dTabla As DataTable

            Me.Estado = enumEstados.NUEVO
            Me.Cambia_Estado()
            Me.InicializaCombos()
            Me.InicializaGrid()

            dTabla = Me.oFormulasEmpaque.ObtenerDetalle(Me.TxtCodArticulo.Text)
            Me.Grid.Rows = 1
            For Each dRow As DataRow In dTabla.Rows
                Me.Grid.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) & dRow(5).ToString & Chr(9) & dRow(6).ToString & Chr(9))
            Next
            Me.FormateaGrid()
        Catch ex As Exception
            HandleError(Me.Name, "tsbNuevo_Click", ex)
        End Try
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del " & Me.msgElemento & " : " & Me.TxtCodArticulo.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el " & Me.msgElemento & " : " & Me.TxtCodArticulo.Text
        End Select
        sMsg = "Deseas " & sMsg & " ?"
        If MsgBox(sMsg, CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle)) = MsgBoxResult.Yes Then
            Call Grabar_Elemento()
        End If
    End Sub

    Private Sub tsbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
        Me.Estado = enumEstados.CONSULTA
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEliminar.Click
        Me.Eliminar_Elemento()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbImprimirListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirListado.Click
        Dim oElementos As New Class_CatArticulos
        oElementos.Nombre_Reporte = "RPT_CATALOGO_PRODUCTOS"
        oElementos.Imprimir_Listado()
        oElementos = Nothing
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Private Sub Catalogo_Articulos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.DesplegarCultivos()
            Me.DesplegarTamaños()
            Me.DesplegarEnvases()
            Me.DesplegarEtiquetas()
            Me.DesplegarFamilias()

            Me.InicializaElemento()
            Me.DesplegarElementos()
            'Me.InicializaGrid()
        Catch ex As Exception
            HandleError(Me.Name, "Catalogo_Articulos_Load", ex)
        End Try
    End Sub

    Private Sub Refrescar()
        Me.DesplegarElementos()
    End Sub

    Private Sub Cambia_Estado()
        Try
            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.gBoxInformacion.Enabled = True
                    Me.gBoxBusquedaRapida.Enabled = False
                    Me.tssLabelEstado.Text = "Agregando nuevo " & Me.msgElemento
                    Me.tsbNuevo.Enabled = False
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = True

                    Me.cboUnidadVenta.Enabled = True
                    Me.CboEstatus.Enabled = False
                    Me.TxtPrecio.Enabled = True
                    Me.TxtPeso.Enabled = True
                    Me.cboCultivo.Enabled = True
                    Me.cboEnvase.Enabled = True
                    Me.cboTamaño.Enabled = True
                    Me.cboEtiqueta.Enabled = True
                    Me.chkInventariable.Enabled = True
                    Me.Grid.Locked = False

                    Me.InicializaElemento()

                Case enumEstados.EDICION
                    Me.gBoxInformacion.Enabled = True
                    Me.gBoxBusquedaRapida.Enabled = False
                    Me.tssLabelEstado.Text = "Edición"
                    Me.tsbNuevo.Enabled = False
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = True
                    Me.tsbCancelar.Enabled = True

                    Me.CboEstatus.Enabled = True
                    Me.cboUnidadVenta.Enabled = False
                    Me.TxtPrecio.Enabled = True
                    Me.TxtPeso.Enabled = True
                    Me.cboCultivo.Enabled = False
                    Me.cboEnvase.Enabled = False
                    Me.cboTamaño.Enabled = False
                    Me.cboEtiqueta.Enabled = False
                    Me.chkInventariable.Enabled = True
                    Me.Grid.Locked = False

                Case enumEstados.CONSULTA
                    Me.gBoxInformacion.Enabled = False
                    Me.gBoxBusquedaRapida.Enabled = True
                    Me.tssLabelEstado.Text = "Consulta"
                    Me.tsbNuevo.Enabled = True
                    Me.tsbEditar.Enabled = False
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False

                    Me.cboCultivo.Enabled = False
                    Me.cboEnvase.Enabled = False
                    Me.cboTamaño.Enabled = False
                    Me.cboEtiqueta.Enabled = False
                    Me.cboUnidadVenta.Enabled = False
                    Me.Grid.Locked = True
                    Me.txtFiltro.Focus()
                    Me.CboEstatusFiltro.SelectedIndex = 0
            End Select
            Application.DoEvents()
        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Sub InicializaElemento()
        Try
            Me.TxtCodArticulo.Text = ""
            Me.TxtDescripcion.Text = ""
            Me.CboEstatus.SelectedIndex = 0
            Me.TxtPrecio.Text = "0.00"
            Me.TxtPeso.Text = "0.00"
            Me.TxtRangoPiezas.Text = ""
            Me.chkInventariable.Checked = True

            Me.InicializaGrid()

            'Me.FormateaGrid()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaElemento", ex)
        End Try
    End Sub

    Private Sub InicializaCombos()
        Try
            Me.cboCultivo.SelectedIndex = -1
            Me.cboTamaño.SelectedIndex = -1
            Me.cboEnvase.SelectedIndex = -1
            Me.cboEtiqueta.SelectedIndex = -1

            Dim sql As New Class_find("SELECT CODIGO_FAMILIA_PRODUCTO_AGRICOLA FROM SIS_EMPRESA ")
            Me.CboFamilia.SelectedValue = sql.Result1
            sql = Nothing
        Catch ex As Exception
            HandleError(Me.Name, "InicializaCombos", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Try
            Me.Grid.DataSource = Nothing
            FG_Grid_Limpiar(Me.Grid)

            Me.Grid.Rows = 1
            Me.Grid.Cols = 10

            Me.FormateaGrid()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            Me.Grid.Column(Me.igyClave).Locked = False

            Me.Grid.Column(Me.igyClave).Width = 140
            Me.Grid.Column(Me.igyCodigoEmpaque).Width = 140
            Me.Grid.Column(Me.igyNombreArticulo).Width = 400
            Me.Grid.Column(Me.igyCantidad).Width = 100
            Me.Grid.Column(Me.igyUnidad).Width = 100
            Me.Grid.Column(Me.igyEditable).Width = 100
            Me.Grid.Column(Me.igyEsMillar).Width = 100
            Me.Grid.Column(Me.igyCostoUnitario).Width = 100
            Me.Grid.Column(Me.igyUnidadVenta).Width = 70

            Me.Grid.Cell(0, Me.igyClave).Text = "Clave"
            Me.Grid.Cell(0, Me.igyCodigoEmpaque).Text = "Codigo de empaque"
            Me.Grid.Cell(0, Me.igyNombreArticulo).Text = "Descripción de material de empaque"
            Me.Grid.Cell(0, Me.igyCantidad).Text = "Cantidad"
            Me.Grid.Cell(0, Me.igyUnidad).Text = "Unidad base"
            Me.Grid.Cell(0, Me.igyEditable).Text = "Editable"
            Me.Grid.Cell(0, Me.igyCostoUnitario).Text = "Costo uni"
            Me.Grid.Cell(0, Me.igyUnidadVenta).Text = "Unidad"

            Me.Grid.Column(Me.igyCantidad).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyCantidad).DecimalLength = 3
            Me.Grid.Column(Me.igyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyCostoUnitario).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyCostoUnitario).DecimalLength = 4
            Me.Grid.Column(Me.igyCostoUnitario).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyClave).Visible = True
            Me.Grid.Column(Me.igyCodigoEmpaque).Visible = True
            Me.Grid.Column(Me.igyNombreArticulo).Visible = True
            Me.Grid.Column(Me.igyCantidad).Visible = True
            Me.Grid.Column(Me.igyUnidad).Visible = True
            Me.Grid.Column(Me.igyEditable).Visible = False
            Me.Grid.Column(Me.igyEsMillar).Visible = False
            Me.Grid.Column(Me.igyCostoUnitario).Visible = False
            Me.Grid.Column(Me.igyUnidadVenta).Visible = True

            Dim i As Integer
            For i = 1 To Me.Grid.Rows - 1
                If Me.Grid.Cell(i, Me.igyEditable).Text = "0" Then
                    Me.Grid.Cell(i, Me.igyCantidad).Locked = True
                End If
            Next i
            Me.Grid.Column(Me.igyClave).Locked = True
            Me.Grid.Column(Me.igyNombreArticulo).Locked = True
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

    Private Sub DesplegarCultivos()
        Try
            Dim oElementos As New Class_CatCultivos
            With Me.cboCultivo
                .DisplayMember = "NOMBRE_CULTIVO"
                .ValueMember = "CODIGO_CULTIVO"

                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_CULTIVO"
                .DataSource = dView
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarCultivos", ex)
        End Try
    End Sub

    Private Sub DesplegarTamaños()
        Try
            Dim oElementos As New Class_CatTamaños
            With Me.cboTamaño
                .DisplayMember = "NOMBRE_TAMAÑO"
                .ValueMember = "CODIGO_TAMAÑO"

                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_TAMAÑO"
                .DataSource = dView
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarTamaños", ex)
        End Try
    End Sub

    Private Sub DesplegarEnvases()
        Try
            Dim oElementos As New Class_CatEnvases
            With Me.cboEnvase
                .DisplayMember = "NOMBRE_ENVASE"
                .ValueMember = "CODIGO_ENVASE"

                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_ENVASE"
                .DataSource = dView
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarEnvases", ex)
        End Try
    End Sub

    Private Sub DesplegarEtiquetas()
        Try
            Dim oElementos As New Class_CatEtiquetas
            With Me.cboEtiqueta
                .DisplayMember = "NOMBRE_ETIQUETA"
                .ValueMember = "CODIGO_ETIQUETA"

                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_ETIQUETA"
                .DataSource = dView
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarEtiquetas", ex)
        End Try
    End Sub

    Private Sub DesplegarFamilias()
        Try
            Dim oElementos As New Class_CatFamilias
            With Me.CboFamilia
                .DisplayMember = "Nombre_Familia"
                .ValueMember = "codigo_Familia"

                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "Nombre_Familia"
                .DataSource = dView
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarFamilias", ex)
        End Try
    End Sub

    Private Sub DesplegarElementos()
        Try
            Dim oElementos As New Class_CatArticulos
            With Me.Grid2
                .DataSource = oElementos.ObtenerElementosFiltroProductosAgricolas(Me.txtFiltro.Text, Me.CboEstatusFiltro.Text)
                .Columns("CODIGO_ARTICULO").Width = 70
                .Columns("DESCRIPCION").Width = 450
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarElementos", ex)
        End Try
    End Sub

    Private Sub LlenaElemento(ByVal iCodigo_Elemento As String)
        Try
            Dim oElemento As New Class_CatArticulos
            Dim dTabla As DataTable
            Me.oFormulasEmpaque = New Class_CatProductosAgricolasFormulasEmpaque()

            Me.InicializaElemento()

            oElemento.CODIGO_ARTICULO = iCodigo_Elemento
            If oElemento.Consultar Then
                With oElemento
                    Me.TxtCodArticulo.Text = .CODIGO_ARTICULO.ToString
                    Me.TxtDescripcion.Text = .DESCRIPCION.ToString
                    If .Estatus = "A" Then
                        Me.CboEstatus.SelectedIndex = 0
                    Else
                        Me.CboEstatus.SelectedIndex = 1
                    End If
                    Me.TxtPrecio.Text = .PRECIO.ToString
                    Me.TxtPeso.Text = .PESO.ToString
                    Me.TxtCantidadBultosXPalet.Text = .CANTIDAD_BULTOS_POR_PALET.ToString
                    Me.CboFamilia.SelectedValue = .CODIGO_FAMILIA
                    Me.cboCultivo.SelectedValue = .CODIGO_CULTIVO
                    Me.cboTamaño.SelectedValue = .CODIGO_TAMAÑO
                    Me.cboEnvase.SelectedValue = .CODIGO_ENVASE
                    Me.cboEtiqueta.SelectedValue = .CODIGO_ETIQUETA
                    Me.cboUnidadVenta.Text = .UNIDAD_VENTA
                    Me.TxtRangoPiezas.Text = .RANGO_PIEZAS
                    Me.chkInventariable.Checked = CBool(.INVENTARIABLE.ToString)
                End With

                'Me.Grid.DataSource = Me.oFormulasEmpaque.ObtenerDetalle(Me.TxtCodArticulo.Text)

                'Private igyClave As Short = 1
                'Private igyUnidad As Short = 2
                'Private igyCodigoEmpaque As Short = 3
                'Private igyNombreArticulo As Short = 4
                'Private igyCantidad As Short = 5
                'Private igyEditable As Short = 6
                'Private igyEsMillar As Short = 7
                'Private igyCostoUnitario As Short = 8
                'Private igyUnidadVenta As Short = 9

                dTabla = Me.oFormulasEmpaque.ObtenerDetalle(Me.TxtCodArticulo.Text) '.Rows.Count
                Me.Grid.Rows = 1
                For Each dRow As DataRow In dTabla.Rows
                    Me.Grid.AddItem(dRow("CLAVE").ToString & Chr(9) & dRow("UNIDAD_BASE").ToString & Chr(9) & dRow("CODIGO_EMPAQUE").ToString & Chr(9) & dRow("DESCRIPCION").ToString & Chr(9) & dRow("CANTIDAD").ToString & Chr(9) & _
                                    dRow("EDITABLE").ToString & Chr(9) & dRow("ES_POR_MILLARES").ToString & Chr(9) & dRow("COSTO_UNITARIO").ToString & Chr(9) & dRow("UNIDAD_VENTA").ToString & Chr(9))
                Next

                'Me.Validar()
                Me.FormateaGrid()

            End If
            oElemento = Nothing
        Catch ex As Exception
            HandleError(Me.Name, "LlenaElemento", ex)
        End Try
    End Sub

    Private Sub Grabar_Elemento()
        Dim oElemento As New Class_CatArticulos
        Dim Grabado As Boolean = False
        Dim i As Integer

        If Usuario.PERMISO_CAT_ARTICULOS = "0" Then
            MsgBox("No tiene permiso para realizar este movimiento.", MsgBoxStyle.Exclamation, Me.Name)
            Me.Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
            Exit Sub
        End If

        If txtLEN(Me.cboCultivo.Text) = False Then
            MsgBox("Asígne un cultivo", MsgBoxStyle.Exclamation, Me.Text)
            Me.cboCultivo.Focus()
            Exit Sub
        End If

        If txtLEN(Me.cboTamaño.Text) = False Then
            MsgBox("Asígne un tamaño", MsgBoxStyle.Exclamation, Me.Text)
            Me.cboTamaño.Focus()
            Exit Sub
        End If

        If txtLEN(Me.cboEnvase.Text) = False Then
            MsgBox("Asígne un envase", MsgBoxStyle.Exclamation, Me.Text)
            Me.cboEnvase.Focus()
            Exit Sub
        End If

        If txtLEN(Me.cboEtiqueta.Text) = False Then
            MsgBox("Asígne una etiqueta", MsgBoxStyle.Exclamation, Me.Text)
            Me.cboEtiqueta.Focus()
            Exit Sub
        End If

        If txtLEN(Me.CboFamilia.Text) = False Then
            MsgBox("Asígne una familia", MsgBoxStyle.Exclamation, Me.Text)
            Me.CboFamilia.Focus()
            Exit Sub
        End If

        If txtLEN(Me.TxtPeso.Text) = False Then
            MsgBox("Asígne el peso que se usará para convertir la cantidad y precio facturado en bultos.", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtPeso.Focus()
            Exit Sub
        Else
            If CInt(Me.TxtPeso.Text) <= 0 Then
                MsgBox("Asígne el peso que se usará para convertir la cantidad y precio facturado en bultos.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtPeso.Focus()
                Exit Sub
            End If
        End If

        If txtLEN(Me.cboCultivo.Text) = True And Me.cboTamaño.SelectedValue.ToString <> Empresa_Sistema.CODIGO_TAMAÑO_REZAGA.ToString And Me.cboUnidadVenta.Text = "KG" Then
            If valorNumerico(Me.TxtPeso.Text) <= 0 Then
                MsgBox("Asígne el peso que se usará para convertir la cantidad y precio facturado en bultos.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtPeso.Focus()
                Exit Sub
            End If
        End If

        For i = 1 To Me.Grid.Rows - 1
            If txtLEN(Me.Grid.Cell(i, Me.igyCodigoEmpaque).Text) = True Then
                If valorNumerico(Me.Grid.Cell(i, Me.igyCantidad).Text) = 0 Then
                    MsgBox("La cantidad debe ser mayor a 0, Favor de modificarla.", MsgBoxStyle.Exclamation, Me.Text)
                    Me.Grid.Cell(i, Me.igyCantidad).SetFocus()
                    Exit Sub
                End If
            End If
        Next

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                oElemento = New Class_CatArticulos
                Try
                    With oElemento
                        .CODIGO_ARTICULO = Me.TxtCodArticulo.Text
                        .DESCRIPCION = Me.TxtDescripcion.Text
                        .Estatus = Strings.Left(Me.CboEstatus.Text, 1)
                        .UNIDAD_VENTA = Me.cboUnidadVenta.Text '"BTO" 
                        .PROTEGIDO = "0"
                        .INVENTARIABLE = "0"
                        .TIENE_IMPUESTO = "0"
                        .CODIGO_LINEA = "0001"
                        .CODIGO_FAMILIA = Me.CboFamilia.SelectedValue.ToString
                        .PRECIO = Convert.ToDecimal(Me.TxtPrecio.Text)
                        .PESO = Convert.ToDecimal(Me.TxtPeso.Text)
                        .CANTIDAD_BULTOS_POR_PALET = CInt(valorNumerico(Me.TxtCantidadBultosXPalet.Text))
                        .CODIGO_CULTIVO = Me.cboCultivo.SelectedValue.ToString
                        .CODIGO_TAMAÑO = Me.cboTamaño.SelectedValue.ToString
                        .CODIGO_ENVASE = Me.cboEnvase.SelectedValue.ToString
                        .CODIGO_ETIQUETA = Me.cboEtiqueta.SelectedValue.ToString
                        .RANGO_PIEZAS = Me.TxtRangoPiezas.Text
                        .INVENTARIABLE = Convert.ToInt32(Me.chkInventariable.Checked).ToString

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

                        Me.GrabarFormulas()

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

    Private Function GrabarFormulas() As Boolean
        Dim i As Integer

        Try
            If Me.EliminaFormulas = False Then
                Exit Function
            End If

            With Me.oFormulasEmpaque
                'SE GRABA EL REGISTRO
                For i = 1 To Me.Grid.Rows - 1
                    'If txtLEN(Me.Grid.Cell(i, Me.igyCodigoEmpaque).Text) = True Then

                    'If valorNumerico(Me.Grid.Cell(i, Me.igyCantidad).Text) < 0 Then
                    ' MsgBox("La cantidad debe ser mayor a 0, Favor de modificarla.", MsgBoxStyle.Exclamation, Me.Text)
                    ' Me.Grid.Cell(i, Me.igyCantidad).SetFocus()
                    ' Exit Function
                    ' End If

                    .CODIGO_PRODUCTO = Me.TxtCodArticulo.Text
                    .CLAVE = Me.Grid.Cell(i, Me.igyClave).Text.ToUpper
                    .CODIGO_EMPAQUE = Me.Grid.Cell(i, Me.igyCodigoEmpaque).Text.ToUpper
                    .CANTIDAD = valorNumerico(Me.Grid.Cell(i, Me.igyCantidad).Text)
                    .UNIDAD_BASE = Me.Grid.Cell(i, Me.igyUnidad).Text
                    .COSTO_UNITARIO = valorNumerico(Me.Grid.Cell(i, Me.igyCostoUnitario).Text)

                    If .Insertar() = False Then
                        MsgBox("Error al tratar de insertar el detalle de la fórmula de empaque.", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                    End If
                    'End If
                Next

                GrabarFormulas = True
                If GrabarFormulas = True Then
                    'MsgBox("Las formulas del producto " & Me.TxtDescripcion.Text & " han sido grabados satisfactoriamente. ", MsgBoxStyle.Information, Me.Text)
                End If

            End With
        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try

    End Function

    Private Sub GeneraCodigoDescripcion()
        If Me.cboCultivo.SelectedIndex >= 0 And Me.cboTamaño.SelectedIndex >= 0 And Me.cboEnvase.SelectedIndex >= 0 And Me.cboEtiqueta.SelectedIndex >= 0 Then
            Me.TxtCodArticulo.Text = Me.cboCultivo.SelectedValue.ToString + Me.cboTamaño.SelectedValue.ToString + Me.cboEnvase.SelectedValue.ToString + Me.cboEtiqueta.SelectedValue.ToString
            Me.TxtDescripcion.Text = Me.cboCultivo.Text + " " + Me.cboTamaño.Text + " " + Me.cboEnvase.Text + " " + Me.cboEtiqueta.Text
        End If
    End Sub

    Private Sub Eliminar_Elemento()
        Try
            If Usuario.PERMISO_CAT_ARTICULOS = "0" Then
                MsgBox("No tiene permiso para realizar este movimiento.", MsgBoxStyle.Exclamation, Me.Name)
                Me.Estado = enumEstados.CONSULTA
                Me.Cambia_Estado()
                Exit Sub
            End If

            If MsgBox("Desea Eliminar este producto agrícola", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
                Dim oElemento As New Class_CatArticulos
                oElemento.CODIGO_ARTICULO = Me.TxtCodArticulo.Text

                If EliminaFormulas() = False Then
                    Exit Sub
                End If

                If oElemento.Eliminar Then
                    MsgBox("El producto agricola fue Eliminado con Exito", MsgBoxStyle.Information)
                Else
                    MsgBox("El producto agricola no puede ser Eliminado, es probable que tenga Movimientos", MsgBoxStyle.Exclamation)
                End If
            End If
            Me.Refrescar()
            Me.Cambia_Estado()
        Catch ex As Exception
            HandleError(Me.Name, "Eliminar_Elemento", ex)
        End Try
    End Sub

    Private Function EliminaFormulas() As Boolean
        Dim bResultado As Boolean = False
        Try
            With Me.oFormulasEmpaque

                .CODIGO_PRODUCTO = Me.TxtCodArticulo.Text
                If .Eliminar() = False Then
                    MsgBox("Error al tratar de eliminar las formulas de empaque.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                End If
                bResultado = True
            End With
        Catch ex As Exception
            HandleError(Me.Name, "EliminaFormulas", ex)
        End Try
        Return bResultado
    End Function

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim Columna As Integer, Renglon As Integer, iMillar As String
            Dim StrCod As String, dCantidad As Double, sCodigoEmpaque As String, iEditable As Integer

            Columna = Me.Grid.Selection.FirstCol
            Renglon = Me.Grid.Selection.FirstRow
            StrCod = Me.Grid.Cell(Renglon, Me.igyClave).Text

            sCodigoEmpaque = Me.Grid.Cell(Renglon, Me.igyCodigoEmpaque).Text
            dCantidad = valorNumerico(Me.Grid.Cell(Renglon, Me.igyCantidad).Text)
            iEditable = CInt(valorNumerico(Me.Grid.Cell(Renglon, Me.igyEditable).Text))
            iMillar = Me.Grid.Cell(Renglon, Me.igyEsMillar).Text

            Select Case e.KeyCode
                Case Keys.Enter
                    Select Case Columna

                        Case Me.igyCodigoEmpaque
                            If Me.Estado = enumEstados.CONSULTA Then
                                Exit Sub
                            End If
LlenaLinea:
                            oCodigoEmbarque = New Class_CatArticulos(sCodigoEmpaque)
                            If oCodigoEmbarque.Existe = False Then
                                GoTo Busca
                            End If

                            'Dim sql As New Class_find("SELECT CODIGO_ARTICULO, FROM CAT_ARTICULOS " & _
                            '"Where CODIGO_ARTICULO='" & sCodigoEmpaque & "' AND CODIGO_FAMILIA='" & Empresa_Sistema.CODIGO_FAMILIA_MATERIA_EMPAQUE.ToString & "'")
                            If oCodigoEmbarque.CODIGO_FAMILIA.ToString <> Empresa_Sistema.CODIGO_FAMILIA_MATERIA_EMPAQUE.ToString Then
                                MsgBox("El código de empaque no es material del empaque.", MsgBoxStyle.Exclamation, Me.Text)
                                Me.Grid.Cell(Renglon, Me.igyCodigoEmpaque).Text = ""
                                Me.Grid.Cell(Renglon, Me.igyCodigoEmpaque).SetFocus()
                                Exit Sub
                            End If

                            Me.Grid.Cell(Renglon, Me.igyCodigoEmpaque).Text = sCodigoEmpaque
                            Me.Grid.Cell(Renglon, Me.igyNombreArticulo).Text = oCodigoEmbarque.DESCRIPCION
                            Me.Grid.Cell(Renglon, Me.igyUnidadVenta).Text = oCodigoEmbarque.UNIDAD_VENTA

                        Case Me.igyCantidad
                            If Me.Estado = enumEstados.CONSULTA Then
                                Exit Sub
                            End If

                            If iEditable = 1 Then
                                'If txtLEN(Me.Grid.Cell(Renglon, Me.igyCodigoEmpaque).Text) = True Then
                                If iMillar = "1" Then
                                    If dCantidad >= 1 Then
                                        'MsgBox("Verifique el dato, se administra por millares.", MsgBoxStyle.Exclamation, Me.Text)
                                        'Me.Grid.Cell(Renglon, Me.igyCantidad).SetFocus()
                                        'e.SuppressKeyPress = True
                                        'Exit Sub
                                        Me.Grid.Cell(Renglon, Me.igyCantidad).Text = (dCantidad / 100).ToString
                                    End If
                                End If
                                If dCantidad <= 0 Then
                                    MsgBox("La canditad debe ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
                                    Me.Grid.Cell(Renglon, Me.igyCantidad).SetFocus()
                                    e.SuppressKeyPress = True
                                    Exit Sub
                                End If
                                'End If
                            End If
                    End Select

                Case Keys.F6
                    If Me.Estado = enumEstados.CONSULTA Then
                        e.SuppressKeyPress = True
                        Exit Sub
                    End If
Busca:
                    If Columna = Me.igyCodigoEmpaque Then
                        oCodigoEmbarque = New Class_CatArticulos
                        sCodigoEmpaque = oCodigoEmbarque.BusquedaVisualMaterialEmpaque_PorDescripcion
                        If txtLEN(sCodigoEmpaque) = True Then
                            GoTo LlenaLinea
                        End If
                    End If
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrid", ex)
        End Try
    End Sub

    'Private Function Validar(Optional ByVal Renglon As Integer = 2, Optional ByVal Codigo As String = "") As Boolean
    '    Dim i As Integer
    '    Dim sCodigoProducto As String = ""

    '    For i = 1 To Me.Grid.Rows - 1
    '        If txtLEN(Me.Grid.Cell(i, Me.igyClave).Text) = True Then
    '            Dim sql As New Class_find("SELECT C.CODIGO_EMPAQUE,C.CANTIDAD " & _
    '                                      "FROM CAT_PRODUCTOS_AGRICOLAS_FORMULAS_EMPAQUE C " & _
    '                                      "WHERE C.CODIGO_PRODUCTO='" & Me.TxtCodArticulo.Text & "'  " & _
    '                                      "AND CLAVE='" & Me.Grid.Cell(i, Me.igyClave).Text & " ' ")
    '            If txtLEN(sql.Result1) = True Then
    '                Me.Grid.Cell(i, Me.igyCodigoEmpaque).Text = sql.Result1.ToString
    '                Me.Grid.Cell(i, Me.igyCantidad).Text = sql.Result2.ToString
    '                Validar = True
    '            End If
    '        End If
    '    Next i
    'End Function

#End Region

#Region "Eventos de objetos"
#Region "Eventos de la lista de elementos"
    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid2.CellClick
        Me.LlenaElemento(Me.Grid2.CurrentRow.Cells("CODIGO_ARTICULO").Value.ToString)
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid2.CellDoubleClick
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

#Region " Eventos de TxtFiltro y CboEstatusFiltro"
    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Dim oElementos As New Class_CatArticulos
        Me.Grid.DataSource = Nothing

        With Me.Grid2
            .DataSource = oElementos.ObtenerElementosFiltroProductosAgricolas(Me.txtFiltro.Text, Me.CboEstatusFiltro.Text)
            .Columns("CODIGO_ARTICULO").Width = 70
            .Columns("DESCRIPCION").Width = 450
        End With
    End Sub
    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub
    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        Dim oElementosFiltro As New Class_CatArticulos
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
            Me.Grid.DataSource = Nothing

            With Me.Grid2
                .DataSource = oElementosFiltro.ObtenerElementosFiltroProductosAgricolas(Me.txtFiltro.Text, Me.CboEstatusFiltro.Text)
                .Columns("CODIGO_ARTICULO").Width = 70
                .Columns("DESCRIPCION").Width = 450
            End With
        End If
    End Sub
    Private Sub CboEstatusFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboEstatusFiltro.SelectedIndexChanged
        Dim oElementos As New Class_CatArticulos
        Me.Grid.DataSource = Nothing

        With Me.Grid2
            .DataSource = oElementos.ObtenerElementosFiltroProductosAgricolas(Me.txtFiltro.Text, Me.CboEstatusFiltro.Text)
            .Columns("CODIGO_ARTICULO").Width = 70
            .Columns("DESCRIPCION").Width = 450
        End With
    End Sub
#End Region

#Region "Eventos Genericos"

    Private Sub CboEstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboEstatus.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                Me.tsbGrabar.PerformClick()
        End Select
    End Sub

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRangoPiezas.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRangoPiezas.KeyDown
        If e.KeyCode = Keys.Return Then
            Select Case Me.Estado
                Case enumEstados.EDICION
                    Me.CboEstatus.Focus()
                Case enumEstados.NUEVO
                    Me.Grid.Cell(1, Me.igyCodigoEmpaque).SetFocus()
            End Select
        End If
    End Sub

    Private Sub txtNumericos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPrecio.KeyPress, TxtPeso.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumericos_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim t As TextBox
        t = CType(sender, TextBox)
        If Not IsNumeric(t.Text) Then
            t.Text = Val(t.Text).ToString
        End If
    End Sub

    Private Sub TxtPrecio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPrecio.KeyPress, TxtPeso.KeyPress
        If InStr(1, "0123456789." & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = CChar("")
        End If
    End Sub

    Private Sub cboEnvase_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPrecio.KeyDown, TxtDescripcion.KeyDown, TxtCodArticulo.KeyDown, cboTamaño.KeyDown, CboFamilia.KeyDown, cboEtiqueta.KeyDown, cboEnvase.KeyDown, cboCultivo.KeyDown, TxtPeso.KeyDown, TxtCantidadBultosXPalet.KeyDown, cboUnidadVenta.KeyDown
        txtTAB(e)
    End Sub

    Private Sub cboCultivo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPrecio.KeyPress, TxtDescripcion.KeyPress, TxtCodArticulo.KeyPress, cboTamaño.KeyPress, CboFamilia.KeyPress, cboEtiqueta.KeyPress, CboEstatus.KeyPress, cboEnvase.KeyPress, cboCultivo.KeyPress, TxtPeso.KeyPress, cboUnidadVenta.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub cboCultivo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTamaño.SelectedIndexChanged, cboEtiqueta.SelectedIndexChanged, cboEnvase.SelectedIndexChanged, cboCultivo.SelectedIndexChanged
        If Me.Estado = enumEstados.NUEVO Then
            Me.GeneraCodigoDescripcion()
        End If
    End Sub

    Private Sub CboFiltroHoja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Refrescar()
    End Sub

    Private Sub TxtCantidadBultosXPalet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantidadBultosXPalet.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub Grid_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        Me.GestionaGrid(e)
    End Sub

#End Region

    Private Sub chkInventariable_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        txtTAB(e)
    End Sub

#End Region

End Class