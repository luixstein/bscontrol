Option Strict On

Imports System.Data.SqlClient

Public Class Class_ComercioExterior
#Region "Campos"
#Region "Campos de la tabla"
    Private _ID_CFDI_CCE_GLOBAL As Integer
    Private _FOLIO_VENTA As String
    Private _VERSION As String
    Private _MOTIVO_TRASLADO As String
    Private _TIPO_OPERACION As String
    Private _CLAVE_PEDIMIENTO As String
    Private _CERTIFICADO_ORIGEN As String
    Private _NUMERO_CERTIFICADO_ORIGEN As String
    Private _NUMERO_EXPORTADOR_CONFIABLE As String
    Private _INCOTERM As String
    Private _SUBDIVISION As String
    Private _OBSERVACIONES As String
    Private _TIPO_CAMBIO_USD As Decimal
    Private _TOTAL_USD As Decimal
#End Region

#Region "Campos ligados a la tabla"
    Private _LISTA_MERCANCIAS As String
    Private _LISTA_FIGURAS As String
    Private _Existe As Boolean
    Private _Nombre_Formato As String
#End Region

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
#End Region
#End Region

#Region "Propiedades"

#Region "Propiedades campos de la tabla"
    Public ReadOnly Property ID_CFDI_CCE_GLOBAL() As Integer
        Get
            Return Me._ID_CFDI_CCE_GLOBAL
        End Get
    End Property

    Public Property FOLIO_VENTA() As String
        Get
            Return Me._FOLIO_VENTA
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_VENTA = Value
        End Set
    End Property

    Public Property VERSION() As String
        Get
            Return Me._VERSION
        End Get
        Set(ByVal Value As String)
            Me._VERSION = Value
        End Set
    End Property

    Public Property MOTIVO_TRASLADO() As String
        Get
            Return Me._MOTIVO_TRASLADO
        End Get
        Set(ByVal Value As String)
            Me._MOTIVO_TRASLADO = Value
        End Set
    End Property

    Public Property TIPO_OPERACION() As String
        Get
            Return Me._TIPO_OPERACION
        End Get
        Set(ByVal Value As String)
            Me._TIPO_OPERACION = Value
        End Set
    End Property

    Public Property CLAVE_PEDIMIENTO() As String
        Get
            Return Me._CLAVE_PEDIMIENTO
        End Get
        Set(ByVal Value As String)
            Me._CLAVE_PEDIMIENTO = Value
        End Set
    End Property

    Public Property CERTIFICADO_ORIGEN() As String
        Get
            Return Me._CERTIFICADO_ORIGEN
        End Get
        Set(ByVal Value As String)
            Me._CERTIFICADO_ORIGEN = Value
        End Set
    End Property

    Public Property NUMERO_CERTIFICADO_ORIGEN() As String
        Get
            Return Me._NUMERO_CERTIFICADO_ORIGEN
        End Get
        Set(ByVal Value As String)
            Me._NUMERO_CERTIFICADO_ORIGEN = Value
        End Set
    End Property

    Public Property NUMERO_EXPORTADOR_CONFIABLE() As String
        Get
            Return Me._NUMERO_EXPORTADOR_CONFIABLE
        End Get
        Set(ByVal Value As String)
            Me._NUMERO_EXPORTADOR_CONFIABLE = Value
        End Set
    End Property

    Public Property INCOTERM() As String
        Get
            Return Me._INCOTERM
        End Get
        Set(ByVal Value As String)
            Me._INCOTERM = Value
        End Set
    End Property

    Public Property SUBDIVISION() As String
        Get
            Return Me._SUBDIVISION
        End Get
        Set(ByVal Value As String)
            Me._SUBDIVISION = Value
        End Set
    End Property

    Public Property OBSERVACIONES() As String
        Get
            Return Me._OBSERVACIONES
        End Get
        Set(ByVal Value As String)
            Me._OBSERVACIONES = Value
        End Set
    End Property

    Public Property TIPO_CAMBIO_USD() As Decimal
        Get
            Return Me._TIPO_CAMBIO_USD
        End Get
        Set(ByVal Value As Decimal)
            Me._TIPO_CAMBIO_USD = Value
        End Set
    End Property

    Public Property TOTAL_USD() As Decimal
        Get
            Return Me._TOTAL_USD
        End Get
        Set(ByVal Value As Decimal)
            Me._TOTAL_USD = Value
        End Set
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

    Public Property LISTA_FIGURAS() As String
        Get
            Return Me._LISTA_FIGURAS
        End Get
        Set(ByVal Value As String)
            Me._LISTA_FIGURAS = Value
        End Set
    End Property

    Public Property LISTA_MERCANCIAS() As String
        Get
            Return Me._LISTA_MERCANCIAS
        End Get
        Set(ByVal Value As String)
            Me._LISTA_MERCANCIAS = Value
        End Set
    End Property
