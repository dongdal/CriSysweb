Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddTableSecteurProjet
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.SecteurProjets", "Secteur_Id", "dbo.Secteur")
            DropForeignKey("dbo.SecteurProjets", "Projet_Id", "dbo.Projet")
            DropIndex("dbo.SecteurProjets", New String() { "Secteur_Id" })
            DropIndex("dbo.SecteurProjets", New String() { "Projet_Id" })
            CreateTable(
                "dbo.SecteurProjet",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .ProjetId = c.Long(nullable := False),
                        .SecteurId = c.Long(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Projet", Function(t) t.ProjetId) _
                .ForeignKey("dbo.Secteur", Function(t) t.SecteurId) _
                .Index(Function(t) t.ProjetId) _
                .Index(Function(t) t.SecteurId)
            
            DropTable("dbo.SecteurProjets")
        End Sub
        
        Public Overrides Sub Down()
            CreateTable(
                "dbo.SecteurProjets",
                Function(c) New With
                    {
                        .Secteur_Id = c.Long(nullable := False),
                        .Projet_Id = c.Long(nullable := False)
                    }) _
                .PrimaryKey(Function(t) New With { t.Secteur_Id, t.Projet_Id })
            
            DropForeignKey("dbo.SecteurProjet", "SecteurId", "dbo.Secteur")
            DropForeignKey("dbo.SecteurProjet", "ProjetId", "dbo.Projet")
            DropIndex("dbo.SecteurProjet", New String() { "SecteurId" })
            DropIndex("dbo.SecteurProjet", New String() { "ProjetId" })
            DropTable("dbo.SecteurProjet")
            CreateIndex("dbo.SecteurProjets", "Projet_Id")
            CreateIndex("dbo.SecteurProjets", "Secteur_Id")
            AddForeignKey("dbo.SecteurProjets", "Projet_Id", "dbo.Projet", "Id", cascadeDelete := True)
            AddForeignKey("dbo.SecteurProjets", "Secteur_Id", "dbo.Secteur", "Id", cascadeDelete := True)
        End Sub
    End Class
End Namespace
