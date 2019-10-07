
Partial Public Class Solution

    Public Property Id As Long
    Public Property TypeSolutionId As Long
    Public Property EvenementZoneId As Long
    Public Property Libelle As String
    Public Property Description As String
    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property TypeMoyen As TypeSolution
    Public Overridable Property EvenementZone As EvenementZone
End Class
