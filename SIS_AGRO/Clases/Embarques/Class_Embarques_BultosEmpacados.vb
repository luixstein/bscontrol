Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_Embarques_BultosEmpacados

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_EMB_BULTOS_EMPACADOS As Integer
    Private _FECHA As Date
    Private _CODIGO_EMPAQUE As String
    Private _CODIGO_ARTICULO As String
    Private _PESO As Double
    Private _CANTIDAD_ENTRADA As Double

    Private _CODIGO_USUARIO_GRABO As Integer
    Private _NOMBRE_USUARIO_GRABO As String

    Private _FOLIO_PALET_ORIGEN As String
    Private _FOLIO_ENTRADA_PRODUCCION As String
    'Private _FOLIO_PALET_ARMADO As String
    'Private _ES_POR_ENTRADA_SOBRANTE As String

#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property ID_EMB_BULTOS_EMPACADOS() As Integer
        Get
            Return Me._ID_EMB_BULTOS_EMPACADOS
        End Get
        Set(ByVal value As Integer)
            Me._ID_EMB_BULTOS_EMPACADOS = value
        End Set
    End Property

    Public Property FECHA() As Date
        Get
            Return Me._FECHA
        End Get
        Set(ByVal value As Date)
            Me._FECHA = value
        End Set
    End Property

    Public Property CODIGO_EMPAQUE() As String
        Get
            Return Me._CODIGO_EMPAQUE
        End Get
        Set(ByVal value As String)
            Me._CODIGO_EMPAQUE = value
        End Set
    End Property

    Public Property CODIGO_ARTICULO() As String
        Get
            Return Me._CODIGO_ARTICULO
        End Get
        Set(ByVal value As String)
            Me._CODIGO_ARTICULO = value
        End Set
    End Property

    Public Property CANTIDAD_ENTRADA() As Double
        Get
            Return Me._CANTIDAD_ENTRADA
        End Get
        Set(ByVal value As Double)
            Me._CANTIDAD_ENTRADA = value
        End Set
    End Property

    Public Property CODIGO_USUARIO_GRABO() As Integer
        Get
            Return Me._CODIGO_USUARIO_GRABO
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_USUARIO_GRABO = value
        End Set
    End Property

    Public ReadOnly Property NOMBRE_USUARIO_GRABO() As String
        Get
            Return Me._NOMBRE_USUARIO_GRABO
        End Get
    End Property
   
    Public Property FOLIO_PALET_ORIGEN() As String
        Get
            Return Me._FOLIO_PALET_ORIGEN
        End Get
        Set(ByVal value As String)
            Me._FOLIO_PALET_ORIGEN = value
        End Set
    End Property

    Public Property FOLIO_ENTRADA_PRODUCCION() As String
        Get
            Return Me._FOLIO_ENTRADA_PRODUCCION
        End Get
        Set(ByVal value As String)
            Me._FOLIO_ENTRADA_PRODUCCION = value
        End Set
    End Property

    'Public Property FOLIO_PALET_ARMADO() As String
    '    Get
    '        Return Me._FOLIO_PALET_ARMADO
    '    End Get
    '    Set(ByVal value As String)
    '        Me._FOLIO_PALET_ARMADO = value
    '    End Set
    'End Property

    'Public Property ES_POR_ENTRADA_SOBRANTE() As String
    '    Get
    '        Return Me._ES_POR_ENTRADA_SOBRANTE
    '    End Get
    '    Set(ByVal value As String)
    '        Me._ES_POR_ENTRADA_SOBRANTE = value
    '    End Set
    'End Property

