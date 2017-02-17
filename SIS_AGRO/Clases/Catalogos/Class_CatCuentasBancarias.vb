Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatCuentasBancarias
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_CUENTA_BANCARIA As Integer
    Private _NOMBRE_CUENTA_BANCARIA As String
    Private _SUCURSAL As String
    Private _NUMERO_CUENTA_BANCARIA As String
    Private _TELEFONO As String
    Private _ESTATUS_CUENTA_BANCARIA As String
    Private _SALDO As Decimal
    Private _CODIGO_BANCO As String
    Private _FOLIO_CHEQUE As String
    Private _CUENTA_CONTABLE_PESOS As String
    Private _CUENTA_CONTABLE_DOLARES As String
    Private _NOMBRE_FORMATO As String
    Private _CODIGO_MONEDA As String
    Private _CODIGO_PROVEEDOR As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
    Private _NOMBRE_MONEDA As String
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
    Public Property ID_CUENTA_BANCARIA() As Integer
        Get
            Return Me._ID_CUENTA_BANCARIA
        End Get
        Set(ByVal VALUE As Integer)
            Me._ID_CUENTA_BANCARIA = VALUE
        End Set
    End Property

    Public Property NOMBRE_CUENTA_BANCARIA() As String
        Get
            Return Me._NOMBRE_CUENTA_BANCARIA
        End Get
        Set(ByVal VALUE As String)
            Me._NOMBRE_CUENTA_BANCARIA = VALUE
        End Set
    End Property

    Public Property SUCURSAL() As String
        Get
            Return Me._SUCURSAL
        End Get
        Set(ByVal VALUE As String)
            Me._SUCURSAL = VALUE
        End Set
    End Property

    Public Property NUMERO_CUENTA_BANCARIA() As String
        Get
            Return Me._NUMERO_CUENTA_BANCARIA
        End Get
        Set(ByVal VALUE As String)
            Me._NUMERO_CUENTA_BANCARIA = VALUE
        End Set
    End Property

    Public Property TELEFONO() As String
        Get
            Return Me._TELEFONO
        End Get
        Set(ByVal VALUE As String)
            Me._TELEFONO = VALUE
        End Set
    End Property

    Public Property ESTATUS_CUENTA_BANCARIA() As String
        Get
            Return Me._ESTATUS_CUENTA_BANCARIA
        End Get
        Set(ByVal VALUE As String)
            Me._ESTATUS_CUENTA_BANCARIA = VALUE
        End Set
    End Property

    Public Property SALDO() As Decimal
        Get
            Return Me._SALDO
        End Get
        Set(ByVal VALUE As Decimal)
            Me._SALDO = VALUE
        End Set
    End Property

    Public Property CODIGO_BANCO() As String
        Get
            Return Me._CODIGO_BANCO
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_BANCO = VALUE
        End Set
    End Property

    Public Property FOLIO_CHEQUE() As String
        Get
            Return Me._FOLIO_CHEQUE
        End Get
        Set(ByVal VALUE As String)
            Me._FOLIO_CHEQUE = VALUE
        End Set
    End Property

    Public Property CUENTA_CONTABLE_PESOS() As String
        Get
            Return Me._CUENTA_CONTABLE_PESOS
        End Get
        Set(ByVal VALUE As String)
            Me._CUENTA_CONTABLE_PESOS = VALUE
        End Set
    End Property

    Public Property CUENTA_CONTABLE_DOLARES() As String
        Get
            Return Me._CUENTA_CONTABLE_DOLARES
        End Get
        Set(ByVal VALUE As String)
            Me._CUENTA_CONTABLE_DOLARES = VALUE
        End Set
    End Property

    Public Property NOMBRE_FORMATO() As String
        Get
            Return Me._NOMBRE_FORMATO
        End Get
        Set(ByVal VALUE As String)
            Me._NOMBRE_FORMATO = VALUE
        End Set
    End Property

    Public Property CODIGO_MONEDA As String
        Get
            Return Me._CODIGO_MONEDA
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_MONEDA = VALUE
        End Set
    End Property

    Public Property CODIGO_PROVEEDOR As String
        Get
            Return Me._CODIGO_PROVEEDOR
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_PROVEEDOR = VALUE
        End Set
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property

    Public ReadOnly Property NOMBRE_MONEDA As String
        Get
            Return Me._NOMBRE_MONEDA
        End Get
    End Property
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
        Me._Nombre_Catalogo = "CAT_CUENTAS_BANCARIAS"
        Me._Nombre_Reporte = "RPT_CATALOGO_CUENTAS_BANCARIAS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.Conexion
        Me._QuerySelect = "SELECT B.*,M.NOMBRE NOMBRE_MONEDA " & _
            "FROM CAT_CUENTAS_BANCARIAS B " & _
            "INNER JOIN CATALOGO_MONEDAS M ON(B.CODIGO_MONEDA=M.CODIGO_MONEDA) "
        Me._QueryOrder = " ORDER BY B.NOMBRE_CUENTA_BANCARIA "
    End Sub

    Public Sub New(ByVal iIDCuentaBancaria As Integer)
        Me.New()
        Me._ID_CUENTA_BANCARIA = iIDCuentaBancaria
        Try
            If Me.Consultar = True Then
                Me._Existe = True
                'Else
                '   Throw New Exception("La cuenta bancaria no existe.")
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
    Public Overrides Function Actualizar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_CUENTAS_BANCARIAS_GRABA"

            sqlParametro = .Parameters.Add("@Id_Cuenta_Bancaria", SqlDbType.SmallInt) : sqlParametro.Value = Me._ID_CUENTA_BANCARIA
            sqlParametro = .Parameters.Add("@Nombre_Cuenta_Bancaria", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._NOMBRE_CUENTA_BANCARIA.ToUpper
            sqlParametro = .Parameters.Add("@Sucursal", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._SUCURSAL.ToUpper
            sqlParametro = .Parameters.Add("@Numero_de_Cuenta_Bancaria", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._NUMERO_CUENTA_BANCARIA
            sqlParametro = .Parameters.Add("@Telefono", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._TELEFONO
            sqlParametro = .Parameters.Add("@ESTATUS_CUENTA_BANCARIA", SqlDbType.Char, 1) : sqlParametro.Value = Me._ESTATUS_CUENTA_BANCARIA.ToUpper
            sqlParametro = .Parameters.Add("@Codigo_Banco", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._CODIGO_BANCO
            sqlParametro = .Parameters.Add("@Folio_Cheque", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_CHEQUE
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_PESOS", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_PESOS
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_DOLARES", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_DOLARES
            sqlParametro = .Parameters.Add("@Nombre_FORMATO", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._NOMBRE_FORMATO.ToUpper
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = "ACTUALIZAR"
            sqlParametro = .Parameters.Add("@CODIGO_PROVEEDOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_PROVEEDOR
            sqlParametro = .Parameters.Add("@CODIGO_MONEDA", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_MONEDA)
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza

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

    ''' <summary>
    ''' Carga al objeto con todos los datos del registro.
    ''' </summary>
    Public Overrides Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE B.ID_CUENTA_BANCARIA=" & Me._ID_CUENTA_BANCARIA, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._ID_CUENTA_BANCARIA = CType(dReader("ID_CUENTA_BANCARIA"), Integer)
                    Me._NOMBRE_CUENTA_BANCARIA = Trim("" & dReader("NOMBRE_CUENTA_BANCARIA").ToString)
                    Me._SUCURSAL = "" & dReader("SUCURSAL").ToString
                    Me._NUMERO_CUENTA_BANCARIA = "" & dReader("NUMERO_DE_CUENTA_BANCARIA").ToString
                    Me._TELEFONO = "" & dReader("TELEFONO").ToString
                    Me._ESTATUS_CUENTA_BANCARIA = dReader("ESTATUS_CUENTA_BANCARIA").ToString
                    Me._SALDO = Convert.ToDecimal(dReader("SALDO"))
                    Me._CODIGO_BANCO = "" & dReader("CODIGO_BANCO").ToString
                    Me._FOLIO_CHEQUE = "" & dReader("FOLIO_CHEQUE").ToString
                    Me._CUENTA_CONTABLE_PESOS = "" & dReader("CUENTA_CONTABLE_PESOS").ToString
                    Me._CUENTA_CONTABLE_DOLARES = "" & dReader("CUENTA_CONTABLE_DOLARES").ToString
                    Me._NOMBRE_FORMATO = "" & dReader("NOMBRE_FORMATO").ToString
                    Me._CODIGO_MONEDA = "" & dReader("CODIGO_MONEDA").ToString
                    Me._CODIGO_PROVEEDOR = "" & dReader("CODIGO_PROVEEDOR").ToString
                    Me._NOMBRE_MONEDA = "" & dReader("NOMBRE_MONEDA").ToString

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

    Public Overrides Function Insertar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_CUENTAS_BANCARIAS_GRABA"

            sqlParametro = .Parameters.Add("@ID_CUENTA_BANCARIA", SqlDbType.SmallInt) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = Me._ID_CUENTA_BANCARIA
            sqlParametro = .Parameters.Add("@NOMBRE_CUENTA_BANCARIA", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._NOMBRE_CUENTA_BANCARIA.ToUpper
            sqlParametro = .Parameters.Add("@SUCURSAL", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._SUCURSAL.ToUpper
            sqlParametro = .Parameters.Add("@NUMERO_DE_CUENTA_BANCARIA", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._NUMERO_CUENTA_BANCARIA
            sqlParametro = .Parameters.Add("@TELEFONO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._TELEFONO
            sqlParametro = .Parameters.Add("@ESTATUS_CUENTA_BANCARIA", SqlDbType.Char, 1) : sqlParametro.Value = Me._ESTATUS_CUENTA_BANCARIA.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_BANCO", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._CODIGO_BANCO
            sqlParametro = .Parameters.Add("@FOLIO_CHEQUE", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_CHEQUE
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_PESOS", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_PESOS
            sqlParametro = .Parameters.Add("@CUENTA_CONTABLE_DOLARES", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._CUENTA_CONTABLE_DOLARES
            sqlParametro = .Parameters.Add("@NOMBRE_FORMATO", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._NOMBRE_FORMATO.ToUpper
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = "INSERTAR"
            sqlParametro = .Parameters.Add("@CODIGO_PROVEEDOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_PROVEEDOR
            sqlParametro = .Parameters.Add("@CODIGO_MONEDA", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_MONEDA)
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._ID_CUENTA_BANCARIA = CType(.Parameters("@ID_CUENTA_BANCARIA").Value, Integer)
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
    ''' Devuelve un datatable con todos los registros de la tabla
    ''' </summary>
    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim ds As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            ds.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            ds.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosN() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT ID_CUENTA_BANCARIA,NOMBRE_CUENTA_BANCARIA FROM CAT_CUENTAS_BANCARIAS", Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosN", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String, ByVal Estatus As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT ID_CUENTA_BANCARIA,NOMBRE_CUENTA_BANCARIA FROM CAT_CUENTAS_BANCARIAS WHERE NOMBRE_CUENTA_BANCARIA LIKE '" & Filtro.ToString & "%' AND ESTATUS_CUENTA_BANCARIA='" & Estatus & "' ORDER BY NOMBRE_CUENTA_BANCARIA", Me._Conexion)
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
        f.Text = "Búsqueda de Cuentas_Bancarias por Código."
        f.sCampo = "ID_Cuenta_Bancaria"
        f.sOrder = "NOMBRE_Cuenta_Bancaria"
        f.sTable = "CAT_CUENTAS_BANCARIAS"
        f.sQl = "Select ID_Cuenta_Bancaria,NOMBRE_Cuenta_Bancaria From CAT_CUENTAS_BANCARIAS Where 1=1 And"
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

    ''' <summary>
    ''' Despliega la búsqueda visual por descripción.
    ''' </summary>
    Public Overrides Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Cuentas_Bancarias por Descripción."
        f.sCampo = "NOMBRE_Cuenta_Bancaria"
        f.sOrder = "NOMBRE_Cuenta_Bancaria"
        f.sTable = "CAT_CUENTAS_BANCARIAS"
        f.sQl = "Select ID_Cuenta_Bancaria,NOMBRE_Cuenta_Bancaria,CUENTA_CONTABLE_PESOS From CAT_CUENTAS_BANCARIAS Where 1=1 And"
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion", ex)
        End Try
        BusquedaVisual_PorDescripcion = Resultado
    End Function

#End Region

End Class



