Option Strict Off
Option Explicit On

Imports cfdi
Imports System.Data.SqlClient
Imports System.IO

Module FacturacionElectronica

    Private Const nombreModulo As String = "FacturacionElectronica"
    Public Const CK_KEY As String = "RSAT34MB34N_2637664B634J"

    Private oComprobante As New cComprobante

    Private sCarpetaCertificados As String = ""
    Private tPlazaFacturaElectronica As Class_SisPlazas

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String = "FacturacionElectronica"
    Private _Conexion As New SqlConnection(Empresa_Sistema.conexion)
#End Region

    Public Enum TipoComprobante
        FACTURA_VENTA
        NOTA_CREDITO_CXC
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

            If My.Computer.Name = "PCSISTEMASJORGE" Or My.Computer.Name = "ERNESTOA" Or Usuario.Codigo_Usuario = 1 Then
                MsgBox("Las computadoras de sistemas no deben timbrar documentos." & vbCrLf & "Ni el dba(por protección de timbrar por error estando en pruebas).", MsgBoxStyle.Exclamation, sProcedure)
                Exit Function
            Else
                Using cfd As New clsCFDI(sRutaXML, Empresa_Sistema.BaseDatos, Empresa_Sistema.Servidor, _
                                  sFelectronicaArchivoPFX, Decrypt(Empresa_Sistema.FELECTRONICA_CONTRASENIA_PFX, "ex8"), _
                                  Empresa_Sistema.FELECTRONICA_USER_WS, Empresa_Sistema.FELECTRONICA_PASS_WS, True)

                    If txtLEN(cfd.RecuperarTimbrePorSerieFolio(sSerie, iFolioNumerico, Empresa_Sistema.RFC, sFelectronicaCbbImagen)) = True Then
                        If cfd.Recuperado = True Then
                            Dim sRutaXMLTimbrado As String = sFelectronicaCarpetaXmlsTimbrados & "\" & sFolioDocumentoSistema & ".xml"
                            'cfd.Timbrar(sRutaXMLTimbrado, sFelectronicaCbbImagen)
                            docXml.LoadXml(cfd.RecuperarTimbrePorSerieFolio(sSerie, iFolioNumerico, Empresa_Sistema.RFC, sFelectronicaCbbImagen))
                            docXml.Save(sRutaXMLTimbrado)
                            bResultado = True
                        End If
                    Else
                        cfd.Sellar()
                        If cfd.Sellado = True Then
                            Dim sRutaXMLTimbrado As String = sFelectronicaCarpetaXmlsTimbrados & "\" & sFolioDocumentoSistema & ".xml"
                            cfd.Timbrar(sRutaXMLTimbrado, sFelectronicaCbbImagen, True)
                            If cfd.Timbrado = True Then
                                'sFolioFacturaSistema, cfd.XmlTimbrado.ToString,
                                If GrabaCadenaOriginalYSelloComprobanteElectronico(cfd, tipoComprobante) = True Then
                                    bResultado = True
                                End If
                            End If
                        End If
                    End If
                End Using
            End If

            xmlDoc = Nothing
            Factura = Nothing

        Catch ex As Exception
            HandleError(_Nombre_Catalogo, sProcedure, ex)
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

            c.noCertificado = FormatearSerie(CKCert.SerialNumber)
            c.Certificado = Mid(CKCert.GetEncoded(), 1, Len(CKCert.GetEncoded()) - 2)
            c.CertificadoValido = True
        Catch ex As Exception
            HandleError(_Nombre_Catalogo, sProcedure, ex)
        End Try
        Return c
    End Function

    Public Function CancelarCFDIVenta(ByVal oVenta As Class_Ventas_Global, ByVal TipoComprobante As TipoComprobante) As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "CancelarCFDIVenta"
        Try
            bResultado = CancelarCFDI(oVenta.FOLIO_VENTA, oVenta.SERIE, oVenta.FOLIO_NUMERICO, oVenta.FOLIO_FISCAL_SAT, oVenta.TIMBRADO_CFDI, TipoComprobante)
        Catch ex As Exception
            HandleError(_Nombre_Catalogo, sProcedure, ex)
        End Try
        Return bResultado
    End Function

    Public Function CancelarCFDIDescuento(ByVal oDescuento As Class_CXC_Descuento, ByVal TipoComprobante As TipoComprobante) As Boolean
        Dim bResultado As Boolean
        Const sProcedure As String = "CancelarCFDIDescuento"
        Try
            bResultado = CancelarCFDI(oDescuento.FOLIO_DESCUENTO, oDescuento.SERIE, oDescuento.FOLIO_NUMERICO, oDescuento.FOLIO_FISCAL_SAT, oDescuento.TIMBRADO_CFDI, TipoComprobante)
        Catch ex As Exception
            HandleError(_Nombre_Catalogo, sProcedure, ex)
        End Try
        Return bResultado
    End Function

    Private Function CancelarCFDI(ByVal sFolioDocumentoSistema As String, ByVal sSerie As String, ByVal iFolioNumerico As Integer, ByVal sFolioFiscalSat As String, ByVal sDocumentoYaEstaTimbrado As String, ByVal sTipoComprobante As TipoComprobante) As Boolean
        Const sProcedure As String = "CancelarCFDI"
        Dim bResultado As Boolean = False

        Dim ArchivoXmlAcuseCancelacion As String = sFelectronicaCarpetaXmlsAcusesCancelacion & "\AcuseCancelacion_" & sFolioDocumentoSistema & ".xml" ' "la ruta de los xml de acuses de cancelacion"
        Dim sUUID As String = "" ' "el folio del sat del documento"
        Dim sXml As String = ""
        'Dim sSerie As String = Left(sFolioDocumentoSistema, 3).ToString
        'Dim iFolioNumerico As Integer = sFolioDocumentoSistema.Substring(4, Len(sFolioDocumentoSistema) - 4)
        Dim sAcuseCancelacion As String = ""

        Try
            If My.Computer.Name = "PCSISTEMASJORGE" Or My.Computer.Name = "ERNESTOA" Or Usuario.Codigo_Usuario = 1 Then
                MsgBox("Las computadoras de sistemas no deben cancelar timbres documentos.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            Using cfd As New clsCFDI(Empresa_Sistema.BaseDatos, Empresa_Sistema.Servidor, sFelectronicaArchivoPFX, _
                                    Decrypt(Empresa_Sistema.FELECTRONICA_CONTRASENIA_PFX, "ex8"), _
                                    Empresa_Sistema.FELECTRONICA_USER_WS, Empresa_Sistema.FELECTRONICA_PASS_WS)

                If sDocumentoYaEstaTimbrado = "0" Then
                    'Recuperar 
                    sXml = cfd.RecuperarTimbrePorSerieFolio(sSerie, iFolioNumerico, Empresa_Sistema.RFC, sFelectronicaCbbImagen)
                    If cfd.Recuperado = False Then 'No se recupero
                        If sXml = "ErrorDLL" Then
                            'No descarta el timbre por algun otro error, que no necesariamente signifca que no exista el timbre
                            Exit Function
                        End If
                        DescartarTimbrado(sFolioDocumentoSistema, sTipoComprobante) 'ActualizaEstatusTimbradoDescartado(Folio, sTipoComprobanteElectronico)
                        Exit Function
                    Else
                        sXml = Replace(sXml, "<?xml version=""1.0"" encoding=""UTF-8""?>", "")
                        'Se recupero 'sFolioFacturaSistema, sXml, 
                        If GrabaCadenaOriginalYSelloComprobanteElectronico(cfd, sTipoComprobante) = False Then
                            Exit Function
                        End If
                    End If
                    sUUID = cfd.Complemento.UUID
                Else
                    sUUID = sFolioFiscalSat
                End If

                'Cancelar timbre
                cfd.CancelarTimbre(Empresa_Sistema.RFC, sUUID, ArchivoXmlAcuseCancelacion, True)

                If cfd.Cancelado = True Then
                    bResultado = True 'Marcamos true sin hacer lo del acuse, porque no es importante grabarlo
                    GrabaCancelacionYAcuseXML(sFolioDocumentoSistema, cfd.XmlAcuseCancelacionTimbre, sTipoComprobante)
                End If
            End Using

        Catch ex As Exception
            HandleError(_Nombre_Catalogo, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function GrabaCancelacionYAcuseXML(ByVal sFolioFacturaSistema As String, ByRef sAcuseCancelacionXML As String, ByVal sTipoComprobanteElectronico As TipoComprobante) As Boolean
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
                        sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolioFacturaSistema
                    Case TipoComprobante.NOTA_CREDITO_CXC '"NOTA_CREDITO_CXC"
                        .CommandText = "MP_CXC_NOTAS_CREDITO_ELECTRONICA_CANCELA_Y_GUARDA_ACUSE_XML"
                        sqlParametro = .Parameters.Add("@FOLIO_DESCUENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolioFacturaSistema
                    Case Else
                        MsgBox("No se indicó el tipo de comprobante electrónico generado para grabar los datos de cancelación del documento.", MsgBoxStyle.Exclamation, sProcedure)
                        cmd = Nothing
                        Exit Function
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
            HandleError(_Nombre_Catalogo, sProcedure, ex)
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
                HandleError(_Nombre_Catalogo, "DescartarTimbrado", ex)
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
            HandleError(_Nombre_Catalogo, "ConvierteXMLUTF8", ex)
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
            HandleError(_Nombre_Catalogo, "ConvierteUTF8", ex)
        End Try

        Return bResultado
    End Function

    Private Function GrabaCadenaOriginalYSelloComprobanteElectronico(ByRef fElectronica As clsCFDI, ByVal sTipoComprobanteElectronico As String) As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "GrabaCadenaOriginalYSelloComprobanteElectronico"
        Try
            Dim cmd As New SqlCommand
            Dim sqlParametro As SqlParameter

            With cmd
                .Connection = _Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure

                Select Case sTipoComprobanteElectronico
                    Case TipoComprobante.FACTURA_VENTA '"FACTURA_VENTA"
                        .CommandText = "MP_VENTAS_FACTURACION_ELECTRONICA_GRABA_DATOS_DIGITALES_Y_XML"
                        sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = fElectronica.Comprobante.FolioCompleto
                    Case TipoComprobante.NOTA_CREDITO_CXC '"NOTA_CREDITO_CXC"
                        .CommandText = "MP_CXC_NOTAS_CREDITO_ELECTRONICA_GRABA_DATOS_DIGITALES_Y_XML"
                        sqlParametro = .Parameters.Add("@FOLIO_DESCUENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = fElectronica.Comprobante.FolioCompleto
                    Case Else
                        MsgBox("No se indicó el tipo de comprobante electrónico generado para grabar los datos digitales del documento.", MsgBoxStyle.Exclamation, sProcedure)
                        cmd = Nothing
                        Exit Function
                End Select

                'sqlParametro = .Parameters.Add("@ID_SIS_CFD_CATALOGO_CERTIFICADOS", SqlDbType.NVarChar, 50) : sqlParametro.Value = fElectronica.IdCfdCertificado
                sqlParametro = .Parameters.Add("@VERSION_ESQUEMA_XML", SqlDbType.NVarChar, 6) : sqlParametro.Value = fElectronica.Comprobante.Version
                sqlParametro = .Parameters.Add("@CADENA_XML", SqlDbType.Xml) : sqlParametro.Value = fElectronica.XmlTimbrado.ToString 'sxml
                sqlParametro = .Parameters.Add("@NUMERO_CERTIFICADO_DIGITAL", SqlDbType.NVarChar, 50) : sqlParametro.Value = fElectronica.Comprobante.noCertificado
                sqlParametro = .Parameters.Add("@CADENA_ORIGINAL", SqlDbType.NVarChar, 4000) : sqlParametro.Value = fElectronica.CadenaOriginal
                sqlParametro = .Parameters.Add("@SELLO_DIGITAL", SqlDbType.NVarChar, 2000) : sqlParametro.Value = fElectronica.Comprobante.SelloCFD
                sqlParametro = .Parameters.Add("@FOLIO_FISCAL_SAT", SqlDbType.NVarChar, 50) : sqlParametro.Value = fElectronica.Complemento.UUID.ToUpper
                sqlParametro = .Parameters.Add("@FECHA_TIMBRADO_SAT", SqlDbType.NVarChar, 20) : sqlParametro.Value = fElectronica.Complemento.FechaTimbrado
                sqlParametro = .Parameters.Add("@NUMERO_SERIE_CERTIFICADO_SAT", SqlDbType.NVarChar, 20) : sqlParametro.Value = fElectronica.Complemento.noCertificadoSAT
                sqlParametro = .Parameters.Add("@SELLO_SAT", SqlDbType.NVarChar, 500) : sqlParametro.Value = fElectronica.Complemento.SelloSAT
                sqlParametro = .Parameters.Add("@CBB_IMAGE", SqlDbType.Image) : sqlParametro.Value = fElectronica.ImagenCBB

                _Conexion.Open()
                .ExecuteNonQuery()
            End With
            cmd = Nothing
            bResultado = True

            _Conexion.Close()

        Catch ex As Exception
            _Conexion.Close()
            HandleError(_Nombre_Catalogo, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function FormatearSerie(ByVal serie As String) As String
        Dim resultado As String = ""
        Dim i As Short

        For i = 2 To Len(serie) Step 2
            resultado = resultado & Mid(serie, i, 1)
        Next

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
            HandleError(_Nombre_Catalogo, "CaracterEspecial", ex)
        End Try

        Return sResultado 'No se esta usando esta función al parecer
    End Function

    Public Function GestionaExistanCertificadosFacturaElectronica() As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "GestionaExistanCertificadosFacturaElectronica"
        Dim sNombreServidor As String
        Dim sCarpetaTrabajoServer, sCarpetaTrabajoLocal As String
        Dim sCarpetaDB As String
        Dim sCerServer, sCadenaOriginalServer, sKeyServer As String
        Dim sDllCfdi As String = "cfdi.dll"
        Dim sDllCo32 As String = "co32.dll"
        Dim sDllIonicZip As String = "Ionic.Zip.dll"
        Dim sDllQRCode As String = "ThoughtWorks.QRCode.dll"
        Dim sDllCfdiArchivo, sDllCo32Archivo, sDllIonicZipArchivo, sDllQRCodeArchivo As String
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

            sDllCfdiArchivo = My.Settings.Ruta & "\" & sDllCfdi
            sDllCo32Archivo = My.Settings.Ruta & "\" & sDllCo32
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
                    Exit Function
                End If
            End If

            If Path.GetFileNameWithoutExtension(sFelectronicaArchivoCERLocal) <> "FALTA" Then 'Si ya esta habilitada la felec, pero no se tiene aún el certificado se salta el buscar el cer,key y pfx
                If Len(Dir(sFelectronicaArchivoCERLocal)) = 0 Then
                    If Len(Dir(sCerServer)) = 0 OrElse Copiar_Archivo(sCerServer, sFelectronicaArchivoCERLocal) = False Then
                        MsgBox("No existe en el servidor el archivo .cer, no se podrán generar facturas electrónicas en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                        Exit Function
                    End If
                End If

                If Len(Dir(sFelectronicaArchivoKEYLocal)) = 0 Then
                    If Len(Dir(sKeyServer)) = 0 OrElse Copiar_Archivo(sKeyServer, sFelectronicaArchivoKEYLocal) = False Then
                        MsgBox("No existe en el servidor el archivo .key, no se podrán generar facturas electrónicas en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                        Exit Function
                    End If
                End If

                If Len(Dir(sFelectronicaArchivoPFX)) = 0 Then
                    If Len(Dir(sFelectronicaArchivoPFXServidor)) = 0 OrElse Copiar_Archivo(sFelectronicaArchivoPFXServidor, sFelectronicaArchivoPFX) = False Then
                        MsgBox("No existe en el servidor el archivo .pfx, no se podrán generar facturas electrónicas en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                        Exit Function
                    End If
                End If
            End If

            If Len(Dir(sFelectronicaConvierteUTF8Local)) = 0 Then
                If Len(Dir(sFelectronicaConvierteUTF8Servidor)) = 0 OrElse Copiar_Archivo(sFelectronicaConvierteUTF8Servidor, sFelectronicaConvierteUTF8Local) = False Then
                    MsgBox("No existe en el servidor el archivo para convertir el XML a UTF8, no se podrán generar facturas electrónicas en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                    Exit Function
                End If
            End If

            If Len(Dir(sDllCfdiArchivo)) = 0 Then
                If Len(Dir("\\" & sNombreServidor & "\" & Right(My.Settings.Ruta, Len(My.Settings.Ruta) - InStrRev(My.Settings.Ruta, "\")) & "\" & sDllCfdi)) = 0 OrElse Copiar_Archivo("\\" & sNombreServidor & "\" & Right(My.Settings.Ruta, Len(My.Settings.Ruta) - InStrRev(My.Settings.Ruta, "\")) & "\" & sDllCfdi, sDllCfdiArchivo) = False Then
                    MsgBox("No existe en el servidor el archivo Cfdi.dll, no se podrán generar facturas electrónicas en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                    Exit Function
                End If
            End If

            If Len(Dir(sDllCo32Archivo)) = 0 Then
                If Len(Dir("\\" & sNombreServidor & "\" & Right(My.Settings.Ruta, Len(My.Settings.Ruta) - InStrRev(My.Settings.Ruta, "\")) & "\" & sDllCo32)) = 0 OrElse Copiar_Archivo("\\" & sNombreServidor & "\" & Right(My.Settings.Ruta, Len(My.Settings.Ruta) - InStrRev(My.Settings.Ruta, "\")) & "\" & sDllCo32, sDllCo32Archivo) = False Then
                    MsgBox("No existe en el servidor el archivo Co32.dll, no se podrán generar facturas electrónicas en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                    Exit Function
                End If
            End If

            If Len(Dir(sDllIonicZipArchivo)) = 0 Then
                If Len(Dir("\\" & sNombreServidor & "\" & Right(My.Settings.Ruta, Len(My.Settings.Ruta) - InStrRev(My.Settings.Ruta, "\")) & "\" & sDllIonicZip)) = 0 OrElse Copiar_Archivo("\\" & sNombreServidor & "\" & "\" & Right(My.Settings.Ruta, Len(My.Settings.Ruta) - InStrRev(My.Settings.Ruta, "\")) & sDllIonicZip, sDllIonicZipArchivo) = False Then
                    MsgBox("No existe en el servidor el archivo Ionic.Zip.dll, no se podrán generar facturas electrónicas en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                    Exit Function
                End If
            End If

            If Len(Dir(sDllQRCodeArchivo)) = 0 Then
                If Len(Dir("\\" & sNombreServidor & "\" & Right(My.Settings.Ruta, Len(My.Settings.Ruta) - InStrRev(My.Settings.Ruta, "\")) & "\" & sDllQRCode)) = 0 OrElse Copiar_Archivo("\\" & sNombreServidor & "\" & Right(My.Settings.Ruta, Len(My.Settings.Ruta) - InStrRev(My.Settings.Ruta, "\")) & "\" & sDllQRCode, sDllQRCodeArchivo) = False Then
                    MsgBox("No existe en el servidor el archivo ThoughtWorks.QRCode.dll, no se podrán generar facturas electrónicas en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
                    Exit Function
                End If
            End If

            '28Abr17,jorgegc, lo quité, a pruebas, no deberia necesitarse ya que el cbb se genera en el momento.
            'If Len(Dir(sFelectronicaCbbImagen)) = 0 Then
            '    If Len(Dir(sFelectronicaCbbImagenServidor)) = 0 OrElse Copiar_Archivo(sFelectronicaCbbImagenServidor, sFelectronicaCbbImagen) = False Then
            '        MsgBox("No existe en el servidor el archivo Cbb.jpg, no se podrán generar facturas electrónicas en este equipo. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
            '        Exit Function
            '    End If
            'End If

            'If fElectronicaValidaArchivosCertificadoLocal(, , ) = False Then
            '    Exit Function
            'End If

            bResultado = True

        Catch ex As Exception
            HandleError(_Nombre_Catalogo, sProcedure, ex)
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
            HandleError(_Nombre_Catalogo, sProcedure, ex)
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

            Dim oMetodoPago As New Class_CFD_CatMetodosPago(oVenta.CODIGO_METODO_PAGO)
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

                        If txtLEN(oCliente.CODIGO_PAIS_SAT) = False And txtLEN(oCliente.PAIS) = True Then 'Tiene escrito el pais mano y no calza con ninguno del catálogo del sat, se forza a que falle
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
                    'dPrecio = valorNumerico(row("PRECIO")) + valorNumerico(row("IMPUESTO_IMPORTE")) 'ojo si es publico gral  no desglosar iva
                    'Else
                    dPrecio = valorNumerico(row("PRECIO"))
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
                sXmlComercioExterior = oVenta.GeneraXmlComercioExterior

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
            HandleError(_Nombre_Catalogo, sProcedure, ex)
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
                Dim Impuesto As New Class_find("SELECT 1 FROM CXC_DESCUENTOS_GLOBAL D INNER JOIN CXC_DESCUENTOS_DETALLE CD ON (D.FOLIO_DESCUENTO=CD.FOLIO_DESCUENTO) " & _
                "INNER JOIN CXC_GLOBAL G ON (CD.FOLIO_CXC=G.FOLIO_CXC) INNER JOIN VENTA_DETALLE VD ON(G.FOLIO_REFERENCIA=VD.FOLIO_VENTA) " & _
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

                    If txtLEN(oCliente.CODIGO_PAIS_SAT) = False And txtLEN(oCliente.PAIS) = True Then 'Tiene escrito el pais mano y no calza con ninguno del catálogo del sat, se forza a que falle
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
            HandleError(_Nombre_Catalogo, sProcedure, ex)
        Finally
            Cfd = New cComprobante 'vaciar el comprobante
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
            HandleError(_Nombre_Catalogo, "fElectronicaValidaCampo", ex)
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
            HandleError(_Nombre_Catalogo, "ValidaHuecosFoliosElectronicosVenta", ex)
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
            HandleError(_Nombre_Catalogo, "ValidaHuecosFoliosElectronicosNotasCreditoCXC", ex)
        End Try
        Return bResultado
    End Function

    Public Function GeneraInformeMensual(ByRef strPort As String, ByRef iMes As Short, ByRef iAño As Short) As Boolean
        Dim bResultado As Boolean = False
        Dim NúmeroArchivo As Object
        Dim sArchivo As String
        Dim strSerie, strCadena As String
        Dim numeroAprobacion As Integer
        Dim iAñoAprobacion As Short

        Try
            If ValidaHuecosFoliosElectronicosVenta(iMes, iAño) = False Then
                Exit Function
            End If

            'If ValidaHuecosFoliosElectronicosNotasCreditoCXC(iMes, iAño) = False Then
            '    Exit Function
            'End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'procedimiento para imprimnir
            NúmeroArchivo = FreeFile() ' Obtiene un número de archivo que no se ha utilizado.

            FileClose(1)
            FileClose(2)
            FileClose(3)

            sArchivo = Empresa_Sistema.RFC & Format(iMes, "0#") & iAño & ".txt"
            If Right(strPort, 1) <> "\" Then strPort = strPort & "\"
            strPort = strPort & "1" & sArchivo

            If isExisteArchivo(strPort) = True Then
                If MsgBox("El archivo " & sArchivo & " correspondiente al mes " & MesNumeroALetra(iMes) & " " & iAño & " ya existe, desea sobreescribirlo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "GeneraInformeMensual") = MsgBoxResult.No Then
                    MsgBox("No se generó el archivo.", MsgBoxStyle.Exclamation, "GeneraInformeMensual")
                    Exit Function
                End If
            End If

            FileOpen(NúmeroArchivo, strPort, OpenMode.Output)

            '''''''''''''''''''AGREGAMOS TODAS LAS FACTURAS DEL MES Y AÑO'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oVenta As New Class_Ventas_Global
            Dim tFacturas As DataTable
            tFacturas = oVenta.ObtenerFacturasMesAño(iMes, iAño)

            For Each row As DataRow In tFacturas.Rows
                strCadena = ""
                strSerie = row("serie")
                numeroAprobacion = row("NUMERO_APROBACION")
                iAñoAprobacion = row("ANIO_APROBACION")

                If txtLEN("" & row("SELLO_DIGITAL")) = False Then
                    MsgBox("Hay documentos sin sello digital, avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, nombreModulo)
                    FileClose(NúmeroArchivo)
                    Exit Function
                End If

                strCadena = strCadena & "|" & Replace(fElectronicaValidaCampo(row("rfc")), "-", "") & "|" & fElectronicaValidaCampo(strSerie) & "|" & fElectronicaValidaCampo(row("FOLIO_NUMERICO")) & "|" & fElectronicaValidaCampo(iAñoAprobacion & numeroAprobacion) & "|" & Format(row("fecha"), "dd/MM/yyyy hh:mm:ss") & "|" & Format(row("TOTAL"), "#########0.00") & "|" & Format(row("IMPUESTO"), "#########0.00") & "|" & "1" & "|" & "I"

                strCadena = strCadena & "||||"

                PrintLine(NúmeroArchivo, strCadena)
            Next
            '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            ''''''''''''''''''''AGREGAMOS TODAS LAS FACTURAS CANCELADAS EN EL MES Y AÑO'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            tFacturas = New DataTable
            tFacturas = oVenta.ObtenerFacturasCanceladasMesAño(iMes, iAño)

            For Each row As DataRow In tFacturas.Rows
                strCadena = ""
                strSerie = row("serie")
                numeroAprobacion = row("NUMERO_APROBACION")
                iAñoAprobacion = row("ANIO_APROBACION")

                If txtLEN("" & row("SELLO_DIGITAL")) = False Then
                    MsgBox("Hay documentos sin sello digital, avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, nombreModulo)
                    FileClose(NúmeroArchivo)
                    Exit Function
                End If

                strCadena = strCadena & "|" & Replace(fElectronicaValidaCampo(row("rfc")), "-", "") & "|" & fElectronicaValidaCampo(strSerie) & "|" & fElectronicaValidaCampo(row("FOLIO_NUMERICO")) & "|" & fElectronicaValidaCampo(iAñoAprobacion & numeroAprobacion) & "|" & Format(row("FECHA"), "dd/MM/yyyy hh:mm:ss") & "|" & Format(row("TOTAL"), "#########0.00") & "|" & Format(row("IMPUESTO"), "#########0.00") & "|" & "0" & "|" & "I"

                strCadena = strCadena & "||||"

                PrintLine(NúmeroArchivo, strCadena)
            Next
            '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '''''''''''''''''''AGREGAMOS TODAS LAS NOTAS DE CREDITO DE CXC DEL MES Y AÑO'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'cmd.CommandText = "SELECT CASE WHEN G.VENTA_PUBLICO_GENERAL='1' THEN '" & Empresa_Sistema.RFC_VENTA_PUBLICO_GENERAL & "' ELSE CTE.RFC END RFC,G.FOLIO_NUMERICO,G.FECHA,G.SUBTOTAL,G.IVA,G.TOTAL," & "FE.SERIE,FE.NUMERO_APROBACION,FE.ANIO_APROBACION,G.SELLO_DIGITAL " & "FROM CXC_DESCUENTOS_GLOBAL G " & "INNER JOIN CATCTES CTE ON(G.COD_CTE=CTE.COD_CTE) " & "INNER JOIN CATALOGO_FOLIOS_FACTURAS_ELECTRONICAS FE ON(G.IDCATALOGO_FOLIO_FELECTRONICA=FE.IDCATALOGO_FOLIO_FELECTRONICA) " & "WHERE G.ES_COMPROBANTE_ELECTRONICO='1' AND YEAR(G.FECHA)=" & iAño & " AND MONTH(G.FECHA)=" & iMes & " " & "ORDER BY G.PLAZA,G.FOLIO_NUMERICO"

            'If dReader.Read = True Then
            '    While dReader.Read
            '        strCadena = ""
            '        strSerie = dReader("serie").ToString
            '        numeroAprobacion = dReader("NUMERO_APROBACION").ToString
            '        iAñoAprobacion = dReader("ANIO_APROBACION").ToString

            '        If txtLEN("" & dReader("SELLO_DIGITAL").ToString) = False Then
            '            MsgBox("Hay documentos sin sello digital, avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, nombreModulo)
            '            FileClose(NúmeroArchivo)
            '            Exit Function
            '        End If

            '        strCadena = strCadena & "|" & Replace(fElectronicaValidaCampo(dReader("rfc").ToString), "-", "") & "|" & fElectronicaValidaCampo(strSerie) & "|" & fElectronicaValidaCampo(dReader("FOLIO_NUMERICO").ToString) & "|" & fElectronicaValidaCampo(iAñoAprobacion & numeroAprobacion) & "|" & Format(dReader("fecha").Value, "dd/mm/yyyy hh:mm:ss") & "|" & Format(dReader("total").Value, "#########0.00") & "|" & Format(dReader("iva").Value, "#########0.00") & "|" & "1" & "|" & "E"

            '        strCadena = strCadena & "||||"

            '        PrintLine(NúmeroArchivo, strCadena)
            '        RecordCount += 1
            '    End While
            'End If
            'dReader.Close()
            'dReader = Nothing
            'RecordCount = 0
            '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            ''''''''''''''''''''AGREGAMOS TODAS LAS NOTAS DE CREDITO CANCELADAS EN EL MES Y AÑO'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'cmd.CommandText = "SELECT CASE WHEN G.VENTA_PUBLICO_GENERAL='1' THEN '" & Empresa_Sistema.RFC_VENTA_PUBLICO_GENERAL & "' ELSE CTE.RFC END RFC,G.FOLIO_NUMERICO,G.FECHA_CANCELACION,G.SUBTOTAL,G.IVA,G.TOTAL," & "FE.SERIE,FE.NUMERO_APROBACION,FE.ANIO_APROBACION,G.SELLO_DIGITAL " & "FROM CXC_DESCUENTOS_GLOBAL G " & "INNER JOIN CATCTES CTE ON(G.COD_CTE=CTE.COD_CTE) " & "INNER JOIN CATALOGO_FOLIOS_FACTURAS_ELECTRONICAS FE ON(G.IDCATALOGO_FOLIO_FELECTRONICA=FE.IDCATALOGO_FOLIO_FELECTRONICA) " & "WHERE G.ES_COMPROBANTE_ELECTRONICO='1' AND G.STATUS='C' AND YEAR(G.FECHA_CANCELACION)=" & iAño & " AND MONTH(G.FECHA_CANCELACION)=" & iMes & " " & "ORDER BY G.PLAZA,G.FOLIO_NUMERICO"
            'If dReader.Read = True Then
            '    While dReader.Read
            '        strCadena = ""
            '        strSerie = dReader("serie").Value
            '        numeroAprobacion = dReader("NUMERO_APROBACION").Value
            '        iAñoAprobacion = dReader("ANIO_APROBACION").Value

            '        If txtLEN("" & dReader("SELLO_DIGITAL").Value) = False Then
            '            MsgBox("Hay documentos sin sello digital, avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, nombreModulo)
            '            FileClose(NúmeroArchivo)
            '            Exit Function
            '        End If

            '        strCadena = strCadena & "|" & Replace(fElectronicaValidaCampo(dReader("rfc").Value), "-", "") & "|" & fElectronicaValidaCampo(strSerie) & "|" & fElectronicaValidaCampo(dReader("FOLIO_NUMERICO").Value) & "|" & fElectronicaValidaCampo(iAñoAprobacion & numeroAprobacion) & "|" & Format(dReader("FECHA_CANCELACION").Value, "dd/mm/yyyy hh:mm:ss") & "|" & Format(dReader("total").Value, "#########0.00") & "|" & Format(dReader("iva").Value, "#########0.00") & "|" & "0" & "|" & "E"

            '        strCadena = strCadena & "||||"
            '        PrintLine(NúmeroArchivo, strCadena)
            '        RecordCount += 1
            '    End While
            'End If
            'dReader.Close()
            'dReader = Nothing
            'RecordCount = 0
            '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            FileClose(NúmeroArchivo) ' Cierra el archivo.
            bResultado = True

            MsgBox("El archivo fue generado con éxito en la My.Settings.Ruta: " & strPort, MsgBoxStyle.Information, "Generación de informe de CFD")

        Catch ex As Exception
            HandleError(_Nombre_Catalogo, "GeneraInformeMensual", ex)
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
                    MsgBox("Receptor.Domicilio.estado - Si la clave de país es {ZZZ} o la clave del país no existe en la columna c_Pais del catálogo c_Estado, se podrá registrar texto libremente. " & vbCrLf & _
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
            HandleError(_Nombre_Catalogo, "ValidaDatoFacturaElectronica", ex)
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
            HandleError(_Nombre_Catalogo, "GestionaFechaCertificadoCFD", ex)
        End Try

        Return sMensaje
    End Function

#Region "CODIGO ANTIGUO"
    'Codigo usado para facturar electronicamente antes de CFDi

    'Public Function GenerarSello(ByRef xmlDoc As MSXML2.DOMDocument60, ByVal dFechaDocumento As Date) As FacturaElectronica
    '       Dim pkey As New CHILKATCERTIFICATELib.privateKey
    '       Dim success As Integer
    '       Dim pkeyXml As String
    '       Dim rsa As New CHILKATRSALib.ChilkatRsa
    '       Try
    '           pkey.LoadPkcs8EncryptedFile(sFelectronicaArchivoKEYLocal, Empresa_Sistema.FELECTRONICA_CONTRASENIA_CLAVE_PRIVADA)

    '           pkeyXml = pkey.GetXml()

    '           success = rsa.UnlockComponent(CK_KEY)
    '           If (success <> 1) Then
    '               Debug.Print(rsa.LastErrorText & vbCrLf)
    '               Exit Function
    '           End If

    '           success = rsa.ImportPrivateKey(pkeyXml)
    '           If (success <> 1) Then
    '               Debug.Print(rsa.LastErrorText & vbCrLf)
    '               Exit Function
    '           End If

    '           rsa.Charset = "utf-8"
    '           rsa.EncodingMode = "base64"
    '           rsa.LittleEndian = 0

    '           Dim base64Sig As String

    '           GenerarSello.CadenaOriginal = GetCadenaOriginal(xmlDoc)

    '           If Year(dFechaDocumento) <= 2010 Then
    '               base64Sig = rsa.SignStringENC(GenerarSello.CadenaOriginal, "md5")
    '           Else
    '               base64Sig = rsa.SignStringENC(GenerarSello.CadenaOriginal, "sha1")
    '           End If

    '           GenerarSello.SelloDigital = base64Sig
    '           'Facturacion.txtSello.Text = GenerarSello

    '           Exit Function
    '       Catch ex As Exception
    '           HandleError(_Nombre_Catalogo, "GenerarSello", ex)
    '       End Try
    '   End Function

    'Function WriteUTF8(ByVal sArchivoXML As String) As Boolean
    '' Returns True if sText saved successfully as UTF-8 in sFile
    '
    'Const adTypeText As Long = 2
    'Const adSaveCreateOverWrite As Long = 2
    '
    'Dim Numarch As Variant, sLinea As String
    '
    'Numarch =IGUO FreeFile
    'Open sArchivoXML For Input As #Numarch
    'While Not EOF(Numarch)
    '    Input #Numarch, sLinea
    '
    'Wend
    'Close #Numarch
    '
    'With CreateObject("ADODB.Stream")
    '    .Type = adTypeText
    '    .Charset = "utf-8"
    '    .Open
    '    .WriteText "el mumu es ñoño, y fer también"
    '    .SaveToFile "C:\Abacosql\FLECTRONICA\Certificados digitales\HAPPY_PRODUCE\XMLs\coke.xml", adSaveCreateOverWrite
    '    WriteUTF8 = True
    'End With
    'Exit Function
    '
    'Oops:
    'MsgBox Err.Description
    'End Function

    'Function WriteUTF8(ByVal sArchivoXML As String) As Boolean
    '' Returns True if sText saved successfully as UTF-8 in sFile
    '
    'Const adTypeText As Long = 2
    'Const adSaveCreateOverWrite As Long = 2
    '
    'Dim Numarch As Variant, sLinea As String
    '
    'Numarch =IGUO FreeFile
    'Open sArchivoXML For Input As #Numarch
    'While Not EOF(Numarch)
    '    Input #Numarch, sLinea
    '
    'Wend
    'Close #Numarch
    '
    'With CreateObject("ADODB.Stream")
    '    .Type = adTypeText
    '    .Charset = "utf-8"
    '    .Open
    '    .WriteText "el mumu es ñoño, y fer también"
    '    .SaveToFile "C:\Abacosql\FLECTRONICA\Certificados digitales\HAPPY_PRODUCE\XMLs\coke.xml", adSaveCreateOverWrite
    '    WriteUTF8 = True
    'End With
    'Exit Function
    '
    'Oops:
    'MsgBox Err.Description
    'End Function

    'Private Function GetCadenaOriginal(ByRef xmlDoc As MSXML2.DOMDocument60) As String
    '    GetCadenaOriginal = ""
    '    Dim xslt As New MSXML2.XSLTemplate60
    '    Dim xslDoc As New MSXML2.FreeThreadedDOMDocument60
    '    Dim xslProc As MSXML2.IXSLProcessor
    '    Try
    '        xslDoc.async = False
    '        xslDoc.load(sFelectronicaArchivoCadenaOriginalLocal)

    '        Dim myErr As Object
    '        If (xslDoc.parseError.errorCode <> 0) Then
    '            myErr = xslDoc.parseError
    '            MsgBox("Error en la hoja de estilo: " & myErr.reason)
    '        Else
    '            xslDoc.setProperty("ResolveExternals", True) ' Esta línea es importante ya que sin ella el proceso no se ejecutará de manera correcta
    '            xslt.stylesheet = xslDoc

    '            If (xmlDoc.parseError.errorCode <> 0) Then
    '                myErr = xmlDoc.parseError
    '                MsgBox("Error en el documento XML: " & myErr.reason)
    '            Else
    '                xslProc = xslt.createProcessor()
    '                xslProc.input = xmlDoc
    '                xslProc.transform()
    '                GetCadenaOriginal = xslProc.output
    '            End If
    '        End If
    '        Exit Function
    '    Catch ex As Exception
    '        HandleError(_Nombre_Catalogo, "GetCadenaOriginal", ex)
    '    End Try
    'End Function

    'Public Function VerificarSello(ByRef xmlDoc As MSXML2.DOMDocument60) As Boolean
    '    Dim Cert As New CHILKATCERTIFICATELib.ChilkatCert
    '    Dim PubKey As New CHILKATCERTIFICATELib.publicKey
    '    Dim rsa As New CHILKATRSALib.ChilkatRsa

    '    Cert.LoadFromBase64(ExtraerCertificado(xmlDoc))

    '    PubKey = Cert.ExportPublicKey()
    '    rsa.UnlockComponent(CK_KEY)
    '    rsa.ImportPublicKey(PubKey.GetXml())

    '    rsa.Charset = "utf-8"
    '    rsa.EncodingMode = "base64"
    '    rsa.LittleEjdian = 0

    '    Dim resultado As Integer
    '    resultado = rsa.VerifyStringENC(GetCadenaOriginal(xmlDoc), "sha1", ExtraerSello(xmlDoc))
    '    VerificarSello = (resultado = 1)

    'End Function

    'Public Function ExtraerCertificado(ByRef xmlDoc As MSXML2.DOMDocument60) As String
    '    Dim Nodo As MSXML2.IXMLDOMNode

    '    Nodo = xmlDoc.selectSingleNode("//@certificado")

    '    If Nodo Is Nothing Then
    '        ExtraerCertificado = ""
    '    Else
    '        ExtraerCertificado = Nodo.Text
    '    End If

    '    Nodo = Nothing
    '    xmlDoc = Nothing
    'End Function


    'Public Function GeneraNotaCreditoCXCElectronica(ByVal sFolio As String, ByVal bMostrarMensaje As Boolean, ByVal sRutaXML As String) As Boolean

    '    Dim sVentaPublicoGeneral, sEsPorDevolucion As String ', sSisTieneIVANotaCredito As String
    '    Try
    '        sFolio = sReplace(sFolio)

    '        If fElectronicaValidaArchivosCertificadoLocal() = False Then
    '            Exit Function
    '        End If

    '        Dim strSerie, sPlaza As String
    '        Dim iddevolucion As Integer

    '        Dim Cfd As cComprobante
    '        Cfd = New cComprobante
    '        Cfd.xmlns = "http://www.sat.gob.mx/cfd/2"
    '        Cfd.xmlnsxsi = "http://www.w3.org/2001/XMLSchema-instance"
    '        Cfd.xsischemaLocation = "http://www.sat.gob.mx/cfd/2 http://www.sat.gob.mx/sitio_internet/cfd/2/cfdv2.xsd"

    '        Cfd.version = "2.0"

    '        Dim drImporte, dPrecio As Double
    '        Dim cmd As New SqlCommand("SELECT ELEC.SERIE,ELEC.NUMERO_APROBACION,ELEC.ANIO_APROBACION,G.*," & "ISNULL((SELECT DISTINCT(IMPUESTO_PORCENTAJE) FROM CXC_DESCUENTOS_DETALLE DET INNER JOIN CXCGLOB CXC ON(DET.FOLIO_CXC=CXC.FOLIO) INNER JOIN FACGLOB FG ON(CXC.FOL_REF=FG.FOLIO) WHERE DET.FOLIO_DESCUENTO=G.FOLIO_DESCUENTO AND FG.IVA>0),0.00) AS IMPUESTO_PORCENTAJE, " & "DEVG.IDDEV DEVG_IDDEV " & "FROM CXC_DESCUENTOS_GLOBAL G " & "INNER JOIN CATALOGO_FOLIOS_FACTURAS_ELECTRONICAS ELEC ON(G.IDCATALOGO_FOLIO_FELECTRONICA=ELEC.IDCATALOGO_FOLIO_FELECTRONICA) " & "LEFT JOIN FACDEVG DEVG ON(G.FOLIO_DESCUENTO=DEVG.FOLIO_NOTA) " & "WHERE G.FOLIO_DESCUENTO='" & sFolio & "'", _Conexion)
    '        Dim dReader As SqlDataReader
    '        Dim RecordCount As Integer = 0
    '        With cmd
    '            .CommandTimeout = 0
    '            .CommandType = CommandType.Text

    '            _Conexion.Open()
    '            dReader = .ExecuteReader()
    '        End With
    '        If dReader.Read = False Then
    '            MsgBox("Se encontró mas de una vez el rango de folios para el comprobante electrócico." & vbCrLf & "Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, sProcedure)
    '            dReader.Close()
    '            Exit Function
    '        End If

    '        Cfd.serie = fElectronicaValidaCampo(dReader("serie").Value)
    '        Cfd.noAprobacion = fElectronicaValidaCampo(dReader("NUMERO_APROBACION").Value)
    '        Cfd.anoAprobacion = fElectronicaValidaCampo(dReader("ANIO_APROBACION").Value)
    '        Cfd.noCertificado = "" 'Solo de muestra despues se obtendra el Numero de Certificado
    '        Cfd.certificado = "" 'Solo de muestra despues se obtendra el Certificado
    '        Cfd.sello = "" 'Solo de muestra despues se obtendra el Sello

    '        iddevolucion = valorNumerico("" & dReader("DEVG_IDDEV").Value) 'pudiera ser nulo, si es descuento directo
    '        Cfd.sFolioFacturaSistema = sFolio

    '        sVentaPublicoGeneral = dReader("VENTA_PUBLICO_GENERAL").Value
    '        sPlaza = dReader("Plaza").Value
    '        sEsPorDevolucion = dReader("ES_POR_DEVOLUCION").Value
    '        'sSisTieneIVANotaCredito = rst!SIS_TIENE_IVA_NOTA_CREDITO

    '        'Agregamos los datos totales y Generales
    '        Cfd.Folio = dReader("FOLIO_NUMERICO").Value
    '        Cfd.fecha = Format(dReader("fecha").Value, "yyyy-mm-dd") & "T" & Format(dReader("FECHA_SERVIDOR").Value, "hh:mm:ss")
    '        Cfd.tipoDeComprobante = "egreso"
    '        Cfd.formaDePago = "PAGO EN UNA SOLA EXHIBICION"

    '        Cfd.Descuento = Format(0, "#0.00") 'rst!Descuento
    '        Cfd.Impuestos.Traslados.USADO = True 'si uso el trasladado

    '        '''''''''''''''''''''''''''''''''SUBTOTAL,IVA,TOTAL''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        'If sEsPorDevolucion = "1" Then

    '        If sVentaPublicoGeneral = "1" Then
    '            'No se desglosa el iva(por ello subtotal=total y se manda un impuesto en cero)
    '            Cfd.subTotal = Format(dReader("total").Value, "#0.00")
    '            Cfd.total = Format(dReader("total").Value, "#0.00")
    '            Cfd.Impuestos.Traslados.Add("IVA", Format(0, "#0.00"), Format(0, "#0.00"))
    '        Else
    '            Cfd.subTotal = Format(dReader("subTotal").Value, "#0.00")
    '            Cfd.total = Format(dReader("total").Value, "#0.00")

    '            If dReader("iva").Value = 0 Then
    '                Cfd.Impuestos.Traslados.Add("IVA", Format(0, "#0.00"), Format(0, "#0.00"))
    '            Else
    '                '0
    '                Dim Disponible As New Class_find("SELECT 1 FROM CXC_DESCUENTOS_DETALLE DET INNER JOIN CXCGLOB CXC ON(DET.FOLIO_CXC=CXC.FOLIO) INNER JOIN FACGLOB FG ON(CXC.FOL_REF=FG.FOLIO) " & "INNER JOIN FACREN R ON(FG.IDFACTURA=R.IDFACTURA)" & "WHERE DET.FOLIO_DESCUENTO='" & sFolio & "' AND R.IVA=0")
    '                If txtLEN(Disponible.Result1) = True Then
    '                    Cfd.Impuestos.Traslados.Add("IVA", Format(0, "#0.00"), Format(0, "#0.00"))
    '                End If
    '                '16
    '                Cfd.Impuestos.Traslados.Add("IVA", Format(IIf(dReader("IMPUESTO_PORCENTAJE").Value > 0, dReader("IMPUESTO_PORCENTAJE").Value, 0), "#0.00"), Format(dReader("iva").Value, "#0.00"))
    '            End If
    '        End If

    '        'Datos del Emisor
    '        Cfd.Emisor.nombre = fElectronicaValidaCampo(Empresa_Sistema.Nombre_empresa)
    '        Cfd.Emisor.rfc = fElectronicaValidaCampo(Empresa_Sistema.Rfc)

    '        Cfd.Emisor.DomicilioFiscal.calle = fElectronicaValidaCampo(Empresa_Sistema.CALLE)
    '        Cfd.Emisor.DomicilioFiscal.noExterior = fElectronicaValidaCampo(Empresa_Sistema.NUMERO_EXTERIOR)
    '        Cfd.Emisor.DomicilioFiscal.noInterior = fElectronicaValidaCampo(Empresa_Sistema.NUMERO_INTERIOR)
    '        Cfd.Emisor.DomicilioFiscal.colonia = fElectronicaValidaCampo(Empresa_Sistema.COLONIA)
    '        Cfd.Emisor.DomicilioFiscal.localidad = fElectronicaValidaCampo(Empresa_Sistema.LOCALIDAD)
    '        Cfd.Emisor.DomicilioFiscal.municipio = fElectronicaValidaCampo(Empresa_Sistema.Ciudad)
    '        Cfd.Emisor.DomicilioFiscal.estado = fElectronicaValidaCampo(Empresa_Sistema.Estado)
    '        Cfd.Emisor.DomicilioFiscal.pais = fElectronicaValidaCampo(Empresa_Sistema.PAIS)
    '        Cfd.Emisor.DomicilioFiscal.codigoPostal = fElectronicaValidaCampo(Empresa_Sistema.CODIGO_POSTAL)

    '        'If sPlaza <> Usuario.Codigo_Plaza Then
    '        '    If sPlaza <> Plaza.CODIGO_PLAZA Then 'Si ya estaba cargada la plaza de la factura, no se cargará de nuevo para evitar consultas.
    '        '        'UPGRADE_WARNING: Couldn't resolve default property of object tPlazaFacturaElectronica. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '        '        tPlazaFacturaElectronica = CargaPlazaParametro(sPlaza)
    '        '    End If
    '        'Else
    '        '    'UPGRADE_WARNING: Couldn't resolve default property of object tPlazaFacturaElectronica. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '        '    tPlazaFacturaElectronica = Mod_Uti.Plaza_Renamed 'Plaza ya cargada en el inicio de sesión del usuario.
    '        'End If

    '        Cfd.Emisor.ExpedidoEn.USADO = True 'si es usado diferente lugar de expedición se pondra la información, en este caso dejaremos la misma
    '        Cfd.Emisor.ExpedidoEn.calle = fElectronicaValidaCampo(Plaza.CALLE)
    '        Cfd.Emisor.ExpedidoEn.noExterior = fElectronicaValidaCampo(Plaza.NUMERO_EXTERIOR)
    '        Cfd.Emisor.ExpedidoEn.noInterior = fElectronicaValidaCampo(Plaza.NUMERO_INTERIOR)
    '        Cfd.Emisor.ExpedidoEn.colonia = fElectronicaValidaCampo(Plaza.COLONIA)
    '        Cfd.Emisor.ExpedidoEn.localidad = fElectronicaValidaCampo(Plaza.LOCALIDAD)
    '        Cfd.Emisor.ExpedidoEn.municipio = fElectronicaValidaCampo(Plaza.CIUDAD)
    '        Cfd.Emisor.ExpedidoEn.estado = fElectronicaValidaCampo(Plaza.ESTADO)
    '        Cfd.Emisor.ExpedidoEn.pais = fElectronicaValidaCampo(Plaza.PAIS)
    '        Cfd.Emisor.ExpedidoEn.codigoPostal = fElectronicaValidaCampo(Plaza.CODIGO_POSTAL)

    '        dReader.Close()
    '        dReader = Nothing
    '        RecordCount = 0

    '        'Sacamos los Datos del Cliente Receptor
    '        cmd.CommandText = "SELECT * FROM CATCTES WHERE COD_CTE='" & dReader("COD_CTE").Value & "'"
    '        With cmd
    '            .CommandTimeout = 0
    '            .CommandType = CommandType.Text
    '            _Conexion.Open()
    '            dReader = .ExecuteReader()
    '        End With
    '        If dReader.Read = True Then
    '            If sVentaPublicoGeneral = "1" Then
    '                Cfd.Receptor.nombre = "PUBLICO GENERAL"
    '                Cfd.Receptor.rfc = Empresa_Sistema.RFC_VENTA_PUBLICO_GENERAL
    '                Cfd.Receptor.Domicilio.calle = "DOMICILIO CONOCIDO"
    '                Cfd.Receptor.Domicilio.noExterior = "S/N"
    '                Cfd.Receptor.Domicilio.noInterior = ""
    '                Cfd.Receptor.Domicilio.colonia = "CENTRO"
    '                Cfd.Receptor.Domicilio.localidad = fElectronicaValidaCampo(Plaza.LOCALIDAD)
    '                Cfd.Receptor.Domicilio.municipio = fElectronicaValidaCampo(Plaza.CIUDAD)
    '                Cfd.Receptor.Domicilio.estado = fElectronicaValidaCampo(Plaza.ESTADO)
    '                Cfd.Receptor.Domicilio.pais = fElectronicaValidaCampo(Empresa_Sistema.PAIS)
    '                Cfd.Receptor.Domicilio.codigoPostal = "00000"
    '            Else
    '                Cfd.Receptor.nombre = fElectronicaValidaCampo(dReader("NOM_CTE").ToString)
    '                Cfd.Receptor.rfc = fElectronicaValidaCampo(Replace(dReader("rfc").ToString, "-", ""))
    '                Cfd.Receptor.Domicilio.calle = fElectronicaValidaCampo(dReader("calle").ToString)
    '                Cfd.Receptor.Domicilio.noExterior = fElectronicaValidaCampo(Nothing & dReader("NUMERO_EXTERIOR").ToString)
    '                Cfd.Receptor.Domicilio.noInterior = fElectronicaValidaCampo(Nothing & dReader("NUMERO_INTERIOR").ToString)
    '                Cfd.Receptor.Domicilio.colonia = fElectronicaValidaCampo(Nothing & dReader("colonia").ToString)
    '                Cfd.Receptor.Domicilio.localidad = fElectronicaValidaCampo(Nothing & dReader("CIUDAD").ToString)
    '                Cfd.Receptor.Domicilio.municipio = fElectronicaValidaCampo(Nothing & dReader("localidad").ToString) 'fElectronicaValidaCampo(Empty & rst1!CIUDAD)
    '                Cfd.Receptor.Domicilio.estado = fElectronicaValidaCampo(Nothing & dReader("estado").ToString)
    '                Cfd.Receptor.Domicilio.pais = fElectronicaValidaCampo(Nothing & dReader("pais").ToString)
    '                Cfd.Receptor.Domicilio.codigoPostal = fElectronicaValidaCampo(Nothing & dReader("CODIGO_POSTAL").ToString)
    '            End If

    '            If ValidaDatoFacturaElectronica(Cfd) = False Then
    '                cmd = Nothing
    '                Exit Function
    '            End If
    '        Else
    '            MsgBox("Cliente no encontrado.", MsgBoxStyle.Exclamation, nombreModulo)
    '            Exit Function
    '        End If

    '        dReader.Close()
    '        dReader = Nothing
    '        RecordCount = 0

    '        '''''''''''''''''''''''''''''''''CONCEPTOS''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        If sEsPorDevolucion = "1" Then
    '            'Aqui crearemos un ciclo para integrar los conceptos que tenga la factura
    '            cmd.CommandText = "SELECT R.COD_ART,A.UNID_VTA,A.DESCRI,R.CANT,R.PRECIO,R.IVA " & "FROM FACDEVR R INNER JOIN CATARTI A ON(R.COD_ART=A.COD_ART) " & "WHERE R.IDDEV=" & iddevolucion & " AND R.COD_ART<>'-' ORDER BY IDTRANS"
    '            With cmd
    '                .CommandTimeout = 0
    '                .CommandType = CommandType.Text
    '                _Conexion.Open()
    '                dReader = .ExecuteReader()
    '            End With

    '            While dReader.Read
    '                If sVentaPublicoGeneral = "1" Then
    '                    dPrecio = dReader("PRECIO").ToString + dReader("iva").ToString 'ojo si es publico gral  no desglosar iva
    '                Else
    '                    dPrecio = dReader("PRECIO").ToString
    '                End If

    '                drImporte = dReader("CANT").ToString * dPrecio
    '                Call Redondear(drImporte, Empresa_Sistema.DECIMALES_CONTABILIDAD)
    '                Cfd.Conceptos.Add(dReader("CANT").ToString, fElectronicaValidaCampo(dReader("DESCRI").ToString), CStr(drImporte), dReader("UNID_VTA").ToString, CStr(dPrecio))
    '                RecordCount += 1
    '            End While
    '            dReader.Close()
    '            dReader = Nothing
    '            RecordCount = 0
    '        Else 'Entonces es una nota de crédito directa.
    '            If sVentaPublicoGeneral = "1" Then
    '                Cfd.Conceptos.Add("1.00", fElectronicaValidaCampo(dReader("Concepto").ToString), dReader("total").ToString, "", dReader("total").ToString)
    '            Else
    '                Cfd.Conceptos.Add("1.00", fElectronicaValidaCampo(dReader("Concepto").ToString), dReader("subTotal").ToString, "", dReader("subTotal").ToString)
    '            End If
    '        End If
    '        '------------------------------------------------------------------------------------------------------------------------------------------------

    '        If Cfd.Sellar(sRutaXML, "NOTA_CREDITO_CXC", IIf(sEsPorDevolucion = "1", True, False)) = True Then
    '            GeneraNotaCreditoCXCElectronica = True
    '            If bMostrarMensaje = True Then
    '                MsgBox("Documento sellado satisfactoriamente.", MsgBoxStyle.Information, "Sellar") 'se quito, solo marca error en caso de no sellar desde facturacion , en el grabar
    '            End If
    '        End If

    '        Cfd = New cComprobante 'vaciar el comprobante

    '        dReader.Close()
    '        dReader = Nothing
    '        RecordCount = 0

    '        Exit Function
    '    Catch ex As Exception

    '    End Try
    'End Function

    'Public Function GuardarComprobanteXML(ByVal Folio As String, ByVal Esquema As String, ByVal XmlDoc As Xml.XmlDocument, ByVal sTipoComprobanteElectronico As String) As Boolean
    '    'ConexionSQL.AbrirConexion()
    '    'With ConexionSQL.Comando
    '    Dim cmd As New SqlCommand
    '    Dim sqlParametro As SqlParameter

    '    With cmd
    '        .Connection = _Conexion
    '        .CommandTimeout = 0
    '        .CommandType = CommandType.StoredProcedure

    '        If XmlDoc.FirstChild.NodeType = Xml.XmlNodeType.XmlDeclaration Then
    '            XmlDoc.RemoveChild(XmlDoc.FirstChild)
    '        End If

    '        .Parameters.Clear()
    '        Select Case sTipoComprobanteElectronico
    '            Case "FACTURA_VENTA"
    '                .CommandText = "MP_VENTAS_CFD_GRABA_CADENA_XML"

    '                sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Folio
    '            Case "FACTURA_VENTA_RETENCION"
    '                .CommandText = "MP_VENTAS_CFD_GRABA_CADENA_XML"

    '                sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Folio
    '            Case "NOTA_CREDITO_CXC"
    '                .CommandText = "MP_DESCUENTOS_CFD_GRABA_CADENA_XML"

    '                sqlParametro = .Parameters.Add("@FOLIO_DESCUENTO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Folio
    '            Case Else
    '                MsgBox("No se indicó el tipo de comprobante electrónico generado para grabar los datos digitales del documento.", MsgBoxStyle.Exclamation)
    '                Exit Function
    '        End Select

    '        sqlParametro = .Parameters.Add("@VERSION_ESQUEMA_XML", SqlDbType.NVarChar, 6) : sqlParametro.Value = Empresa_Sistema.VERSION_ESQUEMA_CFD
    '        sqlParametro = .Parameters.Add("@CADENA_XML", SqlDbType.Xml) : sqlParametro.Value = XmlDoc.OuterXml

    '        _Conexion.Open()
    '        .ExecuteNonQuery()

    '    End With
    '    cmd = Nothing
    '    GuardarComprobanteXML = True
    '    _Conexion.Close()
    '    Exit Function
    '    'ConexionSQL.Comando.ExecuteNonQuery()
    '    'Me.ConexionSQL.Cerrar()

    'End Function

    'Public Function ExtraerSello(ByRef xmlDoc As MSXML2.DOMDocument60) As String

    '    Dim Nodo As MSXML2.IXMLDOMNode
    '    Nodo = xmlDoc.selectSingleNode("//@sehlo")

    '    If Nodo Is Nothing Then
    '        ExtraerSello = ""
    '    Else
    '        ExtraerSello = Nodo.text
    '    End If

    '    Nodo = Nothing
    '    xmlDoc = Nothing
    'End Function

    'Public Function RecuperaFacturaElectronica(ByVal sFolio As String, ByVal bMostrarMensaje As Boolean, ByVal sRutaXML As String, ByVal sTipoComprobanteElectronico As String) As Boolean
    '    ' Dim ArchivoXmlAcuseCancelacion As String = sFelectronicaCarpetaXmlsAcusesCancelacion & "\AcuseCancelacion_" & sFolioFacturaSistema & ".xml" ' "la ruta de los xml de acuses de cancelacion"
    '    Dim sUUID As String = "" ' "el folio del sat del documento"
    '    Dim sXml As String = ""
    '    Dim sSerie As String = Left(sFolio, 3).ToString
    '    Dim iFolioNumerico As Integer = sFolio.Substring(4, Len(sFolio) - 4)
    '    Dim sAcuseCancelacion As String = ""

    '    Using cfd As New clsCFDI(Empresa_Sistema.BaseDatos, Empresa_Sistema.Servidor, sFelectronicaArchivoPFX, _
    '                        Decrypt(Empresa_Sistema.FELECTRONICA_CONTRASENIA_PFX, "ex8"), _
    '                         Empresa_Sistema.FELECTRONICA_USER_WS, Empresa_Sistema.FELECTRONICA_PASS_WS)

    '        sXml = cfd.RecuperarTimbrePorSerieFolio(sSerie, iFolioNumerico, Empresa_Sistema.RFC, sFelectronicaCbbImagen)
    '        If cfd.Recuperado = False Then 'No se recupero
    '            If sXml = "ErrorDLL" Then
    '                Exit Function
    '            End If
    '            DescartarTimbrado(sFolio, sTipoComprobanteElectronico) 'ActualizaEstatusTimbradoDescartado(Folio, sTipoComprobanteElectronico)
    '            Exit Function
    '        Else
    '            sXml = Replace(sXml, "<?xml version=""1.0"" encoding=""UTF-8""?>", "")
    '            'Se recupero
    '            If GrabaCadenaOriginalYSelloComprobanteElectronico(sFolio, sXml, cfd, sTipoComprobanteElectronico) Then
    '                'MsgBox("GUARDADO")
    '            End If
    '        End If
    '    End Using
    '    'cmd = Nothing
    '    RecuperaFacturaElectronica = True
    '    '_Conexion.Close()
    '    Exit Function
    'End Function

    'Public Function RecuperaNotaElectronica(ByVal sFolio As String, ByVal bMostrarMensaje As Boolean, ByVal sRutaXML As String) As Boolean
    '    Dim docXml As Xml.XmlDocument = New Xml.XmlDocument

    '    Dim cmd As New SqlCommand
    '    Dim sqlParametro As SqlParameter

    '    _Conexion.Close()

    '    oDescuento = New Class_CXC_Descuento(sFolio)

    '    Dim ArchivoPFX As String = sFelectronicaArchivoPFX ' "la ruta del pfx"
    '    Dim ArchivoXmlAcuseCancelacion As String = sFelectronicaCarpetaXmlsAcusesCancelacion ' "la ruta de los xml de acuses de cancelacion"
    '    Dim sUUID As String = "" ' "el folio del sat del documento"
    '    Dim aux As String = "", sXML As String = ""
    '    aux = Left(oDescuento.FOLIO_DESCUENTO, 3).ToString

    '    Using cfd As New clsCFDI(Empresa_Sistema.BaseDatos, Empresa_Sistema.Servidor, ArchivoPFX, _
    '                        Decrypt(Empresa_Sistema.FELECTRONICA_CONTRASENIA_PFX, "ex8"), _
    '                         Empresa_Sistema.FELECTRONICA_USER_WS, Empresa_Sistema.FELECTRONICA_PASS_WS)

    '        sXML = cfd.RecuperarTimbrePorSerieFolio(aux, CInt(oDescuento.FOLIO_NUMERICO), Empresa_Sistema.RFC, sFelectronicaCbbImagen)
    '        sXML = Replace(sXML, "<?xml version=""1.0"" encoding=""UTF-8""?>", "")
    '        If GrabaCadenaOriginalYSelloComprobanteElectronico(sFolio, sXML, cfd, "NOTA_CREDITO_CXC") = True Then

    '        End If
    '    End Using

    '    cmd = Nothing
    '    RecuperaNotaElectronica = True
    '    _Conexion.Close()
    '    Exit Function
    'End Function


    'Public Function SellarRangoFacturasElectronicas(ByVal dFecha1 As Date, ByVal dFecha2 As Date) As Boolean
    '    Dim sFolio, sRutaXML As String
    '    Dim sqlParametro As SqlParameter
    '    Try
    '        Dim cmd As New SqlCommand("SELECT FOLIO " & "FROM FACGLOB WHERE COD_DOC='F' AND ES_FACTURA_ELECTRONICA='1' AND " & "FECHA BETWEEN '" & Format(dFecha1, "yyyy-dd-mm") & " 00:00:00' AND '" & Format(dFecha2, "yyyy-dd-mm") & " 23:59:00' " & "ORDER BY PLAZA,IDFACTURA", _Conexion)
    '        Dim dReader As SqlDataReader, i As Integer = 0

    '        With cmd
    '            .CommandTimeout = 0
    '            .CommandType = CommandType.Text
    '            _Conexion.Open()
    '            dReader = .ExecuteReader()

    '            If dReader.Read Then
    '                While i <> dReader.HasRows
    '                    sFolio = dReader("Folio").ToString
    '                    sRutaXML = sFelectronicaCarpetaCertificadosDBXMLs & "\" & dReader("Folio").ToString & ".xml"
    '                    If GeneraFacturaElectronica(sFolio, False, sRutaXML) = False Then
    '                        MsgBox("Error al tratar de sellar la factura " & sFolio & ". El proceso fue abortado.", MsgBoxStyle.Critical, "SellarRangoFacturasElectronicas")
    '                        Exit Function
    '                    Else 'Si la sello
    '                        cmd = New SqlCommand
    '                        With cmd
    '                            .Connection = _Conexion
    '                            .CommandTimeout = 0
    '                            .CommandType = CommandType.StoredProcedure
    '                            .CommandText = "MP_SIS_VENTAS_FACTURACION_ELECTRONICA_INDICA_SELLO_REPROCESADO"

    '                            sqlParametro = .Parameters.Add("@FOLIO", SqlDbType.NVarChar, 15) : sqlParametro.Value = sFolio

    '                            _Conexion.Open()
    '                            .ExecuteNonQuery()
    '                        End With
    '                    End If
    '                    i = i + 1
    '                    dReader.NextResult()
    '                End While
    '                dReader.Close()
    '            End If
    '        End With
    '        'UPGRADE_NOTE: Object rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
    '        cmd = Nothing

    '        SellarRangoFacturasElectronicas = True

    '        MsgBox("Facturas selladas satisfactoriamente.", MsgBoxStyle.Information, "SellarRangoFacturasElectronicas")

    '        Exit Function
    '    Catch ex As Exception

    '    End Try
    '            rs = Nothing
    'End Function

#End Region

End Module