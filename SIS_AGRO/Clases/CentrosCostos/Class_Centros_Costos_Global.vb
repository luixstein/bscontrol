Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class Class_Centros_Costos_Global

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_CENTRO_COSTOS_MOVIMIENTOS_GLOBAL As String
    Private _FOLIO_MOVIMIENTO As String
    Private _CODIGO_DOCUMENTO As String
    Private _ESTATUS As String
    Private _FECHA As Date
    Private _FECHA_SERVIDOR As Date
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean
#End Region

#Region "Campos públicos"

#End Region

#Region "Campos privados"

#End Region

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"

#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property
#End Region

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

#End Region

#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_Centros_Costos_Global"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
    End Sub

    Public Sub New(ByVal sFolio As String, ByVal sCodigoDocumento As String)
        Me.New()
        Try
            Me._FOLIO_MOVIMIENTO = sFolio
            Me._CODIGO_DOCUMENTO = sCodigoDocumento
            If Me.Consultar = True Then
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand("SELECT * FROM CENTRO_COSTOS_MOVIMIENTOS_GLOBAL G WHERE G.FOLIO_MOVIMIENTO='" & sReplace(Me._FOLIO_MOVIMIENTO) & "' AND G.CODIGO_DOCUMENTO='" & sReplace(Me._CODIGO_DOCUMENTO) & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()
                If dReader.Read Then
                    Me._ID_CENTRO_COSTOS_MOVIMIENTOS_GLOBAL = dReader("ID_CENTRO_COSTOS_MOVIMIENTOS_GLOBAL").ToString
                    Me._FOLIO_MOVIMIENTO = dReader("FOLIO_MOVIMIENTO").ToString
                    Me._CODIGO_DOCUMENTO = dReader("CODIGO_DOCUMENTO").ToString
                    Me._ESTATUS = dReader("ESTATUS").ToString
                    'Me._CODIGO_PLAZA = CInt(dReader("CODIGO_PLAZA"))
                    Me._FECHA = CDate(dReader("FECHA"))
                    Me._FECHA_SERVIDOR = CDate(dReader("FECHA_SERVIDOR"))

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With

        Return bResultado
    End Function

    Public Function ObtenerDetalleCostos() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        sSQL = "SELECT CR.ID_CENTRO_COSTOS_MOVIMIENTOS_DETALLE,A.DESCRIPCION DESCRIPCION_ARTICULO,CR.CODIGO_CENTRO_COSTO,CC.NOMBRE_CENTRO_COSTO,CR.CODIGO_CATEGORIA,CA.NOMBRE_CATEGORIA,CR.CODIGO_CONCEPTO,CO.NOMBRE_CONCEPTO," & _
                "CR.CANTIDAD,CR.IMPORTE,CR.CUENTA_CONTABLE " & _
                "FROM CENTRO_COSTOS_MOVIMIENTOS_DETALLE CR " & _
                "INNER JOIN NOMINA_CAT_CENTROS_COSTOS CC ON(CR.CODIGO_CENTRO_COSTO=CC.CODIGO_CENTRO_COSTO) " & _
                "INNER JOIN CAT_CATEGORIAS CA ON(CR.CODIGO_CATEGORIA=CA.CODIGO_CATEGORIA) " & _
                "INNER JOIN CAT_CONCEPTOS CO ON(CR.CODIGO_CONCEPTO=CO.CODIGO_CONCEPTO) " & _
                "LEFT JOIN INVENTARIO_MOVIMIENTOS_DETALLE IR ON(CR.FOLIO_MOVIMIENTO=IR.FOLIO_MOVIMIENTO_INVENTARIO AND CR.ID_ADICIONAL=IR.ID_ADICIONAL) " & _
                "LEFT JOIN CAT_ARTICULOS A ON(IR.CODIGO_ARTICULO=A.CODIGO_ARTICULO)" & _
                "WHERE CR.FOLIO_MOVIMIENTO = '" & Me._FOLIO_MOVIMIENTO & "' " & _
                "ORDER BY CR.ID_CENTRO_COSTOS_MOVIMIENTOS_DETALLE "
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerDetalleCostos", ex)
        End Try
        Return dTabla
    End Function

    Public Function ActualizaCostos(ByVal sListaCentrosCostos As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CENTROS_COSTOS_DETALLE_ACTUALIZA"

            sqlParametro = .Parameters.Add("@FOLIO_MOVIMIENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_MOVIMIENTO
            sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = "" & Me._CODIGO_DOCUMENTO
            sqlParametro = .Parameters.Add("@LISTA_CENTROS_COSTOS", SqlDbType.NVarChar, 4000) : sqlParametro.Value = sListaCentrosCostos
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "ActualizaCostos", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function ObtieneNavegador(ByVal sFecha1 As String, ByVal sFecha2 As String, ByVal sCuenta1 As String, ByVal sCuenta2 As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_RPT_CENTROS_COSTOS_NAVEGADOR", _Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            With da.SelectCommand
                .Parameters.Add("@FECHA1", SqlDbType.NVarChar, 20).Value = sFecha1
                .Parameters.Add("@FECHA2", SqlDbType.NVarChar, 20).Value = sFecha2
                .Parameters.Add("@CUENTA1", SqlDbType.NVarChar, 20).Value = sCuenta1
                .Parameters.Add("@CUENTA2", SqlDbType.NVarChar, 20).Value = sCuenta2
            End With
            da.Fill(dt)
            dt.Columns.Remove("EMPRESA_NOMBRE")
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtieneNavegador", ex)
        End Try
        Return dt
    End Function

    Public Function ObtieneReporteMovimientos(ByVal sFecha1 As String, ByVal sFecha2 As String, ByVal sCodigoCentroCosto As String, ByVal sCodigoCategoria As String, ByVal sCodigoConcepto As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_RPT_CENTROS_COSTOS", _Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            With da.SelectCommand
                .Parameters.Add("@FECHA1", SqlDbType.NVarChar, 20).Value = sFecha1
                .Parameters.Add("@FECHA2", SqlDbType.NVarChar, 20).Value = sFecha2
                .Parameters.Add("@CODIGO_CENTRO_COSTO", SqlDbType.NVarChar, 10).Value = sCodigoCentroCosto
                .Parameters.Add("@CODIGO_CATEGORIA", SqlDbType.NVarChar, 10).Value = sCodigoCategoria
                .Parameters.Add("@CODIGO_CONCEPTO", SqlDbType.NVarChar, 10).Value = sCodigoConcepto
            End With
            da.Fill(dt)
            dt.Columns.Remove("EMPRESA_NOMBRE")
            dt.Columns.Remove("FECHA_INICIO")
            dt.Columns.Remove("FECHA_FIN")
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtieneReporteMovimientos", ex)
        End Try
        Return dt
    End Function

    Public Function ActualizaUUID_Detalle(ByVal iID_CENTRO_COSTOS_MOVIMIENTOS_DETALLE As Integer, ByVal sUUID As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CENTRO_COSTOS_DETALLE_ACTUALIZA_UUID"

            sqlParametro = .Parameters.Add("@ID_CENTRO_COSTOS_MOVIMIENTOS_DETALLE", SqlDbType.Int) : sqlParametro.Value = iID_CENTRO_COSTOS_MOVIMIENTOS_DETALLE
            sqlParametro = .Parameters.Add("@UUID", SqlDbType.NVarChar, 36) : sqlParametro.Value = sUUID

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "ActualizaUUID_Detalle", ex)
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
