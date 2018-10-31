Option Strict On

Public Class clsComprobante
    Private versionField As String = ""
    Private serieField As String = ""
    Private folioField As String = ""
    Private fechaField As Date
    Private selloField As String = ""
    Private formaDePagoField As String = ""
    Private noCertificadoField As String = ""
    Private certificadoField As String = ""
    Private condicionesDePagoField As String = ""
    Private subTotalField As Double
    Private descuentoField As Double
    Private descuentoFieldSpecified As Boolean
    Private motivoDescuentoField As String = ""
    Private tipoCambioField As String = ""
    Private monedaField As String = ""
    Private totalField As Double
    Private tipoDeComprobanteField As String = ""
    Private metodoDePagoField As String = ""
    Private lugarExpedicionField As String = ""
    Private numCtaPagoField As String = ""
    'Private folioFiscalOrigField As String = ""
    'Private serieFolioFiscalOrigField As String = ""
    'Private fechaFolioFiscalOrigField As Date
    'Private montoFolioFiscalOrigField As Double
    Private ConfirmacionField As String = ""

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property version() As String
        Get
            Return Me.versionField
        End Get
        Set(value As String)
            Me.versionField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property serie() As String
        Get
            Return Me.serieField
        End Get
        Set(value As String)
            Me.serieField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property folio() As String
        Get
            Return Me.folioField
        End Get
        Set(value As String)
            Me.folioField = value
        End Set
    End Property

    Public ReadOnly Property folioCompleto As String
        Get
            If txtLEN(Me.serieField) = True Then
                Return Me.serieField & "-" & Me.folioField
            Else
                Return Me.folioField
            End If
        End Get
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property fecha() As Date
        Get
            Return Me.fechaField
        End Get
        Set(value As Date)
            Me.fechaField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property sello() As String
        Get
            Return Me.selloField
        End Get
        Set(value As String)
            Me.selloField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property formaDePago() As String
        Get
            Return Me.formaDePagoField
        End Get
        Set(value As String)
            Me.formaDePagoField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property noCertificado() As String
        Get
            Return Me.noCertificadoField
        End Get
        Set(value As String)
            Me.noCertificadoField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property certificado() As String
        Get
            Return Me.certificadoField
        End Get
        Set(value As String)
            Me.certificadoField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property condicionesDePago() As String
        Get
            Return Me.condicionesDePagoField
        End Get
        Set(value As String)
            Me.condicionesDePagoField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property subTotal() As Double
        Get
            Return Me.subTotalField
        End Get
        Set(value As Double)
            Me.subTotalField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property descuento() As Double
        Get
            Return Me.descuentoField
        End Get
        Set(value As Double)
            Me.descuentoField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property motivoDescuento() As String
        Get
            Return Me.motivoDescuentoField
        End Get
        Set(value As String)
            Me.motivoDescuentoField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TipoCambio() As String
        Get
            Return Me.tipoCambioField
        End Get
        Set(value As String)
            Me.tipoCambioField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Moneda() As String
        Get
            Return Me.monedaField
        End Get
        Set(value As String)
            Me.monedaField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property total() As Double
        Get
            Return Me.totalField
        End Get
        Set(value As Double)
            Me.totalField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property tipoDeComprobante() As String
        Get
            Return Me.tipoDeComprobanteField
        End Get
        Set(value As String)
            Me.tipoDeComprobanteField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property metodoDePago() As String
        Get
            Return Me.metodoDePagoField
        End Get
        Set(value As String)
            Me.metodoDePagoField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property LugarExpedicion() As String
        Get
            Return Me.lugarExpedicionField
        End Get
        Set(value As String)
            Me.lugarExpedicionField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property NumCtaPago() As String
        Get
            Return Me.numCtaPagoField
        End Get
        Set(value As String)
            Me.numCtaPagoField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Confirmacion() As String
        Get
            Return Me.ConfirmacionField
        End Get
        Set(value As String)
            Me.ConfirmacionField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public ReadOnly Property CantidadConLetra As String
        Get
            'numletra(Dimp_civa, "DOLAR", " U.S.C.Y.")
            If Me.tipoCambioField = "" Or Me.tipoCambioField = "." Or valorNumerico(Me.tipoCambioField) = 1 Then
                Return numletra(Me.totalField.ToString)
            Else
                Return numletra(Me.totalField.ToString, "DOLAR", " U.S.C.Y.")
            End If
        End Get
    End Property


    ' '''<comentarios/>
    '<System.Xml.Serialization.XmlAttributeAttribute()> _
    'Public Property FolioFiscalOrig() As String
    '    Get
    '        Return Me.folioFiscalOrigField
    '    End Get
    '    Set(value As String)
    '        Me.folioFiscalOrigField = value
    '    End Set
    'End Property

    ' '''<comentarios/>
    '<System.Xml.Serialization.XmlAttributeAttribute()> _
    'Public Property SerieFolioFiscalOrig() As String
    '    Get
    '        Return Me.serieFolioFiscalOrigField
    '    End Get
    '    Set(value As String)
    '        Me.serieFolioFiscalOrigField = value
    '    End Set
    'End Property

    ' '''<comentarios/>
    '<System.Xml.Serialization.XmlAttributeAttribute()> _
    'Public Property FechaFolioFiscalOrig() As Date
    '    Get
    '        Return Me.fechaFolioFiscalOrigField
    '    End Get
    '    Set(value As Date)
    '        Me.fechaFolioFiscalOrigField = value
    '    End Set
    'End Property

    ' '''<comentarios/>
    '<System.Xml.Serialization.XmlAttributeAttribute()> _
    'Public Property MontoFolioFiscalOrig() As Double
    '    Get
    '        Return Me.montoFolioFiscalOrigField
    '    End Get
    '    Set(value As Double)
    '        Me.montoFolioFiscalOrigField = value
    '    End Set
    'End Property
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class t_UbicacionFiscal
    Private calleField As String
    Private noExteriorField As String
    Private noInteriorField As String
    Private coloniaField As String
    Private localidadField As String
    Private referenciaField As String
    Private municipioField As String
    Private estadoField As String
    Private paisField As String
    Private codigoPostalField As String

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property calle() As String
        Get
            Return Me.calleField
        End Get
        Set(value As String)
            Me.calleField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property noExterior() As String
        Get
            Return Me.noExteriorField
        End Get
        Set(value As String)
            Me.noExteriorField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property noInterior() As String
        Get
            Return Me.noInteriorField
        End Get
        Set(value As String)
            Me.noInteriorField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property colonia() As String
        Get
            Return Me.coloniaField
        End Get
        Set(value As String)
            Me.coloniaField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property localidad() As String
        Get
            Return Me.localidadField
        End Get
        Set(value As String)
            Me.localidadField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property referencia() As String
        Get
            Return Me.referenciaField
        End Get
        Set(value As String)
            Me.referenciaField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property municipio() As String
        Get
            Return Me.municipioField
        End Get
        Set(value As String)
            Me.municipioField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property estado() As String
        Get
            Return Me.estadoField
        End Get
        Set(value As String)
            Me.estadoField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property pais() As String
        Get
            Return Me.paisField
        End Get
        Set(value As String)
            Me.paisField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property codigoPostal() As String
        Get
            Return Me.codigoPostalField
        End Get
        Set(value As String)
            Me.codigoPostalField = value
        End Set
    End Property
