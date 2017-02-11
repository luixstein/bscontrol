Option Strict On

Imports System.Web
Imports System.Web.Services
Imports System.Xml
Imports System.Xml.XmlDocument
Imports System.IO


Public Class Frm_AgregaAddenda

    Private _FolioFactura As String

    Private _CodigoDocumento As String
    Private _CodigoAlmacen As String

    Dim oVenta As Class_Ventas_Global
    Dim oTienda As New Class_CatTiendasSoriana
    Dim oAddenda As New Class_CatAddenda

    Private sRutaXML As String

#Region "Propiedades"
    Public Property FolioFactura() As String
        Get
            Return Me._FolioFactura
        End Get
        Set(ByVal Value As String)
            Me._FolioFactura = Value
        End Set
    End Property

    Public Property CodigoAlmacen() As String
        Get
            Return Me._CodigoAlmacen
        End Get
        Set(ByVal Value As String)
            Me._CodigoAlmacen = Value
        End Set
    End Property

    Public Property CodigoDocumento() As String
        Get
            Return Me._CodigoDocumento
        End Get
        Set(ByVal Value As String)
            Me._CodigoDocumento = Value
        End Set
    End Property
#End Region

    Private Sub Frm_AgregaAddenda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtFolio.Text = Me.FolioFactura
        oVenta = New Class_Ventas_Global(Me.FolioFactura)
        If oVenta.Existe = True Then
            Me.DesplegarTipoMoneda()
            Me.DesplegarTipoBulto()
            Dim oCatVentaAdenda As New Class_CatAddenda(oVenta.FOLIO_VENTA)
            If oCatVentaAdenda.Existe = False Then
                Me.txtProveedor.Text = Empresa_Sistema.CODIGO_PROVEDOR_SORIANA.ToString
                Me.dpFecha.Value = Now
                If oVenta.TIPO_DE_CAMBIO > 0 Then
                    Me.cboTipoMoneda.Text = "DOLARES"
                Else
                    Me.cboTipoMoneda.Text = "PESOS"
                End If
            Else
                Me.txtProveedor.Text = oCatVentaAdenda.CODIGO_PROVEEDOR_SORIANA.ToString 'Empresa_Sistema.CODIGO_PROVEDOR_SORIANA.ToString
                Me.txtTienda.Text = oCatVentaAdenda.CODIGO_TIENDA_SORIANA
                Me.txtCita.Text = oCatVentaAdenda.CITA.ToString
                Me.txtcantidadbultos.Text = oCatVentaAdenda.CANTIDAD_BULTOS.ToString
                Me.dpFecha.Value = oCatVentaAdenda.FECHA_ENTREGA
                Me.txtFolioPedido.Text = oCatVentaAdenda.FOLIO_PEDIDO
                Me.txtFolioNotaEntrada.Text = oCatVentaAdenda.FOLIO_NOTA_ENTRADA

                If oCatVentaAdenda.TIPO_MONEDA = 1 Then
                    Me.cboTipoMoneda.Text = "PESOS"
                Else
                    Me.cboTipoMoneda.Text = "DOLARES"
                End If

                If oCatVentaAdenda.TIPO_BULTO = 1 Then
                    Me.CboTipoBulto.Text = "CAJAS"
                Else
                    Me.CboTipoBulto.Text = "BOLSAS"
                End If

                Select Case oCatVentaAdenda.TIPO_ADDENDA
                    Case "N" 'Normal
                        Me.rbAddendaNormal.Checked = True
                    Case "E" 'Extemporanea
                        Me.rbAddendaExtemporanea.Checked = True
                End Select

                If oCatVentaAdenda.ENVIADA_CORRECTAMENTE = True Then
                    Me.BtnEnviar.Enabled = False
                End If
            End If
            Me.txtTienda.Focus()
        End If
    End Sub

