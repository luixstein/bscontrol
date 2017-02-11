Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CXP_Descuento

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_CXP_DESCUENTOS_GLOBAL As Integer
    Private _CODIGO_PLAZA As Integer
    Private _CODIGO_CLIENTE As String
    Private _NOMBRE_CLIENTE As String
    Private _FECHA As Date
    Private _FECHA_SERVIDOR As Date
    Private _ESTATUS_DESCUENTO As String
    Private _CONCEPTO1 As String
    Private _CONCEPTO2 As String
    Private _FOLIO_POLIZA As String
    Private _CODIGO_USUARIO_GRABO As Integer
    Private _NOMBRE_USUARIO_GRABO As String
    Private _CODIGO_USUARIO_CANCELO As Integer
    Private _NOMBRE_USUARIO_CANCELO As String
    Private _FOLIO_DESCUENTO As String
    Private _FECHA_CANCELACION As Date
    Private _FECHA_CANCELACION_SERVIDOR As Date
    Private _TIPO_DE_CAMBIO As Double
    Private _SUBTOTAL As Double
    Private _IVA As Double
    Private _TOTAL As Double
    Private _ES_COMPROBANTE_ELECTRONICO As String
    Private _FOLIO_NUMERICO As Integer
    Private _IDCATALOGO_FOLIO_FELECTRONICA As Integer
    Private _ID_SIS_CFD_CATALOGO_CERTIFICADOS As Integer
    Private _CADENA_ORIGINAL As String
    Private _SELLO_DIGITAL As String
    Private _ES_VENTA_PUBLICO_GENERAL As String
    Private _ES_POR_DEVOLUCION As String

#End Region

#Region "Campos de control"

#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Nombre_Reporte As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
    Private _Nombre_Formato As String
#End Region

#Region "Campos de privado"
    Private _oDocumento As Class_CatDocumentos
#End Region

#End Region

