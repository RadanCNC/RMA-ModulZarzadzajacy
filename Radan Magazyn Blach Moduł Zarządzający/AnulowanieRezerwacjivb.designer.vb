<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AnulowanieRezerwacjivb
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.BtnAnulujPrzyjęcieMagazynowe = New System.Windows.Forms.Button()
        Me.BtnAnulujRezerwacje = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(47, 61)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1268, 418)
        Me.DataGridView1.TabIndex = 0
        '
        'BtnAnulujPrzyjęcieMagazynowe
        '
        Me.BtnAnulujPrzyjęcieMagazynowe.Location = New System.Drawing.Point(1120, 497)
        Me.BtnAnulujPrzyjęcieMagazynowe.Name = "BtnAnulujPrzyjęcieMagazynowe"
        Me.BtnAnulujPrzyjęcieMagazynowe.Size = New System.Drawing.Size(195, 48)
        Me.BtnAnulujPrzyjęcieMagazynowe.TabIndex = 1
        Me.BtnAnulujPrzyjęcieMagazynowe.Text = "Anuluj Przyjęcie Magazynowe"
        Me.BtnAnulujPrzyjęcieMagazynowe.UseVisualStyleBackColor = True
        Me.BtnAnulujPrzyjęcieMagazynowe.Visible = False
        '
        'BtnAnulujRezerwacje
        '
        Me.BtnAnulujRezerwacje.Location = New System.Drawing.Point(945, 497)
        Me.BtnAnulujRezerwacje.Name = "BtnAnulujRezerwacje"
        Me.BtnAnulujRezerwacje.Size = New System.Drawing.Size(156, 48)
        Me.BtnAnulujRezerwacje.TabIndex = 2
        Me.BtnAnulujRezerwacje.Text = "Anuluj Rezerwację"
        Me.BtnAnulujRezerwacje.UseVisualStyleBackColor = True
        Me.BtnAnulujRezerwacje.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Rezerwacje", "Przyjęcia magazynowe"})
        Me.ComboBox1.Location = New System.Drawing.Point(60, 12)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(247, 24)
        Me.ComboBox1.TabIndex = 4
        Me.ComboBox1.Text = "Rezerwacje"
        '
        'AnulowanieRezerwacjivb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1337, 568)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.BtnAnulujRezerwacje)
        Me.Controls.Add(Me.BtnAnulujPrzyjęcieMagazynowe)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "AnulowanieRezerwacjivb"
        Me.Text = "AnulowanieRezerwacjivb"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As Windows.Forms.DataGridView
    Friend WithEvents BtnAnulujPrzyjęcieMagazynowe As Windows.Forms.Button
    Friend WithEvents BtnAnulujRezerwacje As Windows.Forms.Button
    Friend WithEvents ComboBox1 As Windows.Forms.ComboBox
End Class
