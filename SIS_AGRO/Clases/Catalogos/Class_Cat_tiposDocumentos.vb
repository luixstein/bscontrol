Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_Cat_tiposDocumentos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_TIPO_DOCUMENTO As String
    Private _NOMBRE_TIPO_DOCUMENTO As String
    Private _CODIGO_MODULO As String
    Private _AFECTA_CXC As String
    Private _NATURALEZA_CXC As String
    Private _AFECTA_CONTABILIDAD As String
    Private _AFECTA_INVENTARIOS As String
    Private _NATURALEZA_INVENTARIOS As String
    Private _AFECTA_CXP As String
    Private _NATURALEZA_CXP As String
    Private _ES_CANCELABLE As String
    Private _ES_TRANSFERENCIA As String

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

    Public Property CODIGO_TIPO_DOCUMENTO() As String
        Get
            Return Me._CODIGO_TIPO_DOCUMENTO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_TIPO_DOCUMENTO = Value
        End Set
    End Property

    Public Property NOMBRE_TIPO_DOCUMENTO() As String
        Get
            Return Me._NOMBRE_TIPO_DOCUMENTO
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_TIPO_DOCUMENTO = Value
        End Set
    End Property

    Public Property CODIGO_MODULO() As String
        Get
            Return Me._CODIGO_MODULO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_MODULO = Value
        End Set
    End Property

    Public Property AFECTA_CXC() As String
        Get
            Return Me._AFECTA_CXC
        End Get
        Set(ByVal Value As String)
            Me._AFECTA_CXC = Value
        End Set
    End Property

    Public Property NATURALEZA_CXC() As String
        Get
            Return Me._NATURALEZA_CXC
        End Get
        Set(ByVal Value As String)
            Me._NATURALEZA_CXC = Value
        End Set
    End Property

    Public Property AFECTA_CONTABILIDAD() As String
        Get
            Return Me._AFECTA_CONTABILIDAD
        End Get
        Set(ByVal Value As String)
            Me._AFECTA_CONTABILIDAD = Value
        End Set
    End Property

    Public Property AFECTA_INVENTARIOS() As String
        Get
            Return Me._AFECTA_INVENTARIOS
        End Get
        Set(ByVal Value As String)
            Me._AFECTA_INVENTARIOS = Value
        End Set
    End Property

    Public Property NATURALEZA_INVENTARIOS() As String
        Get
            Return Me._NATURALEZA_INVENTARIOS
        End Get
        Set(ByVal Value As String)
            Me._NATURALEZA_INVENTARIOS = Value
        End Set
    End Property

    Public Property AFECTA_CXP() As String
        Get
            Return Me._AFECTA_CXP
        End Get
        Set(ByVal Value As String)
            Me._AFECTA_CXP = Value
        End Set
    End Property

    Public Property NATURALEZA_CXP() As String
        Get
            Return Me._NATURALEZA_CXP
        End Get
        Set(ByVal Value As String)
            Me._NATURALEZA_CXP = Value
        End Set
    End Property

    Public Property ES_CANCELABLE() As String
        Get
            Return Me._ES_CANCELABLE
        End Get
        Set(ByVal Value As String)
            Me._ES_CANCELABLE = Value
        End Set
    End Property

    Public Property ES_TRANSFERENCIA() As String
        Get
            Return Me._ES_TRANSFERENCIA
        End Get
        Set(ByVal Value As String)
            Me._ES_TRANSFERENCIA = Value
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
        Me._Nombre_Catalogo = "SIS_TIPOS_DOCUMENTOS"
        Me._Nombre_Reporte = "RPT_SIS_TIPOS_DOCUMENTOS.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * from SIS_TIPOS_DOCUMENTOS where "
        Me._QueryOrder = " Order by CODIGO_TIPO_DOCUMENTO"
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal sCodigoTipoDocumento As String)
        Me.New()
        Try
            Me.CODIGO_TIPO_DOCUMENTO = sCodigoTipoDocumento
            If Me.Consultar = False Then
                Throw New Exception("El tipo de documento no existe.")
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

#Region "Opciones"

#End Region

#Region "Métodos y procedimientos"

    ''' <summary>
    ''' Consulta y refresca los campos del almacén.
    ''' </summary>
    Public Function Consultar() As Boolean
        Dim cmd As New SqlCommand(Me._QuerySelect & " CODIGO_TIPO_DOCUMENTO='" & Replace(Me.CODIGO_TIPO_DOCUMENTO, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me.NOMBRE_TIPO_DOCUMENTO = "" & dReader("NOMBRE_TIPO_DOCUMENTO").ToString()
                    Me.CODIGO_MODULO = Trim("" & dReader("CODIGO_MODULO").ToString())
                    Me.AFECTA_CXC = Trim("" & dReader("AFECTA_CXC").ToString())
                    Me.NATURALEZA_CXC = "" & dReader("NATURALEZA_CXC").ToString()
                    Me.AFECTA_CONTABILIDAD = "" & dReader("AFECTA_CONTABILIDAD").ToString()
                    Me.AFECTA_INVENTARIOS = "" & dReader("AFECTA_INVENTARIOS").ToString()
                    Me.NATURALEZA_INVENTARIOS = "" & dReader("NATURALEZA_INVENTARIOS").ToString()
                    Me.AFECTA_CXP = "" & dReader("AFECTA_CXP").ToString()
                    Me.NATURALEZA_CXP = "" & dReader("NATURALEZA_CXP").ToString()
                    Me.ES_CANCELABLE = "" & dReader("ES_CANCELABLE").ToString()
                    Me.ES_TRANSFERENCIA = "" & dReader("ES_TRANSFERENCIA").ToString()

                    Consultar = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With

    End Function        'Consulta un elemento del catálogo.


    ''' <summary>
    ''' Despliega la búsqueda visual por descripción.
    ''' </summary>
    Public Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Articulos por Descripción."
        f.sCampo = "Descripcion"
        f.sOrder = "Descripcion"
        f.sTable = "Cat_Articulos"
        f.sQl = "Select CODIGO_ARTICULO,Descripcion From Cat_Articulos Where 1=1 And Protegido=0 AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion", ex)
        End Try
        Return Resultado
    End Function


#End Region

#Region "Eventos de objetos"


#Region "Eventos de la lista de elementos"

#End Region

#Region " Eventos de TxtFiltro"

#End Region

#Region "Eventos Genericos"

#End Region


#Region "Keydown específicos"


#End Region

#Region "Validating específicos"

#End Region



#End Region


End Class