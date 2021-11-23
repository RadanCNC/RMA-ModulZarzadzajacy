Public Class Informacje
    Private Sub Informacje_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    ' linia kodu odpowiadajaca za okno makra zawsze na wierzchu
    Private Sub frm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.TopMost = True
    End Sub
End Class