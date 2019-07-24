
Partial Public Class Installation

    Public Property Id As Long
    Public Property OganisationId As Long
    Public Property AdresseId As Long
    Public Property Libelle As String
    Public Property CodePostale As String
    Public Property Telephone As String
    Public Property HeureDOuverture As String
    Public Property HeureFermeture As String
    Public Property Email As String
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Adresse As Adresse
    Public Overridable Property Oganisation As Organisation
End Class
