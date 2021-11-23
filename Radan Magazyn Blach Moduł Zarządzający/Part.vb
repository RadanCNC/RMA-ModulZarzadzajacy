Public Class Part
    Public Nazwa As String
    Public ID As Integer
    Public Company As String = ""
    Public CustomerReference As String = ""
    Public OrderDueDate As String = ""
    Public OrderNumber As String = ""
    Public WorkOrderLineId As String = ""

    Public Structure UsedInNest
        Dim ID As String
        Dim Made As String
    End Structure

    Public ListaUsedInNest As New List(Of UsedInNest)


    Public UsedInNest1 As Integer ' to i 
    Public Used As Integer 'to trzeba zamienić na liste albo tablice albo strukture

End Class
