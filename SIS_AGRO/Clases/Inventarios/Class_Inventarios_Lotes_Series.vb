Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class Class_Inventarios_Lotes_Series

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_INVENTARIO_LOTES_COSTOS As String
    Private _CODIGO_ARTICULO As String
    Private _CODIGO_ALMACEN As String
    Private _CANTIDAD_ORIGINAL As Double
    Private _CANTIDAD_DISPONIBLE As Double
    Private _COSTO As Double
    Private _NUMERO_SERIE As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean
#End Region

#Region "Campos públicos"

#End Region

#Region "Campos privados"

#End Region

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public ReadOnly Property ID_INVENTARIO_LOTES_COSTOS As String
        Get
            Return Me._ID_INVENTARIO_LOTES_COSTOS
        End Get
    End Property

    Public ReadOnly Property CODIGO_ARTICULO As String
        Get
            Return Me._CODIGO_ARTICULO
        End Get
    End Property

    Public ReadOnly Property CODIGO_ALMACEN As String
        Get
            Return Me._CODIGO_ALMACEN
        End Get
    End Property

    Public ReadOnly Property CANTIDAD_ORIGINAL As Double
        Get
            Return Me._CANTIDAD_ORIGINAL
        End Get
    End Property

    Public ReadOnly Property CANTIDAD_DISPONIBLE As Double
        Get
            Return Me._CANTIDAD_DISPONIBLE
        End Get
    End Property

    Public ReadOnly Property COSTO As Double
        Get
            Return Me._COSTO
        End Get
    End Property

    Public ReadOnly Property NUMERO_SERIE As String
        Get
            Return Me._NUMERO_SERIE
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

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

#End Region

#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_Inventarios_Lotes_Series"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
    End Sub

    Public Sub New(ByVal ID_INVENTARIO_LOTES_COSTOS As String)
        Me.New()
        Try
            Me._ID_INVENTARIO_LOTES_COSTOS = ID_INVENTARIO_LOTES_COSTOS
            If Me.Consultar = True Then
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand("SELECT * FROM VW_INVENTARIO_LOTES_COSTOS_EXTENDIDO WHERE ID_INVENTARIO_LOTES_COSTOS='" & Replace(Me._ID_INVENTARIO_LOTES_COSTOS, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._ID_INVENTARIO_LOTES_COSTOS = dReader("ID_INVENTARIO_LOTES_COSTOS").ToString
                    Me._CODIGO_ARTICULO = dReader("CODIGO_ARTICULO").ToString
                    Me._CODIGO_ALMACEN = dReader("CODIGO_ALMACEN1").ToString
                    Me._CANTIDAD_ORIGINAL = CDbl(dReader("CANTIDAD_ORIGINAL").ToString)
                    Me._CANTIDAD_DISPONIBLE = CDbl(dReader("CANTIDAD_DISPONIBLE").ToString)
                    Me._COSTO = CDbl(dReader("COSTO").ToString)
                    Me._NUMERO_SERIE = dReader("NUMERO_SERIE").ToString

                    bResultado = True
                End If

                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
        Return bResultado
    End Function

    Public Function BusquedaVisual(ByVal sCodigoArticulo As String, ByVal sCodigoAlmacen As String) As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        Dim oArticulo As New Class_CatArticulos(sCodigoArticulo)

        f.Text = "Búsqueda de series del artículo : " & oArticulo.DESCRIPCION
        f.sCampo = "NUMERO_SERIE"
        f.sOrder = "FECHA"
        f.sTable = "VW_INVENTARIO_LOTES_COSTOS_EXTENDIDO"
        f.sQl = "SELECT ID_INVENTARIO_LOTES_COSTOS,NUMERO_SERIE,DBO.FN_FORMAT_FECHA_CORTO(FECHA) " &
            "FROM VW_INVENTARIO_LOTES_COSTOS_EXTENDIDO WHERE CODIGO_ARTICULO='" & sReplace(sCodigoArticulo) & "' AND CODIGO_ALMACEN1='" & sReplace(sCodigoAlmacen) & "' AND CANTIDAD_DISPONIBLE>0 AND LEN(NUMERO_SERIE)>0 AND "
        f.Inicia("%")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "BusquedaVisual", ex)
        End Try
        Return Resultado
    End Function

    Public Structure Lote
        Dim FolioMovimiento As String
        Dim Cantidad As Double
    End Structure

    Public Function BusquedaVisualSeriesMultiplesFolio(ByVal sCodigoArticulo As String, ByVal sCodigoAlmacen As String) As Lote
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        Dim oArticulo As New Class_CatArticulos(sCodigoArticulo)
        Dim lote As New Lote

        If oArticulo.Existe = False Then
            Return lote
        End If

        f.Text = "Búsqueda de series del artículo : " & oArticulo.DESCRIPCION
        f.sCampo = "FOLIO_MOVIMIENTO_INVENTARIO"
        f.sOrder = "FECHA,FOLIO_MOVIMIENTO_INVENTARIO "
        f.sTable = "VW_INVENTARIO_SERIES_DISPONIBLES_POR_FOLIO"

        f.sQl = "SELECT FOLIO_MOVIMIENTO_INVENTARIO,FECHA,CANTIDAD " & _
                    "FROM VW_INVENTARIO_SERIES_DISPONIBLES_POR_FOLIO " & _
                    "WHERE CODIGO_ARTICULO='" & sReplace(sCodigoArticulo) & "' AND CODIGO_ALMACEN='" & sReplace(sCodigoAlmacen) & "' AND "

        f.Inicia("%")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                lote.FolioMovimiento = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
                lote.Cantidad = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 2), Double)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "BusquedaVisualSeriesMultiplesFolio", ex)
        End Try
        Return lote
    End Function

    Public Function ObtieneRenglonesSeriesFolio(ByVal sFolio As String, ByVal sCodigoArticulo As String) As DataTable
        Dim dt As New DataTable
        Try

            Using da As New SqlDataAdapter("SELECT ID_INVENTARIO_LOTES_COSTOS,CANTIDAD_DISPONIBLE,NUMERO_SERIE " & _
                                            "FROM VW_INVENTARIO_LOTES_COSTOS_EXTENDIDO " & _
                                            "WHERE FOLIO_MOVIMIENTO_INVENTARIO=@FOLIO_MOVIMIENTO_INVENTARIO AND CODIGO_ARTICULO=@CODIGO_ARTICULO AND CANTIDAD_DISPONIBLE>0 AND LEN(NUMERO_SERIE)>0 " & _
                                            "ORDER BY ID_INVENTARIO_LOTES_COSTOS", Me._Conexion)

                da.SelectCommand.CommandType = CommandType.Text

                With da.SelectCommand
                    .Parameters.Add("@FOLIO_MOVIMIENTO_INVENTARIO", SqlDbType.NVarChar, 15).Value = sFolio
                    .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16).Value = sCodigoArticulo
                End With

                da.Fill(dt)
            End Using

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtieneRenglonesSeriesFolio", ex)
        Finally

        End Try
        Return dt
    End Function
#End Region

End Class
