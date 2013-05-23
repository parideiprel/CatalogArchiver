Module Module1
    Dim FileNewInFolder As Integer
    Dim FileReplaceInFolder As Integer

    Sub Main()

        'Console.Write(My.Settings.SevenZip)
        checkFolder()
        Select Case FileNewInFolder
            Case Is 0
                'se zero non faccio niente ed esco
                Exit Select

            Case Is > 0
                'se >0 processo i file

            Case Else
                'genero errore


        End Select


    End Sub

    Function getCounter()
        Return 0

    End Function

    Function setCounter()
        Return 0

    End Function

    Function createFolder()
        Return 0

    End Function

    Function copyFileToFolder()
        Return 0

    End Function

    Function compressFolder()
        Return 0

    End Function


    Sub checkFolder()
        'controlla se ci sono file nella cartella
        FileNewInFolder = FileIO.FileSystem.GetDirectoryInfo(My.Settings.TableIsNewFolder).EnumerateFiles.Count()
        FileReplaceInFolder = FileIO.FileSystem.GetDirectoryInfo(My.Settings.TableToReplaceFolder).EnumerateFiles.Count()


    End Sub

End Module
