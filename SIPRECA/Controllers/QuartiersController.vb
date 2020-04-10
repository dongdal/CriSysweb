Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources

Namespace Controllers
    Public Class QuartiersController
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

        <HttpPost()>
        Public Function LoadQuartiers(ListOfCommunes As List(Of Integer)) As ActionResult
            Dim results As New List(Of SelectListItem)
            For Each item In ListOfCommunes
                Dim LesQuartiers = (From e In Db.Quartier Where e.StatutExistant = 1 And e.CommuneId = item Select New SelectListItem With {.Value = e.Id, .Text = e.Libelle})
                results.AddRange(LesQuartiers)
            Next
            results.Sort(Function(a, b) a.Text < b.Text)
            Return Json(results, JsonRequestBehavior.AllowGet)
        End Function

        ' GET: Quartier
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            If AppSession.ListActionSousRessource.Contains(9, 2) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            ViewBag.CurrentSort = sortOrder
            ViewBag.LibelleSort = If(sortOrder = "Libelle", "Libelle_desc", "Libelle")
            ViewBag.CodeSort = If(sortOrder = "Code", "Code_desc", "Code")
            ViewBag.CommuneSort = If(sortOrder = "Commune", "Commune_desc", "Commune")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")
            ViewBag.SuperficieSort = If(sortOrder = "Superficie", "Superficie_desc", "Superficie")
            ViewBag.SuperficieSortSort = If(sortOrder = "Population", "Population_desc", "Population")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.Quartier Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or e.Commune.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or
                                                                                                                                                    e.Code.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Libelle"
                    entities = entities.OrderBy(Function(e) e.Libelle)
                Case "Libelle_desc"
                    entities = entities.OrderByDescending(Function(e) e.Libelle)

                Case "Commune"
                    entities = entities.OrderBy(Function(e) e.Commune.Libelle)
                Case "Commune_desc"
                    entities = entities.OrderByDescending(Function(e) e.Commune.Libelle)

                Case "Code"
                    entities = entities.OrderBy(Function(e) e.Code)
                Case "Code_desc"
                    entities = entities.OrderByDescending(Function(e) e.Code)

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

        ' GET: Quartier/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim Quartier As Quartier = Db.Quartier.Find(id)
        '    If IsNothing(Quartier) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(Quartier)
        'End Function

        Private Sub LoadComboBox(entityVM As QuartierViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            Dim Commune = (From e In Db.Commune Where e.StatutExistant = 1 Select e)
            Dim LesCommunes As New List(Of SelectListItem)
            For Each item In Commune
                LesCommunes.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            entityVM.LesCommunes = LesCommunes
            entityVM.LesUtilisateurs = LesUtilisateurs
        End Sub

        ' GET: Quartier/Create
        Function Create() As ActionResult
            If AppSession.ListActionSousRessource.Contains(9, 1) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            Dim entityVM As New QuartierViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Quartier/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As QuartierViewModel) As ActionResult
            If AppSession.ListActionSousRessource.Contains(9, 1) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            entityVM.AspNetUserId = GetCurrentUser.Id
            If ModelState.IsValid Then
                Db.Quartier.Add(entityVM.GetEntity)
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

        ' GET: Quartier/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If AppSession.ListActionSousRessource.Contains(9, 3) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Quartier As Quartier = Db.Quartier.Find(id)
            If IsNothing(Quartier) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New QuartierViewModel(Quartier)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Quartier/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As QuartierViewModel) As ActionResult
            If AppSession.ListActionSousRessource.Contains(9, 3) Then
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

        ' GET: Quartier/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If AppSession.ListActionSousRessource.Contains(9, 4) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Quartier As Quartier = Db.Quartier.Find(id)
            If IsNothing(Quartier) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New QuartierViewModel(Quartier)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Quartier/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            If AppSession.ListActionSousRessource.Contains(9, 4) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            Dim Quartier As Quartier = Db.Quartier.Find(id)
            Db.Quartier.Remove(Quartier)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New QuartierViewModel(Quartier))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
