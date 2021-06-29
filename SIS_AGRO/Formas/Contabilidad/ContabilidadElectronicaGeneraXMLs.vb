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

    Private Sub btnGeneraXML_Click(sender As Object, e As EventArgs) Handles btnGeneraXML.Click
        Me.btnGeneraXML.Enabled = False
        Me.GeneraXMLOtros()
        Me.btnGeneraXML.Enabled = True
    End Sub
#End Region

#Region "Eventos"

    Private Sub ContabilidadElectronicaGeneraXMLs_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Shift + Keys.I Then
            Me.chkPruebas.Visible = True
        End If
    End Sub

    Private Sub ContabilidadElectronicaGeneraXMLs_Load(sender As Object, e As EventArgs) Handles Me.Load
        Const sProcedure As String = "ContabilidadElectronicaGeneraXMLs_Load"
        Try
            Me.DesplegarEjercicios()
            Me.CmbEjercicio.SelectedValue = Plaza.ID_CON_EJERCICIO
            Me.lblMsg.Visible = False : Me.lblMsg.Text = ""
            Me.dtFechaModificacionBalanza.Value = Date.Now
            Me.dtFecha.Value = Date.Now
            Me.DesplegarTiposSolicitud()
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
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
                Me.lblMsg.Text = "XML GENERADO CORRECTAMENTE"
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
                Me.lblMsg.Text = "XML GENERADO CORRECTAMENTE"
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

    Private Function GeneraXMLBalanzaComplementaria() As Boolean
        Dim bResultado As Boolean = False
        Try
            Me.lblMsg.Visible = False : Me.lblMsg.Text = ""

            MsgBox("No terminada avíse al depto de sistemas...")
        Catch ex As Exception
            HandleError(Me.Name, "GeneraXMLBalanzaComplementaria", ex)
        End Try
        Return bResultado
    End Function

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

    Private Function GeneraXMLOtros() As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "GeneraXMLOtros"
        Try
            Me.lblMsg.Visible = False : Me.lblMsg.Text = ""

            If txtLEN(Me.CmbEjercicio.Text) = False Then
                MsgBox("Seleccione el ejercicio por favor.", MsgBoxStyle.Exclamation, Me.Name)
                Me.CmbEjercicio.Focus()
                Exit Function
            End If

            If Me.cboTipoSolicitud.SelectedIndex = -1 Then
                MsgBox("Seleccione un tipo de solicitud por favor.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            Dim oConta As New Class_Contabilidad_Electronica, iCodigoTipoArchivo As Integer, sTipoOtro As String = ""

            If Me.rbPolizasPeriodo.Checked = True Then
                sTipoOtro = "POLIZAS"
            ElseIf Me.rbAuxiliarCtas.Checked = True Then
                sTipoOtro = "AUXILIAR_CUENTAS"
            ElseIf Me.rbAuxiliarFolios.Checked = True Then
                sTipoOtro = "AUXILIAR_FOLIOS"
            End If

            iCodigoTipoArchivo = New Class_find("SELECT CODIGO_TIPO_ARCHIVO FROM CONTABILIDAD_ELECTRONICA_CATALOGO_TIPOS_ARCHIVO " &
                                                "WHERE CODIGO_TIPO_SAT='" & Me.cboTipoSolicitud.Text.Substring(0, 2) & "' AND NOMBRE_TIPO_ARCHIVO='" & sTipoOtro & "'").Result1

            If Me.rbPolizasPeriodo.Checked = True Then
                bResultado = oConta.GeneraXMLPolizasPeriodo(FechaMesFIN(Me.dtFecha.Value), iCodigoTipoArchivo, Me.CmbEjercicio.SelectedValue, Me.txtNumOrden.Text, Me.txtNumTramite.Text, Convert.ToInt32(Me.chkPruebas.Checked))
            ElseIf Me.rbAuxiliarCtas.Checked = True Then
                bResultado = oConta.GeneraXMLAuxiliarCtas(FechaMesFIN(Me.dtFecha.Value), iCodigoTipoArchivo, Me.CmbEjercicio.SelectedValue, Me.txtNumOrden.Text, Me.txtNumTramite.Text, Convert.ToInt32(Me.chkPruebas.Checked))
            ElseIf Me.rbAuxiliarFolios.Checked = True Then
                MsgBox("FALTA")
            End If

            If bResultado = True Then
                Me.lblMsg.Text = "XML GENERADO CORRECTAMENTE"
                Me.lblMsg.Visible = True
            End If

            oConta = Nothing

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
        Return bResultado
    End Function

    Private Sub DesplegarTiposSolicitud()
        Const sProcedure As String = "DesplegarTiposSolicitud"
        Try
            Me.cboTipoSolicitud.Items.AddRange(New String() {"AF - Acto de Fiscalización", "FC - Fiscalización Compulsa", "DE - Devolución", "CO - Compensación"})
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

#End Region

End Class