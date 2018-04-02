Option Strict On

Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Class_CXP_Devoluciones_Global

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_CXP_DEVOLUCION_GLOBAL As Integer
    Private _FOLIO_DEVOLUCION As String
    Private _FOLIO_COMPRA As String
    Private _FOLIO_DESCUENTO_DEVOLUCION As String
    Private _FECHA As Date
    Private _FECHA_SERVIDOR As Date
    Private _CODIGO_DOCUMENTO As String
    Private _CODIGO_PLAZA As Integer
    Private _ESTATUS_DEVOLUCION As String
    Private _CONCEPTO As String
    Private _TIPO_DE_CAMBIO As Decimal
    Private _SUBTOTAL As Decimal
    Private _IMPUESTO As Decimal
    Private _TOTAL As Decimal
    Private _TOTAL_USD As Decimal
    Private _IEPS_DESGLOSADO As Decimal
    Private _IEPS_INCLUIDO As Decimal
    Private _IMPUESTO_PORCENTAJE As Decimal
    Private _COSTO As Decimal
    Private _FOLIO_POLIZA As String
    Private _CODIGO_USUARIO_GRABO As Integer
    Private _CODIGO_USUARIO_CANCELO As Integer
    Private _FECHA_CANCELACION As Date
    Private _FECHA_CANCELACION_SERVIDOR As Date
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
    Private _Nombre_Formato As String
    Private _CODIGO_PROVEEDOR As String
    Private _NOMBRE_PROVEEDOR As String
    Private _CODIGO_ALMACEN As String
    Private _NOMBRE_ALMACEN As String
    Private _NOMBRE_USUARIO_GRABO As String
    Private _NOMBRE_USUARIO_CANCELO As String
#End Region

#Region "Campos públicos"
    Public oDetalle As Class_CXP_Devoluciones_Detalle
#End Region

#Region "Campos privados"

#End Region

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
#End Region

#End Region

