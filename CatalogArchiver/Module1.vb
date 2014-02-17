Module Module1
    Dim FileNewInFolder As Integer
    Dim FileReplaceInFolder As Integer
    'Public appSettings = Application.StartupPath + "\Files\appSettings.config"
    'Public pathRepository As String

    Sub Main()

        'If System.IO.File.Exists(appSettings) = True Then
        '    Dim xmlDoc As New Xml.XmlDocument()
        '    xmlDoc.Load(appSettings)
        '    Dim xn As Xml.XmlNode
        '    xn = xmlDoc.SelectSingleNode("Settings/PathRepository")
        '    If IsDBNull(xn) = True Then
        '        MsgBox("Errore: Nodo nullo!", vbOKOnly, "Errore XML")
        '        End
        '    End If
        '    pathRepository = Convert.ToString(xn.InnerText)

        '    xn = xmlDoc.SelectSingleNode("Settings/PathServer")
        '    If IsDBNull(xn) = True Then
        '        MsgBox("Errore: Nodo nullo!", vbOKOnly, "Errore XML")
        '        End
        '    End If
        '    pathServer = Convert.ToString(xn.InnerText)
        'Else
        '    MsgBox("Impossibile trovare file appSettings!", vbOKOnly, "Errore file mancante")
        '    End
        'End If
        'TextBox1.Focus()

        'Console.Write(My.Settings.SevenZip)
        checkFolder()
        Select Case FileNewInFolder
            Case Is = 0
                'se zero non faccio niente ed esco
                Exit Select

            Case Is > 0
                'se >0 processo i file

            Case Else
                'genero errore ed esco


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
        ' FileNewInFolder = FileIO.FileSystem.GetDirectoryInfo(My.Settings.TableIsNewFolder).EnumerateFiles.Count()
        ' FileReplaceInFolder = FileIO.FileSystem.GetDirectoryInfo(My.Settings.TableToReplaceFolder).EnumerateFiles.Count()


    End Sub

End Module
