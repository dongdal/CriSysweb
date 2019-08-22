Partial Public Class Collectivite
    Public Sub New()
        'Adresse = New HashSet(Of Adresse)()
        BudgetCollectivite = New HashSet(Of BudgetCollectivite)()
        'Indemmisation = New HashSet(Of Indemmisation)()
    End Sub


    Public Property Id As Long

    Public Property Libelle As String
    Public Property Superficie As Double
    Public Property Population As Double
    Public Property Longitude As Double?
    Public Property Latitude As Double?
    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    'Public Overridable Property Adresse As ICollection(Of Adresse)
    Public Overridable Property BudgetCollectivite As ICollection(Of BudgetCollectivite)
    'Public Overridable Property Indemmisation As ICollection(Of Indemmisation)
End Class
