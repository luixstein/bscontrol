Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatDistribuidores
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_DISTRIBUIDOR As String
    Private _NOMBRE_DISTRIBUIDOR As String
    Private _DOMICILIO As String
    Private _CIUDAD As String
    Private _ESTADO As String
    Private _OBSERVACION1 As String
    Private _OBSERVACION2 As String
    Private _OBSERVACION3 As String
    Private _ESTATUS As String

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

    Public Property CODIGO_DISTRIBUIDOR() As String
        Get
            Return Me._CODIGO_DISTRIBUIDOR
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_DISTRIBUIDOR = Value
        End Set
    End Property

    Public Property NOMBRE_DISTRIBUIDOR() As String
        Get
            Return Me._NOMBRE_DISTRIBUIDOR
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_DISTRIBUIDOR = Value
        End Set
    End Property

    Public Property DOMICILIO() As String
        Get
            Return Me._DOMICILIO
        End Get
        Set(ByVal Value As String)
            Me._DOMICILIO = Value
        End Set
    End Property

    Public Property CIUDAD() As String
        Get
            Return Me._CIUDAD
        End Get
        Set(ByVal Value As String)
            Me._CIUDAD = Value
        End Set
    End Property

    Public Property ESTADO() As String
        Get
            Return Me._ESTADO
        End Get
        Set(ByVal Value As String)
            Me._ESTADO = Value
        End Set
    End Property

    Public Property OBSERVACION1() As String
        Get
            Return Me._OBSERVACION1
        End Get
        Set(ByVal Value As String)
            Me._OBSERVACION1 = Value
        End Set
    End Property

    Public Property OBSERVACION2() As String
        Get
            Return Me._OBSERVACION2
        End Get
        Set(ByVal Value As String)
            Me._OBSERVACION2 = Value
        End Set
    End Property

    Public Property OBSERVACION3() As String
        Get
            Return Me._OBSERVACION3
        End Get
        Set(ByVal Value As String)
            Me._OBSERVACION3 = Value
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
        Me._Nombre_Catalogo = "CAT_DISTRIBUIDORES"
        'Me._Nombre_Reporte = "RPT_CATALOGO_DISTRIBUIDORES.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT * FROM CAT_DISTRIBUIDORES "
        Me._QueryOrder = " ORDER BY NOMBRE_DISTRIBUIDOR"
    End Sub

    Public Sub New(ByVal sCodigoDistribuidor As String)
        Me.New()
        Me._CODIGO_DISTRIBUIDOR = sCodigoDistribuidor
        Try
            If Me.Consultar = True Then
                Me._Existe = True
                'Else
                '    Throw New Exception("El distribuidor no existe.")
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
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_DISTRIBUIDORES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_DISTRIBUIDOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_DISTRIBUIDOR.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_DISTRIBUIDOR", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._NOMBRE_DISTRIBUIDOR.ToUpper
            sqlParametro = .Parameters.Add("@DOMICILIO", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._DOMICILIO.ToUpper
            sqlParametro = .Parameters.Add("@CIUDAD", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._CIUDAD.ToUpper
            sqlParametro = .Parameters.Add("@ESTADO", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._ESTADO.ToUpper
            sqlParametro = .Parameters.Add("@OBSERVACION1", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._OBSERVACION1.ToUpper
            sqlParametro = .Parameters.Add("@OBSERVACION2", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._OBSERVACION2.ToUpper
            sqlParametro = .Parameters.Add("@OBSERVACION3", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._OBSERVACION3.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
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
    End Function

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de distribuidor por Código."
        f.sCampo = "CODIGO_DISTRIBUIDOR"
        f.sOrder = "NOMBRE_DISTRIBUIDOR"
        f.sTable = "CAT_DISTRIBUIDORES"
        f.sQl = "SELECT CODIGO_DISTRIBUIDOR, NOMBRE_DISTRIBUIDOR FROM CAT_DISTRIBUIDORES WHERE 1=1 AND"
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
        f.Text = "Búsqueda de distribuidor por Nombre."
        f.sCampo = "NOMBRE_DISTRIBUIDOR"
        f.sOrder = "NOMBRE_DISTRIBUIDOR"
        f.sTable = "CAT_DISTRIBUIDORES"
        f.sQl = "SELECT CODIGO_DISTRIBUIDOR, NOMBRE_DISTRIBUIDOR FROM CAT_DISTRIBUIDORES WHERE 1=1 AND"
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorNombre", ex)
        End Try
        Return Resultado
    End Function

    Public Overrides Function Consultar() As Boolean
        Dim cmd As New SqlCommand(Me._QuerySelect & " Where CODIGO_DISTRIBUIDOR='" & Replace(Me._CODIGO_DISTRIBUIDOR, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_DISTRIBUIDOR = dReader("CODIGO_DISTRIBUIDOR").ToString()
                    Me._NOMBRE_DISTRIBUIDOR = Trim("" & dReader("NOMBRE_DISTRIBUIDOR").ToString())
                    Me._DOMICILIO = dReader("DOMICILIO").ToString()
                    Me._CIUDAD = "" & dReader("CIUDAD").ToString()
                    Me._ESTADO = dReader("ESTADO").ToString()
                    Me._OBSERVACION1 = dReader("OBSERVACION1").ToString()
                    Me._OBSERVACION2 = dReader("OBSERVACION2").ToString()
                    Me._OBSERVACION3 = dReader("OBSERVACION3").ToString()
                    Me.Estatus = "" & dReader("ESTATUS").ToString()

                    Consultar = True
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

    Public Overrides Function Insertar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_DISTRIBUIDORES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_DISTRIBUIDOR", SqlDbType.NVarChar, 8) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = Me._CODIGO_DISTRIBUIDOR
            sqlParametro = .Parameters.Add("@NOMBRE_DISTRIBUIDOR", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._NOMBRE_DISTRIBUIDOR.ToUpper
            sqlParametro = .Parameters.Add("@DOMICILIO", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._DOMICILIO.ToUpper
            sqlParametro = .Parameters.Add("@CIUDAD", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._CIUDAD.ToUpper
            sqlParametro = .Parameters.Add("@ESTADO", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._ESTADO.ToUpper
            sqlParametro = .Parameters.Add("@OBSERVACION1", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._OBSERVACION1.ToUpper
            sqlParametro = .Parameters.Add("@OBSERVACION2", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._OBSERVACION2.ToUpper
            sqlParametro = .Parameters.Add("@OBSERVACION3", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._OBSERVACION3.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me.Estatus.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._CODIGO_DISTRIBUIDOR = .Parameters("@CODIGO_DISTRIBUIDOR").Value.ToString
                Insertar = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Insertar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

    End Function

    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCatArticulos As New SqlDataAdapter("SELECT CODIGO_DISTRIBUIDOR, NOMBRE_DISTRIBUIDOR FROM CAT_DISTRIBUIDORES ORDER BY NOMBRE_DISTRIBUIDOR", Me._Conexion)
        Try
            dsCatArticulos.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCatArticulos.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT CODIGO_DISTRIBUIDOR, NOMBRE_DISTRIBUIDOR FROM CAT_DISTRIBUIDORES WHERE NOMBRE_DISTRIBUIDOR LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_DISTRIBUIDOR", Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
    End Function

    Public Function CodigoSiguiente() As String
        Dim iDistribuidor As Integer, sDistribuidor As String
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("SELECT MAX(CODIGO_DISTRIBUIDOR) FROM CAT_DISTRIBUIDORES")
            If sql.Result1 = "" Then
                iDistribuidor = 1
            Else
                iDistribuidor = CType(sql.Result1, Integer) + 1
            End If
            sDistribuidor = "0000" + iDistribuidor.ToString
            Resultado = sDistribuidor.Substring(Len(sDistribuidor) - 4)

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion", ex)
        End Try
        CodigoSiguiente = Resultado
    End Function
#End Region

End Class
