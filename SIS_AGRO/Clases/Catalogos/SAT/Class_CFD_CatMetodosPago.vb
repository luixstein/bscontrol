Option Strict On

Imports System.Data.SqlClient

Public Class Class_CFD_CatMetodosPago

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_METODO_PAGO_EVENTO As String
    Private _NOMBRE_METODO_PAGO_EVENTO As String
    Private _ESTATUS As String
    Private _ES_DEFAULT As Boolean
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
    Public ReadOnly Property CODIGO_METODO_PAGO_EVENTO() As String
        Get
            Return Me._CODIGO_METODO_PAGO_EVENTO
        End Get
    End Property

    Public ReadOnly Property NOMBRE_METODO_PAGO_EVENTO() As String
        Get
            Return Me._NOMBRE_METODO_PAGO_EVENTO
        End Get
    End Property

    Public ReadOnly Property ESTATUS() As String
        Get
            Return Me._ESTATUS
        End Get
    End Property

    Public ReadOnly Property ES_DEFAULT() As Boolean
        Get
            Return Me._ES_DEFAULT
        End Get
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
        Me._Nombre_Catalogo = "CFD_CAT_METODOS_PAGO_EVENTOS"
        Me._Nombre_Reporte = "RPT_CFD_CAT_METODOS_PAGO_EVENTOS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT * FROM CFD_CAT_METODOS_PAGO_EVENTOS"
        Me._QueryOrder = " ORDER BY NOMBRE_METODO_PAGO_EVENTO"
    End Sub

    Public Sub New(ByVal sCodigo As String)
        Me.New()
        Me._CODIGO_METODO_PAGO_EVENTO = sCodigo
        Try
            If Me.Consultar = True Then
                Me._EXISTE = True
            Else
                Throw New Exception("El método de pago no existe.")
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
    Public Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_METODO_PAGO_EVENTO,CODIGO_METODO_PAGO_EVENTO + ' - ' + NOMBRE_METODO_PAGO_EVENTO NOMBRE_METODO_PAGO_EVENTO FROM CFD_CAT_METODOS_PAGO_EVENTOS WHERE ESTATUS='A' ORDER BY CODIGO_METODO_PAGO_EVENTO", Empresa_Sistema.conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE CODIGO_METODO_PAGO_EVENTO='" & Me._CODIGO_METODO_PAGO_EVENTO & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_METODO_PAGO_EVENTO = dReader("CODIGO_METODO_PAGO_EVENTO").ToString
                    Me._NOMBRE_METODO_PAGO_EVENTO = Trim("" & dReader("NOMBRE_METODO_PAGO_EVENTO").ToString)
                    Me._ESTATUS = dReader("ESTATUS").ToString
                    Me._ES_DEFAULT = CBool(dReader("ES_DEFAULT").ToString)

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

#End Region

End Class
