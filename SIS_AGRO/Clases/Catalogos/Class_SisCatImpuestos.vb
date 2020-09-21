Option Strict On
Imports System.Data.SqlClient

Public Class Class_SisCatImpuestos

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_SIS_CAT_IMPUESTOS As String
    Private _NOMBRE_IMPUESTO As String
    Private _ESTATUS As String
    Private _PORCENTAJE As Decimal
    Private _VALOR As Decimal
#End Region

#Region "Campos ligados a la tabla"
    Private _EXISTE As Boolean
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
    Public Property ID_SIS_CAT_IMPUESTOS() As String
        Get
            Return Me._ID_SIS_CAT_IMPUESTOS
        End Get
        Set(ByVal Value As String)
            Me._ID_SIS_CAT_IMPUESTOS = Value
        End Set
    End Property

    Public Property NOMBRE_IMPUESTO() As String
        Get
            Return Me._NOMBRE_IMPUESTO
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_IMPUESTO = Value
        End Set
    End Property

    Public Property ESTATUS() As String
        Get
            Return Me._ESTATUS
        End Get
        Set(ByVal Value As String)
            Me._ESTATUS = Value
        End Set
    End Property

    Public Property PORCENTAJE() As Decimal
        Get
            Return Me._PORCENTAJE
        End Get
        Set(ByVal Value As Decimal)
            Me._PORCENTAJE = Value
        End Set
    End Property

    Public Property VALOR() As Decimal
        Get
            Return Me._VALOR
        End Get
        Set(ByVal Value As Decimal)
            Me._VALOR = Value
        End Set
    End Property

#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property EXISTE() As Boolean
        Get
            Return Me._EXISTE
        End Get
    End Property
#End Region

#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Catalogo() As String
        Get
            Return Me._Nombre_Catalogo
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "SIS_CAT_IMPUESTOS"
        Me._Nombre_Reporte = ".rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT * FROM SIS_CAT_IMPUESTOS"
        Me._QueryOrder = " ORDER BY NOMBRE_IMPUESTO"
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE ID_SIS_CAT_IMPUESTOS='" & sReplace(Me._ID_SIS_CAT_IMPUESTOS) & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._ID_SIS_CAT_IMPUESTOS = dReader("ID_SIS_CAT_IMPUESTOS").ToString
                    Me._NOMBRE_IMPUESTO = dReader("NOMBRE_IMPUESTO").ToString
                    Me._PORCENTAJE = CDec(dReader("_PORCENTAJE"))
                    Me._VALOR = CDec(dReader("VALOR"))
                    Me._ESTATUS = dReader("ESTATUS").ToString
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
    End Function        '

    Public Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT ID_SIS_CAT_IMPUESTOS,NOMBRE_IMPUESTO FROM SIS_CAT_IMPUESTOS WHERE ESTATUS='A'", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosParaReportes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT ID_SIS_CAT_IMPUESTOS,NOMBRE_IMPUESTO FROM SIS_CAT_IMPUESTOS WHERE ESTATUS='A'", Me._Conexion)
        Try
            da.Fill(dTable)
            dTable.Rows.Add("T", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosParaReportes", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function
#End Region

End Class

