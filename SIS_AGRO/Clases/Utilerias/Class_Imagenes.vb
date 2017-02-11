Imports System.IO
Imports System.Reflection

Public Class Class_Imagenes
    Friend Shared Function IconoMas() As Bitmap
        Dim _imageStream As Stream
        Dim _assembly As [Assembly]

        _assembly = [Assembly].GetExecutingAssembly()
        _imageStream = _assembly.GetManifestResourceStream("Agrocontrol.IconoMas.bmp")

        Return New Bitmap(_imageStream)
    End Function

    Friend Shared Function IconoMenos() As Bitmap
        Dim _imageStream As Stream
        Dim _assembly As [Assembly]

        _assembly = [Assembly].GetExecutingAssembly()
        _imageStream = _assembly.GetManifestResourceStream("Agrocontrol.IconoMenos.bmp")

        Return New Bitmap(_imageStream)
    End Function
End Class
