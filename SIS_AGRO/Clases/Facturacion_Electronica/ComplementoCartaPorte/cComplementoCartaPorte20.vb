Option Explicit On

Friend Class cComplementoCartaPorte20

    Private Const NombreClase As String = "cComplementoCartaPorte20"

#Region "Atributos y Nodos"
    Public Version As String
    Public TranspInternac As String
    Public EntradaSalidaMerc As String
    Public PaisOrigenDestino As String
    Public ViaEntradaSalida As String
    Public TotalDistRec As String

    Public Ubicaciones As cCCPUbicaciones
    Public Mercancias As cCCPMercancias
    Public FiguraTransporte As cCCPFiguraTransporte
#End Region

    Private xmlns As String
    Private xmlnsCartaPorte20 As String
    Private xsischemaLocation As String
    Private AnexoNodo As String

    Public ValoresComplementoCargados As Boolean = False
    Public ComplementoGenerado As Boolean
    Public Complemento As MSXML2.IXMLDOMElement

#Region "Métodos y procedimientos"
    Public Sub New()
        AnexoNodo = "cartaporte20:"

        xmlns = "http://www.sat.gob.mx/CartaPorte20"
        xmlnsCartaPorte20 = "http://www.sat.gob.mx/CartaPorte20"
        xsischemaLocation = "http://www.sat.gob.mx/CartaPorte20 http://www.sat.gob.mx/sitio_internet/cfd/CartaPorte/CartaPorte20.xsd"

        Me.Ubicaciones = New cCCPUbicaciones
        Me.Mercancias = New cCCPMercancias
        Me.FiguraTransporte = New cCCPFiguraTransporte
    End Sub

    Public Function GenerarNodoComplementoCartaPorte20() As Boolean
        Const sProcedure As String = "GenerarNodoComplementoCartaPorte20"
        Dim bResultado As Boolean = False
        'Dim mResultado As MSXML2.IXMLDOMElement

        Try
            Dim xmlDoc As New MSXML2.DOMDocument60

            xmlDoc.async = False
            xmlDoc.validateOnParse = False
            xmlDoc.resolveExternals = False
            xmlDoc.preserveWhiteSpace = True

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim NodoCartaPorte As MSXML2.IXMLDOMElement
            NodoCartaPorte = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "CartaPorte", xmlns)

            With NodoCartaPorte
                .setAttribute("xsi:schemaLocation", xsischemaLocation)
                '.setAttribute ("xmlns:cartaporte20", xmlnsCartaPorte20 'Da lo mismo ponerlo o no, si se omite lo pone automáticamente al hacer Set NodoPagos =

                If txtLEN(Me.Version) = False Then
                    MsgBox("El valor de Version es un dato requerido.", vbExclamation, sProcedure) : Return False
                Else
                    .setAttribute("Version", Me.Version) 'required
                End If

                If txtLEN(Me.TranspInternac) = False Then
                    MsgBox("El valor de TranspInternac es un dato requerido.", vbExclamation, sProcedure) : Return False
                Else
                    .setAttribute("TranspInternac", Me.TranspInternac) 'required
                End If

                If txtLEN(Me.EntradaSalidaMerc) = True Then
                    .setAttribute("EntradaSalidaMerc", Me.EntradaSalidaMerc) 'optional
                End If

                If txtLEN(Me.PaisOrigenDestino) = True Then
                    .setAttribute("PaisOrigenDestino", Me.PaisOrigenDestino) 'optional
                End If

                If txtLEN(Me.ViaEntradaSalida) = True Then
                    .setAttribute("ViaEntradaSalida", Me.ViaEntradaSalida) 'optional
                End If

                If txtLEN(Me.TotalDistRec) = True Then
                    .setAttribute("TotalDistRec", Me.TotalDistRec) 'optional
                End If
            End With
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim NodoUbicaciones As MSXML2.IXMLDOMElement 'Nodo requerido
            NodoUbicaciones = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Ubicaciones", xmlns)

            Dim i As Integer, j As Integer
            For i = 1 To Me.Ubicaciones.Count
                Dim NodoUbicacion As MSXML2.IXMLDOMElement 'Nodo requerido '[2..*]
                NodoUbicacion = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Ubicacion", xmlns)

                With NodoUbicacion
                    If txtLEN(Me.Ubicaciones.Item(i).TipoUbicacion) = True Then
                        .setAttribute("TipoUbicacion", Me.Ubicaciones.Item(i).TipoUbicacion) 'required
                    Else
                        MsgBox("El valor de Ubicacion.TipoUbicacion es un dato requerido.", vbExclamation, sProcedure) : Return False
                    End If

                    If txtLEN(Me.Ubicaciones.Item(i).IDUbicacion) = True Then
                        .setAttribute("IDUbicacion", Me.Ubicaciones.Item(i).IDUbicacion) 'optional
                    End If

                    If txtLEN(Me.Ubicaciones.Item(i).RFCRemitenteDestinatario) = True Then
                        .setAttribute("RFCRemitenteDestinatario", Me.Ubicaciones.Item(i).RFCRemitenteDestinatario) 'required
                    Else
                        MsgBox("El valor de Ubicacion.RFCRemitenteDestinatario es un dato requerido.", vbExclamation, sProcedure) : Return False
                    End If

                    If txtLEN(Me.Ubicaciones.Item(i).NombreRemitenteDestinatario) = True Then
                        .setAttribute("NombreRemitenteDestinatario", Me.Ubicaciones.Item(i).NombreRemitenteDestinatario) 'optional
                    End If

                    If txtLEN(Me.Ubicaciones.Item(i).NumRegIdTrib) = True Then
                        .setAttribute("NumRegIdTrib", Me.Ubicaciones.Item(i).NumRegIdTrib) 'optional
                    End If

                    If txtLEN(Me.Ubicaciones.Item(i).ResidenciaFiscal) = True Then
                        .setAttribute("ResidenciaFiscal", Me.Ubicaciones.Item(i).ResidenciaFiscal) 'optional
                    End If

                    If txtLEN(Me.Ubicaciones.Item(i).NumEstacion) = True Then
                        .setAttribute("NumEstacion", Me.Ubicaciones.Item(i).NumEstacion) 'optional
                    End If

                    If txtLEN(Me.Ubicaciones.Item(i).NombreEstacion) = True Then
                        .setAttribute("NombreEstacion", Me.Ubicaciones.Item(i).NombreEstacion) 'optional
                    End If

                    If txtLEN(Me.Ubicaciones.Item(i).NavegacionTrafico) = True Then
                        .setAttribute("NavegacionTrafico", Me.Ubicaciones.Item(i).NavegacionTrafico) 'optional
                    End If

                    If txtLEN(Me.Ubicaciones.Item(i).FechaHoraSalidaLlegada) = True Then
                        .setAttribute("FechaHoraSalidaLlegada", Me.Ubicaciones.Item(i).FechaHoraSalidaLlegada) 'required
                    Else
                        MsgBox("El valor de Ubicacion.FechaHoraSalidaLlegada es un dato requerido.", vbExclamation, sProcedure) : Return False
                    End If

                    If txtLEN(Me.Ubicaciones.Item(i).TipoEstacion) = True Then
                        .setAttribute("TipoEstacion", Me.Ubicaciones.Item(i).TipoEstacion) 'optional
                    End If

                    If valorNumericoD(Me.Ubicaciones.Item(i).DistanciaRecorrida) > 0 Then
                        .setAttribute("DistanciaRecorrida", Me.Ubicaciones.Item(i).DistanciaRecorrida) 'optional
                    End If
                End With

                'If Me.Ubicaciones.Item(i).bTieneDomicilio = True Then
                Dim NodoUbicacionDomicilio As MSXML2.IXMLDOMElement 'Nodo condicional
                NodoUbicacionDomicilio = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Domicilio", xmlns)

                With NodoUbicacionDomicilio
                    If txtLEN(Me.Ubicaciones.Item(i).Domicilio.Calle) = True Then
                        .setAttribute("Calle", Me.Ubicaciones.Item(i).Domicilio.Calle)  'optional
                    End If

                    If txtLEN(Me.Ubicaciones.Item(i).Domicilio.NumeroExterior) = True Then
                        .setAttribute("NumeroExterior", Me.Ubicaciones.Item(i).Domicilio.NumeroExterior) 'optional
                    End If

                    If txtLEN(Me.Ubicaciones.Item(i).Domicilio.NumeroInterior) = True Then
                        .setAttribute("NumeroInterior", Me.Ubicaciones.Item(i).Domicilio.NumeroInterior)  'optional
                    End If

                    If txtLEN(Me.Ubicaciones.Item(i).Domicilio.Colonia) = True Then
                        .setAttribute("Colonia", Me.Ubicaciones.Item(i).Domicilio.Colonia) 'optional
                    End If

                    If txtLEN(Me.Ubicaciones.Item(i).Domicilio.Localidad) = True Then
                        .setAttribute("Localidad", Me.Ubicaciones.Item(i).Domicilio.Localidad) 'optional
                    End If

                    If txtLEN(Me.Ubicaciones.Item(i).Domicilio.Referencia) = True Then
                        .setAttribute("Referencia", Me.Ubicaciones.Item(i).Domicilio.Referencia)  'optional
                    End If

                    If txtLEN(Me.Ubicaciones.Item(i).Domicilio.Municipio) = True Then
                        .setAttribute("Municipio", Me.Ubicaciones.Item(i).Domicilio.Municipio) 'optional
                    End If

                    If txtLEN(Me.Ubicaciones.Item(i).Domicilio.Estado) = True Then
                        .setAttribute("Estado", Me.Ubicaciones.Item(i).Domicilio.Estado) 'required
                    Else
                        MsgBox("El valor de Ubicacion.Domicilio.Estado es un dato requerido.", vbExclamation, sProcedure) : Return False
                    End If

                    If txtLEN(Me.Ubicaciones.Item(i).Domicilio.Pais) = True Then
                        .setAttribute("Pais", Me.Ubicaciones.Item(i).Domicilio.Pais) 'required
                    Else
                        MsgBox("El valor de Ubicacion.Domicilio.Pais es un dato requerido.", vbExclamation, sProcedure) : Return False
                    End If

                    If txtLEN(Me.Ubicaciones.Item(i).Domicilio.CodigoPostal) = True Then
                        .setAttribute("CodigoPostal", Me.Ubicaciones.Item(i).Domicilio.CodigoPostal) 'required
                    Else
                        MsgBox("El valor de Ubicacion.Domicilio.CodigoPostal es un dato requerido.", vbExclamation, sProcedure) : Return False
                    End If
                End With

                NodoUbicacion.appendChild(NodoUbicacionDomicilio)

                'End If

                NodoUbicaciones.appendChild(NodoUbicacion)
            Next

            NodoCartaPorte.appendChild(NodoUbicaciones)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim NodoMercancias As MSXML2.IXMLDOMElement 'Nodo requerido
            NodoMercancias = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Mercancias", xmlns)

            With NodoMercancias
                If txtLEN(Me.Mercancias.PesoBrutoTotal) = True Then
                    .setAttribute("PesoBrutoTotal", Me.Mercancias.PesoBrutoTotal) 'required
                Else
                    MsgBox("El valor de Mercancias.PesoBrutoTotal es un dato requerido.", vbExclamation, sProcedure) : Return False
                End If

                If txtLEN(Me.Mercancias.UnidadPeso) = True Then
                    .setAttribute("UnidadPeso", Me.Mercancias.UnidadPeso) 'required
                Else
                    MsgBox("El valor de Mercancias.UnidadPeso es un dato requerido.", vbExclamation, sProcedure) : Return False
                End If

                If txtLEN(Me.Mercancias.PesoNetoTotal) = True Then
                    .setAttribute("PesoNetoTotal", Me.Mercancias.PesoNetoTotal) 'optional
                End If

                If txtLEN(Me.Mercancias.NumTotalMercancias) = True Then
                    .setAttribute("NumTotalMercancias", Me.Mercancias.NumTotalMercancias) 'required
                Else
                    MsgBox("El valor de Mercancias.NumTotalMercancias es un dato requerido.", vbExclamation, sProcedure) : Return False
                End If

                If txtLEN(Me.Mercancias.CargoPorTasacion) = True Then
                    .setAttribute("CargoPorTasacion", Me.Mercancias.CargoPorTasacion) 'optional
                End If

            End With

            For i = 1 To CInt(Me.Mercancias.Count)
                Dim NodoMercancia As MSXML2.IXMLDOMElement 'Nodo requerido '[1..*]
                NodoMercancia = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Mercancia", xmlns)

                With NodoMercancia
                    If txtLEN(Me.Mercancias.Item(i).BienesTransp) = True Then
                        .setAttribute("BienesTransp", Me.Mercancias.Item(i).BienesTransp) 'required
                    Else
                        MsgBox("El valor de Mercancia.BienesTransp es un dato requerido.", vbExclamation, sProcedure) : Return False
                    End If

                    If txtLEN(Me.Mercancias.Item(i).ClaveSTCC) = True Then
                        .setAttribute("ClaveSTCC", Me.Mercancias.Item(i).ClaveSTCC) 'optional
                    End If

                    If txtLEN(Me.Mercancias.Item(i).Descripcion) = True Then
                        .setAttribute("Descripcion", Me.Mercancias.Item(i).Descripcion) 'required
                    Else
                        MsgBox("El valor de Mercancia.Descripcion es un dato requerido.", vbExclamation, sProcedure) : Return False
                    End If

                    If txtLEN(Me.Mercancias.Item(i).Cantidad) = True Then
                        .setAttribute("Cantidad", Me.Mercancias.Item(i).Cantidad) 'required
                    Else
                        MsgBox("El valor de Mercancia.Cantidad es un dato requerido.", vbExclamation, sProcedure) : Return False
                    End If

                    If txtLEN(Me.Mercancias.Item(i).ClaveUnidad) = True Then
                        .setAttribute("ClaveUnidad", Me.Mercancias.Item(i).ClaveUnidad) 'required
                    Else
                        MsgBox("El valor de Mercancia.ClaveUnidad es un dato requerido.", vbExclamation, sProcedure) : Return False
                    End If

                    If txtLEN(Me.Mercancias.Item(i).Unidad) = True Then
                        .setAttribute("Unidad", Me.Mercancias.Item(i).Unidad) 'optional
                    End If

                    If txtLEN(Me.Mercancias.Item(i).Dimensiones) = True Then
                        .setAttribute("Dimensiones", Me.Mercancias.Item(i).Dimensiones) 'optional
                    End If

                    If txtLEN(Me.Mercancias.Item(i).MaterialPeligroso) = True Then
                        .setAttribute("MaterialPeligroso", Me.Mercancias.Item(i).MaterialPeligroso) 'optional
                    End If

                    If txtLEN(Me.Mercancias.Item(i).CveMaterialPeligroso) = True Then
                        .setAttribute("CveMaterialPeligroso", Me.Mercancias.Item(i).CveMaterialPeligroso) 'optional
                    End If

                    If txtLEN(Me.Mercancias.Item(i).Embalaje) = True Then
                        .setAttribute("Embalaje", Me.Mercancias.Item(i).Embalaje) 'optional
                    End If

                    If txtLEN(Me.Mercancias.Item(i).DescripEmbalaje) = True Then
                        .setAttribute("DescripEmbalaje", Me.Mercancias.Item(i).DescripEmbalaje) 'optional
                    End If

                    If txtLEN(Me.Mercancias.Item(i).PesoEnKg) = True Then
                        .setAttribute("PesoEnKg", Me.Mercancias.Item(i).PesoEnKg) 'required
                    Else
                        MsgBox("El valor de Mercancia.PesoEnKg es un dato requerido.", vbExclamation, sProcedure) : Return False
                    End If

                    If txtLEN(Me.Mercancias.Item(i).ValorMercancia) = True Then
                        .setAttribute("ValorMercancia", Me.Mercancias.Item(i).ValorMercancia) 'optional
                    End If

                    If txtLEN(Me.Mercancias.Item(i).Moneda) = True Then
                        .setAttribute("Moneda", Me.Mercancias.Item(i).Moneda) 'optional
                    End If

                    If txtLEN(Me.Mercancias.Item(i).FraccionArancelaria) = True Then
                        .setAttribute("FraccionArancelaria", Me.Mercancias.Item(i).FraccionArancelaria) 'optional
                    End If

                    If txtLEN(Me.Mercancias.Item(i).UUIDComercioExt) = True Then
                        .setAttribute("UUIDComercioExt", Me.Mercancias.Item(i).UUIDComercioExt) 'optional
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim NodoPedimentos As MSXML2.IXMLDOMElement 'Mercancia.Pedimentos 'Nodo condicional [0..*]

                    For j = 1 To CInt(Me.Mercancias.Item(i).Pedimentos.Count)
                        NodoPedimentos = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Pedimentos", xmlns)

                        If txtLEN(Me.Mercancias.Item(i).Pedimentos.Item(j).Pedimento) = True Then
                            NodoPedimentos.setAttribute("Pedimento", Me.Mercancias.Item(i).Pedimentos.Item(j).Pedimento) 'required
                        Else
                            MsgBox("El valor de Mercancia.Pedimentos.Pedimento es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        NodoMercancia.appendChild(NodoPedimentos)
                    Next
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim NodoGuiasIdentificacion As MSXML2.IXMLDOMElement 'Mercancia.GuiasIdentificacion '[0..*]

                    For j = 1 To CInt(Me.Mercancias.Item(i).GuiasIdentificacion.Count)
                        NodoGuiasIdentificacion = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "GuiasIdentificacion", xmlns)

                        If txtLEN(Me.Mercancias.Item(i).GuiasIdentificacion.Item(j).NumeroGuiaIdentificacion) = True Then
                            NodoGuiasIdentificacion.setAttribute("NumeroGuiaIdentificacion", Me.Mercancias.Item(i).GuiasIdentificacion.Item(j).NumeroGuiaIdentificacion) 'required
                        Else
                            MsgBox("El valor de Mercancia.GuiasIdentificacion.NumeroGuiaIdentificacion es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Me.Mercancias.Item(i).GuiasIdentificacion.Item(j).DescripGuiaIdentificacion) = True Then
                            NodoGuiasIdentificacion.setAttribute("DescripGuiaIdentificacion", Me.Mercancias.Item(i).GuiasIdentificacion.Item(j).DescripGuiaIdentificacion)  'required
                        Else
                            MsgBox("El valor de Mercancia.GuiasIdentificacion.DescripGuiaIdentificacion es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Me.Mercancias.Item(i).GuiasIdentificacion.Item(j).PesoGuiaIdentificacion) = True Then
                            NodoGuiasIdentificacion.setAttribute("PesoGuiaIdentificacion", Me.Mercancias.Item(i).GuiasIdentificacion.Item(j).PesoGuiaIdentificacion)  'required
                        Else
                            MsgBox("El valor de Mercancia.GuiasIdentificacion.PesoGuiaIdentificacion es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        NodoMercancia.appendChild(NodoGuiasIdentificacion)
                    Next
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim NodoCantidadTransporta As MSXML2.IXMLDOMElement 'Mercancia.CantidadTrasporta '[0..*]

                    For j = 1 To CInt(Me.Mercancias.Item(i).CantidadesTransporta.Count)
                        NodoCantidadTransporta = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "CantidadTransporta", xmlns)

                        If txtLEN(Me.Mercancias.Item(i).CantidadesTransporta.Item(j).Cantidad) = True Then
                            NodoCantidadTransporta.setAttribute("Cantidad", Me.Mercancias.Item(i).CantidadesTransporta.Item(j).Cantidad) 'required
                        Else
                            MsgBox("El valor de Mercancia.CantidadesTransporta.Cantidad es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Me.Mercancias.Item(i).CantidadesTransporta.Item(j).IDOrigen) = True Then
                            NodoCantidadTransporta.setAttribute("IDOrigen", Me.Mercancias.Item(i).CantidadesTransporta.Item(j).IDOrigen) 'required
                        Else
                            MsgBox("El valor de Mercancia.CantidadesTransporta.IDOrigen es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Me.Mercancias.Item(i).CantidadesTransporta.Item(j).IDDestino) = True Then
                            NodoCantidadTransporta.setAttribute("IDDestino", Me.Mercancias.Item(i).CantidadesTransporta.Item(j).IDDestino)  'required
                        Else
                            MsgBox("El valor de Mercancia.CantidadesTransporta.IDDestino es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Me.Mercancias.Item(i).CantidadesTransporta.Item(j).CvesTransporte) = True Then
                            NodoCantidadTransporta.setAttribute("CvesTransporte", Me.Mercancias.Item(i).CantidadesTransporta.Item(j).CvesTransporte) 'optional
                        End If

                        NodoMercancia.appendChild(NodoCantidadTransporta)
                    Next
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim NodoDetalleMercancia As MSXML2.IXMLDOMElement 'Mercancia.DetalleMercancia '[0..1]

                    If Me.Mercancias.Item(i).bTieneDetalleMercancia = True Then
                        NodoDetalleMercancia = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "DetalleMercancia", xmlns)

                        If txtLEN(Me.Mercancias.Item(i).DetalleMercancia.UnidadPesoMerc) = True Then
                            NodoDetalleMercancia.setAttribute("UnidadPesoMerc", Me.Mercancias.Item(i).DetalleMercancia.UnidadPesoMerc) 'required
                        Else
                            MsgBox("El valor de Mercancia.DetalleMercancia.UnidadPesoMerc es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Me.Mercancias.Item(i).DetalleMercancia.PesoBruto) = True Then
                            NodoDetalleMercancia.setAttribute("PesoBruto", Me.Mercancias.Item(i).DetalleMercancia.PesoBruto) 'required
                        Else
                            MsgBox("El valor de Mercancia.DetalleMercancia.PesoBruto es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Me.Mercancias.Item(i).DetalleMercancia.PesoNeto) = True Then
                            NodoDetalleMercancia.setAttribute("PesoNeto", Me.Mercancias.Item(i).DetalleMercancia.PesoNeto) 'required
                        Else
                            MsgBox("El valor de Mercancia.DetalleMercancia.PesoNeto es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Me.Mercancias.Item(i).DetalleMercancia.PesoTara) = True Then
                            NodoDetalleMercancia.setAttribute("PesoTara", Me.Mercancias.Item(i).DetalleMercancia.PesoTara)  'required
                        Else
                            MsgBox("El valor de Mercancia.DetalleMercancia.PesoTara es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Me.Mercancias.Item(i).DetalleMercancia.UnidadPesoMerc) = True Then
                            NodoDetalleMercancia.setAttribute("UnidadPesoMerc", Me.Mercancias.Item(i).DetalleMercancia.UnidadPesoMerc)  'optional
                        End If

                        NodoMercancia.appendChild(NodoDetalleMercancia)
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    NodoMercancias.appendChild(NodoMercancia)
                End With
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim NodoAutotransporte As MSXML2.IXMLDOMElement 'Nodo condicional '[0..1]

            'If Me.Mercancias.bTieneAutotransporte = True Then
            NodoAutotransporte = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Autotransporte", xmlns)

            If txtLEN(Me.Mercancias.Autotransporte.PermSCT) = True Then
                NodoAutotransporte.setAttribute("PermSCT", Me.Mercancias.Autotransporte.PermSCT) 'required
            Else
                MsgBox("El valor de Mercancias.Autotransporte.PermSCT es un dato requerido.", vbExclamation, sProcedure) : Return False
            End If

            If txtLEN(Me.Mercancias.Autotransporte.NumPermisoSCT) = True Then
                NodoAutotransporte.setAttribute("NumPermisoSCT", Me.Mercancias.Autotransporte.NumPermisoSCT) 'required
            Else
                MsgBox("El valor de Mercancias.Autotransporte.NumPermisoSCT es un dato requerido.", vbExclamation, sProcedure) : Return False
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim NodoIdentificacionVehicular As MSXML2.IXMLDOMElement 'Nodo requerido
            NodoIdentificacionVehicular = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "IdentificacionVehicular", xmlns)

            If txtLEN(Me.Mercancias.Autotransporte.IdentificacionVehicular.ConfigVehicular) = True Then
                NodoIdentificacionVehicular.setAttribute("ConfigVehicular", Me.Mercancias.Autotransporte.IdentificacionVehicular.ConfigVehicular) 'required
            Else
                MsgBox("El valor de Mercancias.Autotransporte.IdentificacionVehicular.ConfigVehicular es un dato requerido.", vbExclamation, sProcedure) : Return False
            End If

            If txtLEN(Me.Mercancias.Autotransporte.IdentificacionVehicular.PlacaVM) = True Then
                NodoIdentificacionVehicular.setAttribute("PlacaVM", Me.Mercancias.Autotransporte.IdentificacionVehicular.PlacaVM) 'required
            Else
                MsgBox("El valor de Mercancias.Autotransporte.IdentificacionVehicular.PlacaVM es un dato requerido.", vbExclamation, sProcedure) : Return False
            End If

            If txtLEN(Me.Mercancias.Autotransporte.IdentificacionVehicular.AnioModeloVM) = True Then
                NodoIdentificacionVehicular.setAttribute("AnioModeloVM", Me.Mercancias.Autotransporte.IdentificacionVehicular.AnioModeloVM) 'required
            Else
                MsgBox("El valor de Mercancias.Autotransporte.IdentificacionVehicular.AnioModeloVM es un dato requerido.", vbExclamation, sProcedure) : Return False
            End If

            NodoAutotransporte.appendChild(NodoIdentificacionVehicular)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim NodoSeguros As MSXML2.IXMLDOMElement 'Nodo requerido
            NodoSeguros = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Seguros", xmlns)

            If txtLEN(Me.Mercancias.Autotransporte.Seguros.AseguraRespCivil) = True Then
                NodoSeguros.setAttribute("AseguraRespCivil", Me.Mercancias.Autotransporte.Seguros.AseguraRespCivil) 'required
            Else
                MsgBox("El valor de Mercancias.Autotransporte.Seguros.AseguraRespCivil es un dato requerido.", vbExclamation, sProcedure) : Return False
            End If

            If txtLEN(Me.Mercancias.Autotransporte.Seguros.PolizaRespCivil) = True Then
                NodoSeguros.setAttribute("PolizaRespCivil", Me.Mercancias.Autotransporte.Seguros.PolizaRespCivil)  'required
            Else
                MsgBox("El valor de Mercancias.Autotransporte.Seguros.PolizaRespCivil es un dato requerido.", vbExclamation, sProcedure) : Return False
            End If

            If txtLEN(Me.Mercancias.Autotransporte.Seguros.AseguraMedAmbiente) = True Then
                NodoSeguros.setAttribute("AseguraMedAmbiente", Me.Mercancias.Autotransporte.Seguros.AseguraMedAmbiente) 'optional
            End If

            If txtLEN(Me.Mercancias.Autotransporte.Seguros.PolizaMedAmbiente) = True Then
                NodoSeguros.setAttribute("PolizaMedAmbiente", Me.Mercancias.Autotransporte.Seguros.PolizaMedAmbiente) 'optional
            End If

            If txtLEN(Me.Mercancias.Autotransporte.Seguros.AseguraCarga) = True Then
                NodoSeguros.setAttribute("AseguraCarga", Me.Mercancias.Autotransporte.Seguros.AseguraCarga) 'optional
            End If

            If txtLEN(Me.Mercancias.Autotransporte.Seguros.PolizaCarga) = True Then
                NodoSeguros.setAttribute("PolizaCarga", Me.Mercancias.Autotransporte.Seguros.PolizaCarga) 'optional
            End If

            If txtLEN(Me.Mercancias.Autotransporte.Seguros.PrimaSeguro) = True Then
                NodoSeguros.setAttribute("PrimaSeguro", Me.Mercancias.Autotransporte.Seguros.PrimaSeguro) 'optional
            End If

            NodoAutotransporte.appendChild(NodoSeguros)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim NodoRemolques As MSXML2.IXMLDOMElement 'Nodo Remolques '[0..1]
            NodoRemolques = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Remolques", xmlns)

            If Me.Mercancias.Autotransporte.Remolques.Count > 0 Then
                Dim NodoRemolque As MSXML2.IXMLDOMElement 'Nodo requerido '[1..*]
                NodoRemolque = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Remolque", xmlns)

                For i = 1 To CInt(Me.Mercancias.Autotransporte.Remolques.Count)
                    If txtLEN(Me.Mercancias.Autotransporte.Remolques.Item(i).SubTipoRem) = True Then
                        NodoRemolque.setAttribute("SubTipoRem", Me.Mercancias.Autotransporte.Remolques.Item(j).SubTipoRem)  'required
                    Else
                        MsgBox("El valor de Mercancias.Autotransporte.Remolques.SubTipoRem es un dato requerido.", vbExclamation, sProcedure) : Return False
                    End If

                    If txtLEN(Me.Mercancias.Autotransporte.Remolques.Item(i).Placa) = True Then
                        NodoRemolque.setAttribute("Placa", Me.Mercancias.Autotransporte.Remolques.Item(j).Placa)  'required
                    Else
                        MsgBox("El valor de Mercancias.Autotransporte.Remolques.Placa es un dato requerido.", vbExclamation, sProcedure) : Return False
                    End If

                    NodoRemolques.appendChild(NodoRemolque)
                Next

                NodoAutotransporte.appendChild(NodoRemolques)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            NodoMercancias.appendChild(NodoAutotransporte)
            'End If

            NodoCartaPorte.appendChild(NodoMercancias)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim NodoFiguraTransporte As MSXML2.IXMLDOMElement 'Nodo condicional '[0..1]

            If Me.FiguraTransporte.TiposFigura.Count > 0 Then
                NodoFiguraTransporte = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "FiguraTransporte", xmlns)

                For i = 1 To Me.FiguraTransporte.TiposFigura.Count
                    Dim NodoTiposFigura As MSXML2.IXMLDOMElement 'Nodo condicional '[1..*]
                    NodoTiposFigura = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "TiposFigura", xmlns)

                    If txtLEN(Me.FiguraTransporte.TiposFigura.Item(i).TipoFigura) = True Then
                        NodoTiposFigura.setAttribute("TipoFigura", Me.FiguraTransporte.TiposFigura.Item(i).TipoFigura)  'required
                    Else
                        MsgBox("El valor de FiguraTransporte.TiposFigura.TipoFigura es un dato requerido.", vbExclamation, sProcedure) : Return False
                    End If

                    If txtLEN(Me.FiguraTransporte.TiposFigura.Item(i).RFCFigura) = True Then
                        NodoTiposFigura.setAttribute("RFCFigura", Me.FiguraTransporte.TiposFigura.Item(i).RFCFigura)  'optional
                    End If

                    If txtLEN(Me.FiguraTransporte.TiposFigura.Item(i).NumLicencia) = True Then
                        NodoTiposFigura.setAttribute("NumLicencia", Me.FiguraTransporte.TiposFigura.Item(i).NumLicencia) 'optional
                    End If

                    If txtLEN(Me.FiguraTransporte.TiposFigura.Item(i).NombreFigura) = True Then
                        NodoTiposFigura.setAttribute("NombreFigura", Me.FiguraTransporte.TiposFigura.Item(i).NombreFigura) 'optional
                    End If

                    If txtLEN(Me.FiguraTransporte.TiposFigura.Item(i).NumRegIdTribFigura) = True Then
                        NodoTiposFigura.setAttribute("NumRegIdTribFigura", Me.FiguraTransporte.TiposFigura.Item(i).NumRegIdTribFigura) 'optional
                    End If

                    If txtLEN(Me.FiguraTransporte.TiposFigura.Item(i).ResidenciaFiscalFigura) = True Then
                        NodoTiposFigura.setAttribute("ResidenciaFiscalFigura", Me.FiguraTransporte.TiposFigura.Item(i).ResidenciaFiscalFigura) 'optional
                    End If

                    For j = 1 To Me.FiguraTransporte.TiposFigura.Item(i).PartesTransporte.Count
                        Dim NodoPartesTransporte As MSXML2.IXMLDOMElement 'Nodo condicional '[0..*]
                        NodoPartesTransporte = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "PartesTransporte", xmlns)

                        If txtLEN(Me.FiguraTransporte.TiposFigura.Item(i).PartesTransporte.Item(j).ParteTransporte) = True Then
                            NodoPartesTransporte.setAttribute("ParteTransporte", Me.FiguraTransporte.TiposFigura.Item(i).PartesTransporte.Item(j).ParteTransporte) 'required
                        Else
                            MsgBox("El valor de FiguraTransporte.TiposFigura.PartesTransporte.ParteTransporte es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        NodoTiposFigura.appendChild(NodoPartesTransporte)
                    Next

                    'If Me.FiguraTransporte.TiposFigura.Item(i).bTieneDomicilio = True Then
                    Dim NodoTipoFiguraDomicilio As MSXML2.IXMLDOMElement 'Nodo condicional '[0..*]
                    NodoTipoFiguraDomicilio = xmlDoc.createNode(MSXML2.tagDOMNodeType.NODE_ELEMENT, AnexoNodo & "Domicilio", xmlns)

                    With NodoTipoFiguraDomicilio
                        If txtLEN(Me.FiguraTransporte.TiposFigura.Item(i).Domicilio.Calle) = True Then
                            .setAttribute("Calle", Me.FiguraTransporte.TiposFigura.Item(i).Domicilio.Calle) 'optional
                        End If

                        If txtLEN(Me.FiguraTransporte.TiposFigura.Item(i).Domicilio.NumeroExterior) = True Then
                            .setAttribute("NumeroExterior", Me.FiguraTransporte.TiposFigura.Item(i).Domicilio.NumeroExterior) 'optional
                        End If

                        If txtLEN(Me.FiguraTransporte.TiposFigura.Item(i).Domicilio.NumeroInterior) = True Then
                            .setAttribute("NumeroInterior", Me.FiguraTransporte.TiposFigura.Item(i).Domicilio.NumeroInterior) 'optional
                        End If

                        If txtLEN(Me.FiguraTransporte.TiposFigura.Item(i).Domicilio.Colonia) = True Then
                            .setAttribute("Colonia", Me.FiguraTransporte.TiposFigura.Item(i).Domicilio.Colonia) 'optional
                        End If

                        If txtLEN(Me.FiguraTransporte.TiposFigura.Item(i).Domicilio.Localidad) = True Then
                            .setAttribute("Localidad", Me.FiguraTransporte.TiposFigura.Item(i).Domicilio.Localidad) 'optional
                        End If

                        If txtLEN(Me.FiguraTransporte.TiposFigura.Item(i).Domicilio.Referencia) = True Then
                            .setAttribute("Referencia", Me.FiguraTransporte.TiposFigura.Item(i).Domicilio.Referencia) 'optional
                        End If

                        If txtLEN(Me.FiguraTransporte.TiposFigura.Item(i).Domicilio.Municipio) = True Then
                            .setAttribute("Municipio", Me.FiguraTransporte.TiposFigura.Item(i).Domicilio.Municipio) 'optional
                        End If

                        If txtLEN(Me.FiguraTransporte.TiposFigura.Item(i).Domicilio.Estado) = True Then
                            .setAttribute("Estado", Me.FiguraTransporte.TiposFigura.Item(i).Domicilio.Estado) 'required
                        Else
                            MsgBox("El valor de FiguraTransporte.TiposFigura.Domicilio.Estado es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Me.FiguraTransporte.TiposFigura.Item(i).Domicilio.Pais) = True Then
                            .setAttribute("Pais", Me.FiguraTransporte.TiposFigura.Item(i).Domicilio.Pais) 'required
                        Else
                            MsgBox("El valor de FiguraTransporte.TiposFigura.Domicilio.Pais es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If

                        If txtLEN(Me.FiguraTransporte.TiposFigura.Item(i).Domicilio.CodigoPostal) = True Then
                            .setAttribute("CodigoPostal", Me.FiguraTransporte.TiposFigura.Item(i).Domicilio.CodigoPostal) 'required
                        Else
                            MsgBox("El valor de FiguraTransporte.TiposFigura.Domicilio.CodigoPostal es un dato requerido.", vbExclamation, sProcedure) : Return False
                        End If
                    End With

                    NodoTiposFigura.appendChild(NodoTipoFiguraDomicilio)
                    'End If

                    NodoFiguraTransporte.appendChild(NodoTiposFigura)
                Next

                NodoCartaPorte.appendChild(NodoFiguraTransporte)
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ValidaComplementoCartaPorte20() = True Then
                Me.Complemento = NodoCartaPorte
                Me.ComplementoGenerado = True
                bResultado = True
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            HandleError(NombreClase, sProcedure, ex)
        End Try

        Return bResultado
    End Function

    Private Function ValidaComplementoCartaPorte20() As Boolean
        Const sProcedure As String = "ValidaComplementoCartaPorte20"
        Dim bResultado As Boolean = False

        Try
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Ubicaciones:Ubicacion Cuando exista alguno de los nodos “Mercancias:Autotransporte”, “Mercancias:TransporteMaritimo” o “Mercancias:TransporteAereo”, deben existir al menos 2 nodos “Ubicaciones:Ubicacion”, donde existan los atributos “Ubicaciones:Ubicacion:TipoUbicacion” uno  con el valor “Origen” y otro con el valor “Destino”.
            'CP126-El número de nodos de "Ubicaciones:Ubicacion" es menor a "2", o no existe al menos un atributo “Ubicaciones:Ubicacion:TipoUbicacion” con el valor "Origen" y "Destino", respectivamente. 

            'If Me.Mercancias.bTieneAutotransporte = True Then
            If Me.Ubicaciones.Count <> 2 Then
errorUbicacion:
                MsgBox("CP126-El número de nodos de Ubicaciones:Ubicacion es menor a 2, o no existe al menos un atributo Ubicaciones:Ubicacion:TipoUbicacion con el valor Origen y Destino, respectivamente.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            Else
                Dim bOrigenEncontrado As Boolean = False, bDestinoEncontrado As Boolean = False

                If Me.Ubicaciones.Item(1).TipoUbicacion = "Origen" Then
                    bOrigenEncontrado = True
                ElseIf Me.Ubicaciones.Item(2).TipoUbicacion = "Destino" Then
                    bDestinoEncontrado = True
                End If

                If Me.Ubicaciones.Item(2).TipoUbicacion = "Destino" Then
                    If bOrigenEncontrado = False Then
                        GoTo errorUbicacion : Return False
                    Else
                        bDestinoEncontrado = True
                    End If
                ElseIf Me.Ubicaciones.Item(1).TipoUbicacion = "Origen" Then
                    If bDestinoEncontrado = False Then
                        GoTo errorUbicacion : Return False
                    Else
                        bDestinoEncontrado = True
                    End If
                End If

                If Not (bOrigenEncontrado = True And bDestinoEncontrado = True) Then
                    GoTo errorUbicacion : Return False
                End If
            End If
            'End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'If Me.Mercancias.bTieneAutotransporte = True Then
            'FiguraTransporte Cuando exista el nodo “Mercancias:Autotransporte”, este elemento debe existir.	
            'CP171-No existe el nodo "CartaPorte:FiguraTransporte" o se registró sin información.

            If Me.FiguraTransporte.TiposFigura.Count = 0 Then
                MsgBox("CP171-No existe el nodo CartaPorte:FiguraTransporte o se registró sin información.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            'FiguraTransporte:TiposFigura Cuando exista el nodo “Mercancias:Autotransporte”, este nodo debe existir al menos una vez donde el atributo “CartaPorte:FiguraTransporte:TiposFigura:TipoFigura” debe contener la clave “01” del catálogo catCartaPorte: c_FiguraTransporte, que corresponde a “Operador”.	
            'CP172-No existe el nodo "FiguraTransporte:TiposFigura" o se registró sin información.

            Dim bTipoFigura01Encontrado As Boolean = False
            For i As Integer = 1 To Me.FiguraTransporte.TiposFigura.Count ' - 1
                If Me.FiguraTransporte.TiposFigura.Item(i).TipoFigura = "01" Then
                    bTipoFigura01Encontrado = True : Exit For
                End If
            Next

            If bTipoFigura01Encontrado = False Then
                MsgBox("CP172-No existe el nodo FiguraTransporte:TiposFigura o se registró sin información.", MsgBoxStyle.Exclamation, sProcedure)
                Return False
            End If

            'TiposFigura:NumLicencia Cuando el valor registrado en el atributo “CartaPorte:FiguraTransporte:TiposFigura:TipoFigura” sea igual a “01”, este atributo debe existir, en caso contrario se debe omitir.  	
            'CP174-No existe el atributo "TiposFigura:NumLicencia", no cumple con el patrón, o el valor registrado en el atributo "TiposFigura:TIpoFigura" es diferente de "01".

            For i As Integer = 1 To Me.FiguraTransporte.TiposFigura.Count '- 1
                If Me.FiguraTransporte.TiposFigura.Item(i).TipoFigura = "01" Then
                    If Me.FiguraTransporte.TiposFigura.Item(i).NumLicencia.Length = 0 Then
                        MsgBox("CP174-No existe el atributo TiposFigura:NumLicencia, no cumple con el patrón, o el valor registrado en el atributo TiposFigura:TIpoFigura es diferente de 01.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                End If
            Next
            'End If

            'TiposFigura: PartesTransporte Cuando en el atributo “CartaPorte:FiguraTransporte:TiposFigura:TipoFigura” se registre el valor “02” o “03”, este nodo debe existir, en caso contrario se debe omitir.	
            'CP177- No existe el nodo "TiposFigura:PartesTransporte", se registró sin información o el valor registrado en el atributo "TiposFigura:TipoFigura" tiene un valor diferente de "02" o "03".

            For i As Integer = 1 To Me.FiguraTransporte.TiposFigura.Count '- 1
                If Me.FiguraTransporte.TiposFigura.Item(i).TipoFigura = "02" Or Me.FiguraTransporte.TiposFigura.Item(i).TipoFigura = "03" Then
                    If Me.FiguraTransporte.TiposFigura.Item(i).PartesTransporte.Count = 0 Then
                        MsgBox("CP177- No existe el nodo TiposFigura:PartesTransporte, se registró sin información o el valor registrado en el atributo TiposFigura:TipoFigura tiene un valor diferente de 02 o 03.", MsgBoxStyle.Exclamation, sProcedure)
                        Return False
                    End If
                End If
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'MsgBox("Ver la matriz de errores para ver que validar aquí")

            bResultado = True
        Catch ex As Exception
            HandleError(NombreClase, sProcedure, ex)
        End Try

        Return bResultado
    End Function

#End Region

End Class
