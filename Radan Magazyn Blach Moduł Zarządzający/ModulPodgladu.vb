Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml

Public Class Monitor

    Dim ListaArkuszyImport As New List(Of DostepneArkusze)()
    Dim ListaNestingow As New List(Of Nesting)
    Dim ListaPartow As New List(Of Part)

    Private Sub ModulZarzadzajacyLoad(sender As Object, e As EventArgs) Handles MyBase.Load

        'Obrazki się ładnie wczytują dzięki tym trzem linijką
        'http://www.vbforums.com/showthread.php?212024-You-want-to-remove-Graphics-Flicker
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)


        TxtUprawnienia.Text = Uzytkownik.Uprawnienia                                            'Pokaż uprawnienia użytkownika

        Connect.wczytajUstawianieZPliku()                                                       'Wczytaj ustawienia bazy SQL

        Dim login As String
        login = Environment.UserName
        TextBox1.Text = login

        'Przy pierwszy uruchomieniu okna wyświetl wszystkie Arkusze
        Try
            sql.ExecQuery("Select * from Arkusze where " & "IloscDostepne" & " >= 0")

            'Jeżeli pojawi się problem to zakończ, jeżeli nie to przypisz dane do datagridview
            If sql.HasException(True) Then Exit Sub
            DataGridView1.DataSource = sql.DBDT

        Catch ex As Exception
            MsgBox("Błąd podczas łączenia z bazą danych")
        End Try

        TxtLoginSql.Text = LoginSql

        If Uzytkownik.Uprawnienia > 1 Then
            BtnWyczyscTrackera.Enabled = False
            ' BtnOdczytajPlikProjektuDoTrackera.Enabled = False
        End If
        If Uzytkownik.Uprawnienia > 3 Then
            'BtnWyczyscTrackera.Enabled = False
            BtnOdczytajPlikProjektuDoTrackera.Enabled = False
        End If


    End Sub

    Private Sub frm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'Okno zawsze na wierzchu
        'Me.TopMost = True
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        Dim zapytanie As String

        If ComboBox1.SelectedIndex = 3 Then                                      'Zakładka Tracker

            zapytanie = "Select * from Tracker"
            Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, DataGridView1)
            Wl_Wyl_Barcode(False)
            BtnUsunPrzyjecieMagazynowe.Enabled = False
            BtnZuzyte.Enabled = False
            BtnEdycjaPM.Enabled = False
            BtnRaport.Enabled = False
            BtnNiskieStany.Enabled = False

        End If

        If ComboBox1.SelectedIndex = 2 Then                                      'Zakładka Log

            zapytanie = "Select * from Log2"
            If Uzytkownik.Uprawnienia > 3 Then
                zapytanie = "Select * from Log2 where Akcja = 'Rezerwacja'"
            End If
            Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, DataGridView1)
            Wl_Wyl_Barcode(False)
            BtnUsunPrzyjecieMagazynowe.Enabled = True
            BtnZuzyte.Enabled = True
            BtnEdycjaPM.Enabled = False
            BtnRaport.Enabled = False
            BtnNiskieStany.Enabled = False


        End If

        If ComboBox1.SelectedIndex = 1 Then                                      'Zakładka Odpady

            zapytanie = "Select * from Odpady"
            Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, DataGridView1)
            Wl_Wyl_Barcode(True)
            BtnUsunPrzyjecieMagazynowe.Enabled = False
            BtnZuzyte.Enabled = False
            BtnEdycjaPM.Enabled = True
            BtnRaport.Enabled = True
            BtnNiskieStany.Enabled = True
        End If

        If ComboBox1.SelectedIndex = 0 Then                                      'Zakładka Arkusze

            zapytanie = "Select * from Arkusze"
            Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, DataGridView1)
            Wl_Wyl_Barcode(True)
            BtnUsunPrzyjecieMagazynowe.Enabled = False
            BtnZuzyte.Enabled = False
            BtnEdycjaPM.Enabled = True
            BtnRaport.Enabled = True
            BtnNiskieStany.Enabled = True
        End If
    End Sub

    Public Sub Wl_Wyl_Barcode(ByVal wartosc As Boolean)

        'Włącz lub wyłącz przyciski do generowania kodów kreskowych
        BtnGenerujKody.Enabled = wartosc
        LblKatalogDoZapisuBarcodow.Enabled = wartosc
        LblUstawieniaKoduKreskowego.Enabled = wartosc
        TxtSciezkaBarcode.Enabled = wartosc
        CBGrubosc.Enabled = wartosc
        CbMaterial.Enabled = wartosc
        CBNumerMagazynowy.Enabled = wartosc
        CBWymiar.Enabled = wartosc
        CBZrobBarcody.Enabled = wartosc
        'Barcode1.Enabled = wartosc
        BtnOtworzPlik.Enabled = wartosc

    End Sub

    Private Sub Wyszukaj_Click(sender As Object, e As EventArgs) Handles BtnWyszukaj.Click
        Dim ZapytanieSQL As String

        Dim Szukana As String = TextBoxSzukaj.Text

        If ComboBox1.SelectedIndex = 0 Then

            Try
                'Select Case* From EmployeeTable Where Convert(VARCHAR, empname) = '" + comboBox1.Text + "' ;";

                If IsNumeric(Szukana) Then
                    ZapytanieSQL = "Select * from Arkusze where Priorytet = " & Szukana &
                " or Grubosc = " & Szukana &
                " or X = " & Szukana &
                " or Y = " & Szukana &
                " or [Numer Magazynowy] = " & Szukana &
             " or IloscDostepne = " & Szukana &
             " or IloscZuzyte = " & Szukana &
            " or IloscRezerwacja = " & Szukana
                Else
                    'MsgBox("Szukana nie jest liczbą")
                    ZapytanieSQL = "Select * from Arkusze where CONVERT(VARCHAR, Material) = '" & Szukana & "'" &
                " or CONVERT(VARCHAR, Klient) = '" & Szukana & "'" &
                " or CONVERT(VARCHAR, Atest) = '" & Szukana & "'" &
                " or CONVERT(VARCHAR, Wytop) = '" & Szukana & "'" &
                " or CONVERT(VARCHAR, WZ) = '" & Szukana & "'" &
                " or CONVERT(VARCHAR, Size_Units) = '" & Szukana & "'" &
                " or CONVERT(VARCHAR, Pole_uzytkownika) = '" & Szukana & "'"
                    '" or Lokalizacja = '" & Szukana & "'"
                    ' " or Status = '" & Szukana & "'"

                End If

                'ZapytanieSQL = TrimStr(ZapytanieSQL, " Or ")
                'MsgBox(ZapytanieSQL)

                sql.ExecQuery(ZapytanieSQL)
                DataGridView1.DataSource = sql.DBDT
                'Jeżeli pojawi się problem to zakończ, jeżeli nie to przypisz dane do datagridview
                If sql.HasException(True) Then Exit Sub

            Catch ex As Exception

            End Try
        End If

        If ComboBox1.SelectedIndex = 1 Then

            Try
                'Select Case* From EmployeeTable Where Convert(VARCHAR, empname) = '" + comboBox1.Text + "' ;";

                If IsNumeric(Szukana) Then
                    ZapytanieSQL = "Select * from Odpady where Priorytet = " & Szukana &
                " or Grubosc = " & Szukana &
                " or X = " & Szukana &
                " or Y = " & Szukana &
                " or [Numer Magazynowy] = " & Szukana &
             " or IloscDostepne = " & Szukana &
             " or IloscZuzyte = " & Szukana &
            " or IloscRezerwacja = " & Szukana
                Else
                    'MsgBox("Szukana nie jest liczbą")
                    ZapytanieSQL = "Select * from Odpady where CONVERT(VARCHAR, Material) = '" & Szukana & "'" &
                " or CONVERT(VARCHAR, Klient) = '" & Szukana & "'" &
                " or CONVERT(VARCHAR, Atest) = '" & Szukana & "'" &
                " or CONVERT(VARCHAR, Wytop) = '" & Szukana & "'" &
                " or CONVERT(VARCHAR, WZ) = '" & Szukana & "'" &
                " or CONVERT(VARCHAR, Size_Units) = '" & Szukana & "'" &
                " or CONVERT(VARCHAR, Pole_uzytkownika) = '" & Szukana & "'"
                    '" or Lokalizacja = '" & Szukana & "'"
                    ' " or Status = '" & Szukana & "'"

                End If

                'ZapytanieSQL = TrimStr(ZapytanieSQL, " Or ")
                'MsgBox(ZapytanieSQL)

                sql.ExecQuery(ZapytanieSQL)
                DataGridView1.DataSource = sql.DBDT
                'Jeżeli pojawi się problem to zakończ, jeżeli nie to przypisz dane do datagridview
                If sql.HasException(True) Then Exit Sub

            Catch ex As Exception

            End Try
        End If

        If ComboBox1.SelectedIndex = 2 Then
            Try
                If IsNumeric(Szukana) Then
                    ZapytanieSQL = "Select * from Log2 where IDArkusza = " & Szukana &
                    " or IDAkcji = " & Szukana &
                    " or IloscDostepnych = " & Szukana
                    '" or X = " & Szukana &
                    '" or Y = " & Szukana &
                Else
                    'MsgBox("Szukana nie jest liczbą")
                    ZapytanieSQL = "Select * from Log2 where Material = '" & Szukana & "'" &
                    " or CONVERT(VARCHAR, Akcja) = '" & Szukana & "'" &
                    " or CONVERT(VARCHAR, NazwaProjektu) = '" & Szukana & "'" &
                    " or CONVERT(VARCHAR, Uzytkownik) = '" & Szukana & "'"
                End If

                'ZapytanieSQL = TrimStr(ZapytanieSQL, " Or ")
                'MsgBox(ZapytanieSQL)

                sql.ExecQuery(ZapytanieSQL)
                DataGridView1.DataSource = sql.DBDT
                'Jeżeli pojawi się problem to zakończ, jeżeli nie to przypisz dane do datagridview
                If sql.HasException(True) Then Exit Sub

            Catch ex As Exception

            End Try
        End If


    End Sub

    Private Sub BtnOdswiez_Click(sender As Object, e As EventArgs) Handles BtnOdswiez.Click
        Dim zapytanie As String

        Select Case ComboBox1.SelectedIndex
            Case 0
                zapytanie = "Select * from Arkusze"
                Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, DataGridView1)
            Case 1
                zapytanie = "Select * from Odpady"
                Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, DataGridView1)
            Case 2
                zapytanie = "Select * from Log2"
                Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, DataGridView1)
            Case 3
                zapytanie = "Select * from Tracker"
                Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, DataGridView1)

        End Select
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtnPoDacie.Click

        'Dim Odtermin As DateTime = DateTime.ParseExact(Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)
        Dim Odtermin As Date = DatePicker.Value.Date

        'Odtermin = Odtermin.ToString("MM/dd/yyyy"

        'Dim Dotermin As Date = DateTime.ParseExact(Text, "MM/dd/yyyy", CultureInfo.InvariantCulture)
        Dim Dotermin As Date = DatePicker2.Value.Date

        Odtermin.ToString("dd HH:mm:ss/MM/yyyy")
        ' Odtermin.ToShortDateString()
        ' Dotermin.ToShortDateString()

        Dotermin.ToString("dd HH:mm:ss/MM/yyyy")
        'Dotermin = DatePicker2.Value
        'Dotermin = Dotermin.ToString("MM/dd/yyyy HH:mm:ss.fff")

        'Dotermin = Date.Now()
        ' MsgBox(Dotermin)

        'Odtermin = Odtermin & " 01:00:00"
        'MsgBox("Od: " & Odtermin & "Do: " & Dotermin)

        Dim Zapytanie As String

        Select Case ComboBox1.SelectedIndex
            Case 0
                Zapytanie = "Select * from Arkusze where [Data przyjecia] BETWEEN '" & Odtermin & "' AND '" & Dotermin & "'"
                'MsgBox(Zapytanie)
                Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(Zapytanie, DataGridView1)
            Case 1
                Zapytanie = "Select * from Odpady where [Data przyjecia] BETWEEN '" & Odtermin & "' AND '" & Dotermin & "'"
                'MsgBox(Zapytanie)
                Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(Zapytanie, DataGridView1)
            Case 2
                'WHERE [DateTime] BETWEEN '2013-01-01' AND '2013-12-31' GROUP BY [date] ' -- use appropriate date format here

                Zapytanie = "Select * from Log2 where [Data] BETWEEN '" & Odtermin & "' AND '" & Dotermin & "'"
                'Zapytanie = "Select * from Log2 where [Data] BETWEEN '06/22/2017' And '07/04/2017'"
                'MsgBox(Zapytanie)
                Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(Zapytanie, DataGridView1)
            Case 3
                Zapytanie = "Select * from Tracker where [Data] BETWEEN '" & Odtermin.ToString("dd HH:mm:ss/MM/yyyy") & "' AND '" & Dotermin.ToString("dd HH:mm:ss/MM/yyyy") & "'"
                Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(Zapytanie, DataGridView1)

        End Select

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then

            Dim Zapytanie As String
            Select Case ComboBox1.SelectedIndex
                Case 0
                    Zapytanie = "Select * from Arkusze where Powierzony = 1"
                    Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(Zapytanie, DataGridView1)
                Case 1
                    Zapytanie = "Select * from Log2"
                    'Zapytanie = "Select * from Log2 where [Data] BETWEEN '06/22/2017' And '07/04/2017'"
                    Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(Zapytanie, DataGridView1)
            End Select
        End If

    End Sub

    Private Sub BtnUstawieniaAdmin_Click_1(sender As Object, e As EventArgs) Handles BtnUstawieniaAdmin.Click

        'Jeśli użytkownik ma najwyższe uprawnienia to pokaż ustawienia administracyjne
        If Uzytkownik.Uprawnienia = 1 Then
            Dim window As New Ustawienia_administracyjne
            window.Show()
        Else
            MsgBox("Nie masz wystarczających uprawnień aby korzystać z tej funkcji")
        End If

    End Sub

    Private Sub BtnGenerujKody_Click(sender As Object, e As EventArgs) Handles BtnGenerujKody.Click


        'Pytanie do użytkownika czy chce kontynuować?
        Dim wynik As Integer = Windows.Forms.MessageBox.Show("Czy na pewno chcesz wygenerować Barcody?",
                                                                 "Generuj Barcody", MessageBoxButtons.YesNo)

        If wynik = DialogResult.Yes Then

            'Sprawdź poprawność ustawień Kodów kreskowych
            If CBZrobBarcody.Checked = True Then

                'Sprawdź czy istnieje katalog docelowy
                If IO.Directory.Exists(TxtSciezkaBarcode.Text) = False Then
                    MsgBox("Wskazany folder do zapisu Barcode nie istnieje. 
                            Sprawdź ścieżke do zapisu i spróbuj ponownie.")
                    Exit Sub
                End If

                'Sprawdź czy użytkownik zaznaczył chociaż jedną z opcji
                Dim IloscChecboxowZaznaczonych As Integer = 0

                If CBNumerMagazynowy.Checked = True Then
                    IloscChecboxowZaznaczonych = IloscChecboxowZaznaczonych + 1
                ElseIf CbMaterial.Checked = True Then
                    IloscChecboxowZaznaczonych = IloscChecboxowZaznaczonych + 1
                ElseIf CBGrubosc.Checked = True Then
                    IloscChecboxowZaznaczonych = IloscChecboxowZaznaczonych + 1
                ElseIf CBWymiar.Checked = True Then
                    IloscChecboxowZaznaczonych = IloscChecboxowZaznaczonych + 1
                End If

                'Jeżeli nie zaznaczono żadnego checkboxa to podaj komunikat i wyjdź
                If IloscChecboxowZaznaczonych = 0 Then
                    MsgBox("Zaznacz przynajmniej jedną opcję do zapisu kodu kreskowego i spróbuj ponownie")
                    Exit Sub
                End If

            End If

            'Pętla, w której przypisujemy dane z datagridview do listy klasy Arkusz
            For row As Integer = 0 To DataGridView1.RowCount - 2

                If DataGridView1.Rows(row).Selected = True Then
                    ListaArkuszyImport.Add(New DostepneArkusze(DataGridView1, row))
                End If
            Next

            'Barcode
            Dim BarcodeData As String 'Zawartość kodu Kreskowego
            Dim NazwaPlikuBarcode As String 'Ścieżka do zapisu kodu 

            Dim IloscRzedow As Integer = 0

            For Each ArkuszImport As DostepneArkusze In ListaArkuszyImport
                IloscRzedow = IloscRzedow + 1

                'Wyzerowanie zmiennych
                BarcodeData = ""
                NazwaPlikuBarcode = ""

                If CBZrobBarcody.Checked = True Then

                    'Uzupełnienie zmiennych w zależności od wybranej opcji
                    If CBNumerMagazynowy.Checked = True Then
                        BarcodeData = BarcodeData & CStr(ArkuszImport.NumerMagazynowy) '& "-"
                        NazwaPlikuBarcode = NazwaPlikuBarcode & CStr(ArkuszImport.NumerMagazynowy) & "-"
                    ElseIf CbMaterial.Checked = True Then
                        BarcodeData = BarcodeData & ArkuszImport.Material
                        NazwaPlikuBarcode = NazwaPlikuBarcode & ArkuszImport.Material
                    ElseIf CBGrubosc.Checked = True Then
                        BarcodeData = BarcodeData & CStr(ArkuszImport.Grubosc) '& "#"
                        NazwaPlikuBarcode = NazwaPlikuBarcode & "#" & CStr(ArkuszImport.Grubosc) & "#"
                    ElseIf CBWymiar.Checked = True Then
                        BarcodeData = BarcodeData & CStr(ArkuszImport.X) & "x" & CStr(ArkuszImport.Y)
                        NazwaPlikuBarcode = NazwaPlikuBarcode & CStr(ArkuszImport.X) & "x" & CStr(ArkuszImport.Y)
                    End If

                    'Barcode1.Data = BarcodeData
                    NazwaPlikuBarcode = TxtSciezkaBarcode.Text & "\" & NazwaPlikuBarcode & ".png"

                    Try
                        'Zapisz Plik z kodem kreskowym
                        'Barcode1.SaveAsImage(NazwaPlikuBarcode)
                        '  IloscWygenerowanychKodowKreskowych = IloscWygenerowanychKodowKreskowych + 1
                    Catch ex As Exception
                        MsgBox("Wystąpił błąd podczas zapisu kodu kreskowego." & ex.Message)
                    End Try
                End If
            Next
            If IloscRzedow > 0 Then
                MsgBox("Wygenerowano kody kreskowe ")
            Else
                MsgBox("Brak zaznaczonych elementów na liście Arkuszy/Odpadów")
            End If
            'Barcode koniec
        End If
    End Sub

    Private Sub BtnUsunPrzyjecieMagazynowe_Click(sender As Object, e As EventArgs) Handles BtnUsunPrzyjecieMagazynowe.Click

        'Jeżeli użytkownik nie ma najniższych uprawnień to
        If Uzytkownik.Uprawnienia < 4 Then

            Dim wynik As Integer = Windows.Forms.MessageBox.Show("Czy na pewno chcesz usunąć przyjęcie magazynowe?",
                                                                 "Usuń przyjęcie magazynowe", MessageBoxButtons.YesNo)

            If wynik = DialogResult.Yes Then

                Dim tabela As String = "Arkusze"
                Dim zapytanie As String
                Try
                    For i As Integer = 0 To DataGridView1.Rows.Count - 2
                        If DataGridView1.Rows(i).Selected Then
                            If CStr(DataGridView1.Rows(i).Cells(1).Value) = "PrzyjecieMagazynowe" Then

                                tabela = Sprawdz_Pierwsza_Cyfre_Zwroc_Tabele(CStr(DataGridView1.Rows(i).Cells(3).Value))

                                'Zapytanie, które aktualizuje ilość arkuszy w tabeli Arkusze
                                zapytanie = "Update " & tabela & " SET IloscDostepne = IloscDostepne - " &
                        CStr(DataGridView1.Rows(i).Cells(4).Value) &
                         " WHERE[Numer Magazynowy] = " & DataGridView1.Rows(i).Cells(3).Value

                                If Wyslij_Zapytanie_SQL_Do_Bazy_Zwroc_info(zapytanie) = True Then

                                    DoFlowLogaDoPliku("Anulowanie Przyjęcia Magazynowego:" & zapytanie &
                                              "ID Akcji: " & DataGridView1.Rows(i).Cells(0).Value)

                                    'Usuń informacje z Loga
                                    zapytanie = "Delete from LOG2 where [IDArkusza]  = " &
                                         DataGridView1.Rows(i).Cells(3).Value
                                    Wyslij_Zapytanie_SQL_Do_Bazy(zapytanie)
                                    DoFlowLogaDoPliku("Usunięcie informacji z loga:" & zapytanie)

                                Else
                                    DoFlowLogaDoPliku("Arkusze z tego przyjęcia magazynowego są już zarezerwowane. 
                                Anuluj najpierw rezerwacje")
                                    MsgBox("Arkusze z tego przyjęcia magazynowego są już zarezerwowane. 
                                Anuluj najpierw rezerwacje")
                                End If
                            Else
                                MsgBox("Zaznaczona linia nie jest przyjęciem magazynowym")
                            End If

                        End If
                    Next
                Catch ex As Exception
                    MsgBox("Wystąpił błąd przy aktualizowaniu dostępnych ilości Arkusza")
                End Try

                'Zapytanie odświeżające widok datagridview
                zapytanie = "Select * from Log2"
                Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, DataGridView1)
                DoFlowLogaDoPliku("Odświeżenie widoku datagrdiview:" & zapytanie)

                ' MsgBox("Anulowano Wybrane Przyjęcia Magazynowe")

                If wynik = DialogResult.No Then

                End If
            End If
        Else
            MsgBox("Nie masz wystarczających uprawnień aby korzystać z tej funkcji")
        End If

    End Sub

    Private Sub Btn_Zuzyte_Click(sender As Object, e As EventArgs) Handles BtnZuzyte.Click
        If Uzytkownik.Uprawnienia = 4 Or Uzytkownik.Uprawnienia = 3 Or Uzytkownik.Uprawnienia = 1 Then
            Dim ilosc As Integer = 0
            For i As Integer = 0 To DataGridView1.Rows.Count - 2
                If DataGridView1.Rows(i).Selected Then
                    ilosc = ilosc + 1
                End If
            Next

            If ilosc > 0 Then

                For i As Integer = 0 To DataGridView1.Rows.Count - 2
                    If DataGridView1.Rows(i).Selected Then
                        If ComboBox1.SelectedIndex = 2 Then
                            WyswietlDaneArkuszaWOknieDoZuzyciaWLogu(DataGridView1, i)
                        Else
                            WyswietlDaneArkuszaWOknieDoZuzycia(DataGridView1, i)
                        End If

                    End If
                Next
            Else
                MsgBox("Zaznacz poprawnie cały rząd")
            End If

        Else
            MsgBox("Nie masz wystarczających uprawnień by korzystać z tej funkcji")
        End If

    End Sub

    Public Overloads Sub WyswietlDaneArkuszaWOknieDoZuzyciaWLogu(ByRef datagridview1 As DataGridView, ByVal Index As Integer)
        'Pokaz dane w formularzu przyjęcia magazynowego

        Dim PokazArkusz As New PrzyjęcieMagazynowe

        PokazArkusz.Show()

        PokazArkusz.BtnGenerujKod.Visible = True                                               'Wł/wył. Przyciski
        PokazArkusz.Barcode1.Visible = True
        PokazArkusz.BtnZatwierdzEdycje.Visible = False

        PokazArkusz.CBAdmin.Visible = False

        PokazArkusz.TxtDataPrzyjecia.Enabled = False                                           'Wyłącz Textboxy
        PokazArkusz.TXTNumerMagazynowy.Enabled = False
        PokazArkusz.TxtAtest.Enabled = False
        PokazArkusz.TXTNumerMagazynowy.Enabled = False
        PokazArkusz.TxtMaterial.Enabled = False
        PokazArkusz.TxtGrubosc.Enabled = False
        PokazArkusz.TxtIloscDostepna.Enabled = False
        PokazArkusz.TxtIloscRezerwacja.Enabled = False
        PokazArkusz.TxtIloscZuzyta.Enabled = False
        PokazArkusz.TxtX.Enabled = False
        PokazArkusz.TxtY.Enabled = False

        PokazArkusz.TxtDodajIloscZuzytych.Enabled = True                                       'Włącz Textbox

        PokazArkusz.TxtPriorytet.Visible = False                                               'Niewidoczne Textboxy
        PokazArkusz.TxtJednostki.Visible = False
        PokazArkusz.TxtPoleUzytkownika.Visible = False
        PokazArkusz.TxtPole_uzytkownika2.Visible = False
        PokazArkusz.TxtKlient.Visible = False
        PokazArkusz.TxtWytop.Visible = False
        PokazArkusz.TxtAtest.Visible = False
        PokazArkusz.TxtDataPrzyjecia.Enabled = False
        PokazArkusz.TxtWz.Visible = False
        PokazArkusz.TxtPowierzony.Visible = False
        PokazArkusz.TxtLokalizacja.Visible = False


        'Przypisz Wartości z datagridview
        PokazArkusz.TxtIDAkcji.Text = datagridview1.Rows(Index).Cells(0).Value
        PokazArkusz.TXTNumerMagazynowy.Text = datagridview1.Rows(Index).Cells(3).Value
        PokazArkusz.TxtMaterial.Text = datagridview1.Rows(Index).Cells(9).Value
        PokazArkusz.TxtGrubosc.Text = datagridview1.Rows(Index).Cells(10).Value '2
        PokazArkusz.TxtIloscDostepna.Text = datagridview1.Rows(Index).Cells(4).Value
        PokazArkusz.TxtIloscRezerwacja.Text = datagridview1.Rows(Index).Cells(5).Value '9
        PokazArkusz.TxtIloscZuzyta.Text = datagridview1.Rows(Index).Cells(6).Value
        PokazArkusz.TxtX.Text = datagridview1.Rows(Index).Cells(11).Value
        PokazArkusz.TxtY.Text = datagridview1.Rows(Index).Cells(12).Value
        ' PokazArkusz.TxtPriorytet.Text = datagridview1.Rows(Index).Cells(8).Value
        ' PokazArkusz.TxtJednostki.Text = datagridview1.Rows(Index).Cells(9).Value
        '10
        'PokazArkusz.TxtPoleUzytkownika.Text = datagridview1.Rows(Index).Cells(11).Value
        ' PokazArkusz.TxtPole_uzytkownika2.Text = datagridview1.Rows(Index).Cells(12).Value
        ' PokazArkusz.TxtKlient.Text = datagridview1.Rows(Index).Cells(13).Value
        ' PokazArkusz.TxtWytop.Text = datagridview1.Rows(Index).Cells(14).Value
        ' PokazArkusz.TxtAtest.Text = datagridview1.Rows(Index).Cells(15).Value
        PokazArkusz.TxtDataPrzyjecia.Text = datagridview1.Rows(Index).Cells(8).Value
        ' PokazArkusz.TxtWz.Text = datagridview1.Rows(Index).Cells(17).Value
        'PokazArkusz.TxtPowierzony.Text = datagridview1.Rows(Index).Cells(18).Value
        'PokazArkusz.TxtLokalizacja.Text = datagridview1.Rows(Index).Cells(19).Value

        PokazArkusz.Text = "Arkusz w Magazynie"
    End Sub

    Public Overloads Sub WyswietlDaneArkuszaWOknieDoZuzycia(ByRef datagridview1 As DataGridView, ByVal Index As Integer)

        'Pokaz dane w formularzu przyjęcia magazynowego
        Dim PokazArkusz As New PrzyjęcieMagazynowe
        PokazArkusz.Show()

        PokazArkusz.BtnGenerujKod.Visible = True                                                'Wł/Wył. Przyciski
        PokazArkusz.Barcode1.Visible = True
        PokazArkusz.BtnZatwierdzEdycje.Visible = False

        PokazArkusz.CBAdmin.Visible = False

        PokazArkusz.TxtDataPrzyjecia.Enabled = False                                            'Wyłącz Textboxy
        PokazArkusz.TXTNumerMagazynowy.Enabled = False
        PokazArkusz.TxtAtest.Enabled = False
        PokazArkusz.TXTNumerMagazynowy.Enabled = False
        PokazArkusz.TxtMaterial.Enabled = False
        PokazArkusz.TxtGrubosc.Enabled = False
        PokazArkusz.TxtIloscDostepna.Enabled = False
        PokazArkusz.TxtIloscRezerwacja.Enabled = False
        PokazArkusz.TxtIloscZuzyta.Enabled = False
        PokazArkusz.TxtDodajIloscZuzytych.Enabled = True
        PokazArkusz.TxtX.Enabled = False
        PokazArkusz.TxtY.Enabled = False
        PokazArkusz.TxtPriorytet.Enabled = False
        PokazArkusz.TxtJednostki.Enabled = False
        PokazArkusz.TxtPoleUzytkownika.Enabled = False
        PokazArkusz.TxtPole_uzytkownika2.Enabled = False
        PokazArkusz.TxtKlient.Enabled = False
        PokazArkusz.TxtWytop.Enabled = False
        PokazArkusz.TxtAtest.Enabled = False
        PokazArkusz.TxtDataPrzyjecia.Enabled = False
        PokazArkusz.TxtWz.Enabled = False
        PokazArkusz.TxtPowierzony.Enabled = False
        PokazArkusz.TxtLokalizacja.Enabled = False

        'Przypisz Wartości z datagridview
        PokazArkusz.TXTNumerMagazynowy.Text = datagridview1.Rows(Index).Cells(0).Value
        PokazArkusz.TxtMaterial.Text = datagridview1.Rows(Index).Cells(1).Value
        PokazArkusz.TxtGrubosc.Text = datagridview1.Rows(Index).Cells(2).Value
        PokazArkusz.TxtIloscDostepna.Text = datagridview1.Rows(Index).Cells(3).Value
        PokazArkusz.TxtIloscRezerwacja.Text = datagridview1.Rows(Index).Cells(4).Value
        PokazArkusz.TxtIloscZuzyta.Text = datagridview1.Rows(Index).Cells(5).Value
        PokazArkusz.TxtX.Text = datagridview1.Rows(Index).Cells(6).Value
        PokazArkusz.TxtY.Text = datagridview1.Rows(Index).Cells(7).Value
        PokazArkusz.TxtPriorytet.Text = datagridview1.Rows(Index).Cells(8).Value
        PokazArkusz.TxtJednostki.Text = datagridview1.Rows(Index).Cells(9).Value
        '10
        PokazArkusz.TxtPoleUzytkownika.Text = datagridview1.Rows(Index).Cells(11).Value
        PokazArkusz.TxtPole_uzytkownika2.Text = datagridview1.Rows(Index).Cells(12).Value
        PokazArkusz.TxtKlient.Text = datagridview1.Rows(Index).Cells(13).Value
        PokazArkusz.TxtWytop.Text = datagridview1.Rows(Index).Cells(14).Value
        PokazArkusz.TxtAtest.Text = datagridview1.Rows(Index).Cells(15).Value
        PokazArkusz.TxtDataPrzyjecia.Text = datagridview1.Rows(Index).Cells(16).Value
        PokazArkusz.TxtWz.Text = datagridview1.Rows(Index).Cells(17).Value
        PokazArkusz.TxtPowierzony.Text = datagridview1.Rows(Index).Cells(18).Value
        PokazArkusz.TxtLokalizacja.Text = datagridview1.Rows(Index).Cells(19).Value

        PokazArkusz.Text = "Arkusz w Magazynie"                                             'Napis na belce w oknie 

    End Sub
    Public Overloads Sub WyswietlDaneArkuszaWOknieDoEdycji(ByRef datagridview1 As DataGridView, ByVal Index As Integer)

        'Pokaz dane w formularzu przyjęcia magazynowego
        Dim PokazArkusz As New PrzyjęcieMagazynowe
        PokazArkusz.Show()

        PokazArkusz.BtnGenerujKod.Visible = True                                                'Wł/Wył. Przyciski
        PokazArkusz.Barcode1.Visible = True
        PokazArkusz.BtnZatwierdzZuzyte.Visible = False
        PokazArkusz.CBZrobBarcody.Checked = False
        PokazArkusz.TxtIloscRezerwacja.Enabled = True
        PokazArkusz.TxtDodajIloscZuzytych.Visible = False
        PokazArkusz.LblDodajiloscZuzytych.Visible = False

        PokazArkusz.CBAdmin.Visible = False

        'Przypisz Wartości z datagridview
        PokazArkusz.TXTNumerMagazynowy.Text = datagridview1.Rows(Index).Cells(0).Value
        PokazArkusz.TxtMaterial.Text = datagridview1.Rows(Index).Cells(1).Value
        PokazArkusz.TxtGrubosc.Text = datagridview1.Rows(Index).Cells(2).Value
        PokazArkusz.TxtIloscDostepna.Text = datagridview1.Rows(Index).Cells(3).Value
        PokazArkusz.TxtIloscRezerwacja.Text = datagridview1.Rows(Index).Cells(4).Value
        PokazArkusz.TxtIloscZuzyta.Text = datagridview1.Rows(Index).Cells(5).Value
        PokazArkusz.TxtX.Text = datagridview1.Rows(Index).Cells(6).Value
        PokazArkusz.TxtY.Text = datagridview1.Rows(Index).Cells(7).Value
        PokazArkusz.TxtPriorytet.Text = datagridview1.Rows(Index).Cells(8).Value
        PokazArkusz.TxtJednostki.Text = datagridview1.Rows(Index).Cells(9).Value
        '10
        PokazArkusz.TxtPoleUzytkownika.Text = datagridview1.Rows(Index).Cells(11).Value

        Try
            If datagridview1.Rows(Index).Cells(12).Value Is DBNull.Value Then
                PokazArkusz.TxtPole_uzytkownika2.Text = ""
            Else
                PokazArkusz.TxtPole_uzytkownika2.Text = CStr(datagridview1.Rows(Index).Cells(12).Value)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        PokazArkusz.TxtKlient.Text = datagridview1.Rows(Index).Cells(13).Value
        PokazArkusz.TxtWytop.Text = datagridview1.Rows(Index).Cells(14).Value
        PokazArkusz.TxtAtest.Text = datagridview1.Rows(Index).Cells(15).Value
        PokazArkusz.TxtDataPrzyjecia.Text = CStr(datagridview1.Rows(Index).Cells(16).Value)
        PokazArkusz.TxtWz.Text = datagridview1.Rows(Index).Cells(17).Value
        PokazArkusz.TxtPowierzony.Text = datagridview1.Rows(Index).Cells(18).Value
        PokazArkusz.TxtLokalizacja.Text = datagridview1.Rows(Index).Cells(19).Value

        PokazArkusz.Text = "Edycja Arkusza"                                                  'Napis na belce w oknie 

    End Sub
    Private Sub BtnEdycjaPM_Click(sender As Object, e As EventArgs) Handles BtnEdycjaPM.Click

        'Jeżeli użytkownik ma najwyższe uprawnienia to wyświetl okno do Edycji Arkusza

        If Uzytkownik.Uprawnienia = 1 Then
            Dim ilosc As Integer = 0
            For i As Integer = 0 To DataGridView1.Rows.Count - 2
                If DataGridView1.Rows(i).Selected Then
                    ilosc = ilosc + 1
                End If
            Next

            If ilosc > 0 Then
                For i As Integer = 0 To DataGridView1.Rows.Count - 2
                    If DataGridView1.Rows(i).Selected Then
                        WyswietlDaneArkuszaWOknieDoEdycji(DataGridView1, i)
                    End If
                Next
            Else
                MsgBox("Zaznacz poprawnie cały rząd")
            End If

        Else

            'Jeżeli nie ma uprawnień to nie wyświetli okna, tylko pokaże komunikat

            MsgBox("Nie masz wystarczających uprawnień by korzystać z tej funkcji")
        End If
    End Sub

    Private Sub Zamkniecie_Click(sender As Object, e As EventArgs) Handles Me.Closed

        'Po zamknięciu okna Monitor, zamknij również okno logowanie
        Logowanie.Close()

        'Lub wyświetl je ponownie 
        'Logowanie.Visible = True

    End Sub



    ' Private Sub CBKolorTla_SelectedIndexChanged(sender As Object, e As EventArgs)
    'Zmiana koloru tła w zależności od wybranej pozycji w comboboxie

    'Dim kolor As Integer = CBKolorTla.SelectedIndex
    'Select Case kolor
    'Case 0
    'Me.BackColor = Color.LimeGreen
    'Case 1
    'Me.BackColor = Color.Gray
    'Case Else
    'Me.BackColor = Color.Gray
    'End Select

    ' End Sub

    Private Sub BtnRaport_Click(sender As Object, e As EventArgs) Handles BtnRaport.Click

        'Sprawdź ile jest zaznaczonych rzędów
        Dim ilosc As Integer = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 2
            If DataGridView1.Rows(i).Selected Then
                ilosc = ilosc + 1
            End If
        Next

        'Jeżeli jest chociaż jeden zaznaczony to pokaż nowe okno do raportu
        If ilosc > 0 Then
            Dim raport As New Raport
            raport.Show()
            Dim nazwa As String = ""

            'Przeskanuj wszystkie rzędy z data gridview
            'Te, które są zaznaczone dodaj do wykresu
            For i As Integer = 0 To DataGridView1.Rows.Count - 2
                If DataGridView1.Rows(i).Selected Then
                    nazwa = DataGridView1.Rows(i).Cells(0).Value & " " & DataGridView1.Rows(i).Cells(1).Value & " " & DataGridView1.Rows(i).Cells(2).Value
                    raport.Chart1.Series("Ilosci Dostepne").Points.AddXY(nazwa, CInt(DataGridView1.Rows(i).Cells(3).Value))
                    raport.Chart1.Series("Ilosci Zarezerwowane").Points.AddXY(nazwa, CInt(DataGridView1.Rows(i).Cells(4).Value))
                    raport.Chart1.Series("Ilosci Zużyte").Points.AddXY(nazwa, CInt(DataGridView1.Rows(i).Cells(5).Value))
                End If
            Next
        Else
            'Jeżeli nie zaznaczono ani jednego rzędu wyświetl komunikat
            MsgBox("Zaznacz poprawnie przynajmniej jeden rząd.")
        End If

    End Sub

    Private Sub BtnNiskieStany_Click(sender As Object, e As EventArgs) Handles BtnNiskieStany.Click

        'Przeskanuj wszystkie rzędy.
        'Jeżeli, w którymś wartość IlościDostępnych będzie mniejsza niż 10 to podświetl na czerwono

        For i As Integer = 0 To DataGridView1.Rows.Count - 2

            If CInt(DataGridView1.Rows(i).Cells(3).Value) < 10 Then
                DataGridView1.Rows(i).Cells(3).Style.BackColor = Color.Red
            End If

        Next

    End Sub

    Public Function PobierzSciezkeProjektu() As String
        'Pobierz nazwe projektu do odczytu

        'Definicje
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()
        Dim SciezkaProjektu As String = ""

        'Ustawienia open file dialog (ofd)
        'openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "rpd files (*.rpd)|*.rpd|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        'Odczytaj nazwe pliku projektu z ofd
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = openFileDialog1.OpenFile()
                If (myStream IsNot Nothing) Then
                    SciezkaProjektu = openFileDialog1.FileName
                End If
            Catch Ex As Exception
                MessageBox.Show("Nie można odczytać pliku z dysku. Error: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If

        Return SciezkaProjektu
    End Function

    Public Sub OdczytajNestingiZProjektu(ByVal SciezkaProjektu As String)

        'Odczytaj nestingi i czesci z projektu

        Dim xmldoc As New XmlDataDocument()                                                      'Dokument XML
        Dim xmlnode As XmlNodeList                                                               'Znacznik XML
        Dim xmlnodePart As XmlNodeList

        Dim PlikProjektu As New FileStream(SciezkaProjektu, FileMode.Open, FileAccess.Read)      'Dostęp do pliku projektu
        xmldoc.Load(PlikProjektu)                                                                'Załaduj plik projektu
        xmlnode = xmldoc.GetElementsByTagName("Nest")                                            'Szukaj znaczników
        xmlnodePart = xmldoc.GetElementsByTagName("Part")

        ListaNestingow.Clear()                                                                   'Wyzerowanie listy inaczej błędy
        ListaPartow.Clear()

        Dim ilosc As Integer
        Dim OdpadZrodlowy As String = ""                                                         'Póki co nieużywane

        Dim IloscZnacznikow As Integer = 0

        'Pętla odczytania danych z pliku XML do klasy Part
        For i As Integer = 0 To xmlnodePart.Count - 1
            ilosc += 1
            IloscZnacznikow = xmlnodePart(i).ChildNodes.Count
            If IloscZnacznikow = 22 Then

                Try
                    ListaPartow.Add(New Part() With {
                    .ID = xmlnodePart(i).ChildNodes.Item(0).InnerText.Trim(),
                    .Nazwa = xmlnodePart(i).ChildNodes.Item(1).InnerText.Trim(),
                    .Company = xmlnodePart(i).ChildNodes.Item(19).ChildNodes.Item(0).InnerText.Trim(),
                    .CustomerReference = xmlnodePart(i).ChildNodes.Item(19).ChildNodes.Item(1).InnerText.Trim(),
                    .OrderDueDate = xmlnodePart(i).ChildNodes.Item(19).ChildNodes.Item(2).InnerText.Trim(),
                    .OrderNumber = xmlnodePart(i).ChildNodes.Item(19).ChildNodes.Item(3).InnerText.Trim(),
                    .WorkOrderLineId = xmlnodePart(i).ChildNodes.Item(19).ChildNodes.Item(4).InnerText.Trim()
                               })

                Catch ex As Exception
                    DoFlowLogaDoPliku("Ilości znaczników:" & vbNewLine & ex.Message)
                End Try
            Else

                ListaPartow.Add(New Part() With {
                    .ID = xmlnodePart(i).ChildNodes.Item(0).InnerText.Trim(),
                    .Nazwa = xmlnodePart(i).ChildNodes.Item(1).InnerText.Trim(),
                    .Company = "",
                    .CustomerReference = "",
                    .OrderDueDate = "",
                    .OrderNumber = "",
                    .WorkOrderLineId = ""
                               })

            End If

        Next

        'Rozdziel label od value w odczytanym infopacket 
        Try
            For Each part As Part In ListaPartow
                If part.Company <> "" Then
                    '7 bo COMPANY ma 7 liter
                    part.Company = part.Company.Substring(7, part.Company.Length - 7)
                ElseIf part.CustomerReference <> "" Then
                    '18 bo Customer Reference ma 18 liter (ze spacją) 
                    part.CustomerReference = part.CustomerReference.Substring(18, part.CustomerReference.Length - 18)
                ElseIf part.OrderDueDate <> "" Then
                    'itd
                    part.OrderDueDate = part.OrderDueDate.Substring(14, part.OrderDueDate.Length - 14)

                ElseIf part.OrderNumber <> "" Then
                    part.OrderNumber = part.OrderNumber.Substring(12, part.OrderNumber.Length - 12)
                ElseIf part.WorkOrderLineId <> "" Then
                    part.WorkOrderLineId = part.WorkOrderLineId.Substring(15, part.WorkOrderLineId.Length - 15)
                End If
            Next

            DoFlowLogaDoPliku("Rozdzielono label od value")

        Catch ex As Exception
            DoFlowLogaDoPliku("Błąd konwersji stringów: " & vbNewLine & ex.Message)
            MsgBox("Błąd konwersji stringów")
        End Try

        'Odczytaj w jakich nestingach i w jakiej ilości są części
        xmlnodePart = xmldoc.GetElementsByTagName("Part")
        '1 Pętla po częściach z listyPartów
        For Each part As Part In ListaPartow
            '2 Pętla po znaczniku <PART> z projektu
            For i As Integer = 0 To xmlnodePart.Count - 1
                xmlnodePart(i).ChildNodes.Item(0).InnerText.Trim() '??

                'IloscZnacznikow jest różna dla zwykłych projektów i tych z Radmanagera. Więc trzeba odczytać ich ilość i pomniejszyc o 1
                IloscZnacznikow = xmlnodePart(i).ChildNodes.Count

                If part.ID = xmlnodePart(i).ChildNodes.Item(0).InnerText.Trim() Then
                    '3 Pętla po znacznikach UsedInNest, który się mieści w znaczniku <PART>
                    For e As Integer = 0 To xmlnodePart(i).ChildNodes.Item(IloscZnacznikow - 1).ChildNodes.Count - 1
                        Try
                            part.ListaUsedInNest.Add(New Part.UsedInNest With
                                {.ID = xmlnodePart(i).ChildNodes.Item(IloscZnacznikow - 1).ChildNodes.Item(e).ChildNodes.Item(0).InnerText.Trim(),
                            .Made = xmlnodePart(i).ChildNodes.Item(IloscZnacznikow - 1).ChildNodes.Item(e).ChildNodes.Item(1).InnerText.Trim()})
                        Catch ex As Exception
                            DoFlowLogaDoPliku("3 pętla po znacznikach: " & vbNewLine & ex.Message)
                        End Try
                    Next
                End If
            Next
        Next

        'Pętla odczytania danych z pliku XML do klasy Nest
        For i As Integer = 0 To xmlnode.Count - 1
            ilosc += 1


            Try

                Dim NumMag As Integer
                If xmlnode(i).ChildNodes.Item(2).ChildNodes.Item(7).InnerText.Trim() = "" Then
                    NumMag = 0
                Else
                    NumMag = xmlnode(i).ChildNodes.Item(2).ChildNodes.Item(7).InnerText.Trim()
                End If
                ' NumMag = CInt(xmlnode(i).ChildNodes.Item(2).ChildNodes.Item(7).InnerText.Trim())
                ' MsgBox(NumMag)

                ListaNestingow.Add(New Nesting() With {
                .NazwaPliku = xmlnode(i).ChildNodes.Item(0).InnerText.Trim(),
                .Id = CInt(xmlnode(i).ChildNodes.Item(1).InnerText.Trim()),
                .ilosc = CInt(xmlnode(i).ChildNodes.Item(2).ChildNodes.Item(0).InnerText.Trim()),
                .Material = xmlnode(i).ChildNodes.Item(2).ChildNodes.Item(1).InnerText.Trim(),
                .Grubosc = xmlnode(i).ChildNodes.Item(2).ChildNodes.Item(2).InnerText.Trim(),
                .NumerMagazynowy = NumMag,
                .Data = xmlnode(i).ChildNodes.Item(3).InnerText.Trim()
                           })
            Catch ex As Exception
                DoFlowLogaDoPliku("Pętla odczytania danych z pliku XML do klasy Nest:" & vbNewLine & ex.Message)

            End Try
        Next


        'Odczytaj informacje na temat części w poszczególnych nestingach 
        For Each Nest As Nesting In ListaNestingow
            For i As Integer = 0 To xmlnode.Count - 1
                xmlnode(i).ChildNodes.Item(0).InnerText.Trim()
                Try
                    If Nest.NazwaPliku = xmlnode(i).ChildNodes.Item(0).InnerText.Trim() Then

                        For j As Integer = 0 To xmlnode(i).ChildNodes.Count - 1
                            Nest.ListaDetali.Add(New Detal() With {
                               .Plik = (xmlnode(i).ChildNodes.Item(4).ChildNodes.Item(j).ChildNodes.Item(0).InnerText.Trim()),
                               .IloscNaNestingu = (xmlnode(i).ChildNodes.Item(4).ChildNodes.Item(j).ChildNodes.Item(1).InnerText.Trim())
                               })
                        Next
                    Else
                    End If

                Catch ex As Exception
                    DoFlowLogaDoPliku("Błąd przy pobieraniu części z nestingu: " & ex.Message)
                End Try
            Next
        Next
    End Sub

    Private Sub BtnOdczytajPlikProjektu_Click(sender As Object, e As EventArgs) Handles BtnOdczytajPlikProjektuDoTrackera.Click

        Dim SciezkaProjektu As String = PobierzSciezkeProjektu()                    'Pobierz nazwe projektu do odczytu

        If SciezkaProjektu = "" Then                                                'Jeżeli jest pusta to wyświetl ostrzeżenie
            MsgBox("Nie wybrano pliku projektu .rpd")
            Exit Sub
        End If

        'Potrzebne sprawdzenie czy już jest wczytany taki projekt 

        OdczytajNestingiZProjektu(SciezkaProjektu)                                  'Odczytaj dane z projektu

        'Wpisz do bazy danych zebrane informacje
        Dim zapytanie As String = ""

        '1 Pętla po Nestingach
        For Each Nest As Nesting In ListaNestingow

            'Odczytaj z bazy danych Wytop i Atest
            Nest.OdczytajWytopIAtest()

            '2 Pętla po Częściach
            For Each part As Part In ListaPartow

                '3 Pętla po ID i ilości użytych części w nestingach 
                For Each Used As Part.UsedInNest In part.ListaUsedInNest
                    If CInt(Used.ID) = Nest.Id Then
                        zapytanie = "Insert into Tracker (NestID, Material, Grubosc, NumerMagazynowy, Detal, Ilosc, NazwaProjektu,
                                    Wytop, Atest, Klient, NumerZlecenia, Termin, Data, NazwaNestingu, IloscNestingow, IloCzesNaNest) 
                            Values (" & Nest.Id & ", '" & Nest.Material & "'," & Nest.Grubosc & "," & Nest.NumerMagazynowy &
                           ", '" & part.Nazwa & "', " & Used.Made & ",'" & SciezkaProjektu & "','" & Nest.Wytop & "','" & Nest.Atest &
                           "','" & part.Company & "','" & part.OrderNumber & "','" & part.OrderDueDate & "','" & Nest.Data &
                           "','" & Nest.NazwaPliku & "','" & Nest.ilosc & "','" & CStr(CInt(Used.Made) / Nest.ilosc) & "')"
                        DoFlowLogaDoPliku(zapytanie)
                        Wyslij_Zapytanie_SQL_Do_Bazy(zapytanie)
                    Else
                        ' MsgBox("Warunek nie spełniony")
                    End If
                Next
            Next
        Next

        MsgBox("Wczytano plik projektu: " & SciezkaProjektu) ' Potrzebne sprawdzenie

        zapytanie = "Select * from Tracker"                                             'Pokaż odświeżoną tabelę
        Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, DataGridView1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnWyczyscTrackera.Click

        Dim zapytanie As String
        zapytanie = "delete from Tracker"                                           'Wyczyść Tabele Tracker (do testów)
        Wyslij_Zapytanie_SQL_Do_Bazy(zapytanie)
        MsgBox("Wyczyszczono tabele Tracker")

        zapytanie = "Select * From Tracker"                                         'Pokaż Odświeżoną Tabele
        Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, DataGridView1)
    End Sub

    Private Sub BtnInfoOWersji_Click(sender As Object, e As EventArgs) Handles BtnInfoOWersji.Click
        Dim info As New Informacje
        info.Show()

    End Sub
End Class
