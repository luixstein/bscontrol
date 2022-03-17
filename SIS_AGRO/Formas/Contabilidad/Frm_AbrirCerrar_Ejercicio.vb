Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_AbrirCerrar_Ejercicio
    Private oEjercicio As New Class_Contabilidad_Ejercicios

    Private oFormaPoliza As Frm_Contabilidad_Captura_Polizas

#Region "Constructor y destructor"
    Public Sub New()
        InitializeComponent()
        DesplegarEjercicios()
        'EmpresaParametros = New Class_SisContabilidadParametros
        Inicializa()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Eventos"
    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuenta.KeyPress
        txtNoBeep(e)
        txtSoloNumerosEnteros(e)
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Const sProcedure As String = "btnCerrar_Click"
        Try
            If Me.Validar = True Then
                If oEjercicio.Actualizar(CInt(Me.cboEjercicio.SelectedValue), Me.txtCuenta.Text, True) = True Then
                    MsgBox("El ejercicio se cerró correctamente.", MsgBoxStyle.Information, sProcedure)
                    Me.oFormaPoliza = New Frm_Contabilidad_Captura_Polizas
                    Me.oFormaPoliza.FolioPolizaConsultaExterior = "PC." & Me.cboEjercicio.Text
                    Me.oFormaPoliza.ShowDialog()

                    Dim oElementos As New Class_Contabilidad_Ejercicios(CInt(Me.cboEjercicio.SelectedValue))
                    Me.lblEstatus.Text = oElementos.ESTATUS_EJERCICIO.ToString

                    If oElementos.ESTATUS_EJERCICIO.ToString = "C" Then
                        Me.btnCerrar.Enabled = False
                        Me.btnAbrir.Enabled = True
                    Else
                        Me.btnCerrar.Enabled = True
                        Me.btnAbrir.Enabled = False
                    End If
                End If
            End If

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click
        Const sProcedure As String = "btnAbrir_Click"
        Try
            If oEjercicio.Actualizar(CInt(Me.cboEjercicio.SelectedValue), "", False) = True Then
                MsgBox("El ejercicio se abrió correctamente.", MsgBoxStyle.Information, sProcedure)
                Dim oElementos As New Class_Contabilidad_Ejercicios
                oElementos = New Class_Contabilidad_Ejercicios(CInt(Me.cboEjercicio.SelectedValue))
                Me.lblEstatus.Text = oElementos.ESTATUS_EJERCICIO.ToString

                If oElementos.ESTATUS_EJERCICIO.ToString = "C" Then
                    Me.btnCerrar.Enabled = False
                    Me.btnAbrir.Enabled = True
                Else
                    Me.btnCerrar.Enabled = True
                    Me.btnAbrir.Enabled = False
                End If
                Exit Sub
            End If
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub txtCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuenta.KeyDown
        Const sProcedure As String = "txtCuenta_KeyDown"
        Try
            Select Case e.KeyCode
                Case Keys.F6
