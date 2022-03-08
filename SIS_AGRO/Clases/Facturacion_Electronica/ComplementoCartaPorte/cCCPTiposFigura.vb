Option Explicit On

Friend Class cCCPTiposFigura
    Implements System.Collections.IEnumerable
    Dim Partidas As Collection

    Private Const NombreClase As String = "cCCPTiposFigura"

    Public Function Add(ByVal TipoFigura As cCCPTipoFigura) As cCCPTipoFigura
        Const sProcedure As String = "Add"

        Dim objObjeto As New cCCPTipoFigura
        Try
            Partidas.Add(TipoFigura, Partidas.Count + 1)
        Catch ex As Exception
            HandleError(NombreClase, sProcedure, ex)
        End Try

        Return objObjeto
    End Function

    'Public Function Add(
    '    ByVal TipoFigura As String,
    '    ByVal RFCFigura As String,
    '    ByVal NumLicencia As String,
    '    ByVal NombreFigura As String,
    '    ByVal NumRegIdTribFigura As String,
    '    ByVal ResidenciaFiscalFigura As String,
    '    Optional ByVal PartesTransporte As cCCPPartesTransporte = Nothing,
    '    Optional ByVal bTieneDomicilio As Boolean = False,
    '    Optional ByVal Domicilio As cCCPDomicilio = Nothing
    '                   ) As cCCPTipoFigura

    '    Const sProcedure As String = "Add"

    '    Dim objObjeto As New cCCPTipoFigura, i As Integer
    '    Try
    '        With objObjeto
    '            .TipoFigura = TipoFigura
    '            .RFCFigura = RFCFigura
    '            .NumLicencia = NumLicencia
    '            .NombreFigura = NombreFigura
    '            .NumRegIdTribFigura = NumRegIdTribFigura
    '            .ResidenciaFiscalFigura = ResidenciaFiscalFigura

    '            .bTieneDomicilio = bTieneDomicilio

    '            If Not (PartesTransporte Is Nothing) Then
    '                With PartesTransporte
    '                    For i = 1 To PartesTransporte.Count
    '                        .Add(PartesTransporte.Item(i).ParteTransporte)
    '                        '.Add.Item(i).ParteTransporte
    '                    Next
    '                End With
    '            End If

    '            If Not (Domicilio Is Nothing) And bTieneDomicilio = True Then
    '                With .Domicilio
    '                    .Calle = Domicilio.Calle
    '                    .NumeroExterior = Domicilio.NumeroExterior
    '                    .NumeroInterior = Domicilio.NumeroInterior
    '                    .Colonia = Domicilio.Colonia
    '                    .Localidad = Domicilio.Localidad
    '                    .Referencia = Domicilio.Referencia
    '                    .Municipio = Domicilio.Municipio
    '                    .Estado = Domicilio.Estado
    '                    .Pais = Domicilio.Pais
    '                    .CodigoPostal = Domicilio.CodigoPostal
    '                End With
    '            End If

    '            '.PartesTransporte = PartesTransporte
    '            '.Domicilio = Domicilio
    '        End With

    '        Partidas.Add(objObjeto, Partidas.Count + 1)
    '    Catch ex As Exception
    '        HandleError(NombreClase, sProcedure, ex)
    '    End Try

    '    Return objObjeto
    'End Function

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

    Public ReadOnly Property Item(ByVal vntIndexKey As Object) As cCCPTipoFigura
        Get
            'se usa al hacer referencia a un elemento de la colección
            'vntIndexKey contiene el índice o la clave de la colección,
            'por lo que se declara como un Variant
            'Syntax: Set foo = x.Item(xyz) or Set foo = x.Item(5)
            Item = Partidas.Item(vntIndexKey)
        End Get
    End Property

End Class