Imports System.Data.Entity
Imports System.Data.Entity.Spatial
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources

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
            If Not AppSession.ListActionSousRessource.Contains(24, 2) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            ViewBag.CurrentSort = sortOrder
            ViewBag.NomSort = If(sortOrder = "Nom", "Nom_desc", "Nom")
            ViewBag.NombreDeLitMinSort = If(sortOrder = "NombreDeLitMin", "NombreDeLitMin_desc", "NombreDeLitMin")
            ViewBag.NombreDeLitMaxSort = If(sortOrder = "NombreDeLitMax", "NombreDeLitMax_desc", "NombreDeLitMax")
            ViewBag.NombreDeMedecinSort = If(sortOrder = "NombreDeMedecin", "NombreDeMedecin_desc", "NombreDeMedecin")
            ViewBag.NombreDInfimiereSort = If(sortOrder = "NombreDInfimiere", "NombreDInfimiere_desc", "NombreDInfimiere")
            ViewBag.NombreDePersonnelNonMedicalSort = If(sortOrder = "NombreDePersonnelNonMedical", "NombreDePersonnelNonMedical_desc", "NombreDePersonnelNonMedical")
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
                                              e.Commune.Libelle.ToUpper.Contains(value:=searchString.ToUpper))
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
            Dim Commune = (From e In Db.Commune Where e.StatutExistant = 1 Select e)
            Dim LesCommunes As New List(Of SelectListItem)
            Dim TypeHopitaux = (From e In Db.TypeHopitaux Where e.StatutExistant = 1 Select e)
            Dim LesTypeHopitaux As New List(Of SelectListItem)

            Dim HopitauxPuissance = (From e In Db.HopitauxPuissance Where e.HopitauxId = entityVM.Id Select e).ToList
            Dim HopitauxPuissances = (From e In Db.Puissance Where e.StatutExistant = 1 Select e).ToList
            Dim LesHopitauxPuissances As New List(Of SelectListItem)

            Dim Materiels = (From e In Db.Materiel Where e.Cible = 1 Select e).ToList
            Dim MaterielHopitau = (From e In Db.MaterielHopitaux Where e.StatutExistant = 1 Select e.Materiel).ToList
            Dim MaterielHopitaux = (From e In Db.MaterielHopitaux Where e.StatutExistant = 1 Select e).ToList
            Dim LesMaterielHopitaux As New List(Of SelectListItem)

            For Each item In Materiels
                If Not MaterielHopitau.Contains(item) Then
                    LesMaterielHopitaux.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
                End If
            Next

            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            For Each item In HopitauxPuissances

                Dim se As Boolean = True

                For Each item2 In HopitauxPuissance
                    If item.Id = item2.HopitauxId Then
                        se = False
                    End If
                Next

                If se = True Then
                    LesHopitauxPuissances.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
                End If
            Next

            For Each item In Organisation
                LesOrganisations.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
            Next

            For Each item In Commune
                LesCommunes.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In TypeHopitaux
                LesTypeHopitaux.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            entityVM.HopitauxPuissances = HopitauxPuissance
            entityVM.LesHopitauxPuissances = LesHopitauxPuissances
            entityVM.LesUtilisateurs = LesUtilisateurs
            entityVM.LesTypeHopitauxs = LesTypeHopitaux
            entityVM.LesCommunes = LesCommunes
            entityVM.LesOrganisations = LesOrganisations
            entityVM.LesMaterielHopitaux = LesMaterielHopitaux
            entityVM.MaterielHopitaux = MaterielHopitaux
        End Sub

        ' GET: Hopitaux/Create
        Function Create() As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(24, 1) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            Dim entityVM As New HopitauxViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function


        <HttpPost()>
        Function Create(ByVal entityVM As HopitauxJS) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(24, 1) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
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
            If Not AppSession.ListActionSousRessource.Contains(24, 3) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Hopitaux As Hopitaux = Db.Hopitaux.Find(id)
            If IsNothing(Hopitaux) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New HopitauxViewModel(Hopitaux)
            LoadComboBox(entityVM)
            ViewBag.Latitude = 0
            ViewBag.Longitude = 0
            If Not IsNothing(entityVM.Location) Then
                ViewBag.Latitude = entityVM.Location.YCoordinate.ToString().Replace(",", ".")
                ViewBag.Longitude = entityVM.Location.XCoordinate.ToString().Replace(",", ".")
            End If
            Return View(entityVM)
        End Function

        ' POST: Hopitaux/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        Function EditHopitaux(ByVal entityVM As HopitauxJS) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(24, 3) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            Dim Ent As New Hopitaux
            Ent = entityVM.GetEntity(GetCurrentUser.Id)

            If (IsNothing(Ent.Location)) Then
                ModelState.AddModelError("", "Veuillez remplir le champ location.")
            End If
            If ModelState.IsValid Then
                Db.Entry(Ent).State = EntityState.Modified
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

        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As HopitauxViewModel) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(24, 3) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
            If Request.Form("AddMateriel") IsNot Nothing Then
                Return AddMateriel(entityVM)
            Else
                'If ModelState.IsValid Then
                '    Db.Entry(entityVM.GetEntity).State = EntityState.Modified
                '    Try
                '        Db.SaveChanges()
                '        Return RedirectToAction("Index")
                '    Catch ex As DbEntityValidationException
                '        Util.GetError(ex, ModelState)
                '    Catch ex As Exception
                '        Util.GetError(ex, ModelState)
                '    End Try
                'End If
            End If
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        '<ValidateAntiForgeryToken()>
        '<HttpPost>
        'Public Function AddPuissance(ByVal entityVM As HopitauxViewModel) As ActionResult

        '    If IsNothing(entityVM.HopitauxPuissanceId) Then
        '        ModelState.AddModelError("Puissance", Resource.MdlError_Fichier) 'Le champ {0} est obligatoire: veuillez le remplir.
        '    End If

        '    If ModelState.IsValid Then

        '        Dim HopitauxPuissance As New HopitauxPuissance()

        '        If entityVM.HopitauxPuissanceId > 0 Then

        '            HopitauxPuissance.PuissanceId = entityVM.HopitauxPuissanceId
        '            HopitauxPuissance.HopitauxId = entityVM.Id

        '            Db.HopitauxPuissance.Add(HopitauxPuissance)
        '            Try
        '                Db.SaveChanges()
        '            Catch ex As DbEntityValidationException
        '                Util.GetError(ex, ModelState)
        '            Catch ex As Exception
        '                Util.GetError(ex, ModelState)
        '            End Try

        '        End If
        '        Return RedirectToAction("Edit", New With {entityVM.Id})
        '    End If
        '    LoadComboBox(entityVM)
        '    Return View("Edit", entityVM)
        'End Function

        '<HttpPost>
        'Public Function DeletePuissance(id As String) As JsonResult
        '    If [String].IsNullOrEmpty(id) Then
        '        Response.StatusCode = CType(HttpStatusCode.BadRequest, Integer)
        '        Return Json(New With {.Result = "Error"})
        '    End If
        '    Try
        '        Dim HopitauxPuissance = (From p In Db.HopitauxPuissance Where p.Id = id Select p).ToList.FirstOrDefault
        '        If HopitauxPuissance Is Nothing Then
        '            Response.StatusCode = CType(HttpStatusCode.NotFound, Integer)
        '            Return Json(New With {.Result = "Error"})
        '        End If

        '        Db.HopitauxPuissance.Remove(HopitauxPuissance)
        '        Try
        '            Db.SaveChanges()
        '        Catch ex As DbEntityValidationException
        '            Util.GetError(ex, ModelState)
        '        Catch ex As Exception
        '            Util.GetError(ex, ModelState)
        '        End Try

        '        Return Json(New With {.Result = "OK"})
        '    Catch ex As Exception
        '        'Return Json(New With {.Result = "ERROR", .Message = ex.Message})
        '        Return Json(New With {.Result = "Error"})
        '    End Try
        'End Function

        <ValidateAntiForgeryToken()>
        <HttpPost>
        Public Function AddMateriel(ByVal entityVM As HopitauxViewModel) As ActionResult

            If IsNothing(entityVM.MaterielHopitauxId) Then
                ModelState.AddModelError("MaterielHopitauxId", Resource.MdlError_Fichier) 'Le champ {0} est obligatoire: veuillez le remplir.
            End If

            If ModelState.IsValid Then

                Dim MaterielHopitaux As New MaterielHopitaux()

                If entityVM.MaterielHopitauxId > 0 Then

                    MaterielHopitaux.MaterielId = entityVM.MaterielHopitauxId
                    MaterielHopitaux.Quantite = entityVM.Quantite
                    MaterielHopitaux.HopitauxId = entityVM.Id
                    MaterielHopitaux.AspNetUserId = GetCurrentUser.Id

                    Db.MaterielHopitaux.Add(MaterielHopitaux)
                    Try
                        Db.SaveChanges()
                    Catch ex As DbEntityValidationException
                        Util.GetError(ex, ModelState)
                    Catch ex As Exception
                        Util.GetError(ex, ModelState)
                    End Try

                End If
                Return RedirectToAction("Edit", New With {entityVM.Id})
            End If
            LoadComboBox(entityVM)
            Return View("Edit", entityVM)
        End Function

        ' GET: Hopitaux/Edit/5
        Function Details(ByVal id As Long?) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(24, 5) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
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

        <HttpPost>
        Public Function DeleteMateriel(id As String) As JsonResult
            If [String].IsNullOrEmpty(id) Then
                Response.StatusCode = CType(HttpStatusCode.BadRequest, Integer)
                Return Json(New With {.Result = "Error"})
            End If
            Try
                Dim MaterielHopitaux = (From p In Db.MaterielHopitaux Where p.Id = id Select p).ToList.FirstOrDefault
                If MaterielHopitaux Is Nothing Then
                    Response.StatusCode = CType(HttpStatusCode.NotFound, Integer)
                    Return Json(New With {.Result = "Error"})
                End If

                Db.MaterielHopitaux.Remove(MaterielHopitaux)
                Try
                    Db.SaveChanges()
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try

                Return Json(New With {.Result = "OK"})
            Catch ex As Exception
                'Return Json(New With {.Result = "ERROR", .Message = ex.Message})
                Return Json(New With {.Result = "Error"})
            End Try
        End Function

        ' GET: Hopitaux/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If Not AppSession.ListActionSousRessource.Contains(24, 4) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
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
            If Not AppSession.ListActionSousRessource.Contains(24, 4) Then
                Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
            End If
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

        Public Property Id As Long
        Public Property Code As String
        Public Property Nom As String
        Public Property CommuneId As String
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
                .Id = Id
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
                .CommuneId = CommuneId
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
