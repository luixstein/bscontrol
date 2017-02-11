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

Public Class Frm_Embarques_CambiaPrecios
    Dim oCambiaPrecio As New Class_Embarques_CambiaPrecios
    Private oClientes As New Class_CatClientes
    Private oArticulos As New Class_CatArticulos
    Private Estado As enumEstados

    Private igyIDCambioPrecio As Short = 1
    Private igyCodigo As Short = 2
    Private igyDescripcion As Short = 3
    Private igyCantidadEmbarcada As Short = 4
    Private igyCantidadVendida As Short = 5
    Private igyPrecioUnidadBulto As Short = 6
    Private igyImporteEmbarcado As Short = 7
    Private igyImporteVendido As Short = 8
    Private igyAjuste As Short = 9

    Private Enum enumEstados
        NUEVO
        GRABADO
    End Enum

    Dim bFocoInicial As Boolean = False
#Region "Propiedades"

#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.TxtCliente.Focus()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Me.Grabar() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos de objetos"
#Region "Eventos"

    Private Sub Frm_Embarques_CambiaPrecios_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Me.bFocoInicial = False Then
            Me.TxtCliente.Focus()
            Me.bFocoInicial = True
        End If
    End Sub

    Private Sub Frm_Embarques_MastronardiCambiaPrecios_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DesplegarAños()
        Me.Inicializa()
        'Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub CboAnio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboAnio.SelectedIndexChanged
        Dim sql As Class_find
        sql = New Class_find("SELECT NUMERO_SEMANA FROM EMB_CAT_RANGOS_LOTES_MASTRONARDI WHERE '" & Format(CDate(Now.Day & "-" & Now.Month & "-" & Me.CboAnio.Text), "yyyy-dd-MM").ToString & "' BETWEEN FECHA1 AND FECHA2 ")
        Me.CboSemana.Refresh()
        If txtLEN(sql.Result1) = True Then
            Me.DesplegarSemanas()
            Me.CboSemana.Text = sql.Result1
        End If
        Me.Consultar()
    End Sub

    Private Sub CboSemana_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboSemana.SelectedIndexChanged
        If valorNumerico(Me.CboSemana.Text) > 0 Then
            Dim sql As Class_find
            sql = New Class_find("SELECT FECHA1,FECHA2 from EMB_CAT_RANGOS_LOTES_MASTRONARDI where AÑO=" & Me.CboAnio.Text & " And NUMERO_SEMANA = " & Me.CboSemana.Text.ToString)
            Me.DtpFecha1.Value = CDate(sql.Result1)
            Me.DtpFecha2.Value = CDate(sql.Result2)
            Me.Consultar()
        End If
    End Sub

    Private Sub TxtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCliente.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oClientes.BusquedaVisual_PorDescripcionZona("0001")
                If txtLEN(sText) = True Then Me.TxtCliente.Text = sText
            Case Keys.Enter
                If txtLEN(Me.TxtCliente.Text) = False Then
                    Me.lblNombreCliente.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.oClientes = New Class_CatClientes(Me.TxtCliente.Text)
                If Me.oClientes.Existe = False Then
                    Me.lblNombreCliente.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblNombreCliente.Text = Me.oClientes.NOMBRE_CLIENTE.ToString
                If Me.oClientes.CODIGO_TIPO_MERCADO.ToString <> "0001" Then
                    MsgBox("El cliente no es de mercado extranjero.", MsgBoxStyle.Information, Me.Text)
                    Me.TxtCliente.Text = "" : Me.lblNombreCliente.Text = "" : Me.TxtCliente.Focus()
                    Exit Sub
                End If

                Me.Grid.Locked = False
                Me.Consultar()
                Me.TxtCliente.Enabled = False

                Me.CboSemana.Focus()
        End Select
    End Sub

    Private Sub Grid_CellChange(ByVal Sender As Object, ByVal e As FlexCell.Grid.CellChangeEventArgs) Handles Grid.CellChange
        'Dim dImporteBultos As Double
        'If Me.Grid.ActiveCell.Col = Me.igyCantidadEmbarcada Then
        '    Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.igyPesoBultosDetalle).Text = (valorNumerico(Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.igyPesoUnidadBulto).Text) * valorNumerico(Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.igyCantidadEmbarcada).Text)).ToString
        '    dImporteBultos = CDbl((valorNumerico(Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.igyPrecioUnidadBulto).Text) * valorNumerico(Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.igyCantidadEmbarcada).Text)))
        '    dImporteBultos = Redondear(dImporteBultos, Empresa_Sistema.DECIMALES_CONTABILIDAD)
        '    Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.igyImporteBultosDetalle).Text = dImporteBultos.ToString
        '    Me.Totales()
        'ElseIf Me.Grid.ActiveCell.Col = Me.igyPesoUnidadBulto Then
        '    Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.igyPesoBultosDetalle).Text = (valorNumerico(Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.igyPesoUnidadBulto).Text) * valorNumerico(Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.igyCantidadEmbarcada).Text)).ToString
        '    Me.Totales()
        'ElseIf Me.Grid.ActiveCell.Col = Me.igyPrecioUnidadBulto Then
        '    dImporteBultos = CDbl((valorNumerico(Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.igyPrecioUnidadBulto).Text) * valorNumerico(Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.igyCantidadEmbarcada).Text)))
        '    dImporteBultos = Redondear(dImporteBultos, Empresa_Sistema.DECIMALES_CONTABILIDAD)
        '    Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.igyImporteBultosDetalle).Text = dImporteBultos.ToString
        '    Me.Totales()
        'End If
    End Sub

    Private Sub Grid_KeyPress(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Grid.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub Grid_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        If txtLEN(Me.TxtCliente.Text) = False Then
            Exit Sub
        End If
        Me.GestionaGrid(e)
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCliente.KeyPress
        txtNoBeep(e)
    End Sub
#End Region
#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.DtpFecha1.Value = Now
            Me.DtpFecha2.Value = Now
            Me.TxtCliente.Text = ""
            Me.lblNombreCliente.Text = ""

            Me.InicializaGrid()

            Me.txtImporteTotalEmbarcado.Text = ""
            Me.CboAnio.SelectedIndex = Now.Year - 2000
            Me.DesplegarSemanas()

            Me.TxtCliente.Enabled = True
            Me.Grid.Locked = True
        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Me.Grid.DataSource = Nothing
        FG_Grid_Limpiar(Me.Grid)

        Me.Grid.Rows = 2
        Me.Grid.Cols = 10

        Me.FormateaGrid()
    End Sub

    Private Sub FormateaGrid()
        Dim i As Integer

        Me.Grid.Column(Me.igyIDCambioPrecio).Visible = False
        Me.Grid.Column(Me.igyCodigo).Width = 70
        Me.Grid.Column(Me.igyDescripcion).Width = 300
        Me.Grid.Column(Me.igyPrecioUnidadBulto).Width = 80
        Me.Grid.Column(Me.igyCantidadEmbarcada).Width = 80
        Me.Grid.Column(Me.igyCantidadVendida).Width = 80
        Me.Grid.Column(Me.igyImporteEmbarcado).Width = 80
        Me.Grid.Column(Me.igyImporteVendido).Width = 80
        Me.Grid.Column(Me.igyAjuste).Width = 80

        Me.Grid.Cell(0, Me.igyCodigo).Text = "Código"
        Me.Grid.Cell(0, Me.igyDescripcion).Text = "Descripción"
        Me.Grid.Cell(0, Me.igyCantidadEmbarcada).Text = "Cant. emb."
        Me.Grid.Cell(0, Me.igyCantidadVendida).Text = "Cant. vda."
        Me.Grid.Cell(0, Me.igyPrecioUnidadBulto).Text = "Precio Unit."
        Me.Grid.Cell(0, Me.igyImporteEmbarcado).Text = "Importe emb."
        Me.Grid.Cell(0, Me.igyImporteVendido).Text = "Importe vdo."
        Me.Grid.Cell(0, Me.igyAjuste).Text = "Ajuste"

        Me.Grid.Column(Me.igyCantidadEmbarcada).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyCantidadEmbarcada).DecimalLength = 0
        Me.Grid.Column(Me.igyCantidadEmbarcada).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyCantidadVendida).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyCantidadVendida).DecimalLength = 0
        Me.Grid.Column(Me.igyCantidadVendida).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyPrecioUnidadBulto).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyPrecioUnidadBulto).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
        Me.Grid.Column(Me.igyPrecioUnidadBulto).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyAjuste).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyAjuste).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
        Me.Grid.Column(Me.igyAjuste).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyImporteEmbarcado).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyImporteEmbarcado).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
        Me.Grid.Column(Me.igyImporteEmbarcado).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyImporteVendido).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyImporteVendido).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
        Me.Grid.Column(Me.igyImporteVendido).Alignment = FlexCell.AlignmentEnum.RightCenter

        For i = 1 To Me.Grid.Rows - 1
            If (txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True) And (valorNumerico(Me.Grid.Cell(i, Me.igyCantidadEmbarcada).Text) > 0) Then
                Me.Grid.Cell(i, Me.igyCodigo).Locked = True
            End If
        Next i

        'Me.Grid.Column(Me.igyCodigo).Locked = False
        Me.Grid.Column(Me.igyIDCambioPrecio).Locked = True
        Me.Grid.Column(Me.igyDescripcion).Locked = True
        Me.Grid.Column(Me.igyCantidadEmbarcada).Locked = True
        Me.Grid.Column(Me.igyPrecioUnidadBulto).Locked = False
        Me.Grid.Column(Me.igyImporteEmbarcado).Locked = True
        Me.Grid.Column(Me.igyImporteVendido).Locked = True
        Me.Grid.Column(Me.igyAjuste).Locked = False
    End Sub

    Private Function Grabar() As Boolean
        Dim i As Integer

        'If Usuario.PERMISO_GRABAR_CAMBIO_PRECIO_MASTRONARDI = "0" Then
        '    MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
        '    Exit Function
        'End If

        If MsgBox("Deseas grabar la modificación de los precios de los productos?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Grabar") = MsgBoxResult.No Then
            Exit Function
        End If

        Try
            'VALIDAR QUE LA ZONA DEL CLIENTE SEA EXTRANCEJA
            Me.oClientes = New Class_CatClientes(Me.TxtCliente.Text)
            If Me.oClientes.Existe = False Then
                MsgBox("El cliente no existe.", MsgBoxStyle.Information, Me.Text) : Exit Function
                Exit Function
            End If
            If Me.oClientes.CODIGO_TIPO_MERCADO <> "0001" Then
                MsgBox("El cliente no es de mercado extranjero.", MsgBoxStyle.Information, Me.Text)
                Me.TxtCliente.Text = "" : Me.lblNombreCliente.Text = "" : Me.TxtCliente.Focus()
                Exit Function
            End If

            If Me.ValidarProductoAgricola() = False Then
                Exit Function
            End If

            With Me.oCambiaPrecio
                .AÑO = CInt(Me.CboAnio.Text)
                .NUMERO_SEMANA = CInt(Me.CboSemana.Text)
                .CODIGO_CLIENTE = Me.TxtCliente.Text

                For i = 1 To Me.Grid.Rows - 1
                    If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                        .CODIGO_ARTICULO = Me.Grid.Cell(i, Me.igyCodigo).Text.ToUpper
                        .CANTIDAD_EMBARCADA = valorNumerico(Me.Grid.Cell(i, Me.igyCantidadEmbarcada).Text)
                        .CANTIDAD_VENDIDA = valorNumerico(Me.Grid.Cell(i, Me.igyCantidadVendida).Text)
                        .PRECIO_UNIDAD_BULTO = valorNumerico(Me.Grid.Cell(i, Me.igyPrecioUnidadBulto).Text)
                        .IMPORTE_VENDIDO = valorNumerico(Me.Grid.Cell(i, Me.igyImporteVendido).Text)
                        .AJUSTES = valorNumerico(Me.Grid.Cell(i, Me.igyAjuste).Text)

                        If .CambiaPrecios() = False Then
                            MsgBox("Error al tratar de cambiar el precio del artículo " & Me.Grid.Cell(i, Me.igyCodigo).Text & " .", MsgBoxStyle.Exclamation, Me.Text)
                            Exit Function
                        End If
                    End If
                Next

                Grabar = True
                MsgBox("Cambios grabados satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            End With
        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try
    End Function

    Private Function Consultar(Optional ByVal bEsReferencia As Boolean = False) As Boolean
        Dim dTabla As DataTable

        Try
            Me.oCambiaPrecio = New Class_Embarques_CambiaPrecios()

            If Me.CboAnio.Text = "" Or Me.CboSemana.Text = "" Then
                Exit Function
            End If
            Me.oCambiaPrecio.AÑO = CInt(Me.CboAnio.Text)
            Me.oCambiaPrecio.NUMERO_SEMANA = CInt(Me.CboSemana.Text)
            Me.oCambiaPrecio.CODIGO_CLIENTE = Me.TxtCliente.Text

            dTabla = Me.oCambiaPrecio.ObtenerDetalle
            Me.Grid.Rows = 1
            For Each dRow As DataRow In dTabla.Rows
                Me.Grid.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) & dRow(5).ToString & Chr(9) & dRow(6).ToString & Chr(9) & dRow(7).ToString & Chr(9) & dRow(8).ToString & Chr(9))
            Next
            dTabla.Dispose()
            Me.Grid.Rows = Me.Grid.Rows + 1
            Me.FormateaGrid()

            Consultar = True
            Me.Totales()
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try
    End Function

    Private Sub DesplegarAños()
        Dim i As Integer, sAño As String
        Try
            For i = 0 To 100
                sAño = "000" + i.ToString
                Me.CboAnio.Items.Add("2" & sAño.Substring(Len(sAño) - 3).ToString)
            Next i
            Me.CboAnio.SelectedIndex = 0
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAños", ex)
        End Try
    End Sub

    Private Sub DesplegarSemanas()
        Try
            Dim oElementos As New Class_Embarques_CambiaPrecios
            Me.CboSemana.Refresh()
            With Me.CboSemana
                .DisplayMember = "NUMERO_SEMANA"
                .ValueMember = "NUMERO_SEMANA"
                Dim dView As New Data.DataView(oElementos.ObtenerSemanas(CStr(Me.CboAnio.SelectedIndex + 2000)))
                dView.Sort = "NUMERO_SEMANA"
                .DataSource = dView
                'If dView.Count > 0 Then
                '    .SelectedIndex = 0
                'End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarEmpaques", ex)
        End Try
    End Sub

    Private Sub Totales()
        Me.txtBultosTotalEmbarcados.Text = FormatNumber(FG_Grid_SumaCol(Grid, Me.igyCantidadEmbarcada).ToString, 0)
        Me.txtBultosTotalVendido.Text = FormatNumber(FG_Grid_SumaCol(Grid, Me.igyCantidadVendida).ToString, 0)
        Me.txtImporteTotalEmbarcado.Text = FormatImporteContable(CDbl(FG_Grid_SumaCol(Grid, Me.igyImporteEmbarcado).ToString))
        Me.txtImporteTotalVendido.Text = FormatImporteContable(CDbl(FG_Grid_SumaCol(Grid, Me.igyImporteVendido).ToString))
        Me.txtAjustesTotal.Text = FormatImporteContable(CDbl(FG_Grid_SumaCol(Grid, Me.igyAjuste).ToString))
    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim Columna As Integer, Renglon As Integer
        Dim StrCod As String, dCantidadEmbarcada As Double, dCantidadVendida As Double, dPrecioUnidadBulto As Double, dImporteBultos As Double, dImporteVendido As Double

        Columna = Me.Grid.Selection.FirstCol
        Renglon = Me.Grid.Selection.FirstRow
        StrCod = Me.Grid.Cell(Renglon, Me.igyCodigo).Text

        dCantidadEmbarcada = valorNumerico(Me.Grid.Cell(Renglon, Me.igyCantidadEmbarcada).Text)
        dCantidadVendida = valorNumerico(Me.Grid.Cell(Renglon, Me.igyCantidadVendida).Text)
        dPrecioUnidadBulto = valorNumerico(Me.Grid.Cell(Renglon, igyPrecioUnidadBulto).Text)

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

                    Case Me.igyCantidadVendida
                        If txtLEN(Me.Grid.Cell(Renglon, Me.igyCodigo).Text) = True Then
                            If valorNumerico(Me.Grid.Cell(Renglon, Me.igyCantidadVendida).Text) > 0 Then
                                dPrecioUnidadBulto = valorNumerico(Me.Grid.Cell(Renglon, igyPrecioUnidadBulto).Text)
                                dImporteBultos = dCantidadEmbarcada * dPrecioUnidadBulto
                                dImporteVendido = dCantidadVendida * dPrecioUnidadBulto
                                dImporteBultos = Redondear(dImporteBultos, Empresa_Sistema.DECIMALES_CONTABILIDAD)
                                dImporteVendido = Redondear(dImporteVendido, Empresa_Sistema.DECIMALES_CONTABILIDAD)
                                Me.Grid.Cell(Renglon, Me.igyImporteEmbarcado).Text = dImporteBultos.ToString
                                Me.Grid.Cell(Renglon, Me.igyImporteVendido).Text = dImporteVendido.ToString
                                Me.Totales()
                            Else
                                Me.Grid.Cell(Renglon, Me.igyCantidadVendida).Text = "0"
                            End If
                        Else
                            Me.Grid.Cell(Renglon, Me.igyCantidadVendida).Text = ""
                        End If

                        If Me.Grid.Rows > Renglon + 1 Then
                            '    Me.Grid.Cell(1, Me.igyCantidadVendida).SetFocus()
                            'Else
                            Me.Grid.Cell(Renglon + 1, Me.igyCantidadEmbarcada).SetFocus()
                        End If

                    Case Me.igyPrecioUnidadBulto
                        If txtLEN(Me.Grid.Cell(Renglon, Me.igyCodigo).Text) = True Then
                            If dPrecioUnidadBulto <= 0 And (dCantidadEmbarcada > 0 Or dCantidadVendida > 0) Then
                                MsgBox("El precio debe de ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
                                Me.Grid.Cell(Renglon, Me.igyPrecioUnidadBulto).SetFocus()
                                e.SuppressKeyPress = True
                                Exit Sub
                            End If

                            dPrecioUnidadBulto = valorNumerico(Me.Grid.Cell(Renglon, igyPrecioUnidadBulto).Text)
                            dImporteBultos = dCantidadEmbarcada * dPrecioUnidadBulto
                            dImporteVendido = dCantidadVendida * dPrecioUnidadBulto
                            dImporteBultos = Redondear(dImporteBultos, Empresa_Sistema.DECIMALES_CONTABILIDAD)
                            dImporteVendido = Redondear(dImporteVendido, Empresa_Sistema.DECIMALES_CONTABILIDAD)
                            Me.Grid.Cell(Renglon, Me.igyImporteEmbarcado).Text = dImporteBultos.ToString
                            Me.Grid.Cell(Renglon, Me.igyImporteVendido).Text = dImporteVendido.ToString
                            Me.Totales()
                        Else
                            Me.Grid.Cell(Renglon, Me.igyPrecioUnidadBulto).Text = ""
                        End If

                        If Me.Grid.Rows > Renglon + 1 Then
                            '    Me.Grid.Cell(1, Me.igyImporteVendido).SetFocus()
                            'Else
                            Me.Grid.Cell(Renglon + 1, Me.igyCantidadVendida).SetFocus()
                        End If

                    Case Me.igyAjuste
                        If txtLEN(Me.Grid.Cell(Renglon, Me.igyCodigo).Text) = True Then
                            If valorNumerico(Me.Grid.Cell(Renglon, Me.igyPrecioUnidadBulto).Text) > 0 Then
                                If Me.Grid.Rows = Renglon + 1 And txtLEN(Me.Grid.Cell(Renglon, Me.igyCodigo).Text) = True Then
                                    Me.Grid.Rows = Me.Grid.Rows + 1
                                End If
                                If txtLEN(Me.Grid.Cell(Renglon, Me.igyAjuste).Text) = False Then
                                    Me.Grid.Cell(Renglon, Me.igyAjuste).Text = "0"
                                    Me.Grid.Cell(Renglon + 1, Me.igyImporteVendido).SetFocus()
                                End If
                            End If
                        Else
                            Me.Grid.Cell(Renglon, Me.igyAjuste).Text = ""
                        End If

                        If Me.Grid.Rows > Renglon + 1 Then
                            Me.Grid.Cell(Renglon + 1, Me.igyImporteVendido).SetFocus()
                        End If
                End Select

            Case Keys.F6
BuscaArticulos:
                If Columna = Me.igyCodigo Then 'Columna del Codigo de Articulo
                    If valorNumerico(Me.Grid.Cell(Renglon, Me.igyCantidadEmbarcada).Text) > 0 Then
                        e.SuppressKeyPress = True
                        Exit Sub
                    Else
                        oArticulos = New Class_CatArticulos
                        StrCod = oArticulos.BusquedaVisualProductosAgricolas_PorDescripcion()
                        If txtLEN(StrCod) = True Then
                            Me.Grid.Cell(Renglon, Me.igyCodigo).Text = StrCod
                            GoTo LlenaLinea
                        End If
                    End If
                End If

            Case Keys.F8, Keys.Delete
                If Me.Grid.Rows > 2 Then
                    If valorNumerico(Me.Grid.Cell(Renglon, Me.igyIDCambioPrecio).Text) > 0 Then
                        If valorNumerico(Me.Grid.Cell(Renglon, Me.igyCantidadEmbarcada).Text) > 0 Then
                            MsgBox("No es posible eliminar este registro porque hay cantidad embarcada, pero si puede editar los datos que necesite cambiar.", MsgBoxStyle.Exclamation, Me.Text)
                        ElseIf Me.oCambiaPrecio.EliminaCambioPrecio(CInt(valorNumerico(Me.Grid.Cell(Renglon, Me.igyIDCambioPrecio).Text))) = True Then
                            Me.Grid.Selection.DeleteByRow()
                            e.SuppressKeyPress = True
                            Exit Sub
                        End If
                    Else
                        Me.Grid.Selection.DeleteByRow()
                    End If
                    e.SuppressKeyPress = True
                    'If valorNumerico(Me.Grid.Cell(Renglon, Me.igyCantidadEmbarcada).Text) > 0 Then
                    '    e.SuppressKeyPress = True
                    'Else
                    '    Me.Grid.Selection.DeleteByRow()
                    '    e.SuppressKeyPress = True
                    'End If
                Else
                    Me.Grid.Cell(Renglon, Me.igyIDCambioPrecio).Text = ""
                    Me.Grid.Cell(Renglon, Me.igyCodigo).Text = ""
                    Me.Grid.Cell(Renglon, Me.igyDescripcion).Text = ""
                    Me.Grid.Cell(Renglon, Me.igyCantidadEmbarcada).Text = ""
                    Me.Grid.Cell(Renglon, Me.igyCantidadVendida).Text = ""
                    Me.Grid.Cell(Renglon, Me.igyPrecioUnidadBulto).Text = ""
                    Me.Grid.Cell(Renglon, Me.igyImporteEmbarcado).Text = ""
                    Me.Grid.Cell(Renglon, Me.igyImporteVendido).Text = ""
                    Me.Grid.Cell(Renglon, Me.igyAjuste).Text = ""
                    Me.Grid.Cell(Renglon, Me.igyCodigo).SetFocus()
                End If
        End Select

        Me.Totales()
    End Sub

    Private Function ValidarProductoAgricola(Optional ByVal Renglon As Integer = 2, Optional ByVal Codigo As String = "") As Boolean
        Dim i As Integer, j As Integer
        Dim sCodigoProducto As String = ""

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
                        Me.Grid.Cell(Renglon, Me.igyCantidadEmbarcada).Text = ""
                        Me.Grid.Cell(Renglon, Me.igyCantidadVendida).Text = ""
                        Me.Grid.Cell(Renglon, Me.igyPrecioUnidadBulto).Text = ""
                        Me.Grid.Cell(Renglon, Me.igyImporteEmbarcado).Text = ""
                        Me.Grid.Cell(Renglon, Me.igyImporteVendido).Text = ""
                        Me.Grid.Cell(Renglon, Me.igyAjuste).Text = ""
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
                        Me.Grid.Cell(Renglon, Me.igyCantidadEmbarcada).Text = ""
                        Me.Grid.Cell(Renglon, Me.igyCantidadVendida).Text = ""
                        Me.Grid.Cell(Renglon, Me.igyPrecioUnidadBulto).Text = ""
                        Me.Grid.Cell(Renglon, Me.igyImporteEmbarcado).Text = ""
                        Me.Grid.Cell(Renglon, Me.igyImporteVendido).Text = ""
                        Me.Grid.Cell(Renglon, Me.igyAjuste).Text = ""
                        Me.Grid.Cell(Renglon, Me.igyCodigo).SetFocus()
                        Exit Function
                    End If
                End If
            Next j
        End If
        ValidarProductoAgricola = True
    End Function

#End Region

    Private Sub Grid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Grid.Load

    End Sub
End Class