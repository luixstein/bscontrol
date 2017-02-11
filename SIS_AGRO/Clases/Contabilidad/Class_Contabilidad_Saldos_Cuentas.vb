Imports System.Data
Imports System.Data.SqlClient
Public Class Class_Contabilidad_Saldos_Cuentas

#Region "Campos"

#Region "Campos de la tabla"
    Private _CUENTA_CONTABLE As String
    Private _ID_CON_PERIODO1 As Integer
    Private _ID_CON_PERIODO2 As Integer
    Private _ID_CON_EJERCICIO As Integer
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

    Public WriteOnly Property CUENTA_CONTABLE() As String
        Set(ByVal value As String)
            Me._CUENTA_CONTABLE = value
        End Set
    End Property
    Public WriteOnly Property ID_CON_PERIODO1() As Integer
        Set(ByVal value As Integer)
            Me._ID_CON_PERIODO1 = value
        End Set
    End Property
    Public WriteOnly Property ID_CON_PERIODO2() As Integer
        Set(ByVal value As Integer)
            Me._ID_CON_PERIODO2 = value
        End Set
    End Property 
    Public WriteOnly Property ID_CON_EJERCICIO() As Integer
        Set(ByVal value As Integer)
            Me._ID_CON_EJERCICIO = value
        End Set
    End Property

#End Region

#Region "Propiedad Nombre de Clase"
    Private ReadOnly Property NombreClase()
        Get
            NombreClase = "Class_Contabilidad_Saldos_Cuentas"
        End Get
    End Property
#End Region
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
    End Sub                                                         'Inicializa al objeto.

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function Consultar() As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("RPT_CONTABILIDAD_SALDOS_CUENTA_CONTABLE", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            With da.SelectCommand
                .Parameters.Add("@CUENTA_CONTABLE", SqlDbType.NVarChar, 15) : .Parameters("@CUENTA_CONTABLE").Value = Me._CUENTA_CONTABLE
                .Parameters.Add("@ID_CON_PERIODO1", SqlDbType.SmallInt) : .Parameters("@ID_CON_PERIODO1").Value = Val(0 = Me._ID_CON_PERIODO1)
                .Parameters.Add("@ID_CON_PERIODO2", SqlDbType.SmallInt) : .Parameters("@ID_CON_PERIODO2").Value = Val(0 = Me._ID_CON_PERIODO2)
                .Parameters.Add("@ID_CON_EJERCICIO", SqlDbType.SmallInt) : .Parameters("@ID_CON_EJERCICIO").Value = Me._ID_CON_EJERCICIO
            End With
            da.Fill(dt)
        Catch ex As Exception
            HandleError(Me.NombreClase, "Consultar", ex)
        Finally
        End Try
        Return dt
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.


#End Region

End Class



