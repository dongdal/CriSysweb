Imports System.Data.Entity.Spatial

Partial Public Class CardreSendaiCibleD
    Public Sub New()
        CibleDServicesPublique = New HashSet(Of CibleDServicesPublique)()
    End Sub

    Public Property Id As Long
    Public Property EvenementZoneId As Long
    Public Property NombreTotaldesEtablissementDeSanteTouche As Long?
    Public Property NombreDesEtablissementsdeSanteEndommager As Long?
    Public Property NombreDesEtablissementsdeSantedetruits As Long?
    Public Property NombreTotaldesEtablissementEducationTouche As Long?
    Public Property NombreDesEtablissementsEducationEndommager As Long?
    Public Property NombreDesEtablissementsEducationDetruits As Long?
    Public Property NombreTotalAutreInfrastructureTouche As Long?
    Public Property NombreAutreInfrastructureEndommager As Long?
    Public Property NombreAutreInfrastructureDetruits As Long?
    Public Property PerteEconomiqueDuAuRoutes As Long?
    Public Property NombreTotalRoutesTouche As Long?
    Public Property NombreRoutesEndommager As Long?
    Public Property NombreRoutesDetruits As Long?
    Public Property Source As String

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property EvenementZone As EvenementZone
    Public Overridable Property CibleDServicesPublique As ICollection(Of CibleDServicesPublique)
End Class
