Public Module CrisisModule

    ''' <summary>
    ''' Cette énumération permet de connaître l'état d'un objet.
    ''' </summary>
    Public Enum StatutExistantEnum
        ''' <summary>
        ''' Valeur par défaut d'un objet nouvellement créé.
        ''' </summary>
        Encours = 1

        ''' <summary>
        ''' Statut d'un objet qui est à son état final et donc ne sera plus modifié.
        ''' </summary>
        Termine = 2
    End Enum

End Module
