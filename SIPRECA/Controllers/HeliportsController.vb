Imports System.Data.Entity
Imports System.Data.Entity.Spatial
Imports System.Data.Entity.Validation
Imports System.Globalization
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources

Namespace Controllers
    Public Class HeliportsController
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

        ' GET: Heliport
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.NomSort = If(sortOrder = "Nom", "Nom_desc", "Nom")
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

            Dim entities = (From e In Db.Heliport Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Code.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Email.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.SiteWeb.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Telephone.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Oganisation.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Telephone2.ToUpper.Contains(value:=searchString.ToUpper) Or
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
                Case Else
                    entities = entities.OrderBy(Function(e) e.Nom)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Heliport/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim Heliport As Heliport = Db.Heliport.Find(id)
        '    If IsNothing(Heliport) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(Heliport)
        'End Function

        Private Sub LoadComboBox(entityVM As HeliportViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            Dim Organisation = (From e In Db.Organisation Where e.StatutExistant = 1 Select e)
            Dim LesOrganisations As New List(Of SelectListItem)
            Dim Commune = (From e In Db.Commune Where e.StatutExistant = 1 Select e)
            Dim LesCommunes As New List(Of SelectListItem)

            Dim Materiels = (From e In Db.Materiel Where e.Cible = 3 Select e).ToList
            Dim MaterielHeliport = (From e In Db.MaterielHeliport Where e.StatutExistant = 1 Select e.Materiel).ToList
            Dim MaterielHeliports = (From e In Db.MaterielHeliport Where e.StatutExistant = 1 Select e).ToList
            Dim LesMaterielHeliports As New List(Of SelectListItem)

            For Each item In Materiels
                If Not MaterielHeliport.Contains(item) Then
                    LesMaterielHeliports.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
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

            For Each item In Commune
                LesCommunes.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            entityVM.LesUtilisateurs = LesUtilisateurs
            entityVM.LesCommunes = LesCommunes
            entityVM.LesOrganisations = LesOrganisations
            entityVM.LesMaterielHeliports = LesMaterielHeliports
            entityVM.MaterielHeliports = MaterielHeliports
        End Sub

        ' GET: Heliport/Create
        Function Create() As ActionResult
            Dim entityVM As New HeliportViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function



        <HttpPost()>
        Function Create(ByVal entityVM As HeliportJS) As ActionResult
            Dim Ent As New Heliport
            Ent = entityVM.GetEntity(GetCurrentUser.Id)

            If (IsNothing(Ent.Location)) Then
                ModelState.AddModelError("", "Veuillez remplir le champ location")
            End If
            ' DbGeography.FromText("POINT(-122.336106 47.605049)")
            If ModelState.IsValid Then
                Db.Heliport.Add(Ent)
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

        ' POST: Heliport/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        '<HttpPost()>
        '<ValidateAntiForgeryToken()>
        'Function Create(ByVal entityVM As HeliportViewModel) As ActionResult
        '    entityVM.AspNetUserId = GetCurrentUser.Id

        '    entityVM.Location = Util.CreatePoint(latitude:=51.505, longitude:=-0.09)
        '    If (IsNothing(entityVM.Location)) Then
        '        ModelState.AddModelError("", "Veuillez remplir le champ location")
        '    End If
        '    ' DbGeography.FromText("POINT(-122.336106 47.605049)")
        '    If ModelState.IsValid Then
        '        Db.Heliport.Add(entityVM.GetEntity)
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

        ' GET: Heliport/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Heliport As Heliport = Db.Heliport.Find(id)
            If IsNothing(Heliport) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New HeliportViewModel(Heliport)
            LoadComboBox(entityVM)
            ViewBag.Latitude = 0
            ViewBag.Longitude = 0
            If Not IsNothing(entityVM.Location) Then
                ViewBag.Latitude = entityVM.Location.YCoordinate.ToString().Replace(",", ".")
                ViewBag.Longitude = entityVM.Location.XCoordinate.ToString().Replace(",", ".")
            End If
            Return View(entityVM)
        End Function

        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As HeliportViewModel) As ActionResult
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

        <HttpPost()>
        Function EditHeliport(ByVal entityVM As HeliportJS) As ActionResult
            Dim Ent As New Heliport
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
        Public Function AddMateriel(ByVal entityVM As HeliportViewModel) As ActionResult

            If IsNothing(entityVM.MaterielHeliportId) Then
                ModelState.AddModelError("MaterielHeliportId", Resource.MdlError_Fichier) 'Le champ {0} est obligatoire: veuillez le remplir.
            End If

            If ModelState.IsValid Then

                Dim MaterielHeliport As New MaterielHeliport()

                If entityVM.MaterielHeliportId > 0 Then

                    MaterielHeliport.MaterielId = entityVM.MaterielHeliportId
                    MaterielHeliport.Quantite = entityVM.Quantite
                    MaterielHeliport.HeliportId = entityVM.Id
                    MaterielHeliport.AspNetUserId = GetCurrentUser.Id

                    Db.MaterielHeliport.Add(MaterielHeliport)
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
                Dim MaterielHeliport = (From p In Db.MaterielHeliport Where p.Id = id Select p).ToList.FirstOrDefault
                If MaterielHeliport Is Nothing Then
                    Response.StatusCode = CType(HttpStatusCode.NotFound, Integer)
                    Return Json(New With {.Result = "Error"})
                End If

                Db.MaterielHeliport.Remove(MaterielHeliport)
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

        ' GET: Heliport/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Heliport As Heliport = Db.Heliport.Find(id)
            If IsNothing(Heliport) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New HeliportViewModel(Heliport)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Heliport/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim Heliport As Heliport = Db.Heliport.Find(id)
            Db.Heliport.Remove(Heliport)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New HeliportViewModel(Heliport))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class

    Public Class HeliportJS

        Public Property Id As Long
        Public Property Code As String
        Public Property Nom As String
        Public Property CommuneId As String
        Public Property OrganisationId As String
        Public Property Telephone As String
        Public Property Telephone2 As String
        Public Property SiteWeb As String
        Public Property Email As String
        Public Property Latitude As String
        Public Property Longitude As String

        Public Function GetEntity(Str As String) As Heliport
            Dim entity As New Heliport
            With entity
                .Id = Id
                .Nom = Nom
                .Code = Code
                .SiteWeb = SiteWeb
                .Telephone = Telephone
                .Telephone2 = Telephone2
                .CommuneId = CommuneId
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
