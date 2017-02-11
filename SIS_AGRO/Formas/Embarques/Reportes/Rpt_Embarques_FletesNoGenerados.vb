Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Embarques_FletesNoGenerados
    Private oPoliza As New Class_Contabilidad_Poliza_Global
    Private oEmbarque As New Class_Embarques_EmbarqueGlobal

    Private FormatoDeReporte As String = "RPT_EMBARQUES_FLETES_SIN_GENERAR"

    Private iGyFolioEmbarque As Integer = 1
    Private iGyFecha As Integer = 2
    Private iGyCliente As Integer = 3
    Private iGyProveedor As Integer = 4
    Private iGyImporte As Integer = 5
    Private iGyPosibleGenerarFlete As Integer = 6

#Region "Constructor y destructor"
    Public Sub New()
        InitializeComponent()

        Limpiar()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region

#Region "Opciones"
    Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
        Me.Consultar()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Private Sub Consultar()
        Dim StrSqlQuerry As String = ""
        Dim oReporte As New Class_Embarques_EmbarqueGlobal
        Dim dT As New DataTable

        With oReporte
            dT = .EmbarquesSinFletes

            Me.Grid.DataSource = dT

        End With
        oReporte = Nothing

        Me.FormateaGrid()
        Me.txtImporteTotal.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(iGyImporte)))
    End Sub

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)

            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@CODIGO_PLAZA", CInt(Usuario.Codigo_Plaza.ToString))

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Reporte de Fletes sin generar", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Sub InicializaGrid()
        Me.Grid.DataSource = Nothing
        FG_Grid_Limpiar(Grid)

        'Creamos el Grid
        Me.Grid.Rows = 2
        Me.Grid.Cols = 7
        Me.Grid.DisplayRowNumber = True

        Me.FormateaGrid()
    End Sub

    Private Sub FormateaGrid()

        Me.Grid.Cell(0, Me.iGyFolioEmbarque).Text = "FOLIO"
        Me.Grid.Cell(0, Me.iGyFecha).Text = "FECHA"
        Me.Grid.Cell(0, Me.iGyCliente).Text = "CLIENTE"
        Me.Grid.Cell(0, Me.iGyProveedor).Text = "PROVEEDOR"
        Me.Grid.Cell(0, Me.iGyImporte).Text = "IMPORTE"
        Me.Grid.Cell(0, Me.iGyPosibleGenerarFlete).Text = "PUEDE GENERAR FLETE"

        Me.Grid.Column(Me.iGyFecha).FormatString = ("dd/MMM/yy")
        Me.Grid.Column(Me.iGyImporte).FormatString = ("$ ###,###,###.00").ToString
        
        Me.Grid.Column(Me.iGyFecha).Alignment = FlexCell.AlignmentEnum.CenterCenter
        Me.Grid.Column(Me.iGyImporte).Alignment = FlexCell.AlignmentEnum.RightCenter
        Me.Grid.Column(Me.iGyPosibleGenerarFlete).Alignment = FlexCell.AlignmentEnum.CenterCenter

        Me.Grid.Column(Me.iGyFolioEmbarque).Width = 80
        Me.Grid.Column(Me.iGyFecha).Width = 70
        Me.Grid.Column(Me.iGyCliente).Width = 200
        Me.Grid.Column(Me.iGyProveedor).Width = 200
        Me.Grid.Column(Me.iGyImporte).Width = 90
        Me.Grid.Column(Me.iGyPosibleGenerarFlete).Width = 130

        Me.Grid.Column(Me.iGyFolioEmbarque).Locked = True
        Me.Grid.Column(Me.iGyFecha).Locked = True
        Me.Grid.Column(Me.iGyCliente).Locked = True
        Me.Grid.Column(Me.iGyProveedor).Locked = True
        Me.Grid.Column(Me.iGyImporte).Locked = True
        Me.Grid.Column(Me.iGyPosibleGenerarFlete).Locked = True

    End Sub

    Private Sub Limpiar()
       
        Me.txtImporteTotal.Text = "0.00"
        'Me.Grid.Rows.Clear()
    End Sub


    Private Sub tsbReactivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbReactivar.Click
        Try
            
            Dim i As Integer
            
            'GENERAR FLETE DE EMBARQUES
            For i = 1 To Me.Grid.Rows - 1 'Step CInt(Me.oInventario.Visible = True)
                If txtLEN(Me.Grid.Cell(i, Me.iGyFolioEmbarque).Text) = True Then

                    oEmbarque = New Class_Embarques_EmbarqueGlobal(Me.Grid.Cell(i, Me.iGyFolioEmbarque).Text)

                    If Me.Grid.Cell(i, Me.iGyPosibleGenerarFlete).Text = "SI" Then
                        Me.GeneraFlete(Me.Grid.Cell(i, Me.iGyFolioEmbarque).Text)
                    End If
                End If
            Next
            Me.Consultar()
            MsgBox("Se genraron los fletes de los embarques.", MsgBoxStyle.Information, "Generación de fletes")

        Catch ex As Exception
            HandleError(Me.Name, "GeneraFlete", ex)
        End Try

    End Sub

    Private Function GeneraFlete(ByVal sFolioEmbarque As String) As Boolean
        Dim slineaTransporte As New Class_CatLineasTransportes
        Dim sTransporte As New Class_CatTransportes

        sTransporte = New Class_CatTransportes(Me.oEmbarque.CODIGO_TRANSPORTE)

        Dim sql As New Class_find("SELECT L.IMPORTE_FLETE,L.NOMBRE_LUGAR_ENTREGA FROM EMB_EMBARQUE_GLOBAL E INNER JOIN CAT_LUGARES_ENTREGA L ON (E.CODIGO_LUGAR_ENTREGA=L.CODIGO_LUGAR_ENTREGA) WHERE FOLIO_EMBARQUE='" & Me.oEmbarque.FOLIO_EMBARQUE & "'")
        If valorNumerico(sql.Result1) <= 0 Then
            MsgBox("El importe de flete de " & sql.Result2 & " debe ser mayor a 0.", MsgBoxStyle.Exclamation, "Validación de fletes")
            Exit Function
        End If

        Dim sql1 As New Class_find("SELECT CUENTA_CONTABLE_FLETERO,NOMBRE_LINEA_TRANSPORTE FROM VW_CAT_TRANSPORTES_EXTENDIDOS WHERE CODIGO_TRANSPORTE='" & Me.oEmbarque.CODIGO_TRANSPORTE & "'")
        If txtLEN(sql1.Result1) = False Then
            MsgBox("La línea de transporte " & sql1.Result2 & " no tiene cuenta contable.", MsgBoxStyle.Exclamation, "Validación de fletes")
            Exit Function
        End If

        Try
            With Me.oEmbarque
                If Me.oEmbarque.FLETE_GENERADO = "0" Then
                    .FOLIO_EMBARQUE = sFolioEmbarque
                    If .GenerarFlete() = False Then
                        MsgBox("Error al tratar de generar el flete.", MsgBoxStyle.Critical, "Validación de fletes")
                        Exit Function
                    End If
                End If
            End With

            GeneraFlete = True
        Catch ex As Exception
            HandleError(Me.Name, "GeneraFlete", ex)
        End Try
    End Function
#End Region

#Region "Eventos de objetos"

#Region "Eventos Genericos"
    Private Sub txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oTexBox As TextBox = CType(sender, TextBox)
        oTexBox.SelectAll()
    End Sub

    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtImporteTotal.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtImporteTotal.KeyPress
        txtNoBeep(e)
        txtSoloNumerosEnteros(e)
    End Sub
#End Region

#Region "Keydown específicos"

#End Region

#End Region


End Class