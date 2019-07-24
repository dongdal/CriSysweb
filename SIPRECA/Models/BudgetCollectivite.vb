
Partial Public Class BudgetCollectivite
    Public Property Id As Long
    Public Property AnneeBudgetaireId As Long
    Public Property CollectiviteId As Long

    Public Property Montant As Double
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1


    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property AnneeBudgetaire As AnneeBudgetaire
    Public Overridable Property Collectivite As Collectivite
End Class
