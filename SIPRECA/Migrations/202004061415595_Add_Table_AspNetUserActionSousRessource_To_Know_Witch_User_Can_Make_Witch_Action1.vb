Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Add_Table_AspNetUserActionSousRessource_To_Know_Witch_User_Can_Make_Witch_Action1
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.AspNetUserActionSousRessource",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128),
                        .ActionSousRessourceId = c.Long(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .UserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.ActionSousRessource", Function(t) t.ActionSousRessourceId) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.UserId) _
                .Index(Function(t) t.AspNetUserId) _
                .Index(Function(t) t.ActionSousRessourceId) _
                .Index(Function(t) t.UserId)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.AspNetUserActionSousRessource", "UserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.AspNetUserActionSousRessource", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.AspNetUserActionSousRessource", "ActionSousRessourceId", "dbo.ActionSousRessource")
            DropIndex("dbo.AspNetUserActionSousRessource", New String() { "UserId" })
            DropIndex("dbo.AspNetUserActionSousRessource", New String() { "ActionSousRessourceId" })
            DropIndex("dbo.AspNetUserActionSousRessource", New String() { "AspNetUserId" })
            DropTable("dbo.AspNetUserActionSousRessource")
        End Sub
    End Class
End Namespace
