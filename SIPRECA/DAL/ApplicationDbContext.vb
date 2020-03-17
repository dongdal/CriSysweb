﻿Imports Microsoft.AspNet.Identity.EntityFramework
Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions

Public Class ApplicationDbContext
    Inherits IdentityDbContext(Of ApplicationUser)

    'Public Sub New()
    '    MyBase.New("DefaultConnection")
    'End Sub

    Public Sub New()
        MyBase.New("DefaultConnection", throwIfV1Schema:=False)
    End Sub

    Public Shared Function Create() As ApplicationDbContext
        Return New ApplicationDbContext()
    End Function

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)
        modelBuilder.Conventions.Remove(Of OneToManyCascadeDeleteConvention)()
        modelBuilder.Configurations.Add(New AbrisCfg())
        modelBuilder.Configurations.Add(New AlertCfg())
        modelBuilder.Configurations.Add(New AeroportCfg())
        'modelBuilder.Configurations.Add(New AdresseCfg())
        modelBuilder.Configurations.Add(New AnneeBudgetaireCfg())
        modelBuilder.Configurations.Add(New ArticleCfg())
        modelBuilder.Configurations.Add(New BudgetCollectiviteCfg())
        modelBuilder.Configurations.Add(New BureauCfg())
        modelBuilder.Configurations.Add(New BordereauTransfertCfg())
        modelBuilder.Configurations.Add(New BordereauTransfertDemandeCfg())
        modelBuilder.Configurations.Add(New CategorieDArticleCfg())
        modelBuilder.Configurations.Add(New CategorieElementCfg())
        modelBuilder.Configurations.Add(New CausesCfg())
        modelBuilder.Configurations.Add(New ChampsCfg())
        modelBuilder.Configurations.Add(New CollecteCfg())
        modelBuilder.Configurations.Add(New CollectiviteCfg())
        modelBuilder.Configurations.Add(New CollectiviteSinistreeCfg())
        modelBuilder.Configurations.Add(New CommuneCfg())
        modelBuilder.Configurations.Add(New CompetanceCfg())
        modelBuilder.Configurations.Add(New DemandeCfg())
        modelBuilder.Configurations.Add(New DemandeArticleCfg())
        modelBuilder.Configurations.Add(New DemandeDArticleCfg())
        modelBuilder.Configurations.Add(New DepartementCfg())
        modelBuilder.Configurations.Add(New DetailsIndemnisationCfg())
        modelBuilder.Configurations.Add(New DeviseCfg())
        modelBuilder.Configurations.Add(New ElementCfg())
        modelBuilder.Configurations.Add(New EnqueteCfg())
        modelBuilder.Configurations.Add(New EntrepotsCfg())
        modelBuilder.Configurations.Add(New FormulaireCfg())
        modelBuilder.Configurations.Add(New HeliportCfg())
        modelBuilder.Configurations.Add(New HopitauxCfg())
        modelBuilder.Configurations.Add(New HopitauxPuissanceCfg())
        modelBuilder.Configurations.Add(New ImmobilisationCfg())
        modelBuilder.Configurations.Add(New IndemnisationCfg())
        modelBuilder.Configurations.Add(New InfrastructureCfg())
        modelBuilder.Configurations.Add(New InstallationCfg())
        modelBuilder.Configurations.Add(New MaladieCfg())
        modelBuilder.Configurations.Add(New MaladieSinistreCfg())
        modelBuilder.Configurations.Add(New MarqueElementCfg())
        modelBuilder.Configurations.Add(New MaterielCfg())
        modelBuilder.Configurations.Add(New MaterielAbrisCfg())
        modelBuilder.Configurations.Add(New MaterielHopitauxCfg())
        modelBuilder.Configurations.Add(New MaterielHeliportCfg())
        modelBuilder.Configurations.Add(New MaterielPortDeMerCfg())
        modelBuilder.Configurations.Add(New MaterielAeroportCfg())
        modelBuilder.Configurations.Add(New MaterielBureauCfg())
        modelBuilder.Configurations.Add(New MaterielInstallationCfg())
        modelBuilder.Configurations.Add(New MaterielEntrepotsCfg())
        modelBuilder.Configurations.Add(New MoyenCfg())
        modelBuilder.Configurations.Add(New NatureAideCfg())
        modelBuilder.Configurations.Add(New NiveauDeRepresentationCfg())
        modelBuilder.Configurations.Add(New OrganisationCfg())
        modelBuilder.Configurations.Add(New PaysCfg())
        modelBuilder.Configurations.Add(New PersonnelCfg())
        modelBuilder.Configurations.Add(New PersonnelAbrisCfg())
        modelBuilder.Configurations.Add(New PersonnelBureauCfg())
        modelBuilder.Configurations.Add(New PersonnelInstallationCfg())
        modelBuilder.Configurations.Add(New PersonnelProjetCfg())
        modelBuilder.Configurations.Add(New PieceJointeCfg())
        modelBuilder.Configurations.Add(New PortDeMerCfg())
        modelBuilder.Configurations.Add(New PrioriteCfg())
        modelBuilder.Configurations.Add(New ProjetCfg())
        modelBuilder.Configurations.Add(New PropositionCfg())
        modelBuilder.Configurations.Add(New PuissanceCfg())
        modelBuilder.Configurations.Add(New QuartierCfg())
        modelBuilder.Configurations.Add(New RegionCfg())
        modelBuilder.Configurations.Add(New SecteurCfg())
        modelBuilder.Configurations.Add(New SecteurProjetCfg())
        modelBuilder.Configurations.Add(New SectionCfg())
        modelBuilder.Configurations.Add(New SinistreCfg())
        modelBuilder.Configurations.Add(New SinistrerCfg())
        modelBuilder.Configurations.Add(New SiteCfg())
        modelBuilder.Configurations.Add(New SuiviCfg())
        modelBuilder.Configurations.Add(New SurfaceDePisteCfg())
        modelBuilder.Configurations.Add(New TacheCfg())
        modelBuilder.Configurations.Add(New TailleDeAeronefCfg())
        modelBuilder.Configurations.Add(New TypeAbrisCfg())
        modelBuilder.Configurations.Add(New TypeAideCfg())
        modelBuilder.Configurations.Add(New TypeChampsCfg())
        modelBuilder.Configurations.Add(New TypeEntrepotCfg())
        modelBuilder.Configurations.Add(New TypeHopitauxCfg())
        modelBuilder.Configurations.Add(New TypeImmobilisationCfg())
        modelBuilder.Configurations.Add(New TypeMoyenCfg())
        modelBuilder.Configurations.Add(New TypeOfficeCfg())
        modelBuilder.Configurations.Add(New TypeOrganisationCfg())
        modelBuilder.Configurations.Add(New TypePersonnelCfg())
        modelBuilder.Configurations.Add(New TypeSinistreCfg())
        modelBuilder.Configurations.Add(New UsageHumanitaireCfg())
        modelBuilder.Configurations.Add(New TypeSuiviCfg())
        modelBuilder.Configurations.Add(New TypeVehiculeCfg())
        modelBuilder.Configurations.Add(New ValeurChampsCfg())
        modelBuilder.Configurations.Add(New VehiculeCfg())
        modelBuilder.Configurations.Add(New VilleCfg())
        modelBuilder.Configurations.Add(New ZoneCfg())

        '-----------------------------------------------------------------------------START DESINVENTAR-----------------------------------------------------------------------------
        modelBuilder.Configurations.Add(New AutreImpactHumainEtEconomiqueCfg())
        modelBuilder.Configurations.Add(New CardreSendaiCibleACfg())
        modelBuilder.Configurations.Add(New CardreSendaiCibleBCfg())
        modelBuilder.Configurations.Add(New CardreSendaiCibleCCfg())
        modelBuilder.Configurations.Add(New CardreSendaiCibleCDfg())
        modelBuilder.Configurations.Add(New CibleCDesagregationAgricoleCfg())
        modelBuilder.Configurations.Add(New CibleCPerteBetailCfg())
        modelBuilder.Configurations.Add(New CibleDServicesPubliqueCfg())
        modelBuilder.Configurations.Add(New DesagregationRecoltesAgricoleCfg())
        modelBuilder.Configurations.Add(New EvenementCfg())
        modelBuilder.Configurations.Add(New EvenementZoneCfg())
        modelBuilder.Configurations.Add(New FacteurCfg())
        modelBuilder.Configurations.Add(New FacteurEvenementCfg())
        modelBuilder.Configurations.Add(New NiveauDAlertCfg())
        modelBuilder.Configurations.Add(New PerteBetailCfg())
        modelBuilder.Configurations.Add(New RisqueCfg())
        modelBuilder.Configurations.Add(New RisqueZoneCfg())
        modelBuilder.Configurations.Add(New ServicesPubliquePertubeCfg())
        modelBuilder.Configurations.Add(New SolutionCfg())
        modelBuilder.Configurations.Add(New TypeSolutionCfg())
        modelBuilder.Configurations.Add(New ZoneARisqueCfg())
        modelBuilder.Configurations.Add(New ZoneLocalisationCfg())

        '-----------------------------------------------------------------------------END DESINVENTAR-----------------------------------------------------------------------------

        '-----------------------------------------------------------------------------START ACCES RULES-----------------------------------------------------------------------------
        modelBuilder.Configurations.Add(New ActionsCfg())
        modelBuilder.Configurations.Add(New ActionSousRessourceCfg())
        modelBuilder.Configurations.Add(New ModuleRoleCfg())
        modelBuilder.Configurations.Add(New ModulesCfg())
        modelBuilder.Configurations.Add(New RessourceCfg())
        modelBuilder.Configurations.Add(New SousRessourceCfg())
        '-----------------------------------------------------------------------------END ACCES RULES-----------------------------------------------------------------------------

    End Sub

    Public Property Abris() As DbSet(Of Abris)
    ' Public Property Adresse() As DbSet(Of Adresse)
    Public Property Alert() As DbSet(Of Alert)
    Public Property Aeroport() As DbSet(Of Aeroport)
    Public Property AnneeBudgetaires() As DbSet(Of AnneeBudgetaire)
    Public Property Article() As DbSet(Of Article)
    Public Property BudgetCollectivite() As DbSet(Of BudgetCollectivite)
    Public Property BordereauTransfert() As DbSet(Of BordereauTransfert)
    Public Property BordereauTransfertDemande() As DbSet(Of BordereauTransfertDemande)
    Public Property Bureau() As DbSet(Of Bureau)
    Public Property CategorieDArticle() As DbSet(Of CategorieDArticle)
    Public Property CategorieElement() As DbSet(Of CategorieElement)
    Public Property Causes() As DbSet(Of Causes)
    Public Property Champs() As DbSet(Of Champs)
    Public Property Collecte() As DbSet(Of Collecte)
    Public Property Collectivite() As DbSet(Of Collectivite)
    Public Property CollectiviteSinistree() As DbSet(Of CollectiviteSinistree)
    Public Property Commune() As DbSet(Of Commune)
    Public Property Competance() As DbSet(Of Competance)
    Public Property Demande() As DbSet(Of Demande)
    Public Property DemandeArticle() As DbSet(Of DemandeArticle)
    Public Property DemandeDArticle() As DbSet(Of DemandeDArticle)
    Public Property Departement() As DbSet(Of Departement)
    Public Property DetailsIndemnisation() As DbSet(Of DetailsIndemnisation)
    Public Property Devise() As DbSet(Of Devise)
    Public Property Element() As DbSet(Of Element)
    Public Property Enquete() As DbSet(Of Enquete)
    Public Property Entrepots() As DbSet(Of Entrepots)
    Public Property Formulaire() As DbSet(Of Formulaire)
    Public Property Heliport() As DbSet(Of Heliport)
    Public Property Hopitaux() As DbSet(Of Hopitaux)
    Public Property HopitauxPuissance() As DbSet(Of HopitauxPuissance)
    Public Property Immobilisation() As DbSet(Of Immobilisation)
    Public Property Indemnisation() As DbSet(Of Indemnisation)
    Public Property Infrastructure() As DbSet(Of Infrastructure)
    Public Property Installation() As DbSet(Of Installation)
    Public Property Maladie() As DbSet(Of Maladie)
    Public Property MaladieSinistre() As DbSet(Of MaladieSinistre)
    Public Property MarqueElement() As DbSet(Of MarqueElement)
    Public Property Materiel() As DbSet(Of Materiel)
    Public Property MaterielMaterielAbris() As DbSet(Of MaterielAbris)
    Public Property MaterielHopitaux() As DbSet(Of MaterielHopitaux)
    Public Property MaterielHeliport() As DbSet(Of MaterielHeliport)
    Public Property MaterielPortDeMer() As DbSet(Of MaterielPortDeMer)
    Public Property MaterielAeroport() As DbSet(Of MaterielAeroport)
    Public Property MaterielBureau() As DbSet(Of MaterielBureau)
    Public Property MaterielInstallation() As DbSet(Of MaterielInstallation)
    Public Property MaterielEntrepots() As DbSet(Of MaterielEntrepots)
    Public Property Moyen() As DbSet(Of Moyen)
    Public Property NatureAide() As DbSet(Of NatureAide)
    Public Property NiveauDeRepresentation() As DbSet(Of NiveauDeRepresentation)
    Public Property Organisation() As DbSet(Of Organisation)
    Public Property Pays() As DbSet(Of Pays)
    Public Property PersonnelAbris() As DbSet(Of PersonnelAbris)
    Public Property PersonnelBureau() As DbSet(Of PersonnelBureau)
    Public Property Personnel() As DbSet(Of Personnel)
    Public Property PersonnelInstallation() As DbSet(Of PersonnelInstallation)
    Public Property PersonnelProjet() As DbSet(Of PersonnelProjet)
    Public Property PieceJointe() As DbSet(Of PieceJointe)
    Public Property PortDeMer() As DbSet(Of PortDeMer)
    Public Property Priorite() As DbSet(Of Priorite)
    Public Property Projet() As DbSet(Of Projet)
    Public Property Proposition() As DbSet(Of Proposition)
    Public Property Puissance() As DbSet(Of Puissance)
    Public Property Quartier() As DbSet(Of Quartier)
    Public Property Region() As DbSet(Of Region)
    Public Property Secteur() As DbSet(Of Secteur)
    Public Property SecteurProjet() As DbSet(Of SecteurProjet)
    Public Property Section() As DbSet(Of Section)
    Public Property Sinistre() As DbSet(Of Sinistre)
    Public Property Sinistrer() As DbSet(Of Sinistrer)
    Public Property Site() As DbSet(Of Site)
    Public Property Suivi() As DbSet(Of Suivi)
    Public Property SurfaceDePiste() As DbSet(Of SurfaceDePiste)
    Public Property Tache() As DbSet(Of Tache)
    Public Property TailleDeAeronef() As DbSet(Of TailleDeAeronef)
    Public Property TypeAbris() As DbSet(Of TypeAbris)
    Public Property TypeAide() As DbSet(Of TypeAide)
    Public Property TypeChamps() As DbSet(Of TypeChamps)
    Public Property TypeEntrepot() As DbSet(Of TypeEntrepot)
    Public Property TypeHopitaux() As DbSet(Of TypeHopitaux)
    Public Property TypeImmobilisation() As DbSet(Of TypeImmobilisation)
    Public Property TypeMoyen() As DbSet(Of TypeMoyen)
    Public Property TypeOffice() As DbSet(Of TypeOffice)
    Public Property TypeOrganisation() As DbSet(Of TypeOrganisation)
    Public Property TypePersonnel() As DbSet(Of TypePersonnel)
    Public Property TypeSinistre() As DbSet(Of TypeSinistre)
    Public Property TypeSuivi() As DbSet(Of TypeSuivi)
    Public Property TypeVehicule() As DbSet(Of TypeVehicule)
    Public Property UsageHumanitaire() As DbSet(Of UsageHumanitaire)
    Public Property ValeurChamps() As DbSet(Of ValeurChamps)
    Public Property Vehicule() As DbSet(Of Vehicule)
    Public Property Ville() As DbSet(Of Ville)
    Public Property Zone() As DbSet(Of Zone)

    '-----------------------------------------------------------------------------START DESINVENTAR-----------------------------------------------------------------------------
    Public Property AutreImpactHumainEtEconomique() As DbSet(Of AutreImpactHumainEtEconomique)
    Public Property CardreSendaiCibleA() As DbSet(Of CardreSendaiCibleA)
    Public Property CardreSendaiCibleB() As DbSet(Of CardreSendaiCibleB)
    Public Property CardreSendaiCibleC() As DbSet(Of CardreSendaiCibleC)
    Public Property CardreSendaiCibleD() As DbSet(Of CardreSendaiCibleD)
    Public Property CibleCDesagregationAgricole() As DbSet(Of CibleCDesagregationAgricole)
    Public Property CibleCPerteBetail() As DbSet(Of CibleCPerteBetail)
    Public Property CibleDServicesPublique() As DbSet(Of CibleDServicesPublique)
    Public Property DesagregationRecoltesAgricole() As DbSet(Of DesagregationRecoltesAgricole)
    Public Property Evenement() As DbSet(Of Evenement)
    Public Property EvenementZone() As DbSet(Of EvenementZone)
    Public Property Facteur() As DbSet(Of Facteur)
    Public Property FacteurEvenement() As DbSet(Of FacteurEvenement)
    Public Property NiveauDAlert() As DbSet(Of NiveauDAlert)
    Public Property PerteBetail() As DbSet(Of PerteBetail)
    Public Property Risque() As DbSet(Of Risque)
    Public Property RisqueZone() As DbSet(Of RisqueZone)
    Public Property ServicesPubliquePertube() As DbSet(Of ServicesPubliquePertube)
    Public Property Solution() As DbSet(Of Solution)
    Public Property TypeSolution() As DbSet(Of TypeSolution)
    Public Property ZoneARisque() As DbSet(Of ZoneARisque)
    Public Property ZoneLocalisation() As DbSet(Of ZoneLocalisation)
    '-----------------------------------------------------------------------------END DESINVENTAR-----------------------------------------------------------------------------

    '-----------------------------------------------------------------------------START ACCES RULES-----------------------------------------------------------------------------
    Public Property Actions() As DbSet(Of Actions)
    Public Property ActionSousRessource() As DbSet(Of ActionSousRessource)
    Public Property ModuleRole() As DbSet(Of ModuleRole)
    Public Property Modules() As DbSet(Of Modules)
    Public Property Ressource() As DbSet(Of Ressource)
    Public Property SousRessource() As DbSet(Of SousRessource)
    Public Property IdentityUserRole() As DbSet(Of IdentityUserRole)
    '-----------------------------------------------------------------------------END ACCES RULES-----------------------------------------------------------------------------


End Class
