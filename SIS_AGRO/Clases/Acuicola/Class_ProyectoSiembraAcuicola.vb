Option Strict On

Imports System.Data.SqlClient
'Imports CrystalDecisions.CrystalReports.Engine

Public Class Class_ProyectoSiembraAcuicola

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_PROYECTO_SIEMBRA As Integer
    Private _CICLO As Integer
    Private _FECHA_INICIO As Date
    Private _CODIGO_DIVISION As Integer
    Private _CODIGO_LOTE As String
    Private _HA As Decimal
    Private _ESTATUS As String
    Private _FECHA_SERVIDOR As Date
    Private _CODIGO_USUARIO_GRABO As Integer
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
#End Region

#Region "Campos públicos"
#End Region

#Region "Campos privados"
#End Region

#Region "Campos de sistema"
    Private _Nombre_Reporte As String
    Private _Conexion As SqlConnection
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"

    Public Property ID_PROYECTO_SIEMBRA() As Integer
        Get
            Return Me._ID_PROYECTO_SIEMBRA
        End Get
        Set(ByVal VALUE As Integer)
            Me._ID_PROYECTO_SIEMBRA = VALUE
        End Set
    End Property

    Public Property CICLO() As Integer
        Get
            Return Me._CICLO
        End Get
        Set(ByVal VALUE As Integer)
            Me._CICLO = VALUE
        End Set
    End Property

    Public Property FECHA_INICIO() As Date
        Get
            Return Me._FECHA_INICIO
        End Get
        Set(ByVal VALUE As Date)
            Me._FECHA_INICIO = VALUE
        End Set
    End Property

    Public Property CODIGO_DIVISION() As Integer
        Get
            Return Me._CODIGO_DIVISION
        End Get
        Set(ByVal VALUE As Integer)
            Me._CODIGO_DIVISION = VALUE
        End Set
    End Property

    Public Property CODIGO_LOTE() As String
        Get
            Return Me._CODIGO_LOTE
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_LOTE = VALUE
        End Set
    End Property

    Public Property HA() As Decimal
        Get
            Return Me._HA
        End Get
        Set(ByVal VALUE As Decimal)
            Me._HA = VALUE
        End Set
    End Property

    Public Property ESTATUS() As String
        Get
            Return Me._ESTATUS
        End Get
        Set(ByVal VALUE As String)
            Me._ESTATUS = VALUE
        End Set
    End Property

    Public ReadOnly Property FECHA_SERVIDOR() As Date
        Get
            Return Me._FECHA_SERVIDOR
        End Get
    End Property

    Public ReadOnly Property CODIGO_USUARIO_GRABO() As Integer
        Get
            Return Me._CODIGO_USUARIO_GRABO
        End Get
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"

#End Region

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

#End Region

#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_ProyectoSiembraAcuicola"
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
        Me._Nombre_Reporte = ""
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
    End Sub

    Public Sub New(ByVal sID_PROYECTO_SIEMBRA As Integer)
        Me.New()
        Try
            Me._ID_PROYECTO_SIEMBRA = sID_PROYECTO_SIEMBRA
            If Me.Consultar = True Then
                Me._Existe = True
                'Throw New Exception("El artículo no existe.")
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
    Public Function Grabar(ByVal sAccion As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_ACUICOLA_PROYECTO_SIEMBRA_GRABA"

            sqlParametro = .Parameters.Add("@ID_PROYECTO_SIEMBRA", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_PROYECTO_SIEMBRA : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@CICLO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CICLO
            sqlParametro = .Parameters.Add("@FECHA_INICIO", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_INICIO
            sqlParametro = .Parameters.Add("@CODIGO_DIVISION", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_DIVISION
            sqlParametro = .Parameters.Add("@CODIGO_LOTE", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_LOTE.ToUpper
            sqlParametro = .Parameters.Add("@HA", SqlDbType.Decimal) : sqlParametro.Value = Me._HA
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me._ESTATUS.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = sAccion

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._ID_PROYECTO_SIEMBRA = CInt("" & .Parameters("@ID_PROYECTO_SIEMBRA").Value.ToString)
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Grabar", ex)
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
        Dim cmd As New SqlCommand("SELECT * FROM PROYECTO_SIEMBRA_ACUICOLA WHERE ID_PROYECTO_SIEMBRA=" & Me._ID_PROYECTO_SIEMBRA.ToString, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._ID_PROYECTO_SIEMBRA = CInt("" & dReader("ID_PROYECTO_SIEMBRA").ToString())
                    Me._CICLO = CInt("" & dReader("CICLO").ToString())
                    Me._FECHA_INICIO = CDate("" & dReader("FECHA_INICIO").ToString())
                    Me._CODIGO_DIVISION = CInt("" & dReader("CODIGO_DIVISION").ToString())
                    Me._CODIGO_LOTE = "" & dReader("CODIGO_LOTE").ToString()
                    Me._HA = CDec(dReader("HA").ToString())
                    Me._ESTATUS = "" & dReader("ESTATUS").ToString()
                    Me._CODIGO_USUARIO_GRABO = CInt("" & dReader("CODIGO_USUARIO_GRABO").ToString())

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


    Public Function ObtenerElementosFiltro(ByVal Estatus As String, ByVal Año As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT P.ID_PROYECTO_SIEMBRA,P.CICLO Ciclo,DBO.FN_FORMAT_FECHA_CORTO(P.FECHA_INICIO) [Fecha inicio],CD.NOMBRE_DIVISION División,CL.NOMBRE_LOTE Lote,P.HA " &
                                     "FROM PROYECTO_SIEMBRA_ACUICOLA P " &
                                     "INNER JOIN CAT_DIVISIONES_ACUICOLA CD ON(P.CODIGO_DIVISION=CD.CODIGO_DIVISION) " &
                                     "INNER JOIN CAT_LOTES CL ON(P.CODIGO_LOTE=CL.CODIGO_LOTE) " &
                                     "WHERE P.ESTATUS='" & Estatus & "' AND YEAR(P.FECHA_INICIO)=" & Año.ToString & " " &
                                     "ORDER BY P.FECHA_INICIO,P.CODIGO_DIVISION,P.CICLO,P.CODIGO_LOTE", Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerElementosFiltro", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
    End Function

#End Region

End Class

