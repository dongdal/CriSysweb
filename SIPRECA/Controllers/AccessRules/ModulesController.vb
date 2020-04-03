Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources

Namespace Controllers
    Public Class ModulesController
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

        ' GET: Modules
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.LibelleSort = If(sortOrder = "Libelle", "Libelle_desc", "Libelle")
            ViewBag.DescriptionSort = If(sortOrder = "Description", "Description_desc", "Description")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.Modules Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or e.Description.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Libelle"
                    entities = entities.OrderBy(Function(e) e.Libelle)
                Case "Libelle_desc"
                    entities = entities.OrderByDescending(Function(e) e.Libelle)

                Case "Description"
                    entities = entities.OrderBy(Function(e) e.Description)
                Case "Description_desc"
                    entities = entities.OrderByDescending(Function(e) e.Description)

                Case Else
                    entities = entities.OrderBy(Function(e) e.Libelle)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Modules/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim Modules As Modules = Db.Modules.Find(id)
        '    If IsNothing(Modules) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(Modules)
        'End Function

        Private Sub LoadComboBox(entityVM As ModulesViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            Dim AspNetRoles = (From e In Db.Roles Select e)
            Dim LesAspNetRoles As New List(Of SelectListItem)
            For Each item In AspNetRoles
                LesAspNetRoles.Add(New SelectListItem With {.Value = item.Id, .Text = item.Name})
            Next

            entityVM.LesUtilisateurs = LesUtilisateurs
            entityVM.LesAspNetRoles = LesAspNetRoles
        End Sub

        ' GET: Modules/Create
        Function Create() As ActionResult
            Dim entityVM As New ModulesViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Modules/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As ModulesViewModel) As ActionResult
            entityVM.AspNetUserId = GetCurrentUser.Id
            If (IsNothing(entityVM.AspNetRolesId)) Then
                ModelState.AddModelError("AspNetRolesId", Resource.RequiredField)
            End If
            If ModelState.IsValid Then
                Dim entity = entityVM.GetEntity
                Db.Modules.Add(entity)
                Try
                    Db.SaveChanges()
                    AddModuleRole(entityVM.AspNetRolesId, entity.Id)
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

        Private Sub AddModuleRole(ByVal ListRoles As List(Of String), IdModule As Long)
            For Each role In ListRoles
                Dim ModuleRole As New ModuleRole With {
                .AspNetRolesId = role,
                .AspNetUserId = GetCurrentUser().Id,
                .ModulesId = IdModule,
                .DateCreation = Now,
                .StatutExistant = 1
                }
                Db.ModuleRole.Add(ModuleRole)
                Try
                    Db.SaveChanges()
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try
            Next
        End Sub

        ' GET: Modules/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Modules As Modules = Db.Modules.Find(id)
            If IsNothing(Modules) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New ModulesViewModel(Modules)
            LoadComboBox(entityVM)

            entityVM.AspNetRolesId = (From modRol In Db.ModuleRole Where modRol.ModulesId = id Select modRol.AspNetRolesId).ToList()
            For Each IdRole In entityVM.AspNetRolesId
                For Each item In entityVM.LesAspNetRoles
                    If item.Value = IdRole.ToString Then
                        item.Selected = True
                    End If
                Next
            Next

            Return View(entityVM)
        End Function

        ' POST: Modules/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As ModulesViewModel) As ActionResult
            If (IsNothing(entityVM.AspNetRolesId)) Then
                ModelState.AddModelError("AspNetRolesId", Resource.RequiredField)
            End If
            If ModelState.IsValid Then
                Db.Entry(entityVM.GetEntity).State = EntityState.Modified
                Try
                    Db.SaveChanges()
                    DeleteModuleRole(entityVM.Id) 'On supprime les anciens enregistrements dans la table ModuleRole
                    AddModuleRole(entityVM.AspNetRolesId, entityVM.Id) 'On ajoute les nouvelles références
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

        Private Sub DeleteModuleRole(IdModule As Long)
            Dim moduleRole = (From e In Db.ModuleRole Where e.ModulesId = IdModule Select e)
            Db.ModuleRole.RemoveRange(moduleRole)
            Try
                Db.SaveChanges()
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
        End Sub

        ' GET: Modules/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Modules As Modules = Db.Modules.Find(id)
            If IsNothing(Modules) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New ModulesViewModel(Modules)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Modules/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim Modules As Modules = Db.Modules.Find(id)
            Db.Modules.Remove(Modules)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New ModulesViewModel(Modules))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
