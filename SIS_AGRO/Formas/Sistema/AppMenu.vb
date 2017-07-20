Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Public Class AppMenu

    Public oImpuesto_IVA_Actual As Class_find
    Private m_ChildFormNumber As Integer = 0
    Private dtMenus As DataTable

    Dim Opcion_Menu As New Class_Menu
    ' Public oImpuesto_IVA_Actual As Class_find

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

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function SetParent(ByVal child As IntPtr, ByVal newParent As IntPtr) As IntPtr
    End Function

    Private Sub AppMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Dim imagen As New Drawing.Bitmap(PictureBox1.Image, Me.Width, Me.Height)
            'If My.Settings.Mostrar_Imagen_de_Fondo <> "No" Then
            '    Me.BackgroundImage = imagen
            'End If

            If Usuario.Nombre_Usuario = "ROSARIO" Then
                Me.MenuStrip.Visible = False
                Me.MenuStrip2.Visible = True
            Else
                Me.MenuStrip.Visible = True
                Me.MenuStrip2.Visible = False
            End If

            EstableceDescripcionMenu()

            Dim sLogo As String = "\logo_" & My.Settings.BaseDatos & ".jpg"

            If My.Settings.Servidor = "PCSISTEMASJORGE\SQL14" Then
                sLogo = "\logo_AGRINET_LAND.jpg"
            End If

            Dim sRutaLogoServidor As String = "\\" & Split(My.Settings.Servidor, "\")(0) & "\" & Microsoft.VisualBasic.Strings.Right(My.Settings.Ruta, Len(My.Settings.Ruta) - InStrRev(My.Settings.Ruta, "\")) & sLogo
            Dim sRutaLogoLocal As String = My.Settings.Ruta & sLogo

            If Len(Dir(sRutaLogoLocal)) = 0 Then
                If Len(Dir(sRutaLogoServidor)) > 0 Then
                    Copiar_Archivo(sRutaLogoServidor, sRutaLogoLocal)
                End If
            End If

            'If My.Computer.Name <> "PCSISTEMASJORGE" Then
            Me.pbLogo.ImageLocation = sRutaLogoLocal
            'End If

            Dim clienteMDI As MdiClient
            For Each control As Control In Me.Controls
                Try
                    clienteMDI = DirectCast(control, MdiClient)
                    clienteMDI.BackColor = Color.White
                    SetParent(pbLogo.Handle, clienteMDI.Handle)
                Catch generatedExceptionName As InvalidCastException
                    'MsgBox("Error en " & Me.Name & ":" & generatedExceptionName.Message.ToString, MsgBoxStyle.Critical)
                End Try
            Next
            Me.DeshabilitaMenus()
            Me.HabilitaMenus()

            Me.tsslValidacionCSD.Text = GestionaFechaCertificadoCFD()

        Catch ex As Exception
            HandleError("Menu", "AppMenu_Load", ex)
        End Try
    End Sub

    Private Sub AppMenu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Running Then
            If Not Mod_main.Finaliza() Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSalir.Click, MenuSalir2.Click
        Me.Close()
        Mod_main.Finaliza()
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub CuentasContablesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuentasContablesToolStripMenuItem.Click
        Dim Child As New Catalogo_Cuentas_Contables
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub MDICatConFoliosDocumentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MDICatConFoliosDocumentos.Click
        Dim ChildCXC As New Catalogo_Folios_Documentos
        ChildCXC.MdiParent = Me
        m_ChildFormNumber += 1
        ChildCXC.Show()
    End Sub

    Private Sub SelecciónDeEjerciciosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelecciónDeEjerciciosToolStripMenuItem.Click
        Dim Child As New Contabilidad_Periodos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ReporteGlobalDePolizasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteGlobalDePolizasToolStripMenuItem.Click
        Dim Child As New Frm_Contabilidad_Global_Polizas()
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub AuxiliarDeMayorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuxiliarDeMayorToolStripMenuItem.Click
        Dim Child As New Frm_Contabilidad_Auxiliar_Mayor
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub MnuContabilidadEstadoResultados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As New Frm_Contabilidad_Estado_Resultados
        f.MdiParent = Me
        m_ChildFormNumber += 1
        f.Show()
    End Sub

    Private Sub PolizaDeEgresosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PolizaDeEgresosToolStripMenuItem.Click
        Dim Child As New Frm_Contabilidad_Polizas_Egresos()
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub RelacionesAnaliticasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelacionesAnaliticasToolStripMenuItem.Click
        Dim Child As New Frm_Contabilidad_Balanza_Analiticas_Mayor
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub SaldosDeCuentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaldosDeCuentasToolStripMenuItem.Click
        Dim Child As New Frm_Contabilidad_Saldos_CUENTA_CONTABLE_PESOS
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub CapturaDePolizasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CapturaDePolizasToolStripMenuItem.Click
        Dim Child As New Frm_Contabilidad_Captura_Polizas
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.Show()
    End Sub

    Private Sub IVAAcreditableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IVAAcreditableToolStripMenuItem.Click
        Dim Child As New Frm_Contabilidad_IVA_Acreditable_Global
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.Show()
    End Sub

    Private Sub ArticulosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArticulosToolStripMenuItem.Click
        Dim Child As New Catalogo_Articulos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub AlmacenesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlmacenesToolStripMenuItem.Click
        Dim ChildCXC As New Catalogo_Almacenes
        ChildCXC.MdiParent = Me
        m_ChildFormNumber += 1
        ChildCXC.Show()
    End Sub

    Private Sub MnuCatInvLineas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuCatInvLineas.Click
        Dim Child As New Catalogo_Lineas
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub MovimientosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovimientosToolStripMenuItem.Click
        Dim Child As New Inventarios_Movimientos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ContraseñasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContraseñasToolStripMenuItem.Click
        Dim Child As New UtileriasGeneraContraseñaCancelarMovimientosMesesPasados
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub MnuInvRepExistencias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuInvRepExistencias.Click
        Dim Child As New Rpt_Inventario_Existencias
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.Show()
    End Sub

    Private Sub MnuInvRepKardex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuInvRepAuxiliar.Click
        Dim Child As New RPT_INVENTARIOS_AUXILIAR_ARTICULOS
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.Show()
    End Sub

    Private Sub InvRptGlobalDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvRptGlobalDetalle.Click
        Dim Child As New Rpt_Inventarios_Global
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.Show()
    End Sub

    Private Sub FamiliasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FamiliasToolStripMenuItem.Click
        Dim Child As New Catalogo_Familias
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.Show()
    End Sub

    'Private Sub CapturaDePagosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CapturaDePagosToolStripMenuItem.Click
    '    Dim Child As New Frm_CXP_Pagos
    '    Child.MdiParent = Me
    '    m_ChildFormNumber += 1
    '    Child.StartPosition = FormStartPosition.CenterScreen
    '    Child.Show()
    'End Sub

    'Private Sub PagosAAcredoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PagosAAcredoresToolStripMenuItem.Click
    '    Dim ChildCXC As New Frm_CXP_Pagos_Acreedores
    '    ChildCXC.MdiParent = Me
    '    m_ChildFormNumber += 1
    '    ChildCXC.Show()
    'End Sub

    Private Sub BancosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BancosToolStripMenuItem.Click
        Dim ChildCXC As New Catalogo_Bancos
        ChildCXC.MdiParent = Me
        m_ChildFormNumber += 1
        ChildCXC.Show()
    End Sub

    Private Sub CuentasBancariasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuentasBancariasToolStripMenuItem.Click
        Dim ChildCXC As New Catalogo_Cuentas_Bancarias
        ChildCXC.MdiParent = Me
        m_ChildFormNumber += 1
        ChildCXC.Show()
    End Sub

    Private Sub ClientesToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientesToolStripMenuItem1.Click
        Dim Child As New Catalogo_Clientes
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.Show()
    End Sub

    Private Sub VendedoresToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VendedoresToolStripMenuItem1.Click
        Dim Child As New Catalogo_Vendedores
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.Show()
    End Sub

    Private Sub ZonasToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZonasToolStripMenuItem.Click
        Dim Child As New Catalogo_Zonas
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.Show()
    End Sub

    Private Sub ProveedoresToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProveedoresToolStripMenuItem.Click
        Dim Child As New Catalogo_Proveedores
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.Show()
    End Sub

    Private Sub CapturaDePagosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CapturaDePagosToolStripMenuItem.Click
        Dim Child As New Frm_CXP_Pagos_Acreedores
        Child.ModoPago = Frm_CXP_Pagos_Acreedores.enumModoPago.PROVEEDOR
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub PagosAAcredoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PagosAAcredoresToolStripMenuItem.Click
        Dim ChildCXP As New Frm_CXP_Pagos_Acreedores
        ChildCXP.ModoPago = Frm_CXP_Pagos_Acreedores.enumModoPago.ACREEDOR
        ChildCXP.MdiParent = Me
        m_ChildFormNumber += 1
        ChildCXP.Show()
    End Sub

    Private Sub MovimientosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovimientosToolStripMenuItem1.Click
        Dim ChildCXC As New Compras_Movimientos
        ChildCXC.MdiParent = Me
        m_ChildFormNumber += 1
        ChildCXC.Show()
    End Sub

    Private Sub GlobalDeDocumentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GlobalDeDocumentosToolStripMenuItem.Click
        Dim ChildCXC As New Rpt_Compras_Global
        ChildCXC.MdiParent = Me
        m_ChildFormNumber += 1
        ChildCXC.Show()
    End Sub

    Private Sub IvaPorAcreditarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IvaPorAcreditarToolStripMenuItem.Click
        Dim Child As New Frm_Contabilidad_IVA_Acreditable
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub CostoDeProduccionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CostoDeProduccionToolStripMenuItem.Click, CostoDeProduccionToolStripMenuItem1.Click
        Dim Child As New Frm_Contabilidad_Costos_Produccion
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub AplicaciónDeDocumentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AplicaciónDeDocumentosToolStripMenuItem.Click
        Dim ChildCXP As New Frm_CXP_Aplicacion_Documentos
        ChildCXP.MdiParent = Me
        m_ChildFormNumber += 1
        ChildCXP.Show()
    End Sub

    Private Sub AuxliarDeProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuxliarDeProveedorToolStripMenuItem.Click
        Dim ChildCXP As New Rpt_Cxp_Auxiliar_proveedor
        ChildCXP.MdiParent = Me
        m_ChildFormNumber += 1
        ChildCXP.Show()
    End Sub

    Private Sub TamañosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TamañosToolStripMenuItem.Click
        Dim ChildCXP As New Catalogo_Tamaños
        ChildCXP.MdiParent = Me
        m_ChildFormNumber += 1
        ChildCXP.Show()
    End Sub

    Private Sub EnvasesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnvasesToolStripMenuItem.Click
        Dim ChildCXP As New Catalogo_Envases
        ChildCXP.MdiParent = Me
        m_ChildFormNumber += 1
        ChildCXP.Show()
    End Sub

    Private Sub EtiquetasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EtiquetasToolStripMenuItem.Click
        Dim ChildCXP As New Catalogo_Etiquetas
        ChildCXP.MdiParent = Me
        m_ChildFormNumber += 1
        ChildCXP.Show()
    End Sub

    Private Sub DistribuidoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DistribuidoresToolStripMenuItem.Click
        Dim ChildCXP As New Catalogo_Distribuidores
        ChildCXP.MdiParent = Me
        m_ChildFormNumber += 1
        ChildCXP.Show()
    End Sub

    Private Sub ProductoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductoresToolStripMenuItem.Click
        Dim ChildCXP As New Catalogo_Productores
        ChildCXP.MdiParent = Me
        m_ChildFormNumber += 1
        ChildCXP.Show()
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductosToolStripMenuItem.Click
        Dim ChildCXP As New Catalogo_Productos_Agricolas
        ChildCXP.MdiParent = Me
        m_ChildFormNumber += 1
        ChildCXP.Show()
    End Sub

    Private Sub CajasDeTransportesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CajasDeTransportesToolStripMenuItem.Click
        Dim ChildCXP As New Catalogo_CajasTransportes
        ChildCXP.MdiParent = Me
        m_ChildFormNumber += 1
        ChildCXP.Show()
    End Sub

    Private Sub EmbarcadoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmbarcadoresToolStripMenuItem.Click
        Dim ChildCXP As New Catalogo_Embarcadores
        ChildCXP.MdiParent = Me
        m_ChildFormNumber += 1
        ChildCXP.Show()
    End Sub

    Private Sub EmpaquesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmpaquesToolStripMenuItem.Click
        Dim ChildCXP As New Catalogo_Empaques
        ChildCXP.MdiParent = Me
        m_ChildFormNumber += 1
        ChildCXP.Show()
    End Sub

    Private Sub EstadosFinancierosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadosFinancierosToolStripMenuItem.Click
        Dim ChildCXP As New Frm_contabilidad_Estados_Financieros
        ChildCXP.MdiParent = Me
        m_ChildFormNumber += 1
        ChildCXP.Show()
    End Sub

    Private Sub PagosAProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PagosAProveedoresToolStripMenuItem.Click
        Dim ChildCXP As New Rpt_Cxp_Detalle_Cheques_Transferencias
        ChildCXP.MdiParent = Me
        m_ChildFormNumber += 1
        ChildCXP.Show()
    End Sub

    Private Sub ArmadoDePaletsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArmadoDePaletsToolStripMenuItem.Click
        Dim Child As New Frm_Embarques_ArmadoPalets
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub EntradaSobranteProductoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntradaSobranteProductoToolStripMenuItem.Click
        Dim Child As New Frm_Embarques_EntradaSobrante
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub LineasDeTransporteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineasDeTransporteToolStripMenuItem.Click
        Dim Child As New Catalogo_Lineas_Transportes
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ChoferesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChoferesToolStripMenuItem.Click
        Dim Child As New Catalogo_Choferes
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub AgenciasAdunalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Child As New Catalogo_AgenciaAduanas
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub MarcasDeTransporteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarcasDeTransporteToolStripMenuItem.Click
        Dim Child As New Catalogo_Marcas_Transportes
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub TransportesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransportesToolStripMenuItem1.Click
        Dim Child As New Catalogo_transportes
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub CompruebaSaldosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompruebaSaldosToolStripMenuItem.Click
        Dim Child As New Rpt_Cxp_Comprueba_Saldos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub AplicaciónDeAnticiposToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Child As New Frm_CXC_AplicacionDocumentos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub PagosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PagosToolStripMenuItem.Click
        Dim Child As New Frm_CXC_Pagos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub CapturaDeEmbarqueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CapturaDeEmbarqueToolStripMenuItem.Click
        Dim Child As New Frm_Embarques_Captura_Embarque
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub CambioDePrecioRemisionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Child As New Ventas_Modifica_Precios
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub DocumentosDeVentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Child As New Ventas_Movimientos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub CambioDePrecioRemisionToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambioDePrecioRemisionToolStripMenuItem.Click
        Dim Child As New Ventas_Modifica_Precios
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub AgenciasAduanalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgenciasAduanalesToolStripMenuItem.Click
        Dim Child As New Catalogo_AgenciaAduanas
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub EtiquetasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EtiquetasToolStripMenuItem1.Click
        Dim Child As New Frm_Embarques_Etiquetas
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ConsultaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaToolStripMenuItem.Click
        'Dim Child As New Rpt_CXC_Documentos
        'Child.MdiParent = Me
        'm_ChildFormNumber += 1
        'Child.StartPosition = FormStartPosition.CenterScreen
        'Child.Show()
    End Sub

    Private Sub InformeMensualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformeMensualToolStripMenuItem.Click
        Dim Child As New UtileriasGeneraInformeMensual
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub EmpaqueYEmbarqueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmpaqueYEmbarqueToolStripMenuItem.Click
        Dim Child As New Rpt_Embarques_Empaque_Y_Embarque
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub LugaresEntregaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LugaresEntregaToolStripMenuItem.Click
        Dim Child As New Catalogo_Lugares_Entrega
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub EmbarqueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmbarqueToolStripMenuItem.Click
        Dim Child As New Rpt_Embarques_Embarque
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub CostosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CostosToolStripMenuItem.Click
        Dim Child As New Frm_Contabilidad_Costo_corte_acarreo_empaque_embarque
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ConceptosCostosProduccionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Child As New Catalogo_Concepto_Costos_Produccion
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub TiposEnvaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TiposEnvaseToolStripMenuItem.Click
        Dim Child As New Catalogo_TiposEnvases
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub TiposTamañoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TiposTamañoToolStripMenuItem.Click
        Dim Child As New Catalogo_TiposTamaños
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ConfiguraciónEquivalenciasEnvasesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfiguraciónEquivalenciasEnvasesToolStripMenuItem.Click
        Dim Child As New Frm_Embarques_ConfiguracionEquivalenciasEnvases
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ConfiguraciónPesoEnvaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfiguraciónPesoEnvaseToolStripMenuItem.Click
        Dim Child As New Frm_Embarques_ConfiguracionPesoEnvase
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub CapturaDiariaProduccionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Child As New Frm_Embarques_CapturaDiariaProduccion
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub GlobalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GlobalToolStripMenuItem.Click
        Dim Child As New Rpt_Ventas_Global
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ProductosVendidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductosVendidosToolStripMenuItem.Click
        Dim Child As New Rpt_Ventas_ProductosVendidos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub DocumentosDeVentaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocumentosDeVentaToolStripMenuItem.Click
        Dim Child As New Ventas_Movimientos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientesToolStripMenuItem.Click
        Dim Child As New Sis_administracion_clientes
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub DescuentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DescuentosToolStripMenuItem.Click
        Dim Child As New Frm_CXC_Descuentos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub AdministracionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdministracionToolStripMenuItem.Click

    End Sub

    Private Sub SaldoFleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaldoFleteToolStripMenuItem.Click
        Dim Child As New Rpt_Embarques_Saldo_Flete
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub CostoCorteAcarreoEmpaqueYEmbarqueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CostoCorteAcarreoEmpaqueYEmbarqueToolStripMenuItem.Click
        Dim Child As New Frm_Contabilidad_Costo_corte_acarreo_empaque_embarque
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ProducciónEstimadaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProducciónEstimadaToolStripMenuItem.Click
        Dim Child As New Rpt_Embarques_Produccion_Estimada
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ConsultasToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultasToolStripMenuItem3.Click

    End Sub

    Private Sub VentasPorCultivoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentasEstimadasPorCultivoToolStripMenuItem.Click
        My.Forms.Rpt_VentasNetasPorCultivo.MdiParent = Me
        My.Forms.Rpt_VentasNetasPorCultivo.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Rpt_VentasNetasPorCultivo.Show()
        My.Forms.Rpt_VentasNetasPorCultivo.Focus()
    End Sub

    Private Sub ResumenEmpaqueYEmbarqueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResumenEmpaqueYEmbarqueToolStripMenuItem.Click
        My.Forms.Rpt_Resumen_Empaque_y_Embarque.MdiParent = Me
        My.Forms.Rpt_Resumen_Empaque_y_Embarque.StartPosition = FormStartPosition.CenterScreen
        My.Forms.Rpt_Resumen_Empaque_y_Embarque.Show()
        My.Forms.Rpt_Resumen_Empaque_y_Embarque.Focus()
    End Sub

    Private Sub ÁreasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÁreasToolStripMenuItem.Click
        Dim Child As New Cat_Nomina_Areas
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ActividadesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Child As New Cat_Nomina_Actividades
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub PuestosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PuestosToolStripMenuItem.Click
        Dim Child As New Cat_NominaPuestos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub PuntosDePagoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PuntosDePagoToolStripMenuItem.Click
        Dim Child As New Cat_Nomina_PuntoPago
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub TiposDeDeduccionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TiposDeDeduccionesToolStripMenuItem.Click
        Dim Child As New Cat_Nomina_TipoDeducciones
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub TiposDePercepcionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TiposDePercepcionesToolStripMenuItem.Click
        Dim Child As New Cat_Nomina_TipoPercepcion
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub OtroTipoDePercepciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OtroTipoDePercepciónToolStripMenuItem.Click
        Dim Child As New Cat_Nomina_CatPercepciones
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub CambioDePrecioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambioDePrecioToolStripMenuItem.Click
        Dim Child As New Frm_Embarques_CambiaPrecios
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub UnidadMedicaFamiliarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnidadMedicaFamiliarToolStripMenuItem.Click
        Dim Child As New Cat_Nomina_UnidadMedicaFamiliar
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub TrabajadoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrabajadoresToolStripMenuItem.Click
        Dim Child As New Cat_Nomina_Trabajadores
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub CapturaNominaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CapturaNominaToolStripMenuItem.Click
        Dim Child As New Frm_Nomina_CapturaPercepciones
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub PorArtículoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PorArtículoToolStripMenuItem.Click
        Dim Child As New Rpt_Embarques_AgrupadoArticulo
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub VentasNacionalesEstimadasPorCultivoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentasNacionalesEstimadasPorCultivoToolStripMenuItem.Click
        Dim Child As New Rpt_Embarques_VentasNacionalesEstimadas
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ResumenDeVentasExtranjerasYNacionalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResumenDeVentasExtranjerasYNacionalesToolStripMenuItem.Click
        Dim Child As New Rpt_Embarques_ResumenVentas
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub VentasEstimadasPorArticuloToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentasEstimadasPorArticuloToolStripMenuItem.Click
        Dim Child As New Rpt_Embarques_VentasEstimadaArticulo
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub SaldosProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaldosProveedoresToolStripMenuItem.Click
        Dim Child As New Rpt_CXP_SaldosProveedores
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub SincronizaXMLNominaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SincronizaXMLNominaToolStripMenuItem.Click
        Dim Child As New SincronizaXMLNomina
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ConceptosDeGastosDeEmbarqueYEmpaqueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Child As New Catalogo_Conceptos_GastosEmbarqueEmpaque
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub EmbarquesSinSalidaDeEmpaqueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmbarquesSinSalidaDeEmpaqueToolStripMenuItem.Click
        Dim Child As New Rpt_Embarques_SinSalidaEmpaque
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ConfiguraciónDeUsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfiguraciónDeUsuariosToolStripMenuItem.Click
        Dim Child As New ConfiguracionUsuarios
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ConceptosDeINEGIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConceptosDeINEGIToolStripMenuItem.Click
        Dim Child As New Frm_Contabilidad_ConceptosINEGI
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub DescuentosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DescuentosToolStripMenuItem1.Click
        Dim Child As New Frm_CXP_Descuentos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

#Region "Metodos y procedimientos"

    Private Sub DeshabilitaMenus()
        Try
            For Each tsmi As ToolStripMenuItem In Me.MenuStrip.Items
                tsmi.Enabled = False
                DeshabilitaSubMenus(tsmi.DropDownItems)
            Next
        Catch ex As Exception
            HandleError(Me.Name, "DeshabilitaMenus", ex)
        End Try
    End Sub

    Private Sub DeshabilitaSubMenus(ByVal items As ToolStripItemCollection)
        Try
            For Each item As ToolStripItem In items
                If item.GetType().ToString <> "System.Windows.Forms.ToolStripSeparator" Then
                    Me.DeshabilitaSubMenus(DirectCast(item, ToolStripMenuItem).DropDownItems)
                    item.Enabled = False
                End If
            Next

        Catch ex As Exception
            HandleError(Me.Name, "DeshabilitaSubMenus", ex)
        End Try
    End Sub

    Private Sub HabilitaMenus()
        Try
            Me.dtMenus = Usuario.ObtenerDetallePermisosMenus()

            For Each tsmi As ToolStripMenuItem In Me.MenuStrip.Items
                For Each dRow As DataRow In dtMenus.Rows
                    If tsmi.Name = dRow("NOMBRE_MENU") Then
                        tsmi.Enabled = True
                    End If
                Next
                Me.HabilitaSubMenus(tsmi.DropDownItems)
            Next
        Catch ex As Exception
            HandleError(Me.Name, "HabilitaMenus", ex)
        End Try
    End Sub

    Private Sub HabilitaSubMenus(ByVal items As ToolStripItemCollection)
        Try
            For Each item As ToolStripItem In items
                If item.GetType().ToString <> "System.Windows.Forms.ToolStripSeparator" Then
                    For Each dRow As DataRow In dtMenus.Rows
                        If item.Name = dRow("NOMBRE_MENU").ToString Then
                            item.Enabled = True
                        End If
                    Next
                    Me.HabilitaSubMenus(DirectCast(item, ToolStripMenuItem).DropDownItems)
                End If
            Next
        Catch ex As Exception
            HandleError(Me.Name, "HabilitaSubMenus", ex)
        End Try
    End Sub
#End Region

    Private Sub CostoDeMaterialDeEmpaqueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CostoDeMaterialDeEmpaqueToolStripMenuItem.Click
        Dim Child As New Rpt_Embarques_CostoEmpaque
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub EstadoFinancieroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadoFinancieroToolStripMenuItem.Click
        Dim Child As New Frm_contabilidad_Estados_Financieros
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub EnvioDeFacturasElectronicasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnvioDeFacturasElectronicasToolStripMenuItem.Click
        Dim Child As New Frm_EnviaFacturaElectronicas
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub GlobalDeDocumentosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GlobalDeDocumentosToolStripMenuItem1.Click
        Dim Child As New Rpt_CXC_Documentos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub AuxiliarDeClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuxiliarDeClientesToolStripMenuItem.Click
        Dim Child As New Rpt_CXC_AuxClientes
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub TopTenClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TopTenClientesToolStripMenuItem.Click
        Dim Child As New Rpt_Ventas_TopTenProductos
        Child.ModoAgrupado = Rpt_Ventas_TopTenProductos.enumModoAgrupado.CLIENTES
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub TopTenProductosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TopTenProductosToolStripMenuItem.Click
        Dim Child As New Rpt_Ventas_TopTenProductos
        Child.ModoAgrupado = Rpt_Ventas_TopTenProductos.enumModoAgrupado.PRODUCTOS
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub CantidadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CantidadToolStripMenuItem.Click
        Dim Child As New Rpt_Q_ComparativosVenta
        Child.ModoAgrupado = Rpt_Q_ComparativosVenta.enumComparativo.CANTIDAD
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub PrecioPromedioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrecioPromedioToolStripMenuItem.Click
        Dim Child As New Rpt_Q_ComparativosVenta
        Child.ModoAgrupado = Rpt_Q_ComparativosVenta.enumComparativo.PRECIO_PROMEDIO
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub VentaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentaToolStripMenuItem.Click
        Dim Child As New Rpt_Q_ComparativosVenta
        Child.ModoAgrupado = Rpt_Q_ComparativosVenta.enumComparativo.VENTA
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub AplicaciónDeAnticiposToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AplicaciónDeAnticiposToolStripMenuItem.Click
        Dim Child As New Frm_CXC_AplicacionDocumentos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ConfiguraciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfiguraciónToolStripMenuItem.Click
        Dim Child As New Frm_Nomina_Configuracion
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub AltasBajasIntegraciónSUAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AltasBajasIntegraciónSUAToolStripMenuItem.Click
        Dim Child As New Frm_Nomina_AltaBajaIntegracionSUA
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub EdiciónSUAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EdiciónSUAToolStripMenuItem.Click
        Dim Child As New Frm_Nomina_EdicionSUA
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub SUAControlToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SUAControlToolStripMenuItem.Click
        Dim Child As New Frm_Nomina_ControlSUA
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub DeduccionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeduccionesToolStripMenuItem.Click
        Dim Child As New Frm_Nomina_Deducciones
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub CredencialesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CredencialesToolStripMenuItem.Click
        Dim Child As New Frm_Nomina_Credenciales
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub CultivosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CultivosToolStripMenuItem.Click
        Dim Child As New Catalogo_Cultivos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub CapturaDeCajasProducidasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CapturaDeCajasProducidasToolStripMenuItem.Click
        Dim Child As New Frm_Embarques_CapturaCajasProducidas
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub AbrircerrarEjerciciosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrircerrarEjerciciosToolStripMenuItem.Click
        Dim Child As New Frm_AbrirCerrar_Ejercicio
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub AgunaldosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgunaldosToolStripMenuItem.Click
        Dim Child As New Frm_Nomina_Aguinaldos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub EmbarquesSinFleteGeneradoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmbarquesSinFleteGeneradoToolStripMenuItem.Click
        Dim Child As New Rpt_Embarques_FletesNoGenerados
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ControlDePagosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDePagosToolStripMenuItem.Click
        Dim Child As New Frm_CXP_ControlPagos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ComparativosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Child As New Frm_Contabilidad_Comparativas_Financieras
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ConceptosDeFletesYEquipoPropioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Child As New Catalogo_Conceptos_Fletes_Equipo
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub PresupuestoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PresupuestoToolStripMenuItem.Click
        Dim Child As New Frm_Proyecto_presupuesto
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub NavegadorDePresupuestosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavegadorDePresupuestosToolStripMenuItem.Click
        Dim Child As New Frm_Contabilidad_NavegadorPresupuestos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ConceptosDeActividadesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConceptosDeActividadesToolStripMenuItem.Click
        Dim Child As New Cat_Nomina_ConceptosActividades
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub AfiliaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AfiliaciónToolStripMenuItem.Click
        Dim Child As New Frm_NumeroSeguro
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub EmpaqueContraProducciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmpaqueContraProducciónToolStripMenuItem.Click
        Dim Child As New Rpt_Embarques_EmpaqueVsProduccion
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub MonitoDeTimbradosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonitoDeTimbradosToolStripMenuItem.Click
        Dim Child As New Frm_Monitor_CFDi
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub CapturaVentassemanalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CapturaVentassemanalesToolStripMenuItem.Click
        Dim Child As New Ventas_Semanales
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub PagosCobradosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PagosCobradosToolStripMenuItem.Click
        Dim Child As New Frm_CXP_PagosCobrados
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub DetalleNóminaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetalleNóminaToolStripMenuItem.Click
        Dim Child As New Rpt_Nomina_Detalle
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub NavegadorToolStripMenuItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NavegadorToolStripMenuItem.Click
        Dim Child As New Frm_Nomina_NavegadorCostosPresupuesto
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub EmbarquesMasivosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmbarquesMasivosToolStripMenuItem.Click
        Dim Child As New frmEmbarquesMasivos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub RevisiónDeCXPToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles RevisiónDeCXPToolStripMenuItem.Click
        Dim Child As New Frm_CXP_Revision
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ActividadesToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
        Dim Child As New Cat_Nomina_Actividades
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub NavegadorDeCostosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NavegadorDeCostosToolStripMenuItem.Click
        Dim Child As New RptCentrosCostosNavegador
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.Show()
    End Sub

    Private Sub ReporteDeCostosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeCostosToolStripMenuItem.Click
        Dim Child As New Rpt_CentroCostos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.Show()
    End Sub

    Private Sub PólizasDeCostosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PólizasDeCostosToolStripMenuItem.Click
        Dim Child As New FrmPolizaCostos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.Show()
    End Sub

    Private Sub TiposProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TiposProveedoresToolStripMenuItem.Click
        Dim Child As New Sis_Tipos_Proveedores
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.Show()
    End Sub

    Private Sub SincronizaXMLListadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SincronizaXMLListadoToolStripMenuItem.Click
        Dim Child As New SincronizaXMLAsistencia
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.Show()
    End Sub

    Private Sub ListadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoToolStripMenuItem.Click
        Dim Child As New Rpt_Nomina_Listado
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.Show()
    End Sub

    Private Sub LotesDeCostosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LotesDeCostosToolStripMenuItem.Click
        Dim Child As New Rpt_Inventario_Lotes_Costos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.Show()
    End Sub

    Private Sub LotesToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles LotesToolStripMenuItem.Click
        Dim ChildCXP As New Catalogo_Lotes
        ChildCXP.MdiParent = Me
        m_ChildFormNumber += 1
        ChildCXP.Show()
    End Sub

    Private Sub EmbarqueDetalleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmbarqueDetalleToolStripMenuItem.Click
        Dim Child As New Rpt_Embarques_GlobalDetalle
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub UnidadesDeVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnidadesDeVentaToolStripMenuItem.Click
        Dim Child As New Catalogo_UnidadesVenta
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub TipoDeCategoriasToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles TipoDeCategoriasToolStripMenuItem.Click
        Dim Child As New Catalogo_Tipos_Categorias
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.Show()
    End Sub

    Private Sub ProyectoSiembraToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ProyectoSiembraToolStripMenuItem.Click
        Dim Child As New ProyectoSiembra
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.Show()
    End Sub

    Private Sub VehículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VehículosToolStripMenuItem.Click
        Dim Child As New Catalogo_Vehiculos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.Show()
    End Sub

    Private Sub CategoriasToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles CategoriasToolStripMenuItem.Click
        Dim Child As New Catalogo_Categorias
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.Show()
    End Sub

    Private Sub ConceptosToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ConceptosToolStripMenuItem.Click
        Dim Child As New Catalogo_Conceptos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.Show()
    End Sub

    Private Sub CentrosDeCostosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CentrosDeCostosToolStripMenuItem.Click
        Dim Child As New Cat_Nomina_CentroCosto
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub PlazasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlazasToolStripMenuItem.Click
        Dim Child As New SIS_Plazas
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ListaDePreciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListaDePreciosToolStripMenuItem.Click
        Dim Child As New Catalogo_Precios_Venta
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ConceptosDePagosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConceptosDePagosToolStripMenuItem.Click
        Dim Child As New Catalogo_Conceptos_Pagos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub DocumentosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DocumentosToolStripMenuItem.Click
        Dim Child As New Sis_Documentos
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub DevolucionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DevolucionesToolStripMenuItem.Click
        Dim Child As New Frm_CXC_Devoluciones
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub PropietariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PropietariosToolStripMenuItem.Click
        Dim Child As New Catalogo_Propietarios
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub ImportarClienteSucursalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportarClienteSucursalToolStripMenuItem.Click
        Dim Child As New ImportarClientes
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub

    Private Sub BorrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorrarToolStripMenuItem.Click
        Dim Child As New borrar
        Child.MdiParent = Me
        m_ChildFormNumber += 1
        Child.StartPosition = FormStartPosition.CenterScreen
        Child.Show()
    End Sub
End Class