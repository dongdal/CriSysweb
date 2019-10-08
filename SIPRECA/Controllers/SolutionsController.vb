Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList

Namespace Controllers
    Public Class SolutionsController
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

        ' GET: Solution
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.LibelleSort = If(sortOrder = "Libelle", "Libelle_desc", "Libelle")
            ViewBag.TypeSolutionSort = If(sortOrder = "TypeSolution", "TypeSolution_desc", "TypeSolution")
            ViewBag.EvenementSort = If(sortOrder = "EvenementZone", "EvenementZone_desc", "EvenementZone")
            ViewBag.DescriptionSort = If(sortOrder = "Description", "Description_desc", "Description")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.Solution Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.EvenementZone.Evenement.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.TypeSolution.Libelle.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Libelle"
                    entities = entities.OrderBy(Function(e) e.Libelle)
                Case "Libelle_desc"
                    entities = entities.OrderByDescending(Function(e) e.Libelle)
                Case "TypeSolution"
                    entities = entities.OrderBy(Function(e) e.TypeSolution.Libelle)
                Case "TypeSolution_desc"
                    entities = entities.OrderByDescending(Function(e) e.TypeSolution.Libelle)
                Case "EvenementZone"
                    entities = entities.OrderBy(Function(e) e.EvenementZone.Evenement.Libelle)
                Case "EvenementZone_desc"
                    entities = entities.OrderByDescending(Function(e) e.EvenementZone.Evenement.Libelle)
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

        ' GET: Solution/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim Solution As Solution = Db.Solution.Find(id)
        '    If IsNothing(Solution) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(Solution)
        'End Function

        Private Sub LoadComboBox(entityVM As SolutionViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)

            Dim TypeSolutions = (From e In Db.TypeSolution Where e.StatutExistant = 1 Select e)
            Dim LesTypeSolutions As New List(Of SelectListItem)

            Dim EvenementZones = (From e In Db.EvenementZone Where e.StatutExistant = 1 Select e)
            Dim LesEvenementZones As New List(Of SelectListItem)

            For Each item In EvenementZones
                LesEvenementZones.Add(New SelectListItem With {.Value = item.Id, .Text = item.Evenement.Libelle})
            Next

            For Each item In TypeSolutions
                LesTypeSolutions.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            entityVM.LesUtilisateurs = LesUtilisateurs
            entityVM.LesEvenementZones = LesEvenementZones
            entityVM.LesTypeSolutions = LesTypeSolutions
        End Sub

        ' GET: Solution/Create
        Function Create() As ActionResult
            Dim entityVM As New SolutionViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Solution/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As SolutionViewModel) As ActionResult
            entityVM.AspNetUserId = GetCurrentUser.Id
            If ModelState.IsValid Then
                Db.Solution.Add(entityVM.GetEntity)
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

        ' GET: Solution/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Solution As Solution = Db.Solution.Find(id)
            If IsNothing(Solution) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New SolutionViewModel(Solution)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Solution/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As SolutionViewModel) As ActionResult
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

        ' GET: Solution/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Solution As Solution = Db.Solution.Find(id)
            If IsNothing(Solution) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New SolutionViewModel(Solution)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Solution/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim Solution As Solution = Db.Solution.Find(id)
            Db.Solution.Remove(Solution)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New SolutionViewModel(Solution))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
