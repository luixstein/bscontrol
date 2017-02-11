Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatCajasTransportes
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_CAJA As String
    Private _NOMBRE_CAJA As String
    Private _PLACA As String
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

    Public Property CODIGO_CAJA() As String
        Get
            Return Me._CODIGO_CAJA
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CAJA = Value
        End Set
    End Property

    Public Property NOMBRE_CAJA() As String
        Get
            Return Me._NOMBRE_CAJA
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_CAJA = Value
        End Set
    End Property

    Public Property PLACA() As String
        Get
            Return Me._PLACA
        End Get
        Set(ByVal Value As String)
            Me._PLACA = Value
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

#End Region
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "CAT_CAJAS_TRANSPORTES"
        Me._Nombre_Reporte = "RPT_CATALOGO_CAJAS_TRANSPORTES"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT * FROM CAT_CAJAS_TRANSPORTES "
        Me._QueryOrder = " ORDER BY NOMBRE_CAJA"
    End Sub

    Public Sub New(ByVal sCodigoCaja As String)
        Me.New()
        Me._CODIGO_CAJA = sCodigoCaja
        Try
            If Me.Consultar = True Then
                Me._Existe = True
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
            .CommandText = "MP_CAT_CAJAS_TRANSPORTES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_CAJA", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_CAJA.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_CAJA", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._NOMBRE_CAJA.ToUpper
            sqlParametro = .Parameters.Add("@PLACA", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._PLACA.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
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
        f.sCampo = "CODIGO_CAJA"
        f.sOrder = "NOMBRE_CAJA"
        f.sTable = "CAT_CAJAS_TRANSPORTES"
        f.sQl = "SELECT CODIGO_CAJA, NOMBRE_CAJA FROM CAT_CAJAS_TRANSPORTES WHERE 1=1 AND CODIGO_PLAZA=" & Usuario.Codigo_Plaza & " AND"
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
        f.sCampo = "NOMBRE_CAJA"
        f.sOrder = "NOMBRE_CAJA"
        f.sTable = "CAT_CAJAS_TRANSPORTES"
        f.sQl = "SELECT CODIGO_CAJA, NOMBRE_CAJA,PLACA FROM CAT_CAJAS_TRANSPORTES WHERE 1=1 AND CODIGO_PLAZA=" & Usuario.Codigo_Plaza & " AND "
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
        Dim cmd As New SqlCommand(Me._QuerySelect & " Where CODIGO_CAJA='" & Replace(Me._CODIGO_CAJA, "'", "''") & "' AND CODIGO_PLAZA=" & Usuario.Codigo_Plaza, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_CAJA = dReader("CODIGO_CAJA").ToString()
                    Me._NOMBRE_CAJA = Trim("" & dReader("NOMBRE_CAJA").ToString())
                    Me._PLACA = dReader("PLACA").ToString()
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
            .CommandText = "MP_CAT_CAJAS_TRANSPORTES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_CAJA", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_CAJA.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_CAJA", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._NOMBRE_CAJA.ToUpper
            sqlParametro = .Parameters.Add("@PLACA", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._PLACA.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._CODIGO_CAJA = .Parameters("@CODIGO_CAJA").Value.ToString
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
        Dim dsCatArticulos As New SqlDataAdapter("SELECT CODIGO_CAJA, NOMBRE_CAJA FROM CAT_CAJAS_TRANSPORTES WHERE CODIGO_PLAZA=" & Usuario.Codigo_Plaza & " ORDER BY NOMBRE_CAJA", Me._Conexion)
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
        Dim dA As New SqlDataAdapter("SELECT CODIGO_CAJA, NOMBRE_CAJA FROM CAT_CAJAS_TRANSPORTES WHERE NOMBRE_CAJA LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_CAJA", Me._Conexion)
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
        Dim iDistribuidor As Integer, sDistribuidor As String = ""
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("SELECT MAX(CODIGO_CAJA) FROM CAT_CAJAS_TRANSPORTES WHERE CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString)
            If sql.Result1 = "" Then
                iDistribuidor = 1
            Else
                If Usuario.Codigo_Plaza = 1 Then
                    iDistribuidor = CType(sql.Result1, Integer) + 1
                    sDistribuidor = "0000" + iDistribuidor.ToString
                    sDistribuidor = sDistribuidor.Substring(Len(sDistribuidor) - 4)
                Else
                    iDistribuidor = CInt(Strings.Right(sql.Result1, 3))
                    iDistribuidor = iDistribuidor + 1
                    sDistribuidor = "0000" + iDistribuidor.ToString
                    sDistribuidor = sDistribuidor.Substring(Len(sDistribuidor) - 3)
                    sDistribuidor = sql.Result1.Substring(0, sql.Result1.IndexOf("-")) + "-" + sDistribuidor


                    'iLineaTransporte = CInt(Strings.Right(sql.Result1, 3))
                    'iLineaTransporte = iLineaTransporte + 1
                    'sLineaTransporte = sql.Result1.Substring(0, sql.Result1.IndexOf("-"))
                    'sLineaTransporte = sLineaTransporte + "-" + sLineaTransporte.Substring(Len(iLineaTransporte.ToString) - 3)


                End If
            End If

            Resultado = sDistribuidor '.Substring(Len(sPRODUCTOR) - 4)

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion", ex)
        End Try
        CodigoSiguiente = Resultado
    End Function
#End Region
End Class
