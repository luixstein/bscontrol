Option Strict On

Imports System.Data.SqlClient

Public Class Class_CfdiCatTiposFiguraTransporte

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_TIPO_FIGURA_TRANSPORTE As String
    Private _NOMBRE_TIPO_FIGURA_TRANSPORTE As String
    Private _VALIDA_LICENCIA As Boolean
    Private _VALIDA_PARTE_TRANSPORTE As Boolean

#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean
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
    Public ReadOnly Property CODIGO_TIPO_FIGURA_TRANSPORTE() As String
        Get
            Return Me._CODIGO_TIPO_FIGURA_TRANSPORTE
        End Get
    End Property

    Public ReadOnly Property NOMBRE_TIPO_FIGURA_TRANSPORTE() As String
        Get
            Return Me._NOMBRE_TIPO_FIGURA_TRANSPORTE
        End Get
    End Property

    Public ReadOnly Property VALIDA_LICENCIA() As Boolean
        Get
            Return Me._VALIDA_LICENCIA
        End Get
    End Property

    Public ReadOnly Property VALIDA_PARTE_TRANSPORTE() As Boolean
        Get
            Return Me._VALIDA_PARTE_TRANSPORTE
        End Get
    End Property

#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
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
        Me._Nombre_Catalogo = "CFDI_CAT_TIPOS_FIGURAS_TRANSPORTE"
        Me._Nombre_Reporte = "RPT_CATALOGO_CFDI_TIPOS_FIGURAS_TRANSPORTE"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * From CFDI_CAT_TIPOS_FIGURAS_TRANSPORTE"
        Me._QueryOrder = " Order by NOMBRE_TIPO_FIGURA_TRANSPORTE"
    End Sub

    Public Sub New(ByVal sCodigoTipoFiguraTransporte As String)
        Me.New()
        Try
            Me._CODIGO_TIPO_FIGURA_TRANSPORTE = sCodigoTipoFiguraTransporte
            If Me.Consultar = True Then
                Me._Existe = True
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
    Public Function Consultar() As Boolean
        Const sProcedure As String = "Consultar"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand("SELECT * FROM CFDI_CAT_TIPOS_FIGURAS_TRANSPORTE WHERE CODIGO_TIPO_FIGURA_TRANSPORTE='" & sReplace(Me._CODIGO_TIPO_FIGURA_TRANSPORTE) & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._CODIGO_TIPO_FIGURA_TRANSPORTE = "" & dReader("CODIGO_TIPO_FIGURA_TRANSPORTE").ToString
                    Me._NOMBRE_TIPO_FIGURA_TRANSPORTE = "" & dReader("NOMBRE_TIPO_FIGURA_TRANSPORTE").ToString
                    Me._VALIDA_LICENCIA = CBool(dReader("VALIDA_LICENCIA").ToString)
                    Me._VALIDA_PARTE_TRANSPORTE = CBool(dReader("VALIDA_PARTE_TRANSPORTE").ToString)

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, sProcedure, ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
        Return bResultado
    End Function

    Public Function ObtenerElementos() As System.Data.DataTable
        Const sProcedure As String = "ObtenerElementos"
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosParaReportes() As System.Data.DataTable
        Const sProcedure As String = "ObtenerElementosParaReportes"
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
            dTable.Rows.Add("-1", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Const sProcedure As String = "ObtenerElementosFiltro"
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_TIPO_FIGURA_TRANSPORTE,NOMBRE_TIPO_FIGURA_TRANSPORTE " &
                                     "FROM CFDI_CAT_TIPOS_FIGURAS_TRANSPORTE WHERE NOMBRE_TIPO_FIGURA_TRANSPORTE LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_TIPO_FIGURA_TRANSPORTE", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function BusquedaVisual_PorCodigo() As String
        Const sProcedure As String = "BusquedaVisual_PorCodigo"
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de tipos de figuras de transporte por código."
        f.sCampo = "CODIGO_TIPO_FIGURA_TRANSPORTE"
        f.sOrder = "NOMBRE_TIPO_FIGURA_TRANSPORTE"
        f.sTable = "CFDI_CAT_TIPOS_FIGURAS_TRANSPORTE"
        f.sQl = "SELECT CODIGO_TIPO_FIGURA_TRANSPORTE,NOMBRE_TIPO_FIGURA_TRANSPORTE FROM CFDI_CAT_TIPOS_FIGURAS_TRANSPORTE WHERE 1=1 AND "
        f.Inicia("%")
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
        f.Text = "Búsqueda de tipos de figuras de transporte por nombre."
        f.sCampo = "NOMBRE_TIPO_FIGURA_TRANSPORTE"
        f.sOrder = "NOMBRE_TIPO_FIGURA_TRANSPORTE"
        f.sTable = "CFDI_CAT_TIPOS_FIGURAS_TRANSPORTE"
        f.sQl = "SELECT CODIGO_TIPO_FIGURA_TRANSPORTE,NOMBRE_TIPO_FIGURA_TRANSPORTE FROM CFDI_CAT_TIPOS_FIGURAS_TRANSPORTE WHERE 1=1 AND "
        f.Inicia("%")
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