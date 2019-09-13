Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources

Namespace Controllers
    Public Class ProjetsController
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

        ' GET: Projet
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.NomSort = If(sortOrder = "Nom", "Nom_desc", "Nom")
            ViewBag.ReferenceSort = If(sortOrder = "Reference", "Reference_desc", "Reference")
            ViewBag.DescriptionSort = If(sortOrder = "Description", "Description_desc", "Description")
            ViewBag.BudgetSort = If(sortOrder = "Budget", "Budget_desc", "Budget")
            ViewBag.DateDebutSort = If(sortOrder = "DateDebut", "DateDebut_desc", "DateDebut")
            ViewBag.DateFinSort = If(sortOrder = "DateFin", "DateFin_desc", "DateFin")
            ViewBag.DeviselSort = If(sortOrder = "Devise", "Devise_desc", "Devise")
            ViewBag.OrganisationSort = If(sortOrder = "Organisation", "Organisation_desc", "Organisation")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.Projet Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Reference.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Budget.Equals(searchString) Or
                                              e.Oganisation.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Devise.Libelle.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Nom"
                    entities = entities.OrderBy(Function(e) e.Nom)
                Case "Nom_desc"
                    entities = entities.OrderByDescending(Function(e) e.Nom)
                Case "Reference"
                    entities = entities.OrderBy(Function(e) e.Reference)
                Case "Reference_desc"
                    entities = entities.OrderByDescending(Function(e) e.Reference)
                Case "Budget"
                    entities = entities.OrderBy(Function(e) e.Budget)
                Case "Budget_desc"
                    entities = entities.OrderByDescending(Function(e) e.Budget)
                Case "DateDebut"
                    entities = entities.OrderBy(Function(e) e.DateDebut)
                Case "DateDebut_desc"
                    entities = entities.OrderByDescending(Function(e) e.DateDebut)
                Case "DateFin"
                    entities = entities.OrderBy(Function(e) e.DateFin)
                Case "DateFin_desc"
                    entities = entities.OrderByDescending(Function(e) e.DateFin)
                Case "Devise"
                    entities = entities.OrderBy(Function(e) e.Devise.Libelle)
                Case "Devise_desc"
                    entities = entities.OrderByDescending(Function(e) e.Devise.Libelle)
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

        ' GET: Projet/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim Projet As Projet = Db.Projet.Find(id)
        '    If IsNothing(Projet) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(Projet)
        'End Function

        Private Sub LoadComboBox1(entityVM As ProjetViewModel)

            Dim PersonnelProjet = (From e In Db.PersonnelProjet Where e.ProjetId = entityVM.Id Select e.Personnel).ToList
            Dim PersonnelProjets = (From e In Db.Personnel Where e.StatutExistant = 1 Select e)
            Dim LesPersonnelProjets As New List(Of SelectListItem)

            For Each item In PersonnelProjets

                LesPersonnelProjets.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})

            Next

            entityVM.PersonnelProjets = PersonnelProjet
            entityVM.LesPersonnelProjets = LesPersonnelProjets
        End Sub

        Private Sub LoadComboBox(entityVM As ProjetViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            Dim Devise = (From e In Db.Devise Where e.StatutExistant = 1 Select e)
            Dim LesDevises As New List(Of SelectListItem)
            Dim Organisation = (From e In Db.Organisation Where e.StatutExistant = 1 Select e)
            Dim LesOrganisations As New List(Of SelectListItem)


            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            For Each item In Devise

                LesDevises.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})

            Next

            For Each item In Organisation

                LesOrganisations.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})

            Next

            entityVM.LesUtilisateurs = LesUtilisateurs
            entityVM.LesOrganisations = LesOrganisations
            entityVM.LesDevises = LesDevises
        End Sub

        ' GET: Projet/Create
        Function Create() As ActionResult
            Dim entityVM As New ProjetViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Projet/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As ProjetViewModel) As ActionResult
            entityVM.AspNetUserId = GetCurrentUser.Id
            If ModelState.IsValid Then
                Db.Projet.Add(entityVM.GetEntity)
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

        ' GET: Projet/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Projet As Projet = Db.Projet.Find(id)
            If IsNothing(Projet) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New ProjetViewModel(Projet)
            LoadComboBox(entityVM)
            LoadComboBox1(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Projet/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As ProjetViewModel) As ActionResult
            If Request.Form("AddAttachement") IsNot Nothing Then
                Return AddPersonnel(entityVM)
            ElseIf Request.Form("AddAttachement") IsNot Nothing Then
            Else
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
            End If
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        <ValidateAntiForgeryToken()>
        <HttpPost>
        Public Function AddPersonnel(ByVal entityVM As ProjetViewModel) As ActionResult

            If IsNothing(entityVM.PersonnelProjetId) Then
                ModelState.AddModelError("Personnel", Resource.MdlError_Fichier) 'Le champ {0} est obligatoire: veuillez le remplir.
            End If

            If ModelState.IsValid Then

                Dim PersonnelProjet As New PersonnelProjet()

                If entityVM.PersonnelProjetId > 0 Then

                    PersonnelProjet.PersonnelId = entityVM.PersonnelProjetId
                    PersonnelProjet.ProjetId = entityVM.Id

                    Db.PersonnelProjet.Add(PersonnelProjet)
                    Try
                        Db.SaveChanges()
                    Catch ex As DbEntityValidationException
                        Util.GetError(ex, ModelState)
                    Catch ex As Exception
                        Util.GetError(ex, ModelState)
                    End Try

                End If
                Return RedirectToAction("Edit", New With {entityVM.Id})
            End If
            LoadComboBox1(entityVM)
            LoadComboBox(entityVM)
            Return View("Edit", entityVM)
        End Function


        <HttpPost>
        Public Function DeleteFile(id As String) As JsonResult
            If [String].IsNullOrEmpty(id) Then
                Response.StatusCode = CType(HttpStatusCode.BadRequest, Integer)
                Return Json(New With {.Result = "Error"})
            End If
            Try
                Dim PersonnelProjet = (From p In Db.PersonnelProjet Where p.Id = id Select p).ToList.FirstOrDefault
                If PersonnelProjet Is Nothing Then
                    Response.StatusCode = CType(HttpStatusCode.NotFound, Integer)
                    Return Json(New With {.Result = "Error"})
                End If

                Db.PersonnelProjet.Remove(PersonnelProjet)
                Try
                    Db.SaveChanges()
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try

                Return Json(New With {.Result = "OK"})
            Catch ex As Exception
                'Return Json(New With {.Result = "ERROR", .Message = ex.Message})
                Return Json(New With {.Result = "Error"})
            End Try
        End Function

        ' GET: Projet/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Projet As Projet = Db.Projet.Find(id)
            If IsNothing(Projet) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New ProjetViewModel(Projet)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Projet/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim Projet As Projet = Db.Projet.Find(id)
            Db.Projet.Remove(Projet)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New ProjetViewModel(Projet))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
