Option Strict On

Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Imports System.Data
Imports System.Data.SqlClient

Public Class Frm_Embarques_Etiquetas_Palets

#Region "Campos"
#Region "Campos generales"
    Private _FolioEmbarque As String = ""
    Private stringToPrint As String = ""
#End Region

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
#End Region
#End Region

#Region "Propiedades"
    Public WriteOnly Property FolioEmbarque() As String
        Set(ByVal Value As String)
            Me._FolioEmbarque = Value
        End Set
    End Property
#End Region

#Region "Opciones"
    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.GestionaImprimir()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos de objetos"
    Private Sub Frm_Embarques_Etiquetas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion

        Me.CargaImpresoras()
    End Sub

    Private Sub cboImpresora_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboImpresora.SelectedIndexChanged
        My.Settings.ImpresoraEtiquetas = Me.cboImpresora.Text
        My.Settings.Save()
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

#Region "Eventos Genéricos"
    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub GestionaImprimir()
        Dim cmd As New SqlCommand("SELECT P.FOLIO_PALET,P.CODIGO_ARTICULO,DBO.FN_EMB_OBTIENE_LOTE(G.FECHA,P.CODIGO_ARTICULO) LOTE " & _
                                  "FROM EMB_PALETS_DETALLE P INNER JOIN EMB_EMBARQUE_DETALLE E ON(P.FOLIO_PALET=E.FOLIO_PALET)" & _
                                  "INNER JOIN EMB_PALETS_GLOBAL G ON(P.FOLIO_PALET=G.FOLIO_PALET)" & _
                                  "WHERE E.FOLIO_EMBARQUE='" & sReplace(Me._FolioEmbarque) & "' ORDER BY P.ID_EMB_PALETS_DETALLE ", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.HasRows = True Then
                    While dReader.Read() = True
                        If Me.GeneraEtiqueta(dReader("FOLIO_PALET").ToString, dReader("CODIGO_ARTICULO").ToString, dReader("LOTE").ToString) = True Then
                            Me.Imprimir()
                        Else
                            MsgBox("La etiqueta del palet: " & dReader("FOLIO_PALET").ToString & " no se logró imprimir. Se continuará con la siguiente." & vbCrLf & _
                                   "Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, Me.Text)
                        End If
                    End While
                End If
 
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Name, "GestionaImprimir", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
    End Sub

    Private Sub Imprimir()
        Me.PrintDocument1.PrinterSettings.Copies = 1
        Me.PrintDocument1.PrinterSettings.PrinterName = Me.cboImpresora.Text
        Me.PrintDocument1.Print()
    End Sub

    Private Function GeneraEtiqueta(ByVal sFolioPalet As String, ByVal sCodigoArticulo As String, ByVal sLote As String) As Boolean
        Dim sArchivo As String = My.Settings.Ruta & "\etiqueta_palet.prn"
        Dim oProducto As New Class_CatArticulos(sCodigoArticulo)

        If sLote.Length < 7 Then
            MsgBox("No se logró generar el lote para la etiqueta del palet.", MsgBoxStyle.Exclamation, Me.Text)
            Exit Function
        End If

        Try
            Dim sw As New StreamWriter(sArchivo, False) ',  System.Text.Encoding.Unicode) 

            sw.WriteLine("CT~~CD,~CC^~CT~")
            sw.WriteLine("^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR4,4~SD15^JUS^LRN^CI0^XZ")
            sw.WriteLine("^XA")
            sw.WriteLine("^MMT")
            sw.WriteLine("^PW631")
            sw.WriteLine("^LL0607")
            sw.WriteLine("^LS0")
            sw.WriteLine("^FT165,407^A0N,28,28^FH\^FD" & oProducto.DESCRIPCION_EXTRANJERA_PARTE_1 & "^FS")
            sw.WriteLine("^FT165,441^A0N,28,28^FH\^FD" & oProducto.DESCRIPCION_EXTRANJERA_PARTE_2 & "^FS")
            sw.WriteLine("^FT332,92^A0N,28,28^FH\^FDPRODUCTO DE MEXICO^FS")
            sw.WriteLine("^FT23,408^A0N,28,28^FH\^FDPRODUCT :^FS")
            sw.WriteLine("^FT332,53^A0N,28,28^FH\^FDPRODUCT OF MEXICO^FS")
            sw.WriteLine("^FT21,57^A0N,28,28^FH\^FDPALLET^FS")
            sw.WriteLine("^FT123,58^A0N,28,28^FH\^FD" & sFolioPalet & "^FS")
            sw.WriteLine("^FT21,141^A0N,28,28^FH\^FD" & Empresa_Sistema.Nombre_empresa & "^FS")
            sw.WriteLine("^FO13,102^GB605,0,3^FS")
            sw.WriteLine("^FO13,349^GB605,0,3^FS")
            sw.WriteLine("^FO315,1^GB0,103,3^FS")
            sw.WriteLine("^BY2,3,160^FT105,330^BCN,,Y,N")
            sw.WriteLine("^FD>:" & "PLT" & ">5" & sFolioPalet & ">6-" & sLote & "^FS")
            sw.WriteLine("^PQ1,0,1,Y^XZ")

            'sw.WriteLine("CT~~CD,~CC^~CT~")
            'sw.WriteLine("^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR4,4~SD15^JUS^LRN^CI0^XZ")
            'sw.WriteLine("^XA")
            'sw.WriteLine("^MMT")
            'sw.WriteLine("^PW631")
            'sw.WriteLine("^LL0607")
            'sw.WriteLine("^LS0")
            'sw.WriteLine("^FT106,563^A0N,32,31^FH\^FD(01)" & Me.oProductosLand.CODIGO_BARRAS & "(10)" & sLote & "^FS")
            'sw.WriteLine("^BY2,3,160^FT83,526^BCN,,N,N")
            'sw.WriteLine("^FD>;>801" & Me.oProductosLand.CODIGO_BARRAS & "10>6" & sLote & "^FS")
            'sw.WriteLine("^FT48,307^A0N,28,28^FH\^FD" & Me.oProductosLand.DESCRIPCION_EXTRANJERA_PARTE_1 & "^FS")
            'sw.WriteLine("^FT48,341^A0N,28,28^FH\^FD" & Me.oProductosLand.DESCRIPCION_EXTRANJERA_PARTE_2 & "^FS")
            'sw.WriteLine("^FT332,92^A0N,28,28^FH\^FDPRODUCTO DE MEXICO^FS")
            'sw.WriteLine("^FT332,53^A0N,28,28^FH\^FDPRODUCT OF MEXICO^FS")
            'sw.WriteLine("^FT473,189^A0N,28,28^FH\^FD" & Me.txtRango.Text & "^FS")
            'sw.WriteLine("^FT21,129^A0N,28,28^FH\^FD" & Empresa_Sistema.Nombre_empresa & "^FS")
            'sw.WriteLine("^PQ1,0,1,Y^XZ")

            sw.Close()

            Me.ReadFile(sArchivo)

            GeneraEtiqueta = True
        Catch ex As Exception
            HandleError(Me.Text, "GeneraEtiqueta", ex)
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
#End Region

End Class