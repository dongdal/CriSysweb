Imports System.Data.Entity
Imports System.Data.Entity.Spatial
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList

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
            ViewBag.VilleSort = If(sortOrder = "Ville", "Ville_desc", "Ville")
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
                Case "Ville"
                    entities = entities.OrderBy(Function(e) e.Ville.Libelle)
                Case "Ville_desc"
                    entities = entities.OrderByDescending(Function(e) e.Ville.Libelle)
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
            Dim Ville = (From e In Db.Ville Where e.StatutExistant = 1 Select e)
            Dim LesVilles As New List(Of SelectListItem)
            Dim TypeOffice = (From e In Db.TypeOffice Where e.StatutExistant = 1 Select e)
            Dim LesTypeOffices As New List(Of SelectListItem)

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

            For Each item In TypeOffice
                LesTypeOffices.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            entityVM.LesUtilisateurs = LesUtilisateurs
            entityVM.LesTypeOffices = LesTypeOffices
            entityVM.LesVilles = LesVilles
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
            Return View(entityVM)
        End Function

        ' POST: Bureau/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As BureauViewModel) As ActionResult
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

        Public Property Code As String
        Public Property Nom As String
        Public Property VilleId As String
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
                .Id = 0
                .Nom = Nom
                .Code = Code
                .CodePostale = CodePostale
                .Telephone = Telephone
                .Telephone2 = Telephone2
                .VilleId = VilleId
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
