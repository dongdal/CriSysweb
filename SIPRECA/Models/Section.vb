
Partial Public Class Section
    Public Sub New()
        Champs = New HashSet(Of Champs)()
    End Sub

    Public Property Id As Long
    Public Property FormulaireId As Long
    Public Property Titre As String
    Public Property Description As String
    Public Property StatutExistant As Short=1
    Public Property DateCreation As DateTime=Now

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Champs As ICollection(Of Champs)

    Public Overridable Property Formulaire As Formulaire
End Class
