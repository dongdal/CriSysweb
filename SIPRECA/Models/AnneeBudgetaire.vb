
Partial Public Class AnneeBudgetaire
    Public Sub New()
        BudgetCollectivite = New HashSet(Of BudgetCollectivite)()
        CollectiviteSinistree = New HashSet(Of CollectiviteSinistree)()
    End Sub


    Public Property Id As Long

    Public Property Libelle As String
    Public Property DateDebut As Date
    Public Property DateFin As Date
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property BudgetCollectivite As ICollection(Of BudgetCollectivite)
    Public Overridable Property CollectiviteSinistree As ICollection(Of CollectiviteSinistree)
End Class
