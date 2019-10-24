Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports SIPRECA.My.Resources

Namespace Controllers
    Public Class CardreSendaiCibleCController
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

        ' GET: cardreSendaiCibleC
        Function Index() As ActionResult
            Dim cardreSendaiCibleC = Db.CardreSendaiCibleC.Include(Function(c) c.AspNetUser).Include(Function(c) c.EvenementZone)
            Return View(cardreSendaiCibleC.ToList())
        End Function

        ' GET: cardreSendaiCibleC/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim cardreSendaiCibleC As cardreSendaiCibleC = Db.cardreSendaiCibleC.Find(id)
        '    If IsNothing(cardreSendaiCibleC) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(cardreSendaiCibleC)
        'End Function

        Private Sub LoadComboBox(entityVM As CardreSendaiCibleCViewModel)
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

            Dim CibleCDesagregationAgricoles = (From e In Db.CibleCDesagregationAgricole Where e.StatutExistant = 1 And e.CardreSendaiCibleCId = entityVM.Id Select e).ToList
            Dim LesCibleCDesagregationAgricoles As New List(Of SelectListItem)
            For Each item In CibleCDesagregationAgricoles
                LesCibleCDesagregationAgricoles.Add(New SelectListItem With {.Value = item.Id, .Text = item.CardreSendaiCibleC.EvenementZone.Evenement.Libelle & " -- " & item.CardreSendaiCibleC.EvenementZone.ZoneARisque.Libelle})
            Next
            entityVM.LesCibleCDesagregationAgricoles = LesCibleCDesagregationAgricoles

            Dim CibleCDesagregationAgricole = (From o In Db.CibleCDesagregationAgricole Where o.CardreSendaiCibleCId = entityVM.Id Select o).ToList
            entityVM.CibleCDesagregationAgricole = CibleCDesagregationAgricole

            Dim LaDesagregationRecoltesAgricole = (From o In Db.CardreSendaiCibleC Where o.Id = entityVM.Id From a In o.CibleCDesagregationAgricole Select a.DesagregationRecoltesAgricole).ToList

            entityVM.DesagregationRecoltesAgricole = LaDesagregationRecoltesAgricole

            Dim DesagregationRecoltesAgricoles = (From e In Db.DesagregationRecoltesAgricole Where e.StatutExistant = 1 Select e).ToList
            Dim LesDesagregationRecoltesAgricoles As New List(Of SelectListItem)
            For Each item In DesagregationRecoltesAgricoles
                If Not LaDesagregationRecoltesAgricole.Contains(item) Then
                    LesDesagregationRecoltesAgricoles.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libellle})
                End If
            Next


            Dim CibleCPerteBetails = (From e In Db.CibleCPerteBetail Where e.StatutExistant = 1 And e.CardreSendaiCibleCId = entityVM.Id Select e).ToList
            Dim LesCibleCPerteBetail As New List(Of SelectListItem)
            For Each item In CibleCPerteBetails
                LesCibleCPerteBetail.Add(New SelectListItem With {.Value = item.Id, .Text = item.CardreSendaiCibleC.EvenementZone.Evenement.Libelle & " -- " & item.CardreSendaiCibleC.EvenementZone.ZoneARisque.Libelle})
            Next
            entityVM.LesCibleCPerteBetail = LesCibleCPerteBetail

            Dim CibleCPerteBetail = (From o In Db.CibleCPerteBetail Where o.CardreSendaiCibleCId = entityVM.Id Select o).ToList
            entityVM.CibleCPerteBetail = CibleCPerteBetail

            Dim LaPerteBetail = (From o In Db.CardreSendaiCibleC Where o.Id = entityVM.Id From a In o.CibleCPerteBetail Select a.PerteBetail).ToList

            entityVM.PerteBetail = LaPerteBetail

            Dim PerteBetails = (From e In Db.PerteBetail Where e.StatutExistant = 1 Select e).ToList
            Dim LesPerteBetails As New List(Of SelectListItem)
            For Each item In PerteBetails
                If Not LaPerteBetail.Contains(item) Then
                    LesPerteBetails.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
                End If
            Next

            entityVM.LesEvenementsZone = LesEvenementsZone
            entityVM.LesUtilisateurs = LesUtilisateurs
            entityVM.LesPerteBetails = LesPerteBetails
            entityVM.LesDesagregationRecoltesAgricoles = LesDesagregationRecoltesAgricoles
        End Sub

        ' GET: cardreSendaiCibleC/Create
        'Function Create() As ActionResult
        '    Dim entityVM As New cardreSendaiCibleCViewModel()
        '    LoadComboBox(entityVM)
        '    Return View(entityVM)
        'End Function

        ' POST: cardreSendaiCibleC/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        '<HttpPost()>
        '<ValidateAntiForgeryToken()>
        'Function Create(entityVM As cardreSendaiCibleCViewModel) As ActionResult
        '    If ModelState.IsValid Then
        '        Db.cardreSendaiCibleC.Add(entityVM.GetEntity())
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

        ' GET: cardreSendaiCibleC/Edit/5
        Function Edit(ByVal EvenementZoneId As Long?) As ActionResult
            If IsNothing(EvenementZoneId) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cardreSendaiCibleC As CardreSendaiCibleC = (From e In Db.CardreSendaiCibleC Where e.EvenementZoneId = EvenementZoneId Select e).FirstOrDefault()
            If IsNothing(cardreSendaiCibleC) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New CardreSendaiCibleCViewModel(cardreSendaiCibleC)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: cardreSendaiCibleC/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.

        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(entityVM As CardreSendaiCibleCViewModel) As ActionResult
            If Request.Form("AddDsagregationAgricole") IsNot Nothing Then
                Return AddDsagregationAgricole(entityVM)
            ElseIf Request.Form("AddDsagregationBetail") IsNot Nothing Then
                Return AddDsagregationBetail(entityVM)
            Else
                If ModelState.IsValid Then
                    Db.Entry(entityVM.GetEntity()).State = EntityState.Modified
                    Try
                        Db.SaveChanges()
                        Return RedirectToAction("Index", "EvenementZones")
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
        Public Function AddDsagregationAgricole(ByVal entityVM As CardreSendaiCibleCViewModel) As ActionResult

            Dim NombreHectarDetruit As Long = 0
            Dim NombreHectarEndomager As Long = 0
            Dim NombreHectarAfecter As Long = 0

            If (entityVM.NombreHectarAfecter.HasValue) Then
                NombreHectarAfecter = entityVM.NombreHectarAfecter.Value
            End If

            If (entityVM.NombreHectarDetruit.HasValue) Then
                NombreHectarDetruit = entityVM.NombreHectarDetruit.Value
            End If

            If (entityVM.NombreHectarEndomager.HasValue) Then
                NombreHectarEndomager = entityVM.NombreHectarEndomager.Value
            End If

            If NombreHectarAfecter <> (NombreHectarEndomager + NombreHectarDetruit) Then
                ModelState.AddModelError("NombreHectarAfecter", Resource.SommeError) 'Le champ {0} est obligatoire: veuillez le remplir.
            End If

            If ModelState.IsValid Then

                Dim CibleCDesagregationAgricole As New CibleCDesagregationAgricole()

                If entityVM.DesagregationRecoltesAgricoleId > 0 Then

                    CibleCDesagregationAgricole.DesagregationRecoltesAgricoleId = entityVM.DesagregationRecoltesAgricoleId
                    CibleCDesagregationAgricole.CardreSendaiCibleCId = entityVM.Id
                    CibleCDesagregationAgricole.AspNetUserId = GetCurrentUser.Id
                    CibleCDesagregationAgricole.PerteEconomique = entityVM.PerteEconomique
                    CibleCDesagregationAgricole.NombreHectarAfecter = entityVM.NombreHectarAfecter
                    CibleCDesagregationAgricole.NombreHectarEndomager = entityVM.NombreHectarEndomager
                    CibleCDesagregationAgricole.NombreHectarDetruit = entityVM.NombreHectarDetruit

                    Db.CibleCDesagregationAgricole.Add(CibleCDesagregationAgricole)
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

        <ValidateAntiForgeryToken()>
        <HttpPost>
        Public Function AddDsagregationBetail(ByVal entityVM As CardreSendaiCibleCViewModel) As ActionResult
            Dim NombreDetruitDetruit As Long = 0
            Dim NombreTotalEndomager As Long = 0
            Dim NombreTotalAfecter As Long = 0

            If (entityVM.NombreTotalAfecter.HasValue) Then
                NombreTotalAfecter = entityVM.NombreTotalAfecter.Value
            End If

            If (entityVM.NombreDetruitDetruit.HasValue) Then
                NombreDetruitDetruit = entityVM.NombreDetruitDetruit.Value
            End If

            If (entityVM.NombreTotalEndomager.HasValue) Then
                NombreTotalEndomager = entityVM.NombreTotalEndomager.Value
            End If

            If NombreTotalAfecter <> (NombreTotalEndomager + NombreDetruitDetruit) Then
                ModelState.AddModelError("NombreTotalAfecter", Resource.SommeError) 'Le champ {0} est obligatoire: veuillez le remplir.
            End If

            If ModelState.IsValid Then

                Dim CibleCPerteBetail As New CibleCPerteBetail()

                If entityVM.PerteBetailId > 0 Then

                    CibleCPerteBetail.PerteBetailId = entityVM.PerteBetailId
                    CibleCPerteBetail.CardreSendaiCibleCId = entityVM.Id
                    CibleCPerteBetail.PerteEconomique = entityVM.PerteEconomiqueBetail
                    CibleCPerteBetail.AspNetUserId = GetCurrentUser.Id
                    CibleCPerteBetail.NombreTotalAfecter = entityVM.NombreTotalAfecter
                    CibleCPerteBetail.NombreTotalEndomager = entityVM.NombreTotalEndomager
                    CibleCPerteBetail.NombreDetruitDetruit = entityVM.NombreDetruitDetruit

                    Db.CibleCPerteBetail.Add(CibleCPerteBetail)
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
        Public Function DeleteDsagregationAgricole(id As String) As JsonResult
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

        <HttpPost>
        Public Function DeleteDsagregationBetail(id As String) As JsonResult
            If [String].IsNullOrEmpty(id) Then
                Response.StatusCode = CType(HttpStatusCode.BadRequest, Integer)
                Return Json(New With {.Result = "Error"})
            End If
            Try
                Dim CibleCPerteBetail = (From p In Db.CibleCPerteBetail Where p.Id = id Select p).ToList.FirstOrDefault
                If CibleCPerteBetail Is Nothing Then
                    Response.StatusCode = CType(HttpStatusCode.NotFound, Integer)
                    Return Json(New With {.Result = "Error"})
                End If

                Db.CibleCPerteBetail.Remove(CibleCPerteBetail)
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

        ' GET: cardreSendaiCibleC/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cardreSendaiCibleC As CardreSendaiCibleC = Db.CardreSendaiCibleC.Find(id)
            If IsNothing(cardreSendaiCibleC) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New CardreSendaiCibleCViewModel(cardreSendaiCibleC)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: cardreSendaiCibleC/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim cardreSendaiCibleC As CardreSendaiCibleC = Db.CardreSendaiCibleC.Find(id)
            Db.CardreSendaiCibleC.Remove(cardreSendaiCibleC)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index", "EvenementZones")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New CardreSendaiCibleCViewModel(cardreSendaiCibleC))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
