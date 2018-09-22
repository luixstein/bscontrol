Imports System.Data.SqlClient

Public Class Class_CatTiendasSoriana
    'Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_TIENDA_SORIANA As String
    Private _CODIGO_TIENDA_SORIANA As String
    Private _NOMBRE_TIENDA_SORIANA As String
    Private _ESTATUS As String
    Private _AGREGAR As String

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
    Public Property ID_TIENDA_SORIANA() As Integer
        Get
            Return Me._ID_TIENDA_SORIANA
        End Get
        Set(ByVal Value As Integer)
            Me._ID_TIENDA_SORIANA = Value
        End Set
    End Property

    Public Property CODIGO_TIENDA_SORIANA() As String
        Get
            Return Me._CODIGO_TIENDA_SORIANA
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_TIENDA_SORIANA = Value
        End Set
    End Property

    Public Property NOMBRE_TIENDA_SORIANA() As String
        Get
            Return Me._NOMBRE_TIENDA_SORIANA
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_TIENDA_SORIANA = Value
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

    Public ReadOnly Property Nombre_Catalogo() As String
        Get
            Return Me._Nombre_Catalogo
        End Get
    End Property

    Public Property Nombre_Reporte() As String
        Get
            Return Me._Nombre_Reporte
        End Get
        Set(ByVal value As String)
            Me._Nombre_Reporte = value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return Me._ESTATUS
        End Get
        Set(ByVal value As String)
            Me._ESTATUS = value
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
        Me._Nombre_Catalogo = "CAT_TIENDAS_SORIANA"
        Me._Nombre_Reporte = "RPT_CAT_TIENDAS_SORIANA.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select ID_TIENDA_SORIANA,CODIGO_TIENDA_SORIANA,NOMBRE_TIENDA_SORIANA " &
        "FROM CAT_TIENDAS_SORIANA"
        Me._QueryOrder = " ORDER BY NOMBRE_TIENDA_SORIANA"
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal sCodTienda As String)
        Me.New()
        Me._CODIGO_TIENDA_SORIANA = sCodTienda
        Try
            If Me.Consultar = True Then
                Me._Existe = True
                'Else
                '    Throw New Exception("El PRODUCTOR no existe.")
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

    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE CODIGO_TIENDA_SORIANA='" & Me._CODIGO_TIENDA_SORIANA & "' ", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._ID_TIENDA_SORIANA = "" & dReader("ID_TIENDA_SORIANA")
                    Me._CODIGO_TIENDA_SORIANA = "" & dReader("CODIGO_TIENDA_SORIANA")
                    Me._NOMBRE_TIENDA_SORIANA = "" & dReader("NOMBRE_TIENDA_SORIANA")
                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
        Return bResultado
    End Function

    Public Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_TIENDA_SORIANA,NOMBRE_TIENDA_SORIANA FROM CAT_TIENDAS_SORIANA ORDER BY NOMBRE_TIENDA_SORIANA", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de tiendas soriana por codigo."
        f.sCampo = "CODIGO_TIENDA_SORIANA"
        f.sOrder = "NOMBRE_TIENDA_SORIANA"
        f.sTable = "CAT_CLIENTES"
        f.sQl = "SELECT CODIGO_TIENDA_SORIANA,NOMBRE_TIENDA_SORIANA FROM CAT_TIENDAS_SORIANA WHERE 1=1 AND "
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

    Public Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de tiendas soriana por Descripción."
        f.sCampo = "NOMBRE_TIENDA_SORIANA"
        f.sOrder = "NOMBRE_TIENDA_SORIANA"
        f.sTable = "CAT_CLIENTES"
        f.sQl = "SELECT CODIGO_TIENDA_SORIANA,NOMBRE_TIENDA_SORIANA FROM CAT_TIENDAS_SORIANA WHERE 1=1 AND "
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

    Public Function CodigoSiguiente(ByVal sCodigoTipoMercado As String) As String
        Dim iCliente As Integer, sCliente As String
        Dim Resultado As String = ""
        Try
            Dim CodigoCliente As New Class_find("SELECT CASE WHEN " & sCodigoTipoMercado & "='0001' THEN CODIGO_CLIENTES_EXPORTACION ELSE CODIGO_CLIENTES_NACIONAL END FROM SIS_PLAZAS WHERE CODIGO_PLAZA =" & Usuario.Codigo_Plaza.ToString)
            If txtLEN(CodigoCliente.Result1) = False Then
                MsgBox("No se encontró el siguiente código de cliente.", MsgBoxStyle.Exclamation, Me.Nombre_Catalogo)
                Return ""
            End If

            iCliente = CodigoCliente.Result1.Substring(2)
            iCliente = iCliente + 1
            sCliente = "0000" + iCliente.ToString
            Resultado = CodigoCliente.Result1.Remove(2, 4) + sCliente.Substring(Len(sCliente) - 4)
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
        End Try
        Return Resultado
    End Function

#End Region

End Class
