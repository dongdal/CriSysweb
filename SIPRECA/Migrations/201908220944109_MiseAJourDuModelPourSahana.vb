Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class MiseAJourDuModelPourSahana
        Inherits DbMigration
    
        Public Overrides Sub Up()
            RenameTable(name := "dbo.PersonnelProjets", newName := "PersonnelProjet")
            DropForeignKey("dbo.Entrepots", "AdresseId", "dbo.Adresse")
            DropForeignKey("dbo.Entrepots", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Entrepots", "OganisationId", "dbo.Oganisation")
            DropIndex("dbo.Adresse", New String() { "CollectiviteId" })
            DropIndex("dbo.Bureau", New String() { "OganisationId" })
            DropIndex("dbo.Bureau", New String() { "AdresseId" })
            DropIndex("dbo.Bureau", New String() { "AspNetUserId" })
            DropIndex("dbo.Installation", New String() { "OganisationId" })
            DropIndex("dbo.Installation", New String() { "AdresseId" })
            DropIndex("dbo.Installation", New String() { "AspNetUserId" })
            RenameColumn(table := "dbo.Bureau", name := "AdresseId", newName := "Adresse_Id")
            RenameColumn(table := "dbo.Installation", name := "AdresseId", newName := "Adresse_Id")
            RenameColumn(table := "dbo.Bureau", name := "AspNetUserId", newName := "ApplicationUser_Id")
            RenameColumn(table := "dbo.Installation", name := "AspNetUserId", newName := "ApplicationUser_Id")
            RenameColumn(table := "dbo.Adresse", name := "CollectiviteId", newName := "Collectivite_Id")
            RenameColumn(table := "dbo.Bureau", name := "OganisationId", newName := "Organisation_Id")
            RenameColumn(table := "dbo.Installation", name := "OganisationId", newName := "Organisation_Id")
            DropPrimaryKey("dbo.Bureau")
            DropPrimaryKey("dbo.Installation")
            CreateTable(
                "dbo.PersonnelBureau",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .PersonnelId = c.Long(nullable := False),
                        .BureauId = c.Long(nullable := False),
                        .AspNetUserId = c.String(maxLength := 128),
                        .TitreDuPoste = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Bureau", Function(t) t.BureauId) _
                .ForeignKey("dbo.Personnel", Function(t) t.PersonnelId) _
                .Index(Function(t) t.PersonnelId) _
                .Index(Function(t) t.BureauId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.TypeEntrepot",
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
                "dbo.PersonnelAbris",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .PersonnelId = c.Long(nullable := False),
                        .AbrisId = c.Long(nullable := False),
                        .AspNetUserId = c.String(maxLength := 128),
                        .TitreDuPoste = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Abris", Function(t) t.AbrisId) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Personnel", Function(t) t.PersonnelId) _
                .Index(Function(t) t.PersonnelId) _
                .Index(Function(t) t.AbrisId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.PersonnelInstallation",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .PersonnelId = c.Long(nullable := False),
                        .InstallationId = c.Long(nullable := False),
                        .AspNetUserId = c.String(maxLength := 128),
                        .TitreDuPoste = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Installation", Function(t) t.InstallationId) _
                .ForeignKey("dbo.Personnel", Function(t) t.PersonnelId) _
                .Index(Function(t) t.PersonnelId) _
                .Index(Function(t) t.InstallationId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Aeroport",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .OganisationId = c.Long(nullable := False),
                        .AdresseId = c.Long(nullable := False),
                        .SurfaceDePisteId = c.Long(nullable := False),
                        .TailleDeAeronefId = c.Long(nullable := False),
                        .UsageHumanitaireId = c.Long(nullable := False),
                        .Nom = c.String(nullable := False, maxLength := 250),
                        .ICAO = c.String(nullable := False),
                        .IATA = c.String(nullable := False),
                        .LongueurDePiste = c.Double(nullable := False),
                        .LargeurDePiste = c.Double(nullable := False),
                        .Telephone = c.String(nullable := False, maxLength := 20),
                        .Telephone2 = c.String(),
                        .SiteWeb = c.String(),
                        .Email = c.String(maxLength := 250),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Adresse", Function(t) t.AdresseId) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Oganisation", Function(t) t.OganisationId) _
                .ForeignKey("dbo.SurfaceDePiste", Function(t) t.SurfaceDePisteId) _
                .ForeignKey("dbo.TailleDeAeronef", Function(t) t.TailleDeAeronefId) _
                .ForeignKey("dbo.UsageHumanitaire", Function(t) t.UsageHumanitaireId) _
                .Index(Function(t) t.OganisationId) _
                .Index(Function(t) t.AdresseId) _
                .Index(Function(t) t.SurfaceDePisteId) _
                .Index(Function(t) t.TailleDeAeronefId) _
                .Index(Function(t) t.UsageHumanitaireId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.SurfaceDePiste",
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
                "dbo.TailleDeAeronef",
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
                "dbo.UsageHumanitaire",
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
                "dbo.CategorieElement",
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
                "dbo.Element",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .CategorieElementId = c.Long(nullable := False),
                        .MarqueElementId = c.Long(),
                        .Code = c.String(nullable := False, maxLength := 5),
                        .Nom = c.String(),
                        .UniteMesure = c.String(),
                        .ValeurParUnité = c.String(),
                        .Modele = c.String(),
                        .AnneeFabrication = c.Long(nullable := False),
                        .Poids = c.Long(nullable := False),
                        .Longueur = c.Long(nullable := False),
                        .Largeur = c.Long(nullable := False),
                        .Hauteur = c.Long(nullable := False),
                        .Volume = c.Long(nullable := False),
                        .PrixAchat = c.Double(nullable := False),
                        .DeviseId = c.Long(),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.CategorieElement", Function(t) t.CategorieElementId) _
                .ForeignKey("dbo.Devise", Function(t) t.DeviseId) _
                .ForeignKey("dbo.MarqueElement", Function(t) t.MarqueElementId) _
                .Index(Function(t) t.CategorieElementId) _
                .Index(Function(t) t.MarqueElementId) _
                .Index(Function(t) t.DeviseId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.MarqueElement",
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
                "dbo.Heliport",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .OganisationId = c.Long(nullable := False),
                        .AdresseId = c.Long(nullable := False),
                        .Nom = c.String(nullable := False, maxLength := 250),
                        .Code = c.String(nullable := False, maxLength := 5),
                        .Telephone = c.String(nullable := False, maxLength := 20),
                        .Telephone2 = c.String(),
                        .SiteWeb = c.String(),
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
                "dbo.Hopitaux",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .OganisationId = c.Long(nullable := False),
                        .TypeHopitauxId = c.Long(nullable := False),
                        .AdresseId = c.Long(nullable := False),
                        .Nom = c.String(nullable := False, maxLength := 250),
                        .Code = c.String(nullable := False, maxLength := 5),
                        .NombreDeLitMin = c.Long(nullable := False),
                        .NombreDeLitMax = c.Long(nullable := False),
                        .NombreDeMedecin = c.Long(nullable := False),
                        .NombreDInfimiere = c.Long(nullable := False),
                        .NombreDePersonnelNonMedical = c.Long(nullable := False),
                        .Telephone = c.String(nullable := False, maxLength := 20),
                        .TelephoneUrgence = c.String(),
                        .SiteWeb = c.String(),
                        .Email = c.String(maxLength := 250),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Adresse", Function(t) t.AdresseId) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Oganisation", Function(t) t.OganisationId) _
                .ForeignKey("dbo.TypeHopitaux", Function(t) t.TypeHopitauxId) _
                .Index(Function(t) t.OganisationId) _
                .Index(Function(t) t.TypeHopitauxId) _
                .Index(Function(t) t.AdresseId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.HopitauxPuissance",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .HopitauxId = c.Long(nullable := False),
                        .PuissanceId = c.Long(nullable := False),
                        .AspNetUserId = c.String(maxLength := 128),
                        .Libelle = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Hopitaux", Function(t) t.HopitauxId) _
                .ForeignKey("dbo.Puissance", Function(t) t.PuissanceId) _
                .Index(Function(t) t.HopitauxId) _
                .Index(Function(t) t.PuissanceId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Puissance",
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
                "dbo.TypeHopitaux",
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
                "dbo.Immobilisation",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .TypeImmobilisationId = c.Long(),
                        .InfrastructureId = c.Long(nullable := False),
                        .FournisseurId = c.Long(nullable := False),
                        .ElementId = c.Long(nullable := False),
                        .NumeroImobilisation = c.String(nullable := False, maxLength := 20),
                        .NumeroDeSerie = c.String(),
                        .DateAchat = c.DateTime(nullable := False),
                        .PrixAchat = c.Double(nullable := False),
                        .DeviseId = c.Long(),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Devise", Function(t) t.DeviseId) _
                .ForeignKey("dbo.Element", Function(t) t.ElementId) _
                .ForeignKey("dbo.Oganisation", Function(t) t.FournisseurId) _
                .ForeignKey("dbo.Entrepots", Function(t) t.InfrastructureId) _
                .ForeignKey("dbo.TypeImmobilisation", Function(t) t.TypeImmobilisationId) _
                .Index(Function(t) t.TypeImmobilisationId) _
                .Index(Function(t) t.InfrastructureId) _
                .Index(Function(t) t.FournisseurId) _
                .Index(Function(t) t.ElementId) _
                .Index(Function(t) t.DeviseId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.TypeImmobilisation",
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
                "dbo.TypeVehicule",
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
                "dbo.PortDeMer",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .AdresseId = c.Long(nullable := False),
                        .OganisationId = c.Long(nullable := False),
                        .Nom = c.String(nullable := False, maxLength := 250),
                        .Code = c.String(nullable := False, maxLength := 5),
                        .Possession = c.String(),
                        .HauteurMaximum = c.Double(nullable := False),
                        .HauteurMaximumUnites = c.String(),
                        .ProfondeurQuaiChargement = c.Double(nullable := False),
                        .ProfondeurQuaiChargementUnites = c.String(),
                        .ProfondeurTerminalPetrolier = c.Double(nullable := False),
                        .ProfondeurTerminalPetrolierUnites = c.String(),
                        .CaleSeche = c.String(),
                        .LongueurMaximaleNavire = c.Double(nullable := False),
                        .LongueurMaximaleNavireUnites = c.String(),
                        .Reparations = c.String(maxLength := 4000),
                        .Abri = c.String(maxLength := 4000),
                        .CapaciteStockageEntreposage = c.Double(nullable := False),
                        .CapaciteStockageSecurise = c.Double(nullable := False),
                        .CapaciteStockageEntrepotDouanier = c.Double(nullable := False),
                        .NombreRemorqueur = c.Long(nullable := False),
                        .CapaciteRemorqueur = c.Double(nullable := False),
                        .NombreBarge = c.Double(nullable := False),
                        .CapacietBarge = c.Double(nullable := False),
                        .EquipementChargement = c.String(maxLength := 4000),
                        .CapaciteDouaniere = c.String(maxLength := 4000),
                        .Securite = c.String(maxLength := 4000),
                        .ProfondeurMareHaute = c.Double(nullable := False),
                        .ProfondeurMareHauteUnites = c.String(),
                        .ProfondeurMareBasse = c.Double(nullable := False),
                        .ProfondeurMareBasseUnites = c.String(),
                        .ProfondeurInondation = c.Double(nullable := False),
                        .ProfondeurInondationUnites = c.String(),
                        .Telephone = c.String(nullable := False, maxLength := 20),
                        .Telephone2 = c.String(),
                        .SiteWeb = c.String(),
                        .Email = c.String(maxLength := 250),
                        .StatutExistant = c.Short(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Adresse", Function(t) t.AdresseId) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Oganisation", Function(t) t.OganisationId) _
                .Index(Function(t) t.AdresseId) _
                .Index(Function(t) t.OganisationId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Vehicule",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False),
                        .TypeVehiculeId = c.Long(nullable := False),
                        .LicencePlate = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Immobilisation", Function(t) t.Id) _
                .ForeignKey("dbo.TypeVehicule", Function(t) t.TypeVehiculeId) _
                .Index(Function(t) t.Id) _
                .Index(Function(t) t.TypeVehiculeId)
            
            AddColumn("dbo.Abris", "Capacite", Function(c) c.Long(nullable := False))
            AddColumn("dbo.Adresse", "VilleId", Function(c) c.Long(nullable := False))
            AddColumn("dbo.Entrepots", "Code", Function(c) c.String(nullable := False, maxLength := 5))
            AddColumn("dbo.Entrepots", "Telephone2", Function(c) c.String())
            AddColumn("dbo.Entrepots", "TypeEntrepotId", Function(c) c.Long())
            AddColumn("dbo.Entrepots", "Capacite", Function(c) c.Double())
            AddColumn("dbo.Entrepots", "CapaciteDisponible", Function(c) c.Double())
            AddColumn("dbo.Entrepots", "Discriminator", Function(c) c.String(maxLength := 128))
            AddColumn("dbo.Entrepots", "Organisation_Id1", Function(c) c.Long())
            AddColumn("dbo.Entrepots", "ApplicationUser_Id1", Function(c) c.String(maxLength := 128))
            AddColumn("dbo.Entrepots", "Adresse_Id1", Function(c) c.Long())
            AlterColumn("dbo.Adresse", "Collectivite_Id", Function(c) c.Long())
            AlterColumn("dbo.Bureau", "Id", Function(c) c.Long(nullable := False))
            AlterColumn("dbo.Bureau", "Organisation_Id", Function(c) c.Long())
            AlterColumn("dbo.Bureau", "Adresse_Id", Function(c) c.Long())
            AlterColumn("dbo.Bureau", "ApplicationUser_Id", Function(c) c.String(maxLength := 128))
            AlterColumn("dbo.Installation", "Id", Function(c) c.Long(nullable := False))
            AlterColumn("dbo.Installation", "Organisation_Id", Function(c) c.Long())
            AlterColumn("dbo.Installation", "Adresse_Id", Function(c) c.Long())
            AlterColumn("dbo.Installation", "HeureDOuverture", Function(c) c.DateTime(nullable := False))
            AlterColumn("dbo.Installation", "HeureFermeture", Function(c) c.DateTime(nullable := False))
            AlterColumn("dbo.Installation", "ApplicationUser_Id", Function(c) c.String(maxLength := 128))
            AddPrimaryKey("dbo.Bureau", "Id")
            AddPrimaryKey("dbo.Installation", "Id")
            CreateIndex("dbo.Adresse", "VilleId")
            CreateIndex("dbo.Adresse", "Collectivite_Id")
            CreateIndex("dbo.Entrepots", "TypeEntrepotId")
            CreateIndex("dbo.Entrepots", "Organisation_Id1")
            CreateIndex("dbo.Entrepots", "ApplicationUser_Id1")
            CreateIndex("dbo.Entrepots", "Adresse_Id1")
            CreateIndex("dbo.Bureau", "Id")
            CreateIndex("dbo.Bureau", "Organisation_Id")
            CreateIndex("dbo.Bureau", "ApplicationUser_Id")
            CreateIndex("dbo.Bureau", "Adresse_Id")
            CreateIndex("dbo.Installation", "Id")
            CreateIndex("dbo.Installation", "Organisation_Id")
            CreateIndex("dbo.Installation", "ApplicationUser_Id")
            CreateIndex("dbo.Installation", "Adresse_Id")
            AddForeignKey("dbo.Entrepots", "TypeEntrepotId", "dbo.TypeEntrepot", "Id")
            AddForeignKey("dbo.Adresse", "VilleId", "dbo.Ville", "Id")
            AddForeignKey("dbo.Bureau", "Id", "dbo.Entrepots", "Id")
            AddForeignKey("dbo.Installation", "Id", "dbo.Entrepots", "Id")
            AddForeignKey("dbo.Entrepots", "Adresse_Id1", "dbo.Adresse", "Id")
            AddForeignKey("dbo.Entrepots", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id")
            AddForeignKey("dbo.Entrepots", "Organisation_Id1", "dbo.Oganisation", "Id")
            DropColumn("dbo.Bureau", "Libelle")
            DropColumn("dbo.Bureau", "CodePostale")
            DropColumn("dbo.Bureau", "Telephone")
            DropColumn("dbo.Bureau", "Email")
            DropColumn("dbo.Bureau", "HeureDOuverture")
            DropColumn("dbo.Bureau", "HeureFermeture")
            DropColumn("dbo.Bureau", "DateCreation")
            DropColumn("dbo.Bureau", "StatutExistant")
            DropColumn("dbo.Installation", "Libelle")
            DropColumn("dbo.Installation", "CodePostale")
            DropColumn("dbo.Installation", "Telephone")
            DropColumn("dbo.Installation", "Email")
            DropColumn("dbo.Installation", "DateCreation")
            DropColumn("dbo.Installation", "StatutExistant")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.Installation", "StatutExistant", Function(c) c.Short(nullable := False))
            AddColumn("dbo.Installation", "DateCreation", Function(c) c.DateTime(nullable := False))
            AddColumn("dbo.Installation", "Email", Function(c) c.String(maxLength := 250))
            AddColumn("dbo.Installation", "Telephone", Function(c) c.String(nullable := False, maxLength := 20))
            AddColumn("dbo.Installation", "CodePostale", Function(c) c.String(maxLength := 250))
            AddColumn("dbo.Installation", "Libelle", Function(c) c.String(nullable := False, maxLength := 250))
            AddColumn("dbo.Bureau", "StatutExistant", Function(c) c.Short(nullable := False))
            AddColumn("dbo.Bureau", "DateCreation", Function(c) c.DateTime(nullable := False))
            AddColumn("dbo.Bureau", "HeureFermeture", Function(c) c.String(nullable := False, maxLength := 250))
            AddColumn("dbo.Bureau", "HeureDOuverture", Function(c) c.String(nullable := False, maxLength := 250))
            AddColumn("dbo.Bureau", "Email", Function(c) c.String(nullable := False, maxLength := 250))
            AddColumn("dbo.Bureau", "Telephone", Function(c) c.String(nullable := False, maxLength := 20))
            AddColumn("dbo.Bureau", "CodePostale", Function(c) c.String(nullable := False, maxLength := 250))
            AddColumn("dbo.Bureau", "Libelle", Function(c) c.String(nullable := False, maxLength := 250))
            DropForeignKey("dbo.Entrepots", "Organisation_Id1", "dbo.Oganisation")
            DropForeignKey("dbo.Entrepots", "ApplicationUser_Id1", "dbo.AspNetUsers")
            DropForeignKey("dbo.Entrepots", "Adresse_Id1", "dbo.Adresse")
            DropForeignKey("dbo.Vehicule", "TypeVehiculeId", "dbo.TypeVehicule")
            DropForeignKey("dbo.Vehicule", "Id", "dbo.Immobilisation")
            DropForeignKey("dbo.Installation", "Id", "dbo.Entrepots")
            DropForeignKey("dbo.Bureau", "Id", "dbo.Entrepots")
            DropForeignKey("dbo.PortDeMer", "OganisationId", "dbo.Oganisation")
            DropForeignKey("dbo.PortDeMer", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.PortDeMer", "AdresseId", "dbo.Adresse")
            DropForeignKey("dbo.TypeVehicule", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Immobilisation", "TypeImmobilisationId", "dbo.TypeImmobilisation")
            DropForeignKey("dbo.TypeImmobilisation", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Immobilisation", "InfrastructureId", "dbo.Entrepots")
            DropForeignKey("dbo.Immobilisation", "FournisseurId", "dbo.Oganisation")
            DropForeignKey("dbo.Immobilisation", "ElementId", "dbo.Element")
            DropForeignKey("dbo.Immobilisation", "DeviseId", "dbo.Devise")
            DropForeignKey("dbo.Immobilisation", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Hopitaux", "TypeHopitauxId", "dbo.TypeHopitaux")
            DropForeignKey("dbo.TypeHopitaux", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Hopitaux", "OganisationId", "dbo.Oganisation")
            DropForeignKey("dbo.HopitauxPuissance", "PuissanceId", "dbo.Puissance")
            DropForeignKey("dbo.Puissance", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.HopitauxPuissance", "HopitauxId", "dbo.Hopitaux")
            DropForeignKey("dbo.HopitauxPuissance", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Hopitaux", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Hopitaux", "AdresseId", "dbo.Adresse")
            DropForeignKey("dbo.Heliport", "OganisationId", "dbo.Oganisation")
            DropForeignKey("dbo.Heliport", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Heliport", "AdresseId", "dbo.Adresse")
            DropForeignKey("dbo.Element", "MarqueElementId", "dbo.MarqueElement")
            DropForeignKey("dbo.MarqueElement", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Element", "DeviseId", "dbo.Devise")
            DropForeignKey("dbo.Element", "CategorieElementId", "dbo.CategorieElement")
            DropForeignKey("dbo.Element", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.CategorieElement", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.UsageHumanitaire", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Aeroport", "UsageHumanitaireId", "dbo.UsageHumanitaire")
            DropForeignKey("dbo.TailleDeAeronef", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Aeroport", "TailleDeAeronefId", "dbo.TailleDeAeronef")
            DropForeignKey("dbo.SurfaceDePiste", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Aeroport", "SurfaceDePisteId", "dbo.SurfaceDePiste")
            DropForeignKey("dbo.Aeroport", "OganisationId", "dbo.Oganisation")
            DropForeignKey("dbo.Aeroport", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Aeroport", "AdresseId", "dbo.Adresse")
            DropForeignKey("dbo.Adresse", "VilleId", "dbo.Ville")
            DropForeignKey("dbo.PersonnelInstallation", "PersonnelId", "dbo.Personnel")
            DropForeignKey("dbo.PersonnelInstallation", "InstallationId", "dbo.Installation")
            DropForeignKey("dbo.PersonnelInstallation", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.PersonnelBureau", "PersonnelId", "dbo.Personnel")
            DropForeignKey("dbo.PersonnelAbris", "PersonnelId", "dbo.Personnel")
            DropForeignKey("dbo.PersonnelAbris", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.PersonnelAbris", "AbrisId", "dbo.Abris")
            DropForeignKey("dbo.Entrepots", "TypeEntrepotId", "dbo.TypeEntrepot")
            DropForeignKey("dbo.TypeEntrepot", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.PersonnelBureau", "BureauId", "dbo.Bureau")
            DropForeignKey("dbo.PersonnelBureau", "AspNetUserId", "dbo.AspNetUsers")
            DropIndex("dbo.Vehicule", New String() { "TypeVehiculeId" })
            DropIndex("dbo.Vehicule", New String() { "Id" })
            DropIndex("dbo.Installation", New String() { "Adresse_Id" })
            DropIndex("dbo.Installation", New String() { "ApplicationUser_Id" })
            DropIndex("dbo.Installation", New String() { "Organisation_Id" })
            DropIndex("dbo.Installation", New String() { "Id" })
            DropIndex("dbo.Bureau", New String() { "Adresse_Id" })
            DropIndex("dbo.Bureau", New String() { "ApplicationUser_Id" })
            DropIndex("dbo.Bureau", New String() { "Organisation_Id" })
            DropIndex("dbo.Bureau", New String() { "Id" })
            DropIndex("dbo.PortDeMer", New String() { "AspNetUserId" })
            DropIndex("dbo.PortDeMer", New String() { "OganisationId" })
            DropIndex("dbo.PortDeMer", New String() { "AdresseId" })
            DropIndex("dbo.TypeVehicule", New String() { "AspNetUserId" })
            DropIndex("dbo.TypeImmobilisation", New String() { "AspNetUserId" })
            DropIndex("dbo.Immobilisation", New String() { "AspNetUserId" })
            DropIndex("dbo.Immobilisation", New String() { "DeviseId" })
            DropIndex("dbo.Immobilisation", New String() { "ElementId" })
            DropIndex("dbo.Immobilisation", New String() { "FournisseurId" })
            DropIndex("dbo.Immobilisation", New String() { "InfrastructureId" })
            DropIndex("dbo.Immobilisation", New String() { "TypeImmobilisationId" })
            DropIndex("dbo.TypeHopitaux", New String() { "AspNetUserId" })
            DropIndex("dbo.Puissance", New String() { "AspNetUserId" })
            DropIndex("dbo.HopitauxPuissance", New String() { "AspNetUserId" })
            DropIndex("dbo.HopitauxPuissance", New String() { "PuissanceId" })
            DropIndex("dbo.HopitauxPuissance", New String() { "HopitauxId" })
            DropIndex("dbo.Hopitaux", New String() { "AspNetUserId" })
            DropIndex("dbo.Hopitaux", New String() { "AdresseId" })
            DropIndex("dbo.Hopitaux", New String() { "TypeHopitauxId" })
            DropIndex("dbo.Hopitaux", New String() { "OganisationId" })
            DropIndex("dbo.Heliport", New String() { "AspNetUserId" })
            DropIndex("dbo.Heliport", New String() { "AdresseId" })
            DropIndex("dbo.Heliport", New String() { "OganisationId" })
            DropIndex("dbo.MarqueElement", New String() { "AspNetUserId" })
            DropIndex("dbo.Element", New String() { "AspNetUserId" })
            DropIndex("dbo.Element", New String() { "DeviseId" })
            DropIndex("dbo.Element", New String() { "MarqueElementId" })
            DropIndex("dbo.Element", New String() { "CategorieElementId" })
            DropIndex("dbo.CategorieElement", New String() { "AspNetUserId" })
            DropIndex("dbo.UsageHumanitaire", New String() { "AspNetUserId" })
            DropIndex("dbo.TailleDeAeronef", New String() { "AspNetUserId" })
            DropIndex("dbo.SurfaceDePiste", New String() { "AspNetUserId" })
            DropIndex("dbo.Aeroport", New String() { "AspNetUserId" })
            DropIndex("dbo.Aeroport", New String() { "UsageHumanitaireId" })
            DropIndex("dbo.Aeroport", New String() { "TailleDeAeronefId" })
            DropIndex("dbo.Aeroport", New String() { "SurfaceDePisteId" })
            DropIndex("dbo.Aeroport", New String() { "AdresseId" })
            DropIndex("dbo.Aeroport", New String() { "OganisationId" })
            DropIndex("dbo.PersonnelInstallation", New String() { "AspNetUserId" })
            DropIndex("dbo.PersonnelInstallation", New String() { "InstallationId" })
            DropIndex("dbo.PersonnelInstallation", New String() { "PersonnelId" })
            DropIndex("dbo.PersonnelAbris", New String() { "AspNetUserId" })
            DropIndex("dbo.PersonnelAbris", New String() { "AbrisId" })
            DropIndex("dbo.PersonnelAbris", New String() { "PersonnelId" })
            DropIndex("dbo.TypeEntrepot", New String() { "AspNetUserId" })
            DropIndex("dbo.PersonnelBureau", New String() { "AspNetUserId" })
            DropIndex("dbo.PersonnelBureau", New String() { "BureauId" })
            DropIndex("dbo.PersonnelBureau", New String() { "PersonnelId" })
            DropIndex("dbo.Entrepots", New String() { "Adresse_Id1" })
            DropIndex("dbo.Entrepots", New String() { "ApplicationUser_Id1" })
            DropIndex("dbo.Entrepots", New String() { "Organisation_Id1" })
            DropIndex("dbo.Entrepots", New String() { "TypeEntrepotId" })
            DropIndex("dbo.Adresse", New String() { "Collectivite_Id" })
            DropIndex("dbo.Adresse", New String() { "VilleId" })
            DropPrimaryKey("dbo.Installation")
            DropPrimaryKey("dbo.Bureau")
            AlterColumn("dbo.Installation", "ApplicationUser_Id", Function(c) c.String(nullable := False, maxLength := 128))
            AlterColumn("dbo.Installation", "HeureFermeture", Function(c) c.String(nullable := False, maxLength := 20))
            AlterColumn("dbo.Installation", "HeureDOuverture", Function(c) c.String(nullable := False, maxLength := 20))
            AlterColumn("dbo.Installation", "Adresse_Id", Function(c) c.Long(nullable := False))
            AlterColumn("dbo.Installation", "Organisation_Id", Function(c) c.Long(nullable := False))
            AlterColumn("dbo.Installation", "Id", Function(c) c.Long(nullable := False, identity := True))
            AlterColumn("dbo.Bureau", "ApplicationUser_Id", Function(c) c.String(nullable := False, maxLength := 128))
            AlterColumn("dbo.Bureau", "Adresse_Id", Function(c) c.Long(nullable := False))
            AlterColumn("dbo.Bureau", "Organisation_Id", Function(c) c.Long(nullable := False))
            AlterColumn("dbo.Bureau", "Id", Function(c) c.Long(nullable := False, identity := True))
            AlterColumn("dbo.Adresse", "Collectivite_Id", Function(c) c.Long(nullable := False))
            DropColumn("dbo.Entrepots", "Adresse_Id1")
            DropColumn("dbo.Entrepots", "ApplicationUser_Id1")
            DropColumn("dbo.Entrepots", "Organisation_Id1")
            DropColumn("dbo.Entrepots", "Discriminator")
            DropColumn("dbo.Entrepots", "CapaciteDisponible")
            DropColumn("dbo.Entrepots", "Capacite")
            DropColumn("dbo.Entrepots", "TypeEntrepotId")
            DropColumn("dbo.Entrepots", "Telephone2")
            DropColumn("dbo.Entrepots", "Code")
            DropColumn("dbo.Adresse", "VilleId")
            DropColumn("dbo.Abris", "Capacite")
            DropTable("dbo.Vehicule")
            DropTable("dbo.PortDeMer")
            DropTable("dbo.TypeVehicule")
            DropTable("dbo.TypeImmobilisation")
            DropTable("dbo.Immobilisation")
            DropTable("dbo.TypeHopitaux")
            DropTable("dbo.Puissance")
            DropTable("dbo.HopitauxPuissance")
            DropTable("dbo.Hopitaux")
            DropTable("dbo.Heliport")
            DropTable("dbo.MarqueElement")
            DropTable("dbo.Element")
            DropTable("dbo.CategorieElement")
            DropTable("dbo.UsageHumanitaire")
            DropTable("dbo.TailleDeAeronef")
            DropTable("dbo.SurfaceDePiste")
            DropTable("dbo.Aeroport")
            DropTable("dbo.PersonnelInstallation")
            DropTable("dbo.PersonnelAbris")
            DropTable("dbo.TypeEntrepot")
            DropTable("dbo.PersonnelBureau")
            AddPrimaryKey("dbo.Installation", "Id")
            AddPrimaryKey("dbo.Bureau", "Id")
            RenameColumn(table := "dbo.Installation", name := "Organisation_Id", newName := "OganisationId")
            RenameColumn(table := "dbo.Bureau", name := "Organisation_Id", newName := "OganisationId")
            RenameColumn(table := "dbo.Adresse", name := "Collectivite_Id", newName := "CollectiviteId")
            RenameColumn(table := "dbo.Installation", name := "ApplicationUser_Id", newName := "AspNetUserId")
            RenameColumn(table := "dbo.Bureau", name := "ApplicationUser_Id", newName := "AspNetUserId")
            RenameColumn(table := "dbo.Installation", name := "Adresse_Id", newName := "AdresseId")
            RenameColumn(table := "dbo.Bureau", name := "Adresse_Id", newName := "AdresseId")
            CreateIndex("dbo.Installation", "AspNetUserId")
            CreateIndex("dbo.Installation", "AdresseId")
            CreateIndex("dbo.Installation", "OganisationId")
            CreateIndex("dbo.Bureau", "AspNetUserId")
            CreateIndex("dbo.Bureau", "AdresseId")
            CreateIndex("dbo.Bureau", "OganisationId")
            CreateIndex("dbo.Adresse", "CollectiviteId")
            AddForeignKey("dbo.Entrepots", "OganisationId", "dbo.Oganisation", "Id")
            AddForeignKey("dbo.Entrepots", "AspNetUserId", "dbo.AspNetUsers", "Id")
            AddForeignKey("dbo.Entrepots", "AdresseId", "dbo.Adresse", "Id")
            RenameTable(name := "dbo.PersonnelProjet", newName := "PersonnelProjets")
        End Sub
    End Class
End Namespace
