Option Strict On

Public Class Ventas_CartaPorte

#Region "Campos privados"
    Private FolioVenta As String

    Private Enum enumEstados
        EDITAR
        CONSULTAR
    End Enum

    Private oCartaPorte As New Class_CartaPorte, oVenta As New Class_Ventas_Global
    Private Estado As enumEstados
#End Region

#Region "Columnas grid ubicaciones"
    Private iGyUbTipo As Integer = 1
    Private iGyUbCodigo As Integer = 2
    Private iGyUbNombre As Integer = 3
    Private iGyUbDistanciaRecorrida As Integer = 4
    Private iGyUbFechaHoraSalidaLlegada As Integer = 5
    Private iGyUbDomicilio As Integer = 6
#End Region

#Region "Columnas grid mercancias"
    Private iGyMerBienTransportado As Integer = 1
    Private iGyMerDescripcion As Integer = 2
    Private iGyMerCantidad As Integer = 3
    Private iGyMerClaveUnidad As Integer = 4
    Private iGyMerNombreUnidad As Integer = 5
    Private iGyMerUnidad As Integer = 6
    Private iGyMerPesoEnKG As Integer = 7
#End Region

#Region "Columnas grid figuras de transporte"
    Private iGyFtCodigoFigura As Integer = 1
    Private iGyFtCodigoTipo As Integer = 2
    Private iGyFtNombreTipo As Integer = 3
    Private iGyFtNombreFigura As Integer = 4
    Private iGyFtRFC As Integer = 5
    Private iGyFtLicencia As Integer = 6
    Private iGyFtDomicilio As Integer = 7
#End Region

#Region "Columnas grid partes de transporte"
    Private iGyPtCodigoFigura As Integer = 1
    Private iGyPtNombreFigura As Integer = 2
    Private iGyPtCodigoParte As Integer = 3
    Private iGyPtNombreParte As Integer = 4
#End Region

#Region "Constructor"
    Public Sub New(ByVal sFolioVenta As String)
        InitializeComponent()
        Me.FolioVenta = sFolioVenta
    End Sub
#End Region

#Region "Opciones"
    Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.CambiarEstado(enumEstados.EDITAR)
    End Sub

    Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
        If Me.Grabar() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos de objetos"
    Private Sub Ventas_CartaPorte_Load(sender As Object, e As EventArgs) Handles Me.Load
        Const sProcedure As String = "Ventas_CartaPorte_Load"
        Try
            Me.Inicializa()

            Me.cboTransporteInternacional.Items.AddRange(New Object() {"Sí", "No"})
            Me.GridUbicaciones.ComboBox(Me.iGyUbTipo).Items.AddRange(New Object() {"Salida", "Llegada"})

            Me.oVenta = New Class_Ventas_Global(Me.FolioVenta)

            Me.oCartaPorte = New Class_CartaPorte(Me.FolioVenta)

            If Me.oCartaPorte.Existe = True Then
                Me.Consultar()
            Else
                Me.PrecargarEnBaseFactura()

                If Me.oVenta.TIMBRADO_CFDI = "0" And Me.oVenta.ESTATUS_VENTA = "A" Then
                    Me.CambiarEstado(enumEstados.EDITAR)
                Else
                    Me.CambiarEstado(enumEstados.CONSULTAR)
                End If
            End If

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub txtCodigoUnidadPeso_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoUnidadPeso.KeyDown
        Const sProcedure As String = "txtCodigoUnidadPeso_KeyDown"
        Try
            Dim sText As String, oUnidadSAT As Class_CFD_CatUnidades
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    oUnidadSAT = New Class_CFD_CatUnidades
                    sText = oUnidadSAT.BusquedaVisual_PorDescripcion
                    If txtLEN(sText) = True Then Me.txtCodigoUnidadPeso.Text = sText

                Case Keys.Enter
                    If txtLEN(Me.txtCodigoUnidadPeso.Text) = False Then
                        Me.txtNombreUnidadPeso.Text = "" : GoTo Buscar : Exit Sub
                    End If

                    oUnidadSAT = New Class_CFD_CatUnidades(Me.txtCodigoUnidadPeso.Text)

                    If oUnidadSAT.EXISTE = False Then
                        Me.txtNombreUnidadPeso.Text = "" : GoTo Buscar : Exit Sub
                    Else
                        Me.txtNombreUnidadPeso.Text = oUnidadSAT.NOMBRE_UNIDAD
                    End If

                    'txtTAB(e)
            End Select
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub txtCodigoVehiculo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoVehiculo.KeyDown
        Const sProcedure As String = "txtCodigoVehiculo_KeyDown"
        Try
            Dim sText As String, oVehiculo As Class_CatVehiculos
            Select Case e.KeyCode
                Case Keys.F6
Buscar:
                    oVehiculo = New Class_CatVehiculos
                    sText = oVehiculo.BusquedaVisual_PorDescripcion
                    If txtLEN(sText) = True Then
                        Me.txtCodigoVehiculo.Text = sText
                        GoTo Enter : Return
                    End If

                Case Keys.Enter
                    If txtLEN(Me.txtCodigoVehiculo.Text) = False Then
                        Me.InicializaVehiculo() : GoTo Buscar : Return
                    End If
Enter:
                    oVehiculo = New Class_CatVehiculos(Me.txtCodigoVehiculo.Text)

                    If oVehiculo.Existe = False Then
                        Me.InicializaVehiculo() : GoTo Buscar : Return
                    Else
                        Me.ConsultarVehiculo(oVehiculo)
                    End If

                    Me.txtCodigoRemolque1.Focus()
            End Select
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub txtCodigoRemolque1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoRemolque1.KeyDown
        Const sProcedure As String = "txtCodigoRemolque1_KeyDown"
        Try
            Dim sText As String, oRemolque As Class_CatRemolques
            Select Case e.KeyCode
                Case Keys.F6
F6:
                    oRemolque = New Class_CatRemolques
                    sText = oRemolque.BusquedaVisual_PorDescripcion
                    If txtLEN(sText) = True Then
                        Me.txtCodigoRemolque1.Text = sText
                        GoTo Enter : Return
                    End If

                Case Keys.Enter
                    If txtLEN(Me.txtCodigoRemolque1.Text) = False Then
                        Me.InicializaRemolque1()
                        GoTo F6 : Exit Sub
                    End If
Enter:
                    oRemolque = New Class_CatRemolques(Me.txtCodigoRemolque1.Text)

                    If oRemolque.Existe = False Then
                        Me.InicializaRemolque1() : GoTo F6 : Exit Sub
                    Else
                        Me.ConsultarRemolque1(oRemolque)
                    End If

                    txtTAB(e)
            End Select
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub txtCodigoRemolque2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoRemolque2.KeyDown
        Const sProcedure As String = "txtCodigoRemolque2_KeyDown"
        Try
            Dim sText As String, oRemolque As Class_CatRemolques
            Select Case e.KeyCode
                Case Keys.F6
F6:
                    oRemolque = New Class_CatRemolques
                    sText = oRemolque.BusquedaVisual_PorDescripcion
                    If txtLEN(sText) = True Then
                        Me.txtCodigoRemolque2.Text = sText
                        GoTo Enter : Return
                    End If

                Case Keys.Enter
                    If txtLEN(Me.txtCodigoRemolque2.Text) = False Then
                        Me.InicializaRemolque2()
                        GoTo F6 : Exit Sub
                    End If
