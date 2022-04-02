Imports System.Data.SqlClient

Public Class Class_CfdiCatTiposPermisosSCT

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_PERMISO_SCT As String
    Private _NOMBRE_PERMISO_SCT As String
    Private _LISTA_CODIGOS_TRANSPORTE As String

#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean
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
    Public ReadOnly Property CODIGO_PERMISO_SCT() As String
        Get
            Return Me._CODIGO_PERMISO_SCT
        End Get
    End Property

    Public ReadOnly Property NOMBRE_PERMISO_SCT() As String
        Get
            Return Me._NOMBRE_PERMISO_SCT
        End Get
    End Property

    Public ReadOnly Property LISTA_CODIGOS_TRANSPORTE() As String
        Get
            Return Me._LISTA_CODIGOS_TRANSPORTE
        End Get
    End Property

#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
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
        Me._Nombre_Catalogo = "CFDI_CAT_TIPOS_PERMISOS_SCT"
        Me._Nombre_Reporte = "RPT_CATALOGO_CFDI_TIPOS_PERMISOS_SCT"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * From CFDI_CAT_TIPOS_PERMISOS_SCT"
        Me._QueryOrder = " Order by NOMBRE_PERMISO_SCT"
    End Sub

    Public Sub New(ByVal sCodigoPermisoSCT As String)
        Me.New()
        Try
            Me._CODIGO_PERMISO_SCT = sCodigoPermisoSCT
            If Me.Consultar = True Then
                Me._Existe = True

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
        Const sProcedure As String = "Consultar"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand("SELECT * FROM CFDI_CAT_TIPOS_PERMISOS_SCT WHERE CODIGO_PERMISO_SCT='" & sReplace(Me._CODIGO_PERMISO_SCT) & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_PERMISO_SCT = "" & dReader("CODIGO_PERMISO_SCT").ToString
                    Me._NOMBRE_PERMISO_SCT = "" & dReader("NOMBRE_PERMISO_SCT").ToString
                    Me._LISTA_CODIGOS_TRANSPORTE = "" & dReader("LISTA_CODIGOS_TRANSPORTE")

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, sProcedure, ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
        Return bResultado
    End Function

    Public Function ObtenerElementos() As System.Data.DataTable
        Const sProcedure As String = "ObtenerElementos"
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosParaReportes() As System.Data.DataTable
        Const sProcedure As String = "ObtenerElementosParaReportes"
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
            dTable.Rows.Add("-1", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Const sProcedure As String = "ObtenerElementosFiltro"
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_PERMISO_SCT,NOMBRE_PERMISO_SCT FROM CFDI_CAT_TIPOS_PERMISOS_SCT WHERE NOMBRE_PERMISO_SCT LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_PERMISO_SCT", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function BusquedaVisual_PorCodigo() As String
        Const sProcedure As String = "BusquedaVisual_PorCodigo"
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de permisos SCT por código."
        f.sCampo = "CODIGO_PERMISO_SCT"
        f.sOrder = "NOMBRE_PERMISO_SCT"
        f.sTable = "CFDI_CAT_TIPOS_PERMISOS_SCT"
        f.sQl = "SELECT CODIGO_PERMISO_SCT,NOMBRE_PERMISO_SCT FROM CFDI_CAT_TIPOS_PERMISOS_SCT WHERE 1=1 AND "
        f.arrayWidthColumns = New Integer() {100, 400}
        f.Inicia("%")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, sProcedure, ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_PorDescripcion() As String
        Const sProcedure As String = "BusquedaVisual_PorDescripcion"
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de permisos SCT por nombre."
        f.sCampo = "NOMBRE_PERMISO_SCT"
        f.sOrder = "NOMBRE_PERMISO_SCT"
        f.sTable = "CFDI_CAT_TIPOS_PERMISOS_SCT"
        f.sQl = "SELECT CODIGO_PERMISO_SCT,NOMBRE_PERMISO_SCT FROM CFDI_CAT_TIPOS_PERMISOS_SCT WHERE 1=1 AND "
        f.arrayWidthColumns = New Integer() {100, 900}
        f.Inicia("%")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, sProcedure, ex)
        End Try
        Return Resultado
    End Function

#End Region

End Class