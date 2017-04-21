Imports System.Data
Imports System.Data.SqlClient

Public Class Class_Cat_IVAS                                       'Clase Cultivos
    Inherits Class_Catalogos

#Region "Campos"


#Region "Campos de la tabla"
    Private _Id_Deporte As Integer
    Private _Nombre_Deporte As String
    Private _Estatus As String
#End Region

#Region "Campos ligados a la tabla"

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
    Public Property Id_Deporte() As Integer
        Get
            Return Me._Id_Deporte
        End Get
        Set(ByVal Value As Integer)
            Me._Id_Deporte = Value
        End Set
    End Property

    Public Property Nombre_Deporte() As String
        Get
            Return Me._Nombre_Deporte
        End Get
        Set(ByVal Value As String)
            Me._Nombre_Deporte = Value
        End Set
    End Property



#End Region

#Region "Propiedades de campos ligados a la tabla"

#End Region

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

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
    Public Property Status() As String
        Get
            Return Me._Estatus
        End Get
        Set(ByVal value As String)
            Me._Estatus = value
        End Set
    End Property
#End Region

#End Region

#Region "Constructor y destructor"

    Public Sub New()
        Me._Nombre_Catalogo = "SIS_DEPORTES"
        Me._Nombre_Reporte = "RPT_SIS_DEPORTES.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select Id_Deporte,Nombre_Deporte,ESTATUS From SIS_DEPORTES"
        Me._QueryOrder = " Order by Nombre_Deporte"
    End Sub                                                         'Inicializa al objeto.

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"

#End Region

#Region "Métodos y procedimientos"

    Public Overrides Function Actualizar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_ACTUALIZA_SIS_DEPORTES"

            sqlParametro = .Parameters.Add("@Id_Deporte", SqlDbType.SmallInt, 2) : sqlParametro.Value = Me._Id_Deporte
            sqlParametro = .Parameters.Add("@Nombre_Deporte", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._Nombre_Deporte.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me._Estatus.ToString.ToUpper

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
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
        Dim cmd As New SqlCommand(Me._QuerySelect & " Where Id_Deporte=" & Replace(Me._Id_Deporte, "'", "''") & "", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._Id_Deporte = "" & dReader("Id_Deporte")
                    Me._Nombre_Deporte = Trim("" & dReader("Nombre_Deporte").ToString)
                    Me._Estatus = "" & dReader("ESTATUS").ToString
                    Consultar = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With

    End Function        'Consulta un elemento del catálogo.

    Public Overrides Function Insertar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_INSERTA_SIS_DEPORTES"

            sqlParametro = .Parameters.Add("@Id_Deporte", SqlDbType.SmallInt, 2) : sqlParametro.Value = Me._Id_Deporte
            sqlParametro = .Parameters.Add("@Nombre_Deporte", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._Nombre_Deporte.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me._Estatus.ToString.ToUpper

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
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

    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsSIS_IVAS As New SqlDataAdapter("select ID_SIS_CAT_IMPUESTOS, NOMBRE_IMPUESTO from sis_cat_impuestos", Me._Conexion)
        Try
            dsSIS_IVAS.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsSIS_IVAS.Dispose()
        End Try
        Return dTable
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Metodos de Deportes por codigo."
        f.sCampo = "Id_Deporte"
        f.sOrder = "Nombre_Deporte"
        f.sTable = "SIS_DEPORTES"
        f.sQl = "Select Id_Deporte,Nombre_Deporte From SIS_DEPORTES Where 1=1 And"
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
        f.Text = "Búsqueda de Metodos de Deportes por Descripción."
        f.sCampo = "Nombre_Deporte"
        f.sOrder = "Nombre_Deporte"
        f.sTable = "SIS_DEPORTES"
        f.sQl = "Select Id_Deporte,Nombre_Deporte From SIS_DEPORTES Where 1=1 And"
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

