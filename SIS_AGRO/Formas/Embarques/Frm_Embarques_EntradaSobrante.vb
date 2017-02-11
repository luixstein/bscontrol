Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_Embarques_EntradaSobrante
    Private oArticulos As New Class_CatArticulos
    Private oBultosEmpacados As New Class_Embarques_BultosEmpacados
    'Dim oElemento As New Class_Embarques_BultosEmpacados
    Private Estado As enumEstados

    Private Enum enumEstados
        NUEVO
        CONSULTA
    End Enum

#Region "Opciones"
    Private Sub tsbNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Me.Grabar() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEliminar.Click
        If Me.Eliminar() = True Then
            Me.Inicializa()
            Me.Cambia_Estado(enumEstados.NUEVO)
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos de objetos"
#Region "Eventos"
    Private Sub Frm_Embarques_EntradaSobrante_Proveedor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DesplegarEmpaques()

        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub
#End Region

#Region "Eventos Genericos"

    Private Sub txtCodigoArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProducto.KeyDown
        Dim sText As String
        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = Me.oArticulos.BusquedaVisualProductosAgricolas_PorDescripcion
                If txtLEN(sText) = True Then Me.txtProducto.Text = sText
            Case Keys.Enter
                If txtLEN(Me.txtProducto.Text) = False Then
                    Me.lblArticulo.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.oArticulos = New Class_CatArticulos(Me.txtProducto.Text)
                If Me.oArticulos.Existe = False Then
                    Me.lblArticulo.Text = "" : GoTo Buscar : Exit Sub
                End If

                Me.lblArticulo.Text = Me.oArticulos.Descripcion
                Me.txtCantidad.Focus()
        End Select
    End Sub

    Private Sub txtFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolio.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.Consultar()
                Me.CboEmpaque.Focus()
        End Select
    End Sub

    Private Sub txtTextoKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolio.KeyPress, txtCantidad.KeyPress, dtpFecha.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolio.KeyPress, txtCantidad.KeyPress, txtProducto.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboEmpaque.KeyPress, dtpFecha.KeyPress, txtFolio.KeyPress, txtCantidad.KeyPress ', txtCodigoArticulo.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub CboEmpaque_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboEmpaque.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                Me.txtProducto.Focus()
        End Select
    End Sub

    Private Sub txtCantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                Me.tsbGrabar.PerformClick()
        End Select
    End Sub

    Private Sub DtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        If Me.Estado = enumEstados.NUEVO Then
            If Me.dtpFecha.Value > Now Then
                Me.dtpFecha.Value = Now
            ElseIf Me.dtpFecha.Value < Now.Date Then
                Me.dtpFecha.Value = CDate(Format(Me.dtpFecha.Value, Now.Year & "-" & Now.Month & "-" & Now.Day - 1 & " " & Now.Hour & ":" & Now.Minute & ":" & Now.Second))
            Else
                Me.dtpFecha.Value = Now
            End If
        End If
    End Sub
#End Region

#End Region

