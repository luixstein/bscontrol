Option Explicit On
Option Strict On
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Runtime.InteropServices

Public Class AppMenuReportes

    Private m_ChildFormNumber As Integer = 0
    Dim Opcion_Menu As New Class_Menu

#Region "Opciones de manejo de ventanas"

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Global.System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub
#End Region

#Region "Propiedades"
#End Region

    <DllImport("user32.dll", SetLastError:=True)> _
    Private Shared Function SetParent(ByVal child As IntPtr, ByVal newParent As IntPtr) As IntPtr
    End Function

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub AppMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Text = Empresa_Sistema.Nombre_empresa.ToString & " | Plaza: " & Usuario.Codigo_Plaza & "-" & Plaza.NOMBRE_PLAZA & " | Usuario: " & Usuario.Nombre_Usuario
        Me.ToolStripStatusLabel.Text = "Server: " & Empresa_Sistema.Servidor & " | BD: " & Empresa_Sistema.BaseDatos & " | " & String.Format("Revisión {0}", My.Application.Info.Version.ToString) & ""

        Dim sLogo As String = "\logo_" & My.Settings.BaseDatos & ".jpg"
        Dim sRutaLogoServidor As String = "\\" & Split(My.Settings.Servidor, "\")(0) & "\" & Microsoft.VisualBasic.Strings.Right(My.Settings.Ruta, Len(My.Settings.Ruta) - InStrRev(My.Settings.Ruta, "\")) & sLogo
        Dim sRutaLogoLocal As String = My.Settings.Ruta & sLogo

        If Len(Dir(sRutaLogoLocal)) = 0 Then
            If Len(Dir(sRutaLogoServidor)) > 0 Then
                Copiar_Archivo(sRutaLogoServidor, sRutaLogoLocal)
            End If
        End If

        '        Me.pbLogo.ImageLocation = sRutaLogoLocal

        Dim clienteMDI As MdiClient
        For Each control As Control In Me.Controls
            Try
                clienteMDI = DirectCast(control, MdiClient)
                clienteMDI.BackColor = Color.White
                'SetParent(pbLogo.Handle, clienteMDI.Handle)
                'SetParent(TreeViewMenus.Handle, clienteMDI.Handle)
            Catch generatedExceptionName As InvalidCastException
                'MsgBox("Error en " & Me.Name & ":" & generatedExceptionName.Message.ToString, MsgBoxStyle.Critical)
            End Try
        Next
        LlenaElemento(Usuario.Codigo_Usuario)
    End Sub

    Private Sub AppMenu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Running Then
            If Not Mod_main.Finaliza() Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSalir.Click
        Me.Close()
        Mod_main.Finaliza()
    End Sub

    Private Sub CierraTodosReportes()
        My.Forms.Rpt_Embarques_Produccion_Estimada.Close()
        My.Forms.Frm_Contabilidad_Costo_corte_acarreo_empaque_embarque.Close()
        My.Forms.Frm_Contabilidad_Costos_Produccion.Close()
        My.Forms.Frm_contabilidad_Estados_Financieros.Close()
        My.Forms.Rpt_CXC_Documentos.Close()
        My.Forms.Rpt_Resumen_Empaque_y_Embarque.Close()
        My.Forms.Rpt_VentasNetasPorCultivo.Close()
    End Sub

    Private Sub ProducciónEstimadaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProducciónEstimadaToolStripMenuItem.Click
        Me.CierraTodosReportes()
        'My.Forms.Rpt_Embarques_Produccion_Estimada.MdiParent = Me
        My.Forms.Rpt_Embarques_Produccion_Estimada.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Rpt_Embarques_Produccion_Estimada.ShowDialog()
        My.Forms.Rpt_Embarques_Produccion_Estimada.Focus()
    End Sub

    Private Sub CostoCorteAcarreoEmpaqueYEmbarqueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CostoCorteAcarreoEmpaqueYEmbarqueToolStripMenuItem.Click
        Me.CierraTodosReportes()
        'My.Forms.Frm_Contabilidad_Costo_corte_acarreo_empaque_embarque.MdiParent = Me
        My.Forms.Frm_Contabilidad_Costo_corte_acarreo_empaque_embarque.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Frm_Contabilidad_Costo_corte_acarreo_empaque_embarque.ShowDialog()
        My.Forms.Frm_Contabilidad_Costo_corte_acarreo_empaque_embarque.Focus()
    End Sub

    Private Sub CostoDeProduccionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CostoDeProducciónToolStripMenuItem.Click
        Me.CierraTodosReportes()
        'My.Forms.Frm_Contabilidad_Costos_Produccion.MdiParent = Me
        My.Forms.Frm_Contabilidad_Costos_Produccion.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Frm_Contabilidad_Costos_Produccion.ShowDialog()
        My.Forms.Frm_Contabilidad_Costos_Produccion.Focus()
    End Sub

    Private Sub EstadosFinancierosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadosFinancierosToolStripMenuItem.Click
        Me.CierraTodosReportes()
        'My.Forms.Frm_contabilidad_Estados_Financieros.MdiParent = Me
        My.Forms.Frm_contabilidad_Estados_Financieros.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Frm_contabilidad_Estados_Financieros.ShowDialog()
        My.Forms.Frm_contabilidad_Estados_Financieros.Focus()
    End Sub

    Private Sub CobranzaGlobaldetalleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobranzaGlobaldetalleToolStripMenuItem.Click
        Me.CierraTodosReportes()
        'My.Forms.Rpt_CXC_Documentos.MdiParent = Me
        My.Forms.Rpt_CXC_Documentos.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Rpt_CXC_Documentos.ShowDialog()
        My.Forms.Rpt_CXC_Documentos.Focus()
    End Sub

    Private Sub ResumenEmpaqueYEmbarqueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResumenEmpaqueYEmbarqueToolStripMenuItem.Click
        Me.CierraTodosReportes()
        'My.Forms.Rpt_Resumen_Empaque_y_Embarque.MdiParent = Me
        My.Forms.Rpt_Resumen_Empaque_y_Embarque.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Rpt_Resumen_Empaque_y_Embarque.ShowDialog()
        My.Forms.Rpt_Resumen_Empaque_y_Embarque.Focus()
    End Sub

    Private Sub VentasNetasPorCultivoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentasExtranjerasEstimadasPorCultivoToolStripMenuItem.Click
        Me.CierraTodosReportes()
        'My.Forms.Rpt_VentasNetasPorCultivo.MdiParent = Me
        My.Forms.Rpt_VentasNetasPorCultivo.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Rpt_VentasNetasPorCultivo.ShowDialog()
        My.Forms.Rpt_VentasNetasPorCultivo.Focus()
    End Sub

    Private Sub VentasFacturadasNacionalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentasFacturadasNacionalToolStripMenuItem.Click
        'Dim Child As New Rpt_Embarques_VentasNacionalesEstimadas
        ''Child.MdiParent = Me
        'm_ChildFormNumber += 1
        'Child.StartPosition = FormStartPosition.CenterScreen
        'Child.ShowDialog()
        Me.CierraTodosReportes()
        'My.Forms.Rpt_VentasNetasPorCultivo.MdiParent = Me
        My.Forms.Rpt_Embarques_VentasNacionalesEstimadas.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Rpt_Embarques_VentasNacionalesEstimadas.ShowDialog()
        My.Forms.Rpt_Embarques_VentasNacionalesEstimadas.Focus()
    End Sub

    Private Sub ResumenDeVentasExtranjerasYNacionalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResumenDeVentasExtranjerasYNacionalesToolStripMenuItem.Click
        'Dim Child As New Rpt_Embarques_ResumenVentas
        'Child.MdiParent = Me
        'm_ChildFormNumber += 1
        'Child.StartPosition = FormStartPosition.CenterScreen
        'Child.Show()
        Me.CierraTodosReportes()
        'My.Forms.Rpt_VentasNetasPorCultivo.MdiParent = Me
        My.Forms.Rpt_Embarques_ResumenVentas.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Rpt_Embarques_ResumenVentas.ShowDialog()
        My.Forms.Rpt_Embarques_ResumenVentas.Focus()
    End Sub

    Private oUsuarios As New Class_sisUsuarios
    Private dtMenus As DataTable
    Private sParent As String = ""
    Private bPadre As Boolean = False

#Region "Métodos y procedimientos"
    Private Sub LlenaElemento(ByVal iCodigo_Elemento As Integer)
        Dim oElemento As New Class_sisUsuarios
        oElemento.Codigo_Usuario = iCodigo_Elemento
        If oElemento.Consultar Then
            With oElemento
                'Me.TxtCodigoUsuario.Text = .Codigo_Usuario.ToString
                'Me.TxtNombreUsuario.Text = .Nombre_Usuario.ToString
            End With
        End If
        Me.TreeMenus()
        'Me.ConsultaPermisos()
        'Me.ConsultaPermisosMenus()
        oElemento = Nothing
    End Sub

    Private Sub TreeMenus()
        Try
            Me.TreeViewMenus.Nodes.Clear()
            For Each tsmi As ToolStripMenuItem In Me.MenuStrip.Items   'Me.MenuStrip.Items
                Dim tn As New TreeNode(tsmi.Name)
                tn.Text = Replace(tsmi.Text, "&", "")
                tn.Tag = tsmi.Name
                Me.TreeViewMenus.Nodes.Add(tn)
                Me.SubTreeMenus(tn, tsmi.DropDownItems)
                'tsmi.Enabled = False
            Next
        Catch ex As Exception
            HandleError(Me.Name, "TreeMenus", ex)
        End Try
    End Sub

    Private Sub SubTreeMenus(ByVal parentNode As TreeNode, ByVal items As ToolStripItemCollection)
        For Each item As ToolStripItem In items
            If item.GetType().ToString <> "System.Windows.Forms.ToolStripSeparator" Then
                'if item.GetType() = typeof(System.Windows.Forms.ToolStripMenuIte) then
                Dim child As New TreeNode(item.Text)
                child.Text = Replace(item.Text, "&", "")
                child.Tag = item.Name
                parentNode.Nodes.Add(child)
                Me.SubTreeMenus(child, DirectCast(item, ToolStripMenuItem).DropDownItems)
                'item.Enabled = False
            End If
        Next
    End Sub

    Private Sub HabilitaMenus(ByVal sNodo As String)
        Try
            For Each tsmi As ToolStripMenuItem In Me.MenuStrip.Items
                If tsmi.Name = sNodo.ToString Then
                    tsmi.PerformClick()
                End If
                Me.HabilitaSubMenus(tsmi.DropDownItems, sNodo)
            Next
        Catch ex As Exception
            HandleError(Me.Name, "HabilitaMenus", ex)
        End Try
    End Sub

    Private Sub HabilitaSubMenus(ByVal items As ToolStripItemCollection, ByVal sNodo As String)
        Try
            Dim newItem = New ToolStripMenuItem
            For Each item As ToolStripItem In items
                If item.GetType().ToString <> "System.Windows.Forms.ToolStripSeparator" Then
                    If item.Name = sNodo.ToString Then
                        item.PerformClick()
                    End If
                    Me.HabilitaSubMenus(DirectCast(item, ToolStripMenuItem).DropDownItems, sNodo)
                End If
            Next

        Catch ex As Exception
            HandleError(Me.Name, "HabilitaSubMenus", ex)
        End Try
    End Sub

 
#End Region

    Private Sub TreeViewMenus_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeViewMenus.NodeMouseDoubleClick
        If e.Node.Nodes.Count = 0 Then
            If Not e.Node.Tag Is Nothing Then
                HabilitaMenus(e.Node.Tag.ToString)
                'Me.MenuStrip.Items.Item(e.Node.Tag.ToString).PerformClick()
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Me.CierraTodosReportes()
        'My.Forms.Rpt_VentasNetasPorCultivo.MdiParent = Me
        My.Forms.Rpt_VentasNetasPorCultivo.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Rpt_VentasNetasPorCultivo.ShowDialog()
        My.Forms.Rpt_VentasNetasPorCultivo.Focus()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        'Dim Child As New Rpt_Embarques_VentasNacionalesEstimadas
        'Child.MdiParent = Me
        'm_ChildFormNumber += 1
        'Child.StartPosition = FormStartPosition.CenterScreen
        'Child.Show()
        Me.CierraTodosReportes()
        'My.Forms.Rpt_Embarques_VentasNacionalesEstimadas.MdiParent = Me
        My.Forms.Rpt_Embarques_VentasNacionalesEstimadas.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Rpt_Embarques_VentasNacionalesEstimadas.ShowDialog()
        My.Forms.Rpt_Embarques_VentasNacionalesEstimadas.Focus()
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        'Dim Child As New Rpt_Embarques_ResumenVentas
        'Child.MdiParent = Me
        'm_ChildFormNumber += 1
        'Child.StartPosition = FormStartPosition.CenterScreen
        'Child.Show()
        Me.CierraTodosReportes()
        'My.Forms.Rpt_Embarques_ResumenVentas.MdiParent = Me
        My.Forms.Rpt_Embarques_ResumenVentas.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Rpt_Embarques_ResumenVentas.ShowDialog()
        My.Forms.Rpt_Embarques_ResumenVentas.Focus()
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        Me.CierraTodosReportes()
        'My.Forms.Rpt_Resumen_Empaque_y_Embarque.MdiParent = Me
        My.Forms.Rpt_Resumen_Empaque_y_Embarque.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Rpt_Resumen_Empaque_y_Embarque.Show()
        My.Forms.Rpt_Resumen_Empaque_y_Embarque.Focus()
    End Sub

    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        Me.CierraTodosReportes()
        'My.Forms.Rpt_Embarques_Produccion_Estimada.MdiParent = Me
        My.Forms.Rpt_Embarques_Produccion_Estimada.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Rpt_Embarques_Produccion_Estimada.Show()
        My.Forms.Rpt_Embarques_Produccion_Estimada.Focus()
    End Sub

    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem13.Click
        Me.CierraTodosReportes()
        'My.Forms.Frm_Contabilidad_Costo_corte_acarreo_empaque_embarque.MdiParent = Me
        My.Forms.Frm_Contabilidad_Costo_corte_acarreo_empaque_embarque.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Frm_Contabilidad_Costo_corte_acarreo_empaque_embarque.Show()
        My.Forms.Frm_Contabilidad_Costo_corte_acarreo_empaque_embarque.Focus()
    End Sub

    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click
        Me.CierraTodosReportes()
        'My.Forms.Frm_Contabilidad_Costos_Produccion.MdiParent = Me
        My.Forms.Frm_Contabilidad_Costos_Produccion.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Frm_Contabilidad_Costos_Produccion.Show()
        My.Forms.Frm_Contabilidad_Costos_Produccion.Focus()
    End Sub

    Private Sub ToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem14.Click
        Me.CierraTodosReportes()
        'My.Forms.Frm_contabilidad_Estados_Financieros.MdiParent = Me
        My.Forms.Frm_contabilidad_Estados_Financieros.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Frm_contabilidad_Estados_Financieros.Show()
        My.Forms.Frm_contabilidad_Estados_Financieros.Focus()
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        Me.CierraTodosReportes()
        'My.Forms.Rpt_CXC_Documentos.MdiParent = Me
        My.Forms.Rpt_CXC_Documentos.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Rpt_CXC_Documentos.Show()
        My.Forms.Rpt_CXC_Documentos.Focus()
    End Sub

    Private Sub ToptenClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToptenClientesToolStripMenuItem.Click
        Me.CierraTodosReportes()
        My.Forms.Rpt_Ventas_TopTenProductos.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Rpt_Ventas_TopTenProductos.ModoAgrupado = Rpt_Ventas_TopTenProductos.enumModoAgrupado.CLIENTES
        My.Forms.Rpt_Ventas_TopTenProductos.Show()
        My.Forms.Rpt_Ventas_TopTenProductos.Focus()
    End Sub

    Private Sub ToptenProductosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToptenProductosToolStripMenuItem.Click
        Me.CierraTodosReportes()
        My.Forms.Rpt_Ventas_TopTenProductos.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Rpt_Ventas_TopTenProductos.ModoAgrupado = Rpt_Ventas_TopTenProductos.enumModoAgrupado.PRODUCTOS
        My.Forms.Rpt_Ventas_TopTenProductos.Show()
        My.Forms.Rpt_Ventas_TopTenProductos.Focus()
    End Sub

    Private Sub ComparativosDeVentaEnDineroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComparativosDeVentaEnDineroToolStripMenuItem.Click
        Me.CierraTodosReportes()
        My.Forms.Rpt_Q_ComparativosVenta.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Rpt_Q_ComparativosVenta.ModoAgrupado = Rpt_Q_ComparativosVenta.enumComparativo.VENTA
        My.Forms.Rpt_Q_ComparativosVenta.Show()
        My.Forms.Rpt_Q_ComparativosVenta.Focus()
    End Sub

    Private Sub ComparativosDeVentaEnCantidadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComparativosDeVentaEnCantidadToolStripMenuItem.Click
        Me.CierraTodosReportes()
        My.Forms.Rpt_Q_ComparativosVenta.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Rpt_Q_ComparativosVenta.ModoAgrupado = Rpt_Q_ComparativosVenta.enumComparativo.CANTIDAD
        My.Forms.Rpt_Q_ComparativosVenta.Show()
        My.Forms.Rpt_Q_ComparativosVenta.Focus()
    End Sub

    Private Sub ComparativosDeVentaEnPrecioPromedioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComparativosDeVentaEnPrecioPromedioToolStripMenuItem.Click
        Me.CierraTodosReportes()
        My.Forms.Rpt_Q_ComparativosVenta.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Rpt_Q_ComparativosVenta.ModoAgrupado = Rpt_Q_ComparativosVenta.enumComparativo.PRECIO_PROMEDIO
        My.Forms.Rpt_Q_ComparativosVenta.Show()
        My.Forms.Rpt_Q_ComparativosVenta.Focus()
    End Sub
End Class