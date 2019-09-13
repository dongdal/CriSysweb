Imports System.Data.Entity
Imports System.Data.Entity.Spatial
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList

Namespace Controllers
    Public Class HopitauxController
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

        Private Function GetCurrentUser() As ApplicationUser
            Dim id = User.Identity.GetUserId
            Dim aspuser = Db.Users.Find(id)
            Return aspuser
        End Function

        ' GET: Hopitaux
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.NomSort = If(sortOrder = "Nom", "Nom_desc", "Nom")
            ViewBag.NombreDeLitMinSort = If(sortOrder = "NombreDeLitMin", "NombreDeLitMin_desc", "NombreDeLitMin")
            ViewBag.NombreDeLitMaxSort = If(sortOrder = "NombreDeLitMax", "NombreDeLitMax_desc", "NombreDeLitMax")
            ViewBag.NombreDeMedecinSort = If(sortOrder = "NombreDeMedecin", "NombreDeMedecin_desc", "NombreDeMedecin")
            ViewBag.NombreDInfimiereSort = If(sortOrder = "NombreDInfimiere", "NombreDInfimiere_desc", "NombreDInfimiere")
            ViewBag.NombreDePersonnelNonMedicalSort = If(sortOrder = "NombreDePersonnelNonMedical", "NombreDePersonnelNonMedical_desc", "NombreDePersonnelNonMedical")
            ViewBag.VilleSort = If(sortOrder = "Ville", "Ville_desc", "Ville")
            ViewBag.CodeSort = If(sortOrder = "Code", "Code_desc", "Code")
            ViewBag.TelephoneSort = If(sortOrder = "Telephone", "Telephone_desc", "Telephone")
            ViewBag.TelephoneUrgenceSort = If(sortOrder = "TelephoneUrgence", "TelephoneUrgence_desc", "TelephoneUrgence")
            ViewBag.EmailSort = If(sortOrder = "Email", "Email_desc", "Email")
            ViewBag.SiteWebSort = If(sortOrder = "SiteWeb", "SiteWeb_desc", "SiteWeb")
            ViewBag.OrganisationSort = If(sortOrder = "Organisation", "Organisation_desc", "Organisation")
            ViewBag.TypeHopitauxSort = If(sortOrder = "TypeHopitaux", "TypeHopitaux_desc", "TypeHopitaux")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.Hopitaux Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Code.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Email.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.SiteWeb.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Telephone.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Oganisation.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.TelephoneUrgence.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.TypeHopitaux.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Ville.Libelle.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Nom"
                    entities = entities.OrderBy(Function(e) e.Nom)
                Case "Nom_desc"
                    entities = entities.OrderByDescending(Function(e) e.Nom)
                Case "Code"
                    entities = entities.OrderBy(Function(e) e.Code)
                Case "Code_desc"
                    entities = entities.OrderByDescending(Function(e) e.Code)
                Case "Telephone"
                    entities = entities.OrderBy(Function(e) e.Telephone)
                Case "Telephone_desc"
                    entities = entities.OrderByDescending(Function(e) e.Telephone)
                Case "NombreDeLitMin"
                    entities = entities.OrderBy(Function(e) e.NombreDeLitMin)
                Case "NombreDeLitMin_desc"
                    entities = entities.OrderByDescending(Function(e) e.NombreDeLitMin)
                Case "NombreDeLitMax"
                    entities = entities.OrderBy(Function(e) e.NombreDeLitMax)
                Case "NombreDeLitMax_desc"
                    entities = entities.OrderByDescending(Function(e) e.NombreDeLitMax)
                Case "NombreDeMedecin"
                    entities = entities.OrderBy(Function(e) e.NombreDeMedecin)
                Case "NombreDeMedecin_desc"
                    entities = entities.OrderByDescending(Function(e) e.NombreDeMedecin)
                Case "NombreDInfimiere"
                    entities = entities.OrderBy(Function(e) e.NombreDInfimiere)
                Case "NombreDInfimiere_desc"
                    entities = entities.OrderByDescending(Function(e) e.NombreDInfimiere)
                Case "NombreDePersonnelNonMedical"
                    entities = entities.OrderBy(Function(e) e.NombreDePersonnelNonMedical)
                Case "NombreDePersonnelNonMedical_desc"
                    entities = entities.OrderByDescending(Function(e) e.NombreDePersonnelNonMedical)
                Case "TelephoneUrgence"
                    entities = entities.OrderBy(Function(e) e.TelephoneUrgence)
                Case "TelephoneUrgence_desc"
                    entities = entities.OrderByDescending(Function(e) e.TelephoneUrgence)
                Case "Email"
                    entities = entities.OrderBy(Function(e) e.Email)
                Case "Email_desc"
                    entities = entities.OrderByDescending(Function(e) e.Email)
                Case "SiteWeb"
                    entities = entities.OrderBy(Function(e) e.SiteWeb)
                Case "SiteWeb_desc"
                    entities = entities.OrderByDescending(Function(e) e.SiteWeb)
                Case "Oganisation"
                    entities = entities.OrderBy(Function(e) e.Oganisation.Nom)
                Case "Oganisation_desc"
                    entities = entities.OrderByDescending(Function(e) e.Oganisation.Nom)
                Case "Ville"
                    entities = entities.OrderBy(Function(e) e.Ville.Libelle)
                Case "Ville_desc"
                    entities = entities.OrderByDescending(Function(e) e.Ville.Libelle)
                Case "TypeHopitaux"
                    entities = entities.OrderBy(Function(e) e.TypeHopitaux.Libelle)
                Case "TypeHopitaux_desc"
                    entities = entities.OrderByDescending(Function(e) e.TypeHopitaux.Libelle)

                Case Else
                    entities = entities.OrderBy(Function(e) e.Nom)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Hopitaux/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim Hopitaux As Hopitaux = Db.Hopitaux.Find(id)
        '    If IsNothing(Hopitaux) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(Hopitaux)
        'End Function

        Private Sub LoadComboBox(entityVM As HopitauxViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            Dim Organisation = (From e In Db.Organisation Where e.StatutExistant = 1 Select e)
            Dim LesOrganisations As New List(Of SelectListItem)
            Dim Ville = (From e In Db.Ville Where e.StatutExistant = 1 Select e)
            Dim LesVilles As New List(Of SelectListItem)
            Dim TypeHopitaux = (From e In Db.TypeHopitaux Where e.StatutExistant = 1 Select e)
            Dim LesTypeHopitaux As New List(Of SelectListItem)

            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            For Each item In Organisation
                LesOrganisations.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
            Next

            For Each item In Ville
                LesVilles.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In TypeHopitaux
                LesTypeHopitaux.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            entityVM.LesUtilisateurs = LesUtilisateurs
            entityVM.LesTypeHopitauxs = LesTypeHopitaux
            entityVM.LesVilles = LesVilles
            entityVM.LesOrganisations = LesOrganisations
        End Sub

        ' GET: Hopitaux/Create
        Function Create() As ActionResult
            Dim entityVM As New HopitauxViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function


        <HttpPost()>
        Function Create(ByVal entityVM As HopitauxJS) As ActionResult
            Dim Ent As New Hopitaux
            Ent = entityVM.GetEntity(GetCurrentUser.Id)

            If (IsNothing(Ent.Location)) Then
                ModelState.AddModelError("", "Veuillez remplir le champ location")
            End If
            ' DbGeography.FromText("POINT(-122.336106 47.605049)")
            If ModelState.IsValid Then
                Db.Hopitaux.Add(Ent)
                Try
                    Db.SaveChanges()
                    Return Json(New With {.Result = "OK"})
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try
            End If
            'LoadComboBox(entityVM)
            Return Json(New With {.Result = "Error"})
            'Return View(entityVM)
        End Function

        '' POST: Hopitaux/Create
        ''Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        ''plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        '<HttpPost()>
        '<ValidateAntiForgeryToken()>
        'Function Create(ByVal entityVM As HopitauxViewModel) As ActionResult
        '    entityVM.AspNetUserId = GetCurrentUser.Id
        '    If ModelState.IsValid Then

        '        Db.Hopitaux.Add(entityVM.GetEntity)
        '        Try
        '            Db.SaveChanges()
        '            Return RedirectToAction("Index")
        '        Catch ex As DbEntityValidationException
        '            Util.GetError(ex, ModelState)
        '        Catch ex As Exception
        '            Util.GetError(ex, ModelState)
        '        End Try
        '    End If
        '    LoadComboBox(entityVM)
        '    Return View(entityVM)
        'End Function

        ' GET: Hopitaux/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Hopitaux As Hopitaux = Db.Hopitaux.Find(id)
            If IsNothing(Hopitaux) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New HopitauxViewModel(Hopitaux)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Hopitaux/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As HopitauxViewModel) As ActionResult
            If ModelState.IsValid Then
                Db.Entry(entityVM.GetEntity).State = EntityState.Modified
                Try
                    Db.SaveChanges()
                    Return RedirectToAction("Index")
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try
            End If
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' GET: Hopitaux/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Hopitaux As Hopitaux = Db.Hopitaux.Find(id)
            If IsNothing(Hopitaux) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New HopitauxViewModel(Hopitaux)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Hopitaux/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim Hopitaux As Hopitaux = Db.Hopitaux.Find(id)
            Db.Hopitaux.Remove(Hopitaux)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New HopitauxViewModel(Hopitaux))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class

    Public Class HopitauxJS

        Public Property Code As String
        Public Property Nom As String
        Public Property VilleId As String
        Public Property OrganisationId As String
        Public Property TypeHopitauxId As Long
        Public Property NombreDeLitMin As Long
        Public Property NombreDeLitMax As Long
        Public Property NombreDeMedecin As Long
        Public Property NombreDInfimiere As Long
        Public Property NombreDePersonnelNonMedical As Long
        Public Property TelephoneUrgence As String
        Public Property Telephone As String
        Public Property SiteWeb As String
        Public Property Email As String
        Public Property Latitude As String
        Public Property Longitude As String

        Public Function GetEntity(Str As String) As Hopitaux
            Dim entity As New Hopitaux
            With entity
                .Id = 0
                .Nom = Nom
                .Code = Code
                .NombreDeLitMin = NombreDeLitMin
                .NombreDeLitMax = NombreDeLitMax
                .NombreDeMedecin = NombreDeMedecin
                .NombreDInfimiere = NombreDInfimiere
                .NombreDePersonnelNonMedical = NombreDePersonnelNonMedical
                .SiteWeb = SiteWeb
                .Telephone = Telephone
                .TelephoneUrgence = TelephoneUrgence
                .VilleId = VilleId
                .Location = Util.CreatePoint(latitude:=Latitude, longitude:=Longitude)
                .Email = Email
                .OganisationId = OrganisationId
                .TypeHopitauxId = TypeHopitauxId
                .StatutExistant = 1
                .DateCreation = Now
                .AspNetUserId = Str
            End With
            Return entity
        End Function
    End Class
End Namespace
