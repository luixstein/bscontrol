Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_Nomina_Configuracion

#Region "Campos privados"
    Private Enum enumEstados
        NUEVO
        EDICION
        CONSULTA
    End Enum

    Private Estado As enumEstados
    Private Run As Boolean
    Private msgElemento As String
#End Region

#Region "Constructor y destructor"
    'Inicializa al objeto.
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Try
            Me.Run = False
            Estado = enumEstados.CONSULTA
            Me.DesplegarTemporadas()
            Me.Cambia_Estado()

        Catch ex As Exception
            HandleError(Me.Name, "New", ex)
        End Try

    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub

#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Estado = enumEstados.NUEVO
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = " grabar las configuración de nomina"
            Case enumEstados.NUEVO
                sMsg = " agregar las configuración de nomina"
        End Select
        sMsg = "Deseas " & sMsg & " ?"
        If MsgBox(sMsg, CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle)) = MsgBoxResult.Yes Then
            Me.Grabar()
        End If
    End Sub

    Private Sub tsbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
        Me.Estado = enumEstados.CONSULTA
        Me.Cambia_Estado()
        Me.Consultar()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub Cambia_Estado()

        Select Case Me.Estado

            Case enumEstados.NUEVO
                Me.gBoxInformacion.Enabled = True
                Me.tssLabelEstado.Text = "Agregando nuevo " & Me.msgElemento
                'Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtSueldoDiario.Enabled = True
                Me.txtRegistroPatronal.Enabled = True
                Me.txtSemanaActual.Enabled = True
                Me.txtEquivalenciaJornalHoras.Enabled = True
                Me.txtEdadMinima.Enabled = True
                Me.txtRutaFotosTrabajadores.Enabled = True
                Me.txtRutaIDSE.Enabled = True
                Me.txtRutaDispersion.Enabled = True
                Me.txtTipoTrabajador.Enabled = True

                Me.InicializaElemento()

                Me.TxtSueldoDiario.Focus()

            Case enumEstados.EDICION
                Me.gBoxInformacion.Enabled = True
                Me.tssLabelEstado.Text = "Edición"
                'Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True

                Me.TxtId.Enabled = False
                Me.TxtSueldoDiario.Enabled = True
                Me.txtRegistroPatronal.Enabled = True
                Me.txtSemanaActual.Enabled = True
                Me.txtEquivalenciaJornalHoras.Enabled = True
                Me.txtEdadMinima.Enabled = True
                Me.txtRutaFotosTrabajadores.Enabled = True
                Me.txtRutaIDSE.Enabled = True
                Me.txtRutaDispersion.Enabled = True
                Me.txtTipoTrabajador.Enabled = True

                Me.TxtSueldoDiario.Focus()

            Case Else
                Me.gBoxInformacion.Enabled = False
                Me.tssLabelEstado.Text = "Consulta"
                'Me.tsbNuevo.Enabled = True
                Me.tsbEditar.Enabled = True
                Me.tsbGrabar.Enabled = False
                Me.tsbCancelar.Enabled = False

                Me.TxtSueldoDiario.Enabled = False
                Me.txtRegistroPatronal.Enabled = False
                Me.txtSemanaActual.Enabled = False
                Me.txtEquivalenciaJornalHoras.Enabled = False
                Me.txtEdadMinima.Enabled = False
                Me.txtRutaFotosTrabajadores.Enabled = False
                Me.txtRutaIDSE.Enabled = False
                Me.txtRutaDispersion.Enabled = False
                Me.txtTipoTrabajador.Enabled = False

        End Select
        Application.DoEvents()
    End Sub

    Private Sub InicializaElemento()
        Me.TxtSueldoDiario.Text = ""
        Me.txtRegistroPatronal.Text = ""
        Me.txtSemanaActual.Text = ""
        Me.txtEquivalenciaJornalHoras.Text = ""
        Me.txtEdadMinima.Text = ""
        Me.txtRutaFotosTrabajadores.Text = ""
        Me.txtRutaIDSE.Text = ""
        Me.txtRutaDispersion.Text = ""
        Me.txtTipoTrabajador.Text = ""
        Me.DesplegarTemporadas()
    End Sub

    Private Function Grabar() As Boolean
        'Dim oElemento As New Class_SisEmpresaNomina
        Dim bResultado As Boolean = False

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                'oElemento = New Class_SisEmpresaNomina
                Try
                    'With oElemento
                    Plaza.oSisPlazaNomina.NOMINA_SUELDO_DIARIO = CDbl(Me.TxtSueldoDiario.Text)
                    Plaza.oSisPlazaNomina.NOMINA_NUMERO_REGISTRO_PATRONAL = Me.txtRegistroPatronal.Text
                    Plaza.oSisPlazaNomina.NOMINA_NUMERO_SEMANA_ACTUAL = CInt(Me.txtSemanaActual.Text)
                    Plaza.oSisPlazaNomina.NOMINA_EQUIVALENCIA_JORNAL_HORAS = CInt(Me.txtEquivalenciaJornalHoras.Text)
                    Plaza.oSisPlazaNomina.NOMINA_EDAD_MINIMA_TRABAJADORES = CDbl(Me.txtEdadMinima.Text)
                    Plaza.oSisPlazaNomina.NOMINA_RUTA_FOTOS_TRABAJADORES = Me.txtRutaFotosTrabajadores.Text
                    Plaza.oSisPlazaNomina.NOMINA_RUTA_IDSE = Me.txtRutaIDSE.Text
                    Plaza.oSisPlazaNomina.RUTA_ALTAS_DISPERSIONES = Me.txtRutaDispersion.Text
                    '.NOMINA_RUTA_SUA = Me.txtTipoTrabajador.Text
                    Plaza.oSisPlazaNomina.NOMINA_TIPO_TRABAJADOR = Me.txtTipoTrabajador.Text
                    Plaza.oSisPlazaNomina.NOMINA_TIPO_SALARIO = Me.txtTipoSalario.Text
                    Plaza.oSisPlazaNomina.NOMINA_REDUCCION_TIPO_PAGO = Me.txtTipoPago.Text
                    Plaza.oSisPlazaNomina.NOMINA_GUIA = Me.txtGuia.Text
                    Plaza.oSisPlazaNomina.NOMINA_IDENTIFICADOR_FORMATO = Me.txtFormato.Text
                    Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA = CInt(Me.cboTemporada.SelectedValue)

                    Select Case Me.Estado
                        Case enumEstados.NUEVO
                            If Plaza.oSisPlazaNomina.Insertar() Then
                                bResultado = True
                                Me.Estado = enumEstados.CONSULTA
                            End If
                        Case enumEstados.EDICION
                            If Plaza.oSisPlazaNomina.Actualizar() Then
                                bResultado = True
                                Me.Estado = enumEstados.CONSULTA
                            End If
                    End Select

                    If bResultado Then
                        MsgBox(Me.msgElemento & " Grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
                        Me.Cambia_Estado()
                    End If

                    'End With
                Catch ex As Exception
                    HandleError(Me.Name, "Grabar", ex)
                    Me.Estado = enumEstados.CONSULTA
                    Me.Cambia_Estado()
                Finally
                    'oElemento = Nothing
                End Try
        End Select

        Return bResultado
    End Function

    Private Function Consultar() As Boolean
        'Me.InicializaElemento()
        'Me.on = New Class_CatChoferes
        'Me.oChoferes.CODIGO_CHOFER = Me.TxtCodigoChofer.Text

        'If Me.oChoferes.Consultar = False Then
        '    Me.Estado = enumEstados.NUEVO
        '    Me.Cambia_Estado()
        '    Exit Function
        'Else
        '    With Me.oChoferes
        '        Me.TxtCodigoChofer.Text = .CODIGO_CHOFER
        '        Me.TxtNombreChofer.Text = .NOMBRE_CHOFER
        '        Me.txtLiciencia.Text = .LICENCIA
        '        Me.txtVisa.Text = .VISA
        '        Me.txtRfc.Text = .RFC
        '        Me.txtDomicilio.Text = .DOMICILIO
        '        Me.CboEstatus.SelectedText = .Estatus
        '        Me.txtTelefono.Text = .TELEFONO.ToString
        '    End With

        'End If
        Consultar = True

        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Function

    Private Sub DesplegarTemporadas()
        Dim oElementos As New Class_NominaTemporada
        With Me.cboTemporada
            .DisplayMember = "NOMBRE_TEMPORADA"
            .ValueMember = "ID_NOMINA_TEMPORADA"
            Dim dView As New Data.DataView(oElementos.ObtenerElementos(Usuario.Codigo_Plaza.ToString))
            dView.Sort = "NOMBRE_TEMPORADA"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub
#End Region

#Region "Eventos de objetos"

#Region "Eventos de la lista de elementos"
#End Region

#Region " Eventos de TxtFiltro"
#End Region

#Region "Eventos Genericos"

    Private Sub Frm_Nomina_Configuracion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TxtId.Text = Plaza.oSisPlazaNomina.ID_SIS_EMPRESA_NOMINA.ToString
        Me.TxtSueldoDiario.Text = FormatImporteContable(Plaza.oSisPlazaNomina.NOMINA_SUELDO_DIARIO, True).ToString
        Me.txtRegistroPatronal.Text = Plaza.oSisPlazaNomina.NOMINA_NUMERO_REGISTRO_PATRONAL.ToString
        Me.txtSemanaActual.Text = Plaza.oSisPlazaNomina.NOMINA_NUMERO_SEMANA_ACTUAL.ToString
        Me.txtEquivalenciaJornalHoras.Text = Plaza.oSisPlazaNomina.NOMINA_EQUIVALENCIA_JORNAL_HORAS.ToString
        Me.txtEdadMinima.Text = Plaza.oSisPlazaNomina.NOMINA_EDAD_MINIMA_TRABAJADORES.ToString
        Me.txtRutaFotosTrabajadores.Text = Plaza.oSisPlazaNomina.NOMINA_RUTA_FOTOS_TRABAJADORES.ToString
        Me.txtRutaIDSE.Text = Plaza.oSisPlazaNomina.NOMINA_RUTA_IDSE.ToString
        Me.txtRutaDispersion.Text = Plaza.oSisPlazaNomina.RUTA_ALTAS_DISPERSIONES.ToString
        Me.txtTipoTrabajador.Text = Plaza.oSisPlazaNomina.NOMINA_TIPO_TRABAJADOR.ToString
        Me.txtTipoSalario.Text = Plaza.oSisPlazaNomina.NOMINA_TIPO_SALARIO.ToString
        Me.txtTipoPago.Text = Plaza.oSisPlazaNomina.NOMINA_REDUCCION_TIPO_PAGO.ToString
        Me.txtGuia.Text = Plaza.oSisPlazaNomina.NOMINA_GUIA.ToString
        Me.txtFormato.Text = Plaza.oSisPlazaNomina.NOMINA_IDENTIFICADOR_FORMATO.ToString
        Me.cboTemporada.SelectedValue = Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA
    End Sub

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSueldoDiario.KeyPress, txtRegistroPatronal.KeyPress, txtSemanaActual.KeyPress ', txtLiciencia.KeyPress, txtVisa.KeyPress, txtRfc.KeyPress, txtTelefono.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSueldoDiario.KeyDown, txtRegistroPatronal.KeyDown, txtSemanaActual.KeyDown, txtEquivalenciaJornalHoras.KeyDown, _
        txtEdadMinima.KeyDown, txtRutaFotosTrabajadores.KeyDown, txtRutaIDSE.KeyDown, txtTipoTrabajador.KeyDown, txtTipoSalario.KeyDown, txtTipoPago.KeyDown, txtGuia.KeyDown, txtFormato.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNumericos_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim t As TextBox
        t = CType(sender, TextBox)
        If Not IsNumeric(t.Text) Then
            t.Text = Val(t.Text).ToString
        Else
            'Me.ErrorProvider.Clear()
        End If
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipoTrabajador.KeyPress, txtTipoSalario.KeyPress, txtTipoPago.KeyPress, txtFormato.KeyPress, _
    TxtSueldoDiario.KeyPress, txtSemanaActual.KeyPress, txtEquivalenciaJornalHoras.KeyPress, txtEdadMinima.KeyPress, txtGuia.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub
#End Region

#Region "Keydown específicos"
  
#End Region
#End Region

    Private Sub gBoxInformacion_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gBoxInformacion.Enter

    End Sub

End Class