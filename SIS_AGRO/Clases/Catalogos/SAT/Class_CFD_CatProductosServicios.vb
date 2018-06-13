Option Strict On

Imports System.Data.SqlClient

Public Class Class_CFD_CatProductosServicios

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_PRODUCTO_SERVICIO As String
    Private _NOMBRE_PRODUCTO_SERVICIO As String
    Private _NOMBRE_PRODUCTO_SERVICIO_SIMILAR As String
    Private _ESTATUS As String
    Private _TIPO As String
    Private _ESMAYOR As Boolean
    Private _NIVEL As String
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
    Public ReadOnly Property CODIGO_PRODUCTO_SERVICIO() As String
        Get
            Return Me._CODIGO_PRODUCTO_SERVICIO
        End Get
    End Property

    Public ReadOnly Property NOMBRE_PRODUCTO_SERVICIO() As String
        Get
            Return Me._NOMBRE_PRODUCTO_SERVICIO
        End Get
    End Property

    Public ReadOnly Property NOMBRE_PRODUCTO_SERVICIO_SIMILAR() As String
        Get
            Return Me._NOMBRE_PRODUCTO_SERVICIO_SIMILAR
        End Get
    End Property

    Public ReadOnly Property ESTATUS() As String
        Get
            Return Me._ESTATUS
        End Get
    End Property

    Public ReadOnly Property TIPO() As String
        Get
            Return Me._TIPO
        End Get
    End Property

    Public ReadOnly Property ESMAYOR() As Boolean
        Get
            Return Me._ESMAYOR
        End Get
    End Property

    Public ReadOnly Property NIVEL() As String
        Get
            Return Me._NIVEL
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
        Me._Nombre_Catalogo = "CFDI_CAT_PRODUCTOS_Y_SERVICIOS"
        Me._Nombre_Reporte = "RPT_CFDI_CAT_PRODUCTOS_Y_SERVICIOS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT * FROM CFDI_CAT_PRODUCTOS_Y_SERVICIOS"
        Me._QueryOrder = " ORDER BY NOMBRE_PRODUCTO_SERVICIO"
    End Sub

    Public Sub New(ByVal sCodigo As String)
        Me.New()
        Me._CODIGO_PRODUCTO_SERVICIO = sCodigo
        Try
            If Me.Consultar = True Then
                Me._EXISTE = True
            Else
                Throw New Exception("El producto/servicio no existe.")
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
        Dim da As New SqlDataAdapter("SELECT CODIGO_PRODUCTO_SERVICIO,CODIGO_PRODUCTO_SERVICIO + ' - ' + NOMBRE_PRODUCTO_SERVICIO NOMBRE_PRODUCTO_SERVICIO FROM CFDI_CAT_PRODUCTOS_Y_SERVICIOS ORDER BY CODIGO_PRODUCTO_SERVICIO", Empresa_Sistema.conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosporNivel(sTipo As String, iNivel As Integer, Optional sDescripcion As String = "") As System.Data.DataTable
        Dim dTable As New DataTable
        Dim sQl As String
        If iNivel >= 2 And sDescripcion <> "" Then
            sQl = "SELECT CODIGO_PRODUCTO_SERVICIO,CODIGO_PRODUCTO_SERVICIO + ' - ' + NOMBRE_PRODUCTO_SERVICIO NOMBRE_PRODUCTO_SERVICIO FROM CFDI_CAT_PRODUCTOS_Y_SERVICIOS " &
            "WHERE NIVEL=" & iNivel & " AND TIPO='" & sTipo & "' AND CODIGO_PRODUCTO_SERVICIO like " &
            " (LEFT(" & sDescripcion & "," & iNivel + (iNivel - 2) & ") + '%')"
        Else
            sQl = "SELECT CODIGO_PRODUCTO_SERVICIO,CODIGO_PRODUCTO_SERVICIO + ' - ' + NOMBRE_PRODUCTO_SERVICIO NOMBRE_PRODUCTO_SERVICIO FROM CFDI_CAT_PRODUCTOS_Y_SERVICIOS " &
            "WHERE NIVEL=" & iNivel & " AND TIPO='" & sTipo & "' "
        End If
        Dim da As New SqlDataAdapter(sQl, Empresa_Sistema.conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosNivel", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementospoFiltro(sTipo As String, iNivel As Integer, sCodigo As String) As System.Data.DataTable
        Dim Sql, Filtro As String
        Sql = " SELECT CODIGO_PRODUCTO_SERVICIO,NOMBRE_PRODUCTO_SERVICIO,NOMBRE_PRODUCTO_SERVICIO_SIMILAR,NIVEL FROM CFDI_CAT_PRODUCTOS_Y_SERVICIOS WHERE TIPO='" & sTipo & "' "
        If iNivel = 1 Then
            Filtro = "  AND ( CODIGO_PRODUCTO_SERVICIO like (LEFT('" & sCodigo & "',2) +'%')   ) "
        ElseIf iNivel = 2 Then
            Filtro = "  AND ( CODIGO_PRODUCTO_SERVICIO like (LEFT('" & sCodigo & "',4) +'%') " &
                         " OR CODIGO_PRODUCTO_SERVICIO like (LEFT('" & sCodigo & "',2) + '000000') ) "
        ElseIf iNivel = 3 Then
            Filtro = " AND ( CODIGO_PRODUCTO_SERVICIO like (LEFT('" & sCodigo & "',6) +'%')" &
               " OR CODIGO_PRODUCTO_SERVICIO like (LEFT('" & sCodigo & "',4) + '0000')  " &
               " OR CODIGO_PRODUCTO_SERVICIO like (LEFT('" & sCodigo & "',2) + '000000') )"
        Else
            Filtro = ""
        End If

        Dim dTable As New DataTable
        'Dim sQl As String
        'Sql = "SELECT CODIGO_PRODUCTO_SERVICIO,CODIGO_PRODUCTO_SERVICIO + ' - ' + NOMBRE_PRODUCTO_SERVICIO NOMBRE_PRODUCTO_SERVICIO FROM CFDI_CAT_PRODUCTOS_Y_SERVICIOS " &
        '    "WHERE NIVEL=" & iNivel & " AND TIPO='" & sTipo & "' "
        Dim da As New SqlDataAdapter(Sql & Filtro, Empresa_Sistema.conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementospoFiltro", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE CODIGO_PRODUCTO_SERVICIO='" & Me._CODIGO_PRODUCTO_SERVICIO & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_PRODUCTO_SERVICIO = dReader("CODIGO_PRODUCTO_SERVICIO").ToString
                    Me._NOMBRE_PRODUCTO_SERVICIO = dReader("NOMBRE_PRODUCTO_SERVICIO").ToString
                    Me._NOMBRE_PRODUCTO_SERVICIO_SIMILAR = dReader("NOMBRE_PRODUCTO_SERVICIO_SIMILAR").ToString
                    Me._ESTATUS = dReader("ESTATUS").ToString
                    Me._TIPO = dReader("TIPO").ToString
                    Me._ESMAYOR = CBool(dReader("ESMAYOR").ToString)
                    Me._NIVEL = dReader("NIVEL").ToString

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

    Public Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de productos/servicios por descripción."
        f.sCampo = "NOMBRE_PRODUCTO_SERVICIO,NOMBRE_PRODUCTO_SERVICIO_SIMILAR"
        f.sOrder = "NOMBRE_PRODUCTO_SERVICIO"
        f.sTable = "CFDI_CAT_PRODUCTOS_Y_SERVICIOS"
        f.sQl = "SELECT P.CODIGO_PRODUCTO_SERVICIO CODIGO_SAT,P.NOMBRE_PRODUCTO_SERVICIO,COALESCE(P.NOMBRE_PRODUCTO_SERVICIO_SIMILAR,'') NOMBRE_PRODUCTO_SERVICIO_SIMILAR," &
            "(SELECT NOMBRE_PRODUCTO_SERVICIO FROM CFDI_CAT_PRODUCTOS_Y_SERVICIOS WHERE CODIGO_PRODUCTO_SERVICIO=LEFT(P.CODIGO_PRODUCTO_SERVICIO,LEN(P.CODIGO_PRODUCTO_SERVICIO)-2)+'00')CLASE, " &
            "(SELECT NOMBRE_PRODUCTO_SERVICIO FROM CFDI_CAT_PRODUCTOS_Y_SERVICIOS WHERE CODIGO_PRODUCTO_SERVICIO=LEFT(P.CODIGO_PRODUCTO_SERVICIO,LEN(P.CODIGO_PRODUCTO_SERVICIO)-4)+'0000')GRUPO, " &
            "(SELECT NOMBRE_PRODUCTO_SERVICIO FROM CFDI_CAT_PRODUCTOS_Y_SERVICIOS WHERE CODIGO_PRODUCTO_SERVICIO=LEFT(P.CODIGO_PRODUCTO_SERVICIO,LEN(P.CODIGO_PRODUCTO_SERVICIO)-6)+'000000')DIVISION " &
            " FROM CFDI_CAT_PRODUCTOS_Y_SERVICIOS P WHERE 1=1 AND "
        f.arrayWidthColumns = New Integer() {100, 400, 400, 300, 300, 300}
        f.BuscaTodaCadena = True
        f.BuscarDatatableLocal = True
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_CatalogoProductosServicios() As String
        Dim f As New BusquedaCatalogoProductosServicios
        Dim Resultado As String = ""
        f.Text = "Catálogo de productos/servicios."
        'f.sCampo = "NOMBRE_PRODUCTO_SERVICIO"
        'f.sOrder = "NOMBRE_PRODUCTO_SERVICIO"
        'f.sTable = "CFDI_CAT_PRODUCTOS_Y_SERVICIOS"
        'f.sQl = "SELECT CODIGO_PRODUCTO_SERVICIO,NOMBRE_PRODUCTO_SERVICIO FROM CFDI_CAT_PRODUCTOS_Y_SERVICIOS WHERE 1=1 AND "
        'f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.Grid.Item("CODIGO_PRODUCTO_SERVICIO", f.Grid.SelectedRows(0).Index).Value, String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_CatalogoProductosServicios", ex)
        End Try
        Return Resultado
    End Function

#End Region

End Class
