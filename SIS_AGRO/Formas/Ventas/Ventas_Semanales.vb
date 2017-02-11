Public Class Ventas_Semanales

    Private oVentaSemana As Class_VentasSemanales

#Region "Columnas GridVentas"
    Private iGyVentaIDVenta As Integer = 1
    Private iGyVentaCodigo As Integer = 2
    Private iGyVentaCultivo As Integer = 3

    Private iGyVentaBultosS As Integer = 4
    Private iGyVentaVentaS As Integer = 5
    Private iGyVentaAjustesS As Integer = 6
    Private iGyVentaVentaNetaS As Integer = 7
    Private iGyVentaPrecioPromedioS As Integer = 8

    Private iGyVentaBultosA As Integer = 9
    Private iGyVentaVentaA As Integer = 10
    Private iGyVentaAjustesA As Integer = 11
    Private iGyVentaVentaNetaA As Integer = 12
    Private iGyVentaPrecioPromedioA As Integer = 13

    Private iGyVentaBultosST As Integer = 14
    Private iGyVentaVentaST As Integer = 15
    Private iGyVentaAjustesST As Integer = 16
    Private iGyVentaVentaNetaST As Integer = 17
    Private iGyVentaPrecioPromedioST As Integer = 18

    Private iGyVentaBultosAT As Integer = 19
    Private iGyVentaVentaAT As Integer = 20
    Private iGyVentaAjustesAT As Integer = 21
    Private iGyVentaVentaNetaAT As Integer = 22
    Private iGyVentaPrecioPromedioAT As Integer = 23
#End Region

#Region "Columnas GridGastos"
    Private iGyGastoIDGasto As Integer = 1
    Private iGyGastoCodigo As Integer = 2
    Private iGyGastoNombre As Integer = 3
    Private iGyGastoGastoS As Integer = 4
    Private iGyGastoGastoA As Integer = 5
    Private iGyGastoGastoST As Integer = 6
    Private iGyGastoGastoAT As Integer = 7
#End Region

#Region "Opciones"
    Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
    Private Sub btnAgregarVenta_Click(sender As Object, e As EventArgs) Handles btnAgregarVenta.Click
        Me.AgregarVenta()
    End Sub
    Private Sub btnEliminarVenta_Click(sender As Object, e As EventArgs) Handles btnEliminarVenta.Click
        Me.EliminarVenta()
    End Sub
    Private Sub btnAgregarGasto_Click(sender As Object, e As EventArgs) Handles btnAgregarGasto.Click
        Me.AgregarGasto()
    End Sub
    Private Sub btnEliminarGasto_Click(sender As Object, e As EventArgs) Handles btnEliminarGasto.Click
        Me.EliminarGasto()
    End Sub
    Private Sub btnNavegadorSemanaAtras_Click(sender As Object, e As EventArgs) Handles btnNavegadorSemanaAtras.Click
        If Me.CboSemana1.SelectedIndex > 0 Then
            Me.CboSemana1.SelectedIndex -= 1
        End If
    End Sub
    Private Sub btnNavegadorSemanaAdelante_Click(sender As Object, e As EventArgs) Handles btnNavegadorSemanaAdelante.Click
        If Me.CboSemana1.SelectedIndex < Me.CboSemana1.Items.Count - 1 Then
            Me.CboSemana1.SelectedIndex += 1
        End If
    End Sub
#End Region

