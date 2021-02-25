Option Strict On

Public Class Frm_Contabilidad_IVA_Acreditable_Global

#Region "Variables de control"
    Private Enum enumEstados
        NUEVO
        NUEVO_CON_POLIZA_QUE_SI_EXISTE
        GRABADO
        APLICADO
        CANCELADO
    End Enum

    Private Estado As enumEstados
    Private oIVA As Class_Contabilidad_IVA_Acreditable_Global

    Private _FolioPolizaConsultaExterior As String = ""
    Private _FechaPolizaConsultaExterior As Date = Now
#End Region

#Region "Campos grid"
    Private IGyFolioCompra As Integer = 1
    Private iGyCodigoProveedor As Integer = 2
    Private iGyNombreProveedor As Integer = 3
    Private iGyFolioProveedor As Integer = 4
    Private iGyFechaProveedor As Integer = 5
    Private iGyConcepto As Integer = 6
    Private iGyPeriodo As Integer = 7
    Private iGyAño As Integer = 8
    Private iGyOperaciones As Integer = 9
    Private iGyActosExento As Integer = 10
    Private iGyActos0 As Integer = 11
    Private iGyActos8 As Integer = 12
    Private iGyActos11 As Integer = 13
    Private iGyActos16 As Integer = 14
    Private iGySubtotalActos As Integer = 15
    Private iGyIvaAcreditable8 As Integer = 16
    Private iGyIvaAcreditable11 As Integer = 17
    Private iGyIvaAcreditable16 As Integer = 18
    Private iGyIvaRetenido4 As Integer = 19
    Private iGyIvaRetenido6 As Integer = 20
    Private iGyIvaRetenido10 As Integer = 21
    Private iGyIDDetalle As Integer = 22
    Private iGyEMISOR_NOMBRE As Integer = 23
    Private iGyEMISOR_RFC As Integer = 24
    Private iGyUUID As Integer = 25
    Private iGyIEPS As Integer = 26
    Private iGyIMPUESTO_HOTEL As Integer = 27
    Private iGyISR_RETENIDO As Integer = 28
    Private iGyTOTAL_XML As Integer = 29
#End Region

#Region "Propiedades"
    Public WriteOnly Property FolioPolizaConsultaExterior() As String
        Set(ByVal Value As String)
            Me._FolioPolizaConsultaExterior = Value
        End Set
    End Property

    Public WriteOnly Property FechaPolizaConsultaExterior() As Date
        Set(ByVal Value As Date)
            Me._FechaPolizaConsultaExterior = Value
        End Set
    End Property
#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Me.Grabar() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAplicar.Click
        If Me.Aplicar() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
        If Me.Cancelar() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbReactivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbReactivar.Click
        If Reactivar() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "Eventos de objetos"
#Region "Eventos"
    Private Sub Frm_Contabilidad_IVA_Acreditable_General_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)

        If txtLEN(Me._FolioPolizaConsultaExterior) = True Then
            Me.txtFolio.Text = Me._FolioPolizaConsultaExterior
            Me.dtFechaControl.Value = Me._FechaPolizaConsultaExterior
            Me.Consultar()
        End If
    End Sub

    Private Sub txtFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolio.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
