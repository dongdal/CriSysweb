Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class CardreSendaiCibleDViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="EvenementZoneId", ResourceType:=GetType(Resource))>
    Public Property EvenementZoneId As Long
    Public Overridable Property EvenementZone As EvenementZone
    Public Overridable Property LesEvenementsZone As ICollection(Of SelectListItem)

    <Display(Name:="CibleDServicesPublique", ResourceType:=GetType(Resource))>
    Public Property CibleDServicesPubliqueId As New List(Of Long)
    Public Overridable Property LesCibleDServicesPublique As ICollection(Of SelectListItem)
    Public Overridable Property CibleDServicesPublique As ICollection(Of CibleDServicesPublique)

    <Display(Name:="NombreTotaldesEtablissementDeSanteTouche", ResourceType:=GetType(Resource))>
    Public Property NombreTotaldesEtablissementDeSanteTouche As Long?

    <Display(Name:="NombreDesEtablissementsdeSanteEndommager", ResourceType:=GetType(Resource))>
    Public Property NombreDesEtablissementsdeSanteEndommager As Long?

    <Display(Name:="NombreDesEtablissementsdeSantedetruits", ResourceType:=GetType(Resource))>
    Public Property NombreDesEtablissementsdeSantedetruits As Long?

    <Display(Name:="NombreTotaldesEtablissementEducationTouche", ResourceType:=GetType(Resource))>
    Public Property NombreTotaldesEtablissementEducationTouche As Long?

    <Display(Name:="NombreDesEtablissementsEducationEndommager", ResourceType:=GetType(Resource))>
    Public Property NombreDesEtablissementsEducationEndommager As Long?

    <Display(Name:="NombreDesEtablissementsEducationDetruits", ResourceType:=GetType(Resource))>
    Public Property NombreDesEtablissementsEducationDetruits As Long?

    <Display(Name:="NombreTotalAutreInfrastructureTouche", ResourceType:=GetType(Resource))>
    Public Property NombreTotalAutreInfrastructureTouche As Long?

    <Display(Name:="NombreAutreInfrastructureEndommager", ResourceType:=GetType(Resource))>
    Public Property NombreAutreInfrastructureEndommager As Long?

    <Display(Name:="NombreAutreInfrastructureDetruits", ResourceType:=GetType(Resource))>
    Public Property NombreAutreInfrastructureDetruits As Long?

    <Display(Name:="PerteEconomiqueDuAuRoutes", ResourceType:=GetType(Resource))>
    Public Property PerteEconomiqueDuAuRoutes As Long?

    <Display(Name:="NombreTotalRoutesTouche", ResourceType:=GetType(Resource))>
    Public Property NombreTotalRoutesTouche As Long?

    <Display(Name:="NombreRoutesEndommager", ResourceType:=GetType(Resource))>
    Public Property NombreRoutesEndommager As Long?

    <Display(Name:="NombreRoutesDetruits", ResourceType:=GetType(Resource))>
    Public Property NombreRoutesDetruits As Long?

    <Display(Name:="DateCreation", ResourceType:=GetType(Resource))>
    Public Property DateCreation As DateTime = Now

    <Display(Name:="StatutExistant", ResourceType:=GetType(Resource))>
    Public Property StatutExistant As Short = 1

    <Display(Name:="Utilisateur", ResourceType:=GetType(Resource))>
    Public Property AspNetUserId As String
    Public Overridable Property LesUtilisateurs As ICollection(Of SelectListItem)
    Public Overridable Property AspNetUser As ApplicationUser

    <Display(Name:="CibleDServicesPublique", ResourceType:=GetType(Resource))>
    Public Property ServicesPubliqueId As Long
    Public Overridable Property LesServicesPubliques As ICollection(Of SelectListItem)

    Public Sub New()
    End Sub

    Public Sub New(entity As CardreSendaiCibleD)
        With Me
            .Id = entity.Id
            .EvenementZoneId = entity.EvenementZoneId
            .EvenementZone = entity.EvenementZone
            .NombreTotaldesEtablissementDeSanteTouche = entity.NombreTotaldesEtablissementDeSanteTouche
            .NombreDesEtablissementsdeSanteEndommager = entity.NombreDesEtablissementsdeSanteEndommager
            .NombreDesEtablissementsdeSantedetruits = entity.NombreDesEtablissementsdeSantedetruits
            .NombreTotaldesEtablissementEducationTouche = entity.NombreTotaldesEtablissementEducationTouche
            .NombreDesEtablissementsEducationEndommager = entity.NombreDesEtablissementsEducationEndommager
            .NombreDesEtablissementsEducationDetruits = entity.NombreDesEtablissementsEducationDetruits
            .NombreTotalAutreInfrastructureTouche = entity.NombreTotalAutreInfrastructureTouche
            .NombreAutreInfrastructureEndommager = entity.NombreAutreInfrastructureEndommager
            .NombreAutreInfrastructureDetruits = entity.NombreAutreInfrastructureDetruits
            .PerteEconomiqueDuAuRoutes = entity.PerteEconomiqueDuAuRoutes
            .NombreTotalRoutesTouche = entity.NombreTotalRoutesTouche
            .NombreRoutesEndommager = entity.NombreRoutesEndommager
            .NombreRoutesDetruits = entity.NombreRoutesDetruits
            .DateCreation = entity.DateCreation
            .AspNetUserId = entity.AspNetUserId
            .AspNetUser = entity.AspNetUser
        End With
    End Sub

    Public Function GetEntity() As CardreSendaiCibleD
        Dim entity As New CardreSendaiCibleD
        With entity
            .Id = Id
            .EvenementZoneId = EvenementZoneId
            .NombreTotaldesEtablissementDeSanteTouche = NombreTotaldesEtablissementDeSanteTouche
            .NombreDesEtablissementsdeSanteEndommager = NombreDesEtablissementsdeSanteEndommager
            .NombreDesEtablissementsdeSantedetruits = NombreDesEtablissementsdeSantedetruits
            .NombreTotaldesEtablissementEducationTouche = NombreTotaldesEtablissementEducationTouche
            .NombreDesEtablissementsEducationEndommager = NombreDesEtablissementsEducationEndommager
            .NombreDesEtablissementsEducationDetruits = NombreDesEtablissementsEducationDetruits
            .NombreTotalAutreInfrastructureTouche = NombreTotalAutreInfrastructureTouche
            .NombreAutreInfrastructureEndommager = NombreAutreInfrastructureEndommager
            .NombreAutreInfrastructureDetruits = NombreAutreInfrastructureDetruits
            .PerteEconomiqueDuAuRoutes = PerteEconomiqueDuAuRoutes
            .NombreTotalRoutesTouche = NombreTotalRoutesTouche
            .NombreRoutesEndommager = NombreRoutesEndommager
            .NombreRoutesDetruits = NombreRoutesDetruits
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function

End Class
