Option Strict On
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports System.Net

Public Class Frm_EnviaFacturaElectronicas

#Region "Propiedades"
    Public ReadOnly Property Nombre_Modulo() As String
        Get
            Return "Enviar facturas."
        End Get
    End Property
#End Region

    Private Enum enumEstados
        NUEVO
    End Enum

    Private Estado As enumEstados

#Region "Columnas grid"

    Private iGyFolio As Integer = 1
    Private iGyFecha As Integer = 2
    Private iGyReferencia As Integer = 3
    Private iGyTotal As Integer = 4
    Private iGySaldo As Integer = 5
    Private iGySeleccion As Integer = 6
    Private iGyEnviada As Integer = 7
    Private iGyDocumento As Integer = 8
#End Region

    Dim message As New MailMessage
    Dim smtp As New SmtpClient
    Private ClickSinEjecutar As Boolean = False

    Private Declare Function IsNetworkAlive Lib "SENSAPI.DLL" (ByRef lpdwFlags As Long) As Long


#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub tsbEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEnviar.Click
        If Me.Validar() = True Then
            Me.ProgresoBarra()
            Me.EnviarCorreo()
            Me.btnAgregarDocumentosClientes.PerformClick()
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub btnAgregarDocumentosClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarDocumentosClientes.Click
        Me.AgregarDocumentosClientes()
    End Sub
#End Region

