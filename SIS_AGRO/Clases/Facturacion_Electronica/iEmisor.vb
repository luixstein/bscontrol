Option Strict Off
Option Explicit On
Friend Class iEmisor
	
	Public nombre As String
	Public rfc As String
	Public DomicilioFiscal As iEmisorDomFis
	Public ExpedidoEn As iEmisorExpedidoEn
	
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Initialize_Renamed()
		DomicilioFiscal = New iEmisorDomFis
		ExpedidoEn = New iEmisorExpedidoEn
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
End Class