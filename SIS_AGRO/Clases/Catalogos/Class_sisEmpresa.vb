Imports System.Data.SqlClient
Imports System.Data
Public NotInheritable Class Class_sisEmpresa
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    'DATOS DEL SISTEMA
    Private _VERSION_AGROCONTROL As Integer

    'DATOS GENERALES DE LA EMPRESA
    Private _CODIGO_EMPRESA As Integer
    Private _Nombre_Empresa As String
    Private _Domicilio As String
    Private _Ciudad As String
    Private _Rfc As String
    Private _Telefono As String
    Private _Estado As String
    Private _CALLE As String
    Private _NUMERO_EXTERIOR As String
    Private _NUMERO_INTERIOR As String
    Private _COLONIA As String
    Private _LOCALIDAD As String
    Private _PAIS As String
    Private _CODIGO_POSTAL As String
    Private _CODIGO_COLONIA_SAT As String
    Private _CODIGO_LOCALIDAD_SAT As String
    Private _CODIGO_MUNICIPIO As String
    Private _CODIGO_ESTADO As String
    Private _CODIGO_PAIS_SAT As String
    Private _CURP As String

    Private _Decimales_Para_Redondear As Integer
    Private _DECIMALES_CONTABILIDAD As Integer
    Private _VALIDA_EXISTENCIAS_KITS_VENTAS As Boolean
    Private _DECIMALES_CANTIDAD As Integer
    Private _DECIMALES_PRECIO As Integer
    Private _CODIGO_FAMILIA As Integer
    Private _CODIGO_ALMACEN As Integer
    Private _CODIGO_LINEA As Integer
    Private _CODIGO_ARTICULO_NO_INVENTARIABLE_COMPRA_PROVEEDOR As String
    Private _CODIGO_ARTICULO_NO_INVENTARIABLE_COMPRA_ACREEDOR As String
    Private _CUENTA_CONTABLE_ALMACENES As String
    Private _DECIMALES_PESO_BULTOS As Integer
    Private _CUENTA_CONTABLE_CLIENTES_CONTRA_CUENTA_DOLARES As String

    Private _GTIN_BASE As String
    Private _CODIGO_EMPRESA_ASIGNADO_POR_MASTRONARDI As String

    Private _CODIGO_CONCEPTO_COSTO_PRODUCCION As String

    Private _CODIGO_TIPO_DOCUMENTO_SALIDA_EMPAQUE As String

    Private _CODIGO_FAMILIA_MATERIA_EMPAQUE As String

    Private _CUENTA_CONTABLE_MATERIA_EMPAQUE As String
    Private _CUENTA_CONTABLE_COSTOS_DIRECTOS_PRODUCCION As String

    Private _NUMERO_CLIENTE_BANCO As String
    Private _SUCURSAL_BANCO As String
    Private _NUMERO_CUENTA_BANCO As String

    Private _CUENTA_CONTABLE_PERDIDA_GANACIA_CAMBIARIA As String
    Private _CUENTA_CONTABLE_CONTRA_CUENTA_DOLARES As String
    Private _CUENTA_CONTABLE_PROVEEDORES_CONTRA_CUENTA_DOLARES As String

    Private _CODIGO_TAMAÑO_REZAGA As String
    Private _CODIGO_CONCEPTO_FLETE_EQUIPO As String

    'Facturacion Electronica
    Private _FELECTRONICA_ACTIVA As Boolean
    Private _RFC_VENTA_PUBLICO_GENERAL As String
    Private _FELECTRONICA_CARPETA_TRABAJO As String
    Private _FELECTRONICA_CADENA_ORIGINAL As String 'Se actualiza segun la cadena a usar
    Private _FELECTRONICA_KEY As String
    Private _FELECTRONICA_CER As String
    Private _FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA As String

    'CFD
    Private _CODIGO_REGIMEN_FISCAL As Integer
    Private _VERSION_ESQUEMA_CFD As String 'Se actualiza segun a esquema a utilizar

    'CFDi
    Private _FELECTRONICA_PFX As String
    Private _FELECTRONICA_CONTRASENIA_PFX As String
    Private _FELECTRONICA_USER_WS As String
    Private _FELECTRONICA_PASS_WS As String
    Private _FELECTRONICA_TIPO_CFD As String
    Private _FELECTRONICA_CCE_HABILITADO As Boolean

    'AddendaSoriana
    Private _CODIGO_PROVEDOR_SORIANA As String
    Private _CODIGO_CLIENTE_SORIANA As String

    Private _CODIGO_PRODUCTOR_SALIDA_INVENTARIABLE_AUTOMATICA As String
    Private _CODIGO_PRODUCTOR_HAPPY As String
    Private _CODIGO_TIPO_DOCUMENTO_TRANSFERENCIA_EMPAQUE As String
    Private _CODIGO_CONCEPTO_PAGO_CXP_DEFAULT As String

#End Region

#Region "Campos ligados a la tabla"
    Private _Codigo_Temporada_Actual As Integer
    Private _Estatus_Temporada As String
    Private _Num_Semana_Actual As Integer
    Private _Id_semana_actual As Integer
    Private _Id_Dia_Actual As Integer
    Private _Fecha_Dia_Actual As Date
    Private _Tipo_Contabilidad As String
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
    Private _Conexion As String
    Private _ConexionDBEmpresas As String
    Private _QuerySelect As String
    Private _QueryOrder As String

    Private _BaseDatos As String
    Private _User As String
    Private _Pass As String
    Private _Servidor As String
