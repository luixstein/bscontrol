Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_Embarques_CajasProducidas

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_PRODUCCION As Integer
    Private _FOLIO_PRODUCCION As String
    Private _FECHA As Date
    Private _CODIGO_LOTE As String
    Private _CODIGO_CULTIVO As String
    Private _NUMERO_MALLA As String
    Private _NUMERO_RACA As String
    Private _NUMERO_BIN As String
    Private _NUMERO_CAJAS As Integer
    Private _PESO_BALDE As Double
    Private _OPERADOR As String
    Private _UNIDAD As String
    Private _PLACAS As String
    Private _HORA_SALIDA As Date
    Private _CODIGO_EMPAQUE As String
    Private _FLETE_ACARREO As Double
    Private _FLETE_ENTREGA As Double
    Private _CODIGO_CENTRO_COSTO As String
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
    Public Property ID_PRODUCCION() As Integer
        Get
            Return Me._ID_PRODUCCION
        End Get
        Set(ByVal value As Integer)
            Me._ID_PRODUCCION = value
        End Set
    End Property

    Public Property FOLIO_PRODUCCION() As String
        Get
            Return Me._FOLIO_PRODUCCION
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_PRODUCCION = Value
        End Set
    End Property

    Public Property FECHA() As Date
        Get
            Return Me._FECHA
        End Get
        Set(ByVal Value As Date)
            Me._FECHA = Value
        End Set
    End Property

    Public Property CODIGO_LOTE() As String
        Get
            Return Me._CODIGO_LOTE
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_LOTE = Value
        End Set
    End Property

    Public Property CODIGO_CULTIVO() As String
        Get
            Return Me._CODIGO_CULTIVO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CULTIVO = Value
        End Set
    End Property

    Public Property NUMERO_MALLA() As String
        Get
            Return Me._NUMERO_MALLA
        End Get
        Set(ByVal Value As String)
            Me._NUMERO_MALLA = Value
        End Set
    End Property

    Public Property NUMERO_RACA() As String
        Get
            Return Me._NUMERO_RACA
        End Get
        Set(ByVal Value As String)
            Me._NUMERO_RACA = Value
        End Set
    End Property

    Public Property NUMERO_BIN() As String
        Get
            Return Me._NUMERO_BIN
        End Get
        Set(ByVal Value As String)
            Me._NUMERO_BIN = Value
        End Set
    End Property

    Public Property NUMERO_CAJAS() As Integer
        Get
            Return Me._NUMERO_CAJAS
        End Get
        Set(ByVal Value As Integer)
            Me._NUMERO_CAJAS = Value
        End Set
    End Property

    Public Property OPERADOR() As String
        Get
            Return Me._OPERADOR
        End Get
        Set(ByVal Value As String)
            Me._OPERADOR = Value
        End Set
    End Property

    Public Property UNIDAD() As String
        Get
            Return Me._UNIDAD
        End Get
        Set(ByVal Value As String)
            Me._UNIDAD = Value
        End Set
    End Property

    Public Property PLACAS() As String
        Get
            Return Me._PLACAS
        End Get
        Set(ByVal Value As String)
            Me._PLACAS = Value
        End Set
    End Property

    Public Property HORA_SALIDA() As Date
        Get
            Return Me._HORA_SALIDA
        End Get
        Set(ByVal Value As Date)
            Me._HORA_SALIDA = Value
        End Set
    End Property

    Public Property CODIGO_EMPAQUE() As String
        Get
            Return Me._CODIGO_EMPAQUE
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_EMPAQUE = Value
        End Set
    End Property

    Public Property PESO_BALDE() As Double
        Get
            Return Me._PESO_BALDE
        End Get
        Set(ByVal Value As Double)
            Me._PESO_BALDE = Value
        End Set
    End Property

    Public Property FLETE_ACARREO() As Double
        Get
            Return Me._FLETE_ACARREO
        End Get
        Set(ByVal Value As Double)
            Me._FLETE_ACARREO = Value
        End Set
    End Property

    Public Property FLETE_ENTREGA() As Double
        Get
            Return Me._FLETE_ENTREGA
        End Get
        Set(ByVal Value As Double)
            Me._FLETE_ENTREGA = Value
        End Set
    End Property

    Public Property CODIGO_CENTRO_COSTO() As String
        Get
            Return Me._CODIGO_CENTRO_COSTO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_CENTRO_COSTO = Value
        End Set
    End Property

