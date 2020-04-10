Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources

Namespace Controllers
    Public Class DesagregationRecoltesAgricolesController
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

        ' GET: DesagregationRecoltesAgricole
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            If AppSession.ListActionSousRessource.Contains(46, 2) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            ViewBag.CurrentSort = sortOrder
            ViewBag.LibellleSort = If(sortOrder = "Libellle", "Libellle_desc", "Libellle")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.DesagregationRecoltesAgricole Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Libellle.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Libellle"
                    entities = entities.OrderBy(Function(e) e.Libellle)
                Case "Libellle_desc"
                    entities = entities.OrderByDescending(Function(e) e.Libellle)

                Case Else
                    entities = entities.OrderBy(Function(e) e.Libellle)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: DesagregationRecoltesAgricole/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim DesagregationRecoltesAgricole As DesagregationRecoltesAgricole = Db.DesagregationRecoltesAgricole.Find(id)
        '    If IsNothing(DesagregationRecoltesAgricole) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(DesagregationRecoltesAgricole)
        'End Function

        Private Sub LoadComboBox(entityVM As DesagregationRecoltesAgricoleViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            entityVM.LesUtilisateurs = LesUtilisateurs
        End Sub

        ' GET: DesagregationRecoltesAgricole/Create
        Function Create() As ActionResult
            If AppSession.ListActionSousRessource.Contains(46, 1) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            Dim entityVM As New DesagregationRecoltesAgricoleViewModel
            LoadComboBox(entityVM)
            Return View()
        End Function

        ' POST: DesagregationRecoltesAgricole/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As DesagregationRecoltesAgricoleViewModel) As ActionResult
            If AppSession.ListActionSousRessource.Contains(46, 1) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            entityVM.AspNetUserId = GetCurrentUser.Id
            If ModelState.IsValid Then
                Db.DesagregationRecoltesAgricole.Add(entityVM.GetEntity)
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

        ' GET: DesagregationRecoltesAgricole/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If AppSession.ListActionSousRessource.Contains(46, 3) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim DesagregationRecoltesAgricole As DesagregationRecoltesAgricole = Db.DesagregationRecoltesAgricole.Find(id)
            If IsNothing(DesagregationRecoltesAgricole) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New DesagregationRecoltesAgricoleViewModel(DesagregationRecoltesAgricole)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: DesagregationRecoltesAgricole/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As DesagregationRecoltesAgricoleViewModel) As ActionResult
            If AppSession.ListActionSousRessource.Contains(46, 3) Then
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

        ' GET: DesagregationRecoltesAgricole/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If AppSession.ListActionSousRessource.Contains(46, 4) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim DesagregationRecoltesAgricole As DesagregationRecoltesAgricole = Db.DesagregationRecoltesAgricole.Find(id)
            If IsNothing(DesagregationRecoltesAgricole) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New DesagregationRecoltesAgricoleViewModel(DesagregationRecoltesAgricole)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: DesagregationRecoltesAgricole/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            If AppSession.ListActionSousRessource.Contains(46, 4) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            Dim DesagregationRecoltesAgricole As DesagregationRecoltesAgricole = Db.DesagregationRecoltesAgricole.Find(id)
            Db.DesagregationRecoltesAgricole.Remove(DesagregationRecoltesAgricole)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New DesagregationRecoltesAgricoleViewModel(DesagregationRecoltesAgricole))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