#Region "Propiedades"
#Region "Propiedades Campos de la tabla"
    Public ReadOnly Property ID_CXP_DESCUENTOS_GLOBAL() As Integer
        Get
            Return Me._ID_CXP_DESCUENTOS_GLOBAL
        End Get
    End Property

    Public Property FOLIO_DESCUENTO() As String
        Get
            Return Me._FOLIO_DESCUENTO
        End Get
        Set(ByVal value As String)
            Me._FOLIO_DESCUENTO = value
        End Set

    End Property

    Public Property CODIGO_PLAZA() As Integer
        Get
            Return Me._CODIGO_PLAZA
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_PLAZA = value
        End Set
    End Property

    Public Property CODIGO_CLIENTE() As String
        Get
            Return Me._CODIGO_CLIENTE
        End Get
        Set(ByVal value As String)
            Me._CODIGO_CLIENTE = value
        End Set
    End Property
    Public Property NOMBRE_CLIENTE() As String
        Get
            Return Me._NOMBRE_CLIENTE
        End Get
        Set(ByVal value As String)
            Me._NOMBRE_CLIENTE = value
        End Set
    End Property

    Public Property FECHA() As Date
        Get
            Return Me._FECHA
        End Get
        Set(ByVal value As Date)
            Me._FECHA = value
        End Set
    End Property

    Public Property FECHA_SERVIDOR() As Date
        Get
            Return Me._FECHA_SERVIDOR
        End Get
        Set(ByVal value As Date)
            Me._FECHA_SERVIDOR = value
        End Set
    End Property

    Public Property ESTATUS_DESCUENTO() As String
        Get
            Return Me._ESTATUS_DESCUENTO
        End Get
        Set(ByVal value As String)
            Me._ESTATUS_DESCUENTO = value
        End Set
    End Property

    Public Property CONCEPTO1() As String
        Get
            Return Me._CONCEPTO1
        End Get
        Set(ByVal value As String)
            Me._CONCEPTO1 = value
        End Set
    End Property

    Public Property CONCEPTO2() As String
        Get
            Return Me._CONCEPTO2
        End Get
        Set(ByVal value As String)
            Me._CONCEPTO2 = value
        End Set
    End Property

    Public Property FOLIO_POLIZA() As String
        Get
            Return Me._FOLIO_POLIZA
        End Get
        Set(ByVal value As String)
            Me._FOLIO_POLIZA = value
        End Set
    End Property

    Public Property CODIGO_USUARIO_GRABO() As Integer
        Get
            Return Me._CODIGO_USUARIO_GRABO
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_USUARIO_GRABO = value
        End Set
    End Property

    Public Property NOMBRE_USUARIO_GRABO() As String
        Get
            Return Me._NOMBRE_USUARIO_GRABO
        End Get
        Set(ByVal value As String)
            Me._NOMBRE_USUARIO_GRABO = value
        End Set
    End Property

    Public Property CODIGO_USUARIO_CANCELO() As Integer
        Get
            Return Me._CODIGO_USUARIO_CANCELO
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_USUARIO_CANCELO = value
        End Set
    End Property

    Public Property NOMBRE_USUARIO_CANCELO() As String
        Get
            Return Me._NOMBRE_USUARIO_CANCELO
        End Get
        Set(ByVal value As String)
            Me._NOMBRE_USUARIO_CANCELO = value
        End Set
    End Property

    Public Property FECHA_CANCELACION() As Date
        Get
            Return Me._FECHA_CANCELACION
        End Get
        Set(ByVal value As Date)
            Me._FECHA_CANCELACION = value
        End Set
    End Property

    Public Property FECHA_CANCELACION_SERVIDOR() As Date
        Get
            Return Me._FECHA_CANCELACION_SERVIDOR
        End Get
        Set(ByVal value As Date)
            Me._FECHA_CANCELACION_SERVIDOR = value
        End Set
    End Property

    Public Property TIPO_DE_CAMBIO() As Double
        Get
            Return Me._TIPO_DE_CAMBIO
        End Get
        Set(ByVal value As Double)
            Me._TIPO_DE_CAMBIO = value
        End Set
    End Property

    Public Property SUBTOTAL() As Double
        Get
            Return Me._SUBTOTAL
        End Get
        Set(ByVal value As Double)
            Me._SUBTOTAL = value
        End Set
    End Property

    Public Property IVA() As Double
        Get
            Return Me._IVA
        End Get
        Set(ByVal value As Double)
            Me._IVA = value
        End Set
    End Property

    Public Property TOTAL() As Double
        Get
            Return Me._TOTAL
        End Get
        Set(ByVal value As Double)
            Me._TOTAL = value
        End Set
    End Property

    Public WriteOnly Property ES_COMPROBANTE_ELECTRONICO() As String
        Set(ByVal value As String)
            Me._ES_COMPROBANTE_ELECTRONICO = value
        End Set

    End Property

    Public ReadOnly Property FOLIO_NUMERICO() As Integer
        Get
            Return Me._FOLIO_NUMERICO
        End Get

    End Property

    Public WriteOnly Property IDCATALOGO_FOLIO_FELECTRONICA() As Integer
        Set(ByVal value As Integer)
            Me._IDCATALOGO_FOLIO_FELECTRONICA = value
        End Set
    End Property

    Public Property ID_SIS_CFD_CATALOGO_CERTIFICADOS() As Integer
        Get
            Return Me._ID_SIS_CFD_CATALOGO_CERTIFICADOS
        End Get
        Set(ByVal value As Integer)
            Me._ID_SIS_CFD_CATALOGO_CERTIFICADOS = value
        End Set
    End Property

    Public Property CADENA_ORIGINAL() As String
        Get
            Return Me._CADENA_ORIGINAL
        End Get
        Set(ByVal value As String)
            Me._CADENA_ORIGINAL = value
        End Set
    End Property

    Public Property ES_VENTA_PUBLICO_GENERAL() As String
        Get
            Return Me._ES_VENTA_PUBLICO_GENERAL
        End Get
        Set(ByVal value As String)
            Me._ES_VENTA_PUBLICO_GENERAL = value
        End Set
    End Property

    Public Property ES_POR_DEVOLUCION() As String
        Get
            Return Me._ES_POR_DEVOLUCION
        End Get
        Set(ByVal value As String)
            Me._ES_POR_DEVOLUCION = value
        End Set
    End Property
#End Region

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_CXP_Descuentos"
        End Get
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property

    Public ReadOnly Property Nombre_Formato() As String
        Get
            Return Me._Nombre_Formato
        End Get
    End Property

