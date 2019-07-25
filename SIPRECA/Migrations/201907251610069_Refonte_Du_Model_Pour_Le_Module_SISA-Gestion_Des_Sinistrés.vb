Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Refonte_Du_Model_Pour_Le_Module_SISAGestion_Des_Sinistrés
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.Indemmisation", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Indemmisation", "CollectiviteId", "dbo.Collectivite")
            DropForeignKey("dbo.Indemmisation", "DemandeId", "dbo.Demande")
            DropIndex("dbo.Indemmisation", New String() { "DemandeId" })
            DropIndex("dbo.Indemmisation", New String() { "CollectiviteId" })
            DropIndex("dbo.Indemmisation", New String() { "AspNetUserId" })
            CreateTable(
                "dbo.CollectiviteSinistree",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .SinistreId = c.Long(nullable := False),
                        .CollectiviteId = c.Long(nullable := False),
                        .AnneeBudgetaireId = c.Long(nullable := False),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .DateSinistre = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AnneeBudgetaire", Function(t) t.AnneeBudgetaireId) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Collectivite", Function(t) t.CollectiviteId) _
                .ForeignKey("dbo.Sinistre", Function(t) t.SinistreId) _
                .Index(Function(t) t.SinistreId) _
                .Index(Function(t) t.CollectiviteId) _
                .Index(Function(t) t.AnneeBudgetaireId) _
                .Index(Function(t) t.AspNetUserId)
            
            AddColumn("dbo.Demande", "CollectiviteSinistreeId", Function(c) c.Long(nullable := False))
            CreateIndex("dbo.Demande", "CollectiviteSinistreeId")
            AddForeignKey("dbo.Demande", "CollectiviteSinistreeId", "dbo.CollectiviteSinistree", "Id")
            DropTable("dbo.Indemmisation")
        End Sub
        
        Public Overrides Sub Down()
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
                .PrimaryKey(Function(t) t.Id)
            
            DropForeignKey("dbo.CollectiviteSinistree", "SinistreId", "dbo.Sinistre")
            DropForeignKey("dbo.Demande", "CollectiviteSinistreeId", "dbo.CollectiviteSinistree")
            DropForeignKey("dbo.CollectiviteSinistree", "CollectiviteId", "dbo.Collectivite")
            DropForeignKey("dbo.CollectiviteSinistree", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.CollectiviteSinistree", "AnneeBudgetaireId", "dbo.AnneeBudgetaire")
            DropIndex("dbo.Demande", New String() { "CollectiviteSinistreeId" })
            DropIndex("dbo.CollectiviteSinistree", New String() { "AspNetUserId" })
            DropIndex("dbo.CollectiviteSinistree", New String() { "AnneeBudgetaireId" })
            DropIndex("dbo.CollectiviteSinistree", New String() { "CollectiviteId" })
            DropIndex("dbo.CollectiviteSinistree", New String() { "SinistreId" })
            DropColumn("dbo.Demande", "CollectiviteSinistreeId")
            DropTable("dbo.CollectiviteSinistree")
            CreateIndex("dbo.Indemmisation", "AspNetUserId")
            CreateIndex("dbo.Indemmisation", "CollectiviteId")
            CreateIndex("dbo.Indemmisation", "DemandeId")
            AddForeignKey("dbo.Indemmisation", "DemandeId", "dbo.Demande", "Id")
            AddForeignKey("dbo.Indemmisation", "CollectiviteId", "dbo.Collectivite", "Id")
            AddForeignKey("dbo.Indemmisation", "AspNetUserId", "dbo.AspNetUsers", "Id")
        End Sub
    End Class
End Namespace
