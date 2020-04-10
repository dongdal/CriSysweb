Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources

Namespace Controllers
    Public Class BordereauTransfertsController
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

        ' GET: BordereauTransfert
        Function IndexDemandes(sortOrder As String, currentFilter As String, searchString As String, page As Integer?, CommuneId As Long?, DepartementId As Long?, RegionId As Long?) As ActionResult
            If AppSession.ListActionSousRessource.Contains(15, 2) Then
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
            'ViewBag.EtatAvancement = EtatAvancement

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities As IQueryable(Of Demande)

            If AppSession.Niveau.Equals(Util.UserLevel.Communal) Then

                entities = (From e In Db.Demande Where e.CollectiviteSinistree.AnneeBudgetaireId = AppSession.AnneeBudgetaire.Id And
                                                     e.CollectiviteSinistree.CommuneId = AppSession.CommuneId And e.StatutExistant > 0 And e.StatutExistant < CType(Util.ElementsSuiviDemandes.TransfertCommunal, Integer) Select e)

            ElseIf AppSession.Niveau.Equals(Util.UserLevel.Departemental) Then

                entities = (From e In Db.Demande Where e.CollectiviteSinistree.AnneeBudgetaireId = AppSession.AnneeBudgetaire.Id And
                                                         e.StatutExistant >= CType(Util.ElementsSuiviDemandes.TransfertCommunal, Integer) And
                                                     e.StatutExistant < CType(Util.ElementsSuiviDemandes.TransfertDepartemental, Integer) And
                                                     (e.CollectiviteSinistree.Commune.DepartementId = AppSession.DepartementId Or e.AspNetUser.DepartementId = AppSession.DepartementId Or
                                                         e.AspNetUser.Commune.DepartementId = AppSession.DepartementId) Select e)

                If (CommuneId.HasValue) Then
                    entities = FiltrerDemandeCommunale(entities, CommuneId.Value)
                End If
            ElseIf AppSession.Niveau.Equals(Util.UserLevel.Regional) Then

                entities = (From e In Db.Demande Where e.CollectiviteSinistree.AnneeBudgetaireId = AppSession.AnneeBudgetaire.Id And
                                                           e.StatutExistant >= CType(Util.ElementsSuiviDemandes.TransfertDepartemental, Integer) And
                                                           e.StatutExistant < CType(Util.ElementsSuiviDemandes.TransfertRegional, Integer) And
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

                entities = (From e In Db.Demande Where e.CollectiviteSinistree.AnneeBudgetaireId = AppSession.AnneeBudgetaire.Id And e.StatutExistant = 1000 Select e) 'On ne sélectionne rien
                'If (RegionId.HasValue) Then
                '    entities = FiltrerDemandeRegionale(entities, RegionId.Value)
                'End If
                'If (DepartementId.HasValue) Then
                '    entities = FiltrerDemandeDepartementale(entities, DepartementId.Value)
                'End If
                'If (CommuneId.HasValue) Then
                '    entities = FiltrerDemandeCommunale(entities, CommuneId.Value)
                'End If
            End If

            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.CollectiviteSinistree.Sinistre.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or e.Reference.ToUpper.Contains(value:=searchString.ToUpper) Or
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
                    entities = entities.OrderBy(Function(e) e.CollectiviteSinistree.Sinistre.Libelle)
                Case "CollectiviteSinistree_desc"
                    entities = entities.OrderByDescending(Function(e) e.CollectiviteSinistree.Sinistre.Libelle)
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

        ' GET: BordereauTransfert
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            If AppSession.ListActionSousRessource.Contains(16, 2) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            ViewBag.CurrentSort = sortOrder
            ViewBag.LibelleSort = If(sortOrder = "Libelle", "Libelle_desc", "Libelle")
            ViewBag.DateTransfertSort = If(sortOrder = "DateTransfert", "DateTransfertdesc", "DateTransfert")
            ViewBag.NumeroBordereauSort = If(sortOrder = "NumeroBordereau", "NumeroBordereau_desc", "NumeroBordereau")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.BordereauTransfert Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.NumeroBordereau.ToUpper.Contains(value:=searchString.ToUpper) Or e.Libelle.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Libelle"
                    entities = entities.OrderBy(Function(e) e.Libelle)
                Case "Libelle_desc"

                    entities = entities.OrderByDescending(Function(e) e.Libelle)
                Case "NumeroBordereau"
                    entities = entities.OrderBy(Function(e) e.NumeroBordereau)
                Case "NumeroBordereau_desc"
                    entities = entities.OrderByDescending(Function(e) e.NumeroBordereau)
                Case "DateTransfert"
                    entities = entities.OrderBy(Function(e) e.DateTransfert)
                Case "DateTransfert_desc"
                    entities = entities.OrderByDescending(Function(e) e.DateTransfert)

                Case Else
                    entities = entities.OrderByDescending(Function(e) e.DateCreation)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        Private Sub LoadComboBox(entityVM As BordereauTransfertViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next
            entityVM.LesUtilisateurs = LesUtilisateurs
        End Sub

        ' GET: BordereauTransfert/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim anneeBudgetaire As AnneeBudgetaire = Db.BordereauTransfert.Find(id)
        '    If IsNothing(anneeBudgetaire) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(anneeBudgetaire)
        'End Function

        ' GET: BordereauTransfert/Create
        Function Create() As ActionResult
            If AppSession.ListActionSousRessource.Contains(15, 1) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            Dim entityVM As New BordereauTransfertViewModel
            LoadComboBox(entityVM)
            Return View()
        End Function


        ' POST: BordereauTransfert/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(formCollection As FormCollection) As ActionResult
            If AppSession.ListActionSousRessource.Contains(15, 1) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            Dim ListDemande As String() = formCollection("TransfertItem").Split(New Char() {","c})
            If ModelState.IsValid Then

                Dim BordereauTransfert As New BordereauTransfert With {
                        .StatutExistant = 1,
                        .DateCreation = Now,
                        .DateTransfert = Now,
                        .AspNetUserId = GetCurrentUser().Id,
                        .Libelle = Resource.LibelleBordereauTransfert,
                        .NumeroBordereau = Util.GetNumeroBordereau()
                        }
                Db.BordereauTransfert.Add(BordereauTransfert)
                Try
                    Db.SaveChanges()
                    TempData("BordereauId") = BordereauTransfert.Id
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try

                Dim typeSuivi = (From p In Db.TypeSuivi Where p.Id = 1 Select p).ToList

                For Each DemandeId As String In ListDemande
                    Dim Demande = (From p In Db.Demande Where p.Id = DemandeId Select p).ToList.FirstOrDefault

                    Dim Suivi = New Suivi With {
                    .StatutExistant = 1,
                    .DemandeId = DemandeId,
                    .AspNetUserId = GetCurrentUser.Id
                }
                    If AppSession.Niveau.Equals(Util.UserLevel.Communal) Then
                        Suivi.TypeSuiviId = typeSuivi.Where(Function(e) e.Libelle.ToLower.Contains("Communal".ToLower)).FirstOrDefault.Id
                        Suivi.Libelle = "Transfert du dossier de la commune vers le département"
                        Demande.StatutExistant = Util.ElementsSuiviDemandes.TransfertCommunal
                    ElseIf AppSession.Niveau.Equals(Util.UserLevel.Departemental) Then
                        Suivi.TypeSuiviId = typeSuivi.Where(Function(e) e.Libelle.ToLower.Contains("Départemental".ToLower)).FirstOrDefault.Id
                        Suivi.Libelle = "Transfert du dossier du département à la région"
                        Demande.StatutExistant = Util.ElementsSuiviDemandes.TransfertDepartemental
                    ElseIf AppSession.Niveau.Equals(Util.UserLevel.Regional) Then
                        Suivi.TypeSuiviId = typeSuivi.Where(Function(e) e.Libelle.ToLower.Contains("Régional".ToLower)).FirstOrDefault.Id
                        Suivi.Libelle = "Transfert du dossier de la région au ministère"
                        Demande.StatutExistant = Util.ElementsSuiviDemandes.TransfertRegional
                    End If
                    'Remove from database
                    Db.Entry(Demande).State = EntityState.Modified
                    Db.Suivi.Add(Suivi)
                    Try
                        Db.SaveChanges()
                        Dim BordereauTransfertDemande As New BordereauTransfertDemande With {
                            .BordereauTransfertId = BordereauTransfert.Id,
                            .DemandeId = DemandeId,
                            .StatutExistant = 1,
                            .DateCreation = Now
                            }
                        Db.BordereauTransfertDemande.Add(BordereauTransfertDemande)
                        Try
                            Db.SaveChanges()
                        Catch ex As DbEntityValidationException
                            Util.GetError(ex, ModelState)
                        Catch ex As Exception
                            Util.GetError(ex, ModelState)
                        End Try
                    Catch ex As DbEntityValidationException
                        Util.GetError(ex, ModelState)
                    Catch ex As Exception
                        Util.GetError(ex, ModelState)
                    End Try
                Next
                TempData("BordereauId") = BordereauTransfert.Id
                Return RedirectToAction("Index")
            End If
            'LoadComboBox(entityVM)
            Return View()
        End Function


        '' POST: BordereauTransfert/Create
        ''Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        ''plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        '<HttpPost()>
        '<ValidateAntiForgeryToken()>
        'Function Create(ByVal entityVM As BordereauTransfertViewModel) As ActionResult
        '    entityVM.AspNetUserId = GetCurrentUser.Id
        '    If ModelState.IsValid Then
        '        Dim entity = entityVM.GetEntity()
        '        Db.BordereauTransfert.Add(entity)
        '        Try
        '            Db.SaveChanges()
        '            TempData("BordereauId") = entity.Id
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

        ' GET: BordereauTransfert/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If AppSession.ListActionSousRessource.Contains(15, 3) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim bordereautransfert As BordereauTransfert = Db.BordereauTransfert.Find(id)
            If IsNothing(bordereautransfert) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New BordereauTransfertViewModel(bordereautransfert)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: BordereauTransfert/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As BordereauTransfertViewModel) As ActionResult
            If AppSession.ListActionSousRessource.Contains(15, 3) Then
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

        ' GET: BordereauTransfert/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If AppSession.ListActionSousRessource.Contains(15, 4) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim bordereautransfert As BordereauTransfert = Db.BordereauTransfert.Find(id)
            If IsNothing(bordereautransfert) Then
                Return HttpNotFound()
            End If
            Return View(bordereautransfert)
        End Function

        ' POST: BordereauTransfert/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            If AppSession.ListActionSousRessource.Contains(15, 4) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            Dim bordereautransfert As BordereauTransfert = Db.BordereauTransfert.Find(id)
            Db.BordereauTransfert.Remove(bordereautransfert)
            Db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
