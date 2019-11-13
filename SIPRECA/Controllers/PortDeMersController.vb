Imports System.Data.Entity
Imports System.Data.Entity.Spatial
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources

Namespace Controllers
    Public Class PortDeMersController
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

        ' GET: PortDeMer
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.NomSort = If(sortOrder = "Nom", "Nom_desc", "Nom")
            ViewBag.PossessionSort = If(sortOrder = "Possession", "Possession_desc", "Possession")
            ViewBag.HauteurMaximumSort = If(sortOrder = "HauteurMaximum", "HauteurMaximum_desc", "HauteurMaximum")
            ViewBag.HauteurMaximumUnitesSort = If(sortOrder = "HauteurMaximumUnites", "HauteurMaximumUnites_desc", "HauteurMaximumUnites")
            ViewBag.ProfondeurQuaiChargementSort = If(sortOrder = "ProfondeurQuaiChargement", "ProfondeurQuaiChargement_desc", "ProfondeurQuaiChargement")
            ViewBag.ProfondeurTerminalPetrolierSort = If(sortOrder = "ProfondeurTerminalPetrolier", "ProfondeurTerminalPetrolier_desc", "ProfondeurTerminalPetrolier")
            ViewBag.VilleSort = If(sortOrder = "Ville", "Ville_desc", "Ville")
            ViewBag.CodeSort = If(sortOrder = "Code", "Code_desc", "Code")
            ViewBag.TelephoneSort = If(sortOrder = "Telephone", "Telephone_desc", "Telephone")
            ViewBag.Telephone2Sort = If(sortOrder = "Telephone2", "Telephone2_desc", "Telephone2")
            ViewBag.EmailSort = If(sortOrder = "Email", "Email_desc", "Email")
            ViewBag.SiteWebSort = If(sortOrder = "SiteWeb", "SiteWeb_desc", "SiteWeb")
            ViewBag.OrganisationSort = If(sortOrder = "Organisation", "Organisation_desc", "Organisation")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.PortDeMer Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Code.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Email.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.SiteWeb.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Telephone.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Oganisation.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Telephone2.ToUpper.Contains(value:=searchString.ToUpper) Or
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
                Case "Possession"
                    entities = entities.OrderBy(Function(e) e.Possession)
                Case "Possession_desc"
                    entities = entities.OrderByDescending(Function(e) e.Possession)
                Case "HauteurMaximum"
                    entities = entities.OrderBy(Function(e) e.HauteurMaximum)
                Case "HauteurMaximum_desc"
                    entities = entities.OrderByDescending(Function(e) e.HauteurMaximum)
                Case "ProfondeurQuaiChargement"
                    entities = entities.OrderBy(Function(e) e.ProfondeurQuaiChargement)
                Case "ProfondeurQuaiChargement_desc"
                    entities = entities.OrderByDescending(Function(e) e.ProfondeurQuaiChargement)
                Case "HauteurMaximumUnites"
                    entities = entities.OrderBy(Function(e) e.HauteurMaximumUnites)
                Case "HauteurMaximumUnites_desc"
                    entities = entities.OrderByDescending(Function(e) e.HauteurMaximumUnites)
                Case "ProfondeurTerminalPetrolier"
                    entities = entities.OrderBy(Function(e) e.ProfondeurTerminalPetrolier)
                Case "ProfondeurTerminalPetrolier_desc"
                    entities = entities.OrderByDescending(Function(e) e.ProfondeurTerminalPetrolier)
                Case "Telephone2"
                    entities = entities.OrderBy(Function(e) e.Telephone2)
                Case "Telephone2_desc"
                    entities = entities.OrderByDescending(Function(e) e.Telephone2)
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
                Case Else
                    entities = entities.OrderBy(Function(e) e.Nom)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: PortDeMer/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim PortDeMer As PortDeMer = Db.PortDeMer.Find(id)
        '    If IsNothing(PortDeMer) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(PortDeMer)
        'End Function

        Private Sub LoadComboBox(entityVM As PortDeMerViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            Dim Organisation = (From e In Db.Organisation Where e.StatutExistant = 1 Select e)
            Dim LesOrganisations As New List(Of SelectListItem)
            Dim Ville = (From e In Db.Ville Where e.StatutExistant = 1 Select e)
            Dim LesVilles As New List(Of SelectListItem)

            Dim Materiels = (From e In Db.Materiel Where e.Cible = 4 Select e).ToList
            Dim MaterielPortDeMer = (From e In Db.MaterielPortDeMer Where e.StatutExistant = 1 Select e.Materiel).ToList
            Dim MaterielPortDeMers = (From e In Db.MaterielPortDeMer Where e.StatutExistant = 1 Select e).ToList
            Dim LesMaterielPortDeMers As New List(Of SelectListItem)

            For Each item In Materiels
                If Not MaterielPortDeMer.Contains(item) Then
                    LesMaterielPortDeMers.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
                End If
            Next

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

            entityVM.LesUtilisateurs = LesUtilisateurs
            entityVM.LesVilles = LesVilles
            entityVM.LesOrganisations = LesOrganisations
            entityVM.LesMaterielPortDeMers = LesMaterielPortDeMers
            entityVM.MaterielPortDeMers = MaterielPortDeMers
        End Sub

        ' GET: PortDeMer/Create
        Function Create() As ActionResult
            Dim entityVM As New PortDeMerViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function


        <HttpPost()>
        Function Create(ByVal entityVM As PortDeMerJS) As ActionResult
            Dim Ent As New PortDeMer
            Ent = entityVM.GetEntity(GetCurrentUser.Id)

            If (IsNothing(Ent.Location)) Then
                ModelState.AddModelError("", "Veuillez remplir le champ location")
            End If
            ' DbGeography.FromText("POINT(-122.336106 47.605049)")
            If ModelState.IsValid Then
                Db.PortDeMer.Add(Ent)
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

        '' POST: PortDeMer/Create
        ''Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        ''plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        '<HttpPost()>
        '<ValidateAntiForgeryToken()>
        'Function Create(ByVal entityVM As PortDeMerViewModel) As ActionResult
        '    entityVM.AspNetUserId = GetCurrentUser.Id
        '    If ModelState.IsValid Then

        '        Db.PortDeMer.Add(entityVM.GetEntity)
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

        ' GET: PortDeMer/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim PortDeMer As PortDeMer = Db.PortDeMer.Find(id)
            If IsNothing(PortDeMer) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New PortDeMerViewModel(PortDeMer)
            LoadComboBox(entityVM)
            ViewBag.Latitude = entityVM.Location.YCoordinate.ToString().Replace(",", ".")
            ViewBag.Longitude = entityVM.Location.XCoordinate.ToString().Replace(",", ".")
            Return View(entityVM)
        End Function

        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As PortDeMerViewModel) As ActionResult
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

        ' POST: PortDeMer/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        Function EditPortdeMer(ByVal entityVM As PortDeMerJS) As ActionResult
            Dim Ent As New PortDeMer
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

        <ValidateAntiForgeryToken()>
        <HttpPost>
        Public Function AddMateriel(ByVal entityVM As PortDeMerViewModel) As ActionResult

            If IsNothing(entityVM.MaterielPortDeMerId) Then
                ModelState.AddModelError("MaterielPortDeMerId", Resource.MdlError_Fichier) 'Le champ {0} est obligatoire: veuillez le remplir.
            End If

            If ModelState.IsValid Then

                Dim MaterielPortDeMer As New MaterielPortDeMer()

                If entityVM.MaterielPortDeMerId > 0 Then

                    MaterielPortDeMer.MaterielId = entityVM.MaterielPortDeMerId
                    MaterielPortDeMer.PortDeMerId = entityVM.Id
                    MaterielPortDeMer.AspNetUserId = GetCurrentUser.Id

                    Db.MaterielPortDeMer.Add(MaterielPortDeMer)
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

        <HttpPost>
        Public Function DeleteMateriel(id As String) As JsonResult
            If [String].IsNullOrEmpty(id) Then
                Response.StatusCode = CType(HttpStatusCode.BadRequest, Integer)
                Return Json(New With {.Result = "Error"})
            End If
            Try
                Dim MaterielPortDeMer = (From p In Db.MaterielPortDeMer Where p.Id = id Select p).ToList.FirstOrDefault
                If MaterielPortDeMer Is Nothing Then
                    Response.StatusCode = CType(HttpStatusCode.NotFound, Integer)
                    Return Json(New With {.Result = "Error"})
                End If

                Db.MaterielPortDeMer.Remove(MaterielPortDeMer)
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

        ' GET: PortDeMer/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim PortDeMer As PortDeMer = Db.PortDeMer.Find(id)
            If IsNothing(PortDeMer) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New PortDeMerViewModel(PortDeMer)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: PortDeMer/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim PortDeMer As PortDeMer = Db.PortDeMer.Find(id)
            Db.PortDeMer.Remove(PortDeMer)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New PortDeMerViewModel(PortDeMer))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class

    Public Class PortDeMerJS

        Public Property Id As Long
        Public Property Code As String
        Public Property Nom As String
        Public Property VilleId As String
        Public Property OrganisationId As String
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
        Public Property ProfondeurMareBasseUnites As String
        Public Property ProfondeurMareBasse As Double
        Public Property ProfondeurInondation As Double
        Public Property ProfondeurInondationUnites As String
        Public Property Telephone2 As String
        Public Property Telephone As String
        Public Property SiteWeb As String
        Public Property Email As String
        Public Property Latitude As String
        Public Property Longitude As String

        Public Function GetEntity(Str As String) As PortDeMer
            Dim entity As New PortDeMer
            With entity
                .Id = Id
                .Nom = Nom
                .Code = Code
                .Possession = Possession
                .HauteurMaximum = HauteurMaximum
                .HauteurMaximumUnites = HauteurMaximumUnites
                .ProfondeurQuaiChargement = ProfondeurQuaiChargement
                .ProfondeurQuaiChargementUnites = ProfondeurQuaiChargementUnites
                .ProfondeurTerminalPetrolier = ProfondeurTerminalPetrolier
                .ProfondeurTerminalPetrolierUnites = ProfondeurTerminalPetrolierUnites
                .CaleSeche = CaleSeche
                .LongueurMaximaleNavire = LongueurMaximaleNavire
                .LongueurMaximaleNavireUnites = LongueurMaximaleNavireUnites
                .Reparations = Reparations
                .Abri = Abri
                .CapaciteStockageEntreposage = CapaciteStockageEntreposage
                .CapaciteStockageSecurise = CapaciteStockageSecurise
                .CapaciteStockageEntrepotDouanier = CapaciteStockageEntrepotDouanier
                .NombreRemorqueur = NombreRemorqueur
                .CapaciteRemorqueur = CapaciteRemorqueur
                .NombreBarge = NombreBarge
                .CapacietBarge = CapacietBarge
                .EquipementChargement = EquipementChargement
                .CapaciteDouaniere = CapaciteDouaniere
                .Securite = Securite
                .ProfondeurMareHaute = ProfondeurMareHaute
                .ProfondeurMareHauteUnites = ProfondeurMareHauteUnites
                .ProfondeurMareBasse = ProfondeurMareBasse
                .ProfondeurMareBasseUnites = ProfondeurMareBasseUnites
                .ProfondeurInondation = ProfondeurInondation
                .ProfondeurInondationUnites = ProfondeurInondationUnites
                .SiteWeb = SiteWeb
                .Telephone = Telephone
                .Telephone2 = Telephone2
                .VilleId = VilleId
                .Location = Util.CreatePoint(latitude:=Latitude, longitude:=Longitude)
                .Email = Email
                .OganisationId = OrganisationId
                .StatutExistant = 1
                .DateCreation = Now
                .AspNetUserId = Str
            End With
            Return entity
        End Function
    End Class
End Namespace
