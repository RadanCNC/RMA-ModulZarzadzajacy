Public Class Logowanie
    Private Sub BtnZaloguj_Click(sender As Object, e As EventArgs) Handles BtnZaloguj.Click

        'Przypisz Login i Hasło do użytkownika
        Uzytkownik.Login = TxtLogin.Text
        Uzytkownik.Haslo = TxtHaslo.Text

        'Nadaj mu domyślnie najniższe uprawnienia
        Uzytkownik.Uprawnienia = 4

        'Jeżeli logowanie się powiedzie to otwórz Monitor
        If Uzytkownik.Logowanie() = True Then

            LoginSql = Uzytkownik.Login
            Dim modul As New Monitor
            modul.Show()
            Visible = False
        Else
            'Jeżeli nie to wyświetl komunikat
            MsgBox("Nieprawdiłowy login lub hasło. Upewnij się, że masz odpowiednie uprawnienia.")
        End If
    End Sub

    Private Sub Logowanie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Nie pokazuj pomocniczego datagridview1
        DataGridView1.Visible = False
    End Sub

    Private Sub BtnAnuluj_Click(sender As Object, e As EventArgs) Handles BtnAnuluj.Click
        'Wyłącz program
        Me.Dispose()
    End Sub

End Class