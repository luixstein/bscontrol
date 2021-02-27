Option Strict On

Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Class_Acuicola_Canastas_Global

#Region "Campos"
#Region "Campos de la tabla"
    Private _ID_ACUICOLA_CANASTAS_GLOBAL As Integer = 0
    Private _ID_NOMINA_TEMPORADA As Integer
    Private _FOLIO_CANASTAS As String
    Private _CODIGO_DOCUMENTO As String
    Private _CODIGO_PLAZA As Integer
    Private _CICLO As Integer
    Private _CODIGO_DIVISION As Integer
    Private _FECHA As Date
    Private _FECHA_SERVIDOR As Date
    Private _CODIGO_USUARIO_GRABO As Integer
    Private _ESTATUS As String
    Private _CONCEPTO As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
    Private _NOMBRE_USUARIO_GRABO As String
    Public oDocumento As New Class_CatDocumentos
#End Region

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
#End Region

#Region "Campos públicos"
    Public oDetalle As Class_Acuicola_Canastas_Detalle
#End Region

#End Region

#Region "Propiedades"
#Region "Propiedades Campos de la tabla"
    Public ReadOnly Property ID_ACUICOLA_CANASTAS_GLOBAL() As Integer
        Get
            Return Me._ID_ACUICOLA_CANASTAS_GLOBAL
        End Get
    End Property

    Public Property ID_NOMINA_TEMPORADA() As Integer
        Get
            Return Me._ID_NOMINA_TEMPORADA
        End Get
        Set(value As Integer)
            Me._ID_NOMINA_TEMPORADA = value
        End Set
    End Property

    Public Property FOLIO_CANASTAS() As String
        Get
            Return Me._FOLIO_CANASTAS
        End Get
        Set(ByVal value As String)
            Me._FOLIO_CANASTAS = value
        End Set
    End Property

    Public Property CODIGO_DOCUMENTO() As String
        Get
            Return Me._CODIGO_DOCUMENTO
        End Get
        Set(ByVal value As String)
            Me._CODIGO_DOCUMENTO = value
        End Set
    End Property

    Public Property CODIGO_PLAZA() As Integer
        Get
            Return Me._CODIGO_PLAZA
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_PLAZA = value
        End Set
    End Property

    Public Property CICLO() As Integer
        Get
            Return Me._CICLO
        End Get
        Set(ByVal value As Integer)
            Me._CICLO = value
        End Set
    End Property

    Public Property CODIGO_DIVISION() As Integer
        Get
            Return Me._CODIGO_DIVISION
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_DIVISION = value
        End Set
    End Property

    Public Property FECHA() As Date
        Get
            Return Me._FECHA
        End Get
        Set(ByVal value As Date)
            Me._FECHA = value
        End Set
    End Property

    Public ReadOnly Property FECHA_SERVIDOR() As Date
        Get
            Return Me._FECHA_SERVIDOR
        End Get
    End Property

    Public ReadOnly Property CODIGO_USUARIO_GRABO() As Integer
        Get
            Return Me._CODIGO_USUARIO_GRABO
        End Get
    End Property

    Public ReadOnly Property ESTATUS() As String
        Get
            Return Me._ESTATUS
        End Get
    End Property

    Public Property CONCEPTO() As String
        Get
            Return Me._CONCEPTO
        End Get
        Set(ByVal value As String)
            Me._CONCEPTO = value
        End Set
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property

    Public ReadOnly Property NOMBRE_USUARIO_GRABO() As String
        Get
            Return Me._NOMBRE_USUARIO_GRABO
        End Get
    End Property
#End Region

