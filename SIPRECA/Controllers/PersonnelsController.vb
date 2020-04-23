Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources

Namespace Controllers
    Public Class PersonnelsController
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

        ' GET: Personnel
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(22, 2) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            ViewBag.CurrentSort = sortOrder
            ViewBag.NomSort = If(sortOrder = "Nom", "Nom_desc", "Nom")
            ViewBag.PrenomSort = If(sortOrder = "Prenom", "Prenom_desc", "Prenom")
            ViewBag.TelephoneSort = If(sortOrder = "Telephone", "Telephone_desc", "Telephone")
            ViewBag.SexeSort = If(sortOrder = "Sexe", "Sexe_desc", "Sexe")
            ViewBag.EmailSort = If(sortOrder = "Email", "Email_desc", "Email")
            ViewBag.CniSort = If(sortOrder = "Cni", "Cni_desc", "Cni")
            ViewBag.TypePersonnelSort = If(sortOrder = "TypePersonnel", "TypePersonnel_desc", "TypePersonnel")
            ViewBag.OrganisationSort = If(sortOrder = "Organisation", "Organisation_desc", "Organisation")
            ViewBag.LieuNaissanceSort = If(sortOrder = "LieuNaissance", "LieuNaissance_desc", "LieuNaissance")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.Personnel Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Cni.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Email.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Telephone.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Sexe.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Nom"
                    entities = entities.OrderBy(Function(e) e.Nom)
                Case "Nom_desc"
                    entities = entities.OrderByDescending(Function(e) e.Prenom)
                Case "Prenom"
                    entities = entities.OrderBy(Function(e) e.Nom)
                Case "Prenom_desc"
                    entities = entities.OrderByDescending(Function(e) e.Prenom)
                Case "Telephone"
                    entities = entities.OrderBy(Function(e) e.Telephone)
                Case "Telephone_desc"
                    entities = entities.OrderByDescending(Function(e) e.Telephone)
                Case "Sexe"
                    entities = entities.OrderBy(Function(e) e.Sexe)
                Case "Sexe_desc"
                    entities = entities.OrderByDescending(Function(e) e.Sexe)
                Case "Email"
                    entities = entities.OrderBy(Function(e) e.Email)
                Case "Email_desc"
                    entities = entities.OrderByDescending(Function(e) e.Email)
                Case "Cni"
                    entities = entities.OrderBy(Function(e) e.Cni)
                Case "Cni_desc"
                    entities = entities.OrderByDescending(Function(e) e.Cni)
                Case "LieuNaissance"
                    entities = entities.OrderBy(Function(e) e.LieuNaissance)
                Case "LieuNaissance_desc"
                    entities = entities.OrderByDescending(Function(e) e.LieuNaissance)
                Case "TypePersonnel"
                    entities = entities.OrderBy(Function(e) e.TypePersonnel.Libelle)
                Case "TypePersonnel_desc"
                    entities = entities.OrderByDescending(Function(e) e.TypePersonnel.Libelle)
                Case "Organisation"
                    entities = entities.OrderBy(Function(e) e.Oganisation.Nom)
                Case "Organisation_desc"
                    entities = entities.OrderByDescending(Function(e) e.Oganisation.Nom)

                Case Else
                    entities = entities.OrderBy(Function(e) e.Nom)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Personnel/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim Personnel As Personnel = Db.Personnel.Find(id)
        '    If IsNothing(Personnel) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(Personnel)
        'End Function

        Private Sub LoadComboBox(entityVM As PersonnelViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            Dim TypePersonnel = (From e In Db.TypePersonnel Where e.StatutExistant = 1 Select e)
            Dim LesTypePersonnels As New List(Of SelectListItem)
            Dim Organisation = (From e In Db.Organisation Where e.StatutExistant = 1 Select e)
            Dim LesOrganisations As New List(Of SelectListItem)
            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            For Each item In TypePersonnel

                LesTypePersonnels.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})

            Next

            For Each item In Organisation

                LesOrganisations.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})

            Next

            entityVM.LesUtilisateurs = LesUtilisateurs
            entityVM.LesOrganisations = LesOrganisations
            entityVM.LesTypePersonnels = LesTypePersonnels
        End Sub

        ' GET: Personnel/Create
        Function Create() As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(22, 1) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            Dim entityVM As New PersonnelViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Personnel/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As PersonnelViewModel) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(22, 1) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            entityVM.AspNetUserId = GetCurrentUser.Id
            If ModelState.IsValid Then
                Db.Personnel.Add(entityVM.GetEntity)
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

        ' GET: Personnel/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(22, 3) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Personnel As Personnel = Db.Personnel.Find(id)
            If IsNothing(Personnel) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New PersonnelViewModel(Personnel)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Personnel/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As PersonnelViewModel) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(22, 3) Then
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

        ' GET: Personnel/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(22, 4) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Personnel As Personnel = Db.Personnel.Find(id)
            If IsNothing(Personnel) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New PersonnelViewModel(Personnel)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Personnel/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(22, 4) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            Dim Personnel As Personnel = Db.Personnel.Find(id)
            Db.Personnel.Remove(Personnel)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New PersonnelViewModel(Personnel))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
