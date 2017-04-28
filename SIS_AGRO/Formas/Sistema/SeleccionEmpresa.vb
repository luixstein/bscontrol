Option Explicit On

Imports System.Data.SqlClient

Public Class SeleccionEmpresa

    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "SeleccionEmpresa"
        End Get
    End Property

    Private Sub SeleccionEmpresa_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If bSistemaDirecto = True Then
            Me.cboEmpresa.SelectedValue = "AGRINET_LAND"
            'Me.AbrirLogin()
            btnAceptar_Click(sender, e)
        End If
    End Sub

    Private Sub SeleccionEmpresa_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargaEmpresas()
    End Sub

    Private Sub cboEmpresa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEmpresa.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.AbrirLogin()
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.AbrirLogin()
    End Sub

    Private Sub AbrirLogin()
        Me.Hide()
        My.Settings.BaseDatos = Me.cboEmpresa.SelectedValue.ToString
        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Private Sub CargaEmpresas()
        Dim Conexion As String = "Data Source=" & My.Settings.Servidor & ";Initial Catalog=BS_EMPRESAS;" & "User ID=" & sCongif1 & ";Password=" & sCongif2

        'MsgBox("SERVER = " & My.Settings.Servidor & vbCrLf & "USER = " & sCongif1 & vbCrLf & "PASS = " & sCongif2)

        Dim dTable As New DataTable
        Dim ds As New SqlDataAdapter("SELECT ALIAS_EMPRESA,NOMBRE_DB FROM SIS_CAT_EMPRESAS ORDER BY ID_SIS_CAT_EMPRESAS", Conexion)
        Try
            ds.Fill(dTable)
            With Me.cboEmpresa
                .DisplayMember = "ALIAS_EMPRESA"
                .ValueMember = "NOMBRE_DB"
                .DataSource = dTable
            End With
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "CargaEmpresas", ex)
        Finally
            ds.Dispose()
        End Try
    End Sub
End Class