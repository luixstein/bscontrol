Imports System.Data
Imports System.Data.SqlClient

Public Class Class_Menu
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla Menu"
    Public _Codigo_Opcion_Menu As String
    Public _Nom_Opcion_Menu As String
    Public _Alias As String
    Public _Padre As Integer
    Public _ESTATUS_DOCUMENTOMenu As String
#End Region

#Region "Campos de la tabla Privilegios"
    Public _NombrePadren As String
    Public _CodigoPadre As String
    Public _Codigo_Usuario As String

#End Region

#Region "Campos ligados a la tabla"

#End Region

#Region "Campos públicos"
    Private _Opcion As Integer
    Public dReader As SqlDataReader
    Public Datos(500) As String
    Public i As Integer
    Public _Campo As String
#End Region

#Region "Campos privados"
    Private Enum enumEstados
        NUEVO
        EDICION
        CONSULTA
    End Enum

    Private Estado As enumEstados
    Private Run As Boolean
    Private msgElemento As String
    Private msgElementos As String
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


    Public Property Codigo_Opcion_Menu() As String
        Get
            Return Me._Codigo_Opcion_Menu
        End Get
        Set(ByVal Value As String)
            Me._Codigo_Opcion_Menu = Value
        End Set
    End Property

    Public Property Nom_Opcion_Menu() As String
        Get
            Return Me._Nom_Opcion_Menu
        End Get
        Set(ByVal Value As String)
            Me._Nom_Opcion_Menu = Value
        End Set
    End Property

    Public Property Alias2() As String
        Get
            Return Me._Alias
        End Get
        Set(ByVal Value As String)
            Me._Alias = Value
        End Set
    End Property

    Public Property Padre() As String
        Get
            Return Me._Padre
        End Get
        Set(ByVal Value As String)
            Me._Padre = Value
        End Set
    End Property


#End Region

#Region "Propiedades de campos ligados a la tabla"

#End Region

