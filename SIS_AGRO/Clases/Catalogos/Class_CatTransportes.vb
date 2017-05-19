
Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatTransportes

    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_TRANSPORTE As String
    Private _CODIGO_LINEA_TRANSPORTE As String
    Private _CODIGO_MARCA As String
    Private _MARCA As String
    Private _MODELO As String
    Private _PLACA As String
    Private _SERIE As String
    Private _SCAC As String
    Private _FDA As String
    Private _CODIGO_PLAZA As Integer
    Private _ESTATUS As String
#End Region

#Region "Campos ligados a la tabla"
    Private _Existe As Boolean
    Private _NOMBRE_LINEA_TRANSPORTE As String
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
    Public Property CODIGO_TRANSPORTE() As String
        Get
            Return Me._CODIGO_TRANSPORTE
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_TRANSPORTE = VALUE
        End Set
    End Property

    Public Property CODIGO_LINEA_TRANSPORTE() As String
        Get
            Return Me._CODIGO_LINEA_TRANSPORTE
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_LINEA_TRANSPORTE = VALUE
        End Set
    End Property

    Public Property CODIGO_MARCA() As String
        Get
            Return Me._CODIGO_MARCA
        End Get
        Set(ByVal VALUE As String)
            Me._CODIGO_MARCA = VALUE
        End Set
    End Property
    Public Property MARCA() As String
        Get
            Return Me._MARCA
        End Get
        Set(ByVal VALUE As String)
            Me._MARCA = VALUE
        End Set
    End Property

    Public Property MODELO() As String
        Get
            Return Me._MODELO
        End Get
        Set(ByVal VALUE As String)
            Me._MODELO = VALUE
        End Set
    End Property

    Public Property PLACA() As String
        Get
            Return Me._PLACA
        End Get
        Set(ByVal VALUE As String)
            Me._PLACA = VALUE
        End Set
    End Property
    Public Property SERIE() As String
        Get
            Return Me._SERIE
        End Get
        Set(ByVal VALUE As String)
            Me._SERIE = VALUE
        End Set
    End Property
    Public Property SCAC() As String
        Get
            Return Me._SCAC
        End Get
        Set(ByVal VALUE As String)
            Me._SCAC = VALUE
        End Set
    End Property
    Public Property FDA() As String
        Get
            Return Me._FDA
        End Get
        Set(ByVal VALUE As String)
            Me._FDA = VALUE
        End Set
    End Property

    Public Property CODIGO_PLAZA() As Integer
        Get
            Return Me._CODIGO_PLAZA
        End Get
        Set(ByVal VALUE As Integer)
            Me._CODIGO_PLAZA = VALUE
        End Set
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public ReadOnly Property Existe() As Boolean
        Get
            Return Me._Existe
        End Get
    End Property

    Public ReadOnly Property NOMBRE_LINEA_TRANSPORTE() As String
        Get
            Return Me._NOMBRE_LINEA_TRANSPORTE
        End Get
    End Property
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
    'Public Property Estatus() As String
    '    Get
    '        Return Me._Estatus
    '    End Get
    '    Set(ByVal value As String)
    '        Me._Estatus = value
    '    End Set
    'End Property

#End Region

#End Region

#Region "Constructor y destructor"

    Public Sub New()
        Me._Nombre_Catalogo = "CAT_TRANSPORTES"
        Me._Nombre_Reporte = "RPT_CATALOGO_TRANSPORTES"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * From CAT_TRANSPORTES"
        Me._QueryOrder = " Order by MODELO"
    End Sub                                                         'Inicializa al objeto.

    Public Sub New(ByVal sCodigoTransporte As String)
        Me.New()
        Me._CODIGO_TRANSPORTE = sCodigoTransporte
        Try
            If Me.Consultar = True Then
                Me._Existe = True
                'Else
                '    Throw New Exception("El transporte no existe.")
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

#Region "Opciones"

#End Region

