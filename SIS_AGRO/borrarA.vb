Public Class borrarA

    Private dtA As DataTable
    Private oBorrarK As borrarK

    Private Sub borrarA_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub CreaTablas()
        Try
            Me.dtA.Clear()
            Me.dtA = New DataTable("A")
            With Me.dtA
                .Columns.Add("IDA", GetType(Integer))
                .Columns.Add("CODIGO_ARTICULO", GetType(String))
                .Columns.Add("DESCRIPCION", GetType(String))
                .Columns.Add("CANTIDAD", GetType(Decimal))
                .Columns.Add("CANTIDAD_ANTERIOR", GetType(Decimal))
                .Columns.Add("BOTON_K", GetType(String))
                .Columns.Add("BOTON_L", GetType(String))

                .Columns("IDA").Unique = True
                .Columns("IDA").AutoIncrement = True
                .Columns("IDA").AutoIncrementSeed = 1
                .Columns("IDA").AutoIncrementStep = 1
                .AcceptChanges()
            End With

            Me.dtA.Rows.Add(Nothing, "K", "K1", 2, 2, "", "")
            Me.dtA.Rows.Add(Nothing, "ART2", "DESCRI2", 50, 50, "", "")

            Me.gridA.AutoRedraw = False
            Me.gridA.DataSource = Me.dtA
            Me.gridA.DisplayFocusRect = False
            Me.gridA.Column(6).CellType = FlexCell.CellTypeEnum.Button
            Me.gridA.Column(7).CellType = FlexCell.CellTypeEnum.Button
            Me.gridA.AutoRedraw = True
            Me.gridA.Refresh()

            Me.oBorrarK = New borrarK

        Catch ex As Exception
            HandleError(Me.Name, "CreaTablas", ex)
        End Try
    End Sub

    Private Sub gridA_ButtonClick(Sender As Object, e As Grid.ButtonClickEventArgs) Handles gridA.ButtonClick
        Try
            Select Case e.Col.ToString
                Case "6"
                    Dim dView As New DataView(Me.dtK)
                    dView.RowFilter = "IDA=" & Me.dtA.Rows(Me.gridA.ActiveCell.Row - 1)("IDA").ToString

                    Me.gridK.AutoRedraw = False
                    Me.gridK.DataSource = dView
                    Me.gridK.DisplayFocusRect = False
                    Me.gridK.Column(7).CellType = FlexCell.CellTypeEnum.Button 'L
                    Me.gridK.AutoRedraw = True
                    Me.gridK.Refresh()

                    Me.gridL.DataSource = Nothing

                Case "7"
                    Dim dView As New DataView(Me.dtL)
                    dView.RowFilter = "IDA=" & Me.dtA.Rows(Me.gridA.ActiveCell.Row - 1)("IDA").ToString

                    Me.gridL.DataSource = dView

            End Select

        Catch ex As Exception
            HandleError("", "gridA_ButtonClick", ex)
        End Try
    End Sub
End Class