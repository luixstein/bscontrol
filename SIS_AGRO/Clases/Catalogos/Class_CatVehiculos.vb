Option Strict On

Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Class_CatVehiculos

#Region "Campos"
#Region "Campos de la tabla"
    Private _CODIGO_VEHICULO As String
    Private _Nombre_Vehiculo As String
    Private _CODIGO_CATEGORIA As String
    Private _ESTATUS As String
    Private _MARCA As String
    Private _PLACA As String
    Private _ANIO As String
    Private _CODIGO_AUTOTRANSPORTE As String
    Private _CODIGO_PERMISO_SCT As String
    Private _NUMERO_PERMISO_SCT As String
    Private _NOMBRE_ASEGURADORA_RESPONSABILIDAD_CIVIL As String
    Private _POLIZA_RESPONSABILIDAD_CIVIL As String
    Private _NOMBRE_ASEGURADORA_MEDIO_AMBIENTE As String
    Private _POLIZA_MEDIO_AMBIENTE As String
    Private _NOMBRE_ASEGURADORA_CARGA As String
    Private _POLIZA_CARGA As String
    Private _PRIMA_SEGURO As String
    Private _CODIGO_USUARIO_CREO As String
    Private _FECHA_CREO As Date
    Private _CODIGO_USUARIO_MODIFICO As String
    Private _FECHA_MODIFICO As Date
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean
    Private _GENERAR_CATEGORIA As Boolean
    Private _CODIGO_TIPO_CATEGORIA As String
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
    Public Property CODIGO_VEHICULO() As String
        Get
            Return Me._CODIGO_VEHICULO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_VEHICULO = Value
        End Set
    End Property

    Public Property NOMBRE_VEHICULO() As String
        Get
            Return Me._Nombre_Vehiculo
        End Get
        Set(ByVal Value As String)
            Me._Nombre_Vehiculo = Value
        End Set
    End Property

    Public Property CODIGO_CATEGORIA() As String
        Get
            Return Me._CODIGO_CATEGORIA
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CATEGORIA = Value
        End Set
    End Property

    Public Property ESTATUS() As String
        Get
            Return Me._ESTATUS
        End Get
        Set(ByVal Value As String)
            Me._ESTATUS = Value
        End Set
    End Property

    Public Property MARCA() As String
        Get
            Return Me._MARCA
        End Get
        Set(value As String)
            Me._MARCA = value
        End Set
    End Property

    Public Property PLACA() As String
        Get
            Return Me._PLACA
        End Get
        Set(value As String)
            Me._PLACA = value
        End Set
    End Property

    Public Property ANIO() As String
        Get
            Return Me._ANIO
        End Get
        Set(value As String)
            Me._ANIO = value
        End Set
    End Property

    Public Property CODIGO_AUTOTRANSPORTE() As String
        Get
            Return Me._CODIGO_AUTOTRANSPORTE
        End Get
        Set(value As String)
            Me._CODIGO_AUTOTRANSPORTE = value
        End Set
    End Property

    Public Property CODIGO_PERMISO_SCT() As String
        Get
            Return Me._CODIGO_PERMISO_SCT
        End Get
        Set(value As String)
            Me._CODIGO_PERMISO_SCT = value
        End Set
    End Property

    Public Property NUMERO_PERMISO_SCT() As String
        Get
            Return Me._NUMERO_PERMISO_SCT
        End Get
        Set(value As String)
            Me._NUMERO_PERMISO_SCT = value
        End Set
    End Property

    Public Property NOMBRE_ASEGURADORA_RESPONSABILIDAD_CIVIL() As String
        Get
            Return Me._NOMBRE_ASEGURADORA_RESPONSABILIDAD_CIVIL
        End Get
        Set(value As String)
            Me._NOMBRE_ASEGURADORA_RESPONSABILIDAD_CIVIL = value
        End Set
    End Property

    Public Property POLIZA_RESPONSABILIDAD_CIVIL() As String
        Get
            Return Me._POLIZA_RESPONSABILIDAD_CIVIL
        End Get
        Set(value As String)
            Me._POLIZA_RESPONSABILIDAD_CIVIL = value
        End Set
    End Property

    Public Property NOMBRE_ASEGURADORA_MEDIO_AMBIENTE() As String
        Get
            Return Me._NOMBRE_ASEGURADORA_MEDIO_AMBIENTE
        End Get
        Set(value As String)
            Me._NOMBRE_ASEGURADORA_MEDIO_AMBIENTE = value
        End Set
    End Property

    Public Property POLIZA_MEDIO_AMBIENTE() As String
        Get
            Return Me._POLIZA_MEDIO_AMBIENTE
        End Get
        Set(value As String)
            Me._POLIZA_MEDIO_AMBIENTE = value
        End Set
    End Property

    Public Property NOMBRE_ASEGURADORA_CARGA() As String
        Get
            Return Me._NOMBRE_ASEGURADORA_CARGA
        End Get
        Set(value As String)
            Me._NOMBRE_ASEGURADORA_CARGA = value
        End Set
    End Property

    Public Property POLIZA_CARGA() As String
        Get
            Return Me._POLIZA_CARGA
        End Get
        Set(value As String)
            Me._POLIZA_CARGA = value
        End Set
    End Property

    Public Property PRIMA_SEGURO() As String
        Get
            Return Me._PRIMA_SEGURO
        End Get
        Set(value As String)
            Me._PRIMA_SEGURO = value
        End Set
    End Property

    Public Property CODIGO_USUARIO_CREO() As String
        Get
            Return Me._CODIGO_USUARIO_CREO
        End Get
        Set(value As String)
            Me._CODIGO_USUARIO_CREO = value
        End Set
    End Property

    Public Property FECHA_CREO() As Date
        Get
            Return Me._FECHA_CREO
        End Get
        Set(value As Date)
            Me._FECHA_CREO = value
        End Set
    End Property

    Public Property CODIGO_USUARIO_MODIFICO() As String
        Get
            Return Me._CODIGO_USUARIO_MODIFICO
        End Get
        Set(value As String)
            Me._CODIGO_USUARIO_MODIFICO = value
        End Set
    End Property

    Public Property FECHA_MODIFICO() As Date
        Get
            Return Me._FECHA_MODIFICO
        End Get
        Set(value As Date)
            Me._FECHA_MODIFICO = value
        End Set
    End Property

