Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Add_Table_DetailsIndemnisation
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropIndex("dbo.Indemnisation", New String() { "NatureAideId" })
            RenameColumn(table := "dbo.Indemnisation", name := "NatureAideId", newName := "NatureAide_Id")
            CreateTable(
                "dbo.DetailsIndemnisations",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .IndemnisationId = c.Long(nullable := False),
                        .NatureAideId = c.Long(nullable := False),
                        .Quantite = c.Double(nullable := False),
                        .Description = c.String(),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Indemnisation", Function(t) t.IndemnisationId) _
                .ForeignKey("dbo.NatureAide", Function(t) t.NatureAideId) _
                .Index(Function(t) t.IndemnisationId) _
                .Index(Function(t) t.NatureAideId) _
                .Index(Function(t) t.AspNetUserId)
            
            AlterColumn("dbo.Indemnisation", "NatureAide_Id", Function(c) c.Long())
            AlterColumn("dbo.Indemnisation", "Description", Function(c) c.String(maxLength := 4000))
            CreateIndex("dbo.Indemnisation", "NatureAide_Id")
            DropColumn("dbo.Indemnisation", "Quantite")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.Indemnisation", "Quantite", Function(c) c.Double(nullable := False))
            DropForeignKey("dbo.DetailsIndemnisations", "NatureAideId", "dbo.NatureAide")
            DropForeignKey("dbo.DetailsIndemnisations", "IndemnisationId", "dbo.Indemnisation")
            DropForeignKey("dbo.DetailsIndemnisations", "AspNetUserId", "dbo.AspNetUsers")
            DropIndex("dbo.DetailsIndemnisations", New String() { "AspNetUserId" })
            DropIndex("dbo.DetailsIndemnisations", New String() { "NatureAideId" })
            DropIndex("dbo.DetailsIndemnisations", New String() { "IndemnisationId" })
            DropIndex("dbo.Indemnisation", New String() { "NatureAide_Id" })
            AlterColumn("dbo.Indemnisation", "Description", Function(c) c.String(nullable := False, maxLength := 4000))
            AlterColumn("dbo.Indemnisation", "NatureAide_Id", Function(c) c.Long(nullable := False))
            DropTable("dbo.DetailsIndemnisations")
            RenameColumn(table := "dbo.Indemnisation", name := "NatureAide_Id", newName := "NatureAideId")
            CreateIndex("dbo.Indemnisation", "NatureAideId")
        End Sub
    End Class
End Namespace
