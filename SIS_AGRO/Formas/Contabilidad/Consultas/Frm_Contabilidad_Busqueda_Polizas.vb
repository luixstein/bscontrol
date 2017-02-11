Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Drawing
Imports System.Data.SqlClient

Public Class Frm_Contabilidad_Busqueda_Polizas
#Region "Campos"

#Region "Campos públicos"
    Private _Campos As String
    Private _Nom_Tabla As String
    Private _Condicion As String
    Private _Elem_Busqueda As String
    Private _elem_Ordenar As String
#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Nombre_Reporte As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades públicos"
    Public Property Nombre_Campos() As String
        Get
            Return Me._Campos
        End Get
        Set(ByVal value As String)
            Me._Campos = value
        End Set
    End Property
    Public Property Nombre_Tabla() As String
        Get
            Return Me._Nom_Tabla
        End Get
        Set(ByVal value As String)
            Me._Nom_Tabla = value
        End Set
    End Property
    Public Property Condicion() As String
        Get
            Return Me._Condicion
        End Get
        Set(ByVal value As String)
            Me._Condicion = value
        End Set
    End Property
    Public Property Elemento_Buscar() As String
        Get
            Return Me._Elem_Busqueda
        End Get
        Set(ByVal value As String)
            Me._Elem_Busqueda = value
        End Set
    End Property
    Public Property Elemento_Ordenar() As String
        Get
            Return Me._elem_Ordenar
        End Get
        Set(ByVal value As String)
            Me._elem_Ordenar = value
        End Set
    End Property
#End Region

#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Catalogo() As String
        Get
            Return Me._Nombre_Catalogo
        End Get
    End Property
    Public Property Nombre_Reporte() As String
        Get
            Return Me._Nombre_Reporte
        End Get
        Set(ByVal value As String)
            Me._Nombre_Reporte = value
        End Set
    End Property

#End Region

#End Region

    Public sTable As String, strSql As String
    Public MyDataSet As New DataSet
    Dim Forma As Boolean

