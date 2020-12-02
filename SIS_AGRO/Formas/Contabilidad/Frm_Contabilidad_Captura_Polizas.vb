Option Strict On

Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports CFDIXML

Public Class Frm_Contabilidad_Captura_Polizas

#Region "Campos privados grid"
    Private _ChildParaGrabar As Boolean
    Private _FolioPolizaConsultaExterior As String = ""
    Private _CodigoDocumentoParaGrabarLlamadoExterior As String
    Private _CodigoDocumentoProveedorParaGrabarLlamadoExterior As String
    Private _FormaValidaParaGrabarLlamadoExterior As Boolean = False
    Private _EsAcreedor As Boolean = False
    Private _ImporteAcreedor As Double
    Private _RecalcularImporte As Boolean = False
    Private _CuentaBancaria As Integer

    Private Enum enumEstados
        NUEVO
        GRABADO
        APLICADO
        CANCELADO
        CONTRAPOLIZA
    End Enum

    Private Estado As enumEstados
    Private oPoliza As New Class_Contabilidad_Poliza_Global
#End Region

#Region "Columnas grid"
    Private iGyCUENTA_CONTABLE_PESOS As Integer = 1
    Private iGyNombreCuenta As Integer = 2
    Private iGyConcepto As Integer = 3
    Private iGyNaturaleza As Integer = 4
    Private iGyCargo As Integer = 5
    Private iGyAbono As Integer = 6
    Private iGyCodigoCentroCosto As Integer = 7
    Private iGyNombreCentroCosto As Integer = 8
    Private iGyCodigoCategoria As Integer = 9
    Private iGyNombreCategoria As Integer = 10
    Private iGyCodigoConcepto As Integer = 11
    Private iGyNombreConcepto As Integer = 12
#End Region

#Region "Columnas grid xmls"
    Private iGyGridXMLTipoComprobante As Integer = 1
    Private iGyGridXMLNombrePDF As Integer = 2
    Private iGyGridXMLFecha As Integer = 3
    Private iGyGridXMLFolio As Integer = 4
    Private iGyGridXMLUUID As Integer = 5
    Private iGyGridXMLEmisorRFC As Integer = 6
    Private iGyGridXMLEmisorNombre As Integer = 7
    Private iGyGridXMLSubtotal As Integer = 8
    Private iGyGridXMLImpuestosTrasladados As Integer = 9
    Private iGyGridXMLImpuestosRetenidos As Integer = 10
    Private iGyGridXMLTotal As Integer = 11
    Private iGyGridXMLMoneda As Integer = 12
    Private iGyGridXMLRutaXML As Integer = 13
    Private iGyGridXMLRutaPDF As Integer = 14
#End Region

#Region "Propiedades"
    Public WriteOnly Property ChildParaGrabar() As Boolean
        Set(ByVal Value As Boolean)
            Me._ChildParaGrabar = Value
        End Set
    End Property

    Public WriteOnly Property FolioPolizaConsultaExterior() As String
        Set(ByVal Value As String)
            Me._FolioPolizaConsultaExterior = Value
        End Set
    End Property

    Public WriteOnly Property CodigoDocumentoParaGrabar() As String
        Set(ByVal Value As String)
            Me._CodigoDocumentoParaGrabarLlamadoExterior = Value
        End Set
    End Property

    Public WriteOnly Property CodigoDocumentoProveedorParaGrabar() As String
        Set(ByVal Value As String)
            Me._CodigoDocumentoProveedorParaGrabarLlamadoExterior = Value
        End Set
    End Property

    Public ReadOnly Property FormaValidaParaGrabarLlamadoExterior() As Boolean
        Get
            Return Me._FormaValidaParaGrabarLlamadoExterior
        End Get
    End Property

    Public WriteOnly Property EsAcreedor() As Boolean
        Set(ByVal Value As Boolean)
            Me._EsAcreedor = Value
        End Set
    End Property

    Public Property ImporteAcreedor() As Double
        Get
            Return Me._ImporteAcreedor
        End Get
        Set(ByVal value As Double)
            Me._ImporteAcreedor = value
        End Set
    End Property

    Public WriteOnly Property CuentaBancaria() As Integer
        Set(ByVal value As Integer)
            Me._CuentaBancaria = value
        End Set
    End Property

    Public ReadOnly Property RecalcularImporte() As Boolean
        Get
            Return Me._RecalcularImporte
        End Get
    End Property

#End Region

#Region "Constructor y destructor"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        'Termina de crear Grid
        ' Add any initialization after the InitializeComponent() call.
        'No se puede llamar a me.inicaliza porque aun no estan definidos los documentos del combo y generará error, pero estos se ponen para no tener por fuera que crearle rows y cols(en caso de llamarse por fuera)
        Me.InicializaGrid()
        Me.InicializaGridXML()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Me.Grabar(CBool(IIf(Me._ChildParaGrabar = True, False, True))) = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbValidarGrabadoLlamadoExterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbValidarGrabadoLlamadoExterior.Click
        If Me.Validar(CBool(IIf(Me._ChildParaGrabar = True, False, True))) = False Then
            Exit Sub
        End If

        If Me._ChildParaGrabar = True Then
            Me._FormaValidaParaGrabarLlamadoExterior = True
            Me.Visible = False
            Exit Sub
        End If
    End Sub

    Private Sub tsbAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAplicar.Click
        If Me.Aplicar() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbDesaplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDesaplicar.Click
        If Me.Desaplicar() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
        If Me.Cancelar() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbReactivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbReactivar.Click
        If Me.Reactivar() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbRecalcularImporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRecalcularImporte.Click
        'If Me._ImporteAcreedor <> valorNumerico(Me.TxtTotalCargos.Text) Then
        'If MsgBox("Desea actualizar el importe del cheque por el total de la póliza de " & Me.TxtTotalAbonos.Text & " ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
        '    Exit Sub
        'End If
        Me.SumaAbonosBancos()
        'Me._ImporteAcreedor = valorNumerico(Me.TxtTotalAbonos.Text)
        ' End If
    End Sub

    Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub btnNombreCompleto_Click(sender As Object, e As EventArgs) Handles btnNombreCompleto.Click
        Me.NombreCompleto()
    End Sub

    Private Sub btnDocumentoAnterior_Click(sender As Object, e As EventArgs) Handles btnDocumentoAnterior.Click
        Me.Navegador("Anterior")
    End Sub

    Private Sub btnDocumentoSiguiente_Click(sender As Object, e As EventArgs) Handles btnDocumentoSiguiente.Click
        Me.Navegador("Siguiente")
    End Sub

    Private Sub btnAgregarXML_Click(sender As Object, e As EventArgs) Handles btnAgregarXML.Click
        Me.AgregarXML()
    End Sub

    Private Sub btnAgregarPDF_Click(sender As Object, e As EventArgs) Handles btnAgregarPDF.Click
        Me.AgregarPDF()
    End Sub

    Private Sub btnVerXML_Click(sender As Object, e As EventArgs) Handles btnVerXML.Click
        Me.VerXML()
    End Sub

    Private Sub btnVerPDF_Click(sender As Object, e As EventArgs) Handles btnVerPDF.Click
        Me.VerPDF()
    End Sub

    Private Sub btnEliminarXML_Click(sender As Object, e As EventArgs) Handles btnEliminarXML.Click
        Me.EliminarXML()
    End Sub
#End Region

#Region "Eventos de objetos"

