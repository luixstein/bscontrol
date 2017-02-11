Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatActividades
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_ACTIVIDAD As Integer
    Private _NOMBRE_ACTIVIDAD As String
    Private _PROTEGIDO As String
    Private _ESTATUS_ACTIVIDAD As String
    Private _CODIGO_CONCEPTO_ACTIVIDAD As String
    Private _CODIGO_SUB_ACTIVIDAD As String
    Private _COSTO_JORNAL As Double
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
    Public Property CODIGO_ACTIVIDAD() As Integer
        Get
            Return Me._CODIGO_ACTIVIDAD
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_ACTIVIDAD = Value
        End Set
    End Property

    Public Property NOMBRE_ACTIVIDAD() As String
        Get
            Return Me._NOMBRE_ACTIVIDAD
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_ACTIVIDAD = Value
        End Set
    End Property

    Public Property PROTEGIDO() As String
        Get
            Return Me._PROTEGIDO
        End Get
        Set(ByVal Value As String)
            Me._PROTEGIDO = Value
        End Set
    End Property

    Public Property ESTATUS_ACTIVIDAD() As String
        Get
            Return Me._ESTATUS_ACTIVIDAD
        End Get
        Set(ByVal Value As String)
            Me._ESTATUS_ACTIVIDAD = Value
        End Set
    End Property

    Public Property CODIGO_CONCEPTO_ACTIVIDAD() As String
        Get
            Return Me._CODIGO_CONCEPTO_ACTIVIDAD
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CONCEPTO_ACTIVIDAD = Value
        End Set
    End Property

    Public Property CODIGO_SUB_ACTIVIDAD() As String
        Get
            Return Me._CODIGO_SUB_ACTIVIDAD
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_SUB_ACTIVIDAD = Value
        End Set
    End Property

    Public Property COSTO_JORNAL() As Double
        Get
            Return Me._COSTO_JORNAL
        End Get
        Set(ByVal Value As Double)
            Me._COSTO_JORNAL = Value
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
        Me._Nombre_Catalogo = "NOMINA_CAT_ACTIVIDADES"
        Me._Nombre_Reporte = "RPT_CATALOGO_NOMINA_ACTIVIDADES"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select CODIGO_ACTIVIDAD,NOMBRE_ACTIVIDAD,ESTATUS_ACTIVIDAD From NOMINA_CAT_ACTIVIDADES"
        Me._QueryOrder = " Order by NOMBRE_ACTIVIDAD"
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal iCodigo As Integer)
        Me.New()
        Me._CODIGO_ACTIVIDAD = iCodigo
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

