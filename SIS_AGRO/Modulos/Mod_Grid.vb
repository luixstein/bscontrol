Module Mod_Grid
    Public Sub FG_Grid_Crear(ByRef Grid As FlexCell.Grid, ByVal Col As Int16, ByVal Ren As Int16)
        Grid.Cols = Col
        Grid.Rows = Ren
    End Sub
    Public Sub FG_Grid_AnchoCol(ByRef Grid As FlexCell.Grid, ByVal Col As Int16, ByVal Ancho As Int16)
        Grid.Column(Col).Width = Ancho
    End Sub
    Public Sub FG_Grid_LockCol(ByRef Grid As FlexCell.Grid, ByVal Col As Int16)
        Grid.Column(Col).Locked = True
    End Sub
    Public Sub FG_Grid_LockRen(ByRef Grid As FlexCell.Grid, ByVal Ren As Int16)
        Grid.Row(Ren).Locked = True
    End Sub
    Public Sub FG_Grid_Lock(ByRef Grid As FlexCell.Grid, ByVal RenIni As Int16, ByVal ColIni As Int16, ByVal RenFin As Int16, ByVal ColFin As Int16)
        Dim i = RenIni
        While i <= RenFin
            Dim j = ColIni
            While j <= ColFin
                Grid.Cell(i, j).Locked = True
                j = j + 1
            End While
            i = i + 1
        End While
    End Sub
    Public Sub FG_Grid_TituloCol(ByRef Grid As FlexCell.Grid, ByVal Col As Int16, ByVal Titulo As String)
        Grid.Cell(0, Col).Text = Titulo
    End Sub
    Public Sub FG_Grid_Limpiar(ByRef Grid As FlexCell.Grid)
        Grid.Rows = 1
    End Sub
    Public Sub FG_Grid_Insertar(ByRef Grid As FlexCell.Grid, ByVal Clave As String, ByVal Nombre As String, ByVal ApellP As String, ByVal ApellM As String, ByVal Sueldo As String)
        Grid.AddItem(Clave & Chr(9) & Nombre & Chr(9) & ApellP & Chr(9) & ApellM & Chr(9) & Sueldo)
    End Sub
    Public Sub FG_Grid_Lock(ByRef Grid As FlexCell.Grid)
        Grid.Locked = True
    End Sub
    Public Sub FG_Grid_Posicionar(ByRef Grid As FlexCell.Grid, ByVal Col As Int16, ByVal Ren As Int16)
        Grid.Cell(Ren, Col).SetFocus()
    End Sub

    Public Function FG_Grid_SumaCol(ByRef Grid As FlexCell.Grid, ByVal Col As Int16) As Double
        Dim Suma As Double = 0
        Dim count As Integer = Grid.FixedRows '1
        Try
            While count < Grid.Rows
                Suma = Suma + valorNumerico(Grid.Cell(count, Col).Text)
                count = count + 1
            End While
        Catch ex As Exception
            HandleError("Mod_Grid", "FG_Grid_SumaCol", ex)
        End Try
        Return Suma
    End Function

    Public Function FG_Grid_Suma_Calculo_Usd(ByRef Grid As FlexCell.Grid, ByVal ColPesos As Int16, ByVal ColUsd As Int16, ByVal dTipoDeCambio As Double) As Double
        Dim Suma As Double = 0
        Dim count As Integer = Grid.FixedRows '1
        Try
            While count < Grid.Rows
                If valorNumerico(Grid.Cell(count, ColUsd).Text) > 0 Then
                    Suma = Suma + valorNumerico(Grid.Cell(count, ColUsd).Text)
                Else
                    Suma = Suma + Redondear(valorNumerico(Grid.Cell(count, ColPesos).Text) * dTipoDeCambio)
                End If
                count = count + 1
            End While
        Catch ex As Exception
            HandleError("Mod_Grid", "FG_Grid_Suma_Calculo_Usd", ex)
        End Try
        Return Suma
    End Function

    Public Function FG_Grid_ComputeCol(ByRef Grid As FlexCell.Grid, ByVal sClave As String, ByVal ColClave As Integer, ByVal ColPos As Integer) As Double
        Dim Suma As Double = 0
        Try
            Dim count As Integer = Grid.FixedRows
            While count < Grid.Rows
                If Grid.Cell(count, ColClave).Text = sClave Then
                    Suma += valorNumerico(Grid.Cell(count, ColPos).Text)
                End If
                'Suma = Suma + valorNumerico(Grid.Cell(count, Col).Text)
                count = count + 1
            End While
        Catch ex As Exception
            HandleError("Mod_Grid", "FG_Grid_ComputeCol", ex)
        End Try
        Return Suma
    End Function

    Public Function FG_Grid_SumaColPositivos(ByRef Grid As FlexCell.Grid, ByVal Col As Int16) As Double
        Dim Suma As Double = 0
        Dim count As Integer = Grid.FixedRows '1
        Try
            While count < Grid.Rows
                If valorNumerico(Grid.Cell(count, Col).Text) > 0 Then
                    Suma = Suma + valorNumerico(Grid.Cell(count, Col).Text)
                End If
                count = count + 1
            End While
        Catch ex As Exception
            HandleError("Mod_Grid", "FG_Grid_SumaColPositivos", ex)
        End Try
        Return Suma
    End Function

    Public Function FG_Grid_SumaColNegativos(ByRef Grid As FlexCell.Grid, ByVal Col As Int16) As Double
        Dim Suma As Double = 0
        Dim count As Integer = Grid.FixedRows '1
        Try
            While count < Grid.Rows
                If valorNumerico(Grid.Cell(count, Col).Text) < 0 Then
                    Suma = Suma + valorNumerico(Grid.Cell(count, Col).Text)
                End If
                count = count + 1
            End While
        Catch ex As Exception
            HandleError("Mod_Grid", "FG_Grid_SumaColNegativos", ex)
        End Try
        Return Suma
    End Function
End Module
