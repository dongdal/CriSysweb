Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class IncludeClassForDesInventar
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.ZoneLocalisation",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .ZoneARisqueId = c.Long(nullable := False),
                        .QuartierId = c.Long(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Quartier", Function(t) t.QuartierId) _
                .ForeignKey("dbo.ZoneARisque", Function(t) t.ZoneARisqueId) _
                .Index(Function(t) t.ZoneARisqueId) _
                .Index(Function(t) t.QuartierId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.ZoneARisque",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.EvenementZone",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .ZoneARisqueId = c.Long(nullable := False),
                        .EvenementId = c.Long(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Evenement", Function(t) t.EvenementId) _
                .ForeignKey("dbo.ZoneARisque", Function(t) t.ZoneARisqueId) _
                .Index(Function(t) t.ZoneARisqueId) _
                .Index(Function(t) t.EvenementId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.AutreImpactHumainEtEconomique",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .EvenementZoneId = c.Long(nullable := False),
                        .NombreDePersonneEvacue = c.Long(),
                        .NombreDePersonneAffecter = c.Long(),
                        .NombreDePersonneDirrectementAffecter = c.Long(),
                        .NombreDePersonneRelocaliser = c.Long(),
                        .TotalPerteEconomiqueLocalDevise = c.Double(),
                        .TotalPerteEconomiqueDolar = c.Double(),
                        .AutrePerte = c.String(),
                        .AmpleurDuDanger = c.String(),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.EvenementZone", Function(t) t.EvenementZoneId) _
                .Index(Function(t) t.EvenementZoneId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.CardreSendaiCibleA",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .EvenementZoneId = c.Long(nullable := False),
                        .NombreTotalDeces = c.Long(),
                        .NombreDecesFemme = c.Long(),
                        .NombreDecesHomme = c.Long(),
                        .NombreDecesEnfant = c.Long(),
                        .NombreDecesAdult = c.Long(),
                        .NombreDecesVieux = c.Long(),
                        .NombreDecesHandicape = c.Long(),
                        .NombreDecesPauvre = c.Long(),
                        .NombreTotalDisparue = c.Long(),
                        .NombreDisparueFemme = c.Long(),
                        .NombreDisparueHomme = c.Long(),
                        .NombreDisparueEnfant = c.Long(),
                        .NombreDisparueAdult = c.Long(),
                        .NombreDisparueVieux = c.Long(),
                        .NombreDisparueHandicape = c.Long(),
                        .NombreDisparuePauvre = c.Long(),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.EvenementZone", Function(t) t.EvenementZoneId) _
                .Index(Function(t) t.EvenementZoneId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.CardreSendaiCibleB",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .EvenementZoneId = c.Long(nullable := False),
                        .NombreTotalBlesse = c.Long(),
                        .NombreBlesseFemme = c.Long(),
                        .NombreBlesseHomme = c.Long(),
                        .NombreBlesseEnfant = c.Long(),
                        .NombreBlesseAdult = c.Long(),
                        .NombreBlesseVieux = c.Long(),
                        .NombreBlesseHandicape = c.Long(),
                        .NombreBlessePauvre = c.Long(),
                        .NombreTotalMaisonEndomage = c.Long(),
                        .NombreMaisonEndomageFemme = c.Long(),
                        .NombreMaisonEndomageHomme = c.Long(),
                        .NombreMaisonEndomageEnfant = c.Long(),
                        .NombreMaisonEndomageAdult = c.Long(),
                        .NombreMaisonEndomageVieux = c.Long(),
                        .NombreMaisonEndomageHandicape = c.Long(),
                        .NombreMaisonEndomagePauvre = c.Long(),
                        .NombreTotalMaisonDetruite = c.Long(),
                        .NombreMaisonDetruiteFemme = c.Long(),
                        .NombreMaisonDetruiteHomme = c.Long(),
                        .NombreMaisonDetruiteEnfant = c.Long(),
                        .NombreMaisonDetruiteAdult = c.Long(),
                        .NombreMaisonDetruiteVieux = c.Long(),
                        .NombreMaisonDetruiteHandicape = c.Long(),
                        .NombreMaisonDetruitePauvre = c.Long(),
                        .NombreTotalMoyenSubsistance = c.Long(),
                        .NombreMoyenSubsistanceFemme = c.Long(),
                        .NombreMoyenSubsistanceHomme = c.Long(),
                        .NombreMoyenSubsistanceEnfant = c.Long(),
                        .NombreMoyenSubsistanceAdult = c.Long(),
                        .NombreMoyenSubsistanceVieux = c.Long(),
                        .NombreMoyenSubsistanceHandicape = c.Long(),
                        .NombreMoyenSubsistancePauvre = c.Long(),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.EvenementZone", Function(t) t.EvenementZoneId) _
                .Index(Function(t) t.EvenementZoneId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.CardreSendaiCibleC",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .EvenementZoneId = c.Long(nullable := False),
                        .PerteTotalDeBetailTouche = c.Long(),
                        .NombreDanimauxToucheOuPerdu = c.Long(),
                        .NombreDanimauxToucher = c.Long(),
                        .NombreDanimauxPerdu = c.Long(),
                        .PerteEconomiqueDesCultureTouche = c.Double(),
                        .HectaresTautauxDesCulturesTouche = c.Double(),
                        .HectaresEndomages = c.Double(),
                        .HectaresDetruits = c.Double(),
                        .PerteEconomiqueSurForet = c.Double(),
                        .NombreTotalHectarForetToucher = c.Double(),
                        .NombreHectarForetEndomager = c.Double(),
                        .NombreHectarForetDetruit = c.Double(),
                        .PerteEconomiqueAquaculture = c.Double(),
                        .NombreTotalHectarAquacultureToucher = c.Double(),
                        .NombreHectarAquacultureEndomager = c.Double(),
                        .NombreHectarAquacultureDetruit = c.Double(),
                        .PerteEconomiqueDesNaviresAffecter = c.Double(),
                        .NombreTotalNavireToucher = c.Double(),
                        .NombreNavireEndomager = c.Double(),
                        .NombreNavireDetruit = c.Double(),
                        .PerteEconomiqueDesStockAgricole = c.Double(),
                        .NombreTotalDinstallationStockAgricoleToucher = c.Long(),
                        .NombreDinstallationStockAgricoleEndomager = c.Long(),
                        .NombreDinstallationStockAgricoleDetruit = c.Long(),
                        .PerteEconomiqueActifsProductifAfricole = c.Double(),
                        .NombreTotalActifsProductifAfricoleToucher = c.Long(),
                        .NombreActifsProductifAfricoleEndomager = c.Long(),
                        .NombreActifsProductifAfricoleDetruit = c.Long(),
                        .PerteEconomiqueActifsProductifs = c.Double(),
                        .NombreTotalInstallationActifsProductifsToucher = c.Long(),
                        .NombreInstallationActifsProductifsEndomager = c.Long(),
                        .NombreInstallationActifsProductifsDetruit = c.Long(),
                        .NombreTotalLogementEndommagerOuDetruit = c.Long(),
                        .TotalEconomiqueLogementEndomagerOuDetruit = c.Double(),
                        .ValeurEconomiqueDesMaisonsEndomager = c.Double(),
                        .ValeurEconomiqueDesMaisonsDetruites = c.Double(),
                        .PerteEconomiqueSecteurSante = c.Double(),
                        .PerteEconomiqueSecteurEducation = c.Double(),
                        .PerteEconomiqueInfrastructureToucher = c.Double(),
                        .CoutDeLaReabilitationHeritageCulturel = c.Double(),
                        .CoutDeLaReabilitationMobileDetruit = c.Double(),
                        .PerteEconomiqueDuAuActifsMobileDetruit = c.Double(),
                        .NombreDeMonumentImmobiliersEndomager = c.Long(),
                        .NombreMonumentImmobilierDetruits = c.Long(),
                        .NombreDeBiensCulturelMobileEndomager = c.Long(),
                        .NombreDeBiensCulturelMobileDetruits = c.Long(),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.EvenementZone", Function(t) t.EvenementZoneId) _
                .Index(Function(t) t.EvenementZoneId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.CibleCDesagregationAgricole",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .DesagregationRecoltesAgricoleId = c.Long(nullable := False),
                        .CardreSendaiCibleCId = c.Long(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.CardreSendaiCibleC", Function(t) t.CardreSendaiCibleCId) _
                .ForeignKey("dbo.DesagregationRecoltesAgricole", Function(t) t.DesagregationRecoltesAgricoleId) _
                .Index(Function(t) t.DesagregationRecoltesAgricoleId) _
                .Index(Function(t) t.CardreSendaiCibleCId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.DesagregationRecoltesAgricole",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .PerteEconomique = c.Double(),
                        .NombreHectarAfecter = c.Double(),
                        .NombreHectarEndomager = c.Double(),
                        .NombreHectarDetruit = c.Double(),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.CibleCPerteBetail",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .PerteBetailId = c.Long(nullable := False),
                        .CardreSendaiCibleCId = c.Long(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.CardreSendaiCibleC", Function(t) t.CardreSendaiCibleCId) _
                .ForeignKey("dbo.PerteBetail", Function(t) t.PerteBetailId) _
                .Index(Function(t) t.PerteBetailId) _
                .Index(Function(t) t.CardreSendaiCibleCId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.PerteBetail",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .PerteEconomique = c.Double(),
                        .NombreTotalAfecter = c.Long(),
                        .NombreTotalEndomager = c.Long(),
                        .NombreDetruitDetruit = c.Long(),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.CardreSendaiCibleD",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .EvenementZoneId = c.Long(nullable := False),
                        .NombreTotaldesEtablissementDeSanteTouche = c.Long(),
                        .NombreDesEtablissementsdeSanteEndommager = c.Long(),
                        .NombreDesEtablissementsdeSantedetruits = c.Long(),
                        .NombreTotaldesEtablissementEducationTouche = c.Long(),
                        .NombreDesEtablissementsEducationEndommager = c.Long(),
                        .NombreDesEtablissementsEducationDetruits = c.Long(),
                        .NombreTotalAutreInfrastructureTouche = c.Long(),
                        .NombreAutreInfrastructureEndommager = c.Long(),
                        .NombreAutreInfrastructureDetruits = c.Long(),
                        .PerteEconomiqueDuAuRoutes = c.Long(),
                        .NombreTotalRoutesTouche = c.Long(),
                        .NombreRoutesEndommager = c.Long(),
                        .NombreRoutesDetruits = c.Long(),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.EvenementZone", Function(t) t.EvenementZoneId) _
                .Index(Function(t) t.EvenementZoneId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.CibleDServicesPublique",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .ServicesPubliquePertubeId = c.Long(nullable := False),
                        .CardreSendaiCibleDId = c.Long(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.CardreSendaiCibleD", Function(t) t.CardreSendaiCibleDId) _
                .ForeignKey("dbo.ServicesPubliquePertube", Function(t) t.ServicesPubliquePertubeId) _
                .Index(Function(t) t.ServicesPubliquePertubeId) _
                .Index(Function(t) t.CardreSendaiCibleDId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.ServicesPubliquePertube",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Evenement",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.FacteurEvenement",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .FacteurId = c.Long(nullable := False),
                        .EvenementId = c.Long(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Evenement", Function(t) t.EvenementId) _
                .ForeignKey("dbo.Facteur", Function(t) t.FacteurId) _
                .Index(Function(t) t.FacteurId) _
                .Index(Function(t) t.EvenementId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Facteur",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Solution",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .TypeSolutionId = c.Long(nullable := False),
                        .EvenementZoneId = c.Long(nullable := False),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .Description = c.String(),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.EvenementZone", Function(t) t.EvenementZoneId) _
                .ForeignKey("dbo.TypeSolution", Function(t) t.TypeSolutionId) _
                .Index(Function(t) t.TypeSolutionId) _
                .Index(Function(t) t.EvenementZoneId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.TypeSolution",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.NiveauDAlert",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.RisqueZone",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .RisqueId = c.Long(nullable := False),
                        .ZoneARisqueId = c.Long(nullable := False),
                        .NiveauDAlertId = c.Long(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.NiveauDAlert", Function(t) t.NiveauDAlertId) _
                .ForeignKey("dbo.Risque", Function(t) t.RisqueId) _
                .ForeignKey("dbo.ZoneARisque", Function(t) t.ZoneARisqueId) _
                .Index(Function(t) t.RisqueId) _
                .Index(Function(t) t.ZoneARisqueId) _
                .Index(Function(t) t.NiveauDAlertId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Risque",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .Index(Function(t) t.AspNetUserId)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.RisqueZone", "ZoneARisqueId", "dbo.ZoneARisque")
            DropForeignKey("dbo.RisqueZone", "RisqueId", "dbo.Risque")
            DropForeignKey("dbo.Risque", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.RisqueZone", "NiveauDAlertId", "dbo.NiveauDAlert")
            DropForeignKey("dbo.RisqueZone", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.NiveauDAlert", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.ZoneLocalisation", "ZoneARisqueId", "dbo.ZoneARisque")
            DropForeignKey("dbo.EvenementZone", "ZoneARisqueId", "dbo.ZoneARisque")
            DropForeignKey("dbo.Solution", "TypeSolutionId", "dbo.TypeSolution")
            DropForeignKey("dbo.TypeSolution", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Solution", "EvenementZoneId", "dbo.EvenementZone")
            DropForeignKey("dbo.Solution", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.FacteurEvenement", "FacteurId", "dbo.Facteur")
            DropForeignKey("dbo.Facteur", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.FacteurEvenement", "EvenementId", "dbo.Evenement")
            DropForeignKey("dbo.FacteurEvenement", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.EvenementZone", "EvenementId", "dbo.Evenement")
            DropForeignKey("dbo.Evenement", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.CardreSendaiCibleD", "EvenementZoneId", "dbo.EvenementZone")
            DropForeignKey("dbo.CibleDServicesPublique", "ServicesPubliquePertubeId", "dbo.ServicesPubliquePertube")
            DropForeignKey("dbo.ServicesPubliquePertube", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.CibleDServicesPublique", "CardreSendaiCibleDId", "dbo.CardreSendaiCibleD")
            DropForeignKey("dbo.CibleDServicesPublique", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.CardreSendaiCibleD", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.CardreSendaiCibleC", "EvenementZoneId", "dbo.EvenementZone")
            DropForeignKey("dbo.CibleCPerteBetail", "PerteBetailId", "dbo.PerteBetail")
            DropForeignKey("dbo.PerteBetail", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.CibleCPerteBetail", "CardreSendaiCibleCId", "dbo.CardreSendaiCibleC")
            DropForeignKey("dbo.CibleCPerteBetail", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.CibleCDesagregationAgricole", "DesagregationRecoltesAgricoleId", "dbo.DesagregationRecoltesAgricole")
            DropForeignKey("dbo.DesagregationRecoltesAgricole", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.CibleCDesagregationAgricole", "CardreSendaiCibleCId", "dbo.CardreSendaiCibleC")
            DropForeignKey("dbo.CibleCDesagregationAgricole", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.CardreSendaiCibleC", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.CardreSendaiCibleB", "EvenementZoneId", "dbo.EvenementZone")
            DropForeignKey("dbo.CardreSendaiCibleB", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.CardreSendaiCibleA", "EvenementZoneId", "dbo.EvenementZone")
            DropForeignKey("dbo.CardreSendaiCibleA", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.AutreImpactHumainEtEconomique", "EvenementZoneId", "dbo.EvenementZone")
            DropForeignKey("dbo.AutreImpactHumainEtEconomique", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.EvenementZone", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.ZoneARisque", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.ZoneLocalisation", "QuartierId", "dbo.Quartier")
            DropForeignKey("dbo.ZoneLocalisation", "AspNetUserId", "dbo.AspNetUsers")
            DropIndex("dbo.Risque", New String() { "AspNetUserId" })
            DropIndex("dbo.RisqueZone", New String() { "AspNetUserId" })
            DropIndex("dbo.RisqueZone", New String() { "NiveauDAlertId" })
            DropIndex("dbo.RisqueZone", New String() { "ZoneARisqueId" })
            DropIndex("dbo.RisqueZone", New String() { "RisqueId" })
            DropIndex("dbo.NiveauDAlert", New String() { "AspNetUserId" })
            DropIndex("dbo.TypeSolution", New String() { "AspNetUserId" })
            DropIndex("dbo.Solution", New String() { "AspNetUserId" })
            DropIndex("dbo.Solution", New String() { "EvenementZoneId" })
            DropIndex("dbo.Solution", New String() { "TypeSolutionId" })
            DropIndex("dbo.Facteur", New String() { "AspNetUserId" })
            DropIndex("dbo.FacteurEvenement", New String() { "AspNetUserId" })
            DropIndex("dbo.FacteurEvenement", New String() { "EvenementId" })
            DropIndex("dbo.FacteurEvenement", New String() { "FacteurId" })
            DropIndex("dbo.Evenement", New String() { "AspNetUserId" })
            DropIndex("dbo.ServicesPubliquePertube", New String() { "AspNetUserId" })
            DropIndex("dbo.CibleDServicesPublique", New String() { "AspNetUserId" })
            DropIndex("dbo.CibleDServicesPublique", New String() { "CardreSendaiCibleDId" })
            DropIndex("dbo.CibleDServicesPublique", New String() { "ServicesPubliquePertubeId" })
            DropIndex("dbo.CardreSendaiCibleD", New String() { "AspNetUserId" })
            DropIndex("dbo.CardreSendaiCibleD", New String() { "EvenementZoneId" })
            DropIndex("dbo.PerteBetail", New String() { "AspNetUserId" })
            DropIndex("dbo.CibleCPerteBetail", New String() { "AspNetUserId" })
            DropIndex("dbo.CibleCPerteBetail", New String() { "CardreSendaiCibleCId" })
            DropIndex("dbo.CibleCPerteBetail", New String() { "PerteBetailId" })
            DropIndex("dbo.DesagregationRecoltesAgricole", New String() { "AspNetUserId" })
            DropIndex("dbo.CibleCDesagregationAgricole", New String() { "AspNetUserId" })
            DropIndex("dbo.CibleCDesagregationAgricole", New String() { "CardreSendaiCibleCId" })
            DropIndex("dbo.CibleCDesagregationAgricole", New String() { "DesagregationRecoltesAgricoleId" })
            DropIndex("dbo.CardreSendaiCibleC", New String() { "AspNetUserId" })
            DropIndex("dbo.CardreSendaiCibleC", New String() { "EvenementZoneId" })
            DropIndex("dbo.CardreSendaiCibleB", New String() { "AspNetUserId" })
            DropIndex("dbo.CardreSendaiCibleB", New String() { "EvenementZoneId" })
            DropIndex("dbo.CardreSendaiCibleA", New String() { "AspNetUserId" })
            DropIndex("dbo.CardreSendaiCibleA", New String() { "EvenementZoneId" })
            DropIndex("dbo.AutreImpactHumainEtEconomique", New String() { "AspNetUserId" })
            DropIndex("dbo.AutreImpactHumainEtEconomique", New String() { "EvenementZoneId" })
            DropIndex("dbo.EvenementZone", New String() { "AspNetUserId" })
            DropIndex("dbo.EvenementZone", New String() { "EvenementId" })
            DropIndex("dbo.EvenementZone", New String() { "ZoneARisqueId" })
            DropIndex("dbo.ZoneARisque", New String() { "AspNetUserId" })
            DropIndex("dbo.ZoneLocalisation", New String() { "AspNetUserId" })
            DropIndex("dbo.ZoneLocalisation", New String() { "QuartierId" })
            DropIndex("dbo.ZoneLocalisation", New String() { "ZoneARisqueId" })
            DropTable("dbo.Risque")
            DropTable("dbo.RisqueZone")
            DropTable("dbo.NiveauDAlert")
            DropTable("dbo.TypeSolution")
            DropTable("dbo.Solution")
            DropTable("dbo.Facteur")
            DropTable("dbo.FacteurEvenement")
            DropTable("dbo.Evenement")
            DropTable("dbo.ServicesPubliquePertube")
            DropTable("dbo.CibleDServicesPublique")
            DropTable("dbo.CardreSendaiCibleD")
            DropTable("dbo.PerteBetail")
            DropTable("dbo.CibleCPerteBetail")
            DropTable("dbo.DesagregationRecoltesAgricole")
            DropTable("dbo.CibleCDesagregationAgricole")
            DropTable("dbo.CardreSendaiCibleC")
            DropTable("dbo.CardreSendaiCibleB")
            DropTable("dbo.CardreSendaiCibleA")
            DropTable("dbo.AutreImpactHumainEtEconomique")
            DropTable("dbo.EvenementZone")
            DropTable("dbo.ZoneARisque")
            DropTable("dbo.ZoneLocalisation")
        End Sub
    End Class
End Namespace