#Region "Métodos y procedimientos"

    Public Overrides Function Insertar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_CAT_ACTIVIDADES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_ACTIVIDAD", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_ACTIVIDAD.ToString.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_ACTIVIDAD", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._NOMBRE_ACTIVIDAD.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS_ACTIVIDAD", SqlDbType.Char, 1) : sqlParametro.Value = "A"
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Usuario.Codigo_Plaza.ToString)
            sqlParametro = .Parameters.Add("@CODIGO_CONCEPTO_ACTIVIDAD", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._CODIGO_CONCEPTO_ACTIVIDAD
            sqlParametro = .Parameters.Add("@CODIGO_SUB_ACTIVIDAD", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._CODIGO_SUB_ACTIVIDAD
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = "INSERTAR"
            sqlParametro = .Parameters.Add("@COSTO_JORNAL", SqlDbType.Decimal) : sqlParametro.Value = Me._COSTO_JORNAL
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

    Public Overrides Function Actualizar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_NOMINA_CAT_ACTIVIDADES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_ACTIVIDAD", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_ACTIVIDAD
            sqlParametro = .Parameters.Add("@NOMBRE_ACTIVIDAD", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._NOMBRE_ACTIVIDAD.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS_ACTIVIDAD", SqlDbType.Char, 1) : sqlParametro.Value = Me._ESTATUS_ACTIVIDAD.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Usuario.Codigo_Plaza.ToString)
            sqlParametro = .Parameters.Add("@CODIGO_CONCEPTO_ACTIVIDAD", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._CODIGO_CONCEPTO_ACTIVIDAD
            sqlParametro = .Parameters.Add("@CODIGO_SUB_ACTIVIDAD", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._CODIGO_SUB_ACTIVIDAD
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = "ACTUALIZAR"
            sqlParametro = .Parameters.Add("@COSTO_JORNAL", SqlDbType.Decimal) : sqlParametro.Value = Me._COSTO_JORNAL
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

    Public Overrides Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand("Select * from NOMINA_CAT_ACTIVIDADES Where CODIGO_ACTIVIDAD='" & Replace(Me._CODIGO_ACTIVIDAD.ToString, "'", "''") & "' AND CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_ACTIVIDAD = CInt(dReader("CODIGO_ACTIVIDAD"))
                    Me._NOMBRE_ACTIVIDAD = Trim("" & dReader("NOMBRE_ACTIVIDAD").ToString)
                    Me.ESTATUS_ACTIVIDAD = "" & dReader("ESTATUS_ACTIVIDAD").ToString
                    Me._CODIGO_CONCEPTO_ACTIVIDAD = "" & dReader("CODIGO_CONCEPTO_ACTIVIDAD").ToString
                    Me._CODIGO_SUB_ACTIVIDAD = "" & dReader("CODIGO_SUB_ACTIVIDAD").ToString
                    Me._COSTO_JORNAL = CDbl("" & dReader("COSTO_JORNAL").ToString)
                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
        Return bResultado
    End Function

    Public Function ObtenerElementosActividad() As System.Data.DataTable
        Dim dTable As New DataTable

        Dim dsCat_Actividad As New SqlDataAdapter("Select CODIGO_CONCEPTO_ACTIVIDAD,NOMBRE_CONCEPTO_ACTIVIDAD from NOMINA_CAT_CONCEPTOS_ACTIVIDADES  " & "order by CODIGO_CONCEPTO_ACTIVIDAD", Me._Conexion)
        Try
            dsCat_Actividad.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosActividad", ex)
        Finally
            dsCat_Actividad.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerConceptosActividadesParaReportes() As System.Data.DataTable
        Dim dTable As New DataTable

        Dim dsCat_Actividad As New SqlDataAdapter("Select CODIGO_CONCEPTO_ACTIVIDAD,NOMBRE_CONCEPTO_ACTIVIDAD from NOMINA_CAT_CONCEPTOS_ACTIVIDADES  " & "order by NOMBRE_CONCEPTO_ACTIVIDAD", Me._Conexion)
        Try
            dsCat_Actividad.Fill(dTable)
            dTable.Rows.Add("T", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerConceptosActividadesParaReportes", ex)
        Finally
            dsCat_Actividad.Dispose()
        End Try
        Return dTable
    End Function

    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable

        Dim sEstatus As String = " where ESTATUS_ACTIVIDAD='A' "

        Dim dsCat_PuntoPago As New SqlDataAdapter(Me._QuerySelect & sEstatus & Me._QueryOrder, Me._Conexion)
        Try
            dsCat_PuntoPago.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCat_PuntoPago.Dispose()
        End Try
        Return dTable
    End Function
    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("Select CODIGO_ACTIVIDAD,NOMBRE_ACTIVIDAD from NOMINA_CAT_ACTIVIDADES WHERE NOMBRE_ACTIVIDAD LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_ACTIVIDAD", Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosSubActividades(Optional ByVal sCodigoConcepto As String = "") As System.Data.DataTable
        Dim dTable As New DataTable
        Dim scodigo As String = " where ESTATUS_ACTIVIDAD='A' "

        If txtLEN(sCodigoConcepto) = True Then
            scodigo = scodigo & " AND CODIGO_CONCEPTO_ACTIVIDAD='" & sCodigoConcepto & "' "
        End If

        Dim dsCat_PuntoPago As New SqlDataAdapter(Me._QuerySelect & scodigo & Me._QueryOrder, Me._Conexion)
        Try
            dsCat_PuntoPago.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCat_PuntoPago.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerSubActividadesParaReportes(ByVal sCodigoConcepto As String) As System.Data.DataTable
        Dim dTable As New DataTable

        Dim ds As New SqlDataAdapter("SELECT CODIGO_SUB_ACTIVIDAD,NOMBRE_ACTIVIDAD FROM NOMINA_CAT_ACTIVIDADES WHERE ESTATUS_ACTIVIDAD='A' AND CODIGO_CONCEPTO_ACTIVIDAD='" & sCodigoConcepto & "' ORDER BY NOMBRE_ACTIVIDAD", Me._Conexion)
        Try
            ds.Fill(dTable)
            dTable.Rows.Add("T", "TODAS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerSubActividadesParaReportes", ex)
        Finally
            ds.Dispose()
        End Try
        Return dTable
    End Function

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de puntos de pago por codigo."
        f.sCampo = "CODIGO_ACTIVIDAD"
        f.sOrder = "NOMBRE_ACTIVIDAD"
        f.sTable = "NOMINA_CAT_ACTIVIDADES"
        f.sQl = "Select CODIGO_ACTIVIDAD,NOMBRE_ACTIVIDAD From NOMINA_CAT_ACTIVIDADES Where 1=1 And CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " AND CODIGO_CONCEPTO_ACTIVIDAD='" & Me._CODIGO_CONCEPTO_ACTIVIDAD.ToString & "' AND ESTATUS_ACTIVIDAD='A' AND "
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
        Dim sCodigoConcepto As String = ""

        If txtLEN(Me._CODIGO_CONCEPTO_ACTIVIDAD) = True Then
            sCodigoConcepto = " AND CODIGO_CONCEPTO_ACTIVIDAD=" & Me._CODIGO_CONCEPTO_ACTIVIDAD.ToString
        End If

        f.Text = "Búsqueda de puntos de pago por descripción."
        f.sCampo = "NOMBRE_ACTIVIDAD"
        f.sOrder = "NOMBRE_ACTIVIDAD"
        f.sTable = "NOMINA_CAT_ACTIVIDADES"
        f.sQl = "Select CODIGO_ACTIVIDAD,NOMBRE_ACTIVIDAD From NOMINA_CAT_ACTIVIDADES Where 1=1 And CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & sCodigoConcepto & " AND ESTATUS_ACTIVIDAD='A' AND "
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
            Dim sql As New Class_find("SELECT ISNULL(MAX(CODIGO_ACTIVIDAD),0)+1 FROM NOMINA_CAT_ACTIVIDADES WHERE CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " ")
            iPuntoPago = CInt(sql.Result1)
            sPuntoPago = "000" + iPuntoPago.ToString
            Resultado = sPuntoPago.Substring(Len(sPuntoPago) - 3)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
        End Try
        Return Resultado
    End Function

    Public Function CodigoSiguienteSubActividad() As String
        Dim iPuntoPago As Integer, sPuntoPago As String
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("SELECT ISNULL(MAX(CODIGO_SUB_ACTIVIDAD),0) FROM NOMINA_CAT_ACTIVIDADES WHERE CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString & " and CODIGO_CONCEPTO_ACTIVIDAD='" & Me._CODIGO_CONCEPTO_ACTIVIDAD.ToString & "'")
            iPuntoPago = CInt(sql.Result1) + 1
            sPuntoPago = "000" + iPuntoPago.ToString
            Resultado = sPuntoPago.Substring(Len(sPuntoPago) - 3)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CodigoSiguienteSubActividad", ex)
        End Try
        Return Resultado
    End Function
#End Region

End Class
