<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnSostTavole = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnArchiviaTavoleNew = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnSostTavole
        '
        Me.btnSostTavole.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSostTavole.FlatAppearance.BorderSize = 0
        Me.btnSostTavole.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red
        Me.btnSostTavole.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.btnSostTavole.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSostTavole.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSostTavole.Location = New System.Drawing.Point(168, 138)
        Me.btnSostTavole.Name = "btnSostTavole"
        Me.btnSostTavole.Size = New System.Drawing.Size(176, 44)
        Me.btnSostTavole.TabIndex = 8
        Me.btnSostTavole.Text = "Sostituire Tavole"
        Me.btnSostTavole.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(72, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(213, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Inserisci Codice Catalogo"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox1.Location = New System.Drawing.Point(12, 52)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(332, 80)
        Me.TextBox1.TabIndex = 6
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBox1.WordWrap = False
        '
        'btnArchiviaTavoleNew
        '
        Me.btnArchiviaTavoleNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnArchiviaTavoleNew.FlatAppearance.BorderSize = 0
        Me.btnArchiviaTavoleNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red
        Me.btnArchiviaTavoleNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.btnArchiviaTavoleNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnArchiviaTavoleNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnArchiviaTavoleNew.Location = New System.Drawing.Point(12, 138)
        Me.btnArchiviaTavoleNew.Name = "btnArchiviaTavoleNew"
        Me.btnArchiviaTavoleNew.Size = New System.Drawing.Size(150, 44)
        Me.btnArchiviaTavoleNew.TabIndex = 5
        Me.btnArchiviaTavoleNew.Text = "Nuove Tavole"
        Me.btnArchiviaTavoleNew.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 207)
        Me.Controls.Add(Me.btnSostTavole)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnArchiviaTavoleNew)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Table Archiver"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSostTavole As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnArchiviaTavoleNew As System.Windows.Forms.Button

End Class
