Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatNegociantesCxc
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_NEGOCIANTE As Integer
    Private _NOMBRE_NEGOCIANTE As String
    Private _CODIGO_CLIENTE As String
    Private _PUESTO As String
    Private _TELEFONO As String
    Private _CELULAR As String
    Private _EMAIL As String
    Private _CODIGO_USUARIO As Integer
    Private _FECHA_ACTUALIZACION As Date

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
    Public Property CODIGO_NEGOCIANTE() As Integer
        Get
            Return Me._CODIGO_NEGOCIANTE
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_NEGOCIANTE = Value
        End Set
    End Property

    Public Property NOMBRE_NEGOCIANTE() As String
        Get
            Return Me._NOMBRE_NEGOCIANTE
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_NEGOCIANTE = Value
        End Set
    End Property

    Public Property CODIGO_CLIENTE() As String
        Get
            Return Me._CODIGO_CLIENTE
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CLIENTE = Value
        End Set
    End Property

    Public Property PUESTO() As String
        Get
            Return Me._PUESTO
        End Get
        Set(ByVal Value As String)
            Me._PUESTO = Value
        End Set
    End Property

    Public Property TELEFONO() As String
        Get
            Return Me._TELEFONO
        End Get
        Set(ByVal Value As String)
            Me._TELEFONO = Value
        End Set
    End Property

    Public Property CELULAR() As String
        Get
            Return Me._CELULAR
        End Get
        Set(ByVal Value As String)
            Me._CELULAR = Value
        End Set
    End Property

    Public Property EMAIL() As String
        Get
            Return Me._EMAIL
        End Get
        Set(ByVal Value As String)
            Me._EMAIL = Value
        End Set
    End Property

    Public Property CODIGO_USUARIO() As Integer
        Get
            Return Me._CODIGO_USUARIO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_USUARIO = Value
        End Set
    End Property

    Public Property FECHA_ACTUALIZACION() As String
        Get
            Return Me._FECHA_ACTUALIZACION
        End Get
        Set(ByVal Value As String)
            Me._FECHA_ACTUALIZACION = Value
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
#End Region

#End Region

#Region "Constructor y destructor"

    Public Sub New()
        Me._Nombre_Catalogo = "CXC_SEGUIMIENTOS_NEGOCIANTES"
        Me._Nombre_Reporte = "RPT_CXC_SEGUIMIENTOS_NEGOCIANTES.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT * FROM CXC_SEGUIMIENTOS_NEGOCIANTES"
        Me._QueryOrder = " Order by NOMBRE_NEGOCIANTE"
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
            .CommandText = "MP_CXC_SEGUIMIENTO_NEGOCIANTES_GRABAR"

            sqlParametro = .Parameters.Add("@CODIGO_NEGOCIANTE", SqlDbType.SmallInt) : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@NOMBRE_NEGOCIANTE", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._NOMBRE_NEGOCIANTE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_CLIENTE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@PUESTO", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._PUESTO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@TELEFONO", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._TELEFONO
            sqlParametro = .Parameters.Add("@CELULAR", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._CELULAR
            sqlParametro = .Parameters.Add("@EMAIL", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._EMAIL.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._CODIGO_NEGOCIANTE = "" & .Parameters("@CODIGO_NEGOCIANTE").Value.ToString
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
            .CommandText = "MP_CXC_SEGUIMIENTO_NEGOCIANTES_GRABAR"

            sqlParametro = .Parameters.Add("@CODIGO_NEGOCIANTE", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_NEGOCIANTE
            sqlParametro = .Parameters.Add("@NOMBRE_NEGOCIANTE", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._NOMBRE_NEGOCIANTE.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_CLIENTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_CLIENTE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@PUESTO", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._PUESTO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@TELEFONO", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._TELEFONO
            sqlParametro = .Parameters.Add("@CELULAR", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._CELULAR
            sqlParametro = .Parameters.Add("@EMAIL", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._EMAIL.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "0"
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
        Dim cmd As New SqlCommand("Select * from CXC_SEGUIMIENTOS_NEGOCIANTES Where CODIGO_NEGOCIANTE=" & Me._CODIGO_NEGOCIANTE, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_NEGOCIANTE = "" & dReader("CODIGO_NEGOCIANTE").ToString
                    Me._NOMBRE_NEGOCIANTE = "" & dReader("NOMBRE_NEGOCIANTE").ToString
                    Me._CODIGO_CLIENTE = "" & dReader("CODIGO_CLIENTE").ToString
                    Me._PUESTO = "" & dReader("PUESTO").ToString
                    Me._TELEFONO = "" & dReader("TELEFONO").ToString
                    Me._CELULAR = "" & dReader("CELULAR").ToString
                    Me._EMAIL = "" & dReader("EMAIL").ToString
                    Me._CODIGO_USUARIO = "" & dReader("CODIGO_USUARIO").ToString
                    Me._FECHA_ACTUALIZACION = "" & dReader("FECHA_ACTUALIZACION").ToString
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
        Dim dsCAT_Lineas As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            dsCAT_Lineas.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCAT_Lineas.Dispose()
        End Try
        Return dTable
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de LOTES por codigo."
        f.sCampo = "Codigo_LOTE"
        f.sOrder = "Nombre_LOTE"
        f.sTable = "CAT_LOTES"
        f.sQl = "Select Codigo_LOTE,Nombre_LOTE From CAT_LOTES Where 1=1 And"
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
        f.Text = "Búsqueda de LOTES por Descripción."
        f.sCampo = "Nombre_LOTE"
        f.sOrder = "Nombre_LOTE"
        f.sTable = "CAT_LOTES"
        f.sQl = "Select Codigo_LOTE,Nombre_LOTE From CAT_LOTES Where 1=1 And"
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

    'Public Function CodigoSiguiente() As String
    '    Dim iLote As Integer, sLote As String
    '    Dim Resultado As String = ""
    '    Try
    '        Dim sql As New Class_find("SELECT MAX(CODIGO_LOTE) FROM CAT_LOTES")
    '        If sql.Result1 = "" Then
    '            iLote = 1
    '        Else
    '            iLote = CType(sql.Result1, Integer) + 1
    '        End If
    '        sLote = "00" + iLote.ToString
    '        Resultado = sLote.Substring(Len(sLote) - 2)
    '    Catch ex As Exception
    '        HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion", ex)
    '    End Try
    '    Return Resultado
    'End Function
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
