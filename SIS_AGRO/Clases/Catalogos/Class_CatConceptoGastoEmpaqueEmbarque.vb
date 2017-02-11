Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatConceptoGastoEmpaqueEmbarque
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE As String
    Private _NOMBRE_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE As String
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
    Public Property CODIGO_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE() As String
        Get
            Return Me._CODIGO_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE = Value
        End Set
    End Property

    Public Property NOMBRE_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE() As String
        Get
            Return Me._NOMBRE_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE = Value
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
        Me._Nombre_Catalogo = "CAT_CONCEPTOS_GASTOS_EMPAQUE_EMBARQUE"
        Me._Nombre_Reporte = "RPT_CAT_CONCEPTOS_GASTOS_EMPAQUE_EMBARQUE.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select CODIGO_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE,NOMBRE_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE From CAT_CONCEPTOS_GASTOS_EMPAQUE_EMBARQUE"
        Me._QueryOrder = " Order by NOMBRE_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE"
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
            .CommandText = "MP_CAT_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE"

            sqlParametro = .Parameters.Add("@CODIGO_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._NOMBRE_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@Estatus", SqlDbType.Char, 1) : sqlParametro.Value = "A"
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
            .CommandText = "MP_CAT_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE"

            sqlParametro = .Parameters.Add("@CODIGO_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._NOMBRE_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
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
        Dim cmd As New SqlCommand("Select * from CAT_CONCEPTOS_GASTOS_EMPAQUE_EMBARQUE Where CODIGO_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE='" & Replace(Me._CODIGO_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE = "" & dReader("CODIGO_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE").ToString
                    Me._NOMBRE_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE = Trim("" & dReader("NOMBRE_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE").ToString)
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
        Dim dsCAT_Lineas As New SqlDataAdapter("SELECT CODIGO_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE, NOMBRE_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE FROM CAT_CONCEPTOS_GASTOS_EMPAQUE_EMBARQUE", Me._Conexion)
        Try
            dsCAT_Lineas.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCAT_Lineas.Dispose()
        End Try
        Return dTable
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable. 
    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT CODIGO_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE, NOMBRE_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE FROM CAT_CONCEPTOS_GASTOS_EMPAQUE_EMBARQUE WHERE NOMBRE_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE", Me._Conexion)
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
        '    Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        '    f.Text = "Búsqueda de empaque por codigo."
        '    f.sCampo = "Codigo_EMPAQUE"
        '    f.sOrder = "Nombre_EMPAQUE"
        '    f.sTable = "CAT_EMPAQUES"
        '    f.sQl = "Select Codigo_EMPAQUE,Nombre_EMPAQUE From CAT_EMPAQUES Where 1=1 And"
        '    f.Inicia("")
        '    f.ShowDialog()
        '    Try
        '        If f.iRows > 0 Then
        '            Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
        '        End If
        '    Catch ex As Exception
        '        HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorCodigo", ex)
        '    End Try
        Return Resultado
    End Function

    Public Overrides Function BusquedaVisual_PorDescripcion() As String
        '    Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        '    f.Text = "Búsqueda de Lineas por Descripción."
        '    f.sCampo = "Nombre_EMPAQUE"
        '    f.sOrder = "Nombre_EMPAQUE"
        '    f.sTable = "CAT_EMPAQUES"
        '    f.sQl = "Select Codigo_EMPAQUE,Nombre_EMPAQUE From CAT_EMPAQUES Where 1=1 And"
        '    f.Inicia("")
        '    f.ShowDialog()
        '    Try
        '        If f.iRows > 0 Then
        '            Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
        '        End If
        '    Catch ex As Exception
        '        HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion", ex)
        '    End Try
        Return Resultado
    End Function

    Public Function CodigoSiguiente() As String
        Dim iConcepto As Integer, sConcepto As String
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("SELECT MAX(CODIGO_CONCEPTO_GASTOS_EMBARQUE_EMPAQUE) FROM CAT_CONCEPTOS_GASTOS_EMPAQUE_EMBARQUE")
            iConcepto = CInt(sql.Result1)
            iConcepto = iConcepto + 1
            sConcepto = "0000" + iConcepto.ToString
            Resultado = sConcepto.Substring(Len(sConcepto) - 4)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
        End Try
        Return Resultado
    End Function


#End Region
End Class
