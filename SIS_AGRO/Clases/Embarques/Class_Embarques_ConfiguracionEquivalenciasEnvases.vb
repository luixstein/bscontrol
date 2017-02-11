Imports System.Data
Imports System.Data.SqlClient

Public Class Class_Embarques_ConfiguracionEquivalenciasEnvases
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_CULTIVO As String
    Private _CODIGO_TIPO_ENVASE As Integer
    Private _EQUIVALENCIA As Double
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
    Public Property CODIGO_CULTIVO() As String
        Get
            Return Me._CODIGO_CULTIVO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CULTIVO = Value
        End Set
    End Property

    Public Property CODIGO_TIPO_ENVASE() As Integer
        Get
            Return Me._CODIGO_TIPO_ENVASE
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_TIPO_ENVASE = Value
        End Set
    End Property

    Public Property EQUIVALENCIA() As Double
        Get
            Return Me._EQUIVALENCIA
        End Get
        Set(ByVal Value As Double)
            Me._EQUIVALENCIA = Value
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
    'Public Property EStatus() As String
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
        Me._Nombre_Catalogo = "EMB_CONFIGURACION_EQUIVALENCIA_ENVASE"
        Me._Nombre_Reporte = "RPT_EMB_CONFIGURACION_EQUIVALENCIA_ENVASE"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT CODIGO_CULTIVO,CODIGO_TIPO_ENVASE,EQUIVALENCIA FROM EMB_CONFIGURACION_EQUIVALENCIA_ENVASE"
        Me._QueryOrder = " ORDER BY CODIGO_CULTIVO"
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
            .CommandText = "MP_EMB_CONFIGURACION_EQUIVALENCIA_ENVASE_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_CULTIVO", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_CULTIVO
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_ENVASE", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_TIPO_ENVASE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@EQUIVALENCIA", SqlDbType.Decimal) : sqlParametro.Value = Me._EQUIVALENCIA
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Insertar = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Actualizar", ex)
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
            .CommandText = "MP_EMB_CONFIGURACION_EQUIVALENCIA_ENVASE_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_CULTIVO", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_CULTIVO
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_ENVASE", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_TIPO_ENVASE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@EQUIVALENCIA", SqlDbType.Decimal) : sqlParametro.Value = Me._EQUIVALENCIA
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
        Dim cmd As New SqlCommand("Select * from EMB_CONFIGURACION_EQUIVALENCIA_ENVASE Where CODIGO_CULTIVO='" & Me._CODIGO_CULTIVO.ToString & "' AND CODIGO_TIPO_ENVASE=" & Me.CODIGO_TIPO_ENVASE.ToString & "", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_CULTIVO = "" & dReader("CODIGO_CULTIVO")
                    Me._CODIGO_TIPO_ENVASE = CType(dReader("CODIGO_TIPO_ENVASE"), Integer)
                    Me._EQUIVALENCIA = CType(dReader("EQUIVALENCIA"), Double)
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

    End Function        'Consulta un elemento del catálogo.

    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsEquivalencas As New SqlDataAdapter("Select E.CODIGO_CULTIVO,C.NOMBRE_CULTIVO AS CULTIVO,E.CODIGO_TIPO_ENVASE ,T.NOMBRE_TIPO_ENVASE AS ENVASE,E.EQUIVALENCIA FROM EMB_CONFIGURACION_EQUIVALENCIA_ENVASE E " & _
        "INNER JOIN CAT_CULTIVOS C ON(E.CODIGO_CULTIVO=C.CODIGO_CULTIVO) " & _
        "INNER JOIN CAT_TIPOS_ENVASES T ON(E.CODIGO_TIPO_ENVASE=T.CODIGO_TIPO_ENVASE)" & _
        "ORDER BY C.NOMBRE_CULTIVO,T.NOMBRE_TIPO_ENVASE", Me._Conexion)
        Try
            dsEquivalencas.Fill(dTable)

        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsEquivalencas.Dispose()
        End Try
        Return dTable
    End Function

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de tamaños por codigo."
        f.sCampo = "CODIGO_CULTIVO"
        f.sOrder = "CODIGO_TIPO_ENVASE"
        f.sTable = "EMB_CONFIGURACION_EQUIVALENCIA_ENVASE"
        f.sQl = "SELECT CODIGO_CULTIVO,CODIGO_TIPO_ENVASE FROM EMB_CONFIGURACION_EQUIVALENCIA_ENVASE WHERE 1=1 AND "
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
        f.Text = "Búsqueda de tamaños por Descripción."
        f.sCampo = "CODIGO_TIPO_ENVASE"
        f.sOrder = "CODIGO_TIPO_ENVASE"
        f.sTable = "EMB_CONFIGURACION_EQUIVALENCIA_ENVASE"
        f.sQl = "Select CODIGO_CULTIVO,CODIGO_TIPO_ENVASE FROM EMB_CONFIGURACION_EQUIVALENCIA_ENVASE Where 1=1 And"
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

    'Public Function CodigoSiguiente() As String
    '    Dim iTamaño As Integer, sTamaño As String
    '    Dim Resultado As String = ""
    '    Try
    '        Dim sql As New Class_find("SELECT ISNULL(MAX(CODIGO_CULTIVO),0)+1 FROM CAT_TAMAÑOS ")
    '        iTamaño = CInt(sql.Result1)
    '        sTamaño = "00" + iTamaño.ToString
    '        Resultado = sTamaño.Substring(Len(sTamaño) - 2)
    '    Catch ex As Exception
    '        HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion", ex)
    '    End Try
    '    Return Resultado
    'End Function

    Public Function ObtenerElementosFiltroCultivo(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable

        Dim dA As New SqlDataAdapter("Select E.CODIGO_CULTIVO,C.NOMBRE_CULTIVO AS CULTIVO,E.CODIGO_TIPO_ENVASE ,T.NOMBRE_TIPO_ENVASE AS ENVASE,E.EQUIVALENCIA  FROM EMB_CONFIGURACION_EQUIVALENCIA_ENVASE E " & _
        "INNER JOIN CAT_CULTIVOS C ON(E.CODIGO_CULTIVO=C.CODIGO_CULTIVO) " & _
        "INNER JOIN CAT_TIPOS_ENVASES T ON(E.CODIGO_TIPO_ENVASE=T.CODIGO_TIPO_ENVASE)" & _
        "WHERE C.NOMBRE_CULTIVO LIKE  '" & Filtro.ToString & "%' ORDER BY C.NOMBRE_CULTIVO,T.NOMBRE_TIPO_ENVASE", Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltroCultivo", ex)
        Finally
            dA.Dispose()
            End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltroNombreEnvase(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable

        Dim dA As New SqlDataAdapter("SELECT E.CODIGO_CULTIVO,C.NOMBRE_CULTIVO AS CULTIVO,E.CODIGO_TIPO_ENVASE ,T.NOMBRE_TIPO_ENVASE AS ENVASE,E.EQUIVALENCIA FROM EMB_CONFIGURACION_EQUIVALENCIA_ENVASE E " & _
        "INNER JOIN CAT_CULTIVOS C ON(E.CODIGO_CULTIVO=C.CODIGO_CULTIVO) " & _
        "INNER JOIN CAT_TIPOS_ENVASES T ON(E.CODIGO_TIPO_ENVASE=T.CODIGO_TIPO_ENVASE)" & _
        "WHERE T.NOMBRE_TIPO_ENVASE LIKE  '" & Filtro.ToString & "%' ORDER BY C.NOMBRE_CULTIVO,T.NOMBRE_TIPO_ENVASE", Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltroNombreEnvase", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
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