#Region "Propiedades públicos"

    Public Property Opcion() As String
        Get
            Return Me._Opcion
        End Get
        Set(ByVal value As String)
            Me._Opcion = value
        End Set
    End Property
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
        Me._Nombre_Catalogo = "sisUsuarios"
        Me._Nombre_Reporte = "RPT_SIS_USUARIOS.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select Codigo_Usuario,Nombre_Usuario,Clave From SIS_USUARIOS"
        Me._QueryOrder = " Order by Nombre_Usuario"

    End Sub                                                         'Inicializa al objeto.

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Public Function InsertarOpcionMenu() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_INSERTA_OPCION_MENU"
            sqlParametro = .Parameters.Add("@Codigo_Opcion_Menu", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._Codigo_Opcion_Menu
            sqlParametro = .Parameters.Add("@NOM_OPCION_MENU", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._Nom_Opcion_Menu
            sqlParametro = .Parameters.Add("@ALIAS", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._Alias
            sqlParametro = .Parameters.Add("@CODIGO_OPCION_MENU_PADRE", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._Padre
            sqlParametro = .Parameters.Add("@ESTATUS_DOCUMENTO", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._ESTATUS_DOCUMENTOMenu

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                InsertarOpcionMenu = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Insertar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function DarPrivilegios() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_INSERTA_OPCION_MENU"
            sqlParametro = .Parameters.Add("@Codigo_Opcion_Menu", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._Codigo_Opcion_Menu
            sqlParametro = .Parameters.Add("@NOM_OPCION_MENU", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._Nom_Opcion_Menu
            sqlParametro = .Parameters.Add("@ALIAS", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._Alias
            sqlParametro = .Parameters.Add("@CODIGO_OPCION_MENU_PADRE", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._Padre
            sqlParametro = .Parameters.Add("@ESTATUS_DOCUMENTO", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._ESTATUS_DOCUMENTOMenu

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                DarPrivilegios = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Insertar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function ObtenerElemento() As DataSet
        Dim dTable As New DataSet
        Dim dsSisEmpresa As New SqlDataAdapter(Me._QuerySelect, Me._Conexion)
        Try
            dsSisEmpresa.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsSisEmpresa.Dispose()
        End Try
        Return dTable
    End Function

    Public Function Cod_Opcion() As Integer
        Dim cmd As New SqlCommand("SELECT MAX(Codigo_Opcion_Menu) FROM SIS_OPCIONES_MENU", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()
                If dReader.Read Then

                    Me._Codigo_Opcion_Menu = "" & dReader.Item(0).ToString
                    If Me._Codigo_Opcion_Menu = "" Then
                        Return Me._Codigo_Opcion_Menu = "0"
                    Else
                        Return Me._Codigo_Opcion_Menu
                    End If
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
    End Function

    Public Function ObtenerMenu() As DataSet
        Dim dTable As New DataSet
        Dim dsSisEmpresa As New SqlDataAdapter("SELECT ALIAS,Codigo_Opcion_Menu,PADRE FROM SIS_OPCIONES_MENU ORDER BY PADRE,Codigo_Opcion_Menu", Me._Conexion)
        Try
            dsSisEmpresa.Fill(dTable, "SIS_OPCIONES_MENU")
        Catch ex As Exception
            HandleError("00002" + Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsSisEmpresa.Dispose()
        End Try
        Return dTable
    End Function

    Public Sub ActualizarCheck(ByVal node As TreeNode, ByVal check As Boolean)
        ' actualizo los check de los nodos hijos, del nodo que se envío como parametro y a con el valor de parametro
        Dim n As TreeNode
        For Each n In node.Nodes
            n.Checked = check
            If n.Nodes.Count <> 0 Then
                ActualizarCheck(n, check)
            End If
        Next n
    End Sub

    Public Function ConsultarCampo() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        Dim dReader As SqlDataReader
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_SELECT_MENU_CODIGO_OPCION_MENU_PADRE"
            sqlParametro = .Parameters.Add("@ALIAS", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._Alias
            sqlParametro = .Parameters.Add("@CODIGO_OPCION_MENU_PADRE", SqlDbType.NVarChar, 100) : sqlParametro.Value = Me._NombrePadren
            If _NombrePadren = "0" Then

                sqlParametro = .Parameters.Add("@OPCION", SqlDbType.NVarChar, 1) : sqlParametro.Value = 2
            Else

                sqlParametro = .Parameters.Add("@OPCION", SqlDbType.NVarChar, 1) : sqlParametro.Value = 1
            End If

            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._Codigo_Opcion_Menu = Strings.Right("0000" & dReader("Codigo_Opcion_Menu").ToString, 4)

                End If

                dReader.Close()
                ConsultarCampo = True
            Catch ex As Exception
                HandleError("00002" + Me.Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
            End Try

        End With


    End Function

    Public Overrides Function Consultar() As Boolean
        'COMENTADO Y ACTUALIZADO POR MISAEL MORENO. 02 DE NOVIEMBRE DE 2010.
        'ESTOS CAMPOS ESTAN CON OTROS NOMBRES EN LA BASE DE DATOS
        'Me._QuerySelect = "Select Nom_Opcion_Menu,Alias,Padre,ESTATUS_DOCUMENTO From SIS_OPCIONES_MENU"
        Me._QuerySelect = "Select NOMBRE_OPCION_MENU,ALIAS,CODIGO_OPCION_MENU_PADRE,ESTATUS_DOCUMENTO From SIS_OPCIONES_MENU"
        'FIN DE AGREGADO.
        Dim cmd As New SqlCommand(Me._QuerySelect & " Where Codigo_Opcion_Menu='" & Replace(Me._Codigo_Opcion_Menu, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()
                If dReader.Read Then
                    'COMENTADO Y ACTUALIZADO POR MISAEL MORENO. 02 DE NOVIEMBRE DE 2010.
                    'ESTOS CAMPOS ESTAN CON OTROS NOMBRES EN LA BASE DE DATOS
                    'Me._Nom_Opcion_Menu = "" & dReader("Nom_Opcion_Menu").ToString
                    Me._Nom_Opcion_Menu = "" & dReader("NOMBRE_OPCION_MENU").ToString
                    'FIN DE AGREGADO.
                    Me._Alias = "" & dReader("Alias").ToString
                    Me._Padre = Strings.Right("0000" & dReader("CODIGO_OPCION_MENU_PADRE").ToString, 4)
                    'COMENTADO Y ACTUALIZADO POR MISAEL MORENO. 02 DE NOVIEMBRE DE 2010.
                    'ESTOS CAMPOS ESTAN CON OTROS NOMBRES EN LA BASE DE DATOS
                    'Me._ESTATUS_DOCUMENTOMenu = "" & dReader("ESTATUS_DOCUMENTO").ToString
                    Me._ESTATUS_DOCUMENTOMenu = "" & dReader("ESTATUS_DOCUMENTO").ToString
                    'FIN DE AGREGADO
                    dReader.Close()
                    Consultar = True
                End If
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
    End Function


    Public Function ConsultarPrivilegios() As Boolean
        Me._QuerySelect = "Select Codigo_Opcion_Menu from SIS_USUARIOS_OPCIONES_MENU"
        i = 0
        Dim cmd As New SqlCommand(Me._QuerySelect & " Where Codigo_Usuario=" & Replace(Usuario.Codigo_Usuario, "'", "''") & "", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()
                Do While dReader.Read
                    Datos(i) = dReader(0)
                    i = i + 1
                Loop

                dReader.Close()
                ConsultarPrivilegios = True
            Catch ex As Exception
                HandleError("00005" + Me.Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
    End Function

    Public Overloads Function Consultar(ByVal sNombre As String) As Boolean

    End Function
    Public Overrides Function Insertar() As Boolean

    End Function
    Public Function InsertarPrivilegios() As Boolean

    End Function
    Public Function EliminarPrivilegios() As Boolean

    End Function
    Public Overrides Function Actualizar() As Boolean

    End Function

    Public Overrides Function ObtenerElementos() As DataTable
        Dim dTable As New DataTable
        Dim dsSisUsuario As New SqlDataAdapter(Me._QuerySelect, Me._Conexion)
        Try
            dsSisUsuario.Fill(dTable)

        Catch ex As Exception
            HandleError("000013" + Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsSisUsuario.Dispose()
        End Try

        Return dTable
    End Function

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim Resultado As String = ""
        Return Resultado
    End Function

    Public Overrides Function BusquedaVisual_PorDescripcion() As String
        Dim Resultado As String = ""
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
