Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Alter_Table_ValeurChamps_Add_Fields_CodeCollecte_DateSynchro_DateCollecte_StatutExist_Latitude_Longitude
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.ValeurChamps", "CollecteId", "dbo.Collecte")
            DropIndex("dbo.ValeurChamps", New String() { "CollecteId" })
            DropIndex("dbo.ValeurChamps", New String() { "AspNetUserId" })
            AddColumn("dbo.ValeurChamps", "CodeCollecte", Function(c) c.String())
            AddColumn("dbo.ValeurChamps", "DateSynchronisation", Function(c) c.DateTime(nullable := False))
            AddColumn("dbo.ValeurChamps", "DateCollecte", Function(c) c.DateTime(nullable := False))
            AddColumn("dbo.ValeurChamps", "StatutExistant", Function(c) c.Short(nullable := False))
            AddColumn("dbo.ValeurChamps", "Latitude", Function(c) c.String(nullable := False, maxLength := 128))
            AddColumn("dbo.ValeurChamps", "Longitude", Function(c) c.String(nullable := False, maxLength := 128))
            AlterColumn("dbo.ValeurChamps", "AspNetUserId", Function(c) c.String(maxLength := 128))
            CreateIndex("dbo.ValeurChamps", "AspNetUserId")
            DropColumn("dbo.ValeurChamps", "CollecteId")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.ValeurChamps", "CollecteId", Function(c) c.Long(nullable := False))
            DropIndex("dbo.ValeurChamps", New String() { "AspNetUserId" })
            AlterColumn("dbo.ValeurChamps", "AspNetUserId", Function(c) c.String(nullable := False, maxLength := 128))
            DropColumn("dbo.ValeurChamps", "Longitude")
            DropColumn("dbo.ValeurChamps", "Latitude")
            DropColumn("dbo.ValeurChamps", "StatutExistant")
            DropColumn("dbo.ValeurChamps", "DateCollecte")
            DropColumn("dbo.ValeurChamps", "DateSynchronisation")
            DropColumn("dbo.ValeurChamps", "CodeCollecte")
            CreateIndex("dbo.ValeurChamps", "AspNetUserId")
            CreateIndex("dbo.ValeurChamps", "CollecteId")
            AddForeignKey("dbo.ValeurChamps", "CollecteId", "dbo.Collecte", "Id")
        End Sub
    End Class
End Namespace
