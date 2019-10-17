Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports SIPRECA

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
            entityVM.LesEvenementsZone = LesEvenementsZone
            entityVM.LesUtilisateurs = LesUtilisateurs
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
            LoadComboBox(entityVM)
            Return View(entityVM)
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
