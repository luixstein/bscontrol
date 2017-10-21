Option Explicit On

Friend Class cCatalogoFormaPago
    Public CODIGO_METODO_PAGO As String
    Public NOMBRE_METODO_PAGO As String
    Public REQUIERE_NUMERO_CUENTA_PAGO As Boolean
    Public ESTATUS As String
    Public ES_BANCARIZADO As String
    Public REQUIERE_NUMERO_OPERACION As String 'Ninguno de aqui hacia abajo pueden ser boleano porque permiten 3 posibles valores: si,no,opcional
    Public REQUIERE_RFC_EMISOR_CUENTA_ORDENANTE As String
    Public REQUIERE_CUENTA_ORDENANTE As String
    Public REQUIERE_RFC_EMISOR_CUENTA_BENEFICIARIO As String
    Public REQUIERE_CUENTA_BENEFICIARIO As String
    Public REQUIERE_TIPO_CADENA_PAGO As String
    Public REQUIERE_NOMBRE_BANCO_EXTRANJERO_ORIGEN As String
    Public ES_DEFAULT As String
End Class



