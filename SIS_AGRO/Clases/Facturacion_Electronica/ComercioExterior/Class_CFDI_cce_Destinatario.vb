Option Strict Off
Option Explicit On

Friend Class Class_CFDI_cce_Destinatario
    Public NumRegIdTrib As String
    Public Rfc As String
    Public Curp As String
    Public Nombre As String
    Public Domicilio As New ClassCFDI_cce_DestinatarioDomicilio
End Class

Friend Class ClassCFDI_cce_DestinatarioDomicilio
    Public Calle As String
    Public NumeroExterior As String
    Public NumeroInterior As String
    Public Colonia As String
    Public Localidad As String
    Public Referencia As String
    Public Municipio As String
    Public Estado As String
    Public Pais As String
    Public CodigoPostal As String
End Class