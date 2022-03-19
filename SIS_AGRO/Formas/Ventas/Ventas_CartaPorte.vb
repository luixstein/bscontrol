Option Strict On

Public Class Ventas_CartaPorte

#Region "Campos privados"
    Private FolioVenta As String

    Private Enum enumEstados
        NUEVO
        GRABADO
    End Enum

    Private oCartaPorte As New Class_CartaPorte
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
    Private iGyFtCodigo As Integer = 1
    Private iGyFtTipo As Integer = 2
    Private iGyFtNombre As Integer = 3
    Private iGyFtRFC As Integer = 4
    Private iGyFtLicencia As Integer = 5
    Private iGyFtDomicilio As Integer = 6
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
        Me.CambiarEstado(enumEstados.NUEVO)
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
        'FALTA
        Try
            Me.cboTransporteInternacional.Items.AddRange(New Object() {"Sí", "No"})

            Me.Inicializa()

            Me.GridUbicaciones.ComboBox(Me.iGyUbTipo).Items.AddRange(New Object() {"Salida", "Llegada"})
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
        'FALTA
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
                        Me.txtNombreVehiculo.Text = oVehiculo.Nombre_Vehiculo
                        Me.txtMarca.Text = oVehiculo.MARCA
                        Me.txtAño.Text = oVehiculo.ANIO
                        Me.txtPlacaAutotransporte.Text = oVehiculo.PLACA
                        Me.txtCodigoAutotransporte.Text = oVehiculo.CODIGO_AUTOTRANSPORTE
                        Me.txtNombreAutotransporte.Text = "" 'clase autotransporte?
                        Me.txtCodigoPermisoSCT.Text = oVehiculo.CODIGO_PERMISO_SCT
                        Me.txtNumeroPermisoSCT.Text = oVehiculo.NUMERO_PERMISO_SCT
                        Me.txtAseguradoraResponsabilidadCivil.Text = oVehiculo.NOMBRE_ASEGURADORA_RESPONSABILIDAD_CIVIL
                        Me.txtPolizaResposabilidadCivil.Text = oVehiculo.POLIZA_RESPONSABILIDAD_CIVIL
                        Me.txtPrimaSeguro.Text = oVehiculo.PRIMA_SEGURO
                    End If

                    Me.txtCodigoRemolque1.Focus()
            End Select
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub txtCodigoRemolque1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoRemolque1.KeyDown
        Const sProcedure As String = "txtCodigoRemolque1_KeyDown"
        'FALTA
        Try
            Dim sText As String, oRemolque As Class_CFD_CatRemolques
            Select Case e.KeyCode
                Case Keys.F6
F6:
                    oRemolque = New Class_CFD_CatRemolques
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
                    oRemolque = New Class_CFD_CatRemolques(Me.txtCodigoRemolque1.Text)

                    If oRemolque.EXISTE = False Then
                        Me.InicializaRemolque1() : GoTo F6 : Exit Sub
                    Else
                        Me.txtPlacaRemolque1.Text = oRemolque.PLACA
                        Me.txtTipoRemolque1.Text = oRemolque.CODIGO_TIPO_REMOLQUE
                        Dim oTipoRemolque As New Class_CFD_CatTiposRemolques(Me.txtTipoRemolque1.Text)
                        Me.txtNombreTipoRemolque1.Text = oTipoRemolque.NOMBRE_TIPO_REMOLQUE
                    End If

                    txtTAB(e)
            End Select
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub txtCodigoRemolque2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoRemolque2.KeyDown
        Const sProcedure As String = "txtCodigoRemolque2_KeyDown"
        'FALTA
        Try
            Dim sText As String, oRemolque As Class_CFD_CatRemolques
            Select Case e.KeyCode
                Case Keys.F6
