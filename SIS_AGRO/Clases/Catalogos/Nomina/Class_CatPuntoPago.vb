Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatPuntoPago
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_PUNTO_PAGO As Integer
    Private _NOMBRE_PUNTO_PAGO As String
    Private _CODIGO_PLAZA As Integer
    Private _ESTATUS_PUNTO_PAGO As String
    Private _DESDE As String
    Private _HASTA As String
    Private _CODIGO_TRABAJADOR_SIGUIENTE As String
    Private _GENERA_EFECTIVO_DENOMINACIONES As String
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
    Public Property CODIGO_PUNTO_PAGO() As Integer
        Get
            Return Me._CODIGO_PUNTO_PAGO
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_PUNTO_PAGO = Value
        End Set
    End Property

    Public Property NOMBRE_PUNTO_PAGO() As String
        Get
            Return Me._NOMBRE_PUNTO_PAGO
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_PUNTO_PAGO = Value
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

    Public Property ESTATUS_PUNTO_PAGO() As String
        Get
            Return Me._ESTATUS_PUNTO_PAGO
        End Get
        Set(ByVal Value As String)
            Me._ESTATUS_PUNTO_PAGO = Value
        End Set
    End Property

    Public Property DESDE() As String
        Get
            Return Me._DESDE
        End Get
        Set(ByVal Value As String)
            Me._DESDE = Value
        End Set
    End Property

    Public Property HASTA() As String
        Get
            Return Me._HASTA
        End Get
        Set(ByVal Value As String)
            Me._HASTA = Value
        End Set
    End Property

    Public Property CODIGO_TRABAJADOR_SIGUIENTE() As String
        Get
            Return Me._CODIGO_TRABAJADOR_SIGUIENTE
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_TRABAJADOR_SIGUIENTE = Value
        End Set
    End Property

    Public Property GENERA_EFECTIVO_DENOMINACIONES() As String
        Get
            Return Me._GENERA_EFECTIVO_DENOMINACIONES
        End Get
        Set(ByVal Value As String)
            Me._GENERA_EFECTIVO_DENOMINACIONES = Value
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
        Me._Nombre_Catalogo = "NOMINA_CAT_PUNTOS_PAGO"
        Me._Nombre_Reporte = "RPT_CATALOGO_NOMINA_PUNTOS_PAGO"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * From NOMINA_CAT_PUNTOS_PAGO"
        Me._QueryOrder = " Order by NOMBRE_PUNTO_PAGO"
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
            .CommandText = "MP_NOMINA_CAT_PUNTOS_PAGO_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_PUNTO_PAGO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PUNTO_PAGO
            sqlParametro = .Parameters.Add("@NOMBRE_PUNTO_PAGO", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._NOMBRE_PUNTO_PAGO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.Char, 1) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@ESTATUS_PUNTO_PAGO", SqlDbType.Char, 1) : sqlParametro.Value = "A"
            sqlParametro = .Parameters.Add("@DESDE", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._DESDE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@HASTA", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._HASTA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_TRABAJADOR_SIGUIENTE", SqlDbType.NVarChar, 10) : sqlParametro.Value = "0" 'Me._CODIGO_TRABAJADOR_SIGUIENTE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@GENERA_EFECTIVO_DENOMINACIONES", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._GENERA_EFECTIVO_DENOMINACIONES.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PUNTO_PAGO_LIGADO", SqlDbType.SmallInt) : sqlParametro.Value = 0 '"Me._CODIGO_PUNTO_PAGO
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
            .CommandText = "MP_NOMINA_CAT_PUNTOS_PAGO_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_PUNTO_PAGO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PUNTO_PAGO
            sqlParametro = .Parameters.Add("@NOMBRE_PUNTO_PAGO", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._NOMBRE_PUNTO_PAGO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.Char, 1) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@ESTATUS_PUNTO_PAGO", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@DESDE", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._DESDE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@HASTA", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._HASTA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_TRABAJADOR_SIGUIENTE", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_TRABAJADOR_SIGUIENTE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@GENERA_EFECTIVO_DENOMINACIONES", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me._GENERA_EFECTIVO_DENOMINACIONES.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PUNTO_PAGO_LIGADO", SqlDbType.SmallInt) : sqlParametro.Value = 0 '"Me._CODIGO_PUNTO_PAGO
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
        Dim cmd As New SqlCommand("Select * from NOMINA_CAT_PUNTOS_PAGO Where CODIGO_PUNTO_PAGO='" & Replace(Me._CODIGO_PUNTO_PAGO, "'", "''") & "' AND CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA.ToString, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_PUNTO_PAGO = "" & dReader("CODIGO_PUNTO_PAGO").ToString
                    Me._NOMBRE_PUNTO_PAGO = Trim("" & dReader("NOMBRE_PUNTO_PAGO").ToString)
                    Me.Estatus = "" & dReader("ESTATUS_PUNTO_PAGO").ToString
                    Me._CODIGO_PLAZA = CInt(dReader("CODIGO_PLAZA").ToString)
                    Me._DESDE = Trim("" & dReader("DESDE").ToString)
                    Me._HASTA = "" & dReader("HASTA").ToString
                    Me._CODIGO_TRABAJADOR_SIGUIENTE = "" & dReader("CODIGO_TRABAJADOR_SIGUIENTE").ToString
                    Me._GENERA_EFECTIVO_DENOMINACIONES = Trim("" & dReader("GENERA_EFECTIVO_DENOMINACIONES").ToString)
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
        Dim dsCat_PuntoPago As New SqlDataAdapter(Me._QuerySelect & " Where 1=1 AND CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " " & Me._QueryOrder, Me._Conexion)
        Try
            dsCat_PuntoPago.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCat_PuntoPago.Dispose()
        End Try
        Return dTable
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.

    Public Function ObtenerElementosParaReportes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCat_PuntoPago As New SqlDataAdapter(Me._QuerySelect & " Where 1=1 AND CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " " & Me._QueryOrder, Me._Conexion)
        Try
            dsCat_PuntoPago.Fill(dTable)
            dTable.Rows.Add("0", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCat_PuntoPago.Dispose()
        End Try
        Return dTable
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT CODIGO_PUNTO_PAGO, NOMBRE_PUNTO_PAGO FROM NOMINA_CAT_PUNTOS_PAGO WHERE CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " AND NOMBRE_PUNTO_PAGO LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_PUNTO_PAGO", Me._Conexion)
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
        f.sCampo = "CODIGO_PUNTO_PAGO"
        f.sOrder = "NOMBRE_PUNTO_PAGO"
        f.sTable = "NOMINA_CAT_PUNTOS_PAGO"
        f.sQl = "Select CODIGO_PUNTO_PAGO,NOMBRE_PUNTO_PAGO From NOMINA_CAT_PUNTOS_PAGO Where 1=1 AND CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " And"
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
        f.sCampo = "NOMBRE_PUNTO_PAGO"
        f.sOrder = "NOMBRE_PUNTO_PAGO"
        f.sTable = "NOMINA_CAT_PUNTOS_PAGO"
        f.sQl = "Select CODIGO_PUNTO_PAGO,NOMBRE_PUNTO_PAGO From NOMINA_CAT_PUNTOS_PAGO Where 1=1 AND CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " And "
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
            Dim sql As New Class_find("SELECT ISNULL(MAX(CODIGO_PUNTO_PAGO),0)+1 FROM NOMINA_CAT_PUNTOS_PAGO Where CODIGO_PUNTO_PAGO<>999")
            iPuntoPago = CInt(sql.Result1)
            sPuntoPago = "0000" + iPuntoPago.ToString
            Resultado = sPuntoPago.Substring(Len(sPuntoPago) - 4)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion", ex)
        End Try
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
