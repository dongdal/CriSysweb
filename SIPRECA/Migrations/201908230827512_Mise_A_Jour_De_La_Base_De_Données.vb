Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Mise_A_Jour_De_La_Base_De_Données
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.Projet", "AdresseId", "dbo.Adresse")
            DropForeignKey("dbo.Organisation", "SecteurId", "dbo.Secteur")
            DropIndex("dbo.Projet", New String() { "AdresseId" })
            DropIndex("dbo.Organisation", New String() { "SecteurId" })
            DropIndex("dbo.Aeroport", New String() { "AdresseId" })
            DropIndex("dbo.Aeroport", New String() { "SurfaceDePisteId" })
            DropIndex("dbo.Aeroport", New String() { "TailleDeAeronefId" })
            DropIndex("dbo.Aeroport", New String() { "UsageHumanitaireId" })
            AlterColumn("dbo.Aeroport", "AdresseId", Function(c) c.Long())
            AlterColumn("dbo.Aeroport", "SurfaceDePisteId", Function(c) c.Long())
            AlterColumn("dbo.Aeroport", "TailleDeAeronefId", Function(c) c.Long())
            AlterColumn("dbo.Aeroport", "UsageHumanitaireId", Function(c) c.Long())
            AlterColumn("dbo.Aeroport", "ICAO", Function(c) c.String())
            AlterColumn("dbo.Aeroport", "IATA", Function(c) c.String())
            AlterColumn("dbo.Aeroport", "Telephone", Function(c) c.String(maxLength := 20))
            CreateIndex("dbo.Aeroport", "AdresseId")
            CreateIndex("dbo.Aeroport", "SurfaceDePisteId")
            CreateIndex("dbo.Aeroport", "TailleDeAeronefId")
            CreateIndex("dbo.Aeroport", "UsageHumanitaireId")
            DropColumn("dbo.Projet", "AdresseId")
            DropColumn("dbo.Organisation", "SecteurId")
            DropColumn("dbo.HopitauxPuissance", "Libelle")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.HopitauxPuissance", "Libelle", Function(c) c.String())
            AddColumn("dbo.Organisation", "SecteurId", Function(c) c.Long(nullable := False))
            AddColumn("dbo.Projet", "AdresseId", Function(c) c.Long(nullable := False))
            DropIndex("dbo.Aeroport", New String() { "UsageHumanitaireId" })
            DropIndex("dbo.Aeroport", New String() { "TailleDeAeronefId" })
            DropIndex("dbo.Aeroport", New String() { "SurfaceDePisteId" })
            DropIndex("dbo.Aeroport", New String() { "AdresseId" })
            AlterColumn("dbo.Aeroport", "Telephone", Function(c) c.String(nullable := False, maxLength := 20))
            AlterColumn("dbo.Aeroport", "IATA", Function(c) c.String(nullable := False))
            AlterColumn("dbo.Aeroport", "ICAO", Function(c) c.String(nullable := False))
            AlterColumn("dbo.Aeroport", "UsageHumanitaireId", Function(c) c.Long(nullable := False))
            AlterColumn("dbo.Aeroport", "TailleDeAeronefId", Function(c) c.Long(nullable := False))
            AlterColumn("dbo.Aeroport", "SurfaceDePisteId", Function(c) c.Long(nullable := False))
            AlterColumn("dbo.Aeroport", "AdresseId", Function(c) c.Long(nullable := False))
            CreateIndex("dbo.Aeroport", "UsageHumanitaireId")
            CreateIndex("dbo.Aeroport", "TailleDeAeronefId")
            CreateIndex("dbo.Aeroport", "SurfaceDePisteId")
            CreateIndex("dbo.Aeroport", "AdresseId")
            CreateIndex("dbo.Organisation", "SecteurId")
            CreateIndex("dbo.Projet", "AdresseId")
            AddForeignKey("dbo.Organisation", "SecteurId", "dbo.Secteur", "Id")
            AddForeignKey("dbo.Projet", "AdresseId", "dbo.Adresse", "Id")
        End Sub
    End Class
End Namespace
