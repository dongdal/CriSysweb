Partial Public Class ChampsSection

    Public Property Id As Long

    Public Property ChampsId As Long
    Public Property SectionId As Long

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Champs As Champs
    Public Overridable Property Section As Section
    Public Overridable Property ValeurChamps As ValeurChamps
End Class
