Imports System.Data
Imports System.Data.SqlClient

Public Class Class_Contabilidad_RP_Global_Poliza

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_CON_PERIODO1 As Integer
    Private _ID_CON_PERIODO2 As Integer
    Private _FECHA1 As Date
    Private _FECHA2 As Date
    Private _ID_CON_EJERCICIO As Integer
    Private _ESTATUS_POLIZA As String
    Private _CODIGO_TIPO_DOCUMENTO As String
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
    Public WriteOnly Property FECHA1() As Date
        Set(ByVal value As Date)
            Me._FECHA1 = value
        End Set
    End Property
    Public WriteOnly Property FECHA2() As Date
        Set(ByVal value As Date)
            Me._FECHA2 = value
        End Set
    End Property
    Public WriteOnly Property ID_CON_EJERCICIO() As Integer
        Set(ByVal value As Integer)
            Me._ID_CON_EJERCICIO = value
        End Set
    End Property
    Public WriteOnly Property ESTATUS_POLIZA() As String
        Set(ByVal value As String)
            Me._ESTATUS_POLIZA = value
        End Set
    End Property
    Public WriteOnly Property CODIGO_TIPO_DOCUMENTO() As String
        Set(ByVal value As String)
            Me._CODIGO_TIPO_DOCUMENTO = value
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

#Region "Opciones"

#End Region

#Region "Métodos y procedimientos"
    Public Function Consultar() As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_RPT_CONTABILIDAD_GLOBAL_POLIZAS", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            With da.SelectCommand
                .Parameters.Add("@ESTATUS_POLIZA", SqlDbType.NVarChar, 1)
                .Parameters("@ESTATUS_POLIZA").Value = Me._ESTATUS_POLIZA
                .Parameters.Add("@CODIGO_TIPO_DOCUMENTO", SqlDbType.NVarChar, 1)
                .Parameters("@CODIGO_TIPO_DOCUMENTO").Value = Left(Me._CODIGO_TIPO_DOCUMENTO, 1)
                .Parameters.Add("@ID_CON_PERIODO1", SqlDbType.SmallInt)
                .Parameters("@ID_CON_PERIODO1").Value = Me._ID_CON_PERIODO1
                .Parameters.Add("@ID_CON_PERIODO2", SqlDbType.SmallInt)
                .Parameters("@ID_CON_PERIODO2").Value = Me._ID_CON_PERIODO2
                .Parameters.Add("@FECHA1", SqlDbType.NVarChar, 12)
                .Parameters("@FECHA1").Value = Format(Me._FECHA1, "yyyy-dd-MM")
                .Parameters.Add("@FECHA2", SqlDbType.NVarChar, 12)
                .Parameters("@FECHA2").Value = Format(Me._FECHA2, "yyyy-dd-MM")
                .Parameters.Add("@ID_CON_EJERCICIO", SqlDbType.SmallInt)
                .Parameters("@ID_CON_EJERCICIO").Value = Me._ID_CON_EJERCICIO
            End With
            da.Fill(dt)
        Catch ex As Exception
            HandleError("Class_RP_Contabilidad_Global_Polizas", "Consultar", ex)
        Finally

        End Try
        Return dt
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.


#End Region

#Region "Eventos de objetos"

#Region "Eventos de la lista de elementos"

#End Region

#Region " Eventos de TxtFiltro"

#End Region

#Region "Eventos Genericos"

#End Region

#Region "Keydown específicos"


#End Region

#Region "Validating específicos"

#End Region

#End Region






End Class