End Class

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class t_Ubicacion
    Private calleField As String
    Private noExteriorField As String
    Private noInteriorField As String
    Private coloniaField As String
    Private localidadField As String
    Private referenciaField As String
    Private municipioField As String
    Private estadoField As String
    Private paisField As String
    Private codigoPostalField As String

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property calle() As String
        Get
            Return Me.calleField
        End Get
        Set(value As String)
            Me.calleField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property noExterior() As String
        Get
            Return Me.noExteriorField
        End Get
        Set(value As String)
            Me.noExteriorField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property noInterior() As String
        Get
            Return Me.noInteriorField
        End Get
        Set(value As String)
            Me.noInteriorField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property colonia() As String
        Get
            Return Me.coloniaField
        End Get
        Set(value As String)
            Me.coloniaField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property localidad() As String
        Get
            Return Me.localidadField
        End Get
        Set(value As String)
            Me.localidadField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property referencia() As String
        Get
            Return Me.referenciaField
        End Get
        Set(value As String)
            Me.referenciaField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property municipio() As String
        Get
            Return Me.municipioField
        End Get
        Set(value As String)
            Me.municipioField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property estado() As String
        Get
            Return Me.estadoField
        End Get
        Set(value As String)
            Me.estadoField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property pais() As String
        Get
            Return Me.paisField
        End Get
        Set(value As String)
            Me.paisField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property codigoPostal() As String
        Get
            Return Me.codigoPostalField
        End Get
        Set(value As String)
            Me.codigoPostalField = value
        End Set
    End Property
