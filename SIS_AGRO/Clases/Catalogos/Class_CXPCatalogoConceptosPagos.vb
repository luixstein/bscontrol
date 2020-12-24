Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Class_CXPCatalogoConceptosPagos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_CONCEPTO_PAGO_CXP As String
    Private _NOMBRE_CONCEPTO_PAGO_CXP As String
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
    Public Property CODIGO_CONCEPTO_PAGO_CXP() As String
        Get
            Return Me._CODIGO_CONCEPTO_PAGO_CXP
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_CONCEPTO_PAGO_CXP = VALUE
        End Set
    End Property

    Public Property NOMBRE_CONCEPTO_PAGO_CXP() As String
        Get
            Return Me._NOMBRE_CONCEPTO_PAGO_CXP
        End Get
        Set(ByVal VALUE As String)
            Me._NOMBRE_CONCEPTO_PAGO_CXP = VALUE
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
        Me._Nombre_Catalogo = "CXP_CATALOGO_CONCEPTOS_PAGOS"
        Me._Nombre_Reporte = "RPT_CATALOGO_CONCEPTOS_PAGOS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT * FROM CXP_CATALOGO_CONCEPTOS_PAGOS"
        Me._QueryOrder = " ORDER BY NOMBRE_CONCEPTO_PAGO_CXP"
    End Sub

    Public Sub New(ByVal sCodigo As String)
        Me.New()
        Me._CODIGO_CONCEPTO_PAGO_CXP = sCodigo
        Try
            If Me.Consultar = True Then
                Me._EXISTE = True
            Else
                Throw New Exception("El tipo de pago no existe.")
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "New", ex)
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
        Dim ds As New SqlDataAdapter("SELECT CODIGO_CONCEPTO_PAGO_CXP,NOMBRE_CONCEPTO_PAGO_CXP FROM CXP_CATALOGO_CONCEPTOS_PAGOS WHERE ESTATUS='A' ORDER BY NOMBRE_CONCEPTO_PAGO_CXP", Empresa_Sistema.conexion)
        Try
            ds.Fill(dTable)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            ds.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosParaReportes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim ds As New SqlDataAdapter("SELECT CODIGO_CONCEPTO_PAGO_CXP,NOMBRE_CONCEPTO_PAGO_CXP FROM CXP_CATALOGO_CONCEPTOS_PAGOS ORDER BY NOMBRE_CONCEPTO_PAGO_CXP", Empresa_Sistema.conexion)
        Try
            ds.Fill(dTable)
            dTable.Rows.Add("0", "TODOS")
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerElementosParaReportes", ex)
        Finally
            ds.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String, ByVal Estatus As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT CODIGO_CONCEPTO_PAGO_CXP,NOMBRE_CONCEPTO_PAGO_CXP FROM CXP_CATALOGO_CONCEPTOS_PAGOS WHERE NOMBRE_CONCEPTO_PAGO_CXP LIKE '" & Filtro.ToString & "%' AND ESTATUS ='" & Estatus & "' ORDER BY NOMBRE_CONCEPTO_PAGO_CXP", Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
    End Function

    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE CODIGO_CONCEPTO_PAGO_CXP=" & Me._CODIGO_CONCEPTO_PAGO_CXP, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_CONCEPTO_PAGO_CXP = "" & dReader("CODIGO_CONCEPTO_PAGO_CXP").ToString
                    Me._NOMBRE_CONCEPTO_PAGO_CXP = "" & dReader("NOMBRE_CONCEPTO_PAGO_CXP").ToString
                    Me._ESTATUS = "" & dReader("ESTATUS").ToString
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

    Public Function Insertar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_CONCEPTOS_PAGOS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_CONCEPTO_PAGO_CXP", SqlDbType.SmallInt) : sqlParametro.Value = "0" 'El codigo se genera en el stored
            sqlParametro = .Parameters.Add("@NOMBRE_CONCEPTO_PAGO_CXP", SqlDbType.NVarChar, 100) : sqlParametro.Value = Me._NOMBRE_CONCEPTO_PAGO_CXP.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.ESTATUS.ToString.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
                Me._CODIGO_CONCEPTO_PAGO_CXP = "" & .Parameters("@CODIGO_CONCEPTO_PAGO_CXP").Value.ToString
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Insertar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function Actualizar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_CONCEPTOS_PAGOS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_CONCEPTO_PAGO_CXP", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_CONCEPTO_PAGO_CXP)
            sqlParametro = .Parameters.Add("@NOMBRE_CONCEPTO_PAGO_CXP", SqlDbType.NVarChar, 100) : sqlParametro.Value = Me._NOMBRE_CONCEPTO_PAGO_CXP.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.ESTATUS.ToString.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "0"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Actualizar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Sub Imprimir_Listado()   'Función para ver la búsqueda visual por descripción.
        If Len(Nombre_Reporte) > 0 Then
            Dim Rpt As New ReportDocument
            Dim oReporte As Class_Reporte
            Try
                oReporte = New Class_Reporte(Nombre_Reporte, Rpt)

                Dim frm As New Reporte(Rpt)
                frm.CRViewer.ShowGroupTreeButton = False
                frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                frm.Show()

            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, " Impresión del listado :" + Me.Nombre_Catalogo, ex)
            Finally
                oReporte = Nothing
                'Rpt.Dispose()
            End Try
        Else
            MsgBox("El nombre del reporte no ha sido especificado, no hay nada que imprimir.", MsgBoxStyle.Critical, Me.Nombre_Catalogo)
        End If
    End Sub

#End Region
End Class
