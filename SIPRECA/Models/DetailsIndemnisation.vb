Public Class DetailsIndemnisation
    Public Property Id As Long
    Public Property IndemnisationId As Long
    Public Overridable Property Indemnisation As Indemnisation
    Public Property NatureAideId As Long
    Public Overridable Property NatureAide As NatureAide
    Public Property Quantite As Double
    Public Property Description As String
    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

End Class
