Option Strict On

Imports System.Data.SqlClient

Public Class Class_CXC_Global

#Region "Campos"
#Region "Campos de la tabla"
    Private _ID_CXC_GLOBAL As Integer
    Private _FOLIO_CXC As String
    Private _CODIGO_CLIENTE As String
    Private _FECHA As Date
    Private _FECHA_SERVIDOR As Date
    Private _CODIGO_DOCUMENTO As String
    Private _CODIGO_PLAZA As Integer
    Private _FOLIO_REFERENCIA As String
    Private _FOLIO_REFERENCIA_USUARIO As String
    Private _ESTATUS_CXC As String
    Private _ID_MEDIO_PAGO As Integer
    Private _CODIGO_BANCO As String
    Private _CONCEPTO1 As String
    Private _CONCEPTO2 As String
    Private _SUBTOTAL As Decimal
    Private _IMPUESTO As Decimal
    Private _TOTAL As Decimal
    Private _TIPO_DE_CAMBIO As Decimal
    Private _FOLIO_POLIZA As String
    Private _CODIGO_USUARIO_GRABO As Integer
    Private _CODIGO_USUARIO_CANCELO As Integer
    Private _FECHA_DE_CANCELACION As Date
    Private _FECHA_DE_CANCELACION_SERVIDOR As Date
    Private _TOTAL_DOLARES As Decimal

#End Region

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean
    'Private _Nombre_Formato As String
    Private _NOMBRE_CLIENTE As String
    Private _NOMBRE_USUARIO_GRABO As String
    Private _NOMBRE_USUARIO_CANCELO As String
#End Region

#End Region

#Region "Propiedades"

