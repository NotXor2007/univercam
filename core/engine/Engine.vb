Imports System.IO
Imports System.IO.Pipes
Imports System.Runtime.InteropServices

Namespace Utilities

    Module Kernel32
        <DllImport("kernel32.dll")>
        Public Sub Sleep(ByVal dwMilliSeconds as UInteger)
        End Sub
    End Module

    Module FileUtils

        Dim DataBuffer as String
        Dim writer as StreamWriter
        Dim reader as StreamReader

        Function GetFileSize(ByVal filepath as String) As Double
            Dim Info as FileInfo = New FileInfo(filepath)
            If Info.Exists Then
                Return Info.Length
            Else
                Return 1
            End If
        End Function

        Sub DeleteFile(ByVal filepath as String)
            If File.Exists(filepath) Then
                File.Delete(filepath)
            End IF
        End Sub

        Function ReadFile(ByVal filepath as String)
            reader = New StreamReader(filepath)
            Dim line as String = reader.ReadLine()
            Do
                If line Is Nothing Then
                    reader = New StreamReader(filepath)
                    line = reader.ReadLine()
                Else
                    DataBuffer = line
                    line = reader.ReadLine()
                End IF
            Loop
        End Function

        Sub WriteFile(ByVal filepath as String, ByVal data as String, ByVal flag as String)
            If flag = "w" Then
                writer = New StreamWriter(filepath, append:=True)
            ElseIf flag = "a" Then
                writer = New StreamWriter(filepath, append:=False)
            End IF
            writer.WriteLine(data)
            writer.Close()
        End Sub

    End Module

End Namespace

Namespace Engines

    Public Class AutomaticGenerate

        Private Dim _FilePath as String
        Private Dim _FetchData as Boolean
        Private Dim _Ip as String

        Public Sub New( ByVal FilePath as String )
            _FilePath = FilePath
            _FetchData = False
        End Sub

        Public ReadOnly Property GetFetch() as Boolean
            Get
                Return _FetchData
            End Get
        End Property

        Public WriteOnly Property SetFetch() as Boolean
            Set(ByVal value as Boolean)
                _FetchData = value
            End Set
        End Property

        Public Sub GenerateIp()
            For value4 as  Integer = 0 To &HFF
                For value3 as Integer = 0 To &HFF
                    For value2 as Integer = 0 To &HFF
                        For value1 as Integer = 0 To &HFF
                            _Ip = value4.ToString()&"."&value3.ToString()&"."&value2.ToString()&"."&value1.ToString()
                            IF Utilities.FileUtils.GetFileSize( _FilePath ) <= &H5f5e100 Then
                                Utilities.FileUtils.WriteFile(_FilePath,_Ip,"a")
                            Else
                                Utilities.Kernel32.Sleep(2000)
                                Utilities.FileUtils.WriteFile(_FilePath,_Ip,"w")
                            End IF
                        Next value1
                    Next value2
                Next value3
            Next value4
        Console.Write( "Finished press Ctrl+C to exit" )
        End Sub

        Public Sub RemoveFile()
            Utilities.FileUtils.DeleteFile(_FilePath)
        End Sub
    
    End Class

End Namespace
