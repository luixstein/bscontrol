Option Strict On
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Sis_administracion_clientes
    Private oSisAdministracionClientes As New Class_Sis_Administracion_Clientes
    Private oClientes As New Class_CatClientes

    Private igyIdRegla As Short = 1
    Private igyEstatus As Short = 2
    Private igyFecha As Short = 3
    Private igyImporteAutorizado As Short = 4
    Private igyImporteRestante As Short = 5

    Private Sub TxtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCliente.KeyDown
        Dim sText As String
        If Usuario.PERMISO_ADMINISTRADOR = "0" Then
            MsgBox("No cuenta con los permisos para consultar en esta pantalla", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If

        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oClientes.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.TxtCliente.Text = sText
            Case Keys.Enter
                If txtLEN(Me.TxtCliente.Text) = False Then
                    Me.lblCliente.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.oClientes = New Class_CatClientes(Me.TxtCliente.Text)
                If Me.oClientes.Existe = False Then
                    Me.lblCliente.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblCliente.Text = Me.oClientes.NOMBRE_CLIENTE
                Me.Consultar()
                txtTAB(e)
        End Select
    End Sub

    Private Sub TxtImport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtImport.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If valorNumerico(Me.TxtImport.Text) >= 0 Then
                    Me.TxtImport.Text = FormatImporteContable(CDbl(Me.TxtImport.Text))
                    Me.TxtConcept.Focus()
                End If
        End Select
    End Sub

    Private Sub TxtFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFolio.KeyDown
        Dim oVenta As New Class_Ventas_Global
        Select Case e.KeyCode
            Case Keys.F6
                Me.TxtFolio.Text = oVenta.BusquedaVisual_PorCliente(Me.TxtCliente.Text)
            Case Keys.Enter
                If txtLEN(Me.TxtFolio.Text) = True Then
                    oVenta = New Class_Ventas_Global(Me.TxtFolio.Text)
                    If oVenta.Existe = True Then
                        SendKeys.Send("{TAB}")
                    Else
                        Me.TxtFolio.Focus()
                    End If
                End If
        End Select
    End Sub

    Private Sub ckbReglasActivas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbReglasActivas.CheckedChanged
        'Me.InicializaReglaCXC()
        Me.ConsultaReglasCXC()
    End Sub

    'Se agrego txtNumerosEnterosKeyPress
    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiasPlazo.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosDecimalKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtImport.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub TxtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCliente.KeyPress, TxtConcept.KeyPress, TxtFolio.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub TxtCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCliente.TextChanged

    End Sub

    Private Sub txtLimiteCredit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLimiteCredit.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If valorNumerico(Me.txtLimiteCredit.Text) >= 0 Then
                    Me.txtLimiteCredit.Text = FormatImporteContable(CDbl(Me.txtLimiteCredit.Text))
                    Me.BtnActualizaLimiteCredito.Focus()
                End If
        End Select
    End Sub

    Private Sub TxtConcept_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtConcept.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If txtLEN(Me.TxtConcept.Text) = True Then
                    Me.BtnAgregaRegla.Focus()
                End If
        End Select
    End Sub

    Private Sub BtnActualizaLimiteCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizaLimiteCredito.Click
        If Me.ActualizaLimiteCreditoDirectamente() = True Then
            Me.Consultar()
            'InicializaReglaCXC()
            'ConsultaReglasCXC()
            Me.tcPanel.TabPages(1).Enabled = True
            Me.tcPanel.SelectedIndex = 1
            'Me.ConsultarLimiteCredito()
        End If
    End Sub

    Private Sub BtnAgregaRegla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregaRegla.Click
        If Me.AgregarReglaCXC() = True Then
            Me.Consultar()
            Me.InicializaReglaCXC()
            Me.ConsultaReglasCXC()
            Me.tcPanel.TabPages(1).Enabled = True
            Me.tcPanel.SelectedIndex = 1
        End If
    End Sub

    Private Sub BtnCancelarRegla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelarRegla.Click
        If Me.CancelarReglaCxc() = True Then
            Me.Consultar()
            Me.InicializaReglaCXC()
            Me.ConsultaReglasCXC()
            Me.tcPanel.TabPages(1).Enabled = True
            Me.tcPanel.SelectedIndex = 1
        End If
    End Sub
    'Se agrego
    Private Sub BtnActualizarPlazo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizarPlazo.Click
        If Me.ActualizaPlazoDirectamente() = True Then
            Me.Consultar()
            Me.InicializaReglaCXC()
            Me.ConsultaReglasCXC()
            Me.tcPanel.TabPages(1).Enabled = True
            Me.tcPanel.SelectedIndex = 1
        End If
    End Sub
    'Se agrego
    Private Sub BtnConvertir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConvertir.Click
        If Me.ConvertirVentaContadoACredito() = True Then
            Me.Consultar()
            Me.InicializaReglaCXC()
            Me.ConsultaReglasCXC()
            Me.tcPanel.TabPages(1).Enabled = True
            Me.tcPanel.SelectedIndex = 1
        End If
    End Sub

    Private Sub BtnConvertir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnConvertir.KeyDown
        If e.KeyCode = Keys.Return Then
            BtnConvertir.PerformClick()
        End If
    End Sub

    Private Sub Inicializa()
        Me.TxtCliente.Text = ""
        Me.lblCliente.Text = ""
        Me.lblDiasCarteraVentaAntigua.Text = ""
        Me.lblDiasCarteraVentaReciente.Text = ""
        Me.lblEmpresaVentaAntigua.Text = ""
        Me.lblEmpresaVentaReciente.Text = ""
        Me.lblFechaUltimoDeposito.Text = ""
        Me.lblFechaVentaAntigua.Text = ""
        Me.lblFechaVentaReciente.Text = ""
        Me.lblFolioVentaAntigua.Text = ""
        Me.lblFolioVentaReciente.Text = ""
        Me.lblImporteAutorizado.Text = ""
        Me.lblImporteUltimoDeposito.Text = ""
        Me.lblPlazo.Text = ""
        Me.lblSaldo.Text = ""
        Me.lblSaldoVencido.Text = ""
        Me.lblLimiteCredito.Text = ""
        Me.lblCreditoRestante.Text = ""
        Me.lblSaldoVentaAntigua.Text = ""
        Me.lblsaldoVentaReciente.Text = ""

        Me.InicializaGridReglasCXC()
        Me.InicializaReglaCXC()
        Me.InicializaObservaciones()

        Me.tcPanel.SelectedIndex = 0
        Me.tcPanel.TabPages(1).Enabled = False

    End Sub

    Private Sub InicializaReglaCXC()
        Me.ckbReglasActivas.Checked = True
        Me.txtLimiteCredit.Text = ""
        Me.TxtImport.Text = ""
        Me.TxtConcept.Text = ""
        Me.LblUltimaActualizacionLimiteCredit.Text = ""
        Me.lblCXCImporteAutorizadoReglasCXC.Text = "$ 0.00"
        Me.txtDiasPlazo.Text = ""
        Me.ckbRecaularVencimientos.Checked = False
        Me.ckbRangoFechas.Checked = False
        Me.ckbRangoFechas.Enabled = False
        Me.lblDisplayDesde.Enabled = False
        Me.lblDisplayHasta.Enabled = False
        Me.dpFechaDesde.Enabled = False
        Me.dpFechaDesde.Value = Now
        Me.dpFechaHasta.Enabled = False
        Me.dpFechaHasta.Value = Now
        Me.TxtFolio.Text = ""
    End Sub

    Private Sub InicializaGridReglasCXC()
        Me.GridReglasCXC.DataSource = Nothing
        FG_Grid_Limpiar(Me.GridReglasCXC)

        Me.GridReglasCXC.Rows = 2
        Me.GridReglasCXC.Cols = 6

        Me.FormateaGrid()
    End Sub

    Private Sub InicializaObservaciones()
        Me.txtObservaciones.Text = ""
        Me.lblFechaObservacion.Text = ""
        Me.lblIDObservaciones.Text = ""
        Me.txtObservaciones.Enabled = False
    End Sub

    Private Sub FormateaGrid()
        Me.GridReglasCXC.Column(Me.igyIdRegla).Width = 80
        Me.GridReglasCXC.Column(Me.igyEstatus).Width = 80
        Me.GridReglasCXC.Column(Me.igyFecha).Width = 100
        Me.GridReglasCXC.Column(Me.igyImporteAutorizado).Width = 100
        Me.GridReglasCXC.Column(Me.igyImporteRestante).Width = 100

        Me.GridReglasCXC.Cell(0, Me.igyIdRegla).Text = "ID Regla"
        Me.GridReglasCXC.Cell(0, Me.igyEstatus).Text = "Estatus"
        Me.GridReglasCXC.Cell(0, Me.igyFecha).Text = "Fecha"
        Me.GridReglasCXC.Cell(0, Me.igyImporteAutorizado).Text = "Importe autorizado"
        Me.GridReglasCXC.Cell(0, Me.igyImporteRestante).Text = "Importe restante"

        Me.GridReglasCXC.Column(Me.igyImporteAutorizado).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        Me.GridReglasCXC.Column(Me.igyImporteAutorizado).Mask = FlexCell.MaskEnum.Numeric
        'Me.GridReglasCXC.Column(Me.igyImporteAutorizado).DecimalLength = 2
        Me.GridReglasCXC.Column(Me.igyImporteAutorizado).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.GridReglasCXC.Column(Me.igyImporteRestante).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        Me.GridReglasCXC.Column(Me.igyImporteRestante).Mask = FlexCell.MaskEnum.Numeric
        'Me.GridReglasCXC.Column(Me.igyImporteRestante).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
        Me.GridReglasCXC.Column(Me.igyImporteRestante).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.GridReglasCXC.Column(Me.igyFecha).CellType = FlexCell.CellTypeEnum.DateTime
        Me.GridReglasCXC.Column(Me.igyFecha).FormatString = "dd-MMM-yyyy"

        Me.GridReglasCXC.Locked = True
    End Sub

    Private Function Consultar() As Boolean
        Dim sCliente As String = Me.TxtCliente.Text
        Try
            Me.Inicializa()

            Me.oSisAdministracionClientes = New Class_Sis_Administracion_Clientes
            Me.oSisAdministracionClientes.CodigoCliente = sCliente

            If Me.oSisAdministracionClientes.Consultar = False Then
                Exit Function
            Else
                With Me.oClientes
                        Me.TxtCliente.Text = "" & Me.oSisAdministracionClientes.CodigoCliente
                    Me.lblCliente.Text = "" & Me.oSisAdministracionClientes.NombreCliente

                    Me.lblSaldo.Text = "" & FormatImporteContable(CDbl(Me.oSisAdministracionClientes.Saldo), True)
                    Me.lblSaldoVencido.Text = "" & FormatImporteContable(CDbl(Me.oSisAdministracionClientes.SaldoVencido), True)

                    Me.lblLimiteCredito.Text = "" & FormatImporteContable(CDbl(Me.oSisAdministracionClientes.LIMITE_CREDITO), True)
                    Me.lblCreditoRestante.Text = "" & FormatImporteContable(CDbl(Me.oSisAdministracionClientes.CREDITO_RESTANTE), True)

                    Me.lblPlazo.Text = "" & Me.oSisAdministracionClientes.plazo

                    Me.lblImporteAutorizado.Text = "" & FormatImporteContable(CDbl(Me.oSisAdministracionClientes.ImporteAutorizado), True)

                    Me.lblFechaUltimoDeposito.Text = "" & Me.oSisAdministracionClientes.FechaUltimoDeposito
                    Me.lblImporteUltimoDeposito.Text = "" & FormatImporteContable(CDbl(valorNumerico(Me.oSisAdministracionClientes.ImporteUltimoDeposito)), True)
                    Me.lblSaldoUltimoDeposito.Text = " "


                    Me.lblDiasCarteraVentaAntigua.Text = "" & Me.oSisAdministracionClientes.DiasCarteraVentaAntigua
                    Me.lblDiasCarteraVentaReciente.Text = "" & Me.oSisAdministracionClientes.DiasCarteraVentaReciente
                    Me.lblEmpresaVentaAntigua.Text = "" & Me.oSisAdministracionClientes.EmpresaVentaAntigua
                    Me.lblEmpresaVentaReciente.Text = "" & Me.oSisAdministracionClientes.EmpresaVentaReciente

                    Me.lblFechaVentaAntigua.Text = "" & Me.oSisAdministracionClientes.FechaVentaAntigua
                    Me.lblFechaVentaReciente.Text = "" & Me.oSisAdministracionClientes.FechaVentaReciente
                    Me.lblFolioVentaAntigua.Text = "" & Me.oSisAdministracionClientes.FolioVentaAntigua
                    Me.lblFolioVentaReciente.Text = "" & Me.oSisAdministracionClientes.FolioVentaReciente


                    Me.lblPlazo.Text = "" & Me.oSisAdministracionClientes.PLAZO

                    Me.lblSaldoVentaAntigua.Text = "" & FormatImporteContable(CDbl(Me.oSisAdministracionClientes.SaldoVentaAntigua), True)
                    Me.lblsaldoVentaReciente.Text = "" & FormatImporteContable(CDbl(Me.oSisAdministracionClientes.SaldoVentaReciente), True)
                    Me.LblUltimaActualizacionLimiteCredit.Text = Me.oSisAdministracionClientes.ULTIMA_ACTUALIZACION_LIMITE_CREDITO
                    Me.txtSeguimiento.Text = Me.oSisAdministracionClientes.ULTIMO_SEGUIMIENTO

                    If txtLEN(Me.oSisAdministracionClientes.FECHA_ULTIMO_SEGUIMIENTO_CXC) = True Then
                        Me.lblFechaCompromiso.Text = Format(CDate(Me.oSisAdministracionClientes.FECHA_ULTIMO_SEGUIMIENTO_CXC), "dd-MMM-yyyy hh:mm tt")
                    Else
                        Me.lblFechaCompromiso.Text = ""
                    End If

                    Me.txtCodigoSeguimiento.Text = Me.oSisAdministracionClientes.CODIGO_ULTIMO_SEGUIMIENTO

                    If Me.oSisAdministracionClientes.STATUS_REVISADO = "0" Then
                        Me.lblEstatusSeguimiento.Text = "NO REVISADO"
                    ElseIf Me.oSisAdministracionClientes.STATUS_REVISADO = "1" Then
                        Me.lblEstatusSeguimiento.Text = "REVISADO"
                    Else
                        Me.lblEstatusSeguimiento.Text = ""
                    End If

                    If Me.oSisAdministracionClientes.CODIGO_RESULTADO_ACUERDO_ULTIMO_SEGUIMIENTO_CXC = "0" Then
                        Me.lblAcuerdoSeguimiento.Text = "NO CUMPLIDO"
                    ElseIf Me.oSisAdministracionClientes.CODIGO_RESULTADO_ACUERDO_ULTIMO_SEGUIMIENTO_CXC = "1" Then
                        Me.lblAcuerdoSeguimiento.Text = "CUMPLIDO"
                    ElseIf Me.oSisAdministracionClientes.CODIGO_RESULTADO_ACUERDO_ULTIMO_SEGUIMIENTO_CXC = "2" Then
                        Me.lblAcuerdoSeguimiento.Text = "DESCARTADO"
                    Else
                        Me.lblAcuerdoSeguimiento.Text = ""
                    End If

                    If txtLEN(Me.oSisAdministracionClientes.CODIGO_TIPO_ACUERDO_ULTIMO_SEGUIMIENTO_CXC) = True Then
                        Me.cboTipoAcuerdo.SelectedValue = Me.oSisAdministracionClientes.CODIGO_TIPO_ACUERDO_ULTIMO_SEGUIMIENTO_CXC
                    End If

                    Me.tcPanel.TabPages(1).Enabled = True
                End With

                Dim oPropietarios As New Class_CatPropietarios
                Dim sql As New Class_find("SELECT R.CODIGO_PROPIETARIO FROM CAT_PROPIETARIOS_RELACION_CLIENTES R " _
                                          & "WHERE CODIGO_CLIENTE='" & Me.TxtCliente.Text & "'")

                If txtLEN(sql.Result1.ToString) = True Then
                    With Me.GridListaClientes
                        .DataSource = oPropietarios.ObtenerRelacionPropietariosClientes(sql.Result1.ToString)
                        .Columns("CODIGO_CLIENTE").Width = 52
                        .Columns("NOMBRE_CLIENTE").Width = 500
                    End With
                Else
                    Me.GridListaClientes.DataSource = Nothing
                End If

            End If

            Me.ConsultaReglasCXC()
            Me.RefrescarResumenCXC()
            'Me.ConsultarLimiteCredito()

            Consultar = True
        Catch ex As Exception
            HandleError(Me.Text, "Consultar", ex)
        End Try
    End Function

    Private Function ActualizaLimiteCreditoDirectamente() As Boolean
        Try
            If valorNumerico(Me.txtLimiteCredit.Text) < 0 Then
                MsgBox("El limite de credito debe ser igual o mayor que 0 .", MsgBoxStyle.Information, Me.Text)
                Exit Function
            Else

                If MsgBox("Desea actualizar directamente el límite de crédito del cliente por un importe de " & _
                          FormatImporteContable(CDbl(Me.txtLimiteCredit.Text), True) & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "ActualizaLimiteCreditoDirectamente") = MsgBoxResult.No Then
                    Exit Function
                End If
            End If

            Me.oClientes = New Class_CatClientes(Me.TxtCliente.Text)
            Me.oClientes.LIMITE_CREDITO = CDbl(Me.txtLimiteCredit.Text)
            If Me.oClientes.ActualizarLimiteCredito = False Then
                Exit Function
            End If

            ActualizaLimiteCreditoDirectamente = True
            MsgBox("El límite de crédito del cliente se a actualizado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)

        Catch ex As Exception
            HandleError(Me.Name, "ActualizaLimiteCreditoDirectamente", ex)
        End Try
    End Function

    Private Function ConsultarLimiteCredito() As Boolean
        Try
            'Me.oClientes = New Class_CatClientes(Me.TxtCliente.Text)
            'If Me.oClientes.Existe = True Then
            '    'Me.txtLimiteCredit.Text = oClientes.LIMITE_CREDITO.ToString
            '    'Me.txtLimiteCredit.Text = FormatImporteContable(CDbl(Me.txtLimiteCredit.Text))

            '    Dim sql As New Class_find("SELECT MAX(E.CONCEPTO),MAX(E.FECHA),MAX(C.NOMBRE_EVENTO) FROM SIS_EVENTOS E INNER JOIN SIS_CAT_EVENTOS C ON(E.ID_SIS_CAT_EVENTOS=C.ID_SIS_CAT_EVENTOS) WHERE FOLIO='" & Me.TxtCliente.Text & "'")
            '    If txtLEN(sql.Result2) = True Then
            '        Me.LblUltimaActualizacionLimiteCredit.Text = "" & Format(CDate(sql.Result2), "dd-MMM-yyyy") & " " & sql.Result3 & " " & sql.Result1
            '    End If
            'End If
        Catch ex As Exception
            HandleError(Me.Name, "ConsultarLimiteCredito", ex)
        End Try
    End Function

    Private Function AgregarReglaCXC() As Boolean
        Try
            If valorNumerico(Me.TxtImport.Text) < 0 Then
                MsgBox("El limite de credito debe ser igual o mayor que 0 .", MsgBoxStyle.Information, Me.Text)
                Exit Function
            End If

            If txtLEN(Me.TxtConcept.Text) = False Then
                MsgBox("Asígne el concepto de la regla de cxc.", MsgBoxStyle.Information, Me.Text)
                Me.TxtConcept.Focus()
                Exit Function
            End If

            'permisos
           
            If MsgBox("Desea agregar una regla de cxc por " & FormatImporteContable(CDbl(Me.TxtImport.Text)).ToString & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "AgregarReglaCXC") = MsgBoxResult.No Then
                Exit Function
            End If

            Me.oSisAdministracionClientes = New Class_Sis_Administracion_Clientes
            Me.oSisAdministracionClientes.CodigoCliente = Me.TxtCliente.Text
            Me.oSisAdministracionClientes.DIAS = 1
            Me.oSisAdministracionClientes.CONCEPTO = Me.txtConcepto.Text
            Me.oSisAdministracionClientes.DiasCarteraVentaAntigua = Me.lblDiasCarteraVentaAntigua.Text
            Me.oSisAdministracionClientes.ImporteAutorizado = valorNumerico(Me.TxtImport.Text).ToString

            If Me.oSisAdministracionClientes.InsertarReglaCXC() = False Then
                MsgBox("Error al tratar de agregar una regla de CXC.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            AgregarReglaCXC = True
            MsgBox("Regla de cxc aplicada satisfactoriamente.", MsgBoxStyle.Information, Me.Text)

        Catch ex As Exception
            HandleError(Me.Name, "AgregarReglaCXC", ex)
        End Try
    End Function

    Private Function ConsultaReglasCXC() As Boolean
        Dim dTabla As DataTable

        Dim sCliente As String = Me.TxtCliente.Text
        Try
            'Me.InicializaReglaCXC()
            Me.oSisAdministracionClientes = New Class_Sis_Administracion_Clientes
            Me.oSisAdministracionClientes.CodigoCliente = sCliente

            dTabla = Me.oSisAdministracionClientes.ObtenerReglasCXC(CBool(IIf(Me.ckbReglasActivas.Checked = True, True, False)))
            Me.GridReglasCXC.Rows = 1
            For Each dRow As DataRow In dTabla.Rows
                Me.GridReglasCXC.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & dRow(3).ToString & Chr(9) & dRow(4).ToString & Chr(9))
            Next
            dTabla.Dispose()
            Me.Totales()

            ConsultaReglasCXC = True
        Catch ex As Exception
            HandleError(Me.Text, "ConsultaReglasCXC", ex)
        End Try
    End Function

    Private Sub Totales()
        Try
            Me.lblCXCImporteAutorizadoReglasCXC.Text = FormatImporteContable(FG_Grid_SumaCol(Me.GridReglasCXC, CShort(Me.igyImporteRestante)))

        Catch ex As Exception
            HandleError(Me.Name, "Totales", ex)
        End Try
    End Sub

    Private Function CancelarReglaCxc() As Boolean
        Try
            Dim IDReglaCXC As Integer

            'permisos

            IDReglaCXC = CInt(valorNumerico(Me.GridReglasCXC.Cell(Me.GridReglasCXC.ActiveCell.Row, Me.igyIdRegla).Text))

            If IDReglaCXC <= 0 Then
                MsgBox("No señaló ninguna regla para cancelarla.", vbExclamation, Me.Text)
                Exit Function
            End If

            If MsgBox("Desea cancelar la regla de cxc # " & IDReglaCXC.ToString & " con un importe autorizado de " & _
                      FormatImporteContable(CDbl(Me.GridReglasCXC.Cell(Me.GridReglasCXC.ActiveCell.Row, Me.igyImporteAutorizado).Text)).ToString & _
                      " y un importe restante de " & FormatImporteContable(CDbl(Me.GridReglasCXC.Cell(Me.GridReglasCXC.ActiveCell.Row, Me.igyImporteRestante).Text)).ToString & _
                      " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "CancelarReglaCxc") = MsgBoxResult.No Then
                Exit Function
            End If

            Me.oSisAdministracionClientes = New Class_Sis_Administracion_Clientes
            If Me.oSisAdministracionClientes.CancelarReglaCXC(IDReglaCXC) = False Then
                MsgBox("Error al tratar de cancelar una regla de CXC.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            CancelarReglaCxc = True
            MsgBox("Regla de cxc cancelada satisfactoriamente", MsgBoxStyle.Information, Me.Text)

        Catch ex As Exception
            HandleError(Me.Name, "CancelarReglaCxc", ex)
        End Try
    End Function

    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.TxtCliente.Focus()
    End Sub

    Private Sub llblAgregarSeguimiento_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblAgregarSeguimiento.LinkClicked
        If txtLEN(Me.TxtCliente.Text) = False Then
            MsgBox("Debe de asignar primero un cliente", MsgBoxStyle.Exclamation, Me.Text)
            Me.TxtCliente.Focus()
            Exit Sub
        End If

        Dim Child As New Frm_CXC_Seguimientos(Me.TxtCliente.Text)
        Child.txtNegocio.Text = Usuario.Codigo_Usuario.ToString
        Child.lblNombreNegocio.Text = Usuario.Nombre_Usuario
        'Child.sCodigoCliente = Me.TxtCliente.Text
        Child.ShowDialog()
        Child.Dispose()
        Consultar()
    End Sub

    Private Sub Sis_administracion_clientes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Inicializa()
        DesplegarTipoAcuerdo()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub btnClienteSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClienteSiguiente.Click
        NavegadorClientes("Siguiente")
    End Sub

    Private Sub btnClienteAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClienteAnterior.Click
        NavegadorClientes("Anterior")
    End Sub

    Private Sub btnObservacionesAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObservacionesAnterior.Click
        NavegadorObsercaciones("Anterior")
    End Sub

    Private Sub btnObsevacionesSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObsevacionesSiguiente.Click
        NavegadorObsercaciones("Siguiente")
    End Sub

    Private Function NavegadorSeguimientoCxc(ByVal sTipoDeBusqueda As String) As Boolean
        Try
            If txtLEN(Me.txtCodigoSeguimiento.Text) = False Then
                Me.txtCodigoSeguimiento.Text = "0"
            End If
            Dim oSQl As New Class_find("SELECT DBO.FN_CXC_SEGUIMIENTOS_OBTIENE_SEGUIMIENTO_ANTERIOR('" & Me.TxtCliente.Text & "'," & Me.txtCodigoSeguimiento.Text & ",'" & sTipoDeBusqueda & "')")
            Dim iSeguimiento As Integer = CInt(oSQl.Result1)

            If iSeguimiento < 1 Then
                Exit Function
            End If

            Me.txtCodigoSeguimiento.Text = iSeguimiento.ToString

            ConsultarSeguimientoCxc(iSeguimiento)

            NavegadorSeguimientoCxc = True
        Catch ex As Exception
            HandleError(Me.Name, "NavegadorSeguimientoCxc", ex)
        End Try
    End Function

    Private Function ConsultarSeguimientoCxc(ByVal iSeguimiento As Integer) As Boolean
        Try
            Dim oSQl As New Class_find("select FECHA,SEGUIMIENTO,ESTATUS_REVISADO,CODIGO_RESULTADO_ACUERDO,CODIGO_TIPO_ACUERDO from CXC_SEGUIMIENTOS where IDSEGUIMIENTO='" & iSeguimiento & "' ")

            If txtLEN(oSQl.Result1) = False Then
                Exit Function
            End If

            Me.lblFechaCompromiso.Text = Format(CDate(oSQl.Result1.ToString), "dd-MMM-yyyy hh:mm tt")
            Me.txtSeguimiento.Text = oSQl.Result2

            If oSQl.Result3 = "0" Then
                Me.lblEstatusSeguimiento.Text = "NO REVISADO"
            Else
                Me.lblEstatusSeguimiento.Text = "REVISADO"
            End If

            If oSQl.Result4 = "0" Then
                Me.lblAcuerdoSeguimiento.Text = "NO CUMPLIDO"
            ElseIf oSQl.Result4 = "1" Then
                Me.lblAcuerdoSeguimiento.Text = "CUMPLIDO"
            ElseIf oSQl.Result4 = "2" Then
                Me.lblAcuerdoSeguimiento.Text = "DESCARTADO"
            End If

            Me.cboTipoAcuerdo.SelectedValue = oSQl.Result5

            ConsultarSeguimientoCxc = True
        Catch ex As Exception
            HandleError(Me.Name, "NavegadorSeguimientoCxc", ex)
        End Try
    End Function

    Private Function ConsultarObservacionesCxc() As Boolean
        Dim sQuery As String
        Try
            If txtLEN(Me.lblIDObservaciones.Text) = False Then
                sQuery = "SELECT MAX(ID_OBSERVACION_CLIENTE),MAX(FECHA_ACTUALIZACION),MAX(OBSERVACIONES) FROM CXC_OBSEVACIONES_NEGOCIACIONES WHERE CODIGO_CLIENTE='" & Me.TxtCliente.Text & "'"
            Else
                sQuery = "SELECT ID_OBSERVACION_CLIENTE,FECHA_ACTUALIZACION,OBSERVACIONES FROM CXC_OBSEVACIONES_NEGOCIACIONES WHERE CODIGO_CLIENTE='" & Me.TxtCliente.Text & "' AND ID_OBSERVACION_CLIENTE=" & Me.lblIDObservaciones.Text
            End If

            Dim oSQl As New Class_find(sQuery)

            If txtLEN(oSQl.Result1) = False Then
                Exit Function
            End If

            Me.lblIDObservaciones.Text = oSQl.Result1
            Me.lblFechaObservacion.Text = Format(CDate(oSQl.Result2.ToString), "dd-MMM-yyyy hh:mm tt")
            Me.txtObservaciones.Text = oSQl.Result3

            ConsultarObservacionesCxc = True
            Me.CambiarEstadoObservaciones("CONSULTAR")

        Catch ex As Exception
            HandleError(Me.Name, "ConsultarObservacionesCxc", ex)
        End Try
    End Function

    Private Function ActualizaPlazoDirectamente() As Boolean
        Try
            If valorNumerico(Me.txtDiasPlazo.Text) <= 0 Then
                MsgBox("Asígne el plazo en días de crédito a actualizar.", MsgBoxStyle.Information, Me.Text)
                If Me.txtDiasPlazo.Enabled = True Then Me.txtDiasPlazo.Focus()
                Exit Function
            End If

            'permisos
            If MsgBox("Desea actualizar directamente el plazo en dias de crédito del cliente por " & Me.txtDiasPlazo.Text.ToString & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "ActualizaPlazoDirectamente") = MsgBoxResult.No Then
                Exit Function
            End If

            Me.oSisAdministracionClientes = New Class_Sis_Administracion_Clientes
            Me.oSisAdministracionClientes.CodigoCliente = Me.TxtCliente.Text
            Me.oSisAdministracionClientes.PLAZO = Me.txtDiasPlazo.Text

            If Me.oSisAdministracionClientes.ActulizaPlazo(CBool(IIf(Me.ckbRecaularVencimientos.Checked = True, True, False)), CBool(IIf(Me.ckbRangoFechas.Checked = True, True, False)), Format(dpFechaDesde.Value, "yyyy-dd-MM").ToString, Format(dpFechaHasta.Value, "yyyy-dd-MM").ToString) = False Then
                MsgBox("Error al tratar de actualizar plazo de CXC.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            'Me.cmdDatosCreditoActualizarLimiteCredito.Enabled = True
            ActualizaPlazoDirectamente = True
            MsgBox("Se ha actualizado el plazo de crédito al cliente satisfactoriamente.", vbInformation, Me.Text)

        Catch ex As Exception
            HandleError(Me.Name, "ActualizaPlazoDirectamente", ex)
        End Try
    End Function

    Private Function ConvertirVentaContadoACredito() As Boolean
        Try
            If txtLEN(Me.TxtFolio.Text) = False Then
                MsgBox("Asígne el folio del documento a convertir.", MsgBoxStyle.Information, Me.Text)
                If Me.TxtFolio.Enabled = True Then Me.TxtFolio.Focus()
                Exit Function
            End If

            Dim oVentas As New Class_Ventas_Global
            oVentas = New Class_Ventas_Global(Me.TxtFolio.Text)

            If oVentas.Existe = False Then
                MsgBox("La venta que desea convertir no existe.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            'permisos
            If MsgBox("Desea convertir la venta " & Me.TxtFolio.Text & " de contado a crédito? ", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "ConvertirVentaContadoACredito") = MsgBoxResult.No Then
                Exit Function
            End If

            Me.oSisAdministracionClientes = New Class_Sis_Administracion_Clientes
            Me.oSisAdministracionClientes.CodigoCliente = Me.TxtCliente.Text
            'Me.oSisAdministracionClientes.PLAZO = Me.txtDiasPlazo.Text

            If Me.oSisAdministracionClientes.ConvertirContadoAcreedito(Me.TxtFolio.Text) = False Then
                MsgBox("Error al tratar de convertir la venta de contado a crédito.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            ConvertirVentaContadoACredito = True
            MsgBox("Se ha actualizado el tipo de negociación la venta de contado a crédito satisfactoriamente.", vbInformation, Me.Text)

        Catch ex As Exception
            HandleError(Me.Name, "ConvertirVentaContadoACredito", ex)
        End Try
    End Function

    'Se agrego 
    Private Sub ckbRecaularVencimientos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbRecaularVencimientos.CheckedChanged
        If Me.ckbRecaularVencimientos.Checked = True Then
            Me.ckbRangoFechas.Checked = False
            Me.ckbRangoFechas.Enabled = True
        Else
            Me.ckbRangoFechas.Checked = False
            Me.ckbRangoFechas.Enabled = False
        End If
    End Sub

    'Se agrego 
    Private Sub ckbRangoFechas_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbRangoFechas.CheckedChanged
        If Me.ckbRangoFechas.Checked = True Then
            Me.lblDisplayDesde.Enabled = True
            Me.lblDisplayHasta.Enabled = True
            Me.dpFechaDesde.Enabled = True
            Me.dpFechaHasta.Enabled = True
        Else
            Me.lblDisplayDesde.Enabled = False
            Me.lblDisplayHasta.Enabled = False
            Me.dpFechaDesde.Enabled = False
            Me.dpFechaHasta.Enabled = False
        End If
    End Sub

    Private Sub dpFechaHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpFechaHasta.ValueChanged
        If Me.dpFechaHasta.Value < Me.dpFechaDesde.Value Then
            Me.dpFechaHasta.Value = Me.dpFechaDesde.Value
        End If
    End Sub

    Private Sub dpFechaDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpFechaDesde.ValueChanged
        If Me.dpFechaDesde.Value > Me.dpFechaHasta.Value Then
            Me.dpFechaDesde.Value = Me.dpFechaHasta.Value
        End If
    End Sub

    Private Sub txtCodigoSeguimiento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoSeguimiento.KeyPress
        txtSoloNumerosEnteros(e)
    End Sub

    Private Sub btnSeguimientoAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeguimientoAnterior.Click
        NavegadorSeguimientoCxc("Anterior")
    End Sub

    Private Sub btnSeguimientoSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeguimientoSiguiente.Click
        NavegadorSeguimientoCxc("Siguiente")
    End Sub

    Private Sub btnSeguimientoCumplido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeguimientoCumplido.Click
        If ValidaSeguimiento() = False Then
            Exit Sub
        End If
        If Me.oSisAdministracionClientes.ActualizaEstatusSeguimiento(CInt(Me.txtCodigoSeguimiento.Text), 1) = False Then
            MsgBox("No se pudo actualizar el estatus del seguimiento", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        ConsultarSeguimientoCxc(CInt(Me.txtCodigoSeguimiento.Text))
    End Sub

    Private Sub btnSeguimientoNoCumplido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeguimientoNoCumplido.Click
        If ValidaSeguimiento() = False Then
            Exit Sub
        End If
        If Me.oSisAdministracionClientes.ActualizaEstatusSeguimiento(CInt(Me.txtCodigoSeguimiento.Text), 0) = False Then
            MsgBox("No se pudo actualizar el estatus del seguimiento", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        ConsultarSeguimientoCxc(CInt(Me.txtCodigoSeguimiento.Text))
    End Sub

    Private Sub btnSeguimientoDescartado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeguimientoDescartado.Click
        If ValidaSeguimiento() = False Then
            Exit Sub
        End If
        If Me.oSisAdministracionClientes.ActualizaEstatusSeguimiento(CInt(Me.txtCodigoSeguimiento.Text), 2) = False Then
            MsgBox("No se pudo actualizar el estatus del seguimiento", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        ConsultarSeguimientoCxc(CInt(Me.txtCodigoSeguimiento.Text))
    End Sub

    Private Sub btnActualizaTipoAcuerdo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizaTipoAcuerdo.Click
        If ValidaSeguimiento() = False Then
            Exit Sub
        End If
        If Me.oSisAdministracionClientes.ActualizaTipoAcuerdoSeguimiento(CInt(Me.txtCodigoSeguimiento.Text), CInt(Me.cboTipoAcuerdo.SelectedValue)) = False Then
            MsgBox("No se pudo actualizar el tipo de acuerdo del seguimiento", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        MsgBox("Tipo de acuerdo de acuerdo actualizado ", MsgBoxStyle.Information, Me.Text)
        ConsultarSeguimientoCxc(CInt(Me.txtCodigoSeguimiento.Text))
    End Sub

    Private Function ValidaSeguimiento() As Boolean
        If txtLEN(Me.TxtCliente.Text) = False Then
            Exit Function
        End If

        If txtLEN(Me.txtCodigoSeguimiento.Text) = False Then
            Exit Function
        End If

        Dim oSQl As New Class_find("select 1 from CXC_SEGUIMIENTOS where CODIGO_CLIENTE='" & Me.TxtCliente.Text & "' AND IDSEGUIMIENTO=" & Me.txtCodigoSeguimiento.Text & " ")
        If txtLEN(oSQl.Result1) = False Then
            Exit Function
        End If
        ValidaSeguimiento = True
    End Function

    Private Function ValidaObservacion() As Boolean
        If txtLEN(Me.TxtCliente.Text) = False Then
            Exit Function
        End If

        'Dim oSQl As New Class_find("select 1 from CXC_SEGUIMIENTOS where CODIGO_CLIENTE='" & Me.TxtCliente.Text & "' AND IDSEGUIMIENTO=" & Me.txtCodigoSeguimiento.Text & " ")
        'If txtLEN(oSQl.Result1) = False Then
        '    Exit Function
        'End If
        ValidaObservacion = True
    End Function

    Private Sub DesplegarTipoAcuerdo()
        Dim oElementos As New Class_CXC_Seguimientos
        With Me.cboTipoAcuerdo
            .DisplayMember = "NOMBRE_TIPO_ACUERDO"
            .ValueMember = "CODIGO_TIPO_ACUERDO"
            Dim dView As New Data.DataView(oElementos.ObtenerTipoAcuerdo)
            ' dView.Sort = "NOMBRE_EJERCICIO"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub CambiarEstadoObservaciones(ByVal sEstado As String)
        Try
            Me.lblEstadoObservacion.Text = sEstado
            Select Case sEstado
                Case "NUEVA"
                    Me.txtObservaciones.Enabled = True
                    Me.btnNuevaObservacion.Enabled = True
                    Me.btnGrabarObservacion.Enabled = True 'Grabar
                    Me.btnModificarObservacion.Enabled = False 'Modificar
                    Me.BtnRegresarObservacion.Enabled = True  'Regresar
                    Me.txtObservaciones.Focus()
                    Me.lblEstadoDescripcionObservacion.Text = "Agregando una nueva observación"
                Case "CONSULTAR"
                    Me.txtObservaciones.Enabled = False
                    Me.btnGrabarObservacion.Enabled = False 'Grabar
                    Me.btnModificarObservacion.Enabled = True  'Modificar
                    Me.BtnRegresarObservacion.Enabled = False 'Regresar
                    Me.lblEstadoDescripcionObservacion.Text = "Consultando observaciones"
                Case "MODIFICAR"
                    Me.txtObservaciones.Enabled = True
                    Me.btnGrabarObservacion.Enabled = True  'Grabar
                    Me.btnModificarObservacion.Enabled = False 'Modificar
                    Me.BtnRegresarObservacion.Enabled = True  'Regresar
                    If Me.Visible = True Then
                        Me.txtObservaciones.Focus()
                    End If
                    Me.lblEstadoDescripcionObservacion.Text = "Modificando observaciones"
            End Select
            Exit Sub
        Catch ex As Exception
            HandleError(Me.Name, "CambiarEstadoObservaciones", ex)
        End Try
    End Sub

    Private Sub btnNuevaObservacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevaObservacion.Click
        If ValidaObservacion() = False Then
            Exit Sub
        End If
        Me.InicializaObservaciones()
        Me.CambiarEstadoObservaciones("NUEVA")

        'If Me.oSisAdministracionClientes.ActualizaEstatusSeguimiento(CInt(Me.txtCodigoSeguimiento.Text), 1) = False Then
        '    MsgBox("No se pudo actualizar el estatus del seguimiento", MsgBoxStyle.Exclamation, Me.Text)
        '    Exit Sub
        'End If
        'ConsultarSeguimientoCxc(CInt(Me.txtCodigoSeguimiento.Text))
    End Sub

    Private Sub btnModificarObservacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarObservacion.Click
        If ValidaObservacion() = False Then
            Exit Sub
        End If
        If Me.ConsultarObservacionesCxc() = False Then
            MsgBox("No hay ninguna observación para modificar.", vbExclamation, Me.Text)
        Else
            Me.CambiarEstadoObservaciones("MODIFICAR")
        End If
    End Sub

    Private Sub btnGrabarObservacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabarObservacion.Click
        If ValidaObservacion() = False Then
            Exit Sub
        End If
        If Me.GrabarObservacion = True Then
            'CambiarEstadoObservaciones "CONSULTAR" esta dentro de RefrescarResumenCXC
            Me.RefrescarResumenCXC()
        End If
    End Sub

    Private Sub BtnRegresarObservacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRegresarObservacion.Click
        If ValidaObservacion() = False Then
            Exit Sub
        End If
        Me.RefrescarResumenCXC()
    End Sub

    Private Function GrabarObservacion() As Boolean
        Dim bAgregar As Boolean = False

        If MsgBox("Desea grabar la observación?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "GrabarObservacion") = MsgBoxResult.No Then
            Exit Function
        End If

        Try
            Select Case Me.lblEstadoObservacion.Text
                Case "NUEVA"
                    bAgregar = True
            End Select

            Me.oSisAdministracionClientes = New Class_Sis_Administracion_Clientes
            Me.oSisAdministracionClientes.CodigoCliente = Me.TxtCliente.Text

            If txtLEN(Me.TxtCliente.Text) = False Then
                MsgBox("Seleccione un cliente observación de negociación.", MsgBoxStyle.Information, Me.Text)
                Me.TxtCliente.Focus()
                Exit Function
            End If

            If txtLEN(Me.txtObservaciones.Text) = False Then
                MsgBox("Asígne una observación de negociación.", MsgBoxStyle.Information, Me.Text)
                Me.txtObservaciones.Focus()
                Exit Function
            End If

            Me.lblIDObservaciones.Text = Me.oSisAdministracionClientes.ObservacionesNegociaciones(Me.txtObservaciones.Text, CBool(IIf(bAgregar = True, True, False)), CInt(IIf(valorNumerico(Me.lblIDObservaciones.Text) = Convert.ToInt32(False), 0, Me.lblIDObservaciones.Text)))

            If txtLEN(Me.lblIDObservaciones.Text) = False Then
                MsgBox("No se pudo grabar la observación de negociación.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            GrabarObservacion = True

            MsgBox("Observación grabada satisfactoriamente.", vbInformation, Me.Text)
        Catch ex As Exception
            HandleError(Me.Name, "GrabarObservacion", ex)
        End Try
    End Function

    Private Sub RefrescarResumenCXC()
        Try
            If Me.ConsultarObservacionesCxc() = False Then
                Me.CambiarEstadoObservaciones("NUEVA")
            End If
            Me.CambiarEstadoObservaciones("CONSULTAR")
            Exit Sub

        Catch ex As Exception
            HandleError(Me.Name, "RefrescarResumenCXC", ex)
        End Try
    End Sub

    Private Function NavegadorClientes(ByVal sTipoDeBusqueda As String) As Boolean
        Try
            'Dim iCliente As Integer, sCliente As String, sTipoMercado As String
            If txtLEN(Me.TxtCliente.Text) = False Then
                Dim oSQl As New Class_find("SELECT MIN(CODIGO_CLIENTE) FROM CAT_CLIENTES")
                Me.TxtCliente.Text = oSQl.Result1.ToString
                Me.Consultar()
                Exit Function
            End If

            Me.oClientes = New Class_CatClientes(Me.TxtCliente.Text)
            If Me.oClientes.Existe = False Then
                Dim oSQl As New Class_find("SELECT MIN(CODIGO_CLIENTE) FROM CAT_CLIENTES")
                Me.TxtCliente.Text = oSQl.Result1.ToString
                Me.Consultar()
                Exit Function
            End If

            'sTipoMercado = Strings.Left(Me.TxtCliente.Text, 2)

            If sTipoDeBusqueda = "Anterior" Then
                'iCliente = CInt(Strings.Right(Me.TxtCliente.Text, 4))
                'iCliente = iCliente - 1
                'sCliente = "0000" + iCliente.ToString
                'Me.TxtCliente.Text = sTipoMercado + sCliente.Substring(Len(sCliente) - 4)
                'If iCliente > 0 Then
                '    Me.Consultar()
                'Else
                '    Me.Inicializa()
                'Dim oSQl As New Class_find("SELECT MIN(CODIGO_CLIENTE) FROM CAT_CLIENTES WHERE CODIGO_CLIENTE LIKE '" & sTipoMercado & "%'")
                Dim oSQl As New Class_find("SELECT MAX(CODIGO_CLIENTE) FROM CAT_CLIENTES WHERE CODIGO_CLIENTE<'" & Me.TxtCliente.Text & "'")
                'If CInt(Strings.Right(oSQl.Result1, 4)) >= iCliente Then
                Me.TxtCliente.Text = oSQl.Result1.ToString
                Me.Consultar()
                'Else
                '    If sTipoMercado = Strings.Left(oSQl.Result1, 2) Then
                '        Me.TxtCliente.Text = oSQl.Result1
                '        Me.Consultar()
                '    End If
                'End If
                'End If
            ElseIf sTipoDeBusqueda = "Siguiente" Then
                'iCliente = CInt(Strings.Right(Me.TxtCliente.Text, 4))
                'iCliente = iCliente + 1
                'sCliente = "0000" + iCliente.ToString

                'Me.TxtCliente.Text = sTipoMercado + sCliente.Substring(Len(sCliente) - 4)

                'If iCliente > 0 Then
                Dim oSQl1 As New Class_find("SELECT MIN(CODIGO_CLIENTE) FROM CAT_CLIENTES WHERE CODIGO_CLIENTE>'" & Me.TxtCliente.Text & "'")
                'If CInt(Strings.Right(oSQl1.Result1, 4)) < iCliente Then
                'Dim sCodigo As String
                'Me.TxtCliente.Text = (Len("0000" + (CInt(Strings.Left(oSQl1.Result3, 4)) + 1).ToString) - 1).ToString
                'Dim oSQl2 As New Class_find("SELECT MIN(C.CODIGO_CLIENTE) FROM CAT_CLIENTES C INNER JOIN EMB_CAT_MERCADOS E ON (LEFT(C.CODIGO_CLIENTE,1)=E.CODIGO_MERCADO) INNER JOIN VENTAS_CAT_TIPOS_MERCADO V ON(E.CODIGO_TIPO_MERCADO=" & sCodigo & ") WHERE CODIGO_MERCADO='" & sTipoMercado & "%'")
                Me.TxtCliente.Text = oSQl1.Result1
                Me.Consultar()
                'Else
                'Me.Consultar()
                'End If
                'End If
            End If

            NavegadorClientes = True
        Catch ex As Exception
            HandleError(Me.Name, "NavegadorClientes", ex)
        End Try
    End Function

    Private Function NavegadorObsercaciones(ByVal sTipoDeBusqueda As String) As Boolean
        Try
            Dim iIdObsercaciones As Integer ', sIdObsercaciones As String
            If Me.ValidaObservacion() = False Then
                Exit Function
            End If

            If sTipoDeBusqueda = "Anterior" Then
                If valorNumerico(Me.lblIDObservaciones.Text) > 0 Then
                    iIdObsercaciones = CInt(Me.lblIDObservaciones.Text) - 1
                    If iIdObsercaciones < 1 Then
                        'iIdObsercaciones = 1
                        Me.RefrescarResumenCXC()
                    Else
                        Me.lblIDObservaciones.Text = iIdObsercaciones.ToString
                        Me.RefrescarResumenCXC()
                    End If
                End If
            ElseIf sTipoDeBusqueda = "Siguiente" Then
                If valorNumerico(Me.lblIDObservaciones.Text) > 0 Then
                    iIdObsercaciones = CInt(Me.lblIDObservaciones.Text) + 1
                    Me.ConsultarObservacionesCxc()
                    Dim oSQl As New Class_find("SELECT MAX(ID_OBSERVACION_CLIENTE) FROM CXC_OBSEVACIONES_NEGOCIACIONES WHERE CODIGO_CLIENTE='" & Me.TxtCliente.Text & "'")
                    If iIdObsercaciones > CInt(oSQl.Result1) Then
                        Me.lblIDObservaciones.Text = oSQl.Result1
                        Me.RefrescarResumenCXC()
                    Else
                        Me.lblIDObservaciones.Text = iIdObsercaciones.ToString
                        Me.RefrescarResumenCXC()
                    End If
                End If
            End If

            NavegadorObsercaciones = True
        Catch ex As Exception
            HandleError(Me.Name, "NavegadorObsercaciones", ex)
        End Try
    End Function

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If Usuario.ADMON_CREDITOS = 1 Then
            Me.gbAutorizaciones.Enabled = True
        Else
            Me.gbAutorizaciones.Enabled = False
        End If

    End Sub
End Class