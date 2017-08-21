Imports FlexCell

Public Class borrarA

    Private dtA As DataTable
    Private oBorrarK As borrarK
    Private oBorrarL As borrarL

    Private Sub borrarA_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CreaTablaA()
    End Sub

    Private Sub CreaTablaA()
        Try
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

            Me.SimulaCaptura()

            Me.gridA.AutoRedraw = False
            Me.gridA.DataSource = Me.dtA
            Me.gridA.DisplayFocusRect = False
            Me.gridA.Column(6).CellType = FlexCell.CellTypeEnum.Button 'BOTON_K
            Me.gridA.Column(7).CellType = FlexCell.CellTypeEnum.Button 'BOTON_L
            Me.gridA.AutoRedraw = True
            Me.gridA.Refresh()

            AddHandler dtA.RowDeleted, New DataRowChangeEventHandler(AddressOf Row_Deleted_A)

            AddHandler dtA.RowChanged, New DataRowChangeEventHandler(AddressOf Row_Changed_A)

            Me.oBorrarK = New borrarK
            Me.oBorrarL = New borrarL

        Catch ex As Exception
            HandleError(Me.Name, "CreaTablaA", ex)
        End Try
    End Sub

    Private Sub SimulaCaptura()
        Me.dtA.Rows.Add(Nothing, "K", "K1", 2, 2, "", "")
        Me.dtA.Rows.Add(Nothing, "ARTS", "DESCRI2", 3, 3, "", "")
        Me.dtA.Rows.Add(Nothing, "ARTN", "DESCRI3", 50, 50, "", "")
        Me.dtA.AcceptChanges()
    End Sub

    Private Sub gridA_ButtonClick(Sender As Object, e As Grid.ButtonClickEventArgs) Handles gridA.ButtonClick
        Try
            Select Case e.Col.ToString
                Case "6" 'BOTON_K
                    Me.oBorrarK.IDA = Me.gridA.Cell(Me.gridA.ActiveCell.Row, 1).Text 'Note que debe sacarse el valor y no de la tabla porque en la tabla si se borró un renglón este ya no existe
                    Me.oBorrarK.oBorrarL = Me.oBorrarL
                    Me.oBorrarK.RefrescaGridK()
                    Me.oBorrarK.ShowDialog()

                Case "7" 'BOTON_L
                    'Me.oBorrarK.RefrescaGridLDesdeA(Me.gridA.Cell(Me.gridA.ActiveCell.Row, 1).Text) 'Note que debe sacarse el valor y no de la tabla porque en la tabla si se borró un renglón este ya no existe
                    'Me.oBorrarK.ShowDialog()

                    'Me.oBorrarK.oBorrarL = Me.oBorrarL
                    Me.oBorrarK.IDA = Me.gridA.Cell(Me.gridA.ActiveCell.Row, 1).Text
                    Me.oBorrarL.IDA = Me.gridA.Cell(Me.gridA.ActiveCell.Row, 1).Text
                    Me.oBorrarL.RefrescaGridLDesdeA()
                    Me.oBorrarL.ShowDialog()

            End Select

        Catch ex As Exception
            HandleError("", "gridA_ButtonClick", ex)
        End Try
    End Sub

    Private Sub Row_Deleted_A(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        'Si eliminan un renglón de A
        Try
            Dim IDA As String = e.Row("IDA", DataRowVersion.Original).ToString
            Dim sCodigoArticulo As String = e.Row("CODIGO_ARTICULO", DataRowVersion.Original).ToString

            If sCodigoArticulo = "K" Then
                Me.oBorrarK.Elimina(IDA) 'Borra los renglones del kit y este dentro elimina los renglones de los lotes
            Else
                Me.oBorrarL.EliminarDesdeA(IDA) 'Borra los renglones de L
            End If

        Catch ex As Exception
            HandleError("", "Row_Deleted_A", ex)
        End Try
    End Sub

    Private Sub Row_Changed_A(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        Try
            Dim IDA As String = e.Row("IDA", DataRowVersion.Original).ToString

            If e.Row("CANTIDAD").ToString <> e.Row("CANTIDAD_ANTERIOR").ToString Then 'Si modifican la cantidad se eliminan los lotes(no el kit, sea o no kit)
                Me.oBorrarL.EliminarDesdeA(IDA)
            End If

        Catch ex As Exception
            HandleError("", "Row_Changed_A", ex)
        End Try
    End Sub

End Class