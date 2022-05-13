Option Strict On

Imports System.Data.SqlClient

Public Class Class_CFD_CatUsosCFDI

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_USO_CFDI As String
    Private _NOMBRE_USO_CFDI As String
    Private _ESTATUS As String
    Private _ES_DEFAULT As Boolean
    Private _APLICA_TIPO_FISICA As Boolean
    Private _APLICA_TIPO_MORAL As Boolean
    Private _REGIMEN_FISCAL_RECEPTOR As String
#End Region

#Region "Campos ligados a la tabla"
    Private _EXISTE As Boolean
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
    Public Property CODIGO_USO_CFDI() As String
        Get
            Return Me._CODIGO_USO_CFDI
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_USO_CFDI = VALUE
        End Set
    End Property

    Public Property NOMBRE_USO_CFDI() As String
        Get
            Return Me._NOMBRE_USO_CFDI
        End Get
        Set(ByVal VALUE As String)
            Me._NOMBRE_USO_CFDI = VALUE
        End Set
    End Property

    Public Property ESTATUS() As String
        Get
            Return Me._ESTATUS
        End Get
        Set(ByVal VALUE As String)
            Me._ESTATUS = VALUE
        End Set
    End Property

    Public ReadOnly Property ES_DEFAULT() As Boolean
        Get
            Return Me._ES_DEFAULT
        End Get
    End Property

    Public ReadOnly Property APLICA_TIPO_FISICA() As Boolean
        Get
            Return Me._APLICA_TIPO_FISICA
        End Get
    End Property

    Public ReadOnly Property APLICA_TIPO_MORAL() As Boolean
        Get
            Return Me._APLICA_TIPO_MORAL
        End Get
    End Property

    Public ReadOnly Property REGIMEN_FISCAL_RECEPTOR As String
        Get
            Return Me._REGIMEN_FISCAL_RECEPTOR
        End Get
    End Property

#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property EXISTE() As Boolean
        Get
            Return Me._EXISTE
        End Get
    End Property
#End Region

#Region "Propiedades de campos de sistema"

    Public ReadOnly Property Nombre_Catalogo() As String
        Get
            Return Me._Nombre_Catalogo
        End Get
    End Property

    Public Property Nombre_Reporte() As String
        Get
            Return Me._Nombre_Reporte
        End Get
        Set(ByVal value As String)
            Me._Nombre_Reporte = value
        End Set
    End Property
#End Region
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "CFDI_CAT_USOS_CFDI"
        Me._Nombre_Reporte = "RPT_CFDI_CAT_USOS_CFDI"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT * FROM CFDI_CAT_USOS_CFDI"
        Me._QueryOrder = " ORDER BY NOMBRE_USO_CFDI"
    End Sub

    Public Sub New(ByVal sCodigo As String)
        Me.New()
        Me._CODIGO_USO_CFDI = sCodigo
        Try
            If Me.Consultar = True Then
                Me._EXISTE = True
            Else
                Throw New Exception("El uso del CFDI no existe.")
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_USO_CFDI,CAST(CODIGO_USO_CFDI AS NVARCHAR)+ ' - ' + NOMBRE_USO_CFDI NOMBRE_USO_CFDI,ES_DEFAULT FROM CFDI_CAT_USOS_CFDI WHERE ESTATUS='A' ORDER BY CODIGO_USO_CFDI", Empresa_Sistema.conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosPersonasFisicas() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_USO_CFDI,CAST(CODIGO_USO_CFDI AS NVARCHAR)+ ' - ' + NOMBRE_USO_CFDI NOMBRE_USO_CFDI,ES_DEFAULT,APLICA_TIPO_FISICA,APLICA_TIPO_MORAL FROM CFDI_CAT_USOS_CFDI WHERE APLICA_TIPO_FISICA='1' AND ESTATUS='A' ORDER BY CODIGO_USO_CFDI", Empresa_Sistema.conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosPersonasFisicas", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosPersonasMorales() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_USO_CFDI,CAST(CODIGO_USO_CFDI AS NVARCHAR)+ ' - ' + NOMBRE_USO_CFDI NOMBRE_USO_CFDI,ES_DEFAULT FROM CFDI_CAT_USOS_CFDI WHERE APLICA_TIPO_MORAL='1' AND ESTATUS='A' ORDER BY CODIGO_USO_CFDI", Empresa_Sistema.conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosPersonasMorales", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE CODIGO_USO_CFDI='" & Me._CODIGO_USO_CFDI & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_USO_CFDI = dReader("CODIGO_USO_CFDI").ToString
                    Me._NOMBRE_USO_CFDI = Trim("" & dReader("NOMBRE_USO_CFDI").ToString)
                    Me._ESTATUS = dReader("ESTATUS").ToString
                    Me._ES_DEFAULT = CBool(dReader("ES_DEFAULT").ToString)
                    Me._APLICA_TIPO_FISICA = CBool(dReader("APLICA_TIPO_FISICA").ToString)
                    Me._APLICA_TIPO_MORAL = CBool(dReader("APLICA_TIPO_MORAL").ToString)
                    Me._REGIMEN_FISCAL_RECEPTOR = dReader("REGIMEN_FISCAL_RECEPTOR").ToString

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
        Return bResultado
    End Function

    Public Function BusquedaVisual_PorDescripcion(ByVal sTipoPersona As String) As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""

        f.Text = "Búsqueda de usos de CFDI por nombre."
        f.sCampo = "NOMBRE_USO_CFDI"
        f.sOrder = "CODIGO_USO_CFDI"
        f.sTable = "CFDI_CAT_USOS_CFDI"
        f.sQl = "SELECT CODIGO_USO_CFDI,NOMBRE_USO_CFDI,APLICA_TIPO_FISICA,APLICA_TIPO_MORAL,REGIMEN_FISCAL_RECEPTOR " &
            "FROM CFDI_CAT_USOS_CFDI " &
            "WHERE ESTATUS='A' AND " & IIf(sTipoPersona = "F", "APLICA_TIPO_FISICA='1'", "APLICA_TIPO_MORAL='1'").ToString & " AND "
        f.arrayWidthColumns = New Integer() {100, 350, 130, 130, 450}
        f.Inicia("%")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion", ex)
        End Try
        Return Resultado
    End Function

#End Region

End Class
