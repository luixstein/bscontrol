Option Strict Off
Option Explicit On

Imports cfdi
Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Xml.XPath
Imports System.Text

Module FacturacionElectronica

    Private Const nombreModulo As String = "FacturacionElectronica"
    Public Const CK_KEY As String = "RSA87654321_1103553D4K5V" '"RSAT34MB34N_2637664B634J"

    Private oComprobante As New cComprobante

    Private sCarpetaCertificados As String = ""
    Private tPlazaFacturaElectronica As Class_SisPlazas

#Region "Campos de sistema"
    Private _Conexion As New SqlConnection(Empresa_Sistema.conexion)
#End Region

    Public Enum TipoComprobante
        FACTURA_VENTA
        NOTA_CREDITO_CXC
        PAGO_CXC
        DEVOLUCION_CXC
    End Enum

    Public Enum TipoArchivoContabilidadElectronica
        CATALOGO_CUENTAS
        BALANZA_COMPROBACION
        POLIZAS
    End Enum

    Public Structure Certificado
        Dim noCertificado As String
        Dim Certificado As String
        Dim CertificadoValido As Boolean
    End Structure

    Public Function SellarFactura(ByRef xmlDoc As MSXML2.DOMDocument60, ByVal sFolioDocumentoSistema As String, ByVal sSerie As String, ByVal iFolioNumerico As Integer, ByVal sRutaXML As String, ByVal tipoComprobante As TipoComprobante) As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "SellarFactura"

        Dim FacturaO As MSXML2.IXMLDOMNode
        Dim Factura As MSXML2.IXMLDOMNode

        Dim Fecha_Documento

        Dim oVenta As New Class_Ventas_Global
        Dim oDescuento As New Class_CXC_Descuento
        Dim oCliente As New Class_CatClientes
        Dim sNombreFormatoXML As String = ""

        If tipoComprobante = TipoComprobante.FACTURA_VENTA Then
            oVenta = New Class_Ventas_Global(sSerie & "-" & iFolioNumerico.ToString)
            oCliente = New Class_CatClientes(oVenta.CODIGO_CLIENTE)
            sNombreFormatoXML = oCliente.FORMATO_NOMBRE_XML

            If txtLEN(sNombreFormatoXML) = True Then
                If sNombreFormatoXML = "RFCemisor-Serie-FolioNumerico" Then
                    sFolioDocumentoSistema = Empresa_Sistema.RFC & "-" & oVenta.SERIE & "-" & oVenta.FOLIO_NUMERICO
                ElseIf sNombreFormatoXML = "RFCemisor-Fecha-SerieFolio" Then
                    sFolioDocumentoSistema = Empresa_Sistema.RFC & Format(oDescuento.FECHA, "yyyyddMM") & oVenta.SERIE & oVenta.FOLIO_NUMERICO
                End If
            End If
        Else
            oDescuento = New Class_CXC_Descuento(sSerie & "-" & iFolioNumerico.ToString)
            oCliente = New Class_CatClientes(oDescuento.CODIGO_CLIENTE)
            sNombreFormatoXML = oCliente.FORMATO_NOMBRE_XML

            If txtLEN(sNombreFormatoXML) = True Then
                If sNombreFormatoXML = "RFCemisor-Serie-FolioNumerico" Then
                    sFolioDocumentoSistema = Empresa_Sistema.RFC & "-" & oDescuento.SERIE & "-" & oDescuento.FOLIO_NUMERICO
                ElseIf sNombreFormatoXML = "RFCemisor-Fecha-SerieFolio" Then
                    sFolioDocumentoSistema = Empresa_Sistema.RFC & Format(oDescuento.FECHA, "yyyyddMM") & oDescuento.SERIE & oDescuento.FOLIO_NUMERICO
                End If
            End If
        End If

        Try
            FacturaO = xmlDoc.childNodes(1)
            Factura = FacturaO.cloneNode(True)

            Fecha_Documento = CDate(ConvierteFechaTipoXML(Factura.attributes.getNamedItem("fecha").text))

            Dim Cert As Certificado = GestionaCertificado(Fecha_Documento)
            If Cert.CertificadoValido = False Then
                Exit Function
            End If

            Factura.attributes.getNamedItem("noCertificado").text = Cert.noCertificado
            Factura.attributes.getNamedItem("certificado").text = Cert.Certificado
            Factura.attributes.getNamedItem("sello").text = ""

            Dim docXml As New Xml.XmlDocument
            docXml.LoadXml(Factura.xml)

            docXml.Save(sRutaXML)

            If ConvierteXMLUTF8(sRutaXML) = False Then
                MsgBox("Error al tratar de convertir el archivo xml a UTF-8 y falta aún timbrar.", MsgBoxStyle.Exclamation, sProcedure)
                Exit Function
            End If

            bResultado = Timbrar(sFolioDocumentoSistema, sRutaXML, tipoComprobante)

            xmlDoc = Nothing
            Factura = Nothing

        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Public Function Timbrar(ByVal sFolioDocumentoSistema As String, ByVal sRutaXML As String, ByVal tipoComprobante As TipoComprobante)
        Const sProcedure As String = "Timbrar"
        Dim bResultado As Boolean = False, bMododemo As Boolean = False

        Try
            If My.Computer.Name = "PCSISTEMASJORGE" Or My.Computer.Name = "ERNESTOA" Or My.Computer.Name = "DANIEL-PC" Or Usuario.Codigo_Usuario = 1 Then
                MsgBox("Las computadoras de sistemas no deben timbrar documentos." & vbCrLf & "Ni el dba(por protección de timbrar por error estando en pruebas).", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            Dim sUserWS As String = Empresa_Sistema.FELECTRONICA_USER_WS
            Dim sContraseñaWS As String = Empresa_Sistema.FELECTRONICA_PASS_WS

            'Note que aquí se sobreescribe el usuario a demo y en el new no se usan las propiedades de Empresa_Sistema
            If My.Computer.Name = "PCSISTEMASJORGE" Or My.Computer.Name = "ERNESTOA" Or My.Computer.Name = "DANIEL-PC" Or Usuario.Codigo_Usuario = 1 Then
                bMododemo = True
                sUserWS = "demo.demo"
                sContraseñaWS = "demo"
            End If

            Using cfd As New clsCFDI(sRutaXML, Empresa_Sistema.BaseDatos, Empresa_Sistema.Servidor,
                sFelectronicaArchivoPFX, Empresa_Sistema.FELECTRONICA_CONTRASENIA_PFX, sUserWS, sContraseñaWS, True)

                'If txtLEN(cfd.RecuperarTimbrePorSerieFolio(sSerie, iFolioNumerico, Empresa_Sistema.RFC, sFelectronicaCbbImagen)) = True Then
                '    If cfd.Recuperado = True Then
                '        Dim sRutaXMLTimbrado As String = sFelectronicaCarpetaXmlsTimbrados & "\" & sFolioDocumentoSistema & ".xml"
                '        'cfd.Timbrar(sRutaXMLTimbrado, sFelectronicaCbbImagen)
                '        docXml.LoadXml(cfd.RecuperarTimbrePorSerieFolio(sSerie, iFolioNumerico, Empresa_Sistema.RFC, sFelectronicaCbbImagen))
                '        docXml.Save(sRutaXMLTimbrado)
                '        bResultado = True
                '    End If
                'Else

                Dim sRutaXMLTimbrado As String = sFelectronicaCarpetaXmlsTimbrados & "\" & sFolioDocumentoSistema & ".xml"

                If cfd.Sellar = True Then

                    If bMododemo = True Then
                        MsgBox("Esta el timbrado en modo demo", vbInformation, sProcedure)
                        cfd.TimbrarDemo(sRutaXMLTimbrado, sFelectronicaCbbImagen)
                    Else
                        cfd.Timbrar(sRutaXMLTimbrado, sFelectronicaCbbImagen)
                    End If

                    If cfd.Timbrado = True Then
                        If GrabaCadenaOriginalYSelloComprobanteElectronico(cfd, tipoComprobante) = True Then
                            bResultado = True
                        End If
                    End If

                End If
                'End If
            End Using

        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Public Function GestionaCertificado(ByVal FechaDocumento As Date) As Certificado
        Dim CKCert As New CHILKATCERTIFICATELib.ChilkatCert, dFechaServidor As Date
        Dim c As Certificado
        Const sProcedure As String = "GestionaCertificado"

        c.noCertificado = ""
        c.Certificado = ""
        c.CertificadoValido = False

        Try
            If CKCert.LoadFromFile(sFelectronicaArchivoCERLocal) = 0 Then
                MsgBox("No se logró cargar el certificado : " & vbCrLf & sFelectronicaArchivoCERLocal, vbExclamation, sProcedure)
                Return c
            End If

            Dim sqlResult As New Class_find("SELECT GETDATE()")
            dFechaServidor = CDate(sqlResult.Result1)
            If CKCert.ValidTo < dFechaServidor Then
                MsgBox("El certificado caducó el día " & Format(CKCert.ValidFrom, "dd-MMM-yyyy") & ".", vbExclamation, sProcedure)
                Return c
            End If

            'CKCert.ValidFrom AND CKCert.ValidFrom
            If FechaDocumento < CDate(Format(CKCert.ValidFrom, "yyyy-MM-dd")) And FechaDocumento > CDate(Format(CKCert.ValidTo, "yyyy-MM-dd")) Then
                MsgBox("Los sellos han expirado, avíse al depto de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                Return c
            End If

            c.noCertificado = GeneraNumeroCertificado(CKCert.SerialNumber)
            c.Certificado = Mid(CKCert.GetEncoded(), 1, Len(CKCert.GetEncoded()) - 2)
            c.CertificadoValido = True
        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try
        Return c
    End Function

    Public Function CancelarCFDI(ByVal sFolioDocumentoSistema As String, ByVal sSerie As String, ByVal iFolioNumerico As Integer, ByVal sFolioFiscalSat As String, ByVal sDocumentoYaEstaTimbrado As String, ByVal sTipoComprobante As TipoComprobante,
                                 ByVal sCadenaXML As String) As Boolean
        Const sProcedure As String = "CancelarCFDI"

        Dim bResultado As Boolean = False, bGraboAcuse As Boolean = False

        Dim ArchivoXmlAcuseCancelacion As String = sFelectronicaCarpetaXmlsAcusesCancelacion & "\AcuseCancelacion_" & sFolioDocumentoSistema & ".xml" ' "la ruta de los xml de acuses de cancelacion"
        Dim sUUID As String = "" ' "el folio del sat del documento"
        Dim sXml As String = ""
        Dim sAcuseCancelacion As String = ""

        Dim bModoDemo As Boolean = False

        Try
            Dim cfdi As New ClassCFDI(sCadenaXML, False)

            If cfdi.XMLCargado = False Then
                MsgBox("No se logró cargar el xml, se abortó el proceso de cancelar el timbre.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If My.Computer.Name = "PCSISTEMASJORGE" Or My.Computer.Name = "PCSISTEMASFER" Or Usuario.Nombre_Usuario = "DBA" Then
                MsgBox("Las computadoras de sistemas no deben cancelar timbres.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If My.Computer.Name = "PCSISTEMASJORGE" Or My.Computer.Name = "PCSISTEMASFER" Or Usuario.Nombre_Usuario = "DBA" Then
                bModoDemo = True
            End If

            Dim sUserWS As String = Empresa_Sistema.FELECTRONICA_USER_WS
            Dim sContraseñaWS As String = Empresa_Sistema.FELECTRONICA_PASS_WS

            'Note que aquí se sobreescribe el usuario a demo y en el new no se usan las propiedades de Empresa_Sistema
            If bModoDemo = True Then
                MsgBox("La cancelación de timbres esta modo demo !!", vbExclamation, sProcedure)
                sUserWS = "demo.demo"
                sContraseñaWS = "demo"
            End If

            Using cfd As New clsCFDI(Empresa_Sistema.BaseDatos, Empresa_Sistema.Servidor,
                                     sFelectronicaArchivoPFX, Empresa_Sistema.FELECTRONICA_CONTRASENIA_PFX,
                                     sUserWS, sContraseñaWS, True, sFelectronicaArchivoKEYLocal)

                If sDocumentoYaEstaTimbrado = "0" Then
                    'Recuperar 
                    sXml = cfd.RecuperarTimbrePorSerieFolio(sSerie, iFolioNumerico, Empresa_Sistema.RFC, sFelectronicaCbbImagen)
                    If cfd.Recuperado = False Then 'No se recupero
                        If sXml = "ErrorDLL" Then
                            'No descarta el timbre por algun otro error, que no necesariamente signifca que no exista el timbre
                            Return False
                        End If
                        DescartarTimbrado(sFolioDocumentoSistema, sTipoComprobante) 'ActualizaEstatusTimbradoDescartado(Folio, sTipoComprobanteElectronico)
                        Return False
                    Else
                        sXml = Replace(sXml, "<?xml version=""1.0"" encoding=""UTF-8""?>", "")
                        'Se recupero 'sFolioFacturaSistema, sXml, 
                        If GrabaCadenaOriginalYSelloComprobanteElectronico(cfd, sTipoComprobante) = False Then
                            Return False
                        End If
                    End If
                    sUUID = cfd.Complemento.UUID
                Else
                    sUUID = sFolioFiscalSat
                End If

                'cfd.CancelarTimbre(Empresa_Sistema.RFC, sUUID, ArchivoXmlAcuseCancelacion)'V1
                cfd.CancelarTimbreV2(cfdi.Emisor.rfc, cfdi.Receptor.rfc, sUUID, cfdi.Comprobante.total, ArchivoXmlAcuseCancelacion) 'V2

                If cfd.Cancelado = True Then
                    bResultado = True 'Marcamos true sin hacer lo del acuse, porque no es importante grabarlo
                    bGraboAcuse = GrabaCancelacionYAcuseXML(sFolioDocumentoSistema, cfd.XmlAcuseCancelacionTimbre, sTipoComprobante)
                Else 'En caso de que no lo haya podido cancelar es posible que haya regresado algún mensaje importante, se debe de grabar.
                    If txtLEN(cfd.MensajeErrorCancelarTimbre) = True Then
                        GuardarMensajeErrorCancelarTimbre(sFolioDocumentoSistema, cfd.MensajeErrorCancelarTimbre, sTipoComprobante)
                    End If
                End If
            End Using

            If bResultado = True Then
                If bGraboAcuse = False Then
                    MsgBox("Timbre cancelado satisfactoriamente pero no se grabó el acuse.", vbInformation, sProcedure)
                Else
                    MsgBox("Timbre cancelado satisfactoriamente.", vbInformation, sProcedure)
                End If
            End If

        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function GrabaCancelacionYAcuseXML(ByVal sFolioDocumentoSistema As String, ByRef sAcuseCancelacionXML As String, ByVal sTipoComprobanteElectronico As TipoComprobante) As Boolean
        Const sProcedure As String = "GrabaCancelacionYAcuseXML"
        Dim bResultado As Boolean = False

        Try
            Dim cmd As New SqlCommand
            Dim sqlParametro As SqlParameter

            With cmd
                .Connection = _Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure

                Select Case sTipoComprobanteElectronico
                    Case TipoComprobante.FACTURA_VENTA '"FACTURA_VENTA"
                        .CommandText = "MP_VENTAS_FACTURACION_ELECTRONICA_CANCELA_Y_GUARDA_ACUSE_XML"
                        sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolioDocumentoSistema

                    Case TipoComprobante.NOTA_CREDITO_CXC '"NOTA_CREDITO_CXC"
                        .CommandText = "MP_CXC_NOTAS_CREDITO_ELECTRONICA_CANCELA_Y_GUARDA_ACUSE_XML"
                        sqlParametro = .Parameters.Add("@FOLIO_DESCUENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolioDocumentoSistema

                    Case TipoComprobante.PAGO_CXC
                        .CommandText = "MP_CFD_CXC_PAGOS_CANCELA_Y_GUARDA_ACUSE_XML"
                        sqlParametro = .Parameters.Add("@FOLIO_PAGO", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolioDocumentoSistema

                    Case TipoComprobante.DEVOLUCION_CXC
                        .CommandText = "MP_CFD_CXC_DEVOLUCIONES_CANCELA_Y_GUARDA_ACUSE_XML"
                        sqlParametro = .Parameters.Add("@FOLIO_DEVOLUCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolioDocumentoSistema

                    Case Else
                        MsgBox("No se indicó el tipo de comprobante electrónico generado para grabar los datos de cancelación del documento.", MsgBoxStyle.Exclamation, sProcedure)
                        cmd = Nothing
                        Return False
                End Select

                sqlParametro = .Parameters.Add("@CADENA_XML_ACUSE_CANCELACION", SqlDbType.Xml) : sqlParametro.Value = sAcuseCancelacionXML

                _Conexion.Open()
                .ExecuteNonQuery()
            End With
            cmd = Nothing
            bResultado = True

            _Conexion.Close()

        Catch ex As Exception
            _Conexion.Close()
            HandleError(nombreModulo, sProcedure, ex)
        End Try
        Return bResultado
    End Function

    Public Function GuardarMensajeErrorCancelarTimbre(ByVal sFolioFacturaSistema As String, ByVal sMensajeError As String, ByVal sTipoComprobanteElectronico As TipoComprobante) As Boolean
        Const sProcedure As String = "GuardarMensajeErrorCancelarTimbre"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        Try
            With cmd
                .Connection = _Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure

                .Parameters.Clear()

                .CommandText = "MP_CFDI_GRABA_ERROR_CANCELAR_TIMBRE"

                sqlParametro = .Parameters.Add("@FOLIO", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolioFacturaSistema
                sqlParametro = .Parameters.Add("@MENSAJE_ERROR_CANCELAR_TIMBRE", SqlDbType.NVarChar, 300) : sqlParametro.Value = sMensajeError
                sqlParametro = .Parameters.Add("@TIPO_COMPROBANTE", SqlDbType.NVarChar, 30) : sqlParametro.Value = sTipoComprobanteElectronico

                _Conexion.Open()
                .ExecuteNonQuery()

            End With
            cmd = Nothing
            bResultado = True
            _Conexion.Close()

        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
            _Conexion.Close()
        End Try

        Return bResultado
    End Function

    Private Function DescartarTimbrado(ByVal sFolio As String, ByVal sTipoComprobanteElectronico As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CFD_DESCARTAR_TIMBRE"

            sqlParametro = .Parameters.Add("@FOLIO_DOCUMENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolio
            sqlParametro = .Parameters.Add("@TIPO_COMPROBANTE_ELECTRONICO", SqlDbType.NVarChar, 20) : sqlParametro.Value = sTipoComprobanteElectronico

            Try
                _Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(nombreModulo, "DescartarTimbrado", ex)
            Finally
                _Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Private Function ConvierteXMLUTF8(ByVal sRutaXML As String) As Boolean
        Try
            Dim Var As Object
            Var = Shell(sFelectronicaConvierteUTF8Local & " """ & sRutaXML & """", AppWinStyle.MinimizedFocus)
            Return True
        Catch ex As Exception
            HandleError(nombreModulo, "ConvierteXMLUTF8", ex)
        End Try
    End Function

    Public Function ConvierteUTF8(ByVal sArchivoXML As String) As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim rAutomatico As StreamReader, sTexto As String

            rAutomatico = New StreamReader(sArchivoXML, True)

            'Se tiene que leer, si no, no da el encode que realmente tiene.
            sTexto = rAutomatico.ReadToEnd
            rAutomatico.Close()
            rAutomatico.Dispose()

            Dim sw As New StreamWriter(sArchivoXML, False, System.Text.Encoding.UTF8) 'MyEncoding)
            sw.Write(sTexto)

            sw.Close()
            sw.Dispose()

            bResultado = True
        Catch ex As Exception
            HandleError(nombreModulo, "ConvierteUTF8", ex)
        End Try

        Return bResultado
    End Function

    Private Function GrabaCadenaOriginalYSelloComprobanteElectronico(ByRef fElectronica As clsCFDI, ByVal sTipoComprobanteElectronico As String) As Boolean
        Const sProcedure As String = "GrabaCadenaOriginalYSelloComprobanteElectronico"
        Dim bResultado As Boolean = False

        Try
            Dim cmd As New SqlCommand
            Dim sqlParametro As SqlParameter

            With cmd
                .Connection = _Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure

                Select Case sTipoComprobanteElectronico
                    Case TipoComprobante.FACTURA_VENTA '"FACTURA_VENTA"
                        .CommandText = "MP_CFD_VENTAS_GRABA_DATOS_DIGITALES"
                        sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = fElectronica.Comprobante.FolioCompleto

                    Case TipoComprobante.NOTA_CREDITO_CXC '"NOTA_CREDITO_CXC"
                        .CommandText = "MP_CFD_CXC_NOTAS_CREDITO_GRABA_DATOS_DIGITALES"
                        sqlParametro = .Parameters.Add("@FOLIO_DESCUENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = fElectronica.Comprobante.FolioCompleto

                    Case TipoComprobante.PAGO_CXC
                        .CommandText = "MP_CFD_CXC_PAGOS_GRABA_DATOS_DIGITALES"
                        sqlParametro = .Parameters.Add("@FOLIO_PAGO", SqlDbType.NVarChar, 15) : sqlParametro.Value = fElectronica.Comprobante.FolioCompleto

                    Case TipoComprobante.DEVOLUCION_CXC
                        .CommandText = "MP_CFD_CXC_DEVOLUCIONES_GRABA_DATOS_DIGITALES"
                        sqlParametro = .Parameters.Add("@FOLIO_DEVOLUCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = fElectronica.Comprobante.FolioCompleto

                    Case Else
                        MsgBox("No se indicó el tipo de comprobante electrónico generado para grabar los datos digitales del documento.", MsgBoxStyle.Exclamation, sProcedure)
                        cmd = Nothing
                        Return False
                End Select

                sqlParametro = .Parameters.Add("@VERSION_ESQUEMA_XML", SqlDbType.NVarChar, 6) : sqlParametro.Value = fElectronica.Comprobante.Version
                sqlParametro = .Parameters.Add("@CADENA_XML", SqlDbType.Xml) : sqlParametro.Value = fElectronica.XmlTimbrado.ToString 'sxml
                sqlParametro = .Parameters.Add("@NUMERO_CERTIFICADO_DIGITAL", SqlDbType.NVarChar, 50) : sqlParametro.Value = fElectronica.Comprobante.noCertificado
                sqlParametro = .Parameters.Add("@CADENA_ORIGINAL", SqlDbType.NVarChar, 4000) : sqlParametro.Value = fElectronica.CadenaOriginal
                sqlParametro = .Parameters.Add("@SELLO_DIGITAL", SqlDbType.NVarChar, 2000) : sqlParametro.Value = fElectronica.Comprobante.SelloCFD
                sqlParametro = .Parameters.Add("@FOLIO_FISCAL_SAT", SqlDbType.NVarChar, 50) : sqlParametro.Value = fElectronica.Complemento.UUID.ToUpper
                sqlParametro = .Parameters.Add("@FECHA_TIMBRADO_SAT", SqlDbType.NVarChar, 20) : sqlParametro.Value = fElectronica.Complemento.FechaTimbrado
                sqlParametro = .Parameters.Add("@NUMERO_SERIE_CERTIFICADO_SAT", SqlDbType.NVarChar, 20) : sqlParametro.Value = fElectronica.Complemento.NoCertificadoSAT
                sqlParametro = .Parameters.Add("@SELLO_SAT", SqlDbType.NVarChar, 500) : sqlParametro.Value = fElectronica.Complemento.SelloSAT
                sqlParametro = .Parameters.Add("@CBB_IMAGE", SqlDbType.Image) : sqlParametro.Value = fElectronica.ImagenCBB
                sqlParametro = .Parameters.Add("@RFCPROVCERTIF", SqlDbType.NVarChar, 13) : sqlParametro.Value = fElectronica.Complemento.RfcProvCertif
                sqlParametro = .Parameters.Add("@LEYENDA", SqlDbType.NVarChar, 200) : sqlParametro.Value = fElectronica.Complemento.Leyenda

                _Conexion.Open()
                .ExecuteNonQuery()
            End With
            cmd = Nothing
            bResultado = True

            _Conexion.Close()

        Catch ex As Exception
            _Conexion.Close()
            HandleError(nombreModulo, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Public Function GeneraNumeroCertificado(ByVal serie As String) As String
        Const sProcedure As String = "GeneraNumeroCertificado"
        Dim resultado As String = ""
        Try
            Dim i As Short

            For i = 2 To Len(serie) Step 2
                resultado = resultado & Mid(serie, i, 1)
            Next
        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try

        Return resultado
    End Function

    Public Function CaracterEspecial(ByRef cadena As String) As String
        Dim sResultado As String = ""
        Try
            ' En el caso del & se deberá usar la secuencia &amp;
            ' En el caso del “ se deberá usar la secuencia &quot;
            ' En el caso del < se deberá usar la secuencia &lt;
            ' En el caso del > se deberá usar la secuencia &gt;
            ' En el caso del ‘ se deberá usar la secuencia &apos;
            cadena = Replace(cadena, "&", "&amp", , , CompareMethod.Text)
            cadena = Replace(cadena, "+char(34)+", "&quot", , , CompareMethod.Text)
            cadena = Replace(cadena, "<", "&lt", , , CompareMethod.Text)
            cadena = Replace(cadena, ">", "&gt", , , CompareMethod.Text)
            cadena = Replace(cadena, "'", "&apos", , , CompareMethod.Text)

        Catch ex As Exception
            HandleError(nombreModulo, "CaracterEspecial", ex)
        End Try

        Return sResultado 'No se esta usando esta función al parecer
    End Function

    Public Function GestionaExistanCertificadosFacturaElectronica() As Boolean
        Const sProcedure As String = "GestionaExistanCertificadosFacturaElectronica"
        Dim bResultado As Boolean = False

        Dim sNombreServidor As String
        Dim sCarpetaTrabajoServer As String, sCarpetaTrabajoLocal As String
        Dim sCarpetaDB As String
        Dim sCerServer As String, sCadenaOriginalServer As String, sKeyServer As String
        Dim sDllCfdi As String = "cfdi.dll"
        Dim sDllCo32 As String = "co32.dll"
        Dim sDllCo33 As String = "cadenaoriginal_3_3.dll"
        Dim sDllIonicZip As String = "Ionic.Zip.dll"
        Dim sDllQRCode As String = "ThoughtWorks.QRCode.dll"
        Dim sDllCo32Archivo As String, sDllIonicZipArchivo As String, sDllQRCodeArchivo As String, sDllCo33Archivo As String
        Dim sFelectronicaArchivoPFXServidor As String
        Dim sFelectronicaCbbImagenServidor As String

        Try
            sNombreServidor = Split(My.Settings.Servidor, "\")(0)
            sCarpetaTrabajoServer = "\\" & sNombreServidor & "\" & Right(My.Settings.Ruta, Len(My.Settings.Ruta) - InStrRev(My.Settings.Ruta, "\")) & "\" & Empresa_Sistema.FELECTRONICA_CARPETA_TRABAJO
            sCarpetaTrabajoLocal = My.Settings.Ruta & "\" & Empresa_Sistema.FELECTRONICA_CARPETA_TRABAJO

            sCarpetaDB = sCarpetaTrabajoLocal & "\" & My.Settings.BaseDatos
            sCarpetaCertificados = sCarpetaDB & "\Certificados digitales"
            sFelectronicaCarpetaXMLPDF = sCarpetaDB & "\Xmls_Pdfs" & "\" & Plaza.NOMBRE_PLAZA
            sFelectronicaCarpetaXMLSinTimbrar = sFelectronicaCarpetaXMLPDF & "\Temporales"

            sFelectronicaConvierteUTF8Local = My.Settings.Ruta & "\ConvierteArchivoUTF8.exe"
            sFelectronicaConvierteUTF8Servidor = "\\" & sNombreServidor & "\" & Right(My.Settings.Ruta, Len(My.Settings.Ruta) - InStrRev(My.Settings.Ruta, "\")) & "\" & "ConvierteArchivoUTF8.exe"

            '07dic16, se cambió para que sea la misma ruta de los pdf donde queden los xmls timbrados y ahora los temporales quedan separados de los pdfs para evitar confusiones.
            sFelectronicaCarpetaXmlsTimbrados = sFelectronicaCarpetaXMLPDF 'sCarpetaDB & "\XMLsTimbrados" & "\" & Plaza.NOMBRE_PLAZA

            sFelectronicaCarpetaXmlsAcusesCancelacion = sCarpetaDB & "\XMLsAcusesCancelacion" & "\" & Plaza.NOMBRE_PLAZA
            sFelectronicaCbbImagen = sCarpetaDB & "\" & "cbb.jpg"

            sFelectronicaDLLCFDILocal = My.Settings.Ruta & "\" & sDllCfdi
            sDllCo32Archivo = My.Settings.Ruta & "\" & sDllCo32
            sDllCo33Archivo = My.Settings.Ruta & "\" & sDllCo33
            sDllIonicZipArchivo = My.Settings.Ruta & "\" & sDllIonicZip
            sDllQRCodeArchivo = My.Settings.Ruta & "\" & sDllQRCode

            'Crea las carpeta del certificado digital en caso de que el usuario no la tenga en su equipo.
            If Len(Dir(sCarpetaTrabajoLocal, FileAttribute.Directory)) = 0 Then
                MkDir(sCarpetaTrabajoLocal)
            End If
            If Len(Dir(sCarpetaDB, FileAttribute.Directory)) = 0 Then
                MkDir(sCarpetaDB)
            End If
            If Len(Dir(sCarpetaCertificados, FileAttribute.Directory)) = 0 Then
                MkDir(sCarpetaCertificados)
            End If
            If Len(Dir(sFelectronicaCarpetaXMLPDF, FileAttribute.Directory)) = 0 Then
                MkDir(sFelectronicaCarpetaXMLPDF)
            End If
            If Len(Dir(sFelectronicaCarpetaXmlsTimbrados, FileAttribute.Directory)) = 0 Then
                MkDir(sFelectronicaCarpetaXmlsTimbrados)
            End If
            If Len(Dir(sFelectronicaCarpetaXMLSinTimbrar, FileAttribute.Directory)) = 0 Then
                MkDir(sFelectronicaCarpetaXMLSinTimbrar)
            End If
            If Len(Dir(sFelectronicaCarpetaXmlsAcusesCancelacion, FileAttribute.Directory)) = 0 Then
                MkDir(sFelectronicaCarpetaXmlsAcusesCancelacion)
            End If

            sCadenaOriginalServer = sCarpetaTrabajoServer & "\" & Empresa_Sistema.FELECTRONICA_CADENA_ORIGINAL
            sCerServer = sCarpetaTrabajoServer & "\" & My.Settings.BaseDatos & "\Certificados digitales\" & Empresa_Sistema.FELECTRONICA_CER
            sKeyServer = sCarpetaTrabajoServer & "\" & My.Settings.BaseDatos & "\Certificados digitales\" & Empresa_Sistema.FELECTRONICA_KEY
            sFelectronicaArchivoPFXServidor = sCarpetaTrabajoServer & "\" & My.Settings.BaseDatos & "\Certificados digitales" & "\" & Empresa_Sistema.FELECTRONICA_PFX
            sFelectronicaCbbImagenServidor = sCarpetaTrabajoServer & "\" & My.Settings.BaseDatos & "\cbb.jpg"

            sFelectronicaArchivoPFX = sCarpetaCertificados & "\" & Empresa_Sistema.FELECTRONICA_PFX

            sFelectronicaArchivoCadenaOriginalLocal = sCarpetaTrabajoLocal & "\" & Empresa_Sistema.FELECTRONICA_CADENA_ORIGINAL

            sFelectronicaArchivoCERLocal = sCarpetaCertificados & "\" & Empresa_Sistema.FELECTRONICA_CER
            sFelectronicaArchivoKEYLocal = sCarpetaCertificados & "\" & Empresa_Sistema.FELECTRONICA_KEY
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Len(Dir(sFelectronicaArchivoCadenaOriginalLocal)) = 0 Then
                If Len(Dir(sCadenaOriginalServer)) = 0 OrElse Copiar_Archivo(sCadenaOriginalServer, sFelectronicaArchivoCadenaOriginalLocal) = False Then
                    MsgBox("No existe en el servidor el archivo de la cadena original, no se podrán generar facturas electrónicas en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            If Path.GetFileNameWithoutExtension(sFelectronicaArchivoCERLocal) <> "FALTA" Then 'Si ya esta habilitada la felec, pero no se tiene aún el certificado se salta el buscar el cer,key y pfx
                If Len(Dir(sFelectronicaArchivoCERLocal)) = 0 Then
                    If Len(Dir(sCerServer)) = 0 OrElse Copiar_Archivo(sCerServer, sFelectronicaArchivoCERLocal) = False Then
                        MsgBox("No existe en el servidor el archivo .cer, no se podrán generar facturas electrónicas en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                End If
            End If

            If Len(Dir(sFelectronicaArchivoKEYLocal)) = 0 Then
                If Len(Dir(sKeyServer)) = 0 OrElse Copiar_Archivo(sKeyServer, sFelectronicaArchivoKEYLocal) = False Then
                    MsgBox("No existe en el servidor el archivo .key, no se podrán generar facturas electrónicas en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            If Len(Dir(sFelectronicaConvierteUTF8Local)) = 0 Then
                If Len(Dir(sFelectronicaConvierteUTF8Servidor)) = 0 OrElse Copiar_Archivo(sFelectronicaConvierteUTF8Servidor, sFelectronicaConvierteUTF8Local) = False Then
                    MsgBox("No existe en el servidor el archivo para convertir el XML a UTF8, no se podrán generar facturas electrónicas en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            If Len(Dir(sFelectronicaArchivoPFX)) = 0 Then
                If Len(Dir(sFelectronicaArchivoPFXServidor)) = 0 OrElse Copiar_Archivo(sFelectronicaArchivoPFXServidor, sFelectronicaArchivoPFX) = False Then
                    MsgBox("No existe en el servidor el archivo .pfx, no se podrán generar facturas electrónicas en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            If Len(Dir(sFelectronicaDLLCFDILocal)) = 0 Then
                If Len(Dir("\\" & sNombreServidor & "\" & Right(My.Settings.Ruta, Len(My.Settings.Ruta) - InStrRev(My.Settings.Ruta, "\")) & "\" & sDllCfdi)) = 0 OrElse Copiar_Archivo("\\" & sNombreServidor & "\" & Right(My.Settings.Ruta, Len(My.Settings.Ruta) - InStrRev(My.Settings.Ruta, "\")) & "\" & sDllCfdi, sFelectronicaDLLCFDILocal) = False Then
                    MsgBox("No existe en el servidor el archivo " & sDllCfdi & ", no se podrán generar facturas electrónicas en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            If Len(Dir(sDllCo32Archivo)) = 0 Then
                If Len(Dir("\\" & sNombreServidor & "\" & Right(My.Settings.Ruta, Len(My.Settings.Ruta) - InStrRev(My.Settings.Ruta, "\")) & "\" & sDllCo32)) = 0 OrElse Copiar_Archivo("\\" & sNombreServidor & "\" & Right(My.Settings.Ruta, Len(My.Settings.Ruta) - InStrRev(My.Settings.Ruta, "\")) & "\" & sDllCo32, sDllCo32Archivo) = False Then
                    MsgBox("No existe en el servidor el archivo " & sDllCo32 & ", no se podrán generar facturas electrónicas en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            If Len(Dir(sDllCo33Archivo)) = 0 Then
                If Len(Dir("\\" & sNombreServidor & "\" & Right(My.Settings.Ruta, Len(My.Settings.Ruta) - InStrRev(My.Settings.Ruta, "\")) & "\" & sDllCo33)) = 0 OrElse Copiar_Archivo("\\" & sNombreServidor & "\" & Right(My.Settings.Ruta, Len(My.Settings.Ruta) - InStrRev(My.Settings.Ruta, "\")) & "\" & sDllCo33, sDllCo33Archivo) = False Then
                    MsgBox("No existe en el servidor el archivo " & sDllCo33 & ", no se podrán generar facturas electrónicas en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            If Len(Dir(sDllIonicZipArchivo)) = 0 Then
                If Len(Dir("\\" & sNombreServidor & "\" & Right(My.Settings.Ruta, Len(My.Settings.Ruta) - InStrRev(My.Settings.Ruta, "\")) & "\" & sDllIonicZip)) = 0 OrElse Copiar_Archivo("\\" & sNombreServidor & "\" & "\" & Right(My.Settings.Ruta, Len(My.Settings.Ruta) - InStrRev(My.Settings.Ruta, "\")) & sDllIonicZip, sDllIonicZipArchivo) = False Then
                    MsgBox("No existe en el servidor el archivo " & sDllIonicZip & ", no se podrán generar facturas electrónicas en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            If Len(Dir(sDllQRCodeArchivo)) = 0 Then
                If Len(Dir("\\" & sNombreServidor & "\" & Right(My.Settings.Ruta, Len(My.Settings.Ruta) - InStrRev(My.Settings.Ruta, "\")) & "\" & sDllQRCode)) = 0 OrElse Copiar_Archivo("\\" & sNombreServidor & "\" & Right(My.Settings.Ruta, Len(My.Settings.Ruta) - InStrRev(My.Settings.Ruta, "\")) & "\" & sDllQRCode, sDllQRCodeArchivo) = False Then
                    MsgBox("No existe en el servidor el archivo " & sDllQRCode & ", no se podrán generar facturas electrónicas en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            If Empresa_Sistema.VERSION_CFDI_DLL <> VersionArchivo(sFelectronicaDLLCFDILocal) Then
                Copiar_Archivo("\\" & sNombreServidor & "\" & Right(My.Settings.Ruta, Len(My.Settings.Ruta) - InStrRev(My.Settings.Ruta, "\")) & "\" & sDllCfdi, sFelectronicaDLLCFDILocal) 'Actualizar la dll del usuario

                If Empresa_Sistema.VERSION_CFDI_DLL <> VersionArchivo(sFelectronicaDLLCFDILocal) Then
                    MsgBox("La versión del archivo cfdi.dll(v " & VersionArchivo(sFelectronicaDLLCFDILocal) & ") no es la del servidor(v " & Empresa_Sistema.VERSION_CFDI_DLL & "). " & vbCrLf &
                            "No se podrán generar facturas electrónicas en este equipo. Avíse al depto. de sistemas.", vbExclamation, sProcedure)
                    Return False
                End If
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'If fElectronicaValidaArchivosCertificadoLocal(, , ) = False Then
            '    Return False
            'End If

            bResultado = True

        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Public Function fElectronicaValidaArchivosCertificadoLocal(ByVal sArchivoCer As String, ByVal sArchivoKey As String, ByVal sContraseñaClavePrivada As String) As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "fElectronicaValidaArchivosCertificadoLocal"

        Try

            If txtLEN(sArchivoCer) = False Then
                MsgBox("No se indicó el archivo cer.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If txtLEN(sArchivoKey) = False Then
                MsgBox("No se indicó el archivo key.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If txtLEN(sContraseñaClavePrivada) = False Then
                MsgBox("No se indicó la contrasena de la clave privada.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            sFelectronicaArchivoCERLocal = sCarpetaCertificados + "\" + sArchivoCer
            sFelectronicaArchivoKEYLocal = sCarpetaCertificados + "\" + sArchivoKey
            Empresa_Sistema.FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA = sContraseñaClavePrivada

            If Len(Dir(sFelectronicaArchivoCadenaOriginalLocal)) = 0 Or Len(Dir(sFelectronicaArchivoCERLocal)) = 0 Or Len(Dir(sFelectronicaArchivoKEYLocal)) = 0 Then
                If Len(Dir(sFelectronicaArchivoCadenaOriginalLocal)) = 0 Then
                    MsgBox("No se encontró el archivo de la cadena original, no se podrán generar facturas eletrónicas en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                End If
                If Len(Dir(sFelectronicaArchivoCERLocal)) = 0 Then
                    MsgBox("No se encontró el archivo .cer, no se podrán generar facturas eletrónicas en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                End If
                If Len(Dir(sFelectronicaArchivoKEYLocal)) = 0 Then
                    MsgBox("No se encontró el archivo .key, no se podrán generar facturas eletrónicas en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                End If
                Exit Function
            End If

            bResultado = True

        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try
        Return bResultado
    End Function

    Public Function GeneraFacturaElectronica(ByVal oVenta As Class_Ventas_Global, ByVal bMostrarMensaje As Boolean, ByVal sRutaXML As String) As Boolean
        Const sProcedure As String = "GeneraFacturaElectronica"
        Dim bResultado As Boolean = False
        Dim sVentaPublicoGeneral As String
        Dim sPlaza As String
        Dim drImporte, dPrecio As Double

        Dim Cfd As New cComprobante

        Try
            Cfd.xmlns = "http://www.sat.gob.mx/cfd/3"
            Cfd.xmlnsxsi = "http://www.w3.org/2001/XMLSchema-instance"
            Cfd.xmlnscfdi = "http://www.sat.gob.mx/cfd/3"
            Cfd.xsischemaLocation = "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv32.xsd"

            Cfd.version = Empresa_Sistema.VERSION_ESQUEMA_CFD
            Cfd.serie = fElectronicaValidaCampo(oVenta.SERIE)

            Cfd.noCertificado = "" 'Solo de muestra despues se obtendra el Numero de Certificado
            Cfd.certificado = "" 'Solo de muestra despues se obtendra el Certificado
            Cfd.sello = "" 'Solo de muestra despues se obtendra el Sello

            'Obtenemos la información de la tabla donde se grabo la Factura
            'oVenta = New Class_Ventas_Global(sFolio)
            'If oVenta.Existe = False Then
            '    MsgBox("Error al consultar el documento, no se encontró favor de revisar que exista.", MsgBoxStyle.Exclamation, "Búsqueda de Folios")
            '    Exit Function
            'End If

            If fElectronicaValidaArchivosCertificadoLocal(oVenta.FELECTRONICA_CER, oVenta.FELECTRONICA_KEY, oVenta.FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA) = False Then
                Exit Function
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Datos globales''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Cfd.sFolioFacturaSistema = oVenta.FOLIO_VENTA

            sVentaPublicoGeneral = oVenta.ES_VENTA_PUBLICO_GENERAL
            sPlaza = oVenta.CODIGO_PLAZA

            'Agregamos los datos totales y Generales
            Cfd.Folio = oVenta.FOLIO_NUMERICO
            Cfd.fecha = Format(oVenta.FECHA, "yyyy-MM-dd") & "T" & Format(oVenta.FECHA, "HH:mm:ss")
            Cfd.tipoDeComprobante = "ingreso"
            Cfd.formaDePago = "PAGO EN UNA SOLA EXHIBICION"
            Cfd.condicionesDePago = oVenta.CONDICIONES_DE_PAGO

            If oVenta.TIPO_DE_CAMBIO > 0 Then
                Cfd.Moneda = "USD"
                Cfd.TipoCambio = oVenta.TIPO_DE_CAMBIO
            Else
                Cfd.Moneda = "MXN"
            End If

            Cfd.metodoDePago = oVenta.CODIGO_METODO_PAGO

            Dim oMetodoPago As New Class_CFD_CatFormasPago(oVenta.CODIGO_METODO_PAGO)
            If oMetodoPago.REQUIERE_NUMERO_CUENTA_PAGO = 1 Then
                Cfd.sRequiereNumPago = oMetodoPago.REQUIERE_NUMERO_CUENTA_PAGO
                Cfd.NumCtaPago = oVenta.NUMERO_CUENTA_PAGO.ToString
            End If

            Cfd.Regimen = oVenta.NOMBRE_REGIMEN_FISCAL
            Cfd.Impuestos.Traslados.USADO = True 'si uso el trasladado

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Totales'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oVenta.ES_FACTURA_EMBARQUE_EXTRANJERO = True And (oVenta.IMPUESTO > 0 Or oVenta.IEPS_TOTAL_DESGLOSADO > 0 Or oVenta.IEPS_TOTAL_YA_INCLUIDO > 0) Then
                MsgBox("No esta soportado actualmente por este sistema que lo embarques extranjeros lleven impuestos iva/ieps.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If oVenta.ES_FACTURA_EMBARQUE_EXTRANJERO = True Then
                Cfd.Descuento = Format(oVenta.DESCUENTO_USD, "#0.00")
                Cfd.subTotal = Format(oVenta.TOTAL_DOLARES, "#0.00") 'Nota aquí van
                Cfd.total = Format(0, "#0.00")
                Cfd.Impuestos.Traslados.Add("IVA", Format(0, "#0.00"), Format(0, "#0.00"))
            Else
                Cfd.Descuento = Format(oVenta.DESCUENTO, "#0.00")

                'If sVentaPublicoGeneral = "1" Then
                '    'No se desglosa el iva(por ello subtotal=total y se manda un impuesto en cero)
                '    Cfd.subTotal = Format(oVenta.TOTAL, "#0.00")
                '    Cfd.total = Format(oVenta.TOTAL, "#0.00")
                '    Cfd.Impuestos.Traslados.Add("IVA", Format(0, "#0.00"), Format(0, "#0.00"))
                'Else
                Cfd.subTotal = Format(oVenta.SUBTOTAL, "#0.00")
                Cfd.total = Format(oVenta.TOTAL, "#0.00")

                If oVenta.IMPUESTO = 0 Then
                    Cfd.Impuestos.Traslados.Add("IVA", Format(0, "#0.00"), Format(0, "#0.00"))
                Else
                    '0
                    Dim Impuesto As New Class_find("SELECT 1 FROM VENTA_DETALLE WHERE FOLIO_VENTA='" & oVenta.FOLIO_VENTA & "' AND IMPUESTO_PORCENTAJE=0")
                    If txtLEN(Impuesto.Result1) = True Then
                        Cfd.Impuestos.Traslados.Add("IVA", Format(0, "#0.00"), Format(0, "#0.00"))
                    End If
                    '16
                    Cfd.Impuestos.Traslados.Add("IVA", Format(IIf(oVenta.IMPUESTO_PORCENTAJE > 0, oVenta.IMPUESTO_PORCENTAJE, 0), "#0.00"), Format(oVenta.IMPUESTO, "#0.00"))
                End If
                'End If

                If oVenta.IEPS_TOTAL_DESGLOSADO > 0 Then 'Si es desglosado agregamos los nodos, si no, como van incluidos en precio y subtotal, entonces no se agregan.
                    For Each dRow In oVenta.ObtenerImpuestosIEPS.Rows
                        Cfd.Impuestos.Traslados.Add("IEPS", Format(dRow("IEPS_PORCENTAJE"), "#0.00"), Format(dRow("SUMA_IEPS_IMPORTE"), "#0.00"))
                    Next
                End If

                If oVenta.RETENCION > 0 Then
                    Cfd.Impuestos.Retenciones.Add("IVA", "0", Format(oVenta.RETENCION, "#0.00")) 'escribirlo a mano
                End If

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Cfd.Emisor'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Cfd.Emisor.nombre = fElectronicaValidaCampo(Empresa_Sistema.NOMBRE_EMPRESA)
            Cfd.Emisor.rfc = fElectronicaValidaCampo(Empresa_Sistema.RFC)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Cfd.Emisor.DomicilioFiscal''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With Cfd.Emisor.DomicilioFiscal
                .calle = fElectronicaValidaCampo(Empresa_Sistema.CALLE)
                .noExterior = fElectronicaValidaCampo(Empresa_Sistema.NUMERO_EXTERIOR)
                .noInterior = fElectronicaValidaCampo(Empresa_Sistema.NUMERO_INTERIOR)
                .codigoPostal = fElectronicaValidaCampo(Empresa_Sistema.CODIGO_POSTAL)

                If Empresa_Sistema.FELECTRONICA_CCE_HABILITADO = True And oVenta.ES_FACTURA_EMBARQUE_EXTRANJERO = True Then
                    'Nota, si es con factura de embarque extranjero, estos datos en vez de ir con texto libre van con item de los catálogos proporcionados por el sat.
                    If txtLEN(Empresa_Sistema.CODIGO_COLONIA_SAT) = True Then
                        .colonia = fElectronicaValidaCampo(Empresa_Sistema.CODIGO_COLONIA_SAT)
                    End If
                    If txtLEN(Empresa_Sistema.CODIGO_LOCALIDAD_SAT) = True Then
                        .localidad = fElectronicaValidaCampo(Empresa_Sistema.CODIGO_LOCALIDAD_SAT)
                    End If
                    If txtLEN(Empresa_Sistema.CODIGO_MUNICIPIO_SAT) = True Then
                        .municipio = fElectronicaValidaCampo(Empresa_Sistema.CODIGO_MUNICIPIO_SAT)
                    End If
                    If txtLEN(Empresa_Sistema.CODIGO_ESTADO_SAT) = True Then
                        .estado = fElectronicaValidaCampo(Empresa_Sistema.CODIGO_ESTADO_SAT)
                    End If
                    If txtLEN(Empresa_Sistema.CODIGO_PAIS_SAT) = True Then
                        .pais = fElectronicaValidaCampo(Empresa_Sistema.CODIGO_PAIS_SAT)
                    End If
                Else 'Factura normal
                    .colonia = fElectronicaValidaCampo(Empresa_Sistema.COLONIA)
                    .localidad = fElectronicaValidaCampo(Empresa_Sistema.LOCALIDAD)
                    .municipio = fElectronicaValidaCampo(Empresa_Sistema.CIUDAD)
                    .estado = fElectronicaValidaCampo(Empresa_Sistema.ESTADO)
                    .pais = fElectronicaValidaCampo(Empresa_Sistema.PAIS)
                End If
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Cfd.Emisor.ExpedidoEn''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If sPlaza <> Usuario.Codigo_Plaza Then
                If sPlaza <> Plaza.CODIGO_PLAZA Then 'Si ya estaba cargada la plaza de la factura, no se cargará de nuevo para evitar consultas.
                    tPlazaFacturaElectronica = New Class_SisPlazas(sPlaza)
                End If
            Else
                tPlazaFacturaElectronica = Plaza
            End If

            With Cfd.Emisor.ExpedidoEn
                .USADO = True 'si es usado diferente lugar de expedición se pondra la información, en este caso dejaremos la misma
                .calle = fElectronicaValidaCampo(tPlazaFacturaElectronica.CALLE)
                .noExterior = fElectronicaValidaCampo(tPlazaFacturaElectronica.NUMERO_EXTERIOR)
                .noInterior = fElectronicaValidaCampo(tPlazaFacturaElectronica.NUMERO_INTERIOR)
                .codigoPostal = fElectronicaValidaCampo(tPlazaFacturaElectronica.CODIGO_POSTAL)

                If Empresa_Sistema.FELECTRONICA_CCE_HABILITADO = True And oVenta.ES_FACTURA_EMBARQUE_EXTRANJERO = True Then
                    'Nota, si es con factura de embarque extranjero, estos datos en vez de ir con texto libre van con item de los catálogos proporcionados por el sat.
                    If txtLEN(tPlazaFacturaElectronica.CODIGO_COLONIA_SAT) = True Then
                        .colonia = fElectronicaValidaCampo(tPlazaFacturaElectronica.CODIGO_COLONIA_SAT)
                    End If
                    If txtLEN(tPlazaFacturaElectronica.CODIGO_LOCALIDAD_SAT) = True Then
                        .localidad = fElectronicaValidaCampo(tPlazaFacturaElectronica.CODIGO_LOCALIDAD_SAT)
                    End If
                    If txtLEN(tPlazaFacturaElectronica.CODIGO_MUNICIPIO_SAT) = True Then
                        .municipio = fElectronicaValidaCampo(tPlazaFacturaElectronica.CODIGO_MUNICIPIO_SAT)
                    End If
                    If txtLEN(tPlazaFacturaElectronica.CODIGO_ESTADO_SAT) = True Then
                        .estado = fElectronicaValidaCampo(tPlazaFacturaElectronica.CODIGO_ESTADO_SAT)
                    End If
                    If txtLEN(tPlazaFacturaElectronica.CODIGO_PAIS_SAT) = True Then
                        .pais = fElectronicaValidaCampo(tPlazaFacturaElectronica.CODIGO_PAIS_SAT)
                    End If
                Else
                    .colonia = fElectronicaValidaCampo(tPlazaFacturaElectronica.COLONIA)
                    .localidad = fElectronicaValidaCampo(tPlazaFacturaElectronica.LOCALIDAD)
                    .municipio = fElectronicaValidaCampo(tPlazaFacturaElectronica.CIUDAD)
                    .estado = fElectronicaValidaCampo(tPlazaFacturaElectronica.ESTADO)
                    .pais = fElectronicaValidaCampo(tPlazaFacturaElectronica.PAIS)
                End If
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Cfd.LugarExpedicion = fElectronicaValidaCampo(tPlazaFacturaElectronica.CIUDAD) & ", " & fElectronicaValidaCampo(tPlazaFacturaElectronica.ESTADO)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Cfd.Receptor'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim oCliente As New Class_CatClientes(oVenta.CODIGO_CLIENTE.ToString)

            If oCliente.Existe = False Then
                MsgBox("Cliente no encontrado.", MsgBoxStyle.Exclamation, nombreModulo)
                Exit Function
            End If

            If sVentaPublicoGeneral = "1" Then
                Cfd.Receptor.nombre = "PUBLICO GENERAL"
                Cfd.Receptor.rfc = Empresa_Sistema.RFC_VENTA_PUBLICO_GENERAL
                With Cfd.Receptor.Domicilio
                    .calle = "DOMICILIO CONOCIDO"
                    .noExterior = "S/N"
                    .noInterior = ""
                    .colonia = "CENTRO"
                    .localidad = fElectronicaValidaCampo(tPlazaFacturaElectronica.LOCALIDAD)
                    .municipio = fElectronicaValidaCampo(tPlazaFacturaElectronica.CIUDAD)
                    .estado = fElectronicaValidaCampo(tPlazaFacturaElectronica.ESTADO)
                    .pais = fElectronicaValidaCampo(Empresa_Sistema.PAIS)
                    .codigoPostal = "00000"
                End With
            Else
                Cfd.Receptor.nombre = fElectronicaValidaCampo(oCliente.NOMBRE_CLIENTE)
                Cfd.Receptor.rfc = fElectronicaValidaCampo(oCliente.RFC)

                With Cfd.Receptor.Domicilio
                    .calle = fElectronicaValidaCampo(oCliente.CALLE)
                    .noExterior = fElectronicaValidaCampo(oCliente.NUMERO_EXTERIOR)
                    .noInterior = fElectronicaValidaCampo(oCliente.NUMERO_INTERIOR)
                    .colonia = fElectronicaValidaCampo(oCliente.COLONIA)
                    .localidad = fElectronicaValidaCampo(oCliente.LOCALIDAD)

                    If Empresa_Sistema.FELECTRONICA_CCE_HABILITADO = True And oVenta.ES_FACTURA_EMBARQUE_EXTRANJERO = True Then
                        .municipio = fElectronicaValidaCampo(oCliente.CIUDAD) 'Al ser extranjero no hay catálogo de municipios, se usa el txt abierto
                        'Nota, si es con factura de embarque extranjero, estos datos en vez de ir con texto libre van con item de los catálogos proporcionados por el sat.
                        .estado = fElectronicaValidaCampo(oCliente.CODIGO_ESTADO_SAT)
                        .pais = fElectronicaValidaCampo(oCliente.CODIGO_PAIS_SAT)
                    Else
                        If oCliente.CODIGO_PAIS_SAT <> "MEX" Then
                            .municipio = fElectronicaValidaCampo(oCliente.CIUDAD) 'Al ser extranjero no hay catalogo de municipios y se teclea manual.
                        Else
                            If txtLEN(oCliente.CODIGO_MUNICIPIO) = False And txtLEN(oCliente.CIUDAD) = True Then 'Tiene escrita la ciudad(municipio) a mano y no calza con ninguna del catálogo del sat, se forza a que falle
                                .municipio = "."
                            Else
                                .municipio = fElectronicaValidaCampo(oCliente.NOMBRE_MUNICIPIO) 'Nota en la validacion se pregunta por oCliente.CIUDAD que es escrito a mano, pero se usa el nombre del catálogo del sat, igual con estado y pais
                            End If

                        End If

                        If txtLEN(oCliente.CODIGO_ESTADO_SAT) = False And txtLEN(oCliente.ESTADO) = True Then 'Tiene escrito el estado mano y no calza con ninguno del catálogo del sat, se forza a que falle
                            .estado = "."
                        Else
                            .estado = fElectronicaValidaCampo(oCliente.NOMBRE_ESTADO) 'Ver nota de municipio
                        End If

                        'If txtLEN(oCliente.CODIGO_PAIS_SAT) = False And txtLEN(oCliente.PAIS) = True Then 'Tiene escrito el pais mano y no calza con ninguno del catálogo del sat, se forza a que falle
                        If txtLEN(oCliente.CODIGO_PAIS_SAT) = False Then 'Tiene escrito el pais mano y no calza con ninguno del catálogo del sat, se forza a que falle
                            .pais = "."
                        Else
                            .pais = fElectronicaValidaCampo(oCliente.NOMBRE_PAIS) 'Ver nota de municipio
                        End If
                    End If

                    .codigoPostal = fElectronicaValidaCampo(oCliente.CODIGO_POSTAL.ToString)
                End With
            End If

            'El 2do parámetro es la combinación de dos validaciones, porque puede ser factura extranjera, y otra cosa es que tenga complemento CCE.
            If ValidaDatoFacturaElectronica(Cfd, Empresa_Sistema.FELECTRONICA_CCE_HABILITADO = True And oVenta.ES_FACTURA_EMBARQUE_EXTRANJERO = True) = False Then
                Return False
            End If
            ' _Conexion.Close()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Conceptos''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each row As DataRow In oVenta.ObtenerDetalle.Rows
                'If row("ES_PRODUCTO_KILOS") = "0" Then
                If oVenta.ES_FACTURA_EMBARQUE_EXTRANJERO = True Then
                    dPrecio = valorNumerico(row("PRECIO_USD"))
                    drImporte = valorNumerico(row("IMPORTE_USD"))
                Else
                    'If sVentaPublicoGeneral = "1" Then
                    'dPrecio = valorNumerico(row("PRECIO_TOTAL")) + valorNumerico(row("IMPUESTO_IMPORTE")) 'ojo si es publico gral  no desglosar iva
                    'Else
                    dPrecio = valorNumerico(row("PRECIO_TOTAL"))
                    'End If

                    drImporte = valorNumerico(row("CANTIDAD")) * dPrecio
                    Call Redondear(drImporte, Empresa_Sistema.DECIMALES_CONTABILIDAD)
                End If

                Cfd.Conceptos.Add(row("CANTIDAD"), fElectronicaValidaCampo(row("DESCRIPCION").ToString), CStr(drImporte), row("UNIDAD_VENTA").ToString, CStr(dPrecio), row("CODIGO_ARTICULO").ToString)
                'Else
                '    'Si elprecio o la cantidad es cero no dejar sellar
                '    If valorNumerico(row("PRECIO_KILOS")) = 0 Or valorNumerico(row("CANTIDAD_KILOS")) = 0 Then
                '        Exit Function
                '    End If

                '    'If sVentaPublicoGeneral = "1" Then
                '    'dPrecio = valorNumerico(row("PRECIO_KILOS")) (+ (valorNumerico(row("IMPUESTO_IMPORTE")/valorNumerico(row("CANTIDAD_KILOS"))) 'ojo si es publico gral  no desglosar iva
                '    'dPrecio = valorNumerico(row("PRECIO_KILOS")) + valorNumerico(row("IMPUESTO_IMPORTE")) 'ojo si es publico gral  no desglosar iva
                '    'Else
                '    dPrecio = valorNumerico(row("PRECIO_KILOS"))
                '    'End If

                '    drImporte = valorNumerico(row("CANTIDAD_KILOS")) * dPrecio

                '    Call Redondear(drImporte, Empresa_Sistema.DECIMALES_CONTABILIDAD)
                '    Cfd.Conceptos.Add(row("CANTIDAD_KILOS"), fElectronicaValidaCampo(row("DESCRIPCION").ToString), CStr(drImporte), row("UNIDAD_VENTA").ToString, CStr(dPrecio), row("CODIGO_ARTICULO").ToString)
                'End If
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''CCE COMPLEMENTO COMERCIO EXTERIOR''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim sXmlComercioExterior As String = ""

            'Alguna pregunta que se fije si la empresa lo tiene activado y si el documento es de tipo embarque extranjero
            If Empresa_Sistema.FELECTRONICA_CCE_HABILITADO = True And oVenta.ES_FACTURA_EMBARQUE_EXTRANJERO = True Then
                'If bGenerarComplementoComercioExterior = True Then
                sXmlComercioExterior = oVenta.GeneraXmlComercioExterior10

                If txtLEN(sXmlComercioExterior) = False Then
                    Return False 'Abortamos
                End If
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Cfd.Sellar(sRutaXML, cComprobante.TipoComprobante.FACTURA_VENTA, True, sXmlComercioExterior, oVenta.ES_FACTURA_EMBARQUE_EXTRANJERO) = True Then
                bResultado = True
                If bMostrarMensaje = True Then
                    MsgBox("Factura timbrada satisfactoriamente.", MsgBoxStyle.Information, sProcedure) 'se quito, solo marca error en caso de no sellar desde facturacion , en el grabar
                End If
            End If

        Catch ex As Exception
            _Conexion.Close()
            HandleError(nombreModulo, sProcedure, ex)
        Finally
            Cfd = New cComprobante 'vaciar el comprobante
        End Try

        Return bResultado
    End Function

    Public Function GeneraNotaCreditoCXCElectronica(ByVal oDescuento As Class_CXC_Descuento, ByVal bMostrarMensaje As Boolean, ByVal sRutaXML As String) As Boolean
        Const sProcedure As String = "GeneraNotaCreditoCXCElectronica"
        Dim bResultado As Boolean = False
        Dim sVentaPublicoGeneral, sEsPorDevolucion As String
        Dim sPlaza As String

        Dim Cfd As New cComprobante
        Try
            Cfd.xmlns = "http://www.sat.gob.mx/cfd/3"
            Cfd.xmlnsxsi = "http://www.w3.org/2001/XMLSchema-instance"
            Cfd.xmlnscfdi = "http://www.sat.gob.mx/cfd/3"
            Cfd.xsischemaLocation = "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv32.xsd"

            Cfd.version = Empresa_Sistema.VERSION_ESQUEMA_CFD
            Cfd.serie = fElectronicaValidaCampo(oDescuento.SERIE)
            Cfd.noCertificado = "" 'Solo de muestra despues se obtendra el Numero de Certificado
            Cfd.certificado = "" 'Solo de muestra despues se obtendra el Certificado
            Cfd.sello = "" 'Solo de muestra despues se obtendra el Sello

            'oDescuento = New Class_CXC_Descuento(sFolio)
            'If oDescuento.Existe = False Then
            '    MsgBox("Error al consultar el documento, no se encontró favor de revisar que exista.", MsgBoxStyle.Exclamation, "Búsqueda de Folios")
            '    Exit Function
            'End If

            If fElectronicaValidaArchivosCertificadoLocal(oDescuento.FELECTRONICA_CER, oDescuento.FELECTRONICA_KEY, oDescuento.FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA) = False Then
                Return False
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Datos globales''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'idFactura = oDescuento.ID_CXC_DESCUENTOS_GLOBAL
            Cfd.sFolioFacturaSistema = oDescuento.FOLIO_DESCUENTO

            sVentaPublicoGeneral = oDescuento.ES_VENTA_PUBLICO_GENERAL
            sPlaza = oDescuento.CODIGO_PLAZA
            sEsPorDevolucion = oDescuento.ES_POR_DEVOLUCION

            'Agregamos los datos totales y Generales
            Cfd.Folio = oDescuento.FOLIO_NUMERICO
            Cfd.fecha = Format(oDescuento.FECHA, "yyyy-MM-dd") & "T" & Format(oDescuento.FECHA, "HH:mm:ss")
            Cfd.tipoDeComprobante = "egreso"
            Cfd.formaDePago = "PAGO EN UNA SOLA EXHIBICION"

            Cfd.Descuento = Format(0, "#0.00")

            If oDescuento.TIPO_DE_CAMBIO > 0 Then
                Cfd.Moneda = "USD"
                Cfd.TipoCambio = oDescuento.TIPO_DE_CAMBIO
            Else
                Cfd.Moneda = "MXN"
            End If
            Cfd.Impuestos.Traslados.USADO = True 'si uso el trasladado

            Cfd.metodoDePago = oDescuento.CODIGO_METODO_PAGO
            Cfd.Regimen = oDescuento.NOMBRE_REGIMEN_FISCAL

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'If sVentaPublicoGeneral = "1" Then
            '    'No se desglosa el iva(por ello subtotal=total y se manda un impuesto en cero)
            '    Cfd.subTotal = Format(oDescuento.TOTAL, "#0.00")
            '    Cfd.total = Format(oDescuento.TOTAL, "#0.00")
            '    Cfd.Impuestos.Traslados.Add("IVA", Format(0, "#0.00"), Format(0, "#0.00"))
            'Else
            Cfd.subTotal = Format(oDescuento.SUBTOTAL, "#0.00")
            Cfd.total = Format(oDescuento.TOTAL, "#0.00")

            If oDescuento.IVA = 0 Then
                Cfd.Impuestos.Traslados.Add("IVA", Format(0, "#0.00"), Format(0, "#0.00"))
            Else
                Dim Impuesto As New Class_find("SELECT 1 FROM CXC_DESCUENTOS_GLOBAL D INNER JOIN CXC_DESCUENTOS_DETALLE CD ON (D.FOLIO_DESCUENTO=CD.FOLIO_DESCUENTO) " &
                "INNER JOIN CXC_GLOBAL G ON (CD.FOLIO_CXC=G.FOLIO_CXC) INNER JOIN VENTA_DETALLE VD ON(G.FOLIO_REFERENCIA=VD.FOLIO_VENTA) " &
                "WHERE D.FOLIO_DESCUENTO='" & oDescuento.FOLIO_DESCUENTO & "' AND VD.IMPUESTO_PORCENTAJE=0 ")

                If txtLEN(Impuesto.Result1) = True Then
                    Cfd.Impuestos.Traslados.Add("IVA", Format(0, "#0.00"), Format(0, "#0.00"))
                End If
                '16 IMPUESTO_PORCENTAJE
                'Cfd.Impuestos.Traslados.Add("IVA", Format(IIf(oDescuento.IVA > 0, oDescuento.IMPUESTO_PORCENTAJE, 0), "#0.00"), Format(oDescuento.IVA, "#0.00")) 'corregir, crerar campo impuesto_poercentaje, y no poner fijo 16
                Cfd.Impuestos.Traslados.Add("IVA", Format(IIf(oDescuento.IVA > 0, 16, 0), "#0.00"), Format(oDescuento.IVA, "#0.00")) 'corregir, crerar campo impuesto_poercentaje, y no poner fijo 16
            End If
            'End If

            If oDescuento.RETENCION > 0 Then
                Cfd.Impuestos.Retenciones.Add("IVA", "0", Format(oDescuento.RETENCION, "#0.00"))
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Cfd.Emisor'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Cfd.Emisor.nombre = fElectronicaValidaCampo(Empresa_Sistema.NOMBRE_EMPRESA)
            Cfd.Emisor.rfc = fElectronicaValidaCampo(Empresa_Sistema.RFC)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Cfd.Emisor.DomicilioFiscal''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With Cfd.Emisor.DomicilioFiscal
                .calle = fElectronicaValidaCampo(Empresa_Sistema.CALLE)
                .noExterior = fElectronicaValidaCampo(Empresa_Sistema.NUMERO_EXTERIOR)
                .noInterior = fElectronicaValidaCampo(Empresa_Sistema.NUMERO_INTERIOR)
                .colonia = fElectronicaValidaCampo(Empresa_Sistema.COLONIA)
                .localidad = fElectronicaValidaCampo(Empresa_Sistema.LOCALIDAD)
                .municipio = fElectronicaValidaCampo(Empresa_Sistema.CIUDAD)
                .estado = fElectronicaValidaCampo(Empresa_Sistema.ESTADO)
                .pais = fElectronicaValidaCampo(Empresa_Sistema.PAIS)
                .codigoPostal = fElectronicaValidaCampo(Empresa_Sistema.CODIGO_POSTAL)
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Cfd.Emisor.ExpedidoEn''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If sPlaza <> Usuario.Codigo_Plaza Then
                If sPlaza <> Plaza.CODIGO_PLAZA Then 'Si ya estaba cargada la plaza de la factura, no se cargará de nuevo para evitar consultas.
                    tPlazaFacturaElectronica = New Class_SisPlazas(sPlaza)
                End If
            Else
                tPlazaFacturaElectronica = Plaza 'Plaza ya cargada en el inicio de sesión del usuario.
            End If

            With Cfd.Emisor.ExpedidoEn
                .USADO = True 'si es usado diferente lugar de expedición se pondra la información, en este caso dejaremos la misma
                .calle = fElectronicaValidaCampo(tPlazaFacturaElectronica.CALLE)
                .noExterior = fElectronicaValidaCampo(tPlazaFacturaElectronica.NUMERO_EXTERIOR)
                .noInterior = fElectronicaValidaCampo(tPlazaFacturaElectronica.NUMERO_INTERIOR)
                .colonia = fElectronicaValidaCampo(tPlazaFacturaElectronica.COLONIA)
                .localidad = fElectronicaValidaCampo(tPlazaFacturaElectronica.LOCALIDAD)
                .municipio = fElectronicaValidaCampo(tPlazaFacturaElectronica.CIUDAD)
                .estado = fElectronicaValidaCampo(tPlazaFacturaElectronica.ESTADO)
                .pais = fElectronicaValidaCampo(tPlazaFacturaElectronica.PAIS)
                .codigoPostal = fElectronicaValidaCampo(tPlazaFacturaElectronica.CODIGO_POSTAL)
            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Cfd.LugarExpedicion = fElectronicaValidaCampo(tPlazaFacturaElectronica.CIUDAD) & ", " & fElectronicaValidaCampo(tPlazaFacturaElectronica.ESTADO)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Cfd.Receptor'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oCliente As New Class_CatClientes(oDescuento.CODIGO_CLIENTE.ToString)

            If oCliente.Existe = False Then
                MsgBox("Cliente no encontrado.", MsgBoxStyle.Exclamation, nombreModulo)
                Return False
            End If

            If sVentaPublicoGeneral = "1" Then
                Cfd.Receptor.nombre = "PUBLICO GENERAL"
                Cfd.Receptor.rfc = Empresa_Sistema.RFC_VENTA_PUBLICO_GENERAL
                With Cfd.Receptor.Domicilio
                    .calle = "DOMICILIO CONOCIDO"
                    .noExterior = "S/N"
                    .noInterior = ""
                    .colonia = "CENTRO"
                    .localidad = fElectronicaValidaCampo(tPlazaFacturaElectronica.LOCALIDAD)
                    .municipio = fElectronicaValidaCampo(tPlazaFacturaElectronica.CIUDAD)
                    .estado = fElectronicaValidaCampo(tPlazaFacturaElectronica.ESTADO)
                    .pais = fElectronicaValidaCampo(Empresa_Sistema.PAIS)
                    .codigoPostal = "00000"
                End With
            Else
                Cfd.Receptor.nombre = fElectronicaValidaCampo(oCliente.NOMBRE_CLIENTE)
                Cfd.Receptor.rfc = fElectronicaValidaCampo(oCliente.RFC)
                With Cfd.Receptor.Domicilio
                    .calle = fElectronicaValidaCampo(oCliente.CALLE)
                    .noExterior = fElectronicaValidaCampo(oCliente.NUMERO_EXTERIOR)
                    .noInterior = fElectronicaValidaCampo(oCliente.NUMERO_INTERIOR)
                    .colonia = fElectronicaValidaCampo(oCliente.COLONIA)
                    .localidad = fElectronicaValidaCampo(oCliente.LOCALIDAD)

                    'Ahora estos 3 campos se forzan a que calzen con los catálogos del sat para estandarizar.
                    '.municipio = fElectronicaValidaCampo(oCliente.CIUDAD)
                    '.estado = fElectronicaValidaCampo(oCliente.ESTADO)
                    '.pais = fElectronicaValidaCampo(oCliente.PAIS)

                    If oCliente.CODIGO_PAIS_SAT <> "MEX" Then
                        .municipio = fElectronicaValidaCampo(oCliente.CIUDAD) 'Al ser extranjero no hay catalogo de municipios y se teclea manual.
                    Else
                        If txtLEN(oCliente.CODIGO_MUNICIPIO) = False And txtLEN(oCliente.CIUDAD) = True Then 'Tiene escrita la ciudad(municipio) a mano y no calza con ninguna del catálogo del sat, se forza a que falle
                            .municipio = "."
                        Else
                            .municipio = fElectronicaValidaCampo(oCliente.NOMBRE_MUNICIPIO) 'Nota en la validacion se pregunta por oCliente.CIUDAD que es escrito a mano, pero se usa el nombre del catálogo del sat, igual con estado y pais
                        End If
                    End If

                    If txtLEN(oCliente.CODIGO_ESTADO_SAT) = False And txtLEN(oCliente.ESTADO) = True Then 'Tiene escrito el estado mano y no calza con ninguno del catálogo del sat, se forza a que falle
                        .estado = "."
                    Else
                        .estado = fElectronicaValidaCampo(oCliente.NOMBRE_ESTADO) 'Ver nota de municipio
                    End If

                    'If txtLEN(oCliente.CODIGO_PAIS_SAT) = False And txtLEN(oCliente.PAIS) = True Then 'Tiene escrito el pais mano y no calza con ninguno del catálogo del sat, se forza a que falle
                    If txtLEN(oCliente.CODIGO_PAIS_SAT) = False Then 'Tiene escrito el pais mano y no calza con ninguno del catálogo del sat, se forza a que falle
                        .pais = "."
                    Else
                        .pais = fElectronicaValidaCampo(oCliente.NOMBRE_PAIS) 'Ver nota de municipio
                    End If

                    .codigoPostal = fElectronicaValidaCampo(oCliente.CODIGO_POSTAL.ToString)
                End With
            End If

            If ValidaDatoFacturaElectronica(Cfd) = False Then
                Return False
            End If
            '_Conexion.Close()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Conceptos''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '!!!NOTA, cuando se hagan las dev ya no considerar lo de diferenciar entre pco gral o no !!!!!!!

            'Dim tArticulos As DataTable
            'tArticulos = oDescuento.ObtenerDetalle
            'If sEsPorDevolucion = "1" Then
            'Aqui crearemos un ciclo para integrar los conceptos que tenga la factura
            'For Each row As DataRow In tArticulos.Rows
            '    'If sVentaPublicoGeneral = "1" Then
            '    '    dPrecio = valorNumerico(row("IMPORTE")) + valorNumerico(row("IMPUESTO_IMPORTE")) 'ojo si es publico gral  no desglosar iva
            '    'Else
            '    dDescuento = valorNumerico(row("DESCUENTO"))
            '    'End If

            '    drImporte = valorNumerico(row("IMPORTE"))
            '    Call Redondear(drImporte, Empresa_Sistema.DECIMALES_CONTABILIDAD)
            '    Cfd.Conceptos.Add(row("IMPORTE"), fElectronicaValidaCampo(row("IMPORTE")), CStr(drImporte), row("DESCUENTO"), CStr(dDescuento))
            'Next
            Cfd.Conceptos.Add("1.00", fElectronicaValidaCampo(oDescuento.CONCEPTO1), oDescuento.SUBTOTAL, "No aplica", oDescuento.SUBTOTAL)
            'Else 'Entonces es una nota de crédito directa.
            '    '    'CDF
            '    If sVentaPublicoGeneral = "1" Then
            '        Cfd.Conceptos.Add("1.00", fElectronicaValidaCampo(tArticulos.Columns("DESCRIPCION").ToString), row("total").ToString, "No aplica", row("total").ToString)
            '    Else
            '        Cfd.Conceptos.Add("1.00", fElectronicaValidaCampo(tArticulos.Columns("DESCRIPCION").ToString), row("subTotal").ToString, "No aplica", row("subTotal").ToString)
            '        'Cfd.Conceptos.Add("1.00", fElectronicaValidaCampo(rst!Concepto), rst!subTotal, "No aplica", rst!subTotal)
            '    End If
            'End If
            '------------------------------------------------------------------------------------------------------------------------------------------------

            If Cfd.Sellar(sRutaXML, cComprobante.TipoComprobante.NOTA_CREDITO_CXC, True) = True Then
                bResultado = True
                If bMostrarMensaje = True Then
                    MsgBox("Nota de crédito timbrada satisfactoriamente.", MsgBoxStyle.Information, sProcedure) 'se quito, solo marca error en caso de no sellar desde facturacion , en el grabar
                End If
            End If

        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        Finally
            Cfd = New cComprobante 'vaciar el comprobante
        End Try

        Return bResultado
    End Function

    Public Function GeneraCXCDevolucionElectronica(ByVal oDescuento As Class_CXC_Devoluciones_Global, ByVal bMostrarMensaje As Boolean, ByVal sRutaXML As String) As Boolean
        Const sProcedure As String = "GeneraCXCDevolucionElectronica"
        Dim bResultado As Boolean = False

        Try
            MsgBox("falta desarrollar..")
        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        Finally

        End Try

        Return bResultado
    End Function

    Public Function fElectronicaValidaCampo(ByRef campo As String) As String
        fElectronicaValidaCampo = ""
        Try
            campo = Replace(campo, "|", "")
            campo = Replace(campo, Chr(10), "")
            campo = Replace(campo, Chr(9), "")
            campo = Replace(campo, vbCrLf, "")
            campo = Replace(campo, "#", "")
            'campo = Replace(campo, ".", "") 'si se usa en abreviaciones, (s.a   col.   No.)
            'campo = Replace(campo, ",", "") 'si se usa en razones sociales(AGRICOLA AMHER, SPR DE RL)
            'campo = Replace(campo, "-", "") 'si se usa en folios(FA-454)
            campo = Trim(campo)
            campo = Replace(campo, "      ", " ")
            campo = Replace(campo, "     ", " ")
            campo = Replace(campo, "    ", " ")
            campo = Replace(campo, "   ", " ")
            campo = Replace(campo, "  ", " ")

            If campo Is Nothing Then
                campo = ""
            End If

            Return campo

        Catch ex As Exception
            HandleError(nombreModulo, "fElectronicaValidaCampo", ex)
        End Try
    End Function

    Public Function ValidaHuecosFoliosElectronicosVenta(ByVal iMes As Short, ByRef iAño As Short) As Boolean
        Dim bResultado As Boolean = False
        Dim bAbortar As Boolean
        Try
            Dim cmd As New SqlCommand
            Dim dReader As SqlDataReader
            Dim sqlParametro As SqlParameter, i As Integer = 0
            With cmd
                .Connection = _Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MP_VENTA_VALIDA_HUECOS_FOLIOS_ELECTRONICOS"

                sqlParametro = .Parameters.Add("@MES", SqlDbType.SmallInt) : sqlParametro.Value = iMes
                sqlParametro = .Parameters.Add("@ANIO", SqlDbType.SmallInt) : sqlParametro.Value = iAño
                sqlParametro = .Parameters.Add("@PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Plaza.CODIGO_PLAZA

                _Conexion.Open()
                dReader = .ExecuteReader()
            End With

            If dReader.Read = True Then
                MsgBox("Hay huecos en los folios :" & vbCrLf & dReader(0).Value, MsgBoxStyle.Exclamation, nombreModulo)
                bAbortar = True
            End If

            _Conexion.Close()
            cmd = Nothing

            If bAbortar = False Then
                bResultado = True
            End If
            _Conexion.Close()

        Catch ex As Exception
            HandleError(nombreModulo, "ValidaHuecosFoliosElectronicosVenta", ex)
            _Conexion.Close()
        End Try
        Return bResultado
    End Function

    Public Function ValidaHuecosFoliosElectronicosNotasCreditoCXC(ByVal iMes As Short, ByRef iAño As Short) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim dReader As SqlDataReader
        Dim sqlParametro As SqlParameter, i As Integer = 0
        Dim bAbortar As Boolean
        Try
            With cmd
                .Connection = _Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MP_CXC_DESCUENTOS_VALIDA_HUECOS_FOLIOS_ELECTRONICOS"

                sqlParametro = .Parameters.Add("@MES", SqlDbType.SmallInt) : sqlParametro.Value = iMes
                sqlParametro = .Parameters.Add("@ANIO", SqlDbType.SmallInt) : sqlParametro.Value = iAño
                sqlParametro = .Parameters.Add("@PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = ""

                _Conexion.Open()
                dReader = .ExecuteReader()

            End With

            If dReader.Read = True Then
                MsgBox("Hay huecos en los folios :" & vbCrLf & dReader(0).Value, MsgBoxStyle.Exclamation, nombreModulo)
                bAbortar = True
            End If

            _Conexion.Close()
            cmd = Nothing

            If bAbortar = False Then
                bResultado = True
            End If
        Catch ex As Exception
            HandleError(nombreModulo, "ValidaHuecosFoliosElectronicosNotasCreditoCXC", ex)
        End Try
        Return bResultado
    End Function

    Private Function ValidaDatoFacturaElectronica(ByRef Cfd As cComprobante, Optional ByVal bValidarDatosXComplementoComercioExterior As Boolean = False) As Boolean
        Try
            If txtLEN(Cfd.Receptor.nombre) = False Or Cfd.Receptor.nombre = "." Then
                MsgBox("El dato ''Nombre'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, nombreModulo)
                Return False
            ElseIf txtLEN(Cfd.Receptor.rfc) = False Or Cfd.Receptor.rfc = "." Then
                MsgBox("El dato ''RFC'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, nombreModulo)
                Return False
                'ElseIf txtLEN(Cfd.Receptor.Domicilio.calle) = False Or Cfd.Receptor.Domicilio.calle = "." Then
                '    MsgBox("El dato ''Calle'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, nombreModulo)
                '    Return False
                'ElseIf (Cfd.Receptor.Domicilio.noExterior <> Nothing And txtLEN(Cfd.Receptor.Domicilio.noExterior) = False) Or Cfd.Receptor.Domicilio.noExterior = "." Then
                '    MsgBox("El dato ''Número exterior'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, nombreModulo)
                '    Return False
                'ElseIf txtLEN(Cfd.Receptor.Domicilio.municipio) = False Or Cfd.Receptor.Domicilio.municipio = "." Then
                '    MsgBox("El dato ''Municipio/Ciudad'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, nombreModulo)
                '    Return False
                'ElseIf txtLEN(Cfd.Receptor.Domicilio.estado) = False Or Cfd.Receptor.Domicilio.estado = "." Then
                '    MsgBox("El dato ''Estado'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, nombreModulo)
                '    Return False
            ElseIf txtLEN(Cfd.Receptor.Domicilio.pais) = False Or Cfd.Receptor.Domicilio.pais = "." Then
                MsgBox("El dato ''País'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, nombreModulo)
                Return False
                'ElseIf txtLEN(Cfd.Receptor.Domicilio.codigoPostal) = False Or Cfd.Receptor.Domicilio.codigoPostal = "." Then
                '    MsgBox("El dato ''Código postal'' del cliente no esta capturado.", MsgBoxStyle.Exclamation, nombreModulo)
                '    Return False
            End If

            If bValidarDatosXComplementoComercioExterior = True Then
                Dim oPais As New Class_CatPaises(Cfd.Receptor.Domicilio.pais)
                If oPais.Existe = False OrElse Cfd.Receptor.Domicilio.pais = "MEX" Then
                    MsgBox("Receptor.Domicilio.pais - La clave en el atributo [pais] debe existir en el catálogo c_pais y debe ser diferente de {MEX}.", MsgBoxStyle.Exclamation, nombreModulo)
                    Return False
                End If
                Dim oEstado As New Class_SisEstados(Cfd.Receptor.Domicilio.estado, Cfd.Receptor.Domicilio.pais)
                If oEstado.Existe = False Then
                    MsgBox("Receptor.Domicilio.estado - Si la clave de país es {ZZZ} o la clave del país no existe en la columna c_Pais del catálogo c_Estado, se podrá registrar texto libremente. " & vbCrLf &
                           "En otro caso, debe contener una clave del catálogo c_Estado, donde la columna clave de país sea igual a la clave de país registrada en el atributo [pais].", MsgBoxStyle.Exclamation, nombreModulo)
                    Return False
                End If
            End If

            'Estos antes los pedia obligatoriamente, ahora si están como opcionales, para los cfdi al extranjero, sólo validamos que no tengan un punto a secas.
            If Cfd.Receptor.Domicilio.calle = "." Then
                MsgBox("El dato ''Calle'' del cliente esta mal capturado(puede dejarlo en blanco).", MsgBoxStyle.Exclamation, nombreModulo)
                Return False
            ElseIf Cfd.Receptor.Domicilio.noExterior = "." Then
                MsgBox("El dato ''Número exterior'' del cliente esta mal capturado(puede dejarlo en blanco).", MsgBoxStyle.Exclamation, nombreModulo)
                Return False
            ElseIf Cfd.Receptor.Domicilio.municipio = "." Then
                MsgBox("El dato ''Municipio/Ciudad'' del cliente esta mal capturado(puede dejarlo en blanco).", MsgBoxStyle.Exclamation, nombreModulo)
                Return False
            ElseIf Cfd.Receptor.Domicilio.estado = "." Then
                MsgBox("El dato ''Estado'' del cliente esta mal capturado(puede dejarlo en blanco).", MsgBoxStyle.Exclamation, nombreModulo)
                Return False
            ElseIf Cfd.Receptor.Domicilio.codigoPostal = "." Then
                MsgBox("El dato ''Código postal'' del cliente esta mal capturado(puede dejarlo en blanco).", MsgBoxStyle.Exclamation, nombreModulo)
                Return False
            End If

            'Cfd.Receptor.Domicilio.colonia = fElectronicaValidaCampo(Empty & rst1!colonia)
            'Cfd.Receptor.Domicilio.localidad = fElectronicaValidaCampo(Empty & rst1!CIUDAD)

            Return True

        Catch ex As Exception
            HandleError(nombreModulo, "ValidaDatoFacturaElectronica", ex)
        End Try
    End Function

    Public Function ConvierteFechaTipoXML(ByVal sFechaXML As String) As Date
        Return CDate(Replace(sFechaXML, "T", " "))
    End Function

    Public Function GestionaFechaCertificadoCFD() As String
        Dim sMensaje As String = ""
        Try
            Dim CKCert As New CHILKATCERTIFICATELib.ChilkatCert, dFechaServidor As Date, dFechaCertificado As Date, iDias As Integer

            CKCert.LoadFromFile(sFelectronicaArchivoCERLocal)

            Dim sqlResult As New Class_find("SELECT GETDATE()")
            dFechaServidor = CDate(sqlResult.Result1)

            dFechaCertificado = CDate(CKCert.ValidTo)

            iDias = DateDiff("D", dFechaServidor, dFechaCertificado)

            Select Case iDias
                Case 1 To 15
                    sMensaje = "Atención !!!, quedan " & iDias & " dias para que caduque el certificado que sirve para sellar facturas. Tiene que generar un nuevo CSD a la brevedad"
                Case Is <= 0
                    sMensaje = "Atención !!!, el certificado que sirve para sellar facturas está caducado."
                Case Else
                    sMensaje = ""
            End Select

            CKCert = Nothing

        Catch ex As Exception
            HandleError(nombreModulo, "GestionaFechaCertificadoCFD", ex)
        End Try

        Return sMensaje
    End Function

    Public Function GestionaExistanArchivosContabilidadElectronica() As Boolean
        Dim bResultado As Boolean = False
        Dim sNombreServidor As String
        Dim sCarpetaTrabajoServer, sCarpetaTrabajoLocal As String
        Dim sCadenaOriginalCatalogoCuentasServer, sCadenaOriginalBalanzaComprobacionServer, sCadenaOriginalPolizasServer As String

        Const sProcedure As String = "GestionaExistanArchivosContabilidadElectronica"

        Try
            sNombreServidor = Split(My.Settings.Servidor, "\")(0)
            sCarpetaTrabajoServer = "\\" & sNombreServidor & "\" & Right(My.Settings.Ruta, Len(My.Settings.Ruta) - InStrRev(My.Settings.Ruta, "\")) & "\" & "CONTABILIDAD_ELECTRONICA"
            sCarpetaTrabajoLocal = My.Settings.Ruta & "\CONTABILIDAD_ELECTRONICA"

            sContabilidadElectronicaCarpeta = sCarpetaTrabajoLocal & "\" & My.Settings.BaseDatos

            'Crea las carpetas relacionadas a la contabilidad electrónica en caso de que el usuario no la tenga en su equipo.
            If Len(Dir(sCarpetaTrabajoLocal, FileAttribute.Directory)) = 0 Then
                MkDir(sCarpetaTrabajoLocal)
            End If
            If Len(Dir(sContabilidadElectronicaCarpeta, FileAttribute.Directory)) = 0 Then
                MkDir(sContabilidadElectronicaCarpeta)
            End If

            sContabilidadElectronicaArchivoCadenaOriginalLocalCatalogoCuentas = sCarpetaTrabajoLocal & "\" & Empresa_Sistema.CONTAELECTRONICA_CADENA_ORIGINAL_CATALOGO_CUENTAS
            sContabilidadElectronicaArchivoCadenaOriginalLocalBalanzaComprobacion = sCarpetaTrabajoLocal & "\" & Empresa_Sistema.CONTAELECTRONICA_CADENA_ORIGINAL_BALANZA_COMPROBACION
            sContabilidadElectronicaArchivoCadenaOriginalLocalPolizas = sCarpetaTrabajoLocal & "\" & Empresa_Sistema.CONTAELECTRONICA_CADENA_ORIGINAL_POLIZAS

            sCadenaOriginalCatalogoCuentasServer = sCarpetaTrabajoServer & "\" & Empresa_Sistema.CONTAELECTRONICA_CADENA_ORIGINAL_CATALOGO_CUENTAS
            sCadenaOriginalBalanzaComprobacionServer = sCarpetaTrabajoServer & "\" & Empresa_Sistema.CONTAELECTRONICA_CADENA_ORIGINAL_BALANZA_COMPROBACION
            sCadenaOriginalPolizasServer = sCarpetaTrabajoServer & "\" & Empresa_Sistema.CONTAELECTRONICA_CADENA_ORIGINAL_POLIZAS

            If Len(Dir(sContabilidadElectronicaArchivoCadenaOriginalLocalCatalogoCuentas)) = 0 Then
                If Len(Dir(sCadenaOriginalCatalogoCuentasServer)) = 0 OrElse Copiar_Archivo(sCadenaOriginalCatalogoCuentasServer, sContabilidadElectronicaArchivoCadenaOriginalLocalCatalogoCuentas) = False Then
                    MsgBox("No existe en el servidor el archivo de la cadena original para el catálogo de cuentas, no podrá generar contabilidad eletrónica en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            If Len(Dir(sContabilidadElectronicaArchivoCadenaOriginalLocalBalanzaComprobacion)) = 0 Then
                If Len(Dir(sCadenaOriginalBalanzaComprobacionServer)) = 0 OrElse Copiar_Archivo(sCadenaOriginalBalanzaComprobacionServer, sContabilidadElectronicaArchivoCadenaOriginalLocalBalanzaComprobacion) = False Then
                    MsgBox("No existe en el servidor el archivo de la cadena original para la balanza de comprobación, no podrá generar contabilidad eletrónica en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            If Len(Dir(sContabilidadElectronicaArchivoCadenaOriginalLocalPolizas)) = 0 Then
                If Len(Dir(sCadenaOriginalPolizasServer)) = 0 OrElse Copiar_Archivo(sCadenaOriginalPolizasServer, sContabilidadElectronicaArchivoCadenaOriginalLocalPolizas) = False Then
                    MsgBox("No existe en el servidor el archivo de la cadena original para las pólizas, no podrá generar contabilidad eletrónica en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            End If

            bResultado = True
        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Public Function GenerarSelloContabilidadElectronicaConChilkat(ByRef xmlDoc As MSXML2.DOMDocument60, tipoContabilidad As TipoArchivoContabilidadElectronica) As FacturaElectronica
        Dim f As FacturaElectronica
        Const sProcedure As String = "GenerarSelloContabilidadElectronicaConChilkat"

        f.NumeroCertificadoDigital = ""
        f.IdCfdCertificado = Nothing
        f.CadenaOriginal = ""
        f.SelloDigital = ""

        Dim pkey As New CHILKATCERTIFICATELib.privateKey
        Dim success As Integer
        Dim pkeyXml As String
        Dim rsa As New CHILKATRSALib.ChilkatRsa
        Dim base64Sig As String
        Try
            pkey.LoadPkcs8EncryptedFile(sFelectronicaArchivoKEYLocal, Empresa_Sistema.FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA)

            pkeyXml = pkey.GetXml()

            success = rsa.UnlockComponent(CK_KEY)
            If (success <> 1) Then
                Debug.Print(rsa.LastErrorText & vbCrLf)
                Return f
                Exit Function
            End If

            success = rsa.ImportPrivateKey(pkeyXml)
            If (success <> 1) Then
                Debug.Print(rsa.LastErrorText & vbCrLf)
                Return f
                Exit Function
            End If

            rsa.Charset = "utf-8"
            rsa.EncodingMode = "base64"
            rsa.LittleEndian = 0

            'MsgBox("moverle a este para usar una o x cadena original")
            f.CadenaOriginal = GetCadenaOriginalContabilidadElectronicaConXSLT(xmlDoc, tipoContabilidad)
            If txtLEN(f.CadenaOriginal) = False Or Len(f.CadenaOriginal) <= 3 Then
                MsgBox("Error al intentar generar la cadena original(quedó vacía).", MsgBoxStyle.Exclamation, sProcedure)
                Return f
                Exit Function
            End If

            base64Sig = rsa.SignStringENC(f.CadenaOriginal, "sha1")

            f.SelloDigital = base64Sig
        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try
        Return f
    End Function

    'Public Function GenerarSelloContabilidadElectronicaConPFX(ByRef xmlDoc As MSXML2.DOMDocument60, tipoContabilidad As TipoArchivoContabilidadElectronica) As FacturaElectronica
    Public Function GenerarSelloContabilidadElectronicaConPFX(ByVal sRutaXML As String, tipoContabilidad As TipoArchivoContabilidadElectronica) As FacturaElectronica
        Dim f As FacturaElectronica
        Const sProcedure As String = "GenerarSelloContabilidadElectronicaConPFX"

        f.NumeroCertificadoDigital = ""
        f.IdCfdCertificado = Nothing
        f.CadenaOriginal = ""
        f.SelloDigital = ""

        Try
            'f.CadenaOriginal = GetCadenaOriginalContabilidadElectronica(xmlDoc, tipoContabilidad)
            f.CadenaOriginal = GetCadenaOriginalContabilidadElectronicaConDLL(sRutaXML, tipoContabilidad)

            If txtLEN(f.CadenaOriginal) = False Then
                MsgBox("Error al intentar generar la cadena original(quedó vacía).", MsgBoxStyle.Exclamation, sProcedure)
                Return f
                Exit Function
            End If

            'Versión sha1
            'Dim objCert As New X509Certificates.X509Certificate2(sFelectronicaArchivoPFX, Decrypt(Empresa_Sistema.FELECTRONICA_CONTRASENIA_PFX, "ex8"))
            'Dim lRSA As RSACryptoServiceProvider = CType(objCert.PrivateKey, RSACryptoServiceProvider)
            'Dim sha1 As New SHA1CryptoServiceProvider()
            'Dim bytesFirmados As Byte() = lRSA.SignData(System.Text.Encoding.UTF8.GetBytes(f.CadenaOriginal), sha1)
            'f.SelloDigital = Convert.ToBase64String(bytesFirmados)
            'lRSA = Nothing
            'objCert = Nothing
            'sha1 = Nothing

            'Versión sha256
            Dim objCert As New X509Certificates.X509Certificate2(sFelectronicaArchivoPFX, Empresa_Sistema.FELECTRONICA_CONTRASENIA_PFX, X509KeyStorageFlags.Exportable)
            Dim lRSA As RSACryptoServiceProvider = DirectCast(objCert.PrivateKey, RSACryptoServiceProvider)
            Dim privateKey1 As New RSACryptoServiceProvider()
            privateKey1.ImportParameters(lRSA.ExportParameters(True))
            Dim bytesFirmados As Byte() = privateKey1.SignData(System.Text.Encoding.UTF8.GetBytes(f.CadenaOriginal), "SHA256")
            f.SelloDigital = Convert.ToBase64String(bytesFirmados)
            lRSA = Nothing
            objCert = Nothing
            privateKey1 = Nothing

        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try

        Return f
    End Function

    Public Function GetCadenaOriginalContabilidadElectronicaConXSLT(ByRef xmlDoc As MSXML2.DOMDocument60, tipoContabilidad As TipoArchivoContabilidadElectronica) As String
        Dim sCadenaOriginal As String = ""
        Const sProcedure As String = "GetCadenaOriginalContabilidadElectronicaConXSLT"

        Dim xslt As New MSXML2.XSLTemplate60
        Dim xslDoc As New MSXML2.FreeThreadedDOMDocument60
        Dim xslProc As MSXML2.IXSLProcessor

        Dim fileXSLT As String = ""
        Select Case tipoContabilidad
            Case TipoArchivoContabilidadElectronica.CATALOGO_CUENTAS
                fileXSLT = sContabilidadElectronicaArchivoCadenaOriginalLocalCatalogoCuentas
            Case TipoArchivoContabilidadElectronica.BALANZA_COMPROBACION
                fileXSLT = sContabilidadElectronicaArchivoCadenaOriginalLocalBalanzaComprobacion
            Case TipoArchivoContabilidadElectronica.POLIZAS
                fileXSLT = sContabilidadElectronicaArchivoCadenaOriginalLocalPolizas
        End Select

        Try
            xslDoc.async = False
            xslDoc.load(fileXSLT)

            Dim myErr As Object
            If (xslDoc.parseError.errorCode <> 0) Then
                myErr = xslDoc.parseError
                MsgBox("Error en la hoja de estilo: " & myErr.reason, MsgBoxStyle.Critical, sProcedure)
            Else
                xslDoc.setProperty("ResolveExternals", True) ' Esta línea es importante ya que sin ella el proceso no se ejecutará de manera correcta
                xslt.stylesheet = xslDoc

                If (xmlDoc.parseError.errorCode <> 0) Then
                    myErr = xmlDoc.parseError
                    MsgBox("Error en el documento XML: " & myErr.reason, MsgBoxStyle.Critical, sProcedure)
                Else
                    xslProc = xslt.createProcessor()
                    xslProc.input = xmlDoc
                    xslProc.transform()
                    sCadenaOriginal = xslProc.output
                End If
            End If
        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        End Try

        Return sCadenaOriginal
    End Function

    Public Function GetCadenaOriginalContabilidadElectronicaConDLL(ByVal sRutaXML As String, tipoContabilidad As TipoArchivoContabilidadElectronica) As String
        Const sProcedure As String = "GetCadenaOriginalContabilidadElectronicaConDLL"
        Dim CadenaOriginal As String = ""
        Dim ms As New System.IO.MemoryStream()
        Dim XSL As New System.Xml.Xsl.XslCompiledTransform()
        Try
            Dim reader As New StreamReader(sRutaXML)
            Dim myXPathDoc As New XPathDocument(reader)

            Select Case tipoContabilidad
                Case TipoArchivoContabilidadElectronica.CATALOGO_CUENTAS
                    XSL.Load(GetType(CatalogoCuentas_1_2))
                Case TipoArchivoContabilidadElectronica.BALANZA_COMPROBACION
                    XSL.Load(GetType(BalanzaComprobacion_1_2))
                Case TipoArchivoContabilidadElectronica.POLIZAS
                    XSL.Load(GetType(PolizasPeriodo_1_2))
            End Select

            XSL.Transform(myXPathDoc, Nothing, MS)
            CadenaOriginal = Encoding.UTF8.GetString(MS.ToArray()).Trim
            CadenaOriginal = Replace(CadenaOriginal, "﻿", "") 'Quita un caracter extraño al inicio de la cadena

        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
        Finally
            MS.Dispose()
            XSL = Nothing
        End Try

        Return CadenaOriginal
    End Function

End Module