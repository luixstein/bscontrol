Imports System.Data
Imports System.Data.SqlClient

Public Class Class_SisTiposDocumentos

#Region "Campos de la tabla"
    Private _CODIGO_DOCUMENTO As String
    Private _ESTATUS_DOCUMENTO As String
    Private _FOLIO As String
    Private _CODIGO_TIPO_DOCUMENTO As String
    Private _CODIGO_PLAZA As Integer
    Private _CONSECUTIVO As String
    Private _CODIGO_ASIENTO_REPETITIVO As Integer
    Private _NOMBRE_FORMATO As String

#End Region

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
#End Region

#Region "Propiedades Campos de la tabla"
    Public Property CODIGO_DOCUMENTO() As String
        Get
            Return Me._CODIGO_DOCUMENTO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_DOCUMENTO = Value
        End Set
    End Property

    Public ReadOnly Property ESTATUS_DOCUMENTO() As String
        Get
            Return Me._ESTATUS_DOCUMENTO
        End Get
    End Property

    Public Property FOLIO() As String
        Get
            Return Me._FOLIO
        End Get
        Set(ByVal Value As String)
            Me._FOLIO = Value
        End Set
    End Property

    Public ReadOnly Property CODIGO_TIPO_DOCUMENTO() As String
        Get
            Return Me._CODIGO_TIPO_DOCUMENTO
        End Get
    End Property

    Public ReadOnly Property CODIGO_PLAZA() As Integer
        Get
            Return Me._CODIGO_PLAZA
        End Get
    End Property

    Public ReadOnly Property CONSECUTIVO() As String
        Get
            Return Me._CONSECUTIVO
        End Get
    End Property

    Public ReadOnly Property CODIGO_ASIENTO_REPETITIVO() As Integer
        Get
            Return Me._CODIGO_ASIENTO_REPETITIVO
        End Get
    End Property

    Public Property NOMBRE_FORMATO() As String
        Get
            Return Me._NOMBRE_FORMATO
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_FORMATO = Value
        End Set
    End Property

#End Region

#Region "Propiedad Nombre de Clase"
    Private ReadOnly Property NombreClase()
        Get
            NombreClase = "Class_SisTiposDocumentos"
        End Get
    End Property
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
    End Sub                                                         'Inicializa al objeto.

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Public Function Actualizar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_SIS_CAT_DOCUMENTOS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_DOCUMENTO.ToString
            sqlParametro = .Parameters.Add("@FOLIO", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._FOLIO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_FORMATO", SqlDbType.NVarChar, 100) : sqlParametro.Value = Me._NOMBRE_FORMATO.ToString.ToUpper

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.NombreClase, "Actualizar", ex)
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
        Dim cmd As New SqlCommand("SELECT * FROM SIS_CAT_DOCUMENTOS WHERE CODIGO_DOCUMENTO='" & Replace(Me._CODIGO_DOCUMENTO, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_DOCUMENTO = "" & dReader("CODIGO_DOCUMENTO").ToString
                    Me._ESTATUS_DOCUMENTO = "" & dReader("ESTATUS_DOCUMENTO").ToString
                    Me._FOLIO = "" & dReader("FOLIO").ToString
                    Me._CODIGO_TIPO_DOCUMENTO = "" & dReader("CODIGO_TIPO_DOCUMENTO").ToString
                    Me._CODIGO_PLAZA = "" & dReader("CODIGO_PLAZA")
                    Me._CONSECUTIVO = "" & dReader("CONSECUTIVO").ToString
                    Me._CODIGO_ASIENTO_REPETITIVO = "" & dReader("CODIGO_ASIENTO_REPETITIVO")
                    Me._NOMBRE_FORMATO = Trim("" & dReader("NOMBRE_FORMATO").ToString)
                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.NombreClase, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
        Return bResultado
    End Function

    Public Function ObtenerTiposDocumentosContabilidaParaReporte() As System.Data.DataTable
        Dim dTable As New DataTable, dRow As DataRow
        Dim dsCaDocumentos As New SqlDataAdapter("SELECT CODIGO_TIPO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM SIS_TIPOS_DOCUMENTOS WHERE CODIGO_MODULO='CON' AND CODIGO_TIPO_DOCUMENTO<>'O' ORDER BY NOMBRE_TIPO_DOCUMENTO", Me._Conexion)
        Try
            dsCaDocumentos.Fill(dTable)
            dRow = dTable.NewRow
            dRow("CODIGO_TIPO_DOCUMENTO") = "T"
            dRow("NOMBRE_TIPO_DOCUMENTO") = "TODOS"
            dTable.Rows.Add(dRow)
        Catch ex As Exception
            HandleError(Me.NombreClase, "ObtenerTiposDocumentosContabilidaParaReporte", ex)
        Finally
            dsCaDocumentos.Dispose()
        End Try
        Return dTable
    End Function    'Obtiene una liSta completa de los elementos del catalogo en un datatable.

    Public Function ObtenerTiposDocumentosContabilida() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCaDocumentos As New SqlDataAdapter("SELECT CODIGO_TIPO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM SIS_TIPOS_DOCUMENTOS WHERE CODIGO_MODULO='CON' AND CODIGO_TIPO_DOCUMENTO<>'O' ORDER BY NOMBRE_TIPO_DOCUMENTO", Me._Conexion)
        Try
            dsCaDocumentos.Fill(dTable)
        Catch ex As Exception
            HandleError(Me.NombreClase, "ObtenerTiposDocumentosContabilida", ex)
        Finally
            dsCaDocumentos.Dispose()
        End Try
        Return dTable
    End Function    'Obtiene una liSta completa de los elementos del catalogo en un datatable.

    Public Function ObtenerTiposDocumentosCxpParaReporte() As System.Data.DataTable
        Dim dTable As New DataTable, dRow As DataRow
        Dim dsCaDocumentos As New SqlDataAdapter("SELECT CODIGO_TIPO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM SIS_TIPOS_DOCUMENTOS WHERE CODIGO_MODULO='BAN' AND CODIGO_TIPO_DOCUMENTO<>'O' ORDER BY NOMBRE_TIPO_DOCUMENTO", Me._Conexion)
        Try
            dsCaDocumentos.Fill(dTable)
            dRow = dTable.NewRow
            dRow("CODIGO_TIPO_DOCUMENTO") = "T"
            dRow("NOMBRE_TIPO_DOCUMENTO") = "TODOS"
            dTable.Rows.Add(dRow)
        Catch ex As Exception
            HandleError(Me.NombreClase, "ObtenerTiposDocumentosCxpParaReporte", ex)
        Finally
            dsCaDocumentos.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String, ByVal Estatus As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_DOCUMENTO FROM SIS_CAT_DOCUMENTOS WHERE CODIGO_DOCUMENTO LIKE '" & Filtro.ToString & "%' AND ESTATUS_DOCUMENTO='" & Estatus & "' ORDER BY CODIGO_DOCUMENTO", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me.NombreClase, "ObtenerElementosFiltro", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function
#End Region

End Class