#End Region

    '#Region "Clase Detalle"
    '    Public oSisEmpresaNomina As Class_SisEmpresaNomina
    '#End Region
#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    'DATOS DEL SISTEMA
    Public ReadOnly Property VERSION_AGROCONTROL() As Integer
        Get
            Return Me._VERSION_AGROCONTROL
        End Get
    End Property

    'DATOS GENERALES DE LA EMPRESA PARA REPORTES Y FACTURACION
    Public ReadOnly Property CODIGO_EMPRESA() As Integer
        Get
            Return Me._CODIGO_EMPRESA
        End Get
    End Property
    Public Property NOMBRE_EMPRESA() As String
        Get
            Return _Nombre_Empresa
        End Get
        Set(ByVal value As String)
            Me._Nombre_Empresa = value
        End Set
    End Property
    Public Property DOMICILIO() As String
        Get
            Return _Domicilio
        End Get
        Set(ByVal value As String)
            Me._Domicilio = value
        End Set
    End Property
    Public Property CIUDAD() As String
        Get
            Return _Ciudad
        End Get
        Set(ByVal value As String)
            Me._Ciudad = value
        End Set
    End Property
    Public Property RFC() As String
        Get
            Return _Rfc
        End Get
        Set(ByVal value As String)
            Me._Rfc = value
        End Set
    End Property
    Public Property TELEFONO() As String
        Get
            Return _Telefono
        End Get
        Set(ByVal value As String)
            Me._Telefono = value
        End Set
    End Property
    Public ReadOnly Property ESTADO() As String
        Get
            Return Me._Estado
        End Get
    End Property
    Public ReadOnly Property CALLE() As String
        Get
            Return Me._CALLE
        End Get
    End Property
    Public ReadOnly Property NUMERO_EXTERIOR() As String
        Get
            Return Me._NUMERO_EXTERIOR
        End Get
    End Property
    Public ReadOnly Property NUMERO_INTERIOR() As String
        Get
            Return Me._NUMERO_INTERIOR
        End Get
    End Property
    Public ReadOnly Property COLONIA() As String
        Get
            Return Me._COLONIA
        End Get
    End Property
    Public ReadOnly Property LOCALIDAD() As String
        Get
            Return Me._LOCALIDAD
        End Get
    End Property
    Public ReadOnly Property PAIS() As String
        Get
            Return Me._PAIS
        End Get
    End Property
    Public ReadOnly Property CODIGO_POSTAL() As String
        Get
            Return Me._CODIGO_POSTAL
        End Get
    End Property
    Public ReadOnly Property CODIGO_COLONIA_SAT() As String
        Get
            Return Me._CODIGO_COLONIA_SAT
        End Get
    End Property

    Public ReadOnly Property CODIGO_LOCALIDAD_SAT() As String
        Get
            Return Me._CODIGO_LOCALIDAD_SAT
        End Get
    End Property

    Public ReadOnly Property CODIGO_MUNICIPIO() As String
        Get
            Return Me._CODIGO_MUNICIPIO
        End Get
    End Property

    Public ReadOnly Property CODIGO_ESTADO() As String
        Get
            Return Me._CODIGO_ESTADO
        End Get
    End Property

    Public ReadOnly Property CODIGO_PAIS_SAT() As String
        Get
            Return Me._CODIGO_PAIS_SAT
        End Get
    End Property

    Public ReadOnly Property CURP() As String
        Get
            Return Me._CURP
        End Get
    End Property

    Public Property DECIMALES_PARA_REDONDEAR() As Integer
        Get
            Return _Decimales_Para_Redondear
        End Get
        Set(ByVal value As Integer)
            Me._Decimales_Para_Redondear = value
        End Set
    End Property

    Public ReadOnly Property DECIMALES_CONTABILIDAD() As Integer
        Get
            Return Me._DECIMALES_CONTABILIDAD
        End Get
    End Property

    Public ReadOnly Property DECIMALES_PRECIO() As Integer
        Get
            Return Me._DECIMALES_PRECIO
        End Get
    End Property

    Public ReadOnly Property DECIMALES_CANTIDAD() As Integer
        Get
            Return Me._DECIMALES_PRECIO
        End Get
    End Property

    Public ReadOnly Property VALIDA_EXISTENCIAS_KITS_VENTAS() As Boolean
        Get
            Return Me._VALIDA_EXISTENCIAS_KITS_VENTAS
        End Get
    End Property

    Public ReadOnly Property CODIGO_FAMILIA() As Integer
        Get
            Return Me._CODIGO_FAMILIA
        End Get
    End Property

    Public ReadOnly Property CODIGO_ALMACEN() As Integer
        Get
            Return Me._CODIGO_ALMACEN
        End Get
    End Property

    Public ReadOnly Property CODIGO_LINEA() As String
        Get
            Return Me._CODIGO_LINEA
        End Get
    End Property

    Public ReadOnly Property CODIGO_ARTICULO_NO_INVENTARIABLE_COMPRA_PROVEEDOR() As String
        Get
            Return Me._CODIGO_ARTICULO_NO_INVENTARIABLE_COMPRA_PROVEEDOR
        End Get
    End Property

    Public ReadOnly Property CODIGO_ARTICULO_NO_INVENTARIABLE_COMPRA_ACREEDOR() As String
        Get
            Return Me._CODIGO_ARTICULO_NO_INVENTARIABLE_COMPRA_ACREEDOR
        End Get
    End Property

    Public Property CUENTA_CONTABLE_ALMACENES() As String
        Get
            Return _CUENTA_CONTABLE_ALMACENES
        End Get
        Set(ByVal value As String)
            Me._CUENTA_CONTABLE_ALMACENES = value
        End Set
    End Property

    Public ReadOnly Property DECIMALES_PESO_BULTOS() As Integer
        Get
            Return Me._DECIMALES_PESO_BULTOS
        End Get
    End Property

    Public Property CUENTA_CONTABLE_CLIENTES_CONTRA_CUENTA_DOLARES() As String
        Get
            Return Me._CUENTA_CONTABLE_CLIENTES_CONTRA_CUENTA_DOLARES
        End Get
        Set(ByVal value As String)
            Me._CUENTA_CONTABLE_CLIENTES_CONTRA_CUENTA_DOLARES = value
        End Set
    End Property

    Public ReadOnly Property GTIN_BASE() As String
        Get
            Return Me._GTIN_BASE
        End Get
    End Property

    Public ReadOnly Property CODIGO_EMPRESA_ASIGNADO_POR_MASTRONARDI() As String
        Get
            Return Me._CODIGO_EMPRESA_ASIGNADO_POR_MASTRONARDI
        End Get
    End Property

    Public Property CODIGO_CONCEPTO_COSTO_PRODUCCION() As String
        Get
            Return Me._CODIGO_CONCEPTO_COSTO_PRODUCCION
        End Get
        Set(ByVal value As String)
            Me._CODIGO_CONCEPTO_COSTO_PRODUCCION = value
        End Set
    End Property

    Public ReadOnly Property CODIGO_TIPO_DOCUMENTO_SALIDA_EMPAQUE() As String
        Get
            Return Me._CODIGO_TIPO_DOCUMENTO_SALIDA_EMPAQUE
        End Get
    End Property

    Public ReadOnly Property CODIGO_FAMILIA_MATERIA_EMPAQUE() As String
        Get
            Return Me._CODIGO_FAMILIA_MATERIA_EMPAQUE
        End Get
    End Property

    Public ReadOnly Property CUENTA_CONTABLE_MATERIA_EMPAQUE() As String
        Get
            Return Me._CUENTA_CONTABLE_MATERIA_EMPAQUE
        End Get
    End Property

    Public ReadOnly Property CUENTA_CONTABLE_COSTOS_DIRECTOS_PRODUCCION() As String
        Get
            Return Me._CUENTA_CONTABLE_COSTOS_DIRECTOS_PRODUCCION
        End Get
    End Property

    Public ReadOnly Property CUENTA_CONTABLE_PERDIDA_GANACIA_CAMBIARIA() As String
        Get
            Return Me._CUENTA_CONTABLE_PERDIDA_GANACIA_CAMBIARIA
        End Get
    End Property

    Public ReadOnly Property CUENTA_CONTABLE_CONTRA_CUENTA_DOLARES() As String
        Get
            Return Me._CUENTA_CONTABLE_CONTRA_CUENTA_DOLARES
        End Get
    End Property

    Public ReadOnly Property CUENTA_CONTABLE_PROVEEDORES_CONTRA_CUENTA_DOLARES() As String
        Get
            Return Me._CUENTA_CONTABLE_PROVEEDORES_CONTRA_CUENTA_DOLARES
        End Get
    End Property

    Public ReadOnly Property NUMERO_CLIENTE_BANCO() As String
        Get
            Return Me._NUMERO_CLIENTE_BANCO
        End Get
    End Property

    Public ReadOnly Property SUCURSAL_BANCO() As String
        Get
            Return Me._SUCURSAL_BANCO
        End Get
    End Property

    Public ReadOnly Property NUMERO_CUENTA_BANCO() As String
        Get
            Return Me._NUMERO_CUENTA_BANCO
        End Get
    End Property

    Public ReadOnly Property CODIGO_TAMAÑO_REZAGA() As String
        Get
            Return Me._CODIGO_TAMAÑO_REZAGA
        End Get
    End Property

    Public ReadOnly Property CODIGO_CONCEPTO_FLETE_EQUIPO() As String
        Get
            Return Me._CODIGO_CONCEPTO_FLETE_EQUIPO
        End Get
    End Property

    Public ReadOnly Property CODIGO_PRODUCTOR_SALIDA_INVENTARIABLE_AUTOMATICA() As String
        Get
            Return Me._CODIGO_PRODUCTOR_SALIDA_INVENTARIABLE_AUTOMATICA
        End Get
    End Property

    'ADDENDA
    Public ReadOnly Property CODIGO_PROVEDOR_SORIANA() As String
        Get
            Return Me._CODIGO_PROVEDOR_SORIANA
        End Get
    End Property

    Public ReadOnly Property CODIGO_CLIENTE_SORIANA() As String
        Get
            Return Me._CODIGO_CLIENTE_SORIANA
        End Get
    End Property

    'FACTURACION ELECTRONICA
    Public ReadOnly Property FELECTRONICA_ACTIVA() As Boolean
        Get
            Return Me._FELECTRONICA_ACTIVA
        End Get
    End Property
    Public ReadOnly Property RFC_VENTA_PUBLICO_GENERAL() As String
        Get
            Return Me._RFC_VENTA_PUBLICO_GENERAL
        End Get
    End Property
    Public ReadOnly Property FELECTRONICA_CARPETA_TRABAJO() As String
        Get
            Return Me._FELECTRONICA_CARPETA_TRABAJO
        End Get
    End Property
    Public ReadOnly Property FELECTRONICA_CADENA_ORIGINAL() As String
        Get
            Return Me._FELECTRONICA_CADENA_ORIGINAL
        End Get
    End Property
    Public ReadOnly Property FELECTRONICA_KEY() As String
        Get
            Return Me._FELECTRONICA_KEY
        End Get
    End Property
    Public ReadOnly Property FELECTRONICA_CER() As String
        Get
            Return Me._FELECTRONICA_CER
        End Get
    End Property
    Public Property FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA() As String
        Get
            Return Me._FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA
        End Get
        Set(ByVal value As String)
            Me._FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA = value
        End Set
    End Property

    'CFD
    Public ReadOnly Property CODIGO_REGIMEN_FISCAL() As Integer
        Get
            Return Me._CODIGO_REGIMEN_FISCAL
        End Get
    End Property
    Public ReadOnly Property VERSION_ESQUEMA_CFD() As String
        Get
            Return Me._VERSION_ESQUEMA_CFD
        End Get
    End Property

    'CFDi
    Public ReadOnly Property FELECTRONICA_PFX() As String
        Get
            Return Me._FELECTRONICA_PFX
        End Get
    End Property
    Public ReadOnly Property FELECTRONICA_CONTRASENIA_PFX() As String
        Get
            Return Me._FELECTRONICA_CONTRASENIA_PFX
        End Get
    End Property
    Public ReadOnly Property FELECTRONICA_USER_WS() As String
        Get
            Return Me._FELECTRONICA_USER_WS
        End Get
    End Property
    Public ReadOnly Property FELECTRONICA_PASS_WS() As String
        Get
            Return Me._FELECTRONICA_PASS_WS
        End Get
    End Property
    Public ReadOnly Property FELECTRONICA_TIPO_CFD() As String
        Get
            Return Me._FELECTRONICA_TIPO_CFD
        End Get
    End Property

    Public ReadOnly Property FELECTRONICA_CCE_HABILITADO() As Boolean
        Get
            Return Me._FELECTRONICA_CCE_HABILITADO
        End Get
    End Property

    Public ReadOnly Property CODIGO_PRODUCTOR_HAPPY() As String
        Get
            Return Me._CODIGO_PRODUCTOR_HAPPY
        End Get
    End Property

    Public ReadOnly Property CODIGO_TIPO_DOCUMENTO_TRANSFERENCIA_EMPAQUE() As String
        Get
            Return Me._CODIGO_TIPO_DOCUMENTO_TRANSFERENCIA_EMPAQUE
        End Get
    End Property

    Public ReadOnly Property CODIGO_CONCEPTO_PAGO_CXP_DEFAULT() As String
        Get
            Return Me._CODIGO_CONCEPTO_PAGO_CXP_DEFAULT
        End Get
    End Property


