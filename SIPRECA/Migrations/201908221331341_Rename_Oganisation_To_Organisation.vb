Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Rename_Oganisation_To_Organisation
        Inherits DbMigration
    
        Public Overrides Sub Up()
            RenameTable(name := "dbo.Oganisation", newName := "Organisation")
        End Sub
        
        Public Overrides Sub Down()
            RenameTable(name := "dbo.Organisation", newName := "Oganisation")
        End Sub
    End Class
End Namespace
