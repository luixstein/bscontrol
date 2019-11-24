Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatProveedores
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_PROVEEDOR As String
    Private _NOMBRE_PROVEEDOR As String
    Private _PLAZO As Integer
    Private _DOMICILIO As String
    Private _RFC As String
    Private _TELEFONO As String
    Private _FAX As String
    Private _CELULAR As String
    Private _CORREO_ELECTRONICO As String
    Private _SALDO As Double
    Private _FECHA_ALTA As Date
    Private _CUENTA_CONTABLE As String
    Private _CUENTA_CONTABLE_DOLARES As String
    Private _CODIGO_TIPO_PROVEEDOR As String
    Private _CONTACTO As String
    Private _CONTACTO_TELEFONO_CELULAR As String
    Private _CODIGO_PLAZA As Integer
    Private _CURP As String
    Private _PROTEGIDO As Boolean
    Private _CODIGO_PROPIETARIO As String
    Private _LIMITE_CREDITO As Double
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean
    Private _NOMBRE_TIPO_PROVEEDOR As String
    Private _CuentaBancaria As Class_CatCuentasBancarias
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

    Public Property Codigo_Proveedor() As String
        Get
            Return Me._CODIGO_PROVEEDOR
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_PROVEEDOR = Value
        End Set
    End Property

    Public Property Nombre_Proveedor() As String
        Get
            Return Me._NOMBRE_PROVEEDOR
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_PROVEEDOR = Value
        End Set
    End Property

    Public Property Plazo() As Integer
        Get
            Return Me._PLAZO
        End Get
        Set(ByVal Value As Integer)
            Me._PLAZO = Value
        End Set
    End Property

    'Public Property ESTATUS() As String
    '    Get
    '        Return Me._ESTATUS
    '    End Get
    '    Set(ByVal Value As String)
    '        Me._ESTATUS = Value
    '    End Set
    'End Property

    Public Property Domicilio() As String
        Get
            Return Me._DOMICILIO
        End Get
        Set(ByVal Value As String)
            Me._DOMICILIO = Value
        End Set
    End Property

    Public Property RFC() As String
        Get
            Return Me._RFC
        End Get
        Set(ByVal Value As String)
            Me._RFC = Value
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return Me._TELEFONO
        End Get
        Set(ByVal Value As String)
            Me._TELEFONO = Value
        End Set
    End Property

    Public Property Fax() As String
        Get
            Return Me._FAX
        End Get
        Set(ByVal Value As String)
            Me._FAX = Value
        End Set
    End Property

    Public Property Celular() As String
        Get
            Return Me._CELULAR
        End Get
        Set(ByVal Value As String)
            Me._CELULAR = Value
        End Set
    End Property

    Public Property Correo_Electronico() As String
        Get
            Return Me._CORREO_ELECTRONICO
        End Get
        Set(ByVal Value As String)
            Me._CORREO_ELECTRONICO = Value
        End Set
    End Property

    Public Property Saldo() As Double
        Get
            Return Me._SALDO
        End Get
        Set(ByVal Value As Double)
            Me._SALDO = Value
        End Set
    End Property

    Public Property FECHA_ALTA() As Date
        Get
            Return Me._FECHA_ALTA
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_ALTA = Value
        End Set
    End Property

    Public Property CUENTA_CONTABLE() As String
        Get
            Return Me._CUENTA_CONTABLE
        End Get
        Set(ByVal Value As String)
            Me._CUENTA_CONTABLE = Value
        End Set
    End Property

    Public Property CUENTA_CONTABLE_DOLARES() As String
        Get
            Return Me._CUENTA_CONTABLE_DOLARES
        End Get
        Set(ByVal Value As String)
            Me._CUENTA_CONTABLE_DOLARES = Value
        End Set
    End Property

    Public Property Codigo_Tipo_Proveedor() As String
        Get
            Return Me._CODIGO_TIPO_PROVEEDOR
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_TIPO_PROVEEDOR = Value
        End Set
    End Property

    Public Property Contacto() As String
        Get
            Return Me._CONTACTO
        End Get
        Set(ByVal Value As String)
            Me._CONTACTO = Value
        End Set
    End Property

    Public Property Contacto_Telefono_Celular() As String
        Get
            Return Me._CONTACTO_TELEFONO_CELULAR
        End Get
        Set(ByVal Value As String)
            Me._CONTACTO_TELEFONO_CELULAR = Value
        End Set
    End Property

    Public Property CODIGO_PLAZA() As Integer
        Get
            Return Me._CODIGO_PLAZA
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_PLAZA = Value
        End Set
    End Property

    Public Property CURP() As String
        Get
            Return Me._CURP
        End Get
        Set(ByVal Value As String)
            Me._CURP = Value
        End Set
    End Property

    Public ReadOnly Property PROTEGIDO() As Boolean
        Get
            Return Me._PROTEGIDO
        End Get
    End Property

    Public Property LIMITE_CREDITO() As Double
        Get
            Return Me._LIMITE_CREDITO
        End Get
        Set(ByVal Value As Double)
            Me._LIMITE_CREDITO = Value
        End Set
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property

    Public ReadOnly Property NOMBRE_TIPO_PROVEEDOR() As String
        Get
            Return Me._NOMBRE_TIPO_PROVEEDOR
        End Get
    End Property

    Public ReadOnly Property CuentaBancaria() As Class_CatCuentasBancarias
        Get
            Return Me._CuentaBancaria
        End Get
    End Property

    Public Property CODIGO_PROPIETARIO() As String
        Get
            Return Me._CODIGO_PROPIETARIO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_PROPIETARIO = Value
        End Set
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

