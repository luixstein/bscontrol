Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_UtileriasFirmaElectronicaCancelacion

#Region "Campos de la tabla"
    Private _FOLIO_DOCUMENTO As String
    Private _FOLIO_POLIZA As String
    Private _FECHA_CANCELACION As Date
    Private _CONTRASEÑA As String

    Private _CODIGO_DOCUMENTO As String
    Private _MODULO As String
    Private _CODIGO_PLAZA As Integer


    Private _CANCELA_DIRECTO As Boolean
    Private _CANCELACION_AUTORIZO As Boolean
    Private _CANCELACION_CONCEPTO As String = ""

    Private _ES_FECHA_CANCELACION_VALIDA As String
    Private _PERIODO_CANCELACION_INTERFAZ As String
#End Region

#Region "Propiedades Campos de la tabla"

    Public Property FOLIO_DOCUMENTO() As String
        Get
            Return Me._FOLIO_DOCUMENTO
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_DOCUMENTO = Value
        End Set
    End Property

    Public Property FOLIO_POLIZA() As String
        Get
            Return Me._FOLIO_POLIZA
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_POLIZA = Value
        End Set
    End Property

    Public Property FECHA_CANCELACION() As Date
        Get
            Return Me._FECHA_CANCELACION
        End Get
        Set(ByVal Value As Date)
            Me._FECHA_CANCELACION = Value
        End Set
    End Property

    Public Property CONTRASEÑA() As String
        Get
            Return Me._CONTRASEÑA
        End Get
        Set(ByVal Value As String)
            Me._CONTRASEÑA = Value
        End Set
    End Property

    Public Property CODIGO_DOCUMENTO() As String
        Get
            Return Me._CODIGO_DOCUMENTO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_DOCUMENTO = Value
        End Set
    End Property

    Public Property MODULO() As String
        Get
            Return Me._MODULO
        End Get
        Set(ByVal Value As String)
            Me._MODULO = Value
        End Set
    End Property

    Public Property CODIGO_PLAZA() As Integer
        Get
            Return Me._CODIGO_PLAZA
        End Get
        Set(ByVal Value As Integer)
            Me._CODIGO_PLAZA = Value
        End Set
    End Property

    Public ReadOnly Property CANCELACION_AUTORIZO() As Boolean
        Get
            Return Me._CANCELACION_AUTORIZO
        End Get
    End Property

    'Public ReadOnly Property CANCELACION_NUEVA_FECHA_CANCELACION() As Date
    '    Get
    '        Return Me._CANCELACION_NUEVA_FECHA_CANCELACION
    '    End Get
    'End Property

    Public ReadOnly Property CANCELACION_CONCEPTO() As String
        Get
            Return Me._CANCELACION_CONCEPTO
        End Get
    End Property

    Public Property CANCELA_DIRECTO() As Boolean
        Get
            Return Me._CANCELA_DIRECTO
        End Get
        Set(ByVal Value As Boolean)
            Me._CANCELA_DIRECTO = Value
        End Set
    End Property

    Public ReadOnly Property PERIODO_CANCELACION_INTERFAZ() As String
        Get
            Return Me._PERIODO_CANCELACION_INTERFAZ
        End Get
    End Property

    Public ReadOnly Property ES_FECHA_CANCELACION_VALIDA() As String
        Get
            Return Me._ES_FECHA_CANCELACION_VALIDA
        End Get
    End Property
