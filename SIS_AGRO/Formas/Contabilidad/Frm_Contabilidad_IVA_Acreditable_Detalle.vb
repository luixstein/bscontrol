Option Strict On

Public Class Frm_Contabilidad_IVA_Acreditable_Detalle

#Region "Campos"
    Private _bValido As Boolean
#End Region

#Region "Propiedades"
    Public ReadOnly Property Valido() As Boolean
        Get
            Return _bValido
        End Get
    End Property
#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Inicializa()
        Me.txtProveedor.Focus()
    End Sub

    Private Sub tsbAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAgregar.Click
        Me._bValido = Me.Valida()
        Application.DoEvents()
        If Me._bValido = True Then
            Me.Visible = False
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "Eventos de objetos"
#Region "Eventos"
    Private Sub Frm_Contabilidad_IVA_Acreditable_Detalle_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.Inicializa()
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        Dim oProveedores As Class_CatProveedores, sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                oProveedores = New Class_CatProveedores
                sText = oProveedores.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.txtProveedor.Text = sText
                oProveedores = Nothing
            Case Keys.Enter
                If txtLEN(Me.txtProveedor.Text) = False Then
                    Me.lblProveedorRFC.Text = "" : Me.lblProveedorNombre.Text = "" : oProveedores = Nothing : GoTo Buscar : Exit Sub
                End If
                oProveedores = New Class_CatProveedores(Me.txtProveedor.Text)
                If oProveedores.Existe = False Then
                    Me.lblProveedorRFC.Text = "" : Me.lblProveedorNombre.Text = "" : oProveedores = Nothing : GoTo Buscar : Exit Sub
                End If

                Me.lblProveedorRFC.Text = oProveedores.RFC
                Me.lblProveedorNombre.Text = oProveedores.Nombre_Proveedor
                Me.cboTipoProveedor.Text = oProveedores.NOMBRE_TIPO_PROVEEDOR

                txtTAB(e)
            Case Keys.F4
                Dim Child As New Catalogo_Proveedores
                Child.ShowDialog()
        End Select
    End Sub

    Private Sub txtFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolio.KeyDown
        If e.KeyCode = Keys.Return Then
            Dim sql As New Class_find("SELECT 1 FROM VW_CON_IVA_ACREDITABLE_DETALLE WHERE CODIGO_PROVEEDOR='" & Me.txtProveedor.Text & "' AND FOLIO_PROVEEDOR='" & Me.txtFolio.Text & "' AND ESTATUS_POLIZA='A'")
            If sql.Result1 = "1" Then
                MsgBox("El folio de la factura del proveedor ya existe.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtFolio.Focus() : Exit Sub
            Else
                txtTAB(e)
            End If
        End If
    End Sub

    Private Sub btnCalcularIVAS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcularIVAS.Click
        CalcularIVAS(True)
    End Sub

    Private Sub txtIvaRetenido10_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIvaRetenido10.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.tsbAgregar.PerformClick()
        End If
    End Sub

    Private Sub txtActos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtActos0.KeyDown, txtActos11.KeyDown, txtActos16.KeyDown, txtActos8.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.TotalizaActos()
        End If
    End Sub

#End Region

#Region "Eventos Genericos"
    Private Sub txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProveedor.Enter, txtFolio.Enter, txtAño.Enter, txtNumeroOperaciones.Enter, _
    txtActos0.Enter, txtActos11.Enter, txtActos16.Enter, txtIvaAcreditable11.Enter, txtIvaAcreditable16.Enter, txtIvaRetenido4.Enter, txtIvaRetenido10.Enter, txtConcepto.Enter, txtActos8.Enter, txtIvaRetenido6.Enter
        Dim oTexBox As TextBox = CType(sender, TextBox)
        oTexBox.SelectAll()
    End Sub

    Private Sub txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMes.KeyDown, txtAño.KeyDown, txtNumeroOperaciones.KeyDown, _
    cboTipoProveedor.KeyDown, txtActos0.KeyDown, txtActos11.KeyDown, txtActos16.KeyDown, txtIvaAcreditable11.KeyDown, txtIvaAcreditable16.KeyDown, _
    txtIvaRetenido4.KeyDown, dtFechaFacturaProveedor.KeyDown, txtConcepto.KeyDown, txtIvaRetenido6.KeyDown, txtActos8.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolio.KeyPress, txtProveedor.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAño.KeyPress, txtNumeroOperaciones.KeyPress, _
    txtActos0.KeyPress, txtActos11.KeyPress, txtActos16.KeyPress, txtIvaAcreditable11.KeyPress, txtIvaAcreditable16.KeyPress, txtIvaRetenido4.KeyPress, txtIvaRetenido10.KeyPress,
    txtIvaRetenido6.KeyPress, txtActos8.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub txtBeep(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConcepto.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtNoBeep(e)
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"
    Public Sub Inicializa()
        Try
            Me.txtProveedor.Text = ""
            Me.lblProveedorRFC.Text = ""
            Me.lblProveedorNombre.Text = ""
            Me.txtAño.Text = Date.Now.Year.ToString
            Me.cboMes.Text = Format(Month(Now), "0#")
            Me.txtNumeroOperaciones.Text = "1"
            Me.cboTipoProveedor.Text = ""
            Me.txtFolio.Text = ""

            Me.txtActos0.Text = FormatImporteContable(0)
            Me.txtActos8.Text = FormatImporteContable(0)
            Me.txtActos11.Text = FormatImporteContable(0)
            Me.txtActos16.Text = FormatImporteContable(0)
            Me.lblActosTotal.Text = FormatImporteContable(0)
            Me.txtIvaAcreditable8.Text = FormatImporteContable(0)
            Me.txtIvaAcreditable11.Text = FormatImporteContable(0)
            Me.txtIvaAcreditable16.Text = FormatImporteContable(0)
            Me.txtIvaRetenido4.Text = FormatImporteContable(0)
            Me.txtIvaRetenido6.Text = FormatImporteContable(0)
            Me.txtIvaRetenido10.Text = FormatImporteContable(0)

        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Public Sub Inicia()

        Me.lblIvaAcreditablePorCubrir8.Text = FormatImporteContable(valorNumerico(Me.lblIvaAcreditableACubrir8.Text) - valorNumerico(Me.lblIvaAcreditableAcumulado8.Text))
        Me.lblIvaAcreditablePorCubrir11.Text = FormatImporteContable(valorNumerico(Me.lblIvaAcreditableACubrir11.Text) - valorNumerico(Me.lblIvaAcreditableAcumulado11.Text))
        Me.lblIvaAcreditablePorCubrir16.Text = FormatImporteContable(valorNumerico(Me.lblIvaAcreditableACubrir16.Text) - valorNumerico(Me.lblIvaAcreditableAcumulado16.Text))

        If valorNumerico(Me.lblIvaAcreditableACubrir8.Text) = 0 Then
            Me.txtActos8.Enabled = False
            Me.txtIvaAcreditable8.Enabled = False
        End If

        If valorNumerico(Me.lblIvaAcreditableACubrir11.Text) = 0 Then
            Me.txtActos11.Enabled = False
            Me.txtIvaAcreditable11.Enabled = False
        End If

        If valorNumerico(Me.lblIvaAcreditableACubrir16.Text) = 0 Then
            Me.txtActos16.Enabled = False
            Me.txtIvaAcreditable16.Enabled = False
        End If

    End Sub

    Private Function Valida() As Boolean
        If txtLEN(Me.txtProveedor.Text) = False Then
            MsgBox("Asigne el código del proveedor.", MsgBoxStyle.Exclamation, Me.Text)
            Me.txtProveedor.Focus() : Exit Function
        End If

        If txtLEN(Me.txtAño.Text) = False Then
            MsgBox("Asigne el año de la última operación.", MsgBoxStyle.Exclamation, Me.Text)
            Me.txtAño.Focus() : Exit Function
        End If
        If txtLEN(Me.txtNumeroOperaciones.Text) = False Then
            MsgBox("Asigne el número de operaciones.", MsgBoxStyle.Exclamation, Me.Text)
            Me.txtNumeroOperaciones.Focus() : Exit Function
        End If
        If txtLEN(Me.txtFolio.Text) = False Then
            MsgBox("Asigne el folio.", MsgBoxStyle.Exclamation, Me.Text)
            Me.txtFolio.Focus() : Exit Function
        End If
        Dim sql As New Class_find("SELECT 1 FROM VW_CON_IVA_ACREDITABLE_DETALLE WHERE CODIGO_PROVEEDOR='" & Me.txtProveedor.Text & "' AND FOLIO_PROVEEDOR='" & Me.txtFolio.Text & "' AND ESTATUS_IVA='A'")
        If sql.Result1 = "1" Then
            MsgBox("El folio de la factura del proveedor ya existe.", MsgBoxStyle.Exclamation, Me.Text)
            Me.txtFolio.Focus() : Exit Function
        End If

        If CalcularIVAS(False) = False Then
            Exit Function
        End If

        Valida = True
    End Function

    Private Sub TotalizaActos()
        Dim drActos0 As Double, drActos11 As Double, drActos16 As Double, drActos8 As Double

        drActos0 = Redondear(valorNumerico(Me.txtActos0.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD)
        drActos8 = Redondear(valorNumerico(Me.txtActos8.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD)
        drActos11 = Redondear(valorNumerico(Me.txtActos11.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD)
        drActos16 = Redondear(valorNumerico(Me.txtActos16.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD)

        Me.lblActosTotal.Text = FormatImporteContable(drActos0 + drActos11 + drActos16 + drActos8)
    End Sub

    Private Function CalcularIVAS(ByVal bRecalcularIVAS As Boolean) As Boolean
        Dim drActos0 As Double, drActos11 As Double, drActos16 As Double, drActos As Double, drActos8 As Double
        Dim drIvaAcreditable11 As Double, drIvaAcreditable16 As Double, drIvaAcreditable8 As Double
        Dim drIvaRetenido4 As Double, drIvaRetenido10 As Double, drIvaRetenido6 As Double

        drActos0 = Redondear(valorNumerico(Me.txtActos0.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD)
        drActos8 = Redondear(valorNumerico(Me.txtActos8.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD)
        drActos11 = Redondear(valorNumerico(Me.txtActos11.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD)
        drActos16 = Redondear(valorNumerico(Me.txtActos16.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD)

        drIvaRetenido4 = Redondear(valorNumerico(Me.txtIvaRetenido4.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD)
        drIvaRetenido6 = Redondear(valorNumerico(Me.txtIvaRetenido6.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD)
        drIvaRetenido10 = Redondear(valorNumerico(Me.txtIvaRetenido10.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD)

        drActos = drActos0 + drActos11 + drActos16 + drActos8

        If drActos <= 0 Then
            MsgBox("No capturaron los actos del movimiento.", vbExclamation, Me.Text)
            Exit Function
        End If

        'If _
        '(drActos11 > 0 And (drActos16 > 0)) Or _
        '(drActos16 > 0 And (drActos11 > 0)) Or _
        '(drActos8 > 0 And (drActos11 > 0)) Or _
        '(drActos11 > 0 And (drActos8 > 0)) Or _
        '(drActos8 > 0 And (drActos16 > 0)) Or _
        '(drActos16 > 0 And (drActos8 > 0)) Then
        '    MsgBox("No esta permitido agregar actos de diferentes impuestos en un mismo movimiento.", vbExclamation, Me.Text)
        '    Exit Function
        'End If

        If bRecalcularIVAS = True Then
            'Si se capturaron actos al 10%, se calcula el iva acreditable al 10%.
            If drActos11 > 0 Then
                drIvaAcreditable11 = Redondear(drActos11 * 0.11, Empresa_Sistema.DECIMALES_CONTABILIDAD)
            ElseIf drActos16 > 0 Then
                drIvaAcreditable16 = Redondear(drActos16 * 0.16, Empresa_Sistema.DECIMALES_CONTABILIDAD)
            ElseIf drActos8 > 0 Then
                drIvaAcreditable8 = Redondear(drActos8 * 0.08, Empresa_Sistema.DECIMALES_CONTABILIDAD)
            End If
        Else
            drIvaAcreditable8 = Redondear(valorNumerico(Me.txtIvaAcreditable8.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD)
            drIvaAcreditable11 = Redondear(valorNumerico(Me.txtIvaAcreditable11.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD)
            drIvaAcreditable16 = Redondear(valorNumerico(Me.txtIvaAcreditable16.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD)
        End If

        Me.txtActos0.Text = FormatImporteContable(drActos0)
        Me.txtActos8.Text = FormatImporteContable(drActos8)
        Me.txtActos11.Text = FormatImporteContable(drActos11)
        Me.txtActos16.Text = FormatImporteContable(drActos16)
        Me.lblActosTotal.Text = FormatImporteContable(drActos)

        Me.txtIvaAcreditable8.Text = FormatImporteContable(drIvaAcreditable8)
        Me.txtIvaAcreditable11.Text = FormatImporteContable(drIvaAcreditable11)
        Me.txtIvaAcreditable16.Text = FormatImporteContable(drIvaAcreditable16)

        Me.txtIvaRetenido4.Text = FormatImporteContable(drIvaRetenido4)
        Me.txtIvaRetenido6.Text = FormatImporteContable(drIvaRetenido6)
        Me.txtIvaRetenido10.Text = FormatImporteContable(drIvaRetenido10)

        CalcularIVAS = True
    End Function
#End Region

End Class