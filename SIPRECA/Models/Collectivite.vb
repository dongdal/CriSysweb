Partial Public Class Collectivite
    Public Sub New()
        Adresse = New HashSet(Of Adresse)()
        BudgetCollectivite = New HashSet(Of BudgetCollectivite)()
        'Communes = New HashSet(Of Commune)()
        'Departements = New HashSet(Of Departement)()
        Indemmisation = New HashSet(Of Indemmisation)()
        'Regions = New HashSet(Of Region)()
    End Sub


    Public Property Id As Long

    Public Property Libelle As String
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Adresse As ICollection(Of Adresse)
    Public Overridable Property BudgetCollectivite As ICollection(Of BudgetCollectivite)
    'Public Overridable Property Communes As ICollection(Of Commune)
    'Public Overridable Property Departements As ICollection(Of Departement)
    Public Overridable Property Indemmisation As ICollection(Of Indemmisation)
    'Public Overridable Property Regions As ICollection(Of Region)
End Class
