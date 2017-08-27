Option Strict On
Imports FlexCell

Public Class VentasDetalleKits

#Region "Columnas grid"
    Private igyIDA As Short = 1
    Private igyIDK As Short = 2
    Private igyCODIGO_ARTICULO As Short = 3
    Private igyDESCRIPCION As Short = 4
    Private igyCANTIDAD As Short = 5
    Private igyCANTIDAD_ANTERIOR As Short = 6
    Private igyBOTON_L As Short = 7
    Private igyCONFIRMACION As Short = 8
    Private igyCOSTO As Short = 9
    Private igyIMPORTE As Short = 10
#End Region

#Region "Campos"
    Private dtK As DataTable
    Public oVentaL As VentasDetalleLotes

    Private _IDA As String
    Private _CodigoAlmacen As String
    Private _Cantidad As Decimal
#End Region

#Region "Propiedades"
    Public ReadOnly Property dtKPublica As DataTable
        Get
            Return Me.dtK
        End Get
    End Property

    Public Property IDA As String
        Get
            Return Me._IDA
        End Get
        Set(value As String)
            Me._IDA = value
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
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos"
    Private Sub VentasDetalleKits_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.dtK.Rows.Count <> Me.gridK.Rows - 2 Then
            MsgBox("Falta la confirmación de algunos renglones.", MsgBoxStyle.Exclamation, Me.Text)
            e.Cancel = True
            Return
        End If

        If Me.HayArticulosRepetidos = True Then
            e.Cancel = True
            Return
        End If

        If Me.ValidaExistanSoloArticulosInventariables = False Then
            e.Cancel = True
            Return
        End If
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
                .Columns.Add("CANTIDAD", GetType(String))
                .Columns.Add("CANTIDAD_ANTERIOR", GetType(String))
                .Columns.Add("BOTON_L", GetType(String))
                .Columns.Add("CONFIRMACION", GetType(String))
                .Columns.Add("COSTO", GetType(String))
                .Columns.Add("IMPORTE", GetType(String))

                .Columns("IDK").Unique = True
                .Columns("IDK").AutoIncrement = True
                .Columns("IDK").AutoIncrementSeed = 1
                .Columns("IDK").AutoIncrementStep = 1

                .Columns("CODIGO_ARTICULO").DefaultValue = ""
                .Columns("DESCRIPCION").DefaultValue = ""
                .Columns("CANTIDAD").DefaultValue = ""
                .Columns("CANTIDAD_ANTERIOR").DefaultValue = ""
                .Columns("BOTON_L").DefaultValue = ""
                .Columns("CONFIRMACION").DefaultValue = "Sin confirmar"
                .Columns("COSTO").DefaultValue = ""
                .Columns("IMPORTE").DefaultValue = ""

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
            dView.RowFilter = "IDA=" & valorNumerico(Me._IDA)

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
            Me.oVentaL.EliminarDesdeA(IDA)

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
            HandleError(Me.Name, "SimulaCaptura", ex)
        End Try
    End Sub

    Private Sub gridK_ButtonClick(Sender As Object, e As Grid.ButtonClickEventArgs) Handles gridK.ButtonClick
        Try
            Select Case e.Col.ToString
                Case Me.igyBOTON_L.ToString
                    If Me.gridK.ActiveCell.Row <= 0 Then
                        Return
                    End If

                    Me.oVentaL.IDA = Me._IDA
                    Me.oVentaL.IDK = Me.gridK.Cell(Me.gridK.ActiveCell.Row, Me.igyIDK).Text
                    Me.oVentaL.CodigoArticulo = Me.gridK.Cell(Me.gridK.ActiveCell.Row, Me.igyCODIGO_ARTICULO).Text
                    Me.oVentaL.Cantidad = CDec(Me.gridK.Cell(Me.gridK.ActiveCell.Row, Me.igyCANTIDAD).Text)
                    Me.oVentaL.CodigoAlmacen = Me._CodigoAlmacen
                    Me.oVentaL.RefrescaGridLDesdeK()
                    Me.oVentaL.ShowDialog()

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
                Me.oVentaL.EliminarDesdeK(IDK)
            Catch ex As Exception

            End Try

        Catch ex As Exception
            HandleError(Me.Name, "Row_Deleted_K", ex)
        End Try
    End Sub

    Private Sub Row_Changed_K(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        Try
            If e.Row("CANTIDAD").ToString <> e.Row("CANTIDAD_ANTERIOR").ToString Then

                'Si modifican un renglón de K se eliminan sus hijos del L(tienen que volver a detallar L)
                Try
                    Dim IDK As String = e.Row("IDK", DataRowVersion.Original).ToString
                    Me.oVentaL.EliminarDesdeK(IDK)
                Catch ex As Exception

                End Try

                e.Row("CANTIDAD_ANTERIOR") = e.Row("CANTIDAD")
            End If
        Catch ex As Exception
            HandleError(Me.Name, "Row_Changed_K", ex)
        End Try
    End Sub

    Private Sub Table_NewRow_K(ByVal sender As Object, ByVal e As DataTableNewRowEventArgs)
        'MsgBox("renglón nuevo en dtK", MsgBoxStyle.Information, Me.Text)
        Try
            e.Row("IDA") = Me._IDA
            e.Row("DESCRIPCION") = ""
            e.Row("CONFIRMACION") = "Sin confirmar"
        Catch ex As Exception
            HandleError(Me.Name, "Table_NewRow_K", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            With Me.gridK
                .AutoRedraw = False
                .DisplayFocusRect = False

                .Column(Me.igyIDA).Width = 20
                .Column(Me.igyIDK).Width = 20
                .Column(Me.igyCODIGO_ARTICULO).Width = 75
                .Column(Me.igyDESCRIPCION).Width = 250
                .Column(Me.igyCANTIDAD).Width = 75
                .Column(Me.igyCANTIDAD_ANTERIOR).Width = 75
                .Column(Me.igyBOTON_L).Width = 50

                .Cell(0, Me.igyCODIGO_ARTICULO).Text = "Código"
                .Cell(0, Me.igyDESCRIPCION).Text = "Descripción"
                .Cell(0, Me.igyCANTIDAD).Text = "Cantidad"
                .Cell(0, Me.igyBOTON_L).Text = "Lotes"
                .Cell(0, Me.igyCOSTO).Text = "Costo"
                .Cell(0, Me.igyIMPORTE).Text = "Importe"

                .Column(Me.igyCANTIDAD).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyCANTIDAD).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.igyCANTIDAD).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyCOSTO).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
                .Column(Me.igyCOSTO).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyCOSTO).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyCOSTO).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyIMPORTE).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.igyIMPORTE).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyIMPORTE).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                .Column(Me.igyIMPORTE).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyIDA).Locked = True
                .Column(Me.igyIDK).Locked = True
                .Column(Me.igyDESCRIPCION).Locked = True
                .Column(Me.igyCANTIDAD_ANTERIOR).Locked = True
                .Column(Me.igyCONFIRMACION).Locked = True
                .Column(Me.igyCOSTO).Locked = True
                .Column(Me.igyIMPORTE).Locked = True

                .Column(Me.igyIDA).Visible = True
                .Column(Me.igyIDK).Visible = True  ' False
                .Column(Me.igyCANTIDAD_ANTERIOR).Visible = False
                .Column(Me.igyBOTON_L).Visible = True
                .Column(Me.igyCOSTO).Visible = False
                .Column(Me.igyIMPORTE).Visible = False

                .Column(Me.igyBOTON_L).CellType = CellTypeEnum.Button

                .AutoRedraw = True
                .Refresh()
            End With

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim Columna As Integer, Renglon As Integer
            Dim StrCod As String = "" ', sCuentaContable As String = "", dCantidad As Decimal, dPrecio As Decimal, sCodigoCentroCosto As String
            Dim oArticulos As Class_CatArticulos

            'If Me.gridK.Selection.FirstRow = Me.gridK.Rows - 1 Then
            '    Return
            'End If

            Columna = Me.gridK.Selection.FirstCol
            Renglon = Me.gridK.Selection.FirstRow
            StrCod = Me.gridK.Cell(Renglon, Me.igyCODIGO_ARTICULO).Text

            Select Case e.KeyCode
                Case Keys.F6
                    Select Case Columna
                        Case Me.igyCODIGO_ARTICULO
