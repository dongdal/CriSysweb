Public Class AspNetUserActionSousRessource
    Public Property Id As Long

    Public Property AspNetUserId As String 'Utilisateur à qui les droit appartiennent
    Public Overridable Property AspNetUser As ApplicationUser

    Public Property ActionSousRessourceId As Long
    Public Overridable Property ActionSousRessource As ActionSousRessource

    Public Property StatutExistant As Short = 1
    Public Property DateCreation As DateTime = Now

    Public Property UserId As String 'Utilisateur ayant procéder à l'enregistrement
    Public Overridable Property User As ApplicationUser

End Class
