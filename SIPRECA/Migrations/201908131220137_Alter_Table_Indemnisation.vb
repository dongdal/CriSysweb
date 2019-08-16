Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Alter_Table_Indemnisation
        Inherits DbMigration
    
        Public Overrides Sub Up()
            RenameTable(name := "dbo.DetailsIndemnisations", newName := "DetailsIndemnisation")
            DropIndex("dbo.DetailsIndemnisation", New String() { "AspNetUserId" })
            AlterColumn("dbo.DetailsIndemnisation", "Description", Function(c) c.String(maxLength := 4000))
            AlterColumn("dbo.DetailsIndemnisation", "AspNetUserId", Function(c) c.String(nullable := False, maxLength := 128))
            CreateIndex("dbo.DetailsIndemnisation", "AspNetUserId")
        End Sub
        
        Public Overrides Sub Down()
            DropIndex("dbo.DetailsIndemnisation", New String() { "AspNetUserId" })
            AlterColumn("dbo.DetailsIndemnisation", "AspNetUserId", Function(c) c.String(maxLength := 128))
            AlterColumn("dbo.DetailsIndemnisation", "Description", Function(c) c.String())
            CreateIndex("dbo.DetailsIndemnisation", "AspNetUserId")
            RenameTable(name := "dbo.DetailsIndemnisation", newName := "DetailsIndemnisations")
        End Sub
    End Class
End Namespace
