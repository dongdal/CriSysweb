' <auto-generated />
Imports System.CodeDom.Compiler
Imports System.Data.Entity.Migrations
Imports System.Data.Entity.Migrations.Infrastructure
Imports System.Resources

Namespace Migrations
    <GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")>
    Public NotInheritable Partial Class AjoutdelalocalisationsurzoneArisqueetdelaquantit√©surlesequipements
        Implements IMigrationMetadata
    
        Private ReadOnly Resources As New ResourceManager(GetType(AjoutdelalocalisationsurzoneArisqueetdelaquantit√©surlesequipements))
        
        Private ReadOnly Property IMigrationMetadata_Id() As String Implements IMigrationMetadata.Id
            Get
                Return "201911130839431_Ajout de la localisation sur zoneArisque et de la quantit√© sur les equipements"
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
