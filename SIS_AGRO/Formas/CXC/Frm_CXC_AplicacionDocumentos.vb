Option Strict On

Public Class Frm_CXC_AplicacionDocumentos

    Private oBancosCXC As New Class_Bancos_CXC
    Private oCXCAfectaDocumentos As New Class_CXC_Afecta_Documentos
    Private oDocumentoCXC As New Class_CXC_Global

    Private Enum enumEstados
        NUEVO
        GRABADO
        APLICADO
        CANCELADO
    End Enum

    Private Estado As enumEstados

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
        Me.txtFolio.Focus()
    End Sub

    Private Sub tsbAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAplicar.Click
        If Me.Aplicar = True Then
            If Me.rbAnticipo.Checked = True Then
                Me.Consultar()
            Else
                Me.ConsultarDescuentoDevolucion()
            End If
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos"
    Private Sub Frm_CXC_Aplicacion_Documentos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub txtFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolio.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
                If Me.rbAnticipo.Checked = True Then
busca_an:
                    sText = BusquedaVisualAnticiposCXC()
                    If sText.Length > 0 Then
                        Me.txtFolio.Text = sText
                        Me.Consultar()
                    End If
                Else
busca_dd:
                    sText = BusquedaVisualDescuentosDevolucionesCXC()
                    If sText.Length > 0 Then
                        Me.txtFolio.Text = sText
                        Me.ConsultarDescuentoDevolucion()
                    End If
                End If

            Case Keys.Return
                If Me.rbAnticipo.Checked = True Then
                    If Me.txtFolio.Text.Length = 0 Then
                        GoTo busca_an : Exit Sub
                    End If
                    If Me.Consultar() = True Then
                        Me.txtReferencia.Focus()
                    End If
                Else
                    If Me.txtFolio.Text.Length = 0 Then
                        GoTo busca_dd : Exit Sub
                    End If
                    If Me.ConsultarDescuentoDevolucion() = True Then
                        Me.txtReferencia.Focus()
                    End If
                End If

        End Select
    End Sub

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolio.KeyPress, txtReferencia.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtReferencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReferencia.KeyDown
        Dim sText As String
        Dim oVenta As New Class_Ventas_Global

        Select Case e.KeyCode
            Case Keys.F6
busca:
                sText = BusquedaVisualDocumentosVentas()
                If txtLEN(sText) = True Then
                    Me.txtReferencia.Text = sText
                    oVenta = New Class_Ventas_Global(sText, False)
                    Me.txtSaldo.Text = FormatImporteContable(oVenta.SALDO)
                    Me.dtpFechaVenta.Value = oVenta.FECHA
                End If

            Case Keys.Return
                If txtLEN(Me.txtReferencia.Text) = False Then GoTo busca : Exit Sub
                Me.tsbAplicar.PerformClick()
        End Select
    End Sub

#End Region

