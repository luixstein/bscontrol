Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatFormulas_Detalle

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_FORMULA_DETALLE As String
    Private _CODIGO_FORMULA As String
    Private _CODIGO_ARTICULO As String
    Private _CANTIDAD As Double
#End Region

#Region "Campos ligados a la tabla"

#End Region

#Region "Campos públicos"

#End Region

#Region "Campos privados"

#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Nombre_Reporte As String
    Private _Conexion As SqlConnection
    Private _QuerySELECT As String
    Private _QueryOrder As String

#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property ID_FORMULA_DETALLE As String
        Get
            Return Me._ID_FORMULA_DETALLE
        End Get
        Set(Value As String)
            Me._ID_FORMULA_DETALLE = Value
        End Set
    End Property

    Public Property CODIGO_FORMULA() As String
        Get
            Return Me._CODIGO_FORMULA
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_FORMULA = Value
        End Set
    End Property

    Public Property CODIGO_ARTICULO() As String
        Get
            Return Me._CODIGO_ARTICULO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_ARTICULO = Value
        End Set
    End Property

    Public Property CANTIDAD() As Double
        Get
            Return Me._CANTIDAD
        End Get
        Set(Value As Double)
            Me._CANTIDAD = Value
        End Set
    End Property

#End Region

#Region "Propiedades de campos ligados a la tabla"

#End Region

#Region "Propiedades públicos"

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

#Region "Constructor y destructor"

    Public Sub New()
        Me._Nombre_Catalogo = "CAT_FORMULAS_DETALLE"
        Me._Nombre_Reporte = "RPT_CATALOGO_FORMULAS_DETALLE"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySELECT = "SELECT ID_FORMULA_DETALLE,CODIGO_FORMULA,CODIGO_ARTICULO,CANTIDAD FROM CAT_FORMULAS_DETALLE"
        Me._QueryOrder = " Order by ID_FORMULA_DETALLE"
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"

#End Region

#Region "Métodos y procedimientos"

    Public Function Insertar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_FORMULAS_DETALLE_GRABA"

            sqlParametro = .Parameters.Add("@ID_FORMULA_DETALLE", SqlDbType.Int) : sqlParametro.Value = 0
            sqlParametro = .Parameters.Add("@CODIGO_FORMULA", SqlDbType.Int) : sqlParametro.Value = CInt(Me._CODIGO_FORMULA)
            sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CODIGO_ARTICULO.ToString
            sqlParametro = .Parameters.Add("@CANTIDAD", SqlDbType.Decimal) : sqlParametro.Value = Me._CANTIDAD
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
                Me._ID_FORMULA_DETALLE = "" & .Parameters("@ID_FORMULA_DETALLE").Value.ToString

            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Insertar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function Actualizar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_FORMULAS_DETALLE_GRABA"

            sqlParametro = .Parameters.Add("@ID_FORMULA_DETALLE", SqlDbType.Int) : sqlParametro.Value = CInt(Me._ID_FORMULA_DETALLE)
            sqlParametro = .Parameters.Add("@CODIGO_FORMULA", SqlDbType.Int) : sqlParametro.Value = CInt(Me._CODIGO_FORMULA)
            sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CODIGO_ARTICULO.ToString
            sqlParametro = .Parameters.Add("@CANTIDAD", SqlDbType.Decimal) : sqlParametro.Value = Me._CANTIDAD
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "0"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Actualizar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function EliminaIngrediente(ByVal Id_formula_detalle As Integer) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_FORMULAS_DETALLE_ELIMINA_INGREDIENTE"

            sqlParametro = .Parameters.Add("@ID_FORMULA_DETALLE", SqlDbType.Int) : sqlParametro.Value = Id_formula_detalle

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Actualizar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

#End Region

End Class



