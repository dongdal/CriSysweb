Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Alter_Table_Heliports_Change_Column_Location_From_DbGeography_to_DbGeometry
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.Heliport", "Location", Function(c) c.Geometry())
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.Heliport", "Location", Function(c) c.Geography())
        End Sub
    End Class
End Namespace
