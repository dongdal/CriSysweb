Public Class Proposition

    Public Sub New()
        ValeurChamps = New HashSet(Of ValeurChamps)()
    End Sub

    Public Property Id As Long
    Public Property Libelle As String
    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property ChampsId As Long
    Public Overridable Property Champs As Champs
    Public Overridable Property ValeurChamps As ICollection(Of ValeurChamps)
End Class
