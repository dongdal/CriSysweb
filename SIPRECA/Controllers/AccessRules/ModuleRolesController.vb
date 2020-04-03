Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList

Namespace Controllers
    Public Class ModuleRolesController
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

        ' GET: ModuleRole
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.RoleSort = If(sortOrder = "Role", "Role_desc", "Role")
            ViewBag.ModuleSort = If(sortOrder = "Module", "Module_desc", "Module")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.ModuleRole Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.AspNetRoles.Name.ToUpper.Contains(value:=searchString.ToUpper) Or e.Modules.Libelle.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Module"
                    entities = entities.OrderBy(Function(e) e.Modules.Libelle)
                Case "Module_desc"
                    entities = entities.OrderByDescending(Function(e) e.Modules.Libelle)

                Case "Role"
                    entities = entities.OrderBy(Function(e) e.AspNetRoles.Name)
                Case "Role_desc"
                    entities = entities.OrderByDescending(Function(e) e.AspNetRoles.Name)

                Case Else
                    entities = entities.OrderBy(Function(e) e.Modules.Libelle)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: ModuleRole/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim ModuleRole As ModuleRole = Db.ModuleRole.Find(id)
        '    If IsNothing(ModuleRole) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(ModuleRole)
        'End Function

        Private Sub LoadComboBox(entityVM As ModuleRoleViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            Dim Modules = (From e In Db.Modules Where e.StatutExistant = 1 Select e)
            Dim LesModules As New List(Of SelectListItem)
            For Each item In Modules
                LesModules.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            Dim Roles = (From e In Db.Roles Select e)
            Dim LesRoles As New List(Of SelectListItem)
            For Each item In Roles
                LesRoles.Add(New SelectListItem With {.Value = item.Id, .Text = item.Name})
            Next

            entityVM.LesModules = LesModules
            entityVM.LesRoles = LesRoles
            entityVM.LesUtilisateurs = LesUtilisateurs
        End Sub

        ' GET: ModuleRole/Create
        Function Create() As ActionResult
            Dim entityVM As New ModuleRoleViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: ModuleRole/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As ModuleRoleViewModel) As ActionResult
            entityVM.AspNetUserId = GetCurrentUser.Id
            If ModelState.IsValid Then
                For Each item In entityVM.ModulesId
                    Dim ModuleRole As New ModuleRole With {
                    .AspNetRolesId = entityVM.AspNetRolesId,
                    .AspNetUserId = entityVM.AspNetUserId,
                    .ModulesId = item,
                    .DateCreation = Now,
                    .Id = entityVM.Id,
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
                Return RedirectToAction("Index")
            End If
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' GET: ModuleRole/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ModuleRole As ModuleRole = Db.ModuleRole.Find(id)
            If IsNothing(ModuleRole) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New ModuleRoleViewModel(ModuleRole)
            LoadComboBox(entityVM)

            entityVM.ModulesId = (From modRol In Db.ModuleRole Where modRol.Id = id Select modRol.ModulesId).ToList()
            For Each IdModule In entityVM.ModulesId
                For Each item In entityVM.LesModules
                    If item.Value = IdModule.ToString Then
                        item.Selected = True
                    End If
                Next
            Next

            Return View(entityVM)
        End Function

        ' POST: ModuleRole/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As ModuleRoleViewModel) As ActionResult
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

        ' GET: ModuleRole/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ModuleRole As ModuleRole = Db.ModuleRole.Find(id)
            If IsNothing(ModuleRole) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New ModuleRoleViewModel(ModuleRole)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: ModuleRole/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim ModuleRole As ModuleRole = Db.ModuleRole.Find(id)
            Db.ModuleRole.Remove(ModuleRole)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New ModuleRoleViewModel(ModuleRole))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
