Imports System.Data.SqlClient

Public Class Class_sisUsuarios

#Region "Campos"

#Region "Campos de la tabla"
    Private _Codigo_Usuario As Integer
    Private _Nombre_Usuario As String
    Private _Clave As String
    Private _Codigo_Plaza As Integer
    Private _Codigo_Almacen As String
    Private _PERMISO_CON_CAT_CUENTAS As String
    Private _PERMISO_CAT_ARTICULOS As String
    Private _PERMISO_CAT_CLIENTES As String
    Private _PERMISO_ADMINISTRADOR As String
    Private _PERMISO_ARMADO_PALET As String
    Private _ESTATUS As String
    Private _CORREO_USUARIO As String
    Private _CLAVE_CORREO As String
    Private _SERVIDOR_CORREO_REMITENTE As String
    Private _PUERTO_REMITENTE As String
    Private _USAR_SSL_REMITENTE As Boolean
    Private _PERMISO_CAMBIAR_PRECIO_VENTA As Boolean
    Private _ADMON_CREDITOS As Integer
    Private _VER_COSTOS As Boolean
    Private _CODIGO_VENDEDOR As String
    Private _PERMISO_FORMULAS_CONFIDENCIALES As Boolean
    Private _CODIGO_DEPARTAMENTO As String
    Private _PERMISO_GRABAR_OC_SIN_REQUISICION As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
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
    Public Property Codigo_Usuario() As Integer
        Get
            Return Me._Codigo_Usuario
        End Get
        Set(ByVal Value As Integer)
            Me._Codigo_Usuario = Value
        End Set
    End Property

    Public Property Nombre_Usuario() As String
        Get
            Return Me._Nombre_Usuario
        End Get
        Set(ByVal Value As String)
            Me._Nombre_Usuario = Value
        End Set
    End Property

    Public Property Codigo_Plaza() As Integer
        Get
            Return Me._Codigo_Plaza
        End Get
        Set(ByVal value As Integer)
            Me._Codigo_Plaza = value
        End Set
    End Property

    Public Property Clave() As String
        Get
            Return Me._Clave
        End Get
        Set(ByVal Value As String)
            Me._Clave = Value
        End Set
    End Property

    Public Property Codigo_Almacen() As String
        Get
            Return Me._Codigo_Almacen
        End Get
        Set(ByVal Value As String)
            Me._Codigo_Almacen = Value
        End Set
    End Property

    Public Property PERMISO_CON_CAT_CUENTAS() As String
        Get
            Return Me._PERMISO_CON_CAT_CUENTAS
        End Get
        Set(ByVal Value As String)
            Me._PERMISO_CON_CAT_CUENTAS = Value
        End Set
    End Property

    Public Property PERMISO_CAT_ARTICULOS() As String
        Get
            Return Me._PERMISO_CAT_ARTICULOS
        End Get
        Set(ByVal Value As String)
            Me._PERMISO_CAT_ARTICULOS = Value
        End Set
    End Property

    Public Property PERMISO_CAT_CLIENTES() As String
        Get
            Return Me._PERMISO_CAT_CLIENTES
        End Get
        Set(ByVal Value As String)
            Me._PERMISO_CAT_CLIENTES = Value
        End Set
    End Property

    Public Property PERMISO_ADMINISTRADOR() As String
        Get
            Return Me._PERMISO_ADMINISTRADOR
        End Get
        Set(ByVal Value As String)
            Me._PERMISO_ADMINISTRADOR = Value
        End Set
    End Property

    Public Property PERMISO_ARMADO_PALET() As String
        Get
            Return Me._PERMISO_ARMADO_PALET
        End Get
        Set(ByVal Value As String)
            Me._PERMISO_ARMADO_PALET = Value
        End Set
    End Property

    Public Property ESTATUS() As String
        Get
            Return Me._ESTATUS
        End Get
        Set(ByVal Value As String)
            Me._ESTATUS = Value
        End Set
    End Property

    Public Property CORREO_USUARIO() As String
        Get
            Return Me._CORREO_USUARIO
        End Get
        Set(ByVal Value As String)
            Me._CORREO_USUARIO = Value
        End Set
    End Property

    Public Property CLAVE_CORREO() As String
        Get
            Return Me._CLAVE_CORREO
        End Get
        Set(ByVal Value As String)
            Me._CLAVE_CORREO = Value
        End Set
    End Property

    Public Property SERVIDOR_CORREO_REMITENTE() As String
        Get
            Return Me._SERVIDOR_CORREO_REMITENTE
        End Get
        Set(ByVal Value As String)
            Me._SERVIDOR_CORREO_REMITENTE = Value
        End Set
    End Property

    Public Property PUERTO_REMITENTE() As String
        Get
            Return Me._PUERTO_REMITENTE
        End Get
        Set(ByVal Value As String)
            Me._PUERTO_REMITENTE = Value
        End Set
    End Property

    Public Property USAR_SSL_REMITENTE() As Boolean
        Get
            Return Me._USAR_SSL_REMITENTE
        End Get
        Set(ByVal Value As Boolean)
            Me._USAR_SSL_REMITENTE = Value
        End Set
    End Property

    Public Property PERMISO_CAMBIAR_PRECIO_VENTA() As Boolean
        Get
            Return Me._PERMISO_CAMBIAR_PRECIO_VENTA
        End Get
        Set(ByVal Value As Boolean)
            Me._PERMISO_CAMBIAR_PRECIO_VENTA = Value
        End Set
    End Property

    Public Property ADMON_CREDITOS() As Integer
        Get
            Return Me._ADMON_CREDITOS
        End Get
        Set(ByVal Value As Integer)
            Me._ADMON_CREDITOS = Value
        End Set
    End Property

    Public Property VER_COSTOS() As Boolean
        Get
            Return Me._VER_COSTOS
        End Get
        Set(ByVal Value As Boolean)
            Me._VER_COSTOS = Value
        End Set
    End Property

    Public Property CODIGO_VENDEDOR() As String
        Get
            Return Me._CODIGO_VENDEDOR
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_VENDEDOR = Value
        End Set
    End Property

    Public Property PERMISOS_FORMULAS_CONFIDENCIALES() As Boolean
        Get
            Return Me._PERMISO_FORMULAS_CONFIDENCIALES
        End Get
        Set(value As Boolean)
            Me._PERMISO_FORMULAS_CONFIDENCIALES = value
        End Set
    End Property

    Public Property CODIGO_DEPARTAMENTO() As String
        Get
            Return Me._CODIGO_DEPARTAMENTO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_DEPARTAMENTO = Value
        End Set
    End Property

    Public Property PERMISO_GRABAR_OC_SIN_REQUISICION() As String
        Get
            Return Me._PERMISO_GRABAR_OC_SIN_REQUISICION
        End Get
        Set(value As String)
            Me._PERMISO_GRABAR_OC_SIN_REQUISICION = value
        End Set
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

    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property

