Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatTiposDocumentos
    Inherits Class_Catalogos


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
    Public Overrides ReadOnly Property Nombre_Catalogo() As String
        Get
            Return Me._Nombre_Catalogo
        End Get
    End Property

    Public Overrides Property Nombre_Reporte() As String
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
        Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"

#End Region

#Region "Métodos y procedimientos"

    ''' <summary>
    ''' Actualiza al almacén.
    ''' </summary>
    Public Overrides Function Actualizar() As Boolean
        'Dim cmd As New SqlCommand
        'Dim sqlParametro As SqlParameter
        'With cmd
        '    .Connection = Me._Conexion
        '    .CommandTimeout = 0
        '    .CommandType = CommandType.StoredProcedure
        '    .CommandText = "MP_ACTUALIZA_CAT_ARTICULOS"

        '    sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me.Codigo_Articulo
        '    sqlParametro = .Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me.Descripcion
        '    sqlParametro = .Parameters.Add("@UNIDAD_VENTA", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me.Unidad_Venta
        '    sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Status
        '    sqlParametro = .Parameters.Add("@PROTEGIDO", SqlDbType.Bit, 1) : sqlParametro.Value = Me.Protegido
        '    sqlParametro = .Parameters.Add("@INVENTARIABLE", SqlDbType.Char, 1) : sqlParametro.Value = Me.Inventariable
        '    sqlParametro = .Parameters.Add("@ID_SIS_CAT_IMPUESTO", SqlDbType.SmallInt, 2) : sqlParametro.Value = Me.ID_SIS_CAT_IMPUESTO
        '    sqlParametro = .Parameters.Add("@CODIGO_LINEA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me.Codigo_Linea
        '    sqlParametro = .Parameters.Add("@ID_CAT_FAMILIAS", SqlDbType.SmallInt) : sqlParametro.Value = Me.Id_Cat_Familia
        '    sqlParametro = .Parameters.Add("@PRECIO", SqlDbType.Money) : sqlParametro.Value = Me.Precio
        '    'Agregado por Misael Moreno. 10 de Noviembre de 2010.
        '    'Ver requisito DDR_002
        '    sqlParametro = .Parameters.Add("@INCLUIR_EN_VENTA", SqlDbType.Bit) : sqlParametro.Value = Me.Incluir_Para_Venta
        '    'Fin de agregado.

        '    'Agregado por Oscar Zambrano. 14 de Diciembre de 2010.
        '    'Para tomar en cuenata todos articulos que cuentan con un porcentaje de Merma
        '    sqlParametro = .Parameters.Add("@PORCENTAJE_MERMA", SqlDbType.Decimal) : sqlParametro.Value = Me.Inclir_Merma
        '    'Fin de lo agregado  =)

        '    Try
        '        Me._Conexion.Open()
        '        .ExecuteNonQuery()
        '        Actualizar = True
        '    Catch ex As Exception
        '        HandleError(Me._Nombre_Catalogo, "Actualizar", ex)
        '    Finally
        '        Me._Conexion.Close()
        '        cmd.Dispose()
        '        sqlParametro = Nothing
        '    End Try

        'End With
    End Function                        'Actualiza un elemento del catálogo.

    Public Function ActualizaDescripcion() As Boolean
        'Dim cmd As New SqlCommand
        'Dim sqlParametro As SqlParameter
        'With cmd
        '    .Connection = Me._Conexion
        '    .CommandTimeout = 0
        '    .CommandType = CommandType.StoredProcedure
        '    .CommandText = "MP_ACTUALIZA_CAT_ARTICULOS_ACTUALIZA_DESCRIPCION"

        '    sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me.Codigo_Articulo
        '    sqlParametro = .Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me.Descripcion

        '    Try
        '        Me._Conexion.Open()
        '        .ExecuteNonQuery()
        '        ActualizaDescripcion = True
        '    Catch ex As Exception
        '        HandleError(Me._Nombre_Catalogo, "ActualizaDescripcion", ex)
        '    Finally
        '        Me._Conexion.Close()
        '        cmd.Dispose()
        '        sqlParametro = Nothing
        '    End Try
        'End With
    End Function

    ''' <summary>
    ''' Consulta y refresca los campos del almacén.
    ''' </summary>
    Public Overrides Function Consultar() As Boolean
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

                    Return True
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
    ''' Inserta un almacén al catálogo.
    ''' </summary>
    Public Overrides Function Insertar() As Boolean
        'Dim cmd As New SqlCommand
        'Dim sqlParametro As SqlParameter
        'With cmd
        '    .Connection = Me._Conexion
        '    .CommandTimeout = 0
        '    .CommandType = CommandType.StoredProcedure
        '    .CommandText = "MP_INSERTA_CAT_ARTICULOS"

        '    sqlParametro = .Parameters.Add("@CODIGO_ARTICULO", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me.Codigo_Articulo
        '    sqlParametro = .Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me.Descripcion
        '    sqlParametro = .Parameters.Add("@UNIDAD_VENTA", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me.Unidad_Venta
        '    sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Status
        '    sqlParametro = .Parameters.Add("@PROTEGIDO", SqlDbType.Bit, 1) : sqlParametro.Value = Me.Protegido
        '    sqlParametro = .Parameters.Add("@INVENTARIABLE", SqlDbType.Char, 1) : sqlParametro.Value = Me.Inventariable
        '    sqlParametro = .Parameters.Add("@ID_SIS_CAT_IMPUESTO", SqlDbType.SmallInt, 2) : sqlParametro.Value = Me.ID_SIS_CAT_IMPUESTO
        '    sqlParametro = .Parameters.Add("@CODIGO_LINEA", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me.Codigo_Linea
        '    sqlParametro = .Parameters.Add("@ID_CAT_FAMILIAS", SqlDbType.SmallInt) : sqlParametro.Value = Me.Id_Cat_Familia
        '    sqlParametro = .Parameters.Add("@PRECIO", SqlDbType.Money) : sqlParametro.Value = Me.Precio
        '    'Agregado por Misael Moreno. 10 de Noviembre de 2010.
        '    'Ver requisito DDR_002
        '    sqlParametro = .Parameters.Add("@INCLUIR_EN_VENTA", SqlDbType.Bit) : sqlParametro.Value = Me.Incluir_Para_Venta
        '    'Fin de agregado.


        '    'Agregado por Oscar Zambrano. 14 de Diciembre de 2010.
        '    'Para tomar en cuenata todos articulos que cuentan con un porcentaje de Merma
        '    sqlParametro = .Parameters.Add("@PORCENTAJE_MERMA", SqlDbType.Decimal) : sqlParametro.Value = Me.Inclir_Merma
        '    'Fin de lo Agregado =)

        '    Try
        '        Me._Conexion.Open()
        '        .ExecuteNonQuery()
        '        Return True
        '    Catch ex As Exception
        '        HandleError(Me._Nombre_Catalogo, "Insertar", ex)
        '    Finally
        '        Me._Conexion.Close()
        '        cmd.Dispose()
        '        sqlParametro = Nothing
        '    End Try

        'End With

    End Function 'Inserta un elemento al catálogo.

    ''' <summary>
    ''' Obtiene a todos los elementos del catálogo.
    ''' </summary>
    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        'Dim dTable As New DataTable
        'Dim dsCatArticulos As New SqlDataAdapter("SELECT CODIGO_ARTICULO, DESCRIPCION FROM CAT_Articulos ORDER BY DESCRIPCION", Me._Conexion)
        'Try
        '    dsCatArticulos.Fill(dTable)
        'Catch ex As Exception
        '    HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        'Finally
        '    dsCatArticulos.Dispose()
        'End Try
        'Return dTable
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.

    ''' <summary>
    ''' Despliega la búsqueda visual por código.
    ''' </summary>
    Public Overrides Function BusquedaVisual_PorCodigo() As String
        'Dim f As New BusquedaVisual
        'Dim Resultado As String = ""
        'f.Text = "Búsqueda de Articulos por Código."
        'f.sCampo = "CODIGO_ARTICULO"
        'f.sOrder = "Descripcion"
        'f.sTable = "Cat_Articulos"
        'f.sQl = "Select CODIGO_ARTICULO,Descripcion From Cat_Articulos Where 1=1 And Protegido=0 AND "
        'f.Inicia("")
        'f.ShowDialog()
        'Try
        '    If f.iRows > 0 Then
        '        Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
        '    End If
        'Catch ex As Exception
        '    HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorCodigo", ex)
        'End Try
        'Return Resultado
    End Function

    ''' <summary>
    ''' Despliega la búsqueda visual por descripción.
    ''' </summary>
    Public Overrides Function BusquedaVisual_PorDescripcion() As String
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