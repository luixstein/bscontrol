Option Strict On

Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Imports System.Globalization

Public Class Frm_Embarques_Etiquetas

    Private oProductosLand As Class_CatArticulos
    Private oProductosMastronardi As Class_CatProductosMastronardi

    Private stringToPrint As String = ""

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos de objetos"
    Private Sub Frm_Embarques_Etiquetas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CargaImpresoras()
        Me.Inicializa()
    End Sub

    Private Sub cboImpresora_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboImpresora.SelectedIndexChanged
        My.Settings.ImpresoraEtiquetas = Me.cboImpresora.Text
        My.Settings.Save()
    End Sub

    Private Sub txtCodigoArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoArticulo.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
                If Me.rbnLand.Checked = True Or Me.rbnLand2013.Checked = True Then 'Land y Land2013
buscar_land:
                    Me.oProductosLand = New Class_CatArticulos
                    Dim sArticulo As String = Me.oProductosLand.BusquedaVisualProductosAgricolas_PorDescripcion
                    If sArticulo.Length > 0 Then
                        Me.txtCodigoArticulo.Text = sArticulo
                        Me.lblArticulo.Text = Me.oProductosLand.DESCRIPCION
                    End If
                Else 'Mastronardi
buscar_mastronardi:
                    Me.oProductosMastronardi = New Class_CatProductosMastronardi
                    Dim sArticulo As String = Me.oProductosMastronardi.BusquedaVisual_PorDescripcion
                    If sArticulo.Length > 0 Then
                        Me.txtCodigoArticulo.Text = sArticulo
                        Me.lblArticulo.Text = Me.oProductosMastronardi.DESCRIPCION
                    End If
                End If

            Case Keys.Enter
                If Me.rbnLand.Checked = True Or Me.rbnLand2013.Checked = True Then 'Land y Land2013
                    If txtLEN(Me.txtCodigoArticulo.Text) = False Then
                        Me.lblArticulo.Text = "" : GoTo buscar_land : Exit Sub
                    End If
                    Me.oProductosLand = New Class_CatArticulos(Me.txtCodigoArticulo.Text)
                    Me.lblArticulo.Text = Me.oProductosLand.DESCRIPCION
                    'Me.txtRango.Text = Me.oProductosLand.RANGO_PIEZAS
                    If txtLEN(Me.lblArticulo.Text) = False Then
                        Me.lblArticulo.Text = "" : GoTo buscar_land : Exit Sub
                    Else
                        txtTAB(e)
                    End If
                Else
                    If txtLEN(Me.txtCodigoArticulo.Text) = False Then
                        Me.lblArticulo.Text = "" : GoTo buscar_mastronardi : Exit Sub
                    End If
                    Me.oProductosMastronardi = New Class_CatProductosMastronardi(Me.txtCodigoArticulo.Text)
                    Me.lblArticulo.Text = Me.oProductosMastronardi.DESCRIPCION
                    Me.txtRango.Text = Me.oProductosMastronardi.RANGO_PIEZAS
                    If txtLEN(Me.lblArticulo.Text) = False Then
                        Me.lblArticulo.Text = "" : GoTo buscar_mastronardi : Exit Sub
                    Else
                        txtTAB(e)
                    End If
                End If
        End Select
    End Sub

    Private Sub txtCantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown
        txtTAB(e)
    End Sub

    Private Sub txtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub dtFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtFecha.KeyDown
        txtTAB(e)
    End Sub

    Private Sub printDocument1_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim charactersOnPage As Integer = 0
        Dim linesPerPage As Integer = 0

        ' Sets the value of charactersOnPage to the number of characters of stringToPrint that will fit within the bounds of the page.
        e.Graphics.MeasureString(stringToPrint, Me.Font, e.MarginBounds.Size, StringFormat.GenericTypographic, charactersOnPage, linesPerPage)
        ' Draws the string within the bounds of the page
        e.Graphics.DrawString(stringToPrint, Me.Font, Brushes.Black, e.MarginBounds, StringFormat.GenericTypographic)
        ' Remove the portion of the string that has been printed.
        stringToPrint = stringToPrint.Substring(charactersOnPage)
        ' Check to see if more pages are to be printed.
        e.HasMorePages = stringToPrint.Length > 0
    End Sub

    Private Sub rbnLand_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnLand.CheckedChanged
        Me.txtRango.Visible = True : Me.lblDisplayRango.Visible = True
        Me.txtMalla.Visible = False : Me.lblDisplayMalla.Visible = False
    End Sub

    Private Sub rbnLand2013_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnLand2013.CheckedChanged
        Me.txtRango.Visible = False : Me.lblDisplayRango.Visible = False
        Me.txtMalla.Visible = True : Me.lblDisplayMalla.Visible = True
    End Sub

    Private Sub rbnMastronardi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnMastronardi.CheckedChanged
        Me.txtRango.Visible = True : Me.lblDisplayRango.Visible = True
        Me.txtMalla.Visible = False : Me.lblDisplayMalla.Visible = False
    End Sub

