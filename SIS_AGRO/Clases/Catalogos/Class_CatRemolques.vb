Option Strict On

Imports System.Data.SqlClient

Public Class Class_CatRemolques
#Region "Campos"
#Region "Campos de la tabla"
    Private _CODIGO_REMOLQUE As String
    Private _NOMBRE_REMOLQUE As String
    Private _CODIGO_TIPO_REMOLQUE As String
    Private _PLACA As String
    Private _ESTATUS As String
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

    Public Property CODIGO_TIPO_REMOLQUE() As String
        Get
            Return Me._CODIGO_TIPO_REMOLQUE
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_TIPO_REMOLQUE = VALUE
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

    Public Property ESTATUS() As String
        Get
            Return Me._ESTATUS
        End Get
        Set(ByVal VALUE As String)
            Me._ESTATUS = VALUE
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
    End Sub

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

#Region "Métodos y procedimientos"
    Public Function Grabar(ByVal bAgregar As Boolean) As Boolean
        Const sProcedure As String = "Grabar"
        Dim bResultado As Boolean = False
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
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me._ESTATUS.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_CREO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(CODIGO_USUARIO_CREO)
            sqlParametro = .Parameters.Add("@FECHA_CREO", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_CREO
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_MODIFICO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_USUARIO_MODIFICO)
            sqlParametro = .Parameters.Add("@FECHA_MODIFICO", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_MODIFICO
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(bAgregar).ToString
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()

                If bAgregar = True Then
                    Me._CODIGO_REMOLQUE = .Parameters("@CODIGO_REMOLQUE").Value.ToString
                End If

                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, sProcedure, ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function Consultar() As Boolean
        Const sProcedure As String = "Consultar"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand("SELECT * FROM CAT_REMOLQUES " &
                                  " WHERE CODIGO_REMOLQUE='" & Replace(Me._CODIGO_REMOLQUE, "'", "''") & "' ", Me._Conexion)
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
                    Me._ESTATUS = "" & dReader("ESTATUS").ToString
                    Me._CODIGO_USUARIO_CREO = "" & dReader("CODIGO_USUARIO_CREO").ToString
                    Me._FECHA_CREO = CDate(dReader("FECHA_CREO").ToString)
                    Me._CODIGO_USUARIO_MODIFICO = "" & dReader("CODIGO_USUARIO_MODIFICO").ToString
                    If Not (IsDBNull(dReader("FECHA_MODIFICO"))) Then Me._FECHA_MODIFICO = CDate(dReader("FECHA_MODIFICO"))

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, sProcedure, ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
        Return bResultado
    End Function

    Public Function ObtenerElementos() As System.Data.DataTable
        Const sProcedure As String = "ObtenerElementos"
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_REMOLQUE,NOMBRE_REMOLQUE,PLACA FROM CAT_REMOLQUES ORDER BY PLACA", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Const sProcedure As String = "ObtenerElementosFiltro"
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_REMOLQUE,NOMBRE_REMOLQUE,PLACA FROM CAT_REMOLQUES WHERE NOMBRE_REMOLQUE LIKE '" & Filtro.ToString & "%' ORDER BY PLACA", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function BusquedaVisual_PorCodigo() As String
        Const sProcedure As String = "BusquedaVisual_PorCodigo"
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de remolques por código."
        f.sCampo = "CODIGO_REMOLQUE"
        f.sOrder = "NOMBRE_REMOLQUE"
        f.sTable = "CAT_REMOLQUES"
        f.sQl = "Select CODIGO_REMOLQUE,NOMBRE_REMOLQUE,PLACA FROM CAT_REMOLQUES WHERE 1=1 AND "
        f.Inicia("%")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, sProcedure, ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_PorDescripcion() As String
        Const sProcedure As String = "BusquedaVisual_PorDescripcion"
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de remolques por descripción."
        f.sCampo = "NOMBRE_REMOLQUE "
        f.sOrder = "NOMBRE_REMOLQUE"
        f.sTable = "CAT_REMOLQUES"
        f.sQl = "SELECT CODIGO_REMOLQUE,NOMBRE_REMOLQUE,PLACA FROM CAT_REMOLQUES Where 1=1 AND "
        f.Inicia("%")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, sProcedure, ex)
        End Try
        Return Resultado
    End Function

    Public Function CodigoSiguiente() As String
        Const sProcedure As String = "CodigoSiguiente"
        Dim Resultado As Integer
        Try
            Dim sql As New Class_find("SELECT ISNULL(MAX(CODIGO_REMOLQUE),0) FROM CAT_REMOLQUES")
            Resultado = CType(sql.Result1, Integer) + 1
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, sProcedure, ex)
        End Try
        Return Resultado.ToString
    End Function
#End Region

End Class
