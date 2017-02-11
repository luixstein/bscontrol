Option Strict On

Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Common
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Collections
Imports System.Collections.Generic
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_Embarques_ArmadoPalets
    Private _FolioEmbarqueConsultaExterior As String = ""

    Private oPaletsGlobal As New Class_Embarques_PaletsGlobal
    Private oEmbarques As New Class_Embarques_BultosEmpacados
    Private oProveedores As New Class_CatProveedores
    Private oArticulos As New Class_CatArticulos
    Private oLotes As New Class_CatLotes
    Private oProductores As New Class_CatProductores

    Private Estado As enumEstados

    Private igyCodigo As Short = 1
    Private igyDescripcion As Short = 2
    Private igyCantidad As Short = 3
    Private igyPrecioUnidadBulto As Short = 4
    Private igyPesoUnidadBulto As Short = 5
    Private igyImporteBultosDetalle As Short = 6
    Private igyPesoBultosDetalle As Short = 7
    'Private b As Boolean = False

    Private Enum enumEstados
        NUEVO
        GRABADO
        ARMADO
        EMBARCADO
        CANCELADO
    End Enum

#Region "Propiedades"
    Public WriteOnly Property FolioEmbarqueConsultaExterior() As String
        Set(ByVal Value As String)
            Me._FolioEmbarqueConsultaExterior = Value
        End Set
    End Property
#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Cambia_Estado(enumEstados.NUEVO)
        Me.Inicializa()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Me.GestionaGrabar() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbArmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbArmar.Click
        If Me.Armado(Me.TxtFolio.Text, True) = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
        If Me.Cancelar() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub btnImprimirEtiquetasPalets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirEtiquetasPalets.Click
        Me.oPaletsGlobal.GestionaEtiquetasPalets(Me.txtFolioPalet1Etiquetas.Text, Me.txtFolioPalet2Etiquetas.Text, Me.Font, "Palets")
    End Sub

    Private Sub btnImprimirEtiquetasCajas_Click(sender As Object, e As EventArgs) Handles btnImprimirEtiquetasCajas.Click
        Me.oPaletsGlobal.GestionaEtiquetasCajas(Me.txtFolioPalet1Etiquetas.Text, Me.txtFolioPalet2Etiquetas.Text, Me.Font, "Cajas")
    End Sub

    Private Sub BtnArmarPalets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnArmarPalets.Click
        If Me.GestionaArmado() = True Then
            Me.Consultar()
        End If
    End Sub
    Private Sub tsbDesarmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDesarmarPalet.Click
        If Me.DesArmarPalet = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos de objetos"
