' <auto-generated />
Imports System.CodeDom.Compiler
Imports System.Data.Entity.Migrations
Imports System.Data.Entity.Migrations.Infrastructure
Imports System.Resources

Namespace Migrations
    <GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")>
    Public NotInheritable Partial Class Refonte_Du_Model_Pour_Le_Module_SISAGestion_Des_Sinistrés
        Implements IMigrationMetadata
    
        Private ReadOnly Resources As New ResourceManager(GetType(Refonte_Du_Model_Pour_Le_Module_SISAGestion_Des_Sinistrés))
        
        Private ReadOnly Property IMigrationMetadata_Id() As String Implements IMigrationMetadata.Id
            Get
                Return "201907251610069_Refonte_Du_Model_Pour_Le_Module_SISA-Gestion_Des_Sinistrés"
            End Get
        End Property
        
        Private ReadOnly Property IMigrationMetadata_Source() As String Implements IMigrationMetadata.Source
            Get
                Return Nothing
            End Get
        End Property
        
        Private ReadOnly Property IMigrationMetadata_Target() As String Implements IMigrationMetadata.Target
            Get
                Return Resources.GetString("Target")
            End Get
        End Property
    End Class
End Namespace
