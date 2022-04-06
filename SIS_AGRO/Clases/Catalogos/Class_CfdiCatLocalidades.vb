Option Strict On

Imports System.Data.SqlClient

Public Class Class_CfdiCatLocalidades

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_LOCALIDAD As String
    Private _CODIGO_LOCALIDAD As String
    Private _CODIGO_ESTADO_SAT As String
    Private _NOMBRE_LOCALIDAD As String
    Private _ESTATUS As String
    Private _CODIGO_USUARIO_CREO As Integer
    Private _FECHA_CREO As Date
    Private _CODIGO_USUARIO_MODIFICO As Integer
    Private _FECHA_MODIFICO As Date
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
    Public ReadOnly Property ID_LOCALIDAD() As String
        Get
            Return Me._ID_LOCALIDAD
        End Get
    End Property

    Public ReadOnly Property CODIGO_LOCALIDAD() As String
        Get
            Return Me._CODIGO_LOCALIDAD
        End Get
    End Property

    Public ReadOnly Property CODIGO_ESTADO_SAT() As String
        Get
            Return Me._CODIGO_ESTADO_SAT
        End Get
    End Property

    Public ReadOnly Property NOMBRE_LOCALIDAD() As String
        Get
            Return Me._NOMBRE_LOCALIDAD
        End Get
    End Property

    Public ReadOnly Property ESTATUS() As String
        Get
            Return Me._ESTATUS
        End Get
    End Property

    Public ReadOnly Property CODIGO_USUARIO_CREO() As Integer
        Get
            Return Me._CODIGO_USUARIO_CREO
        End Get
    End Property

    Public ReadOnly Property FECHA_CREO() As Date
        Get
            Return Me._FECHA_CREO
        End Get
    End Property

    Public ReadOnly Property CODIGO_USUARIO_MODIFICO() As Integer
        Get
            Return Me._CODIGO_USUARIO_MODIFICO
        End Get
    End Property

    Public ReadOnly Property FECHA_MODIFICO() As Date
        Get
            Return Me._FECHA_MODIFICO
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
#End Region
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "CFDI_CAT_LOCALIDADES"
        Me._Nombre_Reporte = "RPT_CATALOGO_CFDI_LOCALIDADES"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * From CFDI_CAT_LOCALIDADES"
        Me._QueryOrder = " Order by NOMBRE_LOCALIDAD"
    End Sub

    Public Sub New(ByVal sIDLocalidad As String)
        Me.New()
        Try
            Me._ID_LOCALIDAD = sIDLocalidad
            If Me.Consultar = True Then
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "New", ex)
        End Try
    End Sub

    Public Sub New(ByVal sIDLocalidad As String, ByVal sCodigoEstadoSAT As String)
        Me.New()
        Try
            Me._ID_LOCALIDAD = sIDLocalidad
            If Me.ConsultarPorEstado(sCodigoEstadoSAT) = True Then
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

