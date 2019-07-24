
Imports System.Data.Entity.Spatial

Partial Public Class Moyen

    Public Property Id As Long
    Public Property TypeMoyenId As Long
    Public Property OganisationId As Long
    Public Property Nom As String
    Public Property Description As String
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1
    Public Property Location As DbGeography

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser



    Public Overridable Property Oganisation As Organisation
    Public Overridable Property TypeMoyen As TypeMoyen
End Class
