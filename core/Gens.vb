Imports System.IO

Module Program

    Function GetFileSize(ByVal filepath as String) As Double
        Dim Info as FileInfo = New FileInfo(filepath)
        If Info.Exists Then
            Return Info.Length
        Else
            Return 1
        End If
    End Function
    

    Sub GenerateIp(ByVal writer as StreamWriter)
        For value4 as Integer = 0 To 255
            For value3 as Integer = 0 To 255
                For value2 as Integer = 0 To 255
                    For value1 as Integer = 0 To 255
                        writer.WriteLine( value4 & "." & value3 & "." & value2 & "." & value1)
                    Next value1
                Next value2
            Next value3
        Next value4
        Console.Write( "Finished press Ctrl+C to exit" )
    End Sub

    Sub Main(ByVal args as String() )
        Dim Writer as StreamWriter = New StreamWriter( args(0) )
        GenerateIp(Writer)
    End Sub

End Module
