Option Strict On

Imports Microsoft.VisualBasic
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmPolizaCostos

#Region "Auxiliares"
    Private Enum enumEstados
        NUEVO
        'GRABADO
        APLICADO
        CANCELADO
    End Enum

    Private Estado As enumEstados
    Private oPoliza As Class_Contabilidad_Poliza_Global
    Private sCodigoTipoDocumento As String = "C"

#Region "Columnas grid activos"
    Private iGyActivoCuentaContable As Integer = 1
    Private iGyActivoNombreCuenta As Integer = 2
    Private iGyActivoImporte As Integer = 3
#End Region

#Region "Columnas grid cuentas"
    Private iGyCodigoCentroCosto As Integer = 1
    Private iGyNombreCentroCosto As Integer = 2
    Private iGyCodigoCategoria As Integer = 3
    Private iGyNombreCategoria As Integer = 4
    Private iGyCodigoConcepto As Integer = 5
    Private iGyNombreConcepto As Integer = 6
    Private iGyImporte As Integer = 7
    Private iGyCuentaContable As Integer = 8
#End Region

#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
        If Me.Grabar() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub

    Private Sub tsbCancelar_Click(sender As Object, e As EventArgs) Handles tsbCancelar.Click
        If Me.Cancelar = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub btnDocumentoAnterior_Click(sender As Object, e As EventArgs) Handles btnDocumentoAnterior.Click
        Me.Navegador("Anterior")
    End Sub

    Private Sub btnDocumentoSiguiente_Click(sender As Object, e As EventArgs) Handles btnDocumentoSiguiente.Click
        Me.Navegador("Siguiente")
    End Sub
#End Region

#Region "Eventos"
    Private Sub Frm_CXC_Descuentos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub TxtFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolio.KeyDown
        Select Case e.KeyCode
            'Case Keys.F6
            '    Dim Busqueda = New Frm_Contabilidad_Busqueda_Polizas("FOLIO_POLIZA AS POLIZA,CONCEPTO1 AS CONCEPTO,FECHA,ESTATUS_POLIZA AS ESTATUS", "CON_POLIZAS_GLOBAL", "", "Poliza", "Fecha,Folio_poliza")
            '    Busqueda.ShowDialog()
            '    Me.TxtFolio.Text = "" & Busqueda.Tag.ToString
            '    Busqueda.Dispose()
            Case Keys.Return
                If txtLEN(Me.TxtFolio.Text) = True Then
                    Me.Consultar()
                Else
                    Me.GeneraFolio()
                End If
        End Select
    End Sub

    Private Sub TxtConcepto1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtConcepto1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.GridActivos.Cell(1, Me.iGyActivoCuentaContable).SetFocus()
            Case Keys.Escape
                Me.TxtConcepto1.Focus()
        End Select
    End Sub

    Private Sub GridActivos_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridActivos.KeyDown
        Me.GestionaGridActivos(e)
    End Sub

    Private Sub GridCostos_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridCostos.KeyDown
        Me.GestionaGridCostos(e)
    End Sub

    Private Sub txtImportarPoliza_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolioImportarPoliza.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                If txtLEN(Me.txtFolioImportarPoliza.Text) = True Then
                    Me.ImportarPoliza()
                End If
        End Select
    End Sub

#Region "Eventos Genericos"

    Private Sub txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFolio.Enter, TxtConcepto1.Enter
        Dim oTexBox As TextBox = CType(sender, TextBox)
        oTexBox.SelectAll()
    End Sub

    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtFecha.KeyDown, txtFolioImportarPoliza.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
        Me.TxtConcepto1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    End Sub

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtFecha.KeyPress, txtFolio.KeyPress, TxtConcepto1.KeyPress, txtFolioImportarPoliza.KeyPress
        txtNoBeep(e)
    End Sub

#End Region

