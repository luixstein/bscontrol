Option Strict Off
Option Explicit On

Imports System.ComponentModel

Public Class BusquedaVisual
    Inherits Form

#Region "Campos"


#Region "Campos de la tabla"

#End Region

#Region "Campos ligados a la tabla"

#End Region

#Region "Campos públicos"

#End Region


#Region "Campos privados"

#End Region

#Region "Campos de sistema"

#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"




#End Region

#Region "Propiedades de campos ligados a la tabla"

#End Region

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

#End Region
#Region "Propiedades de campos de sistema"


#End Region

#End Region

#Region "Propiedades públicos"
    Public arrayWidthColumns(-1) As Integer
    Private CollectionWidthColumns As Collection
#End Region

#Region "Constructor y destructor"

#End Region

#Region "Opciones"

#End Region

#Region "Métodos y procedimientos"

#End Region

#Region "Eventos de objetos"

#Region "Eventos de la lista de elementos"

#End Region

#Region " Eventos de TxtFiltro"

#End Region

#Region "Eventos Genericos"

#End Region


#Region "Keydown específicos"


#End Region

#Region "Validating específicos"

#End Region

#End Region

    Public sCampo As String
    Public sTable As String
    Public sOrder As String
    Public sQl As String
    Public sExtraFilter As String = ""
    Private components As Container
    Public WithEvents GridBusqueda As New Class_GridBusqueda
    Public Colwidths() As Integer
    Public iRows As Integer

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

    Private Sub Txtbusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusca.TextChanged
        Inicia(txtBusca.Text)
    End Sub

    Public Sub Inicia(ByVal sCodigo As String)
        Dim dv As New DataView, iColumnas As Integer
        Dim i As Integer

        GridBusqueda.inicia(sTable)
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

            Dim dsTable As New DataSet

            Dim sCadena As String = sQl & "  " & sCampo & " like '" & sCodigo & "%' order by " & sOrder

            Dim daTable As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(sCadena, Empresa_Sistema.conexion)

            daTable.Fill(dsTable, sTable)
            daTable.Dispose()
            GridBusqueda.DataSource = dsTable.Tables(sTable)
            iColumnas = dsTable.Tables(sTable).Columns.Count
            iRows = dsTable.Tables(sTable).Rows.Count
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
                GridBusqueda.Select()
            Case Keys.Down
                GridBusqueda.Tag = "X"
                GridBusqueda.Select()
        End Select
    End Sub

    Private Sub txtBusca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBusca.KeyPress
        txtNoBeep(e)
    End Sub
End Class