#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "Cat_Proveedores"
        Me._Nombre_Reporte = "RPT_CATALOGO_PROVEEDORES"

        Me._Conexion = New SqlConnection(Empresa_Sistema.conexion)

        Me._QuerySelect = "SELECT C.*,T.NOMBRE_TIPO_PROVEEDOR,CB.ID_CUENTA_BANCARIA " & _
            "FROM CAT_PROVEEDORES C " & _
            "INNER JOIN SIS_TIPOS_PROVEEDORES T ON(C.CODIGO_TIPO_PROVEEDOR=T.CODIGO_TIPO_PROVEEDOR) " & _
            "LEFT JOIN CAT_CUENTAS_BANCARIAS CB ON(C.CODIGO_PROVEEDOR=CB.CODIGO_PROVEEDOR) "

        Me._QueryOrder = " ORDER BY NOMBRE_PROVEEDOR"
    End Sub

    Public Sub New(ByVal sCodigoProveedor As String)
        Me.New()
        Me._CODIGO_PROVEEDOR = sCodigoProveedor
        Try
            If Me.Consultar = True Then
                Me._Existe = True
                'Else
                '    Throw New Exception("El proveedor no existe.")
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

#Region "Métodos y procedimientos"
    ''' <summary>
    ''' Inserta un proveedor al catálogo.
    ''' </summary>
    Public Overrides Function Insertar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_PROVEEDORES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_PROVEEDOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_PROVEEDOR.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_PROVEEDOR", SqlDbType.NVarChar, 130) : sqlParametro.Value = Me._NOMBRE_PROVEEDOR.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = "A"
            sqlParametro = .Parameters.Add("@PLAZO", SqlDbType.SmallInt) : sqlParametro.Value = Me._PLAZO
            sqlParametro = .Parameters.Add("@DOMICILIO", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._DOMICILIO.ToUpper
            sqlParametro = .Parameters.Add("@RFC", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._RFC.ToUpper
            sqlParametro = .Parameters.Add("@CURP", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._CURP.ToUpper
            sqlParametro = .Parameters.Add("@TELEFONO", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._TELEFONO.ToUpper
            sqlParametro = .Parameters.Add("@FAX", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._FAX.ToUpper
            sqlParametro = .Parameters.Add("@CELULAR", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._CELULAR.ToUpper
            sqlParametro = .Parameters.Add("@CORREO_ELECTRONICO", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._CORREO_ELECTRONICO.ToUpper
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_DOLARES", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_DOLARES
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_PROVEEDOR", SqlDbType.Char, 1) : sqlParametro.Value = Me._CODIGO_TIPO_PROVEEDOR.ToUpper
            sqlParametro = .Parameters.Add("@CONTACTO", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONTACTO.ToUpper
            sqlParametro = .Parameters.Add("@CONTACTO_TELEFONO_CELULAR", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONTACTO_TELEFONO_CELULAR.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@LIMITE_CREDITO", SqlDbType.Decimal) : sqlParametro.Value = Me._LIMITE_CREDITO

            If txtLEN(Me._CODIGO_PROPIETARIO) = True Then
                sqlParametro = .Parameters.Add("@CODIGO_PROPIETARIO", SqlDbType.Int) : sqlParametro.Value = CInt(Me._CODIGO_PROPIETARIO)
            Else
                sqlParametro = .Parameters.Add("@CODIGO_PROPIETARIO", SqlDbType.Int) : sqlParametro.Value = DBNull.Value
            End If

            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"

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

    ''' <summary>
    ''' Actualiza al proveedor.
    ''' </summary>
    Public Overrides Function Actualizar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_PROVEEDORES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_PROVEEDOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_PROVEEDOR.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_PROVEEDOR", SqlDbType.NVarChar, 130) : sqlParametro.Value = Me._NOMBRE_PROVEEDOR.ToUpper
            sqlParametro = .Parameters.Add("@PLAZO", SqlDbType.SmallInt) : sqlParametro.Value = Me._PLAZO
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus
            sqlParametro = .Parameters.Add("@DOMICILIO", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._DOMICILIO.ToUpper
            sqlParametro = .Parameters.Add("@RFC", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._RFC.ToUpper
            sqlParametro = .Parameters.Add("@CURP", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._CURP.ToUpper
            sqlParametro = .Parameters.Add("@TELEFONO", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._TELEFONO.ToUpper
            sqlParametro = .Parameters.Add("@FAX", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._FAX.ToUpper
            sqlParametro = .Parameters.Add("@CELULAR", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._CELULAR.ToUpper
            sqlParametro = .Parameters.Add("@CORREO_ELECTRONICO", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._CORREO_ELECTRONICO.ToUpper
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_DOLARES", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_DOLARES
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_PROVEEDOR", SqlDbType.Char, 1) : sqlParametro.Value = Me._CODIGO_TIPO_PROVEEDOR.ToUpper
            sqlParametro = .Parameters.Add("@CONTACTO", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONTACTO.ToUpper
            sqlParametro = .Parameters.Add("@CONTACTO_TELEFONO_CELULAR", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._CONTACTO_TELEFONO_CELULAR.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@LIMITE_CREDITO", SqlDbType.Decimal) : sqlParametro.Value = Me._LIMITE_CREDITO

            If txtLEN(Me._CODIGO_PROPIETARIO) = True Then
                sqlParametro = .Parameters.Add("@CODIGO_PROPIETARIO", SqlDbType.Int) : sqlParametro.Value = CInt(Me._CODIGO_PROPIETARIO)
            Else
                sqlParametro = .Parameters.Add("@CODIGO_PROPIETARIO", SqlDbType.Int) : sqlParametro.Value = DBNull.Value
            End If
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

    Public Function EliminarProveedor() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_PROVEEDORES_ELIMINA"

            sqlParametro = .Parameters.Add("@CODIGO_PROVEEDOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_PROVEEDOR.ToUpper
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_DOLARES", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_DOLARES

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "EliminarProveedor", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    ''' <summary>
    ''' Consulta y refresca los campos del almacén.
    ''' </summary>
    Public Overrides Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE C.CODIGO_PROVEEDOR='" & Replace(Me._CODIGO_PROVEEDOR, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._CODIGO_PROVEEDOR = "" & dReader("CODIGO_PROVEEDOR").ToString()
                    Me._NOMBRE_PROVEEDOR = Trim("" & dReader("NOMBRE_PROVEEDOR").ToString())
                    Me._PLAZO = Convert.ToInt32(dReader("PLAZO"))
                    Me.Estatus = "" & dReader("ESTATUS").ToString()
                    Me._DOMICILIO = dReader("DOMICILIO").ToString()
                    Me._RFC = "" & dReader("RFC").ToString()
                    Me._TELEFONO = dReader("TELEFONO").ToString()
                    Me._FAX = "" & dReader("FAX").ToString()
                    Me._CELULAR = "" & dReader("CELULAR").ToString()
                    Me._CORREO_ELECTRONICO = Trim("" & dReader("CORREO_ELECTRONICO").ToString())
                    Me._SALDO = Convert.ToDouble(dReader("SALDO"))
                    Me._FECHA_ALTA = Convert.ToDateTime(dReader("FECHA_ALTA"))
                    Me._CUENTA_CONTABLE = dReader("CUENTA_CONTABLE").ToString()
                    Me._CUENTA_CONTABLE_DOLARES = dReader("CUENTA_CONTABLE_DOLARES").ToString()
                    Me._CODIGO_TIPO_PROVEEDOR = "" & dReader("CODIGO_TIPO_PROVEEDOR").ToString()
                    Me._NOMBRE_TIPO_PROVEEDOR = "" & dReader("NOMBRE_TIPO_PROVEEDOR").ToString()
                    Me._CONTACTO = dReader("CONTACTO").ToString()
                    Me._CONTACTO_TELEFONO_CELULAR = dReader("CONTACTO_TELEFONO_CELULAR").ToString()
                    Me._CODIGO_PLAZA = Convert.ToInt32(dReader("CODIGO_PLAZA"))
                    Me._CURP = "" & dReader("CURP").ToString()
                    Me._PROTEGIDO = CBool(dReader("PROTEGIDO").ToString())
                    Me._CODIGO_PROPIETARIO = "" & dReader("CODIGO_PROPIETARIO").ToString()
                    Me._LIMITE_CREDITO = Convert.ToDouble(dReader("LIMITE_CREDITO"))

                    If txtLEN(dReader("ID_CUENTA_BANCARIA").ToString()) = True Then
                        Me._CuentaBancaria = New Class_CatCuentasBancarias(CInt(dReader("ID_CUENTA_BANCARIA").ToString()))
                    End If

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

    ''' <summary>
    ''' Obtiene a todos los elementos del catálogo.
    ''' </summary>
    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_PROVEEDOR,NOMBRE_PROVEEDOR FROM CAT_PROVEEDORES WHERE CODIGO_PLAZA=" & Usuario.Codigo_Plaza & " ORDER BY NOMBRE_PROVEEDOR", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable

    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String, ByVal Estatus As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_PROVEEDOR, NOMBRE_PROVEEDOR FROM CAT_PROVEEDORES WHERE NOMBRE_PROVEEDOR LIKE '" & Filtro.ToString & "%' AND ESTATUS='" & Estatus & "' ORDER BY NOMBRE_PROVEEDOR", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable

    End Function

    Public Function ObtenerElementosFiltroCodigo(ByVal Filtro As String, ByVal Estatus As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_PROVEEDOR, NOMBRE_PROVEEDOR FROM CAT_PROVEEDORES WHERE CODIGO_PROVEEDOR LIKE '" & Filtro.ToString & "%' AND ESTATUS='" & Estatus & "' ORDER BY CODIGO_PROVEEDOR", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltroCodigo", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerTiposProveedores() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_TIPO_PROVEEDOR,NOMBRE_TIPO_PROVEEDOR,ELEGIBLE_CATALOGO_PROVEEDORES FROM SIS_TIPOS_PROVEEDORES ORDER BY NOMBRE_TIPO_PROVEEDOR", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerTiposProveedores", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Proveedores por Código."
        f.sCampo = "CODIGO_PROVEEDOR"
        f.sOrder = "NOMBRE_PROVEEDOR"
        f.sTable = "CAT_PROVEEDORES"
        f.sQl = "SELECT P.CODIGO_PROVEEDOR,P.NOMBRE_PROVEEDOR FROM CAT_PROVEEDORES P INNER JOIN SIS_TIPOS_PROVEEDORES T ON(P.CODIGO_TIPO_PROVEEDOR=T.CODIGO_TIPO_PROVEEDOR) " & _
                "WHERE P.CODIGO_PLAZA=" & Usuario.Codigo_Plaza & " AND P.ESTATUS='A' AND T.REALIZA_COMPRAS_GASTOS_PAGOS='1' AND "
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
        f.Text = "Búsqueda de Proveedores por Nombre."
        f.sCampo = "NOMBRE_PROVEEDOR"
        f.sOrder = "NOMBRE_PROVEEDOR"
        f.sTable = "CAT_PROVEEDORES"
        f.sQl = "SELECT P.CODIGO_PROVEEDOR,P.NOMBRE_PROVEEDOR FROM CAT_PROVEEDORES P INNER JOIN SIS_TIPOS_PROVEEDORES T ON(P.CODIGO_TIPO_PROVEEDOR=T.CODIGO_TIPO_PROVEEDOR) " & _
                "WHERE P.ESTATUS='A' AND T.REALIZA_COMPRAS_GASTOS_PAGOS='1' AND "
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

    Public Function BusquedaVisual_PorDescripcion_TiposCuentasBancarias() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Proveedores por Nombre."
        f.sCampo = "NOMBRE_PROVEEDOR"
        f.sOrder = "NOMBRE_PROVEEDOR"
        f.sTable = "CAT_PROVEEDORES"
        f.sQl = "SELECT P.CODIGO_PROVEEDOR,P.NOMBRE_PROVEEDOR FROM CAT_PROVEEDORES P INNER JOIN CAT_CUENTAS_BANCARIAS CB ON(P.CODIGO_PROVEEDOR=CB.CODIGO_PROVEEDOR) WHERE 1=1 AND P.CODIGO_PLAZA=" & Usuario.Codigo_Plaza & " AND "
        f.Inicia("%")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion_TiposCuentasBancarias", ex)
        End Try
        Return Resultado
    End Function

    Public Function CodigoSiguiente() As String
        'Dim iProveedor As Integer, sProveedor As String
        Dim sResultado As String = ""
        Try
            'iProveedor = CInt(Strings.Right(Plaza.Codigo_Proveedor, 4))
            'iProveedor = iProveedor + 1
            'sProveedor = "0000" + iProveedor.ToString
            'Resultado = sProveedor.Substring(Len(sProveedor) - 4)
            'Resultado = Strings.Left(Plaza.Codigo_Proveedor, 2) + Resultado

            Dim sql As New Class_find("SELECT 'P'+IDENTIFICADOR+RIGHT('0000'+RIGHT(CODIGO_PROVEEDOR,4)+1,4) FROM SIS_PLAZAS WHERE CODIGO_PLAZA=" & Usuario.Codigo_Plaza)
            sResultado = sql.Result1

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
        End Try
        Return sResultado
    End Function

    Public Function InsertarCuentaContableDolares() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_CUENTAS_GENERA_CUENTA_CONTABLE_DOLARES_PROVEEDOR"

            Me._NOMBRE_PROVEEDOR = Strings.Left(Me._NOMBRE_PROVEEDOR, 120)

            sqlParametro = .Parameters.Add("@NOMBRE_CUENTA_CONTABLE", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._NOMBRE_PROVEEDOR.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PROVEEDOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_PROVEEDOR.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PLAZA

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "InsertarCuentaContableDolares", ex)
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

