Imports System.IO

Module Globals1

    Public Connect As New Ustawienia



    'Połączenie z bazą danych
    Public sql As New SqlCon

    'Nazwy kolumn w datagridview1 w ImportBlach
    Public Kolumny As New List(Of String)


    'Sciezka do projektu
    Public SciezkaProjektu As String

    'Nazwa użytkownika Radan
    Public nazwaUzytkownika As String

    'Ścieżka do pliku log
    Public SciezkaDoPlikuLog As String
    Public LoginSql As String
    Public Uprawnienia As Integer = 0

    Public Uzytkownik As New Users

    'DoFlowLoga
    Public Sub DoFlowLogaDoPliku(ByVal tekst As String)
        Using sw As StreamWriter = File.AppendText(SciezkaDoPlikuLog)
            'Wpisz datę, nazwe użytkownika oraz wpis
            sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") & " " &
                         nazwaUzytkownika & " " & tekst)
        End Using
    End Sub

    'Funkcja wyświetla wynik zapytania w podanym przez nas datagridview
    Public Sub Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(ByVal Zapytanie As String, ByRef DataGRid As Windows.Forms.DataGridView)
        Try
            sql.ExecQuery(Zapytanie)

            'Jeżeli napotka problem to pojawi się komunikat z błędem, jeżeli nie to przypisz dane do datagridview
            If sql.HasException(True) Then Exit Sub
            DataGRid.DataSource = sql.DBDT

        Catch ex As Exception
            MsgBox("Wystąpił błąd podczas wysyłania zapytania SQL do bazy danych: " & Zapytanie)
        End Try

    End Sub

    'Realizacja samego zapytania z obsługą błędów
    Public Sub Wyslij_Zapytanie_SQL_Do_Bazy(ByVal Zapytanie As String)
        Try
            sql.ExecQuery(Zapytanie)
            'Jeżeli napotka problem to pojawi się komunikat z błędem 
            If sql.HasException(True) Then
                DoFlowLogaDoPliku("Wystąpił błąd podczas wysyłania zapytania SQL do bazy danych: " & Zapytanie)
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox("Wystąpił błąd podczas wysyłania zapytania SQL do bazy danych: " & Zapytanie)
        End Try

    End Sub

    Public Function Wyslij_Zapytanie_SQL_Do_Bazy_Zwroc_info(ByVal Zapytanie As String) As Boolean
        Try
            sql.ExecQuery(Zapytanie)
            'Jeżeli napotka problem to pojawi się komunikat z błędem 
            If sql.HasExceptionBezKomunikatu(True) Then
                DoFlowLogaDoPliku("Wystąpił błąd podczas wysyłania zapytania SQL do bazy danych: " & Zapytanie)
                Return False
            End If

        Catch ex As Exception
            MsgBox("Wystąpił błąd podczas wysyłania zapytania SQL do bazy danych: " & Zapytanie)
        End Try

        Return True
    End Function

    Public Function Wyslij_Zapytanie_SQL_Do_Bazy_F(ByVal Zapytanie As String) As Boolean
        Try
            sql.ExecQuery(Zapytanie)
            'Jeżeli napotka problem to pojawi się komunikat z błędem 
            If sql.HasException(True) Then Return False

        Catch ex As Exception
            MsgBox("Wystąpił błąd podczas wysyłania zapytania SQL do bazy danych: " & Zapytanie)
            Return False
        End Try
        Return True
    End Function

    Public Function Sprawdz_Pierwsza_Cyfre_Zwroc_Tabele(ByVal Liczba As String) As String
        'Sprawdź pierwszą cyfrę numeru magazynowego, jeżeli jedynka to zwróć tabele Arkusze
        'jeżeli 5 to tabele odpady

        Dim PierwszaCyfra As String
        Dim tabela As String

        PierwszaCyfra = Liczba
        PierwszaCyfra = PierwszaCyfra.Substring(0, 1)

        If PierwszaCyfra = "1" Then
            tabela = "Arkusze"

        ElseIf PierwszaCyfra = "5" Then
            tabela = "Odpady"
        Else ' Jeżeli jakakolwiek inna to wyświetl ostrzeżenie
            MsgBox("Napotkano nietypowy Numer Magazynowy pierwsza cyfra nie jest zgodna z 
                                Arkuszem (1) ani Odpadem (5)")
            tabela = "Arkusze"

        End If

        Return tabela
    End Function

End Module