#Region "Eventos de objetos"

    Private Sub Frm_CXC_Pagos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub TxtCodigoCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoCliente.KeyDown
        Dim oCliente As Class_CatClientes

        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                Dim Busqueda = New Busqueda_General("CODIGO_CLIENTE AS CODIGO,NOMBRE_CLIENTE AS NOMBRE", "CAT_CLIENTES", "1=1 AND ESTATUS='A' ", "NOMBRE", "NOMBRE_CLIENTE")
                Busqueda.ShowDialog()
                Me.txtCodigoCliente.Text = "" & Busqueda.Tag.ToString
                Busqueda.Dispose()

            Case Keys.Enter
                If txtLEN(Me.txtCodigoCliente.Text) = False Then
                    Me.lblNombreCliente.Text = ""
                    Me.txtCodigoCliente.Focus()
                    GoTo Buscar
                    Exit Sub
                End If
                oCliente = New Class_CatClientes(Me.txtCodigoCliente.Text)
                If oCliente.Consultar = True Then
                    If oCliente.ESTATUS = "A" Then
                        Me.lblNombreCliente.Text = oCliente.NOMBRE_CLIENTE
                        Me.TxtFormatoXML.Text = oCliente.FORMATO_NOMBRE_XML.ToString
                        If txtLEN(oCliente.CORREO_CLIENTE) = True Then
                            Me.txtCorreoCliente.Text = oCliente.CORREO_CLIENTE.ToString
                        End If
                        Me.txtCorreoCliente.Focus()
                        Me.tsbEnviar.Enabled = True
                        Me.btnActualizaCorreo.Enabled = True
                        Me.btnAgregarDocumentosClientes.Enabled = True
                        Me.txtCodigoCliente.Enabled = False
                    Else
                        MsgBox("El código de Cliente que intenta buscar no existe o esta dado de baja, favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de Clientes")
                        Me.lblNombreCliente.Text = ""
                        GoTo Buscar : Exit Sub
                    End If
                Else
                    MsgBox("El código de Cliente que intenta buscar no existe o esta dado de baja, favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de Clientes")
                    Me.lblNombreCliente.Text = ""
                    GoTo Buscar : Exit Sub
                End If
        End Select
    End Sub

    Private Sub Grid_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        Try
            Dim Columna As Integer = Me.Grid.Selection.FirstCol, Renglon As Integer = Me.Grid.Selection.FirstRow
            Dim StrCod As String = Me.Grid.Cell(Renglon, Columna).Text

            Select Case e.KeyCode
                Case Keys.Enter
                    Select Case Columna
                        'Case 1, 2, 3, 4, 5, 6
                        '    Me.Grid1.Cell(Renglon, Columna).SetFocus()
                        'Case 6
                        '    Me.Grid1.Cell(Renglon, 6).SetFocus()
                    End Select
                Case Keys.F8
                    Grid.Selection.DeleteByRow()
            End Select

            Me.Totales()

        Catch ex As Exception
            HandleError(Me.Name, "Grid1_KeyDown", ex)
        End Try
    End Sub

    Private Sub Grid_CellChanging(ByVal Sender As Object, ByVal e As FlexCell.Grid.CellChangingEventArgs) Handles Grid.CellChanging
        Try
            Dim Columna As Integer = e.Col, Renglon As Integer = e.Row

            If e.Col = Me.iGySeleccion And e.Row > 0 Then
                If Me.Grid.Cell(Renglon, Me.iGySeleccion).Text = "0" And Me.CkbMarcarTodo.Checked = True Then
                    Me.ClickSinEjecutar = True
                    Me.CkbMarcarTodo.Checked = False
                End If
            End If

            Me.Totales()

        Catch ex As Exception
            HandleError(Me.Name, "Grid_CellChanging", ex)
        End Try
    End Sub

    Private Sub txtCorreoCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCorreoCliente.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.btnActualizaCorreo.Focus()
        End If
    End Sub

    Private Sub btnActualizaCorreo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnActualizaCorreo.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.DtFechaDesde.Focus()
        End If
    End Sub

    Private Sub CkbMarcarTodo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CkbMarcarTodo.CheckedChanged
        Dim i As Integer, sMarcar As String = "0"

        If Me.CkbMarcarTodo.Checked = True Then
            sMarcar = "1"
        End If

        If Me.ClickSinEjecutar = True Then
            Me.ClickSinEjecutar = False
            Exit Sub
        End If

        For i = 1 To Me.Grid.Rows - 1
            If txtLEN(Me.Grid.Cell(i, Me.iGyFolio).Text) = True Then
                Me.Grid.Cell(i, Me.iGySeleccion).Text = sMarcar
            End If
        Next i
        Me.Totales()
    End Sub

    Private Sub btnActualizaCorreo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizaCorreo.Click
        Dim oCliente As New Class_CatClientes, tabla() As String, n As Integer

        If txtLEN(Me.txtCorreoCliente.Text) = False Then
            MsgBox("Favor de capturar un correo. ", MsgBoxStyle.Information, Me.Text)
            Me.txtCorreoCliente.Focus()
            Exit Sub
        End If

        tabla = Split(Me.txtCorreoCliente.Text, ";")

        For n = 0 To UBound(tabla, 1)
            If IsEmailSyntaxValid(tabla(n)) = False Then
                MsgBox("El correo no es valido, favor de verificar.", MsgBoxStyle.Exclamation, "Validación")
                Exit Sub
            End If
        Next

        oCliente.CODIGO_CLIENTE = Me.txtCodigoCliente.Text
        oCliente.CORREO_CLIENTE = Me.txtCorreoCliente.Text

        If oCliente.ActualizarCorreo() = True Then
            MsgBox("El correo del cliente se a actualizado correctamente. ", MsgBoxStyle.Information, Me.Text)
            Me.DtFechaDesde.Focus()
        End If
    End Sub

