Public Class Users
    Public Login As String
    Public Haslo As String
    Public Uprawnienia As Integer

    Public Function Logowanie() As Boolean
        Dim zapytanie As String
        zapytanie = "Select COUNT(Login) FROM Users WHERE " &
        "Login = " & "'" & Login & "' " &
        "And Haslo = " & "'" & Haslo & "'"

        Connect.wczytajUstawianieZPliku()

        ' Tymczasowe przyjecie magazynowe aby mieć dostęp do datagridview
        Dim przyjecie As New PrzyjęcieMagazynowe
        Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, przyjecie.DataGridView1)

        Dim wynikZapytania As String = ""
        Try
            wynikZapytania = (przyjecie.DataGridView1.Rows(0).Cells(0).Value)
        Catch ex As Exception
            DoFlowLogaDoPliku("Nie udało się odczytać wartości z datagridview: " & zapytanie)
        End Try

        If wynikZapytania = "1" Then

            zapytanie = "select uprawnienia from users where login = '" & Uzytkownik.Login & "'" &
                " and haslo = '" & Uzytkownik.Haslo & "'"
            Try

                Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, przyjecie.DataGridView1)
                Uprawnienia = przyjecie.DataGridView1.Rows(0).Cells(0).Value

            Catch ex As Exception
                DoFlowLogaDoPliku("Nie udało się odczytać wartości z datagridview: " & zapytanie)
            End Try

            Return True
        Else
            Return False

            End If
        przyjecie.Dispose()

    End Function

End Class