#Region "Eventos"
    Private Sub Frm_ArmadoPalets_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DesplegarProductores()
        Me.DesplegarEmpaques()
        Me.DesplegarLotes()

        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)

        If Me._FolioEmbarqueConsultaExterior.Length > 0 Then
            Me.TxtFolio.Text = Me._FolioEmbarqueConsultaExterior
            Me.Consultar()
        End If

    End Sub

    Private Sub TxtFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFolio.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If Me.Consultar() = True Then
                Me.CboEmpaque.Focus()
                    Me.txtFolioPalet1Etiquetas.Text = Me.TxtFolio.Text
                    Me.txtFolioPalet2Etiquetas.Text = Me.TxtFolio.Text
                End If
        End Select
    End Sub

    Private Sub CboEmpaque_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboEmpaque.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub CboProductor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboProductor.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub TxtCodigoProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oProveedores.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.txtProveedor.Text = sText
            Case Keys.Enter
                If txtLEN(Me.txtProveedor.Text) = False Then
                    Me.lblProveedor.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.oProveedores = New Class_CatProveedores(Me.txtProveedor.Text)
                If Me.oProveedores.Existe = False Then
                    Me.lblProveedor.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblProveedor.Text = Me.oProveedores.Nombre_Proveedor
                txtTAB(e)
        End Select
    End Sub

    Private Sub CboProductor_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboProductor.SelectedValueChanged
        If Me.CboProductor.SelectedValue Is Nothing Then
            Me.gbGeneraraSalida.Visible = False
            Me.rdbSi.Checked = True
            Exit Sub
        End If
        If Me.CboProductor.SelectedValue.ToString = Empresa_Sistema.CODIGO_PRODUCTOR_SALIDA_INVENTARIABLE_AUTOMATICA Then
            Me.gbGeneraraSalida.Visible = False
            Me.rdbSi.Checked = True
        Else
            Me.gbGeneraraSalida.Visible = True
            Me.rdbSi.Checked = True
        End If
    End Sub

    Private Sub CboLote_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboLote.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub DtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpFecha.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub txtCantidadPalets_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidadPalets.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub CboOrigen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboOrigen.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.chkEsChepPalet.Focus()
        End Select
    End Sub

    Private Sub chkEsChepPalet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkEsChepPalet.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.Grid.Cell(1, Me.igyCodigo).SetFocus()
        End Select
    End Sub

    Private Sub Grid_CellChange(ByVal Sender As Object, ByVal e As FlexCell.Grid.CellChangeEventArgs) Handles Grid.CellChange
        Dim dImporteBultos As Double
        If Me.Grid.ActiveCell.Col = Me.igyCantidad Then
            Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.igyPesoBultosDetalle).Text = (valorNumerico(Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.igyPesoUnidadBulto).Text) * valorNumerico(Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.igyCantidad).Text)).ToString
            dImporteBultos = CDbl((valorNumerico(Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.igyPrecioUnidadBulto).Text) * valorNumerico(Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.igyCantidad).Text)))
            dImporteBultos = Redondear(dImporteBultos, Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.igyImporteBultosDetalle).Text = dImporteBultos.ToString
            Me.Totales()
        ElseIf Me.Grid.ActiveCell.Col = Me.igyPesoUnidadBulto Then
            Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.igyPesoBultosDetalle).Text = (valorNumerico(Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.igyPesoUnidadBulto).Text) * valorNumerico(Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.igyCantidad).Text)).ToString
            Me.Totales()
        ElseIf Me.Grid.ActiveCell.Col = Me.igyPrecioUnidadBulto Then
            dImporteBultos = CDbl((valorNumerico(Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.igyPrecioUnidadBulto).Text) * valorNumerico(Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.igyCantidad).Text)))
            dImporteBultos = Redondear(dImporteBultos, Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.igyImporteBultosDetalle).Text = dImporteBultos.ToString
            Me.Totales()
        End If
    End Sub

    Private Sub Grid_KeyPress(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Grid.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub Grid_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        Me.GestionaGrid(e)
    End Sub

    Private Sub DtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFecha.ValueChanged
        If Me.Estado = enumEstados.NUEVO Then 'and b=false
            If Me.DtpFecha.Value > Now Then 'CDate(Format(Me.DtpFecha.Value, Now.Year & "-" & Now.Month & "-" & Now.Day & " 05:00:00")) Then
                Me.DtpFecha.Value = Now
                'ElseIf Me.DtpFecha.Value < CDate(Format(Me.DtpFecha.Value, Now.Year & "-" & Now.Month & "-" & Now.Day & " 05:00:00")) Then
                '    Dim d As Date
                '    d = DtpFecha.Value.AddDays(-1)
                '    'b = True
                '    Me.DtpFecha.Value = CDate(Format(d, d.Date & " 23:59:59"))
            End If
        End If
    End Sub

    Private Sub btnPaletAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaletAnterior.Click
        Me.NavegadorPalets("Anterior")
    End Sub

    Private Sub btnPaletSiguiente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPaletSiguiente.Click
        Me.NavegadorPalets("Siguiente")
    End Sub

    Private Sub txtCentroCosto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCentroCosto.KeyDown
        Try
            Dim sText As String, oCentroCosto As Class_CatCentroCostos

            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    oCentroCosto = New Class_CatCentroCostos
                    sText = oCentroCosto.BusquedaVisualPorProyectoSiembraActivo
                    If txtLEN(sText) = True Then
                        Me.txtCentroCosto.Text = sText
                        GoTo Enter : Return
                    End If

                Case Keys.Enter
Enter:
                    If txtLEN(Me.txtCentroCosto.Text) = False Then
                        Me.lblCentroCosto.Text = "" : GoTo Buscar : Exit Sub
                    End If
                    oCentroCosto = New Class_CatCentroCostos(CInt(Me.txtCentroCosto.Text))
                    If oCentroCosto.EXISTE = True Then
                        Me.txtCentroCosto.Text = oCentroCosto.CODIGO_CENTRO_COSTO.ToString
                        Me.lblCentroCosto.Text = oCentroCosto.NOMBRE_CENTRO_COSTO
                    Else
                        Me.lblCentroCosto.Text = ""
                        GoTo Buscar : Exit Sub
                    End If
                    txtTAB(e)
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "txtCentroCosto_KeyDown", ex)
        End Try
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFolio.KeyPress, txtCantidadPalets.KeyPress, txtProveedor.KeyPress, DtpFecha.KeyPress, TxtFolio.KeyPress, TxtTotalPeso.KeyPress, _
        txtFolioPalet1Etiquetas.KeyPress, txtFolioPalet2Etiquetas.KeyPress, txtCentroCosto.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidadPalets.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboEmpaque.KeyPress, DtpFecha.KeyPress, TxtFolio.KeyPress, txtCantidadPalets.KeyPress, txtProveedor.KeyPress, txtFolioPalet1Etiquetas.KeyPress, txtFolioPalet2Etiquetas.KeyPress
        txtNoBeep(e)
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.TxtFolio.Text = ""
            Me.txtProveedor.Text = ""
            Me.lblProveedor.Text = ""
            Me.txtCantidadPalets.Text = "1"
            Me.LblEstatus.Text = "N"
            Me.dtFechaCorte.Value = Now
            Me.DtpFecha.Value = Now

            If Me.DtpFecha.Value < CDate(Format(Me.DtpFecha.Value, Now.Year & "-" & Now.Month & "-" & Now.Day & " 05:00:00")) Then
                Dim d As Date = DtpFecha.Value.AddDays(-1)
                Me.DtpFecha.Value = CDate(Format(d, d.Date & " 23:59:59"))
            End If

            Me.InicializaGrid()
            Me.CboEmpaque.SelectedItem = 1
            Me.CboLote.SelectedIndex = 0
            Me.CboOrigen.SelectedIndex = 0
            Me.chkEsChepPalet.Checked = False
            Me.CboEstatus.SelectedIndex = 0
            Me.TxtTotalBultos.Text = ""
            Me.TxtTotalPeso.Text = ""
            Me.TxtImporteTotal.Text = ""
            Me.oProveedores = New Class_CatProveedores
            Me.txtCentroCosto.Text = ""
            Me.lblCentroCosto.Text = ""

            Me.GeneraFolio()

        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Try
            Me.Grid.DataSource = Nothing
            FG_Grid_Limpiar(Me.Grid)

            Me.Grid.Rows = 2
            Me.Grid.Cols = 8

            Me.FormateaGrid()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            Me.Grid.Column(Me.igyCodigo).Width = 100
            Me.Grid.Column(Me.igyDescripcion).Width = 350
            Me.Grid.Column(Me.igyPesoUnidadBulto).Width = 70
            Me.Grid.Column(Me.igyPrecioUnidadBulto).Width = 70
            Me.Grid.Column(Me.igyCantidad).Width = 70
            Me.Grid.Column(Me.igyPesoBultosDetalle).Width = 70
            Me.Grid.Column(Me.igyImporteBultosDetalle).Width = 70

            Me.Grid.Cell(0, Me.igyCodigo).Text = "Código"
            Me.Grid.Cell(0, Me.igyDescripcion).Text = "Descripción"
            Me.Grid.Cell(0, Me.igyCantidad).Text = "Cantidad"
            Me.Grid.Cell(0, Me.igyPrecioUnidadBulto).Text = "Precio Unit."
            Me.Grid.Cell(0, Me.igyPesoUnidadBulto).Text = "Peso Unit."
            Me.Grid.Cell(0, Me.igyImporteBultosDetalle).Text = "Importe"
            Me.Grid.Cell(0, Me.igyPesoBultosDetalle).Text = "Peso total"

            Me.Grid.Column(Me.igyCantidad).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyCantidad).DecimalLength = 0 'Empresa_Sistema.DECIMALES_CANTIDAD
            Me.Grid.Column(Me.igyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPrecioUnidadBulto).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPrecioUnidadBulto).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
            Me.Grid.Column(Me.igyPrecioUnidadBulto).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPesoUnidadBulto).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPesoUnidadBulto).DecimalLength = Empresa_Sistema.DECIMALES_PESO_BULTOS
            Me.Grid.Column(Me.igyPesoUnidadBulto).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyImporteBultosDetalle).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyImporteBultosDetalle).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.igyImporteBultosDetalle).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyPesoBultosDetalle).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.igyPesoBultosDetalle).DecimalLength = Empresa_Sistema.DECIMALES_PESO_BULTOS
            Me.Grid.Column(Me.igyPesoBultosDetalle).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.igyCodigo).Locked = False
            Me.Grid.Column(Me.igyDescripcion).Locked = True
            Me.Grid.Column(Me.igyCantidad).Locked = False
            Me.Grid.Column(Me.igyPrecioUnidadBulto).Locked = False
            Me.Grid.Column(Me.igyPesoUnidadBulto).Locked = False
            Me.Grid.Column(Me.igyImporteBultosDetalle).Locked = True
            Me.Grid.Column(Me.igyPesoBultosDetalle).Locked = True

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Try
            Me.Estado = pEstado

            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    Me.tsbArmar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbDesarmarPalet.Enabled = False
                    Me.btnImprimirEtiquetasPalets.Enabled = True

                    Me.TxtFolio.Enabled = True
                    Me.DtpFecha.Enabled = True
                    Me.CboEmpaque.Enabled = True
                    Me.CboProductor.Enabled = True
                    Me.txtProveedor.Enabled = True
                    Me.CboLote.Enabled = True
                    Me.CboOrigen.Enabled = True
                    Me.chkEsChepPalet.Enabled = True
                    Me.txtCantidadPalets.Enabled = True
                    Me.lblDisplayEstado.Enabled = False
                    Me.CboEstatus.Enabled = False
                    Me.Grid.Locked = False
                    Me.gbGeneraraSalida.Enabled = True

                    Me.tsslEstado.Text = "Estado: Agregando nuevo movimiento"
                    Me.tssElaboro.Visible = False : Me.tssElaboro.Text = ""
                    Me.tssArmo.Visible = False : Me.tssArmo.Text = ""
                    Me.tssCancelo.Visible = False : Me.tssCancelo.Text = ""
                    If Me.Visible = True Then
                        Me.TxtFolio.Focus()
                    End If

                Case enumEstados.GRABADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    Me.tsbArmar.Enabled = True
                    Me.tsbCancelar.Enabled = True
                    Me.tsbDesarmarPalet.Enabled = False
                    Me.btnImprimirEtiquetasPalets.Enabled = True

                    Me.TxtFolio.Enabled = False
                    Me.DtpFecha.Enabled = True
                    Me.CboEmpaque.Enabled = True
                    Me.CboProductor.Enabled = True
                    Me.txtProveedor.Enabled = True
                    Me.CboLote.Enabled = True
                    Me.CboOrigen.Enabled = True
                    Me.chkEsChepPalet.Enabled = True
                    Me.txtCantidadPalets.Enabled = False
                    Me.lblDisplayEstado.Enabled = False
                    Me.CboEstatus.Enabled = False
                    Me.Grid.Locked = False
                    Me.gbGeneraraSalida.Enabled = True

                    Me.tsslEstado.Text = "Estado: Consultando movimiento"
                    Me.tssElaboro.Visible = True ': Me.tssElaboro.Text = "Elaboró: " + Me.oPaletsGlobal.NOMBRE_USUARIO_GRABO.ToUpper + " el " + Format(Me.oPaletsGlobal.FECHA, "dd/MMM/yyyy").ToUpper
                    Me.tssArmo.Visible = False : Me.tssArmo.Text = ""
                    Me.tssCancelo.Visible = False : Me.tssCancelo.Text = ""
                    Me.CboEmpaque.Focus()

                Case enumEstados.EMBARCADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbArmar.Enabled = False
                    Me.tsbDesarmarPalet.Enabled = False
                    Me.btnImprimirEtiquetasPalets.Enabled = True

                    Me.TxtFolio.Enabled = False
                    Me.DtpFecha.Enabled = False
                    Me.CboEmpaque.Enabled = False
                    Me.CboProductor.Enabled = False
                    Me.txtProveedor.Enabled = False
                    Me.CboLote.Enabled = False
                    Me.CboOrigen.Enabled = False
                    Me.chkEsChepPalet.Enabled = False
                    Me.txtCantidadPalets.Enabled = False
                    Me.lblDisplayEstado.Enabled = False
                    Me.CboEstatus.Enabled = False
                    Me.Grid.Locked = True
                    Me.gbGeneraraSalida.Enabled = False

                    Me.tsslEstado.Text = "Estado: Consultando movimiento"
                    Me.tssElaboro.Visible = True ': Me.tssElaboro.Text = "Elaboró: " + Me.oPaletsGlobal.NOMBRE_USUARIO_GRABO.ToUpper + " el " + Format(Me.oPaletsGlobal.FECHA, "dd/MMM/yyyy").ToUpper
                    Me.tssArmo.Visible = True ': Me.tssArmo.Text = "Armó : " + Me.oPaletsGlobal.NOMBRE_USUARIO_ARMADO.ToUpper + " el " + Format(Me.oPaletsGlobal.FECHA_ARMADO_SERVIDOR, "dd/MMM/yyyy").ToUpper
                    Me.tssCancelo.Visible = False : Me.tssCancelo.Text = ""
                    Me.tsbNuevo.Select()

                Case enumEstados.ARMADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbArmar.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.tsbDesarmarPalet.Enabled = True
                    Me.btnImprimirEtiquetasPalets.Enabled = True

                    Me.TxtFolio.Enabled = False
                    Me.DtpFecha.Enabled = False
                    Me.CboEmpaque.Enabled = False
                    Me.CboProductor.Enabled = False
                    Me.txtProveedor.Enabled = False
                    Me.CboLote.Enabled = False
                    Me.CboOrigen.Enabled = False
                    Me.chkEsChepPalet.Enabled = False
                    Me.txtCantidadPalets.Enabled = False
                    Me.lblDisplayEstado.Enabled = False
                    Me.CboEstatus.Enabled = False
                    Me.Grid.Locked = True
                    Me.gbGeneraraSalida.Enabled = False

                    Me.tsslEstado.Text = "Estado: Consultando movimiento"
                    Me.tssElaboro.Visible = True ' : Me.tssElaboro.Text = "Elaboró: " + Me.oPaletsGlobal.NOMBRE_USUARIO_GRABO.ToUpper + " el " + Format(Me.oPaletsGlobal.FECHA, "dd/MMM/yyyy").ToUpper
                    Me.tssArmo.Visible = True ' : Me.tssArmo.Text = "Armó : " + Me.oPaletsGlobal.NOMBRE_USUARIO_ARMADO.ToUpper + " el " + Format(Me.oPaletsGlobal.FECHA_ARMADO_SERVIDOR, "dd/MMM/yyyy").ToUpper
                    Me.tssCancelo.Visible = False : Me.tssCancelo.Text = ""
                    Me.tsbNuevo.Select()

                Case enumEstados.CANCELADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbArmar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbDesarmarPalet.Enabled = False
                    Me.btnImprimirEtiquetasPalets.Enabled = True

                    Me.TxtFolio.Enabled = False
                    Me.DtpFecha.Enabled = False
                    Me.CboEmpaque.Enabled = False
                    Me.CboProductor.Enabled = False
                    Me.txtProveedor.Enabled = False
                    Me.CboLote.Enabled = False
                    Me.CboOrigen.Enabled = False
                    Me.chkEsChepPalet.Enabled = False
                    Me.txtCantidadPalets.Enabled = False
                    Me.lblDisplayEstado.Enabled = False
                    Me.CboEstatus.Enabled = False
                    Me.Grid.Locked = True
                    Me.tssCancelo.Visible = True
                    Me.gbGeneraraSalida.Enabled = False

                    Me.tsslEstado.Text = "Estado: Consultando movimiento"
                    Me.tssElaboro.Visible = True ' : Me.tssElaboro.Text = "Elaboró: " + Me.oPaletsGlobal.NOMBRE_USUARIO_CANCELO.ToUpper + " el " + Format(Me.oPaletsGlobal.FECHA_CANCELO, "dd/MMM/yyyy").ToUpper
                    Me.tssArmo.Visible = False ' : Me.tssArmo.Text = "Armó : " + Me.oPaletsGlobal.NOMBRE_USUARIO_ARMADO.ToUpper + " el " + Format(Me.oPaletsGlobal.FECHA_ARMADO_SERVIDOR, "dd/MMM/yyyy").ToUpper
                    Me.tssCancelo.Visible = True
                    Me.tsbNuevo.Select()

            End Select

            Application.DoEvents()

        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try

    End Sub

    Private Function GestionaGrabar() As Boolean
        Dim bResultado As Boolean = False
        Dim i As Integer, iNumeroPalets As Integer

        Try
            iNumeroPalets = CInt(valorNumerico(Me.txtCantidadPalets.Text))

            If Me.ValidarPalet() = False Then
                Exit Function
            End If

            If txtLEN(Me.txtProveedor.Text) = False Then
                MsgBox("Asigne el proveedor de envase.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtProveedor.Focus()
                Exit Function
            End If

            If iNumeroPalets <= 0 Then
                MsgBox("Capture la cantidad de palets armados.", MsgBoxStyle.Information, Me.Text)
                Me.txtCantidadPalets.Focus()
                Exit Function
            End If

            If MsgBox("Deseas grabar los palets armados?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Grabar") = MsgBoxResult.No Then
                Exit Function
            End If

            If CInt(valorNumerico(Me.TxtTotalBultos.Text)) <= 0 Then
                MsgBox("No ha capturado el detalle de los productos.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            If txtLEN(Me.txtCentroCosto.Text) = False Then
                MsgBox("No ha capturado el centro de costo.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtCentroCosto.Focus()
                Return False
            Else
                Dim oCC As New Class_CatCentroCostos
                If oCC.EsCentroCostoProyectoSiembraActivo(Me.txtCentroCosto.Text) = False Then
                    MsgBox("El centro de costo no es parte del proyecto de siembra actual.", MsgBoxStyle.Exclamation, Me.Text)
                    Me.txtCentroCosto.Focus()
                    Return False
                End If
            End If

            If iNumeroPalets > 1 Then
                For i = 1 To iNumeroPalets
                    If Me.Grabar() = False Then
                        Exit Function
                    Else
                        Select Case i
                            Case 1
                                Me.txtFolioPalet1Etiquetas.Text = Me.TxtFolio.Text
                            Case iNumeroPalets
                                Me.txtFolioPalet2Etiquetas.Text = Me.TxtFolio.Text
                        End Select
                    End If
                Next
                bResultado = True
            ElseIf valorNumerico(Me.txtCantidadPalets.Text) = 1 Then
                bResultado = Me.Grabar()
                If bResultado = True Then
                    Me.txtFolioPalet1Etiquetas.Text = Me.TxtFolio.Text
                    Me.txtFolioPalet2Etiquetas.Text = Me.TxtFolio.Text
                End If
            End If

            If bResultado = True Then
                If iNumeroPalets > 1 Then
                    MsgBox("Palets grabados satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
                Else
                    MsgBox("Palet grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
                End If
            End If

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrabar", ex)
        End Try

        Return bResultado
    End Function

    Private Function Grabar() As Boolean
        Dim bResultado As Boolean = False
        Dim i As Integer

        If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
            Exit Function
        End If

        'faltan validaciones
        If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios("PLT" & Usuario.Codigo_Plaza) = False Then
            MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
            Exit Function
        End If

        If Me.ValidarProductoAgricola() = False Then
            Exit Function
        End If

        If Me.dtFechaCorte.Value > Me.DtpFecha.Value Then
            MsgBox("La fecha de corte debe ser menor a la fecha de empaque.", MsgBoxStyle.Exclamation, Me.Text)
            Exit Function
        End If

        Try
            With Me.oPaletsGlobal
                .FOLIO_PALET = Me.TxtFolio.Text
                .CODIGO_EMPAQUE = Me.CboEmpaque.SelectedValue.ToString
                .CODIGO_PRODUCTOR = Me.CboProductor.SelectedValue.ToString
                .CODIGO_PROVEEDOR_ENVASE = Me.txtProveedor.Text
                '.CODIGO_LOTE = Me.CboLote.SelectedValue.ToString
                .ORIGEN = Me.CboOrigen.Text
                .FECHA = Me.DtpFecha.Value
                .FECHA_CORTE = Me.dtFechaCorte.Value
                .ES_CHEP_PALET = Me.chkEsChepPalet.Checked
                .CANTIDAD_TOTAL_PALET = CInt(valorNumerico(Me.TxtTotalBultos.Text))
                .PESO_TOTAL_PALET = valorNumerico(Me.TxtTotalPeso.Text)
                .IMPORTE_TOTAL_PALET = valorNumerico(Me.TxtImporteTotal.Text)
                If Me.rdbSi.Checked = True Then
                    .GENERARA_SALIDA = "1"
                Else
                    .GENERARA_SALIDA = "0"
                End If

                Dim j As Integer, iRenglon As Integer = 0
                For j = 1 To Me.Grid.Rows - 1
                    If txtLEN(Me.Grid.Cell(j, Me.igyCodigo).Text) = True Then
                        iRenglon = iRenglon + 1
                    End If
                Next

                If iRenglon > 1 Then
                    .ES_MIXTO = Convert.ToInt32(True).ToString
                Else
                    .ES_MIXTO = Convert.ToInt32(False).ToString
                End If

                .CODIGO_CENTRO_COSTO = Me.txtCentroCosto.Text

                If Me.Estado = enumEstados.NUEVO Then
                    If .Insertar() = False Then
                        MsgBox("Error al tratar de insertar el palet armado.", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                    End If
                    Me.TxtFolio.Text = Me.oPaletsGlobal.FOLIO_PALET
                Else
                    If .Actualizar() = False Then
                        MsgBox("Error al tratar de actualizar el palet armado.", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                    End If
                End If

                'se graba el detalle
                For i = 1 To Me.Grid.Rows - 1
                    If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                        .NuevoRenglon()
                        .oPaletsDetalle.FOLIO_PALET = Me.oPaletsGlobal.FOLIO_PALET
                        .oPaletsDetalle.CODIGO_ARTICULO = Me.Grid.Cell(i, Me.igyCodigo).Text.ToUpper
                        .oPaletsDetalle.PESO_UNIDAD_BULTO = valorNumerico(Me.Grid.Cell(i, Me.igyPesoUnidadBulto).Text)
                        .oPaletsDetalle.CANTIDAD_BULTOS_DETALLE = CInt(Me.Grid.Cell(i, Me.igyCantidad).Text)
                        .oPaletsDetalle.PRECIO_UNIDAD_BULTO = valorNumerico(Me.Grid.Cell(i, Me.igyPrecioUnidadBulto).Text)
                        .oPaletsDetalle.PESO_BULTOS_DETALLE = valorNumerico(Me.Grid.Cell(i, Me.igyPesoBultosDetalle).Text)
                        .oPaletsDetalle.IMPORTE_BULTOS_DETALLE = valorNumerico(Me.Grid.Cell(i, Me.igyImporteBultosDetalle).Text)
                        If .oPaletsDetalle.GrabaDetallePalet() = False Then
                            MsgBox("Error al tratar de grabar el detalle.", MsgBoxStyle.Exclamation, Me.Text)
                            Exit Function
                        End If
                    End If
                Next

                bResultado = True
            End With

        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try

        Return bResultado
    End Function

    Private Function Armado(ByVal sFolioPalet As String, Optional ByVal bConfirmacion As Boolean = True) As Boolean
        Dim bResultado As Boolean = False

        If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
            Exit Function
        End If

        'faltan validaciones
        If (Usuario.PERMISO_ARMADO_PALET = "1" And Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios("PLT" & Usuario.Codigo_Plaza) = True) = False Then
            MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
            Exit Function
        End If

        If Me.ValidarProductoAgricola() = False Then
            Exit Function
        End If

        Try
            With Me.oPaletsGlobal
                .FOLIO_PALET = sFolioPalet

                If .Armado(True) = False Then
                    MsgBox("Error al tratar de armar el palet.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                End If

                bResultado = True

                If bConfirmacion = True Then
                    MsgBox("El palet a sido armado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "Armado", ex)
        End Try

        Return bResultado
    End Function

    Private Function Consultar(Optional ByVal bEsReferencia As Boolean = False) As Boolean
        Dim bResultado As Boolean = False
        Dim sFolio As String = Me.TxtFolio.Text
        Dim dTabla As DataTable
        Me.Inicializa()

        Try
            Me.oPaletsGlobal = New Class_Embarques_PaletsGlobal(sFolio)

            If Me.oPaletsGlobal.Existe = False Then
                Me.Cambia_Estado(enumEstados.NUEVO)
                Me.TxtFolio.Enabled = False
                Exit Function
            Else
                Me.TxtFolio.Enabled = False

                Me.TxtFolio.Text = Me.oPaletsGlobal.FOLIO_PALET
                'Me.DtpFecha.Value = CDate(Me.oPaletsGlobal.FECHA) 'Se cambio al final de la consulta para que pasara por Cambia_Estado y el ValueChanged del DtpFecha no cambiara la fecha despues de consultarlo
                Me.txtProveedor.Text = Me.oPaletsGlobal.CODIGO_PROVEEDOR_ENVASE
                Me.oProveedores = New Class_CatProveedores(Me.oPaletsGlobal.CODIGO_PROVEEDOR_ENVASE)
                Me.lblProveedor.Text = oProveedores.Nombre_Proveedor.ToUpper
                Me.CboEmpaque.SelectedValue = Me.oPaletsGlobal.CODIGO_EMPAQUE
                Me.CboProductor.SelectedValue = Me.oPaletsGlobal.CODIGO_PRODUCTOR
                'Me.CboLote.SelectedValue = Me.oPaletsGlobal.CODIGO_LOTE
                Me.CboOrigen.Text = Me.oPaletsGlobal.ORIGEN
                Me.chkEsChepPalet.Checked = Me.oPaletsGlobal.ES_CHEP_PALET
                Me.CboEstatus.SelectedIndex = CInt(Me.oPaletsGlobal.ESTA_EMBARCADO)
                Me.LblEstatus.Text = Me.oPaletsGlobal.ESTATUS.ToString
                Me.TxtTotalBultos.Text = FormatNumber(Me.oPaletsGlobal.CANTIDAD_TOTAL_PALET.ToString, 0)
                Me.TxtTotalPeso.Text = FormatNumber(Me.oPaletsGlobal.PESO_TOTAL_PALET.ToString, Empresa_Sistema.DECIMALES_PESO_BULTOS)
                Me.TxtImporteTotal.Text = FormatImporteContable(Me.oPaletsGlobal.IMPORTE_TOTAL_PALET)
                Me.txtCentroCosto.Text = Me.oPaletsGlobal.CODIGO_CENTRO_COSTO
                Dim oCentroCosto As New Class_CatCentroCostos(CInt(Me.oPaletsGlobal.CODIGO_CENTRO_COSTO))
                Me.lblCentroCosto.Text = oCentroCosto.NOMBRE_CENTRO_COSTO

                If Me.oPaletsGlobal.GENERARA_SALIDA = "0" Then
                    Me.rdbNo.Checked = True
                Else
                    Me.rdbSi.Checked = True
                End If

                dTabla = Me.oPaletsGlobal.ObtenerDetalle
                Me.Grid.Rows = 1
                For Each dRow As DataRow In dTabla.Rows
                    Me.Grid.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) & _
                                    dRow(5).ToString & Chr(9) & dRow(6).ToString & Chr(9))
                Next
                dTabla.Dispose()

                Me.FormateaGrid()
            End If

            Me.tssElaboro.Text = "Elaboró : " & Me.oPaletsGlobal.NOMBRE_USUARIO_GRABO & " el " & Format(Me.oPaletsGlobal.FECHA, "dd/MMM/yyyy hh:mm tt")
            If Me.oPaletsGlobal.ESTATUS = "C" Then
                Me.tssCancelo.Text = "Canceló : " & Me.oPaletsGlobal.NOMBRE_USUARIO_CANCELO & " el : " & Format(Me.oPaletsGlobal.FECHA_CANCELO, "dd/MMM/yyyy hh:mm tt")
            ElseIf Me.oPaletsGlobal.ESTATUS = "A" Then
                Me.tssArmo.Text = "Armó : " & Me.oPaletsGlobal.NOMBRE_USUARIO_ARMADO & " el : " & Format(Me.oPaletsGlobal.FECHA_ARMADO_SERVIDOR, "dd/MMM/yyyy hh:mm tt")
            End If

            bResultado = True
            Me.GestionaCambioEstado()

            If Me.CboEstatus.SelectedIndex.ToString = "1" Then
                Me.Cambia_Estado(enumEstados.EMBARCADO)
            End If
            Me.DtpFecha.Value = CDate(Me.oPaletsGlobal.FECHA)
            Me.dtFechaCorte.Value = CDate(Me.oPaletsGlobal.FECHA_CORTE)

        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try

        Return bResultado
    End Function

    Private Function Cancelar() As Boolean
        Dim bResultado As Boolean = False

        If MsgBox("Deseas cancelar el movimiento " & Me.TxtFolio.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "CancelaPalet") = MsgBoxResult.No Then
            Exit Function
        End If

        'If (Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios("PLT" & Usuario.Codigo_Plaza) = True And Usuario.PERMISO_ARMADO_PALET = "1") = False Then
        '    MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
        '    Exit Function
        'End If

        If Plaza.ValidarPeriodoTrabajo(Date.Now) = False Then 'Para cancelar se valida con la fecha de la maquina
            Exit Function
        End If

        Select Case Me.LblEstatus.Text
            Case "N"
                MsgBox("El documento no se ha grabado.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            Case "A", "G"
                If (Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios("PLT" & Usuario.Codigo_Plaza) = True And Usuario.PERMISO_ARMADO_PALET = "1") = False Then
                    MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
                    Exit Function
                End If
            Case "C"
                MsgBox("Los documentos cancelados no se pueden volver a cancelar.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
        End Select

        Try
            Me.oPaletsGlobal.FECHA_CANCELO = Now
            If Me.oPaletsGlobal.CancelarPalet() = False Then
                MsgBox("Error al intentar cancelar el palet.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            MsgBox("Palet cancelado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, "Cancelar", ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidarPalet() As Boolean
        Dim bResultado As Boolean = False

        Try
            If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
                Exit Function
            End If

            'Valia que se asigne un proveedor
            If txtLEN(Me.txtProveedor.Text) = True Then
                If Me.oProveedores.Existe = False Then
                    MsgBox("El proveedor de envases no existe.", MsgBoxStyle.Exclamation, "ValidarPalet")
                    Me.txtProveedor.Focus()
                    Exit Function
                Else
                    Me.lblProveedor.Text = Me.oProveedores.Nombre_Proveedor
                End If
            Else
                MsgBox("Asigne un proveedor de envases.", MsgBoxStyle.Exclamation, "ValidarPalet")
                Me.txtProveedor.Focus()
                Exit Function
            End If

            Dim i As Integer
            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                    If valorNumerico(Me.Grid.Cell(i, Me.igyPrecioUnidadBulto).Text) = 0 Then
                        MsgBox("El precio del artículo no es válido.", MsgBoxStyle.Exclamation, "Validación de productos")
                        Me.Grid.Cell(i, Me.igyPrecioUnidadBulto).SetFocus()
                        Exit Function
                    End If
                    If valorNumerico(Me.Grid.Cell(i, Me.igyPesoUnidadBulto).Text) = 0 Then
                        MsgBox("El peso del artículo no es válido.", MsgBoxStyle.Exclamation, "Validación de productos")
                        Me.Grid.Cell(i, Me.igyPesoUnidadBulto).SetFocus()
                        Exit Function
                    End If
                    If valorNumerico(Me.Grid.Cell(i, Me.igyCantidad).Text) = 0 Then
                        MsgBox("La cantidad del artículo no es válido.", MsgBoxStyle.Exclamation, "Validación de productos")
                        Me.Grid.Cell(i, Me.igyCantidad).SetFocus()
                        Exit Function
                    End If
                End If
            Next

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "ValidarPalet", ex)
        End Try

        Return bResultado
    End Function

    Private Sub DesplegarProductores()
        Try
            With Me.CboProductor
                .DisplayMember = "NOMBRE_PRODUCTOR"
                .ValueMember = "CODIGO_PRODUCTOR"
                Dim dView As New Data.DataView(Me.oProductores.ObtenerElementos())
                dView.Sort = "NOMBRE_PRODUCTOR DESC"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarProductores", ex)
        End Try
    End Sub

    Private Sub DesplegarEmpaques()
        Try
            Dim oElementos As New Class_CatEmpaques
            With Me.CboEmpaque
                .DisplayMember = "NOMBRE_EMPAQUE"
                .ValueMember = "CODIGO_EMPAQUE"
                Dim dView As New Data.DataView(oElementos.ObtenerElementosParaCapturaPalets)
                ' dView.Sort = "NOMBRE_EMPAQUE"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarEmpaques", ex)
        End Try
    End Sub

    Private Sub DesplegarLotes()
        Try
            With Me.CboLote
                .DisplayMember = "NOMBRE_LOTE"
                .ValueMember = "CODIGO_LOTE"
                Dim dView As New Data.DataView(Me.oLotes.ObtenerElementosActivos)
                dView.Sort = "NOMBRE_LOTE DESC"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarLotes", ex)
        End Try
    End Sub

    Private Sub Totales()
        Me.TxtTotalBultos.Text = FormatNumber(FG_Grid_SumaCol(Grid, Me.igyCantidad).ToString, 0)
        Me.TxtTotalPeso.Text = FormatNumber(FG_Grid_SumaCol(Grid, Me.igyPesoBultosDetalle).ToString, Empresa_Sistema.DECIMALES_PESO_BULTOS)
        Me.TxtImporteTotal.Text = FormatImporteContable(CDbl(FG_Grid_SumaCol(Grid, Me.igyImporteBultosDetalle).ToString))
    End Sub

    Private Sub GeneraFolio()
        Me.TxtFolio.Text = Me.oPaletsGlobal.FolioSiguiente
    End Sub

    Private Sub GestionaCambioEstado()
        Try
            Select Case Me.LblEstatus.Text
                Case "A"
                    Me.Cambia_Estado(enumEstados.ARMADO)
                Case "G"
                    Me.Cambia_Estado(enumEstados.GRABADO)
                Case "C"
                    Me.Cambia_Estado(enumEstados.CANCELADO)
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "GestionaCambioEstado", ex)
        End Try
    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim Columna As Integer, Renglon As Integer
        Dim StrCod As String, dCantidad As Double, dPesoUnidadBulto As Double, dPrecioUnidadBulto As Double, dImporteBultos As Double
        Dim oArticulos As Class_CatArticulos

        Try
            If Me.Estado = enumEstados.CANCELADO Or Me.Estado = enumEstados.EMBARCADO Or Me.Estado = enumEstados.ARMADO Then
                Exit Sub
            End If

            Columna = Me.Grid.Selection.FirstCol
            Renglon = Me.Grid.Selection.FirstRow
            StrCod = Me.Grid.Cell(Renglon, Me.igyCodigo).Text

            dCantidad = valorNumerico(Me.Grid.Cell(Renglon, Me.igyCantidad).Text)
            dPesoUnidadBulto = valorNumerico(Me.Grid.Cell(Renglon, igyPesoUnidadBulto).Text)
            dPrecioUnidadBulto = valorNumerico(Me.Grid.Cell(Renglon, igyPrecioUnidadBulto).Text)

            If Me.Grid.Column(Columna).Locked = True Then
                If Columna = Me.igyPesoBultosDetalle Then
                    If Me.Grid.Rows = Renglon + 1 Then
                        Me.Grid.Rows = Me.Grid.Rows + 1
                    End If
                End If

            End If

            Select Case e.KeyCode
                Case Keys.Enter
                    Select Case Columna

                        Case Me.igyCodigo
                            If txtLEN(StrCod) = False Then
                                GoTo BuscaArticulos
                                Exit Sub
                            End If
LlenaLinea:
                            oArticulos = New Class_CatArticulos(StrCod)
                            If oArticulos.Existe = False Then
                                Me.Grid.Cell(Renglon, Me.igyCodigo).Text = ""
                                GoTo BuscaArticulos
                                Exit Sub
                            End If

                            If Me.ValidarProductoAgricola(Renglon, Me.Grid.Cell(Renglon, Me.igyCodigo).Text) = False Then
                                Exit Sub
                            End If

                            Me.Grid.Cell(Renglon, Me.igyDescripcion).Text = oArticulos.DESCRIPCION
                            Me.Grid.Cell(Renglon, Me.igyPesoUnidadBulto).Text = oArticulos.PESO.ToString
                            Me.Grid.Cell(Renglon, Me.igyPrecioUnidadBulto).Text = oArticulos.PRECIO.ToString
                            Me.Grid.Cell(Renglon, Me.igyCantidad).Text = oArticulos.CANTIDAD_BULTOS_POR_PALET.ToString

                            dCantidad = valorNumerico(Me.Grid.Cell(Renglon, Me.igyCantidad).Text)
                            dPesoUnidadBulto = valorNumerico(Me.Grid.Cell(Renglon, igyPesoUnidadBulto).Text)
                            dPrecioUnidadBulto = valorNumerico(Me.Grid.Cell(Renglon, igyPrecioUnidadBulto).Text)

                            Me.Grid.Cell(Renglon, Me.igyPesoBultosDetalle).Text = (dCantidad * dPesoUnidadBulto).ToString

                            dImporteBultos = dCantidad * dPrecioUnidadBulto : dImporteBultos = Redondear(dImporteBultos, Empresa_Sistema.DECIMALES_CONTABILIDAD)
                            Me.Grid.Cell(Renglon, Me.igyImporteBultosDetalle).Text = dImporteBultos.ToString
                            Me.Totales()

                        Case Me.igyPesoUnidadBulto
                            If dPesoUnidadBulto <= 0 Then
                                MsgBox("El peso debe de ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
                                Me.Grid.Cell(Renglon, Me.igyPesoUnidadBulto).SetFocus()
                                Exit Sub
                            End If

                            dPesoUnidadBulto = valorNumerico(Me.Grid.Cell(Renglon, igyPesoUnidadBulto).Text)
                            Me.Grid.Cell(Renglon, Me.igyPesoBultosDetalle).Text = (dCantidad * dPesoUnidadBulto).ToString

                        Case Me.igyPrecioUnidadBulto
                            If dPrecioUnidadBulto <= 0 Then
                                MsgBox("El precio debe de ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
                                Me.Grid.Cell(Renglon, Me.igyPrecioUnidadBulto).SetFocus()
                                Exit Sub
                            End If

                            dPrecioUnidadBulto = valorNumerico(Me.Grid.Cell(Renglon, igyPrecioUnidadBulto).Text)
                            dImporteBultos = dCantidad * dPrecioUnidadBulto
                            dImporteBultos = Redondear(dImporteBultos, Empresa_Sistema.DECIMALES_CONTABILIDAD)
                            Me.Grid.Cell(Renglon, Me.igyImporteBultosDetalle).Text = dImporteBultos.ToString

                        Case Me.igyCantidad
                            If dCantidad <= 0 Then
                                MsgBox("La cantidad debe de ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
                                Me.Grid.Cell(Renglon, Me.igyCantidad).SetFocus()
                                Exit Sub
                            End If

                            dCantidad = valorNumerico(Me.Grid.Cell(Renglon, Me.igyCantidad).Text)

                            Me.Grid.Cell(Renglon, Me.igyPesoBultosDetalle).Text = (dCantidad * dPesoUnidadBulto).ToString

                            dImporteBultos = dCantidad * dPrecioUnidadBulto : dImporteBultos = Redondear(dImporteBultos, Empresa_Sistema.DECIMALES_CONTABILIDAD)
                            Me.Grid.Cell(Renglon, Me.igyImporteBultosDetalle).Text = dImporteBultos.ToString
                    End Select

                    Me.Totales()

                Case Keys.F6
                    If Me.Estado = enumEstados.CANCELADO Or Me.Estado = enumEstados.EMBARCADO Then
                        Exit Sub
                    End If
BuscaArticulos:
                    If Columna = Me.igyCodigo Then 'Columna del Codigo de Articulo
                        oArticulos = New Class_CatArticulos
                        StrCod = oArticulos.BusquedaVisualProductosAgricolas_PorDescripcion()
                        If txtLEN(StrCod) = True Then
                            Me.Grid.Cell(Renglon, Me.igyCodigo).Text = StrCod
                            GoTo LlenaLinea
                        End If
                    End If

                Case Keys.F8, Keys.Delete
                    If (Me.Estado = enumEstados.NUEVO Or Me.Estado = enumEstados.GRABADO) Then
                        If Me.Grid.Rows > 2 Then
                            Me.Grid.Selection.DeleteByRow()
                            e.SuppressKeyPress = True
                        Else
                            Me.Grid.Cell(Renglon, Me.igyCodigo).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyDescripcion).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyCantidad).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyPrecioUnidadBulto).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyPesoUnidadBulto).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyImporteBultosDetalle).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyPesoBultosDetalle).Text = ""
                        End If
                    End If
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrid", ex)
        End Try
    End Sub

    Private Function ValidarProductoAgricola(Optional ByVal Renglon As Integer = 2, Optional ByVal Codigo As String = "") As Boolean
        Dim bResultado As Boolean = False
        Dim i As Integer, j As Integer
        Dim sCodigoProducto As String = ""

        Try
            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                    Dim sql As New Class_find("SELECT CODIGO_ARTICULO,DESCRIPCION FROM VW_CAT_PRODUCTOS_AGRICOLAS WHERE CODIGO_ARTICULO='" & Me.Grid.Cell(i, Me.igyCodigo).Text & "'")
                    If sql.Result1 = "" Then
                        MsgBox("El artículo que intenta introducir en el renglón: " & i & " no existe o no es un producto agrícola, favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de productos")
                        Me.Grid.Cell(i, Me.igyCodigo).Text = ""
                        Me.Grid.Cell(i, Me.igyDescripcion).Text = ""
                        Me.Grid.Cell(i, Me.igyCodigo).SetFocus()
                        Exit Function
                    End If
                End If
            Next i

            If txtLEN(Codigo) = False Then
                For i = 1 To Me.Grid.Rows - 1
                    sCodigoProducto = Me.Grid.Cell(i, Me.igyCodigo).Text
                    For j = i + 1 To Me.Grid.Rows - 1
                        If txtLEN(Me.Grid.Cell(j, Me.igyCodigo).Text) = True Then
                            If sCodigoProducto = Me.Grid.Cell(j, Me.igyCodigo).Text And Me.Grid.Rows > 2 Then
                                MsgBox("El artículo que intenta introducir en el renglón:  " & i & " ya existe en el renglon " & j.ToString & ", favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de productos")
                                Me.Grid.Cell(i, Me.igyCodigo).SetFocus()
                                Exit Function
                            End If
                        End If
                    Next j
                    'sCodigoProducto = Me.Grid.Cell(i, Me.igyCodigo).Text
                Next i
            Else
                sCodigoProducto = Codigo

                For j = 1 To Renglon - 1 'Me.Grid.Rows - 1
                    If txtLEN(Me.Grid.Cell(j, Me.igyCodigo).Text) = True Then
                        If sCodigoProducto = Me.Grid.Cell(j, Me.igyCodigo).Text And Me.Grid.Rows > 2 Then
                            MsgBox("El artículo que intenta introducir en el renglón: " & Renglon & " ya existe en el renglon " & j.ToString & ", favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de productos")
                            Me.Grid.Cell(Renglon, Me.igyCodigo).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyDescripcion).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyCantidad).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyPrecioUnidadBulto).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyPesoUnidadBulto).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyImporteBultosDetalle).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyPesoBultosDetalle).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyCodigo).SetFocus()
                            Exit Function
                        End If
                    End If
                Next j

                For j = Renglon + 1 To Me.Grid.Rows - 1
                    If txtLEN(Me.Grid.Cell(j, Me.igyCodigo).Text) = True Then
                        If sCodigoProducto = Me.Grid.Cell(j, Me.igyCodigo).Text And Me.Grid.Rows > 2 Then
                            MsgBox("El artículo que intenta introducir en el renglón: " & Renglon & " ya existe en el renglon " & j.ToString & ", favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de productos")
                            Me.Grid.Cell(Renglon, Me.igyCodigo).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyDescripcion).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyCantidad).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyPrecioUnidadBulto).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyPesoUnidadBulto).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyImporteBultosDetalle).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyPesoBultosDetalle).Text = ""
                            Me.Grid.Cell(Renglon, Me.igyCodigo).SetFocus()
                            Exit Function
                        End If
                    End If
                Next j
            End If

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, "ValidarProductoAgricola", ex)
        End Try

        Return bResultado
    End Function

    Private Sub NavegadorPalets(ByVal sTipoDeBusqueda As String)
        Try
            Dim iFolio As Integer, sFolio As String
            If txtLEN(Me.TxtFolio.Text) = False Then
                Me.TxtFolio.Text = "0"
            End If

            If sTipoDeBusqueda = "Anterior" Then

                iFolio = CInt(Strings.Right(Me.TxtFolio.Text, 6))
                iFolio = iFolio - 1
                sFolio = "000000" + iFolio.ToString
                Me.TxtFolio.Text = sFolio.Substring(Len(sFolio) - 6)
                If Plaza.CODIGO_PLAZA <> 1 Then
                    Me.TxtFolio.Text = Plaza.Identificador + "-" + Me.TxtFolio.Text
                End If

                If iFolio > 0 Then
                    Me.Consultar()
                Else
                    Me.Cambia_Estado(enumEstados.NUEVO)
                    Me.Inicializa()
                End If
            ElseIf sTipoDeBusqueda = "Siguiente" Then
                iFolio = CInt(Strings.Right(Me.TxtFolio.Text, 6))
                iFolio = iFolio + 1
                sFolio = "000000" + iFolio.ToString
                Me.TxtFolio.Text = sFolio.Substring(Len(sFolio) - 6)
                If Plaza.CODIGO_PLAZA <> 1 Then
                    Me.TxtFolio.Text = Plaza.Identificador + "-" + Me.TxtFolio.Text
                End If

                If iFolio > 0 Then
                    If CInt(Strings.Right(Me.oPaletsGlobal.FolioSiguiente, 6)) <= iFolio Then
                        Me.Cambia_Estado(enumEstados.NUEVO)
                        Me.Inicializa()
                    Else
                        Me.Consultar()
                    End If
                End If
            End If
            Me.txtFolioPalet1Etiquetas.Text = Me.TxtFolio.Text
            Me.txtFolioPalet2Etiquetas.Text = Me.TxtFolio.Text

        Catch ex As Exception
            HandleError(Me.Name, "NavegadorPalets", ex)
        End Try
    End Sub

    Private Function GestionaArmado() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim sFolio1 As String, sFolio2 As String, i As Integer, iFolio1 As Integer, iFolio2 As Integer, rango As Integer

            If txtLEN(Me.txtFolioPalet1Etiquetas.Text) = False Then
                Me.txtFolioPalet1Etiquetas.Text = ""
            End If
            If txtLEN(Me.txtFolioPalet2Etiquetas.Text) = False Then
                Me.txtFolioPalet2Etiquetas.Text = ""
            End If

            sFolio1 = Me.txtFolioPalet1Etiquetas.Text
            sFolio2 = Me.txtFolioPalet2Etiquetas.Text

            Dim sql As New Class_find("SELECT 1 FROM EMB_PALETS_GLOBAL Where FOLIO_PALET BETWEEN '" & sFolio1 & "' AND '" & sFolio2 & "' AND ESTATUS='G'")
            If txtLEN(sql.Result1) = False Then
                MsgBox("El rango de palets seleccionado no se pueden armar.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            Else

                iFolio1 = CInt(Strings.Right(sFolio1, 6))
                iFolio2 = CInt(Strings.Right(sFolio2, 6))
                rango = iFolio2 - iFolio1

                For i = 1 To rango + 1
                    Dim sFolio As String = "000000" & iFolio1.ToString
                    sFolio = sFolio.Substring(Len(iFolio1.ToString), 6)

                    If Plaza.CODIGO_PLAZA <> 1 Then
                        sFolio = Plaza.Identificador + "-" + sFolio
                    End If
                    Me.oPaletsGlobal = New Class_Embarques_PaletsGlobal(sFolio)
                    If Me.oPaletsGlobal.ESTATUS = "G" Then
                        If Me.Armado(sFolio, False) = False Then
                            Exit Function
                        End If
                    End If
                    iFolio1 += 1
                Next
            End If

            bResultado = True

            If bResultado = True Then
                MsgBox("El rango de palets seleccionado a sido armado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            End If

        Catch ex As Exception
            HandleError(Me.Name, "GestonaArmado", ex)
        End Try

        Return bResultado
    End Function

    Private Function DesArmarPalet() As Boolean
        Dim bResultado As Boolean = False

        Try
            If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
                Exit Function
            End If

            'faltan validaciones
            If (Usuario.PERMISO_ARMADO_PALET = "1" And Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios("PLT" & Usuario.Codigo_Plaza) = True) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
                Exit Function
            End If

            If Me.ValidarProductoAgricola() = False Then
                Exit Function
            End If

            Select Case Me.LblEstatus.Text
                Case "N"
                    MsgBox("El palet no se ha grabado.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                Case "G"
                    MsgBox("El palet no esta armado no se pueden volver a desarmar.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                Case "A"
                    'No hay restricciones
                Case "C"
                    MsgBox("Los documentos cancelados no se pueden desarmar.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
            End Select

            With Me.oPaletsGlobal
                .FOLIO_PALET = Me.TxtFolio.Text
                If .Armado(False) = False Then
                    MsgBox("Error al tratar de desarmar el palet.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                End If

                bResultado = True

                MsgBox("El palet a sido desarmado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesArmarPalet", ex)
        End Try

        Return bResultado
    End Function

#End Region


End Class