#Region "Propiedades"
#Region "Propiedades Campos de la tabla"
    Public ReadOnly Property ID_CXP_DEVOLUCION_GLOBAL() As Integer
        Get
            Return Me._ID_CXP_DEVOLUCION_GLOBAL
        End Get
    End Property

    Public Property FOLIO_DEVOLUCION() As String
        Get
            Return Me._FOLIO_DEVOLUCION
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_DEVOLUCION = Value
        End Set
    End Property

    Public Property FOLIO_COMPRA() As String
        Get
            Return Me._FOLIO_COMPRA
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_COMPRA = Value
        End Set
    End Property

    Public Property FOLIO_DESCUENTO_DEVOLUCION() As String
        Get
            Return Me._FOLIO_DESCUENTO_DEVOLUCION
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_DESCUENTO_DEVOLUCION = Value
        End Set
    End Property

    Public Property FECHA() As Date
        Get
            Return Me._FECHA
        End Get
        Set(ByVal Value As Date)
            Me._FECHA = Value
        End Set
    End Property

    Public ReadOnly Property FECHA_SERVIDOR() As Date
        Get
            Return Me._FECHA_SERVIDOR
        End Get
    End Property

    Public Property CODIGO_DOCUMENTO() As String
        Get
            Return Me._CODIGO_DOCUMENTO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_DOCUMENTO = Value
        End Set
    End Property

    Public ReadOnly Property CODIGO_PLAZA() As Integer
        Get
            Return Me._CODIGO_PLAZA
        End Get
    End Property

    Public ReadOnly Property ESTATUS_DEVOLUCION() As String
        Get
            Return Me._ESTATUS_DEVOLUCION
        End Get
    End Property

    Public ReadOnly Property CODIGO_USUARIO_GRABO() As Integer
        Get
            Return Me._CODIGO_USUARIO_GRABO
        End Get
    End Property

    Public ReadOnly Property CODIGO_USUARIO_CANCELO() As Integer
        Get
            Return Me._CODIGO_USUARIO_CANCELO
        End Get
    End Property

    Public Property CONCEPTO() As String
        Get
            Return Me._CONCEPTO
        End Get
        Set(ByVal Value As String)
            Me._CONCEPTO = Value
        End Set
    End Property

    Public Property TIPO_DE_CAMBIO() As Decimal
        Get
            Return Me._TIPO_DE_CAMBIO
        End Get
        Set(ByVal Value As Decimal)
            Me._TIPO_DE_CAMBIO = Value
        End Set
    End Property

    Public Property SUBTOTAL() As Decimal
        Get
            Return Me._SUBTOTAL
        End Get
        Set(ByVal Value As Decimal)
            Me._SUBTOTAL = Value
        End Set
    End Property

    Public Property IMPUESTO() As Decimal
        Get
            Return Me._IMPUESTO
        End Get
        Set(ByVal Value As Decimal)
            Me._IMPUESTO = Value
        End Set
    End Property

    Public Property TOTAL() As Decimal
        Get
            Return Me._TOTAL
        End Get
        Set(ByVal Value As Decimal)
            Me._TOTAL = Value
        End Set
    End Property

    Public Property IEPS_DESGLOSADO() As Decimal
        Get
            Return Me._IEPS_DESGLOSADO
        End Get
        Set(ByVal Value As Decimal)
            Me._IEPS_DESGLOSADO = Value
        End Set
    End Property

    Public Property IEPS_INCLUIDO() As Decimal
        Get
            Return Me._IEPS_INCLUIDO
        End Get
        Set(ByVal Value As Decimal)
            Me._IEPS_INCLUIDO = Value
        End Set
    End Property

    Public Property IMPUESTO_PORCENTAJE() As Decimal
        Get
            Return Me._IMPUESTO_PORCENTAJE
        End Get
        Set(ByVal Value As Decimal)
            Me._IMPUESTO_PORCENTAJE = Value
        End Set
    End Property

    Public Property COSTO() As Decimal
        Get
            Return Me._COSTO
        End Get
        Set(ByVal Value As Decimal)
            Me._COSTO = Value
        End Set
    End Property

    Public Property FOLIO_POLIZA() As String
        Get
            Return Me._FOLIO_POLIZA
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_POLIZA = Value
        End Set
    End Property

    Public Property FECHA_CANCELACION() As Date
        Get
            Return Me._FECHA_CANCELACION
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_CANCELACION = Value
        End Set
    End Property

    Public ReadOnly Property FECHA_CANCELACION_SERVIDOR() As Date
        Get
            Return Me._FECHA_CANCELACION_SERVIDOR
        End Get
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property

    Public ReadOnly Property Nombre_Formato() As String
        Get
            Return Me._Nombre_Formato
        End Get
    End Property

    Public ReadOnly Property CODIGO_MODULO() As String
        Get
            Return "DEVC"
        End Get
    End Property

    Public ReadOnly Property CODIGO_PROVEEDOR() As String
        Get
            Return Me._CODIGO_PROVEEDOR
        End Get
    End Property

    Public ReadOnly Property NOMBRE_PROVEEDOR() As String
        Get
            Return Me._NOMBRE_PROVEEDOR
        End Get
    End Property

    Public ReadOnly Property CODIGO_ALMACEN() As String
        Get
            Return Me._CODIGO_ALMACEN
        End Get
    End Property

    Public ReadOnly Property NOMBRE_ALMACEN() As String
        Get
            Return Me._NOMBRE_ALMACEN
        End Get
    End Property

    Public ReadOnly Property NOMBRE_USUARIO_GRABO() As String
        Get
            Return Me._NOMBRE_USUARIO_GRABO
        End Get
    End Property

    Public ReadOnly Property NOMBRE_USUARIO_CANCELO() As String
        Get
            Return Me._NOMBRE_USUARIO_GRABO
        End Get
    End Property

#End Region

#Region "Propiedades de campos privados"

#End Region

