Public Class Alert

    Public Property Id As Long
    Public Property OrganisationId As Long
    Public Overridable Property Organisation As Organisation
    Public Property SinistreId As Long
    Public Overridable Property Sinistre As Sinistre
    Public Property Contenu As String

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser



End Class
