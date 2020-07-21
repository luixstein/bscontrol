Option Strict On

Public Class ConfiguracionEmpresa

#Region "Opciones"
    Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
        Me.Grabar()
    End Sub

    Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos de objetos"
    Private Sub ConfiguracionEmpresa_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.txtContraseñaPeriodos.Text = Empresa_Sistema.CONTRASEÑA_PERIODO_TRABAJO_CONTABLE
        Me.txtContraseñaPrecios.Text = Empresa_Sistema.CONTRASEÑA_PRECIO_MENOR_COSTO
        Me.TxtPorcentajeUtilidadMinima.Text = Empresa_Sistema.PORCENTAJE_UTLIDAD_VENTA_MINIMO.ToString
    End Sub

#Region "Eventos Genericos"
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContraseñaPeriodos.KeyPress, txtContraseñaPrecios.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtContraseñaPeriodos.KeyDown, txtContraseñaPrecios.KeyDown, TxtPorcentajeUtilidadMinima.KeyDown
        If e.KeyCode = Keys.Return Then
            txtTAB(e)
        End If
    End Sub

    Private Sub txtNumericos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPorcentajeUtilidadMinima.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

#End Region

#End Region

#Region "Métodos y procedimientos"
    Private Function Grabar() As Boolean
        Const sProcedure As String = "Grabar"
        Dim bResultado As Boolean = False

        Try
            If txtLEN(Me.txtContraseñaPeriodos.Text) = False Then
                MsgBox("Asígne por favor la contraseña de periodo contable.", vbExclamation, sProcedure)
                Me.txtContraseñaPeriodos.Focus()
                Return False
            End If

            If txtLEN(Me.txtContraseñaPrecios.Text) = False Then
                MsgBox("Asígne por favor la contraseña de precio menor que el costo.", vbExclamation, sProcedure)
                Me.txtContraseñaPeriodos.Focus()
                Return False
            End If

            If txtLEN(Me.TxtPorcentajeUtilidadMinima.Text) = False Then
                Me.TxtPorcentajeUtilidadMinima.Text = "0"
            End If

            Empresa_Sistema.CONTRASEÑA_PERIODO_TRABAJO_CONTABLE = Me.txtContraseñaPeriodos.Text
            Empresa_Sistema.CONTRASEÑA_PRECIO_MENOR_COSTO = Me.txtContraseñaPrecios.Text
            Empresa_Sistema.PORCENTAJE_UTLIDAD_VENTA_MINIMO = valorNumerico(Me.TxtPorcentajeUtilidadMinima.Text)
            bResultado = Empresa_Sistema.Grabar

            If bResultado = True Then
                MsgBox("Datos grabados correctamente.", MsgBoxStyle.Information, sProcedure)
            End If

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function
#End Region

End Class