F6:
                    oRemolque = New Class_CFD_CatRemolques
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
                    oRemolque = New Class_CFD_CatRemolques(Me.txtCodigoRemolque2.Text)

                    If oRemolque.EXISTE = False Then
                        Me.InicializaRemolque2() : GoTo F6 : Exit Sub
                    Else
                        Me.txtPlacaRemolque2.Text = oRemolque.PLACA
                        Me.txtTipoRemolque2.Text = oRemolque.CODIGO_TIPO_REMOLQUE
                        Dim oTipoRemolque As New Class_CFD_CatTiposRemolques(Me.txtTipoRemolque2.Text)
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
                Case enumEstados.NUEVO

                Case enumEstados.GRABADO

            End Select

            'FALTA
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Function Consultar() As Boolean
        Const sProcedure As String = "Consultar"
        Try
            'FALTA
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Function Grabar() As Boolean
        'FALTA
        Const sProcedure As String = "Grabar"
        Dim bResultado As Boolean = False

        Try
            Dim sListaUbicaciones As String = "", sListaMercancias As String = "", sListaFigurasTransporte As String = "", sListaPartesTransporte As String = ""

            Me.Totaliza()

            If Me.Validar = False Then
                Return False
            End If

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

                Select Case Me.Estado
                    Case enumEstados.NUEVO
                        bResultado = .Grabar("INSERTAR")
                    Case enumEstados.GRABADO
                        bResultado = .Grabar("ACTUALIZAR")
                End Select

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
            'FALTA
            Dim i As Integer = 0

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Validar que hayan puesto 2 ubicaciones, una origen y destino y la de destino validar que distancia recorrida>0
            Dim oUbicacion As Class_CFD_CatUbicaciones, bUbicacionOrigenEncontrada As Boolean = False, bUbicacionDestinoEncontrada As Boolean = False

            For i = 1 To Me.GridUbicaciones.Rows - 1
                Dim sCodigoUbicacion As String = Me.GridUbicaciones.Cell(i, Me.iGyUbCodigo).Text

                If txtLEN(sCodigoUbicacion) = True Then
                    oUbicacion = New Class_CFD_CatUbicaciones(sCodigoUbicacion)
                    If oUbicacion.Existe = False Then
                        MsgBox("La ubicación del renglón #" & i.ToString & " no existe.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If

                    If oUbicacion.TIPO_UBICACION = "Origen" Then
                        bUbicacionOrigenEncontrada = True

                        If valorNumericoD(Me.GridUbicaciones.Cell(i, Me.iGyUbDistanciaRecorrida).Text) <> 0 Then
                            MsgBox("La distancia recorrida de ubicación del renglón #" & i.ToString & " debe ser cero al ser tipo origen.", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        End If
                    ElseIf oUbicacion.TIPO_UBICACION = "Destino" Then
                        bUbicacionDestinoEncontrada = True

                        If valorNumericoD(Me.GridUbicaciones.Cell(i, Me.iGyUbDistanciaRecorrida).Text) <= 0 Then
                            MsgBox("La distancia recorrida de ubicación del renglón #" & i.ToString & " debe ser mayor que cero al ser tipo destino.", MsgBoxStyle.Exclamation, sProcedure)
                            Return False
                        End If
                    End If

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
            'Validar que hayan puesto al menos una mercancia con cantidad, codigo_unidad,unidad y peso_kg>0
            Dim bHayMercancias As Boolean = False

            For i = 1 To Me.GridMercancias.Rows - 1
                Dim sBienTransportado As String = Me.GridMercancias.Cell(i, Me.iGyMerBienTransportado).Text

                If txtLEN(sBienTransportado) = True Then
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
                End If
            Next

            If bHayMercancias = False Then
                MsgBox("Debe de indicar al menos una mercancía.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Validar que haya puesto al menos una figura de transporte tipo operador y si es operador que tenga licencia
            Dim bHayFiguras As Boolean = False

            For i = 1 To Me.GridMercancias.Rows - 1

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Validar que si pusieron figuras que les aplique poner parte de transporte que hayan puesto al menos una figura por cada figura que le aplique

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
            Me.GridUbicaciones.Rows = 2
            Me.GridUbicaciones.Cols = 7
            Me.GridUbicaciones.DisplayRowNumber = True
            
            Me.FormateaGridUbicaciones()
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
            Me.GridFigurasTransporte.Cols = 7
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
                .Column(Me.iGyUbCodigo).Width = 75
                .Column(Me.iGyUbNombre).Width = 100
                .Column(Me.iGyUbDistanciaRecorrida).Width = 120
                .Column(Me.iGyUbFechaHoraSalidaLlegada).Width = 130
                .Column(Me.iGyUbDomicilio).Width = 300

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

                .Cell(0, Me.iGyFtCodigo).Text = "Código"
                .Cell(0, Me.iGyFtTipo).Text = "Tipo"
                .Cell(0, Me.iGyFtNombre).Text = "Nombre"
                .Cell(0, Me.iGyFtRFC).Text = "RFC"
                .Cell(0, Me.iGyFtLicencia).Text = "Licencia"
                .Cell(0, Me.iGyFtDomicilio).Text = "Domicilio"

                .Column(Me.iGyFtCodigo).Width = 100
                .Column(Me.iGyFtTipo).Width = 100
                .Column(Me.iGyFtNombre).Width = 250
                .Column(Me.iGyFtRFC).Width = 100
                .Column(Me.iGyFtLicencia).Width = 100
                .Column(Me.iGyFtDomicilio).Width = 300

                .Column(Me.iGyFtTipo).Locked = True
                .Column(Me.iGyFtNombre).Locked = True
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
                .Column(Me.iGyPtCodigoParte).Locked = True
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
            'FALTA

            Dim Columna As Integer, Renglon As Integer
            'Dim sText As String = "", oUbicacion As Class_CFD_CatUbicaciones

            Columna = Me.GridUbicaciones.Selection.FirstCol
            Renglon = Me.GridUbicaciones.Selection.FirstRow

            Select Case e.KeyCode
                Case Keys.Enter
                    '                    Select Case Columna
                    '                        Case Me.iGyUbCodigo
                    '                            If txtLEN(Me.GridUbicaciones.Cell(Renglon, Me.iGyMerBienTransportado).Text) = False Then
                    'NoExiste_Codigo:
                    '                                Me.GridUbicaciones.Cell(Renglon, Me.iGyUbNombre).Text = ""
                    '                                GoTo F6_Codigo : Return
                    '                            End If
                    'Enter_Codigo:
                    '                            oUbicacion = New Class_CFD_CatUbicaciones(Me.GridUbicaciones.Cell(Renglon, Me.iGyUbCodigo).Text)

                    '                            If oUbicacion.EXISTE = True Then
                    '                                Me.GridUbicaciones.Cell(Renglon, Me.iGyUbNombre).Text = oUbicacion.NOMBRE_REMITENTE_DESTINATARIO
                    '                            Else
                    '                                GoTo NoExiste_Codigo : Return
                    '                            End If

                    '                    End Select

                    If Columna = Me.iGyUbDomicilio AndAlso Me.GridUbicaciones.Rows = Renglon + 1 Then
                        Me.GridUbicaciones.Rows += 1
                    End If

                Case Keys.F6
                    '                    Select Case Columna
                    '                        Case Me.iGyUbCodigo
                    'F6_Codigo:
                    '                            oUbicacion = New Class_CFD_CatUbicaciones
                    '                            sText = oUbicacion.BusquedaVisual_PorDescripcion

                    '                            If txtLEN(sText) = True Then
                    '                                Me.GridUbicaciones.Cell(Renglon, Me.iGyUbCodigo).Text = sText : GoTo Enter_Codigo : Return
                    '                            End If
                    '                    End Select
            End Select

            Me.Totaliza()
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub GestionaGridMercancias(ByVal e As System.Windows.Forms.KeyEventArgs)
        Const sProcedure As String = "GestionaGridMercancias"
        Try
            Dim Columna As Integer, Renglon As Integer
            Dim sText As String = "", oProductoSAT As Class_CFD_CatProductosServicios, oUnidadSAT As Class_CFD_CatUnidades

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
            End Select

            Me.Totaliza()
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub GestionaGridFigurasTransporte(ByVal e As System.Windows.Forms.KeyEventArgs)
        Const sProcedure As String = "GestionaGridFigurasTransporte"
        Try
            'FALTA
            Dim Columna As Integer, Renglon As Integer

            Columna = Me.GridFigurasTransporte.Selection.FirstCol
            Renglon = Me.GridFigurasTransporte.Selection.FirstRow
            'StrCod = Me.Grid1.Cell(Renglon, iGyCodigo).Text

            Select Case e.KeyCode
                Case Keys.Enter

                Case Keys.F6
                    Select Case Columna
                        Case Me.iGyFtCodigo

                    End Select
            End Select

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub GestionaGridPartesTransporte(ByVal e As System.Windows.Forms.KeyEventArgs)
        Const sProcedure As String = "GestionaGridPartesTransporte"
        Try
            'FALTA
            Dim Columna As Integer, Renglon As Integer

            Columna = Me.GridFigurasTransporte.Selection.FirstCol
            Renglon = Me.GridFigurasTransporte.Selection.FirstRow
            'StrCod = Me.Grid1.Cell(Renglon, iGyCodigo).Text

            Select Case e.KeyCode
                Case Keys.Enter

                Case Keys.F6
                    Select Case Columna
                        Case Me.iGyPtCodigoFigura

                        Case Me.iGyPtCodigoParte

                    End Select
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