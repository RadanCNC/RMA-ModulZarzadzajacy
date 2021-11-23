<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportBlach
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
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.BtnWczytajDane = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BtnWczytajDoRadana = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.LabelProgressBar = New System.Windows.Forms.Label()
        Me.CBAdmin = New System.Windows.Forms.CheckBox()
        Me.BtnWczytajWybrane = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(27, 69)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(267, 83)
        Me.RichTextBox1.TabIndex = 21
        Me.RichTextBox1.Text = "Select * From Arkusze where iloscDostepne > 0"
        '
        'BtnWczytajDane
        '
        Me.BtnWczytajDane.Location = New System.Drawing.Point(316, 69)
        Me.BtnWczytajDane.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnWczytajDane.Name = "BtnWczytajDane"
        Me.BtnWczytajDane.Size = New System.Drawing.Size(97, 85)
        Me.BtnWczytajDane.TabIndex = 20
        Me.BtnWczytajDane.Text = "Wczytaj Dane"
        Me.BtnWczytajDane.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(9, 195)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1544, 504)
        Me.DataGridView1.TabIndex = 19
        '
        'BtnWczytajDoRadana
        '
        Me.BtnWczytajDoRadana.Location = New System.Drawing.Point(425, 69)
        Me.BtnWczytajDoRadana.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnWczytajDoRadana.Name = "BtnWczytajDoRadana"
        Me.BtnWczytajDoRadana.Size = New System.Drawing.Size(116, 85)
        Me.BtnWczytajDoRadana.TabIndex = 22
        Me.BtnWczytajDoRadana.Text = "Wczytaj Wszystkie Arkusze Do Radana"
        Me.BtnWczytajDoRadana.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(718, 128)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(395, 19)
        Me.ProgressBar1.TabIndex = 32
        '
        'LabelProgressBar
        '
        Me.LabelProgressBar.AutoSize = True
        Me.LabelProgressBar.Location = New System.Drawing.Point(716, 98)
        Me.LabelProgressBar.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelProgressBar.Name = "LabelProgressBar"
        Me.LabelProgressBar.Size = New System.Drawing.Size(37, 13)
        Me.LabelProgressBar.TabIndex = 33
        Me.LabelProgressBar.Text = "Status"
        '
        'CBAdmin
        '
        Me.CBAdmin.AutoSize = True
        Me.CBAdmin.Location = New System.Drawing.Point(27, 25)
        Me.CBAdmin.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CBAdmin.Name = "CBAdmin"
        Me.CBAdmin.Size = New System.Drawing.Size(55, 17)
        Me.CBAdmin.TabIndex = 35
        Me.CBAdmin.Text = "Admin"
        Me.CBAdmin.UseVisualStyleBackColor = True
        '
        'BtnWczytajWybrane
        '
        Me.BtnWczytajWybrane.Location = New System.Drawing.Point(566, 69)
        Me.BtnWczytajWybrane.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnWczytajWybrane.Name = "BtnWczytajWybrane"
        Me.BtnWczytajWybrane.Size = New System.Drawing.Size(122, 85)
        Me.BtnWczytajWybrane.TabIndex = 36
        Me.BtnWczytajWybrane.Text = "Wczytaj tylko wybrane Arkusze"
        Me.BtnWczytajWybrane.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1204, 69)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(122, 85)
        Me.Button1.TabIndex = 37
        Me.Button1.Text = "Zamknij okno"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ImportBlach
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1437, 708)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BtnWczytajWybrane)
        Me.Controls.Add(Me.CBAdmin)
        Me.Controls.Add(Me.LabelProgressBar)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.BtnWczytajDane)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.BtnWczytajDoRadana)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "ImportBlach"
        Me.Text = "Import Blach"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RichTextBox1 As Windows.Forms.RichTextBox
    Friend WithEvents BtnWczytajDane As Windows.Forms.Button
    Friend WithEvents DataGridView1 As Windows.Forms.DataGridView
    Friend WithEvents BackgroundWorker1 As ComponentModel.BackgroundWorker
    Friend WithEvents BtnWczytajDoRadana As Windows.Forms.Button
    Friend WithEvents ProgressBar1 As Windows.Forms.ProgressBar
    Friend WithEvents LabelProgressBar As Windows.Forms.Label
    Friend WithEvents CBAdmin As Windows.Forms.CheckBox
    Friend WithEvents BtnWczytajWybrane As Windows.Forms.Button
    Friend WithEvents Button1 As Windows.Forms.Button
End Class