#Region "Procedimientos y funciones"

    Private Sub Inicializa()
        Try
            Me.txtFolio.Text = ""
            Me.lblEstatus.Text = "N"
            Me.dtpFecha.Value = Now
            Me.txtCodigoDocumento.Text = ""
            Me.lblNombreDocumento.Text = ""
            Me.txtImporte.Text = ""
            Me.txtCodigoCliente.Text = ""
            Me.lblNombreProveedor.Text = ""
            Me.txtReferencia.Text = ""
            Me.txtReferencia2.Text = ""
            Me.txtConcepto.Text = ""
            Me.txtSaldo.Text = ""
            Me.dtpFechaVenta.Value = Now
        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Try
            Me.Estado = pEstado

            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.txtFolio.Enabled = True
                    Me.txtReferencia.Enabled = False
                    Me.tsbAplicar.Enabled = False
                    Me.tssElaboro.Visible = False
                    Me.tssLabelEstado.Text = "Estado: aplicando documento de CXC"

                    Me.txtFolio.Enabled = True
                    Me.gbDocumento.Enabled = True

                Case enumEstados.GRABADO
                    Me.txtFolio.Enabled = False
                    Me.txtReferencia.Enabled = True
                    Me.tsbAplicar.Enabled = True
                    Me.tssElaboro.Visible = True
                    Me.txtReferencia.Focus()
                    Me.tssLabelEstado.Text = "Estado: aplicando documento de CXC"

                Case enumEstados.APLICADO, enumEstados.CANCELADO
                    Me.txtFolio.Enabled = False
                    Me.txtReferencia.Enabled = False
                    Me.tsbAplicar.Enabled = False
                    Me.tssElaboro.Visible = True
                    Me.tssLabelEstado.Text = "Estado: Consultando documento de CXC"

            End Select
        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim sFolio As String = Me.txtFolio.Text

        Try
            Me.oBancosCXC = New Class_Bancos_CXC

            Me.oBancosCXC.ConsultarCXC(sFolio)
            If txtLEN(Me.oBancosCXC.FOLIO_CXC) = False Then
                Me.Inicializa()
                Me.txtFolio.Enabled = False
                Return False
            End If

            Me.txtFolio.Enabled = False
            Me.gbDocumento.Enabled = False

            Me.txtFolio.Text = oBancosCXC.FOLIO_CXC
            Me.lblEstatus.Text = oBancosCXC.ESTATUS_CXC
            Me.dtpFecha.Value = oBancosCXC.FECHA
            Me.txtCodigoDocumento.Text = oBancosCXC.CODIGO_DOCUMENTO
            Me.lblNombreDocumento.Text = oBancosCXC.Nombre_Formato
            Me.txtImporte.Text = FormatImporteContable(oBancosCXC.TOTAL)
            Me.txtCodigoCliente.Text = oBancosCXC.CODIGO_Cliente
            Me.lblNombreProveedor.Text = oBancosCXC.NOMBRE_Cliente
            Me.txtReferencia.Text = oBancosCXC.FOLIO_REFERENCIA
            Me.txtReferencia2.Text = oBancosCXC.FOLIO_BANCO
            Me.txtConcepto.Text = oBancosCXC.CONCEPTO1
            'Me.tssElaboro.Text = oBancosCXC.NOMBRE_USUARIO_GRABO

            If txtLEN(oBancosCXC.FOLIO_REFERENCIA) = True Then
                Dim oVenta = New Class_Ventas_Global(oBancosCXC.FOLIO_REFERENCIA, False)
                Me.txtSaldo.Text = FormatImporteContable(oVenta.SALDO).ToString
                Me.dtpFechaVenta.Value = oVenta.FECHA
            End If

            bResultado = True

            Me.tssElaboro.Text = "Elaboró : " & Me.oBancosCXC.NOMBRE_USUARIO_GRABO
            'If Me.oBancosCXC.ESTATUS = "C" Then
            '    Me.tssCancelo.Text = "Canceló : " & Me.oBancosCXC.NOMBRE_USUARIO_CANCELO & " el : " & Format(Me.oBancosCXC.FECHA_DE_CANCELACION_SERVIDOR, "dd-MMM-yyyy hh:mm tt")
            'End If

            Me.GestionaCambioEstado()

        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try

        Return bResultado
    End Function

    Private Function ConsultarDescuentoDevolucion() As Boolean
        Dim bResultado As Boolean = False
        Dim sFolio As String = Me.txtFolio.Text

        Try
            Me.oDocumentoCXC = New Class_CXC_Global(sFolio)

            If Me.oDocumentoCXC.Existe = False Then
                Me.Inicializa()
                Return False
            End If

            With Me.oDocumentoCXC
                Me.txtFolio.Text = .FOLIO_CXC
                Me.lblEstatus.Text = .ESTATUS_CXC
                Me.dtpFecha.Value = .FECHA
                Me.txtCodigoDocumento.Text = .CODIGO_DOCUMENTO
                Me.lblNombreDocumento.Text = ""
                Me.txtImporte.Text = FormatImporteContable(.TOTAL)
                Me.txtCodigoCliente.Text = .CODIGO_CLIENTE
                Me.lblNombreProveedor.Text = .NOMBRE_CLIENTE
                Me.txtReferencia.Text = .FOLIO_REFERENCIA
                Me.txtReferencia2.Text = .FOLIO_REFERENCIA_USUARIO
                Me.txtConcepto.Text = .CONCEPTO1
                Me.tssElaboro.Text = .NOMBRE_USUARIO_GRABO

                If txtLEN(oBancosCXC.FOLIO_REFERENCIA) = True Then
                    Dim oVenta = New Class_Ventas_Global(.FOLIO_REFERENCIA, False)
                    Me.txtSaldo.Text = FormatImporteContable(oVenta.SALDO).ToString
                    Me.dtpFechaVenta.Value = oVenta.FECHA
                End If

                bResultado = True
            End With

            Me.GestionaCambioEstado()

        Catch ex As Exception
            HandleError(Me.Name, "ConsultarDescuentoDevolucion", ex)
        End Try

        Return bResultado
    End Function

    Private Sub GestionaCambioEstado()
        Select Case Me.lblEstatus.Text
            Case "G"
                Me.Cambia_Estado(enumEstados.GRABADO)
            Case "A"
                Me.Cambia_Estado(enumEstados.APLICADO)
            Case "C"
                Me.Cambia_Estado(enumEstados.CANCELADO)
        End Select
    End Sub

    Private Function BusquedaVisualAnticiposCXC() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de documentos de CXC"
        f.sCampo = "CXC_FOLIO_CXC"
        f.sOrder = "FECHA_CXC"
        f.sTable = "VW_BANCOS_GLOBAL_CON_CXC_GLOBAL"

        f.sQl = "SELECT CXC.CXC_FOLIO_CXC,CXC.CXC_ESTATUS_CXC,CXC.CXC_CODIGO_DOCUMENTO,T.NOMBRE_TIPO_DOCUMENTO,CXC.CXC_TOTAL,CXC.CXC_CODIGO_CLIENTE,CXC.CXC_NOMBRE_CLIENTE,DBO.FN_FECHA_SIN_HORA(CXC.BAN_FECHA) FECHA_CXC " &
                "FROM VW_BANCOS_GLOBAL_CON_CXC_GLOBAL CXC " &
                "INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO T ON(CXC.CXC_CODIGO_DOCUMENTO=T.CODIGO_DOCUMENTO) " &
                "WHERE T.CODIGO_MODULO='CXC' AND CXC.CXC_ESTATUS_CXC='G' AND T.CODIGO_TIPO_DOCUMENTO='PA' AND CXC_CODIGO_PLAZA=" & Usuario.Codigo_Plaza & " AND"

        f.arrayWidthColumns = New Integer() {100, 70, 100, 200, 70, 100, 300, 100}
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Name, "BusquedaVisualAnticiposCXC", ex)
        End Try

        Return Resultado
    End Function

    Private Function BusquedaVisualDescuentosDevolucionesCXC() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de documentos de CXC"
        f.sCampo = "FOLIO_CXC"
        f.sOrder = "FECHA"
        f.sTable = "CXC_GLOBAL"

        f.sQl = "SELECT CXC.FOLIO_CXC,CXC.ESTATUS_CXC,CXC.CODIGO_DOCUMENTO,T.NOMBRE_TIPO_DOCUMENTO,CXC.TOTAL,CXC.CODIGO_CLIENTE,CTE.NOMBRE_CLIENTE,DBO.FN_FECHA_SIN_HORA(CXC.FECHA) FECHA_CXC  " &
                "FROM CXC_GLOBAL CXC " &
                "INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO T ON(CXC.CODIGO_DOCUMENTO=T.CODIGO_DOCUMENTO) " &
                "INNER JOIN CAT_CLIENTES CTE ON(CXC.CODIGO_CLIENTE=CTE.CODIGO_CLIENTE)" &
                "WHERE T.CODIGO_MODULO='CXC' AND CXC.ESTATUS_CXC='G' AND T.CODIGO_TIPO_DOCUMENTO<>'PA' AND CXC.CODIGO_PLAZA=" & Usuario.Codigo_Plaza & " AND "

        f.arrayWidthColumns = New Integer() {100, 70, 100, 200, 70, 100, 300, 100}

        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Name, "BusquedaVisualDescuentosDevolucionesCXC", ex)
        End Try

        Return Resultado
    End Function

    Private Function BusquedaVisualDocumentosVentas() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de documentos de ventas"
        f.sCampo = "FOLIO_VENTA"
        f.sOrder = "FECHA DESC"
        f.sTable = "VENTA_GLOBAL"
        f.sQl = "SELECT V.FOLIO_VENTA,V.FECHA,V.TOTAL,V.SALDO,V.CODIGO_CLIENTE,C.NOMBRE_CLIENTE,V.ESTATUS_VENTA " &
                "FROM VENTA_GLOBAL V INNER JOIN CAT_CLIENTES C ON(V.CODIGO_CLIENTE=C.CODIGO_CLIENTE) " &
                "WHERE ESTATUS_VENTA='A' AND v.CODIGO_CLIENTE='" & Me.txtCodigoCliente.Text & "' AND V.SALDO>0 AND"

        f.arrayWidthColumns = New Integer() {100, 100, 70, 70, 70, 200}

        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Name, "BusquedaVisualDocumentosVentas", ex)
        End Try

        Return Resultado
    End Function

    Private Function Aplicar() As Boolean
        Dim bResultado As Boolean = False
        Try
            If Me.Validar() = False Then
                Return False
            End If

            Me.oCXCAfectaDocumentos = New Class_CXC_Afecta_Documentos
            With oCXCAfectaDocumentos
                .FOLIO_CXC = Me.txtFolio.Text
                .FOLIO_REFERENCIA = Me.txtReferencia.Text
                .CODIGO_PLAZA = Usuario.Codigo_Plaza
                bResultado = .AplicaDocumentoCXC
            End With
            oCXCAfectaDocumentos = Nothing

            If bResultado = True Then
                MsgBox("Documento : " & Me.txtFolio.Text & " aplicado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            End If
        Catch ex As Exception
            HandleError(Me.Name, "Aplicar", ex)
        End Try
        Return bResultado
    End Function

    Private Function Validar() As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim sDocumento As String, sQl As Class_find

            If Me.txtFolio.TextLength = 0 Then
                MsgBox("Asígne el folio del documento de CXC.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtFolio.Focus()
                Exit Function
            End If

            If Me.txtReferencia.TextLength = 0 Then
                MsgBox("Asígne el folio de la referencia al que aplicara el documento de CXC.", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtReferencia.Focus()
                Exit Function
            End If

            If MsgBox("Desea aplicar el documento CXC : " & Me.txtFolio.Text & " en la referencia : " &
            Me.txtReferencia.Text & " ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                Exit Function
            End If

            sQl = New Class_find("SELECT CODIGO_DOCUMENTO,* FROM CXC_GLOBAL WHERE FOLIO_CXC='" & sReplace(Me.txtFolio.Text) & "'")
            sDocumento = sQl.Result1

            If txtLEN(sDocumento) = False Then
                MsgBox("No se encontró el código del documento.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Function
            End If

            'If Usuario.ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(Me.txtFolio.Text) = False Then
            '    MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para realizar el movimiento.", MsgBoxStyle.Information, Me.Text)
            '    Exit Function
            'End If

            If Me.lblEstatus.Text <> "G" Then
                MsgBox("El documento de CXC debe de estar en estatus de grabado(G).", MsgBoxStyle.Exclamation, Me.Text)
                Me.txtFolio.Focus()
                Exit Function
            End If

            'sQl = New Class_find("SELECT 1,C.TOTAL,P.SALDO FROM CXC_GLOBAL C CROSS JOIN VENTA_GLOBAL P " & _
            '"WHERE C.FOLIO_CXC='" & sReplace(Me.txtFolio.Text) & "' AND P.FOLIO_VENTA='" & sReplace(Me.txtReferencia.Text) & "' AND C.TOTAL>P.SALDO")

            'If txtLEN(sQl.Result1) = True Then
            '    MsgBox("El total del documento de CXC por " & FormatImporteContable(CDbl(sQl.Result2)) & " es mayor que el saldo de la venta por " & FormatImporteContable(CDbl(sQl.Result3)) & ".", _
            '    MsgBoxStyle.Exclamation, Me.Text)
            '    Exit Function
            'End If

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "Aplicar", ex)
        End Try

        Return bResultado
    End Function

#End Region

End Class