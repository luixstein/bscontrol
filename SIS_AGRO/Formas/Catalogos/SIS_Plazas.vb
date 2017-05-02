Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class SIS_Plazas
    Private oPlazas As New Class_SisPlazas

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
            Me.msgElemento = "Plaza"
            Me.msgElementos = "Plazas"
            Me.Run = False
            'Me.lstbElementos.ContextMenuStrip = Me.cMenuStripAccion
            Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
            Me.DesplegarElementos()
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
        Me.TxtCodigo.Text = Me.oPlazas.CodigoSiguiente
        Me.CboEstatus.Enabled = True
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las modificaciones del " & Me.msgElemento & " : " & Me.TxtCodigo.Text
            Case enumEstados.NUEVO
                sMsg = " agregar el " & Me.msgElemento & " : " & Me.TxtCodigo.Text
        End Select
        sMsg = "Deseas " & sMsg & " ?"
        If MsgBox(sMsg, CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle)) = MsgBoxResult.Yes Then
            Call Grabar_Elemento()
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
        Me.oPlazas.Imprimir_Listado()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub SIS_Plazas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DesplegarPaises()
        Me.DesplegarElementos()
    End Sub
    Private Sub Refrescar()
        Me.DesplegarElementos()
        Me.DesplegarPaises()
    End Sub

    Private Sub Cambia_Estado()
        Select Case Me.Estado
            Case enumEstados.NUEVO
                Me.gBoxInformacion.Enabled = True
                Me.gBoxDomicilio.Enabled = True
                Me.gBoxEjercicio.Enabled = True
                Me.gBoxCuentasContables.Enabled = True
                Me.gBoxVentas.Enabled = True
                Me.gBoxZona.Enabled = True
                Me.gBoxInventarios.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Agregando"
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtCodigo.Enabled = False
                Me.TxtNombre.Enabled = True
                Me.CboEstatus.Enabled = False

                Me.InicializaElemento()
                Me.TxtNombre.Focus()

            Case enumEstados.EDICION
                Me.gBoxInformacion.Enabled = True
                Me.gBoxDomicilio.Enabled = True
                Me.gBoxEjercicio.Enabled = True
                Me.gBoxCuentasContables.Enabled = True
                Me.gBoxVentas.Enabled = True
                Me.gBoxZona.Enabled = True
                Me.gBoxInventarios.Enabled = True
                Me.gBoxBusquedaRapida.Enabled = False
                Me.tssLabelEstado.Text = "Edición"
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtCodigo.Enabled = False
                Me.TxtNombre.Enabled = True
                Me.TxtIdentificador.Enabled = True
                Me.CboEstatus.Enabled = True

                Me.TxtCodigoClienteExportacion.Enabled = False
                Me.TxtCodigoClienteNacional.Enabled = True
                Me.TxtCodigoProveedor.Enabled = False
                Me.TxtNombre.Focus()

            Case enumEstados.CONSULTA
                Me.gBoxInformacion.Enabled = False
                Me.gBoxDomicilio.Enabled = False
                Me.gBoxEjercicio.Enabled = False
                Me.gBoxCuentasContables.Enabled = False
                Me.gBoxVentas.Enabled = False
                Me.gBoxZona.Enabled = False
                Me.gBoxInventarios.Enabled = False
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
        Me.TxtCodigo.Text = ""
        Me.TxtNombre.Text = ""
        Me.TxtIdentificador.Text = ""
        Me.CboEstatus.SelectedIndex = 0

        Me.cboPais.SelectedIndex = -1
        Me.cboEstado.SelectedIndex = -1
        Me.cboCiudad.SelectedIndex = -1
        Me.TxtCalle.Text = ""
        Me.TxtExterior.Text = ""
        Me.TxtInterior.Text = ""
        Me.TxtCodLocalidad.Text = ""
        Me.TxtLocalidad.Text = ""
        Me.TxtCodColonia.Text = ""
        Me.TxtColonia.Text = ""
        Me.TxtCodigoPostal.Text = ""
        Me.TxtTelefono.Text = ""

        Me.TxtIdEjercicioContable.Text = ""
        Me.LblNombreEjercicio.Text = ""
        Me.dtFechaInicio.Value = Now
        Me.dtFechaFinal.Value = Now

        Me.TxtCuentaContableVentas.Text = ""
        Me.TxtCtaContableMayorExportacion.Text = ""
        Me.TxtCtaContableMayorNacional.Text = ""
        Me.TxtCtaContadoExportacion.Text = ""
        Me.TxtCtaContadoNacional.Text = ""
        Me.TxtCuentaProveedor.Text = ""
        Me.txtCuentaRebajas.Text = ""

        Me.TxtImpuestoPorcentaje.Text = ""
        Me.TxtPlazoVentaContado.Text = ""
        Me.ckbValidarFechaVentas.Checked = False
        Me.TxtIdTemporadaProduccion.Text = ""
        Me.TxtCodigoClienteExportacion.Text = ""
        Me.TxtCodigoClienteNacional.Text = ""

        Me.TxtCodigoZona.Text = ""
        Me.LblNombreZona.Text = ""

        Me.TxtCodigoAlmacen.Text = ""
        Me.LblNombreAlmacen.Text = ""
        Me.TxtCodigoProveedor.Text = ""
        Me.TxtCodigoLoteEmbarque.Text = ""
        Me.TxtCodigoLotePlanta.Text = ""
        Me.TxtCodigoPuntoPago.Text = ""

    End Sub
    Private Sub DesplegarElementos()
        With Me.Grid
            .DataSource = oPlazas.ObtenerElementos
            .Columns("CODIGO_PLAZA").Width = 50
            .Columns("NOMBRE_PLAZA").Width = 200
        End With

    End Sub

    Private Sub LlenaElemento(ByVal sCodigo_Elemento As String)
        Me.oPlazas.CODIGO_PLAZA = CInt(sCodigo_Elemento)
        If Me.oPlazas.Consultar Then
            With Me.oPlazas
                Me.TxtCodigo.Text = .CODIGO_PLAZA.ToString
                Me.TxtNombre.Text = .NOMBRE_PLAZA
                Me.TxtIdentificador.Text = .Identificador
                If .Estatus = "A" Then
                    Me.CboEstatus.SelectedIndex = 0
                Else
                    Me.CboEstatus.SelectedIndex = 1
                End If

                Me.cboPais.SelectedValue = .CODIGO_PAIS_SAT
                Me.cboEstado.SelectedValue = .CODIGO_ESTADO
                Me.cboCiudad.SelectedValue = .CODIGO_MUNICIPIO
                Me.TxtCalle.Text = .CALLE
                Me.TxtExterior.Text = .NUMERO_EXTERIOR
                Me.TxtInterior.Text = .NUMERO_INTERIOR
                Me.TxtCodColonia.Text = .CODIGO_COLONIA_SAT
                Me.TxtColonia.Text = .COLONIA
                Me.TxtCodLocalidad.Text = .CODIGO_LOCALIDAD_SAT
                Me.TxtLocalidad.Text = .LOCALIDAD
                Me.TxtCodigoPostal.Text = .CODIGO_POSTAL
                Me.TxtTelefono.Text = .TELEFONO

                Me.TxtIdEjercicioContable.Text = .ID_CON_EJERCICIO.ToString
                Dim sql As New Class_find("SELECT NOMBRE_EJERCICIO FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO =" & Me.TxtIdEjercicioContable.Text)
                If sql.Result1 = "" Then
                Else
                    Me.LblNombreEjercicio.Text = sql.Result1.ToString
                End If
                sql = Nothing
                Me.dtFechaInicio.Value = .FECHA_INICIO
                Me.dtFechaFinal.Value = .FECHA_FINAL

                Me.TxtCuentaContableVentas.Text = .CUENTA_CONTABLE_VENTAS
                Me.TxtCtaContableMayorExportacion.Text = .CUENTA_CONTABLE_MAYOR_EXPORTACION
                Me.TxtCtaContableMayorNacional.Text = .CUENTA_CONTABLE_MAYOR_NACIONAL
                Me.TxtCtaContadoExportacion.Text = .CUENTA_CONTABLE_CONTADO_EXPORTACION
                Me.TxtCtaContadoNacional.Text = .CUENTA_CONTABLE_CONTADO_NACIONAL
                Me.TxtCuentaProveedor.Text = .CUENTA_CONTABLE_PROVEEDOR_GENERICA
                Me.txtCuentaRebajas.Text = .CUENTA_DESCUENTOS_REBAJAS_NACIONALES

                Me.TxtImpuestoPorcentaje.Text = .Impuesto_Porcentaje.ToString
                Me.TxtPlazoVentaContado.Text = .PLAZO_VENTA_CONTADO.ToString
                Me.ckbValidarFechaVentas.Checked = CBool(.VALIDAR_FECHA_VENTAS)
                Me.TxtIdTemporadaProduccion.Text = .ID_TEMPORADA_PRODUCCION.ToString
                Me.TxtCodigoClienteExportacion.Text = .CODIGO_CLIENTES_EXPORTACION
                Me.TxtCodigoClienteNacional.Text = .CODIGO_CLIENTES_NACIONAL

                Me.TxtCodigoZona.Text = .CODIGO_ZONA_PRINCIPAL
                sql = New Class_find("SELECT NOMBRE_ZONA FROM CAT_ZONAS WHERE CODIGO_ZONA='" & Me.TxtCodigoZona.Text & "'")
                If sql.Result1 = "" Then
                Else
                    Me.LblNombreZona.Text = sql.Result1
                End If
                sql = Nothing

                Me.TxtCodigoAlmacen.Text = .CODIGO_ALMACEN_PRINCIPAL
                sql = New Class_find("SELECT NOMBRE_ALMACEN FROM CAT_ALMACENES WHERE CODIGO_ALMACEN='" & Me.TxtCodigoAlmacen.Text & "'")
                If sql.Result1 = "" Then
                Else
                    Me.LblNombreAlmacen.Text = sql.Result1
                End If
                sql = Nothing
                Me.TxtCodigoProveedor.Text = .Codigo_Proveedor
                Me.TxtCodigoLoteEmbarque.Text = .CODIGO_LOTE_EMPAQUE
                Me.TxtCodigoLotePlanta.Text = .CODIGO_LOTE_PLANTA
                Me.TxtCodigoPuntoPago.Text = .CODIGO_PUNTO_PAGO_EMPAQUE

            End With
        End If
    End Sub

    Private Sub Grabar_Elemento()
        Dim Grabado As Boolean = False

        If Validar() = False Then
            Exit Sub
        End If

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                Try
                    With Me.oPlazas
                        .CODIGO_PLAZA = CInt(Me.TxtCodigo.Text)
                        .NOMBRE_PLAZA = Me.TxtNombre.Text
                        .Identificador = Me.TxtIdentificador.Text
                        .Estatus = Strings.Left(Me.CboEstatus.Text, 1)

                        .CODIGO_PAIS_SAT = cboPais.SelectedValue.ToString
                        .PAIS = cboPais.Text
                        .CODIGO_ESTADO = cboEstado.SelectedValue.ToString
                        .ESTADO = cboEstado.Text
                        .CODIGO_MUNICIPIO = cboCiudad.SelectedValue.ToString
                        .CIUDAD = cboCiudad.Text
                        .CALLE = Me.TxtCalle.Text
                        .NUMERO_EXTERIOR = Me.TxtExterior.Text
                        .NUMERO_INTERIOR = Me.TxtInterior.Text
                        .CODIGO_COLONIA_SAT = Me.TxtCodColonia.Text
                        .COLONIA = Me.TxtColonia.Text
                        .CODIGO_LOCALIDAD_SAT = Me.TxtCodLocalidad.Text
                        .LOCALIDAD = Me.TxtLocalidad.Text
                        .CODIGO_POSTAL = Me.TxtCodigoPostal.Text
                        .TELEFONO = Me.TxtTelefono.Text

                        .ID_CON_EJERCICIO = CInt(Me.TxtIdEjercicioContable.Text)
                        .FECHA_INICIO = dtFechaInicio.Value
                        .FECHA_FINAL = dtFechaFinal.Value

                        .CUENTA_CONTABLE_VENTAS = Me.TxtCuentaContableVentas.Text
                        .CUENTA_CONTABLE_MAYOR_EXPORTACION = Me.TxtCtaContableMayorExportacion.Text
                        .CUENTA_CONTABLE_MAYOR_NACIONAL = Me.TxtCtaContableMayorNacional.Text
                        .CUENTA_CONTABLE_CONTADO_EXPORTACION = Me.TxtCtaContadoExportacion.Text
                        .CUENTA_CONTABLE_CONTADO_NACIONAL = Me.TxtCtaContadoNacional.Text
                        .CUENTA_CONTABLE_PROVEEDOR_GENERICA = Me.TxtCuentaProveedor.Text
                        .CUENTA_DESCUENTOS_REBAJAS_NACIONALES = Me.txtCuentaRebajas.Text

                        .Impuesto_Porcentaje = CType(Me.TxtImpuestoPorcentaje.Text, Decimal)
                        .PLAZO_VENTA_CONTADO = CInt(Me.TxtPlazoVentaContado.Text)
                        .VALIDAR_FECHA_VENTAS = Me.ckbValidarFechaVentas.Checked.ToString
                        .ID_TEMPORADA_PRODUCCION = CInt(Me.TxtIdTemporadaProduccion.Text)
                        .CODIGO_CLIENTES_EXPORTACION = Me.TxtCodigoClienteExportacion.Text
                        .CODIGO_CLIENTES_NACIONAL = Me.TxtCodigoClienteNacional.Text

                        .CODIGO_ZONA_PRINCIPAL = Me.TxtCodigoZona.Text

                        .CODIGO_ALMACEN_PRINCIPAL = Me.TxtCodigoAlmacen.Text
                        .Codigo_Proveedor = Me.TxtCodigoProveedor.Text
                        .CODIGO_LOTE_EMPAQUE = Me.TxtCodigoLoteEmbarque.Text
                        .CODIGO_LOTE_PLANTA = Me.TxtCodigoLotePlanta.Text
                        .CODIGO_PUNTO_PAGO_EMPAQUE = Me.TxtCodigoPuntoPago.Text

                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                If .Insertar() Then
                                    Grabado = True
                                    Me.Estado = enumEstados.NUEVO
                                End If
                            Case enumEstados.EDICION
                                If .Actualizar() Then
                                    Grabado = True
                                End If
                        End Select

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

    Private Sub DesplegarPaises()
        Try
            Me.cboEstado.DataSource = Nothing
            Me.cboCiudad.DataSource = Nothing
            Dim oElementos As New Class_CatPaises
            With Me.cboPais
                .DisplayMember = "NOMBRE_PAIS"
                .ValueMember = "CODIGO_PAIS_SAT"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos)
                dView.Sort = "NOMBRE_PAIS"
                .DataSource = dView
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarPaises", ex)
        End Try
    End Sub

    Private Sub DesplegarEstados()
        Try
            Me.cboEstado.DataSource = Nothing
            Me.cboCiudad.DataSource = Nothing
            If Me.cboPais.SelectedIndex = -1 Then
                Return
            End If
            Dim oElementos As New Class_SisEstados
            With Me.cboEstado
                .DisplayMember = "NOMBRE_ESTADO"
                .ValueMember = "CODIGO_ESTADO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos(Me.cboPais.SelectedValue.ToString))
                dView.Sort = "NOMBRE_ESTADO"
                .DataSource = dView
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarEstados", ex)
        End Try
    End Sub

    Private Sub DesplegarCiudades()
        Try
            Me.cboCiudad.DataSource = Nothing
            If Me.cboEstado.SelectedIndex = -1 Then
                Return
            End If
            Dim oElementos As New Class_CatMunicipios
            With Me.cboCiudad
                .DisplayMember = "NOMBRE_MUNICIPIO"
                .ValueMember = "CODIGO_MUNICIPIO"
                Dim dView As New Data.DataView(oElementos.ObtenerElementos(Me.cboEstado.SelectedValue.ToString))
                dView.Sort = "NOMBRE_MUNICIPIO"
                .DataSource = dView
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarMunicipios", ex)
        End Try
    End Sub

    Private Function Validar() As Boolean
        Dim bResultado As Boolean = False

        If txtLEN(Me.TxtNombre.Text) = False Then
            MsgBox("Asíge un nombre a la plaza.", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtNombre.Focus()
            Return bResultado
        End If

        If txtLEN(Me.TxtIdentificador.Text) = False Then
            MsgBox("Asígne un identificador a la plaza.", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtIdentificador.Focus()
            Return bResultado
        End If

        If Me.cboPais.SelectedIndex = -1 Then
            MsgBox("Seleccione un país.", MsgBoxStyle.Exclamation, Me.Text)
            Me.cboPais.Focus()
            Return bResultado
        End If

        If Me.cboEstado.SelectedIndex = -1 Then
            MsgBox("Seleccione un estado.", MsgBoxStyle.Exclamation, Me.Text)
            Me.cboEstado.Focus()
            Return bResultado
        End If

        If Me.cboCiudad.SelectedIndex = -1 Then
            MsgBox("Seleccione una ciudad.", MsgBoxStyle.Exclamation, Me.Text)
            Me.cboCiudad.Focus()
            Return bResultado
        End If

        If txtLEN(Me.TxtIdEjercicioContable.Text) = False Then
            MsgBox("Asígne un id de ejercicio contable.", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtIdEjercicioContable.Focus()
            Return bResultado
        End If

        If txtLEN(Me.TxtImpuestoPorcentaje.Text) = False Then
            MsgBox("Capture un porcentaje de impuesto.", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtImpuestoPorcentaje.Focus()
            Return bResultado
        End If

        bResultado = True
        Return bResultado

    End Function


#End Region

#Region "Eventos de objetos"

    Private Sub cboPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPais.SelectedIndexChanged
        DesplegarEstados()
    End Sub

    Private Sub cboEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstado.SelectedIndexChanged
        DesplegarCiudades()
    End Sub

#Region "Eventos de la lista de elementos"

    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        Me.LlenaElemento(Me.Grid.CurrentRow.Cells("CODIGO_PLAZA").Value.ToString)
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellDoubleClick
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub
#End Region

#Region " Eventos de TxtFiltro"
    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Me.Grid.DataSource = Nothing

        With Me.Grid
            .DataSource = oPlazas.ObtenerElementosFiltro(Me.txtFiltro.Text)
            .Columns("CODIGO_PLAZA").Width = 50
            .Columns("NOMBRE_PLAZA").Width = 200
        End With
    End Sub
    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub
    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
            Me.Grid.DataSource = Nothing

            With Me.Grid
                .DataSource = oPlazas.ObtenerElementosFiltro(Me.txtFiltro.Text)
                .Columns("CODIGO_PLAZA").Width = 50
                .Columns("NOMBRE_PLAZA").Width = 200
            End With
        End If
    End Sub
#End Region

#Region "Eventos Genericos"

    Private Sub CboEstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboEstatus.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboEstatus.KeyPress, TxtNombre.KeyPress, TxtIdentificador.KeyPress, cboPais.KeyPress, cboEstado.KeyPress, cboCiudad.KeyPress, TxtCalle.KeyPress, TxtExterior.KeyPress, TxtInterior.KeyPress, TxtCodColonia.KeyPress, TxtColonia.KeyPress, TxtCodLocalidad.KeyPress, TxtLocalidad.KeyPress, TxtTelefono.KeyPress, dtFechaInicio.KeyPress, dtFechaFinal.KeyPress, TxtCodigoClienteExportacion.KeyPress, TxtCodigoClienteNacional.KeyPress, TxtCodigoZona.KeyPress, TxtCodigoAlmacen.KeyPress, TxtCodigoProveedor.KeyPress, TxtCodigoLoteEmbarque.KeyPress, TxtCodigoLotePlanta.KeyPress, TxtCodigoPuntoPago.KeyPress, ckbValidarFechaVentas.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombre.KeyDown
        If e.KeyCode = Keys.Return Then

        End If
    End Sub

    Private Sub CboAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            Select Case Me.Estado
                Case enumEstados.EDICION
                    SendKeys.Send("{TAB}")
                Case enumEstados.NUEVO
                    tsbGrabar.PerformClick()
            End Select
        End If
    End Sub

    Private Sub txtNumericos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress, TxtIdEjercicioContable.KeyPress, TxtCodigoPostal.KeyPress, TxtCuentaContableVentas.KeyPress, TxtCtaContableMayorExportacion.KeyPress, TxtCtaContableMayorNacional.KeyPress, TxtCtaContadoExportacion.KeyPress, TxtCtaContadoNacional.KeyPress, TxtCuentaProveedor.KeyPress, txtCuentaRebajas.KeyPress, TxtImpuestoPorcentaje.KeyPress, TxtPlazoVentaContado.KeyPress, TxtIdTemporadaProduccion.KeyPress
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
    Private Sub TxtCodigoZona_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigoZona.KeyDown
        Dim oElemento As New Class_CatZonas
        Select Case e.KeyCode
            Case Keys.F6
busca:
                Me.TxtCodigoZona.Text = oElemento.BusquedaVisual_PorDescripcion
                oElemento.Codigo_Zona = CInt(Me.TxtCodigoZona.Text)
                Me.TxtCodigoZona.Text = oElemento.BusquedaVisual_PorDescripcion
                oElemento.Codigo_Zona = CInt(Me.TxtCodigoZona.Text)
                If txtLEN(Me.TxtCodigoZona.Text) = True Then
                    oElemento.Consultar()
                    Me.LblNombreZona.Text = oElemento.Nombre_Zona
                Else
                    MsgBox("No existen elementos en el catálogo de Zonas.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
                End If
            Case Keys.Enter
                If txtLEN(Me.TxtCodigoZona.Text) = True Then
                    oElemento.Codigo_Zona = CInt(Me.TxtCodigoZona.Text)
                    If oElemento.Consultar() = False Then
                        GoTo busca
                    End If
                    Me.LblNombreZona.Text = oElemento.Nombre_Zona
                End If
        End Select
        txtTAB(e)
    End Sub
#End Region

#Region "Validating específicos"

#End Region

#End Region

End Class