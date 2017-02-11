Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_Embarques_EmbarqueDetalle

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_EMB_EMBARQUE_DETALLE As Integer
    Private _FOLIO_EMBARQUE As String
    Private _FOLIO_PALET As String
#End Region

#Region "Campos ligados a la tabla"

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
    Public Property FOLIO_EMBARQUE() As String
        Get
            Return Me._FOLIO_EMBARQUE
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_EMBARQUE = Value
        End Set
    End Property

    Public ReadOnly Property ID_EMB_EMBARQUE_DETALLE() As Integer
        Get
            Return Me._ID_EMB_EMBARQUE_DETALLE
        End Get
    End Property

    Public Property FOLIO_PALET() As String
        Get
            Return Me._FOLIO_PALET
        End Get
        Set(ByVal Value As String)
            Me._FOLIO_PALET = Value
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

#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "EMB_EMBARQUE_DETALLE"
        Me._Conexion = New SqlConnection(Empresa_Sistema.conexion)
        Me._QuerySelect = "SELECT * FROM COMPRA_DETALLE WHERE "
        Me._QueryOrder = " ORDER BY ID_COMPRA_DETALLE"
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function GrabaRenglonEmbarque() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMB_EMBARQUE_GRABA_DETALLE"

            sqlParametro = .Parameters.Add("@FOLIO_EMBARQUE", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_EMBARQUE
            sqlParametro = .Parameters.Add("@FOLIO_PALET", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_PALET

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "GrabaRenglonEmbarque", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function

    Public Function EliminaSalidaPalet() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_EMB_EMBARQUE_DETALLE_ELIMINA_PALET"

            sqlParametro = .Parameters.Add("@FOLIO_EMBARQUE ", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_EMBARQUE
            sqlParametro = .Parameters.Add("@FOLIO_PALET", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_PALET.ToString

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "EliminaSalidaPalet", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return bResultado
    End Function
#End Region

End Class
