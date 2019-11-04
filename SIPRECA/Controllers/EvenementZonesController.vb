Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList

Namespace Controllers
    Public Class EvenementZonesController
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

        ' GET: EvenementZone
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.EvenementSort = If(sortOrder = "Evenement", "Evenement_desc", "Evenement")
            ViewBag.ZoneARisqueSort = If(sortOrder = "ZoneARisque", "ZoneARisque_desc", "ZoneARisque")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.EvenementZone Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Evenement.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.ZoneARisque.Libelle.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Evenement"
                    entities = entities.OrderBy(Function(e) e.Evenement.Libelle)
                Case "Evenement_desc"
                    entities = entities.OrderByDescending(Function(e) e.Evenement.Libelle)
                Case "ZoneARisque"
                    entities = entities.OrderBy(Function(e) e.ZoneARisque.Libelle)
                Case "ZoneARisque_desc"
                    entities = entities.OrderByDescending(Function(e) e.ZoneARisque.Libelle)
                Case Else
                    entities = entities.OrderBy(Function(e) e.Evenement.Libelle)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: EvenementZone
        Function QueryResult(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.EvenementSort = If(sortOrder = "Evenement", "Evenement_desc", "Evenement")
            ViewBag.ZoneARisqueSort = If(sortOrder = "ZoneARisque", "ZoneARisque_desc", "ZoneARisque")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")
            'Dim ListEvenementZone = AppSession.ListEvenementZone

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString
            Dim ListEvenementZone As New List(Of EvenementZone)
            For Each item In AppSession.ListEvenementZone
                ListEvenementZone.Add(Db.EvenementZone.Find(item.Id))
            Next

            'ListEvenementZone = ListEvenementZone.Intersect(AppSession.ListEvenementZone).ToList()
            If Not String.IsNullOrEmpty(searchString) Then
                ListEvenementZone = ListEvenementZone.Where(Function(e) e.Evenement.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.ZoneARisque.Libelle.ToUpper.Contains(value:=searchString.ToUpper)).ToList()
            End If
            'ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Evenement"
                    ListEvenementZone = ListEvenementZone.OrderBy(Function(e) e.Evenement.Libelle).ToList()
                Case "Evenement_desc"
                    ListEvenementZone = ListEvenementZone.OrderByDescending(Function(e) e.Evenement.Libelle).ToList()
                Case "ZoneARisque"
                    ListEvenementZone = ListEvenementZone.OrderBy(Function(e) e.ZoneARisque.Libelle).ToList()
                Case "ZoneARisque_desc"
                    ListEvenementZone = ListEvenementZone.OrderByDescending(Function(e) e.ZoneARisque.Libelle).ToList()
                Case Else
                    ListEvenementZone = ListEvenementZone.OrderBy(Function(e) e.Evenement.Libelle).ToList()
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            pageSize = pageSize * 5
            Dim pageNumber As Integer = If(page, 1)

            Return View(ListEvenementZone.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: EvenementZone/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim EvenementZone As EvenementZone = Db.EvenementZone.Find(id)
        '    If IsNothing(EvenementZone) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(EvenementZone)
        'End Function


        Private Sub LoadComboBox(entityVM As EvenementZoneViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)

            Dim Evenement = (From e In Db.Evenement Where e.StatutExistant = 1 Select e)
            Dim LesEvenements As New List(Of SelectListItem)

            Dim ZoneARisque = (From e In Db.ZoneARisque Where e.StatutExistant = 1 Select e).ToList
            Dim LesZoneARisques As New List(Of SelectListItem)



            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            For Each item In Evenement

                LesEvenements.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})

            Next

            For Each item In ZoneARisque

                LesZoneARisques.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})

            Next

            entityVM.LesUtilisateurs = LesUtilisateurs
            entityVM.LesEvenements = LesEvenements
            entityVM.LesZoneARisques = LesZoneARisques
        End Sub

        Private Sub LoadQueryComboBox(entityVM As QueryViewModel)

            Dim Evenement = (From e In Db.Evenement Where e.StatutExistant = 1 Select e)
            Dim LesEvenements As New List(Of SelectListItem)

            Dim Region = (From e In Db.Region Where e.StatutExistant = 1 Select e).ToList
            Dim LesRegions As New List(Of SelectListItem)

            Dim Departement = (From e In Db.Departement Where e.StatutExistant = 1 Select e).ToList
            Dim LesDepartements As New List(Of SelectListItem)

            Dim Commune = (From e In Db.Commune Where e.StatutExistant = 1 Select e).ToList
            Dim LesCommunes As New List(Of SelectListItem)

            Dim Quartier = (From e In Db.Quartier Where e.StatutExistant = 1 Select e).ToList
            Dim LesQuartiers As New List(Of SelectListItem)

            Dim Facteur = (From e In Db.Facteur Where e.StatutExistant = 1 Select e).ToList
            Dim LesFacteurs As New List(Of SelectListItem)

            For Each item In Evenement
                LesEvenements.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In Region
                LesRegions.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In Departement
                LesDepartements.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In Commune
                LesCommunes.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In Quartier
                LesQuartiers.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In Facteur
                LesFacteurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            entityVM.LesEvenements = LesEvenements
            entityVM.LesRegions = LesRegions
            entityVM.LesDepartements = LesDepartements
            entityVM.LesCommunes = LesCommunes
            entityVM.LesQuartiers = LesQuartiers
            entityVM.LesFacteurs = LesFacteurs
        End Sub

        ' GET: EvenementZone/Create
        Function Create() As ActionResult
            Dim entityVM As New EvenementZoneViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: EvenementZone/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As EvenementZoneViewModel) As ActionResult
            entityVM.AspNetUserId = GetCurrentUser.Id
            If ModelState.IsValid Then
                Dim evenementZone = entityVM.GetEntity()
                Db.EvenementZone.Add(evenementZone)
                Try
                    Db.SaveChanges()
                    Dim cardreSendaiCibleA As New CardreSendaiCibleA With {
                        .EvenementZoneId = evenementZone.Id,
                        .AspNetUserId = evenementZone.AspNetUserId
                    }
                    Dim cardreSendaiCibleB As New CardreSendaiCibleB With {
                        .EvenementZoneId = evenementZone.Id,
                        .AspNetUserId = evenementZone.AspNetUserId
                    }
                    Dim cardreSendaiCibleC As New CardreSendaiCibleC With {
                        .EvenementZoneId = evenementZone.Id,
                        .AspNetUserId = evenementZone.AspNetUserId
                    }
                    Dim cardreSendaiCibleD As New CardreSendaiCibleD With {
                        .EvenementZoneId = evenementZone.Id,
                        .AspNetUserId = evenementZone.AspNetUserId
                    }
                    Dim AutreImpactHumainEtEconomique As New AutreImpactHumainEtEconomique With {
                        .EvenementZoneId = evenementZone.Id,
                        .AspNetUserId = evenementZone.AspNetUserId
                    }

                    Db.CardreSendaiCibleA.Add(cardreSendaiCibleA)
                    Db.CardreSendaiCibleB.Add(cardreSendaiCibleB)
                    Db.CardreSendaiCibleC.Add(cardreSendaiCibleC)
                    Db.CardreSendaiCibleD.Add(cardreSendaiCibleD)
                    Db.AutreImpactHumainEtEconomique.Add(AutreImpactHumainEtEconomique)
                    Try
                        Db.SaveChanges()
                        Return RedirectToAction("Index")
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
            End If
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' GET: EvenementZone/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim EvenementZone As EvenementZone = Db.EvenementZone.Find(id)
            If IsNothing(EvenementZone) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New EvenementZoneViewModel(EvenementZone)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: EvenementZone/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As EvenementZoneViewModel) As ActionResult

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

        ' GET: EvenementZone/Query
        Function Query() As ActionResult
            Dim entityVM As New QueryViewModel
            LoadQueryComboBox(entityVM)
            Return View(entityVM)
        End Function

        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Query(ByVal entityVM As QueryViewModel) As ActionResult
            If (ModelState.IsValid) Then
                Dim QueryFieldsResult As New QueryFieldsResult()
                Dim CadreSendaiCibleA = (From e In Db.CardreSendaiCibleA Where e.StatutExistant = 1 Select e)
                Dim CadreSendaiCibleB = (From e In Db.CardreSendaiCibleB Where e.StatutExistant = 1 Select e)
                Dim CadreSendaiCibleC = (From e In Db.CardreSendaiCibleC Where e.StatutExistant = 1 Select e)
                Dim CadreSendaiCibleD = (From e In Db.CardreSendaiCibleD Where e.StatutExistant = 1 Select e)
                Dim AutreImpactHumainEtEconomique = (From e In Db.AutreImpactHumainEtEconomique Where e.StatutExistant = 1 Select e)
                Dim ListEvenementZone As New List(Of EvenementZone)
                'Dim A As Long = 0
                'Dim B As Long = 0
                'Dim C As Long = 0
                'Dim D As Long = 0

                If (entityVM.Deces And entityVM.DecesMAx.HasValue And entityVM.DecesMin.HasValue) Then
                    QueryFieldsResult.Deces = CadreSendaiCibleA.Where(Function(e) (entityVM.DecesMin.Value <= e.NombreTotalDeces.Value And e.NombreTotalDeces.Value <= entityVM.DecesMAx.Value) Or
                                                                    (entityVM.DecesMin.Value <= e.NombreDecesFemme.Value And e.NombreDecesFemme.Value <= entityVM.DecesMAx.Value) Or
                                                                    (entityVM.DecesMin.Value <= e.NombreDecesHomme.Value And e.NombreDecesHomme.Value <= entityVM.DecesMAx.Value) Or
                                                                    (entityVM.DecesMin.Value <= e.NombreDecesEnfant.Value And e.NombreDecesEnfant.Value <= entityVM.DecesMAx.Value) Or
                                                                    (entityVM.DecesMin.Value <= e.NombreDecesAdult.Value And e.NombreDecesAdult.Value <= entityVM.DecesMAx.Value) Or
                                                                    (entityVM.DecesMin.Value <= e.NombreDecesVieux.Value And e.NombreDecesVieux.Value <= entityVM.DecesMAx.Value) Or
                                                                    (entityVM.DecesMin.Value <= e.NombreDecesPauvre.Value And e.NombreDecesPauvre.Value <= entityVM.DecesMAx.Value) Or
                                                                    (entityVM.DecesMin.Value <= e.NombreDecesHandicape.Value And e.NombreDecesHandicape.Value <= entityVM.DecesMAx.Value)).Select(Function(e) e.EvenementZone).ToList()
                End If

                If (entityVM.Blesse And entityVM.BlesseMAx.HasValue And entityVM.BlesseMin.HasValue) Then
                    QueryFieldsResult.Blesses = CadreSendaiCibleB.Where(Function(e) (entityVM.BlesseMin.Value <= e.NombreTotalBlesse.Value And e.NombreTotalBlesse.Value <= entityVM.BlesseMAx.Value) Or
                                                                    (entityVM.BlesseMin.Value <= e.NombreBlesseFemme.Value And e.NombreBlesseFemme.Value <= entityVM.BlesseMAx.Value) Or
                                                                    (entityVM.BlesseMin.Value <= e.NombreBlesseHomme.Value And e.NombreBlesseHomme.Value <= entityVM.BlesseMAx.Value) Or
                                                                    (entityVM.BlesseMin.Value <= e.NombreBlesseEnfant.Value And e.NombreBlesseEnfant.Value <= entityVM.BlesseMAx.Value) Or
                                                                    (entityVM.BlesseMin.Value <= e.NombreBlesseAdult.Value And e.NombreBlesseAdult.Value <= entityVM.BlesseMAx.Value) Or
                                                                    (entityVM.BlesseMin.Value <= e.NombreBlesseVieux.Value And e.NombreBlesseVieux.Value <= entityVM.BlesseMAx.Value) Or
                                                                    (entityVM.BlesseMin.Value <= e.NombreBlessePauvre.Value And e.NombreBlessePauvre.Value <= entityVM.BlesseMAx.Value) Or
                                                                    (entityVM.BlesseMin.Value <= e.NombreBlesseHandicape.Value And e.NombreBlesseHandicape.Value <= entityVM.BlesseMAx.Value)).Select(Function(e) e.EvenementZone).ToList()
                End If

                If (entityVM.MaisonDetruite And entityVM.MaisonDetruiteMAx.HasValue And entityVM.MaisonDetruiteMin.HasValue) Then
                    QueryFieldsResult.MaisonsDetruites = CadreSendaiCibleB.Where(Function(e) (entityVM.MaisonDetruiteMin.Value <= e.NombreTotalMaisonDetruite.Value And e.NombreTotalMaisonDetruite.Value <= entityVM.MaisonDetruiteMAx.Value) Or
                                                                    (entityVM.MaisonDetruiteMin.Value <= e.NombreMaisonDetruiteFemme.Value And e.NombreMaisonDetruiteFemme.Value <= entityVM.MaisonDetruiteMAx.Value) Or
                                                                    (entityVM.MaisonDetruiteMin.Value <= e.NombreMaisonDetruiteHomme.Value And e.NombreMaisonDetruiteHomme.Value <= entityVM.MaisonDetruiteMAx.Value) Or
                                                                    (entityVM.MaisonDetruiteMin.Value <= e.NombreMaisonDetruiteEnfant.Value And e.NombreMaisonDetruiteEnfant.Value <= entityVM.MaisonDetruiteMAx.Value) Or
                                                                    (entityVM.MaisonDetruiteMin.Value <= e.NombreMaisonDetruiteAdult.Value And e.NombreMaisonDetruiteAdult.Value <= entityVM.MaisonDetruiteMAx.Value) Or
                                                                    (entityVM.MaisonDetruiteMin.Value <= e.NombreMaisonDetruiteVieux.Value And e.NombreMaisonDetruiteVieux.Value <= entityVM.MaisonDetruiteMAx.Value) Or
                                                                    (entityVM.MaisonDetruiteMin.Value <= e.NombreMaisonDetruitePauvre.Value And e.NombreMaisonDetruitePauvre.Value <= entityVM.MaisonDetruiteMAx.Value) Or
                                                                    (entityVM.MaisonDetruiteMin.Value <= e.NombreMaisonDetruiteHandicape.Value And e.NombreMaisonDetruiteHandicape.Value <= entityVM.MaisonDetruiteMAx.Value)).Select(Function(e) e.EvenementZone).ToList()
                End If

                If (entityVM.MaisonEndommages And entityVM.MaisonEndommagesMAx.HasValue And entityVM.MaisonEndommagesMin.HasValue) Then
                    QueryFieldsResult.MaisonsEndommagees = CadreSendaiCibleB.Where(Function(e) (entityVM.MaisonEndommagesMin.Value <= e.NombreTotalMaisonEndomage.Value And e.NombreTotalMaisonEndomage.Value <= entityVM.MaisonEndommagesMAx.Value) Or
                                                                    (entityVM.MaisonEndommagesMin.Value <= e.NombreMaisonEndomageFemme.Value And e.NombreMaisonEndomageFemme.Value <= entityVM.MaisonEndommagesMAx.Value) Or
                                                                    (entityVM.MaisonEndommagesMin.Value <= e.NombreMaisonEndomageHomme.Value And e.NombreMaisonEndomageHomme.Value <= entityVM.MaisonEndommagesMAx.Value) Or
                                                                    (entityVM.MaisonEndommagesMin.Value <= e.NombreMaisonEndomageEnfant.Value And e.NombreMaisonEndomageEnfant.Value <= entityVM.MaisonEndommagesMAx.Value) Or
                                                                    (entityVM.MaisonEndommagesMin.Value <= e.NombreMaisonEndomageAdult.Value And e.NombreMaisonEndomageAdult.Value <= entityVM.MaisonEndommagesMAx.Value) Or
                                                                    (entityVM.MaisonEndommagesMin.Value <= e.NombreMaisonEndomageVieux.Value And e.NombreMaisonEndomageVieux.Value <= entityVM.MaisonEndommagesMAx.Value) Or
                                                                    (entityVM.MaisonEndommagesMin.Value <= e.NombreMaisonEndomagePauvre.Value And e.NombreMaisonEndomagePauvre.Value <= entityVM.MaisonEndommagesMAx.Value) Or
                                                                    (entityVM.MaisonEndommagesMin.Value <= e.NombreMaisonEndomageHandicape.Value And e.NombreMaisonEndomageHandicape.Value <= entityVM.MaisonEndommagesMAx.Value)).Select(Function(e) e.EvenementZone).ToList()
                End If

                If (entityVM.Sinistrees And entityVM.SinistreesMAx.HasValue And entityVM.SinistreesMin.HasValue) Then
                    Dim Blesses = CadreSendaiCibleB.Where(Function(e) (entityVM.SinistreesMin.Value <= e.NombreTotalBlesse.Value And e.NombreTotalBlesse.Value <= entityVM.SinistreesMAx.Value) Or
                                                                    (entityVM.SinistreesMin.Value <= e.NombreBlesseFemme.Value And e.NombreBlesseFemme.Value <= entityVM.SinistreesMAx.Value) Or
                                                                    (entityVM.SinistreesMin.Value <= e.NombreBlesseHomme.Value And e.NombreBlesseHomme.Value <= entityVM.SinistreesMAx.Value) Or
                                                                    (entityVM.SinistreesMin.Value <= e.NombreBlesseEnfant.Value And e.NombreBlesseEnfant.Value <= entityVM.SinistreesMAx.Value) Or
                                                                    (entityVM.SinistreesMin.Value <= e.NombreBlesseAdult.Value And e.NombreBlesseAdult.Value <= entityVM.SinistreesMAx.Value) Or
                                                                    (entityVM.SinistreesMin.Value <= e.NombreBlesseVieux.Value And e.NombreBlesseVieux.Value <= entityVM.SinistreesMAx.Value) Or
                                                                    (entityVM.SinistreesMin.Value <= e.NombreBlessePauvre.Value And e.NombreBlessePauvre.Value <= entityVM.SinistreesMAx.Value) Or
                                                                    (entityVM.SinistreesMin.Value <= e.NombreBlesseHandicape.Value And e.NombreBlesseHandicape.Value <= entityVM.SinistreesMAx.Value)).Select(Function(e) e.EvenementZone).ToList()

                    Dim PersonnesLogementsEndommages = CadreSendaiCibleB.Where(Function(e) (entityVM.SinistreesMin.Value <= e.NombreTotalPersonneMaisonEndomage.Value And e.NombreTotalPersonneMaisonEndomage.Value <= entityVM.SinistreesMAx.Value)).Select(Function(e) e.EvenementZone).ToList()

                    Dim PersonnesLogementsDetruits = CadreSendaiCibleB.Where(Function(e) (entityVM.SinistreesMin.Value <= e.NombreTotalPersonneMaisonDetruite.Value And e.NombreTotalPersonneMaisonDetruite.Value <= entityVM.SinistreesMAx.Value)).Select(Function(e) e.EvenementZone).ToList()

                    Dim PersonnesMoyensSubsistanceAffectes = CadreSendaiCibleB.Where(Function(e) (entityVM.SinistreesMin.Value <= e.NombreTotalMoyenSubsistance.Value And e.NombreTotalMoyenSubsistance.Value <= entityVM.SinistreesMAx.Value) Or
                                                                    (entityVM.SinistreesMin.Value <= e.NombreMoyenSubsistanceFemme.Value And e.NombreMoyenSubsistanceFemme.Value <= entityVM.SinistreesMAx.Value) Or
                                                                    (entityVM.SinistreesMin.Value <= e.NombreMoyenSubsistanceHomme.Value And e.NombreMoyenSubsistanceHomme.Value <= entityVM.SinistreesMAx.Value) Or
                                                                    (entityVM.SinistreesMin.Value <= e.NombreMoyenSubsistanceEnfant.Value And e.NombreMoyenSubsistanceEnfant.Value <= entityVM.SinistreesMAx.Value) Or
                                                                    (entityVM.SinistreesMin.Value <= e.NombreMoyenSubsistanceAdult.Value And e.NombreMoyenSubsistanceAdult.Value <= entityVM.SinistreesMAx.Value) Or
                                                                    (entityVM.SinistreesMin.Value <= e.NombreMoyenSubsistanceVieux.Value And e.NombreMoyenSubsistanceVieux.Value <= entityVM.SinistreesMAx.Value) Or
                                                                    (entityVM.SinistreesMin.Value <= e.NombreMoyenSubsistancePauvre.Value And e.NombreMoyenSubsistancePauvre.Value <= entityVM.SinistreesMAx.Value) Or
                                                                    (entityVM.SinistreesMin.Value <= e.NombreMoyenSubsistanceHandicape.Value And e.NombreMoyenSubsistanceHandicape.Value <= entityVM.SinistreesMAx.Value)).Select(Function(e) e.EvenementZone).ToList()

                    Dim PersonnesAffectees = AutreImpactHumainEtEconomique.Where(Function(e) (entityVM.SinistreesMin.Value <= e.NombreDePersonneAffecter And e.NombreDePersonneAffecter >= entityVM.SinistreesMAx) Or
                                                                    (entityVM.SinistreesMin.Value <= e.NombreDePersonneEvacue.Value And e.NombreDePersonneEvacue.Value <= entityVM.SinistreesMAx.Value) Or
                                                                    (entityVM.SinistreesMin.Value <= e.NombreDePersonneRelocaliser.Value And e.NombreDePersonneRelocaliser.Value <= entityVM.SinistreesMAx.Value) Or
                                                                    (entityVM.SinistreesMin.Value <= e.NombreDePersonneDirrectementAffecter.Value And e.NombreDePersonneDirrectementAffecter.Value <= entityVM.SinistreesMAx.Value)).Select(Function(e) e.EvenementZone).ToList()

                    Dim entities = Blesses.Union(PersonnesLogementsEndommages).Union(PersonnesLogementsDetruits).Union(PersonnesMoyensSubsistanceAffectes).Union(PersonnesAffectees).ToList()
                    QueryFieldsResult.Sinistrees = entities.ToList()
                End If

                If (entityVM.AffecteesIndirectment And entityVM.AffecteesIndirectmentMAx.HasValue And entityVM.AffecteesIndirectmentMin.HasValue) Then

                    QueryFieldsResult.AffecteesDirectment = AutreImpactHumainEtEconomique.Where(Function(e) (entityVM.AffecteesIndirectmentMin.Value <= e.NombreDePersonneDirrectementAffecter.Value And
                                                                                     e.NombreDePersonneDirrectementAffecter.Value <= entityVM.AffecteesIndirectmentMAx.Value)).Select(Function(e) e.EvenementZone).ToList()
                End If

                If (entityVM.Deplacees And entityVM.DeplaceesMAx.HasValue And entityVM.DeplaceesMin.HasValue) Then

                    QueryFieldsResult.Deplacees = AutreImpactHumainEtEconomique.Where(Function(e) (entityVM.DeplaceesMin.Value <= e.NombreDePersonneRelocaliser.Value And e.NombreDePersonneRelocaliser.Value <= entityVM.DeplaceesMAx.Value) Or
                                                                                          (entityVM.DeplaceesMin.Value <= e.NombreDePersonneEvacue.Value And e.NombreDePersonneEvacue.Value <= entityVM.DeplaceesMAx.Value)).Select(Function(e) e.EvenementZone).ToList()
                End If

                If (entityVM.Hopitaux And entityVM.HopitauxMAx.HasValue And entityVM.HopitauxMin.HasValue) Then

                    QueryFieldsResult.Hopitaux = CadreSendaiCibleD.Where(Function(e) (entityVM.HopitauxMin.Value <= e.NombreTotaldesEtablissementDeSanteTouche.Value And e.NombreTotaldesEtablissementDeSanteTouche.Value <= entityVM.HopitauxMAx.Value) Or
                                                                                          (entityVM.HopitauxMin.Value <= e.NombreDesEtablissementsdeSanteEndommager.Value And e.NombreDesEtablissementsdeSanteEndommager.Value <= entityVM.HopitauxMAx.Value) Or
                                                                                          (entityVM.HopitauxMin.Value <= e.NombreDesEtablissementsdeSantedetruits.Value And e.NombreDesEtablissementsdeSantedetruits.Value <= entityVM.HopitauxMAx.Value)).Select(Function(e) e.EvenementZone).ToList()
                End If

                If (entityVM.Disparus And entityVM.DisparusMAx.HasValue And entityVM.DisparusMin.HasValue) Then
                    QueryFieldsResult.Disparus = CadreSendaiCibleA.Where(Function(e) (entityVM.DisparusMin.Value <= e.NombreTotalDisparue.Value And e.NombreTotalDisparue.Value <= entityVM.DisparusMAx.Value) Or
                                                                    (entityVM.DisparusMin.Value <= e.NombreDisparueFemme.Value And e.NombreDisparueFemme.Value <= entityVM.DisparusMAx.Value) Or
                                                                    (entityVM.DisparusMin.Value <= e.NombreDisparueHomme.Value And e.NombreDisparueHomme.Value <= entityVM.DisparusMAx.Value) Or
                                                                    (entityVM.DisparusMin.Value <= e.NombreDisparueEnfant.Value And e.NombreDisparueEnfant.Value <= entityVM.DisparusMAx.Value) Or
                                                                    (entityVM.DisparusMin.Value <= e.NombreDisparueAdult.Value And e.NombreDisparueAdult.Value <= entityVM.DisparusMAx.Value) Or
                                                                    (entityVM.DisparusMin.Value <= e.NombreDisparueVieux.Value And e.NombreDisparueVieux.Value <= entityVM.DisparusMAx.Value) Or
                                                                    (entityVM.DisparusMin.Value <= e.NombreDisparuePauvre.Value And e.NombreDisparuePauvre.Value <= entityVM.DisparusMAx.Value) Or
                                                                    (entityVM.DisparusMin.Value <= e.NombreDisparueHandicape.Value And e.NombreDisparueHandicape.Value <= entityVM.DisparusMAx.Value)).Select(Function(e) e.EvenementZone).ToList()
                End If

                If (entityVM.RoutesEndomages And entityVM.RoutesEndomagesMin.HasValue And entityVM.RoutesEndomagesMAx.HasValue) Then
                    QueryFieldsResult.RoutesEndomagesMTS = CadreSendaiCibleD.Where(Function(e) (entityVM.RoutesEndomagesMin.Value <= e.NombreTotalRoutesTouche.Value And e.NombreTotalRoutesTouche.Value <= entityVM.RoutesEndomagesMAx.Value) Or
                                                                    (entityVM.RoutesEndomagesMin.Value <= e.NombreRoutesEndommager.Value And e.NombreRoutesEndommager.Value <= entityVM.RoutesEndomagesMAx.Value) Or
                                                                    (entityVM.RoutesEndomagesMin.Value <= e.NombreRoutesDetruits.Value And e.NombreRoutesDetruits.Value <= entityVM.RoutesEndomagesMAx.Value)).Select(Function(e) e.EvenementZone).ToList()
                End If

                If (entityVM.CulturesBoisEndomages And entityVM.CulturesBoisEndomagesMin.HasValue And entityVM.CulturesBoisEndomagesMAx.HasValue) Then
                    QueryFieldsResult.Cultures_BoisEndomages_HA = CadreSendaiCibleC.Where(Function(e) (entityVM.CulturesBoisEndomagesMin.Value <= e.HectaresTautauxDesCulturesTouche.Value And e.HectaresTautauxDesCulturesTouche.Value <= entityVM.CulturesBoisEndomagesMAx.Value) Or
                                                                    (entityVM.CulturesBoisEndomagesMin.Value <= e.HectaresEndomages.Value And e.HectaresEndomages.Value <= entityVM.CulturesBoisEndomagesMAx.Value) Or
                                                                    (entityVM.CulturesBoisEndomagesMin.Value <= e.HectaresDetruits.Value And e.HectaresDetruits.Value <= entityVM.CulturesBoisEndomagesMAx.Value)).Select(Function(e) e.EvenementZone).ToList()
                End If

                If (entityVM.BetailPerdu And entityVM.BetailPerduMin.HasValue And entityVM.BetailPerduMAx.HasValue) Then
                    QueryFieldsResult.BetailPerdu = CadreSendaiCibleC.Where(Function(e) (entityVM.BetailPerduMin.Value <= e.NombreDanimauxToucher.Value And e.NombreDanimauxToucher.Value <= entityVM.BetailPerduMAx.Value) Or
                                                                    (entityVM.BetailPerduMin.Value <= e.NombreDanimauxToucheOuPerdu.Value And e.NombreDanimauxToucheOuPerdu.Value <= entityVM.BetailPerduMAx.Value) Or
                                                                    (entityVM.BetailPerduMin.Value <= e.NombreDanimauxPerdu.Value And e.NombreDanimauxPerdu.Value <= entityVM.BetailPerduMAx.Value)).Select(Function(e) e.EvenementZone).ToList()
                End If

                If (entityVM.CulturesBoisEndomages And entityVM.CulturesBoisEndomagesMin.HasValue And entityVM.CulturesBoisEndomagesMAx.HasValue) Then
                    QueryFieldsResult.Cultures_BoisEndomages_HA = CadreSendaiCibleC.Where(Function(e) (entityVM.CulturesBoisEndomagesMin.Value <= e.HectaresTautauxDesCulturesTouche.Value And e.HectaresTautauxDesCulturesTouche.Value <= entityVM.CulturesBoisEndomagesMAx.Value) Or
                                                                    (entityVM.CulturesBoisEndomagesMin.Value <= e.HectaresEndomages.Value And e.HectaresEndomages.Value <= entityVM.CulturesBoisEndomagesMAx.Value) Or
                                                                    (entityVM.CulturesBoisEndomagesMin.Value <= e.HectaresDetruits.Value And e.HectaresDetruits.Value <= entityVM.CulturesBoisEndomagesMAx.Value)).Select(Function(e) e.EvenementZone).ToList()
                End If

                If (entityVM.CentresEducationnels And entityVM.CentresEducationnelsMAx.HasValue And entityVM.CentresEducationnelsMin.HasValue) Then

                    QueryFieldsResult.Hopitaux = CadreSendaiCibleD.Where(Function(e) (entityVM.CentresEducationnelsMin.Value <= e.NombreTotaldesEtablissementEducationTouche.Value And e.NombreTotaldesEtablissementEducationTouche.Value <= entityVM.CentresEducationnelsMAx.Value) Or
                                                                                          (entityVM.CentresEducationnelsMin.Value <= e.NombreDesEtablissementsEducationEndommager.Value And e.NombreDesEtablissementsEducationEndommager.Value <= entityVM.CentresEducationnelsMAx.Value) Or
                                                                                          (entityVM.CentresEducationnelsMin.Value <= e.NombreDesEtablissementsEducationDetruits.Value And e.NombreDesEtablissementsEducationDetruits.Value <= entityVM.CentresEducationnelsMAx.Value)).Select(Function(e) e.EvenementZone).ToList()
                End If

                'Ici en fonction de l'opérateur logique choisi soit on sélectionne les éléments qui sont communs à tous les ensembles (cas du ET) soit on fusionne tous les ensembles (cas du OU)
                Select Case entityVM.Logique
                    Case "ET"
                        Dim entities = QueryFieldsResult.Deces.Intersect(QueryFieldsResult.Blesses).Intersect(QueryFieldsResult.MaisonsDetruites).Intersect(QueryFieldsResult.MaisonsEndommagees).
                        Intersect(QueryFieldsResult.Sinistrees).Intersect(QueryFieldsResult.AffecteesDirectment).Intersect(QueryFieldsResult.AffecteesIndirectment).Intersect(QueryFieldsResult.Deplacees).
                        Intersect(QueryFieldsResult.Hopitaux).Intersect(QueryFieldsResult.Disparus).Intersect(QueryFieldsResult.RoutesEndomagesMTS).Intersect(QueryFieldsResult.Cultures_BoisEndomages_HA).
                        Intersect(QueryFieldsResult.BetailPerdu).Intersect(QueryFieldsResult.CentresEducationnels).ToList()
                        ListEvenementZone = entities
                    Case Else
                        Dim entities = QueryFieldsResult.Deces.Union(QueryFieldsResult.Blesses).Union(QueryFieldsResult.MaisonsDetruites).Union(QueryFieldsResult.MaisonsEndommagees).
                        Union(QueryFieldsResult.Sinistrees).Union(QueryFieldsResult.AffecteesDirectment).Union(QueryFieldsResult.AffecteesIndirectment).Union(QueryFieldsResult.Deplacees).
                        Union(QueryFieldsResult.Hopitaux).Union(QueryFieldsResult.Disparus).Union(QueryFieldsResult.RoutesEndomagesMTS).Union(QueryFieldsResult.Cultures_BoisEndomages_HA).
                        Union(QueryFieldsResult.BetailPerdu).Union(QueryFieldsResult.CentresEducationnels).ToList()
                        ListEvenementZone = entities
                End Select

                'Une fois que la liste des évènements est composée, on peut désormais la filtrer en fonction des localités sélectionnées par l'utilisateur
                'If (Not IsNothing(entityVM.QuartiersId) And entityVM.QuartiersId.Count > 0) Then
                If (entityVM.QuartiersId IsNot Nothing) AndAlso (entityVM.QuartiersId.Any()) Then
                    For Each IdQuartier In entityVM.QuartiersId
                        'Dim ListZoneLocalisation = (From e In Db.ZoneLocalisation Where e.QuartierId = IdQuartier From evntZon In e.ZoneARisque.EvenementZone Select evntZon).ToList()
                        Dim ListEvenementZoneFiltree = (From e In ListEvenementZone From evntZon In e.ZoneARisque.ZoneLocalisation Where evntZon.QuartierId = IdQuartier Select e).ToList()
                        ListEvenementZone = IIf(ListEvenementZoneFiltree.Count > 0, ListEvenementZoneFiltree.Intersect(ListEvenementZone).ToList(), ListEvenementZone)
                    Next
                ElseIf (entityVM.CommuneId IsNot Nothing) AndAlso (entityVM.CommuneId.Any()) Then
                    For Each IdCommune In entityVM.CommuneId
                        'Dim ListZoneLocalisation = (From e In Db.ZoneLocalisation Where e.QuartierId = IdQuartier From evntZon In e.ZoneARisque.EvenementZone Select evntZon).ToList()
                        Dim ListEvenementZoneFiltree = (From e In ListEvenementZone From evntZon In e.ZoneARisque.ZoneLocalisation Where evntZon.Quartier.CommuneId = IdCommune Select e).ToList()
                        ListEvenementZone = IIf(ListEvenementZoneFiltree.Count > 0, ListEvenementZoneFiltree.Intersect(ListEvenementZone).ToList(), ListEvenementZone)
                    Next
                ElseIf (entityVM.DepartementId IsNot Nothing) AndAlso (entityVM.DepartementId.Any()) Then
                    For Each IdDepartement In entityVM.DepartementId
                        'Dim ListZoneLocalisation = (From e In Db.ZoneLocalisation Where e.QuartierId = IdQuartier From evntZon In e.ZoneARisque.EvenementZone Select evntZon).ToList()
                        Dim ListEvenementZoneFiltree = (From e In ListEvenementZone From evntZon In e.ZoneARisque.ZoneLocalisation Where
                                                                                                                                       evntZon.Quartier.Commune.DepartementId = IdDepartement Select e).ToList()
                        ListEvenementZone = IIf(ListEvenementZoneFiltree.Count > 0, ListEvenementZoneFiltree.Intersect(ListEvenementZone).ToList(), ListEvenementZone)
                    Next
                ElseIf (entityVM.RegionId IsNot Nothing) AndAlso (entityVM.RegionId.Any()) Then
                    For Each IdRegion In entityVM.RegionId
                        'Dim ListZoneLocalisation = (From e In Db.ZoneLocalisation Where e.QuartierId = IdQuartier From evntZon In e.ZoneARisque.EvenementZone Select evntZon).ToList()
                        Dim ListEvenementZoneFiltree = (From e In ListEvenementZone From evntZon In e.ZoneARisque.ZoneLocalisation Where
                                                                                                                                       evntZon.Quartier.Commune.Departement.RegionId = IdRegion Select e).ToList()
                        ListEvenementZone = IIf(ListEvenementZoneFiltree.Count > 0, ListEvenementZoneFiltree.Intersect(ListEvenementZone).ToList(), ListEvenementZone)
                    Next
                End If

                AppSession.ListEvenementZone = ListEvenementZone
                    Return RedirectToAction("QueryResult", New With {.sortOrder = "", .currentFilter = "", .searchString = "", .page = 1})
                End If
                LoadQueryComboBox(entityVM)
            Return View(entityVM)
        End Function


        ' GET: EvenementZone/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim EvenementZone As EvenementZone = Db.EvenementZone.Find(id)
            If IsNothing(EvenementZone) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New EvenementZoneViewModel(EvenementZone)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: EvenementZone/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim EvenementZone As EvenementZone = Db.EvenementZone.Find(id)
            Db.EvenementZone.Remove(EvenementZone)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New EvenementZoneViewModel(EvenementZone))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class

    Public Class QueryFieldsResult
        Public Property Deces As New List(Of EvenementZone)
        Public Property Blesses As New List(Of EvenementZone)
        Public Property MaisonsDetruites As New List(Of EvenementZone)
        Public Property MaisonsEndommagees As New List(Of EvenementZone)
        Public Property Sinistrees As New List(Of EvenementZone)
        Public Property AffecteesDirectment As New List(Of EvenementZone)
        Public Property AffecteesIndirectment As New List(Of EvenementZone)
        Public Property Deplacees As New List(Of EvenementZone)
        Public Property Hopitaux As New List(Of EvenementZone)
        Public Property Disparus As New List(Of EvenementZone)
        Public Property RoutesEndomagesMTS As New List(Of EvenementZone)
        Public Property Cultures_BoisEndomages_HA As New List(Of EvenementZone)
        Public Property BetailPerdu As New List(Of EvenementZone)
        Public Property CentresEducationnels As New List(Of EvenementZone)
        Public Property EauPotable As New List(Of EvenementZone)
        Public Property Egouts As New List(Of EvenementZone)
        Public Property Sante As New List(Of EvenementZone)
        Public Property Education As New List(Of EvenementZone)
        Public Property Industries As New List(Of EvenementZone)
        Public Property Transport As New List(Of EvenementZone)
        Public Property Communications As New List(Of EvenementZone)
        Public Property Energie As New List(Of EvenementZone)
        Public Property Secours As New List(Of EvenementZone)
        Public Property Agriculture As New List(Of EvenementZone)
        Public Property AutresSecteurs As New List(Of EvenementZone)
    End Class

End Namespace
