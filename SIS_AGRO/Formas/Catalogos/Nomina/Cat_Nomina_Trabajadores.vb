Option Strict On

Imports System.Drawing.Imaging
Imports System.Drawing.Printing

Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Cat_Nomina_Trabajadores
    Dim oTrabajadores As New Class_CatTrabajadores
    Private _CODIGO_TRABAJADOR As String = ""

#Region "Campos privados"
    Private Enum enumEstados
        NUEVO
        EDICION
        CONSULTA
    End Enum

    Private Estado As enumEstados
    Private Run As Boolean
    Private msgElemento As String
    Private msgElementos As String
#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Nombre_Reporte As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
#End Region

#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Catalogo() As String
        Get
            Return Me._Nombre_Catalogo
        End Get
    End Property

    Public Property Nombre_Reporte() As String
        Get
            Return Me._Nombre_Reporte
        End Get
        Set(ByVal value As String)
            Me._Nombre_Reporte = value
        End Set
    End Property

    Public WriteOnly Property CODIGO_TRABAJADOR() As String
        Set(ByVal Value As String)
            Me._CODIGO_TRABAJADOR = Value
        End Set
    End Property
#End Region

#Region "Constructor y destructor"
    'Inicializa al objeto.
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Try
            Me.msgElemento = "Trabajador"
            Me.msgElementos = "Trabajadores"
            Me.Run = False
            'Me.lstbElementos.ContextMenuStrip = Me.cMenuStripAccion
            Me.Cambia_Estado(enumEstados.CONSULTA)
            Me.Run = True
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
        Me.Cambia_Estado(enumEstados.NUEVO)

        Me.oTrabajadores.CodigoSiguiente()

        Me.txtCodigoTrabajador.Text = String.Format("{0,5}", Me.oTrabajadores.CODIGO_TRABAJADOR.ToString).Replace(" ", "0")
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.Cambia_Estado(enumEstados.EDICION)
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim sMsg As String = ""
        'If Usuario.PERMISO_CAT_CLIENTES = "0" Then
        '    MsgBox("No tiene permiso para realizar este movimiento.", MsgBoxStyle.Exclamation, Me.Name)
        '    Me.Estado = enumEstados.CONSULTA
        '    Me.Cambia_Estado()
        '    Exit Sub
        'End If

        Select Case Me.Estado
            Case enumEstados.EDICION
                sMsg = "grabar las modificaciones del " & Me.msgElemento & " : " & Me.txtCodigoTrabajador.Text
            Case enumEstados.NUEVO
                sMsg = "agregar el " & Me.msgElemento & " : " & Me.txtCodigoTrabajador.Text
        End Select
        sMsg = "Deseas " & sMsg & " ?"
        'If MsgBox(sMsg, CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle)) = MsgBoxResult.Yes Then
        Me.Grabar_Elemento()
        'End If
    End Sub

    Private Sub tsbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
        Me.Cambia_Estado(enumEstados.CONSULTA)
        'Me.oTrabajadores.CodigoSiguiente()
        Me.txtCodigoTrabajador.Text = String.Format("{0,5}", Me.oTrabajadores.CODIGO_TRABAJADOR.ToString).Replace(" ", "0")
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbImprimirListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirListado.Click
        Dim oElementos As New Class_CatTrabajadores
        'oElementos.Imprimir_Listado()
        oElementos = Nothing
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub Cat_Nomina_Trabajadores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CargaEstados()
        Me.CargaEstadosNacimiento()
        Me.DesplegarElementos()
        Me.DesplegarTemporadas()
        Me.DesplegarSexos()
        Me.DesplegarUnidadMedicaFamiliar()
        Me.DesplegarAreas()
        Me.DesplegarPuestos()
        Me.DesplegarPuntoPago()

        If Me._CODIGO_TRABAJADOR <> "" Then
            Me.tsbEditar.PerformClick()
        End If
    End Sub

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Me.Estado = pEstado

        Select Case Me.Estado
            Case enumEstados.NUEVO
                Me.tssLabelEstado.Text = "Agregando nuevo " & Me.msgElemento
                Me.tsbNuevo.Enabled = True
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True
                Me.btnAnterior.Enabled = False
                Me.btnSiguiente.Enabled = False

                Me.txtCodigoTrabajador.Enabled = False
                Me.cboIdTemporada.Enabled = False
                Me.TxtNombreTrabajador.Enabled = True
                Me.txtApellidoPaterno.Enabled = True
                Me.txtApellidoMaterno.Enabled = True
                Me.cboSexo.Enabled = True
                Me.dtpFechaNacimiento.Enabled = True
                Me.dtpFechaIngreso.Enabled = True
                Me.cboEstadoNacimiento.Enabled = True

                Me.cboArea.Enabled = True
                Me.cboPuesto.Enabled = True
                Me.cboPuntoPago.Enabled = True
                Me.txtCodigoMayordomo.Enabled = True
                Me.txtSueldo.Enabled = True
                Me.txtRfc.Enabled = True
                Me.txtCurp.Enabled = True
                Me.CboEstatus.Enabled = False
                Me.ckbPagoTarjeta.Enabled = True

                Me.txtDomicilioCalle.Enabled = True
                Me.txtDomicilioNumero.Enabled = True
                Me.txtDomicilioCodigoPostal.Enabled = True
                Me.txtDomicilioColonia.Enabled = True
                Me.txtDomicilioCiudad.Enabled = True
                Me.txtDomicilioLocalidad.Enabled = True
                Me.cboDomicilioEstado.Enabled = True

                Me.cboUnidadMedicaFamiliar.Enabled = True
                Me.txtNombrePadre.Enabled = True
                Me.txtNombreMadre.Enabled = True
                Me.txtNumIMSS.Enabled = True
                Me.txtNumTarjeta.Enabled = True
                Me.txtCodigoBanco.Enabled = True
                Me.ckbAfiliableIMSS.Enabled = True
                Me.ckbFijoIMSS.Enabled = True
                Me.ckbSindicato.Enabled = True
                Me.btnAgregaFoto.Enabled = True
                Me.txtNumeroTrabajadorBanco.Enabled = True
                Me.txtNumeroCuentaBanco.Enabled = True

                Me.InicializaElemento()

                Me.TxtNombreTrabajador.Focus()

            Case enumEstados.EDICION
                Me.tssLabelEstado.Text = "Edición"
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbGrabar.Enabled = True
                Me.tsbCancelar.Enabled = True
                Me.btnAnterior.Enabled = False
                Me.btnSiguiente.Enabled = False

                Me.txtCodigoTrabajador.Enabled = False
                Me.cboIdTemporada.Enabled = False
                Me.TxtNombreTrabajador.Enabled = True
                Me.txtApellidoPaterno.Enabled = True
                Me.txtApellidoMaterno.Enabled = True
                Me.cboSexo.Enabled = True
                Me.dtpFechaNacimiento.Enabled = True
                Me.dtpFechaIngreso.Enabled = True
                Me.cboEstadoNacimiento.Enabled = True

                Me.cboArea.Enabled = True
                Me.cboPuesto.Enabled = True
                Me.cboPuntoPago.Enabled = True
                Me.txtCodigoMayordomo.Enabled = True
                Me.txtSueldo.Enabled = True
                Me.txtRfc.Enabled = True
                Me.txtCurp.Enabled = True
                Me.CboEstatus.Enabled = True
                Me.ckbPagoTarjeta.Enabled = True
                If Me.ckbPagoTarjeta.Checked = True Then
                    Me.txtNumTarjeta.Enabled = True
                    Me.txtCodigoBanco.Enabled = True
                End If
                Me.LblBanco.Enabled = True

                Me.txtDomicilioCalle.Enabled = True
                Me.txtDomicilioNumero.Enabled = True
                Me.txtDomicilioCodigoPostal.Enabled = True
                Me.txtDomicilioColonia.Enabled = True
                Me.txtDomicilioCiudad.Enabled = True
                Me.txtDomicilioLocalidad.Enabled = True
                Me.cboDomicilioEstado.Enabled = True

                Me.cboUnidadMedicaFamiliar.Enabled = True
                Me.txtNombrePadre.Enabled = True
                Me.txtNombreMadre.Enabled = True
                Me.txtNumIMSS.Enabled = True
                Me.txtNumTarjeta.Enabled = True
                Me.txtCodigoBanco.Enabled = True
                Me.ckbAfiliableIMSS.Enabled = True
                Me.ckbFijoIMSS.Enabled = True
                Me.ckbSindicato.Enabled = True
                Me.btnAgregaFoto.Enabled = True
                Me.txtNumeroTrabajadorBanco.Enabled = True
                Me.txtNumeroCuentaBanco.Enabled = True

                Me.TxtNombreTrabajador.Focus()

            Case enumEstados.CONSULTA
                Me.tsbNuevo.Enabled = True
                Me.tsbEditar.Enabled = True
                Me.tsbGrabar.Enabled = False
                Me.tsbCancelar.Enabled = True
                Me.btnAnterior.Enabled = True
                Me.btnSiguiente.Enabled = True

                Me.txtCodigoTrabajador.Enabled = True
                Me.cboIdTemporada.Enabled = False
                Me.TxtNombreTrabajador.Enabled = False
                Me.txtApellidoPaterno.Enabled = False
                Me.txtApellidoMaterno.Enabled = False
                Me.cboSexo.Enabled = False
                Me.dtpFechaNacimiento.Enabled = False
                Me.dtpFechaIngreso.Enabled = False
                Me.cboEstadoNacimiento.Enabled = False

                Me.cboArea.Enabled = False
                Me.cboPuesto.Enabled = False
                Me.cboPuntoPago.Enabled = False
                Me.txtCodigoMayordomo.Enabled = False
                Me.txtSueldo.Enabled = False
                Me.txtRfc.Enabled = False
                Me.txtCurp.Enabled = False
                Me.CboEstatus.Enabled = False
                Me.ckbPagoTarjeta.Enabled = False
                Me.txtNumTarjeta.Enabled = False
                Me.txtCodigoBanco.Enabled = False
                Me.LblBanco.Enabled = False

                Me.txtDomicilioCalle.Enabled = False
                Me.txtDomicilioNumero.Enabled = False
                Me.txtDomicilioCodigoPostal.Enabled = False
                Me.txtDomicilioColonia.Enabled = False
                Me.txtDomicilioCiudad.Enabled = False
                Me.txtDomicilioLocalidad.Enabled = False
                Me.cboDomicilioEstado.Enabled = False

                Me.cboUnidadMedicaFamiliar.Enabled = False
                Me.txtNombrePadre.Enabled = False
                Me.txtNombreMadre.Enabled = False
                Me.txtNumIMSS.Enabled = False
                Me.txtNumTarjeta.Enabled = False
                Me.txtCodigoBanco.Enabled = False
                Me.ckbAfiliableIMSS.Enabled = False
                Me.ckbFijoIMSS.Enabled = False
                Me.ckbSindicato.Enabled = False
                Me.btnAgregaFoto.Enabled = False
                Me.txtNumeroTrabajadorBanco.Enabled = False
                Me.txtNumeroCuentaBanco.Enabled = False

                Me.tssLabelEstado.Text = "Consultando"

        End Select
        'Application.DoEvents()
    End Sub

    Private Sub InicializaElemento()
        Try
            Me.txtCodigoTrabajador.Text = ""
            Me.TxtNombreTrabajador.Text = ""
            Me.txtApellidoPaterno.Text = ""
            Me.txtApellidoMaterno.Text = ""
            Me.dtpFechaNacimiento.Value = Now
            Me.dtpFechaIngreso.Value = Now

            Me.txtCodigoMayordomo.Text = ""
            Me.txtSueldo.Text = ""
            Me.txtRfc.Text = ""
            Me.txtCurp.Text = ""
            Me.CboEstatus.SelectedIndex = 0

            Me.ckbPagoTarjeta.Checked = False
            Me.txtNumTarjeta.Text = ""
            Me.txtCodigoBanco.Text = ""
            Me.LblBanco.Text = ""

            Me.txtDomicilioCalle.Text = ""
            Me.txtDomicilioNumero.Text = ""
            Me.txtDomicilioCodigoPostal.Text = ""
            Me.txtDomicilioColonia.Text = ""
            Me.txtDomicilioCiudad.Text = ""
            Me.txtDomicilioLocalidad.Text = ""

            Me.txtNombrePadre.Text = ""
            Me.txtNombreMadre.Text = ""
            Me.txtNumIMSS.Text = ""
            Me.ckbAfiliableIMSS.Checked = False
            Me.ckbFijoIMSS.Checked = False
            Me.ckbSindicato.Checked = False

            Me.pbFotoTrabajador.Image = Nothing
            Me.cboEstadoNacimiento.SelectedValue = "SL"
            Me.cboDomicilioEstado.SelectedValue = "SL"
            Me.cboUnidadMedicaFamiliar.SelectedValue = -1
            Me.cboIdTemporada.SelectedValue = Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA

            Me.txtNumeroTrabajadorBanco.Text = ""
            Me.txtNumeroCuentaBanco.Text = ""

        Catch ex As Exception
            HandleError(Me.Name, "InicializaElemento", ex)
        End Try
    End Sub

    Private Function Validar() As Boolean
        Try
            If txtLEN(Me.TxtNombreTrabajador.Text) = False Then
                MsgBox("Asígne el nombre del trabajador.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtNombreTrabajador.Focus()
                Exit Function
            End If

            If txtLEN(Me.txtApellidoPaterno.Text) = False Then
                MsgBox("Asígne el apellido paterno al trabajador.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtApellidoPaterno.Focus()
                Exit Function
            End If

            Me.TxtNombreTrabajador.Text = Me.TxtNombreTrabajador.Text.TrimEnd()
            Me.txtApellidoPaterno.Text = Me.txtApellidoPaterno.Text.TrimEnd()
            Me.txtApellidoMaterno.Text = Me.txtApellidoMaterno.Text.TrimEnd()

            Me.TxtNombreTrabajador.Text = Me.TxtNombreTrabajador.Text.Trim()
            Me.txtApellidoPaterno.Text = Me.txtApellidoPaterno.Text.Trim()
            Me.txtApellidoMaterno.Text = Me.txtApellidoMaterno.Text.Trim()

            Me.TxtNombreTrabajador.Text = Me.TxtNombreTrabajador.Text.Replace("   ", " ")
            Me.txtApellidoPaterno.Text = Me.txtApellidoPaterno.Text.Replace("   ", " ")
            Me.txtApellidoMaterno.Text = Me.txtApellidoMaterno.Text.Replace("   ", " ")

            Me.TxtNombreTrabajador.Text = Me.TxtNombreTrabajador.Text.Replace("  ", " ")
            Me.txtApellidoPaterno.Text = Me.txtApellidoPaterno.Text.Replace("  ", " ")
            Me.txtApellidoMaterno.Text = Me.txtApellidoMaterno.Text.Replace("  ", " ")

            Dim sql1 As New Class_find("SELECT DATEDIFF(DAY,CAST('" & Format(Me.dtpFechaNacimiento.Value, "yyyy-dd-MM") & "' AS DATETIME),CAST('" & Format(Now, "yyyy-dd-MM") & "' AS DATETIME))/365.00 ")
            If valorNumerico(sql1.Result1) < Plaza.oSisPlazaNomina.NOMINA_EDAD_MINIMA_TRABAJADORES Then
                MsgBox("La edad trabajador debe ser mayor a 16 años.", MsgBoxStyle.Exclamation, Me.Text)
                Me.dtpFechaNacimiento.Focus()
                Exit Function
            End If

            If txtLEN(Me.txtSueldo.Text) = False Then
                Me.txtSueldo.Text = "0"
            Else
                If valorNumerico(Me.txtSueldo.Text) < 0 Then
                    MsgBox("El sueldo del trabajador de no debe ser menor a 0.", MsgBoxStyle.Exclamation, Me.Text)
                    Me.txtSueldo.Focus()
                    Exit Function
                End If
            End If

            If Me.cboArea.SelectedIndex = -1 Then
                MsgBox("Seleccione el area del trabajador.", MsgBoxStyle.Exclamation, Me.Text)
                Me.cboArea.Focus()
                Return False
            End If

            If Me.cboPuesto.SelectedIndex = -1 Then
                MsgBox("Seleccione el puesto del trabajador.", MsgBoxStyle.Exclamation, Me.Text)
                Me.cboPuesto.Focus()
                Return False
            End If

            If Me.cboPuntoPago.SelectedIndex = -1 Then
                MsgBox("Seleccione el punto de pago del trabajador.", MsgBoxStyle.Exclamation, Me.Text)
                Me.cboPuntoPago.Focus()
                Return False
            End If

            'Aunque no este checado el pago de tarjeta si le escribieron que la completen a 16
            If txtLEN(Me.txtNumTarjeta.Text) = True Then
                If Len(Me.txtNumTarjeta.Text) < 16 Then
                    MsgBox("Asígne los 16 dígitos de la tarjeta.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                End If

                If ValidaTarjetaBancaria(Me.txtNumTarjeta.Text) = False Then
                    If MsgBox("El número de tarjeta parece estar incorrecto, desea grabarlo así de todas formas?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                        Exit Function
                    End If
                End If
            End If

            If Me.ckbPagoTarjeta.Checked = True Then
                'Va poder quedar en blanco
                'If txtLEN(Me.txtNumTarjeta.Text) = False Then
                '    MsgBox("Asígne el número de tarjeta del trabajador.", MsgBoxStyle.Exclamation, Me.Text)
                '    Exit Function
                'End If

                If txtLEN(Me.txtNumeroCuentaBanco.Text) = False Then
                    MsgBox("Asígne el número de cuenta.", MsgBoxStyle.Exclamation, Me.Text)
                    Me.txtNumeroCuentaBanco.Focus()
                    Exit Function
                End If

                If txtLEN(Me.txtNumeroTrabajadorBanco.Text) = False Then
                    MsgBox("Asígne el número de trabajador en el banco.", MsgBoxStyle.Exclamation, Me.Text)
                    Me.txtNumeroTrabajadorBanco.Focus()
                    Exit Function
                End If

                If txtLEN(Me.txtCodigoBanco.Text) = False Then
                    MsgBox("Asígne el código del banco de la tarjeta del trabajador.", MsgBoxStyle.Exclamation, Me.Text)
                    Me.txtCodigoBanco.Focus()
                    Exit Function
                Else
                    Dim sql As New Class_find("SELECT 1 FROM CAT_BANCOS WHERE CODIGO_BANCO='" & Me.txtCodigoBanco.Text & "' AND ESTATUS_BANCO='A' AND PROTEGIDO='0'")
                    If sql.Result1 = "" Then
                        MsgBox("El código de banco que intenta buscar no existe o esta dado de baja, favor de intentar con otro código.", MsgBoxStyle.Critical, "Validación de Bancos")
                        Me.LblBanco.Text = ""
                        Me.txtCodigoBanco.Focus()
                        Exit Function
                    End If
                End If
            End If

            'If txtLEN(Me.txtDomicilioCalle.Text) = False Then
            '    MsgBox("Asígne el nombre de la calle del domicilio del trabajador.", MsgBoxStyle.Exclamation, Me.Text)
            '    Exit Function
            'End If

            'If txtLEN(Me.txtDomicilioNumero.Text) = False Then
            '    MsgBox("Asígne el nombre de la calle del domicilio del trabajador.", MsgBoxStyle.Exclamation, Me.Text)
            '    Exit Function
            'End If

            'If txtLEN(Me.txtDomicilioNumero.Text) = False Then
            '    MsgBox("Asígne el número del domicilio del trabajador.", MsgBoxStyle.Exclamation, Me.Text)
            '    Exit Function
            'End If

            'If txtLEN(Me.txtDomicilioCodigoPostal.Text) = False Then
            '    MsgBox("Asígne el código postal del domicilio del trabajador.", MsgBoxStyle.Exclamation, Me.Text)
            '    Exit Function
            'End If

            'If txtLEN(Me.txtDomicilioColonia.Text) = False Then
            '    MsgBox("Asígne el nombre de la colonia del domicilio del trabajador.", MsgBoxStyle.Exclamation, Me.Text)
            '    Exit Function
            'End If

            'If txtLEN(Me.txtDomicilioCiudad.Text) = False Then
            '    MsgBox("Asígne el nombre de la cuidad del domicilio del trabajador.", MsgBoxStyle.Exclamation, Me.Text)
            '    Exit Function
            'End If

            'If txtLEN(Me.txtDomicilioLocalidad.Text) = False Then
            '    MsgBox("Asígne el nombre de la localidad del domicilio del trabajador.", MsgBoxStyle.Exclamation, Me.Text)
            '    Exit Function
            'End If

            If txtLEN(Me.cboDomicilioEstado.SelectedValue.ToString) = False Then
                MsgBox("Seleccione un estado del domicilio del trabajador.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            If txtLEN(Me.txtNombrePadre.Text) = True Then
                If Me.Validar_Caracteres(Me.txtNombrePadre.Text) = False Then
                    MsgBox("El nombre del padre del trabajador esta incorrecto.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                End If
            End If

            If txtLEN(Me.txtNombreMadre.Text) = True Then
                If Me.Validar_Caracteres(Me.txtNombreMadre.Text) = False Then
                    MsgBox("El nombre de la madre del trabajador esta incorrecto.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                End If
            End If

            If txtLEN(Me.txtNumIMSS.Text) = True Then
                If Len(Me.txtNumIMSS.Text) <> 11 Then
                    MsgBox("El número de IMSS del trabajador es incorrecto, favor de verificar.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                End If

                Dim sql2 As New Class_find("SELECT 1 FROM NOMINA_CAT_TRABAJADORES WHERE NUMERO_REGISTRO_IMSS='" & Me.txtNumIMSS.Text & "' AND CODIGO_TRABAJADOR<>'" & Me.txtCodigoTrabajador.Text & "' AND ID_NOMINA_TEMPORADA=" & Me.cboIdTemporada.SelectedValue.ToString)
                If sql2.Result1 = "1" Then
                    MsgBox("El número de registro de IMSS ya existe.", MsgBoxStyle.Exclamation, Me.Text)
                    Me.txtNumIMSS.Focus()
                    Exit Function
                End If

                Dim sNumIMSS As String

                sNumIMSS = Strings.Right(Me.txtNumIMSS.Text, 1)
                'sNumIMSS = Strings.Left(Me.txtNumIMSS.Text, 10)

                If sNumIMSS <> Me.DVIMSS(Me.txtNumIMSS.Text) Then
                    MsgBox("El número de registro de IMSS esta incorrecto, favor de verificarlo.", MsgBoxStyle.Exclamation, Me.Text)
                    Me.txtNumIMSS.Focus()
                    Exit Function
                End If
                'Me.txtNumIMSS.Text = sNumIMSS.Substring(Len(sNumIMSS) - 10) & Me.DVIMSS(sNumIMSS)

                Dim sNumIMSSyy As String = Me.txtNumIMSS.Text.Substring(4, Me.txtNumIMSS.Text.Length - 5 - 4)

                If sNumIMSSyy <> Format(Me.dtpFechaNacimiento.Value, "yy") Then
                    MsgBox("El número de registro de IMSS esta incorrecto, favor de verificarlo.", MsgBoxStyle.Exclamation, Me.Text)
                    Me.txtNumIMSS.Focus()
                    Exit Function
                End If

            End If

            Dim SQL3 As New Class_find("SELECT 1 FROM NOMINA_CAT_TRABAJADORES WHERE NOMBRE_TRABAJADOR='" & Me.TxtNombreTrabajador.Text & "' AND APELLIDO_PATERNO='" & Me.txtApellidoPaterno.Text & "' AND APELLIDO_MATERNO='" & Me.txtApellidoMaterno.Text & "' AND FECHA_NACIMIENTO='" & Format(Me.dtpFechaNacimiento.Value, "yyyy-dd-MM").ToString & "' AND CODIGO_TRABAJADOR<>'" & Me.txtCodigoTrabajador.Text & "' ")
            If SQL3.Result1 = "1" Then
                MsgBox("Ya existe un trabajador con el mismo nombre,apellidos y fecha de nacimiento, no es posible repetirlo.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            Dim sql4 As New Class_find("SELECT 1 FROM NOMINA_CAT_TRABAJADORES WHERE NOMBRE_TRABAJADOR='" & Me.TxtNombreTrabajador.Text & "' AND APELLIDO_PATERNO='" & Me.txtApellidoPaterno.Text & "' AND APELLIDO_MATERNO='" & Me.txtApellidoMaterno.Text & "' AND CODIGO_TRABAJADOR<>'" & Me.txtCodigoTrabajador.Text & "' ")
            If sql4.Result1 = "1" Then
                If MsgBox("Ya existe un trabajador con el mismo nombre, apellidos pero con fecha de nacimiento diferente, esta seguro de grabarlo?", CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle)) = MsgBoxResult.No Then
                    Exit Function
                End If
            End If

            'Me.cboUnidadMedicaFamiliar.SelectedValue.ToString()
            Me.txtRfc.Text = Me.RFC(Me.txtApellidoPaterno.Text, Me.txtApellidoMaterno.Text, Me.TxtNombreTrabajador.Text, dtpFechaNacimiento.Value)
            Me.txtCurp.Text = Me.CURP(Me.txtApellidoPaterno.Text, Me.txtApellidoMaterno.Text, Me.TxtNombreTrabajador.Text, dtpFechaNacimiento.Value)

            If txtLEN(Me.txtRfc.Text) = False Then
                MsgBox("Asígne el RFC al trabajador.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtRfc.Focus()
                Exit Function
            End If

            If txtLEN(Me.txtCurp.Text) = False Then
                MsgBox("Asígne el CURP al trabajador.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtCurp.Focus()
                Exit Function
            ElseIf Len(Me.txtCurp.Text) <> 18 Then
                MsgBox("El CURP del trabajador es incorrecto, favor de verificar.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtCurp.Focus()
                Exit Function
            End If

            Return True

        Catch ex As Exception
            HandleError(Me.Name, "Validar", ex)
        End Try
    End Function

    Private Function DVIMSS(ByVal CADENA As String) As String
        '     22 91 75 0448 6
        Dim S As Integer, DV As Integer, DX As Integer, D0 As Integer, D1(10) As Integer ',
        DVIMSS = ""
        If Len(CADENA) = 11 Then
            For S = 1 To 10
                D1(S) = CInt(Mid(CADENA, S, 1))
            Next S

            For S = 2 To 10 Step 2
                D1(S) = D1(S) * 2
                If Val(D1(S)) > 9 Then
                    DX = D1(S)
                    D1(S) = CInt(Val(Mid(CStr(DX), 1, 1)) + Val(Mid(CStr(DX), 2, 1)))
                End If
            Next S
            DV = D1(1) + D1(2) + D1(3) + D1(4) + D1(5) + D1(6) + D1(7) + D1(8) + D1(9) + D1(10)
            DX = DV
            D0 = CInt(Val(Mid(CStr(DX), 1, 1)))
            D0 = (D0 * 10) + 10
            DVIMSS = (D0 - DV).ToString
            If Val(DVIMSS) = 10 Then
                DVIMSS = "0"
            End If
        End If
    End Function

    Private Function Validar_Caracteres(ByVal CADENA As String) As Boolean
        Dim letra As String, I As Integer

        For I = 1 To Len(CADENA)
            letra = Mid(CADENA, I, 1)
            If InStr("ABCDEFGHIJKLMNÑOPQRSTUVWXYZ ", letra) >= 1 Then
                Validar_Caracteres = True
            Else
                Validar_Caracteres = False
                Exit Function
            End If
        Next
    End Function

    Private Sub Grabar_Elemento()
        Dim oElemento As New Class_CatTrabajadores
        Dim Grabado As Boolean = False
        Dim sFoto As String = ""

        If Me.Validar() = False Then
            Exit Sub
        End If

        Select Case Me.Estado
            Case enumEstados.NUEVO, enumEstados.EDICION
                oElemento = New Class_CatTrabajadores
                Try
                    With oElemento
                        .CODIGO_TRABAJADOR = Me.txtCodigoTrabajador.Text
                        .NOMBRE_TRABAJADOR = Me.TxtNombreTrabajador.Text
                        .ID_NOMINA_TEMPORADA = CInt(Me.cboIdTemporada.SelectedValue)
                        .APELLIDO_PATERNO = Me.txtApellidoPaterno.Text
                        .APELLIDO_MATERNO = Me.txtApellidoMaterno.Text
                        .CODIGO_SEXO = Me.cboSexo.SelectedValue.ToString
                        .FECHA_NACIMIENTO = Me.dtpFechaNacimiento.Value
                        .CODIGO_ESTADO_NACIMIENTO = Me.cboEstadoNacimiento.SelectedValue.ToString

                        .CODIGO_AREA = CInt(Me.cboArea.SelectedValue)
                        .CODIGO_PUESTO = CInt(Me.cboPuesto.SelectedValue)
                        .CODIGO_PUNTO_PAGO = CInt(Me.cboPuntoPago.SelectedValue)
                        .RFC = Me.txtRfc.Text
                        .CURP = Me.txtCurp.Text
                        .CODIGO_MAYORDOMO = Me.txtCodigoMayordomo.Text
                        .SUELDO_DIARIO = CDbl(Me.txtSueldo.Text)
                        .ESTATUS_TRABAJADOR = Strings.Left(Me.CboEstatus.Text, 1)
                        .RECIBE_PAGO_TARJETA_BANCARIA = Convert.ToInt32(Me.ckbPagoTarjeta.Checked).ToString
                        .NUMERO_TARJETA_BANCARIA = Me.txtNumTarjeta.Text
                        .CODIGO_BANCO_PAGO_TARJETA = Me.txtCodigoBanco.Text

                        .DOMICILIO_CALLE = Me.txtDomicilioCalle.Text
                        .DOMICILIO_NUMERO = Me.txtDomicilioNumero.Text
                        .DOMICILIO_CODIGO_POSTAL = Me.txtDomicilioCodigoPostal.Text
                        .DOMICILIO_COLONIA = Me.txtDomicilioColonia.Text
                        .DOMICILIO_CIUDAD = Me.txtDomicilioCiudad.Text
                        .DOMICILIO_LOCALIDAD = Me.txtDomicilioLocalidad.Text
                        .DOMICILIO_CODIGO_ESTADO = Me.cboDomicilioEstado.SelectedValue.ToString

                        If txtLEN(Me.cboUnidadMedicaFamiliar.Text) = True Then
                            .CODIGO_UNIDAD_MEDICA_FAMILIAR = "" & Me.cboUnidadMedicaFamiliar.SelectedValue.ToString
                        End If
                        .NOMBRE_PADRE = Me.txtNombrePadre.Text
                        .NOMBRE_MADRE = Me.txtNombreMadre.Text
                        .NUMERO_REGISTRO_IMSS = Me.txtNumIMSS.Text
                        .AFILIABLE_IMSS = Convert.ToInt32(Me.ckbAfiliableIMSS.Checked).ToString
                        .FIJO_IMSS = Convert.ToInt32(Me.ckbFijoIMSS.Checked).ToString
                        .CALCULA_SINDICATO = Convert.ToInt32(Me.ckbSindicato.Checked).ToString
                        .FECHA_INGRESO = Me.dtpFechaIngreso.Value
                        .NUMERO_TRABAJADOR_BANCO = Me.txtNumeroTrabajadorBanco.Text.ToUpper
                        .NUMERO_CUENTA_BANCO = Me.txtNumeroCuentaBanco.Text.ToUpper

                        Select Case Me.Estado
                            Case enumEstados.NUEVO
                                If .Insertar() = False Then
                                    Exit Sub
                                End If
                            Case enumEstados.EDICION
                                If .Actualizar() = False Then
                                    Exit Sub
                                End If
                        End Select

                        'para que solamente lo haga si hay imagen en la caja de imagen 
                        If Not Me.pbFotoTrabajador.Image Is Nothing Then
                            sFoto = Plaza.oSisPlazaNomina.NOMINA_RUTA_FOTOS_TRABAJADORES.ToString & "\" & Me.txtCodigoTrabajador.Text & ".jpg"
                            If File.Exists(sFoto) = False Then
                                'File.Exists(Nothing)
                                'File.Delete(sFoto)

                                Me.pbFotoTrabajador.Image.Save(sFoto, Imaging.ImageFormat.Jpeg)
                            End If
                        End If

                        MsgBox(Me.msgElemento & " grabado satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
                        Me.Cambia_Estado(enumEstados.CONSULTA)
                        Me.DesplegarElementos()

                    End With
                Catch ex As Exception
                    HandleError(Me.Name, "Grabar_Elemento", ex)
                Finally
                    oElemento = Nothing
                End Try
        End Select
    End Sub

    Private Function LlenaComboEstatus() As Boolean
        Me.CboEstatus.Items.Add("A")
        Me.CboEstatus.Items.Add("B")
        Me.CboEstatus.SelectedItem = "A"
    End Function

    Private Sub CargaEstados()
        Dim oElementos As New Class_CatTrabajadores
        With Me.cboDomicilioEstado
            .DisplayMember = "NOMBRE_ESTADO"
            .ValueMember = "CODIGO_ESTADO"

            Dim dView As New Data.DataView(oElementos.ObtenerEstados)
            dView.Sort = "NOMBRE_ESTADO"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedValue = "SIN"
            End If
        End With
    End Sub

    Private Sub CargaEstadosNacimiento()
        Dim oElementos As New Class_CatTrabajadores
        With Me.cboEstadoNacimiento
            .DisplayMember = "NOMBRE_ESTADO"
            .ValueMember = "CODIGO_ESTADO"

            Dim dView As New Data.DataView(oElementos.ObtenerEstados)
            dView.Sort = "NOMBRE_ESTADO"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedValue = "SIN"
            End If
        End With
    End Sub

    Private Function Consultar() As Boolean
        Dim sFolio As String = Me.txtCodigoTrabajador.Text
        Me.InicializaElemento()
        Me.oTrabajadores = New Class_CatTrabajadores()
        Me.oTrabajadores.CODIGO_TRABAJADOR = sFolio

        If Me.oTrabajadores.Consultar = False Then
            Me.oTrabajadores.CodigoSiguiente()
            Me.Cambia_Estado(enumEstados.NUEVO)
            Me.txtCodigoTrabajador.Text = Me.oTrabajadores.CODIGO_TRABAJADOR.ToString
            Exit Function
        Else
            With Me.oTrabajadores
                Me.txtCodigoTrabajador.Text = .CODIGO_TRABAJADOR
                Me.TxtNombreTrabajador.Text = .NOMBRE_TRABAJADOR
                Me.cboIdTemporada.SelectedValue = .ID_NOMINA_TEMPORADA
                Me.txtApellidoPaterno.Text = .APELLIDO_PATERNO
                Me.txtApellidoMaterno.Text = .APELLIDO_MATERNO
                Me.cboSexo.SelectedValue = .CODIGO_SEXO
                Me.dtpFechaNacimiento.Value = .FECHA_NACIMIENTO
                Me.cboEstadoNacimiento.SelectedValue = .CODIGO_ESTADO_NACIMIENTO

                Me.cboArea.SelectedValue = .CODIGO_AREA
                Me.cboPuesto.SelectedValue = .CODIGO_PUESTO
                Me.cboPuntoPago.SelectedValue = .CODIGO_PUNTO_PAGO
                Me.txtCodigoMayordomo.Text = .CODIGO_MAYORDOMO
                Me.lblNombreMayordomo.Text = .NOMBRE_MAYORDOMO
                Me.txtSueldo.Text = FormatImporteContable(valorNumerico(.SUELDO_DIARIO.ToString), True)
                Me.txtRfc.Text = .RFC
                Me.txtCurp.Text = .CURP
                If .ESTATUS_TRABAJADOR = "A" Then
                    Me.CboEstatus.SelectedIndex = 0
                Else
                    Me.CboEstatus.SelectedIndex = 1
                End If
                Me.ckbPagoTarjeta.Checked = CBool(.RECIBE_PAGO_TARJETA_BANCARIA)
                Me.txtNumTarjeta.Text = .NUMERO_TARJETA_BANCARIA
                Me.txtCodigoBanco.Text = .CODIGO_BANCO_PAGO_TARJETA
                Me.LblBanco.Text = .NOMBRE_BANCO
                Me.txtCuentaContable.Text = .CUENTA_CONTABLE

                Me.txtDomicilioCalle.Text = .DOMICILIO_CALLE
                Me.txtDomicilioNumero.Text = .DOMICILIO_NUMERO
                Me.txtDomicilioCodigoPostal.Text = .DOMICILIO_CODIGO_POSTAL
                Me.txtDomicilioColonia.Text = .DOMICILIO_COLONIA
                Me.txtDomicilioCiudad.Text = .DOMICILIO_CIUDAD
                Me.txtDomicilioLocalidad.Text = .DOMICILIO_LOCALIDAD
                Me.cboDomicilioEstado.SelectedValue = .DOMICILIO_CODIGO_ESTADO

                Me.cboUnidadMedicaFamiliar.SelectedValue = .CODIGO_UNIDAD_MEDICA_FAMILIAR
                Me.txtNombrePadre.Text = .NOMBRE_PADRE
                Me.txtNombreMadre.Text = .NOMBRE_MADRE
                Me.txtNumIMSS.Text = .NUMERO_REGISTRO_IMSS
                Me.ckbAfiliableIMSS.Checked = CBool(.AFILIABLE_IMSS)
                Me.ckbFijoIMSS.Checked = CBool(.FIJO_IMSS)
                Me.ckbSindicato.Checked = CBool(.CALCULA_SINDICATO)
                Me.dtpFechaIngreso.Value = .FECHA_INGRESO

                Me.txtNumeroTrabajadorBanco.Text = .NUMERO_TRABAJADOR_BANCO
                Me.txtNumeroCuentaBanco.Text = .NUMERO_CUENTA_BANCO
            End With

            'Dim sFoto As String = Plaza.oSisPlazaNomina.NOMINA_RUTA_FOTOS_TRABAJADORES.ToString & "\" & Me.txtCodigoTrabajador.Text & ".jpg"
            'If File.Exists(sFoto) Then 'C:\agrinet\Nomina\Fotos_Trabajadores
            '    Me.pbFotoTrabajador.Image = System.Drawing.Image.FromFile(sFoto)
            'Else
            '    Me.pbFotoTrabajador.Image = Nothing
            'End If

        End If
        Consultar = True

    End Function

    Private Sub DesplegarElementos()
        With Me.Grid
            .DataSource = oTrabajadores.ObtenerElementos
            .Columns("CODIGO_TRABAJADOR").Width = 40
            .Columns("NOMBRE_COMPLETO_APELLIDO").Width = 300
        End With
    End Sub

    Private Sub DesplegarTemporadas()
        With Me.cboIdTemporada
            .DisplayMember = "NOMBRE_TEMPORADA"
            .ValueMember = "ID_NOMINA_TEMPORADA"
            Dim dView As New Data.DataView(Me.oTrabajadores.ObtenerTemporadas)
            dView.Sort = "NOMBRE_TEMPORADA"
            .DataSource = dView
            If dView.Count > 0 Then
                '.SelectedIndex = 0
                .SelectedValue = Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA
            End If
        End With
    End Sub

    Private Sub DesplegarSexos()
        With Me.cboSexo
            .DisplayMember = "NOMBRE_SEXO"
            .ValueMember = "CODIGO_SEXO"
            Dim dView As New Data.DataView(Me.oTrabajadores.ObtenerSexos)
            dView.Sort = "NOMBRE_SEXO"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub DesplegarAreas()
        Dim oAreas As New Class_CatAreas
        Try
            With Me.cboArea
                .DisplayMember = "NOMBRE_AREA"
                .ValueMember = "CODIGO_AREA"
                Dim dView As New Data.DataView(oAreas.ObtenerElementos)
                dView.Sort = "NOMBRE_AREA"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAreas", ex)
        End Try
    End Sub

    Private Sub DesplegarPuestos()
        Dim oPuestos As New Class_CatPuestos
        Try
            With Me.cboPuesto
                .DisplayMember = "NOMBRE_PUESTO"
                .ValueMember = "CODIGO_PUESTO"
                Dim dView As New Data.DataView(oPuestos.ObtenerElementos)
                dView.Sort = "NOMBRE_PUESTO"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarPuestos", ex)
        End Try
    End Sub

    Private Sub DesplegarPuntoPago()
        Dim oPuntoPago As New Class_CatPuntoPago
        Try
            With Me.cboPuntoPago
                .DisplayMember = "NOMBRE_PUNTO_PAGO"
                .ValueMember = "CODIGO_PUNTO_PAGO"
                Dim dView As New Data.DataView(oPuntoPago.ObtenerElementos)
                dView.Sort = "NOMBRE_PUNTO_PAGO"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarPuntoPago", ex)
        End Try
    End Sub

    Private Sub DesplegarUnidadMedicaFamiliar()
        Dim oUMF As New Class_CatUnidadMedicaFamiliar
        Try
            With Me.cboUnidadMedicaFamiliar
                .DisplayMember = "NOMBRE_UNIDAD_MEDICA_FAMILIAR"
                .ValueMember = "CODIGO_UNIDAD_MEDICA_FAMILIAR"
                Dim dView As New Data.DataView(oUMF.ObtenerElementos)
                dView.Sort = "NOMBRE_UNIDAD_MEDICA_FAMILIAR"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = -1
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarUnidadMedicaFamiliar", ex)
        End Try
    End Sub

    Private Function NavegadorTrabajadores(ByVal sTipoDeBusqueda As String) As Boolean
        Try
            Dim iFolio As Integer, sFolio As String

            If txtLEN(Me.txtCodigoTrabajador.Text) = False Then
                Me.oTrabajadores.CodigoSiguiente()
                Me.txtCodigoTrabajador.Text = Me.oTrabajadores.CODIGO_TRABAJADOR.ToString
            End If

            sFolio = Me.txtCodigoTrabajador.Text

            If sTipoDeBusqueda = "Anterior" Then
                'iFolio = CInt(Strings.Right(Me.txtCodigoTrabajador.Text, 5))
                'iFolio = iFolio - 1
                'sFolio = "00000" + iFolio.ToString
                'Me.txtCodigoTrabajador.Text = sFolio.Substring(Len(sFolio) - 5)
                Dim oSQl As New Class_find("select  max(CODIGO_TRABAJADOR) from VW_NOMINA_CAT_TRABAJADORES_EXTENDIDA where CODIGO_TRABAJADOR<'" & sFolio & "' AND CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString)
                Me.txtCodigoTrabajador.Text = oSQl.Result1.ToString

                'Me.txtCodigoTrabajador.Text = Me.txtCodigoTrabajador.Text
                If txtLEN(Me.txtCodigoTrabajador.Text) = False Then
                    Me.tsbNuevo.PerformClick()
                Else
                    Me.Consultar()
                End If

            ElseIf sTipoDeBusqueda = "Siguiente" Then
                'iFolio = CInt(Strings.Right(Me.txtCodigoTrabajador.Text, 5))
                'iFolio = iFolio + 1
                'sFolio = "00000" + iFolio.ToString
                'Me.txtCodigoTrabajador.Text = sFolio.Substring(Len(sFolio) - 5)
                Dim oSQl As New Class_find("select  min(CODIGO_TRABAJADOR) from VW_NOMINA_CAT_TRABAJADORES_EXTENDIDA where CODIGO_TRABAJADOR>'" & sFolio & "%' AND CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString)
                Me.txtCodigoTrabajador.Text = oSQl.Result1.ToString

                If txtLEN(Me.txtCodigoTrabajador.Text) = False Then
                    Me.oTrabajadores.CodigoSiguiente()
                    If CInt(Strings.Right(Me.oTrabajadores.CODIGO_TRABAJADOR.ToString, 5)) <= iFolio Then
                        Me.tsbNuevo.PerformClick()
                    End If
                Else
                    Me.Consultar()
                End If
            End If

            NavegadorTrabajadores = True
        Catch ex As Exception
            HandleError(Me.Name, "NavegadorTrabajadores", ex)
        End Try
    End Function

#Region "CURP y RFC"
    Private Sub txtRfc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRfc.KeyDown
        If e.KeyCode = Keys.Return Then

            If txtLEN(Me.TxtNombreTrabajador.Text) = False Then
                Exit Sub
            End If

            If txtLEN(Me.txtApellidoPaterno.Text) = False Then
                Exit Sub
            End If

            Me.txtRfc.Text = Me.RFC(Me.txtApellidoPaterno.Text, Me.txtApellidoMaterno.Text, Me.TxtNombreTrabajador.Text, dtpFechaNacimiento.Value)
            'Me.txtCurp.Text = Me.CURP(Me.txtApellidoPaterno.Text, Me.txtApellidoMaterno.Text, Me.TxtNombreTrabajador.Text, dtpFechaNacimiento.Value)

            Me.txtCurp.Focus()
        End If
    End Sub

    Private Sub txtCurp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCurp.KeyDown
        If e.KeyCode = Keys.Return Then

            If txtLEN(Me.TxtNombreTrabajador.Text) = False Then
                Exit Sub
            End If

            If txtLEN(Me.txtApellidoPaterno.Text) = False Then
                Exit Sub
            End If

            'Me.txtRfc.Text = Me.RFC(Me.txtApellidoPaterno.Text, Me.txtApellidoMaterno.Text, Me.TxtNombreTrabajador.Text, dtpFechaNacimiento.Value)
            Me.txtCurp.Text = Me.CURP(Me.txtApellidoPaterno.Text, Me.txtApellidoMaterno.Text, Me.TxtNombreTrabajador.Text, dtpFechaNacimiento.Value)

            If Me.Estado = enumEstados.NUEVO Then
                Me.ckbPagoTarjeta.Focus()
            Else
                Me.CboEstatus.Focus()
            End If
        End If
    End Sub

    Public Function RFC(ByVal ApellidoPaterno As String, ByVal ApellidoMaterno As String, ByVal Nombre As String, ByVal FechaNacimiento As Date) As String
        RFC = ""
        Dim RFCTemp As String, sDia As String, sMes As String, sAño As String, sHomoClave1 As String, sHomoClave2 As String
        Try

            If (ApellidoPaterno) = "" Then
                RFCTemp = Mid(Depurar(UCase(ApellidoMaterno)), 1, 1) & Vocal(Depurar(UCase(ApellidoMaterno))) & Mid(Depurar(UCase(Nombre)), 1, 1) & "X"
            ElseIf (ApellidoMaterno) = "" Then
                RFCTemp = Mid(Depurar(UCase(ApellidoPaterno)), 1, 1) & Vocal(Depurar(UCase(ApellidoPaterno))) & Mid(Depurar(UCase(Nombre)), 1, 1) & "X"
            Else
                RFCTemp = CorrigePalabraInvalida(Mid(Depurar(UCase(ApellidoPaterno)), 1, 1) & Vocal(Depurar(UCase(ApellidoPaterno))) & Mid(Depurar(UCase(ApellidoMaterno)), 1, 1) & Mid(Depurar(UCase(Nombre)), 1, 1))
            End If

            sDia = Format(FechaNacimiento, "dd").ToString
            sMes = Format(FechaNacimiento, "MM").ToString
            sAño = Format(FechaNacimiento, "yy").ToString
            sHomoClave1 = GenHomVal(ValHomUno(CadenaHomoclave(ApellidoPaterno, ApellidoMaterno, Nombre)))
            sHomoClave2 = GenHomVal(ValHomDos(CadenaHomoclave(ApellidoPaterno, ApellidoMaterno, Nombre)))
            RFC = RFCTemp & sAño & sMes & sDia & sHomoClave1 & sHomoClave2 & RFCdigit(RFCTemp & sAño & sMes & sDia & sHomoClave1 & sHomoClave2)

        Catch ex As Exception
            HandleError(Me.Name, "RFC", ex)
        End Try
    End Function

    Public Function Depurar(ByVal NombreADepurar As String) As String
        Depurar = ""
        Dim iLen As Integer
        Try
            If UCase(Mid(Trim(NombreADepurar), 1, 13)) = "MARIA DE LOS " Then
                iLen = 14
            ElseIf UCase(Mid(Trim(NombreADepurar), 1, 12)) = "MARIA DE LA " Then
                iLen = 13
            ElseIf UCase(Mid(Trim(NombreADepurar), 1, 9)) = "MARIA DE " Then
                iLen = 10
            ElseIf UCase(Mid(Trim(NombreADepurar), 1, 6)) = "DE LA " Or UCase(Mid(Trim(NombreADepurar), 1, 6)) = "MARIA " Then
                iLen = 7
            ElseIf UCase(Mid(Trim(NombreADepurar), 1, 3)) = "DE " Then
                iLen = 4
            ElseIf UCase(Mid(Trim(NombreADepurar), 1, 2)) = "Y " Then
                iLen = 3
            ElseIf UCase(Mid(Trim(NombreADepurar), 1, 4)) = "DEL " Then
                iLen = 5
            ElseIf UCase(Mid(Trim(NombreADepurar), 1, 10)) = "MA DE LOS " Or UCase(Mid(Trim(NombreADepurar), 1, 10)) = "MARIA DEL " Then
                iLen = 11
            ElseIf UCase(Mid(Trim(NombreADepurar), 1, 9)) = "MA DE LA " Then
                iLen = 10
            ElseIf UCase(Mid(Trim(NombreADepurar), 1, 7)) = "MA DEL " Then
                iLen = 8
            ElseIf UCase(Mid(Trim(NombreADepurar), 1, 8)) = "JOSE DE " Then
                iLen = 9
            ElseIf UCase(Mid(Trim(NombreADepurar), 1, 5)) = "JOSE " Then
                iLen = 6
            Else
                iLen = 1
            End If
            Depurar = Trim(Mid(Trim(NombreADepurar), iLen, 50))
        Catch ex As Exception
            HandleError(Me.Name, "Depurar", ex)
        End Try
    End Function

    Public Function Vocal(ByVal CADENA As String) As String
        Vocal = ""
        Try
            Dim letra As String, i As Integer
            For i = 2 To Len(CADENA)
                letra = Mid(CADENA, i, 1)
                If InStr("AEIOU", letra) > 0 Then
                    Vocal = letra
                    Exit Function
                End If
            Next
        Catch ex As Exception
            HandleError(Me.Name, "Vocal", ex)
        End Try
    End Function

    Public Function Constante(ByVal CADENA As String) As String
        Constante = ""
        Try
            Dim letra As String, i As Integer
            For i = 2 To Len(CADENA)
                letra = Mid(CADENA, i, 1)
                If InStr("BCDFGHJKLMNÑPQRSTVWXYZ", letra) > 0 Then
                    Constante = letra
                    Exit Function
                End If
            Next
        Catch ex As Exception
            HandleError(Me.Name, "Constante", ex)
        End Try
    End Function

    Public Function ValorConsonantes(ByVal NombreCadena As String) As String
        ValorConsonantes = ""
        Try
            If Constante(UCase(NombreCadena)) = "Ñ" Then
                ValorConsonantes = "X"
            Else
                ValorConsonantes = Constante(UCase(NombreCadena))
            End If

        Catch ex As Exception
            HandleError(Me.Name, "ValorConsonantes", ex)
        End Try
    End Function

    Public Function CorrigePalabraInvalida(ByVal InicioRFC As String) As String
        CorrigePalabraInvalida = ""
        Try
            If InicioRFC = "BUEI" Or InicioRFC = "BUEY" Or InicioRFC = "CACA" Or InicioRFC = "CACO" Or InicioRFC = "CAGA" Or InicioRFC = "CAGO" Or InicioRFC = "CAKA" Or InicioRFC = "CAKO" Or InicioRFC = "COGE" Or InicioRFC = "COJA" Or InicioRFC = "COJE" Or InicioRFC = "COJI" Or InicioRFC = "COJO" Or InicioRFC = "CULO" Or InicioRFC = "FETO" Or InicioRFC = "GUEY" Or InicioRFC = "JOTO" Or InicioRFC = "KACA" Or InicioRFC = "KACO" Or InicioRFC = "KAGA" Or InicioRFC = "KAGO" Or InicioRFC = "KAKA" Or InicioRFC = "KOGE" Or InicioRFC = "KOJO" Or InicioRFC = "KULO" Or InicioRFC = "LOCA" Or InicioRFC = "LOCO" Or InicioRFC = "LOKA" Or InicioRFC = "LOKO" Or InicioRFC = "MAME" Or InicioRFC = "MAMO" Or InicioRFC = "MEAR" Or InicioRFC = "MEAS" Or InicioRFC = "MEON" Or InicioRFC = "MION" Or InicioRFC = "MOCO" Or InicioRFC = "MULA" Or InicioRFC = "PEDA" Or InicioRFC = "PEDO" Or InicioRFC = "PENE" Or InicioRFC = "PUTA" Or InicioRFC = "PUTO" Or InicioRFC = "QULO" Or InicioRFC = "RATA" Or InicioRFC = "RUIN" Then
                CorrigePalabraInvalida = Mid(InicioRFC, 1, 3) & "X"
            Else
                CorrigePalabraInvalida = InicioRFC
            End If
        Catch ex As Exception
            HandleError(Me.Name, "CorrigePalabraInvalida", ex)
        End Try
    End Function

    Public Function ValHomUno(ByVal valorhomoclave As Integer) As Integer
        Try
            ValHomUno = CInt(Int(valorhomoclave / 34))

        Catch ex As Exception
            HandleError(Me.Name, "ValHomUno", ex)
        End Try
    End Function

    Public Function ValHomDos(ByVal valorhomoclave As Integer) As Integer
        Try
            ValHomDos = CInt(valorhomoclave) Mod 34
        Catch ex As Exception
            HandleError(Me.Name, "ValHomDos", ex)
        End Try
    End Function

    Public Function GenHomVal(ByVal digito As Integer) As String
        GenHomVal = ""
        Try
            Dim ValorDigito As String = ""
            Select Case digito
                Case 0 To 8
                    ValorDigito = Chr(digito + 49)
                Case 9 To 22
                    ValorDigito = Chr(digito + 56)
                Case 23 To 33
                    ValorDigito = Chr(digito + 57)
            End Select
            GenHomVal = ValorDigito.ToString

        Catch ex As Exception
            HandleError(Me.Name, "ValHomDos", ex)
        End Try
    End Function

    Public Function RFCdigit(ByVal RFC As String) As String
        RFCdigit = ""
        Try
            Dim iB As Integer = 13, DigitoNum As Integer = 0, a As Integer, digito As String, ValorDigito As Integer, RfcBasico_Homo As String

            RfcBasico_Homo = Mid(RFC, 1, 12)

            For a = 1 To 12
                digito = Mid(RfcBasico_Homo, a, 1)
                Select Case digito
                    Case "0" To "9"
                        ValorDigito = Asc(digito) - 48
                    Case "A" To "N"
                        ValorDigito = Asc(digito) - 55
                    Case "&"
                        ValorDigito = 24
                    Case "O" To "Z"
                        ValorDigito = Asc(digito) - 54
                    Case " "
                        ValorDigito = 37
                End Select

                DigitoNum = DigitoNum + (ValorDigito * iB)
                iB = iB - 1
            Next
            digito = (11 - (DigitoNum Mod 11)).ToString
            If CInt(digito) = 10 Then
                RFCdigit = "A"
            ElseIf CInt(digito) = 11 Then
                RFCdigit = "0"
            Else
                RFCdigit = Trim(Str(digito))
            End If

        Catch ex As Exception
            HandleError(Me.Name, "RFCdigit", ex)
        End Try
    End Function

    Public Function CadenaHomoclave(ByVal ApellidoPaterno As String, ByVal ApellidoMaterno As String, ByVal Nombres As String) As Integer
        Try
            Dim Nombre As String, DigitoNum As String, a As Integer, digito As String, ValorDigito As String = "", Val1 As String, Val2 As String, Cantidad As Integer
            Nombre = UCase((ApellidoPaterno) & " " & (ApellidoMaterno) & " " & (Nombres))

            DigitoNum = "0"
            For a = 1 To 180
                digito = Mid(Nombre, a, 1)
                Select Case digito
                    Case "0" To "9"
                        ValorDigito = Format(Asc(digito) - 48, "00")
                    Case "A" To "I"
                        ValorDigito = Format(Asc(digito) - 54, "00")
                    Case "J" To "N"
                        ValorDigito = Format(Asc(digito) - 53, "00")
                    Case "Ñ"
                        ValorDigito = "10"
                    Case "O" To "R"
                        ValorDigito = Format(Asc(digito) - 53, "00")
                    Case "S" To "Z"
                        ValorDigito = Format(Asc(digito) - 51, "00")
                    Case " "
                        ValorDigito = Format(0, "00")
                    Case ""
                        ValorDigito = ""
                End Select

                DigitoNum = DigitoNum & ValorDigito
            Next

            For a = 1 To Len(DigitoNum) - 1 ' hasta el penultimo numero. Si no, no podrá tomar dos caracteres cuando haya llegado al último dígito
                Val1 = Mid(DigitoNum.ToString, a, 2).ToString
                Val2 = Microsoft.VisualBasic.Right(Val1, 1)
                Cantidad = (CInt(Val1) * CInt(Val2)) + Cantidad
            Next

            CadenaHomoclave = CInt(Microsoft.VisualBasic.Right(Cantidad.ToString, 3))
        Catch ex As Exception
            HandleError(Me.Name, "CadenaHomoclave", ex)
        End Try
    End Function

    Private Function CURP(ByVal ApellidoPaterno As String, ByVal ApellidoMaterno As String, ByVal Nombre As String, ByVal Fecha As Date) As String
        CURP = ""
        Try
            Dim Consonante1 As String, Consonante2 As String, Consonante3 As String
            Consonante1 = ValorConsonantes(Trim(ApellidoPaterno))
            Consonante2 = ValorConsonantes(Trim(ApellidoMaterno))
            Consonante3 = ValorConsonantes(Trim(Depurar(Nombre)))
            If Consonante1 = "" Then
                Consonante1 = "X"
            End If
            If Consonante2 = "" Then
                Consonante2 = "X"
            End If
            If Consonante3 = "" Then
                Consonante3 = "X"
            End If

            CURP = CurpBasico((ApellidoPaterno), (ApellidoMaterno), (Nombre), Fecha) & Me.cboSexo.SelectedValue.ToString & Me.cboEstadoNacimiento.SelectedValue.ToString & Consonante1 & Consonante2 & Consonante3 & PnUtlmDg(Fecha) & _
            Curpdigit(CurpBasico(ApellidoPaterno, ApellidoMaterno, Nombre, Fecha).ToString & Me.cboSexo.SelectedValue.ToString & _
                            Me.cboEstadoNacimiento.SelectedValue.ToString & Consonante1 & Consonante2 & Consonante3 & PnUtlmDg(Fecha))

        Catch ex As Exception
            HandleError(Me.Name, "CURP", ex)
        End Try
    End Function

    Public Function CurpBasico(ByVal ApellidoPaterno As String, ByVal ApellidoMaterno As String, ByVal Nombre As String, ByVal FechaNacimiento As Date) As String
        CurpBasico = ""
        Dim CurpTemp As String, sDia As String, sMes As String, sAño As String
        Try

            If (ApellidoPaterno) = "" Then
                CurpTemp = "XX" & Mid(Depurar(UCase(ApellidoMaterno)), 1, 1) & Mid(Depurar(UCase(Nombre)), 1, 1)
            ElseIf (ApellidoMaterno) = "" Then
                CurpTemp = Mid(Depurar(UCase(ApellidoPaterno)), 1, 1) & Vocal(Depurar(UCase(ApellidoPaterno))) & "X" & Mid(Depurar(UCase(Nombre)), 1, 1)
            Else
                CurpTemp = CorrigePalabraInvalida(Mid(Depurar(UCase(ApellidoPaterno)), 1, 1) & Vocal(Depurar(UCase(ApellidoPaterno))) & Mid(Depurar(UCase(ApellidoMaterno)), 1, 1) & Mid(Depurar(UCase(Nombre)), 1, 1))
            End If

            sDia = Format(FechaNacimiento, "dd").ToString
            sMes = Format(FechaNacimiento, "MM").ToString
            sAño = Format(FechaNacimiento, "yy").ToString
            CurpBasico = CurpTemp & sAño & sMes & sDia

        Catch ex As Exception
            HandleError(Me.Name, "CURP", ex)
        End Try
    End Function

    Public Function PnUtlmDg(ByVal FechaNacimiento As Date) As String
        PnUtlmDg = ""
        Try
            If FechaNacimiento.Year >= 2000 Then
                PnUtlmDg = "A"
                'ElseIf Not FechaNacimiento.Year >= 2000 Then
                '    PnUtlmDg = "0"
            Else
                PnUtlmDg = "0"
            End If
        Catch ex As Exception
            HandleError(Me.Name, "PnUtlmDg", ex)
        End Try
    End Function

    Function Curpdigit(ByVal CURP As String) As String
        Curpdigit = ""
        Try

            Dim iB As Integer = 18, DigitoNum As Integer = 0, a As Integer, digito As String, ValorDigito As Integer, CurpBasico_Homo As String

            CurpBasico_Homo = Mid(CURP, 1, 17)

            For a = 1 To 17
                digito = Mid(CurpBasico_Homo, a, 1)
                Select Case digito
                    Case "0" To "9"
                        ValorDigito = Asc(digito) - 48
                    Case "A" To "N"
                        ValorDigito = Asc(digito) - 55
                    Case "Ñ"
                        ValorDigito = 24
                    Case "O" To "Z"
                        ValorDigito = Asc(digito) - 54
                    Case " "
                        ValorDigito = 37
                End Select

                DigitoNum = DigitoNum + (ValorDigito * iB)
                iB = iB - 1
            Next
            digito = (10 - (DigitoNum Mod 10)).ToString

            If digito.ToString = "10" Then
                digito = "0"
            End If

            Curpdigit = digito
        Catch ex As Exception
            HandleError(Me.Name, "Curpdigit", ex)
        End Try
    End Function
#End Region

#End Region

#Region "Eventos de objetos"

#Region "Eventos de la lista de elementos"
    Private Sub Grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellClick
        Me.txtCodigoTrabajador.Text = (Me.Grid.CurrentRow.Cells("CODIGO_TRABAJADOR").Value.ToString)
        Me.Consultar()
        Me.Cambia_Estado(enumEstados.CONSULTA)
    End Sub

    Private Sub Grid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellDoubleClick
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado(enumEstados.EDICION)
    End Sub
    'Private Sub lstbElementos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstbElementos.Click

    'End Sub
    'Private Sub lstbElementos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstbElementos.DoubleClick
    '    Me.Cambia_Estado(enumEstados.EDICION)
    'End Sub

    'Private Sub lstbElementos_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstbElementos.Enter
    '    If Me.lstbElementos.Items.Count > 0 Then
    '        Me.tsbEditar.Enabled = True
    '    End If
    'End Sub

    'Private Sub lstbElementos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstbElementos.SelectedIndexChanged
    '    If Me.lstbElementos.SelectedIndex >= 0 Then
    '        Me.txtCodigoTrabajador.Text = Me.lstbElementos.SelectedValue.ToString
    '        Me.Consultar()
    '        Me.Cambia_Estado(enumEstados.CONSULTA)
    '    End If
    'End Sub

#End Region
#Region " Eventos de TxtFiltro"
    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Me.Grid.DataSource = Nothing

        With Me.Grid
            .DataSource = oTrabajadores.ObtenerElementosFiltroTrabajador(Me.txtFiltro.Text)
            .Columns("CODIGO_TRABAJADOR").Width = 40
            .Columns("NOMBRE_COMPLETO_APELLIDO").Width = 300
        End With
    End Sub

    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        txtNoBeep(e)
        txtNoComilla(e)
    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Back Then
            Me.Grid.DataSource = Nothing

            With Me.Grid
                .DataSource = oTrabajadores.ObtenerElementosFiltroTrabajador(Me.txtFiltro.Text)
                .Columns("CODIGO_TRABAJADOR").Width = 40
                .Columns("NOMBRE_COMPLETO_APELLIDO").Width = 300
            End With
        End If
    End Sub
#End Region
#Region "Eventos Genericos"

    Private Sub txt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDomicilioNumero.KeyDown, _
     cboSexo.KeyDown, dtpFechaNacimiento.KeyDown, cboArea.KeyDown, cboPuesto.KeyDown, cboPuntoPago.KeyDown, txtCodigoBanco.KeyDown, _
        CboEstatus.KeyDown, ckbPagoTarjeta.KeyDown, txtNumTarjeta.KeyDown, txtDomicilioCalle.KeyDown, txtDomicilioCodigoPostal.KeyDown, txtDomicilioColonia.KeyDown, txtDomicilioCiudad.KeyDown, _
    txtDomicilioLocalidad.KeyDown, cboDomicilioEstado.KeyDown, cboUnidadMedicaFamiliar.KeyDown, txtNombrePadre.KeyDown, txtNombreMadre.KeyDown, txtNumIMSS.KeyDown, ckbAfiliableIMSS.KeyDown, dtpFechaIngreso.KeyDown, txtNumeroTrabajadorBanco.KeyDown, _
    txtNumeroCuentaBanco.KeyDown
        txtTAB(e)
    End Sub

    Private Sub txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoTrabajador.KeyPress, TxtNombreTrabajador.KeyPress, cboIdTemporada.KeyPress, _
        txtApellidoPaterno.KeyPress, txtApellidoMaterno.KeyPress, cboSexo.KeyPress, dtpFechaNacimiento.KeyPress, cboEstadoNacimiento.KeyPress, cboArea.KeyPress, cboPuesto.KeyPress, cboPuntoPago.KeyPress, txtCodigoMayordomo.KeyPress, _
        CboEstatus.KeyPress, ckbPagoTarjeta.KeyPress, txtCodigoBanco.KeyPress, txtDomicilioCalle.KeyPress, txtDomicilioColonia.KeyPress, txtDomicilioCiudad.KeyPress, txtCurp.KeyPress, txtRfc.KeyPress, _
    txtDomicilioLocalidad.KeyPress, cboDomicilioEstado.KeyPress, cboUnidadMedicaFamiliar.KeyPress, txtNombrePadre.KeyPress, txtNombreMadre.KeyPress, txtNumIMSS.KeyPress, ckbAfiliableIMSS.KeyPress, ckbFijoIMSS.KeyPress, ckbSindicato.KeyPress, _
    dtpFechaIngreso.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDomicilioNumero.KeyPress, txtDomicilioCodigoPostal.KeyPress, txtNumTarjeta.KeyPress, txtNumIMSS.KeyPress, _
        txtCodigoTrabajador.KeyPress, txtCodigoMayordomo.KeyPress, txtNumeroTrabajadorBanco.KeyPress, txtNumeroCuentaBanco.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosDecimalKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSueldo.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub
#End Region

#Region "Keydown específicos"

    Private Sub TxtNombreTrabajador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombreTrabajador.KeyDown, txtApellidoPaterno.KeyDown, txtApellidoMaterno.KeyDown
        'Me.TxtNombreTrabajador.Text = Me.TxtNombreTrabajador.Text.TrimEnd()
        'Me.txtApellidoPaterno.Text = Me.txtApellidoPaterno.Text.TrimEnd()
        'Me.txtApellidoMaterno.Text = Me.txtApellidoMaterno.Text.TrimEnd()
        txtTAB(e)
    End Sub

    Private Sub txtCiudad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDomicilioCiudad.KeyDown
        If e.KeyCode = Keys.Return Then
            If txtLEN(Me.txtDomicilioLocalidad.Text) = False Then
                Me.txtDomicilioLocalidad.Text = Me.txtDomicilioCiudad.Text
                txtTAB(e)
            End If
        End If
    End Sub

    Private Sub cboEstadoNacimiento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEstadoNacimiento.KeyDown
        If e.KeyCode = Keys.Return Then

            If txtLEN(Me.TxtNombreTrabajador.Text) = False Then
                Exit Sub
            End If

            If txtLEN(Me.txtApellidoPaterno.Text) = False Then
                Me.txtApellidoPaterno.Focus()
                Exit Sub
            End If

            'If txtLEN(Me.txtApellidoMaterno.Text) = False Then
            '    Exit Sub
            'End If
            Me.txtRfc.Text = Me.RFC(Me.txtApellidoPaterno.Text, Me.txtApellidoMaterno.Text, Me.TxtNombreTrabajador.Text, dtpFechaNacimiento.Value)
            Me.txtCurp.Text = Me.CURP(Me.txtApellidoPaterno.Text, Me.txtApellidoMaterno.Text, Me.TxtNombreTrabajador.Text, dtpFechaNacimiento.Value)
            Me.cboArea.Focus()
        End If
    End Sub

    Private Sub txtCodigoMayordomo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoMayordomo.KeyDown
        Dim sCodigo As String
        Select Case e.KeyCode
            Case Keys.F6
                Dim oMayordomos As New Class_CatTrabajadores
                oMayordomos = New Class_CatTrabajadores
                sCodigo = oMayordomos.BusquedaVisual_Mayordomos

                If txtLEN(sCodigo) = True Then
                    Me.txtCodigoMayordomo.Text = sCodigo
                End If

            Case Keys.Return
                If txtLEN(Me.txtCodigoMayordomo.Text) = False Then
                    Me.lblNombreMayordomo.Text = ""
                    Me.txtSueldo.Focus()
                    Exit Sub
                End If

                Dim sql As New Class_find("SELECT CODIGO_TRABAJADOR,NOMBRE_TRABAJADOR FROM NOMINA_CAT_TRABAJADORES T INNER JOIN NOMINA_CAT_PUESTOS P ON(T.CODIGO_PUESTO=P.CODIGO_PUESTO AND P.NOMBRE_PUESTO='MAYORDOMO') WHERE  T.ID_NOMINA_TEMPORADA=" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA.ToString & " AND CODIGO_TRABAJADOR='" & Me.txtCodigoMayordomo.Text & "'")
                If sql.Result1 = "" Then
                    MsgBox("El código del mayordomo no existe, favor de verificar.", MsgBoxStyle.Critical, "Validación de código de mayordomo")
                    Me.lblNombreMayordomo.Text = ""
                    Me.txtCodigoMayordomo.Focus()
                    Exit Sub
                Else
                    Me.lblNombreMayordomo.Text = sql.Result2
                    Me.txtSueldo.Focus()
                End If
        End Select
    End Sub

    Private Sub ckbSindicato_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ckbSindicato.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.tsbGrabar.PerformClick()
        End If
    End Sub

    Private Sub txtNombrePadre_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombrePadre.KeyDown, txtNombreMadre.KeyDown
        Me.txtNombrePadre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreMadre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        'Me.txtNombrePadre.Text = Me.txtNombrePadre.Text.TrimEnd()
        'Me.txtNombreMadre.Text = Me.txtNombreMadre.Text.TrimEnd()
    End Sub

    Private Sub txtCodigoBanco_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoBanco.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
                Dim Busqueda = New Busqueda_General("CODIGO_BANCO AS CODIGO,NOMBRE_BANCO AS NOMBRE", "CAT_BANCOS", " 1=1 AND ESTATUS_BANCO='A' AND PROTEGIDO='0' ", "NOMBRE", "NOMBRE_BANCO")
                Busqueda.ShowDialog()
                Me.txtCodigoBanco.Text = "" & Busqueda.Tag.ToString
                Busqueda.Dispose()
            Case Keys.Return
                Dim sql As New Class_find("SELECT NOMBRE_BANCO FROM CAT_BANCOS WHERE CODIGO_BANCO='" & Me.txtCodigoBanco.Text & "' AND ESTATUS_BANCO='A' AND PROTEGIDO='0'")
                If sql.Result1 = "" Then
                    MsgBox("El código de Banco que intenta buscar no existe o esta dado de Baja, favor de intentar con otro codigo", MsgBoxStyle.Critical, "Validación de Bancos")
                    Me.LblBanco.Text = ""
                    Me.txtCodigoBanco.Focus()
                    Exit Sub
                Else
                    Me.LblBanco.Text = sql.Result1
                    'Me.txtDomicilioCalle.Focus()
                End If
        End Select
    End Sub

    Private Sub txtSueldo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSueldo.KeyDown
        If e.KeyCode = Keys.Return Then
            If txtLEN(Me.txtSueldo.Text) = False Then
                'Me.txtDomicilioLocalidad.Text = Me.txtDomicilioCiudad.Text
                Me.txtSueldo.Text = FormatImporteContable(0, True)
            Else
                Me.txtSueldo.Text = FormatImporteContable(valorNumerico(Me.txtSueldo.Text), True)
            End If
            txtTAB(e)
        End If
    End Sub

    Private Sub txtCodigoTrabajador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoTrabajador.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If Me.Consultar() = False Then
                    Me.tsbNuevo.PerformClick()
                End If
        End Select
        txtTAB(e)
    End Sub
#End Region

    Private Sub txtLocalidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDomicilioLocalidad.Click
        If txtLEN(Me.txtDomicilioLocalidad.Text) = False Then
            Me.txtDomicilioLocalidad.Text = Me.txtDomicilioCiudad.Text
        End If
    End Sub

    Private Sub cboPuntoPago_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPuntoPago.SelectedValueChanged
        'If Me.Estado = enumEstados.NUEVO Then
        '    Me.oTrabajadores.CODIGO_PUNTO_PAGO = CInt(Me.cboPuntoPago.SelectedValue)
        '    Me.oTrabajadores.CodigoSiguiente()
        '    Me.txtCodigoTrabajador.Text = Me.oTrabajadores.CODIGO_TRABAJADOR.ToString
        'End If
    End Sub

    'Private Sub ckbPagoTarjeta_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbPagoTarjeta.CheckedChanged
    '    If Me.ckbPagoTarjeta.Checked = True Then
    '        Me.txtNumTarjeta.Enabled = True
    '        Me.txtCodigoBanco.Enabled = True
    '    Else
    '        Me.txtNumTarjeta.Enabled = False
    '        Me.txtCodigoBanco.Enabled = False
    '        Me.LblBanco.Text = ""
    '    End If
    'End Sub

    Private Sub pbFotoTrabajador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbFotoTrabajador.Click
        'Dim sFoto As String = Empresa_Sistema.NOMINA_RUTA_FOTOS_TRABAJADORES.ToString & "\" & Me.txtCodigoTrabajador.Text & ".jpg"
        'Me.pbFotoTrabajador.Image = System.Drawing.Image.FromFile(sFoto)
    End Sub

    Private Sub btnAgregaFoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregaFoto.Click
        Dim oFd As OpenFileDialog = New OpenFileDialog()

        oFd.Filter = "Imágenes JPG (*.jpg)|*.jpg|Mapas de bits (*.bmp)|*.bmp"
        oFd.Title = "Abre una imagen JPG o BMP"

        If oFd.ShowDialog = Windows.Forms.DialogResult.OK Then
            'Me.pbFotoTrabajador.Image.Dispose()
            Me.pbFotoTrabajador.Image = Nothing
            Me.pbFotoTrabajador.Image = System.Drawing.Image.FromFile(oFd.FileName)
        End If
    End Sub

    Private Sub cboPuntoPago_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPuntoPago.SelectedIndexChanged
        If Me.Estado = enumEstados.NUEVO Then
            Me.oTrabajadores.CODIGO_PUNTO_PAGO = CInt(Me.cboPuntoPago.SelectedValue)
            Me.oTrabajadores.CodigoSiguiente()

            Me.txtCodigoTrabajador.Text = String.Format("{0,5}", Me.oTrabajadores.CODIGO_TRABAJADOR.ToString).Replace(" ", "0")
        End If
    End Sub

    Private Sub btnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        NavegadorTrabajadores("Anterior")
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        NavegadorTrabajadores("Siguiente")
    End Sub
#End Region

End Class