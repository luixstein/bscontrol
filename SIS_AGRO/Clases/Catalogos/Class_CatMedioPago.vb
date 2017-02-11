Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatMedioPago
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _ID_MEDIO_PAGO As Integer
    Private _NOMBRE_MEDIO_PAGO As String
    Private _DATOS_BANCARIOS As Integer
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
    Public Property ID_MEDIO_PAGO() As Integer
        Get
            Return Me._ID_MEDIO_PAGO
        End Get
        Set(ByVal Value As Integer)
            Me._ID_MEDIO_PAGO = Value
        End Set
    End Property

    Public Property NOMBRE_MEDIO_PAGO() As String
        Get
            Return Me._NOMBRE_MEDIO_PAGO
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_MEDIO_PAGO = Value
        End Set
    End Property

    Public Property DATOS_BANCARIOS() As Integer
        Get
            Return Me._DATOS_BANCARIOS
        End Get
        Set(ByVal Value As Integer)
            Me._DATOS_BANCARIOS = Value
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
        Me._Nombre_Catalogo = "SIS_MEDIOS_PAGO"
        Me._Nombre_Reporte = "RPT_SIS_MEDIOS_PAGO.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "SELECT ID_MEDIO_PAGO,NOMBRE_MEDIO_PAGO FROM SIS_MEDIOS_PAGO"
        Me._QueryOrder = " ORDER BY NOMBRE_MEDIO_PAGO"
    End Sub                                                         'Inicializa al objeto.

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Opciones"

#End Region

#Region "Métodos y procedimientos"

    Public Overrides Function Insertar() As Boolean
        'Dim cmd As New SqlCommand
        'Dim sqlParametro As SqlParameter
        'With cmd
        '    .Connection = Me._Conexion
        '    .CommandTimeout = 0
        '    .CommandType = CommandType.StoredProcedure
        '    .CommandText = "MP_SIS_MEDIOS_PAGO_GRABA"

        '    sqlParametro = .Parameters.Add("@ID_MEDIO_PAGO", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._ID_MEDIO_PAGO
        '    sqlParametro = .Parameters.Add("@NOMBRE_MEDIO_PAGO", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._NOMBRE_MEDIO_PAGO.ToString
        '    sqlParametro = .Parameters.Add("@Estatus", SqlDbType.Char, 1) : sqlParametro.Value = "A"
        '    sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"
        '    Try
        '        Me._Conexion.Open()
        '        .ExecuteNonQuery()
        '        Insertar = True
        '    Catch ex As Exception
        '        HandleError(Me._Nombre_Catalogo, "Insertar", ex)
        '    Finally
        '        Me._Conexion.Close()
        '        cmd.Dispose()
        '        sqlParametro = Nothing
        '    End Try

        'End With
    End Function                          'Inserta un elemento al catálogo.

    Public Overrides Function Actualizar() As Boolean
        'Dim cmd As New SqlCommand
        'Dim sqlParametro As SqlParameter
        'With cmd
        '    .Connection = Me._Conexion
        '    .CommandTimeout = 0
        '    .CommandType = CommandType.StoredProcedure
        '    .CommandText = "MP_SIS_MEDIOS_PAGO_GRABA"

        '    sqlParametro = .Parameters.Add("@ID_MEDIO_PAGO", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._ID_MEDIO_PAGO
        '    sqlParametro = .Parameters.Add("@NOMBRE_MEDIO_PAGO", SqlDbType.NVarChar, 80) : sqlParametro.Value = Me._NOMBRE_MEDIO_PAGO.ToString
        '    sqlParametro = .Parameters.Add("@Estatus", SqlDbType.Char, 1) : sqlParametro.Value = "A"
        '    sqlParametro = .Parameters.Add("@AGREGAR", SqlDbType.Char, 1) : sqlParametro.Value = "1"
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

    Public Overrides Function Consultar() As Boolean
        Dim cmd As New SqlCommand("Select * from SIS_MEDIOS_PAGO Where ID_MEDIO_PAGO='" & Replace(Me._ID_MEDIO_PAGO, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._ID_MEDIO_PAGO = "" & dReader("ID_MEDIO_PAGO").ToString
                    Me._NOMBRE_MEDIO_PAGO = Trim("" & dReader("NOMBRE_MEDIO_PAGO").ToString)
                    Me.Estatus = "" & dReader("ESTATUS").ToString
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
        Dim dsCAT_Lineas As New SqlDataAdapter(Me._QuerySelect & Me._QueryOrder, Me._Conexion)
        Try
            dsCAT_Lineas.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCAT_Lineas.Dispose()
        End Try
        Return dTable
    End Function

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de medios de pago por codigo."
        f.sCampo = "ID_MEDIO_PAGO"
        f.sOrder = "NOMBRE_MEDIO_PAGO"
        f.sTable = "SIS_MEDIOS_PAGO"
        f.sQl = "SELECT ID_MEDIO_PAGO,NOMBRE_MEDIO_PAGO FROM SIS_MEDIOS_PAGO WHERE 1=1 AND"
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
        f.Text = "Búsqueda de medios de pago por descripción."
        f.sCampo = "ID_MEDIO_PAGO"
        f.sOrder = "NOMBRE_MEDIO_PAGO"
        f.sTable = "SIS_MEDIOS_PAGO"
        f.sQl = "SELECT ID_MEDIO_PAGO,NOMBRE_MEDIO_PAGO FROM SIS_MEDIOS_PAGO WHERE 1=1 AND"
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
        Dim iEMPAQUE As Integer, sEmpaque As String
        Dim Resultado As String = ""
        Try
            Dim sql As New Class_find("SELECT MAX(ID_MEDIO_PAGO) FROM SIS_MEDIOS_PAGO")
            If sql.Result1 = "" Then
                iEMPAQUE = 1
            Else
                iEMPAQUE = CType(sql.Result1, Integer) + 1
            End If
            sEmpaque = "00" + iEMPAQUE.ToString
            Resultado = sEmpaque.Substring(Len(sEmpaque) - 2)
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
