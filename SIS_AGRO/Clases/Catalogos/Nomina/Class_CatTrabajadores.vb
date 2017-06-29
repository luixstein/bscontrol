Option Strict On

Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Class_CatTrabajadores
    'Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_TRABAJADOR As String
    Private _CODIGO_X_TEMPORADA As String
    Private _ID_NOMINA_TEMPORADA As Integer
    Private _NOMBRE_TRABAJADOR As String
    Private _APELLIDO_PATERNO As String
    Private _APELLIDO_MATERNO As String
    Private _CODIGO_SEXO As String
    Private _FECHA_NACIMIENTO As Date
    Private _CODIGO_ESTADO_NACIMIENTO As String
    Private _CODIGO_ESTADO_NACIMIENTO_NUMERICO As String
    Private _CODIGO_AREA As Integer
    Private _CODIGO_PUESTO As Integer
    Private _CODIGO_PUNTO_PAGO As Integer
    Private _NUMERO_REGISTRO_IMSS As String
    Private _SUELDO_DIARIO As Double
    Private _ESTATUS_TRABAJADOR As String
    Private _RFC As String
    Private _CURP As String
    Private _DOMICILIO_CALLE As String
    Private _DOMICILIO_NUMERO As String
    Private _DOMICILIO_COLONIA As String
    Private _DOMICILIO_CIUDAD As String
    Private _DOMICILIO_LOCALIDAD As String
    Private _DOMICILIO_CODIGO_ESTADO As String
    Private _DOMICILIO_CODIGO_POSTAL As String
    Private _RECIBE_PAGO_TARJETA_BANCARIA As String
    Private _NUMERO_TARJETA_BANCARIA As String
    Private _CODIGO_BANCO_PAGO_TARJETA As String
    Private _CODIGO_UNIDAD_MEDICA_FAMILIAR As String
    Private _NOMBRE_PADRE As String
    Private _NOMBRE_MADRE As String
    Private _CODIGO_MAYORDOMO As String
    Private _AFILIABLE_IMSS As String
    Private _FIJO_IMSS As String
    Private _CUENTA_CONTABLE As String
    Private _CALCULA_SINDICATO As String
    Private _FECHA_INGRESO As Date
    Private _NUMERO_TRABAJADOR_BANCO As String
    Private _NUMERO_CUENTA_BANCO As String
    Private _ARCHIVO_FOTO() As Byte
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean
    Private _NOMBRE_BANCO As String
    Private _NOMBRE_MAYORDOMO As String
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

    Enum Accion
        INSERTAR
        ACTUALIZAR
    End Enum
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property CODIGO_TRABAJADOR() As String
        Get
            Return Me._CODIGO_TRABAJADOR
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_TRABAJADOR = Value
        End Set
    End Property

    Public ReadOnly Property CODIGO_X_TEMPORADA() As String
        Get
            Return Me._CODIGO_X_TEMPORADA
        End Get
    End Property

    Public Property ID_NOMINA_TEMPORADA() As Integer
        Get
            Return Me._ID_NOMINA_TEMPORADA
        End Get
        Set(ByVal Value As Integer)
            Me._ID_NOMINA_TEMPORADA = Value
        End Set
    End Property

    Public Property NOMBRE_TRABAJADOR() As String
        Get
            Return Me._NOMBRE_TRABAJADOR
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_TRABAJADOR = Value
        End Set
    End Property

    Public Property APELLIDO_PATERNO() As String
        Get
            Return Me._APELLIDO_PATERNO
        End Get
        Set(ByVal Value As String)
            Me._APELLIDO_PATERNO = Value
        End Set
    End Property

    Public Property APELLIDO_MATERNO() As String
        Get
            Return Me._APELLIDO_MATERNO
        End Get
        Set(ByVal Value As String)
            Me._APELLIDO_MATERNO = Value
        End Set
    End Property

    Public Property CODIGO_SEXO() As String
        Get
            Return Me._CODIGO_SEXO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_SEXO = Value
        End Set
    End Property

    Public ReadOnly Property CODIGO_SEXO_SUA() As String
        Get
            Select Case Me._CODIGO_SEXO
                Case "H" 'Hombre
                    Return "M" 'Masculino
                Case "M" 'Mujer
                    Return "F" 'Femenino
                Case Else
                    Return ""
            End Select
        End Get
    End Property

    Public Property FECHA_NACIMIENTO() As Date
        Get
            Return Me._FECHA_NACIMIENTO
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_NACIMIENTO = Value
        End Set
    End Property

    Public Property CODIGO_ESTADO_NACIMIENTO() As String
        Get
            Return Me._CODIGO_ESTADO_NACIMIENTO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_ESTADO_NACIMIENTO = Value
        End Set
    End Property

    Public Property CODIGO_ESTADO_NACIMIENTO_NUMERICO() As String
        Get
            Return Me._CODIGO_ESTADO_NACIMIENTO_NUMERICO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_ESTADO_NACIMIENTO_NUMERICO = Value
        End Set
    End Property

    Public Property CODIGO_AREA() As Integer
        Get
            Return Me._CODIGO_AREA
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_AREA = Value
        End Set
    End Property

    Public Property CODIGO_PUESTO() As Integer
        Get
            Return Me._CODIGO_PUESTO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_PUESTO = Value
        End Set
    End Property

    Public Property CODIGO_PUNTO_PAGO() As Integer
        Get
            Return Me._CODIGO_PUNTO_PAGO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_PUNTO_PAGO = Value
        End Set
    End Property

    Public Property NUMERO_REGISTRO_IMSS() As String
        Get
            Return Me._NUMERO_REGISTRO_IMSS
        End Get
        Set(ByVal Value As String)
            Me._NUMERO_REGISTRO_IMSS = Value
        End Set
    End Property

    Public Property SUELDO_DIARIO() As Double
        Get
            Return Me._SUELDO_DIARIO
        End Get
        Set(ByVal Value As Double)
            Me._SUELDO_DIARIO = Value
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

    Public Property CURP() As String
        Get
            Return Me._CURP
        End Get
        Set(ByVal Value As String)
            Me._CURP = Value
        End Set
    End Property

    Public Property ESTATUS_TRABAJADOR() As String
        Get
            Return Me._ESTATUS_TRABAJADOR
        End Get
        Set(ByVal Value As String)
            Me._ESTATUS_TRABAJADOR = Value
        End Set
    End Property

    Public Property DOMICILIO_CALLE() As String
        Get
            Return Me._DOMICILIO_CALLE
        End Get
        Set(ByVal Value As String)
            Me._DOMICILIO_CALLE = Value
        End Set
    End Property

    Public Property DOMICILIO_NUMERO() As String
        Get
            Return Me._DOMICILIO_NUMERO
        End Get
        Set(ByVal Value As String)
            Me._DOMICILIO_NUMERO = Value
        End Set
    End Property

    Public Property DOMICILIO_COLONIA() As String
        Get
            Return Me._DOMICILIO_COLONIA
        End Get
        Set(ByVal Value As String)
            Me._DOMICILIO_COLONIA = Value
        End Set
    End Property

    Public Property DOMICILIO_LOCALIDAD() As String
        Get
            Return Me._DOMICILIO_LOCALIDAD
        End Get
        Set(ByVal Value As String)
            Me._DOMICILIO_LOCALIDAD = Value
        End Set
    End Property

    Public Property DOMICILIO_CIUDAD() As String
        Get
            Return Me._DOMICILIO_CIUDAD
        End Get
        Set(ByVal Value As String)
            Me._DOMICILIO_CIUDAD = Value
        End Set
    End Property

    Public Property DOMICILIO_CODIGO_ESTADO() As String
        Get
            Return Me._DOMICILIO_CODIGO_ESTADO
        End Get
        Set(ByVal Value As String)
            Me._DOMICILIO_CODIGO_ESTADO = Value
        End Set
    End Property

    Public Property DOMICILIO_CODIGO_POSTAL() As String
        Get
            Return Me._DOMICILIO_CODIGO_POSTAL
        End Get
        Set(ByVal Value As String)
            Me._DOMICILIO_CODIGO_POSTAL = Value
        End Set
    End Property

    Public Property RECIBE_PAGO_TARJETA_BANCARIA() As String
        Get
            Return Me._RECIBE_PAGO_TARJETA_BANCARIA
        End Get
        Set(ByVal Value As String)
            Me._RECIBE_PAGO_TARJETA_BANCARIA = Value
        End Set
    End Property

    Public Property NUMERO_TARJETA_BANCARIA() As String
        Get
            Return Me._NUMERO_TARJETA_BANCARIA
        End Get
        Set(ByVal Value As String)
            Me._NUMERO_TARJETA_BANCARIA = Value
        End Set
    End Property

    Public Property CODIGO_BANCO_PAGO_TARJETA() As String
        Get
            Return Me._CODIGO_BANCO_PAGO_TARJETA
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_BANCO_PAGO_TARJETA = Value
        End Set
    End Property

    Public Property CODIGO_UNIDAD_MEDICA_FAMILIAR() As String
        Get
            Return Me._CODIGO_UNIDAD_MEDICA_FAMILIAR
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_UNIDAD_MEDICA_FAMILIAR = Value
        End Set
    End Property

    Public Property NOMBRE_PADRE() As String
        Get
            Return Me._NOMBRE_PADRE
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_PADRE = Value
        End Set
    End Property

    Public Property NOMBRE_MADRE() As String
        Get
            Return Me._NOMBRE_MADRE
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_MADRE = Value
        End Set
    End Property

    Public Property CODIGO_MAYORDOMO() As String
        Get
            Return Me._CODIGO_MAYORDOMO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_MAYORDOMO = Value
        End Set
    End Property

    Public Property AFILIABLE_IMSS() As String
        Get
            Return Me._AFILIABLE_IMSS
        End Get
        Set(ByVal Value As String)
            Me._AFILIABLE_IMSS = Value
        End Set
    End Property

    Public Property FIJO_IMSS() As String
        Get
            Return Me._FIJO_IMSS
        End Get
        Set(ByVal Value As String)
            Me._FIJO_IMSS = Value
        End Set
    End Property

    Public ReadOnly Property CUENTA_CONTABLE() As String
        Get
            Return Me._CUENTA_CONTABLE
        End Get
    End Property

    Public ReadOnly Property NOMBRE_MAYORDOMO() As String
        Get
            Return Me._NOMBRE_MAYORDOMO
        End Get
    End Property

    Public Property CALCULA_SINDICATO() As String
        Get
            Return Me._CALCULA_SINDICATO
        End Get
        Set(ByVal Value As String)
            Me._CALCULA_SINDICATO = Value
        End Set
    End Property

    Public Property FECHA_INGRESO() As Date
        Get
            Return Me._FECHA_INGRESO
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_INGRESO = Value
        End Set
    End Property

    Public Property NUMERO_TRABAJADOR_BANCO() As String
        Get
            Return Me._NUMERO_TRABAJADOR_BANCO
        End Get
        Set(ByVal Value As String)
            Me._NUMERO_TRABAJADOR_BANCO = Value
        End Set
    End Property

    Public Property NUMERO_CUENTA_BANCO() As String
        Get
            Return Me._NUMERO_CUENTA_BANCO
        End Get
        Set(ByVal Value As String)
            Me._NUMERO_CUENTA_BANCO = Value
        End Set
    End Property

    Public Property ARCHIVO_FOTO() As Byte()
        Get
            Return Me._ARCHIVO_FOTO
        End Get
        Set(value As Byte())
            Me._ARCHIVO_FOTO = value
        End Set
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property NOMBRE_BANCO() As String
        Get
            Return Me._NOMBRE_BANCO
        End Get
    End Property

    Public ReadOnly Property NOMBRE_COMPLETO_NOMBRE() As String
        Get
            Return Me._NOMBRE_TRABAJADOR + " " + Me._APELLIDO_PATERNO + " " + Me._APELLIDO_MATERNO
        End Get
    End Property

    Public ReadOnly Property NOMBRE_COMPLETO_APELLIDO() As String
        Get
            Return Me._APELLIDO_PATERNO + " " + Me._APELLIDO_MATERNO + " " + Me._NOMBRE_TRABAJADOR
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

    Public Property Status() As String
        Get
            Return Me._ESTATUS_TRABAJADOR
        End Get
        Set(ByVal value As String)
            Me._ESTATUS_TRABAJADOR = value
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
        Me._Nombre_Catalogo = "NOMINA_CAT_TRABAJADORES"
        Me._Nombre_Reporte = "RPT_CATALOGO_NOMINA_TRABAJADORES"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT T.*,B.NOMBRE_BANCO,M.NOMBRE_TRABAJADOR NOMBRE_MAYORDOMO,E.CODIGO_ESTADO_NUMERICO CODIGO_ESTADO_NACIMIENTO_NUMERICO " &
        "FROM NOMINA_CAT_TRABAJADORES T " &
        "LEFT JOIN CAT_BANCOS B ON(T.CODIGO_BANCO_PAGO_TARJETA=B.CODIGO_BANCO) " &
        "LEFT JOIN NOMINA_CAT_TRABAJADORES M ON(T.CODIGO_MAYORDOMO=M.CODIGO_TRABAJADOR) " &
        "INNER JOIN SIS_ESTADOS E ON(T.CODIGO_ESTADO_NACIMIENTO=E.CODIGO_ESTADO) "
        Me._QueryOrder = " ORDER BY T.NOMBRE_TRABAJADOR"
    End Sub

    Public Sub New(ByVal sCodigoTrabajador As String, Optional ByVal sRegistroImss As String = "")
        Me.New()
        If sRegistroImss = "" Then
            Me._CODIGO_TRABAJADOR = sCodigoTrabajador
        End If

        Try
            If Me.Consultar(sRegistroImss) = True Then
                Me._Existe = True
                'Else
                '    Throw New Exception("El trabajador no existe.")
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "New", ex)
        End Try
    End Sub

    Public Sub New(ByVal sCodigoxTemporada As String, ByVal bEsXTemporada As Boolean)
        Me.New()
        Me._CODIGO_X_TEMPORADA = sCodigoxTemporada
        Try
            If Me.ConsultarXTemporada() = True Then
                Me._Existe = True
                'Else
                '    Throw New Exception("El trabajador no existe.")
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "New", ex)
        End Try
    End Sub

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

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region


