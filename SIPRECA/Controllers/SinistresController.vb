Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources

Namespace Controllers
    Public Class SinistresController
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

        ' GET: Sinistre
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(13, 2) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            ViewBag.CurrentSort = sortOrder
            ViewBag.LibelleSort = If(sortOrder = "Libelle", "Libelle_desc", "Libelle")
            ViewBag.TypeSinistreSort = If(sortOrder = "TypeSinistre", "TypeSinistre_desc", "TypeSinistre")
            ViewBag.DateDuSinistreSort = If(sortOrder = "DateDuSinistre", "DateDuSinistre_desc", "DateDuSinistre")
            ViewBag.LieuDuSinistreSort = If(sortOrder = "LieuDuSinistre", "LieuDuSinistre_desc", "LieuDuSinistre")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.Sinistre Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or e.TypeSinistre.Libelle.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Libelle"
                    entities = entities.OrderBy(Function(e) e.Libelle)
                Case "Libelle_desc"
                    entities = entities.OrderByDescending(Function(e) e.Libelle)
                Case "TypeSinistre"
                    entities = entities.OrderBy(Function(e) e.TypeSinistre.Libelle)
                Case "TypeSinistre_desc"
                    entities = entities.OrderByDescending(Function(e) e.TypeSinistre.Libelle)
                Case "DateDuSinistre"
                    entities = entities.OrderBy(Function(e) e.DateDuSinistre)
                Case "DateDuSinistre_desc"
                    entities = entities.OrderByDescending(Function(e) e.DateDuSinistre)
                Case "LieuDuSinistre"
                    entities = entities.OrderBy(Function(e) e.LieuDuSinistre)
                Case "LieuDuSinistre_desc"
                    entities = entities.OrderByDescending(Function(e) e.LieuDuSinistre)
                Case Else
                    entities = entities.OrderBy(Function(e) e.Libelle)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Sinistre/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim Sinistre As Sinistre = Db.Sinistre.Find(id)
        '    If IsNothing(Sinistre) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(Sinistre)
        'End Function

        Private Sub LoadComboBox(entityVM As SinistreViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            Dim TypeSinistre = (From e In Db.TypeSinistre Where e.StatutExistant = 1 Select e)
            Dim LesTypeSinistres As New List(Of SelectListItem)

            Dim Collectivite = (From e In Db.Commune Where e.StatutExistant = 1 Select e)

            If (AppSession.Niveau.Equals(Util.UserLevel.Departemental)) Then
                Collectivite = Collectivite.Where(Function(e) e.DepartementId = AppSession.DepartementId)
            ElseIf (AppSession.Niveau.Equals(Util.UserLevel.Regional)) Then
                Collectivite = Collectivite.Where(Function(e) e.Departement.RegionId = AppSession.RegionId)
            ElseIf (AppSession.Niveau.Equals(Util.UserLevel.Communal)) Then
                Collectivite = Collectivite.Where(Function(e) e.Id = AppSession.CommuneId)
            End If

            Dim LesCollectivites As New List(Of SelectListItem)
            For Each item In Collectivite
                LesCollectivites.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            Dim AnneeBudgetaire = (From e In Db.AnneeBudgetaires Where e.StatutExistant = 1 Select e)
            Dim LesAnneeBudgetaires As New List(Of SelectListItem)
            For Each item In AnneeBudgetaire
                LesAnneeBudgetaires.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " " & item.Prenom})
                End If
            Next

            For Each item In TypeSinistre
                LesTypeSinistres.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            entityVM.LesCollectivites = LesCollectivites
            entityVM.LesAnneeBudgetaires = LesAnneeBudgetaires
            entityVM.LesTypeSinistres = LesTypeSinistres
            entityVM.LesUtilisateurs = LesUtilisateurs
        End Sub

        ' GET: Sinistre/Create
        Function Create() As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(13, 1) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            Dim entityVM As New SinistreViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Sinistre/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As SinistreViewModel) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(13, 1) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            entityVM.AspNetUserId = GetCurrentUser.Id
            If ModelState.IsValid Then
                Dim entity = entityVM.GetEntity
                Db.Sinistre.Add(entity)
                Try
                    Db.SaveChanges()

                    For Each item In entityVM.CommuneId
                        Dim collectiviteSinistre = New CollectiviteSinistree()
                        collectiviteSinistre.CommuneId = item
                        collectiviteSinistre.Libelle = entityVM.Libelle
                        collectiviteSinistre.SinistreId = entity.Id
                        collectiviteSinistre.DateSinistre = entityVM.DateDuSinistre
                        collectiviteSinistre.AspNetUserId = GetCurrentUser.Id
                        collectiviteSinistre.AnneeBudgetaireId = AppSession.AnneeBudgetaire.Id
                        Db.CollectiviteSinistree.Add(collectiviteSinistre)
                        Try
                            Db.SaveChanges()
                        Catch ex As DbEntityValidationException
                            Util.GetError(ex, ModelState)
                        Catch ex As Exception
                            Util.GetError(ex, ModelState)
                        End Try
                    Next
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

        ' GET: Sinistre/Edit/5
        Function Edit(ByVal ids As Long?) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(13, 3) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If IsNothing(ids) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Sinistre As Sinistre = Db.Sinistre.Find(ids)
            If IsNothing(Sinistre) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New SinistreViewModel(Sinistre)
            LoadComboBox(entityVM)
            Dim lesCommunes = (From e In Db.CollectiviteSinistree Where e.StatutExistant = 1 And e.SinistreId = ids Select e.Commune.Id).ToList
            entityVM.CommuneId = lesCommunes
            Return View(entityVM)
        End Function

        ' POST: Sinistre/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As SinistreViewModel) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(13, 3) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If ModelState.IsValid Then
                Db.Entry(entityVM.GetEntity).State = EntityState.Modified
                Try
                    Db.SaveChanges()
                    DeleteCollectivite(entityVM)
                    AddCollectivite(entityVM)
                    Try
                        Db.SaveChanges()
                    Catch ex As DbEntityValidationException
                        Util.GetError(ex, ModelState)
                    Catch ex As Exception
                        Util.GetError(ex, ModelState)
                    End Try

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

        Function AddCollectivite(ByVal entityVM As SinistreViewModel)
            For Each item In entityVM.CommuneId
                Dim collectiviteSinistre = New CollectiviteSinistree()
                collectiviteSinistre.CommuneId = item
                collectiviteSinistre.Libelle = entityVM.Libelle
                collectiviteSinistre.SinistreId = entityVM.Id
                collectiviteSinistre.DateSinistre = entityVM.DateDuSinistre
                collectiviteSinistre.AspNetUserId = GetCurrentUser.Id
                collectiviteSinistre.AnneeBudgetaireId = AppSession.AnneeBudgetaire.Id
                Db.CollectiviteSinistree.Add(collectiviteSinistre)
            Next
            Return True
        End Function

        Function DeleteCollectivite(ByVal entityVM As SinistreViewModel)

            Dim collectiviteSinistre = (From e In Db.CollectiviteSinistree Where e.StatutExistant = 1 And e.SinistreId = entityVM.Id Select e).ToList
            For Each item In collectiviteSinistre
                Db.CollectiviteSinistree.Remove(item)
            Next
            Return True
        End Function

        ' GET: Sinistre/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(13, 4) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Sinistre As Sinistre = Db.Sinistre.Find(id)
            If IsNothing(Sinistre) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New SinistreViewModel(Sinistre)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Sinistre/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(13, 4) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            Dim Sinistre As Sinistre = Db.Sinistre.Find(id)
            Db.Sinistre.Remove(Sinistre)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New SinistreViewModel(Sinistre))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
