Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing

Public Class Class_Embarques_PaletsGlobal

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_EMB_PALETS_GLOBAL As Integer
    Private _FOLIO_PALET As String
    Private _CODIGO_PLAZA As Integer
    Private _FECHA As Date
    Private _FECHA_CORTE As Date
    Private _CODIGO_EMPAQUE As String
    Private _CODIGO_PRODUCTOR As String
    Private _CODIGO_PROVEEDOR_ENVASE As String
    'Private _CODIGO_LOTE As String
    Private _ORIGEN As String
    Private _ES_CHEP_PALET As Boolean
    Private _PESO_TOTAL_PALET As Double
    Private _CANTIDAD_TOTAL_PALET As Integer
    Private _ESTA_EMBARCADO As String
    Private _CODIGO_USUARIO_GRABO As Integer
    Private _NOMBRE_USUARIO_GRABO As String
    Private _IMPORTE_TOTAL_PALET As Double
    Private _ESTATUS As String
    Private _CODIGO_USUARIO_CANCELO As Integer
    Private _NOMBRE_USUARIO_CANCELO As String
    Private _FECHA_CANCELO As Date
    Private _CODIGO_USUARIO_ARMADO As Integer
    Private _NOMBRE_USUARIO_ARMADO As String
    Private _FECHA_ARMADO_SERVIDOR As Date
    Private _SALIDA_EMPAQUE_GENERADA As String
    Private _ES_MIXTO As String
    Private _GENERARA_SALIDA As String
    Private _CODIGO_CENTRO_COSTO As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
    Private _CODIGO_ALMACEN As String
#End Region

#Region "Clase Detalle"
    Public oPaletsDetalle As New Class_Embarques_PaletsDetalle
#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public ReadOnly Property ID_EMB_PALETS_GLOBAL() As Integer
        Get
            Return Me._ID_EMB_PALETS_GLOBAL
        End Get
    End Property

    Public Property FOLIO_PALET() As String
        Get
            Return Me._FOLIO_PALET
        End Get
        Set(ByVal value As String)
            Me._FOLIO_PALET = value
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

    Public Property CODIGO_EMPAQUE() As String
        Get
            Return Me._CODIGO_EMPAQUE
        End Get
        Set(ByVal value As String)
            Me._CODIGO_EMPAQUE = value
        End Set
    End Property

    Public Property CODIGO_PRODUCTOR() As String
        Get
            Return Me._CODIGO_PRODUCTOR
        End Get
        Set(ByVal value As String)
            Me._CODIGO_PRODUCTOR = value
        End Set
    End Property

    Public Property CODIGO_PROVEEDOR_ENVASE() As String
        Get
            Return Me._CODIGO_PROVEEDOR_ENVASE
        End Get
        Set(ByVal value As String)
            Me._CODIGO_PROVEEDOR_ENVASE = value
        End Set
    End Property

    'Public Property CODIGO_LOTE() As String
    '    Get
    '        Return Me._CODIGO_LOTE
    '    End Get
    '    Set(ByVal value As String)
    '        Me._CODIGO_LOTE = value
    '    End Set
    'End Property

    Public Property ORIGEN() As String
        Get
            Return Me._ORIGEN
        End Get
        Set(ByVal value As String)
            Me._ORIGEN = value
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

    Public Property FECHA_CORTE() As Date
        Get
            Return Me._FECHA_CORTE
        End Get
        Set(ByVal value As Date)
            Me._FECHA_CORTE = value
        End Set
    End Property

    Public Property ES_CHEP_PALET() As Boolean
        Get
            Return Me._ES_CHEP_PALET
        End Get
        Set(ByVal value As Boolean)
            Me._ES_CHEP_PALET = value
        End Set
    End Property

    Public Property PESO_TOTAL_PALET() As Double
        Get
            Return Me._PESO_TOTAL_PALET
        End Get
        Set(ByVal value As Double)
            Me._PESO_TOTAL_PALET = value
        End Set
    End Property

    Public Property CANTIDAD_TOTAL_PALET() As Integer
        Get
            Return Me._CANTIDAD_TOTAL_PALET
        End Get
        Set(ByVal value As Integer)
            Me._CANTIDAD_TOTAL_PALET = value
        End Set
    End Property

    Public Property ESTA_EMBARCADO() As String
        Get
            Return Me._ESTA_EMBARCADO
        End Get
        Set(ByVal value As String)
            Me._ESTA_EMBARCADO = value
        End Set
    End Property

    Public Property CODIGO_USUARIO_GRABO() As Integer
        Get
            Return Me._CODIGO_USUARIO_GRABO
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_USUARIO_GRABO = value
        End Set
    End Property

    Public ReadOnly Property NOMBRE_USUARIO_GRABO() As String
        Get
            Return Me._NOMBRE_USUARIO_GRABO
        End Get
    End Property

    Public Property IMPORTE_TOTAL_PALET() As Double
        Get
            Return Me._IMPORTE_TOTAL_PALET
        End Get
        Set(ByVal value As Double)
            Me._IMPORTE_TOTAL_PALET = value
        End Set
    End Property

    Public Property ESTATUS() As String
        Get
            Return Me._ESTATUS
        End Get
        Set(ByVal value As String)
            Me._ESTATUS = value
        End Set
    End Property

    Public Property CODIGO_USUARIO_CANCELO() As Integer
        Get
            Return Me._CODIGO_USUARIO_CANCELO
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_USUARIO_CANCELO = value
        End Set
    End Property

    Public ReadOnly Property NOMBRE_USUARIO_CANCELO() As String
        Get
            Return Me._NOMBRE_USUARIO_CANCELO
        End Get
    End Property

    Public Property FECHA_CANCELO() As Date
        Get
            Return Me._FECHA_CANCELO
        End Get
        Set(ByVal value As Date)
            Me._FECHA_CANCELO = value
        End Set
    End Property

    Public Property CODIGO_USUARIO_ARMADO() As Integer
        Get
            Return Me._CODIGO_USUARIO_ARMADO
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_USUARIO_ARMADO = value
        End Set
    End Property

    Public ReadOnly Property NOMBRE_USUARIO_ARMADO() As String
        Get
            Return Me._NOMBRE_USUARIO_ARMADO
        End Get
    End Property

    Public Property FECHA_ARMADO_SERVIDOR() As Date
        Get
            Return Me._FECHA_ARMADO_SERVIDOR
        End Get
        Set(ByVal value As Date)
            Me._FECHA_ARMADO_SERVIDOR = value
        End Set
    End Property

    Public ReadOnly Property SALIDA_EMPAQUE_GENERADA() As String
        Get
            Return Me._SALIDA_EMPAQUE_GENERADA
        End Get
    End Property

    Public Property ES_MIXTO() As String
        Get
            Return Me._ES_MIXTO
        End Get
        Set(ByVal value As String)
            Me._ES_MIXTO = value
        End Set
    End Property

    Public Property GENERARA_SALIDA() As String
        Get
            Return Me._GENERARA_SALIDA
        End Get
        Set(ByVal value As String)
            Me._GENERARA_SALIDA = value
        End Set
    End Property

    Public Property CODIGO_CENTRO_COSTO() As String
        Get
            Return Me._CODIGO_CENTRO_COSTO
        End Get
        Set(ByVal value As String)
            Me._CODIGO_CENTRO_COSTO = value
        End Set
    End Property