BusquedaVisual:
                    Dim oCuenta As New Class_CatCuentas
                    Dim sCuenta As String = oCuenta.BusquedaVisual_PorCodigoFiltro("3") '("3003")
                    If sCuenta.Length > 0 Then
                        Me.txtCuenta.Text = sCuenta
                        sCuenta = Replace(sCuenta, "'", "''")
                        Dim sql As New Class_find("SELECT CUENTA_CONTABLE,NOMBRE_CUENTA FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & sCuenta & "'")
                        Me.txtCuenta.Text = sCuenta
                        Me.lblCuenta.Text = sql.Result2
                        sql = Nothing
                    Else
                        Me.txtCuenta.Text = ""
                        Me.lblCuenta.Text = ""
                    End If
                Case Keys.Return
                    Dim sql As New Class_find("SELECT CUENTA_CONTABLE,NOMBRE_CUENTA FROM CON_CAT_CUENTAS WHERE CUENTA_CONTABLE='" & sReplace(Me.txtCuenta.Text) & "' AND ESMAYOR=0 ")
                    If sql.Result1 = "" Then
                        MsgBox("La cuenta contable que intenta buscar es de mayor, favor de intentar con otro codigo", MsgBoxStyle.Exclamation, "Validación de Cuentas Contables")
                        GoTo BusquedaVisual
                    Else
                        Me.lblCuenta.Text = sql.Result2
                        SendKeys.Send("{TAB}")
                    End If
                    sql = Nothing
            End Select

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub cboEjercicio_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEjercicio.SelectedValueChanged
        Const sProcedure As String = "cboEjercicio_SelectedValueChanged"
        Try
            Dim oElementos As New Class_Contabilidad_Ejercicios
            If Me.cboEjercicio.SelectedValue Is Nothing = False Then
                oElementos = New Class_Contabilidad_Ejercicios(CInt(Me.cboEjercicio.SelectedValue))
                Me.lblEstatus.Text = oElementos.ESTATUS_EJERCICIO.ToString
                If oElementos.ESTATUS_EJERCICIO.ToString = "C" Then
                    Dim sql As New Class_find("SELECT TOP 1 D.CUENTA_CONTABLE,C.NOMBRE_CUENTA " &
                                              "FROM CON_POLIZAS_GLOBAL G " &
                                              "INNER JOIN CON_POLIZAS_DETALLE D ON (G.FOLIO_POLIZA=D.FOLIO_POLIZA) " &
                                              "INNER JOIN CON_CAT_CUENTAS C ON (D.CUENTA_CONTABLE=C.CUENTA_CONTABLE) " &
                                              "WHERE G.FOLIO_POLIZA ='PC." & Me.cboEjercicio.Text & "' " &
                                              "ORDER BY ID_CON_POLIZAS_DETALLE DESC ")

                    Me.txtCuenta.Text = sql.Result1.ToString
                    Me.lblCuenta.Text = sql.Result2.ToString
                    Me.btnCerrar.Enabled = False
                    Me.btnAbrir.Enabled = True
                Else
                    Me.txtCuenta.Text = ""
                    Me.lblCuenta.Text = ""
                    Me.btnCerrar.Enabled = True
                    Me.btnAbrir.Enabled = False
                End If
            End If
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Me.cboEjercicio.SelectedValue = Plaza.ID_CON_EJERCICIO
    End Sub

    Private Sub DesplegarEjercicios()
        Const sProcedure As String = "DesplegarEjercicios"
        Try
            Dim oElementos As New Class_Contabilidad_Ejercicios
            With Me.cboEjercicio
                .DisplayMember = "NOMBRE_EJERCICIO"
                .ValueMember = "ID_CON_EJERCICIO"
                Dim dView As New Data.DataView(oElementos.ObtenerEjercicios)
                ' dView.Sort = "NOMBRE_EJERCICIO"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Function Validar() As Boolean
        Const sProcedure As String = "Validar"
        Dim bResultado As Boolean = False

        Try
            If txtLEN(Me.txtCuenta.Text) = True Then
                If Strings.Left(Me.txtCuenta.Text, Len(EmpresaParametros.CUENTA_CONTABLE_CIERRE)) <> EmpresaParametros.CUENTA_CONTABLE_CIERRE Then
                    MsgBox("La cuenta de cierre de ejercicio debe empezar con " & EmpresaParametros.CUENTA_CONTABLE_CIERRE & " Favor de verificar.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                Dim oCuenta As New Class_CatCuentas(Me.txtCuenta.Text)
                If oCuenta._Existe = False Then
                    MsgBox("La cuenta de cierre de ejercicio, no existe. Favor de verificar", MsgBoxStyle.Exclamation, sProcedure)
                    Me.txtCuenta.Focus()
                    Return False
                End If
            Else
                Me.lblCuenta.Text = ""
                MsgBox("Asígne una cuenta de cierre de ejercicio. ", MsgBoxStyle.Exclamation, sProcedure)
                Me.txtCuenta.Focus()
                Return False
            End If

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function
#End Region

End Class