#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.txtFolio.Text = ""
            Me.dtFecha.Value = Date.Now
            Me.TxtConcepto1.Text = ""
            Me.LblCodigoEstatus.Text = "N"
            Me.lblEstatus.Text = "Nueva"

            Me.txtTotalCargos.Text = FormatImporteContable(0)
            Me.txtTotalAbonos.Text = FormatImporteContable(0)

            Me.InicializaGridActivos()
            Me.InicializaGridCostos()

            Me.oPoliza = New Class_Contabilidad_Poliza_Global

            Me.GeneraFolio()

            Me.txtFolioImportarPoliza.Text = ""
        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Try
            Me.Estado = pEstado
            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.txtFolio.Enabled = True
                    Me.tssEstado.Text = "Estado: agregando póliza"
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True
                    'Me.tsbAplicar.Enabled = False
                    'Me.tsbDesaplicar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    'Me.tsbReactivar.Enabled = False
                    Me.tsbImprimir.Enabled = False
                    Me.dtFecha.Enabled = True
                    Me.TxtConcepto1.Enabled = True
                    Me.GridCostos.Locked = False
                    Me.GridActivos.Locked = False
                    Me.lblEstatus.Text = "Nueva"
                    Me.gbRenglones.Enabled = True

                    Me.tssElaboro.Visible = False
                    Me.tssCancelo.Visible = False

                    If Me.Visible = True Then
                        Me.txtFolio.Focus()
                    End If

                Case enumEstados.APLICADO
                    Me.txtFolio.Enabled = False
                    Me.tssEstado.Text = "Estado: consultando póliza"
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    'Me.tsbAplicar.Enabled = False
                    'Me.tsbDesaplicar.Enabled = True
                    Me.tsbCancelar.Enabled = True
                    'Me.tsbReactivar.Enabled = False
                    Me.tsbImprimir.Enabled = True
                    Me.dtFecha.Enabled = False
                    Me.TxtConcepto1.Enabled = False
                    Me.GridCostos.Locked = True
                    Me.GridActivos.Locked = True
                    Me.gbRenglones.Enabled = False

                    Me.tssElaboro.Visible = True
                    Me.tssCancelo.Visible = False

                    If Me.Visible = True Then
                        Me.tsbImprimir.Select()
                    End If

                Case enumEstados.CANCELADO
                    Me.txtFolio.Enabled = False
                    Me.tssEstado.Text = "Estado: consultando póliza"
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = False
                    'Me.tsbAplicar.Enabled = False
                    'Me.tsbDesaplicar.Enabled = False
                    Me.tsbCancelar.Enabled = False
                    'Me.tsbReactivar.Enabled = True
                    Me.tsbImprimir.Enabled = True
                    Me.dtFecha.Enabled = False
                    Me.TxtConcepto1.Enabled = False
                    Me.GridCostos.Locked = True
                    Me.GridActivos.Locked = True
                    Me.gbRenglones.Enabled = False

                    Me.tssElaboro.Visible = True
                    Me.tssCancelo.Visible = True

                    If Me.Visible = True Then
                        Me.tsbImprimir.Select()
                    End If

            End Select
        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Sub GestionaCambioEstado()
        Select Case Me.LblCodigoEstatus.Text
            Case "N"
                Me.Cambia_Estado(enumEstados.NUEVO)
                'Case "G"
                '    Me.Cambia_Estado(enumEstados.GRABADO)
            Case "A"
                Me.Cambia_Estado(enumEstados.APLICADO)
            Case "C"
                Me.Cambia_Estado(enumEstados.CANCELADO)
        End Select
    End Sub

    Private Sub InicializaGridActivos()
        Try
            Me.GridActivos.DataSource = Nothing
            FG_Grid_Limpiar(Me.GridActivos)

            'Creamos el Grid
            Me.GridActivos.Rows = 2
            Me.GridActivos.Cols = 4
            Me.GridActivos.DisplayRowNumber = True

            Me.FormateaGridActivos()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGridActivos", ex)
        End Try
    End Sub

    Private Sub InicializaGridCostos()
        Try
            Me.GridCostos.DataSource = Nothing
            FG_Grid_Limpiar(Me.GridCostos)

            'Creamos el Grid
            Me.GridCostos.Rows = 2
            Me.GridCostos.Cols = 9
            Me.GridCostos.DisplayRowNumber = True

            Me.FormateaGridCostos()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGridCostos", ex)
        End Try
    End Sub

    Private Sub FormateaGridActivos()
        Try
            With Me.GridActivos
                .Column(Me.iGyActivoCuentaContable).Width = 100
                .Column(Me.iGyActivoNombreCuenta).Width = 600
                .Column(Me.iGyActivoImporte).Width = 100

                .Cell(0, Me.iGyActivoCuentaContable).Text = "Cuenta contable"
                .Cell(0, Me.iGyActivoNombreCuenta).Text = "Nombre cuenta"
                .Cell(0, Me.iGyActivoImporte).Text = "Importe(MXP)"

                .Column(Me.iGyActivoImporte).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyActivoImporte).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyActivoImporte).DecimalLength = 2
                .Column(Me.iGyActivoImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyActivoImporte).Locked = False 'Se habilita 
                .Column(Me.iGyActivoNombreCuenta).Locked = True 'Se bloquea 
            End With
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridActivos", ex)
        End Try
    End Sub

    Private Sub FormateaGridCostos()
        Try
            With Me.GridCostos
                .Column(Me.iGyCodigoCentroCosto).Visible = False
                .Column(Me.iGyNombreCentroCosto).Width = 220
                .Column(Me.iGyCodigoCategoria).Visible = False
                .Column(Me.iGyNombreCategoria).Width = 220
                .Column(Me.iGyCodigoConcepto).Visible = False
                .Column(Me.iGyNombreConcepto).Width = 220
                .Column(Me.iGyImporte).Width = 100
                .Column(Me.iGyCuentaContable).Width = 100

                .Cell(0, Me.iGyCodigoCentroCosto).Text = "CCos"
                .Cell(0, Me.iGyNombreCentroCosto).Text = "C.costo"
                .Cell(0, Me.iGyCodigoCategoria).Text = "CCat"
                .Cell(0, Me.iGyNombreCategoria).Text = "Categoria"
                .Cell(0, Me.iGyCodigoConcepto).Text = "CCon"
                .Cell(0, Me.iGyNombreConcepto).Text = "Concepto"
                .Cell(0, Me.iGyImporte).Text = "Importe(MXP)"
                .Cell(0, Me.iGyCuentaContable).Text = "Cuenta contable"

                .Column(Me.iGyImporte).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyImporte).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyImporte).DecimalLength = 2
                .Column(Me.iGyImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyImporte).Locked = False 'Se habilita el importe
                .Column(Me.iGyCuentaContable).Locked = True 'Se bloquea la cuenta
            End With
        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridCostos", ex)
        End Try
    End Sub

    Private Function Grabar() As Boolean
        Dim bResultado As Boolean = False
        Dim sListaActivos As String = "", sListaCostos As String = ""
        Try
            If Me.Validar() = False Then
                Return False
            End If

            Me.Totales()

            If Me.Estado <> enumEstados.NUEVO Then
                MsgBox("Sólo se pueden grabar pólizas nuevas.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            Me.oPoliza = New Class_Contabilidad_Poliza_Global

            sListaActivos = ""
            sListaCostos = ""

            With Me.GridActivos
                For i = 1 To .Rows - 1
                    If .Cell(i, Me.iGyActivoCuentaContable).Text <> "" And valorNumerico(.Cell(i, Me.iGyActivoImporte).Text) <> 0 Then
                        sListaActivos = sListaActivos & i & "," & .Cell(i, Me.iGyActivoCuentaContable).Text & "," & .Cell(i, Me.iGyActivoImporte).Text & "|"
                    End If
                Next i
            End With

            With Me.GridCostos
                For i = 1 To .Rows - 1
                    If .Cell(i, Me.iGyCuentaContable).Text <> "" And valorNumerico(.Cell(i, Me.iGyImporte).Text) <> 0 Then
                        sListaCostos = sListaCostos & "@FOLIO_MOVIMIENTO," & i & "," & .Cell(i, Me.iGyCodigoCentroCosto).Text & "," & .Cell(i, Me.iGyCodigoCategoria).Text & "," & .Cell(i, Me.iGyCodigoConcepto).Text & ",0,1," & _
                        .Cell(i, Me.iGyImporte).Text & "," & .Cell(i, Me.iGyCuentaContable).Text & "|"
                    End If
                Next i
            End With

            If txtLEN(sListaCostos) = False And txtLEN(sListaActivos) = False Then
                MsgBox("Falta introducir los centros de costos o activos.", MsgBoxStyle.Exclamation, "Validación")
                Exit Function
            Else
                If txtLEN(sListaCostos) = True Then
                    sListaCostos = sListaCostos.Substring(0, sListaCostos.Length - 1) 'Para quitarle el último pipe que sale sobrando.
                End If
                If txtLEN(sListaActivos) = True Then
                    sListaActivos = sListaActivos.Substring(0, sListaActivos.Length - 1) 'Para quitarle el último pipe que sale sobrando.
                End If
            End If

            With Me.oPoliza
                .FOLIO_POLIZA = Me.txtFolio.Text
                .CODIGO_PLAZA = Usuario.Codigo_Plaza
                .CODIGO_USUARIO_GRABO = Usuario.Codigo_Usuario
                .CODIGO_TIPO_DOCUMENTO = Me.sCodigoTipoDocumento
                .FECHA = Me.dtFecha.Value
                .CONCEPTO1 = Me.TxtConcepto1.Text

                bResultado = .GrabarPolizaCosto(sListaActivos, sListaCostos, "INSERTAR")
            End With

            MsgBox("Póliza aplicada satisfactoriamente.", MsgBoxStyle.Information, Me.Text)

        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try

        Return bResultado
    End Function

    Private Sub Imprimir()
        Dim StrFiltros As String = ""
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            oReporte = New Class_Reporte("RPT_FORMATO_CONTABILIDAD_POLIZA", Rpt, False)
            If Not oReporte.RptCargado Then
                Exit Sub
            End If
            Rpt.SetParameterValue("@FOLIO_POLIZA", Me.txtFolio.Text)
            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()
        Catch ex As Exception
            HandleError(Me.Name, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Private Function Consultar(Optional ByVal sFolioImportar As String = "") As Boolean
        Dim bResultado As Boolean = False
        Dim sFolio As String = Me.txtFolio.Text

        Try
            Me.Inicializa()

            If txtLEN(sFolioImportar) = False Then
                Me.oPoliza = New Class_Contabilidad_Poliza_Global(sFolio)
            Else
                Me.oPoliza = New Class_Contabilidad_Poliza_Global(sFolioImportar)
            End If

            If Me.oPoliza.Existe = False Then
                Me.Cambia_Estado(enumEstados.NUEVO)
                Me.txtFolio.Enabled = False
                Exit Function
            Else

                If txtLEN(sFolioImportar) = False Then
                    Me.dtFecha.Value = Me.oPoliza.FECHA
                    Me.oPoliza.FOLIO_POLIZA = sFolio
                    Me.txtFolio.Text = Me.oPoliza.FOLIO_POLIZA
                    Me.LblCodigoEstatus.Text = Me.oPoliza.ESTATUS_POLIZA
                    Me.lblEstatus.Text = Me.oPoliza.ESTATUS
                    Me.TxtConcepto1.Text = Me.oPoliza.CONCEPTO1

                    Me.tssElaboro.Text = "Elaboró : " & Me.oPoliza.NOMBRE_USUARIO_GRABO & " el " & Format(Me.oPoliza.FECHA_SERVIDOR, "dd-MMM-yyyy hh:mm tt")
                    If Me.oPoliza.ESTATUS_POLIZA = "C" Then
                        Me.tssCancelo.Text = "Canceló : " & Me.oPoliza.NOMBRE_USUARIO_CANCELO & " el : " & Format(Me.oPoliza.FECHA_CANCELACION_SERVIDOR, "dd-MMM-yyyy hh:mm tt")
                        Me.tssCancelo.Visible = True
                    End If
                End If

                Me.txtTotalCargos.Text = FormatImporteContable(Me.oPoliza.CARGO)
                Me.txtTotalAbonos.Text = FormatImporteContable(Me.oPoliza.ABONO)

                'Renglones activos
                Me.GridActivos.DataSource = Me.oPoliza.ObtenerDetalleGastosActivos()
                Me.FormateaGridActivos()

                'Renglones centros costos
                Me.GridCostos.DataSource = Me.oPoliza.ObtenerDetalleCostos
                Me.FormateaGridCostos()

                Me.GestionaCambioEstado()

                If txtLEN(sFolioImportar) = True Then 'Para forzar a que se vacie el objeto porque es una importación
                    Me.oPoliza = New Class_Contabilidad_Poliza_Global()
                End If

            End If
            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try

        Return bResultado
    End Function

    Private Sub GeneraFolio()
        Try
            With oPoliza
                .CODIGO_TIPO_DOCUMENTO = Me.sCodigoTipoDocumento
                .FECHA = Me.dtFecha.Value
                .GeneraNuevoFolioPoliza()
            End With

            Me.txtFolio.Text = Me.oPoliza.FOLIO_POLIZA
        Catch ex As Exception
            HandleError(Me.Name, "GeneraFolio", ex)
        End Try
    End Sub

    Public Sub Totales()
        Try
            Me.txtTotalCargos.Text = FormatImporteContable(FG_Grid_SumaColPositivos(Me.GridActivos, CShort(Me.iGyActivoImporte)) + FG_Grid_SumaCol(Me.GridCostos, CShort(Me.iGyImporte)))
            Me.txtTotalAbonos.Text = FormatImporteContable(FG_Grid_SumaColNegativos(Me.GridActivos, CShort(Me.iGyActivoImporte)) * -1)
        Catch ex As Exception
            HandleError(Me.Name, "Totales", ex)
        End Try
    End Sub

    Private Function Cancelar() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim sFolio As String = Me.txtFolio.Text
            Me.oPoliza = New Class_Contabilidad_Poliza_Global(sFolio)

            If MsgBox("Desea cancelar la póliza " & Me.txtFolio.Text & " ?", vbYesNo Or vbQuestion, Me.Text) = MsgBoxResult.No Then
                Exit Function
            End If

            If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.sCodigoTipoDocumento & Usuario.Codigo_Plaza) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            Select Case Me.LblCodigoEstatus.Text
                Case "N"
                    MsgBox("La póliza no existe.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                    'Case "G"
                    '
                Case "A"
                    If Plaza.ValidarPeriodoTrabajo(Me.dtFecha.Value) = False Then
                        Exit Function
                    End If

                    Me.oPoliza.FECHA = Me.dtFecha.Value
                    bResultado = Me.oPoliza.CancelarPolizaCosto

                Case "C"
                    MsgBox("La pólizas canceladas no se pueden volver a cancelar.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
            End Select

            If bResultado = True Then
                MsgBox("Póliza " & Me.txtFolio.Text & " cancelada satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Cancelar", ex)
        End Try

        Return bResultado
    End Function

    Private Function Navegador(ByVal sTipoDeBusqueda As String) As Boolean
        Dim bResultado As Boolean = False
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

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "Navegador", ex)
        End Try

        Return bResultado
    End Function

    Private Sub ImportarPoliza()
        Try
            Me.Consultar(Me.txtFolioImportarPoliza.Text)
        Catch ex As Exception
            HandleError(Me.Name, "ImportarPoliza", ex)
        End Try
    End Sub

    Private Sub GestionaGridCostos(ByVal e As System.Windows.Forms.KeyEventArgs)

        Dim Columna As Integer, Renglon As Integer
        Dim StrCod As String = "" ', oCuenta As Class_CatCuentas
        Dim oCentroCosto As Class_CatCentroCostos 'Class_VwCatCentrosCostosyDeudoresDiversos
        Dim oCategoria As Class_CatCategorias, oConcepto As Class_CatConceptos
        Dim sCodigo As String = "", sTipo As String = ""

        Try
            Columna = Me.GridCostos.Selection.FirstCol
            Renglon = Me.GridCostos.Selection.FirstRow

            If Me.GridCostos.Column(Columna).Locked = True Then
                Return
            End If

            Select Case e.KeyCode
                Case Keys.Return

                    Select Case Columna
                        Case Me.iGyNombreCentroCosto
                            If txtLEN(Me.GridCostos.Cell(Renglon, Columna).Text) = False Then
                                GoTo busca_centro_costo
                                Return
                            End If

                            ''oCentroCosto = New Class_CatCentroCostos(CInt(Me.GridCostos.Cell(Renglon, Me.iGyCodigoCentroCosto).Text))
                            sCodigo = Me.GridCostos.Cell(Renglon, Me.iGyCodigoCentroCosto).Text
                            If Me.EstableceCentroCosto(Renglon, Columna, e.KeyCode, sTipo, sCodigo) = False Then
                                GoTo busca_centro_costo
                                Return
                            End If

                        Case Me.iGyNombreCategoria
                            If txtLEN(Me.GridCostos.Cell(Renglon, Columna).Text) = False Then
                                GoTo busca_categoria
                                Return
                            End If

                            oCategoria = New Class_CatCategorias(Me.GridCostos.Cell(Renglon, Me.iGyCodigoCategoria).Text)
                            If oCategoria.Existe = True Then
                                Me.GridCostos.Cell(Renglon, Me.iGyCodigoCategoria).Text = oCategoria.Codigo_Categoria
                                Me.GridCostos.Cell(Renglon, Me.iGyNombreCategoria).Text = oCategoria.Nombre_Categoria
                                Me.GridCostos.Cell(Renglon, Me.iGyCuentaContable).Text = oCategoria.Codigo_Tipo_Categoria
                            Else
                                Me.GridCostos.Cell(Renglon, Me.iGyCodigoCategoria).Text = ""
                                Me.GridCostos.Cell(Renglon, Me.iGyNombreCategoria).Text = ""
                                Me.GridCostos.Cell(Renglon, Me.iGyCuentaContable).Text = ""
                                GoTo busca_categoria
                                Return
                            End If

                        Case Me.iGyNombreConcepto
                            If txtLEN(Me.GridCostos.Cell(Renglon, Columna).Text) = False Then
                                GoTo busca_concepto
                                Return
                            End If

                            oConcepto = New Class_CatConceptos(Me.GridCostos.Cell(Renglon, Me.iGyCodigoConcepto).Text)
                            If oConcepto.Existe = True Then
                                Me.GridCostos.Cell(Renglon, Me.iGyCodigoConcepto).Text = oConcepto.Codigo_Concepto
                                Me.GridCostos.Cell(Renglon, Me.iGyNombreConcepto).Text = oConcepto.Nombre_Concepto
                            Else
                                Me.GridCostos.Cell(Renglon, Me.iGyCodigoConcepto).Text = ""
                                Me.GridCostos.Cell(Renglon, Me.iGyNombreConcepto).Text = ""
                                GoTo busca_concepto
                                Return
                            End If

                        Case Me.iGyImporte
                            If valorNumerico(Me.GridCostos.Cell(Renglon, Me.iGyImporte).Text) = 0 Then
                                e.Handled = True 'Con esto el importe si es 0 no se brinca a la siguiente columna, se queda el foco en el importe.
                                Return
                            End If
                            Me.SaltoColumnas(Renglon, Columna, Keys.KeyCode, sTipo)
                    End Select

salto_columna:

                Case Keys.F6
                    Select Case Columna


                        Case Me.iGyNombreCentroCosto
busca_centro_costo:

                            'Otra ves ahora es solo centro de costos
                            oCentroCosto = New Class_CatCentroCostos
                            sCodigo = oCentroCosto.BusquedaVisual_PorDescripcion
                            If txtLEN(sCodigo) = True Then
                                Me.EstableceCentroCosto(Renglon, Columna, e.KeyCode, "CENTRO_COSTO", sCodigo)
                            End If

                        Case Me.iGyNombreCategoria
busca_categoria:
                            oCategoria = New Class_CatCategorias
                            sCodigo = oCategoria.BusquedaVisual_PorDescripcion

                            If txtLEN(sCodigo) = True Then
                                oCategoria = New Class_CatCategorias(sCodigo)
                                Me.GridCostos.Cell(Renglon, Me.iGyCodigoCategoria).Text = oCategoria.Codigo_Categoria.ToString
                                Me.GridCostos.Cell(Renglon, Me.iGyNombreCategoria).Text = oCategoria.Nombre_Categoria
                                Me.GridCostos.Cell(Renglon, Me.iGyCuentaContable).Text = oCategoria.Codigo_Tipo_Categoria
                                'Else
                                '    GoTo busca_categoria
                                '    Return
                            End If

                        Case Me.iGyNombreConcepto
busca_concepto:
                            oConcepto = New Class_CatConceptos
                            sCodigo = oConcepto.BusquedaVisual_PorDescripcion

                            If txtLEN(sCodigo) = True Then
                                oConcepto = New Class_CatConceptos(sCodigo)
                                Me.GridCostos.Cell(Renglon, Me.iGyCodigoConcepto).Text = oConcepto.Codigo_Concepto.ToString
                                Me.GridCostos.Cell(Renglon, Me.iGyNombreConcepto).Text = oConcepto.Nombre_Concepto
                                'Else
                                '    GoTo busca_concepto
                                '    Return
                            End If

                    End Select


                Case Keys.F8
                    Me.GridCostos.Selection.DeleteByRow()

            End Select

            Me.Totales()
            'Me.TotalizaGridCentrosCostosyActivos()

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGridCostos", ex)
        End Try
    End Sub

    Private Sub GestionaGridActivos(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim sProcedure As String = "GestionaGridActivos"
        Dim Columna As Integer, Renglon As Integer
        Dim sCuentaContable As String = "", oCuenta As Class_CatCuentas

        With Me.GridActivos
            Try
                Columna = .Selection.FirstCol
                Renglon = .Selection.FirstRow

                If .Column(Columna).Locked = True Then
                    Return
                End If

                Select Case e.KeyCode
                    Case Keys.Return
                        Select Case Columna
                            Case Me.iGyActivoCuentaContable
                                sCuentaContable = .Cell(Renglon, Columna).Text
                                If txtLEN(sCuentaContable) = False Then
                                    GoTo busca_cuenta_contable
                                    Return
                                ElseIf sCuentaContable.StartsWith("1") = False Then
                                    .Cell(Renglon, Me.iGyActivoCuentaContable).Text = ""
                                    .Cell(Renglon, Me.iGyActivoNombreCuenta).Text = ""
                                    MsgBox("La cuenta contable del renglón : " & Renglon & " debe ser del rango de las miles(que empiezen con 1).", MsgBoxStyle.Exclamation, sProcedure)
                                    Return
                                End If

                                oCuenta = New Class_CatCuentas(sCuentaContable)
                                If oCuenta._Existe = False Then
                                    MsgBox("La cuenta contable que intenta buscar no existe, favor de intentar con otro código.", MsgBoxStyle.Critical, sProcedure)
                                    Me.InicializaRenglonGridActivos(Renglon)
                                    Return
                                Else
                                    .Cell(Renglon, Me.iGyActivoNombreCuenta).Text = oCuenta.NOMBRE_CUENTA_NIVELES_COMPLETOS
                                End If
                                oCuenta = Nothing

                            Case Me.iGyActivoImporte
                                If valorNumerico(.Cell(Renglon, Me.iGyActivoImporte).Text) = 0 Then
                                    e.Handled = True 'Con esto el importe si es 0 no se brinca a la siguiente columna, se queda el foco en el importe.
                                    Return
                                End If
                        End Select

salto_columna:
                        If .Rows = Renglon + 1 And .Cell(Renglon, Me.iGyActivoImporte).Locked = False Then
                            .Rows = .Rows + 1
                        End If

                        Select Case Columna
                            Case Me.iGyActivoImporte
                                .Cell(Renglon + 1, 0).SetFocus()
                            Case Else
                                .Cell(Renglon, Columna).SetFocus()
                        End Select

                    Case Keys.F6
                        Select Case Columna
                            Case Me.iGyActivoCuentaContable
busca_cuenta_contable:
                                oCuenta = New Class_CatCuentas()
                                Dim sCuenta As String = oCuenta.BusquedaVisual_PorCodigoConLike("1")
                                If txtLEN(sCuenta) = True Then
                                    oCuenta = New Class_CatCuentas(sCuenta)
                                    .Cell(Renglon, Me.iGyActivoCuentaContable).Text = oCuenta.CUENTA_CONTABLE
                                    .Cell(Renglon, Me.iGyActivoNombreCuenta).Text = oCuenta.NOMBRE_CUENTA_NIVELES_COMPLETOS
                                End If
                                oCuenta = Nothing
                        End Select

                    Case Keys.F7
                        Select Case Columna
                            Case Me.iGyActivoCuentaContable
                                oCuenta = New Class_CatCuentas()
                                Dim sCuenta As String = oCuenta.BusquedaVisual_PorDescripcionConLike("1")
                                If txtLEN(sCuenta) = True Then
                                    oCuenta = New Class_CatCuentas(sCuenta)
                                    .Cell(Renglon, Me.iGyActivoCuentaContable).Text = oCuenta.CUENTA_CONTABLE
                                    .Cell(Renglon, Me.iGyActivoNombreCuenta).Text = oCuenta.NOMBRE_CUENTA_NIVELES_COMPLETOS
                                End If
                                oCuenta = Nothing
                        End Select

                    Case Keys.F8
                        .Selection.DeleteByRow()

                End Select

                Me.Totales()
                'Me.TotalizaGridCentrosCostosyActivos()

            Catch ex As Exception
                HandleError(Me.Name, "GestionaGridActivos", ex)
            End Try

        End With
    End Sub

    Private Sub InicializaRenglonGridCostos(ByVal iRenglon As Integer)
        Try
            For i As Integer = 1 To Me.GridCostos.Cols - 1
                Me.GridCostos.Cell(iRenglon, i).Text = ""
            Next
        Catch ex As Exception
            HandleError(Me.Name, "InicializaRenglonGridCostos", ex)
        End Try
    End Sub

    Private Sub InicializaRenglonGridActivos(ByVal iRenglon As Integer)
        Try
            For i As Integer = 1 To Me.GridActivos.Cols - 1
                Me.GridActivos.Cell(iRenglon, i).Text = ""
            Next
        Catch ex As Exception
            HandleError(Me.Name, "InicializaRenglonGridActivos", ex)
        End Try
    End Sub

    Private Function EstableceCentroCosto(ByVal Renglon As Integer, ByVal Columna As Integer, ByVal KeyCode As System.Windows.Forms.Keys, ByVal sTipo As String, ByVal sCodigo As String) As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim oCentroCosto As New Class_VwCatCentrosCostosyDeudoresDiversos(sTipo, sCodigo)

            If oCentroCosto.EXISTE = True Then
                Me.GridCostos.Cell(Renglon, Me.iGyCodigoCentroCosto).Text = oCentroCosto.CODIGO
                Me.GridCostos.Cell(Renglon, Me.iGyNombreCentroCosto).Text = oCentroCosto.NOMBRE
                Select Case sTipo
                    Case "DEUDOR_DIVERSO"
                        Me.GridCostos.Cell(Renglon, Me.iGyCodigoCategoria).Text = ""
                        Me.GridCostos.Cell(Renglon, Me.iGyNombreCategoria).Text = "NO APLICA"
                        Me.GridCostos.Cell(Renglon, Me.iGyCodigoConcepto).Text = ""
                        Me.GridCostos.Cell(Renglon, Me.iGyNombreConcepto).Text = "NO APLICA"
                        Me.GridCostos.Cell(Renglon, Me.iGyCuentaContable).Text = oCentroCosto.CUENTA_CONTABLE
                End Select
                bResultado = True
            Else
                Me.InicializaRenglonGridCostos(Renglon)
            End If

            If bResultado = True Then
                Me.SaltoColumnas(Renglon, Columna, KeyCode, sTipo)
            End If

        Catch ex As Exception
            HandleError(Me.Name, "EstableceCentroCosto", ex)
        End Try
        Return bResultado
    End Function

    Private Sub SaltoColumnas(ByVal Renglon As Integer, ByVal Columna As Integer, ByVal KeyCode As System.Windows.Forms.Keys, ByVal sTipo As String)
        If Me.GridCostos.Rows = Renglon + 1 And Me.GridCostos.Cell(Renglon, Me.iGyImporte).Locked = False Then
            Me.GridCostos.Rows = Me.GridCostos.Rows + 1
        End If

        Select Case Columna
            Case Me.iGyImporte
                Me.GridCostos.Cell(Renglon + 1, Me.iGyCodigoCentroCosto).SetFocus()
            Case Else
                Select Case sTipo
                    Case "DEUDOR_DIVERSO"
                        Select Case KeyCode
                            Case Keys.Return
                                Me.GridCostos.Cell(Renglon, Me.iGyNombreConcepto).SetFocus() 'Se pone una antes para quese vaya al importe, porque el enter por si mismo va forzar brincar otra vez
                            Case Keys.F6
                                Me.GridCostos.Cell(Renglon, Me.iGyImporte).SetFocus()
                        End Select
                    Case Else
                        If KeyCode = Keys.F6 Then
                            Select Case Columna
                                Case Me.iGyNombreCentroCosto
                                    Columna = Me.iGyNombreCategoria
                            End Select
                        End If
                        Me.GridCostos.Cell(Renglon, Columna).SetFocus()
                End Select
        End Select
    End Sub

    Private Function ValidaCuentasContables() As Boolean
        Dim bResultado As Boolean = False
        Dim sProcedure As String = "ValidaCuentasContables"
        Dim i As Integer, bHayCuentasContables As Boolean = False
        Dim sCuentaContable As String = "", oCuenta As New Class_CatCuentas

        Try
            ''''''''''''''''''''''''''''''''''''''''''''''''
            With Me.GridCostos
                For i = 1 To .Rows - 1
                    sCuentaContable = .Cell(i, Me.iGyCuentaContable).Text
                    If txtLEN(sCuentaContable) = True Then
                        oCuenta = New Class_CatCuentas(sCuentaContable)
                        If oCuenta._Existe = False Then
                            MsgBox("La cuenta contable del renglón: " & i & " no existe, favor de intentar con otro código.", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyCuentaContable).SetFocus()
                            Return False
                        ElseIf oCuenta.ESMAYOR = "1" Then
                            MsgBox("La cuenta contable del renglón: " & i & " es de mayor, favor de intentar con otro código.", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyCuentaContable).SetFocus()
                            Return False
                        ElseIf Microsoft.VisualBasic.Left(sCuentaContable, 1) = "5" Then
                            'If .Cell(i, Me.iGyTipo).Text <> "CENTRO_COSTO" Then
                            '    MsgBox("La cuenta contable del renglón: " & i & " es 5 mil , y el tipo no es centro de costos.", MsgBoxStyle.Exclamation, sProcedure)
                            '    Return False
                            'End If
                            If txtLEN(.Cell(i, Me.iGyCodigoCentroCosto).Text) = False Or .Cell(i, Me.iGyCodigoCentroCosto).Text = "0" Then
                                MsgBox("La cuenta contable  del renglón: " & i & " es 5 mil , favor de asignar un centro de costo.", MsgBoxStyle.Exclamation, sProcedure)
                                .Cell(i, Me.iGyCodigoCentroCosto).SetFocus()
                                Return False
                            End If
                            'ElseIf Microsoft.VisualBasic.Left(sCuentaContable, 1) = "1" Then
                            '    If .Cell(i, Me.iGyTipo).Text <> "DEUDOR_DIVERSO" Then
                            '        MsgBox("La cuenta contable del renglón: " & i & " es 1 mil , y el tipo no es deudor diverso.", MsgBoxStyle.Exclamation, sProcedure)
                            '        Return False
                            '    End If
                        ElseIf valorNumerico(.Cell(i, Me.iGyImporte).Text) = 0 Then
                            MsgBox("Falta introducir el importe del renglón: " & i & ".", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyImporte).SetFocus()
                            Return False
                        End If
                        bHayCuentasContables = True
                    End If
                Next i

                For i = 1 To .Rows - 1
                    If valorNumerico(.Cell(i, Me.iGyImporte).Text) <> 0 Then 'Si capturaron algún importe.
                        If Len(.Cell(i, Me.iGyCuentaContable).Text) = 0 Then
                            MsgBox("Falta introducir la cuenta contrable del renglón: " & i & ".", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyCuentaContable).SetFocus()
                            Return False
                        End If
                    End If
                Next i

            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''
            With Me.GridActivos
                For i = 1 To .Rows - 1
                    sCuentaContable = .Cell(i, Me.iGyActivoCuentaContable).Text
                    If txtLEN(sCuentaContable) = True Then
                        oCuenta = New Class_CatCuentas(sCuentaContable)

                        If oCuenta._Existe = False Then
                            MsgBox("La cuenta contable(de los activos) del renglón: " & i & " no existe, favor de intentar con otro código.", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyActivoCuentaContable).SetFocus()
                            Return False
                        ElseIf oCuenta.ESMAYOR = "1" Then
                            MsgBox("La cuenta contable(de los activos) del renglón: " & i & " es de mayor, favor de intentar con otro código.", MsgBoxStyle.Exclamation, sProcedure)
                            .Cell(i, Me.iGyActivoCuentaContable).SetFocus()
                            Return False
                        ElseIf sCuentaContable.StartsWith("1") = False Then 'Si no empieza con 1
                            MsgBox("La cuenta contable del renglón : " & i & " debe ser del rango de las miles(que empiezen con 1).", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        ElseIf valorNumerico(.Cell(i, Me.iGyActivoImporte).Text) = 0 Then
                            MsgBox("Falta introducir un importe en el renglón: " & i & ".", MsgBoxStyle.Exclamation, sProcedure)
                            Me.GridActivos.Cell(i, Me.iGyActivoImporte).SetFocus()
                            Return False
                        End If
                        bHayCuentasContables = True
                    End If

                    If valorNumerico(.Cell(i, Me.iGyActivoImporte).Text) <> 0 Then
                        If Len(.Cell(i, Me.iGyActivoCuentaContable).Text) = 0 Then
                            MsgBox("Falta introducir la cuenta contrable en el renglón: " & i & ".", MsgBoxStyle.Exclamation, sProcedure)
                            Me.GridActivos.Cell(i, Me.iGyActivoCuentaContable).SetFocus()
                            Return False
                        End If
                    End If
                Next i
            End With
            ''''''''''''''''''''''''''''''''''''''''''''''''

            If bHayCuentasContables = False Then
                MsgBox("Captúre el detalle de la póliza.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function Validar() As Boolean
        Try
            If Plaza.ValidarPeriodoTrabajo(Me.dtFecha.Value) = False Then
                Return False
            End If

            If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.sCodigoTipoDocumento & Usuario.Codigo_Plaza) = False Then
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
                Return False
            End If

            If Me.ValidaCuentasContables = False Then
                Return False
            End If

            If valorNumerico(Me.txtTotalCargos.Text) <> valorNumerico(Me.txtTotalAbonos.Text) Then
                MsgBox("La suma total de cargos y abonos no cuadra.", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If

            Select Case Me.LblCodigoEstatus.Text
                Case "N" 'No hay restricciones
                    If Plaza.ValidarPeriodoTrabajo(Me.dtFecha.Value) = False Then
                        Return False
                    End If
                    'Case "G"
                    '    If Plaza.ValidarPeriodoTrabajo(Me.dtFecha.Value) = False Then
                    '        Return False
                    '    End If
                Case "A"
                    MsgBox("Las pólizas aplicadas no pueden modificarse.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
                Case "C"
                    MsgBox("Las pólizas canceladas no pueden modificarse.", MsgBoxStyle.Exclamation, Me.Text)
                    Return False
            End Select

        Catch ex As Exception
            HandleError(Me.Name, "Validar", ex)
        End Try

        Return True
    End Function
#End Region

End Class