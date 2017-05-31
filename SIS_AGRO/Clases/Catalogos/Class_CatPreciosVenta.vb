Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatPreciosVenta

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_ARTICULO As String
    Private _PRECIO1 As Decimal
    Private _PRECIO2 As Decimal
    Private _PRECIO3 As Decimal
    Private _PRECIO4 As Decimal
    Private _PRECIO5 As Decimal
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
    Private _DESCRIPCION As String
    Private _IEPS_PORCENTAJE As Decimal
    Private _PRECIO1_IEPS As Decimal
    Private _PRECIO2_IEPS As Decimal
    Private _PRECIO3_IEPS As Decimal
    Private _PRECIO4_IEPS As Decimal
    Private _PRECIO5_IEPS As Decimal
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
    Public ReadOnly Property CODIGO_ARTICULO() As String
        Get
            Return Me._CODIGO_ARTICULO
        End Get
    End Property

    Public Property PRECIO1() As Decimal
        Get
            Return Me._PRECIO1
        End Get
        Set(ByVal VALUE As Decimal)
            Me._PRECIO1 = VALUE
        End Set
    End Property

    Public Property PRECIO2() As Decimal
        Get
            Return Me._PRECIO2
        End Get
        Set(ByVal VALUE As Decimal)
            Me._PRECIO2 = VALUE
        End Set
    End Property

    Public Property PRECIO3() As Decimal
        Get
            Return Me._PRECIO3
        End Get
        Set(ByVal VALUE As Decimal)
            Me._PRECIO3 = VALUE
        End Set
    End Property

    Public Property PRECIO4() As Decimal
        Get
            Return Me._PRECIO4
        End Get
        Set(ByVal VALUE As Decimal)
            Me._PRECIO4 = VALUE
        End Set
    End Property

    Public Property PRECIO5() As Decimal
        Get
            Return Me._PRECIO5
        End Get
        Set(ByVal VALUE As Decimal)
            Me._PRECIO5 = VALUE
        End Set
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property DESCRIPCION() As String
        Get
            Return Me._DESCRIPCION
        End Get
    End Property

    Public ReadOnly Property IEPS_PORCENTAJE() As Decimal
        Get
            Return Me._IEPS_PORCENTAJE
        End Get
    End Property

    Public ReadOnly Property PRECIO1_IEPS() As Decimal
        Get
            Return Me._PRECIO1_IEPS
        End Get
    End Property

    Public ReadOnly Property PRECIO2_IEPS() As Decimal
        Get
            Return Me._PRECIO2_IEPS
        End Get
    End Property

    Public ReadOnly Property PRECIO3_IEPS() As Decimal
        Get
            Return Me._PRECIO3_IEPS
        End Get
    End Property

    Public ReadOnly Property PRECIO4_IEPS() As Decimal
        Get
            Return Me._PRECIO4_IEPS
        End Get
    End Property

    Public ReadOnly Property PRECIO5_IEPS() As Decimal
        Get
            Return Me._PRECIO5_IEPS
        End Get
    End Property
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

    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property

