Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatPaises

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_PAIS_SAT As String
    Private _NOMBRE_PAIS As String
    Private _ESTATUS As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
#End Region

#Region "Campos públicos"

#End Region

#Region "Campos privados"

#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Nombre_Reporte As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property CODIGO_PAIS_SAT() As String
        Get
            Return Me._CODIGO_PAIS_SAT
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_PAIS_SAT = Value
        End Set
    End Property

    Public Property NOMBRE_PAIS() As String
        Get
            Return Me._NOMBRE_PAIS
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_PAIS = Value
        End Set
    End Property

    Public Property ESTATUS() As String
        Get
            Return Me._ESTATUS
        End Get
        Set(ByVal Value As String)
            Me._ESTATUS = Value
        End Set
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property
#End Region

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

#End Region
#Region "Propiedades de campos de sistema"

    Public ReadOnly Property Nombre_Catalogo() As String
        Get
            Return Me._NOMBRE_Catalogo
        End Get
    End Property

    Public Property Nombre_Reporte() As String
        Get
            Return Me._NOMBRE_Reporte
        End Get
        Set(ByVal value As String)
            Me._NOMBRE_Reporte = value
        End Set
    End Property
#End Region

#End Region

#Region "Constructor y destructor"

    Public Sub New()
        Me._NOMBRE_Catalogo = "CAT_PAISES"
        Me._NOMBRE_Reporte = "RPT_CATALOGO_PAISES"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = ""
        Me._QueryOrder = ""
    End Sub

    Public Sub New(ByVal sCodigo As String)
        Me.New()
        Try
            Me._CODIGO_PAIS_SAT = sCodigo
            If Me.Consultar = True Then
                Me._Existe = True
                'Throw New Exception("El artículo no existe.")
            End If
        Catch ex As Exception
            HandleError(Me._NOMBRE_Catalogo, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"

#End Region

#Region "Métodos y procedimientos"
    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand("SELECT CODIGO_PAIS_SAT,NOMBRE_PAIS,ESTATUS FROM CAT_PAISES WHERE CODIGO_PAIS_SAT='" & sReplace(Me._CODIGO_PAIS_SAT) & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_PAIS_SAT = "" & dReader("CODIGO_PAIS_SAT")
                    Me._NOMBRE_PAIS = Trim("" & dReader("NOMBRE_PAIS").ToString)
                    Me.ESTATUS = "" & dReader("ESTATUS").ToString
                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
        Return bResultado
    End Function

    Public Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_PAIS_SAT,NOMBRE_PAIS FROM CAT_PAISES WHERE ESTATUS='A' ORDER BY NOMBRE_PAIS", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._NOMBRE_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function BusquedaVisual_PorCodigo() As String
        Const sProcedure As String = "BusquedaVisual_PorCodigo"
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de países por código."
        f.sCampo = "CODIGO_PAIS_SAT"
        f.sOrder = "NOMBRE_PAIS"
        f.sTable = "CAT_PAISES"
        f.sQl = "SELECT CODIGO_PAIS_SAT,NOMBRE_PAIS FROM CAT_PAISES WHERE ESTATUS='A' AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, sProcedure, ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_PorDescripcion() As String
        Const sProcedure As String = "BusquedaVisual_PorDescripcion"
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de países por nombre."
        f.sCampo = "NOMBRE_PAIS"
        f.sOrder = "NOMBRE_PAIS"
        f.sTable = "CAT_PAISES"
        f.sQl = "SELECT CODIGO_PAIS_SAT,NOMBRE_PAIS FROM CAT_PAISES WHERE ESTATUS='A' AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, sProcedure, ex)
        End Try
        Return Resultado
    End Function
#End Region

End Class