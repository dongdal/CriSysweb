Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList

Namespace Controllers
    Public Class SuivisController
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

        ' GET: Suivi
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.LibelleSort = If(sortOrder = "Libelle", "Libelle_desc", "Libelle")
            ViewBag.DemandeSort = If(sortOrder = "Demande", "Demande_desc", "Demande")
            ViewBag.TypeSuiviSort = If(sortOrder = "TypeSuivi", "TypeSuivi_desc", "TypeSuivi")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.Suivi Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or e.Demande.Reference.ToUpper.Contains(value:=searchString.ToUpper) Or e.TypeSuivi.Libelle.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Libelle"
                    entities = entities.OrderBy(Function(e) e.Libelle)
                Case "Libelle_desc"
                    entities = entities.OrderByDescending(Function(e) e.Libelle)
                Case "Demande"
                    entities = entities.OrderBy(Function(e) e.Demande.Reference)
                Case "Demande_desc"
                    entities = entities.OrderByDescending(Function(e) e.Demande.Reference)
                Case "TypeSuivi"
                    entities = entities.OrderBy(Function(e) e.TypeSuivi.Libelle)
                Case "TypeSuivi_desc"
                    entities = entities.OrderByDescending(Function(e) e.TypeSuivi.Libelle)

                Case Else
                    entities = entities.OrderBy(Function(e) e.Libelle)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Suivi/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim Suivi As Suivi = Db.Suivi.Find(id)
        '    If IsNothing(Suivi) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(Suivi)
        'End Function

        Private Sub LoadComboBox(entityVM As SuiviViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            Dim Demande = (From e In Db.Demande Where e.StatutExistant = 1 Select e)
            Dim Demandes As New List(Of SelectListItem)
            For Each item In Demande
                Demandes.Add(New SelectListItem With {.Value = item.Id, .Text = item.Reference})
            Next

            Dim TypeSuivi = (From e In Db.TypeSuivi Where e.StatutExistant = 1 Select e)
            Dim TypeSuivis As New List(Of SelectListItem)
            For Each item In TypeSuivi
                TypeSuivis.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            entityVM.Demandes = Demandes
            entityVM.TypeSuivis = TypeSuivis
            entityVM.LesUtilisateurs = LesUtilisateurs
        End Sub

        ' GET: Suivi/Create
        Function Create() As ActionResult
            Dim entityVM As New SuiviViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Suivi/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As SuiviViewModel) As ActionResult
            entityVM.AspNetUserId = GetCurrentUser.Id
            If ModelState.IsValid Then
                Db.Suivi.Add(entityVM.GetEntity)
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

        ' GET: Suivi/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Suivi As Suivi = Db.Suivi.Find(id)
            If IsNothing(Suivi) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New SuiviViewModel(Suivi)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Suivi/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As SuiviViewModel) As ActionResult
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

        ' GET: Suivi/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Suivi As Suivi = Db.Suivi.Find(id)
            If IsNothing(Suivi) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New SuiviViewModel(Suivi)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Suivi/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim Suivi As Suivi = Db.Suivi.Find(id)
            Db.Suivi.Remove(Suivi)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New SuiviViewModel(Suivi))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
