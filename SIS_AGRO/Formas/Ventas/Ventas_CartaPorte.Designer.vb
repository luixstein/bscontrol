<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ventas_CartaPorte
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ventas_CartaPorte))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.gbMercancias = New System.Windows.Forms.GroupBox()
        Me.txtEncabezadoMercanciasFake = New System.Windows.Forms.TextBox()
        Me.txtNombreUnidadPeso = New System.Windows.Forms.TextBox()
        Me.txtTotalPesoBruto = New System.Windows.Forms.TextBox()
        Me.txtTotalMercancias = New System.Windows.Forms.TextBox()
        Me.txtCodigoUnidadPeso = New System.Windows.Forms.TextBox()
        Me.lblDisplayUnidadPeso = New System.Windows.Forms.Label()
        Me.lblDisplayTotalPesoBruto = New System.Windows.Forms.Label()
        Me.lblDisplayTotalMercancias = New System.Windows.Forms.Label()
        Me.GridMercancias = New FlexCell.Grid()
        Me.cboTransporteInternacional = New System.Windows.Forms.ComboBox()
        Me.lblDisplayTransporteInternacional = New System.Windows.Forms.Label()
        Me.gbUbicaciones = New System.Windows.Forms.GroupBox()
        Me.txtEncabezadoUbicacionesaFake = New System.Windows.Forms.TextBox()
        Me.txtTotalDistanciaRecorrida = New System.Windows.Forms.TextBox()
        Me.lblDisplayTotalDistanciaRecorrida = New System.Windows.Forms.Label()
        Me.GridUbicaciones = New FlexCell.Grid()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.gbPartesTransporte = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.GridPartesTransporte = New FlexCell.Grid()
        Me.gbAutoTransporte = New System.Windows.Forms.GroupBox()
        Me.lblDisplayPrimaSeguro = New System.Windows.Forms.Label()
        Me.txtPrimaSeguro = New System.Windows.Forms.TextBox()
        Me.txtNombreTipoRemolque2 = New System.Windows.Forms.TextBox()
        Me.txtNombreTipoRemolque1 = New System.Windows.Forms.TextBox()
        Me.lblDisplayTipoRemolque2 = New System.Windows.Forms.Label()
        Me.txtTipoRemolque2 = New System.Windows.Forms.TextBox()
        Me.lblDisplayTipoRemolque1 = New System.Windows.Forms.Label()
        Me.txtTipoRemolque1 = New System.Windows.Forms.TextBox()
        Me.lblDisplayPlacaRemolque2 = New System.Windows.Forms.Label()
        Me.txtPlacaRemolque2 = New System.Windows.Forms.TextBox()
        Me.lblDisplayPlacaRemolque1 = New System.Windows.Forms.Label()
        Me.txtPlacaRemolque1 = New System.Windows.Forms.TextBox()
        Me.lblDisplayPolizaResposabilidadCivil = New System.Windows.Forms.Label()
        Me.txtPolizaResposabilidadCivil = New System.Windows.Forms.TextBox()
        Me.txtNumeroPermisoSCT = New System.Windows.Forms.TextBox()
        Me.lblDisplayCodigoPermisoSCT = New System.Windows.Forms.Label()
        Me.txtCodigoPermisoSCT = New System.Windows.Forms.TextBox()
        Me.txtNombreAutotransporte = New System.Windows.Forms.TextBox()
        Me.lblDisplayRemolque2 = New System.Windows.Forms.Label()
        Me.txtCodigoRemolque2 = New System.Windows.Forms.TextBox()
        Me.lblDisplayRemolque1 = New System.Windows.Forms.Label()
        Me.txtCodigoRemolque1 = New System.Windows.Forms.TextBox()
        Me.lblDisplayAseguradoraResponsabilidadCivil = New System.Windows.Forms.Label()
        Me.txtAseguradoraResponsabilidadCivil = New System.Windows.Forms.TextBox()
        Me.lblDisplayAutotransporte = New System.Windows.Forms.Label()
        Me.txtCodigoAutotransporte = New System.Windows.Forms.TextBox()
        Me.lblDisplayPlacaAutotransporte = New System.Windows.Forms.Label()
        Me.txtPlacaAutotransporte = New System.Windows.Forms.TextBox()
        Me.lblDisplayAño = New System.Windows.Forms.Label()
        Me.txtAño = New System.Windows.Forms.TextBox()
        Me.lblDisplayMarca = New System.Windows.Forms.Label()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.lblDisplayNombreVehiculo = New System.Windows.Forms.Label()
        Me.txtNombreVehiculo = New System.Windows.Forms.TextBox()
        Me.lblDisplayVehiculo = New System.Windows.Forms.Label()
        Me.txtCodigoVehiculo = New System.Windows.Forms.TextBox()
        Me.gbFigurasTransporte = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GridFigurasTransporte = New FlexCell.Grid()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.gbMercancias.SuspendLayout()
        Me.gbUbicaciones.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.gbPartesTransporte.SuspendLayout()
        Me.gbAutoTransporte.SuspendLayout()
        Me.gbFigurasTransporte.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(3, 30)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1210, 565)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.gbMercancias)
        Me.TabPage1.Controls.Add(Me.cboTransporteInternacional)
        Me.TabPage1.Controls.Add(Me.lblDisplayTransporteInternacional)
        Me.TabPage1.Controls.Add(Me.gbUbicaciones)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1202, 539)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Ubicaciones / Mercancias"
        '
        'gbMercancias
        '
        Me.gbMercancias.Controls.Add(Me.txtEncabezadoMercanciasFake)
        Me.gbMercancias.Controls.Add(Me.txtNombreUnidadPeso)
        Me.gbMercancias.Controls.Add(Me.txtTotalPesoBruto)
        Me.gbMercancias.Controls.Add(Me.txtTotalMercancias)
        Me.gbMercancias.Controls.Add(Me.txtCodigoUnidadPeso)
        Me.gbMercancias.Controls.Add(Me.lblDisplayUnidadPeso)
        Me.gbMercancias.Controls.Add(Me.lblDisplayTotalPesoBruto)
        Me.gbMercancias.Controls.Add(Me.lblDisplayTotalMercancias)
        Me.gbMercancias.Controls.Add(Me.GridMercancias)
        Me.gbMercancias.Location = New System.Drawing.Point(6, 209)
        Me.gbMercancias.Name = "gbMercancias"
        Me.gbMercancias.Size = New System.Drawing.Size(1188, 283)
        Me.gbMercancias.TabIndex = 2
        Me.gbMercancias.TabStop = False
        Me.gbMercancias.Text = "Mercancias"
        '
        'txtEncabezadoMercanciasFake
        '
        Me.txtEncabezadoMercanciasFake.Location = New System.Drawing.Point(68, 19)
        Me.txtEncabezadoMercanciasFake.Name = "txtEncabezadoMercanciasFake"
        Me.txtEncabezadoMercanciasFake.ReadOnly = True
        Me.txtEncabezadoMercanciasFake.Size = New System.Drawing.Size(992, 20)
        Me.txtEncabezadoMercanciasFake.TabIndex = 260
        Me.txtEncabezadoMercanciasFake.Text = "| BienTransportado | Descripcion | Cantidad | ClaveUnidad | Unidad | PesoEnKG |"
        Me.txtEncabezadoMercanciasFake.Visible = False
        '
        'txtNombreUnidadPeso
        '
        Me.txtNombreUnidadPeso.Location = New System.Drawing.Point(803, 258)
        Me.txtNombreUnidadPeso.Name = "txtNombreUnidadPeso"
        Me.txtNombreUnidadPeso.ReadOnly = True
        Me.txtNombreUnidadPeso.Size = New System.Drawing.Size(193, 20)
        Me.txtNombreUnidadPeso.TabIndex = 259
        '
        'txtTotalPesoBruto
        '
        Me.txtTotalPesoBruto.Location = New System.Drawing.Point(403, 258)
        Me.txtTotalPesoBruto.Name = "txtTotalPesoBruto"
        Me.txtTotalPesoBruto.ReadOnly = True
        Me.txtTotalPesoBruto.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalPesoBruto.TabIndex = 258
        Me.txtTotalPesoBruto.Text = "0.000"
        Me.txtTotalPesoBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalMercancias
        '
        Me.txtTotalMercancias.Location = New System.Drawing.Point(105, 258)
        Me.txtTotalMercancias.Name = "txtTotalMercancias"
        Me.txtTotalMercancias.ReadOnly = True
        Me.txtTotalMercancias.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalMercancias.TabIndex = 257
        Me.txtTotalMercancias.Text = "0"
        Me.txtTotalMercancias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCodigoUnidadPeso
        '
        Me.txtCodigoUnidadPeso.Location = New System.Drawing.Point(697, 258)
        Me.txtCodigoUnidadPeso.MaxLength = 10
        Me.txtCodigoUnidadPeso.Name = "txtCodigoUnidadPeso"
        Me.txtCodigoUnidadPeso.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigoUnidadPeso.TabIndex = 1
        '
        'lblDisplayUnidadPeso
        '
        Me.lblDisplayUnidadPeso.AutoSize = True
        Me.lblDisplayUnidadPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayUnidadPeso.Location = New System.Drawing.Point(605, 261)
        Me.lblDisplayUnidadPeso.Name = "lblDisplayUnidadPeso"
        Me.lblDisplayUnidadPeso.Size = New System.Drawing.Size(86, 13)
        Me.lblDisplayUnidadPeso.TabIndex = 254
        Me.lblDisplayUnidadPeso.Text = "Unidad peso :"
        '
        'lblDisplayTotalPesoBruto
        '
        Me.lblDisplayTotalPesoBruto.AutoSize = True
        Me.lblDisplayTotalPesoBruto.Location = New System.Drawing.Point(310, 261)
        Me.lblDisplayTotalPesoBruto.Name = "lblDisplayTotalPesoBruto"
        Me.lblDisplayTotalPesoBruto.Size = New System.Drawing.Size(87, 13)
        Me.lblDisplayTotalPesoBruto.TabIndex = 252
        Me.lblDisplayTotalPesoBruto.Text = "Peso bruto total :"
        '
        'lblDisplayTotalMercancias
        '
        Me.lblDisplayTotalMercancias.AutoSize = True
        Me.lblDisplayTotalMercancias.Location = New System.Drawing.Point(12, 261)
        Me.lblDisplayTotalMercancias.Name = "lblDisplayTotalMercancias"
        Me.lblDisplayTotalMercancias.Size = New System.Drawing.Size(97, 13)
        Me.lblDisplayTotalMercancias.TabIndex = 250
        Me.lblDisplayTotalMercancias.Text = "Total mercancias : "
        '
        'GridMercancias
        '
        Me.GridMercancias.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridMercancias.CheckedImage = CType(resources.GetObject("GridMercancias.CheckedImage"), System.Drawing.Bitmap)
        Me.GridMercancias.Cols = 1
        Me.GridMercancias.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridMercancias.DefaultRowHeight = CType(24, Short)
        Me.GridMercancias.DisplayRowNumber = True
        Me.GridMercancias.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridMercancias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridMercancias.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridMercancias.Location = New System.Drawing.Point(6, 19)
        Me.GridMercancias.LockButton = True
        Me.GridMercancias.Name = "GridMercancias"
        Me.GridMercancias.Rows = 9
        Me.GridMercancias.Size = New System.Drawing.Size(1176, 234)
        Me.GridMercancias.TabIndex = 0
        Me.GridMercancias.UncheckedImage = CType(resources.GetObject("GridMercancias.UncheckedImage"), System.Drawing.Bitmap)
        '
        'cboTransporteInternacional
        '
        Me.cboTransporteInternacional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTransporteInternacional.Enabled = False
        Me.cboTransporteInternacional.FormattingEnabled = True
        Me.cboTransporteInternacional.Location = New System.Drawing.Point(143, 19)
        Me.cboTransporteInternacional.Name = "cboTransporteInternacional"
        Me.cboTransporteInternacional.Size = New System.Drawing.Size(53, 21)
        Me.cboTransporteInternacional.TabIndex = 0
        '
        'lblDisplayTransporteInternacional
        '
        Me.lblDisplayTransporteInternacional.AutoSize = True
        Me.lblDisplayTransporteInternacional.Location = New System.Drawing.Point(9, 22)
        Me.lblDisplayTransporteInternacional.Name = "lblDisplayTransporteInternacional"
        Me.lblDisplayTransporteInternacional.Size = New System.Drawing.Size(128, 13)
        Me.lblDisplayTransporteInternacional.TabIndex = 223
        Me.lblDisplayTransporteInternacional.Text = "Transporte Internacional :"
        '
        'gbUbicaciones
        '
        Me.gbUbicaciones.Controls.Add(Me.txtEncabezadoUbicacionesaFake)
        Me.gbUbicaciones.Controls.Add(Me.txtTotalDistanciaRecorrida)
        Me.gbUbicaciones.Controls.Add(Me.lblDisplayTotalDistanciaRecorrida)
        Me.gbUbicaciones.Controls.Add(Me.GridUbicaciones)
        Me.gbUbicaciones.Location = New System.Drawing.Point(6, 46)
        Me.gbUbicaciones.Name = "gbUbicaciones"
        Me.gbUbicaciones.Size = New System.Drawing.Size(1188, 154)
        Me.gbUbicaciones.TabIndex = 1
        Me.gbUbicaciones.TabStop = False
        Me.gbUbicaciones.Text = "Ubicaciones"
        '
        'txtEncabezadoUbicacionesaFake
        '
        Me.txtEncabezadoUbicacionesaFake.Location = New System.Drawing.Point(68, 19)
        Me.txtEncabezadoUbicacionesaFake.Name = "txtEncabezadoUbicacionesaFake"
        Me.txtEncabezadoUbicacionesaFake.ReadOnly = True
        Me.txtEncabezadoUbicacionesaFake.Size = New System.Drawing.Size(992, 20)
        Me.txtEncabezadoUbicacionesaFake.TabIndex = 258
        Me.txtEncabezadoUbicacionesaFake.Text = "| TipoUbicacion | CodigoUbicacion | Nombre | DistRecorrida | FechaHoraSalidaLlega" &
    "da | Domicilio(pegar calle,num,etc) |"
        Me.txtEncabezadoUbicacionesaFake.Visible = False
        '
        'txtTotalDistanciaRecorrida
        '
        Me.txtTotalDistanciaRecorrida.Location = New System.Drawing.Point(320, 126)
        Me.txtTotalDistanciaRecorrida.Name = "txtTotalDistanciaRecorrida"
        Me.txtTotalDistanciaRecorrida.ReadOnly = True
        Me.txtTotalDistanciaRecorrida.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalDistanciaRecorrida.TabIndex = 256
        Me.txtTotalDistanciaRecorrida.Text = "0.00"
        Me.txtTotalDistanciaRecorrida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayTotalDistanciaRecorrida
        '
        Me.lblDisplayTotalDistanciaRecorrida.AutoSize = True
        Me.lblDisplayTotalDistanciaRecorrida.Location = New System.Drawing.Point(171, 129)
        Me.lblDisplayTotalDistanciaRecorrida.Name = "lblDisplayTotalDistanciaRecorrida"
        Me.lblDisplayTotalDistanciaRecorrida.Size = New System.Drawing.Size(150, 13)
        Me.lblDisplayTotalDistanciaRecorrida.TabIndex = 248
        Me.lblDisplayTotalDistanciaRecorrida.Text = "Total distancia recorrida (Km) :"
        '
        'GridUbicaciones
        '
        Me.GridUbicaciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridUbicaciones.CheckedImage = CType(resources.GetObject("GridUbicaciones.CheckedImage"), System.Drawing.Bitmap)
        Me.GridUbicaciones.Cols = 1
        Me.GridUbicaciones.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridUbicaciones.DefaultRowHeight = CType(24, Short)
        Me.GridUbicaciones.DisplayRowNumber = True
        Me.GridUbicaciones.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridUbicaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridUbicaciones.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridUbicaciones.Location = New System.Drawing.Point(6, 19)
        Me.GridUbicaciones.LockButton = True
        Me.GridUbicaciones.Name = "GridUbicaciones"
        Me.GridUbicaciones.Rows = 4
        Me.GridUbicaciones.Size = New System.Drawing.Size(1176, 101)
        Me.GridUbicaciones.TabIndex = 0
        Me.GridUbicaciones.UncheckedImage = CType(resources.GetObject("GridUbicaciones.UncheckedImage"), System.Drawing.Bitmap)
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.gbPartesTransporte)
        Me.TabPage2.Controls.Add(Me.gbAutoTransporte)
        Me.TabPage2.Controls.Add(Me.gbFigurasTransporte)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1202, 539)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Autotransporte / Figura Transporte"
        '
        'gbPartesTransporte
        '
        Me.gbPartesTransporte.Controls.Add(Me.TextBox2)
        Me.gbPartesTransporte.Controls.Add(Me.GridPartesTransporte)
        Me.gbPartesTransporte.Location = New System.Drawing.Point(3, 332)
        Me.gbPartesTransporte.Name = "gbPartesTransporte"
        Me.gbPartesTransporte.Size = New System.Drawing.Size(1169, 140)
        Me.gbPartesTransporte.TabIndex = 2
        Me.gbPartesTransporte.TabStop = False
        Me.gbPartesTransporte.Text = "Partes de transporte"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(72, 19)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(992, 20)
        Me.TextBox2.TabIndex = 260
        Me.TextBox2.Text = "|CodigoFigura|NombreFigura|CodigoParteTransporte|NombreParteTransporte|"
        Me.TextBox2.Visible = False
        '
        'GridPartesTransporte
        '
        Me.GridPartesTransporte.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridPartesTransporte.CheckedImage = CType(resources.GetObject("GridPartesTransporte.CheckedImage"), System.Drawing.Bitmap)
        Me.GridPartesTransporte.Cols = 1
        Me.GridPartesTransporte.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridPartesTransporte.DefaultRowHeight = CType(24, Short)
        Me.GridPartesTransporte.DisplayRowNumber = True
        Me.GridPartesTransporte.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridPartesTransporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridPartesTransporte.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridPartesTransporte.Location = New System.Drawing.Point(6, 19)
        Me.GridPartesTransporte.LockButton = True
        Me.GridPartesTransporte.Name = "GridPartesTransporte"
        Me.GridPartesTransporte.Rows = 4
        Me.GridPartesTransporte.Size = New System.Drawing.Size(1157, 111)
        Me.GridPartesTransporte.TabIndex = 0
        Me.GridPartesTransporte.UncheckedImage = CType(resources.GetObject("GridPartesTransporte.UncheckedImage"), System.Drawing.Bitmap)
        '
        'gbAutoTransporte
        '
        Me.gbAutoTransporte.BackColor = System.Drawing.SystemColors.Control
        Me.gbAutoTransporte.Controls.Add(Me.lblDisplayPrimaSeguro)
        Me.gbAutoTransporte.Controls.Add(Me.txtPrimaSeguro)
        Me.gbAutoTransporte.Controls.Add(Me.txtNombreTipoRemolque2)
        Me.gbAutoTransporte.Controls.Add(Me.txtNombreTipoRemolque1)
        Me.gbAutoTransporte.Controls.Add(Me.lblDisplayTipoRemolque2)
        Me.gbAutoTransporte.Controls.Add(Me.txtTipoRemolque2)
        Me.gbAutoTransporte.Controls.Add(Me.lblDisplayTipoRemolque1)
        Me.gbAutoTransporte.Controls.Add(Me.txtTipoRemolque1)
        Me.gbAutoTransporte.Controls.Add(Me.lblDisplayPlacaRemolque2)
        Me.gbAutoTransporte.Controls.Add(Me.txtPlacaRemolque2)
        Me.gbAutoTransporte.Controls.Add(Me.lblDisplayPlacaRemolque1)
        Me.gbAutoTransporte.Controls.Add(Me.txtPlacaRemolque1)
        Me.gbAutoTransporte.Controls.Add(Me.lblDisplayPolizaResposabilidadCivil)
        Me.gbAutoTransporte.Controls.Add(Me.txtPolizaResposabilidadCivil)
        Me.gbAutoTransporte.Controls.Add(Me.txtNumeroPermisoSCT)
        Me.gbAutoTransporte.Controls.Add(Me.lblDisplayCodigoPermisoSCT)
        Me.gbAutoTransporte.Controls.Add(Me.txtCodigoPermisoSCT)
        Me.gbAutoTransporte.Controls.Add(Me.txtNombreAutotransporte)
        Me.gbAutoTransporte.Controls.Add(Me.lblDisplayRemolque2)
        Me.gbAutoTransporte.Controls.Add(Me.txtCodigoRemolque2)
        Me.gbAutoTransporte.Controls.Add(Me.lblDisplayRemolque1)
        Me.gbAutoTransporte.Controls.Add(Me.txtCodigoRemolque1)
        Me.gbAutoTransporte.Controls.Add(Me.lblDisplayAseguradoraResponsabilidadCivil)
        Me.gbAutoTransporte.Controls.Add(Me.txtAseguradoraResponsabilidadCivil)
        Me.gbAutoTransporte.Controls.Add(Me.lblDisplayAutotransporte)
        Me.gbAutoTransporte.Controls.Add(Me.txtCodigoAutotransporte)
        Me.gbAutoTransporte.Controls.Add(Me.lblDisplayPlacaAutotransporte)
        Me.gbAutoTransporte.Controls.Add(Me.txtPlacaAutotransporte)
        Me.gbAutoTransporte.Controls.Add(Me.lblDisplayAño)
        Me.gbAutoTransporte.Controls.Add(Me.txtAño)
        Me.gbAutoTransporte.Controls.Add(Me.lblDisplayMarca)
        Me.gbAutoTransporte.Controls.Add(Me.txtMarca)
        Me.gbAutoTransporte.Controls.Add(Me.lblDisplayNombreVehiculo)
        Me.gbAutoTransporte.Controls.Add(Me.txtNombreVehiculo)
        Me.gbAutoTransporte.Controls.Add(Me.lblDisplayVehiculo)
        Me.gbAutoTransporte.Controls.Add(Me.txtCodigoVehiculo)
        Me.gbAutoTransporte.Location = New System.Drawing.Point(6, 6)
        Me.gbAutoTransporte.Name = "gbAutoTransporte"
        Me.gbAutoTransporte.Size = New System.Drawing.Size(1169, 153)
        Me.gbAutoTransporte.TabIndex = 0
        Me.gbAutoTransporte.TabStop = False
        Me.gbAutoTransporte.Text = "Autotransporte"
        '
        'lblDisplayPrimaSeguro
        '
        Me.lblDisplayPrimaSeguro.AutoSize = True
        Me.lblDisplayPrimaSeguro.Location = New System.Drawing.Point(492, 74)
        Me.lblDisplayPrimaSeguro.Name = "lblDisplayPrimaSeguro"
        Me.lblDisplayPrimaSeguro.Size = New System.Drawing.Size(74, 13)
        Me.lblDisplayPrimaSeguro.TabIndex = 260
        Me.lblDisplayPrimaSeguro.Text = "Prima seguro :"
        '
        'txtPrimaSeguro
        '
        Me.txtPrimaSeguro.Location = New System.Drawing.Point(566, 71)
        Me.txtPrimaSeguro.Name = "txtPrimaSeguro"
        Me.txtPrimaSeguro.ReadOnly = True
        Me.txtPrimaSeguro.Size = New System.Drawing.Size(83, 20)
        Me.txtPrimaSeguro.TabIndex = 259
        Me.txtPrimaSeguro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNombreTipoRemolque2
        '
        Me.txtNombreTipoRemolque2.Location = New System.Drawing.Point(517, 123)
        Me.txtNombreTipoRemolque2.Name = "txtNombreTipoRemolque2"
        Me.txtNombreTipoRemolque2.ReadOnly = True
        Me.txtNombreTipoRemolque2.Size = New System.Drawing.Size(189, 20)
        Me.txtNombreTipoRemolque2.TabIndex = 258
        '
        'txtNombreTipoRemolque1
        '
        Me.txtNombreTipoRemolque1.Location = New System.Drawing.Point(517, 97)
        Me.txtNombreTipoRemolque1.Name = "txtNombreTipoRemolque1"
        Me.txtNombreTipoRemolque1.ReadOnly = True
        Me.txtNombreTipoRemolque1.Size = New System.Drawing.Size(189, 20)
        Me.txtNombreTipoRemolque1.TabIndex = 257
        '
        'lblDisplayTipoRemolque2
        '
        Me.lblDisplayTipoRemolque2.AutoSize = True
        Me.lblDisplayTipoRemolque2.Location = New System.Drawing.Point(342, 126)
        Me.lblDisplayTipoRemolque2.Name = "lblDisplayTipoRemolque2"
        Me.lblDisplayTipoRemolque2.Size = New System.Drawing.Size(80, 13)
        Me.lblDisplayTipoRemolque2.TabIndex = 256
        Me.lblDisplayTipoRemolque2.Text = "Tipo remolque :"
        '
        'txtTipoRemolque2
        '
        Me.txtTipoRemolque2.Location = New System.Drawing.Point(428, 123)
        Me.txtTipoRemolque2.Name = "txtTipoRemolque2"
        Me.txtTipoRemolque2.ReadOnly = True
        Me.txtTipoRemolque2.Size = New System.Drawing.Size(83, 20)
        Me.txtTipoRemolque2.TabIndex = 255
        '
        'lblDisplayTipoRemolque1
        '
        Me.lblDisplayTipoRemolque1.AutoSize = True
        Me.lblDisplayTipoRemolque1.Location = New System.Drawing.Point(342, 100)
        Me.lblDisplayTipoRemolque1.Name = "lblDisplayTipoRemolque1"
        Me.lblDisplayTipoRemolque1.Size = New System.Drawing.Size(80, 13)
        Me.lblDisplayTipoRemolque1.TabIndex = 254
        Me.lblDisplayTipoRemolque1.Text = "Tipo remolque :"
        '
        'txtTipoRemolque1
        '
        Me.txtTipoRemolque1.Location = New System.Drawing.Point(428, 97)
        Me.txtTipoRemolque1.Name = "txtTipoRemolque1"
        Me.txtTipoRemolque1.ReadOnly = True
        Me.txtTipoRemolque1.Size = New System.Drawing.Size(83, 20)
        Me.txtTipoRemolque1.TabIndex = 253
        '
        'lblDisplayPlacaRemolque2
        '
        Me.lblDisplayPlacaRemolque2.AutoSize = True
        Me.lblDisplayPlacaRemolque2.Location = New System.Drawing.Point(199, 126)
        Me.lblDisplayPlacaRemolque2.Name = "lblDisplayPlacaRemolque2"
        Me.lblDisplayPlacaRemolque2.Size = New System.Drawing.Size(40, 13)
        Me.lblDisplayPlacaRemolque2.TabIndex = 252
        Me.lblDisplayPlacaRemolque2.Text = "Placa :"
        '
        'txtPlacaRemolque2
        '
        Me.txtPlacaRemolque2.Location = New System.Drawing.Point(245, 123)
        Me.txtPlacaRemolque2.Name = "txtPlacaRemolque2"
        Me.txtPlacaRemolque2.ReadOnly = True
        Me.txtPlacaRemolque2.Size = New System.Drawing.Size(83, 20)
        Me.txtPlacaRemolque2.TabIndex = 251
        '
        'lblDisplayPlacaRemolque1
        '
        Me.lblDisplayPlacaRemolque1.AutoSize = True
        Me.lblDisplayPlacaRemolque1.Location = New System.Drawing.Point(199, 100)
        Me.lblDisplayPlacaRemolque1.Name = "lblDisplayPlacaRemolque1"
        Me.lblDisplayPlacaRemolque1.Size = New System.Drawing.Size(40, 13)
        Me.lblDisplayPlacaRemolque1.TabIndex = 250
        Me.lblDisplayPlacaRemolque1.Text = "Placa :"
        '
        'txtPlacaRemolque1
        '
        Me.txtPlacaRemolque1.Location = New System.Drawing.Point(245, 97)
        Me.txtPlacaRemolque1.Name = "txtPlacaRemolque1"
        Me.txtPlacaRemolque1.ReadOnly = True
        Me.txtPlacaRemolque1.Size = New System.Drawing.Size(83, 20)
        Me.txtPlacaRemolque1.TabIndex = 249
        '
        'lblDisplayPolizaResposabilidadCivil
        '
        Me.lblDisplayPolizaResposabilidadCivil.AutoSize = True
        Me.lblDisplayPolizaResposabilidadCivil.Location = New System.Drawing.Point(341, 74)
        Me.lblDisplayPolizaResposabilidadCivil.Name = "lblDisplayPolizaResposabilidadCivil"
        Me.lblDisplayPolizaResposabilidadCivil.Size = New System.Drawing.Size(41, 13)
        Me.lblDisplayPolizaResposabilidadCivil.TabIndex = 248
        Me.lblDisplayPolizaResposabilidadCivil.Text = "Póliza :"
        '
        'txtPolizaResposabilidadCivil
        '
        Me.txtPolizaResposabilidadCivil.Location = New System.Drawing.Point(388, 71)
        Me.txtPolizaResposabilidadCivil.Name = "txtPolizaResposabilidadCivil"
        Me.txtPolizaResposabilidadCivil.ReadOnly = True
        Me.txtPolizaResposabilidadCivil.Size = New System.Drawing.Size(83, 20)
        Me.txtPolizaResposabilidadCivil.TabIndex = 247
        '
        'txtNumeroPermisoSCT
        '
        Me.txtNumeroPermisoSCT.Location = New System.Drawing.Point(734, 45)
        Me.txtNumeroPermisoSCT.Name = "txtNumeroPermisoSCT"
        Me.txtNumeroPermisoSCT.ReadOnly = True
        Me.txtNumeroPermisoSCT.Size = New System.Drawing.Size(143, 20)
        Me.txtNumeroPermisoSCT.TabIndex = 246
        '
        'lblDisplayCodigoPermisoSCT
        '
        Me.lblDisplayCodigoPermisoSCT.AutoSize = True
        Me.lblDisplayCodigoPermisoSCT.Location = New System.Drawing.Point(571, 48)
        Me.lblDisplayCodigoPermisoSCT.Name = "lblDisplayCodigoPermisoSCT"
        Me.lblDisplayCodigoPermisoSCT.Size = New System.Drawing.Size(74, 13)
        Me.lblDisplayCodigoPermisoSCT.TabIndex = 245
        Me.lblDisplayCodigoPermisoSCT.Text = "Permiso SCT :"
        '
        'txtCodigoPermisoSCT
        '
        Me.txtCodigoPermisoSCT.Location = New System.Drawing.Point(645, 45)
        Me.txtCodigoPermisoSCT.Name = "txtCodigoPermisoSCT"
        Me.txtCodigoPermisoSCT.ReadOnly = True
        Me.txtCodigoPermisoSCT.Size = New System.Drawing.Size(83, 20)
        Me.txtCodigoPermisoSCT.TabIndex = 244
        '
        'txtNombreAutotransporte
        '
        Me.txtNombreAutotransporte.Location = New System.Drawing.Point(177, 45)
        Me.txtNombreAutotransporte.Name = "txtNombreAutotransporte"
        Me.txtNombreAutotransporte.ReadOnly = True
        Me.txtNombreAutotransporte.Size = New System.Drawing.Size(389, 20)
        Me.txtNombreAutotransporte.TabIndex = 243
        '
        'lblDisplayRemolque2
        '
        Me.lblDisplayRemolque2.AutoSize = True
        Me.lblDisplayRemolque2.Location = New System.Drawing.Point(6, 126)
        Me.lblDisplayRemolque2.Name = "lblDisplayRemolque2"
        Me.lblDisplayRemolque2.Size = New System.Drawing.Size(70, 13)
        Me.lblDisplayRemolque2.TabIndex = 242
        Me.lblDisplayRemolque2.Text = "Remolque 2 :"
        '
        'txtCodigoRemolque2
        '
        Me.txtCodigoRemolque2.Location = New System.Drawing.Point(88, 123)
        Me.txtCodigoRemolque2.MaxLength = 10
        Me.txtCodigoRemolque2.Name = "txtCodigoRemolque2"
        Me.txtCodigoRemolque2.Size = New System.Drawing.Size(83, 20)
        Me.txtCodigoRemolque2.TabIndex = 2
        '
        'lblDisplayRemolque1
        '
        Me.lblDisplayRemolque1.AutoSize = True
        Me.lblDisplayRemolque1.Location = New System.Drawing.Point(6, 100)
        Me.lblDisplayRemolque1.Name = "lblDisplayRemolque1"
        Me.lblDisplayRemolque1.Size = New System.Drawing.Size(70, 13)
        Me.lblDisplayRemolque1.TabIndex = 240
        Me.lblDisplayRemolque1.Text = "Remolque 1 :"
        '
        'txtCodigoRemolque1
        '
        Me.txtCodigoRemolque1.Location = New System.Drawing.Point(88, 97)
        Me.txtCodigoRemolque1.MaxLength = 10
        Me.txtCodigoRemolque1.Name = "txtCodigoRemolque1"
        Me.txtCodigoRemolque1.Size = New System.Drawing.Size(83, 20)
        Me.txtCodigoRemolque1.TabIndex = 1
        '
        'lblDisplayAseguradoraResponsabilidadCivil
        '
        Me.lblDisplayAseguradoraResponsabilidadCivil.AutoSize = True
        Me.lblDisplayAseguradoraResponsabilidadCivil.Location = New System.Drawing.Point(6, 74)
        Me.lblDisplayAseguradoraResponsabilidadCivil.Name = "lblDisplayAseguradoraResponsabilidadCivil"
        Me.lblDisplayAseguradoraResponsabilidadCivil.Size = New System.Drawing.Size(73, 13)
        Me.lblDisplayAseguradoraResponsabilidadCivil.TabIndex = 238
        Me.lblDisplayAseguradoraResponsabilidadCivil.Text = "Aseguradora :"
        '
        'txtAseguradoraResponsabilidadCivil
        '
        Me.txtAseguradoraResponsabilidadCivil.Location = New System.Drawing.Point(88, 71)
        Me.txtAseguradoraResponsabilidadCivil.Name = "txtAseguradoraResponsabilidadCivil"
        Me.txtAseguradoraResponsabilidadCivil.ReadOnly = True
        Me.txtAseguradoraResponsabilidadCivil.Size = New System.Drawing.Size(240, 20)
        Me.txtAseguradoraResponsabilidadCivil.TabIndex = 237
        '
        'lblDisplayAutotransporte
        '
        Me.lblDisplayAutotransporte.AutoSize = True
        Me.lblDisplayAutotransporte.Location = New System.Drawing.Point(6, 48)
        Me.lblDisplayAutotransporte.Name = "lblDisplayAutotransporte"
        Me.lblDisplayAutotransporte.Size = New System.Drawing.Size(64, 13)
        Me.lblDisplayAutotransporte.TabIndex = 236
        Me.lblDisplayAutotransporte.Text = "Transporte :"
        '
        'txtCodigoAutotransporte
        '
        Me.txtCodigoAutotransporte.Location = New System.Drawing.Point(88, 45)
        Me.txtCodigoAutotransporte.Name = "txtCodigoAutotransporte"
        Me.txtCodigoAutotransporte.ReadOnly = True
        Me.txtCodigoAutotransporte.Size = New System.Drawing.Size(83, 20)
        Me.txtCodigoAutotransporte.TabIndex = 235
        '
        'lblDisplayPlacaAutotransporte
        '
        Me.lblDisplayPlacaAutotransporte.AutoSize = True
        Me.lblDisplayPlacaAutotransporte.Location = New System.Drawing.Point(870, 22)
        Me.lblDisplayPlacaAutotransporte.Name = "lblDisplayPlacaAutotransporte"
        Me.lblDisplayPlacaAutotransporte.Size = New System.Drawing.Size(40, 13)
        Me.lblDisplayPlacaAutotransporte.TabIndex = 234
        Me.lblDisplayPlacaAutotransporte.Text = "Placa :"
        '
        'txtPlacaAutotransporte
        '
        Me.txtPlacaAutotransporte.Location = New System.Drawing.Point(916, 19)
        Me.txtPlacaAutotransporte.Name = "txtPlacaAutotransporte"
        Me.txtPlacaAutotransporte.ReadOnly = True
        Me.txtPlacaAutotransporte.Size = New System.Drawing.Size(83, 20)
        Me.txtPlacaAutotransporte.TabIndex = 233
        '
        'lblDisplayAño
        '
        Me.lblDisplayAño.AutoSize = True
        Me.lblDisplayAño.Location = New System.Drawing.Point(740, 22)
        Me.lblDisplayAño.Name = "lblDisplayAño"
        Me.lblDisplayAño.Size = New System.Drawing.Size(32, 13)
        Me.lblDisplayAño.TabIndex = 232
        Me.lblDisplayAño.Text = "Año :"
        '
        'txtAño
        '
        Me.txtAño.Location = New System.Drawing.Point(781, 19)
        Me.txtAño.Name = "txtAño"
        Me.txtAño.ReadOnly = True
        Me.txtAño.Size = New System.Drawing.Size(83, 20)
        Me.txtAño.TabIndex = 231
        '
        'lblDisplayMarca
        '
        Me.lblDisplayMarca.AutoSize = True
        Me.lblDisplayMarca.Location = New System.Drawing.Point(523, 22)
        Me.lblDisplayMarca.Name = "lblDisplayMarca"
        Me.lblDisplayMarca.Size = New System.Drawing.Size(43, 13)
        Me.lblDisplayMarca.TabIndex = 230
        Me.lblDisplayMarca.Text = "Marca :"
        '
        'txtMarca
        '
        Me.txtMarca.Location = New System.Drawing.Point(566, 19)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.ReadOnly = True
        Me.txtMarca.Size = New System.Drawing.Size(168, 20)
        Me.txtMarca.TabIndex = 229
        '
        'lblDisplayNombreVehiculo
        '
        Me.lblDisplayNombreVehiculo.AutoSize = True
        Me.lblDisplayNombreVehiculo.Location = New System.Drawing.Point(189, 22)
        Me.lblDisplayNombreVehiculo.Name = "lblDisplayNombreVehiculo"
        Me.lblDisplayNombreVehiculo.Size = New System.Drawing.Size(50, 13)
        Me.lblDisplayNombreVehiculo.TabIndex = 228
        Me.lblDisplayNombreVehiculo.Text = "Nombre :"
        '
        'txtNombreVehiculo
        '
        Me.txtNombreVehiculo.Location = New System.Drawing.Point(245, 19)
        Me.txtNombreVehiculo.Name = "txtNombreVehiculo"
        Me.txtNombreVehiculo.ReadOnly = True
        Me.txtNombreVehiculo.Size = New System.Drawing.Size(226, 20)
        Me.txtNombreVehiculo.TabIndex = 227
        '
        'lblDisplayVehiculo
        '
        Me.lblDisplayVehiculo.AutoSize = True
        Me.lblDisplayVehiculo.Location = New System.Drawing.Point(6, 22)
        Me.lblDisplayVehiculo.Name = "lblDisplayVehiculo"
        Me.lblDisplayVehiculo.Size = New System.Drawing.Size(56, 13)
        Me.lblDisplayVehiculo.TabIndex = 226
        Me.lblDisplayVehiculo.Text = "Vehículo :"
        '
        'txtCodigoVehiculo
        '
        Me.txtCodigoVehiculo.Location = New System.Drawing.Point(88, 19)
        Me.txtCodigoVehiculo.MaxLength = 10
        Me.txtCodigoVehiculo.Name = "txtCodigoVehiculo"
        Me.txtCodigoVehiculo.Size = New System.Drawing.Size(83, 20)
        Me.txtCodigoVehiculo.TabIndex = 0
        '
        'gbFigurasTransporte
        '
        Me.gbFigurasTransporte.BackColor = System.Drawing.SystemColors.Control
        Me.gbFigurasTransporte.Controls.Add(Me.TextBox1)
        Me.gbFigurasTransporte.Controls.Add(Me.GridFigurasTransporte)
        Me.gbFigurasTransporte.Location = New System.Drawing.Point(6, 165)
        Me.gbFigurasTransporte.Name = "gbFigurasTransporte"
        Me.gbFigurasTransporte.Size = New System.Drawing.Size(1170, 161)
        Me.gbFigurasTransporte.TabIndex = 1
        Me.gbFigurasTransporte.TabStop = False
        Me.gbFigurasTransporte.Text = "Figuras de transporte"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(69, 19)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(992, 20)
        Me.TextBox1.TabIndex = 259
        Me.TextBox1.Text = "|Codigo|Tipo|Nombre|Rfc|Licencia|Domicilio|"
        Me.TextBox1.Visible = False
        '
        'GridFigurasTransporte
        '
        Me.GridFigurasTransporte.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridFigurasTransporte.CheckedImage = CType(resources.GetObject("GridFigurasTransporte.CheckedImage"), System.Drawing.Bitmap)
        Me.GridFigurasTransporte.Cols = 1
        Me.GridFigurasTransporte.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridFigurasTransporte.DefaultRowHeight = CType(24, Short)
        Me.GridFigurasTransporte.DisplayRowNumber = True
        Me.GridFigurasTransporte.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridFigurasTransporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridFigurasTransporte.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridFigurasTransporte.Location = New System.Drawing.Point(6, 19)
        Me.GridFigurasTransporte.LockButton = True
        Me.GridFigurasTransporte.Name = "GridFigurasTransporte"
        Me.GridFigurasTransporte.Rows = 5
        Me.GridFigurasTransporte.Size = New System.Drawing.Size(1158, 131)
        Me.GridFigurasTransporte.TabIndex = 0
        Me.GridFigurasTransporte.UncheckedImage = CType(resources.GetObject("GridFigurasTransporte.UncheckedImage"), System.Drawing.Bitmap)
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbImprimir, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1213, 27)
        Me.tsMenu.TabIndex = 1
        Me.tsMenu.Text = "tsMenu"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = CType(resources.GetObject("tsbNuevo.Image"), System.Drawing.Image)
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(66, 24)
        Me.tsbNuevo.Text = "&Nuevo"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(66, 24)
        Me.tsbGrabar.Text = "&Grabar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(53, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(77, 24)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'Ventas_CartaPorte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1213, 601)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Ventas_CartaPorte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carta Porte"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.gbMercancias.ResumeLayout(False)
        Me.gbMercancias.PerformLayout()
        Me.gbUbicaciones.ResumeLayout(False)
        Me.gbUbicaciones.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.gbPartesTransporte.ResumeLayout(False)
        Me.gbPartesTransporte.PerformLayout()
        Me.gbAutoTransporte.ResumeLayout(False)
        Me.gbAutoTransporte.PerformLayout()
        Me.gbFigurasTransporte.ResumeLayout(False)
        Me.gbFigurasTransporte.PerformLayout()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents gbUbicaciones As GroupBox
    Friend WithEvents GridUbicaciones As FlexCell.Grid
    Friend WithEvents gbMercancias As GroupBox
    Friend WithEvents GridMercancias As FlexCell.Grid
    Friend WithEvents cboTransporteInternacional As ComboBox
    Friend WithEvents lblDisplayTransporteInternacional As Label
    Friend WithEvents lblDisplayTotalDistanciaRecorrida As Label
    Friend WithEvents lblDisplayUnidadPeso As Label
    Friend WithEvents lblDisplayTotalPesoBruto As Label
    Friend WithEvents lblDisplayTotalMercancias As Label
    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents tsbNuevo As ToolStripButton
    Friend WithEvents tsbGrabar As ToolStripButton
    Friend WithEvents tsbSalir As ToolStripButton
    Friend WithEvents txtTotalPesoBruto As TextBox
    Friend WithEvents txtTotalMercancias As TextBox
    Friend WithEvents txtCodigoUnidadPeso As TextBox
    Friend WithEvents txtTotalDistanciaRecorrida As TextBox
    Friend WithEvents gbAutoTransporte As GroupBox
    Friend WithEvents gbFigurasTransporte As GroupBox
    Friend WithEvents GridFigurasTransporte As FlexCell.Grid
    Friend WithEvents gbPartesTransporte As GroupBox
    Friend WithEvents GridPartesTransporte As FlexCell.Grid
    Friend WithEvents lblDisplayVehiculo As Label
    Friend WithEvents txtCodigoVehiculo As TextBox
    Friend WithEvents txtNumeroPermisoSCT As TextBox
    Friend WithEvents lblDisplayCodigoPermisoSCT As Label
    Friend WithEvents txtCodigoPermisoSCT As TextBox
    Friend WithEvents txtNombreAutotransporte As TextBox
    Friend WithEvents txtCodigoRemolque2 As TextBox
    Friend WithEvents lblDisplayRemolque1 As Label
    Friend WithEvents txtCodigoRemolque1 As TextBox
    Friend WithEvents lblDisplayAseguradoraResponsabilidadCivil As Label
    Friend WithEvents txtAseguradoraResponsabilidadCivil As TextBox
    Friend WithEvents lblDisplayAutotransporte As Label
    Friend WithEvents txtCodigoAutotransporte As TextBox
    Friend WithEvents lblDisplayPlacaAutotransporte As Label
    Friend WithEvents txtPlacaAutotransporte As TextBox
    Friend WithEvents lblDisplayAño As Label
    Friend WithEvents txtAño As TextBox
    Friend WithEvents lblDisplayMarca As Label
    Friend WithEvents txtMarca As TextBox
    Friend WithEvents lblDisplayNombreVehiculo As Label
    Friend WithEvents txtNombreVehiculo As TextBox
    Friend WithEvents lblDisplayPolizaResposabilidadCivil As Label
    Friend WithEvents txtPolizaResposabilidadCivil As TextBox
    Friend WithEvents lblDisplayRemolque2 As Label
    Friend WithEvents lblDisplayTipoRemolque2 As Label
    Friend WithEvents txtTipoRemolque2 As TextBox
    Friend WithEvents lblDisplayTipoRemolque1 As Label
    Friend WithEvents txtTipoRemolque1 As TextBox
    Friend WithEvents lblDisplayPlacaRemolque2 As Label
    Friend WithEvents txtPlacaRemolque2 As TextBox
    Friend WithEvents lblDisplayPlacaRemolque1 As Label
    Friend WithEvents txtPlacaRemolque1 As TextBox
    Friend WithEvents lblDisplayPrimaSeguro As Label
    Friend WithEvents txtPrimaSeguro As TextBox
    Friend WithEvents txtNombreTipoRemolque2 As TextBox
    Friend WithEvents txtNombreTipoRemolque1 As TextBox
    Friend WithEvents txtNombreUnidadPeso As TextBox
    Friend WithEvents txtEncabezadoMercanciasFake As TextBox
    Friend WithEvents txtEncabezadoUbicacionesaFake As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents tsbImprimir As ToolStripButton
End Class
