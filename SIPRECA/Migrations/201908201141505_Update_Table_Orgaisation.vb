Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Update_Table_Orgaisation
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Oganisation", "SecteurId", Function(c) c.Long(nullable := False))
            AddColumn("dbo.Oganisation", "BoitePostale", Function(c) c.String())
            AddColumn("dbo.Oganisation", "VilleId", Function(c) c.Long(nullable := False))
            CreateIndex("dbo.Oganisation", "SecteurId")
            CreateIndex("dbo.Oganisation", "VilleId")
            AddForeignKey("dbo.Oganisation", "SecteurId", "dbo.Secteur", "Id")
            AddForeignKey("dbo.Oganisation", "VilleId", "dbo.Ville", "Id")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Oganisation", "VilleId", "dbo.Ville")
            DropForeignKey("dbo.Oganisation", "SecteurId", "dbo.Secteur")
            DropIndex("dbo.Oganisation", New String() { "VilleId" })
            DropIndex("dbo.Oganisation", New String() { "SecteurId" })
            DropColumn("dbo.Oganisation", "VilleId")
            DropColumn("dbo.Oganisation", "BoitePostale")
            DropColumn("dbo.Oganisation", "SecteurId")
        End Sub
    End Class
End Namespace
