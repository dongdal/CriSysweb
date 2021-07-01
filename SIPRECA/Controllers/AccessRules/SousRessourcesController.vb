Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources

Namespace Controllers
    Public Class SousRessourcesController
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

        ' GET: SousRessource
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(65, 2) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            ViewBag.CurrentSort = sortOrder
            ViewBag.LibelleSort = If(sortOrder = "Libelle", "Libelle_desc", "Libelle")
            ViewBag.RessourceSort = If(sortOrder = "Ressource", "Ressource_desc", "Ressource")
            ViewBag.DescriptionSort = If(sortOrder = "Description", "Description_desc", "Description")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.SousRessource Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or e.Description.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Ressource.Libelle.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Libelle"
                    entities = entities.OrderBy(Function(e) e.Libelle)
                Case "Libelle_desc"
                    entities = entities.OrderByDescending(Function(e) e.Libelle)

                Case "Module"
                    entities = entities.OrderBy(Function(e) e.Ressource.Libelle)
                Case "Module_desc"
                    entities = entities.OrderByDescending(Function(e) e.Ressource.Libelle)

                Case "Description"
                    entities = entities.OrderBy(Function(e) e.Description)
                Case "Description_desc"
                    entities = entities.OrderByDescending(Function(e) e.Description)

                Case Else
                    entities = entities.OrderBy(Function(e) e.Id)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: SousRessource/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim SousRessource As SousRessource = Db.SousRessource.Find(id)
        '    If IsNothing(SousRessource) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(SousRessource)
        'End Function

        Private Sub LoadComboBox(entityVM As SousRessourceViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            Dim Ressources = (From e In Db.Ressource Where e.StatutExistant = 1 Select e).ToList
            Dim LesRessources As New List(Of SelectListItem)
            For Each item In Ressources
                LesRessources.Add(New SelectListItem With {.Value = item.Id, .Text = item.Modules.Libelle & " -> " & item.Libelle})
            Next


            Dim Actions = (From e In Db.Actions Select e Where e.StatutExistant = 1)
            Dim LesActions As New List(Of SelectListItem)
            For Each item In Actions
                LesActions.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            entityVM.LesRessources = LesRessources
            entityVM.LesUtilisateurs = LesUtilisateurs
            entityVM.LesActions = LesActions
        End Sub

        ' GET: SousRessource/Create
        Function Create() As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(65, 1) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            Dim entityVM As New SousRessourceViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: SousRessource/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As SousRessourceViewModel) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(65, 1) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            entityVM.AspNetUserId = GetCurrentUser.Id
            If (IsNothing(entityVM.ActionsId)) Then
                ModelState.AddModelError("ActionsId", Resource.RequiredField)
            End If
            If ModelState.IsValid Then
                Using transaction = Db.Database.BeginTransaction
                    Try
                        Dim entity = entityVM.GetEntity()
                        Db.SousRessource.Add(entity)
                        AddActionSousRessource(entityVM.ActionsId, entity.Id)
                        Db.SaveChanges()
                        transaction.Commit()
                        Return RedirectToAction("Index")
                    Catch ex As DbEntityValidationException
                        transaction.Rollback()
                        Util.GetError(ex, ModelState)
                    Catch ex As Exception
                        transaction.Rollback()
                        Util.GetError(ex, ModelState)
                    End Try
                End Using
            End If
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        Private Sub AddActionSousRessource(ByVal ListActions As List(Of Long), IdSousRessource As Long)
            'on crée une liste d'action sur les sous ressources
            Dim actionSousRessourceList As New List(Of ActionSousRessource)
            'on récupère l'utilisateur connecté
            Dim currentUserId = GetCurrentUser().Id
            For Each IdAction In ListActions
                actionSousRessourceList.Add(New ActionSousRessource With {
                                            .ActionsId = IdAction,
                                            .AspNetUserId = currentUserId,
                                            .SousRessourceId = IdSousRessource,
                                            .DateCreation = Now,
                                            .StatutExistant = 1
                                            })
            Next
            Db.ActionSousRessource.AddRange(actionSousRessourceList)
        End Sub

        Private Sub DeleteActionSousRessource(IdSousRessource As Long)
            'on récupère la liste des actions liées à la sous ressource IdSousRessource dans la table ActionSousRessource
            Dim actionSousRessource = (From e In Db.ActionSousRessource Where e.SousRessourceId = IdSousRessource Select e).ToList

            'liste des actions possibles sur une sous ressource et qui ont été affectées à un (des) utilisateur(s)
            Dim userActionSousResourceList As New List(Of AspNetUserActionSousRessource)

            'on fait une boucle pour récupérer toutes les actions possibles sur des sous ressources et qui ont été affectées à un (des) utilisateur(s)
            For Each item In actionSousRessource
                Dim userActionSousRessource = (From e In Db.AspNetUserActionSousRessource Where e.ActionSousRessourceId = item.Id Select e).FirstOrDefault()
                If Not IsNothing(userActionSousRessource) Then
                    userActionSousResourceList.Add(userActionSousRessource)
                End If
            Next
            'on supprime les actions possibles sur les sous ressources qui ont été affectées à un(des) utilisateur(s) dans la table AspNetUserActionSousRessource
            Db.AspNetUserActionSousRessource.RemoveRange(userActionSousResourceList)

            'on supprime les actions possibles sur les sous ressources dans la table ActionSousRessource
            Db.ActionSousRessource.RemoveRange(actionSousRessource)
        End Sub

        ' GET: SousRessource/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(65, 3) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim SousRessource As SousRessource = Db.SousRessource.Find(id)
            If IsNothing(SousRessource) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New SousRessourceViewModel(SousRessource)
            LoadComboBox(entityVM)

            entityVM.ActionsId = (From actSousRes In Db.ActionSousRessource Where actSousRes.SousRessourceId = id Select actSousRes.ActionsId).ToList()
            For Each IdAction In entityVM.ActionsId
                For Each item In entityVM.LesActions
                    If item.Value = IdAction.ToString Then
                        item.Selected = True
                    End If
                Next
            Next

            Return View(entityVM)
        End Function

        ' POST: SousRessource/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As SousRessourceViewModel) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(65, 3) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If (IsNothing(entityVM.ActionsId)) Then
                ModelState.AddModelError("ActionsId", Resource.RequiredField)
            End If
            If ModelState.IsValid Then
                Using transaction = Db.Database.BeginTransaction
                    Try
                        Db.Entry(entityVM.GetEntity).State = EntityState.Modified
                        DeleteActionSousRessource(entityVM.Id) 'On supprime les anciens enregistrements dans la table ActionSousRessource
                        AddActionSousRessource(entityVM.ActionsId, entityVM.Id) 'On ajoute les nouvelles références
                        Db.SaveChanges()
                        transaction.Commit()
                        Return RedirectToAction("Index")
                    Catch ex As DbEntityValidationException
                        transaction.Rollback()
                        Util.GetError(ex, ModelState)
                    Catch ex As Exception
                        transaction.Rollback()
                        Util.GetError(ex, ModelState)
                    End Try
                End Using
            End If
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' GET: SousRessource/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(65, 4) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim SousRessource As SousRessource = Db.SousRessource.Find(id)
            If IsNothing(SousRessource) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New SousRessourceViewModel(SousRessource)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: SousRessource/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(65, 4) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            Dim SousRessource As SousRessource = Db.SousRessource.Find(id)
            Db.SousRessource.Remove(SousRessource)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New SousRessourceViewModel(SousRessource))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
