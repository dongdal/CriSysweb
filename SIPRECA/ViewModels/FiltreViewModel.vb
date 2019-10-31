Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity.Spatial
Imports SIPRECA.My.Resources

Public Class FiltreViewModel

    <Display(Name:="Aeroport", ResourceType:=GetType(Resource))>
    Public Property Aeroport As Boolean

    <Display(Name:="AeroportLongueurDePisteMin", ResourceType:=GetType(Resource))>
    Public Property AeroportLongueurDePisteMin As Double?

    <Display(Name:="AeroportLongueurDePisteMAx", ResourceType:=GetType(Resource))>
    Public Property AeroportLongueurDePisteMAx As Double?

    <Display(Name:="AeroportLargeurDePisteMin", ResourceType:=GetType(Resource))>
    Public Property AeroportLargeurDePisteMin As Double?

    <Display(Name:="AeroportLargeurDePisteMAx", ResourceType:=GetType(Resource))>
    Public Property AeroportLargeurDePisteMAx As Double?

    <Display(Name:="Abris", ResourceType:=GetType(Resource))>
    Public Property Abris As Boolean

    <Display(Name:="AbrisCapaciteMin", ResourceType:=GetType(Resource))>
    Public Property AbrisCapaciteMin As Long?

    <Display(Name:="AbrisCapaciteMAx", ResourceType:=GetType(Resource))>
    Public Property AbrisCapaciteMAx As Long?

    <Display(Name:="AbrisEstimationPopulationMin", ResourceType:=GetType(Resource))>
    Public Property AbrisEstimationPopulationMin As Long?

    <Display(Name:="AbrisEstimationPopulationMAx", ResourceType:=GetType(Resource))>
    Public Property AbrisEstimationPopulationMAx As Long?

    <Display(Name:="Bureau", ResourceType:=GetType(Resource))>
    Public Property Bureau As Boolean

    <Display(Name:="Entrepot", ResourceType:=GetType(Resource))>
    Public Property Entrepot As Boolean

    <Display(Name:="EntrepotCapaciteDisponibleMin", ResourceType:=GetType(Resource))>
    Public Property EntrepotCapaciteDisponibleMin As Double?

    <Display(Name:="EntrepotCapaciteDisponibleMAx", ResourceType:=GetType(Resource))>
    Public Property EntrepotCapaciteDisponibleMAx As Double?

    <Display(Name:="EntrepotCapaciteMin", ResourceType:=GetType(Resource))>
    Public Property EntrepotCapaciteMin As Double?

    <Display(Name:="EntrepotCapaciteMAx", ResourceType:=GetType(Resource))>
    Public Property EntrepotCapaciteMAx As Double?

    <Display(Name:="Heliport", ResourceType:=GetType(Resource))>
    Public Property Heliport As Boolean

    <Display(Name:="Hopitaux", ResourceType:=GetType(Resource))>
    Public Property Hopitaux As Boolean

    <Display(Name:="NombreDInfimiereMin", ResourceType:=GetType(Resource))>
    Public Property NombreDInfimiereMin As Long?

    <Display(Name:="NombreDInfimiereMAx", ResourceType:=GetType(Resource))>
    Public Property NombreDInfimiereMAx As Long?

    <Display(Name:="NombreDeMedecinMin", ResourceType:=GetType(Resource))>
    Public Property NombreDeMedecinMin As Long?

    <Display(Name:="NombreDeMedecinMax", ResourceType:=GetType(Resource))>
    Public Property NombreDeMedecinMax As Long?

    <Display(Name:="NombreDeLitMin", ResourceType:=GetType(Resource))>
    Public Property NombreDeLitMin As Long?

    <Display(Name:="NombreDeLitMax", ResourceType:=GetType(Resource))>
    Public Property NombreDeLitMax As Long?

    <Display(Name:="NombreDePersonnelNonMedicalMin", ResourceType:=GetType(Resource))>
    Public Property NombreDePersonnelNonMedicalMin As Long?

    <Display(Name:="NombreDePersonnelNonMedicalMAx", ResourceType:=GetType(Resource))>
    Public Property NombreDePersonnelNonMedicalMAx As Long?

    <Display(Name:="Instalation", ResourceType:=GetType(Resource))>
    Public Property Instalation As Boolean

    <Display(Name:="PortDeMer", ResourceType:=GetType(Resource))>
    Public Property PortDeMer As Boolean

    <Display(Name:="PortDeMerHauteurMaximumMin", ResourceType:=GetType(Resource))>
    Public Property PortDeMerHauteurMaximumMin As Double?

    <Display(Name:="PortDeMerHauteurMaximumMAx", ResourceType:=GetType(Resource))>
    Public Property PortDeMerHauteurMaximumMAx As Double?

    <Display(Name:="PortDeMerProfondeurQuaiChargementMin", ResourceType:=GetType(Resource))>
    Public Property PortDeMerProfondeurQuaiChargementMin As Double?

    <Display(Name:="PortDeMerProfondeurQuaiChargementMAx", ResourceType:=GetType(Resource))>
    Public Property PortDeMerProfondeurQuaiChargementMAx As Double?

    <Display(Name:="PortDeMerProfondeurTerminalPetrolierMin", ResourceType:=GetType(Resource))>
    Public Property PortDeMerProfondeurTerminalPetrolierMin As Double?

    <Display(Name:="PortDeProfondeurTerminalPetrolierMAx", ResourceType:=GetType(Resource))>
    Public Property PortDeProfondeurTerminalPetrolierMAx As Double?

    <Display(Name:="PortDeMerLongueurMaximaleNavireMin", ResourceType:=GetType(Resource))>
    Public Property PortDeMerLongueurMaximaleNavireMin As Double?

    <Display(Name:="PortDeMerLongueurMaximaleNavireMAx", ResourceType:=GetType(Resource))>
    Public Property PortDeMerLongueurMaximaleNavireMAx As Double?

    <Display(Name:="TypeAbris", ResourceType:=GetType(Resource))>
    Public Property TypeAbrisId As ICollection(Of Long)
    Public Overridable Property LesTypeAbris As ICollection(Of SelectListItem)

    <Display(Name:="Ville", ResourceType:=GetType(Resource))>
    Public Property VilleId As ICollection(Of Long)
    Public Overridable Property LesVilles As ICollection(Of SelectListItem)

    <Display(Name:="Organisation", ResourceType:=GetType(Resource))>
    Public Property OrganisationId As ICollection(Of Long)
    Public Overridable Property LesOrganisations As ICollection(Of SelectListItem)

    <Display(Name:="TailleDeAeronef", ResourceType:=GetType(Resource))>
    Public Property TailleDeAeronefId As ICollection(Of Long)
    Public Overridable Property LesTailleDeAeronefs As ICollection(Of SelectListItem)

    <Display(Name:="TypeOffice", ResourceType:=GetType(Resource))>
    Public Property TypeOfficeId As ICollection(Of Long)
    Public Overridable Property LesTypeOffices As ICollection(Of SelectListItem)

    <Display(Name:="TypeHopitaux", ResourceType:=GetType(Resource))>
    Public Property TypeHopitauxId As ICollection(Of Long)
    Public Overridable Property LesTypeHopitaux As ICollection(Of SelectListItem)

    <Display(Name:="TypeEntrepot", ResourceType:=GetType(Resource))>
    Public Property TypeEntrepotId As ICollection(Of Long)
    Public Overridable Property LesTypeEntrepots As ICollection(Of SelectListItem)

End Class