#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public Property Tipo_Contabilidad() As String
        Get
            Return _Tipo_Contabilidad
        End Get
        Set(ByVal value As String)
            _Tipo_Contabilidad = value
        End Set
    End Property
    Public ReadOnly Property CODIGO_ESTADO_SAT() As String
        Get
            Return Me._CODIGO_ESTADO_SAT
        End Get
    End Property

    Public ReadOnly Property CODIGO_MUNICIPIO_SAT() As String
        Get
            Return Me._CODIGO_MUNICIPIO_SAT
        End Get
    End Property

#End Region

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

#End Region

#Region "Propiedades Campos de sistema"

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

    Public ReadOnly Property conexion() As String
        Get
            Return _Conexion
        End Get
    End Property

    Public ReadOnly Property ConexionDBEmpresas() As String
        Get
            Return _ConexionDBEmpresas
        End Get
    End Property

    Public Property BaseDatos() As String
        Get
            Return _BaseDatos
        End Get
        Set(ByVal value As String)
            _BaseDatos = value
        End Set
    End Property

    Public Property User() As String
        Get
            Return _User
        End Get
        Set(ByVal value As String)
            _User = value
        End Set
    End Property

    Public Property Pass() As String
        Get
            Return _Pass
        End Get
        Set(ByVal value As String)
            _Pass = value
        End Set
    End Property

    Public Property Servidor() As String
        Get
            Return _Servidor
        End Get
        Set(ByVal value As String)
            _Servidor = value
        End Set
    End Property

    Public Property Codigo_Temporada_Actual() As Integer
        Get
            Return _Codigo_Temporada_Actual
        End Get
        Set(ByVal value As Integer)
            _Codigo_Temporada_Actual = value
        End Set
    End Property

    Public Property Estatus_Temporada() As String
        Get
            Return _Estatus_Temporada
        End Get
        Set(ByVal value As String)
            _Estatus_Temporada = value
        End Set
    End Property

    Public Property Num_Semana_Actual() As Integer
        Get
            Return _Num_Semana_Actual
        End Get
        Set(ByVal value As Integer)
            _Num_Semana_Actual = value
        End Set
    End Property

    Public Property Id_semana_actual() As Integer
        Get
            Return _Id_semana_actual
        End Get
        Set(ByVal value As Integer)
            _Id_semana_actual = value
        End Set
    End Property

    Public Property Id_Dia_Actual() As Integer
        Get
            Return _Id_Dia_Actual
        End Get
        Set(ByVal value As Integer)
            _Id_Dia_Actual = value
        End Set
    End Property

    Public Property Fecha_Dia_Actual() As Date
        Get
            Return _Fecha_Dia_Actual
        End Get
        Set(ByVal value As Date)
            _Fecha_Dia_Actual = value
        End Set
    End Property

