
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Infrastructure

    Public Property Id As Long
    Public Property OganisationId As Long
    Public Property CommuneId As Long?

    Public Property Nom As String
    Public Property Code As String
    Public Property CodePostale As String
    Public Property Telephone As String
    Public Property Telephone2 As String
    Public Property Email As String
    Public Property Location As DbGeometry


    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Commune As Commune
    Public Overridable Property Oganisation As Organisation

End Class
