Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Remove_Table_AspNetUserActionSousRessource
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.AspNetUserActionSousRessource", "ActionSousRessourceId", "dbo.ActionSousRessource")
            DropForeignKey("dbo.AspNetUserActionSousRessource", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.AspNetUserActionSousRessource", "UserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.AspNetUserActionSousRessource", "ApplicationUser_Id", "dbo.AspNetUsers")
            DropForeignKey("dbo.AspNetUserActionSousRessource", "ApplicationUser_Id1", "dbo.AspNetUsers")
            DropIndex("dbo.AspNetUserActionSousRessource", New String() { "AspNetUserId" })
            DropIndex("dbo.AspNetUserActionSousRessource", New String() { "ActionSousRessourceId" })
            DropIndex("dbo.AspNetUserActionSousRessource", New String() { "UserId" })
            DropIndex("dbo.AspNetUserActionSousRessource", New String() { "ApplicationUser_Id" })
            DropIndex("dbo.AspNetUserActionSousRessource", New String() { "ApplicationUser_Id1" })
            DropTable("dbo.AspNetUserActionSousRessource")
        End Sub
        
        Public Overrides Sub Down()
            CreateTable(
                "dbo.AspNetUserActionSousRessource",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128),
                        .ActionSousRessourceId = c.Long(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .UserId = c.String(nullable := False, maxLength := 128),
                        .ApplicationUser_Id = c.String(maxLength := 128),
                        .ApplicationUser_Id1 = c.String(maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            CreateIndex("dbo.AspNetUserActionSousRessource", "ApplicationUser_Id1")
            CreateIndex("dbo.AspNetUserActionSousRessource", "ApplicationUser_Id")
            CreateIndex("dbo.AspNetUserActionSousRessource", "UserId")
            CreateIndex("dbo.AspNetUserActionSousRessource", "ActionSousRessourceId")
            CreateIndex("dbo.AspNetUserActionSousRessource", "AspNetUserId")
            AddForeignKey("dbo.AspNetUserActionSousRessource", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id")
            AddForeignKey("dbo.AspNetUserActionSousRessource", "ApplicationUser_Id", "dbo.AspNetUsers", "Id")
            AddForeignKey("dbo.AspNetUserActionSousRessource", "UserId", "dbo.AspNetUsers", "Id")
            AddForeignKey("dbo.AspNetUserActionSousRessource", "AspNetUserId", "dbo.AspNetUsers", "Id")
            AddForeignKey("dbo.AspNetUserActionSousRessource", "ActionSousRessourceId", "dbo.ActionSousRessource", "Id")
        End Sub
    End Class
End Namespace
