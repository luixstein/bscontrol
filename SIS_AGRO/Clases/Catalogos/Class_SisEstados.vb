Imports System.Data
Imports System.Data.SqlClient

Public Class Class_SisEstados

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_ESTADO As String
    Private _NOMBRE_ESTADO As String
    Private _CODIGO_ESTADO_NUMERICO As String
    'Private _NOMBRE_ESTADO_SUA As String
    'Private _CODIGO_ESTADO_BANAMEX As String
    Private _CODIGO_PAIS_SAT As String
    Private _CODIGO_ESTADO_SAT As String
    'Private _ESTATUS As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
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
    Public ReadOnly Property CODIGO_ESTADO() As String
        Get
            Return Me._CODIGO_ESTADO
        End Get
    End Property

    Public ReadOnly Property NOMBRE_ESTADO() As String
        Get
            Return Me._NOMBRE_ESTADO
        End Get
    End Property

    Public ReadOnly Property CODIGO_ESTADO_NUMERICO() As String
        Get
            Return Me._CODIGO_ESTADO_NUMERICO
        End Get
    End Property

    'Public ReadOnly Property NOMBRE_ESTADO_SUA() As String
    '    Get
    '        Return Me._NOMBRE_ESTADO_SUA
    '    End Get
    'End Property

    'Public ReadOnly Property CODIGO_ESTADO_BANAMEX() As String
    '    Get
    '        Return Me._CODIGO_ESTADO_BANAMEX
    '    End Get
    'End Property

    Public ReadOnly Property CODIGO_PAIS_SAT() As String
        Get
            Return Me._CODIGO_PAIS_SAT
        End Get
    End Property

    Public ReadOnly Property CODIGO_ESTADO_SAT() As String
        Get
            Return Me._CODIGO_ESTADO_SAT
        End Get
    End Property

    'Public ReadOnly Property ESTATUS() As String
    '    Get
    '        Return Me._ESTATUS
    '    End Get
    'End Property
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
        Me._Nombre_Catalogo = "SIS_ESTADOS"
        Me._Nombre_Reporte = "RPT_CATALOGO_ESTADOS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT CODIGO_ESTADO,NOMBRE_ESTADO,CODIGO_ESTADO_NUMERICO,NOMBRE_ESTADO_SUA,CODIGO_ESTADO_BANAMEX,CODIGO_PAIS_SAT,CODIGO_ESTADO_SAT,CODIGO_ESTADO_ANTERIOR FROM SIS_ESTADOS"
        Me._QueryOrder = " ORDER BY NOMBRE_ESTADO"
    End Sub

    Public Sub New(ByVal sCodigo As String)
        Me.New()
        Try
            Me._CODIGO_ESTADO = sCodigo
            If Me.Consultar = True Then
                Me._Existe = True
                'Throw New Exception("El artículo no existe.")
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "New", ex)
        End Try
    End Sub

    Public Sub New(ByVal sCodigoEstadoSAT As String, ByVal sCodigoEstadoPaisSAT As String)
        Me.New()
        Try
            Me._CODIGO_ESTADO_SAT = sCodigoEstadoSAT
            Me._CODIGO_PAIS_SAT = sCodigoEstadoPaisSAT
            If Me.ConsultarConCodigoTipoSAT = True Then
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

#Region "Opciones"

#End Region

#Region "Métodos y procedimientos"
    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand("SELECT CODIGO_ESTADO,NOMBRE_ESTADO,CODIGO_ESTADO_NUMERICO,/*NOMBRE_ESTADO_SUA,CODIGO_ESTADO_BANAMEX*/,CODIGO_PAIS_SAT,CODIGO_ESTADO_SAT " & _
                                  "FROM SIS_ESTADOS " & _
                                  "WHERE CODIGO_ESTADO='" & sReplace(Me._CODIGO_ESTADO) & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_ESTADO = "" & dReader("CODIGO_ESTADO")
                    Me._NOMBRE_ESTADO = Trim("" & dReader("NOMBRE_ESTADO").ToString)
                    Me._CODIGO_ESTADO_NUMERICO = "" & dReader("CODIGO_ESTADO_NUMERICO")
                    'Me._NOMBRE_ESTADO_SUA = Trim("" & dReader("NOMBRE_ESTADO_SUA").ToString)
                    'Me._CODIGO_ESTADO_BANAMEX = "" & dReader("CODIGO_ESTADO_BANAMEX")
                    Me._CODIGO_PAIS_SAT = "" & dReader("CODIGO_PAIS_SAT")
                    Me._CODIGO_ESTADO_SAT = "" & dReader("CODIGO_ESTADO_SAT")
                    'Me.ESTATUS = "" & dReader("ESTATUS").ToString

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

    Public Function ConsultarConCodigoTipoSAT() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand("SELECT CODIGO_ESTADO,NOMBRE_ESTADO,CODIGO_ESTADO_NUMERICO,/*NOMBRE_ESTADO_SUA,CODIGO_ESTADO_BANAMEX,*/CODIGO_PAIS_SAT,CODIGO_ESTADO_SAT " & _
                                  "FROM SIS_ESTADOS " & _
                                  "WHERE CODIGO_ESTADO_SAT='" & sReplace(Me._CODIGO_ESTADO_SAT) & "' AND CODIGO_PAIS_SAT='" & sReplace(Me._CODIGO_PAIS_SAT) & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_ESTADO = "" & dReader("CODIGO_ESTADO")
                    Me._NOMBRE_ESTADO = Trim("" & dReader("NOMBRE_ESTADO").ToString)
                    Me._CODIGO_ESTADO_NUMERICO = "" & dReader("CODIGO_ESTADO_NUMERICO")
                    'Me._NOMBRE_ESTADO_SUA = Trim("" & dReader("NOMBRE_ESTADO_SUA").ToString)
                    'Me._CODIGO_ESTADO_BANAMEX = "" & dReader("CODIGO_ESTADO_BANAMEX")
                    Me._CODIGO_PAIS_SAT = "" & dReader("CODIGO_PAIS_SAT")
                    Me._CODIGO_ESTADO_SAT = "" & dReader("CODIGO_ESTADO_SAT")
                    'Me.ESTATUS = "" & dReader("ESTATUS").ToString

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

    Public Function ObtenerElementos(ByVal sCodigoPaisSAT As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_ESTADO,NOMBRE_ESTADO FROM SIS_ESTADOS WHERE CODIGO_PAIS_SAT='" & sReplace(sCodigoPaisSAT) & "'" & _
                                     "ORDER BY NOMBRE_ESTADO", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_ESTADO,NOMBRE_ESTADO FROM VW_SIS_ESTADOS_EXTENDIDO ORDER BY ORDEN_PAIS,NOMBRE_ESTADO", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

#End Region

End Class