Imports CrystalDecisions.CrystalReports.Engine

Public MustInherit Class Class_Catalogos
    Public MustOverride ReadOnly Property Nombre_Catalogo() As String       'Nombre del Catálogo.
    Public MustOverride Property Nombre_Reporte() As String                'Nombre del reporte del listado de catálogo (.rpt)
    Public MustOverride Function Actualizar() As Boolean                    'Función para actualizar a un determidado elemento del catálogo.
    Public MustOverride Function Insertar() As Boolean                      'Función para insertar un nuevo elemento del catálogo.
    Public MustOverride Function Consultar() As Boolean                     'Función para consultar a un determidado elemento del catálogo.
    Public MustOverride Function ObtenerElementos() As Data.DataTable       'Función para obtener a todos los elementos de un deter. catálogo.
    Public MustOverride Function BusquedaVisual_PorCodigo() As String       'Función para ver la búsqueda visual por código.
    Public MustOverride Function BusquedaVisual_PorDescripcion() As String  'Función para ver la búsqueda visual por descripción.

    Public Overridable Sub Imprimir_Listado()   'Función para ver la búsqueda visual por descripción.
        If Len(Nombre_Reporte) > 0 Then
            Dim Rpt As New ReportDocument
            Dim oReporte As Class_Reporte
            Try
                oReporte = New Class_Reporte(Nombre_Reporte, Rpt)

                Dim frm As New Reporte(Rpt)
                frm.CRViewer.ShowGroupTreeButton = False
                frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                frm.Show()

            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, " Impresión del listado :" + Me.Nombre_Catalogo, ex)
            Finally
                oReporte = Nothing
                'Rpt.Dispose()
            End Try
        Else
            MsgBox("El nombre del reporte no ha sido especificado, no hay nada que imprimir.", MsgBoxStyle.Critical, Me.Nombre_Catalogo)
        End If
    End Sub
#Region "Campos"

#Region "Campos de la tabla"

#End Region

#Region "Campos ligados a la tabla"

#End Region

#Region "Campos públicos"
    Public Estatus As String
#End Region


#Region "Campos privados"

#End Region

#Region "Campos de sistema"

#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"

#End Region

#Region "Propiedades de campos ligados a la tabla"

#End Region

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

#End Region
#Region "Propiedades de campos de sistema"


#End Region

#End Region

#Region "Constructor y destructor"

#End Region

#Region "Opciones"

#End Region

#Region "Métodos y procedimientos"

#End Region

#Region "Eventos de objetos"


#Region "Eventos de la lista de elementos"

#End Region

#Region " Eventos de TxtFiltro"

#End Region

#Region "Eventos Genericos"

#End Region


#Region "Keydown específicos"


#End Region

#Region "Validating específicos"

#End Region



#End Region
End Class

