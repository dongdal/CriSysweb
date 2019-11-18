Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources

Namespace Controllers
    Public Class ZoneARisquesController
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

        ' GET: ZoneARisque
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.LibelleSort = If(sortOrder = "Libelle", "Libelle_desc", "Libelle")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.ZoneARisque Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Libelle.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Libelle"
                    entities = entities.OrderBy(Function(e) e.Libelle)
                Case "Libelle_desc"
                    entities = entities.OrderByDescending(Function(e) e.Libelle)

                Case Else
                    entities = entities.OrderBy(Function(e) e.Libelle)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: ZoneARisque/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim ZoneARisque As ZoneARisque = Db.ZoneARisque.Find(id)
        '    If IsNothing(ZoneARisque) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(ZoneARisque)
        'End Function

        Private Sub LoadComboBox(entityVM As ZoneARisqueViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)

            Dim Risqus = (From e In Db.RisqueZone Where e.ZoneARisqueId = entityVM.Id Select e.Risque).ToList
            Dim RisqueZones = (From e In Db.RisqueZone Where e.ZoneARisqueId = entityVM.Id Select e).ToList
            Dim Risques = (From e In Db.Risque Where e.StatutExistant = 1 Select e)
            Dim LesRisques As New List(Of SelectListItem)

            For Each item In Risques
                If Not Risqus.Contains(item) Then
                    LesRisques.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
                End If
            Next

            Dim NiveauDAlets = (From e In Db.RisqueZone Where e.ZoneARisqueId = entityVM.Id Select e.NiveauDAlert).ToList
            Dim NiveauDAlerts = (From e In Db.NiveauDAlert Where e.StatutExistant = 1 Select e)
            Dim LesNiveauDAlerts As New List(Of SelectListItem)

            For Each item In NiveauDAlerts
                If Not NiveauDAlets.Contains(item) Then
                    LesNiveauDAlerts.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
                End If
            Next

            Dim Quartirs = (From e In Db.ZoneLocalisation Where e.ZoneARisqueId = entityVM.Id Select e.Quartier).ToList
            Dim ZoneLocalisations = (From e In Db.ZoneLocalisation Where e.ZoneARisqueId = entityVM.Id Select e).ToList
            Dim Quartiers = (From e In Db.Quartier Where e.StatutExistant = 1 Select e)
            Dim LesQuartiers As New List(Of SelectListItem)

            For Each item In Quartiers
                If Not Quartirs.Contains(item) Then
                    LesQuartiers.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
                End If
            Next


            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            entityVM.ZoneLocalisations = ZoneLocalisations
            entityVM.RisqueZones = RisqueZones
            entityVM.LesNiveauDAlerts = LesNiveauDAlerts
            entityVM.LesRisques = LesRisques
            entityVM.LesQuartiers = LesQuartiers
            entityVM.LesUtilisateurs = LesUtilisateurs
        End Sub

        ' GET: ZoneARisque/Create
        Function Create() As ActionResult
            Dim entityVM As New ZoneARisqueViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: ZoneARisque/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        Function Create(ByVal entityVM As ZoneARisqueJS) As ActionResult
            Dim Ent As New ZoneARisque
            Ent = entityVM.GetEntity(GetCurrentUser.Id)

            If (IsNothing(Ent.Location)) Then
                ModelState.AddModelError("", "Veuillez remplir le champ location")
            End If
            ' DbGeography.FromText("POINT(-122.336106 47.605049)")
            If ModelState.IsValid Then
                Db.ZoneARisque.Add(Ent)
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

        ' GET: ZoneARisque/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ZoneARisque As ZoneARisque = Db.ZoneARisque.Find(id)
            If IsNothing(ZoneARisque) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New ZoneARisqueViewModel(ZoneARisque)
            LoadComboBox(entityVM)
            ViewBag.Latitude = 0
            ViewBag.Longitude = 0
            If Not IsNothing(entityVM.Location) Then
                ViewBag.Latitude = entityVM.Location.YCoordinate.ToString().Replace(",", ".")
                ViewBag.Longitude = entityVM.Location.XCoordinate.ToString().Replace(",", ".")
            End If
            Return View(entityVM)
        End Function

        ' POST: ZoneARisque/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As ZoneARisqueViewModel) As ActionResult
            If Request.Form("AddQuartier") IsNot Nothing Then
                Return AddQuartier(entityVM)
            ElseIf Request.Form("AddRisqueZone") IsNot Nothing Then
                Return AddRisqueZone(entityVM)
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

        <HttpPost()>
        Function EditZoneARisque(ByVal entityVM As ZoneARisqueJS) As ActionResult
            Dim Ent As New ZoneARisque
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
        Public Function AddQuartier(ByVal entityVM As ZoneARisqueViewModel) As ActionResult

            If IsNothing(entityVM.QuartierId) Then
                ModelState.AddModelError("QuartierId", Resource.MdlError_Fichier) 'Le champ {0} est obligatoire: veuillez le remplir.
            End If

            If ModelState.IsValid Then

                Dim ZoneLocalisation As New ZoneLocalisation()

                If entityVM.QuartierId > 0 Then

                    ZoneLocalisation.QuartierId = entityVM.QuartierId
                    ZoneLocalisation.ZoneARisqueId = entityVM.Id
                    ZoneLocalisation.AspNetUserId = GetCurrentUser.Id

                    Db.ZoneLocalisation.Add(ZoneLocalisation)
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
        Public Function DeleteQuartier(id As String) As JsonResult
            If [String].IsNullOrEmpty(id) Then
                Response.StatusCode = CType(HttpStatusCode.BadRequest, Integer)
                Return Json(New With {.Result = "Error"})
            End If
            Try
                Dim ZoneLocalisation = (From p In Db.ZoneLocalisation Where p.Id = id Select p).ToList.FirstOrDefault
                If ZoneLocalisation Is Nothing Then
                    Response.StatusCode = CType(HttpStatusCode.NotFound, Integer)
                    Return Json(New With {.Result = "Error"})
                End If

                Db.ZoneLocalisation.Remove(ZoneLocalisation)
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

        <ValidateAntiForgeryToken()>
        <HttpPost>
        Public Function AddRisqueZone(ByVal entityVM As ZoneARisqueViewModel) As ActionResult

            If IsNothing(entityVM.RisqueId) Then
                ModelState.AddModelError("RisqueId", Resource.MdlError_Fichier) 'Le champ {0} est obligatoire: veuillez le remplir.
            ElseIf IsNothing(entityVM.NiveauDAlertId) Then
                ModelState.AddModelError("NiveauDAlertId", Resource.MdlError_Fichier) 'Le champ {0} est obligatoire: veuillez le remplir.
            End If

            If ModelState.IsValid Then

                Dim RisqueZone As New RisqueZone()

                If entityVM.RisqueId > 0 And entityVM.NiveauDAlertId > 0 Then

                    RisqueZone.RisqueId = entityVM.RisqueId
                    RisqueZone.NiveauDAlertId = entityVM.NiveauDAlertId
                    RisqueZone.ZoneARisqueId = entityVM.Id
                    RisqueZone.AspNetUserId = GetCurrentUser.Id

                    Db.RisqueZone.Add(RisqueZone)
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
        Public Function DeleteRisqueZone(id As String) As JsonResult
            If [String].IsNullOrEmpty(id) Then
                Response.StatusCode = CType(HttpStatusCode.BadRequest, Integer)
                Return Json(New With {.Result = "Error"})
            End If
            Try
                Dim RisqueZone = (From p In Db.RisqueZone Where p.Id = id Select p).ToList.FirstOrDefault
                If RisqueZone Is Nothing Then
                    Response.StatusCode = CType(HttpStatusCode.NotFound, Integer)
                    Return Json(New With {.Result = "Error"})
                End If

                Db.RisqueZone.Remove(RisqueZone)
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

        ' GET: ZoneARisque/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ZoneARisque As ZoneARisque = Db.ZoneARisque.Find(id)
            If IsNothing(ZoneARisque) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New ZoneARisqueViewModel(ZoneARisque)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: ZoneARisque/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim ZoneARisque As ZoneARisque = Db.ZoneARisque.Find(id)
            Db.ZoneARisque.Remove(ZoneARisque)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New ZoneARisqueViewModel(ZoneARisque))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class

    Public Class ZoneARisqueJS
        Public Property Id As Long
        Public Property Libelle As String
        Public Property Latitude As String
        Public Property Longitude As String

        Public Function GetEntity(Str As String) As ZoneARisque
            Dim entity As New ZoneARisque
            With entity
                .Id = Id
                .Libelle = Libelle
                .Location = Util.CreatePoint(latitude:=Latitude, longitude:=Longitude)
                .StatutExistant = 1
                .DateCreation = Now
                .AspNetUserId = Str
            End With
            Return entity
        End Function
    End Class
End Namespace
