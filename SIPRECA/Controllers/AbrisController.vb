Imports System.Data.Entity
Imports System.Data.Entity.Spatial
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources

Namespace Controllers
    Public Class AbrisController
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

        ' GET: Abris
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.NomSort = If(sortOrder = "Nom", "Nom_desc", "Nom")
            ViewBag.EstimationPopulationSort = If(sortOrder = "EstimationPopulation", "EstimationPopulation_desc", "EstimationPopulation")
            ViewBag.CapaciteSort = If(sortOrder = "Capacite", "Capacite_desc", "Capacite")
            ViewBag.VilleSort = If(sortOrder = "Ville", "Ville_desc", "Ville")
            ViewBag.OrganisationSort = If(sortOrder = "Organisation", "Organisation_desc", "Organisation")
            ViewBag.TypeAbrisSort = If(sortOrder = "TypeAbris", "TypeAbris_desc", "TypeAbris")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.Abris Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.EstimationPopulation.Equals(searchString) Or
                                              e.Capacite.Equals(searchString) Or
                                              e.Oganisation.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.TypeAbris.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Ville.Libelle.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Nom"
                    entities = entities.OrderBy(Function(e) e.Nom)
                Case "Nom_desc"
                    entities = entities.OrderByDescending(Function(e) e.Nom)
                Case "EstimationPopulation"
                    entities = entities.OrderBy(Function(e) e.EstimationPopulation)
                Case "EstimationPopulation_desc"
                    entities = entities.OrderByDescending(Function(e) e.EstimationPopulation)
                Case "Capacite"
                    entities = entities.OrderBy(Function(e) e.Capacite)
                Case "Capacite_desc"
                    entities = entities.OrderByDescending(Function(e) e.Capacite)
                Case "Oganisation"
                    entities = entities.OrderBy(Function(e) e.Oganisation.Nom)
                Case "Oganisation_desc"
                    entities = entities.OrderByDescending(Function(e) e.Oganisation.Nom)
                Case "Ville"
                    entities = entities.OrderBy(Function(e) e.Ville.Libelle)
                Case "Ville_desc"
                    entities = entities.OrderByDescending(Function(e) e.Ville.Libelle)
                Case "TypeAbris"
                    entities = entities.OrderBy(Function(e) e.TypeAbris.Libelle)
                Case "TypeAbris_desc"
                    entities = entities.OrderByDescending(Function(e) e.TypeAbris.Libelle)

                Case Else
                    entities = entities.OrderBy(Function(e) e.Nom)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Abris/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim Abris As Abris = Db.Abris.Find(id)
        '    If IsNothing(Abris) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(Abris)
        'End Function

        Private Sub LoadComboBox(entityVM As AbrisViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            Dim Organisation = (From e In Db.Organisation Where e.StatutExistant = 1 Select e)
            Dim LesOrganisations As New List(Of SelectListItem)
            Dim Ville = (From e In Db.Ville Where e.StatutExistant = 1 Select e)
            Dim LesVilles As New List(Of SelectListItem)
            Dim TypeAbris = (From e In Db.TypeAbris Where e.StatutExistant = 1 Select e)
            Dim LesTypeAbris As New List(Of SelectListItem)

            Dim PersonnelAbri = (From e In Db.PersonnelAbris Where e.AbrisId = entityVM.Id Select e).ToList
            Dim PersonnelAbris = (From e In Db.Personnel Where e.StatutExistant = 1 Select e)
            Dim LesPersonnelAbris As New List(Of SelectListItem)

            For Each item In PersonnelAbris

                Dim re As Boolean = True

                For Each item2 In PersonnelAbri
                    If item.Id = item2.PersonnelId Then
                        re = False
                    End If
                Next

                If re = True Then
                    LesPersonnelAbris.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
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

            For Each item In TypeAbris
                LesTypeAbris.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            entityVM.PersonnelAbris = PersonnelAbri
            entityVM.LesPersonnelAbris = LesPersonnelAbris
            entityVM.LesUtilisateurs = LesUtilisateurs
            entityVM.LesTypeAbris = LesTypeAbris
            entityVM.LesVilles = LesVilles
            entityVM.LesOrganisations = LesOrganisations
        End Sub

        ' GET: Abris/Create
        Function Create() As ActionResult
            Dim entityVM As New AbrisViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function


        <HttpPost()>
        Function Create(ByVal entityVM As AbrisJS) As ActionResult
            Dim Ent As New Abris
            Ent = entityVM.GetEntity(GetCurrentUser.Id)

            If (IsNothing(Ent.Location)) Then
                ModelState.AddModelError("", "Veuillez remplir le champ location")
            End If
            ' DbGeography.FromText("POINT(-122.336106 47.605049)")
            If ModelState.IsValid Then
                Db.Abris.Add(Ent)
                Try
                    Db.SaveChanges()
                    Return Json(New With {.Result = "OK"})
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try
            End If
            Return Json(New With {.Result = "Error"})
        End Function

        '' POST: Abris/Create
        ''Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        ''plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        '<HttpPost()>
        '<ValidateAntiForgeryToken()>
        'Function Create(ByVal entityVM As AbrisViewModel) As ActionResult
        '    entityVM.AspNetUserId = GetCurrentUser.Id
        '    If ModelState.IsValid Then

        '        Db.Abris.Add(entityVM.GetEntity)
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

        ' GET: Abris/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Abris As Abris = Db.Abris.Find(id)
            If IsNothing(Abris) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New AbrisViewModel(Abris)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Abris/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As AbrisViewModel) As ActionResult
            If Request.Form("AddPersonnel") IsNot Nothing Then
                Return AddPersonnel(entityVM)
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
        Public Function AddPersonnel(ByVal entityVM As AbrisViewModel) As ActionResult

            If IsNothing(entityVM.PersonnelAbrisId) Then
                ModelState.AddModelError("Personnel", Resource.MdlError_Fichier) 'Le champ {0} est obligatoire: veuillez le remplir.
            End If

            If ModelState.IsValid Then

                Dim PersonnelAbris As New PersonnelAbris()

                If entityVM.PersonnelAbrisId > 0 Then

                    PersonnelAbris.PersonnelId = entityVM.PersonnelAbrisId
                    PersonnelAbris.AbrisId = entityVM.Id
                    PersonnelAbris.AspNetUserId = GetCurrentUser.Id
                    PersonnelAbris.TitreDuPoste = entityVM.TitreDuPoste

                    Db.PersonnelAbris.Add(PersonnelAbris)
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
        Public Function DeletePersonnel(id As String) As JsonResult
            If [String].IsNullOrEmpty(id) Then
                Response.StatusCode = CType(HttpStatusCode.BadRequest, Integer)
                Return Json(New With {.Result = "Error"})
            End If
            Try
                Dim PersonnelAbris = (From p In Db.PersonnelAbris Where p.Id = id Select p).ToList.FirstOrDefault
                If PersonnelAbris Is Nothing Then
                    Response.StatusCode = CType(HttpStatusCode.NotFound, Integer)
                    Return Json(New With {.Result = "Error"})
                End If

                Db.PersonnelAbris.Remove(PersonnelAbris)
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

        ' GET: Abris/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Abris As Abris = Db.Abris.Find(id)
            If IsNothing(Abris) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New AbrisViewModel(Abris)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Abris/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim Abris As Abris = Db.Abris.Find(id)
            Db.Abris.Remove(Abris)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New AbrisViewModel(Abris))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class

    Public Class AbrisJS

        Public Property Nom As String
        Public Property VilleId As String
        Public Property OrganisationId As String
        Public Property TypeAbrisId As Long
        Public Property EstimationPopulation As Long
        Public Property Capacite As Long
        Public Property Latitude As String
        Public Property Longitude As String

        Public Function GetEntity(Str As String) As Abris
            Dim entity As New Abris
            With entity
                .Id = 0
                .Nom = Nom
                .EstimationPopulation = EstimationPopulation
                .Capacite = Capacite
                .VilleId = VilleId
                .TypeAbrisId = TypeAbrisId
                .Location = Util.CreatePoint(latitude:=Latitude, longitude:=Longitude)
                .OganisationId = OrganisationId
                .StatutExistant = 1
                .DateCreation = Now
                .AspNetUserId = Str
            End With
            Return entity
        End Function
    End Class
End Namespace
