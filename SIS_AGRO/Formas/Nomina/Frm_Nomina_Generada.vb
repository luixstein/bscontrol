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
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports System.Data.OleDb

Public Class Frm_Nomina_Generada
    Private _ID_NOMINA_SEMANA As Integer
    Private _ACCION As String = "LISTAR_DISPERSION"
    Private _RANGO As Integer = 100

    Dim oNominaSemana As Class_NominaSemana

    Private igyCodigo As Short = 1
    Private igyNombreCompleto As Short = 2
    Private igyNumeroSemana As Short = 3
    Private igyFechaDeduccion As Short = 4
    Private igyIdDeduccionDetalle As Short = 5
    Private igyPercepciones As Short = 6
    Private igySindicato As Short = 7
    Private igyDescuento As Short = 8
    Private igyAbonar As Short = 9

    Private igyDispersionCodigo As Short = 1
    Private igyDispersionNombreCompleto As Short = 2
    Private igyDispersionNumeroTarjera As Short = 3
    Private igyDispersionImporte As Short = 4
    Private igyDispersionRechazado As Short = 5
    Private igyDispersionPagoRealizado As Short = 6

    Private sNombreTxt As String = ""

#Region "Propiedades"
    Public WriteOnly Property ID_NOMINA_SEMANA() As Integer
        Set(ByVal Value As Integer)
            Me._ID_NOMINA_SEMANA = Value
        End Set
    End Property

    Public WriteOnly Property ACCION() As String
        Set(ByVal Value As String)
            Me._ACCION = Value
        End Set
    End Property

    Public WriteOnly Property RANGO() As Integer
        Set(ByVal Value As Integer)
            Me._RANGO = Value
        End Set
    End Property