#Region "Métodos y procedimientos"
    Public Function Grabar(ByVal eAccion As Accion) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_CAT_TRABAJADORES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_TRABAJADOR", SqlDbType.NVarChar, 10) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = Me._CODIGO_TRABAJADOR
            sqlParametro = .Parameters.Add("@CODIGO_X_TEMPORADA", SqlDbType.NVarChar, 10) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = ""
            sqlParametro = .Parameters.Add("@ID_NOMINA_TEMPORADA", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_NOMINA_TEMPORADA
            sqlParametro = .Parameters.Add("@NOMBRE_TRABAJADOR", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._NOMBRE_TRABAJADOR.ToUpper
            sqlParametro = .Parameters.Add("@APELLIDO_PATERNO", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._APELLIDO_PATERNO.ToUpper
            sqlParametro = .Parameters.Add("@APELLIDO_MATERNO", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._APELLIDO_MATERNO.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_SEXO", SqlDbType.Char, 1) : sqlParametro.Value = Me._CODIGO_SEXO.ToUpper
            sqlParametro = .Parameters.Add("@FECHA_NACIMIENTO", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_NACIMIENTO
            sqlParametro = .Parameters.Add("@CODIGO_ESTADO_NACIMIENTO", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_ESTADO_NACIMIENTO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_AREA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_AREA
            sqlParametro = .Parameters.Add("@CODIGO_PUESTO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PUESTO
            sqlParametro = .Parameters.Add("@CODIGO_PUNTO_PAGO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PUNTO_PAGO
            sqlParametro = .Parameters.Add("@NUMERO_REGISTRO_IMSS", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._NUMERO_REGISTRO_IMSS 'FALTA R
            sqlParametro = .Parameters.Add("@SUELDO_DIARIO", SqlDbType.Money) : sqlParametro.Value = Me._SUELDO_DIARIO
            sqlParametro = .Parameters.Add("@RFC", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._RFC.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CURP", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._CURP.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS_TRABAJADOR", SqlDbType.Char, 1) : sqlParametro.Value = Me._ESTATUS_TRABAJADOR.ToUpper

            sqlParametro = .Parameters.Add("@DOMICILIO_CALLE", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._DOMICILIO_CALLE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@DOMICILIO_NUMERO", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._DOMICILIO_NUMERO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@DOMICILIO_COLONIA", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._DOMICILIO_COLONIA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@DOMICILIO_LOCALIDAD", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._DOMICILIO_LOCALIDAD.ToString.ToUpper
            sqlParametro = .Parameters.Add("@DOMICILIO_CIUDAD", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._DOMICILIO_CIUDAD.ToString.ToUpper
            sqlParametro = .Parameters.Add("@DOMICILIO_CODIGO_ESTADO", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._DOMICILIO_CODIGO_ESTADO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@DOMICILIO_CODIGO_POSTAL ", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._DOMICILIO_CODIGO_POSTAL.ToString.ToUpper

            sqlParametro = .Parameters.Add("@RECIBE_PAGO_TARJETA_BANCARIA", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._RECIBE_PAGO_TARJETA_BANCARIA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@NUMERO_TARJETA_BANCARIA", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._NUMERO_TARJETA_BANCARIA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_BANCO_PAGO_TARJETA", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._CODIGO_BANCO_PAGO_TARJETA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_UNIDAD_MEDICA_FAMILIAR", SqlDbType.NVarChar, 3) : sqlParametro.Value = "" & Me._CODIGO_UNIDAD_MEDICA_FAMILIAR
            sqlParametro = .Parameters.Add("@NOMBRE_PADRE", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._NOMBRE_PADRE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_MADRE", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._NOMBRE_MADRE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_MAYORDOMO", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_MAYORDOMO.ToString
            sqlParametro = .Parameters.Add("@AFILIABLE_IMSS", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._AFILIABLE_IMSS.ToString.ToUpper
            sqlParametro = .Parameters.Add("@FIJO_IMSS", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._FIJO_IMSS.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CALCULA_SINDICATO", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._CALCULA_SINDICATO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@FECHA_INGRESO", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_INGRESO
            sqlParametro = .Parameters.Add("@NUMERO_TRABAJADOR_BANCO", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._NUMERO_TRABAJADOR_BANCO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@NUMERO_CUENTA_BANCO", SqlDbType.NVarChar, 18) : sqlParametro.Value = Me._NUMERO_CUENTA_BANCO.ToString.ToUpper
            sqlParametro = .Parameters.Add("ARCHIVO_FOTO", SqlDbType.Image) : sqlParametro.Value = IIf(Me._ARCHIVO_FOTO Is Nothing, DBNull.Value, Me._ARCHIVO_FOTO)

            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = eAccion.ToString

            Try

                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._CODIGO_TRABAJADOR = "" & .Parameters("@CODIGO_TRABAJADOR").Value.ToString
                Me._CODIGO_X_TEMPORADA = "" & .Parameters("@CODIGO_X_TEMPORADA").Value.ToString
                bResultado = True
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

    Private Function ConsultarLocal(ByVal sSql As String) As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim cmd As New SqlCommand(Me._QuerySelect & sSql, Me._Conexion)
            Dim dReader As SqlDataReader

            With cmd
                .CommandTimeout = 0
                .CommandType = CommandType.Text
                Try
                    Me._Conexion.Open()
                    dReader = .ExecuteReader()

                    If dReader.Read = True Then
                        Me._CODIGO_TRABAJADOR = "" & dReader("CODIGO_TRABAJADOR").ToString
                        Me._CODIGO_X_TEMPORADA = "" & dReader("CODIGO_X_TEMPORADA").ToString
                        Me._ID_NOMINA_TEMPORADA = CInt(dReader("ID_NOMINA_TEMPORADA"))
                        Me._NOMBRE_TRABAJADOR = "" & dReader("NOMBRE_TRABAJADOR").ToString
                        Me._APELLIDO_PATERNO = "" & dReader("APELLIDO_PATERNO").ToString
                        Me._APELLIDO_MATERNO = "" & dReader("APELLIDO_MATERNO").ToString
                        Me._CODIGO_SEXO = "" & dReader("CODIGO_SEXO").ToString
                        Me._FECHA_NACIMIENTO = CDate(dReader("FECHA_NACIMIENTO"))
                        Me._CODIGO_ESTADO_NACIMIENTO = "" & dReader("CODIGO_ESTADO_NACIMIENTO").ToString
                        Me._CODIGO_ESTADO_NACIMIENTO_NUMERICO = dReader("CODIGO_ESTADO_NACIMIENTO_NUMERICO").ToString

                        Me._CODIGO_AREA = CInt("" & dReader("CODIGO_AREA").ToString)
                        Me._CODIGO_PUESTO = CInt("" & dReader("CODIGO_PUESTO").ToString)
                        Me._CODIGO_PUNTO_PAGO = CInt("" & dReader("CODIGO_PUNTO_PAGO").ToString)
                        Me._NUMERO_REGISTRO_IMSS = "" & dReader("NUMERO_REGISTRO_IMSS").ToString.ToString
                        Me._SUELDO_DIARIO = CDec(dReader("SUELDO_DIARIO"))
                        Me._ESTATUS_TRABAJADOR = "" & dReader("ESTATUS_TRABAJADOR").ToString
                        Me._RFC = "" & dReader("RFC").ToString
                        Me._CURP = "" & dReader("CURP").ToString

                        Me._DOMICILIO_CALLE = "" & dReader("DOMICILIO_CALLE").ToString
                        Me._DOMICILIO_NUMERO = "" & dReader("DOMICILIO_NUMERO").ToString
                        Me._DOMICILIO_COLONIA = "" & dReader("DOMICILIO_COLONIA").ToString
                        Me._DOMICILIO_CIUDAD = "" & dReader("DOMICILIO_CIUDAD").ToString
                        Me._DOMICILIO_LOCALIDAD = "" & dReader("DOMICILIO_LOCALIDAD").ToString
                        Me._DOMICILIO_CODIGO_ESTADO = "" & dReader("DOMICILIO_CODIGO_ESTADO").ToString
                        Me._DOMICILIO_CODIGO_POSTAL = "" & dReader("DOMICILIO_CODIGO_POSTAL").ToString
                        Me._RECIBE_PAGO_TARJETA_BANCARIA = "" & dReader("RECIBE_PAGO_TARJETA_BANCARIA").ToString
                        Me._NUMERO_TARJETA_BANCARIA = "" & dReader("NUMERO_TARJETA_BANCARIA").ToString
                        Me._CODIGO_BANCO_PAGO_TARJETA = "" & dReader("CODIGO_BANCO_PAGO_TARJETA").ToString
                        Me._NOMBRE_BANCO = "" & dReader("NOMBRE_BANCO").ToString

                        Me._CODIGO_UNIDAD_MEDICA_FAMILIAR = "" & dReader("CODIGO_UNIDAD_MEDICA_FAMILIAR").ToString
                        Me._NOMBRE_PADRE = "" & dReader("NOMBRE_PADRE").ToString
                        Me._NOMBRE_MADRE = "" & dReader("NOMBRE_MADRE").ToString
                        Me._CODIGO_MAYORDOMO = "" & dReader("CODIGO_MAYORDOMO").ToString
                        Me._NOMBRE_MAYORDOMO = "" & dReader("NOMBRE_MAYORDOMO").ToString
                        Me._AFILIABLE_IMSS = "" & dReader("AFILIABLE_IMSS").ToString
                        Me._FIJO_IMSS = "" & dReader("FIJO_IMSS").ToString
                        Me._CUENTA_CONTABLE = "" & dReader("CUENTA_CONTABLE").ToString
                        Me._CALCULA_SINDICATO = "" & dReader("CALCULA_SINDICATO").ToString
                        Me._FECHA_INGRESO = CDate(dReader("FECHA_INGRESO"))
                        Me._NUMERO_TRABAJADOR_BANCO = "" & dReader("NUMERO_TRABAJADOR_BANCO").ToString
                        Me._NUMERO_CUENTA_BANCO = "" & dReader("NUMERO_CUENTA_BANCO").ToString

                        If IsDBNull(dReader("ARCHIVO_FOTO")) = False Then
                            Me._ARCHIVO_FOTO = CType(dReader("ARCHIVO_FOTO"), Byte())
                        End If

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

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ConsultarLocal", ex)
        End Try

        Return bResultado
    End Function

    Public Function Consultar(Optional ByVal sRegistroImss As String = "") As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim sSql As String = ""
            If txtLEN(sRegistroImss) = True Then
                Me._NUMERO_REGISTRO_IMSS = sRegistroImss
                sSql = " WHERE T.NUMERO_REGISTRO_IMSS='" & sReplace(Me._NUMERO_REGISTRO_IMSS) & "' "
            Else
                sSql = " WHERE T.CODIGO_TRABAJADOR='" & sReplace(Me._CODIGO_TRABAJADOR) & "' "
            End If

            bResultado = Me.ConsultarLocal(sSql)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "Consultar", ex)
        End Try

        Return bResultado
    End Function

    Public Function ConsultarXTemporada() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim sSql As String = ""
            sSql = " WHERE T.CODIGO_X_TEMPORADA='" & sReplace(Me._CODIGO_X_TEMPORADA) & "' AND T.ID_NOMINA_TEMPORADA=" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA.ToString

            bResultado = Me.ConsultarLocal(sSql)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ConsultarXTemporada", ex)
        End Try

        Return bResultado
    End Function

    Public Function ActualizarUnidadMedica() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_CAT_TRABAJADORES_ACTUALIZA_CODIGO_UNIDAD_MEDICA_FAMILIAR"

            sqlParametro = .Parameters.Add("@CODIGO_TRABAJADOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_TRABAJADOR.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_UNIDAD_MEDICA_FAMILIAR", SqlDbType.Money) : sqlParametro.Value = Me._CODIGO_UNIDAD_MEDICA_FAMILIAR
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "ActualizarUnidadMedica", ex)
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
        Dim da As New SqlDataAdapter("SELECT CODIGO_TRABAJADOR,NOMBRE_COMPLETO_APELLIDO FROM VW_NOMINA_CAT_TRABAJADORES_EXTENDIDA EHERE CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA.ToString & "  ORDER BY NOMBRE_COMPLETO_APELLIDO", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosxTemporada() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_X_TEMPORADA,NOMBRE_COMPLETO_APELLIDO FROM VW_NOMINA_CAT_TRABAJADORES_EXTENDIDA WHERE CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA.ToString &
                                    "AND ID_NOMINA_TEMPORADA=" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA & " " &
                                    "ORDER BY NOMBRE_COMPLETO_APELLIDO", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltroTrabajador(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_TRABAJADOR,NOMBRE_COMPLETO_APELLIDO FROM VW_NOMINA_CAT_TRABAJADORES_EXTENDIDA where CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA.ToString & " AND  NOMBRE_COMPLETO_APELLIDO LIKE '%" & Filtro.ToString & "%' ORDER BY NOMBRE_COMPLETO_APELLIDO", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltroTrabajador", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerEstados() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_ESTADO,NOMBRE_ESTADO FROM SIS_ESTADOS ORDER BY NOMBRE_ESTADO", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerEstados", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerTemporadas() As System.Data.DataTable
        Dim dTable As New DataTable
        'Dim dsCat_Estados As New SqlDataAdapter("SELECT ID_NOMINA_TEMPORADA,NOMBRE_TEMPORADA FROM NOMINA_TEMPORADAS T INNER JOIN SIS_EMPRESA_NOMINA P ON(T.CODIGO_PLAZA=P.CODIGO_PLAZA) WHERE T.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " AND T.CODIGO_TEMPORADA=P.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA ", Me._Conexion)
        Dim da As New SqlDataAdapter("SELECT ID_NOMINA_TEMPORADA,NOMBRE_TEMPORADA FROM NOMINA_TEMPORADAS T INNER JOIN SIS_EMPRESA_NOMINA P ON(T.CODIGO_PLAZA=P.CODIGO_PLAZA) WHERE T.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " ORDER BY CODIGO_TEMPORADA DESC ", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerTemporadas", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerSexos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_SEXO,NOMBRE_SEXO FROM CAT_SEXOS ORDER BY NOMBRE_SEXO", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerSexos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de trabajadores por código."
        f.sCampo = "CODIGO_TRABAJADOR"
        f.sOrder = "NOMBRE_COMPLETO_APELLIDO"
        f.sTable = "VW_NOMINA_CAT_TRABAJADORES_EXTENDIDA"
        f.sQl = "SELECT CODIGO_X_TEMPORADA,NOMBRE_COMPLETO_APELLIDO FROM VW_NOMINA_CAT_TRABAJADORES_EXTENDIDA WHERE CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString &
            " AND ID_NOMINA_TEMPORADA = " & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA & " AND "
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
        f.Text = "Búsqueda de trabajadores por nombre."
        f.sCampo = "NOMBRE_COMPLETO_NOMBRE"
        f.sOrder = "NOMBRE_COMPLETO_NOMBRE"
        f.sTable = "VW_NOMINA_CAT_TRABAJADORES_EXTENDIDA"
        f.sQl = "SELECT CODIGO_X_TEMPORADA,NOMBRE_COMPLETO_NOMBRE FROM VW_NOMINA_CAT_TRABAJADORES_EXTENDIDA WHERE CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA.ToString &
            " AND ID_NOMINA_TEMPORADA = " & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA & " AND "
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

    Public Function BusquedaVisual_PorDescripcion_PuntoPago(ByVal iPuntoPago As Integer) As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de trabajadores por nombre de un punto de pago."
        f.sCampo = "NOMBRE_COMPLETO_APELLIDO"
        f.sOrder = "NOMBRE_COMPLETO_APELLIDO"
        f.sTable = "VW_NOMINA_CAT_TRABAJADORES_EXTENDIDA"
        f.sQl = "SELECT CODIGO_X_TEMPORADA,NOMBRE_COMPLETO_APELLIDO FROM VW_NOMINA_CAT_TRABAJADORES_EXTENDIDA WHERE CODIGO_PUNTO_PAGO=" & iPuntoPago.ToString & " And CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA.ToString &
            " AND ID_NOMINA_TEMPORADA=" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA & " AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion_PuntoPago", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_Mayordomos() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de mayordomos por nombre."
        f.sCampo = "NOMBRE_TRABAJADOR"
        f.sOrder = "NOMBRE_TRABAJADOR"
        f.sTable = "NOMINA_CAT_TRABAJADORES"
        f.sQl = "SELECT CODIGO_X_TEMPORADA,NOMBRE_TRABAJADOR FROM NOMINA_CAT_TRABAJADORES T " &
        "INNER JOIN NOMINA_CAT_PUESTOS P ON(T.CODIGO_PUESTO=P.CODIGO_PUESTO AND P.NOMBRE_PUESTO='MAYORDOMO') " &
        "WHERE T.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA.ToString & " AND T.ID_NOMINA_TEMPORADA=" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA.ToString & " AND "
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

    Public Function CodigoSiguiente() As Boolean
        'Dim iTrabajador As Integer
        'Dim Resultado As String = ""
        'Try
        '    Dim CodigoTrabajador As New Class_find("SELECT ISNULL(MAX(CODIGO_TRABAJADOR),0) FROM NOMINA_CAT_TRABAJADORES  WHERE ID_NOMINA_TEMPORADA=" & Plaza.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA)
        '    'iTrabajador = CInt(Strings.Right(CodigoTrabajador.Result1, Len(Plaza.CODIGO_PLAZA.ToString) + 1))
        '    iTrabajador = CInt(CodigoTrabajador.Result1.Replace(Plaza.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA.ToString & "-", ""))
        '    'sFolio.Substring(Len(sFolio) - 6)
        '    'iTrabajador = CInt(CodigoTrabajador.Result1)
        '    iTrabajador = iTrabajador + 1

        '    Resultado = iTrabajador.ToString
        'Catch ex As Exception
        '    HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
        'End Try
        'Return Resultado

        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_CAT_TRABAJADORES_GESTIONA_CONSECUTIVO"

            sqlParametro = .Parameters.Add("@CODIGO_TRABAJADOR", SqlDbType.NVarChar, 10) : sqlParametro.Value = "" & Me._CODIGO_TRABAJADOR : sqlParametro.Direction = ParameterDirection.Output
            sqlParametro = .Parameters.Add("@CODIGO_PUNTO_PAGO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PUNTO_PAGO
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = "OBTENER"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()

                Me._CODIGO_TRABAJADOR = cmd.Parameters("@CODIGO_TRABAJADOR").Value.ToString

            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function ObtenerHistorialDeducciones() As System.Data.DataTable
        Dim dt As New DataTable("detalle"), da As SqlDataAdapter

        Dim sSQL As String
        sSQL = "SELECT * " &
        "FROM VW_NOMINA_DEDUCCIONES_GLOBAL_EXTENDIDA P " &
        "WHERE P.CODIGO_TRABAJADOR= '" & Me._CODIGO_TRABAJADOR & "' AND P.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)

            da.Fill(dt)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerHistorialDeducciones", ex)
        End Try

        Return dt
    End Function

#End Region

End Class
