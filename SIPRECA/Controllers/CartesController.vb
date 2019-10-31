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


            entityVM.LesTypeOffices = LesTypeOffices
            entityVM.LesVilles = LesVilles
            entityVM.LesOrganisations = LesOrganisations
            entityVM.LesTypeAbris = LesTypeAbris
            entityVM.LesTypeEntrepots = LesTypeEntrepots
            entityVM.LesTailleDeAeronefs = LesTailleDeAeronefs
            entityVM.LesTypeHopitaux = LesTypeHopitaux
        End Sub

        ' GET: Carte
        Function Index() As ActionResult
            Dim entityVM As New FiltreViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

    End Class
End Namespace
