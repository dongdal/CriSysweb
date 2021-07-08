Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Alter_table_Collecte_Add_Field_DateCollecte
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Collecte", "DateCollecte", Function(c) c.DateTime(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.Collecte", "DateCollecte")
        End Sub
    End Class
End Namespace
