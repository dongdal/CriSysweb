Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Villeverscommunemoyendereponse
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.Aeroport", "VilleId", "dbo.Ville")
            DropForeignKey("dbo.Heliport", "VilleId", "dbo.Ville")
            DropForeignKey("dbo.PortDeMer", "VilleId", "dbo.Ville")
            DropForeignKey("dbo.Hopitaux", "VilleId", "dbo.Ville")
            DropForeignKey("dbo.Infrastructure", "VilleId", "dbo.Ville")
            DropForeignKey("dbo.Abris", "VilleId", "dbo.Ville")
            DropIndex("dbo.Abris", New String() { "VilleId" })
            DropIndex("dbo.Hopitaux", New String() { "VilleId" })
            DropIndex("dbo.Aeroport", New String() { "VilleId" })
            DropIndex("dbo.Infrastructure", New String() { "VilleId" })
            DropIndex("dbo.Heliport", New String() { "VilleId" })
            DropIndex("dbo.PortDeMer", New String() { "VilleId" })
            CreateTable(
                "dbo.Alert",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .OrganisationId = c.Long(nullable := False),
                        .SinistreId = c.Long(nullable := False),
                        .Contenu = c.String(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Organisation", Function(t) t.OrganisationId) _
                .ForeignKey("dbo.Sinistre", Function(t) t.SinistreId) _
                .Index(Function(t) t.OrganisationId) _
                .Index(Function(t) t.SinistreId) _
                .Index(Function(t) t.AspNetUserId)
            
            AddColumn("dbo.Abris", "CommuneId", Function(c) c.Long())
            AddColumn("dbo.Demande", "AnneeBudgetaireId", Function(c) c.Long())
            AddColumn("dbo.Demande", "Observation", Function(c) c.String())
            AddColumn("dbo.Hopitaux", "CommuneId", Function(c) c.Long())
            AddColumn("dbo.Aeroport", "CommuneId", Function(c) c.Long())
            AddColumn("dbo.Infrastructure", "CommuneId", Function(c) c.Long())
            AddColumn("dbo.Heliport", "CommuneId", Function(c) c.Long())
            AddColumn("dbo.PortDeMer", "CommuneId", Function(c) c.Long())
            AddColumn("dbo.TypeHopitaux", "Code", Function(c) c.String())
            AddColumn("dbo.TypeHopitaux", "Observation", Function(c) c.String())
            AddColumn("dbo.Sinistre", "LieuDuSinistre", Function(c) c.String())
            AddColumn("dbo.Sinistre", "DateDuSinistre", Function(c) c.DateTime(nullable := False))
            AddColumn("dbo.AutreImpactHumainEtEconomique", "Source", Function(c) c.String())
            AddColumn("dbo.CardreSendaiCibleA", "Source", Function(c) c.String())
            AddColumn("dbo.CardreSendaiCibleB", "Source", Function(c) c.String())
            AddColumn("dbo.CardreSendaiCibleC", "Source", Function(c) c.String())
            AddColumn("dbo.CardreSendaiCibleD", "Source", Function(c) c.String())
            CreateIndex("dbo.Abris", "CommuneId")
            CreateIndex("dbo.Aeroport", "CommuneId")
            CreateIndex("dbo.Infrastructure", "CommuneId")
            CreateIndex("dbo.Hopitaux", "CommuneId")
            CreateIndex("dbo.Demande", "AnneeBudgetaireId")
            CreateIndex("dbo.Heliport", "CommuneId")
            CreateIndex("dbo.PortDeMer", "CommuneId")
            AddForeignKey("dbo.Abris", "CommuneId", "dbo.Commune", "Id")
            AddForeignKey("dbo.Aeroport", "CommuneId", "dbo.Commune", "Id")
            AddForeignKey("dbo.Hopitaux", "CommuneId", "dbo.Commune", "Id")
            AddForeignKey("dbo.Infrastructure", "CommuneId", "dbo.Commune", "Id")
            AddForeignKey("dbo.Demande", "AnneeBudgetaireId", "dbo.AnneeBudgetaire", "Id")
            AddForeignKey("dbo.Heliport", "CommuneId", "dbo.Commune", "Id")
            AddForeignKey("dbo.PortDeMer", "CommuneId", "dbo.Commune", "Id")
            DropColumn("dbo.Abris", "VilleId")
            DropColumn("dbo.Hopitaux", "VilleId")
            DropColumn("dbo.Aeroport", "VilleId")
            DropColumn("dbo.Infrastructure", "VilleId")
            DropColumn("dbo.Heliport", "VilleId")
            DropColumn("dbo.PortDeMer", "VilleId")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.PortDeMer", "VilleId", Function(c) c.Long(nullable := False))
            AddColumn("dbo.Heliport", "VilleId", Function(c) c.Long(nullable := False))
            AddColumn("dbo.Infrastructure", "VilleId", Function(c) c.Long(nullable := False))
            AddColumn("dbo.Aeroport", "VilleId", Function(c) c.Long(nullable := False))
            AddColumn("dbo.Hopitaux", "VilleId", Function(c) c.Long(nullable := False))
            AddColumn("dbo.Abris", "VilleId", Function(c) c.Long(nullable := False))
            DropForeignKey("dbo.Alert", "SinistreId", "dbo.Sinistre")
            DropForeignKey("dbo.Alert", "OrganisationId", "dbo.Organisation")
            DropForeignKey("dbo.Alert", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.PortDeMer", "CommuneId", "dbo.Commune")
            DropForeignKey("dbo.Heliport", "CommuneId", "dbo.Commune")
            DropForeignKey("dbo.Demande", "AnneeBudgetaireId", "dbo.AnneeBudgetaire")
            DropForeignKey("dbo.Infrastructure", "CommuneId", "dbo.Commune")
            DropForeignKey("dbo.Hopitaux", "CommuneId", "dbo.Commune")
            DropForeignKey("dbo.Aeroport", "CommuneId", "dbo.Commune")
            DropForeignKey("dbo.Abris", "CommuneId", "dbo.Commune")
            DropIndex("dbo.Alert", New String() { "AspNetUserId" })
            DropIndex("dbo.Alert", New String() { "SinistreId" })
            DropIndex("dbo.Alert", New String() { "OrganisationId" })
            DropIndex("dbo.PortDeMer", New String() { "CommuneId" })
            DropIndex("dbo.Heliport", New String() { "CommuneId" })
            DropIndex("dbo.Demande", New String() { "AnneeBudgetaireId" })
            DropIndex("dbo.Hopitaux", New String() { "CommuneId" })
            DropIndex("dbo.Infrastructure", New String() { "CommuneId" })
            DropIndex("dbo.Aeroport", New String() { "CommuneId" })
            DropIndex("dbo.Abris", New String() { "CommuneId" })
            DropColumn("dbo.CardreSendaiCibleD", "Source")
            DropColumn("dbo.CardreSendaiCibleC", "Source")
            DropColumn("dbo.CardreSendaiCibleB", "Source")
            DropColumn("dbo.CardreSendaiCibleA", "Source")
            DropColumn("dbo.AutreImpactHumainEtEconomique", "Source")
            DropColumn("dbo.Sinistre", "DateDuSinistre")
            DropColumn("dbo.Sinistre", "LieuDuSinistre")
            DropColumn("dbo.TypeHopitaux", "Observation")
            DropColumn("dbo.TypeHopitaux", "Code")
            DropColumn("dbo.PortDeMer", "CommuneId")
            DropColumn("dbo.Heliport", "CommuneId")
            DropColumn("dbo.Infrastructure", "CommuneId")
            DropColumn("dbo.Aeroport", "CommuneId")
            DropColumn("dbo.Hopitaux", "CommuneId")
            DropColumn("dbo.Demande", "Observation")
            DropColumn("dbo.Demande", "AnneeBudgetaireId")
            DropColumn("dbo.Abris", "CommuneId")
            DropTable("dbo.Alert")
            CreateIndex("dbo.PortDeMer", "VilleId")
            CreateIndex("dbo.Heliport", "VilleId")
            CreateIndex("dbo.Infrastructure", "VilleId")
            CreateIndex("dbo.Aeroport", "VilleId")
            CreateIndex("dbo.Hopitaux", "VilleId")
            CreateIndex("dbo.Abris", "VilleId")
            AddForeignKey("dbo.Abris", "VilleId", "dbo.Ville", "Id")
            AddForeignKey("dbo.Infrastructure", "VilleId", "dbo.Ville", "Id")
            AddForeignKey("dbo.Hopitaux", "VilleId", "dbo.Ville", "Id")
            AddForeignKey("dbo.PortDeMer", "VilleId", "dbo.Ville", "Id")
            AddForeignKey("dbo.Heliport", "VilleId", "dbo.Ville", "Id")
            AddForeignKey("dbo.Aeroport", "VilleId", "dbo.Ville", "Id")
        End Sub
    End Class
End Namespace