#End Region

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.InicializaGrid()
            Me.InicializaGridDispersion()
            Me.txtAceptados.Text = "0"
            Me.txtRechazados.Text = "0"
            Me.txtTotalTrabajadores.Text = "0"
            Me.txtTotal.Text = "0"
            Me.lblConfimado.Text = "Dispersion sin confirmar"

            Me.dtFechaDispersion.Value = Now.AddDays(1)
           
            'Me.TcNomina.SelectedIndex = 0
            'Me.TcNomina.TabPages(1).Enabled = False
        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Me.GridDeduccion.DataSource = Nothing
        FG_Grid_Limpiar(Me.GridDeduccion)

        Me.GridDeduccion.Rows = 2
        Me.GridDeduccion.Cols = 10

        Me.FormateaGrid()
    End Sub

    Private Sub InicializaGridDispersion()
        Me.GridDeduccion.DataSource = Nothing
        FG_Grid_Limpiar(Me.GridDispersion)

        Me.GridDispersion.Rows = 2
        Me.GridDispersion.Cols = 7

        Me.FormateaGridDispersion()
    End Sub

    Private Sub FormateaGrid()
        Me.GridDeduccion.Column(Me.igyCodigo).Width = 60
        Me.GridDeduccion.Column(Me.igyNombreCompleto).Width = 180
        Me.GridDeduccion.Column(Me.igyNumeroSemana).Width = 80
        Me.GridDeduccion.Column(Me.igyFechaDeduccion).Width = 80
        Me.GridDeduccion.Column(Me.igyIdDeduccionDetalle).Width = 100
        Me.GridDeduccion.Column(Me.igyPercepciones).Width = 80
        Me.GridDeduccion.Column(Me.igySindicato).Width = 80
        Me.GridDeduccion.Column(Me.igyDescuento).Width = 80
        Me.GridDeduccion.Column(Me.igyAbonar).Width = 70

        Me.GridDeduccion.Cell(0, Me.igyCodigo).Text = "Código"
        Me.GridDeduccion.Cell(0, Me.igyNombreCompleto).Text = "Nombre"
        Me.GridDeduccion.Cell(0, Me.igyNumeroSemana).Text = "Semana"
        Me.GridDeduccion.Cell(0, Me.igyFechaDeduccion).Text = "Fecha"
        Me.GridDeduccion.Cell(0, Me.igyIdDeduccionDetalle).Text = "Id deduccion"
        Me.GridDeduccion.Cell(0, Me.igyPercepciones).Text = "Percepciones"
        Me.GridDeduccion.Cell(0, Me.igySindicato).Text = "Sindicato"
        Me.GridDeduccion.Cell(0, Me.igyDescuento).Text = "Descuento"
        Me.GridDeduccion.Cell(0, Me.igyAbonar).Text = "Abonar"

        Me.GridDeduccion.Column(Me.igyPercepciones).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        Me.GridDeduccion.Column(Me.igyPercepciones).Mask = FlexCell.MaskEnum.Numeric
        Me.GridDeduccion.Column(Me.igyPercepciones).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
        Me.GridDeduccion.Column(Me.igyPercepciones).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.GridDeduccion.Column(Me.igySindicato).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        Me.GridDeduccion.Column(Me.igySindicato).Mask = FlexCell.MaskEnum.Numeric
        Me.GridDeduccion.Column(Me.igySindicato).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
        Me.GridDeduccion.Column(Me.igySindicato).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.GridDeduccion.Column(Me.igyDescuento).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        Me.GridDeduccion.Column(Me.igyDescuento).Mask = FlexCell.MaskEnum.Numeric
        Me.GridDeduccion.Column(Me.igyDescuento).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
        Me.GridDeduccion.Column(Me.igyDescuento).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.GridDeduccion.Column(Me.igyAbonar).CellType = FlexCell.CellTypeEnum.CheckBox

        Me.GridDeduccion.Column(Me.igyCodigo).Locked = True
        Me.GridDeduccion.Column(Me.igyNombreCompleto).Locked = True
        Me.GridDeduccion.Column(Me.igyNumeroSemana).Locked = True
        Me.GridDeduccion.Column(Me.igyFechaDeduccion).Locked = True
        Me.GridDeduccion.Column(Me.igyIdDeduccionDetalle).Locked = True
        Me.GridDeduccion.Column(Me.igyPercepciones).Locked = True
        Me.GridDeduccion.Column(Me.igySindicato).Locked = True
        Me.GridDeduccion.Column(Me.igyDescuento).Locked = True
        Me.GridDeduccion.Column(Me.igyAbonar).Locked = True
        Me.GridDeduccion.Column(Me.igyIdDeduccionDetalle).Visible = False
    End Sub

    Private Sub FormateaGridDispersion()
        Try
            With Me.GridDispersion
                .AutoRedraw = False

                .Column(Me.igyDispersionCodigo).Width = 60
                .Column(Me.igyDispersionNombreCompleto).Width = 180
                .Column(Me.igyDispersionNumeroTarjera).Width = 110
                .Column(Me.igyDispersionImporte).Width = 100
                .Column(Me.igyDispersionRechazado).Width = 70
                .Column(Me.igyDispersionPagoRealizado).Width = 70

                .Cell(0, Me.igyDispersionCodigo).Text = "Código"
                .Cell(0, Me.igyDispersionNombreCompleto).Text = "Nombre"
                .Cell(0, Me.igyDispersionNumeroTarjera).Text = "Tarjeta"
                .Cell(0, Me.igyDispersionImporte).Text = "Importe"
                .Cell(0, Me.igyDispersionRechazado).Text = "Rechazados"
                .Cell(0, Me.igyDispersionPagoRealizado).Text = "Pagado"

                .Column(Me.igyDispersionRechazado).CellType = FlexCell.CellTypeEnum.CheckBox

                .Column(Me.igyDispersionImporte).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
                .Column(Me.igyDispersionImporte).Mask = FlexCell.MaskEnum.Numeric
                .Column(Me.igyDispersionImporte).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
                .Column(Me.igyDispersionImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

                .Column(Me.igyDispersionCodigo).Locked = True
                .Column(Me.igyDispersionNombreCompleto).Locked = True
                .Column(Me.igyDispersionNumeroTarjera).Locked = True
                .Column(Me.igyDispersionImporte).Locked = True
                .Column(Me.igyDispersionRechazado).Locked = False
                .Column(Me.igyDispersionPagoRealizado).Locked = True
                .Column(Me.igyDispersionPagoRealizado).Visible = False

                Dim i As Integer
                For i = 1 To .Rows - 1
                    If .Cell(i, Me.igyDispersionPagoRealizado).Text = "1" Then
                        .Row(i).Locked = True
                        Me.btnIntegrar.Enabled = False
                        Me.CkbMarcarTodo.Enabled = False
                        Me.lblConfimado.Text = "Dispersión confirmada"
                    Else
                        .Row(i).Locked = False
                        Me.btnIntegrar.Enabled = True
                        Me.CkbMarcarTodo.Enabled = True
                        Me.lblConfimado.Text = "Dispersión sin confirmar"
                    End If
                Next i

                .AutoRedraw = True
                .Refresh()
            End With

        Catch ex As Exception
            HandleError(Me.Name, "FormateaGridDispersion", ex)
        End Try
    End Sub

    Private Sub DesplegarArchivos()
        Try
            Dim oNominaSemana As New Class_NominaSemana
            oNominaSemana.ID_NOMINA_SEMANA = Me._ID_NOMINA_SEMANA

            Me.InicializaGridDispersion()
            Me.cboTxtArchivos.Refresh()
            Me.cboTxtArchivos.DataSource = Nothing
            With Me.cboTxtArchivos
                .DisplayMember = "NOMBRE_TXT"
                .ValueMember = "NOMBRE_TXT"
                Dim dView As New Data.DataView(oNominaSemana.ObtenerTxtDispersiones())
                dView.Sort = "NOMBRE_TXT"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedIndex = 0
                End If
            End With

        Catch ex As Exception
            HandleError(Me.Name, "DesplegarArchivos", ex)
        End Try
    End Sub

    Private Function Consultar() As Boolean
        Dim bResultado As Boolean = False
        Dim dTable As DataTable
        'Dim dTable2 As DataTable

        Try
            oNominaSemana = New Class_NominaSemana(Me._ID_NOMINA_SEMANA)

            dTable = oNominaSemana.ObtieneDetalleSemana
            Me.GridDeduccion.Rows = 1
            For Each dRow As DataRow In dTable.Rows
                Me.GridDeduccion.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & Chr(9) & dRow(2).ToString & Chr(9) & _
                                           Format(CDate(dRow(3).ToString), "dd-MMM-yy").ToString & Chr(9) & dRow(4).ToString & Chr(9) & _
                                           dRow(5).ToString & Chr(9) & dRow(6).ToString & Chr(9) & dRow(7).ToString & Chr(9) & dRow(8).ToString & Chr(9))
            Next
            dTable.Dispose()
            Me.Totales()

            Me.FormateaGrid()

            bResultado = True

            'If txtLEN(Me.cboTxtArchivos.Text) = True Then
            '    dTable2 = oNominaSemana.GeneraNominaDispercion(Me._ACCION, Me.cboTxtArchivos.Text)
            '    Me.GridDispersion.Rows = 1
            '    For Each dRow As DataRow In dTable2.Rows
            '        Me.GridDispersion.AddItem(dRow(0).ToString & Chr(9) & dRow(2).ToString & " " & dRow(3).ToString & " " & dRow(1).ToString & Chr(9) & _
            '                                 dRow(4).ToString & Chr(9) & dRow(5).ToString & Chr(9) & "0" & Chr(9) & dRow(6).ToString & Chr(9))
            '    Next
            '    dTable2.AcceptChanges()
            '    dTable2.Dispose()
            'End If
            'Me.FormateaGridDispersion()

        Catch ex As Exception
            HandleError(Me.Name, "Consultar", ex)
        End Try
        Return bResultado
    End Function

    Private Function GenerarNominaSemana() As Boolean
        Dim bResultado As Boolean = False
        Try
            If Me.Validar = False Then
                Exit Function
            End If

            Dim i As Integer
            For i = 1 To Me.GridDeduccion.Rows - 1
                If txtLEN(Me.GridDeduccion.Cell(i, Me.igyCodigo).Text) = True And Me.GridDeduccion.Cell(i, Me.igyAbonar).Text = "1" Then
                    Me.oNominaSemana.ID_NOMINA_SEMANA = Me._ID_NOMINA_SEMANA
                    If Me.oNominaSemana.AbonaDescuentosSemana(CInt(Me.GridDeduccion.Cell(i, Me.igyIdDeduccionDetalle).Text)) = False Then
                        Exit Function
                    End If
                End If
            Next i

            If Me.oNominaSemana.GeneraNomina = False Then
                Exit Function
            Else
                Dim oSQL As New Class_find("SELECT NOMINA_NUMERO_SEMANA_ACTUAL FROM SIS_EMPRESA_NOMINA WHERE CODIGO_PLAZA=" & Plaza.CODIGO_PLAZA)
                Plaza.oSisPlazaNomina.NOMINA_NUMERO_SEMANA_ACTUAL = CInt(oSQL.Result1)
                oSQL = Nothing
            End If

            bResultado = True
            MsgBox("Nomina generada satisfactoriamente.", MsgBoxStyle.Information, Me.Name)
            Me.btnConfirmar.Enabled = False
            Me.lblConfimado.Text = "Dispersión confirmada"

        Catch ex As Exception
            HandleError(Me.Name, "GenerarNominaSemana", ex)
        End Try
        Return bResultado
    End Function

    Private Sub Totales()
        Dim i As Integer
        Me.txtTotal.Text = "0"
        Me.txtAceptados.Text = "0"
        Me.txtRechazados.Text = "0"
        Me.txtTotalTrabajadores.Text = "0"

        For i = 1 To Me.GridDeduccion.Rows - 1
            If Me.GridDeduccion.Cell(i, Me.igyAbonar).Text = "1" Then
                Me.txtTotal.Text = FormatImporteContable(valorNumerico(Me.txtTotal.Text) + valorNumerico(Me.GridDeduccion.Cell(i, Me.igyDescuento).Text), True)
            End If
        Next i

        For i = 1 To Me.GridDispersion.Rows - 1
            If Me.GridDispersion.Cell(i, Me.igyDispersionRechazado).Text = "0" Or Me.GridDispersion.Cell(i, Me.igyDispersionRechazado).Text = "" Then
                Me.txtAceptados.Text = (valorNumerico(Me.txtAceptados.Text) + 1).ToString
                Me.GridDispersion.Cell(i, Me.igyDispersionRechazado).Text = "0"
            Else
                Me.txtRechazados.Text = (valorNumerico(Me.txtRechazados.Text) + 1).ToString
            End If
        Next

        Me.txtTotalDispersion.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.GridDispersion, Me.igyDispersionImporte), Empresa_Sistema.DECIMALES_CONTABILIDAD))
        Me.txtTotalTrabajadores.Text = (Me.GridDispersion.Rows - 1).ToString
        'Me.txtTotalImporte.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.GridSemanaTrabajadores, Me.igyPercepciones), Empresa_Sistema.DECIMALES_CONTABILIDAD))
        'Me.txtTotalJornales.Text = FG_Grid_SumaCol(Me.GridSemanaTrabajadores, Me.igyCodigoTrabajador).ToString
    End Sub

    Private Function Validar() As Boolean
        Dim i As Integer
        For i = 1 To Me.GridDeduccion.Rows - 1
            If Me.GridDeduccion.Cell(i, Me.igyAbonar).Text = "0" Then
                MsgBox("No todos los abonos pueden ser pagados. ", MsgBoxStyle.Exclamation, Me.Text)
                'Validar = False
                Exit Function
            End If
        Next i
        Validar = True
    End Function

    Private Function ConfirmarDispersion() As Boolean
        Dim i As Integer
        Dim oNominaSemana As New Class_NominaSemana(Me._ID_NOMINA_SEMANA)

        If MsgBox("Deseas confirmar la dispersión del archivo " & Me.cboTxtArchivos.Text & " ?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Dispersión") = MsgBoxResult.No Then
            Exit Function
        End If
        Try
            For i = 1 To Me.GridDispersion.Rows - 1
                If txtLEN(Me.GridDispersion.Cell(i, Me.igyDispersionCodigo).Text) = True Then
                    If Me.GridDispersion.Cell(i, Me.igyDispersionRechazado).Text <> "1" Then
                        If oNominaSemana.ConfirmaRechazaNominaDispercion(Me.GridDispersion.Cell(i, Me.igyDispersionCodigo).Text, Me.cboTxtArchivos.Text, True) = False Then
                            MsgBox("No se pudo aplicar la dispersión del archivo. ", MsgBoxStyle.Exclamation, Me.Text)
                            Exit Function
                        End If
                    Else
                        If oNominaSemana.ConfirmaRechazaNominaDispercion(Me.GridDispersion.Cell(i, Me.igyDispersionCodigo).Text, Me.cboTxtArchivos.Text, False) = False Then
                            MsgBox("No se pudo desaplicar la dispersión del archivo. ", MsgBoxStyle.Exclamation, Me.Text)
                            Exit Function
                        End If
                    End If
                End If
            Next

            ConfirmarDispersion = True
            MsgBox("Se aplicó el archivo correctamente. ", MsgBoxStyle.Information, Me.Text)

            Me.ConsultarArchivo()

        Catch ex As Exception
            HandleError(Me.Name, "ConfirmarDispersion", ex)
        End Try
    End Function

    Private Function ConsultarArchivo() As Boolean
        Dim bResultado As Boolean = False
        Dim dTable As DataTable
        Try
            oNominaSemana = New Class_NominaSemana(Me._ID_NOMINA_SEMANA)

            Me.InicializaGridDispersion()

            Me.GridDispersion.AutoRedraw = False

            dTable = oNominaSemana.GeneraNominaDispercion("LISTAR_DISPERSION", Me.cboTxtArchivos.Text)
            Me.GridDispersion.Rows = 1
            For Each dRow As DataRow In dTable.Rows
                Me.GridDispersion.AddItem(dRow(0).ToString & Chr(9) & dRow(1).ToString & " " & dRow(2).ToString & " " & dRow(3).ToString & Chr(9) & _
                                         dRow(4).ToString & Chr(9) & dRow(5).ToString & Chr(9) & "0" & Chr(9) & String.Format("{0,1}", dRow(6).ToString) & Chr(9))
            Next

            dTable.Dispose()
            Me.FormateaGridDispersion()

            Me.GridDispersion.AutoRedraw = True
            Me.GridDispersion.Refresh()

            Me.Totales()
            bResultado = True

        Catch ex As Exception
            HandleError(Me.Name, "ConsultarArchivo", ex)
        End Try
        Return bResultado
    End Function

    Private Function GeneraDispersion(Optional ByVal bConfirmacion As Boolean = True) As Boolean
        Dim bResultado As Boolean = False, sProcedure As String = "GeneraDispersion"
        Dim dTabla As DataTable
        Dim sRenglon As String = Nothing
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim PathArchivo As String = "", sCarpeta As String = ""
        Dim sTotalRegistros As String
        Dim sTotalImporte As String = ""
        Dim bResitroGlobal As Boolean = False
        Dim iFolio As Integer
        Dim iRango1 As Integer = 0, iRango2 As Integer = 0
        Dim iTotalTrabajadores As Integer = 0 'Total de trabajadores con tarjetas de la semana para poder dividirlo entre el rango, para hacer los archivos
        Dim oSemana As  New Class_NominaSemana(Me._ID_NOMINA_SEMANA)

        Try
            If Directory.Exists(Plaza.oSisPlazaNomina.RUTA_ALTAS_DISPERSIONES & "SEM" & oSemana.NUMERO_SEMANA.ToString) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(Plaza.oSisPlazaNomina.RUTA_ALTAS_DISPERSIONES & "SEM" & oSemana.NUMERO_SEMANA.ToString)
                'Else
                '    'Elimina todos los txt que empiezan con la palabra Dispersion_
                '    For Each fichero As String In Directory.GetFiles(Plaza.oSisPlazaNomina.RUTA_ALTAS_DISPERSIONES & "SEM" & oSemana.NUMERO_SEMANA.ToString, "Dispersion_*.txt")
                '        File.Delete(fichero)
                '    Next
            End If

            If txtLEN(Me.TxtRango.Text) = False Then
                MsgBox("No ha definido el rango de trajadores.", MsgBoxStyle.Exclamation, sProcedure)
                Exit Function
            End If

            Me._RANGO = CInt(Me.TxtRango.Text)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dTabla = oSemana.GeneraNominaDispercion("GENERAR_DISPERSION", "x", CInt(Me.txtConsecutivo.Text), CInt(Me.TxtRango.Text))

            If dTabla.Rows.Count = 0 Then
                MsgBox("No se encontraron trabajadores con pago con tarjeta.", MsgBoxStyle.Exclamation, sProcedure)
                Exit Function
            End If

            'Recorrer tabla agrupando por nombre_archivo
            Dim qArchivos = dTabla.AsEnumerable()

            'Este era una especie de group sencillo, pero me faltaba el numero de archivo, que bien podia tomarse con la terminación del nombre del archivo con un right, Dispersion_18SEP15_1
            'Dim tArchivos = (From c In qArchivos _
            '            Select c!NOMBRE_ARCHIVO).Distinct()

            Dim tArchivos = From a In qArchivos
                                       Order By a!NOMBRE_ARCHIVO, a!NUMERO_ARCHIVO
                                       Group By NOMBRE_ARCHIVO = a!NOMBRE_ARCHIVO, NUMERO_ARCHIVO = a!NUMERO_ARCHIVO, CODIGO_PUNTO_PAGO_NOMINA_GENERADA = a!CODIGO_PUNTO_PAGO_NOMINA_GENERADA, NOMBRE_PUNTO_PAGO = a!NOMBRE_PUNTO_PAGO,
                                       NUMERO_TRABAJADORES = a!NUMERO_TRABAJADORES, TOTAL_DEPOSITADO = a!TOTAL_DEPOSITADO
            Into xGrupo = Group, Count()
            Order By NUMERO_ARCHIVO
            'Into xGrupo = Group, Count() 'No se para que es esto

            'ObjectDumper.Write(tArchivos)'Se imprime en la ventana de output
            'For Each x In tArchivos
            '    MsgBox(x.NUMERO_ARCHIVO.ToString & "-" & x.NOMBRE_ARCHIVO.ToString)
            'Next

            'For Each sArchivo As String In tArchivos
            For Each x In tArchivos
                Me.sNombreTxt = x.NOMBRE_ARCHIVO.ToString
                iFolio = CInt(x.NUMERO_ARCHIVO.ToString)

                Me.sNombreTxt = "NI00136" & Microsoft.VisualBasic.Right("0" & iFolio.ToString, 2) & ".pag"

                sCarpeta = Plaza.oSisPlazaNomina.RUTA_ALTAS_DISPERSIONES & "SEM" & oSemana.NUMERO_SEMANA.ToString & "\" & x.CODIGO_PUNTO_PAGO_NOMINA_GENERADA.ToString & "-" & x.NOMBRE_PUNTO_PAGO.ToString

                PathArchivo = sCarpeta & "\" & sNombreTxt

                If Directory.Exists(sCarpeta) = False Then ' si no existe la carpeta se crea
                    Directory.CreateDirectory(sCarpeta)
                End If

                If isExisteArchivo(PathArchivo) = True Then
                    File.Delete(PathArchivo)
                    strStreamW = File.Create(PathArchivo)
                Else
                    strStreamW = File.Create(PathArchivo)
                End If

                strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'sTotalRegistros = String.Format("{0,6}", dTabla.Rows.Count.ToString)
                sTotalRegistros = String.Format("{0,6}", x.NUMERO_TRABAJADORES.ToString)
                sTotalRegistros = sTotalRegistros.Replace(" ", "0")

                'sTotalImporte = dTabla.Rows(0)("TOTAL_DEPOSITADO").ToString.Replace(".", "").ToString
                sTotalImporte = x.TOTAL_DEPOSITADO.ToString.Replace(".", "").ToString
                sTotalImporte = String.Format("{0,15}", sTotalImporte).Replace(" ", "0").ToString()

                'Dim sFecha As String = String.Format("{0,6}", Format(Now(), "yyyyMMdd"))
                Dim sFecha As String = String.Format("{0,6}", Format(Me.dtFechaDispersion.Value, "yyyyMMdd"))

                'REGISTRO DE CONTROL
                strStreamWriter.WriteLine(String.Format("{0,-165}", _
                                                        "H" & "NE" & "00136" & sFecha & _
                                                        String.Format("{0,2}", iFolio).Replace(" ", "0").ToString & sTotalRegistros & sTotalImporte & _
                                                        String.Format("{0,6}", "").Replace(" ", "0").ToString & String.Format("{0,15}", "").Replace(" ", "0").ToString & _
                                                        String.Format("{0,6}", "").Replace(" ", "0").ToString & String.Format("{0,15}", "").Replace(" ", "0").ToString & _
                                                        String.Format("{0,6}", "").Replace(" ", "0").ToString & _
                                                        "0" & _
                                                        String.Format("{0,77}", "").Replace(" ", "0").ToString))

                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'REGISTRO DETALLE
                'For Each drow As DataRow In dTabla.Rows
                For Each dRow As DataRow In dTabla.Select("NOMBRE_ARCHIVO='" & Me.sNombreTxt & "'")
                    Dim kt1 As String = String.Format("{0,1}", "D")  'Tipo de registro
                    Dim kt2 As String = sFecha  'Fecha
                    Dim kt3 As String = String.Format("{0,10}", dRow("NUMERO_TRABAJADOR_BANCO").ToString).Replace(" ", "0")  'Numero empleado
                    Dim kt4 As String = String.Format("{0,40}", "")  'Referencia servicio
                    Dim kt5 As String = String.Format("{0,40}", "")  'Referencia Leyenda del Ordenante
                    Dim kt6 As String = String.Format("{0,15}", dRow("SUELDO").ToString.Replace(".", "").ToString).Replace(" ", "0").ToString 'Importe
                    Dim kt7 As String = "072" 'Número de Banco Receptor
                    Dim kt8 As String = "01" 'Tipo de Cuenta
                    Dim kt9 As String = String.Format("{0,18}", dRow("NUMERO_CUENTA_BANCO").ToString).Replace(" ", "0").ToString  'Cuenta a la que se aplicará el Cargo ó Abono
                    Dim kt10 As String = "0" 'Tipo de Movimiento
                    Dim kt11 As String = " " 'Acción
                    Dim kt12 As String = String.Format("{0,8}", "").Replace(" ", "0").ToString 'Importe IVA de la Operación
                    Dim kt13 As String = String.Format("{0,18}", "") 'Filler

                    strStreamWriter.WriteLine(kt1.ToString & kt2.ToString & kt3.ToString & kt4.ToString & kt5.ToString & kt6.ToString & kt7.ToString & kt8.ToString & kt9.ToString & kt10.ToString & kt11.ToString & kt12.ToString & kt13.ToString)
                    'escribimos en el archivo
                Next

                strStreamWriter.Close() 'Cerramos
                bResultado = True

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''Codigo anterior !!!!!!!! antes 02feb16

            'iTotalTrabajadores = oSemana.ObtenerTotalTrabajadoresTarjeta()

            ''Dim x As Double = 0
            'Dim iTotalesArchivos As Integer = 0
            'Dim k As Integer = 0

            ''x = iTotalTrabajadores / Me._RANGO
            'iTotalesArchivos = CInt(-Int(-(iTotalTrabajadores / Me._RANGO)))

            'For k = 0 To iTotalesArchivos - 1
            '    'Me.sNombreTxt = "Dispersion_" & Format(Now(), "ddMMMyyyy") & "_"
            '    iRango1 = iRango2
            '    iRango2 = iRango2 + Me._RANGO
            '    bResitroGlobal = False

            '    'procedimiento para imprimnir
            '    If Me.txtConsecutivo.Text = oSemana.ULTIMO_NUMERO_TXT_DISPERSION.ToString Then
            '        iFolio = CInt(oSemana.ULTIMO_NUMERO_TXT_DISPERSION)
            '        iFolio = iFolio + k
            '    Else
            '        If CInt(Me.txtConsecutivo.Text) <= 0 Then
            '            MsgBox("El consecutivo del archivo debe ser mayor a 0.", MsgBoxStyle.Exclamation, "GeneraArchivoDispercion")
            '            Exit Function
            '        End If
            '        iFolio = CInt(Me.txtConsecutivo.Text)
            '        iFolio = iFolio + k
            '        'Ahi que actualizar el consecutivo de la semana
            '        oSemana.ULTIMO_NUMERO_TXT_DISPERSION = Me.txtConsecutivo.Text
            '        If oSemana.ActualizaUltimoNumeroTxtDispercionSemana() = False Then
            '            Exit Function
            '        End If
            '    End If

            '    'NI0013601.pag Modelo, donde el 01 es consecutivo a dos digitos

            '    Me.sNombreTxt = "NI00136" & Microsoft.VisualBasic.Right("0" & iFolio.ToString, 2) & ".pag"

            '    PathArchivo = Plaza.oSisPlazaNomina.RUTA_ALTAS_DISPERSIONES & "SEM" & oSemana.NUMERO_SEMANA.ToString & "\" & sNombreTxt

            '    If isExisteArchivo(PathArchivo) = True Then
            '        'If bConfirmacion = True Then
            '        'If MsgBox("El archivo correspondiente ya existe, desea sobreescribirlo?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "GeneraArchivoDispercion") = MsgBoxResult.No Then
            '        '    MsgBox("No se generó el archivo.", MsgBoxStyle.Exclamation, "GeneraArchivoDispercion")
            '        '    Exit Function
            '        'Else
            '        'trStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            '        'End If
            '        'Else
            '        File.Delete(PathArchivo)
            '        strStreamW = File.Create(PathArchivo)
            '        'Se cambio porque agregaba al final del archivo
            '        'strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            '        'End If
            '    Else
            '        strStreamW = File.Create(PathArchivo)
            '    End If

            '    strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            '    dTabla = oSemana.GeneraNominaDispercion("GENERAR_DISPERSION", sNombreTxt, iRango1, iRango2)

            '    If dTabla.Rows.Count < 1 Then
            '        MsgBox("No se encontraron trabajadores con pago con tarjeta.", MsgBoxStyle.Exclamation, "ImprimirDispersion")
            '        strStreamWriter.Close()
            '        File.Delete(PathArchivo)
            '        Exit Function
            '    End If

            '    'Global
            '    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '    sTotalRegistros = String.Format("{0,6}", dTabla.Rows.Count.ToString)
            '    sTotalRegistros = sTotalRegistros.Replace(" ", "0")

            '    sTotalImporte = dTabla.Rows(0)(6).ToString.Replace(".", "").ToString
            '    sTotalImporte = String.Format("{0,15}", sTotalImporte).Replace(" ", "0").ToString()

            '    Dim sFecha As String = String.Format("{0,6}", Format(Now(), "yyyyMMdd"))

            '    'REGISTRO DE CONTROL
            '    strStreamWriter.WriteLine(String.Format("{0,-165}", _
            '                                            "H" & "NE" & "00136" & sFecha & _
            '                                            String.Format("{0,2}", iFolio).Replace(" ", "0").ToString & sTotalRegistros & sTotalImporte & _
            '                                            String.Format("{0,6}", "").Replace(" ", "0").ToString & String.Format("{0,15}", "").Replace(" ", "0").ToString & _
            '                                            String.Format("{0,6}", "").Replace(" ", "0").ToString & String.Format("{0,15}", "").Replace(" ", "0").ToString & _
            '                                            String.Format("{0,6}", "").Replace(" ", "0").ToString & _
            '                                            "0" & _
            '                                            String.Format("{0,77}", "").Replace(" ", "0").ToString))

            '    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '    'REGISTRO DETALLE
            '    For Each drow As DataRow In dTabla.Rows
            '        Dim kt1 As String = String.Format("{0,1}", "D")  'Tipo de registro
            '        Dim kt2 As String = sFecha  'Fecha
            '        Dim kt3 As String = String.Format("{0,10}", drow(9).ToString)  'Numero empleado
            '        Dim kt4 As String = String.Format("{0,40}", "")  'Referencia servicio
            '        Dim kt5 As String = String.Format("{0,40}", "")  'Referencia Leyenda del Ordenante
            '        Dim kt6 As String = String.Format("{0,15}", drow(5).ToString.Replace(".", "").ToString).Replace(" ", "0").ToString 'Importe
            '        Dim kt7 As String = "072" 'Número de Banco Receptor
            '        Dim kt8 As String = "01" 'Tipo de Cuenta
            '        Dim kt9 As String = String.Format("{0,18}", drow(10).ToString).Replace(" ", "0").ToString  'Cuenta a la que se aplicará el Cargo ó Abono
            '        Dim kt10 As String = "0" 'Tipo de Movimiento
            '        Dim kt11 As String = " " 'Acción
            '        Dim kt12 As String = String.Format("{0,8}", "").Replace(" ", "0").ToString 'Importe IVA de la Operación
            '        Dim kt13 As String = String.Format("{0,18}", "") 'Filler

            '        strStreamWriter.WriteLine(kt1.ToString & kt2.ToString & kt3.ToString & kt4.ToString & kt5.ToString & kt6.ToString & kt7.ToString & kt8.ToString & kt9.ToString & kt10.ToString & kt11.ToString & kt12.ToString & kt13.ToString)
            '        'escribimos en el archivo
            '    Next

            '    strStreamWriter.Close() 'Cerramos
            '    bResultado = True







            '    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '    sTotalRegistros = String.Format("{0,6}", dTabla.Rows.Count.ToString)
            '    sTotalRegistros = sTotalRegistros.Replace(" ", "0")
            '    'REGISTRO DE CONTROL
            '    strStreamWriter.WriteLine("1" & String.Format("{0,12}", Empresa_Sistema.NUMERO_CLIENTE_BANCO.ToString).Replace(" ", "0").ToString & String.Format("{0,06}", Format(Now(), "yyMMdd")) & _
            '                              String.Format("{0,4}", iFolio).Replace(" ", "0").ToString & _
            '                              String.Format("{0,-36}", Empresa_Sistema.Nombre_empresa) & String.Format("{0,-20}", "Descripcion") & String.Format("{0,2}", "15") & String.Format("{0,1}", "D") & String.Format("{0,2}", "01"))

            '    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '    'REGISTRO DETALLE
            '    For Each drow As DataRow In dTabla.Rows
            '        If bResitroGlobal = False Then
            '            'REGISTRO GLOBAL
            '            sTotalImporte = drow(6).ToString.Replace(".", "").ToString
            '            strStreamWriter.WriteLine("2" & "1" & "001" & String.Format("{0,18}", sTotalImporte).Replace(" ", "0").ToString & String.Format("{0,02}", "01") & _
            '                                      String.Format("{0,20}", (Empresa_Sistema.SUCURSAL_BANCO.ToString & Empresa_Sistema.NUMERO_CUENTA_BANCO.ToString)).Replace(" ", "0").ToString & _
            '                                      String.Format("{0,6}", drow(7).ToString).Replace(" ", "0").ToString)
            '            bResitroGlobal = True
            '        End If

            '        Dim kt1 As String = String.Format("{0,1}", "3")  'Tipo de registro
            '        Dim kt2 As String = String.Format("{0,1}", "0")  'Tipo de operacion
            '        Dim kt3 As String = String.Format("{0,3}", "001")  'Método de pago
            '        Dim Kt4 As String = String.Format("{0,2}", "01") 'Tipo de pago
            '        Dim kt5 As String = String.Format("{0,3}", "001") 'Clave de la moneda
            '        Dim kt6 As String = String.Format("{0,18}", drow(5).ToString.Replace(".", "").ToString).Replace(" ", "0").ToString 'Importe
            '        Dim kt7 As String = String.Format("{0,2}", "03") 'Tipo de cuenta de abono
            '        Dim kt8 As String = String.Format("{0,20}", drow(4).ToString).Replace(" ", "0").ToString 'Número de cuenta de abono
            '        Dim kt9 As String = String.Format("{0,-16}", "Pago Banamex") 'Referencia del pago
            '        'REGISTRO DETALLE - INTERBANCARIOS
            '        Dim kt10 As String = String.Format("{0,-55}", drow(3).ToString & "," & drow(1).ToString & "/" & drow(2).ToString)
            '        kt10 = kt10.Replace("Ñ", "@")                      'Nombre trabajador (Nombre,ApPaterno/ApMaterno)
            '        Dim kt11 As String = String.Format("{0,35}", "") 'Referencia1
            '        Dim kt12 As String = String.Format("{0,35}", "") 'Referencia2
            '        Dim kt13 As String = String.Format("{0,35}", "") 'Referencia3
            '        Dim kt14 As String = String.Format("{0,35}", "") 'Referencia4
            '        Dim kt15 As String = String.Format("{0,4}", "").Replace(" ", "0").ToString  'Clave del banco
            '        Dim kt16 As String = String.Format("{0,2}", "").Replace(" ", "0").ToString 'Plazo hrs
            '        Dim kt17 As String = String.Format("{0,14}", "") 'RFC
            '        Dim kt18 As String = String.Format("{0,8}", "") 'IVA
            '        Dim kt19 As String = String.Format("{0,80}", "") 'Para uso futuro
            '        Dim kt20 As String = String.Format("{0,50}", "") 'Para uso futuro

            '        sTotalRegistros = drow(7).ToString

            '        strStreamWriter.WriteLine(kt1.ToString & kt2.ToString & kt3.ToString & Kt4.ToString & kt5.ToString & kt6.ToString & kt7.ToString & _
            '                                  kt8.ToString & kt9.ToString & kt10.ToString & kt11.ToString & kt12.ToString & kt13.ToString & _
            '                                  kt14.ToString & kt15.ToString & kt16.ToString & kt17.ToString & kt18.ToString & kt19.ToString & kt20.ToString)
            '        'escribimos en el archivo
            '    Next
            '    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '    'REGISTRO DE CONTROL
            '    strStreamWriter.WriteLine("4" & "001" & String.Format("{0,6}", sTotalRegistros).Replace(" ", "0").ToString & String.Format("{0,18}", sTotalImporte.ToString).Replace(" ", "0").ToString & _
            '                              String.Format("{0,6}", 1).Replace(" ", "0").ToString & String.Format("{0,18}", sTotalImporte.ToString).Replace(" ", "0").ToString)

            '    strStreamWriter.Close() 'Cerramos
            '    ImprimirDispersion = True

            If bConfirmacion = True Then
                MsgBox("El archivo fue generado con éxito en la ruta: " & PathArchivo, MsgBoxStyle.Information, sProcedure)
            End If

        Catch ex As Exception
            HandleError(Me.Name, sProcedure, ex)
        Finally
            strStreamWriter.Dispose()
            strStreamW.Dispose()
        End Try

        Return bResultado
    End Function

    Public Function ValidarNominaDispersion() As Boolean
        Dim bResultado As Boolean = False
        Dim dTable As DataTable
        Dim oSemana As Class_NominaSemana
        oSemana = New Class_NominaSemana(Me._ID_NOMINA_SEMANA)
        dTable = oSemana.GeneraNominaDispercion("VALIDAR_DISPERSION", "")

        If dTable.Rows.Count > 0 Then
            MsgBox("Se encontraron trabajadores con datos incorrectos.", MsgBoxStyle.Exclamation, "ImprimirDispersion")

            Dim StrFiltros As String = ""
            Dim Rpt As New ReportDocument
            Dim oReporte As Class_Reporte
            Try
                oReporte = New Class_Reporte("RPT_NOMINA_GENERA_DISPERSION", Rpt)
                If Not oReporte.RptCargado Then
                    Exit Function
                End If
                Rpt.SetParameterValue("@ID_NOMINA_SEMANA", CInt(Me._ID_NOMINA_SEMANA))
                Rpt.SetParameterValue("@NOMBRE_TXT_DISPERSION", "")
                Rpt.SetParameterValue("@ACCION", "VALIDAR_DISPERSION")

                Dim frm As New Reporte(Rpt)
                frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                frm.Show()
                bResultado = False
            Catch ex As Exception
                HandleError(Me.Name, "Impresión de Trabajadores", ex)
            Finally
                oReporte = Nothing
            End Try
            Exit Function
        Else
            bResultado = True
        End If

        Return bResultado
    End Function

    Private Function ActualizaNumeroTxtDispersion() As Boolean

    End Function
#End Region

    Private Sub Frm_Nomina_Generada_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim sArchivo As String = ""
            If txtLEN(Me.cboTxtArchivos.Text) = True Then
                sArchivo = Me.cboTxtArchivos.Text
            End If

            Me.Inicializa()
            If Me._ACCION <> "LISTAR_DISPERSION" Then
                'Me.GeneraDispersion(False)
                Me.DesplegarArchivos()
                'Me.cboTxtArchivos.SelectedValue = sNombreTxt
                Me.cboTxtArchivos.Text = sNombreTxt
            End If
            Me.TxtRango.Text = Me._RANGO.ToString

            Me.consultar()
        Catch ex As Exception
            HandleError(Me.Name, "Frm_Nomina_Generada_Load", ex)
        End Try
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub btnConfirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmar.Click
        If MsgBox("Deseas generar la nómina de la semana : " & oNominaSemana.NUMERO_SEMANA.ToString & " ?", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Generar nómina") = MsgBoxResult.No Then
            Exit Sub
        End If

        If Me.GenerarNominaSemana() = False Then
            Exit Sub
            'MsgBox("La nómina de la semana se genero satisfactoriamente. ", MsgBoxStyle.Information, Me.Text)
        End If

        If Me.oNominaSemana.AplicaNominaDispercionSemana() = False Then
            MsgBox("La nómina no se aplico correctamente. ", MsgBoxStyle.Information, Me.Text)
        End If

        Me.Close()
    End Sub

    Private Sub txtNumerosEnterosKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRango.KeyPress, txtConsecutivo.KeyPress
        txtSoloNumerosEnteros(e)
        txtNoBeep(e)
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub

    Private Sub GridDispersion_CellChange(ByVal Sender As Object, ByVal e As FlexCell.Grid.CellChangeEventArgs) Handles GridDispersion.CellChange
        'se ejecuta despues del click
        If Me.GridDispersion.ActiveCell.Col = Me.igyDispersionRechazado Then
            Me.Totales()
        End If
    End Sub

    Private Sub GridDispersion_Click(ByVal Sender As Object, ByVal e As System.EventArgs) Handles GridDispersion.Click
        If Me.GridDispersion.ActiveCell.Col = Me.igyDispersionRechazado Then
            Me.Totales()
        End If
    End Sub

    Private Sub GridDispersion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GridDispersion.KeyPress
        If Me.GridDispersion.ActiveCell.Col = Me.igyDispersionRechazado Then
            'Me.GridIngracion.Cell(Me.GridIngracion.ActiveCell.Row, Me.igyIntegracionCodigoTrabajador).SetFocus()
            Me.Totales()
        End If
    End Sub

    Private Sub btnIntegrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIntegrar.Click
        If Me.ConfirmarDispersion() = True Then
            oNominaSemana = New Class_NominaSemana(Me._ID_NOMINA_SEMANA)
            oNominaSemana.AplicaNominaDispercionSemana()
        End If
    End Sub

    Private Sub btnRegresarIntegracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresarIntegracion.Click
        Me.Close()
    End Sub

    Private Sub cboTxtArchivos_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTxtArchivos.SelectedValueChanged
        If txtLEN(Me.cboTxtArchivos.Text) = False Then
            Exit Sub
        End If
        Me.ConsultarArchivo()
    End Sub

    Private Sub CkbMarcarTodo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CkbMarcarTodo.CheckedChanged
        Dim i As Integer, sMarcar As String = "0"

        If Me.CkbMarcarTodo.Checked = True Then
            sMarcar = "1"
        End If

        For i = 1 To Me.GridDispersion.Rows - 1
            If txtLEN(Me.GridDispersion.Cell(i, Me.igyDispersionRechazado).Text) = True Then
                Me.GridDispersion.Cell(i, Me.igyDispersionRechazado).Text = sMarcar
            Else
                Me.GridDispersion.Cell(i, Me.igyDispersionRechazado).Text = sMarcar
            End If
        Next i
        Me.Totales()
    End Sub

    Private Sub btnGenerarDispersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerarDispersion.Click
        If Me.ValidarNominaDispersion = True Then
            Me.Inicializa()

            If Me.GeneraDispersion() = True Then
                Me.DesplegarArchivos()
                'Me.cboTxtArchivos.Text = Me.sNombreTxt

                oNominaSemana = New Class_NominaSemana(Me._ID_NOMINA_SEMANA)
                Me.txtConsecutivo.Text = oNominaSemana.ULTIMO_NUMERO_TXT_DISPERSION
            End If
        End If
    End Sub

End Class