busca:
                Dim Busqueda = New Frm_Contabilidad_Busqueda_Polizas("FOLIO_POLIZA AS POLIZA,CONCEPTO1 AS CONCEPTO,FECHA,ESTATUS_POLIZA AS ESTATUS", "CON_POLIZAS_GLOBAL", "", "Poliza", "Fecha,Folio_poliza")
                Busqueda.ShowDialog()
                Me.txtFolio.Text = "" & Busqueda.Tag.ToString
                Busqueda.Dispose()
            Case Keys.Return
                If txtLEN(Me.txtFolio.Text) = False Then GoTo busca : Exit Sub
                Me.Consultar()
        End Select
    End Sub

    Private Sub txtConcepto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtConcepto.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.Grid.Cell(1, 1).SetFocus()
            Me.Grid.Focus()
        End If
    End Sub

    Private Sub Grid_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F6
                    If (Me.Estado = enumEstados.NUEVO_CON_POLIZA_QUE_SI_EXISTE Or Me.Estado = enumEstados.GRABADO) And Me.Grid.ActiveCell.Row > 0 Then
                        GestionaDetalle()
                    End If
                Case Keys.Delete, Keys.F8
                    If (Me.Estado = enumEstados.NUEVO_CON_POLIZA_QUE_SI_EXISTE Or Me.Estado = enumEstados.GRABADO) And Me.Grid.ActiveCell.Row > 0 And txtLEN(Me.Grid.Cell(Me.Grid.ActiveCell.Row, Me.iGyCodigoProveedor).Text) = True Then
                        Me.Grid.RemoveItem(Me.Grid.ActiveCell.Row)
                        Me.Totaliza()
                    End If
            End Select
        Catch ex As Exception
            HandleError(Me.Text, "Grid_KeyDown", ex)
        End Try
    End Sub

    Private Sub chkOcultarIVA11_Click(sender As Object, e As EventArgs) Handles chkOcultarIVA11.Click
        Me.OcultaIVA11()
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFolio.Enter, txtConcepto.Enter
        Dim oTexBox As TextBox = CType(sender, TextBox)
        oTexBox.SelectAll()
    End Sub

    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolio.KeyPress, txtConcepto.KeyPress
        txtNoBeep(e)
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.txtFolio.Text = ""
            Me.dtFechaCaptura.Value = Now
            Me.dtFechaControl.Value = Now
            Me.lblEstatus.Text = "N"
            Me.txtConcepto.Text = ""

            Me.lblIvaAcreditableACubrir8.Text = FormatImporteContable(0)
            Me.lblIvaAcreditableACubrir11.Text = FormatImporteContable(0)
            Me.lblIvaAcreditableACubrir16.Text = FormatImporteContable(0)

            Me.lblTotalActos0.Text = FormatImporteContable(0)
            Me.lblTotalActos8.Text = FormatImporteContable(0)
            Me.lblTotalActos11.Text = FormatImporteContable(0)
            Me.lblTotalActos16.Text = FormatImporteContable(0)
            Me.lblTotalActos.Text = FormatImporteContable(0)

            Me.lblTotalIvaAcreditable8.Text = FormatImporteContable(0)
            Me.lblTotalIvaAcreditable11.Text = FormatImporteContable(0)
            Me.lblTotalIvaAcreditable16.Text = FormatImporteContable(0)
            Me.lblTotalIvaRetenido4.Text = FormatImporteContable(0)
            Me.lblTotalIvaRetenido6.Text = FormatImporteContable(0)
            Me.lblTotalIvaRetenido10.Text = FormatImporteContable(0)

            Me.lblTotalIEPS.Text = FormatImporteContable(0)
            Me.lblTotalISRRetenido.Text = FormatImporteContable(0)
            Me.lblTotalXML.Text = FormatImporteContable(0)

            Me.InicializaGrid()
        Catch ex As Exception
            HandleError(Me.Text, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Try
            Me.Grid.DataSource = Nothing
            FG_Grid_Limpiar(Grid)

            Me.Grid.Rows = 2
            Me.Grid.Cols = 30

            Me.FormateaGrid()
        Catch ex As Exception
            HandleError(Me.Text, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try

            'Me.Grid1.Column(3).CellType = FlexCell.CellTypeEnum.Calendar
            'Me.Grid1.DisplayDateTimeMask = True
            'Me.Grid1.Column(3).FormatString = "dd/MMM/yy"

            Me.Grid.Column(Me.IGyFolioCompra).Width = 75
            Me.Grid.Column(Me.iGyCodigoProveedor).Width = 60
            Me.Grid.Column(Me.iGyNombreProveedor).Width = 120
            Me.Grid.Column(Me.iGyFolioProveedor).Width = 75
            Me.Grid.Column(Me.iGyFechaProveedor).Width = 70
            Me.Grid.Column(Me.iGyConcepto).Width = 80
            Me.Grid.Column(Me.iGyPeriodo).Width = 40
            Me.Grid.Column(Me.iGyAño).Width = 30
            Me.Grid.Column(Me.iGyOperaciones).Width = 30
            Me.Grid.Column(Me.iGyActosExento).Width = 80
            Me.Grid.Column(Me.iGyActos0).Width = 80
            Me.Grid.Column(Me.iGyActos8).Width = 80
            Me.Grid.Column(Me.iGyActos11).Width = 80
            Me.Grid.Column(Me.iGyActos16).Width = 80
            Me.Grid.Column(Me.iGySubtotalActos).Width = 80
            Me.Grid.Column(Me.iGyIvaAcreditable8).Width = 80
            Me.Grid.Column(Me.iGyIvaAcreditable11).Width = 80
            Me.Grid.Column(Me.iGyIvaAcreditable16).Width = 80
            Me.Grid.Column(Me.iGyIvaRetenido4).Width = 80
            Me.Grid.Column(Me.iGyIvaRetenido6).Width = 80
            Me.Grid.Column(Me.iGyIvaRetenido10).Width = 80
            Me.Grid.Column(Me.iGyIDDetalle).Visible = False
            Me.Grid.Column(Me.iGyEMISOR_NOMBRE).Width = 80
            Me.Grid.Column(Me.iGyEMISOR_RFC).Width = 80
            Me.Grid.Column(Me.iGyUUID).Width = 80
            Me.Grid.Column(Me.iGyIEPS).Width = 80
            Me.Grid.Column(Me.iGyIMPUESTO_HOTEL).Width = 80
            Me.Grid.Column(Me.iGyISR_RETENIDO).Width = 80
            Me.Grid.Column(Me.iGyTOTAL_XML).Width = 80

            Me.Grid.Cell(0, Me.IGyFolioCompra).Text = "Folio CO/CA"
            Me.Grid.Cell(0, Me.iGyCodigoProveedor).Text = "Cod Prov"
            Me.Grid.Cell(0, Me.iGyNombreProveedor).Text = "Proveedor"
            Me.Grid.Cell(0, Me.iGyFolioProveedor).Text = "Folio Prov"
            Me.Grid.Cell(0, Me.iGyFechaProveedor).Text = "Fecha Prov"
            Me.Grid.Cell(0, Me.iGyConcepto).Text = "Concepto"
            Me.Grid.Cell(0, Me.iGyPeriodo).Text = "Periodo"
            Me.Grid.Cell(0, Me.iGyAño).Text = "Año"
            Me.Grid.Cell(0, Me.iGyOperaciones).Text = "Ops"
            Me.Grid.Cell(0, Me.iGyActosExento).Text = "Actos exento"
            Me.Grid.Cell(0, Me.iGyActos0).Text = "Actos al 0%"
            Me.Grid.Cell(0, Me.iGyActos8).Text = "Actos al 8%"
            Me.Grid.Cell(0, Me.iGyActos11).Text = "Actos al 11%"
            Me.Grid.Cell(0, Me.iGyActos16).Text = "Actos al 16%"
            Me.Grid.Cell(0, Me.iGySubtotalActos).Text = "Actos Total"
            Me.Grid.Cell(0, Me.iGyIvaAcreditable8).Text = "IVA acred.8%"
            Me.Grid.Cell(0, Me.iGyIvaAcreditable11).Text = "IVA acred.11%"
            Me.Grid.Cell(0, Me.iGyIvaAcreditable16).Text = "IVA acred.16%"
            Me.Grid.Cell(0, Me.iGyIvaRetenido4).Text = "IVA ret.4%"
            Me.Grid.Cell(0, Me.iGyIvaRetenido6).Text = "IVA ret.6%"
            Me.Grid.Cell(0, Me.iGyIvaRetenido10).Text = "IVA ret.10%"
            Me.Grid.Cell(0, Me.iGyIDDetalle).Text = "IDDetalle"
            Me.Grid.Cell(0, Me.iGyEMISOR_NOMBRE).Text = "Emisor"
            Me.Grid.Cell(0, Me.iGyEMISOR_RFC).Text = "RFC"
            Me.Grid.Cell(0, Me.iGyUUID).Text = "UUID"
            Me.Grid.Cell(0, Me.iGyIEPS).Text = "IEPS"
            Me.Grid.Cell(0, Me.iGyIMPUESTO_HOTEL).Text = "ISH"
            Me.Grid.Cell(0, Me.iGyISR_RETENIDO).Text = "ISR Ret"
            Me.Grid.Cell(0, Me.iGyTOTAL_XML).Text = "Total XML"

            Me.Grid.Column(Me.iGyFechaProveedor).CellType = FlexCell.CellTypeEnum.Calendar
            Me.Grid.Column(Me.iGyFechaProveedor).FormatString = "dd/MMM/yy"
            'Me.Grid.DisplayDateTimeMask = True

            Me.Grid.Column(Me.iGyPeriodo).Alignment = FlexCell.AlignmentEnum.RightCenter
            Me.Grid.Column(Me.iGyAño).Alignment = FlexCell.AlignmentEnum.RightCenter
            Me.Grid.Column(Me.iGyOperaciones).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyActosExento).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyActosExento).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyActosExento).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyActosExento).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyActos0).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyActos0).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyActos0).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyActos0).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyActos8).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyActos8).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyActos8).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyActos8).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyActos11).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyActos11).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyActos11).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyActos11).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyActos16).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyActos16).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyActos16).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyActos16).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGySubtotalActos).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGySubtotalActos).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGySubtotalActos).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGySubtotalActos).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyIvaAcreditable8).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyIvaAcreditable8).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyIvaAcreditable8).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyIvaAcreditable8).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyIvaAcreditable11).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyIvaAcreditable11).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyIvaAcreditable11).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyIvaAcreditable11).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyIvaAcreditable16).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyIvaAcreditable16).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyIvaAcreditable16).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyIvaAcreditable16).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyIvaRetenido4).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyIvaRetenido4).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyIvaRetenido4).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyIvaRetenido4).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyIvaRetenido6).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyIvaRetenido6).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyIvaRetenido6).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyIvaRetenido6).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyIvaRetenido10).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyIvaRetenido10).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyIvaRetenido10).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyIvaRetenido10).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyIEPS).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyIEPS).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyIEPS).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyIEPS).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyIMPUESTO_HOTEL).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyIMPUESTO_HOTEL).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyIMPUESTO_HOTEL).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyIMPUESTO_HOTEL).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyISR_RETENIDO).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyISR_RETENIDO).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyISR_RETENIDO).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyISR_RETENIDO).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyTOTAL_XML).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
            Me.Grid.Column(Me.iGyTOTAL_XML).Mask = FlexCell.MaskEnum.Numeric
            Me.Grid.Column(Me.iGyTOTAL_XML).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
            Me.Grid.Column(Me.iGyTOTAL_XML).Alignment = FlexCell.AlignmentEnum.RightCenter

            Me.Grid.Column(Me.iGyActos11).Visible = False
            Me.Grid.Column(Me.iGyIvaAcreditable11).Visible = False

            Me.Grid.Locked = True

        Catch ex As Exception
            HandleError(Me.Text, "FormateaGrid", ex)
        End Try

    End Sub

    Private Sub GestionaCambioEstado()
        Select Case Me.lblEstatus.Text
            Case "G"
                Me.Cambia_Estado(enumEstados.GRABADO)
            Case "A"
                Me.Cambia_Estado(enumEstados.APLICADO)
            Case "C"
                Me.Cambia_Estado(enumEstados.CANCELADO)
        End Select
    End Sub

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Try
            Me.Estado = pEstado
            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbAplicar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbReactivar.Enabled = False

                    Me.txtFolio.Enabled = True
                    Me.gbDatosGenerales.Enabled = True
                    Me.dtFechaControl.Enabled = True

                    Me.tssElaboro.Visible = False

                    Me.tssEstado.Text = "Estado: agregando IVA acreditable"

                    If Me.Visible = True Then
                        Me.txtFolio.Focus()
                    End If

                Case enumEstados.NUEVO_CON_POLIZA_QUE_SI_EXISTE
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    Me.tsbAplicar.Enabled = True
                    Me.tsbCancelar.Enabled = False
                    Me.tsbReactivar.Enabled = False

                    Me.txtFolio.Enabled = False
                    Me.gbDatosGenerales.Enabled = True
                    Me.dtFechaControl.Enabled = True

                    Me.tssElaboro.Visible = False

                    Me.tssEstado.Text = "Estado: agregando IVA acreditable"

                    If Me.Visible = True Then
                        Me.txtConcepto.Focus()
                    End If

                Case enumEstados.GRABADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    Me.tsbAplicar.Enabled = True
                    Me.tsbCancelar.Enabled = True
                    Me.tsbReactivar.Enabled = False

                    Me.txtFolio.Enabled = False
                    Me.gbDatosGenerales.Enabled = True
                    Me.dtFechaControl.Enabled = True

                    Me.tssElaboro.Visible = True

                    Me.tssEstado.Text = "Estado: consultando IVA acreditable"

                    If Me.Visible = True Then
                        Me.tsbNuevo.Select()
                    End If

                Case enumEstados.APLICADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbAplicar.Enabled = False
                    Me.tsbCancelar.Enabled = True
                    Me.tsbReactivar.Enabled = False

                    Me.txtFolio.Enabled = False
                    Me.gbDatosGenerales.Enabled = False
                    Me.dtFechaControl.Enabled = False

                    Me.tssElaboro.Visible = True

                    Me.tssEstado.Text = "Estado: consultando IVA acreditable"

                    If Me.Visible = True Then
                        Me.tsbNuevo.Select()
                    End If

                Case enumEstados.CANCELADO
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    Me.tsbAplicar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    Me.tsbReactivar.Enabled = True

                    Me.txtFolio.Enabled = False
                    Me.gbDatosGenerales.Enabled = False
                    Me.dtFechaControl.Enabled = False

                    Me.tssElaboro.Visible = True

                    Me.tssEstado.Text = "Estado: consultando IVA acreditable"

                    If Me.Visible = True Then
                        Me.tsbNuevo.Select()
                    End If

            End Select
            Application.DoEvents()

        Catch ex As Exception
            HandleError(Me.Text, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim sFolio As String = Me.txtFolio.Text, dTabla As DataTable
        Try
            Me.Inicializa()
            Me.oIVA = New Class_Contabilidad_IVA_Acreditable_Global(sFolio)

            'Me.OcultaIVA11()

            If Me.oIVA.ExisteDocumentoPoliza = False Then
                Me.txtFolio.Text = sFolio
                MsgBox("La póliza no existe.", MsgBoxStyle.Exclamation, Me.Text)
                Me.Cambia_Estado(enumEstados.NUEVO)
                Exit Function
            End If

            Me.txtFolio.Enabled = False

            With Me.oIVA
                Me.txtFolio.Text = .FOLIO_POLIZA
                Me.dtFechaControl.Value = Me._FechaPolizaConsultaExterior
                Me.lblIvaAcreditableACubrir8.Text = FormatImporteContable(.IVAACubrirAl8)
                Me.lblIvaAcreditableACubrir11.Text = FormatImporteContable(.IVAACubrirAl11)
                Me.lblIvaAcreditableACubrir16.Text = FormatImporteContable(.IVAACubrirAl16)
            End With

            'iGyFolioCompra As Integer = 1		    iGyCodigoProveedor As Integer = 2       iGyNombreProveedor As Integer = 3	    
            'iGyFolioProveedor As Integer = 4       iGyFechaProveedor As Integer = 5	    iGyConcepto As Integer = 6              
            'iGyPeriodo As Integer = 7		        iGyAño As Integer = 8                   iGyOperaciones As Integer = 9		    
            'iGyActosExento As Integer = 10         iGyActos0 As Integer = 11		        iGyActos8 As Integer = 12               iGyActos11 As Integer = 13		        iGyActos16 As Integer = 14
            'iGySubtotalActos As Integer = 15	    
            'iGyIvaAcreditable8 As Integer = 16     iGyIvaAcreditable11 As Integer = 17     iGyIvaAcreditable16 As Integer = 18
            'iGyIvaRetenido4 As Integer = 19		iGyIvaRetenido6 As Integer = 20         iGyIvaRetenido10 As Integer = 21	    
            'iGyIDDetalle As Integer = 22
            'iGyEMISOR_NOMBRE As Integer = 23	    iGyEMISOR_RFC As Integer = 24
            'iGyUUID As Integer = 25			    iGyIEPS As Integer = 26                 iGyIMPUESTO_HOTEL As Integer = 27	    iGyISR_RETENIDO As Integer = 28         iGyTOTAL_XML As Integer = 29

            'Si no existe el iva acreditable.
            If Me.oIVA.ExisteDocumentoIVA = False Then
                Me.Grid.Rows = 1
                With Me.oIVA
                    'dTabla = .ObtenerDetalle 'Al no existir el detalle tratará de traer los mismos renglones que el pago, y si no ningun renglon(que seria una póliza directa)
                    dTabla = .PrecargarIVAAcreditable

                    'dRow("PERIODO").ToString & Chr(9) & dRow("ANIO").ToString & Chr(9) & dRow("OPERACIONES").ToString & Chr(9) & 

                    'dRow(5) Es el concepto del documento de CXP que se pagó
                    For Each dRow As DataRow In dTabla.Rows
                        Me.Grid.AddItem(dRow("FOLIO_MOVIMIENTO").ToString & Chr(9) & dRow("CODIGO_PROVEEDOR").ToString & Chr(9) & dRow("NOMBRE_PROVEEDOR").ToString & Chr(9) &
                                        dRow("FOLIO").ToString & Chr(9) & dRow("FECHA_FACTURA_PROVEEDOR").ToString & Chr(9) & dRow("CONCEPTO").ToString.Replace(vbTab, " ").ToString & Chr(9) &
                                        "0" & Chr(9) & "0" & Chr(9) & "0" & Chr(9) &
                                        dRow("ACTOS_EXENTOS").ToString & Chr(9) & dRow("ACTOS_AL_0").ToString & Chr(9) & dRow("ACTOS_AL_8").ToString & Chr(9) & "0" & Chr(9) & dRow("ACTOS_AL_16").ToString & Chr(9) &
                                        dRow("SUBTOTAL_ACTOS").ToString & Chr(9) &
                                        dRow("IVA_ACREDITABLE_AL_8").ToString & Chr(9) & "0" & Chr(9) & dRow("IVA_ACREDITABLE_AL_16").ToString & Chr(9) &
                                        dRow("IVA_RETENIDO_AL_4").ToString & Chr(9) & dRow("IVA_RETENIDO_AL_6").ToString & Chr(9) & dRow("IVA_RETENIDO_AL_10").ToString & Chr(9) &
                                        "0" & Chr(9) &
                                        dRow("EMISOR_NOMBRE").ToString & Chr(9) & dRow("EMISOR_RFC").ToString & Chr(9) &
                                        dRow("UUID").ToString & Chr(9) & dRow("IEPS").ToString & Chr(9) & dRow("IMPUESTO_HOTEL").ToString & Chr(9) & dRow("ISR_RETENIDO").ToString & Chr(9) & dRow("TOTAL").ToString & Chr(9))
                    Next
                End With

                'If Me.Grid.Rows > 1 Then 'Para que agregue otro renglón nuevo en blanco
                Me.Grid.Rows += 1
                'End If

                Me.Totaliza()

                Me.Cambia_Estado(enumEstados.NUEVO_CON_POLIZA_QUE_SI_EXISTE)
                Exit Function
            End If

            Me.Grid.Rows = 1

            With Me.oIVA
                Me.dtFechaCaptura.Value = .FECHA_SERVIDOR
                Me.dtFechaControl.Value = .FECHA
                Me.lblEstatus.Text = .ESTATUS
                Me.txtConcepto.Text = .CONCEPTO

                Me.lblTotalActos0.Text = FormatImporteContable(.TOTAL_ACTOS_AL_0)
                Me.lblTotalActos8.Text = FormatImporteContable(.TOTAL_ACTOS_AL_8)
                Me.lblTotalActos11.Text = FormatImporteContable(.TOTAL_ACTOS_AL_11)
                Me.lblTotalActos16.Text = FormatImporteContable(.TOTAL_ACTOS_AL_16)
                Me.lblTotalActosExento.Text = FormatImporteContable(.TOTAL_ACTOS_IVA_EXENTO)
                Me.lblTotalActos.Text = FormatImporteContable(.TOTAL_ACTOS)

                Me.lblTotalIvaAcreditable8.Text = FormatImporteContable(.TOTAL_IVA_ACREDITABLE_AL_8)
                Me.lblTotalIvaAcreditable11.Text = FormatImporteContable(.TOTAL_IVA_ACREDITABLE_AL_11)
                Me.lblTotalIvaAcreditable16.Text = FormatImporteContable(.TOTAL_IVA_ACREDITABLE_AL_16)
                Me.lblTotalIvaRetenido4.Text = FormatImporteContable(.TOTAL_IVA_RETENIDO_AL_4)
                Me.lblTotalIvaRetenido6.Text = FormatImporteContable(.TOTAL_IVA_RETENIDO_AL_6)
                Me.lblTotalIvaRetenido10.Text = FormatImporteContable(.TOTAL_IVA_RETENIDO_AL_10)

                dTabla = .ObtenerDetalle

                For Each dRow As DataRow In dTabla.Rows
                    'Me.Grid.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9) & _
                    '                dRow(5).ToString.Replace(vbTab, " ").ToString & Chr(9) & _
                    '                dRow(6).ToString & Chr(9) & dRow(7).ToString & Chr(9) & dRow(8).ToString & Chr(9) & dRow(9).ToString & Chr(9) & _
                    '                dRow(10).ToString & Chr(9) & dRow(11).ToString & Chr(9) & dRow(12).ToString & Chr(9) & dRow(13).ToString & Chr(9) & dRow(14).ToString & Chr(9) & _
                    '                dRow(15).ToString & Chr(9) & dRow(16).ToString & Chr(9) & dRow(17).ToString & Chr(9) & dRow(18).ToString & Chr(9) & dRow(19).ToString & Chr(9) & _
                    '                dRow(20).ToString & Chr(9) & dRow(21).ToString & Chr(9))
                    Me.Grid.AddItem(dRow("FOLIO_MOVIMIENTO").ToString & Chr(9) & dRow("CODIGO_PROVEEDOR").ToString & Chr(9) & dRow("NOMBRE_PROVEEDOR").ToString & Chr(9) &
                                    dRow("FOLIO_PROVEEDOR").ToString & Chr(9) & dRow("FECHA_FACTURA_PROVEEDOR").ToString & Chr(9) & dRow("CONCEPTO").ToString.Replace(vbTab, " ").ToString & Chr(9) &
                                    dRow("PERIODO").ToString & Chr(9) & dRow("ANIO").ToString & Chr(9) & dRow("OPERACIONES").ToString & Chr(9) & dRow("ACTOS_IVA_EXENTO").ToString & Chr(9) &
                                    dRow("ACTOS_AL_0").ToString & Chr(9) & dRow("ACTOS_AL_8").ToString & Chr(9) & dRow("ACTOS_AL_11").ToString & Chr(9) & dRow("ACTOS_AL_16").ToString & Chr(9) &
                                    dRow("SUBTOTAL_ACTOS").ToString & Chr(9) & dRow("IVA_ACREDITABLE_AL_8").ToString & Chr(9) & dRow("IVA_ACREDITABLE_AL_11").ToString & Chr(9) &
                                    dRow("IVA_ACREDITABLE_AL_16").ToString & Chr(9) & dRow("IVA_RETENIDO_AL_4").ToString & Chr(9) & dRow("IVA_RETENIDO_AL_6").ToString & Chr(9) &
                                    dRow("IVA_RETENIDO_AL_10").ToString & Chr(9) & dRow("ID_CON_IVA_ACREDITABLE_DETALLE").ToString & Chr(9) &
                                    dRow("EMISOR_NOMBRE").ToString & Chr(9) & dRow("EMISOR_RFC").ToString & Chr(9) &
                                    dRow("UUID").ToString & Chr(9) & dRow("IEPS").ToString & Chr(9) & dRow("IMPUESTO_HOTEL").ToString & Chr(9) & dRow("ISR_RETENIDO").ToString & Chr(9) & dRow("TOTAL_XML").ToString & Chr(9))
                Next

                'No es posible hace un datasource y luego intentar cambiar datos de celdas con codigo, no marca error pero no hace el cambio, por eso
                'Me.Grid.DataSource = .ObtenerDetalle

                Me.FormateaGrid()

                Me.Grid.Rows += 1

                Me.tssElaboro.Text = "Elaboró : " & .NOMBRE_USUARIO_GRABO & " el " & Format(.FECHA_SERVIDOR, "dd-MMM-yyyy hh:mm tt")
            End With

            Me.GestionaCambioEstado()
            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try

        Return bResultado
    End Function

    Private Function Validar(Optional ByVal bValidarPermisoUsuario As Boolean = True) As Boolean

        If Plaza.ValidarPeriodoTrabajo(Me.oIVA.FECHA_POLIZA) = False Then
            Exit Function
        End If

        'If bValidarPermisoUsuario = True Then
        '    If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.CmbDocumento.SelectedValue.ToString) = False Then
        '        MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
        '        Exit Function
        '    End If
        'End If

        Select Case Me.lblEstatus.Text
            Case "N", "G"
                'No hay restricciones
            Case "A"
                MsgBox("Las pólias aplicadas no pueden modificarse.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            Case "C"
                MsgBox("Las pólizas canceladas no pueden modificarse.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
        End Select

        If valorNumerico(Me.lblTotalActos.Text) <= 0 Then
            MsgBox("No ha agregado registros del IVA acreditable.", vbExclamation, Me.Text)
            Exit Function
        End If

        Validar = True

    End Function

    Private Function Grabar(Optional ByVal bConfirmacion As Boolean = True) As Boolean
        Dim i As Integer = 0, bGraboGlobal As Boolean = False

        If bConfirmacion = True Then
            If MsgBox("¿Desea grabar el IVA acreditable de la póliza " & Me.txtFolio.Text & " ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                Exit Function
            End If
        End If

        Try
            'If Validar(CBool(IIf(Me._ChildParaGrabar = True, False, True))) = False Then
            If Validar() = False Then
                Exit Function
            End If

            With Me.oIVA
                .FECHA = Me.dtFechaControl.Value
                .CODIGO_USUARIO_GRABO = Usuario.Codigo_Usuario
                .CONCEPTO = Me.txtConcepto.Text.ToUpper
                .TOTAL_ACTOS_AL_0 = valorNumerico(Me.lblTotalActos0.Text)
                .TOTAL_ACTOS_AL_8 = valorNumerico(Me.lblTotalActos8.Text)
                .TOTAL_ACTOS_AL_11 = valorNumerico(Me.lblTotalActos11.Text)
                .TOTAL_ACTOS_AL_16 = valorNumerico(Me.lblTotalActos16.Text)
                .TOTAL_ACTOS_IVA_EXENTO = valorNumerico(Me.lblTotalActosExento.Text)
                .TOTAL_ACTOS = valorNumerico(Me.lblTotalActos.Text)
                .TOTAL_IVA_ACREDITABLE_AL_8 = valorNumerico(Me.lblTotalIvaAcreditable8.Text)
                .TOTAL_IVA_ACREDITABLE_AL_11 = valorNumerico(Me.lblTotalIvaAcreditable11.Text)
                .TOTAL_IVA_ACREDITABLE_AL_16 = valorNumerico(Me.lblTotalIvaAcreditable16.Text)
                .TOTAL_IVA_RETENIDO_AL_4 = valorNumerico(Me.lblTotalIvaRetenido4.Text)
                .TOTAL_IVA_RETENIDO_AL_6 = valorNumerico(Me.lblTotalIvaRetenido6.Text)
                .TOTAL_IVA_RETENIDO_AL_10 = valorNumerico(Me.lblTotalIvaRetenido10.Text)

                bGraboGlobal = .GrabaIVAAcreditableGlobal

                If bGraboGlobal = False Then
                    Exit Function
                End If

                'Graba el detalle
                For i = 1 To Me.Grid.Rows - 1
                    If txtLEN(Me.Grid.Cell(i, Me.iGyCodigoProveedor).Text) = True Then
                        .NuevoRenglon()
                        .oIVADetalle.CODIGO_PROVEEDOR = Me.Grid.Cell(i, Me.iGyCodigoProveedor).Text.ToUpper
                        .oIVADetalle.FOLIO_PROVEEDOR = Me.Grid.Cell(i, Me.iGyFolioProveedor).Text.ToUpper
                        .oIVADetalle.PERIODO = CInt(Me.Grid.Cell(i, Me.iGyPeriodo).Text)
                        .oIVADetalle.ANIO = CInt(Me.Grid.Cell(i, Me.iGyAño).Text)
                        .oIVADetalle.OPERACIONES = CInt(Me.Grid.Cell(i, Me.iGyOperaciones).Text)
                        .oIVADetalle.ACTOS_IVA_EXENTO = valorNumerico(Me.Grid.Cell(i, Me.iGyActosExento).Text)
                        .oIVADetalle.ACTOS_AL_0 = valorNumerico(Me.Grid.Cell(i, Me.iGyActos0).Text)
                        .oIVADetalle.ACTOS_AL_8 = valorNumerico(Me.Grid.Cell(i, Me.iGyActos8).Text)
                        .oIVADetalle.ACTOS_AL_10 = 0
                        .oIVADetalle.ACTOS_AL_15 = 0
                        .oIVADetalle.ACTOS_AL_11 = valorNumerico(Me.Grid.Cell(i, Me.iGyActos11).Text)
                        .oIVADetalle.ACTOS_AL_16 = valorNumerico(Me.Grid.Cell(i, Me.iGyActos16).Text)
                        .oIVADetalle.SUBTOTAL_ACTOS = valorNumerico(Me.Grid.Cell(i, Me.iGySubtotalActos).Text)
                        .oIVADetalle.IVA_ACREDITABLE_AL_8 = valorNumerico(Me.Grid.Cell(i, Me.iGyIvaAcreditable8).Text)
                        .oIVADetalle.IVA_ACREDITABLE_AL_10 = 0
                        .oIVADetalle.IVA_ACREDITABLE_AL_15 = 0
                        .oIVADetalle.IVA_ACREDITABLE_AL_11 = valorNumerico(Me.Grid.Cell(i, Me.iGyIvaAcreditable11).Text)
                        .oIVADetalle.IVA_ACREDITABLE_AL_16 = valorNumerico(Me.Grid.Cell(i, Me.iGyIvaAcreditable16).Text)
                        .oIVADetalle.IVA_RETENIDO_AL_4 = valorNumerico(Me.Grid.Cell(i, Me.iGyIvaRetenido4).Text)
                        .oIVADetalle.IVA_RETENIDO_AL_6 = valorNumerico(Me.Grid.Cell(i, Me.iGyIvaRetenido6).Text)
                        .oIVADetalle.IVA_RETENIDO_AL_10 = valorNumerico(Me.Grid.Cell(i, Me.iGyIvaRetenido10).Text)
                        .oIVADetalle.FOLIO_COMPRA = Me.Grid.Cell(i, Me.IGyFolioCompra).Text.ToUpper
                        .oIVADetalle.FECHA_FACTURA_PROVEEDOR = CDate(Me.Grid.Cell(i, Me.iGyFechaProveedor).Text)
                        .oIVADetalle.CONCEPTO = Me.Grid.Cell(i, Me.iGyConcepto).Text.ToUpper

                        .oIVADetalle.GrabaIVAAcreditableDetalle()
                    End If
                Next i

                Me.lblEstatus.Text = "G"
                Grabar = True

                If bConfirmacion = True Then
                    MsgBox("IVA acreditable de la póliza " & Me.txtFolio.Text & " grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
                End If

            End With

        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try

    End Function

    Private Function Aplicar() As Boolean
        If MsgBox("¿Desea grabar y aplicar el IVA acreditable de la póliza " & Me.txtFolio.Text & " ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
            Exit Function
        End If

        Try
            If Me.Grabar(False) = False Then
                Exit Function
            End If

            Select Case Me.lblEstatus.Text
                Case "N"
                    MsgBox("El movimiento del IVA acreditable no existe.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                Case "G"
                    'No hay restricciones
                Case "A"
                    MsgBox("El movimiento del IVA acreditable no se puede aplicar de nuevo.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                Case "C"
                    MsgBox("El movimiento del IVA acreditable esta cancelado, no se pueden aplicar.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
            End Select


            Aplicar = Me.oIVA.AplicaIVAAcreditable

            If Aplicar = True Then
                MsgBox("IVA acreditable de la póliza " & Me.txtFolio.Text & " aplicado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Aplicar", ex)
        End Try
    End Function

    Private Function Cancelar() As Boolean
        If MsgBox("¿Desea cancelar el IVA acreditable de la póliza " & Me.txtFolio.Text & " ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
            Exit Function
        End If

        If Plaza.ValidarPeriodoTrabajo(Me.oIVA.FECHA_POLIZA) = False Then
            Exit Function
        End If

        'If bValidarPermisoUsuario = True Then
        '    If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.CmbDocumento.SelectedValue.ToString) = False Then
        '        MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
        '        Exit Function
        '    End If
        'End If

        Try
            Select Case Me.lblEstatus.Text
                Case "N"
                    MsgBox("El movimiento del IVA acreditable no existe.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                Case "G"
                    'No hay restricciones
                Case "A"
                    'No hay restricciones
                Case "C"
                    MsgBox("El movimiento del IVA acreditable ya esta cancelado, no se puede cancella nuevamente.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
            End Select

            Cancelar = Me.oIVA.CancelaIVAAcreditable

            If Cancelar = True Then
                MsgBox("IVA acreditable de la póliza " & Me.txtFolio.Text & " cancelado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Cancelar", ex)
        End Try
    End Function

    Private Function Reactivar() As Boolean
        If MsgBox("¿Desea reactivar el IVA acreditable de la póliza " & Me.txtFolio.Text & " ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
            Exit Function
        End If

        If Plaza.ValidarPeriodoTrabajo(Me.oIVA.FECHA_POLIZA) = False Then
            Exit Function
        End If

        'If bValidarPermisoUsuario = True Then
        '    If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.CmbDocumento.SelectedValue.ToString) = False Then
        '        MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
        '        Exit Function
        '    End If
        'End If

        Try
            Select Case Me.lblEstatus.Text
                Case "N"
                    MsgBox("El movimiento del IVA acreditable no existe.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                Case "G"
                    MsgBox("Sólo movimientos de IVA acreditable cancelados se pueden reactivar.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                Case "A"
                    MsgBox("Sólo movimientos de IVA acreditable cancelados se pueden reactivar.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                Case "C"
                    'No hay restricciones
            End Select

            Reactivar = Me.oIVA.ReactivaIVAAcreditable

            If Reactivar = True Then
                MsgBox("IVA acreditable de la póliza " & Me.txtFolio.Text & " reactivado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Reactivar", ex)
        End Try
    End Function

    Private Function GestionaDetalle() As Boolean
        Dim f As New Frm_Contabilidad_IVA_Acreditable_Detalle
        Dim iRenglon As Integer, bNuevoRenglon As Boolean = False

        iRenglon = Me.Grid.ActiveCell.Row

        Try
            With f
                .Inicializa()

                f.lblIvaAcreditableACubrir8.Text = Me.lblIvaAcreditableACubrir8.Text
                f.lblIvaAcreditableACubrir11.Text = Me.lblIvaAcreditableACubrir11.Text
                f.lblIvaAcreditableACubrir16.Text = Me.lblIvaAcreditableACubrir16.Text
                f.lblIvaAcreditableAcumulado8.Text = Me.lblTotalIvaAcreditable8.Text
                f.lblIvaAcreditableAcumulado11.Text = Me.lblTotalIvaAcreditable11.Text
                f.lblIvaAcreditableAcumulado16.Text = Me.lblTotalIvaAcreditable16.Text

                .Inicia()

                If txtLEN(Me.Grid.Cell(iRenglon, Me.iGyCodigoProveedor).Text) = True Then

                    Dim oProveedor As New Class_CatProveedores(Me.Grid.Cell(iRenglon, Me.iGyCodigoProveedor).Text)
                    .txtProveedor.Text = oProveedor.Codigo_Proveedor
                    .lblProveedorRFC.Text = oProveedor.RFC
                    .lblProveedorNombre.Text = oProveedor.Nombre_Proveedor
                    .cboTipoProveedor.Text = oProveedor.NOMBRE_TIPO_PROVEEDOR
                    oProveedor = Nothing

                    .txtFolio.Text = Me.Grid.Cell(iRenglon, Me.iGyFolioProveedor).Text
                    .dtFechaFacturaProveedor.Value = CDate(Me.Grid.Cell(iRenglon, Me.iGyFechaProveedor).Text)
                    .txtConcepto.Text = Me.Grid.Cell(iRenglon, Me.iGyConcepto).Text

                    .cboMes.Text = Me.Grid.Cell(iRenglon, Me.iGyPeriodo).Text

                    .txtAño.Text = Me.Grid.Cell(iRenglon, Me.iGyAño).Text
                    If .txtAño.TextLength = 0 Then
                        .txtAño.Text = Date.Now.Year.ToString()
                    End If

                    .txtNumeroOperaciones.Text = Me.Grid.Cell(iRenglon, Me.iGyOperaciones).Text
                    If .txtNumeroOperaciones.TextLength = 0 Then
                        .txtNumeroOperaciones.Text = "1"
                    End If

                    .txtActos0.Text = FormatImporteContable(CDbl(Me.Grid.Cell(iRenglon, Me.iGyActos0).Text))
                    .txtActos8.Text = FormatImporteContable(CDbl(Me.Grid.Cell(iRenglon, Me.iGyActos8).Text))
                    .txtActos11.Text = FormatImporteContable(CDbl(Me.Grid.Cell(iRenglon, Me.iGyActos11).Text))
                    .txtActos16.Text = FormatImporteContable(CDbl(Me.Grid.Cell(iRenglon, Me.iGyActos16).Text))
                    .txtActosExento.Text = FormatImporteContable(CDbl(Me.Grid.Cell(iRenglon, Me.iGyActosExento).Text))
                    .lblActosTotal.Text = FormatImporteContable(CDbl(Me.Grid.Cell(iRenglon, Me.iGySubtotalActos).Text))
                    .txtIvaAcreditable8.Text = FormatImporteContable(CDbl(Me.Grid.Cell(iRenglon, Me.iGyIvaAcreditable8).Text))
                    .txtIvaAcreditable11.Text = FormatImporteContable(CDbl(Me.Grid.Cell(iRenglon, Me.iGyIvaAcreditable11).Text))
                    .txtIvaAcreditable16.Text = FormatImporteContable(CDbl(Me.Grid.Cell(iRenglon, Me.iGyIvaAcreditable16).Text))
                    .txtIvaRetenido4.Text = FormatImporteContable(CDbl(Me.Grid.Cell(iRenglon, Me.iGyIvaRetenido4).Text))
                    .txtIvaRetenido6.Text = FormatImporteContable(CDbl(Me.Grid.Cell(iRenglon, Me.iGyIvaRetenido6).Text))
                    .txtIvaRetenido10.Text = FormatImporteContable(CDbl(Me.Grid.Cell(iRenglon, Me.iGyIvaRetenido10).Text))
                Else
                    bNuevoRenglon = True
                End If

                f.ShowDialog()

                If f.Valido = True Then
                    Me.Grid.Cell(iRenglon, Me.iGyCodigoProveedor).Text = .txtProveedor.Text.ToUpper
                    Me.Grid.Cell(iRenglon, Me.iGyNombreProveedor).Text = .lblProveedorNombre.Text.ToUpper
                    Me.Grid.Cell(iRenglon, Me.iGyFolioProveedor).Text = .txtFolio.Text.ToUpper
                    Me.Grid.Cell(iRenglon, Me.iGyFechaProveedor).Text = .dtFechaFacturaProveedor.Value.ToString
                    Me.Grid.Cell(iRenglon, Me.iGyConcepto).Text = .txtConcepto.Text.ToUpper

                    Me.Grid.Cell(iRenglon, Me.iGyPeriodo).Text = .cboMes.Text
                    Me.Grid.Cell(iRenglon, Me.iGyAño).Text = .txtAño.Text
                    Me.Grid.Cell(iRenglon, Me.iGyOperaciones).Text = .txtNumeroOperaciones.Text

                    Me.Grid.Cell(iRenglon, Me.iGyActos0).Text = .txtActos0.Text
                    Me.Grid.Cell(iRenglon, Me.iGyActos8).Text = .txtActos8.Text
                    Me.Grid.Cell(iRenglon, Me.iGyActos11).Text = .txtActos11.Text
                    Me.Grid.Cell(iRenglon, Me.iGyActos16).Text = .txtActos16.Text
                    Me.Grid.Cell(iRenglon, Me.iGyActosExento).Text = .txtActosExento.Text
                    Me.Grid.Cell(iRenglon, Me.iGySubtotalActos).Text = .lblActosTotal.Text
                    Me.Grid.Cell(iRenglon, Me.iGyIvaAcreditable8).Text = .txtIvaAcreditable8.Text
                    Me.Grid.Cell(iRenglon, Me.iGyIvaAcreditable11).Text = .txtIvaAcreditable11.Text
                    Me.Grid.Cell(iRenglon, Me.iGyIvaAcreditable16).Text = .txtIvaAcreditable16.Text
                    Me.Grid.Cell(iRenglon, Me.iGyIvaRetenido4).Text = .txtIvaRetenido4.Text
                    Me.Grid.Cell(iRenglon, Me.iGyIvaRetenido6).Text = .txtIvaRetenido6.Text
                    Me.Grid.Cell(iRenglon, Me.iGyIvaRetenido10).Text = .txtIvaRetenido10.Text

                    If bNuevoRenglon = True Then
                        Me.Grid.Rows += 1
                    End If
                End If

            End With
            f.Dispose()

            Me.Totaliza()

        Catch ex As Exception
            HandleError(Me.Name, "GestionaDetalle", ex)
            Me.Grid.Locked = True
        Finally
            f.Dispose()
        End Try
    End Function

    Private Sub Totaliza()
        Try
            Me.lblTotalActos0.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.iGyActos0)))
            Me.lblTotalActos8.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.iGyActos8)))
            Me.lblTotalActos11.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.iGyActos11)))
            Me.lblTotalActos16.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.iGyActos16)))
            Me.lblTotalActosExento.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.iGyActosExento)))
            Me.lblTotalActos.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.iGySubtotalActos)))
            Me.lblTotalIvaAcreditable8.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.iGyIvaAcreditable8)))
            Me.lblTotalIvaAcreditable11.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.iGyIvaAcreditable11)))
            Me.lblTotalIvaAcreditable16.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.iGyIvaAcreditable16)))
            Me.lblTotalIvaRetenido4.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.iGyIvaRetenido4)))
            Me.lblTotalIvaRetenido6.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.iGyIvaRetenido6)))
            Me.lblTotalIvaRetenido10.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.iGyIvaRetenido10)))

            Me.lblTotalIEPS.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.iGyIEPS)))
            Me.lblTotalISRRetenido.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.iGyISR_RETENIDO)))
            Me.lblTotalXML.Text = FormatImporteContable(FG_Grid_SumaCol(Me.Grid, CShort(Me.iGyTOTAL_XML)))
        Catch ex As Exception
            HandleError(Me.Name, "Totaliza", ex)
        End Try
    End Sub

    Private Sub OcultaIVA11()
        Me.Grid.Column(Me.iGyIvaAcreditable11).Visible = Not (Me.chkOcultarIVA11.Checked)
        Me.Grid.Column(Me.iGyActos11).Visible = Not (Me.chkOcultarIVA11.Checked)
    End Sub
#End Region

End Class