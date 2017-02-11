Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CFD_CatMetodosPago

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_METODO_PAGO As String
    Private _NOMBRE_METODO_PAGO As String
    Private _REQUIERE_NUMERO_CUENTA_PAGO As Integer
    Private _ESTATUS As String
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
    Public Property CODIGO_METODO_PAGO() As String
        Get
            Return Me._CODIGO_METODO_PAGO
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_METODO_PAGO = VALUE
        End Set
    End Property

    Public Property NOMBRE_METODO_PAGO() As String
        Get
            Return Me._NOMBRE_METODO_PAGO
        End Get
        Set(ByVal VALUE As String)
            Me._NOMBRE_METODO_PAGO = VALUE
        End Set
    End Property

    Public Property REQUIERE_NUMERO_CUENTA_PAGO() As Integer
        Get
            Return Me._REQUIERE_NUMERO_CUENTA_PAGO
        End Get
        Set(ByVal VALUE As Integer)
            Me._REQUIERE_NUMERO_CUENTA_PAGO = VALUE
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
        Me._Nombre_Catalogo = "CFD_CAT_METODOS_PAGO"
        Me._Nombre_Reporte = "RPT_CFD_CAT_METODOS_PAGO"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT * FROM CFD_CAT_METODOS_PAGO"
        Me._QueryOrder = " ORDER BY NOMBRE_METODO_PAGO"
    End Sub

    Public Sub New(ByVal sCodigo As String)
        Me.New()
        Me._CODIGO_METODO_PAGO = sCodigo
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
        Dim da As New SqlDataAdapter("SELECT CODIGO_METODO_PAGO,NOMBRE_METODO_PAGO FROM CFD_CAT_METODOS_PAGO WHERE ESTATUS='A' ORDER BY CODIGO_METODO_PAGO", Empresa_Sistema.conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosParaFacturacion() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_METODO_PAGO,NOMBRE_METODO_PAGO,ESTATUS FROM CFD_CAT_METODOS_PAGO ORDER BY CODIGO_METODO_PAGO", Empresa_Sistema.conexion) 'NO FILTRAMOS AQUI ESTATUS, PERO SI EN EL DESPLIEGA DEPENDIENDO SI NUEVO FACT, O CONSULTA
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosParaFacturacion", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerMetodosPagoParaReportes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_METODO_PAGO,NOMBRE_METODO_PAGO FROM CFD_CAT_METODOS_PAGO", Empresa_Sistema.conexion)
        Try
            da.Fill(dTable)
            dTable.Rows.Add("T", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerMetodosPagoParaReportes", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE CODIGO_METODO_PAGO='" & Me._CODIGO_METODO_PAGO & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_METODO_PAGO = dReader("CODIGO_METODO_PAGO").ToString
                    Me._NOMBRE_METODO_PAGO = Trim("" & dReader("NOMBRE_METODO_PAGO").ToString)
                    Me._REQUIERE_NUMERO_CUENTA_PAGO = CInt(dReader("REQUIERE_NUMERO_CUENTA_PAGO").ToString)
                    Me._ESTATUS = dReader("ESTATUS").ToString

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
