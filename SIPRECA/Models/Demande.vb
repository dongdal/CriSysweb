Partial Public Class Demande
    Public Sub New()
        'Indemmisation = New HashSet(Of Indemmisation)()
        PieceJointe = New HashSet(Of PieceJointe)()
        Suivi = New HashSet(Of Suivi)()
    End Sub

    Public Property Id As Long

    Public Property SinistreId As Long
    Public Property SinistrerId As Long
    Public Property Reference As String
    Public Property Etat As Integer
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property CollectiviteSinistreeId As Long

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Sinistre As Sinistre
    Public Overridable Property Sinistrer As Sinistrer
    Public Overridable Property CollectiviteSinistree As CollectiviteSinistree

    'Public Overridable Property Indemmisation As ICollection(Of Indemmisation)
    Public Overridable Property PieceJointe As ICollection(Of PieceJointe)
    Public Overridable Property Suivi As ICollection(Of Suivi)

End Class