#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property
#End Region

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_Embarques_BultosEmpacados"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "EMB_BULTOS_EMPACADOS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion

        Me._QuerySelect = "SELECT G.*,U1.NOMBRE_USUARIO AS NOMBRE_USUARIO_GRABO " & _
                          "FROM EMB_BULTOS_EMPACADOS G " & _
                          "INNER JOIN SIS_USUARIOS U1 ON(G.CODIGO_USUARIO_GRABO=U1.CODIGO_USUARIO)"
    End Sub

    Public Sub New(ByVal folio As Integer)
        Me.New()
        Me._ID_EMB_BULTOS_EMPACADOS = folio
        Try
            If Me.Consultar = True Then
                Me._Existe = True
                'Else
                '   Throw New Exception("La cuenta bancaria no existe.")
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function Consultar() As Boolean
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE ID_EMB_BULTOS_EMPACADOS='" & Me._ID_EMB_BULTOS_EMPACADOS & "' ", Me._Conexion)
        Dim dReader As SqlDataReader
        'Dim sqlParametro As SqlParameter
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()

                dReader = .ExecuteReader()
                If dReader.Read Then
                    Me._ID_EMB_BULTOS_EMPACADOS = CType(dReader("ID_EMB_BULTOS_EMPACADOS"), Integer)
                    Me._FECHA = CType(dReader("FECHA"), Date)
                    Me._CODIGO_EMPAQUE = CType(dReader("CODIGO_EMPAQUE"), String)
                    Me._CODIGO_ARTICULO = CType(dReader("CODIGO_ARTICULO"), String)
                    Me._CANTIDAD_ENTRADA = CType(dReader("CANTIDAD_ENTRADA"), Double)

                    Me._CODIGO_USUARIO_GRABO = CType(dReader("CODIGO_USUARIO_GRABO"), Integer)
                    Me._NOMBRE_USUARIO_GRABO = CType(dReader("NOMBRE_USUARIO_GRABO"), String)

                    Me._FOLIO_PALET_ORIGEN = "" & dReader("FOLIO_PALET_ORIGEN").ToString
                    Me._FOLIO_ENTRADA_PRODUCCION = "" & dReader("FOLIO_ENTRADA_PRODUCCION").ToString
                    'Me._FOLIO_PALET_ARMADO = "" & dReader("FOLIO_PALET_ARMADO").ToString
                    'Me._ES_POR_ENTRADA_SOBRANTE = dReader("ES_POR_ENTRADA_SOBRANTE_PRODUCCION").ToString

                    Consultar = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
    End Function    'Obtiene polizas globales

    Public Function Insertar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMB_BULTOS_EMPACADOS_GRABA_ENTRADA"

            sqlParametro = .Parameters.Add("@ID_EMB_BULTOS_EMPACADOS", SqlDbType.Int) : sqlParametro.Direction = ParameterDirection.Input : sqlParametro.Value = Me._ID_EMB_BULTOS_EMPACADOS
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA
            sqlParametro = .Parameters.Add("@CODIGO_EMPAQUE", SqlDbType.NVarChar, (8)) : sqlParametro.Value = Me._CODIGO_EMPAQUE
            sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, (16)) : sqlParametro.Value = Me._CODIGO_ARTICULO
            sqlParametro = .Parameters.Add("@CANTIDAD_ENTRADA", SqlDbType.Decimal) : sqlParametro.Value = Me._CANTIDAD_ENTRADA
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.Int) : sqlParametro.Value = Usuario.Codigo_Usuario
            'sqlParametro = .Parameters.Add("@FOLIO_PALET_ORIGEN", SqlDbType.NVarChar, (15)) : sqlParametro.Direction = ParameterDirection.Input : sqlParametro.Value = Me._FOLIO_PALET_ORIGEN
            'sqlParametro = .Parameters.Add("@FOLIO_PALET_ARMADO", SqlDbType.NVarChar, (15)) : sqlParametro.Direction = ParameterDirection.Input : sqlParametro.Value = Me._FOLIO_PALET_ARMADO
            'sqlParametro = .Parameters.Add("@ES_POR_ENTRADA_SOBRANTE_PRODUCCION", SqlDbType.Char, (1)) : sqlParametro.Value = Me._ES_POR_ENTRADA_SOBRANTE

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Insertar = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Insertar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function Eliminar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMB_BULTOS_EMPACADOS_ELIMINA_ENTRADA"

            sqlParametro = .Parameters.Add("@ID_EMB_BULTOS_EMPACADOS", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_EMB_BULTOS_EMPACADOS
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Eliminar = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Eliminar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function BusquedaVisual_Bultos() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de bultos sobrantes empacados."
        f.sCampo = "CODIGO_ARTICULO"
        f.sOrder = "FOLIO_PALET_ORIGEN"
        f.sTable = "EMB_BULTOS_EMPACADOS"
        f.sQl = "SELECT E.ID_EMB_BULTOS_EMPACADOS,E.FECHA,E.CODIGO_EMPAQUE,E.CODIGO_ARTICULO,A.DESCRIPCION,E.CANTIDAD_ENTRADA,E.PESO,E.FOLIO_PALET_ARMADO " & _
        "FROM EMB_BULTOS_EMPACADOS E INNER JOIN CAT_ARTICULOS A ON(E.CODIGO_ARTICULO=A.CODIGO_ARTICULO) WHERE ES_POR_ENTRADA_SOBRANTE='1' AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "BusquedaVisual_PorCodigo", ex)
        End Try
        Return Resultado
    End Function

#End Region

End Class

