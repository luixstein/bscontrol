Imports FlexCell

Public Class borrarK

#Region "Columnas grid ventas"
    Private igyIDA As Short = 1
    Private igyIDK As Short = 2
    Private igyCODIGO_ARTICULO As Short = 3
    Private igyDESCRIPCION As Short = 4
    Private igyCANTIDAD As Short = 5
    Private igyCANTIDAD_ANTERIOR As Short = 6
    Private igyBOTON_L As Short = 7
    Private igyCONFIRMACION As Short = 8
#End Region

    Private dtK As DataTable

    Public oBorrarL As borrarL

    Private _IDA As String

    Public Property IDA As String
        Get
            Return Me._IDA
        End Get
        Set(value As String)
            Me._IDA = value
        End Set
    End Property

#Region "Opciones"

#End Region

#Region "Eventos"
    Private Sub borrarK_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Me.dtK.AcceptChanges()
        If Me.dtK.Rows.Count <> Me.gridK.Rows - 2 Then
            MsgBox("Falta confirmacion")
            e.Cancel = True
        End If
        'Me.gridK.
    End Sub

    Private Sub gridK_KeyDown(Sender As Object, e As KeyEventArgs) Handles gridK.KeyDown
        Me.GestionaGrid(e)
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.CreaTablaK()
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
                .Columns.Add("CONFIRMACION", GetType(String))

                .Columns("IDK").Unique = True
                .Columns("IDK").AutoIncrement = True
                .Columns("IDK").AutoIncrementSeed = 1
                .Columns("IDK").AutoIncrementStep = 1

                .AcceptChanges()
            End With

            AddHandler dtK.RowDeleted, New DataRowChangeEventHandler(AddressOf Row_Deleted_K)
            AddHandler dtK.RowChanged, New DataRowChangeEventHandler(AddressOf Row_Changed_K)
            AddHandler dtK.TableNewRow, New DataTableNewRowEventHandler(AddressOf Table_NewRow_K)

        Catch ex As Exception
            HandleError(Me.Name, "CreaTablaK", ex)
        End Try
    End Sub

    Public Function RefrescaGridK() As Boolean
        Try
            Dim dView As New DataView(Me.dtK)
            dView.RowFilter = "IDA=" & Me._IDA

            Me.gridK.DataSource = dView

            Me.FormateaGrid()
        Catch ex As Exception
            HandleError(Me.Name, "RefrescaGridK", ex)
        End Try
    End Function

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

                    Me.oBorrarL.IDA = Me._IDA
                    Me.oBorrarL.IDK = Me.gridK.Cell(Me.gridK.ActiveCell.Row, Me.igyIDK).Text
                    Me.oBorrarL.RefrescaGridLDesdeK()
                    Me.oBorrarL.ShowDialog()

            End Select
        Catch ex As Exception
            HandleError(Me.Name, "gridK_ButtonClick", ex)
        End Try
    End Sub

    Private Sub Row_Deleted_K(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        Try
            'Si eliminan un renglón de K se eliminan sus hijos del L(tienen que volver a detallar L)
            'MsgBox(e.Row.RowState.ToString)
            Try
                Dim IDK As String = e.Row("IDK", DataRowVersion.Original).ToString
                Me.oBorrarL.EliminarDesdeK(IDK)
            Catch ex As Exception

            End Try

        Catch ex As Exception
            HandleError("", "Row_Deleted_K", ex)
        End Try
    End Sub

    Private Sub Row_Changed_K(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        Try
            If e.Row("CANTIDAD").ToString <> e.Row("CANTIDAD_ANTERIOR").ToString Then

                'Si modifican un renglón de K se eliminan sus hijos del L(tienen que volver a detallar L)
                Try
                    Dim IDK As String = e.Row("IDK", DataRowVersion.Original).ToString
                    Me.oBorrarL.EliminarDesdeK(IDK)
                Catch ex As Exception

                End Try

                e.Row("CANTIDAD_ANTERIOR") = e.Row("CANTIDAD")
            End If
        Catch ex As Exception
            HandleError("", "Row_Changed_K", ex)
        End Try
    End Sub

    Private Sub Table_NewRow_K(ByVal sender As Object, ByVal e As DataTableNewRowEventArgs)
        'MsgBox("renglón nuevo en dtK", MsgBoxStyle.Information, Me.Text)
        Try
            e.Row("IDA") = Me._IDA
            e.Row("DESCRIPCION") = ""
            e.Row("CONFIRMACION") = "Sin confirmar"
        Catch ex As Exception
            HandleError("", "Table_NewRow_K", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            With Me.gridK
                .AutoRedraw = False
                .DisplayFocusRect = False

                .Column(Me.igyIDA).Width = 50
                .Column(Me.igyIDK).Width = 50
                .Column(Me.igyCODIGO_ARTICULO).Width = 75
                .Column(Me.igyDESCRIPCION).Width = 250
                .Column(Me.igyCANTIDAD).Width = 75
                .Column(Me.igyCANTIDAD_ANTERIOR).Width = 75
                .Column(Me.igyBOTON_L).Width = 50

                .Cell(0, Me.igyCODIGO_ARTICULO).Text = "Código"
                .Cell(0, Me.igyDESCRIPCION).Text = "Descripción"
                .Cell(0, Me.igyCANTIDAD).Text = "Cantidad"
                .Cell(0, Me.igyBOTON_L).Text = "Lotes"

                .Column(Me.igyCANTIDAD).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyCANTIDAD).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.igyCANTIDAD).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyIDA).Locked = True
                .Column(Me.igyIDK).Locked = True
                .Column(Me.igyDESCRIPCION).Locked = True
                .Column(Me.igyCANTIDAD_ANTERIOR).Locked = True
                .Column(Me.igyCONFIRMACION).Locked = True

                .Column(Me.igyIDA).Visible = False
                .Column(Me.igyIDK).Visible = False
                .Column(Me.igyCANTIDAD_ANTERIOR).Visible = False
                .Column(Me.igyIDA).Visible = False

                .Column(Me.igyBOTON_L).CellType = CellTypeEnum.Button

                .AutoRedraw = True
                .Refresh()
            End With

        Catch ex As Exception
            HandleError("", "FormateaGrid", ex)
        End Try
    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim Columna As Integer, Renglon As Integer
            'Dim StrCod As String, sCuentaContable As String = "", dCantidad As Decimal, dPrecio As Decimal, sCodigoCentroCosto As String
            'Dim oArticulos As Class_CatArticulos

            If Me.gridK.Selection.FirstRow = Me.gridK.Rows - 1 Then
                Return
            End If

            Columna = Me.gridK.Selection.FirstCol
            Renglon = Me.gridK.Selection.FirstRow

            Select Case e.KeyCode
                Case Keys.F6

                Case Keys.Enter
                    Select Case Columna
                        Case Me.igyCANTIDAD
                            'If Me.gridK.Rows = Renglon + 1 Then Me.gridK.Rows = Me.gridK.Rows + 1
                        Case Me.igyCONFIRMACION
                            Me.gridK.Cell(Renglon, Columna).Text = "Confirmado"
                    End Select
                    'Me.dtK.AcceptChanges()
            End Select

        Catch ex As Exception
            HandleError("", "GestionaGrid", ex)
        End Try

    End Sub

#End Region

End Class