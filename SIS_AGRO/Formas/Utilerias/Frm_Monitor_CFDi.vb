Public Class Frm_Monitor_CFDi

    Private igyFolio As Short = 1
    Private igyTipo As Short = 2
    Private igyFecha As Short = 3
    Private igyProblema As Short = 4
    Private igyTiempoRestante As Short = 5

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.consultar()
    End Sub

    Private Function consultar() As Boolean
        Dim dTabla1 As DataTable
        Dim dTabla2 As DataTable

        dTabla1 = Empresa_Sistema.ObtenDocumentosSinTimbrar()

        dTabla2 = Empresa_Sistema.ObtenDocumentosCanceladosSinTimbrar()

        Me.InicializaGrid()
        Me.InicializaGridCancelados()

        Me.Grid1.Rows = 1
        For Each dRow As DataRow In dTabla1.Rows
            Me.Grid1.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9))
        Next

        Me.Grid2.Rows = 1
        For Each dRow As DataRow In dTabla2.Rows
            Me.Grid2.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9))
        Next

        If dTabla1.Rows.Count < 1 Or dTabla2.Rows.Count < 1 Then
            Me.LblDocumentosSinTimbrar.Text = "No existen documentos sin timbrar."
        Else
            Me.LblDocumentosSinTimbrar.Text = ""
        End If

        If Me.Grid1.Rows = 1 Then
            Me.Grid1.Rows = 2
        End If

        If Me.Grid2.Rows = 1 Then
            Me.Grid2.Rows = 2
        End If

        Me.FormateaGrid()
        Me.FormateaGridCancelados()
    End Function

    Private Sub InicializaGrid()
        Me.Grid1.DataSource = Nothing
        FG_Grid_Limpiar(Me.Grid1)
        Me.Grid1.Rows = 2
        Me.Grid1.Cols = 6
        Me.FormateaGrid()
    End Sub

    Private Sub InicializaGridCancelados()
        Me.Grid2.DataSource = Nothing
        FG_Grid_Limpiar(Me.Grid2)
        Me.Grid2.Rows = 2
        Me.Grid2.Cols = 6
        Me.FormateaGridCancelados()
    End Sub

    Private Sub FormateaGrid()
        Me.Grid1.Column(Me.igyFolio).Width = 90
        Me.Grid1.Column(Me.igyTipo).Width = 120
        Me.Grid1.Column(Me.igyFecha).Width = 150
        Me.Grid1.Column(Me.igyProblema).Width = 150
        Me.Grid1.Column(Me.igyTiempoRestante).Width = 100

        Me.Grid1.Cell(0, Me.igyFolio).Text = "Folio"
        Me.Grid1.Cell(0, Me.igyTipo).Text = "Tipo"
        Me.Grid1.Cell(0, Me.igyFecha).Text = "Fecha"
        Me.Grid1.Cell(0, Me.igyProblema).Text = "Problema"
        Me.Grid1.Cell(0, Me.igyTiempoRestante).Text = "Horas para timbrar"

        Me.Grid1.Column(Me.igyFecha).CellType = FlexCell.CellTypeEnum.DateTime
        Me.Grid1.Column(Me.igyFecha).FormatString = "dd-MMM-yy hh:mm tt"

        Me.Grid1.Column(Me.igyFolio).Locked = False
        Me.Grid1.Column(Me.igyTipo).Locked = False
        Me.Grid1.Column(Me.igyFecha).Locked = False
        Me.Grid1.Column(Me.igyProblema).Locked = False
        Me.Grid1.Column(Me.igyTiempoRestante).Locked = False
    End Sub

    Private Sub FormateaGridCancelados()
        Me.Grid2.Column(Me.igyFolio).Width = 90
        Me.Grid2.Column(Me.igyTipo).Width = 120
        Me.Grid2.Column(Me.igyFecha).Width = 150
        Me.Grid2.Column(Me.igyProblema).Width = 150
        Me.Grid2.Column(Me.igyTiempoRestante).Width = 100

        Me.Grid2.Cell(0, Me.igyFolio).Text = "Folio"
        Me.Grid2.Cell(0, Me.igyTipo).Text = "Tipo"
        Me.Grid2.Cell(0, Me.igyFecha).Text = "Fecha"
        Me.Grid2.Cell(0, Me.igyProblema).Text = "Problema"
        Me.Grid2.Cell(0, Me.igyTiempoRestante).Text = "Horas para timbrar"

        Me.Grid2.Column(Me.igyFecha).CellType = FlexCell.CellTypeEnum.DateTime
        Me.Grid2.Column(Me.igyFecha).FormatString = "dd-MMM-yy hh:mm tt"

        Me.Grid2.Column(Me.igyFolio).Locked = False
        Me.Grid2.Column(Me.igyTipo).Locked = False
        Me.Grid2.Column(Me.igyFecha).Locked = False
        Me.Grid2.Column(Me.igyProblema).Locked = False
        Me.Grid2.Column(Me.igyTiempoRestante).Locked = False
    End Sub

    Private Sub Frm_Monitor_CFDi_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InicializaGrid()
        Me.InicializaGridCancelados()

        Me.consultar()
    End Sub

End Class
