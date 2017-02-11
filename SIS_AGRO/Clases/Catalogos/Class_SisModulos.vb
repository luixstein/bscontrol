
Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_SisModulos
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_MODULO As String
    Private _NOMBRE_MODULO As String
    Private _ESTATUS_MODULO As String
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
    Public Property CODIGO_MODULO() As String
        Get
            Return Me._CODIGO_MODULO
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_MODULO = VALUE
        End Set
    End Property

    Public Property NOMBRE_MODULO() As String
        Get
            Return Me._NOMBRE_MODULO
        End Get
        Set(ByVal VALUE As String)
            Me._NOMBRE_MODULO = VALUE
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

#Region "Propiedades de campos de sistema"

    Public Overrides ReadOnly Property Nombre_Catalogo() As String
        Get
            Return Me._Nombre_Catalogo
        End Get
    End Property

    Public Overrides Property Nombre_Reporte() As String
        Get
            Return Me._Nombre_Reporte
        End Get
        Set(ByVal value As String)
            Me._Nombre_Reporte = value
        End Set
    End Property
    'Public Property ESTATUS_MODULO() As String
    '    Get
    '        Return Me._ESTATUS_MODULO
    '    End Get
    '    Set(ByVal value As String)
    '        Me._ESTATUS_MODULO = value
    '    End Set
    'End Property

#End Region

#End Region

#Region "Constructor y destructor"

    Public Sub New()
        Me._Nombre_Catalogo = "SIS_MODULOS"
        'Me._Nombre_Reporte = "RPT_SIS_MODULOS.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * From SIS_MODULOS"
        Me._QueryOrder = " Order by NOMBRE_MODULO"
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal sCodigo As String)
        Me.New()
        Me._CODIGO_MODULO = sCodigo
        Try
            If Me.Consultar = True Then
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "New", ex)
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

    Public Overrides Function Insertar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_SIS_MODULOS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_MODULO", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_MODULO.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_MODULO", SqlDbType.NVarChar, 100) : sqlParametro.Value = Me._NOMBRE_MODULO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS_MODULO", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._CODIGO_MODULO = .Parameters("@CODIGO_MODULO").Value.ToString
                Insertar = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Insertar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try

        End With
    End Function                          'Inserta un elemento al catálogo.

    Public Overrides Function Actualizar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_SIS_MODULOS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_MODULO", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_MODULO.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_MODULO", SqlDbType.NVarChar, 100) : sqlParametro.Value = Me._NOMBRE_MODULO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS_MODULO", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "0"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._CODIGO_MODULO = .Parameters("@CODIGO_MODULO").Value.ToString
                Actualizar = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Actualizar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try

        End With
    End Function                        'Actualiza un elemento del catálogo.

    Public Overrides Function Consultar() As Boolean
        Dim cmd As New SqlCommand("Select * from SIS_MODULOS Where CODIGO_MODULO='" & Replace(Me._CODIGO_MODULO, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_MODULO = dReader("CODIGO_MODULO").ToString
                    Me._NOMBRE_MODULO = dReader("NOMBRE_MODULO").ToString
                    Me.Estatus = dReader("ESTATUS_MODULO").ToString
                    Consultar = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
    End Function        'Consulta un elemento del catálogo.

    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCat_Modulos As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            dsCat_Modulos.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCat_Modulos.Dispose()
        End Try
        Return dTable
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.

    Public Function ObtenerElementosParaReportes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCat_Modulos As New SqlDataAdapter
        Dim Sql As String
        Sql = "Select CODIGO_MODULO,NOMBRE_MODULO FROM SIS_MODULOS ORDER BY NOMBRE_MODULO "
        dsCat_Modulos = New SqlDataAdapter(Sql, Me._Conexion)

        Try
            dsCat_Modulos.Fill(dTable)
            dTable.Rows.Add("T", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosParaReportes", ex)
        Finally
            dsCat_Modulos.Dispose()
        End Try
        Return dTable
    End Function

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda por codigo."
        f.sCampo = "CODIGO_MODULO"
        f.sOrder = "NOMBRE_MODULO"
        f.sTable = "SIS_MODULOS"
        f.sQl = "Select CODIGO_MODULO,NOMBRE_MODULO From SIS_MODULOS Where 1=1 And"
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorCodigo", ex)
        End Try
        Return Resultado
    End Function

    Public Overrides Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Lineas por Descripción."
        f.sCampo = "NOMBRE_MODULO"
        f.sOrder = "NOMBRE_MODULO"
        f.sTable = "SIS_MODULOS"
        f.sQl = "Select CODIGO_MODULO,NOMBRE_MODULO From SIS_MODULOS Where 1=1 And"
        f.Inicia("")
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