#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_CXP_Descuentos"
        End Get
    End Property
#End Region
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection(Empresa_Sistema.conexion)
        oDetalle = New Class_CXP_Devoluciones_Detalle
    End Sub

    Public Sub New(ByVal FolioDevolucion As String)
        Me.New()
        Try
            Me._FOLIO_DEVOLUCION = FolioDevolucion
            If Me.Consultar = False Then
                'Throw New Exception("El documento de venta no existe.")
            Else
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "New", ex)
        End Try
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function GrabaDevolucionGlobal() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CXP_DEVOLUCIONES_GRABA_GLOBAL"

            Try
                sqlParametro = .Parameters.Add("@FOLIO_DEVOLUCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" : sqlParametro.Direction = ParameterDirection.InputOutput
                sqlParametro = .Parameters.Add("@FOLIO_COMPRA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_COMPRA
                sqlParametro = .Parameters.Add("@FOLIO_DESCUENTO_DEVOLUCION_APLICADO", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" : sqlParametro.Direction = ParameterDirection.InputOutput
                sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA
                sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_DOCUMENTO
                sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
                sqlParametro = .Parameters.Add("@CONCEPTO", SqlDbType.NVarChar, 200) : sqlParametro.Value = Me._CONCEPTO.ToUpper
                sqlParametro = .Parameters.Add("@TIPO_DE_CAMBIO", SqlDbType.Decimal) : sqlParametro.Value = Me._TIPO_DE_CAMBIO
                sqlParametro = .Parameters.Add("@SUBTOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._SUBTOTAL
                sqlParametro = .Parameters.Add("@IMPUESTO", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO
                sqlParametro = .Parameters.Add("@TOTAL", SqlDbType.Decimal) : sqlParametro.Value = Me._TOTAL
                sqlParametro = .Parameters.Add("@IEPS_DESGLOSADO", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_DESGLOSADO
                sqlParametro = .Parameters.Add("@IEPS_INCLUIDO", SqlDbType.Decimal) : sqlParametro.Value = Me._IEPS_INCLUIDO
                sqlParametro = .Parameters.Add("@IMPUESTO_PORCENTAJE", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPUESTO_PORCENTAJE
                sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario

                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True

                Me._FOLIO_DEVOLUCION = "" & .Parameters("@FOLIO_DEVOLUCION").Value.ToString
                Me._FOLIO_DESCUENTO_DEVOLUCION = "" & .Parameters("@FOLIO_DESCUENTO_DEVOLUCION_APLICADO").Value.ToString
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "GrabaDevolucionGlobal", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand("SELECT DG.ID_CXP_DEVOLUCION_GLOBAL,DG.FOLIO_DEVOLUCION,DG.FOLIO_COMPRA,DG.FOLIO_DESCUENTO_DEVOLUCION,DG.FECHA,DG.FECHA_SERVIDOR,DG.CODIGO_DOCUMENTO,DG.CODIGO_PLAZA,DG.ESTATUS_DEVOLUCION,DG.CONCEPTO," &
                                  "DG.TIPO_DE_CAMBIO,DG.SUBTOTAL,DG.IMPUESTO,DG.TOTAL,DG.TOTAL_USD,DG.IEPS_DESGLOSADO,DG.IEPS_INCLUIDO,DG.IMPUESTO_PORCENTAJE,DG.COSTO,DG.FOLIO_POLIZA,DG.CODIGO_USUARIO_GRABO,S1.NOMBRE_USUARIO NOMBRE_USUARIO_GRABO," &
                                    "DOC.NOMBRE_FORMATO,S2.NOMBRE_USUARIO NOMBRE_USUARIO_CANCELO," &
                                    "VG.CODIGO_ALMACEN,ALM.NOMBRE_ALMACEN,VG.CODIGO_PROVEEDOR,PRO.NOMBRE_PROVEEDOR " &
                                    "FROM CXP_DEVOLUCION_GLOBAL DG " &
                                    "INNER JOIN SIS_USUARIOS S1 ON(DG.CODIGO_USUARIO_GRABO=S1.CODIGO_USUARIO) " &
                                    "LEFT JOIN SIS_USUARIOS S2 ON(DG.CODIGO_USUARIO_CANCELO=S2.CODIGO_USUARIO) " &
                                    "INNER JOIN COMPRA_GLOBAL VG ON(DG.FOLIO_COMPRA=VG.FOLIO_COMPRA) " &
                                    "INNER JOIN CAT_ALMACENES ALM ON(VG.CODIGO_ALMACEN=ALM.CODIGO_ALMACEN) " &
                                    "INNER JOIN CAT_PROVEEDORES PRO ON(VG.CODIGO_PROVEEDOR=PRO.CODIGO_PROVEEDOR) " &
                                    "INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO DOC ON(DG.CODIGO_DOCUMENTO=DOC.CODIGO_DOCUMENTO) " &
                                    "WHERE DG.FOLIO_DEVOLUCION='" & sReplace(Me._FOLIO_DEVOLUCION) & "' AND DG.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA.ToString, Me._Conexion)

        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._ID_CXP_DEVOLUCION_GLOBAL = CInt(dReader("ID_CXP_DEVOLUCION_GLOBAL"))
                    Me._FOLIO_DEVOLUCION = "" & dReader("FOLIO_DEVOLUCION").ToString()
                    Me._FOLIO_COMPRA = "" & dReader("FOLIO_COMPRA").ToString()
                    Me._FOLIO_DESCUENTO_DEVOLUCION = "" & dReader("FOLIO_DESCUENTO_DEVOLUCION").ToString()
                    Me._FECHA = CDate(dReader("FECHA"))
                    Me._FECHA_SERVIDOR = CDate(dReader("FECHA_SERVIDOR"))
                    Me._CODIGO_DOCUMENTO = "" & dReader("CODIGO_DOCUMENTO").ToString()
                    Me._CODIGO_PLAZA = CInt(dReader("CODIGO_PLAZA"))
                    Me._ESTATUS_DEVOLUCION = "" & dReader("ESTATUS_DEVOLUCION").ToString()
                    Me._CONCEPTO = "" & dReader("CONCEPTO").ToString()
                    Me._TIPO_DE_CAMBIO = CDec(dReader("TIPO_DE_CAMBIO"))
                    Me._SUBTOTAL = CDec(dReader("SUBTOTAL"))
                    Me._IMPUESTO = CDec(dReader("IMPUESTO"))
                    Me._TOTAL = CDec(dReader("TOTAL"))
                    Me._TOTAL_USD = CDec(dReader("TOTAL_USD"))
                    Me._IEPS_DESGLOSADO = CDec(dReader("IEPS_DESGLOSADO"))
                    Me._IEPS_INCLUIDO = CDec(dReader("IEPS_INCLUIDO"))
                    Me._IMPUESTO_PORCENTAJE = CDec(dReader("IMPUESTO_PORCENTAJE"))
                    Me._COSTO = CDec(dReader("COSTO"))
                    Me._FOLIO_POLIZA = "" & dReader("FOLIO_POLIZA").ToString()
                    Me._CODIGO_USUARIO_GRABO = CInt(dReader("CODIGO_USUARIO_GRABO"))

                    If Me._ESTATUS_DEVOLUCION = "C" Then
                        Me._CODIGO_USUARIO_CANCELO = CInt(dReader("CODIGO_USUARIO_CANCELO"))
                        Me._NOMBRE_USUARIO_CANCELO = "" & dReader("NOMBRE_USUARIO_CANCELO").ToString
                        Me._FECHA_CANCELACION = CDate(dReader("FECHA_CANCELACION"))
                        Me._FECHA_CANCELACION_SERVIDOR = CDate(dReader("FECHA_CANCELACION_SERVIDOR"))
                    End If

                    Me._Nombre_Formato = "" & Trim(dReader("NOMBRE_FORMATO").ToString)

                    Me._CODIGO_PROVEEDOR = "" & dReader("CODIGO_PROVEEDOR").ToString()
                    Me._NOMBRE_PROVEEDOR = "" & dReader("NOMBRE_PROVEEDOR").ToString()
                    Me._NOMBRE_USUARIO_GRABO = "" & dReader("NOMBRE_USUARIO_GRABO").ToString()
                    Me._CODIGO_ALMACEN = "" & dReader("CODIGO_ALMACEN").ToString()
                    Me._NOMBRE_ALMACEN = "" & dReader("NOMBRE_ALMACEN").ToString()

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With

        Return bResultado
    End Function

    Public Function Cancelar() As Boolean 'Pendiente de agregar funcionalidad
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CXC_DEVOLUCIONES_CANCELA"

            sqlParametro = .Parameters.Add("@FOLIO_DEVOLUCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_DEVOLUCION
            sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_DOCUMENTO
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@FECHA_CANCELACION", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_CANCELACION
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Cancelar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function AfectaInventarios() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CXP_DEVOLUCIONES_AFECTA_INVENTARIOS"

            sqlParametro = .Parameters.Add("@FOLIO_DEVOLUCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_DEVOLUCION
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "AfectaInventarios", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function BusquedaVisual_PorFolio() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de devoluciones en CXP."
        f.sCampo = "DG.FOLIO_DEVOLUCION"
        f.sOrder = "DG.FOLIO_DEVOLUCION"
        f.sTable = "CXP_DEVOLUCION_GLOBAL"
        f.sQl = "SELECT DG.FOLIO_DEVOLUCION,DG.TOTAL,DBO.FN_FORMAT_FECHA_CORTO(DG.FECHA) FECHA,PRO.NOMBRE_PROVEEDOR,VG.CONCEPTO FROM CXP_DEVOLUCION_GLOBAL DG " &
            "INNER JOIN VENTA_GLOBAL VG ON(DG.FOLIO_VENTA=VG.FOLIO_VENTA) INNER JOIN CAT_PROVEEDORES PRO ON(VG.CODIGO_PROVEEDOR=PRO.CODIGO_PROVEEDOR) " &
            "WHERE DG.CODIGO_PLAZA='" & Usuario.Codigo_Plaza & "' AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "BusquedaVisual_PorFolio", ex)
        End Try
        Return Resultado
    End Function

    Public Function ObtenerDetalle() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        sSQL = "SELECT DR.CODIGO_ARTICULO," &
            "CASE WHEN ART.ES_SERIALIZABLE = '1' THEN 'SER' WHEN ART.INVENTARIABLE= '1' THEN 'INV' ELSE 'NIV' END TIPO_CONTROL_INVENTARIO," &
            "VR.DESCRIPCION,DR.CANTIDAD,DR.PRECIO,VR.UNIDAD_VENTA,DR.IMPUESTO_PORCENTAJE,DR.IMPORTE,DR.IMPUESTO_IMPORTE,DR.ID_COMPRA_DETALLE,DR.IEPS_PORCENTAJE,DR.IEPS_UNITARIO,DR.IEPS_IMPORTE,DR.BASE_IEPS,DR.BASE_IVA " &
            "FROM CXP_DEVOLUCION_DETALLE DR " &
            "INNER JOIN CAT_ARTICULOS ART ON(DR.CODIGO_ARTICULO=ART.CODIGO_ARTICULO) " &
            "INNER JOIN COMPRA_DETALLE VR ON(DR.ID_COMPRA_DETALLE=VR.ID_COMPRA_DETALLE) " &
            "WHERE DR.FOLIO_DEVOLUCION='" & sReplace(Me._FOLIO_DEVOLUCION) & "' " &
            "ORDER BY DR.ID_CXP_DEVOLUCION_DETALLE"

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)

            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerDetalle", ex)
        End Try

        Return dTabla
    End Function

    Public Function ObtenerDetalleSeries() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        'Private igySeriePosicion As Short = 1
        'Private igySerieCodigo As Short = 2
        'Private igySerieDescripcion As Short = 3
        'Private igySerieIdInventarioLotesCostos As Short = 4
        'Private igySerieNumeroSerie As Short = 5
        'Private igySerieIdOrigen As Short = 6

        sSQL = "SELECT 1 POSICION,I.CODIGO_ARTICULO,A.DESCRIPCION,S.ID_INVENTARIO_LOTES_COSTOS,C.NUMERO_SERIE,0 ID_COMPRA_DETALLE " &
        "FROM INVENTARIO_MOVIMIENTOS_DETALLE I " &
        "INNER JOIN INVENTARIO_LOTES_SALIDAS S ON(I.ID_INVENTARIO_MOVIMIENTOS_DETALLE=S.ID_INVENTARIO_MOVIMIENTOS_DETALLE) " &
        "INNER JOIN INVENTARIO_LOTES_COSTOS C ON(S.ID_INVENTARIO_LOTES_COSTOS=C.ID_INVENTARIO_LOTES_COSTOS) " &
        "INNER JOIN CAT_ARTICULOS A ON(I.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " &
        "WHERE I.FOLIO_MOVIMIENTO_INVENTARIO='" & Me._FOLIO_DEVOLUCION & "' AND LEN(C.NUMERO_SERIE)>0 " &
        "ORDER BY S.ID_INVENTARIO_LOTES_SALIDAS "

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerDetalleSeries", ex)
        End Try

        Return dTabla
    End Function

    Public Sub NuevoRenglon()
        Me.oDetalle = New Class_CXP_Devoluciones_Detalle
    End Sub

    Public Sub Imprimir()
        Dim Rpt As New ReportDocument
        Dim oReporte As Class_Reporte

        Try
            oReporte = New Class_Reporte(Me._Nombre_Formato, Rpt, False)

            If Not oReporte.RptCargado Then
                Exit Sub
            End If

            Rpt.SetParameterValue("@FOLIO_DEVOLUCION", Me._FOLIO_DEVOLUCION)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.Show()

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "Imprimir", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Public Function BusquedaVisualSeriesDevolucion(ByVal FolioCompra As String, ByVal sCodigoArticulo As String, ByVal IdOrigen As String) As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        Dim oArticulo As New Class_CatArticulos(sCodigoArticulo)

        f.Text = "Búsqueda de series del artículo : " & oArticulo.DESCRIPCION
        f.sCampo = "LC.NUMERO_SERIE"
        f.sOrder = "LC.ID_INVENTARIO_LOTES_COSTOS"
        f.sTable = "VW_INVENTARIO_LOTES_COSTOS_EXTENDIDO"
        f.sQl = "SELECT LC.ID_INVENTARIO_LOTES_COSTOS,LC.NUMERO_SERIE,DBO.FN_FORMAT_FECHA_CORTO(LC.FECHA) " &
                "FROM COMPRA_DETALLE R " &
                "INNER JOIN INVENTARIO_MOVIMIENTOS_DETALLE IR ON(R.ID_COMPRA_DETALLE=IR.ID_ORIGEN AND R.FOLIO_COMPRA=IR.FOLIO_MOVIMIENTO_INVENTARIO) " &
                "INNER JOIN VW_INVENTARIO_LOTES_COSTOS_EXTENDIDO LC ON(IR.ID_INVENTARIO_MOVIMIENTOS_DETALLE=LC.ID_INVENTARIO_MOVIMIENTOS_DETALLE) " &
                "WHERE R.ID_COMPRA_DETALLE=" & IdOrigen.ToString & " AND R.FOLIO_COMPRA='" & FolioCompra & "' AND "
        f.Inicia("%")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "BusquedaVisualSeriesDevolucion", ex)
        End Try
        Return Resultado
    End Function
#End Region

End Class
