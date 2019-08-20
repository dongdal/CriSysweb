Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Remove_Fields_On_Table_Pays
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropColumn("dbo.Pays", "Capital")
            DropColumn("dbo.Pays", "CurrencyCode")
            DropColumn("dbo.Pays", "CurrencyName")
            DropColumn("dbo.Pays", "TelephoneCode")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.Pays", "TelephoneCode", Function(c) c.String(nullable := False, maxLength := 5))
            AddColumn("dbo.Pays", "CurrencyName", Function(c) c.String(nullable := False, maxLength := 250))
            AddColumn("dbo.Pays", "CurrencyCode", Function(c) c.String(nullable := False, maxLength := 250))
            AddColumn("dbo.Pays", "Capital", Function(c) c.String(nullable := False, maxLength := 250))
        End Sub
    End Class
End Namespace
