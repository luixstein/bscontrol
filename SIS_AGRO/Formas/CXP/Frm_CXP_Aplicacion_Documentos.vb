Option Strict On
Imports System.Data.SqlClient

Public Class Frm_CXP_Aplicacion_Documentos

    Private oBancosCXP As New Class_Bancos_CXP
    Private oCxpAfectaDocumentos As New Class_CXP_Afecta_Documentos

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
            Me.Consultar()
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
busca:
                sText = BusquedaVisualDocumentosCXP()
                If sText.Length > 0 Then
                    Me.txtFolio.Text = sText
                    Me.Consultar()
                End If

            Case Keys.Return
                If Me.txtFolio.Text.Length = 0 Then GoTo busca : Exit Sub
                If Me.Consultar() = True Then
                    Me.txtReferencia.Focus()
                End If

            Case Keys.F7
                sText = BusquedaVisualDocumentosCXP_NombreProveedor()
                If sText.Length > 0 Then
                    Me.txtFolio.Text = sText
                    Me.Consultar()
                End If

        End Select
    End Sub

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolio.KeyPress, txtReferencia.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtReferencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReferencia.KeyDown
        Dim sText As String
        Dim oCompra As New Class_Compras_Global

        Select Case e.KeyCode
            Case Keys.F6
busca:
                sText = BusquedaVisualDocumentosCompra()
                If txtLEN(sText) = True Then
                    Me.txtReferencia.Text = sText
                    Dim Sql = New Class_find("SELECT FECHA,SALDO FROM COMPRA_GLOBAL WHERE FOLIO_COMPRA='" & sText & "'")
                    Me.txtSaldo.Text = FormatImporteContable(CDbl(Sql.Result2)).ToString
                    Me.dtpFechaCompra.Value = CType(Sql.Result1, Date)
                End If

            Case Keys.Return
                If txtLEN(Me.txtReferencia.Text) = False Then GoTo busca : Exit Sub
                Me.tsbAplicar.PerformClick()
        End Select
    End Sub

#End Region

