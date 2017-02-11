Imports System.Data.SqlClient

Public Class Class_find

#Region "Variables de retorno"
    Private _Result1 As String = ""
    Private _Result2 As String = ""
    Private _Result3 As String = ""
    Private _Result4 As String = ""
    Private _Result5 As String = ""
    Private dRow As Data.DataRow
#End Region

#Region "Variables de proceso"
    Private myCnn As SqlConnection
    Private myQuery As String
    Private _sTabla As String, _sCampo As String, _sFiltro As String
#End Region

#Region "Propiedades "
    Public ReadOnly Property dataRow() As Data.DataRow
        Get
            Return dRow
        End Get
    End Property

    Public ReadOnly Property Result1() As String
        Get
            Return _Result1
        End Get
    End Property

    Public ReadOnly Property Result2() As String
        Get
            Return _Result2
        End Get
    End Property

    Public ReadOnly Property Result3() As String
        Get
            Return _Result3
        End Get
    End Property

    Public ReadOnly Property Result4() As String
        Get
            Return _Result4
        End Get
    End Property

    Public ReadOnly Property Result5() As String
        Get
            Return _Result5
        End Get
    End Property
#End Region

#Region "Metodos "
        Public Sub New(ByVal sql As String)
        myCnn = New SqlConnection
        myCnn.ConnectionString = Empresa_Sistema.conexion
        myQuery = sql
        Call Consulta_bd()
    End Sub

    Private Sub Consulta_bd()
        Dim cmd As New SqlCommand(myQuery, myCnn)
        Dim drFind As SqlDataReader
        Try
            myCnn.Open()
            drFind = cmd.ExecuteReader
            If drFind.Read Then
                If drFind.FieldCount > 0 Then
                    _Result1 = "" & CStr(drFind(0).ToString)
                End If
                If drFind.FieldCount > 1 Then
                    _Result2 = "" & CStr(drFind(1).ToString)
                End If
                If drFind.FieldCount > 2 Then
                    _Result3 = "" & CStr(drFind(2).ToString)
                End If
                If drFind.FieldCount > 3 Then
                    _Result4 = "" & CStr(drFind(3).ToString)
                End If
                If drFind.FieldCount > 4 Then
                    _Result5 = "" & CStr(drFind(4).ToString)
                End If
            Else
                _Result1 = ""
                _Result2 = ""
                _Result3 = ""
                _Result4 = ""
                _Result5 = ""
            End If
        Catch ex As Exception
            HandleError("cls-Find", "Consulta_bd", ex)
        Finally
            myCnn.Close()
            cmd.Dispose() : myCnn.Dispose()
        End Try
    End Sub
#End Region

End Class
