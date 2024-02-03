Option Explicit On
Imports ThoughtWorks.QRCode.Geom

Friend Class cComplementoINE11

    Private Const NombreClase As String = "cComplementoINE11"

    Private xmlns As String
    Private xmlnsine As String
    Private xsischemaLocation As String
    Private AnexoNodo As String

    Public Version As String
    Public TipoProceso As String
    Public TipoComite As String
    Public IdContabilidad As String

    Public Entidades As cINEEntidades

    Public ComplementoGenerado As Boolean

    Private _Complemento As MSXML2.IXMLDOMElement

    Public ReadOnly Property Complemento As MSXML2.IXMLDOMElement
        Get
            Return Me._Complemento
        End Get
    End Property

    Private Sub Class_Initialize_Renamed()
        Const sProcedure As String = "Class_Initialize_Renamed"
        Try
            Me.AnexoNodo = "ine:"

            Me.xmlns = "http://www.sat.gob.mx/ine"
            Me.xmlnsine = "http://www.sat.gob.mx/ine"
            Me.xsischemaLocation = "http://www.sat.gob.mx/ine http://www.sat.gob.mx/sitio_internet/cfd/ine/ine11.xsd"

            Me.Entidades = New cINEEntidades

            Me.ComplementoGenerado = False

        Catch ex As Exception
            HandleError(NombreClase, sProcedure, ex)
        End Try
    End Sub

    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub

    Public Function GenerarNodoComplementoINE() As Boolean
        Const sProcedure As String = "GenerarNodoComplementoINE"
        Dim bResultado As Boolean = False
        Dim mResultado As MSXML2.IXMLDOMElement

        Try
            Dim xmlDoc As New MSXML2.DOMDocument60

            xmlDoc.async = False
            xmlDoc.validateOnParse = False
            xmlDoc.resolveExternals = False
            xmlDoc.preserveWhiteSpace = True

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim NodoINE As MSXML2.IXMLDOMElement
            NodoINE = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "INE", xmlns)

            With NodoINE
                .setAttribute("xsi:schemaLocation", xsischemaLocation)
                '.setAttribute ("xmlns:ine", xmlnsine) 'Da lo mismo ponerlo o no, si se omite lo pone automáticamente al hacer Set NodoPagos =

                If txtLEN(Me.Version) = False Then
                    MsgBox("El valor de Version es un dato requerido.", vbExclamation, sProcedure) : Return False
                Else
                    .setAttribute("Version", Me.Version) 'required
                End If

                If txtLEN(Me.TipoProceso) = False Then
                    MsgBox("El valor de TipoProceso es un dato requerido.", vbExclamation, sProcedure) : Return False
                Else
                    .setAttribute("TipoProceso", Me.TipoProceso) 'required
                End If

                If txtLEN(Me.TipoComite) = True Then
                    .setAttribute("TipoComite", Me.TipoComite) 'optional
                End If

                If txtLEN(Me.IdContabilidad) = True Then
                    .setAttribute("IdContabilidad", Me.IdContabilidad) 'optional
                End If
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim i As Integer
            For i = 1 To CInt(Me.Entidades.Count)
                Dim NodoEntidad As MSXML2.IXMLDOMElement

                NodoEntidad = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Entidad", xmlns)

                With NodoEntidad
                    If txtLEN(Me.Entidades.Item(i).ClaveEntidad) = True Then
                        .setAttribute("ClaveEntidad", Me.Entidades.Item(i).ClaveEntidad)
                    Else
                        MsgBox("El valor de Entidad.ClaveEntidad es un dato requerido.", vbExclamation, sProcedure)
                        Return False
                    End If

                    If txtLEN(Me.Entidades.Item(i).Ambito) = True Then
                        .setAttribute("Ambito", Me.Entidades.Item(i).Ambito)
                    End If

                    If Me.Entidades.Item(i).Contabilidades.Count > 0 Then
                        For j = 1 To Me.Entidades.Item(i).Contabilidades.Count
                            Dim NodoContabilidad As MSXML2.IXMLDOMElement

                            NodoContabilidad = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Contabilidad", xmlns)

                            If txtLEN(Trim(Me.Entidades.Item(i).Contabilidades.Item(j).IdContabilidad)) = True Then
                                NodoContabilidad.setAttribute("IdContabilidad", Trim(Me.Entidades.Item(i).Contabilidades.Item(j).IdContabilidad)) 'required
                            Else
                                MsgBox("El valor de Entidad.Contabilidad.IdContabilidad es un dato requerido.", vbExclamation, sProcedure) : Return False
                            End If

                            NodoEntidad.appendChild(NodoContabilidad)
                        Next
                    End If
                End With

                If NodoEntidad.childNodes.length > 0 Then
                    NodoINE.appendChild(NodoEntidad)
                End If
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Me.ValidaComplementoINE() = True Then
                'MsgBox NodoPago.xml
                bResultado = True
                mResultado = NodoINE
                Me.ComplementoGenerado = True

                Me._Complemento = mResultado
            End If

        Catch ex As Exception
            HandleError(NombreClase, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidaComplementoINE() As Boolean
        Const sProcedure As String = "ValidaComplementoINE"
        Dim bResultado As Boolean = False

        Try

            '            3.1 Validaciones adicionales a realizar por el Proveedor

            'Elemento:   INE
            '---------------------------------------------------------------------------------
            'Atributos:

            'TipoProceso
            'Validar
            'Cuando en este atributo se seleccione el valor {Ordinario}:  
            '    Debe existir el atributo ine:TipoComite.
            'Cuando en este atributo se seleccione el valor {Precampaña} o el valor {Campaña}:  
            '    Se debe registrar al menos un elemento ineEntidad y en las entidades que se registren debe existir el atributo ine:Entidad:Ambito.
            '    No debe existir el atributo ine:TipoComite.
            'No debe existir el atributo ine: IdContabilidad

            'TipoComite
            'Validar
            'Cuando en este atributo se seleccione el valor {Ejecutivo Nacional}:  
            '    Puede existir el atributo ineIdContabilidad.
            '    No debe existir ningún elemento ine:Entidad.
            'Cuando en este atributo se seleccione el valor {Ejecutivo Estatal}:  
            '    No debe existir el atributo ineIdContabilidad
            '    Debe existir al menos un elemento ine:Entidad y en cada entidad que se registre no debe existir el atributo ine:Entidad :Ambito
            'Cuando en este atributo se seleccione el valor {Directivo Estatal}:  
            '    Puede existir el atributo ineIdContabilidad
            '    Debe existir al menos un elemento ine:Entidad y en cada entidad que se registre no debe existir el atributo ine:Entidad:Ambito


            'Elemento:   Entidad
            '---------------------------------------------------------------------------------
            'Atributos:

            'ClaveEntidad
            'Validar
            'La combinación del valor de este atributo con el valor del atributo ine:Entidad:Ambito, no se debe repetir en este complemento.

            'Ambito
            'Validar
            'Cuando en este atributo se seleccione el valor {Local}: 
            '    No se pueden seleccionar las claves NAC, CR1, CR2, CR3, CR4 y CR5 en el atributo ineEntidad : ClaveEntidad.

            Dim i As Integer

            Select Case Me.TipoProceso
                Case "Ordinario"
                    If txtLEN(Me.TipoComite) = False Then
                        MsgBox("ine:TipoProceso - Cuando en este atributo se seleccione el valor {Ordinario}:" & vbCrLf &
                                "Debe existir el atributo ine:TipoComite.", vbExclamation, sProcedure)
                        Return False
                    End If

                Case "Campaña", "Precampaña"
                    If Me.Entidades.Count = 0 Then
                        MsgBox("ine:TipoProceso - Cuando en este atributo se seleccione el valor {Precampaña} o el valor {Campaña}:" & vbCrLf &
                                "Se debe registrar al menos un elemento ine:Entidad y en las entidades que se registren debe existir el atributo ine:Entidad:Ambito.", vbExclamation, sProcedure)
                        Return False
                    Else
                        For i = 1 To Me.Entidades.Count
                            If txtLEN(Me.Entidades.Item(i).Ambito) = False Then
                                MsgBox("ine:TipoProceso - Cuando en este atributo se seleccione el valor {Precampaña} o el valor {Campaña}:" & vbCrLf &
                                        "Se debe registrar al menos un elemento ine:Entidad y en las entidades que se registren debe existir el atributo ine:Entidad:Ambito.", vbExclamation, sProcedure)
                                Return False
                            End If
                        Next
                    End If

                    If txtLEN(Me.TipoComite) = True Then
                        MsgBox("ine:TipoProceso - Cuando en este atributo se seleccione el valor {Precampaña} o el valor {Campaña}:" & vbCrLf &
                                "No debe existir el atributo ine:TipoComite.", vbExclamation, sProcedure)
                        Return False
                    End If

                    If txtLEN(Me.IdContabilidad) = True Then
                        MsgBox("ine:TipoProceso - Cuando en este atributo se seleccione el valor {Precampaña} o el valor {Campaña}:" & vbCrLf &
                                "No debe existir el atributo ine:IdContabilidad.", vbExclamation, sProcedure)
                        Return False
                    End If
            End Select

            Select Case Me.TipoComite
                Case "Ejecutivo Nacional"
                    If Me.Entidades.Count > 0 Then
                        MsgBox("ine:TipoComite - Cuando en este atributo se seleccione el valor {Ejecutivo Nacional}:" & vbCrLf &
                                "No debe existir ningún elemento ine:Entidad.", vbExclamation, sProcedure)
                        Return False
                    End If

                Case "Ejecutivo Estatal", "Directivo Estatal"
                    If Me.TipoComite = "Ejecutivo Estatal" Then
                        If txtLEN(Me.IdContabilidad) = True Then
                            MsgBox("ine:TipoComite - Cuando en este atributo se seleccione el valor {Ejecutivo Estatal}:" & vbCrLf &
                                    "No debe existir el atributo ine:IdContabilidad.", vbExclamation, sProcedure)
                            Return False
                        End If
                    Else
                        If Me.Entidades.Count = 0 Then
                            MsgBox("ine:TipoComite - Cuando en este atributo se seleccione el valor {Ejecutivo Estatal} o {Directivo Estatal}:" & vbCrLf &
                                    "Debe existir al menos un elemento ine:Entidad y en cada entidad que se registre no debe existir el atributo ine:Entidad:Ambito.", vbExclamation, sProcedure)
                            Return False
                        Else
                            For i = 1 To Me.Entidades.Count
                                If txtLEN(Me.Entidades.Item(i).Ambito) = True Then
                                    MsgBox("ine:TipoComite - Cuando en este atributo se seleccione el valor {Ejecutivo Estatal}:" & vbCrLf &
                                            "Debe existir al menos un elemento ine:Entidad y en cada entidad que se registre no debe existir el atributo ine:Entidad:Ambito", vbExclamation, sProcedure)
                                    Return False
                                End If
                            Next
                        End If
                    End If
            End Select

            For i = 1 To Me.Entidades.Count
                Dim sClaveEntidadAnterior As String = Me.Entidades.Item(i).ClaveEntidad
                Dim sAmbito As String = Me.Entidades.Item(i).Ambito

                For j = i + 1 To Me.Entidades.Count
                    If Me.Entidades.Item(j).ClaveEntidad = sClaveEntidadAnterior AndAlso Me.Entidades.Item(i).Ambito = sAmbito Then
                        MsgBox("ine:Entidad:ClaveEntidad" & vbCrLf &
                                "La combinación del valor de este atributo con el valor del atributo ine:Entidad:Ambito, no se debe repetir en este complemento.", vbExclamation, sProcedure)
                        Return False
                    End If
                Next

                If Me.Entidades.Item(i).Ambito = "Local" Then
                    If Me.Entidades.Item(i).ClaveEntidad = "NAC" Or Me.Entidades.Item(i).ClaveEntidad = "CR1" Or Me.Entidades.Item(i).ClaveEntidad = "CR2" Or
                       Me.Entidades.Item(i).ClaveEntidad = "CR3" Or Me.Entidades.Item(i).ClaveEntidad = "CR4" Or Me.Entidades.Item(i).ClaveEntidad = "CR5" Then
                        MsgBox("ine:Entidad:Ambito - Cuando en este atributo se seleccione el valor {Local}:" & vbCrLf &
                                "No se pueden seleccionar las claves NAC, CR1, CR2, CR3, CR4 y CR5 en el atributo ine:Entidad:ClaveEntidad.", vbExclamation, sProcedure)
                        Return False
                    End If
                    'Dim nombres() As String = {"NAC", "CR1", "CR2", "CR3", "CR4", "CR5"}
                    'If nombres.Any(Function(x) x = Me.Entidades.Item(i).ClaveEntidad) = False Then
                    '    MsgBox("ine:Entidad:Ambito - Cuando en este atributo se seleccione el valor {Local}:" & vbCrLf &
                    '            "No se pueden seleccionar las claves NAC, CR1, CR2, CR3, CR4 y CR5 en el atributo ine:Entidad:ClaveEntidad.", vbExclamation, sProcedure)
                    '    Return False
                    'End If
                End If
            Next

            bResultado = True
        Catch ex As Exception
            HandleError(NombreClase, sProcedure, ex)
        End Try

        Return bResultado
    End Function
End Class
