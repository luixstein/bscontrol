Imports System.Data
Imports System.Data.SqlClient


Public Class Class_CatEmbarcadores
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_EMBARCADOR As String
    Private _NOMBRE_EMBARCADOR As String
    Private _RFC As String
    Private _CURP As String
    Private _DOMICILIO As String
    Private _CIUDAD As String
    Private _ESTADO As String
    Private _TELEFONO As String
    Private _CELULAR As String
    Private _FAX As String
    Private _CODIGO_POSTAL As String
    Private _REPRESENTANTE As String
    Private _RFC_REPRESENTANTE As String
    Private _FDA As String
    Private _ESTATUS As String

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
    Public Property CODIGO_EMBARCADOR() As String
        Get
            Return Me._CODIGO_EMBARCADOR
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_EMBARCADOR = Value
        End Set
    End Property

    Public Property NOMBRE_EMBARCADOR() As String
        Get
            Return Me._NOMBRE_EMBARCADOR
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_EMBARCADOR = Value
        End Set
    End Property

    Public Property RFC() As String
        Get
            Return Me._RFC
        End Get
        Set(ByVal Value As String)
            Me._RFC = Value
        End Set
    End Property

    Public Property CURP() As String
        Get
            Return Me._CURP
        End Get
        Set(ByVal Value As String)
            Me._CURP = Value
        End Set
    End Property

    Public Property DOMICILIO() As String
        Get
            Return Me._DOMICILIO
        End Get
        Set(ByVal Value As String)
            Me._DOMICILIO = Value
        End Set
    End Property

    Public Property CIUDAD() As String
        Get
            Return Me._CIUDAD
        End Get
        Set(ByVal Value As String)
            Me._CIUDAD = Value
        End Set
    End Property

    Public Property ESTADO() As String
        Get
            Return Me._ESTADO
        End Get
        Set(ByVal Value As String)
            Me._ESTADO = Value
        End Set
    End Property

    Public Property TELEFONO() As String
        Get
            Return Me._TELEFONO
        End Get
        Set(ByVal Value As String)
            Me._TELEFONO = Value
        End Set
    End Property

    Public Property CELULAR() As String
        Get
            Return Me._CELULAR
        End Get
        Set(ByVal Value As String)
            Me._CELULAR = Value
        End Set
    End Property
 
    Public Property FAX() As String
        Get
            Return Me._FAX
        End Get
        Set(ByVal Value As String)
            Me._FAX = Value
        End Set
    End Property

    Public Property CODIGO_POSTAL() As String
        Get
            Return Me._CODIGO_POSTAL
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_POSTAL = Value
        End Set
    End Property

    Public Property REPRESENTANTE() As String
        Get
            Return Me._REPRESENTANTE
        End Get
        Set(ByVal Value As String)
            Me._REPRESENTANTE = Value
        End Set
    End Property

    Public Property RFC_REPRESENTANTE() As String
        Get
            Return Me._RFC_REPRESENTANTE
        End Get
        Set(ByVal Value As String)
            Me._RFC_REPRESENTANTE = Value
        End Set
    End Property

    Public Property FDA() As String
        Get
            Return Me._FDA
        End Get
        Set(ByVal Value As String)
            Me._FDA = Value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return Me._ESTATUS
        End Get
        Set(ByVal value As String)
            Me._ESTATUS = value
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
        Me._Nombre_Catalogo = "CAT_EMBARCADORES"
        Me._Nombre_Reporte = "RPT_CATALOGO_EMBARCADORES"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * FROM CAT_EMBARCADORES"
        Me._QueryOrder = " ORDER BY NOMBRE_EMBARCADOR"
    End Sub                                                         'Inicializa al objeto.

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"

#End Region

