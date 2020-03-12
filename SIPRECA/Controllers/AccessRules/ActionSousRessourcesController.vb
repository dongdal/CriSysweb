Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList

Namespace Controllers
    Public Class ActionSousRessourcesController
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

        ' GET: ActionSousRessource
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.ActionsSort = If(sortOrder = "Actions", "Actions_desc", "Actions")
            ViewBag.SousResourceSort = If(sortOrder = "SousResource", "SousResource_desc", "SousResource")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.ActionSousRessource Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Actions.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or e.Actions.Description.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.SousRessource.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or e.SousRessource.Description.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Actions"
                    entities = entities.OrderBy(Function(e) e.Actions.Libelle)
                Case "Actions_desc"
                    entities = entities.OrderByDescending(Function(e) e.Actions.Libelle)

                Case "SousResource"
                    entities = entities.OrderBy(Function(e) e.SousRessource.Libelle)
                Case "SousResource_desc"
                    entities = entities.OrderByDescending(Function(e) e.SousRessource.Libelle)

                Case Else
                    entities = entities.OrderBy(Function(e) e.Actions.Libelle)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: ActionSousRessource/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim ActionSousRessource As ActionSousRessource = Db.ActionSousRessource.Find(id)
        '    If IsNothing(ActionSousRessource) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(ActionSousRessource)
        'End Function

        Private Sub LoadComboBox(entityVM As ActionSousRessourceViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            Dim Actions = (From e In Db.Actions Where e.StatutExistant = 1 Select e)
            Dim LesActions As New List(Of SelectListItem)
            For Each item In Actions
                LesActions.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            Dim SousRessource = (From e In Db.SousRessource Where e.StatutExistant = 1 Select e)
            Dim LesSousRessources As New List(Of SelectListItem)
            For Each item In SousRessource
                LesSousRessources.Add(New SelectListItem With {.Value = item.Ressource.Modules.Libelle & " -> " & item.Ressource.Libelle & " -> " & item.Id, .Text = item.Libelle})
            Next

            entityVM.LesActions = LesActions
            entityVM.LesSousRessources = LesSousRessources
            entityVM.LesUtilisateurs = LesUtilisateurs
        End Sub

        ' GET: ActionSousRessource/Create
        Function Create() As ActionResult
            Dim entityVM As New ActionSousRessourceViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: ActionSousRessource/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As ActionSousRessourceViewModel) As ActionResult
            entityVM.AspNetUserId = GetCurrentUser.Id
            If ModelState.IsValid Then
                Db.ActionSousRessource.Add(entityVM.GetEntity)
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

        ' GET: ActionSousRessource/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ActionSousRessource As ActionSousRessource = Db.ActionSousRessource.Find(id)
            If IsNothing(ActionSousRessource) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New ActionSousRessourceViewModel(ActionSousRessource)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: ActionSousRessource/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As ActionSousRessourceViewModel) As ActionResult
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

        ' GET: ActionSousRessource/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ActionSousRessource As ActionSousRessource = Db.ActionSousRessource.Find(id)
            If IsNothing(ActionSousRessource) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New ActionSousRessourceViewModel(ActionSousRessource)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: ActionSousRessource/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim ActionSousRessource As ActionSousRessource = Db.ActionSousRessource.Find(id)
            Db.ActionSousRessource.Remove(ActionSousRessource)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New ActionSousRessourceViewModel(ActionSousRessource))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
