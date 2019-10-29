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
            Dim CadreSendaiCibleA = (From e In Db.CardreSendaiCibleA Where e.StatutExistant = 1)
            Dim CadreSendaiCibleB = (From e In Db.CardreSendaiCibleB Where e.StatutExistant = 1)
            Dim CadreSendaiCibleC = (From e In Db.CardreSendaiCibleC Where e.StatutExistant = 1)
            Dim CadreSendaiCibleD = (From e In Db.CardreSendaiCibleD Where e.StatutExistant = 1)
            Dim entities = (From e In Db.EvenementZone Where e.StatutExistant = 1)

            If (entityVM.Deces And entityVM.DecesMAx.HasValue And entityVM.DecesMin.HasValue) Then
                CadreSendaiCibleA = CadreSendaiCibleA.Where(Function(e) (entityVM.DecesMin.Value <= IIf(e.NombreTotalDeces.HasValue, e.NombreTotalDeces.Value, 0) And IIf(e.NombreTotalDeces.HasValue, e.NombreTotalDeces.Value, 0) <= entityVM.DecesMAx.Value) Or
                                                                (entityVM.DecesMin.Value <= IIf(e.NombreDecesFemme.HasValue, e.NombreDecesFemme.Value, 0) And IIf(e.NombreDecesFemme.HasValue, e.NombreDecesFemme.Value, 0) <= entityVM.DecesMAx.Value) Or
                                                                (entityVM.DecesMin.Value <= IIf(e.NombreDecesHomme.HasValue, e.NombreDecesHomme.Value, 0) And IIf(e.NombreDecesHomme.HasValue, e.NombreDecesHomme.Value, 0) <= entityVM.DecesMAx.Value) Or
                                                                (entityVM.DecesMin.Value <= IIf(e.NombreDecesEnfant.HasValue, e.NombreDecesEnfant.Value, 0) And IIf(e.NombreDecesEnfant.HasValue, e.NombreDecesEnfant.Value, 0) <= entityVM.DecesMAx.Value) Or
                                                                (entityVM.DecesMin.Value <= IIf(e.NombreDecesAdult.HasValue, e.NombreDecesAdult.Value, 0) And IIf(e.NombreDecesAdult.HasValue, e.NombreDecesAdult.Value, 0) <= entityVM.DecesMAx.Value) Or
                                                                (entityVM.DecesMin.Value <= IIf(e.NombreDecesVieux.HasValue, e.NombreDecesVieux.Value, 0) And IIf(e.NombreDecesVieux.HasValue, e.NombreDecesVieux.Value, 0) <= entityVM.DecesMAx.Value) Or
                                                                (entityVM.DecesMin.Value <= IIf(e.NombreDecesPauvre.HasValue, e.NombreDecesPauvre.Value, 0) And IIf(e.NombreDecesPauvre.HasValue, e.NombreDecesPauvre.Value, 0) <= entityVM.DecesMAx.Value) Or
                                                                (entityVM.DecesMin.Value <= IIf(e.NombreDecesHandicape.HasValue, e.NombreDecesHandicape.Value, 0) And IIf(e.NombreDecesHandicape.HasValue, e.NombreDecesHandicape.Value, 0) <= entityVM.DecesMAx.Value))
            End If

            If (entityVM.Disparus And entityVM.DisparusMAx.HasValue And entityVM.DisparusMin.HasValue) Then
                CadreSendaiCibleA = CadreSendaiCibleA.Where(Function(e) (entityVM.DisparusMin.Value <= IIf(e.NombreTotalDisparue.HasValue, e.NombreTotalDisparue.Value, 0) And IIf(e.NombreTotalDisparue.HasValue, e.NombreTotalDisparue.Value, 0) <= entityVM.DisparusMAx.Value) Or
                                                                (entityVM.DisparusMin.Value <= IIf(e.NombreDisparueFemme.HasValue, e.NombreDisparueFemme.Value, 0) And IIf(e.NombreDisparueFemme.HasValue, e.NombreDisparueFemme.Value, 0) <= entityVM.DisparusMAx.Value) Or
                                                                (entityVM.DisparusMin.Value <= IIf(e.NombreDisparueHomme.HasValue, e.NombreDisparueHomme.Value, 0) And IIf(e.NombreDisparueHomme.HasValue, e.NombreDisparueHomme.Value, 0) <= entityVM.DisparusMAx.Value) Or
                                                                (entityVM.DisparusMin.Value <= IIf(e.NombreDisparueEnfant.HasValue, e.NombreDisparueEnfant.Value, 0) And IIf(e.NombreDisparueEnfant.HasValue, e.NombreDisparueEnfant.Value, 0) <= entityVM.DisparusMAx.Value) Or
                                                                (entityVM.DisparusMin.Value <= IIf(e.NombreDisparueAdult.HasValue, e.NombreDisparueAdult.Value, 0) And IIf(e.NombreDisparueAdult.HasValue, e.NombreDisparueAdult.Value, 0) <= entityVM.DisparusMAx.Value) Or
                                                                (entityVM.DisparusMin.Value <= IIf(e.NombreDisparueVieux.HasValue, e.NombreDisparueVieux.Value, 0) And IIf(e.NombreDisparueVieux.HasValue, e.NombreDisparueVieux.Value, 0) <= entityVM.DisparusMAx.Value) Or
                                                                (entityVM.DisparusMin.Value <= IIf(e.NombreDisparuePauvre.HasValue, e.NombreDisparuePauvre.Value, 0) And IIf(e.NombreDisparuePauvre.HasValue, e.NombreDisparuePauvre.Value, 0) <= entityVM.DisparusMAx.Value) Or
                                                                (entityVM.DisparusMin.Value <= IIf(e.NombreDisparueHandicape.HasValue, e.NombreDisparueHandicape.Value, 0) And IIf(e.NombreDisparueHandicape.HasValue, e.NombreDisparueHandicape.Value, 0) <= entityVM.DisparusMAx.Value))
            End If

            If (entityVM.MaisonEndommages And entityVM.MaisonEndommagesMAx.HasValue And entityVM.MaisonEndommagesMin.HasValue) Then
                CadreSendaiCibleB = CadreSendaiCibleB.Where(Function(e) (entityVM.MaisonEndommagesMin.Value <= IIf(e.NombreTotalMaisonEndomage.HasValue, e.NombreTotalMaisonEndomage.Value, 0) And IIf(e.NombreTotalMaisonEndomage.HasValue, e.NombreTotalMaisonEndomage.Value, 0) <= entityVM.MaisonEndommagesMAx.Value) Or
                                                                (entityVM.MaisonEndommagesMin.Value <= IIf(e.NombreMaisonEndomageFemme.HasValue, e.NombreMaisonEndomageFemme.Value, 0) And IIf(e.NombreMaisonEndomageFemme.HasValue, e.NombreMaisonEndomageFemme.Value, 0) <= entityVM.MaisonEndommagesMAx.Value) Or
                                                                (entityVM.MaisonEndommagesMin.Value <= IIf(e.NombreMaisonEndomageHomme.HasValue, e.NombreMaisonEndomageHomme.Value, 0) And IIf(e.NombreMaisonEndomageHomme.HasValue, e.NombreMaisonEndomageHomme.Value, 0) <= entityVM.MaisonEndommagesMAx.Value) Or
                                                                (entityVM.MaisonEndommagesMin.Value <= IIf(e.NombreMaisonEndomageEnfant.HasValue, e.NombreMaisonEndomageEnfant.Value, 0) And IIf(e.NombreMaisonEndomageEnfant.HasValue, e.NombreMaisonEndomageEnfant.Value, 0) <= entityVM.MaisonEndommagesMAx.Value) Or
                                                                (entityVM.MaisonEndommagesMin.Value <= IIf(e.NombreMaisonEndomageAdult.HasValue, e.NombreMaisonEndomageAdult.Value, 0) And IIf(e.NombreMaisonEndomageAdult.HasValue, e.NombreMaisonEndomageAdult.Value, 0) <= entityVM.MaisonEndommagesMAx.Value) Or
                                                                (entityVM.MaisonEndommagesMin.Value <= IIf(e.NombreMaisonEndomageVieux.HasValue, e.NombreMaisonEndomageVieux.Value, 0) And IIf(e.NombreMaisonEndomageVieux.HasValue, e.NombreMaisonEndomageVieux.Value, 0) <= entityVM.MaisonEndommagesMAx.Value) Or
                                                                (entityVM.MaisonEndommagesMin.Value <= IIf(e.NombreMaisonEndomagePauvre.HasValue, e.NombreMaisonEndomagePauvre.Value, 0) And IIf(e.NombreMaisonEndomagePauvre.HasValue, e.NombreMaisonEndomagePauvre.Value, 0) <= entityVM.MaisonEndommagesMAx.Value) Or
                                                                (entityVM.MaisonEndommagesMin.Value <= IIf(e.NombreMaisonEndomageHandicape.HasValue, e.NombreMaisonEndomageHandicape.Value, 0) And IIf(e.NombreMaisonEndomageHandicape.HasValue, e.NombreMaisonEndomageHandicape.Value, 0) <= entityVM.MaisonEndommagesMAx.Value))
            End If

            If (entityVM.MaisonDetruite And entityVM.MaisonDetruiteMAx.HasValue And entityVM.MaisonDetruiteMin.HasValue) Then
                CadreSendaiCibleB = CadreSendaiCibleB.Where(Function(e) (entityVM.MaisonDetruiteMin.Value <= IIf(e.NombreTotalMaisonEndomage.HasValue, e.NombreTotalMaisonEndomage.Value, 0) And IIf(e.NombreTotalMaisonEndomage.HasValue, e.NombreTotalMaisonEndomage.Value, 0) <= entityVM.MaisonDetruiteMAx.Value) Or
                                                                (entityVM.MaisonDetruiteMin.Value <= IIf(e.NombreMaisonDetruiteFemme.HasValue, e.NombreMaisonDetruiteFemme.Value, 0) And IIf(e.NombreMaisonDetruiteFemme.HasValue, e.NombreMaisonDetruiteFemme.Value, 0) <= entityVM.MaisonDetruiteMAx.Value) Or
                                                                (entityVM.MaisonDetruiteMin.Value <= IIf(e.NombreMaisonDetruiteHomme.HasValue, e.NombreMaisonDetruiteHomme.Value, 0) And IIf(e.NombreMaisonDetruiteHomme.HasValue, e.NombreMaisonDetruiteHomme.Value, 0) <= entityVM.MaisonDetruiteMAx.Value) Or
                                                                (entityVM.MaisonDetruiteMin.Value <= IIf(e.NombreMaisonDetruiteEnfant.HasValue, e.NombreMaisonDetruiteEnfant.Value, 0) And IIf(e.NombreMaisonDetruiteEnfant.HasValue, e.NombreMaisonDetruiteEnfant.Value, 0) <= entityVM.MaisonDetruiteMAx.Value) Or
                                                                (entityVM.MaisonDetruiteMin.Value <= IIf(e.NombreMaisonDetruiteAdult.HasValue, e.NombreMaisonDetruiteAdult.Value, 0) And IIf(e.NombreMaisonDetruiteAdult.HasValue, e.NombreMaisonDetruiteAdult.Value, 0) <= entityVM.MaisonDetruiteMAx.Value) Or
                                                                (entityVM.MaisonDetruiteMin.Value <= IIf(e.NombreMaisonDetruiteVieux.HasValue, e.NombreMaisonDetruiteVieux.Value, 0) And IIf(e.NombreMaisonDetruiteVieux.HasValue, e.NombreMaisonDetruiteVieux.Value, 0) <= entityVM.MaisonDetruiteMAx.Value) Or
                                                                (entityVM.MaisonDetruiteMin.Value <= IIf(e.NombreMaisonDetruitePauvre.HasValue, e.NombreMaisonDetruitePauvre.Value, 0) And IIf(e.NombreMaisonDetruitePauvre.HasValue, e.NombreMaisonDetruitePauvre.Value, 0) <= entityVM.MaisonDetruiteMAx.Value) Or
                                                                (entityVM.MaisonDetruiteMin.Value <= IIf(e.NombreMaisonDetruiteHandicape.HasValue, e.NombreMaisonDetruiteHandicape.Value, 0) And IIf(e.NombreMaisonDetruiteHandicape.HasValue, e.NombreMaisonDetruiteHandicape.Value, 0) <= entityVM.MaisonDetruiteMAx.Value))
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
End Namespace
