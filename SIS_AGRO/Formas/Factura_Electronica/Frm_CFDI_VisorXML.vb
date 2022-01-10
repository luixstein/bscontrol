Imports System.IO
Imports System.Xml
Imports CFDIXML

Public Class Frm_CFDI_VisorXML

    Private _BaseDatosXML As String = "EXPEDIENTES_BS..XML_REPOSITORIO_GLOBAL"

#Region "Variables de control"
    Private _UUID As String = ""
    Private _LlamadoDesdeCFDIRelacionado As Boolean = False
    Private _RutaXML As String = ""
    Private _EsRutaXML As Boolean = False
#End Region

#Region "Campos grid conceptos"
    Private iGyConCantidad As Integer = 1
    Private iGyConClaveProdServ As Integer = 2
    Private iGyConClaveUnidad As Integer = 3
    Private iGyConDescripcion As Integer = 4
    Private iGyConValorUnitario As Integer = 5
    Private iGyConImporte As Integer = 6
    Private iGyConDescuento As Integer = 7
    'De aqui empieza la sección de impuestos.
    Private iGyConImpTraslado_o_Retencion As Integer = 8
    Private iGyConImpImpuesto As Integer = 9
    Private iGyConImpTipoFactor As Integer = 10
    Private iGyConImpBase As Integer = 11
    Private iGyConImpTasaOCuota As Integer = 12
    Private iGyConImpImporte As Integer = 13
#End Region

#Region "Campos grid impuestos"
    Private iGyImpTipo As Integer = 1
    Private iGyImpImpuesto As Integer = 2
    Private iGyImpTipoFactor As Integer = 3
    Private iGyImpTasaOCuota As Integer = 4
    Private iGyImpImporte As Integer = 5
#End Region

#Region "Campos grid impuestos"
    Private iGyCPIdDocumento As Integer = 1
    Private iGyCPSerie As Integer = 2
    Private iGyCPFolio As Integer = 3
    Private iGyCPMonedaDR As Integer = 4
    Private iGyCPTipoCambioDR As Integer = 5
    Private iGyCPMetodoDePagoDR As Integer = 6
    Private iGyCPNumParcialidad As Integer = 7
    Private iGyCPImpSaldoAnt As Integer = 8
    Private iGyCPImpPagado As Integer = 9
    Private iGyCPImpSaldoInsoluto As Integer = 10
#End Region

#Region "Campos grid cdfi relacionados"
    Private iGyCFDIRelTipoComprobante As Integer = 1
    Private iGyCFDIRelUUID As Integer = 2
    Private iGyCFDIRelFolioCompleto As Integer = 3
    Private iGyCFDIRelFecha As Integer = 4
    Private iGyCFDIRelTotal As Integer = 5
#End Region

#Region "Propiedades"
    'Public WriteOnly Property UUID() As String
    '    Set(ByVal Value As String)
    '        Me._UUID = Value
    '    End Set
    'End Property
#End Region

#Region "Opciones"
    Private Sub tsbAbrirArchivoXML_Click(sender As Object, e As EventArgs) Handles tsbAbrirArchivoXML.Click
        Me.AbrirArchivoXML()
    End Sub

    Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos de objetos"

#Region "Eventos"
    Private Sub GridCfdiRelacionados_Click(Sender As Object, e As EventArgs) Handles GridCfdiRelacionados.Click
        Dim iRenglon As Integer = Me.GridCfdiRelacionados.ActiveCell.Row
        Dim iColumna As Integer = Me.GridCfdiRelacionados.ActiveCell.Col
        Dim sUUID As String = ""
        If iColumna = Me.iGyCFDIRelUUID Then
            sUUID = Me.GridCfdiRelacionados.Cell(iRenglon, Me.iGyCFDIRelUUID).Text
            Dim oVisorXML As New Frm_CFDI_VisorXML(sUUID, True)
            oVisorXML.ShowDialog()
        End If
    End Sub

    Private Sub GridCP_Click(Sender As Object, e As EventArgs) Handles GridCP.Click
        Dim iRenglon As Integer = Me.GridCP.ActiveCell.Row
        Dim iColumna As Integer = Me.GridCP.ActiveCell.Col
        Dim sUUID As String = ""
        If iColumna = Me.iGyCPIdDocumento Then
            sUUID = Me.GridCP.Cell(iRenglon, Me.iGyCPIdDocumento).Text
            Dim oVisorXML As New Frm_CFDI_VisorXML(sUUID, True)
            oVisorXML.ShowDialog()
        End If
    End Sub
#End Region

#Region "Eventos Genericos"

#End Region

#End Region

