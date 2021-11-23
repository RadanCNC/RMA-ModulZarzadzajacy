
'Biblioteka z funkcjami SQL
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class ImportBlach

    Public Sub BtnWczytajDane_Click(sender As Object, e As EventArgs) Handles BtnWczytajDane.Click
        'Wykonaj zapytanie SQL w bazie danych
        sql.ExecQuery(RichTextBox1.Text)

        'Jeżeli pojawi się problem to zakończ, jeżeli nie to przypisz dane do datagridview
        If sql.HasException(True) Then Exit Sub
        DataGridView1.DataSource = sql.DBDT

        'Odczytaj nazwy kolumn z bazy danych i zapisz pod postacia listy String
        For index As Integer = 0 To DataGridView1.ColumnCount() - 1
            Kolumny.Add(DataGridView1.Columns(index).HeaderText)
        Next

        ' Wyswietl Kolumny
        ' For Each Kol As String In Kolumny
        ' MsgBox(Kol.ToString)
        ' Next

    End Sub
    Private Sub frm_Activated(sender As Object, e As EventArgs) Handles Me.Activated

        Me.TopMost = True
    End Sub

    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Funkcja która pokazuje lub blokuje kilka formantów w zależności czy check box admin jest kliknięte
        Ukryj_Pokaz_Przyciski()

        'Nawiąż połączenie z bazą danych z pól tekstowych
        'sql.SQLConect = New SqlConnection("Server=" & TxtSerwer.Text & "; Database=" & TxtBaza.Text &
        '  "; User=" & TxtLogin.Text & ";Pwd=" & TxtHaslo.Text)

        sql.ExecQuery(RichTextBox1.Text)

        'Jeżeli pojawi się problem to zakończ, jeżeli nie to przypisz dane do datagridview
        If sql.HasException(True) Then Exit Sub
        DataGridView1.DataSource = sql.DBDT
    End Sub

    Public Sub BtnWczytajDoRadana_Click(sender As Object, e As EventArgs) Handles BtnWczytajDoRadana.Click
        'Jeżeli nie jesteś adminem to od razu wczytaj do radana
        Try
            If CBAdmin.Checked = False Then
                'Wykonaj zapytanie SQL w bazie danych
                sql.ExecQuery(RichTextBox1.Text)

                'Jeżeli pojawi się problem to zakończ, jeżeli nie to przypisz dane do datagridview
                If sql.HasException(True) Then Exit Sub
                DataGridView1.DataSource = sql.DBDT

            End If

            'Definicja listy klasy Arkusz
            Dim ListaArkuszyImport As New List(Of Arkusz)()
            'Pętla, w której przypisujemy dane z datagridview do listy klasy Arkusz
            'Cells(1) to numer kolumny 2
            For row As Integer = 0 To DataGridView1.RowCount - 2

                ListaArkuszyImport.Add(New Arkusz() With {
                    .ID = DataGridView1.Rows(row).Cells(0).Value,
                    .material = DataGridView1.Rows(row).Cells(1).Value,
                    .grubosc = DataGridView1.Rows(row).Cells(2).Value,
                    .ilosc = DataGridView1.Rows(row).Cells(3).Value,
                    .x = DataGridView1.Rows(row).Cells(6).Value,
                    .y = DataGridView1.Rows(row).Cells(7).Value,
                    .Priorytet = DataGridView1.Rows(row).Cells(8).Value,
                    .Size_Units = DataGridView1.Rows(row).Cells(9).Value,
                    .Sheet_Thickness_Unit = DataGridView1.Rows(row).Cells(10).Value
                })
            Next


            'Dim result As List(Of Arkusz) = values.Distinct().ToList '
            'Ilość arkuszy równa się ilości rzędów z datagridview 
            Dim ileArkuszy As Int16 = DataGridView1.RowCount - 2
            'Zmienne do progress baru
            'Najpierw go zeruje
            ProgressBar1.Value = 0
            'Określam jego maksimum
            ProgressBar1.Maximum = ileArkuszy + 1
            'Info dla użytkownika
            LabelProgressBar.Text = "Proszę czekać"
            Dim procent As Double = 0

            For Each ArkuszImport As Arkusz In ListaArkuszyImport
                myMac.SetString("PRJ_SHEET_STOCK_ID", ArkuszImport.ID)
                myMac.SetString("PRJ_SHEET_MATERIAL", ArkuszImport.material)
                myMac.SetNumber("PRJ_SHEET_THICKNESS", ArkuszImport.grubosc)
                myMac.SetNumber("PRJ_SHEET_NUM_AVAILABLE", ArkuszImport.ilosc)
                myMac.SetNumber("PRJ_SHEET_X_SIZE", ArkuszImport.x)
                myMac.SetNumber("PRJ_SHEET_Y_SIZE", ArkuszImport.y)
                myMac.SetNumber("PRJ_SHEET_PRIORITY", ArkuszImport.Priorytet)
                myMac.SetString("PRJ_SHEET_SIZE_UNITS", ArkuszImport.Size_Units)
                myMac.SetString("PRJ_SHEET_THICK_UNITS", ArkuszImport.Sheet_Thickness_Unit)
                ' MsgBox(ArkuszImport.ID & " " & ArkuszImport.material & " " & ArkuszImport.grubosc & " " & ArkuszImport.ilosc & " " & ArkuszImport.x & " " & ArkuszImport.y & " " & ArkuszImport.Priorytet & " " & ArkuszImport.Sheet_Thickness_Unit & " " & ArkuszImport.Size_Units)
                myMac.prj_add_sheet()

                ProgressBar1.Value = ProgressBar1.Value + 1
                procent = (ProgressBar1.Value * 100) / ProgressBar1.Maximum

                LabelProgressBar.Text = "Ukończono w " & procent.ToString("F0") & "%"
                Me.Update()
            Next

        Catch ex As Exception
            MsgBox("Wystąpił błąd")
        End Try

    End Sub

    Public Sub DodajArkuszeDoRadana()



        'Pętla, w której przypisujemy wartości z każdego obiektu klasy do Radana
        'Definicja listy klasy Arkusz
        Dim ListaArkuszyImport As New List(Of Arkusz)()

        For Each ArkuszImport As Arkusz In ListaArkuszyImport
            myMac.SetString("PRJ_SHEET_STOCK_ID", ArkuszImport.ID)
            myMac.SetString("PRJ_SHEET_MATERIAL", ArkuszImport.material)
            myMac.SetNumber("PRJ_SHEET_THICKNESS", ArkuszImport.grubosc)
            myMac.SetNumber("PRJ_SHEET_NUM_AVAILABLE", ArkuszImport.ilosc)
            myMac.SetNumber("PRJ_SHEET_X_SIZE", ArkuszImport.x)
            myMac.SetNumber("PRJ_SHEET_Y_SIZE", ArkuszImport.y)
            myMac.SetNumber("PRJ_SHEET_PRIORITY", ArkuszImport.Priorytet)
            myMac.SetString("PRJ_SHEET_SIZE_UNITS", ArkuszImport.Size_Units)
            myMac.SetString("PRJ_SHEET_THICK_UNITS", ArkuszImport.Sheet_Thickness_Unit)
            ' MsgBox(ArkuszImport.ID & " " & ArkuszImport.material & " " & ArkuszImport.grubosc & " " & ArkuszImport.ilosc & " " & ArkuszImport.x & " " & ArkuszImport.y & " " & ArkuszImport.Priorytet & " " & ArkuszImport.Sheet_Thickness_Unit & " " & ArkuszImport.Size_Units)
            myMac.prj_add_sheet()

            ' ObslugaProgressBara(procent)

        Next
    End Sub
    Public Sub WyzerowanieProgressBara()

    End Sub
    Public Sub ObslugaProgressBara(ByVal procent)

        ProgressBar1.Value = ProgressBar1.Value + 1
        procent = (ProgressBar1.Value * 100) / ProgressBar1.Maximum

        LabelProgressBar.Text = "Ukończono w " & procent.ToString("F0") & "%"
    End Sub

    Private Sub CBAdmin_CheckedChanged(sender As Object, e As EventArgs) Handles CBAdmin.CheckedChanged
        Ukryj_Pokaz_Przyciski()
    End Sub

    Private Sub Ukryj_Pokaz_Przyciski()
        'Funkcja która pokazuje lub blokuje kilka formantów w zależności czy check box admin jest kliknięte
        RichTextBox1.Visible = CBAdmin.Checked
        '  DataGridView1.Visible = CBAdmin.Checked
        BtnWczytajDane.Visible = CBAdmin.Checked
        ' BtnWczytajWybrane.Visible = CBAdmin.Checked
    End Sub

    Private Sub BtnWczytajWybrane_Click(sender As Object, e As EventArgs) Handles BtnWczytajWybrane.Click

        'Jeżeli nie jesteś adminem to od razu wczytaj do radana
        Try
            '  If CBAdmin.Checked = False Then
            'Wykonaj zapytanie SQL w bazie danych
            '  sql.ExecQuery(RichTextBox1.Text)

            'Jeżeli pojawi się problem to zakończ, jeżeli nie to przypisz dane do datagridview
            'If sql.HasException(True) Then Exit Sub
            'DataGridView1.DataSource = sql.DBDT
            'Definicja listy klasy Arkusz
            Dim ListaArkuszyImport As New List(Of Arkusz)()

            '  End If

            'Definicja listy klasy Arkusz
            ' Dim ListaArkuszyImport As New List(Of Arkusz)()

            ' Ilość arkuszy równa się ilości rzędów z datagridview 
            Dim ileArkuszy As Integer = 0


            'Pętla, w której przypisujemy dane z datagridview do listy klasy Arkusz
            'Cells(1) to numer kolumny 2
            For row As Integer = 0 To DataGridView1.RowCount - 2
                If DataGridView1.Rows(row).Selected = True Then
                    ileArkuszy = ileArkuszy + 1
                    ListaArkuszyImport.Add(New Arkusz() With {
                   .ID = DataGridView1.Rows(row).Cells(0).Value,
                   .material = DataGridView1.Rows(row).Cells(1).Value,
                   .grubosc = DataGridView1.Rows(row).Cells(2).Value,
                   .ilosc = DataGridView1.Rows(row).Cells(3).Value,
                   .x = DataGridView1.Rows(row).Cells(6).Value,
                   .y = DataGridView1.Rows(row).Cells(7).Value,
                   .Priorytet = DataGridView1.Rows(row).Cells(8).Value,
                   .Size_Units = DataGridView1.Rows(row).Cells(9).Value,
                   .Sheet_Thickness_Unit = DataGridView1.Rows(row).Cells(10).Value
               })
                End If

            Next


            'Zmienne do progress baru
            'Najpierw go zeruje
            ProgressBar1.Value = 0
            'Określam jego maksimum
            ProgressBar1.Maximum = ileArkuszy
            'Info dla użytkownika
            LabelProgressBar.Text = "Proszę czekać"
            Dim procent As Double

            'Pętla, w której przypisujemy wartości z tablicy do Radana

            For Each ArkuszImport As Arkusz In ListaArkuszyImport
                myMac.SetString("PRJ_SHEET_STOCK_ID", ArkuszImport.ID)
                myMac.SetString("PRJ_SHEET_MATERIAL", ArkuszImport.material)
                myMac.SetNumber("PRJ_SHEET_THICKNESS", ArkuszImport.grubosc)
                myMac.SetNumber("PRJ_SHEET_NUM_AVAILABLE", ArkuszImport.ilosc)
                myMac.SetNumber("PRJ_SHEET_X_SIZE", ArkuszImport.x)
                myMac.SetNumber("PRJ_SHEET_Y_SIZE", ArkuszImport.y)
                myMac.SetNumber("PRJ_SHEET_PRIORITY", ArkuszImport.Priorytet)
                myMac.SetString("PRJ_SHEET_SIZE_UNITS", ArkuszImport.Size_Units)
                myMac.SetString("PRJ_SHEET_THICK_UNITS", ArkuszImport.Sheet_Thickness_Unit)

                'Obsługa Progress bara
                ProgressBar1.Value = ProgressBar1.Value + 1
                procent = (ProgressBar1.Value * 100) / ProgressBar1.Maximum

                LabelProgressBar.Text = "Ukończono w " & procent.ToString("F0") & "%"

                Me.Update()
                myMac.prj_add_sheet()
            Next
        Catch ex As Exception
            MsgBox("Najpierw wczytaj materiały z bazy danych")
        End Try


    End Sub


    Private Sub grdview_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        'Obsługa podwójnego kliknięcia na komórce
        For index As Integer = 0 To DataGridView1.Rows.Count - 1

            If e.RowIndex = index Then
                'Pokaz Arkusz w nowm oknie
                WyswietlDaneArkuszaWOknie(DataGridView1, index)

            End If
        Next

    End Sub

    Public Sub WyswietlDaneArkuszaWOknie(ByRef datagridview1 As DataGridView, ByVal Index As Integer)

        'Pokaz dane w formularzu przyjęcia magazynowego
        Dim PokazArkusz As New PrzyjęcieMagazynowe
        PokazArkusz.Show()

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
        PokazArkusz.TxtAtest.Text = datagridview1.Rows(Index).Cells(14).Value
        PokazArkusz.TxtWz.Text = datagridview1.Rows(Index).Cells(17).Value
        PokazArkusz.TxtPowierzony.Text = datagridview1.Rows(Index).Cells(18).Value
        PokazArkusz.TxtPoleUzytkownika.Text = datagridview1.Rows(Index).Cells(11).Value
        PokazArkusz.TxtDataPrzyjecia.Text = datagridview1.Rows(Index).Cells(16).Value

        'Włącz Textboxy
        PokazArkusz.TxtDataPrzyjecia.Enabled = True
        PokazArkusz.TXTNumerMagazynowy.Enabled = True

        'Wyłącz Przyciski

        PokazArkusz.BtnWpiszDoBazy.Visible = False
        PokazArkusz.CBAdmin.Visible = False

    End Sub

    Public Sub OdczytajNazwyKolumn()
        'Odczytaj nazwy kolumn z bazy danych i zapisz pod postacia listy String
        For index As Integer = 0 To DataGridView1.ColumnCount() - 1
            Kolumny.Add(DataGridView1.Columns(index).HeaderText)
        Next
    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    'Zamknięcie okna
    'Me.Close()

End Class