#Region "Métodos y procedimientos"

    Public Overrides Function Insertar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_TRANSPORTES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_TRANSPORTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_TRANSPORTE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_LINEA_TRANSPORTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_LINEA_TRANSPORTE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_MARCA", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_MARCA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@MODELO", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._MODELO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@PLACA", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._PLACA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@SERIE", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._SERIE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@SCAC", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._SCAC.ToString.ToUpper
            sqlParametro = .Parameters.Add("@FDA", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._FDA.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._CODIGO_TRANSPORTE = .Parameters("@CODIGO_TRANSPORTE").Value.ToString
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

    Public Overrides Function Actualizar() As Boolean
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_CAT_TRANSPORTES_GRABA"

            sqlParametro = .Parameters.Add("@CODIGO_TRANSPORTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_TRANSPORTE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_LINEA_TRANSPORTE", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_LINEA_TRANSPORTE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_MARCA", SqlDbType.NVarChar, 8) : sqlParametro.Value = Me._CODIGO_MARCA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@MODELO", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._MODELO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@PLACA", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._PLACA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@SERIE", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._SERIE.ToString.ToUpper
            sqlParametro = .Parameters.Add("@SCAC", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._SCAC.ToString.ToUpper
            sqlParametro = .Parameters.Add("@FDA", SqlDbType.NVarChar, 30) : sqlParametro.Value = Me._FDA.ToUpper
            sqlParametro = .Parameters.Add("@CODIGO_PLAZA", SqlDbType.SmallInt) : sqlParametro.Value = Usuario.Codigo_Plaza
            sqlParametro = .Parameters.Add("@ESTATUS", SqlDbType.Char, 1) : sqlParametro.Value = Me.Estatus.ToString.ToUpper
            sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "0"
            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                Me._CODIGO_TRANSPORTE = .Parameters("@CODIGO_TRANSPORTE").Value.ToString
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
        Dim cmd As New SqlCommand("Select T.*,L.NOMBRE_LINEA_TRANSPORTE,M.MARCA_TRANSPORTE from CAT_TRANSPORTES T INNER JOIN CAT_LINEAS_TRANSPORTES L ON(T.CODIGO_LINEA_TRANSPORTE=L.CODIGO_LINEA_TRANSPORTE) " & _
                                  "INNER JOIN CAT_MARCAS_TRANSPORTES M ON(T.CODIGO_MARCA=M.CODIGO_MARCA) " & _
                                  " Where CODIGO_TRANSPORTE='" & Replace(Me._CODIGO_TRANSPORTE, "'", "''") & "' AND T.CODIGO_PLAZA=" & Usuario.Codigo_Plaza, Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_TRANSPORTE = "" & dReader("CODIGO_TRANSPORTE").ToString
                    Me._CODIGO_LINEA_TRANSPORTE = "" & dReader("CODIGO_LINEA_TRANSPORTE").ToString
                    Me._CODIGO_MARCA = "" & dReader("CODIGO_MARCA").ToString
                    Me._MARCA = "" & dReader("MARCA_TRANSPORTE").ToString
                    Me._MODELO = "" & dReader("MODELO").ToString
                    Me._PLACA = "" & dReader("PLACA").ToString
                    Me._SERIE = "" & dReader("SERIE").ToString
                    Me._SCAC = "" & dReader("SCAC").ToString
                    Me._FDA = "" & dReader("FDA").ToString
                    Me.Estatus = "" & dReader("ESTATUS").ToString
                    Me._NOMBRE_LINEA_TRANSPORTE = "" & dReader("NOMBRE_LINEA_TRANSPORTE").ToString
                    Me._CODIGO_PLAZA = CInt(dReader("CODIGO_PLAZA").ToString)
                    Consultar = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With

    End Function        'Consulta un elemento del catálogo.

    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCAT_Lineas As New SqlDataAdapter(Me._QuerySelect & " WHERE CODIGO_PLAZA=" & Usuario.Codigo_Plaza & Me._QueryOrder, Me._Conexion)
        Try
            dsCAT_Lineas.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCAT_Lineas.Dispose()
        End Try
        Return dTable
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.
    Public Function ObtenerElementosN() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCAT_Lineas As New SqlDataAdapter("SELECT CODIGO_TRANSPORTE, PLACA FROM CAT_TRANSPORTES WHERE CODIGO_PLAZA=" & Usuario.Codigo_Plaza & " ORDER BY PLACA", Me._Conexion)
        Try
            dsCAT_Lineas.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCAT_Lineas.Dispose()
        End Try
        Return dTable
    End Function    'Obtiene una lita completa de los elementos del catalogo en un datatable.

    Public Function ObtenerElementosFiltro(ByVal Filtro As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dA As New SqlDataAdapter("SELECT CODIGO_TRANSPORTE, PLACA FROM CAT_TRANSPORTES WHERE CODIGO_PLAZA=" & Usuario.Codigo_Plaza & " AND PLACA LIKE '" & Filtro.ToString & "%' ORDER BY PLACA", Me._Conexion)
        Try
            dA.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementosFiltro", ex)
        Finally
            dA.Dispose()
        End Try
        Return dTable
    End Function

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda por codigo de transporte."
        f.sCampo = "CODIGO_TRANSPORTE"
        f.sOrder = "MARCA_TRANSPORTE"
        f.sTable = "PLACA"
        f.sQl = "Select CODIGO_TRANSPORTE,PLACA From CAT_TRANSPORTES Where 1=1  AND  CODIGO_PLAZA=" & Usuario.Codigo_Plaza & " And"
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
        f.Text = "Búsqueda de placa del transporte."
        f.sCampo = "PLACA "
        f.sOrder = "PLACA"
        f.sTable = "VW_CAT_TRANSPORTES_EXTENDIDOS"
        f.sQl = "SELECT CODIGO_TRANSPORTE,PLACA,MARCA_TRANSPORTE,MODELO,NOMBRE_LINEA_TRANSPORTE,CUENTA_CONTABLE_FLETERO From VW_CAT_TRANSPORTES_EXTENDIDOS Where 1=1 AND CODIGO_PLAZA=" & Usuario.Codigo_Plaza & " AND "
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
        Dim iLineaTransporte As Integer, sLineaTransporte As String = "", sLineaTransporte1 As String = ""
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("SELECT MAX(CODIGO_TRANSPORTE) FROM CAT_TRANSPORTES  WHERE CODIGO_PLAZA=" & Usuario.Codigo_Plaza.ToString)
            If sql.Result1 = "" Then
                iLineaTransporte = 1
            Else
                If Usuario.Codigo_Plaza = 1 Then
                    iLineaTransporte = CType(sql.Result1, Integer) + 1
                    sLineaTransporte = iLineaTransporte.ToString
                    'sLineaTransporte = sLineaTransporte '.Substring(Len(sLineaTransporte) - 4)
                    sLineaTransporte = "0000" + iLineaTransporte.ToString
                    sLineaTransporte = sLineaTransporte.Substring(Len(sLineaTransporte) - 4)
                Else
                    'iLineaTransporte = CInt(Strings.Right(sql.Result1, 3))
                    'iLineaTransporte = iLineaTransporte + 1
                    'sLineaTransporte = sql.Result1.Substring(0, sql.Result1.IndexOf("-"))
                    'sLineaTransporte = sLineaTransporte + "-" + sLineaTransporte.Substring(Len("0000" + iLineaTransporte.ToString) - 3)

                    iLineaTransporte = CInt(Strings.Right(sql.Result1, 3))
                    iLineaTransporte = iLineaTransporte + 1
                    sLineaTransporte1 = "0000" + iLineaTransporte.ToString
                    sLineaTransporte = sql.Result1.Substring(0, sql.Result1.ToString.IndexOf("-"))
                    sLineaTransporte = sLineaTransporte + "-" + sLineaTransporte1.Substring(Len(sLineaTransporte1) - 3)
                End If

            End If
           
            Resultado = sLineaTransporte
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "CodigoSiguiente", ex)
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
