Imports System
Imports System.Data.Entity.Migrations
Imports System.Data.Entity.Spatial
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AjoutdelalocalisationsurzoneArisqueetdelaquantitésurlesequipements
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.MaterielHopitaux", "Quantite", Function(c) c.Long(nullable := False))
            AddColumn("dbo.MaterielAbris", "Quantite", Function(c) c.Long(nullable := False))
            AddColumn("dbo.MaterielAeroport", "Quantite", Function(c) c.Long(nullable := False))
            AddColumn("dbo.MaterielBureau", "Quantite", Function(c) c.Long(nullable := False))
            AddColumn("dbo.MaterielEntrepots", "Quantite", Function(c) c.Long(nullable := False))
            AddColumn("dbo.MaterielInstallation", "Quantite", Function(c) c.Long(nullable := False))
            AddColumn("dbo.MaterielHeliport", "Quantite", Function(c) c.Long(nullable := False))
            AddColumn("dbo.MaterielPortDeMer", "Quantite", Function(c) c.Long(nullable := False))
            AddColumn("dbo.ZoneARisque", "Location", Function(c) c.Geometry())
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.ZoneARisque", "Location")
            DropColumn("dbo.MaterielPortDeMer", "Quantite")
            DropColumn("dbo.MaterielHeliport", "Quantite")
            DropColumn("dbo.MaterielInstallation", "Quantite")
            DropColumn("dbo.MaterielEntrepots", "Quantite")
            DropColumn("dbo.MaterielBureau", "Quantite")
            DropColumn("dbo.MaterielAeroport", "Quantite")
            DropColumn("dbo.MaterielAbris", "Quantite")
            DropColumn("dbo.MaterielHopitaux", "Quantite")
        End Sub
    End Class
End Namespace
