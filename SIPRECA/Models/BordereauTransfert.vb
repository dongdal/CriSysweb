Public Class BordereauTransfert
    Public Sub New()
        BordereauTransfertDemande = New HashSet(Of BordereauTransfertDemande)()
    End Sub

    Public Property Id As Long
    Public Property Libelle As String
    Public Property NumeroBordereau As String
    Public Property DateTransfert As Date = Now
    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property BordereauTransfertDemande As ICollection(Of BordereauTransfertDemande)

End Class
