Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class Class_Contabilidad_IVA_Acreditable_DIOT

#Region "Campos"
#Region "Campos de la tabla"
    Private _TotalActos0 As Double = 0, _TotalActos16 As Double = 0, _TotalActos15 As Double = 0, _TotalActos11 As Double = 0, _TotalActos10 As Double = 0, _TotalActos As Double = 0
    Private _TotalIVAAcreditable16 As Double = 0, _TotalIVARetenido4 As Double = 0
#End Region

#Region "Campos de sistema"
    Private _Conexion As SqlConnection
#End Region
#End Region

#Region "Propiedades"
#Region "Propiedades Campos de la tabla"
    Public ReadOnly Property TotalActos0 As Double
        Get
            Return Me._TotalActos0
        End Get
    End Property
    Public ReadOnly Property TotalActos16 As Double
        Get
            Return Me._TotalActos16
        End Get
    End Property
    Public ReadOnly Property TotalActos15 As Double
        Get
            Return Me._TotalActos15
        End Get
    End Property
    Public ReadOnly Property TotalActos11 As Double
        Get
            Return Me._TotalActos11
        End Get
    End Property
    Public ReadOnly Property TotalActos10 As Double
        Get
            Return Me._TotalActos10
        End Get
    End Property
    Public ReadOnly Property TotalActos As Double
        Get
            Return Me._TotalActos
        End Get
    End Property
    Public ReadOnly Property TotalIVAAcreditable16 As Double
        Get
            Return Me._TotalIVAAcreditable16
        End Get
    End Property
    Public ReadOnly Property TotalIVARetenido4 As Double
        Get
            Return Me._TotalIVARetenido4
        End Get
    End Property
#End Region

#Region "Propiedad Nombre de Clase"
    Public ReadOnly Property Nombre_Clase() As String
        Get
            Return "Class_Contabilidad_IVA_Acreditable_Global"
        End Get
    End Property
#End Region
#End Region

#Region "Constructor y destructor"
    Public Sub New()
        Me._Conexion = New SqlConnection
        Me._Conexion.ConnectionString = Empresa_Sistema.conexion
    End Sub

    Protected Overrides Sub Finalize()
        'Me._Conexion.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

#Region "Métodos y procedimientos"
    Public Function GeneraArchivoBatch(ByVal sFecha1 As String, ByVal sFecha2 As String, ByVal sUsarFechaCobro As String) As Boolean
        Dim bResultado As Boolean = False
        Dim sCarpeta As String, sArchivo As String
        Dim cmd As New SqlCommand, dReader As SqlDataReader, sqlParametro As SqlParameter
        Dim strStreamW As Stream = Nothing, strStreamWriter As StreamWriter = Nothing

        Me._TotalActos0 = 0 : Me._TotalActos16 = 0 : Me._TotalActos15 = 0 : Me._TotalActos11 = 0 : Me._TotalActos10 = 0

        Try
            sCarpeta = My.Settings.Ruta & "\Iva acreditable"
            sArchivo = sCarpeta & "\" & Empresa_Sistema.RFC & "-" & Format(Now, "ddMMyy") & ".txt"

            If txtLEN(Dir$(sCarpeta, vbDirectory)) = False Then
                MkDir(sCarpeta)
            End If

            If isExisteArchivo(sArchivo) = True Then
                If MsgBox("El archivo " & sArchivo & " ya existe, desea sobreescribirlo?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, Me.Nombre_Clase) = vbNo Then
                    MsgBox("No se generó el archivo.", vbExclamation, Me.Nombre_Clase)
                    Exit Function
                Else
                    File.Delete(sArchivo)
                End If
            End If

            strStreamW = File.Create(sArchivo)
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            With cmd
                .Connection = Me._Conexion
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MP_RPT_CONTABILIDAD_IVA_ACREDITABLE_ARCHIVO_DIOT"

                sqlParametro = .Parameters.Add("@FECHA1", SqlDbType.NVarChar, 20) : sqlParametro.Value = sFecha1
                sqlParametro = .Parameters.Add("@FECHA2", SqlDbType.NVarChar, 20) : sqlParametro.Value = sFecha2
                sqlParametro = .Parameters.Add("@USAR_FECHA_COBRO", SqlDbType.Char, 1) : sqlParametro.Value = sUsarFechaCobro
                Try
                    Me._Conexion.Open()
                    dReader = .ExecuteReader()

                    While dReader.Read
                        strStreamWriter.WriteLine("" & dReader("CADENA_BATCH").ToString)

                        Me._TotalActos0 += valorNumerico("" & dReader("TOTAL_ACTOS_AL_0").ToString)
                        Me._TotalActos16 += valorNumerico("" & dReader("TOTAL_ACTOS_AL_16").ToString)
                        Me._TotalActos15 += valorNumerico("" & dReader("TOTAL_ACTOS_AL_15").ToString)
                        Me._TotalActos11 += valorNumerico("" & dReader("TOTAL_ACTOS_AL_11").ToString)
                        Me._TotalActos10 += valorNumerico("" & dReader("TOTAL_ACTOS_AL_10").ToString)
                        Me._TotalIVAAcreditable16 += valorNumerico("" & dReader("TOTAL_IVA_ACREDITABLE_AL_16").ToString)
                        Me._TotalIVARetenido4 += valorNumerico("" & dReader("TOTAL_IVA_RETENIDO_AL_4").ToString)
                        Me._TotalActos = Me._TotalActos0 + Me._TotalActos16 + Me._TotalActos15 + Me._TotalActos11 + Me._TotalActos10
                    End While

                    'Me._CodigoCliente = "" & dReader("CODIGO_CLIENTE")

                    dReader.Close()

                    bResultado = True
                Catch ex As Exception
                    HandleError(Me.Nombre_Clase, "Consultar", ex)
                Finally
                    Me._Conexion.Close()
                    cmd.Dispose()
                End Try
            End With

            strStreamWriter.Close() 'Cerramos

            'Me._TotalActos0 = FormatImporteContable(dTotalActos0, True)
            'Me._TotalActos16 = FormatImporteContable(dTotalActos16, True)
            'Me._TotalActos = FormatImporteContable(dTotalActos0 + dTotalActos10 + dTotalActos15 + dTotalActos11 + dTotalActos16, True)

            If bResultado = True Then
                MsgBox("El archivo fue generado con éxito en la ruta: " & vbCrLf & sArchivo, vbInformation, Me.Nombre_Clase)
            End If

        Catch ex As Exception
            HandleError(Me.Nombre_Clase, "GeneraArchivoBatch", ex)
        End Try

        Return bResultado
    End Function

#End Region

End Class
