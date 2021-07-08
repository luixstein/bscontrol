Option Explicit On
Option Strict On

Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Class_CXC_Pago_CFDI_Global

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_CFDI_PAGOS_CXC_GLOBAL As Integer
    Private _FOLIO_PAGO As String
    Private _ESTATUS_PAGO As String
    Private _FOLIO_NUMERICO As String
    Private _FOLIO_BANCO As String
    Private _FECHA_SERVIDOR As Date
    Private _CODIGO_CLIENTE As String
    Private _ES_A_PUBLICO_GENERAL As Boolean
    Private _FECHA_PAGO As Date
    Private _MONTO As Decimal
    Private _IDCATALOGO_FOLIO_FELECTRONICA As String
    Private _ID_SIS_CFD_CATALOGO_CERTIFICADOS As String
    Private _ENVIADA_POR_CORREO As Boolean
    Private _VERSION_ESQUEMA_XML As String
    Private _NUMERO_CERTIFICADO_DIGITAL As String
    Private _CADENA_ORIGINAL As String
    Private _SELLO_DIGITAL As String
    Private _TIMBRADO_CFDI As String
    Private _TIMBRADO_DESCARTADO As String
    Private _FOLIO_FISCAL_SAT As String
    Private _FECHA_TIMBRADO_SAT As String
    Private _NUMERO_SERIE_CERTIFICADO_SAT As String
    Private _SELLO_SAT As String
    Private _CBB_IMAGE As String
    Private _FOLIO_FISCAL_CANCELACION_SAT As String
    Private _ESTATUS_CANCELACION_CFDI As String
    Private _ENVIADO_AUTOMATICAMENTE As Boolean
    Private _CANCELACION_ENVIADA_AUTOMATICAMENTE As Boolean
    Private _CODIGO_MOTIVO_CANCELACION As String
    Private _MOTIVO_CANCELACION As String
    Private _CODIGO_REGIMEN_FISCAL As String
    Private _CODIGO_USO_CFDI As String
    Private _TIPO_CADENA_PAGO As String
    Private _CERTIFICADO_PAGO As String
    Private _CADENA_PAGO As String
    Private _SELLO_PAGO As String
    Private _RFCPROVCERTIF As String
    Private _LEYENDA As String
#End Region

#Region "Campos ligados a la tabla"
    Private _EXISTE As Boolean 'lectura
    Private _NOMBRE_FORMATO As String
    Private _SERIE As String
    Private _FELECTRONICA_CER As String
    Private _FELECTRONICA_KEY As String
    Private _FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA As String
    Private _CODIGO_PLAZA As String
#End Region

