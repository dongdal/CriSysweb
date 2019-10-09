Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Alter_Tables_PerteDeBetail_CibleCPerteBetail_DesagregationRecoltesAgricole_And_CibleCDesagregationRecolte
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.CibleCDesagregationAgricole", "PerteEconomique", Function(c) c.Double())
            AddColumn("dbo.CibleCDesagregationAgricole", "NombreHectarAfecter", Function(c) c.Double())
            AddColumn("dbo.CibleCDesagregationAgricole", "NombreHectarEndomager", Function(c) c.Double())
            AddColumn("dbo.CibleCDesagregationAgricole", "NombreHectarDetruit", Function(c) c.Double())
            AddColumn("dbo.DesagregationRecoltesAgricole", "Libellle", Function(c) c.String())
            AddColumn("dbo.CibleCPerteBetail", "PerteEconomique", Function(c) c.Double())
            AddColumn("dbo.CibleCPerteBetail", "NombreTotalAfecter", Function(c) c.Long())
            AddColumn("dbo.CibleCPerteBetail", "NombreTotalEndomager", Function(c) c.Long())
            AddColumn("dbo.CibleCPerteBetail", "NombreDetruitDetruit", Function(c) c.Long())
            AddColumn("dbo.PerteBetail", "Libelle", Function(c) c.String())
            DropColumn("dbo.DesagregationRecoltesAgricole", "PerteEconomique")
            DropColumn("dbo.DesagregationRecoltesAgricole", "NombreHectarAfecter")
            DropColumn("dbo.DesagregationRecoltesAgricole", "NombreHectarEndomager")
            DropColumn("dbo.DesagregationRecoltesAgricole", "NombreHectarDetruit")
            DropColumn("dbo.PerteBetail", "PerteEconomique")
            DropColumn("dbo.PerteBetail", "NombreTotalAfecter")
            DropColumn("dbo.PerteBetail", "NombreTotalEndomager")
            DropColumn("dbo.PerteBetail", "NombreDetruitDetruit")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.PerteBetail", "NombreDetruitDetruit", Function(c) c.Long())
            AddColumn("dbo.PerteBetail", "NombreTotalEndomager", Function(c) c.Long())
            AddColumn("dbo.PerteBetail", "NombreTotalAfecter", Function(c) c.Long())
            AddColumn("dbo.PerteBetail", "PerteEconomique", Function(c) c.Double())
            AddColumn("dbo.DesagregationRecoltesAgricole", "NombreHectarDetruit", Function(c) c.Double())
            AddColumn("dbo.DesagregationRecoltesAgricole", "NombreHectarEndomager", Function(c) c.Double())
            AddColumn("dbo.DesagregationRecoltesAgricole", "NombreHectarAfecter", Function(c) c.Double())
            AddColumn("dbo.DesagregationRecoltesAgricole", "PerteEconomique", Function(c) c.Double())
            DropColumn("dbo.PerteBetail", "Libelle")
            DropColumn("dbo.CibleCPerteBetail", "NombreDetruitDetruit")
            DropColumn("dbo.CibleCPerteBetail", "NombreTotalEndomager")
            DropColumn("dbo.CibleCPerteBetail", "NombreTotalAfecter")
            DropColumn("dbo.CibleCPerteBetail", "PerteEconomique")
            DropColumn("dbo.DesagregationRecoltesAgricole", "Libellle")
            DropColumn("dbo.CibleCDesagregationAgricole", "NombreHectarDetruit")
            DropColumn("dbo.CibleCDesagregationAgricole", "NombreHectarEndomager")
            DropColumn("dbo.CibleCDesagregationAgricole", "NombreHectarAfecter")
            DropColumn("dbo.CibleCDesagregationAgricole", "PerteEconomique")
        End Sub
    End Class
End Namespace
