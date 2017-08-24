Option Strict On

Public Class VentasDetalleLotes

#Region "Columnas grid"
    Private igyIDA As Short = 1
    Private igyIDK As Short = 2
    Private igyIDL As Short = 3
    Private igyID_INVENTARIO_LOTES_COSTOSO As Short = 4
    Private igyCANTIDAD_USAR As Short = 5
    Private igyNS As Short = 6
    Private igyCONFIRMACION As Short = 7
    Private igyCOSTO As Short = 8
    Private igyIMPORTE As Short = 9
#End Region

#Region "Campos"
    Private dtL As DataTable
    Private _IDA As String
    Private _IDK As String
    Private _CodigoArticulo As String
    Private _CodigoAlmacen As String
    Private _Cantidad As Decimal
#End Region

#Region "Propiedades"
    Public Property IDA As String
        Get
            Return Me._IDA
        End Get
        Set(value As String)
            Me._IDA = value
        End Set
    End Property

    Public Property IDK As String
        Get
            Return Me._IDK
        End Get
        Set(value As String)
            Me._IDK = value
        End Set
    End Property

    Public Property CodigoArticulo As String
        Get
            Return Me._CodigoArticulo
        End Get
        Set(value As String)
            Me._CodigoArticulo = value
        End Set
    End Property

    Public Property CodigoAlmacen As String
        Get
            Return Me._CodigoAlmacen
        End Get
        Set(value As String)
            Me._CodigoAlmacen = value
        End Set
    End Property

    Public Property Cantidad As Decimal
        Get
            Return Me._Cantidad
        End Get
        Set(value As Decimal)
            Me._Cantidad = value
        End Set
    End Property
#End Region

#Region "Opciones"

#End Region

