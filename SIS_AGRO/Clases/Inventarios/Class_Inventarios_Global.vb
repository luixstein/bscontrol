Option Strict On
Imports System.Data.SqlClient

Public Class Class_Inventarios_Global

#Region "Campos"

#Region "Campos de la tabla"
    Private _FOLIO_MOVIMIENTO_INVENTARIO As String
    Private _CODIGO_TIPO_DOCUMENTO As String
    Private _FOLIO_REFERENCIA As String
    Private _CODIGO_ALMACEN1 As String
    Private _CODIGO_ALMACEN2 As String
    Private _FECHA As Date
    Private _CONCEPTO As String
    Private _CODIGO_USUARIO As Integer
    Private _CODIGO_PLAZA As Integer
    Private _TOTAL As Decimal
    Private _NATURALEZA_INVENTARIOS As String
    Private _FOLIO_POLIZA As String
    Private _FECHA_CANCELACION As Date
    Private _CODIGO_USUARIO_CANCELACION As Integer
    Private _NOMBRE_USUARIO As String
    Private _NOMBRE_USUARIO_CANCELO As String
    Private _ESTA_CANCELADO As String
    Private _ESTATUS As String
    Private _FOLIO_EMBARQUE As String
    Private _CODIGO_CONCEPTO_INVENTARIOS As Integer
    Private _COSTO_TOTAL_BASE As Decimal = 0
    Private _FLETE_TOTAL As Decimal = 0
    Private _ESTATUS_MOVIMIENTO As String
    Private _CODIGO_ALMACEN_ENTRADA_FINANCIERA As String
    Private _FOLIO_ENTRADA_FINANCIERA As String
    Private _FOLIO_ORDEN_PRODUCCION As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
#End Region

