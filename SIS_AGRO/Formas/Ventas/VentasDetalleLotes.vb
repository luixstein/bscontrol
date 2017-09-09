Option Strict On

Public Class VentasDetalleLotes

#Region "Columnas grid"
    Private igyIDA As Short = 1
    Private igyIDK As Short = 2
    Private igyIDL As Short = 3
    Private igyID_INVENTARIO_LOTES_COSTOS As Short = 4
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

    Enum LlamadoDesde
        A
        K
    End Enum

    Public eLlamadoDesde As LlamadoDesde
#End Region

#Region "Propiedades"
    Public ReadOnly Property dtLPublica As DataTable
        Get
            Me.dtL.AcceptChanges()
            Return Me.dtL
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
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos"
    Private Sub VentasDetalleLotes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            Dim dView As New DataView
            Select Case Me.eLlamadoDesde
                Case LlamadoDesde.A
                    dView = New DataView(Me.dtL)
                    dView.RowFilter = "IDA=" & Me._IDA
                Case LlamadoDesde.K
                    dView = New DataView(Me.dtL)
                    dView.RowFilter = "IDA=" & Me._IDA & " AND IDK=" & Me._IDK
            End Select
            'If Me.dtL.Rows.Count <> Me.gridL.Rows - 2 Then
            If dView.Count <> Me.gridL.Rows - 2 Then
                MsgBox("Falta la confirmación de algunos renglones.", MsgBoxStyle.Exclamation, Me.Text)
                e.Cancel = True
                Return
            End If
        Catch ex As Exception
            HandleError(Me.Name, "VentasDetalleLotes_FormClosing", ex)
        End Try
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
                .Columns.Add("COSTO", GetType(String))
                .Columns.Add("IMPORTE", GetType(String))

                .Columns("IDL").Unique = True
                .Columns("IDL").AutoIncrement = True
                .Columns("IDL").AutoIncrementSeed = 1
                .Columns("IDL").AutoIncrementStep = 1

                .Columns("IDK").DefaultValue = "0"
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

    '    Private Function RefrescaGrid(ByVal dView As DataView) As Boolean
    Public Function RefrescaGrid() As Boolean
        Try
            Dim dView As New DataView(Me.dtL)

            Select Case Me.eLlamadoDesde
                Case LlamadoDesde.A
                    dView.RowFilter = "IDA=" & Me._IDA
                Case LlamadoDesde.K
                    dView.RowFilter = "IDA=" & Me._IDA & " AND IDK=" & Me._IDK
            End Select

            'Si hay detalle de lotes , se carga
            'MsgBox(dView.Count.ToString)
            If dView.Count > 0 Then
                With Me.gridL
                    .AutoRedraw = False
                    .DataSource = dView
                    .DisplayFocusRect = False
                    .AutoRedraw = True
                    .Refresh()
                End With
            Else 'Si no, se construye en blanco la tabla lista para capturarle lotes

                Dim dRow As DataRow

                If txtLEN(Me._CodigoArticulo) = False Then
                    MsgBox("No ha especificado el artículo de series que se usarán.", MsgBoxStyle.Exclamation, Me.Text)
                    Me.gridL.DataSource = Nothing
                    Me.gridL.Rows = 0
                    Return False
                End If

                If Me._Cantidad = 0 Then
                    MsgBox("No ha especificado la cantidad de series que se usarán.", MsgBoxStyle.Exclamation, Me.Text)
                    Me.gridL.DataSource = Nothing
                    Return False
                End If

                Dim oArticulo As New Class_CatArticulos(Me._CodigoArticulo)

                If oArticulo.Existe = False Then
                    MsgBox("El artículo indicado no existe.", MsgBoxStyle.Exclamation, Me.Text)
                    Me.gridL.DataSource = Nothing
                    Return False
                End If

                If Not (oArticulo.ES_SERIALIZABLE = True AndAlso oArticulo.INVENTARIABLE = "1") Then
                    MsgBox("El artículo indicado no es serializable.", MsgBoxStyle.Exclamation, Me.Text)
                    Me.gridL.DataSource = Nothing
                    Return False
                End If


                Select Case Me.eLlamadoDesde
                    Case LlamadoDesde.A
                        For j = 1 To Me._Cantidad
                            dRow = Me.dtL.NewRow

                            dRow("IDA") = Me._IDA
                            dRow("CANTIDAD_USAR") = "1"

                            Me.dtL.Rows.Add(dRow)
                        Next

                        Me.dtL.AcceptChanges()

                        dView.RowFilter = "IDA=" & Me._IDA

                    Case LlamadoDesde.K
                        For j = 1 To Me._Cantidad
                            dRow = Me.dtL.NewRow

                            dRow("IDA") = Me._IDA
                            dRow("IDK") = Me._IDK
                            dRow("CANTIDAD_USAR") = "1"

                            Me.dtL.Rows.Add(dRow)
                        Next

                        Me.dtL.AcceptChanges()

                        dView.RowFilter = "IDA=" & Me._IDA & " AND IDK=" & Me._IDK
                End Select

                Me.gridL.DataSource = dView

            End If

            Me.FormateaGrid()
        Catch ex As Exception
            HandleError(Me.Name, "RefrescaGrid", ex)
        End Try
    End Function

    'Public Function RefrescaGridLDesdeA() As Boolean
    '    Try
    '        Dim dView As New DataView(Me.dtL)
    '        dView.RowFilter = "IDA=" & Me._IDA

    '        Me.RefrescaGrid(dView)



    '    Catch ex As Exception
    '        HandleError(Me.Name, "RefrescaGridLDesdeA", ex)
    '    End Try
    'End Function

    'Public Function RefrescaGridLDesdeK() As Boolean
    '    Try
    '        Dim dView As New DataView(Me.dtL)
    '        dView.RowFilter = "IDA=" & Me._IDA & " AND IDK=" & Me._IDK

    '        Me.RefrescaGrid(dView)

    '    Catch ex As Exception
    '        HandleError(Me.Name, "RefrescaGridLDesdeK", ex)
    '    End Try
    'End Function

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
            If Me.eLlamadoDesde = LlamadoDesde.K Then
                e.Row("IDK") = Me._IDK
            End If
            e.Row("CONFIRMACION") = "Sin confirmar"
        Catch ex As Exception
            HandleError(Me.Name, "Table_NewRow_L", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            With Me.gridL
                .AutoRedraw = False
                .DisplayFocusRect = False

                .Column(Me.igyIDA).Width = 20
                .Column(Me.igyIDK).Width = 20
                .Column(Me.igyIDL).Width = 20
                .Column(Me.igyID_INVENTARIO_LOTES_COSTOS).Width = 50
                .Column(Me.igyCANTIDAD_USAR).Width = 75
                .Column(Me.igyNS).Width = 150
                .Column(Me.igyCONFIRMACION).Width = 75
                .Column(Me.igyCOSTO).Width = 50
                .Column(Me.igyIMPORTE).Width = 50

                .Cell(0, Me.igyIDA).Text = "IDA"
                .Cell(0, Me.igyIDK).Text = "IDK"
                .Cell(0, Me.igyIDL).Text = "IDL"
                .Cell(0, Me.igyID_INVENTARIO_LOTES_COSTOS).Text = "IDLoteCosto"
                .Cell(0, Me.igyCANTIDAD_USAR).Text = "Cantidad"
                .Cell(0, Me.igyNS).Text = "Número de serie"
                .Cell(0, Me.igyCONFIRMACION).Text = ""
                .Cell(0, Me.igyCOSTO).Text = "Costo"
                .Cell(0, Me.igyIMPORTE).Text = "Importe"

                .Column(Me.igyIDA).Locked = True
                .Column(Me.igyIDK).Locked = True
                .Column(Me.igyIDL).Locked = True
                .Column(Me.igyID_INVENTARIO_LOTES_COSTOS).Locked = True
                .Column(Me.igyCANTIDAD_USAR).Locked = True
                .Column(Me.igyNS).Locked = True
                .Column(Me.igyCONFIRMACION).Locked = True
                .Column(Me.igyCOSTO).Locked = True
                .Column(Me.igyIMPORTE).Locked = True

                .Column(Me.igyIDA).Visible = True
                .Column(Me.igyIDK).Visible = True
                .Column(Me.igyIDL).Visible = True
                .Column(Me.igyID_INVENTARIO_LOTES_COSTOS).Visible = True
                .Column(Me.igyCANTIDAD_USAR).Visible = True
                .Column(Me.igyNS).Visible = True
                .Column(Me.igyCONFIRMACION).Visible = True
                .Column(Me.igyCOSTO).Visible = False
                .Column(Me.igyIMPORTE).Visible = False

                .AutoRedraw = True
                .Refresh()
            End With

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim sLote As String = ""
        Dim oSerie As Class_Inventarios_Lotes_Series
        Try
            With Me.gridL
                Dim Renglon As Integer = .Selection.FirstRow
                Dim Columna As Integer = .Selection.FirstCol

                If .Selection.FirstRow = .Rows - 1 Then
                    Return
                End If

                Select Case e.KeyCode
                    Case Keys.Return
                        Select Case Columna
                            Case Me.igyNS
                                If Columna = Me.igyNS AndAlso txtLEN(.Cell(Renglon, Me.igyIDL).Text) = True Then
                                    sLote = .Cell(Renglon, Me.igyID_INVENTARIO_LOTES_COSTOS).Text
                                    If txtLEN(sLote) = False Then
                                        GoTo busca_serie
                                        Return
                                    End If

                                    If Me.EstableceSerie(Renglon, sLote) = True Then
                                        'If Renglon + 1 < .Rows Then
                                        '    .Cell(Renglon + 1, Me.igySerieDescripcion).SetFocus()
                                        'Else
                                        '    .Cell(1, Me.igySerieDescripcion).SetFocus()
                                        'End If
                                    End If
                                End If
                            Case Me.igyCONFIRMACION
                                Me.gridL.Cell(Renglon, Columna).Text = "Confirmado"
                        End Select

                    Case Keys.F6
                        If Columna = Me.igyNS AndAlso txtLEN(.Cell(Renglon, Me.igyIDL).Text) = True Then
busca_serie:
                            oSerie = New Class_Inventarios_Lotes_Series
                            sLote = oSerie.BusquedaVisual(Me._CodigoArticulo, Me._CodigoAlmacen)
                            If txtLEN(sLote) = True Then
                                If RepiteSerie(Renglon, sLote) = False Then
                                    Me.EstableceSerie(Renglon, sLote)
                                End If
                            End If
                        End If

                    Case Keys.F7
                        If Columna = Me.igyNS AndAlso txtLEN(.Cell(Renglon, Me.igyIDL).Text) = True Then
                            oSerie = New Class_Inventarios_Lotes_Series

                            Dim lote As New Class_Inventarios_Lotes_Series.Lote
                            lote = oSerie.BusquedaVisualSeriesMultiplesFolio(Me._CodigoArticulo, Me._CodigoAlmacen)

                            If txtLEN(lote.FolioMovimiento) = True Then

                                Dim dtSeries As DataTable = oSerie.ObtieneRenglonesSeriesFolio(lote.FolioMovimiento, Me._CodigoArticulo)
                                If dtSeries.Rows.Count = 0 Then
                                    MsgBox("No se encontraron series disponibles del artículo " & Me._CodigoArticulo & " del folio " & lote.FolioMovimiento, MsgBoxStyle.Exclamation, Me.Text)
                                    Return
                                End If

                                Dim i As Integer, iArticulosPendientes As Integer = Me.CantidadArticulosPendientesSerie(Me._CodigoArticulo) 'iArticulosEncontrados As Integer
                                Dim iSeriesUsadas As Double = lote.Cantidad, iRowEncontrado As Integer = 0
                                For i = 1 To Me.gridL.Rows - 1
                                    If iArticulosPendientes <= 0 Or iSeriesUsadas <= 0 Then
                                        Exit For
                                    End If
                                    If txtLEN(Me.gridL.Cell(i, Me.igyIDL).Text) = True AndAlso txtLEN(Me.gridL.Cell(i, Me.igyID_INVENTARIO_LOTES_COSTOS).Text) = False Then
                                        iArticulosPendientes -= 1
                                        iSeriesUsadas -= 1
                                        Me.gridL.Cell(i, Me.igyID_INVENTARIO_LOTES_COSTOS).Text = dtSeries.Rows(iRowEncontrado)("ID_INVENTARIO_LOTES_COSTOS").ToString
                                        Me.gridL.Cell(i, Me.igyNS).Text = dtSeries.Rows(iRowEncontrado)("NUMERO_SERIE").ToString
                                        iRowEncontrado += 1 'empieza desde el 0
                                    End If
                                Next


                            End If
                        End If

                    Case Keys.Delete
                        e.SuppressKeyPress = True
                End Select
            End With

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrid", ex)
        End Try
    End Sub

    Private Function CantidadArticulosPendientesSerie(ByVal sCodigoArticulo As String) As Integer
        Dim iArticulosEncontrados As Integer = 0
        Try
            For i = 1 To Me.gridL.Rows - 1
                If txtLEN(Me.gridL.Cell(i, Me.igyIDL).Text) = True AndAlso txtLEN(Me.gridL.Cell(i, Me.igyID_INVENTARIO_LOTES_COSTOS).Text) = False Then
                    iArticulosEncontrados += 1
                End If
            Next
        Catch ex As Exception
            HandleError(Me.Name, "CantidadArticulosPendientesSerie", ex)
        End Try
        Return iArticulosEncontrados
    End Function

    Private Function EstableceSerie(ByVal Renglon As Integer, ByVal ID_INVENTARIO_LOTES_COSTOS As String) As Boolean
        Try
            Dim oSerie As New Class_Inventarios_Lotes_Series(ID_INVENTARIO_LOTES_COSTOS)
            If oSerie.Existe = True Then
                Me.gridL.Cell(Renglon, Me.igyID_INVENTARIO_LOTES_COSTOS).Text = oSerie.ID_INVENTARIO_LOTES_COSTOS
                Me.gridL.Cell(Renglon, Me.igyNS).Text = oSerie.NUMERO_SERIE
                Return True
            End If
        Catch ex As Exception
            HandleError(Me.Name, "EstableceSerie", ex)
        End Try
    End Function

    Private Function RepiteSerie(ByVal Renglon As Integer, ByVal ID_INVENTARIO_LOTES_COSTOS As String) As Boolean
        Dim RenglonRepetido As Integer
        Try
            Me.dtL.AcceptChanges()

            For i = 1 To Me.gridL.Rows - 1
                If i <> Renglon Then
                    If txtLEN(Me.gridL.Cell(i, Me.igyIDL).Text) = True Then
                        If ID_INVENTARIO_LOTES_COSTOS = Me.gridL.Cell(i, Me.igyID_INVENTARIO_LOTES_COSTOS).Text Then
                            RenglonRepetido = i

                            MsgBox("La serie " & Me.gridL.Cell(RenglonRepetido, igyNS).Text &
                                   " del artículo " & Me._CodigoArticulo & " esta repetida en el renglón " & RenglonRepetido & "." & vbCrLf &
                                   "", MsgBoxStyle.Exclamation)
                            Me.gridL.Cell(RenglonRepetido, Me.igyNS).SetFocus()

                            Return True

                        End If

                    End If
                End If

            Next
        Catch ex As Exception
            HandleError(Me.Name, "RepiteSerie", ex)
        End Try
    End Function

#End Region

End Class
