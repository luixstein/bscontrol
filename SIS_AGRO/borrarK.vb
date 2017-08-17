Imports FlexCell

Public Class borrarK

    Private dtK As DataTable
    'Private dtL As DataTable

    Public oBorrarL As borrarL

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.CreaTablaK()

        'oBorrarL = New borrarL

        Me.SimulaCaptura()
    End Sub

    Private Sub CreaTablaK()
        Try
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

                .AcceptChanges()
            End With

            AddHandler dtK.RowDeleted, New DataRowChangeEventHandler(AddressOf Row_Deleted_K)

            'Me.dtL = New DataTable("L")
            'With Me.dtL
            '    .Columns.Add("IDA", GetType(Integer))
            '    .Columns.Add("IDK", GetType(Integer))
            '    .Columns.Add("IDL", GetType(Integer))
            '    .Columns.Add("ID_INVENTARIO_LOTES_COSTOS", GetType(String))
            '    .Columns.Add("CANTIDAD_USAR", GetType(Decimal))
            '    .Columns.Add("NS", GetType(String))

            '    .Columns("IDL").Unique = True
            '    .Columns("IDL").AutoIncrement = True
            '    .Columns("IDL").AutoIncrementSeed = 1
            '    .Columns("IDL").AutoIncrementStep = 1

            '    .AcceptChanges()
            'End With
        Catch ex As Exception
            HandleError(Me.Name, "CreaTablaK", ex)
        End Try
    End Sub

    Public Function RefrescaGridK(ByVal IDA As String) As Boolean
        Try
            Dim dView As New DataView(Me.dtK)
            dView.RowFilter = "IDA=" & IDA

            Me.gridK.AutoRedraw = False
            Me.gridK.DataSource = dView
            Me.gridK.DisplayFocusRect = False
            Me.gridK.Column(7).CellType = FlexCell.CellTypeEnum.Button 'L
            Me.gridK.AutoRedraw = True
            Me.gridK.Refresh()

            'Me.gridL.DataSource = Nothing
            'Me.gridL.Visible = False

        Catch ex As Exception
            HandleError(Me.Name, "RefrescaGridK", ex)
        End Try
    End Function

    'Public Function RefrescaGridLDesdeA(ByVal IDA As String) As Boolean
    '    Try
    '        Dim dView As New DataView(Me.dtL)
    '        dView.RowFilter = "IDA=" & IDA 'Filtra los lotes del gridA del elemento seleccionado
    '        Me.gridL.DataSource = dView

    '        If dView.Count = 0 Then
    '            MsgBox("cargar full l en blanco",, Me.Text)
    '        End If
    '    Catch ex As Exception
    '        HandleError(Me.Name, "RefrescaGridLDesdeA", ex)
    '    End Try
    'End Function

    'Public Function RefrescaGridLDesdeK(ByVal IDK As String) As Boolean
    '    Try
    '        Dim dView As New DataView(Me.dtL)
    '        dView.RowFilter = "IDK=" & IDK 'Filtra los lotes del gridK del elemento seleccionado
    '        Me.gridL.DataSource = dView

    '        If dView.Count = 0 Then
    '            MsgBox("falta cargar full l en rows en blanco para capturar",, Me.Text)
    '        End If
    '    Catch ex As Exception
    '        HandleError(Me.Name, "RefrescaGridLDesdeK", ex)
    '    End Try
    'End Function

    Public Function Elimina(ByVal IDA As String) As Boolean
        Try
            'Elimina los renglones del kit
            Dim foundRow As DataRow() = Me.dtK.Select("IDA=" & IDA)
            For Each row As DataRow In foundRow
                row.Delete()
            Next
            Me.dtK.AcceptChanges()

            'Elimina los renglones de los lotes de todo el kit
            Me.oBorrarL.EliminarDesdeA(IDA)
        Catch ex As Exception
            HandleError(Me.Name, "Elimina", ex)
        End Try
    End Function

    Private Sub SimulaCaptura()
        Try
            With Me.dtK
                .Rows.Add(1, Nothing, "ARTS", "DESCRI1", 2, 2, "")
                .Rows.Add(1, Nothing, "ARTN", "DESCRI2", 10, 10, "")

                .AcceptChanges()
            End With

            'With Me.dtL
            '    .Rows.Add(1, 1, Nothing, 500, 1, "S1")
            '    .Rows.Add(1, 1, Nothing, 501, 1, "S2")
            '    .Rows.Add(1, 1, Nothing, 600, 1, "S3")
            '    .Rows.Add(1, 1, Nothing, 601, 1, "S4")
            '    '.Rows.Add(1, 2, Nothing, 620, 6)'2DO r del k es nos por eso no se muestran, son peps
            '    '.Rows.Add(1, 2, Nothing, 777, 4)'2DO r del k es nos por eso no se muestran, son peps

            '    .Rows.Add(2, 0, Nothing, 700, 1, "S5")
            '    .Rows.Add(2, 0, Nothing, 701, 1, "S6")
            '    .Rows.Add(2, 0, Nothing, 702, 1, "S7")

            '    '.Rows.Add(3, 0, Nothing, 555, 50, Nothing)'3er r del gridA, es nos por eso no se muestran, son peps

            '    .AcceptChanges()
            'End With

        Catch ex As Exception
            HandleError(Me.Name, "InicializaTabla", ex)
        End Try
    End Sub

    Private Sub gridK_ButtonClick(Sender As Object, e As Grid.ButtonClickEventArgs) Handles gridK.ButtonClick
        Try
            Select Case e.Col.ToString
                Case "7" 'BOTON_L
                    If Me.gridK.ActiveCell.Row <= 0 Then
                        Return
                    End If

                    Me.oBorrarL.RefrescaGridLDesdeK(Me.gridK.Cell(Me.gridK.ActiveCell.Row, 2).Text)
                    Me.oBorrarL.ShowDialog()

            End Select
        Catch ex As Exception
            HandleError(Me.Name, "gridK_ButtonClick", ex)
        End Try
    End Sub

    Private Sub Row_Deleted_K(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        Try

            Dim IDK As String = e.Row("IDK", DataRowVersion.Original).ToString

            Me.oBorrarL.EliminarDesdeK(IDK)

        Catch ex As Exception
            HandleError("", "Row_Deleted_A", ex)
        End Try
    End Sub

End Class