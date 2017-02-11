Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatMarcasTransportes

    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_MARCA As String
    Private _MARCA As String
    Private _ESTATUS As String
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
    Public Property CODIGO_MARCA() As String
        Get
            Return Me._CODIGO_MARCA
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_MARCA = VALUE
        End Set
    End Property

    Public Property MARCA() As String
        Get
            Return Me._MARCA
        End Get
        Set(ByVal VALUE As String)
            Me._MARCA = VALUE
        End Set
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
        Me._Nombre_Catalogo = "CAT_MARCAS_TRANSPORTES"
        'Me._Nombre_Reporte = "RPT_CAT_LINEAS_TRANSPORTES.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * From CAT_MARCAS_TRANSPORTES"
        Me._QueryOrder = " Order by MARCA_TRANSPORTE"
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
            .CommandText = "MP_CAT_MARCAS_TRANSPORTE_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_MARCA", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_MARCA.ToUpper
            sqlParametro = .Parameters.Add("@MARCA_TRANSPORTE", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._MARCA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._CODIGO_MARCA = .Parameters("@CODIGO_MARCA").Value.ToString
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
            .CommandText = "MP_CAT_MARCAS_TRANSPORTE_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_MARCA", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_MARCA.ToUpper
            sqlParametro = .Parameters.Add("@MARCA_TRANSPORTE", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._MARCA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "0"
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._CODIGO_MARCA = .Parameters("@CODIGO_MARCA").Value.ToString
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
        Dim cmd As New SqlCommand("Select * from CAT_MARCAS_TRANSPORTES Where CODIGO_MARCA='" & Replace(Me._CODIGO_MARCA, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_MARCA = "" & dReader("CODIGO_MARCA").ToString
                    Me._MARCA = Trim("" & dReader("MARCA_TRANSPORTE").ToString)
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
        Dim dsCAT_Lineas As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
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
        Dim dA As New SqlDataAdapter("SELECT CODIGO_MARCA, MARCA_TRANSPORTE FROM CAT_MARCAS_TRANSPORTES WHERE MARCA_TRANSPORTE LIKE '" & Filtro.ToString & "%' ORDER BY MARCA_TRANSPORTE", Me._Conexion)
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
        f.Text = "Búsqueda por codigo."
        f.sCampo = "CODIGO_MARCA"
        f.sOrder = "MARCA_TRANSPORTE"
        f.sTable = "CAT_MARCAS_TRANSPORTES"
        f.sQl = "Select CODIGO_MARCA,MARCA_TRANSPORTE From CAT_MARCAS_TRANSPORTES Where 1=1 And"
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
        f.Text = "Búsqueda de Lineas por Descripción."
        f.sCampo = "MARCA_TRANSPORTE"
        f.sOrder = "MARCA_TRANSPORTE"
        f.sTable = "CAT_MARCAS_TRANSPORTES"
        f.sQl = "Select CODIGO_MARCA,MARCA_TRANSPORTE From CAT_MARCAS_TRANSPORTES Where 1=1 And"
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
        Dim iLineaTransporte As Integer, sLineaTransporte As String
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("SELECT MAX(CODIGO_MARCA) FROM CAT_MARCAS_TRANSPORTES")
            If sql.Result1 = "" Then
                iLineaTransporte = 1
            Else
                iLineaTransporte = CType(sql.Result1, Integer) + 1
            End If
            sLineaTransporte = "0000" + iLineaTransporte.ToString
            Resultado = sLineaTransporte.Substring(Len(sLineaTransporte) - 4)
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

