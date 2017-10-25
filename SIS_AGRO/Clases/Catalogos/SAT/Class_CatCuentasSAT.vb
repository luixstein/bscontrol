Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatCuentasSAT

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_AGRUPADOR As String
    Private _NOMBRE_CUENTA_SAT As String
    Private _CODIGO_RANGO As String
    Private _ES_MAYOR As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean
#End Region

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public ReadOnly Property CODIGO_AGRUPADOR As String
        Get
            Return Me._CODIGO_AGRUPADOR
        End Get
    End Property

    Public ReadOnly Property NOMBRE_CUENTA_SAT As String
        Get
            Return Me._NOMBRE_CUENTA_SAT
        End Get
    End Property

    Public ReadOnly Property CODIGO_RANGO As String
        Get
            Return Me._CODIGO_RANGO
        End Get
    End Property

    Public ReadOnly Property ES_MAYOR As String
        Get
            Return Me._ES_MAYOR
        End Get
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property
#End Region

#Region "Propiedad Nombre de Clase"
    Private ReadOnly Property NombreClase() As String
        Get
            NombreClase = "Class_CatCuentasSAT"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT CODIGO_AGRUPADOR,NOMBRE_CUENTA_SAT,CODIGO_RANGO,ES_MAYOR FROM CAT_CUENTAS_SAT "
        Me._QueryOrder = " ORDER BY ID_ORDER"
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal sCodigoAgrupador As String)
        Me.New()
        Me._CODIGO_AGRUPADOR = sCodigoAgrupador
        Try
            If Me.Consultar = True Then
                Me._Existe = True
                'Else
                '    Throw New Exception("El proveedor no existe.")
            End If
        Catch ex As Exception
            HandleError(Me.NombreClase, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function Consultar() As Boolean
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE CODIGO_AGRUPADOR='" & Me._CODIGO_AGRUPADOR.ToString & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_AGRUPADOR = dReader("CODIGO_AGRUPADOR").ToString()
                    Me._NOMBRE_CUENTA_SAT = "" & dReader("NOMBRE_CUENTA_SAT").ToString()
                    Me._CODIGO_RANGO = "" & dReader("CODIGO_RANGO").ToString()
                    Me._ES_MAYOR = "" & dReader("ES_MAYOR").ToString()
                    Consultar = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.NombreClase, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
    End Function        'Consulta un elemento del catálogo.

    Public Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de cuentas SAT por Código."
        f.sCampo = "CODIGO_AGRUPADOR"
        f.sOrder = "ID_ORDER"
        f.sTable = "CAT_CUENTAS_SAT"
        f.sQl = "SELECT CODIGO_AGRUPADOR,NOMBRE_CUENTA_SAT FROM CAT_CUENTAS_SAT WHERE 1=1 AND"
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.NombreClase, "BusquedaVisual_PorCodigo", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de cuentas SAT por Nombre."
        f.sCampo = "NOMBRE_CUENTA_SAT"
        f.sOrder = "ID_ORDER"
        f.sTable = "CAT_CUENTAS_SAT"
        f.sQl = "SELECT CODIGO_AGRUPADOR,NOMBRE_CUENTA_SAT FROM CAT_CUENTAS_SAT WHERE 1=1 AND"
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.NombreClase, "BusquedaVisual_PorDescripcion", ex)
        End Try
        Return Resultado
    End Function
#End Region
End Class
