
Partial Public Class Sinistrer
    Public Sub New()
        Demande = New HashSet(Of Demande)()
        MaladieSinistre = New HashSet(Of MaladieSinistre)()
    End Sub

    Public Property Id As Long
    Public Property Cni As String
    Public Property Nom As String
    Public Property Prenom As String
    Public Property Telephone As String
    Public Property Email As String
    Public Property DateDeNaissance As Date
    Public Property Sexe As String
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Demande As ICollection(Of Demande)
    Public Overridable Property MaladieSinistre As ICollection(Of MaladieSinistre)
End Class
