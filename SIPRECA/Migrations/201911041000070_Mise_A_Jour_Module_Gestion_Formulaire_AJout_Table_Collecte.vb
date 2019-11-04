Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Mise_A_Jour_Module_Gestion_Formulaire_AJout_Table_Collecte
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Collecte",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .Valeur = c.Long(),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .Latitude = c.Double(),
                        .Longitude = c.Double(),
                        .LibellePosition = c.String(maxLength := 250),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .Index(Function(t) t.AspNetUserId)
            
            AddColumn("dbo.ValeurChamps", "CollecteId", Function(c) c.Long(nullable := False))
            CreateIndex("dbo.ValeurChamps", "CollecteId")
            AddForeignKey("dbo.ValeurChamps", "CollecteId", "dbo.Collecte", "Id")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.ValeurChamps", "CollecteId", "dbo.Collecte")
            DropForeignKey("dbo.Collecte", "AspNetUserId", "dbo.AspNetUsers")
            DropIndex("dbo.Collecte", New String() { "AspNetUserId" })
            DropIndex("dbo.ValeurChamps", New String() { "CollecteId" })
            DropColumn("dbo.ValeurChamps", "CollecteId")
            DropTable("dbo.Collecte")
        End Sub
    End Class
End Namespace
