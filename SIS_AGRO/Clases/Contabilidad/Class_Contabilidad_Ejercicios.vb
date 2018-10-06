Imports System.Data
Imports System.Data.SqlClient

Public Class Class_Contabilidad_Ejercicios

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_CON_EJERCICIO As Integer
    Private _NOMBRE_EJERCICIO As String
    Private _NUM_EJERCICIO As Integer
    Private _TIPO_CONTABILIDAD As String
    Private _ESTATUS_EJERCICIO As String
    Private _FECHA_INICIO As Date
    Private _FECHA_FINAL As Date
    Private _CODIGO_USUARIO_CIERRE As Integer
    Private _FECHA_CIERRE As Date
#End Region

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
#End Region

#Region "Campos ligados a la tabla"
    Public _Existe As Boolean 'lectura
#End Region

#End Region

#Region "Propiedades Campos de la tabla"
    Public Property ID_CON_EJERCICIO() As Integer
        Get
            Return Me._ID_CON_EJERCICIO
        End Get
        Set(ByVal Value As Integer)
            Me._ID_CON_EJERCICIO = Value
        End Set
    End Property
    Public Property NOMBRE_EJERCICIO() As String
        Get
            Return Me._NOMBRE_EJERCICIO
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_EJERCICIO = Value
        End Set
    End Property
    Public Property NUM_EJERCICIO() As Integer
        Get
            Return Me._NUM_EJERCICIO
        End Get
        Set(ByVal Value As Integer)
            Me._NUM_EJERCICIO = Value
        End Set
    End Property
    Public Property TIPO_CONTABILIDAD() As String
        Get
            Return Me._TIPO_CONTABILIDAD
        End Get
        Set(ByVal Value As String)
            Me._TIPO_CONTABILIDAD = Value
        End Set
    End Property
    Public Property ESTATUS_EJERCICIO() As String
        Get
            Return Me._ESTATUS_EJERCICIO
        End Get
        Set(ByVal Value As String)
            Me._ESTATUS_EJERCICIO = Value
        End Set
    End Property
    Public Property FECHA_INICIO() As Date
        Get
            Return Me._FECHA_INICIO
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_INICIO = Value
        End Set
    End Property
    Public Property FECHA_FINAL() As Date
        Get
            Return Me._FECHA_FINAL
        End Get
        Set(ByVal value As Date)
            Me._FECHA_FINAL = value
        End Set
    End Property
    Public Property CODIGO_USUARIO_CIERRE() As Integer
        Get
            Return Me._CODIGO_USUARIO_CIERRE
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_USUARIO_CIERRE = value
        End Set
    End Property
    Public Property FECHA_CIERRE() As Date
        Get
            Return Me._FECHA_CIERRE
        End Get
        Set(ByVal value As Date)
            Me._FECHA_CIERRE = value
        End Set
    End Property
#End Region

#Region "Propiedad Nombre de Clase"
    Private ReadOnly Property NombreClase()
        Get
            NombreClase = "Class_Contabilidad_Ejercicios"
        End Get
    End Property
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT * FROM CON_EJERCICIOS "
        Me._QueryOrder = " ORDER BY ID_CON_EJERCICIO"
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal iEjercicio As Integer)
        Me.New()
        Try
            Me._ID_CON_EJERCICIO = iEjercicio
            If Me.Consultar = True Then
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me.NombreClase, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function Consultar() As Boolean
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE ID_CON_EJERCICIO='" & Me._ID_CON_EJERCICIO & "' ", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._ID_CON_EJERCICIO = CInt(dReader("ID_CON_EJERCICIO").ToString)
                    Me._NOMBRE_EJERCICIO = Trim("" & dReader("NOMBRE_EJERCICIO").ToString)
                    Me._NUM_EJERCICIO = CInt(dReader("NUM_EJERCICIO").ToString)
                    Me._TIPO_CONTABILIDAD = Trim("" & dReader("TIPO_CONTABILIDAD").ToString)
                    Me._ESTATUS_EJERCICIO = Trim("" & dReader("ESTATUS_EJERCICIO").ToString)
                    Me._FECHA_INICIO = CDate(dReader("FECHA_INICIO").ToString)
                    Me._FECHA_FINAL = CDate(dReader("FECHA_FINAL").ToString)
                    If Me._ESTATUS_EJERCICIO = "C" Then
                        Me._CODIGO_USUARIO_CIERRE = CInt(dReader("CODIGO_USUARIO_CIERRE").ToString)
                        Me._FECHA_CIERRE = CDate(dReader("FECHA_CIERRE").ToString)
                    End If
                    Consultar = True
                End If

                dReader.Close()
            Catch ex As Exception
                HandleError(Me.NombreClase, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
    End Function

    Public Function ObtenerEjercicios() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCaDocumentos As New SqlDataAdapter("SELECT ID_CON_EJERCICIO,NOMBRE_EJERCICIO,TIPO_CONTABILIDAD FROM CON_EJERCICIOS ORDER BY TIPO_CONTABILIDAD DESC, NOMBRE_EJERCICIO", Me._Conexion)
        Try
            dsCaDocumentos.Fill(dTable)
        Catch ex As Exception
            HandleError(Me.NombreClase, "ObtenerEjercicios", ex)
        Finally
            dsCaDocumentos.Dispose()
        End Try
        ObtenerEjercicios = dTable
    End Function

    Public Function Actualizar(ByVal iIdEjercicio As Integer, ByVal sCuentacontable As String, ByVal bCerrarEjercicio As Boolean) As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_GENERA_POLIZA_CIERRE_EJERCICIO"

            sqlParametro = .Parameters.Add("@ID_CON_EJERCICIO", SqlDbType.SmallInt) : sqlParametro.Value = iIdEjercicio
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_CAPITAL", SqlDbType.NVarChar, 20) : sqlParametro.Value = sCuentacontable
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(bCerrarEjercicio)
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_CIERRE", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Actualizar = True
            Catch ex As Exception
                HandleError(Me.NombreClase, "Actualizar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function ValidarPolizas(ByVal iIdEjercicio As Integer, ByVal sValidar As String) As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_RPT_CONTABILIDAD_VALIDAR_POLIZA_EJERCICIO", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            With da.SelectCommand
                .Parameters.Add("@ID_CON_EJERCICIO", SqlDbType.SmallInt).Value = iIdEjercicio
                .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15).Value = sValidar
            End With

            da.Fill(dt)

        Catch ex As Exception
            HandleError(Me.NombreClase, "ValidarPolizas", ex)
        Finally
          
        End Try
        ValidarPolizas = dt
    End Function
#End Region

End Class