Enter:
                    oRemolque = New Class_CatRemolques(Me.txtCodigoRemolque2.Text)

                    If oRemolque.Existe = False Then
                        Me.InicializaRemolque2() : GoTo F6 : Exit Sub
                    Else
                        Me.txtPlacaRemolque2.Text = oRemolque.PLACA
                        Me.txtTipoRemolque2.Text = oRemolque.CODIGO_TIPO_REMOLQUE
                        Dim oTipoRemolque As New Class_CfdiCatTiposRemolques(Me.txtTipoRemolque2.Text)
                        Me.txtNombreTipoRemolque2.Text = oTipoRemolque.NOMBRE_TIPO_REMOLQUE
                    End If

                    txtTAB(e)
            End Select
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub GridUbicaciones_KeyDown(Sender As Object, e As KeyEventArgs) Handles GridUbicaciones.KeyDown
        Me.GestionaGridUbicaciones(e)
    End Sub

    Private Sub GridMercancias_KeyDown(Sender As Object, e As KeyEventArgs) Handles GridMercancias.KeyDown
        Me.GestionaGridMercancias(e)
    End Sub

    Private Sub GridFigurasTransporte_KeyDown(Sender As Object, e As KeyEventArgs) Handles GridFigurasTransporte.KeyDown
        Me.GestionaGridFigurasTransporte(e)
    End Sub

    Private Sub GridPartesTransporte_KeyDown(Sender As Object, e As KeyEventArgs) Handles GridPartesTransporte.KeyDown
        Me.GestionaGridPartesTransporte(e)
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txtKeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoUnidadPeso.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub txtSoloNumerosDecimales_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 'Handles
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosDecimales(e, txt.Text)
        txtNoBeep(e)
    End Sub

    Private Sub txtSoloNumerosEnteros_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoVehiculo.KeyPress, txtCodigoRemolque1.KeyPress, txtCodigoRemolque2.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Const sProcedure As String = "Inicializa"
        Try
            Me.InicializaGridUbicaciones()
            Me.InicializaGridMercancias()
            Me.InicializaGridFigurasTransporte()
            Me.InicializaGridPartesTransporte()

            Me.cboTransporteInternacional.Text = "No"
            Me.txtTotalDistanciaRecorrida.Text = "0.00"
            Me.txtTotalPesoBruto.Text = "0.000"
            Me.txtTotalMercancias.Text = "0"
            Me.txtCodigoUnidadPeso.Text = ""
            Me.txtNombreUnidadPeso.Text = ""

            Me.txtCodigoVehiculo.Text = ""
            Me.txtNombreVehiculo.Text = ""
            Me.txtMarca.Text = ""
            Me.txtAño.Text = ""
            Me.txtPlacaAutotransporte.Text = ""

            Me.txtCodigoAutotransporte.Text = ""
            Me.txtNombreAutotransporte.Text = ""
            Me.txtCodigoPermisoSCT.Text = ""
            Me.txtNumeroPermisoSCT.Text = ""

            Me.txtAseguradoraResponsabilidadCivil.Text = ""
            Me.txtPolizaResposabilidadCivil.Text = ""
            Me.txtPrimaSeguro.Text = ""

            Me.txtCodigoRemolque1.Text = ""
            Me.txtPlacaRemolque1.Text = ""
            Me.txtTipoRemolque1.Text = ""
            Me.txtNombreTipoRemolque1.Text = ""

            Me.txtCodigoRemolque2.Text = ""
            Me.txtPlacaRemolque2.Text = ""
            Me.txtTipoRemolque2.Text = ""
            Me.txtNombreTipoRemolque2.Text = ""

            Me.TabControl1.SelectedIndex = 0

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub CambiarEstado(ByVal Estado As enumEstados)
        Const sProcedure As String = "CambiarEstado"
        Try
            Me.Estado = Estado

            Select Case Me.Estado
                Case enumEstados.EDITAR
                    Me.tsbNuevo.Enabled = True
                    Me.tsbGrabar.Enabled = True

                    Me.GridUbicaciones.Locked = False
                    Me.GridMercancias.Locked = False
                    Me.GridFigurasTransporte.Locked = False
                    Me.GridPartesTransporte.Locked = False

                    Me.cboTransporteInternacional.Enabled = False
                    Me.txtCodigoUnidadPeso.Enabled = True
                    Me.txtCodigoVehiculo.Enabled = True
                    Me.txtCodigoRemolque1.Enabled = True
                    Me.txtCodigoRemolque2.Enabled = True

                Case enumEstados.CONSULTAR
                    Me.tsbNuevo.Enabled = False
                    Me.tsbGrabar.Enabled = False

                    Me.GridUbicaciones.Locked = True
                    Me.GridMercancias.Locked = True
                    Me.GridFigurasTransporte.Locked = True
                    Me.GridPartesTransporte.Locked = True

                    Me.cboTransporteInternacional.Enabled = False 'Bloqueado siempre de momento
                    Me.txtCodigoUnidadPeso.Enabled = False
                    Me.txtCodigoVehiculo.Enabled = False
                    Me.txtCodigoRemolque1.Enabled = False
                    Me.txtCodigoRemolque2.Enabled = False

                    'Me.TabControl1.TabPages(1).Enabled = False
            End Select

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Function PrecargarEnBaseFactura() As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "PrecargarEnBaseFactura"
        Try
            'iGyMerBienTransportado,iGyMerDescripcion,iGyMerCantidad,iGyMerClaveUnidad,iGyMerNombreUnidad,iGyMerUnidad,iGyMerPesoEnKG
            Dim dtMercancias As DataTable = Me.oVenta.ObtenerDetalleParaCartaPorte()
            Me.GridMercancias.AutoRedraw = False
            Me.GridMercancias.Rows = 1
            For Each dRow As DataRow In dtMercancias.Rows
                Me.GridMercancias.AddItem(
                        dRow("CODIGO_PRODUCTO_SERVICIO").ToString & Chr(9) & dRow("DESCRIPCION").ToString & Chr(9) & dRow("CANTIDAD").ToString & Chr(9) & dRow("CODIGO_UNIDAD").ToString & Chr(9) & dRow("NOMBRE_UNIDAD").ToString & Chr(9) &
                        dRow("UNIDAD_VENTA").ToString & Chr(9) & dRow("CANTIDAD").ToString & Chr(9)) 'No tenemos PESO_EN_KG pero igualamos de momento con la cantidad
            Next

            Me.Totaliza()

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        Finally
            Me.GridMercancias.AutoRedraw = True : Me.GridMercancias.Refresh()
        End Try

        Return bResultado
    End Function

    Private Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "Consultar"
        Try
            With Me.oCartaPorte
                Me.cboTransporteInternacional.Text = .TRANSPORTE_INTERNACIONAL

                Me.txtTotalDistanciaRecorrida.Text = Format(.TOTAL_DISTANCIA_RECORRIDA, "###,##0.00")
                Me.txtTotalPesoBruto.Text = Format(.PESO_BRUTO_TOTAL, "###,##0.000")
                Me.txtTotalMercancias.Text = Format(.NUMERO_TOTAL_MERCANCIAS, "###,##0")

                Me.txtCodigoUnidadPeso.Text = .CODIGO_UNIDAD_PESO
                Me.txtNombreUnidadPeso.Text = New Class_CFD_CatUnidades(.CODIGO_UNIDAD_PESO).NOMBRE_UNIDAD

                Me.txtCodigoVehiculo.Text = .CODIGO_VEHICULO.ToString
                Dim oVehiculo As New Class_CatVehiculos(.CODIGO_VEHICULO.ToString)
                Me.ConsultarVehiculo(oVehiculo)

                Me.txtCodigoRemolque1.Text = .CODIGO_REMOLQUE_1
                If txtLEN(Me.txtCodigoRemolque1.Text) = True Then
                    Dim oRemolque1 As New Class_CatRemolques(.CODIGO_REMOLQUE_1)
                    Me.ConsultarRemolque1(oRemolque1)
                End If

                Me.txtCodigoRemolque2.Text = .CODIGO_REMOLQUE_2
                If txtLEN(Me.txtCodigoRemolque2.Text) = True Then
                    Dim oRemolque2 As New Class_CatRemolques(.CODIGO_REMOLQUE_2)
                    Me.ConsultarRemolque2(oRemolque2)
                End If

                'iGyUbTipo,iGyUbCodigo,iGyUbNombre,iGyUbDistanciaRecorrida,iGyUbFechaHoraSalidaLlegada,iGyUbDomicilio
                Dim dtUbicaciones As DataTable = Me.oCartaPorte.ObtenerDetalleUbicaciones
                Me.GridUbicaciones.AutoRedraw = False
                Me.GridUbicaciones.Rows = 1 'Trae dos porque en docs nuevos se pone un row en blanco, y si se dejan aqui dos agrega a partir del 3 y queda un hueco
                For Each dRow As DataRow In dtUbicaciones.Rows
                    Me.GridUbicaciones.AddItem(
                        dRow("TIPO_UBICACION").ToString & Chr(9) & dRow("CODIGO_UBICACION").ToString & Chr(9) & dRow("NOMBRE_REMITENTE_DESTINATARIO").ToString & Chr(9) & dRow("DISTANCIA_RECORRIDA").ToString & Chr(9) &
                        Format(CDate(dRow("FECHA_HORA_SALIDA_LLEGADA").ToString), "dd/MM/yyyy HH:mm:ss") & Chr(9) & dRow("DOMICILIO_COMPLETO").ToString & Chr(9))
                Next

                'iGyMerBienTransportado,iGyMerDescripcion,iGyMerCantidad,iGyMerClaveUnidad,iGyMerNombreUnidad,iGyMerUnidad,iGyMerPesoEnKG
                Dim dtMercancias As DataTable = Me.oCartaPorte.ObtenerDetalleMercancias
                Me.GridMercancias.AutoRedraw = False
                Me.GridMercancias.Rows = 1 'Trae dos porque en docs nuevos se pone un row en blanco, y si se dejan aqui dos agrega a partir del 3 y queda un hueco
                For Each dRow As DataRow In dtMercancias.Rows
                    Me.GridMercancias.AddItem(
                        dRow("CODIGO_PRODUCTO_SERVICIO").ToString & Chr(9) & dRow("DESCRIPCION").ToString & Chr(9) & dRow("CANTIDAD").ToString & Chr(9) & dRow("CODIGO_UNIDAD").ToString & Chr(9) & dRow("NOMBRE_UNIDAD").ToString & Chr(9) &
                        dRow("UNIDAD").ToString & Chr(9) & dRow("PESO_EN_KG").ToString & Chr(9))
                Next

                'iGyFtCodigoFigura,iGyFtCodigoTipo,iGyFtNombreTipo,iGyFtNombreFigura,iGyFtRFC,iGyFtLicencia,iGyFtDomicilio
                Dim dtFiguras As DataTable = Me.oCartaPorte.ObtenerDetalleFiguras
                Me.GridFigurasTransporte.AutoRedraw = False
                Me.GridFigurasTransporte.Rows = 1 'Trae dos porque en docs nuevos se pone un row en blanco, y si se dejan aqui dos agrega a partir del 3 y queda un hueco
                For Each dRow As DataRow In dtFiguras.Rows
                    Me.GridFigurasTransporte.AddItem(
                        dRow("CODIGO_FIGURA_TRANSPORTE").ToString & Chr(9) & dRow("CODIGO_TIPO_FIGURA_TRANSPORTE").ToString & Chr(9) & dRow("NOMBRE_TIPO_FIGURA_TRANSPORTE").ToString & Chr(9) & dRow("NOMBRE_FIGURA_TRANSPORTE").ToString & Chr(9) &
                        dRow("RFC").ToString & Chr(9) & dRow("NUMERO_LICENCIA").ToString & Chr(9) & dRow("DOMICILIO_COMPLETO").ToString & Chr(9))
                Next

                'iGyPtCodigoFigura,iGyPtNombreFigura, iGyPtCodigoParte, iGyPtNombreParte
                Dim dtPartesFiguras As DataTable = Me.oCartaPorte.ObtenerDetallePartesFiguras
                Me.GridPartesTransporte.AutoRedraw = False
                Me.GridPartesTransporte.Rows = 1 'Trae dos porque en docs nuevos se pone un row en blanco, y si se dejan aqui dos agrega a partir del 3 y queda un hueco
                For Each dRow As DataRow In dtPartesFiguras.Rows
                    Me.GridPartesTransporte.AddItem(
                        dRow("CODIGO_FIGURA_TRANSPORTE").ToString & Chr(9) & dRow("NOMBRE_FIGURA_TRANSPORTE").ToString & Chr(9) & dRow("CODIGO_PARTE_TRANSPORTE").ToString & Chr(9) & dRow("NOMBRE_PARTE_TRANSPORTE").ToString & Chr(9))
                Next
            End With

            If Me.oVenta.TIMBRADO_CFDI = "0" And Me.oVenta.ESTATUS_VENTA = "A" Then
                Me.CambiarEstado(enumEstados.EDITAR)
            Else
                Me.CambiarEstado(enumEstados.CONSULTAR)
            End If

            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        Finally
            Me.GridUbicaciones.AutoRedraw = True : Me.GridUbicaciones.Refresh()
            Me.GridMercancias.AutoRedraw = True : Me.GridMercancias.Refresh()
            Me.GridFigurasTransporte.AutoRedraw = True : Me.GridFigurasTransporte.Refresh()
            Me.GridPartesTransporte.AutoRedraw = True : Me.GridPartesTransporte.Refresh()
        End Try

        Return bResultado
    End Function

    Private Function ConsultarVehiculo(ByVal oVehiculo As Class_CatVehiculos) As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "ConsultarVehiculo"
        Try
            Me.txtNombreVehiculo.Text = oVehiculo.NOMBRE_VEHICULO
            Me.txtMarca.Text = oVehiculo.MARCA
            Me.txtAño.Text = oVehiculo.ANIO
            Me.txtPlacaAutotransporte.Text = oVehiculo.PLACA
            Me.txtCodigoAutotransporte.Text = oVehiculo.CODIGO_AUTOTRANSPORTE
            Dim oAutoTransporte As New Class_CfdiCatConfigAutotransporte(oVehiculo.CODIGO_AUTOTRANSPORTE)
            Me.txtNombreAutotransporte.Text = oAutoTransporte.NOMBRE_AUTOTRANSPORTE
            Me.txtCodigoPermisoSCT.Text = oVehiculo.CODIGO_PERMISO_SCT
            Me.txtNumeroPermisoSCT.Text = oVehiculo.NUMERO_PERMISO_SCT
            Me.txtAseguradoraResponsabilidadCivil.Text = oVehiculo.NOMBRE_ASEGURADORA_RESPONSABILIDAD_CIVIL
            Me.txtPolizaResposabilidadCivil.Text = oVehiculo.POLIZA_RESPONSABILIDAD_CIVIL
            Me.txtPrimaSeguro.Text = oVehiculo.PRIMA_SEGURO

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ConsultarRemolque1(ByVal oRemolque As Class_CatRemolques) As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "ConsultarRemolque1"
        Try
            Me.txtPlacaRemolque1.Text = oRemolque.PLACA
            Me.txtTipoRemolque1.Text = oRemolque.CODIGO_TIPO_REMOLQUE
            Dim oTipoRemolque As New Class_CfdiCatTiposRemolques(Me.txtTipoRemolque1.Text)
            Me.txtNombreTipoRemolque1.Text = oTipoRemolque.NOMBRE_TIPO_REMOLQUE

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ConsultarRemolque2(ByVal oRemolque As Class_CatRemolques) As Boolean
        Dim bResultado As Boolean = False
        Const sProcedure As String = "ConsultarRemolque2"
        Try
            Me.txtPlacaRemolque2.Text = oRemolque.PLACA
            Me.txtTipoRemolque2.Text = oRemolque.CODIGO_TIPO_REMOLQUE
            Dim oTipoRemolque As New Class_CfdiCatTiposRemolques(Me.txtTipoRemolque1.Text)
            Me.txtNombreTipoRemolque2.Text = oTipoRemolque.NOMBRE_TIPO_REMOLQUE

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function Grabar() As Boolean
        Const sProcedure As String = "Grabar"
        Dim bResultado As Boolean = False

        Try
            Dim sListaUbicaciones As String = "", sListaMercancias As String = "", sListaFigurasTransporte As String = "", sListaPartesTransporte As String = ""

            Me.Totaliza()

            If Me.Validar = False Then
                Return False
            End If

            'CODIGO_UBICACION,TIPO_UBICACION,FECHA_HORA_SALIDA_LLEGADA,DISTANCIA_RECORRIDA|
            '"dd/MM/yyyy HH:mm:ss" asi se consulta en el grid la fecha
            For i = 1 To Me.GridUbicaciones.Rows - 1
                If txtLEN(Me.GridUbicaciones.Cell(i, Me.iGyUbCodigo).Text) = True Then
                    sListaUbicaciones &= Me.GridUbicaciones.Cell(i, Me.iGyUbCodigo).Text & "," & Me.GridUbicaciones.Cell(i, Me.iGyUbTipo).Text & "," &
                                        Format(CDate(Me.GridUbicaciones.Cell(i, Me.iGyUbFechaHoraSalidaLlegada).Text), "yyyy-dd-MM HH:mm:ss") & "," & Me.GridUbicaciones.Cell(i, Me.iGyUbDistanciaRecorrida).Text & "|"
                End If
            Next

            'CODIGO_PRODUCTO_SERVICIO,DESCRIPCION,CANTIDAD,CODIGO_UNIDAD,UNIDAD,PESO_EN_KG,VALOR_MERCANCIA,CODIGO_MONEDA_SAT| nota las últimas 2 de momento se pasan en 0 y en blanco respectivamente.
            For i = 1 To Me.GridMercancias.Rows - 1
                If txtLEN(Me.GridMercancias.Cell(i, Me.iGyMerBienTransportado).Text) = True Then
                    sListaMercancias &= Me.GridMercancias.Cell(i, Me.iGyMerBienTransportado).Text & "," & Me.GridMercancias.Cell(i, Me.iGyMerDescripcion).Text & "," & Me.GridMercancias.Cell(i, Me.iGyMerCantidad).Text & "," &
                                        Me.GridMercancias.Cell(i, Me.iGyMerClaveUnidad).Text & "," & Me.GridMercancias.Cell(i, Me.iGyMerUnidad).Text & "," & Me.GridMercancias.Cell(i, Me.iGyMerPesoEnKG).Text & ",0,|"
                End If
            Next

            'CODIGO_FIGURA_TRANSPORTE|
            For i = 1 To Me.GridFigurasTransporte.Rows - 1
                If txtLEN(Me.GridFigurasTransporte.Cell(i, Me.iGyFtCodigoFigura).Text) = True Then
                    sListaFigurasTransporte &= Me.GridFigurasTransporte.Cell(i, Me.iGyFtCodigoFigura).Text & "|"
                End If
            Next

            'CODIGO_FIGURA_TRANSPORTE,CODIGO_PARTE_TRANSPORTE|
            For i = 1 To Me.GridPartesTransporte.Rows - 1
                If txtLEN(Me.GridPartesTransporte.Cell(i, Me.iGyPtCodigoFigura).Text) = True AndAlso txtLEN(Me.GridPartesTransporte.Cell(i, Me.iGyPtCodigoParte).Text) = True Then
                    sListaPartesTransporte &= Me.GridPartesTransporte.Cell(i, Me.iGyPtCodigoFigura).Text & "," & Me.GridPartesTransporte.Cell(i, Me.iGyPtCodigoParte).Text & "|"
                End If
            Next

            With Me.oCartaPorte
                '.ID_CFDI_CARTA_PORTE_GLOBAL = 0
                .FOLIO_VENTA = Me.FolioVenta
                .VERSION = "2.0"
                .TRANSPORTE_INTERNACIONAL = Me.cboTransporteInternacional.Text
                .ENTRADA_SALIDA_MERCANCIA = "" 'Forzado en blanco de momento
                .CODIGO_PAIS_SAT = "" 'Forzado en blanco de momento
                .CODIGO_TRANSPORTE = "" 'Forzado en blanco de momento
                .TOTAL_DISTANCIA_RECORRIDA = valorNumericoD(Me.txtTotalDistanciaRecorrida.Text)
                .PESO_BRUTO_TOTAL = valorNumericoD(Me.txtTotalPesoBruto.Text)
                .CODIGO_UNIDAD_PESO = Me.txtCodigoUnidadPeso.Text
                .NUMERO_TOTAL_MERCANCIAS = CInt(Me.txtTotalMercancias.Text)
                .CODIGO_VEHICULO = CInt(Me.txtCodigoVehiculo.Text)
                .CODIGO_REMOLQUE_1 = Me.txtCodigoRemolque1.Text
                .CODIGO_REMOLQUE_2 = Me.txtCodigoRemolque2.Text
                .LISTA_UBICACIONES = sListaUbicaciones
                .LISTA_MERCANCIAS = sListaMercancias
                .LISTA_FIGURAS_TRANSPORTE = sListaFigurasTransporte
                .LISTA_FIGURAS_PARTES_TRANSPORTE = sListaPartesTransporte

                If Me.oCartaPorte.Existe = True Then
                    bResultado = .Grabar("ACTUALIZAR")
                Else
                    bResultado = .Grabar("INSERTAR")
                End If

            End With
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function Validar() As Boolean
        Const sProcedure As String = "Validar"
        Dim bResultado As Boolean = False
        Try
            Dim i As Integer = 0, j As Integer = 0

            Me.TabControl1.SelectedIndex = 0 'Por si alguna validación no pasa al menos pase al tab page donde se hizo la validación
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Validar que hayan puesto 2 ubicaciones, una origen y destino y la de destino validar que distancia recorrida>0
            Dim oUbicacion As Class_CatCfdiUbicaciones, bUbicacionOrigenEncontrada As Boolean = False, bUbicacionDestinoEncontrada As Boolean = False

            For i = 1 To Me.GridUbicaciones.Rows - 1
                If txtLEN(Me.GridUbicaciones.Cell(i, Me.iGyUbCodigo).Text) = False Then
                    Continue For
                End If

                Dim iCodigoUbicacion As Integer = CInt(Me.GridUbicaciones.Cell(i, Me.iGyUbCodigo).Text)

                oUbicacion = New Class_CatCfdiUbicaciones(iCodigoUbicacion)
                If oUbicacion.Existe = False Then
                    MsgBox("La ubicación del renglón #" & i.ToString & " no existe.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If oUbicacion.TIPO_UBICACION = "Origen" Then
                    bUbicacionOrigenEncontrada = True

                    If valorNumericoD(Me.GridUbicaciones.Cell(i, Me.iGyUbDistanciaRecorrida).Text) <> 0 Then
                        MsgBox("La distancia recorrida de la ubicación del renglón #" & i.ToString & " debe ser cero al ser tipo origen.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                ElseIf oUbicacion.TIPO_UBICACION = "Destino" Then
                    bUbicacionDestinoEncontrada = True

                    If valorNumericoD(Me.GridUbicaciones.Cell(i, Me.iGyUbDistanciaRecorrida).Text) <= 0 Then
                        MsgBox("La distancia recorrida de la ubicación del renglón #" & i.ToString & " debe ser mayor que cero al ser tipo destino.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                End If

                If IsDate(Me.GridUbicaciones.Cell(i, Me.iGyUbFechaHoraSalidaLlegada).Text) = False Then
                    MsgBox("Falta indicar la fecha/hora del renglón #" & i.ToString & " de ubicaciones.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If
            Next

            If bUbicacionOrigenEncontrada = False Then
                MsgBox("Debe de indicar al menos una ubicación tipo origen.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If bUbicacionDestinoEncontrada = False Then
                MsgBox("Debe de indicar al menos una ubicación tipo destino.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If valorNumericoD(Me.txtTotalDistanciaRecorrida.Text) <= 0 Then
                MsgBox("La distancia recorrida total debe ser mayor que cero.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Validar que hayan puesto al menos una mercancia con cantidad, codigo_unidad,unidad y peso_kg>0
            Dim bHayMercancias As Boolean = False

            For i = 1 To Me.GridMercancias.Rows - 1
                Dim sBienTransportado As String = Me.GridMercancias.Cell(i, Me.iGyMerBienTransportado).Text

                If txtLEN(sBienTransportado) = False Then
                    Continue For
                End If

                Dim oBienTransportado As New Class_CFD_CatProductosServicios(sBienTransportado)

                If oBienTransportado.EXISTE = False Then
                    MsgBox("La mercancía del renglón #" & i.ToString & " no existe.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If valorNumericoD(Me.GridMercancias.Cell(i, Me.iGyMerCantidad).Text) <= 0 Then
                    MsgBox("La cantidad de la mercancía del renglón #" & i.ToString & " debe ser mayor que cero.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If txtLEN(Me.GridMercancias.Cell(i, Me.iGyMerClaveUnidad).Text) = False Then
                    MsgBox("La clave de la unidad de la mercancía del renglón #" & i.ToString & " no debe quedar en blanco.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                Else
                    Dim oUnidad As New Class_CFD_CatUnidades(Me.GridMercancias.Cell(i, Me.iGyMerClaveUnidad).Text)

                    If oUnidad.EXISTE = False Then
                        MsgBox("La clave de la unidad de la mercancía del renglón #" & i.ToString & " no existe.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                End If

                If txtLEN(Me.GridMercancias.Cell(i, Me.iGyMerUnidad).Text) = False Then
                    MsgBox("La unidad de la mercancía del renglón #" & i.ToString & " no debe quedar en blanco.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                If valorNumericoD(Me.GridMercancias.Cell(i, Me.iGyMerPesoEnKG).Text) <= 0 Then
                    MsgBox("El peso en Kg de la mercancía del renglón #" & i.ToString & " debe ser mayor que cero.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                bHayMercancias = True
            Next

            If bHayMercancias = False Then
                MsgBox("Debe de indicar al menos una mercancía.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If valorNumericoD(Me.txtTotalMercancias.Text) <= 0 Then
                MsgBox("Debe de indicar al menos una mercancía.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If valorNumericoD(Me.txtTotalPesoBruto.Text) <= 0 Then
                MsgBox("El peso bruto total debe ser mayor que cero.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If txtLEN(Me.txtCodigoUnidadPeso.Text) = False Then
                MsgBox("Debe indicar la unidad de peso(va abajo de las mercancias).", MsgBoxStyle.Exclamation, sProcedure)
                Me.txtNombreUnidadPeso.Text = "" : Me.txtCodigoUnidadPeso.Focus() : Return False
            Else
                Dim oUnidadSAT As New Class_CFD_CatUnidades(Me.txtCodigoUnidadPeso.Text)
                If oUnidadSAT.EXISTE = False Then
                    MsgBox("La unidad de peso indicada no existe.", MsgBoxStyle.Exclamation, sProcedure)
                    Me.txtNombreUnidadPeso.Text = "" : Me.txtCodigoUnidadPeso.Focus() : Return False
                End If
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.TabControl1.SelectedIndex = 1 'Por si alguna validación no pasa al menos pase al tab page donde se hizo la validación

            'Validar vehículo
            If txtLEN(Me.txtCodigoVehiculo.Text) = False Then
                MsgBox("Debe indicar el vehículo usado.", MsgBoxStyle.Exclamation, sProcedure)
                Me.InicializaVehiculo() : Return False
            End If

            Dim oVehiculo = New Class_CatVehiculos(Me.txtCodigoVehiculo.Text)
            If oVehiculo.Existe = False Then
                MsgBox("El vehículo indicado no existe.", MsgBoxStyle.Exclamation, sProcedure)
                Me.InicializaVehiculo() : Me.txtCodigoVehiculo.Focus() : Return False
            End If

            If txtLEN(Me.txtCodigoPermisoSCT.Text) = False Then
                MsgBox("El vehículo indicado no tiene el código de permiso de la SCT.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If txtLEN(Me.txtNumeroPermisoSCT.Text) = False Then
                MsgBox("El vehículo indicado no tiene el número de permiso de la SCT.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If txtLEN(Me.txtCodigoAutotransporte.Text) = False Then
                MsgBox("El vehículo indicado no tiene el código de autotransporte.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If txtLEN(Me.txtPlacaAutotransporte.Text) = False Then
                MsgBox("El vehículo indicado no tiene número de placa.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If txtLEN(Me.txtAño.Text) = False Then
                MsgBox("El vehículo indicado no tiene el año.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If txtLEN(Me.txtAseguradoraResponsabilidadCivil.Text) = False Then
                MsgBox("El vehículo indicado no tiene la aseguradora.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            If txtLEN(Me.txtAseguradoraResponsabilidadCivil.Text) = False Then
                MsgBox("El vehículo indicado no tiene el número de póliza de seguro.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            Dim oAutoTransporte As New Class_CfdiCatConfigAutotransporte(oVehiculo.CODIGO_AUTOTRANSPORTE)

            Select Case oAutoTransporte.REMOLQUE
                Case "0" 'Significa que no lleva ningún remolque
                    If txtLEN(Me.txtCodigoRemolque1.Text) = True Or txtLEN(Me.txtCodigoRemolque1.Text) = True Then
                        MsgBox("El vehículo indicado no soporta que se le indiquen remolques.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If

                Case "1" 'Significa que debe llevar al menos el remolque #1 y el #2 de forma opcional
                    If txtLEN(Me.txtCodigoRemolque1.Text) = False Then
                        MsgBox("El vehículo indicado debe llevar al menos el remolque #1.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.InicializaRemolque1() : Me.txtCodigoRemolque1.Focus() : Return False
                    End If

                    Dim oRemolque1 As New Class_CatRemolques(Me.txtCodigoRemolque1.Text)
                    If oRemolque1.Existe = False Then
                        MsgBox("El remolque #1 indicado no existe.", MsgBoxStyle.Exclamation, sProcedure)
                        Me.InicializaRemolque1() : Me.txtCodigoRemolque1.Focus() : Return False
                    End If

                    If txtLEN(Me.txtCodigoRemolque2.Text) = True Then
                        Dim oRemolque2 As New Class_CatRemolques(Me.txtCodigoRemolque2.Text)
                        If oRemolque2.Existe = False Then
                            MsgBox("El remolque #2 indicado no existe.", MsgBoxStyle.Exclamation, sProcedure)
                            Me.InicializaRemolque2() : Me.txtCodigoRemolque2.Focus() : Return False
                        End If
                    End If

                    If Me.txtCodigoRemolque1.Text = Me.txtCodigoRemolque2.Text Then
                        MsgBox("Los remolque #1 y #2 no pueden ser los mismos.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If

                Case "0,1" 'Significa que puede o no llevar remolque.
                    If txtLEN(Me.txtCodigoRemolque1.Text) = True Then
                        Dim oRemolque1 As New Class_CatRemolques(Me.txtCodigoRemolque1.Text)
                        If oRemolque1.Existe = False Then
                            MsgBox("El remolque #1 indicado no existe.", MsgBoxStyle.Exclamation, sProcedure)
                            Me.InicializaRemolque1() : Me.txtCodigoRemolque1.Focus() : Return False
                        End If
                    End If

                    If txtLEN(Me.txtCodigoRemolque2.Text) = True Then
                        Dim oRemolque2 As New Class_CatRemolques(Me.txtCodigoRemolque2.Text)
                        If oRemolque2.Existe = False Then
                            MsgBox("El remolque #2 indicado no existe.", MsgBoxStyle.Exclamation, sProcedure)
                            Me.InicializaRemolque2() : Me.txtCodigoRemolque2.Focus() : Return False
                        End If
                    End If

                    If Me.txtCodigoRemolque1.Text = Me.txtCodigoRemolque2.Text Then
                        MsgBox("Los remolque #1 y #2 no pueden ser los mismos.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
            End Select

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Validar que hayan puesto al menos una figura de transporte tipo operador y si es operador que tenga licencia
            Dim bHayFiguraTipoOperador As Boolean = False

            For i = 1 To Me.GridFigurasTransporte.Rows - 1
                Dim sCodigoFigura As String = Me.GridFigurasTransporte.Cell(i, Me.iGyFtCodigoFigura).Text

                If txtLEN(sCodigoFigura) = False Then
                    Continue For
                End If

                Dim oFiguraTransporte As New Class_CatCfdiFigurasTransporte(sCodigoFigura)

                If oFiguraTransporte.Existe = False Then
                    MsgBox("La figura de transporte del renglón #" & i.ToString & " no existe.", MsgBoxStyle.Exclamation, sProcedure)
                    Return False
                End If

                Dim oTipoFiguraTransporte As New Class_CfdiCatTiposFiguraTransporte(oFiguraTransporte.CODIGO_TIPO_FIGURA_TRANSPORTE)

                If oFiguraTransporte.CODIGO_TIPO_FIGURA_TRANSPORTE = "01" Then '01=Operador
                    bHayFiguraTipoOperador = True

                    If oTipoFiguraTransporte.VALIDA_LICENCIA = True AndAlso txtLEN(oFiguraTransporte.NUMERO_LICENCIA) = False Then
                        MsgBox("La figura de transporte del renglón #" & i.ToString & " al ser tipo operador debe tener número de licencia en el catálogo de figuras.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                End If

                Dim bHayParteTransporte As Boolean = False
                If oTipoFiguraTransporte.VALIDA_PARTE_TRANSPORTE = True Then
                    'Validar que si pusieron figuras que les aplique poner parte de transporte que hayan puesto al menos una figura por cada figura que le aplique
                    For j = 1 To Me.GridPartesTransporte.Rows - 1
                        If sCodigoFigura = Me.GridPartesTransporte.Cell(j, Me.iGyPtCodigoFigura).Text Then
                            Dim sCodigoParteTransporte As String = Me.GridPartesTransporte.Cell(j, Me.iGyPtCodigoParte).Text

                            If txtLEN(sCodigoParteTransporte) = False Then
                                MsgBox("La parte de transporte del renglón #" & j.ToString & " no debe quedar vacia.", MsgBoxStyle.Exclamation, sProcedure)
                                Return False
                            End If

                            Dim oParteTransporte As New Class_CfdiCatPartesTransporte(sCodigoParteTransporte)
                            If oParteTransporte.Existe = False Then
                                MsgBox("La parte de transporte del renglón #" & j.ToString & " no existe.", MsgBoxStyle.Exclamation, sProcedure)
                                Return False
                            End If

                            bHayParteTransporte = True
                        End If
                    Next

                    If bHayParteTransporte = False Then
                        MsgBox("La figura de transporte del renglón #" & i.ToString & " debe tener relacionada al menos una parte de transporte.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                End If
            Next

            If bHayFiguraTipoOperador = False Then
                MsgBox("Debe de indicar al menos una figura que sea tipo operador.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Sub Totaliza()
        Const sProcedure As String = "Totaliza"
        Try
            Dim i As Integer, dTotalDistanciaRecorrida As Decimal = 0, dTotalPesoBruto As Decimal = 0, dTotalMercancias As Decimal = 0

            Me.txtTotalDistanciaRecorrida.Text = Format(0, "###,##0.00")
            Me.txtTotalPesoBruto.Text = Format(0, "###,##0.000")
            Me.txtTotalMercancias.Text = Format(0, "###,##0")

            'FG_Grid_SumaCol(Me.Grid1, CShort(Me.iGyCantidad)).ToString()

            For i = 1 To Me.GridUbicaciones.Rows - 1
                If txtLEN(Me.GridUbicaciones.Cell(i, Me.iGyUbCodigo).Text) = True Then
                    dTotalDistanciaRecorrida += valorNumericoD(Me.GridUbicaciones.Cell(i, Me.iGyUbDistanciaRecorrida).Text)
                End If
            Next

            For i = 1 To Me.GridMercancias.Rows - 1
                If txtLEN(Me.GridMercancias.Cell(i, Me.iGyMerBienTransportado).Text) = True Then
                    dTotalPesoBruto += valorNumericoD(Me.GridMercancias.Cell(i, Me.iGyMerPesoEnKG).Text)

                    dTotalMercancias += 1
                End If
            Next

            Me.txtTotalDistanciaRecorrida.Text = Format(dTotalDistanciaRecorrida, "###,##0.00")
            Me.txtTotalPesoBruto.Text = Format(dTotalPesoBruto, "###,##0.000")
            Me.txtTotalMercancias.Text = Format(dTotalMercancias, "###,##0")

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub InicializaGridUbicaciones()
        Const sProcedure As String = "InicializaGridUbicaciones"
        Try
            Me.GridUbicaciones.DataSource = Nothing
            FG_Grid_Limpiar(Me.GridUbicaciones)
            Me.GridUbicaciones.Rows = 3
            Me.GridUbicaciones.Cols = 7
            Me.GridUbicaciones.DisplayRowNumber = True

            Me.FormateaGridUbicaciones()

            Me.GridUbicaciones.Cell(1, Me.iGyUbTipo).Text = "Salida"
            Me.GridUbicaciones.Cell(2, Me.iGyUbTipo).Text = "Llegada"
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub InicializaGridMercancias()
        Const sProcedure As String = "InicializaGridMercancias"
        Try
            Me.GridMercancias.DataSource = Nothing
            FG_Grid_Limpiar(Me.GridMercancias)
            Me.GridMercancias.Rows = 2
            Me.GridMercancias.Cols = 8
            Me.GridMercancias.DisplayRowNumber = True

            Me.FormateaGridMercancias()
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub InicializaGridFigurasTransporte()
        Const sProcedure As String = "InicializaGridFigurasTransporte"
        Try
            Me.GridFigurasTransporte.DataSource = Nothing
            FG_Grid_Limpiar(Me.GridFigurasTransporte)
            Me.GridFigurasTransporte.Rows = 2
            Me.GridFigurasTransporte.Cols = 8
            Me.GridFigurasTransporte.DisplayRowNumber = True

            Me.FormateaGridFigurasTransporte()
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub InicializaGridPartesTransporte()
        Const sProcedure As String = "InicializaGridPartesTransporte"
        Try
            Me.GridPartesTransporte.DataSource = Nothing
            FG_Grid_Limpiar(Me.GridPartesTransporte)
            Me.GridPartesTransporte.Rows = 2
            Me.GridPartesTransporte.Cols = 5
            Me.GridPartesTransporte.DisplayRowNumber = True

            Me.FormateaGridPartesTransporte()
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub FormateaGridUbicaciones()
        Const sProcedure As String = "FormateaGridUbicaciones"
        Try
            With Me.GridUbicaciones
                .AutoRedraw = False
                .DisplayFocusRect = False
                .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
                .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
                .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat

                .Cell(0, Me.iGyUbTipo).Text = "Tipo"
                .Cell(0, Me.iGyUbCodigo).Text = "Código"
                .Cell(0, Me.iGyUbNombre).Text = "Nombre"
                .Cell(0, Me.iGyUbDistanciaRecorrida).Text = "Distancia recorrida"
                .Cell(0, Me.iGyUbFechaHoraSalidaLlegada).Text = "FechaHoraSalidaLlegada"
                .Cell(0, Me.iGyUbDomicilio).Text = "Domicilio"

                .Column(Me.iGyUbTipo).Width = 75
                .Column(Me.iGyUbCodigo).Width = 65
                .Column(Me.iGyUbNombre).Width = 320
                .Column(Me.iGyUbDistanciaRecorrida).Width = 100
                .Column(Me.iGyUbFechaHoraSalidaLlegada).Width = 130
                .Column(Me.iGyUbDomicilio).Width = 420

                .Column(Me.iGyUbTipo).CellType = FlexCell.CellTypeEnum.ComboBox
                .Column(Me.iGyUbFechaHoraSalidaLlegada).CellType = FlexCell.CellTypeEnum.DateTime

                .Column(Me.iGyUbDistanciaRecorrida).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyUbDistanciaRecorrida).DecimalLength = 2
                .Column(Me.iGyUbDistanciaRecorrida).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyUbNombre).Locked = True
                .Column(Me.iGyUbDomicilio).Locked = True
            End With

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        Finally
            Me.GridUbicaciones.AutoRedraw = True
            Me.GridUbicaciones.Refresh()
        End Try
    End Sub

    Private Sub FormateaGridMercancias()
        Const sProcedure As String = "FormateaGridMercancias"
        Try
            With Me.GridMercancias
                .AutoRedraw = False
                .DisplayFocusRect = False
                .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
                .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
                .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat

                .Cell(0, Me.iGyMerBienTransportado).Text = "Bien Transpor."
                .Cell(0, Me.iGyMerDescripcion).Text = "Descripción"
                .Cell(0, Me.iGyMerCantidad).Text = "Cantidad"
                .Cell(0, Me.iGyMerClaveUnidad).Text = "ClaveUnidad"
                .Cell(0, Me.iGyMerNombreUnidad).Text = "NombreUnidad"
                .Cell(0, Me.iGyMerUnidad).Text = "Unidad"
                .Cell(0, Me.iGyMerPesoEnKG).Text = "Peso En KG"

                .Column(Me.iGyMerBienTransportado).Width = 100
                .Column(Me.iGyMerDescripcion).Width = 300
                .Column(Me.iGyMerCantidad).Width = 100
                .Column(Me.iGyMerClaveUnidad).Width = 100
                .Column(Me.iGyMerNombreUnidad).Width = 100
                .Column(Me.iGyMerUnidad).Width = 100
                .Column(Me.iGyMerPesoEnKG).Width = 100

                .Column(Me.iGyMerCantidad).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyMerCantidad).DecimalLength = 3
                .Column(Me.iGyMerCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyMerPesoEnKG).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyMerPesoEnKG).DecimalLength = 3
                .Column(Me.iGyMerPesoEnKG).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyMerDescripcion).Locked = True
                .Column(Me.iGyMerNombreUnidad).Locked = True
            End With

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        Finally
            Me.GridMercancias.AutoRedraw = True
            Me.GridMercancias.Refresh()
        End Try
    End Sub

    Private Sub FormateaGridFigurasTransporte()
        Const sProcedure As String = "FormateaGridFigurasTransporte"
        Try
            With Me.GridFigurasTransporte
                .AutoRedraw = False
                .DisplayFocusRect = False
                .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
                .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
                .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat

                .Cell(0, Me.iGyFtCodigoFigura).Text = "Código"
                .Cell(0, Me.iGyFtCodigoTipo).Text = "CodTipo"
                .Cell(0, Me.iGyFtNombreTipo).Text = "NomTipo"
                .Cell(0, Me.iGyFtNombreFigura).Text = "Nombre"
                .Cell(0, Me.iGyFtRFC).Text = "RFC"
                .Cell(0, Me.iGyFtLicencia).Text = "Licencia"
                .Cell(0, Me.iGyFtDomicilio).Text = "Domicilio"

                .Column(Me.iGyFtCodigoFigura).Width = 60
                .Column(Me.iGyFtCodigoTipo).Width = 60
                .Column(Me.iGyFtNombreTipo).Width = 100
                .Column(Me.iGyFtNombreFigura).Width = 250
                .Column(Me.iGyFtRFC).Width = 100
                .Column(Me.iGyFtLicencia).Width = 70
                .Column(Me.iGyFtDomicilio).Width = 400

                .Column(Me.iGyFtCodigoTipo).Locked = True
                .Column(Me.iGyFtNombreTipo).Locked = True
                .Column(Me.iGyFtNombreFigura).Locked = True
                .Column(Me.iGyFtDomicilio).Locked = True
                .Column(Me.iGyFtLicencia).Locked = True
                .Column(Me.iGyFtDomicilio).Locked = True
            End With

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        Finally
            Me.GridFigurasTransporte.AutoRedraw = True
            Me.GridFigurasTransporte.Refresh()
        End Try
    End Sub

    Private Sub FormateaGridPartesTransporte()
        Const sProcedure As String = "FormateaGridPartesTransporte"
        Try
            With Me.GridPartesTransporte
                .AutoRedraw = False
                .DisplayFocusRect = False
                .DrawMode = FlexCell.DrawModeEnum.OwnerDraw
                .BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
                .FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Flat

                .Cell(0, Me.iGyPtCodigoFigura).Text = "Código fig."
                .Cell(0, Me.iGyPtNombreFigura).Text = "Nombre fig."
                .Cell(0, Me.iGyPtCodigoParte).Text = "Código parte"
                .Cell(0, Me.iGyPtNombreParte).Text = "Nombre parte"

                .Column(Me.iGyPtCodigoFigura).Width = 100
                .Column(Me.iGyPtNombreFigura).Width = 300
                .Column(Me.iGyPtCodigoParte).Width = 100
                .Column(Me.iGyPtNombreParte).Width = 200

                .Column(Me.iGyPtNombreFigura).Locked = True
                .Column(Me.iGyPtNombreParte).Locked = True
            End With

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        Finally
            Me.GridPartesTransporte.AutoRedraw = True
            Me.GridPartesTransporte.Refresh()
        End Try
    End Sub

    Private Sub GestionaGridUbicaciones(ByVal e As System.Windows.Forms.KeyEventArgs)
        Const sProcedure As String = "GestionaGridUbicaciones"
        Try
            Dim Columna As Integer, Renglon As Integer
            Dim sText As String = "", oUbicacion As Class_CatCfdiUbicaciones

            If Me.GridUbicaciones.Locked = True Then
                Return
            End If

            Columna = Me.GridUbicaciones.Selection.FirstCol
            Renglon = Me.GridUbicaciones.Selection.FirstRow

            Select Case e.KeyCode
                Case Keys.Enter
                    Select Case Columna
                        Case Me.iGyUbCodigo
                            If txtLEN(Me.GridUbicaciones.Cell(Renglon, Me.iGyUbCodigo).Text) = False Then
NoExiste_Codigo:
                                Me.GridUbicaciones.Cell(Renglon, Me.iGyUbNombre).Text = ""
                                GoTo F6_Codigo : Return
                            End If
Enter_Codigo:

                            oUbicacion = New Class_CatCfdiUbicaciones(CInt(Me.GridUbicaciones.Cell(Renglon, Me.iGyUbCodigo).Text))

                            If oUbicacion.Existe = False Then
                                GoTo NoExiste_Codigo : Return
                            End If

                            Me.GridUbicaciones.Cell(Renglon, Me.iGyUbNombre).Text = oUbicacion.NOMBRE_REMITENTE_DESTINATARIO
                            Me.GridUbicaciones.Cell(Renglon, Me.iGyUbDomicilio).Text = oUbicacion.DOMICILIO_COMPLETO
                    End Select

                    If Columna = Me.iGyUbDomicilio AndAlso Me.GridUbicaciones.Rows = Renglon + 1 Then
                        Me.GridUbicaciones.Rows += 1
                    End If

                    Me.Totaliza()

                Case Keys.F6
                    Select Case Columna
                        Case Me.iGyUbCodigo
F6_Codigo:
                            oUbicacion = New Class_CatCfdiUbicaciones
                            sText = oUbicacion.BusquedaVisual_PorDescripcion

                            If txtLEN(sText) = True Then
                                Me.GridUbicaciones.Cell(Renglon, Me.iGyUbCodigo).Text = sText : GoTo Enter_Codigo : Return
                            End If
                    End Select

                Case Keys.F8 ', Keys.Delete-El delete no se considera porque también va borra el valor de la celda donde quede el foco luego de borrar el renglón
                    If Me.GridUbicaciones.Rows = 2 Then
                        Me.InicializaGridUbicaciones()
                    Else
                        Me.GridUbicaciones.Selection.DeleteByRow()
                    End If

                    Me.Totaliza()

            End Select

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub GestionaGridMercancias(ByVal e As System.Windows.Forms.KeyEventArgs)
        Const sProcedure As String = "GestionaGridMercancias"
        Try
            Dim Columna As Integer, Renglon As Integer
            Dim sText As String = "", oProductoSAT As Class_CFD_CatProductosServicios, oUnidadSAT As Class_CFD_CatUnidades

            If Me.GridMercancias.Locked = True Then
                Return
            End If

            Columna = Me.GridMercancias.Selection.FirstCol
            Renglon = Me.GridMercancias.Selection.FirstRow

            Select Case e.KeyCode
                Case Keys.Enter
                    Select Case Columna
                        Case Me.iGyMerBienTransportado
                            If txtLEN(Me.GridMercancias.Cell(Renglon, Me.iGyMerBienTransportado).Text) = False Then
NoExiste_BienTransportado:
                                Me.GridMercancias.Cell(Renglon, Me.iGyMerDescripcion).Text = ""
                                GoTo F6_BienTransportado : Return
                            End If
Enter_BienTransportado:
                            oProductoSAT = New Class_CFD_CatProductosServicios(Me.GridMercancias.Cell(Renglon, Me.iGyMerBienTransportado).Text)

                            If oProductoSAT.EXISTE = True Then
                                Me.GridMercancias.Cell(Renglon, Me.iGyMerDescripcion).Text = oProductoSAT.NOMBRE_PRODUCTO_SERVICIO
                            Else
                                GoTo NoExiste_BienTransportado : Return
                            End If

                        Case Me.iGyMerClaveUnidad
                            If txtLEN(Me.GridMercancias.Cell(Renglon, Me.iGyMerClaveUnidad).Text) = False Then
NoExiste_ClaveUnidad:
                                Me.GridMercancias.Cell(Renglon, Me.iGyMerNombreUnidad).Text = ""
                                GoTo F6_ClaveUnidad : Return
                            End If
Enter_ClaveUnidad:
                            oUnidadSAT = New Class_CFD_CatUnidades(Me.GridMercancias.Cell(Renglon, Me.iGyMerClaveUnidad).Text)

                            If oUnidadSAT.EXISTE = True Then
                                Me.GridMercancias.Cell(Renglon, Me.iGyMerNombreUnidad).Text = oUnidadSAT.NOMBRE_UNIDAD
                            Else
                                GoTo NoExiste_ClaveUnidad : Return
                            End If

                        Case Me.iGyMerPesoEnKG
                            If valorNumericoD(Me.GridMercancias.Cell(Renglon, Me.iGyMerPesoEnKG).Text) <= 0 Then
                                MsgBox("Debe asignar un peso en Kg mayor que cero.", MsgBoxStyle.Exclamation, sProcedure)
                                Me.GridMercancias.Cell(Renglon, Me.iGyMerUnidad).SetFocus()
                                Return
                            End If
                    End Select

                    If Columna = Me.iGyMerPesoEnKG AndAlso Me.GridMercancias.Rows = Renglon + 1 Then
                        Me.GridMercancias.Rows += 1
                    End If

                    Me.Totaliza()

                Case Keys.F6
                    Select Case Columna
                        Case Me.iGyMerBienTransportado
F6_BienTransportado:
                            oProductoSAT = New Class_CFD_CatProductosServicios
                            sText = oProductoSAT.BusquedaVisual_PorDescripcion

                            If txtLEN(sText) = True Then
                                Me.GridMercancias.Cell(Renglon, Me.iGyMerBienTransportado).Text = sText : GoTo Enter_BienTransportado : Return
                            End If

                        Case Me.iGyMerClaveUnidad
F6_ClaveUnidad:
                            oUnidadSAT = New Class_CFD_CatUnidades
                            sText = oUnidadSAT.BusquedaVisual_PorDescripcion

                            If txtLEN(sText) = True Then
                                Me.GridMercancias.Cell(Renglon, Me.iGyMerClaveUnidad).Text = sText : GoTo Enter_ClaveUnidad : Return
                            End If
                    End Select

                Case Keys.F7
                    Select Case Columna
                        Case Me.iGyMerBienTransportado
                            oProductoSAT = New Class_CFD_CatProductosServicios
                            sText = oProductoSAT.BusquedaVisual_CatalogoProductosServicios

                            If txtLEN(sText) = True Then
                                Me.GridMercancias.Cell(Renglon, Me.iGyMerBienTransportado).Text = sText
                                GoTo Enter_BienTransportado : Return
                            End If

                    End Select

                Case Keys.F8 ', Keys.Delete-El delete no se considera porque también va borra el valor de la celda donde quede el foco luego de borrar el renglón
                    If Me.GridMercancias.Rows = 2 Then
                        Me.InicializaGridMercancias()
                    Else
                        Me.GridMercancias.Selection.DeleteByRow()
                    End If

                    Me.Totaliza()

            End Select

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub InicializaRenglonGridFiguraTransporte(ByVal iRenglon As Integer)
        Const sProcedure As String = "InicializaFiguraTransporte"
        Try
            Me.GridFigurasTransporte.Cell(iRenglon, Me.iGyFtCodigoTipo).Text = ""
            Me.GridFigurasTransporte.Cell(iRenglon, Me.iGyFtNombreTipo).Text = ""
            Me.GridFigurasTransporte.Cell(iRenglon, Me.iGyFtNombreFigura).Text = ""
            Me.GridFigurasTransporte.Cell(iRenglon, Me.iGyFtRFC).Text = ""
            Me.GridFigurasTransporte.Cell(iRenglon, Me.iGyFtLicencia).Text = ""
            Me.GridFigurasTransporte.Cell(iRenglon, Me.iGyFtDomicilio).Text = ""
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub GestionaGridFigurasTransporte(ByVal e As System.Windows.Forms.KeyEventArgs)
        Const sProcedure As String = "GestionaGridFigurasTransporte"
        Try
            Dim Columna As Integer, Renglon As Integer
            Dim sText As String = "", oFigura As Class_CatCfdiFigurasTransporte

            If Me.GridFigurasTransporte.Locked = True Then
                Return
            End If

            Columna = Me.GridFigurasTransporte.Selection.FirstCol
            Renglon = Me.GridFigurasTransporte.Selection.FirstRow

            Select Case e.KeyCode
                Case Keys.Enter
                    Select Case Columna
                        Case Me.iGyFtCodigoFigura
                            If txtLEN(Me.GridFigurasTransporte.Cell(Renglon, Me.iGyFtCodigoFigura).Text) = False Then
NoExiste_Codigo:
                                Me.InicializaRenglonGridFiguraTransporte(Renglon)
                                GoTo F6_Codigo : Return
                            End If
Enter_Codigo:
                            oFigura = New Class_CatCfdiFigurasTransporte(Me.GridFigurasTransporte.Cell(Renglon, Me.iGyFtCodigoFigura).Text)

                            If oFigura.Existe = True Then
                                Dim oTipoFigura As New Class_CfdiCatTiposFiguraTransporte(oFigura.CODIGO_TIPO_FIGURA_TRANSPORTE)

                                Me.GridFigurasTransporte.Cell(Renglon, Me.iGyFtCodigoTipo).Text = oFigura.CODIGO_TIPO_FIGURA_TRANSPORTE
                                Me.GridFigurasTransporte.Cell(Renglon, Me.iGyFtNombreTipo).Text = oTipoFigura.NOMBRE_TIPO_FIGURA_TRANSPORTE
                                Me.GridFigurasTransporte.Cell(Renglon, Me.iGyFtNombreFigura).Text = oFigura.NOMBRE_FIGURA_TRANSPORTE
                                Me.GridFigurasTransporte.Cell(Renglon, Me.iGyFtRFC).Text = oFigura.RFC
                                Me.GridFigurasTransporte.Cell(Renglon, Me.iGyFtLicencia).Text = oFigura.NUMERO_LICENCIA
                                Me.GridFigurasTransporte.Cell(Renglon, Me.iGyFtDomicilio).Text = oFigura.DOMICILIO_COMPLETO

                                If Me.GridFigurasTransporte.Rows = Renglon + 1 Then
                                    Me.GridFigurasTransporte.Rows += 1
                                End If
                            Else
                                GoTo NoExiste_Codigo : Return
                            End If
                    End Select

                Case Keys.F6
                    Select Case Columna
                        Case Me.iGyFtCodigoFigura
F6_Codigo:
                            oFigura = New Class_CatCfdiFigurasTransporte
                            sText = oFigura.BusquedaVisual_PorDescripcion

                            If txtLEN(sText) = True Then
                                Me.GridFigurasTransporte.Cell(Renglon, Me.iGyFtCodigoFigura).Text = sText : GoTo Enter_Codigo : Return
                            End If
                    End Select

                Case Keys.F8 ', Keys.Delete-El delete no se considera porque también va borra el valor de la celda donde quede el foco luego de borrar el renglón
                    If Me.GridFigurasTransporte.Rows = 2 Then
                        Me.InicializaGridFigurasTransporte()
                    Else
                        Me.GridFigurasTransporte.Selection.DeleteByRow()
                    End If

            End Select

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub GestionaGridPartesTransporte(ByVal e As System.Windows.Forms.KeyEventArgs)
        Const sProcedure As String = "GestionaGridPartesTransporte"
        Try
            Dim Columna As Integer, Renglon As Integer
            Dim sText As String = "", oParteTransporte As Class_CfdiCatPartesTransporte, oFigura As Class_CatCfdiFigurasTransporte

            If Me.GridFigurasTransporte.Locked = True Then
                Return
            End If

            Columna = Me.GridFigurasTransporte.Selection.FirstCol
            Renglon = Me.GridFigurasTransporte.Selection.FirstRow

            Select Case e.KeyCode
                Case Keys.Enter
                    Select Case Columna
                        Case Me.iGyPtCodigoFigura
                            If txtLEN(Me.GridFigurasTransporte.Cell(Renglon, Me.iGyPtCodigoFigura).Text) = False Then
NoExiste_CodigoFigura:
                                Me.GridPartesTransporte.Cell(Renglon, Me.iGyPtNombreFigura).Text = ""
                                GoTo F6_CodigoFigura : Return
                            End If
Enter_CodigoFigura:
                            Dim bFiguraEncontrada As Boolean = False
                            For i = 1 To Me.GridFigurasTransporte.Rows - 1
                                If Me.GridFigurasTransporte.Cell(i, Me.iGyFtCodigoFigura).Text = Me.GridPartesTransporte.Cell(Renglon, Me.iGyPtCodigoFigura).Text Then
                                    bFiguraEncontrada = True
                                    Exit For
                                End If
                            Next

                            If bFiguraEncontrada = False Then
                                MsgBox("Esta figura que indicó no esta en la lista de figuras.", MsgBoxStyle.Exclamation, sProcedure)
                                Me.GridPartesTransporte.Cell(Renglon, Me.iGyPtCodigoFigura).Text = ""
                                Me.GridPartesTransporte.Cell(Renglon, Me.iGyPtNombreFigura).Text = ""
                                Me.GridPartesTransporte.Cell(Renglon, 0).SetFocus() 'Para que se quede el focus donde mismo porque con el enter lo va avanzar a la siguiente columna.
                                Return
                            End If

                            oFigura = New Class_CatCfdiFigurasTransporte(Me.GridPartesTransporte.Cell(Renglon, Me.iGyPtCodigoFigura).Text)

                            If oFigura.Existe = True Then
                                Dim oTipoFigura As New Class_CfdiCatTiposFiguraTransporte(oFigura.CODIGO_TIPO_FIGURA_TRANSPORTE)
                                If oTipoFigura.VALIDA_PARTE_TRANSPORTE = True Then
                                    Me.GridPartesTransporte.Cell(Renglon, Me.iGyPtNombreFigura).Text = oFigura.NOMBRE_FIGURA_TRANSPORTE
                                Else
                                    MsgBox("Esta figura no necesita que le indique una parte de transporte.", MsgBoxStyle.Exclamation, sProcedure)
                                    Me.GridPartesTransporte.Cell(Renglon, Me.iGyPtCodigoFigura).Text = ""
                                    Me.GridPartesTransporte.Cell(Renglon, Me.iGyPtNombreFigura).Text = ""
                                    Me.GridPartesTransporte.Cell(Renglon, 0).SetFocus() 'Para que se quede el focus donde mismo porque con el enter lo va avanzar a la siguiente columna.
                                End If
                            Else
                                GoTo NoExiste_CodigoFigura : Return
                            End If

                        Case Me.iGyPtCodigoParte
                            If txtLEN(Me.GridPartesTransporte.Cell(Renglon, Me.iGyPtCodigoParte).Text) = False Then
NoExiste_CodigoParte:
                                Me.GridPartesTransporte.Cell(Renglon, Me.iGyPtNombreParte).Text = ""
                                GoTo F6_CodigoParte : Return
                            End If
Enter_CodigoParte:
                            oParteTransporte = New Class_CfdiCatPartesTransporte(Me.GridPartesTransporte.Cell(Renglon, Me.iGyPtCodigoParte).Text)

                            If oParteTransporte.Existe = True Then
                                Me.GridPartesTransporte.Cell(Renglon, Me.iGyPtNombreParte).Text = oParteTransporte.NOMBRE_PARTE_TRANSPORTE
                            Else
                                GoTo NoExiste_CodigoParte : Return
                            End If

                            If Me.GridPartesTransporte.Rows = Renglon + 1 Then
                                Me.GridPartesTransporte.Rows += 1
                            End If
                    End Select

                Case Keys.F6
                    Select Case Columna
                        Case Me.iGyPtCodigoFigura 'La figura que seleccionen debe de existir en el grid de figuras previo a este, esto se hace en Enter_CodigoFigura
F6_CodigoFigura:
                            oFigura = New Class_CatCfdiFigurasTransporte
                            sText = oFigura.BusquedaVisual_PorDescripcion

                            If txtLEN(sText) = True Then
                                Me.GridPartesTransporte.Cell(Renglon, Me.iGyPtCodigoFigura).Text = sText : GoTo Enter_CodigoFigura : Return
                            End If

                        Case Me.iGyPtCodigoParte
F6_CodigoParte:
                            oParteTransporte = New Class_CfdiCatPartesTransporte
                            sText = oParteTransporte.BusquedaVisual_PorDescripcion

                            If txtLEN(sText) = True Then
                                Me.GridPartesTransporte.Cell(Renglon, Me.iGyPtCodigoParte).Text = sText : GoTo Enter_CodigoParte : Return
                            End If

                    End Select

                Case Keys.F8 ', Keys.Delete-El delete no se considera porque también va borra el valor de la celda donde quede el foco luego de borrar el renglón
                    If Me.GridPartesTransporte.Rows = 2 Then
                        Me.InicializaGridPartesTransporte()
                    Else
                        Me.GridPartesTransporte.Selection.DeleteByRow()
                    End If

            End Select

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub InicializaVehiculo()
        Const sProcedure As String = "InicializaVehiculo"
        Try
            Me.txtCodigoVehiculo.Text = ""
            Me.txtNombreVehiculo.Text = ""
            Me.txtMarca.Text = ""
            Me.txtAño.Text = ""
            Me.txtPlacaAutotransporte.Text = ""
            Me.txtCodigoAutotransporte.Text = ""
            Me.txtNombreAutotransporte.Text = ""
            Me.txtCodigoPermisoSCT.Text = ""
            Me.txtNumeroPermisoSCT.Text = ""
            Me.txtAseguradoraResponsabilidadCivil.Text = ""
            Me.txtPolizaResposabilidadCivil.Text = ""
            Me.txtPrimaSeguro.Text = ""
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub InicializaRemolque1()
        Const sProcedure As String = "InicializaRemolque1"
        Try
            Me.txtCodigoRemolque1.Text = ""
            Me.txtPlacaRemolque1.Text = ""
            Me.txtTipoRemolque1.Text = ""
            Me.txtNombreTipoRemolque1.Text = ""
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub InicializaRemolque2()
        Const sProcedure As String = "InicializaRemolque2"
        Try
            Me.txtCodigoRemolque2.Text = ""
            Me.txtPlacaRemolque2.Text = ""
            Me.txtTipoRemolque2.Text = ""
            Me.txtNombreTipoRemolque2.Text = ""
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub


#End Region

End Class