#End Region

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_sisEmpresa"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New() 'Utilizado unicamente para la configuración de la empresa.
        If Not IsNothing(Empresa_Sistema) Then
            Me._Nombre_Catalogo = Empresa_Sistema.Nombre_Catalogo
            Me._Nombre_Reporte = "RPT_SIS_EMPRESA.rpt"
            Me._Conexion = Empresa_Sistema.conexion
            Me._QuerySelect = "Select * From SIS_EMPRESA"
            Me._QueryOrder = " Order by NOMBRE_EMP"

            'Me.oSisEmpresaNomina = New Class_SisEmpresaNomina
        End If
    End Sub

    Public Sub New(ByVal sEmpresa As String, ByVal sBaseDatos As String, ByVal sServidor As String, ByVal sUser As String, ByVal sPass As String)
        'Utilizado para arrancar la aplicación
        _Nombre_Empresa = sEmpresa
        _BaseDatos = sBaseDatos
        _Servidor = sServidor
        _User = sUser
        _Pass = sPass

        Me._Nombre_Catalogo = "sis_Empresa"
        Me._Conexion = "Data Source=" & sServidor & ";Initial Catalog=" & sBaseDatos & ";" & "User ID=" & sUser & ";Password=" & sPass
        Me._ConexionDBEmpresas = "Data Source=" & sServidor & ";Initial Catalog=BS_EMPRESAS;" & "User ID=" & sUser & ";Password=" & sPass
        Me._QuerySelect = "Select * From SIS_EMPRESA"
        Me._QueryOrder = " Order by NOMBRE_EMPRESA"

        If Not Me.Consultar Then
            Running = True
            MsgBox("No es posible conectarse al servidor. Contácte a su administrador de sistemas.", MsgBoxStyle.Critical)
            Finaliza(False)
        End If

