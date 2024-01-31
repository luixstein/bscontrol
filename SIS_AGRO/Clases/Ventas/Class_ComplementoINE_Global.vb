Option Strict On

Imports System.Data.SqlClient

Public Class Class_ComplementoINE_Global
#Region "Campos"
#Region "Campos de la tabla"
    Private _ID_COMPLEMENTO_INE As Integer
    Private _FOLIO_VENTA As String
    Private _VERSION As String
    Private _CODIGO_PROCESO As Integer
    Private _CODIGO_COMITE As Integer
    Private _ID_CONTABILIDAD As String

#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean
    Private _Nombre_Formato As String
#End Region

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
#End Region
#End Region

#Region "Propiedades"

#Region "Propiedades campos de la tabla"
    Public ReadOnly Property ID_COMPLEMENTO_INE() As Integer
        Get
            Return Me._ID_COMPLEMENTO_INE
        End Get
    End Property

    Public Property FOLIO_VENTA() As String
        Get
            Return Me._FOLIO_VENTA
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_VENTA = Value
        End Set
    End Property

    Public ReadOnly Property VERSION() As String
        Get
            Return Me._VERSION
        End Get
    End Property

    Public Property CODIGO_PROCESO() As Integer
        Get
            Return Me._CODIGO_PROCESO
        End Get
        Set(value As Integer)
            Me._CODIGO_PROCESO = value
        End Set
    End Property

    Public Property CODIGO_COMITE() As Integer
        Get
            Return Me._CODIGO_COMITE
        End Get
        Set(value As Integer)
            Me._CODIGO_COMITE = value
        End Set
    End Property

    Public Property ID_CONTABILIDAD() As String
        Get
            Return Me._ID_CONTABILIDAD
        End Get
        Set(value As String)
            Me._ID_CONTABILIDAD = value
        End Set
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
#End Region

#Region "Propiedades de sistema"
    Private ReadOnly Property NombreClase() As String
        Get
            Return "Class_ComplementoINE_Global"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection(Empresa_Sistema.conexion)
    End Sub

    Public Sub New(ByVal sFOLIO_VENTA As String)
        Me.New()
        Try
            Me._FOLIO_VENTA = sFOLIO_VENTA
            If Me.Consultar() = True Then
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me.NombreClase, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function Grabar() As Boolean
        Const sProcedure As String = "Grabar"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter

        Try
            With cmd
                .Connection = Me._Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MP_VENTAS_COMPLEMENTO_INE_GLOBAL_GRABA"

                sqlParametro = .Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 14) : sqlParametro.Value = Me._FOLIO_VENTA
                sqlParametro = .Parameters.Add("@CODIGO_PROCESO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PROCESO
                sqlParametro = .Parameters.Add("@CODIGO_COMITE", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_COMITE
                sqlParametro = .Parameters.Add("@ID_CONTABILIDAD", SqlDbType.NVarChar, 6) : sqlParametro.Value = Me._ID_CONTABILIDAD

                Me._Conexion.Open()
                .ExecuteNonQuery()

                bResultado = True
            End With

        Catch ex As Exception
            HandleError(Me.NombreClase, sProcedure, ex)
        Finally
            Me._Conexion.Close()
            cmd.Dispose()
            sqlParametro = Nothing
        End Try

        Return bResultado
    End Function

    Private Function Consultar() As Boolean
        Const sProcedure As String = "Consultar"
        Dim bResultado As Boolean = False
        Dim dReader As SqlDataReader, sSQL As String = ""

        sSQL = "SELECT ID_COMPLEMENTO_INE,FOLIO_VENTA,VERSION,CODIGO_PROCESO,ISNULL(CODIGO_COMITE, 0) CODIGO_COMITE,ID_CONTABILIDAD FROM CFDI_COMPLEMENTO_INE_GLOBAL WHERE FOLIO_VENTA='" & Me._FOLIO_VENTA & "'"

        Dim cmd As New SqlCommand(sSQL, Me._Conexion)

        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._ID_COMPLEMENTO_INE = CInt("" & dReader("ID_COMPLEMENTO_INE").ToString())
                    Me._FOLIO_VENTA = "" & dReader("FOLIO_VENTA").ToString()
                    Me._VERSION = "" & dReader("VERSION").ToString()
                    Me._CODIGO_PROCESO = CInt("" & dReader("CODIGO_PROCESO").ToString())
                    Me._CODIGO_COMITE = CInt(dReader("CODIGO_COMITE").ToString())
                    Me._ID_CONTABILIDAD = "" & dReader("ID_CONTABILIDAD").ToString()
                    Me._Nombre_Formato = ""

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.NombreClase, sProcedure, ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With

        Return bResultado
    End Function

    Public Function ObtenerDetalleEntidades() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        Try
            sSQL = "SELECT E.CODIGO_ENTIDAD, T.NOMBRE_ENTIDAD, ISNULL(E.CODIGO_AMBITO, '') CODIGO_AMBITO, ISNULL(A.NOMBRE_AMBITO, '') NOMBRE_AMBITO, C.ID_CONTABILIDAD, 0 id_adicional " &
                "FROM CFDI_COMPLEMENTO_INE_DETALLE_ENTIDADES E INNER JOIN CFDI_COMPLEMENTO_INE_DETALLE_CONTABILIDADES C ON(E.ID_DETALLE_ENTIDADES=C.ID_DETALLE_ENTIDADES) " &
                "INNER JOIN CFDI_INE_CAT_ENTIDADES T ON(E.CODIGO_ENTIDAD=T.CODIGO_ENTIDAD) LEFT JOIN CFDI_INE_CAT_AMBITOS A ON(E.CODIGO_AMBITO=A.CODIGO_AMBITO) " &
                "WHERE E.FOLIO_VENTA='" & Me._FOLIO_VENTA & "' ORDER BY C.ID_DETALLE_CONTABILIDADES"

            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.NombreClase, "ObtenerDetalleEntidades", ex)
        End Try
        Return dTabla
    End Function


#End Region

End Class