#Region "Eventos"
    Private Sub Frm_Contabilidad_Captura_Polizas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Me._ChildParaGrabar = True Then
                Me.InicializaChild()
                Dim i As Integer
                'InicializaGrid()
                For i = 1 To Me.Grid1.Rows - 1
                    If txtLEN(Me.Grid1.Cell(i, Me.iGyNombreCuenta).Text) = True Then
                        Dim sql As New Class_find("SELECT DBO.FN_CONTABILIDAD_NOMBRE_CUENTA_NIVELES_COMPLETOS(CUENTA_CONTABLE) NOMBRE_CUENTA,NATURALEZA_CONTABLE,ESMAYOR " &
                                                  "FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & Me.Grid1.Cell(i, Me.iGyCUENTA_CONTABLE_PESOS).Text & "'")
                        If sql.Result1 <> "" Then
                            Me.Grid1.Cell(i, Me.iGyNombreCuenta).Text = sql.Result1
                            Me.Grid1.Cell(i, Me.iGyNaturaleza).Text = sql.Result2
                        End If
                        sql = Nothing
                    End If
                Next i
                Me.FormateaGrid()
                Me.Totales()
                Me.Grid1.Focus()
            Else
                Me.DesplegarTipoDocumento()
                Me.DesplegarDocumentosProveedor()
                Me.CmbDocumento.SelectedValue = "D"
                Me.Inicializa()
                Me.Cambia_Estado(enumEstados.NUEVO)
                If Me._FolioPolizaConsultaExterior.Length > 0 Then
                    Me.TxtFolio.Text = Me._FolioPolizaConsultaExterior
                    Me.Consultar()
                    If Me.oPoliza.CODIGO_TIPO_DOCUMENTO = "E" Then
                        'Me.gpbFacturasRecibidas.Visible = True
                        Me.CboFacturasRecibidas.SelectedValue = Me.oPoliza.CODIGO_LISTA_FACTURAS_RECIBIDAS
                        'Me.gpbFacturasRecibidas.Enabled = False
                    End If
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, "Frm_Contabilidad_Captura_Polizas_Load", ex)
        End Try
    End Sub

    Private Sub CmbDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbDocumento.SelectedIndexChanged
        Me.GeneraFolio()
        If Me.CmbDocumento.SelectedValue.ToString = "E" Then
            Me.gpbFacturasRecibidas.Visible = True
            Me.CboFacturasRecibidas.SelectedValue = "N"
        Else
            Me.gpbFacturasRecibidas.Visible = False
        End If
    End Sub

    Private Sub CboFacturasRecibidas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboFacturasRecibidas.SelectedIndexChanged
        If Me.CmbDocumento.SelectedValue.ToString = "E" Then
            If Me.GrabarFacturasRecibidas() = True Then
                MsgBox("Se ha modificado las facturas recibidas satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            End If
        End If
    End Sub

    Private Sub TxtFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFolio.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
                Dim Busqueda = New Frm_Contabilidad_Busqueda_Polizas("FOLIO_POLIZA AS POLIZA,CONCEPTO1 AS CONCEPTO,FECHA,ESTATUS_POLIZA AS ESTATUS", "CON_POLIZAS_GLOBAL", "", "Poliza", "Fecha,Folio_poliza")
                Busqueda.ShowDialog()
                Me.TxtFolio.Text = "" & Busqueda.Tag.ToString
                Busqueda.Dispose()
            Case Keys.Return
                If txtLEN(Me.TxtFolio.Text) = True Then
                    Me.Consultar()
                    'Dim sql As New Class_find("SELECT FOLIO_POLIZA FROM CON_POLIZAS_GLOBAL WHERE FOLIO_POLIZA='" & Me.TxtFolio.Text & "' ")
                    'If sql.Result1 = "" Then
                    '    Me.GeneraFolio()
                    '    Me.TxtFolio.Enabled = False
                    'Else
                    '    Me.Consultar()
                    'End If
                    'sql = Nothing
                Else
                    Me.GeneraFolio()
                End If
        End Select
    End Sub

    Private Sub txtImportarPoliza_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtImportarPoliza.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                If txtLEN(Me.txtImportarPoliza.Text) = True Then
                    Me.ImportarPoliza()
                End If
        End Select
    End Sub

    Private Sub TxtFolio_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFolio.Validated
        If Len(Me.TxtFolio.Text) > 0 Then
            Dim sql As New Class_find("Select FOLIO_POLIZA From CON_POLIZAS_GLOBAL Where FOLIO_POLIZA='" & Me.TxtFolio.Text & "' ")
            If sql.Result1 = "" Then
                Me.GeneraFolio()
                Me.TxtFolio.Enabled = False
                'Else
                '    Me.Consultar()
            End If
            sql = Nothing
        End If
    End Sub

    Private Sub LnkContrapoliza_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkContrapoliza.LinkClicked
        Dim Child As New Frm_Contabilidad_Captura_Polizas()
        Child.FolioPolizaConsultaExterior = Me.LnkContrapoliza.Text
        Child.ShowDialog()
        Child.Dispose()
    End Sub

    Private Sub TxtConcepto2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtConcepto2.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Grid1.Cell(1, Me.iGyCUENTA_CONTABLE_PESOS).SetFocus()
            Case Keys.Escape
                Me.TxtConcepto1.Focus()
        End Select
        Me.TxtConcepto2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    End Sub

    Private Sub Grid1_CellChange(ByVal Sender As Object, ByVal e As FlexCell.Grid.CellChangeEventArgs) Handles Grid1.CellChange
        If Me.Grid1.ActiveCell.Col = Me.iGyCargo Then
            Me.Grid1.Cell(Me.Grid1.ActiveCell.Row, Me.iGyAbono).Text = "0"
            Totales()
        ElseIf Me.Grid1.ActiveCell.Col = Me.iGyAbono Then
            Me.Grid1.Cell(Me.Grid1.ActiveCell.Row, Me.iGyCargo).Text = "0"
            Totales()
        End If
    End Sub

    Private Sub Grid1_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid1.KeyDown
        Me.GestionaGrid(e)
    End Sub

    Private Sub MoverSeleccionados()
        'Dim Columna As Integer, Renglon As Integer
        'Dim StrCod As String, i As Integer
        'Dim iRow As Integer
        'Dim iCol As Integer

        'Columna = 1 'Grid1.Selection.FirstCol
        'Renglon = 1 'Grid1.Selection.FirstRow
        ''StrCod = Grid1.Cell(Renglon, Me.iGyCUENTA_CONTABLE_PESOS).Text

        'For i = 1 To Me.Grid1.Rows - 1
        '    If Len(Me.Grid1.Cell(i, Me.iGyCUENTA_CONTABLE_PESOS).Text) > 0 Then
        '        If valorNumerico(Me.Grid1.Cell(i, Me.iGyAbono).Text) = 0 And valorNumerico(Me.Grid1.Cell(i, Me.iGyCargo).Text) = 0 Then
        '            MsgBox("Falta introducir un importe en el renglón: " & i & ".", MsgBoxStyle.Exclamation, "Validación de Cuentas Contables")
        '            Me.Grid1.Cell(i, Me.iGyAbono).SetFocus()
        '            Exit Sub
        '        End If
        '    End If
        'Next i


        'Me.Grid1.Rows = Me.Grid1.Rows + 1
        'iRow = Me.Grid1.Rows - 2
        'For i = 1 To Me.Grid1.Rows - 1 - Renglon
        '    For iCol = 1 To Grid1.Cols - 1
        '        Me.Grid1.Cell(iRow + 1, iCol).Text = Me.Grid1.Cell(iRow, iCol).Text
        '        If iRow = Renglon Then
        '            Me.Grid1.Cell(iRow, iCol).Text = "" 'Make the current row empty 
        '        End If
        '    Next
        '    iRow = iRow - 1
        'Next
    End Sub

    Private Sub DtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFecha.VisibleChanged
        If Me.DtpFecha.Value > Now And Me._ChildParaGrabar = False And txtLEN(Me._FolioPolizaConsultaExterior) = False Then
            Me.DtpFecha.Value = Now
        End If
    End Sub

    Private Sub chkDetallarGastos_CheckedChanged(sender As Object, e As EventArgs) Handles chkDetallarGastos.CheckedChanged
        Me.Grid1.Column(Me.iGyNombreCentroCosto).Visible = Me.chkDetallarGastos.Checked
        Me.Grid1.Column(Me.iGyNombreCategoria).Visible = Me.chkDetallarGastos.Checked
        Me.Grid1.Column(Me.iGyNombreConcepto).Visible = Me.chkDetallarGastos.Checked

        If Me.chkDetallarGastos.Checked = True Then
            Me.Grid1.Column(Me.iGyNombreCuenta).Width = 200
            Me.Grid1.Column(Me.iGyConcepto).Width = 100
        Else 'Valores originales
            Me.Grid1.Column(Me.iGyNombreCuenta).Width = 400
            Me.Grid1.Column(Me.iGyConcepto).Width = 200
        End If
    End Sub
#End Region

#Region "Eventos Genericos"

    Private Sub txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFolio.Enter, TxtConcepto1.Enter, TxtConcepto2.Enter
        Dim oTexBox As TextBox = CType(sender, TextBox)
        oTexBox.SelectAll()
    End Sub

    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpFecha.KeyDown, TxtConcepto1.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
        Me.TxtConcepto1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    End Sub

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbDocumento.KeyPress, DtpFecha.KeyPress, TxtFolio.KeyPress, TxtConcepto1.KeyPress, TxtConcepto2.KeyPress
        txtNoBeep(e)
    End Sub

#End Region

#End Region

#Region "Métodos y procedimientos"
    Private Function GrabarFacturasRecibidas() As Boolean
        Dim bResultado As Boolean = False
        Try
            If txtLEN(Me.oPoliza.CODIGO_LISTA_FACTURAS_RECIBIDAS) = False Then
                If txtLEN(Me._CodigoDocumentoProveedorParaGrabarLlamadoExterior) = True Then
                    Me.CboFacturasRecibidas.SelectedValue = Me._CodigoDocumentoProveedorParaGrabarLlamadoExterior
                Else
                    Me.CboFacturasRecibidas.SelectedValue = "N"
                End If
            End If

            If Me.oPoliza.CODIGO_LISTA_FACTURAS_RECIBIDAS <> Me.CboFacturasRecibidas.SelectedValue.ToString And Me.Estado = enumEstados.APLICADO Then ' And txtLEN(Me._FolioPolizaConsultaExterior) = True
                Me.oPoliza.CODIGO_LISTA_FACTURAS_RECIBIDAS = Me.CboFacturasRecibidas.SelectedValue.ToString
                If Me.oPoliza.AsignaFacturasPoliza() = True Then
                    bResultado = True
                End If
            End If

        Catch ex As Exception
            HandleError(Me.Name, "GrabarFacturasRecibidas", ex)
        End Try

        Return bResultado
    End Function

    Private Sub DesplegarTipoDocumento()
        Try
            Dim oElementos As New Class_SisTiposDocumentos
            With Me.CmbDocumento  'Strings.Left(Me.CmbDocumento.Text, 1)
                .DisplayMember = "NOMBRE_TIPO_DOCUMENTO"
                .ValueMember = "CODIGO_TIPO_DOCUMENTO"

                Dim dView As New Data.DataView(oElementos.ObtenerTiposDocumentosContabilida)
                dView.Sort = "NOMBRE_TIPO_DOCUMENTO"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarTipoDocumento", ex)
        End Try
    End Sub

    Private Sub DesplegarDocumentosProveedor()
        Try
            Dim oElementos As New Class_Contabilidad_ListaFacturasRecibidas
            With Me.CboFacturasRecibidas
                .DisplayMember = "NOMBRE_LISTA_FACTURAS_RECIBIDAS"
                .ValueMember = "CODIGO_LISTA_FACTURAS_RECIBIDAS"
                Dim dView As New Data.DataView(oElementos.ListaFacturasRecibidas())
                dView.Sort = "NOMBRE_LISTA_FACTURAS_RECIBIDAS"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarDocumentosProveedor", ex)
        End Try
    End Sub

    Private Sub Inicializa()
        Try
            Me.TxtFolio.Text = ""
            'Me.TxtFolio.Enabled = True
            Me.DtpFecha.Value = Now
            Me.TxtConcepto1.Text = ""
            Me.TxtConcepto2.Text = ""
            Me.LblCodigoEstatus.Text = "N"
            Me.lblEstatus.Text = "Nueva"
            Me.lblFolioOrigen.Text = ""
            Me.TxtTotalCargos.Text = "0.00"
            Me.TxtTotalAbonos.Text = "0.00"
            Me.txtTotalDiferenciaCargosAbonos.Text = "0.00"
            Me.txtImportarPoliza.Text = ""

            Me.txtXMLsSubtotal.Text = ""
            Me.txtXMLsImpuestosTrasladados.Text = ""
            Me.txtXMLsImpuestosRetenidos.Text = ""
            Me.txtXMLsTotal.Text = ""
            Me.chkDetallarGastos.Checked = False
            'Me.CboFacturasRecibidas.SelectedValue = "N"

            Me.InicializaGrid()

            Me.oPoliza = New Class_Contabilidad_Poliza_Global

            Me.InicializaGridXML()

            Me.GeneraFolio()

            Me.TabControl1.SelectedIndex = 0
        Catch ex As Exception
            HandleError(Me.Text, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Try
            Me.Grid1.DataSource = Nothing
            FG_Grid_Limpiar(Grid1)

            'Creamos el Grid
            Me.Grid1.Rows = 2
            Me.Grid1.Cols = 13
            Me.Grid1.DisplayRowNumber = True

            Me.FormateaGrid()
        Catch ex As Exception
            HandleError(Me.Text, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub NombreCompleto()
        If InStr(Me.btnNombreCompleto.Text, ">>") > 0 Then
            Me.btnNombreCompleto.Text = Me.btnNombreCompleto.Text.Replace(">>", "<<")
            Me.Grid1.Column(Me.iGyNombreCuenta).Width = 600
        Else
            Me.btnNombreCompleto.Text = Me.btnNombreCompleto.Text.Replace("<<", ">>")
            Me.Grid1.Column(Me.iGyNombreCuenta).Width = 430
        End If
    End Sub

    Private Sub FormateaGrid()
        Try
            With Me.Grid1
                .AutoRedraw = False

                'Dim X As New Drawing.Font("Tahoma", 7.0, FontStyle.Regular)
                '.Cell(1, Me.iGyNombreCuenta).Font = X
                .AllowUserResizing = FlexCell.ResizeEnum.Columns
                .Column(0).Width = 25
                .Column(Me.iGyCUENTA_CONTABLE_PESOS).Width = 105
                .Column(Me.iGyNombreCuenta).Width = 400 'Relacionado tambien con NombreCompleto, porque se aumenta el len se
                .Column(Me.iGyConcepto).Width = 200
                .Column(Me.iGyNaturaleza).Width = 15
                .Column(Me.iGyCargo).Width = 80
                .Column(Me.iGyAbono).Width = 80
                .Column(Me.iGyCodigoCentroCosto).Visible = False
                .Column(Me.iGyNombreCentroCosto).Width = 130 : .Column(Me.iGyNombreCentroCosto).Visible = False
                .Column(Me.iGyCodigoCategoria).Visible = False
                .Column(Me.iGyNombreCategoria).Width = 130 : .Column(Me.iGyNombreCategoria).Visible = False
                .Column(Me.iGyCodigoConcepto).Visible = False
                .Column(Me.iGyNombreConcepto).Width = 150 : .Column(Me.iGyNombreConcepto).Visible = False

                .Cell(0, Me.iGyCUENTA_CONTABLE_PESOS).Text = "Cuenta"
                .Cell(0, Me.iGyNombreCuenta).Text = "Nombre"
                .Cell(0, Me.iGyConcepto).Text = "Concepto"
                .Cell(0, Me.iGyNaturaleza).Text = "N"
                .Cell(0, Me.iGyCargo).Text = "Cargo"
                .Cell(0, Me.iGyAbono).Text = "Abono"
                .Cell(0, Me.iGyCodigoCentroCosto).Text = "CCos"
                .Cell(0, Me.iGyNombreCentroCosto).Text = "C.costo"
                .Cell(0, Me.iGyCodigoCategoria).Text = "CCat"
                .Cell(0, Me.iGyNombreCategoria).Text = "Categoria"
                .Cell(0, Me.iGyCodigoConcepto).Text = "CCon"
                .Cell(0, Me.iGyNombreConcepto).Text = "Concepto"

                .Column(Me.iGyCargo).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyCargo).DecimalLength = 2
                .Column(Me.iGyCargo).Alignment = FlexCell.AlignmentEnum.RightCenter
                .Column(Me.iGyAbono).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyAbono).DecimalLength = 2
                .Column(Me.iGyAbono).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyNombreCuenta).Locked = True
                .Column(Me.iGyNaturaleza).Locked = True

                'No las podemos lockear porque si no el f6 no va funcionar, de modo que si va dejar editar aunque de todas ese dato no se graba, se graban los códigos que sólo se ingresan con f6
                '.Column(Me.iGyNombreCentroCosto).Locked = True
                '.Column(Me.iGyNombreCategoria).Locked = True
                '.Column(Me.iGyNombreConcepto).Locked = True

                .Column(Me.iGyConcepto).MaxLength = 80

            End With

            Me.FormateaColoresGrid()

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        Finally
            Me.Grid1.AutoRedraw = True
            Me.Grid1.Refresh()
        End Try
    End Sub

    Private Sub FormateaColoresGrid()
        Try
            Dim i As Integer, k As Integer, sCuenta As String = ""
            Dim bcColor1 As Color = Color.White
            Dim oCuenta As New Class_CatCuentas

            If txtLEN(sCuenta) = False And Me.Grid1.Rows - 1 = 1 Then
                oCuenta = New Class_CatCuentas(Me.Grid1.Cell(i, Me.iGyCUENTA_CONTABLE_PESOS).Text)
                If oCuenta.CODIGO_PLAZA <> Plaza.CODIGO_PLAZA Or oCuenta.CODIGO_PLAZA <> 0 Then
                    For k = 1 To Me.Grid1.Cols - 1
                        Me.Grid1.Cell(1, k).BackColor = Color.White
                    Next
                End If
            Else
                For i = 1 To Me.Grid1.Rows - 1
                    If txtLEN(sCuenta) = False Then
                        Me.Grid1.Cell(i, k).BackColor = Color.White
                    Else
                        oCuenta = New Class_CatCuentas(Me.Grid1.Cell(i, Me.iGyCUENTA_CONTABLE_PESOS).Text)
                        If oCuenta.CODIGO_PLAZA <> Plaza.CODIGO_PLAZA Or oCuenta.CODIGO_PLAZA <> 0 Then
                            For k = 1 To Me.Grid1.Cols - 1
                                Me.Grid1.Cell(i, k).BackColor = Color.OrangeRed
                            Next
                        Else
                            For k = 1 To Me.Grid1.Cols - 1
                                Me.Grid1.Cell(i, k).BackColor = Color.White
                            Next
                        End If
                    End If
                Next i
            End If

        Catch ex As Exception
            HandleError(Me.Name, "FormateaColoresGrid", ex)
        End Try
    End Sub

    Private Function Validar(Optional ByVal bValidarPermisoUsuario As Boolean = True) As Boolean
        Dim bResultado As Boolean = False
        Try
            If Me._ChildParaGrabar = True Then
                Me.Totales()
                If Me.TxtTotalCargos.Text <> Me.TxtTotalAbonos.Text Then
                    MsgBox("Las pólizas no cuadra, debe cuadrar para poderse grabar.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                End If
                'Me.SumaAbonosBancos()
                'If Me._ImporteAcreedor <> valorNumerico(Me.TxtTotalCargos.Text) Then
                '    If MsgBox("Desea actualizar el importe del cheque por el total de la póliza de " & Me.TxtTotalAbonos.Text & " ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                '        Me._ImporteAcreedor = valorNumerico(Me.TxtTotalAbonos.Text)
                '    End If
                'End If
            Else
                If bValidarPermisoUsuario = True Then
                    If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.CmbDocumento.SelectedValue.ToString & Usuario.Codigo_Plaza) = False Then
                        MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
                        Exit Function
                    End If
                End If
            End If

            If Me.ValidaCuentasContables = False Then
                Exit Function
            End If

            Select Case Me.LblCodigoEstatus.Text
                Case "N" 'No hay restricciones
                    If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
                        Exit Function
                    End If
                Case "G"
                    If txtLEN(Me.lblFolioOrigen.Text) = True Then
                        Me.oPoliza = New Class_Contabilidad_Poliza_Global
                        Me.oPoliza = New Class_Contabilidad_Poliza_Global(Me.TxtFolio.Text)
                        If Me.oPoliza.CODIGO_PLAZA = Usuario.Codigo_Plaza Then
                            If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
                                Exit Function
                            End If
                        Else
                            MsgBox("La póliza es de otra plaza, no puede modificarse.", MsgBoxStyle.Exclamation, Me.Text)
                            Exit Function
                        End If
                    Else
                        If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
                            Exit Function
                        End If
                    End If
                Case "A"
                    MsgBox("Las pólizas aplicadas no pueden modificarse.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                Case "C"
                    MsgBox("Las pólizas canceladas no pueden modificarse.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
            End Select

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, "Validar", ex)
        End Try

        Return bResultado
    End Function

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Const sProcedure As String = "GestionaGrid"
        Try
            Dim Columna As Integer, Renglon As Integer
            Dim StrCod As String
            Dim sql As Class_find
            Dim oCentroCosto As New Class_CatCentroCostos, oCategoria As Class_CatCategorias, oConcepto As Class_CatConceptos
            Dim sCodigo As String = ""

            Columna = Me.Grid1.Selection.FirstCol
            Renglon = Me.Grid1.Selection.FirstRow
            StrCod = Me.Grid1.Cell(Renglon, Me.iGyCUENTA_CONTABLE_PESOS).Text

            If Me.Grid1.Column(Columna).Locked = True Then
                Return 'Celda bloqueada no acepta eventos
            End If

            Select Case e.KeyCode
                Case Keys.Tab, Keys.Return
                    Select Case Columna
                        Case Me.iGyCUENTA_CONTABLE_PESOS 'Columna Cuenta Contable
                            sql = New Class_find("SELECT NOMBRE_CUENTA,NATURALEZA_CONTABLE,CODIGO_PLAZA,DBO.FN_CONTABILIDAD_NOMBRE_CUENTA_NIVELES_COMPLETOS(CUENTA_CONTABLE) FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & StrCod & "'")
                            If sql.Result1 = "" Then
                                MsgBox("La cuenta contable no existe, favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de Cuentas Contables")
                                Me.Grid1.Cell(Renglon, Me.iGyCUENTA_CONTABLE_PESOS).Text = ""
                                Me.Grid1.Cell(Renglon, 0).SetFocus()
                                Return
                            Else
                                If Renglon = 1 Then
                                    Me.Grid1.Cell(Renglon, Me.iGyConcepto).Text = Me.TxtConcepto1.Text
                                Else
                                    Me.Grid1.Cell(Renglon, Me.iGyConcepto).Text = Me.Grid1.Cell(Renglon - 1, Me.iGyConcepto).Text
                                End If
                                Me.Grid1.Cell(Renglon, Me.iGyNombreCuenta).Text = sql.Result4
                                Me.Grid1.Cell(Renglon, Me.iGyNaturaleza).Text = sql.Result2

                                If sql.Result3 <> Plaza.CODIGO_PLAZA.ToString Then
                                    Me.Grid1.Cell(Renglon, Me.iGyCUENTA_CONTABLE_PESOS).BackColor = Color.OrangeRed
                                    Me.Grid1.Cell(Renglon, Me.iGyNombreCuenta).BackColor = Color.OrangeRed
                                    Me.Grid1.Cell(Renglon, Me.iGyConcepto).BackColor = Color.OrangeRed
                                    Me.Grid1.Cell(Renglon, Me.iGyNaturaleza).BackColor = Color.OrangeRed
                                    Me.Grid1.Cell(Renglon, Me.iGyCargo).BackColor = Color.OrangeRed
                                    Me.Grid1.Cell(Renglon, Me.iGyAbono).BackColor = Color.OrangeRed
                                    'Me.Grid1.Cell(Renglon, Me.iGyCodigoCentroCosto).BackColor = Color.OrangeRed
                                    'Me.Grid1.Cell(Renglon, Me.iGyNombreCentroCosto).BackColor = Color.OrangeRed
                                Else
                                    Me.Grid1.Cell(Renglon, Me.iGyCUENTA_CONTABLE_PESOS).BackColor = Color.White
                                    Me.Grid1.Cell(Renglon, Me.iGyNombreCuenta).BackColor = Color.White
                                    Me.Grid1.Cell(Renglon, Me.iGyConcepto).BackColor = Color.White
                                    Me.Grid1.Cell(Renglon, Me.iGyNaturaleza).BackColor = Color.White
                                    Me.Grid1.Cell(Renglon, Me.iGyCargo).BackColor = Color.White
                                    Me.Grid1.Cell(Renglon, Me.iGyAbono).BackColor = Color.White
                                    'Me.Grid1.Cell(Renglon, Me.iGyCodigoCentroCosto).BackColor = Color.White
                                    'Me.Grid1.Cell(Renglon, Me.iGyNombreCentroCosto).BackColor = Color.White
                                End If
                            End If

                        Case Me.iGyCargo, Me.iGyAbono
                            sql = New Class_find("SELECT ESMAYOR FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & StrCod & "' ")
                            If sql.Result1 = "1" Or sql.Result1.ToString = "" Then
                                MsgBox("La cuenta contable es una cuenta madre y no acepta cargos o abonos.", MsgBoxStyle.Exclamation, "Validación de Cuentas Contables")
                                Me.Grid1.Cell(Renglon, Me.iGyCUENTA_CONTABLE_PESOS).Text = "" '4
                                Me.Grid1.Cell(Renglon, Me.iGyNombreCuenta).Text = ""
                                Me.Grid1.Cell(Renglon, Me.iGyConcepto).Text = ""
                                Me.Grid1.Cell(Renglon, Me.iGyNaturaleza).Text = ""
                                Me.Grid1.Cell(Renglon, Me.iGyCargo).Text = ""
                                Me.Grid1.Cell(Renglon, Me.iGyAbono).Text = ""
                                'Me.Grid1.Cell(Renglon, Me.iGyCodigoCentroCosto).Text = ""
                                'Me.Grid1.Cell(Renglon, Me.iGyNombreCentroCosto).Text = ""
                                Me.Grid1.Cell(Renglon, 0).SetFocus()
                                Return
                            End If

                            'Case Me.iGyCodigoCentroCosto

                            '    If Microsoft.VisualBasic.Left(Me.Grid1.Cell(Renglon, Me.iGyCUENTA_CONTABLE_PESOS).Text, 1) = "5" Then
                            '        'If txtLEN(Me.Grid1.Cell(Renglon, Columna).Text) = False Or Me.Grid1.Cell(Renglon, Me.iGyCodigoCentroCosto).Text = "0" Then
                            '        If txtLEN(Me.Grid1.Cell(Renglon, Columna).Text) = False Then
                            '            GoTo busca_centro_costo
                            '            Return
                            '        End If
                            '    End If

                            '    If txtLEN(Me.Grid1.Cell(Renglon, Columna).Text) = True Then

                            '        oCentroCosto = New Class_CatCentroCostos(CInt(valorNumerico(Me.Grid1.Cell(Renglon, Columna).Text)))

                            '        If oCentroCosto.EXISTE = True Then
                            '            Me.Grid1.Cell(Renglon, Me.iGyCodigoCentroCosto).Text = oCentroCosto.CODIGO_CENTRO_COSTO.ToString
                            '            Me.Grid1.Cell(Renglon, Me.iGyNombreCentroCosto).Text = oCentroCosto.NOMBRE_CENTRO_COSTO
                            '        Else
                            '            Me.Grid1.Cell(Renglon, Me.iGyCodigoCentroCosto).Text = ""
                            '            Me.Grid1.Cell(Renglon, Me.iGyNombreCentroCosto).Text = ""
                            '            GoTo busca_centro_costo
                            '            Return
                            '        End If

                            '    End If

                        Case Me.iGyNombreCentroCosto
                            If txtLEN(Me.Grid1.Cell(Renglon, Columna).Text) = False Then
                                GoTo busca_centro_costo
                                Return
                            End If

                            oCentroCosto = New Class_CatCentroCostos(CInt(Me.Grid1.Cell(Renglon, Me.iGyCodigoCentroCosto).Text))
                            If oCentroCosto.EXISTE = True Then
                                Me.Grid1.Cell(Renglon, Me.iGyCodigoCentroCosto).Text = oCentroCosto.CODIGO_CENTRO_COSTO.ToString
                                Me.Grid1.Cell(Renglon, Me.iGyNombreCentroCosto).Text = oCentroCosto.NOMBRE_CENTRO_COSTO
                            Else
                                Me.Grid1.Cell(Renglon, Me.iGyCodigoCentroCosto).Text = ""
                                Me.Grid1.Cell(Renglon, Me.iGyNombreCentroCosto).Text = ""
                                GoTo busca_centro_costo
                                Return
                            End If

                        Case Me.iGyNombreCategoria
                            If txtLEN(Me.Grid1.Cell(Renglon, Columna).Text) = False Then
                                GoTo busca_categoria
                                Return
                            End If

                            oCategoria = New Class_CatCategorias(Me.Grid1.Cell(Renglon, Me.iGyCodigoCategoria).Text)
                            If oCategoria.Existe = True Then
                                Me.Grid1.Cell(Renglon, Me.iGyCodigoCategoria).Text = oCategoria.CODIGO_CATEGORIA
                                Me.Grid1.Cell(Renglon, Me.iGyNombreCategoria).Text = oCategoria.NOMBRE_CATEGORIA
                            Else
                                Me.Grid1.Cell(Renglon, Me.iGyCodigoCategoria).Text = ""
                                Me.Grid1.Cell(Renglon, Me.iGyNombreCategoria).Text = ""
                                GoTo busca_categoria
                                Return
                            End If

                        Case Me.iGyNombreConcepto
                            If txtLEN(Me.Grid1.Cell(Renglon, Columna).Text) = False Then
                                GoTo busca_concepto
                                Return
                            End If

                            oConcepto = New Class_CatConceptos(Me.Grid1.Cell(Renglon, Me.iGyCodigoConcepto).Text)
                            If oConcepto.Existe = True Then
                                Me.Grid1.Cell(Renglon, Me.iGyCodigoConcepto).Text = oConcepto.Codigo_Concepto
                                Me.Grid1.Cell(Renglon, Me.iGyNombreConcepto).Text = oConcepto.Nombre_Concepto
                            Else
                                Me.Grid1.Cell(Renglon, Me.iGyCodigoConcepto).Text = ""
                                Me.Grid1.Cell(Renglon, Me.iGyNombreConcepto).Text = ""
                                GoTo busca_concepto
                                Return
                            End If

                    End Select

                    sql = Nothing

                    If Me.Grid1.Rows = Renglon + 1 And Me.Grid1.Cell(Renglon, Me.iGyCargo).Locked = False Then
                        Me.Grid1.Rows = Me.Grid1.Rows + 1
                    End If

                    Select Case Columna
                        Case Me.iGyNombreCuenta
                            Me.Grid1.Cell(Renglon, Me.iGyConcepto).SetFocus()
                            'Case Me.iGyCodigoCentroCosto
                            '    Me.Grid1.Cell(Renglon + 1, 0).SetFocus()
                        Case Else
                            Me.Grid1.Cell(Renglon, Columna).SetFocus()
                    End Select

                Case Keys.F6
                    If Not (Me.Estado = enumEstados.NUEVO Or Me.Estado = enumEstados.GRABADO) Then
                        Return
                    End If

                    Select Case Columna
                        Case Me.iGyCUENTA_CONTABLE_PESOS  'Columna de cuenta contable
                            Dim oId As New Class_CatCuentas
                            Dim sIdCodigo As String = oId.BusquedaVisual_PorCodigoFiltrandoTipoOperacion()
                            If sIdCodigo.Length > 0 Then
                                Me.Grid1.Cell(Renglon, Me.iGyCUENTA_CONTABLE_PESOS).Text = sIdCodigo
                                sIdCodigo = Replace(sIdCodigo, "'", "''")
                                sql = New Class_find("SELECT NOMBRE_CUENTA,NATURALEZA_CONTABLE,CODIGO_PLAZA,DBO.FN_CONTABILIDAD_NOMBRE_CUENTA_NIVELES_COMPLETOS(CUENTA_CONTABLE) FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & sIdCodigo & "'")
                                If Renglon = 1 Then
                                    Me.Grid1.Cell(Renglon, Me.iGyConcepto).Text = Me.TxtConcepto1.Text
                                Else
                                    Me.Grid1.Cell(Renglon, Me.iGyConcepto).Text = Me.Grid1.Cell(Renglon - 1, Me.iGyConcepto).Text
                                End If
                                Me.Grid1.Cell(Renglon, Me.iGyNombreCuenta).Text = sql.Result4
                                Me.Grid1.Cell(Renglon, Me.iGyNaturaleza).Text = sql.Result2

                                If sql.Result3 <> Plaza.CODIGO_PLAZA.ToString Then
                                    Me.Grid1.Cell(Renglon, Me.iGyCUENTA_CONTABLE_PESOS).BackColor = Color.OrangeRed
                                    Me.Grid1.Cell(Renglon, Me.iGyNombreCuenta).BackColor = Color.OrangeRed
                                    Me.Grid1.Cell(Renglon, Me.iGyConcepto).BackColor = Color.OrangeRed
                                    Me.Grid1.Cell(Renglon, Me.iGyNaturaleza).BackColor = Color.OrangeRed
                                    Me.Grid1.Cell(Renglon, Me.iGyCargo).BackColor = Color.OrangeRed
                                    Me.Grid1.Cell(Renglon, Me.iGyAbono).BackColor = Color.OrangeRed
                                    'Me.Grid1.Cell(Renglon, Me.iGyCodigoCentroCosto).BackColor = Color.OrangeRed
                                    'Me.Grid1.Cell(Renglon, Me.iGyNombreCentroCosto).BackColor = Color.OrangeRed
                                Else
                                    Me.Grid1.Cell(Renglon, Me.iGyCUENTA_CONTABLE_PESOS).BackColor = Color.White
                                    Me.Grid1.Cell(Renglon, Me.iGyNombreCuenta).BackColor = Color.White
                                    Me.Grid1.Cell(Renglon, Me.iGyConcepto).BackColor = Color.White
                                    Me.Grid1.Cell(Renglon, Me.iGyNaturaleza).BackColor = Color.White
                                    Me.Grid1.Cell(Renglon, Me.iGyCargo).BackColor = Color.White
                                    Me.Grid1.Cell(Renglon, Me.iGyAbono).BackColor = Color.White
                                    'Me.Grid1.Cell(Renglon, Me.iGyCodigoCentroCosto).BackColor = Color.White
                                    'Me.Grid1.Cell(Renglon, Me.iGyNombreCentroCosto).BackColor = Color.White
                                End If
                                sql = Nothing
                            End If

                            '                        Case Me.iGyCodigoCentroCosto
                            'busca_centro_costo:
                            '                            oCentroCosto = New Class_CatCentroCostos
                            '                            Dim sCodigoCentroCosto As String = oCentroCosto.BusquedaVisual_PorDescripcion

                            '                            If txtLEN(sCodigoCentroCosto) = True Then
                            '                                oCentroCosto = New Class_CatCentroCostos(CInt(sCodigoCentroCosto))
                            '                                Me.Grid1.Cell(Renglon, Me.iGyCodigoCentroCosto).Text = oCentroCosto.CODIGO_CENTRO_COSTO.ToString
                            '                                Me.Grid1.Cell(Renglon, Me.iGyNombreCentroCosto).Text = oCentroCosto.NOMBRE_CENTRO_COSTO
                            '                            Else
                            '                                If Microsoft.VisualBasic.Left(Me.Grid1.Cell(Renglon, Me.iGyCUENTA_CONTABLE_PESOS).Text, 1) = "5" Then
                            '                                    GoTo busca_centro_costo
                            '                                    Return
                            '                                End If
                            '                            End If
                        Case Me.iGyNombreCentroCosto
busca_centro_costo:
                            If Me.Grid1.Cell(Renglon, Me.iGyCUENTA_CONTABLE_PESOS).Text.StartsWith("5") Then
                                oCentroCosto = New Class_CatCentroCostos
                                sCodigo = oCentroCosto.BusquedaVisual_PorDescripcion
                                If txtLEN(sCodigo) = True Then
                                    oCentroCosto = New Class_CatCentroCostos(CInt(sCodigo))
                                    Me.Grid1.Cell(Renglon, Me.iGyCodigoCentroCosto).Text = oCentroCosto.CODIGO_CENTRO_COSTO.ToString
                                    Me.Grid1.Cell(Renglon, Me.iGyNombreCentroCosto).Text = oCentroCosto.NOMBRE_CENTRO_COSTO
                                End If
                            Else
                                MsgBox("Sólo a las cuentas de gastos 5x se les puede detallar el centro de costo, categoria y concepto.", MsgBoxStyle.Exclamation, sProcedure)
                            End If

                        Case Me.iGyNombreCategoria
busca_categoria:
                            If Me.Grid1.Cell(Renglon, Me.iGyCUENTA_CONTABLE_PESOS).Text.StartsWith("5") Then
                                oCategoria = New Class_CatCategorias
                                sCodigo = oCategoria.BusquedaVisual_PorDescripcion

                                If txtLEN(sCodigo) = True Then
                                    oCategoria = New Class_CatCategorias(sCodigo)
                                    Me.Grid1.Cell(Renglon, Me.iGyCodigoCategoria).Text = oCategoria.CODIGO_CATEGORIA.ToString
                                    Me.Grid1.Cell(Renglon, Me.iGyNombreCategoria).Text = oCategoria.NOMBRE_CATEGORIA
                                End If
                            Else
                                MsgBox("Sólo a las cuentas de gastos 5x se les puede detallar el centro de costo, categoria y concepto.", MsgBoxStyle.Exclamation, sProcedure)
                            End If

                        Case Me.iGyNombreConcepto
busca_concepto:
                            If Me.Grid1.Cell(Renglon, Me.iGyCUENTA_CONTABLE_PESOS).Text.StartsWith("5") Then
                                oConcepto = New Class_CatConceptos
                                sCodigo = oConcepto.BusquedaVisual_PorDescripcion

                                If txtLEN(sCodigo) = True Then
                                    oConcepto = New Class_CatConceptos(sCodigo)
                                    Me.Grid1.Cell(Renglon, Me.iGyCodigoConcepto).Text = oConcepto.Codigo_Concepto.ToString
                                    Me.Grid1.Cell(Renglon, Me.iGyNombreConcepto).Text = oConcepto.Nombre_Concepto
                                End If
                            Else
                                MsgBox("Sólo a las cuentas de gastos 5x se les puede detallar el centro de costo, categoria y concepto.", MsgBoxStyle.Exclamation, sProcedure)
                            End If

                    End Select

                Case Keys.F7
                    If (Me.Estado = enumEstados.NUEVO Or Me.Estado = enumEstados.GRABADO) And Columna = Me.iGyCUENTA_CONTABLE_PESOS Then 'Columna de cuenta contable
                        Dim oId As New Class_CatCuentas
                        Dim sIdCodigo As String = oId.BusquedaVisual_PorNombreFiltrandoTipoOperacion()
                        If sIdCodigo.Length > 0 Then
                            Me.Grid1.Cell(Renglon, Me.iGyCUENTA_CONTABLE_PESOS).Text = sIdCodigo
                            sIdCodigo = Replace(sIdCodigo, "'", "''")
                            sql = New Class_find("SELECT CUENTA_CONTABLE,NATURALEZA_CONTABLE,CODIGO_PLAZA FROM CON_CAT_CUENTAS WHERE NOMBRE_CUENTA='" & sIdCodigo & "'")
                            If Renglon = 1 Then
                                Me.Grid1.Cell(Renglon, Me.iGyConcepto).Text = Me.TxtConcepto1.Text
                            Else

                                Me.Grid1.Cell(Renglon, Me.iGyConcepto).Text = Me.Grid1.Cell(Renglon - 1, Me.iGyConcepto).Text
                            End If
                            Me.Grid1.Cell(Renglon, Me.iGyNombreCuenta).Text = sql.Result1
                            Me.Grid1.Cell(Renglon, Me.iGyNaturaleza).Text = sql.Result2
                            If sql.Result3 <> Plaza.CODIGO_PLAZA.ToString Then
                                Me.Grid1.Cell(Renglon, Me.iGyCUENTA_CONTABLE_PESOS).BackColor = Color.OrangeRed
                                Me.Grid1.Cell(Renglon, Me.iGyNombreCuenta).BackColor = Color.OrangeRed
                                Me.Grid1.Cell(Renglon, Me.iGyConcepto).BackColor = Color.OrangeRed
                                Me.Grid1.Cell(Renglon, Me.iGyNaturaleza).BackColor = Color.OrangeRed
                                Me.Grid1.Cell(Renglon, Me.iGyCargo).BackColor = Color.OrangeRed
                                Me.Grid1.Cell(Renglon, Me.iGyAbono).BackColor = Color.OrangeRed
                                'Me.Grid1.Cell(Renglon, Me.iGyCodigoCentroCosto).BackColor = Color.OrangeRed
                                'Me.Grid1.Cell(Renglon, Me.iGyNombreCentroCosto).BackColor = Color.OrangeRed
                            Else
                                Me.Grid1.Cell(Renglon, Me.iGyCUENTA_CONTABLE_PESOS).BackColor = Color.White
                                Me.Grid1.Cell(Renglon, Me.iGyNombreCuenta).BackColor = Color.White
                                Me.Grid1.Cell(Renglon, Me.iGyConcepto).BackColor = Color.White
                                Me.Grid1.Cell(Renglon, Me.iGyNaturaleza).BackColor = Color.White
                                Me.Grid1.Cell(Renglon, Me.iGyCargo).BackColor = Color.White
                                Me.Grid1.Cell(Renglon, Me.iGyAbono).BackColor = Color.White
                                'Me.Grid1.Cell(Renglon, Me.iGyCodigoCentroCosto).BackColor = Color.White
                                'Me.Grid1.Cell(Renglon, Me.iGyNombreCentroCosto).BackColor = Color.White
                            End If
                            sql = Nothing
                        End If
                    End If

                Case Keys.F8
                    If (Me.Estado = enumEstados.NUEVO Or Me.Estado = enumEstados.GRABADO) Then
                        Me.Grid1.Selection.DeleteByRow()
                    End If

                Case Keys.Insert
                    If (Me.Estado = enumEstados.NUEVO Or Me.Estado = enumEstados.GRABADO) And Columna = Me.iGyCUENTA_CONTABLE_PESOS Then 'Columna de cuenta contable
                        Dim iRow As Integer
                        Dim iCol As Integer

                        Me.Grid1.Rows = Me.Grid1.Rows + 1

                        Dim i As Integer
                        iRow = Me.Grid1.Rows - 2
                        For i = 1 To Me.Grid1.Rows - 1 - Renglon
                            For iCol = 1 To Grid1.Cols - 1
                                Me.Grid1.Cell(iRow + 1, iCol).Text = Me.Grid1.Cell(iRow, iCol).Text
                                If iRow = Renglon Then
                                    Me.Grid1.Cell(iRow, iCol).Text = "" 'Make the current row empty 
                                End If
                            Next
                            iRow = iRow - 1
                        Next
                    End If

            End Select

            Me.Totales()

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrid", ex)
        End Try
    End Sub

    Private Function Grabar(Optional ByVal bConfirmacion As Boolean = True) As Boolean
        Const sProcedure As String = "Grabar"
        Dim bResultado As Boolean = False
        Dim i As Integer

        If bConfirmacion = True Then
            If MsgBox("Desea grabar la póliza de " & Me.CmbDocumento.Text & " ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, sProcedure) = MsgBoxResult.No Then
                Return False
            End If
        End If

        Try
            If Me.Validar(CBool(IIf(Me._ChildParaGrabar = True, False, True))) = False Then
                Return False
            End If

            If Me.ValidaCuentasContablesOrden() = False Then
                Return False
            End If

            Me.Totales()

            Select Case Me.Estado
                Case enumEstados.NUEVO, enumEstados.GRABADO
                    If Me.Estado = enumEstados.NUEVO Then
                        Me.oPoliza = New Class_Contabilidad_Poliza_Global
                        'Else
                        '   Me.oPoliza = New Class_Contabilidad_Global_Polizas(Me.TxtFolio.Text)
                    End If

                    With Me.oPoliza
                        .FOLIO_POLIZA = Me.TxtFolio.Text
                        .CODIGO_PLAZA = Usuario.Codigo_Plaza
                        .CODIGO_USUARIO_GRABO = Usuario.Codigo_Usuario
                        .CODIGO_TIPO_DOCUMENTO = Me.CmbDocumento.SelectedValue.ToString
                        .FECHA = Me.DtpFecha.Value
                        .CONCEPTO1 = Me.TxtConcepto1.Text
                        .CONCEPTO2 = Me.TxtConcepto2.Text
                        .CARGO = CType(Me.TxtTotalCargos.Text, Double)
                        .ABONO = CType(Me.TxtTotalAbonos.Text, Double)
                        .FOLIO_ORIGEN = "" & Me.lblFolioOrigen.Text
                        .TIPO_CONTABILIDAD = "NM"
                        .TIENE_DETALLE_GASTOS = Me.chkDetallarGastos.Checked

                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                Me.GeneraFolio()
                                .FOLIO_POLIZA = Me.TxtFolio.Text
                                bResultado = .Grabar("INSERTAR", CBool(IIf(Me._ChildParaGrabar = True, False, True)))
                                Me.TxtFolio.Text = Me.oPoliza.FOLIO_POLIZA
                            Case enumEstados.GRABADO
                                bResultado = .Grabar("ACTUALIZAR", False)
                        End Select

                        If bResultado = False Then
                            MsgBox("Se abortó el proceso de grabar los renglones por fallo al grabar el global.", MsgBoxStyle.Exclamation, Me.Name)
                            Return False
                        End If

                        For i = 1 To Me.Grid1.Rows - 1
                            If Me.Grid1.Cell(i, Me.iGyCUENTA_CONTABLE_PESOS).Text <> "" Then
                                '.InicializaDetalle()
                                .oPolizaDetalle.FOLIO_POLIZA = Me.oPoliza.FOLIO_POLIZA
                                .oPolizaDetalle.CUENTA_CONTABLE = "" & Me.Grid1.Cell(i, Me.iGyCUENTA_CONTABLE_PESOS).Text
                                .oPolizaDetalle.CARGO = valorNumerico(Me.Grid1.Cell(i, Me.iGyCargo).Text)
                                .oPolizaDetalle.ABONO = valorNumerico(Me.Grid1.Cell(i, Me.iGyAbono).Text)
                                .oPolizaDetalle.CONCEPTO = "" & Me.Grid1.Cell(i, Me.iGyConcepto).Text

                                If Me.chkDetallarGastos.Checked = True Then
                                    .oPolizaDetalle.CODIGO_CENTRO_COSTO = CInt("0" & Me.Grid1.Cell(i, Me.iGyCodigoCentroCosto).Text)
                                    .oPolizaDetalle.CODIGO_CATEGORIA = CInt("0" & Me.Grid1.Cell(i, Me.iGyCodigoCategoria).Text)
                                    .oPolizaDetalle.CODIGO_CONCEPTO = CInt("0" & Me.Grid1.Cell(i, Me.iGyCodigoConcepto).Text)
                                End If

                                .oPolizaDetalle.GrabaDetallePoliza()
                            End If
                        Next i

                        'Grabar xmls y pdfs(elimando primero ya relación si es un docto que ya existe.
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Me.Estado = enumEstados.GRABADO Then 'Si ya la póliza ya existe
                            Me.oPoliza.EliminarRelacionTodosXMLs()  'Elimina las relaciones con sus xml para su posterior insercción.
                        End If

                        For i = 1 To Me.GridXMLs.Rows - 1
                            Dim sUUID As String = "", sRutaXML As String = "", sRutaPDF As String = ""

                            sUUID = Me.GridXMLs.Cell(i, Me.iGyGridXMLUUID).Text
                            sRutaXML = Me.GridXMLs.Cell(i, Me.iGyGridXMLRutaXML).Text
                            sRutaPDF = Me.GridXMLs.Cell(i, Me.iGyGridXMLRutaPDF).Text

                            If (txtLEN(sRutaXML) = True) And (txtLEN(sRutaPDF) = True) Then
                                Me.oPoliza.AgregarXMLPDF(sRutaXML, sRutaPDF)
                            ElseIf txtLEN(sRutaPDF) = True Then
                                Me.oPoliza.AgregarPDF(sUUID, sRutaPDF)
                            ElseIf txtLEN(sRutaXML) = True Then
                                Me.oPoliza.AgregarXMLPDF(sRutaXML, "")
                            End If
                        Next
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        bResultado = True

                        If bConfirmacion = True And bResultado = True Then
                            MsgBox("Póliza " & Me.TxtFolio.Text & " grabada satisfactoriamente. ", MsgBoxStyle.Information, sProcedure)
                        End If

                        'If bChildParaGrabar = True Then
                        '    Me.Tag = "SI"
                        '    '.Aplicar()
                        '    Me.Close()
                        '    return false
                        'End If

                    End With
            End Select

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Public Function Aplicar(Optional ByVal bConfirmacion As Boolean = True, Optional ByVal bValidarEstatus As Boolean = True) As Boolean
        Const sProcedure As String = "Aplicar"
        Dim bResultado As Boolean = False
        Try
            'Dim sContraPoliza As String
            If bConfirmacion = True Then
                If MsgBox("Desea aplicar la póliza " & Me.TxtFolio.Text & " ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, sProcedure) = MsgBoxResult.No Then
                    Return False
                End If
            End If

            If Me.Grabar(False) = False Then
                Return False
            End If

            If Me.TxtTotalCargos.Text <> Me.TxtTotalAbonos.Text Then
                MsgBox("La póliza que desea aplicar no cuadra.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If bValidarEstatus = True Then
                Select Case Me.LblCodigoEstatus.Text
                    Case "N"
                        MsgBox("La póliza no existe.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    Case "G"
                        'No hay restricciones
                        If txtLEN(Me.oPoliza.FOLIO_CONTRAPOLIZA) = True Then
                            MsgBox("Las pólizas con contrapólizas no pueden aplicarse, pueden en cambio cancelarse.", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        End If
                        'If txtLEN(Me.oPoliza.FOLIO_CONTRAPOLIZA) = True Then
                        '    If MsgBox("La póliza tiene una contrapoliza desea aplicar ambas polizas. " & Me.TxtFolio.Text & " y " & Me.oPoliza.FOLIO_CONTRAPOLIZA.ToString & " ?", vbYesNo Or vbQuestion, sProcedure) = MsgBoxResult.No Then
                        '        return false
                        '    End If
                        '    sContraPoliza = Me.oPoliza.FOLIO_CONTRAPOLIZA.ToString
                        '    Me.oPoliza = New Class_Contabilidad_Poliza_Global(sContraPoliza)
                        '    Me.oPoliza.Aplicar()
                        'End If
                        If txtLEN(Me.lblFolioOrigen.Text) = True Then
                            Me.oPoliza = New Class_Contabilidad_Poliza_Global(Me.TxtFolio.Text)
                            If Me.oPoliza.CODIGO_PLAZA = Usuario.Codigo_Plaza Then
                                If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
                                    Return False
                                End If
                            Else
                                MsgBox("La póliza es de otra plaza, no puede modificarse.", MsgBoxStyle.Exclamation, sProcedure)
                                Return False
                            End If
                        Else
                            If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
                                Return False
                            End If
                        End If
                    Case "A"
                        MsgBox("La pólizas aplicadas no se pueden aplicar de nuevo.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    Case "C"
                        MsgBox("La pólizas canceladas no se pueden aplicar.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                End Select
            End If

            Me.oPoliza = New Class_Contabilidad_Poliza_Global(Me.TxtFolio.Text)
            bResultado = Me.oPoliza.Aplicar()

            If bResultado = True Then
                If bConfirmacion = True Then
                    MsgBox("Póliza " & Me.TxtFolio.Text & " aplicada satisfactoriamente.", MsgBoxStyle.Information, sProcedure)
                End If
                If Me.oPoliza.ConsiderarParaControlIVAAcreditable = True Then
                    Me.GestionaIVAAcreditable()
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function Desaplicar() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim sContraPoliza As String = ""

            If MsgBox("Desea desaplicar la póliza " & Me.TxtFolio.Text & " ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                Exit Function
            End If

            If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.CmbDocumento.SelectedValue.ToString & Usuario.Codigo_Plaza) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            'If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
            '    Exit Function
            'End If

            Select Case Me.LblCodigoEstatus.Text
                Case "N"
                    MsgBox("La póliza no existe.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                Case "G"
                    MsgBox("La pólizas grabadas no pueden desaplicarse.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                Case "A"
                    'No hay restricciones
                    If txtLEN(Me.lblFolioOrigen.Text) = True Then
                        If Me.oPoliza.CODIGO_PLAZA = Usuario.Codigo_Plaza Then
                            If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
                                Exit Function
                            End If
                        Else
                            MsgBox("La póliza es de otra plaza, no puede modificarse.", MsgBoxStyle.Exclamation, Me.Text)
                            Exit Function
                        End If
                    Else
                        If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
                            Exit Function
                        End If
                    End If

                    If txtLEN(Me.oPoliza.FOLIO_CONTRAPOLIZA) = True Then
                        MsgBox("Las pólizas con contrapólizas no pueden desaplicarse, pueden en cambio cancelarse.", MsgBoxStyle.Exclamation, Me.Text)
                        Return False

                        '26oct16, se eliminó la posibilidad de desaplicar pólizas con contras porque luego podian reactivar la original y quedar incongruente.
                        'If MsgBox("La póliza tiene una contrapóliza desea desaplicar ambas pólizas. " & Me.TxtFolio.Text & " y " & Me.oPoliza.FOLIO_CONTRAPOLIZA.ToString & " ?", vbYesNo Or vbQuestion, Me.Text) = MsgBoxResult.No Then
                        '    Exit Function
                        'End If
                        'sContraPoliza = Me.oPoliza.FOLIO_CONTRAPOLIZA.ToString
                        'Me.oPoliza = New Class_Contabilidad_Poliza_Global(sContraPoliza)
                        'Me.oPoliza.Desaplicar()
                    End If
                Case "C"
                    MsgBox("La pólizas canceladas no pueden desaplicarse.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
            End Select

            Me.oPoliza = New Class_Contabilidad_Poliza_Global(Me.TxtFolio.Text)
            bResultado = Me.oPoliza.Desaplicar()

            If bResultado = True Then
                MsgBox("Póliza " & Me.TxtFolio.Text & " desaplicada satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            End If
        Catch ex As Exception
            HandleError(Me.Name, "Desaplicar", ex)
        End Try

        Return bResultado
    End Function

    Private Function Cancelar() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim sFolio As String = Me.TxtFolio.Text
            Me.oPoliza = New Class_Contabilidad_Poliza_Global(sFolio)

            If MsgBox("Desea cancelar la póliza " & Me.TxtFolio.Text & " ?", vbYesNo Or vbQuestion, Me.Text) = MsgBoxResult.No Then
                Return False
            End If

            If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.CmbDocumento.SelectedValue.ToString & Usuario.Codigo_Plaza) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
                Return False
            End If

            'If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
            '    Exit Function
            'End If

            Select Case Me.LblCodigoEstatus.Text
                Case "N"
                    MsgBox("La póliza no existe.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False

                Case "G"
                    'No hay restricciones
                    If txtLEN(Me.lblFolioOrigen.Text) = True Then
                        If Me.oPoliza.CODIGO_PLAZA = Usuario.Codigo_Plaza Then
                            If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
                                Return False
                            End If
                        Else
                            MsgBox("La póliza es de otra plaza, no puede modificarse.", MsgBoxStyle.Exclamation, Me.Text)
                            Return False
                        End If
                    Else
                        If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
                            Return False
                        End If
                    End If

                    If txtLEN(Me.oPoliza.FOLIO_CONTRAPOLIZA) = True Then
                        If MsgBox("La póliza tiene una contrapóliza, desea cancelar ambas pólizas. " & Me.TxtFolio.Text & " y " & Me.oPoliza.FOLIO_CONTRAPOLIZA.ToString & " ?", vbYesNo Or vbQuestion, Me.Text) = MsgBoxResult.No Then
                            Return False
                        End If
                        Me.oPoliza.FECHA = Me.DtpFecha.Value
                        bResultado = Me.oPoliza.GestionaCancelar()
                    Else 'Poliza directa
                        Me.oPoliza.FECHA = Me.DtpFecha.Value
                        bResultado = Me.oPoliza.Cancelar()
                    End If

                Case "A"

                    If txtLEN(Me.lblFolioOrigen.Text) = True Then
                        If Me.oPoliza.CODIGO_PLAZA = Usuario.Codigo_Plaza Then
                            If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
                                Return False
                            End If
                        Else
                            MsgBox("La póliza es de otra plaza, no puede modificarse.", MsgBoxStyle.Exclamation, Me.Text)
                            Return False
                        End If
                    Else
                        If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
                            Return False
                        End If
                    End If

                    'Si la póliza tiene contrapóliza
                    If txtLEN(Me.oPoliza.FOLIO_CONTRAPOLIZA) = True Then
                        If MsgBox("La póliza tiene una contrapóliza, desea cancelar ambas pólizas : " & Me.TxtFolio.Text & " y " & Me.oPoliza.FOLIO_CONTRAPOLIZA.ToString & " ?", vbYesNo Or vbQuestion, Me.Text) = MsgBoxResult.No Then
                            Return False
                        End If
                        Me.oPoliza.FECHA = Me.DtpFecha.Value
                        bResultado = Me.oPoliza.GestionaCancelar()
                    ElseIf txtLEN(Me.oPoliza.FOLIO_ORIGEN) = True Then 'Póliza generada por otro movimiento
                        MsgBox("La póliza " & Me.TxtFolio.Text & " debe cancelarla desde donde se originó el documento.", MsgBoxStyle.Exclamation, Me.Text)
                        Return False
                    Else 'Poliza directa
                        Me.oPoliza.FECHA = Me.DtpFecha.Value
                        bResultado = Me.oPoliza.Cancelar()
                    End If

                Case "C"
                    MsgBox("La pólizas canceladas no se pueden volver a cancelar.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
            End Select
            'Cancelar = Me.oPoliza.Cancelar()
            If bResultado = True Then
                MsgBox("Póliza " & Me.TxtFolio.Text & " cancelada satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Cancelar", ex)
        End Try

        Return bResultado
    End Function

    Private Function Reactivar() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim sFolio As String = Me.TxtFolio.Text, sContraPoliza As String = ""
            Me.oPoliza = New Class_Contabilidad_Poliza_Global(sFolio)

            If MsgBox("Desea reactivar la póliza " & Me.TxtFolio.Text & " ?", vbYesNo Or vbQuestion, Me.Text) = MsgBoxResult.No Then
                Return False
            End If

            If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.CmbDocumento.SelectedValue.ToString & Usuario.Codigo_Plaza) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
                Return False
            End If

            If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
                Return False
            End If

            Select Case Me.LblCodigoEstatus.Text
                Case "N"
                    MsgBox("La póliza no existe.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                Case "G"
                    MsgBox("Sólo las pólizas canceladas se pueden reactivar.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                Case "A"
                    MsgBox("Sólo las pólizas canceladas se pueden reactivar.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                Case "C"
                    If txtLEN(Me.oPoliza.FOLIO_CONTRAPOLIZA) = True Then
                        MsgBox("Las pólizas con contrapólizas no pueden reactivarse.", MsgBoxStyle.Exclamation, Me.Text)
                        Return False

                        '26oct16, se eliminó la posibilidad de reactivar pólizas con contras porque luego podian reactivar la original y quedar incongruente.
                        'If MsgBox("La póliza tiene una contrapoliza desea reactivar ambas polizas. " & Me.TxtFolio.Text & " y " & Me.oPoliza.FOLIO_CONTRAPOLIZA.ToString & " ?", vbYesNo Or vbQuestion, Me.Text) = MsgBoxResult.No Then
                        '    Exit Function
                        'End If
                        'sContraPoliza = Me.oPoliza.FOLIO_CONTRAPOLIZA.ToString
                        'Me.oPoliza = New Class_Contabilidad_Poliza_Global(sContraPoliza)
                        'Me.oPoliza.Reactiva()
                    End If
                    'No hay restricciones    
            End Select

            Me.oPoliza = New Class_Contabilidad_Poliza_Global(sFolio)
            bResultado = Me.oPoliza.Reactiva()

            If bResultado = True Then
                MsgBox("Póliza reactivada satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Reactivar", ex)
        End Try

        Return bResultado
    End Function

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim FormatoDeReporte As String
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            FormatoDeReporte = "RPT_FORMATO_CONTABILIDAD_POLIZA"
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt, False)
            If Not oReporte.RptCargado Then
                Exit Sub
            End If
            Rpt.SetParameterValue("@FOLIO_POLIZA", TxtFolio.Text)
            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Function Consultar() As Boolean
        Const sProcedure As String = "Consultar"
        Dim bResultado As Boolean = False
        Dim sFolio As String = Me.TxtFolio.Text, dTabla As DataTable

        Try
            Me.Inicializa()
            Me.oPoliza = New Class_Contabilidad_Poliza_Global(sFolio)

            If Me.oPoliza.Existe = False Then
                Me.Cambia_Estado(enumEstados.NUEVO)
                Me.TxtFolio.Enabled = False
                Return False
            End If

            Me.DtpFecha.Value = oPoliza.FECHA 'Se llena primero la fecha porque se piede al generar el folio cuando se ejecuta la siguiente linea que llena el codigo tipo documento
            Me.CmbDocumento.SelectedValue = oPoliza.CODIGO_TIPO_DOCUMENTO
            Me.oPoliza.FOLIO_POLIZA = sFolio
            Me.TxtFolio.Text = oPoliza.FOLIO_POLIZA
            Me.LblCodigoEstatus.Text = oPoliza.ESTATUS_POLIZA
            Me.lblEstatus.Text = oPoliza.ESTATUS
            Me.lblFolioOrigen.Text = oPoliza.FOLIO_ORIGEN
            Me.TxtConcepto1.Text = oPoliza.CONCEPTO1
            Me.TxtConcepto2.Text = oPoliza.CONCEPTO2

            If oPoliza.CODIGO_TIPO_DOCUMENTO = "E" Then
                Me.CboFacturasRecibidas.SelectedValue = oPoliza.CODIGO_LISTA_FACTURAS_RECIBIDAS.ToString
            End If

            'Este lo puse luego del formatea porque se ocultarian las columnas.
            'Me.chkDetallarGastos.Checked = oPoliza.TIENE_DETALLE_GASTOS

            Me.Grid1.AutoRedraw = False

            dTabla = Me.oPoliza.ObtenerDetalle '.Rows.Count
            Me.Grid1.Rows = 1
            For Each dRow As DataRow In dTabla.Rows
                Me.Grid1.AddItem(dRow("CUENTA_CONTABLE").ToString & Chr(9) & dRow("NOMBRE_CUENTA").ToString & Chr(9) & dRow("CONCEPTO").ToString.Replace(vbTab, " ").ToString & Chr(9) & dRow("NATURALEZA_CONTABLE").ToString & Chr(9) &
                                 dRow("CARGO").ToString & Chr(9) & dRow("ABONO").ToString & Chr(9) &
                                  dRow("CODIGO_CENTRO_COSTO").ToString & Chr(9) & dRow("NOMBRE_CENTRO_COSTO").ToString & Chr(9) &
                                  dRow("CODIGO_CATEGORIA").ToString & Chr(9) & dRow("NOMBRE_CATEGORIA").ToString & Chr(9) &
                                  dRow("CODIGO_CONCEPTO").ToString & Chr(9) & dRow("NOMBRE_CONCEPTO").ToString & Chr(9))
            Next

            Me.FormateaGrid()

            'Me.TxtTotalCargos.Text = FormatImporteContable(oPoliza.CARGO)
            'Me.TxtTotalAbonos.Text = FormatImporteContable(oPoliza.ABONO)
            'Me.txtTotalDiferenciaCargosAbonos.Text = FormatImporteContable(oPoliza.CARGO - oPoliza.ABONO)

            'Se cambió para sumarizar lo que este en grid(del mismo modo que en totales, porque a veces pudieran estar en 0 los totales)
            Me.TxtTotalCargos.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid1, 5))
            Me.TxtTotalAbonos.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid1, 6))
            Me.txtTotalDiferenciaCargosAbonos.Text = FormatImporteContable(valorNumericoD(Me.TxtTotalCargos.Text) - valorNumericoD(Me.TxtTotalAbonos.Text))

            Me.GestionaCambioEstado()
            'TIENE CONTRA POLIZA
            If txtLEN(Me.oPoliza.FOLIO_CONTRAPOLIZA) = True Then
                Me.LnkContrapoliza.Text = Me.oPoliza.FOLIO_CONTRAPOLIZA.ToString
                Me.LnkContrapoliza.Visible = True
                Me.lblDisplayContraPoliza.Visible = True
            Else 'ES CONTRA POLIZA
                Dim sql As New Class_find("SELECT 1 FROM CON_POLIZAS_GLOBAL WHERE FOLIO_ORIGEN<>FOLIO_POLIZA AND FOLIO_ORIGEN IN (SELECT FOLIO_POLIZA FROM CON_POLIZAS_GLOBAL ) " &
                                        "and  FOLIO_POLIZA='" & Me.TxtFolio.Text & "'")
                If txtLEN(sql.Result1) = True Then
                    Me.Cambia_Estado(enumEstados.CONTRAPOLIZA)
                End If
            End If

            Me.tssElaboro.Text = "Elaboró : " & Me.oPoliza.NOMBRE_USUARIO_GRABO & " el " & Format(Me.oPoliza.FECHA_SERVIDOR, "dd-MMM-yyyy hh:mm tt")
            If Me.oPoliza.ESTATUS_POLIZA = "C" Then
                Me.tssCancelo.Text = "Canceló : " & Me.oPoliza.NOMBRE_USUARIO_CANCELO & " el : " & Format(Me.oPoliza.FECHA_CANCELACION_SERVIDOR, "dd-MMM-yyyy hh:mm tt")
                Me.tssCancelo.Visible = True
            End If

            'Consulta grid de xmls.
            If txtLEN(Me.GridXMLs.Cell(Me.GridXMLs.Rows - 1, Me.iGyGridXMLUUID).Text) = False Then
                Me.GridXMLs.Row(Me.GridXMLs.Rows - 1).Delete()
            End If

            Me.GridXMLs.AutoRedraw = False
            Dim dtXMLs As New DataTable
            dtXMLs = Me.oPoliza.ObtieneXMLs
            For Each dRow As DataRow In dtXMLs.Rows

                'No se usó este método porque los datos ya están en la tabla, además para el complemento de pagos habria que hacer un if para traer el total y la modena del complemento(en el caso de la tabla están reutilizados los del nodo comprobante)
                'Dim oCFDI As New ClassCFDI(dRow("CADENA_XML").ToString, False)
                'If oCFDI.XMLCargado = True Then
                '    With oCFDI.Comprobante
                '        Me.GridXMLs.AddItem(.tipoDeComprobante & Chr(9) & dRow("PDF_NOMBRE").ToString & Chr(9) & .fecha & Chr(9) & .folioCompleto & Chr(9) & oCFDI.ComplementoTFD.UUID & Chr(9) & oCFDI.Emisor.rfc & Chr(9) & oCFDI.Emisor.nombre & Chr(9) &
                '                        .subTotal & Chr(9) & oCFDI.Impuestos.totalImpuestosTrasladados & Chr(9) & oCFDI.Impuestos.totalImpuestosRetenidos & Chr(9) & .total & Chr(9) & .Moneda & Chr(9) & "" & Chr(9) & "")
                '    End With
                'End If
                'oCFDI = Nothing

                Me.GridXMLs.AddItem(dRow("TIPO_DE_COMPROBANTE").ToString & Chr(9) & dRow("PDF_NOMBRE").ToString & Chr(9) & dRow("FECHA").ToString & Chr(9) & dRow("FOLIO").ToString & Chr(9) & dRow("UUID").ToString & Chr(9) &
                                    dRow("EMISOR_RFC").ToString & Chr(9) & dRow("EMISOR_NOMBRE").ToString & Chr(9) & dRow("SUBTOTAL").ToString & Chr(9) &
                                    dRow("TOTAL_IMPUESTOS_TRASLADADOS").ToString & Chr(9) & dRow("TOTAL_IMPUESTOS_RETENIDOS").ToString & Chr(9) & dRow("TOTAL").ToString & Chr(9) & dRow("MONEDA").ToString & Chr(9) & "" & Chr(9) & "")

            Next
            dtXMLs.Dispose()
            Me.TotalizaGridXMLs()

            'Ver nota 1, aqui va para que no se oculten las columnas por otros eventos.
            Me.chkDetallarGastos.Checked = oPoliza.TIENE_DETALLE_GASTOS

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        Finally
            Me.Grid1.AutoRedraw = True
            Me.Grid1.Refresh()
            Me.GridXMLs.AutoRedraw = True
            Me.GridXMLs.Refresh()
        End Try

        Return bResultado
    End Function

    Private Sub GeneraFolio()
        If Me._ChildParaGrabar = False Then
            Try
                With oPoliza
                    .CODIGO_TIPO_DOCUMENTO = Me.CmbDocumento.SelectedValue.ToString
                    .FECHA = Me.DtpFecha.Value
                    .GeneraNuevoFolioPoliza()
                End With

                Me.TxtFolio.Text = Me.oPoliza.FOLIO_POLIZA
            Catch ex As Exception
                HandleError(Me.Name, "GeneraFolio", ex)
            End Try
        End If
    End Sub

    Public Sub Totales()
        Const sProcedure As String = "Totales"
        Try
            Me.TxtTotalCargos.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid1, 5))
            Me.TxtTotalAbonos.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid1, 6))
            Me.txtTotalDiferenciaCargosAbonos.Text = FormatImporteContable(valorNumericoD(Me.TxtTotalCargos.Text) - valorNumericoD(Me.TxtTotalAbonos.Text))
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Function ValidaCuentasContables() As Boolean
        Dim bResultado As Boolean = False
        Dim i As Integer, bHayCuentasContables As Boolean = False
        Try
            For i = 1 To Me.Grid1.Rows - 1
                If Len(Me.Grid1.Cell(i, Me.iGyCUENTA_CONTABLE_PESOS).Text) > 0 Then
                    Dim sql As New Class_find("SELECT CUENTA_CONTABLE,ESMAYOR FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & Me.Grid1.Cell(i, Me.iGyCUENTA_CONTABLE_PESOS).Text & "'")
                    If sql.Result1 = "" Then
                        MsgBox("La cuenta contable que intenta introducir en el renglón: " & i & " no existe, favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de Cuentas Contables")
                        Me.Grid1.Cell(i, Me.iGyCUENTA_CONTABLE_PESOS).SetFocus()
                        Exit Function
                    ElseIf sql.Result2 = "1" Then
                        MsgBox("La cuenta contable que intenta introducir en el renglón: " & i & " es de mayor, favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de Cuentas Contables")
                        Me.Grid1.Cell(i, Me.iGyCUENTA_CONTABLE_PESOS).SetFocus()
                        Exit Function
                        'ElseIf Microsoft.VisualBasic.Left(Me.Grid1.Cell(i, Me.iGyCUENTA_CONTABLE_PESOS).Text, 1) = "5" Then
                        '    If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigoCentroCosto).Text) = False Or Me.Grid1.Cell(i, Me.iGyCodigoCentroCosto).Text = "0" Then
                        '        MsgBox("La cuenta contable que intenta introducir en el renglón: " & i & " es 5 mil , favor de asignar un centro de costo.", MsgBoxStyle.Exclamation, "Validación de Cuentas Contables")
                        '        Me.Grid1.Cell(i, Me.iGyCodigoCentroCosto).SetFocus()
                        '        Exit Function
                        '    End If
                    End If
                    sql = Nothing
                    bHayCuentasContables = True
                End If
            Next i

            For i = 1 To Me.Grid1.Rows - 1
                If Len(Me.Grid1.Cell(i, Me.iGyCUENTA_CONTABLE_PESOS).Text) > 0 Then
                    If valorNumerico(Me.Grid1.Cell(i, Me.iGyAbono).Text) = 0 And valorNumerico(Me.Grid1.Cell(i, Me.iGyCargo).Text) = 0 Then
                        MsgBox("Falta introducir un importe en el renglón: " & i & ".", MsgBoxStyle.Exclamation, "Validación de Cuentas Contables")
                        Me.Grid1.Cell(i, Me.iGyAbono).SetFocus()
                        Exit Function
                    End If
                End If
            Next i

            For i = 1 To Me.Grid1.Rows - 1
                If valorNumerico(Me.Grid1.Cell(i, Me.iGyAbono).Text) <> 0 Or valorNumerico(Me.Grid1.Cell(i, Me.iGyCargo).Text) <> 0 Then
                    If Len(Me.Grid1.Cell(i, Me.iGyCUENTA_CONTABLE_PESOS).Text) = 0 Then
                        MsgBox("Falta introducir la cuenta contrable en el renglón: " & i & ".", MsgBoxStyle.Exclamation, "Validación de Cuentas Contables")
                        Me.Grid1.Cell(i, Me.iGyCUENTA_CONTABLE_PESOS).SetFocus()
                        Exit Function
                    End If
                End If
            Next i

            If bHayCuentasContables = False Then
                MsgBox("Captúre el detalle de la póliza.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, "ValidaCuentasContables", ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidaCuentasContablesOrden() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim i As Integer, dTotalCargos As Double = 0, dTotalAbonos As Double = 0
            For i = 1 To Me.Grid1.Rows - 1
                If Len(Me.Grid1.Cell(i, Me.iGyCUENTA_CONTABLE_PESOS).Text) > 0 Then
                    Dim sql As New Class_find("SELECT  SUBSTRING(CUENTA_CONTABLE, 1, 1) NUM_CUENTA_INICIAL FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & Me.Grid1.Cell(i, Me.iGyCUENTA_CONTABLE_PESOS).Text & "'")
                    If sql.Result1 = "6" Then
                        If valorNumerico(Me.Grid1.Cell(i, Me.iGyAbono).Text) > 0 Then
                            dTotalAbonos = dTotalAbonos + valorNumerico(Me.Grid1.Cell(i, Me.iGyAbono).Text)
                        ElseIf valorNumerico(Me.Grid1.Cell(i, Me.iGyCargo).Text) > 0 Then
                            dTotalCargos = dTotalCargos + valorNumerico(Me.Grid1.Cell(i, Me.iGyCargo).Text)
                        End If
                    End If
                    sql = Nothing
                End If
            Next i
            If dTotalAbonos <> dTotalCargos Then
                MsgBox("Las cuentas '6000' de orden no cuadran.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "ValidaCuentasContablesOrden", ex)
        End Try

        Return bResultado
    End Function

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Try
            Me.Estado = pEstado

            Me.lblXMLPDFMsg.Visible = False

            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.TxtFolio.Enabled = True
                    Me.tssEstado.Text = "Estado: agregando póliza"
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    Me.tsbAplicar.Enabled = False
                    Me.tsbDesaplicar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbReactivar.Enabled = False
                    Me.tsbImprimir.Enabled = False
                    Me.CmbDocumento.Enabled = True
                    Me.DtpFecha.Enabled = True
                    Me.TxtConcepto1.Enabled = True
                    Me.TxtConcepto2.Enabled = True
                    Me.chkDetallarGastos.Enabled = True
                    Me.Grid1.Locked = False
                    Me.gpbFacturasRecibidas.Enabled = False
                    Me.CboFacturasRecibidas.SelectedValue = "N"
                    Me.lblEstatus.Text = "Nueva"
                    Me.LnkContrapoliza.Visible = False
                    Me.lblDisplayContraPoliza.Visible = False
                    Me.LblEsContraPoliza.Visible = False
                    Me.gbRenglones.Enabled = True
                    Me.txtTotalDiferenciaCargosAbonos.Visible = True : Me.lblDisplayTotalDiferenciaCargosAbonos.Visible = True

                    Me.tssElaboro.Visible = False
                    Me.tssCancelo.Visible = False

                    If Me.Visible = True Then
                        Me.TxtFolio.Focus()
                    End If

                Case enumEstados.GRABADO
                    Me.TxtFolio.Enabled = False
                    Me.tssEstado.Text = "Estado: consultando póliza"
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    Me.tsbAplicar.Enabled = True
                    Me.tsbDesaplicar.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.tsbReactivar.Enabled = False
                    Me.tsbImprimir.Enabled = True
                    Me.CmbDocumento.Enabled = False
                    Me.DtpFecha.Enabled = False
                    Me.TxtConcepto1.Enabled = True
                    Me.TxtConcepto2.Enabled = False
                    Me.chkDetallarGastos.Enabled = True
                    Me.Grid1.Locked = False
                    Me.gpbFacturasRecibidas.Enabled = False
                    Me.LblEsContraPoliza.Visible = False
                    Me.gbRenglones.Enabled = True
                    Me.txtTotalDiferenciaCargosAbonos.Visible = True : Me.lblDisplayTotalDiferenciaCargosAbonos.Visible = True

                    Me.tssElaboro.Visible = True
                    Me.tssCancelo.Visible = False

                    If Me.Visible = True Then
                        Me.TxtConcepto1.Focus()
                    End If

                Case enumEstados.APLICADO
                    Me.TxtFolio.Enabled = False
                    Me.tssEstado.Text = "Estado: consultando póliza"
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbAplicar.Enabled = False
                    Me.tsbDesaplicar.Enabled = True
                    Me.tsbCancelar.Enabled = True
                    Me.tsbReactivar.Enabled = False
                    Me.tsbImprimir.Enabled = True
                    Me.CmbDocumento.Enabled = False
                    Me.DtpFecha.Enabled = False
                    Me.TxtConcepto1.Enabled = False
                    Me.TxtConcepto2.Enabled = False
                    Me.chkDetallarGastos.Enabled = False
                    Me.Grid1.Locked = True
                    Me.gpbFacturasRecibidas.Enabled = True
                    Me.LblEsContraPoliza.Visible = False
                    Me.gbRenglones.Enabled = False
                    Me.txtTotalDiferenciaCargosAbonos.Visible = True : Me.lblDisplayTotalDiferenciaCargosAbonos.Visible = True

                    Me.tssElaboro.Visible = True
                    Me.tssCancelo.Visible = False

                    If Me.Visible = True Then
                        Me.tsbImprimir.Select()
                    End If

                Case enumEstados.CANCELADO
                    Me.TxtFolio.Enabled = False
                    Me.tssEstado.Text = "Estado: consultando póliza"
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbAplicar.Enabled = False
                    Me.tsbDesaplicar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbReactivar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.CmbDocumento.Enabled = False
                    Me.DtpFecha.Enabled = False
                    Me.TxtConcepto1.Enabled = False
                    Me.TxtConcepto2.Enabled = False
                    Me.chkDetallarGastos.Enabled = False
                    Me.Grid1.Locked = True
                    Me.gpbFacturasRecibidas.Enabled = False
                    Me.LblEsContraPoliza.Visible = False
                    Me.gbRenglones.Enabled = False
                    Me.txtTotalDiferenciaCargosAbonos.Visible = True : Me.lblDisplayTotalDiferenciaCargosAbonos.Visible = True

                    Me.tssElaboro.Visible = True
                    Me.tssCancelo.Visible = True

                    If Me.Visible = True Then
                        Me.tsbImprimir.Select()
                    End If

                Case enumEstados.CONTRAPOLIZA
                    Me.tssEstado.Text = "Estado: consultando contrapóliza"
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbAplicar.Enabled = False
                    Me.tsbDesaplicar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbReactivar.Enabled = False
                    Me.tsbImprimir.Enabled = True
                    Me.CmbDocumento.Enabled = False
                    Me.DtpFecha.Enabled = False
                    Me.TxtConcepto1.Enabled = False
                    Me.TxtConcepto2.Enabled = False
                    Me.chkDetallarGastos.Enabled = False
                    Me.Grid1.Locked = True
                    Me.gpbFacturasRecibidas.Enabled = False
                    Me.LnkContrapoliza.Visible = False
                    Me.lblDisplayContraPoliza.Visible = False
                    Me.LblEsContraPoliza.Visible = True
                    Me.gbRenglones.Enabled = False
                    Me.txtTotalDiferenciaCargosAbonos.Visible = True : Me.lblDisplayTotalDiferenciaCargosAbonos.Visible = True

                    Me.tssElaboro.Visible = True
                    Me.tssCancelo.Visible = False

                    If Me.Visible = True Then
                        Me.TxtConcepto1.Focus()
                    End If
            End Select

            Application.DoEvents()

        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try

    End Sub

    Private Sub GestionaCambioEstado()
        Select Case Me.LblCodigoEstatus.Text
            Case "G"
                Me.Cambia_Estado(enumEstados.GRABADO)
            Case "A"
                Me.Cambia_Estado(enumEstados.APLICADO)
            Case "C"
                Me.Cambia_Estado(enumEstados.CANCELADO)
        End Select
    End Sub

    Private Sub InicializaChild()
        Try
            Me.oPoliza = New Class_Contabilidad_Poliza_Global(Me.TxtFolio.Text)
            Me.DesplegarTipoDocumento()
            Me.DesplegarDocumentosProveedor()

            Me.CmbDocumento.SelectedValue = Me._CodigoDocumentoParaGrabarLlamadoExterior
            If Me.CmbDocumento.SelectedValue.ToString = "E" Then
                Me.gpbFacturasRecibidas.Visible = True
                Me.CboFacturasRecibidas.SelectedValue = Me._CodigoDocumentoProveedorParaGrabarLlamadoExterior
            Else
                Me.gpbFacturasRecibidas.Visible = False
            End If

            If valorNumerico(CStr(Me._ImporteAcreedor)) > 0 Then
                Me.tsbRecalcularImporte.Visible = True
                'Else
                'Me.tsbRecalcularImporte.Visible = False
            End If

            Me.Cambia_Estado(enumEstados.NUEVO)
            Me.DtpFecha.Enabled = False
            Me.TxtFolio.Enabled = False
            Me.CmbDocumento.Enabled = False
            Me.TxtConcepto1.Enabled = False
            Me.TxtConcepto2.Enabled = False

            Me.tsbNuevo.Visible = False
            Me.tsbGrabar.Visible = False
            Me.tsbValidarGrabadoLlamadoExterior.Visible = True
            Me.tsbAplicar.Visible = False
            Me.tsbDesaplicar.Visible = False
            Me.tsbCancelar.Visible = False
            Me.tsbImprimir.Visible = False
            Me.tsbReactivar.Visible = False

        Catch ex As Exception
            HandleError(Me.Name, "InicializaChild", ex)
        End Try
    End Sub

    Private Sub GestionaIVAAcreditable()
        Dim f As New Frm_Contabilidad_IVA_Acreditable_Global
        Try
            f.FolioPolizaConsultaExterior = Me.TxtFolio.Text
            f.FechaPolizaConsultaExterior = Me.DtpFecha.Value
            f.ShowDialog()
        Catch ex As Exception
            HandleError(Me.Name, "GestionaIVAAcreditable", ex)
        Finally
            f.Dispose()
        End Try
    End Sub

    Private Sub SumaAbonosBancos()
        Dim i As Integer, dTotalBancos As Double = 0
        'Dim sCuentaContable As String

        Try
            Dim oCuentaBancaria As New Class_CatCuentasBancarias(Me._CuentaBancaria)

            If MsgBox("Desea recalcular el importe del cheque ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                Exit Sub
            End If

            For i = 1 To Me.Grid1.Rows - 1
                If oCuentaBancaria.CUENTA_CONTABLE_PESOS = Me.Grid1.Cell(i, Me.iGyCUENTA_CONTABLE_PESOS).Text Then
                    dTotalBancos += valorNumerico(Me.Grid1.Cell(i, Me.iGyAbono).Text)
                End If
            Next i

            If dTotalBancos <> Me._ImporteAcreedor Then
                If Me._FormaValidaParaGrabarLlamadoExterior = False Then
                    If MsgBox("El importe no es igual al importe del banco en cheques. Desea actualizar el importe de total del banco " & FormatImporteContable(dTotalBancos).ToString & " ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                        Me._ImporteAcreedor = valorNumerico(dTotalBancos.ToString)
                        MsgBox("El importe se a modificado satisfactoriamente.", MsgBoxStyle.Exclamation, Me.Text)
                        Me._RecalcularImporte = True
                    End If
                End If
            End If

        Catch ex As Exception
            HandleError(Me.Name, "SumaAbonosBancos", ex)
        End Try

    End Sub

    Private Sub Navegador(ByVal sTipoDeBusqueda As String)
        Try
            Dim iFolio As Integer, sFolio As String, iPosicion As Integer, sFolioParte2 As String
            'If txtLEN(Me.TxtFolio.Text) = False Then
            '    If GeneraFolio() = False OrElse txtLEN(Me.TxtFolio.Text) = False Then
            '        Exit Function
            '    End If
            'End If

            If sTipoDeBusqueda = "Anterior" Then
                iPosicion = Me.TxtFolio.Text.IndexOf("-")
                sFolio = Me.TxtFolio.Text.Substring(0, iPosicion)
                iFolio = CInt(Strings.Right(Me.TxtFolio.Text, Len(Me.TxtFolio.Text) - (Len(sFolio) + 1))) ' Me.oVenta.FOLIO_NUMERICO
                iFolio = iFolio - 1
                sFolioParte2 = Format(iFolio, New String(CChar("0"), Me.TxtFolio.Text.Substring(3, Me.TxtFolio.TextLength - iPosicion - 1).Length))
                sFolio = sFolio + "-" + sFolioParte2 'sFolio + "-" + iFolio.ToString
                Me.TxtFolio.Text = sFolio

                If txtLEN(sFolio) = True Then
                    Me.Consultar()
                Else
                    Me.Inicializa()
                    Me.Cambia_Estado(enumEstados.NUEVO)
                    Me.GeneraFolio()
                    Me.TxtFolio.Focus()
                End If

            ElseIf sTipoDeBusqueda = "Siguiente" Then
                iPosicion = Me.TxtFolio.Text.IndexOf("-")
                sFolio = Me.TxtFolio.Text.Substring(0, iPosicion)
                iFolio = CInt(Strings.Right(Me.TxtFolio.Text, Len(Me.TxtFolio.Text) - (Len(sFolio) + 1))) ' Me.oVenta.FOLIO_NUMERICO
                iFolio = iFolio + 1
                sFolioParte2 = Format(iFolio, New String(CChar("0"), Me.TxtFolio.Text.Substring(3, Me.TxtFolio.TextLength - iPosicion - 1).Length))
                sFolio = sFolio + "-" + sFolioParte2 'sFolio + "-" + iFolio.ToString
                Me.TxtFolio.Text = sFolio

                If txtLEN(sFolio) = True Then
                    Me.Consultar()
                Else
                    Me.Inicializa()
                    Me.Cambia_Estado(enumEstados.NUEVO)
                    Me.GeneraFolio()
                    Me.TxtFolio.Focus()
                End If
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Navegador", ex)
        End Try
    End Sub

    Private Sub ImportarPoliza()
        Try
            Dim dTabla As DataTable

            Me.oPoliza = New Class_Contabilidad_Poliza_Global(Me.txtImportarPoliza.Text)
            If Me.oPoliza.Existe = False Then
                MsgBox("La póliza no existe. Favor de verificar.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtImportarPoliza.Focus()
                Exit Sub
            End If

            Me.Grid1.AutoRedraw = False
            Me.InicializaGrid()

            dTabla = Me.oPoliza.ObtenerDetalle '.Rows.Count
            Me.Grid1.Rows = 1
            For Each dRow As DataRow In dTabla.Rows
                Me.Grid1.AddItem(dRow("CUENTA_CONTABLE").ToString & Chr(9) & dRow("NOMBRE_CUENTA").ToString & Chr(9) & Replace(dRow("CONCEPTO").ToString, vbTab, " ") & Chr(9) & dRow("NATURALEZA_CONTABLE").ToString & Chr(9) & dRow("CARGO").ToString & Chr(9) &
                    dRow("ABONO").ToString & Chr(9) & dRow("CODIGO_CENTRO_COSTO").ToString & Chr(9) & dRow("NOMBRE_CENTRO_COSTO").ToString & Chr(9))
            Next

            Me.FormateaGrid()
            Me.Totales()
        Catch ex As Exception
            HandleError(Me.Name, "ImportarPoliza", ex)
        Finally
            Me.Grid1.AutoRedraw = True
            Me.Grid1.Refresh()
        End Try
    End Sub

    Private Sub InicializaGridXML()
        Try
            Me.GridXMLs.DataSource = Nothing
            FG_Grid_Limpiar(GridXMLs)

            'Creamos el Grid
            Me.GridXMLs.Rows = 2
            Me.GridXMLs.Cols = 15
            Me.GridXMLs.DisplayRowNumber = True

            Me.FormateaGridXMLs()
        Catch ex As Exception
            HandleError(Me.Text, "InicializaGridXML", ex)
        End Try
    End Sub

    Private Sub FormateaGridXMLs()
        Try
            Me.GridXMLs.Column(Me.iGyGridXMLTipoComprobante).Width = 25
            Me.GridXMLs.Column(Me.iGyGridXMLNombrePDF).Width = 70
            Me.GridXMLs.Column(Me.iGyGridXMLFecha).Width = 60
            Me.GridXMLs.Column(Me.iGyGridXMLFolio).Width = 70
            Me.GridXMLs.Column(Me.iGyGridXMLUUID).Width = 180
            Me.GridXMLs.Column(Me.iGyGridXMLEmisorRFC).Width = 90
            Me.GridXMLs.Column(Me.iGyGridXMLEmisorNombre).Width = 170
            Me.GridXMLs.Column(Me.iGyGridXMLSubtotal).Width = 80
            Me.GridXMLs.Column(Me.iGyGridXMLImpuestosTrasladados).Width = 80
            Me.GridXMLs.Column(Me.iGyGridXMLImpuestosRetenidos).Width = 50
            Me.GridXMLs.Column(Me.iGyGridXMLTotal).Width = 80
            Me.GridXMLs.Column(Me.iGyGridXMLMoneda).Width = 30
            Me.GridXMLs.Column(Me.iGyGridXMLRutaXML).Visible = False
            Me.GridXMLs.Column(Me.iGyGridXMLRutaPDF).Visible = False

            Me.GridXMLs.Cell(0, Me.iGyGridXMLTipoComprobante).Text = "Tipo"
            Me.GridXMLs.Cell(0, Me.iGyGridXMLNombrePDF).Text = "NombrePDF"
            Me.GridXMLs.Cell(0, Me.iGyGridXMLFecha).Text = "Fecha"
            Me.GridXMLs.Cell(0, Me.iGyGridXMLFolio).Text = "Folio"
            Me.GridXMLs.Cell(0, Me.iGyGridXMLUUID).Text = "UUID"
            Me.GridXMLs.Cell(0, Me.iGyGridXMLEmisorRFC).Text = "Emisor RFC"
            Me.GridXMLs.Cell(0, Me.iGyGridXMLEmisorNombre).Text = "Emisor nombre"
            Me.GridXMLs.Cell(0, Me.iGyGridXMLSubtotal).Text = "Subtotal"
            Me.GridXMLs.Cell(0, Me.iGyGridXMLImpuestosTrasladados).Text = "Imp.Tras"
            Me.GridXMLs.Cell(0, Me.iGyGridXMLImpuestosRetenidos).Text = "Imp.Ret"
            Me.GridXMLs.Cell(0, Me.iGyGridXMLTotal).Text = "Total"
            Me.GridXMLs.Cell(0, Me.iGyGridXMLMoneda).Text = "Mon."
            Me.GridXMLs.Cell(0, Me.iGyGridXMLRutaXML).Text = "RutaXML"
            Me.GridXMLs.Cell(0, Me.iGyGridXMLRutaPDF).Text = "RutaPDF"

            Me.GridXMLs.Column(Me.iGyGridXMLSubtotal).Mask = FlexCell.MaskEnum.Numeric
            Me.GridXMLs.Column(Me.iGyGridXMLSubtotal).DecimalLength = 2
            Me.GridXMLs.Column(Me.iGyGridXMLSubtotal).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.GridXMLs.Column(Me.iGyGridXMLImpuestosTrasladados).Mask = FlexCell.MaskEnum.Numeric
            Me.GridXMLs.Column(Me.iGyGridXMLImpuestosTrasladados).DecimalLength = 2
            Me.GridXMLs.Column(Me.iGyGridXMLImpuestosTrasladados).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.GridXMLs.Column(Me.iGyGridXMLImpuestosRetenidos).Mask = FlexCell.MaskEnum.Numeric
            Me.GridXMLs.Column(Me.iGyGridXMLImpuestosRetenidos).DecimalLength = 2
            Me.GridXMLs.Column(Me.iGyGridXMLImpuestosRetenidos).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.GridXMLs.Column(Me.iGyGridXMLTotal).Mask = FlexCell.MaskEnum.Numeric
            Me.GridXMLs.Column(Me.iGyGridXMLTotal).DecimalLength = 2
            Me.GridXMLs.Column(Me.iGyGridXMLTotal).Alignment = FlexCell.AlignmentEnum.RightCenter

            'Me.GridXMLs.Column(Me.iGyNombreCuenta).Locked = True
            Me.GridXMLs.Locked = True

        Catch ex As Exception
            HandleError(Me.Text, "FormateaGridXMLs", ex)
        End Try
    End Sub

    Private Function AgregarXML() As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "AgregarXML"

        Me.lblXMLPDFMsg.Visible = False
        Me.btnAgregarXML.Enabled = False

        Try
            Dim sRutaXML As String = Me.oPoliza.BuscarXML 'Aquí ya se valida que sea del emisor.rfc sea el rfc de esta empresa.
            Dim sPDFNombre As String = ""

            If txtLEN(sRutaXML) = False Then
                Return False
            End If

            Dim oCFDI As New ClassCFDI(sRutaXML, True)

            If oCFDI.XMLCargado = False Then
                Return False
            End If

            For i As Integer = 1 To Me.GridXMLs.Rows - 1
                If Me.GridXMLs.Cell(i, Me.iGyGridXMLUUID).Text.ToUpper = oCFDI.ComplementoTFD.UUID.ToUpper Then
                    MsgBox("El UUID de este XML ya se agregó a este documento en el renglón #" & i.ToString & ".", vbExclamation, sProcedure)
                    Return False
                End If
            Next

            Me.GridXMLs.AutoRedraw = False

            If txtLEN(Me.GridXMLs.Cell(Me.GridXMLs.Rows - 1, Me.iGyGridXMLUUID).Text) = False Then
                Me.GridXMLs.Row(Me.GridXMLs.Rows - 1).Delete()
            End If

            If Me.Estado = enumEstados.APLICADO Or Me.Estado = enumEstados.CANCELADO Or Me.Estado = enumEstados.GRABADO Then 'Si ya la póliza ya existe, graba de inmediato el XML en la base de datos.
                If Me.oPoliza.AgregarXMLPDF(sRutaXML, "") = False Then
                    Return False
                End If

                Me.lblXMLPDFMsg.Text = "XML relacionado correctamente."
                Me.lblXMLPDFMsg.Visible = True
            End If

            sPDFNombre = Me.oPoliza.ObtienePDFNombre(oCFDI.ComplementoTFD.UUID) 'Si agregan un xml que ya existe, es posible que ya tenga el pdf, vamos a cargar el nombre pdf, no la ruta porque no la tenemos ni la grabaremos nunca(el usuario las puede mover)

            If txtLEN(sPDFNombre) = True Then
                MsgBox("Este XML ya tiene un PDF relacionado, puede abrirlo para corrobar que este correcto, si no para corregirlo.", MsgBoxStyle.Information, sProcedure)
            End If

            With oCFDI.Comprobante
                Me.GridXMLs.AddItem(.TipoDeComprobante & Chr(9) & sPDFNombre & Chr(9) & .Fecha & Chr(9) & .FolioCompleto & Chr(9) & oCFDI.ComplementoTFD.UUID & Chr(9) & oCFDI.Emisor.rfc & Chr(9) & oCFDI.Emisor.nombre & Chr(9) &
                                    .SubTotal & Chr(9) & oCFDI.Impuestos.totalImpuestosTrasladados & Chr(9) & oCFDI.Impuestos.totalImpuestosRetenidos & Chr(9) &
                                    CDec(IIf(.TipoDeComprobante = "P", oCFDI.ComplementoPago.Monto, .Total).ToString) & Chr(9) &
                                    IIf(.TipoDeComprobante = "P", oCFDI.ComplementoPago.MonedaP, .Moneda).ToString & Chr(9) &
                                    sRutaXML & Chr(9) & "")
            End With

            bResultado = True

            Me.TotalizaGridXMLs()

            Me.GridXMLs.Cell(Me.GridXMLs.Rows - 1, Me.iGyGridXMLUUID).SetFocus()

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        Finally
            Me.btnAgregarXML.Enabled = True
            Me.GridXMLs.AutoRedraw = True
            Me.GridXMLs.Refresh()
        End Try

        Return bResultado
    End Function

    Private Sub TotalizaGridXMLs()
        Const sProcedure As String = "TotalizaGridXMLs"
        Try
            Me.txtXMLsSubtotal.Text = FormatImporteContable(FG_Grid_SumaCol(Me.GridXMLs, CShort(Me.iGyGridXMLSubtotal)))
            Me.txtXMLsImpuestosTrasladados.Text = FormatImporteContable(FG_Grid_SumaCol(Me.GridXMLs, CShort(Me.iGyGridXMLImpuestosTrasladados)))
            Me.txtXMLsImpuestosRetenidos.Text = FormatImporteContable(FG_Grid_SumaCol(Me.GridXMLs, CShort(Me.iGyGridXMLImpuestosRetenidos)))
            Me.txtXMLsTotal.Text = FormatImporteContable(FG_Grid_SumaCol(Me.GridXMLs, CShort(Me.iGyGridXMLTotal)))
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Function VerXML() As Boolean
        Const sProcedure As String = "VerXML"
        Dim bResultado As Boolean = False

        Try
            Dim Renglon As Integer = Me.GridXMLs.Selection.FirstRow
            Dim sUUID As String = Me.GridXMLs.Cell(Renglon, Me.iGyGridXMLUUID).Text
            Dim sRutaXML As String = Me.GridXMLs.Cell(Renglon, Me.iGyGridXMLRutaXML).Text

            If Renglon = 0 Then
                MsgBox("No ha seleccionado un renglón.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If txtLEN(sUUID) = False Then
                MsgBox("No hay agregado un XML en este renglón.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If txtLEN(sRutaXML) = True Then
                Process.Start(sRutaXML)
            Else 'Es un XML que ya fue grabado y recordemos que en la consulta no hay ruta porque este dato no se graba(porque lo pueden mover los usuarios físicamente)
                bResultado = Me.oPoliza.AbrirXML(sUUID)
            End If

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function AgregarPDF() As Boolean
        Const sProcedure As String = "AgregarPDF"
        Dim bResultado As Boolean = False

        Me.lblXMLPDFMsg.Visible = False
        Me.btnAgregarPDF.Enabled = False

        Try
            Dim Renglon As Integer = Me.GridXMLs.Selection.FirstRow
            Dim sUUID As String = Me.GridXMLs.Cell(Renglon, Me.iGyGridXMLUUID).Text
            Dim sRutaPDF As String = "", sNombreArchivoPDF As String = ""

            If Renglon = 0 Then
                MsgBox("No ha seleccionado un renglón.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If txtLEN(sUUID) = False Then
                MsgBox("No hay agregado un XML en este renglón.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            sRutaPDF = Me.oPoliza.BuscarPDF

            If txtLEN(sRutaPDF) = False Then
                Return False
            End If

            sNombreArchivoPDF = Path.GetFileName(sRutaPDF)

            Me.GridXMLs.Cell(Renglon, iGyGridXMLNombrePDF).Text = sNombreArchivoPDF
            Me.GridXMLs.Cell(Renglon, iGyGridXMLRutaPDF).Text = sRutaPDF

            If Me.Estado = enumEstados.APLICADO Or Me.Estado = enumEstados.CANCELADO Or Me.Estado = enumEstados.GRABADO Then
                bResultado = Me.oPoliza.AgregarPDF(sUUID, sRutaPDF) 'Lo graba inmediatamente en la base de datos.

                Me.lblXMLPDFMsg.Text = "PDF relacionado correctamente."
                Me.lblXMLPDFMsg.Visible = True
            End If

            Me.GridXMLs.Cell(Renglon, Me.iGyGridXMLNombrePDF).SetFocus()

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        Finally
            Me.btnAgregarPDF.Enabled = True
            Application.DoEvents()
        End Try

        Return bResultado
    End Function

    Private Function VerPDF() As Boolean
        Const sProcedure As String = "VerPDF"
        Dim bResultado As Boolean = False

        Try
            Dim Renglon As Integer = Me.GridXMLs.Selection.FirstRow
            Dim sUUID As String = Me.GridXMLs.Cell(Renglon, Me.iGyGridXMLUUID).Text
            Dim sRutaPDF As String = Me.GridXMLs.Cell(Renglon, Me.iGyGridXMLRutaPDF).Text

            If Renglon = 0 Then
                MsgBox("No ha seleccionado un renglón.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If txtLEN(sUUID) = False Then
                MsgBox("No hay agregado un XML en este renglón.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If txtLEN(sRutaPDF) = True Then
                Process.Start(sRutaPDF)
            Else 'Es un XML que ya fue grabado y recordemos que en la consulta no hay ruta porque este dato no se graba(porque lo pueden mover los usuarios físicamente)
                If Me.oPoliza.TienePDF(sUUID) = True Then
                    bResultado = Me.oPoliza.AbrirPDF(sUUID)
                Else
                    MsgBox("Este xml no tiene archivo PDF.", vbExclamation, sProcedure)
                    Return False
                End If
            End If

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function EliminarXML() As Boolean
        Const sProcedure As String = "EliminarXML"
        Dim bResultado As Boolean = False

        Me.lblXMLPDFMsg.Visible = False
        Me.btnEliminarXML.Enabled = False

        Try
            Dim Renglon As Integer = Me.GridXMLs.Selection.FirstRow
            Dim sUUID As String = Me.GridXMLs.Cell(Renglon, Me.iGyGridXMLUUID).Text

            If Renglon = 0 Then
                MsgBox("No ha seleccionado un renglón.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If txtLEN(sUUID) = False Then
                MsgBox("No hay agregado un XML en este renglón.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If Me.oPoliza.EliminarRelacionUnXML(sUUID) = True Then
                Me.GridXMLs.Row(Renglon).Delete()

                Me.lblXMLPDFMsg.Text = "XML eliminado correctamente."
                Me.lblXMLPDFMsg.Visible = True

                bResultado = True

                Me.TotalizaGridXMLs()
            End If

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
            Application.DoEvents()
        Finally
            Me.btnEliminarXML.Enabled = True
            Me.GridXMLs.Refresh()
            Application.DoEvents()
        End Try

        Return bResultado
    End Function


#End Region

End Class


