
Imports System.ComponentModel.DataAnnotations.Schema

Partial Public Class Heliport

    Public Property Id As Long
    Public Property OganisationId As Long
    Public Property AdresseId As Long

    Public Property Nom As String
    Public Property Code As String
    Public Property Telephone As String
    Public Property Telephone2 As String
    Public Property SiteWeb As String
    Public Property Email As String

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Adresse As Adresse
    Public Overridable Property Oganisation As Organisation
End Class
