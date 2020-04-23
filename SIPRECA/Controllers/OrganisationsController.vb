Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources

Namespace Controllers
    Public Class OrganisationsController
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

        ' GET: Organisation
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(20, 2) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            ViewBag.CurrentSort = sortOrder
            ViewBag.NomSort = If(sortOrder = "Nom", "Nom_desc", "Nom")
            ViewBag.AcronymeSort = If(sortOrder = "Acronyme", "Acronyme_desc", "Acronyme")
            ViewBag.TelephoneSort = If(sortOrder = "Telephone", "Telephone_desc", "Telephone")
            ViewBag.VilleSort = If(sortOrder = "Ville", "Ville_desc", "Ville")
            ViewBag.SecteurSort = If(sortOrder = "Secteur", "Secteur_desc", "Secteur")
            ViewBag.TypeOrganisationSort = If(sortOrder = "TypeOrganisation", "TypeOrganisation_desc", "TypeOrganisation")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.Organisation Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or e.Acronyme.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Telephone.ToUpper.Contains(value:=searchString.ToUpper) Or e.Ville.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.TypeOrganisation.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or e.Email.ToUpper.Contains(value:=searchString.ToUpper) Or
                                               e.BoitePostale.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Nom"
                    entities = entities.OrderBy(Function(e) e.Nom)
                Case "Nom_desc"
                    entities = entities.OrderByDescending(Function(e) e.Nom)

                Case "Acronyme"
                    entities = entities.OrderBy(Function(e) e.Acronyme)
                Case "Acronyme_desc"
                    entities = entities.OrderByDescending(Function(e) e.Acronyme)

                Case "Telephone"
                    entities = entities.OrderBy(Function(e) e.Telephone)
                Case "Telephone_desc"
                    entities = entities.OrderByDescending(Function(e) e.Telephone)

                Case "Ville"
                    entities = entities.OrderBy(Function(e) e.Ville.Libelle)
                Case "Ville_desc"
                    entities = entities.OrderByDescending(Function(e) e.Ville.Libelle)

                Case "TypeOrganisation"
                    entities = entities.OrderBy(Function(e) e.TypeOrganisation.Libelle)
                Case "TypeOrganisation_desc"
                    entities = entities.OrderByDescending(Function(e) e.TypeOrganisation.Libelle)

                    'Case "Secteur"
                    '    entities = entities.OrderBy(Function(e) e.Secteur.Libelle)
                    'Case "Secteur_desc"
                    '    entities = entities.OrderByDescending(Function(e) e.Secteur.Libelle)

                Case Else
                    entities = entities.OrderBy(Function(e) e.Nom)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        Private Sub LoadComboBox(entityVM As OrganisationViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            Dim TypeOrganisations = (From e In Db.TypeOrganisation Where e.StatutExistant = 1 Select e)
            Dim LesTypeOrganisations As New List(Of SelectListItem)
            For Each item In TypeOrganisations
                LesTypeOrganisations.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            Dim Villes = (From e In Db.Ville Where e.StatutExistant = 1 Select e)
            Dim LesVilles As New List(Of SelectListItem)
            For Each item In Villes
                LesVilles.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            Dim Secteurs = (From e In Db.Secteur Where e.StatutExistant = 1 Select e)
            Dim LesSecteurs As New List(Of SelectListItem)
            For Each item In Secteurs
                LesSecteurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            entityVM.LesTypeOrganisations = LesTypeOrganisations
            entityVM.LesVilles = LesVilles
            'entityVM.LesSecteurs = LesSecteurs
            entityVM.LesUtilisateurs = LesUtilisateurs
        End Sub

        ' GET: Organisation/Create
        Function Create() As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(20, 1) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            Dim entityVM As New OrganisationViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Organisation/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As OrganisationViewModel) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(20, 1) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            entityVM.AspNetUserId = GetCurrentUser.Id
            If ModelState.IsValid Then
                Db.Organisation.Add(entityVM.GetEntity)
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

        ' GET: Organisation/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(20, 3) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Organisation As Organisation = Db.Organisation.Find(id)
            If IsNothing(Organisation) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New OrganisationViewModel(Organisation)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Organisation/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As OrganisationViewModel) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(20, 3) Then
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

        ' GET: Organisation/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(20, 4) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Organisation As Organisation = Db.Organisation.Find(id)
            If IsNothing(Organisation) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New OrganisationViewModel(Organisation)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Organisation/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(20, 4) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            Dim Organisation As Organisation = Db.Organisation.Find(id)
            Db.Organisation.Remove(Organisation)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New OrganisationViewModel(Organisation))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
