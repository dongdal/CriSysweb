Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports SIPRECA
Imports SIPRECA.My.Resources

Public Class HomeController
    Inherits BaseController

    Private _db As New ApplicationDbContext

    Public Property Db As ApplicationDbContext
        Get
            Return _db
        End Get
        Set(value As ApplicationDbContext)
            _db = value
        End Set
    End Property


    Function Index() As ActionResult
        AppSession.ListRessources = New List(Of Ressource)
        For Each item In AppSession.ActionSousRessourceList
            AppSession.ListRessources.Add(item.SousRessource.Ressource)
        Next
        Dim AnneesBudgetaires = (From annee In Db.AnneeBudgetaires Where annee.StatutExistant = 1 Select annee).ToList()
            Dim LesAnneesBudgetaires As New List(Of SelectListItem)
            For Each item In AnneesBudgetaires
                LesAnneesBudgetaires.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next
            ViewBag.LesAnneesBudgetaires = LesAnneesBudgetaires
            Return View()
    End Function

    Function IndexSinistre(AnneeBudgetaireId As Long?) As ActionResult
        If Not AppSession.ModuleUserList.Contains(1) Then
            Return RedirectToAction("Error400", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
        End If
        AppSession.LesAnneeBudgetaires = Db.AnneeBudgetaires.Where(Function(e) e.StatutExistant = 1).ToList
        Dim EtatDemande As New EtatDemande()
        Dim entities = (From e In Db.Demande Select e)
        If AppSession.Niveau.Equals(Util.UserLevel.Communal) Then
            entities = entities.Where(Function(e) e.CollectiviteSinistree.CommuneId = AppSession.CommuneId)
        ElseIf AppSession.Niveau.Equals(Util.UserLevel.Regional) Then
            entities = entities.Where(Function(e) e.StatutExistant >= 3 Or
                                                           e.StatutExistant = -2 And
                                                         (e.CollectiviteSinistree.Commune.DepartementId = AppSession.DepartementId Or e.AspNetUser.DepartementId = AppSession.DepartementId Or
                                                         e.AspNetUser.Commune.DepartementId = AppSession.DepartementId))
        Else
            entities = entities.Where(Function(e) e.StatutExistant >= 7 Or
                                                           e.StatutExistant = -3 And
                                                           (e.CollectiviteSinistree.Commune.Departement.RegionId = AppSession.RegionId Or e.AspNetUser.RegionId = AppSession.RegionId Or
                                                           e.AspNetUser.Departement.RegionId = AppSession.RegionId Or
                                                           e.AspNetUser.Commune.Departement.RegionId = AppSession.RegionId))
        End If
        EtatDemande.DemandesEnCours = entities.Where(Function(e) e.StatutExistant > 0 And e.StatutExistant <> 15 And e.StatutExistant <> 16).ToList().Count
        EtatDemande.DemandesRejetees = entities.Where(Function(e) e.StatutExistant < 0 Or e.StatutExistant = 15).ToList().Count
        EtatDemande.DemandesApprouvees = entities.Where(Function(e) e.StatutExistant = 16).ToList().Count
        ViewBag.EtatDemade = EtatDemande

        If IsNothing(AnneeBudgetaireId) Then
            If IsNothing(AppSession.AnneeBudgetaire) Then
                Return RedirectToAction("Error400", "Home", New With {Resource.Error400_SelectAnnee, .MyAction = "Index", .Controleur = "Home"})
            Else
                AnneeBudgetaireId = AppSession.AnneeBudgetaire.Id
                Return View()
            End If
        End If
        Dim anneeBudgetaire As AnneeBudgetaire = Db.AnneeBudgetaires.Find(AnneeBudgetaireId)
        If IsNothing(anneeBudgetaire) Then
            Return HttpNotFound()
        End If
        AppSession.AnneeBudgetaire = anneeBudgetaire
        Return View()
    End Function

    Function IndexSahana() As ActionResult
        If Not AppSession.ModuleUserList.Contains(2) Then
            Return RedirectToAction("Error400", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
        End If
        Dim MoyenReponse As New MoyenReponse()
        MoyenReponse.Abris = (From e In Db.Abris Where e.StatutExistant = 1 Select e).ToList().Count
        MoyenReponse.Aeroports = (From e In Db.Aeroport Where e.StatutExistant = 1 Select e).ToList().Count
        MoyenReponse.Bureaux = (From e In Db.Bureau Where e.StatutExistant = 1 Select e).ToList().Count
        MoyenReponse.Entrepots = (From e In Db.Entrepots Where e.StatutExistant = 1 Select e).ToList().Count
        MoyenReponse.Heliports = (From e In Db.Heliport Where e.StatutExistant = 1 Select e).ToList().Count
        MoyenReponse.Hopitaux = (From e In Db.Hopitaux Where e.StatutExistant = 1 Select e).ToList().Count
        MoyenReponse.PortDeMer = (From e In Db.PortDeMer Where e.StatutExistant = 1 Select e).ToList().Count
        ViewBag.MoyenReponse = MoyenReponse
        Return View()
    End Function

    Function IndexDesinventar() As ActionResult
        If Not AppSession.ModuleUserList.Contains(3) Then
            Return RedirectToAction("Error400", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
        End If
        Return View()
    End Function

    Function IndexCollecte() As ActionResult
        If Not AppSession.ModuleUserList.Contains(4) Then
            Return RedirectToAction("Error400", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
        End If
        Return View()
    End Function

    Function IndexAlertes() As ActionResult
        If Not AppSession.ModuleUserList.Contains(5) Then
            Return RedirectToAction("Error400", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
        End If
        Return View()
    End Function

    Function IndexParam() As ActionResult
        If Not AppSession.ModuleUserList.Contains(6) Then
            Return RedirectToAction("Error400", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
        End If
        Return View()
    End Function

    Function IndexReport() As ActionResult
        If Not AppSession.ModuleUserList.Contains(7) Then
            Return RedirectToAction("Error400", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
        End If
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Error400(Error400_SelectAnnee As String, Optional MyAction As String = "Index", Optional Controleur As String = "Home") As ActionResult
        ViewBag.Error400_SelectAnnee = Error400_SelectAnnee
        ViewBag.Action = MyAction
        ViewBag.Controleur = Controleur
        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class

Public Class EtatDemande
    Public Property DemandesEnCours As Double = 0.0
    Public Property DemandesRejetees As Double = 0.0
    Public Property DemandesApprouvees As Double = 0.0

    Public Sub New()

    End Sub
End Class

Public Class MoyenReponse
    Public Property Hopitaux As Double = 0.0
    Public Property Heliports As Double = 0.0
    Public Property PortDeMer As Double = 0.0
    Public Property Abris As Double = 0.0
    Public Property Aeroports As Double = 0.0
    Public Property Bureaux As Double = 0.0
    Public Property Entrepots As Double = 0.0

    Public Sub New()

    End Sub
End Class


'Dim LesRegions = (From e In Db.Region Where e.StatutExistant = 1 Select e).ToList()
'For Each region In LesRegions
'    Dim LesDepartements = region.Departement.OrderBy(Function(e) e.Libelle).ToList()
'    Dim i As Integer = 1
'    For Each departement In LesDepartements
'        Dim CodeDep As String = ""
'        CodeDep = IIf(i < 10, region.Code & "0" & i.ToString(), region.Code & i.ToString())
'        departement.Code = CodeDep
'        Db.Entry(departement).State = EntityState.Modified
'        i = i + 1
'        Dim LesCommunes = departement.Commune.OrderBy(Function(e) e.Libelle).ToList()
'        Dim j As Integer = 1
'        For Each commune In LesCommunes
'            commune.Code = IIf(j < 10, CodeDep & "0" & j.ToString(), CodeDep & j.ToString())
'            Db.Entry(commune).State = EntityState.Modified
'            j = j + 1
'        Next
'    Next
'Next
'Try
'    Db.SaveChanges()
'    Return RedirectToAction("Index")
'Catch ex As DbEntityValidationException
'    Util.GetError(ex, ModelState)
'Catch ex As Exception
'    Util.GetError(ex, ModelState)
'End Try