#Region "Propiedades Campos de la tabla"
    Public ReadOnly Property ID_CXC_GLOBAL() As Integer
        Get
            Return _ID_CXC_GLOBAL
        End Get
    End Property

    Public Property FOLIO_CXC() As String
        Get
            Return _FOLIO_CXC
        End Get
        Set(ByVal value As String)
            Me._FOLIO_CXC = value
        End Set
    End Property

    Public Property CODIGO_CLIENTE() As String
        Get
            Return _CODIGO_CLIENTE
        End Get
        Set(ByVal value As String)
            Me._CODIGO_CLIENTE = value
        End Set
    End Property

    Public Property FECHA() As Date
        Get
            Return _FECHA
        End Get
        Set(ByVal value As Date)
            Me._FECHA = value
        End Set
    End Property

    Public Property FECHA_SERVIDOR() As Date
        Get
            Return _FECHA_SERVIDOR
        End Get
        Set(ByVal value As Date)
            Me._FECHA_SERVIDOR = value
        End Set
    End Property

    Public Property CODIGO_DOCUMENTO() As String
        Get
            Return _CODIGO_DOCUMENTO
        End Get
        Set(ByVal value As String)
            Me._CODIGO_DOCUMENTO = value
        End Set
    End Property

    Public ReadOnly Property CODIGO_PLAZA() As Integer
        Get
            Return _CODIGO_PLAZA
        End Get
    End Property

    Public Property FOLIO_REFERENCIA() As String
        Get
            Return _FOLIO_REFERENCIA
        End Get
        Set(ByVal value As String)
            Me._FOLIO_REFERENCIA = value
        End Set
    End Property

    Public Property FOLIO_REFERENCIA_USUARIO() As String
        Get
            Return _FOLIO_REFERENCIA_USUARIO
        End Get
        Set(ByVal value As String)
            Me._FOLIO_REFERENCIA_USUARIO = value
        End Set
    End Property

    Public ReadOnly Property ESTATUS_CXC() As String
        Get
            Return Me._ESTATUS_CXC
        End Get
    End Property

    Public Property ID_MEDIO_PAGO() As Integer
        Get
            Return Me._ID_MEDIO_PAGO
        End Get
        Set(ByVal value As Integer)
            Me._ID_MEDIO_PAGO = value
        End Set
    End Property

    Public Property CODIGO_BANCO() As String
        Get
            Return Me._CODIGO_BANCO
        End Get
        Set(ByVal value As String)
            Me._CODIGO_BANCO = value
        End Set
    End Property

    Public Property CONCEPTO1() As String
        Get
            Return _CONCEPTO1
        End Get
        Set(ByVal value As String)
            Me._CONCEPTO1 = value
        End Set
    End Property

    Public Property CONCEPTO2() As String
        Get
            Return _CONCEPTO2
        End Get
        Set(ByVal value As String)
            Me._CONCEPTO2 = value
        End Set
    End Property

    Public Property SUBTOTAL() As Decimal
        Get
            Return Me._SUBTOTAL
        End Get
        Set(ByVal value As Decimal)
            Me._SUBTOTAL = value
        End Set
    End Property

    Public Property IMPUESTO() As Decimal
        Get
            Return Me._IMPUESTO
        End Get
        Set(ByVal value As Decimal)
            Me._IMPUESTO = value
        End Set
    End Property

    Public Property TOTAL() As Decimal
        Get
            Return _TOTAL
        End Get
        Set(ByVal value As Decimal)
            Me._TOTAL = value
        End Set
    End Property

    Public Property TIPO_DE_CAMBIO() As Decimal
        Get
            Return Me._TIPO_DE_CAMBIO
        End Get
        Set(ByVal value As Decimal)
            Me._TIPO_DE_CAMBIO = value
        End Set
    End Property

    Public ReadOnly Property FOLIO_POLIZA() As String
        Get
            Return _FOLIO_POLIZA
        End Get
    End Property

    Public ReadOnly Property CODIGO_USUARIO_GRABO() As Integer
        Get
            Return Me._CODIGO_USUARIO_GRABO
        End Get
    End Property

    Public ReadOnly Property CODIGO_USUARIO_CANCELO() As Integer
        Get
            Return Me._CODIGO_USUARIO_CANCELO
        End Get
    End Property

    Public Property FECHA_DE_CANCELACION() As Date
        Get
            Return Me._FECHA_DE_CANCELACION
        End Get
        Set(ByVal value As Date)
            Me._FECHA_DE_CANCELACION = value
        End Set
    End Property

    Public ReadOnly Property FECHA_DE_CANCELACION_SERVIDOR() As Date
        Get
            Return Me._FECHA_DE_CANCELACION_SERVIDOR
        End Get
    End Property

    Public Property TOTAL_DOLARES() As Decimal
        Get
            Return _TOTAL_DOLARES
        End Get
        Set(ByVal value As Decimal)
            Me._TOTAL_DOLARES = value
        End Set
    End Property

#End Region

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_CXC_Global"
        End Get
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property

    'Public ReadOnly Property Nombre_Formato() As String
    '    Get
    '        Return Me._Nombre_Formato
    '    End Get
    'End Property

    Public ReadOnly Property NOMBRE_CLIENTE() As String
        Get
            Return Me._NOMBRE_CLIENTE
        End Get
    End Property

    Public ReadOnly Property NOMBRE_USUARIO_GRABO() As String
        Get
            Return Me._NOMBRE_USUARIO_GRABO
        End Get
    End Property

    Public ReadOnly Property NOMBRE_USUARIO_CANCELO() As String
        Get
            Return Me._NOMBRE_USUARIO_GRABO
        End Get
    End Property
#End Region

