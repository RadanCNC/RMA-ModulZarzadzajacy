

Module Globals
    'Połączenie z bazą danych
    Public sql As New SqlCon


    ' global object -Radraftapplication 
    Public myApp As Radraft.Interop.Application
    ' global object -macro 
    Public myMac As Radraft.Interop.Mac

    'Nazwy kolumn w datagridview1 w ImportBlach
    Public Kolumny As New List(Of String)

    'Sciezka do projektu
    Public SciezkaProjektu As String

    'Nazwa użytkownika Radan
    Public nazwaUzytkownika As String









End Module