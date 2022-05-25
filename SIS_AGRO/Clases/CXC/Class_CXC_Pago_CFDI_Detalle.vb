Option Explicit On
Option Strict On

Imports System.Data.SqlClient

Public Class Class_CXC_Pago_CFDI_Detalle

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_CFDI_PAGOS_CXC_DETALLE As String
    Private _FOLIO_PAGO As String
    Private _FOLIO_CXC As String
    Private _CODIGO_MONEDA_SAT_DR As String
    Private _TIPO_CAMBIO_DR As Decimal
    Private _CODIGO_METODO_PAGO_EVENTO_DR As String
    Private _NUMERO_PARCIALIDAD As String
    Private _IMPORTE_SALDO_ANTERIOR As Decimal
    Private _IMPORTE_PAGADO As Decimal
    Private _IMPORTE_SALDO_INSOLUTO As Decimal
    Private _OBJETO_IMP_DR As String
#End Region

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
#End Region

#Region "Campos ligados a la tabla"
    Private _EXISTE As Boolean 'lectura

    Private _FACTURA_FOLIO_FISCAL_SAT As String
    Private _FACTURA_SERIE As String
    Private _FACTURA_FOLIO_NUMERICO As String
#End Region

#End Region

#Region "Propiedades"
#Region "Propiedades Campos de la tabla"
    Public ReadOnly Property ID_CFDI_PAGOS_CXC_DETALLE() As String
        Get
            Return Me._ID_CFDI_PAGOS_CXC_DETALLE
        End Get
    End Property

    Public ReadOnly Property FOLIO_PAGO() As String
        Get
            Return Me._FOLIO_PAGO
        End Get
    End Property

    Public ReadOnly Property FOLIO_CXC() As String
        Get
            Return Me._FOLIO_CXC
        End Get
    End Property

    Public ReadOnly Property CODIGO_MONEDA_SAT_DR() As String
        Get
            Return Me._CODIGO_MONEDA_SAT_DR
        End Get
    End Property

    Public ReadOnly Property TIPO_CAMBIO_DR() As Decimal
        Get
            Return Me._TIPO_CAMBIO_DR
        End Get
    End Property

    Public ReadOnly Property CODIGO_METODO_PAGO_EVENTO_DR() As String
        Get
            Return Me._CODIGO_METODO_PAGO_EVENTO_DR
        End Get
    End Property

    Public ReadOnly Property NUMERO_PARCIALIDAD() As String
        Get
            Return Me._NUMERO_PARCIALIDAD
        End Get
    End Property

    Public ReadOnly Property IMPORTE_SALDO_ANTERIOR() As Decimal
        Get
            Return Me._IMPORTE_SALDO_ANTERIOR
        End Get
    End Property

    Public ReadOnly Property IMPORTE_PAGADO() As Decimal
        Get
            Return Me._IMPORTE_PAGADO
        End Get
    End Property

    Public ReadOnly Property IMPORTE_SALDO_INSOLUTO() As Decimal
        Get
            Return Me._IMPORTE_SALDO_INSOLUTO
        End Get
    End Property

    Public ReadOnly Property OBJETO_IMP_DR() As String
        Get
            Return Me._OBJETO_IMP_DR
        End Get
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property EXISTE() As Boolean
        Get
            Return Me._EXISTE
        End Get
    End Property

    Public ReadOnly Property FACTURA_FOLIO_FISCAL_SAT() As String
        Get
            Return Me._FACTURA_FOLIO_FISCAL_SAT
        End Get
    End Property

    Public ReadOnly Property FACTURA_SERIE() As String
        Get
            Return Me._FACTURA_SERIE
        End Get
    End Property

    Public ReadOnly Property FACTURA_FOLIO_NUMERICO() As String
        Get
            Return Me._FACTURA_FOLIO_NUMERICO
        End Get
    End Property

#End Region

#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_Bancos_CXC_Detalle"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
    End Sub

    Public Sub New(ByVal folioCXC As String)
        Me.New()
        Me._FOLIO_CXC = folioCXC

        Try
            If Me.Consultar = True Then
                Me._EXISTE = True
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function Consultar() As Boolean
        Const sProcedure As String = "Consultar"
        Dim bResultado As Boolean = False

        Dim sSQL As String = ""

        sSQL = "SELECT D.*, " &
        "F.FOLIO_FISCAL_SAT FACTURA_FOLIO_FISCAL_SAT,F.SERIE FACTURA_SERIE,F.FOLIO_NUMERICO FACTURA_FOLIO_NUMERICO " &
        "FROM CFDI_PAGOS_CXC_DETALLE D " &
        "INNER JOIN CXC_GLOBAL C ON(D.FOLIO_CXC=C.FOLIO_CXC) " &
        "INNER JOIN VENTA_GLOBAL F ON(C.FOLIO_REFERENCIA=F.FOLIO_VENTA) " &
        "WHERE D.FOLIO_CXC='" & sReplace(Me._FOLIO_CXC) & "' "

        Dim cmd As New SqlCommand(sSQL, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._ID_CFDI_PAGOS_CXC_DETALLE = dReader("ID_CFDI_PAGOS_CXC_DETALLE").ToString
                    Me._FOLIO_PAGO = dReader("FOLIO_PAGO").ToString
                    Me._FOLIO_CXC = dReader("FOLIO_CXC").ToString
                    Me._CODIGO_MONEDA_SAT_DR = dReader("CODIGO_MONEDA_SAT_DR").ToString
                    Me._TIPO_CAMBIO_DR = CDec(dReader("TIPO_CAMBIO_DR").ToString)
                    Me._CODIGO_METODO_PAGO_EVENTO_DR = dReader("CODIGO_METODO_PAGO_EVENTO_DR").ToString
                    Me._NUMERO_PARCIALIDAD = dReader("NUMERO_PARCIALIDAD").ToString
                    Me._IMPORTE_SALDO_ANTERIOR = CDec(dReader("IMPORTE_SALDO_ANTERIOR").ToString)
                    Me._IMPORTE_PAGADO = CDec(dReader("IMPORTE_PAGADO").ToString)
                    Me._IMPORTE_SALDO_INSOLUTO = CDec(dReader("IMPORTE_SALDO_INSOLUTO").ToString)
                    Me._OBJETO_IMP_DR = dReader("OBJETO_IMP_DR").ToString

                    Me._FACTURA_FOLIO_FISCAL_SAT = dReader("FACTURA_FOLIO_FISCAL_SAT").ToString
                    Me._FACTURA_SERIE = dReader("FACTURA_SERIE").ToString
                    Me._FACTURA_FOLIO_NUMERICO = dReader("FACTURA_FOLIO_NUMERICO").ToString

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, sProcedure, ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With

        Return bResultado
    End Function

    Public Function ObtenerDetalleImpuestosDR() As DataTable
        Const sProcedure As String = "ObtenerDetalleImpuestosDR"
        Dim dTabla As New DataTable, da As New SqlDataAdapter
        Dim sSQL As String

        Try
            sSQL = "SELECT * " &
            "FROM CFDI_PAGOS_CXC_DETALLE_IMPUESTOS_DR " &
            "WHERE FOLIO_CXC='" & sReplace(Me._FOLIO_CXC) & "' " &
            "ORDER BY ID_CFDI_PAGOS_CXC_DETALLE_IMPUESTOS_DR"

            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, sProcedure, ex)
        Finally
            da.Dispose()
        End Try

        Return dTabla
    End Function
#End Region

End Class