#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_Acuicola_Canastas_Global"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
    End Sub

    Public Sub New(ByVal FolioCanastas As String)
        Me.New()
        Me._FOLIO_CANASTAS = FolioCanastas

        Try
            If Me.Consultar = True Then
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function GrabaCanastasGlobal(ByVal sAccion As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_ACUICOLA_CANASTAS_GLOBAL_GRABA"

            Try
                sqlParametro = .Parameters.Add("@ID_ACUICOLA_CANASTAS_GLOBAL", SqlDbType.Int) : sqlParametro.Value = Me._ID_ACUICOLA_CANASTAS_GLOBAL : sqlParametro.Direction = ParameterDirection.InputOutput
                sqlParametro = .Parameters.Add("@ID_NOMINA_TEMPORADA", SqlDbType.Int) : sqlParametro.Value = Me._ID_NOMINA_TEMPORADA
                sqlParametro = .Parameters.Add("@FOLIO_CANASTAS", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_CANASTAS : sqlParametro.Direction = ParameterDirection.InputOutput
                sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_DOCUMENTO
                sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
                sqlParametro = .Parameters.Add("@CICLO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CICLO
                sqlParametro = .Parameters.Add("@CODIGO_DIVISION", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_DIVISION
                sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA
                sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
                sqlParametro = .Parameters.Add("@CONCEPTO", SqlDbType.NVarChar, 100) : sqlParametro.Value = Me._CONCEPTO
                sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = sAccion

                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True

                If sAccion = "INSERTAR" Then
                    Me._ID_ACUICOLA_CANASTAS_GLOBAL = CInt("" & .Parameters("@ID_ACUICOLA_CANASTAS_GLOBAL").Value.ToString)
                    Me._FOLIO_CANASTAS = "" & .Parameters("@FOLIO_CANASTAS").Value.ToString
                End If

            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "GrabaCanastasGlobal", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False

        Dim cmd As New SqlCommand("SELECT G.*,U1.NOMBRE_USUARIO NOMBRE_USUARIO_GRABO " &
                                  "FROM ACUICOLA_CANASTAS_GLOBAL G " &
                                  "INNER JOIN SIS_USUARIOS U1 ON(G.CODIGO_USUARIO_GRABO=U1.CODIGO_USUARIO) " &
                                  "WHERE G.FOLIO_CANASTAS='" & Me._FOLIO_CANASTAS & "'", Me._Conexion)

        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._ID_ACUICOLA_CANASTAS_GLOBAL = CInt(dReader("ID_ACUICOLA_CANASTAS_GLOBAL"))
                    Me._ID_NOMINA_TEMPORADA = CInt(dReader("ID_NOMINA_TEMPORADA"))
                    Me._FOLIO_CANASTAS = "" & dReader("FOLIO_CANASTAS").ToString()
                    Me._CODIGO_DOCUMENTO = "" & dReader("CODIGO_DOCUMENTO").ToString()
                    Me._CODIGO_PLAZA = CInt(dReader("CODIGO_PLAZA"))
                    Me._CICLO = CInt(dReader("CICLO"))
                    Me._CODIGO_DIVISION = CInt(dReader("CODIGO_DIVISION"))
                    Me._FECHA = CDate(dReader("FECHA"))
                    Me._FECHA_SERVIDOR = CDate(dReader("FECHA_SERVIDOR"))
                    Me._CODIGO_USUARIO_GRABO = CInt(dReader("CODIGO_USUARIO_GRABO"))
                    Me._NOMBRE_USUARIO_GRABO = "" & dReader("NOMBRE_USUARIO_GRABO").ToString()
                    Me._CONCEPTO = "" & dReader("CONCEPTO").ToString()
                    Me._ESTATUS = "" & dReader("ESTATUS").ToString

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With

        Return bResultado
    End Function

    Public Function Cancelar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_ACUICOLA_CANCELA_CAPTURA_GLOBAL"

            Try
                sqlParametro = .Parameters.Add("@FOLIO_CAPTURA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_CANASTAS
                sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_DOCUMENTO

                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True

            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Cancelar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function GeneraFolio() As String
        Dim sResultado As String = ""
        Try
            Me.oDocumento.CODIGO_DOCUMENTO = Me._CODIGO_DOCUMENTO
            Me.oDocumento.GeneraFolio()
            sResultado = Me.oDocumento.FOLIO
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "GeneraFolio", ex)
        End Try

        Return sResultado
    End Function

    Public Function BusquedaVisual_PorFolio() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de parámetros global."
        f.sCampo = "G.FOLIO_CANASTAS"
        f.sOrder = "G.FOLIO_CANASTAS"
        f.sTable = "ACUICOLA_CANASTAS_GLOBAL"
        f.sQl = "SELECT G.FOLIO_CANASTAS,DBO.FN_FORMAT_FECHA_CORTO(G.FECHA) FECHA,G.CONCEPTO " &
            "FROM ACUICOLA_CANASTAS_GLOBAL G " &
            "WHERE G.CODIGO_PLAZA='" & Usuario.Codigo_Plaza & "' AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "BusquedaVisual_PorFolio", ex)
        End Try
        Return Resultado
    End Function

    Public Function BusquedaVisual_Lote_ProyectoSiembra_PorNombre(sCodigoDivision As String, sCiclo As String, sTemporada As String) As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de estanques por nombre."
        f.sCampo = "L.NOMBRE_LOTE"
        f.sOrder = "L.NOMBRE_LOTE"
        f.sTable = "P.PROYECTO_SIEMBRA_ACUICOLA"
        f.sQl = "SELECT P.ID_PROYECTO_SIEMBRA,P.CODIGO_LOTE,L.NOMBRE_LOTE AS ESTANQUE FROM PROYECTO_SIEMBRA_ACUICOLA P INNER JOIN CAT_LOTES L ON(P.CODIGO_LOTE=L.CODIGO_LOTE) " & _
                "WHERE P.CODIGO_DIVISION = '" & sCodigoDivision & "' AND P.CICLO = '" & sCiclo & "' AND P.ID_NOMINA_TEMPORADA=" & sTemporada & " AND P.ESTATUS='A' AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "BusquedaVisual_Lote_ProyectoSiembra_PorNombre", ex)
        End Try
        Return Resultado
    End Function

    Public Function ObtenerDetalle() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        sSQL = "SELECT R.ID_ACUICOLA_CANASTAS_DETALLE,R.ID_PROYECTO_SIEMBRA,R.CODIGO_LOTE,L.NOMBRE_LOTE,R.CANASTAS,R.MUERTOS " &
            "FROM ACUICOLA_CANASTAS_DETALLE R " &
            "INNER JOIN CAT_LOTES L ON(R.CODIGO_LOTE=L.CODIGO_LOTE) " &
            "WHERE R.FOLIO_CANASTAS='" & sReplace(Me._FOLIO_CANASTAS) & "' " &
            "ORDER BY R.ID_ACUICOLA_CANASTAS_DETALLE"

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dTabla)

            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerDetalle", ex)
        End Try

        Return dTabla
    End Function

    Public Sub NuevoRenglon()
        Me.oDetalle = New Class_Acuicola_Canastas_Detalle
    End Sub
#End Region

End Class
