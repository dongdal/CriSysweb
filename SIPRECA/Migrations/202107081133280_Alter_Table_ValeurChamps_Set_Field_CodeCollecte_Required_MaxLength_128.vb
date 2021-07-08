Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Alter_Table_ValeurChamps_Set_Field_CodeCollecte_Required_MaxLength_128
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.ValeurChamps", "CodeCollecte", Function(c) c.String(nullable := False, maxLength := 128))
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.ValeurChamps", "CodeCollecte", Function(c) c.String())
        End Sub
    End Class
End Namespace
