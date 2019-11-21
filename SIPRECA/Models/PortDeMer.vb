
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class PortDeMer
    Public Sub New()
        MaterielPortDeMer = New HashSet(Of MaterielPortDeMer)()
    End Sub

    Public Property Id As Long
    Public Property CommuneId As Long?
    Public Property OganisationId As Long

    Public Property Nom As String
    Public Property Code As String
    Public Property Possession As String
    Public Property HauteurMaximum As Double
    Public Property HauteurMaximumUnites As String
    Public Property ProfondeurQuaiChargement As Double
    Public Property ProfondeurQuaiChargementUnites As String
    Public Property ProfondeurTerminalPetrolier As Double
    Public Property ProfondeurTerminalPetrolierUnites As String
    Public Property CaleSeche As String
    Public Property LongueurMaximaleNavire As Double
    Public Property LongueurMaximaleNavireUnites As String
    Public Property Reparations As String
    Public Property Abri As String
    Public Property CapaciteStockageEntreposage As Double
    Public Property CapaciteStockageSecurise As Double
    Public Property CapaciteStockageEntrepotDouanier As Double
    Public Property NombreRemorqueur As Long
    Public Property CapaciteRemorqueur As Double
    Public Property NombreBarge As Double
    Public Property CapacietBarge As Double
    Public Property EquipementChargement As String
    Public Property CapaciteDouaniere As String
    Public Property Securite As String
    Public Property ProfondeurMareHaute As Double
    Public Property ProfondeurMareHauteUnites As String
    Public Property ProfondeurMareBasse As Double
    Public Property ProfondeurMareBasseUnites As String
    Public Property ProfondeurInondation As Double
    Public Property ProfondeurInondationUnites As String
    Public Property Location As DbGeometry
    Public Property Telephone As String
    Public Property Telephone2 As String
    Public Property SiteWeb As String
    Public Property Email As String

    Public Property StatutExistant As Short = 1
    Public Property DateCreation As DateTime = Now

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Commune As Commune
    Public Overridable Property Oganisation As Organisation
    Public Overridable Property MaterielPortDeMer As ICollection(Of MaterielPortDeMer)
End Class
