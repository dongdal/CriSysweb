Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports System.IO
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources

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

        Private Shared ReadOnly _context As New ApplicationDbContext
        Public Shared ReadOnly Property Context As ApplicationDbContext
            Get
                Return _context
            End Get
        End Property

        <HttpPost()>
        Public Function DepartementParRegion(id_pere As String) As ActionResult
            Dim results = (From depart In Db.Departement Where depart.RegionId = id_pere Select New SelectListItem With {.Value = depart.Id, .Text = depart.Libelle})
            Return Json(results, JsonRequestBehavior.AllowGet)
        End Function

        <HttpPost()>
        Public Function CommuneParDepartement(id_pere As String) As ActionResult
            Dim results = (From com In Db.Commune Where com.DepartementId = id_pere Select New SelectListItem With {.Value = com.Id, .Text = com.Libelle})
            Return Json(results, JsonRequestBehavior.AllowGet)
        End Function

        Private Function GetCurrentUser() As ApplicationUser
            Dim id = User.Identity.GetUserId
            Dim aspuser = Db.Users.Find(id)
            Return aspuser
        End Function

        ' GET: Demande
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?, CommuneId As Long?, DepartementId As Long?, RegionId As Long?, EtatAvancement As String) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(11, 2) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            ViewBag.CurrentSort = sortOrder
            ViewBag.IDSort = If(sortOrder = "Id", "Id_desc", "Id")
            ViewBag.CollectiviteSinistreeSort = If(sortOrder = "CollectiviteSinistree", "CollectiviteSinistree_desc", "CollectiviteSinistree")
            ViewBag.SinistrerSort = If(sortOrder = "Sinistrer", "Sinistrer_desc", "Sinistrer")
            ViewBag.DateDeclarationSort = If(sortOrder = "DateDeclaration", "DateDeclaration_desc", "DateDeclaration")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            ViewBag.PageCommuneId = CommuneId
            ViewBag.PageDepartementId = DepartementId
            ViewBag.PageRegionId = RegionId
            ViewBag.EtatAvancement = EtatAvancement

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities As IQueryable(Of Demande)

            If AppSession.Niveau.Equals(Util.UserLevel.Communal) Then

                entities = (From e In Db.Demande Where e.AnneeBudgetaireId = AppSession.AnneeBudgetaire.Id And
                                                     e.CollectiviteSinistree.CommuneId = AppSession.CommuneId Select e)

            ElseIf AppSession.Niveau.Equals(Util.UserLevel.Departemental) Then

                'entities = (From e In Db.Demande Where e.CollectiviteSinistree.AnneeBudgetaireId = AppSession.AnneeBudgetaire.Id And
                '                                         e.StatutExistant >= 3 Or
                '                                           e.StatutExistant = -2 And
                '                                         (e.AspNetUser.DepartementId = AppSession.DepartementId Or
                '                                         e.AspNetUser.Commune.DepartementId = AppSession.DepartementId) Select e)

                entities = (From e In Db.Demande Where e.AnneeBudgetaireId = AppSession.AnneeBudgetaire.Id And
                                                         e.StatutExistant >= 3 Or
                                                           e.StatutExistant = -2 And
                                                         (e.CollectiviteSinistree.Commune.DepartementId = AppSession.DepartementId Or e.AspNetUser.DepartementId = AppSession.DepartementId Or
                                                         e.AspNetUser.Commune.DepartementId = AppSession.DepartementId) Select e)

                If (CommuneId.HasValue) Then
                    entities = FiltrerDemandeCommunale(entities, CommuneId.Value)
                End If
            ElseIf AppSession.Niveau.Equals(Util.UserLevel.Regional) Then

                entities = (From e In Db.Demande Where e.AnneeBudgetaireId = AppSession.AnneeBudgetaire.Id And
                                                           e.StatutExistant >= 7 Or
                                                           e.StatutExistant = -3 And
                                                           (e.CollectiviteSinistree.Commune.Departement.RegionId = AppSession.RegionId Or e.AspNetUser.RegionId = AppSession.RegionId Or
                                                           e.AspNetUser.Departement.RegionId = AppSession.RegionId Or
                                                           e.AspNetUser.Commune.Departement.RegionId = AppSession.RegionId) Select e)
                If (DepartementId.HasValue) Then
                    entities = FiltrerDemandeDepartementale(entities, DepartementId.Value)
                End If
                If (CommuneId.HasValue) Then
                    entities = FiltrerDemandeCommunale(entities, CommuneId.Value)
                End If
            Else

                entities = (From e In Db.Demande Where e.AnneeBudgetaireId = AppSession.AnneeBudgetaire.Id And
                                                       e.StatutExistant >= 11 Select e)
                If (RegionId.HasValue) Then
                    entities = FiltrerDemandeRegionale(entities, RegionId.Value)
                End If
                If (DepartementId.HasValue) Then
                    entities = FiltrerDemandeDepartementale(entities, DepartementId.Value)
                End If
                If (CommuneId.HasValue) Then
                    entities = FiltrerDemandeCommunale(entities, CommuneId.Value)
                End If
            End If

            entities = FiltrerEtatAvancement(entities, EtatAvancement)

            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.CollectiviteSinistree.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or e.Reference.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Sinistrer.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or e.Sinistrer.Prenom.ToUpper.Contains(value:=searchString.ToUpper))
            End If

            Select Case sortOrder

                Case "Id"
                    entities = entities.OrderBy(Function(e) e.Id)
                Case "Id_desc"
                    entities = entities.OrderByDescending(Function(e) e.Id)
                Case "Sinistrer"
                    entities = entities.OrderBy(Function(e) e.Sinistrer.Nom)
                Case "Sinistrer_desc"
                    entities = entities.OrderByDescending(Function(e) e.Sinistrer.Nom)
                Case "CollectiviteSinistree"
                    entities = entities.OrderBy(Function(e) e.CollectiviteSinistree.Libelle)
                Case "CollectiviteSinistree_desc"
                    entities = entities.OrderByDescending(Function(e) e.CollectiviteSinistree.Libelle)
                Case "DateDeclaration"
                    entities = entities.OrderBy(Function(e) e.DateDeclaration)
                Case "DateDeclaration_desc"
                    entities = entities.OrderByDescending(Function(e) e.DateDeclaration)
                Case Else
                    entities = entities.OrderByDescending(Function(e) e.DateCreation)
                    Exit Select
            End Select


            Dim entitiesCommune = If((AppSession.CommuneId = 0 And AppSession.DepartementId = 0 And AppSession.RegionId = 0),
                                (From e In Db.Commune Order By e.Libelle Select e),
                                (From u In Db.Commune Where (u.Id = AppSession.CommuneId Or u.DepartementId = AppSession.DepartementId Or
                                                          u.Departement.RegionId = AppSession.RegionId) Order By u.Libelle Select u)).ToList

            Dim entitiesDepartement = If((AppSession.CommuneId = 0 And AppSession.DepartementId = 0 And AppSession.RegionId = 0),
                                (From e In Db.Departement Order By e.Libelle Select e),
                                (From u In Db.Departement Where (u.Id = AppSession.DepartementId Or u.RegionId = AppSession.RegionId) Order By u.Libelle Select u)).ToList

            Dim entitiesRegion = If((AppSession.CommuneId = 0 And AppSession.DepartementId = 0 And AppSession.RegionId = 0),
                               (From e In Db.Region Order By e.Libelle Select e),
                               (From u In Db.Region Where (u.Id = AppSession.RegionId) Order By u.Libelle Select u)).ToList


            ViewBag.CommuneIds = LoadCommunes(entitiesCommune)
            ViewBag.DepartementIds = LoadDepartements(entitiesDepartement)
            ViewBag.RegionIds = LoadRegions(entitiesRegion)
            Dim StatutDemande As New List(Of SelectListItem) From {
                New SelectListItem With {.Value = Util.StatutDemande.Approuvee, .Text = Resource.StatutDemande_Approuvee},
                New SelectListItem With {.Value = Util.StatutDemande.EnCours, .Text = Resource.StatutDemande_EnCours},
                New SelectListItem With {.Value = Util.StatutDemande.Rejetee, .Text = Resource.StatutDemande_Rejetee}
            }
            ViewBag.StatutDemande = StatutDemande

            ViewBag.EnregCount = entities.Count
            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        Private Shared Function FiltrerEtatAvancement(entities As IQueryable(Of Demande), EtatAvancement As String) As IQueryable(Of Demande)
            If Not String.IsNullOrEmpty(EtatAvancement) Then
                Select Case EtatAvancement
                    Case Util.StatutDemande.EnCours
                        entities = entities.Where(Function(e) e.StatutExistant > 0 And e.StatutExistant <> 15 And e.StatutExistant <> 16)
                    Case Util.StatutDemande.Rejetee
                        entities = entities.Where(Function(e) e.StatutExistant < 0 Or e.StatutExistant = 15)
                    Case Else
                        entities = entities.Where(Function(e) e.StatutExistant = 16)
                        Exit Select
                End Select
            End If
            Return entities
        End Function

        Private Shared Function FiltrerDemandeCommunale(entities As IQueryable(Of Demande), ElementFiltre As Long) As IQueryable(Of Demande)
            If ElementFiltre > 0 Then
                entities = entities.Where(Function(e) e.CollectiviteSinistree.CommuneId = ElementFiltre)
            End If
            Return entities
        End Function

        Private Shared Function FiltrerDemandeDepartementale(entities As IQueryable(Of Demande), ElementFiltre As Long) As IQueryable(Of Demande)
            If ElementFiltre > 0 Then
                entities = entities.Where(Function(e) e.CollectiviteSinistree.Commune.DepartementId = ElementFiltre Or e.AspNetUser.DepartementId = ElementFiltre Or e.AspNetUser.Commune.DepartementId = ElementFiltre)
            End If
            Return entities
        End Function

        Private Shared Function FiltrerDemandeRegionale(entities As IQueryable(Of Demande), ElementFiltre As Long) As IQueryable(Of Demande)
            If ElementFiltre > 0 Then
                entities = entities.Where(Function(e) e.CollectiviteSinistree.Commune.Departement.RegionId = ElementFiltre Or e.AspNetUser.RegionId = ElementFiltre Or e.AspNetUser.Departement.RegionId = ElementFiltre Or
                                              e.AspNetUser.Commune.Departement.RegionId = ElementFiltre)
            End If
            Return entities
        End Function

        Private Shared Function LoadRegions(Regions As List(Of Region)) As List(Of SelectListItem)
            Dim LesRegions As New List(Of SelectListItem)
            For Each item In Regions
                If (AppSession.RegionId = item.Id) Then
                    LesRegions.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle, .Selected = True})
                Else
                    LesRegions.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
                End If
            Next
            Return LesRegions
        End Function

        Private Shared Function LoadDepartements(Departements As List(Of Departement)) As List(Of SelectListItem)
            Dim LesDepartements As New List(Of SelectListItem)
            For Each item In Departements
                If (AppSession.DepartementId = item.Id) Then
                    LesDepartements.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle, .Selected = True})
                Else
                    LesDepartements.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
                End If
            Next
            Return LesDepartements
        End Function

        Private Shared Function LoadCommunes(Communes As List(Of Commune)) As List(Of SelectListItem)
            Dim LesCommunes As New List(Of SelectListItem)
            For Each item In Communes
                If (AppSession.CommuneId = item.Id) Then
                    LesCommunes.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle, .Selected = True})
                Else
                    LesCommunes.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
                End If
            Next
            Return LesCommunes
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
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " " & item.Prenom})
                End If
            Next
            Dim Piecesjointes = (From e In Db.PieceJointe Where e.StatutExistant = 1 And e.DemandeId = entityVM.Id Select e).ToList()
            Dim CollectiviteSinistree = (From e In Db.CollectiviteSinistree Where e.StatutExistant = 1 And e.AnneeBudgetaireId = AppSession.AnneeBudgetaire.Id Select e).ToList()
            Dim LesCollectiviteSinistrees As New List(Of SelectListItem)
            For Each item In CollectiviteSinistree
                LesCollectiviteSinistrees.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle & " | " & item.Sinistre.Libelle & " | " & item.Commune.Libelle})
            Next

            Dim Sinistrer = (From e In Db.Sinistrer Where e.StatutExistant = 1 Select e)
            Dim LesSinistrers As New List(Of SelectListItem)
            For Each item In Sinistrer
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesSinistrers.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesSinistrers.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " " & item.Prenom})
                End If
            Next

            Dim AnneeBudgetaire = (From e In Db.AnneeBudgetaires Where e.StatutExistant = 1 Select e)
            Dim LesAnneeBudgetaires As New List(Of SelectListItem)
            For Each item In AnneeBudgetaire
                LesAnneeBudgetaires.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            entityVM.LesCollectiviteSinistrees = LesCollectiviteSinistrees
            entityVM.LesAnneeBudgetaires = LesAnneeBudgetaires
            entityVM.PiecesJointes = Piecesjointes
            entityVM.LesSinistrers = LesSinistrers
            entityVM.LesUtilisateurs = LesUtilisateurs
        End Sub

        ' GET: Demande/Create
        Function Create(ByVal id As Long?) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(11, 1) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Sinistre As Sinistrer = Db.Sinistrer.Find(id)

            Dim entityVM As New DemandeViewModel
            entityVM.Sinistrer = Sinistre
            entityVM.SinistrerId = Sinistre.Id
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Demande/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As DemandeViewModel) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(11, 1) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            entityVM.AspNetUserId = GetCurrentUser.Id
            entityVM.AnneeBudgetaireId = AppSession.AnneeBudgetaire.Id

            If ModelState.IsValid Then
                Dim LaCommune = (From e In Db.CollectiviteSinistree Where e.StatutExistant = 1 And e.Id = entityVM.CollectiviteSinistreeId Select e.Commune).FirstOrDefault()

                If (AppSession.Niveau.Equals(1)) Then
                    entityVM.StatutExistant = Util.ElementsSuiviDemandes.CreationCommunal
                ElseIf (AppSession.Niveau.Equals(2)) Then
                    entityVM.StatutExistant = Util.ElementsSuiviDemandes.CreationDepartemental
                ElseIf (AppSession.Niveau.Equals(3)) Then
                    entityVM.StatutExistant = Util.ElementsSuiviDemandes.CreationRegional
                ElseIf (AppSession.Niveau.Equals(4)) Then
                    entityVM.StatutExistant = Util.ElementsSuiviDemandes.CreationNational
                End If
                entityVM.Reference = LaCommune.Code
                Dim entity = entityVM.GetEntity
                Db.Demande.Add(entity)
                Try
                    Db.SaveChanges()
                    If Request.Form("AddPieces") IsNot Nothing Then
                        Return RedirectToAction("EditPieces", "Demandes", New With {.id = entity.Id})
                    Else
                        Return RedirectToAction("Index")
                    End If
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
            If Not AppSession.ListActionSousRessource.Contains(11, 3) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
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

        '' GET: Demande/Tansfert/5
        'Function Tansfert(ByVal DemandeId As Long?) As ActionResult
        '    If IsNothing(DemandeId) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim Demande As Demande = Db.Demande.Find(DemandeId)
        '    If IsNothing(Demande) Then
        '        Return HttpNotFound()
        '    End If
        '    Dim entityVM As New DemandeViewModel(Demande)
        '    LoadComboBox(entityVM)
        '    Return View(entityVM)
        'End Function

        '<HttpPost()>
        '<ValidateAntiForgeryToken()>
        'Function Tansfert(ByVal entityVM As DemandeViewModel) As ActionResult
        '    If ModelState.IsValid Then
        '        Db.Entry(entityVM.GetEntity).State = EntityState.Modified
        '        Try
        '            Db.SaveChanges()
        '            Return RedirectToAction("Index")
        '        Catch ex As DbEntityValidationException
        '            Util.GetError(ex, ModelState)
        '        Catch ex As Exception
        '            Util.GetError(ex, ModelState)
        '        End Try
        '    End If
        '    LoadComboBox(entityVM)
        '    Return View(entityVM)
        'End Function

        ' GET: Demande/Edit/5
        Function EditPieces(ByVal id As Long?) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(11, 3) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
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
            If Not AppSession.ListActionSousRessource.Contains(11, 3) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If Request.Form("AddAttachement") IsNot Nothing Then
                Return UploadFile(entityVM)
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

        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function EditPieces(ByVal entityVM As DemandeViewModel) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(11, 3) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If Request.Form("AddAttachement") IsNot Nothing Then
                Return UploadFileTo(entityVM)
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

        '<HttpPost>
        <ValidateAntiForgeryToken()>
        <HttpPost>
        Public Function UploadFile(ByVal entityVM As DemandeViewModel) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(11, 11) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If

            If IsNothing(entityVM.Fichiers.FirstOrDefault) Then
                ModelState.AddModelError("Fichiers", Resource.MdlError_Fichier) 'Le champ {0} est obligatoire: veuillez le remplir.
            End If

            If ModelState.IsValid Then

                Dim leChemin = Path.Combine(Server.MapPath("~/Upload/Demandes/" & entityVM.Id & "/" & entityVM.Reference))
                Dim RealPath = "/Upload/Demandes/" & entityVM.Id & "/" & entityVM.Reference

                If Not Directory.Exists(leChemin) Then
                    Directory.CreateDirectory(leChemin)
                End If
                Dim piecesjointes As New PieceJointe()
                For Each files In entityVM.Fichiers
                    If files.ContentLength > 0 Then
                        'Checking file is available to save.  
                        Dim fileExtension As String = Path.GetExtension(files.FileName)
                        Dim fileName As String = files.FileName
                        With piecesjointes
                            .DateCreation = Now
                            .StatutExistant = 1
                            .DemandeId = entityVM.Id
                            .Libelle = Now.Date.ToString("dd-MM-yyyy") & "_A_" & Now.Hour & "h" & Now.Minute & "min" & Now.Second & "s" & Now.Millisecond & "ms _" & Path.GetFileName(files.FileName.Replace(" ", "_").ToLower) ' & extension
                            .Lien = RealPath & "/" & .Libelle
                            '.filePath = Path.Combine(leChemin, .Libelle
                            .AspNetUserId = GetCurrentUser.Id
                        End With
                        files.SaveAs(Path.Combine(leChemin, piecesjointes.Libelle))
                        Db.PieceJointe.Add(piecesjointes)
                        Try
                            Db.SaveChanges()
                        Catch ex As DbEntityValidationException
                            Util.GetError(ex, ModelState)
                        Catch ex As Exception
                            Util.GetError(ex, ModelState)
                        End Try

                    End If
                Next
                Return RedirectToAction("Edit", New With {entityVM.Id})
            End If
            LoadComboBox(entityVM)
            Return View("Edit", entityVM)
        End Function

        '<HttpPost>
        <ValidateAntiForgeryToken()>
        <HttpPost>
        Public Function UploadFileTo(ByVal entityVM As DemandeViewModel) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(11, 11) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If

            If IsNothing(entityVM.Fichiers.FirstOrDefault) Then
                ModelState.AddModelError("Fichiers", Resource.MdlError_Fichier) 'Le champ {0} est obligatoire: veuillez le remplir.
            End If

            If ModelState.IsValid Then

                Dim leChemin = Path.Combine(Server.MapPath("~/Upload/Demandes/" & entityVM.Id & "/" & entityVM.Reference))
                Dim RealPath = "/Upload/Demandes/" & entityVM.Id & "/" & entityVM.Reference

                If Not Directory.Exists(leChemin) Then
                    Directory.CreateDirectory(leChemin)
                End If
                Dim piecesjointes As New PieceJointe()
                For Each files In entityVM.Fichiers
                    If files.ContentLength > 0 Then
                        'Checking file is available to save.  
                        Dim fileExtension As String = Path.GetExtension(files.FileName)
                        Dim fileName As String = files.FileName
                        With piecesjointes
                            .DateCreation = Now
                            .StatutExistant = 1
                            .DemandeId = entityVM.Id
                            .Libelle = Now.Date.ToString("dd-MM-yyyy") & "_A_" & Now.Hour & "h" & Now.Minute & "min" & Now.Second & "s" & Now.Millisecond & "ms _" & Path.GetFileName(files.FileName.Replace(" ", "_").ToLower) ' & extension
                            .Lien = RealPath & "/" & .Libelle
                            '.filePath = Path.Combine(leChemin, .Libelle
                            .AspNetUserId = GetCurrentUser.Id
                        End With
                        files.SaveAs(Path.Combine(leChemin, piecesjointes.Libelle))
                        Db.PieceJointe.Add(piecesjointes)
                        Try
                            Db.SaveChanges()
                        Catch ex As DbEntityValidationException
                            Util.GetError(ex, ModelState)
                        Catch ex As Exception
                            Util.GetError(ex, ModelState)
                        End Try

                    End If
                Next
                Return RedirectToAction("EditPieces", New With {entityVM.Id})
            End If
            LoadComboBox(entityVM)
            Return View("EditPieces", entityVM)
        End Function

        <HttpPost>
        Public Function DeleteFile(id As String) As JsonResult
            If Not AppSession.ListActionSousRessource.Contains(11, 12) Then
                Return Json(New With {.Result = "Error"})
            End If
            If [String].IsNullOrEmpty(id) Then
                Response.StatusCode = CType(HttpStatusCode.BadRequest, Integer)
                Return Json(New With {.Result = "Error"})
            End If
            Try
                'Dim guid As New Guid(id)
                Dim piecesjointes = (From p In Db.PieceJointe Where p.Id = id Select p).ToList.FirstOrDefault
                'Dim piecesjointes As PiecesJointes = db.PiecesJointes.Find(id)
                If piecesjointes Is Nothing Then
                    Response.StatusCode = CType(HttpStatusCode.NotFound, Integer)
                    Return Json(New With {.Result = "Error"})
                End If
                Dim leCheminDB = "~" & piecesjointes.Lien
                Dim leFichier = Path.Combine(Server.MapPath(leCheminDB))

                'Delete file from the file system
                If System.IO.File.Exists(leFichier) Then
                    System.IO.File.Delete(leFichier)
                End If

                'Remove from database
                Db.PieceJointe.Remove(piecesjointes)
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

        ' GET: Demande/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(11, 4) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
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
            If Not AppSession.ListActionSousRessource.Contains(11, 4) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
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

        <HttpPost>
        Public Function ConfirmSuivi(id As String, type As String) As JsonResult
            If Not AppSession.ListActionSousRessource.Contains(11, 5) Then
                Return Json(New With {.Result = "Error"})
            End If
            If [String].IsNullOrEmpty(id) Or [String].IsNullOrEmpty(type) Then
                Response.StatusCode = CType(HttpStatusCode.BadRequest, Integer)
                Return Json(New With {.Result = "Error"})
            End If
            Try
                'Dim guid As New Guid(id)
                Dim Demande = (From p In Db.Demande Where p.Id = id Select p).ToList.FirstOrDefault
                Dim typeSuivi = (From p In Db.TypeSuivi Where p.Id = 1 Select p).ToList
                'Dim piecesjointes As PiecesJointes = db.PiecesJointes.Find(id)
                If Demande Is Nothing Then
                    Response.StatusCode = CType(HttpStatusCode.NotFound, Integer)
                    Return Json(New With {.Result = "Error"})
                End If

                Dim Suivi = New Suivi With {
                    .StatutExistant = 1,
                    .DemandeId = Demande.Id,
                    .AspNetUserId = GetCurrentUser.Id
                }

                If (Util.ElementsSuiviDemandes.ValidationCommunal = type) Then
                    Suivi.TypeSuiviId = typeSuivi.Where(Function(e) e.Libelle.ToLower.Contains("Communal".ToLower)).FirstOrDefault.Id
                    Suivi.Libelle = "Validation Communal"
                    Demande.StatutExistant = Util.ElementsSuiviDemandes.ValidationCommunal
                ElseIf (Util.ElementsSuiviDemandes.ValidationDepartemental = type) Then
                    Suivi.TypeSuiviId = typeSuivi.Where(Function(e) e.Libelle.ToLower.Contains("Départemental".ToLower)).FirstOrDefault.Id
                    Suivi.Libelle = "Validation Départemental"
                    Demande.StatutExistant = Util.ElementsSuiviDemandes.ValidationDepartemental
                ElseIf (Util.ElementsSuiviDemandes.ValidationRegional = type) Then
                    Suivi.TypeSuiviId = typeSuivi.Where(Function(e) e.Libelle.ToLower.Contains("Régional".ToLower)).FirstOrDefault.Id
                    Suivi.Libelle = "Validation Régional"
                    Demande.StatutExistant = Util.ElementsSuiviDemandes.ValidationRegional
                ElseIf (Util.ElementsSuiviDemandes.ValidationNational = type) Then
                    Suivi.TypeSuiviId = typeSuivi.Where(Function(e) e.Libelle.ToLower.Contains("National".ToLower)).FirstOrDefault.Id
                    Suivi.Libelle = "Validation National"
                    Demande.StatutExistant = Util.ElementsSuiviDemandes.ValidationNational
                End If

                'Remove from database
                Db.Entry(Demande).State = EntityState.Modified
                Try
                    Db.SaveChanges()
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try

                Db.Suivi.Add(Suivi)
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
        Public Function RejetSuivi(id As String, type As String) As JsonResult
            If Not AppSession.ListActionSousRessource.Contains(11, 7) Then
                Return Json(New With {.Result = "Error"})
            End If
            If [String].IsNullOrEmpty(id) Or [String].IsNullOrEmpty(type) Then
                Response.StatusCode = CType(HttpStatusCode.BadRequest, Integer)
                Return Json(New With {.Result = "Error"})
            End If
            Try
                'Dim guid As New Guid(id)
                Dim Demande = (From p In Db.Demande Where p.Id = id Select p).ToList.FirstOrDefault
                Dim typeSuivi = (From p In Db.TypeSuivi Where p.Id = 1 Select p).ToList
                'Dim piecesjointes As PiecesJointes = db.PiecesJointes.Find(id)
                If Demande Is Nothing Then
                    Response.StatusCode = CType(HttpStatusCode.NotFound, Integer)
                    Return Json(New With {.Result = "Error"})
                End If

                Dim Suivi = New Suivi With {
                    .StatutExistant = 1,
                    .DemandeId = Demande.Id,
                    .AspNetUserId = GetCurrentUser.Id
                }

                If (Util.ElementsSuiviDemandes.RejetCommunal = type) Then
                    Suivi.TypeSuiviId = typeSuivi.Where(Function(e) e.Libelle.ToLower.Contains("Communal".ToLower)).FirstOrDefault.Id
                    Suivi.Libelle = "Rejet Communal"
                    Demande.StatutExistant = Util.ElementsSuiviDemandes.RejetCommunal
                ElseIf (Util.ElementsSuiviDemandes.RejetDepartemental = type) Then
                    Suivi.TypeSuiviId = typeSuivi.Where(Function(e) e.Libelle.ToLower.Contains("Départemental".ToLower)).FirstOrDefault.Id
                    Suivi.Libelle = "Rejet Départemental"
                    Demande.StatutExistant = Util.ElementsSuiviDemandes.RejetDepartemental
                ElseIf (Util.ElementsSuiviDemandes.RejetRegional = type) Then
                    Suivi.TypeSuiviId = typeSuivi.Where(Function(e) e.Libelle.ToLower.Contains("Régional".ToLower)).FirstOrDefault.Id
                    Suivi.Libelle = "Rejet Régional"
                    Demande.StatutExistant = Util.ElementsSuiviDemandes.RejetRegional
                ElseIf (Util.ElementsSuiviDemandes.RejetNational = type) Then
                    Suivi.TypeSuiviId = typeSuivi.Where(Function(e) e.Libelle.ToLower.Contains("National".ToLower)).FirstOrDefault.Id
                    Suivi.Libelle = "Rejet National"
                    Demande.StatutExistant = Util.ElementsSuiviDemandes.RejetNational
                End If

                'Remove from database
                Db.Entry(Demande).State = EntityState.Modified
                Db.Suivi.Add(Suivi)
                Try
                    Db.SaveChanges()
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                    Return Json(New With {.Result = "Error"})
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                    Return Json(New With {.Result = "Error"})
                End Try

                'Try
                '    Db.SaveChanges()
                'Catch ex As DbEntityValidationException
                '    Util.GetError(ex, ModelState)
                'Catch ex As Exception
                '    Util.GetError(ex, ModelState)
                'End Try

                Return Json(New With {.Result = "OK"})
            Catch ex As Exception
                'Return Json(New With {.Result = "ERROR", .Message = ex.Message})
                Return Json(New With {.Result = "Error"})
            End Try
        End Function


        <HttpPost>
        Public Function TransfertSuivi(id As String, type As String) As JsonResult
            If Not AppSession.ListActionSousRessource.Contains(11, 8) Then
                Return Json(New With {.Result = "Error"})
            End If
            If [String].IsNullOrEmpty(id) Or [String].IsNullOrEmpty(type) Then
                Response.StatusCode = CType(HttpStatusCode.BadRequest, Integer)
                Return Json(New With {.Result = "Error"})
            End If
            Try
                'Dim guid As New Guid(id)
                Dim Demande = (From p In Db.Demande Where p.Id = id Select p).ToList.FirstOrDefault
                Dim typeSuivi = (From p In Db.TypeSuivi Where p.Id = 1 Select p).ToList
                'Dim piecesjointes As PiecesJointes = db.PiecesJointes.Find(id)
                If Demande Is Nothing Then
                    Response.StatusCode = CType(HttpStatusCode.NotFound, Integer)
                    Return Json(New With {.Result = "Error"})
                End If

                Dim Suivi = New Suivi With {
                    .StatutExistant = 1,
                    .DemandeId = Demande.Id,
                    .AspNetUserId = GetCurrentUser.Id
                }

                If (Util.ElementsSuiviDemandes.TransfertCommunal = type) Then
                    Suivi.TypeSuiviId = typeSuivi.Where(Function(e) e.Libelle.ToLower.Contains("Communal".ToLower)).FirstOrDefault.Id
                    Suivi.Libelle = "Transfert Communal"
                    Demande.StatutExistant = Util.ElementsSuiviDemandes.TransfertCommunal
                ElseIf (Util.ElementsSuiviDemandes.TransfertDepartemental = type) Then
                    Suivi.TypeSuiviId = typeSuivi.Where(Function(e) e.Libelle.ToLower.Contains("Départemental".ToLower)).FirstOrDefault.Id
                    Suivi.Libelle = "Transfert Départemental"
                    Demande.StatutExistant = Util.ElementsSuiviDemandes.TransfertDepartemental
                ElseIf (Util.ElementsSuiviDemandes.RejetRegional = type) Then
                    Suivi.TypeSuiviId = typeSuivi.Where(Function(e) e.Libelle.ToLower.Contains("Régional".ToLower)).FirstOrDefault.Id
                    Suivi.Libelle = "Transfert Régional"
                    Demande.StatutExistant = Util.ElementsSuiviDemandes.TransfertRegional
                End If

                'Remove from database
                Db.Entry(Demande).State = EntityState.Modified
                Try
                    Db.SaveChanges()
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try

                Db.Suivi.Add(Suivi)
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
        Public Function ReceptionSuivi(id As String, type As String) As JsonResult
            If Not AppSession.ListActionSousRessource.Contains(11, 9) Then
                Return Json(New With {.Result = "Error"})
            End If
            If [String].IsNullOrEmpty(id) Or [String].IsNullOrEmpty(type) Then
                Response.StatusCode = CType(HttpStatusCode.BadRequest, Integer)
                Return Json(New With {.Result = "Error"})
            End If
            Try
                'Dim guid As New Guid(id)
                Dim Demande = (From p In Db.Demande Where p.Id = id Select p).ToList.FirstOrDefault
                Dim typeSuivi = (From p In Db.TypeSuivi Where p.Id = 1 Select p).ToList
                'Dim piecesjointes As PiecesJointes = db.PiecesJointes.Find(id)
                If Demande Is Nothing Then
                    Response.StatusCode = CType(HttpStatusCode.NotFound, Integer)
                    Return Json(New With {.Result = "Error"})
                End If

                Dim Suivi = New Suivi With {
                    .StatutExistant = 1,
                    .DemandeId = Demande.Id,
                    .AspNetUserId = GetCurrentUser.Id
                }

                If (Util.ElementsSuiviDemandes.ReceptionDepartemental = type) Then
                    Suivi.TypeSuiviId = typeSuivi.Where(Function(e) e.Libelle.ToLower.Contains("Départemental".ToLower)).FirstOrDefault.Id
                    Suivi.Libelle = "Reception Départemental"
                    Demande.StatutExistant = Util.ElementsSuiviDemandes.ReceptionDepartemental
                ElseIf (Util.ElementsSuiviDemandes.ReceptionRegionale = type) Then
                    Suivi.TypeSuiviId = typeSuivi.Where(Function(e) e.Libelle.ToLower.Contains("Régional".ToLower)).FirstOrDefault.Id
                    Suivi.Libelle = "Reception Régional"
                    Demande.StatutExistant = Util.ElementsSuiviDemandes.ReceptionRegionale
                ElseIf (Util.ElementsSuiviDemandes.ReceptionNational = type) Then
                    Suivi.TypeSuiviId = typeSuivi.Where(Function(e) e.Libelle.ToLower.Contains("National".ToLower)).FirstOrDefault.Id
                    Suivi.Libelle = "Reception National"
                    Demande.StatutExistant = Util.ElementsSuiviDemandes.ReceptionNational
                End If

                'Remove from database
                Db.Entry(Demande).State = EntityState.Modified
                Try
                    Db.SaveChanges()
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try

                Db.Suivi.Add(Suivi)
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
