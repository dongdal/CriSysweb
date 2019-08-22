
Partial Public Class TypeVehicule
    Public Sub New()
        Vehicule = New HashSet(Of Vehicule)()
    End Sub


    Public Property Id As Long
    Public Property Libelle As String
    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Vehicule As ICollection(Of Vehicule)
End Class
