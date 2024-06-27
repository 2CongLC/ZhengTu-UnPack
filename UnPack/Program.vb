Imports System
Imports System.Text
Imports System.IO
Imports System.IO.Compression


Module Program

    Private br As BinaryReader
    Private des As String
    Private source As String
    Private buffer As Byte()
    Private subtables As New List(Of TableData)()
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
            Dim sign As String = New String(br.ReadChars(4))
            Dim unknow1 As Int32 = br.ReadInt32
            Dim count_FileData As Int32 = br.ReadInt32
            Dim unknow3 As Int32 = br.ReadInt32
            Dim unknow4 As Int32 = br.ReadInt32
            Dim unknow5 As Int32 = br.ReadInt32
            Dim unknow6 As Int32 = br.ReadInt32
            Dim unknow7 As String = br.ReadInt32


            Console.WriteLine("signarute : {0}", sign)
            Console.WriteLine("unknow1 : {0}", unknow1)
            Console.WriteLine("unknow2 : {0}", count_FileData)
            Console.WriteLine("unknow3 : {0}", unknow3)
            Console.WriteLine("unknow4 : {0}", unknow4)
            Console.WriteLine("unknow5 : {0}", unknow5)
            Console.WriteLine("unknow6 : {0}", unknow6)
            Console.WriteLine("unknow7 : {0}", unknow7)


            For i As Int32 = 0 To count_FileData - 1
                subtables.Add(New TableData)
            Next

            For Each td As TableData In subtables
                br.BaseStream.Position = td.offset
                If td.count < 300 Then
                    For j As Int32 = 0 To td.count - 1
                        subfiles.Add(New FileData)
                    Next
                End If
            Next


            For Each fd As FileData In subfiles
                Console.WriteLine("unknow1 : {0}", fd.unknow1)
                Console.WriteLine("unknow2 : {0}", fd.unknow2)
                Console.WriteLine("unknow3 : {0}", fd.unknow3)
            Next


        End If
        Console.ReadLine()
    End Sub

    Class TableData
        Public count As UInt32 = br.ReadUInt32
        Public offset As UInt32 = br.ReadUInt32
        Public types As UInt32 = br.ReadUInt32
    End Class

    Class FileData
        Public unknow1 As UInt32 = br.ReadUInt32
        Public unknow2 As UInt32 = br.ReadUInt32
        Public unknow3 As UInt32 = br.ReadUInt32
    End Class
End Module
