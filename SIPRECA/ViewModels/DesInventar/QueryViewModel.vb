Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity.Spatial
Imports SIPRECA.My.Resources

Public Class QueryViewModel

    <Display(Name:="Deces", ResourceType:=GetType(Resource))>
    Public Property Deces As Boolean

    Public Property DecesMin As Double?

    Public Property DecesMAx As Double?

    <Display(Name:="MaisonDetruite", ResourceType:=GetType(Resource))>
    Public Property MaisonDetruite As Boolean

    Public Property MaisonDetruiteMin As Double?

    Public Property MaisonDetruiteMAx As Double?

    <Display(Name:="Sinistrees", ResourceType:=GetType(Resource))>
    Public Property Sinistrees As Boolean

    Public Property SinistreesMin As Double?

    Public Property SinistreesMAx As Double?

    <Display(Name:="AffecteesIndirectment", ResourceType:=GetType(Resource))>
    Public Property AffecteesIndirectment As Boolean

    Public Property AffecteesIndirectmentMin As Double?

    Public Property AffecteesIndirectmentMAx As Double?

    <Display(Name:="Hopitaux", ResourceType:=GetType(Resource))>
    Public Property Hopitaux As Boolean

    Public Property HopitauxMin As Double?

    Public Property HopitauxMAx As Double?

    <Display(Name:="RoutesEndomages", ResourceType:=GetType(Resource))>
    Public Property RoutesEndomages As Boolean

    Public Property RoutesEndomagesMin As Double?

    Public Property RoutesEndomagesMAx As Double?

    <Display(Name:="BetailPerdu", ResourceType:=GetType(Resource))>
    Public Property BetailPerdu As Boolean

    Public Property BetailPerduMin As Double?

    Public Property BetailPerduMAx As Double?

    <Display(Name:="Blesse", ResourceType:=GetType(Resource))>
    Public Property Blesse As Boolean

    Public Property BlesseMin As Double?

    Public Property BlesseMAx As Double?

    <Display(Name:="MaisonEndommages", ResourceType:=GetType(Resource))>
    Public Property MaisonEndommages As Boolean

    Public Property MaisonEndommagesMin As Double?

    Public Property MaisonEndommagesMAx As Double?

    <Display(Name:="AffectesDirectment", ResourceType:=GetType(Resource))>
    Public Property AffectesDirectment As Boolean

    Public Property AffectesDirectmentMin As Double?

    Public Property AffectesDirectmentMAx As Double?

    <Display(Name:="Deplacees", ResourceType:=GetType(Resource))>
    Public Property Deplacees As Boolean

    Public Property DeplaceesMin As Double?

    Public Property DeplaceesMAx As Double?

    <Display(Name:="Disparus", ResourceType:=GetType(Resource))>
    Public Property Disparus As Boolean

    Public Property DisparusMin As Double?

    Public Property DisparusMAx As Double?

    <Display(Name:="CulturesBoisEndomages", ResourceType:=GetType(Resource))>
    Public Property CulturesBoisEndomages As Boolean

    Public Property CulturesBoisEndomagesMin As Double?

    Public Property CulturesBoisEndomagesMAx As Double?

    <Display(Name:="CentresEducationnels", ResourceType:=GetType(Resource))>
    Public Property CentresEducationnels As Boolean

    Public Property CentresEducationnelsMin As Double?

    Public Property CentresEducationnelsMAx As Double?

    <Display(Name:="Logique", ResourceType:=GetType(Resource))>
    Public Property Logique As String

    <Display(Name:="AffecteSante", ResourceType:=GetType(Resource))>
    Public Property AffecteSante As Boolean

    <Display(Name:="AffecteEducation", ResourceType:=GetType(Resource))>
    Public Property AffecteEducation As Boolean

    <Display(Name:="AffecteTransport", ResourceType:=GetType(Resource))>
    Public Property AffecteTransport As Boolean

    <Display(Name:="AffecteAgriculture", ResourceType:=GetType(Resource))>
    Public Property AffecteAgriculture As Boolean

    <Display(Name:="AutresSecteurs", ResourceType:=GetType(Resource))>
    Public Property AutresSecteurs As Boolean

    <Display(Name:="NombreRaportsPage", ResourceType:=GetType(Resource))>
    Public Property NombreRaportsPage As Long

    <Display(Name:="DateDe", ResourceType:=GetType(Resource))>
    Public Property DateDe As Date?

    <Display(Name:="DateA", ResourceType:=GetType(Resource))>
    Public Property DateA As Date?

    <Display(Name:="Evenement", ResourceType:=GetType(Resource))>
    Public Property EvenementId As Long?
    Public Overridable Property LesEvenements As ICollection(Of SelectListItem)

    <Display(Name:="Facteur", ResourceType:=GetType(Resource))>
    Public Property FacteurId As Long?
    Public Overridable Property LesFacteurs As ICollection(Of SelectListItem)

    <Display(Name:="Region", ResourceType:=GetType(Resource))>
    Public Property RegionId As Long?
    Public Overridable Property LesRegions As ICollection(Of SelectListItem)

    <Display(Name:="Commune", ResourceType:=GetType(Resource))>
    Public Property CommuneId As Long?
    Public Overridable Property LesCommunes As ICollection(Of SelectListItem)


    <Display(Name:="Departement", ResourceType:=GetType(Resource))>
    Public Property DepartementId As Long?
    Public Overridable Property LesDepartements As ICollection(Of SelectListItem)

    <Display(Name:="Quartier", ResourceType:=GetType(Resource))>
    Public Property QuartiersId As Long?
    Public Overridable Property LesQuartiers As ICollection(Of SelectListItem)

End Class

