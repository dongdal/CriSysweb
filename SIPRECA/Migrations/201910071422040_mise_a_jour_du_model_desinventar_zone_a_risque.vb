Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class mise_a_jour_du_model_desinventar_zone_a_risque
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.ZoneARisque", "Libelle", Function(c) c.String(nullable := False, maxLength := 250))
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.ZoneARisque", "Libelle")
        End Sub
    End Class
End Namespace
