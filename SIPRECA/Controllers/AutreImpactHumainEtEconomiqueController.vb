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
    Public Class AutreImpactHumainEtEconomiqueController
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

        ' GET: AutreImpactHumainEtEconomique
        Function Index() As ActionResult
            Dim AutreImpactHumainEtEconomique = Db.AutreImpactHumainEtEconomique.Include(Function(c) c.AspNetUser).Include(Function(c) c.EvenementZone)
            Return View(AutreImpactHumainEtEconomique.ToList())
        End Function

        ' GET: AutreImpactHumainEtEconomique/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim AutreImpactHumainEtEconomique As AutreImpactHumainEtEconomique = Db.AutreImpactHumainEtEconomique.Find(id)
        '    If IsNothing(AutreImpactHumainEtEconomique) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(AutreImpactHumainEtEconomique)
        'End Function

        Private Sub LoadComboBox(entityVM As AutreImpactHumainEtEconomiqueViewModel)
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

        ' GET: AutreImpactHumainEtEconomique/Create
        'Function Create() As ActionResult
        '    Dim entityVM As New AutreImpactHumainEtEconomiqueViewModel()
        '    LoadComboBox(entityVM)
        '    Return View(entityVM)
        'End Function

        ' POST: AutreImpactHumainEtEconomique/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        '<HttpPost()>
        '<ValidateAntiForgeryToken()>
        'Function Create(entityVM As AutreImpactHumainEtEconomiqueViewModel) As ActionResult
        '    If ModelState.IsValid Then
        '        Db.AutreImpactHumainEtEconomique.Add(entityVM.GetEntity())
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

        ' GET: AutreImpactHumainEtEconomique/Edit/5
        Function Edit(ByVal EvenementZoneId As Long?) As ActionResult
            If IsNothing(EvenementZoneId) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim AutreImpactHumainEtEconomique As AutreImpactHumainEtEconomique = (From e In Db.AutreImpactHumainEtEconomique Where e.EvenementZoneId = EvenementZoneId Select e).FirstOrDefault()
            If IsNothing(AutreImpactHumainEtEconomique) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New AutreImpactHumainEtEconomiqueViewModel(AutreImpactHumainEtEconomique)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: AutreImpactHumainEtEconomique/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(entityVM As AutreImpactHumainEtEconomiqueViewModel) As ActionResult
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

        ' GET: AutreImpactHumainEtEconomique/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim AutreImpactHumainEtEconomique As AutreImpactHumainEtEconomique = Db.AutreImpactHumainEtEconomique.Find(id)
            If IsNothing(AutreImpactHumainEtEconomique) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New AutreImpactHumainEtEconomiqueViewModel(AutreImpactHumainEtEconomique)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: AutreImpactHumainEtEconomique/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim AutreImpactHumainEtEconomique As AutreImpactHumainEtEconomique = Db.AutreImpactHumainEtEconomique.Find(id)
            Db.AutreImpactHumainEtEconomique.Remove(AutreImpactHumainEtEconomique)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index", "EvenementZones")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New AutreImpactHumainEtEconomiqueViewModel(AutreImpactHumainEtEconomique))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
