Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Class_Contabilidad_Reportes

#Region "Campos"
#Region "Campos privados"
    Private _ID_CON_PERIODO1 As Integer
    Private _ID_CON_PERIODO2 As Integer
    Private _FECHA1 As Date
    Private _FECHA2 As Date
    Private _ID_CON_EJERCICIO As Integer
    Private _ESTATUS_POLIZA As String
    Private _CODIGO_TIPO_DOCUMENTO As String
    Private _CODIGO_PLAZA As String
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
    Public WriteOnly Property CODIGO_PLAZA() As Integer
        Set(ByVal value As Integer)
            Me._CODIGO_PLAZA = value
        End Set
    End Property
#End Region

#Region "Propiedad Nombre de Clase"
    Private ReadOnly Property NombreClase()
        Get
            NombreClase = "Class_Contabilidad_Reportes"
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
    Public Sub ReporteGlobalPolizasRpt()
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            oReporte = New Class_Reporte("RPT_CONTABILIDAD_GLOBAL_POLIZAS.rpt", Rpt)

            Rpt.SetParameterValue("@ID_CON_PERIODO1", 1)
            Rpt.SetParameterValue("@ID_CON_PERIODO2", 13)
            Rpt.SetParameterValue("@FECHA1", Format(Me._FECHA1, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA2", Format(Me._FECHA2, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@ID_CON_EJERCICIO", Me._ID_CON_EJERCICIO)
            Rpt.SetParameterValue("@ESTATUS_POLIZA", Me._ESTATUS_POLIZA)
            Rpt.SetParameterValue("@CODIGO_TIPO_DOCUMENTO", Me._CODIGO_TIPO_DOCUMENTO)
            Rpt.SetParameterValue("@CODIGO_PLAZA", Me._CODIGO_PLAZA)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ExportReport()
            frm.Show()
        Catch ex As Exception
            HandleError(Me.NombreClase, "ReporteGlobalPolizasRpt", ex)
        Finally
            oReporte = Nothing
            Rpt.Dispose()
        End Try
    End Sub    'Obtiene una lita completa de los elementos del catalogo en un datatable.

    Public Function ReporteGlobalPolizasDatatable() As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_RPT_CONTABILIDAD_GLOBAL_POLIZAS", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            With da.SelectCommand
                .Parameters.Add("@ESTATUS_POLIZA", SqlDbType.NVarChar, 1)
                .Parameters.Add("@CODIGO_TIPO_DOCUMENTO", SqlDbType.NVarChar, 1)
                .Parameters.Add("@FECHA1", SqlDbType.NVarChar, 12)
                .Parameters.Add("@FECHA2", SqlDbType.NVarChar, 12)
                .Parameters.Add("@ID_CON_EJERCICIO", SqlDbType.SmallInt)
                .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt)

                .Parameters("@ESTATUS_POLIZA").Value = Me._ESTATUS_POLIZA
                .Parameters("@CODIGO_TIPO_DOCUMENTO").Value = Left(Me._CODIGO_TIPO_DOCUMENTO, 1)
                .Parameters("@FECHA1").Value = Format(Me._FECHA1, "yyyy-dd-MM")
                .Parameters("@FECHA2").Value = Format(Me._FECHA2, "yyyy-dd-MM")
                .Parameters("@ID_CON_EJERCICIO").Value = Me._ID_CON_EJERCICIO
                .Parameters("@CODIGO_PLAZA").Value = Me._CODIGO_PLAZA

            End With
            da.Fill(dt)
            dt.Columns.Remove("EMPRESA_NOMBRE")
            dt.Columns.Remove("EMPRESA_DOMICILIO")
            dt.Columns.Remove("EMPRESA_CIUDAD")
            dt.Columns.Remove("EMPRESA_ESTADO")
            dt.Columns.Remove("EMPRESA_RFC")
            dt.Columns.Remove("EMPRESA_TELEFONO")
            dt.Columns.Remove("G_FOLIO_ORIGEN")
            'dt.Columns.Remove("R_CONCEPTO")
        Catch ex As Exception
            HandleError(Me.NombreClase, "ReporteGlobalPolizasDatatable", ex)
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
