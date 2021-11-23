<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Monitor
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Monitor))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBoxSzukaj = New System.Windows.Forms.TextBox()
        Me.DatePicker = New System.Windows.Forms.DateTimePicker()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.DatePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.BtnOtworzPlik = New System.Windows.Forms.Button()
        Me.CBZrobBarcody = New System.Windows.Forms.CheckBox()
        Me.LblUstawieniaKoduKreskowego = New System.Windows.Forms.Label()
        Me.CBWymiar = New System.Windows.Forms.CheckBox()
        Me.CBGrubosc = New System.Windows.Forms.CheckBox()
        Me.CbMaterial = New System.Windows.Forms.CheckBox()
        Me.CBNumerMagazynowy = New System.Windows.Forms.CheckBox()
        Me.LblKatalogDoZapisuBarcodow = New System.Windows.Forms.Label()
        Me.TxtSciezkaBarcode = New System.Windows.Forms.TextBox()
        Me.TxtLoginSql = New System.Windows.Forms.TextBox()
        Me.TxtUprawnienia = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        'Me.Barcode1 = New BarcodeLib.Barcode.WinForms.QRCodeWinForm()
        Me.PictureBox12 = New System.Windows.Forms.PictureBox()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BtnInfoOWersji = New System.Windows.Forms.Button()
        Me.BtnWyczyscTrackera = New System.Windows.Forms.Button()
        Me.BtnOdczytajPlikProjektuDoTrackera = New System.Windows.Forms.Button()
        Me.BtnNiskieStany = New System.Windows.Forms.Button()
        Me.BtnRaport = New System.Windows.Forms.Button()
        Me.BtnEdycjaPM = New System.Windows.Forms.Button()
        Me.BtnZuzyte = New System.Windows.Forms.Button()
        Me.BtnUsunPrzyjecieMagazynowe = New System.Windows.Forms.Button()
        Me.BtnGenerujKody = New System.Windows.Forms.Button()
        Me.BtnUstawieniaAdmin = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnPoDacie = New System.Windows.Forms.Button()
        Me.BtnOdswiez = New System.Windows.Forms.Button()
        Me.BtnWyszukaj = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Zalogowany użytkownik:"
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.White
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Magazyn Arkuszy", "Magazyn Odpadów", "Log (Przyjęcia, Rezerwacje, Anulowania Rezerwacji, Zużyte Arkusze)", "Tracker"})
        Me.ComboBox1.Location = New System.Drawing.Point(29, 117)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(186, 21)
        Me.ComboBox1.TabIndex = 8
        Me.ComboBox1.Text = "Magazyn Arkuszy"
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Location = New System.Drawing.Point(21, 146)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1492, 512)
        Me.DataGridView1.TabIndex = 5
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(258, 81)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(114, 20)
        Me.TextBox1.TabIndex = 9
        '
        'TextBoxSzukaj
        '
        Me.TextBoxSzukaj.BackColor = System.Drawing.Color.White
        Me.TextBoxSzukaj.Location = New System.Drawing.Point(1039, 116)
        Me.TextBoxSzukaj.Name = "TextBoxSzukaj"
        Me.TextBoxSzukaj.Size = New System.Drawing.Size(265, 20)
        Me.TextBoxSzukaj.TabIndex = 10
        '
        'DatePicker
        '
        Me.DatePicker.CustomFormat = "dd-MM-yyyy"
        Me.DatePicker.Enabled = False
        Me.DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DatePicker.Location = New System.Drawing.Point(450, 117)
        Me.DatePicker.Name = "DatePicker"
        Me.DatePicker.Size = New System.Drawing.Size(92, 20)
        Me.DatePicker.TabIndex = 14
        Me.DatePicker.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(391, 117)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(53, 20)
        Me.TextBox2.TabIndex = 15
        Me.TextBox2.Text = "Data od:"
        Me.TextBox2.Visible = False
        '
        'DatePicker2
        '
        Me.DatePicker2.CustomFormat = "dd-MM-yyyy"
        Me.DatePicker2.Enabled = False
        Me.DatePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DatePicker2.Location = New System.Drawing.Point(609, 117)
        Me.DatePicker2.Name = "DatePicker2"
        Me.DatePicker2.Size = New System.Drawing.Size(92, 20)
        Me.DatePicker2.TabIndex = 14
        Me.DatePicker2.Visible = False
        '
        'TextBox3
        '
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(574, 117)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(29, 20)
        Me.TextBox3.TabIndex = 15
        Me.TextBox3.Text = "Do:"
        Me.TextBox3.Visible = False
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.Color.White
        Me.TextBox4.Enabled = False
        Me.TextBox4.Location = New System.Drawing.Point(865, 117)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(68, 20)
        Me.TextBox4.TabIndex = 15
        Me.TextBox4.Text = "Powierzone:"
        Me.TextBox4.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(939, 117)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(40, 17)
        Me.CheckBox1.TabIndex = 16
        Me.CheckBox1.Text = "CB"
        Me.CheckBox1.UseVisualStyleBackColor = False
        Me.CheckBox1.Visible = False
        '
        'BtnOtworzPlik
        '
        Me.BtnOtworzPlik.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtnOtworzPlik.Enabled = False
        Me.BtnOtworzPlik.Location = New System.Drawing.Point(400, 762)
        Me.BtnOtworzPlik.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnOtworzPlik.Name = "BtnOtworzPlik"
        Me.BtnOtworzPlik.Size = New System.Drawing.Size(24, 19)
        Me.BtnOtworzPlik.TabIndex = 82
        Me.BtnOtworzPlik.Text = "..."
        Me.BtnOtworzPlik.UseVisualStyleBackColor = False
        Me.BtnOtworzPlik.Visible = False
        '
        'CBZrobBarcody
        '
        Me.CBZrobBarcody.AutoSize = True
        Me.CBZrobBarcody.BackColor = System.Drawing.Color.Transparent
        Me.CBZrobBarcody.Enabled = False
        Me.CBZrobBarcody.Location = New System.Drawing.Point(183, 684)
        Me.CBZrobBarcody.Margin = New System.Windows.Forms.Padding(2)
        Me.CBZrobBarcody.Name = "CBZrobBarcody"
        Me.CBZrobBarcody.Size = New System.Drawing.Size(112, 17)
        Me.CBZrobBarcody.TabIndex = 81
        Me.CBZrobBarcody.Text = "Wł/Wył. Barcode"
        Me.CBZrobBarcody.UseVisualStyleBackColor = False
        Me.CBZrobBarcody.Visible = False
        '
        'LblUstawieniaKoduKreskowego
        '
        Me.LblUstawieniaKoduKreskowego.AutoSize = True
        Me.LblUstawieniaKoduKreskowego.BackColor = System.Drawing.Color.Transparent
        Me.LblUstawieniaKoduKreskowego.Enabled = False
        Me.LblUstawieniaKoduKreskowego.Location = New System.Drawing.Point(23, 687)
        Me.LblUstawieniaKoduKreskowego.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblUstawieniaKoduKreskowego.Name = "LblUstawieniaKoduKreskowego"
        Me.LblUstawieniaKoduKreskowego.Size = New System.Drawing.Size(147, 13)
        Me.LblUstawieniaKoduKreskowego.TabIndex = 80
        Me.LblUstawieniaKoduKreskowego.Text = "Ustawienia kodu kreskowego"
        Me.LblUstawieniaKoduKreskowego.Visible = False
        '
        'CBWymiar
        '
        Me.CBWymiar.AutoSize = True
        Me.CBWymiar.BackColor = System.Drawing.Color.Transparent
        Me.CBWymiar.Enabled = False
        Me.CBWymiar.Location = New System.Drawing.Point(251, 720)
        Me.CBWymiar.Margin = New System.Windows.Forms.Padding(2)
        Me.CBWymiar.Name = "CBWymiar"
        Me.CBWymiar.Size = New System.Drawing.Size(61, 17)
        Me.CBWymiar.TabIndex = 79
        Me.CBWymiar.Text = "Wymiar"
        Me.CBWymiar.UseVisualStyleBackColor = False
        Me.CBWymiar.Visible = False
        '
        'CBGrubosc
        '
        Me.CBGrubosc.AutoSize = True
        Me.CBGrubosc.BackColor = System.Drawing.Color.Transparent
        Me.CBGrubosc.Enabled = False
        Me.CBGrubosc.Location = New System.Drawing.Point(183, 720)
        Me.CBGrubosc.Margin = New System.Windows.Forms.Padding(2)
        Me.CBGrubosc.Name = "CBGrubosc"
        Me.CBGrubosc.Size = New System.Drawing.Size(66, 17)
        Me.CBGrubosc.TabIndex = 78
        Me.CBGrubosc.Text = "Grubość"
        Me.CBGrubosc.UseVisualStyleBackColor = False
        Me.CBGrubosc.Visible = False
        '
        'CbMaterial
        '
        Me.CbMaterial.AutoSize = True
        Me.CbMaterial.BackColor = System.Drawing.Color.Transparent
        Me.CbMaterial.Enabled = False
        Me.CbMaterial.Location = New System.Drawing.Point(119, 720)
        Me.CbMaterial.Margin = New System.Windows.Forms.Padding(2)
        Me.CbMaterial.Name = "CbMaterial"
        Me.CbMaterial.Size = New System.Drawing.Size(65, 17)
        Me.CbMaterial.TabIndex = 77
        Me.CbMaterial.Text = "Materiał"
        Me.CbMaterial.UseVisualStyleBackColor = False
        Me.CbMaterial.Visible = False
        '
        'CBNumerMagazynowy
        '
        Me.CBNumerMagazynowy.AutoSize = True
        Me.CBNumerMagazynowy.BackColor = System.Drawing.Color.Transparent
        Me.CBNumerMagazynowy.Enabled = False
        Me.CBNumerMagazynowy.Location = New System.Drawing.Point(23, 720)
        Me.CBNumerMagazynowy.Margin = New System.Windows.Forms.Padding(2)
        Me.CBNumerMagazynowy.Name = "CBNumerMagazynowy"
        Me.CBNumerMagazynowy.Size = New System.Drawing.Size(102, 17)
        Me.CBNumerMagazynowy.TabIndex = 76
        Me.CBNumerMagazynowy.Text = "Nr Magazynowy"
        Me.CBNumerMagazynowy.UseVisualStyleBackColor = False
        Me.CBNumerMagazynowy.Visible = False
        '
        'LblKatalogDoZapisuBarcodow
        '
        Me.LblKatalogDoZapisuBarcodow.AutoSize = True
        Me.LblKatalogDoZapisuBarcodow.BackColor = System.Drawing.Color.Transparent
        Me.LblKatalogDoZapisuBarcodow.Enabled = False
        Me.LblKatalogDoZapisuBarcodow.Location = New System.Drawing.Point(22, 766)
        Me.LblKatalogDoZapisuBarcodow.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblKatalogDoZapisuBarcodow.Name = "LblKatalogDoZapisuBarcodow"
        Me.LblKatalogDoZapisuBarcodow.Size = New System.Drawing.Size(142, 13)
        Me.LblKatalogDoZapisuBarcodow.TabIndex = 75
        Me.LblKatalogDoZapisuBarcodow.Text = "Katalog do zapisu Barcodów"
        Me.LblKatalogDoZapisuBarcodow.Visible = False
        '
        'TxtSciezkaBarcode
        '
        Me.TxtSciezkaBarcode.Enabled = False
        Me.TxtSciezkaBarcode.Location = New System.Drawing.Point(183, 762)
        Me.TxtSciezkaBarcode.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtSciezkaBarcode.Name = "TxtSciezkaBarcode"
        Me.TxtSciezkaBarcode.Size = New System.Drawing.Size(213, 20)
        Me.TxtSciezkaBarcode.TabIndex = 74
        Me.TxtSciezkaBarcode.Text = "C:\Barcode"
        Me.TxtSciezkaBarcode.Visible = False
        '
        'TxtLoginSql
        '
        Me.TxtLoginSql.BackColor = System.Drawing.Color.White
        Me.TxtLoginSql.Location = New System.Drawing.Point(391, 81)
        Me.TxtLoginSql.Name = "TxtLoginSql"
        Me.TxtLoginSql.ReadOnly = True
        Me.TxtLoginSql.Size = New System.Drawing.Size(128, 20)
        Me.TxtLoginSql.TabIndex = 85
        '
        'TxtUprawnienia
        '
        Me.TxtUprawnienia.BackColor = System.Drawing.Color.White
        Me.TxtUprawnienia.Location = New System.Drawing.Point(544, 81)
        Me.TxtUprawnienia.Name = "TxtUprawnienia"
        Me.TxtUprawnienia.ReadOnly = True
        Me.TxtUprawnienia.Size = New System.Drawing.Size(59, 20)
        Me.TxtUprawnienia.TabIndex = 86
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(255, 52)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 88
        Me.Label2.Text = "Nazwa komputera"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(389, 52)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 89
        Me.Label3.Text = "Login z MS SQL"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(542, 52)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "Uprawnienia"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Barcode1
        '

        '
        'PictureBox12
        '
        Me.PictureBox12.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox12.Enabled = False
        Me.PictureBox12.Image = Global.Radan_Magazyn_Blach_Moduł_Zarządzający.My.Resources.Resources.calendar
        Me.PictureBox12.Location = New System.Drawing.Point(707, 104)
        Me.PictureBox12.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.Size = New System.Drawing.Size(34, 37)
        Me.PictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox12.TabIndex = 109
        Me.PictureBox12.TabStop = False
        Me.PictureBox12.Visible = False
        '
        'PictureBox10
        '
        Me.PictureBox10.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(1193, 745)
        Me.PictureBox10.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(45, 49)
        Me.PictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox10.TabIndex = 107
        Me.PictureBox10.TabStop = False
        '
        'PictureBox9
        '
        Me.PictureBox9.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(873, 745)
        Me.PictureBox9.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(45, 49)
        Me.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox9.TabIndex = 106
        Me.PictureBox9.TabStop = False
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(873, 684)
        Me.PictureBox8.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(45, 49)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox8.TabIndex = 105
        Me.PictureBox8.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(1194, 684)
        Me.PictureBox7.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(45, 49)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox7.TabIndex = 104
        Me.PictureBox7.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(1034, 745)
        Me.PictureBox6.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(45, 49)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 103
        Me.PictureBox6.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(1034, 684)
        Me.PictureBox5.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(45, 49)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 102
        Me.PictureBox5.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(1355, 684)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(45, 49)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 101
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(1355, 745)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(45, 49)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 100
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(706, 745)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(45, 49)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 99
        Me.PictureBox2.TabStop = False
        '
        'BtnInfoOWersji
        '
        Me.BtnInfoOWersji.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtnInfoOWersji.BackgroundImage = CType(resources.GetObject("BtnInfoOWersji.BackgroundImage"), System.Drawing.Image)
        Me.BtnInfoOWersji.Location = New System.Drawing.Point(1083, 745)
        Me.BtnInfoOWersji.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnInfoOWersji.Name = "BtnInfoOWersji"
        Me.BtnInfoOWersji.Size = New System.Drawing.Size(107, 49)
        Me.BtnInfoOWersji.TabIndex = 98
        Me.BtnInfoOWersji.Text = "Informacja o wersji"
        Me.BtnInfoOWersji.UseVisualStyleBackColor = False
        '
        'BtnWyczyscTrackera
        '
        Me.BtnWyczyscTrackera.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.BtnWyczyscTrackera.BackgroundImage = Global.Radan_Magazyn_Blach_Moduł_Zarządzający.My.Resources.Resources._7
        Me.BtnWyczyscTrackera.Location = New System.Drawing.Point(922, 745)
        Me.BtnWyczyscTrackera.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnWyczyscTrackera.Name = "BtnWyczyscTrackera"
        Me.BtnWyczyscTrackera.Size = New System.Drawing.Size(107, 49)
        Me.BtnWyczyscTrackera.TabIndex = 97
        Me.BtnWyczyscTrackera.Text = "Wyczysc Tracker [Usuwa wszystko z tabeli]"
        Me.BtnWyczyscTrackera.UseVisualStyleBackColor = False
        '
        'BtnOdczytajPlikProjektuDoTrackera
        '
        Me.BtnOdczytajPlikProjektuDoTrackera.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtnOdczytajPlikProjektuDoTrackera.BackgroundImage = Global.Radan_Magazyn_Blach_Moduł_Zarządzający.My.Resources.Resources._7
        Me.BtnOdczytajPlikProjektuDoTrackera.Location = New System.Drawing.Point(755, 745)
        Me.BtnOdczytajPlikProjektuDoTrackera.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnOdczytajPlikProjektuDoTrackera.Name = "BtnOdczytajPlikProjektuDoTrackera"
        Me.BtnOdczytajPlikProjektuDoTrackera.Size = New System.Drawing.Size(112, 49)
        Me.BtnOdczytajPlikProjektuDoTrackera.TabIndex = 96
        Me.BtnOdczytajPlikProjektuDoTrackera.Text = "Wczytaj plik projektu do Trackera"
        Me.BtnOdczytajPlikProjektuDoTrackera.UseVisualStyleBackColor = False
        '
        'BtnNiskieStany
        '
        Me.BtnNiskieStany.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.BtnNiskieStany.BackgroundImage = CType(resources.GetObject("BtnNiskieStany.BackgroundImage"), System.Drawing.Image)
        Me.BtnNiskieStany.FlatAppearance.BorderSize = 0
        Me.BtnNiskieStany.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!)
        Me.BtnNiskieStany.Location = New System.Drawing.Point(1243, 745)
        Me.BtnNiskieStany.Name = "BtnNiskieStany"
        Me.BtnNiskieStany.Size = New System.Drawing.Size(107, 49)
        Me.BtnNiskieStany.TabIndex = 95
        Me.BtnNiskieStany.Text = "Pokaż niskie stany magazynowe < 10"
        Me.BtnNiskieStany.UseVisualStyleBackColor = False
        '
        'BtnRaport
        '
        Me.BtnRaport.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtnRaport.BackgroundImage = CType(resources.GetObject("BtnRaport.BackgroundImage"), System.Drawing.Image)
        Me.BtnRaport.FlatAppearance.BorderSize = 0
        Me.BtnRaport.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!)
        Me.BtnRaport.Location = New System.Drawing.Point(1406, 745)
        Me.BtnRaport.Name = "BtnRaport"
        Me.BtnRaport.Size = New System.Drawing.Size(107, 49)
        Me.BtnRaport.TabIndex = 94
        Me.BtnRaport.Text = "Pokaż raport"
        Me.BtnRaport.UseVisualStyleBackColor = False
        '
        'BtnEdycjaPM
        '
        Me.BtnEdycjaPM.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.BtnEdycjaPM.BackgroundImage = CType(resources.GetObject("BtnEdycjaPM.BackgroundImage"), System.Drawing.Image)
        Me.BtnEdycjaPM.Location = New System.Drawing.Point(1244, 684)
        Me.BtnEdycjaPM.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnEdycjaPM.Name = "BtnEdycjaPM"
        Me.BtnEdycjaPM.Size = New System.Drawing.Size(107, 49)
        Me.BtnEdycjaPM.TabIndex = 91
        Me.BtnEdycjaPM.Text = "Edycja Przyjęcia Magazynowego"
        Me.BtnEdycjaPM.UseVisualStyleBackColor = False
        '
        'BtnZuzyte
        '
        Me.BtnZuzyte.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.BtnZuzyte.BackgroundImage = Global.Radan_Magazyn_Blach_Moduł_Zarządzający.My.Resources.Resources._7
        Me.BtnZuzyte.Location = New System.Drawing.Point(922, 684)
        Me.BtnZuzyte.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnZuzyte.Name = "BtnZuzyte"
        Me.BtnZuzyte.Size = New System.Drawing.Size(107, 49)
        Me.BtnZuzyte.TabIndex = 87
        Me.BtnZuzyte.Text = "Wpisz ilość zużytych arkuszy"
        Me.BtnZuzyte.UseVisualStyleBackColor = False
        '
        'BtnUsunPrzyjecieMagazynowe
        '
        Me.BtnUsunPrzyjecieMagazynowe.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtnUsunPrzyjecieMagazynowe.BackgroundImage = CType(resources.GetObject("BtnUsunPrzyjecieMagazynowe.BackgroundImage"), System.Drawing.Image)
        Me.BtnUsunPrzyjecieMagazynowe.Location = New System.Drawing.Point(1083, 684)
        Me.BtnUsunPrzyjecieMagazynowe.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnUsunPrzyjecieMagazynowe.Name = "BtnUsunPrzyjecieMagazynowe"
        Me.BtnUsunPrzyjecieMagazynowe.Size = New System.Drawing.Size(107, 49)
        Me.BtnUsunPrzyjecieMagazynowe.TabIndex = 84
        Me.BtnUsunPrzyjecieMagazynowe.Text = "Usuń Przyjęcie Magazynowe"
        Me.BtnUsunPrzyjecieMagazynowe.UseVisualStyleBackColor = False
        '
        'BtnGenerujKody
        '
        Me.BtnGenerujKody.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtnGenerujKody.BackgroundImage = Global.Radan_Magazyn_Blach_Moduł_Zarządzający.My.Resources.Resources._7
        Me.BtnGenerujKody.Enabled = False
        Me.BtnGenerujKody.Location = New System.Drawing.Point(755, 684)
        Me.BtnGenerujKody.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnGenerujKody.Name = "BtnGenerujKody"
        Me.BtnGenerujKody.Size = New System.Drawing.Size(112, 49)
        Me.BtnGenerujKody.TabIndex = 73
        Me.BtnGenerujKody.Text = "Generuj kody kreskowe dla wybranych arkuszy"
        Me.BtnGenerujKody.UseVisualStyleBackColor = False
        Me.BtnGenerujKody.Visible = False
        '
        'BtnUstawieniaAdmin
        '
        Me.BtnUstawieniaAdmin.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtnUstawieniaAdmin.BackgroundImage = CType(resources.GetObject("BtnUstawieniaAdmin.BackgroundImage"), System.Drawing.Image)
        Me.BtnUstawieniaAdmin.FlatAppearance.BorderSize = 0
        Me.BtnUstawieniaAdmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!)
        Me.BtnUstawieniaAdmin.Location = New System.Drawing.Point(1406, 684)
        Me.BtnUstawieniaAdmin.Name = "BtnUstawieniaAdmin"
        Me.BtnUstawieniaAdmin.Size = New System.Drawing.Size(107, 49)
        Me.BtnUstawieniaAdmin.TabIndex = 18
        Me.BtnUstawieniaAdmin.Text = "Ustawienia administracyjne"
        Me.BtnUstawieniaAdmin.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.Radan_Magazyn_Blach_Moduł_Zarządzający.My.Resources.Resources.radan
        Me.PictureBox1.Location = New System.Drawing.Point(865, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(631, 90)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'BtnPoDacie
        '
        Me.BtnPoDacie.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.BtnPoDacie.BackgroundImage = Global.Radan_Magazyn_Blach_Moduł_Zarządzający.My.Resources.Resources._7
        Me.BtnPoDacie.Enabled = False
        Me.BtnPoDacie.Location = New System.Drawing.Point(746, 108)
        Me.BtnPoDacie.Name = "BtnPoDacie"
        Me.BtnPoDacie.Size = New System.Drawing.Size(112, 33)
        Me.BtnPoDacie.TabIndex = 13
        Me.BtnPoDacie.Text = "Pokaż zakres dat"
        Me.BtnPoDacie.UseVisualStyleBackColor = False
        Me.BtnPoDacie.Visible = False
        '
        'BtnOdswiez
        '
        Me.BtnOdswiez.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtnOdswiez.BackgroundImage = Global.Radan_Magazyn_Blach_Moduł_Zarządzający.My.Resources.Resources._7
        Me.BtnOdswiez.Location = New System.Drawing.Point(258, 108)
        Me.BtnOdswiez.Name = "BtnOdswiez"
        Me.BtnOdswiez.Size = New System.Drawing.Size(112, 33)
        Me.BtnOdswiez.TabIndex = 12
        Me.BtnOdswiez.Text = "Odśwież"
        Me.BtnOdswiez.UseVisualStyleBackColor = False
        '
        'BtnWyszukaj
        '
        Me.BtnWyszukaj.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtnWyszukaj.BackgroundImage = Global.Radan_Magazyn_Blach_Moduł_Zarządzający.My.Resources.Resources._7
        Me.BtnWyszukaj.Location = New System.Drawing.Point(1321, 108)
        Me.BtnWyszukaj.Name = "BtnWyszukaj"
        Me.BtnWyszukaj.Size = New System.Drawing.Size(112, 33)
        Me.BtnWyszukaj.TabIndex = 11
        Me.BtnWyszukaj.Text = "Wyszukaj"
        Me.BtnWyszukaj.UseVisualStyleBackColor = False
        '
        'Monitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.BackColor = System.Drawing.Color.LightGray
        Me.BackgroundImage = Global.Radan_Magazyn_Blach_Moduł_Zarządzający.My.Resources.Resources._14
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1529, 829)
        Me.Controls.Add(Me.PictureBox12)
        Me.Controls.Add(Me.PictureBox10)
        Me.Controls.Add(Me.PictureBox9)
        Me.Controls.Add(Me.PictureBox8)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.BtnInfoOWersji)
        Me.Controls.Add(Me.BtnWyczyscTrackera)
        Me.Controls.Add(Me.BtnOdczytajPlikProjektuDoTrackera)
        Me.Controls.Add(Me.BtnNiskieStany)
        Me.Controls.Add(Me.BtnRaport)
        Me.Controls.Add(Me.BtnEdycjaPM)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnZuzyte)
        Me.Controls.Add(Me.TxtUprawnienia)
        Me.Controls.Add(Me.TxtLoginSql)
        Me.Controls.Add(Me.BtnUsunPrzyjecieMagazynowe)
        ' Me.Controls.Add(Me.Barcode1)
        Me.Controls.Add(Me.BtnOtworzPlik)
        Me.Controls.Add(Me.CBZrobBarcody)
        Me.Controls.Add(Me.LblUstawieniaKoduKreskowego)
        Me.Controls.Add(Me.CBWymiar)
        Me.Controls.Add(Me.CBGrubosc)
        Me.Controls.Add(Me.CbMaterial)
        Me.Controls.Add(Me.CBNumerMagazynowy)
        Me.Controls.Add(Me.LblKatalogDoZapisuBarcodow)
        Me.Controls.Add(Me.TxtSciezkaBarcode)
        Me.Controls.Add(Me.BtnGenerujKody)
        Me.Controls.Add(Me.BtnUstawieniaAdmin)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.DatePicker2)
        Me.Controls.Add(Me.DatePicker)
        Me.Controls.Add(Me.BtnPoDacie)
        Me.Controls.Add(Me.BtnOdswiez)
        Me.Controls.Add(Me.BtnWyszukaj)
        Me.Controls.Add(Me.TextBoxSzukaj)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label1)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Monitor"
        Me.Text = "Monitor"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBoxSzukaj As TextBox
    Friend WithEvents BtnWyszukaj As Button
    Friend WithEvents BtnOdswiez As Button
    Friend WithEvents BtnPoDacie As Button
    Friend WithEvents DatePicker As DateTimePicker
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents DatePicker2 As DateTimePicker
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BtnOtworzPlik As Button
    Friend WithEvents CBZrobBarcody As CheckBox
    Friend WithEvents LblUstawieniaKoduKreskowego As Label
    Friend WithEvents CBWymiar As CheckBox
    Friend WithEvents CBGrubosc As CheckBox
    Friend WithEvents CbMaterial As CheckBox
    Friend WithEvents CBNumerMagazynowy As CheckBox
    Friend WithEvents LblKatalogDoZapisuBarcodow As Label
    Friend WithEvents TxtSciezkaBarcode As TextBox
    Friend WithEvents BtnGenerujKody As Button
    ' Friend WithEvents Barcode1 As BarcodeLib.Barcode.WinForms.QRCodeWinForm
    Friend WithEvents BtnUsunPrzyjecieMagazynowe As Button
    Friend WithEvents TxtLoginSql As TextBox
    Friend WithEvents TxtUprawnienia As TextBox
    Friend WithEvents BtnZuzyte As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnEdycjaPM As Button
    Friend WithEvents BtnRaport As Button
    Friend WithEvents BtnNiskieStany As Button
    Friend WithEvents BtnOdczytajPlikProjektuDoTrackera As Button
    Friend WithEvents BtnWyczyscTrackera As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents BtnInfoOWersji As Button
    Public WithEvents BtnUstawieniaAdmin As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents PictureBox9 As PictureBox
    Friend WithEvents PictureBox10 As PictureBox
    Friend WithEvents PictureBox12 As PictureBox
End Class
