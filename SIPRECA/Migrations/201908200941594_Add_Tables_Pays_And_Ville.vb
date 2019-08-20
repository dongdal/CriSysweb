Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Add_Tables_Pays_And_Ville
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Pays",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .Code = c.Long(nullable := False),
                        .Alpha2 = c.String(nullable := False, maxLength := 2),
                        .Alpha3 = c.String(nullable := False, maxLength := 3),
                        .Nom_En_Gb = c.String(nullable := False, maxLength := 250),
                        .Nom_Fr_Fr = c.String(nullable := False, maxLength := 250),
                        .Capital = c.String(nullable := False, maxLength := 250),
                        .CurrencyCode = c.String(nullable := False, maxLength := 250),
                        .CurrencyName = c.String(nullable := False, maxLength := 250),
                        .TelephoneCode = c.String(nullable := False, maxLength := 5),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .Index(Function(t) t.Code, unique := True) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Ville",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .PaysId = c.Long(nullable := False),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Pays", Function(t) t.PaysId) _
                .Index(Function(t) t.PaysId) _
                .Index(Function(t) t.AspNetUserId)
            
            AddColumn("dbo.Oganisation", "Pays_Id", Function(c) c.Long())
            CreateIndex("dbo.Oganisation", "Pays_Id")
            AddForeignKey("dbo.Oganisation", "Pays_Id", "dbo.Pays", "Id")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Ville", "PaysId", "dbo.Pays")
            DropForeignKey("dbo.Ville", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Oganisation", "Pays_Id", "dbo.Pays")
            DropForeignKey("dbo.Pays", "AspNetUserId", "dbo.AspNetUsers")
            DropIndex("dbo.Ville", New String() { "AspNetUserId" })
            DropIndex("dbo.Ville", New String() { "PaysId" })
            DropIndex("dbo.Pays", New String() { "AspNetUserId" })
            DropIndex("dbo.Pays", New String() { "Code" })
            DropIndex("dbo.Oganisation", New String() { "Pays_Id" })
            DropColumn("dbo.Oganisation", "Pays_Id")
            DropTable("dbo.Ville")
            DropTable("dbo.Pays")
        End Sub
    End Class
End Namespace
