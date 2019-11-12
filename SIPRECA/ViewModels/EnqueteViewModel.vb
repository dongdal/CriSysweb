Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class EnqueteViewModel
    Public Property Id As Long
    Public Property IdFormulaire As Long
    Public Property IdSection As Long
    Public Property IdChamps As Long

    '<Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Titre", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Titre As String

    '<Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="SinistreId", ResourceType:=GetType(Resource))>
    Public Property SinistreId As Long
    Public Overridable Property LesSinistres As ICollection(Of SelectListItem)
    Public Overridable Property Sinistre As Sinistre

    <Display(Name:="Description", ResourceType:=GetType(Resource))>
    <StringLength(4000, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Description As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="StatutExistant", ResourceType:=GetType(Resource))>
    Public Property StatutExistant As Short = 1
    Public Property StatutExistantFormulaire As Short = 1
    Public Property StatutExistantSection As Short = 1
    Public Property StatutExistantChamps As Short = 1

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="DateCreation", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateCreation As DateTime = Now
    Public Property DateCreationFormulaire As DateTime = Now
    Public Property DateCreationSection As DateTime = Now
    Public Property DateCreationChamps As DateTime = Now

    <Display(Name:="Utilisateur", ResourceType:=GetType(Resource))>
    Public Property AspNetUserId As String
    Public Property AspNetUserIdFormulaire As String
    Public Property AspNetUserIdSection As String
    Public Property AspNetUserIdChamps As String
    Public Overridable Property LesUtilisateurs As ICollection(Of SelectListItem)
    Public Overridable Property AspNetUser As ApplicationUser

    '<Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="EnqueteId", ResourceType:=GetType(Resource))>
    Public Property EnqueteId As Long
    Public Overridable Property LesEnquetes As ICollection(Of SelectListItem)
    Public Overridable Property Enquete As Enquete
    Public Overridable Property ListeFormulaires As List(Of Formulaire) 'La liste des Formulaires déjà enregistrés et à afficher après enregistrement

    '<Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Titre", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property TitreFormulaire As String

    <Display(Name:="Description", ResourceType:=GetType(Resource))>
    <StringLength(4000, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property DescriptionFormulaire As String

    '<Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="FormulaireId", ResourceType:=GetType(Resource))>
    Public Property FormulaireId As Long
    Public Overridable Property LesFormulaires As ICollection(Of SelectListItem)
    Public Overridable Property Formulaire As Formulaire
    Public Overridable Property ListeSections As List(Of Section) 'La liste des sections déjà enregistrées et à afficher après enregistrement

    '<Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Titre", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property TitreSection As String

    <Display(Name:="Description", ResourceType:=GetType(Resource))>
    <StringLength(4000, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property DescriptionSection As String


    '<Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="SectionId", ResourceType:=GetType(Resource))>
    Public Property SectionId As Long
    Public Overridable Property LesSections As ICollection(Of SelectListItem)
    Public Overridable Property Section As Section

    <Display(Name:="TypeChampsId", ResourceType:=GetType(Resource))>
    Public Property TypeChampsId As Long
    Public Overridable Property LesTypeChamps As ICollection(Of SelectListItem)
    Public Overridable Property TypeChamps As TypeChamps

    '<Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Titre", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property TitreChamps As String

    <Display(Name:="Description", ResourceType:=GetType(Resource))>
    <StringLength(4000, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property DescriptionChamps As String

    Public Overridable Property ListeChamps As List(Of Champs) 'La liste des champs déjà enregistrés et à afficher après enregistrement

    Public Property PropositionViewModel As New PropositionViewModel

    Public Sub New()
    End Sub

    Public Sub New(entity As Enquete)
        With Me
            .Id = entity.Id
            .Titre = entity.Titre
            .Description = entity.Description
            .StatutExistant = entity.StatutExistant
            .Sinistre = entity.Sinistre
            .SinistreId = entity.SinistreId
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntity() As Enquete
        Dim entity As New Enquete
        With entity
            .Id = Id
            .Titre = Titre
            .Description = Description
            .StatutExistant = StatutExistant
            .SinistreId = SinistreId
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function

    Public Sub New(entity As Formulaire)
        With Me
            .IdFormulaire = entity.Id
            .TitreFormulaire = entity.Titre
            .DescriptionFormulaire = entity.Description
            .StatutExistantFormulaire = entity.StatutExistant
            .Enquete = entity.Enquete
            .EnqueteId = entity.EnqueteId
            .DateCreationFormulaire = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserIdFormulaire = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntityFormulaire() As Formulaire
        Dim entity As New Formulaire
        With entity
            .Id = IdFormulaire
            .Titre = TitreFormulaire
            .Description = DescriptionFormulaire
            .StatutExistant = StatutExistantFormulaire
            .EnqueteId = EnqueteId
            .DateCreation = DateCreationFormulaire
            .AspNetUserId = AspNetUserIdFormulaire
        End With
        Return entity
    End Function

    Public Sub New(entity As Section)
        With Me
            .IdSection = entity.Id
            .TitreSection = entity.Titre
            .DescriptionSection = entity.Description
            .StatutExistantSection = entity.StatutExistant
            .Formulaire = entity.Formulaire
            .FormulaireId = entity.FormulaireId
            .DateCreationSection = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserIdSection = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntitySection() As Section
        Dim entity As New Section
        With entity
            .Id = IdSection
            .Titre = TitreSection
            .Description = DescriptionSection
            .StatutExistant = StatutExistantSection
            .FormulaireId = FormulaireId
            .DateCreation = DateCreationSection
            .AspNetUserId = AspNetUserIdSection
        End With
        Return entity
    End Function


    Public Sub New(entity As Champs)
        With Me
            .IdChamps = entity.Id
            .TitreChamps = entity.Titre
            .TypeChamps = entity.TypeChamps
            .TypeChampsId = entity.TypeChampsId
            .StatutExistantSection = entity.StatutExistant
            .Section = entity.Section
            .SectionId = entity.SectionId
            .DateCreationSection = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserIdSection = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntityChamps() As Champs
        Dim entity As New Champs
        With entity
            .Id = IdChamps
            .Titre = TitreChamps
            .TypeChampsId = TypeChampsId
            .StatutExistant = StatutExistantSection
            .SectionId = SectionId
            .DateCreation = DateCreationSection
            .AspNetUserId = AspNetUserIdSection
        End With
        Return entity
    End Function


End Class
