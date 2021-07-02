Option Strict On

Imports System.Data.SqlClient
Imports System.Xml
Imports System.IO
Imports Ionic.Zip
Imports CrystalDecisions.CrystalReports.Engine
Imports cfdi

Public Class Class_Contabilidad_Electronica

#Region "Campos"

#Region "Campos de la tabla"
    Private _IDXML As String
    Private _FECHA_ENVIO As Date
    Private _FECHA_SERVIDOR As Date
    Private _CODIGO_USUARIO As String
    Private _CODIGO_TIPO_ARCHIVO As String
    Private _CADENA_XML As String
    Private _EXISTE As Boolean 'LECTURA
#End Region

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
#End Region

#End Region

#Region "Propiedades"
#Region "Propiedad Nombre de Clase"
    Private ReadOnly Property NombreClase() As String
        Get
            Return "Class_Contabilidad_Electronica"
        End Get
    End Property
#End Region
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function Consultar(ByVal iCodigoTipoArchivo As Integer, ByVal dFechaEnvio As Date) As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "Consultar"
        Dim cmd As New SqlCommand("SELECT * FROM CONTABILIDAD_ELECTRONICA_ARCHIVOS_XML WHERE CODIGO_TIPO_ARCHIVO='" & iCodigoTipoArchivo.ToString & "' AND FECHA_ENVIO='" & Format(dFechaEnvio, "yyyy-dd-MM") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._IDXML = "" & dReader("IDXML").ToString
                    Me._FECHA_ENVIO = CDate(dReader("FECHA_ENVIO").ToString)
                    Me._FECHA_SERVIDOR = CDate(dReader("FECHA_SERVIDOR").ToString)
                    Me._CODIGO_USUARIO = "" & dReader("CODIGO_USUARIO").ToString
                    Me._CODIGO_TIPO_ARCHIVO = "" & dReader("CODIGO_TIPO_ARCHIVO").ToString
                    Me._CADENA_XML = "" & dReader("CADENA_XML").ToString
                    Me._EXISTE = True

                    bResultado = True
                Else
                    Me._EXISTE = False
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

    Public Function GeneraXMLCatalogoCuentas(ByVal dFecha As Date, Optional ByVal iPruebas As Integer = 0) As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "GeneraXMLCatalogoCuentas"
        Dim bValidaciones As Boolean = False, sValidaciones As String, fElectronica As FacturaElectronica
        Dim strStreamW As Stream = Nothing, strStreamWriter As StreamWriter = Nothing, sCarpeta As String
        Dim iCodigoTipoArchivo As Integer = 1
        Dim oXML As New XmlDocument, sRutaXML As String ', sNamespace As String = "catalogocuentas"

        Try
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Validar si el archivo ya fue generado
            Me.Consultar(iCodigoTipoArchivo, dFecha)
            If Me._EXISTE = True Then
                If MsgBox("Este archivo ya se generó, seguro desea genearlo otra vez?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, sProcedure) = MsgBoxResult.No Then
                    Return False
                End If
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oTipo As New Class_Contabilidad_Electronica_CatalogoTiposArchivos(iCodigoTipoArchivo.ToString)
            If oTipo.EXISTE = False Then
                Return False
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            sCarpeta = sContabilidadElectronicaCarpeta & "\" & Year(dFecha) & "." & Format(dFecha, "MM").ToUpper
            sRutaXML = sCarpeta & "\" & Empresa_Sistema.RFC & Year(dFecha) & Format(dFecha, "MM") & oTipo.TERMINACION_NOMBRE_ARCHIVO_XML & ".xml" '"CT.xml"

            If Len(Dir(sCarpeta, FileAttribute.Directory)) = 0 Then
                MkDir(sCarpeta)
            End If
            ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim Nodo As Xml.XmlDeclaration
            'Nodo = oXML.CreateXmlDeclaration("1.0", "utf-8", Nothing)

            'Dim root As Xml.XmlElement = oXML.DocumentElement
            'oXML.InsertBefore(Nodo, root)

            ''Dim oNode As XmlNode
            ''oNode = oXML.CreateNode(XmlNodeType.Element, "Catalogo", sNamespace)

            'Dim NodoComprobante As Xml.XmlElement = oXML.CreateElement(sNamespace & ":" & "Catalogo", sNamespace)
            'NodoComprobante.SetAttribute("xmlns:" & sNamespace, "http://www.sat.gob.mx/catalogo")
            'NodoComprobante.SetAttribute("Version", "1")
            'NodoComprobante.SetAttribute("RFC", Empresa_Sistema.RFC)
            'NodoComprobante.SetAttribute("TotalCtas", "666")
            'NodoComprobante.SetAttribute("Mes", Format(dFecha, "MM"))
            'NodoComprobante.SetAttribute("Ano", Format(dFecha, "YYYY"))

            'Dim NodoCatalogo As Xml.XmlElement = oXML.CreateElement(sNamespace & ":" & "Ctas", sNamespace)
            'NodoCatalogo.SetAttribute("haber", "1")
            'Dim s As String = "<catalogocuentas:Ctas CodAgrup=""1"" NumCta=""1010"" Desc=""FONDO FIJO DE CAJA"" Nivel=""1"" Natur=""D"" />"

            'NodoComprobante.AppendChild(NodoCatalogo)

            'oXML.AppendChild(NodoComprobante)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Dim sXML As String = ""

            Dim dt As New DataTable
            Using da As New SqlDataAdapter("MP_CONTABILIDAD_ELECTRONICA_CATALOGO_CUENTAS", Me._Conexion)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                Dim parameter As SqlParameter
                parameter = New SqlParameter("@FECHA_ENVIO", SqlDbType.NVarChar, 20) : parameter.Value = Format(dFecha, "yyyy-dd-MM") : da.SelectCommand.Parameters.Add(parameter)
                parameter = New SqlParameter("@CODIGO_TIPO_ARCHIVO", SqlDbType.SmallInt) : parameter.Value = iCodigoTipoArchivo : da.SelectCommand.Parameters.Add(parameter)
                parameter = New SqlParameter("@CODIGO_USUARIO", SqlDbType.SmallInt) : parameter.Value = Usuario.Codigo_Usuario : da.SelectCommand.Parameters.Add(parameter)
                parameter = New SqlParameter("@PRUEBAS", SqlDbType.SmallInt) : parameter.Value = iPruebas : da.SelectCommand.Parameters.Add(parameter)
                parameter = New SqlParameter("@VALIDACIONES", SqlDbType.NVarChar, 2000) : parameter.Value = "0" : parameter.Direction = ParameterDirection.Output : da.SelectCommand.Parameters.Add(parameter)

                da.Fill(dt)
                sValidaciones = da.SelectCommand.Parameters("@VALIDACIONES").Value.ToString
                bValidaciones = CBool(sValidaciones.Substring(0, 1))
            End Using
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If bValidaciones = False Then
                Dim sValidacionesSplit As String() = sValidaciones.Substring(2).Split(CChar(";"))
                sValidaciones = ""
                For Each x In sValidacionesSplit
                    sValidaciones += x & vbCrLf
                Next

                MsgBox("Hay validaciones que no se cumplieron y son : " & vbCrLf &
                         sValidaciones, vbExclamation, sProcedure)

                Dim Rpt As New ReportDocument
                Dim oReporte As New Class_Reporte("RPT_CONTABILIDAD_ELECTRONICA_CATALOGO_CUENTAS", Rpt, True)
                If Not oReporte.RptCargado Then
                    Return False
                End If
                Rpt.SetParameterValue("@FECHA_ENVIO", Format(dFecha, "yyyy-dd-MM"))
                Rpt.SetParameterValue("@CODIGO_TIPO_ARCHIVO", iCodigoTipoArchivo)
                Rpt.SetParameterValue("@CODIGO_USUARIO", Usuario.Codigo_Usuario)
                Rpt.SetParameterValue("@PRUEBAS", "0")
                Rpt.SetParameterValue("@VALIDACIONES", "0")

                Dim frm As New Reporte(Rpt)
                frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                frm.ShowDialog()
                frm.Dispose()
                Return False
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            strStreamW = File.Create(sRutaXML)
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.UTF8) ' tipo de codificacion para escritura

            'Linea por línea construye el xml en un stream, aun no existe el archivo en físico
            For Each dRow As DataRow In dt.Rows
                strStreamWriter.WriteLine(dRow("LINEA").ToString)
            Next

            strStreamWriter.Flush()
            strStreamW.Position = 0
            Dim SR As New StreamReader(strStreamW)
            Dim LineRead As String = SR.ReadToEnd 'Aquí del stream lo carga todo en una variable con la que se cargará el xml con LoadXml
            'SR.Dispose()'No es necesario haerle dispose porque el dispose del strStreamWriter lo libera

            strStreamWriter.Close()
            strStreamWriter.Dispose()

            oXML.LoadXml(LineRead)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Fecha_Documento = CDate(oXML.GetElementsByTagName("catalogocuentas:Catalogo").Item(0).Attributes.GetNamedItem("version").Value())
            'Fecha_Documento = CDate(ConvierteFechaTipoXML(Factura.attributes.getNamedItem("fecha").text))

            Dim Cert As Certificado = GestionaCertificado(Date.Now) 'intencionalmente se le pasa cualquier fecha con el fin de validar si está vigente el certificado, este xml no tiene fecha, tiene mes y año y no es necesario crear una fecha.
            If Cert.CertificadoValido = False Then
                Return False
            End If

            oXML.Item("catalogocuentas:Catalogo").Attributes("noCertificado").Value = Cert.noCertificado
            oXML.Item("catalogocuentas:Catalogo").Attributes("Certificado").Value = Cert.Certificado
            oXML.Save(sRutaXML)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim xmlDoc As New MSXML2.DOMDocument60
            xmlDoc.loadXML(oXML.InnerXml)

            'Esto se ocupaba cuando era versión 1.1
            'Dim sTemp As String
            'sTemp = xmlDoc.xml
            'sTemp = Replace(xmlDoc.xml, """www.sat.gob.mx/", """http://www.sat.gob.mx/") 'Se tienen que poner los http porque si no marca error el sello, pero el xml no debe guardarse con los https
            'xmlDoc.loadXML(sTemp)

            'fElectronica = GenerarSelloContabilidadElectronicaConChilkat(xmlDoc, TipoArchivoContabilidadElectronica.CATALOGO_CUENTAS)
            fElectronica = GenerarSelloContabilidadElectronicaConPFX(sRutaXML, TipoArchivoContabilidadElectronica.CATALOGO_CUENTAS)

            If txtLEN(fElectronica.SelloDigital) = False Then
                MsgBox("No se generó el sello digital.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            oXML.Item("catalogocuentas:Catalogo").Attributes("Sello").Value = fElectronica.SelloDigital
            oXML.Save(sRutaXML)

            ''Esta forma también sella bien.
            'Dim fElectronica2 As FacturaElectronica
            'fElectronica2 = GenerarSelloConPFX(xmlDoc)
            'oXML.Item("catalogocuentas:Catalogo").Attributes("Sello").Value = fElectronica2.SelloDigital
            'oXML.Save(sRutaXML)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Pruebas diferentes para cadena original
            'Dim CadenaOriginal1 As String = GetCadenaOriginalContabilidadElectronica1(xmlDoc)

            'Dim xDoc As XDocument = XDocument.Load(sRutaXML)
            'Dim CadenaOriginal2 As String = GetCadenaOriginalContabilidadElectronica2(xDoc)

            'Dim xmlDoc2 As New XmlDocument
            'xmlDoc2.Load(sRutaXML)
            'Dim CadenaOriginal3 As String = GetCadenaOriginalContabilidadElectronica3(xmlDoc2)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If ConvierteUTF8(sRutaXML) = False Then
                MsgBox("Error al intentar convertir el archivo a utf8.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Comprime

            Dim sRutaXMLZip As String = sRutaXML.Replace(".xml", ".zip")

            Using zip As ZipFile = New ZipFile()
                zip.AddFile(sRutaXML, "")
                zip.Save(sRutaXMLZip)
            End Using
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Borra archivo xml(se necesita sólo en .zip)

            File.Delete(sRutaXML)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If oXML.FirstChild.NodeType = XmlNodeType.XmlDeclaration Then
                oXML.RemoveChild(oXML.FirstChild) 'Se tiene que grabar sin el encabezado de la codificación
            End If

            If iPruebas = 0 Then 'Sólo se va grabar cuando no sean pruebas.
                bResultado = Me.GrabaXML(dFecha, iCodigoTipoArchivo, oXML.InnerXml)
            Else
                bResultado = True
            End If

            Dim proceso As New ProcessStartInfo()
            proceso.FileName = sCarpeta
            Process.Start(proceso)

        Catch ex As Exception
            HandleError(Me.NombreClase, sProcedure, ex)
        Finally
            If IsNothing(strStreamWriter) = False Then
                strStreamWriter.Dispose()
            End If
            If IsNothing(strStreamW) = False Then
                strStreamW.Dispose()
            End If
        End Try

        Return bResultado
    End Function

    Public Function GeneraXMLBalanzaComprobacion(ByVal dFecha As Date, ByVal iCodigoTipoArchivo As Integer, ByVal iCodigoEjercicio As Integer, ByVal dFechaModificacion As Date, ByVal iPruebas As Integer) As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "GeneraXMLBalanzaComprobacion"
        Dim bValidaciones As Boolean = False, sValidaciones As String, fElectronica As FacturaElectronica
        Dim strStreamW As Stream = Nothing, strStreamWriter As StreamWriter = Nothing, sCarpeta As String
        Dim oXML As New XmlDocument, sRutaXML As String
        Try
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Validar si el archivo ya fue generado
            Me.Consultar(iCodigoTipoArchivo, dFecha)
            If Me._EXISTE = True Then
                If MsgBox("Este archivo ya se generó, seguro desea genearlo otra vez?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, sProcedure) = MsgBoxResult.No Then
                    Exit Function
                End If
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oTipo As New Class_Contabilidad_Electronica_CatalogoTiposArchivos(iCodigoTipoArchivo.ToString)
            If oTipo.EXISTE = False Then
                Exit Function
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            sCarpeta = sContabilidadElectronicaCarpeta & "\" & Year(dFecha) & "." & Format(dFecha, "MM").ToUpper
            sRutaXML = sCarpeta & "\" & Empresa_Sistema.RFC & Year(dFecha) & Format(dFecha, "MM") & oTipo.TERMINACION_NOMBRE_ARCHIVO_XML & ".xml" '"BN.xml"

            If Len(Dir(sCarpeta, FileAttribute.Directory)) = 0 Then
                MkDir(sCarpeta)
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim dt As New DataTable
            Using da As New SqlDataAdapter("MP_CONTABILIDAD_ELECTRONICA_BALANZA_COMPROBACION", Me._Conexion)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                Dim parameter As SqlParameter
                parameter = New SqlParameter("@FECHA_ENVIO", SqlDbType.NVarChar, 20) : parameter.Value = Format(dFecha, "yyyy-dd-MM") : da.SelectCommand.Parameters.Add(parameter)
                parameter = New SqlParameter("@FECHA_MODIFICACION", SqlDbType.NVarChar, 20) : parameter.Value = Format(dFechaModificacion, "yyyy-dd-MM") : da.SelectCommand.Parameters.Add(parameter)
                parameter = New SqlParameter("@ID_CON_EJERCICIO", SqlDbType.SmallInt) : parameter.Value = iCodigoEjercicio : da.SelectCommand.Parameters.Add(parameter)
                parameter = New SqlParameter("@CODIGO_TIPO_ARCHIVO", SqlDbType.SmallInt) : parameter.Value = iCodigoTipoArchivo : da.SelectCommand.Parameters.Add(parameter)
                parameter = New SqlParameter("@CODIGO_USUARIO", SqlDbType.SmallInt) : parameter.Value = Usuario.Codigo_Usuario : da.SelectCommand.Parameters.Add(parameter)
                parameter = New SqlParameter("@PRUEBAS", SqlDbType.SmallInt) : parameter.Value = iPruebas : da.SelectCommand.Parameters.Add(parameter)
                parameter = New SqlParameter("@VALIDACIONES", SqlDbType.NVarChar, 2000) : parameter.Value = "" : parameter.Direction = ParameterDirection.Output : da.SelectCommand.Parameters.Add(parameter)

                da.Fill(dt)
                sValidaciones = da.SelectCommand.Parameters("@VALIDACIONES").Value.ToString
                bValidaciones = CBool(sValidaciones.Substring(0, 1))
            End Using
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If bValidaciones = False Then
                Dim sValidacionesSplit As String() = sValidaciones.Substring(2).Split(CChar(";"))
                sValidaciones = ""
                For Each x In sValidacionesSplit
                    sValidaciones += x & vbCrLf
                Next

                If MsgBox("Hay validaciones que no se cumplieron y son : " & vbCrLf &
                      sValidaciones & vbCrLf &
                      "Esta seguro de querer generar el xml de la balanza de todas formas?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, sProcedure) = MsgBoxResult.No Then

                    Me.ReporteBalanzaComprobacion(dFecha, iCodigoTipoArchivo, iCodigoEjercicio, iPruebas)

                    Exit Function
                End If
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            strStreamW = File.Create(sRutaXML)
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.UTF8) ' tipo de codificacion para escritura

            'Linea por línea construye el xml en un stream, aun no existe el archivo en físico
            For Each dRow As DataRow In dt.Rows
                If dRow("LINEA").ToString.Length > 0 Then 'And dRow("LINEA").ToString > "010" Then
                    strStreamWriter.WriteLine(dRow("LINEA").ToString)
                End If
            Next

            strStreamWriter.Flush()
            strStreamW.Position = 0
            Dim SR As New StreamReader(strStreamW)
            Dim LineRead As String = SR.ReadToEnd 'Aquí del stream lo carga todo en una variable con la que se cargará el xml con LoadXml
            'SR.Dispose()'No es necesario haerle dispose porque el dispose del strStreamWriter lo libera

            strStreamWriter.Close()
            strStreamWriter.Dispose()

            oXML.LoadXml(LineRead)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim Cert As Certificado = GestionaCertificado(Date.Now) 'intencionalmente se le pasa cualquier fecha con el fin de validar si está vigente el certificado, este xml no tiene fecha, tiene mes y año y no es necesario crear una fecha.
            If Cert.CertificadoValido = False Then
                Exit Function
            End If

            oXML.Item("BCE:Balanza").Attributes("noCertificado").Value = Cert.noCertificado
            oXML.Item("BCE:Balanza").Attributes("Certificado").Value = Cert.Certificado
            oXML.Save(sRutaXML)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim xmlDoc As New MSXML2.DOMDocument60
            xmlDoc.loadXML(oXML.InnerXml)

            'Esto se ocupaba cuando era versión 1.1
            'Dim sTemp As String
            'sTemp = xmlDoc.xml
            'sTemp = Replace(xmlDoc.xml, """www.sat.gob.mx/", """http://www.sat.gob.mx/") 'Se tienen que poner los http porque si no marca error el sello, pero el xml no debe guardarse con los https
            'xmlDoc.loadXML(sTemp)

            'fElectronica = GenerarSelloContabilidadElectronicaConChilkat(xmlDoc, TipoArchivoContabilidadElectronica.BALANZA_COMPROBACION)
            fElectronica = GenerarSelloContabilidadElectronicaConPFX(sRutaXML, TipoArchivoContabilidadElectronica.BALANZA_COMPROBACION)

            If txtLEN(fElectronica.SelloDigital) = False Then
                MsgBox("No se generó el sello digital.", MsgBoxStyle.Exclamation, sProcedure)
                Exit Function
            End If

            oXML.Item("BCE:Balanza").Attributes("Sello").Value = fElectronica.SelloDigital
            oXML.Save(sRutaXML)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If ConvierteUTF8(sRutaXML) = False Then
                MsgBox("Error al intentar convertir el archivo a utf8.", MsgBoxStyle.Exclamation, Me.NombreClase)
                Exit Function
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Comprime

            Dim sRutaXMLZip As String = sRutaXML.Replace(".xml", ".zip")

            Using zip As ZipFile = New ZipFile()
                zip.AddFile(sRutaXML, "")
                zip.Save(sRutaXMLZip)
            End Using
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Borra archivo xml(se necesita sólo en .zip)

            File.Delete(sRutaXML)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If oXML.FirstChild.NodeType = XmlNodeType.XmlDeclaration Then
                oXML.RemoveChild(oXML.FirstChild) 'Se tiene que graba sin el encabezado de la codificación
            End If

            If iPruebas = 0 Then 'Sólo se va grabar cuando no sean pruebas.
                bResultado = Me.GrabaXML(dFecha, iCodigoTipoArchivo, oXML.InnerXml)
            Else
                bResultado = True
            End If

            Dim proceso As New ProcessStartInfo()
            proceso.FileName = sCarpeta
            Process.Start(proceso)

            'En la balanza ese muestra el reporte al final siempre.
            Me.ReporteBalanzaComprobacion(dFecha, iCodigoTipoArchivo, iCodigoEjercicio, iPruebas)

        Catch ex As Exception
            HandleError(Me.NombreClase, sProcedure, ex)
        Finally
            If IsNothing(strStreamWriter) = False Then
                strStreamWriter.Dispose()
            End If
            If IsNothing(strStreamW) = False Then
                strStreamW.Dispose()
            End If
        End Try

        Return bResultado
    End Function

    Public Sub ReporteBalanzaComprobacion(ByVal dFecha As Date, ByVal iCodigoTipoArchivo As Integer, ByVal iCodigoEjercicio As Integer, Optional ByVal iPruebas As Integer = 0)
        Const sProcedure As String = "ReporteBalanzaComprobacion"
        Try
            Dim Rpt As New ReportDocument
            Dim oReporte As New Class_Reporte("RPT_CONTABILIDAD_ELECTRONICA_BALANZA_COMPROBACION", Rpt, True)
            If Not oReporte.RptCargado Then
                Exit Sub
            End If
            Rpt.SetParameterValue("@FECHA_ENVIO", Format(dFecha, "yyyy-dd-MM"))
            Rpt.SetParameterValue("@FECHA_MODIFICACION", Format(dFecha, "yyyy-dd-MM")) 'se pasa la misma fecha, no influye en el reporte
            Rpt.SetParameterValue("@ID_CON_EJERCICIO", iCodigoEjercicio)
            Rpt.SetParameterValue("@CODIGO_TIPO_ARCHIVO", iCodigoTipoArchivo)
            Rpt.SetParameterValue("@CODIGO_USUARIO", Usuario.Codigo_Usuario)
            Rpt.SetParameterValue("@PRUEBAS", "0")
            Rpt.SetParameterValue("@VALIDACIONES", "0")

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.ShowDialog()
            frm.Dispose()
        Catch ex As Exception
            HandleError(Me.NombreClase, sProcedure, ex)
        End Try
    End Sub

    Private Function GrabaXML(ByVal dFecha As Date, ByVal iCodigoTipoArchivo As Integer, ByVal sXML As String) As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "GrabaXML"

        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CONTABILIDAD_ELECTRONICA_GRABA_XML"

            sqlParametro = .Parameters.Add("@FECHA_ENVIO", SqlDbType.DateTime) : sqlParametro.Value = dFecha
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_ARCHIVO", SqlDbType.SmallInt) : sqlParametro.Value = iCodigoTipoArchivo
            sqlParametro = .Parameters.Add("@CADENA_XML", SqlDbType.Xml) : sqlParametro.Value = sXML

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.NombreClase, sProcedure, ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
            Return bResultado
        End With
    End Function

    Public Function GeneraXMLPolizasPeriodo(ByVal dFecha As Date, ByVal iCodigoTipoArchivo As Integer, ByVal iCodigoEjercicio As Integer, ByVal sNumOrden As String, ByVal sNumTramite As String, ByVal iPruebas As Integer) As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "GeneraXMLPolizasPeriodo"

        Dim bValidaciones As Boolean = False, fElectronica As New FacturaElectronica()
        Dim strStreamW As Stream = Nothing, strStreamWriter As StreamWriter = Nothing, sCarpeta As String
        Dim oXML As New XmlDocument, sRutaXML As String

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Validar si el archivo ya fue generado
            Me.Consultar(iCodigoTipoArchivo, dFecha)
            If Me._EXISTE = True Then
                If MsgBox("Este archivo ya se generó, seguro desea genearlo otra vez?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, sProcedure) = MsgBoxResult.No Then
                    Return False
                End If
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oTipo As New Class_Contabilidad_Electronica_CatalogoTiposArchivos(iCodigoTipoArchivo.ToString)
            If oTipo.EXISTE = False Then
                Return False
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            sCarpeta = sContabilidadElectronicaCarpeta & "\" & Year(dFecha) & "." & Format(dFecha, "MM").ToUpper
            sRutaXML = sCarpeta & "\" & Empresa_Sistema.RFC & Year(dFecha) & Format(dFecha, "MM") & oTipo.TERMINACION_NOMBRE_ARCHIVO_XML & ".xml" '"BN.xml"

            If Len(Dir(sCarpeta, FileAttribute.Directory)) = 0 Then
                MkDir(sCarpeta)
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim dt As New DataTable
            Using da As New SqlDataAdapter("MP_CONTABILIDAD_ELECTRONICA_POLIZAS", Me._Conexion)
                da.SelectCommand.CommandTimeout = 300
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                Dim parameter As SqlParameter

                parameter = New SqlParameter("@FECHA", SqlDbType.NVarChar, 20) : parameter.Value = Format(dFecha, "yyyy-dd-MM") : da.SelectCommand.Parameters.Add(parameter)
                parameter = New SqlParameter("@ID_CON_EJERCICIO", SqlDbType.SmallInt) : parameter.Value = iCodigoEjercicio : da.SelectCommand.Parameters.Add(parameter)
                parameter = New SqlParameter("@CODIGO_TIPO_ARCHIVO", SqlDbType.SmallInt) : parameter.Value = iCodigoTipoArchivo : da.SelectCommand.Parameters.Add(parameter)
                parameter = New SqlParameter("@NUM_ORDEN", SqlDbType.NVarChar, 13) : parameter.Value = sNumOrden : da.SelectCommand.Parameters.Add(parameter)
                parameter = New SqlParameter("@NUM_TRAMITE", SqlDbType.NVarChar, 15) : parameter.Value = sNumTramite : da.SelectCommand.Parameters.Add(parameter)

                da.Fill(dt)
            End Using
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If dt.Rows.Count <= 0 Then
                MsgBox("No se encontró ninguna información.", vbExclamation, sProcedure)
                Return False
            End If

            If dt.Rows.Count = 1 Then
                MsgBox("No se encontraron pólizas.", vbExclamation, sProcedure)
                Return False
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            strStreamW = File.Create(sRutaXML)
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.UTF8) ' tipo de codificacion para escritura

            'Linea por línea construye el xml en un stream, aun no existe el archivo en físico
            'For Each dRow As DataRow In dt.Select("LEN(LINEA)>0")
            For Each dRow As DataRow In dt.Rows
                If dRow("LINEA").ToString.Length > 0 Then 'And dRow("LINEA").ToString > "010" Then
                    strStreamWriter.WriteLine(dRow("LINEA").ToString)
                    'Console.WriteLine(dRow("LINEA").ToString)
                End If
            Next

            strStreamWriter.Flush()
            strStreamW.Position = 0
            Dim SR As New StreamReader(strStreamW)
            Dim LineRead As String = SR.ReadToEnd 'Aquí del stream lo carga todo en una variable con la que se cargará el xml con LoadXml
            'SR.Dispose()'No es necesario haerle dispose porque el dispose del strStreamWriter lo libera

            strStreamWriter.Close()
            strStreamWriter.Dispose()

            oXML.LoadXml(LineRead)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim Cert As Certificado = GestionaCertificado(Date.Now) 'intencionalmente se le pasa cualquier fecha con el fin de validar si está vigente el certificado, este xml no tiene fecha, tiene mes y año y no es necesario crear una fecha.
            If Cert.CertificadoValido = False Then
                Return False
            End If

            oXML.Item("PLZ:Polizas").Attributes("noCertificado").Value = Cert.noCertificado
            oXML.Item("PLZ:Polizas").Attributes("Certificado").Value = Cert.Certificado
            oXML.Save(sRutaXML)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim xmlDoc As New MSXML2.DOMDocument60
            xmlDoc.loadXML(oXML.InnerXml)

            fElectronica = GenerarSelloContabilidadElectronicaConPFX(sRutaXML, TipoArchivoContabilidadElectronica.POLIZAS)

            If txtLEN(fElectronica.SelloDigital) = False Then
                MsgBox("No se generó el sello digital.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            oXML.Item("PLZ:Polizas").Attributes("Sello").Value = fElectronica.SelloDigital
            oXML.Save(sRutaXML)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If ConvierteUTF8(sRutaXML) = False Then
                MsgBox("Error al intentar convertir el archivo a utf8.", MsgBoxStyle.Exclamation, Me.NombreClase)
                Return False
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Comprime
            Dim sRutaXMLZip As String = sRutaXML.Replace(".xml", ".zip")

            Using zip As ZipFile = New ZipFile()
                zip.AddFile(sRutaXML, "")
                zip.Save(sRutaXMLZip)
            End Using
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Borra archivo xml(se necesita sólo en .zip)

            File.Delete(sRutaXML)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If oXML.FirstChild.NodeType = XmlNodeType.XmlDeclaration Then
                oXML.RemoveChild(oXML.FirstChild) 'Se tiene que graba sin el encabezado de la codificación
            End If

            If iPruebas = 0 Then 'Sólo se va grabar cuando no sean pruebas.
                bResultado = Me.GrabaXML(dFecha, iCodigoTipoArchivo, oXML.InnerXml)
            Else
                bResultado = True
            End If

            Process.Start(sCarpeta)

        Catch ex As Exception
            HandleError(Me.NombreClase, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Public Function GeneraXMLAuxiliarCtas(ByVal dFecha As Date, ByVal iCodigoTipoArchivo As Integer, ByVal iCodigoEjercicio As Integer, ByVal sNumOrden As String, ByVal sNumTramite As String, ByVal iPruebas As Integer) As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "GeneraXMLAuxiliarCtas"

        Dim bValidaciones As Boolean = False, fElectronica As New FacturaElectronica()
        Dim strStreamW As Stream = Nothing, strStreamWriter As StreamWriter = Nothing, sCarpeta As String
        Dim oXML As New XmlDocument, sRutaXML As String

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Validar si el archivo ya fue generado
            Me.Consultar(iCodigoTipoArchivo, dFecha)
            If Me._EXISTE = True Then
                If MsgBox("Este archivo ya se generó, seguro desea genearlo otra vez?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, sProcedure) = MsgBoxResult.No Then
                    Return False
                End If
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oTipo As New Class_Contabilidad_Electronica_CatalogoTiposArchivos(iCodigoTipoArchivo.ToString)
            If oTipo.EXISTE = False Then
                Return False
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            sCarpeta = sContabilidadElectronicaCarpeta & "\" & Year(dFecha) & "." & Format(dFecha, "MM").ToUpper
            sRutaXML = sCarpeta & "\" & Empresa_Sistema.RFC & Year(dFecha) & Format(dFecha, "MM") & oTipo.TERMINACION_NOMBRE_ARCHIVO_XML & ".xml" '"BN.xml"

            If Len(Dir(sCarpeta, FileAttribute.Directory)) = 0 Then
                MkDir(sCarpeta)
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim dt As New DataTable
            Using da As New SqlDataAdapter("MP_CONTABILIDAD_ELECTRONICA_AUXILIAR_CUENTAS", Me._Conexion)
                da.SelectCommand.CommandTimeout = 300
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                Dim parameter As SqlParameter

                parameter = New SqlParameter("@FECHA", SqlDbType.NVarChar, 20) : parameter.Value = Format(dFecha, "yyyy-dd-MM") : da.SelectCommand.Parameters.Add(parameter)
                parameter = New SqlParameter("@ID_CON_EJERCICIO", SqlDbType.SmallInt) : parameter.Value = iCodigoEjercicio : da.SelectCommand.Parameters.Add(parameter)
                parameter = New SqlParameter("@CODIGO_TIPO_ARCHIVO", SqlDbType.SmallInt) : parameter.Value = iCodigoTipoArchivo : da.SelectCommand.Parameters.Add(parameter)
                parameter = New SqlParameter("@NUM_ORDEN", SqlDbType.NVarChar, 13) : parameter.Value = sNumOrden : da.SelectCommand.Parameters.Add(parameter)
                parameter = New SqlParameter("@NUM_TRAMITE", SqlDbType.NVarChar, 15) : parameter.Value = sNumTramite : da.SelectCommand.Parameters.Add(parameter)

                da.Fill(dt)
            End Using
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If dt.Rows.Count <= 0 Then
                MsgBox("No se encontró ninguna información.", vbExclamation, sProcedure)
                Return False
            End If

            If dt.Rows.Count = 1 Then
                MsgBox("No se encontraron pólizas.", vbExclamation, sProcedure)
                Return False
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            strStreamW = File.Create(sRutaXML)
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.UTF8) ' tipo de codificacion para escritura

            'Linea por línea construye el xml en un stream, aun no existe el archivo en físico
            'For Each dRow As DataRow In dt.Select("LEN(LINEA)>0")
            For Each dRow As DataRow In dt.Rows
                If dRow("LINEA").ToString.Length > 0 Then 'And dRow("LINEA").ToString > "010" Then
                    strStreamWriter.WriteLine(dRow("LINEA").ToString)
                    'Console.WriteLine(dRow("LINEA").ToString)
                End If
            Next

            strStreamWriter.Flush()
            strStreamW.Position = 0
            Dim SR As New StreamReader(strStreamW)
            Dim LineRead As String = SR.ReadToEnd 'Aquí del stream lo carga todo en una variable con la que se cargará el xml con LoadXml
            'SR.Dispose()'No es necesario haerle dispose porque el dispose del strStreamWriter lo libera

            strStreamWriter.Close()
            strStreamWriter.Dispose()

            oXML.LoadXml(LineRead)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim Cert As Certificado = GestionaCertificado(Date.Now) 'intencionalmente se le pasa cualquier fecha con el fin de validar si está vigente el certificado, este xml no tiene fecha, tiene mes y año y no es necesario crear una fecha.
            If Cert.CertificadoValido = False Then
                Return False
            End If

            oXML.Item("AuxiliarCtas:AuxiliarCtas").Attributes("noCertificado").Value = Cert.noCertificado
            oXML.Item("AuxiliarCtas:AuxiliarCtas").Attributes("Certificado").Value = Cert.Certificado
            oXML.Save(sRutaXML)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim xmlDoc As New MSXML2.DOMDocument60
            xmlDoc.loadXML(oXML.InnerXml)

            fElectronica = GenerarSelloContabilidadElectronicaConPFX(sRutaXML, TipoArchivoContabilidadElectronica.AUXILIAR_CTAS)

            If txtLEN(fElectronica.SelloDigital) = False Then
                MsgBox("No se generó el sello digital.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            oXML.Item("AuxiliarCtas:AuxiliarCtas").Attributes("Sello").Value = fElectronica.SelloDigital
            oXML.Save(sRutaXML)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If ConvierteUTF8(sRutaXML) = False Then
                MsgBox("Error al intentar convertir el archivo a utf8.", MsgBoxStyle.Exclamation, Me.NombreClase)
                Return False
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Comprime
            Dim sRutaXMLZip As String = sRutaXML.Replace(".xml", ".zip")

            Using zip As ZipFile = New ZipFile()
                zip.AddFile(sRutaXML, "")
                zip.Save(sRutaXMLZip)
            End Using
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Borra archivo xml(se necesita sólo en .zip)

            File.Delete(sRutaXML)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If oXML.FirstChild.NodeType = XmlNodeType.XmlDeclaration Then
                oXML.RemoveChild(oXML.FirstChild) 'Se tiene que graba sin el encabezado de la codificación
            End If

            If iPruebas = 0 Then 'Sólo se va grabar cuando no sean pruebas.
                bResultado = Me.GrabaXML(dFecha, iCodigoTipoArchivo, oXML.InnerXml)
            Else
                bResultado = True
            End If

            Process.Start(sCarpeta)

        Catch ex As Exception
            HandleError(Me.NombreClase, sProcedure, ex)
        End Try

        Return bResultado
    End Function
#End Region

End Class
