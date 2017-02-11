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

Public Class Frm_Embarques_CapturaDiariaProduccion
    Dim oCapturaDiariaProduccion As Class_Embarques_CapturaDiariaProduccion
    Private Estado As enumEstados

    Private igyCodgioTamaño As Short = 1
    Private igyTamaño As Short = 2
    Private igyCodigoEnvase As Short = 3
    Private igyEnvase As Short = 4
    Private igyProduccion As Short = 5

    Private Enum enumEstados
        NUEVO
        CONSULTA
    End Enum

#Region "Propiedades"

#End Region

#Region "Constructor y destructor"
    'Inicializa al objeto.
    Sub New()
        InitializeComponent()
        DesplegarCultivos()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region
#Region "Opciones"

#End Region

#Region "Eventos de objetos"
#Region "Eventos"

    Private Sub Frm_Emb_CapturaDiariaProduccion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Me.Inicializa()
            Me.Cambia_Estado(enumEstados.NUEVO)

            Me.Consultar()
        Catch ex As Exception
            HandleError(Me.Name, "Emb_CapturaDiariaProduccion_Load", ex)
        End Try
    End Sub

    Private Sub DtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpFecha.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.cboCultivo.Focus()
        End Select
    End Sub

    Private Sub cboCultivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCultivo.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.Grid.Cell(1, Me.igyProduccion).SetFocus()
        End Select
    End Sub

    Private Sub cboCultivo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCultivo.SelectedValueChanged
        If cboCultivo.SelectedIndex > -1 Then
            Me.Consultar()
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
        Me.Consultar()

        If Me.DtpFecha.Value = Now Then
            Me.Cambia_Estado(enumEstados.NUEVO)
        ElseIf Me.DtpFecha.Value < Now Then
            Me.Cambia_Estado(enumEstados.CONSULTA)
        ElseIf Me.DtpFecha.Value > Now Then
            Me.DtpFecha.Value = Now
        End If
    End Sub

#End Region

#Region "Eventos Genericos"
    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpFecha.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 'Handles txtCantidadPalets.KeyPress, TxtFolio.KeyPress, TxtTotalPeso.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpFecha.KeyPress
        txtNoBeep(e)
    End Sub
