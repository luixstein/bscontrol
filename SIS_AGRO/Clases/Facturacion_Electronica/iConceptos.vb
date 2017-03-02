Option Strict Off
Option Explicit On
Friend Class iConceptos
	Implements System.Collections.IEnumerable
	Dim Partidas As Collection
	
    Public Function Add(ByVal cantidad As String, ByVal descripcion As String, ByVal importe As String, ByVal unidad As String, ByVal valorUnitario As String, Optional ByVal noIdentificacion As String = "") As iConcepto
        Dim objObjeto As New iConcepto
        Try
            objObjeto.cantidad = cantidad
            objObjeto.descripcion = descripcion
            objObjeto.importe = importe
            objObjeto.unidad = unidad
            objObjeto.valorUnitario = valorUnitario
            objObjeto.noIdentificacion = noIdentificacion

            Partidas.Add(objObjeto, "N" & Partidas.Count + 1 & CStr(descripcion))
        Catch ex As Exception
            HandleError("iConceptos", "Add", ex)
        End Try
        Return objObjeto
    End Function
	
	Public Sub RemoveAll()
		Partidas = New Collection
	End Sub
	
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Initialize_Renamed()
		Partidas = New Collection
    End Sub

	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Terminate_Renamed()
		
		On Error GoTo procerror
		
		'UPGRADE_NOTE: Object Partidas may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Partidas = Nothing
		Exit Sub
		
procerror: 
		Resume Fin
		Resume 
Fin: 
	End Sub
	Protected Overrides Sub Finalize()
		Class_Terminate_Renamed()
		MyBase.Finalize()
	End Sub
	
	Public ReadOnly Property Count() As Integer
		Get
			'se usa al obtener el número de elementos de la
			'colección. Sintaxis: Debug.Print x.Count
			Count = Partidas.Count()
		End Get
	End Property
	
	'UPGRADE_NOTE: NewEnum property was commented out. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3FC1610-34F3-43F5-86B7-16C984F0E88E"'
	'Public ReadOnly Property NewEnum() As stdole.IUnknown
		'Get
			'esta propiedad permite enumerar
			'esta colección con la sintaxis For...Each
			'NewEnum = Partidas._NewEnum
		'End Get
	'End Property
	
	Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
		'UPGRADE_TODO: Uncomment and change the following line to return the collection enumerator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="95F9AAD0-1319-4921-95F0-B9D3C4FF7F1C"'
        GetEnumerator = Partidas.GetEnumerator
	End Function
	
	Public ReadOnly Property Item(ByVal vntIndexKey As Object) As iConcepto
		Get
			'se usa al hacer referencia a un elemento de la colección
			'vntIndexKey contiene el índice o la clave de la colección,
			'por lo que se declara como un Variant
			'Syntax: Set foo = x.Item(xyz) or Set foo = x.Item(5)
			Item = Partidas.Item(vntIndexKey)
		End Get
	End Property
End Class