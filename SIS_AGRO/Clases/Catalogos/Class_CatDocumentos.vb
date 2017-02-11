Imports System.Data
Imports System.Data.SqlClient

Public Class Class_CatDocumentos
    Inherits Class_Catalogos

#Region "Campos"

#Region "Campos de la tabla"
    Private _CODIGO_DOCUMENTO As String
    Private _NOMBRE_DOCUMENTO As String
    Private _ESTATUS_DOCUMENTO As String
    Private _FOLIO As String
    Private _FOLIO_NUMERICO As String
    Private _CODIGO_PLAZA As Integer
    Private _CONSECUTIVO_DE_FOLIO As String
    Private _CODIGO_ASIENTO_REPETITIVO As String
    Private _NOMBRE_FORMATO As String
    Private _NATURALEZA_INVENTARIOS As String
#End Region

#Region "Campos ligados a la tabla"
    Private _AFECTA_INVENTARIOS As Boolean
    Private _AFECTA_CONTABILIDAD As Boolean
    Private _AFECTA_CXC As Boolean
    Private _AFECTA_CXP As Boolean
    Private _CODIGO_TIPO_DOCUMENTO As String
    Private _CODIGO_MERCADO As String
    Private _TIMBRA_DOCUMENTO As Boolean
    Private _ACCESIBLE_USUARIO As String
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
    Public Overridable Property CODIGO_DOCUMENTO() As String
        Get
            Return Me._CODIGO_DOCUMENTO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_DOCUMENTO = Value
        End Set
    End Property

    Public Property NOMBRE_DOCUMENTO() As String
        Get
            Return Me._NOMBRE_DOCUMENTO
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_DOCUMENTO = Value
        End Set
    End Property

    Public Overridable Property ESTATUS_DOCUMENTO() As String
        Get
            Return Me._ESTATUS_DOCUMENTO
        End Get
        Set(ByVal Value As String)
            Me._ESTATUS_DOCUMENTO = Value
        End Set
    End Property

    Public ReadOnly Property FOLIO() As String
        Get
            Return Me._FOLIO
        End Get
    End Property

    Public ReadOnly Property FOLIO_NUMERICO() As String
        Get
            Return Me._FOLIO_NUMERICO
        End Get
    End Property

    Public Property CODIGO_PLAZA() As String
        Get
            Return Me._CODIGO_PLAZA
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_PLAZA = Value
        End Set
    End Property

    Public Property CONSECUTIVO_DE_FOLIO() As String
        Get
            Return Me._CONSECUTIVO_DE_FOLIO
        End Get
        Set(ByVal Value As String)
            Me._CONSECUTIVO_DE_FOLIO = Value
        End Set
    End Property

    Public Property CODIGO_ASIENTO_REPETITIVO() As String
        Get
            Return Me._CODIGO_ASIENTO_REPETITIVO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_ASIENTO_REPETITIVO = Value
        End Set
    End Property

    Public Property NOMBRE_FORMATO() As String
        Get
            Return Me._NOMBRE_FORMATO
        End Get
        Set(ByVal Value As String)
            Me._NOMBRE_FORMATO = Value
        End Set
    End Property
    Public ReadOnly Property NATURALEZA_INVENTARIOS() As String
        Get
            Return Me._NATURALEZA_INVENTARIOS
        End Get
    End Property
#End Region