#If Not Debug Then
        'If Me._VERSION_AGRINET <> My.Application.Info.Version.Revision Then
        '    MsgBox("La versión no esta actualizada.", MsgBoxStyle.Exclamation, Me.Nombre_Catalogo)
        '    Finaliza(False)
        '    Exit Sub
        'End If
#End If

        If Not Crea_DSN() Then
            MsgBox("El sistema no pudo crear el DSN , por lo tanto no podra imprimir reportes. Avise al departamento de sistemas", vbExclamation, "DSN")
        End If

        Loginfo = New CrystalDecisions.Shared.ConnectionInfo
        Loginfo.ServerName = DSNBaseOperativa
        Loginfo.DatabaseName = My.Settings.BaseDatos
        Loginfo.UserID = sUser
        Loginfo.Password = sPass
        Running = True

        'Me.oSisEmpresaNomina = New Class_SisEmpresaNomina(Me._Conexion)
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Overrides Function Actualizar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        Dim cn As New SqlConnection(conexion)
        With cmd
            .Connection = cn
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_ACTUALIZA_EMPRESA"
            sqlParametro = .Parameters.Add("@NOMBRE_EMP", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._Nombre_Empresa.ToUpper
            sqlParametro = .Parameters.Add("@DOM", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._Domicilio.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_CIUDAD", SqlDbType.SmallInt) : sqlParametro.Value = Me._Ciudad
            sqlParametro = .Parameters.Add("@RFC", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._Rfc.ToUpper
            sqlParametro = .Parameters.Add("@TEL", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._Telefono.ToUpper
            sqlParametro = .Parameters.Add("@VERSION", SqlDbType.SmallInt) : sqlParametro.Value = Me._VERSION_AGROCONTROL

            Try
                cn.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Actualizar", ex)
            Finally
                cn.Close()
                cn.Dispose()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try

        End With
        Return bResultado
    End Function

    Public Overrides Function Insertar() As Boolean

    End Function

    Public Overrides Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cn As New SqlConnection(_Conexion)
        Dim cmd As New SqlCommand("SELECT S.*,E.CODIGO_ESTADO_SAT,M.CODIGO_MUNICIPIO_SAT " & _
                                  "FROM SIS_EMPRESA S " & _
                                  "LEFT JOIN SIS_ESTADOS E ON(S.CODIGO_ESTADO=E.CODIGO_ESTADO) " & _
                                  "LEFT JOIN CAT_MUNICIPIOS M ON(S.CODIGO_MUNICIPIO=M.CODIGO_MUNICIPIO)", cn)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                cn.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_EMPRESA = CInt(dReader("CODIGO_EMPRESA"))
                    Me._Nombre_Empresa = "" & dReader("NOMBRE_EMPRESA").ToString
                    Me._Domicilio = "" & dReader("DOMICILIO").ToString
                    Me._Ciudad = "" & dReader("CIUDAD").ToString
                    Me._Rfc = "" & dReader("RFC").ToString
                    Me._Telefono = "" & dReader("TELEFONO").ToString
                    Me._Estado = "" & dReader("ESTADO").ToString
                    Me.Tipo_Contabilidad = "" & dReader("TIPO_CONTABILIDAD").ToString
                    Me._DECIMALES_CONTABILIDAD = CInt(dReader("DECIMALES_CONTABILIDAD"))
                    Me._DECIMALES_CANTIDAD = dReader("DECIMALES_CANTIDAD")
                    Me._DECIMALES_PRECIO = dReader("DECIMALES_PRECIO")
                    Me._CODIGO_ALMACEN = "" & dReader("CODIGO_ALMACEN").ToString
                    Me._CODIGO_FAMILIA = "" & dReader("CODIGO_FAMILIA").ToString
                    Me._CODIGO_LINEA = "" & dReader("CODIGO_LINEA").ToString
                    Me._CODIGO_ARTICULO_NO_INVENTARIABLE_COMPRA_ACREEDOR = "" & dReader("CODIGO_ARTICULO_NO_INVENTARIABLE_COMPRA_ACREEDOR").ToString
                    Me._CODIGO_ARTICULO_NO_INVENTARIABLE_COMPRA_PROVEEDOR = "" & dReader("CODIGO_ARTICULO_NO_INVENTARIABLE_COMPRA_PROVEEDOR").ToString
                    Me._VERSION_AGROCONTROL = dReader("VERSION_AGRINET")
                    Me._CUENTA_CONTABLE_ALMACENES = dReader("CUENTA_CONTABLE_ALMACENES")
                    Me._DECIMALES_PESO_BULTOS = CInt(dReader("DECIMALES_PESO_BULTOS"))
                    Me._CUENTA_CONTABLE_CLIENTES_CONTRA_CUENTA_DOLARES = dReader("CUENTA_CONTABLE_CLIENTES_CONTRA_CUENTA_DOLARES")

                    Me._RFC_VENTA_PUBLICO_GENERAL = dReader("RFC_VENTA_PUBLICO_GENERAL")
                    Me._CALLE = dReader("CALLE")
                    Me._NUMERO_EXTERIOR = dReader("NUMERO_EXTERIOR")
                    Me._NUMERO_INTERIOR = dReader("NUMERO_INTERIOR")
                    Me._COLONIA = dReader("COLONIA")
                    Me._LOCALIDAD = dReader("LOCALIDAD")
                    Me._PAIS = dReader("PAIS")
                    Me._CODIGO_POSTAL = dReader("CODIGO_POSTAL")
                    Me._CODIGO_COLONIA_SAT = "" & dReader("CODIGO_COLONIA_SAT")
                    Me._CODIGO_LOCALIDAD_SAT = "" & dReader("CODIGO_LOCALIDAD_SAT")
                    Me._CODIGO_MUNICIPIO = "" & dReader("CODIGO_MUNICIPIO")
                    Me._CODIGO_ESTADO = "" & dReader("CODIGO_ESTADO")
                    Me._CODIGO_PAIS_SAT = "" & dReader("CODIGO_PAIS_SAT")
                    Me._CURP = "" & dReader("CURP")

                    Me._CODIGO_ESTADO_SAT = dReader("CODIGO_ESTADO_SAT")
                    Me._CODIGO_MUNICIPIO_SAT = dReader("CODIGO_MUNICIPIO_SAT")

                    Me._GTIN_BASE = "" & dReader("GTIN_BASE").ToString
                    Me._CODIGO_EMPRESA_ASIGNADO_POR_MASTRONARDI = "" & dReader("CODIGO_EMPRESA_ASIGNADO_POR_MASTRONARDI").ToString
                    Me._CODIGO_CONCEPTO_COSTO_PRODUCCION = "" & dReader("CODIGO_CONCEPTO_COSTO_PRODUCCION").ToString
                    Me._CODIGO_TIPO_DOCUMENTO_SALIDA_EMPAQUE = "" & dReader("CODIGO_TIPO_DOCUMENTO_SALIDA_EMPAQUE").ToString
                    Me._CODIGO_FAMILIA_MATERIA_EMPAQUE = "" & dReader("CODIGO_FAMILIA_MATERIA_EMPAQUE").ToString
                    'Me._CUENTA_CONTABLE_MATERIA_EMPAQUE = "0002" & dReader("CUENTA_CONTABLE_MATERIA_EMPAQUE").ToString
                    Me._CUENTA_CONTABLE_COSTOS_DIRECTOS_PRODUCCION = "" & dReader("CUENTA_CONTABLE_COSTOS_DIRECTOS_PRODUCCION").ToString
                    Me._CUENTA_CONTABLE_PERDIDA_GANACIA_CAMBIARIA = "" & dReader("CUENTA_CONTABLE_PERDIDA_GANACIA_CAMBIARIA").ToString
                    Me._CUENTA_CONTABLE_CONTRA_CUENTA_DOLARES = "" & dReader("CUENTA_CONTABLE_CONTRA_CUENTA_DOLARES").ToString
                    Me._CUENTA_CONTABLE_PROVEEDORES_CONTRA_CUENTA_DOLARES = "" & dReader("CUENTA_CONTABLE_PROVEEDORES_CONTRA_CUENTA_DOLARES").ToString

                    Me._CODIGO_REGIMEN_FISCAL = CInt(dReader("CODIGO_REGIMEN_FISCAL"))
                    Me._VERSION_ESQUEMA_CFD = "" & dReader("VERSION_ESQUEMA_CFD").ToString
                    Me._NUMERO_CLIENTE_BANCO = "" & dReader("NUMERO_CLIENTE_BANCO").ToString
                    Me._SUCURSAL_BANCO = "" & dReader("SUCURSAL_BANCO").ToString
                    Me._NUMERO_CUENTA_BANCO = "" & dReader("NUMERO_CUENTA_BANCO").ToString
                    Me._CODIGO_TAMAÑO_REZAGA = "" & dReader("CODIGO_TAMAÑO_REZAGA").ToString
                    'Me._CODIGO_CONCEPTO_FLETE_EQUIPO = "" & dReader("CODIGO_CONCEPTO_FLETE_EQUIPO").ToString
                    Me._CODIGO_PROVEDOR_SORIANA = "" & dReader("CODIGO_PROVEDOR_SORIANA").ToString
                    Me._CODIGO_CLIENTE_SORIANA = "" & dReader("CODIGO_CLIENTE_SORIANA").ToString
                    Me._FELECTRONICA_ACTIVA = dReader("FELECTRONICA_ACTIVA")
                    Me._FELECTRONICA_CARPETA_TRABAJO = dReader("FELECTRONICA_CARPETA_TRABAJO")
                    Me._FELECTRONICA_CADENA_ORIGINAL = dReader("FELECTRONICA_CADENA_ORIGINAL")
                    Me._FELECTRONICA_KEY = dReader("FELECTRONICA_KEY")
                    Me._FELECTRONICA_CER = dReader("FELECTRONICA_CER")
                    Me._FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA = IIf(txtLEN("" & dReader("FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA")) = True, Decrypt("" & dReader("FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA"), "r7"), "")
                    Me._FELECTRONICA_PFX = "" & dReader("FELECTRONICA_PFX").ToString
                    Me._FELECTRONICA_CONTRASENIA_PFX = "" & dReader("FELECTRONICA_CONTRASENIA_PFX").ToString
                    Me._FELECTRONICA_USER_WS = "" & dReader("FELECTRONICA_USER_WS").ToString
                    Me._FELECTRONICA_PASS_WS = "" & dReader("FELECTRONICA_PASS_WS").ToString
                    Me._FELECTRONICA_TIPO_CFD = "" & dReader("FELECTRONICA_TIPO_CFD").ToString
                    Me._FELECTRONICA_CCE_HABILITADO = CBool(dReader("FELECTRONICA_CCE_HABILITADO").ToString)

                    Me._CODIGO_PRODUCTOR_SALIDA_INVENTARIABLE_AUTOMATICA = "" & dReader("CODIGO_PRODUCTOR_SALIDA_INVENTARIABLE_AUTOMATICA").ToString
                    Me._CODIGO_PRODUCTOR_HAPPY = "" & dReader("CODIGO_PRODUCTOR_HAPPY").ToString
                    Me._CODIGO_TIPO_DOCUMENTO_TRANSFERENCIA_EMPAQUE = "" & dReader("CODIGO_TIPO_DOCUMENTO_TRANSFERENCIA_EMPAQUE").ToString
                    Me._CODIGO_CONCEPTO_PAGO_CXP_DEFAULT = "" & dReader("CODIGO_CONCEPTO_PAGO_CXP_DEFAULT").ToString

                    dReader.Close()
                    bResultado = True
                End If

            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "Consultar", ex)
            Finally
                cmd.Dispose()
                cn.Close()
                cn.Dispose()
            End Try
        End With

        Return bResultado
    End Function

    Public Overrides Function ObtenerElementos() As DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter(Me._QuerySelect, Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim Resultado As String = ""
        Return Resultado
    End Function

    Public Overrides Function BusquedaVisual_PorDescripcion() As String
        Dim Resultado As String = ""
        Return Resultado
    End Function

    'Private Function DatosTipoContabilidad() As String
    '    Dim Conexion As New SqlConnection
    '    Conexion.ConnectionString = Empresa_Sistema.conexion
    '    Dim cmd As New SqlCommand("SELECT TIPO_CONTABILIDAD FROM CON_EJERCICIOS WHERE ID_CON_EJERCICIO='" & Empresa_Sistema.ID_CON_EJERCICIO & "'", conexion)
    '    Dim dReader As SqlDataReader
    '    With cmd
    '        .CommandTimeout = 0
    '        .CommandType = CommandType.Text
    '        Try
    '            Conexion.Open()
    '            dReader = .ExecuteReader()
    '            If dReader.Read Then

    '                Return CType(dReader("TIPO_CONTABILIDAD"), String)
    '            Else
    '                MsgBox("El ejercicio no cuenta con tipo de contabilidad", MsgBoxStyle.Critical, "Busqueda de Ejercicio")
    '            End If
    '            dReader.Close()
    '        Catch ex As Exception
    '            HandleError("Trae los datos de Ejecicios", "Consultar", ex)

    '        Finally
    '            Conexion.Close()
    '            cmd.Dispose()
    '        End Try
    '    End With
    '    Return CType(("TIPO_CONTABILIDAD"), String)
    'End Function

    Public Function ObtenDocumentosSinTimbrar() As DataTable
        Dim dTable As New DataTable 'AND LEN(VERSION_ESQUEMA_XML)=0 
        Dim da As New SqlDataAdapter("SELECT FOLIO_VENTA FOLIO,CODIGO_DOCUMENTO TIPO,FECHA_SERVIDOR,'NO ESTA TIMBRADO' PROBLEMA,case when (72-DATEDIFF(HOUR,FECHA_SERVIDOR, GETDATE()))>0 then 72-DATEDIFF(HOUR,FECHA_SERVIDOR, GETDATE()) else 0 end TIEMPO_RESTANTE " & _
                                               "FROM VENTA_GLOBAL WHERE ES_FACTURA_ELECTRONICA='1' AND TIMBRADO_DESCARTADO='0' AND FECHA_SERVIDOR>'2013-24-12' AND ESTATUS_VENTA='A' AND LEN(FOLIO_FISCAL_SAT)=0 AND LEN(SELLO_SAT)=0" & _
                                               "UNION ALL " & _
                                               "SELECT FOLIO_DESCUENTO FOLIO,'NCG_CXC' + CAST(CODIGO_PLAZA AS NVARCHAR) TIPO,FECHA_SERVIDOR,'NO ESTA TIMBRADO' PROBLEMA,case when (72-DATEDIFF(HOUR,FECHA_SERVIDOR, GETDATE()))>0 then 72-DATEDIFF(HOUR,FECHA_SERVIDOR, GETDATE()) else 0 end TIEMPO_RESTANTE " & _
                                               "FROM CXC_DESCUENTOS_GLOBAL WHERE ES_COMPROBANTE_ELECTRONICO='1' AND TIMBRADO_DESCARTADO='0' AND FECHA_SERVIDOR>'2013-24-12' AND ESTATUS_DESCUENTO='A'  AND LEN(FOLIO_FISCAL_SAT)=0 AND LEN(SELLO_SAT)=0", Me._Conexion)
        Try
            da.Fill(dTable)

        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenDocumentosSinTimbrar", ex)
        Finally
            da.Dispose()
        End Try

        Return dTable
    End Function

    Public Function ObtenDocumentosCanceladosSinTimbrar() As DataTable
        Dim dTable As New DataTable 'AND LEN(VERSION_ESQUEMA_XML)=0 
        Dim da As New SqlDataAdapter("SELECT FOLIO_VENTA FOLIO,'FACTURA' TIPO,FECHA_SERVIDOR,'NO ESTA TIMBRADO' PROBLEMA,case when (72-DATEDIFF(HOUR,FECHA_SERVIDOR, GETDATE()))>0 then 72-DATEDIFF(HOUR,FECHA_SERVIDOR, GETDATE()) else 0 end TIEMPO_RESTANTE " & _
                                               "FROM VENTA_GLOBAL WHERE ES_FACTURA_ELECTRONICA='1' AND TIMBRADO_DESCARTADO='0' AND FECHA_SERVIDOR>'2013-24-12'   AND ESTATUS_VENTA='C' AND ESTATUS_CANCELACION_CFDI='0' " & _
                                               "UNION ALL " & _
                                               "SELECT FOLIO_DESCUENTO FOLIO,'NOTA DE CREDITO' TIPO,FECHA_SERVIDOR,'NO ESTA TIMBRADO' PROBLEMA,case when (72-DATEDIFF(HOUR,FECHA_SERVIDOR, GETDATE()))>0 then 72-DATEDIFF(HOUR,FECHA_SERVIDOR, GETDATE()) else 0 end TIEMPO_RESTANTE " & _
                                               "FROM CXC_DESCUENTOS_GLOBAL WHERE ES_COMPROBANTE_ELECTRONICO='1' AND TIMBRADO_DESCARTADO='0' AND FECHA_SERVIDOR>'2013-24-12' AND ESTATUS_DESCUENTO='C' AND ESTATUS_CANCELACION_CFDI='0' ", Me._Conexion)
        Try
            da.Fill(dTable)

        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenDocumentosSinTimbrar", ex)
        Finally
            da.Dispose()
        End Try

        Return dTable
    End Function
#End Region

End Class