#End Region

#End Region

#Region "Constructor y destructor"

    Public Sub New()
        Me._Nombre_Catalogo = "SIS_USUARIOS"
        ' Me._Nombre_Reporte = "RPT_SIS_USUARIOS.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * From SIS_USUARIOS"
        Me._QueryOrder = " Order by NOMBRE_USUARIO"
        Me._Codigo_Plaza = 0
    End Sub

    Public Sub New(ByVal bAbrirConexion As Boolean, ByVal bLogin As Boolean)
        Me._Nombre_Catalogo = "SIS_USUARIOS"
    End Sub

    Public Sub New(ByVal iCodigoUsuario As Integer)
        Me.New()
        Me._Codigo_Usuario = iCodigoUsuario

        Try
            If Me.Consultar = True Then
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'oClaveAutorizacion = Nothing
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function Grabar(ByVal sAccion As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_UTILERIAS_USUARIO_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Me._Codigo_Usuario : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@NOMBRE_USUARIO", SqlDbType.NVarChar, 60) : sqlParametro.Value = Me._Nombre_Usuario.ToUpper
            sqlParametro = .Parameters.Add("@CLAVE", SqlDbType.NVarChar, 12) : sqlParametro.Value = Me._Clave
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._Codigo_Plaza
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._Codigo_Almacen
            sqlParametro = .Parameters.Add("@PERMISO_CON_CAT_CUENTAS", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._PERMISO_CON_CAT_CUENTAS
            sqlParametro = .Parameters.Add("@PERMISO_CAT_ARTICULOS", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._PERMISO_CAT_ARTICULOS
            sqlParametro = .Parameters.Add("@PERMISO_CAT_CLIENTES", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._PERMISO_CAT_CLIENTES
            sqlParametro = .Parameters.Add("@PERMISO_ADMINISTRADOR", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._PERMISO_ADMINISTRADOR
            sqlParametro = .Parameters.Add("@PERMISO_ARMADO_PALET", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._PERMISO_ARMADO_PALET
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._ESTATUS
            sqlParametro = .Parameters.Add("@CORREO_USUARIO", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._CORREO_USUARIO
            sqlParametro = .Parameters.Add("@CLAVE_CORREO", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CLAVE_CORREO
            sqlParametro = .Parameters.Add("@ADMON_CREDITOS", SqlDbType.SmallInt) : sqlParametro.Value = Me._ADMON_CREDITOS
            sqlParametro = .Parameters.Add("@VER_COSTOS", SqlDbType.NVarChar, 1) : sqlParametro.Value = Convert.ToInt32(Me._VER_COSTOS).ToString
            If txtLEN(Me._CODIGO_VENDEDOR) = True Then
                sqlParametro = .Parameters.Add("@CODIGO_VENDEDOR", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_VENDEDOR)
            Else
                sqlParametro = .Parameters.Add("@CODIGO_VENDEDOR", SqlDbType.SmallInt) : sqlParametro.Value = DBNull.Value
            End If
            sqlParametro = .Parameters.Add("@PERMISO_FORMULAS_CONFIDENCIALES", SqlDbType.NVarChar, 1) : sqlParametro.Value = Convert.ToInt32(Me._PERMISO_FORMULAS_CONFIDENCIALES).ToString
            sqlParametro = .Parameters.Add("@CODIGO_DEPARTAMENTO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_DEPARTAMENTO
            sqlParametro = .Parameters.Add("@PERMISO_GRABAR_OC_SIN_REQUISICION", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._PERMISO_GRABAR_OC_SIN_REQUISICION
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = sAccion '"ACTUALIZAR" 'INSERTAR

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._Codigo_Usuario = .Parameters("@CODIGO_USUARIO").Value.ToString
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Grabar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Private Function ConsultarUnico(ByVal sSQL As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(sSQL, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._Codigo_Usuario = dReader("CODIGO_USUARIO")
                    Me._Nombre_Usuario = "" & dReader("NOMBRE_USUARIO").ToString
                    Me._Codigo_Plaza = "" & dReader("Codigo_Plaza").ToString
                    Me._Clave = "" & dReader("CLAVE").ToString
                    Me._Codigo_Almacen = "" & dReader("CODIGO_ALMACEN").ToString
                    Me._PERMISO_CON_CAT_CUENTAS = "" & dReader("PERMISO_CON_CAT_CUENTAS").ToString
                    Me._PERMISO_CAT_ARTICULOS = "" & dReader("PERMISO_CAT_ARTICULOS").ToString
                    Me._PERMISO_CAT_CLIENTES = "" & dReader("PERMISO_CAT_CLIENTES").ToString
                    Me._PERMISO_ADMINISTRADOR = "" & dReader("PERMISO_ADMINISTRADOR").ToString
                    Me._PERMISO_ARMADO_PALET = "" & dReader("PERMISO_ARMADO_PALET").ToString
                    Me._ESTATUS = "" & dReader("ESTATUS").ToString
                    Me._CORREO_USUARIO = Trim("" & dReader("CORREO_USUARIO").ToString)
                    Me._CLAVE_CORREO = Trim("" & dReader("CLAVE_CORREO").ToString)
                    Me._SERVIDOR_CORREO_REMITENTE = Trim("" & dReader("SERVIDOR_CORREO_REMITENTE").ToString)
                    Me._PUERTO_REMITENTE = Trim("" & dReader("PUERTO_REMITENTE").ToString)
                    Me._USAR_SSL_REMITENTE = CBool(dReader("USAR_SSL_REMITENTE").ToString)
                    Me._PERMISO_CAMBIAR_PRECIO_VENTA = CBool(dReader("PERMISO_CAMBIAR_PRECIO_VENTA").ToString)
                    Me._ADMON_CREDITOS = CInt(dReader("ADMON_CREDITOS"))
                    Me._VER_COSTOS = CBool(dReader("VER_COSTOS").ToString)
                    Me._CODIGO_VENDEDOR = "" & dReader("CODIGO_VENDEDOR").ToString
                    Me._PERMISO_FORMULAS_CONFIDENCIALES = CBool(dReader("PERMISO_FORMULAS_CONFIDENCIALES"))
                    Me._CODIGO_DEPARTAMENTO = dReader("CODIGO_DEPARTAMENTO").ToString
                    Me._PERMISO_GRABAR_OC_SIN_REQUISICION = "" & dReader("PERMISO_GRABAR_OC_SIN_REQUISICION").ToString

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "ConsultarUnico", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
        Return bResultado
    End Function

    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Try
            bResultado = Me.ConsultarUnico(Me._QuerySelect & " Where CODIGO_USUARIO=" & Me._Codigo_Usuario.ToString)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "Consultar", ex)
        End Try
        Return bResultado
    End Function

    Public Function Consultar(ByVal sNombre As String) As Boolean
        Dim bResultado As Boolean = False
        Try
            bResultado = Me.ConsultarUnico(Me._QuerySelect & " Where NOMBRE_USUARIO='" & sReplace(sNombre) & "'")
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "Consultar", ex)
        End Try
        Return bResultado
    End Function

    Public Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    '    Public Sub ObtenerALMACENESUSUARIOS(ByRef LST As ListBox)
    '        Dim cmd As New SqlCommand("SELECT CODIGO_ALMACEN,NOMBRE_ALMACEN FROM VW_CAT_REL_ALMACENES_USUARIOS Where CODIGO_USUARIO='" & Replace(Me._Codigo_Usuario, "'", "''") & "'", Me._Conexion)
    '        Dim dReader As SqlDataReader
    '        With cmd
    '            .CommandTimeout = 0
    '            .CommandType = CommandType.Text
    '            Try
    '                Me._Conexion.Open()
    '                dReader = .ExecuteReader()

    '                If dReader.HasRows Then
    '                    While dReader.Read()
    '                        LST.Items.Add(dReader("NOMBRE_ALMACEN").ToString)
    '                    End While
    '                End If
    '                dReader.Close()
    '            Catch ex As Exception
    '                HandleError(Me.Nombre_Catalogo, "Obtener Almacenes", ex)
    '            Finally
    '                Me._Conexion.Close()
    '                cmd.Dispose()
    '            End Try
    '        End With

    '    End Sub

    'Public Sub ObtenerPlazasUsuarios(ByRef LST As ListBox)
    '    Dim cmd As New SqlCommand("SELECT CODIGO_PLAZA,NOMBRE_PLAZA FROM VW_CAT_REL_PLAZAS_USUARIOS Where CODIGO_USUARIO='" & Replace(Me._Codigo_Usuario, "'", "''") & "'", Me._Conexion)
    '    Dim dReader As SqlDataReader
    '    With cmd
    '        .CommandTimeout = 0
    '        .CommandType = CommandType.Text
    '        Try
    '            Me._Conexion.Open()
    '            dReader = .ExecuteReader()

    '            If dReader.HasRows Then
    '                While dReader.Read()
    '                    LST.Items.Add(dReader("NOMBRE_PLAZA").ToString)
    '                End While
    '            End If
    '            dReader.Close()
    '        Catch ex As Exception
    '            HandleError(Me.Nombre_Catalogo, "Obtener PLAZAS", ex)
    '        Finally
    '            Me._Conexion.Close()
    '            cmd.Dispose()
    '        End Try
    '    End With
    'End Sub

    '    Public Sub ObtenerDOCUMENTOSUSUARIOS(ByRef LST As ListBox, Optional ByVal STRALMACEN As String = "", Optional ByVal STRCENTRO As String = "")
    '        Dim STRSQL As String

    '        STRSQL = "SELECT DISTINCT CODIGO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM VW_CAT_REL_DOCUMENTOS_USUARIOS Where CODIGO_USUARIO='" & Replace(Me._Codigo_Usuario, "'", "''") & "'"
    '        If STRALMACEN <> "" Then
    '            STRSQL = STRSQL & " AND NOMBRE_ALMACEN='" & STRALMACEN & "'"
    '        End If

    '        If STRCENTRO <> "" Then
    '            STRSQL = STRSQL & " AND NOMBRE_CENTRO='" & STRCENTRO & "'"
    '        End If

    '        Dim cmd As New SqlCommand(STRSQL, Me._Conexion)
    '        Dim dReader As SqlDataReader
    '        With cmd
    '            .CommandTimeout = 0
    '            .CommandType = CommandType.Text
    '            Try
    '                Me._Conexion.Open()
    '                dReader = .ExecuteReader()

    '                If dReader.HasRows Then
    '                    While dReader.Read()
    '                        LST.Items.Add(dReader("NOMBRE_TIPO_DOCUMENTO").ToString)
    '                    End While
    '                End If
    '                dReader.Close()
    '            Catch ex As Exception
    '                HandleError(Me.Nombre_Catalogo, "Obtener DOCUMENTOS", ex)
    '            Finally
    '                Me._Conexion.Close()
    '                cmd.Dispose()
    '            End Try
    '        End With

    '    End Sub

    Public Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Usuarios por Código."
        f.sCampo = "CODIGO_USUARIO"
        f.sOrder = "NOMBRE_USUARIO"
        f.sTable = "SIS_USUARIOS"
        f.sQl = "Select CODIGO_USUARIO,NOMBRE_USUARIO From SIS_USUARIOS Where 1=1 And"
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

    Public Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Usuarios por Descripción."
        f.sCampo = "NOMBRE_USUARIO"
        f.sOrder = "NOMBRE_USUARIO"
        f.sTable = "SIS_USUARIOS"
        f.sQl = "SELECT CODIGO_USUARIO,NOMBRE_USUARIO FROM SIS_USUARIOS WHERE 1=1 AND ESTATUS='A' AND "
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

    Public Function BusquedaVisual_PorDescripcion(ByVal sCodigoDepartamento As String) As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Usuarios por Descripción."
        f.sCampo = "NOMBRE_USUARIO"
        f.sOrder = "NOMBRE_USUARIO"
        f.sTable = "SIS_USUARIOS"
        f.sQl = "SELECT CODIGO_USUARIO,NOMBRE_USUARIO FROM SIS_USUARIOS WHERE 1=1 AND ESTATUS='A' AND CODIGO_DEPARTAMENTO=" & sCodigoDepartamento & " AND "
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

    Public Function ValidaContraseña(ByVal sContraseña As String) As Boolean
        sContraseña = "" & Replace(sContraseña, "'", "''")
        If sContraseña = Usuario.Clave Then 'Then 'Decrypt(Me._Clave, Me.Codigo_Usuario) Then
            Return True
        End If
    End Function

    Public Function CambiarContraseña(ByVal iCodigoUsuario As Integer, ByVal sContraseña As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_UTILERIAS_SIS_USUARIOS_CLAVE_ACTUALIZA"

            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = iCodigoUsuario
            sqlParametro = .Parameters.Add("@CLAVE", SqlDbType.NVarChar, 12) : sqlParametro.Value = sContraseña

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "CambiarContraseña", ex)
            Finally
                Me._Conexion.Close()
                'Me._Conexion.Dispose()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function ValidaPermisoUsuarioDocumentoSinAfectacionInventarios(ByVal sCodigo_Documento As String) As Boolean
        Dim sQuery As String
        Dim Doc As New Class_CatDocumentos

        Try
            Doc.CODIGO_DOCUMENTO = sCodigo_Documento

            If Not Doc.Consultar() Then
                MsgBox("El documento " & sCodigo_Documento & " no fue encontrado en el catálogo de documentos.", MsgBoxStyle.Exclamation, "Validación de permisos de usuarios sobre documentos")
                Return False
            End If

            sQuery = "SELECT 1 FROM SIS_PERMISOS_USUARIOS_DOCUMENTOS_SIN_AFECTACION_INVENTARIOS " &
            "WHERE CODIGO_DOCUMENTO='" & sCodigo_Documento & "' AND CODIGO_USUARIO='" & Usuario.Codigo_Usuario & "'"

            Dim sql As New Class_find(sQuery)
            If sql.Result1 = "" Or Len(sql.Result1) < 1 Then
                'MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para utilizar el documento " & Doc.NOMBRE_DOCUMENTO & ".", MsgBoxStyle.Exclamation, "Validación de permisos de usuarios sobre documentos")
                Return False
            End If

            Return True
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ValidaPermisoUsuarioDocumentoSinAfectacionInventarios", ex)
        End Try

    End Function

    Public Function ValidaPermisoUsuarioDocumentoConAfectacionInventarios(ByVal sCodigoDocumento As String, ByVal sCodigoAlmacen As String) As Boolean
        Dim bResultado As Boolean = False
        Dim sQuery As String
        Dim Doc As New Class_CatDocumentos

        Try
            Doc.CODIGO_DOCUMENTO = sCodigoDocumento

            If Not Doc.Consultar() Then
                MsgBox("El documento " & sCodigoDocumento & " no fue encontrado en el catálogo de documentos.", MsgBoxStyle.Exclamation, "Validación de permisos de usuarios sobre documentos")
                Return False
            End If

            sQuery = "SELECT 1 FROM SIS_PERMISOS_USUARIOS_DOCUMENTOS_CON_AFECTACION_INVENTARIOS " &
            "WHERE CODIGO_DOCUMENTO='" & sCodigoDocumento & "' AND CODIGO_USUARIO='" & Usuario.Codigo_Usuario & "' AND CODIGO_ALMACEN='" & sCodigoAlmacen & "' "

            Dim sql As New Class_find(sQuery)
            If sql.Result1 = "" Or Len(sql.Result1) < 1 Then
                'MsgBox("El usuario " & Usuario.Nombre_Completo & " no tiene permiso para utilizar el documento " & Doc.NOMBRE_DOCUMENTO & ".", MsgBoxStyle.Exclamation, "Validación de permisos de usuarios sobre documentos")
                Return False
            End If

            Return True
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ValidaPermisoUsuarioDocumentoConAfectacionInventarios", ex)
        End Try

    End Function

    'Public Function ValidaPermisoUsuarioTiposDocumentosSinAfectaInventarios(ByVal sCodigoDocumento As String, ByVal sCodigoAlmacen As String, ByVal sCodigoAlmacen2 As String) As Boolean
    '    Dim sQuery As String
    '    Dim Doc As New Class_CatDocumentos
    '    Doc.CODIGO_DOCUMENTO = sCodigoDocumento

    '    If Not Doc.Consultar() Then
    '        MsgBox("El documento " & sCodigoDocumento & " no fue encontrado en el catálogo de documentos.", MsgBoxStyle.Critical, "Validación de permisos de usuarios sobre documentos")
    '        Exit Function
    '    End If

    '    If txtLEN(sCodigoAlmacen2) = True Then
    '        sQuery = "SELECT 1 FROM SIS_PERMISOS_USUARIOS_TIPOS_DOCUMENTOS_AFECTA_INVENTARIOS " & _
    '        "WHERE CODIGO_TIPO_DOCUMENTO='" & sCodigoDocumento & "' AND CODIGO_USUARIO='" & Usuario.Codigo_Usuario & "' AND CODIGO_ALMACEN='" & sCodigoAlmacen & "' AND CODIGO_ALMACEN2='" & sCodigoAlmacen2 & "' "
    '    Else
    '        sQuery = "SELECT 1 FROM SIS_PERMISOS_USUARIOS_TIPOS_DOCUMENTOS_AFECTA_INVENTARIOS " & _
    '        "WHERE CODIGO_TIPO_DOCUMENTO='" & sCodigoDocumento & "' AND CODIGO_USUARIO='" & Usuario.Codigo_Usuario & "' AND CODIGO_ALMACEN='" & sCodigoAlmacen & "' "
    '    End If

    '    Dim sql As New Class_find(sQuery)
    '    If sql.Result1 = "" Or Len(sql.Result1) < 1 Then
    '        MsgBox("El usuario " & Usuario.Nombre_Completo & " no tiene permiso para utilizar el documento " & Doc.NOMBRE_DOCUMENTO & ".", MsgBoxStyle.Critical, "Validación de permisos de usuarios sobre documentos")
    '        Exit Function
    '    End If
    '    ValidaPermisoUsuarioTiposDocumentosSinAfectaInventarios = True
    'End Function

    Public Function ValidaPermisoUsuarioTiposDocumentosConAfectaInventarios(ByVal sCodigoTipoDocumento As String, ByVal sCodigoAlmacen As String, ByVal sCodigoAlmacen2 As String) As Boolean
        Dim sQuery As String
        Dim Doc As New Class_CatDocumentos

        Try
            Doc.CODIGO_TIPO_DOCUMENTO = sCodigoTipoDocumento

            If Not Doc.ConsultarTipoDocumento() Then
                MsgBox("El tipo de documento " & sCodigoTipoDocumento & " no fue encontrado en el catálogo de documentos.", MsgBoxStyle.Exclamation, "Validación de permisos de usuarios sobre documentos")
                Return False
            End If

            If txtLEN(sCodigoAlmacen2) = True Then
                sQuery = "SELECT 1 FROM SIS_PERMISOS_USUARIOS_TIPOS_DOCUMENTOS_CON_AFECTACION_INVENTARIOS " &
               "WHERE CODIGO_TIPO_DOCUMENTO='" & sCodigoTipoDocumento & "' AND CODIGO_USUARIO='" & Usuario.Codigo_Usuario & "' AND CODIGO_ALMACEN='" & sCodigoAlmacen & "' AND CODIGO_ALMACEN2='" & sCodigoAlmacen2 & "' "
            Else
                sQuery = "SELECT 1 FROM SIS_PERMISOS_USUARIOS_TIPOS_DOCUMENTOS_CON_AFECTACION_INVENTARIOS " &
                "WHERE CODIGO_TIPO_DOCUMENTO='" & sCodigoTipoDocumento & "' AND CODIGO_USUARIO='" & Usuario.Codigo_Usuario & "' AND CODIGO_ALMACEN='" & sCodigoAlmacen & "' "
            End If

            Dim sql As New Class_find(sQuery)
            If sql.Result1 = "" Or Len(sql.Result1) < 1 Then
                Dim oAlmacen1 As New Class_CatAlmacenes(sCodigoAlmacen)
                Dim oAlmacen2 As New Class_CatAlmacenes
                If txtLEN(sCodigoAlmacen2) = True Then
                    oAlmacen2 = New Class_CatAlmacenes(sCodigoAlmacen2)
                End If
                MsgBox("El usuario " & Usuario.Nombre_Usuario & " no tiene permiso para utilizar el documento " & Doc.NOMBRE_DOCUMENTO & vbCrLf &
                       "del almacén " & sCodigoAlmacen & "-" & oAlmacen1.NOMBRE_ALMACEN &
                    IIf(sCodigoAlmacen2.Length > 0, " al almacén " & sCodigoAlmacen2 & "-" & oAlmacen2.NOMBRE_ALMACEN, "").ToString & ".", MsgBoxStyle.Exclamation, "Validación de permisos de usuarios sobre documentos")
                Return False
            End If

            Return True
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ValidaPermisoUsuarioTiposDocumentosConAfectaInventarios", ex)
        End Try
    End Function

    Public Function CodigoSiguiente() As String
        Dim iUsuario As Integer, sUsuario As String
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("SELECT MAX(CODIGO_USUARIO) FROM SIS_USUARIOS")
            If sql.Result1 = "" Then
                iUsuario = 1
            Else
                iUsuario = CType(sql.Result1, Integer) + 1
            End If
            sUsuario = "0000" + iUsuario.ToString
            Resultado = sUsuario.Substring(Len(sUsuario) - 4)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
        End Try
        Return Resultado
    End Function

    Public Function ObtenerDetallePermisosUsuarioDocumentosConAfectaInventarios(ByVal iPlaza As Integer) As System.Data.DataTable
        Dim dt As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        sSQL = "SELECT P.CODIGO_DOCUMENTO,V.NOMBRE_TIPO_DOCUMENTO,P.CODIGO_ALMACEN " & _
               "FROM SIS_PERMISOS_USUARIOS_DOCUMENTOS_CON_AFECTACION_INVENTARIOS P " & _
               "INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO V ON (P.CODIGO_DOCUMENTO=V.CODIGO_DOCUMENTO) " & _
               "WHERE P.CODIGO_USUARIO=" & Codigo_Usuario.ToString '& " AND V.CODIGO_PLAZA=" & iPlaza.ToString '& " AND V.CODIGO_MODULO='" & sCodigoModulo.ToString & "'"

        Try
            'Dim da As New SqlDataAdapter("MP_RPT_USUARIOS_PERMISOS_DOCUMENTOS", Me._Conexion)
            'da.SelectCommand.CommandType = CommandType.StoredProcedure

            'With da.SelectCommand
            '    .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt).Value = Me._Codigo_Usuario
            '    .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt).Value = iPlaza
            'End With
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dt)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetallePermisosUsuarioDocumentosConAfectaInventarios", ex)
        Finally

        End Try
        Return dt
    End Function

    Public Function ObtenerDetallePermisosUsuarioDocumentosSinAfectaInventarios(ByVal iPlaza As Integer) As System.Data.DataTable
        Dim dt As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        sSQL = "SELECT P.CODIGO_DOCUMENTO,V.NOMBRE_TIPO_DOCUMENTO " & _
               "FROM SIS_PERMISOS_USUARIOS_DOCUMENTOS_SIN_AFECTACION_INVENTARIOS P " & _
               "INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO V ON (P.CODIGO_DOCUMENTO=V.CODIGO_DOCUMENTO) " & _
               "WHERE P.CODIGO_USUARIO=" & Codigo_Usuario.ToString '& " AND V.CODIGO_PLAZA=" & iPlaza.ToString & " AND V.CODIGO_MODULO='" & sCodigoModulo.ToString & "'"

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dt)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetallePermisosUsuarioDocumentosSinAfectaInventarios", ex)
        Finally

        End Try
        Return dt
    End Function

    Public Function ObtenerDetallePermisosUsuarioTipoDocumentosConAfectaInventarios() As System.Data.DataTable
        Dim dt As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        sSQL = "SELECT DISTINCT P.CODIGO_TIPO_DOCUMENTO,V.NOMBRE_TIPO_DOCUMENTO,P.CODIGO_ALMACEN,ISNULL(P.CODIGO_ALMACEN2,'') CODIGO_ALMACEN2 " & _
               "FROM SIS_PERMISOS_USUARIOS_TIPOS_DOCUMENTOS_CON_AFECTACION_INVENTARIOS P  " & _
               "INNER JOIN VW_SIS_CAT_DOCUMENTOS_EXTENDIDO V ON (P.CODIGO_TIPO_DOCUMENTO=V.CODIGO_TIPO_DOCUMENTO) " & _
               "WHERE P.CODIGO_USUARIO=" & Codigo_Usuario.ToString '& " AND V.CODIGO_PLAZA=" & iPlaza.ToString & " AND V.CODIGO_MODULO='" & sCodigoModulo.ToString & "'"

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dt)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetallePermisosUsuarioTipoDocumentosConAfectaInventarios", ex)
        Finally

        End Try
        Return dt
    End Function

    Public Function ObtenerDetallePermisosMenus() As System.Data.DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        sSQL = "SELECT NOMBRE_MENU FROM SIS_USUARIOS_PERMISOS_MENUS WHERE CODIGO_USUARIO=" & Codigo_Usuario.ToString

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetallePermisosMenus", ex)
        End Try
        Return dTabla
    End Function

    Public Function InsertarPermisoMenu(ByVal sNombreMenu As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_UTILERIAS_SIS_USUARIOS_PERMISOS_MENUS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Me._Codigo_Usuario
            sqlParametro = .Parameters.Add("@NOMBRE_MENU", SqlDbType.NVarChar, 500) : sqlParametro.Value = sNombreMenu

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "InsertarPermisoMenu", ex)
            Finally
                Me._Conexion.Close()
                'Me._Conexion.Dispose()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function EliminaPermisoMenu() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_UTILERIAS_SIS_USUARIOS_PERMISOS_MENUS_ELIMINA"

            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Me._Codigo_Usuario
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "EliminaPermisoMenu", ex)
            Finally
                Me._Conexion.Close()
                'Me._Conexion.Dispose()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function EliminaPermisoDocumentos() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_UTILERIAS_SIS_USUARIOS_PERMISOS_DOCUMENTOS_ELIMINA"

            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Me._Codigo_Usuario

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "EliminaPermisoDocumentos", ex)
            Finally
                Me._Conexion.Close()
                'Me._Conexion.Dispose()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function GrabaPermisoDocumentos(ByVal sCodigoDocumento As String, Optional ByVal sCodigoAlmacen As String = "") As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_UTILERIAS_SIS_USUARIOS_PERMISOS_DOCUMENTOS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Me._Codigo_Usuario
            sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = sCodigoDocumento
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN", SqlDbType.NVarChar, 4) : sqlParametro.Value = sCodigoAlmacen

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "GrabaPermisoDocumentos", ex)
            Finally
                Me._Conexion.Close()
                'Me._Conexion.Dispose()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function GrabaPermisosTipoDocumentos(ByVal sCodigoTipoDocumento As String, ByVal sCodigoAlmacen As String, ByVal sCodigoAlmacen2 As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_UTILERIAS_SIS_USUARIOS_PERMISOS_TIPOS_DOCUMENTOS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Me._Codigo_Usuario
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = sCodigoTipoDocumento
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN", SqlDbType.NVarChar, 4) : sqlParametro.Value = sCodigoAlmacen
            sqlParametro = .Parameters.Add("@CODIGO_ALMACEN2", SqlDbType.NVarChar, 4) : sqlParametro.Value = sCodigoAlmacen2

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "GrabaPermisosTipoDocumentos", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function ActualizarCorreo() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_SIS_USUARIOS_ACTUALIZA_CORREO"

            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Me._Codigo_Usuario.ToString
            sqlParametro = .Parameters.Add("@CORREO_USUARIO", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._CORREO_USUARIO.ToString
            sqlParametro = .Parameters.Add("@CLAVE_CORREO", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CLAVE_CORREO.ToString

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "ActualizarCorreo", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

#End Region

End Class
