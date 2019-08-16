Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Update_MicrosoftAspNetIdentityEntityFramework_From_100_To_200
        Inherits DbMigration
    
        Public Overrides Sub Up()
            RenameColumn(table := "dbo.AspNetUserClaims", name := "User_Id", newName := "UserId")
            RenameIndex(table := "dbo.AspNetUserClaims", name := "IX_User_Id", newName := "IX_UserId")
            DropPrimaryKey("dbo.AspNetUserLogins")
            AddColumn("dbo.AspNetUsers", "EmailConfirmed", Function(c) c.Boolean(nullable := False))
            AddColumn("dbo.AspNetUsers", "PhoneNumber", Function(c) c.String())
            AddColumn("dbo.AspNetUsers", "PhoneNumberConfirmed", Function(c) c.Boolean(nullable := False))
            AddColumn("dbo.AspNetUsers", "TwoFactorEnabled", Function(c) c.Boolean(nullable := False))
            AddColumn("dbo.AspNetUsers", "LockoutEndDateUtc", Function(c) c.DateTime())
            AddColumn("dbo.AspNetUsers", "LockoutEnabled", Function(c) c.Boolean(nullable := False))
            AddColumn("dbo.AspNetUsers", "AccessFailedCount", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.AspNetUsers", "UserName", Function(c) c.String(nullable := False, maxLength := 256))
            AlterColumn("dbo.AspNetUsers", "DateDelivranceCNI", Function(c) c.DateTime(nullable := False))
            AlterColumn("dbo.AspNetUsers", "DateExpirationCNI", Function(c) c.DateTime(nullable := False))
            AlterColumn("dbo.AspNetUsers", "Email", Function(c) c.String(maxLength := 256))
            AlterColumn("dbo.AspNetUsers", "DateCreation", Function(c) c.DateTime(nullable := False))
            AlterColumn("dbo.AspNetUsers", "Etat", Function(c) c.Short(nullable := False))
            AlterColumn("dbo.AspNetRoles", "Name", Function(c) c.String(nullable := False, maxLength := 256))
            AddPrimaryKey("dbo.AspNetUserLogins", New String() { "LoginProvider", "ProviderKey", "UserId" })
            CreateIndex("dbo.AspNetUsers", "UserName", unique := True, name := "UserNameIndex")
            CreateIndex("dbo.AspNetRoles", "Name", unique := True, name := "RoleNameIndex")
            DropColumn("dbo.AspNetUsers", "Discriminator")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.AspNetUsers", "Discriminator", Function(c) c.String(nullable := False, maxLength := 128))
            DropIndex("dbo.AspNetRoles", "RoleNameIndex")
            DropIndex("dbo.AspNetUsers", "UserNameIndex")
            DropPrimaryKey("dbo.AspNetUserLogins")
            AlterColumn("dbo.AspNetRoles", "Name", Function(c) c.String(nullable := False))
            AlterColumn("dbo.AspNetUsers", "Etat", Function(c) c.Short())
            AlterColumn("dbo.AspNetUsers", "DateCreation", Function(c) c.DateTime())
            AlterColumn("dbo.AspNetUsers", "Email", Function(c) c.String())
            AlterColumn("dbo.AspNetUsers", "DateExpirationCNI", Function(c) c.DateTime())
            AlterColumn("dbo.AspNetUsers", "DateDelivranceCNI", Function(c) c.DateTime())
            AlterColumn("dbo.AspNetUsers", "UserName", Function(c) c.String(nullable := False))
            DropColumn("dbo.AspNetUsers", "AccessFailedCount")
            DropColumn("dbo.AspNetUsers", "LockoutEnabled")
            DropColumn("dbo.AspNetUsers", "LockoutEndDateUtc")
            DropColumn("dbo.AspNetUsers", "TwoFactorEnabled")
            DropColumn("dbo.AspNetUsers", "PhoneNumberConfirmed")
            DropColumn("dbo.AspNetUsers", "PhoneNumber")
            DropColumn("dbo.AspNetUsers", "EmailConfirmed")
            AddPrimaryKey("dbo.AspNetUserLogins", New String() { "UserId", "LoginProvider", "ProviderKey" })
            RenameIndex(table := "dbo.AspNetUserClaims", name := "IX_UserId", newName := "IX_User_Id")
            RenameColumn(table := "dbo.AspNetUserClaims", name := "UserId", newName := "User_Id")
        End Sub
    End Class
End Namespace