#Region "Eventos"
    Private Sub borrarL_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.dtL.Rows.Count <> Me.gridL.Rows - 2 Then
            MsgBox("Falta confirmacion")
            e.Cancel = True
        End If
    End Sub

    Private Sub gridK_KeyDown(Sender As Object, e As KeyEventArgs) Handles gridL.KeyDown
        Me.GestionaGrid(e)
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.CreaTablaL()

        'Me.SimulaCaptura()
    End Sub

    Private Sub CreaTablaL()
        Try
            Me.dtL = New DataTable("L")
            With Me.dtL
                .Columns.Add("IDA", GetType(Integer))
                .Columns.Add("IDK", GetType(Integer))
                .Columns.Add("IDL", GetType(Integer))
                .Columns.Add("ID_INVENTARIO_LOTES_COSTOS", GetType(String))
                .Columns.Add("CANTIDAD_USAR", GetType(String))
                .Columns.Add("NS", GetType(String))
                .Columns.Add("CONFIRMACION", GetType(String))

                .Columns("IDL").Unique = True
                .Columns("IDL").AutoIncrement = True
                .Columns("IDL").AutoIncrementSeed = 1
                .Columns("IDL").AutoIncrementStep = 1

                .Columns("ID_INVENTARIO_LOTES_COSTOS").DefaultValue = ""
                .Columns("CANTIDAD_USAR").DefaultValue = ""
                .Columns("NS").DefaultValue = ""
                .Columns("CONFIRMACION").DefaultValue = "Sin confirmar"

                .AcceptChanges()
            End With

            AddHandler dtL.TableNewRow, New DataTableNewRowEventHandler(AddressOf Table_NewRow_L)
        Catch ex As Exception
            HandleError(Me.Name, "CreaTablaL", ex)
        End Try
    End Sub

    Public Function RefrescaGridLDesdeA() As Boolean
        Try
            Dim dView As New DataView(Me.dtL)
            dView.RowFilter = "IDA=" & Me._IDA

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

    Public Function RefrescaGridLDesdeK() As Boolean
        Try
            Dim dView As New DataView(Me.dtL)
            dView.RowFilter = "IDA=" & Me._IDA & " AND IDK=" & Me._IDK

            If dView.Count > 0 Then
                With Me.gridL
                    .AutoRedraw = False
                    .DataSource = dView
                    .DisplayFocusRect = False
                    .AutoRedraw = True
                    .Refresh()
                End With
            Else

                Dim dRow As DataRow

                If Me._Cantidad = 0 Then
                    MsgBox("No ha especificado la cantidad de series que se usarán.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                End If

                Dim oArticulo As New Class_CatArticulos(Me._CodigoArticulo)

                If oArticulo.Existe = True AndAlso oArticulo.ES_SERIALIZABLE = True AndAlso oArticulo.INVENTARIABLE = "1" Then
                    For j = 1 To Me._Cantidad
                        dRow = Me.dtL.NewRow

                        'dRow("POSICION") = i
                        'dRow("CODIGO_ARTICULO") = Me.Grid.Cell(i, Me.igyCODIGO_ARTICULO).Text
                        'dRow("DESCRIPCION") = Me.Grid.Cell(i, Me.igyDESCRIPCION).Text
                        'dRow("ID_INVENTARIO_LOTES_COSTOS") = ""
                        'dRow("NUMERO_SERIE") = ""

                        dRow("IDA") = Me._IDA
                        dRow("IDK") = Me._IDK
                        dRow("CANTIDAD_USAR") = "1"

                        Me.dtL.Rows.Add(dRow)
                    Next
                End If

                '.Columns.Add("IDA", GetType(Integer))
                '.Columns.Add("IDK", GetType(Integer))
                '.Columns.Add("IDL", GetType(Integer))
                '.Columns.Add("ID_INVENTARIO_LOTES_COSTOS", GetType(String))
                '.Columns.Add("CANTIDAD_USAR", GetType(Decimal))
                '.Columns.Add("NS", GetType(String))
                '.Columns.Add("CONFIRMACION", GetType(String))

                Me.dtL.AcceptChanges()

                Me.gridL.DataSource = Me.dtL

            End If

            Me.FormateaGrid()

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
            Dim foundRow As DataRow() = Me.dtL.Select("IDK=" & IDK)
            For Each row As DataRow In foundRow
                row.Delete()
            Next
            Me.dtL.AcceptChanges()
        Catch ex As Exception
            HandleError(Me.Name, "EliminarDesdeK", ex)
        End Try
    End Function

    Private Sub Table_NewRow_L(ByVal sender As Object, ByVal e As DataTableNewRowEventArgs)
        Try
            e.Row("IDA") = Me._IDA
            e.Row("IDK") = Me._IDK
            e.Row("CONFIRMACION") = "Sin confirmar"
        Catch ex As Exception
            HandleError(Me.Name, "Table_NewRow_L", ex)
        End Try
    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim Columna As Integer, Renglon As Integer
            'Dim StrCod As String, sCuentaContable As String = "", dCantidad As Decimal, dPrecio As Decimal, sCodigoCentroCosto As String
            'Dim oArticulos As Class_CatArticulos

            If Me.gridL.Selection.FirstRow = Me.gridL.Rows - 1 Then
                Return
            End If

            Columna = Me.gridL.Selection.FirstCol
            Renglon = Me.gridL.Selection.FirstRow

            Select Case e.KeyCode
                Case Keys.F6

                Case Keys.Enter
                    Select Case Columna
                        'Case Me.igyCANTIDAD
                            'If Me.gridK.Rows = Renglon + 1 Then Me.gridK.Rows = Me.gridK.Rows + 1
                        Case Me.igyCONFIRMACION
                            Me.gridL.Cell(Renglon, Columna).Text = "Confirmado"
                    End Select
                    'Me.dtK.AcceptChanges()
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrid", ex)
        End Try

    End Sub

    Private Sub FormateaGrid()
        Try
            With Me.gridL
                .AutoRedraw = False
                .DisplayFocusRect = False


                .Column(Me.igyIDA).Locked = True
                .Column(Me.igyIDK).Locked = True
                .Column(Me.igyIDL).Locked = True
                .Column(Me.igyID_INVENTARIO_LOTES_COSTOSO).Locked = False
                .Column(Me.igyCANTIDAD_USAR).Locked = True
                .Column(Me.igyNS).Locked = True
                .Column(Me.igyCONFIRMACION).Locked = True

                .AutoRedraw = True
                .Refresh()
            End With

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

#End Region

End Class
