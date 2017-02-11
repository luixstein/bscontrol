Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatPercepcion
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_PERCEPCION As Integer
    Private _NOMBRE As String
    Private _REEMBOLSABLE As String
    Private _PROTEGIDO As String
    Private _OCULTO As String
    Private _ESTATUS_PERCEPCION As String
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
    Public Property CODIGO_PERCEPCION() As Integer
        Get
            Return Me._CODIGO_PERCEPCION
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_PERCEPCION = Value
        End Set
    End Property

    Public Property NOMBRE() As String
        Get
            Return Me._NOMBRE
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE = Value
        End Set
    End Property

    Public Property REEMBOLSABLE() As String
        Get
            Return Me._REEMBOLSABLE
        End Get
        Set(ByVal Value As String)
            Me._REEMBOLSABLE = Value
        End Set
    End Property

    Public Property PROTEGIDO() As String
        Get
            Return Me._PROTEGIDO
        End Get
        Set(ByVal Value As String)
            Me._PROTEGIDO = Value
        End Set
    End Property

    Public Property OCULTO() As String
        Get
            Return Me._OCULTO
        End Get
        Set(ByVal Value As String)
            Me._OCULTO = Value
        End Set
    End Property

    Public Property ESTATUS_PERCEPCION() As String
        Get
            Return Me._ESTATUS_PERCEPCION
        End Get
        Set(ByVal Value As String)
            Me._ESTATUS_PERCEPCION = Value
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
    'Public Property Estatus() As String
    '    Get
    '        Return Me._Estatus
    '    End Get
    '    Set(ByVal value As String)
    '        Me._Estatus = value
    '    End Set
    'End Property

#End Region

#End Region

#Region "Constructor y destructor"

    Public Sub New()
        Me._Nombre_Catalogo = "NOMINA_CAT_PERCEPCIONES"
        Me._Nombre_Reporte = "RPT_CATALOGO_NOMINA_PERCEPCIONES"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT CODIGO_PERCEPCION,NOMBRE,REEMBOLSABLE,PROTEGIDO,OCULTO,ESTATUS_PERCEPCION FROM NOMINA_CAT_PERCEPCIONES"
        Me._QueryOrder = " ORDER BY NOMBRE"
    End Sub                                                         'Inicializa al objeto.

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
            .CommandText = "MP_NOMINA_CAT_PERCEPCIONES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_PERCEPCION", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PERCEPCION
            sqlParametro = .Parameters.Add("@NOMBRE", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._NOMBRE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@REEMBOLSABLE", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._REEMBOLSABLE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS_PERCEPCION", SqlDbType.Char, 1) : sqlParametro.Value = "A"
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = "INSERTAR"
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

    Public Overrides Function Actualizar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_CAT_PERCEPCIONES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_PERCEPCION", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PERCEPCION
            sqlParametro = .Parameters.Add("@NOMBRE", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._NOMBRE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@REEMBOLSABLE", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._REEMBOLSABLE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS_PERCEPCION", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = "ACTUALIZAR"
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
        Dim cmd As New SqlCommand("Select * from NOMINA_CAT_PERCEPCIONES Where CODIGO_PERCEPCION='" & Replace(Me._CODIGO_PERCEPCION, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_PERCEPCION = "" & dReader("CODIGO_PERCEPCION").ToString
                    Me._NOMBRE = Trim("" & dReader("NOMBRE").ToString)
                    Me._REEMBOLSABLE = Trim("" & dReader("REEMBOLSABLE").ToString)
                    Me._PROTEGIDO = Trim("" & dReader("PROTEGIDO").ToString)
                    Me._OCULTO = Trim("" & dReader("OCULTO").ToString)
                    Me.Estatus = "" & dReader("ESTATUS_PERCEPCION").ToString
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
        Dim dsCat_CentroCosto As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            dsCat_CentroCosto.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCat_CentroCosto.Dispose()
        End Try
        Return dTable
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT CODIGO_PERCEPCION, NOMBRE FROM NOMINA_CAT_PERCEPCIONES WHERE NOMBRE LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE", Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
    End Function

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de puntos de pago por codigo."
        f.sCampo = "CODIGO_PERCEPCION"
        f.sOrder = "NOMBRE"
        f.sTable = "NOMINA_CAT_PERCEPCIONES"
        f.sQl = "Select CODIGO_PERCEPCION,NOMBRE From NOMINA_CAT_PERCEPCIONES Where 1=1 And"
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
        f.Text = "Búsqueda de puntos de pago por descripción."
        f.sCampo = "NOMBRE"
        f.sOrder = "NOMBRE"
        f.sTable = "NOMINA_CAT_PERCEPCIONES"
        f.sQl = "Select CODIGO_PERCEPCION,NOMBRE From NOMINA_CAT_PERCEPCIONES Where 1=1 And"
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

    Public Function CodigoSiguiente() As String
        Dim iPercepcion As Integer, sPercepcion As String
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("SELECT ISNULL(MAX(CODIGO_PERCEPCION),0)+1 FROM NOMINA_CAT_PERCEPCIONES ")
            iPercepcion = CInt(sql.Result1)
            sPercepcion = "0000" + iPercepcion.ToString
            Resultado = sPercepcion.Substring(Len(sPercepcion) - 4)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion", ex)
        End Try
        Return Resultado
    End Function
#End Region

#Region "Eventos de objetos"


#Region "Eventos de la lista de elementos"

#End Region

#Region " Eventos de TxtFiltro"

#End Region

#Region "Eventos Genericos"

#End Region


#Region "Keydown específicos"


#End Region

#Region "Validating específicos"

#End Region

#End Region

End Class
