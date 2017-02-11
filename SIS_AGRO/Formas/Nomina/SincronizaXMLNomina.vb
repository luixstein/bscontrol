Option Strict On

Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Common
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data.OleDb
Imports System.IO
Imports System.Linq
Imports Ionic.Zip

Public Class SincronizaXMLNomina

    Private dtCaptura As New DataTable("dtCaptura")
    Private RutaNominaNET As String = "C:\AgroControl\NominaMovil" ' Path.GetPathRoot(My.Settings.Ruta) & "NominaNET"

    Private oHoja As New Class_NominaHoja

    'Public ConexionMDB As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & "C:\sys21\LAND PRODUCE\NOMINA.mdb" & ";Persist Security Info=False;"
    Public ConexionMDB As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & "\\" & Split(My.Settings.Servidor, "\")(0) & "\sys21\SYS21\LAND PRODUCE\NOMINA.mdb" & ";Persist Security Info=False;"

#Region "Propiedades"
    Private ReadOnly Property NombreClase() As String
        Get
            NombreClase = "SincronizaXMLNomina"
        End Get
    End Property
#End Region

#Region "Opciones"
    Private Sub btnBuscaArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaArchivo.Click
        Me.BuscarArchivo()
    End Sub

    Private Sub btnSincroniza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSincronizaSys.Click
        'Me.Sincroniza()
        Me.SincronizaDirectoAccess()
    End Sub

    Private Sub btnSincronizaAgrinet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSincronizaAgrinet.Click
        Me.SincronizaDirectoAgrinet()
    End Sub
#End Region

#Region "Eventos de objetos"
    Private Sub SincronizaXMLNomina_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Dir(RutaNominaNET, FileAttribute.Directory)) = 0 Then
            MkDir(RutaNominaNET)
        End If
        Me.cboTurno.Text = "MAÑANA"
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Private Sub BuscarArchivo()
        With OpenFileDialog1
            .InitialDirectory = Me.RutaNominaNET
            .Filter = "zip files (*.zip)|*.zip"
            .FilterIndex = 2
            .RestoreDirectory = True
            .FileName = ""
            .Multiselect = False
            .DefaultExt = ".zip"

            If .ShowDialog() = DialogResult.OK Then
                Me.txtRutaArchivo.Text = .FileName
            End If

        End With
    End Sub

    Private Function Unzip(ByVal ZipToUnpack As String) As Boolean
        Try
            Dim UnpackDirectory As String = Path.GetDirectoryName(ZipToUnpack)
            Using zip1 As ZipFile = ZipFile.Read(ZipToUnpack)
                For Each exx In zip1
                    exx.Extract(UnpackDirectory, ExtractExistingFileAction.OverwriteSilently)
                Next
            End Using
            Unzip = True
        Catch ex As Exception
            HandleError(Me.NombreClase, "Unzip", ex)
        End Try
    End Function

    Public Function CargaXMLCaptura() As Boolean
        Dim dInicio As Date = Date.Now
        Try
            Dim XmlCapturaArchivoZIP As String = Me.txtRutaArchivo.Text
            Dim XmlCapturaArchivoXML As String = IIf(XmlCapturaArchivoZIP.Length > 0, Path.ChangeExtension(Me.txtRutaArchivo.Text, "xml"), "").ToString
            Dim XmlCapturaSchema As String = IIf(XmlCapturaArchivoZIP.Length > 0, Path.GetDirectoryName(XmlCapturaArchivoZIP) & "\Captura.xls", "").ToString

            If txtLEN(XmlCapturaArchivoZIP) = False Then
                MsgBox("No seleccionó ningún archivo.", MsgBoxStyle.Exclamation, Me.Text)
                Me.btnSincronizaSys.Enabled = True
                Exit Function
            End If

            If File.Exists(XmlCapturaArchivoZIP) = False Then
                MsgBox("El archivo xml seleccionado no existe. Verifíquelo.", MsgBoxStyle.Exclamation, Me.Text)
                Me.btnSincronizaSys.Enabled = True
                Exit Function
            End If

            If Me.Unzip(XmlCapturaArchivoZIP) = False Then
                Exit Function
            End If

            If File.Exists(XmlCapturaSchema) = False Then 'Se pregunta despues porque va dentro del zip.
                MsgBox("El archivo xms(schema) no existe. Avíse al depto. de sistemas.", MsgBoxStyle.Exclamation, Me.Text)
                Me.btnSincronizaSys.Enabled = True
                Exit Function
            End If

            Me.dtCaptura.Dispose()
            Me.dtCaptura = New DataTable("dtCaptura")

            Dim fsReadXml As New System.IO.FileStream(XmlCapturaArchivoXML, System.IO.FileMode.Open)
            Dim fsReadXmlSchema As New System.IO.FileStream(XmlCapturaSchema, System.IO.FileMode.Open)

            Dim myXmlReader As New System.Xml.XmlTextReader(fsReadXml)
            Dim myXmlReaderSchema As New System.Xml.XmlTextReader(fsReadXmlSchema)

            Me.dtCaptura.ReadXmlSchema(myXmlReaderSchema)
            Me.dtCaptura.ReadXml(myXmlReader)

            myXmlReaderSchema.Close()
            myXmlReader.Close()

            CargaXMLCaptura = True
        Catch ex As Exception
            HandleError(Me.NombreClase, "CargaXMLCaptura", ex)
            Me.btnSincronizaSys.Enabled = True
        End Try
    End Function

    Public Function SincronizaDirectoAgrinet() As Boolean
        Me.btnSincronizaSys.Enabled = False
        Me.tssDuracion.Text = "Tiempo de ejecución :"

        If Me.CargaXMLCaptura = False Then
            MsgBox("No se cargó la información de la captura, no es posible sincronizar.", MsgBoxStyle.Exclamation, Me.Text)
            Me.btnSincronizaAgrinet.Enabled = True
            Exit Function
        End If

        Try
            Dim HJS = Me.dtCaptura.AsEnumerable()
            'Dim Hojas = (From c In HJS _
            '             Where c.Field(Of String)("TURNO") = Me.cboTurno.Text
            '            Select c!NUMERO_HOJA
            '            ).Distinct()

            'Dim RE = Me.dtCaptura.AsEnumerable()
            ' _
            Dim grupo = From r In HJS _
                        Where r.Field(Of String)("TURNO") = Me.cboTurno.Text _
            Group By NUMERO_HOJA = r.Field(Of String)("NUMERO_HOJA") _
            Into TOTAL_PERCEPCIONES = Sum(r.Field(Of Double)("IMPORTE")), CODIGO_CENTRO_COSTO = Max(r.Field(Of Integer)("CODIGO_CENTRO_COSTO")), _
            CODIGO_CULTIVO = Max(r.Field(Of String)("CODIGO_CULTIVO")), CODIGO_MERCADO = Max(r.Field(Of String)("CODIGO_MERCADO")), _
            CODIGO_LOTE = Max(r.Field(Of String)("CODIGO_LOTE")), CODIGO_ACTIVIDAD = Max(r.Field(Of String)("CODIGO_ACTIVIDAD")), _
            CODIGO_PUNTO_PAGO = Max(r.Field(Of Integer)("CODIGO_PUNTO_PAGO")), CODIGO_TIPO_PERCEPCION = Max(r.Field(Of Integer)("CODIGO_TIPO_PERCEPCION")), _
            HORAS_POR_TRABAJADOR = Max(r.Field(Of Integer)("NUMERO_HORAS")), FECHA = Max(r.Field(Of Date)("FECHA")), _
            TURNO = Max(r.Field(Of String)("TURNO")) _
            Select NUMERO_HOJA, CODIGO_CENTRO_COSTO, CODIGO_CULTIVO, CODIGO_LOTE, CODIGO_MERCADO, CODIGO_ACTIVIDAD, CODIGO_PUNTO_PAGO, CODIGO_TIPO_PERCEPCION, TOTAL_PERCEPCIONES, HORAS_POR_TRABAJADOR, FECHA, TURNO

            Me.ProgressBar1.Value = 0
            Me.ProgressBar1.Maximum = grupo.Count 'Me.dtCaptura.Rows.Count

            Dim i As Integer = 1
            'For Each j In Hojas

            For Each hj In grupo
                'Dim sHoja As Integer = CInt(hj)

                Dim dtHoja = Me.dtCaptura.AsEnumerable()
                Dim Hoja = From c In dtHoja _
                            Where c.Field(Of String)("NUMERO_HOJA") = hj.NUMERO_HOJA _
                            Select c

                With Me.oHoja
                    Dim sql As New Class_find("SELECT ID_NOMINA_DIA,NOMINA_GENERADA FROM VW_NOMINA_DIAS_EXTENDIDA WHERE ID_NOMINA_TEMPORADA=" & Plaza.oSisPlazaNomina.NOMINA_ID_NOMINA_TEMPORADA_ACTIVA & " AND FECHA='" & hj.FECHA.Date.Year.ToString & "-" & hj.FECHA.Date.Day.ToString & "-" & hj.FECHA.Date.Month.ToString & "'")
                    .ID_NOMINA_DIA = CInt(sql.Result1)

                    If sql.Result2.ToString = "1" Then
                        MsgBox("La nomina ya esta generada, no es posible sincronizar.", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                    End If

                    .NUMERO_HOJA = CInt(hj.NUMERO_HOJA) 'sNumeroHoja) grupo.Select(CInt("NUMERO_HOJA")) 
                    .CODIGO_CENTRO_COSTO = hj.CODIGO_CENTRO_COSTO 'CInt(hj("CODIGO_CENTRO_COSTO").ToString()) 'sCodigoCentroCosto
                    .CODIGO_CULTIVO = "" & hj.CODIGO_CULTIVO '("CODIGO_CULTIVO").ToString() 'sCodigoCultivo
                    .CODIGO_MERCADO = "" & hj.CODIGO_MERCADO '("CODIGO_MERCADO").ToString() 'sCodigoMercado
                    .CODIGO_LOTE = "" & hj.CODIGO_LOTE '("CODIGO_LOTE").ToString() 'sCodigoLote
                    .CODIGO_ACTIVIDAD = CInt(hj.CODIGO_ACTIVIDAD) '("CODIGO_ACTIVIDAD").ToString()) 'sCodigoActividad
                    .CODIGO_PUNTO_PAGO = CInt(hj.CODIGO_PUNTO_PAGO) '("CODIGO_PUNTO_PAGO").ToString()) 'sCodigoPuntoPago
                    .CODIGO_TIPO_PERCEPCION = CInt(hj.CODIGO_TIPO_PERCEPCION) '("CODIGO_TIPO_PERCEPCION").ToString()) 'sCodigoTipoPercepcion
                    .TOTAL_PERCEPCIONES = CDbl(hj.TOTAL_PERCEPCIONES)
                    .HORAS_POR_TRABAJADOR = CDbl(hj.HORAS_POR_TRABAJADOR) '("NUMERO_HORAS").ToString())
                    .TOTAL_JORNALES = Hoja.Count() * CDbl(hj.HORAS_POR_TRABAJADOR) / Plaza.oSisPlazaNomina.NOMINA_EQUIVALENCIA_JORNAL_HORAS
                    .TURNO = "" & hj.TURNO

                    If .Insertar(True) = False Then
                        MsgBox("Error al tratar de insertar la hoja.", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                    End If

                    For Each row In Hoja
                        'se graba el detalle
                        .oHojaPercepcion.ID_NOMINA_PERCEPCION = 0
                        .oHojaPercepcion.ID_NOMINA_HOJA = .ID_NOMINA_HOJA
                        .oHojaPercepcion.CODIGO_TRABAJADOR = row("CODIGO_TRABAJADOR").ToString() 'sCodigoTrabajador
                        .oHojaPercepcion.PERCEPCION = CDbl(row("IMPORTE").ToString()) 'dImporte
                        .oHojaPercepcion.CODIGO_PERCEPCION = 1

                        If .oHojaPercepcion.GrabaDetallePercepcion("INSERTAR") = False Then
                            MsgBox("Error al tratar de grabar el detalle de la hoja.", MsgBoxStyle.Exclamation, Me.Text)
                            Exit Function
                        End If
                    Next
                End With
                SincronizaDirectoAgrinet = True
                'MsgBox("Hoja grabada satisfactoriamente.", MsgBoxStyle.Information, Me.Text)

                '            sOrdenCaptura = Microsoft.VisualBasic.Right("000" & i, 3)
                '            cmdMDB = New OleDbCommand("INSERT INTO PERCEPCIONES(" & _
                '            "NUMSEM,NUMDIA,NUMHOJ,NUMTRA,APL2__,APL1__,APL3__,TIPPER,IMPORT,ORDEN,BASE,TABU," & _
                '            "CUADRILLA,PPAGO,UNIDADES,FECHA,PUNTOCOSTO,CENTROCOSTO)" & _
                '            "VALUES(@NUMSEM,@NUMDIA,@NUMHOJ,@NUMTRA,@APL2__,@APL1__,@APL3__,@TIPPER,@IMPORT,@ORDEN,@BASE,@TABU,@CUADRILLA,@PPAGO,@UNIDADES,@FECHA,@PUNTOCOSTO,@CENTROCOSTO)", ConexionMDB)

                '            cmdMDB.Parameters.Clear()

                '            Dim sPuntoPagoActualTrabajador As String = ""
                '            Dim sql As New OleDbCommand("SELECT PPAGO FROM EMPLEADOS WHERE NUMERO=@NUMERO", ConexionMDB)
                '            Dim dReader As OleDbDataReader

                '            sqlParametroMDB = sql.Parameters.Add("@NUMERO", OleDbType.VarWChar) : sqlParametroMDB.Value = row("CODIGO_TRABAJADOR").ToString()
                '            dReader = sql.ExecuteReader()
                '            If dReader.Read = True Then
                '                sPuntoPagoActualTrabajador = dReader("PPAGO").ToString
                '            End If
                '            dReader.Close()
                '            sql.Dispose()

                '            With cmdMDB
                '                sqlParametroMDB = .Parameters.Add("@NUMSEM", OleDbType.VarWChar) : sqlParametroMDB.Value = row("NUMERO_SEMANA").ToString() 'sNumeroSemana
                '                sqlParametroMDB = .Parameters.Add("@NUMDIA", OleDbType.VarWChar) : sqlParametroMDB.Value = row("NUMERO_DIA").ToString() 'sNumeroDia
                ''                sqlParametroMDB = .Parameters.Add("@NUMHOJ", OleDbType.VarWChar) : sqlParametroMDB.Value = row("NUMERO_HOJA").ToString() 'sNumeroHoja
                '                sqlParametroMDB = .Parameters.Add("@NUMTRA", OleDbType.VarWChar) : sqlParametroMDB.Value = row("CODIGO_TRABAJADOR").ToString() 'sCodigoTrabajador
                ''                sqlParametroMDB = .Parameters.Add("@APL2__", OleDbType.VarWChar) : sqlParametroMDB.Value = row("CODIGO_LOTE").ToString() 'sCodigoLote
                ''                sqlParametroMDB = .Parameters.Add("@APL1__", OleDbType.VarWChar) : sqlParametroMDB.Value = row("CODIGO_CULTIVO").ToString() 'sCodigoCultivo
                ''                sqlParametroMDB = .Parameters.Add("@APL3__", OleDbType.VarWChar) : sqlParametroMDB.Value = row("CODIGO_ACTIVIDAD").ToString() 'sCodigoActividad
                '                sqlParametroMDB = .Parameters.Add("@TIPPER", OleDbType.VarWChar) : sqlParametroMDB.Value = row("CODIGO_TIPO_PERCEPCION").ToString() 'sCodigoTipoPercepcion
                '                sqlParametroMDB = .Parameters.Add("@IMPORT", OleDbType.VarWChar) : sqlParametroMDB.Value = row("IMPORTE").ToString() 'dImporte
                '                sqlParametroMDB = .Parameters.Add("@ORDEN", OleDbType.VarWChar) : sqlParametroMDB.Value = sOrdenCaptura
                '                sqlParametroMDB = .Parameters.Add("@BASE", OleDbType.VarWChar) : sqlParametroMDB.Value = "0.00"
                '                sqlParametroMDB = .Parameters.Add("@TABU", OleDbType.VarWChar) : sqlParametroMDB.Value = "0"
                '                sqlParametroMDB = .Parameters.Add("@CUADRILLA", OleDbType.VarWChar) : sqlParametroMDB.Value = row("CODIGO_CENTRO_COSTO").ToString() 'sCodigoCentroCosto
                '                sqlParametroMDB = .Parameters.Add("@PPAGO", OleDbType.VarWChar) : sqlParametroMDB.Value = sPuntoPagoActualTrabajador
                '                sqlParametroMDB = .Parameters.Add("@UNIDADES", OleDbType.VarWChar) : sqlParametroMDB.Value = "0.00"
                '                sqlParametroMDB = .Parameters.Add("@FECHA", OleDbType.VarWChar) : sqlParametroMDB.Value = Format(CDate(row("FECHA").ToString), "yyyy/MM/dd") 'dFecha 'CDate(dFecha)
                ''                sqlParametroMDB = .Parameters.Add("@PUNTOCOSTO", OleDbType.VarWChar) : sqlParametroMDB.Value = row("CODIGO_PUNTO_PAGO").ToString() 'sCodigoPuntoPago
                ''                sqlParametroMDB = .Parameters.Add("@CENTROCOSTO", OleDbType.VarWChar) : sqlParametroMDB.Value = row("CODIGO_CENTRO_COSTO").ToString() 'sCodigoCentroCosto

                '                .ExecuteNonQuery()
                '            End With

                Me.ProgressBar1.Value += 1
                Application.DoEvents()
                i += 1
            Next
            '    Application.DoEvents()

            '    'Me.tssDuracion.Text = "Tiempo de ejecución : " & DateDiff(DateInterval.Second, dInicio, Date.Now).ToString & " seg;"
            'Me.tssDuracion.Text = "Tiempo de ejecución : " & DuracionSegundos(dInicio)
            MsgBox("Sincronización completada satisfactoriamente.", MsgBoxStyle.Information, Me.Text)

            '******************************************************************************************************************
            SincronizaDirectoAgrinet = True
            Me.btnSincronizaAgrinet.Enabled = True
            '******************************************************************************************************************
        Catch ex As Exception
            HandleError(Me.NombreClase, "Sincroniza", ex)
            Me.btnSincronizaAgrinet.Enabled = True
        Finally
            'ConexionMDB.Close()
            'cmdMDB.Dispose()
            'sqlParametroMDB = Nothing
        End Try
    End Function

    Public Function SincronizaDirectoAccess() As Boolean
        Dim ConexionSQLServer As New SqlConnection(Empresa_Sistema.conexion)
        Dim cmdSQLServer As New SqlCommand
        Dim sqlParametroSQLServer As New SqlParameter

        Dim ConexionMDB As New OleDbConnection(Me.ConexionMDB)
        Dim sqlParametroMDB As OleDbParameter
        Dim cmdMDB As New OleDbCommand("INSERT INTO PERCEPCIONES(" & _
        "NUMSEM,NUMDIA,NUMHOJ,NUMTRA,APL2__,APL1__,APL3__,TIPPER,IMPORT,ORDEN,BASE,TABU," & _
        "CUADRILLA,PPAGO,UNIDADES,FECHA,PUNTOCOSTO,CENTROCOSTO)" & _
        "VALUES(@NUMSEM,@NUMDIA,@NUMHOJ,@NUMTRA,@APL2__,@APL1__,@APL3__,@TIPPER,@IMPORT,@ORDEN,@BASE,@TABU,@CUADRILLA,@PPAGO,@UNIDADES,@FECHA,@PUNTOCOSTO,@CENTROCOSTO)", ConexionMDB)

        Try
            Dim dInicio As Date = Date.Now

            Me.btnSincronizaSys.Enabled = False

            Me.tssDuracion.Text = "Tiempo de ejecución :"

            If Me.CargaXMLCaptura = False Then
                MsgBox("No se cargó la información de la captura, no es posible sincronizar.", MsgBoxStyle.Exclamation, Me.Text)
                Me.btnSincronizaSys.Enabled = True
                Exit Function
            End If

            Me.ProgressBar1.Value = 0
            Me.ProgressBar1.Maximum = Me.dtCaptura.Rows.Count

            ConexionMDB.Open()

            Dim dtqCaptura = Me.dtCaptura.AsEnumerable()
            Dim Hojas = (From c In dtCaptura _
                         Select c!NUMERO_HOJA).Distinct()

            For Each hj In Hojas
                Dim sHoja As String = hj.ToString

                Dim dtHoja = Me.dtCaptura.AsEnumerable()
                Dim Hoja = (From c In dtHoja _
                            Where c.Field(Of String)("NUMERO_HOJA") = sHoja _
                            Select c)

                Dim i As Integer = 1
                Dim sOrdenCaptura As String = ""

                For Each row In Hoja
                    sOrdenCaptura = Microsoft.VisualBasic.Right("000" & i, 3)

                    cmdMDB = New OleDbCommand("INSERT INTO PERCEPCIONES(" & _
                    "NUMSEM,NUMDIA,NUMHOJ,NUMTRA,APL2__,APL1__,APL3__,TIPPER,IMPORT,ORDEN,BASE,TABU," & _
                    "CUADRILLA,PPAGO,UNIDADES,FECHA,PUNTOCOSTO,CENTROCOSTO)" & _
                    "VALUES(@NUMSEM,@NUMDIA,@NUMHOJ,@NUMTRA,@APL2__,@APL1__,@APL3__,@TIPPER,@IMPORT,@ORDEN,@BASE,@TABU,@CUADRILLA,@PPAGO,@UNIDADES,@FECHA,@PUNTOCOSTO,@CENTROCOSTO)", ConexionMDB)

                    cmdMDB.Parameters.Clear()

                    Dim sPuntoPagoActualTrabajador As String = ""
                    Dim sql As New OleDbCommand("SELECT PPAGO FROM EMPLEADOS WHERE NUMERO=@NUMERO", ConexionMDB)
                    Dim dReader As OleDbDataReader

                    sqlParametroMDB = sql.Parameters.Add("@NUMERO", OleDbType.VarWChar) : sqlParametroMDB.Value = row("CODIGO_TRABAJADOR").ToString()
                    dReader = sql.ExecuteReader()
                    If dReader.Read = True Then
                        sPuntoPagoActualTrabajador = dReader("PPAGO").ToString
                    End If
                    dReader.Close()
                    sql.Dispose()

                    With cmdMDB
                        sqlParametroMDB = .Parameters.Add("@NUMSEM", OleDbType.VarWChar) : sqlParametroMDB.Value = row("NUMERO_SEMANA").ToString() 'sNumeroSemana
                        sqlParametroMDB = .Parameters.Add("@NUMDIA", OleDbType.VarWChar) : sqlParametroMDB.Value = row("NUMERO_DIA").ToString() 'sNumeroDia
                        sqlParametroMDB = .Parameters.Add("@NUMHOJ", OleDbType.VarWChar) : sqlParametroMDB.Value = row("NUMERO_HOJA").ToString() 'sNumeroHoja
                        sqlParametroMDB = .Parameters.Add("@NUMTRA", OleDbType.VarWChar) : sqlParametroMDB.Value = row("CODIGO_TRABAJADOR").ToString() 'sCodigoTrabajador
                        sqlParametroMDB = .Parameters.Add("@APL2__", OleDbType.VarWChar) : sqlParametroMDB.Value = row("CODIGO_LOTE").ToString() 'sCodigoLote
                        sqlParametroMDB = .Parameters.Add("@APL1__", OleDbType.VarWChar) : sqlParametroMDB.Value = row("CODIGO_CULTIVO").ToString() 'sCodigoCultivo
                        sqlParametroMDB = .Parameters.Add("@APL3__", OleDbType.VarWChar) : sqlParametroMDB.Value = row("CODIGO_ACTIVIDAD").ToString() 'sCodigoActividad
                        sqlParametroMDB = .Parameters.Add("@TIPPER", OleDbType.VarWChar) : sqlParametroMDB.Value = row("CODIGO_TIPO_PERCEPCION").ToString() 'sCodigoTipoPercepcion
                        sqlParametroMDB = .Parameters.Add("@IMPORT", OleDbType.VarWChar) : sqlParametroMDB.Value = row("IMPORTE").ToString() 'dImporte
                        sqlParametroMDB = .Parameters.Add("@ORDEN", OleDbType.VarWChar) : sqlParametroMDB.Value = sOrdenCaptura
                        sqlParametroMDB = .Parameters.Add("@BASE", OleDbType.VarWChar) : sqlParametroMDB.Value = "0.00"
                        sqlParametroMDB = .Parameters.Add("@TABU", OleDbType.VarWChar) : sqlParametroMDB.Value = "0"
                        sqlParametroMDB = .Parameters.Add("@CUADRILLA", OleDbType.VarWChar) : sqlParametroMDB.Value = row("CODIGO_CENTRO_COSTO").ToString() 'sCodigoCentroCosto
                        sqlParametroMDB = .Parameters.Add("@PPAGO", OleDbType.VarWChar) : sqlParametroMDB.Value = sPuntoPagoActualTrabajador
                        sqlParametroMDB = .Parameters.Add("@UNIDADES", OleDbType.VarWChar) : sqlParametroMDB.Value = "0.00"
                        sqlParametroMDB = .Parameters.Add("@FECHA", OleDbType.VarWChar) : sqlParametroMDB.Value = Format(CDate(row("FECHA").ToString), "yyyy/MM/dd") 'dFecha 'CDate(dFecha)
                        sqlParametroMDB = .Parameters.Add("@PUNTOCOSTO", OleDbType.VarWChar) : sqlParametroMDB.Value = row("CODIGO_PUNTO_PAGO").ToString() 'sCodigoPuntoPago
                        sqlParametroMDB = .Parameters.Add("@CENTROCOSTO", OleDbType.VarWChar) : sqlParametroMDB.Value = row("CODIGO_CENTRO_COSTO").ToString() 'sCodigoCentroCosto

                        .ExecuteNonQuery()
                    End With

                    Me.ProgressBar1.Value += 1
                    Application.DoEvents()
                    i += 1

                Next

            Next

            Application.DoEvents()

            'Me.tssDuracion.Text = "Tiempo de ejecución : " & DateDiff(DateInterval.Second, dInicio, Date.Now).ToString & " seg;"
            Me.tssDuracion.Text = "Tiempo de ejecución : " & DuracionSegundos(dInicio)
            MsgBox("Sincronización completada satisfactoriamente.", MsgBoxStyle.Information, Me.Text)

            SincronizaDirectoAccess = True
            Me.btnSincronizaSys.Enabled = True

        Catch ex As Exception
            HandleError(Me.NombreClase, "Sincroniza", ex)
            Me.btnSincronizaSys.Enabled = True
        Finally
            ConexionMDB.Close()
            cmdMDB.Dispose()
            sqlParametroMDB = Nothing
        End Try
    End Function

    Public Function Sincroniza() As Boolean
        Dim Conexion As New SqlConnection(Empresa_Sistema.conexion)
        Dim cmd As New SqlCommand
        Dim sqlParametro As SqlParameter

        Try
            Dim dInicio As Date = Date.Now

            Me.btnSincronizaSys.Enabled = False

            Me.tssDuracion.Text = "Tiempo de ejecución :"

            If Me.CargaXMLCaptura = False Then
                MsgBox("No se cargó la información de la captura, no es posible sincronizar.", MsgBoxStyle.Exclamation, Me.Text)
                Me.btnSincronizaSys.Enabled = True
                Exit Function
            End If

            Conexion.Open()

            Me.ProgressBar1.Value = 0
            Me.ProgressBar1.Maximum = Me.dtCaptura.Rows.Count

            Dim dtqCaptura = Me.dtCaptura.AsEnumerable()
            Dim Hojas = (From c In dtCaptura _
                         Select c!NUMERO_HOJA).Distinct()

            For Each hj In Hojas
                Dim sHoja As String = hj.ToString

                Dim dtHoja = Me.dtCaptura.AsEnumerable()
                Dim Hoja = (From c In dtHoja _
                            Where c.Field(Of String)("NUMERO_HOJA") = sHoja _
                            Select c)

                Dim i As Integer = 1

                Dim j As Integer = 0
                Dim sCodigoTrabajador1 As String = "", sCodigoTrabajador2 As String = "", sCodigoTrabajador3 As String = "", sCodigoTrabajador4 As String = ""
                Dim dImporte1 As Double, dImporte2 As Double, dImporte3 As Double, dImporte4 As Double
                Dim sOrdenCaptura1 As String = "", sOrdenCaptura2 As String = "", sOrdenCaptura3 As String = "", sOrdenCaptura4 As String = ""
                Dim dRowImpar As DataRow

                For Each row In Hoja
                    Select Case j
                        Case 0
                            sCodigoTrabajador1 = row("CODIGO_TRABAJADOR").ToString
                            dImporte1 = CDbl(row("IMPORTE"))
                            j += 1
                            dRowImpar = row
                        Case 1
                            sCodigoTrabajador2 = row("CODIGO_TRABAJADOR").ToString
                            dImporte2 = CDbl(row("IMPORTE"))
                            j += 1
                        Case 2
                            sCodigoTrabajador3 = row("CODIGO_TRABAJADOR").ToString
                            dImporte3 = CDbl(row("IMPORTE"))
                            j += 1
                        Case 3
                            sCodigoTrabajador4 = row("CODIGO_TRABAJADOR").ToString
                            dImporte4 = CDbl(row("IMPORTE"))
                            j += 1
                    End Select


                    If j = 4 Then
                        sOrdenCaptura1 = Microsoft.VisualBasic.Right("000" & i, 3)
                        sOrdenCaptura2 = Microsoft.VisualBasic.Right("000" & i + 1, 3)
                        sOrdenCaptura3 = Microsoft.VisualBasic.Right("000" & i + 2, 3)
                        sOrdenCaptura4 = Microsoft.VisualBasic.Right("000" & i + 3, 3)

                        cmd = New SqlCommand
                        With cmd
                            .Connection = Conexion
                            .CommandTimeout = 0
                            .CommandType = CommandType.StoredProcedure
                            .CommandText = "MP_SYS21_NOMINA_GRABA_PERCEPCION"

                            sqlParametro = .Parameters.Add("@NUMERO_SEMANA", SqlDbType.SmallInt) : sqlParametro.Value = row("NUMERO_SEMANA").ToString
                            sqlParametro = .Parameters.Add("@NUMERO_DIA", SqlDbType.SmallInt) : sqlParametro.Value = row("NUMERO_DIA").ToString
                            sqlParametro = .Parameters.Add("@NUMERO_HOJA", SqlDbType.NVarChar, 4) : sqlParametro.Value = row("NUMERO_HOJA").ToString
                            sqlParametro = .Parameters.Add("@CODIGO_LOTE", SqlDbType.NVarChar, 2) : sqlParametro.Value = row("CODIGO_LOTE").ToString
                            sqlParametro = .Parameters.Add("@CODIGO_CULTIVO", SqlDbType.NVarChar, 2) : sqlParametro.Value = row("CODIGO_CULTIVO").ToString
                            sqlParametro = .Parameters.Add("@CODIGO_ACTIVIDAD", SqlDbType.NVarChar, 4) : sqlParametro.Value = row("CODIGO_ACTIVIDAD").ToString
                            sqlParametro = .Parameters.Add("@CODIGO_TIPO_PERCEPCION", SqlDbType.SmallInt) : sqlParametro.Value = row("CODIGO_TIPO_PERCEPCION").ToString
                            sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Format(CDate(row("FECHA").ToString), "yyyy/MM/dd")
                            sqlParametro = .Parameters.Add("@CODIGO_PUNTO_PAGO", SqlDbType.SmallInt) : sqlParametro.Value = row("CODIGO_PUNTO_PAGO").ToString
                            sqlParametro = .Parameters.Add("@CODIGO_CENTRO_COSTO", SqlDbType.SmallInt) : sqlParametro.Value = row("CODIGO_CENTRO_COSTO").ToString

                            sqlParametro = .Parameters.Add("@CODIGO_TRABAJADOR_1", SqlDbType.NVarChar, 5) : sqlParametro.Value = sCodigoTrabajador1
                            sqlParametro = .Parameters.Add("@IMPORTE_1", SqlDbType.Decimal) : sqlParametro.Value = dImporte1
                            sqlParametro = .Parameters.Add("@ORDEN_1", SqlDbType.NVarChar, 3) : sqlParametro.Value = sOrdenCaptura1

                            sqlParametro = .Parameters.Add("@CODIGO_TRABAJADOR_2", SqlDbType.NVarChar, 5) : sqlParametro.Value = sCodigoTrabajador2
                            sqlParametro = .Parameters.Add("@IMPORTE_2", SqlDbType.Decimal) : sqlParametro.Value = dImporte2
                            sqlParametro = .Parameters.Add("@ORDEN_2", SqlDbType.NVarChar, 3) : sqlParametro.Value = sOrdenCaptura2

                            sqlParametro = .Parameters.Add("@CODIGO_TRABAJADOR_3", SqlDbType.NVarChar, 5) : sqlParametro.Value = sCodigoTrabajador3
                            sqlParametro = .Parameters.Add("@IMPORTE_3", SqlDbType.Decimal) : sqlParametro.Value = dImporte3
                            sqlParametro = .Parameters.Add("@ORDEN_3", SqlDbType.NVarChar, 3) : sqlParametro.Value = sOrdenCaptura3

                            sqlParametro = .Parameters.Add("@CODIGO_TRABAJADOR_4", SqlDbType.NVarChar, 5) : sqlParametro.Value = sCodigoTrabajador4
                            sqlParametro = .Parameters.Add("@IMPORTE_4", SqlDbType.Decimal) : sqlParametro.Value = dImporte4
                            sqlParametro = .Parameters.Add("@ORDEN_4", SqlDbType.NVarChar, 3) : sqlParametro.Value = sOrdenCaptura4

                            .ExecuteNonQuery()
                        End With

                        Me.ProgressBar1.Value += 4
                        Application.DoEvents()
                        i += 4

                        sCodigoTrabajador1 = ""
                        sCodigoTrabajador2 = ""
                        sCodigoTrabajador3 = ""
                        sCodigoTrabajador4 = ""
                        dImporte1 = 0
                        dImporte2 = 0
                        dImporte3 = 0
                        dImporte4 = 0
                        sOrdenCaptura1 = ""
                        sOrdenCaptura2 = ""
                        sOrdenCaptura3 = ""
                        sOrdenCaptura4 = ""

                        j = 0
                    End If
                Next


                If j = 1 Or j = 2 Or j = 3 Then 'falto el impar
                    sOrdenCaptura1 = Microsoft.VisualBasic.Right("000" & i, 3)
                    Select Case j
                        Case 2
                            sOrdenCaptura2 = Microsoft.VisualBasic.Right("000" & i + 1, 3)
                        Case 3
                            sOrdenCaptura2 = Microsoft.VisualBasic.Right("000" & i + 1, 3)
                            sOrdenCaptura3 = Microsoft.VisualBasic.Right("000" & i + 2, 3)
                    End Select

                    cmd = New SqlCommand
                    With cmd
                        .Connection = Conexion
                        .CommandTimeout = 0
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "MP_SYS21_NOMINA_GRABA_PERCEPCION"

                        sqlParametro = .Parameters.Add("@NUMERO_SEMANA", SqlDbType.SmallInt) : sqlParametro.Value = dRowImpar("NUMERO_SEMANA").ToString
                        sqlParametro = .Parameters.Add("@NUMERO_DIA", SqlDbType.SmallInt) : sqlParametro.Value = dRowImpar("NUMERO_DIA").ToString
                        sqlParametro = .Parameters.Add("@NUMERO_HOJA", SqlDbType.NVarChar, 4) : sqlParametro.Value = dRowImpar("NUMERO_HOJA").ToString
                        sqlParametro = .Parameters.Add("@CODIGO_LOTE", SqlDbType.NVarChar, 2) : sqlParametro.Value = dRowImpar("CODIGO_LOTE").ToString
                        sqlParametro = .Parameters.Add("@CODIGO_CULTIVO", SqlDbType.NVarChar, 2) : sqlParametro.Value = dRowImpar("CODIGO_CULTIVO").ToString
                        sqlParametro = .Parameters.Add("@CODIGO_ACTIVIDAD", SqlDbType.NVarChar, 4) : sqlParametro.Value = dRowImpar("CODIGO_ACTIVIDAD").ToString
                        sqlParametro = .Parameters.Add("@CODIGO_TIPO_PERCEPCION", SqlDbType.SmallInt) : sqlParametro.Value = dRowImpar("CODIGO_TIPO_PERCEPCION").ToString
                        sqlParametro = .Parameters.Add("@FECHA", SqlDbType.DateTime) : sqlParametro.Value = Format(CDate(dRowImpar("FECHA").ToString), "yyyy/MM/dd")
                        sqlParametro = .Parameters.Add("@CODIGO_PUNTO_PAGO", SqlDbType.SmallInt) : sqlParametro.Value = dRowImpar("CODIGO_PUNTO_PAGO").ToString
                        sqlParametro = .Parameters.Add("@CODIGO_CENTRO_COSTO", SqlDbType.SmallInt) : sqlParametro.Value = dRowImpar("CODIGO_CENTRO_COSTO").ToString

                        sqlParametro = .Parameters.Add("@CODIGO_TRABAJADOR_1", SqlDbType.NVarChar, 5) : sqlParametro.Value = sCodigoTrabajador1
                        sqlParametro = .Parameters.Add("@IMPORTE_1", SqlDbType.Decimal) : sqlParametro.Value = dImporte1
                        sqlParametro = .Parameters.Add("@ORDEN_1", SqlDbType.NVarChar, 3) : sqlParametro.Value = sOrdenCaptura1

                        sqlParametro = .Parameters.Add("@CODIGO_TRABAJADOR_2", SqlDbType.NVarChar, 5) : sqlParametro.Value = sCodigoTrabajador2
                        sqlParametro = .Parameters.Add("@IMPORTE_2", SqlDbType.Decimal) : sqlParametro.Value = dImporte2
                        sqlParametro = .Parameters.Add("@ORDEN_2", SqlDbType.NVarChar, 3) : sqlParametro.Value = sOrdenCaptura2

                        sqlParametro = .Parameters.Add("@CODIGO_TRABAJADOR_3", SqlDbType.NVarChar, 5) : sqlParametro.Value = sCodigoTrabajador3
                        sqlParametro = .Parameters.Add("@IMPORTE_3", SqlDbType.Decimal) : sqlParametro.Value = dImporte3
                        sqlParametro = .Parameters.Add("@ORDEN_3", SqlDbType.NVarChar, 3) : sqlParametro.Value = sOrdenCaptura3

                        sqlParametro = .Parameters.Add("@CODIGO_TRABAJADOR_4", SqlDbType.NVarChar, 5) : sqlParametro.Value = ""
                        sqlParametro = .Parameters.Add("@IMPORTE_4", SqlDbType.Decimal) : sqlParametro.Value = 0
                        sqlParametro = .Parameters.Add("@ORDEN_4", SqlDbType.NVarChar, 3) : sqlParametro.Value = ""

                        .ExecuteNonQuery()
                    End With

                    Me.ProgressBar1.Value += j
                    Application.DoEvents()
                    i += j

                End If

            Next

            Me.tssDuracion.Text = "Tiempo de ejecución : " & DuracionSegundos(dInicio)
            MsgBox("Sincronización completada satisfactoriamente.", MsgBoxStyle.Information, Me.Text)

            Sincroniza = True
            Me.btnSincronizaSys.Enabled = True

        Catch ex As Exception
            HandleError(Me.NombreClase, "Sincroniza", ex)
            Me.btnSincronizaSys.Enabled = True
        Finally
            Conexion.Close()
            cmd.Dispose()
            sqlParametro = Nothing
        End Try
    End Function

    'Private Sub EjemploZip_Unzip()
    '    Dim exx As ZipEntry

    '    Using zip As ZipFile = New ZipFile()
    '        zip.AddFile("C:\NominaNET\Captura260312.xml", "")
    '        zip.Save("C:\Temp\MyZipFile.zip")
    '    End Using

    '    Dim ZipToUnpack As String = "C:\Temp\MyZipFile.zip"
    '    Dim UnpackDirectory As String = "C:\Temp"
    '    Using zip1 As ZipFile = ZipFile.Read(ZipToUnpack)
    '        ' here, we extract every entry, but we could extract conditionally,
    '        ' based on entry name, size, date, checkbox status, etc.   
    '        For Each exx In zip1
    '            exx.Extract(UnpackDirectory, ExtractExistingFileAction.OverwriteSilently)
    '        Next
    '    End Using
    'End Sub


#End Region

End Class