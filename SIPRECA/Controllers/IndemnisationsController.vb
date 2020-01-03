Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports System.IO
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources

Namespace Controllers
    Public Class IndemnisationsController
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

        ' GET: Indemnisation
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?, DemandeId As Long?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.LibelleSort = If(sortOrder = "Libelle", "Libelle_desc", "Libelle")
            ViewBag.NatureAideSort = If(sortOrder = "NatureAide", "NatureAide_desc", "NatureAide")
            ViewBag.DemandeSort = If(sortOrder = "Demande", "Demande_desc", "Demande")
            ViewBag.QuantiteSort = If(sortOrder = "Quantite", "Quantite_desc", "Quantite")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.Indemnisation Where e.StatutExistant = 1 And e.Demande.CollectiviteSinistree.AnneeBudgetaireId = AppSession.AnneeBudgetaire.Id Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Demande.Reference.ToUpper.Contains(value:=searchString.ToUpper) Or e.Libelle.ToUpper.Contains(value:=searchString.ToUpper))
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

        ' GET: Indemnisation/Details/5
        Function Details(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                'Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                Return RedirectToAction("Error400", "Home", New With {Resource.SelectedDetailsId, .MyAction = "Index", .Controleur = "Indemnisations"})
            End If
            Dim Indemnisation As Indemnisation = Db.Indemnisation.Find(id)
            If IsNothing(Indemnisation) Then
                'Return HttpNotFound()
                Return RedirectToAction("Error400", "Home", New With {Resource.SelectedDetailsId, .MyAction = "Index", .Controleur = "Indemnisations"})
            End If
            Dim entityVM As New IndemnisationViewModel(Indemnisation)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' GET: Indemnisation/Details/5
        Function DetailIndems(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                'Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                Return RedirectToAction("Error400", "Home", New With {Resource.SelectedDetailsId, .MyAction = "Index", .Controleur = "Indemnisations"})
            End If
            Dim Indemnisation As Indemnisation = Db.Indemnisation.Find(id)
            If IsNothing(Indemnisation) Then
                'Return HttpNotFound()
                Return RedirectToAction("Error400", "Home", New With {Resource.SelectedDetailsId, .MyAction = "Index", .Controleur = "Indemnisations"})
            End If
            Dim entityVM As New IndemnisationViewModel(Indemnisation)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function


        Private Sub LoadComboBox(entityVM As IndemnisationViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " " & item.Prenom})
                End If
            Next

            'Dim NatureAide = (From e In Db.NatureAide Where e.StatutExistant = 1 Select e)
            'Dim LesNatureAides As New List(Of SelectListItem)
            'For Each item In NatureAide
            '    LesNatureAides.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            'Next

            Dim Demandes = (From e In Db.Demande Where e.Id = entityVM.DemandeId Select e).ToList()
            Dim LesDemandes As New List(Of SelectListItem)
            For Each item In Demandes
                LesDemandes.Add(New SelectListItem With {.Value = item.Id, .Text = item.Reference & " | " & item.Sinistrer.Nom, .Selected = True})
            Next


            Dim DetailsIndemnisations = Db.DetailsIndemnisation.ToList
            Dim LesDetailsIndemnisations As New List(Of SelectListItem)
            For Each item In DetailsIndemnisations
                LesDetailsIndemnisations.Add(New SelectListItem With {.Value = item.Id, .Text = item.Indemnisation.Libelle})
            Next
            entityVM.LesDetailsIndemnisations = LesDetailsIndemnisations

            Dim DetailsIndemnisation = (From o In Db.DetailsIndemnisation Where o.IndemnisationId = entityVM.Id Select o).ToList
            entityVM.DetailsIndemnisation = DetailsIndemnisation

            Dim LaNatureAide = (From o In Db.Indemnisation Where o.Id = entityVM.Id From a In o.DetailsIndemnisation Select a.NatureAide).ToList

            entityVM.NatureAide = LaNatureAide

            Dim NatureAides = (From e In Db.NatureAide Where e.StatutExistant = 1 Select e).ToList
            Dim LesNatureAides As New List(Of SelectListItem)
            For Each item In NatureAides
                If Not LaNatureAide.Contains(item) Then
                    LesNatureAides.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
                End If
            Next

            entityVM.LesNatureAides = LesNatureAides
            entityVM.LesDemande = LesDemandes
            entityVM.LesUtilisateurs = LesUtilisateurs
        End Sub

        ' GET: Indemnisation/Create
        Function Create(ByVal DemandeId As Long?) As ActionResult
            If IsNothing(DemandeId) Then
                Return RedirectToAction("Error400", "Home", New With {Resource.SelectDemandeId, .MyAction = "Index", .Controleur = "Demande"})
            End If

            Dim Indemnisation As Indemnisation = Db.Indemnisation.Where(Function(e) e.DemandeId = DemandeId).FirstOrDefault
            If IsNothing(Indemnisation) Then
                Dim entityVM As New IndemnisationViewModel With {
               .DemandeId = DemandeId
                }
                LoadComboBox(entityVM)
                Return View(entityVM)
            Else
                Return RedirectToAction("Edit", New With {Indemnisation.Id})
            End If
        End Function


        ' POST: Indemnisation/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As IndemnisationViewModel) As ActionResult
            entityVM.AspNetUserId = GetCurrentUser.Id
            If ModelState.IsValid Then
                Dim entity = entityVM.GetEntity
                Db.Indemnisation.Add(entity)
                Try
                    Db.SaveChanges()
                    Return RedirectToAction("Edit", New With {entity.Id})
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try
            End If
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' GET: Indemnisation/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Indemnisation As Indemnisation = Db.Indemnisation.Find(id)
            If IsNothing(Indemnisation) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New IndemnisationViewModel(Indemnisation)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Indemnisation/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As IndemnisationViewModel) As ActionResult
            If Request.Form("AddDetailsIndemnisation") IsNot Nothing Then
                Return AddDetailsIndemnisation(entityVM)
            Else
                If ModelState.IsValid Then
                    Db.Entry(entityVM.GetEntity).State = EntityState.Modified
                    Try
                        Db.SaveChanges()
                        ViewBag.DetailsIndemnisation = entityVM.Id
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


        ' GET: Indemnisation/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Indemnisation As Indemnisation = Db.Indemnisation.Find(id)
            If IsNothing(Indemnisation) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New IndemnisationViewModel(Indemnisation)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Indemnisation/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim Indemnisation As Indemnisation = Db.Indemnisation.Find(id)
            Db.Indemnisation.Remove(Indemnisation)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New IndemnisationViewModel(Indemnisation))
        End Function


        Private Function AddDetailsIndemnisation(ByVal entityVM As IndemnisationViewModel) As ActionResult
            'If entityVM.MedicamentId Is Nothing Then
            '    ModelState.AddModelError("MedicamentId", Resource.MdlStatError_MedicamentId) 'Veuillez Ajouter un Medicament SVP !
            'End If
            Dim Quantite = 0.0
            Double.TryParse(entityVM.Quantite.Replace(".", ","), Quantite)
            If Quantite <= 0.0 Then
                ModelState.AddModelError("Quantite", Resource.MdlStatError_Quantite)
            End If
            If entityVM.NatureAideId = 0 Then
                ModelState.AddModelError("NatureAideId", Resource.MdlStatError_NatureAide) 'Veuillez Ajouter une Posologie SVP !
            End If

            If ModelState.IsValid Then
                Dim DetailsIndemnisation As New DetailsIndemnisation With {
                    .IndemnisationId = entityVM.Id,
                    .NatureAideId = entityVM.NatureAideId,
                    .Quantite = Quantite,
                    .Description = entityVM.DescriptionAide,
                    .DateCreation = entityVM.DateCreation,
                    .AspNetUserId = GetCurrentUser.Id,
                    .StatutExistant = entityVM.StatutExistant
                    }
                Db.DetailsIndemnisation.Add(DetailsIndemnisation)

                Try
                    Db.SaveChanges()

                    Return RedirectToAction("Edit", New With {entityVM.Id})
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try
            End If
            LoadComboBox(entityVM)

            Return View("Edit", entityVM)
        End Function

        Function DeleteDetails(ByVal id As Long?, IndemnisationId As Long) As ActionResult
            If IsNothing(id) Then
                'Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                Return RedirectToAction("Error400", "Home", New With {Resource.SelectedDetailsId, .MyAction = "Index", .Controleur = "Demande"})
            End If
            Dim DetailsIndemnisation = (From o In Db.DetailsIndemnisation
                                        Where o.Id = id And o.IndemnisationId = IndemnisationId Select o).FirstOrDefault

            If IsNothing(DetailsIndemnisation) Then
                Return HttpNotFound()
            End If

            Db.DetailsIndemnisation.Remove(DetailsIndemnisation)
            Try
                Db.SaveChanges()
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return RedirectToAction("Edit", New With {.id = IndemnisationId})
        End Function


        <HttpPost>
        Public Function Indemnisation(DetailsIndemnisationId As Long) As JsonResult
            Dim Msg As String = ""
            If [String].IsNullOrEmpty(DetailsIndemnisationId) Then
                Response.StatusCode = CType(HttpStatusCode.BadRequest, Integer)
                Return Json(New With {.Result = "Error"})
            End If
            Try
                Dim DetailsIndemnisation = (From o In Db.DetailsIndemnisation
                                            Where o.Id = DetailsIndemnisationId Select o).FirstOrDefault

                If Not IsNothing(DetailsIndemnisation) Then
                    'Modified from database
                    DetailsIndemnisation.StatutExistant = Util.ElementsSuiviDemandes.DecisionIndemnisation
                    Db.Entry(DetailsIndemnisation).State = EntityState.Modified
                    Try
                        Db.SaveChanges()
                        Return Json(New With {.Result = "OK"})
                    Catch ex As DbEntityValidationException
                        Util.GetError(ex, ModelState)
                    Catch ex As Exception
                        Util.GetError(ex, ModelState)
                    End Try
                End If
            Catch ex As Exception
                Msg = ex.Message.ToString
            End Try
            Return Json(New With {.Result = "Error"})
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