End Class

'''<comentarios/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteEmisorRegimenFiscal
    Private regimenField As String

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Regimen() As String
        Get
            Return Me.regimenField
        End Get
        Set(value As String)
            Me.regimenField = value
        End Set
    End Property
End Class

'''<comentarios/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteEmisor
    Private domicilioFiscalField As New t_UbicacionFiscal
    Private expedidoEnField As New t_Ubicacion
    Private regimenFiscalField As New ComprobanteEmisorRegimenFiscal
    Private rfcField As String = ""
    Private nombreField As String = ""

    '''<comentarios/>
    Public Property DomicilioFiscal() As t_UbicacionFiscal
        Get
            Return Me.domicilioFiscalField
        End Get
        Set(value As t_UbicacionFiscal)
            Me.domicilioFiscalField = value
        End Set
    End Property

    '''<comentarios/>
    Public Property ExpedidoEn() As t_Ubicacion
        Get
            Return Me.expedidoEnField
        End Get
        Set(value As t_Ubicacion)
            Me.expedidoEnField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlElementAttribute("RegimenFiscal")>
    Public Property RegimenFiscal As ComprobanteEmisorRegimenFiscal
        Get
            Return Me.regimenFiscalField
        End Get
        Set(value As ComprobanteEmisorRegimenFiscal)
            Me.regimenFiscalField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property rfc() As String
        Get
            Return Me.rfcField
        End Get
        Set(value As String)
            Me.rfcField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property nombre() As String
        Get
            Return Me.nombreField
        End Get
        Set(value As String)
            Me.nombreField = value
        End Set
    End Property
End Class

'''<comentarios/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteReceptor
    Private domicilioField As New t_Ubicacion
    Private rfcField As String = ""
    Private nombreField As String = ""
    Private ResidenciaFiscalField As String = ""
    Private NumRegIdTribField As String = ""
    Private UsoCFDIField As String = ""

    '''<comentarios/>
    Public Property Domicilio() As t_Ubicacion
        Get
            Return Me.domicilioField
        End Get
        Set(value As t_Ubicacion)
            Me.domicilioField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property rfc() As String
        Get
            Return Me.rfcField
        End Get
        Set(value As String)
            Me.rfcField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property nombre() As String
        Get
            Return Me.nombreField
        End Get
        Set(value As String)
            Me.nombreField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property ResidenciaFiscal() As String
        Get
            Return Me.ResidenciaFiscalField
        End Get
        Set(value As String)
            Me.ResidenciaFiscalField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property NumRegIdTrib() As String
        Get
            Return Me.NumRegIdTribField
        End Get
        Set(value As String)
            Me.NumRegIdTribField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property UsoCFDI() As String
        Get
            Return Me.UsoCFDIField
        End Get
        Set(value As String)
            Me.UsoCFDIField = value
        End Set
    End Property


