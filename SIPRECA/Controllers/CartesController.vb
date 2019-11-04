Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList

Namespace Controllers
    Public Class CartesController
        Inherits BaseController

        Private _db As New ApplicationDbContext

        Public Property Db As ApplicationDbContext
            Get
                Return _db
            End Get
            Set(value As ApplicationDbContext)
                _db = value
            End Set
        End Property

        Private Sub LoadComboBox(entityVM As FiltreViewModel)

            Dim Organisation = (From e In Db.Organisation Where e.StatutExistant = 1 Select e)
            Dim LesOrganisations As New List(Of SelectListItem)

            Dim Ville = (From e In Db.Ville Where e.StatutExistant = 1 Select e)
            Dim LesVilles As New List(Of SelectListItem)

            Dim TypeOffice = (From e In Db.TypeOffice Where e.StatutExistant = 1 Select e)
            Dim LesTypeOffices As New List(Of SelectListItem)

            Dim TypeAbris = (From e In Db.TypeAbris Where e.StatutExistant = 1 Select e)
            Dim LesTypeAbris As New List(Of SelectListItem)

            Dim TailleDeAeronef = (From e In Db.TailleDeAeronef Where e.StatutExistant = 1 Select e)
            Dim LesTailleDeAeronefs As New List(Of SelectListItem)

            Dim TypeHopitaux = (From e In Db.TypeHopitaux Where e.StatutExistant = 1 Select e)
            Dim LesTypeHopitaux As New List(Of SelectListItem)

            Dim TypeEntrepot = (From e In Db.TypeEntrepot Where e.StatutExistant = 1 Select e)
            Dim LesTypeEntrepots As New List(Of SelectListItem)

            Dim MaterielHopitaux = (From e In Db.Materiel Where e.StatutExistant = 1 And e.Cible = 1 Select e)
            Dim LesMaterielHopitaux As New List(Of SelectListItem)

            Dim MaterielAbris = (From e In Db.Materiel Where e.StatutExistant = 1 And e.Cible = 2 Select e)
            Dim LesMaterielAbris As New List(Of SelectListItem)

            Dim MaterielHeliport = (From e In Db.Materiel Where e.StatutExistant = 1 And e.Cible = 3 Select e)
            Dim LesMaterielHeliport As New List(Of SelectListItem)

            Dim MaterielPortDeMer = (From e In Db.Materiel Where e.StatutExistant = 1 And e.Cible = 4 Select e)
            Dim LesMaterielPortDeMer As New List(Of SelectListItem)

            Dim MaterielAeroport = (From e In Db.Materiel Where e.StatutExistant = 1 And e.Cible = 5 Select e)
            Dim LesMaterielAeroport As New List(Of SelectListItem)

            Dim MaterielBureau = (From e In Db.Materiel Where e.StatutExistant = 1 And e.Cible = 6 Select e)
            Dim LesMaterielBureau As New List(Of SelectListItem)

            Dim MaterielInstallation = (From e In Db.Materiel Where e.StatutExistant = 1 And e.Cible = 7 Select e)
            Dim LesMaterielInstallation As New List(Of SelectListItem)

            Dim MaterielEntrepots = (From e In Db.Materiel Where e.StatutExistant = 1 And e.Cible = 8 Select e)
            Dim LesMaterielEntrepots As New List(Of SelectListItem)

            For Each item In Organisation
                LesOrganisations.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
            Next

            For Each item In Ville
                LesVilles.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In TypeOffice
                LesTypeOffices.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In TypeAbris
                LesTypeAbris.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In TailleDeAeronef
                LesTailleDeAeronefs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In TypeHopitaux
                LesTypeHopitaux.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In TypeEntrepot
                LesTypeEntrepots.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In MaterielHopitaux
                LesMaterielHopitaux.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In MaterielAbris
                LesMaterielAbris.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In MaterielHeliport
                LesMaterielHeliport.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In MaterielPortDeMer
                LesMaterielPortDeMer.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In MaterielAeroport
                LesMaterielAeroport.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In MaterielBureau
                LesMaterielBureau.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In MaterielInstallation
                LesMaterielInstallation.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In MaterielEntrepots
                LesMaterielEntrepots.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next


            entityVM.LesTypeOffices = LesTypeOffices
            entityVM.LesVilles = LesVilles
            entityVM.LesOrganisations = LesOrganisations
            entityVM.LesTypeAbris = LesTypeAbris
            entityVM.LesTypeEntrepots = LesTypeEntrepots
            entityVM.LesTailleDeAeronefs = LesTailleDeAeronefs
            entityVM.LesTypeHopitaux = LesTypeHopitaux
            entityVM.LesMaterielAeroport = LesMaterielAeroport
            entityVM.LesMaterielsAbris = LesMaterielAbris
            entityVM.LesMaterielBureau = LesMaterielBureau
            entityVM.LesMaterielPortDeMer = LesMaterielPortDeMer
            entityVM.LesMaterielHeliport = LesMaterielHeliport
            entityVM.LesMaterielInstallation = LesMaterielInstallation
            entityVM.LesMaterielEntrepots = LesMaterielEntrepots
            entityVM.LesMaterielHopitaux = LesMaterielHopitaux
        End Sub

        ' GET: Carte
        Function Index() As ActionResult
            Dim entityVM As New FiltreViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

    End Class
End Namespace
