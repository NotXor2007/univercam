Imports System.IO
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
            If flag == "w" Then
                writer = New StreamWriter(filepath, append:=True)
            ElseIf flag == "a" Then
                writer = New StreamWriter(filepath, write:=True)
            writer.WriteLine(data)
            writer.Close()
        End Sub

    End Module

End Namespace

Namespace Engines

    Public Class AutomaticGenerate

        Private Dim _FilePath as String
        Private Dim _FetchData as Boolean
        

        Public Sub New( ByVal FilePath as String )
            _FilePath = FilePath
            _FetchData = False
            _Writer = New StreamWriter( FilePath )
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
                            IF Utilities.FileUtils.GetFileSize( _FilePath ) <= &H5f5e100 Then
                                _Writer.WriteLine( value4 & "." & value3 & "." & value2 & "." & value1)
                            Else
                                _Writer.Close()
                                Utilities.Kernel32.Sleep(2000)
                                _Writer = New StreamWriter(_FilePath)
                            End IF
                        Next value1
                    Next value2
                Next value3
            Next value4
        Console.Write( "Finished press Ctrl+C to exit" )
        End Sub

        Public Sub RemoveFile()
            _Writer.Close()
            Utilities.FileUtils.DeleteFile(_FilePath)
        End Sub
    
    End Class

End Namespace
