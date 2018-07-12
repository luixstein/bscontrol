Option Strict On
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Class_CatArticulos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_ARTICULO As String
    Private _DESCRIPCION As String
    Private _UNIDAD_VENTA As String
    Private _ESTATUS As String
    Private _PROTEGIDO As String
    Private _INVENTARIABLE As String
    'Private _TIENE_IMPUESTO As String
    Private _CODIGO_FAMILIA As String
    Private _CODIGO_LINEA As String
    Private _PRECIO As Decimal
    Private _PESO As Decimal
    Private _CANTIDAD_BULTOS_POR_PALET As Integer
    Private _DESCRIPCION_EXTRANJERA As String = ""
    Private _CODIGO_CULTIVO As String = ""
    Private _CODIGO_TAMAÑO As String = ""
    Private _CODIGO_ENVASE As String = ""
    Private _CODIGO_ETIQUETA As String = ""
    Private _RANGO_PIEZAS As String = ""

    Private _CODIGO_PRODUCTO_AGRICOLA As String = ""
    Private _CODIGO_BARRAS As String = ""
    Private _ES_PRODUCTO_KILOS As String
    Private _CODIGO_BARRAS_PTI_13 As String = ""
    Private _CODIGO_BARRAS_PTI_14 As String = ""
    Private _ES_SERIALIZABLE As Boolean
    Private _GRADO_TOXICIDAD As String
    'Private _CODIGO_UNIDAD_VENTA As String
    'Private _NOMBRE_UNIDAD As String
    Private _CODIGO_PRODUCTO_SERVICIO As String
    Private _CODIGO_UNIDAD As String
    Private _ID_SIS_CAT_IMPUESTOS As String
    Private _FACTOR_CONVERSION As Decimal
    Private _CODIGO_PRODUCTO As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura

    Private _DESCRIPCION_EXTRANJERA_PARTE_1 As String
    Private _DESCRIPCION_EXTRANJERA_PARTE_2 As String
    Private _TIPO_CONTROL_INVENTARIO As String
    Private _IEPS_PORCENTAJE As Decimal
    Private _IMPUESTO_PORCENTAJE As Decimal
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

    Public Property CODIGO_ARTICULO() As String
        Get
            Return Me._CODIGO_ARTICULO
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_ARTICULO = VALUE
        End Set
    End Property

    Public Property DESCRIPCION() As String
        Get
            Return Me._DESCRIPCION
        End Get
        Set(ByVal VALUE As String)
            Me._DESCRIPCION = VALUE
        End Set
    End Property

    Public Property UNIDAD_VENTA() As String
        Get
            Return Me._UNIDAD_VENTA
        End Get
        Set(ByVal VALUE As String)
            Me._UNIDAD_VENTA = VALUE
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

    Public Property PROTEGIDO() As String
        Get
            Return Me._PROTEGIDO
        End Get
        Set(ByVal VALUE As String)
            Me._PROTEGIDO = VALUE
        End Set
    End Property

    Public Property INVENTARIABLE() As String
        Get
            Return Me._INVENTARIABLE
        End Get
        Set(ByVal VALUE As String)
            Me._INVENTARIABLE = VALUE
        End Set
    End Property

    'Public Property TIENE_IMPUESTO() As String
    '    Get
    '        Return Me._TIENE_IMPUESTO
    '    End Get
    '    Set(ByVal VALUE As String)
    '        Me._TIENE_IMPUESTO = VALUE
    '    End Set
    'End Property

    Public Property CODIGO_LINEA() As String
        Get
            Return Me._CODIGO_LINEA
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_LINEA = VALUE
        End Set
    End Property

    Public Property CODIGO_FAMILIA() As String
        Get
            Return Me._CODIGO_FAMILIA
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_FAMILIA = VALUE
        End Set
    End Property

    Public Property PRECIO() As Decimal
        Get
            Return Me._PRECIO
        End Get
        Set(ByVal VALUE As Decimal)
            Me._PRECIO = VALUE
        End Set
    End Property

    Public Property PESO() As Decimal
        Get
            Return Me._PESO
        End Get
        Set(ByVal VALUE As Decimal)
            Me._PESO = VALUE
        End Set
    End Property

    Public Property CANTIDAD_BULTOS_POR_PALET() As Integer
        Get
            Return Me._CANTIDAD_BULTOS_POR_PALET
        End Get
        Set(ByVal VALUE As Integer)
            Me._CANTIDAD_BULTOS_POR_PALET = VALUE
        End Set
    End Property

    Public Property DESCRIPCION_EXTRANJERA() As String
        Get
            Return Me._DESCRIPCION_EXTRANJERA
        End Get
        Set(ByVal VALUE As String)
            Me._DESCRIPCION_EXTRANJERA = VALUE
        End Set
    End Property

    Public Property CODIGO_CULTIVO() As String
        Get
            Return Me._CODIGO_CULTIVO
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_CULTIVO = VALUE
        End Set
    End Property

    Public Property CODIGO_TAMAÑO() As String
        Get
            Return Me._CODIGO_TAMAÑO
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_TAMAÑO = VALUE
        End Set
    End Property

    Public Property CODIGO_ENVASE() As String
        Get
            Return Me._CODIGO_ENVASE
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_ENVASE = VALUE
        End Set
    End Property

    Public Property CODIGO_ETIQUETA() As String
        Get
            Return Me._CODIGO_ETIQUETA
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_ETIQUETA = VALUE
        End Set
    End Property

    Public Property RANGO_PIEZAS() As String
        Get
            Return Me._RANGO_PIEZAS
        End Get
        Set(ByVal VALUE As String)
            Me._RANGO_PIEZAS = VALUE
        End Set
    End Property

    Public ReadOnly Property CODIGO_PRODUCTO_AGRICOLA() As String
        Get
            Return Me._CODIGO_PRODUCTO_AGRICOLA
        End Get
    End Property

    Public ReadOnly Property CODIGO_BARRAS() As String
        Get
            Return Me._CODIGO_BARRAS
        End Get
    End Property

    Public ReadOnly Property ES_PRODUCTO_KILOS() As String
        Get
            Return Me._ES_PRODUCTO_KILOS
        End Get
    End Property
    Public ReadOnly Property CODIGO_BARRAS_PTI_13() As String
        Get
            Return Me._CODIGO_BARRAS_PTI_13
        End Get
    End Property

    Public ReadOnly Property CODIGO_BARRAS_PTI_14() As String
        Get
            Return Me._CODIGO_BARRAS_PTI_14
        End Get
    End Property

    Public Property ES_SERIALIZABLE() As Boolean
        Get
            Return Me._ES_SERIALIZABLE
        End Get
        Set(value As Boolean)
            Me._ES_SERIALIZABLE = value
        End Set
    End Property

    Public Property GRADO_TOXICIDAD() As String
        Get
            Return Me._GRADO_TOXICIDAD
        End Get
        Set(value As String)
            Me._GRADO_TOXICIDAD = value
        End Set
    End Property


    'Public Property CODIGO_UNIDAD_VENTA() As String
    '    Get
    '        Return Me._CODIGO_UNIDAD_VENTA
    '    End Get
    '    Set(ByVal VALUE As String)
    '        Me._CODIGO_UNIDAD_VENTA = VALUE
    '    End Set
    'End Property

    'Public Property NOMBRE_UNIDAD() As String
    '    Get
    '        Return Me._NOMBRE_UNIDAD
    '    End Get
    '    Set(ByVal VALUE As String)
    '        Me._NOMBRE_UNIDAD = VALUE
    '    End Set
    'End Property

    Public Property CODIGO_PRODUCTO_SERVICIO() As String
        Get
            Return Me._CODIGO_PRODUCTO_SERVICIO
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_PRODUCTO_SERVICIO = VALUE
        End Set
    End Property

    Public Property CODIGO_UNIDAD() As String
        Get
            Return Me._CODIGO_UNIDAD
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_UNIDAD = VALUE
        End Set
    End Property

    Public Property ID_SIS_CAT_IMPUESTOS() As String
        Get
            Return Me._ID_SIS_CAT_IMPUESTOS
        End Get
        Set(ByVal VALUE As String)
            Me._ID_SIS_CAT_IMPUESTOS = VALUE
        End Set
    End Property

    Public Property FACTOR_CONVERSION() As Decimal
        Get
            Return Me._FACTOR_CONVERSION
        End Get
        Set(ByVal VALUE As Decimal)
            Me._FACTOR_CONVERSION = VALUE
        End Set
    End Property

    Public Property CODIGO_PRODUCTO() As String
        Get
            Return Me._CODIGO_PRODUCTO
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_PRODUCTO = VALUE
        End Set
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property DESCRIPCION_EXTRANJERA_PARTE_1() As String
        Get
            Return Me._DESCRIPCION_EXTRANJERA_PARTE_1
        End Get
    End Property

    Public ReadOnly Property DESCRIPCION_EXTRANJERA_PARTE_2() As String
        Get
            Return Me._DESCRIPCION_EXTRANJERA_PARTE_2
        End Get
    End Property

    Public ReadOnly Property TIPO_CONTROL_INVENTARIO() As String
        Get
            Return Me._TIPO_CONTROL_INVENTARIO
        End Get
    End Property

    Public ReadOnly Property IEPS_PORCENTAJE() As Decimal
        Get
            Return Me._IEPS_PORCENTAJE
        End Get
    End Property

    Public ReadOnly Property IMPUESTO_PORCENTAJE() As Decimal
        Get
            Return Me._IMPUESTO_PORCENTAJE
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

    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property

