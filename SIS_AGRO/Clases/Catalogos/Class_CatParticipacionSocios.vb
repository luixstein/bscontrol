Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatParticipacionSocios
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_ARTICULO As String
    Private _CODIGO_USUARIO_SOCIO As Integer
    Private _CANTIDAD As Decimal
    Private _PORCENTAJE_PARTICIPACION As Decimal
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
    Private _QuerySELECT As String
    Private _QueryOrder As String

#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public Property CODIGO_ARTICULO() As String
        Get
            Return Me._CODIGO_ARTICULO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_ARTICULO = Value
        End Set
    End Property

    Public Property CODIGO_USUARIO_SOCIO() As Integer
        Get
            Return Me._CODIGO_USUARIO_SOCIO
        End Get
        Set(value As Integer)
            Me._CODIGO_USUARIO_SOCIO = value
        End Set
    End Property

    Public Property CANTIDAD() As Decimal
        Get
            Return Me._CANTIDAD
        End Get
        Set(ByVal Value As Decimal)
            Me._CANTIDAD = Value
        End Set
    End Property

    Public Property PORCENTAJE_PARTICIPACION() As Decimal
        Get
            Return Me._PORCENTAJE_PARTICIPACION
        End Get
        Set(value As Decimal)
            Me._PORCENTAJE_PARTICIPACION = value
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

    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property

#End Region

#End Region

#Region "Constructor y destructor"

    Public Sub New()
        Me._Nombre_Catalogo = "CAT_PARTICIPACION_SOCIOS"
        Me._Nombre_Reporte = "RPT_CATALOGO_PARTICIPACION_SOCIOS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySELECT = "SELECT CODIGO_ARTICULO,CODIGO_USUARIO_SOCIO,CANTIDAD,PORCENTAJE_PARTICIPACION FROM CAT_PARTICIPACION_SOCIOS"
        Me._QueryOrder = " Order by CODIGO_ARTICULO"
    End Sub

    Public Sub New(ByVal sCodigoArticulo As String)
        Me.New()
        Try
            Me.CODIGO_ARTICULO = sCodigoArticulo
            If Me.Consultar = True Then
                Me._Existe = True
                'Throw New Exception("La fórmula no existe.")
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

    Public Function Grabar(Optional ByVal sEliminar As String = "0") As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_PARTICIPACION_SOCIOS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CODIGO_ARTICULO.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_SOCIO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_USUARIO_SOCIO
            sqlParametro = .Parameters.Add("@CANTIDAD", SqlDbType.Decimal) : sqlParametro.Value = Me._CANTIDAD
            sqlParametro = .Parameters.Add("@PORCENTAJE_PARTICIPACION", SqlDbType.Decimal) : sqlParametro.Value = Me._PORCENTAJE_PARTICIPACION
            sqlParametro = .Parameters.Add("@ELIMINA", SqlDbType.Char, 1) : sqlParametro.Value = sEliminar

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True

            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Grabar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Overrides Function Insertar() As Boolean

    End Function
    Public Overrides Function Actualizar() As Boolean
        
    End Function

    Public Overrides Function Consultar() As Boolean
        'Dim bResultado As Boolean = False
        'Dim cmd As New SqlCommand("SELECT * FROM CAT_FORMULAS WHERE CODIGO_FORMULA=" & Me._CODIGO_FORMULA, Me._Conexion)
        'Dim dReader As SqlDataReader
        'With cmd
        '    .CommandTimeout = 0
        '    .CommandType = CommandType.Text
        '    Try
        '        Me._Conexion.Open()
        '        dReader = .ExecuteReader()

        '        If dReader.Read Then
        '            Me._CODIGO_FORMULA = "" & dReader("CODIGO_FORMULA").ToString
        '            Me._NOMBRE_FORMULA = Trim("" & dReader("NOMBRE_FORMULA").ToString)
        '            Me._CODIGO_ARTICULO = "" & dReader("CODIGO_ARTICULO").ToString
        '            Me.Estatus = "" & dReader("ESTATUS").ToString
        '            Me._PORCENTAJE_COSTO_PRODUCCION = dReader("PORCENTAJE_COSTO_PRODUCCION")
        '            Me._ES_CONFIDENCIAL = CBool(dReader("ES_CONFIDENCIAL"))
        '            bResultado = True
        '        End If
        '        dReader.Close()
        '    Catch ex As Exception
        '        HandleError(Me.Nombre_Catalogo, "Consultar", ex)
        '    Finally
        '        Me._Conexion.Close()
        '        cmd.Dispose()
        '    End Try
        'End With
        'Return bResultado
    End Function

    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCAT_FORMULAS As New SqlDataAdapter(Me._QuerySELECT & Me._QueryOrder, Me._Conexion)
        Try
            dsCAT_FORMULAS.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCAT_FORMULAS.Dispose()
        End Try
        Return dTable
    End Function

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Metodos de Fórmulas por codigo."
        f.sCampo = "CODIGO_FORMULA"
        f.sOrder = "NOMBRE_FORMULA"
        f.sTable = "CAT_FORMULAS"
        f.sQl = "SELECT CODIGO_FORMULA,NOMBRE_FORMULA FROM CAT_FORMULAS WHERE ESTATUS='A' And"
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
        f.Text = "Búsqueda de Fórmulas por Descripción."
        f.sCampo = "NOMBRE_FORMULA"
        f.sOrder = "NOMBRE_FORMULA"
        f.sTable = "CAT_FORMULAS"
        f.sQl = "SELECT CODIGO_FORMULA,NOMBRE_FORMULA FROM CAT_FORMULAS WHERE ESTATUS='A' And"
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

    Public Function ObtenerDetalle(ByVal sCodigoArticulo As String) As System.Data.DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String
        sSQL = "SELECT P.CODIGO_USUARIO_SOCIO,U.NOMBRE_USUARIO NOMBRE_SOCIO,P.CANTIDAD,P.PORCENTAJE_PARTICIPACION FROM CAT_PARTICIPACION_SOCIOS P INNER JOIN SIS_USUARIOS U ON(P.CODIGO_USUARIO_SOCIO=U.CODIGO_USUARIO) " & _
               "WHERE P.CODIGO_ARTICULO='" & sCodigoArticulo & "' ORDER BY U.NOMBRE_USUARIO "
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalle", ex)
        End Try
        Return dTabla
    End Function

#End Region

End Class