End Class

Public Class clsComplementoTimbreFiscalDigital
    Private _Version As String = ""
    Private _UUID As String = ""
    Private _FechaTimbrado As String = ""
    Private _NoCertificadoSAT As String = ""
    Private _SelloCFD As String = ""
    Private _SelloSAT As String = ""
    Private _CBBImage As Byte()
    Private _RfcProvCertif As String = ""
    Private _Leyenda As String = ""

    Public Property Version As String
        Get
            Return Me._Version
        End Get
        Set(value As String)
            Me._Version = value
        End Set
    End Property

    Public Property UUID As String
        Get
            Return Me._UUID
        End Get
        Set(value As String)
            Me._UUID = value
        End Set
    End Property

    Public Property FechaTimbrado As String
        Get
            Return Me._FechaTimbrado
        End Get
        Set(value As String)
            Me._FechaTimbrado = value
        End Set
    End Property

    Public Property NoCertificadoSAT As String
        Get
            Return Me._NoCertificadoSAT
        End Get
        Set(value As String)
            Me._NoCertificadoSAT = value
        End Set
    End Property

    Public Property SelloCFD As String
        Get
            Return Me._SelloCFD
        End Get
        Set(value As String)
            Me._SelloCFD = value
        End Set
    End Property

    Public Property SelloSAT As String
        Get
            Return Me._SelloSAT
        End Get
        Set(value As String)
            Me._SelloSAT = value
        End Set
    End Property

    Public Property CBBImage As Byte()
        Get
            Return Me._CBBImage
        End Get
        Set(value As Byte())
            Me._CBBImage = value
        End Set
    End Property

    Public Property RfcProvCertif As String
        Get
            Return Me._RfcProvCertif
        End Get
        Set(value As String)
            Me._RfcProvCertif = value
        End Set
    End Property

    Public Property Leyenda As String
        Get
            Return Me._Leyenda
        End Get
        Set(value As String)
            Me._Leyenda = value
        End Set
    End Property
End Class

Public Class clsConcepto
    Private _Cantidad As Double
    Private _Unidad As String
    Private _Descripcion As String
    Private _ValorUnitario As Double
    Private _Importe As Double

    Public Property Cantidad() As Double
        Get
            Return Me._Cantidad
        End Get
        Set(value As Double)
            Me._Cantidad = value
        End Set
    End Property
    Public Property Unidad() As String
        Get
            Return Me._Unidad
        End Get
        Set(value As String)
            Me._Unidad = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return Me._Descripcion
        End Get
        Set(value As String)
            Me._Descripcion = value
        End Set
    End Property
    Public Property valorUnitario() As Double
        Get
            Return Me._ValorUnitario
        End Get
        Set(value As Double)
            Me._ValorUnitario = value
        End Set
    End Property
    Public Property Importe() As Double
        Get
            Return Me._Importe
        End Get
        Set(value As Double)
            Me._Importe = value
        End Set
    End Property
End Class

'''<comentarios/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteImpuestos
    Private retencionesField() As ComprobanteImpuestosRetencion
    Private trasladosField() As ComprobanteImpuestosTraslado
    Private totalImpuestosRetenidosField As Double
    Private totalImpuestosTrasladadosField As Double

    '''<comentarios/>
    <System.Xml.Serialization.XmlArrayItemAttribute("Retencion", IsNullable:=False)>
    Public Property Retenciones() As ComprobanteImpuestosRetencion()
        Get
            Return Me.retencionesField
        End Get
        Set(value As ComprobanteImpuestosRetencion())
            Me.retencionesField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlArrayItemAttribute("Traslado", IsNullable:=False)>
    Public Property Traslados() As ComprobanteImpuestosTraslado()
        Get
            Return Me.trasladosField
        End Get
        Set(value As ComprobanteImpuestosTraslado())
            Me.trasladosField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property totalImpuestosRetenidos() As Double
        Get
            Return Me.totalImpuestosRetenidosField
        End Get
        Set(value As Double)
            Me.totalImpuestosRetenidosField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property totalImpuestosTrasladados() As Double
        Get
            Return Me.totalImpuestosTrasladadosField
        End Get
        Set(value As Double)
            Me.totalImpuestosTrasladadosField = value
        End Set
    End Property


