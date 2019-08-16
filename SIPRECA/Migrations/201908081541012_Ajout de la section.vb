Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Ajoutdelasection
        Inherits DbMigration
    
        Public Overrides Sub Up()
            RenameTable(name := "dbo.Sections", newName := "Section")
            DropIndex("dbo.Section", New String() { "AspNetUserId" })
            AlterColumn("dbo.Section", "Titre", Function(c) c.String(nullable := False, maxLength := 250))
            AlterColumn("dbo.Section", "AspNetUserId", Function(c) c.String(nullable := False, maxLength := 128))
            CreateIndex("dbo.Section", "AspNetUserId")
        End Sub
        
        Public Overrides Sub Down()
            DropIndex("dbo.Section", New String() { "AspNetUserId" })
            AlterColumn("dbo.Section", "AspNetUserId", Function(c) c.String(maxLength := 128))
            AlterColumn("dbo.Section", "Titre", Function(c) c.String())
            CreateIndex("dbo.Section", "AspNetUserId")
            RenameTable(name := "dbo.Section", newName := "Sections")
        End Sub
    End Class
End Namespace
