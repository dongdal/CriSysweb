Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Add_Acces_Rules_Tables
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Actions",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .Description = c.String(maxLength := 4000),
                        .StatutExistant = c.Short(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.ActionSousRessource",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .ActionsId = c.Long(nullable := False),
                        .SousRessourceId = c.Long(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Actions", Function(t) t.ActionsId) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.SousRessource", Function(t) t.SousRessourceId) _
                .Index(Function(t) t.ActionsId) _
                .Index(Function(t) t.SousRessourceId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.SousRessource",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .RessourceId = c.Long(nullable := False),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .Description = c.String(maxLength := 4000),
                        .StatutExistant = c.Short(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Ressource", Function(t) t.RessourceId) _
                .Index(Function(t) t.RessourceId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Ressource",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .ModuleId = c.Long(nullable := False),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .Description = c.String(maxLength := 4000),
                        .StatutExistant = c.Short(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128),
                        .Modules_Id = c.Long()
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Modules", Function(t) t.Modules_Id) _
                .Index(Function(t) t.AspNetUserId) _
                .Index(Function(t) t.Modules_Id)
            
            CreateTable(
                "dbo.Modules",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .Description = c.String(maxLength := 4000),
                        .StatutExistant = c.Short(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.ModuleRole",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .ModulesId = c.Long(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .AspNetRolesId = c.String(maxLength := 128),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetRoles", Function(t) t.AspNetRolesId) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Modules", Function(t) t.ModulesId) _
                .Index(Function(t) t.ModulesId) _
                .Index(Function(t) t.AspNetRolesId) _
                .Index(Function(t) t.AspNetUserId)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Actions", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.SousRessource", "RessourceId", "dbo.Ressource")
            DropForeignKey("dbo.Ressource", "Modules_Id", "dbo.Modules")
            DropForeignKey("dbo.ModuleRole", "ModulesId", "dbo.Modules")
            DropForeignKey("dbo.ModuleRole", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.ModuleRole", "AspNetRolesId", "dbo.AspNetRoles")
            DropForeignKey("dbo.Modules", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Ressource", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.SousRessource", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.ActionSousRessource", "SousRessourceId", "dbo.SousRessource")
            DropForeignKey("dbo.ActionSousRessource", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.ActionSousRessource", "ActionsId", "dbo.Actions")
            DropIndex("dbo.ModuleRole", New String() { "AspNetUserId" })
            DropIndex("dbo.ModuleRole", New String() { "AspNetRolesId" })
            DropIndex("dbo.ModuleRole", New String() { "ModulesId" })
            DropIndex("dbo.Modules", New String() { "AspNetUserId" })
            DropIndex("dbo.Ressource", New String() { "Modules_Id" })
            DropIndex("dbo.Ressource", New String() { "AspNetUserId" })
            DropIndex("dbo.SousRessource", New String() { "AspNetUserId" })
            DropIndex("dbo.SousRessource", New String() { "RessourceId" })
            DropIndex("dbo.ActionSousRessource", New String() { "AspNetUserId" })
            DropIndex("dbo.ActionSousRessource", New String() { "SousRessourceId" })
            DropIndex("dbo.ActionSousRessource", New String() { "ActionsId" })
            DropIndex("dbo.Actions", New String() { "AspNetUserId" })
            DropTable("dbo.ModuleRole")
            DropTable("dbo.Modules")
            DropTable("dbo.Ressource")
            DropTable("dbo.SousRessource")
            DropTable("dbo.ActionSousRessource")
            DropTable("dbo.Actions")
        End Sub
    End Class
End Namespace
