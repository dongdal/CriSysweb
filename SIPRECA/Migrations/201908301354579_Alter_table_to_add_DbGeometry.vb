Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Alter_table_to_add_DbGeometry
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.Abris", "Location", Function(c) c.Geometry())
            AlterColumn("dbo.Hopitaux", "Location", Function(c) c.Geometry())
            AlterColumn("dbo.Infrastructure", "Location", Function(c) c.Geometry())
            AlterColumn("dbo.Aeroport", "Location", Function(c) c.Geometry())
            AlterColumn("dbo.PortDeMer", "Location", Function(c) c.Geometry())
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.PortDeMer", "Location", Function(c) c.Geography())
            AlterColumn("dbo.Aeroport", "Location", Function(c) c.Geography())
            AlterColumn("dbo.Infrastructure", "Location", Function(c) c.Geography())
            AlterColumn("dbo.Hopitaux", "Location", Function(c) c.Geography())
            AlterColumn("dbo.Abris", "Location", Function(c) c.Geography())
        End Sub
    End Class
End Namespace
