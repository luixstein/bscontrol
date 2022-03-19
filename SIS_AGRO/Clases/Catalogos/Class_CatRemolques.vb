
Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatRemolques

    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_REMOLQUE As String
    Private _NOMBRE_REMOLQUE As String
    Private _CODIGO_TIPO_REMOLQUE As String
    Private _ESTATUS As String
    Private _PLACA As String
    Private _CODIGO_USUARIO_CREO As String
    Private _FECHA_CREO As Date
    Private _CODIGO_USUARIO_MODIFICO As String
    Private _FECHA_MODIFICO As Date
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
    Public Property CODIGO_REMOLQUE() As String
        Get
            Return Me._CODIGO_REMOLQUE
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_REMOLQUE = VALUE
        End Set
    End Property

    Public Property NOMBRE_REMOLQUE() As String
        Get
            Return Me._NOMBRE_REMOLQUE
        End Get
        Set(ByVal VALUE As String)
            Me._NOMBRE_REMOLQUE = VALUE
        End Set
    End Property

    Public Property PLACA() As String
        Get
            Return Me._PLACA
        End Get
        Set(ByVal VALUE As String)
            Me._PLACA = VALUE
        End Set
    End Property

    Public Property CODIGO_USUARIO_CREO() As String
        Get
            Return Me._CODIGO_USUARIO_CREO
        End Get
        Set(value As String)
            Me._CODIGO_USUARIO_CREO = value
        End Set
    End Property

    Public Property FECHA_CREO() As Date
        Get
            Return Me._FECHA_CREO
        End Get
        Set(value As Date)
            Me._FECHA_CREO = value
        End Set
    End Property

    Public Property CODIGO_USUARIO_MODIFICO() As String
        Get
            Return Me._CODIGO_USUARIO_MODIFICO
        End Get
        Set(value As String)
            Me._CODIGO_USUARIO_MODIFICO = value
        End Set
    End Property

    Public Property FECHA_MODIFICO() As Date
        Get
            Return Me._FECHA_MODIFICO
        End Get
        Set(value As Date)
            Me._FECHA_MODIFICO = value
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
        Me._Nombre_Catalogo = "CAT_REMOLQUES"
        Me._Nombre_Reporte = "RPT_CATALOGO_REMOLQUES"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * From CAT_REMOLQUES"
        Me._QueryOrder = " Order by NOMBRE_REMOLQUE"
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal sCodigoRemolque As String)
        Me.New()
        Me._CODIGO_REMOLQUE = sCodigoRemolque
        Try
            If Me.Consultar = True Then
                Me._Existe = True
                'Else
                '    Throw New Exception("El transporte no existe.")
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
            .CommandText = "MP_CAT_REMOLQUE_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_REMOLQUE", SqlDbType.Int) : sqlParametro.Value = CInt(Me._CODIGO_REMOLQUE) : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@NOMBRE_REMOLQUE", SqlDbType.NVarChar, 100) : sqlParametro.Value = Me._NOMBRE_REMOLQUE.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_REMOLQUE", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_TIPO_REMOLQUE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@PLACA", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._PLACA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_CREO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(CODIGO_USUARIO_CREO)
            sqlParametro = .Parameters.Add("@FECHA_CREO", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_CREO
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_MODIFICO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_USUARIO_MODIFICO)
            sqlParametro = .Parameters.Add("@FECHA_MODIFICO", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_MODIFICO
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._CODIGO_REMOLQUE = .Parameters("@CODIGO_REMOLQUE").Value.ToString
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
            .CommandText = "MP_CAT_TRANSPORTES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_REMOLQUE", SqlDbType.Int) : sqlParametro.Value = CInt(Me._CODIGO_REMOLQUE)
            sqlParametro = .Parameters.Add("@NOMBRE_REMOLQUE", SqlDbType.NVarChar, 100) : sqlParametro.Value = Me._NOMBRE_REMOLQUE.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_REMOLQUE", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_TIPO_REMOLQUE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@PLACA", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._PLACA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_CREO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(CODIGO_USUARIO_CREO)
            sqlParametro = .Parameters.Add("@FECHA_CREO", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_CREO
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_MODIFICO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_USUARIO_MODIFICO)
            sqlParametro = .Parameters.Add("@FECHA_MODIFICO", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_MODIFICO
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "0"
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._CODIGO_REMOLQUE = .Parameters("@CODIGO_REMOLQUE").Value.ToString
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
        Dim cmd As New SqlCommand("Select * from CAT_REMOLQUES " & _
                                  " Where CODIGO_REMOLQUE='" & Replace(Me._CODIGO_REMOLQUE, "'", "''") & "' " & Usuario.Codigo_Plaza, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_REMOLQUE = "" & dReader("CODIGO_REMOLQUE").ToString
                    Me._NOMBRE_REMOLQUE = "" & dReader("NOMBRE_REMOLQUE").ToString
                    Me._CODIGO_TIPO_REMOLQUE = "" & dReader("CODIGO_TIPO_REMOLQUE").ToString
                    Me._PLACA = "" & dReader("PLACA").ToString
                    Me.Estatus = "" & dReader("ESTATUS").ToString
                    Me._CODIGO_USUARIO_CREO = "" & dReader("CODIGO_USUARIO_CREO").ToString
                    Me._FECHA_CREO = CDate(dReader("FECHA_CREO").ToString)
                    Me._CODIGO_USUARIO_MODIFICO = "" & dReader("CODIGO_USUARIO_MODIFICO").ToString
                    If Not (IsDBNull(dReader("FECHA_MODIFICO"))) Then Me._FECHA_MODIFICO = CDate(dReader("FECHA_MODIFICO"))
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
    Public Function ObtenerElementosN() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCAT_Lineas As New SqlDataAdapter("SELECT CODIGO_REMOLQUE,NOMBRE_REMOLQUE, PLACA FROM CAT_REMOLQUES ORDER BY PLACA", Me._Conexion)
        Try
            dsCAT_Lineas.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCAT_Lineas.Dispose()
        End Try
        Return dTable
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT CODIGO_REMOLQUE,NOMBRE_REMOLQUE, PLACA FROM CAT_REMOLQUES WHERE PLACA LIKE '" & Filtro.ToString & "%' ORDER BY PLACA", Me._Conexion)
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
        f.Text = "Búsqueda por codigo de remolques."
        f.sCampo = "CODIGO_REMOLQUE"
        f.sOrder = "NOMBRE_REMOLQUE"
        f.sTable = "PLACA"
        f.sQl = "Select CODIGO_REMOLQUE,NOMBRE_REMOLQUE,PLACA From CAT_REMOLQUES Where 1=1 AND "
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
        f.Text = "Búsqueda de placa del remolque."
        f.sCampo = "PLACA "
        f.sOrder = "PLACA"
        f.sTable = "CAT_REMOLQUES"
        f.sQl = "SELECT CODIGO_REMOLQUE,NOMBRE_REMOLQUE,PLACA From CAT_REMOLQUES Where 1=1 AND "
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
        Dim Resultado As Integer
        Try
            Dim sql As New Class_find("SELECT ISNULL(MAX(CODIGO_REMOLQUE),0) FROM CAT_REMOLQUES")
            Resultado = CType(sql.Result1, Integer) + 1
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
        End Try
        Return Resultado.ToString
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
