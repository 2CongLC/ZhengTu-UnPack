Imports System
Imports System.Text
Imports System.IO
Imports System.IO.Compression


Module Program

    Private br As BinaryReader
    Private des As String
    Private source As String
    Private buffer As Byte()
    Private subfiles As New List(Of FileData)()

    Sub Main(args As String())

        If args.Count = 0 Then
            Console.WriteLine("UnPack Tool - 2CongLC.vn")
        Else
            source = args(0)
        End If

        If IO.File.Exists(source) Then

            des = Path.GetDirectoryName(source) + "\" + Path.GetFileNameWithoutExtension(source) + "\"
            br = New BinaryReader(IO.File.OpenRead(source))


        End If
        Console.ReadLine()
    End Sub



    Class FileData

    End Class
End Module
