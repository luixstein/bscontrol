Imports System.Xml

Public Class Frm_CFDI_VisorXML

#Region "Variables de control"
    Private _UUID As String
#End Region

#Region "Campos grid conceptos"
    Private iGyConCantidad As Integer = 1
    Private iGyConClaveProdServ As Integer = 2
    Private iGyConClaveUnidad As Integer = 3
    Private iGyConDescripcion As Integer = 4
    Private iGyConValorUnitario As Integer = 5
    Private iGyConImporte As Integer = 6
    Private iGyConDescuento As Integer = 7

    Private iGyConImpTraslado_o_Retencion As Integer = 8
    Private iGyConImpBase As Integer = 9
    Private iGyConImpImpuesto As Integer = 10
    Private iGyConImpTipoFactor As Integer = 11
    Private iGyConImpTasaOCuota As Integer = 12
    Private iGyConImpImporte As Integer = 13
#End Region

#Region "Campos grid impuestos"
    Private iGyImpTipo As Integer = 1
    Private iGyImpImpuesto As Integer = 2
    Private iGyImpTipoFactor As Integer = 3
    Private iGyImpTasaOCuota As Integer = 4
    Private iGyImpImporte As Integer = 5
#End Region

#Region "Propiedades"
    Public WriteOnly Property UUID() As String
        Set(ByVal Value As String)
            Me._UUID = Value
        End Set
    End Property
#End Region

#Region "Opciones"

#End Region

#Region "Eventos de objetos"

#Region "Eventos"

#End Region

#Region "Eventos Genericos"

#End Region

#End Region

#Region "Métodos y procedimientos"
    Public Sub New(ByVal sUUID As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Consultar()
    End Sub

    Private Function Consultar() As Boolean
        Const sProcedure As String = "Consultar"
        Dim bResultado As Boolean = False
        Try
            'Dim oXML As New XmlDocument()
            'oXML.Load()
            Dim sXML As String = New Class_find("SELECT CADENA_XML FROM EXPEDIENTES_BS..XML_REPOSITORIO_GLOBAL WHERE UUID='" + sReplace(Me._UUID) + "'").Result1

            If txtLEN(sXML) = False Then
                MsgBox("El UUID " + Me._UUID + " no existe en la base de datos de XML. Favor de verificar", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            Dim oCFDI As New CFDIXML.ClassCFDI(sXML, False) 'Internamente: ya se valida que este timbrado

            If oCFDI.XMLCargado = False Then
                Return False
            End If

            If oCFDI.Comprobante.Moneda <> "MXN" Then
                Me.txtAvisoUSD.Visible = True
            End If

            Me.txtUUID.Text = oCFDI.ComplementoTFD.UUID
            Me.txtFolio.Text = oCFDI.Comprobante.Folio
            Me.txtSerie.Text = oCFDI.Comprobante.Serie
            Me.txtEmisorRFC.Text = oCFDI.Emisor.rfc
            Me.txtEmisorNombre.Text = oCFDI.Emisor.nombre
            Me.txtReceptorRFC.Text = oCFDI.Receptor.rfc
            Me.txtReceptorNombre.Text = oCFDI.Receptor.nombre



        Catch ex As Exception
            HandleError(Me.Text, "Consultar", ex)
        End Try

        Return bResultado
    End Function
#End Region

End Class