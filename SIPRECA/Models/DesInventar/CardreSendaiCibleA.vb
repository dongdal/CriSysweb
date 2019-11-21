Imports System.Data.Entity.Spatial

Partial Public Class CardreSendaiCibleA

    Public Property Id As Long
    Public Property EvenementZoneId As Long
    Public Property NombreTotalDeces As Long?
    Public Property NombreDecesFemme As Long?
    Public Property NombreDecesHomme As Long?
    Public Property NombreDecesEnfant As Long?
    Public Property NombreDecesAdult As Long?
    Public Property NombreDecesVieux As Long?
    Public Property NombreDecesHandicape As Long?
    Public Property NombreDecesPauvre As Long?
    Public Property NombreTotalDisparue As Long?
    Public Property NombreDisparueFemme As Long?
    Public Property NombreDisparueHomme As Long?
    Public Property NombreDisparueEnfant As Long?
    Public Property NombreDisparueAdult As Long?
    Public Property NombreDisparueVieux As Long?
    Public Property NombreDisparueHandicape As Long?
    Public Property NombreDisparuePauvre As Long?
    Public Property Source As String

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property EvenementZone As EvenementZone
End Class