#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property

    Public ReadOnly Property CODIGO_ALMACEN() As String
        Get
            Return Me._CODIGO_ALMACEN
        End Get
    End Property
#End Region

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_Embarques_PaletsGlobal"
        End Get
    End Property
#End Region

#End Region

    Private WithEvents pDocument As New PrintDocument
    Private stringToPrint As String
    Private fFont As Font

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "EMB_PALETS_GLOBAL"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion

        Me._QuerySelect = "SELECT G.*,U.NOMBRE_USUARIO NOMBRE_USUARIO_GRABO,U2.NOMBRE_USUARIO NOMBRE_USUARIO_CANCELO,U3.NOMBRE_USUARIO NOMBRE_USUARIO_ARMADO,E.CODIGO_ALMACEN CODIGO_ALMACEN " & _
                            "FROM EMB_PALETS_GLOBAL G " & _
                            "INNER JOIN CAT_EMPAQUES E ON(G.CODIGO_EMPAQUE=E.CODIGO_EMPAQUE)" & _
                            "INNER JOIN SIS_USUARIOS U ON(G.CODIGO_USUARIO_GRABO=U.CODIGO_USUARIO) " & _
                            "LEFT JOIN SIS_USUARIOS U2 ON(G.CODIGO_USUARIO_CANCELO=U2.CODIGO_USUARIO) " & _
                            "LEFT JOIN SIS_USUARIOS U3 ON(G.CODIGO_USUARIO_ARMADO=U3.CODIGO_USUARIO) "

        Me.oPaletsDetalle = New Class_Embarques_PaletsDetalle
    End Sub

    Public Sub New(ByVal folioPatel As String)
        Me.New()
        Me._FOLIO_PALET = folioPatel
        'Me.oPaletsDetalle = New Class_Contabilidad_Detalle_Poliza
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
    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE G.FOLIO_PALET='" & Me._FOLIO_PALET.ToString & "' AND G.CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA & " ", Me._Conexion)
        Dim dReader As SqlDataReader
        'Dim sqlParametro As SqlParameter
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()

                dReader = .ExecuteReader()
                If dReader.Read Then
                    Me._ID_EMB_PALETS_GLOBAL = CType(dReader("ID_EMB_PALETS_GLOBAL"), Integer)
                    Me._FOLIO_PALET = CType(dReader("FOLIO_PALET"), String)
                    Me._CODIGO_PLAZA = CType(dReader("CODIGO_PLAZA"), Integer)
                    Me._CODIGO_EMPAQUE = Trim("" & dReader("CODIGO_EMPAQUE").ToString)
                    Me._CODIGO_PRODUCTOR = Trim("" & dReader("CODIGO_PRODUCTOR").ToString)
                    Me._CODIGO_PROVEEDOR_ENVASE = Trim("" & dReader("CODIGO_PROVEEDOR_ENVASE").ToString)
                    'Me._CODIGO_LOTE = Trim("" & dReader("CODIGO_LOTE").ToString)
                    Me._ORIGEN = Trim("" & dReader("ORIGEN").ToString)
                    Me._FECHA = CType(dReader("FECHA"), Date)
                    Me._FECHA_CORTE = CType(dReader("FECHA_CORTE"), Date)
                    Me._ES_CHEP_PALET = CType(dReader("ES_CHEP_PALET"), Boolean)
                    Me._PESO_TOTAL_PALET = valorNumerico(dReader("PESO_TOTAL_PALET").ToString)
                    Me._CANTIDAD_TOTAL_PALET = CType(dReader("CANTIDAD_TOTAL_PALET"), Integer)
                    Me._ESTA_EMBARCADO = dReader("ESTA_EMBARCADO").ToString
                    Me._CODIGO_USUARIO_GRABO = CType(dReader("CODIGO_USUARIO_GRABO"), Integer)
                    Me._NOMBRE_USUARIO_GRABO = CType(dReader("NOMBRE_USUARIO_GRABO"), String)
                    Me._IMPORTE_TOTAL_PALET = CType(dReader("IMPORTE_TOTAL_PALET"), Double)
                    Me._ESTATUS = CType(dReader("ESTATUS"), String)
                    If Me._ESTATUS = "C" Then
                        Me._CODIGO_USUARIO_CANCELO = CType(dReader("CODIGO_USUARIO_CANCELO"), Integer)
                        Me._NOMBRE_USUARIO_CANCELO = CType(dReader("NOMBRE_USUARIO_CANCELO"), String)
                        Me._FECHA_CANCELO = CType(dReader("FECHA_DE_CANCELACION_SERVIDOR"), Date)
                    End If
                    If Me._ESTATUS = "A" Then
                        'IIf(txtLEN(dRow("PRODUCTO2_PESO").ToString) = True, CInt("0" & dRow("PRODUCTO2_PESO").ToString).ToString, "").ToString & "^FS")
                        Me._CODIGO_USUARIO_ARMADO = CInt(IIf(txtLEN(dReader("CODIGO_USUARIO_ARMADO").ToString) = True, CInt("0" & dReader("CODIGO_USUARIO_ARMADO").ToString), "0"))
                        Me._NOMBRE_USUARIO_ARMADO = Trim("" & dReader("NOMBRE_USUARIO_ARMADO").ToString)
                        If txtLEN(dReader("FECHA_ARMADO_SERVIDOR").ToString) = True Then
                            Me._FECHA_ARMADO_SERVIDOR = CType(dReader("FECHA_ARMADO_SERVIDOR").ToString, Date)
                        Else
                            Me._FECHA_ARMADO_SERVIDOR = CType(dReader("FECHA"), Date)
                        End If
                    End If
                    Me._SALIDA_EMPAQUE_GENERADA = CType(dReader("SALIDA_EMPAQUE_GENERADA"), String)
                    Me._CODIGO_ALMACEN = CType(dReader("CODIGO_ALMACEN"), String)
                    Me._GENERARA_SALIDA = CType(dReader("GENERARA_SALIDA"), String)
                    Me._CODIGO_CENTRO_COSTO = dReader("CODIGO_CENTRO_COSTO").ToString

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

    Public Function Insertar(Optional ByVal bRegenera As Boolean = True) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMB_PALETS_GLOBAL_GRABA"

            sqlParametro = .Parameters.Add("@FOLIO_PALET", SqlDbType.NVarChar, 15) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = Me._FOLIO_PALET
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA
            sqlParametro = .Parameters.Add("@FECHA_CORTE", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_CORTE
            sqlParametro = .Parameters.Add("@CODIGO_EMPAQUE", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_EMPAQUE
            sqlParametro = .Parameters.Add("@CODIGO_PRODUCTOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me.CODIGO_PRODUCTOR
            sqlParametro = .Parameters.Add("@CODIGO_PROVEEDOR_ENVASE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_PROVEEDOR_ENVASE
            'sqlParametro = .Parameters.Add("@CODIGO_LOTE", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_LOTE
            sqlParametro = .Parameters.Add("@ORIGEN", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._ORIGEN
            sqlParametro = .Parameters.Add("@ES_CHEP_PALET", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(Me._ES_CHEP_PALET).ToString
            sqlParametro = .Parameters.Add("@PESO_TOTAL_PALET", SqlDbType.Decimal) : sqlParametro.Value = Me._PESO_TOTAL_PALET
            sqlParametro = .Parameters.Add("@CANTIDAD_TOTAL_PALET", SqlDbType.Int) : sqlParametro.Value = Me._CANTIDAD_TOTAL_PALET
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@IMPORTE_TOTAL_PALET", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPORTE_TOTAL_PALET
            sqlParametro = .Parameters.Add("@ES_MIXTO", SqlDbType.Char, 1) : sqlParametro.Value = Me._ES_MIXTO
            sqlParametro = .Parameters.Add("@GENERARA_SALIDA", SqlDbType.Char, 1) : sqlParametro.Value = Me._GENERARA_SALIDA
            sqlParametro = .Parameters.Add("@CODIGO_CENTRO_COSTO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CENTRO_COSTO
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = "INSERTAR"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._FOLIO_PALET = "" & .Parameters("@FOLIO_PALET").Value.ToString
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Insertar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function Actualizar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMB_PALETS_GLOBAL_GRABA"

            sqlParametro = .Parameters.Add("@FOLIO_PALET", SqlDbType.NVarChar, 15) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = Me._FOLIO_PALET
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA
            sqlParametro = .Parameters.Add("@FECHA_CORTE", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_CORTE
            sqlParametro = .Parameters.Add("@CODIGO_EMPAQUE", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_EMPAQUE
            sqlParametro = .Parameters.Add("@CODIGO_PRODUCTOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me.CODIGO_PRODUCTOR
            sqlParametro = .Parameters.Add("@CODIGO_PROVEEDOR_ENVASE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_PROVEEDOR_ENVASE
            'sqlParametro = .Parameters.Add("@CODIGO_LOTE", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_LOTE
            sqlParametro = .Parameters.Add("@ORIGEN", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._ORIGEN
            sqlParametro = .Parameters.Add("@ES_CHEP_PALET", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(Me._ES_CHEP_PALET).ToString
            sqlParametro = .Parameters.Add("@PESO_TOTAL_PALET", SqlDbType.Decimal) : sqlParametro.Value = Me._PESO_TOTAL_PALET
            sqlParametro = .Parameters.Add("@CANTIDAD_TOTAL_PALET", SqlDbType.Int) : sqlParametro.Value = Me._CANTIDAD_TOTAL_PALET
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_GRABO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@IMPORTE_TOTAL_PALET", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPORTE_TOTAL_PALET
            sqlParametro = .Parameters.Add("@ES_MIXTO", SqlDbType.Char, 1) : sqlParametro.Value = Me._ES_MIXTO
            sqlParametro = .Parameters.Add("@GENERARA_SALIDA", SqlDbType.Char, 1) : sqlParametro.Value = Me._GENERARA_SALIDA
            sqlParametro = .Parameters.Add("@CODIGO_CENTRO_COSTO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CENTRO_COSTO
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 20) : sqlParametro.Value = "ACTUALIZAR"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._FOLIO_PALET = "" & .Parameters("@FOLIO_PALET").Value.ToString
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Actualizar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function CancelarPalet() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMB_PALET_CANCELA"

            sqlParametro = .Parameters.Add("@FOLIO_PALET", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_PALET
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_CANCELO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@FECHA_DE_CANCELACION", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_CANCELO

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "CancelarPalet", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function Armado(ByVal bAccion As Boolean) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMB_PALET_ARMADO"

            sqlParametro = .Parameters.Add("@FOLIO_PALET", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_PALET
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_ARMADO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(bAccion)

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Armado", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function ObtenerDetalle() As DataTable
        Dim dTabla As New DataTable("detalle"), da As SqlDataAdapter
        Dim sSQL As String

        sSQL = "SELECT D.CODIGO_ARTICULO,A.DESCRIPCION,D.CANTIDAD_BULTOS_DETALLE,D.PRECIO_UNIDAD_BULTO,D.PESO_UNIDAD_BULTO,D.IMPORTE_BULTOS_DETALLE,D.PESO_BULTOS_DETALLE " & _
               "FROM EMB_PALETS_DETALLE D " & _
               "INNER JOIN CAT_ARTICULOS A ON(D.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " & _
               "WHERE D.FOLIO_PALET='" & Me._FOLIO_PALET & "' " & _
               "ORDER BY D.ID_EMB_PALETS_DETALLE"
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
        Me.oPaletsDetalle = New Class_Embarques_PaletsDetalle
    End Sub

    Public Function FolioSiguiente() As String
        Dim sResultado As String = ""
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_UTILERIAS_GENERA_FOLIO_DOCUMENTO"

            sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = "PLT" & Usuario.Codigo_Plaza.ToString
            sqlParametro = .Parameters.Add("@VFOLIO", SqlDbType.NVarChar, 16) : sqlParametro.Direction = ParameterDirection.Output : sqlParametro.Value = Me._FOLIO_PALET

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._FOLIO_PALET = "" & .Parameters("@VFOLIO").Value.ToString
                sResultado = "" & .Parameters("@VFOLIO").Value.ToString
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "FolioSiguiente", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return sResultado
    End Function

    Public Function BusquedaVisual_Palets() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de palet."
        f.sCampo = "G.FOLIO_PALET"
        f.sOrder = "ID_EMB_PALETS_GLOBAL"
        f.sTable = "EMB_PALETS_GLOBAL"
        f.sQl = "SELECT G.FOLIO_PALET,A.DESCRIPCION,CANTIDAD_TOTAL_PALET,PESO_TOTAL_PALET,IMPORTE_TOTAL_PALET " & _
        "FROM EMB_PALETS_GLOBAL G inner join EMB_PALETS_DETALLE D ON (G.FOLIO_PALET=D.FOLIO_PALET) " & _
        "INNER JOIN CAT_ARTICULOS A ON(D.CODIGO_ARTICULO=A.CODIGO_ARTICULO) " & _
        "WHERE G.ESTA_EMBARCADO=0 AND G.ESTATUS='A' AND G.CODIGO_PLAZA= " & Usuario.Codigo_Plaza.ToString & " AND "

        f.arrayWidthColumns = New Integer() {150, 700, 140, 140, 140}

        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "BusquedaVisual_Palets", ex)
        End Try
        Return Resultado
    End Function

    Public Function MarcaSalidaPalet(Optional ByVal bMarcar As Boolean = True) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMB_GENERA_MARCA_SALIDA_PALET"

            sqlParametro = .Parameters.Add("@FOLIO_PALET", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_PALET
            sqlParametro = .Parameters.Add("@MARCAR", SqlDbType.NVarChar, 1) : sqlParametro.Value = Convert.ToInt32(bMarcar)

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "MarcaSalidaPalet", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function ObtenerDetalleSalidaInventario(ByVal sFolioEmbarque As String) As System.Data.DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter("MP_EMB_EMBARQUE_GENERA_SALIDA_MATERIAL_EMPAQUE", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            With da.SelectCommand
                .Parameters.Add("@FOLIO_EMBARQUE", SqlDbType.NVarChar, 15).Value = sFolioEmbarque
                .Parameters.Add("@FOLIO_PALET", SqlDbType.NVarChar, 15).Value = Me._FOLIO_PALET
            End With

            da.Fill(dt)
            'dt.Columns.Add("TOTALES")
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerDetalleSalidaInventario", ex)
        Finally

        End Try
        Return dt
    End Function

    Public Function GestionaEtiquetasPalets(ByVal sFolioPalet1 As String, ByVal sFolioPalet2 As String, ByVal fFont As Font, ByVal sNombreImpresora As String) As Boolean
        Dim dt As New DataTable
        Try
            Me.fFont = fFont

            Dim da As New SqlDataAdapter("MP_EMB_PALETS_GENERA_ETIQUETAS", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            With da.SelectCommand
                .Parameters.Add("@FOLIO_PALET_1", SqlDbType.NVarChar, 15).Value = sFolioPalet1
                .Parameters.Add("@FOLIO_PALET_2", SqlDbType.NVarChar, 15).Value = sFolioPalet2
            End With

            da.Fill(dt)

            MsgBox(sFolioPalet1 & "-" & sFolioPalet2)
            MsgBox(dt.Rows.Count.ToString)


            Dim btAPP As BarTender.Application
            Dim btFormat As BarTender.Format
            Dim btMsgs As BarTender.Messages
            btAPP = New BarTender.Application

            For Each dRow As DataRow In dt.Rows

                'Me.GeneraEtiquetaPaletBartender(dRow, sNombreImpresora)

                Dim sFormatoEtiqueta As String = My.Settings.Ruta & "\Etiquetas\Palet.btw"

                'btFormat = btAPP.Formats.Open(sFormatoEtiqueta, False, "Bar Code Printer T-0612")
                btFormat = btAPP.Formats.Open(sFormatoEtiqueta, False, sNombreImpresora)

                btFormat.SetNamedSubStringValue("objCodigoBarras", dRow("FOLIO_PALET").ToString)
                btFormat.SetNamedSubStringValue("objProductoCompleto", dRow("PRODUCTO_COMPLETO").ToString)
                btFormat.SetNamedSubStringValue("objProducto", dRow("NOMBRE_PRODUCTO").ToString)
                btFormat.SetNamedSubStringValue("objEtiqueta", dRow("NOMBRE_ETIQUETA").ToString)
                btFormat.SetNamedSubStringValue("objEnvase", dRow("NOMBRE_ENVASE").ToString)
                btFormat.SetNamedSubStringValue("objTamanio", dRow("NOMBRE_TAMAÑO").ToString)
                btFormat.SetNamedSubStringValue("objCajas", dRow("CAJAS").ToString)

                'For i As Integer = 1 To btFormat.NamedSubStrings.Count
                '    If btFormat.NamedSubStrings.Item(CObj(i)).Name = "objMalla" Then 'Con esta validación se revisa si la equeta tiene el objecto indicado
                '        btFormat.SetNamedSubStringValue("objMalla", Me.txtMalla.Text)
                '    End If
                'Next

                btFormat.PrintSetup.IdenticalCopiesOfLabel = 1
                btFormat.Print("Job1", True, -1, btMsgs)
                btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)


                'Estilo anterior
                'If Me.GeneraEtiquetaPalet(dRow) = True Then
                '    Me.pDocument.PrinterSettings.Copies = 1
                '    Me.pDocument.PrinterSettings.PrinterName = "Generic / Text Only2"
                '    Me.pDocument.Print()
                'End If
            Next

            btAPP.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(btAPP)

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "GestionaEtiquetasPalets", ex)
        Finally

        End Try
    End Function

    Public Function GestionaEtiquetasCajas(ByVal sFolioPalet1 As String, ByVal sFolioPalet2 As String, ByVal fFont As Font, ByVal sNombreImpresora As String) As Boolean
        Dim dt As New DataTable
        Try
            Me.fFont = fFont

            Dim da As New SqlDataAdapter("MP_EMB_PALETS_GENERA_ETIQUETAS_CAJAS", Me._Conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            With da.SelectCommand
                .Parameters.Add("@FOLIO_PALET_1", SqlDbType.NVarChar, 15).Value = sFolioPalet1
                .Parameters.Add("@FOLIO_PALET_2", SqlDbType.NVarChar, 15).Value = sFolioPalet2
            End With

            da.Fill(dt)

            Dim sVoicePicker1 As String = "", sVoicePicker2 As String = ""
            Dim btAPP As BarTender.Application
            Dim btFormat As BarTender.Format
            Dim btMsgs As BarTender.Messages

            Dim sFormatoEtiqueta As String = My.Settings.Ruta & "\Etiquetas\Caja.btw"

            btAPP = New BarTender.Application
            'btFormat = btAPP.Formats.Open(sFormatoEtiqueta, False, "Bar Code Printer T-0612")
            btFormat = btAPP.Formats.Open(sFormatoEtiqueta, False, sNombreImpresora)

            For Each dRow As DataRow In dt.Rows
                'Me.GeneraEtiquetaCajaBartender(dRow, sNombreImpresora)

                btFormat.SetNamedSubStringValue("objLote", dRow("CODIGO_LOTE").ToString)
                btFormat.SetNamedSubStringValue("objCodigoTrazabilidad", dRow("CODIGO_TRAZABILIDAD").ToString)
                btFormat.SetNamedSubStringValue("objProductoCompleto", dRow("PRODUCTO_COMPLETO").ToString)
                btFormat.SetNamedSubStringValue("objPalet", dRow("FOLIO_PALET").ToString)

                sVoicePicker1 = Class_Embarques_PTI.VoicePicker1("00000000000000", dRow("CODIGO_LOTE").ToString, CDate(dRow("FECHA_EMPAQUE")))
                sVoicePicker2 = Class_Embarques_PTI.VoicePicker2("00000000000000", dRow("CODIGO_LOTE").ToString, CDate(dRow("FECHA_EMPAQUE")))

                btFormat.SetNamedSubStringValue("objVoicePicker1", sVoicePicker1)
                btFormat.SetNamedSubStringValue("objVoicePicker2", "  " & sVoicePicker2) 'Se agrega primero un espacio doble

                If txtLEN(sVoicePicker1) = False Then
                    MsgBox("No se logró generar la 1era parte del voice picker.", MsgBoxStyle.Exclamation, Me.Nombre_Clase)
                    Exit Function
                End If

                If txtLEN(sVoicePicker1) = False Then
                    MsgBox("No se logró generar la 2da parte del voice picker.", MsgBoxStyle.Exclamation, Me.Nombre_Clase)
                    Exit Function
                End If

                btFormat.PrintSetup.IdenticalCopiesOfLabel = 1
                btFormat.Print("Job1", True, -1, btMsgs)


            Next

            btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
            btAPP.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(btAPP)

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "GestionaEtiquetasCajas", ex)
        Finally

        End Try
    End Function

    Private Function GeneraEtiquetaPaletBartender(ByVal dRow As DataRow, ByVal sNombreImpresora As String) As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim btAPP As BarTender.Application
            Dim btFormat As BarTender.Format
            Dim btMsgs As BarTender.Messages

            Dim sFormatoEtiqueta As String = My.Settings.Ruta & "\Etiquetas\Palet.btw"

            btAPP = New BarTender.Application
            'btFormat = btAPP.Formats.Open(sFormatoEtiqueta, False, "Bar Code Printer T-0612")
            btFormat = btAPP.Formats.Open(sFormatoEtiqueta, False, sNombreImpresora)

            btFormat.SetNamedSubStringValue("objCodigoBarras", dRow("FOLIO_PALET").ToString)
            btFormat.SetNamedSubStringValue("objProductoCompleto", dRow("PRODUCTO_COMPLETO").ToString)
            btFormat.SetNamedSubStringValue("objProducto", dRow("NOMBRE_PRODUCTO").ToString)
            btFormat.SetNamedSubStringValue("objEtiqueta", dRow("NOMBRE_ETIQUETA").ToString)
            btFormat.SetNamedSubStringValue("objEnvase", dRow("NOMBRE_ENVASE").ToString)
            btFormat.SetNamedSubStringValue("objTamanio", dRow("NOMBRE_TAMAÑO").ToString)
            btFormat.SetNamedSubStringValue("objCajas", dRow("CAJAS").ToString)

            'For i As Integer = 1 To btFormat.NamedSubStrings.Count
            '    If btFormat.NamedSubStrings.Item(CObj(i)).Name = "objMalla" Then 'Con esta validación se revisa si la equeta tiene el objecto indicado
            '        btFormat.SetNamedSubStringValue("objMalla", Me.txtMalla.Text)
            '    End If
            'Next

            btFormat.PrintSetup.IdenticalCopiesOfLabel = 1
            btFormat.Print("Job1", True, -1, btMsgs)
            btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
            btAPP.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(btAPP)

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "GeneraEtiquetaPaletBartender", ex)
        End Try
        Return bResultado
    End Function

    Private Function GeneraEtiquetaCajaBartender(ByVal dRow As DataRow, ByVal sNombreImpresora As String) As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim sVoicePicker1 As String = "", sVoicePicker2 As String = ""
            Dim btAPP As BarTender.Application
            Dim btFormat As BarTender.Format
            Dim btMsgs As BarTender.Messages

            Dim sFormatoEtiqueta As String = My.Settings.Ruta & "\Etiquetas\Caja.btw"

            btAPP = New BarTender.Application
            'btFormat = btAPP.Formats.Open(sFormatoEtiqueta, False, "Bar Code Printer T-0612")
            btFormat = btAPP.Formats.Open(sFormatoEtiqueta, False, sNombreImpresora)

            btFormat.SetNamedSubStringValue("objCodigoBarras", dRow("FOLIO_PALET").ToString)
            btFormat.SetNamedSubStringValue("objCodigoTrazabilidad", dRow("CODIGO_TRAZABILIDAD").ToString)
            btFormat.SetNamedSubStringValue("objProductoCompleto", dRow("PRODUCTO_COMPLETO").ToString)

            sVoicePicker1 = Class_Embarques_PTI.VoicePicker1("00000000000000", dRow("FOLIO_PALET").ToString, CDate(dRow("FECHA_EMPAQUE")))
            sVoicePicker2 = Class_Embarques_PTI.VoicePicker2("00000000000000", dRow("FOLIO_PALET").ToString, CDate(dRow("FECHA_EMPAQUE")))

            btFormat.SetNamedSubStringValue("objVoicePicker1", sVoicePicker1)
            btFormat.SetNamedSubStringValue("objVoicePicker2", "  " & sVoicePicker2) 'Se agrega primero un espacio doble

            If txtLEN(sVoicePicker1) = False Then
                MsgBox("No se logró generar la 1era parte del voice picker.", MsgBoxStyle.Exclamation, Me.Nombre_Clase)
                Exit Function
            End If

            If txtLEN(sVoicePicker1) = False Then
                MsgBox("No se logró generar la 2da parte del voice picker.", MsgBoxStyle.Exclamation, Me.Nombre_Clase)
                Exit Function
            End If

            btFormat.PrintSetup.IdenticalCopiesOfLabel = 1
            btFormat.Print("Job1", True, -1, btMsgs)
            btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
            btAPP.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(btAPP)

            bResultado = True
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "GeneraEtiquetaCajaBartender", ex)
        End Try
        Return bResultado
    End Function


    Private Function GeneraEtiquetaPalet(ByVal dRow As DataRow) As Boolean
        Dim sArchivo As String = My.Settings.Ruta & "\etiqueta_palet.prn"

        Try
            Dim sw As New StreamWriter(sArchivo, False) ',  System.Text.Encoding.Unicode) 

            sw.WriteLine("CT~~CD,~CC^~CT~")
            sw.WriteLine("^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR4,4~SD15^JUS^LRN^CI0^XZ")
            sw.WriteLine("^XA")
            sw.WriteLine("^MMT")
            sw.WriteLine("^PW783")
            sw.WriteLine("^LL1215")
            sw.WriteLine("^LS0")
            sw.WriteLine("^FT772,936^A0I,28,28^FH\^FD" & dRow("PRODUCTO1_DESCRIPCION_EXTRANJERA_PARTE_1").ToString & "^FS")
            sw.WriteLine("^FT772,902^A0I,28,28^FH\^FD" & dRow("PRODUCTO1_DESCRIPCION_EXTRANJERA_PARTE_2").ToString & "^FS")
            sw.WriteLine("^FT108,863^A0I,28,28^FH\^FD" & FormatNumber(dRow("PESO_TOTAL_PALET").ToString, 0).ToString & "^FS")
            sw.WriteLine("^FT85,929^A0I,28,28^FH\^FD" & IIf(txtLEN(dRow("PRODUCTO2_PESO").ToString) = True, CInt("0" & dRow("PRODUCTO2_PESO").ToString).ToString, "").ToString & "^FS")
            sw.WriteLine("^FT199,863^A0I,28,28^FH\^FD" & dRow("CANTIDAD_TOTAL_PALET").ToString & "^FS")
            sw.WriteLine("^FT185,929^A0I,28,28^FH\^FD" & IIf(txtLEN(dRow("PRODUCTO2_CANTIDAD_TOTAL_PALET").ToString) = True, CInt("0" & dRow("PRODUCTO2_CANTIDAD_TOTAL_PALET").ToString), "").ToString & "^FS")
            sw.WriteLine("^FT89,1002^A0I,28,28^FH\^FD" & CInt(dRow("PRODUCTO1_PESO").ToString).ToString & "^FS")
            sw.WriteLine("^FT189,1002^A0I,28,28^FH\^FD" & dRow("PRODUCTO1_CANTIDAD_TOTAL_PALET").ToString & "^FS")
            sw.WriteLine("^FT122,1068^A0I,28,28^FH\^FDPESO :^FS")
            sw.WriteLine("^FT543,863^A0I,28,28^FH\^FDTOTAL :^FS")
            sw.WriteLine("^FT247,1069^A0I,28,28^FH\^FDCAJAS :^FS")
            sw.WriteLine("^FT748,578^A0I,23,26^FH\^FD" & dRow("PRODUCTO1_DESCRIPCION_EXTRANJERA_PARTE_1").ToString & "^FS")
            sw.WriteLine("^FT748,550^A0I,23,26^FH\^FD" & dRow("PRODUCTO1_DESCRIPCION_EXTRANJERA_PARTE_2").ToString & "^FS")

            sw.WriteLine("^FT748,181^A0I,23,26^FH\^FD" & dRow("PRODUCTO1_DESCRIPCION_EXTRANJERA_PARTE_1").ToString & "^FS")
            sw.WriteLine("^FT748,153^A0I,23,26^FH\^FD" & dRow("PRODUCTO1_DESCRIPCION_EXTRANJERA_PARTE_2").ToString & "^FS")

            sw.WriteLine("^FT323,578^A0I,23,26^FH\^FD" & dRow("PRODUCTO1_DESCRIPCION_EXTRANJERA_PARTE_1").ToString & "^FS")
            sw.WriteLine("^FT323,550^A0I,23,26^FH\^FD" & dRow("PRODUCTO1_DESCRIPCION_EXTRANJERA_PARTE_2").ToString & "^FS")

            sw.WriteLine("^FT323,181^A0I,23,26^FH\^FD" & dRow("PRODUCTO1_DESCRIPCION_EXTRANJERA_PARTE_1").ToString & "^FS")
            sw.WriteLine("^FT323,153^A0I,23,26^FH\^FD" & dRow("PRODUCTO1_DESCRIPCION_EXTRANJERA_PARTE_2").ToString & "^FS")

            sw.WriteLine("^FT748,381^A0I,23,26^FH\^FD" & dRow("PRODUCTO1_DESCRIPCION_EXTRANJERA_PARTE_1").ToString & "^FS")
            sw.WriteLine("^FT748,353^A0I,23,26^FH\^FD" & dRow("PRODUCTO1_DESCRIPCION_EXTRANJERA_PARTE_2").ToString & "^FS")

            sw.WriteLine("^FT323,381^A0I,23,26^FH\^FD" & dRow("PRODUCTO1_DESCRIPCION_EXTRANJERA_PARTE_1").ToString & "^FS")
            sw.WriteLine("^FT323,353^A0I,23,26^FH\^FD" & dRow("PRODUCTO1_DESCRIPCION_EXTRANJERA_PARTE_2").ToString & "^FS")

            sw.WriteLine("^FT771,1008^A0I,28,28^FH\^FD" & dRow("PRODUCTO2_DESCRIPCION_EXTRANJERA_PARTE_1").ToString & "^FS")
            sw.WriteLine("^FT771,974^A0I,28,28^FH\^FD" & dRow("PRODUCTO2_DESCRIPCION_EXTRANJERA_PARTE_2").ToString & "^FS")

            sw.WriteLine("^FT668,1091^A0I,28,28^FH\^FD" & dRow("NOMBRE_LOTE").ToString & "^FS")
            sw.WriteLine("^FT765,1091^A0I,28,28^FH\^FDLOTE :^FS")
            sw.WriteLine("^FT667,1130^A0I,28,28^FH\^FD" & dRow("NOMBRE_EMPAQUE").ToString & "^FS")
            sw.WriteLine("^FT765,1129^A0I,28,28^FH\^FDEMPQ:^FS")
            sw.WriteLine("^FT667,1169^A0I,28,28^FH\^FD" & dRow("NOMBRE_PRODUCTOR").ToString & "^FS")
            sw.WriteLine("^FT765,1168^A0I,28,28^FH\^FDPROD :^FS")
            sw.WriteLine("^FT759,659^A0I,28,28^FH\^FD" & dRow("NOMBRE_CULTIVO").ToString & "^FS")
            sw.WriteLine("^FT760,696^A0I,28,28^FH\^FDPALLET :^FS")
            sw.WriteLine("^FT396,1130^A0I,28,28^FH\^FDFECHA :^FS")
            sw.WriteLine("^FT295,1130^A0I,28,28^FH\^FD" & UCase(Format(CDate(dRow("FECHA").ToString), "dd/MMM/yy")) & "^FS")
            sw.WriteLine("^BY3,3,46^FT229,671^BCI,,Y,N")
            sw.WriteLine("^FD>;" & dRow("FOLIO_PALET").ToString & "^FS")
            sw.WriteLine("^FT634,698^A0I,28,28^FH\^FD" & dRow("FOLIO_PALET").ToString & "^FS")
            sw.WriteLine("^BY4,3,56^FT748,90^BCI,,Y,N")
            sw.WriteLine("^FD>;" & dRow("FOLIO_PALET").ToString & "^FS")
            sw.WriteLine("^BY4,3,56^FT748,290^BCI,,Y,N")
            sw.WriteLine("^FD>;" & dRow("FOLIO_PALET").ToString & "^FS")
            sw.WriteLine("^BY4,3,56^FT323,90^BCI,,Y,N")
            sw.WriteLine("^FD>;" & dRow("FOLIO_PALET").ToString & "^FS")
            sw.WriteLine("^^BY4,3,56^FT323,290^BCI,,Y,N")
            sw.WriteLine("^FD>;" & dRow("FOLIO_PALET").ToString & "^FS")
            sw.WriteLine("^BY4,3,56^FT323,487^BCI,,Y,N")
            sw.WriteLine("^FD>;" & dRow("FOLIO_PALET").ToString & "^FS")
            sw.WriteLine("^BY4,3,56^FT748,487^BCI,,Y,N")
            sw.WriteLine("^FD>;" & dRow("FOLIO_PALET").ToString & "^FS")
            sw.WriteLine("^PQ1,0,1,Y^XZ")

            sw.Close()

            If Me.LeeEtiquetaPalet(sArchivo) = True Then
                GeneraEtiquetaPalet = True
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "GeneraEtiquetaPalet", ex)
        End Try
    End Function

    Private Function LeeEtiquetaPalet(ByVal sArchivo As String) As Boolean
        Dim bResultado As Boolean = False
        Me.pDocument.DocumentName = System.IO.Path.GetFileName(sArchivo)
        Dim stream As New FileStream(sArchivo, FileMode.Open)
        Try
            Dim reader As New StreamReader(stream)
            Try
                stringToPrint = reader.ReadToEnd()
                bResultado = True
            Finally
                reader.Dispose()
            End Try
        Finally
            stream.Dispose()
        End Try
        Return bResultado
    End Function

    Private Sub printDocument1_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) Handles pDocument.PrintPage
        Dim charactersOnPage As Integer = 0
        Dim linesPerPage As Integer = 0

        ' Sets the value of charactersOnPage to the number of characters of stringToPrint that will fit within the bounds of the page.
        'e.Graphics.MeasureString(stringToPrint, Me.Font, e.MarginBounds.Size, StringFormat.GenericTypographic, charactersOnPage, linesPerPage
        e.Graphics.MeasureString(stringToPrint, Me.fFont, e.MarginBounds.Size, StringFormat.GenericTypographic, charactersOnPage, linesPerPage)
        ' Draws the string within the bounds of the page
        'e.Graphics.DrawString(stringToPrint, Me.Font, Brushes.Black, e.MarginBounds, StringFormat.GenericTypographic)
        e.Graphics.DrawString(stringToPrint, Me.fFont, Brushes.Black, e.MarginBounds, StringFormat.GenericTypographic)
        ' Remove the portion of the string that has been printed.
        stringToPrint = stringToPrint.Substring(charactersOnPage)
        ' Check to see if more pages are to be printed.
        e.HasMorePages = stringToPrint.Length > 0
    End Sub

#End Region

End Class
