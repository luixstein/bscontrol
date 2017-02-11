Option Strict On
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Public Class Frm_CXP_ControlPagos
    Private dt As New DataTable

    Private oCompras As New Class_Compras_Global

    Private iGyImagen As Integer = 1
    Private iGyRenglon As Integer = 2
    Private iGyFolioCO As Integer = 3
    Private iGyFolioOC As Integer = 4
    Private iGyEmbarque As Integer = 5
    Private iGyFecha As Integer = 6
    Private iGyFechaContraRecibo As Integer = 7
    Private iGyFechaProgamacion As Integer = 8
    Private iGyFacturaProveedor As Integer = 9
    Private iGyFechaProveedor As Integer = 10
    Private iGyTotal As Integer = 11
    Private iGySaldo As Integer = 12
    Private iGySeleccion As Integer = 13
    Private iGyPagar As Integer = 14
    Private iGyAutorizadoEl As Integer = 15
    Private iGyCodigoProveedor As Integer = 16

    Private ClickSinEjecutar As Boolean = False
    Private bConsultando As Boolean = False

#Region "Métodos y procedimientos"

    Private Sub DesplegarAlmacenes()
        Try
            Dim oAlmacenes As New Class_CatAlmacenes
            With Me.CboAlmacen
                .DisplayMember = "NOMBRE_ALMACEN"
                .ValueMember = "CODIGO_ALMACEN"
                Dim dView As New Data.DataView(oAlmacenes.ObtenerAlmacenes)
                dView.Sort = "NOMBRE_ALMACEN"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = Plaza.CODIGO_ALMACEN_PRINCIPAL 'Usuario.Codigo_Almacen
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAlmacenes", ex)
        End Try
    End Sub

    Private Sub DesplegarTipoGasto()
        Try
            Dim dt As DataTable

            Dim oGastos As New Class_Compras_Global
            With Me.cboTipoGasto
                .DisplayMember = "NOMBRE_TIPO_GASTO"
                .ValueMember = "CODIGO_TIPO_GASTO"
                dt = oGastos.ObtenerTiposGastos
                dt.Rows.Add(0, "TODOS")

                Dim dView As New Data.DataView(dt)
                dView.Sort = "NOMBRE_TIPO_GASTO"
                .DataSource = dView

                If dView.Count > 0 Then
                    .SelectedValue = 0
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarTipoGasto", ex)
        End Try
    End Sub

    Private Sub Inicializa()
        Me.txtCodigoProveedor.Text = ""
        Me.LblProveedor.Text = ""

        Me.txtTotal.Text = ""
        Me.txtSaldo.Text = ""
        Me.txtImporte.Text = ""
        Me.GroupBox1.Enabled = True
        Me.GroupBox2.Enabled = False
        Me.InicializaGrid()
    End Sub

    Private Sub InicializaGrid()
        Me.Grid1.DataSource = Nothing
        FG_Grid_Limpiar(Grid1)

        'Creamos el Grid
        Me.Grid1.Rows = 2
        Me.Grid1.Cols = 17
        Me.Grid1.DisplayRowNumber = True

        Me.FormateaGrid()
    End Sub

    Private Sub FormateaGrid()
        Me.Grid1.Column(Me.iGyFolioCO).Width = 75
        Me.Grid1.Column(Me.iGyFolioOC).Width = 75
        Me.Grid1.Column(Me.iGyEmbarque).Width = 75
        Me.Grid1.Column(Me.iGyFecha).Width = 70
        Me.Grid1.Column(Me.iGyFechaContraRecibo).Width = 90
        Me.Grid1.Column(Me.iGyFechaProgamacion).Width = 70
        Me.Grid1.Column(Me.iGyFacturaProveedor).Width = 70
        Me.Grid1.Column(Me.iGyFechaProveedor).Width = 70
        Me.Grid1.Column(Me.iGyTotal).Width = 94
        Me.Grid1.Column(Me.iGySaldo).Width = 94
        Me.Grid1.Column(Me.iGySeleccion).Width = 50
        Me.Grid1.Column(Me.iGyPagar).Width = 94
        Me.Grid1.Column(Me.iGyAutorizadoEl).Width = 70

        Me.Grid1.Cell(0, Me.iGyFolioCO).Text = "Folio(CO)"
        Me.Grid1.Cell(0, Me.iGyFolioOC).Text = "Folio(OC)"
        Me.Grid1.Cell(0, Me.iGyEmbarque).Text = "Embarque"
        Me.Grid1.Cell(0, Me.iGyFecha).Text = "Fecha"
        Me.Grid1.Cell(0, Me.iGyFechaContraRecibo).Text = "Fec.Contrarecibo"
        Me.Grid1.Cell(0, Me.iGyFechaProgamacion).Text = "Fec.Prog."
        Me.Grid1.Cell(0, Me.iGyFacturaProveedor).Text = "Proveedor"
        Me.Grid1.Cell(0, Me.iGyFechaProveedor).Text = "Fec.Prov."
        Me.Grid1.Cell(0, Me.iGyTotal).Text = "Total"
        Me.Grid1.Cell(0, Me.iGySaldo).Text = "Saldo"
        Me.Grid1.Cell(0, Me.iGySeleccion).Text = "Selec."
        Me.Grid1.Cell(0, Me.iGyPagar).Text = "Pagar"
        Me.Grid1.Cell(0, Me.iGyAutorizadoEl).Text = "Autorizado el"

        Me.Grid1.Column(Me.iGyFecha).CellType = FlexCell.CellTypeEnum.DateTime
        Me.Grid1.Column(Me.iGyFecha).FormatString = "dd-MMM-yy"

        Me.Grid1.Column(Me.iGyFechaContraRecibo).CellType = FlexCell.CellTypeEnum.DateTime
        Me.Grid1.Column(Me.iGyFechaContraRecibo).FormatString = "dd-MMM-yy"

        Me.Grid1.Column(Me.iGyFechaProgamacion).CellType = FlexCell.CellTypeEnum.DateTime
        Me.Grid1.Column(Me.iGyFechaProgamacion).FormatString = "dd-MMM-yy"

        Me.Grid1.Column(Me.iGyFechaProveedor).CellType = FlexCell.CellTypeEnum.DateTime
        Me.Grid1.Column(Me.iGyFechaProveedor).FormatString = "dd-MMM-yy"

        Me.Grid1.Column(Me.iGyAutorizadoEl).CellType = FlexCell.CellTypeEnum.DateTime
        Me.Grid1.Column(Me.iGyAutorizadoEl).FormatString = "dd-MMM-yy"

        Me.Grid1.Column(Me.iGyTotal).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        Me.Grid1.Column(Me.iGyTotal).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid1.Column(Me.iGyTotal).DecimalLength = 2
        Me.Grid1.Column(Me.iGyTotal).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid1.Column(Me.iGySaldo).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        Me.Grid1.Column(Me.iGySaldo).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid1.Column(Me.iGySaldo).DecimalLength = 2
        Me.Grid1.Column(Me.iGySaldo).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid1.Column(Me.iGyPagar).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        Me.Grid1.Column(Me.iGyPagar).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid1.Column(Me.iGyPagar).DecimalLength = 2
        Me.Grid1.Column(Me.iGyPagar).Alignment = FlexCell.AlignmentEnum.RightCenter

        'Me.Grid1.Column(Me.iGySeleccion).CellType = FlexCell.CellTypeEnum.CheckBox

        Me.Grid1.Refresh()
        Me.Grid1.Column(Me.iGyRenglon).Visible = False
        'Me.Grid1.Column(Me.iGyFolioCO).Locked = True
        'Me.Grid1.Column(Me.iGyFolioOC).Locked = True
        'Me.Grid1.Column(Me.iGyEmbarque).Locked = True
        'Me.Grid1.Column(Me.iGyFecha).Locked = True
        'Me.Grid1.Column(Me.iGyFechaContraRecibo).Locked = True
        'Me.Grid1.Column(Me.iGyFechaProgamacion).Locked = True
        'Me.Grid1.Column(Me.iGyFacturaProveedor).Locked = True
        'Me.Grid1.Column(Me.iGyFechaProveedor).Locked = True
        'Me.Grid1.Column(Me.iGyTotal).Locked = True
        'Me.Grid1.Column(Me.iGySaldo).Locked = True
        'Me.Grid1.Column(Me.iGySeleccion).Locked = False
        'Me.Grid1.Column(Me.iGyPagar).Locked = False
        'Me.Grid1.Column(Me.iGyAutorizadoEl).Locked = True
        Me.Grid1.Column(Me.iGyCodigoProveedor).Visible = False
    End Sub

    Private Sub LlenaGrid()
        Grid1.Rows = 1
        Grid1.Cols = 17
        Grid1.Rows = Me.dt.Rows.Count + 1

        Grid1.Row(0).Visible = True
        'Grid1.Column(0).Visible = False
        'Grid1.Column(2).Visible = False

        Grid1.SelectionMode = FlexCell.SelectionModeEnum.ByCell
        Grid1.DisplayFocusRect = False
        Grid1.ExtendLastCol = False
        Grid1.LockButton = True
        Grid1.ReadonlyFocusRect = FlexCell.FocusRectEnum.Solid
        Grid1.BorderStyle = FlexCell.BorderStyleEnum.Light3D
        Grid1.ScrollBars = FlexCell.ScrollBarsEnum.Vertical
        Grid1.BackColorBkg = SystemColors.Control
        Grid1.DefaultFont = New Font("Tahoma", 8)

        Grid1.Column(iGyImagen).Width = 18
        Grid1.Column(iGyImagen).Locked = True

        'Column 1
        With Grid1.Range(1, 1, Grid1.Rows - 1, 1)
            .Alignment = FlexCell.AlignmentEnum.CenterCenter
            .BackColor = Grid1.GridColor
        End With

        'Images
        'Dim Img As Bitmap
        'Img = New Bitmap("C:\_Fuentes\Agrinet_con_fletes\SIS_AGRO\Imagenes\Image1.bmp")
        ''Grid1.Images.Add(Class_Imagenes.IconoMas, "Image1")
        'Img = New Bitmap("C:\_Fuentes\Agrinet_con_fletes\SIS_AGRO\Imagenes\Image2.bmp")
        '' Grid1.Images.Add(Class_Imagenes.IconoMenos, "Image2")
        'Img.Dispose()
        ' Img = Nothing

        Dim i As Integer = 1

        Dim Rpt = Me.dt.AsEnumerable()
        Dim Proveedores = (From c In Rpt _
                    Select c!CODIGO_PROVEEDOR).Distinct()

        For Each rProv In Proveedores
            Dim sProveedor As String = rProv.ToString
            Dim renglones As DataRow() = Me.dt.Select("CODIGO_PROVEEDOR='" & sProveedor & "'")

            Me.Grid1.Cell(i, Me.iGyImagen).SetImage("Image2")
            Me.Grid1.Cell(i, Me.iGyRenglon).Text = (renglones.Count - 2).ToString
            Me.Grid1.Cell(i, Me.iGyFolioCO).Text = renglones(0)("GENERICO").ToString
            Me.Grid1.Cell(i, Me.iGyFolioCO).FontBold = True
            Me.Grid1.Cell(i, Me.iGyFacturaProveedor).Text = renglones(0)("FOLIO_PROVEEDOR").ToString
            Me.Grid1.Cell(i, Me.iGyCodigoProveedor).Text = renglones(0)("CODIGO_PROVEEDOR").ToString

            Me.Grid1.Range(i, Me.iGyFolioCO, i, Me.iGyFechaContraRecibo).Merge()
            Me.Grid1.Range(i, Me.iGyFolioCO, i, Me.iGyFechaContraRecibo).Locked = True

            'Me.Grid1.Cell(i, Me.iGyImagen).Locked = False
            Me.Grid1.Cell(i, Me.iGyFecha).Locked = True
            Me.Grid1.Cell(i, Me.iGyFechaContraRecibo).Locked = True
            Me.Grid1.Cell(i, Me.iGyFechaProgamacion).Locked = True
            Me.Grid1.Cell(i, Me.iGyFacturaProveedor).Locked = True
            Me.Grid1.Cell(i, Me.iGyFechaProveedor).Locked = True
            Me.Grid1.Cell(i, Me.iGyTotal).Locked = True
            Me.Grid1.Cell(i, Me.iGySaldo).Locked = True
            Me.Grid1.Cell(i, Me.iGySeleccion).Locked = True
            Me.Grid1.Cell(i, Me.iGyPagar).Locked = True
            Me.Grid1.Cell(i, Me.iGyAutorizadoEl).Locked = True

            Dim j As Integer = i + 1
            For Each dRow As DataRow In renglones.Skip(1)
                Me.Grid1.Cell(j, Me.iGyCodigoProveedor).Text = dRow("CODIGO_PROVEEDOR").ToString
                Me.Grid1.Cell(j, Me.iGyFolioCO).Text = dRow("GENERICO").ToString
                Me.Grid1.Cell(j, Me.iGyFolioOC).Text = dRow("FOLIO_OC").ToString
                Me.Grid1.Cell(j, Me.iGyEmbarque).Text = dRow("FOLIO_EMBARQUE").ToString
                Me.Grid1.Cell(j, Me.iGyFecha).Text = dRow("FECHA").ToString
                Me.Grid1.Cell(j, Me.iGyFechaContraRecibo).Text = dRow("FECHA_CONTRARECIBO").ToString
                Me.Grid1.Cell(j, Me.iGyFechaProgamacion).Text = dRow("FECHA_PROGRAMACION").ToString
                Me.Grid1.Cell(j, Me.iGyFacturaProveedor).Text = dRow("FOLIO_PROVEEDOR").ToString
                Me.Grid1.Cell(j, Me.iGyFechaProveedor).Text = dRow("FECHA_FACTURA_PROVEEDOR").ToString

                Me.Grid1.Cell(j, Me.iGyTotal).Text = dRow("TOTAL").ToString
                Me.Grid1.Cell(j, Me.iGySaldo).Text = dRow("SALDO").ToString
                Me.Grid1.Cell(j, Me.iGyPagar).Text = dRow("PAGAR").ToString
                If dRow("PAGAR").ToString <> "0.00" And dRow("GENERICO").ToString <> "TOTAL" Then
                    Me.Grid1.Cell(j, Me.iGySeleccion).Text = "1"
                End If

                Me.Grid1.Cell(j, Me.iGyAutorizadoEl).Text = dRow("AUTORIZADO_EL").ToString

                If dRow("GENERICO").ToString <> "TOTAL" Then
                    Me.Grid1.Cell(j, Me.iGySeleccion).CellType = FlexCell.CellTypeEnum.CheckBox
                Else
                    Me.Grid1.Cell(j, Me.iGySeleccion).Locked = True
                End If

                Me.Grid1.Cell(j, Me.iGyFolioCO).Locked = True
                Me.Grid1.Cell(j, Me.iGyFolioOC).Locked = True
                Me.Grid1.Cell(j, Me.iGyEmbarque).Locked = True
                Me.Grid1.Cell(j, Me.iGyFecha).Locked = True
                Me.Grid1.Cell(j, Me.iGyFechaContraRecibo).Locked = True
                Me.Grid1.Cell(j, Me.iGyFechaProgamacion).Locked = True
                Me.Grid1.Cell(j, Me.iGyFacturaProveedor).Locked = True
                Me.Grid1.Cell(j, Me.iGyFechaProveedor).Locked = True
                Me.Grid1.Cell(j, Me.iGyTotal).Locked = True
                Me.Grid1.Cell(j, Me.iGySaldo).Locked = True
                Me.Grid1.Cell(j, Me.iGySeleccion).Locked = False
                'Me.Grid1.Cell(j, Me.iGyPagar).Locked = False
                Me.Grid1.Cell(j, Me.iGyAutorizadoEl).Locked = True

                j += 1
            Next

            i = i + renglones.Count
        Next

        'Refresh
        Grid1.AutoRedraw = True
        Grid1.Refresh()
    End Sub

    Private Function CargaComprasConSaldo() As Boolean
        Dim dTabla As DataTable

        bConsultando = True

        Try
            Me.Grid1.DataSource = Nothing
            dTabla = oCompras.CargaComprashechas(Me.txtCodigoProveedor.Text, Me.cboTipoGasto.SelectedValue.ToString, Me.CboAlmacen.SelectedValue.ToString, "0")
            'Me.Grid1.Rows = 1
            'For Each dRow As DataRow In dTabla.Rows
            '    Me.Grid1.AddItem(Me.LblProveedor.Text & Chr(9) & dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & Format(CDate(dRow(3)), "dd-MMM-yyyy") & Chr(9) & dRow(4).ToString & Chr(9) & _
            '                     dRow(5).ToString & Chr(9) & dRow(6).ToString & Chr(9) & dRow(7).ToString & Chr(9) & dRow(8).ToString & Chr(9) & dRow(9).ToString & Chr(9) & dRow(10).ToString & Chr(9) & _
            '                     dRow(11).ToString & Chr(9) & dRow(12).ToString & Chr(9) & dRow(13).ToString & Chr(9) & dRow(14).ToString & Chr(9) & dRow(15).ToString & Chr(9) & dRow(16).ToString)
            'Next

            dt = New DataTable
            dt = dTabla

            If Me.dt.Rows.Count > 0 Then
                Me.LlenaGrid()
            End If

            CargaComprasConSaldo = True
            Me.FormateaGrid()
            Me.Totales()

        Catch ex As Exception
            HandleError(Me.Name, "CargaComprasConSaldo", ex)
        Finally
            bConsultando = False
        End Try
    End Function

    Private Sub Grid_CellChanging(ByVal Sender As Object, ByVal e As FlexCell.Grid.CellChangingEventArgs) Handles Grid1.CellChanging
        Try
            If bConsultando = True Then
                Exit Sub
            End If

            Dim Columna As Integer = e.Col, Renglon As Integer = e.Row, Provedor As String = ""
            Dim dPago As Double, dPagoProveedor As Double = 0

            Provedor = Me.Grid1.Cell(Renglon, Me.iGyCodigoProveedor).Text

            If e.Col = Me.iGySeleccion And e.Row > 0 Then
                If Me.Grid1.Cell(Renglon, Me.iGySeleccion).Text = "1" And Me.ClickSinEjecutar = False Then
                    dPago = valorNumerico(Me.Grid1.Cell(Renglon, Me.iGySaldo).Text)
                    If dPago > 0 Then
                        Me.ClickSinEjecutar = True
                        Me.Grid1.Cell(Renglon, Me.iGyPagar).Text = dPago.ToString
                        Me.ClickSinEjecutar = False
                        GestionaGrabar(Renglon)
                    End If
                Else
                    Me.Grid1.Cell(Renglon, Me.iGyPagar).Text = "0"
                    GestionaGrabar(Renglon)
                End If
            End If

            Dim i As Integer = 1
            For i = 1 To Me.Grid1.Rows - 1
                If Me.Grid1.Cell(i, Me.iGyFolioCO).Text <> "TOTAL" And Me.Grid1.Cell(i, Me.iGyCodigoProveedor).Text = Provedor Then
                    dPagoProveedor = dPagoProveedor + valorNumerico(Me.Grid1.Cell(i, Me.iGyPagar).Text)
                ElseIf Me.Grid1.Cell(i, Me.iGyFolioCO).Text = "TOTAL" And Me.Grid1.Cell(i, Me.iGyCodigoProveedor).Text = Provedor Then
                    Me.Grid1.Cell(i, Me.iGyPagar).Text = FormatImporteContable(dPagoProveedor)
                    dPagoProveedor = 0
                    Provedor = ""
                End If
            Next i


            Me.Totales()

        Catch ex As Exception
            HandleError(Me.Name, "Grid_CellChanging", ex)
        End Try
    End Sub

    Private Function GestionaGrabar(ByVal iRenglon As Integer) As Boolean
        Dim Renglon As Integer, dPago As Double = 0
        Renglon = iRenglon

        Dim oAutorizacionCXP As New Class_CXP_Autorizacion

        dPago = valorNumerico(Me.Grid1.Cell(Renglon, Me.iGyPagar).Text)

        If dPago >= 0 And txtLEN(Me.Grid1.Cell(Renglon, Me.iGyAutorizadoEl).Text) = True Then

            If dPago > valorNumerico(Me.Grid1.Cell(Renglon, Me.iGySaldo).Text) And Me.Grid1.Locked = False Then
                MsgBox("El pago en el renglón: " & Renglon & " es mayor al saldo de la compra favor de revisar.", MsgBoxStyle.Exclamation, "Validación de Importes de CXP")
                Me.Grid1.Cell(Renglon, Me.iGyPagar).SetFocus()
                'e.SuppressKeyPress = True
                Exit Function
            Else
                '**Nota importante, sólo si el importe cambió comparado con el que ya tenia la celda se grabará la información
                '(si habian tecleado 500 pesos y dieron enter, se graba, se refresca la columna de autorizado , y luego vuelven 
                'a dar enter en la columna de pagar con los mismo 500 pesos, como no cambiaron el dato no hay nada que actualizar, 
                'pero si ya hay una fecha de autorizado con 500 pesos y cambian a 600 y dan enter , esto es un cambio de importe, 
                'si procede ir a actualizar y refrescar fecha de autorizado)
                oAutorizacionCXP = New Class_CXP_Autorizacion(Me.Grid1.Cell(Renglon, Me.iGyFolioCO).Text)
                If oAutorizacionCXP.Existe = True Then
                    If oAutorizacionCXP.IMPORTE_AUTORIZADO <> valorNumerico(Me.Grid1.Cell(Renglon, Me.iGyPagar).Text) Then
                        oAutorizacionCXP.IMPORTE_AUTORIZADO = valorNumerico(Me.Grid1.Cell(Renglon, Me.iGyPagar).Text)
                        oAutorizacionCXP.Actualiza_Autorizacion()
                        Me.Grid1.Cell(Renglon, Me.iGyAutorizadoEl).Text = oAutorizacionCXP.FECHA_AUTORIZACION.ToString
                    End If
                End If
            End If
        ElseIf dPago > 0 And txtLEN(Me.Grid1.Cell(Renglon, Me.iGyAutorizadoEl).Text) = False Then
            oAutorizacionCXP = New Class_CXP_Autorizacion(Me.Grid1.Cell(Renglon, Me.iGyFolioCO).Text)
            oAutorizacionCXP.IMPORTE_AUTORIZADO = valorNumerico(Me.Grid1.Cell(Renglon, Me.iGyPagar).Text)
            oAutorizacionCXP.Inserta_Autorizacion()
            Me.Grid1.Cell(Renglon, Me.iGyAutorizadoEl).Text = oAutorizacionCXP.FECHA_AUTORIZACION.ToString
        End If

    End Function

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs) 'Handles Grid1.CellChanging
        Dim Columna As Integer, Renglon As Integer
        Dim StrCod As String, dImporte As Double ', dPago As Double
        Dim oAutorizacionCXP As New Class_CXP_Autorizacion

        Columna = Me.Grid1.Selection.FirstCol
        Renglon = Me.Grid1.Selection.FirstRow
        StrCod = Me.Grid1.Cell(Renglon, Me.iGyFolioCO).Text

        dImporte = valorNumerico(Me.Grid1.Cell(Renglon, Me.iGyPagar).Text)

        Select Case e.KeyCode
            Case Keys.Enter
                Select Case Columna
                    Case Me.iGyPagar
                        If Me.Grid1.Rows > Renglon + 1 Then
                            GestionaGrabar(Renglon)
                            'dPago = valorNumerico(Me.Grid1.Cell(Renglon, Me.iGyPagar).Text)
                            Me.Grid1.Cell(Renglon + 1, Me.iGySeleccion).SetFocus()
                        End If


                        'If dPago >= 0 And txtLEN(Me.Grid1.Cell(Renglon, Me.iGyAutorizadoEl).Text) = True Then

                        '    If dPago > valorNumerico(Me.Grid1.Cell(Renglon, Me.iGySaldo).Text) And Me.Grid1.Locked = False Then
                        '        MsgBox("El pago en el renglón: " & Renglon & " es mayor al saldo de la compra favor de revisar.", MsgBoxStyle.Exclamation, "Validación de Importes de CXP")
                        '        Me.Grid1.Cell(Renglon, Me.iGyPagar).SetFocus()
                        '        e.SuppressKeyPress = True
                        '        Exit Sub
                        '    Else
                        '        '**Nota importante, sólo si el importe cambió comparado con el que ya tenia la celda se grabará la información
                        '        '(si habian tecleado 500 pesos y dieron enter, se graba, se refresca la columna de autorizado , y luego vuelven 
                        '        'a dar enter en la columna de pagar con los mismo 500 pesos, como no cambiaron el dato no hay nada que actualizar, 
                        '        'pero si ya hay una fecha de autorizado con 500 pesos y cambian a 600 y dan enter , esto es un cambio de importe, 
                        '        'si procede ir a actualizar y refrescar fecha de autorizado)
                        '        oAutorizacionCXP = New Class_CXP_Autorizacion(Me.Grid1.Cell(Renglon, Me.iGyFolioCO).Text)
                        '        If oAutorizacionCXP.Existe = True Then
                        '            If oAutorizacionCXP.IMPORTE_AUTORIZADO <> valorNumerico(Me.Grid1.Cell(Renglon, Me.iGyPagar).Text) Then
                        '                oAutorizacionCXP.IMPORTE_AUTORIZADO = valorNumerico(Me.Grid1.Cell(Renglon, Me.iGyPagar).Text)
                        '                oAutorizacionCXP.Actualiza_Autorizacion()
                        '                Me.Grid1.Cell(Renglon, Me.iGyAutorizadoEl).Text = oAutorizacionCXP.FECHA_AUTORIZACION.ToString
                        '            End If

                        '        End If
                        '    End If
                        '    'ElseIf dPago <= 0 Then
                        '    '    MsgBox("La cantidad debe de ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
                        '    '    Me.Grid1.Cell(Renglon, Me.iGyPagar).SetFocus()
                        '    '    e.SuppressKeyPress = True
                        '    '    Exit Sub
                        'ElseIf dPago > 0 And txtLEN(Me.Grid1.Cell(Renglon, Me.iGyAutorizadoEl).Text) = False Then
                        '    oAutorizacionCXP = New Class_CXP_Autorizacion(Me.Grid1.Cell(Renglon, Me.iGyFolioCO).Text)
                        '    oAutorizacionCXP.IMPORTE_AUTORIZADO = valorNumerico(Me.Grid1.Cell(Renglon, Me.iGyPagar).Text)
                        '    oAutorizacionCXP.Inserta_Autorizacion()
                        '    Me.Grid1.Cell(Renglon, Me.iGyAutorizadoEl).Text = oAutorizacionCXP.FECHA_AUTORIZACION.ToString
                        'End If

                    Case Me.iGySeleccion
                        If Me.Grid1.Rows = Renglon + 1 Then
                            Me.Grid1.Rows = Me.Grid1.Rows + 1
                        End If

                End Select
                Me.Totales()

                Me.FormateaGrid()
        End Select
    End Sub

    Private Sub Totales()
        Try
            Dim dPago As Double = 0, dTotal As Double = 0, dSaldo As Double = 0
            Dim i As Integer = 1
            For i = 1 To Me.Grid1.Rows - 1
                If Me.Grid1.Cell(i, Me.iGyFolioCO).Text <> "TOTAL" Then
                    dPago = dPago + valorNumerico(Me.Grid1.Cell(i, Me.iGyPagar).Text)
                    dTotal = dTotal + valorNumerico(Me.Grid1.Cell(i, Me.iGyTotal).Text)
                    dSaldo = dSaldo + valorNumerico(Me.Grid1.Cell(i, Me.iGySaldo).Text)
                End If
            Next i

            Me.txtImporte.Text = FormatImporteContable(dPago)
            Me.txtTotal.Text = FormatImporteContable(dTotal)
            Me.txtSaldo.Text = FormatImporteContable(dSaldo)

        Catch ex As Exception
            HandleError(Me.Name, "Totales", ex)
        End Try
    End Sub

    Private Sub SetRowVisible(ByVal Row1 As Integer, ByVal Row2 As Integer, ByVal Value As Boolean)
        Dim i As Integer

        Grid1.AutoRedraw = False
        For i = Row1 To Row2
            Grid1.Row(i).Visible = Value
        Next
        Grid1.AutoRedraw = True
        Grid1.Refresh()
    End Sub
#End Region

    Private Sub Frm_CXP_ControlPagos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DesplegarAlmacenes()
        Me.DesplegarTipoGasto()
        Me.Inicializa()
    End Sub

    Private Sub txtCodigoProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoProveedor.KeyDown

        Select Case e.KeyCode
            Case Keys.F6
Buscar:
                Dim Busqueda = New Busqueda_General("CODIGO_PROVEEDOR AS CODIGO,NOMBRE_PROVEEDOR AS NOMBRE", "Cat_Proveedores", " 1=1 and Estatus='A' AND CODIGO_PLAZA=" & Usuario.Codigo_Plaza, "Nombre", "Nombre_Proveedor")
                Busqueda.ShowDialog()
                Me.txtCodigoProveedor.Text = "" & Busqueda.Tag.ToString
                Busqueda.Dispose()

            Case Keys.Enter
                If txtLEN(Me.txtCodigoProveedor.Text) = False Then
                    Me.LblProveedor.Text = ""
                    Me.btnConsultar.Focus()
                    'GoTo Buscar
                    Exit Sub
                End If
                Dim sql As New Class_find("Select NOMBRE_PROVEEDOR,CUENTA_CONTABLE,CUENTA_CONTABLE_DOLARES From CAT_PROVEEDORES Where CODIGO_PROVEEDOR='" & Me.txtCodigoProveedor.Text & "' and Estatus='A' AND CODIGO_PLAZA=" & Usuario.Codigo_Plaza)
                If sql.Result1 = "" Then
                    MsgBox("El código de proveedor que intenta buscar no existe o esta dado de baja, favor de intentar con otro código.", MsgBoxStyle.Exclamation, "Validación de Proveedores")
                    Me.LblProveedor.Text = ""
                    GoTo Buscar : Exit Sub
                Else
                    Me.LblProveedor.Text = sql.Result1
                    'Me.LblCuentaContableProveedor.Text = sql.Result2
                    If txtLEN(sql.Result2) = False Then
                        MsgBox("El proveedor no tiene cuenta contable asignda, favor de asignarle una.", MsgBoxStyle.Exclamation, "Validación de Proveedores")
                        Exit Sub
                    End If
                    Me.btnConsultar.Focus()
                End If
                sql = Nothing

            Case Keys.F4
                Dim Child As New Catalogo_Proveedores()
                Child.tsbNuevo.PerformClick()
                Child.ShowDialog()
                Child.Dispose()
        End Select

    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Me.GroupBox1.Enabled = False
        Me.CargaComprasConSaldo()
        Me.GroupBox2.Enabled = True
        Me.cboTipoGasto.Focus()
    End Sub

    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.txtCodigoProveedor.Focus()
    End Sub

    Private Sub Grid1_Click(ByVal Sender As Object, ByVal e As System.EventArgs) Handles Grid1.Click
        If Grid1.ActiveCell.ImageKey = "Image1" Then
            Grid1.ActiveCell.SetImage("Image2")

            SetRowVisible(Me.Grid1.ActiveCell.Row + 1, Me.Grid1.ActiveCell.Row + CInt(Me.Grid1.Cell(Me.Grid1.ActiveCell.Row, Me.iGyRenglon).Text), True)

        ElseIf Grid1.ActiveCell.ImageKey = "Image2" Then
            Grid1.ActiveCell.SetImage("Image1")

            SetRowVisible(Me.Grid1.ActiveCell.Row + 1, Me.Grid1.ActiveCell.Row + CInt(Me.Grid1.Cell(Me.Grid1.ActiveCell.Row, Me.iGyRenglon).Text), False)
        End If
    End Sub

    Private Sub Grid1_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid1.KeyDown
        Me.GestionaGrid(e)
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub txtCodigoProveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoProveedor.KeyPress
        txtNoBeep(e)
    End Sub
End Class