#Region "Métodos y procedimientos"

    Public Overrides Function Actualizar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_EMBARCADORES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_EMBARCADOR", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._CODIGO_EMBARCADOR.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_EMBARCADOR", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._NOMBRE_EMBARCADOR.ToUpper
            sqlParametro = .Parameters.Add("@RFC", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._RFC.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CURP", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._CURP.ToString.ToUpper
            sqlParametro = .Parameters.Add("@DOMICILIO", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._DOMICILIO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CIUDAD", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._CIUDAD.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTADO", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._ESTADO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@TELEFONO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._TELEFONO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CELULAR", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._CELULAR.ToString.ToUpper
            sqlParametro = .Parameters.Add("@FAX", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FAX.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_POSTAL", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_POSTAL.ToString.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_REPRESENTANTE", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._REPRESENTANTE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@RFC_REPRESENTANTE", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._RFC_REPRESENTANTE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@FDA", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._FDA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me._ESTATUS.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.NVarChar, 1) : sqlParametro.Value = "0"
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Actualizar = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Actualizar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try

        End With
    End Function                        'Actualiza un elemento del catálogo.

    Public Overrides Function Consultar() As Boolean
        Dim cmd As New SqlCommand(Me._QuerySelect & " WHERE CODIGO_EMBARCADOR=" & Replace(Me._CODIGO_EMBARCADOR, "'", "''") & "", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_EMBARCADOR = "" & dReader("CODIGO_EMBARCADOR")
                    Me._NOMBRE_EMBARCADOR = "" & dReader("NOMBRE_EMBARCADOR")
                    Me._RFC = "" & dReader("RFC")
                    Me._CURP = "" & dReader("CURP")
                    Me._DOMICILIO = "" & dReader("DOMICILIO")
                    Me._CIUDAD = "" & dReader("CIUDAD")
                    Me._ESTADO = "" & dReader("ESTADO")
                    Me._TELEFONO = "" & dReader("TELEFONO")
                    Me._CELULAR = "" & dReader("CELULAR")
                    Me._FAX = "" & dReader("FAX")
                    Me._CODIGO_POSTAL = "" & dReader("CODIGO_POSTAL")
                    Me._REPRESENTANTE = "" & dReader("NOMBRE_REPRESENTANTE")
                    Me._RFC_REPRESENTANTE = "" & dReader("RFC_REPRESENTANTE")
                    Me._FDA = "" & dReader("FDA")
                    Me._ESTATUS = "" & dReader("ESTATUS")

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

    Public Overrides Function Insertar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_EMBARCADORES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_EMBARCADOR", SqlDbType.NVarChar, 16) : sqlParametro.Direction = ParameterDirection.InputOutput : sqlParametro.Value = Me._CODIGO_EMBARCADOR.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_EMBARCADOR", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._NOMBRE_EMBARCADOR.ToUpper
            sqlParametro = .Parameters.Add("@RFC", SqlDbType.NVarChar, 16) : sqlParametro.Value = Me._RFC.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CURP", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._CURP.ToString.ToUpper
            sqlParametro = .Parameters.Add("@DOMICILIO", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._DOMICILIO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CIUDAD", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._CIUDAD.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTADO", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._ESTADO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@TELEFONO", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._TELEFONO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CELULAR", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._CELULAR.ToString.ToUpper
            sqlParametro = .Parameters.Add("@FAX", SqlDbType.NVarChar, 15) : sqlParametro.Value = Me._FAX.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_POSTAL", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_POSTAL.ToString.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_REPRESENTANTE", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._REPRESENTANTE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@RFC_REPRESENTANTE", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._RFC_REPRESENTANTE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@FDA", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._FDA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me._ESTATUS.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.NVarChar, 1) : sqlParametro.Value = "1"
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._CODIGO_EMBARCADOR = .Parameters("@CODIGO_EMBARCADOR").Value.ToString
                Insertar = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Insertar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try

        End With
    End Function                          'Inserta un elemento al catálogo.

    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCat_Vendedores As New SqlDataAdapter("SELECT CODIGO_EMBARCADOR,NOMBRE_EMBARCADOR FROM CAT_EMBARCADORES ORDER BY NOMBRE_EMBARCADOR", Me._Conexion)
        Try
            dsCat_Vendedores.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCat_Vendedores.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT CODIGO_EMBARCADOR,NOMBRE_EMBARCADOR FROM CAT_EMBARCADORES WHERE NOMBRE_EMBARCADOR LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_EMBARCADOR", Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerEstados() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCat_Estados As New SqlDataAdapter("SELECT COD_ESTADO,NOM_ESTADO FROM SISESTADOS ORDER BY NOM_ESTADO", Me._Conexion)
        Try
            dsCat_Estados.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerEstados", ex)
        Finally
            dsCat_Estados.Dispose()
        End Try
        Return dTable
    End Function

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de clientes por codigo."
        f.sCampo = "CODIGO_EMBARCADOR"
        f.sOrder = "NOMBRE_EMBARCADOR"
        f.sTable = "CAT_EMBARCADORES"
        f.sQl = "SELECT CODIGO_EMBARCADOR,NOMBRE_EMBARCADOR FROM CAT_EMBARCADORES WHERE 1=1 AND "
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorCodigo", ex)
        End Try
        Return Resultado
    End Function

    Public Overrides Function BusquedaVisual_PorDescripcion() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de clientes por Descripción."
        f.sCampo = "NOMBRE_EMBARCADOR"
        f.sOrder = "NOMBRE_EMBARCADOR"
        f.sTable = "CAT_EMBARCADORES"
        f.sQl = "SELECT CODIGO_EMBARCADOR,NOMBRE_EMBARCADOR FROM CAT_EMBARCADORES WHERE 1=1 AND "
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

    Public Function CodigoSiguiente() As String
        Dim iEmbarcadores As Integer, sEmbarcadores As String
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("SELECT MAX(CODIGO_EMBARCADOR) FROM CAT_EMBARCADORES")
            If sql.Result1 = "" Then
                iEmbarcadores = 1
            Else
                iEmbarcadores = CType(sql.Result1, Integer) + 1
            End If
            sEmbarcadores = "0000" + iEmbarcadores.ToString
            Resultado = sEmbarcadores.Substring(Len(sEmbarcadores) - 4)

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion", ex)
        End Try
        CodigoSiguiente = Resultado
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

