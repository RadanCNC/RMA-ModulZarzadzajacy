<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Logowanie
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Logowanie))
        Me.BtnZaloguj = New System.Windows.Forms.Button()
        Me.BtnAnuluj = New System.Windows.Forms.Button()
        Me.TxtLogin = New System.Windows.Forms.TextBox()
        Me.TxtHaslo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnZaloguj
        '
        Me.BtnZaloguj.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BtnZaloguj.Location = New System.Drawing.Point(722, 92)
        Me.BtnZaloguj.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnZaloguj.Name = "BtnZaloguj"
        Me.BtnZaloguj.Size = New System.Drawing.Size(60, 31)
        Me.BtnZaloguj.TabIndex = 0
        Me.BtnZaloguj.Text = "Zaloguj"
        Me.BtnZaloguj.UseVisualStyleBackColor = False
        '
        'BtnAnuluj
        '
        Me.BtnAnuluj.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BtnAnuluj.Location = New System.Drawing.Point(786, 92)
        Me.BtnAnuluj.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnAnuluj.Name = "BtnAnuluj"
        Me.BtnAnuluj.Size = New System.Drawing.Size(56, 31)
        Me.BtnAnuluj.TabIndex = 1
        Me.BtnAnuluj.Text = "Anuluj"
        Me.BtnAnuluj.UseVisualStyleBackColor = False
        '
        'TxtLogin
        '
        Me.TxtLogin.Location = New System.Drawing.Point(650, 19)
        Me.TxtLogin.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtLogin.Name = "TxtLogin"
        Me.TxtLogin.Size = New System.Drawing.Size(193, 20)
        Me.TxtLogin.TabIndex = 2
        Me.TxtLogin.Text = "Radan"
        '
        'TxtHaslo
        '
        Me.TxtHaslo.Location = New System.Drawing.Point(650, 53)
        Me.TxtHaslo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtHaslo.Name = "TxtHaslo"
        Me.TxtHaslo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtHaslo.Size = New System.Drawing.Size(193, 20)
        Me.TxtHaslo.TabIndex = 3
        Me.TxtHaslo.Text = "Radan123"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(605, 21)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Login:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(604, 55)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Hasło:"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(758, 148)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(85, 65)
        Me.DataGridView1.TabIndex = 6
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Radan_Magazyn_Blach_Moduł_Zarządzający.My.Resources.Resources.sl_rma2
        Me.PictureBox1.Location = New System.Drawing.Point(-19, -73)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(622, 395)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'Logowanie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(861, 228)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtHaslo)
        Me.Controls.Add(Me.TxtLogin)
        Me.Controls.Add(Me.BtnAnuluj)
        Me.Controls.Add(Me.BtnZaloguj)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "Logowanie"
        Me.Text = "Logowanie"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnZaloguj As Button
    Friend WithEvents BtnAnuluj As Button
    Friend WithEvents TxtLogin As TextBox
    Friend WithEvents TxtHaslo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents PictureBox1 As PictureBox
End Class