#End Region
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        ' Me.oDocumento = New Class_CatDocumentos()
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal folioDescuento As String)
        Me.New()
        Me._FOLIO_DESCUENTO = folioDescuento

        Try
            If Me.Consultar = True Then
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Public Function InsertarDescuentos() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CXP_DESCUENTOS_GRABA_GLOBAL"

            sqlParametro = .Parameters.Add("@FOLIO_DESCUENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_DESCUENTO : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_CLIENTE
            sqlParametro = .Parameters.Add("@SUBTOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._SUBTOTAL
            sqlParametro = .Parameters.Add("@IVA", SqlDbType.Decimal) : sqlParametro.Value = Me._IVA
            sqlParametro = .Parameters.Add("@TOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA
            sqlParametro = .Parameters.Add("@CONCEPTO", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONCEPTO1
            sqlParametro = .Parameters.Add("@CONCEPTO2", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONCEPTO2
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@TIPO_DE_CAMBIO", SqlDbType.Decimal) : sqlParametro.Value = Me._TIPO_DE_CAMBIO
            sqlParametro = .Parameters.Add("@ES_POR_DEVOLUCION", SqlDbType.Char, 1) : sqlParametro.Value = Me._ES_POR_DEVOLUCION
            'sqlParametro = .Parameters.Add("@ES_COMPROBANTE_ELECTRONICO", SqlDbType.Char, 1) : sqlParametro.Value = Me._ES_COMPROBANTE_ELECTRONICO
            sqlParametro = .Parameters.Add("@ES_VENTA_PUBLICO_GENERAL", SqlDbType.Char, 1) : sqlParametro.Value = Me._ES_VENTA_PUBLICO_GENERAL

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
                Me._FOLIO_DESCUENTO = "" & .Parameters("@FOLIO_DESCUENTO").Value.ToString
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "InsertarDescuentos", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function InsertaDescuentoDetalle(ByVal sFolio As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CXP_DESCUENTOS_GRABA_RELACION_DETALLE"

            sqlParametro = .Parameters.Add("@FOLIO_CXP", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolio
            sqlParametro = .Parameters.Add("@FOLIO_DESCUENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_DESCUENTO

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "InsertaDescuentoDetalle", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    'Public Function InsertaDescuentoCultivoDetalle(ByVal sFolio As String, ByVal dImporteDescuento As Double, Optional ByVal sCodigoCultivo As String = "") As Boolean
    '    Dim cmd As New SqlCommand
    '    Dim sqlParametro As SqlParameter
    '    With cmd
    '        .Connection = _Conexion
    '        .CommandTimeout = 0
    '        .CommandType = CommandType.StoredProcedure
    '        .CommandText = "MP_CXP_DESCUENTOS_DETALLE_CULTIVOS_GRABA"

    '        sqlParametro = .Parameters.Add("@FOLIO_CXC", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolio
    '        sqlParametro = .Parameters.Add("@CODIGO_CULTIVO", SqlDbType.NVarChar, 4) : sqlParametro.Value = sCodigoCultivo
    '        sqlParametro = .Parameters.Add("@IMPORTE_DESCUENTO", SqlDbType.Decimal) : sqlParametro.Value = dImporteDescuento

    '        Try
    '            Me._Conexion.Open()
    '            .ExecuteNonQuery()
    '            InsertaDescuentoCultivoDetalle = True
    '        Catch ex As Exception
    '            HandleError(Me.Nombre_Clase, "InsertaDescuentoCultivoDetalle", ex)
    '        Finally
    '            Me._Conexion.Close()
    '            cmd.Dispose()
    '            sqlParametro = Nothing
    '        End Try
    '    End With
    'End Function

    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        'VW_BANCOS_GLOBAL_CON_CXC_GLOBAL Where FOLIO_BANCO=
        Dim cmd As New SqlCommand("SELECT V.* " & _
                                  "FROM VW_CXP_DESCUENTOS_GLOBAL_CON_CXP_GLOBAL V " & _
                                  "WHERE V.DESC_FOLIO_DESCUENTO='" & Me._FOLIO_DESCUENTO & "'", Me._Conexion)
        '"INNER JOIN SIS_CAT_DOCUMENTOS CD ON (V.BAN_CODIGO_DOCUMENTO=CD.CODIGO_DOCUMENTO) " & _
        Dim dReader As SqlDataReader

        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then

                    Me._ID_CXP_DESCUENTOS_GLOBAL = CType(dReader("DESC_ID_CXP_DESCUENTOS_GLOBAL"), Integer)
                    Me._FOLIO_DESCUENTO = CType(dReader("DESC_FOLIO_DESCUENTO"), String)
                    Me._CODIGO_PLAZA = CType(dReader("DESC_CODIGO_PLAZA"), Integer)
                    Me._CODIGO_CLIENTE = CType(dReader("DESC_CODIGO_PROVEEDOR"), String)
                    Me._NOMBRE_CLIENTE = CType(dReader("DESC_NOMBRE_PROVEEDOR"), String)
                    Me._FOLIO_POLIZA = "" & dReader("DESC_FOLIO_POLIZA").ToString
                    Me._FECHA = CType(dReader("DESC_FECHA"), Date)
                    Me._FECHA_SERVIDOR = CType(dReader("DESC_FECHA_SERVIDOR"), Date)
                    Me._ESTATUS_DESCUENTO = CType(dReader("DESC_ESTATUS_DESCUENTO"), String)
                    Me._CONCEPTO1 = CType(dReader("DESC_CONCEPTO1"), String)
                    Me._CONCEPTO2 = CType(dReader("DESC_CONCEPTO2"), String)
                    Me._CODIGO_USUARIO_GRABO = CType(dReader("DESC_CODIGO_USUARIO_GRABO"), Integer)
                    Me._NOMBRE_USUARIO_GRABO = CType(dReader("DESC_NOMBRE_USUARIO_GRABO"), String)
                    Me._TIPO_DE_CAMBIO = CType(dReader("DESC_TIPO_DE_CAMBIO"), Double)
                    Me._SUBTOTAL = CType(dReader("DESC_SUBTOTAL"), Double)
                    Me._IVA = CType(dReader("DESC_IVA"), Double)
                    Me._TOTAL = CType(dReader("DESC_TOTAL"), Double)
                    'Me._ES_COMPROBANTE_ELECTRONICO = CType(dReader("DESC_ES_COMPROBANTE_ELECTRONICO"), String)
                    'Me._FOLIO_NUMERICO = CType(dReader("DESC_FOLIO_NUMERICO"), Integer)
                    'Me._IDCATALOGO_FOLIO_FELECTRONICA = CType(dReader("DESC_IDCATALOGO_FOLIO_FELECTRONICA"), Integer)
                    'Me._ID_SIS_CFD_CATALOGO_CERTIFICADOS = CType(dReader("DESC_ID_SIS_CFD_CATALOGO_CERTIFICADOS"), Integer)
                    'Me._CADENA_ORIGINAL = CType(dReader("DESC_CADENA_ORIGINAL"), String)
                    'Me._SELLO_DIGITAL = CType(dReader("DESC_SELLO_DIGITAL"), String)
                    Me._ES_VENTA_PUBLICO_GENERAL = "" & dReader("DESC_ES_VENTA_PUBLICO_GENERAL").ToString
                    Me._ES_POR_DEVOLUCION = CType(dReader("DESC_ES_POR_DEVOLUCION"), String)

                    If Me._ESTATUS_DESCUENTO = "C" Then
                        Me._CODIGO_USUARIO_CANCELO = CType(dReader("DESC_CODIGO_USUARIO_CANCELO"), Integer)
                        Me._NOMBRE_USUARIO_CANCELO = CType(dReader("DESC_NOMBRE_USUARIO_CANCELO"), String)
                        Me._FECHA_CANCELACION = CType(dReader("DESC_FECHA_CANCELACION"), Date)
                        'Me._FECHA_CANCELACION_SERVIDOR = CType(dReader("FECHA_CANCELACION_SERVIDOR"), Date)
                    End If

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

    Public Function ObtenerDetalle() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        sSQL = "SELECT G.FOLIO_REFERENCIA,V.FECHA,V.TOTAL,V.SALDO,G.SUBTOTAL,G.IMPUESTO,G.TOTAL,V.IMPUESTO_PORCENTAJE FROM CXP_DESCUENTOS_GLOBAL DG " & _
        "INNER JOIN CXP_DESCUENTOS_DETALLE D ON(DG.FOLIO_DESCUENTO=D.FOLIO_DESCUENTO) " & _
        "INNER JOIN CXP_GLOBAL G ON(D.FOLIO_CXP =G.FOLIO_CXP) " & _
        "INNER JOIN COMPRA_GLOBAL V  ON(G.FOLIO_REFERENCIA=V.FOLIO_COMPRA ) " & _
        "WHERE DG.FOLIO_DESCUENTO = '" & Me.FOLIO_DESCUENTO.ToString & "' "

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)

            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerDetalle", ex)
        End Try
        Return dTabla
    End Function

    Public Function CancelaDescuentoCXP() As Boolean
        Dim bResultado As Boolean = False
        Dim Conexion As New SqlConnection(Empresa_Sistema.conexion), Error1 As String = ""

        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter

        With cmd
            .Connection = Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CXP_DESCUENTOS_CANCELA"

            sqlParametro = .Parameters.Add("@FOLIO_DESCUENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_DESCUENTO
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_CANCELO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@FECHA_CANCELACION", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_CANCELACION
            sqlParametro = .Parameters.Add("@CANCELADO_DESDE_INTERFAZ_DESCUENTOS", SqlDbType.Char) : sqlParametro.Value = "1"

            Try
                Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "CancelaDescuentoCXP", ex)
            Finally
                Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function AplicaDocumentoCXP() As Boolean
        'Dim cmd As New SqlCommand
        'Dim sqlParametro As SqlParameter
        'With cmd
        '    .Connection = _Conexion
        '    .CommandTimeout = 0
        '    .CommandType = CommandType.StoredProcedure
        '    .CommandText = "MP_CXC_APLICA_DOCUMENTO"

        '    sqlParametro = .Parameters.Add("@FOLIO_DESCUENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_DESCUENTO
        '    sqlParametro = .Parameters.Add("@FOLIO_REFERENCIA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_REFERENCIA
        '    sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PLAZA
        '    sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario

        '    Try
        '        Me._Conexion.Open()
        '        .ExecuteNonQuery()
        '        AplicaDocumentoCXC = True
        '    Catch ex As Exception
        '        HandleError(Me.Nombre_Clase, "AplicaDocumentoCXC", ex)
        '    Finally
        '        Me._Conexion.Close()
        '        cmd.Dispose()
        '        sqlParametro = Nothing
        '    End Try

        'End With
    End Function

    Public Function ActualizaFolioPoliza() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_DESCUENTO_CXP_ACTUALIZA_FOLIO_POLIZA"

            sqlParametro = .Parameters.Add("@FOLIO_DESCUENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_DESCUENTO

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._FOLIO_POLIZA = Me._FOLIO_DESCUENTO
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "ActualizaFolioPoliza", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function GeneraFolio() As String
        Dim sResultado As String = ""
        Try
            Me._oDocumento.CODIGO_DOCUMENTO = "NCG_CXP" & Usuario.Codigo_Plaza
            Me._oDocumento.GeneraFolio()
            sResultado = Me._oDocumento.FOLIO
            Me._FOLIO_DESCUENTO = _oDocumento.FOLIO
            Me._FOLIO_NUMERICO = CInt(_oDocumento.FOLIO_NUMERICO)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "New", ex)
        End Try
        Return sResultado
    End Function

    'Public Function DistribucionDescuentos(ByVal sFolioCxc As String, ByVal dImporteDescuento As Double) As System.Data.DataTable
    '    Dim dt As New DataTable
    '    Try
    '        Dim da As New SqlDataAdapter("MP_CXC_DESCUENTOS_PROMEDIA_DESCUENTO", Me._Conexion)
    '        da.SelectCommand.CommandType = CommandType.StoredProcedure

    '        With da.SelectCommand
    '            .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : .Parameters("@FOLIO_VENTA").Value = sFolioCxc
    '            .Parameters.Add("@IMPORTE_DESCUENTO", SqlDbType.Decimal) : .Parameters("@IMPORTE_DESCUENTO").Value = dImporteDescuento
    '        End With

    '        da.Fill(dt)
    '        dt.Columns.Remove("ID")
    '        dt.Columns.Remove("SALDO")
    '        dt.Columns.Remove("IMPORTE")
    '        dt.Columns.Remove("SUBIMPORTE")

    '    Catch ex As Exception
    '        HandleError(Me.Nombre_Clase, "DistribucionDescuentos", ex)
    '    Finally

    '    End Try
    '    DistribucionDescuentos = dt
    'End Function

#End Region

End Class