#Region "Eventos Genéricos"
    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoArticulo.KeyPress, txtRango.KeyPress, dtFecha.KeyPress, txtMalla.KeyPress
        txtNoBeep(e)
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"
    Private Sub CargaImpresoras()
        For Each pkInstalledPrinters In PrinterSettings.InstalledPrinters
            Me.cboImpresora.Items.Add(pkInstalledPrinters)
        Next pkInstalledPrinters
        'cboImpresora.SelectedIndex = 0
        If txtLEN(My.Settings.ImpresoraEtiquetas) = True Then
            Me.cboImpresora.Text = My.Settings.ImpresoraEtiquetas
        End If
    End Sub

    Private Sub Inicializa()
        Me.txtCodigoArticulo.Text = ""
        Me.lblArticulo.Text = ""
        Me.txtCantidad.Text = "1"
        Me.dtFecha.Value = Date.Now
        Me.txtRango.Text = ""

        Me.txtCodigoArticulo.Focus()
    End Sub

    Private Sub Imprimir()
        If Me.rbnLand.Checked = True Or Me.rbnMastronardi.Checked = True Then
            If Me.GeneraArchivo() = True Then
                Me.PrintDocument1.PrinterSettings.Copies = CShort(Me.txtCantidad.Text)
                Me.PrintDocument1.PrinterSettings.PrinterName = Me.cboImpresora.Text
                Me.PrintDocument1.Print()
            End If
        ElseIf Me.rbnLand2013.Checked = True Then
            Me.ImprimirEtiqueta2013()
        End If
    End Sub

    Private Function GeneraArchivo() As Boolean
        Dim sArchivo As String = My.Settings.Ruta & "\etiqueta.prn"

        If txtLEN(Me.txtCodigoArticulo.Text) = False Then
            MsgBox("Asígne el producto.", MsgBoxStyle.Exclamation, Me.Text)
            Exit Function
        End If

        If Me.rbnLand.Checked = True Then
            Me.oProductosLand = New Class_CatArticulos(Me.txtCodigoArticulo.Text)
            If Me.oProductosLand.Existe = False Then
                MsgBox("El producto asignado no existe.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If
        Else
            Me.oProductosMastronardi = New Class_CatProductosMastronardi(Me.txtCodigoArticulo.Text)
            If Me.oProductosMastronardi.Existe = False Then
                MsgBox("El producto asignado no existe.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If
        End If

        If valorNumerico(Me.txtCantidad.Text) <= 0 Then
            MsgBox("Asígne la cantidad de etiquetas a imprimir.", MsgBoxStyle.Exclamation, Me.Text)
            Exit Function
        End If

        If Me.rbnLand.Checked = True Then
            GeneraArchivo = Me.GeneraEtiquetaLAND(sArchivo)
        Else
            GeneraArchivo = Me.GeneraEtiquetaMastronardi(sArchivo)
        End If

    End Function

    Private Function GeneraEtiquetaMastronardi(ByVal sArchivo As String) As Boolean
        Dim oSQl As New Class_find("SELECT DBO.FN_EMB_OBTIENE_LOTE_MASTRONARDI('" & Format(Me.dtFecha.Value, "yyyy-dd-MM") & "')")
        Dim sLote As String = oSQl.Result1

        If sLote.Length < 7 Then
            MsgBox("No se logró generar el lote para las etiquetas.", MsgBoxStyle.Exclamation, Me.Text)
            Exit Function
        End If

        Try
            Dim sw As New StreamWriter(sArchivo, False) ',  System.Text.Encoding.Unicode)

            sw.WriteLine("CT~~CD,~CC^~CT~")
            sw.WriteLine("^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR4,4~SD15^JUS^LRN^CI0^XZ")
            sw.WriteLine("^XA")
            sw.WriteLine("^MMT")
            sw.WriteLine("^PW727")
            sw.WriteLine("^LL0408")
            sw.WriteLine("^LS0")
            sw.WriteLine("^BY2,3,100^FT107,325^BCN,,N,N")
            sw.WriteLine("^FD>;>801" & Me.txtCodigoArticulo.Text & "10>6" & sLote & "^FS")
            sw.WriteLine("^FT435,69^A0N,28,28^FH\^FDPRODUIT OF MEXIQUE^FS")
            sw.WriteLine("^FT48,124^A0N,28,28^FH\^FD" & Me.oProductosMastronardi.NOMBRE_1 & "^FS")
            sw.WriteLine("^FT249,196^A0N,28,28^FH\^FD" & Me.oProductosMastronardi.NOMBRE_2 & "^FS")
            sw.WriteLine("^FT512,129^A0N,28,28^FH\^FD" & Me.txtRango.Text & "^FS")
            sw.WriteLine("^FT435,35^A0N,28,28^FH\^FDPRODUCT OF MEXICO^FS")
            sw.WriteLine("^FT165,359^A0N,28,28^FH\^FD(01)" & Me.txtCodigoArticulo.Text & "(10)" & sLote & "^FS")
            sw.WriteLine("^PQ1,0,1,Y^XZ")

            sw.Close()

            Me.ReadFile(sArchivo)

            GeneraEtiquetaMastronardi = True
        Catch ex As Exception
            HandleError(Me.Text, "GeneraArchivo", ex)
        End Try
    End Function

    Private Function GeneraEtiquetaLAND(ByVal sArchivo As String) As Boolean
        Dim oSQl As New Class_find("SELECT ALIAS_EXTRANJERO FROM CAT_CULTIVOS WHERE CODIGO_CULTIVO='" & Me.oProductosLand.CODIGO_CULTIVO & "' ")
        Dim sCultivo As String = oSQl.Result1
        Dim sLote As String
        sLote = "00" & DatePart(DateInterval.WeekOfYear, Me.dtFecha.Value, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) & "D" & Me.dtFecha.Value.DayOfWeek & "C" & oProductosLand.CODIGO_CULTIVO

        sLote = sLote.Substring(Len(sLote) - 7)

        If sLote.Length < 7 Then
            MsgBox("No se logró generar el lote para las etiquetas.", MsgBoxStyle.Exclamation, Me.Text)
            Exit Function
        End If

        Try
            Dim sw As New StreamWriter(sArchivo, False) ',  System.Text.Encoding.Unicode) 

            'sw.WriteLine("CT~~CD,~CC^~CT~")
            'sw.WriteLine("^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR4,4~SD15^JUS^LRN^CI0^XZ")
            'sw.WriteLine("^XA")
            'sw.WriteLine("^MMT")
            'sw.WriteLine("^PW631")
            'sw.WriteLine("^LL0707")
            'sw.WriteLine("^LS0")
            'sw.WriteLine("^BY3,2,166^FT188,618^BEN,,Y,N")
            'sw.WriteLine("^FD" & Me.oProductosLand.CODIGO_BARRAS & "^FS")
            'sw.WriteLine("^FT92,393^A0N,28,28^FH\^FD" & Me.oProductosLand.DESCRIPCION_EXTRANJERA_PARTE_1 & "^FS")
            'sw.WriteLine("^FT92,427^A0N,28,28^FH\^FD" & Me.oProductosLand.DESCRIPCION_EXTRANJERA_PARTE_2 & "^FS")
            'sw.WriteLine("^FT332,184^A0N,28,28^FH\^FDPRODUCTO DE MEXICO^FS")
            'sw.WriteLine("^FT332,146^A0N,28,28^FH\^FDPRODUCT OF MEXICO^FS")
            'sw.WriteLine("^FT473,275^A0N,28,28^FH\^FD" & Me.txtRango.Text & "^FS")
            'sw.WriteLine("^FT21,222^A0N,28,28^FH\^FD" & Empresa_Sistema.Nombre_empresa & "^FS")
            'sw.WriteLine("^PQ1,0,1,Y^XZ")

            'sw.WriteLine("CT~~CD,~CC^~CT~")
            'sw.WriteLine("^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR4,4~SD15^JUS^LRN^CI0^XZ")
            'sw.WriteLine("^XA")
            'sw.WriteLine("^MMT")
            'sw.WriteLine("^PW631")
            'sw.WriteLine("^LL0707")
            'sw.WriteLine("^LS0")
            'sw.WriteLine("^FT106,650^A0N,32,31^FH\^FD(01)" & Me.oProductosLand.CODIGO_BARRAS & "(10)" & sLote & "^FS")
            'sw.WriteLine("^BY2,3,160^FT83,611^BCN,,N,N")
            'sw.WriteLine("^FD>;>801" & Me.oProductosLand.CODIGO_BARRAS & "10>6" & sLote & "^FS")
            'sw.WriteLine("^FT48,393^A0N,28,28^FH\^FD" & Me.oProductosLand.DESCRIPCION_EXTRANJERA_PARTE_1 & "^FS")
            'sw.WriteLine("^FT48,427^A0N,28,28^FH\^FD" & Me.oProductosLand.DESCRIPCION_EXTRANJERA_PARTE_2 & "^FS")
            'sw.WriteLine("^FT332,184^A0N,28,28^FH\^FDPRODUCTO DE MEXICO^FS")
            'sw.WriteLine("^FT332,146^A0N,28,28^FH\^FDPRODUCT OF MEXICO^FS")
            'sw.WriteLine("^FT473,275^A0N,28,28^FH\^FD" & Me.txtRango.Text & "^FS")
            'sw.WriteLine("^FT21,222^A0N,28,28^FH\^FD" & Empresa_Sistema.Nombre_empresa & "^FS")
            'sw.WriteLine("^PQ1,0,1,Y^XZ")

            sw.WriteLine("CT~~CD,~CC^~CT~")
            sw.WriteLine("^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR4,4~SD15^JUS^LRN^CI0^XZ")
            sw.WriteLine("^XA")
            sw.WriteLine("^MMT")
            sw.WriteLine("^PW631")
            sw.WriteLine("^LL0607")
            sw.WriteLine("^LS0")
            sw.WriteLine("^FT106,563^A0N,32,31^FH\^FD(01)" & Me.oProductosLand.CODIGO_BARRAS & "(10)" & sLote & "^FS")
            sw.WriteLine("^BY2,3,160^FT83,526^BCN,,N,N")
            sw.WriteLine("^FD>;>801" & Me.oProductosLand.CODIGO_BARRAS & "10>6" & sLote & "^FS")
            sw.WriteLine("^FT48,307^A0N,28,28^FH\^FD" & sCultivo & "^FS")
            sw.WriteLine("^FT48,341^A0N,28,28^FH\^FD" & "" & "^FS")
            'sw.WriteLine("^FT48,307^A0N,28,28^FH\^FD" & Me.oProductosLand.DESCRIPCION_EXTRANJERA_PARTE_1 & "^FS")
            'sw.WriteLine("^FT48,341^A0N,28,28^FH\^FD" & Me.oProductosLand.DESCRIPCION_EXTRANJERA_PARTE_2 & "^FS")

            sw.WriteLine("^FT332,92^A0N,28,28^FH\^FDPRODUCTO DE MEXICO^FS")
            sw.WriteLine("^FT332,53^A0N,28,28^FH\^FDPRODUCT OF MEXICO^FS")
            sw.WriteLine("^FT473,189^A0N,28,28^FH\^FD" & Me.txtRango.Text & "^FS")
            sw.WriteLine("^FT21,129^A0N,28,28^FH\^FD" & Empresa_Sistema.Nombre_empresa & "^FS")
            sw.WriteLine("^PQ1,0,1,Y^XZ")

            sw.Close()

            Me.ReadFile(sArchivo)

            GeneraEtiquetaLAND = True
        Catch ex As Exception
            HandleError(Me.Text, "GeneraArchivo", ex)
        End Try
    End Function

    Private Sub ReadFile(ByVal sArchivo As String)
        Me.PrintDocument1.DocumentName = System.IO.Path.GetFileName(sArchivo)
        Dim stream As New FileStream(sArchivo, FileMode.Open)
        Try
            Dim reader As New StreamReader(stream)
            Try
                stringToPrint = reader.ReadToEnd()
            Finally
                reader.Dispose()
            End Try
        Finally
            stream.Dispose()
        End Try
    End Sub

    Private Function ImprimirEtiqueta2013() As Boolean
        Dim btAPP As BarTender.Application
        Dim btFormat As BarTender.Format
        Dim btMsgs As New BarTender.Messages
        Dim sLote As String = "", sFormatoEtiqueta As String = "", sVoicePicker1 As String = "", sVoicePicker2 As String = ""
        Dim sFechaEmpaque As String = Me.dtFecha.Value.ToString("MMMdd", CultureInfo.CreateSpecificCulture("en-US"))

        Try
            If txtLEN(Me.txtCodigoArticulo.Text) = False Then
                MsgBox("Asígne el producto.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            Me.oProductosLand = New Class_CatArticulos(Me.txtCodigoArticulo.Text)
            If Me.oProductosLand.Existe = False Then
                MsgBox("El producto asignado no existe.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            Me.lblArticulo.Text = Me.oProductosLand.DESCRIPCION

            If valorNumerico(Me.txtCantidad.Text) <= 0 Then
                MsgBox("Asígne la cantidad de etiquetas a imprimir.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            If txtLEN(Me.oProductosLand.CODIGO_BARRAS_PTI_14) = False Then
                MsgBox("El producto no tiene configurado un código de barras PTI.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            If InStr(Me.oProductosLand.CODIGO_BARRAS_PTI_14.ToUpper, "INVALIDO") > 0 Then
                MsgBox("El producto no tiene configurado un código de barras PTI válido.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            sFormatoEtiqueta = My.Settings.Ruta & "\Etiquetas\" & Me.oProductosLand.CODIGO_BARRAS_PTI_14 & ".btw"
            sLote = Class_Embarques_PTI.Lote(Me.dtFecha.Value)

            If IO.File.Exists(sFormatoEtiqueta) = False Then
                MsgBox("El archivo del formato no existe.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            If txtLEN(sLote) = False Then
                MsgBox("No se encontró el lote de la fecha indicada.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            sVoicePicker1 = Class_Embarques_PTI.VoicePicker1(Me.oProductosLand.CODIGO_BARRAS_PTI_14, sLote, Me.dtFecha.Value)
            sVoicePicker2 = Class_Embarques_PTI.VoicePicker2(Me.oProductosLand.CODIGO_BARRAS_PTI_14, sLote, Me.dtFecha.Value)

            If txtLEN(sVoicePicker1) = False Then
                MsgBox("No se logró generar la 1era parte del voice picker.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            If txtLEN(sVoicePicker1) = False Then
                MsgBox("No se logró generar la 2da parte del voice picker.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            btAPP = New BarTender.Application
            'btFormat = btAPP.Formats.Open(sFormatoEtiqueta, False, "Bar Code Printer T-0612")
            btFormat = btAPP.Formats.Open(sFormatoEtiqueta, False, Me.cboImpresora.Text)

            btFormat.SetNamedSubStringValue("objLote", sLote)
            btFormat.SetNamedSubStringValue("objVoicePicker1", sVoicePicker1)
            btFormat.SetNamedSubStringValue("objVoicePicker2", "  " & sVoicePicker2) 'Se agrega primero un espacio doble
            btFormat.SetNamedSubStringValue("objFechaEmpaque", sFechaEmpaque)

            For i As Integer = 1 To btFormat.NamedSubStrings.Count
                If btFormat.NamedSubStrings.Item(CObj(i)).Name = "objMalla" Then 'Con esta validación se revisa si la equeta tiene el objecto indicado
                    btFormat.SetNamedSubStringValue("objMalla", Me.txtMalla.Text)
                End If
            Next
            'MsgBox(btFormat.Objects.Item(1).Name)

            'btFormat.SetNamedSubStringValue("objGTIN", "1750226371003")
            'btFormat.SetNamedSubStringValue("objNombreProducto", "Coke tomatoes")
            'btFormat.SetNamedSubStringValue("objPiezasPesoGrado", "66 / 27pds / 1")
            'btFormat.SetNamedSubStringValue("objPais", "República de los Cocos")
            'btFormat.SetNamedSubStringValue("objProductor", "González Inc")

            'Debug.Print(btFormat.NamedSubStrings.Count.ToString)
            btFormat.PrintSetup.IdenticalCopiesOfLabel = CShort(Me.txtCantidad.Text)
            btFormat.Print("Job1", True, -1, btMsgs)
            btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
            btAPP.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(btAPP)


            'Para la version full
            'dim btMs As Seagull.BarTender.Print.Messages
            'btFormat = btAPP.Formats.Open("C:\_Documentacion\Info codigo barras\_prueba.btw", False, "Bar Code Printer T-0612")
            'btFormat.SetNamedSubStringValue("txt2", "Coke Cucumbers")
            'Try
            '    Dim btEngine As New Seagull.BarTender.Print.Engine(True)
            '    Dim labelFormat As Seagull.BarTender.Print.LabelFormatDocument = btEngine.Documents.Open("C:\_Documentacion\Info codigo barras\_prueba.btw", "Bar Code Printer T-0612")
            '    labelFormat.SubStrings("barras2").Value = "1750226371003"
            '    labelFormat.SubStrings("barras4").Value = "milote"
            '    labelFormat.SubStrings("txt2").Value = "CokemanS Cucumbers"
            '    labelFormat.Print("Job1", -1, btMs)
            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try

        Catch ex As Exception
            HandleError(Me.Text, "ImprimirEtiqueta2013", ex)
        End Try
    End Function
#End Region

End Class