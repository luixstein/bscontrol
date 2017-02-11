Imports System.Data
Imports System.Data.SqlClient

Public Class Class_AuxiliarMayor

#Region "Campos"

#Region "Campos de la tabla"
    Private _CUENTA_CONTABLE1 As String
    Private _CUENTA_CONTABLE2 As String
    Private _FECHA1 As String
    Private _FECHA2 As String
    Private _MOSTRAR_SOLO_CUENTAS_CON_SALDO_MAYOR_QUE_CERO As Integer
    Private _ID_CON_EJERCICIO As Integer
    Private _FILTRO_CONTRAPOLIZAS As Integer
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

    Public WriteOnly Property CUENTA_CONTABLE1() As String
        Set(ByVal value As String)
            Me._CUENTA_CONTABLE1 = value
        End Set
    End Property
    Public WriteOnly Property CUENTA_CONTABLE2() As String
        Set(ByVal value As String)
            Me._CUENTA_CONTABLE2 = value
        End Set
    End Property
    Public WriteOnly Property FECHA1() As String
        Set(ByVal value As String)
            Me._FECHA1 = value
        End Set
    End Property
    Public WriteOnly Property FECHA2() As String
        Set(ByVal value As String)
            Me._FECHA2 = value
        End Set
    End Property
    Public WriteOnly Property MOSTRAR_SOLO_CUENTAS_CON_SALDO_MAYOR_QUE_CERO() As Integer
        Set(ByVal value As Integer)
            Me._MOSTRAR_SOLO_CUENTAS_CON_SALDO_MAYOR_QUE_CERO = value
        End Set
    End Property
    Public WriteOnly Property ID_CON_EJERCICIO() As Integer
        Set(ByVal value As Integer)
            Me._ID_CON_EJERCICIO = value
        End Set
    End Property

    Public WriteOnly Property FILTRO_CONTRAPOLIZAS() As Integer
        Set(ByVal value As Integer)
            Me._FILTRO_CONTRAPOLIZAS = value
        End Set
    End Property


#End Region

