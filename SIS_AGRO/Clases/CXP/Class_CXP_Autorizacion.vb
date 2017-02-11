
Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CXP_Autorizacion
#Region "Campos"
#Region "Campos de la tabla"
    Private _FOLIO_COMPRA As String
    Private _IMPORTE_AUTORIZADO As Double
    Private _FECHA_AUTORIZACION As String
    Private _CODIGO_USUARIO_AUTORIZO As Integer
    Private _NOMBRE_USUARIO_AUTORIZO As String
    Private _ESTATUS_AUTORIZACION_USADA As String
    Private _FOLIO_BANCO As String
#End Region

#Region "Campos de sistema"
    Private _Nombre_Catalogo As String
    Private _Nombre_Reporte As String
    Private _Conexion As SqlConnection
    Private _QuerySelect As String
    Private _QueryOrder As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean 'lectura
    Private _Nombre_Formato As String
#End Region

#Region "Campos privados"

#End Region

#End Region

#Region "Propiedades"
#Region "Propiedades Campos de la tabla"
    Public Property FOLIO_COMPRA() As String
        Get
            Return _FOLIO_COMPRA
        End Get
        Set(ByVal value As String)
            Me._FOLIO_COMPRA = value
        End Set
    End Property

    Public Property IMPORTE_AUTORIZADO() As Double
        Get
            Return Me._IMPORTE_AUTORIZADO
        End Get
        Set(ByVal value As Double)
            Me._IMPORTE_AUTORIZADO = value
        End Set
    End Property

    Public Property FECHA_AUTORIZACION() As String
        Get
            Return _FECHA_AUTORIZACION
        End Get
        Set(ByVal value As String)
            Me._FECHA_AUTORIZACION = value
        End Set
    End Property

    Public Property ESTATUS_AUTORIZACION_USADA() As String
        Get
            Return Me._ESTATUS_AUTORIZACION_USADA
        End Get
        Set(ByVal value As String)
            Me._ESTATUS_AUTORIZACION_USADA = value
        End Set
    End Property

    Public Property CODIGO_USUARIO_AUTORIZO() As Integer
        Get
            Return Me._CODIGO_USUARIO_AUTORIZO
        End Get
        Set(ByVal value As Integer)
            Me._CODIGO_USUARIO_AUTORIZO = value
        End Set
    End Property

    Public ReadOnly Property NOMBRE_USUARIO_AUTORIZO() As String
        Get
            Return Me._NOMBRE_USUARIO_AUTORIZO
        End Get
    End Property
 
    Public Property FOLIO_BANCO() As String
        Get
            Return Me._FOLIO_BANCO
        End Get
        Set(ByVal value As String)
            Me._FOLIO_BANCO = value
        End Set
    End Property
#End Region

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_CxpGlobal"
        End Get
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property

    Public ReadOnly Property Nombre_Formato() As String
        Get
            Return Me._Nombre_Formato
        End Get
    End Property

#End Region
#End Region

    Public oDocumento As New Class_CatDocumentos

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal folioCompra As String)
        Me.New()
        Me._FOLIO_COMPRA = folioCompra

        Try
            If Me.Consultar = True Then
                Me._Existe = True
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function Inserta_Autorizacion() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CXP_AUTORIZACION_PAGO_GRABA"

            sqlParametro = .Parameters.Add("@FOLIO_COMPRA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_COMPRA
            sqlParametro = .Parameters.Add("@IMPORTE_AUTORIZADO", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPORTE_AUTORIZADO
            sqlParametro = .Parameters.Add("@FECHA_AUTORIZACION", SqlDbType.NVarChar, 30) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = ""
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_AUTORIZO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@FOLIO_BANCO", SqlDbType.NVarChar, 15) : sqlParametro.Value = "" & Me._FOLIO_BANCO
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = "INSERTAR"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._FECHA_AUTORIZACION = .Parameters("@FECHA_AUTORIZACION").Value.ToString
                Inserta_Autorizacion = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Inserta_Autorizacion", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function Actualiza_Autorizacion() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CXP_AUTORIZACION_PAGO_GRABA"

            sqlParametro = .Parameters.Add("@FOLIO_COMPRA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_COMPRA
            sqlParametro = .Parameters.Add("@IMPORTE_AUTORIZADO", SqlDbType.Decimal) : sqlParametro.Value = Me._IMPORTE_AUTORIZADO
            sqlParametro = .Parameters.Add("@FECHA_AUTORIZACION", SqlDbType.NVarChar, 30) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = ""
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO_AUTORIZO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario
            sqlParametro = .Parameters.Add("@FOLIO_BANCO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_BANCO
            sqlParametro = .Parameters.Add("@ACCION", SqlDbType.NVarChar, 15) : sqlParametro.Value = "ACTUALIZAR"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._FECHA_AUTORIZACION = .Parameters("@FECHA_AUTORIZACION").Value.ToString
                Actualiza_Autorizacion = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Actualiza_Autorizacion", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
    End Function

    Public Function Consultar() As Boolean

        Dim cmd As New SqlCommand("SELECT A.*, S.NOMBRE_USUARIO NOMBRE_USUARIO_AUTORIZO " & _
                                  "FROM CXP_PAGOS_AUTORIZADOS A " & _
                                  "INNER JOIN SIS_USUARIOS S on(A.CODIGO_USUARIO_AUTORIZO=S.CODIGO_USUARIO) " & _
                                  "WHERE A.FOLIO_COMPRA='" & Me._FOLIO_COMPRA & "' AND ESTATUS_AUTORIZACION_USADA='0'", Me._Conexion)
        Dim dReader As SqlDataReader

        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then

                    Me._FOLIO_COMPRA = "" & dReader("FOLIO_COMPRA").ToString
                    Me._IMPORTE_AUTORIZADO = CType(dReader("IMPORTE_AUTORIZADO"), Double)
                    Me._FECHA_AUTORIZACION = "" & dReader("FECHA_AUTORIZACION").ToString
                    Me._CODIGO_USUARIO_AUTORIZO = CType(dReader("CODIGO_USUARIO_AUTORIZO"), Integer)
                    Me._NOMBRE_USUARIO_AUTORIZO = CType(dReader("NOMBRE_USUARIO_AUTORIZO"), String)
                    Me._ESTATUS_AUTORIZACION_USADA = CType(dReader("ESTATUS_AUTORIZACION_USADA"), String)
                    If txtLEN(dReader("FOLIO_BANCO").ToString) = True Then
                        Me._FOLIO_BANCO = "" & dReader("FOLIO_BANCO").ToString
                    Else
                        Me._FOLIO_BANCO = ""
                    End If

                    Consultar = True

                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With
    End Function
#End Region
 End Class