#Region "Eventos Genericos"
    Private Sub txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oTexBox As TextBox = CType(sender, TextBox)
        oTexBox.SelectAll()
    End Sub

    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtFechaDesde.KeyDown, DtFechaHasta.KeyDown, CboEstatus.KeyDown, ckbConSaldo.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosDecimalKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoCliente.KeyPress, txtCorreoCliente.KeyPress
        txtNoBeep(e)
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.DtFechaDesde.Value = CDate(Format(Date.Now, "01-MM-yyyy"))
            Me.DtFechaHasta.Value = Date.Now

            Me.txtCodigoCliente.Text = ""
            Me.lblNombreCliente.Text = ""
            Me.txtCorreoCliente.Text = ""
            Me.CboEstatus.Text = "A"
            Me.txtTotal.Text = ""
            Me.txtSaldo.Text = ""

            Me.InicializaGrid()
        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Try
            Me.Grid.DataSource = Nothing
            FG_Grid_Limpiar(Grid)

            'Creamos el Grid
            Me.Grid.Rows = 2
            Me.Grid.Cols = 9
            Me.Grid.DisplayRowNumber = True

            Me.FormateaGrid()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            Me.Grid.Column(Me.iGyFecha).Width = 100
            Me.Grid.Column(Me.iGyFolio).Width = 95
            Me.Grid.Column(Me.iGyTotal).Width = 100
            Me.Grid.Column(Me.iGySaldo).Width = 90
            Me.Grid.Column(Me.iGySeleccion).Width = 60
            Me.Grid.Column(Me.iGyReferencia).Width = 95
            Me.Grid.Column(Me.iGyEnviada).Width = 60
            Me.Grid.Column(Me.iGyDocumento).Width = 60

            Me.Grid.Cell(0, Me.iGyFolio).Text = "Folio"
            Me.Grid.Cell(0, Me.iGyFecha).Text = "Fecha"
            Me.Grid.Cell(0, Me.iGyTotal).Text = "Total"
            Me.Grid.Cell(0, Me.iGySaldo).Text = "Saldo"
            Me.Grid.Cell(0, Me.iGySeleccion).Text = "Selección"
            Me.Grid.Cell(0, Me.iGyReferencia).Text = "Referencia"
            Me.Grid.Cell(0, Me.iGyEnviada).Text = "Enviada"
            Me.Grid.Cell(0, Me.iGyDocumento).Text = "TipoDocumento"

            Me.Grid.Column(Me.iGyFecha).CellType = FlexCell.CellTypeEnum.DateTime
            Me.Grid.Column(Me.iGyFecha).FormatString = "dd-MMM-yy"

            Me.Grid.Column(Me.iGyTotal).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyTotal).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyTotal).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyTotal).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGySaldo).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGySaldo).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGySaldo).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGySaldo).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGySeleccion).CellType = FlexCell.CellTypeEnum.CheckBox

            Me.Grid.Refresh()

            Me.Grid.Column(Me.iGyFecha).Locked = True
            Me.Grid.Column(Me.iGyFolio).Locked = True
            Me.Grid.Column(Me.iGyTotal).Locked = True
            Me.Grid.Column(Me.iGySaldo).Locked = True
            Me.Grid.Column(Me.iGyReferencia).Locked = True
            Me.Grid.Column(Me.iGyEnviada).Locked = True
            Me.Grid.Column(Me.iGyDocumento).Visible = False

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

    Private Sub AgregarDocumentosClientes()
        Try
            If Me.txtCodigoCliente.TextLength = 0 Then
                MsgBox("Asígne el código del cliente.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtCodigoCliente.Focus()
                Exit Sub
            End If

            If Me.ValidarPeriodo = False Then
                Exit Sub
            End If

            Me.CkbMarcarTodo.Checked = False
            Me.InicializaGrid()
            Me.CargaDocumentos()

        Catch ex As Exception
            HandleError(Me.Name, "AgregarDocumentosClientes", ex)
        End Try
    End Sub

    Private Sub CargaDocumentos()
        Dim Conexion As New SqlConnection(Empresa_Sistema.conexion)
        Dim i As Integer = 1, oCliente As Class_CatClientes

        Dim cmd As New SqlCommand("SELECT FOLIO_VENTA,FECHA,ISNULL(FOLIO_REFERENCIA, '') FOLIO_REFERENCIA,TOTAL,SALDO,ENVIADA,'F' DOCUMENTO  " &
                                  "FROM VENTA_GLOBAL " &
                                  "WHERE CODIGO_CLIENTE='" & sReplace(Me.txtCodigoCliente.Text) & "' " &
                                  "AND CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " " &
                                  "AND FECHA BETWEEN '" & Format(Me.DtFechaDesde.Value, "yyyy-dd-MM") & "' AND '" & Format(Me.DtFechaHasta.Value, "yyyy-dd-MM 23:59:59") & "' " &
                                  IIf(Me.ckbConSaldo.Checked = True, " AND SALDO>0 ", "").ToString() & " " &
                                  IIf(Me.CboEstatus.Text <> "T", " AND ESTATUS_VENTA='" & Me.CboEstatus.Text & "' ", "").ToString &
                                  "" &
                                  "UNION ALL " &
                                  "" &
                                  "SELECT D.FOLIO_DESCUENTO,MAX(D.FECHA) FECHA,MAX(FOLIO_REFERENCIA) FOLIO_REFERENCIA,MAX(D.TOTAL) TOTAL,0 SALDO,MAX(ENVIADA) ENVIADA,'D' DOCUMENTO " &
                                  "FROM CXC_DESCUENTOS_GLOBAL D " &
                                  "INNER JOIN CXC_DESCUENTOS_DETALLE C ON(D.FOLIO_DESCUENTO=C.FOLIO_DESCUENTO) " &
                                  "INNER JOIN CXC_GLOBAL G ON(C.FOLIO_CXC=G.FOLIO_CXC) " &
                                  "WHERE D.CODIGO_CLIENTE='" & sReplace(Me.txtCodigoCliente.Text) & "' " &
                                  "AND D.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " " &
                                  "AND D.FECHA BETWEEN '" & Format(Me.DtFechaDesde.Value, "yyyy-dd-MM") & "' AND '" & Format(Me.DtFechaHasta.Value, "yyyy-dd-MM 23:59:59") & "' " &
                                  IIf(Me.CboEstatus.Text <> "T", " AND D.ESTATUS_DESCUENTO='" & Me.CboEstatus.Text & "' ", "").ToString &
                                  "GROUP BY D.FOLIO_DESCUENTO " &
                                  "" &
                                  "UNION ALL " &
                                  "" &
                                  "SELECT G.FOLIO_PAGO,G.FECHA_PAGO FECHA,'' FOLIO_REFERENCIA,G.MONTO TOTAL,0 SALDO,CASE WHEN G.ENVIADA_POR_CORREO='1' THEN 'SI' ELSE 'NO' END ENVIADA,'P' DOCUMENTO " &
                                  "FROM CFDI_PAGOS_CXC_GLOBAL G " &
                                  "INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO DOC ON(G.CODIGO_DOCUMENTO=DOC.CODIGO_DOCUMENTO) " &
                                  "WHERE G.CODIGO_CLIENTE='" & sReplace(Me.txtCodigoCliente.Text) & "' " &
                                  "AND DOC.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " " &
                                  "AND G.FECHA_PAGO BETWEEN '" & Format(Me.DtFechaDesde.Value, "yyyy-dd-MM") & "' AND '" & Format(Me.DtFechaHasta.Value, "yyyy-dd-MM 23:59:59") & "' " &
                                  IIf(Me.CboEstatus.Text <> "T", " AND G.ESTATUS_PAGO='" & Me.CboEstatus.Text & "' ", "").ToString &
                                  "" &
                                  "ORDER BY FECHA", Conexion)

        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                oCliente = New Class_CatClientes(sReplace(Me.txtCodigoCliente.Text))

                Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.HasRows = True Then
                    With Me.Grid
                        i = .Rows - 1

                        If .Cell(i, Me.iGyFolio).Text.Length > 0 Then
                            i = i + 1
                        End If

                        While dReader.Read()
                            .Rows = .Rows + 1
                            .Cell(i, Me.iGyFolio).Text = dReader("FOLIO_VENTA").ToString
                            .Cell(i, Me.iGyFecha).Text = dReader("FECHA").ToString
                            .Cell(i, Me.iGyReferencia).Text = dReader("FOLIO_REFERENCIA").ToString
                            .Cell(i, Me.iGyTotal).Text = dReader("TOTAL").ToString
                            .Cell(i, Me.iGySaldo).Text = dReader("SALDO").ToString
                            .Cell(i, Me.iGyEnviada).Text = dReader("ENVIADA").ToString
                            .Cell(i, Me.iGyDocumento).Text = dReader("DOCUMENTO").ToString

                            i = i + 1
                        End While
                    End With
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Text, "CargaFacturas", ex)
            Finally
                Conexion.Close()
                cmd.Dispose()
            End Try
        End With

        Me.Totales()

    End Sub

    Private Sub Totales()
        Try
            Me.txtTotal.Text = "0"
            Me.txtSaldo.Text = "0"
            Dim i As Integer
            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.iGyFolio).Text) = True And Me.Grid.Cell(i, Me.iGySeleccion).Text = "1" Then
                    Me.txtTotal.Text = (valorNumerico(Me.txtTotal.Text) + valorNumerico(Me.Grid.Cell(i, Me.iGyTotal).Text)).ToString
                    Me.txtSaldo.Text = (valorNumerico(Me.txtSaldo.Text) + valorNumerico(Me.Grid.Cell(i, Me.iGySaldo).Text)).ToString
                End If
            Next i

            Me.txtTotal.Text = FormatImporteContable(valorNumerico(Me.txtTotal.Text))
            Me.txtSaldo.Text = FormatImporteContable(valorNumerico(Me.txtSaldo.Text))
        Catch ex As Exception
            HandleError(Me.Name, "Totales", ex)
        End Try

    End Sub

    Private Function EnviarCorreo() As Boolean
        Dim bResultado As Boolean = False
        Dim i As Integer, iFacturas As Integer = 0, archivos As String = sFelectronicaCarpetaXMLPDF & "\"   '"C:\agrinet\FELECTRONICA\AGRINET_LAND\Xmls_Pdfs\CULIACAN\"
        Dim archivosXMLtimbrados As String = sFelectronicaCarpetaXmlsTimbrados & "\"
        Dim Ret As Long, tabla() As String, n As Integer

        'Si el Api retorna 0 quiere decir que no hay ningun tipo de conexión de Red
        If IsNetworkAlive(Ret) = 0 Then
            MsgBox("No existe conexión a internet.", MsgBoxStyle.Exclamation, Me.Name)
        Else
            Dim MyMailMsg As New Net.Mail.MailMessage
            Dim oUsuario As New Class_sisUsuarios

            Try
                oUsuario = New Class_sisUsuarios(Usuario.Codigo_Usuario)

                If txtLEN(oUsuario.CORREO_USUARIO) = False Then
                    MsgBox("El usuario no tiene correo configurado.", MsgBoxStyle.Exclamation, Me.Name)
                    Return False
                End If

                MyMailMsg.Subject = "FACTURAS DE " & Empresa_Sistema.NOMBRE_EMPRESA
                'MyMailMsg.To.Add(Me.txtCorreoCliente.Text)

                tabla = Split(Me.txtCorreoCliente.Text, ";")

                For n = 0 To UBound(tabla, 1)
                    MyMailMsg.To.Add(tabla(n))
                Next

                MyMailMsg.From = New MailAddress(oUsuario.CORREO_USUARIO.ToString)
                MyMailMsg.Priority = MailPriority.Normal
                MyMailMsg.Body = Me.txtComentarios.Text
                'MyMailMsg.IsBodyHtml = False
                'MyMailMsg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure

                Dim SMTP As New SmtpClient()
                SMTP.Host = oUsuario.SERVIDOR_CORREO_REMITENTE '"mail.passa.com.mx"
                SMTP.EnableSsl = oUsuario.USAR_SSL_REMITENTE ' True
                SMTP.Credentials = New System.Net.NetworkCredential(oUsuario.CORREO_USUARIO.ToString, oUsuario.CLAVE_CORREO.ToString)
                SMTP.Port = CInt(oUsuario.PUERTO_REMITENTE) '587

                Me.lblDisplayProgreso.Visible = True
                Me.pbBarra.Visible = True

                Me.pbBarra.Maximum = iFacturas
                Me.pbBarra.Tag = 0
                Me.pbBarra.MarqueeAnimationSpeed = 0
                Me.pbBarra.Style = ProgressBarStyle.Blocks
                Me.pbBarra.Value = 0

                Me.lblDisplayProgreso.Visible = True
                Me.pbBarra.Visible = True

                For i = 1 To Me.Grid.Rows - 1
                    If txtLEN(Me.Grid.Cell(i, Me.iGyFolio).Text) = True And Me.Grid.Cell(i, Me.iGySeleccion).Text = "1" Then
                        Me.pbBarra.Maximum = Me.pbBarra.Maximum + 1
                    End If
                Next

                For i = 1 To Me.Grid.Rows - 1
                    If txtLEN(Me.Grid.Cell(i, Me.iGyFolio).Text) = True And Me.Grid.Cell(i, Me.iGySeleccion).Text = "1" Then
                        Dim sRutaXML As String = "", sNombreXmlTimbrado As String = ""
                        Dim sRutaPDF As String = ""

                        Select Case Me.Grid.Cell(i, Me.iGyDocumento).Text
                            Case "F" 'Facturas
                                Dim oVenta As New Class_Ventas_Global(Me.Grid.Cell(i, Me.iGyFolio).Text)

                                If txtLEN(Me.TxtFormatoXML.Text) = True Then
                                    If Me.TxtFormatoXML.Text = "RFCemisor-Serie-FolioNumerico" Then
                                        sNombreXmlTimbrado = Empresa_Sistema.RFC & "-" & oVenta.SERIE & "-" & oVenta.FOLIO_NUMERICO
                                    ElseIf Me.TxtFormatoXML.Text = "RFCemisor-Fecha-SerieFolio" Then
                                        sNombreXmlTimbrado = Empresa_Sistema.RFC & Format(oVenta.FECHA, "yyyyddMM") & oVenta.SERIE & oVenta.FOLIO_NUMERICO
                                    End If
                                Else
                                    sNombreXmlTimbrado = Me.Grid.Cell(i, Me.iGyFolio).Text
                                End If
                                'sRutaXML = archivos.ToString & "\" & sNombreXmlTimbrado & ".xml"

                                sRutaXML = sFelectronicaCarpetaXmlsTimbrados & "\" & sNombreXmlTimbrado & ".xml"
                                sRutaPDF = archivos.ToString & sNombreXmlTimbrado & ".PDF"

                                If oVenta.RecuperaXML(sRutaXML) = True Then
                                    If oVenta.ExportarAPdf(sRutaPDF) = False Then
                                        MsgBox("No se logró generar el PDF de la factura : " & Me.Grid.Cell(i, Me.iGyFolio).Text & ". Avíse al depto. de sistemas.", vbExclamation, Me.Name)
                                    End If
                                Else
                                    MsgBox("No se logró recuperar el XML de la factura : " & Me.Grid.Cell(i, Me.iGyFolio).Text & ". Avíse al depto. de sistemas.", vbExclamation, Me.Name)
                                End If

                                oVenta.Enviado(oVenta.FOLIO_VENTA)
                                oVenta = Nothing

                            Case "D" 'Nota de crédito
                                Dim oDescuento As New Class_CXC_Descuento(Me.Grid.Cell(i, Me.iGyFolio).Text)

                                If txtLEN(Me.TxtFormatoXML.Text) = True Then
                                    If Me.TxtFormatoXML.Text = "RFCemisor-Serie-FolioNumerico" Then
                                        sNombreXmlTimbrado = Empresa_Sistema.RFC & "-" & oDescuento.SERIE & "-" & oDescuento.FOLIO_NUMERICO
                                    ElseIf Me.TxtFormatoXML.Text = "RFCemisor-Fecha-SerieFolio" Then
                                        sNombreXmlTimbrado = Empresa_Sistema.RFC & Format(oDescuento.FECHA, "yyyyddMM") & oDescuento.SERIE & oDescuento.FOLIO_NUMERICO
                                    End If
                                Else
                                    sNombreXmlTimbrado = Me.Grid.Cell(i, Me.iGyFolio).Text
                                End If
                                'sRutaXML = archivos.ToString & "\" & sNombreXmlTimbrado & ".xml"

                                sRutaXML = sFelectronicaCarpetaXmlsTimbrados & "\" & sNombreXmlTimbrado & ".xml"
                                sRutaPDF = archivos.ToString & sNombreXmlTimbrado & ".PDF"

                                If oDescuento.RecuperaXML(sRutaXML) = True Then
                                    If oDescuento.ExportarAPdf(sRutaPDF) = False Then
                                        MsgBox("No se logró generar el PDF del descuento : " & Me.Grid.Cell(i, Me.iGyFolio).Text & ". Avíse al depto. de sistemas.", vbExclamation, Me.Name)
                                    End If
                                Else
                                    MsgBox("No se logró recuperar el XML del descuento : " & Me.Grid.Cell(i, Me.iGyFolio).Text & ". Avíse al depto. de sistemas.", vbExclamation, Me.Name)
                                End If

                                oDescuento.Enviado(oDescuento.FOLIO_DESCUENTO)
                                oDescuento = Nothing

                            Case "P" 'Pagos
                                Dim oPago As New Class_CXC_Pago_CFDI_Global(Me.Grid.Cell(i, Me.iGyFolio).Text)

                                If oPago.EXISTE = False Then
                                    Exit Select
                                End If

                                If txtLEN(Me.TxtFormatoXML.Text) = True Then
                                    If Me.TxtFormatoXML.Text = "RFCemisor-Serie-FolioNumerico" Then
                                        sNombreXmlTimbrado = Empresa_Sistema.RFC & "-" & oPago.SERIE & "-" & oPago.FOLIO_NUMERICO
                                    ElseIf Me.TxtFormatoXML.Text = "RFCemisor-Fecha-SerieFolio" Then
                                        sNombreXmlTimbrado = Empresa_Sistema.RFC & Format(oPago.FECHA_PAGO, "yyyyddMM") & oPago.SERIE & oPago.FOLIO_NUMERICO
                                    End If
                                Else
                                    sNombreXmlTimbrado = Me.Grid.Cell(i, Me.iGyFolio).Text
                                End If
                                'sRutaXML = archivos.ToString & "\" & sNombreXmlTimbrado & ".xml"

                                sRutaXML = sFelectronicaCarpetaXmlsTimbrados & "\" & sNombreXmlTimbrado & ".xml"
                                sRutaPDF = archivos.ToString & sNombreXmlTimbrado & ".PDF"

                                If oPago.RecuperaXML(sRutaXML) = True Then
                                    If oPago.ExportarAPdf(sRutaPDF) = False Then
                                        MsgBox("No se logró generar el PDF del pago : " & Me.Grid.Cell(i, Me.iGyFolio).Text & ". Avíse al depto. de sistemas.", vbExclamation, Me.Name)
                                    End If
                                Else
                                    MsgBox("No se logró recuperar el XML del pago : " & Me.Grid.Cell(i, Me.iGyFolio).Text & ". Avíse al depto. de sistemas.", vbExclamation, Me.Name)
                                End If

                                oPago.MarcaEnviadoxCorreo(oPago.FOLIO_PAGO)
                                oPago = Nothing

                        End Select

                        Dim msa As New Attachment(sRutaPDF)
                        MyMailMsg.Attachments.Add(msa)
                        msa = New Attachment(sRutaXML)
                        MyMailMsg.Attachments.Add(msa)

                        ServicePointManager.ServerCertificateValidationCallback = Function(s As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) True

                        Me.pbBarra.Value = Me.pbBarra.Value + 1
                    End If
                Next i
                SMTP.Send(MyMailMsg)

                MsgBox("Tu E-Mail se ha enviado exitosamente.", MsgBoxStyle.Information, "Listo!!")
                bResultado = True

                Me.lblDisplayProgreso.Visible = False
                Me.pbBarra.Visible = False

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        Return bResultado
    End Function

    Private Shared Function ValidarCertificado(ByVal sender As Object, ByVal certificate As X509Certificate, ByVal chain As X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        'bypass de la validación del certificado (aplicar aquí validación personalizada si fuera el caso)
        Return True
    End Function

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Try
            Me.Estado = pEstado
            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.tsbEnviar.Enabled = False
                    Me.txtCodigoCliente.Enabled = True
                    Me.lblDisplayProgreso.Visible = False
                    Me.btnActualizaCorreo.Enabled = False
                    Me.btnAgregarDocumentosClientes.Enabled = False
                    Me.ckbConSaldo.Checked = True
                    Me.pbBarra.Visible = False
                    Me.Grid.Locked = False
                    'Me.gbAgregaDocCliente.Enabled = True
            End Select
        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Function Validar() As Boolean
        Const sProcedure As String = "Validar"
        Dim bResultado As Boolean = False
        Dim oCliente As Class_CatClientes
        Dim i As Integer, bMarcado As Boolean, tabla() As String, n As Integer

        oCliente = New Class_CatClientes(Me.txtCodigoCliente.Text)
        Try

            If oCliente.Consultar = True Then
                If oCliente.ESTATUS = "A" Then
                    Me.lblNombreCliente.Text = oCliente.NOMBRE_CLIENTE
                    Me.txtCorreoCliente.Focus()
                    Me.tsbEnviar.Enabled = True
                    Me.btnActualizaCorreo.Enabled = True
                    Me.btnAgregarDocumentosClientes.Enabled = True
                    Me.txtCodigoCliente.Enabled = False
                Else
                    MsgBox("El cliente no exite.", MsgBoxStyle.Exclamation, sProcedure)
                    Me.lblNombreCliente.Text = ""
                    Return False
                End If
            End If

            If txtLEN(Me.txtCorreoCliente.Text) = False Then
                MsgBox("El correo no es válido.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            tabla = Split(Me.txtCorreoCliente.Text, ";")

            For n = 0 To UBound(tabla, 1)
                If IsEmailSyntaxValid(tabla(n)) = False Then
                    MsgBox("El correo no es válido.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            Next

            For i = 1 To Me.Grid.Rows - 1
                If txtLEN(Me.Grid.Cell(i, Me.iGyFolio).Text) = True And Me.Grid.Cell(i, Me.iGySeleccion).Text = "1" Then
                    bMarcado = True
                End If
            Next i

            If bMarcado = False Then
                MsgBox("No ha seleccionado ningún documento.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If
            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Sub ProgresoBarra()
        Me.lblDisplayProgreso.Visible = True
        Me.pbBarra.Visible = True
        If Me.pbBarra.Tag Is "0" Then
            Me.pbBarra.MarqueeAnimationSpeed = 100
            Me.pbBarra.Style = ProgressBarStyle.Marquee
            Me.pbBarra.Tag = 1
        Else
            Me.pbBarra.Tag = 0
            Me.pbBarra.MarqueeAnimationSpeed = 0
            Me.pbBarra.Style = ProgressBarStyle.Blocks
            Me.pbBarra.Value = 0
        End If
        Me.lblDisplayProgreso.Visible = True
        Me.pbBarra.Visible = True
    End Sub

    Private Function ValidarPeriodo() As Boolean
        Me.DtFechaDesde.Enabled = False
        Me.DtFechaDesde.Enabled = True
        Me.DtFechaHasta.Enabled = False
        Me.DtFechaHasta.Enabled = True

        If Me.DtFechaDesde.Value > Me.DtFechaHasta.Value Then
            MsgBox("Rango de fechas inválidas.", MsgBoxStyle.Exclamation, Me.Name)
            Return False
        End If

        Return True
    End Function
#End Region

End Class
