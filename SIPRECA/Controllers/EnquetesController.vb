Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources


Namespace Controllers
    Public Class EnquetesController
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

        ' GET: Enquetes
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.TitreSort = If(sortOrder = "Titre", "Titre_desc", "Titre")
            ViewBag.DescriptionSort = If(sortOrder = "Description", "Description_desc", "Description")
            ViewBag.SinistreSort = If(sortOrder = "Sinistre", "Sinistre_desc", "Sinistre")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.Enquete Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Titre.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Description.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Sinistre.Libelle.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Titre"
                    entities = entities.OrderBy(Function(e) e.Titre)
                Case "Titre_desc"
                    entities = entities.OrderByDescending(Function(e) e.Titre)
                Case "Sinistre"
                    entities = entities.OrderBy(Function(e) e.Sinistre.Libelle)
                Case "Description_desc"
                    entities = entities.OrderByDescending(Function(e) e.Description)
                Case "Description"
                    entities = entities.OrderBy(Function(e) e.Description)
                Case "Sinistre_desc"
                    entities = entities.OrderByDescending(Function(e) e.Sinistre.Libelle)
                Case Else
                    entities = entities.OrderBy(Function(e) e.Titre)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Enquetes/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim enquete As Enquete = db.Enquete.Find(id)
        '    If IsNothing(enquete) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(enquete)
        'End Function

        Public Sub LoadComboBox(entityVM As EnqueteViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            Dim Sinistre = (From e In Db.Sinistre Where e.StatutExistant = 1 Select e)
            Dim LesSinistres As New List(Of SelectListItem)

            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " " & item.Prenom})
                End If
            Next

            For Each item In Sinistre
                LesSinistres.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            entityVM.LesSinistres = LesSinistres
            entityVM.LesUtilisateurs = LesUtilisateurs
        End Sub

        Public Sub LoadComboBoxFormulaire(entityVM As EnqueteViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            Dim Enquete = (From e In Db.Enquete Where e.StatutExistant = 1 And e.Id = entityVM.EnqueteId Select e)
            Dim LesEnquetes As New List(Of SelectListItem)

            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " " & item.Prenom})
                End If
            Next

            For Each item In Enquete
                LesEnquetes.Add(New SelectListItem With {.Value = item.Id, .Text = item.Titre})
            Next

            entityVM.LesEnquetes = LesEnquetes
            entityVM.LesUtilisateurs = LesUtilisateurs
        End Sub

        Public Sub LoadComboBoxSection(entityVM As EnqueteViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            Dim Formulaire = (From e In Db.Formulaire Where e.StatutExistant = 1 And e.Id = entityVM.FormulaireId Select e)
            Dim LesFormulaires As New List(Of SelectListItem)

            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " " & item.Prenom})
                End If
            Next

            For Each item In Formulaire
                LesFormulaires.Add(New SelectListItem With {.Value = item.Id, .Text = item.Titre})
            Next

            entityVM.LesFormulaires = LesFormulaires
            entityVM.LesUtilisateurs = LesUtilisateurs
        End Sub

        Public Sub LoadComboBoxChamps(entityVM As EnqueteViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            Dim Section = (From e In Db.Section Where e.StatutExistant = 1 And e.FormulaireId = entityVM.FormulaireId Select e)
            Dim TypeChamps = (From e In Db.TypeChamps Where e.StatutExistant = 1 Select e)
            Dim LesSections As New List(Of SelectListItem)
            Dim LesTypeChamps As New List(Of SelectListItem)

            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " " & item.Prenom})
                End If
            Next

            For Each item In Section
                LesSections.Add(New SelectListItem With {.Value = item.Id, .Text = item.Titre})
            Next

            For Each item In TypeChamps
                LesTypeChamps.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            entityVM.LesSections = LesSections
            entityVM.LesTypeChamps = LesTypeChamps
            entityVM.LesUtilisateurs = LesUtilisateurs
        End Sub

        ' GET: Enquetes/Create
        Function Create() As ActionResult
            Dim entityVM As New EnqueteViewModel()
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Enquetes/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(entityVM As EnqueteViewModel) As ActionResult

            If IsNothing(entityVM.Titre) Then
                ModelState.AddModelError("Titre", Resource.TheRequiredField)
            End If

            If IsNothing(entityVM.SinistreId) Then
                ModelState.AddModelError("SinistreId", Resource.TheRequiredField)
            End If
            entityVM.AspNetUserId = GetCurrentUser().Id
            If ModelState.IsValid Then
                Dim entity = entityVM.GetEntity()
                Db.Enquete.Add(entity)
                Try
                    Db.SaveChanges()
                    Return RedirectToAction("CreateFromulaire", New With {.EnqueteId = entity.Id})
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try
            End If
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' GET: Enquetes/CreateFromulaire
        Function CreateFromulaire(EnqueteId As Long) As ActionResult
            If IsNothing(EnqueteId) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim enquete As Enquete = Db.Enquete.Find(EnqueteId)
            If IsNothing(enquete) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New EnqueteViewModel With {
                .EnqueteId = enquete.Id
            }
            LoadComboBoxFormulaire(entityVM)
            entityVM.ListeFormulaires = (From e In Db.Formulaire Where e.StatutExistant = 1 And e.EnqueteId = enquete.Id Select e).ToList()
            Return View(entityVM)
        End Function

        ' POST: Enquetes/CreateFromulaire
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function CreateFromulaire(entityVM As EnqueteViewModel, BtnPrevious As String, BtnNext As String) As ActionResult
            If (BtnPrevious IsNot Nothing) Then
                Return RedirectToAction("Edit", New With {.id = entityVM.EnqueteId})
            End If

            If (BtnNext IsNot Nothing) Then
                If IsNothing(entityVM.TitreFormulaire) Then
                    ModelState.AddModelError("TitreFormulaire", Resource.TheRequiredField)
                End If

                If IsNothing(entityVM.EnqueteId) Then
                    ModelState.AddModelError("EnqueteId", Resource.TheRequiredField)
                End If

                entityVM.AspNetUserIdFormulaire = GetCurrentUser().Id
                If ModelState.IsValid Then
                    Dim entity = entityVM.GetEntityFormulaire()
                    Db.Formulaire.Add(entity)
                    Try
                        Db.SaveChanges()
                        Return RedirectToAction("CreateSection", New With {.FormulaireId = entity.Id})
                    Catch ex As DbEntityValidationException
                        Util.GetError(ex, ModelState)
                    Catch ex As Exception
                        Util.GetError(ex, ModelState)
                    End Try
                End If
            End If
            LoadComboBoxFormulaire(entityVM)
            entityVM.ListeFormulaires = (From e In Db.Formulaire Where e.StatutExistant = 1 And e.EnqueteId = entityVM.EnqueteId Select e).ToList()
            Return View(entityVM)
        End Function

        ' GET: Enquetes/CreateSection
        Function CreateSection(FormulaireId As Long) As ActionResult
            If IsNothing(FormulaireId) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim formulaire As Formulaire = Db.Formulaire.Find(FormulaireId)
            If IsNothing(formulaire) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New EnqueteViewModel With {
                .FormulaireId = formulaire.Id
            }
            LoadComboBoxSection(entityVM)
            entityVM.ListeSections = (From e In Db.Section Where e.StatutExistant = 1 And e.FormulaireId = formulaire.Id Select e).ToList()
            Return View(entityVM)
        End Function

        ' POST: Enquetes/CreateFromulaire
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function CreateSection(entityVM As EnqueteViewModel, BtnPrevious As String, BtnNext As String, BtnSave As String) As ActionResult
            If (BtnPrevious IsNot Nothing) Then
                Return RedirectToAction("EditFormulaire", New With {.IdFormulaire = entityVM.FormulaireId})
            End If

            If (BtnNext IsNot Nothing) Then
                Return RedirectToAction("CreateChamps", New With {entityVM.FormulaireId})
            End If

            If (BtnSave IsNot Nothing) Then

                If IsNothing(entityVM.TitreSection) Then
                    ModelState.AddModelError("TitreSection", Resource.TheRequiredField)
                End If

                If IsNothing(entityVM.FormulaireId) Then
                    ModelState.AddModelError("FormulaireId", Resource.TheRequiredField)
                End If

                entityVM.AspNetUserIdSection = GetCurrentUser().Id
                If ModelState.IsValid Then
                    Dim entity = entityVM.GetEntitySection()
                    Db.Section.Add(entity)
                    Try
                        Db.SaveChanges()
                        Return RedirectToAction("CreateSection", New With {entity.FormulaireId})
                    Catch ex As DbEntityValidationException
                        Util.GetError(ex, ModelState)
                    Catch ex As Exception
                        Util.GetError(ex, ModelState)
                    End Try
                End If
            End If
            LoadComboBoxSection(entityVM)
            entityVM.ListeSections = (From e In Db.Section Where e.StatutExistant = 1 And e.FormulaireId = entityVM.FormulaireId Select e).ToList()
            Return View(entityVM)
        End Function

        ' GET: Enquetes/CreateChamps
        Function CreateChamps(FormulaireId As Long) As ActionResult
            If IsNothing(FormulaireId) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim formulaire As Formulaire = Db.Formulaire.Find(FormulaireId)
            If IsNothing(formulaire) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New EnqueteViewModel With {
                .FormulaireId = formulaire.Id
            }
            LoadComboBoxChamps(entityVM)
            ViewBag.FormulaireId = formulaire.Id
            entityVM.ListeChamps = (From e In Db.Champs Where e.StatutExistant = 1 And e.Section.FormulaireId = formulaire.Id Select e Order By e.SectionId).ToList()
            Return View(entityVM)
        End Function

        ' POST: Enquetes/CreateChamps
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <ValidateAntiForgeryToken()>
        <HttpPost()>
        Function CreateChamps(entityVM As EnqueteViewModel, BtnPrevious As String, BtnSave As String) As ActionResult
            If (BtnPrevious IsNot Nothing) Then
                Return RedirectToAction("CreateSection", New With {entityVM.FormulaireId})
            End If

            'If (BtnNext IsNot Nothing) Then
            '    ViewBag.FormulaireId = entityVM.FormulaireId
            '    Return RedirectToAction("CreateChamps", New With {.FormulaireId = entityVM.FormulaireId})
            'End If

            If (BtnSave IsNot Nothing) Then

                If IsNothing(entityVM.TitreChamps) Then
                    ModelState.AddModelError("TitreChamps", Resource.TheRequiredField)
                End If

                If IsNothing(entityVM.SectionId) Then
                    ModelState.AddModelError("SectionId", Resource.TheRequiredField)
                End If


                entityVM.AspNetUserIdChamps = GetCurrentUser().Id
                If ModelState.IsValid Then
                    Dim entity = entityVM.GetEntityChamps()
                    Db.Champs.Add(entity)
                    Try
                        Db.SaveChanges()
                        ViewBag.FormulaireId = entityVM.FormulaireId
                        Return RedirectToAction("CreateChamps", New With {entityVM.FormulaireId})
                    Catch ex As DbEntityValidationException
                        Util.GetError(ex, ModelState)
                    Catch ex As Exception
                        Util.GetError(ex, ModelState)
                    End Try
                End If
            End If
            LoadComboBoxChamps(entityVM)
            entityVM.ListeChamps = (From e In Db.Champs Where e.StatutExistant = 1 And e.Section.FormulaireId = entityVM.FormulaireId Select e Order By e.SectionId).ToList()
            Return View(entityVM)
        End Function

        '<ValidateAntiForgeryToken()>
        <HttpPost()>
        Function CreatePoposition(ByVal Libelle As String, ChampsId As Long) As ActionResult

            If (IsNothing(Libelle)) Then
                ModelState.AddModelError("Libelle", Resource.TheRequiredField)
            End If
            If (IsNothing(ChampsId)) Then
                ModelState.AddModelError("ChampsId", Resource.TheRequiredField)
            End If
            If ModelState.IsValid Then
                Dim proposition As New Proposition With {
                    .ChampsId = ChampsId,
                    .Libelle = Libelle
                }

                Db.Proposition.Add(proposition)
                Try
                    Db.SaveChanges()
                    Return Json(New With {.Result = "OK"})
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try
            End If
            'LoadComboBox(entityVM)
            Return Json(New With {.Result = "Error"})
            'Return View(entityVM)
        End Function

        ' GET: Enquetes/EditFormulaire/5
        Function EditFormulaire(ByVal IdFormulaire As Long?) As ActionResult
            If IsNothing(IdFormulaire) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim formulaire As Formulaire = Db.Formulaire.Find(IdFormulaire)
            If IsNothing(formulaire) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New EnqueteViewModel(formulaire)
            LoadComboBoxFormulaire(entityVM)
            entityVM.ListeFormulaires = (From e In Db.Formulaire Where e.StatutExistant = 1 And e.EnqueteId = entityVM.EnqueteId Select e).ToList()
            Return View(entityVM)
        End Function

        ' POST: Enquetes/EditFormulaire/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function EditFormulaire(entityVM As EnqueteViewModel, BtnPrevious As String, BtnNext As String) As ActionResult

            If (BtnPrevious IsNot Nothing) Then
                Return RedirectToAction("Edit", New With {.id = entityVM.EnqueteId})
            End If

            If (BtnNext IsNot Nothing) Then
                If String.IsNullOrEmpty(entityVM.TitreFormulaire) Then
                    ModelState.AddModelError("TitreFormulaire", Resource.TheRequiredField)
                End If

                If entityVM.EnqueteId <= 0 Or IsNothing(entityVM.EnqueteId) Then
                    ModelState.AddModelError("EnqueteId", Resource.TheRequiredField)
                End If

                If ModelState.IsValid Then
                    Dim entity = entityVM.GetEntityFormulaire()
                    Db.Entry(entity).State = EntityState.Modified
                    Try
                        Db.SaveChanges()
                        Return RedirectToAction("CreateSection", New With {.FormulaireId = entity.Id})
                    Catch ex As DbEntityValidationException
                        Util.GetError(ex, ModelState)
                    Catch ex As Exception
                        Util.GetError(ex, ModelState)
                    End Try
                End If
            End If
            LoadComboBoxFormulaire(entityVM)
            entityVM.ListeFormulaires = (From e In Db.Formulaire Where e.StatutExistant = 1 And e.EnqueteId = entityVM.EnqueteId Select e).ToList()
            Return View(entityVM)
        End Function


        ' GET: Enquetes/EditSection/5
        Function EditSection(ByVal IdSection As Long?) As ActionResult
            If IsNothing(IdSection) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim section As Section = Db.Section.Find(IdSection)
            If IsNothing(section) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New EnqueteViewModel(section)
            LoadComboBoxSection(entityVM)
            entityVM.ListeSections = (From e In Db.Section Where e.StatutExistant = 1 And e.FormulaireId = entityVM.FormulaireId Select e).ToList()
            Return View(entityVM)
        End Function

        ' POST: Enquetes/EditSection/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function EditSection(entityVM As EnqueteViewModel, BtnPrevious As String, BtnNext As String, BtnSave As String) As ActionResult

            If (BtnPrevious IsNot Nothing) Then
                Return RedirectToAction("EditFormulaire", New With {.IdFormulaire = entityVM.FormulaireId})
            End If

            If (BtnNext IsNot Nothing) Then
                Return RedirectToAction("CreateChamps", New With {entityVM.FormulaireId})
            End If

            If (BtnSave IsNot Nothing) Then

                If String.IsNullOrEmpty(entityVM.TitreSection) Then
                    ModelState.AddModelError("TitreSection", Resource.TheRequiredField)
                End If

                If entityVM.FormulaireId <= 0 Or IsNothing(entityVM.FormulaireId) Then
                    ModelState.AddModelError("FormulaireId", Resource.TheRequiredField)
                End If

                If ModelState.IsValid Then
                    Dim entity = entityVM.GetEntitySection()
                    Db.Entry(entity).State = EntityState.Modified
                    Try
                        Db.SaveChanges()
                        Return RedirectToAction("CreateSection", New With {.FormulaireId = entity.FormulaireId})
                    Catch ex As DbEntityValidationException
                        Util.GetError(ex, ModelState)
                    Catch ex As Exception
                        Util.GetError(ex, ModelState)
                    End Try
                End If
            End If
            LoadComboBox(entityVM)
            entityVM.ListeSections = (From e In Db.Section Where e.StatutExistant = 1 And e.FormulaireId = entityVM.FormulaireId Select e).ToList()
            Return View(entityVM)
        End Function

        ' GET: Enquetes/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim enquete As Enquete = Db.Enquete.Find(id)
            If IsNothing(enquete) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New EnqueteViewModel(enquete)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Enquetes/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(entityVM As EnqueteViewModel) As ActionResult
            If ModelState.IsValid Then
                Dim entity = entityVM.GetEntity()
                Db.Entry(entity).State = EntityState.Modified
                Try
                    Db.SaveChanges()
                    Return RedirectToAction("CreateFromulaire", New With {.EnqueteId = entity.Id})
                    'Return RedirectToAction("Index")
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try
            End If
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' GET: Enquetes/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim enquete As Enquete = Db.Enquete.Find(id)
            If IsNothing(enquete) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New EnqueteViewModel(enquete)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Enquetes/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim enquete As Enquete = Db.Enquete.Find(id)
            Db.Enquete.Remove(enquete)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New EnqueteViewModel(enquete))
        End Function

        <HttpPost>
        Public Function DeleteFormulaire(ByVal id As Long?) As JsonResult
            If IsNothing(id) Then
                Response.StatusCode = CType(HttpStatusCode.BadRequest, Integer)
                Return Json(New With {.Result = "Error"})
            End If
            Try
                Dim formulaire = Db.Formulaire.Find(id)
                If formulaire Is Nothing Then
                    Response.StatusCode = CType(HttpStatusCode.NotFound, Integer)
                    Return Json(New With {.Result = "Error"})
                End If
                Dim LesSections = (From e In Db.Section Where e.FormulaireId = formulaire.Id Select e).ToList()

                Dim LesChamps As New List(Of Champs)
                For Each section In LesSections
                    Dim tempo = (From champ In Db.Champs Where champ.SectionId = section.Id Select champ).ToList()
                    LesChamps.AddRange(tempo)
                Next

                Dim LesPropositions As New List(Of Proposition)
                For Each champ In LesChamps
                    Dim tempo = (From prop In Db.Proposition Where prop.ChampsId = champ.Id Select prop).ToList()
                    LesPropositions.AddRange(tempo)
                Next

                Db.Proposition.RemoveRange(LesPropositions)
                Db.Champs.RemoveRange(LesChamps)
                Db.Section.RemoveRange(LesSections)
                Db.Formulaire.Remove(formulaire)
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

        <HttpPost>
        Public Function DeleteSection(ByVal id As Long?) As JsonResult
            If IsNothing(id) Then
                Response.StatusCode = CType(HttpStatusCode.BadRequest, Integer)
                Return Json(New With {.Result = "Error"})
            End If
            Try
                Dim section = Db.Section.Find(id)
                If section Is Nothing Then
                    Response.StatusCode = CType(HttpStatusCode.NotFound, Integer)
                    Return Json(New With {.Result = "Error"})
                End If
                Dim LesChamps = (From e In Db.Champs Where e.SectionId = section.Id Select e).ToList()
                Dim LesPropositions As New List(Of Proposition)
                For Each champ In LesChamps
                    Dim tempo = (From prop In Db.Proposition Where prop.ChampsId = champ.Id Select prop).ToList()
                    LesPropositions.AddRange(tempo)
                Next

                Db.Proposition.RemoveRange(LesPropositions)
                Db.Champs.RemoveRange(LesChamps)
                Db.Section.Remove(section)
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


        <HttpPost>
        Public Function DeleteChamps(ByVal id As Long?) As JsonResult
            If IsNothing(id) Then
                Response.StatusCode = CType(HttpStatusCode.BadRequest, Integer)
                Return Json(New With {.Result = "Error"})
            End If
            Try
                Dim Champs = Db.Champs.Find(id)
                If Champs Is Nothing Then
                    Response.StatusCode = CType(HttpStatusCode.NotFound, Integer)
                    Return Json(New With {.Result = "Error"})
                End If
                Dim LesPropositions = (From e In Db.Proposition Where e.ChampsId = Champs.Id Select e).ToList()
                Db.Proposition.RemoveRange(LesPropositions)
                Db.Champs.Remove(Champs)
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


        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
