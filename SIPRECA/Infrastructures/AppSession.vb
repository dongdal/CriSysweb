Public Class AppSession
    Shared Property DateFormat As String
        Get
            Return HttpContext.Current.Session("DateFormat")
        End Get
        Set(value As String)
            HttpContext.Current.Session("DateFormat") = value
        End Set
    End Property

    Shared Property RegionId As Long
        Get
            Return HttpContext.Current.Session("RegionId")
        End Get
        Set(value As Long)
            HttpContext.Current.Session("RegionId") = value
        End Set
    End Property

    Shared Property DepartementId As Long
        Get
            Return HttpContext.Current.Session("DepartementId")
        End Get
        Set(value As Long)
            HttpContext.Current.Session("DepartementId") = value
        End Set
    End Property

    Shared Property CommuneId As Long
        Get
            Return HttpContext.Current.Session("CommuneId")
        End Get
        Set(value As Long)
            HttpContext.Current.Session("CommuneId") = value
        End Set
    End Property

    Shared Property Niveau As Long
        Get
            Return HttpContext.Current.Session("Niveau")
        End Get
        Set(value As Long)
            HttpContext.Current.Session("Niveau") = value
        End Set
    End Property

    Shared Property UserId As String
        Get
            Return HttpContext.Current.Session("UserId")
        End Get
        Set(value As String)
            HttpContext.Current.Session("UserId") = value
        End Set
    End Property

    Shared Property UserName As String
        Get
            Return HttpContext.Current.Session("UserName")
        End Get
        Set(value As String)
            HttpContext.Current.Session("UserName") = value
        End Set
    End Property

    Shared Property NomUser As String
        Get
            Return HttpContext.Current.Session("NomUser")
        End Get
        Set(value As String)
            HttpContext.Current.Session("NomUser") = value
        End Set
    End Property

    Shared Property PrenomUser As String
        Get
            Return HttpContext.Current.Session("PrenomUser")
        End Get
        Set(value As String)
            HttpContext.Current.Session("PrenomUser") = value
        End Set
    End Property

    Shared Property AnneeBudgetaire As AnneeBudgetaire
        Get
            Return HttpContext.Current.Session("AnneeBudgetaire")
        End Get
        Set(value As AnneeBudgetaire)
            HttpContext.Current.Session("AnneeBudgetaire") = value
        End Set
    End Property

    Shared Property LesAnneeBudgetaires As List(Of AnneeBudgetaire)
        Get
            Return HttpContext.Current.Session("LesAnneeBudgetaires")
        End Get
        Set(value As List(Of AnneeBudgetaire))
            HttpContext.Current.Session("LesAnneeBudgetaires") = value
        End Set
    End Property

    Shared Property ListEvenementZone As List(Of EvenementZone)
        Get
            Return HttpContext.Current.Session("ListEvenementZone")
        End Get
        Set(value As List(Of EvenementZone))
            HttpContext.Current.Session("ListEvenementZone") = value
        End Set
    End Property

    Shared Property ActionSousRessourceList As List(Of ActionSousRessource)
        Get
            Return HttpContext.Current.Session("ActionSousRessourceList")
        End Get
        Set(value As List(Of ActionSousRessource))
            HttpContext.Current.Session("ActionSousRessourceList") = value
        End Set
    End Property

    Shared Property ModuleUserList As List(Of Long)
        Get
            Return HttpContext.Current.Session("ModuleUserList")
        End Get
        Set(value As List(Of Long))
            HttpContext.Current.Session("ModuleUserList") = value
        End Set
    End Property

    Shared Property ListRessources As List(Of Long)
        Get
            Return HttpContext.Current.Session("ListRessources")
        End Get
        Set(value As List(Of Long))
            HttpContext.Current.Session("ListRessources") = value
        End Set
    End Property

    Shared Property ListSousRessources As List(Of Long)
        Get
            Return HttpContext.Current.Session("ListSousRessources")
        End Get
        Set(value As List(Of Long))
            HttpContext.Current.Session("ListSousRessources") = value
        End Set
    End Property

    Shared Property ListUserActionSousResource As List(Of AspNetUserActionSousRessource)
        Get
            Return HttpContext.Current.Session("ListUserActionSousResource")
        End Get
        Set(value As List(Of AspNetUserActionSousRessource))
            HttpContext.Current.Session("ListUserActionSousResource") = value
        End Set
    End Property

    Shared Property ListActionSousRessource As List(Of ActionSousRessource)
        Get
            Return HttpContext.Current.Session("ListActionSousRessource")
        End Get
        Set(value As List(Of ActionSousRessource))
            HttpContext.Current.Session("ListActionSousRessource") = value
        End Set
    End Property

End Class
