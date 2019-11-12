Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class PropositionViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Libelle", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Libelle As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="ChampsId", ResourceType:=GetType(Resource))>
    Public Property ChampsId As Long
    Public Overridable Property LesChamps As ICollection(Of SelectListItem)
    Public Overridable Property Champs As Champs

    <Display(Name:="StatutExistant", ResourceType:=GetType(Resource))>
    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    Public Property StatutExistant As Short = 1

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="DateCreation", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateCreation As DateTime = Now


    Public Sub New()
    End Sub

    Public Sub New(entity As Proposition)
        With Me
            .Id = entity.Id
            .Libelle = entity.Libelle
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .Champs = entity.Champs
            .ChampsId = entity.ChampsId
        End With
    End Sub

    Public Function GetEntity() As Proposition
        Dim entity As New Proposition
        With entity
            .Id = Id
            .Libelle = Libelle
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .ChampsId = ChampsId
        End With
        Return entity
    End Function


End Class

