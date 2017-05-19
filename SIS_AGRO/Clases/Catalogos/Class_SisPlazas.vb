Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_SisPlazas
    Inherits Class_Catalogos


#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_PLAZA As Integer
    Private _NOMBRE_PLAZA As String
    'ESTATUS SE HEREDA
    Private _ESTATUS_PLAZA As String
    Private _Identificador As String
    Private _Impuesto_Porcentaje As Decimal
    Private _Codigo_Proveedor As String
    Private _PLAZO_VENTA_CONTADO As String
    Private _CUENTA_CONTABLE_VENTAS As String

    Private _CALLE As String
    Private _NUMERO_EXTERIOR As String
    Private _NUMERO_INTERIOR As String
    Private _COLONIA As String
    Private _LOCALIDAD As String
    Private _CIUDAD As String
    Private _ESTADO As String
    Private _PAIS As String
    Private _CODIGO_POSTAL As String
    Private _TELEFONO As String
    Private _VALIDAR_FECHA_VENTAS As String
    Private _CODIGO_COLONIA_SAT As String
    Private _CODIGO_LOCALIDAD_SAT As String
    Private _CODIGO_MUNICIPIO As String
    Private _CODIGO_ESTADO As String
    Private _CODIGO_PAIS_SAT As String

    Private _CODIGO_ESTADO_NUMERICO As Integer
    Private _CODIGO_CLIENTES_EXPORTACION As String
    Private _CODIGO_CLIENTES_NACIONAL As String
    Private _CUENTA_CONTABLE_MAYOR_EXPORTACION As String
    Private _CUENTA_CONTABLE_MAYOR_NACIONAL As String
    Private _CUENTA_CONTABLE_CONTADO_EXPORTACION As String
    Private _CUENTA_CONTABLE_CONTADO_NACIONAL As String
    Private _CODIGO_ALMACEN_PRINCIPAL As String
    Private _CODIGO_ZONA_PRINCIPAL As String

    Private _ID_CON_EJERCICIO As Integer
    Private _FECHA_INICIO As Date
    Private _FECHA_FINAL As Date
    Private _CUENTA_DESCUENTOS_REBAJAS_NACIONALES As String

    Private _ID_TEMPORADA_PRODUCCION As String
    Private _CUENTA_CONTABLE_PROVEEDOR_GENERICA As String
    Private _CODIGO_LOTE_EMPAQUE As String
    Private _CODIGO_LOTE_PLANTA As String
    Private _CODIGO_PUNTO_PAGO_EMPAQUE As String
#End Region

#Region "Campos ligados a la tabla"
    Private _NOMBRE_EJERCICIO As String
    Private _CODIGO_ESTADO_SAT As String
    Private _CODIGO_MUNICIPIO_SAT As String
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

#Region "Clase Detalle"
    Public oSisPlazaNomina As Class_SisEmpresaNomina
