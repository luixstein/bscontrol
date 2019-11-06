Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatParametrosAcuicolaDetalle
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _Id_Cat_Parametros_Acuicola_Detalle As Integer
    Private _Codigo_Division As Integer
    Private _Codigo_Lote As String
    Private _Numero_canastas As Integer
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean
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
    Public Property Id_Cat_Parametros_Acuicola_Detalle() As Integer
        Get
            Return Me._Id_Cat_Parametros_Acuicola_Detalle
        End Get
        Set(ByVal Value As Integer)
            Me._Id_Cat_Parametros_Acuicola_Detalle = Value
        End Set
    End Property

    Public Property Codigo_Division() As Integer
        Get
            Return Me._Codigo_Division
        End Get
        Set(ByVal Value As Integer)
            Me._Codigo_Division = Value
        End Set
    End Property
    Public Property Codigo_Lote() As String
        Get
            Return Me._Codigo_Lote
        End Get
        Set(ByVal Value As String)
            Me._Codigo_Lote = Value
        End Set
    End Property

    Public Property Numero_Canastas() As Integer
        Get
            Return Me._Numero_canastas
        End Get
        Set(ByVal Value As Integer)
            Me._Numero_canastas = Value
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
        Me._Nombre_Catalogo = "CAT_PARAMETROS_ACUICOLA_DETALLE"
        Me._Nombre_Reporte = "RPT_CATALOGO_PARAMETROS_ACUICOLA_DETALLE"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * From CAT_PARAMETROS_ACUICOLA_DETALLE"
        Me._QueryOrder = " Order by codigo_lote"
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal sCodigoDivision As String, ByVal sCodigoLote As String)
        Me.New()
        Try
            Me._Codigo_Division = sCodigoDivision
            Me._Codigo_Lote = sCodigoLote
            If Me.Consultar = True Then
                Me._Existe = True

            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "New", ex)
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
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_PARAMETROS_ACUICOLA_DETALLE_GRABA"

            sqlParametro = .Parameters.Add("@ID_CAT_PARAMETROS_ACUICOLA_DETALLE", SqlDbType.Int) : sqlParametro.Value = 0
            sqlParametro = .Parameters.Add("@CODIGO_DIVISION", SqlDbType.SmallInt) : sqlParametro.Value = Me._Codigo_Division
            sqlParametro = .Parameters.Add("@CODIGO_LOTE", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._Codigo_Lote.ToUpper.ToString
            sqlParametro = .Parameters.Add("@NUMERO_CANASTAS", SqlDbType.SmallInt) : sqlParametro.Value = Me._Numero_canastas
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._Id_Cat_Parametros_Acuicola_Detalle = .Parameters("@ID_CAT_PARAMETROS_ACUICOLA_DETALLE").Value.ToString
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
            .CommandText = "MP_CAT_PARAMETROS_ACUICOLA_DETALLE_GRABA"

            sqlParametro = .Parameters.Add("@ID_CAT_PARAMETROS_ACUICOLA_DETALLE", SqlDbType.Int) : sqlParametro.Value = Me._Id_Cat_Parametros_Acuicola_Detalle
            sqlParametro = .Parameters.Add("@CODIGO_DIVISION", SqlDbType.SmallInt) : sqlParametro.Value = Me._Codigo_Division
            sqlParametro = .Parameters.Add("@CODIGO_LOTE", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._Codigo_Lote.ToUpper.ToString
            sqlParametro = .Parameters.Add("@NUMERO_CANASTAS", SqlDbType.SmallInt) : sqlParametro.Value = Me._Numero_canastas
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

    Public Overrides Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand("Select * from CAT_PARAMETROS_ACUICOLA_DETALLE Where Codigo_division =" & Replace(Me._Codigo_Division, "'", "''") & " and Codigo_Lote='" & Replace(Me._Codigo_Lote, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._Id_Cat_Parametros_Acuicola_Detalle = dReader("ID_CAT_PARAMETROS_ACUICOLA_DETALLE")
                    Me._Codigo_Division = dReader("CODIGO_DIVISION")
                    Me._Codigo_Lote = "" & dReader("CODIGO_LOTE").ToString
                    Me._Numero_canastas = CInt(dReader("NUMERO_CANASTAS"))
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

    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosParaReportes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
            dTable.Rows.Add("-1", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosParaReportes", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT P.CODIGO_DIVISION, D.NOMBRE_DIVISION,P.CODIGO_LOTE,L.NOMBRE_LOTE FROM CAT_PARAMETROS_ACUICOLA_DETALLE P INNER JOIN CAT_DIVISIONES_ACUICOLA D ON(P.CODIGO_DIVISION=D.CODIGO_DIVISION) " & _
                                     "INNER JOIN CAT_LOTES L ON(P.CODIGO_LOTE=L.CODIGO_LOTE) WHERE D.NOMBRE_DIVISION LIKE '" & Filtro.ToString & "%' ORDER BY D.NOMBRE_DIVISION", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de conceptos por codigo."
        f.sCampo = "Codigo_CONCEPTO"
        f.sOrder = "Nombre_CONCEPTO"
        f.sTable = "CAT_CONCEPTOS"
        f.sQl = "Select Codigo_CONCEPTO,Nombre_CONCEPTO From CAT_CONCEPTOS Where 1=1 And"
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
        f.Text = "Búsqueda de conceptos por nombre."
        f.sCampo = "Nombre_CONCEPTO"
        f.sOrder = "Nombre_CONCEPTO"
        f.sTable = "CAT_CONCEPTOS"
        f.sQl = "Select Codigo_CONCEPTO,Nombre_CONCEPTO From CAT_CONCEPTOS Where 1=1 And ESTATUS='A' AND "
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
#End Region

End Class