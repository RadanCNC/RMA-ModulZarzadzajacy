Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports RasterEdge.Imaging.Basic
Imports RasterEdge.XDoc.PDF
'Imports BarcodeLib

Public Class PrzyjęcieMagazynowe

    Private Sub frm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'Zawsze na wierzchu
        Me.TopMost = True
    End Sub

    Private Sub PrzyjęcieMagazynowe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Obrazki się ładnie wczytują dzięki tym trzem linijką
        'http://www.vbforums.com/showthread.php?212024-You-want-to-remove-Graphics-Flicker
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)
    End Sub

    Private Sub TxtIloscDostepna_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtIloscDostepna.KeyPress

        'Zezwól na wpisywanie Tylko Cyfr

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtPowierzony_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPowierzony.KeyPress

        'Zezwól na wpisywanie Tylko Cyfr 0,1

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) <> 48 And Asc(e.KeyChar) <> 49 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtPriorytet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPriorytet.KeyPress
        'Tylko Cyfry

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtGrubosc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGrubosc.KeyPress

        'Cyfry plus kropka (47)

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) = 47 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtX_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtX.KeyPress

        'Cyfry plus kropka (47)

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) = 47 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtY.KeyPress

        'Cyfry plus kropka (47)

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) = 47 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub



    Private Sub CBAdmin_CheckedChanged(sender As Object, e As EventArgs) Handles CBAdmin.CheckedChanged
        'Zmień widoczność jeżeli jesteś adminem
        If CBAdmin.Checked = True Then
            RichTextBox1.Visible = True
            DataGridView1.Visible = True
        Else
            RichTextBox1.Visible = False
            DataGridView1.Visible = False
        End If
    End Sub

    Private Sub TxtWytop_TextChanged(sender As Object, e As EventArgs) Handles TxtWytop.TextChanged

    End Sub



    Public Function SprawdzCzyIstniejeKatalog(ByVal Katalog As String) As Boolean
        If Directory.Exists(Katalog) = False Then
            MsgBox("Wskazany folder do zapisu Kodów Kreskowych nie istnieje. Sprawdź ścieżke do zapisu i spróbuj ponownie.")
            Return False
        Else
            Return True
        End If

    End Function

    Public Function SprawdzUstawieniaKoduKreskowego() As Boolean
        'Sprawdź poprawność ustawień Kodów kreskowych
        '    If CBZrobBarcody.Checked = True Then

        Dim IloscChecboxowZaznaczonych As Integer = 0

        If CBNumerMagazynowy.Checked = True Then
            IloscChecboxowZaznaczonych = IloscChecboxowZaznaczonych + 1
        End If
        If CbMaterial.Checked = True Then
            IloscChecboxowZaznaczonych = IloscChecboxowZaznaczonych + 1
        End If
        If CBGrubosc.Checked = True Then
            IloscChecboxowZaznaczonych = IloscChecboxowZaznaczonych + 1
        End If
        If CBWymiar.Checked = True Then
            IloscChecboxowZaznaczonych = IloscChecboxowZaznaczonych + 1
        End If

        'Jeżeli nie zaznaczono żadnego checkboxa to podaj komunikat i wyjdź
        If IloscChecboxowZaznaczonych = 0 Then
            MsgBox("Zaznacz przynajmniej jedną opcję do zapisu kodu kreskowego i spróbuj ponownie")
            Return False
        Else
            Return True
        End If

        '  End If

    End Function



    Private Sub BtnGenerujKod_Click(sender As Object, e As EventArgs) Handles BtnGenerujKod.Click
        'Sprawdź poprawność ustawień Kodów kreskowych
        If CBZrobBarcody.Checked = True Then
            If SprawdzCzyIstniejeKatalog(TxtSciezkaBarcode.Text) = False Then
                Exit Sub
            End If
            If SprawdzUstawieniaKoduKreskowego() = False Then
                Exit Sub
            End If
        End If

        'Barcode
        If CBZrobBarcody.Checked = True Then
            'Wyzerowanie danych
            Dim BarcodeData As String = ""
            Dim sciezka As String = ""

            If CBNumerMagazynowy.Checked = True Then
                BarcodeData = BarcodeData & TXTNumerMagazynowy.Text '& "-"
                sciezka = sciezka & TXTNumerMagazynowy.Text & "-"
            End If
            If CbMaterial.Checked = True Then
                BarcodeData = BarcodeData & TxtMaterial.Text
                sciezka = sciezka & TxtMaterial.Text
            End If
            If CBGrubosc.Checked = True Then
                BarcodeData = BarcodeData & TxtGrubosc.Text '& "#"
                sciezka = sciezka & "#" & TxtGrubosc.Text & "#"
            End If
            If CBWymiar.Checked = True Then
                BarcodeData = BarcodeData & TxtX.Text & "x" & TxtY.Text
                sciezka = sciezka & TxtX.Text & "x" & TxtY.Text
            End If
            Barcode1.Data = BarcodeData
            sciezka = TxtSciezkaBarcode.Text & "\" & sciezka & ".png"

            Try
                Barcode1.SaveAsImage(sciezka)
                MsgBox("Wygenerowano kod kreskowy: " & sciezka)
            Catch ex As Exception
                MsgBox("Nie zapisano kodu kreskowego. Sprawdź ścieżke do zapisu. " & ex.Message)
            End Try
        Else
            MsgBox("Włącz ustawienia Barcode")

        End If
        'Koniec Barcode


    End Sub

    Private Sub CBZrobBarcody_CheckedChanged(sender As Object, e As EventArgs) Handles CBZrobBarcody.CheckedChanged

        'Włącz lub wyłącz ustawienia do tworzenia barcodów
        CBGrubosc.Enabled = CBZrobBarcody.CheckState
        CbMaterial.Enabled = CBZrobBarcody.CheckState
        CBWymiar.Enabled = CBZrobBarcody.CheckState
        CBNumerMagazynowy.Enabled = CBZrobBarcody.CheckState
        LblKatalogDoZapisuBarcodow.Enabled = CBZrobBarcody.CheckState
        LblUstawieniaKoduKreskowego.Enabled = CBZrobBarcody.CheckState
        TxtSciezkaBarcode.Enabled = CBZrobBarcody.CheckState
        BtnGenerujKod.Enabled = CBZrobBarcody.CheckState

    End Sub

    Private Sub BtnOtworzPlik_Click(sender As Object, e As EventArgs) Handles BtnOtworzPlik.Click
        Dim myStream As Stream = Nothing
        Dim folderbrowser As New FolderBrowserDialog()

        If folderbrowser.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            TxtSciezkaBarcode.Text = folderbrowser.SelectedPath

        End If
    End Sub

    Private Sub BtnZatwierdz_Click(sender As Object, e As EventArgs) Handles BtnZatwierdzZuzyte.Click

        ' dim IdAkcji 
        'Sprawdź czy ilość zużytych nie przekroczy ilości rezerwacji
        Dim iloscZuzytych As Integer
        iloscZuzytych = CInt(TxtIloscZuzyta.Text) + CInt(TxtDodajIloscZuzytych.Text)

        If iloscZuzytych > CInt(TxtIloscRezerwacja.Text) Then
            MsgBox("Chcesz wpisać więcej zużytych arkuszy niż jest zarezerwowanych. 
                    Zarezerwuj więcej arkuszy i spróbuj ponownie.")
            Exit Sub
        End If

        Dim wynik As Integer = Windows.Forms.MessageBox.Show("Czy na pewno chcesz wpisać ilość zużytych do bazy danych?",
                                                             "Ilość Zużytych Arkuszy", MessageBoxButtons.YesNo)

        'Jeżeli tak do zapisz odpad do bazy i jako przyjęcie magazynowe do loga
        If wynik = DialogResult.Yes Then

            Dim tabela As String
            tabela = Sprawdz_Pierwsza_Cyfre_Zwroc_Tabele(TXTNumerMagazynowy.Text)

            Dim zapytanie As String

            'Zapytanie, które aktualizuje ilość zużytych arkuszy w tabeli Arkusze lub Odpady
            zapytanie = "Update " & tabela & " SET IloscZuzyte = IloscZuzyte + " & TxtDodajIloscZuzytych.Text &
            " WHERE[Numer Magazynowy] = " & TXTNumerMagazynowy.Text

            Wyslij_Zapytanie_SQL_Do_Bazy(zapytanie)
            DoFlowLogaDoPliku(zapytanie)

            'Zapytanie, które aktualizuje ilość zarezerwowanych arkuszy w tabeli Arkusze lub Odpady
            zapytanie = "Update " & tabela & " SET IloscRezerwacja = IloscRezerwacja - " & TxtDodajIloscZuzytych.Text &
            " WHERE[Numer Magazynowy] = " & TXTNumerMagazynowy.Text
            Wyslij_Zapytanie_SQL_Do_Bazy(zapytanie)
            DoFlowLogaDoPliku(zapytanie)

            'zapytanie, które aktualizuje ilość arkuszy w tabeli Arkusze
            zapytanie = "Update " & "Log2" & " SET IloscZuzytych = IloscZuzytych + " & TxtDodajIloscZuzytych.Text &
             " WHERE[IDAkcji] = " & TxtIDAkcji.Text & " and [IDArkusza] = " & TXTNumerMagazynowy.Text

            ' MsgBox(zapytanie)
            Wyslij_Zapytanie_SQL_Do_Bazy(zapytanie)

            DoFlowLogaDoPliku(zapytanie)
            MsgBox("Zaktualizowano ilości zużyte")

            'Zapisz Zużycie Arkuszy do LOGa
            Dim ZapytanieSQL As String
            ZapytanieSQL = "Insert into LOG2 " &
        "(Akcja, 
        IDArkusza,
        NazwaProjektu,
        IloscZuzytych, 
        Uzytkownik,
        Material,
        Grubosc,
        X,
        Y) values" &
        "('ZuzycieArkuszy'," &
        TXTNumerMagazynowy.Text & ",'" &
        SciezkaProjektu & "'," &
        TxtDodajIloscZuzytych.Text & "," &
        "'" & Uzytkownik.Login & "'," &
        "'" & TxtMaterial.Text & "'," &
        TxtGrubosc.Text & "," &
        TxtX.Text & "," &
        TxtY.Text &
        ")"

            Wyslij_Zapytanie_SQL_Do_Bazy(ZapytanieSQL)


            'odśwież widok tabeli
            Dim zapytanieOdswiez As String = ""

            zapytanieOdswiez = "Select * From Log2" '& tabela
            Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanieOdswiez, Monitor.DataGridView1)

            Me.Close()

            'Jeżeli nie to anuluj i nic nie rób

        End If
        If wynik = DialogResult.No Then

            Exit Sub
        End If

    End Sub

    Private Sub BtnZatwierdzEdycje_Click(sender As Object, e As EventArgs) Handles BtnZatwierdzEdycje.Click
        Dim wynik As Integer = Windows.Forms.MessageBox.Show("Czy na pewno chcesz zapisać zmiany?",
                                                                "Edycja przyjęcia magazynowego", MessageBoxButtons.YesNo)

        'Jeżeli tak do zapisz odpad do bazy i jako przyjęcie magazynowe do loga
        If wynik = DialogResult.Yes Then

            Dim tabela As String
            tabela = Sprawdz_Pierwsza_Cyfre_Zwroc_Tabele(TXTNumerMagazynowy.Text)

            Dim zapytanie As String

            'Zapytanie, które aktualizuje ilość arkuszy w tabeli Arkusze
            zapytanie = "Update " & tabela & " SET IloscDostepne = " & TxtIloscDostepna.Text & " , " &
                "IloscRezerwacja = " & TxtIloscRezerwacja.Text & " , " &
                "IloscZuzyte = " & TxtIloscZuzyta.Text & " , " &
                "X = " & TxtX.Text & " , " &
                "Y = " & TxtY.Text & " , " &
                "Material = '" & TxtMaterial.Text & "' , " &
                "Grubosc = " & TxtGrubosc.Text & " , " &
                "Pole_Uzytkownika = '" & TxtPoleUzytkownika.Text & "' , " &
                "Pole_Uzytkownika2 = '" & TxtPole_uzytkownika2.Text & "' , " &
                "Klient = '" & TxtKlient.Text & "' , " &
                "Wytop = '" & TxtWytop.Text & "' , " &
                "Atest = '" & TxtAtest.Text & "' , " &
                "WZ = '" & TxtWz.Text & "' , " &
                "Powierzony = '" & CBool(TxtPowierzony.Text) & "' , " &
                "Lokalizacja = '" & TxtLokalizacja.Text & "'  " &
                     " WHERE[Numer Magazynowy] = " & TXTNumerMagazynowy.Text

            Wyslij_Zapytanie_SQL_Do_Bazy(zapytanie)
            'MsgBox(zapytanie)
            DoFlowLogaDoPliku(zapytanie)

            'Zapisz Przyjęcie Magazynowe do LOGa
            Dim ZapytanieSQL As String
            ZapytanieSQL = "Insert into LOG2 " &
        "(Akcja, 
        IDArkusza,
        NazwaProjektu,
        IloscDostepnych,
        IloscZarezerwowanych,
        IloscZuzytych, 
        Uzytkownik,
        Material,
        Grubosc,
        X,
        Y) values" &
        "('EdycjaArkuszy'," &
        TXTNumerMagazynowy.Text & ",'" &
        SciezkaProjektu & "'," &
        TxtIloscDostepna.Text & "," &
        TxtIloscRezerwacja.Text & "," &
        TxtIloscZuzyta.Text & "," &
        "'" & Uzytkownik.Login & "'," &
        "'" & TxtMaterial.Text & "'," &
        TxtGrubosc.Text & "," &
        TxtX.Text & "," &
        TxtY.Text &
        ")"

            Wyslij_Zapytanie_SQL_Do_Bazy(ZapytanieSQL)
            'Koniec Loga

            'Odśwież widok tabeli
            Dim zapytanieOdswiez As String = ""
            zapytanieOdswiez = "Select * From " & tabela
            Wyslij_Zapytanie_SQL_Do_Bazy(zapytanieOdswiez)


        End If
        If wynik = DialogResult.No Then
            'Nic nie rób
        End If
    End Sub
End Class