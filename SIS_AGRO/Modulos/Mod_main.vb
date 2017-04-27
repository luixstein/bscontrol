Option Strict On

Imports System.IO

Module Mod_main
    Private Const nombreModulo As String = "Mod_main"

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
        My.Forms.AppMenu.Text = Empresa_Sistema.NOMBRE_EMPRESA.ToString & " | Plaza: " & Usuario.Codigo_Plaza & "-" & Plaza.NOMBRE_PLAZA & " | Usuario: " & Usuario.Nombre_Usuario & " |  Ejercicio: " & Plaza.NOMBRE_EJERCICIO
        My.Forms.AppMenu.ToolStripStatusLabel.Text = "Server: " & Empresa_Sistema.Servidor & " | BD: " & Empresa_Sistema.BaseDatos & " | " & String.Format("Revisión {0}", My.Application.Info.Version.ToString) & ""
    End Sub

    Public Sub GestionaExeCarpetaUsuario()
        Const sProcedure As String = "GestionaExeCarpetaUsuario"
        Dim bModoExeCarpetaUsuario As Boolean

        Dim sNombreUserWin As String = Environ("USERNAME")
        Dim sRootUser As String = "USER_" & sNombreUserWin
        Dim sCarpetaUsuario As String = My.Settings.Ruta & "\" & sRootUser

        Dim sOrigen As String = My.Settings.Ruta & "\BsControl.EXE"
        Dim sDestino As String = sCarpetaUsuario & "\BsControl.EXE"
        Dim sDestinoConfig As String = sCarpetaUsuario & "\BsControl.EXE.CONFIG"

        Try
            'cachar el comando mandado desde el exe para que no se cicle
            If Command() = "enCarpetaUsuario" Then
                bModoExeCarpetaUsuario = True
            End If

            If bModoExeCarpetaUsuario = False Then
                If Len(Dir(sCarpetaUsuario, FileAttribute.Directory)) = 0 Then
                    MkDir(sCarpetaUsuario)
                    If txtLEN(Dir(sCarpetaUsuario, FileAttribute.Directory)) = False Then
                        MsgBox("No se logró crear la carpeta de trabajo local por usuario, avíse al depto. de sistemas.", vbExclamation, sProcedure)
                        Mod_main.Finaliza(False)
                        Exit Sub
                    End If
                End If

                Copiar_Archivo(sOrigen, sDestino)
                Copiar_Archivo(sOrigen & ".CONFIG", sDestinoConfig)

                If Len(Dir(sDestino)) = 0 Then
                    MsgBox("No se logró copiar el archivo del sistema local por usuario, avíse al depto. de sistemas.", vbExclamation, sProcedure)
                    Mod_main.Finaliza(False)
                    Exit Sub
                End If

                If Len(Dir(sDestinoConfig)) = 0 Then
                    MsgBox("No se logró copiar el archivo de configuración del sistema local por usuario, avíse al depto. de sistemas.", vbExclamation, sProcedure)
                    Mod_main.Finaliza(False)
                    Exit Sub
                End If

                'Copia todas las dlls que en ese momento estén en la carpeta del root
                'Nota revisar como hacer para que caundo se actualize una dlls a nueva versión, estas sean por cliente.
                Dim sArchivoDestino As String
                For Each fichero As String In Directory.GetFiles(My.Settings.Ruta, "*.dll")
                    'File.Delete(fichero)
                    sOrigen = fichero
                    sArchivoDestino = sCarpetaUsuario & "\" & Path.GetFileName(fichero)
                    Copiar_Archivo(sOrigen, sArchivoDestino)
                Next

                Dim proces As New Process()
                'proces.StartInfo.FileName = sComando
                Process.Start(sDestino, "enCarpetaUsuario")

                Mod_main.Finaliza(False)
            End If

        Catch ex As Exception
            HandleError(nombreModulo, sProcedure, ex)
            Mod_main.Finaliza(False)
        End Try
    End Sub
End Module
