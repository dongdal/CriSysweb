Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity.Spatial
Imports SIPRECA.My.Resources

Public Class ExportCollectDatasViewModel
    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="FormulaireId", ResourceType:=GetType(Resource))>
    Public Property FormulaireId As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="EnqueteId", ResourceType:=GetType(Resource))>
    Public Property EnqueteId As Long

    '<DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="DateDebut", ResourceType:=GetType(Resource))>
    Public Property DateDebut As String = Now.ToString(AppSession.DateFormat)

    '<DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="DateFin", ResourceType:=GetType(Resource))>
    Public Property DateFin As String = Now.ToString(AppSession.DateFormat)

    Public Sub New()
    End Sub

    Public Sub New(FormulaireId As Long, EnqueteId As Long)
        With Me
            .FormulaireId = FormulaireId
            .EnqueteId = EnqueteId
            .DateDebut = Now.ToString(AppSession.DateFormat)
            .DateFin = Now.ToString(AppSession.DateFormat)
        End With
    End Sub
End Class
