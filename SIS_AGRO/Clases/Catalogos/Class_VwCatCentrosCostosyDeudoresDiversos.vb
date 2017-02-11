Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class Class_VwCatCentrosCostosyDeudoresDiversos

#Region "Campos"

#Region "Campos de la tabla"
    Private _TIPO As String
    Private _CODIGO As String
    Private _NOMBRE As String
    Private _CUENTA_CONTABLE As String
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
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public ReadOnly Property TIPO() As String
        Get
            Return Me._TIPO
        End Get
    End Property

    Public ReadOnly Property CODIGO() As String
        Get
            Return Me._CODIGO
        End Get
    End Property

    Public ReadOnly Property NOMBRE() As String
        Get
            Return Me._NOMBRE
        End Get
    End Property

    Public ReadOnly Property CUENTA_CONTABLE() As String
        Get
            Return Me._CUENTA_CONTABLE
        End Get
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property EXISTE() As Boolean
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
    Public ReadOnly Property Nombre_Catalogo() As String
        Get
            Return Me._Nombre_Catalogo
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"

    Public Sub New()
        Me._Nombre_Catalogo = "VW_CAT_CENTROS_COSTOS_Y_DEUDORES_DIVERSOS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT TIPO,CODIGO,NOMBRE,CUENTA_CONTABLE FROM VW_CAT_CENTROS_COSTOS_Y_DEUDORES_DIVERSOS"
        Me._QueryOrder = " ORDER BY TIPO,NOMBRE"
    End Sub

    Public Sub New(ByVal sTipo As String, ByVal sCodigo As String)
        Me.New()

        Me._TIPO = sTipo
        Me._CODIGO = sCodigo
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

#Region "Opciones"

#End Region

#Region "Métodos y procedimientos"
    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand("SELECT * FROM VW_CAT_CENTROS_COSTOS_Y_DEUDORES_DIVERSOS WHERE TIPO='" & Me._TIPO & "' AND CODIGO='" & Me._CODIGO & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._TIPO = Trim("" & dReader("TIPO").ToString)
                    Me._CODIGO = Trim("" & dReader("CODIGO").ToString)
                    Me._NOMBRE = Trim("" & dReader("NOMBRE").ToString)
                    Me._CUENTA_CONTABLE = Trim("" & dReader("CUENTA_CONTABLE").ToString)

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

    Public Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de centros de costos/deudores diversos por descripción."
        f.sCampo = "NOMBRE"
        f.sOrder = "CODIGO,NOMBRE"
        f.sTable = "VW_CAT_CENTROS_COSTOS_Y_DEUDORES_DIVERSOS"
        f.sQl = "SELECT TIPO+'|'+CODIGO CODIGO,NOMBRE FROM VW_CAT_CENTROS_COSTOS_Y_DEUDORES_DIVERSOS WHERE 1=1 AND " 'Regresa las dos primeras columnas : tipo y codigo concateadas con |
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String) ' + "|" + CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 1), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion", ex)
        End Try
        Return Resultado
    End Function
#End Region

End Class
