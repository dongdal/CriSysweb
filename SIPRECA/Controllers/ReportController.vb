Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports SIPRECA
Imports SIPRECA.My.Resources

Public Class ReportController
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

    Function ListeHopitaux() As ActionResult
        Return View()
    End Function

    Function ListeHeliports() As ActionResult
        Return View()
    End Function

    Function ListePorts() As ActionResult
        Return View()
    End Function

    Function ListeDesAeroports() As ActionResult
        Return View()
    End Function

    Function ListeDesBureaux() As ActionResult
        Return View()
    End Function

    Function ListeDesAbris() As ActionResult
        Return View()
    End Function

    Function ListeDesEntrepots() As ActionResult
        Return View()
    End Function

    Function ListeDesPorts() As ActionResult
        Return View()
    End Function

    ' GET: Report/ExportCollectDatas/5
    Function ExportCollectDatas(ByVal FormulaireId As Long) As ActionResult
        If Not AppSession.ListActionSousRessource.Contains(58, 3) Or Not AppSession.ListActionSousRessource.Contains(58, 1) Then
            Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
        End If
        If IsNothing(FormulaireId) Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If
        Dim formulaire As Formulaire = Db.Formulaire.Find(FormulaireId)
        If IsNothing(formulaire) Then
            Return HttpNotFound()
        End If
        Dim entityVM As New ExportCollectDatasViewModel(FormulaireId, formulaire.EnqueteId)
        Return View(entityVM)
    End Function
End Class

