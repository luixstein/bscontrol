Option Strict On

Public Class borrarL
    Private dtL As DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.CreaTablaL()

        Me.SimulaCaptura()
    End Sub

    Private Sub CreaTablaL()
        Try
            Me.dtL = New DataTable("L")
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

                .AcceptChanges()
            End With
        Catch ex As Exception
            HandleError(Me.Name, "CreaTablaL", ex)
        End Try
    End Sub

    Public Function RefrescaGridLDesdeA(ByVal IDA As String) As Boolean
        Try
            Dim dView As New DataView(Me.dtL)
            dView.RowFilter = "IDA=" & IDA

            'MsgBox(dView.Count.ToString)

            With Me.gridL
                .AutoRedraw = False
                .DataSource = dView
                .DisplayFocusRect = False
                .AutoRedraw = True
                .Refresh()
            End With

            'falta algo que valide si rows 0 para preparar series en blanco

        Catch ex As Exception
            HandleError(Me.Name, "RefrescaGridLDesdeA", ex)
        End Try
    End Function

    Public Function RefrescaGridLDesdeK(ByVal IDK As String) As Boolean
        Try
            Dim dView As New DataView(Me.dtL)
            dView.RowFilter = "IDK=" & IDK

            With Me.gridL
                .AutoRedraw = False
                .DataSource = dView
                .DisplayFocusRect = False
                .AutoRedraw = True
                .Refresh()
            End With

            'falta algo que valide si rows 0 para preparar series en blanco

        Catch ex As Exception
            HandleError(Me.Name, "RefrescaGridLDesdeK", ex)
        End Try
    End Function

    Private Sub SimulaCaptura()
        Try
            With Me.dtL
                .Rows.Add(1, 1, Nothing, 500, 1, "S1")
                .Rows.Add(1, 1, Nothing, 501, 1, "S2")
                .Rows.Add(1, 1, Nothing, 600, 1, "S3")
                .Rows.Add(1, 1, Nothing, 601, 1, "S4")
                '.Rows.Add(1, 2, Nothing, 620, 6)'2DO r del k es nos por eso no se muestran, son peps
                '.Rows.Add(1, 2, Nothing, 777, 4)'2DO r del k es nos por eso no se muestran, son peps

                .Rows.Add(2, 0, Nothing, 700, 1, "S5")
                .Rows.Add(2, 0, Nothing, 701, 1, "S6")
                .Rows.Add(2, 0, Nothing, 702, 1, "S7")

                '.Rows.Add(3, 0, Nothing, 555, 50, Nothing)'3er r del gridA, es nos por eso no se muestran, son peps

                .AcceptChanges()
            End With

        Catch ex As Exception
            HandleError(Me.Name, "InicializaTabla", ex)
        End Try
    End Sub

    Public Function EliminarDesdeA(ByVal IDA As String) As Boolean
        Try
            Dim foundRow As DataRow() = Me.dtL.Select("IDA=" & IDA)
            For Each row As DataRow In foundRow
                row.Delete()
            Next
            Me.dtL.AcceptChanges()
        Catch ex As Exception
            HandleError(Me.Name, "EliminarDesdeA", ex)
        End Try
    End Function

    Public Function EliminarDesdeK(ByVal IDK As String) As Boolean
        Try
            Dim foundRow As DataRow() = Me.dtL.Select("IDK=" & IDA)
            For Each row As DataRow In foundRow
                row.Delete()
            Next
            Me.dtL.AcceptChanges()
        Catch ex As Exception
            HandleError(Me.Name, "EliminarDesdeK", ex)
        End Try
    End Function
End Class