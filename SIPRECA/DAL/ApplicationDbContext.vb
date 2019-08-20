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
        modelBuilder.Configurations.Add(New AdresseCfg())
        modelBuilder.Configurations.Add(New AnneeBudgetaireCfg())
        modelBuilder.Configurations.Add(New ArticleCfg())
        modelBuilder.Configurations.Add(New BudgetCollectiviteCfg())
        modelBuilder.Configurations.Add(New BureauCfg())
        modelBuilder.Configurations.Add(New CategorieDArticleCfg())
        modelBuilder.Configurations.Add(New CausesCfg())
        modelBuilder.Configurations.Add(New ChampsCfg())
        modelBuilder.Configurations.Add(New PropositionCfg())
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
        modelBuilder.Configurations.Add(New EnqueteCfg())
        modelBuilder.Configurations.Add(New EntrepotsCfg())
        modelBuilder.Configurations.Add(New FormulaireCfg())
        modelBuilder.Configurations.Add(New IndemnisationCfg())
        modelBuilder.Configurations.Add(New InstallationCfg())
        modelBuilder.Configurations.Add(New MaladieCfg())
        modelBuilder.Configurations.Add(New MaladieSinistreCfg())
        modelBuilder.Configurations.Add(New MoyenCfg())
        modelBuilder.Configurations.Add(New NatureAideCfg())
        modelBuilder.Configurations.Add(New NiveauDeRepresentationCfg())
        modelBuilder.Configurations.Add(New OrganisationCfg())
        modelBuilder.Configurations.Add(New PaysCfg())
        modelBuilder.Configurations.Add(New PersonnelCfg())
        modelBuilder.Configurations.Add(New PieceJointeCfg())
        modelBuilder.Configurations.Add(New PrioriteCfg())
        modelBuilder.Configurations.Add(New ProjetCfg())
        modelBuilder.Configurations.Add(New QuartierCfg())
        modelBuilder.Configurations.Add(New RegionCfg())
        modelBuilder.Configurations.Add(New SecteurCfg())
        modelBuilder.Configurations.Add(New SectionCfg())
        modelBuilder.Configurations.Add(New SinistreCfg())
        modelBuilder.Configurations.Add(New SinistrerCfg())
        modelBuilder.Configurations.Add(New SiteCfg())
        modelBuilder.Configurations.Add(New SuiviCfg())
        modelBuilder.Configurations.Add(New TacheCfg())
        modelBuilder.Configurations.Add(New TypeAbrisCfg())
        modelBuilder.Configurations.Add(New TypeAideCfg())
        modelBuilder.Configurations.Add(New TypeChampsCfg())
        modelBuilder.Configurations.Add(New TypeMoyenCfg())
        modelBuilder.Configurations.Add(New TypeOfficeCfg())
        modelBuilder.Configurations.Add(New TypeOrganisationCfg())
        modelBuilder.Configurations.Add(New TypePersonnelCfg())
        modelBuilder.Configurations.Add(New TypeSinistreCfg())
        modelBuilder.Configurations.Add(New TypeSuiviCfg())
        modelBuilder.Configurations.Add(New ValeurChampsCfg())
        modelBuilder.Configurations.Add(New VilleCfg())
        modelBuilder.Configurations.Add(New ZoneCfg())
    End Sub

    Public Property Abris() As DbSet(Of Abris)
    Public Property Adresse() As DbSet(Of Adresse)
    Public Property AnneeBudgetaires() As DbSet(Of AnneeBudgetaire)
    Public Property Article() As DbSet(Of Article)
    Public Property BudgetCollectivite() As DbSet(Of BudgetCollectivite)
    Public Property Bureau() As DbSet(Of Bureau)
    Public Property CategorieDArticle() As DbSet(Of CategorieDArticle)
    Public Property Causes() As DbSet(Of Causes)
    Public Property Champs() As DbSet(Of Champs)
    Public Property Proposition() As DbSet(Of Proposition)
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
    Public Property Enquete() As DbSet(Of Enquete)
    Public Property Entrepots() As DbSet(Of Entrepots)
    Public Property Formulaire() As DbSet(Of Formulaire)
    Public Property Indemnisation() As DbSet(Of Indemnisation)
    Public Property Installation() As DbSet(Of Installation)
    Public Property Maladie() As DbSet(Of Maladie)
    Public Property MaladieSinistre() As DbSet(Of MaladieSinistre)
    Public Property Moyen() As DbSet(Of Moyen)
    Public Property NatureAide() As DbSet(Of NatureAide)
    Public Property NiveauDeRepresentation() As DbSet(Of NiveauDeRepresentation)
    Public Property Organisation() As DbSet(Of Organisation)
    Public Property Pays() As DbSet(Of Pays)
    Public Property Personnel() As DbSet(Of Personnel)
    Public Property PieceJointe() As DbSet(Of PieceJointe)
    Public Property Priorite() As DbSet(Of Priorite)
    Public Property Projet() As DbSet(Of Projet)
    Public Property Quartier() As DbSet(Of Quartier)
    Public Property Region() As DbSet(Of Region)
    Public Property Secteur() As DbSet(Of Secteur)
    Public Property Section() As DbSet(Of Section)
    Public Property Sinistre() As DbSet(Of Sinistre)
    Public Property Sinistrer() As DbSet(Of Sinistrer)
    Public Property Site() As DbSet(Of Site)
    Public Property Suivi() As DbSet(Of Suivi)
    Public Property Tache() As DbSet(Of Tache)
    Public Property TypeAbris() As DbSet(Of TypeAbris)
    Public Property TypeAide() As DbSet(Of TypeAide)
    Public Property TypeChamps() As DbSet(Of TypeChamps)
    Public Property TypeMoyen() As DbSet(Of TypeMoyen)
    Public Property TypeOffice() As DbSet(Of TypeOffice)
    Public Property TypeOrganisation() As DbSet(Of TypeOrganisation)
    Public Property TypePersonnel() As DbSet(Of TypePersonnel)
    Public Property TypeSinistre() As DbSet(Of TypeSinistre)
    Public Property TypeSuivi() As DbSet(Of TypeSuivi)
    Public Property ValeurChamps() As DbSet(Of ValeurChamps)
    Public Property Ville() As DbSet(Of Ville)
    Public Property Zone() As DbSet(Of Zone)
End Class