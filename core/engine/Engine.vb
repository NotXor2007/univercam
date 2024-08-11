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
            If flag = "a" Then
                writer = New StreamWriter(filepath, append:=True)
            ElseIf flag = "w" Then
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
        Private Dim _Ip as String
        Private Dim _StartWrite as Boolean
        Private Dim _GIPV4 As Integer,_GIPV3 As Integer,_GIPV2 As Integer,_GIPV1 As Integer

        Public Sub New( ByVal FilePath as String )
            _FilePath = FilePath
            _StartWrite = True
            _GIPV1 = 0
            _GIPV2 = 0
            _GIPV3 = 0
            _GIPV4 = 0
        End Sub

        Public WriteOnly Property SetSave() as Boolean
            Set(ByVal value as Boolean)
                _GIPV1 = value
                _GIPV2 = value
                _GIPV3 = value
                _GIPV4 = value
            End Set
        End Property

        Public Sub GenerateIp()
            For value4 as  Integer = _GIPV4 To &HFF
                For value3 as Integer = _GIPV3 To &HFF
                    For value2 as Integer = _GIPV2 To &HFF
                        For value1 as Integer = _GIPV1 To &HFF
                            _GIPV1 = value1
                            _GIPV2 = value2
                            _GIPV3 = value3
                            _GIPV4 = value4
                            _Ip = value4.ToString()&"."&value3.ToString()&"."&value2.ToString()&"."&value1.ToString()
                            IF Utilities.FileUtils.GetFileSize( _FilePath ) < &H5f5e102 And Not _StartWrite Then
                                Utilities.FileUtils.WriteFile(_FilePath,_Ip,"a")
                            ElseIF _StartWrite Then
                                Utilities.Kernel32.Sleep(1000)
                                Utilities.FileUtils.WriteFile(_FilePath,_Ip,"w")
                                _StartWrite = False
                            Else
                                _StartWrite = True
                                Return
                            End IF
                            IF _GIPV1=255 Then 
                                _GIPV1 = 0
                            End If
                            IF _GIPV2=255 Then 
                                _GIPV2 = 0
                            End If
                            IF _GIPV3=255 Then 
                                _GIPV3 = 0
                            End If
                            IF _GIPV4=255 Then 
                                _GIPV4 = 0
                            End IF 
                        Next value1
                    Next value2
                Next value3
            Next value4
        End Sub

        Public Sub RemoveFile()
            Utilities.FileUtils.DeleteFile(_FilePath)
        End Sub
    
    End Class

End Namespace
