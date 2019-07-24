
Partial Public Class Champs
    Public Sub New()
        ChampsSection = New HashSet(Of ChampsSection)()
    End Sub

    Public Property Id As Long
    Public Property TypeChampsId As Long
    Public Property Titre As String
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property TypeChamps As TypeChamps

    Public Overridable Property ChampsSection As ICollection(Of ChampsSection)
End Class
