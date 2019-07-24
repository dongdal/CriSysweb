Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList

Namespace Controllers
    Public Class IndemmisationsController
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

        ' GET: Indemmisation
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.MontantSort = If(sortOrder = "Montant", "Montant_desc", "Montant")
            ViewBag.CollectiviteSort = If(sortOrder = "Collectivite", "Collectivite_desc", "Collectivite")
            ViewBag.DemandeSort = If(sortOrder = "Demande", "Demande_desc", "Demande")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.Indemmisation Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Collectivite.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or e.Demande.Reference.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Montant"
                    entities = entities.OrderBy(Function(e) e.Montant)
                Case "Montant_desc"
                    entities = entities.OrderByDescending(Function(e) e.Montant)
                Case "Collectivite"
                    entities = entities.OrderBy(Function(e) e.Collectivite.Libelle)
                Case "Collectivite_desc"
                    entities = entities.OrderByDescending(Function(e) e.Collectivite.Libelle)
                Case "Demande"
                    entities = entities.OrderBy(Function(e) e.Demande.Reference)
                Case "Demande_desc"
                    entities = entities.OrderByDescending(Function(e) e.Demande.Reference)

                Case Else
                    entities = entities.OrderBy(Function(e) e.Montant)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Indemmisation/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim Indemmisation As Indemmisation = Db.Indemmisation.Find(id)
        '    If IsNothing(Indemmisation) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(Indemmisation)
        'End Function

        Private Sub LoadComboBox(entityVM As IndemmisationViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            Dim Collectivite = (From e In Db.Collectivite Where e.StatutExistant = 1 Select e)
            Dim Collectivites As New List(Of SelectListItem)
            For Each item In Collectivite
                Collectivites.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            Dim Demande = (From e In Db.Demande Where e.StatutExistant = 1 Select e)
            Dim Demandes As New List(Of SelectListItem)
            For Each item In Demande
                Demandes.Add(New SelectListItem With {.Value = item.Id, .Text = item.Reference})
            Next

            entityVM.Demandes = Demandes
            entityVM.Collectivies = Collectivites
            entityVM.LesUtilisateurs = LesUtilisateurs
        End Sub

        ' GET: Indemmisation/Create
        Function Create() As ActionResult
            Dim entityVM As New IndemmisationViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Indemmisation/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As IndemmisationViewModel) As ActionResult
            entityVM.AspNetUserId = GetCurrentUser.Id
            If ModelState.IsValid Then
                Db.Indemmisation.Add(entityVM.GetEntity)
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

        ' GET: Indemmisation/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Indemmisation As Indemmisation = Db.Indemmisation.Find(id)
            If IsNothing(Indemmisation) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New IndemmisationViewModel(Indemmisation)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Indemmisation/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As IndemmisationViewModel) As ActionResult
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

        ' GET: Indemmisation/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Indemmisation As Indemmisation = Db.Indemmisation.Find(id)
            If IsNothing(Indemmisation) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New IndemmisationViewModel(Indemmisation)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Indemmisation/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim Indemmisation As Indemmisation = Db.Indemmisation.Find(id)
            Db.Indemmisation.Remove(Indemmisation)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New IndemmisationViewModel(Indemmisation))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
