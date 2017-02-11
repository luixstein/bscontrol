Option Strict On

Public Class Frm_Nomina_TrabajadorAdicional
    Private _NUMERO_SEMANA As Integer
    Private _FECHA As Date
    Private _CODIGO_TRABAJADOR As String

#Region "Propiedades"
    Public Property NUMERO_SEMANA() As Integer
        Get
            Return _NUMERO_SEMANA
        End Get
        Set(ByVal Value As Integer)
            Me._NUMERO_SEMANA = Value
        End Set
    End Property

    Public Property FECHA() As Date
        Get
            Return _FECHA
        End Get
        Set(ByVal Value As Date)
            Me._FECHA = Value
        End Set
    End Property

    Public Property CODIGO_TRABAJADOR() As String
        Get
            Return _CODIGO_TRABAJADOR
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_TRABAJADOR = Value
        End Set
    End Property
#End Region

    Private Sub txtCodigoTrabajador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoTrabajador.KeyDown
        Dim sText As String
        Dim oTrabajadores As New Class_CatTrabajadores

        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = oTrabajadores.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then Me.txtCodigoTrabajador.Text = sText
            Case Keys.Enter
                If txtLEN(Me.txtCodigoTrabajador.Text) = False Then
                    Me.lblNombreTrabajador.Text = "" : GoTo Buscar : Exit Sub
                End If

                oTrabajadores = New Class_CatTrabajadores(Me.txtCodigoTrabajador.Text)
                If oTrabajadores.Existe = False Then
                    Me.lblNombreTrabajador.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblNombreTrabajador.Text = oTrabajadores.NOMBRE_TRABAJADOR + " " + oTrabajadores.APELLIDO_PATERNO + " " + oTrabajadores.APELLIDO_MATERNO
                Me.dtFecha.Focus()
        End Select
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me._CODIGO_TRABAJADOR = Me.txtCodigoTrabajador.Text
        Me._FECHA = Me.dtFecha.Value

        'Dim sql As New Class_find("SELECT DATEADD(DAY, (" & (Me._NUMERO_SEMANA - 1).ToString & "*7),FECHA1),DATEADD(DAY," & (Me._NUMERO_SEMANA - 1).ToString & "*7,FECHA1)+7 FROM NOMINA_TEMPORADAS WHERE ID_NOMINA_TEMPORADA=" & Plaza.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA)

        'If Me.dtFecha.Value < CDate(sql.Result1.ToString) Or Me.dtFecha.Value > CDate(sql.Result2.ToString) Then
        '    MsgBox("El rango especificado esta fuera del rango de la semana.", MsgBoxStyle.Exclamation, Me.Name)
        '    Exit Sub
        'End If
        Me.Visible = False
    End Sub

    Private Sub Frm_Nomina_TrabajadorAdicional_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtCodigoTrabajador.Focus()
    End Sub

    Private Sub dtFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtFecha.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub text_KeyPress(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoTrabajador.KeyPress, dtFecha.KeyPress, btnAceptar.KeyPress, btnCancelar.KeyPress
        'txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class