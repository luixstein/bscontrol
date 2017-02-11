Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_VentasCatGastos
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_GASTO As String
    Private _NOMBRE_GASTO As String
#End Region

#Region "Campos ligados a la tabla"
    Private _ES_GENERICO As String
#End Region

#Region "Campos públicos"

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
    Public Property CODIGO_GASTO() As String
        Get
            Return Me._CODIGO_GASTO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_GASTO = Value
        End Set
    End Property

    Public Property NOMBRE_GASTO() As String
        Get
            Return Me._NOMBRE_GASTO
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_GASTO = Value
        End Set
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public WriteOnly Property ES_GENERICO() As String
        Set(ByVal Value As String)
            Me._ES_GENERICO = Value
        End Set
    End Property

#End Region

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

#End Region
#Region "Propiedades de campos de sistema"

    Public Overrides ReadOnly Property Nombre_Catalogo() As String
        Get
            Return Me._Nombre_Catalogo
        End Get
    End Property

    Public Overrides Property Nombre_Reporte() As String
        Get
            Return Me._Nombre_Reporte
        End Get
        Set(ByVal value As String)
            Me._Nombre_Reporte = value
        End Set
    End Property
    'Public Property EStatus() As String
    '    Get
    '        Return Me._Estatus
    '    End Get
    '    Set(ByVal value As String)
    '        Me._Estatus = value
    '    End Set
    'End Property
#End Region

#End Region

#Region "Constructor y destructor"

    Public Sub New()
        Me._Nombre_Catalogo = "VENTAS_CAT_GASTOS"
        Me._Nombre_Reporte = "RPT_VENTAS_CAT_GASTOS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT CODIGO_GASTO,NOMBRE_GASTO FROM VENTAS_CAT_GASTOS "
        Me._QueryOrder = " ORDER BY CODIGO_GASTO"
    End Sub                                                         'Inicializa al objeto.

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"

#End Region

#Region "Métodos y procedimientos"

    Public Overrides Function Insertar() As Boolean
        '
    End Function                          'Inserta un elemento al catálogo.

    Public Overrides Function Actualizar() As Boolean
        '
    End Function                        'Actualiza un elemento del catálogo.

    Public Overrides Function Consultar() As Boolean
        Dim cmd As New SqlCommand(Me._QuerySelect & " Where CODIGO_GASTO='" & Me._CODIGO_GASTO.ToString & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_GASTO = dReader("CODIGO_GASTO").ToString()
                    Me._NOMBRE_GASTO = "" & dReader("NOMBRE_GASTO").ToString()
                    Consultar = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
    End Function        'Consulta un elemento del catálogo.

    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCAT_Lineas As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            dsCAT_Lineas.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCAT_Lineas.Dispose()
        End Try
        Return dTable
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.

    Public Function ObtenerElementosParaReportes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCAT_Lineas As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            dsCAT_Lineas.Fill(dTable)
            dTable.Rows.Add("T", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosParaReportes", ex)
        Finally
            dsCAT_Lineas.Dispose()
        End Try
        Return dTable
    End Function

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de contratos por Código."
        f.sCampo = "CODIGO_GASTO"
        f.sOrder = "NOMBRE_GASTO"
        f.sTable = "VENTAS_CAT_GASTOS"
        f.sQl = "SELECT CODIGO_GASTO, NOMBRE_GASTO FROM VENTAS_CAT_GASTOS WHERE 1=1 AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorCodigo", ex)
        End Try
        Return Resultado
    End Function

    Public Overrides Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de cultivos por Nombre."
        f.sCampo = "NOMBRE_GASTO"
        f.sOrder = "NOMBRE_GASTO"
        f.sTable = "VENTAS_CAT_GASTOS"
        f.sQl = "SELECT CODIGO_GASTO, NOMBRE_GASTO FROM VENTAS_CAT_GASTOS WHERE 1=1 AND"
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorNombre", ex)
        End Try
        Return Resultado
    End Function

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

End Class
