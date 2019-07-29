Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList

Namespace Controllers
    Public Class DemandesController
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

        ' GET: Demande
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.ReferenceSort = If(sortOrder = "Reference", "Reference_desc", "Reference")
            ViewBag.CollectiviteSinistreeSort = If(sortOrder = "CollectiviteSinistree", "CollectiviteSinistree_desc", "CollectiviteSinistree")
            ViewBag.SinistrerSort = If(sortOrder = "Sinistrer", "Sinistrer_desc", "Sinistrer")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.Demande Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.CollectiviteSinistree.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or e.Reference.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Sinistrer.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or e.Sinistrer.Prenom.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Reference"
                    entities = entities.OrderBy(Function(e) e.Reference)
                Case "Reference_desc"
                    entities = entities.OrderByDescending(Function(e) e.Reference)
                Case "Sinistrer"
                    entities = entities.OrderBy(Function(e) e.Sinistrer.Nom)
                Case "Sinistrer_desc"
                    entities = entities.OrderByDescending(Function(e) e.Sinistrer.Nom)
                Case "CollectiviteSinistree"
                    entities = entities.OrderBy(Function(e) e.CollectiviteSinistree.Libelle)
                Case "CollectiviteSinistree_desc"
                    entities = entities.OrderByDescending(Function(e) e.CollectiviteSinistree.Libelle)
                Case "DateCreation"
                    entities = entities.OrderBy(Function(e) e.DateCreation)
                Case "DateCreation_desc"
                    entities = entities.OrderByDescending(Function(e) e.DateCreation)

                Case Else
                    entities = entities.OrderByDescending(Function(e) e.DateCreation)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Demande/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim Demande As Demande = Db.Demande.Find(id)
        '    If IsNothing(Demande) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(Demande)
        'End Function

        Private Sub LoadComboBox(entityVM As DemandeViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            Dim CollectiviteSinistree = (From e In Db.CollectiviteSinistree Where e.StatutExistant = 1 And e.AnneeBudgetaireId = AppSession.AnneeBudgetaire.Id Select e)
            Dim LesCollectiviteSinistrees As New List(Of SelectListItem)
            For Each item In CollectiviteSinistree
                LesCollectiviteSinistrees.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle & " | " & item.Sinistre.Libelle & " | " & item.Collectivite.Libelle})
            Next

            Dim Sinistrer = (From e In Db.Sinistrer Where e.StatutExistant = 1 Select e)
            Dim LesSinistrers As New List(Of SelectListItem)
            For Each item In Sinistrer
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            entityVM.LesCollectiviteSinistrees = LesCollectiviteSinistrees
            entityVM.LesSinistrers = LesSinistrers
            entityVM.LesUtilisateurs = LesUtilisateurs
        End Sub

        ' GET: Demande/Create
        Function Create() As ActionResult
            Dim entityVM As New DemandeViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Demande/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As DemandeViewModel) As ActionResult
            entityVM.AspNetUserId = GetCurrentUser.Id
            If ModelState.IsValid Then
                Db.Demande.Add(entityVM.GetEntity)
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

        ' GET: Demande/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Demande As Demande = Db.Demande.Find(id)
            If IsNothing(Demande) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New DemandeViewModel(Demande)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Demande/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As DemandeViewModel) As ActionResult
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

        ' GET: Demande/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Demande As Demande = Db.Demande.Find(id)
            If IsNothing(Demande) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New DemandeViewModel(Demande)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Demande/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim Demande As Demande = Db.Demande.Find(id)
            Db.Demande.Remove(Demande)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New DemandeViewModel(Demande))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
