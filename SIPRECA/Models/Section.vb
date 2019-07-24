
Partial Public Class Section
    Public Sub New()
        ChampsSection = New HashSet(Of ChampsSection)()
    End Sub

    Public Property Id As Long
    Public Property FormulaireId As Long
    Public Property Titre As String
    Public Property Description As String
    Public Property StatutExistant As Short=1
    Public Property DateCreation As DateTime=Now

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property ChampsSection As ICollection(Of ChampsSection)

    Public Overridable Property Formulaire As Formulaire
End Class
