Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatProductores
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_PRODUCTOR As String
    Private _NOMBRE_PRODUCTOR As String
    Private _RFC As String
    Private _DOMICILIO As String
    Private _CIUDAD As String
    Private _ESTADO As String
    Private _DESTINO As String
    Private _TELEFONO As String
    Private _FAX As String
    Private _CODIGO_POSTAL As String
    Private _ESTATUS As String

#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean
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

    Public Property CODIGO_PRODUCTOR() As String
        Get
            Return Me._CODIGO_PRODUCTOR
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_PRODUCTOR = Value
        End Set
    End Property

    Public Property NOMBRE_PRODUCTOR() As String
        Get
            Return Me._NOMBRE_PRODUCTOR
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_PRODUCTOR = Value
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

    Public Property DESTINO() As String
        Get
            Return Me._DESTINO
        End Get
        Set(ByVal Value As String)
            Me._DESTINO = Value
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
    'Public Property ESTATUS() As String
    '    Get
    '        Return Me._ESTATUS
    '    End Get
    '    Set(ByVal Value As String)
    '        Me._ESTATUS = Value
    '    End Set
    'End Property
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

    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property

#End Region
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Nombre_Catalogo = "CAT_PRODUCTORES"
        Me._Nombre_Reporte = "RPT_CATALOGO_PRODUCTORES"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT * FROM CAT_PRODUCTORES "
        Me._QueryOrder = " ORDER BY NOMBRE_PRODUCTOR"
    End Sub

    Public Sub New(ByVal sCodigoPRODUCTOR As String)
        Me.New()
        Me._CODIGO_PRODUCTOR = sCodigoPRODUCTOR
        Try
            If Me.Consultar = True Then
                Me._Existe = True
                'Else
                '    Throw New Exception("El PRODUCTOR no existe.")
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "New", ex)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"

    Public Overrides Function Actualizar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_PRODUCTORES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_PRODUCTOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_PRODUCTOR.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_PRODUCTOR", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._NOMBRE_PRODUCTOR.ToUpper
            sqlParametro = .Parameters.Add("@RFC", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._RFC.ToUpper
            sqlParametro = .Parameters.Add("@DOMICILIO", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._DOMICILIO.ToUpper
            sqlParametro = .Parameters.Add("@CIUDAD", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._CIUDAD.ToUpper
            sqlParametro = .Parameters.Add("@ESTADO", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._ESTADO.ToUpper
            sqlParametro = .Parameters.Add("@DESTINO", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._DESTINO
            sqlParametro = .Parameters.Add("@TELEFONO", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._TELEFONO.ToUpper
            sqlParametro = .Parameters.Add("@FAX", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._FAX.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_POSTAL", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._CODIGO_POSTAL.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "0"

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
    End Function

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de PRODUCTOR por Código."
        f.sCampo = "CODIGO_PRODUCTOR"
        f.sOrder = "NOMBRE_PRODUCTOR"
        f.sTable = "CAT_PRODUCTORES"
        f.sQl = "SELECT CODIGO_PRODUCTOR, NOMBRE_PRODUCTOR FROM CAT_PRODUCTORES WHERE 1=1 AND"
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
        f.Text = "Búsqueda de PRODUCTOR por Nombre."
        f.sCampo = "NOMBRE_PRODUCTOR"
        f.sOrder = "NOMBRE_PRODUCTOR"
        f.sTable = "CAT_PRODUCTORES"
        f.sQl = "SELECT CODIGO_PRODUCTOR, NOMBRE_PRODUCTOR FROM CAT_PRODUCTORES WHERE 1=1 AND"
        f.Inicia("")
        f.ShowDialog()
        Try
            If f.iRows > 0 Then
                Resultado = CType(f.GridBusqueda.Item(f.GridBusqueda.CurrentCell.RowNumber, 0), String)
            End If
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorNombre", ex)
        End Try
        Return Resultado
    End Function

    Public Overrides Function Consultar() As Boolean
        Dim cmd As New SqlCommand(Me._QuerySelect & " Where CODIGO_PRODUCTOR='" & Replace(Me._CODIGO_PRODUCTOR, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_PRODUCTOR = dReader("CODIGO_PRODUCTOR").ToString()
                    Me._NOMBRE_PRODUCTOR = Trim("" & dReader("NOMBRE_PRODUCTOR").ToString())
                    Me._RFC = dReader("RFC").ToString()
                    Me._DOMICILIO = dReader("DOMICILIO").ToString()
                    Me._CIUDAD = "" & dReader("CIUDAD").ToString()
                    Me._ESTADO = dReader("ESTADO").ToString()
                    Me._DESTINO = dReader("DESTINO").ToString()
                    Me._TELEFONO = dReader("TELEFONO").ToString()
                    Me._FAX = dReader("FAX").ToString()
                    Me._CODIGO_POSTAL = dReader("CODIGO_POSTAL").ToString()
                    Me.Estatus = "" & dReader("ESTATUS").ToString()

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
    End Function

    Public Overrides Function Insertar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_PRODUCTORES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_PRODUCTOR", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_PRODUCTOR.ToUpper
            sqlParametro = .Parameters.Add("@NOMBRE_PRODUCTOR", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._NOMBRE_PRODUCTOR.ToUpper
            sqlParametro = .Parameters.Add("@RFC", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._RFC.ToUpper
            sqlParametro = .Parameters.Add("@DOMICILIO", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._DOMICILIO.ToUpper
            sqlParametro = .Parameters.Add("@CIUDAD", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._CIUDAD.ToUpper
            sqlParametro = .Parameters.Add("@ESTADO", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._ESTADO.ToUpper
            sqlParametro = .Parameters.Add("@DESTINO", SqlDbType.NVarChar, 50) : sqlParametro.Value = Me._DESTINO
            sqlParametro = .Parameters.Add("@TELEFONO", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._TELEFONO.ToUpper
            sqlParametro = .Parameters.Add("@FAX", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._FAX.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_POSTAL", SqlDbType.NVarChar, 120) : sqlParametro.Value = Me._CODIGO_POSTAL.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.NVarChar, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._CODIGO_PRODUCTOR = .Parameters("@CODIGO_PRODUCTOR").Value.ToString
                Insertar = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Insertar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

    End Function

    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCatProductores As New SqlDataAdapter("SELECT CODIGO_PRODUCTOR, NOMBRE_PRODUCTOR FROM CAT_PRODUCTORES ORDER BY NOMBRE_PRODUCTOR", Me._Conexion)
        Try
            dsCatProductores.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCatProductores.Dispose()
        End Try
        ObtenerElementos = dTable
    End Function

    Public Function ObtenerElementosParaReportes() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCatProductores As New SqlDataAdapter("SELECT CODIGO_PRODUCTOR, NOMBRE_PRODUCTOR FROM CAT_PRODUCTORES ORDER BY NOMBRE_PRODUCTOR", Empresa_Sistema.conexion)
        Try
            dsCatProductores.Fill(dTable)
            dTable.Rows.Add("T", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosParaReportes", ex)
        Finally
            dsCatProductores.Dispose()
        End Try
        ObtenerElementosParaReportes = dTable
    End Function

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT CODIGO_PRODUCTOR, NOMBRE_PRODUCTOR FROM CAT_PRODUCTORES WHERE NOMBRE_PRODUCTOR LIKE '" & Filtro.ToString & "%' ORDER BY NOMBRE_PRODUCTOR", Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
    End Function

    Public Function CodigoSiguiente() As String
        Dim iPRODUCTOR As Integer, sPRODUCTOR As String
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("SELECT MAX(CODIGO_PRODUCTOR) FROM CAT_PRODUCTORES")
            If sql.Result1 = "" Then
                iPRODUCTOR = 1
            Else
                iPRODUCTOR = CType(sql.Result1, Integer) + 1
            End If
            sPRODUCTOR = "0000" + iPRODUCTOR.ToString
            Resultado = sPRODUCTOR.Substring(Len(sPRODUCTOR) - 4)

        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "BusquedaVisual_PorDescripcion", ex)
        End Try
        CodigoSiguiente = Resultado
    End Function
#End Region

End Class