#Region "Métodos y procedimientos"
    Public Sub New(ByVal sUUID As String, ByVal bLlamadoDesdeCFDIRelacionado As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        Me._UUID = sUUID
        Me._LlamadoDesdeCFDIRelacionado = bLlamadoDesdeCFDIRelacionado

        ' Add any initialization after the InitializeComponent() call.
        Me.Consultar()
    End Sub

    Public Sub New(ByVal sRutaXML As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me._RutaXML = sRutaXML
        Me._EsRutaXML = True

        Me.Consultar()
    End Sub

    Private Function AbrirArchivoXML() As Boolean
        Const sProcedure As String = "AbrirArchivoXML"
        Dim bResultado As Boolean = False
        Try
            Dim sXML As String = New Class_find("SELECT CADENA_XML FROM EXPEDIENTES..XMLS_SAT WHERE UUID='" + sReplace(Me._UUID) + "'").Result1

            If txtLEN(sXML) = False Then
                MsgBox("El UUID " + Me._UUID + " no existe en la base de datos de XML. Favor de verificar", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            Dim XmlDoc As New XmlDocument, sRutaXML As String

            sRutaXML = Path.ChangeExtension(Path.GetTempFileName, "xml")

            XmlDoc.LoadXml(sXML)

            'Crea el nodo principal o primera linea <?xml version="1.0"?>
            Dim Nodo As Xml.XmlDeclaration
            Nodo = XmlDoc.CreateXmlDeclaration("1.0", "utf-8", Nothing)
            'Agrega el nodo al documento
            Dim root As Xml.XmlElement = XmlDoc.DocumentElement
            XmlDoc.InsertBefore(Nodo, root)

            XmlDoc.Save(sRutaXML)

            If ConvierteUTF8(sRutaXML) = False Then
                MsgBox("Error al intentar convertir el archivo a utf8.", MsgBoxStyle.Exclamation, sProcedure)
            End If

            Process.Start(sRutaXML)

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Text, "AbrirArchivoXML", ex)
        Finally

        End Try

        Return bResultado
    End Function

    Private Function Consultar() As Boolean
        Const sProcedure As String = "Consultar"
        Dim bResultado As Boolean = False
        Try
            Dim sXML As String = "", xmlDoc As New XmlDocument()
            Dim oCFDI As New CFDIXML.ClassCFDI

            Select Case Me._EsRutaXML
                Case True
                    'Me._RutaXML = "C:\Users\jorgegc\Dropbox\Frestyle\_Actualizaciones\Bs\400-GastosRetenciones\Ejemplos XMLs\Hotel_2_traslados.xml"
                    'Me._RutaXML = "C:\Users\jorgegc\Google Drive\_Documentacion\_Sellos digitales fact ele PASSA\CFDI 3.3 y complemento pagos\Ejemplos varios\ImpuestosRetenidosLocalesSEVY8402138B4_479_FPP170927MHA.xml"
                    'xmlDoc.Load(Me._RutaXML)
                    'sXML = XmlDoc.InnerXml

                    oCFDI = New CFDIXML.ClassCFDI(Me._RutaXML, True) 'Internamente: ya se valida que este timbrado
                    sXML = oCFDI.XMLConDeclaracion
                    Me.lblEsRuta.Visible = True
                Case False
                    sXML = New Class_find("SELECT CADENA_XML FROM " + Me._BaseDatosXML + " WHERE UUID='" + sReplace(Me._UUID) + "'").Result1

                    If txtLEN(sXML) = False Then
                        MsgBox("El UUID " + Me._UUID + " no existe en la base de datos de XML. Favor de verificar", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If

                    oCFDI = New CFDIXML.ClassCFDI(sXML, False) 'Internamente: ya se valida que este timbrado
            End Select

            If oCFDI.XMLCargado = False Then
                Return False
            End If

            Select Case oCFDI.Comprobante.TipoDeComprobante
                Case "P" 'P-Pago(Complemento de pago)
                    Me.GridConceptos.Height = 87 'Lo recortamos porque siempre lleva un sólo renglón con información no relevante.
                    Me.gbComplementoPago.Visible = True : Me.GridCP.Visible = True : Me.lblDisplayDocumentosRelacionados.Visible = True 'Estaban todos ocultos por default
                Case Else
                    Me.GridConceptos.Height = 301
            End Select

            Me.txtTipoDeComprobante.Text = NombreTipoComprobante(oCFDI.Comprobante.TipoDeComprobante)
            Me.dtFecha.Value = oCFDI.Comprobante.Fecha
            Me.txtUUID.Text = oCFDI.ComplementoTFD.UUID.ToUpper
            Me.txtFolio.Text = oCFDI.Comprobante.Folio
            Me.txtSerie.Text = oCFDI.Comprobante.Serie
            Me.txtFormaPago.Text = oCFDI.Comprobante.FormaPago
            Me.txtMetodoPago.Text = oCFDI.Comprobante.MetodoPago
            Me.txtEmisorRFC.Text = oCFDI.Emisor.rfc
            Me.txtEmisorNombre.Text = oCFDI.Emisor.nombre
            Me.txtReceptorRFC.Text = oCFDI.Receptor.rfc
            Me.txtReceptorNombre.Text = oCFDI.Receptor.nombre
            Me.txtSubtotal.Text = FormatImporteContable(oCFDI.Comprobante.SubTotal)
            Me.txtDescuento.Text = FormatImporteContable(oCFDI.Comprobante.Descuento)
            Me.txtTotal.Text = FormatImporteContable(oCFDI.Comprobante.Total)
            Me.txtMoneda.Text = oCFDI.Comprobante.Moneda
            Me.txtTipoCambio.Text = Format(valorNumericoD(oCFDI.Comprobante.TipoCambio), "0.###0")
            Me.txtCondicionesDePago.Text = oCFDI.Comprobante.CondicionesDePago
            Me.txtLugarExpedicion.Text = oCFDI.Comprobante.LugarExpedicion
            Me.txtUsoCFDI.Text = oCFDI.Receptor.UsoCFDI

            If oCFDI.Comprobante.Moneda <> "MXN" And oCFDI.Comprobante.Moneda <> "XXX" Then
                Me.lblAvisoMonedaNoMXN.Visible = True
            End If

            xmlDoc.LoadXml(sXML) 'Leemos el xml como cadena

            Dim iRenglonConcepto As Integer = 2 'Al tener dos encabezados empezamos en el 2do renglón en vez del 1ero.

            Dim sImpuesto As String = "", iOrdenImpuesto As Integer = 0, sTipoImpuesto As String = ""

            Me.GridConceptos.AutoRedraw = False
            Me.GridImpuestos.AutoRedraw = False

            If xmlDoc.DocumentElement.Name = "cfdi:Comprobante" OrElse xmlDoc.DocumentElement.Name = "Comprobante" Then
                For i As Integer = 0 To xmlDoc.DocumentElement.ChildNodes.Count - 1
                    If xmlDoc.DocumentElement.ChildNodes(i).Name = "cfdi:Conceptos" OrElse xmlDoc.DocumentElement.ChildNodes(i).Name = "Conceptos" Then

                        For j As Integer = 0 To xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes.Count - 1 'Recorre los conceptos
                            If xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).Name = "cfdi:Concepto" OrElse xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).Name = "Concepto" Then
                                'Dim concepto As New clsConcepto()'No se usa este porque agarra otra clase diferente.
                                Dim concepto As New CFDIXML.clsConcepto

                                Select Case oCFDI.Comprobante.Version

                                    Case "3.3", "4.0"
                                        concepto.ClaveProdServ = xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).Attributes("ClaveProdServ").Value

                                        Try 'Es opcional
                                            concepto.NoIdentificacion = xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).Attributes("NoIdentificacion").Value
                                        Catch ex As Exception
                                            concepto.NoIdentificacion = ""
                                        End Try

                                        concepto.Cantidad = System.Convert.ToDouble(xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).Attributes("Cantidad").Value)
                                        concepto.ClaveUnidad = xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).Attributes("ClaveUnidad").Value

                                        Try 'Es opcional
                                            concepto.Unidad = xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).Attributes("Unidad").Value
                                        Catch msgx As System.Exception
                                            concepto.Unidad = ""
                                        End Try

                                        concepto.Descripcion = xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).Attributes("Descripcion").Value.Replace(vbLf, "")
                                        concepto.ValorUnitario = System.Convert.ToDouble(xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).Attributes("ValorUnitario").Value)
                                        concepto.Importe = System.Convert.ToDouble(xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).Attributes("Importe").Value)

                                        Try 'Es opcional
                                            concepto.Descuento = System.Convert.ToDouble(xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).Attributes("Descuento").Value)
                                        Catch ex As Exception
                                            concepto.Descuento = 0
                                        End Try

                                        Me.GridConceptos.Cell(iRenglonConcepto, Me.iGyConCantidad).Text = concepto.Cantidad
                                        Me.GridConceptos.Cell(iRenglonConcepto, Me.iGyConClaveProdServ).Text = concepto.ClaveProdServ
                                        Me.GridConceptos.Cell(iRenglonConcepto, Me.iGyConClaveUnidad).Text = concepto.ClaveUnidad
                                        Me.GridConceptos.Cell(iRenglonConcepto, Me.iGyConDescripcion).Text = concepto.Descripcion
                                        Me.GridConceptos.Cell(iRenglonConcepto, Me.iGyConValorUnitario).Text = concepto.ValorUnitario
                                        Me.GridConceptos.Cell(iRenglonConcepto, Me.iGyConImporte).Text = concepto.Importe
                                        Me.GridConceptos.Cell(iRenglonConcepto, Me.iGyConDescuento).Text = concepto.Descuento


                                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                        'Conceptos

                                        iOrdenImpuesto = 0

                                        For k As Integer = 0 To xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).ChildNodes.Count - 1 'RECORRE LOS DIFERENTES NODOS DENTRO DE CONCEPTOS
                                            If xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).ChildNodes(k).Name = "cfdi:Impuestos" Then
                                                For l As Integer = 0 To xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).ChildNodes(k).ChildNodes.Count - 1 'RECORRE LOS DIFERENTES NODOS DENTRO DE IMPUESTOS

                                                    sTipoImpuesto = xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).ChildNodes(k).ChildNodes(l).Name

                                                    If xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).ChildNodes(k).ChildNodes(l).Name = "cfdi:Traslados" Then
                                                        For m As Integer = 0 To xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).ChildNodes(k).ChildNodes(l).ChildNodes.Count - 1 'RECORRE LOS DIFERENTES NODOS DENTRO DE TRASLADOS
                                                            If xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).ChildNodes(k).ChildNodes(l).ChildNodes(m).Name = "cfdi:Traslado" Then
                                                                sImpuesto = NombreImpuesto(xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).ChildNodes(k).ChildNodes(l).ChildNodes(m).Attributes("Impuesto").Value)

                                                                If iOrdenImpuesto > 0 Then
                                                                    Me.GridConceptos.Rows += 1 : iRenglonConcepto += 1
                                                                End If
                                                                iOrdenImpuesto += 1

                                                                Me.GridConceptos.Cell(iRenglonConcepto, Me.iGyConImpTraslado_o_Retencion).Text = "Traslado"
                                                                Me.GridConceptos.Cell(iRenglonConcepto, Me.iGyConImpImpuesto).Text = sImpuesto
                                                                Me.GridConceptos.Cell(iRenglonConcepto, Me.iGyConImpTipoFactor).Text = xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).ChildNodes(k).ChildNodes(l).ChildNodes(m).Attributes("TipoFactor").Value
                                                                Me.GridConceptos.Cell(iRenglonConcepto, Me.iGyConImpBase).Text = System.Convert.ToDouble(xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).ChildNodes(k).ChildNodes(l).ChildNodes(m).Attributes("Base").Value)
                                                                Me.GridConceptos.Cell(iRenglonConcepto, Me.iGyConImpTasaOCuota).Text = LeeValorXML(xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).ChildNodes(k).ChildNodes(l).ChildNodes(m).Attributes("TasaOCuota")) 'Usa LeeValorXML orque es opcional
                                                                Me.GridConceptos.Cell(iRenglonConcepto, Me.iGyConImpImporte).Text = LeeValorXML(xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).ChildNodes(k).ChildNodes(l).ChildNodes(m).Attributes("Importe")) 'Usa LeeValorXML orque es opcional
                                                            End If
                                                        Next
                                                    ElseIf xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).ChildNodes(k).ChildNodes(l).Name = "cfdi:Retenciones" Then
                                                        For m As Integer = 0 To xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).ChildNodes(k).ChildNodes(l).ChildNodes.Count - 1 'RECORRE LOS DIFERENTES NODOS DENTRO DE RETENCIONES
                                                            If xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).ChildNodes(k).ChildNodes(l).ChildNodes(m).Name = "cfdi:Retencion" Then
                                                                sImpuesto = NombreImpuesto(xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).ChildNodes(k).ChildNodes(l).ChildNodes(m).Attributes("Impuesto").Value)

                                                                If iOrdenImpuesto > 0 Then
                                                                    Me.GridConceptos.Rows += 1 : iRenglonConcepto += 1
                                                                End If
                                                                iOrdenImpuesto += 1

                                                                Me.GridConceptos.Cell(iRenglonConcepto, Me.iGyConImpTraslado_o_Retencion).Text = "Retención"
                                                                Me.GridConceptos.Cell(iRenglonConcepto, Me.iGyConImpImpuesto).Text = sImpuesto
                                                                Me.GridConceptos.Cell(iRenglonConcepto, Me.iGyConImpTipoFactor).Text = xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).ChildNodes(k).ChildNodes(l).ChildNodes(m).Attributes("TipoFactor").Value
                                                                Me.GridConceptos.Cell(iRenglonConcepto, Me.iGyConImpBase).Text = System.Convert.ToDouble(xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).ChildNodes(k).ChildNodes(l).ChildNodes(m).Attributes("Base").Value)
                                                                Me.GridConceptos.Cell(iRenglonConcepto, Me.iGyConImpTasaOCuota).Text = LeeValorXML(xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).ChildNodes(k).ChildNodes(l).ChildNodes(m).Attributes("TasaOCuota")) 'Usa LeeValorXML orque es opcional
                                                                Me.GridConceptos.Cell(iRenglonConcepto, Me.iGyConImpImporte).Text = LeeValorXML(xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).ChildNodes(k).ChildNodes(l).ChildNodes(m).Attributes("Importe")) 'Usa LeeValorXML orque es opcional
                                                            End If
                                                        Next
                                                    End If
                                                Next
                                            End If
                                        Next

                                        'De momento no leemos anda si es 3.2
                                        'Case "3.2"

                                        '    concepto.Cantidad = System.Convert.ToDouble(xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).Attributes("cantidad").Value)
                                        '    Try
                                        '        concepto.Unidad = xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).Attributes("unidad").Value
                                        '    Catch msgx As System.Exception
                                        '        concepto.Unidad = ""
                                        '    End Try
                                        '    concepto.Descripcion = xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).Attributes("descripcion").Value.Replace(vbLf, "")
                                        '    concepto.ValorUnitario = System.Convert.ToDouble(xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).Attributes("valorUnitario").Value)
                                        '    concepto.Importe = System.Convert.ToDouble(xmlDoc.DocumentElement.ChildNodes.Item(i).ChildNodes(j).Attributes("importe").Value)

                                End Select

                                'list.Add(concepto)

                                Me.GridConceptos.Rows += 1 : iRenglonConcepto += 1

                            End If

                        Next
                    End If
                Next
            End If
            'Hasta aquí terminan de consultarse los conceptos

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Impuestos

            Dim NodoImpuestos As XmlNode = xmlDoc.Item("cfdi:Comprobante").Item("cfdi:Impuestos")
            Dim iRenglonImpuesto As Integer = 1

            If TieneValorXML(NodoImpuestos) = True Then
                If NodoImpuestos.HasChildNodes = True Then 'Se pregunta si tiene hijos porque hay xmls que tienen ivas exentos en los conceptos y en el total de impuestos acumulan el exento(lo cual no deberian pero lo hacen) 
                    'y no tendria los hijos de Traslados y fallaria tratar de leerlos

                    Me.GridImpuestos.Rows = 2
                    With NodoImpuestos
                        'Dim TotalImpuestosRetenidos As Decimal = valorNumerico(LeeValorXML(.Attributes("TotalImpuestosRetenidos")))
                        'Dim TotalImpuestosTrasladados As Decimal = valorNumerico(LeeValorXML(.Attributes("TotalImpuestosTrasladados")))

                        If TieneValorXML(.Item("cfdi:Traslados")) = True Then
                            For Each x As XmlNode In .Item("cfdi:Traslados").ChildNodes
                                sImpuesto = NombreImpuesto(LeeValorXML(x.Attributes("Impuesto")))

                                Me.GridImpuestos.Cell(iRenglonImpuesto, Me.iGyImpTipo).Text = "Traslado"
                                Me.GridImpuestos.Cell(iRenglonImpuesto, Me.iGyImpImpuesto).Text = sImpuesto
                                Me.GridImpuestos.Cell(iRenglonImpuesto, Me.iGyImpTipoFactor).Text = LeeValorXML(x.Attributes("TipoFactor"))
                                Me.GridImpuestos.Cell(iRenglonImpuesto, Me.iGyImpTasaOCuota).Text = LeeValorXML(x.Attributes("TasaOCuota"))
                                Me.GridImpuestos.Cell(iRenglonImpuesto, Me.iGyImpImporte).Text = LeeValorXML(x.Attributes("Importe"))

                                Me.GridImpuestos.Rows += 1 : iRenglonImpuesto += 1
                            Next
                        End If

                        If TieneValorXML(.Item("cfdi:Retenciones")) Then
                            For Each x As XmlNode In .Item("cfdi:Retenciones").ChildNodes
                                sImpuesto = NombreImpuesto(LeeValorXML(x.Attributes("Impuesto")))

                                Me.GridImpuestos.Cell(iRenglonImpuesto, Me.iGyImpTipo).Text = "Retencion"
                                Me.GridImpuestos.Cell(iRenglonImpuesto, Me.iGyImpImpuesto).Text = sImpuesto
                                Me.GridImpuestos.Cell(iRenglonImpuesto, Me.iGyImpTipoFactor).Text = LeeValorXML(x.Attributes("TipoFactor"))
                                Me.GridImpuestos.Cell(iRenglonImpuesto, Me.iGyImpTasaOCuota).Text = LeeValorXML(x.Attributes("TasaOCuota"))
                                Me.GridImpuestos.Cell(iRenglonImpuesto, Me.iGyImpImporte).Text = LeeValorXML(x.Attributes("Importe"))

                                Me.GridImpuestos.Rows += 1 : iRenglonImpuesto += 1
                            Next
                        End If
                    End With

                    Me.GridImpuestos.Rows -= 1 'Para quitar el renglón extra en blanco.
                End If
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Impuestos locales, estos impuestos los juntamos con los impuestos normales(debajo)

            Dim NodoImpuestosLocales As XmlNode = xmlDoc.Item("cfdi:Comprobante").Item("cfdi:Complemento").Item("implocal:ImpuestosLocales")
            If TieneValorXML(NodoImpuestosLocales) = True Then
                With NodoImpuestosLocales
                    Dim ImpuestosLocalesTotaldeRetenciones As Decimal = valorNumerico(LeeValorXML(.Attributes("TotaldeRetenciones")))
                    Dim ImpuestosLocalesTotaldeTraslados As Decimal = valorNumerico(LeeValorXML(.Attributes("TotaldeTraslados")))
                End With
            End If

            If TieneValorXML(NodoImpuestosLocales) = True Then
                If NodoImpuestosLocales.HasChildNodes = True Then
                    With NodoImpuestosLocales
                        For Each x As XmlNode In NodoImpuestosLocales
                            Me.GridImpuestos.Rows += 1 'Se lo vuelvo a poner porque al final de los otros impuestos se eliminan los renglones en blanco.

                            Select Case x.Name
                                Case "implocal:TrasladosLocales"
                                    Me.GridImpuestos.Cell(iRenglonImpuesto, Me.iGyImpTipo).Text = "TrasladosLocales"
                                    Me.GridImpuestos.Cell(iRenglonImpuesto, Me.iGyImpImpuesto).Text = LeeValorXML(x.Attributes("ImpLocTrasladado"))
                                    Me.GridImpuestos.Cell(iRenglonImpuesto, Me.iGyImpTipoFactor).Text = "" 'Este campo no aplica para impuesto locales.
                                    Me.GridImpuestos.Cell(iRenglonImpuesto, Me.iGyImpTasaOCuota).Text = LeeValorXML(x.Attributes("TasadeTraslado"))
                                    Me.GridImpuestos.Cell(iRenglonImpuesto, Me.iGyImpImporte).Text = LeeValorXML(x.Attributes("Importe"))

                                    Me.GridImpuestos.Rows += 1 : iRenglonImpuesto += 1

                                Case "implocal:RetencionesLocales"
                                    Me.GridImpuestos.Cell(iRenglonImpuesto, Me.iGyImpTipo).Text = "RetencionesLocales"
                                    Me.GridImpuestos.Cell(iRenglonImpuesto, Me.iGyImpImpuesto).Text = LeeValorXML(x.Attributes("ImpLocRetenido"))
                                    Me.GridImpuestos.Cell(iRenglonImpuesto, Me.iGyImpTipoFactor).Text = "" 'Este campo no aplica para impuesto locales.
                                    Me.GridImpuestos.Cell(iRenglonImpuesto, Me.iGyImpTasaOCuota).Text = LeeValorXML(x.Attributes("TasadeRetencion"))
                                    Me.GridImpuestos.Cell(iRenglonImpuesto, Me.iGyImpImporte).Text = LeeValorXML(x.Attributes("Importe"))

                                    Me.GridImpuestos.Rows += 1 : iRenglonImpuesto += 1
                            End Select
                        Next
                    End With

                    Me.GridImpuestos.Rows -= 1 'Para quitar el renglón extra en blanco.
                End If
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Complemento de pago
            If oCFDI.Comprobante.TipoDeComprobante = "P" Then 'P-Pago(Complemento de pago)
                Dim NodoPagos As XmlNode = xmlDoc.Item("cfdi:Comprobante").Item("cfdi:Complemento").Item("pago10:Pagos").Item("pago10:Pago")
                If TieneValorXML(NodoPagos) = True Then
                    With NodoPagos
                        Me.dtCPFecha.Value = CDate(LeeValorXML(.Attributes("FechaPago")))
                        Me.txtCPMonto.Text = FormatImporteContable(valorNumerico(LeeValorXML(.Attributes("Monto"))))
                        Me.txtCPFormaPago.Text = LeeValorXML(.Attributes("FormaDePagoP"))
                        Me.txtCPMoneda.Text = LeeValorXML(.Attributes("MonedaP"))
                        Me.txtCPTipoCambio.Text = Format(valorNumericoD(LeeValorXML(.Attributes("TipoCambioP"))), "0.###0")
                        Me.txtCPRFCEmisorCtaOrd.Text = LeeValorXML(.Attributes("RfcEmisorCtaOrd"))
                        Me.txtCPRFCEmisorCtaBen.Text = LeeValorXML(.Attributes("RfcEmisorCtaBen"))
                        Me.txtCPCtaOrdenante.Text = LeeValorXML(.Attributes("CtaOrdenante"))
                        Me.txtCPCtaBeneficiario.Text = LeeValorXML(.Attributes("CtaBeneficiario"))
                        Me.txtCPNumOperacion.Text = LeeValorXML(.Attributes("NumOperacion"))
                        Me.txtCPNomBancoOrdExt.Text = LeeValorXML(.Attributes("NomBancoOrdExt"))

                        Dim iRenglonComplementoPago As Integer = 1

                        If .HasChildNodes = True Then
                            Me.GridCP.Rows = 2

                            For Each x As XmlNode In NodoPagos
                                Me.GridCP.Cell(iRenglonImpuesto, Me.iGyCPIdDocumento).FontUnderline = True
                                Me.GridCP.Cell(iRenglonImpuesto, Me.iGyCPIdDocumento).ForeColor = Color.Blue

                                Me.GridCP.Cell(iRenglonImpuesto, Me.iGyCPIdDocumento).Text = LeeValorXML(x.Attributes("IdDocumento")).ToUpper
                                Me.GridCP.Cell(iRenglonImpuesto, Me.iGyCPSerie).Text = LeeValorXML(x.Attributes("Serie")).ToUpper
                                Me.GridCP.Cell(iRenglonImpuesto, Me.iGyCPFolio).Text = LeeValorXML(x.Attributes("Folio")).ToUpper
                                Me.GridCP.Cell(iRenglonImpuesto, Me.iGyCPMonedaDR).Text = LeeValorXML(x.Attributes("MonedaDR")).ToUpper
                                Me.GridCP.Cell(iRenglonImpuesto, Me.iGyCPTipoCambioDR).Text = Format(valorNumericoD(LeeValorXML(x.Attributes("TipoCambioDR"))), "0.###0")
                                Me.GridCP.Cell(iRenglonImpuesto, Me.iGyCPMetodoDePagoDR).Text = LeeValorXML(x.Attributes("MetodoDePagoDR")).ToUpper
                                Me.GridCP.Cell(iRenglonImpuesto, Me.iGyCPNumParcialidad).Text = LeeValorXML(x.Attributes("NumParcialidad"))
                                Me.GridCP.Cell(iRenglonImpuesto, Me.iGyCPImpSaldoAnt).Text = FormatImporteContable(valorNumericoD(LeeValorXML(x.Attributes("ImpSaldoAnt"))))
                                Me.GridCP.Cell(iRenglonImpuesto, Me.iGyCPImpPagado).Text = FormatImporteContable(valorNumericoD(LeeValorXML(x.Attributes("ImpPagado"))))
                                Me.GridCP.Cell(iRenglonImpuesto, Me.iGyCPImpSaldoInsoluto).Text = FormatImporteContable(valorNumericoD(LeeValorXML(x.Attributes("ImpSaldoInsoluto"))))

                                Me.GridCP.Rows += 1 : iRenglonImpuesto += 1
                            Next

                            Me.GridCP.Rows -= 1 'Para quitar el renglón extra en blanco.
                        End If
                    End With
                End If
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Cfdi's relacionados

            Dim iRenglonRelacionCFDI As Integer = 1

            Dim NodoCfdiRelacionados As XmlNode = xmlDoc.Item("cfdi:Comprobante").Item("cfdi:CfdiRelacionados")
            If TieneValorXML(NodoCfdiRelacionados) = True Then
                With NodoCfdiRelacionados
                    Me.txtTipoRelacion.Text = LeeValorXML(.Attributes("TipoRelacion")).ToUpper

                    Dim sNombreRelacion As String = New Class_find("SELECT NOMBRE_TIPO_RELACION_CFDI FROM CFDI_CAT_TIPOS_RELACIONES WHERE CODIGO_TIPO_RELACION_CFDI='" & sReplace(Me.txtTipoRelacion.Text) & "'").Result1

                    Me.txtTipoRelacion.Text = Me.txtTipoRelacion.Text + "-" + sNombreRelacion

                    If .HasChildNodes = True Then
                        Me.GridCfdiRelacionados.Rows = 2
                        For Each x As XmlNode In NodoCfdiRelacionados

                            Me.GridCfdiRelacionados.Cell(iRenglonRelacionCFDI, Me.iGyCFDIRelUUID).FontUnderline = True
                            Me.GridCfdiRelacionados.Cell(iRenglonRelacionCFDI, Me.iGyCFDIRelUUID).ForeColor = Color.Blue

                            Me.GridCfdiRelacionados.Cell(iRenglonRelacionCFDI, Me.iGyCFDIRelUUID).Text = LeeValorXML(x.Attributes("UUID")).ToUpper

                            sXML = New Class_find("SELECT CADENA_XML FROM " + Me._BaseDatosXML + " WHERE UUID='" + sReplace(LeeValorXML(x.Attributes("UUID")).ToUpper) + "'").Result1

                            'Abrir conexión para sacar la cadena xml y cargar clase cfdi
                            If txtLEN(sXML) = True Then
                                Dim oCFDIRelacionado As New ClassCFDI(sXML, False)

                                If oCFDIRelacionado.XMLCargado = False Then
                                    Continue For
                                End If

                                Me.GridCfdiRelacionados.Cell(iRenglonRelacionCFDI, Me.iGyCFDIRelTipoComprobante).Text = oCFDIRelacionado.Comprobante.TipoDeComprobante
                                Me.GridCfdiRelacionados.Cell(iRenglonRelacionCFDI, Me.iGyCFDIRelFolioCompleto).Text = oCFDIRelacionado.Comprobante.FolioCompleto
                                Me.GridCfdiRelacionados.Cell(iRenglonRelacionCFDI, Me.iGyCFDIRelFecha).Text = Format(CDate(oCFDIRelacionado.Comprobante.Fecha), "dd/MMM/yy")
                                Me.GridCfdiRelacionados.Cell(iRenglonRelacionCFDI, Me.iGyCFDIRelTotal).Text = oCFDIRelacionado.Comprobante.Total
                            End If

                            Me.GridCfdiRelacionados.Rows += 1 : iRenglonRelacionCFDI += 1
                        Next

                        Me.GridCfdiRelacionados.Rows -= 1 'Para quitar el renglón extra en blanco.
                    End If
                End With
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            HandleError(Me.Text, "Consultar", ex)
        Finally
            Me.FormateaGridConceptos()
            Me.GridConceptos.AutoRedraw = True
            Me.GridConceptos.Refresh()

            Me.FormateaGridImpuestos()
            Me.GridImpuestos.AutoRedraw = True
            Me.GridImpuestos.Refresh()

            Me.FormateaGridCP()
            Me.GridCP.AutoRedraw = True
            Me.GridCP.Refresh()

            Me.FormateaGridCFDIRel()
            Me.GridCfdiRelacionados.AutoRedraw = True
            Me.GridCfdiRelacionados.Refresh()
        End Try

        'Me.GridConceptos.ExportToExcel("c:\Temp\haber.xls", True, False)

        Return bResultado
    End Function

    Private Function NombreImpuesto(ByVal sCodigoImpuesto As String) As String
        Dim sResultado As String = ""
        Try
            Select Case sCodigoImpuesto
                Case "001"
                    sResultado = "ISR"
                Case "002"
                    sResultado = "IVA"
                Case "003"
                    sResultado = "IEPS"
                Case Else
                    sResultado = sCodigoImpuesto 'Quedará con el número
            End Select
        Catch ex As Exception
            HandleError(Me.Text, "NombreImpuesto", ex)
        End Try

        Return sResultado
    End Function

    Private Sub FormateaGridConceptos()
        Try
            With Me.GridConceptos
                .AutoRedraw = False
                .DisplayFocusRect = False
                '.DisplayDateTimeMask = True
                '.ExtendLastCol = True
                .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
                .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
                .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat

                .Column(Me.iGyConCantidad).Width = 80
                .Column(Me.iGyConClaveProdServ).Width = 70
                .Column(Me.iGyConClaveUnidad).Width = 70
                .Column(Me.iGyConDescripcion).Width = 140
                .Column(Me.iGyConValorUnitario).Width = 80
                .Column(Me.iGyConImporte).Width = 80
                .Column(Me.iGyConDescuento).Width = 80
                .Column(Me.iGyConImpTraslado_o_Retencion).Width = 50
                .Column(Me.iGyConImpBase).Width = 80
                .Column(Me.iGyConImpImpuesto).Width = 50
                .Column(Me.iGyConImpTipoFactor).Width = 60
                .Column(Me.iGyConImpTasaOCuota).Width = 60
                .Column(Me.iGyConImpImporte).Width = 80

                .Cell(1, Me.iGyConCantidad).Text = "Cantidad"
                .Cell(1, Me.iGyConClaveProdServ).Text = "ClaveProdServ"
                .Cell(1, Me.iGyConClaveUnidad).Text = "ClaveUnidad"
                .Cell(1, Me.iGyConDescripcion).Text = "Descripcion"
                .Cell(1, Me.iGyConValorUnitario).Text = "ValorUnitario"
                .Cell(1, Me.iGyConImporte).Text = "Importe"
                .Cell(1, Me.iGyConDescuento).Text = "Descuento"

                .Cell(1, Me.iGyConImpTraslado_o_Retencion).Text = "Tipo"
                .Cell(1, Me.iGyConImpImpuesto).Text = "Impuesto"
                .Cell(1, Me.iGyConImpTipoFactor).Text = "TipoFactor"
                .Cell(1, Me.iGyConImpBase).Text = "Base"
                .Cell(1, Me.iGyConImpTasaOCuota).Text = "TasaOCuota"
                .Cell(1, Me.iGyConImpImporte).Text = "Importe"

                .Cell(0, Me.iGyConImpTraslado_o_Retencion).Text = "Impuestos"
                .Range(0, Me.iGyConImpTraslado_o_Retencion, 0, Me.iGyConImpImporte).Merge()

                .Column(Me.iGyConCantidad).FormatString = "###,###,##0.#####0" '& CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyConCantidad).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyConCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyConValorUnitario).FormatString = "###,###,##0.#####0" '& CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyConValorUnitario).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyConValorUnitario).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyConImporte).FormatString = "###,###,##0.#####0" '& CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyConImporte).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyConImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyConDescuento).FormatString = "###,###,##0.#####0" '& CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyConDescuento).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyConDescuento).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyConImpBase).FormatString = "###,###,##0.#####0" '& CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyConImpBase).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyConImpBase).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyConImpTasaOCuota).FormatString = "###,###,##0.#####0" '& CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyConImpTasaOCuota).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyConImpTasaOCuota).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyConImpImporte).FormatString = "###,###,##0.#####0" '& CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyConImpImporte).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyConImpImporte).Alignment = FlexCell.AlignmentEnum.RightCenter
            End With

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridConceptos", ex)
        Finally
            Me.GridConceptos.AutoRedraw = True
            Me.GridConceptos.Refresh()
        End Try
    End Sub

    Private Sub FormateaGridImpuestos()
        Try
            With Me.GridImpuestos
                .AutoRedraw = False
                .DisplayFocusRect = False
                '.DisplayDateTimeMask = True
                '.ExtendLastCol = True
                .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
                .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
                .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat

                .Column(Me.iGyImpTipo).Width = 80
                .Column(Me.iGyImpImpuesto).Width = 80
                .Column(Me.iGyImpTipoFactor).Width = 80
                .Column(Me.iGyImpTasaOCuota).Width = 80
                .Column(Me.iGyImpImporte).Width = 80

                .Cell(0, Me.iGyImpTipo).Text = "Tipo"
                .Cell(0, Me.iGyImpImpuesto).Text = "Impuesto"
                .Cell(0, Me.iGyImpTipoFactor).Text = "TipoFactor"
                .Cell(0, Me.iGyImpTasaOCuota).Text = "TasaOCuota"
                .Cell(0, Me.iGyImpImporte).Text = "Importe"

                .Column(Me.iGyImpTasaOCuota).FormatString = "###,###,##0.#####0" '& CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyImpTasaOCuota).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyImpTasaOCuota).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyImpImporte).FormatString = "###,###,##0.#####0" '& CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyImpImporte).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyImpImporte).Alignment = FlexCell.AlignmentEnum.RightCenter
            End With

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridImpuestos", ex)
        Finally
            Me.GridImpuestos.AutoRedraw = True
            Me.GridImpuestos.Refresh()
        End Try
    End Sub

    Private Sub FormateaGridCP()
        Try
            With Me.GridCP
                .AutoRedraw = False
                .DisplayFocusRect = False
                '.DisplayDateTimeMask = True
                '.ExtendLastCol = True
                .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
                .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
                .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat

                .Column(Me.iGyCPIdDocumento).Width = 80
                .Column(Me.iGyCPSerie).Width = 80
                .Column(Me.iGyCPFolio).Width = 80
                .Column(Me.iGyCPMonedaDR).Width = 80
                .Column(Me.iGyCPTipoCambioDR).Width = 80
                .Column(Me.iGyCPMetodoDePagoDR).Width = 80
                .Column(Me.iGyCPNumParcialidad).Width = 80
                .Column(Me.iGyCPImpSaldoAnt).Width = 80
                .Column(Me.iGyCPImpPagado).Width = 80
                .Column(Me.iGyCPImpSaldoInsoluto).Width = 80

                .Cell(0, Me.iGyCPIdDocumento).Text = "UUID"
                .Cell(0, Me.iGyCPSerie).Text = "Serie"
                .Cell(0, Me.iGyCPFolio).Text = "Folio"
                .Cell(0, Me.iGyCPMonedaDR).Text = "MonedaDR"
                .Cell(0, Me.iGyCPTipoCambioDR).Text = "TipoCambioDR"
                .Cell(0, Me.iGyCPMetodoDePagoDR).Text = "MetodoDePagoDR"
                .Cell(0, Me.iGyCPNumParcialidad).Text = "NumParcialidad"
                .Cell(0, Me.iGyCPImpSaldoAnt).Text = "ImpSaldoAnt"
                .Cell(0, Me.iGyCPImpPagado).Text = "ImpPagado"
                .Cell(0, Me.iGyCPImpSaldoInsoluto).Text = "ImpSaldoInsoluto"

                .Column(Me.iGyCPTipoCambioDR).FormatString = "0.###0"
                .Column(Me.iGyCPTipoCambioDR).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCPTipoCambioDR).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCPImpSaldoAnt).FormatString = "###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyCPImpSaldoAnt).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCPImpSaldoAnt).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCPImpPagado).FormatString = "###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyCPImpPagado).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCPImpPagado).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyCPImpSaldoInsoluto).FormatString = "###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyCPImpSaldoInsoluto).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCPImpSaldoInsoluto).Alignment = FlexCell.AlignmentEnum.RightCenter
            End With

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridCP", ex)
        Finally
            Me.GridCP.AutoRedraw = True
            Me.GridCP.Refresh()
        End Try
    End Sub

    Private Sub FormateaGridCFDIRel()
        Try
            With Me.GridCfdiRelacionados
                .AutoRedraw = False
                .DisplayFocusRect = False
                '.DisplayDateTimeMask = True
                '.ExtendLastCol = True
                .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
                .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
                .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat

                .Column(Me.iGyCFDIRelTipoComprobante).Width = 80
                .Column(Me.iGyCFDIRelUUID).Width = 80
                .Column(Me.iGyCFDIRelFolioCompleto).Width = 80
                .Column(Me.iGyCFDIRelFecha).Width = 80
                .Column(Me.iGyCFDIRelTotal).Width = 80

                .Cell(0, Me.iGyCFDIRelTipoComprobante).Text = "Tipo"
                .Cell(0, Me.iGyCFDIRelUUID).Text = "UUID"
                .Cell(0, Me.iGyCFDIRelFolioCompleto).Text = "Folio"
                .Cell(0, Me.iGyCFDIRelFecha).Text = "Fecha"
                .Cell(0, Me.iGyCFDIRelTotal).Text = "Total"

                .Column(Me.iGyCFDIRelTotal).FormatString = "###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyCFDIRelTotal).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCFDIRelTotal).Alignment = FlexCell.AlignmentEnum.RightCenter
            End With

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridCFDIRel", ex)
        Finally
            Me.GridCfdiRelacionados.AutoRedraw = True
            Me.GridCfdiRelacionados.Refresh()
        End Try
    End Sub

    Private Function NombreTipoComprobante(ByVal TipoDeComprobante As String) As String
        Select Case TipoDeComprobante
            Case "I"
                Return "I-Ingreso"
            Case "E"
                Return "E-Egreso"
            Case "P"
                Return "P-Pago"
            Case "N"
                Return "N-Nomina"
            Case Else
                Return TipoDeComprobante
        End Select
    End Function

#End Region

End Class