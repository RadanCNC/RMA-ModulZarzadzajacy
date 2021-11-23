
Imports System.Windows.Forms

Public Class AnulowanieRezerwacjivb

    Private Sub BtnAnulujPrzyjęcieMagazynowe_Click(sender As Object, e As EventArgs) Handles BtnAnulujPrzyjęcieMagazynowe.Click
        'Zapytanie, które aktualizuje ilość arkuszy w tabeli Arkusze
        Try
            Dim zapytanie As String
            For i As Integer = 0 To DataGridView1.Rows.Count - 2
                If DataGridView1.Rows(i).Selected Then

                    zapytanie = "Update Arkusze SET IloscDostepne = IloscDostepne - " &
                    CStr(DataGridView1.Rows(i).Cells(4).Value) &
                     " WHERE[Numer Magazynowy] = " & DataGridView1.Rows(i).Cells(3).Value
                    sql.ExecQuery(zapytanie)

                    zapytanie = "Delete from LOG2 where [IDArkusza]  = " & DataGridView1.Rows(i).Cells(3).Value
                    sql.ExecQuery(zapytanie)



                End If

            Next

            'Zapytanie odświeżające widok datagridview
            zapytanie = "Select * from Log2 where Akcja = 'PrzyjecieMagazynowe'"
            sql.ExecQuery(zapytanie)
            If sql.HasException(True) Then Exit Sub
            DataGridView1.DataSource = sql.DBDT




            MsgBox("Anulowano Wybrane Przyjęcia Magazynowe")

        Catch ex As Exception
            MsgBox("Wystąpił jakiś błąd")
        End Try


    End Sub

    Private Sub AnulowanieRezerwacjivb_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Przy pierwszy uruchomieniu okna wyświetl wszystkie rezerwacje
        Try
            sql.ExecQuery("Select * from LOG2 where Akcja = 'Rezerwacja'")

            'Jeżeli pojawi się problem to zakończ, jeżeli nie to przypisz dane do datagridview
            If sql.HasException(True) Then Exit Sub
            DataGridView1.DataSource = sql.DBDT

        Catch ex As Exception
            MsgBox("Błąd podczas łączenia z bazą danych")
        End Try
    End Sub

    Private Sub frm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'Okno zawsze na wierzchu
        Me.TopMost = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnAnulujRezerwacje.Click
        Try
            myMac.prj_save()
            Dim zapytanie As String
            For i As Integer = 0 To DataGridView1.Rows.Count - 2
                If DataGridView1.Rows(i).Selected Then

                    zapytanie = "Update Arkusze SET IloscDostepne = IloscDostepne + " &
                    CStr(DataGridView1.Rows(i).Cells(5).Value) & ", IloscRezerwacja = IloscRezerwacja -  " &
                    CStr(DataGridView1.Rows(i).Cells(5).Value) &
                    " WHERE[Numer Magazynowy] = " & DataGridView1.Rows(i).Cells(3).Value
                    sql.ExecQuery(zapytanie)

                    zapytanie = "Delete from LOG2 where [IDArkusza]  = " & DataGridView1.Rows(i).Cells(3).Value
                    sql.ExecQuery(zapytanie)


                End If

            Next
            zapytanie = "Select * from Log2 where Akcja = 'Rezerwacja'"
            sql.ExecQuery(zapytanie)
            If sql.HasException(True) Then Exit Sub
            DataGridView1.DataSource = sql.DBDT

            MsgBox("Anulowano Wybrane Rezerwacje")

        Catch ex As Exception
            MsgBox("Wystąpił błąd przy anulowaniu rekordów z bazy danych")
            MsgBox(ex)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 1 Then
            BtnAnulujPrzyjęcieMagazynowe.Visible = True
            Dim zapytanie As String
            zapytanie = "Select * from Log2 where Akcja = 'PrzyjecieMagazynowe'"
            sql.ExecQuery(zapytanie)
            If sql.HasException(True) Then Exit Sub
            DataGridView1.DataSource = sql.DBDT
        Else
            BtnAnulujPrzyjęcieMagazynowe.Visible = False
        End If

        If ComboBox1.SelectedIndex = 0 Then
            BtnAnulujRezerwacje.Visible = True
            Dim zapytanie As String
            zapytanie = "Select * from Log2 where Akcja = 'Rezerwacja'"
            sql.ExecQuery(zapytanie)
            If sql.HasException(True) Then Exit Sub
            DataGridView1.DataSource = sql.DBDT
        Else
            BtnAnulujRezerwacje.Visible = False

        End If
    End Sub


End Class