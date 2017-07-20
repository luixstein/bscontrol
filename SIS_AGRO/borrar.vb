Option Strict On
Imports FlexCell

Public Class borrar

    Private dtA As DataTable, dtK As DataTable, dtL As DataTable
    'Private WithEvents dtX As DataTable

    Public Event RowChanged As DataRowChangeEventHandler
    Public Event TableNewRow As DataTableNewRowEventHandler

    Private Sub Row_Changed(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)

        'MsgBox("Row_Changed Event: name=" & e.Row("IDK").ToString & "; action=" & e.Action, MsgBoxStyle.Information, Me.Text)

        If e.Row("CANTIDAD").ToString <> e.Row("CANTIDAD_ANTERIOR").ToString Then
            'MsgBox("CAMBIO DE " & e.Row("CANTIDAD_ANTERIOR").ToString & " A " & e.Row("CANTIDAD").ToString, vbInformation, Me.Text)
            e.Row("CANTIDAD_ANTERIOR") = e.Row("CANTIDAD")

            'Elimina los l por haber cambiado la cantidad.
            Dim foundRow As DataRow() = Me.dtL.Select("IDK=" & e.Row("IDK").ToString)
            For Each row As DataRow In foundRow
                row.Delete()
            Next

        End If

    End Sub

    Private Sub Table_NewRow(ByVal sender As Object, ByVal e As DataTableNewRowEventArgs)
        'MsgBox("renglón nuevo en dtk", MsgBoxStyle.Information, Me.Text)
        e.Row("IDA") = Me.dtA.Rows(Me.gridA.ActiveCell.Row - 1)("IDA")
    End Sub


    Private Sub borrar_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.dtA = New DataTable("A")
        Me.dtK = New DataTable("K")
        Me.dtL = New DataTable("S")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try

            '........................................................................

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

            '........................................................................
            Me.dtK.Clear()
            Me.dtK = New DataTable("K")
            With Me.dtK
                .Columns.Add("IDA", GetType(Integer))
                .Columns.Add("IDK", GetType(Integer))
                .Columns.Add("CODIGO_ARTICULO", GetType(String))
                .Columns.Add("DESCRIPCION", GetType(String))
                .Columns.Add("CANTIDAD", GetType(Decimal))
                .Columns.Add("CANTIDAD_ANTERIOR", GetType(Decimal))
                .Columns.Add("BOTON_L", GetType(String))
            End With
            Me.dtK.Columns("IDK").AutoIncrement = True
            Me.dtK.Columns("IDK").AutoIncrementSeed = 1
            Me.dtK.Columns("IDK").AutoIncrementStep = 1
            Me.dtK.AcceptChanges()

            Me.dtK.Rows.Add(1, Nothing, "ART1", "DESCRI1", 2, 2, "")
            Me.dtK.Rows.Add(1, Nothing, "ART2", "DESCRI2", 10, 10, "")

            'Me.gridK.AutoRedraw = False
            'Me.gridK.DataSource = Me.dtK
            'Me.gridK.DisplayFocusRect = False
            'Me.gridK.Column(7).CellType = FlexCell.CellTypeEnum.Button
            'Me.gridK.AutoRedraw = True
            'Me.gridK.Refresh()

            '........................................................................

            Me.dtL.Clear()
            Me.dtL = New DataTable("L")
            With Me.dtL
                .Columns.Add("IDA", GetType(Integer))
                .Columns.Add("IDK", GetType(Integer))
                .Columns.Add("IDL", GetType(Integer))
                .Columns.Add("ID_INVENTARIO_LOTES_COSTOS", GetType(String))
                .Columns.Add("CANTIDAD_USAR", GetType(Decimal))
                .Columns.Add("NS", GetType(String))
            End With
            Me.dtL.Columns("IDL").AutoIncrement = True
            Me.dtL.Columns("IDL").AutoIncrementSeed = 1
            Me.dtL.Columns("IDL").AutoIncrementStep = 1
            Me.dtL.AcceptChanges()



            ' add a RowChanged event handler for the table.
            AddHandler dtK.RowChanged, New DataRowChangeEventHandler(AddressOf Row_Changed)

            AddHandler dtK.TableNewRow, New DataTableNewRowEventHandler(AddressOf Table_NewRow)

            Me.dtL.Rows.Add(1, 1, Nothing, 500, 1)
            Me.dtL.Rows.Add(1, 1, Nothing, 501, 1)

            Me.dtL.Rows.Add(1, 2, Nothing, 620, 6)
            Me.dtL.Rows.Add(1, 2, Nothing, 777, 4)

            Me.dtL.Rows.Add(2, 0, Nothing, 555, 50, Nothing)

            'Me.gridL.DataSource = Me.dtL

        Catch ex As Exception
            HandleError("", "Button1_Click", ex)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim s As String = ""
        Try
            's = Me.dtk.Rows.Count.ToString
            s = Me.dtK.Rows(Me.gridK.ActiveCell.Row - 1)("CODIGO_ARTICULO").ToString

            MsgBox(s)
        Catch ex As Exception
            HandleError("", "Button2_Click", ex)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Try
            If Me.gridK.ActiveCell.Row <= 0 Then
                Return
            End If

            Dim dView As New DataView(Me.dtL)
            dView.RowFilter = "IDK=" & Me.dtK.Rows(Me.gridK.ActiveCell.Row - 1)("IDK").ToString
            Me.gridL.DataSource = dView

            'Me.gridL.DataSource = Me.dtL.Select("IDK=" & Me.dtk.Rows(Me.gridK.ActiveCell.Row - 1)("IDK").ToString).CopyToDataTable
        Catch ex As Exception
            HandleError("", "Button3_Click", ex)
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

    Private Sub gridK_ButtonClick(Sender As Object, e As Grid.ButtonClickEventArgs) Handles gridK.ButtonClick
        Try
            If e.Col = 7 Then
                If Me.gridK.ActiveCell.Row <= 0 Then
                    Return
                End If

                Dim dView As New DataView(Me.dtL)
                dView.RowFilter = "IDK=" & Me.dtK.Rows(Me.gridK.ActiveCell.Row - 1)("IDK").ToString
                Me.gridL.DataSource = dView

                If dView.Count = 0 Then
                    MsgBox("cargar full l",, Me.Text)
                End If

            End If

        Catch ex As Exception
            HandleError("", "gridK_ButtonClick", ex)
        End Try
    End Sub
End Class