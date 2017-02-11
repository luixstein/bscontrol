Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatChoferes
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_CHOFER As String
    Private _NOMBRE_CHOFER As String
    Private _LICENCIA As String
    Private _VISA As String
    Private _RFC As String
    Private _DOMICILIO As String
    Private _ESTATUS As String
    Private _TELEFONO As String

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

    Public Property CODIGO_CHOFER() As String
        Get
            Return Me._CODIGO_CHOFER
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CHOFER = Value
        End Set
    End Property

    Public Property NOMBRE_CHOFER() As String
        Get
            Return Me._NOMBRE_CHOFER
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_CHOFER = Value
        End Set
    End Property

    Public Property LICENCIA() As String
        Get
            Return Me._LICENCIA
        End Get
        Set(ByVal Value As String)
            Me._LICENCIA = Value
        End Set
    End Property

    Public Property VISA() As String
        Get
            Return Me._VISA
        End Get
        Set(ByVal Value As String)
            Me._VISA = Value
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

    Public Property DOMICILIO() As String
        Get
            Return Me._DOMICILIO
        End Get
        Set(ByVal Value As String)
            Me._DOMICILIO = Value
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
    Public Property TELEFONO() As String
        Get
            Return Me._TELEFONO
        End Get
        Set(ByVal Value As String)
            Me._TELEFONO = Value
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

#End Region
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "CAT_CHOFERES"
        'Me._Nombre_Reporte = "RPT_CATALOGO_CHOFERES.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT * FROM CAT_CHOFERES "
        Me._QueryOrder = " ORDER BY NOMBRE_CHOFER"
    End Sub

    Public Sub New(ByVal sCodigoPRODUCTOR As String)
        Me.New()
        Me._CODIGO_CHOFER = sCodigoPRODUCTOR
        Try
            If Me.Consultar = True Then
                Me._Existe = True
                'Else
                '    Throw New Exception("El PRODUCTOR no existe.")
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
            .CommandText = "MP_CAT_CHOFERES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_CHOFER", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_CHOFER.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_CHOFER", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._NOMBRE_CHOFER.ToUpper
            sqlParametro = .Parameters.Add("@RFC", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._RFC.ToUpper
            sqlParametro = .Parameters.Add("@DOMICILIO", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._DOMICILIO.ToUpper
            sqlParametro = .Parameters.Add("@LICENCIA", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._LICENCIA.ToUpper
            sqlParametro = .Parameters.Add("@VISA", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._VISA.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@TELEFONO", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me.TELEFONO.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "0"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._CODIGO_CHOFER = .Parameters("@CODIGO_CHOFER").Value.ToString
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
        f.Text = "Búsqueda de CHOFER por Código."
        f.sCampo = "CODIGO_CHOFER"
        f.sOrder = "NOMBRE_CHOFER"
        f.sTable = "CAT_CHOFERES"
        f.sQl = "SELECT CODIGO_CHOFER, NOMBRE_CHOFER FROM CAT_CHOFERES WHERE 1=1 AND CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " AND"
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
        f.Text = "Búsqueda de CHOFER por Nombre."
        f.sCampo = "NOMBRE_CHOFER"
        f.sOrder = "NOMBRE_CHOFER"
        f.sTable = "CAT_CHOFERES"
        f.sQl = "SELECT CODIGO_CHOFER, NOMBRE_CHOFER FROM CAT_CHOFERES WHERE 1=1 AND  CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " AND"
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
        Dim cmd As New SqlCommand(Me._QuerySelect & " Where CODIGO_CHOFER='" & Replace(Me._CODIGO_CHOFER, "'", "''") & "'  AND CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_CHOFER = dReader("CODIGO_CHOFER").ToString()
                    Me._NOMBRE_CHOFER = dReader("NOMBRE_CHOFER").ToString()
                    Me._RFC = dReader("RFC").ToString()
                    Me._DOMICILIO = dReader("DOMICILIO").ToString()
                    Me._LICENCIA = dReader("LICENCIA").ToString()
                    Me._VISA = dReader("VISA").ToString()
                    Me._TELEFONO = "" & dReader("TELEFONO").ToString
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
            .CommandText = "MP_CAT_CHOFERES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_CHOFER", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_CHOFER.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_CHOFER", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._NOMBRE_CHOFER.ToUpper
            sqlParametro = .Parameters.Add("@LICENCIA", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._LICENCIA.ToUpper
            sqlParametro = .Parameters.Add("@VISA", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._VISA.ToUpper
            sqlParametro = .Parameters.Add("@RFC", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._RFC.ToUpper
            sqlParametro = .Parameters.Add("@DOMICILIO", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._DOMICILIO.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me.Estatus.ToUpper
            sqlParametro = .Parameters.Add("@TELEFONO", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me.TELEFONO.ToUpper.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._CODIGO_CHOFER = .Parameters("@CODIGO_CHOFER").Value.ToString
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
        Dim dsCatArticulos As New SqlDataAdapter("SELECT CODIGO_CHOFER, NOMBRE_CHOFER FROM CAT_CHOFERES WHERE CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " ORDER BY NOMBRE_CHOFER", Me._Conexion)
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
        Dim dA As New SqlDataAdapter("SELECT CODIGO_CHOFER, NOMBRE_CHOFER FROM CAT_CHOFERES WHERE CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " AND NOMBRE_CHOFER LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_CHOFER", Me._Conexion)
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
        Dim iPRODUCTOR As Integer, sPRODUCTOR As String = ""
        Dim Resultado As String = ""
        Try

            Dim sql As New Class_find("SELECT MAX(CODIGO_CHOFER) FROM CAT_CHOFERES WHERE CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString)
            If sql.Result1 = "" Then
                iPRODUCTOR = 1
            Else
                If Usuario.Codigo_Plaza = 1 Then
                    iPRODUCTOR = CType(sql.Result1, Integer) + 1
                    'sPRODUCTOR = iPRODUCTOR.ToString
                    sPRODUCTOR = "0000" + iPRODUCTOR.ToString
                    sPRODUCTOR = sPRODUCTOR.Substring(Len(sPRODUCTOR) - 4)
                Else
                    iPRODUCTOR = CInt(Strings.Right(sql.Result1, 3))
                    iPRODUCTOR = iPRODUCTOR + 1
                    sPRODUCTOR = "0000" + iPRODUCTOR.ToString
                    sPRODUCTOR = sPRODUCTOR.Substring(Len(sPRODUCTOR) - 3)
                    sPRODUCTOR = sql.Result1.Substring(0, sql.Result1.IndexOf("-")) + "-" + sPRODUCTOR
                End If

            End If

            Resultado = sPRODUCTOR '.Substring(Len(sPRODUCTOR) - 4)

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion", ex)
        End Try
        CodigoSiguiente = Resultado
    End Function
#End Region

End Class