#Region "Campos de sistema"
    Private _Conexion As SqlConnection

    Private Declare Function IsNetworkAlive Lib "SENSAPI.DLL" (ByRef lpdwFlags As Long) As Long
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"

    'Public Property FOLIO_VENTA() As String
    '    Get
    '        Return Me._FOLIO_VENTA
    '    End Get
    '    Set(ByVal Value As String)
    '        Me._FOLIO_VENTA = Value
    '    End Set
    'End Property

    Public ReadOnly Property ID_CFDI_PAGOS_CXC_GLOBAL() As Integer
        Get
            Return Me._ID_CFDI_PAGOS_CXC_GLOBAL
        End Get
    End Property

    Public ReadOnly Property FOLIO_PAGO() As String
        Get
            Return Me._FOLIO_PAGO
        End Get
    End Property
    Public ReadOnly Property ESTATUS_PAGO() As String
        Get
            Return Me._ESTATUS_PAGO
        End Get
    End Property

    Public ReadOnly Property FOLIO_NUMERICO() As String
        Get
            Return Me._FOLIO_NUMERICO
        End Get
    End Property

    Public ReadOnly Property FOLIO_BANCO() As String
        Get
            Return Me._FOLIO_BANCO
        End Get
    End Property

    Public ReadOnly Property FECHA_SERVIDOR() As Date
        Get
            Return Me._FECHA_SERVIDOR
        End Get
    End Property

    Public ReadOnly Property CODIGO_CLIENTE() As String
        Get
            Return Me._CODIGO_CLIENTE
        End Get
    End Property

    Public ReadOnly Property ES_A_PUBLICO_GENERAL() As Boolean
        Get
            Return Me._ES_A_PUBLICO_GENERAL
        End Get
    End Property

    Public ReadOnly Property FECHA_PAGO() As Date
        Get
            Return Me._FECHA_PAGO
        End Get
    End Property

    Public ReadOnly Property MONTO() As Decimal
        Get
            Return Me._MONTO
        End Get
    End Property

    Public ReadOnly Property _DCATALOGO_FOLIO_FELECTRONICA() As String
        Get
            Return Me._IDCATALOGO_FOLIO_FELECTRONICA
        End Get
    End Property

    Public ReadOnly Property ID_SIS_CFD_CATALOGO_CERTIFICADOS() As String
        Get
            Return Me._ID_SIS_CFD_CATALOGO_CERTIFICADOS
        End Get
    End Property

    Public ReadOnly Property ENVIADA_POR_CORREO() As Boolean
        Get
            Return Me._ENVIADA_POR_CORREO
        End Get
    End Property

    Public ReadOnly Property VERSION_ESQUEMA_XML() As String
        Get
            Return Me._VERSION_ESQUEMA_XML
        End Get
    End Property

    Public ReadOnly Property NUMERO_CERTIFICADO_DIGITAL() As String
        Get
            Return Me._NUMERO_CERTIFICADO_DIGITAL
        End Get
    End Property

    Public ReadOnly Property CADENA_ORIGINAL() As String
        Get
            Return Me._CADENA_ORIGINAL
        End Get
    End Property

    Public ReadOnly Property SELLO_DIGITAL() As String
        Get
            Return Me._SELLO_DIGITAL
        End Get
    End Property

    Public ReadOnly Property TIMBRADO_CFDI() As String
        Get
            Return Me._TIMBRADO_CFDI
        End Get
    End Property

    Public ReadOnly Property TIMBRADO_DESCARTADO() As String
        Get
            Return Me._TIMBRADO_DESCARTADO
        End Get
    End Property

    Public ReadOnly Property FOLIO_FISCAL_SAT() As String
        Get
            Return Me._FOLIO_FISCAL_SAT
        End Get
    End Property

    Public ReadOnly Property FECHA_TIMBRADO_SAT() As String
        Get
            Return Me._FECHA_TIMBRADO_SAT
        End Get
    End Property

    Public ReadOnly Property NUMERO_SERIE_CERTIFICADO_SAT() As String
        Get
            Return Me._NUMERO_SERIE_CERTIFICADO_SAT
        End Get
    End Property

    Public ReadOnly Property SELLO_SAT() As String
        Get
            Return Me._SELLO_SAT
        End Get
    End Property

    Public ReadOnly Property CBB_IMAGE() As String
        Get
            Return Me._CBB_IMAGE
        End Get
    End Property

    Public ReadOnly Property FOLIO_FISCAL_CANCELACION_SAT() As String
        Get
            Return Me._FOLIO_FISCAL_CANCELACION_SAT
        End Get
    End Property

    Public ReadOnly Property ESTATUS_CANCELACION_CFDI() As String
        Get
            Return Me._ESTATUS_CANCELACION_CFDI
        End Get
    End Property

    Public ReadOnly Property ENVIADO_AUTOMATICAMENTE() As Boolean
        Get
            Return Me._ENVIADO_AUTOMATICAMENTE
        End Get
    End Property

    Public ReadOnly Property CANCELACION_ENVIADA_AUTOMATICAMENTE() As Boolean
        Get
            Return Me._CANCELACION_ENVIADA_AUTOMATICAMENTE
        End Get
    End Property

    Public ReadOnly Property CODIGO_MOTIVO_CANCELACION() As String
        Get
            Return Me._CODIGO_MOTIVO_CANCELACION
        End Get
    End Property

    Public Property MOTIVO_CANCELACION() As String
        Get
            Return Me._MOTIVO_CANCELACION
        End Get
        Set(value As String)
            Me._MOTIVO_CANCELACION = value
        End Set
    End Property

    Public ReadOnly Property CODIGO_REGIMEN_FISCAL() As String
        Get
            Return Me._CODIGO_REGIMEN_FISCAL
        End Get
    End Property

    Public ReadOnly Property CODIGO_USO_CFDI() As String
        Get
            Return Me._CODIGO_USO_CFDI
        End Get
    End Property

    Public ReadOnly Property TIPO_CADENA_PAGO() As String
        Get
            Return Me._TIPO_CADENA_PAGO
        End Get
    End Property

    Public ReadOnly Property CERTIFICADO_PAGO() As String
        Get
            Return Me._CERTIFICADO_PAGO
        End Get
    End Property

    Public ReadOnly Property CADENA_PAGO() As String
        Get
            Return Me._CADENA_PAGO
        End Get
    End Property

    Public ReadOnly Property SELLO_PAGO() As String
        Get
            Return Me._SELLO_PAGO
        End Get
    End Property

    Public ReadOnly Property RFCPROVCERTIF() As String
        Get
            Return Me._RFCPROVCERTIF
        End Get
    End Property

    Public ReadOnly Property LEYENDA() As String
        Get
            Return Me._LEYENDA
        End Get
    End Property

