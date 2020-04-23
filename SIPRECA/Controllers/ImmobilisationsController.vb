Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources

Namespace Controllers
    Public Class ImmobilisationsController
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

        Private Function GetCurrentUser() As ApplicationUser
            Dim id = User.Identity.GetUserId
            Dim aspuser = Db.Users.Find(id)
            Return aspuser
        End Function

        ' GET: Immobilisation
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(41, 2) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            ViewBag.CurrentSort = sortOrder
            ViewBag.NumeroImobilisationSort = If(sortOrder = "NumeroImobilisation", "NumeroImobilisation_desc", "NumeroImobilisation")
            ViewBag.NumeroDeSerieSort = If(sortOrder = "NumeroDeSerie", "NumeroDeSerie_desc", "NumeroDeSerie")
            ViewBag.DateAchatSort = If(sortOrder = "DateAchat", "DateAchat_desc", "DateAchat")
            ViewBag.PrixAchatSort = If(sortOrder = "PrixAchat", "PrixAchat_desc", "PrixAchat")
            ViewBag.TypeImmobilisationtreSort = If(sortOrder = "TypeImmobilisation", "TypeImmobilisation_desc", "TypeImmobilisation")
            ViewBag.InfrastructureSort = If(sortOrder = "Infrastructure", "Infrastructure_desc", "Infrastructure")
            ViewBag.FournisseurSort = If(sortOrder = "Fournisseur", "Fournisseur_desc", "Fournisseur")
            ViewBag.ElementSort = If(sortOrder = "Element", "Element_desc", "Element")
            ViewBag.DeviseSort = If(sortOrder = "Devise", "Devise_desc", "Devise")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.Immobilisation Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.NumeroDeSerie.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.NumeroImobilisation.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Devise.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Element.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Fournisseur.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Infrastructure.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.TypeImmobilisation.Libelle.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "NumeroImobilisation"
                    entities = entities.OrderBy(Function(e) e.NumeroImobilisation)
                Case "NumeroImobilisation_desc"
                    entities = entities.OrderByDescending(Function(e) e.NumeroImobilisation)
                Case "NumeroDeSerie"
                    entities = entities.OrderBy(Function(e) e.NumeroDeSerie)
                Case "NumeroDeSerie_desc"
                    entities = entities.OrderByDescending(Function(e) e.NumeroDeSerie)
                Case "DateAchat"
                    entities = entities.OrderBy(Function(e) e.DateAchat)
                Case "DateAchat_desc"
                    entities = entities.OrderByDescending(Function(e) e.DateAchat)
                Case "PrixAchat"
                    entities = entities.OrderBy(Function(e) e.PrixAchat)
                Case "PrixAchat_desc"
                    entities = entities.OrderByDescending(Function(e) e.PrixAchat)
                Case "TypeImmobilisation"
                    entities = entities.OrderBy(Function(e) e.TypeImmobilisation.Libelle)
                Case "TypeImmobilisation_desc"
                    entities = entities.OrderByDescending(Function(e) e.TypeImmobilisation.Libelle)
                Case "Infrastructure"
                    entities = entities.OrderBy(Function(e) e.Infrastructure.Nom)
                Case "Infrastructure_desc"
                    entities = entities.OrderByDescending(Function(e) e.Infrastructure.Nom)
                Case "Fournisseur"
                    entities = entities.OrderBy(Function(e) e.Fournisseur.Nom)
                Case "Fournisseur_desc"
                    entities = entities.OrderByDescending(Function(e) e.Fournisseur.Nom)
                Case "Element"
                    entities = entities.OrderBy(Function(e) e.Element.Nom)
                Case "Element_desc"
                    entities = entities.OrderByDescending(Function(e) e.Element.Nom)
                Case "Devise"
                    entities = entities.OrderBy(Function(e) e.Devise.Libelle)
                Case "Devise_desc"
                    entities = entities.OrderByDescending(Function(e) e.Devise.Libelle)
                Case Else
                    entities = entities.OrderBy(Function(e) e.NumeroImobilisation)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Heliport/Edit/5
        Function Details(ByVal id As Long?) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(41, 5) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Immobilisation As Immobilisation = Db.Immobilisation.Find(id)
            If IsNothing(Immobilisation) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New ImmobilisationViewModel(Immobilisation)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        Private Sub LoadComboBox(entityVM As ImmobilisationViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            Dim TypeImmobilisation = (From e In Db.TypeImmobilisation Where e.StatutExistant = 1 Select e)
            Dim LesTypeImmobilisations As New List(Of SelectListItem)
            Dim Infrastructure = (From e In Db.Infrastructure Where e.StatutExistant = 1 Select e)
            Dim LesInfrastructures As New List(Of SelectListItem)
            Dim Fournisseur = (From e In Db.Organisation Where e.StatutExistant = 1 Select e)
            Dim LesFournisseurs As New List(Of SelectListItem)
            Dim Element = (From e In Db.Element Where e.StatutExistant = 1 Select e)
            Dim LesElements As New List(Of SelectListItem)
            Dim Devise = (From e In Db.Devise Where e.StatutExistant = 1 Select e)
            Dim LesDevises As New List(Of SelectListItem)

            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " " & item.Prenom})
                End If
            Next

            For Each item In TypeImmobilisation
                LesTypeImmobilisations.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next
            For Each item In Infrastructure
                LesInfrastructures.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
            Next
            For Each item In Fournisseur
                LesFournisseurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
            Next
            For Each item In Element
                LesElements.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
            Next
            For Each item In Devise
                LesDevises.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            entityVM.LesTypeImmobilisations = LesTypeImmobilisations
            entityVM.LesDevises = LesDevises
            entityVM.LesElements = LesElements
            entityVM.LesFournisseurs = LesFournisseurs
            entityVM.LesInfrastructures = LesInfrastructures
            entityVM.LesUtilisateurs = LesUtilisateurs
        End Sub

        ' GET: Immobilisation/Create
        Function Create() As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(41, 1) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            Dim entityVM As New ImmobilisationViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Immobilisation/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As ImmobilisationViewModel) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(41, 1) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            entityVM.AspNetUserId = GetCurrentUser.Id
            If ModelState.IsValid Then
                Db.Immobilisation.Add(entityVM.GetEntity)
                Try
                    Db.SaveChanges()
                    Return RedirectToAction("Index")
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try
            End If
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' GET: Immobilisation/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(41, 3) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Immobilisation As Immobilisation = Db.Immobilisation.Find(id)
            If IsNothing(Immobilisation) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New ImmobilisationViewModel(Immobilisation)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Immobilisation/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As ImmobilisationViewModel) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(41, 3) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If ModelState.IsValid Then
                Db.Entry(entityVM.GetEntity).State = EntityState.Modified
                Try
                    Db.SaveChanges()
                    Return RedirectToAction("Index")
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try
            End If
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' GET: Immobilisation/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(41, 4) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Immobilisation As Immobilisation = Db.Immobilisation.Find(id)
            If IsNothing(Immobilisation) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New ImmobilisationViewModel(Immobilisation)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Immobilisation/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(41, 4) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            Dim Immobilisation As Immobilisation = Db.Immobilisation.Find(id)
            Db.Immobilisation.Remove(Immobilisation)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New ImmobilisationViewModel(Immobilisation))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
