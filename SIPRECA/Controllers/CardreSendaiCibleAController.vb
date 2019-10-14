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
    Public Class CardreSendaiCibleAController
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

        ' GET: CardreSendaiCibleA
        Function Index() As ActionResult
            Dim CardreSendaiCibleA = Db.CardreSendaiCibleA.Include(Function(c) c.AspNetUser).Include(Function(c) c.EvenementZone)
            Return View(CardreSendaiCibleA.ToList())
        End Function

        ' GET: CardreSendaiCibleA/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim cardreSendaiCibleA As CardreSendaiCibleA = Db.CardreSendaiCibleA.Find(id)
        '    If IsNothing(cardreSendaiCibleA) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(cardreSendaiCibleA)
        'End Function

        Private Sub LoadComboBox(entityVM As CardreSendaiCibleAViewModel)
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

        ' GET: CardreSendaiCibleA/Create
        'Function Create() As ActionResult
        '    Dim entityVM As New CardreSendaiCibleAViewModel()
        '    LoadComboBox(entityVM)
        '    Return View(entityVM)
        'End Function

        ' POST: CardreSendaiCibleA/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        '<HttpPost()>
        '<ValidateAntiForgeryToken()>
        'Function Create(entityVM As CardreSendaiCibleAViewModel) As ActionResult
        '    If ModelState.IsValid Then
        '        Db.CardreSendaiCibleA.Add(entityVM.GetEntity())
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

        ' GET: CardreSendaiCibleA/Edit/5
        Function Edit(ByVal EvenementZoneId As Long?) As ActionResult
            If IsNothing(EvenementZoneId) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cardreSendaiCibleA As CardreSendaiCibleA = (From e In Db.CardreSendaiCibleA Where e.EvenementZoneId = EvenementZoneId Select e).FirstOrDefault()
            If IsNothing(cardreSendaiCibleA) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New CardreSendaiCibleAViewModel(cardreSendaiCibleA)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: CardreSendaiCibleA/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(entityVM As CardreSendaiCibleAViewModel) As ActionResult
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

        ' GET: CardreSendaiCibleA/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cardreSendaiCibleA As CardreSendaiCibleA = Db.CardreSendaiCibleA.Find(id)
            If IsNothing(cardreSendaiCibleA) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New CardreSendaiCibleAViewModel(cardreSendaiCibleA)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: CardreSendaiCibleA/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim cardreSendaiCibleA As CardreSendaiCibleA = Db.CardreSendaiCibleA.Find(id)
            Db.CardreSendaiCibleA.Remove(cardreSendaiCibleA)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index", "EvenementZones")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New CardreSendaiCibleAViewModel(cardreSendaiCibleA))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
