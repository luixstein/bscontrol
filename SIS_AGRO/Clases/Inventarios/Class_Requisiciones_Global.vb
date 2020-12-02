Option Strict On

Imports System.Data.SqlClient

Public Class Class_Requisiciones_Global

#Region "Campos"

#Region "Campos de la tabla"
    Private _FOLIO_REQUISICION As String
    Private _FECHA_ENTREGA As Date
    Private _CODIGO_ALMACEN As String
    Private _CODIGO_USUARIO_COMPRADOR As String
    Private _CODIGO_PLAZA As Integer
    Private _CODIGO_DOCUMENTO As String
    Private _ESTATUS As String
    Private _CODIGO_USUARIO_GRABO As Integer
    Private _CODIGO_USUARIO_SOLICITO As Integer
    Private _CODIGO_USUARIO_CANCELO As Integer
    Private _FECHA_SOLICITO As Date
    Private _FECHA_CANCELACION As Date
    Private _CONCEPTO As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
    Private _NOMBRE_USUARIO_GRABO As String
    Private _NOMBRE_USUARIO_SOLICITO As String
    Private _NOMBRE_USUARIO_CANCELO As String
    Private _NOMBRE_USUARIO_COMPRADOR As String
#End Region

#Region "Campos públicos"
    Public oRequisicionDetalle As Class_Requisiciones_Detalle
    Public CANCELA_DIRECTO As Boolean
    Public ID_CON_EJERCICIO_ORIGINAL As String
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

    Public Property FOLIO_REQUISICION() As String
        Get
            Return Me._FOLIO_REQUISICION
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_REQUISICION = Value
        End Set
    End Property

    Public Property FECHA_ENTREGA() As Date
        Get
            Return Me._FECHA_ENTREGA
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_ENTREGA = Value
        End Set
    End Property

    Public Property CODIGO_ALMACEN() As String
        Get
            Return Me._CODIGO_ALMACEN
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_ALMACEN = Value
        End Set
    End Property

    Public Property CODIGO_USUARIO_COMPRADOR() As String
        Get
            Return Me._CODIGO_USUARIO_COMPRADOR
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_USUARIO_COMPRADOR = Value
        End Set
    End Property

    Public Property CODIGO_PLAZA() As Integer
        Get
            Return Me._CODIGO_PLAZA
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_PLAZA = Value
        End Set
    End Property

    Public Property CODIGO_DOCUMENTO() As String
        Get
            Return Me._CODIGO_DOCUMENTO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_DOCUMENTO = Value
        End Set
    End Property

    Public Property ESTATUS() As String
        Get
            Return Me._ESTATUS
        End Get
        Set(ByVal Value As String)
            Me._ESTATUS = Value
        End Set
    End Property

    Public Property CODIGO_USUARIO_GRABO() As Integer
        Get
            Return Me._CODIGO_USUARIO_GRABO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_USUARIO_GRABO = Value
        End Set
    End Property

    Public Property CODIGO_USUARIO_SOLICITO() As Integer
        Get
            Return Me._CODIGO_USUARIO_SOLICITO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_USUARIO_SOLICITO = Value
        End Set
    End Property

    Public Property CODIGO_USUARIO_CANCELO() As Integer
        Get
            Return Me._CODIGO_USUARIO_CANCELO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_USUARIO_CANCELO = Value
        End Set
    End Property

    Public Property FECHA_SOLICITO() As Date
        Get
            Return Me._FECHA_SOLICITO
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_SOLICITO = Value
        End Set
    End Property

    Public Property FECHA_CANCELACION() As Date
        Get
            Return Me._FECHA_CANCELACION
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_CANCELACION = Value
        End Set
    End Property

    Public Property CONCEPTO() As String
        Get
            Return Me._CONCEPTO
        End Get
        Set(ByVal Value As String)
            Me._CONCEPTO = Value
        End Set
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property
    Public ReadOnly Property CODIGO_MODULO() As String
        Get
            Return "INV"
        End Get
    End Property

    Public ReadOnly Property NOMBRE_USUARIO_GRABO() As String
        Get
            Return Me._NOMBRE_USUARIO_GRABO
        End Get
    End Property

    Public ReadOnly Property NOMBRE_USUARIO_SOLICITO() As String
        Get
            Return Me._NOMBRE_USUARIO_SOLICITO
        End Get
    End Property

    Public ReadOnly Property NOMBRE_USUARIO_CANCELO() As String
        Get
            Return Me._NOMBRE_USUARIO_CANCELO
        End Get
    End Property

    Public ReadOnly Property NOMBRE_COMPRADOR() As String
        Get
            Return Me._NOMBRE_USUARIO_COMPRADOR
        End Get
    End Property