#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "Class_CatArticulos"
        Me._Nombre_Reporte = "RPT_CATALOGO_PRODUCTOS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT * FROM vw_cat_articulos_extendido " & _
                            " WHERE "
        Me._QueryOrder = " Order by Descripcion"
    End Sub

    Public Sub New(ByVal sArticulo As String)
        Me.New()
        Try
            Me.Codigo_Articulo = sArticulo
            If Me.Consultar = True Then
                Me._Existe = True
                'Throw New Exception("El artículo no existe.")
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
            .CommandText = "MP_CAT_ARTICULOS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CODIGO_ARTICULO
            sqlParametro = .Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 500) : sqlParametro.Value = Me._DESCRIPCION.ToUpper
            sqlParametro = .Parameters.Add("@UNIDAD_VENTA", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._UNIDAD_VENTA.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me._ESTATUS.ToUpper
            sqlParametro = .Parameters.Add("@PROTEGIDO", SqlDbType.Char, 1) : sqlParametro.Value = Me._PROTEGIDO
            sqlParametro = .Parameters.Add("@INVENTARIABLE", SqlDbType.Char, 1) : sqlParametro.Value = Me._INVENTARIABLE
            'sqlParametro = .Parameters.Add("@TIENE_IMPUESTO", SqlDbType.Char, 1) : sqlParametro.Value = Me._TIENE_IMPUESTO
            sqlParametro = .Parameters.Add("@CODIGO_FAMILIA", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_FAMILIA
            sqlParametro = .Parameters.Add("@CODIGO_LINEA", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_LINEA
            sqlParametro = .Parameters.Add("@PRECIO", SqlDbType.Money) : sqlParametro.Value = Me._PRECIO
            sqlParametro = .Parameters.Add("@PESO", SqlDbType.Money) : sqlParametro.Value = Me._PESO
            sqlParametro = .Parameters.Add("@CANTIDAD_BULTOS_POR_PALET", SqlDbType.SmallInt) : sqlParametro.Value = Me._CANTIDAD_BULTOS_POR_PALET
            sqlParametro = .Parameters.Add("@CODIGO_CULTIVO", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_CULTIVO
            sqlParametro = .Parameters.Add("@CODIGO_TAMAÑO", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._CODIGO_TAMAÑO
            sqlParametro = .Parameters.Add("@CODIGO_ENVASE", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_ENVASE
            sqlParametro = .Parameters.Add("@CODIGO_ETIQUETA", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_ETIQUETA
            sqlParametro = .Parameters.Add("@RANGO_PIEZAS", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._RANGO_PIEZAS
            sqlParametro = .Parameters.Add("@ES_SERIALIZABLE", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(Me._ES_SERIALIZABLE)
            sqlParametro = .Parameters.Add("@CODIGO_UNIDAD_VENTA", SqlDbType.NVarChar, 20) : sqlParametro.Value = "NA" ' Me._CODIGO_UNIDAD_VENTA.ToUpper
            sqlParametro = .Parameters.Add("@GRADO_TOXICIDAD", SqlDbType.SmallInt) : sqlParametro.Value = Me._GRADO_TOXICIDAD
            sqlParametro = .Parameters.Add("@CODIGO_PRODUCTO_SERVICIO", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_PRODUCTO_SERVICIO
            sqlParametro = .Parameters.Add("@CODIGO_UNIDAD", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_UNIDAD
            sqlParametro = .Parameters.Add("@ID_SIS_CAT_IMPUESTOS", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._ID_SIS_CAT_IMPUESTOS
            sqlParametro = .Parameters.Add("@FACTOR_CONVERSION", SqlDbType.Decimal) : sqlParametro.Value = Me._FACTOR_CONVERSION
            If txtLEN(Me._CODIGO_PRODUCTO) = True Then
                sqlParametro = .Parameters.Add("@CODIGO_PRODUCTO", SqlDbType.Int) : sqlParametro.Value = CInt(Me._CODIGO_PRODUCTO)
            Else
                sqlParametro = .Parameters.Add("@CODIGO_PRODUCTO", SqlDbType.Int) : sqlParametro.Value = DBNull.Value
            End If
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.NVarChar, 1) : sqlParametro.Value = sAccion

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._CODIGO_ARTICULO = "" & .Parameters("@CODIGO_ARTICULO").Value.ToString
                bResultado = True
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

    Public Function EliminarArticulo() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_ARTICULOS_ELIMINA"

            sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CODIGO_ARTICULO

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._CODIGO_ARTICULO = "" & .Parameters("@CODIGO_ARTICULO").Value.ToString
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "EliminarArticulo", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    'Public Function ActualizaDescripcion() As Boolean
    '    Dim bResultado As Boolean = False
    '    Dim cmd As New SqlCommand
    '    Dim sqlParametro As SqlParameter
    '    With cmd
    '        .Connection = Me._Conexion
    '        .CommandTimeout = 0
    '        .CommandType = CommandType.StoredProcedure
    '        .CommandText = "MP_ACTUALIZA_CAT_ARTICULOS_ACTUALIZA_DESCRIPCION"

    '        sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CODIGO_ARTICULO
    '        sqlParametro = .Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._DESCRIPCION

    '        Try
    '            Me._Conexion.Open()
    '            .ExecuteNonQuery()
    '            bResultado = True
    '        Catch ex As Exception
    '            HandleError(Me._Nombre_Catalogo, "ActualizaDescripcion", ex)
    '        Finally
    '            Me._Conexion.Close()
    '            cmd.Dispose()
    '            sqlParametro = Nothing
    '        End Try
    '    End With

    '    Return bResultado
    'End Function

    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " CODIGO_ARTICULO='" & Replace(Me._CODIGO_ARTICULO, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_ARTICULO = "" & dReader("CODIGO_ARTICULO").ToString()
                    Me._DESCRIPCION = Trim("" & dReader("DESCRIPCION").ToString())
                    Me._UNIDAD_VENTA = Trim("" & dReader("UNIDAD_VENTA").ToString())
                    Me._ESTATUS = "" & dReader("ESTATUS").ToString()
                    Me._INVENTARIABLE = "" & dReader("INVENTARIABLE").ToString()
                    'Me._TIENE_IMPUESTO = "" & dReader("TIENE_IMPUESTO").ToString()
                    Me._CODIGO_FAMILIA = "" & dReader("CODIGO_FAMILIA").ToString()
                    Me._CODIGO_LINEA = "" & dReader("CODIGO_LINEA").ToString()
                    Me._PRECIO = Convert.ToDecimal("" & dReader("PRECIO").ToString())
                    Me._DESCRIPCION_EXTRANJERA = "" & dReader("DESCRIPCION_EXTRANJERA").ToString()
                    Me._CODIGO_CULTIVO = "" & dReader("CODIGO_CULTIVO").ToString()
                    Me._CODIGO_TAMAÑO = "" & dReader("CODIGO_TAMAÑO").ToString()
                    Me._CODIGO_ENVASE = "" & dReader("CODIGO_ENVASE").ToString()
                    Me._CODIGO_ETIQUETA = "" & dReader("CODIGO_ETIQUETA").ToString()
                    Me._RANGO_PIEZAS = "" & dReader("RANGO_PIEZAS").ToString()
                    If txtLEN(Me._CODIGO_CULTIVO) = True Then
                        Me._PESO = Convert.ToDecimal("" & dReader("PESO").ToString())
                        Me._CANTIDAD_BULTOS_POR_PALET = CInt(dReader("CANTIDAD_BULTOS_POR_PALET"))
                    End If

                    Me._CODIGO_PRODUCTO_AGRICOLA = "" & dReader("CODIGO_PRODUCTO_AGRICOLA").ToString()
                    Me._CODIGO_BARRAS = "" & dReader("CODIGO_BARRAS").ToString()
                    Me._CODIGO_BARRAS_PTI_13 = Left("" & dReader("CODIGO_BARRAS_PTI").ToString(), 13)
                    Me._CODIGO_BARRAS_PTI_14 = Left("" & dReader("CODIGO_BARRAS_PTI").ToString(), 14)
                    Me._DESCRIPCION_EXTRANJERA_PARTE_1 = "" & dReader("DESCRIPCION_EXTRANJERA_PARTE_1").ToString()
                    Me._DESCRIPCION_EXTRANJERA_PARTE_2 = "" & dReader("DESCRIPCION_EXTRANJERA_PARTE_2").ToString()

                    Me._ES_PRODUCTO_KILOS = "" & dReader("ES_PRODUCTO_KILOS").ToString
                    Me._ES_SERIALIZABLE = CBool(dReader("ES_SERIALIZABLE").ToString)

                    Me._TIPO_CONTROL_INVENTARIO = IIf(Me._ES_SERIALIZABLE = True, "SER", IIf(Me._INVENTARIABLE = "1", "INV", "NIV")).ToString

                    Me._GRADO_TOXICIDAD = "" & dReader("GRADO_TOXICIDAD").ToString
                    Me._IEPS_PORCENTAJE = CDec("" & dReader("IEPS_PORCENTAJE").ToString)

                    '------------------------------------------------------------------------Estos campos se crearon en la base de datos pero aun no se utilizaran
                    'Me._CODIGO_UNIDAD_VENTA = "" & dReader("CODIGO_UNIDAD_VENTA").ToString()
                    'Me._NOMBRE_UNIDAD = "" & dReader("NOMBRE_UNIDAD").ToString()

                    Me._CODIGO_UNIDAD = "" & dReader("CODIGO_UNIDAD").ToString
                    Me._CODIGO_PRODUCTO_SERVICIO = "" & dReader("CODIGO_PRODUCTO_SERVICIO").ToString
                    Me._ID_SIS_CAT_IMPUESTOS = "" & dReader("ID_SIS_CAT_IMPUESTOS").ToString
                    Me._IMPUESTO_PORCENTAJE = CDec("" & dReader("IMPUESTO_PORCENTAJE").ToString)

                    Me._FACTOR_CONVERSION = Convert.ToDecimal("" & dReader("FACTOR_CONVERSION").ToString)
                    Me._CODIGO_PRODUCTO = "" & dReader("CODIGO_PRODUCTO").ToString

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

    Public Function Eliminar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_PRODUCTO_AGRICOLA_ELIMINA"
            sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CODIGO_ARTICULO
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Eliminar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCatArticulos As New SqlDataAdapter("SELECT CODIGO_ARTICULO,DESCRIPCION FROM CAT_ARTICULOS WHERE CODIGO_CULTIVO IS NULL ORDER BY DESCRIPCION", Me._Conexion)
        Try
            dsCatArticulos.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCatArticulos.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosParaCatalogos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCatArticulos As New SqlDataAdapter("SELECT CODIGO_ARTICULO,DESCRIPCION FROM CAT_ARTICULOS WHERE PROTEGIDO='0' AND CODIGO_CULTIVO IS NULL ORDER BY DESCRIPCION ", Me._Conexion)
        Try
            dsCatArticulos.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosParaCatalogos", ex)
        Finally
            dsCatArticulos.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerProductosAgricolas() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCatArticulos As New SqlDataAdapter("SELECT A.CODIGO_ARTICULO,A.DESCRIPCION FROM CAT_ARTICULOS A INNER JOIN CAT_CULTIVOS C ON(A.CODIGO_CULTIVO=C.CODIGO_CULTIVO) WHERE PROTEGIDO='0' AND A.CODIGO_CULTIVO IS NOT NULL AND C.CODIGO_PLAZA=" & Usuario.Codigo_Plaza & " ORDER BY DESCRIPCION  ", Me._Conexion)
        Try
            dsCatArticulos.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerProductosAgricolas", ex)
        Finally
            dsCatArticulos.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltroProductosAgricolas(ByVal Filtro As String, ByVal Estatus As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT A.CODIGO_ARTICULO,A.DESCRIPCION FROM CAT_ARTICULOS A INNER JOIN CAT_CULTIVOS C ON(A.CODIGO_CULTIVO=C.CODIGO_CULTIVO) WHERE A.PROTEGIDO='0' AND A.CODIGO_CULTIVO IS NOT NULL AND C.CODIGO_PLAZA=" & Usuario.Codigo_Plaza & " AND A.DESCRIPCION LIKE '" & Filtro.ToString & "%' AND A.ESTATUS='" & Estatus & "' ORDER BY A.DESCRIPCION", Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltroProductosAgricolas", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerFamilias() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCatArticulos As New SqlDataAdapter("SELECT CODIGO_FAMILIA, NOMBRE_FAMILIA FROM CAT_FAMILIAS ORDER BY NOMBRE_FAMILIA", Me._Conexion)
        Try
            dsCatArticulos.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerFamilias", ex)
        Finally
            dsCatArticulos.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerFamiliaArticulo(ByVal sCodigoArticulo As String) As String
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("SELECT CODIGO_FAMILIA FROM CAT_ARTICULOS WHERE CODIGO_ARTICULO ='" & sCodigoArticulo & "' ")
            If sql.Result1 <> "" Then
                Resultado = sql.Result1
            End If
            sql = Nothing
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerFamiliaArticulo", ex)
        End Try
        Return Resultado
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String, ByVal Estatus As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT CODIGO_ARTICULO,DESCRIPCION FROM CAT_ARTICULOS WHERE PROTEGIDO='0' AND CODIGO_CULTIVO IS NULL AND DESCRIPCION LIKE '" & Filtro.ToString & "%' AND ESTATUS='" & Estatus & "' ORDER BY DESCRIPCION", Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltroCodigo(ByVal Filtro As String, ByVal Estatus As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT CODIGO_ARTICULO,DESCRIPCION FROM CAT_ARTICULOS WHERE PROTEGIDO='0' AND CODIGO_CULTIVO IS NULL AND CODIGO_ARTICULO LIKE '" & Filtro.ToString & "%' AND ESTATUS='" & Estatus & "' ORDER BY DESCRIPCION", Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
    End Function

    Public Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Articulos por Código."
        f.sCampo = "A.CODIGO_ARTICULO"
        f.sOrder = "A.DESCRIPCION"
        f.sTable = "CAT_ARTICULOS"
        f.sQl = "SELECT A.CODIGO_ARTICULO,A.DESCRIPCION,F.NOMBRE_FAMILIA FROM CAT_ARTICULOS A " &
        "INNER JOIN CAT_FAMILIAS F ON(A.CODIGO_FAMILIA=F.CODIGO_FAMILIA) " &
        "LEFT JOIN CAT_CULTIVOS C ON (A.CODIGO_CULTIVO=C.CODIGO_CULTIVO) " &
        "WHERE 1=1 AND A.PROTEGIDO=0 AND A.ESTATUS='A' AND (C.CODIGO_PLAZA=1 OR A.CODIGO_CULTIVO IS NULL)"

        f.arrayWidthColumns = New Integer() {150, 500, 250}
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "BusquedaVisual_PorCodigo", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_PorCodigo_conExistencias(ByVal sAlmacen As String) As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Articulos por código de artículo."
        f.sCampo = "A.CODIGO_ARTICULO"
        f.sOrder = "A.DESCRIPCION"
        f.sTable = "CAT_ARTICULOS"
        f.sQl = "SELECT A.CODIGO_ARTICULO,A.DESCRIPCION,F.NOMBRE_FAMILIA,CONVERT(VARCHAR(50), CAST( ISNULL(I.EXISTENCIA,0) AS MONEY ),1) AS EXISTENCIA,CASE WHEN A.ES_SERIALIZABLE='1' THEN 'ES SERIADO' ELSE '' END " & _
        "FROM CAT_ARTICULOS A " & _
        "INNER JOIN CAT_FAMILIAS F ON(A.CODIGO_FAMILIA=F.CODIGO_FAMILIA) " & _
        "LEFT JOIN CAT_CULTIVOS C ON (A.CODIGO_CULTIVO=C.CODIGO_CULTIVO) " & _
        "LEFT JOIN INVENTARIO_EXISTENCIA_ARTICULOS I ON(I.CODIGO_ARTICULO=A.CODIGO_ARTICULO AND I.CODIGO_ALMACEN='" & sAlmacen & "') " & _
        "WHERE A.PROTEGIDO=0 AND A.ESTATUS='A' AND (C.CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " OR A.CODIGO_CULTIVO IS NULL) AND "

        f.arrayWidthColumns = New Integer() {150, 500, 250}
        f.Inicia("")
        f.ShowDialog()

        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "BusquedaVisual_PorCodigo_conExistencias", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Articulos por Descripción."
        f.sCampo = "A.DESCRIPCION"
        f.sOrder = "A.DESCRIPCION"
        f.sTable = "CAT_ARTICULOS"
        f.sQl = "SELECT A.CODIGO_ARTICULO,A.DESCRIPCION,F.NOMBRE_FAMILIA,CASE WHEN A.ES_SERIALIZABLE='1' THEN 'ES SERIADO' ELSE '' END " &
        "FROM CAT_ARTICULOS A " &
        "INNER JOIN CAT_FAMILIAS F ON(A.CODIGO_FAMILIA=F.CODIGO_FAMILIA) " &
        "LEFT JOIN CAT_CULTIVOS C ON (A.CODIGO_CULTIVO=C.CODIGO_CULTIVO) " &
        "WHERE A.PROTEGIDO=0 AND A.ESTATUS='A' AND (C.CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " OR A.CODIGO_CULTIVO IS NULL) AND "

        f.arrayWidthColumns = New Integer() {150, 500, 250}
        f.Inicia("")
        f.ShowDialog()

        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "BusquedaVisual_PorDescripcion", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_PorDescripcion_conExistencias(ByVal sAlmacen As String, Optional ByVal bSoloConExistencias As Boolean = False) As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Articulos por Descripción."
        f.sCampo = "A.DESCRIPCION"
        f.sOrder = "A.DESCRIPCION"
        f.sTable = "CAT_ARTICULOS"
        f.sQl = "SELECT A.CODIGO_ARTICULO,A.DESCRIPCION,F.NOMBRE_FAMILIA,CONVERT(VARCHAR(50), CAST( ISNULL(I.EXISTENCIA,0) AS MONEY ),1) AS EXISTENCIA,CASE WHEN A.ES_SERIALIZABLE='1' THEN 'ES SERIADO' ELSE '' END SERIADO, " &
        "CASE WHEN A.INVENTARIABLE='1' THEN 'SI' ELSE 'NO' END INVENTARIABLE " &
        "FROM CAT_ARTICULOS A " &
        "INNER JOIN CAT_FAMILIAS F ON(A.CODIGO_FAMILIA=F.CODIGO_FAMILIA) " &
        "LEFT JOIN CAT_CULTIVOS C ON (A.CODIGO_CULTIVO=C.CODIGO_CULTIVO) " &
        "LEFT JOIN INVENTARIO_EXISTENCIA_ARTICULOS I ON(I.CODIGO_ARTICULO=A.CODIGO_ARTICULO AND I.CODIGO_ALMACEN='" & sAlmacen & "') " &
        "WHERE A.PROTEGIDO=0 AND A.ESTATUS='A' AND (C.CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " OR A.CODIGO_CULTIVO IS NULL) AND " &
        IIf(bSoloConExistencias = True, "1=(CASE WHEN A.INVENTARIABLE=1 THEN (CASE WHEN I.EXISTENCIA>0 THEN 1 ELSE 0 END ) ELSE 1 END) AND", "").ToString
        f.arrayWidthColumns = New Integer() {150, 500, 250}
        f.Inicia("")
        f.ShowDialog()

        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "BusquedaVisual_PorDescripcion_conExistencias", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisualInventariables_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Articulos por Descripción."
        f.sCampo = "A.DESCRIPCION"
        f.sOrder = "A.DESCRIPCION"
        f.sTable = "CAT_ARTICULOS"
        f.sQl = "SELECT A.CODIGO_ARTICULO,A.DESCRIPCION,F.NOMBRE_FAMILIA " & _
        "FROM CAT_ARTICULOS A " & _
        "INNER JOIN CAT_FAMILIAS F ON(A.CODIGO_FAMILIA=F.CODIGO_FAMILIA) WHERE A.PROTEGIDO=0 AND A.ESTATUS='A' AND INVENTARIABLE='1' AND "
        f.arrayWidthColumns = New Integer() {150, 500, 250}
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "BusquedaVisualInventariables_PorDescripcion", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisualInventariables_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Articulos por código."
        f.sCampo = "A.CODIGO_ARTICULO"
        f.sOrder = "A.DESCRIPCION"
        f.sTable = "CAT_ARTICULOS"
        f.sQl = "SELECT A.CODIGO_ARTICULO,A.DESCRIPCION,F.NOMBRE_FAMILIA " & _
        "FROM CAT_ARTICULOS A " & _
        "INNER JOIN CAT_FAMILIAS F ON(A.CODIGO_FAMILIA=F.CODIGO_FAMILIA) WHERE A.PROTEGIDO=0 AND A.ESTATUS='A' AND INVENTARIABLE='1' AND "
        f.arrayWidthColumns = New Integer() {150, 500, 250}
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "BusquedaVisualInventariables_PorCodigo", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisualInventariablesConExistencia_PorDescripcion(ByVal sCodigoAlmacen As String) As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Articulos por Descripción."
        f.sCampo = "A.DESCRIPCION"
        f.sOrder = "A.DESCRIPCION"
        f.sTable = "CAT_ARTICULOS"
        f.sQl = "SELECT A.CODIGO_ARTICULO,A.DESCRIPCION,F.NOMBRE_FAMILIA,E.EXISTENCIA " & _
        "FROM CAT_ARTICULOS A " & _
        "INNER JOIN CAT_FAMILIAS F ON(A.CODIGO_FAMILIA=F.CODIGO_FAMILIA) " & _
        "LEFT JOIN INVENTARIO_EXISTENCIA_ARTICULOS E ON(A.CODIGO_ARTICULO=E.CODIGO_ARTICULO AND E.CODIGO_ALMACEN='" & sReplace(sCodigoAlmacen) & "') " & _
        "WHERE A.PROTEGIDO=0 AND A.ESTATUS='A' AND INVENTARIABLE='1' AND "
        f.arrayWidthColumns = New Integer() {150, 500, 250}
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "BusquedaVisualInventariablesConExistencia_PorDescripcion", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisualInventariablesConExistencia_PorCodigo(ByVal sCodigoAlmacen As String) As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Articulos por código."
        f.sCampo = "A.CODIGO_ARTICULO"
        f.sOrder = "A.DESCRIPCION"
        f.sTable = "CAT_ARTICULOS"
        f.sQl = "SELECT A.CODIGO_ARTICULO,A.DESCRIPCION,F.NOMBRE_FAMILIA,E.EXISTENCIA " & _
        "FROM CAT_ARTICULOS A " & _
        "INNER JOIN CAT_FAMILIAS F ON(A.CODIGO_FAMILIA=F.CODIGO_FAMILIA) " & _
        "LEFT JOIN INVENTARIO_EXISTENCIA_ARTICULOS E ON(A.CODIGO_ARTICULO=E.CODIGO_ARTICULO AND E.CODIGO_ALMACEN='" & sReplace(sCodigoAlmacen) & "') " & _
        "WHERE A.PROTEGIDO=0 AND A.ESTATUS='A' AND INVENTARIABLE='1' AND "
        f.arrayWidthColumns = New Integer() {150, 500, 250}
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "BusquedaVisualInventariablesConExistencia_PorCodigo", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisualMaterialEmpaque_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Articulos por Descripción."
        f.sCampo = "Descripcion"
        f.sOrder = "Descripcion"
        f.sTable = "Cat_Articulos"
        f.sQl = "Select CODIGO_ARTICULO,DESCRIPCION From Cat_Articulos Where 1=1 And Protegido=0 AND INVENTARIABLE='1' and CODIGO_FAMILIA='0008' AND "
        f.arrayWidthColumns = New Integer() {150, 600}
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "BusquedaVisualMaterialEmpaque_PorDescripcion", ex)
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
            HandleError(Me._Nombre_Catalogo, "BuscarNombreArticulo", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisualProductosAgricolas_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Articulos  agricolas por Descripción."
        f.sCampo = "Descripcion"
        f.sOrder = "Descripcion"
        f.sTable = "VW_CAT_PRODUCTOS_AGRICOLAS"
        '       "SELECT CODIGO_ARTICULO,DESCRIPCION FROM CAT_ARTICULOS WHERE PROTEGIDO='0' AND CODIGO_CULTIVO IS NOT NULL  ORDER BY DESCRIPCION ", Me._Conexion)
        f.sQl = "SELECT CODIGO_ARTICULO,DESCRIPCION,PESO,PRECIO,CANTIDAD_BULTOS_POR_PALET FROM VW_CAT_PRODUCTOS_AGRICOLAS WHERE ESTATUS='A' AND CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & "AND "

        f.arrayWidthColumns = New Integer() {150, 400, 150, 150, 150}
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "BusquedaVisualProductosAgricolas_PorDescripcion", ex)
        End Try
        Return Resultado
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

    Public Function CodigoSiguiente() As String
        Dim Resultado As Integer
        Dim sql As New Class_find("SELECT MAX(CAST(CODIGO_ARTICULO AS INT)) FROM CAT_ARTICULOS WHERE ISNUMERIC(CODIGO_ARTICULO)=1 AND CODIGO_ARTICULO<>'-'")
        Resultado = CInt(sql.Result1) + 1
        Return Resultado.ToString
    End Function

#End Region

End Class


