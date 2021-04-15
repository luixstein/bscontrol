Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Catalogo_Participacion_Socios
    Private oParticipacion As New Class_CatParticipacionSocios

#Region "Campos"

#Region "Campos ligados a la tabla"

#End Region

#Region "Campos públicos"

#End Region

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

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"

#End Region

#Region "Propiedades de campos ligados a la tabla"

#End Region

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

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

#End Region

#End Region

#Region "Columnas Grid"
    Private iGyCodigoUsuarioSocio As Integer = 1
    Private iGyNombreSocio As Integer = 2
    Private iGyCantidad As Integer = 3
    Private iGyPorcentajeParticipacion As Integer = 4
    Private iGyBorrar As Integer = 5
#End Region

#Region "Constructor y destructor"
    'Inicializa al objeto.
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Try
            Me.msgElemento = "Fórmula"
            Me.msgElementos = "Fórmulas"
            Me.Run = False
            Estado = enumEstados.CONSULTA
            Me.Cambia_Estado()
            Me.InicializaElemento()
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
        Me.Estado = enumEstados.NUEVO
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Estado = enumEstados.EDICION
        Me.Cambia_Estado()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Me.CalculaPorcentajes() = False Then
            Return
        End If

        Me.Totales()

        If Me.Validar() = False Then
            Return
        End If

        Dim sMsg As String = ""
        sMsg = "Deseas grabar los socios del artículo " & Me.LblNombreArticulo.Text & " ?"

        If MsgBox(sMsg, CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo), MsgBoxStyle), Me.Text) = MsgBoxResult.Yes Then
            Me.Grabar()
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "Métodos y procedimientos"
    Private Sub Refrescar()
        'Me.DesplegarElementos()
    End Sub

    Private Sub Cambia_Estado()
        Try
            Select Case Me.Estado
                Case enumEstados.NUEVO
                    Me.gBoxInformacion.Enabled = True
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True

                    Me.TxtCodigoArticulo.Enabled = True
                    Me.TxtCantidad.Enabled = True
                    Me.Grid1.Locked = False

                    Me.InicializaElemento()

                Case enumEstados.EDICION
                    Me.gBoxInformacion.Enabled = True
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True

                    Me.TxtCodigoArticulo.Enabled = True
                    Me.TxtCantidad.Enabled = True
                    Me.Grid1.Locked = False
                    Me.Grid1.Rows = Me.Grid1.Rows + 1

            End Select
            Application.DoEvents()
        Catch ex As Exception
            HandleError(Me.Name, "Cambia_Estado", ex)
        End Try
    End Sub

    Private Sub InicializaElemento()
        Me.TxtCodigoArticulo.Text = ""
        Me.LblNombreArticulo.Text = ""
        Me.TxtCantidad.Text = ""
        Me.InicializaGrid()
    End Sub

    Private Sub Consultar(ByVal sCodigoArticulo As String)
        Try

            With Me.oParticipacion

                Me.InicializaGrid()

                'Consulta datos detalle
                Dim dTabla As DataTable = .ObtenerDetalle(sCodigoArticulo)
                Me.Grid1.AutoRedraw = False
                Me.Grid1.Rows = 1 'Trae dos porque en docs nuevos se pone un row en blanco, y si se dejan aqui dos agrega a partir del 3 y queda un hueco
                For Each dRow As DataRow In dTabla.Rows
                    Me.Grid1.AddItem(dRow("CODIGO_USUARIO_SOCIO").ToString & Chr(9) & dRow("NOMBRE_SOCIO").ToString & Chr(9) & dRow("CANTIDAD").ToString & Chr(9) & _
                                     dRow("PORCENTAJE_PARTICIPACION").ToString & Chr(9) & "0" & Chr(9)) '0 es para la columna borrar
                Next

                Me.TxtCantidad.Text = FG_Grid_SumaCol(Me.Grid1, CShort(Me.iGyCantidad)).ToString

                If Me.Grid1.Rows = 1 Then
                    Me.Estado = enumEstados.NUEVO
                    Me.Grid1.Rows = 2
                Else
                    Me.Estado = enumEstados.EDICION
                End If

                Me.FormateaGrid()

            End With

        Catch ex As Exception
            HandleError(Me.Name, "LlenaElemento", ex)
        End Try
    End Sub

    Private Sub Grabar()
        Dim Grabado As Boolean = False
        Dim i As Integer, msg As String = ""

        Try
            With Me.oParticipacion

                .CODIGO_ARTICULO = Me.TxtCodigoArticulo.Text

                'Graba los socios
                For i = 1 To Me.Grid1.Rows - 1
                    If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigoUsuarioSocio).Text) = True Then
                        oParticipacion = New Class_CatParticipacionSocios

                        .CODIGO_USUARIO_SOCIO = CInt(Me.Grid1.Cell(i, Me.iGyCodigoUsuarioSocio).Text)
                        .CANTIDAD = valorNumericoD(Me.Grid1.Cell(i, Me.iGyCantidad).Text)
                        .PORCENTAJE_PARTICIPACION = valorNumericoD(Me.Grid1.Cell(i, Me.iGyPorcentajeParticipacion).Text)

                        If .Grabar(Me.Grid1.Cell(i, Me.iGyBorrar).Text) = False Then
                            MsgBox("Error al tratar de grabar el socio ", MsgBoxStyle.Exclamation, Me.Text)
                            Exit Sub
                        End If

                    End If
                Next

                MsgBox("Embarques grabados satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
                Me.Estado = enumEstados.EDICION
                Me.Cambia_Estado()

            End With
        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
            Me.Cambia_Estado()
        End Try
    End Sub

    Private Function Validar() As Boolean
        Dim bResultado As Boolean = False
        Dim sinElementos As Boolean
        Dim TotalCantidad As Decimal = 0
        Dim TotalPorcentaje As Decimal = 0

        Try

            If txtLEN(Me.TxtCodigoArticulo.Text) = False Then
                MsgBox("Asígne un código de artículo final.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCodigoArticulo.Focus()
                Return bResultado
            End If

            If valorNumericoD(Me.TxtCantidad.Text) = 0 Then
                MsgBox("Capture una cantidad total de artículo para repartir.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCantidad.Focus()
                Return bResultado
            End If

            If Me.Grid1.Rows < 2 Then 'No deberia entrar a esta condicion
                MsgBox("El artículo debe tener al menos un socio.", MsgBoxStyle.Exclamation, Me.Text)
                Me.Grid1.Rows = 2
                Me.Grid1.Cell(1, Me.iGyCodigoUsuarioSocio).SetFocus()
                Return bResultado
            End If

            sinElementos = True
            For i As Integer = 1 To Me.Grid1.Rows - 1
                If Me.Grid1.Cell(i, Me.iGyBorrar).Text = "0" AndAlso txtLEN(Me.Grid1.Cell(i, Me.iGyCodigoUsuarioSocio).Text) = True Then
                    sinElementos = False
                    Exit For
                End If
            Next

            If sinElementos = True Then
                MsgBox("El artículo debe tener al menos un socio.", MsgBoxStyle.Exclamation, Me.Text)
                Me.Grid1.Cell(1, Me.iGyCodigoUsuarioSocio).SetFocus()
                Return bResultado
            End If

            For i As Integer = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigoUsuarioSocio).Text) = True And Me.Grid1.Cell(i, Me.iGyBorrar).Text = "0" Then
                    For z As Integer = i + 1 To Me.Grid1.Rows - 1
                        If Me.Grid1.Cell(i, Me.iGyCodigoUsuarioSocio).Text = Me.Grid1.Cell(z, Me.iGyCodigoUsuarioSocio).Text Then
                            MsgBox("El socio del renglon " & z & " esta repetido.", MsgBoxStyle.Exclamation, Me.Text)
                            Return bResultado
                        End If
                    Next

                    If valorNumericoD(Me.Grid1.Cell(i, Me.iGyCantidad).Text) = 0 Then
                        MsgBox("La cantdad de participación del socio del renglón " & i & " debe ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
                        Return bResultado
                    End If

                    If valorNumericoD(Me.Grid1.Cell(i, Me.iGyPorcentajeParticipacion).Text) = 0 Then
                        MsgBox("El porcentaje de participación del socio del renglón " & i & " debe ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
                        Return bResultado
                    End If

                    'TotalCantidad = TotalCantidad + valorNumericoD(Me.Grid1.Cell(i, Me.iGyCantidad).Text)
                    'TotalPorcentaje = TotalPorcentaje + Math.Round(CDec(Me.Grid1.Cell(i, Me.iGyPorcentajeParticipacion).Text), 2, MidpointRounding.ToEven) 'CDec(Me.Grid1.Cell(i, Me.iGyPorcentajeParticipacion).Text) 

                End If
            Next

            If Math.Round(valorNumericoD(Me.LblCantidadTotal.Text), 2, MidpointRounding.ToEven) <> Math.Round(valorNumericoD(Me.TxtCantidad.Text), 2, MidpointRounding.ToEven) Then 'If TotalCantidad <> valorNumericoD(Me.TxtCantidad.Text) Then
                MsgBox("La suma de las cantidades de los socios debe ser igual a la caputada para el artículo.", MsgBoxStyle.Exclamation, Me.Text)
                Return bResultado
            End If

            If Math.Round(valorNumericoD(Me.LblPorcentajeTotal.Text), 2, MidpointRounding.ToEven) <> 100 Then 'If TotalPorcentaje <> 100 Then
                MsgBox("La suma de los porcentajes de participación de los socios debe ser igual a 100.", MsgBoxStyle.Exclamation, Me.Text)
                Return bResultado
            End If

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, "Validar", ex)
        End Try
        Return bResultado
    End Function

    Private Sub InicializaGrid()
        Try
            Me.Grid1.DataSource = Nothing
            FG_Grid_Limpiar(Me.Grid1)
            Me.Grid1.Rows = 2
            Me.FormateaGrid()
        Catch ex As Exception
            HandleError(Me.Text, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        With Me.Grid1
            .AutoRedraw = False
            .Cols = 6
            .DisplayFocusRect = False
            .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
            .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
            .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat
            .GridColor = Color.FromArgb(148, 190, 231)

            .Cell(0, Me.iGyCodigoUsuarioSocio).Text = "Cod usuario socio"
            .Cell(0, Me.iGyNombreSocio).Text = "Nombre socio"
            .Cell(0, Me.iGyCantidad).Text = "Cantidad"
            .Cell(0, Me.iGyPorcentajeParticipacion).Text = "% participación"
            .Cell(0, Me.iGyBorrar).Text = "Borrar"

            .Column(Me.iGyPorcentajeParticipacion).Mask = FlexCell.MaskEnum.Numeric
            .Column(Me.iGyPorcentajeParticipacion).DecimalLength = 2
            .Column(Me.iGyPorcentajeParticipacion).Alignment = FlexCell.AlignmentEnum.RightCenter

            .Column(Me.iGyCantidad).Mask = FlexCell.MaskEnum.Numeric
            .Column(Me.iGyCantidad).DecimalLength = 4
            .Column(Me.iGyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

            .Column(Me.iGyNombreSocio).Locked = True
            .Column(Me.iGyPorcentajeParticipacion).Locked = True
            .Column(Me.iGyBorrar).Locked = True

            .Column(Me.iGyCodigoUsuarioSocio).Width = 50
            .Column(Me.iGyNombreSocio).Width = 350
            .Column(Me.iGyCantidad).Width = 100
            .Column(Me.iGyPorcentajeParticipacion).Width = 50

            .Column(Me.iGyCodigoUsuarioSocio).Visible = False
            .Column(Me.iGyBorrar).Visible = False

            .AutoRedraw = True
            .Refresh()
        End With
    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim Columna As Integer, Renglon As Integer
            Dim sCodigoUsuario As String, dCantidad As Double
            Dim oUsuarios As Class_sisUsuarios
            Dim i As Integer

            Columna = Me.Grid1.Selection.FirstCol
            Renglon = Me.Grid1.Selection.FirstRow
            sCodigoUsuario = Me.Grid1.Cell(Renglon, Me.iGyCodigoUsuarioSocio).Text
            dCantidad = valorNumerico(Me.Grid1.Cell(Renglon, Me.iGyCantidad).Text)

            Select Case e.KeyCode
                Case Keys.Enter

                    Select Case Columna
                        Case Me.iGyNombreSocio
                            If txtLEN(sCodigoUsuario) = False Then
                                GoTo BuscaUsuario
                            End If
LlenaLinea:
                            oUsuarios = New Class_sisUsuarios(CInt(sCodigoUsuario))
                            If oUsuarios.Existe = False Then
                                GoTo BuscaUsuario
                            End If

                            For i = 1 To Me.Grid1.Rows - 1
                                If Me.Grid1.Cell(i, Me.iGyCodigoUsuarioSocio).Text = sCodigoUsuario And i <> Renglon And Me.Grid1.Cell(i, Me.iGyBorrar).Text = "0" Then
                                    MsgBox("Ya existe ese socio en el renglón " & i, MsgBoxStyle.Exclamation, Me.Text)
                                    Exit Sub
                                End If
                            Next

                            Me.Grid1.Cell(Renglon, Me.iGyNombreSocio).Text = oUsuarios.Nombre_Usuario

                            Me.Grid1.Cell(Renglon, iGyBorrar).Text = "0"

                        Case Me.iGyCantidad
                            If dCantidad <= 0 Then
                                MsgBox("La cantidad de participación debe de ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
                                Me.Grid1.Cell(Renglon, Me.iGyCantidad).SetFocus()
                                Exit Sub
                            End If

                            If valorNumericoD(Me.TxtCantidad.Text) = 0 Then
                                MsgBox("Capture la cantidad total del artículo.", MsgBoxStyle.Exclamation, Me.Text)
                                Me.TxtCantidad.Focus()
                                Exit Sub
                            End If

                            Me.Grid1.Cell(Renglon, Me.iGyPorcentajeParticipacion).Text = ((dCantidad / valorNumericoD(Me.TxtCantidad.Text)) * 100).ToString
                            Me.Totales()

                            If txtLEN(Me.Grid1.Cell(Me.Grid1.Rows - 1, Me.iGyCodigoUsuarioSocio).Text) Then
                                Me.Grid1.Rows = Me.Grid1.Rows + 1
                            End If

                            Me.Grid1.Cell(Renglon + 1, Me.iGyCodigoUsuarioSocio).SetFocus()

                    End Select

                Case Keys.F6

                    Select Case Columna
                        Case Me.iGyNombreSocio
                            If e.KeyCode = Keys.F6 Then
BuscaUsuario:
                                oUsuarios = New Class_sisUsuarios
                                sCodigoUsuario = oUsuarios.BusquedaVisual_PorDescripcion()

                                If txtLEN(sCodigoUsuario) = True Then

                                    For i = 1 To Me.Grid1.Rows - 1
                                        If Me.Grid1.Cell(i, Me.iGyCodigoUsuarioSocio).Text = sCodigoUsuario And i <> Renglon And Me.Grid1.Cell(i, Me.iGyBorrar).Text = "0" Then
                                            MsgBox("Ya existe ese socio en el renglón " & i, MsgBoxStyle.Exclamation, Me.Text)
                                            Exit Sub
                                        End If
                                    Next

                                    Me.Grid1.Cell(Renglon, Me.iGyCodigoUsuarioSocio).Text = sCodigoUsuario
                                    Me.Grid1.Cell(Renglon, Me.iGyNombreSocio).Text = oUsuarios.Nombre_Usuario

                                    GoTo LlenaLinea
                                End If
                            End If

                    End Select

                Case Keys.F8, Keys.Delete
                    If Me.Estado = enumEstados.EDICION Then
                        If txtLEN(Me.Grid1.Cell(Renglon, Me.iGyCodigoUsuarioSocio).Text) Then
                            Me.Grid1.Cell(Renglon, Me.iGyBorrar).Text = "1" 'El renglon queda pendiente para eliminarse al grabar
                            Me.Grid1.Row(Renglon).Visible = False
                        End If

                    ElseIf Me.Estado = enumEstados.NUEVO Then
                        Me.Grid1.Selection.DeleteByRow()
                        If Me.Grid1.Rows = 1 Then Me.Grid1.Rows = 2
                    End If

                    Me.CalculaPorcentajes()
                    Me.Totales()

            End Select

        Catch ex As Exception
            HandleError(Me.Name, "GestionaGrid", ex)
        End Try
    End Sub

    Private Function CalculaPorcentajes() As Boolean
        Try
            If valorNumerico(Me.TxtCantidad.Text) = 0 Then
                MsgBox("Capture la cantidad de artículo total.", MsgBoxStyle.Exclamation, Me.Text)
                Me.TxtCantidad.Focus()
                Return False
            End If

            For i As Integer = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigoUsuarioSocio).Text) Then
                    Me.Grid1.Cell(i, Me.iGyPorcentajeParticipacion).Text = ((valorNumerico(Me.Grid1.Cell(i, Me.iGyCantidad).Text) / valorNumerico(Me.TxtCantidad.Text)) * 100).ToString
                End If
            Next

            Return True
        Catch ex As Exception
            HandleError(Me.Name, "CalculaPorcentajes", ex)
        End Try
    End Function

    Private Sub Totales()
        Dim TotalCantidad As Decimal = 0, TotalPorcentaje As Decimal = 0
        Try
            'Total cantidad
            For i As Integer = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigoUsuarioSocio).Text) = True And Me.Grid1.Cell(i, Me.iGyBorrar).Text = "0" Then
                    TotalCantidad = TotalCantidad + valorNumericoD(Me.Grid1.Cell(i, Me.iGyCantidad).Text)
                End If
            Next

            'Total porcentaje
            For i As Integer = 1 To Me.Grid1.Rows - 1
                If txtLEN(Me.Grid1.Cell(i, Me.iGyCodigoUsuarioSocio).Text) = True And Me.Grid1.Cell(i, Me.iGyBorrar).Text = "0" Then
                    TotalPorcentaje = TotalPorcentaje + valorNumericoD(Me.Grid1.Cell(i, Me.iGyPorcentajeParticipacion).Text) 'Math.Round(valorNumericoD(Me.Grid1.Cell(i, Me.iGyPorcentajeParticipacion).Text), 2, MidpointRounding.ToEven)
                End If
            Next

            Me.LblCantidadTotal.Text = Math.Round(TotalCantidad, 2, MidpointRounding.ToEven).ToString
            Me.LblPorcentajeTotal.Text = Math.Round(TotalPorcentaje, 2, MidpointRounding.ToEven).ToString

        Catch ex As Exception
            HandleError(Me.Name, "Totales", ex)
        End Try
    End Sub
#End Region

#Region "Eventos de objetos"
#Region "Eventos de la lista de elementos"

#End Region

#Region "Eventos Genericos"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoArticulo.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub TxtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantidad.KeyPress
        txtSoloNumerosDecimales(e, Me.TxtCantidad.Text)
        txtNoBeep(e)
    End Sub

    Private Sub txt_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoArticulo.KeyDown
        If e.KeyCode = Keys.Return Then
            txtTAB(e)
        End If
    End Sub

    Private Sub txtCantidad_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCantidad.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.Grid1.Cell(1, Me.iGyNombreSocio).SetFocus()
        End If
    End Sub

#End Region

#Region "Keydown específicos"
    Private Sub txtCodigoArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigoArticulo.KeyDown
        Dim sText As String
        Dim oArticulo As New Class_CatArticulos

        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                sText = oArticulo.BusquedaVisual_PorDescripcion
                If txtLEN(sText) = True Then
                    Me.TxtCodigoArticulo.Text = sText
                End If

            Case Keys.Enter

                If txtLEN(Me.TxtCodigoArticulo.Text) = True Then
                    oArticulo = New Class_CatArticulos(Me.TxtCodigoArticulo.Text)

                    If oArticulo.Existe = False Then
                        Me.LblNombreArticulo.Text = "" : GoTo Buscar : Exit Sub
                    End If

                    Me.LblNombreArticulo.Text = oArticulo.DESCRIPCION
                    Me.Consultar(Me.TxtCodigoArticulo.Text)

                    If Me.Estado = enumEstados.NUEVO Then
                        Me.Grid1.Cell(1, Me.iGyCodigoUsuarioSocio).SetFocus()
                    End If

                End If

        End Select
    End Sub

    Private Sub Grid1_KeyDown(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid1.KeyDown
        Me.GestionaGrid(e)
    End Sub
#End Region

#Region "Validating específicos"

#End Region

#End Region

End Class