Option Strict On
Imports System.Math
Imports System.Data
Imports System.Data.SqlClient
Imports System.Threading
Imports CrystalDecisions.CrystalReports.Engine

Module Mod_Uti
    Public sFelectronicaArchivoCadenaOriginalLocal As String
    Public sFelectronicaArchivoCERLocal As String
    Public sFelectronicaArchivoKEYLocal As String
    Public sFelectronicaCarpetaXMLPDF As String
    Public sFelectronicaCarpetaXMLSinTimbrar As String
    Public sFelectronicaConvierteUTF8Local As String
    Public sFelectronicaConvierteUTF8Servidor As String
    Public sFelectronicaCarpetaXmlsTimbrados As String = "", sFelectronicaCarpetaXmlsAcusesCancelacion As String = "", sFelectronicaArchivoPFX As String = ""
    Public sFelectronicaCbbImagen As String
    Public bSistemaDirecto As Boolean

    Private Declare Function SQLDataSources Lib "ODBC32.DLL" (ByVal henv As Integer, _
    ByVal fDirection As Short, ByVal szDSN As String, ByVal cbDSNMax As Short, ByRef pcbDSN As Short, _
    ByVal szDescription As String, ByVal cbDescriptionMax As Short, ByRef pcbDescription As Short) As Short

    Private Declare Function SQLAllocEnv Lib "ODBC32.DLL" (ByRef env As Integer) As Short

    Private Declare Function SQLConfigDataSource Lib "ODBCCP32.DLL" (ByVal hwndParent As Integer, _
    ByVal ByValfRequest As Integer, ByVal lpszDriver As String, ByVal lpszAttributes As String) As Integer

    Const SQL_SUCCESS As Integer = 0
    Const SQL_FETCH_NEXT As Integer = 1
    Private Const ODBC_ADD_DSN As Short = 1 ' Add user data source 
    Private Const ODBC_CONFIG_DSN As Short = 2 ' Configure (edit) data source 
    Private Const ODBC_REMOVE_DSN As Short = 3 ' Remove data source 
    Private Const ODBC_ADD_SYS_DSN As Short = 4 'Add system data source 
    Private Const vbAPINull As Integer = 0 ' NULL Pointer 

    'Public sFelectronicaArchivoCadenaOriginalLocal As String = "c:\Agrinet\FELECTRONICA\cadenaorginal.xsl"
    'Public sFelectronicaArchivoCERLocal As String = "C:\Agrinet\FELECTRONICA\AGRINET_LAND\Certificados digitales\00001000000102404915.cer"
    'Public sFelectronicaArchivoKEYLocal As String = "C:\Agrinet\FELECTRONICA\AGRINET_LAND\Certificados digitales\lpr070917rt9_1012151637s.key"
    'Public sFelectronicaCarpetaCertificadosDBXMLs As String = "C:\Agrocontrol\FELECTRONICA\AGRINET_LAND\Xmls_Pdfs"
    'Public sFelectronicaCarpetaPDFs As String
    'Public sFelectronicaConvierteUTF8Local As String = "c:\Agrinet\ConvierteArchivoUTF8.exe"
    'Public sFelectronicaConvierteUTF8Servidor As String

    Public sCongif1 As String = Decrypt("¬›»º—¸¹¨»º Š›„", "iK4"), sCongif2 As String = Decrypt("™‡Š¬¯Å„¾", "x4n")

    ''''''''''Configuración regional
    Private Declare Function GetSystemDefaultLCID Lib "kernel32" () As Integer
    Private Declare Function GetLocaleInfo Lib "kernel32" Alias "GetLocaleInfoA" (ByVal Locale As Integer, ByVal LCType As Integer, ByVal lpLCData As String, ByVal cchData As Integer) As Integer

    Public Const LOCALE_SCURRENCY As Long = &H14    'local monetary symbol
    Public Const LOCALE_SDATE As Long = &H1D    'date separator
    Public Const LOCALE_SDECIMAL As Long = &HE     'decimal separator
    Public Const LOCALE_STHOUSAND As Long = &HF     'thousand separator
    Public Const LOCALE_ICURRDIGITS As Long = &H19    '# local monetary digits
    Public Const LOCALE_SSHORTDATE As Long = &H1F    'short date format string
    Public Const LOCALE_STIMEFORMAT As Long = &H1003  'time format string
    ''''''''''

    'Copia archivos con interfaz de copiado de windows.
    ' Estructura SHFILEOPSTRUCT o para usar con el Api
    Private Structure SHFILEOPSTRUCT
        Dim hWnd As Integer
        Dim wFunc As Integer
        Dim pFrom As String
        Dim pTo As String
        Dim fFlags As Short
        Dim fAnyOperationsAborted As Boolean
        Dim hNameMappings As Integer
        Dim lpszProgressTitle As String
    End Structure

    Public Structure Tipo2
        Dim uno As String
        Dim dos As String
    End Structure

    Public Structure FacturaElectronica
        Dim NumeroCertificadoDigital As String
        Dim IdCfdCertificado As Integer
        Dim CadenaOriginal As String
        Dim SelloDigital As String
    End Structure

    Public Function Caracteres_Repetidos(ByVal sCadena As String, ByVal sLetra As Char) As Integer
        Dim i As Integer, iRepetidos As Integer = 0
        For i = 1 To sCadena.Length
            If Mid(sCadena, i, 1) = sLetra Then
                iRepetidos += 1
            End If
        Next
        Return iRepetidos
    End Function

    Function txtNoBeep(ByRef e As System.Windows.Forms.KeyPressEventArgs) As Boolean
        If e.KeyChar = Chr(CInt("13")) Or e.KeyChar = Chr(CInt("27")) Then
            e.Handled = True
            Return e.Handled
        End If
    End Function

    Function txtNoComilla(ByRef e As System.Windows.Forms.KeyPressEventArgs) As Boolean
        If e.KeyChar = ("'") Then
            e.Handled = True
            Return e.Handled
        End If
    End Function

    Function txtSoloNumerosDecimales(ByRef e As System.Windows.Forms.KeyPressEventArgs, ByVal sText As String) As Boolean
        If (Not (System.Char.IsDigit(e.KeyChar)) AndAlso Not (System.Char.IsControl(e.KeyChar)) AndAlso e.KeyChar <> ".") Then
            e.Handled = True
        End If
        If e.KeyChar = "." AndAlso CBool(InStr(sText, ".")) Then
            e.Handled = True
        End If
        Return e.Handled
    End Function

    Public Sub txtSoloNumerosEnteros(ByRef e As System.Windows.Forms.KeyPressEventArgs)
        If (Not (System.Char.IsDigit(e.KeyChar)) AndAlso Not (System.Char.IsControl(e.KeyChar))) Then
            e.Handled = True
        End If
    End Sub

    Function Decrypt(ByVal strText As String, ByVal strPwd As String) As String
        'Decrypt text encrypted with EncryptText
        Dim i As Integer, c As Integer
        Dim strBuff As String = ""

        strPwd = UCase$(strPwd)
        'Decrypt string
        If Len(strPwd) > 0 Then
            For i = 1 To Len(strText)
                c = Asc(Mid$(strText, i, 1))
                c = c - Asc(Mid$(strPwd, (i Mod Len(strPwd)) + 1, 1))
                strBuff = strBuff & Chr(c And &HFF)
            Next i
        Else
            strBuff = strText
        End If
        Decrypt = strBuff
    End Function

    Function Encrypt(ByVal strText As String, ByVal strPwd As String) As String
        Dim i As Integer, c As Integer
        Dim strBuff As String = ""
        strPwd = UCase$(strPwd)

        'Encrypt string
        If Len(strPwd) > 0 Then
            For i = 1 To Len(strText)
                c = Asc(Mid$(strText, i, 1))
                c = c + Asc(Mid$(strPwd, (i Mod Len(strPwd)) + 1, 1))
                strBuff = strBuff & Chr(c And &HFF)
            Next i
        Else
            strBuff = strText
        End If
        Encrypt = strBuff
    End Function

    Public Function Crea_DSN() As Boolean
        Dim ReturnValue As Integer
        Dim Driver As String
        Dim Attributes As String

        DSNBaseOperativa = Replace(Left((My.Settings.Servidor & My.Settings.BaseDatos & Application.ProductName), 32), "\", "") 'El nombre tiene como maximo 32 caracteres.

        'Set the driver to SQL Server because it is most common. 
        Driver = "SQL Server"
        'Set the attributes delimited by null. 
        'See driver documentation for a complete 
        'list of supported attributes. 
        Attributes = "SERVER=" & My.Settings.Servidor & Chr(0)
        Attributes = Attributes & "DESCRIPTION=Temp DSN" & Chr(0)
        Attributes = Attributes & "DSN=" & DSNBaseOperativa & Chr(0)
        Attributes = Attributes & "DATABASE=" & My.Settings.BaseDatos & Chr(0)
        'To show dialog, use Form1.Hwnd instead of vbAPINull. 
        ReturnValue = SQLConfigDataSource(vbAPINull, ODBC_ADD_DSN, Driver, Attributes)
        If ReturnValue <> 0 Then
            Crea_DSN = True
        End If
    End Function

    'Public Function Elimina_DSN() As Boolean
    '    Dim intRet As Long
    '    Dim strAttributes As String
    '    On Error Resume Next
    '    'Asignamos los parametros separados por null.
    '    strAttributes = "DSN=" & My.Settings.Servidor & My.Settings.Servidor_hamachi & sRandom & Chr(0)

    '    'Para mostrar el diálogo usar Form1.Hwnd en vez de vbAPINull.
    '    intRet = SQLConfigDataSource(vbAPINull, ODBC_REMOVE_DSN, "SQL Server", strAttributes)
    '    If CBool(intRet) Then
    '        Elimina_DSN = True
    '    Else
    '        Elimina_DSN = False
    '    End If
    'End Function

    Public Function Redondea_Total(ByVal Cantidad As Double) As Double
        'Cantidad = Redondear(Cantidad, 2)

        Cantidad = Redondear(Cantidad, 2)

        Dim sCantidad As String = CStr(Cantidad)
        Dim sParteDecimal As String = "", dParteDecimal As Double
        Dim Letra As Char, Flag As Boolean = False
        Dim iDividendo As Byte

        Dim i As Integer
        For i = 1 To Len(sCantidad)
            Letra = CChar(Right(sCantidad, 1))
            If Not Flag Then
                If Letra = "." Then
                    Flag = True
                Else
                    sParteDecimal = Letra & sParteDecimal
                End If
                sCantidad = Left(sCantidad, Len(sCantidad) - 1)
            End If
        Next

        If sParteDecimal.Length > 1 Then
            dParteDecimal = Val("0." & sParteDecimal)
            If dParteDecimal > 0.0 Then
                iDividendo = CByte(Int(Right(CStr(dParteDecimal), 1)))
                If iDividendo <> 0 And iDividendo <> 5 Then
                    Select Case iDividendo
                        Case 1, 2
                            If sParteDecimal.Length = 1 Then
                                Cantidad = 0
                                'Cantidad = Cantidad - Val(("0." & CStr(iDividendo)))
                            Else
                                Cantidad = Cantidad - Val(("0.0" & CStr(iDividendo)))
                            End If
                        Case 3, 4
                            If sParteDecimal.Length = 1 Then
                                Cantidad = 0
                                'Cantidad = Cantidad + Val(("0." & CStr(5 Mod iDividendo)))
                            Else
                                Cantidad = Cantidad + Val(("0.0" & CStr(5 Mod iDividendo)))
                            End If
                        Case 6, 7
                            If sParteDecimal.Length = 1 Then
                                Cantidad = 0
                                'Cantidad = Cantidad - Val(("0." & CStr(iDividendo Mod 5)))
                            Else
                                Cantidad = Cantidad - Val(("0.0" & CStr(iDividendo Mod 5)))
                            End If
                        Case 8, 9
                            If sParteDecimal.Length = 1 Then
                                Cantidad = 0
                                'Cantidad = Cantidad + Val(("0." & CStr(10 Mod iDividendo)))
                            Else
                                Cantidad = Cantidad + Val(("0.0" & CStr(10 Mod iDividendo)))
                            End If
                    End Select
                End If
            End If
        Else
            'Si termina en decenas exactas de centavos, no se redondea.
            Cantidad = Cantidad
        End If

        'Cantidad = Redondear(Cantidad, 2)
        Return Cantidad
    End Function

    Public Function Redondear(ByVal dValor As Double, Optional ByVal iDecimales As Integer = 2) As Double
        Dim DBlPot As Double, DBlF As Double
        If dValor < 0 Then DBlF = -0.5 Else  : DBlF = 0.5
        DBlPot = 10 ^ iDecimales
        Return Fix(dValor * DBlPot * (1 + 0.0000000000000001) + DBlF) / DBlPot

        'Dim DBlPot As Double, DBlF As Double
        'If dblnToR < 0 Then DBlF = -0.5 Else  : DBlF = 0.5
        'DBlPot = 10 ^ intCntDec
        'dblnToR = Fix(dblnToR * DBlPot * (1 + 0.0000000000000001) + DBlF) / DBlPot
    End Function

    'Public Function Redondear2(ByVal Numero As String) As String
    '    Dim ParteEntera As String = CInt(Numero).ToString
    '    Dim ParteDecimal As String
    '    If Not (Len(Numero) - Len(ParteEntera)) = 0 Then
    '        ParteDecimal = Right(Numero, Len(Numero) - Len(ParteEntera) - 1)
    '    Else
    '        ParteDecimal = "00"
    '    End If
    '    Dim Num As Double
    '    If Len(ParteDecimal) >= 3 Then
    '        ParteDecimal = Left(ParteDecimal, 3)
    '        If Mid(ParteDecimal, 3, 1) >= "5" Then
    '            ParteDecimal = Left(ParteDecimal, 2)
    '            Num = Convert.ToDouble(ParteDecimal)
    '            Num = Num + 1
    '            If Len(CStr(Num)) = 3 Then ParteEntera = (Convert.ToDouble(ParteEntera) + 1).ToString
    '            ParteDecimal = Right(CStr(Num), 2)
    '        End If
    '    Else
    '        ParteDecimal = Left(ParteDecimal, 2) '<-- El problema estaba aquí. Si el tercer decimal no 
    '        ' empezaba por un numero mayor de 5, saltaba y retornaba 
    '        ' el mismo valor de entrada.

    '    End If
    '    Redondear2 = ParteEntera & "," & ParteDecimal
    'End Function

    '    Public Function RedondeaX(ByVal Cantidad As Double, Optional ByVal iDecimales As Integer = 2) As Double
    '        Dim CantidadOriginal As Double = Cantidad
    '        Dim sCantidad As String = CStr(Cantidad)
    '        Dim sParteDecimal As String = "", dParteDecimal As Double
    '        Dim sParteEntera As String = "", iParteEntera As Integer = 0
    '        Dim Letra As String, Flag As Boolean = False
    '        Dim sCerosExtra As String = "", i As Integer

    '        For i = 1 To Len(sCantidad)
    '            Letra = CChar(Mid(sCantidad, i, 1))
    '            If Not Flag Then
    '                If Letra = "." Then
    '                    Flag = True
    '                    Exit For
    '                End If
    '            End If
    '        Next
    '        If Not Flag Then
    '            iParteEntera = CInt(Cantidad)
    '            Cantidad = iParteEntera
    '            GoTo fin
    '        Else
    '            iParteEntera = CInt(Left(sCantidad, i - 1))
    '            sParteDecimal = Mid(sCantidad, i + 1)
    '        End If

    '        If iDecimales = 0 Then
    '            Cantidad = Redondear(Cantidad, 0)
    '            GoTo fin
    '        Else
    '            If sParteDecimal.Length = 0 Then ' No hay decimales
    '                For i = 1 To (iDecimales + 1) ' Se rellena con ceros hasta cubrir el numero de decimales , mas un cero extra
    '                    sParteDecimal += "0" '
    '                Next
    '            End If
    '            If iDecimales > sParteDecimal.Length Then
    '                For i = 1 To (iDecimales + 1 - sParteDecimal.Length)
    '                    sParteDecimal += "0"
    '                Next
    '            ElseIf iDecimales = sParteDecimal.Length Then
    '                sParteDecimal += "0"
    '            End If
    '        End If


    '        'Se obtiene la parte entera

    '        Letra = ""

    '        Letra = CChar(Mid(sParteDecimal, iDecimales + 1, 1)) 'Se obtiene el digito siguiente al decimal pedido
    '        If CInt(Letra) >= 5 Then
    '            Letra = ""
    '            Letra = CChar(Mid(sParteDecimal, iDecimales, 1)) 'Se obtiene el digito  decimal pedido
    '            Dim iDecena As Integer = CInt(Letra) + 1
    '            If iDecena = 10 Then
    '                If iDecimales = 1 Then
    '                    iParteEntera = iParteEntera + 1
    '                    Cantidad = iParteEntera
    '                Else
    '                    If Len(sParteDecimal) > iDecimales Then
    '                        dParteDecimal = Val(Left(sParteDecimal, iDecimales)) + 1
    '                        If dParteDecimal.ToString.Length > (iDecimales) Then
    '                            Cantidad = CDbl(iParteEntera + 1)
    '                        Else
    '                            Cantidad = CDbl(iParteEntera.ToString & "." & dParteDecimal.ToString)
    '                        End If
    '                    Else
    '                        dParteDecimal = Val(Left(sParteDecimal, iDecimales + 1)) + 1
    '                        If dParteDecimal.ToString.Length > (iDecimales + 1) Then
    '                            Cantidad = CDbl(iParteEntera + 1)
    '                        Else
    '                            Cantidad = CDbl(iParteEntera.ToString & "." & dParteDecimal.ToString)
    '                        End If
    '                    End If

    '                End If
    '            Else
    '                Letra = Right(CStr(CInt(Letra) + 1), 1)
    '                Cantidad = CDbl(iParteEntera.ToString & "." & Left(sParteDecimal, iDecimales - 1) & Letra)
    '            End If
    '        Else
    '            sCantidad = Left(sParteDecimal, iDecimales)
    '            Cantidad = CDbl(iParteEntera.ToString & "." & sCantidad)
    '        End If
    'fin:
    '        If CantidadOriginal < 0 Then
    '            Cantidad *= -1
    '        End If
    '        Return Cantidad
    '    End Function

    Public Function Comas(ByRef strnum As String, Optional ByVal opcion As Boolean = False) As String
        Dim i As Integer, strcaracter As String, stracum As String = ""
        Dim valor As Integer

        valor = Len(strnum)
        For i = 1 To valor
            strcaracter = Mid(strnum, i, 1)
            If InStr("-01234567890.", strcaracter) > 0 Then
                stracum = stracum & strcaracter
            Else
                If opcion Then
                    strnum = stracum
                    Return strnum
                End If
            End If
        Next i
        strnum = stracum
        Return strnum
    End Function


    'Public Function Existencia_articulo(ByVal sCodigo_Art As String, ByVal sCodigo_alm As String) As Double
    '    Dim busca As New Class_find("SELECT EXISTENCIA FROM EXISTENCIAS_ACTUALES WHERE CODIGO_ART='" & sCodigo_Art & "' AND CODIGO_ALM='" & sCodigo_alm & "'")
    '    Return Redondear(CDbl(Val(busca.Result1)), 3)
    'End Function

    'Public Function Calcula_Precio_Articulo(ByVal sCodigo_Art As String, ByVal sCodigo_Lista As Integer) As Double
    '    Dim busca As Class_find
    '    Select Case sCodigo_Lista
    '        Case 1
    '            busca = New Class_find("SELECT PVTA_V1 FROM CATPRECIOS WHERE CODIGO_ART='" & sCodigo_Art & "'")
    '        Case 2
    '            busca = New Class_find("SELECT PVTA_V2 FROM CATPRECIOS WHERE CODIGO_ART='" & sCodigo_Art & "'")
    '        Case 3
    '            busca = New Class_find("SELECT PVTA_V3 FROM CATPRECIOS WHERE CODIGO_ART='" & sCodigo_Art & "'")
    '        Case 4
    '            busca = New Class_find("SELECT PVTA_V4 FROM CATPRECIOS WHERE CODIGO_ART='" & sCodigo_Art & "'")
    '        Case 5
    '            busca = New Class_find("SELECT PVTA_V5 FROM CATPRECIOS WHERE CODIGO_ART='" & sCodigo_Art & "'")
    '        Case Else
    '            busca = New Class_find("SELECT PVTA_V1 FROM CATPRECIOS WHERE CODIGO_ART='" & sCodigo_Art & "'")
    '    End Select

    '    Return Redondear(CDbl(Val(busca.Result1)), 2)
    'End Function

    'Public Function Calcula_Ultimo_Costo_Articulo(ByVal sCodigo_Art As String, ByVal sCodigo_alm As String) As Double
    '    Dim busca As New Class_find("SELECT COSTO  FROM EXISTENCIAS_ACTUALES WHERE CODIGO_ART='" & sCodigo_Art & "' AND CODIGO_ALM='" & sCodigo_alm & "'")
    '    Return Redondear(CDbl(Val(busca.Result1)), 2)
    'End Function

    'Public Function Calcula_Impuesto_Articulo(ByVal sCodigo_Art As String) As Double
    '    Dim busca As New Class_find("SELECT valorreal FROM Catarti c inner join catimpuestos i on c.cod_impuesto=i.cod_impuesto WHERE CODIGO_ART='" & sCodigo_Art & "'")
    '    Return Redondear(CDbl(Val(busca.Result1)), 2)
    'End Function

    'Public Function Calcula_Costo_articulo(ByVal sCodigo_Art As String, ByVal sCodigo_alm As String, ByVal dCantidad As Double) As Double
    '    Dim cmd As SqlCommand
    '    Dim cn As New SqlConnection(Empresa_Sistema.conexion)
    '    Dim p As SqlParameter
    '    Try
    '        cn.Open()
    '        cmd = New SqlCommand
    '        With cmd
    '            .Connection = cn
    '            .CommandTimeout = 0
    '            .CommandText = "dbo.MP_INVENTARIOS_CALCULO_COSTEO"
    '            .CommandType = CommandType.StoredProcedure
    '            p = .Parameters.Add("@CODIGO_ART", SqlDbType.VarChar, 16) : p.Value = sCodigo_Art.ToString
    '            p = .Parameters.Add("@CODIGO_ALM", SqlDbType.VarChar, 3) : p.Value = sCodigo_alm.ToString
    '            p = .Parameters.Add("@CANTIDAD", SqlDbType.Money, 18) : p.Value = dCantidad
    '            p = .Parameters.Add("@RESULTADO", SqlDbType.Money, 18) : p.Direction = ParameterDirection.Output
    '            p = .Parameters.Add("@SIMULA", SqlDbType.Bit) : p.Value = 1
    '            .ExecuteNonQuery()
    '        End With

    '        Return CDbl(cmd.Parameters("@RESULTADO").Value)
    '        cmd.Dispose()
    '    Catch ex As Exception
    '        MsgBox("Error al calcular el costo. " & ex.Message)
    '    Finally
    '        cn.Close() : cn.Dispose()

    '    End Try
    'End Function

    Public Function FG_Meses(ByVal StrMes As String, Optional ByVal Tipo As Integer = 0) As String
        'Tipo 0 = Regresa el Numero de Mes, Tipo 1= Regresa la Descripcion del Mes
        Dim Regreso As String = ""
        If Tipo = 1 Then
            Dim meses(13) As String
            meses(0) = "ENERO"
            meses(1) = "ENERO"
            meses(2) = "FEBRERO"
            meses(3) = "MARZO"
            meses(4) = "ABRIL"
            meses(5) = "MAYO"
            meses(6) = "JUNIO"
            meses(7) = "JULIO"
            meses(8) = "AGOSTO"
            meses(9) = "SEPTIEMBRE"
            meses(10) = "OCTUBRE"
            meses(11) = "NOVIEMBRE"
            meses(12) = "DICIEMBRE"
            meses(13) = "CIERRE"
            Regreso = meses(Convert.ToInt16(StrMes))
        End If

        If Tipo = 0 Then
            If StrMes = "ENERO" Then Regreso = ("1")
            If StrMes = "FEBRERO" Then Regreso = ("2")
            If StrMes = "MARZO" Then Regreso = ("3")
            If StrMes = "ABRIL" Then Regreso = ("4")
            If StrMes = "MAYO" Then Regreso = ("5")
            If StrMes = "JUNIO" Then Regreso = ("6")
            If StrMes = "JULIO" Then Regreso = ("7")
            If StrMes = "AGOSTO" Then Regreso = ("8")
            If StrMes = "SEPTIEMBRE" Then Regreso = ("9")
            If StrMes = "OCTUBRE" Then Regreso = ("10")
            If StrMes = "NOVIEMBRE" Then Regreso = ("11")
            If StrMes = "DICIEMBRE" Then Regreso = ("12")
            If StrMes = "CIERRE" Then Regreso = ("13")
        End If

        Return Regreso
    End Function

    Public Function valorNumerico(ByVal sNumero As String) As Double
        Try
            If IsNumeric(sNumero) = True Then
                Comas(sNumero)
                valorNumerico = Val(sNumero)
            Else
                valorNumerico = 0
            End If
        Catch ex As Exception
            HandleError("Utílerias", "valorNumerico", ex)
        End Try
    End Function

    Public Function ConvertirArrayAColeccion(ByVal array() As Integer) As Collection
        Dim x As New Collection, i As Integer
        For i = 0 To array.Length - 1
            x.Add(array(i))
        Next
        ConvertirArrayAColeccion = x
    End Function

    Public Function FechaActualINI() As Date
        Dim dFecha As Date = Date.Now
        dFecha = CDate("01/" & Month(dFecha) & "/" & Year(dFecha))
        FechaActualINI = dFecha
    End Function

    Public Function FechaActualFIN() As Date
        Dim dFecha As Date = Date.Now
        dFecha = CDate(DiasDelMes(dFecha) & "/" & Month(dFecha) & "/" & Year(dFecha))
        FechaActualFIN = dFecha
    End Function

    Public Function FechaMesINI(ByVal dFecha As Date) As Date
        dFecha = CDate("01/" & Month(dFecha) & "/" & Year(dFecha))
        FechaMesINI = dFecha
    End Function

    Public Function FechaMesFIN(ByVal dFecha As Date) As Date
        dFecha = CDate(DiasDelMes(dFecha) & "/" & Month(dFecha) & "/" & Year(dFecha))
        FechaMesFIN = dFecha
    End Function

    Public Function DiasDelMes(ByVal dFecha As Date) As Integer
        Dim mes As Integer, Y As Integer

        Y = Year(dFecha)
        mes = Month(dFecha)

        Select Case mes
            Case 2 : DiasDelMes = CInt(IIf(saltarYear(dFecha), 29, 28))
            Case 1, 3, 5, 7, 8, 10, 12 : DiasDelMes = 31
            Case 4, 6, 9, 11 : DiasDelMes = 30
        End Select

    End Function

    Public Function saltarYear(ByVal dFecha As Date) As Boolean
        Dim iYear As Integer
        iYear = Year(dFecha)
        If (DateSerial(iYear, 3, 0)).Day = 29 Then
            saltarYear = True
        End If
    End Function

    Public Function sReplace(ByVal sString As String) As String
        sReplace = Replace(sString, "'", "''")
    End Function

    Public Function CerosEnCadena(ByVal iCantidadCeros As Integer) As String
        Dim sCadena As String = ""
        For i As Integer = 1 To iCantidadCeros
            sCadena = sCadena & "0"
        Next
        CerosEnCadena = sCadena
    End Function

    Public Function FormatImporteContable(ByVal dImporte As Double, Optional ByVal bConSignoMoneda As Boolean = True) As String
        If bConSignoMoneda = True Then
            FormatImporteContable = Format(dImporte, "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD))
        Else
            FormatImporteContable = Format(dImporte, "###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD))
        End If
    End Function

    Public Function FormatCantidad(ByVal dCantidad As Double) As String
        Return Format(dCantidad, "###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CANTIDAD))
    End Function

    Public Function FormatFechaCorta(ByVal dFecha As Date) As String
        Return Format(dFecha, "dd-MMM-yy").ToUpper
    End Function

    Public Sub HandleError(ByVal CurrentModule As String, ByVal CurrentProcedure As String, ByVal ex As Exception)
        'If ex.Source = ".Net SqlClient Data Provider" Then
        '    MsgBox("Error : " & My.Settings.Servidor & " " & ex.Message.ToString, MsgBoxStyle.Critical, _
        '    "Error en : " & CurrentModule & " " & CurrentProcedure)
        'Else
        '    MsgBox("Error : " & ex.Message.ToString, MsgBoxStyle.Critical, _
        '    "Error en : " & CurrentModule & " " & CurrentProcedure)
        'End If
        MsgBox("Error : " & ex.Message.ToString, MsgBoxStyle.Critical, _
        "Error en : " & CurrentModule & " " & CurrentProcedure)
    End Sub

    Public Sub txtTAB(ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Public Function txtLEN(ByVal sText As String) As Boolean
        If Len(sText) > 0 Then
            txtLEN = True
        End If
    End Function

    ''' <summary>
    ''' Metodo para separar una cadena por el metodo String.Split y retornarla con formato SQL para consultas sobre varios registros.
    ''' </summary>
    ''' <param name="prmCadena">String con los valores separados por un caracter que servirá como base para la consulta SQL</param>
    ''' <param name="prmSeparador">Indica el parametro Separator de tipo CHAR del metodo String.Split</param>
    ''' <returns>Retorna la misma cadena esta vez con el caracter apostrofe inicial y final por cada elemento y el separador coma(",") </returns>
    ''' <remarks></remarks>
    Public Function FormatearCadenaParaConsultaSQL(ByVal prmCadena As String, ByVal prmSeparador As Char) As String
        Dim vArregloStringAuxiliar As String()
        vArregloStringAuxiliar = prmCadena.Split(prmSeparador)
        prmCadena = String.Empty
        For i As Integer = 0 To vArregloStringAuxiliar.Length - 1
            If i > 0 Then
                prmCadena = prmCadena + ","
            End If
            prmCadena += Chr(39) + vArregloStringAuxiliar(i) + Chr(39)
        Next
        Return prmCadena
    End Function

    ' Subrutina que copia el archivo
    Public Function Copiar_Archivo(ByVal Origen As String, ByVal Destino As String) As Boolean
        Dim t_Op As SHFILEOPSTRUCT
        Try
            With t_Op
                .hWnd = 0
                .wFunc = FO_COPY
                .pFrom = Origen & vbNullChar & vbNullChar
                .pTo = Destino & vbNullChar & vbNullChar
                .fFlags = FOF_NOCONFIRMATION 'FOF_ALLOWUNDO
            End With

            ' Se ejecuta la función Api pasandole la estructura
            SHFileOperation(t_Op)

            Copiar_Archivo = True

            Exit Function
        Catch ex As Exception

        End Try
    End Function

    Private Declare Function SHFileOperation Lib "shell32.dll" Alias "SHFileOperationA" (ByRef lpFileOp As SHFILEOPSTRUCT) As Integer

    'Constantes
    Private Const FO_COPY As Integer = &H2
    Private Const FOF_ALLOWUNDO As Integer = &H40
    Private Const FOF_NOCONFIRMATION As Integer = &H10 'Sobreescribe sin preguntar

    Public Function isExisteArchivo(ByVal sRuta As String) As Boolean
        Try
            If Len(Dir(sRuta)) > 0 Then
                isExisteArchivo = True
            Else
                isExisteArchivo = False
            End If
            Exit Function
        Catch ex As Exception

        End Try
    End Function

    Public Function MesNumeroALetra(ByVal iMes As Short, Optional ByVal bFormatoCorto As Boolean = False) As String
        Dim sResultado As String = ""
        Try
            Select Case iMes
                Case 1 : sResultado = "ENERO"
                Case 2 : sResultado = "FEBRERO"
                Case 3 : sResultado = "MARZO"
                Case 4 : sResultado = "ABRIL"
                Case 5 : sResultado = "MAYO"
                Case 6 : sResultado = "JUNIO"
                Case 7 : sResultado = "JULIO"
                Case 8 : sResultado = "AGOSTO"
                Case 9 : sResultado = "SEPTIEMBRE"
                Case 10 : sResultado = "OCTUBRE"
                Case 11 : sResultado = "NOVIEMBRE"
                Case 12 : sResultado = "DICIEMBRE"
            End Select
            If bFormatoCorto = True Then
                sResultado = Mid(sResultado, 1, 3)
            End If
        Catch ex As Exception
            HandleError("Mod_Uti", "MesNumeroALetra", ex)
        End Try

        Return sResultado
    End Function

    Delegate Sub TaskDelegate()

    Public Sub TDelegateCrystal()
        Dim td As New TaskDelegate(AddressOf TestCrystal)
        ' Runs on a worker thread from the pool.
        td.BeginInvoke(Nothing, Nothing)
    End Sub

    Private Sub TestCrystal()
        Dim FormatoDeReporte As String = ""
        Dim Rpt As ReportDocument
        Rpt = New ReportDocument
        Dim oReporte As Class_Reporte
        Try
            FormatoDeReporte = "RPT_CRYSTAL_PRUEBA_INICIO"
            oReporte = New Class_Reporte(FormatoDeReporte, Rpt)

            Dim frm As New Reporte(Rpt)
            frm.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frm.CRViewer.Visible = False
            frm.WindowState = FormWindowState.Minimized
            frm.Show()
            frm.Dispose()
        Catch ex As Exception
            HandleError("Mod_Uti", "TestCrystal", ex)
        Finally
            oReporte = Nothing
        End Try
    End Sub

    Public Function DuracionSegundos(ByVal dHoraInicio As Date) As String
        DuracionSegundos = ""
        Try
            Dim iSegundos As Long
            iSegundos = DateDiff(DateInterval.Second, dHoraInicio, Now)
            DuracionSegundos = Int(iSegundos / 60).ToString

            DuracionSegundos = DuracionSegundos & ":" & Format((iSegundos - (60 * CDbl(DuracionSegundos))), "0#") & " minutos"
        Catch ex As Exception
            HandleError("Mod_Uti", "DuracionSegundos", ex)
        End Try
    End Function

    Public Function ValidaTarjetaBancaria(ByVal NumeroTarjeta As String) As Boolean
        Dim bResultado As Boolean = False
        Dim i As Integer, w, x, y As Double

        Try
            y = 0
            NumeroTarjeta = Replace(Replace(Replace(CStr(NumeroTarjeta), "-", ""), " ", ""), ".", "") 'Ensure proper format of the input
            'Process digits from right to left, drop last digit if total length is even
            w = 2 * (Len(NumeroTarjeta) Mod 2)
            For i = Len(NumeroTarjeta) - 1 To 1 Step -1
                x = CDbl(Mid(NumeroTarjeta, i, 1))
                If IsNumeric(x) Then
                    Select Case (i Mod 2) + w
                        Case 0, 3 'Even Digit - Odd where total length is odd (eg. Visa vs. Amx)
                            y = y + CInt(x)
                        Case 1, 2 'Odd Digit - Even where total length is odd (eg. Visa vs. Amx)
                            x = CInt(x) * 2
                            If x > 9 Then
                                'Break the digits (eg. 19 becomes 1 + 9)
                                y = y + (CLng(x) \ 10) + (x - 10)
                            Else
                                y = y + x
                            End If
                    End Select
                End If
            Next
            'Return the 10's complement of the total
            y = 10 - (y Mod 10)
            If y > 9 Then y = 0
            bResultado = (CStr(y) = Microsoft.VisualBasic.Strings.Right(NumeroTarjeta, 1))
        Catch ex As Exception
            HandleError("Mod_Uti", "ValidaTarjetaBancaria", ex)
        End Try

        Return bResultado
    End Function

    Public Function ConvierteXMLUTF8(ByVal sRutaXML As String) As Boolean
        Dim bResultado As Boolean = False
        Try
            Dim Var As Object
            Var = Shell(sFelectronicaConvierteUTF8Local & " """ & sRutaXML & """", AppWinStyle.MinimizedFocus)
            bResultado = True
        Catch ex As Exception
            HandleError("Mod_Uti", "ConvierteXMLUTF8", ex)
        End Try
        Return bResultado
    End Function

    Public Function IsEmailSyntaxValid(ByVal emailToValidate As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(emailToValidate, "^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
    End Function

    Public Function ActualConfgRegional(ByVal LCID As Integer, ByVal iTipo As Integer) As String
        Dim sReturn As String = ""
        Dim r As Integer
        Try
            r = GetLocaleInfo(LCID, iTipo, sReturn, Len(sReturn))
            If r > 0 Then
                sReturn = Space(CInt(r))
                r = GetLocaleInfo(LCID, iTipo, sReturn, Len(sReturn))
                sReturn = Microsoft.VisualBasic.Left(sReturn, CInt(r - 1))
            End If

        Catch ex As Exception
            HandleError("Mod_Uti", "ActualConfgRegional", ex)
        End Try
        Return sReturn
    End Function

    Public Function isSistemaValidaConfiguracionRegional() As Boolean
        Dim bResultado As Boolean = False
        Dim sProcedure As String = "isSistemaValidaConfiguracionRegional"
        Dim LCID As Integer, sParcial As String = "", sCorrecto As String = ""
        Try
            LCID = GetSystemDefaultLCID()

            'MsgBox(ActualConfgRegional(LCID, LOCALE_SCURRENCY)  & vbCrLf & ActualConfgRegional(LCID, LOCALE_SDATE) & vbCrLf & ActualConfgRegional(LCID, LOCALE_SDECIMAL) & vbCrLf & ActualConfgRegional(LCID, LOCALE_STHOUSAND) & vbCrLf & _
            '       ActualConfgRegional(LCID, LOCALE_ICURRDIGITS) & vbCrLf & ActualConfgRegional(LCID, LOCALE_SSHORTDATE) & vbCrLf & ActualConfgRegional(LCID, LOCALE_STIMEFORMAT) & vbCrLf)

            sParcial = ActualConfgRegional(LCID, LOCALE_SCURRENCY)
            sCorrecto = "$"
            If sParcial <> sCorrecto Then
                MsgBox("La configuración regional del equipo esta incorrecta, avíse al depto. de sistemas." & vbCrLf & _
                       "LOCALE_SCURRENCY=" & sParcial & " debería ser=" & sCorrecto, MsgBoxStyle.Critical, sProcedure)
                Return False
            End If

            sParcial = ActualConfgRegional(LCID, LOCALE_SDATE)
            sCorrecto = "/"
            If sParcial <> sCorrecto Then
                MsgBox("La configuración regional del equipo esta incorrecta, avíse al depto. de sistemas." & vbCrLf & _
                       "LOCALE_SDATE=" & sParcial & " debería ser=" & sCorrecto, MsgBoxStyle.Critical, sProcedure)
                Return False
            End If

            sParcial = ActualConfgRegional(LCID, LOCALE_SDECIMAL)
            sCorrecto = "."
            If sParcial <> sCorrecto Then
                MsgBox("La configuración regional del equipo esta incorrecta, avíse al depto. de sistemas." & vbCrLf & _
                       "LOCALE_SDECIMAL=" & sParcial & " debería ser=" & sCorrecto, MsgBoxStyle.Critical, sProcedure)
                Return False
            End If

            sParcial = ActualConfgRegional(LCID, LOCALE_STHOUSAND)
            sCorrecto = ","
            If sParcial <> sCorrecto Then
                MsgBox("La configuración regional del equipo esta incorrecta, avíse al depto. de sistemas." & vbCrLf & _
                       "LOCALE_STHOUSAND=" & sParcial & " debería ser=" & sCorrecto, MsgBoxStyle.Critical, sProcedure)
                Return False
            End If

            sParcial = ActualConfgRegional(LCID, LOCALE_ICURRDIGITS)
            sCorrecto = "2"
            If sParcial <> sCorrecto Then
                MsgBox("La configuración regional del equipo esta incorrecta, avíse al depto. de sistemas." & vbCrLf & _
                       "LOCALE_ICURRDIGITS=" & sParcial & " debería ser=" & sCorrecto, MsgBoxStyle.Critical, sProcedure)
                Return False
            End If

            sParcial = ActualConfgRegional(LCID, LOCALE_SSHORTDATE)
            sCorrecto = "dd/MM/yyyy"
            If sParcial <> sCorrecto Then
                MsgBox("La configuración regional del equipo esta incorrecta, avíse al depto. de sistemas." & vbCrLf & _
                       "LOCALE_SSHORTDATE=" & sParcial & " debería ser=" & sCorrecto, MsgBoxStyle.Critical, sProcedure)
                Return False
            End If

            sParcial = ActualConfgRegional(LCID, LOCALE_STIMEFORMAT)
            sCorrecto = "hh:mm:ss tt"
            If sParcial <> sCorrecto Then
                MsgBox("La configuración regional del equipo esta incorrecta, avíse al depto. de sistemas." & vbCrLf & _
                       "LOCALE_STIMEFORMAT=" & sParcial & " debería ser=" & sCorrecto, MsgBoxStyle.Critical, sProcedure)
                Return False
            End If

            bResultado = True

        Catch ex As Exception
            HandleError("Mod_Uti", sProcedure, ex)
        End Try

        Return bResultado
    End Function

End Module