#End Region
#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"

    Public Property CODIGO_PLAZA() As Integer
        Get
            Return Me._CODIGO_PLAZA
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_PLAZA = Value
        End Set
    End Property

    Public Property NOMBRE_PLAZA() As String
        Get
            Return Me._NOMBRE_PLAZA
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_PLAZA = Value
        End Set
    End Property

    Public Property ESTATUS_PLAZA() As String
        Get
            Return Me._ESTATUS_PLAZA
        End Get
        Set(ByVal Value As String)
            Me._ESTATUS_PLAZA = Value
        End Set
    End Property

    Public Property Identificador() As String
        Get
            Return Me._Identificador
        End Get
        Set(ByVal value As String)
            Me._Identificador = value
        End Set
    End Property

    Public Property Impuesto_Porcentaje() As Decimal
        Get
            Return Me._Impuesto_Porcentaje
        End Get
        Set(ByVal value As Decimal)
            Me._Impuesto_Porcentaje = value
        End Set
    End Property

    Public Property Codigo_Proveedor() As String
        Get
            Return Me._Codigo_Proveedor
        End Get
        Set(ByVal value As String)
            Me._Codigo_Proveedor = value
        End Set
    End Property

    Public Property CALLE() As String
        Get
            Return Me._CALLE
        End Get
        Set(ByVal value As String)
            Me._CALLE = value
        End Set
    End Property

    Public Property NUMERO_EXTERIOR() As String
        Get
            Return Me._NUMERO_EXTERIOR
        End Get
        Set(ByVal value As String)
            Me._NUMERO_EXTERIOR = value
        End Set
    End Property

    Public Property NUMERO_INTERIOR() As String
        Get
            Return Me._NUMERO_INTERIOR
        End Get
        Set(ByVal value As String)
            Me._NUMERO_INTERIOR = value
        End Set
    End Property

    Public Property COLONIA() As String
        Get
            Return Me._COLONIA
        End Get
        Set(ByVal value As String)
            Me._COLONIA = value
        End Set
    End Property

    Public Property LOCALIDAD() As String
        Get
            Return Me._LOCALIDAD
        End Get
        Set(ByVal value As String)
            Me._LOCALIDAD = value
        End Set
    End Property

    Public Property CIUDAD() As String
        Get
            Return Me._CIUDAD
        End Get
        Set(ByVal value As String)
            Me._CIUDAD = value
        End Set
    End Property

    Public Property ESTADO() As String
        Get
            Return Me._ESTADO
        End Get
        Set(ByVal value As String)
            Me._ESTADO = value
        End Set
    End Property

    Public Property PAIS() As String
        Get
            Return Me._PAIS
        End Get
        Set(ByVal value As String)
            Me._PAIS = value
        End Set
    End Property

    Public Property CODIGO_POSTAL() As String
        Get
            Return Me._CODIGO_POSTAL
        End Get
        Set(ByVal value As String)
            Me._CODIGO_POSTAL = value
        End Set
    End Property

    Public Property TELEFONO() As String
        Get
            Return Me._TELEFONO
        End Get
        Set(ByVal value As String)
            Me._TELEFONO = value
        End Set
    End Property

    Public Property CUENTA_CONTABLE_VENTAS() As String
        Get
            Return Me._CUENTA_CONTABLE_VENTAS
        End Get
        Set(ByVal value As String)
            Me._CUENTA_CONTABLE_VENTAS = value
        End Set
    End Property

    Public Property CUENTA_CONTABLE_MAYOR_EXPORTACION() As String
        Get
            Return Me._CUENTA_CONTABLE_MAYOR_EXPORTACION
        End Get
        Set(ByVal value As String)
            Me._CUENTA_CONTABLE_MAYOR_EXPORTACION = value
        End Set
    End Property

    Public Property CUENTA_CONTABLE_MAYOR_NACIONAL() As String
        Get
            Return Me._CUENTA_CONTABLE_MAYOR_NACIONAL
        End Get
        Set(ByVal value As String)
            Me._CUENTA_CONTABLE_MAYOR_NACIONAL = value
        End Set
    End Property

    Public Property CUENTA_CONTABLE_CONTADO_EXPORTACION() As String
        Get
            Return Me._CUENTA_CONTABLE_CONTADO_EXPORTACION
        End Get
        Set(ByVal value As String)
            Me._CUENTA_CONTABLE_CONTADO_EXPORTACION = value
        End Set
    End Property

    Public Property CUENTA_CONTABLE_CONTADO_NACIONAL() As String
        Get
            Return Me._CUENTA_CONTABLE_CONTADO_NACIONAL
        End Get
        Set(ByVal value As String)
            Me._CUENTA_CONTABLE_CONTADO_NACIONAL = value
        End Set
    End Property

    Public Property PLAZO_VENTA_CONTADO() As String
        Get
            Return Me._PLAZO_VENTA_CONTADO
        End Get
        Set(ByVal value As String)
            Me._PLAZO_VENTA_CONTADO = value
        End Set
    End Property

    Public Property VALIDAR_FECHA_VENTAS() As String
        Get
            Return Me._VALIDAR_FECHA_VENTAS
        End Get
        Set(ByVal value As String)
            Me._VALIDAR_FECHA_VENTAS = value
        End Set
    End Property
    Public Property CODIGO_COLONIA_SAT() As String
        Get
            Return Me._CODIGO_COLONIA_SAT
        End Get
        Set(ByVal value As String)
            Me._CODIGO_COLONIA_SAT = value
        End Set
    End Property

    Public Property CODIGO_LOCALIDAD_SAT() As String
        Get
            Return Me._CODIGO_LOCALIDAD_SAT
        End Get
        Set(ByVal value As String)
            Me._CODIGO_LOCALIDAD_SAT = value
        End Set
    End Property

    Public Property CODIGO_MUNICIPIO() As String
        Get
            Return Me._CODIGO_MUNICIPIO
        End Get
        Set(ByVal value As String)
            Me._CODIGO_MUNICIPIO = value
        End Set
    End Property

    Public Property CODIGO_ESTADO() As String
        Get
            Return Me._CODIGO_ESTADO
        End Get
        Set(ByVal value As String)
            Me._CODIGO_ESTADO = value
        End Set
    End Property

    Public Property CODIGO_PAIS_SAT() As String
        Get
            Return Me._CODIGO_PAIS_SAT
        End Get
        Set(ByVal value As String)
            Me._CODIGO_PAIS_SAT = value
        End Set
    End Property

    Public Property CODIGO_ESTADO_NUMERICO() As Integer
        Get
            Return Me._CODIGO_ESTADO_NUMERICO
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_ESTADO_NUMERICO = value
        End Set
    End Property

    Public Property CODIGO_ALMACEN_PRINCIPAL() As String
        Get
            Return Me._CODIGO_ALMACEN_PRINCIPAL
        End Get
        Set(ByVal value As String)
            Me._CODIGO_ALMACEN_PRINCIPAL = value
        End Set
    End Property

    Public Property CODIGO_ZONA_PRINCIPAL() As String
        Get
            Return Me._CODIGO_ZONA_PRINCIPAL
        End Get
        Set(ByVal value As String)
            Me._CODIGO_ZONA_PRINCIPAL = value
        End Set
    End Property

    Public Property ID_CON_EJERCICIO() As Integer
        Get
            Return Me._ID_CON_EJERCICIO
        End Get
        Set(ByVal value As Integer)
            Me._ID_CON_EJERCICIO = value
        End Set
    End Property

    Public Property FECHA_INICIO() As Date
        Get
            Return Me._FECHA_INICIO
        End Get
        Set(ByVal value As Date)
            Me._FECHA_INICIO = value
        End Set
    End Property

    Public Property FECHA_FINAL() As Date
        Get
            Return Me._FECHA_FINAL
        End Get
        Set(ByVal value As Date)
            Me._FECHA_FINAL = value
        End Set
    End Property

    Public Property CUENTA_DESCUENTOS_REBAJAS_NACIONALES() As String
        Get
            Return Me._CUENTA_DESCUENTOS_REBAJAS_NACIONALES
        End Get
        Set(ByVal value As String)
            Me._CUENTA_DESCUENTOS_REBAJAS_NACIONALES = value
        End Set
    End Property

    Public Property ID_TEMPORADA_PRODUCCION() As String
        Get
            Return Me._ID_TEMPORADA_PRODUCCION
        End Get
        Set(ByVal value As String)
            Me._ID_TEMPORADA_PRODUCCION = value
        End Set
    End Property

    Public Property CUENTA_CONTABLE_PROVEEDOR_GENERICA() As String
        Get
            Return Me._CUENTA_CONTABLE_PROVEEDOR_GENERICA
        End Get
        Set(ByVal value As String)
            Me._CUENTA_CONTABLE_PROVEEDOR_GENERICA = value
        End Set
    End Property

    Public Property CODIGO_LOTE_EMPAQUE() As String
        Get
            Return Me._CODIGO_LOTE_EMPAQUE
        End Get
        Set(ByVal value As String)
            Me._CODIGO_LOTE_EMPAQUE = value
        End Set
    End Property

    Public Property CODIGO_LOTE_PLANTA() As String
        Get
            Return Me._CODIGO_LOTE_PLANTA
        End Get
        Set(ByVal value As String)
            Me._CODIGO_LOTE_PLANTA = value
        End Set
    End Property

    Public Property CODIGO_PUNTO_PAGO_EMPAQUE() As String
        Get
            Return Me._CODIGO_PUNTO_PAGO_EMPAQUE
        End Get
        Set(ByVal value As String)
            Me._CODIGO_PUNTO_PAGO_EMPAQUE = value
        End Set
    End Property

    Public Property CODIGO_CLIENTES_EXPORTACION() As String
        Get
            Return Me._CODIGO_CLIENTES_EXPORTACION
        End Get
        Set(ByVal value As String)
            Me._CODIGO_CLIENTES_EXPORTACION = value
        End Set
    End Property

    Public Property CODIGO_CLIENTES_NACIONAL() As String
        Get
            Return Me._CODIGO_CLIENTES_NACIONAL
        End Get
        Set(ByVal value As String)
            Me._CODIGO_CLIENTES_NACIONAL = value
        End Set
    End Property

