Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Collections
Imports System.Collections.Generic
Imports CrystalDecisions.CrystalReports.Engine

Public Class UtileriasFirmaElectronicaCancelacionMovimientosFueraPeriodo

    Public ValidaContraseña As Boolean = False
    Public Titulo As String
    Public TituloCorto As String
    Public Centrada As Boolean
    Public sFolio As String
    Private oUtileriasCancela As New Class_UtileriasFirmaElectronicaCancelacion

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        ValidaAutorizacion()
    End Sub

    Private Function ValidaAutorizacion() As Boolean
        Try
            If Len(Me.txtContraseña.Text) = False Then
                MsgBox("Asígne la contraseña.", vbExclamation, Me.Text)
                Me.txtContraseña.Focus()
                Exit Function
            End If

            If txtLEN(Me.TxtConcepto.Text) = False Then
                MsgBox("Asígne el concepto o el porqué se esta realizando el movimiento.", vbExclamation, Me.Text)
                Me.TxtConcepto.Focus()
                Exit Function
            End If

            Me.oUtileriasCancela = New Class_UtileriasFirmaElectronicaCancelacion
            Me.oUtileriasCancela.FOLIO_DOCUMENTO = Me.sFolio
            Me.oUtileriasCancela.FECHA_CANCELACION = Me.dtFechaCancelacion.Value
            Me.oUtileriasCancela.CONTRASEÑA = Me.txtContraseña.Text
            Me.ValidaContraseña = Me.oUtileriasCancela.ValidaContraseñaCancelarMovimientosFueraPeriodo()

            If Me.ValidaContraseña = True Then
                Me.Hide()
            Else
                MsgBox("Autorización denegada. Verifique la contraseña.", vbExclamation, Me.Text)
                Me.txtNombreUsuario.Text = UCase(Usuario.Nombre_Usuario)
                Me.txtContraseña.Text = ""
                Me.txtContraseña.Focus()
            End If

        Catch ex As Exception
            HandleError(Me.Text, "BusquedaVisual_PorCodigo", ex)
        End Try
    End Function

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.Hide()
    End Sub

    Private Sub dtFechaCancelacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtFechaCancelacion.KeyDown
        txtTAB(e)
    End Sub

    Private Sub UtileriasFirmaElectronicaCancelacionMovimientosFueraPeriodo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lblTitulo.Text = Me.Titulo
        Me.lblTituloCorto.Text = Me.TituloCorto
        Me.dtFecha.Value = Now
        Me.dtFechaCancelacion.Value = Now
        Me.txtNombreUsuario.Text = UCase(Usuario.Nombre_Usuario)

        Me.CenterToScreen()
    End Sub
End Class