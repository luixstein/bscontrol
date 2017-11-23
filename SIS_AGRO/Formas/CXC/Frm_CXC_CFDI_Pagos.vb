Public Class Frm_CXC_CFDI_Pagos

#Region "Campos privados"
    Private _FOLIO_BANCO As String
    Private oBancoCXC As Class_Bancos_CXC
#End Region

#Region "Propiedades"

#End Region

#Region "Columnas grid pago"
    Private iGyPagoFOLIO As Integer = 1
    Private iGyPagoFECHA_PAGO As Integer = 2
    Private iGyPagoMONTO As Integer = 3
    Private iGyPagoMONEDA As Integer = 4
    Private iGyPagoCODIGO_CLIENTE As Integer = 5
    Private iGyPagoNOMBRE_CLIENTE As Integer = 6
    Private iGyPagoTIMBRADO As Integer = 7
#End Region

#Region "Columnas grid venta"
    Private iGyVentaFOLIO As Integer = 1
    Private iGyVentaMONEDA_DR As Integer = 2
    Private iGyVentaTIPO_CAMBIO_DR As Integer = 3
    Private iGyVentaMETODO_PAGO_DR As Integer = 4
    Private iGyVentaNUMERO_PARCIALIDAD As Integer = 5
    Private iGyVentaSALDO_ANTERIOR As Integer = 6
    Private iGyVentaIMPORTE_PAGADO As Integer = 7
    Private iGyVentaSALDO_INSOLUTO As Integer = 8
#End Region