#End Region

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

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
        Me._Nombre_Catalogo = "REQUISICIONES_GLOBAL"
        Me._Nombre_Reporte = "RPT_REQUISICIONES_GLOBAL.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT R.*,U.NOMBRE_USUARIO NOMBRE_USUARIO_GRABO,U2.NOMBRE_USUARIO NOMBRE_USUARIO_SOLICITO,U3.NOMBRE_USUARIO NOMBRE_USUARIO_CANCELO,U4.NOMBRE_USUARIO NOMBRE_COMPRADOR " &
                          "FROM REQUISICIONES_GLOBAL R " &
                          "INNER JOIN SIS_USUARIOS U ON(R.CODIGO_USUARIO_GRABO=U.CODIGO_USUARIO) " &
                          "LEFT JOIN SIS_USUARIOS U2 ON(R.CODIGO_USUARIO_SOLICITO=U2.CODIGO_USUARIO) " &
                          "LEFT JOIN SIS_USUARIOS U3 ON(R.CODIGO_USUARIO_CANCELO=U3.CODIGO_USUARIO) " &
                          "LEFT JOIN SIS_USUARIOS U4 ON(R.CODIGO_USUARIO_COMPRADOR=U4.CODIGO_USUARIO) " &
                          "WHERE "
        Me._QueryOrder = " ORDER BY R.FOLIO_REQUISICION"
        oRequisicionDetalle = New Class_Requisiciones_Detalle
    End Sub

    Public Sub New(ByVal sFolioRequisicion As String)
        Me.New()
        Try
            Me.FOLIO_REQUISICION = sFolioRequisicion
            If Me.Consultar = False Then
                Throw New Exception("El folio de requisición de inventario no existe.")
            Else
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
    Public Function Grabar(ByVal sAccion As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_REQUISICIONES_GLOBAL_GRABA"

            sqlParametro = .Parameters.Add("@FOLIO_REQUISICION", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_REQUISICION.ToUpper : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@FECHA_ENTREGA", SqlDbType.SmallDateTime) : sqlParametro.Value = "" & Me._FECHA_ENTREGA
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN", SqlDbType.NVarChar, 4) : sqlParametro.Value = "" & Me._CODIGO_ALMACEN
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_COMPRADOR", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_USUARIO_COMPRADOR
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = "" & Me._CODIGO_DOCUMENTO
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = "" & Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@CONCEPTO", SqlDbType.NVarChar, 160) : sqlParametro.Value = "" & Me._CONCEPTO.ToUpper
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = sAccion ' "ACTUALIZAR", "INSERTAR"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
                Me._FOLIO_REQUISICION = "" & .Parameters("@FOLIO_REQUISICION").Value.ToString
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Grabar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function Solicita() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_REQUISICIONES_SOLICITA"

            sqlParametro = .Parameters.Add("@FOLIO_REQUISICION", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_REQUISICION.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_SOLICITO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@FECHA_SOLICITO", SqlDbType.SmallDateTime) : sqlParametro.Value = Me._FECHA_SOLICITO
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Solicita", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function Anular() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_REQUISICIONES_ANULA_GLOBAL"

            sqlParametro = .Parameters.Add("@FOLIO_REQUISICION", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_REQUISICION.ToUpper

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Anular", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function Cancelar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_REQUISICIONES_CANCELA"

            sqlParametro = .Parameters.Add("@FOLIO_REQUISICION", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_REQUISICION.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_CANCELO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@FECHA_CANCELACION", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_CANCELACION
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Cancelar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " R.FOLIO_REQUISICION ='" & Replace(Me._FOLIO_REQUISICION, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._FOLIO_REQUISICION = "" & dReader("FOLIO_REQUISICION").ToString()
                    Me._FECHA_ENTREGA = CDate(dReader("FECHA_ENTREGA"))
                    Me._CODIGO_ALMACEN = "" & dReader("CODIGO_ALMACEN").ToString()
                    Me._CODIGO_USUARIO_COMPRADOR = "" & dReader("CODIGO_USUARIO_COMPRADOR").ToString()
                    Me._CODIGO_PLAZA = Convert.ToInt32(dReader("CODIGO_PLAZA"))
                    Me._CODIGO_DOCUMENTO = "" & dReader("CODIGO_DOCUMENTO").ToString()
                    Me._ESTATUS = "" & dReader("ESTATUS").ToString()
                    Me._CODIGO_USUARIO_GRABO = CInt(dReader("CODIGO_USUARIO_GRABO"))
                    Me._NOMBRE_USUARIO_GRABO = "" & dReader("NOMBRE_USUARIO_GRABO").ToString()
                    Me._CONCEPTO = "" & dReader("CONCEPTO").ToString()

                    If Me._ESTATUS = "L" Or Me._ESTATUS = "R" Or Me._ESTATUS = "A" Then
                        Me._FECHA_SOLICITO = CDate(dReader("FECHA_SOLICITO"))
                        Me._CODIGO_USUARIO_SOLICITO = CInt(dReader("CODIGO_USUARIO_SOLICITO"))
                        Me._NOMBRE_USUARIO_SOLICITO = "" & dReader("NOMBRE_USUARIO_SOLICITO").ToString()
                    End If

                    If Me._ESTATUS = "C" Then
                        Me._FECHA_CANCELACION = CDate(dReader("FECHA_CANCELACION"))
                        Me._CODIGO_USUARIO_CANCELO = CInt(dReader("CODIGO_USUARIO_CANCELO"))
                        Me._NOMBRE_USUARIO_CANCELO = "" & dReader("NOMBRE_USUARIO_CANCELO").ToString()
                    End If

                    Me._NOMBRE_USUARIO_COMPRADOR = "" & dReader("NOMBRE_COMPRADOR").ToString()

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

    Public Function ObtenerDetalle() As DataTable
        Dim dTabla As New DataTable("detalle")
        Dim sSQL As String

        Try
            sSQL = "SELECT R.CODIGO_ARTICULO,A.DESCRIPCION,R.CANTIDAD,A.UNIDAD_VENTA,R.DISPONIBLE,R.CANTIDAD_ANULADA FROM REQUISICIONES_DETALLE R " &
                   "INNER JOIN CAT_ARTICULOS A ON(R.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
                   "WHERE R.FOLIO_REQUISICION='" & Me._FOLIO_REQUISICION & "' ORDER BY R.ID_REQUISICION_DETALLE "

            Using da As New SqlDataAdapter(sSQL, Me._Conexion)

                da.SelectCommand.CommandType = CommandType.Text

                With da.SelectCommand
                    .Parameters.Add("@FOLIO_REQUISICION", SqlDbType.NVarChar, 15).Value = Me._FOLIO_REQUISICION
                End With

                da.Fill(dTabla)
            End Using

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalle", ex)
        End Try

        Return dTabla
    End Function

    Public Function ObtenerDetalleParaOrdenCompra() As DataTable
        Dim dTabla As New DataTable("detalle")
        Dim sSQL As String

        Try
            sSQL = "SELECT D.CODIGO_ARTICULO,A.DESCRIPCION,D.DISPONIBLE,A.UNIDAD_VENTA,A.IMPUESTO_PORCENTAJE,A.IEPS_PORCENTAJE,D.ID_REQUISICION_DETALLE " &
                   "FROM REQUISICIONES_GLOBAL G " &
                   "INNER JOIN REQUISICIONES_DETALLE D ON(G.FOLIO_REQUISICION=D.FOLIO_REQUISICION) " &
                   "INNER JOIN VW_CAT_ARTICULOS_EXTENDIDO A ON(D.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
                   "WHERE G.FOLIO_REQUISICION='" & Me._FOLIO_REQUISICION & "' ORDER BY D.ID_REQUISICION_DETALLE "

            Using da As New SqlDataAdapter(sSQL, Me._Conexion)

                da.SelectCommand.CommandType = CommandType.Text

                With da.SelectCommand
                    .Parameters.Add("@FOLIO_REQUISICION", SqlDbType.NVarChar, 15).Value = Me._FOLIO_REQUISICION
                End With

                da.Fill(dTabla)
            End Using

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalleParaOrdenCompra", ex)
        End Try

        Return dTabla
    End Function

    'Public Function CantidadDisponible(ByVal sCodigoArticulo As String, ByVal sFolioRequisicion As String) As Decimal

    Public Function CantidadDisponible(ByVal sCodigoArticulo As String, ByVal sCodigoAlmacen As String) As Decimal
        Dim dResultado As Decimal = 0
        Try
            Dim sql As New Class_find("SELECT ISNULL(SUM(D.DISPONIBLE),0) " &
                                      "FROM REQUISICIONES_GLOBAL G " &
                                      "INNER JOIN REQUISICIONES_DETALLE D ON(G.FOLIO_REQUISICION=D.FOLIO_REQUISICION) " &
                                      "WHERE D.CODIGO_ARTICULO='" & sCodigoArticulo & "' AND G.ESTATUS IN('L','R') AND G.CODIGO_ALMACEN='" & sCodigoAlmacen & "' ")
            '                         "WHERE D.CODIGO_ARTICULO='" & sCodigoArticulo & "' AND G.FOLIO_REQUISICION='" & sFolioRequisicion & "' ")

            dResultado = valorNumericoD(sql.Result1)
            sql = Nothing
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "CantidadDisponible", ex)
        End Try

        Return dResultado
    End Function

    Public Function ObtieneArticulosRequeridos(ByVal sCodigoAlmacen As String) As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String = ("SELECT MAX(D.CODIGO_ARTICULO) CODIGO_ARTICULO,MAX(A.DESCRIPCION) DESCRIPCION,ISNULL(SUM(D.DISPONIBLE),0) DISPONIBLE,0 CANTIDAD,MAX(A.UNIDAD_VENTA) UNIDAD,0 SELECCION " &
                              "FROM REQUISICIONES_GLOBAL G " &
                              "INNER JOIN REQUISICIONES_DETALLE D ON(G.FOLIO_REQUISICION=D.FOLIO_REQUISICION) INNER JOIN CAT_ARTICULOS A ON(D.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
                              "WHERE G.ESTATUS IN('L','R') AND G.CODIGO_ALMACEN='" & sReplace(sCodigoAlmacen) & "' GROUP BY D.CODIGO_ARTICULO ORDER BY MAX(A.DESCRIPCION) ")
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtieneArticulosRequeridos", ex)
            End Try
        Return dTabla
    End Function

    Public Function ObtieneArticulosMultiplesRequisiciones(ByVal sArticulos As String) As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String = ("EXEC MP_COMPRAS_OBTIENE_DETALLE_MULTIPLES_REQUISICIONES_PARA_AGREGAR_ORDEN_COMPRA @ARTICULOS_REQUERIDOS='" & sArticulos & "'")
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtieneArticulosMultiplesRequisiciones", ex)
        End Try
        Return dTabla
    End Function

    Public Function BusquedaVisual_Requisiciones() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de requisiciones pendientes de OC por folio."
        f.sCampo = "FOLIO_REQUISICION"
        f.sOrder = "FECHA_ENTREGA DESC"
        f.sTable = "REQUISICIONES_GLOBAL"
        f.sQl = "SELECT G.FOLIO_REQUISICION,A.NOMBRE_ALMACEN,G.ESTATUS,G.FECHA_ENTREGA,G.FECHA_SERVIDOR,UC.NOMBRE_USUARIO COMPRADOR " &
                "FROM REQUISICIONES_GLOBAL G " &
                "INNER JOIN CAT_ALMACENES A ON(G.CODIGO_ALMACEN=A.CODIGO_ALMACEN) " &
                "LEFT JOIN SIS_USUARIOS UC ON(G.CODIGO_USUARIO_COMPRADOR=UC.CODIGO_USUARIO) " &
                "WHERE G.ESTATUS IN('L','R') AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_Requisiciones", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_RequisicionesPorAlmacen(ByVal sCodigoAlmacen As String) As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de requisiciones pendientes de OC por folio."
        f.sCampo = "FOLIO_REQUISICION"
        f.sOrder = "FECHA_ENTREGA DESC"
        f.sTable = "REQUISICIONES_GLOBAL"
        f.sQl = "SELECT G.FOLIO_REQUISICION,A.NOMBRE_ALMACEN,G.ESTATUS,G.FECHA_ENTREGA,G.FECHA_SERVIDOR,UC.NOMBRE_USUARIO COMPRADOR " &
                "FROM REQUISICIONES_GLOBAL G " &
                "INNER JOIN CAT_ALMACENES A ON(G.CODIGO_ALMACEN=A.CODIGO_ALMACEN) " &
                "LEFT JOIN SIS_USUARIOS UC ON(G.CODIGO_USUARIO_COMPRADOR=UC.CODIGO_USUARIO) " &
                "WHERE G.ESTATUS IN('L','R') AND G.CODIGO_ALMACEN='" & sCodigoAlmacen & "' AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_Requisiciones", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de requisiciones de inventario."
        f.sCampo = "FOLIO_REQUISICION"
        f.sOrder = "FOLIO_REQUISICION"
        f.sTable = "REQUISICIONES_GLOBAL"
        f.sQl = "SELECT G.FOLIO_REQUISICION,A.NOMBRE_ALMACEN,G.ESTATUS,G.FECHA " &
                "FROM REQUISICIONES_GLOBAL G " &
                "INNER JOIN CAT_ALMACENES A ON(G.CODIGO_ALMACEN=A.CODIGO_ALMACEN) " &
                "WHERE "
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

    Public Function GeneraFolio() As String
        Dim sResultado As String = ""
        Dim Conexion As New SqlConnection(Empresa_Sistema.conexion)
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter

        With cmd
            .Connection = Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_UTILERIAS_GENERA_FOLIO_DOCUMENTO"

            sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_DOCUMENTO
            sqlParametro = .Parameters.Add("@VFOLIO", SqlDbType.NVarChar, 15) : sqlParametro.Direction = ParameterDirection.Output

            Try
                Conexion.Open()
                .ExecuteNonQuery()

                sResultado = "" & .Parameters("@VFOLIO").Value.ToString

            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "GeneraFolio", ex)
            Finally
                Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return sResultado
    End Function

    Public Sub NuevoRenglon()
        Me.oRequisicionDetalle = New Class_Requisiciones_Detalle
    End Sub

#End Region

End Class