#Region "Métodos y procedimientos"
    Public Function Consultar() As Boolean
        Const sProcedure As String = "Consultar"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand("SELECT * FROM CFDI_CAT_LOCALIDADES WHERE ID_LOCALIDAD='" & sReplace(Me._ID_LOCALIDAD) & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._ID_LOCALIDAD = "" & dReader("ID_LOCALIDAD").ToString
                    Me._CODIGO_LOCALIDAD = "" & dReader("CODIGO_LOCALIDAD").ToString
                    Me._CODIGO_ESTADO_SAT = "" & dReader("CODIGO_ESTADO").ToString
                    Me._NOMBRE_LOCALIDAD = "" & dReader("NOMBRE_LOCALIDAD").ToString
                    Me._ESTATUS = "" & dReader("ESTATUS").ToString
                    Me._CODIGO_USUARIO_CREO = CType(dReader("CODIGO_USUARIO_CREO").ToString, Integer)
                    Me._FECHA_CREO = CDate(dReader("FECHA_CREO").ToString)
                    If Not (IsDBNull(dReader("CODIGO_USUARIO_MODIFICO"))) Then Me._CODIGO_USUARIO_MODIFICO = CInt("" & dReader("CODIGO_USUARIO_MODIFICO").ToString)
                    If Not (IsDBNull(dReader("FECHA_MODIFICO"))) Then Me._FECHA_MODIFICO = CDate(dReader("FECHA_MODIFICO"))

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, sProcedure, ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
        Return bResultado
    End Function

    Public Function ConsultarPorEstado(ByVal sCodigoEstadoSAT As String) As Boolean
        Const sProcedure As String = "ConsultarPorEstado"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand("SELECT * FROM CFDI_CAT_LOCALIDADES L  " &
                                  "WHERE L.ID_LOCALIDAD='" & sReplace(Me._ID_LOCALIDAD) & "' AND L.CODIGO_ESTADO_SAT='" & sCodigoEstadoSAT & "' ", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._ID_LOCALIDAD = "" & dReader("ID_LOCALIDAD").ToString
                    Me._CODIGO_LOCALIDAD = "" & dReader("CODIGO_LOCALIDAD").ToString
                    Me._CODIGO_ESTADO_SAT = "" & dReader("CODIGO_ESTADO_SAT").ToString
                    Me._NOMBRE_LOCALIDAD = "" & dReader("NOMBRE_LOCALIDAD").ToString
                    Me._ESTATUS = "" & dReader("ESTATUS").ToString
                    Me._CODIGO_USUARIO_CREO = CType(dReader("CODIGO_USUARIO_CREO").ToString, Integer)
                    Me._FECHA_CREO = CDate(dReader("FECHA_CREO").ToString)
                    If Not (IsDBNull(dReader("CODIGO_USUARIO_MODIFICO"))) Then Me._CODIGO_USUARIO_MODIFICO = CInt("" & dReader("CODIGO_USUARIO_MODIFICO").ToString)
                    If Not (IsDBNull(dReader("FECHA_MODIFICO"))) Then Me._FECHA_MODIFICO = CDate(dReader("FECHA_MODIFICO"))

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, sProcedure, ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
        Return bResultado
    End Function

    Public Function ObtenerElementos() As System.Data.DataTable
        Const sProcedure As String = "ObtenerElementos"
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosParaReportes() As System.Data.DataTable
        Const sProcedure As String = "ObtenerElementosParaReportes"
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            da.Fill(dTable)
            dTable.Rows.Add("-1", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Const sProcedure As String = "ObtenerElementosFiltro"
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_LOCALIDAD,NOMBRE_LOCALIDAD FROM CFDI_CAT_LOCALIDADES WHERE NOMBRE_LOCALIDAD LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_LOCALIDAD", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function BusquedaVisual_PorCodigo(ByVal sCodigoEstadoSAT As String) As String
        Const sProcedure As String = "BusquedaVisual_PorCodigo"
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de localidades por código."
        f.sCampo = "CODIGO_LOCALIDAD"
        f.sOrder = "NOMBRE_LOCALIDAD"
        f.sTable = "CFDI_CAT_LOCALIDADES"
        f.sQl = "SELECT L.ID_LOCALIDAD,L.NOMBRE_LOCALIDAD FROM CFDI_CAT_LOCALIDADES L " &
                "WHERE L.ESTATUS='A' AND l.CODIGO_ESTADO_SAT='" & sCodigoEstadoSAT & "' AND "
        f.Inicia("%")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, sProcedure, ex)
        End Try
        Return Resultado
    End Function

    'Public Function BusquedaVisual_PorDescripcion(ByVal sCodigoMunicipio As String) As String
    Public Function BusquedaVisual_PorDescripcion(ByVal sCodigoEstadoSAT As String) As String
        Const sProcedure As String = "BusquedaVisual_PorDescripcion"
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de localidades por nombre."
        f.sCampo = "NOMBRE_LOCALIDAD"
        f.sOrder = "NOMBRE_LOCALIDAD"
        f.sTable = "CFDI_CAT_LOCALIDADES"
        f.sQl = "SELECT L.ID_LOCALIDAD,L.NOMBRE_LOCALIDAD FROM CFDI_CAT_LOCALIDADES L " &
                "WHERE L.ESTATUS='A' AND L.CODIGO_ESTADO_SAT='" & sCodigoEstadoSAT & "' AND "

        'f.sQl = "SELECT L.ID_LOCALIDAD,L.NOMBRE_LOCALIDAD FROM CFDI_CAT_LOCALIDADES L INNER JOIN SIS_ESTADOS E ON(L.CODIGO_ESTADO=E.CODIGO_ESTADO) INNER JOIN CAT_MUNICIPIOS M ON(E.CODIGO_ESTADO=M.CODIGO_ESTADO) " &
        '        "WHERE L.ESTATUS='A' AND M.CODIGO_MUNICIPIO='" & sCodigoMunicipio & "' AND "

        f.Inicia("%")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, sProcedure, ex)
        End Try
        Return Resultado
    End Function

#End Region

End Class