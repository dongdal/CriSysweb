Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList

Namespace Controllers
    Public Class RisqueZonesController
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

        ' GET: RisqueZone
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.RisqueSort = If(sortOrder = "Risque", "Risque_desc", "Risque")
            ViewBag.NiveauDAlertSort = If(sortOrder = "NiveauDAlert", "NiveauDAlert_desc", "NiveauDAlert")
            ViewBag.ZoneARisqueSort = If(sortOrder = "ZoneARisque", "ZoneARisque_desc", "ZoneARisque")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.RisqueZone Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Risque.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.NiveauDAlert.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.ZoneARisque.Libelle.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Risque"
                    entities = entities.OrderBy(Function(e) e.Risque.Libelle)
                Case "Risque_desc"
                    entities = entities.OrderByDescending(Function(e) e.Risque.Libelle)
                Case "NiveauDAlert"
                    entities = entities.OrderBy(Function(e) e.NiveauDAlert.Libelle)
                Case "NiveauDAlert_desc"
                    entities = entities.OrderByDescending(Function(e) e.NiveauDAlert.Libelle)
                Case "ZoneARisque"
                    entities = entities.OrderBy(Function(e) e.ZoneARisque.Libelle)
                Case "ZoneARisque_desc"
                    entities = entities.OrderByDescending(Function(e) e.ZoneARisque.Libelle)
                Case Else
                    entities = entities.OrderBy(Function(e) e.Risque.Libelle)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: RisqueZone/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim RisqueZone As RisqueZone = Db.RisqueZone.Find(id)
        '    If IsNothing(RisqueZone) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(RisqueZone)
        'End Function

        Private Sub LoadComboBox(entityVM As RisqueZoneViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)

            Dim Risques = (From e In Db.Risque Where e.StatutExistant = 1 Select e)
            Dim LesRisques As New List(Of SelectListItem)

            Dim NiveauDAlerts = (From e In Db.NiveauDAlert Where e.StatutExistant = 1 Select e)
            Dim LesNiveauDAlerts As New List(Of SelectListItem)

            Dim ZoneARisques = (From e In Db.ZoneARisque Where e.StatutExistant = 1 Select e)
            Dim LesZoneARisques As New List(Of SelectListItem)

            For Each item In Risques
                LesRisques.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In NiveauDAlerts
                LesNiveauDAlerts.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In ZoneARisques
                LesZoneARisques.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            entityVM.LesUtilisateurs = LesUtilisateurs
            entityVM.LesNiveauDAlerts = LesNiveauDAlerts
            entityVM.LesRisques = LesRisques
            entityVM.LesZoneARisques = LesZoneARisques
        End Sub

        ' GET: RisqueZone/Create
        Function Create() As ActionResult
            Dim entityVM As New RisqueZoneViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: RisqueZone/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As RisqueZoneViewModel) As ActionResult
            entityVM.AspNetUserId = GetCurrentUser.Id
            If ModelState.IsValid Then
                Db.RisqueZone.Add(entityVM.GetEntity)
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

        ' GET: RisqueZone/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim RisqueZone As RisqueZone = Db.RisqueZone.Find(id)
            If IsNothing(RisqueZone) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New RisqueZoneViewModel(RisqueZone)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: RisqueZone/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As RisqueZoneViewModel) As ActionResult
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

        ' GET: RisqueZone/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim RisqueZone As RisqueZone = Db.RisqueZone.Find(id)
            If IsNothing(RisqueZone) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New RisqueZoneViewModel(RisqueZone)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: RisqueZone/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim RisqueZone As RisqueZone = Db.RisqueZone.Find(id)
            Db.RisqueZone.Remove(RisqueZone)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New RisqueZoneViewModel(RisqueZone))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
