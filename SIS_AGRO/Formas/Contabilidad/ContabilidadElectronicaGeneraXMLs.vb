Public Class ContabilidadElectronicaGeneraXMLs

#Region "Opciones"
    Private Sub btnGeneraXMLCatalogoCuentas_Click(sender As Object, e As EventArgs) Handles btnGeneraXMLCatalogoCuentas.Click
        Me.btnGeneraXMLCatalogoCuentas.Enabled = False
        Me.GeneraXMLCatalogoCuentas()
        Me.btnGeneraXMLCatalogoCuentas.Enabled = True
    End Sub

    Private Sub btnGeneraXMLBalanzaComprobacion_Click(sender As Object, e As EventArgs) Handles btnGeneraXMLBalanzaComprobacion.Click
        Me.btnGeneraXMLBalanzaComprobacion.Enabled = False
        Me.GeneraXMLBalanzaComprobacion()
        Me.btnGeneraXMLBalanzaComprobacion.Enabled = True
    End Sub

    Private Sub btnPrevioBalanzaComprobacion_Click(sender As Object, e As EventArgs) Handles btnPrevioBalanzaComprobacion.Click
        Me.ReporteBalanzaComprobacion()
    End Sub
#End Region

#Region "Eventos"

    Private Sub ContabilidadElectronicaGeneraXMLs_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Shift + Keys.I Then
            Me.chkPruebas.Visible = True
        End If
    End Sub

    Private Sub ContabilidadElectronicaGeneraXMLs_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DesplegarEjercicios()
        Me.CmbEjercicio.SelectedValue = Plaza.ID_CON_EJERCICIO
        Me.lblMsg.Visible = False : Me.lblMsg.Text = ""
        Me.dtFechaModificacionBalanza.Value = Date.Now
        Me.dtFecha.Value = Date.Now
    End Sub

    Private Sub dtFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtFecha.ValueChanged
        Me.lblMsg.Visible = False : Me.lblMsg.Text = ""
    End Sub

    Private Sub CmbEjercicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbEjercicio.SelectedIndexChanged
        Me.lblMsg.Visible = False : Me.lblMsg.Text = ""
    End Sub

    Private Sub rbBalanzaComplementaria_CheckedChanged(sender As Object, e As EventArgs) Handles rbBalanzaComplementaria.CheckedChanged
        If Me.rbBalanzaComplementaria.Checked = True Then
            Me.dtFechaModificacionBalanza.Visible = True : Me.lblDisplayFechaModificacionBalanza.Visible = True
        Else
            Me.dtFechaModificacionBalanza.Visible = False : Me.lblDisplayFechaModificacionBalanza.Visible = False
        End If
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Function GeneraXMLCatalogoCuentas() As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "GeneraXMLCatalogoCuentas"
        Try
            Me.lblMsg.Visible = False : Me.lblMsg.Text = ""

            Dim oConta As New Class_Contabilidad_Electronica
            bResultado = oConta.GeneraXMLCatalogoCuentas(FechaMesFIN(Me.dtFecha.Value), Convert.ToInt32(Me.chkPruebas.Checked))

            If bResultado = True Then
                Me.lblMsg.Text = "XML CATALOGOS CUENTAS GENERADO CORRECTAMENTE"
                Me.lblMsg.Visible = True
            End If

            oConta = Nothing
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
        Return bResultado
    End Function

    Private Function GeneraXMLBalanzaComprobacion() As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "GeneraXMLBalanzaComprobacion"
        Try
            Me.lblMsg.Visible = False : Me.lblMsg.Text = ""

            If txtLEN(Me.CmbEjercicio.Text) = False Then
                MsgBox("Seleccione el ejercicio por favor.", MsgBoxStyle.Exclamation, Me.Name)
                Me.CmbEjercicio.Focus()
                Exit Function
            End If

            Dim oConta As New Class_Contabilidad_Electronica, iCodigoTipoArchivo As Integer
            If Me.rbBalanzaNormal.Checked = True Then
                iCodigoTipoArchivo = 2
            ElseIf Me.rbBalanzaComplementaria.Checked = True Then
                iCodigoTipoArchivo = 3
            End If
            bResultado = oConta.GeneraXMLBalanzaComprobacion(FechaMesFIN(Me.dtFecha.Value), iCodigoTipoArchivo, Me.CmbEjercicio.SelectedValue, Me.dtFechaModificacionBalanza.Value, Convert.ToInt32(Me.chkPruebas.Checked))

            If bResultado = True Then
                Me.lblMsg.Text = "XML BALANZA COMPROBACION GENERADO CORRECTAMENTE"
                Me.lblMsg.Visible = True
            End If

            oConta = Nothing
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
        Return bResultado
    End Function

    Private Sub ReporteBalanzaComprobacion()
        Const sProcedure As String = "ReporteBalanzaComprobacion"
        Try
            Me.lblMsg.Visible = False : Me.lblMsg.Text = ""

            If txtLEN(Me.CmbEjercicio.Text) = False Then
                MsgBox("Seleccione el ejercicio por favor.", MsgBoxStyle.Exclamation, Me.Name)
                Me.CmbEjercicio.Focus()
                Exit Sub
            End If

            Dim oConta As New Class_Contabilidad_Electronica
            oConta.ReporteBalanzaComprobacion(FechaMesFIN(Me.dtFecha.Value), 2, Me.CmbEjercicio.SelectedValue, 0)
            oConta = Nothing

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Function GeneraXMLBalanzaCierre() As Boolean
        Dim bResultado As Boolean = False
        Try
            Me.lblMsg.Visible = False : Me.lblMsg.Text = ""

            MsgBox("En proceso...")
        Catch ex As Exception
            HandleError(Me.Name, "GeneraXMLBalanzaCierre", ex)
        End Try
        Return bResultado
    End Function

    Private Sub DesplegarEjercicios()
        Try
            Dim oElementos As New Class_Contabilidad_Ejercicios
            With Me.CmbEjercicio
                .DisplayMember = "NOMBRE_EJERCICIO"
                .ValueMember = "ID_CON_EJERCICIO"

                Dim dView As New Data.DataView(oElementos.ObtenerEjerciciosFiscales)
                .DataSource = dView
                If dView.Count > 0 Then
                    'Dim Ejercicio As New Class_find("SELECT ID_CON_EJERCICIO FROM CON_EJERCICIOS WHERE '" & Format(Date.Now, "yyyy-dd-MM") & "' BETWEEN FECHA_INICIO AND FECHA_FINAL AND TIPO_CONTABILIDAD='FN'")
                    .SelectedValue = Plaza.ID_CON_EJERCICIO.ToString ' Ejercicio.Result1.ToString
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarEjercicios", ex)
        End Try
    End Sub
#End Region

End Class