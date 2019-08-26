Imports System
Imports System.Data.Entity.Migrations
Imports System.Data.Entity.Spatial
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Miseajourdesadresse
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.Adresse", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Hopitaux", "AdresseId", "dbo.Adresse")
            DropForeignKey("dbo.Infrastructure", "AdresseId", "dbo.Adresse")
            DropForeignKey("dbo.Adresse", "VilleId", "dbo.Ville")
            DropForeignKey("dbo.Abris", "AdresseId", "dbo.Adresse")
            DropForeignKey("dbo.Aeroport", "AdresseId", "dbo.Adresse")
            DropForeignKey("dbo.Heliport", "AdresseId", "dbo.Adresse")
            DropForeignKey("dbo.PortDeMer", "AdresseId", "dbo.Adresse")
            DropIndex("dbo.Abris", New String() { "AdresseId" })
            DropIndex("dbo.Adresse", New String() { "VilleId" })
            DropIndex("dbo.Adresse", New String() { "AspNetUserId" })
            DropIndex("dbo.Hopitaux", New String() { "AdresseId" })
            DropIndex("dbo.Infrastructure", New String() { "AdresseId" })
            DropIndex("dbo.Aeroport", New String() { "AdresseId" })
            DropIndex("dbo.Heliport", New String() { "AdresseId" })
            DropIndex("dbo.PortDeMer", New String() { "AdresseId" })
            AddColumn("dbo.Abris", "VilleId", Function(c) c.Long(nullable := False))
            AddColumn("dbo.Abris", "Location", Function(c) c.Geography())
            AddColumn("dbo.Hopitaux", "VilleId", Function(c) c.Long(nullable := False))
            AddColumn("dbo.Hopitaux", "Location", Function(c) c.Geography())
            AddColumn("dbo.Infrastructure", "VilleId", Function(c) c.Long(nullable := False))
            AddColumn("dbo.Infrastructure", "Location", Function(c) c.Geography())
            AddColumn("dbo.Aeroport", "VilleId", Function(c) c.Long(nullable := False))
            AddColumn("dbo.Aeroport", "Location", Function(c) c.Geography())
            AddColumn("dbo.Heliport", "VilleId", Function(c) c.Long(nullable := False))
            AddColumn("dbo.Heliport", "Location", Function(c) c.Geography())
            AddColumn("dbo.PortDeMer", "VilleId", Function(c) c.Long(nullable := False))
            AddColumn("dbo.PortDeMer", "Location", Function(c) c.Geography())
            CreateIndex("dbo.Abris", "VilleId")
            CreateIndex("dbo.Hopitaux", "VilleId")
            CreateIndex("dbo.Infrastructure", "VilleId")
            CreateIndex("dbo.Aeroport", "VilleId")
            CreateIndex("dbo.Heliport", "VilleId")
            CreateIndex("dbo.PortDeMer", "VilleId")
            AddForeignKey("dbo.Hopitaux", "VilleId", "dbo.Ville", "Id")
            AddForeignKey("dbo.Infrastructure", "VilleId", "dbo.Ville", "Id")
            AddForeignKey("dbo.Abris", "VilleId", "dbo.Ville", "Id")
            AddForeignKey("dbo.Aeroport", "VilleId", "dbo.Ville", "Id")
            AddForeignKey("dbo.Heliport", "VilleId", "dbo.Ville", "Id")
            AddForeignKey("dbo.PortDeMer", "VilleId", "dbo.Ville", "Id")
            DropColumn("dbo.Abris", "AdresseId")
            DropColumn("dbo.Hopitaux", "AdresseId")
            DropColumn("dbo.Infrastructure", "AdresseId")
            DropColumn("dbo.Aeroport", "AdresseId")
            DropColumn("dbo.Heliport", "AdresseId")
            DropColumn("dbo.PortDeMer", "AdresseId")
            DropTable("dbo.Adresse")
        End Sub
        
        Public Overrides Sub Down()
            CreateTable(
                "dbo.Adresse",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .VilleId = c.Long(nullable := False),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .Location = c.Geography(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            AddColumn("dbo.PortDeMer", "AdresseId", Function(c) c.Long(nullable := False))
            AddColumn("dbo.Heliport", "AdresseId", Function(c) c.Long(nullable := False))
            AddColumn("dbo.Aeroport", "AdresseId", Function(c) c.Long())
            AddColumn("dbo.Infrastructure", "AdresseId", Function(c) c.Long(nullable := False))
            AddColumn("dbo.Hopitaux", "AdresseId", Function(c) c.Long(nullable := False))
            AddColumn("dbo.Abris", "AdresseId", Function(c) c.Long(nullable := False))
            DropForeignKey("dbo.PortDeMer", "VilleId", "dbo.Ville")
            DropForeignKey("dbo.Heliport", "VilleId", "dbo.Ville")
            DropForeignKey("dbo.Aeroport", "VilleId", "dbo.Ville")
            DropForeignKey("dbo.Abris", "VilleId", "dbo.Ville")
            DropForeignKey("dbo.Infrastructure", "VilleId", "dbo.Ville")
            DropForeignKey("dbo.Hopitaux", "VilleId", "dbo.Ville")
            DropIndex("dbo.PortDeMer", New String() { "VilleId" })
            DropIndex("dbo.Heliport", New String() { "VilleId" })
            DropIndex("dbo.Aeroport", New String() { "VilleId" })
            DropIndex("dbo.Infrastructure", New String() { "VilleId" })
            DropIndex("dbo.Hopitaux", New String() { "VilleId" })
            DropIndex("dbo.Abris", New String() { "VilleId" })
            DropColumn("dbo.PortDeMer", "Location")
            DropColumn("dbo.PortDeMer", "VilleId")
            DropColumn("dbo.Heliport", "Location")
            DropColumn("dbo.Heliport", "VilleId")
            DropColumn("dbo.Aeroport", "Location")
            DropColumn("dbo.Aeroport", "VilleId")
            DropColumn("dbo.Infrastructure", "Location")
            DropColumn("dbo.Infrastructure", "VilleId")
            DropColumn("dbo.Hopitaux", "Location")
            DropColumn("dbo.Hopitaux", "VilleId")
            DropColumn("dbo.Abris", "Location")
            DropColumn("dbo.Abris", "VilleId")
            CreateIndex("dbo.PortDeMer", "AdresseId")
            CreateIndex("dbo.Heliport", "AdresseId")
            CreateIndex("dbo.Aeroport", "AdresseId")
            CreateIndex("dbo.Infrastructure", "AdresseId")
            CreateIndex("dbo.Hopitaux", "AdresseId")
            CreateIndex("dbo.Adresse", "AspNetUserId")
            CreateIndex("dbo.Adresse", "VilleId")
            CreateIndex("dbo.Abris", "AdresseId")
            AddForeignKey("dbo.PortDeMer", "AdresseId", "dbo.Adresse", "Id")
            AddForeignKey("dbo.Heliport", "AdresseId", "dbo.Adresse", "Id")
            AddForeignKey("dbo.Aeroport", "AdresseId", "dbo.Adresse", "Id")
            AddForeignKey("dbo.Abris", "AdresseId", "dbo.Adresse", "Id")
            AddForeignKey("dbo.Adresse", "VilleId", "dbo.Ville", "Id")
            AddForeignKey("dbo.Infrastructure", "AdresseId", "dbo.Adresse", "Id")
            AddForeignKey("dbo.Hopitaux", "AdresseId", "dbo.Adresse", "Id")
            AddForeignKey("dbo.Adresse", "AspNetUserId", "dbo.AspNetUsers", "Id")
        End Sub
    End Class
End Namespace
