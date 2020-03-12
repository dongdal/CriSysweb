﻿Public Class SousRessource
    Public Property Id As Long
    Public Property RessourceId As Long
    Public Overridable Property Ressource As Ressource
    Public Property Libelle As String
    Public Property Description As String
    Public Property StatutExistant As Short = 1
    Public Property DateCreation As DateTime = Now()
    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property ActionSousRessource As ICollection(Of ActionSousRessource)
    Public Sub New()
        ActionSousRessource = New HashSet(Of ActionSousRessource)()
    End Sub
End Class