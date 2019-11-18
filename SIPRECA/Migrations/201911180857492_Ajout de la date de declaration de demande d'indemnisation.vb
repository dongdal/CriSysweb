Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Ajoutdeladatededeclarationdedemandedindemnisation
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Demande", "DateDeclaration", Function(c) c.DateTime(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.Demande", "DateDeclaration")
        End Sub
    End Class
End Namespace
