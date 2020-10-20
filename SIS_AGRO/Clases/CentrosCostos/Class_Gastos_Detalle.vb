Option Strict On

Imports System.Data.SqlClient

Public Class Class_Gastos_Detalle

#Region "Campos"

#Region "Campos de la tabla"

#End Region

#Region "Campos ligados a la tabla"

#End Region

#Region "Campos públicos"

#End Region

#Region "Campos privados"

#End Region

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"

#End Region

#Region "Propiedades de campos ligados a la tabla"

#End Region

#Region "Propiedades públicos"

#End Region

#Region "Propiedades de campos privados"

#End Region

#Region "Propiedades de campos de sistema"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_Gastos_Detalle"
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
    End Sub

    Public Sub New(ByVal sFolio As String, ByVal sCodigoDocumento As String)
        Me.New()
        Try
            'Me._FOLIO_MOVIMIENTO = sFolio
            'Me._CODIGO_DOCUMENTO = sCodigoDocumento
            'If Me.Consultar = True Then
            '    Me._Existe = True
            'End If
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
    Public Function ActualizaUUID_Detalle(ByVal iID_GASTOS_DETALLE As Integer, ByVal sUUID As String) As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_GASTOS_DETALLE_ACTUALIZA_UUID"

            sqlParametro = .Parameters.Add("@ID_GASTOS_DETALLE", SqlDbType.Int) : sqlParametro.Value = iID_GASTOS_DETALLE
            sqlParametro = .Parameters.Add("@UUID", SqlDbType.NVarChar, 36) : sqlParametro.Value = sUUID

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "ActualizaUUID_Detalle", ex)
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
