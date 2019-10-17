Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Miseajourcardresendaicibleb
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.CardreSendaiCibleB", "NombreTotalPersonneMaisonEndomage", Function(c) c.Long())
            AddColumn("dbo.CardreSendaiCibleB", "NombreTotalPersonneMaisonDetruite", Function(c) c.Long())
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.CardreSendaiCibleB", "NombreTotalPersonneMaisonDetruite")
            DropColumn("dbo.CardreSendaiCibleB", "NombreTotalPersonneMaisonEndomage")
        End Sub
    End Class
End Namespace
