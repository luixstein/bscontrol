Option Strict On
Imports FlexCell

Public Class borrar

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DataTableRowDeleted()
    End Sub

    Private Sub DataTableRowDeleted()
        Dim customerTable As DataTable = New DataTable("Customers")
        ' add columns
        customerTable.Columns.Add("id", Type.GetType("System.Int32"))
        customerTable.Columns.Add("name", Type.GetType("System.String"))
        customerTable.Columns.Add("address", Type.GetType("System.String"))
        ' set PrimaryKey
        customerTable.Columns("id").Unique = True
        customerTable.PrimaryKey = New DataColumn() {customerTable.Columns("id")}
        ' add a RowDeleted event handler for the table.
        AddHandler customerTable.RowDeleted, New DataRowChangeEventHandler(AddressOf Row_Deleted)
        ' add ten rows
        Dim id As Integer
        For id = 1 To 10
            customerTable.Rows.Add(New Object() {id, String.Format("customer{0}", id), String.Format("address{0}", id)})
        Next
        customerTable.AcceptChanges()
        ' Delete all the rows
        Dim row As DataRow
        For Each row In customerTable.Rows
            row.Delete()
        Next
    End Sub

    Private Sub Row_Deleted(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        Console.WriteLine("Row_Deleted Event: name={0}; action={1}", e.Row("name", DataRowVersion.Original), e.Action)
    End Sub
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Private dtK As DataTable
    Private dtA As DataTable, dtL As DataTable
    'Private WithEvents dtX As DataTable

    'Public Event RowChanged As DataRowChangeEventHandler
    'Public Event TableNewRow As DataTableNewRowEventHandler

    Private Sub Row_Deleted_A(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        Try
            'Console.WriteLine("Row_Deleted Event: name={0}; action={1}", e.Row("name", DataRowVersion.Original), e.Action)

            Dim IDA As String = e.Row("IDA", DataRowVersion.Original).ToString

            'Elimina los l por haber eliminado el A.
            Dim foundRow As DataRow() = Me.dtL.Select("IDA=" & IDA)
            'Dim foundRow As DataRow() = Me.dtL.Select("IDA=" & e.Row("IDA").ToString)'asi no funciona porque ese registro ya ni existe, falta decirle que queremos la versión original(antes de borrarse)
            For Each row As DataRow In foundRow
                row.Delete()
            Next

            'Elimina los K por haber eliminado el A.
            foundRow = Me.dtK.Select("IDA=" & IDA)
            For Each row As DataRow In foundRow
                row.Delete()
            Next
        Catch ex As Exception
            HandleError("", "Row_Deleted_A", ex)
        End Try
    End Sub

    Private Sub Row_Changed_A(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        Try
            'If e.Row("") Then
            'como saber que editaron solamente la cantidad, que no se ejecute por segunda vez al cambiar con código la cantidad anterior

            'MsgBox("Row_Changed Event: name=" & e.Row("IDA").ToString & "; action=" & e.Action, MsgBoxStyle.Information, Me.Text)

            If e.Row("CANTIDAD").ToString <> e.Row("CANTIDAD_ANTERIOR").ToString Then
                'MsgBox("CAMBIO DE " & e.Row("CANTIDAD_ANTERIOR").ToString & " A " & e.Row("CANTIDAD").ToString, vbInformation, Me.Text)

                'Elimina los l por haber cambiado la cantidad.
                Dim foundRow As DataRow() = Me.dtL.Select("IDA=" & e.Row("IDA").ToString)
                For Each row As DataRow In foundRow
                    row.Delete()
                Next

                e.Row("CANTIDAD_ANTERIOR") = e.Row("CANTIDAD") 'Esto va ejecutar otra vez este mismo evento(aparente ciclado) pero al ser ya iguales no entrará al if y ya no se ciclará.

            End If
        Catch ex As Exception
            HandleError("", "Row_Changed_A", ex)
        End Try
    End Sub

    Private Sub Row_Changed_K(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        Try
            'MsgBox("Row_Changed Event: name=" & e.Row("IDK").ToString & "; action=" & e.Action, MsgBoxStyle.Information, Me.Text)

            If e.Row("CANTIDAD").ToString <> e.Row("CANTIDAD_ANTERIOR").ToString Then
                'MsgBox("CAMBIO DE " & e.Row("CANTIDAD_ANTERIOR").ToString & " A " & e.Row("CANTIDAD").ToString, vbInformation, Me.Text)

                'Elimina los l por haber cambiado la cantidad.
                Dim foundRow As DataRow() = Me.dtL.Select("IDK=" & e.Row("IDK").ToString)
                For Each row As DataRow In foundRow
                    row.Delete()
                Next

                e.Row("CANTIDAD_ANTERIOR") = e.Row("CANTIDAD")
            End If
        Catch ex As Exception
            HandleError("", "Row_Changed_K", ex)
        End Try
    End Sub

    Private Sub Table_NewRow_K(ByVal sender As Object, ByVal e As DataTableNewRowEventArgs)
        'MsgBox("renglón nuevo en dtK", MsgBoxStyle.Information, Me.Text)
        e.Row("IDA") = Me.dtA.Rows(Me.gridA.ActiveCell.Row - 1)("IDA")
    End Sub

    Private Sub Table_NewRow_L(ByVal sender As Object, ByVal e As DataTableNewRowEventArgs)
        'MsgBox("renglón nuevo en dtL", MsgBoxStyle.Information, Me.Text)
        e.Row("IDA") = Me.dtK.Rows(Me.gridK.ActiveCell.Row - 1)("IDA")
        e.Row("IDK") = Me.dtK.Rows(Me.gridK.ActiveCell.Row - 1)("IDK")
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

                .Columns("IDA").Unique = True
                .Columns("IDA").AutoIncrement = True
                .Columns("IDA").AutoIncrementSeed = 1
                .Columns("IDA").AutoIncrementStep = 1

                .Rows.Add(Nothing, "K", "K1", 2, 2, "", "")
                .Rows.Add(Nothing, "ART2", "DESCRI2", 50, 50, "", "")

                .AcceptChanges()
            End With

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

                .Columns("IDK").Unique = True
                .Columns("IDK").AutoIncrement = True
                .Columns("IDK").AutoIncrementSeed = 1
                .Columns("IDK").AutoIncrementStep = 1

                .Rows.Add(1, Nothing, "ART1", "DESCRI1", 2, 2, "")
                .Rows.Add(1, Nothing, "ART2", "DESCRI2", 10, 10, "")

                .AcceptChanges()
            End With

            'Me.gridK.AutoRedraw = False
            'Me.gridK.DataSource = Me.dtK
            'Me.gridK.DisplayFocusRect = False
            'Me.gridK.Column(7).CellType = FlexCell.CellTypeEnum.Button
            'Me.gridK.AutoRedraw = True
            'Me.gridK.Refresh()

            '........................................................................

            Me.dtL.Clear()
            Me.dtL = New DataTable("L")

            AddHandler dtL.TableNewRow, New DataTableNewRowEventHandler(AddressOf Table_NewRow_L)

            With Me.dtL
                .Columns.Add("IDA", GetType(Integer))
                .Columns.Add("IDK", GetType(Integer))
                .Columns.Add("IDL", GetType(Integer))
                .Columns.Add("ID_INVENTARIO_LOTES_COSTOS", GetType(String))
                .Columns.Add("CANTIDAD_USAR", GetType(Decimal))
                .Columns.Add("NS", GetType(String))

                .Columns("IDL").Unique = True
                .Columns("IDL").AutoIncrement = True
                .Columns("IDL").AutoIncrementSeed = 1
                .Columns("IDL").AutoIncrementStep = 1

                .Rows.Add(1, 1, Nothing, 500, 1)
                .Rows.Add(1, 1, Nothing, 501, 1)

                .Rows.Add(1, 2, Nothing, 620, 6)
                .Rows.Add(1, 2, Nothing, 777, 4)

                .Rows.Add(2, 0, Nothing, 555, 50, Nothing)

                .AcceptChanges()
            End With

            AddHandler dtA.RowDeleted, New DataRowChangeEventHandler(AddressOf Row_Deleted_A)

            AddHandler dtA.RowChanged, New DataRowChangeEventHandler(AddressOf Row_Changed_A)

            AddHandler dtK.RowChanged, New DataRowChangeEventHandler(AddressOf Row_Changed_K)

            AddHandler dtK.TableNewRow, New DataTableNewRowEventHandler(AddressOf Table_NewRow_K)

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
                Case "6" 'BOTON_K
                    Dim dView As New DataView(Me.dtK)
                    dView.RowFilter = "IDA=" & Me.dtA.Rows(Me.gridA.ActiveCell.Row - 1)("IDA").ToString 'Filtra detalle del kit del articulo seleccionado.

                    Me.gridK.AutoRedraw = False
                    Me.gridK.DataSource = dView
                    Me.gridK.DisplayFocusRect = False
                    Me.gridK.Column(7).CellType = FlexCell.CellTypeEnum.Button 'L
                    Me.gridK.AutoRedraw = True
                    Me.gridK.Refresh()

                    Me.gridL.DataSource = Nothing

                Case "7" 'BOTON_L
                    Dim dView As New DataView(Me.dtL)
                    dView.RowFilter = "IDA=" & Me.dtA.Rows(Me.gridA.ActiveCell.Row - 1)("IDA").ToString 'Filtra detalle de los lotes del articulo seleccionado.

                    Me.gridL.DataSource = dView

            End Select

        Catch ex As Exception
            HandleError("", "gridA_ButtonClick", ex)
        End Try
    End Sub

    Private Sub gridK_ButtonClick(Sender As Object, e As Grid.ButtonClickEventArgs) Handles gridK.ButtonClick
        Try
            If e.Col = 7 Then 'BOTON_L
                If Me.gridK.ActiveCell.Row <= 0 Then
                    Return
                End If

                Dim dView As New DataView(Me.dtL)
                dView.RowFilter = "IDK=" & Me.dtK.Rows(Me.gridK.ActiveCell.Row - 1)("IDK").ToString 'Filtra detalle de los lotes del elemento del kit seleccionado.
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