#Region "Procedimientos y funciones"

    Private Sub Inicializa()
        Me.txtFolio.Text = ""
        Me.lblEstatus.Text = "N"
        Me.dtpFecha.Value = Now
        Me.dtpFechaCompra.Value = Now
        Me.txtCodigoDocumento.Text = ""
        Me.lblNombreDocumento.Text = ""
        Me.txtImporte.Text = ""
        Me.txtCodigoProveedor.Text = ""
        Me.lblNombreProveedor.Text = ""
        Me.txtReferencia.Text = ""
        Me.txtReferencia2.Text = ""
        Me.txtConcepto.Text = ""
        Me.txtSaldo.Text = ""
    End Sub

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Me.Estado = pEstado

        Select Case Me.Estado
            Case enumEstados.NUEVO
                Me.txtFolio.Enabled = True
                Me.txtReferencia.Enabled = False
                Me.tsbAplicar.Enabled = False
                Me.tssElaboro.Visible = False
                Me.tssLabelEstado.Text = "Estado: aplicando documento de CXP"

            Case enumEstados.GRABADO
                Me.txtFolio.Enabled = False
                Me.txtReferencia.Enabled = True
                Me.tsbAplicar.Enabled = True
                Me.tssElaboro.Visible = True
                Me.txtReferencia.Focus()
                Me.tssLabelEstado.Text = "Estado: aplicando documento de CXP"

            Case enumEstados.APLICADO, enumEstados.CANCELADO
                Me.txtFolio.Enabled = False
                Me.txtReferencia.Enabled = False
                Me.tsbAplicar.Enabled = False
                Me.tssElaboro.Visible = True
                Me.tssLabelEstado.Text = "Estado: Consultando documento de CXP"

        End Select
    End Sub

    Private Function Consultar() As Boolean
        Dim sFolio As String = Me.txtFolio.Text

        Try
            Me.oBancosCXP = New Class_Bancos_CXP

            Me.oBancosCXP.ConsultarCxp(sFolio)

            If txtLEN(Me.oBancosCXP.FOLIO_CXP) = False Then
                Me.Inicializa()
                Exit Function
            End If

            Me.txtFolio.Text = oBancosCXP.FOLIO_CXP
            Me.lblEstatus.Text = oBancosCXP.ESTATUS_CXP
            Me.dtpFecha.Value = oBancosCXP.FECHA
            Me.txtCodigoDocumento.Text = oBancosCXP.CODIGO_DOCUMENTO
            Me.lblNombreDocumento.Text = oBancosCXP.Nombre_Formato '"NOMBRE_TIPO_DOCUMENTO"
            Me.txtImporte.Text = FormatImporteContable(oBancosCXP.TOTAL)
            Me.txtCodigoProveedor.Text = oBancosCXP.CODIGO_PROVEEDOR
            Me.lblNombreProveedor.Text = oBancosCXP.NOMBRE_PROVEEDOR
            Me.txtReferencia.Text = oBancosCXP.FOLIO_REFERENCIA
            Me.txtReferencia2.Text = oBancosCXP.FOLIO_BANCO
            Me.txtConcepto.Text = oBancosCXP.CONCEPTO1
            'Me.tssElaboro.Text = oBancosCXP.NOMBRE_USUARIO_GRABO

            If txtLEN(oBancosCXP.FOLIO_REFERENCIA) = True Then
                Dim Sql = New Class_find("SELECT FECHA,SALDO FROM COMPRA_GLOBAL WHERE FOLIO_COMPRA='" & oBancosCXP.FOLIO_REFERENCIA.ToString & "'")
                Me.txtSaldo.Text = FormatImporteContable(CDbl(Sql.Result2)).ToString
                Me.dtpFechaCompra.Value = CType(Sql.Result1, Date)
            End If

            Consultar = True

            Me.tssElaboro.Text = "Elaboró : " & Me.oBancosCXP.NOMBRE_USUARIO_GRABO
            'If Me.oBancosCXP.ESTATUS = "C" Then
            '    Me.tssCancelo.Text = "Canceló : " & Me.oBancosCXP.NOMBRE_USUARIO_CANCELO & " el : " & Format(Me.oBancosCXP.FECHA_DE_CANCELACION_SERVIDOR, "dd-MMM-yyyy hh:mm tt")
            'End If

            Me.GestionaCambioEstado()

        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try

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

    Private Function BusquedaVisualDocumentosCXP() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de documentos de CXP"
        f.sCampo = "FOLIO_CXP"
        f.sOrder = "CXP.FECHA DESC"
        f.sTable = "VW_BANCOS_GLOBAL_CON_CXP_GLOBAL"
        f.sQl = "SELECT CXP.FOLIO_CXP,CXP.ESTATUS_CXP,CXP.CODIGO_DOCUMENTO_CXP,T.NOMBRE_TIPO_DOCUMENTO,CXP.TOTAL,CXP.CODIGO_PROVEEDOR,CXP.NOMBRE_PROVEEDOR,DBO.FN_FECHA_SIN_HORA(CXP.FECHA) FECHA_CXP " &
                    "FROM VW_BANCOS_GLOBAL_CON_CXP_GLOBAL CXP " &
                    "INNER JOIN SIS_TIPOS_DOCUMENTOS T ON(CXP.CODIGO_TIPO_DOCUMENTO=T.CODIGO_TIPO_DOCUMENTO) " &
                    "WHERE T.CODIGO_MODULO='CXP' AND CXP.ESTATUS_CXP='G' AND CXP.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " AND "

        f.arrayWidthColumns = New Integer() {100, 70, 100, 200, 70, 100, 300, 100}
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Name, "BusquedaVisualDocumentosCXP", ex)
        End Try
        Return Resultado
    End Function

    Private Function BusquedaVisualDocumentosCXP_NombreProveedor() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de documentos de CXP"
        f.sCampo = "NOMBRE_PROVEEDOR"
        f.sOrder = "CXP.FECHA DESC"
        f.sTable = "VW_BANCOS_GLOBAL_CON_CXP_GLOBAL"
        f.sQl = "SELECT CXP.FOLIO_CXP,CXP.FOLIO_REFERENCIA,CXP.ESTATUS_CXP,CXP.CODIGO_DOCUMENTO_CXP,T.NOMBRE_TIPO_DOCUMENTO,CXP.TOTAL,CXP.CODIGO_PROVEEDOR,CXP.NOMBRE_PROVEEDOR,DBO.FN_FECHA_SIN_HORA(CXP.FECHA) FECHA_CXP " & _
                "FROM VW_BANCOS_GLOBAL_CON_CXP_GLOBAL CXP INNER JOIN SIS_TIPOS_DOCUMENTOS T ON(CXP.CODIGO_TIPO_DOCUMENTO=T.CODIGO_TIPO_DOCUMENTO) WHERE T.CODIGO_MODULO='CXP' AND CXP.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " AND "

        f.arrayWidthColumns = New Integer() {100, 100, 70, 100, 200, 70, 100, 300, 100}

        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Name, "BusquedaVisualDocumentosCXP_NombreProveedor", ex)
        End Try
        Return Resultado
    End Function

    Private Function BusquedaVisualDocumentosCompra() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de documentos de compra"
        f.sCampo = "FOLIO_COMPRA"
        f.sOrder = "FECHA DESC"
        f.sTable = "VW_COMPRA_GLOBAL_EXTENDIDO"
        f.sQl = "SELECT FOLIO_COMPRA,FECHA,TOTAL,SALDO,CODIGO_PROVEEDOR,NOMBRE_PROVEEDOR " & _
                "FROM VW_COMPRA_GLOBAL_EXTENDIDO WHERE AFECTA_CXP='1' AND ESTATUS='A' AND CODIGO_PROVEEDOR='" & Me.txtCodigoProveedor.Text & "' AND CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " AND SALDO>0 AND "

        f.arrayWidthColumns = New Integer() {100, 100, 70, 70, 70, 200}

        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Name, "BusquedaVisualDocumentosCompra", ex)
        End Try
        BusquedaVisualDocumentosCompra = Resultado
    End Function

    Private Function Aplicar() As Boolean

        If Validar() = False Then
            Exit Function
        End If

        Me.oCxpAfectaDocumentos = New Class_CXP_Afecta_Documentos
        With oCxpAfectaDocumentos
            .FOLIO_CXP = Me.txtFolio.Text
            .FOLIO_REFERENCIA = Me.txtReferencia.Text
            .CODIGO_PLAZA = Usuario.Codigo_Plaza
            Aplicar = .AplicaDocumentoCXP
        End With
        oCxpAfectaDocumentos = Nothing

        If Aplicar = True Then
            MsgBox("Documento : " & Me.txtFolio.Text & " aplicado satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
        End If

    End Function

    Private Function Validar() As Boolean

        Dim sDocumento As String, sQl As Class_find

        If Me.txtFolio.TextLength = 0 Then
            MsgBox("Asígne el folio del documento de cxp.", MsgBoxStyle.Exclamation, Me.Text)
            Me.txtFolio.Focus()
            Exit Function
        End If

        If Me.txtReferencia.TextLength = 0 Then
            MsgBox("Asígne el folio de la referencia al que aplicara el documento de cxp.", MsgBoxStyle.Exclamation, Me.Text)
            Me.txtReferencia.Focus()
            Exit Function
        End If

        If MsgBox("Desea aplicar el documento cxp : " & Me.txtFolio.Text & " en la referencia : " & _
        Me.txtReferencia.Text & " ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
            Exit Function
        End If

        sQl = New Class_find("SELECT CODIGO_DOCUMENTO,* FROM CXP_GLOBAL WHERE FOLIO_CXP='" & sReplace(Me.txtFolio.Text) & "'")
        sDocumento = sQl.Result1

        If txtLEN(sDocumento) = False Then
            MsgBox("No se encontró el código del documento.", MsgBoxStyle.Exclamation, Me.Text)
            Exit Function
        End If

        'If Not Usuario.ValidaPermisoDocumento(sDocumento) Then
        '    Exit Function
        'End If

        If Me.lblEstatus.Text <> "G" Then
            MsgBox("El documento de cxp debe de estar en estatus de grabado(G).", MsgBoxStyle.Exclamation, Me.Text)
            Me.txtFolio.Focus()
            Exit Function
        End If

        sQl = New Class_find("SELECT 1,C.TOTAL,P.SALDO FROM CXP_GLOBAL C " & _
                             "CROSS JOIN COMPRA_GLOBAL P " & _
        "WHERE C.FOLIO_CXP='" & sReplace(Me.txtFolio.Text) & "' AND P.FOLIO_COMPRA='" & sReplace(Me.txtReferencia.Text) & "' AND C.TOTAL>P.SALDO")

        'If txtLEN(sQl.Result1) = True Then
        '    MsgBox("El total del documento de cxp por " & FormatImporteContable(sQl.Result2) & " es mayor que el saldo de la compra por " & FormatImporteContable(sQl.Result3) & ".", _
        '    MsgBoxStyle.Exclamation, Me.Text)
        '    Exit Function
        'End If

        Validar = True

    End Function

#End Region

    Private Sub txtFolio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFolio.TextChanged

    End Sub

    Private Sub txtReferencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReferencia.TextChanged

    End Sub
End Class