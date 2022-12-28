Option Strict Off
Option Explicit On

Imports System.ComponentModel

Public Class BusquedaVisual
    Inherits Form

#Region "Campos"
    Public sCampo As String
    Public sTable As String
    Public sOrder As String
    Public sQl As String
    Public sExtraFilter As String = ""
    Private components As Container
    Public WithEvents GridBusqueda As New Class_GridBusqueda
    Public Colwidths() As Integer
    Public iRows As Integer

    Public arrayWidthColumns(-1) As Integer
    Private CollectionWidthColumns As Collection
    Private arrColsAlignment(-1) As Integer
#End Region

    Public BuscaTodaCadena As Boolean = False, BuscarDatatableLocal As Boolean = False, bIniciado As Boolean = False
    Private dTablaLocal As New DataTable, vwLocal As New DataView

#Region "Constructor"
    Public Sub New()
        MyBase.New()
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()
        '
        ' TODO: Add any constructor code after InitializeComponent call
        Me.Controls.Add(GridBusqueda)
        Me.GridBusqueda.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.GridBusqueda.DataMember = ""
        Me.GridBusqueda.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.GridBusqueda.Location = New System.Drawing.Point(2, 24)
        Me.GridBusqueda.Name = "datagrid1"
        Me.GridBusqueda.Size = New System.Drawing.Size(296, 240)
        Me.GridBusqueda.TabIndex = 1
        Me.GridBusqueda.ReadOnly = True
        Me.GridBusqueda.RowHeadersVisible = False
    End Sub
#End Region

#Region " Windows Form Designer generated code "
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)

        If disposing Then
            If (Not (components) Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)

    End Sub

    Friend WithEvents txtBusca As System.Windows.Forms.TextBox
    Private Sub InitializeComponent()
        Me.txtBusca = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtBusca
        '
        Me.txtBusca.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBusca.Location = New System.Drawing.Point(0, 0)
        Me.txtBusca.Name = "txtBusca"
        Me.txtBusca.Size = New System.Drawing.Size(296, 20)
        Me.txtBusca.TabIndex = 0
        Me.txtBusca.Text = ""
        '
        'fBusca
        '
        'Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoScaleDimensions = New System.Drawing.SizeF(5, 13)
        Me.ClientSize = New System.Drawing.Size(296, 281)
        Me.Controls.Add(Me.txtBusca)
        Me.MinimizeBox = False
        Me.Name = "fBusca"
        Me.Text = "Busqueda visual"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    '<STAThread()> _
    'Public Shared Sub Main()
    '    Application.Run(New fBusca())
    'End Sub
#End Region

