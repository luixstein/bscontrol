Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatAlmacenes
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _Codigo_Almacen As String
    Private _Nombre_Almacen As String
    Private _Cuenta_Contable As String
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
    Public Property Codigo_Almacen() As String
        Get
            Return Me._Codigo_Almacen
        End Get
        Set(ByVal Value As String)
            Me._Codigo_Almacen = Value
        End Set
    End Property

    Public Property Nombre_Almacen() As String
        Get
            Return Me._Nombre_Almacen
        End Get
        Set(ByVal Value As String)
            Me._Nombre_Almacen = Value
        End Set
    End Property

    Public ReadOnly Property Cuenta_Contable() As String
        Get
            Return Me._Cuenta_Contable
        End Get
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
        Me._Nombre_Catalogo = "Cat_Almacenes"
        Me._Nombre_Reporte = "RPT_CATALOGO_ALMACENES"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select Codigo_Almacen,Nombre_Almacen From Cat_Almacenes"
        Me._QueryOrder = " Order by Nombre_Almacen"
    End Sub

    Public Sub New(ByVal sAlmacen As String)
        Me.New()
        Try
            Me.Codigo_Almacen = sAlmacen
            If Me.Consultar = False Then
                Throw New Exception("El almacén no existe.")
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

#Region "Opciones"

#End Region

#Region "Métodos y procedimientos"

    Public Overrides Function Insertar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_ALMACENES_GRABA"

            sqlParametro = .Parameters.Add("@Codigo_Almacen", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._Codigo_Almacen.ToUpper
            sqlParametro = .Parameters.Add("@Nombre_Almacen", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._Nombre_Almacen.ToString.ToUpper
            'sqlParametro = .Parameters.Add("@CUENTA_CONTABLE", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._Cuenta_Contable
            sqlParametro = .Parameters.Add("@Estatus", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.Char, 1) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@Agregar", SqlDbType.Char, 1) : sqlParametro.Value = "1"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Insertar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Overrides Function Actualizar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_ALMACENES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._Codigo_Almacen.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_ALMACEN", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._Nombre_Almacen.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            'sqlParametro = .Parameters.Add("@CUENTA_CONTABLE", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._Cuenta_Contable
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.Char, 1) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "0"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Actualizar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Overrides Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand("Select * from Cat_Almacenes Where Codigo_Almacen='" & Replace(Me._Codigo_Almacen, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._Codigo_Almacen = "" & dReader("CODIGO_ALMACEN").ToString
                    Me._Nombre_Almacen = Trim("" & dReader("NOMBRE_ALMACEN").ToString)
                    Me._Cuenta_Contable = Trim("" & dReader("CUENTA_CONTABLE").ToString)
                    Me.Estatus = "" & dReader("ESTATUS").ToString
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

    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCat_Almacenes As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            dsCat_Almacenes.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCat_Almacenes.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerAlmacenes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_ALMACEN,NOMBRE_ALMACEN FROM CAT_ALMACENES Where ESTATUS='A'", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerAlmacenesParaReportes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_ALMACEN,NOMBRE_ALMACEN FROM CAT_ALMACENES Where ESTATUS='A'", Me._Conexion)
        Try
            da.Fill(dTable)
            dTable.Rows.Add("T", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Sub ObtenerAlmacenesUsuarios(ByRef LST As ListBox)
        Dim cmd As New SqlCommand("SELECT CODIGO_ALMACEN,NOMBRE_ALMACEN FROM VW_CAT_REL_ALMACENES_USUARIOS Where CODIGO_USUARIO='" & Replace(Usuario.Codigo_Usuario, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.HasRows Then
                    While dReader.Read()
                        LST.Items.Add(dReader("NOMBRE_ALMACEN").ToString)
                    End While
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "Obtener Almacenes", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
    End Sub

    Public Function ObtenerElementosFiltro(ByVal Filtro As String, ByVal Estatus As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_ALMACEN,NOMBRE_ALMACEN FROM CAT_ALMACENES WHERE NOMBRE_ALMACEN LIKE '" & Filtro.ToString & "%' AND ESTATUS='" & Estatus & "' ORDER BY NOMBRE_ALMACEN", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Metodos de Almacenes por codigo."
        f.sCampo = "Codigo_Almacen"
        f.sOrder = "Nombre_Almacen"
        f.sTable = "Cat_Almacenes"
        f.sQl = "Select Codigo_Almacen,Nombre_Almacen From Cat_Almacenes Where 1=1 And"
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
        f.Text = "Búsqueda de Almacenes por Descripción."
        f.sCampo = "Nombre_Almacen"
        f.sOrder = "Nombre_Almacen"
        f.sTable = "Cat_Almacenes"
        f.sQl = "Select Codigo_Almacen,Nombre_Almacen From Cat_Almacenes Where 1=1 And"
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
        Dim iAlmacen As Integer, sAlmacen As String
        Dim Resultado As String = ""
        Try
            iAlmacen = Empresa_Sistema.CODIGO_ALMACEN
            iAlmacen = iAlmacen + 1
            sAlmacen = "0000" + iAlmacen.ToString
            Resultado = sAlmacen.Substring(Len(sAlmacen) - 4)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion", ex)
        End Try
        Return Resultado
    End Function
#End Region

End Class