BuscaArticulos:
                            oArticulos = New Class_CatArticulos
                            StrCod = oArticulos.BusquedaVisual_PorDescripcion_conExistencias(Me._CodigoAlmacen)
                            If txtLEN(StrCod) = True Then
                                Me.gridK.Cell(Renglon, Me.igyCODIGO_ARTICULO).Text = StrCod
                                GoTo LlenaArticulo : Exit Sub
                            End If
                    End Select

                Case Keys.Enter
                    Select Case Columna
                        Case Me.igyCODIGO_ARTICULO
                            If txtLEN(StrCod) = False Then
                                GoTo BuscaArticulos : Return
                            End If
LlenaArticulo:
                            oArticulos = New Class_CatArticulos(StrCod)
                            If oArticulos.Existe = False Then
                                GoTo BuscaArticulos : Return
                            End If

                            Me.gridK.Cell(Renglon, Me.igyDESCRIPCION).Text = oArticulos.DESCRIPCION

                        Case Me.igyCANTIDAD
                            'If Me.gridK.Rows = Renglon + 1 Then Me.gridK.Rows = Me.gridK.Rows + 1
                        Case Me.igyCONFIRMACION
                            Me.gridK.Cell(Renglon, Columna).Text = "Confirmado"
                    End Select
                    'Me.dtK.AcceptChanges()
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrid", ex)
        End Try

    End Sub

    Private Function HayArticulosRepetidos() As Boolean
        Dim RenglonRepetido As Integer

        Try
            Me.dtK.AcceptChanges()

            For i = 1 To Me.gridK.Rows - 1
                If txtLEN(Me.gridK.Cell(i, Me.igyCODIGO_ARTICULO).Text) = True Then
                    For z = i + 1 To Me.gridK.Rows - 1
                        If Me.gridK.Cell(i, Me.igyCODIGO_ARTICULO).Text = Me.gridK.Cell(z, Me.igyCODIGO_ARTICULO).Text Then
                            RenglonRepetido = z

                            MsgBox("El artículo " & Me.gridK.Cell(RenglonRepetido, igyCODIGO_ARTICULO).Text & " esta repetido en el renglón " & RenglonRepetido & ".", MsgBoxStyle.Exclamation)
                            Me.gridK.Cell(RenglonRepetido, Me.igyCODIGO_ARTICULO).SetFocus()

                            Return True
                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            HandleError(Me.Name, "HayArticulosRepetidos", ex)
        End Try

        Return False
    End Function

    Private Function ValidaExistanSoloArticulosInventariables() As Boolean
        Try
            For i = 1 To Me.gridK.Rows - 1
                If txtLEN(Me.gridK.Cell(i, Me.igyCODIGO_ARTICULO).Text) = True Then
                    Dim oArticulo As New Class_CatArticulos(Me.gridK.Cell(i, Me.igyCODIGO_ARTICULO).Text)
                    If oArticulo.Existe = False Then
                        MsgBox("El artículo " & Me.gridK.Cell(i, igyCODIGO_ARTICULO).Text & "-" & Me.gridK.Cell(i, igyDESCRIPCION).Text & " del renglón " & i.ToString & " no existe.", MsgBoxStyle.Exclamation)
                        Return False
                    ElseIf oArticulo.INVENTARIABLE = "0" Then
                        MsgBox("El artículo " & Me.gridK.Cell(i, igyCODIGO_ARTICULO).Text & "-" & Me.gridK.Cell(i, igyDESCRIPCION).Text & " del renglón " & i.ToString & " no es inventariable.", MsgBoxStyle.Exclamation)
                        Return False
                    End If
                End If
            Next
        Catch ex As Exception
            HandleError(Me.Name, "HayArticulosRepetidos", ex)
        End Try

        Return True
    End Function

#End Region

End Class