#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
    End Sub

    Public Sub New(ByVal FolioCXC As String)
        Me.New()
        Me._FOLIO_CXC = FolioCXC

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
    Public Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand("SELECT CXC.*, " &
                                  "S1.NOMBRE_USUARIO NOMBRE_USUARIO_GRABO,S2.NOMBRE_USUARIO NOMBRE_USUARIO_CANCELO,CTE.NOMBRE_CLIENTE " &
                                  "FROM CXC_GLOBAL CXC " &
                                  "INNER JOIN CAT_CLIENTES CTE ON(CXC.CODIGO_CLIENTE=CTE.CODIGO_CLIENTE) " &
                                  "INNER JOIN SIS_USUARIOS S1 ON(CXC.CODIGO_USUARIO_GRABO=S1.CODIGO_USUARIO) " &
                                  "LEFT JOIN SIS_USUARIOS S2 ON(CXC.CODIGO_USUARIO_CANCELO=S2.CODIGO_USUARIO) " &
                                  "WHERE CXC.FOLIO_CXC='" & sReplace(Me._FOLIO_CXC) & "'", Me._Conexion)

        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read = True Then
                    Me._ID_CXC_GLOBAL = CInt(dReader("ID_CXC_GLOBAL"))
                    Me._FOLIO_CXC = "" & dReader("FOLIO_CXC").ToString()
                    Me._CODIGO_CLIENTE = "" & dReader("CODIGO_CLIENTE").ToString()
                    Me._FECHA = CDate(dReader("FECHA"))
                    Me._FECHA_SERVIDOR = CDate(dReader("FECHA_SERVIDOR"))
                    Me._CODIGO_DOCUMENTO = "" & dReader("CODIGO_DOCUMENTO").ToString()
                    Me._CODIGO_PLAZA = CInt(dReader("CODIGO_PLAZA"))
                    Me._FOLIO_REFERENCIA = "" & dReader("FOLIO_REFERENCIA").ToString()
                    Me._FOLIO_REFERENCIA_USUARIO = "" & dReader("FOLIO_REFERENCIA_USUARIO").ToString()
                    Me._ESTATUS_CXC = "" & dReader("ESTATUS_CXC").ToString()
                    Me._ID_MEDIO_PAGO = CInt(dReader("ID_MEDIO_PAGO"))
                    Me._CONCEPTO1 = "" & dReader("CONCEPTO1").ToString()
                    Me._CONCEPTO2 = "" & dReader("CONCEPTO2").ToString()
                    Me._SUBTOTAL = CDec(dReader("SUBTOTAL"))
                    Me._IMPUESTO = CDec(dReader("IMPUESTO"))
                    Me._TOTAL = CDec(dReader("TOTAL"))
                    Me._TIPO_DE_CAMBIO = CDec(dReader("TIPO_DE_CAMBIO"))
                    Me._FOLIO_POLIZA = "" & dReader("FOLIO_POLIZA").ToString()
                    Me._CODIGO_USUARIO_GRABO = CInt(dReader("CODIGO_USUARIO_GRABO"))

                    If Me._ESTATUS_CXC = "C" Then
                        Me._CODIGO_USUARIO_CANCELO = CInt(dReader("CODIGO_USUARIO_CANCELO"))
                        Me._NOMBRE_USUARIO_CANCELO = "" & dReader("NOMBRE_USUARIO_CANCELO").ToString
                        Me._FECHA_DE_CANCELACION = CDate(dReader("FECHA_DE_CANCELACION"))
                        Me._FECHA_DE_CANCELACION_SERVIDOR = CDate(dReader("FECHA_DE_CANCELACION_SERVIDOR"))
                    End If

                    'Me._Nombre_Formato = "" & Trim(dReader("NOMBRE_FORMATO").ToString)

                    Me._NOMBRE_CLIENTE = "" & dReader("NOMBRE_CLIENTE").ToString()
                    Me._NOMBRE_USUARIO_GRABO = "" & dReader("NOMBRE_USUARIO_GRABO").ToString()

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

    Public Function AplicaDocumentoCXC() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = _Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CXC_APLICA_DOCUMENTO"

            sqlParametro = .Parameters.Add("@FOLIO_CXC", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_CXC
            sqlParametro = .Parameters.Add("@FOLIO_REFERENCIA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FOLIO_REFERENCIA
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Me._CODIGO_PLAZA
            sqlParametro = .Parameters.Add("@CODIGO_USUARIO", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Usuario

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me.Nombre_Clase, "AplicaDocumentoCXC", ex)
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