#Region "Campos públicos"
    Public oInventariosDetalle As Class_Inventarios_Detalle
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

    Public Property FOLIO_MOVIMIENTO_INVENTARIO() As String
        Get
            Return Me._FOLIO_MOVIMIENTO_INVENTARIO
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_MOVIMIENTO_INVENTARIO = Value
        End Set
    End Property

    Public Property CODIGO_TIPO_DOCUMENTO() As String
        Get
            Return Me._CODIGO_TIPO_DOCUMENTO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_TIPO_DOCUMENTO = Value
        End Set
    End Property

    Public Property FOLIO_REFERENCIA() As String
        Get
            Return Me._FOLIO_REFERENCIA
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_REFERENCIA = Value
        End Set
    End Property

    Public Property CODIGO_ALMACEN1() As String
        Get
            Return Me._CODIGO_ALMACEN1
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_ALMACEN1 = Value
        End Set
    End Property

    Public Property CODIGO_ALMACEN2() As String
        Get
            Return Me._CODIGO_ALMACEN2
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_ALMACEN2 = Value
        End Set
    End Property

    Public Property FECHA() As Date
        Get
            Return Me._FECHA
        End Get
        Set(ByVal Value As Date)
            Me._FECHA = Value
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

    Public Property CODIGO_USUARIO() As Integer
        Get
            Return Me._CODIGO_USUARIO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_USUARIO = Value
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

    Public Property TOTAL() As Decimal
        Get
            Return Me._TOTAL
        End Get
        Set(ByVal Value As Decimal)
            Me._TOTAL = Value
        End Set
    End Property

    Public Property NATURALEZA_INVENTARIOS() As String
        Get
            Return Me._NATURALEZA_INVENTARIOS
        End Get
        Set(ByVal Value As String)
            Me._NATURALEZA_INVENTARIOS = Value
        End Set
    End Property

    Public Property FOLIO_POLIZA() As String
        Get
            Return Me._FOLIO_POLIZA
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_POLIZA = Value
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

    Public Property CODIGO_USUARIO_CANCELACION() As Integer
        Get
            Return Me._CODIGO_USUARIO_CANCELACION
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_USUARIO_CANCELACION = Value
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

    Public ReadOnly Property NOMBRE_USUARIO() As String
        Get
            Return Me._NOMBRE_USUARIO
        End Get
    End Property

    Public ReadOnly Property NOMBRE_USUARIO_CANCELO() As String
        Get
            Return Me._NOMBRE_USUARIO_CANCELO
        End Get
    End Property

    Public ReadOnly Property ESTA_CANCELADO() As String
        Get
            Return Me._ESTA_CANCELADO
        End Get
    End Property

    Public Property FOLIO_EMBARQUE() As String
        Get
            Return Me._FOLIO_EMBARQUE
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_EMBARQUE = Value
        End Set
    End Property

    Public Property CODIGO_CONCEPTO_INVENTARIOS() As Integer
        Get
            Return Me._CODIGO_CONCEPTO_INVENTARIOS
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_CONCEPTO_INVENTARIOS = Value
        End Set
    End Property

    Public Property COSTO_TOTAL_BASE() As Decimal
        Get
            Return Me._COSTO_TOTAL_BASE
        End Get
        Set(ByVal Value As Decimal)
            Me._COSTO_TOTAL_BASE = Value
        End Set
    End Property

    Public Property FLETE_TOTAL() As Decimal
        Get
            Return Me._FLETE_TOTAL
        End Get
        Set(ByVal Value As Decimal)
            Me._FLETE_TOTAL = Value
        End Set
    End Property

    Public Property ESTATUS_MOVIMIENTO() As String
        Get
            Return Me._ESTATUS_MOVIMIENTO
        End Get
        Set(value As String)
            Me._ESTATUS_MOVIMIENTO = value
        End Set
    End Property

    Public Property CODIGO_ALMACEN_ENTRADA_FINANCIERA() As String
        Get
            Return Me._CODIGO_ALMACEN_ENTRADA_FINANCIERA
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_ALMACEN_ENTRADA_FINANCIERA = Value
        End Set
    End Property

    Public Property FOLIO_ENTRADA_FINANCIERA() As String
        Get
            Return Me._FOLIO_ENTRADA_FINANCIERA
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_ENTRADA_FINANCIERA = Value
        End Set
    End Property

    Public Property FOLIO_ORDEN_PRODUCCION() As String
        Get
            Return Me._FOLIO_ORDEN_PRODUCCION
        End Get
        Set(Value As String)
            Me._FOLIO_ORDEN_PRODUCCION = Value
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
        Me._Nombre_Catalogo = "INVENTARIO_MOVIMIENTOS_GLOBAL"
        Me._Nombre_Reporte = "RPT_INVENTARIO_MOVIMIENTOS_GLOBAL.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select I.*,D.NATURALEZA_INVENTARIOS,U.NOMBRE_USUARIO,U2.NOMBRE_USUARIO NOMBRE_USUARIO_CANCELO FROM INVENTARIO_MOVIMIENTOS_GLOBAL I INNER JOIN SIS_TIPOS_DOCUMENTOS D ON (D.CODIGO_TIPO_DOCUMENTO=I.CODIGO_TIPO_DOCUMENTO) INNER JOIN SIS_USUARIOS U ON (U.CODIGO_USUARIO=I.CODIGO_USUARIO_GRABO) LEFT JOIN SIS_USUARIOS U2 ON (U2.CODIGO_USUARIO=I.CODIGO_USUARIO_CANCELO) WHERE "
        Me._QueryOrder = " Order by I.FOLIO_MOVIMIENTO_INVENTARIO"
        oInventariosDetalle = New Class_Inventarios_Detalle
    End Sub

    Public Sub New(ByVal sfolioMovimientoInventario As String)
        Me.New()
        Try
            Me.FOLIO_MOVIMIENTO_INVENTARIO = sfolioMovimientoInventario
            If Me.Consultar = False Then
                Throw New Exception("El folio de movimiento de inventarios no existe.")
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
            .CommandText = "MP_INVENTARIOS_MOVIMIENTOS_GRABA_GLOBAL"

            sqlParametro = .Parameters.Add("@FOLIO_MOVIMIENTO_INVENTARIO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_MOVIMIENTO_INVENTARIO.ToUpper : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = "" & Me._CODIGO_TIPO_DOCUMENTO.ToUpper
            sqlParametro = .Parameters.Add("@FOLIO_REFERENCIA", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_REFERENCIA.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN1", SqlDbType.NVarChar, 4) : sqlParametro.Value = "" & Me._CODIGO_ALMACEN1
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN2", SqlDbType.NVarChar, 4) : sqlParametro.Value = "" & Me._CODIGO_ALMACEN2
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.SmallDateTime) : sqlParametro.Value = "" & Me._FECHA
            sqlParametro = .Parameters.Add("@CONCEPTO", SqlDbType.NVarChar, 160) : sqlParametro.Value = "" & Me._CONCEPTO.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = "" & Me._CODIGO_USUARIO
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@TOTAL", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = sAccion ' "ACTUALIZAR", "INSERTAR"
            sqlParametro = .Parameters.Add("@FOLIO_EMBARQUE", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_EMBARQUE.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_CONCEPTO_INVENTARIOS", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CONCEPTO_INVENTARIOS
            sqlParametro = .Parameters.Add("@COSTO_TOTAL_BASE", SqlDbType.Decimal) : sqlParametro.Value = Me._COSTO_TOTAL_BASE
            sqlParametro = .Parameters.Add("@FLETE_TOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._FLETE_TOTAL
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN_ENTRADA_FINANCIERA", SqlDbType.NVarChar, 4) : sqlParametro.Value = "" & Me._CODIGO_ALMACEN_ENTRADA_FINANCIERA
            sqlParametro = .Parameters.Add("@FOLIO_ORDEN_PRODUCCION", SqlDbType.NVarChar, 30) : sqlParametro.Value = "" & Me.FOLIO_ORDEN_PRODUCCION

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
                Me._FOLIO_MOVIMIENTO_INVENTARIO = "" & .Parameters("@FOLIO_MOVIMIENTO_INVENTARIO").Value.ToString
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

    Public Function Aplicar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_INVENTARIOS_MOVIMIENTOS_APLICA"

            sqlParametro = .Parameters.Add("@FOLIO_MOVIMIENTO_INVENTARIO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_MOVIMIENTO_INVENTARIO.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_USUARIO
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Aplicar", ex)
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
            .CommandText = "MP_INVENTARIOS_MOVIMIENTOS_CANCELA"

            sqlParametro = .Parameters.Add("@FOLIO_MOVIMIENTO_INVENTARIO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_MOVIMIENTO_INVENTARIO.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_CANCELO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@FECHA_CANCELACION", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_CANCELACION
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
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
        Dim cmd As New SqlCommand(Me._QuerySelect & " I.FOLIO_MOVIMIENTO_INVENTARIO='" & Replace(Me._FOLIO_MOVIMIENTO_INVENTARIO, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._FOLIO_MOVIMIENTO_INVENTARIO = "" & dReader("FOLIO_MOVIMIENTO_INVENTARIO").ToString()
                    Me._CODIGO_TIPO_DOCUMENTO = "" & dReader("CODIGO_TIPO_DOCUMENTO").ToString()
                    Me._FOLIO_REFERENCIA = "" & dReader("FOLIO_REFERENCIA").ToString()
                    Me._ESTATUS = Trim("" & dReader("Estatus").ToString())
                    Me._CODIGO_ALMACEN1 = "" & dReader("CODIGO_ALMACEN1").ToString()
                    Me._CODIGO_ALMACEN2 = "" & dReader("CODIGO_ALMACEN2").ToString()
                    Me._CONCEPTO = "" & dReader("CONCEPTO").ToString()
                    Me._CODIGO_PLAZA = Convert.ToInt32(dReader("CODIGO_PLAZA"))
                    Me._TOTAL = CDec(dReader("COSTO_TOTAL"))
                    Me._NATURALEZA_INVENTARIOS = "" & dReader("NATURALEZA_INVENTARIOS").ToString()
                    Me._FOLIO_POLIZA = "" & dReader("FOLIO_POLIZA").ToString()
                    Me._FECHA = CDate(dReader("FECHA"))
                    Me._CODIGO_USUARIO = CInt(dReader("CODIGO_USUARIO_GRABO"))
                    Me._NOMBRE_USUARIO = "" & dReader("NOMBRE_USUARIO").ToString()
                    Me._ESTA_CANCELADO = "" & dReader("ESTA_CANCELADO").ToString()

                    If Me._ESTA_CANCELADO = "1" Then
                        Me._ESTATUS = "C"
                    Else
                        Me._ESTATUS = "" & dReader("ESTATUS").ToString()
                    End If

                    If Me._ESTATUS = "C" Then
                        Me._FECHA_CANCELACION = CDate(dReader("FECHA_CANCELACION"))
                        Me._CODIGO_USUARIO_CANCELACION = CInt(dReader("CODIGO_USUARIO_CANCELO"))
                        Me._NOMBRE_USUARIO_CANCELO = "" & dReader("NOMBRE_USUARIO_CANCELO").ToString()
                    End If

                    Me._FOLIO_EMBARQUE = "" & dReader("FOLIO_EMBARQUE").ToString()
                    Me._CODIGO_CONCEPTO_INVENTARIOS = CInt(dReader("CODIGO_CONCEPTO_INVENTARIOS"))

                    Me._COSTO_TOTAL_BASE = CDec(dReader("COSTO_TOTAL_BASE"))
                    Me._FLETE_TOTAL = CDec(dReader("FLETE_TOTAL"))
                    Me._ESTATUS_MOVIMIENTO = "" & dReader("ESTATUS_MOVIMIENTO").ToString
                    Me._CODIGO_ALMACEN_ENTRADA_FINANCIERA = "" & dReader("CODIGO_ALMACEN_ENTRADA_FINANCIERA").ToString()
                    Me._FOLIO_ENTRADA_FINANCIERA = "" & dReader("FOLIO_ENTRADA_FINANCIERA").ToString()
                    Me._FOLIO_ORDEN_PRODUCCION = "" & dReader("FOLIO_ORDEN_PRODUCCION").ToString

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
            'sSQL = "SELECT I.CODIGO_ARTICULO,A.DESCRIPCION,I.CANTIDAD,I.COSTO_DETALLE,I.IMPORTE,I.CUENTA_CONTABLE,C.NOMBRE_CUENTA,'' Boton,I.ID_ADICIONAL  " & _
            '        "FROM INVENTARIO_MOVIMIENTOS_DETALLE I " & _
            '        "INNER JOIN CAT_ARTICULOS A ON (A.CODIGO_ARTICULO=I.CODIGO_ARTICULO) " & _
            '        "LEFT JOIN CON_CAT_CUENTAS C ON(I.CUENTA_CONTABLE=C.CUENTA_CONTABLE) " & _
            '        "WHERE I.FOLIO_MOVIMIENTO_INVENTARIO='" & Me._FOLIO_MOVIMIENTO_INVENTARIO & "' ORDER BY I.ID_INVENTARIO_MOVIMIENTOS_DETALLE--A.DESCRIPCION"

            'Las primeras 3 líneas construyen una tabla que nos trae al menos una cuenta del detalle para poder indicar que si tiene detalle, hace así y no en el mismo select principal porque se tendria que andar agrupando y haciendo varios max
            sSQL = "With DC(ID_ADICIONAL, CUENTA_CONTABLE) " &
                    "AS " &
                    "(SELECT ID_ADICIONAL,MAX(CUENTA_CONTABLE) FROM CENTRO_COSTOS_MOVIMIENTOS_DETALLE WHERE FOLIO_MOVIMIENTO=@FOLIO_MOVIMIENTO_INVENTARIO GROUP BY FOLIO_MOVIMIENTO,ID_ADICIONAL) " &
                    "SELECT I.CODIGO_ARTICULO,A.DESCRIPCION,I.CANTIDAD,I.COSTO_DETALLE,I.IMPORTE,I.CUENTA_CONTABLE,CASE WHEN DC.CUENTA_CONTABLE IS NOT NULL THEN 'Tiene detalle -->>' ELSE C.NOMBRE_CUENTA END NOMBRE_CUENTA, " &
                    "'' Boton,I.ID_ADICIONAL, " &
                    "I.FLETE_DETALLE_IMPORTE,I.COSTO_DETALLE_BASE,I.IMPORTE_BASE,I.ID_COMPRA_DETALLE,I.DISPONIBLE,I.ID_INVENTARIO_LOTES_COSTOS " &
                    "FROM INVENTARIO_MOVIMIENTOS_DETALLE I  " &
                    "INNER JOIN CAT_ARTICULOS A ON(A.CODIGO_ARTICULO=I.CODIGO_ARTICULO)  " &
                    "LEFT JOIN CON_CAT_CUENTAS C ON(I.CUENTA_CONTABLE=C.CUENTA_CONTABLE) " &
                    "LEFT JOIN DC ON(I.ID_ADICIONAL=DC.ID_ADICIONAL) " &
                    "WHERE I.FOLIO_MOVIMIENTO_INVENTARIO=@FOLIO_MOVIMIENTO_INVENTARIO " &
                    "ORDER BY I.ID_INVENTARIO_MOVIMIENTOS_DETALLE"

            Using da As New SqlDataAdapter(sSQL, Me._Conexion)

                da.SelectCommand.CommandType = CommandType.Text

                With da.SelectCommand
                    .Parameters.Add("@FOLIO_MOVIMIENTO_INVENTARIO", SqlDbType.NVarChar, 15).Value = Me._FOLIO_MOVIMIENTO_INVENTARIO
                End With

                da.Fill(dTabla)
            End Using

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalle", ex)
        End Try

        Return dTabla
    End Function

    ''' <summary>
    ''' Obtiene a todos los elementos del catálogo.
    ''' </summary>
    Public Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCatArticulos As New SqlDataAdapter("SELECT CODIGO_ARTICULO, DESCRIPCION FROM CAT_Articulos ORDER BY DESCRIPCION", Me._Conexion)
        Try
            dsCatArticulos.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCatArticulos.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerFamilias() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCatArticulos As New SqlDataAdapter("SELECT ID_CAT_FAMILIAS, NOMBRE_FAMILIA FROM CAT_FAMILIAS ORDER BY NOMBRE_FAMILIA", Me._Conexion)
        Try
            dsCatArticulos.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerFamilias", ex)
        Finally
            dsCatArticulos.Dispose()
        End Try
        Return dTable
    End Function

    Public Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Articulos por Código."
        f.sCampo = "CODIGO_ARTICULO"
        f.sOrder = "Descripcion"
        f.sTable = "Cat_Articulos"
        f.sQl = "Select CODIGO_ARTICULO,Descripcion From Cat_Articulos Where 1=1 And Protegido=0 AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorCodigo", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Articulos por Descripción."
        f.sCampo = "Descripcion"
        f.sOrder = "Descripcion"
        f.sTable = "Cat_Articulos"
        f.sQl = "Select CODIGO_ARTICULO,Descripcion From Cat_Articulos Where 1=1 And Protegido=0 AND "
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

    Public Function GeneraFolioInventarios() As String
        Dim sResultado As String = ""
        Dim Conexion As New SqlConnection(Empresa_Sistema.conexion)
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter

        With cmd
            .Connection = Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_UTILERIAS_GENERA_FOLIO_ALMACEN"

            sqlParametro = .Parameters.Add("@CODIGO_TIPO_DOCUMENTO", SqlDbType.NVarChar, 5) : sqlParametro.Value = Me._CODIGO_TIPO_DOCUMENTO
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_ALMACEN1
            sqlParametro = .Parameters.Add("@FOLIO_INVENTARIO", SqlDbType.NVarChar, 15) : sqlParametro.Direction = ParameterDirection.Output

            Try
                Conexion.Open()
                .ExecuteNonQuery()

                sResultado = "" & .Parameters("@FOLIO_INVENTARIO").Value.ToString

            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "GeneraFolioInventarios", ex)
            Finally
                Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return sResultado
    End Function

    Public Function BusquedaVisualInventariables_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Articulos por Descripción."
        f.sCampo = "Descripcion"
        f.sOrder = "Descripcion"
        f.sTable = "Cat_Articulos"
        f.sQl = "Select CODIGO_ARTICULO,Descripcion From Cat_Articulos Where 1=1 And Protegido=0 AND INVENTARIABLE='1' AND"
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisualInventariables_PorDescripcion", ex)
        End Try
        Return Resultado
    End Function

    Public Function BuscarNombreArticulo(ByVal sCodigoArticulo As String) As String
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("Select Descripcion From CAT_ARTICULOS Where CODIGO_Articulo='" & sCodigoArticulo & "' ")
            If sql.Result1 <> "" Then
                Resultado = sql.Result1
            End If
            sql = Nothing
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BuscarNombreArticulo", ex)
        End Try
        Return Resultado
    End Function

    Public Function NaturalezaInventarios(ByVal sCodigoDocumento As String) As String
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("SELECT NATURALEZA_INVENTARIOS FROM SIS_TIPOS_DOCUMENTOS WHERE CODIGO_TIPO_DOCUMENTO='" & sCodigoDocumento & "' ")
            If sql.Result1 <> "" Then
                Resultado = sql.Result1
            End If
            sql = Nothing
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "NaturalezaInventarios", ex)
        End Try
        Return Resultado
    End Function

    Public Function Existencia(ByVal sCodigoArticulo As String, ByVal sCodigoAlmacen As String) As Double
        Dim Resultado As Double = 0
        Try
            Dim sql As New Class_find("Select Existencia From INVENTARIO_EXISTENCIA_ARTICULOS Where CODIGO_Articulo='" & sCodigoArticulo & "' AND CODIGO_ALMACEN='" & sCodigoAlmacen & "' ")
            If sql.Result1 <> "" Then
                Resultado = CDbl(sql.Result1)
            End If
            sql = Nothing
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "Existencia", ex)
        End Try
        Return Resultado
    End Function

    Public Function AplicarPoliza() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_ASIENTO_REPETITIVO_INVENTARIO"

            sqlParametro = .Parameters.Add("@FOLIO_MOVIMIENTO_INVENTARIO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_MOVIMIENTO_INVENTARIO.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = "" & Me._CODIGO_USUARIO
            sqlParametro = .Parameters.Add("@REPROCESAR_POLIZA", SqlDbType.Char, 1) : sqlParametro.Value = "0"
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "AplicarPoliza", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Sub NuevoRenglon()
        Me.oInventariosDetalle = New Class_Inventarios_Detalle
    End Sub

    Public Function ExistenciaLoteSerie(ByVal sIdInventarioLotesCostos As String) As Double
        Dim Resultado As Double = 0
        Try
            Dim sql As New Class_find("SELECT CANTIDAD_DISPONIBLE FROM VW_INVENTARIO_LOTES_COSTOS_EXTENDIDO WHERE ID_INVENTARIO_LOTES_COSTOS=" & sIdInventarioLotesCostos)
            If sql.Result1 <> "" Then
                Resultado = CDbl(sql.Result1)
            End If
            sql = Nothing
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ExistenciaLoteSerie", ex)
        End Try
        Return Resultado
    End Function

    Public Function ObtenerDetalleSeries(ByVal sFolio As String) As DataTable
        Dim dTabla As New DataTable, da As SqlDataAdapter
        Try

            da = New SqlDataAdapter("EXEC MP_INVENTARIOS_CONSULTA_TABLA_SERIES @FOLIO_MOVIMIENTO_INVENTARIO='" & sFolio & "'", Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalleSeries", ex)
        End Try
        Return dTabla
    End Function

    Public Function ObtenerDetalleDisponiblesEntradasPorOrdenCompra(ByVal sListadoFoliosEntradas As String) As DataTable
        Dim dTabla As New DataTable
        Try
            Using da As New SqlDataAdapter("MP_INVENTARIOS_OBTIENE_DETALLE_DISPONIBLES_ENTRADAS_POR_ORDEN_COMPRA", Me._Conexion)

                da.SelectCommand.CommandType = CommandType.StoredProcedure

                With da.SelectCommand
                    .Parameters.Add("@LISTA_FOLIOS_ENTRADAS_INVENTARIOS", SqlDbType.NVarChar, -1).Value = sListadoFoliosEntradas
                End With

                da.Fill(dTabla)
            End Using
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalleDisponiblesEntradasPorOrdenCompra", ex)
        End Try

        Return dTabla
    End Function

    Public Function ValidaExistencias() As Boolean
        Dim bResultado As Boolean = False
        Dim dTabla As DataTable
        Dim sSQL As String, da As SqlDataAdapter
        Try
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Primero evaluamos los artículos que no son seriados.
            sSQL = "SELECT I.CODIGO_ARTICULO,MAX(A.DESCRIPCION) DESCRIPCION,SUM(I.CANTIDAD) CANTIDAD,MAX(ALM.NOMBRE_ALMACEN) NOMBRE_ALMACEN " &
                "FROM INVENTARIO_MOVIMIENTOS_DETALLE I " &
                "INNER JOIN INVENTARIO_MOVIMIENTOS_GLOBAL G ON(I.FOLIO_MOVIMIENTO_INVENTARIO=G.FOLIO_MOVIMIENTO_INVENTARIO) " &
                "INNER JOIN INVENTARIO_LOTES_COSTOS L ON(I.ID_INVENTARIO_MOVIMIENTOS_DETALLE=L.ID_INVENTARIO_MOVIMIENTOS_DETALLE) " &
                "INNER JOIN CAT_ARTICULOS A ON(I.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
                "LEFT JOIN INVENTARIO_EXISTENCIA_ARTICULOS E ON(I.CODIGO_ARTICULO=E.CODIGO_ARTICULO AND G.CODIGO_ALMACEN1=E.CODIGO_ALMACEN) " &
                "INNER JOIN CAT_ALMACENES ALM ON(G.CODIGO_ALMACEN1=ALM.CODIGO_ALMACEN) " &
                "WHERE I.FOLIO_MOVIMIENTO_INVENTARIO='" & Me._FOLIO_MOVIMIENTO_INVENTARIO & "' AND LEN(L.NUMERO_SERIE)=0 " &
                "GROUP BY I.CODIGO_ARTICULO " &
                "HAVING SUM(I.CANTIDAD)>ISNULL(MAX(E.EXISTENCIA),0) "

            dTabla = New DataTable("detalle")
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

            For Each dRow As DataRow In dTabla.Rows
                MsgBox("No hay existencia suficiente del artículo " & dRow("DESCRIPCION").ToString & " en el almacén " & dRow("NOMBRE_ALMACEN").ToString & ".", MsgBoxStyle.Exclamation, Me.Nombre_Catalogo)
                Return False
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Luego los que si son seriados.
            sSQL = "SELECT I.CODIGO_ARTICULO,A.DESCRIPCION,I.CANTIDAD,C.NUMERO_SERIE " &
                "FROM INVENTARIO_MOVIMIENTOS_DETALLE I " &
                "INNER JOIN INVENTARIO_LOTES_COSTOS C ON(I.ID_INVENTARIO_MOVIMIENTOS_DETALLE=C.ID_INVENTARIO_MOVIMIENTOS_DETALLE) " &
                "INNER JOIN CAT_ARTICULOS A ON(I.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
                "WHERE I.FOLIO_MOVIMIENTO_INVENTARIO='" & Me._FOLIO_MOVIMIENTO_INVENTARIO & "' AND LEN(C.NUMERO_SERIE)>0 AND C.CANTIDAD_ORIGINAL>C.CANTIDAD_DISPONIBLE"

            dTabla = New DataTable("detalle")
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

            For Each dRow As DataRow In dTabla.Rows
                MsgBox("No hay existencia suficiente del artículo " & dRow("DESCRIPCION").ToString & " con el número de serie " & dRow("NUMERO_SERIE").ToString & ".", MsgBoxStyle.Exclamation, Me.Nombre_Catalogo)
                Return False
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Esta validación es simple protección para evitar que catexis quede negativo, digamos que un seriado tiene disp en costos, pero no en caexis
            'Esta validación es la validación base que ya existia para validar agrupando por artículos por si repiten renglones en el movimiento, se suman y se validan vs catexis

            sSQL = "SELECT I.CODIGO_ARTICULO,MAX(A.DESCRIPCION) DESCRIPCION,SUM(I.CANTIDAD) CANTIDAD,ISNULL(MAX(E.EXISTENCIA),0)EXISTENCIA,MAX(ALM.NOMBRE_ALMACEN) NOMBRE_ALMACEN " &
            "FROM INVENTARIO_MOVIMIENTOS_DETALLE I " &
            "INNER JOIN INVENTARIO_MOVIMIENTOS_GLOBAL G ON(I.FOLIO_MOVIMIENTO_INVENTARIO=G.FOLIO_MOVIMIENTO_INVENTARIO) " &
            "INNER JOIN CAT_ARTICULOS A ON(I.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
            "LEFT JOIN INVENTARIO_EXISTENCIA_ARTICULOS E ON(I.CODIGO_ARTICULO=E.CODIGO_ARTICULO AND G.CODIGO_ALMACEN1=E.CODIGO_ALMACEN) " &
            "INNER JOIN CAT_ALMACENES ALM ON(G.CODIGO_ALMACEN1=ALM.CODIGO_ALMACEN) " &
            "WHERE I.FOLIO_MOVIMIENTO_INVENTARIO='" & Me._FOLIO_MOVIMIENTO_INVENTARIO & "'" &
            "GROUP BY I.CODIGO_ARTICULO " &
            "HAVING SUM(I.CANTIDAD)>ISNULL(MAX(E.EXISTENCIA),0) "

            dTabla = New DataTable("detalle")
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

            For Each dRow As DataRow In dTabla.Rows
                MsgBox("No hay existencia suficiente del artículo " & dRow("DESCRIPCION").ToString & " en el almacén " & dRow("NOMBRE_ALMACEN").ToString & ".", MsgBoxStyle.Exclamation, Me.Nombre_Catalogo)
                Return False
            Next

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ValidaExistencias", ex)
        End Try

        Return bResultado
    End Function

    Public Structure tBusquedaLotes
        Dim CodigoArticulo As String
        Dim Costo As Decimal
        Dim ID_INVENTARIO_LOTES_COSTOS As String
    End Structure

    Public Function BusquedaVisual_Lotes(ByVal sCodigoAlmacen As String) As tBusquedaLotes
        Dim b As New tBusquedaLotes

        Dim f As New BusquedaVisual
        f.Text = "Búsqueda de lotes."
        f.sCampo = "C.DESCRIPCION"
        f.sOrder = "C.DESCRIPCION,C.CODIGO_ARTICULO,C.FECHA"
        f.sTable = "VW_INVENTARIO_LOTES_COSTOS_EXTENDIDO"
        f.sQl = "SELECT C.CODIGO_ARTICULO,C.DESCRIPCION,C.FECHA,C.CANTIDAD_DISPONIBLE DISPONIBLE,C.COSTO,C.ID_INVENTARIO_LOTES_COSTOS ID_LOTE
                 FROM VW_INVENTARIO_LOTES_COSTOS_EXTENDIDO C 
                 WHERE C.CODIGO_ALMACEN1='" & sReplace(sCodigoAlmacen) & "' AND C.CANTIDAD_DISPONIBLE>0 AND "
        f.arrayWidthColumns = New Integer() {100, 300, 100, 100, 100, 0}
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                b.CodigoArticulo = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
                b.Costo = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 4), Decimal)
                b.ID_INVENTARIO_LOTES_COSTOS = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 5), String) 'Nota, cuidado con el índice si se agregan mas columnas este podria necesitar cambiarse.
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_Lotes", ex)
        End Try

        Return b
    End Function
#End Region

End Class