#Region "Eventos de objetos"
#Region "Eventos"
    Private Sub Ventas_Semanales_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DesplegarCultivos()
        Me.DesplegarContratos()
        Me.DesplegarSemanas()
        Me.DesplegarGastos()
        Me.Inicializa()
    End Sub

    Private Sub CboSemana1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboSemana1.SelectedIndexChanged
        'Private Sub CboSemana1_SelectedValueChanged(sender As Object, e As EventArgs) Handles CboSemana1.SelectedValueChanged
        If Me.CboSemana1.SelectedIndex <> -1 Then
            'Me.txtSemana2.Text = DirectCast(Me.CboSemana1.SelectedItem, DataRowView)("FECHA2").ToString()
            Me.txtSemana2.Text = Format(CDate(Me.CboSemana1.Text).AddDays(6), "dd-MMM-yy").ToUpper
        End If
        Me.Consultar()
    End Sub

    Private Sub cboContrato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboContrato.SelectedIndexChanged
        Me.Consultar()
    End Sub

    Private Sub cboCultivo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCultivo.SelectedIndexChanged
        'Me.Consultar()
        If Me.cboCultivo.SelectedIndex <> -1 Then
            Me.txtBultos.Focus()
        End If
    End Sub

    Private Sub cboGasto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGasto.SelectedIndexChanged
        If Me.cboGasto.SelectedIndex <> -1 Then
            Me.txtGasto.Focus()
        End If
    End Sub

    Private Sub txtBultos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBultos.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txtBultos.Text = FormatImporteContable(Me.txtBultos.Text, False)
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtVenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVenta.KeyDown
        If e.KeyCode = Keys.Return Then
            If valorNumerico(Me.txtVenta.Text) > 0 Then
                Me.txtVenta.Text = FormatImporteContable(Me.txtVenta.Text)
            End If
            If Me.RefrescaParciales() Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub txtAjustes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAjustes.KeyDown
        If e.KeyCode = Keys.Return Then
            If valorNumerico(Me.txtAjustes.Text) > 0 Then
                Me.txtAjustes.Text = FormatImporteContable(Me.txtAjustes.Text)
            End If
            If Me.RefrescaParciales() Then
                Me.btnAgregarVenta.Focus()
            End If
        End If
    End Sub

    Private Sub txtGasto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGasto.KeyDown
        If e.KeyCode = Keys.Return Then
            If valorNumerico(Me.txtGasto.Text) > 0 Then
                Me.txtGasto.Text = FormatImporteContable(Me.txtGasto.Text)
            End If
            Me.btnAgregarGasto.Focus()
        End If
    End Sub

    Private Sub txtSaldoEstadoCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSaldoEstadoCuenta.KeyDown
        If e.KeyCode = Keys.Return Then
            If valorNumerico(Me.txtSaldoEstadoCuenta.Text) > 0 Then
                Me.txtSaldoEstadoCuenta.Text = FormatImporteContable(Me.txtSaldoEstadoCuenta.Text)
            End If
            Me.Totales()
        End If
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBultos.Enter, txtVenta.Enter, txtAjustes.Enter, txtVentaNeta.Enter, txtPrecioPromedio.Enter
        Dim oTexBox As TextBox = CType(sender, TextBox)
        oTexBox.SelectAll()
    End Sub

    'Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBultos.KeyDown, txtVenta.KeyDown
    '    If e.KeyCode = Keys.Return Then
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub

    Private Sub txtNumerosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBultos.KeyPress, txtVenta.KeyPress, txtAjustes.KeyPress, txtGasto.KeyPress, _
        txtSaldoEstadoCuenta.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Dim sql As New Class_find("SELECT ID_SEMANA FROM VENTAS_CAT_SEMANAS WHERE '" & Format(Date.Now, "yyyy-dd-MM") & "' BETWEEN FECHA1 AND FECHA2")
        If txtLEN(sql.Result1) = True Then
            Me.CboSemana1.SelectedValue = sql.Result1
        End If
    End Sub

    Private Sub DesplegarCultivos()
        Dim oElementos As New Class_CatCultivos
        With Me.cboCultivo
            .DisplayMember = "NOMBRE_CULTIVO"
            .ValueMember = "CODIGO_CULTIVO"

            Dim dView As New Data.DataView(oElementos.ObtenerElementos)
            dView.Sort = "NOMBRE_CULTIVO"
            .DataSource = dView
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub DesplegarContratos()
        Dim oElementos As New Class_VentasCatContratos
        With Me.cboContrato
            .DisplayMember = "NOMBRE_CONTRATO"
            .ValueMember = "CODIGO_CONTRATO"

            Dim dView As New Data.DataView(oElementos.ObtenerElementos)
            dView.Sort = "NOMBRE_CONTRATO"
            .DataSource = dView
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub DesplegarSemanas()
        Dim oElementos As New Class_VentasCatSemanas
        With Me.CboSemana1
            .DisplayMember = "FECHA1"
            .ValueMember = "ID_SEMANA"

            Dim dView As New Data.DataView(oElementos.ObtenerElementos)
            'dView.Sort = "FECHA1"
            .DataSource = dView
            .SelectedIndex = 0 ' -1
        End With
    End Sub

    Private Sub DesplegarGastos()
        Dim oElementos As New Class_VentasCatGastos
        With Me.cboGasto
            .DisplayMember = "NOMBRE_GASTO"
            .ValueMember = "CODIGO_GASTO"

            Dim dView As New Data.DataView(oElementos.ObtenerElementos)
            dView.Sort = "CODIGO_GASTO"
            .DataSource = dView
            .SelectedIndex = -1
        End With
    End Sub

    Private Function Consultar() As Boolean
        Try
            If Not (Me.CboSemana1.SelectedIndex <> -1 AndAlso Me.cboContrato.SelectedIndex <> -1) Then
                Exit Function
            End If

            Me.oVentaSemana = New Class_VentasSemanales(Me.CboSemana1.SelectedValue, Me.cboContrato.SelectedValue)

            Me.GridVentas.Visible = False
            Me.GridGastos.Visible = False

            Me.GridVentas.DataSource = Me.oVentaSemana.ObtenerVentas
            Me.GridGastos.DataSource = Me.oVentaSemana.ObtenerGastos

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim iOcultarVentas As Integer
            With Me.GridVentas
                For iOcultarVentas = 14 To .Cols - 1
                    .Column(iOcultarVentas).Visible = False
                Next

                .Column(Me.iGyVentaIDVenta).Visible = False

                .Cell(0, Me.iGyVentaCodigo).Text = "Código"
                .Cell(0, Me.iGyVentaCultivo).Text = "Cultivo"

                .Cell(0, Me.iGyVentaBultosS).Text = "Bultos"
                .Cell(0, Me.iGyVentaVentaS).Text = "Importe"
                .Cell(0, Me.iGyVentaAjustesS).Text = "Ajutes"
                .Cell(0, Me.iGyVentaVentaNetaS).Text = "V. Netas"
                .Cell(0, Me.iGyVentaPrecioPromedioS).Text = "P. Prom"

                .Cell(0, Me.iGyVentaBultosA).Text = "Bultos"
                .Cell(0, Me.iGyVentaVentaA).Text = "Importe"
                .Cell(0, Me.iGyVentaAjustesA).Text = "Ajutes"
                .Cell(0, Me.iGyVentaVentaNetaA).Text = "V. Netas"
                .Cell(0, Me.iGyVentaPrecioPromedioA).Text = "P. Prom"

                .Column(Me.iGyVentaCodigo).Width = 50
                .Column(Me.iGyVentaCultivo).Width = 130

                .SelectionMode = FlexCell.SelectionModeEnum.ByRow
                .MultiSelect = False
                .Locked = True
                .Visible = True

                If .Rows > 1 Then
                    Me.txtTotalBultosS.Text = FormatImporteContable(.Cell(1, iGyVentaBultosST).Text)
                    Me.txtTotalVentaS.Text = FormatImporteContable(.Cell(1, iGyVentaVentaST).Text)
                    Me.txtTotalAjustesS.Text = FormatImporteContable(.Cell(1, iGyVentaAjustesST).Text)
                    Me.txtTotalVentaNetasS.Text = FormatImporteContable(.Cell(1, iGyVentaVentaNetaST).Text)
                    Me.txtTotalPrecioPromedioS.Text = FormatImporteContable(.Cell(1, iGyVentaPrecioPromedioST).Text)

                    Me.txtTotalBultosA.Text = FormatImporteContable(.Cell(1, iGyVentaBultosAT).Text)
                    Me.txtTotalVentaA.Text = FormatImporteContable(.Cell(1, iGyVentaVentaAT).Text)
                    Me.txtTotalAjustesA.Text = FormatImporteContable(.Cell(1, iGyVentaAjustesAT).Text)
                    Me.txtTotalVentaNetasA.Text = FormatImporteContable(.Cell(1, iGyVentaVentaNetaAT).Text)
                    Me.txtTotalPrecioPromedioA.Text = FormatImporteContable(.Cell(1, iGyVentaPrecioPromedioAT).Text)
                End If
            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim iOcultarGastos As Integer
            With Me.GridGastos
                For iOcultarGastos = 6 To .Cols - 1
                    .Column(iOcultarGastos).Visible = False
                Next

                .Column(Me.iGyGastoIDGasto).Visible = False

                .Cell(0, Me.iGyGastoCodigo).Text = "Código"
                .Cell(0, Me.iGyGastoNombre).Text = "T. Gasto"
                .Cell(0, Me.iGyGastoGastoS).Text = "Gasto"
                .Cell(0, Me.iGyGastoGastoA).Text = "Gasto Ac"

                .Column(Me.iGyGastoCodigo).Width = 50
                .Column(Me.iGyGastoNombre).Width = 200

                .SelectionMode = FlexCell.SelectionModeEnum.ByRow
                .MultiSelect = False
                .Locked = True
                .Visible = True

                If .Rows > 1 Then
                    Me.txtTotalGastosS.Text = FormatImporteContable(.Cell(1, Me.iGyGastoGastoST).Text)

                    Me.txtTotalGastosA.Text = FormatImporteContable(.Cell(1, Me.iGyGastoGastoAT).Text)
                End If
            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Totales()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Consultar = True
        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
            Me.GridVentas.Visible = True
            Me.GridGastos.Visible = True
        End Try
    End Function

    Private Sub Totales()
        Me.txtSaldoS.Text = FormatImporteContable(valorNumerico(Me.txtTotalVentaNetasS.Text) - valorNumerico(Me.txtTotalGastosS.Text))
        Me.txtSaldoA.Text = FormatImporteContable(valorNumerico(Me.txtTotalVentaNetasA.Text) - valorNumerico(Me.txtTotalGastosA.Text))
        Me.txtDiferenciaSaldo.Text = FormatImporteContable(valorNumerico(Me.txtSaldoEstadoCuenta.Text) - valorNumerico(Me.txtSaldoA.Text))
    End Sub

    Private Function RefrescaParciales() As Boolean
        Me.txtVentaNeta.Text = FormatImporteContable(valorNumerico(Me.txtVenta.Text) - valorNumerico(Me.txtAjustes.Text))
        If valorNumerico(Me.txtBultos.Text) > 0 Then
            Me.txtPrecioPromedio.Text = FormatImporteContable(Redondear(valorNumerico(Me.txtVentaNeta.Text) / valorNumerico(Me.txtBultos.Text), 2))
            RefrescaParciales = True
        Else
            MsgBox("Favor de capturar los bultos.", MsgBoxStyle.Exclamation, Me.Text)
            Me.txtBultos.Focus()
            Exit Function
        End If
        Me.Totales()
    End Function

    Private Sub InicializaVenta()
        Me.txtBultos.Text = ""
        Me.txtVenta.Text = ""
        Me.txtAjustes.Text = ""
        Me.txtVentaNeta.Text = ""
        Me.txtPrecioPromedio.Text = ""
    End Sub

    Private Sub InicializaGasto()
        Me.txtGasto.Text = ""
    End Sub

    Private Function AgregarVenta() As Boolean
        Dim dBultos As Double, dVenta As Double, dAjutes As Double, dVentaNeta As Double, dPrecioPromedio As Double
        Try
            If Me.CboSemana1.SelectedIndex = -1 Then
                MsgBox("Favor de seleccionar la semana.", MsgBoxStyle.Exclamation, Me.Text)
                Me.CboSemana1.Focus()
                Exit Function
            End If

            If Me.cboContrato.SelectedIndex = -1 Then
                MsgBox("Favor de seleccionar el contrato.", MsgBoxStyle.Exclamation, Me.Text)
                Me.cboContrato.Focus()
                Exit Function
            End If

            If Me.cboCultivo.SelectedIndex = -1 Then
                MsgBox("Favor de seleccionar el cultivo.", MsgBoxStyle.Exclamation, Me.Text)
                Me.cboCultivo.Focus()
                Exit Function
            End If

            dBultos = valorNumerico(Me.txtBultos.Text)
            dVenta = valorNumerico(Me.txtVenta.Text)
            dAjutes = valorNumerico(Me.txtAjustes.Text)
            dVentaNeta = dVenta - dAjutes
            If dBultos <= 0 Then
                MsgBox("Favor de capturar los bultos.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtBultos.Focus()
                Exit Function
            End If

            dPrecioPromedio = Redondear(dVentaNeta / dBultos, 2)
            AgregarVenta = Me.oVentaSemana.AgregarVenta(Me.cboCultivo.SelectedValue.ToString, dBultos, dVenta, dAjutes, dPrecioPromedio)

            If AgregarVenta = True Then
                Me.InicializaVenta()
                Me.Consultar()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "AgregarVenta", ex)
        End Try
    End Function

    Private Function EliminarVenta() As Boolean
        Try
            Dim iIDVenta As Integer = IIf(Me.GridVentas.ActiveCell.Row > 0, Me.GridVentas.Cell(Me.GridVentas.ActiveCell.Row, Me.iGyVentaIDVenta).Text, 0)
            If iIDVenta <= 0 Then
                MsgBox("Seleccione un registro que ya tenga información capturada.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If
            EliminarVenta = Me.oVentaSemana.EliminarVenta(iIDVenta)
            If EliminarVenta = True Then
                Me.Consultar()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "EliminarVenta", ex)
        End Try
    End Function

    Private Function AgregarGasto() As Boolean
        Dim dGasto As Double
        Try
            If Me.CboSemana1.SelectedIndex = -1 Then
                MsgBox("Favor de seleccionar la semana.", MsgBoxStyle.Exclamation, Me.Text)
                Me.CboSemana1.Focus()
                Exit Function
            End If

            If Me.cboContrato.SelectedIndex = -1 Then
                MsgBox("Favor de seleccionar el contrato.", MsgBoxStyle.Exclamation, Me.Text)
                Me.cboContrato.Focus()
                Exit Function
            End If

            If Me.cboGasto.SelectedIndex = -1 Then
                MsgBox("Favor de seleccionar el tipo de gasto.", MsgBoxStyle.Exclamation, Me.Text)
                Me.cboGasto.Focus()
                Exit Function
            End If

            dGasto = valorNumerico(Me.txtGasto.Text)
            If dGasto <= 0 Then
                MsgBox("Favor de capturar el gasto.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtGasto.Focus()
                Exit Function
            End If

            AgregarGasto = Me.oVentaSemana.AgregarGasto(Me.cboGasto.SelectedValue.ToString, dGasto)

            If AgregarGasto = True Then
                Me.InicializaGasto()
                Me.Consultar()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "AgregarGasto", ex)
        End Try
    End Function

    Private Function EliminarGasto() As Boolean
        Try
            Dim iIDGasto As Integer = IIf(Me.GridGastos.ActiveCell.Row > 0, Me.GridGastos.Cell(Me.GridGastos.ActiveCell.Row, Me.iGyGastoIDGasto).Text, 0)
            If iIDGasto <= 0 Then
                MsgBox("Seleccione un registro que ya tenga información capturada.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If
            EliminarGasto = Me.oVentaSemana.EliminarGasto(iIDGasto)
            If EliminarGasto = True Then
                Me.Consultar()
            End If
        Catch ex As Exception
            HandleError(Me.Name, "EliminarGasto", ex)
        End Try
    End Function
#End Region

End Class