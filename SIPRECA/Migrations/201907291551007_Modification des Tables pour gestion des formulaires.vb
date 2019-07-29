Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class ModificationdesTablespourgestiondesformulaires
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.ChampsSection", "AspNetUserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.ChampsSection", "ChampsId", "dbo.Champs")
            DropForeignKey("dbo.ChampsSection", "SectionId", "dbo.Sections")
            DropForeignKey("dbo.ChampsSection", "ValeurChamps_Id", "dbo.ValeurChamps")
            DropIndex("dbo.PieceJointe", New String() { "DemandeId" })
            DropIndex("dbo.PieceJointe", New String() { "ProjetId" })
            DropIndex("dbo.ChampsSection", New String() { "ChampsId" })
            DropIndex("dbo.ChampsSection", New String() { "SectionId" })
            DropIndex("dbo.ChampsSection", New String() { "AspNetUserId" })
            DropIndex("dbo.ChampsSection", New String() { "ValeurChamps_Id" })
            CreateTable(
                "dbo.Proposition",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .Libelle = c.String(nullable := False, maxLength := 1000),
                        .DateCreation = c.DateTime(nullable := False),
                        .StatutExistant = c.Short(nullable := False),
                        .ChampsId = c.Long(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Champs", Function(t) t.ChampsId) _
                .Index(Function(t) t.ChampsId)
            
            AddColumn("dbo.Champs", "SectionId", Function(c) c.Long(nullable := False))
            AddColumn("dbo.ValeurChamps", "PropositionId", Function(c) c.Long(nullable := False))
            AlterColumn("dbo.PieceJointe", "DemandeId", Function(c) c.Long())
            AlterColumn("dbo.PieceJointe", "ProjetId", Function(c) c.Long())
            CreateIndex("dbo.PieceJointe", "DemandeId")
            CreateIndex("dbo.PieceJointe", "ProjetId")
            CreateIndex("dbo.Champs", "SectionId")
            CreateIndex("dbo.ValeurChamps", "PropositionId")
            AddForeignKey("dbo.Champs", "SectionId", "dbo.Sections", "Id")
            AddForeignKey("dbo.ValeurChamps", "PropositionId", "dbo.Proposition", "Id")
            DropColumn("dbo.ValeurChamps", "ChampsSectionId")
            DropTable("dbo.ChampsSection")
        End Sub
        
        Public Overrides Sub Down()
            CreateTable(
                "dbo.ChampsSection",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .ChampsId = c.Long(nullable := False),
                        .SectionId = c.Long(nullable := False),
                        .AspNetUserId = c.String(nullable := False, maxLength := 128),
                        .ValeurChamps_Id = c.Long()
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            AddColumn("dbo.ValeurChamps", "ChampsSectionId", Function(c) c.Long(nullable := False))
            DropForeignKey("dbo.ValeurChamps", "PropositionId", "dbo.Proposition")
            DropForeignKey("dbo.Proposition", "ChampsId", "dbo.Champs")
            DropForeignKey("dbo.Champs", "SectionId", "dbo.Sections")
            DropIndex("dbo.Proposition", New String() { "ChampsId" })
            DropIndex("dbo.ValeurChamps", New String() { "PropositionId" })
            DropIndex("dbo.Champs", New String() { "SectionId" })
            DropIndex("dbo.PieceJointe", New String() { "ProjetId" })
            DropIndex("dbo.PieceJointe", New String() { "DemandeId" })
            AlterColumn("dbo.PieceJointe", "ProjetId", Function(c) c.Long(nullable := False))
            AlterColumn("dbo.PieceJointe", "DemandeId", Function(c) c.Long(nullable := False))
            DropColumn("dbo.ValeurChamps", "PropositionId")
            DropColumn("dbo.Champs", "SectionId")
            DropTable("dbo.Proposition")
            CreateIndex("dbo.ChampsSection", "ValeurChamps_Id")
            CreateIndex("dbo.ChampsSection", "AspNetUserId")
            CreateIndex("dbo.ChampsSection", "SectionId")
            CreateIndex("dbo.ChampsSection", "ChampsId")
            CreateIndex("dbo.PieceJointe", "ProjetId")
            CreateIndex("dbo.PieceJointe", "DemandeId")
            AddForeignKey("dbo.ChampsSection", "ValeurChamps_Id", "dbo.ValeurChamps", "Id")
            AddForeignKey("dbo.ChampsSection", "SectionId", "dbo.Sections", "Id")
            AddForeignKey("dbo.ChampsSection", "ChampsId", "dbo.Champs", "Id")
            AddForeignKey("dbo.ChampsSection", "AspNetUserId", "dbo.AspNetUsers", "Id")
        End Sub
    End Class
End Namespace
