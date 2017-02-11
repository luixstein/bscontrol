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

Public Class Frm_Nomina_ControlSUA

    Private igyDescripcion As Short = 1
    Private igyAbrir As Short = 2
    Private igyRuta As Short = 3

    Private Sub Frm_ControlSUA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Inicializa()
        AgregaBoton()
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub


#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.InicializaGrid()
            Me.Consultar()

        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        'Me.GridSUA.DataSource = Nothing
        'FG_Grid_Limpiar(Me.GridSUA)

        'Me.GridSUA.Rows = 2
        'Me.GridSUA.Cols = 4

        'Me.FormateaGrid()
    End Sub

    Private Sub FormateaGrid()
        'Me.GridSUA.Column(Me.igyDescripcion).Width = 100
        'Me.GridSUA.Column(Me.igyAbrir).Width = 100
        'Me.GridSUA.Column(Me.igyRuta).Width = 100

        'Me.GridSUA.Cell(0, Me.igyDescripcion).Text = "Descripcion"
        'Me.GridSUA.Cell(0, Me.igyAbrir).Text = ""
        'Me.GridSUA.Cell(0, Me.igyRuta).Text = "Ruta"

        'Me.GridSUA.Column(Me.igyAbrir).Mask = FlexCell.MaskEnum.Numeric
        'Me.GridSUA.Column(Me.igyAbrir).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
        'Me.GridSUA.Column(Me.igyAbrir).Alignment = FlexCell.AlignmentEnum.RightCenter

        'Me.GridSUA.Column(Me.igyAbrir).CellType = FlexCell.CellTypeEnum.Button

        'Me.GridSUA.Column(Me.igyRuta).Visible = False
        'Me.GridSUA.Column(Me.igyDescripcion).Locked = True
    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        'Dim Columna As Integer, Renglon As Integer
        'Dim StrCod As String


        'Columna = Me.GridSUA.Selection.FirstCol
        'Renglon = Me.GridSUA.Selection.FirstRow
        'StrCod = Me.GridSUA.Cell(Renglon, Me.igyAbrir).Text

        'Select Case e.KeyCode
        '    Case Keys.Enter
        '        Select Case Columna
        '            Case Me.igyAbrir

        '                If txtLEN(Me.GridSUA.Cell(Renglon, Me.igyAbrir).Text) = False Then
        '                    Exit Sub
        '                End If

        '                If txtLEN(StrCod) = False Then
        '                    MsgBox("Error al tratar de abri exe.", MsgBoxStyle.Critical, "Validación")
        '                    Exit Sub
        '                End If

        '            Case Me.igyDescripcion
        '                Exit Sub
        '        End Select

        '    Case Keys.F8, Keys.Delete
        '        e.SuppressKeyPress = True
        'End Select
    End Sub

    Private Function Consultar() As Boolean
        Dim dT As DataTable

        dT = Plaza.oSisPlazaNomina.ObtenerRutaSua
        'Me.GridSUA.Rows = 1
        'For Each dRow As DataRow In dT.Rows
        '    Me.GridSUA.AddItem(dRow(0).ToString & Chr(9) & "Abrir" & Chr(9) & dRow(1).ToString)
        'Next

        'If Me.GridSUA.Rows = 1 Then
        '    Me.GridSUA.Rows = 2
        'End If

        dgControlSua.DataSource = dT.DefaultView
        dgControlSua.Columns("RUTA_DB").Visible = False
    End Function

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgControlSua.CellContentClick
        Dim vdg As String, sExe As String
        Try
            If dgControlSua.Rows.Count > 0 Then
                vdg = Me.dgControlSua.Rows(e.RowIndex).Cells(2).Value().ToString
                If txtLEN(vdg) = False Then
                    Exit Sub
                End If
                sExe = vdg.Replace("MDB", "EXE")
                Process.Start(sExe)
            End If
        Catch ex As Exception
            HandleError(Me.Name, "dgControlSua.CellContentClick", ex)
        End Try
    End Sub

    Private Sub AgregaBoton()
        Dim _Boton As New DataGridViewButtonColumn()
        With _Boton
            .HeaderText = ""
            .Text = "Abrir"
            .UseColumnTextForButtonValue = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            .FlatStyle = FlatStyle.Standard
            .CellTemplate.Style.BackColor = Color.Honeydew
            .DisplayIndex = 1
        End With

        dgControlSua.Columns.Add(_Boton)

    End Sub

#End Region

    Private Sub GridSUA_ButtonClick(ByVal Sender As Object, ByVal e As FlexCell.Grid.ButtonClickEventArgs)
        'Dim Columna As Integer, Renglon As Integer, vdg As String, sExe As String

        'Columna = Me.GridSUA.Selection.FirstCol
        'Renglon = Me.GridSUA.Selection.FirstRow
        'Try

        '    vdg = Me.GridSUA.Cell(Renglon, Me.igyRuta).Text 'Grid.Rows(Renglon).Cell("FOLIO_POLIZA")
        '    If txtLEN(vdg) = False Then
        '        Exit Sub
        '    End If
        '    sExe = vdg.Replace("MDB", "EXE")
        '    Process.Start(sExe)

        'Catch ex As Exception
        '    HandleError(Me.Name, "GridSUA.ButtonClick", ex)
        'End Try
    End Sub

    Private Sub GridSUA_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Me.GestionaGrid(e)
        'Me.FormateaGrid()
    End Sub
End Class