#Region "Constructor"
    Public Sub New(ByVal StrCampos As String, ByVal StrNomTabla As String, ByVal StrCondicion As String, ByVal StrElemtoBusqueda As String, ByVal StrOrdenar As String)
        Nombre_Campos = StrCampos
        Nombre_Tabla = StrNomTabla
        Condicion = StrCondicion
        Elemento_Buscar = StrElemtoBusqueda
        Elemento_Ordenar = StrOrdenar
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Forma = False
        ' Add any initialization after the InitializeComponent() call.
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Public Sub Inicia()
        sTable = Me._Nom_Tabla
        Me.Grid.MultiSelect = False
        Me.Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        strSql = "SELECT " & Me._Campos & " FROM " & Me._Nom_Tabla & ""
        If Me._Condicion <> "" Then strSql = strSql & " Where " & Me._Condicion
        strSql = strSql & " order by  " & Me._elem_Ordenar

        Dim daTable As SqlDataAdapter = New SqlDataAdapter(strSql, Empresa_Sistema.Conexion)

        daTable.Fill(MyDataSet, sTable)
        daTable.Dispose()

        MyDataSet.Tables(sTable).DefaultView.Sort = Me._Elem_Busqueda
        Me.Grid.DataSource = MyDataSet.Tables(sTable).DefaultView

        Me.Grid.EditMode = DataGridViewEditMode.EditProgrammatically
        Me.Grid.Columns(0).Width = 100
        Me.Grid.Columns(1).Width = 400

        Me.Tag = ""
    End Sub

    Sub INICIA2(Optional ByVal sTRdES As String = "")
        If Forma = True Then
            'Dim Datos As New DataView
            'Dim dT As New DataTable
            'Dim BUSCAR As String
            'Datos.Table = MyDataSet.Tables(sTable)
            'Me._Elem_Busqueda = Me.CmbBusqueda.Text
            'BUSCAR = Me._Elem_Busqueda & " LIKE '%" & sTRdES & "%'" ' And (FECHA>= '" & Format(Me.DtFechaDesde.Value, "yyyy-dd-MM") & "' and FECHA<='" & Format(Me.DtFechaHasta.Value, "yyyy-dd-MM") & "')"
            'Datos.RowFilter = BUSCAR
            'Me.Grid.DataSource = Datos
            'Me.Grid.Update()
            Me._Condicion = "FECHA BETWEEN '" & Format(Me.DtFechaDesde.Value, "yyyy-dd-MM") & "' AND '" & Format(Me.DtFechaHasta.Value, "yyyy-dd-MM") & "'"
            'Me.Grid.DataSource = dT
            Me.Grid.DataSource = Nothing

            Me.Grid.Rows.Clear()
            'FG_Grid_Limpiar(Me.Grid)

            sTable = Me._Nom_Tabla
            Me.Grid.MultiSelect = False
            Me.Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            strSql = "SELECT " & Me._Campos & " FROM " & Me._Nom_Tabla & ""
            If Me._Condicion <> "" Then strSql = strSql & " Where (" & Me._Condicion & ") AND " & "CONCEPTO1 LIKE '%" & sTRdES & "%'"
            strSql = strSql & " order by  " & Me._elem_Ordenar

            Dim daTable As SqlDataAdapter = New SqlDataAdapter(strSql, Empresa_Sistema.Conexion)

            daTable.Fill(MyDataSet, sTable)
            daTable.Dispose()

            MyDataSet.Tables(sTable).DefaultView.Sort = Me._Elem_Busqueda
            Me.Grid.DataSource = MyDataSet.Tables(sTable).DefaultView

            Me.Grid.EditMode = DataGridViewEditMode.EditProgrammatically
            Me.Grid.Columns(0).Width = 100
            Me.Grid.Columns(1).Width = 400

            Me.Tag = ""

        End If
    End Sub

    Private Sub Grid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles Grid.CellFormatting
        e.CellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    End Sub

    Private Sub Grid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.DoubleClick
        Dim vdg As DataGridViewCell, ICodigo As String
        vdg = Grid.Rows(Val(0 & Me.Grid.CurrentCell.RowIndex)).Cells(0)
        ICodigo = vdg.Value
        Me.Tag = "" & ICodigo
        Me.Hide()
    End Sub

    Private Sub Grid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                Dim vdg As DataGridViewCell, ICodigo As String
                vdg = Grid.Rows(Val(0 & Me.Grid.CurrentCell.RowIndex)).Cells(0)
                ICodigo = vdg.Value
                Me.Tag = "" & ICodigo
                Me.Hide()
            Case Keys.Escape
                Me.txtBusca.SelectionStart = Me.txtBusca.Text
                Me.txtBusca.Focus()
        End Select
    End Sub

    Private Sub txtBusca_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBusca.KeyDown
        Dim celda As DataGridViewCell
        celda = Grid.CurrentCell
        If e.KeyCode = Keys.Down Then
            If Me.Grid.RowCount - 2 > celda.RowIndex Then
                Me.Grid.CurrentCell = Me.Grid(celda.ColumnIndex, celda.RowIndex + 1)
            End If
        End If
        If e.KeyCode = Keys.Up Then
            If celda.RowIndex > 0 Then
                Me.Grid.CurrentCell = Me.Grid(celda.ColumnIndex, celda.RowIndex - 1)
            End If
        End If
        Select Case e.KeyCode
            Case Keys.Return
                Grid.Focus()
            Case Keys.Escape
                Me.Tag = ""
                Me.Hide()
        End Select
    End Sub

    Private Sub Txtbusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusca.TextChanged
        INICIA2(Me.txtBusca.Text)
    End Sub

    Private Sub DesplegarEjercicios()
        Dim oElementos As New Class_Contabilidad_Ejercicios
        With Me.CmbEjercicio
            .DisplayMember = "NOMBRE_EJERCICIO"
            .ValueMember = "ID_CON_EJERCICIO"
            Dim dView As New Data.DataView(oElementos.ObtenerEjercicios)
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub CmbEjercicio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbEjercicio.SelectedIndexChanged
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Me.CmbEjercicio.SelectedValue.ToString)
        Me.DtFechaDesde.Value = CDate(sql.Result1)
        Me.DtFechaHasta.Value = CDate(sql.Result2)
        'If Me.Grid.RowCount > 0 Then
        '    Me.Grid.Rows.Clear()
        'End If
        'INICIA2(Me.txtBusca.Text)
    End Sub

    Private Sub DtFechaHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFechaHasta.ValueChanged
        If Me.Visible = False Then
            Exit Sub
        End If
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue.ToString & "'")
        If Me.DtFechaHasta.Value < CDate(sql.Result1) Then
            Me.DtFechaHasta.Value = CDate(sql.Result1)
        End If
        If Me.DtFechaHasta.Value > CDate(sql.Result2) Then
            Me.DtFechaHasta.Value = CDate(sql.Result2)
        End If
        INICIA2(Me.txtBusca.Text)
    End Sub

    Private Sub DtFechaDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFechaDesde.ValueChanged
        If Me.Visible = False Then
            Exit Sub
        End If
        Dim sql As Class_find
        sql = New Class_find("SELECT FECHA_INICIO,FECHA_FINAL FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Me.CmbEjercicio.SelectedValue.ToString & "'")
        If Me.DtFechaDesde.Value < CDate(sql.Result1) Then
            Me.DtFechaDesde.Value = CDate(sql.Result1)
        End If
        If Me.DtFechaDesde.Value > CDate(sql.Result2) Then
            Me.DtFechaDesde.Value = CDate(sql.Result2)
        End If
        'INICIA2(Me.txtBusca.Text)
    End Sub

    Private Sub Frm_Contabilidad_Busqueda_Polizas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DesplegarEjercicios()
        Me.CmbEjercicio.SelectedValue = Plaza.ID_CON_EJERCICIO
        Me.CmbBusqueda.Text = "POLIZA"
        Me.CmbBusqueda.SelectedIndex = 0
        Forma = True
        'Call Inicia()
        
        Call INICIA2("")
    End Sub
#End Region
End Class