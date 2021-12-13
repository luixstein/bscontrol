Option Strict On

Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Class_CatClientes

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_CLIENTE As String
    Private _NOMBRE_CLIENTE As String
    Private _ESTATUS As String
    Private _RFC As String
    Private _TIPO_PERSONA As String
    Private _CURP As String
    Private _TELEFONO As String
    Private _CELULAR As String
    Private _CALLE As String
    Private _NUMERO_EXTERIOR As String
    Private _NUMERO_INTERIOR As String
    Private _COLONIA As String
    Private _CIUDAD As String
    Private _LOCALIDAD As String
    Private _ESTADO As String
    Private _CODIGO_POSTAL As String
    Private _CODIGO_ZONA As String
    Private _CODIGO_VENDEDOR As String
    Private _CUENTA_CONTABLE As String
    Private _CUENTA_CONTABLE_DOLARES As String
    Private _LIMITE_CREDITO As Double
    Private _DIAS_PLAZO As Double
    Private _SALDO As Double
    Private _PERMITIR_VENTA_CREDITO As String
    Private _FECHA_ALTA As Date
    Private _PLAZA As String
    Private _CORREO_CLIENTE As String
    Private _CODIGO_METODO_PAGO As String
    Private _NUMERO_CUENTA_PAGO As String
    Private _CODIGO_METODO_PAGO_DOLARES As String
    Private _NUMERO_CUENTA_PAGO_DOLARES As String
    Private _CODIGO_TIPO_MERCADO As String
    Private _FORMATO_NOMBRE_XML As String
    Private _NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO As String
    Private _CODIGO_ALMACEN As String
    Private _AGREGAR As String
    Private _CODIGO_MUNICIPIO As String
    Private _CODIGO_ESTADO As String
    Private _CODIGO_ESTADO_SAT As String
    Private _CODIGO_PAIS_SAT As String
    Private _ES_CONTRIBUYENTE_IEPS As String
    Private _CODIGO_USO_CFDI As String
    Private _CORREO_CLIENTE_PAGOS As String
    Private _CODIGO_GIRO As String
    Private _CODIGO_TIPO_NEGOCIACION As String
    Private _CUENTA_CONTABLE_ANTICIPOS As String
    Private _CODIGO_REGIMEN_FISCAL As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean
    Private _NOMBRE_MUNICIPIO As String
    Private _NOMBRE_ESTADO As String
    Private _NOMBRE_PAIS As String

    Private _CODIGO_PROPIETARIO As String
    Private _ID As String
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
    Public Property CODIGO_CLIENTE() As String
        Get
            Return Me._CODIGO_CLIENTE
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CLIENTE = Value
        End Set
    End Property

    Public Property NOMBRE_CLIENTE() As String
        Get
            Return Me._NOMBRE_CLIENTE
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_CLIENTE = Value
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

    Public Property RFC() As String
        Get
            Return Me._RFC
        End Get
        Set(ByVal Value As String)
            Me._RFC = Value
        End Set
    End Property

    Public Property TIPO_PERSONA() As String
        Get
            Return Me._TIPO_PERSONA
        End Get
        Set(ByVal Value As String)
            Me._TIPO_PERSONA = Value
        End Set
    End Property

    Public Property CURP() As String
        Get
            Return Me._CURP
        End Get
        Set(ByVal Value As String)
            Me._CURP = Value
        End Set
    End Property

    Public Property TELEFONO() As String
        Get
            Return Me._TELEFONO
        End Get
        Set(ByVal Value As String)
            Me._TELEFONO = Value
        End Set
    End Property

    Public Property CELULAR() As String
        Get
            Return Me._CELULAR
        End Get
        Set(ByVal Value As String)
            Me._CELULAR = Value
        End Set
    End Property

    Public Property CALLE() As String
        Get
            Return Me._CALLE
        End Get
        Set(ByVal Value As String)
            Me._CALLE = Value
        End Set
    End Property

    Public Property NUMERO_EXTERIOR() As String
        Get
            Return Me._NUMERO_EXTERIOR
        End Get
        Set(ByVal Value As String)
            Me._NUMERO_EXTERIOR = Value
        End Set
    End Property

    Public Property NUMERO_INTERIOR() As String
        Get
            Return Me._NUMERO_INTERIOR
        End Get
        Set(ByVal Value As String)
            Me._NUMERO_INTERIOR = Value
        End Set
    End Property

    Public Property COLONIA() As String
        Get
            Return Me._COLONIA
        End Get
        Set(ByVal Value As String)
            Me._COLONIA = Value
        End Set
    End Property

    Public Property CIUDAD() As String
        Get
            Return Me._CIUDAD
        End Get
        Set(ByVal Value As String)
            Me._CIUDAD = Value
        End Set
    End Property

    Public Property LOCALIDAD() As String
        Get
            Return Me._LOCALIDAD
        End Get
        Set(ByVal Value As String)
            Me._LOCALIDAD = Value
        End Set
    End Property

    Public Property ESTADO() As String
        Get
            Return Me._ESTADO
        End Get
        Set(ByVal Value As String)
            Me._ESTADO = Value
        End Set
    End Property

    Public Property CODIGO_POSTAL() As String
        Get
            Return Me._CODIGO_POSTAL
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_POSTAL = Value
        End Set
    End Property

    Public Property CODIGO_ZONA() As String
        Get
            Return Me._CODIGO_ZONA
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_ZONA = Value
        End Set
    End Property

    Public Property CODIGO_VENDEDOR() As String
        Get
            Return Me._CODIGO_VENDEDOR
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_VENDEDOR = Value
        End Set
    End Property

    Public Property CUENTA_CONTABLE() As String
        Get
            Return Me._CUENTA_CONTABLE
        End Get
        Set(ByVal Value As String)
            Me._CUENTA_CONTABLE = Value
        End Set
    End Property

    Public Property CUENTA_CONTABLE_DOLARES() As String
        Get
            Return Me._CUENTA_CONTABLE_DOLARES
        End Get
        Set(ByVal Value As String)
            Me._CUENTA_CONTABLE_DOLARES = Value
        End Set
    End Property

    Public Property LIMITE_CREDITO() As Double
        Get
            Return Me._LIMITE_CREDITO
        End Get
        Set(ByVal Value As Double)
            Me._LIMITE_CREDITO = Value
        End Set
    End Property

    Public Property DIAS_PLAZO() As Double
        Get
            Return Me._DIAS_PLAZO
        End Get
        Set(ByVal Value As Double)
            Me._DIAS_PLAZO = Value
        End Set
    End Property

    Public Property SALDO() As Double
        Get
            Return Me._SALDO
        End Get
        Set(ByVal Value As Double)
            Me._SALDO = Value
        End Set
    End Property

    Public Property PERMITIR_VENTA_CREDITO() As String
        Get
            Return Me._PERMITIR_VENTA_CREDITO
        End Get
        Set(ByVal Value As String)
            Me._PERMITIR_VENTA_CREDITO = Value
        End Set
    End Property

    Public Property FECHA_ALTA() As Date
        Get
            Return Me._FECHA_ALTA
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_ALTA = Value
        End Set
    End Property

    Public Property PLAZA() As String
        Get
            Return Me._PLAZA
        End Get
        Set(ByVal Value As String)
            Me._PLAZA = Value
        End Set
    End Property

    Public Property CORREO_CLIENTE() As String
        Get
            Return Me._CORREO_CLIENTE
        End Get
        Set(ByVal Value As String)
            Me._CORREO_CLIENTE = Value
        End Set
    End Property

    Public Property AGREGAR() As String
        Get
            Return Me._AGREGAR
        End Get
        Set(ByVal Value As String)
            Me._AGREGAR = Value
        End Set
    End Property

    Public Property CODIGO_METODO_PAGO() As String
        Get
            Return Me._CODIGO_METODO_PAGO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_METODO_PAGO = Value
        End Set
    End Property

    Public Property NUMERO_CUENTA_PAGO() As String
        Get
            Return Me._NUMERO_CUENTA_PAGO
        End Get
        Set(ByVal Value As String)
            Me._NUMERO_CUENTA_PAGO = Value
        End Set
    End Property

    Public Property CODIGO_METODO_PAGO_DOLARES() As String
        Get
            Return Me._CODIGO_METODO_PAGO_DOLARES
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_METODO_PAGO_DOLARES = Value
        End Set
    End Property

    Public Property NUMERO_CUENTA_PAGO_DOLARES() As String
        Get
            Return Me._NUMERO_CUENTA_PAGO_DOLARES
        End Get
        Set(ByVal Value As String)
            Me._NUMERO_CUENTA_PAGO_DOLARES = Value
        End Set
    End Property

    Public Property CODIGO_TIPO_MERCADO() As String
        Get
            Return Me._CODIGO_TIPO_MERCADO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_TIPO_MERCADO = Value
        End Set
    End Property

    Public Property FORMATO_NOMBRE_XML() As String
        Get
            Return Me._FORMATO_NOMBRE_XML
        End Get
        Set(ByVal Value As String)
            Me._FORMATO_NOMBRE_XML = Value
        End Set
    End Property

    Public Property NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO() As String
        Get
            Return Me._NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO
        End Get
        Set(ByVal Value As String)
            Me._NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO = Value
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
    Public Property CODIGO_MUNICIPIO() As String
        Get
            Return Me._CODIGO_MUNICIPIO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_MUNICIPIO = Value
        End Set
    End Property

    Public Property CODIGO_ESTADO() As String
        Get
            Return Me._CODIGO_ESTADO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_ESTADO = Value
        End Set
    End Property

    Public Property CODIGO_PAIS_SAT() As String
        Get
            Return Me._CODIGO_PAIS_SAT
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_PAIS_SAT = Value
        End Set
    End Property

    Public Property ES_CONTRIBUYENTE_IEPS() As String
        Get
            Return Me._ES_CONTRIBUYENTE_IEPS
        End Get
        Set(ByVal Value As String)
            Me._ES_CONTRIBUYENTE_IEPS = Value
        End Set
    End Property

    Public Property CODIGO_USO_CFDI() As String
        Get
            Return Me._CODIGO_USO_CFDI
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_USO_CFDI = Value
        End Set
    End Property

    Public Property CODIGO_GIRO() As String
        Get
            Return Me._CODIGO_GIRO
        End Get
        Set(value As String)
            Me._CODIGO_GIRO = value
        End Set
    End Property

    Public Property CODIGO_TIPO_NEGOCIACION() As String
        Get
            Return Me._CODIGO_TIPO_NEGOCIACION
        End Get
        Set(value As String)
            Me._CODIGO_TIPO_NEGOCIACION = value
        End Set
    End Property

    Public Property CUENTA_CONTABLE_ANTICIPOS() As String
        Get
            Return Me._CUENTA_CONTABLE_ANTICIPOS
        End Get
        Set(ByVal Value As String)
            Me._CUENTA_CONTABLE_ANTICIPOS = Value
        End Set
    End Property

    Public Property CODIGO_REGIMEN_FISCAL() As String
        Get
            Return Me._CODIGO_REGIMEN_FISCAL
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_REGIMEN_FISCAL = Value
        End Set
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property CODIGO_ESTADO_SAT() As String
        Get
            Return Me._CODIGO_ESTADO_SAT
        End Get
    End Property

    Public ReadOnly Property NOMBRE_MUNICIPIO() As String
        Get
            Return Me._NOMBRE_MUNICIPIO
        End Get
    End Property

    Public ReadOnly Property NOMBRE_ESTADO() As String
        Get
            Return Me._NOMBRE_ESTADO
        End Get
    End Property

    Public ReadOnly Property NOMBRE_PAIS() As String
        Get
            Return Me._NOMBRE_PAIS
        End Get
    End Property

    Public Property CODIGO_PROPIETARIO() As String
        Get
            Return Me._CODIGO_PROPIETARIO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_PROPIETARIO = Value
        End Set
    End Property

    Public Property ID() As String
        Get
            Return Me._ID
        End Get
        Set(ByVal Value As String)
            Me._ID = Value
        End Set
    End Property

    Public Property CORREO_CLIENTE_PAGOS() As String
        Get
            Return Me._CORREO_CLIENTE_PAGOS
        End Get
        Set(value As String)
            Me._CORREO_CLIENTE_PAGOS = value
        End Set
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
        Me._Nombre_Catalogo = "CAT_CLIENTES"
        Me._Nombre_Reporte = "RPT_CATALOGO_CLIENTES"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT C.CODIGO_CLIENTE,C.NOMBRE_CLIENTE,C.Estatus,C.RFC,C.TIPO_PERSONA,C.CURP,C.TELEFONO,C.CELULAR, " &
        "C.CALLE,C.NUMERO_EXTERIOR,C.NUMERO_INTERIOR,C.COLONIA,C.CIUDAD,C.LOCALIDAD,C.ESTADO,C.CODIGO_POSTAL,C.CODIGO_ZONA, " &
        "C.CODIGO_VENDEDOR,C.CUENTA_CONTABLE,C.CUENTA_CONTABLE_DOLARES,C.CUENTA_CONTABLE_ANTICIPOS,C.LIMITE_CREDITO,C.DIAS_PLAZO,C.SALDO,C.PERMITIR_VENTA_CREDITO, " &
        "C.FECHA_ALTA,C.PLAZA,C.CORREO_CLIENTE,C.CODIGO_METODO_PAGO,C.NUMERO_CUENTA_PAGO,C.CODIGO_METODO_PAGO_DOLARES,C.NUMERO_CUENTA_PAGO_DOLARES,C.CODIGO_TIPO_MERCADO,C.FORMATO_NOMBRE_XML," &
        "C.CODIGO_ALMACEN,C.NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO,C.CODIGO_MUNICIPIO,C.CODIGO_ESTADO,E.CODIGO_ESTADO_SAT,C.CODIGO_PAIS_SAT,M.NOMBRE_MUNICIPIO,E.NOMBRE_ESTADO,P.NOMBRE_PAIS,C.ES_CONTRIBUYENTE_IEPS," &
        "C.CODIGO_USO_CFDI,C.CODIGO_PROPIETARIO,C.CORREO_CLIENTE_PAGOS,C.CODIGO_GIRO,C.CODIGO_TIPO_NEGOCIACION,C.CODIGO_REGIMEN_FISCAL " &
        "FROM CAT_CLIENTES C " &
        "LEFT JOIN CAT_MUNICIPIOS M ON(C.CODIGO_MUNICIPIO=M.CODIGO_MUNICIPIO) " &
        "LEFT JOIN SIS_ESTADOS E ON(C.CODIGO_ESTADO=E.CODIGO_ESTADO) " &
        "LEFT JOIN CAT_PAISES P ON(C.CODIGO_PAIS_SAT=P.CODIGO_PAIS_SAT)"
        Me._QueryOrder = " ORDER BY C.NOMBRE_CLIENTE"
    End Sub

    Public Sub New(ByVal sCodigoCliente As String)
        Me.New()
        Me._CODIGO_CLIENTE = sCodigoCliente
        Try
            If Me.Consultar = True Then
                Me._Existe = True
                'Else
                '    Throw New Exception("El PRODUCTOR no existe.")
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

    Public Function Grabar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_CLIENTES_GRABAR"

            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CODIGO_CLIENTE.ToUpper : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@NOMBRE_CLIENTE", SqlDbType.NVarChar, 254) : sqlParametro.Value = Me._NOMBRE_CLIENTE.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me._ESTATUS.ToUpper
            sqlParametro = .Parameters.Add("@RFC", SqlDbType.NVarChar, 13) : sqlParametro.Value = Me._RFC.ToString.ToUpper
            sqlParametro = .Parameters.Add("@TIPO_PERSONA", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._TIPO_PERSONA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CURP", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._CURP.ToString.ToUpper
            sqlParametro = .Parameters.Add("@TELEFONO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._TELEFONO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CELULAR", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._CELULAR.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CALLE", SqlDbType.NVarChar, 100) : sqlParametro.Value = Me._CALLE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@NUMERO_EXTERIOR", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._NUMERO_EXTERIOR.ToString.ToUpper
            sqlParametro = .Parameters.Add("@NUMERO_INTERIOR", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._NUMERO_INTERIOR.ToString.ToUpper
            sqlParametro = .Parameters.Add("@COLONIA", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._COLONIA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CIUDAD", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._CIUDAD.ToString.ToUpper
            sqlParametro = .Parameters.Add("@LOCALIDAD", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._LOCALIDAD.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTADO", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._ESTADO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_POSTAL", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_POSTAL.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_ZONA", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_ZONA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_VENDEDOR", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._CODIGO_VENDEDOR.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_DOLARES", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_DOLARES.ToString.ToUpper
            sqlParametro = .Parameters.Add("@LIMITE_CREDITO", SqlDbType.Money) : sqlParametro.Value = Me._LIMITE_CREDITO
            sqlParametro = .Parameters.Add("@DIAS_PLAZO", SqlDbType.Decimal) : sqlParametro.Value = Me._DIAS_PLAZO
            sqlParametro = .Parameters.Add("@PERMITIR_VENTA_CREDITO", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._PERMITIR_VENTA_CREDITO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@PLAZA", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._PLAZA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CORREO_CLIENTE", SqlDbType.NVarChar, 500) : sqlParametro.Value = Me._CORREO_CLIENTE.ToString
            sqlParametro = .Parameters.Add("@CODIGO_METODO_PAGO", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_METODO_PAGO
            sqlParametro = .Parameters.Add("@NUMERO_CUENTA_PAGO", SqlDbType.NVarChar, 40) : sqlParametro.Value = Me._NUMERO_CUENTA_PAGO.ToString
            sqlParametro = .Parameters.Add("@CODIGO_METODO_PAGO_DOLARES", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_METODO_PAGO_DOLARES
            sqlParametro = .Parameters.Add("@NUMERO_CUENTA_PAGO_DOLARES", SqlDbType.NVarChar, 40) : sqlParametro.Value = Me._NUMERO_CUENTA_PAGO_DOLARES.ToString
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_MERCADO", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_TIPO_MERCADO.ToString
            sqlParametro = .Parameters.Add("@FORMATO_NOMBRE_XML", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._FORMATO_NOMBRE_XML.ToString
            sqlParametro = .Parameters.Add("@NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO", SqlDbType.NVarChar, 100) : sqlParametro.Value = Me._NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO.ToString
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_ALMACEN.ToString
            sqlParametro = .Parameters.Add("@CODIGO_MUNICIPIO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_MUNICIPIO.ToString
            sqlParametro = .Parameters.Add("@CODIGO_ESTADO", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_ESTADO.ToString
            sqlParametro = .Parameters.Add("@CODIGO_PAIS_SAT", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_PAIS_SAT.ToString
            sqlParametro = .Parameters.Add("@ES_CONTRIBUYENTE_IEPS", SqlDbType.Char, 1) : sqlParametro.Value = Me._ES_CONTRIBUYENTE_IEPS.ToString
            sqlParametro = .Parameters.Add("@CODIGO_PROPIETARIO", SqlDbType.Int) : sqlParametro.Value = IIf(txtLEN(Me._CODIGO_PROPIETARIO) = True, CInt(Me._CODIGO_PROPIETARIO), DBNull.Value)
            sqlParametro = .Parameters.Add("@ID", SqlDbType.Int) : sqlParametro.Value = IIf(txtLEN(Me._ID) = True, CInt(Me._ID), DBNull.Value)
            sqlParametro = .Parameters.Add("@CODIGO_USO_CFDI", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_USO_CFDI.ToString
            sqlParametro = .Parameters.Add("@CORREO_CLIENTE_PAGOS", SqlDbType.NVarChar, 500) : sqlParametro.Value = Me._CORREO_CLIENTE_PAGOS.ToString
            sqlParametro = .Parameters.Add("@CODIGO_GIRO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_GIRO)
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_NEGOCIACION", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_TIPO_NEGOCIACION)
            sqlParametro = .Parameters.Add("@CODIGO_REGIMEN_FISCAL", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._CODIGO_REGIMEN_FISCAL
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._AGREGAR.ToString
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True

                If Me._AGREGAR = "1" Then
                    Me._CODIGO_CLIENTE = "" & .Parameters("@CODIGO_CLIENTE").Value.ToString 'Código de nuevo cliente generado
                End If

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

    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE CODIGO_CLIENTE='" & sReplace(Me._CODIGO_CLIENTE) & "' ", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_CLIENTE = "" & dReader("CODIGO_CLIENTE").ToString
                    Me._NOMBRE_CLIENTE = "" & dReader("NOMBRE_CLIENTE").ToString
                    Me._ESTATUS = "" & dReader("ESTATUS").ToString
                    Me._RFC = "" & dReader("RFC").ToString
                    Me._TIPO_PERSONA = "" & dReader("TIPO_PERSONA").ToString
                    Me._CURP = "" & dReader("CURP").ToString
                    Me._TELEFONO = "" & dReader("TELEFONO").ToString
                    Me._CELULAR = "" & dReader("CELULAR").ToString
                    Me._CALLE = "" & dReader("CALLE").ToString
                    Me._NUMERO_EXTERIOR = "" & dReader("NUMERO_EXTERIOR").ToString
                    Me._NUMERO_INTERIOR = "" & dReader("NUMERO_INTERIOR").ToString
                    Me._COLONIA = "" & dReader("COLONIA").ToString
                    Me._CIUDAD = "" & dReader("CIUDAD").ToString
                    Me._LOCALIDAD = "" & dReader("LOCALIDAD").ToString
                    Me._ESTADO = "" & dReader("ESTADO").ToString
                    Me._CODIGO_POSTAL = "" & dReader("CODIGO_POSTAL").ToString
                    Me._CODIGO_ZONA = "" & dReader("CODIGO_ZONA").ToString
                    Me._CODIGO_VENDEDOR = "" & dReader("CODIGO_VENDEDOR").ToString
                    Me._CUENTA_CONTABLE = "" & dReader("CUENTA_CONTABLE").ToString
                    Me._CUENTA_CONTABLE_DOLARES = "" & dReader("CUENTA_CONTABLE_DOLARES").ToString
                    Me._LIMITE_CREDITO = CDbl(dReader("LIMITE_CREDITO"))
                    Me._DIAS_PLAZO = CDbl(dReader("DIAS_PLAZO"))
                    Me._SALDO = CDbl(dReader("SALDO"))
                    Me._PERMITIR_VENTA_CREDITO = "" & dReader("PERMITIR_VENTA_CREDITO").ToString
                    Me._FECHA_ALTA = CDate(dReader("FECHA_ALTA"))
                    Me._PLAZA = "" & dReader("PLAZA").ToString
                    Me._CORREO_CLIENTE = Trim("" & dReader("CORREO_CLIENTE").ToString)
                    Me._CODIGO_METODO_PAGO = dReader("CODIGO_METODO_PAGO").ToString
                    Me._NUMERO_CUENTA_PAGO = Trim("" & dReader("NUMERO_CUENTA_PAGO").ToString)
                    Me._CODIGO_METODO_PAGO_DOLARES = dReader("CODIGO_METODO_PAGO_DOLARES").ToString
                    Me._NUMERO_CUENTA_PAGO_DOLARES = Trim("" & dReader("NUMERO_CUENTA_PAGO_DOLARES").ToString)
                    Me._CODIGO_TIPO_MERCADO = Trim("" & dReader("CODIGO_TIPO_MERCADO").ToString)
                    Me._FORMATO_NOMBRE_XML = Trim("" & dReader("FORMATO_NOMBRE_XML").ToString)
                    Me._NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO = Trim("" & dReader("NUMERO_IDENTIFICACION_REGISTRO_FISCAL_EXTRANJERO").ToString)
                    Me._CODIGO_ALMACEN = Trim("" & dReader("CODIGO_ALMACEN").ToString)
                    Me._CODIGO_MUNICIPIO = Trim("" & dReader("CODIGO_MUNICIPIO").ToString)
                    Me._CODIGO_ESTADO = Trim("" & dReader("CODIGO_ESTADO").ToString)
                    Me._CODIGO_ESTADO_SAT = Trim("" & dReader("CODIGO_ESTADO_SAT").ToString)
                    Me._CODIGO_PAIS_SAT = Trim("" & dReader("CODIGO_PAIS_SAT").ToString)
                    Me._ES_CONTRIBUYENTE_IEPS = Trim("" & dReader("ES_CONTRIBUYENTE_IEPS").ToString)
                    Me._NOMBRE_MUNICIPIO = Trim("" & dReader("NOMBRE_MUNICIPIO").ToString)
                    Me._NOMBRE_ESTADO = Trim("" & dReader("NOMBRE_ESTADO").ToString)
                    Me._NOMBRE_PAIS = Trim("" & dReader("NOMBRE_PAIS").ToString)
                    Me._CODIGO_USO_CFDI = Trim("" & dReader("CODIGO_USO_CFDI").ToString)
                    Me._CODIGO_PROPIETARIO = "" & dReader("CODIGO_PROPIETARIO").ToString
                    Me._CORREO_CLIENTE_PAGOS = Trim("" & dReader("CORREO_CLIENTE_PAGOS").ToString)
                    Me._CODIGO_GIRO = "" & dReader("CODIGO_GIRO").ToString
                    Me._CODIGO_TIPO_NEGOCIACION = "" & dReader("CODIGO_TIPO_NEGOCIACION").ToString
                    Me._CUENTA_CONTABLE_ANTICIPOS = "" & dReader("CUENTA_CONTABLE_ANTICIPOS").ToString
                    Me._CODIGO_REGIMEN_FISCAL = "" & dReader("CODIGO_REGIMEN_FISCAL").ToString

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

    Public Function EliminarCliente() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_CLIENTES_ELIMINA"

            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CODIGO_CLIENTE.ToUpper
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_DOLARES", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_DOLARES.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_ANTICIPOS", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_ANTICIPOS.ToString.ToUpper

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "EliminarCliente", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function EliminaRelacionPropietario() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_CLIENTES_ELIMINA_RELACION_PROPIETARIO"

            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_CLIENTE.ToUpper

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "EliminaRelacionPropietario", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function ActualizarLimiteCredito(ByVal dLimiteCredito As Decimal) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_CLIENTES_ACTUALIZA_LIMITE_CREDITO"

            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_CLIENTE.ToUpper
            sqlParametro = .Parameters.Add("@LIMITE_CREDITO", SqlDbType.Money) : sqlParametro.Value = dLimiteCredito
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "ActualizarLimiteCredito", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function ActualizarCorreo(Optional ByVal EsCorreoPagos As String = "0") As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_CLIENTES_ACTUALIZA_CORREO"


            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_CLIENTE.ToString
            If EsCorreoPagos = "1" Then
                sqlParametro = .Parameters.Add("@CORREO_CLIENTE", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._CORREO_CLIENTE_PAGOS.ToString
            Else
                sqlParametro = .Parameters.Add("@CORREO_CLIENTE", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._CORREO_CLIENTE.ToString
            End If

            sqlParametro = .Parameters.Add("@ES_CORREO_PAGOS", SqlDbType.Char, 1) : sqlParametro.Value = EsCorreoPagos.ToString

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "ActualizarCorreo", ex)
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
        Dim sql As String = ""
        If Usuario.Codigo_Plaza = 1 Then 'Si inicio sesion en Matriz(plaza 1) debe poder ver todos los clientes
            sql = "SELECT CODIGO_CLIENTE,NOMBRE_CLIENTE FROM CAT_CLIENTES ORDER BY NOMBRE_CLIENTE"
        Else
            sql = "SELECT CODIGO_CLIENTE,NOMBRE_CLIENTE FROM CAT_CLIENTES  WHERE CODIGO_ZONA='" & Usuario.Codigo_Plaza.ToString & "' ORDER BY NOMBRE_CLIENTE"
        End If
        Dim ds As New SqlDataAdapter(sql, Me._Conexion)
        Try
            ds.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            ds.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String, ByVal Estatus As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim sql As String = ""
        If Usuario.Codigo_Plaza = 1 Then 'Si inicio sesion en Matriz(plaza 1) debe poder ver todos los clientes
            sql = "SELECT CODIGO_CLIENTE,NOMBRE_CLIENTE FROM CAT_CLIENTES  WHERE NOMBRE_CLIENTE LIKE '" & Filtro.ToString & "%' AND ESTATUS='" & Estatus & "' ORDER BY NOMBRE_CLIENTE"
        Else
            sql = "SELECT CODIGO_CLIENTE,NOMBRE_CLIENTE FROM CAT_CLIENTES  WHERE PLAZA='" & Usuario.Codigo_Plaza.ToString & "' AND NOMBRE_CLIENTE LIKE '" & Filtro.ToString & "%' AND ESTATUS='" & Estatus & "' ORDER BY NOMBRE_CLIENTE"
        End If
        Dim dA As New SqlDataAdapter(sql, Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltroCodigoCliente(ByVal Filtro As String, ByVal Estatus As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim sql As String = ""
        If Usuario.Codigo_Plaza = 1 Then 'Si inicio sesion en Matriz(plaza 1) debe poder ver todos los clientes
            sql = "SELECT CODIGO_CLIENTE,NOMBRE_CLIENTE FROM CAT_CLIENTES  WHERE CODIGO_CLIENTE LIKE '" & Filtro.ToString & "%' AND ESTATUS='" & Estatus & "' ORDER BY CODIGO_CLIENTE"
        Else
            sql = "SELECT CODIGO_CLIENTE,NOMBRE_CLIENTE FROM CAT_CLIENTES  WHERE CODIGO_ZONA='" & Usuario.Codigo_Plaza.ToString & "' AND CODIGO_CLIENTE LIKE '" & Filtro.ToString & "%' AND ESTATUS='" & Estatus & "' ORDER BY CODIGO_CLIENTE"
        End If
        Dim dA As New SqlDataAdapter(sql, Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltroCodigoCliente", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerEstados() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim ds As New SqlDataAdapter("SELECT CODIGO_ESTADO,NOMBRE_ESTADO FROM SIS_ESTADOS ORDER BY NOMBRE_ESTADO", Me._Conexion)
        Try
            ds.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerEstados", ex)
        Finally
            ds.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerEstadosParaCatalogoClientes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim ds As New SqlDataAdapter("SELECT CODIGO_ESTADO,NOMBRE_ESTADO FROM SIS_ESTADOS ORDER BY NOMBRE_ESTADO", Me._Conexion)
        Try
            ds.Fill(dTable)
            dTable.Rows.Add("", "")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerEstadosParaCatalogoClientes", ex)
        Finally
            ds.Dispose()
        End Try
        Return dTable
    End Function

    Public Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de clientes por código."
        f.sCampo = "CODIGO_CLIENTE"
        f.sOrder = "NOMBRE_CLIENTE"
        f.sTable = "CAT_CLIENTES"
        f.sQl = "SELECT CODIGO_CLIENTE,NOMBRE_CLIENTE FROM CAT_CLIENTES WHERE ESTATUS='A' AND "

        If Usuario.Codigo_Plaza <> 1 Then
            f.sQl = f.sQl & " PLAZA='" & Usuario.Codigo_Plaza.ToString & "' AND "
        End If

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
        f.Text = "Búsqueda de clientes por nombre."
        f.sCampo = "NOMBRE_CLIENTE"
        f.sOrder = "NOMBRE_CLIENTE"
        f.sTable = "CAT_CLIENTES"
        f.sQl = "SELECT CODIGO_CLIENTE,NOMBRE_CLIENTE FROM CAT_CLIENTES WHERE ESTATUS='A' AND "

        If Usuario.Codigo_Plaza <> 1 Then
            f.sQl = f.sQl & " PLAZA='" & Usuario.Codigo_Plaza.ToString & "' AND "
        End If

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

    Public Function BusquedaVisualPlaza() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de clientes por nombre."
        f.sCampo = "NOMBRE_CLIENTE"
        f.sOrder = "NOMBRE_CLIENTE"
        f.sTable = "CAT_CLIENTES"
        'f.sQl = "SELECT CODIGO_CLIENTE,NOMBRE_CLIENTE FROM CAT_CLIENTES WHERE ESTATUS='A' AND PLAZA='" & Usuario.Codigo_Plaza.ToString & "' AND "
        f.sQl = "SELECT CODIGO_CLIENTE,NOMBRE_CLIENTE,(CALLE + ' ' +NUMERO_EXTERIOR + ' ' + COLONIA) DIRECCION,(CIUDAD + ',' + ESTADO) CIUDAD FROM CAT_CLIENTES WHERE ESTATUS='A' AND PLAZA='" & _
        Usuario.Codigo_Plaza.ToString & "' AND "
        f.arrayWidthColumns = New Integer() {100, 400, 500, 300}

        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisualPlaza", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_PorDescripcionSinFiltroZona(Optional ByVal sCodigo_Tipo_Mercado As String = "") As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = "", sMercado As String = ""

        sMercado = sCodigo_Tipo_Mercado
        f.Text = "Búsqueda de clientes por nombre."
        f.sCampo = "NOMBRE_CLIENTE"
        f.sOrder = "NOMBRE_CLIENTE"
        f.sTable = "CAT_CLIENTES"
        If txtLEN(sMercado) = True And sMercado <> "T" Then
            sMercado = " AND CODIGO_TIPO_MERCADO='" & sMercado & "' "
        End If

        f.sQl = "SELECT CODIGO_CLIENTE,NOMBRE_CLIENTE FROM CAT_CLIENTES WHERE ESTATUS='A' " & sMercado & " AND"
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcionSinFiltroZona", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_PorDescripcionFiltradoZona(ByVal sCodigo_Zona As String) As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de clientes por nombre."
        f.sCampo = "NOMBRE_CLIENTE"
        f.sOrder = "NOMBRE_CLIENTE"
        f.sTable = "CAT_CLIENTES"
        f.sQl = "SELECT CODIGO_CLIENTE,NOMBRE_CLIENTE FROM CAT_CLIENTES WHERE ESTATUS='A' AND CODIGO_ZONA='" & sCodigo_Zona & "' AND "

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

    'Public Function BusquedaVisual_PorDescripcionMercado(ByVal sCodigoMercado As String) As String
    '    Dim f As New BusquedaVisual
    '    Dim Resultado As String = ""
    '    f.Text = "Búsqueda de clientes por Descripción."
    '    f.sCampo = "NOMBRE_CLIENTE"
    '    f.sOrder = "NOMBRE_CLIENTE"
    '    f.sTable = "CAT_CLIENTES"
    '    f.sQl = "SELECT CODIGO_CLIENTE,NOMBRE_CLIENTE FROM CAT_CLIENTES WHERE 1=1 AND CODIGO_CLIENTE like '" & sCodigoMercado & "%' AND"
    '    f.Inicia("")
    '    f.ShowDialog()
    '    Try
    '        If f.iRows > 0 Then
    '            Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
    '        End If
    '    Catch ex As Exception
    '        HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion", ex)
    '    End Try
    '    Return Resultado
    'End Function

    Public Function BusquedaVisual_PorDescripcionZona(ByVal sCodigo_Tipo_Mercado As String) As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = "", sMercado As String = ""

        sMercado = sCodigo_Tipo_Mercado
        f.Text = "Búsqueda de clientes por nombre."
        f.sCampo = "NOMBRE_CLIENTE"
        f.sOrder = "NOMBRE_CLIENTE"
        f.sTable = "CAT_CLIENTES"
        If sMercado <> "T" Then
            sMercado = " AND CODIGO_TIPO_MERCADO='" & sMercado & "' "
        End If

        f.sQl = "SELECT CODIGO_CLIENTE,NOMBRE_CLIENTE FROM CAT_CLIENTES WHERE ESTATUS='A' " & sMercado & " AND PLAZA=" & Usuario.Codigo_Plaza & " AND"

        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcionZona", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_PorDescripcionRegresandoRFC(Optional ByVal bValidaPlaza As Boolean = True) As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de clientes por Descripción."
        f.sCampo = "NOMBRE_CLIENTE"
        f.sOrder = "NOMBRE_CLIENTE"
        f.sTable = "CAT_CLIENTES"
        f.sQl = "SELECT RFC,NOMBRE_CLIENTE FROM CAT_CLIENTES WHERE 1=1 AND ESTATUS='A' " & IIf(bValidaPlaza = True, " AND PLAZA='" & Usuario.Codigo_Plaza.ToString & "'", "").ToString & " AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcionRegresandoRFC", ex)
        End Try
        Return Resultado
    End Function

    Public Function CodigoSiguiente(ByVal sCodigoTipoMercado As String) As String
        Dim iCliente As Integer, sCliente As String
        CodigoSiguiente = ""
        Dim Resultado As String = ""
        Try

            Dim CodigoCliente As New Class_find("SELECT CASE WHEN " & sCodigoTipoMercado & "='0001' THEN CODIGO_CLIENTES_EXPORTACION ELSE CODIGO_CLIENTES_NACIONAL END FROM SIS_PLAZAS WHERE CODIGO_PLAZA =" & Usuario.Codigo_Plaza.ToString)
            If txtLEN(CodigoCliente.Result1) = False Then
                MsgBox("No se encontró el siguiente código de cliente.", MsgBoxStyle.Exclamation, Me.Nombre_Catalogo)
                Exit Function
            End If

            iCliente = CInt(CodigoCliente.Result1.Substring(2))
            iCliente = iCliente + 1
            sCliente = "0000" + iCliente.ToString
            Resultado = CodigoCliente.Result1.Remove(2, 4) + sCliente.Substring(Len(sCliente) - 4)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
        End Try
        Return Resultado
    End Function

    Public Function EstablecerCuentaContableDolares() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_CUENTAS_GENERA_CUENTA_CONTABLE_CLIENTE_USD"

            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CODIGO_CLIENTE.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_CLIENTE", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._NOMBRE_CLIENTE.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._PLAZA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE", SqlDbType.NVarChar, 20) : sqlParametro.Value = ""

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "EstablecerCuentaContableDolares", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function EstablecerCuentaContableAnticipos() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_CUENTAS_GENERA_CUENTA_CONTABLE_CLIENTE_ANTICIPOS"

            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CODIGO_CLIENTE.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_CLIENTE", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._NOMBRE_CLIENTE.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._PLAZA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE", SqlDbType.NVarChar, 20) : sqlParametro.Value = ""

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "EstablecerCuentaContableAnticipos", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function ImportaClienteSucursal(ByVal ClienteOrigen As String, ByVal CodigoZonaDestino As String, ByVal Vendedor As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_CLIENTES_IMPORTA_CLIENTE_SUCURSAL"

            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE_ORIGEN", SqlDbType.NVarChar, 8) : sqlParametro.Value = ClienteOrigen
            sqlParametro = .Parameters.Add("@CODIGO_ZONA_DESTINO", SqlDbType.NVarChar, 4) : sqlParametro.Value = CodigoZonaDestino
            sqlParametro = .Parameters.Add("@CODIGO_VENDEDOR_DESTINO", SqlDbType.NVarChar, 3) : sqlParametro.Value = Vendedor

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "ImportaClienteSucursal", ex)
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
                HandleError(Me.Nombre_Catalogo, "Imprimir_Listado", ex)
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
