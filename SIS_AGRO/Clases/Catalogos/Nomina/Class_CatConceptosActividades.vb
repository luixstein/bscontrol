Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatConceptosActividades
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_CONCEPTO_ACTIVIDAD As String
    Private _NOMBRE_CONCEPTO_ACTIVIDAD As String
#End Region

#Region "Campos ligados a la tabla"
    Public _Existe As Boolean
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
    Public Property CODIGO_CONCEPTO_ACTIVIDAD() As String
        Get
            Return Me._CODIGO_CONCEPTO_ACTIVIDAD
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CONCEPTO_ACTIVIDAD = Value
        End Set
    End Property

    Public Property NOMBRE_CONCEPTO_ACTIVIDAD() As String
        Get
            Return Me._NOMBRE_CONCEPTO_ACTIVIDAD
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_CONCEPTO_ACTIVIDAD = Value
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
        Me._Nombre_Catalogo = "NOMINA_CAT_CONCEPTOS_ACTIVIDADES"
        Me._Nombre_Reporte = "RPT_CATALOGO_NOMINA_CONCEPTOS_ACTIVIDADES"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select CODIGO_CONCEPTO_ACTIVIDAD,NOMBRE_CONCEPTO_ACTIVIDAD,ESTATUS From NOMINA_CAT_CONCEPTOS_ACTIVIDADES"
        Me._QueryOrder = " Order by NOMBRE_CONCEPTO_ACTIVIDAD"
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal iCodigo As Integer)
        Me.New()
        Me._CODIGO_CONCEPTO_ACTIVIDAD = iCodigo
        Try
            If Me.Consultar = True Then
                Me._Existe = True
                'Else
                'Throw New Exception("La actividad no existe.")
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
            .CommandText = "MP_NOMINA_CAT_CONCEPTOS_ACTIVIDADES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_CONCEPTO_ACTIVIDAD", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._CODIGO_CONCEPTO_ACTIVIDAD.ToString.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_CONCEPTO_ACTIVIDAD", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._NOMBRE_CONCEPTO_ACTIVIDAD.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = "A"
            'sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Usuario.Codigo_Plaza.ToString)
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"
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
            .CommandText = "MP_NOMINA_CAT_CONCEPTOS_ACTIVIDADES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_CONCEPTO_ACTIVIDAD", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._CODIGO_CONCEPTO_ACTIVIDAD
            sqlParametro = .Parameters.Add("@NOMBRE_CONCEPTO_ACTIVIDAD", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._NOMBRE_CONCEPTO_ACTIVIDAD.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            'sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Usuario.Codigo_Plaza.ToString)
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
    End Function                        'Actualiza un elemento del catálogo.

    Public Overrides Function Consultar() As Boolean
        Dim cmd As New SqlCommand("Select * from NOMINA_CAT_CONCEPTOS_ACTIVIDADES Where CODIGO_CONCEPTO_ACTIVIDAD='" & Replace(Me._CODIGO_CONCEPTO_ACTIVIDAD, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_CONCEPTO_ACTIVIDAD = "" & dReader("CODIGO_CONCEPTO_ACTIVIDAD").ToString
                    Me._NOMBRE_CONCEPTO_ACTIVIDAD = Trim("" & dReader("NOMBRE_CONCEPTO_ACTIVIDAD").ToString)
                    Me.Estatus = "" & dReader("ESTATUS").ToString
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
        Dim dA As New SqlDataAdapter("SELECT CODIGO_CONCEPTO_ACTIVIDAD, NOMBRE_CONCEPTO_ACTIVIDAD FROM NOMINA_CAT_CONCEPTOS_ACTIVIDADES WHERE NOMBRE_CONCEPTO_ACTIVIDAD LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_CONCEPTO_ACTIVIDAD", Me._Conexion)
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
        f.sCampo = "CODIGO_CONCEPTO_ACTIVIDAD"
        f.sOrder = "NOMBRE_CONCEPTO_ACTIVIDAD"
        f.sTable = "NOMINA_CAT_CONCEPTOS_ACTIVIDADES"
        f.sQl = "Select CODIGO_CONCEPTO_ACTIVIDAD,NOMBRE_CONCEPTO_ACTIVIDAD From NOMINA_CAT_CONCEPTOS_ACTIVIDADES Where 1=1 AND " 'And CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " AND
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
        f.sCampo = "NOMBRE_CONCEPTO_ACTIVIDAD"
        f.sOrder = "NOMBRE_CONCEPTO_ACTIVIDAD"
        f.sTable = "NOMINA_CAT_CONCEPTOS_ACTIVIDADES"
        f.sQl = "Select CODIGO_CONCEPTO_ACTIVIDAD,NOMBRE_CONCEPTO_ACTIVIDAD From NOMINA_CAT_CONCEPTOS_ACTIVIDADES Where 1=1  " 'And CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " AND
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
            Dim sql As New Class_find("SELECT ISNULL(MAX(CODIGO_CONCEPTO_ACTIVIDAD),0)+1 FROM NOMINA_CAT_CONCEPTOS_ACTIVIDADES ") ' WHERE CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " 
            iPuntoPago = CInt(sql.Result1)
            sPuntoPago = "000" + iPuntoPago.ToString
            Resultado = sPuntoPago.Substring(Len(sPuntoPago) - 3)
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
