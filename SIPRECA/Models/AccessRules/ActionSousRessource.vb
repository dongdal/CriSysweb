Public Class ActionSousRessource
    Public Property Id As Long
    Public Property ActionsId As Long
    Public Overridable Property Actions As Actions
    Public Property SousRessourceId As Long
    Public Overridable Property SousRessource As SousRessource

    Public Property StatutExistant As Short = 1
    Public Property DateCreation As DateTime = Now()

    Public Property AspNetUserId As String 'Il s'agit de l'utilisateur à qui on souhaite accorder des droits
    Public Overridable Property AspNetUser As ApplicationUser
End Class