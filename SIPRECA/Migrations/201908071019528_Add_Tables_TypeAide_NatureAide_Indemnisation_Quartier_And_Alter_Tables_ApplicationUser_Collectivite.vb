Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Add_Tables_TypeAide_NatureAide_Indemnisation_Quartier_And_Alter_Tables_ApplicationUser_Collectivite
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Indemnisation",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .NatureAideId = c.Long(nullable := False),
                        .DemandeId = c.Long(nullable := False),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .Quantite = c.Double(nullable := False),
                        .Description = c.String(nullable := False, maxLength := 4000),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.Demande", Function(t) t.DemandeId) _
                .ForeignKey("dbo.NatureAide", Function(t) t.NatureAideId) _
                .Index(Function(t) t.NatureAideId) _
                .Index(Function(t) t.DemandeId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.NatureAide",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .TypeAideId = c.Long(nullable := False),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .ForeignKey("dbo.TypeAide", Function(t) t.TypeAideId) _
                .Index(Function(t) t.TypeAideId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.TypeAide",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .Libelle = c.String(nullable := False, maxLength := 250),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AspNetUserId) _
                .Index(Function(t) t.AspNetUserId)
            
            CreateTable(
                "dbo.Quartier",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False),
                        .CommuneId = c.Long(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Collectivite", Function(t) t.Id) _
                .ForeignKey("dbo.Commune", Function(t) t.CommuneId) _
                .Index(Function(t) t.Id) _
                .Index(Function(t) t.CommuneId)
            
            AddColumn("dbo.AspNetUsers", "CommuneId", Function(c) c.Long())
            AddColumn("dbo.AspNetUsers", "DepartementId", Function(c) c.Long())
            AddColumn("dbo.AspNetUsers", "RegionId", Function(c) c.Long())
            AddColumn("dbo.AspNetUsers", "Niveau", Function(c) c.String())
            AddColumn("dbo.Collectivite", "Superficie", Function(c) c.Double())
            AddColumn("dbo.Collectivite", "Population", Function(c) c.Double())
            AddColumn("dbo.Collectivite", "Longitude", Function(c) c.Double())
            AddColumn("dbo.Collectivite", "Latitude", Function(c) c.Double())
            CreateIndex("dbo.AspNetUsers", "CommuneId")
            CreateIndex("dbo.AspNetUsers", "DepartementId")
            CreateIndex("dbo.AspNetUsers", "RegionId")
            AddForeignKey("dbo.AspNetUsers", "RegionId", "dbo.Region", "Id")
            AddForeignKey("dbo.AspNetUsers", "DepartementId", "dbo.Departement", "Id")
            AddForeignKey("dbo.AspNetUsers", "CommuneId", "dbo.Commune", "Id")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Quartier", "CommuneId", "dbo.Commune")
            DropForeignKey("dbo.Quartier", "Id", "dbo.Collectivite")
            DropForeignKey("dbo.NatureAide", "TypeAideId", "dbo.TypeAide")
            DropForeignKey("dbo.TypeAide", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Indemnisation", "NatureAideId", "dbo.NatureAide")
            DropForeignKey("dbo.NatureAide", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.Indemnisation", "DemandeId", "dbo.Demande")
            DropForeignKey("dbo.Indemnisation", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.AspNetUsers", "CommuneId", "dbo.Commune")
            DropForeignKey("dbo.AspNetUsers", "DepartementId", "dbo.Departement")
            DropForeignKey("dbo.AspNetUsers", "RegionId", "dbo.Region")
            DropIndex("dbo.Quartier", New String() { "CommuneId" })
            DropIndex("dbo.Quartier", New String() { "Id" })
            DropIndex("dbo.TypeAide", New String() { "AspNetUserId" })
            DropIndex("dbo.NatureAide", New String() { "AspNetUserId" })
            DropIndex("dbo.NatureAide", New String() { "TypeAideId" })
            DropIndex("dbo.Indemnisation", New String() { "AspNetUserId" })
            DropIndex("dbo.Indemnisation", New String() { "DemandeId" })
            DropIndex("dbo.Indemnisation", New String() { "NatureAideId" })
            DropIndex("dbo.AspNetUsers", New String() { "RegionId" })
            DropIndex("dbo.AspNetUsers", New String() { "DepartementId" })
            DropIndex("dbo.AspNetUsers", New String() { "CommuneId" })
            DropColumn("dbo.Collectivite", "Latitude")
            DropColumn("dbo.Collectivite", "Longitude")
            DropColumn("dbo.Collectivite", "Population")
            DropColumn("dbo.Collectivite", "Superficie")
            DropColumn("dbo.AspNetUsers", "Niveau")
            DropColumn("dbo.AspNetUsers", "RegionId")
            DropColumn("dbo.AspNetUsers", "DepartementId")
            DropColumn("dbo.AspNetUsers", "CommuneId")
            DropTable("dbo.Quartier")
            DropTable("dbo.TypeAide")
            DropTable("dbo.NatureAide")
            DropTable("dbo.Indemnisation")
        End Sub
    End Class
End Namespace