#Region "Propiedades de campos ligados a la tabla"
    Public Property AFECTA_INVENTARIOS() As Boolean
        Get
            Return Me._AFECTA_INVENTARIOS
        End Get
        Set(ByVal Value As Boolean)
            Me._AFECTA_INVENTARIOS = Value
        End Set
    End Property

    Public Property AFECTA_CONTBILIDAD() As Boolean
        Get
            Return Me._AFECTA_CONTABILIDAD
        End Get
        Set(ByVal Value As Boolean)
            Me._AFECTA_CONTABILIDAD = Value
        End Set
    End Property

    Public Property AFECTA_CXC() As Boolean
        Get
            Return Me._AFECTA_CXC
        End Get
        Set(ByVal Value As Boolean)
            Me._AFECTA_CXC = Value
        End Set
    End Property

    Public Property AFECTA_CXP() As Boolean
        Get
            Return Me._AFECTA_CXP
        End Get
        Set(ByVal Value As Boolean)
            Me._AFECTA_CXP = Value
        End Set
    End Property

    Public Property CODIGO_TIPO_DOCUMENTO() As String
        Get
            Return Me._CODIGO_TIPO_DOCUMENTO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_TIPO_DOCUMENTO = Value
        End Set
    End Property

    Public Property CODIGO_MERCADO() As String
        Get
            Return Me._CODIGO_MERCADO
        End Get
        Set(ByVal Value As String)
            Me._CODIGO_MERCADO = Value
        End Set
    End Property

    Public Property TIMBRA_DOCUMENTO() As Boolean
        Get
            Return Me._TIMBRA_DOCUMENTO
        End Get
        Set(ByVal Value As Boolean)
            Me._TIMBRA_DOCUMENTO = Value
        End Set
    End Property

    Public ReadOnly Property ACCESIBLE_USUARIO() As Boolean
        Get
            Return Me._ACCESIBLE_USUARIO
        End Get
    End Property
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
        Me._Nombre_Catalogo = "CatDOCUMENTOS"
        Me._Nombre_Reporte = "RPT_CATALOGO_DOCUMENTOS.rpt"
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
        Me._QuerySelect = "Select * From VW_SIS_CAT_DOCUMENTOS_EXTENDIDO"
        Me._QueryOrder = " Order by NOMBRE_DOCUMENTO"
    End Sub

    Public Sub New(ByVal Codigo_documento As String)
        Me.New()
        Me._CODIGO_DOCUMENTO = Codigo_documento
        Me.Consultar()
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Overrides Function Actualizar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter
        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_ACTUALIZA_DOCUMENTOS"
            sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_DOCUMENTO.ToUpper
            'sqlParametro = .Parameters.Add("@NOMBRE_DOCUMENTO", SqlDbType.Char, 30) : sqlParametro.Value = Me._NOMBRE_DOCUMENTO.ToString.ToUpper
            'sqlParametro = .Parameters.Add("@CODIGO_MODULO", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._CODIGO_MODULO.ToUpper
            sqlParametro = .Parameters.Add("@CONSECUTIVO_DE_FOLIO", SqlDbType.Char, 1) : sqlParametro.Value = Me._CONSECUTIVO_DE_FOLIO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@FOLIO", SqlDbType.NVarChar, 12) : sqlParametro.Value = Me._FOLIO.ToUpper
            'sqlParametro = .Parameters.Add("@TIPOINV", SqlDbType.Char, 2) : sqlParametro.Value = Me._TIPOINV.ToString.ToUpper
            'sqlParametro = .Parameters.Add("@FORMATO_REPORTE", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._FORMATO_REPORTE.ToUpper
            'sqlParametro = .Parameters.Add("@IMPUESTOS", SqlDbType.Char, 1) : sqlParametro.Value = Me._IMPUESTOS.ToString.ToUpper
            'sqlParametro = .Parameters.Add("@AFECTA", SqlDbType.Char, 1) : sqlParametro.Value = Me._AFECTA.ToString.ToUpper
            'sqlParametro = .Parameters.Add("@TIPOCARGO", SqlDbType.Char, 1) : sqlParametro.Value = Me._TIPOCARGO.ToString.ToUpper
            'sqlParametro = .Parameters.Add("@PANTALLA", SqlDbType.Char, 1) : sqlParametro.Value = Me._PANTALLA.ToString.ToUpper
            sqlParametro = .Parameters.Add("@ESTATUS_DOCUMENTO", SqlDbType.Char, 1) : sqlParametro.Value = Me._ESTATUS_DOCUMENTO.ToString.ToUpper
            sqlParametro = .Parameters.Add("@PLAZA", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_PLAZA.ToString.ToUpper

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                bResultado = True
            Catch ex As Exception
                HandleError(Me._Nombre_Catalogo, "Actualizar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With

        Return bResultado
    End Function

    Public Overrides Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " Where CODIGO_DOCUMENTO='" & Replace(Me._CODIGO_DOCUMENTO, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_DOCUMENTO = "" & dReader("CODIGO_DOCUMENTO").ToString
                    Me._CODIGO_TIPO_DOCUMENTO = "" & dReader("CODIGO_TIPO_DOCUMENTO").ToString
                    Me._Nombre_Reporte = "" & dReader("NOMBRE_FORMATO").ToString
                    Me._FOLIO = "" & dReader("FOLIO").ToString
                    Me._AFECTA_INVENTARIOS = dReader("AFECTA_INVENTARIOS")
                    Me._AFECTA_CONTABILIDAD = dReader("AFECTA_CONTABILIDAD")
                    Me._AFECTA_CXC = dReader("AFECTA_CXC")
                    Me._AFECTA_CXP = dReader("AFECTA_CXP")
                    Me._NATURALEZA_INVENTARIOS = dReader("NATURALEZA_INVENTARIOS")
                    Me._CODIGO_MERCADO = dReader("CODIGO_MERCADO")
                    Me._TIMBRA_DOCUMENTO = CBool(dReader("TIMBRA_DOCUMENTO"))
                    Me._ACCESIBLE_USUARIO = CBool(dReader("ACCESIBLE_USUARIO"))

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "Consultar", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With

        Return bResultado
    End Function

    Public Function ConsultarTipoDocumento() As Boolean
        Dim bResultado As Boolean = False
        Dim cmd As New SqlCommand(Me._QuerySelect & " Where CODIGO_TIPO_DOCUMENTO='" & Replace(Me._CODIGO_TIPO_DOCUMENTO, "'", "''") & "'", Me._Conexion)
        Dim dReader As SqlDataReader
        With cmd
            .CommandTimeout = 0
            .CommandType = CommandType.Text
            Try
                Me._Conexion.Open()
                dReader = .ExecuteReader()

                If dReader.Read Then
                    Me._CODIGO_DOCUMENTO = "" & dReader("CODIGO_DOCUMENTO").ToString
                    Me._CODIGO_TIPO_DOCUMENTO = "" & dReader("CODIGO_TIPO_DOCUMENTO").ToString
                    Me._Nombre_Reporte = "" & dReader("NOMBRE_FORMATO").ToString
                    Me._FOLIO = "" & dReader("FOLIO").ToString
                    Me._AFECTA_INVENTARIOS = dReader("AFECTA_INVENTARIOS")
                    Me._AFECTA_CONTABILIDAD = dReader("AFECTA_CONTABILIDAD")
                    Me._AFECTA_CXC = dReader("AFECTA_CXC")
                    Me._AFECTA_CXP = dReader("AFECTA_CXP")
                    Me._CODIGO_MERCADO = dReader("CODIGO_MERCADO")
                    Me._TIMBRA_DOCUMENTO = CBool(dReader("TIMBRA_DOCUMENTO"))

                    bResultado = True
                End If
                dReader.Close()
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "ConsultarTipoDocumento", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
            End Try
        End With

        Return bResultado
    End Function

    Public Overrides Function Insertar() As Boolean
        MsgBox("Función no disponible. Contácte a su administrador de sistemas.", MsgBoxStyle.Exclamation)
        'Dim cmd As New SqlCommand
        'Dim sqlParametro As SqlParameter
        'With cmd
        ' .Connection = Me._Conexion
        ' .CommandTimeout = 0
        ' .CommandType = CommandType.StoredProcedure
        ' .CommandText = "MP_INSERTA_DOCUMENTOS"

        'sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 2) : sqlParametro.Value = Me._CODIGO_DOCUMENTO.ToUpper
        'sqlParametro = .Parameters.Add("@NOMBRE_DOCUMENTO", SqlDbType.Char, 30) : sqlParametro.Value = Me._NOMBRE_DOCUMENTO.ToString.ToUpper
        'sqlParametro = .Parameters.Add("@CODIGO_MODULO", SqlDbType.NVarChar, 3) : sqlParametro.Value = Me._CODIGO_MODULO.ToUpper
        'sqlParametro = .Parameters.Add("@CONSECUTIVO_DE_FOLIO", SqlDbType.Char, 1) : sqlParametro.Value = Me._CONSECUTIVO_DE_FOLIO.ToString.ToUpper
        'sqlParametro = .Parameters.Add("@FOLIO", SqlDbType.NVarChar, 12) : sqlParametro.Value = Me._FOLIO.ToUpper
        'sqlParametro = .Parameters.Add("@TIPOINV", SqlDbType.Char, 2) : sqlParametro.Value = Me._TIPOINV.ToString.ToUpper
        'sqlParametro = .Parameters.Add("@FORMATO_REPORTE", SqlDbType.NVarChar, 20) : sqlParametro.Value = Me._FORMATO_REPORTE.ToUpper
        'sqlParametro = .Parameters.Add("@IMPUESTOS", SqlDbType.Char, 1) : sqlParametro.Value = Me._IMPUESTOS.ToString.ToUpper
        'sqlParametro = .Parameters.Add("@AFECTA", SqlDbType.Char, 1) : sqlParametro.Value = Me._AFECTA.ToString.ToUpper
        'sqlParametro = .Parameters.Add("@TIPOCARGO", SqlDbType.Char, 1) : sqlParametro.Value = Me._TIPOCARGO.ToString.ToUpper
        'sqlParametro = .Parameters.Add("@PANTALLA", SqlDbType.Char, 1) : sqlParametro.Value = Me._PANTALLA.ToString.ToUpper

        'Try
        ' Me._Conexion.Open()
        ' .ExecuteNonQuery()
        ' Insertar= True
        ' Catch ex As Exception
        ' HandleError(Me._Nombre_Catalogo, "Insertar", ex)
        ' Finally
        'Me._Conexion.Close()
        'cmd.Dispose()
        'sqlParametro = Nothing
        'End Try

        'End With
    End Function

    Public Overrides Function ObtenerElementos() As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCaDocumentos As New SqlDataAdapter("SELECT CODIGO_TIPO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM SIS_TIPOS_DOCUMENTOS", Me._Conexion)
        Try
            dsCaDocumentos.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerElementos", ex)
        Finally
            dsCaDocumentos.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerCodigosDocumentos(ByVal Modulo As String, ByVal CodigoPlaza As String, Optional ByVal Condicion As String = "") As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCaDocumentos As New SqlDataAdapter
        Dim Sql As String

        If txtLEN(Condicion) = True Then
            Condicion = "AND " & Condicion
        End If

        If Modulo = "" Then 'VW_CAT_REL_DOCUMENTOS_USUARIOS 
            Sql = "SELECT DISTINCT CODIGO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO,ORDEN FROM VW_SIS_CAT_DOCUMENTOS_EXTENDIDO WHERE CODIGO_PLAZA=" & CodigoPlaza.ToString & " AND ACCESIBLE_USUARIO=1 "
        Else
            'If bAccesible = True Then
            '    Condicion = Condicion & " AND ACCESIBLE_USUARIO=1 "
            'End If
            Sql = "SELECT DISTINCT CODIGO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO,ORDEN FROM VW_SIS_CAT_DOCUMENTOS_EXTENDIDO WHERE CODIGO_PLAZA=" & CodigoPlaza.ToString & " AND CODIGO_MODULO='" & Modulo & "' " & Condicion
        End If

        dsCaDocumentos = New SqlDataAdapter(Sql, Me._Conexion)
        'If Tipo = "DEPOSITO" Then dsCaDocumentos = New SqlDataAdapter("SELECT CODIGO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM VW_SIS_CAT_DOCUMENTOS_EXTENDIDO WHERE CODIGO_MODULO='BAN' AND NOMBRE_TIPO_DOCUMENTO = 'DEPOSITO'", Me._Conexion)
        'If Tipo = "TIPODEPOSITO" Then dsCaDocumentos = New SqlDataAdapter("SELECT CODIGO_TIPO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM VW_SIS_CAT_DOCUMENTOS_EXTENDIDO WHERE CODIGO_MODULO='CXC'", Me._Conexion)
        Try
            dsCaDocumentos.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerCodigosDocumentos", ex)
        Finally
            dsCaDocumentos.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerCodigosDocumentosParaReportes(Optional ByVal Modulo As String = "") As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCaDocumentos As New SqlDataAdapter
        Dim Sql As String

        If Modulo = "" Then 'VW_CAT_REL_DOCUMENTOS_USUARIOS 
            Sql = "SELECT DISTINCT CODIGO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM VW_SIS_CAT_DOCUMENTOS_EXTENDIDO"
        Else
            Sql = "SELECT DISTINCT CODIGO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM VW_SIS_CAT_DOCUMENTOS_EXTENDIDO WHERE CODIGO_MODULO='" & Modulo & "'  "
        End If
        'd()
        dsCaDocumentos = New SqlDataAdapter(Sql, Me._Conexion)
        Try
            dsCaDocumentos.Fill(dTable)
            dTable.Rows.Add("T", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerCodigosDocumentosParaReportes", ex)
        Finally
            dsCaDocumentos.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerTipoDocumentos(Optional ByVal Modulo As String = "", Optional ByVal IdPLAZA As String = "0", Optional ByVal Condicion As String = "") As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCaDocumentos As New SqlDataAdapter
        Dim Sql As String
        'If Modulo = "" Then
        ' Sql = "SELECT DISTINCT CODIGO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM VW_CAT_REL_DOCUMENTOS_USUARIOS WHERE ID_PLAZA=" & IdPLAZA & " and CODIGO_USUARIO=" & Usuario.Codigo_Usuario & " and " & Condicion
        ' Else
        ' Sql = "SELECT DISTINCT CODIGO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM VW_CAT_REL_DOCUMENTOS_USUARIOS WHERE CODIGO_MODULO='" & Modulo & "' and ID_PLAZA=" & IdPLAZA & " and CODIGO_USUARIO=" & Usuario.Codigo_Usuario & " and " & Condicion
        ' End If

        'Sql = "SELECT DISTINCT CODIGO_TIPO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM VW_SIS_CAT_DOCUMENTOS_EXTENDIDO WHERE " & Condicion

        If Modulo = "" Then 'VW_CAT_REL_DOCUMENTOS_USUARIOS 
            Sql = "SELECT DISTINCT CODIGO_TIPO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM VW_SIS_CAT_DOCUMENTOS_EXTENDIDO WHERE " & Condicion
        Else
            Sql = "SELECT DISTINCT CODIGO_TIPO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM VW_SIS_CAT_DOCUMENTOS_EXTENDIDO WHERE CODIGO_MODULO='" & Modulo & "' and CODIGO_PLAZA=" & IdPLAZA & " and " & Condicion
        End If

        dsCaDocumentos = New SqlDataAdapter(Sql, Me._Conexion)
        'If Tipo = "DEPOSITO" Then dsCaDocumentos = New SqlDataAdapter("SELECT CODIGO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM VW_SIS_CAT_DOCUMENTOS_EXTENDIDO WHERE CODIGO_MODULO='BAN' AND NOMBRE_TIPO_DOCUMENTO = 'DEPOSITO'", Me._Conexion)
        'If Tipo = "TIPODEPOSITO" Then dsCaDocumentos = New SqlDataAdapter("SELECT CODIGO_TIPO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM VW_SIS_CAT_DOCUMENTOS_EXTENDIDO WHERE CODIGO_MODULO='CXC'", Me._Conexion)
        Try
            dsCaDocumentos.Fill(dTable)
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerTipoDocumentos", ex)
        Finally
            dsCaDocumentos.Dispose()
        End Try
        Return dTable
    End Function

    Public Function ObtenerTiposDocumentosParaReportes(Optional ByVal Modulo As String = "", Optional ByVal IdPLAZA As String = "0", Optional ByVal Condicion As String = "") As System.Data.DataTable
        Dim dTable As New DataTable
        Dim dsCaDocumentos As New SqlDataAdapter
        Dim Sql As String

        If Modulo = "" Then
            Sql = "SELECT DISTINCT CODIGO_TIPO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM VW_SIS_CAT_DOCUMENTOS_EXTENDIDO WHERE " & Condicion
        Else
            Sql = "SELECT DISTINCT CODIGO_TIPO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM VW_SIS_CAT_DOCUMENTOS_EXTENDIDO WHERE CODIGO_MODULO='" & Modulo & "' and CODIGO_PLAZA=" & IdPLAZA & " and " & Condicion
        End If
        dsCaDocumentos = New SqlDataAdapter(Sql, Me._Conexion)

        Try
            dsCaDocumentos.Fill(dTable)
            dTable.Rows.Add("T", "TODOS")
        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "ObtenerTiposDocumentosParaReportes", ex)
        Finally
            dsCaDocumentos.Dispose()
        End Try

        Return dTable
    End Function

    Public Overrides Function BusquedaVisual_PorCodigo() As String
        Dim f As New BusquedaVisual
        Dim Resultado As String = ""
        f.Text = "Búsqueda de Documentos por Código."
        f.sCampo = "CODIGO_DOCUMENTO"
        f.sOrder = "NOMBRE_DOCUMENTO"
        f.sTable = "CATDOCUMENTOS"
        f.sQl = "Select CODIGO_DOCUMENTO,NOMBRE_DOCUMENTO,CODIGO_PLAZA From CATDOCUMENTOS Where 1=1 And"
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
        f.Text = "Búsqueda de Documentos por Descripción."
        f.sCampo = "NOMBRE_DOCUMENTO"
        f.sOrder = "NOMBRE_DOCUMENTO"
        f.sTable = "CATDOCUMENTOS"
        f.sQl = "Select CODIGO_DOCUMENTO,NOMBRE_DOCUMENTO,CODIGO_PLAZA From CATDOCUMENTOS Where 1=1 And"
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

    Public Function GeneraFolio() As Boolean
        Dim cmd As SqlCommand
        Dim sqlParametro As SqlParameter

        Try
            Me._Conexion.Open()
            cmd = New SqlCommand
            With cmd
                .Connection = Me._Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MP_UTILERIAS_GENERA_FOLIO_DOCUMENTO"

                sqlParametro = .Parameters.Add("@CODIGO_DOCUMENTO", SqlDbType.NVarChar, 10) : sqlParametro.Value = Me._CODIGO_DOCUMENTO
                sqlParametro = .Parameters.Add("@VFOLIO", SqlDbType.NVarChar, 16) : sqlParametro.Direction = ParameterDirection.Output
                sqlParametro = .Parameters.Add("@FOLIO_NUMERICO", SqlDbType.Int) : sqlParametro.Direction = ParameterDirection.Output

                .ExecuteNonQuery()

                Me._FOLIO = "" & .Parameters("@VFOLIO").Value.ToString
                Me._FOLIO_NUMERICO = "" & .Parameters("@FOLIO_NUMERICO").Value.ToString
            End With

        Catch ex As Exception
            HandleError(Me._Nombre_Catalogo, "GeneraFolio", ex)
        Finally
            cmd = Nothing
            Me._Conexion.Close()
            sqlParametro = Nothing
        End Try
    End Function

    Public Function GeneraFolioCheque(ByVal IDCuentaBancaria As Integer) As String
        Dim Error1 As String = "", sFolio As String = ""
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter

        With cmd
            .Connection = Me._Conexion
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MP_UTILERIAS_GENERA_FOLIO_CHEQUE"

            sqlParametro = .Parameters.Add("@FOLIO_CHEQUE", SqlDbType.NVarChar, 15) : sqlParametro.Direction = ParameterDirection.Output
            sqlParametro = .Parameters.Add("@ID_CUENTA_BANCARIA", SqlDbType.SmallInt) : sqlParametro.Value = IDCuentaBancaria

            Try
                Me._Conexion.Open()
                .ExecuteNonQuery()
                sFolio = "" & .Parameters("@FOLIO_CHEQUE").Value.ToString
            Catch ex As Exception
                HandleError(Me.Nombre_Catalogo, "GeneraFolioCheque", ex)
            Finally
                Me._Conexion.Close()
                cmd.Dispose()
                sqlParametro = Nothing
            End Try
        End With
        Return sFolio
    End Function

    Public Function ObtenerTiposFacturas() As DataTable
        Dim dt As New DataTable
        Try
            Using da As New SqlDataAdapter("SELECT CODIGO_DOCUMENTO,NOMBRE_TIPO_DOCUMENTO FROM VW_SIS_CAT_DOCUMENTOS_EXTENDIDO WHERE CODIGO_MODULO='VTA' AND AFECTA_CXC=1 AND AFECTA_CONTABILIDAD=1 ORDER BY NOMBRE_TIPO_DOCUMENTO", Me._Conexion)
                da.SelectCommand.CommandType = CommandType.Text
                da.Fill(dt)
            End Using
        Catch ex As Exception
            HandleError(Me.Nombre_Catalogo, "ObtenerTiposFacturas", ex)
        End Try
        Return dt
    End Function

#End Region

End Class