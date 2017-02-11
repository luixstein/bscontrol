Option Strict On

Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Public Class Frm_Contabilidad_Captura_Polizas
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

#Region "Columnas grid"
    Private iGyCUENTA_CONTABLE_PESOS As Integer = 1
    Private iGyNombreCuenta As Integer = 2
    Private iGyConcepto As Integer = 3
    Private iGyNaturaleza As Integer = 4
    Private iGyCargo As Integer = 5
    Private iGyAbono As Integer = 6
    'Private iGyCodigoCentroCosto As Integer = 7
    'Private iGyNombreCentroCosto As Integer = 8
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
#End Region

#Region "Eventos de objetos"

#Region "Eventos"
    Private Sub Frm_Contabilidad_Captura_Polizas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me._ChildParaGrabar = True Then
            Me.InicializaChild()
            Dim i As Integer
            'InicializaGrid()
            For i = 1 To Me.Grid1.Rows - 1
                If Len(Me.Grid1.Cell(i, Me.iGyNombreCuenta).Text) > 0 Then
                    Dim sql As New Class_find("Select DBO.FN_CONTABILIDAD_NOMBRE_CUENTA_NIVELES_COMPLETOS(CUENTA_CONTABLE),NATURALEZA_CONTABLE,ESMAYOR From CON_CAT_CUENTAS Where CUENTA_CONTABLE='" & Me.Grid1.Cell(i, Me.iGyCUENTA_CONTABLE_PESOS).Text & "'")
                    If sql.Result1 <> "" Then
                        Me.Grid1.Cell(i, Me.iGyNombreCuenta).Text = sql.Result1
                        Me.Grid1.Cell(i, Me.iGyNaturaleza).Text = sql.Result2
                    End If
                    sql = Nothing
                End If
            Next i
            FormateaGrid()
            Totales()
            Me.Grid1.Focus()
        Else
            Me.DesplegarTipoDocumento()
            Me.DesplegarDocumentosProveedor()
            Me.CmbDocumento.SelectedValue = "D"
            Inicializa()
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
            'Me.CboFacturasRecibidas.SelectedValue = "N"

            Me.InicializaGrid()

            Me.oPoliza = New Class_Contabilidad_Poliza_Global

            Me.GeneraFolio()
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
            Me.Grid1.Cols = 7 ' 9
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
            'Dim X As New Drawing.Font("Tahoma", 7.0, FontStyle.Regular)
            'Me.Grid1.Cell(1, Me.iGyNombreCuenta).Font = X
            Me.Grid1.AllowUserResizing = FlexCell.ResizeEnum.Columns
            Me.Grid1.Column(0).Width = 25
            Me.Grid1.Column(Me.iGyCUENTA_CONTABLE_PESOS).Width = 105
            Me.Grid1.Column(Me.iGyNombreCuenta).Width = 400 'Relacionado tambien con NombreCompleto, porque se aumenta el len se
            Me.Grid1.Column(Me.iGyConcepto).Width = 205
            Me.Grid1.Column(Me.iGyNaturaleza).Width = 15
            Me.Grid1.Column(Me.iGyCargo).Width = 80
            Me.Grid1.Column(Me.iGyAbono).Width = 80
            'Me.Grid1.Column(Me.iGyCodigoCentroCosto).Width = 20
            'Me.Grid1.Column(Me.iGyNombreCentroCosto).Width = 120

            Me.Grid1.Cell(0, Me.iGyCUENTA_CONTABLE_PESOS).Text = "Cuenta"
            Me.Grid1.Cell(0, Me.iGyNombreCuenta).Text = "Nombre"
            Me.Grid1.Cell(0, Me.iGyConcepto).Text = "Concepto"
            Me.Grid1.Cell(0, Me.iGyNaturaleza).Text = "N"
            Me.Grid1.Cell(0, Me.iGyCargo).Text = "Cargo"
            Me.Grid1.Cell(0, Me.iGyAbono).Text = "Abono"
            'Me.Grid1.Cell(0, Me.iGyCodigoCentroCosto).Text = "CC"
            'Me.Grid1.Cell(0, Me.iGyNombreCentroCosto).Text = "C.costo"

            Me.Grid1.Column(Me.iGyCargo).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid1.Column(Me.iGyCargo).DecimalLength = 2
            Me.Grid1.Column(Me.iGyCargo).Alignment = FlexCell.AlignmentEnum.RightCenter
            Me.Grid1.Column(Me.iGyAbono).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid1.Column(Me.iGyAbono).DecimalLength = 2
            Me.Grid1.Column(Me.iGyAbono).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid1.Column(Me.iGyNombreCuenta).Locked = True
            Me.Grid1.Column(Me.iGyNaturaleza).Locked = True
            'Me.Grid1.Column(Me.iGyNombreCentroCosto).Locked = True

            Me.Grid1.Column(Me.iGyConcepto).MaxLength = 80

            Me.FormateaColoresGrid()

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
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
        Try
            Dim Columna As Integer, Renglon As Integer
            Dim StrCod As String
            Dim sql As Class_find
            Dim oCentroCosto As New Class_CatCentroCostos

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
                                MsgBox("La cuenta contable que intenta buscar no existe, favor de intentar con otro código.", MsgBoxStyle.Critical, "Validación de Cuentas Contables")
                                Me.Grid1.Cell(Renglon, Me.iGyCUENTA_CONTABLE_PESOS).Text = ""
                                Me.Grid1.Cell(Renglon, 0).SetFocus()
                                Exit Sub
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
                                MsgBox("La cuenta contable es una cuenta madre y no acepta cargos o abonos.", MsgBoxStyle.Critical, "Validación de Cuentas Contables")
                                Me.Grid1.Cell(Renglon, Me.iGyCUENTA_CONTABLE_PESOS).Text = "" '4
                                Me.Grid1.Cell(Renglon, Me.iGyNombreCuenta).Text = ""
                                Me.Grid1.Cell(Renglon, Me.iGyConcepto).Text = ""
                                Me.Grid1.Cell(Renglon, Me.iGyNaturaleza).Text = ""
                                Me.Grid1.Cell(Renglon, Me.iGyCargo).Text = ""
                                Me.Grid1.Cell(Renglon, Me.iGyAbono).Text = ""
                                'Me.Grid1.Cell(Renglon, Me.iGyCodigoCentroCosto).Text = ""
                                'Me.Grid1.Cell(Renglon, Me.iGyNombreCentroCosto).Text = ""
                                Me.Grid1.Cell(Renglon, 0).SetFocus()
                                Exit Sub
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
        Dim bResultado As Boolean = False
        Dim i As Integer

        If bConfirmacion = True Then
            If MsgBox("Desea grabar la póliza de " & Me.CmbDocumento.Text & " ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                Exit Function
            End If
        End If

        Try
            If Me.Validar(CBool(IIf(Me._ChildParaGrabar = True, False, True))) = False Then
                Exit Function
            End If

            If Me.ValidaCuentasContablesOrden() = False Then
                Exit Function
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

                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                Me.GeneraFolio()
                                .FOLIO_POLIZA = Me.TxtFolio.Text
                                bResultado = .Insertar(CBool(IIf(Me._ChildParaGrabar = True, False, True)))
                                Me.TxtFolio.Text = Me.oPoliza.FOLIO_POLIZA
                            Case enumEstados.GRABADO
                                bResultado = .Actualizar()
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
                                '.oPolizaDetalle.CODIGO_CENTRO_COSTO = CInt("0" & Me.Grid1.Cell(i, Me.iGyCodigoCentroCosto).Text)
                                .oPolizaDetalle.GrabaDetallePoliza()
                            End If
                        Next i
                        bResultado = True
                        If bConfirmacion = True And bResultado = True Then
                            MsgBox("Póliza " & Me.TxtFolio.Text & " grabada satisfactoriamente. ", MsgBoxStyle.Information, Me.Text)
                        End If

                        'If bChildParaGrabar = True Then
                        '    Me.Tag = "SI"
                        '    '.Aplicar()
                        '    Me.Close()
                        '    Exit Function
                        'End If

                    End With
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try

        Return bResultado
    End Function

    Public Function Aplicar(Optional ByVal bConfirmacion As Boolean = True, Optional ByVal bValidarEstatus As Boolean = True) As Boolean
        Dim bResultado As Boolean = False
        Try
            'Dim sContraPoliza As String
            If bConfirmacion = True Then
                If MsgBox("Desea aplicar la póliza " & Me.TxtFolio.Text & " ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                    Exit Function
                End If
            End If

            If Me.Grabar(False) = False Then
                Exit Function
            End If

            If Me.TxtTotalCargos.Text <> Me.TxtTotalAbonos.Text Then
                MsgBox("La póliza que desea aplicar no cuadra.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            If bValidarEstatus = True Then
                Select Case Me.LblCodigoEstatus.Text
                    Case "N"
                        MsgBox("La póliza no existe.", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                    Case "G"
                        'No hay restricciones
                        If txtLEN(Me.oPoliza.FOLIO_CONTRAPOLIZA) = True Then
                            MsgBox("Las pólizas con contrapólizas no pueden aplicarse, pueden en cambio cancelarse.", MsgBoxStyle.Exclamation, Me.Text)
                            Return False
                        End If
                        'If txtLEN(Me.oPoliza.FOLIO_CONTRAPOLIZA) = True Then
                        '    If MsgBox("La póliza tiene una contrapoliza desea aplicar ambas polizas. " & Me.TxtFolio.Text & " y " & Me.oPoliza.FOLIO_CONTRAPOLIZA.ToString & " ?", vbYesNo Or vbQuestion, Me.Text) = MsgBoxResult.No Then
                        '        Exit Function
                        '    End If
                        '    sContraPoliza = Me.oPoliza.FOLIO_CONTRAPOLIZA.ToString
                        '    Me.oPoliza = New Class_Contabilidad_Poliza_Global(sContraPoliza)
                        '    Me.oPoliza.Aplicar()
                        'End If
                        If txtLEN(Me.lblFolioOrigen.Text) = True Then
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
                        MsgBox("La pólizas aplicadas no se pueden aplicar de nuevo.", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                    Case "C"
                        MsgBox("La pólizas canceladas no se pueden aplicar.", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                End Select
            End If

            Me.oPoliza = New Class_Contabilidad_Poliza_Global(Me.TxtFolio.Text)
            bResultado = Me.oPoliza.Aplicar()

            If bResultado = True Then
                If bConfirmacion = True Then
                    MsgBox("Póliza " & Me.TxtFolio.Text & " aplicada satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
                End If
                If Me.oPoliza.ConsiderarParaControlIVAAcreditable = True Then
                    Me.GestionaIVAAcreditable()
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, "Aplicar", ex)
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
                        If MsgBox("La póliza tiene una contrapoliza desea cancelar ambas pólizas. " & Me.TxtFolio.Text & " y " & Me.oPoliza.FOLIO_CONTRAPOLIZA.ToString & " ?", vbYesNo Or vbQuestion, Me.Text) = MsgBoxResult.No Then
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
                        If MsgBox("La póliza tiene una contrapoliza, desea cancelar ambas pólizas : " & Me.TxtFolio.Text & " y " & Me.oPoliza.FOLIO_CONTRAPOLIZA.ToString & " ?", vbYesNo Or vbQuestion, Me.Text) = MsgBoxResult.No Then
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
                Exit Function
            End If

            If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.CmbDocumento.SelectedValue.ToString & Usuario.Codigo_Plaza) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
                Exit Function
            End If

            If Plaza.ValidarPeriodoTrabajo(Me.DtpFecha.Value) = False Then
                Exit Function
            End If

            Select Case Me.LblCodigoEstatus.Text
                Case "N"
                    MsgBox("La póliza no existe.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                Case "G"
                    MsgBox("Sólo las pólizas canceladas se pueden reactivar.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                Case "A"
                    MsgBox("Sólo las pólizas canceladas se pueden reactivar.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
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
        Dim bResultado As Boolean = False
        Dim sFolio As String = Me.TxtFolio.Text, dTabla As DataTable

        Try
            Me.Inicializa()
            Me.oPoliza = New Class_Contabilidad_Poliza_Global(sFolio)

            If Me.oPoliza.Existe = False Then
                Me.Cambia_Estado(enumEstados.NUEVO)
                Me.TxtFolio.Enabled = False
                Exit Function
            Else
                Me.DtpFecha.Value = oPoliza.FECHA 'Se llena primero la fecha porque se piede al generar el folio cuando se ejecuta la siguiente linea que llena el codigo tipo documento
                Me.CmbDocumento.SelectedValue = oPoliza.CODIGO_TIPO_DOCUMENTO
                Me.oPoliza.FOLIO_POLIZA = sFolio
                Me.TxtFolio.Text = oPoliza.FOLIO_POLIZA
                Me.LblCodigoEstatus.Text = oPoliza.ESTATUS_POLIZA
                Me.lblEstatus.Text = oPoliza.ESTATUS
                Me.lblFolioOrigen.Text = oPoliza.FOLIO_ORIGEN
                Me.TxtConcepto1.Text = oPoliza.CONCEPTO1
                Me.TxtConcepto2.Text = oPoliza.CONCEPTO2

                Me.TxtTotalCargos.Text = FormatImporteContable(oPoliza.CARGO)
                Me.TxtTotalAbonos.Text = FormatImporteContable(oPoliza.ABONO)
                Me.txtTotalDiferenciaCargosAbonos.Text = FormatImporteContable(oPoliza.CARGO - oPoliza.ABONO)

                If oPoliza.CODIGO_TIPO_DOCUMENTO = "E" Then
                    Me.CboFacturasRecibidas.SelectedValue = oPoliza.CODIGO_LISTA_FACTURAS_RECIBIDAS.ToString
                End If

                Me.Grid1.AutoRedraw = False

                dTabla = Me.oPoliza.ObtenerDetalle '.Rows.Count
                Me.Grid1.Rows = 1
                For Each dRow As DataRow In dTabla.Rows
                    Me.Grid1.AddItem(dRow("CUENTA_CONTABLE").ToString & Chr(9) & dRow("NOMBRE_CUENTA").ToString & Chr(9) & dRow("CONCEPTO").ToString & Chr(9) & dRow("NATURALEZA_CONTABLE").ToString & Chr(9) & dRow("CARGO").ToString & Chr(9) &
                                    dRow("ABONO").ToString & Chr(9)) ' & dRow("CODIGO_CENTRO_COSTO").ToString & Chr(9) & dRow("NOMBRE_CENTRO_COSTO").ToString & Chr(9))
                Next

                Me.FormateaGrid()

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

            End If
            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        Finally
            Me.Grid1.AutoRedraw = True
            Me.Grid1.Refresh()
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
        Me.TxtTotalCargos.Text = FormatImporteContable(FG_Grid_SumaCol(Grid1, 5))
        Me.TxtTotalAbonos.Text = FormatImporteContable(FG_Grid_SumaCol(Grid1, 6))
        Me.txtTotalDiferenciaCargosAbonos.Text = FormatImporteContable(valorNumerico(Me.TxtTotalCargos.Text) - valorNumerico(Me.TxtTotalAbonos.Text))
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
                Exit Function
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
                    Me.TxtConcepto1.Enabled = False
                    Me.TxtConcepto2.Enabled = False
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
                MsgBox("Las pólizas no existe. Favor de verificar.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtImportarPoliza.Focus()
                Exit Sub
            End If

            Me.Grid1.AutoRedraw = False
            Me.InicializaGrid()

            dTabla = Me.oPoliza.ObtenerDetalle '.Rows.Count
            Me.Grid1.Rows = 1
            For Each dRow As DataRow In dTabla.Rows
                Me.Grid1.AddItem(dRow("CUENTA_CONTABLE").ToString & Chr(9) & dRow("NOMBRE_CUENTA").ToString & Chr(9) & dRow("CONCEPTO").ToString & Chr(9) & dRow("NATURALEZA_CONTABLE").ToString & Chr(9) & dRow("CARGO").ToString & Chr(9) &
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

#End Region

End Class


