Option Strict On

Imports System.Data.SqlClient

Public Class Class_CfdiCatPartesTransporte

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_PARTE_TRANSPORTE As String
    Private _NOMBRE_PARTE_TRANSPORTE As String

#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean
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
    Public ReadOnly Property CODIGO_PARTE_TRANSPORTE() As String
        Get
            Return Me._CODIGO_PARTE_TRANSPORTE
        End Get
    End Property

    Public ReadOnly Property NOMBRE_PARTE_TRANSPORTE() As String
        Get
            Return Me._NOMBRE_PARTE_TRANSPORTE
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

    Public ReadOnly Property Nombre_Reporte() As String
        Get
            Return Me._Nombre_Reporte
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"

    Public Sub New()
        Me._Nombre_Catalogo = "CFDI_CAT_PARTES_TRANSPORTE"
        Me._Nombre_Reporte = "RPT_CATALOGO_CFDI_PARTES_TRANSPORTE"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * From CFDI_CAT_PARTES_TRANSPORTE"
        Me._QueryOrder = " Order by NOMBRE_PARTE_TRANSPORTE"
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal sCodigoParteTransporte As String)
        Me.New()
        Try
            Me._CODIGO_PARTE_TRANSPORTE = sCodigoParteTransporte
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
        Dim cmd As New SqlCommand("SELECT * FROM CFDI_CAT_PARTES_TRANSPORTE WHERE CODIGO_PARTE_TRANSPORTE='" & sReplace(Me._CODIGO_PARTE_TRANSPORTE) & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._CODIGO_PARTE_TRANSPORTE = "" & dReader("CODIGO_PARTE_TRANSPORTE").ToString
                    Me._NOMBRE_PARTE_TRANSPORTE = "" & dReader("NOMBRE_PARTE_TRANSPORTE").ToString

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
        Dim da As New SqlDataAdapter("SELECT CODIGO_PARTE_TRANSPORTE,NOMBRE_PARTE_TRANSPORTE FROM CFDI_CAT_PARTES_TRANSPORTE WHERE NOMBRE_PARTE_TRANSPORTE LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_PARTE_TRANSPORTe", Me._Conexion)
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
        f.Text = "Búsqueda de partes de transporte por codigo."
        f.sCampo = "CODIGO_PARTE_TRANSPORTE"
        f.sOrder = "NOMBRE_PARTE_TRANSPORTE"
        f.sTable = "CFDI_CAT_PARTES_TRANSPORTE"
        f.sQl = "SELECT CODIGO_PARTE_TRANSPORTE,NOMBRE_PARTE_TRANSPORTE FROM CFDI_CAT_PARTES_TRANSPORTE WHERE 1=1 AND "
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
        f.Text = "Búsqueda de partes de transporte por nombre."
        f.sCampo = "NOMBRE_PARTE_TRANSPORTE"
        f.sOrder = "NOMBRE_PARTE_TRANSPORTE"
        f.sTable = "CFDI_CAT_PARTES_TRANSPORTE"
        f.sQl = "SELECT CODIGO_PARTE_TRANSPORTE,NOMBRE_PARTE_TRANSPORTE FROM CFDI_CAT_PARTES_TRANSPORTE WHERE 1=1 AND "
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