#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property EXISTE() As Boolean
        Get
            Return Me._EXISTE
        End Get
    End Property

    Public ReadOnly Property NOMBRE_FORMATO() As String
        Get
            Return Me._NOMBRE_FORMATO
        End Get
    End Property

    Public ReadOnly Property SERIE() As String
        Get
            Return Me._SERIE
        End Get
    End Property

    'Public ReadOnly Property CODIGO_MODULO() As String
    '    Get
    '        Return "VTA"
    '    End Get
    'End Property

    Public ReadOnly Property FELECTRONICA_CER() As String
        Get
            Return Me._FELECTRONICA_CER
        End Get
    End Property

    Public ReadOnly Property FELECTRONICA_KEY() As String
        Get
            Return Me._FELECTRONICA_KEY
        End Get
    End Property

    Public ReadOnly Property FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA() As String
        Get
            Return Me._FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA
        End Get
    End Property

    Public ReadOnly Property CODIGO_PLAZA() As String
        Get
            Return Me._CODIGO_PLAZA
        End Get
    End Property

#End Region

#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_CXC_Pago_CFDI_Global"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection(Empresa_Sistema.conexion)
        'oVentasDetalle = New Class_Ventas_Detalle
    End Sub

    Public Sub New(ByVal FOLIO_PAGO As String)
        Me.New()
        Try
            Me._FOLIO_PAGO = FOLIO_PAGO
            If Me.Consultar = False Then
                'Throw New Exception("El documento de venta no existe.")
            Else
                Me._EXISTE = True
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False

        Dim sSQL As String = ""

        sSQL = "SELECT G.*, " &
        "" &
        "SCCC.FELECTRONICA_CER,SCCC.FELECTRONICA_KEY,SCCC.CONTRASEÑA FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA,B.CODIGO_PLAZA,DOC.NOMBRE_FORMATO " &
        "FROM CFDI_PAGOS_CXC_GLOBAL G " &
        "INNER JOIN BANCOS_GLOBAL B ON(G.FOLIO_BANCO=B.FOLIO_BANCO) " &
        "LEFT JOIN SIS_CFD_CATALOGO_CERTIFICADOS SCCC ON(G.ID_SIS_CFD_CATALOGO_CERTIFICADOS=SCCC.ID_SIS_CFD_CATALOGO_CERTIFICADOS) " &
        "INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO DOC ON(G.CODIGO_DOCUMENTO=DOC.CODIGO_DOCUMENTO) " &
        "WHERE G.FOLIO_PAGO='" & sReplace(Me._FOLIO_PAGO) & "' "

        Dim cmd As New SqlCommand(sSQL, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._ID_CFDI_PAGOS_CXC_GLOBAL = CInt(dReader("ID_CFDI_PAGOS_CXC_GLOBAL").ToString)
                    Me._FOLIO_PAGO = dReader("FOLIO_PAGO").ToString
                    Me._ESTATUS_PAGO = dReader("ESTATUS_PAGO").ToString
                    Me._FOLIO_NUMERICO = dReader("FOLIO_NUMERICO").ToString
                    Me._FOLIO_BANCO = dReader("FOLIO_BANCO").ToString
                    Me._FECHA_SERVIDOR = CDate(dReader("FECHA_SERVIDOR").ToString)
                    Me._CODIGO_CLIENTE = dReader("CODIGO_CLIENTE").ToString
                    Me._ES_A_PUBLICO_GENERAL = CBool(dReader("ES_A_PUBLICO_GENERAL").ToString)
                    Me._FECHA_PAGO = CDate(dReader("FECHA_PAGO").ToString)
                    Me._MONTO = CDec(dReader("MONTO").ToString)
                    Me._ID_SIS_CFD_CATALOGO_CERTIFICADOS = "" & dReader("ID_SIS_CFD_CATALOGO_CERTIFICADOS").ToString
                    Me._ENVIADA_POR_CORREO = CBool(dReader("ENVIADA_POR_CORREO").ToString)
                    Me._VERSION_ESQUEMA_XML = "" & dReader("VERSION_ESQUEMA_XML").ToString
                    Me._NUMERO_CERTIFICADO_DIGITAL = "" & dReader("NUMERO_CERTIFICADO_DIGITAL").ToString
                    Me._CADENA_ORIGINAL = "" & dReader("CADENA_ORIGINAL").ToString
                    Me._SELLO_DIGITAL = "" & dReader("SELLO_DIGITAL").ToString
                    Me._TIMBRADO_CFDI = dReader("TIMBRADO_CFDI").ToString
                    Me._TIMBRADO_DESCARTADO = dReader("TIMBRADO_DESCARTADO").ToString
                    Me._FOLIO_FISCAL_SAT = "" & dReader("FOLIO_FISCAL_SAT").ToString
                    Me._FECHA_TIMBRADO_SAT = "" & dReader("FECHA_TIMBRADO_SAT").ToString
                    Me._NUMERO_SERIE_CERTIFICADO_SAT = "" & dReader("NUMERO_SERIE_CERTIFICADO_SAT").ToString
                    Me._SELLO_SAT = "" & dReader("SELLO_SAT").ToString
                    If txtLEN("" & dReader("CBB_IMAGE").ToString) = True Then
                        Me._CBB_IMAGE = "" & dReader("CBB_IMAGE").ToString
                    Else
                        Me._CBB_IMAGE = ""
                    End If
                    Me._FOLIO_FISCAL_CANCELACION_SAT = "" & dReader("FOLIO_FISCAL_CANCELACION_SAT").ToString
                    Me._ESTATUS_CANCELACION_CFDI = dReader("ESTATUS_CANCELACION_CFDI").ToString
                    Me._ENVIADO_AUTOMATICAMENTE = CBool(dReader("ENVIADO_AUTOMATICAMENTE").ToString)
                    Me._CANCELACION_ENVIADA_AUTOMATICAMENTE = CBool(dReader("CANCELACION_ENVIADA_AUTOMATICAMENTE").ToString)
                    Me._CODIGO_MOTIVO_CANCELACION = "" & dReader("CODIGO_MOTIVO_CANCELACION").ToString
                    Me._MOTIVO_CANCELACION = "" & dReader("MOTIVO_CANCELACION").ToString
                    Me._CODIGO_REGIMEN_FISCAL = "" & dReader("CODIGO_REGIMEN_FISCAL").ToString
                    Me._CODIGO_USO_CFDI = "" & dReader("CODIGO_USO_CFDI").ToString
                    Me._TIPO_CADENA_PAGO = "" & dReader("TIPO_CADENA_PAGO").ToString
                    Me._CERTIFICADO_PAGO = "" & dReader("CERTIFICADO_PAGO").ToString
                    Me._CADENA_PAGO = "" & dReader("CADENA_PAGO").ToString
                    Me._SELLO_PAGO = "" & dReader("SELLO_PAGO").ToString
                    Me._RFCPROVCERTIF = "" & dReader("RFCPROVCERTIF").ToString
                    Me._LEYENDA = "" & dReader("LEYENDA").ToString

                    Me._SERIE = "" & dReader("SERIE").ToString
                    Me._FELECTRONICA_CER = "" & dReader("FELECTRONICA_CER").ToString
                    Me._FELECTRONICA_KEY = "" & dReader("FELECTRONICA_KEY").ToString
                    Me._FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA = IIf(txtLEN("" & dReader("FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA").ToString) = True, Decrypt("" & dReader("FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA").ToString, "r7"), "").ToString
                    Me._CODIGO_PLAZA = "" & dReader("CODIGO_PLAZA").ToString
                    Me._NOMBRE_FORMATO = "" & dReader("NOMBRE_FORMATO").ToString

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

    Public Function GeneraPagoElectronico(ByVal bMensajes As Boolean, ByVal bGenerarPDF As Boolean) As Boolean
        Const sProcedure As String = "GeneraPagoElectronico"
        Dim bResultado As Boolean = False
        Dim sRutaXML As String

        Try
            sRutaXML = sFelectronicaCarpetaXMLPDF & "\" & Me._FOLIO_PAGO & ".xml"

            If Me._TIMBRADO_CFDI = "0" Then
                bResultado = FacturacionElectronica33.GeneraPagoElectronico33(Me, bMensajes, sRutaXML)

                If bResultado = False Then
                    MsgBox("Los datos digitales del documento no fueron generados correctamente. Avíse al depto. de sistemas.", vbExclamation, sProcedure)
                Else
                    If bGenerarPDF = True Then
                        Me.ExportarAPdf()
                    End If
                End If
                'Else
                '    Me.RecuperarFacturaElectronicaLocal(bMensajes)
            Else
                MsgBox("El pago " & Me._FOLIO_PAGO & " ya esta timbrado.", vbExclamation, sProcedure)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Public Function CancelarTimbre() As Boolean
        Const sProcedure As String = "CancelarTimbre"
        Dim bResultado As Boolean = False

        Try
            If Me.Consultar() = False Then 'Refrescamos el documento para tener los datos mas nuevos.
                Return False
            End If

            If Me._ESTATUS_PAGO <> "C" Then
                MsgBox("El documento no esta cancelado.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me._TIMBRADO_DESCARTADO = "1" Then
                MsgBox("El timbre esta descartado.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me._ESTATUS_CANCELACION_CFDI = "1" Then
                MsgBox("El timbre ya esta cancelado.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            Dim sCadenaXML As String = Me.RecuperaXML()
            If txtLEN(sCadenaXML) = False Then
                MsgBox("No se logró recuperar el xml para poder cancelar el timbre.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            bResultado = CancelarCFDI(Me.FOLIO_PAGO, Me.SERIE, CInt(Me.FOLIO_NUMERICO), Me.FOLIO_FISCAL_SAT, Me.TIMBRADO_CFDI, TipoComprobante.PAGO_CXC, sCadenaXML)

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "CancelarTimbre", ex)
        End Try

        Return bResultado
    End Function

    Public Sub Imprimir()
        Dim sProcedure As String = "Imprimir"
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            If Me._EXISTE = False Then
                MsgBox("NO FOLIO NO EXISTE", MsgBoxStyle.Exclamation, sProcedure)
                Exit Sub
            End If

            oReporte = New Class_Reporte(Me._NOMBRE_FORMATO, Rpt, False)

            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@FOLIO_PAGO", Me._FOLIO_PAGO)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "Imprimir", ex)
        End Try
    End Sub

    Public Function ExportarAPdf(Optional ByVal sRutaPDF As String = "") As Boolean
        Dim bResultado As Boolean = False
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte

        Try
            If txtLEN(sRutaPDF) = False Then 'Si no trae un nombre en especifico lo crea con el nombre del folio
                sRutaPDF = sFelectronicaCarpetaXMLPDF & "\" & Me._FOLIO_PAGO.ToString & ".PDF"
            End If

            oReporte = New Class_Reporte(Me._NOMBRE_FORMATO, Rpt, False)

            Rpt.SetParameterValue("@FOLIO_PAGO", Me._FOLIO_PAGO)

            If Not oReporte.RptCargado Then
                Exit Function
            End If

            Rpt.ExportToDisk(ExportFormatType.PortableDocFormat, sRutaPDF)

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ExportarAPdf", ex)
        Finally
            oReporte = Nothing
        End Try

        Return bResultado
    End Function

    Public Function EnviarCorreo() As Boolean
        Dim sProcedure As String = "EnviarCorreo"
        Dim Ret As Long, tabla() As String, n As Integer, archivos As String = sFelectronicaCarpetaXMLPDF & "\"
        Dim oCliente As Class_CatClientes
        Dim MyMailMsg As New Net.Mail.MailMessage

        Try
            oCliente = New Class_CatClientes(Me._CODIGO_CLIENTE)

            If txtLEN(oCliente.CORREO_CLIENTE_PAGOS) = False Then
                MsgBox("El cliente no tiene correo para pagos configurado.", MsgBoxStyle.Exclamation, sProcedure)
                Dim oActualizar As New Catalogo_Clientes_ActualizaCorreo(oCliente, True)
                oActualizar.ShowDialog()
                If oActualizar.bActualizado = False Then
                    Return False
                End If
            End If

            tabla = Split(oCliente.CORREO_CLIENTE_PAGOS, ";")

            For n = 0 To UBound(tabla, 1)
                If IsEmailSyntaxValid(tabla(n)) = False Then
                    MsgBox("El correo no es válido, favor de verificar.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            Next

            'Si el Api retorna 0 quiere decir que no hay ningun tipo de conexión de Red
            If IsNetworkAlive(Ret) = 0 Then
                MsgBox("No existe conexión a internet. Por favor revise su conexión e inténtelo nuevamente.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If txtLEN(Usuario.CORREO_USUARIO) = False Then
                MsgBox("El usuario : " & Usuario.Nombre_Usuario & " no tiene correo configurado.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            MyMailMsg.Subject = "CFDI DE PAGOS A " & Empresa_Sistema.NOMBRE_EMPRESA

            For n = 0 To UBound(tabla, 1)
                MyMailMsg.To.Add(tabla(n))
            Next

            MyMailMsg.From = New MailAddress(Usuario.CORREO_USUARIO.ToString)
            MyMailMsg.Priority = MailPriority.Normal
            MyMailMsg.Body = "PAGO " & Me._FOLIO_PAGO

            'MyMailMsg.IsBodyHtml = False
            'MyMailMsg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure

            Dim SMTP As New SmtpClient()
            SMTP.Host = Usuario.SERVIDOR_CORREO_REMITENTE
            SMTP.EnableSsl = Usuario.USAR_SSL_REMITENTE
            SMTP.Port = CInt(Usuario.PUERTO_REMITENTE)

            SMTP.Credentials = New System.Net.NetworkCredential(Usuario.CORREO_USUARIO.ToString, Usuario.CLAVE_CORREO.ToString)

            Dim sRutaXML As String = "", sNombreXmlTimbrado As String = ""
            Dim sRutaPDF As String = ""

            If txtLEN(oCliente.FORMATO_NOMBRE_XML) = True Then
                Select Case oCliente.FORMATO_NOMBRE_XML
                    Case "RFCemisor-Serie-FolioNumerico"
                        sNombreXmlTimbrado = Empresa_Sistema.RFC & "-" & Me._SERIE & "-" & Me._FOLIO_NUMERICO
                    Case "RFCemisor-Fecha-SerieFolio"
                        sNombreXmlTimbrado = Empresa_Sistema.RFC & Format(Me._FECHA_PAGO, "yyyyddMM") & Me._SERIE & Me._FOLIO_NUMERICO
                End Select
            Else
                sNombreXmlTimbrado = Me._FOLIO_PAGO
            End If

            sRutaXML = sFelectronicaCarpetaXmlsTimbrados & "\" & sNombreXmlTimbrado & ".xml"
            sRutaPDF = archivos.ToString & sNombreXmlTimbrado & ".PDF"

            If Me.RecuperaXML(sRutaXML) = True Then
                If Me.ExportarAPdf(sRutaPDF) = False Then
                    MsgBox("No se logró generar el PDF del documento : " & Me._FOLIO_PAGO & ". Avíse al depto. de sistemas.", vbExclamation, sProcedure)
                    Return False
                End If
            Else
                MsgBox("No se logró recuperar el XML del documento : " & Me._FOLIO_PAGO & ". Avíse al depto. de sistemas.", vbExclamation, sProcedure)
                Return False
            End If

            Me.MarcaEnviadoxCorreo(Me._FOLIO_PAGO)

            Dim msa As New Attachment(sRutaPDF)
            MyMailMsg.Attachments.Add(msa)
            msa = New Attachment(sRutaXML)
            MyMailMsg.Attachments.Add(msa)

            ServicePointManager.ServerCertificateValidationCallback = Function(s As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) True

            SMTP.Send(MyMailMsg)

            MsgBox("Tu E-Mail se ha enviado exitosamente.", MsgBoxStyle.Information, sProcedure)

            Return True

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, sProcedure, ex)
        End Try
    End Function

    Public Function MarcaEnviadoxCorreo(ByVal sFolio As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CFDI_PAGOS_CXC_MARCA_CORREO_ENVIADO"

            sqlParametro = .Parameters.Add("@FOLIO_PAGO", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolio

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "MarcaEnviadoxCorreo", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function RecuperaXML(ByVal sRutaXML As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        Dim docXml As Xml.XmlDocument = New Xml.XmlDocument

        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CFDI_PAGOS_CXC_RECUPERA_CADENA_XML"

            sqlParametro = .Parameters.Add("@FOLIO_PAGO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_PAGO
            sqlParametro = .Parameters.Add("@CADENA_XML", SqlDbType.Xml) : sqlParametro.Direction = ParameterDirection.Output : sqlParametro.Value = "" 'XmlDoc.OuterXml
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()

                'Agrega al documento XML la cadena que ya esta grabada
                docXml.LoadXml(.Parameters("@CADENA_XML").Value.ToString)
                'Crea el nodo principal o primera linea <?xml version="1.0"?>
                Dim Nodo As Xml.XmlDeclaration
                Nodo = docXml.CreateXmlDeclaration("1.0", "utf-8", Nothing)
                'Agrega el nodo al documento
                Dim root As Xml.XmlElement = docXml.DocumentElement
                docXml.InsertBefore(Nodo, root)

                docXml.Save(sRutaXML)
                ConvierteXMLUTF8(sRutaXML)

                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "RecuperaXML", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function RecuperaXML() As String
        Dim sResultado As String = ""
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        Dim docXml As Xml.XmlDocument

        If Me._Conexion.State = ConnectionState.Open Then
            Me._Conexion.Close()
        End If

        Try
            With cmd
                .Connection = _Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MP_CFDI_PAGOS_CXC_RECUPERA_CADENA_XML"

                sqlParametro = .Parameters.Add("@FOLIO_PAGO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_PAGO
                sqlParametro = .Parameters.Add("@CADENA_XML", SqlDbType.Xml) : sqlParametro.Direction = ParameterDirection.Output : sqlParametro.Value = "" 'XmlDoc.OuterXml

                _Conexion.Open()
                .ExecuteNonQuery()

                'Agrega al documento XML la cadena que ya esta grabada
                docXml = New Xml.XmlDocument
                docXml.LoadXml(.Parameters("@CADENA_XML").Value.ToString)

                'Crea el nodo principal o primera linea <?xml version="1.0"?>
                Dim Nodo As Xml.XmlDeclaration
                Nodo = docXml.CreateXmlDeclaration("1.0", "utf-8", Nothing)
                'Agrega el nodo al documento
                Dim root As Xml.XmlElement = docXml.DocumentElement
                docXml.InsertBefore(Nodo, root)
                'docXml.Save(sRutaXML)

                sResultado = docXml.InnerXml

                'If txtLEN(docXml.InnerXml) = True Then
                '    bResultado = True
                'End If

            End With
            cmd = Nothing
            _Conexion.Close()

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "RecuperaXML", ex)
        End Try

        Return sResultado
    End Function

    Public Function ObtenerPagosDetalle() As DataTable
        Dim dTabla As New DataTable, da As SqlDataAdapter
        Dim sSQL As String

        sSQL = "SELECT D.FOLIO_CXC " &
            "FROM CFDI_PAGOS_CXC_DETALLE D " &
            "WHERE D.FOLIO_PAGO='" & Me._FOLIO_PAGO & "' " &
            "ORDER BY D.ID_CFDI_PAGOS_CXC_DETALLE"

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)

            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerPagosDetalle", ex)
        End Try

        Return dTabla
    End Function

    Public Function ObtenerPagosDetalleParaConsultaCFDI() As DataTable
        Dim dTabla As New DataTable, da As SqlDataAdapter
        Dim sSQL As String

        sSQL = "SELECT CXC.FOLIO_REFERENCIA,D.CODIGO_MONEDA_SAT_DR,D.TIPO_CAMBIO_DR,D.CODIGO_METODO_PAGO_EVENTO_DR,D.NUMERO_PARCIALIDAD,D.IMPORTE_SALDO_ANTERIOR,D.IMPORTE_PAGADO,D.IMPORTE_SALDO_INSOLUTO " &
            "FROM CFDI_PAGOS_CXC_DETALLE D " &
            "INNER JOIN CXC_GLOBAL CXC ON(D.FOLIO_CXC=CXC.FOLIO_CXC) " &
            "WHERE D.FOLIO_PAGO='" & Me._FOLIO_PAGO & "' " &
            "ORDER BY D.ID_CFDI_PAGOS_CXC_DETALLE"

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)

            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerPagosDetalleParaConsultaCFDI", ex)
        End Try

        Return dTabla
    End Function

    Public Function BusquedaVisualPagosClienteParaRelacionarCFDIs(ByVal sCodigoCliente As String) As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de pagos del cliente."
        f.sCampo = "P.FOLIO_PAGO"
        f.sOrder = "P.FECHA_PAGO DESC"
        f.sTable = "CFDI_PAGOS_CXC_GLOBAL"
        f.sQl = "SELECT P.FOLIO_PAGO,P.FOLIO_BANCO,P.ESTATUS_PAGO,DBO.FN_FORMAT_FECHA_CORTO(P.FECHA_PAGO) FECHA,DBO.fn_FormatoNum(P.MONTO,1,2) TOTAL,P.FOLIO_FISCAL_SAT " +
        "FROM CFDI_PAGOS_CXC_GLOBAL P " +
        "WHERE P.CODIGO_CLIENTE='" & sCodigoCliente.ToString & "' AND LEN(P.FOLIO_FISCAL_SAT)>0 AND " 'Busca sólo pagos timbrados.
        f.arrayWidthColumns = New Integer() {100, 60, 70, 250, 100, 300}
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "BusquedaVisualPagosClienteParaRelacionarCFDIs", ex)
        End Try
        Return Resultado
    End Function
#End Region

End Class
