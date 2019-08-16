Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources

Namespace Controllers
    Public Class CollectiviteSinistreesController
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


        ' GET: CollectiviteSinistrees
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.LibelleSort = If(sortOrder = "Libelle", "Libelle_desc", "Libelle")
            ViewBag.DateSinistreSort = If(sortOrder = "DateSinistre", "DateSinistre_desc", "DateSinistre")
            ViewBag.SinistreSort = If(sortOrder = "Sinistre", "Sinistre_desc", "Sinistre")
            ViewBag.CollectiviteSort = If(sortOrder = "Collectivite", "Collectivite_desc", "Collectivite")
            ViewBag.AnneeBudgetaireSort = If(sortOrder = "AnneeBudgetaire", "AnneeBudgetaire_desc", "AnneeBudgetaire")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.CollectiviteSinistree Where e.StatutExistant = 1 And e.AnneeBudgetaireId = AppSession.AnneeBudgetaire.Id Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or e.Sinistre.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Commune.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or e.AnneeBudgetaire.Libelle.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Libelle"
                    entities = entities.OrderBy(Function(e) e.Libelle)
                Case "Libelle_desc"
                    entities = entities.OrderByDescending(Function(e) e.Libelle)

                Case "Sinistre"
                    entities = entities.OrderBy(Function(e) e.Sinistre.Libelle)
                Case "Sinistre_desc"
                    entities = entities.OrderByDescending(Function(e) e.Sinistre.Libelle)

                Case "Collectivite"
                    entities = entities.OrderBy(Function(e) e.Commune.Libelle)
                Case "Collectivite_desc"
                    entities = entities.OrderByDescending(Function(e) e.Commune.Libelle)

                Case "AnneeBudgetaire"
                    entities = entities.OrderBy(Function(e) e.AnneeBudgetaire.Libelle)
                Case "AnneeBudgetaire_desc"
                    entities = entities.OrderByDescending(Function(e) e.AnneeBudgetaire.Libelle)

                Case "DateSinistre"
                    entities = entities.OrderBy(Function(e) e.DateSinistre)
                Case "DateSinistre_desc"
                    entities = entities.OrderByDescending(Function(e) e.DateSinistre)

                Case Else
                    entities = entities.OrderBy(Function(e) e.Libelle)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: CollectiviteSinistrees/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim CollectiviteSinistree As CollectiviteSinistree = db.Collectivite.Find(id)
        '    If IsNothing(CollectiviteSinistree) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(CollectiviteSinistree)
        'End Function

        Private Sub LoadComboBox(entityVM As CollectiviteSinistreeViewModel)

            Dim Sinistre = (From e In Db.Sinistre Where e.StatutExistant = 1 Select e)
            Dim LesSinistres As New List(Of SelectListItem)
            For Each item In Sinistre
                LesSinistres.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

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

            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            entityVM.LesSinistres = LesSinistres
            entityVM.LesCollectivites = LesCollectivites
            entityVM.LesAnneeBudgetaires = LesAnneeBudgetaires
            entityVM.LesUtilisateurs = LesUtilisateurs
        End Sub

        ' GET: CollectiviteSinistrees/Create
        Function Create() As ActionResult
            Dim entityVM As New CollectiviteSinistreeViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: CollectiviteSinistrees/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As CollectiviteSinistreeViewModel) As ActionResult
            Dim SinistreDejaDeclare = (From item In Db.CollectiviteSinistree Where item.CommuneId = entityVM.CommuneId And
                                                                                 item.SinistreId = entityVM.SinistreId And item.AnneeBudgetaireId = item.AnneeBudgetaireId Select item).ToList.Count
            entityVM.AnneeBudgetaireId = AppSession.AnneeBudgetaire.Id
            If (SinistreDejaDeclare >= 1) Then
                ModelState.AddModelError("", Resource.ModelError_SinistreDejaDeclare)
            Else
                entityVM.AspNetUserId = GetCurrentUser.Id
                If ModelState.IsValid Then
                    Db.CollectiviteSinistree.Add(entityVM.GetEntity)
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

        ' GET: CollectiviteSinistrees/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim CollectiviteSinistree As CollectiviteSinistree = Db.CollectiviteSinistree.Find(id)
            If IsNothing(CollectiviteSinistree) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New CollectiviteSinistreeViewModel(CollectiviteSinistree)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: CollectiviteSinistrees/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As CollectiviteSinistreeViewModel) As ActionResult
            'Dim SinistreDejaDeclare = (From item In Db.CollectiviteSinistree Where item.CollectiviteId = entityVM.CollectiviteId And
            'item.SinistreId = entityVM.SinistreId And item.AnneeBudgetaireId = item.AnneeBudgetaireId Select item).ToList.Count

            'If (SinistreDejaDeclare >= 1) Then
            '    ModelState.AddModelError("", Resource.ModelError_SinistreDejaDeclare)
            'Else
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
            'End If
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' GET: CollectiviteSinistrees/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim CollectiviteSinistree As CollectiviteSinistree = Db.CollectiviteSinistree.Find(id)
            If IsNothing(CollectiviteSinistree) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New CollectiviteSinistreeViewModel(CollectiviteSinistree)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: CollectiviteSinistrees/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim SinistreDeclareUtilise = (From item In Db.Demande Where item.CollectiviteSinistreeId = id).ToList.Count
            Dim CollectiviteSinistree As CollectiviteSinistree = Db.CollectiviteSinistree.Find(id)
            If (SinistreDeclareUtilise >= 1) Then
                ModelState.AddModelError("", Resource.ModelError_SinistreDeclareUtilise)
            Else
                Db.CollectiviteSinistree.Remove(CollectiviteSinistree)
                Try
                    Db.SaveChanges()
                    Return RedirectToAction("Index")
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try
            End If
            Return View(New CollectiviteSinistreeViewModel(CollectiviteSinistree))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
