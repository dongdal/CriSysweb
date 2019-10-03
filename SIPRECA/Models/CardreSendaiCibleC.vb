Imports System.Data.Entity.Spatial

Partial Public Class CardreSendaiCibleC
    Public Sub New()
        CibleCDesagregationAgricole = New HashSet(Of CibleCDesagregationAgricole)()
        CibleCPerteBetail = New HashSet(Of CibleCPerteBetail)()
    End Sub

    Public Property Id As Long
    Public Property EvenementZoneId As Long
    Public Property PerteTotalDeBetailTouche As Long
    Public Property NombreDanimauxToucheOuPerdu As Long
    Public Property NombreDanimauxToucher As Long
    Public Property NombreDanimauxPerdu As Long
    Public Property PerteEconomiqueDesCultureTouche As Double
    Public Property HectaresTautauxDesCulturesTouche As Double
    Public Property HectaresEndomages As Double
    Public Property HectaresDetruits As Double
    Public Property PerteEconomiqueSurForet As Double
    Public Property NombreTotalHectarForetToucher As Double
    Public Property NombreHectarForetEndomager As Double
    Public Property NombreHectarForetDetruit As Double
    Public Property PerteEconomiqueAquaculture As Double
    Public Property NombreTotalHectarAquacultureToucher As Double
    Public Property NombreHectarAquacultureEndomager As Double
    Public Property NombreHectarAquacultureDetruit As Double
    Public Property PerteEconomiqueDesNaviresAffecter As Double
    Public Property NombreTotalNavireToucher As Double
    Public Property NombreNavireEndomager As Double
    Public Property NombreNavireDetruit As Double
    Public Property PerteEconomiqueDesStockAgricole As Double
    Public Property NombreTotalDinstallationStockAgricoleToucher As Long
    Public Property NombreDinstallationStockAgricoleEndomager As Long
    Public Property NombreDinstallationStockAgricoleDetruit As Long
    Public Property PerteEconomiqueActifsProductifAfricole As Double
    Public Property NombreTotalActifsProductifAfricoleToucher As Long
    Public Property NombreActifsProductifAfricoleEndomager As Long
    Public Property NombreActifsProductifAfricoleDetruit As Long
    Public Property PerteEconomiqueActifsProductifs As Double
    Public Property NombreTotalInstallationActifsProductifsToucher As Long
    Public Property NombreInstallationActifsProductifsEndomager As Long
    Public Property NombreInstallationActifsProductifsDetruit As Long
    Public Property NombreTotalLogementEndommagerOuDetruit As Long
    Public Property TotalEconomiqueLogementEndomagerOuDetruit As Double
    Public Property ValeurEconomiqueDesMaisonsEndomager As Double
    Public Property ValeurEconomiqueDesMaisonsDetruites As Double
    Public Property PerteEconomiqueSecteurSante As Double
    Public Property PerteEconomiqueSecteurEducation As Double
    Public Property PerteEconomiqueInfrastructureToucher As Double
    Public Property CoutDeLaReabilitationHeritageCulturel As Double
    Public Property CoutDeLaReabilitationMobileDetruit As Double
    Public Property PerteEconomiqueDuAuActifsMobileDetruit As Double
    Public Property NombreDeMonumentImmobiliersEndomager As Long
    Public Property NombreMonumentImmobilierDetruits As Long
    Public Property NombreDeBiensCulturelMobileEndomager As Long
    Public Property NombreDeBiensCulturelMobileDetruits As Long

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property EvenementZone As EvenementZone
    Public Overridable Property CibleCDesagregationAgricole As ICollection(Of CibleCDesagregationAgricole)
    Public Overridable Property CibleCPerteBetail As ICollection(Of CibleCPerteBetail)
End Class
