Public Class Class_GridBusqueda
    Inherits DataGrid
    Public Event keyEnter_presed()
    Public Event keyF6_presed()

    'Private Const WM_KEYDOWN As Integer = &H100
    'Private Const WM_KEYUP As Integer = &H101
    'Private Const WM_CHAR As Integer = &H102
    Public Sub New()
        Me.RowHeadersVisible = False
        Me.ReadOnly = True
    End Sub

    Protected Overrides Function ProcessKeyPreview(ByRef m As System.Windows.Forms.Message) As Boolean
        Dim keyCode As Keys

        keyCode = CType(m.WParam.ToInt32, Keys)
        Select Case keyCode
            Case Keys.Enter
                If CStr(Me.Tag) <> "X" Then
                    RaiseEvent keyEnter_presed()
                    Me.Tag = "X"
                Else
                    Me.Tag = ""
                End If
                Return False
            Case Keys.F6
                RaiseEvent keyF6_presed()
                Return False
            Case Keys.Down
                If CStr(Me.Tag) <> "X" Then
                    Me.CurrentCell = New DataGridCell(Me.CurrentCell.RowNumber + 1, Me.CurrentCell.ColumnNumber)
                    'Me.Tag = "X"
                Else
                    Me.Tag = ""
                End If
            Case Keys.Up
                If CStr(Me.Tag) <> "X" Then
                    Me.CurrentCell = New DataGridCell(Me.CurrentCell.RowNumber - 1, Me.CurrentCell.ColumnNumber)
                    'Me.Tag = "X"
                Else
                    Me.Tag = ""
                End If
            Case Keys.Left
                'If Me.Tag <> "X" Then
                Me.CurrentCell = New DataGridCell(Me.CurrentCell.RowNumber, Me.CurrentCell.ColumnNumber - 1)
                Me.Tag = "X"
                'Else
                '    Me.Tag = ""
                'End If

            Case Keys.Right
                If CStr(Me.Tag) <> "X" Then
                    Me.CurrentCell = New DataGridCell(Me.CurrentCell.RowNumber, Me.CurrentCell.ColumnNumber + 1)
                    Me.Tag = "X"
                Else
                    Me.Tag = ""
                End If
        End Select
    End Function

    Public Sub inicia(ByVal sTabla As String)
        Dim tablestyle As DataGridTableStyle
        tablestyle = New DataGridTableStyle
        tablestyle.MappingName = CStr(sTabla)
        Me.TableStyles.Clear()
        Me.TableStyles.Add(tablestyle)
    End Sub

End Class
