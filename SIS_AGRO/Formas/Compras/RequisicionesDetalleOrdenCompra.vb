Option Strict On

Public Class RequisicionesDetalleOrdenCompra
    Public CodigoAlmacen As String
    Private ClickSinEjecutar As Boolean = False
    Public dArticulosRequeridos As DataTable

#Region "Campos"
    Private _bAgregado As Boolean = False
#End Region

#Region "Propiedades"
    Public ReadOnly Property Agregado() As Boolean
        Get
            Return _bAgregado
        End Get
    End Property
#End Region

#Region "Columnas grid requisiciones"
    Private igyCodigoArticulo As Short = 1
    Private igyDescripcion As Short = 2
    Private igyDisponible As Short = 3
    Private igyCantidad As Short = 4
    Private igyUnidad As Short = 5
    Private igySeleccion As Short = 6
#End Region

#Region "Opciones"
    Private Sub tsbAgregar_Click(sender As Object, e As EventArgs) Handles tsbAgregar.Click
        Me._bAgregado = Me.AgregarDetalleRequisiciones()
        Application.DoEvents()
        If Me._bAgregado = True Then
            Me.Visible = False
        End If
    End Sub

    Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Eventos de objetos"
    Private Sub RequisicionesDetalleOrdenCompra(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InicializaGrid()
        Me.ConsultarDetalleRequisiciones(CodigoAlmacen)
    End Sub

    Private Sub Grid_CellChanging(ByVal Sender As Object, ByVal e As FlexCell.Grid.CellChangingEventArgs) Handles GridRequisiones.CellChanging
        Try
            Dim Columna As Integer = e.Col, Renglon As Integer = e.Row
            Dim dCantidad As Double

            If e.Col = Me.igySeleccion And e.Row > 0 Then
                If Me.GridRequisiones.Cell(Renglon, Me.igySeleccion).Text = "1" And Me.ClickSinEjecutar = False Then
                    dCantidad = valorNumerico(Me.GridRequisiones.Cell(Renglon, Me.igyDisponible).Text)
                    If dCantidad > 0 Then
                        Me.ClickSinEjecutar = True

                        Me.GridRequisiones.Cell(Renglon, Me.igyCantidad).Text = dCantidad.ToString

                        Me.ClickSinEjecutar = False
                    End If
                Else
                    Me.GridRequisiones.Cell(Renglon, Me.igyCantidad).Text = "0"
                End If
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Grid_CellChanging", ex)
        End Try
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Private Sub ConsultarDetalleRequisiciones(ByVal sCodigoAlmacen As String)
        Dim dTabla As DataTable
        Dim oRequisiciones As New Class_Requisiciones_Global

        Try
            dTabla = oRequisiciones.ObtieneArticulosRequeridos(sCodigoAlmacen)

            Me.GridRequisiones.AutoRedraw = False
            Me.GridRequisiones.Rows = 1

            For Each dRow As DataRow In dTabla.Rows
                Me.GridRequisiones.AddItem(dRow("CODIGO_ARTICULO").ToString & Chr(9) & dRow("DESCRIPCION").ToString & Chr(9) & dRow("DISPONIBLE").ToString & Chr(9) &
                                           dRow("CANTIDAD").ToString & Chr(9) & dRow("UNIDAD").ToString & Chr(9) & dRow("SELECCION").ToString & Chr(9))
            Next

            'No es posible hace un datasource y luego intentar cambiar datos de celdas con codigo, no marca error pero no hace el cambio
            dTabla.DefaultView.AllowDelete = False
            dTabla.DefaultView.AllowNew = False

            If dTabla.Rows.Count = 0 Then
                MsgBox("No hay artículos requeridos para el almacén.", MsgBoxStyle.Information, Me.Text)
            End If

            Me.FormateaGrid()

        Catch ex As Exception
            HandleError(Me.Name, "ConsultarDetalleRequisiciones", ex)
        Finally
            Me.GridRequisiones.AutoRedraw = True
            Me.GridRequisiones.Refresh()
        End Try
    End Sub

    Private Function AgregarDetalleRequisiciones() As Boolean
        Dim i As Integer, sArticulos As String = ""
        Dim oRequisiciones As New Class_Requisiciones_Global

        Try
            For i = 1 To Me.GridRequisiones.Rows - 1
                If Me.GridRequisiones.Cell(i, igySeleccion).Text = "1" Then
                    sArticulos = sArticulos & Me.GridRequisiones.Cell(i, Me.igyCodigoArticulo).Text & "," & Me.GridRequisiones.Cell(i, Me.igyCantidad).Text & "|"
                End If
            Next

            If txtLEN(sArticulos) = True Then
                sArticulos = sArticulos.Substring(0, sArticulos.Length - 1) 'Para quitarle el último pipe que sale sobrando.
            End If

            dArticulosRequeridos = oRequisiciones.ObtieneArticulosMultiplesRequisiciones(sArticulos)

            _bAgregado = True
        Catch ex As Exception
            HandleError(Me.Name, "AgregarDetalleRequisiciones", ex)
        End Try

        Return _bAgregado
    End Function

    Private Sub InicializaGrid()
        Try
            Me.GridRequisiones.DataSource = Nothing
            FG_Grid_Limpiar(GridRequisiones)

            Me.GridRequisiones.Rows = 2
            Me.GridRequisiones.Cols = 7
            Me.GridRequisiones.DisplayRowNumber = True

            Me.FormateaGrid()
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGrid", ex)
        End Try
    End Sub

    Private Sub FormateaGrid()
        Try
            With Me.GridRequisiones
                .Column(Me.igyCodigoArticulo).Width = 60
                .Column(Me.igyDescripcion).Width = 400
                .Column(Me.igyDisponible).Width = 100
                .Column(Me.igyCantidad).Width = 100
                .Column(Me.igyUnidad).Width = 40
                .Column(Me.igySeleccion).Width = 40

                .Cell(0, Me.igyCodigoArticulo).Text = "Código"
                .Cell(0, Me.igyDescripcion).Text = "Descripción"
                .Cell(0, Me.igyDisponible).Text = "Requerido"
                .Cell(0, Me.igyCantidad).Text = "Cantidad"
                .Cell(0, Me.igyUnidad).Text = "Unidad"

                .Column(Me.igyDisponible).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyDisponible).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.igyDisponible).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyCantidad).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyCantidad).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
                .Column(Me.igyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igySeleccion).CellType = FlexCell.CellTypeEnum.CheckBox

                .Column(Me.igyCodigoArticulo).Locked = True
                .Column(Me.igyDescripcion).Locked = True
                .Column(Me.igyDisponible).Locked = True
                .Column(Me.igyUnidad).Locked = True

                .Refresh()

            End With

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGrid", ex)
        End Try
    End Sub

#End Region

End Class