#End Region

#Region "Propiedades de sistema"
    Private ReadOnly Property NombreClase() As String
        Get
            Return "Class_CartaPorte"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection(Empresa_Sistema.conexion)
    End Sub

    Public Sub New(ByVal iID_CFDI_CCE_GLOBAL As Integer)
        Me.New()
        Try
            Me._ID_CFDI_CCE_GLOBAL = iID_CFDI_CCE_GLOBAL
            If Me.Consultar("ID_CFDI_CCE_GLOBAL") = True Then
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me.NombreClase, "New", ex)
        End Try
    End Sub

    Public Sub New(ByVal sFOLIO_VENTA As String)
        Me.New()
        Try
            Me._FOLIO_VENTA = sFOLIO_VENTA
            If Me.Consultar("FOLIO_VENTA") = True Then
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me.NombreClase, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function Grabar(ByVal sAccion As String) As Boolean
        Const sProcedure As String = "Grabar"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter

        Try
            With cmd
                .Connection = Me._Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MP_CFDI_CCE_GRABA"

                sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = sAccion 'INSERTAR,ACTUALIZAR
                sqlParametro = .Parameters.Add("@ID_CFDI_CCE_GLOBAL", SqlDbType.Int) : sqlParametro.Value = Me._ID_CFDI_CCE_GLOBAL : sqlParametro.Direction = ParameterDirection.InputOutput
                sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_VENTA
                sqlParametro = .Parameters.Add("@VERSION", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._VERSION
                sqlParametro = .Parameters.Add("@MOTIVO_TRASLADO", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._MOTIVO_TRASLADO
                sqlParametro = .Parameters.Add("@TIPO_OPERACION", SqlDbType.Char, 1) : sqlParametro.Value = Me._TIPO_OPERACION
                sqlParametro = .Parameters.Add("@CLAVE_PEDIMIENTO", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CLAVE_PEDIMIENTO
                sqlParametro = .Parameters.Add("@CERTIFICADO_ORIGEN", SqlDbType.Char, 1) : sqlParametro.Value = Me._CERTIFICADO_ORIGEN
                sqlParametro = .Parameters.Add("@NUMERO_CERTIFICADO_ORIGEN", SqlDbType.NVarChar, 40) : sqlParametro.Value = Me._NUMERO_CERTIFICADO_ORIGEN
                sqlParametro = .Parameters.Add("@NUMERO_EXPORTADOR_CONFIABLE", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._NUMERO_EXPORTADOR_CONFIABLE
                sqlParametro = .Parameters.Add("@INCOTERM", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._INCOTERM
                sqlParametro = .Parameters.Add("@SUBDIVISION", SqlDbType.Char, 1) : sqlParametro.Value = Me._SUBDIVISION
                sqlParametro = .Parameters.Add("@OBSERVACIONES", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._OBSERVACIONES
                sqlParametro = .Parameters.Add("@TIPO_CAMBIO_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._TIPO_CAMBIO_USD
                sqlParametro = .Parameters.Add("@TOTAL_USD", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL_USD
                sqlParametro = .Parameters.Add("@LISTA_FIGURAS", SqlDbType.NVarChar, -1) : sqlParametro.Value = Me._LISTA_FIGURAS
                sqlParametro = .Parameters.Add("@LISTA_MERCANCIAS", SqlDbType.NVarChar, -1) : sqlParametro.Value = Me._LISTA_MERCANCIAS

                Me._Conexion.Open()
                .ExecuteNonQuery()

                If sAccion = "INSERTAR" Then
                    Me._ID_CFDI_CCE_GLOBAL = CInt(.Parameters("@ID_CFDI_CCE_GLOBAL").Value.ToString) 'Se asegura el cambio del folio
                End If

                bResultado = True
            End With

        Catch ex As Exception
            HandleError(Me.NombreClase, sProcedure, ex)
        Finally
            Me._Conexion.Close()
            cmd.Dispose()
            sqlParametro = Nothing
        End Try

        Return bResultado
    End Function

    Private Function Consultar(ByVal sConsultarPor As String) As Boolean
        Const sProcedure As String = "Consultar"
        Dim bResultado As Boolean = False
        Dim dReader As SqlDataReader, sSQL As String = ""

        Select Case sConsultarPor
            Case "ID_CFDI_CCE_GLOBAL"
                sSQL = "SELECT * FROM CFDI_CCE_GLOBAL WHERE ID_CFDI_CCE_GLOBAL=" & Me._ID_CFDI_CCE_GLOBAL.ToString
            Case "FOLIO_VENTA"
                sSQL = "SELECT * FROM CFDI_CCE_GLOBAL WHERE FOLIO_VENTA='" & sReplace(Me._FOLIO_VENTA) & "'"
        End Select

        Dim cmd As New SqlCommand(sSQL, Me._Conexion)

        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._ID_CFDI_CCE_GLOBAL = CInt("" & dReader("ID_CFDI_CCE_GLOBAL").ToString())
                    Me._FOLIO_VENTA = "" & dReader("FOLIO_VENTA").ToString()
                    Me._VERSION = "" & dReader("VERSION").ToString()
                    Me._MOTIVO_TRASLADO = "" & dReader("MOTIVO_TRASLADO").ToString()
                    Me._TIPO_OPERACION = "" & dReader("TIPO_OPERACION").ToString()
                    Me._CLAVE_PEDIMIENTO = "" & dReader("CLAVE_PEDIMIENTO").ToString()
                    Me._CERTIFICADO_ORIGEN = "" & dReader("CERTIFICADO_ORIGEN").ToString()
                    Me._NUMERO_CERTIFICADO_ORIGEN = "" & dReader("NUMERO_CERTIFICADO_ORIGEN").ToString()
                    Me._NUMERO_EXPORTADOR_CONFIABLE = "" & dReader("NUMERO_EXPORTADOR_CONFIABLE").ToString()
                    Me._INCOTERM = "" & dReader("INCOTERM").ToString()
                    Me._SUBDIVISION = "" & dReader("SUBDIVISION").ToString()
                    Me._OBSERVACIONES = "" & dReader("OBSERVACIONES").ToString()
                    Me._TIPO_CAMBIO_USD = CDec(dReader("TIPO_CAMBIO_USD").ToString())
                    Me._TOTAL_USD = CDec(dReader("TOTAL_USD").ToString())
                    Me._Nombre_Formato = "" '& Trim(dReader("NOMBRE_FORMATO").ToString) 'Nota esta fijo puesto que este no es un documento del catálogo de documentos.

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.NombreClase, sProcedure, ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With

        Return bResultado
    End Function

    Public Function ObtenerDetalleMercancias() As DataTable
        Const sProcedure As String = "ObtenerDetalleMercancias"
        Dim dTabla As New DataTable("detalle")
        Dim sSQL As String

        Try
            'iGyMerBienTransportado,iGyMerDescripcion,iGyMerCantidad,iGyMerClaveUnidad,iGyMerNombreUnidad,iGyMerUnidad,iGyMerPesoEnKG
            sSQL = "SELECT R.CODIGO_PRODUCTO_SERVICIO,R.DESCRIPCION,R.CANTIDAD,R.CODIGO_UNIDAD,U.NOMBRE_UNIDAD,R.UNIDAD,R.PESO_EN_KG " &
                    "FROM CFDI_CCE_DETALLE_MERCANCIAS R " &
                    "INNER JOIN CFDI_CAT_UNIDADES U ON(R.CODIGO_UNIDAD=U.CODIGO_UNIDAD)" &
                    "WHERE R.ID_CFDI_CCE_GLOBAL=@ID_CFDI_CCE_GLOBAL " &
                    "ORDER BY R.ID_CFDI_CARTA_PORTE_DETALLE_MERCANCIAS"

            Using da As New SqlDataAdapter(sSQL, Me._Conexion)
                da.SelectCommand.CommandType = CommandType.Text

                With da.SelectCommand
                    .Parameters.Add("@ID_CFDI_CCE_GLOBAL", SqlDbType.Int).Value = Me._ID_CFDI_CCE_GLOBAL
                End With

                da.Fill(dTabla)
            End Using

        Catch ex As Exception
            HandleError(Me.NombreClase, sProcedure, ex)
        End Try

        Return dTabla
    End Function

    Public Function ObtenerDetalleFiguras() As DataTable
        Const sProcedure As String = "ObtenerDetalleFiguras"
        Dim dTabla As New DataTable("detalle")
        Dim sSQL As String

        Try
            sSQL = "SELECT R.CODIGO_FIGURA_TRANSPORTE,F.CODIGO_TIPO_FIGURA_TRANSPORTE,TF.NOMBRE_TIPO_FIGURA_TRANSPORTE,F.NOMBRE_FIGURA_TRANSPORTE,F.RFC,F.NUMERO_LICENCIA, " &
                    "LTRIM(UPPER( " &
                    "CASE WHEN LEN(F.CALLE)>0 THEN F.CALLE ELSE '' END + CASE WHEN LEN(F.NUMERO_EXTERIOR)>0 THEN ' ' + F.NUMERO_EXTERIOR ELSE '' END + CASE WHEN LEN(F.NUMERO_INTERIOR)>0 THEN ' ' + F.NUMERO_INTERIOR ELSE '' END + " &
                    "CASE WHEN LEN(COL.NOMBRE_COLONIA)>0 THEN ' ' + COL.NOMBRE_COLONIA ELSE '' END + CASE WHEN LEN(LOC.NOMBRE_LOCALIDAD)>0 THEN ' ' + LOC.NOMBRE_LOCALIDAD ELSE '' END + " &
                    "CASE WHEN M.NOMBRE_MUNICIPIO IS NOT NULL THEN ' ' + M.NOMBRE_MUNICIPIO ELSE '' END + ' ' + E.NOMBRE_ESTADO + ' ' + P.NOMBRE_PAIS + ' ' + F.CODIGO_POSTAL)) DOMICILIO_COMPLETO " &
                    "FROM CFDI_CARTA_PORTE_DETALLE_FIGURAS_TRANSPORTE R " &
                    "INNER JOIN CFDI_CCE_FIGURAS F ON(R.CODIGO_FIGURA_TRANSPORTE=F.CODIGO_FIGURA_TRANSPORTE) " &
                    "INNER JOIN CFDI_CAT_TIPOS_FIGURAS_TRANSPORTE TF ON(F.CODIGO_TIPO_FIGURA_TRANSPORTE=TF.CODIGO_TIPO_FIGURA_TRANSPORTE) " &
                    "INNER JOIN CAT_PAISES P ON(F.CLAVE_PEDIMIENTO_DOMICILIO=P.CLAVE_PEDIMIENTO) " &
                    "INNER JOIN SIS_ESTADOS E ON(F.CODIGO_ESTADO_SAT=E.CODIGO_ESTADO_SAT) " &
                    "LEFT JOIN CAT_MUNICIPIOS M ON(F.CODIGO_MUNICIPIO=M.CODIGO_MUNICIPIO) " &
                    "LEFT JOIN CFDI_CAT_COLONIAS COL ON(F.ID_COLONIA=COL.ID_COLONIA) " &
                    "LEFT JOIN CFDI_CAT_LOCALIDADES LOC ON(F.ID_LOCALIDAD=LOC.ID_LOCALIDAD) " &
                    "WHERE R.ID_CFDI_CCE_GLOBAL=@ID_CFDI_CCE_GLOBAL " &
                    "ORDER BY R.ID_CFDI_CARTA_PORTE_DETALLE_FIGURAS_TRANSPORTE"

            Using da As New SqlDataAdapter(sSQL, Me._Conexion)
                da.SelectCommand.CommandType = CommandType.Text

                With da.SelectCommand
                    .Parameters.Add("@ID_CFDI_CCE_GLOBAL", SqlDbType.Int).Value = Me._ID_CFDI_CCE_GLOBAL
                End With

                da.Fill(dTabla)
            End Using

        Catch ex As Exception
            HandleError(Me.NombreClase, sProcedure, ex)
        End Try

        Return dTabla
    End Function

#End Region

End Class