#Region "Métodos y procedimientos"

    Private Sub Inicializa()
        Me.CboEmpaque.SelectedIndex = 0
        Me.txtFolio.Text = CodigoSiguiente.ToString
        Me.dtpFecha.Value = Date.Now
        Me.CboEmpaque.SelectedIndex = 0
        Me.txtProducto.Text = ""
        Me.lblArticulo.Text = ""
        Me.txtCantidad.Text = ""

        Me.CodigoSiguiente()
    End Sub

    Private Sub DesplegarEmpaques()
        Dim oElementos As New Class_CatEmpaques
        With Me.CboEmpaque
            .DisplayMember = "NOMBRE_EMPAQUE"
            .ValueMember = "CODIGO_EMPAQUE"
            Dim dView As New Data.DataView(oElementos.ObtenerElementos)
            ' dView.Sort = "NOMBRE_EMPAQUE"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Me.Estado = pEstado

        Select Case Me.Estado
            Case enumEstados.NUEVO
                Me.tssLabelEstado.Text = "Agregando nuevo bulto empacado"
                Me.tsbNuevo.Enabled = True
                Me.tsbGrabar.Enabled = True
                Me.tsbEliminar.Enabled = False

                Me.txtFolio.Enabled = True
                Me.CboEmpaque.Enabled = True
                Me.txtProducto.Enabled = True
                Me.txtCantidad.Enabled = True
                Me.dtpFecha.Enabled = True

                If Me.Visible = True Then
                    Me.txtFolio.Focus()
                End If

            Case enumEstados.CONSULTA
                Me.tssLabelEstado.Text = "Consulta"
                Me.tsbNuevo.Enabled = True
                Me.tsbGrabar.Enabled = False
                Me.tsbEliminar.Enabled = True

                Me.txtFolio.Enabled = False
                Me.CboEmpaque.Enabled = False
                Me.txtProducto.Enabled = False
                Me.txtCantidad.Enabled = False
                Me.dtpFecha.Enabled = False

        End Select
        Application.DoEvents()
    End Sub

    Function Grabar() As Boolean

        Dim Grabado As Boolean = False

        If MsgBox("Desea grabar una entrada por " & Me.txtCantidad.Text & " bultos del producto " & Me.lblArticulo.Text & " ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then
            Exit Function
        End If

        If Me.Validar() = False Then
            Exit Function
        End If

        If Plaza.ValidarPeriodoTrabajo(Me.dtpFecha.Value) = False Then
            Exit Function
        End If

        Try
            With Me.oBultosEmpacados
                .ID_EMB_BULTOS_EMPACADOS = CInt(valorNumerico(Me.txtFolio.Text))
                .FECHA = Me.dtpFecha.Value
                .CODIGO_EMPAQUE = Me.CboEmpaque.SelectedValue.ToString
                .CODIGO_ARTICULO = Me.txtProducto.Text
                .CANTIDAD_ENTRADA = valorNumerico(Me.txtCantidad.Text)
                '.FOLIO_PALET_ORIGEN = ""
                '.FOLIO_PALET_ARMADO = ""
                '.ES_POR_ENTRADA_SOBRANTE = "1"

                If .Insertar() = False Then
                    MsgBox("Error al tratar de grabar la entrada de producto.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                End If
                'Me.txtFolio.Text = Me.oBultosEmpacados.ID_EMB_BULTOS_EMPACADOS

                Grabar = True
                If Grabar = True Then
                    MsgBox("Entrada grabada satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try
    End Function

    Private Function Consultar() As Boolean
        Dim sEmbarque As Integer = CInt(valorNumerico(Me.txtFolio.Text))
        Me.Inicializa()
        Try
            Me.oBultosEmpacados = New Class_Embarques_BultosEmpacados(sEmbarque)

            If Me.oBultosEmpacados.Existe = False Then
                Me.Cambia_Estado(enumEstados.NUEVO)
                Me.txtFolio.Enabled = False
                Exit Function
            Else
                'Me.dtpFecha.Value = Me.oBultosEmpacados.FECHA 'Se cambio al final de la consulta para que pasara por Cambia_Estado y el ValueChanged del DtpFecha no cambiara la fecha despues de consultarlo
                Me.txtFolio.Text = Me.oBultosEmpacados.ID_EMB_BULTOS_EMPACADOS.ToString
                Me.CboEmpaque.SelectedValue = Me.oBultosEmpacados.CODIGO_EMPAQUE
                Me.txtProducto.Text = Me.oBultosEmpacados.CODIGO_ARTICULO
                Me.oArticulos = New Class_CatArticulos(Me.oBultosEmpacados.CODIGO_ARTICULO)
                Me.lblArticulo.Text = oArticulos.DESCRIPCION.ToUpper
                Me.txtCantidad.Text = Me.oBultosEmpacados.CANTIDAD_ENTRADA.ToString
                'Me.TxtPeso.Text=Me.oBultosEmpacados.
            End If

            Consultar = True
            Me.Cambia_Estado(enumEstados.CONSULTA)
            Me.dtpFecha.Value = Me.oBultosEmpacados.FECHA
            Me.txtFolio.Enabled = False

        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try
    End Function

    Private Function Eliminar() As Boolean
        If MsgBox("Desea eliminar esta entrada ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Eliminar") = MsgBoxResult.Yes Then
            If txtLEN(Me.oBultosEmpacados.FOLIO_PALET_ORIGEN) = True Then
                MsgBox("La entrada fue generada por un palet, no es posible eliminarla directamente.", MsgBoxStyle.Information, Me.Text)
                Exit Function
            End If
            If Me.oBultosEmpacados.Eliminar() = True Then
                MsgBox("La entrada fue eliminada con éxito.", MsgBoxStyle.Information, Me.Text)
            Else
                MsgBox("La entrada no puede ser eliminado.")
                Me.Estado = enumEstados.CONSULTA
                Exit Function
            End If
        End If
        Eliminar = True
    End Function

    Public Function CodigoSiguiente() As Integer
        Dim sql As New Class_find("SELECT MAX(ID_EMB_BULTOS_EMPACADOS) FROM EMB_BULTOS_EMPACADOS")
        If sql.Result1 = "" Then
            CodigoSiguiente = 1
        Else
            CodigoSiguiente = CType(sql.Result1, Integer) + 1
        End If
    End Function

    Private Function Validar() As Boolean
        Try
            If txtLEN(Me.txtProducto.Text) = True Then
                If oArticulos.Existe = False Then
                    MsgBox("El producto seleccionado no existe, favor de revisar", MsgBoxStyle.Exclamation, "Validación")
                    Me.CboEmpaque.Focus()
                    Exit Function
                Else
                    Me.lblArticulo.Text = oArticulos.Descripcion
                    Dim sql As New Class_find("SELECT CANTIDAD_BULTOS_POR_PALET FROM VW_CAT_PRODUCTOS_AGRICOLAS Where CODIGO_ARTICULO='" & Me.txtProducto.Text & "' ")
                    If sql.Result1 = "" Then
                        MsgBox("El producto debe ser agrícola.", MsgBoxStyle.Exclamation, Me.Text)
                        Me.txtProducto.Focus()
                        Exit Function
                    ElseIf txtLEN(Me.txtCantidad.Text) = True Then
                        'If valorNumerico(Me.txtCantidad.Text) > valorNumerico(sql.Result1) Then
                        '    If MsgBox("La cantidad del sobrante es mayor al del palet. Desea guardar el sobrante de todas formas ? ", MsgBoxStyle.YesNo, "Validar") = MsgBoxResult.No Then
                        '        Me.txtCantidad.Focus()
                        '        Exit Function
                        '    Else
                        '        Dim sql1 As New Class_find("SELECT 1 FROM EMB_BULTOS_EMPACADOS WHERE CODIGO_EMPAQUE='" & Me.CboEmpaque.SelectedValue.ToString & "' AND CODIGO_ARTICULO='" & Me.txtProducto.Text & "' " & _
                        '                                   "AND ES_POR_ENTRADA_SOBRANTE_PRODUCCION='1' AND FOLIO_PALET_ARMADO IS NULL")
                        '        If sql1.Result1 = "1" Then
                        '            MsgBox("Ya existe un sobrante del mismo producto agricola que no se ha usado en un palet, no es posible agregar otro.", MsgBoxStyle.Exclamation, "Validar")
                        '            Me.txtProducto.Focus()
                        '            Exit Function
                        '        End If
                        '    End If
                        'End If
                    Else
                        MsgBox("Capture una cantidad válida.", MsgBoxStyle.Exclamation, Me.Text)
                        Me.txtCantidad.Focus()
                        Exit Function
                    End If
                End If
            End If

            Validar = True
        Catch ex As Exception
            HandleError(Me.Name, "Validar", ex)
        End Try
    End Function
#End Region

End Class