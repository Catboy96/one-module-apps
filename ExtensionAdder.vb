Imports System.IO

Module ExtensionAdder

    Sub Main()

        Console.WriteLine("Extension Adder")
        Console.WriteLine("(C) 2018 Ralf Ren <me@ralf.ren>")
        Console.WriteLine("")

        Dim path As String
        If Environment.GetCommandLineArgs.Length = 1 Then
            Console.Write("Specify a file or a directory: ")
            path = Console.ReadLine()
        Else
            path = Environment.GetCommandLineArgs(1)
        End If

        Console.WriteLine("")
        If IO.Directory.Exists(path) Then
            renameDir(path)
        ElseIf IO.File.Exists(path) Then
            renameFile(path)
        Else
            Console.WriteLine("The specified path is invalid.")
            Exit Sub
        End If

    End Sub

    Sub renameDir(path As String)
        Console.Write("Add extension (example: txt): ")
        Dim ext As String = Console.ReadLine()
        Dim f As String = ""
        Try
            For Each f In Directory.GetFiles(path)
                File.Move(f, f & $".{ext}")
                Console.WriteLine($"Renamed [{f}] to [{f}.{ext}]")
            Next
        Catch ex As Exception
            Console.WriteLine($"Cannot rename {f}: {ex.Message}")
            Exit Sub
        End Try
    End Sub

    Sub renameFile(path As String)
        Console.Write("Add extension (example: txt): ")
        Dim ext As String = Console.ReadLine()

        Try
            File.Move(path, path & $".{ext}")
            Console.WriteLine($"Renamed [{path}] to [{path}.{ext}]")
        Catch ex As Exception
            Console.WriteLine($"Cannot rename {path}: {ex.Message}")
            Exit Sub
        End Try
    End Sub

End Module