#End Region

    Public Sub New()
        '
    End Sub

    Public Function ValidaContraseñaCancelarMovimientosFueraPeriodo() As Boolean
        Try
            Dim sql As New Class_find("SELECT DBO.FN_SIS_IS_VALIDA_CONTRASEÑA_CANCELAR_MOVIMIENTOS_FUERA_PERIODO " & _
                                      "('" & Me._FOLIO_DOCUMENTO & "','" & Format(Me._FECHA_CANCELACION, "yyyy-dd-MM") & "','" & Me.CONTRASEÑA & "')")
            If sql.Result1 = "1" Then
                ValidaContraseñaCancelarMovimientosFueraPeriodo = True
            End If
        Catch ex As Exception
            HandleError("Utílerias", "ValidaContraseñaCancelarMovimientosFueraPeriodo", ex)
        End Try
    End Function

    Public Function AutorizaCancelacionMovimientosFueraPeriodo() As Boolean
        Try
            Dim f As New UtileriasFirmaElectronicaCancelacionMovimientosFueraPeriodo
            f.Titulo = "La fecha de cancelación esta fuera de período, asígne la contraseña correspondiente para poder realizar la cancelación. " & _
            "La contraseña será proporcionada por el depto. de contabilidad."
            f.TituloCorto = "Fecha fuera de período."
            f.Centrada = True
            f.sFolio = Me._FOLIO_DOCUMENTO
            f.ShowDialog()
            If f.ValidaContraseña = True Then
                Me._CANCELACION_AUTORIZO = True
                Me._CANCELACION_CONCEPTO = UCase(f.TxtConcepto.Text)
                Me._FECHA_CANCELACION = f.dtFechaCancelacion.Value
                'Me._CANCELACION_NUEVA_FECHA_CANCELACION = f.dtFechaCancelacion.Value
                AutorizaCancelacionMovimientosFueraPeriodo = True
            End If
            f = Nothing
        Catch ex As Exception
            HandleError("Utílerias", "AutorizaCancelacionMovimientosFueraPeriodo", ex)
        End Try
    End Function

    Public Function GestionaCancelacion() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        Dim dReader As SqlDataReader
        Dim cn As New SqlConnection(Empresa_Sistema.conexion)
        With cmd
            .Connection = cn
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_UTILERIAS_GESTIONA_CANCELACION_DOCUMENTOS"

            sqlParametro = .Parameters.Add("@FOLIO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_DOCUMENTO
            sqlParametro = .Parameters.Add("@CODIGO_MODULO", SqlDbType.NVarChar, 4) : sqlParametro.Value = Me._MODULO
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PLAZA
            Try
                cn.Open()
                dReader = .ExecuteReader()
                If dReader.Read Then
                    Me._CANCELA_DIRECTO = CBool(dReader("CANCELA_DIRECTO").ToString())
                    GestionaCancelacion = True
                End If

            Catch ex As Exception
                HandleError("Utilerias", "GestionaCancelacion", ex)
            Finally
                cn.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function GestionaCancelacionConInterfaz() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        Dim dReader As SqlDataReader
        Dim cn As New SqlConnection(Empresa_Sistema.conexion)
        With cmd
            .Connection = cn
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_UTILERIAS_GESTIONA_CANCELACION_DOCUMENTOS_CON_INTERFAZ_CANCELACION"

            sqlParametro = .Parameters.Add("@FOLIO_POLIZA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_POLIZA
            sqlParametro = .Parameters.Add("@FECHA_CANCELACION_INTERFAZ", SqlDbType.DateTime) : sqlParametro.Value = Me._FECHA_CANCELACION

            Try
                cn.Open()
                dReader = .ExecuteReader()
                If dReader.Read Then
                    Me._ES_FECHA_CANCELACION_VALIDA = "" & dReader("ES_FECHA_CANCELACION_VALIDA").ToString()
                    GestionaCancelacionConInterfaz = True
                Else
                    Me._ES_FECHA_CANCELACION_VALIDA = ""
                    Me._PERIODO_CANCELACION_INTERFAZ = ""
                End If
            Catch ex As Exception
                HandleError("Utilerias", "GestionaCancelacion", ex)
                Me._ES_FECHA_CANCELACION_VALIDA = ""
                Me._PERIODO_CANCELACION_INTERFAZ = ""
            Finally
                cn.Close()
                cmd.Dispose()
                sqlParametro = Nothing

            End Try
        End With
    End Function
End Class
