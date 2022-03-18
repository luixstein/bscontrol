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
        'FALTA
    End Sub

    Private Sub txtCodigoUnidadPeso_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoUnidadPeso.KeyDown
        'FALTA
    End Sub

    Private Sub txtCodigoVehiculo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoVehiculo.KeyDown
        'FALTA
    End Sub

    Private Sub txtCodigoRemolque1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoRemolque1.KeyDown
        'FALTA
    End Sub

    Private Sub txtCodigoRemolque2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoRemolque2.KeyDown
        'FALTA
    End Sub

    Private Sub GridUbicaciones_KeyDown(Sender As Object, e As KeyEventArgs) Handles GridUbicaciones.KeyDown
        'FALTA
    End Sub

    Private Sub GridMercancias_KeyDown(Sender As Object, e As KeyEventArgs) Handles GridMercancias.KeyDown
        'FALTA
    End Sub

    Private Sub GridFigurasTransporte_KeyDown(Sender As Object, e As KeyEventArgs) Handles GridFigurasTransporte.KeyDown
        'FALTA
    End Sub

    Private Sub GridPartesTransporte_KeyDown(Sender As Object, e As KeyEventArgs) Handles GridPartesTransporte.KeyDown
        'FALTA
    End Sub
#End Region

#Region "Eventos Genericos"
    Private Sub txtKeyPress(sender As Object, e As KeyPressEventArgs) 'Handles txtCodigoUnidadPeso.KeyPress

    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Const sProcedure As String = "Inicializa"
        Try
            'FALTA
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub

    Private Sub CambiarEstado(ByVal Estado As enumEstados)
        Const sProcedure As String = "CambiarEstado"
        Try
            Me.Estado = Estado
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

            With Me.oCartaPorte
                '.ID_CFDI_CARTA_PORTE_GLOBAL = 0
                .FOLIO_VENTA = Me.FolioVenta
                .VERSION = "2.0"
                .TRANSPORTE_INTERNACIONAL = ""
                .ENTRADA_SALIDA_MERCANCIA = ""
                .CODIGO_PAIS_SAT = ""
                .CODIGO_TRANSPORTE = ""
                .TOTAL_DISTANCIA_RECORRIDA = ""
                .PESO_BRUTO_TOTAL = ""
                .CODIGO_UNIDAD_PESO = ""
                .NUMERO_TOTAL_MERCANCIAS = ""
                .CODIGO_VEHICULO = ""
                .CODIGO_REMOLQUE_1 = ""
                .CODIGO_REMOLQUE_2 = ""
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
        Try
            'FALTA
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Function

    Private Sub Totaliza()
        Const sProcedure As String = "Totaliza"
        Try
            'FALTA
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
    End Sub


#End Region

End Class