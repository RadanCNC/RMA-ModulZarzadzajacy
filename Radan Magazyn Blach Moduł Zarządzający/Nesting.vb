Public Class Nesting
    Public NazwaPliku As String
    Public Id As Integer
    Public ilosc As Integer
    Public Material As String
    Public Grubosc As String
    Public X As Double
    Public Y As Double
    Public OdpadZrodlowy As String = ""
    Public NumerMagazynowy As Integer
    Public Wytop As String
    Public Atest As String
    Public Data As String

    Public ListaDetali As New List(Of Detal)

    Public Sub OdczytajWytopIAtest()
        Dim zapytanie As String

        'Tymczasowe okno z datagridview
        Dim przyjecie As New PrzyjęcieMagazynowe

        'Odczytaj Wytop
        zapytanie = "Select Wytop from Arkusze Where [Numer Magazynowy] = " & NumerMagazynowy
        Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, przyjecie.DataGridView1)
        Wytop = przyjecie.DataGridView1.Rows(0).Cells(0).Value

        'Odczytaj Atest
        zapytanie = "Select Atest from Arkusze Where [Numer Magazynowy] = " & NumerMagazynowy
        Wyslij_Zapytanie_SQL_Wynik_w_DataGrid(zapytanie, przyjecie.DataGridView1)
        Atest = przyjecie.DataGridView1.Rows(0).Cells(0).Value

        'Zamykam tymczasowe datagridview
        przyjecie.Dispose()

    End Sub

    Public Function WpiszDoBazy() As String 'Nie aktualne
        Dim zapytanie As String = ""
        zapytanie = "Insert into Tracker (NestID, Material) Values (" & Id & ", '" & NazwaPliku & "')"
        Return zapytanie
    End Function
End Class