End Class

'''<comentarios/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteImpuestosRetencion

    'Private impuestoField As ComprobanteImpuestosRetencionImpuesto
    Private impuestoField As String

    Private importeField As Double

    ' '''<comentarios/>
    '<System.Xml.Serialization.XmlAttributeAttribute()> _
    'Public Property impuesto() As ComprobanteImpuestosRetencionImpuesto
    '    Get
    '        Return Me.impuestoField
    '    End Get
    '    Set(value As ComprobanteImpuestosRetencionImpuesto)
    '        Me.impuestoField = value
    '    End Set
    'End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property impuesto() As String
        Get
            Return Me.impuestoField
        End Get
        Set(value As String)
            Me.impuestoField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property importe() As Double
        Get
            Return Me.importeField
        End Get
        Set(value As Double)
            Me.importeField = value
        End Set
    End Property
End Class

' '''<comentarios/>
'<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"), _
' System.SerializableAttribute(), _
' System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")> _
'Public Enum ComprobanteImpuestosRetencionImpuesto

'    '''<comentarios/>
'    ISR

'    '''<comentarios/>
'    IVA
'End Enum

<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteImpuestosTraslado

    'Private impuestoField As ComprobanteImpuestosTrasladoImpuesto
    Private impuestoField As String

    Private tasaField As Double

    Private importeField As Double

    ' '''<comentarios/>
    '<System.Xml.Serialization.XmlAttributeAttribute()> _
    'Public Property impuesto() As ComprobanteImpuestosTrasladoImpuesto
    '    Get
    '        Return Me.impuestoField
    '    End Get
    '    Set(value As ComprobanteImpuestosTrasladoImpuesto)
    '        Me.impuestoField = value
    '    End Set
    'End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property impuesto() As String
        Get
            Return Me.impuestoField
        End Get
        Set(value As String)
            Me.impuestoField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property tasa() As Double
        Get
            Return Me.tasaField
        End Get
        Set(value As Double)
            Me.tasaField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property importe() As Double
        Get
            Return Me.importeField
        End Get
        Set(value As Double)
            Me.importeField = value
        End Set
    End Property
End Class

' '''<comentarios/>
'<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"), _
' System.SerializableAttribute(), _
' System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")> _
'Public Enum ComprobanteImpuestosTrasladoImpuesto

'    '''<comentarios/>
'    IVA

'    '''<comentarios/>
'    IEPS
'End Enum

'''<comentarios/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteImpuestosLocales
    Private TotaldeRetencionesField As Double
    Private TotaldeTrasladosField As Double

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotaldeRetenciones As Double
        Get
            Return Me.TotaldeRetencionesField
        End Get
        Set(value As Double)
            Me.TotaldeRetencionesField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotaldeTraslados As Double
        Get
            Return Me.TotaldeTrasladosField
        End Get
        Set(value As Double)
            Me.TotaldeTrasladosField = value
        End Set
    End Property
End Class

'''<comentarios/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.sat.gob.mx/cfd/3")>
Partial Public Class ComprobanteImpuestosAerolineas
    Private TUAField As Double
    Private TieneTUADesglosadoField As Boolean

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TUA As Double
        Get
            Return Me.TUAField
        End Get
        Set(value As Double)
            Me.TUAField = value
        End Set
    End Property

    '''<comentarios/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TieneTUADesglosado As Boolean
        Get
            Return Me.TieneTUADesglosadoField
        End Get
        Set(value As Boolean)
            Me.TieneTUADesglosadoField = value
        End Set
    End Property
End Class