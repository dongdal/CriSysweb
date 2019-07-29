Public Class AppSession

    'Shared Property InstrusVerificationPeriodiqueProche As List(Of Instrument)
    '    Get
    '        Return HttpContext.Current.Session("InstrusVerificationPeriodiqueProche")
    '    End Get
    '    Set(value As List(Of Instrument))
    '        HttpContext.Current.Session("InstrusVerificationPeriodiqueProche") = value
    '    End Set
    'End Property

    'Shared Property LesOrdreRecetteDepasses As List(Of OrdreRecette)
    '    Get
    '        Return HttpContext.Current.Session("LesOrdreRecetteDepasses")
    '    End Get
    '    Set(value As List(Of OrdreRecette))
    '        HttpContext.Current.Session("LesOrdreRecetteDepasses") = value
    '    End Set
    'End Property

    'Shared Property ServiceUtilisateur As UserService
    '    Get
    '        Return HttpContext.Current.Session("ServiceUtilisateur")
    '    End Get
    '    Set(value As UserService)
    '        HttpContext.Current.Session("ServiceUtilisateur") = value
    '    End Set
    'End Property

    'Shared Property ListeDemandeControle As List(Of Demande)
    '    Get
    '        Return HttpContext.Current.Session("ListeDemandeControle")
    '    End Get
    '    Set(value As List(Of Demande))
    '        HttpContext.Current.Session("ListeDemandeControle") = value
    '    End Set
    'End Property

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


End Class
