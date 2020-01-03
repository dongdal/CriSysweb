Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Add_Table_BordereauTransfertDemande
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.BordereauTransfertDemande",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .DemandeId = c.Long(nullable := False),
                        .BordereauTransfertId = c.Long(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.BordereauTransfert", Function(t) t.BordereauTransfertId) _
                .ForeignKey("dbo.Demande", Function(t) t.DemandeId) _
                .Index(Function(t) t.DemandeId) _
                .Index(Function(t) t.BordereauTransfertId)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.BordereauTransfertDemande", "DemandeId", "dbo.Demande")
            DropForeignKey("dbo.BordereauTransfertDemande", "BordereauTransfertId", "dbo.BordereauTransfert")
            DropIndex("dbo.BordereauTransfertDemande", New String() { "BordereauTransfertId" })
            DropIndex("dbo.BordereauTransfertDemande", New String() { "DemandeId" })
            DropTable("dbo.BordereauTransfertDemande")
        End Sub
    End Class
End Namespace
