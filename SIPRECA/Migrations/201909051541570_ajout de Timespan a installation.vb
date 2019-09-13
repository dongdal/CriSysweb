Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class ajoutdeTimespanainstallation
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.Installation", "HeureDOuverture", Function(c) c.Time(nullable := False, precision := 7))
            AlterColumn("dbo.Installation", "HeureFermeture", Function(c) c.Time(nullable := False, precision := 7))
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.Installation", "HeureFermeture", Function(c) c.DateTime(nullable := False))
            AlterColumn("dbo.Installation", "HeureDOuverture", Function(c) c.DateTime(nullable := False))
        End Sub
    End Class
End Namespace
