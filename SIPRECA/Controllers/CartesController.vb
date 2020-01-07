Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList

Namespace Controllers
    Public Class CartesController
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

        Public Function Hopitaux() As JsonResult
            Dim entities = (From p In _db.Hopitaux
                            Select New With {
                                .Organisation = p.Oganisation.Nom,
                                .TypeHopital = p.TypeHopitaux.Libelle,
                                p.Id,
                                p.Nom,
                                p.Code,
                                p.NombreDeLitMin,
                                p.NombreDeLitMax,
                                p.NombreDeMedecin,
                                p.NombreDInfimiere,
                                p.NombreDePersonnelNonMedical,
                                p.Telephone,
                                p.TelephoneUrgence,
                                p.SiteWeb,
                                p.Email,
                                p.DateCreation,
                                p.StatutExistant,
                                .Long = p.Location.XCoordinate,
                                .Lat = p.Location.YCoordinate,
                                .Commune = p.Commune.Libelle
                            }).ToList()
            Return Json(entities, JsonRequestBehavior.AllowGet)
        End Function

        Public Function Heliports() As JsonResult
            Dim entities = (From p In _db.Heliport
                            Select New With {
                                .Organisation = p.Oganisation.Nom,
                                p.Id,
                                p.Nom,
                                p.Code,
                                p.Telephone,
                                .TelephoneUrgence = p.Telephone2,
                                p.SiteWeb,
                                p.Email,
                                p.DateCreation,
                                p.StatutExistant,
                                .Long = p.Location.XCoordinate,
                                .Lat = p.Location.YCoordinate,
                                .Commune = p.Commune.Libelle
                            }).ToList()
            Return Json(entities, JsonRequestBehavior.AllowGet)
        End Function

        Public Function Aeroport() As JsonResult
            Dim entities = (From p In _db.Aeroport
                            Select New With {
                                .Organisation = p.Oganisation.Nom,
                                .SurfacePiste = p.SurfaceDePiste.Libelle,
                                .TailleDeAeronef = p.TailleDeAeronef.Libelle,
                                .UsageHumanitaire = p.UsageHumanitaire.Libelle,
                                p.Id,
                                p.Nom,
                                p.ICAO,
                                p.IATA,
                                p.LongueurDePiste,
                                p.LargeurDePiste,
                                p.Telephone,
                                p.Telephone2,
                                p.SiteWeb,
                                p.Email,
                                p.DateCreation,
                                p.StatutExistant,
                                .Long = p.Location.XCoordinate,
                                .Lat = p.Location.YCoordinate,
                                .Commune = p.Commune.Libelle
                            }).ToList()
            Return Json(entities, JsonRequestBehavior.AllowGet)
        End Function

        Public Function Abris() As JsonResult
            Dim entities = (From p In _db.Abris
                            Select New With {
                                .Organisation = p.Oganisation.Nom,
                                .TypeAbris = p.TypeAbris.Libelle,
                                p.Id,
                                p.Nom,
                                p.EstimationPopulation,
                                p.Capacite,
                                p.DateCreation,
                                p.StatutExistant,
                                .Long = p.Location.XCoordinate,
                                .Lat = p.Location.YCoordinate,
                                .Commune = p.Commune.Libelle
                            }).ToList()
            Return Json(entities, JsonRequestBehavior.AllowGet)
        End Function

        Public Function Bureaux() As JsonResult
            Dim entities = (From p In _db.Bureau
                            Select New With {
                                .Organisation = p.Oganisation.Nom,
                                p.Id,
                                p.Nom,
                                p.Code,
                                p.CodePostale,
                                p.Telephone,
                                .TelephoneUrgence = p.Telephone2,
                                p.Email,
                                p.DateCreation,
                                p.StatutExistant,
                                .Long = p.Location.XCoordinate,
                                .Lat = p.Location.YCoordinate,
                                .Commune = p.Commune.Libelle
                            }).ToList()
            Return Json(entities, JsonRequestBehavior.AllowGet)
        End Function

        Public Function Entrepots() As JsonResult
            Dim entities = (From p In _db.Entrepots
                            Select New With {
                                .Organisation = p.Oganisation.Nom,
                                p.Id,
                                p.Nom,
                                p.Code,
                                p.CodePostale,
                                p.Telephone,
                                .TelephoneUrgence = p.Telephone2,
                                p.Email,
                                p.DateCreation,
                                p.StatutExistant,
                                .Long = p.Location.XCoordinate,
                                .Lat = p.Location.YCoordinate,
                                .Commune = p.Commune.Libelle
                            }).ToList()
            Return Json(entities, JsonRequestBehavior.AllowGet)
        End Function

        Public Function Installations() As JsonResult
            Dim entities = (From p In _db.Installation
                            Select New With {
                                .Organisation = p.Oganisation.Nom,
                                p.Id,
                                p.Nom,
                                p.Code,
                                p.CodePostale,
                                p.Telephone,
                                .TelephoneUrgence = p.Telephone2,
                                p.Email,
                                p.DateCreation,
                                p.StatutExistant,
                                .Long = p.Location.XCoordinate,
                                .Lat = p.Location.YCoordinate,
                                .Commune = p.Commune.Libelle
                            }).ToList()
            Return Json(entities, JsonRequestBehavior.AllowGet)
        End Function

        Public Function Ports() As JsonResult
            Dim entities = (From p In _db.PortDeMer
                            Select New With {
                                p.Id,
                                .Organisation = p.Oganisation.Nom,
                                p.Nom,
                                p.Code,
                                p.Possession,
                                p.HauteurMaximum,
                                p.HauteurMaximumUnites,
                                p.ProfondeurQuaiChargement,
                                p.ProfondeurQuaiChargementUnites,
                                p.ProfondeurTerminalPetrolier,
                                p.ProfondeurTerminalPetrolierUnites,
                                p.CaleSeche,
                                p.LongueurMaximaleNavire,
                                p.LongueurMaximaleNavireUnites,
                                p.Reparations,
                                p.Abri,
                                p.CapaciteStockageEntreposage,
                                p.CapaciteStockageSecurise,
                                p.CapaciteStockageEntrepotDouanier,
                                p.NombreRemorqueur,
                                p.CapaciteRemorqueur,
                                p.NombreBarge,
                                p.CapacietBarge,
                                p.EquipementChargement,
                                p.CapaciteDouaniere,
                                p.Securite,
                                p.ProfondeurMareHaute,
                                p.ProfondeurMareHauteUnites,
                                p.ProfondeurMareBasse,
                                p.ProfondeurMareBasseUnites,
                                p.ProfondeurInondation,
                                p.ProfondeurInondationUnites,
                                p.Telephone,
                                .TelephoneUrgence = p.Telephone2,
                                p.Email,
                                p.DateCreation,
                                p.StatutExistant,
                                .Long = p.Location.XCoordinate,
                                .Lat = p.Location.YCoordinate,
                                .Commune = p.Commune.Libelle
                            }).ToList()
            Return Json(entities, JsonRequestBehavior.AllowGet)
        End Function

        Public Function ZonesRisques() As JsonResult
            Dim entities = (From p In _db.ZoneARisque
                            Select New With {
                                p.Id,
                                p.Libelle,
                                p.Rayon,
                                p.DateCreation,
                                p.StatutExistant,
                                .Long = p.Location.XCoordinate,
                                .Lat = p.Location.YCoordinate,
                                .Risques = (From r In _db.RisqueZone Where r.ZoneARisqueId = p.Id Select risque = r.Risque.Libelle & " (" & r.NiveauDAlert.Libelle & ")").ToList()
                            }).ToList()
            Return Json(entities, JsonRequestBehavior.AllowGet)
        End Function

        Private Sub LoadComboBox(entityVM As FiltreViewModel)

            Dim Organisation = (From e In Db.Organisation Where e.StatutExistant = 1 Select e)
            Dim LesOrganisations As New List(Of SelectListItem)

            Dim Ville = (From e In Db.Ville Where e.StatutExistant = 1 Select e)
            Dim LesVilles As New List(Of SelectListItem)

            Dim TypeOffice = (From e In Db.TypeOffice Where e.StatutExistant = 1 Select e)
            Dim LesTypeOffices As New List(Of SelectListItem)

            Dim TypeAbris = (From e In Db.TypeAbris Where e.StatutExistant = 1 Select e)
            Dim LesTypeAbris As New List(Of SelectListItem)

            Dim TailleDeAeronef = (From e In Db.TailleDeAeronef Where e.StatutExistant = 1 Select e)
            Dim LesTailleDeAeronefs As New List(Of SelectListItem)

            Dim TypeHopitaux = (From e In Db.TypeHopitaux Where e.StatutExistant = 1 Select e)
            Dim LesTypeHopitaux As New List(Of SelectListItem)

            Dim TypeEntrepot = (From e In Db.TypeEntrepot Where e.StatutExistant = 1 Select e)
            Dim LesTypeEntrepots As New List(Of SelectListItem)

            Dim MaterielHopitaux = (From e In Db.Materiel Where e.StatutExistant = 1 And e.Cible = 1 Select e)
            Dim LesMaterielHopitaux As New List(Of SelectListItem)

            Dim MaterielAbris = (From e In Db.Materiel Where e.StatutExistant = 1 And e.Cible = 2 Select e)
            Dim LesMaterielAbris As New List(Of SelectListItem)

            Dim MaterielHeliport = (From e In Db.Materiel Where e.StatutExistant = 1 And e.Cible = 3 Select e)
            Dim LesMaterielHeliport As New List(Of SelectListItem)

            Dim MaterielPortDeMer = (From e In Db.Materiel Where e.StatutExistant = 1 And e.Cible = 4 Select e)
            Dim LesMaterielPortDeMer As New List(Of SelectListItem)

            Dim MaterielAeroport = (From e In Db.Materiel Where e.StatutExistant = 1 And e.Cible = 5 Select e)
            Dim LesMaterielAeroport As New List(Of SelectListItem)

            Dim MaterielBureau = (From e In Db.Materiel Where e.StatutExistant = 1 And e.Cible = 6 Select e)
            Dim LesMaterielBureau As New List(Of SelectListItem)

            Dim MaterielInstallation = (From e In Db.Materiel Where e.StatutExistant = 1 And e.Cible = 7 Select e)
            Dim LesMaterielInstallation As New List(Of SelectListItem)

            Dim MaterielEntrepots = (From e In Db.Materiel Where e.StatutExistant = 1 And e.Cible = 8 Select e)
            Dim LesMaterielEntrepots As New List(Of SelectListItem)

            For Each item In Organisation
                LesOrganisations.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
            Next

            For Each item In Ville
                LesVilles.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In TypeOffice
                LesTypeOffices.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In TypeAbris
                LesTypeAbris.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In TailleDeAeronef
                LesTailleDeAeronefs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In TypeHopitaux
                LesTypeHopitaux.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In TypeEntrepot
                LesTypeEntrepots.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In MaterielHopitaux
                LesMaterielHopitaux.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In MaterielAbris
                LesMaterielAbris.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In MaterielHeliport
                LesMaterielHeliport.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In MaterielPortDeMer
                LesMaterielPortDeMer.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In MaterielAeroport
                LesMaterielAeroport.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In MaterielBureau
                LesMaterielBureau.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In MaterielInstallation
                LesMaterielInstallation.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In MaterielEntrepots
                LesMaterielEntrepots.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next


            entityVM.LesTypeOffices = LesTypeOffices
            entityVM.LesVilles = LesVilles
            entityVM.LesOrganisations = LesOrganisations
            entityVM.LesTypeAbris = LesTypeAbris
            entityVM.LesTypeEntrepots = LesTypeEntrepots
            entityVM.LesTailleDeAeronefs = LesTailleDeAeronefs
            entityVM.LesTypeHopitaux = LesTypeHopitaux
            entityVM.LesMaterielAeroport = LesMaterielAeroport
            entityVM.LesMaterielsAbris = LesMaterielAbris
            entityVM.LesMaterielBureau = LesMaterielBureau
            entityVM.LesMaterielPortDeMer = LesMaterielPortDeMer
            entityVM.LesMaterielHeliport = LesMaterielHeliport
            entityVM.LesMaterielInstallation = LesMaterielInstallation
            entityVM.LesMaterielEntrepots = LesMaterielEntrepots
            entityVM.LesMaterielHopitaux = LesMaterielHopitaux
        End Sub

        ' GET: Carte
        Function Index() As ActionResult
            Dim entityVM As New FiltreViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Query(ByVal entityVM As FiltreViewModel) As ActionResult
            If (ModelState.IsValid) Then
                Dim QueryFieldsResult As New QueryCartesResult()
                Dim Aeroports = (From e In Db.Aeroport Where e.StatutExistant = 1 Select e)
                Dim Abris = (From e In Db.Abris Where e.StatutExistant = 1 Select e)
                Dim Heliports = (From e In Db.Heliport Where e.StatutExistant = 1 Select e)
                Dim Hopitaux = (From e In Db.Hopitaux Where e.StatutExistant = 1 Select e)
                Dim Bureaux = (From e In Db.Bureau Where e.StatutExistant = 1 Select e)
                Dim Installation = (From e In Db.Installation Where e.StatutExistant = 1 Select e)
                Dim Entrepots = (From e In Db.Entrepots Where e.StatutExistant = 1 Select e)
                Dim PortDeMers = (From e In Db.PortDeMer Where e.StatutExistant = 1 Select e)

                If (entityVM.Abris And entityVM.AbrisCapaciteMin.HasValue And entityVM.AbrisCapaciteMAx.HasValue And entityVM.AbrisEstimationPopulationMin.HasValue And entityVM.AbrisEstimationPopulationMAx.HasValue) Then
                    QueryFieldsResult.Abris = Abris.Where(Function(e) (entityVM.AbrisCapaciteMin.Value <= e.Capacite And e.Capacite <= entityVM.AbrisCapaciteMAx.Value) And
                                                                    (entityVM.AbrisEstimationPopulationMin.Value <= e.EstimationPopulation And e.EstimationPopulation <= entityVM.AbrisEstimationPopulationMin.Value)).Select(Function(e) e).ToList()
                End If

                If (entityVM.Aeroport And entityVM.AeroportLargeurDePisteMin.HasValue And entityVM.AeroportLargeurDePisteMAx.HasValue And entityVM.AeroportLongueurDePisteMin.HasValue And entityVM.AeroportLongueurDePisteMAx.HasValue) Then
                    QueryFieldsResult.Aeroport = Aeroports.Where(Function(e) (entityVM.AeroportLargeurDePisteMin.Value <= e.LargeurDePiste And e.LargeurDePiste <= entityVM.AeroportLargeurDePisteMAx.Value) And
                                                                    (entityVM.AeroportLongueurDePisteMin.Value <= e.LongueurDePiste And e.LongueurDePiste <= entityVM.AeroportLongueurDePisteMAx.Value)).Select(Function(e) e).ToList()
                End If

                If (entityVM.Entrepot And entityVM.EntrepotCapaciteDisponibleMin.HasValue And entityVM.EntrepotCapaciteDisponibleMAx.HasValue And entityVM.EntrepotCapaciteMin.HasValue And entityVM.EntrepotCapaciteMAx.HasValue) Then
                    QueryFieldsResult.Entrepots = Entrepots.Where(Function(e) (entityVM.EntrepotCapaciteDisponibleMin.Value <= e.CapaciteDisponible And e.CapaciteDisponible <= entityVM.EntrepotCapaciteDisponibleMAx.Value) And
                                                                    (entityVM.EntrepotCapaciteMin.Value <= e.Capacite And e.Capacite <= entityVM.EntrepotCapaciteMAx.Value)).Select(Function(e) e).ToList()
                End If

                If (entityVM.Hopitaux And entityVM.NombreDInfimiereMin.HasValue And entityVM.NombreDInfimiereMAx.HasValue And entityVM.NombreDeMedecinMin.HasValue And entityVM.NombreDeMedecinMax.HasValue And
                    entityVM.NombreDePersonnelNonMedicalMin.HasValue And entityVM.NombreDePersonnelNonMedicalMAx.HasValue And entityVM.NombreDeLitMin.HasValue And entityVM.NombreDeLitMax.HasValue) Then
                    QueryFieldsResult.Hopitaux = Hopitaux.Where(Function(e) (entityVM.NombreDInfimiereMin.Value <= e.NombreDInfimiere And e.NombreDInfimiere <= entityVM.NombreDInfimiereMAx.Value) And
                                                                    (entityVM.NombreDeMedecinMin.Value <= e.NombreDeMedecin And e.NombreDeMedecin <= entityVM.NombreDeMedecinMax.Value) And
                                                                    (entityVM.NombreDePersonnelNonMedicalMin.Value <= e.NombreDePersonnelNonMedical And e.NombreDePersonnelNonMedical <= entityVM.NombreDePersonnelNonMedicalMAx.Value) And
                                                                    (entityVM.NombreDeLitMin.Value <= e.NombreDeLitMin And e.NombreDeLitMax <= entityVM.NombreDeLitMax.Value)).Select(Function(e) e).ToList()
                End If

                If (entityVM.PortDeMer And entityVM.PortDeMerHauteurMaximumMin.HasValue And entityVM.PortDeMerHauteurMaximumMAx.HasValue And entityVM.PortDeMerProfondeurQuaiChargementMin.HasValue And entityVM.PortDeMerProfondeurQuaiChargementMAx.HasValue And
                    entityVM.PortDeMerProfondeurTerminalPetrolierMin.HasValue And entityVM.PortDeProfondeurTerminalPetrolierMAx.HasValue And entityVM.PortDeMerLongueurMaximaleNavireMin.HasValue And entityVM.PortDeMerLongueurMaximaleNavireMAx.HasValue) Then
                    QueryFieldsResult.PortDeMer = PortDeMers.Where(Function(e) (entityVM.PortDeMerHauteurMaximumMin.Value <= e.HauteurMaximum And e.HauteurMaximum <= entityVM.PortDeMerHauteurMaximumMAx.Value) And
                                                                    (entityVM.PortDeMerProfondeurQuaiChargementMin.Value <= e.ProfondeurQuaiChargement And e.ProfondeurQuaiChargement <= entityVM.PortDeMerProfondeurQuaiChargementMAx.Value) And
                                                                    (entityVM.PortDeMerProfondeurTerminalPetrolierMin.Value <= e.ProfondeurTerminalPetrolier And e.ProfondeurTerminalPetrolier <= entityVM.PortDeProfondeurTerminalPetrolierMAx.Value) And
                                                                    (entityVM.PortDeMerLongueurMaximaleNavireMin.Value <= e.LongueurMaximaleNavire And e.LongueurMaximaleNavire <= entityVM.PortDeMerLongueurMaximaleNavireMAx.Value)).Select(Function(e) e).ToList()
                End If

            End If

            Return View(entityVM)
        End Function

    End Class

    Public Class QueryCartesResult
        Public Property Abris As New List(Of Abris)
        Public Property Aeroport As New List(Of Aeroport)
        Public Property Hopitaux As New List(Of Hopitaux)
        Public Property Heliport As New List(Of Heliport)
        Public Property Bureau As New List(Of Bureau)
        Public Property Installation As New List(Of Installation)
        Public Property Entrepots As New List(Of Entrepots)
        Public Property PortDeMer As New List(Of PortDeMer)

    End Class

End Namespace
