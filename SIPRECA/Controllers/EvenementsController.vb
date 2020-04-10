Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources

Namespace Controllers
    Public Class EvenementsController
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

        ' GET: Evenement
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            If AppSession.ListActionSousRessource.Contains(55, 2) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            ViewBag.CurrentSort = sortOrder
            ViewBag.LibelleSort = If(sortOrder = "Libelle", "Libelle_desc", "Libelle")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.Evenement Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Libelle.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Libelle"
                    entities = entities.OrderBy(Function(e) e.Libelle)
                Case "Libelle_desc"
                    entities = entities.OrderByDescending(Function(e) e.Libelle)

                Case Else
                    entities = entities.OrderBy(Function(e) e.Libelle)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Evenement/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim Evenement As Evenement = Db.Evenement.Find(id)
        '    If IsNothing(Evenement) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(Evenement)
        'End Function

        Private Sub LoadComboBox(entityVM As EvenementViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)

            Dim Facteu = (From e In Db.FacteurEvenement Where e.EvenementId = entityVM.Id Select e.Facteur).ToList
            Dim FacteurEvenements = (From e In Db.FacteurEvenement Where e.EvenementId = entityVM.Id Select e).ToList

            Dim Facteurs = (From e In Db.Facteur Where e.StatutExistant = 1 Select e).ToList
            Dim LesFacteurs As New List(Of SelectListItem)

            For Each item In Facteurs
                If Not Facteu.Contains(item) Then
                    LesFacteurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
                End If
            Next

            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            entityVM.FacteurEvenements = FacteurEvenements
            entityVM.LesFacteurs = LesFacteurs
            entityVM.LesUtilisateurs = LesUtilisateurs
        End Sub

        ' GET: Evenement/Create
        Function Create() As ActionResult
            If AppSession.ListActionSousRessource.Contains(55, 1) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            Dim entityVM As New EvenementViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Evenement/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As EvenementViewModel) As ActionResult
            If AppSession.ListActionSousRessource.Contains(55, 1) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            entityVM.AspNetUserId = GetCurrentUser.Id
            If ModelState.IsValid Then
                Db.Evenement.Add(entityVM.GetEntity)
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

        ' GET: Evenement/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If AppSession.ListActionSousRessource.Contains(55, 3) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Evenement As Evenement = Db.Evenement.Find(id)
            If IsNothing(Evenement) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New EvenementViewModel(Evenement)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Evenement/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As EvenementViewModel) As ActionResult
            If AppSession.ListActionSousRessource.Contains(55, 3) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If Request.Form("AddFacteur") IsNot Nothing Then
                Return AddFacteur(entityVM)
            Else
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
            End If
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        <ValidateAntiForgeryToken()>
        <HttpPost>
        Public Function AddFacteur(ByVal entityVM As EvenementViewModel) As ActionResult

            If IsNothing(entityVM.FacteurId) Then
                ModelState.AddModelError("FacteurId", Resource.MdlError_Fichier) 'Le champ {0} est obligatoire: veuillez le remplir.
            End If

            If ModelState.IsValid Then

                Dim FacteurEvenement As New FacteurEvenement()

                If entityVM.FacteurId > 0 Then

                    FacteurEvenement.FacteurId = entityVM.FacteurId
                    FacteurEvenement.EvenementId = entityVM.Id
                    FacteurEvenement.AspNetUserId = GetCurrentUser.Id

                    Db.FacteurEvenement.Add(FacteurEvenement)
                    Try
                        Db.SaveChanges()
                    Catch ex As DbEntityValidationException
                        Util.GetError(ex, ModelState)
                    Catch ex As Exception
                        Util.GetError(ex, ModelState)
                    End Try

                End If
                Return RedirectToAction("Edit", New With {entityVM.Id})
            End If
            LoadComboBox(entityVM)
            Return View("Edit", entityVM)
        End Function

        <HttpPost>
        Public Function DeleteFacteur(id As String) As JsonResult
            If [String].IsNullOrEmpty(id) Then
                Response.StatusCode = CType(HttpStatusCode.BadRequest, Integer)
                Return Json(New With {.Result = "Error"})
            End If
            Try
                Dim FacteurEvenement = (From p In Db.FacteurEvenement Where p.Id = id Select p).ToList.FirstOrDefault
                If FacteurEvenement Is Nothing Then
                    Response.StatusCode = CType(HttpStatusCode.NotFound, Integer)
                    Return Json(New With {.Result = "Error"})
                End If

                Db.FacteurEvenement.Remove(FacteurEvenement)
                Try
                    Db.SaveChanges()
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try

                Return Json(New With {.Result = "OK"})
            Catch ex As Exception
                'Return Json(New With {.Result = "ERROR", .Message = ex.Message})
                Return Json(New With {.Result = "Error"})
            End Try
        End Function

        ' GET: Evenement/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If AppSession.ListActionSousRessource.Contains(55, 4) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Evenement As Evenement = Db.Evenement.Find(id)
            If IsNothing(Evenement) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New EvenementViewModel(Evenement)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Evenement/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            If AppSession.ListActionSousRessource.Contains(55, 4) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            Dim Evenement As Evenement = Db.Evenement.Find(id)
            Db.Evenement.Remove(Evenement)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New EvenementViewModel(Evenement))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
