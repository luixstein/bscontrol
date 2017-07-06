Option Strict On
Imports System.Data
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
    Private _TOTAL As Double
    Private _NATURALEZA_INVENTARIOS As String
    Private _FOLIO_POLIZA As String
    Private _FECHA_CANCELACION As Date
    Private _CODIGO_USUARIO_CANCELACION As Integer
    Private _NOMBRE_USUARIO As String
    Private _NOMBRE_USUARIO_CANCELO As String
    Private _ESTA_CANCELADO As String
    Private _ESTATUS As String
    Private _FOLIO_EMBARQUE As String

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

    Public Property TOTAL() As Double
        Get
            Return Me._TOTAL
        End Get
        Set(ByVal Value As Double)
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
    Public Function Actualizar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_INVENTARIOS_MOVIMIENTOS_GRABA_GLOBAL"

            sqlParametro = .Parameters.Add("@FOLIO_MOVIMIENTO_INVENTARIO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_MOVIMIENTO_INVENTARIO.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = "" & Me._CODIGO_TIPO_DOCUMENTO.ToUpper
            sqlParametro = .Parameters.Add("@FOLIO_REFERENCIA", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_REFERENCIA.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN1", SqlDbType.NVarChar, 4) : sqlParametro.Value = "" & Me._CODIGO_ALMACEN1
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN2", SqlDbType.NVarChar, 4) : sqlParametro.Value = "" & Me._CODIGO_ALMACEN2
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.SmallDateTime) : sqlParametro.Value = "" & Me._FECHA
            sqlParametro = .Parameters.Add("@CONCEPTO", SqlDbType.NVarChar, 160) : sqlParametro.Value = "" & Me._CONCEPTO.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = "" & Me._CODIGO_USUARIO
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@TOTAL", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = "ACTUALIZAR"
            sqlParametro = .Parameters.Add("@FOLIO_EMBARQUE", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_EMBARQUE.ToUpper
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
                Me._FOLIO_MOVIMIENTO_INVENTARIO = "" & .Parameters("@FOLIO_MOVIMIENTO_INVENTARIO").Value.ToString
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

    Public Function Insertar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_INVENTARIOS_MOVIMIENTOS_GRABA_GLOBAL"

            sqlParametro = .Parameters.Add("@FOLIO_MOVIMIENTO_INVENTARIO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_MOVIMIENTO_INVENTARIO.ToString : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = "" & Me._CODIGO_TIPO_DOCUMENTO.ToUpper
            sqlParametro = .Parameters.Add("@FOLIO_REFERENCIA", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_REFERENCIA.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN1", SqlDbType.NVarChar, 4) : sqlParametro.Value = "" & Me._CODIGO_ALMACEN1
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN2", SqlDbType.NVarChar, 4) : sqlParametro.Value = "" & Me._CODIGO_ALMACEN2
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.SmallDateTime) : sqlParametro.Value = "" & Me._FECHA
            sqlParametro = .Parameters.Add("@CONCEPTO", SqlDbType.NVarChar, 160) : sqlParametro.Value = "" & Me._CONCEPTO.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = "" & Me._CODIGO_USUARIO
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@TOTAL", SqlDbType.Money) : sqlParametro.Value = Me._TOTAL
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = "INSERTAR"
            sqlParametro = .Parameters.Add("@FOLIO_EMBARQUE", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_EMBARQUE.ToUpper
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
                Me._FOLIO_MOVIMIENTO_INVENTARIO = "" & .Parameters("@FOLIO_MOVIMIENTO_INVENTARIO").Value.ToString
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
                    Me._TOTAL = CDbl(dReader("COSTO_TOTAL"))
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
            sSQL = "With DC(ID_ADICIONAL, CUENTA_CONTABLE) " & _
                    "AS " & _
                    "(SELECT ID_ADICIONAL,MAX(CUENTA_CONTABLE) FROM CENTRO_COSTOS_MOVIMIENTOS_DETALLE WHERE FOLIO_MOVIMIENTO=@FOLIO_MOVIMIENTO_INVENTARIO GROUP BY FOLIO_MOVIMIENTO,ID_ADICIONAL) " & _
                    "SELECT I.CODIGO_ARTICULO,A.DESCRIPCION,I.CANTIDAD,I.COSTO_DETALLE,I.IMPORTE,I.CUENTA_CONTABLE,CASE WHEN DC.CUENTA_CONTABLE IS NOT NULL THEN 'Tiene detalle -->>' ELSE C.NOMBRE_CUENTA END NOMBRE_CUENTA, " & _
                    "'' Boton,I.ID_ADICIONAL " & _
                    "FROM INVENTARIO_MOVIMIENTOS_DETALLE I  " & _
                    "INNER JOIN CAT_ARTICULOS A ON (A.CODIGO_ARTICULO=I.CODIGO_ARTICULO)  " & _
                    "LEFT JOIN CON_CAT_CUENTAS C ON(I.CUENTA_CONTABLE=C.CUENTA_CONTABLE) " & _
                    "LEFT JOIN DC ON(I.ID_ADICIONAL=DC.ID_ADICIONAL) " & _
                    "WHERE I.FOLIO_MOVIMIENTO_INVENTARIO=@FOLIO_MOVIMIENTO_INVENTARIO " & _
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

#End Region

End Class