#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "Cat_PreciosVenta"
        Me._Nombre_Reporte = ""
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = ""
        Me._QueryOrder = ""
    End Sub

    Public Sub New(ByVal sArticulo As String)
        Me.New()
        Try
            Me._CODIGO_ARTICULO = sArticulo
            If Me.Consultar = True Then
                Me._Existe = True
                'Throw New Exception("El artículo no existe.")
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function GrabarCambioPrecio() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_PRECIOS_VENTA_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CODIGO_ARTICULO
            sqlParametro = .Parameters.Add("@PRECIO1", SqlDbType.Money) : sqlParametro.Value = Me._PRECIO1
            sqlParametro = .Parameters.Add("@PRECIO2", SqlDbType.Money) : sqlParametro.Value = Me._PRECIO2
            sqlParametro = .Parameters.Add("@PRECIO3", SqlDbType.Money) : sqlParametro.Value = Me._PRECIO3
            sqlParametro = .Parameters.Add("@PRECIO4", SqlDbType.Money) : sqlParametro.Value = Me._PRECIO4
            sqlParametro = .Parameters.Add("@PRECIO5", SqlDbType.Money) : sqlParametro.Value = Me._PRECIO5

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "GrabarCambioPrecio", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand("SELECT P.CODIGO_ARTICULO,A.DESCRIPCION,P.PRECIO1,P.PRECIO2,P.PRECIO3,P.PRECIO4,P.PRECIO5,T.IEPS_PORCENTAJE, " &
                                    "ROUND(P.PRECIO1*(1+(T.IEPS_PORCENTAJE/100.00)),3) PRECIO1_IEPS, " &
                                    "ROUND(P.PRECIO2*(1+(T.IEPS_PORCENTAJE/100.00)),3) PRECIO2_IEPS, " &
                                    "ROUND(P.PRECIO3*(1+(T.IEPS_PORCENTAJE/100.00)),3) PRECIO3_IEPS, " &
                                    "ROUND(P.PRECIO4*(1+(T.IEPS_PORCENTAJE/100.00)),3) PRECIO4_IEPS, " &
                                    "ROUND(P.PRECIO5*(1+(T.IEPS_PORCENTAJE/100.00)),3) PRECIO5_IEPS " &
                                    "FROM CAT_PRECIOS_VENTA P INNER JOIN CAT_ARTICULOS A ON(P.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
                                    "LEFT JOIN CAT_GRADOS_TOXICIDAD T ON(A.GRADO_TOXICIDAD=T.GRADO_TOXICIDAD)" &
                                    "WHERE P.CODIGO_ARTICULO='" & sReplace(Me._CODIGO_ARTICULO) & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_ARTICULO = dReader("CODIGO_ARTICULO").ToString()
                    Me._DESCRIPCION = dReader("DESCRIPCION").ToString()
                    Me._IEPS_PORCENTAJE = CDec(dReader("IEPS_PORCENTAJE").ToString())
                    Me._PRECIO1 = CDec(dReader("PRECIO1").ToString())
                    Me._PRECIO2 = CDec(dReader("PRECIO2").ToString())
                    Me._PRECIO3 = CDec(dReader("PRECIO3").ToString())
                    Me._PRECIO4 = CDec(dReader("PRECIO4").ToString())
                    Me._PRECIO5 = CDec(dReader("PRECIO5").ToString())
                    Me._PRECIO1_IEPS = CDec(dReader("PRECIO1_IEPS").ToString())
                    Me._PRECIO2_IEPS = CDec(dReader("PRECIO2_IEPS").ToString())
                    Me._PRECIO3_IEPS = CDec(dReader("PRECIO3_IEPS").ToString())
                    Me._PRECIO4_IEPS = CDec(dReader("PRECIO4_IEPS").ToString())
                    Me._PRECIO5_IEPS = CDec(dReader("PRECIO5_IEPS").ToString())
                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With

        Return bResultado
    End Function

    Public Function ObtenerElementos(ByVal sArticulo As String, ByVal sLinea As String, ByVal sFamilia As String) As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Using da As New SqlDataAdapter("MP_RPT_CAT_PRECIOS_VENTA", Me._Conexion)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                With da.SelectCommand
                    .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 500).Value = sArticulo
                    .Parameters.Add("@CODIGO_LINEA", SqlDbType.NVarChar, 4).Value = sLinea
                    .Parameters.Add("@CODIGO_FAMILIA", SqlDbType.NVarChar, 4).Value = sFamilia
                End With

                da.Fill(dt)
                dt.Columns.Remove("EMPRESA_NOMBRE")
                dt.Columns.Remove("FILTROS_TEXTO")
                dt.AcceptChanges()
            End Using

        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        End Try

        Return dt
    End Function

#End Region
End Class