#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property

    Public WriteOnly Property GENERAR_CATEGORIA() As Boolean
        Set(ByVal Value As Boolean)
            Me._GENERAR_CATEGORIA = Value
        End Set
    End Property

    Public WriteOnly Property CODIGO_TIPO_CATEGORIA() As String
        Set(ByVal Value As String)
            Me._CODIGO_TIPO_CATEGORIA = Value
        End Set
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
        Me._Nombre_Catalogo = "CAT_VEHICULOS"
        Me._Nombre_Reporte = "RPT_CATALOGO_VEHICULOS"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * From CAT_VEHICULOS"
        Me._QueryOrder = " Order by NOMBRE_VEHICULO"
    End Sub

    Public Sub New(ByVal sCodigoVehiculo As String)
        Me.New()
        Try
            Me._CODIGO_VEHICULO = sCodigoVehiculo
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

#Region "Métodos y procedimientos"
    Public Function Grabar(ByVal sAccion As String) As Boolean
        Const sProcedure As String = "Grabar"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_VEHICULOS_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_VEHICULO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_VEHICULO) : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@NOMBRE_VEHICULO", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._Nombre_Vehiculo.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me._ESTATUS.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_CATEGORIA", SqlDbType.SmallInt) : sqlParametro.Value = CInt(valorNumerico(Me._CODIGO_CATEGORIA)) : sqlParametro.Direction = ParameterDirection.InputOutput
            sqlParametro = .Parameters.Add("@GENERAR_CATEGORIA", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(Me._GENERAR_CATEGORIA)
            sqlParametro = .Parameters.Add("@CODIGO_TIPO_CATEGORIA", SqlDbType.SmallInt) : sqlParametro.Value = CInt(valorNumerico(Me._CODIGO_TIPO_CATEGORIA))
            sqlParametro = .Parameters.Add("@MARCA", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._MARCA.ToUpper
            sqlParametro = .Parameters.Add("@PLACA", SqlDbType.NVarChar, 7) : sqlParametro.Value = Me._PLACA.ToUpper
            sqlParametro = .Parameters.Add("@ANIO", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._ANIO.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_AUTOTRANSPORTE", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_AUTOTRANSPORTE.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PERMISO_SCT", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_PERMISO_SCT.ToUpper
            sqlParametro = .Parameters.Add("@NUMERO_PERMISO_SCT", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._NUMERO_PERMISO_SCT.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_ASEGURADORA_RESPONSABILIDAD_CIVIL", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._NOMBRE_ASEGURADORA_RESPONSABILIDAD_CIVIL.ToUpper
            sqlParametro = .Parameters.Add("@POLIZA_RESPONSABILIDAD_CIVIL", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._POLIZA_RESPONSABILIDAD_CIVIL.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_ASEGURADORA_MEDIO_AMBIENTE", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._NOMBRE_ASEGURADORA_MEDIO_AMBIENTE.ToUpper
            sqlParametro = .Parameters.Add("@POLIZA_MEDIO_AMBIENTE", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._POLIZA_MEDIO_AMBIENTE.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_ASEGURADORA_CARGA", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._NOMBRE_ASEGURADORA_CARGA.ToUpper
            sqlParametro = .Parameters.Add("@PRIMA_SEGURO", SqlDbType.Decimal) : sqlParametro.Value = Me._PRIMA_SEGURO.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_CREO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_USUARIO_CREO)
            sqlParametro = .Parameters.Add("@FECHA_CREO", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_CREO
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_MODIFICO", SqlDbType.SmallInt) : sqlParametro.Value = CInt(Me._CODIGO_USUARIO_MODIFICO)
            sqlParametro = .Parameters.Add("@FECHA_MODIFICO", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_MODIFICO
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = sAccion
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
                If sAccion = "INSERTAR" Then
                    Me._CODIGO_VEHICULO = "" & .Parameters("@CODIGO_VEHICULO").Value.ToString
                    Me._CODIGO_CATEGORIA = "" & .Parameters("@CODIGO_CATEGORIA").Value.ToString
                End If

            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, sProcedure, ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function Consultar() As Boolean
        Const sProcedure As String = "Consultar"
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand("Select * from CAT_VEHICULOS Where CODIGO_VEHICULO='" & sReplace(Me._CODIGO_VEHICULO) & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_VEHICULO = "" & dReader("CODIGO_VEHICULO").ToString
                    Me._Nombre_Vehiculo = Trim("" & dReader("NOMBRE_VEHICULO").ToString)
                    Me._ESTATUS = "" & dReader("ESTATUS").ToString
                    Me._CODIGO_CATEGORIA = "" & dReader("CODIGO_CATEGORIA").ToString
                    Me._MARCA = "" & dReader("MARCA").ToString
                    Me._PLACA = "" & dReader("PLACA").ToString
                    Me._ANIO = "" & dReader("ANIO").ToString
                    Me._CODIGO_AUTOTRANSPORTE = "" & dReader("CODIGO_AUTOTRANSPORTE").ToString
                    Me._CODIGO_PERMISO_SCT = "" & dReader("CODIGO_PERMISO_SCT").ToString
                    Me._NUMERO_PERMISO_SCT = "" & dReader("NUMERO_PERMISO_SCT").ToString
                    Me._NOMBRE_ASEGURADORA_RESPONSABILIDAD_CIVIL = "" & dReader("NOMBRE_ASEGURADORA_RESPONSABILIDAD_CIVIL").ToString
                    Me._POLIZA_RESPONSABILIDAD_CIVIL = "" & dReader("POLIZA_RESPONSABILIDAD_CIVIL").ToString
                    Me._NOMBRE_ASEGURADORA_MEDIO_AMBIENTE = "" & dReader("NOMBRE_ASEGURADORA_MEDIO_AMBIENTE").ToString
                    Me._POLIZA_MEDIO_AMBIENTE = "" & dReader("POLIZA_MEDIO_AMBIENTE").ToString
                    Me._NOMBRE_ASEGURADORA_CARGA = "" & dReader("NOMBRE_ASEGURADORA_CARGA").ToString
                    Me._POLIZA_CARGA = "" & dReader("POLIZA_CARGA").ToString
                    Me._PRIMA_SEGURO = "" & dReader("PRIMA_SEGURO").ToString
                    Me._CODIGO_USUARIO_CREO = "" & dReader("CODIGO_USUARIO_CREO").ToString
                    Me._FECHA_CREO = CDate(dReader("FECHA_CREO").ToString)
                    Me._CODIGO_USUARIO_MODIFICO = "" & dReader("CODIGO_USUARIO_MODIFICO").ToString
                    If Not (IsDBNull(dReader("FECHA_MODIFICO"))) Then Me._FECHA_MODIFICO = CDate(dReader("FECHA_MODIFICO").ToString)

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

    Public Function ObtenerElementosFiltro(ByVal Filtro As String, ByVal ESTATUS As String) As System.Data.DataTable
        Const sProcedure As String = "ObtenerElementosFiltro"
        Dim dTable As New DataTable
        Dim da As New SqlDataAdapter("SELECT CODIGO_VEHICULO,NOMBRE_VEHICULO FROM CAT_VEHICULOS WHERE NOMBRE_VEHICULO LIKE '" & Filtro.ToString & "%' AND ESTATUS='" & ESTATUS & "' ORDER BY NOMBRE_VEHICULO", Me._Conexion)
        Try
            da.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, sProcedure, ex)
        Finally
            da.Dispose()
        End Try
        Return dTable
    End Function

    Public Function BusquedaVisual_PorCodigo() As String
        Const sProcedure As String = "BusquedaVisual_PorCodigo"
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de categoria por código."
        f.sCampo = "CODIGO_VEHICULO"
        f.sOrder = "NOMBRE_VEHICULO"
        f.sTable = "CAT_VEHICULOS"
        f.sQl = "SELECT CODIGO_VEHICULO,NOMBRE_VEHICULO FROM CAT_VEHICULOS WHERE 1=1 AND "
        f.Inicia("")
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

    Public Function BusquedaVisual_PorDescripcion() As String
        Const sProcedure As String = "BusquedaVisual_PorDescripcion"
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de vehículos por nombre."
        f.sCampo = "NOMBRE_VEHICULO"
        f.sOrder = "NOMBRE_VEHICULO"
        f.sTable = "CAT_VEHICULOS"
        f.sQl = "SELECT CODIGO_VEHICULO,NOMBRE_VEHICULO FROM CAT_VEHICULOS WHERE 1=1 AND "
        f.Inicia("")
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

    Public Function CodigoSiguiente() As Integer
        Const sProcedure As String = "CodigoSiguiente"
        Dim Resultado As Integer
        Try
            Dim sql As New Class_find("SELECT ISNULL(MAX(CODIGO_VEHICULO),0) FROM CAT_VEHICULOS")
            Resultado = CType(sql.Result1, Integer) + 1
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, sProcedure, ex)
        End Try
        Return Resultado
    End Function

    Public Sub Imprimir_Listado()   'Función para ver la búsqueda visual por descripción.
        Const sProcedure As String = "Imprimir_Listado"
        If Len(Nombre_Reporte) > 0 Then
            Dim Rpt As New ReportDocument
            Dim oReporte As Class_Reporte
            Try
                oReporte = New Class_Reporte(Nombre_Reporte, Rpt)

                Dim frm As New Reporte(Rpt)
                frm.CRViewer.ShowGroupTreeButton = False
                frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                frm.Show()

            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, sProcedure, ex)
            Finally
                oReporte = Nothing
                'Rpt.Dispose()
            End Try
        Else
            MsgBox("El nombre del reporte no ha sido especificado, no hay nada que imprimir.", MsgBoxStyle.Exclamation, Me.Nombre_Catalogo)
        End If
    End Sub
#End Region

End Class