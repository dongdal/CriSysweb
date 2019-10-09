Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class CardreSendaiCibleCViewModel

    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="EvenementZoneId", ResourceType:=GetType(Resource))>
    Public Property EvenementZoneId As Long
    Public Overridable Property LesEvenementsZone As ICollection(Of SelectListItem)
    Public Overridable Property EvenementZone As EvenementZone

    <Display(Name:="CibleCPerteBetail", ResourceType:=GetType(Resource))>
    Public Property CibleCPerteBetailId As New List(Of Long)
    Public Overridable Property LesCibleCPerteBetail As ICollection(Of SelectListItem)
    Public Overridable Property CibleCPerteBetail As ICollection(Of CibleCPerteBetail)

    <Display(Name:="CibleCDesagregationAgricole", ResourceType:=GetType(Resource))>
    Public Property CibleCDesagregationAgricoleId As New List(Of Long)
    Public Overridable Property LesCibleCDesagregationAgricoles As ICollection(Of SelectListItem)
    Public Overridable Property CibleCDesagregationAgricole As ICollection(Of CibleCDesagregationAgricole)

    <Display(Name:="PerteTotalDeBetailTouche", ResourceType:=GetType(Resource))>
    Public Property PerteTotalDeBetailTouche As Long?

    <Display(Name:="NombreDanimauxToucheOuPerdu", ResourceType:=GetType(Resource))>
    Public Property NombreDanimauxToucheOuPerdu As Long?

    <Display(Name:="NombreDanimauxToucher", ResourceType:=GetType(Resource))>
    Public Property NombreDanimauxToucher As Long?

    <Display(Name:="NombreDanimauxPerdu", ResourceType:=GetType(Resource))>
    Public Property NombreDanimauxPerdu As Long?

    <Display(Name:="PerteEconomiqueDesCultureTouche", ResourceType:=GetType(Resource))>
    Public Property PerteEconomiqueDesCultureTouche As Double?

    <Display(Name:="HectaresTautauxDesCulturesTouche", ResourceType:=GetType(Resource))>
    Public Property HectaresTautauxDesCulturesTouche As Double?

    <Display(Name:="HectaresEndomages", ResourceType:=GetType(Resource))>
    Public Property HectaresEndomages As Double?

    <Display(Name:="HectaresDetruits", ResourceType:=GetType(Resource))>
    Public Property HectaresDetruits As Double?

    <Display(Name:="PerteEconomiqueSurForet", ResourceType:=GetType(Resource))>
    Public Property PerteEconomiqueSurForet As Double?

    <Display(Name:="NombreTotalHectarForetToucher", ResourceType:=GetType(Resource))>
    Public Property NombreTotalHectarForetToucher As Double?

    <Display(Name:="NombreHectarForetEndomager", ResourceType:=GetType(Resource))>
    Public Property NombreHectarForetEndomager As Double?

    <Display(Name:="NombreHectarForetDetruit", ResourceType:=GetType(Resource))>
    Public Property NombreHectarForetDetruit As Double?

    <Display(Name:="PerteEconomiqueAquaculture", ResourceType:=GetType(Resource))>
    Public Property PerteEconomiqueAquaculture As Double?

    <Display(Name:="NombreTotalHectarAquacultureToucher", ResourceType:=GetType(Resource))>
    Public Property NombreTotalHectarAquacultureToucher As Double?

    <Display(Name:="NombreHectarAquacultureEndomager", ResourceType:=GetType(Resource))>
    Public Property NombreHectarAquacultureEndomager As Double?

    <Display(Name:="NombreHectarAquacultureDetruit", ResourceType:=GetType(Resource))>
    Public Property NombreHectarAquacultureDetruit As Double?

    <Display(Name:="PerteEconomiqueDesNaviresAffecter", ResourceType:=GetType(Resource))>
    Public Property PerteEconomiqueDesNaviresAffecter As Double?

    <Display(Name:="NombreTotalNavireToucher", ResourceType:=GetType(Resource))>
    Public Property NombreTotalNavireToucher As Double?

    <Display(Name:="NombreNavireEndomager", ResourceType:=GetType(Resource))>
    Public Property NombreNavireEndomager As Double?

    <Display(Name:="NombreNavireDetruit", ResourceType:=GetType(Resource))>
    Public Property NombreNavireDetruit As Double?

    <Display(Name:="PerteEconomiqueDesStockAgricole", ResourceType:=GetType(Resource))>
    Public Property PerteEconomiqueDesStockAgricole As Double?

    <Display(Name:="NombreTotalDinstallationStockAgricoleToucher", ResourceType:=GetType(Resource))>
    Public Property NombreTotalDinstallationStockAgricoleToucher As Long?

    <Display(Name:="NombreDinstallationStockAgricoleEndomager", ResourceType:=GetType(Resource))>
    Public Property NombreDinstallationStockAgricoleEndomager As Long?

    <Display(Name:="NombreDinstallationStockAgricoleDetruit", ResourceType:=GetType(Resource))>
    Public Property NombreDinstallationStockAgricoleDetruit As Long?

    <Display(Name:="PerteEconomiqueActifsProductifAfricole", ResourceType:=GetType(Resource))>
    Public Property PerteEconomiqueActifsProductifAfricole As Double?

    <Display(Name:="NombreTotalActifsProductifAfricoleToucher", ResourceType:=GetType(Resource))>
    Public Property NombreTotalActifsProductifAfricoleToucher As Long?

    <Display(Name:="NombreActifsProductifAfricoleEndomager", ResourceType:=GetType(Resource))>
    Public Property NombreActifsProductifAfricoleEndomager As Long?

    <Display(Name:="NombreActifsProductifAfricoleDetruit", ResourceType:=GetType(Resource))>
    Public Property NombreActifsProductifAfricoleDetruit As Long?

    <Display(Name:="PerteEconomiqueActifsProductifs", ResourceType:=GetType(Resource))>
    Public Property PerteEconomiqueActifsProductifs As Double?

    <Display(Name:="NombreTotalInstallationActifsProductifsToucher", ResourceType:=GetType(Resource))>
    Public Property NombreTotalInstallationActifsProductifsToucher As Long?

    <Display(Name:="NombreInstallationActifsProductifsEndomager", ResourceType:=GetType(Resource))>
    Public Property NombreInstallationActifsProductifsEndomager As Long?

    <Display(Name:="NombreInstallationActifsProductifsDetruit", ResourceType:=GetType(Resource))>
    Public Property NombreInstallationActifsProductifsDetruit As Long?

    <Display(Name:="NombreTotalLogementEndommagerOuDetruit", ResourceType:=GetType(Resource))>
    Public Property NombreTotalLogementEndommagerOuDetruit As Long?

    <Display(Name:="TotalEconomiqueLogementEndomagerOuDetruit", ResourceType:=GetType(Resource))>
    Public Property TotalEconomiqueLogementEndomagerOuDetruit As Double?

    <Display(Name:="ValeurEconomiqueDesMaisonsEndomager", ResourceType:=GetType(Resource))>
    Public Property ValeurEconomiqueDesMaisonsEndomager As Double?

    <Display(Name:="ValeurEconomiqueDesMaisonsDetruites", ResourceType:=GetType(Resource))>
    Public Property ValeurEconomiqueDesMaisonsDetruites As Double?

    <Display(Name:="PerteEconomiqueSecteurSante", ResourceType:=GetType(Resource))>
    Public Property PerteEconomiqueSecteurSante As Double?

    <Display(Name:="PerteEconomiqueSecteurEducation", ResourceType:=GetType(Resource))>
    Public Property PerteEconomiqueSecteurEducation As Double?

    <Display(Name:="PerteEconomiqueInfrastructureToucher", ResourceType:=GetType(Resource))>
    Public Property PerteEconomiqueInfrastructureToucher As Double?

    <Display(Name:="CoutDeLaReabilitationHeritageCulturel", ResourceType:=GetType(Resource))>
    Public Property CoutDeLaReabilitationHeritageCulturel As Double?

    <Display(Name:="CoutDeLaReabilitationMobileDetruit", ResourceType:=GetType(Resource))>
    Public Property CoutDeLaReabilitationMobileDetruit As Double?

    <Display(Name:="PerteEconomiqueDuAuActifsMobileDetruit", ResourceType:=GetType(Resource))>
    Public Property PerteEconomiqueDuAuActifsMobileDetruit As Double?

    <Display(Name:="NombreDeMonumentImmobiliersEndomager", ResourceType:=GetType(Resource))>
    Public Property NombreDeMonumentImmobiliersEndomager As Long?

    <Display(Name:="NombreMonumentImmobilierDetruits", ResourceType:=GetType(Resource))>
    Public Property NombreMonumentImmobilierDetruits As Long?

    <Display(Name:="NombreDeBiensCulturelMobileEndomager", ResourceType:=GetType(Resource))>
    Public Property NombreDeBiensCulturelMobileEndomager As Long?

    <Display(Name:="NombreDeBiensCulturelMobileDetruits", ResourceType:=GetType(Resource))>
    Public Property NombreDeBiensCulturelMobileDetruits As Long?

    <Display(Name:="DateCreation", ResourceType:=GetType(Resource))>
    Public Property DateCreation As DateTime = Now

    <Display(Name:="StatutExistant", ResourceType:=GetType(Resource))>
    Public Property StatutExistant As Short = 1

    <Display(Name:="Utilisateur", ResourceType:=GetType(Resource))>
    Public Property AspNetUserId As String
    Public Overridable Property LesUtilisateurs As ICollection(Of SelectListItem)
    Public Overridable Property AspNetUser As ApplicationUser

    Public Sub New()
    End Sub

    Public Sub New(entity As CardreSendaiCibleC)
        With Me
            .Id = entity.Id
            .EvenementZoneId = entity.EvenementZoneId
            .EvenementZone = entity.EvenementZone
            .PerteTotalDeBetailTouche = entity.PerteTotalDeBetailTouche
            .NombreDanimauxToucheOuPerdu = entity.NombreDanimauxToucheOuPerdu
            .NombreDanimauxToucher = entity.NombreDanimauxToucher
            .NombreDanimauxPerdu = entity.NombreDanimauxPerdu
            .PerteEconomiqueDesCultureTouche = entity.PerteEconomiqueDesCultureTouche
            .HectaresTautauxDesCulturesTouche = entity.HectaresTautauxDesCulturesTouche
            .HectaresEndomages = entity.HectaresEndomages
            .HectaresDetruits = entity.HectaresDetruits
            .PerteEconomiqueSurForet = entity.PerteEconomiqueSurForet
            .NombreTotalHectarForetToucher = entity.NombreTotalHectarForetToucher
            .NombreHectarForetEndomager = entity.NombreHectarForetEndomager
            .NombreHectarForetDetruit = entity.NombreHectarForetDetruit
            .PerteEconomiqueAquaculture = entity.PerteEconomiqueAquaculture
            .NombreTotalHectarAquacultureToucher = entity.NombreTotalHectarAquacultureToucher
            .NombreHectarAquacultureEndomager = entity.NombreHectarAquacultureEndomager
            .NombreHectarAquacultureDetruit = entity.NombreHectarAquacultureDetruit
            .PerteEconomiqueDesNaviresAffecter = entity.PerteEconomiqueDesNaviresAffecter
            .NombreTotalNavireToucher = entity.NombreTotalNavireToucher
            .NombreNavireEndomager = entity.NombreNavireEndomager
            .NombreNavireDetruit = entity.NombreNavireDetruit
            .PerteEconomiqueDesStockAgricole = entity.PerteEconomiqueDesStockAgricole
            .NombreTotalDinstallationStockAgricoleToucher = entity.NombreTotalDinstallationStockAgricoleToucher
            .NombreDinstallationStockAgricoleEndomager = entity.NombreDinstallationStockAgricoleEndomager
            .NombreDinstallationStockAgricoleDetruit = entity.NombreDinstallationStockAgricoleDetruit
            .PerteEconomiqueActifsProductifAfricole = entity.PerteEconomiqueActifsProductifAfricole
            .NombreTotalActifsProductifAfricoleToucher = entity.NombreTotalActifsProductifAfricoleToucher
            .NombreActifsProductifAfricoleEndomager = entity.NombreActifsProductifAfricoleEndomager
            .NombreActifsProductifAfricoleDetruit = entity.NombreActifsProductifAfricoleDetruit
            .PerteEconomiqueActifsProductifs = entity.PerteEconomiqueActifsProductifs
            .NombreTotalInstallationActifsProductifsToucher = entity.NombreTotalInstallationActifsProductifsToucher
            .NombreInstallationActifsProductifsEndomager = entity.NombreInstallationActifsProductifsEndomager
            .NombreInstallationActifsProductifsDetruit = entity.NombreInstallationActifsProductifsDetruit
            .NombreTotalLogementEndommagerOuDetruit = entity.NombreTotalLogementEndommagerOuDetruit
            .TotalEconomiqueLogementEndomagerOuDetruit = entity.TotalEconomiqueLogementEndomagerOuDetruit
            .ValeurEconomiqueDesMaisonsEndomager = entity.ValeurEconomiqueDesMaisonsEndomager
            .ValeurEconomiqueDesMaisonsDetruites = entity.ValeurEconomiqueDesMaisonsDetruites
            .PerteEconomiqueSecteurSante = entity.PerteEconomiqueSecteurSante
            .PerteEconomiqueSecteurEducation = entity.PerteEconomiqueSecteurEducation
            .PerteEconomiqueInfrastructureToucher = entity.PerteEconomiqueInfrastructureToucher
            .CoutDeLaReabilitationHeritageCulturel = entity.CoutDeLaReabilitationHeritageCulturel
            .CoutDeLaReabilitationMobileDetruit = entity.CoutDeLaReabilitationMobileDetruit
            .PerteEconomiqueDuAuActifsMobileDetruit = entity.PerteEconomiqueDuAuActifsMobileDetruit
            .NombreDeMonumentImmobiliersEndomager = entity.NombreDeMonumentImmobiliersEndomager
            .NombreMonumentImmobilierDetruits = entity.NombreMonumentImmobilierDetruits
            .NombreDeBiensCulturelMobileEndomager = entity.NombreDeBiensCulturelMobileEndomager
            .NombreDeBiensCulturelMobileDetruits = entity.NombreDeBiensCulturelMobileDetruits
            .DateCreation = entity.DateCreation
            .AspNetUserId = entity.AspNetUserId
            .AspNetUser = entity.AspNetUser
        End With
    End Sub

    Public Function GetEntity() As CardreSendaiCibleC
        Dim entity As New CardreSendaiCibleC
        With entity
            .Id = Id
            .EvenementZoneId = EvenementZoneId
            .PerteTotalDeBetailTouche = PerteTotalDeBetailTouche
            .NombreDanimauxToucheOuPerdu = NombreDanimauxToucheOuPerdu
            .NombreDanimauxToucher = NombreDanimauxToucher
            .NombreDanimauxPerdu = NombreDanimauxPerdu
            .PerteEconomiqueDesCultureTouche = PerteEconomiqueDesCultureTouche
            .HectaresTautauxDesCulturesTouche = HectaresTautauxDesCulturesTouche
            .HectaresEndomages = HectaresEndomages
            .HectaresDetruits = HectaresDetruits
            .PerteEconomiqueSurForet = PerteEconomiqueSurForet
            .NombreTotalHectarForetToucher = NombreTotalHectarForetToucher
            .NombreHectarForetEndomager = NombreHectarForetEndomager
            .NombreHectarForetDetruit = NombreHectarForetDetruit
            .PerteEconomiqueAquaculture = PerteEconomiqueAquaculture
            .NombreTotalHectarAquacultureToucher = NombreTotalHectarAquacultureToucher
            .NombreHectarAquacultureEndomager = NombreHectarAquacultureEndomager
            .NombreHectarAquacultureDetruit = NombreHectarAquacultureDetruit
            .PerteEconomiqueDesNaviresAffecter = PerteEconomiqueDesNaviresAffecter
            .NombreTotalNavireToucher = NombreTotalNavireToucher
            .NombreNavireEndomager = NombreNavireEndomager
            .NombreNavireDetruit = NombreNavireDetruit
            .PerteEconomiqueDesStockAgricole = PerteEconomiqueDesStockAgricole
            .NombreTotalDinstallationStockAgricoleToucher = NombreTotalDinstallationStockAgricoleToucher
            .NombreDinstallationStockAgricoleEndomager = NombreDinstallationStockAgricoleEndomager
            .NombreDinstallationStockAgricoleDetruit = NombreDinstallationStockAgricoleDetruit
            .PerteEconomiqueActifsProductifAfricole = PerteEconomiqueActifsProductifAfricole
            .NombreTotalActifsProductifAfricoleToucher = NombreTotalActifsProductifAfricoleToucher
            .NombreActifsProductifAfricoleEndomager = NombreActifsProductifAfricoleEndomager
            .NombreActifsProductifAfricoleDetruit = NombreActifsProductifAfricoleDetruit
            .PerteEconomiqueActifsProductifs = PerteEconomiqueActifsProductifs
            .NombreTotalInstallationActifsProductifsToucher = NombreTotalInstallationActifsProductifsToucher
            .NombreInstallationActifsProductifsEndomager = NombreInstallationActifsProductifsEndomager
            .NombreInstallationActifsProductifsDetruit = NombreInstallationActifsProductifsDetruit
            .NombreTotalLogementEndommagerOuDetruit = NombreTotalLogementEndommagerOuDetruit
            .TotalEconomiqueLogementEndomagerOuDetruit = TotalEconomiqueLogementEndomagerOuDetruit
            .ValeurEconomiqueDesMaisonsEndomager = ValeurEconomiqueDesMaisonsEndomager
            .ValeurEconomiqueDesMaisonsDetruites = ValeurEconomiqueDesMaisonsDetruites
            .PerteEconomiqueSecteurSante = PerteEconomiqueSecteurSante
            .PerteEconomiqueSecteurEducation = PerteEconomiqueSecteurEducation
            .PerteEconomiqueInfrastructureToucher = PerteEconomiqueInfrastructureToucher
            .CoutDeLaReabilitationHeritageCulturel = CoutDeLaReabilitationHeritageCulturel
            .CoutDeLaReabilitationMobileDetruit = CoutDeLaReabilitationMobileDetruit
            .PerteEconomiqueDuAuActifsMobileDetruit = PerteEconomiqueDuAuActifsMobileDetruit
            .NombreDeMonumentImmobiliersEndomager = NombreDeMonumentImmobiliersEndomager
            .NombreMonumentImmobilierDetruits = NombreMonumentImmobilierDetruits
            .NombreDeBiensCulturelMobileEndomager = NombreDeBiensCulturelMobileEndomager
            .NombreDeBiensCulturelMobileDetruits = NombreDeBiensCulturelMobileDetruits
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function

End Class
