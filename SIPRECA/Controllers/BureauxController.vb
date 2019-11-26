Imports System.Data.Entity
Imports System.Data.Entity.Spatial
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources

Namespace Controllers
    Public Class BureauxController
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

        ' GET: Bureau
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.NomSort = If(sortOrder = "Nom", "Nom_desc", "Nom")
            ViewBag.CodePostaleSort = If(sortOrder = "CodePostale", "CodePostale_desc", "CodePostale")
            ViewBag.CodeSort = If(sortOrder = "Code", "Code_desc", "Code")
            ViewBag.TelephoneSort = If(sortOrder = "Telephone", "Telephone_desc", "Telephone")
            ViewBag.Telephone2Sort = If(sortOrder = "Telephone2", "Telephone2_desc", "Telephone2")
            ViewBag.EmailSort = If(sortOrder = "Email", "Email_desc", "Email")
            ViewBag.OrganisationSort = If(sortOrder = "Organisation", "Organisation_desc", "Organisation")
            ViewBag.TypeOfficeSort = If(sortOrder = "TypeOffice", "TypeOffice_desc", "TypeOffice")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.Bureau Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Code.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Email.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Telephone.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Oganisation.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Telephone2.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.CodePostale.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.TypeOffice.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or
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
                Case "CodePostale"
                    entities = entities.OrderBy(Function(e) e.CodePostale)
                Case "CodePostale_desc"
                    entities = entities.OrderByDescending(Function(e) e.CodePostale)
                Case "Telephone2"
                    entities = entities.OrderBy(Function(e) e.Telephone2)
                Case "Telephone2_desc"
                    entities = entities.OrderByDescending(Function(e) e.Telephone2)
                Case "Email"
                    entities = entities.OrderBy(Function(e) e.Email)
                Case "Email_desc"
                    entities = entities.OrderByDescending(Function(e) e.Email)
                Case "Oganisation"
                    entities = entities.OrderBy(Function(e) e.Oganisation.Nom)
                Case "Oganisation_desc"
                    entities = entities.OrderByDescending(Function(e) e.Oganisation.Nom)
                Case "TypeOffice"
                    entities = entities.OrderBy(Function(e) e.TypeOffice.Libelle)
                Case "TypeOffice_desc"
                    entities = entities.OrderByDescending(Function(e) e.TypeOffice.Libelle)
                Case Else
                    entities = entities.OrderBy(Function(e) e.Nom)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Bureau/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim Bureau As Bureau = Db.Bureau.Find(id)
        '    If IsNothing(Bureau) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(Bureau)
        'End Function

        Private Sub LoadComboBox(entityVM As BureauViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            Dim Organisation = (From e In Db.Organisation Where e.StatutExistant = 1 Select e)
            Dim LesOrganisations As New List(Of SelectListItem)
            Dim Commune = (From e In Db.Commune Where e.StatutExistant = 1 Select e)
            Dim LesCommunes As New List(Of SelectListItem)
            Dim TypeOffice = (From e In Db.TypeOffice Where e.StatutExistant = 1 Select e)
            Dim LesTypeOffices As New List(Of SelectListItem)

            Dim PersonnelBureau = (From e In Db.PersonnelBureau Where e.BureauId = entityVM.Id Select e).ToList
            Dim PersonnelBurea = (From e In Db.PersonnelBureau Where e.BureauId = entityVM.Id Select e.Personnel).ToList
            Dim PersonnelBureaux = (From e In Db.Personnel Where e.StatutExistant = 1 Select e)
            Dim LesPersonnelBureaux As New List(Of SelectListItem)

            Dim Materiels = (From e In Db.Materiel Where e.Cible = 6 Select e).ToList
            Dim MaterielBureau = (From e In Db.MaterielBureau Where e.StatutExistant = 1 Select e.Materiel).ToList
            Dim MaterielBureaux = (From e In Db.MaterielBureau Where e.StatutExistant = 1 Select e).ToList
            Dim LesMaterielBureau As New List(Of SelectListItem)

            For Each item In Materiels
                If Not MaterielBureau.Contains(item) Then
                    LesMaterielBureau.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
                End If
            Next

            For Each item In PersonnelBureaux
                If Not PersonnelBurea.Contains(item) Then
                    LesPersonnelBureaux.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
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

            For Each item In TypeOffice
                LesTypeOffices.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            entityVM.PersonnelBureaux = PersonnelBureau
            entityVM.LesPersonnelBureaux = LesPersonnelBureaux
            entityVM.LesUtilisateurs = LesUtilisateurs
            entityVM.LesTypeOffices = LesTypeOffices
            entityVM.LesCommunes = LesCommunes
            entityVM.LesMaterielBureaux = LesMaterielBureau
            entityVM.MaterielBureaux = MaterielBureaux
            entityVM.LesOrganisations = LesOrganisations
        End Sub

        ' GET: Bureau/Create
        Function Create() As ActionResult
            Dim entityVM As New BureauViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function


        <HttpPost()>
        Function Create(ByVal entityVM As BureauxJS) As ActionResult
            Dim Ent As New Bureau
            Ent = entityVM.GetEntity(GetCurrentUser.Id)

            If (IsNothing(Ent.Location)) Then
                ModelState.AddModelError("", "Veuillez remplir le champ location")
            End If
            ' DbGeography.FromText("POINT(-122.336106 47.605049)")
            If ModelState.IsValid Then
                Db.Bureau.Add(Ent)
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

        '' POST: Bureau/Create
        ''Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        ''plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        '<HttpPost()>
        '<ValidateAntiForgeryToken()>
        'Function Create(ByVal entityVM As BureauViewModel) As ActionResult
        '    entityVM.AspNetUserId = GetCurrentUser.Id
        '    If ModelState.IsValid Then

        '        Db.Bureau.Add(entityVM.GetEntity)
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

        ' GET: Bureau/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Bureau As Bureau = Db.Bureau.Find(id)
            If IsNothing(Bureau) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New BureauViewModel(Bureau)
            LoadComboBox(entityVM)
            ViewBag.Latitude = 0
            ViewBag.Longitude = 0
            If Not IsNothing(entityVM.Location) Then
                ViewBag.Latitude = entityVM.Location.YCoordinate.ToString().Replace(",", ".")
                ViewBag.Longitude = entityVM.Location.XCoordinate.ToString().Replace(",", ".")
            End If
            Return View(entityVM)
        End Function

        ' POST: Bureau/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As BureauViewModel) As ActionResult
            If Request.Form("AddPersonnel") IsNot Nothing Then
                Return AddPersonnel(entityVM)
            ElseIf Request.Form("AddMateriel") IsNot Nothing Then
                Return AddMateriel(entityVM)
            Else
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
            End If
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        <ValidateAntiForgeryToken()>
        <HttpPost>
        Public Function AddMateriel(ByVal entityVM As BureauViewModel) As ActionResult

            If IsNothing(entityVM.MaterielBureauId) Then
                ModelState.AddModelError("MaterielBureauId", Resource.MdlError_Fichier) 'Le champ {0} est obligatoire: veuillez le remplir.
            End If

            If ModelState.IsValid Then

                Dim MaterielBureau As New MaterielBureau()

                If entityVM.MaterielBureauId > 0 Then

                    MaterielBureau.MaterielId = entityVM.MaterielBureauId
                    MaterielBureau.Quantite = entityVM.Quantite
                    MaterielBureau.BureauId = entityVM.Id
                    MaterielBureau.AspNetUserId = GetCurrentUser.Id

                    Db.MaterielBureau.Add(MaterielBureau)
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
                Dim MaterielBureau = (From p In Db.MaterielBureau Where p.Id = id Select p).ToList.FirstOrDefault
                If MaterielBureau Is Nothing Then
                    Response.StatusCode = CType(HttpStatusCode.NotFound, Integer)
                    Return Json(New With {.Result = "Error"})
                End If

                Db.MaterielBureau.Remove(MaterielBureau)
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


        'POST: Heliport/EditBureaux/5
        <HttpPost()>
        Function EditBureaux(ByVal entityVM As BureauxJS) As ActionResult
            Dim Ent As New Bureau
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
        Public Function AddPersonnel(ByVal entityVM As BureauViewModel) As ActionResult

            If IsNothing(entityVM.PersonnelBureauxId) Then
                ModelState.AddModelError("PersonnelBureauxId", Resource.MdlError_Fichier) 'Le champ {0} est obligatoire: veuillez le remplir.
            End If

            If ModelState.IsValid Then

                Dim PersonnelBureau As New PersonnelBureau()

                If entityVM.PersonnelBureauxId > 0 Then

                    PersonnelBureau.PersonnelId = entityVM.PersonnelBureauxId
                    PersonnelBureau.BureauId = entityVM.Id
                    PersonnelBureau.AspNetUserId = GetCurrentUser.Id
                    PersonnelBureau.TitreDuPoste = entityVM.TitreDuPoste

                    Db.PersonnelBureau.Add(PersonnelBureau)
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

        ' GET: Bureau/Details/5
        Function Details(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Bureau As Bureau = Db.Bureau.Find(id)
            If IsNothing(Bureau) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New BureauViewModel(Bureau)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        <HttpPost>
        Public Function DeletePersonnel(id As String) As JsonResult
            If [String].IsNullOrEmpty(id) Then
                Response.StatusCode = CType(HttpStatusCode.BadRequest, Integer)
                Return Json(New With {.Result = "Error"})
            End If
            Try
                Dim PersonnelBureau = (From p In Db.PersonnelBureau Where p.Id = id Select p).ToList.FirstOrDefault
                If PersonnelBureau Is Nothing Then
                    Response.StatusCode = CType(HttpStatusCode.NotFound, Integer)
                    Return Json(New With {.Result = "Error"})
                End If

                Db.PersonnelBureau.Remove(PersonnelBureau)
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

        ' GET: Bureau/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Bureau As Bureau = Db.Bureau.Find(id)
            If IsNothing(Bureau) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New BureauViewModel(Bureau)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Bureau/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim Bureau As Bureau = Db.Bureau.Find(id)
            Db.Bureau.Remove(Bureau)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New BureauViewModel(Bureau))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class

    Public Class BureauxJS

        Public Property Id As Long
        Public Property Code As String
        Public Property Nom As String
        Public Property CommuneId As String
        Public Property OrganisationId As String
        Public Property TypeOfficeId As Long
        Public Property CodePostale As String
        Public Property Telephone2 As String
        Public Property Telephone As String
        Public Property Email As String
        Public Property Latitude As String
        Public Property Longitude As String

        Public Function GetEntity(Str As String) As Bureau
            Dim entity As New Bureau
            With entity
                .Id = Id
                .Nom = Nom
                .Code = Code
                .CodePostale = CodePostale
                .Telephone = Telephone
                .Telephone2 = Telephone2
                .CommuneId = CommuneId
                .Location = Util.CreatePoint(latitude:=Latitude, longitude:=Longitude)
                .Email = Email
                .OganisationId = OrganisationId
                .TypeOfficeId = TypeOfficeId
                .StatutExistant = 1
                .DateCreation = Now
                .AspNetUserId = Str
            End With
            Return entity
        End Function
    End Class
End Namespace