#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
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

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_Embarques_CajasProducidas"
        End Get
    End Property
#End Region

#End Region

#End Region

#Region "Constructor y destructor"

    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT ID_PRODUCCION,FOLIO_PRODUCCION,FECHA,CODIGO_LOTE,CODIGO_CULTIVO,NUMERO_MALLA,NUMERO_RACA,NUMERO_BIN,NUMERO_CAJAS,PESO_BALDE,OPERADOR,UNIDAD,PLACAS,HORA_SALIDA," & _
            "CODIGO_EMPAQUE,FLETE_ACARREO,FLETE_ENTREGA FROM EMB_PRODUCCION_CAJAS"
        Me._QueryOrder = " Order by FOLIO_PRODUCCION,FECHA"
    End Sub

    Public Sub New(ByVal iID As Integer)
        Me.New()
        Me._ID_PRODUCCION = iID
        Try
            If Me.Consultar = True Then
                Me._Existe = True
            Else
                'Throw New Exception("No existe.")
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

    Public Function GrabarProduccion(ByVal bAccion As Boolean) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMB_PRODUCCION_CAJAS_GRABA"

            sqlParametro = .Parameters.Add("@ID_PRODUCCION", SqlDbType.Int) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = Me._ID_PRODUCCION
            sqlParametro = .Parameters.Add("@FOLIO_PRODUCCION", SqlDbType.NVarChar, 6) : sqlParametro.Value = Me._FOLIO_PRODUCCION
            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA
            sqlParametro = .Parameters.Add("@CODIGO_LOTE", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_LOTE
            sqlParametro = .Parameters.Add("@CODIGO_CULTIVO", SqlDbType.NVarChar, 4) : sqlParametro.Value = "01" 'DBNull.Value   'Me._CODIGO_CULTIVO.ToString
            sqlParametro = .Parameters.Add("@NUMERO_MALLA", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._NUMERO_MALLA
            sqlParametro = .Parameters.Add("@NUMERO_CAJAS", SqlDbType.SmallInt) : sqlParametro.Value = Me._NUMERO_CAJAS
            sqlParametro = .Parameters.Add("@PESO_BALDE", SqlDbType.Money) : sqlParametro.Value = Me._PESO_BALDE
            sqlParametro = .Parameters.Add("@NUMERO_RACA", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._NUMERO_RACA
            sqlParametro = .Parameters.Add("@NUMERO_BIN", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._NUMERO_BIN
            sqlParametro = .Parameters.Add("@OPERADOR", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._OPERADOR
            sqlParametro = .Parameters.Add("@UNIDAD", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._UNIDAD
            sqlParametro = .Parameters.Add("@PLACAS", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._PLACAS
            sqlParametro = .Parameters.Add("@HORA_SALIDA", SqlDbType.DateTime) : sqlParametro.Value = Me._HORA_SALIDA
            sqlParametro = .Parameters.Add("@CODIGO_EMPAQUE", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_EMPAQUE
            sqlParametro = .Parameters.Add("@FLETE_ACARREO", SqlDbType.Decimal) : sqlParametro.Value = Me._FLETE_ACARREO
            sqlParametro = .Parameters.Add("@FLETE_ENTREGA", SqlDbType.Decimal) : sqlParametro.Value = Me._FLETE_ENTREGA
            sqlParametro = .Parameters.Add("@CODIGO_CENTRO_COSTO", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_CENTRO_COSTO
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.Char, 1) : sqlParametro.Value = Convert.ToInt32(bAccion)

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._ID_PRODUCCION = CInt(.Parameters("@ID_PRODUCCION").Value.ToString)
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "GrabarProduccion", ex)
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
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE ID_PRODUCCION=" & Me._ID_PRODUCCION.ToString, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._ID_PRODUCCION = CInt(dReader("ID_PRODUCCION").ToString)
                    Me._FOLIO_PRODUCCION = Trim("" & dReader("FOLIO_PRODUCCION").ToString)
                    Me._FECHA = CDate(dReader("FECHA").ToString)
                    Me._CODIGO_LOTE = "" & dReader("CODIGO_LOTE").ToString
                    Me._CODIGO_CULTIVO = "" & dReader("CODIGO_CULTIVO").ToString
                    Me._NUMERO_MALLA = "" & dReader("NUMERO_MALLA").ToString
                    Me._NUMERO_RACA = "" & dReader("NUMERO_RACA").ToString
                    Me._NUMERO_BIN = "" & dReader("NUMERO_BIN").ToString
                    Me._NUMERO_CAJAS = CInt(dReader("NUMERO_CAJAS").ToString)
                    Me._PESO_BALDE = CDbl(dReader("PESO_BALDE").ToString)
                    Me._OPERADOR = "" & dReader("OPERADOR").ToString
                    Me._UNIDAD = "" & dReader("UNIDAD").ToString
                    Me._PLACAS = "" & dReader("PLACAS").ToString
                    Me._HORA_SALIDA = CDate(dReader("HORA_SALIDA").ToString)
                    Me._CODIGO_EMPAQUE = "" & dReader("CODIGO_EMPAQUE").ToString
                    Me._FLETE_ACARREO = CDbl(dReader("FLETE_ACARREO").ToString)
                    Me._FLETE_ENTREGA = CDbl(dReader("FLETE_ENTREGA").ToString)

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

    Public Function EliminaProduccion(ByVal iID_PRODUCCION As Integer) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMBARQUES_PRODUCCION_CAJAS_ELIMINA"

            sqlParametro = .Parameters.Add("@ID_PRODUCCION", SqlDbType.Int) : sqlParametro.Value = iID_PRODUCCION

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "EliminaProduccion", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Function ObtenerDetalle(ByVal dFecha As Date, ByVal sCodigoLote As String, ByVal sCodigoCentroCosto As String, ByVal sCodigoEmpaque As String) As System.Data.DataTable
        Dim dt As New DataTable, da As SqlDataAdapter

        'Dim sSQL As String = "SELECT ID_PRODUCCION,FOLIO_PRODUCCION,FECHA,CODIGO_LOTE,CODIGO_CULTIVO,NUMERO_MALLA,NUMERO_RACA,NUMERO_BIN, " & _
        '                     "NUMERO_CAJAS,PESO_BALDE,OPERADOR,UNIDAD,PLACAS,HORA_SALIDA,CODIGO_EMPAQUE,FLETE_ACARREO,FLETE_ENTREGA " & _
        '                     "FROM EMB_PRODUCCION_CAJAS " & _
        '                     "WHERE dbo.FN_FECHA_SIN_HORA(FECHA)='" & Format(dFecha, "yyyy-dd-MM").ToString & "' " & _
        '                     "AND CODIGO_LOTE='" & sCodigoLote & "' AND CODIGO_CULTIVO='" & sCodigoCultivo & "' AND CODIGO_EMPAQUE='" & sCodigoEmpaque & "' " & _
        '                     "ORDER BY FOLIO_PRODUCCION"

        Dim sSQL As String = "SELECT ID_PRODUCCION,FOLIO_PRODUCCION,FECHA,CODIGO_LOTE,CODIGO_CULTIVO,NUMERO_MALLA,NUMERO_RACA,NUMERO_BIN, " & _
                     "NUMERO_CAJAS,PESO_BALDE,OPERADOR,UNIDAD,PLACAS,HORA_SALIDA,CODIGO_EMPAQUE,FLETE_ACARREO,FLETE_ENTREGA " & _
                     "FROM EMB_PRODUCCION_CAJAS " & _
                     "WHERE dbo.FN_FECHA_SIN_HORA(FECHA)='" & Format(dFecha, "yyyy-dd-MM").ToString & "' " & _
                     "AND CODIGO_LOTE='" & sCodigoLote & "' AND CODIGO_CENTRO_COSTO='" & sCodigoCentroCosto & "' AND CODIGO_EMPAQUE='" & sCodigoEmpaque & "' " & _
                     "ORDER BY FOLIO_PRODUCCION"

        Try
            da = New SqlDataAdapter(sSQL, Me._Conexion)
            da.Fill(dt)
            da.Dispose()
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "ObtenerDetalle", ex)
        Finally

        End Try
        Return dt
    End Function
#End Region

End Class
