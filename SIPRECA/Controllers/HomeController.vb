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
        Dim AnneesBudgetaires = (From annee In Db.AnneeBudgetaires Where annee.StatutExistant = 1 Select annee).ToList()
        Dim LesAnneesBudgetaires As New List(Of SelectListItem)
        For Each item In AnneesBudgetaires
            LesAnneesBudgetaires.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
        Next
        ViewBag.LesAnneesBudgetaires = LesAnneesBudgetaires
        Return View()
    End Function

    Function IndexSahana() As ActionResult
        Return View()
    End Function

    Function IndexDesinventar() As ActionResult
        Return View()
    End Function

    Function IndexCollecte() As ActionResult
        Return View()
    End Function

    Function IndexAlertes() As ActionResult
        Return View()
    End Function

    Function IndexSinistre(AnneeBudgetaireId As Long?) As ActionResult
        AppSession.LesAnneeBudgetaires = Db.AnneeBudgetaires.Where(Function(e) e.StatutExistant = 1).ToList
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
