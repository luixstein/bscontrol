Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatAreas
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_AREA As Integer
    Private _NOMBRE_AREA As String
    Private _CALCULA_SINDICATO As String
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
    Public Property CODIGO_AREA() As Integer
        Get
            Return Me._CODIGO_AREA
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_AREA = Value
        End Set
    End Property

    Public Property NOMBRE_AREA() As String
        Get
            Return Me._NOMBRE_AREA
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_AREA = Value
        End Set
    End Property

    Public Property CALCULA_SINDICATO() As String
        Get
            Return Me._CALCULA_SINDICATO
        End Get
        Set(ByVal Value As String)
            Me._CALCULA_SINDICATO = Value
        End Set
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
        Me._Nombre_Catalogo = "NOMINA_CAT_AREAS"
        Me._Nombre_Reporte = "RPT_CATALOGO_NOMINA_AREAS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select CODIGO_AREA,NOMBRE_AREA From NOMINA_CAT_AREAS"
        Me._QueryOrder = " Order by NOMBRE_AREA"
    End Sub                                                         'Inicializa al objeto.

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
            .CommandText = "MP_NOMINA_CAT_AREAS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_AREA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_AREA
            sqlParametro = .Parameters.Add("@NOMBRE_AREA", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._NOMBRE_AREA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CALCULA_SINDICATO", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._CALCULA_SINDICATO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS_AREA", SqlDbType.Char, 1) : sqlParametro.Value = "A"
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = "INSERTAR"
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
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
            .CommandText = "MP_NOMINA_CAT_AREAS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_AREA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_AREA
            sqlParametro = .Parameters.Add("@NOMBRE_AREA", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._NOMBRE_AREA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CALCULA_SINDICATO", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._CALCULA_SINDICATO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS_AREA", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = "ACTUALIZAR"
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
    End Function                        'Actualiza un elemento del catálogo.

    Public Overrides Function Consultar() As Boolean
        Dim cmd As New SqlCommand("Select * from NOMINA_CAT_AREAS Where CODIGO_AREA='" & Replace(Me._CODIGO_AREA, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_AREA = "" & dReader("CODIGO_AREA").ToString
                    Me._NOMBRE_AREA = Trim("" & dReader("NOMBRE_AREA").ToString)
                    Me._CALCULA_SINDICATO = "" & dReader("CALCULA_SINDICATO").ToString
                    Me.Estatus = "" & dReader("ESTATUS_AREA").ToString
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
        Dim dsCat_PuntoPago As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            dsCat_PuntoPago.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCat_PuntoPago.Dispose()
        End Try
        Return dTable
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT CODIGO_AREA, NOMBRE_AREA FROM NOMINA_CAT_AREAS WHERE NOMBRE_AREA LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_AREA", Me._Conexion)
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
        f.Text = "Búsqueda de puntos de pago por codigo."
        f.sCampo = "CODIGO_AREA"
        f.sOrder = "NOMBRE_AREA"
        f.sTable = "NOMINA_CAT_AREAS"
        f.sQl = "Select CODIGO_AREA,NOMBRE_AREA From NOMINA_CAT_AREAS Where 1=1 And"
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
        f.Text = "Búsqueda de puntos de pago por descripción."
        f.sCampo = "NOMBRE_AREA"
        f.sOrder = "NOMBRE_AREA"
        f.sTable = "NOMINA_CAT_AREAS"
        f.sQl = "Select CODIGO_AREA,NOMBRE_AREA From NOMINA_CAT_AREAS Where 1=1 And"
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
        Dim iPuntoPago As Integer, sPuntoPago As String
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("SELECT ISNULL(MAX(CODIGO_AREA),0)+1 FROM NOMINA_CAT_AREAS ")
            iPuntoPago = CInt(sql.Result1)
            sPuntoPago = "0000" + iPuntoPago.ToString
            Resultado = sPuntoPago.Substring(Len(sPuntoPago) - 4)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion", ex)
        End Try
        Return Resultado
    End Function
#End Region
End Class
