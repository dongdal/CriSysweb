Imports System.Data.Entity
Imports System.Data.Entity.Spatial
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList

Namespace Controllers
    Public Class AeroportController
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

        ' GET: Aeroport
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.NomSort = If(sortOrder = "Nom", "Nom_desc", "Nom")
            ViewBag.ICAOSort = If(sortOrder = "ICAO", "ICAO_desc", "ICAO")
            ViewBag.IATASort = If(sortOrder = "IATA", "IATA_desc", "IATA")
            ViewBag.LongueurDePisteSort = If(sortOrder = "LongueurDePiste", "LongueurDePiste_desc", "LongueurDePiste")
            ViewBag.LargeurDePisteSort = If(sortOrder = "LargeurDePiste", "LargeurDePiste_desc", "LargeurDePiste")
            ViewBag.UsageHumanitaireSort = If(sortOrder = "UsageHumanitaire", "UsageHumanitaire_desc", "UsageHumanitaire")
            ViewBag.TailleDeAeronefSort = If(sortOrder = "TailleDeAeronef", "TailleDeAeronef_desc", "TailleDeAeronef")
            ViewBag.SurfaceDePisteSort = If(sortOrder = "SurfaceDePiste", "SurfaceDePiste_desc", "SurfaceDePiste")
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

            Dim entities = (From e In Db.Aeroport Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.ICAO.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.IATA.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.LongueurDePiste.Equals(searchString) Or
                                              e.LargeurDePiste.Equals(searchString) Or
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
                Case "ICAO"
                    entities = entities.OrderBy(Function(e) e.ICAO)
                Case "ICAO_desc"
                    entities = entities.OrderByDescending(Function(e) e.ICAO)
                Case "IATA"
                    entities = entities.OrderBy(Function(e) e.ICAO)
                Case "IATA_desc"
                    entities = entities.OrderByDescending(Function(e) e.ICAO)
                Case "Telephone"
                    entities = entities.OrderBy(Function(e) e.Telephone)
                Case "Telephone_desc"
                    entities = entities.OrderByDescending(Function(e) e.Telephone)
                Case "LongueurDePiste"
                    entities = entities.OrderBy(Function(e) e.LongueurDePiste)
                Case "LongueurDePiste_desc"
                    entities = entities.OrderByDescending(Function(e) e.LongueurDePiste)
                Case "LargeurDePiste"
                    entities = entities.OrderBy(Function(e) e.LargeurDePiste)
                Case "LargeurDePiste_desc"
                    entities = entities.OrderByDescending(Function(e) e.LargeurDePiste)
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

        ' GET: Aeroport/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim Aeroport As Aeroport = Db.Aeroport.Find(id)
        '    If IsNothing(Aeroport) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(Aeroport)
        'End Function

        Private Sub LoadComboBox(entityVM As AeroportViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            Dim Organisation = (From e In Db.Organisation Where e.StatutExistant = 1 Select e)
            Dim LesOrganisations As New List(Of SelectListItem)
            Dim Ville = (From e In Db.Ville Where e.StatutExistant = 1 Select e)
            Dim LesVilles As New List(Of SelectListItem)
            Dim SurfaceDePiste = (From e In Db.SurfaceDePiste Where e.StatutExistant = 1 Select e)
            Dim LesSurfaceDePistes As New List(Of SelectListItem)
            Dim TailleDeAeronef = (From e In Db.TailleDeAeronef Where e.StatutExistant = 1 Select e)
            Dim LesTailleDeAeronefs As New List(Of SelectListItem)
            Dim UsageHumanitaire = (From e In Db.UsageHumanitaire Where e.StatutExistant = 1 Select e)
            Dim LesUsageHumanitaires As New List(Of SelectListItem)

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

            For Each item In SurfaceDePiste
                LesSurfaceDePistes.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In TailleDeAeronef
                LesTailleDeAeronefs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In UsageHumanitaire
                LesUsageHumanitaires.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            entityVM.LesUtilisateurs = LesUtilisateurs
            entityVM.LesSurfaceDePistes = LesSurfaceDePistes
            entityVM.LesTailleDeAeronefs = LesTailleDeAeronefs
            entityVM.LesUsageHumanitaires = LesUsageHumanitaires
            entityVM.LesVilles = LesVilles
            entityVM.LesOrganisations = LesOrganisations
        End Sub

        ' GET: Aeroport/Create
        Function Create() As ActionResult
            Dim entityVM As New AeroportViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function


        <HttpPost()>
        Function Create(ByVal entityVM As AeroportJS) As ActionResult
            Dim Ent As New Aeroport
            Ent = entityVM.GetEntity(GetCurrentUser.Id)

            If (IsNothing(Ent.Location)) Then
                ModelState.AddModelError("", "Veuillez remplir le champ location")
            End If
            ' DbGeography.FromText("POINT(-122.336106 47.605049)")
            If ModelState.IsValid Then
                Db.Aeroport.Add(Ent)
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

        '' POST: Aeroport/Create
        ''Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        ''plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        '<HttpPost()>
        '<ValidateAntiForgeryToken()>
        'Function Create(ByVal entityVM As AeroportViewModel) As ActionResult
        '    entityVM.AspNetUserId = GetCurrentUser.Id
        '    If ModelState.IsValid Then

        '        Db.Aeroport.Add(entityVM.GetEntity)
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

        ' GET: Aeroport/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Aeroport As Aeroport = Db.Aeroport.Find(id)
            If IsNothing(Aeroport) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New AeroportViewModel(Aeroport)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Aeroport/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As AeroportViewModel) As ActionResult
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

        ' GET: Aeroport/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Aeroport As Aeroport = Db.Aeroport.Find(id)
            If IsNothing(Aeroport) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New AeroportViewModel(Aeroport)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Aeroport/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim Aeroport As Aeroport = Db.Aeroport.Find(id)
            Db.Aeroport.Remove(Aeroport)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New AeroportViewModel(Aeroport))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class

    Public Class AeroportJS

        Public Property Nom As String
        Public Property ICAO As String
        Public Property IATA As String
        Public Property LongueurDePiste As Double
        Public Property LargeurDePiste As Double
        Public Property Telephone As String
        Public Property Telephone2 As String
        Public Property SiteWeb As String
        Public Property Email As String
        Public Property Latitude As String
        Public Property Longitude As String
        Public Property OganisationId As Long
        Public Property VilleId As Long
        Public Property SurfaceDePisteId As Long
        Public Property TailleDeAeronefId As Long
        Public Property UsageHumanitaireId As Long

        Public Function GetEntity(Str As String) As Aeroport
            Dim entity As New Aeroport
            With entity
                .Id = 0
                .Nom = Nom
                .ICAO = ICAO
                .IATA = IATA
                .LongueurDePiste = LongueurDePiste
                .LargeurDePiste = LargeurDePiste
                .Telephone = Telephone
                .Telephone2 = Telephone2
                .SiteWeb = SiteWeb
                .Telephone = Telephone
                .OganisationId = OganisationId
                .VilleId = VilleId
                .Location = Util.CreatePoint(latitude:=Latitude, longitude:=Longitude)
                .Email = Email
                .SurfaceDePisteId = SurfaceDePisteId
                .TailleDeAeronefId = TailleDeAeronefId
                .UsageHumanitaireId = UsageHumanitaireId
                .StatutExistant = 1
                .DateCreation = Now
                .AspNetUserId = Str
            End With
            Return entity
        End Function
    End Class
End Namespace
