Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Add_Field_Code_On_Collectivite_And_Add_Table_BordereauTransfert
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.BordereauTransfert",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .NumeroBordereau = c.String(maxLength := 100),
                        .DateTransfert = c.DateTime(nullable := False),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .Index(Function(t) t.AspNetUserId)
            
            AddColumn("dbo.Collectivite", "Code", Function(c) c.String())
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.BordereauTransfert", "AspNetUserId", "dbo.AspNetUsers")
            DropIndex("dbo.BordereauTransfert", New String() { "AspNetUserId" })
            DropColumn("dbo.Collectivite", "Code")
            DropTable("dbo.BordereauTransfert")
        End Sub
    End Class
End Namespace
