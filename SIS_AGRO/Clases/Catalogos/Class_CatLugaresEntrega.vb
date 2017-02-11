
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatLugaresEntrega

    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_LUGAR_ENTREGA As String
    Private _NOMBRE_LUGAR_ENTREGA As String
    Private _IMPORTE_FLETE As Decimal
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
    Public Property CODIGO_LUGAR_ENTREGA() As String
        Get
            Return Me._CODIGO_LUGAR_ENTREGA
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_LUGAR_ENTREGA = VALUE
        End Set
    End Property

    Public Property NOMBRE_LUGAR_ENTREGA() As String
        Get
            Return Me._NOMBRE_LUGAR_ENTREGA
        End Get
        Set(ByVal VALUE As String)
            Me._NOMBRE_LUGAR_ENTREGA = VALUE
        End Set
    End Property

    Public Property IMPORTE_FLETE() As Decimal
        Get
            Return Me._IMPORTE_FLETE
        End Get
        Set(ByVal value As Decimal)
            Me._IMPORTE_FLETE = value
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


#End Region

#End Region

#Region "Constructor y destructor"

    Public Sub New()
        Me._Nombre_Catalogo = "CAT_LUGARES_ENTREGA"
        Me._Nombre_Reporte = "RPT_CAT_LUGARES_ENTREGA"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * From CAT_LUGARES_ENTREGA"
        Me._QueryOrder = " Order by NOMBRE_LUGAR_ENTREGA"
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
            .CommandText = "MP_CAT_LUGARES_ENTREGA_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_LUGAR_ENTREGA", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_LUGAR_ENTREGA.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_LUGAR_ENTREGA", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._NOMBRE_LUGAR_ENTREGA.ToUpper
            sqlParametro = .Parameters.Add("@IMPORTE_FLETE", SqlDbType.Decimal) : sqlParametro.Value = Me.IMPORTE_FLETE
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
            .CommandText = "MP_CAT_LUGARES_ENTREGA_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_LUGAR_ENTREGA", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._CODIGO_LUGAR_ENTREGA.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_LUGAR_ENTREGA", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._NOMBRE_LUGAR_ENTREGA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@IMPORTE_FLETE", SqlDbType.Decimal) : sqlParametro.Value = Me.IMPORTE_FLETE.ToString.ToUpper
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
        Dim cmd As New SqlCommand("Select * from CAT_LUGARES_ENTREGA Where CODIGO_LUGAR_ENTREGA='" & Replace(Me._CODIGO_LUGAR_ENTREGA, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_LUGAR_ENTREGA = "" & dReader("CODIGO_LUGAR_ENTREGA").ToString
                    Me._NOMBRE_LUGAR_ENTREGA = Trim("" & dReader("NOMBRE_LUGAR_ENTREGA").ToString)
                    Me.IMPORTE_FLETE = "" & dReader("IMPORTE_FLETE").ToString
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
        Dim dsCat_LugaresEntrega As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            dsCat_LugaresEntrega.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCat_LugaresEntrega.Dispose()
        End Try
        Return dTable
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.

    Public Function ObtenerElementosParaReportes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCat_LugaresEntrega As New SqlDataAdapter("Select CODIGO_LUGAR_ENTREGA,NOMBRE_LUGAR_ENTREGA FROM CAT_LUGARES_ENTREGA ORDER BY NOMBRE_LUGAR_ENTREGA ", Me._Conexion)
        Try
            dsCat_LugaresEntrega.Fill(dTable)
            dTable.Rows.Add("0", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosParaReportes", ex)
        Finally
            dsCat_LugaresEntrega.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT CODIGO_LUGAR_ENTREGA,NOMBRE_LUGAR_ENTREGA FROM CAT_LUGARES_ENTREGA WHERE NOMBRE_LUGAR_ENTREGA LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_LUGAR_ENTREGA", Me._Conexion)
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
        f.sCampo = "CODIGO_LUGAR_ENTREGA"
        f.sOrder = "NOMBRE_LUGAR_ENTREGA"
        f.sTable = "CAT_LUGARES_ENTREGA"
        f.sQl = "Select CODIGO_LUGAR_ENTREGA,NOMBRE_LUGAR_ENTREGA From CAT_LUGARES_ENTREGA Where 1=1 And"
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
        f.sCampo = "NOMBRE_LUGAR_ENTREGA"
        f.sOrder = "NOMBRE_LUGAR_ENTREGA"
        f.sTable = "CAT_LUGARES_ENTREGA"
        f.sQl = "Select CODIGO_LUGAR_ENTREGA,NOMBRE_LUGAR_ENTREGA From CAT_LINEAS_TRANSPORTES Where 1=1 And"
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
        Dim iLineaTransporte As Integer
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("SELECT MAX(CODIGO_LUGAR_ENTREGA) FROM CAT_LUGARES_ENTREGA")
            If sql.Result1 = "" Then
                iLineaTransporte = 1
            Else
                iLineaTransporte = CType(sql.Result1, Integer) + 1
            End If
            Resultado = iLineaTransporte.ToString
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
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
