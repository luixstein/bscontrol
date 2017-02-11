Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Drawing
Imports System.Data.SqlClient

Public Class Busqueda_General
#Region "Campos"


#Region "Campos de la tabla"


#End Region

#Region "Campos ligados a la tabla"

#End Region

#Region "Campos públicos"
    Private _Campos As String
    Private _Nom_Tabla As String
    Private _Condicion As String
    Private _Elem_Busqueda As String
    Private _elem_Ordenar As String
    'Agregado por Misael Moreno. 25 de Octubre de 2010. Para detectar cuando la busqueda contiene campos CHECKBOX
    Private _contiene_Celda_Checkbox As Boolean
#End Region

#Region "Campos privados"
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

#Region "Propiedades Campos de la tabla"

#End Region

#Region "Propiedades de campos ligados a la tabla"

#End Region

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
    Public ReadOnly Property contieneSeleccionMultiple() As Boolean
        Get
            Return _contiene_Celda_Checkbox
        End Get
    End Property

#End Region

#Region "Propiedades de campos privados"

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

    Public Sub Inicia()
        sTable = Me._Nom_Tabla
        Grid.MultiSelect = False
        Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        strSql = "Select " & Me._Campos & " From " & Me._Nom_Tabla & ""
        If Me._Condicion <> "" Then strSql = strSql & " Where " & Me._Condicion
        strSql = strSql & " order by  " & Me._elem_Ordenar

        Dim daTable As SqlDataAdapter = New SqlDataAdapter(strSql, Empresa_Sistema.conexion)

        daTable.Fill(MyDataSet, sTable)
        daTable.Dispose()

        MyDataSet.Tables(sTable).DefaultView.Sort = Me._Elem_Busqueda
        Grid.DataSource = MyDataSet.Tables(sTable).DefaultView

        Grid.EditMode = DataGridViewEditMode.EditProgrammatically
        Grid.Columns(0).Width = 100
        Grid.Columns(1).Width = 400

        'Agregado por Misael Moreno. 25 de Octubre de 2010. Ver Requisito DDR_008.
        'Se modifica esta pantalla para que pueda ser reutilizada para otras busquedas con opcion de seleccionar
        'mas de un registro. Para esto, tambien se tendran que revisar procedimientos ya que el resultado de la seleccion
        'serán los codigos separados por "comas (,)".
        For Each columna As DataGridViewColumn In Grid.Columns
            If TypeOf columna Is DataGridViewCheckBoxColumn Then
                Grid.SelectionMode = DataGridViewSelectionMode.CellSelect
                _contiene_Celda_Checkbox = True
            End If
        Next
        'Fin de Agregado

        Me.Tag = ""
    End Sub
    Sub INICIA2(Optional ByVal sTRdES As String = "")
        Dim Datos As New DataView, BUSCAR As String
        Datos.Table = MyDataSet.Tables(sTable)
        BUSCAR = Me._Elem_Busqueda & " LIKE '%" & sTRdES & "%'"
        Datos.RowFilter = BUSCAR
        Me.Grid.DataSource = Datos
        Me.Grid.Update()
    End Sub

    Private Sub Grid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles Grid.CellFormatting
        e.CellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    End Sub

    Public Sub New(ByVal StrCampos As String, ByVal StrNomTabla As String, ByVal StrCondicion As String, ByVal StrElemtoBusqueda As String, ByVal StrOrdenar As String)
        Nombre_Campos = StrCampos
        Nombre_Tabla = StrNomTabla
        Condicion = StrCondicion
        Elemento_Buscar = StrElemtoBusqueda
        Elemento_Ordenar = StrOrdenar

        ' This call is required by the Windows Form Designer.w
        InitializeComponent()
        Call Inicia()
        Call INICIA2("")
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub Grid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.DoubleClick
        'Comentado y Agregado por Misael Moreno. 25 de Octubre de 2010. Ver Requisito DDR_008.
        'Debido al requisito DDR_008, cuando se presente una columna de tipo "checkbox" se debera hacer
        'un recorrido por todos los elementos para identificar los valores seleccionados.
        'Dim vdg As DataGridViewCell, ICodigo As String
        'vdg = Grid.Rows(Val(0 & Grid.CurrentCell.RowIndex)).Cells(0)
        'ICodigo = vdg.Value
        'Me.Tag = "" & ICodigo
        'Me.Hide()
        'Inicio de Agregado
        ObtenerSeleccion()
        'Fin de Agregado
    End Sub
    'Agregado por Misael Moreno. 25 de Octubre de 2010. Ver Requisito DDR_008.
    'Se modifica esta pantalla para que pueda ser reutilizada para otras busquedas.
    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        If _contiene_Celda_Checkbox Then
            If e.RowIndex >= 0 Then
                If TypeOf Grid.Rows(e.RowIndex).Cells(e.ColumnIndex) Is DataGridViewCheckBoxCell AndAlso Not Grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Is DBNull.Value Then
                    Grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = IIf(Grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True, False, True)
                End If
            End If
        End If
    End Sub
    'Fin de Agregado

    Private Sub Grid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                'Comentado y Agregado por Misael Moreno. 25 de Octubre de 2010. Ver Requisito DDR_008.
                'Debido al requisito DDR_008, cuando se presente una columna de tipo "checkbox" se debera hacer
                'un recorrido por todos los elementos para identificar los valores seleccionados.
                'Dim vdg As DataGridViewCell, ICodigo As String
                'vdg = Grid.Rows(Val(0 & Grid.CurrentCell.RowIndex)).Cells(0)
                'ICodigo = vdg.Value
                'Me.Tag = "" & ICodigo
                'Me.Hide()
                'Inicio de Agregado
                ObtenerSeleccion()
                'Fin de Agregado
            Case Keys.Escape
                txtBusca.SelectionStart = 0
                txtBusca.SelectionLength = Len(txtBusca.Text)
                txtBusca.Focus()
        End Select
    End Sub

    Private Sub txtBusca_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBusca.KeyDown
        Dim celda As DataGridViewCell
        celda = Grid.CurrentCell

        If e.KeyCode = Keys.Down Then
            If Grid.RowCount - 2 > celda.RowIndex Then
                Grid.CurrentCell = Grid(celda.ColumnIndex, celda.RowIndex + 1)
            End If
        End If
        If e.KeyCode = Keys.Up Then
            If celda.RowIndex > 0 Then
                Grid.CurrentCell = Grid(celda.ColumnIndex, celda.RowIndex - 1)
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
        INICIA2(txtBusca.Text)
    End Sub
    'Agregado por Misael Moreno. 25 de Octubre de 2010. Ver Requisito DDR_008.
    'Se paso este codigo para reutilizarse en otras secciones de codigo
    ', debido a que se localizo la misma fraccion en distintas partes.
    Public Sub ObtenerSeleccion()
        Dim ICodigo As String = String.Empty, posicionColumnaCheckBox As Integer = 0, indice As Integer = 0

        If _contiene_Celda_Checkbox Then
            For Each columna As DataGridViewColumn In Grid.Columns
                If TypeOf columna Is DataGridViewCheckBoxColumn Then
                    posicionColumnaCheckBox = indice
                End If
                indice += 1
            Next
        End If

        If _contiene_Celda_Checkbox Then
            'Limpiamos el filtro para que la busqueda se realice en toda la tabla 
            CType(Grid.DataSource, DataView).RowFilter = ""
            Dim bEstaSeleccionado As Boolean
            For i As Integer = 0 To Grid.RowCount - 1
                If Not Grid.Rows(Val(0 & i)).Cells(posicionColumnaCheckBox).Value Is DBNull.Value Then
                    bEstaSeleccionado = Grid.Rows(Val(0 & i)).Cells(posicionColumnaCheckBox).Value
                    If bEstaSeleccionado Then
                        If i > 0 AndAlso ICodigo <> String.Empty Then
                            ICodigo += ","
                        End If
                        ICodigo += Grid.Rows(Val(0 & i)).Cells(0).Value.ToString
                    End If
                End If
            Next
        Else
            ICodigo = Grid.Rows(Val(0 & Grid.CurrentCell.RowIndex)).Cells(0).Value
        End If
        Me.Tag = "" & ICodigo
        Me.Hide()
    End Sub
    'Fin de Agregado

End Class