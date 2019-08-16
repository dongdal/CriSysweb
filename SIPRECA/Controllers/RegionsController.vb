Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList

Namespace Controllers
    Public Class RegionsController
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


        ' GET: Regions
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.LibelleSort = If(sortOrder = "Libelle", "Libelle_desc", "Libelle")
            ViewBag.ChefLieuSort = If(sortOrder = "ChefLieu", "ChefLieu_desc", "ChefLieu")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.SuperficieSort = If(sortOrder = "Superficie", "Superficie_desc", "Superficie")
            ViewBag.SuperficieSortSort = If(sortOrder = "Population", "Population_desc", "Population")
            ViewBag.PopulationSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.Region Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or e.ChefLieu.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Libelle"
                    entities = entities.OrderBy(Function(e) e.Libelle)
                Case "Libelle_desc"
                    entities = entities.OrderByDescending(Function(e) e.Libelle)

                Case "ChefLieu"
                    entities = entities.OrderBy(Function(e) e.ChefLieu)
                Case "ChefLieu_desc"
                    entities = entities.OrderByDescending(Function(e) e.ChefLieu)

                Case "Superficie"
                    entities = entities.OrderBy(Function(e) e.Superficie)
                Case "Superficie_desc"
                    entities = entities.OrderByDescending(Function(e) e.Superficie)

                Case "Population"
                    entities = entities.OrderBy(Function(e) e.Population)
                Case "Population_desc"
                    entities = entities.OrderByDescending(Function(e) e.Population)

                Case Else
                    entities = entities.OrderBy(Function(e) e.Libelle)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Regions/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim region As Region = db.Collectivite.Find(id)
        '    If IsNothing(region) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(region)
        'End Function

        Private Sub LoadComboBox(entityVM As RegionViewModel)
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

        ' GET: Regions/Create
        Function Create() As ActionResult
            Dim entityVM As New RegionViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Regions/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As RegionViewModel) As ActionResult
            entityVM.AspNetUserId = GetCurrentUser.Id
            If ModelState.IsValid Then
                Db.Region.Add(entityVM.GetEntity)
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

        ' GET: Regions/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim region As Region = Db.Region.Find(id)
            If IsNothing(region) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New RegionViewModel(region)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Regions/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As RegionViewModel) As ActionResult
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

        ' GET: Regions/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim region As Region = Db.Region.Find(id)
            If IsNothing(region) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New RegionViewModel(region)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Regions/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim region As Region = Db.Region.Find(id)
            Db.Region.Remove(region)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New RegionViewModel(region))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