#End Region
#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try

            Me.DtpFecha.Value = Date.Now

            Me.cboCultivo.SelectedIndex = -1
            Me.InicializaGrid()
            'Me.oProveedores = New Class_CatProveedores

        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Me.Grid.DataSource = Nothing
        FG_Grid_Limpiar(Me.Grid)

        Me.Grid.Rows = 2
        Me.Grid.Cols = 6

        Me.FormateaGrid()
    End Sub

    Private Sub FormateaGrid()
        Me.Grid.Column(Me.igyTamaño).Width = 300
        Me.Grid.Column(Me.igyEnvase).Width = 200
        Me.Grid.Column(Me.igyProduccion).Width = 160

        Me.Grid.Cell(0, Me.igyTamaño).Text = "Tamaño"
        Me.Grid.Cell(0, Me.igyEnvase).Text = "Envase"
        Me.Grid.Cell(0, Me.igyProduccion).Text = "Produccion"

        Me.Grid.Column(Me.igyProduccion).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyProduccion).DecimalLength = 0 'Empresa_Sistema.DECIMALES_CANTIDAD
        Me.Grid.Column(Me.igyProduccion).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyCodgioTamaño).Visible = False
        Me.Grid.Column(Me.igyCodigoEnvase).Visible = False
        Me.Grid.Column(Me.igyTamaño).Locked = True
        Me.Grid.Column(Me.igyEnvase).Locked = True
        Me.Grid.Column(Me.igyProduccion).Locked = False

    End Sub

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Me.Estado = pEstado

        Select Case Me.Estado
            Case enumEstados.NUEVO

                Me.DtpFecha.Enabled = True
                Me.cboCultivo.Enabled = True
                Me.Grid.Locked = False

                Me.tsslEstado.Text = "Estado: Agregando nuevo movimiento"
                Me.tssElaboro.Visible = False : Me.tssElaboro.Text = ""

            Case enumEstados.CONSULTA

                Me.DtpFecha.Enabled = True
                Me.cboCultivo.Enabled = True
                Me.Grid.Locked = False

                Me.tsslEstado.Text = "Estado: Consultando movimiento"
                'Me.tssElaboro.Visible = True : Me.tssElaboro.Text = "Elaboró: " + Me.oCapturaDiariaProduccion.NOMBRE_USUARIO_GRABO.ToUpper + " el " + Format(Me.oCapturaDiariaProduccion.FECHA, "dd/MMM/yyyy").ToUpper
        End Select

        Application.DoEvents()
    End Sub

    Private Sub DesplegarCultivos()
        Dim oElementos As New Class_CatCultivos
        With Me.cboCultivo
            .DisplayMember = "NOMBRE_CULTIVO"
            .ValueMember = "CODIGO_CULTIVO"

            Dim dView As New Data.DataView(oElementos.ObtenerElementos)
            'dView.Sort = "NOMBRE_CULTIVO"
            .DataSource = dView
            .SelectedIndex = -1
        End With
    End Sub

    Private Function Grabar() As Boolean

        'If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.cboDocumento.SelectedValue.ToString) = False Then
        '    MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
        '    Exit Function
        'End If

        Try
            With Me.oCapturaDiariaProduccion
                'SE GRABA EL REGISTRO DE PRODUCCION DIARIA
                If txtLEN(Me.Grid.Cell(Grid.ActiveCell.Row, Me.igyProduccion).Text) = True Then

                    .FECHA = Me.DtpFecha.Value
                    .CODIGO_CULTIVO = Me.cboCultivo.SelectedValue.ToString
                    .CODIGO_TIPO_ENVASE = CInt(Me.Grid.Cell(Grid.ActiveCell.Row, Me.igyCodigoEnvase).Text.ToUpper)
                    .CODIGO_TIPO_TAMAÑO = CInt(Me.Grid.Cell(Grid.ActiveCell.Row, Me.igyCodgioTamaño).Text.ToUpper)
                    .CANTIDAD_BULTOS = CInt(Me.Grid.Cell(Grid.ActiveCell.Row, Me.igyProduccion).Text)

                    'If Me.Estado = enumEstados.NUEVO Then
                    Dim sql As New Class_find("SELECT 1 FROM EMB_CAPTURA_DIARIA_PRODUCCION C " & _
                                     "WHERE C.FECHA='" & Format(.FECHA, "yyyy-dd-MM").ToString & "' AND C.CODIGO_CULTIVO='" & .CODIGO_CULTIVO.ToString & "' AND " & _
                                     "C.CODIGO_TIPO_TAMAÑO=" & .CODIGO_TIPO_TAMAÑO.ToString & " AND C.CODIGO_TIPO_ENVASE='" & .CODIGO_TIPO_ENVASE & "' ")
                    If sql.Result1 = "" Then
                        If .Insertar() = False Then
                            MsgBox("Error al tratar de insertar el registro de producción diaria.", MsgBoxStyle.Exclamation, Me.Text)
                            Exit Function
                        End If
                    Else
                        If .Actualizar() = False Then
                            MsgBox("Error al tratar de actualizar el registro de producción diaria.", MsgBoxStyle.Exclamation, Me.Text)
                            Exit Function
                        End If
                    End If

                End If
                Grabar = True
            End With
        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try
    End Function

    Private Function Consultar() As Boolean
        Dim dTabla As DataTable
        If Me.cboCultivo.Visible = True And txtLEN(Me.cboCultivo.Text.ToString) = True Then
            Me.oCapturaDiariaProduccion = New Class_Embarques_CapturaDiariaProduccion() 'Me.DtpFecha.Value, Me.cboCultivo.SelectedValue.ToString)
            Try
                'Me.Grid.DataSource = Me.oCapturaDiariaProduccion.ObtenerDetalle(Me.cboCultivo.SelectedValue.ToString)
                'If Me.Validar() = False Then
                '    Me.Cambia_Estado(enumEstados.NUEVO)
                'Else
                '    Me.Cambia_Estado(enumEstados.CONSULTA)
                'End If

                dTabla = Me.oCapturaDiariaProduccion.ObtenerDetalle(Me.cboCultivo.SelectedValue.ToString, Format(Me.DtpFecha.Value, "yyyy-dd-MM")) '.Rows.Count
                Me.Grid.Rows = 1
                For Each dRow As DataRow In dTabla.Rows
                    Me.Grid.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9))
                Next

                Me.FormateaGrid()

            Catch ex As Exception
                HandleError(Me.Name, "Consultar", ex)
            End Try
        End If

    End Function

    Private Function BorraRegistro() As Boolean
        Try
            With Me.oCapturaDiariaProduccion
                'se graba el detalle
                If txtLEN(Me.Grid.Cell(Grid.ActiveCell.Row, Me.igyProduccion).Text) = True Then
                    .FECHA = Me.DtpFecha.Value
                    .CODIGO_CULTIVO = Me.cboCultivo.SelectedValue.ToString
                    .CODIGO_TIPO_ENVASE = CInt(Me.Grid.Cell(Grid.ActiveCell.Row, Me.igyCodigoEnvase).Text.ToUpper)
                    .CODIGO_TIPO_TAMAÑO = CInt(Me.Grid.Cell(Grid.ActiveCell.Row, Me.igyCodgioTamaño).Text.ToUpper)

                    If .Eliminar() = False Then
                        MsgBox("Error al tratar de insertar el palet armado.", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function

                    End If
                End If
                BorraRegistro = True
            End With
        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try

    End Function

    Private Sub Imprimir()
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            ' oReporte = New Class_Reporte(Me.oCompras.Nombre_Reporte, Rpt, False)
            'If Not oReporte.RptCargado Then
            '    Exit Sub
            'End If
            Rpt.SetParameterValue("@FECHA", Me.DtpFecha.Value)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.ShowDialog()
        Catch ex As Exception
            HandleError(Me.Name, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim Columna As Integer, Renglon As Integer
        Dim StrCod As String, dCantidad As Double

        Columna = Me.Grid.Selection.FirstCol
        Renglon = Me.Grid.Selection.FirstRow
        StrCod = Me.Grid.Cell(Renglon, Me.igyTamaño).Text

        dCantidad = valorNumerico(Me.Grid.Cell(Renglon, Me.igyProduccion).Text)

        Select Case e.KeyCode
            Case Keys.Enter
                Select Case Columna

                    Case Me.igyProduccion
                        If dCantidad = 0 Then
                            If BorraRegistro() = False Then
                                MsgBox("El registro no pudo ser eliminado.", MsgBoxStyle.Exclamation, Me.Text)
                            End If
                            Exit Sub
                        End If
                        Me.Grabar()
                End Select

        End Select
    End Sub

    'Private Function Validar(Optional ByVal Renglon As Integer = 2, Optional ByVal Codigo As String = "") As Boolean
    '    Dim i As Integer
    '    Dim sCodigoCultivo As String = ""

    '    For i = 1 To Me.Grid.Rows - 1
    '        If txtLEN(Me.Grid.Cell(i, Me.igyCodgioTamaño).Text) = True Then
    '            Dim sql As New Class_find("SELECT C.CANTIDAD_BULTOS PRODUCCION " & _
    '                                      "FROM EMB_CAPTURA_DIARIA_PRODUCCION C " & _
    '                                      "WHERE C.FECHA='" & Format(Me.DtpFecha.Value, "yyyy-dd-MM").ToString & "' AND C.CODIGO_CULTIVO='" & Me.cboCultivo.SelectedValue.ToString & "' AND " & _
    '                                      "C.CODIGO_TIPO_TAMAÑO=" & Me.Grid.Cell(i, Me.igyCodgioTamaño).Text & " AND C.CODIGO_TIPO_ENVASE='" & Me.Grid.Cell(i, Me.igyCodigoEnvase).Text & "' ")
    '            If txtLEN(sql.Result1) = True Then
    '                Me.Grid.Cell(i, Me.igyProduccion).Text = sql.Result1.ToString
    '                Validar = True
    '            End If
    '        End If
    '    Next i
    'End Function
#End Region

End Class