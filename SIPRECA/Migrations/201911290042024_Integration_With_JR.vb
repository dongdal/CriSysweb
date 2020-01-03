Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Integration_With_JR
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.ZoneARisque", "Rayon", Function(c) c.Double(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.ZoneARisque", "Rayon")
        End Sub
    End Class
End Namespace
