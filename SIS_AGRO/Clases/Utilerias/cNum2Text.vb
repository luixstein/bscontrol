Option Strict Off
Option Explicit On
Option Compare Text
Friend Class cNum2Text
    '------------------------------------------------------------------------------
    ' CNUMERO2LETRA   CLASE PARA CONVERTIR NUMEROS A LETRAS             (04/ENE/99)
    '
    ' VERSION ORIGINAL PARA MS-DOS:                         ( 1/MAR/91)
    ' VERSION PARA WINDOWS                                  (25/OCT/96)
    ' ULTIMA REVISION:                                      (10/JUL/97)
    ' PARA MANEJAR EL SEXO DE LA MONEDA Y LOS CENTIMOS      ( 6/ENE/99)
    ' AÑADO LA FUNCION CONVDECIMAL                          (10/ENE/99)
    ' QUITADOS LOS CEROS A LA DERECHA DE LOS DECIMALES      (13/ENE/99)
    '
    ' CORRECCION PARA CIENTOS MILLONES                      (05/MAR/99)
    ' CORRECCION PARA CIENTOS MILLONES (2ª)                 (30/JUN/00)
    ' PLURALIZAR ES UN FUNCION PUBLICA                      (07/JUL/00)
    ' NUEVOS ARREGLOS A LOS DECIMALES, VER COMENTARIOS.     (08/JUL/00)
    ' ARREGLADO EL TEMA DEL SEXO DE LOS CENTIMOS            (20/JUL/00)
    ' ARREGLADO EL FALLO DEL 1000                           (19/AGO/00)
    ' CORRECCION PARA CIENTOS MILLONES (3ª)                 (07/DIC/00)
    ' CORRECCION CUANDO LA FRACCION ERA JUSTAMENTE "2"      (08/SEP/01)
    '
    ' ©GUILLERMO 'GUILLE' SOM, 1991-2001
    '------------------------------------------------------------------------------

    'DECLARADAS A NIVEL DE MODULO
    Dim UNIDAD(9) As String
    Dim DECENA(9) As String
    Dim CENTENA(10) As String
    Dim DECI(9) As String
    Dim OTROS(15) As String

    Private M_SEXO1 As String
    Private M_SEXO2 As String
    Private M_LENSEXO1 As Double

    Public Enum ESEXO
        FEMENINO '= 0
        MASCULINO '= 1
    End Enum

    Public Function NUMERO2LETRA(ByVal strnum As String, Optional ByVal LO As Double = 0, Optional ByVal NUMDECIMALES As Double = 2, Optional ByVal SMONEDA As String = "", Optional ByVal SCENTIMOS As String = "", Optional ByVal SEXOMONEDA As ESEXO = ESEXO.FEMENINO, Optional ByVal SEXOCENTIMOS As ESEXO = ESEXO.MASCULINO, Optional ByVal sMn As String = " M.N.") As String
        '----------------------------------------------------------
        ' CONVIERTE EL NUMERO STRNUM EN LETRAS          (28/FEB/91)
        ' VERSION PARA WINDOWS                          (25/OCT/96)
        ' VARIABLES ESTATICAS                           (15/MAY/97)
        ' PARCHE DE "ESTEVE" <ESTEVE@MUR.HNET.ES>       (20/MAY/97)
        ' REVISION PARA DECIMALES                       (10/JUL/97)
        ' PERMITE INDICAR EL SEXO DE LA MONEDA          ( 6/ENE/99)
        ' Y DE LOS CENTIMOS... NUNCA SE SABE...
        ' CORREGIDO FALLO DE LOS DECIMALES CUANDO       (13/ENE/99)
        ' TIENEN CEROS A LA DERECHA.
        '
        ' LA MONEDA DEBE ESPECIFICARSE EN SINGULAR, YA QUE LA FUNCION
        ' SE ENCARGA DE CONVERTIRLA EN PLURAL.
        ' SE PUEDE INDICAR EL NUMERO DE DECIMALES A DEVOLVER
        ' POR DEFECTO SON DOS.
        '----------------------------------------------------------
        'Dim i As Double
        Dim IHAYDECIMAL As Double 'POSICION DEL SIGNO DECIMAL
        Dim SDECIMAL As String = "" 'SIGNO DECIMAL A USAR
        Dim SDECIMALNO As String = "" 'SIGNO NO DECIMAL
        Dim SENTERO As String
        Dim SFRACCION As String
        Dim FFRACCION As Long
        Dim SNUMERO As String
        Static SEXOANTMONEDA As ESEXO
        'Static SEXOANTCENTIMOS As ESEXO
        Dim SSEXOCENTS As String
        '
        ' PARA TENER EN CUENTA EL SEXO DE LOS CENTIMOS                  (20/JUL/00)
        ' M_SEXO2 SE USA PARA INDICAR EL PLURAL DE LAS MONEDAS,
        ' SSEXOCENTS SUSTITUIRA A ESA VARIABLE CUANDO SE CALCULEN LOS CENTIMOS
        If SEXOCENTIMOS = ESEXO.FEMENINO Then
            SSEXOCENTS = "OS"
        Else
            SSEXOCENTS = "OS"
        End If
        '
        'DEPENDIENDO DEL "SEXO" INDICADO, USAR LAS TERMINACIONES
        If SEXOMONEDA = ESEXO.FEMENINO Then
            M_SEXO1 = "O"
            M_SEXO2 = "OS"
        Else
            M_SEXO1 = ""
            M_SEXO2 = "OS"
        End If
        'POR SI SE CAMBIA EN EL TRASCURSO EL SEXO DE LA MONEDA
        If SEXOMONEDA <> SEXOANTMONEDA Then
            UNIDAD(1) = "" ' AQUÍ PONÍA: UNIDAD(2) = ""                 (08/SEP/01)
            SEXOANTMONEDA = SEXOMONEDA
        End If
        M_LENSEXO1 = Len(M_SEXO1)

        'SI SE ESPECIFICA, SE USARAN
        SMONEDA = Trim(SMONEDA)
        If Len(Trim(SMONEDA)) Then
            SMONEDA = " " & SMONEDA & " "
        Else
            SMONEDA = " "
        End If

        SCENTIMOS = Trim(SCENTIMOS)
        If Len(Trim(SCENTIMOS)) Then
            SCENTIMOS = " " & SCENTIMOS & " "
        Else
            SCENTIMOS = " "
        End If

        'SI NO SE ESPECIFICA EL ANCHO...
        '
        If LO Then
            SNUMERO = Space(LO)
        Else
            SNUMERO = ""
        End If

        'COMPROBAR EL SIGNO DECIMAL Y DEVOLVER LOS ADECUADOS A LA CONFIG. REGIONAL
        strnum = CONVDECIMAL(strnum, SDECIMAL, SDECIMALNO)

        'COMPROBAR SI TIENE DECIMALES
        IHAYDECIMAL = InStr(strnum, SDECIMAL)
        If IHAYDECIMAL Then
            SENTERO = Left(strnum, IHAYDECIMAL - 1)
            SFRACCION = Mid(strnum, IHAYDECIMAL + 1) & New String("0", NUMDECIMALES)
            'OBLIGAR A QUE TENGA DOS CIFRAS
            '
            'PERO HABRÍA QUE REDONDEAR EL RESTO...
            'POR EJEMPLO:
            '   .256 SERÍA .26 Y
            '   .254 SERÍA .25
            'PERO ESTO OTRO NO SE HARÍA:
            '.25499 NO PASARÍA A .255 Y DESPUES A .26
            '
            '*SFRACCION = LEFT$(SFRACCION, NUMDECIMALES + 1)
            '*FFRACCION = INT((VAL(SFRACCION) / 100) * 10 + 0.5) * 10
            '*SFRACCION = LEFT$(CSTR(FFRACCION), NUMDECIMALES)
            '
            ' NO HACER CALCULOS DE REDONDEO NI NADA DE NADA             (08/JUL/00)
            '
            ' DE ESTA FORMA SE DIRA:
            '   ,06 CON SEIS
            '   ,50 CON CINCUENTA
            '
            SFRACCION = Left(SFRACCION, NUMDECIMALES)
            '
            '* EN LAS FRACCIONES LOS CEROS A LA DERECHA NO TIENEN SIGNIFICADO
            '----------------------------------------------------------------------
            ' PERO SI TENEMOS: 125.50 SI QUE TIENE SIGNIFICADO,         (08/JUL/00)
            ' YA QUE TAL Y COMO ESTA AHORA, DIRÍA CON 5 EN LUGAR DE CINCUENTA
            ' ASÍ QUE SI SE PONEN NUMDECIMALES MAYOR DE 2,
            ' HAY QUE SER CONSECUENTES CON LOS RESULTADOS.
            '----------------------------------------------------------------------
            '*DO WHILE RIGHT$(SFRACCION, 1) = "0"
            '*    SFRACCION = LEFT$(SFRACCION, LEN(SFRACCION) - 1)
            '*LOOP
            '
            FFRACCION = Val(SFRACCION)
            ' SI NO HAY DECIMALES... NO AGREGAR NADA...
            If FFRACCION < 1 Then
                If Len(Trim(SMONEDA)) Then
                    SMONEDA = PLURALIZAR(SNUMERO, SMONEDA)
                End If
                If Right(SENTERO, 6) = "000000" Then
                    SMONEDA = " DE" + SMONEDA
                End If
                strnum = RTrim(UNNUMERO(SENTERO, M_SEXO1) & SMONEDA)
                If LO Then
                    SNUMERO = LSet(strnum, Len(SNUMERO))
                Else
                    SNUMERO = strnum
                End If
                NUMERO2LETRA = SNUMERO & " 00/100 " & sMn
                Exit Function
            End If

            If Len(Trim(SMONEDA)) Then
                SMONEDA = PLURALIZAR(SENTERO, SMONEDA)
            End If

            If Right(SENTERO, 6) = "000000" Then
                SMONEDA = " DE" + SMONEDA
            End If

            SENTERO = UNNUMERO(SENTERO, M_SEXO1)

            If Len(Trim(SCENTIMOS)) Then
                SCENTIMOS = PLURALIZAR(SFRACCION, SCENTIMOS)
            End If

            ' PARA EL SEXO DE LOS DECIMALES
            ' NO SE SI ESTO PUEDE CAMBIAR, PERO POR SI OCURRE...
            '
            ' SUSTITUIMOS EL PLURAL DE LAS MONEDAS,                     (20/JUL/00)
            ' PARA ADECUARLA A LOS CENTIMOS,
            ' YA QUE EN ESPAÑA, LA MONEDA ES FEMENINO, PERO LOS CENTIMOS MASCULINO.
            M_SEXO2 = SSEXOCENTS
            If SEXOCENTIMOS = ESEXO.MASCULINO Then
                'SFRACCION = UNNUMERO(SFRACCION, "")
            Else
                'SFRACCION = UNNUMERO(SFRACCION, "A")
            End If
            '
            strnum = SENTERO & SMONEDA
            If LO Then
                SNUMERO = LSet(RTrim(strnum), Len(SNUMERO))
            Else
                SNUMERO = RTrim(strnum)
            End If
            ' valida los decimales

            NUMERO2LETRA = SNUMERO
            NUMERO2LETRA = NUMERO2LETRA & " " & SFRACCION & "/100 " & sMn

        Else
            If Len(Trim(SMONEDA)) Then
                SMONEDA = PLURALIZAR(strnum, SMONEDA)
            End If
            strnum = RTrim(UNNUMERO(strnum, M_SEXO1) & SMONEDA)
            If LO Then
                SNUMERO = LSet(strnum, Len(SNUMERO))
            Else
                SNUMERO = strnum
            End If
            'aqui
            NUMERO2LETRA = SNUMERO
            NUMERO2LETRA = NUMERO2LETRA & " 00/100 " & sMn
        End If
    End Function

    Private Function UNNUMERO(ByVal strnum As String, ByVal SEXO1 As String) As String
        '----------------------------------------------------------
        'ESTA ES LA RUTINA PRINCIPAL                    (10/JUL/97)
        'ESTA SEPARADA PARA PODER ACTUAR CON DECIMALES
        '----------------------------------------------------------
        Dim DBLNUMERO As Double

        Dim NEGATIVO As Boolean
        Dim L As Short
        Dim UNA As Boolean
        Dim MILLON As Boolean
        Dim MILLONES As Boolean
        Dim VEZ As Double
        Dim MAXVEZ As Double
        Dim K As Double
        Dim STRQ As String
        Dim STRB As String
        Dim STRU As String
        Dim STRD As String
        Dim STRC As String
        Dim IA As Double
        '
        Dim STRN() As String
        Dim SEXO1ANT As String

        'SI SE AMPLIA ESTE VALOR... NO SE MANIPULARAN BIEN LOS NUMEROS
        Const CANCHO As Short = 12
        Const CGRUPOS As Short = CANCHO \ 3

        'POR SI SE ESPECIFICA EL SEXO, PARA EL CASO DE LOS DECIMALES
        'QUE SIEMPRE SERA MASCULINO
        SEXO1ANT = M_SEXO1
        M_SEXO1 = SEXO1

        M_LENSEXO1 = Len(M_SEXO1)
        '
        ' IDEA APORTADA POR HARVEY TRIANA
        ' PARA NO TENER QUE ESTAR REINICIALIZANDO CONTINUAMENTE LOS ARRAYS
        '
        ' SE VE QUE LO ANTERIOR FALLABA SI SE USABA VARIAS VECES SEGUIDAS (05/MAR/99)
        If UNIDAD(1) <> "UN" & SEXO1 Then
            INICIALIZARARRAYS()
        End If
        '
        '    IF M_SEXO1 <> SEXO1ANT THEN
        '        UNIDAD(2) = ""
        '    END IF
        '    '
        '    IF UNIDAD(2) <> "DOS" THEN
        '        INICIALIZARARRAYS
        '    END IF
        '

        'SI SE PRODUCE UN ERROR QUE SE PARE EL MUNDO!!!
        On Error GoTo 0

        If Len(strnum) = 0 Then
            strnum = "0"
        End If

        DBLNUMERO = System.Math.Abs(CInt(strnum))
        NEGATIVO = (DBLNUMERO <> CInt(strnum))
        strnum = LTrim(RTrim(Str(DBLNUMERO)))
        L = Len(strnum)

        If DBLNUMERO < 1 Then
            UNNUMERO = "CERO"
            Exit Function
        End If
        '
        UNA = True
        MILLON = False
        MILLONES = False
        If L < 4 Then UNA = False
        If DBLNUMERO > 999999 Then MILLON = True
        If DBLNUMERO > 1999999 Then MILLONES = True
        STRB = ""
        STRQ = strnum
        VEZ = 0

        'UPGRADE_WARNING: Lower bound of array STRN was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
        ReDim STRN(CGRUPOS)
        STRQ = Right(New String("0", CANCHO) & strnum, CANCHO)
        For K = Len(STRQ) To 1 Step -3
            VEZ = VEZ + 1
            STRN(VEZ) = Mid(STRQ, K - 2, 3)
        Next
        MAXVEZ = CGRUPOS
        For K = CGRUPOS To 1 Step -1
            If STRN(K) = "000" Then
                MAXVEZ = MAXVEZ - 1
            Else
                Exit For
            End If
        Next
        For VEZ = 1 To MAXVEZ
            STRU = ""
            STRD = ""
            STRC = ""
            strnum = STRN(VEZ)
            L = Len(strnum)
            K = Val(Right(strnum, 2))
            If Right(strnum, 1) = "0" Then
                K = K \ 10
                STRD = DECENA(K)
            ElseIf K > 10 And K < 16 Then
                K = Val(Mid(strnum, L - 1, 2))
                STRD = OTROS(K)
            Else
                STRU = UNIDAD(Val(Right(strnum, 1)))
                If L - 1 > 0 Then
                    K = Val(Mid(strnum, L - 1, 1))
                    STRD = DECI(K)
                End If
            End If
            '---PARCHE DE ESTEVE
            If L - 2 > 0 Then
                K = Val(Mid(strnum, L - 2, 1))
                'CON ESTO FUNCIONARA BIEN EL 100100, POR EJEMPLO...
                If K = 1 Then 'PARCHE
                    If Val(strnum) = 100 Then 'PARCHE
                        K = 10 'PARCHE
                    End If 'PARCHE
                End If
                STRC = CENTENA(K) & " "
            End If
            '------
            If STRU = "UNO" And Left(STRB, 4) = " MIL" Then STRU = ""
            STRB = STRC & STRD & STRU & " " & STRB

            If (VEZ = 1 Or VEZ = 3) Then
                If STRN(VEZ + 1) <> "000" Then STRB = " MIL " & STRB
            End If
            If VEZ = 2 And MILLON Then
                If MILLONES Then
                    STRB = "MILLONES " & STRB
                Else
                    STRB = "UN MILLON " & STRB
                End If
            End If
        Next
        STRB = Trim(STRB)
        If Right(STRB, 3) = "UNO" Then
            STRB = Left(STRB, Len(STRB) - 1) & M_SEXO1 '"A"
        End If
        Do  'QUITAR LOS ESPACIOS DOBLES QUE HAYA POR MEDIO
            IA = InStr(STRB, "  ")
            If IA = 0 Then Exit Do
            STRB = Left(STRB, IA - 1) & Mid(STRB, IA + 1)
        Loop
        '
        If Left(STRB, 5 + M_LENSEXO1) = "UN" & M_SEXO1 & " UN" Then
            STRB = Mid(STRB, 4 + M_LENSEXO1)
        End If
        '---NUEVA COMPARACION                                     (01:16 25/ENE/99)
        If Left(STRB, 5) = "UN UN" Then
            STRB = Mid(STRB, 4)
        End If
        '
        ' COMPROBAR SOLO SI SE ESPECIFICA "UN* MIL ",                   (05/MAR/99)
        ' NO "UN* MIL" YA QUE PUEDE SER "UN* MILLON"
        'IF LEFT$(STRB, 6 + M_LENSEXO1) = "UN" & M_SEXO1 & " MIL" THEN
        If Left(STRB, 7 + M_LENSEXO1) = "UN" & M_SEXO1 & " MIL " Then
            STRB = Mid(STRB, 4 + M_LENSEXO1)
            ' PUEDE QUE EL IMPORTE SEA SOLO "UN MIL" O "UNA MIL"            (19/AGO/00)
        ElseIf STRB = "UN" & M_SEXO1 & " MIL" Then
            STRB = Mid(STRB, 4 + M_LENSEXO1)
        End If
        '
        '---NUEVA COMPARACION                                     (15:11 25/ENE/99)
        'IF LEFT$(STRB, 6) = "UN MIL" THEN
        ' QUE DEBE ESTAR ASÍ, PARA QUE NO QUITE "UN MILLON"             (05/MAR/99)
        If Left(STRB, 7) = "UN MIL " Then
            STRB = Mid(STRB, 4)
        End If
        '
        If Right(STRB, 15 + M_LENSEXO1) <> "MILLONES MIL UN" & M_SEXO1 Then
            IA = InStr(STRB, "MILLONES MIL UN" & M_SEXO1)
            If IA Then STRB = Left(STRB, IA + 8) & Mid(STRB, IA + 13)
        End If
        '---NUEVA COMPARACION                                   (15:13 25/ENE/99)
        If Right(STRB, 15) <> "MILLONES MIL UN" Then
            IA = InStr(STRB, "MILLONES MIL UN")
            If IA Then STRB = Left(STRB, IA + 8) & Mid(STRB, IA + 13)
        End If
        '
        ' DE ALGO SIRVE QUE LA GENTE PRUEBE LAS RUTINAS...              (05/MAR/99)
        ' ¡¡¡ GRACIAS GENTE !!!
        If MILLONES Then
            ' COMPROBACION DE -AS ??? MILLONES
            ' CONVERTIR EN -OS ??? MILLONES
            ' PERO SOLO SI EL SEXO ES FEMENINO
            If M_SEXO1 = "A" Then
                'IF (STRB LIKE "*AS * MILLONES*") THEN
                ' USAR UN BUCLE DO POR SI HAY VARIAS COINCIDENCIAS      (07/DIC/00)
                Do While (STRB Like "*AS * MILLONES*")
                    ' BUSCAR LA PRIMERA TERMINACION "AS " Y CAMBIAR POR "OS "
                    K = InStr(STRB, "AS ")
                    If K Then
                        Mid(STRB, K) = "OS "
                    End If
                Loop
                'END IF
                ' LA COMPARACION ANTERIOR NO FUNCIONA CON X00 MILLONES  (30/JUN/00)
                'IF (STRB LIKE "*AS MILLONES*") THEN
                ' USAR UN BUCLE DO POR SI HAY VARIAS COINCIDENCIAS      (07/DIC/00)
                Do While (STRB Like "*AS MILLONES*")
                    ' BUSCAR LA PRIMERA TERMINACION "AS " Y CAMBIAR POR "OS "
                    K = InStr(STRB, "AS MILLONES")
                    If K Then
                        Mid(STRB, K) = "OS MILLONES"
                    End If
                Loop
                'END IF
                '
                '
                '------------------------------------------------------------------
                ' COMPROBAR SI DICE ALGO ASÍ ...UNA MILLONES            (08/JUL/00)
                ' POR EJEMPLO EN 821.XXX.XXX DECIA OCHOCIENTOS VEINTIUNA MILLONES
                '------------------------------------------------------------------
                K = InStr(STRB, "UNA MILL")
                If K Then
                    STRB = Left(STRB, K + 1) & Mid(STRB, K + 3)
                End If
                '
                '
            End If
        End If
        '
        '
        '--------------------------------------------------------------------------
        ' CAMBIAR LOS VEINTIUN POR VEINTIUN, ETC POR SUS ACENTUADAS     (08/JUL/00)
        'Do
        '    K = InStr(STRB, "VEINTIUN ")
        '    If K Then
        '        Mid$(STRB, K) = "VEINTIUN "
        '    End If
        'Loop While K
        ' EL VEINTIDOS CREO QUE NUNCA LO HE ACENTUADO...                (08/JUL/00)
        ' PERO EN LA ENCICLOPEDIA CONSULTADA LO ACENTUA
        'Do
        '    K = InStr(STRB, "VEINTIDOS ")
        '    If K Then
        '        Mid$(STRB, K) = "VEINTIDOS "
        '    End If
        'Loop While K
        'Do
        '    K = InStr(STRB, "VEINTITRES ")
        '    If K Then
        '        Mid$(STRB, K) = "VEINTITRES "
        '    End If
        'Loop While K
        'Do
        '    K = InStr(STRB, "VEINTISEIS ")
        '    If K Then
        '        Mid$(STRB, K) = "VEINTISEIS "
        '    End If
        'Loop While K
        '--------------------------------------------------------------------------
        '
        '
        If Right(STRB, 6) = "CIENTO" Then
            STRB = Left(STRB, Len(STRB) - 2)
        End If
        If NEGATIVO Then STRB = "MENOS " & STRB

        UNNUMERO = Trim(STRB)

        ' RESTABLECER EL VALOR ANTERIOR
        M_SEXO1 = SEXO1ANT
        M_LENSEXO1 = Len(M_SEXO1)
    End Function

    Private Sub INICIALIZARARRAYS()
        'ASIGNAR LOS VALORES
        UNIDAD(1) = "UN" '& M_SEXO1
        UNIDAD(2) = "DOS"
        UNIDAD(3) = "TRES"
        UNIDAD(4) = "CUATRO"
        UNIDAD(5) = "CINCO"
        UNIDAD(6) = "SEIS"
        UNIDAD(7) = "SIETE"
        UNIDAD(8) = "OCHO"
        UNIDAD(9) = "NUEVE"
        '
        DECENA(1) = "DIEZ"
        DECENA(2) = "VEINTE"
        DECENA(3) = "TREINTA"
        DECENA(4) = "CUARENTA"
        DECENA(5) = "CINCUENTA"
        DECENA(6) = "SESENTA"
        DECENA(7) = "SETENTA"
        DECENA(8) = "OCHENTA"
        DECENA(9) = "NOVENTA"
        '
        CENTENA(1) = "CIENTO"
        CENTENA(2) = "DOSCIENT" & M_SEXO2
        CENTENA(3) = "TRESCIENT" & M_SEXO2
        CENTENA(4) = "CUATROCIENT" & M_SEXO2
        CENTENA(5) = "QUINIENT" & M_SEXO2
        CENTENA(6) = "SEISCIENT" & M_SEXO2
        CENTENA(7) = "SETECIENT" & M_SEXO2
        CENTENA(8) = "OCHOCIENT" & M_SEXO2
        CENTENA(9) = "NOVECIENT" & M_SEXO2
        CENTENA(10) = "CIEN" 'PARCHE
        '
        DECI(1) = "DIECI"
        DECI(2) = "VEINTI"
        DECI(3) = "TREINTA Y "
        DECI(4) = "CUARENTA Y "
        DECI(5) = "CINCUENTA Y "
        DECI(6) = "SESENTA Y "
        DECI(7) = "SETENTA Y "
        DECI(8) = "OCHENTA Y "
        DECI(9) = "NOVENTA Y "
        '
        OTROS(1) = "1"
        OTROS(2) = "2"
        OTROS(3) = "3"
        OTROS(4) = "4"
        OTROS(5) = "5"
        OTROS(6) = "6"
        OTROS(7) = "7"
        OTROS(8) = "8"
        OTROS(9) = "9"
        OTROS(10) = "10"
        OTROS(11) = "ONCE"
        OTROS(12) = "DOCE"
        OTROS(13) = "TRECE"
        OTROS(14) = "CATORCE"
        OTROS(15) = "QUINCE"
    End Sub

    'UPGRADE_NOTE: CLASS_INITIALIZE was upgraded to CLASS_INITIALIZE_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Initialize_Renamed()
        M_SEXO1 = "A"
        M_SEXO2 = "AS"
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub

    Public Function PLURALIZAR(ByVal SNUMERO As String, ByVal SMONEDA As String, Optional ByVal BCADAPALABRA As Boolean = False) As String
        '--------------------------------------------------------------------------
        ' PLURALIZA LA MONEDA, SI EL VALOR DE NUMERO ES DISTINTO DE UNO
        '
        ' AHORA ES UNA FUNCION PUBLICA                                  (07/JUL/00)
        '
        ' PARAMETROS:
        '   SNUMERO         IMPORTE, PARA SABER SI HAY QUE PLURALIZAR O NO
        '   SMONEDA         CADENA CON LA PALABRA A PLURALIZAR
        '   BCADAPALABRA    SI SE PLURALIZAN TODAS LAS PALABRAS         (08/JUL/00)
        '--------------------------------------------------------------------------
        Dim DBLTOTAL As Double
        Dim STMP As String
        Dim i As Double

        If Len(Trim(SMONEDA)) Then
            ' HE QUITADO EL VAL             (08/JUL/00)
            'DBLTOTAL = VAL(SNUMERO)
            '
            ' SI ENTRA UNA CADENA VACIA, DA ERROR                       (08/JUL/00)
            If Len(SNUMERO) = 0 Then
                SNUMERO = "0"
            End If
            DBLTOTAL = CDbl(SNUMERO)
            '
            If DBLTOTAL <> 1.0# Then
                SMONEDA = Trim(SMONEDA)
                ' SI SE PLURALIZAN TODAS LAS PALABRAS                   (08/JUL/00)
                If BCADAPALABRA Then
                    SMONEDA = SMONEDA & " "
                    STMP = ""
                    For i = 1 To Len(SMONEDA)
                        If Mid(SMONEDA, i, 1) = " " Then
                            ' PLURALIZAR
                            If InStr("AEIOU", Right(STMP, 1)) Then
                                STMP = STMP & "S"
                            Else
                                STMP = STMP & "ES"
                            End If
                        End If
                        STMP = STMP & Mid(SMONEDA, i, 1)
                    Next
                    SMONEDA = " " & Trim(STMP) & " "
                Else
                    If InStr("AEIOU", Right(SMONEDA, 1)) Then
                        SMONEDA = " " & SMONEDA & "S "
                    Else
                        SMONEDA = " " & SMONEDA & "ES "
                    End If
                End If
            End If
        End If
        PLURALIZAR = SMONEDA
    End Function

    Public Function CONVDECIMAL(ByVal strnum As String, Optional ByRef SDECIMAL As String = ",", Optional ByRef SDECIMALNO As String = ".") As String
        ' ASIGNA EL SIGNO DECIMAL ADECUADO (O LO INTENTA)               (10/ENE/99)
        ' DEVUELVE UNA CADENA CON EL SIGNO DECIMAL DEL SISTEMA
        Dim SNUMERO As String
        Dim i As Integer
        Dim J As Integer

        On Error Resume Next ' SI SE PRODUCE UN ERROR, CONTINUAR (07/JUL/00)

        ' AVERIGUAR EL SIGNO DECIMAL
        SNUMERO = Format(25.5, "#.#")
        If InStr(SNUMERO, ".") Then
            SDECIMAL = "."
            SDECIMALNO = ","
        Else
            SDECIMAL = ","
            SDECIMALNO = "."
        End If

        strnum = Trim(strnum)
        If Left(strnum, 1) = SDECIMALNO Then
            Mid(strnum, 1, 1) = SDECIMAL
        End If

        ' SI EL NUMERO INTRODUCIDO CONTIENE SIGNOS NO DECIMALES
        J = 0
        i = 1
        Do
            i = InStr(i, strnum, SDECIMALNO)
            If i Then
                J = J + 1
                i = i + 1
            End If
        Loop While i

        If J = 1 Then
            ' CAMBIAR ESE SÍMBOLO POR UN ESPACIO, SI SOLO HAY UNO DE ESOS SIGNOS
            i = InStr(strnum, SDECIMALNO)
            If i Then
                If InStr(strnum, SDECIMAL) Then
                    Mid(strnum, i, 1) = " "
                Else
                    Mid(strnum, i, 1) = SDECIMAL
                End If
            End If
        Else
            'EN CASO DE QUE TENGA MAS DE UNO DE ESTOS SÍMBOLOS
            'CONVERTIRLOS DE MANERA ADECUADA.
            'POR EJEMPLO:
            'SI EL SIGNO DECIMAL ES LA COMA:
            '   1,250.45 SERÍA 1.250,45 Y QUEDARÍA EN 1250,45
            'SI EL SIGNO DECIMAL ES EL PUNTO:
            '   1.250,45 SERÍA 1,250.45 Y QUEDARÍA EN 1250.45
            '
            'AUNQUE NO SE ARREGLARA UN NUMERO ERRONEO:
            'SI EL SIGNO DECIMAL ES LA COMA:
            '   1,250,45 SERA LO MISMO QUE 1,25
            '   12,500.25 SERA LO MISMO QUE 12,50
            'SI EL SIGNO DECIMAL ES EL PUNTO:
            '   1.250.45 SERA LO MISMO QUE 1.25
            '   12.500,25 SERA LO MISMO QUE 12.50
            '
            i = 1
            Do
                i = InStr(i, strnum, SDECIMALNO)
                If i Then
                    J = J - 1
                    If J = 0 Then
                        Mid(strnum, i, 1) = SDECIMAL
                    Else
                        Mid(strnum, i, 1) = " "
                    End If
                    i = i + 1
                End If
            Loop While i
        End If

        J = 0
        ' QUITAR LOS ESPACIOS QUE HAYA POR MEDIO
        Do
            i = InStr(strnum, " ")
            If i = 0 Then Exit Do
            strnum = Left(strnum, i - 1) & Mid(strnum, i + 1)
        Loop

        CONVDECIMAL = strnum

        Err.Clear()
    End Function
End Class