#Region "Métodos y procedimientos"

    Private Sub DesplegarTipoMoneda()
        Me.cboTipoMoneda.Items.Add("PESOS")
        Me.cboTipoMoneda.Items.Add("DOLARES")

        Me.cboTipoMoneda.SelectedItem = "PESOS"
    End Sub

    Private Sub DesplegarTipoBulto()
        Me.CboTipoBulto.Items.Add("CAJAS")
        Me.CboTipoBulto.Items.Add("BOLSAS")

        Me.CboTipoBulto.SelectedItem = "CAJAS"
    End Sub

    Private Sub btnGrabarAddenda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabarAddenda.Click
        Try
            If Me.Validar() = False Then
                Exit Sub
            End If
            If Me.Grabar() = False Then
                Exit Sub
            End If
            If Me.AgregaAddenda(False) = True Then
                'Me.EnviaAddenda()
                'Me.Close()
                MsgBox("Addenda de ventas grabada satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            End If
        Catch ex As Exception
            HandleError(Me.Name, "btnGrabarAddenda", ex)
        End Try
    End Sub

    Private Function Validar() As Boolean
        If txtLEN(Me.txtProveedor.Text) = False Then
            MsgBox("Favor de proporcionar el proveedor", MsgBoxStyle.Exclamation, "Validar addenda")
            Me.txtProveedor.Focus()
            Exit Function
        End If

        If txtLEN(Me.txtTienda.Text) = False Then
            MsgBox("Favor de introducir tienda.", MsgBoxStyle.Exclamation, "Validar addenda")
            Me.txtTienda.Focus()
            Exit Function
        End If

        If Me.rbAddendaNormal.Checked = True Then
            If txtLEN(Me.txtCita.Text) = False Then
                MsgBox("Favor de introducir número de Cita.", MsgBoxStyle.Exclamation, "Validar addenda")
                Me.txtCita.Focus()
                Exit Function
            End If
        ElseIf Me.rbAddendaExtemporanea.Checked = True Then
            If txtLEN(Me.txtFolioNotaEntrada.Text) = False Then
                MsgBox("Favor de introducir el folio de la nota de entrada.", MsgBoxStyle.Exclamation, "Validar addenda")
                Me.txtFolioNotaEntrada.Focus()
                Exit Function
            End If
        End If

        If CDate(Format(Me.dpFecha.Value, "yyyy-MM-dd")) < CDate(Format(oVenta.FECHA, "yyyy-MM-dd")) Then
            MsgBox("La fecha de entrega debe ser mayor a la fecha de la factura.", MsgBoxStyle.Exclamation, "Validar addenda")
            Me.dpFecha.Focus()
            Exit Function
        End If

        If txtLEN(Me.txtFolioPedido.Text) = False Then
            MsgBox("Favor de introducir número de pedido.", MsgBoxStyle.Exclamation, "Validar addenda")
            Me.txtFolioPedido.Focus()
            Exit Function
        End If
        Validar = True
    End Function
    Private Sub txtTienda_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTienda.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oTienda.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.txtTienda.Text = sText
            Case Keys.Enter
                If txtLEN(Me.txtTienda.Text) = False Then
                    GoTo Buscar : Exit Sub
                End If

                Me.oTienda = New Class_CatTiendasSoriana(Me.txtTienda.Text)
                If Me.oTienda.Existe = False Then
                    Me.txtTienda.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblNombreTiendaSoriana.Text = Me.oTienda.NOMBRE_TIENDA_SORIANA

                Me.CboTipoBulto.Focus()
        End Select
    End Sub

    Private Function AgregaAddenda(ByVal bMensajes As Boolean) As Boolean
        Try

            oVenta = New Class_Ventas_Global(Me.txtFolio.Text)

            If oVenta.TIMBRADO_CFDI = "1" Then
                sRutaXML = sFelectronicaCarpetaXmlsTimbrados & "\" & Me.txtFolio.Text & ".xml"
            Else
                MsgBox("El documento no esta timbrado, no se puede agregar addenda. Avíse por favor al depto. de sistemas.", vbExclamation, Me.Text)
                Exit Function
            End If

            Dim oAddenda As New Addenda(Me.oVenta, sRutaXML)

            AgregaAddenda = oAddenda.GeneraAddenda

        Catch ex As Exception
            HandleError(Me.Name, "AgregaAddenda", ex)
        End Try
    End Function

    Private Function EnviaAddenda() As Boolean
        Try
            Dim WebServerSoriana As New wsSorianaProduccion.wseDocReciboSoapClient
            'Dim WebServerSoriana As New WSPruebaSoriana.wseDocReciboSoapClient

            Dim xml As String = "", sArchivo As String = "", sRespuesta As String = ""

            Dim XMLDoc As XmlDocument, Aperak As New XmlDocument, sRutaXmlAperak As String = ""

            sArchivo = sFelectronicaCarpetaXmlsTimbrados & "\" & Me.txtFolio.Text & ".xml"

            sRutaXmlAperak = Path.GetDirectoryName(sArchivo) + "\Aperak_" + Path.GetFileName(sArchivo)

            XMLDoc = New XmlDocument
            XMLDoc.Load(sArchivo)

            If XMLDoc.FirstChild.NodeType = XmlNodeType.XmlDeclaration Then
                XMLDoc.RemoveChild(XMLDoc.FirstChild)
            End If

            sRespuesta = WebServerSoriana.RecibeCFD(XMLDoc.InnerXml)

            Try
                Aperak.LoadXml(sRespuesta)
            Catch ex As Exception
                MsgBox("No se recibió una respuesta válida en formato xml por parte del proveedor, lo que se recibió fué :" & vbCrLf & _
                    sRespuesta & vbCrLf & _
                    ex.Message, MsgBoxStyle.Critical, Me.Name)
            End Try

            'Este es para probar leer un xml de aperak que ya existe.
            'Aperak.Load("D:\_Documentacion\_Diseños\Agrinet\Addenda Soriana\Aceptado\FEC-1660 extemporanea aperak error.XML")

            Dim sMensaje As String = Aperak.SelectSingleNode("//AckErrorApplication").Attributes("documentStatus").Value
            Dim bEnviada As Boolean
            'Dim sAdicional As String = Aperak.SelectSingleNode("//AckErrorApplication").SelectSingleNode("//messageError").InnerXml
            'Con este de abajo corta exacto el error,  pero considero mejor dar mas información del error, jorgegc
            'Aperak.SelectSingleNode("//AckErrorApplication").SelectSingleNode("//messageError").SelectSingleNode("//errorDescription").Item("text").InnerText 

            If sMensaje = "ACCEPTED" Then
                bEnviada = True
                MsgBox("Enviado y aceptado correctamente.", MsgBoxStyle.Information, "Respuesta de Aperak")
            Else
                Dim sAdicional As String = Aperak.SelectSingleNode("//AckErrorApplication").SelectSingleNode("//messageError").InnerXml
                MsgBox("Rechazado." & vbCrLf & _
                       "Descripción del error : " & sMensaje & " " & sAdicional, MsgBoxStyle.Critical, "Respuesta de Aperak")
            End If

            Aperak.Save(sRutaXmlAperak)

            sRespuesta = Replace(sRespuesta, "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & "?>", "")
            Me.oAddenda.FOLIO_VENTA = Me.txtFolio.Text
            If Me.oAddenda.Graba_Aperak(sRespuesta, bEnviada) = False Then
                MsgBox("El aperak no se grabo. Avíse al depto. de sistemas")
            End If

        Catch ex As Exception
            HandleError(Me.Name, "EnviaAddenda", ex)
        End Try
    End Function

    Private Function Grabar() As Boolean
        Try
            If MsgBox("Deseas agregar la Addenda a la factura con el folio : " & Me.txtFolio.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Grabar") = MsgBoxResult.No Then
                Exit Function
            End If

            If Usuario.ValidaPermisoUsuarioDocumentoConAfectacionInventarios(Me._CodigoDocumento.ToString, Me._CodigoAlmacen.ToString) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
                Exit Function
            End If

            Dim sql As New Class_find("SELECT 1 FROM VENTAS_ADDENDAS WHERE FOLIO_VENTA='" & Me.txtFolio.Text & "' ")

            With Me.oAddenda
                .CODIGO_PROVEEDOR_SORIANA = CInt(Empresa_Sistema.CODIGO_PROVEDOR_SORIANA)
                .FOLIO_VENTA = Me.txtFolio.Text.ToUpper
                .CODIGO_TIENDA_SORIANA = Me.txtTienda.Text
                .TIPO_MONEDA = CInt(IIf(Me.cboTipoMoneda.Text = "PESOS", 1, 2))
                .TIPO_BULTO = CInt(IIf(Me.CboTipoBulto.Text = "BOLSAS", 2, 1))
                .CANTIDAD_BULTOS = CInt(Me.txtcantidadbultos.Text)
                .FECHA_ENTREGA = Me.dpFecha.Value
                .CITA = Me.txtCita.Text
                .FOLIO_PEDIDO = Me.txtFolioPedido.Text
                .FOLIO_NOTA_ENTRADA = Me.txtFolioNotaEntrada.Text
                .TIPO_ADDENDA = IIf(Me.rbAddendaNormal.Checked = True, "N", "E").ToString

                If sql.Result1 <> "" Then
                    If .Actualizar = False Then
                        MsgBox("Error al tratar de actualizar el movimiento de addenda.", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                    End If
                Else
                    If .Insertar = False Then
                        MsgBox("Error al tratar de insertar el movimiento de addenda.", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                    End If
                End If

                Grabar = True
                'MsgBox("Movimiento de ventas grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            End With
        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try
    End Function

    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolio.KeyDown, txtFolioPedido.KeyDown, txtProveedor.KeyDown, _
    txtCita.KeyDown, cboTipoMoneda.KeyDown, txtcantidadbultos.KeyDown, txtFolioNotaEntrada.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub
    Private Sub CboTipoBulto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboTipoBulto.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.txtcantidadbultos.Focus()
        End Select
    End Sub

    Private Sub DtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dpFecha.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolio.KeyPress, txtCita.KeyPress, txtFolioPedido.KeyPress, _
   txtProveedor.KeyPress, txtTienda.KeyPress, CboTipoBulto.KeyPress, cboTipoMoneda.KeyPress, txtTienda.KeyPress, dpFecha.KeyPress, txtcantidadbultos.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCita.KeyPress, txtFolioPedido.KeyPress, _
                                                                                    txtcantidadbultos.KeyPress, txtFolioNotaEntrada.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosDecimalKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub
#End Region

    Private Sub BtnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnviar.Click
        Me.EnviaAddenda()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    Private Sub rbAddendaNormal_CheckedChanged(sender As Object, e As EventArgs) Handles rbAddendaNormal.CheckedChanged
        If Me.rbAddendaNormal.Checked = True Then
            Me.txtCita.Enabled = True
            Me.txtFolioNotaEntrada.Enabled = False
            Me.txtFolioNotaEntrada.Text = ""
        Else
            Me.txtFolioNotaEntrada.Enabled = True
            Me.txtCita.Enabled = False
            Me.txtCita.Text = ""
        End If
    End Sub
End Class