#Region "Propiedad Nombre de Clase"
    Private ReadOnly Property NombreClase()
        Get
            NombreClase = "Class_AuxiliarMayor"
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
            Dim da As New SqlDataAdapter("MP_RPT_CONTABILIDAD_AUXILIAR_DE_MAYOR", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            With da.SelectCommand
                .Parameters.Add("@CUENTA_CONTABLE1", SqlDbType.NVarChar, 20) : .Parameters("@CUENTA_CONTABLE1").Value = Me._CUENTA_CONTABLE1
                .Parameters.Add("@CUENTA_CONTABLE2", SqlDbType.NVarChar, 20) : .Parameters("@CUENTA_CONTABLE2").Value = Me._CUENTA_CONTABLE2
                .Parameters.Add("@FECHA1", SqlDbType.NVarChar, 20) : .Parameters("@FECHA1").Value = Me._FECHA1
                .Parameters.Add("@FECHA2", SqlDbType.NVarChar, 20) : .Parameters("@FECHA2").Value = Me._FECHA2
                .Parameters.Add("@ID_CON_EJERCICIO", SqlDbType.SmallInt) : .Parameters("@ID_CON_EJERCICIO").Value = Me._ID_CON_EJERCICIO
                .Parameters.Add("@MOSTRAR_SOLO_CUENTAS_CON_SALDO_MAYOR_QUE_CERO", SqlDbType.SmallInt) : .Parameters("@MOSTRAR_SOLO_CUENTAS_CON_SALDO_MAYOR_QUE_CERO").Value = Me._MOSTRAR_SOLO_CUENTAS_CON_SALDO_MAYOR_QUE_CERO
                .Parameters.Add("@FILTRO_CONTRAPOLIZAS", SqlDbType.SmallInt) : .Parameters("@FILTRO_CONTRAPOLIZAS").Value = Me._FILTRO_CONTRAPOLIZAS
            End With
            da.Fill(dt)
            dt.Columns.Remove("EMPRESA_NOMBRE")
            dt.Columns.Remove("EMPRESA_DOMICILIO")
            dt.Columns.Remove("EMPRESA_CIUDAD")
            dt.Columns.Remove("EMPRESA_ESTADO")
            dt.Columns.Remove("EMPRESA_RFC")
            dt.Columns.Remove("EMPRESA_TELEFONO")
            dt.Columns.Remove("NOMBRE_EJERCICIO")
            dt.Columns.Remove("IDTRANS")
            'dt.Columns.Remove("SALDO_TOTAL")
            'dt.Columns.Remove("CARGOS_GLOBAL")
            'dt.Columns.Remove("ABONOS_GLOBAL")

        Catch ex As Exception
            HandleError(Me.NombreClase, "Consultar", ex)
        Finally

        End Try
        Return dt
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.

    Public Function ConsultarEgresos() As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_RPT_CONTABILIDAD_EGRESOS", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            With da.SelectCommand
                .Parameters.Add("@CUENTA_CONTABLE1", SqlDbType.NVarChar, 20) : .Parameters("@CUENTA_CONTABLE1").Value = Me._CUENTA_CONTABLE1
                .Parameters.Add("@CUENTA_CONTABLE2", SqlDbType.NVarChar, 20) : .Parameters("@CUENTA_CONTABLE2").Value = Me._CUENTA_CONTABLE2
                .Parameters.Add("@FECHA_INICIO", SqlDbType.NVarChar, 20) : .Parameters("@FECHA_INICIO").Value = Format(Me._FECHA1, "yyyy-dd-MM")
                .Parameters.Add("@FECHA_FIN", SqlDbType.NVarChar, 20) : .Parameters("@FECHA_FIN").Value = Format(Me._FECHA2, "yyyy-dd-MM")
                .Parameters.Add("@ID_CON_EJERCICIO", SqlDbType.SmallInt) : .Parameters("@ID_CON_EJERCICIO").Value = Me._ID_CON_EJERCICIO
            End With
            da.Fill(dt)
            dt.Columns.Remove("EMPRESA_NOMBRE")
            dt.Columns.Remove("EMPRESA_DOMICILIO")
            dt.Columns.Remove("EMPRESA_CIUDAD")
            dt.Columns.Remove("EMPRESA_ESTADO")
            dt.Columns.Remove("EMPRESA_RFC")
            dt.Columns.Remove("EMPRESA_TELEFONO")
            dt.Columns.Remove("NOMBRE_EJERCICIO")
            dt.Columns.Remove("IDTRANS")
            dt.Columns.Remove("SALDO_TOTAL")
            dt.Columns.Remove("CARGOS_GLOBAL")
            dt.Columns.Remove("ABONOS_GLOBAL")

        Catch ex As Exception
            HandleError(Me.NombreClase, "ConsultarEgresos", ex)
        Finally

        End Try
        Return dt
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.

    Public Function ConsultarNavegadoPresupuesto() As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_RPT_NAVEGADOR_PRESUPUESTOS", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            With da.SelectCommand
                .Parameters.Add("@CUENTA_CONTABLE1", SqlDbType.NVarChar, 20) : .Parameters("@CUENTA_CONTABLE1").Value = Me._CUENTA_CONTABLE1
                .Parameters.Add("@CUENTA_CONTABLE2", SqlDbType.NVarChar, 20) : .Parameters("@CUENTA_CONTABLE2").Value = Me._CUENTA_CONTABLE2
                .Parameters.Add("@FECHA1", SqlDbType.NVarChar, 20) : .Parameters("@FECHA1").Value = Me._FECHA1
                .Parameters.Add("@FECHA2", SqlDbType.NVarChar, 20) : .Parameters("@FECHA2").Value = Me._FECHA2
                .Parameters.Add("@ID_CON_EJERCICIO", SqlDbType.SmallInt) : .Parameters("@ID_CON_EJERCICIO").Value = Me._ID_CON_EJERCICIO
            End With
            da.Fill(dt)
            dt.Columns.Remove("EMPRESA_NOMBRE")
            dt.Columns.Remove("EMPRESA_DOMICILIO")
            dt.Columns.Remove("EMPRESA_CIUDAD")
            dt.Columns.Remove("EMPRESA_ESTADO")
            dt.Columns.Remove("EMPRESA_RFC")
            dt.Columns.Remove("EMPRESA_TELEFONO")
            dt.Columns.Remove("NOMBRE_EJERCICIO")
            dt.Columns.Remove("CARGOS")
            dt.Columns.Remove("ABONOS")
            dt.Columns.Remove("ES_CULTIVO_DEL_PROYECTO")
            'dt.Columns.Remove("HECTAREAS_SEMBRADAS")

        Catch ex As Exception
            HandleError(Me.NombreClase, "ConsultarNavegadoPresupuesto", ex)
        Finally

        End Try
        Return dt
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.
#End Region

End Class


