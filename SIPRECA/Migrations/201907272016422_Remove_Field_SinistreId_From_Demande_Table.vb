Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Remove_Field_SinistreId_From_Demande_Table
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.Demande", "SinistreId", "dbo.Sinistre")
            DropIndex("dbo.Demande", New String() { "SinistreId" })
            DropColumn("dbo.Demande", "SinistreId")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.Demande", "SinistreId", Function(c) c.Long(nullable := False))
            CreateIndex("dbo.Demande", "SinistreId")
            AddForeignKey("dbo.Demande", "SinistreId", "dbo.Sinistre", "Id")
        End Sub
    End Class
End Namespace
