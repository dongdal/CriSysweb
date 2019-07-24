Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class CreateDataBase
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Abris",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .OganisationId = c.Long(nullable := False),
                        .TypeAbrisId = c.Long(nullable := False),
                        .AdresseId = c.Long(nullable := False),
                        .Nom = c.String(nullable := False, maxLength := 250),
                        .EstimationPopulation = c.Long(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Oganisation", Function(t) t.OganisationId) _
                .ForeignKey("dbo.TypeAbris", Function(t) t.TypeAbrisId) _
                .ForeignKey("dbo.Adresse", Function(t) t.AdresseId) _
                .Index(Function(t) t.OganisationId) _
                .Index(Function(t) t.TypeAbrisId) _
                .Index(Function(t) t.AdresseId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Adresse",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .CollectiviteId = c.Long(nullable := False),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .Location = c.Geography(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Collectivite", Function(t) t.CollectiviteId) _
                .Index(Function(t) t.CollectiviteId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.AspNetUsers",
                Function(c) New With
                    {
                        .Id = c.String(nullable := False, maxLength := 128),
                        .UserName = c.String(nullable := False),
                        .PasswordHash = c.String(),
                        .SecurityStamp = c.String(),
                        .Nom = c.String(),
                        .Prenom = c.String(),
                        .Sexe = c.String(),
                        .DateNaissance = c.DateTime(),
                        .LieuNaissance = c.String(),
                        .CNI = c.String(),
                        .DateDelivranceCNI = c.DateTime(),
                        .DateExpirationCNI = c.DateTime(),
                        .AdresseUser = c.String(),
                        .Telephone = c.String(),
                        .Telephone2 = c.String(),
                        .Email = c.String(),
                        .DateCreation = c.DateTime(),
                        .Etat = c.Short(),
                        .Discriminator = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            CreateTable(
                "dbo.AnneeBudgetaire",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .DateDebut = c.DateTime(nullable := False),
                        .DateFin = c.DateTime(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.BudgetCollectivite",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .AnneeBudgetaireId = c.Long(nullable := False),
                        .CollectiviteId = c.Long(nullable := False),
                        .Montant = c.Double(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AnneeBudgetaire", Function(t) t.AnneeBudgetaireId) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Collectivite", Function(t) t.CollectiviteId) _
                .Index(Function(t) t.AnneeBudgetaireId) _
                .Index(Function(t) t.CollectiviteId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Collectivite",
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
                "dbo.Indemmisation",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .DemandeId = c.Long(nullable := False),
                        .CollectiviteId = c.Long(nullable := False),
                        .Montant = c.Double(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Collectivite", Function(t) t.CollectiviteId) _
                .ForeignKey("dbo.Demande", Function(t) t.DemandeId) _
                .Index(Function(t) t.DemandeId) _
                .Index(Function(t) t.CollectiviteId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Demande",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .SinistreId = c.Long(nullable := False),
                        .SinistrerId = c.Long(nullable := False),
                        .Reference = c.String(nullable := False, maxLength := 250),
                        .Etat = c.Int(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Sinistre", Function(t) t.SinistreId) _
                .ForeignKey("dbo.Sinistrer", Function(t) t.SinistrerId) _
                .Index(Function(t) t.SinistreId) _
                .Index(Function(t) t.SinistrerId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.PieceJointe",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .DemandeId = c.Long(nullable := False),
                        .ProjetId = c.Long(nullable := False),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .Lien = c.String(maxLength := 4000),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Demande", Function(t) t.DemandeId) _
                .ForeignKey("dbo.Projet", Function(t) t.ProjetId) _
                .Index(Function(t) t.DemandeId) _
                .Index(Function(t) t.ProjetId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Projet",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .AdresseId = c.Long(nullable := False),
                        .DeviseId = c.Long(nullable := False),
                        .OganisationId = c.Long(nullable := False),
                        .Reference = c.String(nullable := False, maxLength := 250),
                        .Nom = c.String(nullable := False, maxLength := 250),
                        .Description = c.String(maxLength := 4000),
                        .Budget = c.Double(nullable := False),
                        .DateDebut = c.DateTime(nullable := False),
                        .DateFin = c.DateTime(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Adresse", Function(t) t.AdresseId) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Devise", Function(t) t.DeviseId) _
                .ForeignKey("dbo.Oganisation", Function(t) t.OganisationId) _
                .Index(Function(t) t.AdresseId) _
                .Index(Function(t) t.DeviseId) _
                .Index(Function(t) t.OganisationId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Devise",
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
                "dbo.Oganisation",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .TypeOrganisationId = c.Long(nullable := False),
                        .Nom = c.String(nullable := False, maxLength := 250),
                        .Acronyme = c.String(),
                        .SiteWeb = c.String(maxLength := 250),
                        .Telephone = c.String(nullable := False, maxLength := 250),
                        .Email = c.String(nullable := False, maxLength := 250),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.TypeOrganisation", Function(t) t.TypeOrganisationId) _
                .Index(Function(t) t.TypeOrganisationId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Bureau",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .OganisationId = c.Long(nullable := False),
                        .TypeOfficeId = c.Long(nullable := False),
                        .AdresseId = c.Long(nullable := False),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .CodePostale = c.String(nullable := False, maxLength := 250),
                        .Telephone = c.String(nullable := False, maxLength := 20),
                        .Email = c.String(nullable := False, maxLength := 250),
                        .HeureDOuverture = c.String(nullable := False, maxLength := 250),
                        .HeureFermeture = c.String(nullable := False, maxLength := 250),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Adresse", Function(t) t.AdresseId) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Oganisation", Function(t) t.OganisationId) _
                .ForeignKey("dbo.TypeOffice", Function(t) t.TypeOfficeId) _
                .Index(Function(t) t.OganisationId) _
                .Index(Function(t) t.TypeOfficeId) _
                .Index(Function(t) t.AdresseId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.TypeOffice",
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
                "dbo.Entrepots",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .OganisationId = c.Long(nullable := False),
                        .AdresseId = c.Long(nullable := False),
                        .Nom = c.String(nullable := False, maxLength := 250),
                        .Telephone = c.String(maxLength := 20),
                        .CodePostale = c.String(maxLength := 20),
                        .Email = c.String(maxLength := 250),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Adresse", Function(t) t.AdresseId) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Oganisation", Function(t) t.OganisationId) _
                .Index(Function(t) t.OganisationId) _
                .Index(Function(t) t.AdresseId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Article",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .EntrepotsId = c.Long(nullable := False),
                        .CategorieDArticleId = c.Long(nullable := False),
                        .Code = c.String(nullable := False, maxLength := 250),
                        .Nom = c.String(nullable := False, maxLength := 250),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.CategorieDArticle", Function(t) t.CategorieDArticleId) _
                .ForeignKey("dbo.Entrepots", Function(t) t.EntrepotsId) _
                .Index(Function(t) t.EntrepotsId) _
                .Index(Function(t) t.CategorieDArticleId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.CategorieDArticle",
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
                "dbo.DemandeArticle",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .ArticleId = c.Long(nullable := False),
                        .DemandeDArticleId = c.Long(nullable := False),
                        .Quantite = c.Int(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Article", Function(t) t.ArticleId) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.DemandeDArticle", Function(t) t.DemandeDArticleId) _
                .Index(Function(t) t.ArticleId) _
                .Index(Function(t) t.DemandeDArticleId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.DemandeDArticle",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .PersonnelId = c.Long(nullable := False),
                        .EntrepotsId = c.Long(nullable := False),
                        .PrioriteId = c.Long(nullable := False),
                        .Code = c.String(nullable := False, maxLength := 250),
                        .Details = c.String(nullable := False, maxLength := 250),
                        .DateCreation = c.DateTime(nullable := False),
                        .DatePrevuDeReception = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Entrepots", Function(t) t.EntrepotsId) _
                .ForeignKey("dbo.Personnel", Function(t) t.PersonnelId) _
                .ForeignKey("dbo.Priorite", Function(t) t.PrioriteId) _
                .Index(Function(t) t.PersonnelId) _
                .Index(Function(t) t.EntrepotsId) _
                .Index(Function(t) t.PrioriteId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Personnel",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .TypePersonnelId = c.Long(nullable := False),
                        .OganisationId = c.Long(nullable := False),
                        .Cni = c.String(nullable := False, maxLength := 30),
                        .Nom = c.String(nullable := False, maxLength := 250),
                        .Prenom = c.String(maxLength := 250),
                        .Telephone = c.String(nullable := False, maxLength := 20),
                        .Email = c.String(maxLength := 250),
                        .DateDeNaissance = c.DateTime(nullable := False),
                        .LieuNaissance = c.String(nullable := False, maxLength := 250),
                        .Sexe = c.String(nullable := False, maxLength := 10),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Oganisation", Function(t) t.OganisationId) _
                .ForeignKey("dbo.TypePersonnel", Function(t) t.TypePersonnelId) _
                .Index(Function(t) t.TypePersonnelId) _
                .Index(Function(t) t.OganisationId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Competance",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .PersonnelId = c.Long(nullable := False),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Personnel", Function(t) t.PersonnelId) _
                .Index(Function(t) t.PersonnelId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.PersonnelProjets",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .PersonnelId = c.Long(nullable := False),
                        .ProjetId = c.Long(nullable := False),
                        .AspNetUserId = c.String(maxLength := 128),
                        .TitreDuPoste = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Personnel", Function(t) t.PersonnelId) _
                .ForeignKey("dbo.Projet", Function(t) t.ProjetId) _
                .Index(Function(t) t.PersonnelId) _
                .Index(Function(t) t.ProjetId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Tache",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .PersonnelId = c.Long(nullable := False),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Personnel", Function(t) t.PersonnelId) _
                .Index(Function(t) t.PersonnelId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.TypePersonnel",
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
                "dbo.Priorite",
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
                "dbo.Installation",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .OganisationId = c.Long(nullable := False),
                        .AdresseId = c.Long(nullable := False),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .CodePostale = c.String(maxLength := 250),
                        .Telephone = c.String(nullable := False, maxLength := 20),
                        .HeureDOuverture = c.String(nullable := False, maxLength := 20),
                        .HeureFermeture = c.String(nullable := False, maxLength := 20),
                        .Email = c.String(maxLength := 250),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Adresse", Function(t) t.AdresseId) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Oganisation", Function(t) t.OganisationId) _
                .Index(Function(t) t.OganisationId) _
                .Index(Function(t) t.AdresseId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Moyen",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .TypeMoyenId = c.Long(nullable := False),
                        .OganisationId = c.Long(nullable := False),
                        .Nom = c.String(nullable := False, maxLength := 250),
                        .Description = c.String(maxLength := 4000),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .Location = c.Geography(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Oganisation", Function(t) t.OganisationId) _
                .ForeignKey("dbo.TypeMoyen", Function(t) t.TypeMoyenId) _
                .Index(Function(t) t.TypeMoyenId) _
                .Index(Function(t) t.OganisationId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.TypeMoyen",
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
                "dbo.TypeOrganisation",
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
                "dbo.Secteur",
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
                "dbo.Sinistre",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .TypeSinistreId = c.Long(nullable := False),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.TypeSinistre", Function(t) t.TypeSinistreId) _
                .Index(Function(t) t.TypeSinistreId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Causes",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .SinistreId = c.Long(nullable := False),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .Description = c.String(),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Sinistre", Function(t) t.SinistreId) _
                .Index(Function(t) t.SinistreId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Enquete",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .SinistreId = c.Long(nullable := False),
                        .Titre = c.String(nullable := False, maxLength := 250),
                        .Description = c.String(maxLength := 4000),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Sinistre", Function(t) t.SinistreId) _
                .Index(Function(t) t.SinistreId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Formulaire",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .EnqueteId = c.Long(nullable := False),
                        .Titre = c.String(nullable := False, maxLength := 250),
                        .Description = c.String(maxLength := 4000),
                        .StatutExistant = c.Short(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Enquete", Function(t) t.EnqueteId) _
                .Index(Function(t) t.EnqueteId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Sections",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .FormulaireId = c.Long(nullable := False),
                        .Titre = c.String(),
                        .Description = c.String(),
                        .StatutExistant = c.Short(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .AspNetUserId = c.String(maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Formulaire", Function(t) t.FormulaireId) _
                .Index(Function(t) t.FormulaireId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.ChampsSection",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .ChampsId = c.Long(nullable := False),
                        .SectionId = c.Long(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128),
                        .ValeurChamps_Id = c.Long()
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Champs", Function(t) t.ChampsId) _
                .ForeignKey("dbo.Sections", Function(t) t.SectionId) _
                .ForeignKey("dbo.ValeurChamps", Function(t) t.ValeurChamps_Id) _
                .Index(Function(t) t.ChampsId) _
                .Index(Function(t) t.SectionId) _
                .Index(Function(t) t.AspNetUserId) _
                .Index(Function(t) t.ValeurChamps_Id)
            
            CreateTable(
                "dbo.Champs",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .TypeChampsId = c.Long(nullable := False),
                        .Titre = c.String(),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.TypeChamps", Function(t) t.TypeChampsId) _
                .Index(Function(t) t.TypeChampsId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.TypeChamps",
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
                "dbo.ValeurChamps",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .ChampsSectionId = c.Long(nullable := False),
                        .Valeur = c.String(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Site",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .SinistreId = c.Long(nullable := False),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Sinistre", Function(t) t.SinistreId) _
                .Index(Function(t) t.SinistreId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Zone",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .NiveauDeRepresentationId = c.Long(nullable := False),
                        .SiteId = c.Long(nullable := False),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.NiveauDeRepresentation", Function(t) t.NiveauDeRepresentationId) _
                .ForeignKey("dbo.Site", Function(t) t.SiteId) _
                .Index(Function(t) t.NiveauDeRepresentationId) _
                .Index(Function(t) t.SiteId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.NiveauDeRepresentation",
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
                "dbo.TypeSinistre",
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
                "dbo.Sinistrer",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .Cni = c.String(nullable := False, maxLength := 30),
                        .Nom = c.String(nullable := False, maxLength := 250),
                        .Prenom = c.String(maxLength := 250),
                        .Telephone = c.String(nullable := False, maxLength := 20),
                        .Email = c.String(maxLength := 250),
                        .DateDeNaissance = c.DateTime(),
                        .Sexe = c.String(nullable := False, maxLength := 10),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.MaladieSinistre",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .MaladieId = c.Long(nullable := False),
                        .SinistrerId = c.Long(nullable := False),
                        .AbrisId = c.Long(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Abris", Function(t) t.AbrisId) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Maladie", Function(t) t.MaladieId) _
                .ForeignKey("dbo.Sinistrer", Function(t) t.SinistrerId) _
                .Index(Function(t) t.MaladieId) _
                .Index(Function(t) t.SinistrerId) _
                .Index(Function(t) t.AbrisId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Maladie",
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
                "dbo.Suivi",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .DemandeId = c.Long(nullable := False),
                        .TypeSuiviId = c.Long(nullable := False),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Demande", Function(t) t.DemandeId) _
                .ForeignKey("dbo.TypeSuivi", Function(t) t.TypeSuiviId) _
                .Index(Function(t) t.DemandeId) _
                .Index(Function(t) t.TypeSuiviId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.TypeSuivi",
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
                "dbo.AspNetUserClaims",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .ClaimType = c.String(),
                        .ClaimValue = c.String(),
                        .User_Id = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.User_Id) _
                .Index(Function(t) t.User_Id)
            
            CreateTable(
                "dbo.AspNetUserLogins",
                Function(c) New With
                    {
                        .UserId = c.String(nullable := False, maxLength := 128),
                        .LoginProvider = c.String(nullable := False, maxLength := 128),
                        .ProviderKey = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) New With { t.UserId, t.LoginProvider, t.ProviderKey }) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.UserId) _
                .Index(Function(t) t.UserId)
            
            CreateTable(
                "dbo.AspNetUserRoles",
                Function(c) New With
                    {
                        .UserId = c.String(nullable := False, maxLength := 128),
                        .RoleId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) New With { t.UserId, t.RoleId }) _
                .ForeignKey("dbo.AspNetRoles", Function(t) t.RoleId) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.UserId) _
                .Index(Function(t) t.UserId) _
                .Index(Function(t) t.RoleId)
            
            CreateTable(
                "dbo.AspNetRoles",
                Function(c) New With
                    {
                        .Id = c.String(nullable := False, maxLength := 128),
                        .Name = c.String(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            CreateTable(
                "dbo.TypeAbris",
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
                "dbo.SecteurProjets",
                Function(c) New With
                    {
                        .Secteur_Id = c.Long(nullable := False),
                        .Projet_Id = c.Long(nullable := False)
                    }) _
                .PrimaryKey(Function(t) New With { t.Secteur_Id, t.Projet_Id }) _
                .ForeignKey("dbo.Secteur", Function(t) t.Secteur_Id, cascadeDelete := True) _
                .ForeignKey("dbo.Projet", Function(t) t.Projet_Id, cascadeDelete := True) _
                .Index(Function(t) t.Secteur_Id) _
                .Index(Function(t) t.Projet_Id)
            
            CreateTable(
                "dbo.Commune",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False),
                        .DepartementId = c.Long(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Collectivite", Function(t) t.Id) _
                .ForeignKey("dbo.Departement", Function(t) t.DepartementId) _
                .Index(Function(t) t.Id) _
                .Index(Function(t) t.DepartementId)
            
            CreateTable(
                "dbo.Departement",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False),
                        .ChefLieu = c.String(nullable := False, maxLength := 250),
                        .RegionId = c.Long(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Collectivite", Function(t) t.Id) _
                .ForeignKey("dbo.Region", Function(t) t.RegionId) _
                .Index(Function(t) t.Id) _
                .Index(Function(t) t.RegionId)
            
            CreateTable(
                "dbo.Region",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False),
                        .ChefLieu = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Collectivite", Function(t) t.Id) _
                .Index(Function(t) t.Id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Region", "Id", "dbo.Collectivite")
            DropForeignKey("dbo.Departement", "RegionId", "dbo.Region")
            DropForeignKey("dbo.Departement", "Id", "dbo.Collectivite")
            DropForeignKey("dbo.Commune", "DepartementId", "dbo.Departement")
            DropForeignKey("dbo.Commune", "Id", "dbo.Collectivite")
            DropForeignKey("dbo.Abris", "AdresseId", "dbo.Adresse")
            DropForeignKey("dbo.TypeAbris", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Abris", "TypeAbrisId", "dbo.TypeAbris")
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers")
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles")
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Suivi", "TypeSuiviId", "dbo.TypeSuivi")
            DropForeignKey("dbo.TypeSuivi", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Suivi", "DemandeId", "dbo.Demande")
            DropForeignKey("dbo.Suivi", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.MaladieSinistre", "SinistrerId", "dbo.Sinistrer")
            DropForeignKey("dbo.MaladieSinistre", "MaladieId", "dbo.Maladie")
            DropForeignKey("dbo.Maladie", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.MaladieSinistre", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.MaladieSinistre", "AbrisId", "dbo.Abris")
            DropForeignKey("dbo.Demande", "SinistrerId", "dbo.Sinistrer")
            DropForeignKey("dbo.Sinistrer", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Sinistre", "TypeSinistreId", "dbo.TypeSinistre")
            DropForeignKey("dbo.TypeSinistre", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Zone", "SiteId", "dbo.Site")
            DropForeignKey("dbo.Zone", "NiveauDeRepresentationId", "dbo.NiveauDeRepresentation")
            DropForeignKey("dbo.NiveauDeRepresentation", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Zone", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Site", "SinistreId", "dbo.Sinistre")
            DropForeignKey("dbo.Site", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Enquete", "SinistreId", "dbo.Sinistre")
            DropForeignKey("dbo.Sections", "FormulaireId", "dbo.Formulaire")
            DropForeignKey("dbo.ChampsSection", "ValeurChamps_Id", "dbo.ValeurChamps")
            DropForeignKey("dbo.ValeurChamps", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.ChampsSection", "SectionId", "dbo.Sections")
            DropForeignKey("dbo.Champs", "TypeChampsId", "dbo.TypeChamps")
            DropForeignKey("dbo.TypeChamps", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.ChampsSection", "ChampsId", "dbo.Champs")
            DropForeignKey("dbo.Champs", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.ChampsSection", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Sections", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Formulaire", "EnqueteId", "dbo.Enquete")
            DropForeignKey("dbo.Formulaire", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Enquete", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Demande", "SinistreId", "dbo.Sinistre")
            DropForeignKey("dbo.Causes", "SinistreId", "dbo.Sinistre")
            DropForeignKey("dbo.Causes", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Sinistre", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.SecteurProjets", "Projet_Id", "dbo.Projet")
            DropForeignKey("dbo.SecteurProjets", "Secteur_Id", "dbo.Secteur")
            DropForeignKey("dbo.Secteur", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.PieceJointe", "ProjetId", "dbo.Projet")
            DropForeignKey("dbo.Oganisation", "TypeOrganisationId", "dbo.TypeOrganisation")
            DropForeignKey("dbo.TypeOrganisation", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Projet", "OganisationId", "dbo.Oganisation")
            DropForeignKey("dbo.Moyen", "TypeMoyenId", "dbo.TypeMoyen")
            DropForeignKey("dbo.TypeMoyen", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Moyen", "OganisationId", "dbo.Oganisation")
            DropForeignKey("dbo.Moyen", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Installation", "OganisationId", "dbo.Oganisation")
            DropForeignKey("dbo.Installation", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Installation", "AdresseId", "dbo.Adresse")
            DropForeignKey("dbo.Entrepots", "OganisationId", "dbo.Oganisation")
            DropForeignKey("dbo.Entrepots", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Article", "EntrepotsId", "dbo.Entrepots")
            DropForeignKey("dbo.DemandeDArticle", "PrioriteId", "dbo.Priorite")
            DropForeignKey("dbo.Priorite", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Personnel", "TypePersonnelId", "dbo.TypePersonnel")
            DropForeignKey("dbo.TypePersonnel", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Tache", "PersonnelId", "dbo.Personnel")
            DropForeignKey("dbo.Tache", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.PersonnelProjets", "ProjetId", "dbo.Projet")
            DropForeignKey("dbo.PersonnelProjets", "PersonnelId", "dbo.Personnel")
            DropForeignKey("dbo.PersonnelProjets", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Personnel", "OganisationId", "dbo.Oganisation")
            DropForeignKey("dbo.DemandeDArticle", "PersonnelId", "dbo.Personnel")
            DropForeignKey("dbo.Competance", "PersonnelId", "dbo.Personnel")
            DropForeignKey("dbo.Competance", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Personnel", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.DemandeDArticle", "EntrepotsId", "dbo.Entrepots")
            DropForeignKey("dbo.DemandeArticle", "DemandeDArticleId", "dbo.DemandeDArticle")
            DropForeignKey("dbo.DemandeDArticle", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.DemandeArticle", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.DemandeArticle", "ArticleId", "dbo.Article")
            DropForeignKey("dbo.CategorieDArticle", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Article", "CategorieDArticleId", "dbo.CategorieDArticle")
            DropForeignKey("dbo.Article", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Entrepots", "AdresseId", "dbo.Adresse")
            DropForeignKey("dbo.Bureau", "TypeOfficeId", "dbo.TypeOffice")
            DropForeignKey("dbo.TypeOffice", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Bureau", "OganisationId", "dbo.Oganisation")
            DropForeignKey("dbo.Bureau", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Bureau", "AdresseId", "dbo.Adresse")
            DropForeignKey("dbo.Oganisation", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Abris", "OganisationId", "dbo.Oganisation")
            DropForeignKey("dbo.Projet", "DeviseId", "dbo.Devise")
            DropForeignKey("dbo.Devise", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Projet", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Projet", "AdresseId", "dbo.Adresse")
            DropForeignKey("dbo.PieceJointe", "DemandeId", "dbo.Demande")
            DropForeignKey("dbo.PieceJointe", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Indemmisation", "DemandeId", "dbo.Demande")
            DropForeignKey("dbo.Demande", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Indemmisation", "CollectiviteId", "dbo.Collectivite")
            DropForeignKey("dbo.Indemmisation", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.BudgetCollectivite", "CollectiviteId", "dbo.Collectivite")
            DropForeignKey("dbo.Collectivite", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Adresse", "CollectiviteId", "dbo.Collectivite")
            DropForeignKey("dbo.BudgetCollectivite", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.BudgetCollectivite", "AnneeBudgetaireId", "dbo.AnneeBudgetaire")
            DropForeignKey("dbo.AnneeBudgetaire", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Adresse", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Abris", "AspNetUserId", "dbo.AspNetUsers")
            DropIndex("dbo.Region", New String() { "Id" })
            DropIndex("dbo.Departement", New String() { "RegionId" })
            DropIndex("dbo.Departement", New String() { "Id" })
            DropIndex("dbo.Commune", New String() { "DepartementId" })
            DropIndex("dbo.Commune", New String() { "Id" })
            DropIndex("dbo.SecteurProjets", New String() { "Projet_Id" })
            DropIndex("dbo.SecteurProjets", New String() { "Secteur_Id" })
            DropIndex("dbo.TypeAbris", New String() { "AspNetUserId" })
            DropIndex("dbo.AspNetUserRoles", New String() { "RoleId" })
            DropIndex("dbo.AspNetUserRoles", New String() { "UserId" })
            DropIndex("dbo.AspNetUserLogins", New String() { "UserId" })
            DropIndex("dbo.AspNetUserClaims", New String() { "User_Id" })
            DropIndex("dbo.TypeSuivi", New String() { "AspNetUserId" })
            DropIndex("dbo.Suivi", New String() { "AspNetUserId" })
            DropIndex("dbo.Suivi", New String() { "TypeSuiviId" })
            DropIndex("dbo.Suivi", New String() { "DemandeId" })
            DropIndex("dbo.Maladie", New String() { "AspNetUserId" })
            DropIndex("dbo.MaladieSinistre", New String() { "AspNetUserId" })
            DropIndex("dbo.MaladieSinistre", New String() { "AbrisId" })
            DropIndex("dbo.MaladieSinistre", New String() { "SinistrerId" })
            DropIndex("dbo.MaladieSinistre", New String() { "MaladieId" })
            DropIndex("dbo.Sinistrer", New String() { "AspNetUserId" })
            DropIndex("dbo.TypeSinistre", New String() { "AspNetUserId" })
            DropIndex("dbo.NiveauDeRepresentation", New String() { "AspNetUserId" })
            DropIndex("dbo.Zone", New String() { "AspNetUserId" })
            DropIndex("dbo.Zone", New String() { "SiteId" })
            DropIndex("dbo.Zone", New String() { "NiveauDeRepresentationId" })
            DropIndex("dbo.Site", New String() { "AspNetUserId" })
            DropIndex("dbo.Site", New String() { "SinistreId" })
            DropIndex("dbo.ValeurChamps", New String() { "AspNetUserId" })
            DropIndex("dbo.TypeChamps", New String() { "AspNetUserId" })
            DropIndex("dbo.Champs", New String() { "AspNetUserId" })
            DropIndex("dbo.Champs", New String() { "TypeChampsId" })
            DropIndex("dbo.ChampsSection", New String() { "ValeurChamps_Id" })
            DropIndex("dbo.ChampsSection", New String() { "AspNetUserId" })
            DropIndex("dbo.ChampsSection", New String() { "SectionId" })
            DropIndex("dbo.ChampsSection", New String() { "ChampsId" })
            DropIndex("dbo.Sections", New String() { "AspNetUserId" })
            DropIndex("dbo.Sections", New String() { "FormulaireId" })
            DropIndex("dbo.Formulaire", New String() { "AspNetUserId" })
            DropIndex("dbo.Formulaire", New String() { "EnqueteId" })
            DropIndex("dbo.Enquete", New String() { "AspNetUserId" })
            DropIndex("dbo.Enquete", New String() { "SinistreId" })
            DropIndex("dbo.Causes", New String() { "AspNetUserId" })
            DropIndex("dbo.Causes", New String() { "SinistreId" })
            DropIndex("dbo.Sinistre", New String() { "AspNetUserId" })
            DropIndex("dbo.Sinistre", New String() { "TypeSinistreId" })
            DropIndex("dbo.Secteur", New String() { "AspNetUserId" })
            DropIndex("dbo.TypeOrganisation", New String() { "AspNetUserId" })
            DropIndex("dbo.TypeMoyen", New String() { "AspNetUserId" })
            DropIndex("dbo.Moyen", New String() { "AspNetUserId" })
            DropIndex("dbo.Moyen", New String() { "OganisationId" })
            DropIndex("dbo.Moyen", New String() { "TypeMoyenId" })
            DropIndex("dbo.Installation", New String() { "AspNetUserId" })
            DropIndex("dbo.Installation", New String() { "AdresseId" })
            DropIndex("dbo.Installation", New String() { "OganisationId" })
            DropIndex("dbo.Priorite", New String() { "AspNetUserId" })
            DropIndex("dbo.TypePersonnel", New String() { "AspNetUserId" })
            DropIndex("dbo.Tache", New String() { "AspNetUserId" })
            DropIndex("dbo.Tache", New String() { "PersonnelId" })
            DropIndex("dbo.PersonnelProjets", New String() { "AspNetUserId" })
            DropIndex("dbo.PersonnelProjets", New String() { "ProjetId" })
            DropIndex("dbo.PersonnelProjets", New String() { "PersonnelId" })
            DropIndex("dbo.Competance", New String() { "AspNetUserId" })
            DropIndex("dbo.Competance", New String() { "PersonnelId" })
            DropIndex("dbo.Personnel", New String() { "AspNetUserId" })
            DropIndex("dbo.Personnel", New String() { "OganisationId" })
            DropIndex("dbo.Personnel", New String() { "TypePersonnelId" })
            DropIndex("dbo.DemandeDArticle", New String() { "AspNetUserId" })
            DropIndex("dbo.DemandeDArticle", New String() { "PrioriteId" })
            DropIndex("dbo.DemandeDArticle", New String() { "EntrepotsId" })
            DropIndex("dbo.DemandeDArticle", New String() { "PersonnelId" })
            DropIndex("dbo.DemandeArticle", New String() { "AspNetUserId" })
            DropIndex("dbo.DemandeArticle", New String() { "DemandeDArticleId" })
            DropIndex("dbo.DemandeArticle", New String() { "ArticleId" })
            DropIndex("dbo.CategorieDArticle", New String() { "AspNetUserId" })
            DropIndex("dbo.Article", New String() { "AspNetUserId" })
            DropIndex("dbo.Article", New String() { "CategorieDArticleId" })
            DropIndex("dbo.Article", New String() { "EntrepotsId" })
            DropIndex("dbo.Entrepots", New String() { "AspNetUserId" })
            DropIndex("dbo.Entrepots", New String() { "AdresseId" })
            DropIndex("dbo.Entrepots", New String() { "OganisationId" })
            DropIndex("dbo.TypeOffice", New String() { "AspNetUserId" })
            DropIndex("dbo.Bureau", New String() { "AspNetUserId" })
            DropIndex("dbo.Bureau", New String() { "AdresseId" })
            DropIndex("dbo.Bureau", New String() { "TypeOfficeId" })
            DropIndex("dbo.Bureau", New String() { "OganisationId" })
            DropIndex("dbo.Oganisation", New String() { "AspNetUserId" })
            DropIndex("dbo.Oganisation", New String() { "TypeOrganisationId" })
            DropIndex("dbo.Devise", New String() { "AspNetUserId" })
            DropIndex("dbo.Projet", New String() { "AspNetUserId" })
            DropIndex("dbo.Projet", New String() { "OganisationId" })
            DropIndex("dbo.Projet", New String() { "DeviseId" })
            DropIndex("dbo.Projet", New String() { "AdresseId" })
            DropIndex("dbo.PieceJointe", New String() { "AspNetUserId" })
            DropIndex("dbo.PieceJointe", New String() { "ProjetId" })
            DropIndex("dbo.PieceJointe", New String() { "DemandeId" })
            DropIndex("dbo.Demande", New String() { "AspNetUserId" })
            DropIndex("dbo.Demande", New String() { "SinistrerId" })
            DropIndex("dbo.Demande", New String() { "SinistreId" })
            DropIndex("dbo.Indemmisation", New String() { "AspNetUserId" })
            DropIndex("dbo.Indemmisation", New String() { "CollectiviteId" })
            DropIndex("dbo.Indemmisation", New String() { "DemandeId" })
            DropIndex("dbo.Collectivite", New String() { "AspNetUserId" })
            DropIndex("dbo.BudgetCollectivite", New String() { "AspNetUserId" })
            DropIndex("dbo.BudgetCollectivite", New String() { "CollectiviteId" })
            DropIndex("dbo.BudgetCollectivite", New String() { "AnneeBudgetaireId" })
            DropIndex("dbo.AnneeBudgetaire", New String() { "AspNetUserId" })
            DropIndex("dbo.Adresse", New String() { "AspNetUserId" })
            DropIndex("dbo.Adresse", New String() { "CollectiviteId" })
            DropIndex("dbo.Abris", New String() { "AspNetUserId" })
            DropIndex("dbo.Abris", New String() { "AdresseId" })
            DropIndex("dbo.Abris", New String() { "TypeAbrisId" })
            DropIndex("dbo.Abris", New String() { "OganisationId" })
            DropTable("dbo.Region")
            DropTable("dbo.Departement")
            DropTable("dbo.Commune")
            DropTable("dbo.SecteurProjets")
            DropTable("dbo.TypeAbris")
            DropTable("dbo.AspNetRoles")
            DropTable("dbo.AspNetUserRoles")
            DropTable("dbo.AspNetUserLogins")
            DropTable("dbo.AspNetUserClaims")
            DropTable("dbo.TypeSuivi")
            DropTable("dbo.Suivi")
            DropTable("dbo.Maladie")
            DropTable("dbo.MaladieSinistre")
            DropTable("dbo.Sinistrer")
            DropTable("dbo.TypeSinistre")
            DropTable("dbo.NiveauDeRepresentation")
            DropTable("dbo.Zone")
            DropTable("dbo.Site")
            DropTable("dbo.ValeurChamps")
            DropTable("dbo.TypeChamps")
            DropTable("dbo.Champs")
            DropTable("dbo.ChampsSection")
            DropTable("dbo.Sections")
            DropTable("dbo.Formulaire")
            DropTable("dbo.Enquete")
            DropTable("dbo.Causes")
            DropTable("dbo.Sinistre")
            DropTable("dbo.Secteur")
            DropTable("dbo.TypeOrganisation")
            DropTable("dbo.TypeMoyen")
            DropTable("dbo.Moyen")
            DropTable("dbo.Installation")
            DropTable("dbo.Priorite")
            DropTable("dbo.TypePersonnel")
            DropTable("dbo.Tache")
            DropTable("dbo.PersonnelProjets")
            DropTable("dbo.Competance")
            DropTable("dbo.Personnel")
            DropTable("dbo.DemandeDArticle")
            DropTable("dbo.DemandeArticle")
            DropTable("dbo.CategorieDArticle")
            DropTable("dbo.Article")
            DropTable("dbo.Entrepots")
            DropTable("dbo.TypeOffice")
            DropTable("dbo.Bureau")
            DropTable("dbo.Oganisation")
            DropTable("dbo.Devise")
            DropTable("dbo.Projet")
            DropTable("dbo.PieceJointe")
            DropTable("dbo.Demande")
            DropTable("dbo.Indemmisation")
            DropTable("dbo.Collectivite")
            DropTable("dbo.BudgetCollectivite")
            DropTable("dbo.AnneeBudgetaire")
            DropTable("dbo.AspNetUsers")
            DropTable("dbo.Adresse")
            DropTable("dbo.Abris")
        End Sub
    End Class
End Namespace