#Region "Eventos"
    Private Sub Txtbusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusca.TextChanged
        Me.Inicia(Me.txtBusca.Text)
    End Sub

    Private Sub GridBusqueda_keyEnter_presed() Handles GridBusqueda.keyEnter_presed
        'Me.Hide()
        Me.Close()
    End Sub

    Private Sub txtBusca_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBusca.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                'Me.Hide()
                Me.iRows = 0
                Me.Close()
            Case Keys.Return
                'dataGrid1.Tag = "X"
                Me.GridBusqueda.Select()
            Case Keys.Down
                Me.GridBusqueda.Tag = "X"
                Me.GridBusqueda.Select()
        End Select
    End Sub

    Private Sub txtBusca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBusca.KeyPress
        txtNoBeep(e)
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Sub Inicia(ByVal sCodigo As String)
        Dim dv As New DataView, iColumnas As Integer
        Dim i As Integer
        Dim dsTable As New DataSet

        Me.GridBusqueda.inicia(sTable)
        If Me.sExtraFilter.Length > 0 Then
            sCodigo = Me.sExtraFilter & sCodigo & Me.sExtraFilter
        End If

        If Len(sQl) < 1 Then 'Si leeremos del dataset local
            'dv = DvM.CreateDataView(dsConfig.Tables(sTable))
            'dv.RowFilter = sCampo & " like '" & sCodigo & "%' "
            'dv.Sort = sOrder

            'dataGrid1.DataSource = dv
            'iColumnas = dv.Table.Columns.Count
            'iRows = dv.Count
        Else 'Si leeremos directamente del servidor
            If BuscaTodaCadena = True Then
                sCodigo = "%" & sCodigo
            End If

            Dim sFiltro As String = "", sSplitResultado() As String, j As Integer, sCampoSeparado As String = ""
            If Me.sCampo.Contains(",") = True Then 'Si se quiere filtrar por mas un campo
                sSplitResultado = Split(sCampo, ",")
                For j = 0 To UBound(sSplitResultado)
                    sCampoSeparado = sSplitResultado(j)
                    If j <> 0 Then
                        sFiltro = sFiltro & " OR "
                    End If
                    sFiltro = sFiltro & sCampoSeparado & " like '" & sCodigo & "%' "
                Next
                sFiltro = "(" & sFiltro & ")"
            Else
                sFiltro = sCampo & " like '" & sCodigo & "%' "
            End If

            'Dim sCadena As String = sQl & "  " & sCampo & " like '" & sCodigo & "%' order by " & sOrder
            Dim sCadena As String = sQl & "  " & sFiltro & " order by " & sOrder

            Dim daTable As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(sCadena, Empresa_Sistema.conexion)

            If Me.BuscarDatatableLocal = True Then

                If Me.bIniciado = False Then 'Llena una sola vez la tabla y vista local, y en las siguientes búsquedas ya busca directo sobre la vista
                    daTable.Fill(dsTable, sTable)
                    daTable.Dispose()

                    dTablaLocal = dsTable.Tables(0)

                    Me.bIniciado = True

                    vwLocal = New DataView(dTablaLocal)
                End If

                vwLocal.RowFilter = sFiltro
                'vwLocal.RowFilter = sCampo & " like '" & sCodigo & "%'"
                'vwLocal.RowFilter = sCampo & " like '" & sCodigo & "%' OR SIMILAR LIKE '" & sCodigo & "%'"

                'Estas dos formas son mas lentas.
                'Dim dTablaFiltrada As DataTable
                'dTablaFiltrada = dTablaLocal.Select(sCampo & " like '" & sCodigo & "%'").CopyToDataTable

                'dTablaLocal.Select(sCampo & " like '" & sCodigo & "%'")
                'dTablaFiltrada = vw.ToTable

                Me.GridBusqueda.DataSource = vwLocal 'dTablaFiltrada
                iRows = vwLocal.Count
                iColumnas = vwLocal.Table.Columns.Count
                'iColumnas = dTablaFiltrada.Columns.Count
                'iRows = dTablaFiltrada.Rows.Count
            Else
                daTable.Fill(dsTable, sTable)
                daTable.Dispose()
                Me.GridBusqueda.DataSource = dsTable.Tables(sTable)
                iColumnas = dsTable.Tables(sTable).Columns.Count
                iRows = dsTable.Tables(sTable).Rows.Count
            End If

        End If

        'Establece el ancho de las columnas
        Dim arrColWidth() As Integer
        ReDim arrColWidth(iColumnas - 1)
        If iColumnas > 0 Then arrColWidth(0) = 150
        If iColumnas > 1 Then arrColWidth(1) = 250

        If iColumnas > 2 Then
            For i = 2 To iColumnas - 1
                arrColWidth(i) = 100
            Next
        End If

        Me.CollectionWidthColumns = ConvertirArrayAColeccion(Me.arrayWidthColumns)
        If Me.CollectionWidthColumns.Count > 0 Then
            For i = 1 To Me.CollectionWidthColumns.Count
                Me.GridBusqueda.TableStyles(0).GridColumnStyles(i - 1).Width = Me.CollectionWidthColumns(i)
            Next
        Else
            For i = 0 To iColumnas - 1
                Me.GridBusqueda.TableStyles(0).GridColumnStyles(i).Width = arrColWidth(i)
            Next
        End If

        'Esta sección sirve para que detecte las columnas numéricas y las alinee a la derecha automáticamente.
        If Me.arrColsAlignment.Length > 0 Then 'Esto es para que si ya entró una vez a buscar, las subsecuentes veces ya no vea si son numéricas o no, porque esa información ya se recopiló en un arreglo.
            For i = 0 To Me.arrColsAlignment.Length - 1
                If Me.arrColsAlignment(i) = HorizontalAlignment.Right Then
                    Me.GridBusqueda.TableStyles(0).GridColumnStyles(i).Alignment = Me.arrColsAlignment(i)
                End If
            Next
        Else
            If iRows > 0 Then
                ReDim Preserve Me.arrColsAlignment(iColumnas - 1)

                For i = 1 To iColumnas - 1 'Omitimos la 1er columna porque regularmente en un código y sea numérico o no se alinea a la izquierda para que no se pegue con el nombre de la segunda columna
                    If Microsoft.VisualBasic.IsNumeric(Me.GridBusqueda.Item(0, i).ToString) Then
                        Me.arrColsAlignment(i) = HorizontalAlignment.Right
                        Me.GridBusqueda.TableStyles(0).GridColumnStyles(i).Alignment = HorizontalAlignment.Right
                    End If
                Next
            End If
        End If

    End Sub
#End Region

End Class