#End Region

#Region "Propiedades de campos ligados a la tabla"

    Public ReadOnly Property NOMBRE_EJERCICIO() As String
        Get
            Return Me._NOMBRE_EJERCICIO
        End Get
    End Property
    Public Property CODIGO_ESTADO_SAT() As String
        Get
            Return Me._CODIGO_ESTADO_SAT
        End Get
        Set(ByVal value As String)
            Me._CODIGO_ESTADO_SAT = value
        End Set
    End Property

    Public Property CODIGO_MUNICIPIO_SAT() As String
        Get
            Return Me._CODIGO_MUNICIPIO_SAT
        End Get
        Set(ByVal value As String)
            Me._CODIGO_MUNICIPIO_SAT = value
        End Set
    End Property
#End Region

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

#End Region

#Region "Propiedades de campos de sistema"
    Public Overrides ReadOnly Property Nombre_Catalogo() As String
        Get
            Return Me._Nombre_Catalogo
        End Get
    End Property

    Public Overrides Property Nombre_Reporte() As String
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
    Public Sub New(ByVal bAbrirConexion As Boolean, ByVal bLogin As Boolean)
        Me._Nombre_Catalogo = "SIS_PLAZAS"
    End Sub

    Public Sub New()
        Me._Nombre_Catalogo = "SIS_PLAZAS"
        Me._Nombre_Reporte = "RPT_CATALOGO_PLAZAS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        'Me._QuerySelect = "Select * From SIS_PLAZAS"
        Me._QuerySelect = "SELECT P.*,E.NOMBRE_EJERCICIO FROM SIS_PLAZAS P INNER JOIN CON_EJERCICIOS E ON(P.ID_CON_EJERCICIO=E.ID_CON_EJERCICIO) "
        Me._QueryOrder = " Order by NOMBRE_PLAZA"

        Me.oSisPlazaNomina = New Class_SisEmpresaNomina(Empresa_Sistema.conexion)
    End Sub

    Public Sub New(ByVal iCODPlaza As Integer)
        Me.New()
        Try
            Me.CODIGO_PLAZA = iCODPlaza
            If Me.Consultar = False Then
                Throw New Exception("La Plaza no existe.")
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

    Public Overrides Function Actualizar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_SIS_PLAZAS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_PLAZA)
            sqlParametro = .Parameters.Add("@NOMBRE_PLAZA", SqlDbType.NVarChar, 60) : sqlParametro.Value = Me._NOMBRE_PLAZA.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS_PLAZA", SqlDbType.Char, 1) : sqlParametro.Value = Me._ESTATUS_PLAZA
            sqlParametro = .Parameters.Add("@IDENTIFICADOR", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._Identificador.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PROVEEDOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._Codigo_Proveedor.ToString.ToUpper
            sqlParametro = .Parameters.Add("@IMPUESTO_PORCENTAJE", SqlDbType.Decimal) : sqlParametro.Value = Me._Impuesto_Porcentaje
            sqlParametro = .Parameters.Add("@CALLE", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._CALLE.ToUpper
            sqlParametro = .Parameters.Add("@NUMERO_EXTERIOR", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._NUMERO_EXTERIOR.ToString
            sqlParametro = .Parameters.Add("@NUMERO_INTERIOR", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._NUMERO_INTERIOR.ToString
            sqlParametro = .Parameters.Add("@COLONIA", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._COLONIA.ToUpper
            sqlParametro = .Parameters.Add("@LOCALIDAD", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._LOCALIDAD.ToUpper
            sqlParametro = .Parameters.Add("@CIUDAD", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._CIUDAD.ToUpper
            sqlParametro = .Parameters.Add("@ESTADO", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._ESTADO.ToUpper
            sqlParametro = .Parameters.Add("@PAIS", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._PAIS.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_POSTAL", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_POSTAL.ToString
            sqlParametro = .Parameters.Add("@TELEFONO", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._TELEFONO.ToString
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_VENTAS", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_VENTAS.ToString
            sqlParametro = .Parameters.Add("@PLAZO_VENTA_CONTADO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._PLAZO_VENTA_CONTADO)
            sqlParametro = .Parameters.Add("@VALIDAR_FECHA_VENTAS", SqlDbType.Char, 1) : sqlParametro.Value = Me._VALIDAR_FECHA_VENTAS.ToString
            sqlParametro = .Parameters.Add("@ID_TEMPORADA_PRODUCCION", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._ID_TEMPORADA_PRODUCCION)
            sqlParametro = .Parameters.Add("@CODIGO_CLIENTES_EXPORTACION", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CODIGO_CLIENTES_EXPORTACION.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_CLIENTES_NACIONAL", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CODIGO_CLIENTES_NACIONAL.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_MAYOR_EXPORTACION", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_MAYOR_EXPORTACION.ToString
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_MAYOR_NACIONAL", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_MAYOR_NACIONAL.ToString
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_CONTADO_EXPORTACION", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_CONTADO_EXPORTACION.ToString
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_CONTADO_NACIONAL", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_CONTADO_NACIONAL.ToString
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN_PRINCIPAL", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_ALMACEN_PRINCIPAL.ToString
            sqlParametro = .Parameters.Add("@CODIGO_ZONA_PRINCIPAL", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_ZONA_PRINCIPAL.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ID_CON_EJERCICIO", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_CON_EJERCICIO
            sqlParametro = .Parameters.Add("@FECHA_INICIO", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_INICIO
            sqlParametro = .Parameters.Add("@FECHA_FINAL", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_FINAL
            sqlParametro = .Parameters.Add("@CUENTA_DESCUENTOS_REBAJAS_NACIONALES", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_DESCUENTOS_REBAJAS_NACIONALES.ToString
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_PROVEEDOR_GENERICA", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_PROVEEDOR_GENERICA.ToString
            sqlParametro = .Parameters.Add("@CODIGO_LOTE_EMPAQUE", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_LOTE_EMPAQUE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_LOTE_PLANTA", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_LOTE_PLANTA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PUNTO_PAGO_EMPAQUE", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_PUNTO_PAGO_EMPAQUE)
            sqlParametro = .Parameters.Add("@CODIGO_COLONIA_SAT", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_COLONIA_SAT.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_LOCALIDAD_SAT", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_LOCALIDAD_SAT.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_MUNICIPIO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_MUNICIPIO
            sqlParametro = .Parameters.Add("@CODIGO_ESTADO", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_ESTADO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PAIS_SAT", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_PAIS_SAT.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.Char, 1) : sqlParametro.Value = "0"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Actualizar = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Actualizar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try

        End With
    End Function

    Public Overrides Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        'Dim cmd As New SqlCommand(Me._QuerySelect & " Where P.CODIGO_PLAZA=" & CODIGO_PLAZA, Me._Conexion)

        Dim cmd As New SqlCommand("SELECT P.*,J.NOMBRE_EJERCICIO,E.CODIGO_ESTADO_SAT,M.CODIGO_MUNICIPIO_SAT " & _
                                  "FROM SIS_PLAZAS P " & _
                                  "INNER JOIN CON_EJERCICIOS J ON(P.ID_CON_EJERCICIO=J.ID_CON_EJERCICIO) " & _
                                  "LEFT JOIN SIS_ESTADOS E ON(P.CODIGO_ESTADO=E.CODIGO_ESTADO) " & _
                                  "LEFT JOIN CAT_MUNICIPIOS M ON(P.CODIGO_MUNICIPIO=M.CODIGO_MUNICIPIO) " & _
                                  "WHERE P.CODIGO_PLAZA=" & CODIGO_PLAZA, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_PLAZA = CType(dReader("CODIGO_PLAZA"), Integer)
                    Me._NOMBRE_PLAZA = Trim("" & dReader("NOMBRE_PLAZA").ToString)
                    'Me.ESTATUS_EJERCICIO = "" & dReader("ESTATUS_EJERCICIO").ToString
                    Me._Identificador = "" & dReader("IDENTIFICADOR").ToString
                    Me._ESTATUS_PLAZA = Trim("" & dReader("ESTATUS_PLAZA").ToString)

                    Me._PAIS = "" & dReader("PAIS").ToString
                    Me._CODIGO_PAIS_SAT = "" & dReader("CODIGO_PAIS_SAT").ToString
                    Me._ESTADO = "" & dReader("ESTADO").ToString
                    Me._CODIGO_ESTADO = "" & dReader("CODIGO_ESTADO").ToString
                    Me._CODIGO_ESTADO_NUMERICO = CInt(dReader("CODIGO_ESTADO_NUMERICO"))
                    'Me._CODIGO_ESTADO_SAT = "" & dReader("CODIGO_ESTADO_SAT").ToString '''El campo ya no esta en la tabla
                    Me._CIUDAD = "" & dReader("CIUDAD").ToString
                    Me._CODIGO_MUNICIPIO = "" & dReader("CODIGO_MUNICIPIO").ToString
                    'Me._CODIGO_MUNICIPIO_SAT = "" & dReader("CODIGO_MUNICIPIO_SAT").ToString '''El campo ya no esta en la tabla
                    Me._CALLE = "" & dReader("CALLE").ToString
                    Me._NUMERO_EXTERIOR = "" & dReader("NUMERO_EXTERIOR").ToString
                    Me._NUMERO_INTERIOR = "" & dReader("NUMERO_INTERIOR").ToString
                    Me._CODIGO_COLONIA_SAT = "" & dReader("CODIGO_COLONIA_SAT").ToString
                    Me._COLONIA = "" & dReader("COLONIA").ToString
                    Me._CODIGO_LOCALIDAD_SAT = "" & dReader("CODIGO_LOCALIDAD_SAT").ToString
                    Me._LOCALIDAD = "" & dReader("LOCALIDAD").ToString

                    Me._CODIGO_POSTAL = "" & dReader("CODIGO_POSTAL").ToString
                    Me._TELEFONO = "" & dReader("TELEFONO").ToString

                    Me._ID_CON_EJERCICIO = CInt(dReader("ID_CON_EJERCICIO").ToString)
                    Me._NOMBRE_EJERCICIO = "" & dReader("NOMBRE_EJERCICIO").ToString
                    Me._FECHA_INICIO = CDate(dReader("FECHA_INICIO").ToString)
                    Me._FECHA_FINAL = CDate(dReader("FECHA_FINAL").ToString)

                    Me._CUENTA_CONTABLE_VENTAS = "" & dReader("CUENTA_CONTABLE_VENTAS").ToString
                    Me._CUENTA_CONTABLE_MAYOR_EXPORTACION = "" & dReader("CUENTA_CONTABLE_MAYOR_EXPORTACION").ToString
                    Me._CUENTA_CONTABLE_MAYOR_NACIONAL = "" & dReader("CUENTA_CONTABLE_MAYOR_NACIONAL").ToString
                    Me._CUENTA_CONTABLE_CONTADO_EXPORTACION = "" & dReader("CUENTA_CONTABLE_CONTADO_EXPORTACION").ToString
                    Me._CUENTA_CONTABLE_CONTADO_NACIONAL = "" & dReader("CUENTA_CONTABLE_CONTADO_NACIONAL").ToString
                    Me._CUENTA_CONTABLE_PROVEEDOR_GENERICA = "" & dReader("CUENTA_CONTABLE_PROVEEDOR_GENERICA").ToString
                    Me._CUENTA_DESCUENTOS_REBAJAS_NACIONALES = "" & dReader("CUENTA_DESCUENTOS_REBAJAS_NACIONALES").ToString

                    Me._Impuesto_Porcentaje = CDec(dReader("IMPUESTO_PORCENTAJE"))
                    Me._PLAZO_VENTA_CONTADO = "" & dReader("PLAZO_VENTA_CONTADO").ToString
                    Me._VALIDAR_FECHA_VENTAS = "" & dReader("VALIDAR_FECHA_VENTAS").ToString
                    Me._ID_TEMPORADA_PRODUCCION = "" & dReader("ID_TEMPORADA_PRODUCCION").ToString
                    Me._CODIGO_CLIENTES_EXPORTACION = "" & dReader("CODIGO_CLIENTES_EXPORTACION").ToString
                    Me._CODIGO_CLIENTES_NACIONAL = "" & dReader("CODIGO_CLIENTES_NACIONAL").ToString

                    Me._CODIGO_ZONA_PRINCIPAL = "" & dReader("CODIGO_ZONA_PRINCIPAL").ToString
                    Me._CODIGO_ALMACEN_PRINCIPAL = "" & dReader("CODIGO_ALMACEN_PRINCIPAL").ToString

                    Me._Codigo_Proveedor = "" & dReader("Codigo_Proveedor").ToString
                    Me._CODIGO_LOTE_EMPAQUE = "" & dReader("CODIGO_LOTE_EMPAQUE").ToString
                    Me._CODIGO_LOTE_PLANTA = "" & dReader("CODIGO_LOTE_PLANTA").ToString
                    Me._CODIGO_PUNTO_PAGO_EMPAQUE = "" & dReader("CODIGO_PUNTO_PAGO_EMPAQUE").ToString

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

    Public Overrides Function Insertar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_SIS_PLAZAS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_PLAZA)
            sqlParametro = .Parameters.Add("@NOMBRE_PLAZA", SqlDbType.NVarChar, 60) : sqlParametro.Value = Me._NOMBRE_PLAZA.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS_PLAZA", SqlDbType.Char, 1) : sqlParametro.Value = Me._ESTATUS_PLAZA
            sqlParametro = .Parameters.Add("@IDENTIFICADOR", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._Identificador.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PROVEEDOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._Codigo_Proveedor.ToString.ToUpper
            sqlParametro = .Parameters.Add("@IMPUESTO_PORCENTAJE", SqlDbType.Decimal) : sqlParametro.Value = Me._Impuesto_Porcentaje
            sqlParametro = .Parameters.Add("@CALLE", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._CALLE.ToUpper
            sqlParametro = .Parameters.Add("@NUMERO_EXTERIOR", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._NUMERO_EXTERIOR.ToString
            sqlParametro = .Parameters.Add("@NUMERO_INTERIOR", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._NUMERO_INTERIOR.ToString
            sqlParametro = .Parameters.Add("@COLONIA", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._COLONIA.ToUpper
            sqlParametro = .Parameters.Add("@LOCALIDAD", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._LOCALIDAD.ToUpper
            sqlParametro = .Parameters.Add("@CIUDAD", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._CIUDAD.ToUpper
            sqlParametro = .Parameters.Add("@ESTADO", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._ESTADO.ToUpper
            sqlParametro = .Parameters.Add("@PAIS", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._PAIS.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_POSTAL", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_POSTAL.ToString
            sqlParametro = .Parameters.Add("@TELEFONO", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._TELEFONO.ToString
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_VENTAS", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_VENTAS.ToString
            sqlParametro = .Parameters.Add("@PLAZO_VENTA_CONTADO", SqlDbType.Int) : sqlParametro.Value = CInt(Me._PLAZO_VENTA_CONTADO)
            sqlParametro = .Parameters.Add("@VALIDAR_FECHA_VENTAS", SqlDbType.Char, 1) : sqlParametro.Value = Me._VALIDAR_FECHA_VENTAS.ToString
            sqlParametro = .Parameters.Add("@ID_TEMPORADA_PRODUCCION", SqlDbType.Int) : sqlParametro.Value = CInt(Me._ID_TEMPORADA_PRODUCCION)
            sqlParametro = .Parameters.Add("@CODIGO_CLIENTES_EXPORTACION", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CODIGO_CLIENTES_EXPORTACION.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_CLIENTES_NACIONAL", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CODIGO_CLIENTES_NACIONAL.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_MAYOR_EXPORTACION", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_MAYOR_EXPORTACION.ToString
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_MAYOR_NACIONAL", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_MAYOR_NACIONAL.ToString
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_CONTADO_EXPORTACION", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_CONTADO_EXPORTACION.ToString
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_CONTADO_NACIONAL", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_CONTADO_NACIONAL.ToString
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN_PRINCIPAL", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_ALMACEN_PRINCIPAL.ToString
            sqlParametro = .Parameters.Add("@CODIGO_ZONA_PRINCIPAL", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_ZONA_PRINCIPAL.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ID_CON_EJERCICIO", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_CON_EJERCICIO
            sqlParametro = .Parameters.Add("@FECHA_INICIO", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_INICIO
            sqlParametro = .Parameters.Add("@FECHA_FINAL", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_FINAL
            sqlParametro = .Parameters.Add("@CUENTA_DESCUENTOS_REBAJAS_NACIONALES", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_DESCUENTOS_REBAJAS_NACIONALES.ToString
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_PROVEEDOR_GENERICA", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_PROVEEDOR_GENERICA.ToString
            sqlParametro = .Parameters.Add("@CODIGO_LOTE_EMPAQUE", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_LOTE_EMPAQUE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_LOTE_PLANTA", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_LOTE_PLANTA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PUNTO_PAGO_EMPAQUE", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_PUNTO_PAGO_EMPAQUE)
            sqlParametro = .Parameters.Add("@CODIGO_COLONIA_SAT", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_COLONIA_SAT.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_LOCALIDAD_SAT", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_LOCALIDAD_SAT.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_MUNICIPIO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_MUNICIPIO)
            sqlParametro = .Parameters.Add("@CODIGO_ESTADO", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_ESTADO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PAIS_SAT", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_PAIS_SAT.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.Char, 1) : sqlParametro.Value = "1"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Insertar = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Insertar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try

        End With
    End Function

    ''' <summary>
    ''' Devuelve un datatable con todos los registros de la tabla
    ''' </summary>
    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCat As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            dsCat.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCat.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT CODIGO_PLAZA,NOMBRE_PLAZA FROM SIS_PLAZA WHERE NOMBRE_PLAZA LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_PLAZA", Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosParaReporte() As System.Data.DataTable
        Dim dTable As New DataTable, dRow As DataRow
        Dim da As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
            dRow = dTable.NewRow
            dRow("CODIGO_PLAZA") = 0
            dRow("NOMBRE_PLAZA") = "TODOS"
            dTable.Rows.Add(dRow)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosParaReporte", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    ''' <summary>
    ''' Devuelve un datatable con todos los registros de la tabla que conicidan para 
    ''' el id de usuario.
    ''' </summary>
    Public Function ObtenerPlazasPorUsuario() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCat As New SqlDataAdapter("SELECT CODIGO_PLAZA,NOMBRE_PLAZA FROM VW_SIS_RELACION_USUARIOS_PLAZAS_EXTENDIDO WHERE CODIGO_USUARIO=" & Usuario.Codigo_Usuario & "", Me._Conexion)
        Try
            dsCat.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerPlazasPorUsuario", ex)
        Finally
            dsCat.Dispose()
        End Try
        Return dTable
    End Function

    ''' <summary>
    ''' Despliega la búsqueda visual por código.
    ''' </summary>
    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de plazas por Código."
        f.sCampo = "CODIGO_PLAZA"
        f.sOrder = "NOMBRE_PLAZA"
        f.sTable = "SIS_PLAZAS"
        f.sQl = "Select CODIGO_PLAZA,NOMBRE_PLAZA From SIS_PLAZAS Where 1=1 And"
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

    ''' <summary>
    ''' Despliega la búsqueda visual por descripción.
    ''' </summary>
    Public Overrides Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de plazas por Descripción."
        f.sCampo = "NOMBRE_PLAZA"
        f.sOrder = "NOMBRE_PLAZA"
        f.sTable = "SIS_PLAZAS"
        f.sQl = "Select CODIGO_PLAZA,NOMBRE_PLAZA From SIS_PLAZAS Where 1=1 And"
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

    Public Function ValidarPeriodoTrabajo(ByVal dtFecha As Date) As Boolean
        Try
            Dim ValidaPeriodo As New Class_find("SELECT 1,ESTATUS_EJERCICIO,NOMBRE_EJERCICIO FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Plaza.ID_CON_EJERCICIO & _
                    " AND (CAST('" & Format(dtFecha, "yyyy-dd-MM") & "' AS DATETIME) BETWEEN '" & Format(Plaza.FECHA_INICIO, "yyyy-dd-MM") & "' AND '" & Format(Plaza.FECHA_FINAL, "yyyy-dd-MM") & "')")
            'SE AGREGÓ EL CAST A LA FECHA PARA EVITAR LA COMPRACION DE STRING PORQUE EL SQL NO DISTINGUE QUE SE COMPARABA CON FECHAS

            If ValidaPeriodo.Result1.Length = 0 Then
                MsgBox("La fecha esta fuera del periodo de trabajo.", MsgBoxStyle.Exclamation, Me.Nombre_Catalogo)
                Return False
            End If

            If ValidaPeriodo.Result2.ToString <> "A" Then
                MsgBox("El ejercicio " & ValidaPeriodo.Result3.ToString & " no esta abierto .", MsgBoxStyle.Exclamation, Me.Nombre_Catalogo)
                Return False
            End If

            Return True
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ValidarPeriodoTrabajo", ex)
        End Try
    End Function

    Public Sub ActualizaNombreEjercicio()
        Dim sql As New Class_find("SELECT NOMBRE_EJERCICIO FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO=" & Me.ID_CON_EJERCICIO)
        Me._NOMBRE_EJERCICIO = sql.Result1
        sql = Nothing
    End Sub

    Public Function ActualizaFechas() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_ACTUALIZA_FECHAS_PLAZA"

            sqlParametro = .Parameters.Add("@FECHA_INICIO", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_INICIO
            sqlParametro = .Parameters.Add("@FECHA_FINAL", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_FINAL
            sqlParametro = .Parameters.Add("@ID_CON_EJERCICIO", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_CON_EJERCICIO
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "ActualizaFechas", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function CodigoSiguiente() As String
        Dim resultado As String
        Dim sql As New Class_find("SELECT ISNULL(MAX(CODIGO_PLAZA),0) FROM SIS_PLAZAS")

        resultado = (CInt(sql.Result1) + 1).ToString
        Return resultado
    End Function

#End Region

End Class


