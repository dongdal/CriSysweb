Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Alter_Table_CollectiviteSinistree_Set_ForeignKey_On_Commune
        Inherits DbMigration
    
        Public Overrides Sub Up()
            RenameColumn(table := "dbo.CollectiviteSinistree", name := "CollectiviteId", newName := "CommuneId")
            RenameIndex(table := "dbo.CollectiviteSinistree", name := "IX_CollectiviteId", newName := "IX_CommuneId")
        End Sub
        
        Public Overrides Sub Down()
            RenameIndex(table := "dbo.CollectiviteSinistree", name := "IX_CommuneId", newName := "IX_CollectiviteId")
            RenameColumn(table := "dbo.CollectiviteSinistree", name := "CommuneId", newName := "CollectiviteId")
        End Sub
    End Class
End Namespace
