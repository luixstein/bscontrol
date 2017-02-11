<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class AppMenuReportes
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AppMenuReportes))
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.MenuSalir = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.VentasToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.VentasExtranjerasEstimadasPorCultivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VentasFacturadasNacionalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ResumenDeVentasExtranjerasYNacionalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ResumenEmpaqueYEmbarqueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CxcToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.CobranzaGlobaldetalleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ProducciónToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ProducciónEstimadaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CostoDeProducciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ContableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CostoCorteAcarreoEmpaqueYEmbarqueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EstadosFinancierosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TreeViewMenus = New System.Windows.Forms.TreeView
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem13 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem14 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem15 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToptenClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToptenProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ComparativosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HistoricosDeVentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ComparativosDeVentaEnDineroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ComparativosDeVentaEnCantidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ComparativosDeVentaEnPrecioPromedioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel.Text = "Status"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 558)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(565, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'HelpProvider
        '
        Me.HelpProvider.HelpNamespace = "C:\PV\data\AyudaPV_Administra.chm"
        '
        'MenuSalir
        '
        Me.MenuSalir.Name = "MenuSalir"
        Me.MenuSalir.Size = New System.Drawing.Size(41, 20)
        Me.MenuSalir.Text = "&Salir"
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VentasToolStripMenuItem1, Me.CxcToolStripMenuItem1, Me.ProducciónToolStripMenuItem1, Me.ContableToolStripMenuItem, Me.ComparativosToolStripMenuItem, Me.MenuSalir})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(565, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'VentasToolStripMenuItem1
        '
        Me.VentasToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VentasExtranjerasEstimadasPorCultivoToolStripMenuItem, Me.VentasFacturadasNacionalToolStripMenuItem, Me.ResumenDeVentasExtranjerasYNacionalesToolStripMenuItem, Me.ResumenEmpaqueYEmbarqueToolStripMenuItem, Me.ToptenClientesToolStripMenuItem, Me.ToptenProductosToolStripMenuItem})
        Me.VentasToolStripMenuItem1.Name = "VentasToolStripMenuItem1"
        Me.VentasToolStripMenuItem1.Size = New System.Drawing.Size(54, 20)
        Me.VentasToolStripMenuItem1.Text = "Ventas"
        '
        'VentasExtranjerasEstimadasPorCultivoToolStripMenuItem
        '
        Me.VentasExtranjerasEstimadasPorCultivoToolStripMenuItem.Name = "VentasExtranjerasEstimadasPorCultivoToolStripMenuItem"
        Me.VentasExtranjerasEstimadasPorCultivoToolStripMenuItem.Size = New System.Drawing.Size(303, 22)
        Me.VentasExtranjerasEstimadasPorCultivoToolStripMenuItem.Text = "Ventas extranjeras estimadas por cultivo"
        '
        'VentasFacturadasNacionalToolStripMenuItem
        '
        Me.VentasFacturadasNacionalToolStripMenuItem.Name = "VentasFacturadasNacionalToolStripMenuItem"
        Me.VentasFacturadasNacionalToolStripMenuItem.Size = New System.Drawing.Size(303, 22)
        Me.VentasFacturadasNacionalToolStripMenuItem.Text = "Ventas facturadas nacional"
        '
        'ResumenDeVentasExtranjerasYNacionalesToolStripMenuItem
        '
        Me.ResumenDeVentasExtranjerasYNacionalesToolStripMenuItem.Name = "ResumenDeVentasExtranjerasYNacionalesToolStripMenuItem"
        Me.ResumenDeVentasExtranjerasYNacionalesToolStripMenuItem.Size = New System.Drawing.Size(303, 22)
        Me.ResumenDeVentasExtranjerasYNacionalesToolStripMenuItem.Text = "Resumen de ventas extranjeras y nacionales"
        '
        'ResumenEmpaqueYEmbarqueToolStripMenuItem
        '
        Me.ResumenEmpaqueYEmbarqueToolStripMenuItem.Name = "ResumenEmpaqueYEmbarqueToolStripMenuItem"
        Me.ResumenEmpaqueYEmbarqueToolStripMenuItem.Size = New System.Drawing.Size(303, 22)
        Me.ResumenEmpaqueYEmbarqueToolStripMenuItem.Text = "Resumen empaque y embarque"
        '
        'CxcToolStripMenuItem1
        '
        Me.CxcToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CobranzaGlobaldetalleToolStripMenuItem})
        Me.CxcToolStripMenuItem1.Name = "CxcToolStripMenuItem1"
        Me.CxcToolStripMenuItem1.Size = New System.Drawing.Size(42, 20)
        Me.CxcToolStripMenuItem1.Text = "CXC"
        '
        'CobranzaGlobaldetalleToolStripMenuItem
        '
        Me.CobranzaGlobaldetalleToolStripMenuItem.Name = "CobranzaGlobaldetalleToolStripMenuItem"
        Me.CobranzaGlobaldetalleToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.CobranzaGlobaldetalleToolStripMenuItem.Text = "Cobranza global/detalle"
        '
        'ProducciónToolStripMenuItem1
        '
        Me.ProducciónToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProducciónEstimadaToolStripMenuItem, Me.CostoDeProducciónToolStripMenuItem})
        Me.ProducciónToolStripMenuItem1.Name = "ProducciónToolStripMenuItem1"
        Me.ProducciónToolStripMenuItem1.Size = New System.Drawing.Size(80, 20)
        Me.ProducciónToolStripMenuItem1.Text = "Producción"
        '
        'ProducciónEstimadaToolStripMenuItem
        '
        Me.ProducciónEstimadaToolStripMenuItem.Name = "ProducciónEstimadaToolStripMenuItem"
        Me.ProducciónEstimadaToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.ProducciónEstimadaToolStripMenuItem.Text = "Producción estimada"
        '
        'CostoDeProducciónToolStripMenuItem
        '
        Me.CostoDeProducciónToolStripMenuItem.Name = "CostoDeProducciónToolStripMenuItem"
        Me.CostoDeProducciónToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.CostoDeProducciónToolStripMenuItem.Text = "Costo de producción"
        '
        'ContableToolStripMenuItem
        '
        Me.ContableToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CostoCorteAcarreoEmpaqueYEmbarqueToolStripMenuItem, Me.EstadosFinancierosToolStripMenuItem})
        Me.ContableToolStripMenuItem.Name = "ContableToolStripMenuItem"
        Me.ContableToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.ContableToolStripMenuItem.Text = "Contable"
        '
        'CostoCorteAcarreoEmpaqueYEmbarqueToolStripMenuItem
        '
        Me.CostoCorteAcarreoEmpaqueYEmbarqueToolStripMenuItem.Name = "CostoCorteAcarreoEmpaqueYEmbarqueToolStripMenuItem"
        Me.CostoCorteAcarreoEmpaqueYEmbarqueToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.CostoCorteAcarreoEmpaqueYEmbarqueToolStripMenuItem.Text = "Costo corte, acarreo, empaque y embarque"
        '
        'EstadosFinancierosToolStripMenuItem
        '
        Me.EstadosFinancierosToolStripMenuItem.Name = "EstadosFinancierosToolStripMenuItem"
        Me.EstadosFinancierosToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.EstadosFinancierosToolStripMenuItem.Text = "Estados financieros"
        '
        'TreeViewMenus
        '
        Me.TreeViewMenus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeViewMenus.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeViewMenus.Location = New System.Drawing.Point(0, 0)
        Me.TreeViewMenus.Name = "TreeViewMenus"
        Me.TreeViewMenus.Size = New System.Drawing.Size(588, 560)
        Me.TreeViewMenus.TabIndex = 17
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem15})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(565, 24)
        Me.MenuStrip1.TabIndex = 19
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem3, Me.ToolStripMenuItem4, Me.ToolStripMenuItem5, Me.ToolStripMenuItem6, Me.ToolStripMenuItem10, Me.ToolStripMenuItem2, Me.ToolStripMenuItem13, Me.ToolStripMenuItem11, Me.ToolStripMenuItem14, Me.ToolStripMenuItem7, Me.ToolStripMenuItem8})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(65, 20)
        Me.ToolStripMenuItem1.Text = "Reportes"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(303, 22)
        Me.ToolStripMenuItem3.Text = "Ventas extranjeras estimadas por cultivo"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(303, 22)
        Me.ToolStripMenuItem4.Text = "Ventas facturadas nacional"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(303, 22)
        Me.ToolStripMenuItem5.Text = "Resumen de ventas extranjeras y nacionales"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(303, 22)
        Me.ToolStripMenuItem6.Text = "Resumen empaque y embarque"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(303, 22)
        Me.ToolStripMenuItem10.Text = "Producción estimada"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(300, 6)
        '
        'ToolStripMenuItem13
        '
        Me.ToolStripMenuItem13.Name = "ToolStripMenuItem13"
        Me.ToolStripMenuItem13.Size = New System.Drawing.Size(303, 22)
        Me.ToolStripMenuItem13.Text = "Costo corte, acarreo, empaque y embarque"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(303, 22)
        Me.ToolStripMenuItem11.Text = "Costo de producción"
        '
        'ToolStripMenuItem14
        '
        Me.ToolStripMenuItem14.Name = "ToolStripMenuItem14"
        Me.ToolStripMenuItem14.Size = New System.Drawing.Size(303, 22)
        Me.ToolStripMenuItem14.Text = "Estados financieros"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(300, 6)
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(303, 22)
        Me.ToolStripMenuItem8.Text = "Cobranza global/detalle"
        '
        'ToolStripMenuItem15
        '
        Me.ToolStripMenuItem15.Name = "ToolStripMenuItem15"
        Me.ToolStripMenuItem15.Size = New System.Drawing.Size(41, 20)
        Me.ToolStripMenuItem15.Text = "&Salir"
        '
        'ToptenClientesToolStripMenuItem
        '
        Me.ToptenClientesToolStripMenuItem.Name = "ToptenClientesToolStripMenuItem"
        Me.ToptenClientesToolStripMenuItem.Size = New System.Drawing.Size(303, 22)
        Me.ToptenClientesToolStripMenuItem.Text = "Topten clientes"
        '
        'ToptenProductosToolStripMenuItem
        '
        Me.ToptenProductosToolStripMenuItem.Name = "ToptenProductosToolStripMenuItem"
        Me.ToptenProductosToolStripMenuItem.Size = New System.Drawing.Size(303, 22)
        Me.ToptenProductosToolStripMenuItem.Text = "Topten productos"
        '
        'ComparativosToolStripMenuItem
        '
        Me.ComparativosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HistoricosDeVentaToolStripMenuItem})
        Me.ComparativosToolStripMenuItem.Name = "ComparativosToolStripMenuItem"
        Me.ComparativosToolStripMenuItem.Size = New System.Drawing.Size(93, 20)
        Me.ComparativosToolStripMenuItem.Text = "Comparativos"
        '
        'HistoricosDeVentaToolStripMenuItem
        '
        Me.HistoricosDeVentaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ComparativosDeVentaEnDineroToolStripMenuItem, Me.ComparativosDeVentaEnCantidadToolStripMenuItem, Me.ComparativosDeVentaEnPrecioPromedioToolStripMenuItem})
        Me.HistoricosDeVentaToolStripMenuItem.Name = "HistoricosDeVentaToolStripMenuItem"
        Me.HistoricosDeVentaToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.HistoricosDeVentaToolStripMenuItem.Text = "Historicos de venta"
        '
        'ComparativosDeVentaEnDineroToolStripMenuItem
        '
        Me.ComparativosDeVentaEnDineroToolStripMenuItem.Name = "ComparativosDeVentaEnDineroToolStripMenuItem"
        Me.ComparativosDeVentaEnDineroToolStripMenuItem.Size = New System.Drawing.Size(303, 22)
        Me.ComparativosDeVentaEnDineroToolStripMenuItem.Text = "Comparativos de venta en dinero"
        '
        'ComparativosDeVentaEnCantidadToolStripMenuItem
        '
        Me.ComparativosDeVentaEnCantidadToolStripMenuItem.Name = "ComparativosDeVentaEnCantidadToolStripMenuItem"
        Me.ComparativosDeVentaEnCantidadToolStripMenuItem.Size = New System.Drawing.Size(303, 22)
        Me.ComparativosDeVentaEnCantidadToolStripMenuItem.Text = "Comparativos de venta en cantidad"
        '
        'ComparativosDeVentaEnPrecioPromedioToolStripMenuItem
        '
        Me.ComparativosDeVentaEnPrecioPromedioToolStripMenuItem.Name = "ComparativosDeVentaEnPrecioPromedioToolStripMenuItem"
        Me.ComparativosDeVentaEnPrecioPromedioToolStripMenuItem.Size = New System.Drawing.Size(303, 22)
        Me.ComparativosDeVentaEnPrecioPromedioToolStripMenuItem.Text = "Comparativos de venta en precio promedio"
        '
        'AppMenuReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(565, 580)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TreeViewMenus)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpProvider.SetHelpKeyword(Me, "F1")
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MaximizeBox = False
        Me.Name = "AppMenuReportes"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppMenu"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents MenuSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents TreeViewMenus As System.Windows.Forms.TreeView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem15 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem14 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem13 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VentasToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CxcToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProducciónToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VentasExtranjerasEstimadasPorCultivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VentasFacturadasNacionalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResumenDeVentasExtranjerasYNacionalesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResumenEmpaqueYEmbarqueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CobranzaGlobaldetalleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProducciónEstimadaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CostoDeProducciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CostoCorteAcarreoEmpaqueYEmbarqueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstadosFinancierosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToptenClientesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToptenProductosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComparativosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HistoricosDeVentaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComparativosDeVentaEnDineroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComparativosDeVentaEnCantidadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComparativosDeVentaEnPrecioPromedioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
