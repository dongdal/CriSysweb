Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Modificationdumodelpourajoutduplateautechnique
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.MaterielHopitaux",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .HopitauxId = c.Long(nullable := False),
                        .MaterielId = c.Long(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Hopitaux", Function(t) t.HopitauxId) _
                .ForeignKey("dbo.Materiel", Function(t) t.MaterielId) _
                .Index(Function(t) t.HopitauxId) _
                .Index(Function(t) t.MaterielId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Materiel",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .Cible = c.Long(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.MaterielAbris",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .AbrisId = c.Long(nullable := False),
                        .MaterielId = c.Long(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Abris", Function(t) t.AbrisId) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Materiel", Function(t) t.MaterielId) _
                .Index(Function(t) t.AbrisId) _
                .Index(Function(t) t.MaterielId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.MaterielAeroport",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .AeroportId = c.Long(nullable := False),
                        .MaterielId = c.Long(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Aeroport", Function(t) t.AeroportId) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Materiel", Function(t) t.MaterielId) _
                .Index(Function(t) t.AeroportId) _
                .Index(Function(t) t.MaterielId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.MaterielBureau",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .BureauId = c.Long(nullable := False),
                        .MaterielId = c.Long(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Bureau", Function(t) t.BureauId) _
                .ForeignKey("dbo.Materiel", Function(t) t.MaterielId) _
                .Index(Function(t) t.BureauId) _
                .Index(Function(t) t.MaterielId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.MaterielEntrepots",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .EntrepotsId = c.Long(nullable := False),
                        .MaterielId = c.Long(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Entrepot", Function(t) t.EntrepotsId) _
                .ForeignKey("dbo.Materiel", Function(t) t.MaterielId) _
                .Index(Function(t) t.EntrepotsId) _
                .Index(Function(t) t.MaterielId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.MaterielInstallation",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .InstallationId = c.Long(nullable := False),
                        .MaterielId = c.Long(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Installation", Function(t) t.InstallationId) _
                .ForeignKey("dbo.Materiel", Function(t) t.MaterielId) _
                .Index(Function(t) t.InstallationId) _
                .Index(Function(t) t.MaterielId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.MaterielHeliport",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .HeliportId = c.Long(nullable := False),
                        .MaterielId = c.Long(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Heliport", Function(t) t.HeliportId) _
                .ForeignKey("dbo.Materiel", Function(t) t.MaterielId) _
                .Index(Function(t) t.HeliportId) _
                .Index(Function(t) t.MaterielId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.MaterielPortDeMer",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .PortDeMerId = c.Long(nullable := False),
                        .MaterielId = c.Long(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Materiel", Function(t) t.MaterielId) _
                .ForeignKey("dbo.PortDeMer", Function(t) t.PortDeMerId) _
                .Index(Function(t) t.PortDeMerId) _
                .Index(Function(t) t.MaterielId) _
                .Index(Function(t) t.AspNetUserId)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.MaterielPortDeMer", "PortDeMerId", "dbo.PortDeMer")
            DropForeignKey("dbo.MaterielPortDeMer", "MaterielId", "dbo.Materiel")
            DropForeignKey("dbo.MaterielPortDeMer", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.MaterielHopitaux", "MaterielId", "dbo.Materiel")
            DropForeignKey("dbo.MaterielHeliport", "MaterielId", "dbo.Materiel")
            DropForeignKey("dbo.MaterielHeliport", "HeliportId", "dbo.Heliport")
            DropForeignKey("dbo.MaterielHeliport", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.MaterielBureau", "MaterielId", "dbo.Materiel")
            DropForeignKey("dbo.MaterielInstallation", "MaterielId", "dbo.Materiel")
            DropForeignKey("dbo.MaterielInstallation", "InstallationId", "dbo.Installation")
            DropForeignKey("dbo.MaterielInstallation", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.MaterielEntrepots", "MaterielId", "dbo.Materiel")
            DropForeignKey("dbo.MaterielEntrepots", "EntrepotsId", "dbo.Entrepot")
            DropForeignKey("dbo.MaterielEntrepots", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.MaterielBureau", "BureauId", "dbo.Bureau")
            DropForeignKey("dbo.MaterielBureau", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.MaterielAeroport", "MaterielId", "dbo.Materiel")
            DropForeignKey("dbo.MaterielAeroport", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.MaterielAeroport", "AeroportId", "dbo.Aeroport")
            DropForeignKey("dbo.MaterielAbris", "MaterielId", "dbo.Materiel")
            DropForeignKey("dbo.MaterielAbris", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.MaterielAbris", "AbrisId", "dbo.Abris")
            DropForeignKey("dbo.Materiel", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.MaterielHopitaux", "HopitauxId", "dbo.Hopitaux")
            DropForeignKey("dbo.MaterielHopitaux", "AspNetUserId", "dbo.AspNetUsers")
            DropIndex("dbo.MaterielPortDeMer", New String() { "AspNetUserId" })
            DropIndex("dbo.MaterielPortDeMer", New String() { "MaterielId" })
            DropIndex("dbo.MaterielPortDeMer", New String() { "PortDeMerId" })
            DropIndex("dbo.MaterielHeliport", New String() { "AspNetUserId" })
            DropIndex("dbo.MaterielHeliport", New String() { "MaterielId" })
            DropIndex("dbo.MaterielHeliport", New String() { "HeliportId" })
            DropIndex("dbo.MaterielInstallation", New String() { "AspNetUserId" })
            DropIndex("dbo.MaterielInstallation", New String() { "MaterielId" })
            DropIndex("dbo.MaterielInstallation", New String() { "InstallationId" })
            DropIndex("dbo.MaterielEntrepots", New String() { "AspNetUserId" })
            DropIndex("dbo.MaterielEntrepots", New String() { "MaterielId" })
            DropIndex("dbo.MaterielEntrepots", New String() { "EntrepotsId" })
            DropIndex("dbo.MaterielBureau", New String() { "AspNetUserId" })
            DropIndex("dbo.MaterielBureau", New String() { "MaterielId" })
            DropIndex("dbo.MaterielBureau", New String() { "BureauId" })
            DropIndex("dbo.MaterielAeroport", New String() { "AspNetUserId" })
            DropIndex("dbo.MaterielAeroport", New String() { "MaterielId" })
            DropIndex("dbo.MaterielAeroport", New String() { "AeroportId" })
            DropIndex("dbo.MaterielAbris", New String() { "AspNetUserId" })
            DropIndex("dbo.MaterielAbris", New String() { "MaterielId" })
            DropIndex("dbo.MaterielAbris", New String() { "AbrisId" })
            DropIndex("dbo.Materiel", New String() { "AspNetUserId" })
            DropIndex("dbo.MaterielHopitaux", New String() { "AspNetUserId" })
            DropIndex("dbo.MaterielHopitaux", New String() { "MaterielId" })
            DropIndex("dbo.MaterielHopitaux", New String() { "HopitauxId" })
            DropTable("dbo.MaterielPortDeMer")
            DropTable("dbo.MaterielHeliport")
            DropTable("dbo.MaterielInstallation")
            DropTable("dbo.MaterielEntrepots")
            DropTable("dbo.MaterielBureau")
            DropTable("dbo.MaterielAeroport")
            DropTable("dbo.MaterielAbris")
            DropTable("dbo.Materiel")
            DropTable("dbo.MaterielHopitaux")
        End Sub
    End Class
End Namespace
