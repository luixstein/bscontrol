Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_NominaDia

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_NOMINA_DIA As Integer
    Private _ID_NOMINA_SEMANA As Integer
    Private _FECHA As String
    Private _NUMERO_DIA As Integer
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
    Private _QuerySelect As String
    Private _QueryOrder As String

#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property ID_NOMINA_DIA() As Integer
        Get
            Return Me._ID_NOMINA_DIA
        End Get
        Set(ByVal Value As Integer)
            Me._ID_NOMINA_DIA = Value
        End Set
    End Property

    'Public Property ID_NOMINA_TEMPORADA() As Integer
    '    Get
    '        Return Me._ID_NOMINA_TEMPORADA
    '    End Get
    '    Set(ByVal Value As Integer)
    '        Me._ID_NOMINA_TEMPORADA = Value
    '    End Set
    'End Property

    Public Property NUMERO_DIA() As Integer
        Get
            Return Me._NUMERO_DIA
        End Get
        Set(ByVal Value As Integer)
            Me._NUMERO_DIA = Value
        End Set
    End Property

    Public Property FECHA() As String
        Get
            Return Me._FECHA
        End Get
        Set(ByVal Value As String)
            Me._FECHA = Value
        End Set
    End Property

    Public Property ID_NOMINA_SEMANA() As Integer
        Get
            Return Me._ID_NOMINA_SEMANA
        End Get
        Set(ByVal Value As Integer)
            Me._ID_NOMINA_SEMANA = Value
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
        Me._Nombre_Catalogo = "NOMINA_DIAS"
        Me._Nombre_Reporte = "RPT_CATALOGO_NOMINA_DIAS.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * From NOMINA_DIAS"
        Me._QueryOrder = " Order by ID_NOMINA_DIA"
    End Sub

    Public Sub New(ByVal iDia As Integer)
        Me.New()
        Try
            Me.ID_NOMINA_DIA = iDia
            If Me.Consultar = False Then
                Throw New Exception("El día no existe.")
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
    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " Where ID_NOMINA_DIA=" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._ID_NOMINA_DIA = CType(dReader("ID_NOMINA_DIA"), Integer)
                    Me._ID_NOMINA_SEMANA = CInt(dReader("ID_NOMINA_SEMANA"))
                    Me._FECHA = "" & dReader("FECHA").ToString
                    Me._NUMERO_DIA = CInt(dReader("NUMERO_DIA"))
                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
        Return bResultado
    End Function

    Public Function ObtieneDetalleSemana(Optional ByVal iSemana As Integer = 0) As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_NOMINA_PERCEPCIONES_OBTIENE_SEMANA_POR_DIA", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            With da.SelectCommand
                .Parameters.Add("@ID_NOMINA_SEMANA", SqlDbType.Int).Value = iSemana
            End With

            da.Fill(dt)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtieneDetalleSemana", ex)
        End Try
        Return dt
    End Function

    Public Function ObtenerDetalleHojas() As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_NOMINA_PERCEPCIONES_OBTIENE_HOJAS_POR_DIA", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            With da.SelectCommand
                .Parameters.Add("@ID_NOMINA_DIA", SqlDbType.SmallInt).Value = Me._ID_NOMINA_DIA
            End With

            da.Fill(dt)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalleHojas", ex)
        End Try
        Return dt
    End Function

#End Region

End Class