#Region "Opciones"
    Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
        Me.Imprimir()
    End Sub

    Private Sub tsbTimbrar_Click(sender As Object, e As EventArgs) Handles tsbTimbrar.Click
        If Me.Timbrar = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbCancelarTimbre_Click(sender As Object, e As EventArgs) Handles tsbCancelarTimbre.Click
        If Me.CancelarTimbre() = True Then
            Me.Consultar()
        End If
    End Sub

    Private Sub tsbEnviarCorreo_Click(sender As Object, e As EventArgs) Handles tsbEnviarCorreo.Click
        Me.EnviarCorreo()
    End Sub

    Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "Constructor y destructor"
    Public Sub New(ByVal FOLIO_BANCO As String)
        Me.New()
        Try
            Me._FOLIO_BANCO = FOLIO_BANCO

            Me.Consultar()
        Catch ex As Exception
            HandleError(Me.Name, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Eventos de objetos"
    Private Sub GridPagos_MouseClick(sender As Object, e As MouseEventArgs) Handles GridPagos.MouseClick
        Me.ConsultarDetallePago()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub New()
        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Private Function Consultar() As Boolean
        Const sProcedure As String = "Consultar"
        Dim bResultado As Boolean = False
        Try
            oBancoCXC = New Class_Bancos_CXC(Me._FOLIO_BANCO)
            If oBancoCXC.Existe = False Then
                Return False
            End If

            Me.InicializaGridPagos()
            Me.GridPagos.DataSource = oBancoCXC.ObtenerPagosParaConsultaCFDI
            Me.FormateaGridPagos()

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
        Return bResultado
    End Function

    Private Sub FormateaGridPagos()
        Try
            With Me.GridPagos
                .AutoRedraw = False

                .Cell(0, Me.iGyPagoFOLIO).Text = "Folio pago"
                .Cell(0, Me.iGyPagoFECHA_PAGO).Text = "Fecha pago"
                .Cell(0, Me.iGyPagoMONTO).Text = "Monto"
                .Cell(0, Me.iGyPagoMONEDA).Text = "Moneda"
                .Cell(0, Me.iGyPagoCODIGO_CLIENTE).Text = "Cliente"
                .Cell(0, Me.iGyPagoNOMBRE_CLIENTE).Text = "Nombre"
                .Cell(0, Me.iGyPagoTIMBRADO).Text = "Timbrado ?"

                .Column(Me.iGyPagoNOMBRE_CLIENTE).Width = 250

                .Column(Me.iGyPagoFECHA_PAGO).CellType = FlexCell.CellTypeEnum.DateTime
                .Column(Me.iGyPagoFECHA_PAGO).FormatString = "dd-MMM-yy"

                .Column(Me.iGyPagoMONTO).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyPagoMONTO).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyPagoMONTO).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                .Column(Me.iGyPagoMONTO).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyPagoTIMBRADO).CellType = FlexCell.CellTypeEnum.CheckBox

                .Locked = True
            End With

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridPagos", ex)
        Finally
            Me.GridPagos.AutoRedraw = True
            Me.GridPagos.Refresh()
        End Try
    End Sub

    Private Function ConsultarDetallePago() As Boolean
        Const sProcedure As String = "ConsultarDetallePago"
        Dim bResultado As Boolean = False
        Try
            Dim sFolioPago As String = Me.GridPagos.Cell(Me.GridPagos.ActiveCell.Row, Me.iGyPagoFOLIO).Text
            Dim oPago As New Class_CXC_Pago_CFDI_Global(sFolioPago)

            If oPago.EXISTE = True Then
                Me.GridVentas.DataSource = Nothing
                Me.GridVentas.DataSource = oPago.ObtenerPagosDetalleParaConsultaCFDI
                Me.FormateaGridVentas()
            End If

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try
        Return bResultado
    End Function

    Private Sub InicializaGridPagos()
        Try
            Me.GridPagos.DataSource = Nothing
            Me.GridPagos.Rows = 2
        Catch ex As Exception
            HandleError(Me.Name, "InicializaGridPagos", ex)
        End Try
    End Sub

    Private Sub FormateaGridVentas()
        Try
            With Me.GridVentas
                .AutoRedraw = False

                .Cell(0, Me.iGyVentaFOLIO).Text = "Folio"
                .Cell(0, Me.iGyVentaMONEDA_DR).Text = "Moneda DR"
                .Cell(0, Me.iGyVentaTIPO_CAMBIO_DR).Text = "TpCam DR"
                .Cell(0, Me.iGyVentaMETODO_PAGO_DR).Text = "Método pago DR"
                .Cell(0, Me.iGyVentaNUMERO_PARCIALIDAD).Text = "Núm parcialidad"
                .Cell(0, Me.iGyVentaSALDO_ANTERIOR).Text = "Saldo anterior"
                .Cell(0, Me.iGyVentaIMPORTE_PAGADO).Text = "Importe pago"
                .Cell(0, Me.iGyVentaSALDO_INSOLUTO).Text = "Saldo insoluto"

                .Column(Me.iGyVentaMETODO_PAGO_DR).Width = 100

                .Column(Me.iGyVentaTIPO_CAMBIO_DR).FormatString = "###,###,##0.0000"
                .Column(Me.iGyVentaTIPO_CAMBIO_DR).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyVentaTIPO_CAMBIO_DR).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                .Column(Me.iGyVentaTIPO_CAMBIO_DR).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyVentaSALDO_ANTERIOR).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyVentaSALDO_ANTERIOR).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyVentaSALDO_ANTERIOR).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                .Column(Me.iGyVentaSALDO_ANTERIOR).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyVentaIMPORTE_PAGADO).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyVentaIMPORTE_PAGADO).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyVentaIMPORTE_PAGADO).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                .Column(Me.iGyVentaIMPORTE_PAGADO).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.iGyVentaSALDO_INSOLUTO).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.iGyVentaSALDO_INSOLUTO).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.iGyVentaSALDO_INSOLUTO).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
                .Column(Me.iGyVentaSALDO_INSOLUTO).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Locked = True
            End With

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridVentas", ex)
        Finally
            Me.GridVentas.AutoRedraw = True
            Me.GridVentas.Refresh()
        End Try
    End Sub

    Private Sub Imprimir()
        Try
            If Me.GridPagos.ActiveCell.Row <= 0 Then
                MsgBox("Debe seleccionar un pago.", MsgBoxStyle.Exclamation, Me.Name)
                Return
            End If

            Dim sFolioPago As String = Me.GridPagos.Cell(Me.GridPagos.ActiveCell.Row, Me.iGyPagoFOLIO).Text
            Dim oPago As New Class_CXC_Pago_CFDI_Global(sFolioPago)

            If oPago.EXISTE = True Then
                oPago.Imprimir()
            End If

        Catch ex As Exception
            HandleError(Me.Name, "Imprimir", ex)
        End Try
    End Sub

    Private Function Timbrar() As Boolean
        Const sProcedure As String = "Timbrar"
        Dim bResultado As Boolean = False

        Try
            MsgBox("falta...")
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function CancelarTimbre() As Boolean
        Const sProcedure As String = "CancelarTimbre"
        Dim bResultado As Boolean = False

        Try
            MsgBox("falta...")
        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Sub EnviarCorreo()
        Const sProcedure As String = "EnviarCorreo"
        Try
            Me.tsbEnviarCorreo.Enabled = False
            Me.tsbEnviarCorreo.Text = "Enviando..."
            Application.DoEvents()

            If Me.GridPagos.ActiveCell.Row <= 0 Then
                MsgBox("Debe seleccionar un pago.", MsgBoxStyle.Exclamation, Me.Name)
                Return
            End If

            Dim sFolioPago As String = Me.GridPagos.Cell(Me.GridPagos.ActiveCell.Row, Me.iGyPagoFOLIO).Text
            Dim oPago As New Class_CXC_Pago_CFDI_Global(sFolioPago)

            If oPago.EXISTE = True Then
                oPago.EnviarCorreo()
            End If

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        Finally
            Me.tsbEnviarCorreo.Text = "&Enviar correo"
            Me.tsbEnviarCorreo.Enabled = True
        End Try
        Application.DoEvents()
    End Sub

#End Region

End Class