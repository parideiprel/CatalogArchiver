Imports System.Net.Mail

Public Class frmMain
    Public appSettings = Application.StartupPath + "\Files\appSettings.config"
    Public pathRepository As String
    Public pathCataloghi As String
    Public pathServer As String
    Public smtpAddress As String
    Public mailTo As String
    Public mailFrom As String

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        If System.IO.File.Exists(appSettings) = True Then
            Dim xmlDoc As New Xml.XmlDocument()
            xmlDoc.Load(appSettings)
            Dim xn As Xml.XmlNode
            xn = xmlDoc.SelectSingleNode("Settings/PathRepository")
            If IsDBNull(xn) = True Then
                MsgBox("Errore: Nodo nullo!", vbOKOnly, "Errore XML")
                End
            End If
            pathRepository = Convert.ToString(xn.InnerText)

            xn = xmlDoc.SelectSingleNode("Settings/PathServer")
            If IsDBNull(xn) = True Then
                MsgBox("Errore: Nodo nullo!", vbOKOnly, "Errore XML")
                End
            End If
            pathServer = Convert.ToString(xn.InnerText)

            xn = xmlDoc.SelectSingleNode("Settings/SmtpServer")
            If IsDBNull(xn) = True Then
                MsgBox("Errore: Nodo nullo!", vbOKOnly, "Errore XML")
                End
            End If
            smtpAddress = Convert.ToString(xn.InnerText)

            xn = xmlDoc.SelectSingleNode("Settings/SendTo")
            If IsDBNull(xn) = True Then
                MsgBox("Errore: Nodo nullo!", vbOKOnly, "Errore XML")
                End
            End If
            mailTo = Convert.ToString(xn.InnerText)

            xn = xmlDoc.SelectSingleNode("Settings/From")
            If IsDBNull(xn) = True Then
                MsgBox("Errore: Nodo nullo!", vbOKOnly, "Errore XML")
                End
            End If
            mailFrom = Convert.ToString(xn.InnerText)
        Else
            MsgBox("Impossibile trovare file appSettings!", vbOKOnly, "Errore file mancante")
            End
        End If
        TextBox1.Focus()

    End Sub


    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs)
        End

    End Sub

    Private Sub btnArchiviaTavoleNew_Click(sender As Object, e As EventArgs) Handles btnArchiviaTavoleNew.Click
        Dim f As System.IO.FileInfo
        Dim x As Integer
        Dim y As Integer
        Dim contami As Integer
        Dim attachSize As Int64

        If TextBox1.Text = "" Or Len(TextBox1.Text) <> 4 Then
            MsgBox("ERRORE! Inserire un catalogo", vbOKOnly, "ERRORE")
            TextBox1.Focus()
            Exit Sub
        End If
        TextBox1.Text = UCase(TextBox1.Text)

        Dim dirFiles() As String
        Dim dirFilesQ() As String
        Dim dirFilesT() As String

        dirFiles = System.IO.Directory.GetFiles(pathRepository + "\" + Trim(TextBox1.Text), "*.pdf")
        x = 0
        y = 0
        contami = dirFiles.Count

        dirFilesQ = New String(contami) {}
        dirFilesT = New String(contami) {}

        ' verifico se sono delle tavole Qxx
        'If dirFiles.First.Substring(9, 2)
        For Each qFile As String In dirFiles
            If qFile.Contains("Q00") Then
                ' è una tavola Q00 quindi va mandata per email
                ' aggiungo il file alla lista dirFilesQ()
                dirFilesQ(x) = qFile
                x = x + 1

            End If

            If qFile.Contains("Q01") Then
                ' è una tavola Q01 quindi va mandata per email
                ' aggiungo il file alla lista dirFilesQ()
                dirFilesQ(x) = qFile
                x = x + 1

            End If

            If qFile.Contains("Q02") Then
                ' è una tavola Q0" quindi va mandata per email
                ' aggiungo il file alla lista dirFilesQ()
                dirFilesQ(x) = qFile
                x = x + 1

            End If

            If Not qFile.Contains("Q00") And Not qFile.Contains("Q01") And Not qFile.Contains("Q02") Then
                ' siccome non è una tavola Q00 / Q01 o Q02
                ' l'aggiungo all'array delle tavole da archiviare
                ' con il TableArchiverServer
                dirFilesT(y) = qFile
                y = y + 1
            End If

        Next

        ' ridimensiono gli array delle liste in base ai contatori X e Y diminuiti di 1
        ReDim Preserve dirFilesQ(x - 1)
        ReDim Preserve dirFilesT(y - 1)

        Dim messaggio As String

        messaggio = "Risultato tavole trovate per " + Trim(TextBox1.Text)
        messaggio = messaggio + vbCrLf + vbCrLf + "Tavole Q00 / Q01 / Q02:     " + dirFilesQ.Count.ToString
        messaggio = messaggio + vbCrLf + vbCrLf + "Tavole normali:     " + dirFilesT.Count.ToString

        Dim gneppo = MsgBox(messaggio + vbCrLf + vbCrLf + "Continuo ?", vbOKCancel, "Info")
        If gneppo = vbOK Then
            For Each sFile As String In dirFilesT
                f = New System.IO.FileInfo(sFile)
                'Console.WriteLine(f.Name)
                f.CopyTo(pathServer + "\N\" + f.Name, True)
            Next

            'For Each sFile As String In dirFilesQ
            '    f = New System.IO.FileInfo(sFile)
            '    'Console.WriteLine(f.Name)
            '    f.CopyTo(pathServer + "\Att\" + f.Name, True)
            'Next

        Else
            Exit Sub
        End If

        TextBox1.Text = ""
        TextBox1.Focus()

        If dirFilesQ.Count > 0 Then
            ' send EMAIL !!!
            'create the mail message
            Dim mail As New MailMessage()

            'set the addresses
            mail.From = New MailAddress(mailFrom)
            mail.To.Add(mailTo)
            Dim user() As String
            user = mailFrom.Split("_")

            'set the content
            mail.Subject = "Tavole Q00"
            mail.Body = "Me le archivieresti ?" + vbCrLf + vbCrLf + "Grazie 1000" + vbCrLf + vbCrLf + "--------" + vbCrLf + UCase(user(0))

            ''add an attachment from the filesystem
            'mail.Attachments.Add(New Attachment("c:\temp\example.txt"))

            ''to add additional attachments, simply call .Add(...) again
            'mail.Attachments.Add(New Attachment("c:\temp\example2.txt"))
            'mail.Attachments.Add(New Attachment("c:\temp\example3.txt"))
            For Each sFile As String In dirFilesQ
                f = New System.IO.FileInfo(sFile)
                attachSize = attachSize + f.Length
            Next
            If Math.Round(((attachSize / 1024) / 1000), 2) < 9.5 Then
                'MsgBox("attachSize = " + Math.Round(((attachSize / 1024) / 1000), 2).ToString + " Mb", vbOKOnly)

                For Each sFile As String In dirFilesQ
                    f = New System.IO.FileInfo(sFile)
                    'Console.WriteLine(f.Name)
                    mail.Attachments.Add(New Attachment(f.FullName))
                Next

                'send the message
                Dim smtp As New SmtpClient(smtpAddress)
                smtp.Send(mail)
            Else
                MsgBox("ATTENZIONE !!!!" + vbCrLf + vbCrLf + "Gli allegati superano i 9,5Mb" + vbCrLf + "comprimere i file e inviare manualmente !", vbOKOnly, "Errore dimensione Allegati")
                Exit Sub
            End If
        End If
        MsgBox("Archiviazione Terminata", vbOKOnly)
    End Sub

    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TextBox1.Focus()
    End Sub

    Private Sub btnSostTavole_Click(sender As Object, e As EventArgs) Handles btnSostTavole.Click
        Dim f As System.IO.FileInfo
        Dim x As Integer
        Dim y As Integer
        Dim contami As Integer
        Dim attachSize As Int64

        If TextBox1.Text = "" Or Len(TextBox1.Text) <> 4 Then
            MsgBox("ERRORE! Inserire un catalogo", vbOKOnly, "ERRORE")
            TextBox1.Focus()
            Exit Sub
        End If
        TextBox1.Text = UCase(TextBox1.Text)

        Dim dirFiles() As String
        Dim dirFilesQ() As String
        Dim dirFilesT() As String

        dirFiles = System.IO.Directory.GetFiles(pathRepository + "\" + Trim(TextBox1.Text), "*.pdf")
        x = 0
        y = 0
        contami = dirFiles.Count

        dirFilesQ = New String(contami) {}
        dirFilesT = New String(contami) {}

        ' verifico se sono delle tavole Qxx
        'If dirFiles.First.Substring(9, 2)
        For Each qFile As String In dirFiles
            If qFile.Contains("Q00") Then
                ' è una tavola Q00 quindi va mandata per email
                ' aggiungo il file alla lista dirFilesQ()
                dirFilesQ(x) = qFile
                x = x + 1

            End If

            If qFile.Contains("Q01") Then
                ' è una tavola Q01 quindi va mandata per email
                ' aggiungo il file alla lista dirFilesQ()
                dirFilesQ(x) = qFile
                x = x + 1

            End If

            If qFile.Contains("Q02") Then
                ' è una tavola Q0" quindi va mandata per email
                ' aggiungo il file alla lista dirFilesQ()
                dirFilesQ(x) = qFile
                x = x + 1

            End If

            If Not qFile.Contains("Q00") And Not qFile.Contains("Q01") And Not qFile.Contains("Q02") Then
                ' siccome non è una tavola Q00 / Q01 o Q02
                ' l'aggiungo all'array delle tavole da archiviare
                ' con il TableArchiverServer
                dirFilesT(y) = qFile
                y = y + 1
            End If

        Next

        ' ridimensiono gli array delle liste in base ai contatori X e Y diminuiti di 1
        ReDim Preserve dirFilesQ(x - 1)
        ReDim Preserve dirFilesT(y - 1)

        Dim messaggio As String

        messaggio = "Risultato tavole trovate per " + Trim(TextBox1.Text)
        messaggio = messaggio + vbCrLf + vbCrLf + "Tavole Q00 / Q01 / Q02:     " + dirFilesQ.Count.ToString
        messaggio = messaggio + vbCrLf + vbCrLf + "Tavole normali:     " + dirFilesT.Count.ToString

        Dim gneppo = MsgBox(messaggio + vbCrLf + vbCrLf + "Continuo ?", vbOKCancel, "Info")
        If gneppo = vbOK Then
            For Each sFile As String In dirFilesT
                f = New System.IO.FileInfo(sFile)
                'Console.WriteLine(f.Name)
                f.CopyTo(pathServer + "\S\" + f.Name, True)
            Next

            'For Each sFile As String In dirFilesQ
            '    f = New System.IO.FileInfo(sFile)
            '    'Console.WriteLine(f.Name)
            '    f.CopyTo(pathServer + "\Att\" + f.Name, True)
            'Next

        Else
            Exit Sub
        End If

        TextBox1.Text = ""
        TextBox1.Focus()

        If dirFilesQ.Count > 0 Then
            ' send EMAIL !!!
            'create the mail message
            Dim mail As New MailMessage()

            'set the addresses
            mail.From = New MailAddress(mailFrom)
            mail.To.Add(mailTo)
            Dim user() As String
            user = mailFrom.Split("_")

            'set the content
            mail.Subject = "SOSTITUZIONE Tavole Q00"
            mail.Body = "Me le sostituiresti ?" + vbCrLf + vbCrLf + "Grazie 1000" + vbCrLf + vbCrLf + "--------" + vbCrLf + UCase(user(0))

            ''add an attachment from the filesystem
            'mail.Attachments.Add(New Attachment("c:\temp\example.txt"))

            ''to add additional attachments, simply call .Add(...) again
            'mail.Attachments.Add(New Attachment("c:\temp\example2.txt"))
            'mail.Attachments.Add(New Attachment("c:\temp\example3.txt"))
            For Each sFile As String In dirFilesQ
                f = New System.IO.FileInfo(sFile)
                attachSize = attachSize + f.Length
            Next
            If Math.Round(((attachSize / 1024) / 1000), 2) < 9.5 Then
                'MsgBox("attachSize = " + Math.Round(((attachSize / 1024) / 1000), 2).ToString + " Mb", vbOKOnly)

                For Each sFile As String In dirFilesQ
                    f = New System.IO.FileInfo(sFile)
                    'Console.WriteLine(f.Name)
                    mail.Attachments.Add(New Attachment(f.FullName))
                Next

                'send the message
                Dim smtp As New SmtpClient(smtpAddress)
                smtp.Send(mail)
            Else
                MsgBox("ATTENZIONE !!!!" + vbCrLf + vbCrLf + "Gli allegati superano i 9,5Mb" + vbCrLf + "comprimere i file e inviare manualmente !", vbOKOnly, "Errore dimensione Allegati")
                Exit Sub
            End If
        End If
        MsgBox("Archiviazione Terminata", vbOKOnly)
    End Sub
End Class
