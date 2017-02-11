Option Strict On
Module Mod_main
    Public Empresa_Sistema As New Class_sisEmpresa
    Public EmpresaParametros As New Class_SisContabilidadParametros(True)
    Public Usuario As New Class_sisUsuarios(True, True)
    Public Plaza As New Class_SisPlazas(True, True)
    
    Public Loginfo As CrystalDecisions.Shared.ConnectionInfo
    'DSN DINAMICO
    Public DSNBaseOperativa As String
    Public Running As Boolean

    Public Function Finaliza(Optional ByVal MostrarMensajeSalida As Boolean = True) As Boolean
        If Running Then
            If MostrarMensajeSalida Then
                If MsgBox("¿ Deseas salir del sistema ?", CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), "Sistema de administracion de punto de venta.") = MsgBoxResult.Yes Then
                    Running = False
                    Empresa_Sistema = Nothing
                    Usuario = Nothing
                    Plaza = Nothing
                    Application.Exit()
                    End
                Else
                    Return False
                End If
            End If
        End If

        Running = False
        Empresa_Sistema = Nothing
        Usuario = Nothing
        Plaza = Nothing
        Application.Exit()
        End
    End Function

    Public Sub EstableceDescripcionMenu()
        My.Forms.AppMenu.Text = Empresa_Sistema.Nombre_empresa.ToString & " | Plaza: " & Usuario.Codigo_Plaza & "-" & Plaza.NOMBRE_PLAZA & " | Usuario: " & Usuario.Nombre_Usuario & " |  Ejercicio: " & Plaza.NOMBRE_EJERCICIO
        My.Forms.AppMenu.ToolStripStatusLabel.Text = "Server: " & Empresa_Sistema.Servidor & " | BD: " & Empresa_Sistema.BaseDatos & " | " & String.Format("Revisión {0}", My.Application.Info.Version.ToString) & ""
    End Sub

End Module
