Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_VentasSemanales

#Region "Campos"
#Region "Campos de la tabla"
    Private _ID_SEMANA As Integer
    Private _CODIGO_CONTRATO As String
#End Region
#Region "Campos de sistema"
    Private _Nombre_Clase As String = "Class_VentasSemanales"
    Private _Nombre_Reporte As String
    Private _Conexion As SqlConnection
#End Region
#End Region

#Region "Propiedades"
#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return Me._Nombre_Clase
        End Get
    End Property
#End Region
#End Region

#Region "Constructor y destructor"
    Public Sub New(ByVal ID_Semana As Integer, ByVal sCodigoContrato As String)
        Me._ID_SEMANA = ID_Semana
        Me._CODIGO_CONTRATO = sCodigoContrato
        Me._Conexion = New SqlConnection(Empresa_Sistema.conexion)
    End Sub
    Protected Overrides Sub Finalize()
        Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function AgregarVenta(ByVal sCodigoCultivo As String, ByVal dBultos As Double, dVenta As Double, dAjustes As Double, dPrecioPromedio As Double) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_VENTAS_SEMANALES_GRABA_VENTA"

            sqlParametro = .Parameters.Add("@ID_VENTA", SqlDbType.Int) : sqlParametro.Direction = ParameterDirection.Output : sqlParametro.Value = 0
            sqlParametro = .Parameters.Add("@ID_SEMANA", SqlDbType.Int) : sqlParametro.Value = Me._ID_SEMANA
            sqlParametro = .Parameters.Add("@CODIGO_CONTRATO", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_CONTRATO
            sqlParametro = .Parameters.Add("@CODIGO_CULTIVO", SqlDbType.NVarChar, 4) : sqlParametro.Value = sCodigoCultivo
            sqlParametro = .Parameters.Add("@BULTOS", SqlDbType.Decimal) : sqlParametro.Value = dBultos
            sqlParametro = .Parameters.Add("@VENTA", SqlDbType.Decimal) : sqlParametro.Value = dVenta
            sqlParametro = .Parameters.Add("@AJUSTES", SqlDbType.Decimal) : sqlParametro.Value = dAjustes
            sqlParametro = .Parameters.Add("@PRECIO_PROMEDIO", SqlDbType.Decimal) : sqlParametro.Value = dPrecioPromedio
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "AgregarVenta", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function EliminarVenta(ByVal ID_VENTA As Integer) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_VENTAS_SEMANALES_ELIMINA_VENTA"

            sqlParametro = .Parameters.Add("@ID_VENTA", SqlDbType.Int) : sqlParametro.Value = ID_VENTA

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "EliminarVenta", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function AgregarGasto(ByVal sCodigoGasto As String, ByVal dGasto As Double) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_VENTAS_SEMANALES_GRABA_GASTO"

            sqlParametro = .Parameters.Add("@ID_GASTO", SqlDbType.Int) : sqlParametro.Direction = ParameterDirection.Output : sqlParametro.Value = 0
            sqlParametro = .Parameters.Add("@ID_SEMANA", SqlDbType.Int) : sqlParametro.Value = Me._ID_SEMANA
            sqlParametro = .Parameters.Add("@CODIGO_CONTRATO", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_CONTRATO
            sqlParametro = .Parameters.Add("@CODIGO_GASTO", SqlDbType.SmallInt) : sqlParametro.Value = sCodigoGasto
            sqlParametro = .Parameters.Add("@GASTO", SqlDbType.Decimal) : sqlParametro.Value = dGasto
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "AgregarGasto", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function EliminarGasto(ByVal ID_GASTO As Integer) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_VENTAS_SEMANALES_ELIMINA_GASTO"

            sqlParametro = .Parameters.Add("@ID_GASTO", SqlDbType.Int) : sqlParametro.Value = ID_GASTO

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "EliminarGasto", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function ObtenerVentas() As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Using da As New SqlDataAdapter("MP_VENTAS_SEMANALES_OBTIENE_VENTAS", Me._Conexion)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                With da.SelectCommand
                    .Parameters.Add("@ID_SEMANA", SqlDbType.Int).Value = Me._ID_SEMANA
                    .Parameters.Add("@CODIGO_CONTRATO", SqlDbType.NVarChar, 8).Value = Me._CODIGO_CONTRATO
                End With

                da.Fill(dt)
                'dt.Columns.Remove("ID")
            End Using

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerVentas", ex)
        End Try

        Return dt
    End Function

    Public Function ObtenerGastos() As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Using da As New SqlDataAdapter("MP_VENTAS_SEMANALES_OBTIENE_GASTOS", Me._Conexion)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                With da.SelectCommand
                    .Parameters.Add("@ID_SEMANA", SqlDbType.Int).Value = Me._ID_SEMANA
                    .Parameters.Add("@CODIGO_CONTRATO", SqlDbType.NVarChar, 8).Value = Me._CODIGO_CONTRATO
                End With

                da.Fill(dt)
                'dt.Columns.Remove("ID")
            End Using

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerGastos", ex)
        End Try

        Return dt
    End Function
#End Region

End Class
