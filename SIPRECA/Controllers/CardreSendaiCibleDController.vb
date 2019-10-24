Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports SIPRECA.My.Resources

Namespace Controllers
    Public Class CardreSendaiCibleDController
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

        ' GET: CardreSendaiCibleD
        Function Index() As ActionResult
            Dim CardreSendaiCibleD = Db.CardreSendaiCibleD.Include(Function(c) c.AspNetUser).Include(Function(c) c.EvenementZone)
            Return View(CardreSendaiCibleD.ToList())
        End Function

        ' GET: CardreSendaiCibleD/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim CardreSendaiCibleD As CardreSendaiCibleD = Db.CardreSendaiCibleD.Find(id)
        '    If IsNothing(CardreSendaiCibleD) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(CardreSendaiCibleD)
        'End Function

        Private Sub LoadComboBox(entityVM As CardreSendaiCibleDViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            Dim EvenementZone = Db.EvenementZone.Include(Function(c) c.AspNetUser).Include(Function(c) c.Evenement).Where(Function(e) e.Id = entityVM.EvenementZoneId And e.StatutExistant = 1).ToList()
            Dim LesEvenementsZone As New List(Of SelectListItem)
            For Each item In EvenementZone
                LesEvenementsZone.Add(New SelectListItem With {.Value = item.Id, .Text = item.Evenement.Libelle & " | " & item.ZoneARisque.Libelle})
            Next

            Dim CibleDServicesPubliques = (From e In Db.CibleDServicesPublique Where e.StatutExistant = 1 And e.CardreSendaiCibleDId = entityVM.Id Select e).ToList
            Dim LesCibleDServicesPublique As New List(Of SelectListItem)
            For Each item In CibleDServicesPubliques
                LesCibleDServicesPublique.Add(New SelectListItem With {.Value = item.Id, .Text = item.CardreSendaiCibleD.EvenementZone.Evenement.Libelle & " -- " & item.CardreSendaiCibleD.EvenementZone.ZoneARisque.Libelle})
            Next
            entityVM.LesCibleDServicesPublique = LesCibleDServicesPublique

            Dim CibleDServicesPublique = (From o In Db.CibleDServicesPublique Where o.CardreSendaiCibleDId = entityVM.Id Select o).ToList
            entityVM.CibleDServicesPublique = CibleDServicesPublique

            Dim LaCibleDServicesPublique = (From o In Db.CardreSendaiCibleD Where o.Id = entityVM.Id From a In o.CibleDServicesPublique Select a.ServicesPubliquePertube).ToList

            entityVM.ServicesPubliquePertube = LaCibleDServicesPublique

            Dim ServicesPubliquePertubes = (From e In Db.ServicesPubliquePertube Where e.StatutExistant = 1 Select e).ToList
            Dim LesServicesPubliques As New List(Of SelectListItem)
            For Each item In ServicesPubliquePertubes
                If Not LaCibleDServicesPublique.Contains(item) Then
                    LesServicesPubliques.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
                End If
            Next

            entityVM.LesEvenementsZone = LesEvenementsZone
            entityVM.LesUtilisateurs = LesUtilisateurs
            entityVM.LesServicesPubliques = LesServicesPubliques
        End Sub

        ' GET: CardreSendaiCibleD/Create
        'Function Create() As ActionResult
        '    Dim entityVM As New CardreSendaiCibleDViewModel()
        '    LoadComboBox(entityVM)
        '    Return View(entityVM)
        'End Function

        ' POST: CardreSendaiCibleD/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        '<HttpPost()>
        '<ValidateAntiForgeryToken()>
        'Function Create(entityVM As CardreSendaiCibleDViewModel) As ActionResult
        '    If ModelState.IsValid Then
        '        Db.CardreSendaiCibleD.Add(entityVM.GetEntity())
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

        ' GET: CardreSendaiCibleD/Edit/5
        Function Edit(ByVal EvenementZoneId As Long?) As ActionResult
            If IsNothing(EvenementZoneId) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim CardreSendaiCibleD As CardreSendaiCibleD = (From e In Db.CardreSendaiCibleD Where e.EvenementZoneId = EvenementZoneId Select e).FirstOrDefault()
            If IsNothing(CardreSendaiCibleD) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New CardreSendaiCibleDViewModel(CardreSendaiCibleD)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: CardreSendaiCibleD/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.

        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(entityVM As CardreSendaiCibleDViewModel) As ActionResult
            If Request.Form("AddServicesPubliques") IsNot Nothing Then
                Return AddServicesPubliques(entityVM)
            Else
                If ModelState.IsValid Then
                    Db.Entry(entityVM.GetEntity()).State = EntityState.Modified
                    Try
                        Db.SaveChanges()
                        Return RedirectToAction("Edit", New With {.EvenementZoneId = entityVM.EvenementZoneId})
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
        Public Function AddServicesPubliques(ByVal entityVM As CardreSendaiCibleDViewModel) As ActionResult

            If IsNothing(entityVM.ServicesPubliqueId) Then
                ModelState.AddModelError("ServicesPubliqueId", Resource.MdlError_Fichier) 'Le champ {0} est obligatoire: veuillez le remplir.
            End If

            If ModelState.IsValid Then

                Dim CibleDServicesPublique As New CibleDServicesPublique()

                If entityVM.ServicesPubliqueId > 0 Then

                    CibleDServicesPublique.ServicesPubliquePertubeId = entityVM.ServicesPubliqueId
                    CibleDServicesPublique.CardreSendaiCibleDId = entityVM.Id
                    CibleDServicesPublique.AspNetUserId = GetCurrentUser.Id


                    Db.CibleDServicesPublique.Add(CibleDServicesPublique)
                    Try
                        Db.SaveChanges()
                    Catch ex As DbEntityValidationException
                        Util.GetError(ex, ModelState)
                    Catch ex As Exception
                        Util.GetError(ex, ModelState)
                    End Try

                End If
                Return RedirectToAction("Edit", New With {.EvenementZoneId = entityVM.EvenementZoneId})
            End If
            LoadComboBox(entityVM)
            Return View("Edit", entityVM)
        End Function


        <HttpPost>
        Public Function DeleteServicesPublique(id As String) As JsonResult
            If [String].IsNullOrEmpty(id) Then
                Response.StatusCode = CType(HttpStatusCode.BadRequest, Integer)
                Return Json(New With {.Result = "Error"})
            End If
            Try
                Dim CibleCDesagregationAgricole = (From p In Db.CibleCDesagregationAgricole Where p.Id = id Select p).ToList.FirstOrDefault
                If CibleCDesagregationAgricole Is Nothing Then
                    Response.StatusCode = CType(HttpStatusCode.NotFound, Integer)
                    Return Json(New With {.Result = "Error"})
                End If

                Db.CibleCDesagregationAgricole.Remove(CibleCDesagregationAgricole)
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


        ' GET: CardreSendaiCibleD/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim CardreSendaiCibleD As CardreSendaiCibleD = Db.CardreSendaiCibleD.Find(id)
            If IsNothing(CardreSendaiCibleD) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New CardreSendaiCibleDViewModel(CardreSendaiCibleD)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: CardreSendaiCibleD/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim CardreSendaiCibleD As CardreSendaiCibleD = Db.CardreSendaiCibleD.Find(id)
            Db.CardreSendaiCibleD.Remove(CardreSendaiCibleD)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index", "EvenementZones")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New CardreSendaiCibleDViewModel(CardreSendaiCibleD))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
