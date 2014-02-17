
Public Class frmMain
    Public appSettings = Application.StartupPath + "\Files\appSettings.config"
    Public pathRepository As String
    Public pathCataloghi As String
    Public pathServer As String

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
        If TextBox1.Text = "" Or Len(TextBox1.Text) <> 4 Then
            MsgBox("ERRORE! Inserire un catalogo", vbOKOnly, "ERRORE")
            TextBox1.Focus()
            Exit Sub
        End If
        TextBox1.Text = UCase(TextBox1.Text)

        Dim dirFiles() As String
        dirFiles = System.IO.Directory.GetFiles(pathRepository + "\" + Trim(TextBox1.Text), "*.pdf")
        Dim gneppo = MsgBox("Tavole da copiare trovate: " + dirFiles.Count.ToString + vbCrLf + vbCrLf + "Continuo ?", vbOKCancel, "Info")
        If gneppo = vbOK Then
            For Each sFile As String In dirFiles
                f = New System.IO.FileInfo(sFile)
                'Console.WriteLine(f.Name)
                f.CopyTo(pathServer + "\N\" + f.Name, True)
            Next
        Else
            Exit Sub
        End If
        MsgBox("Copia Termianta !", vbOKOnly)
        TextBox1.Text = ""
        TextBox1.Focus()

    End Sub

    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TextBox1.Focus()
    End Sub

    Private Sub btnSostTavole_Click(sender As Object, e As EventArgs) Handles btnSostTavole.Click
        Dim f As System.IO.FileInfo
        If TextBox1.Text = "" Or Len(TextBox1.Text) <> 4 Then
            MsgBox("ERRORE! Inserire un catalogo", vbOKOnly, "ERRORE")
            TextBox1.Focus()
            Exit Sub
        End If
        TextBox1.Text = UCase(TextBox1.Text)

        Dim dirFiles() As String
        dirFiles = System.IO.Directory.GetFiles(pathRepository + "\" + Trim(TextBox1.Text), "*.pdf")
        Dim gneppo = MsgBox("Tavole da copiare trovate: " + dirFiles.Count.ToString + vbCrLf + vbCrLf + "Continuo ?", vbOKCancel, "Info")
        If gneppo = vbOK Then
            For Each sFile As String In dirFiles
                f = New System.IO.FileInfo(sFile)
                'Console.WriteLine(f.Name)
                f.CopyTo(pathServer + "\S\" + f.Name, True)
            Next
        Else
            Exit Sub
        End If
        MsgBox("Copia Termianta !", vbOKOnly)
        TextBox1.Text = ""
        TextBox1.Focus()
    End Sub
End Class
