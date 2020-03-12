Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Alter_table_rename_column_ModuleId_to_ModulesId
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropIndex("dbo.Ressource", New String() { "Modules_Id" })
            RenameColumn(table := "dbo.Ressource", name := "Modules_Id", newName := "ModulesId")
            AlterColumn("dbo.Ressource", "ModulesId", Function(c) c.Long(nullable := False))
            CreateIndex("dbo.Ressource", "ModulesId")
            DropColumn("dbo.Ressource", "ModuleId")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.Ressource", "ModuleId", Function(c) c.Long(nullable := False))
            DropIndex("dbo.Ressource", New String() { "ModulesId" })
            AlterColumn("dbo.Ressource", "ModulesId", Function(c) c.Long())
            RenameColumn(table := "dbo.Ressource", name := "ModulesId", newName := "Modules_Id")
            CreateIndex("dbo.Ressource", "Modules_Id")
        End Sub
    End Class
End Namespace
