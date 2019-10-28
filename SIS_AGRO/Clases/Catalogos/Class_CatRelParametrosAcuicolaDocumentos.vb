Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatRelParametrosAcuicolaDocumentos
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _Codigo_Tipo_Documento As String
    Private _Codigo_Parametro As String
    Private _Posicion As Integer
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
    Public Property Codigo_Tipo_Documento() As String
        Get
            Return Me._Codigo_Tipo_Documento
        End Get
        Set(ByVal Value As String)
            Me._Codigo_Tipo_Documento = Value
        End Set
    End Property

    Public Property Codigo_Parametro() As String
        Get
            Return Me._Codigo_Parametro
        End Get
        Set(ByVal Value As String)
            Me._Codigo_Parametro = Value
        End Set
    End Property

    Public Property Posicion() As Integer
        Get
            Return Me._Posicion
        End Get
        Set(ByVal Value As Integer)
            Me._Posicion = Value
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
        Me._Nombre_Catalogo = "CAT_REL_PARAMETROS_ACUICOLA_DOCUMENTOS"
        Me._Nombre_Reporte = "RPT_CATALOGO_REL_PARAMETROS_ACUICOLA_DOCUMENTOS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * From CAT_REL_PARAMETROS_ACUICOLA_DOCUMENTOS"
        Me._QueryOrder = " Order by Codigo_Tipo_Documento"
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal sCodigoTipoDocumento As String)
        Me.New()
        Try
            Me._Codigo_Tipo_Documento = sCodigoTipoDocumento
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
            .CommandText = "MP_CAT_REL_PARAMETROS_ACUICOLA_DOCUMENTOS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_TIPO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._Codigo_Tipo_Documento
            sqlParametro = .Parameters.Add("@CODIGO_PARAMETRO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._Codigo_Parametro)
            sqlParametro = .Parameters.Add("@POSICION", SqlDbType.SmallInt) : sqlParametro.Value = Me._Posicion
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._Codigo_Tipo_Documento = .Parameters("@CODIGO_TIPO_DOCUMENTO").Value.ToString
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
            .CommandText = "MP_CAT_REL_PARAMETROS_ACUICOLA_DOCUMENTOS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_TIPO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._Codigo_Tipo_Documento
            sqlParametro = .Parameters.Add("@CODIGO_PARAMETRO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._Codigo_Parametro)
            sqlParametro = .Parameters.Add("@POSICION", SqlDbType.SmallInt) : sqlParametro.Value = Me._Posicion
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

    Public Function Eliminar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_REL_PARAMETROS_ACUICOLA_DOCUMENTOS_ELIMINA"

            sqlParametro = .Parameters.Add("@CODIGO_TIPO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._Codigo_Tipo_Documento
            sqlParametro = .Parameters.Add("@CODIGO_PARAMETRO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._Codigo_Parametro)
            sqlParametro = .Parameters.Add("@POSICION", SqlDbType.SmallInt) : sqlParametro.Value = Me._Posicion
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Eliminar", ex)
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
        Dim cmd As New SqlCommand("Select CODIGO_TIPO_DOCUMENTO from Cat_Rel_Parametros_Acuicola_Documentos Where Codigo_Tipo_Documento='" & Replace(Me._Codigo_Tipo_Documento, "'", "''") & "' GROUP BY CODIGO_TIPO_DOCUMENTO", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._Codigo_Tipo_Documento = "" & dReader("CODIGO_TIPO_DOCUMENTO").ToString
                    'Me._Codigo_Parametro = "" & dReader("CODIGO_PARAMETRO").ToString
                    'Me._Posicion = dReader("POSICION")
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

    Public Function ObtenerDetalle(ByVal sCodigoTipoDocumento As String) As System.Data.DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String
        sSQL = "SELECT R.POSICION,R.CODIGO_PARAMETRO,P.NOMBRE_PARAMETRO FROM CAT_REL_PARAMETROS_ACUICOLA_DOCUMENTOS R " & _
        "INNER JOIN CAT_PARAMETROS_ACUICOLA P ON(R.CODIGO_PARAMETRO=P.CODIGO_PARAMETRO) WHERE R.CODIGO_TIPO_DOCUMENTO = '" & sCodigoTipoDocumento & "' ORDER BY R.POSICION "
        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerDetalle", ex)
        End Try
        Return dTabla
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
        Dim da As New SqlDataAdapter("SELECT R.CODIGO_TIPO_DOCUMENTO,MAX(D.NOMBRE_TIPO_DOCUMENTO) AS NOMBRE_TIPO_DOCUMENTO FROM CAT_REL_PARAMETROS_ACUICOLA_DOCUMENTOS R " & _
                                    "INNER JOIN SIS_TIPOS_DOCUMENTOS D ON(R.CODIGO_TIPO_DOCUMENTO=D.CODIGO_TIPO_DOCUMENTO) " & _
                                    "WHERE R.CODIGO_TIPO_DOCUMENTO LIKE '" & Filtro.ToString & "%' GROUP BY R.CODIGO_TIPO_DOCUMENTO ORDER BY R.CODIGO_TIPO_DOCUMENTO", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function BusquedaVisual_Docs_Acuicola_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de documentos por nombre."
        f.sCampo = "NOMBRE_TIPO_DOCUMENTO"
        f.sOrder = "NOMBRE_TIPO_DOCUMENTO"
        f.sTable = "SIS_TIPOS_DOCUMENTOS"
        f.sQl = "SELECT CODIGO_TIPO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM SIS_TIPOS_DOCUMENTOS WHERE 1=1 AND CODIGO_MODULO = 'ACU' AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_Docs_Acuicola_PorDescripcion", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_Docs_Acuicola_Porcodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de documentos por código."
        f.sCampo = "CODIGO_TIPO_DOCUMENTO"
        f.sOrder = "NOMBRE_TIPO_DOCUMENTO"
        f.sTable = "SIS_TIPOS_DOCUMENTOS"
        f.sQl = "SELECT CODIGO_TIPO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM SIS_TIPOS_DOCUMENTOS WHERE 1=1 AND CODIGO_MODULO = 'ACU' AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_Docs_Acuicola_Porcodigo", ex)
        End Try
        Return Resultado
    End Function

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de relaciones por codigo."
        f.sCampo = "Codigo_TIPO_DOCUMENTO"
        f.sOrder = "Nombre_CONCEPTO"
        f.sTable = "CAT_CONCEPTOS"
        f.sQl = "Select Codigo_CONCEPTO,Nombre_CONCEPTO From CAT_REL_PARAMETROS_ACUICOLA_DOCUMENTOS Where 1=1 And"
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
        f.Text = "Búsqueda de relaciones por nombre."
        f.sCampo = "Nombre_CONCEPTO"
        f.sOrder = "Nombre_CONCEPTO"
        f.sTable = "CAT_CONCEPTOS"
        f.sQl = "Select Codigo_CONCEPTO,Nombre_CONCEPTO From CAT_REL_PARAMETROS_ACUICOLA_DOCUMENTOS Where 1=1 And ESTATUS='A' AND "
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
        Dim Resultado As Integer
        Try
            Dim sql As New Class_find("SELECT MAX(CODIGO_CONCEPTO) FROM CAT_CONCEPTOS")
            Resultado = CType(sql.Result1, Integer) + 1
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
        End Try
        Return Resultado
    End Function
#End Region

End Class
