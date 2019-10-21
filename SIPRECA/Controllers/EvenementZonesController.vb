Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.IO
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources

Namespace Controllers
    Public Class EvenementZonesController
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

        ' GET: EvenementZone
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.EvenementSort = If(sortOrder = "Evenement", "Evenement_desc", "Evenement")
            ViewBag.ZoneARisqueSort = If(sortOrder = "ZoneARisque", "ZoneARisque_desc", "ZoneARisque")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.EvenementZone Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Evenement.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.ZoneARisque.Libelle.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Evenement"
                    entities = entities.OrderBy(Function(e) e.Evenement.Libelle)
                Case "Evenement_desc"
                    entities = entities.OrderByDescending(Function(e) e.Evenement.Libelle)
                Case "ZoneARisque"
                    entities = entities.OrderBy(Function(e) e.ZoneARisque.Libelle)
                Case "ZoneARisque_desc"
                    entities = entities.OrderByDescending(Function(e) e.ZoneARisque.Libelle)
                Case Else
                    entities = entities.OrderBy(Function(e) e.Evenement.Libelle)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: EvenementZone/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim EvenementZone As EvenementZone = Db.EvenementZone.Find(id)
        '    If IsNothing(EvenementZone) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(EvenementZone)
        'End Function


        Private Sub LoadComboBox(entityVM As EvenementZoneViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)

            Dim Evenement = (From e In Db.Evenement Where e.StatutExistant = 1 Select e)
            Dim LesEvenements As New List(Of SelectListItem)

            Dim ZoneARisque = (From e In Db.ZoneARisque Where e.StatutExistant = 1 Select e).ToList
            Dim LesZoneARisques As New List(Of SelectListItem)



            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            For Each item In Evenement

                LesEvenements.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})

            Next

            For Each item In ZoneARisque

                LesZoneARisques.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})

            Next

            entityVM.LesUtilisateurs = LesUtilisateurs
            entityVM.LesEvenements = LesEvenements
            entityVM.LesZoneARisques = LesZoneARisques
        End Sub

        ' GET: EvenementZone/Create
        Function Create() As ActionResult
            Dim entityVM As New EvenementZoneViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: EvenementZone/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As EvenementZoneViewModel) As ActionResult
            entityVM.AspNetUserId = GetCurrentUser.Id
            If ModelState.IsValid Then
                Dim evenementZone = entityVM.GetEntity()
                Db.EvenementZone.Add(evenementZone)
                Try
                    Db.SaveChanges()
                    Dim cardreSendaiCibleA As New CardreSendaiCibleA With {
                        .EvenementZoneId = evenementZone.Id,
                        .AspNetUserId = evenementZone.AspNetUserId
                    }
                    Dim cardreSendaiCibleB As New CardreSendaiCibleB With {
                        .EvenementZoneId = evenementZone.Id,
                        .AspNetUserId = evenementZone.AspNetUserId
                    }
                    Dim cardreSendaiCibleC As New CardreSendaiCibleC With {
                        .EvenementZoneId = evenementZone.Id,
                        .AspNetUserId = evenementZone.AspNetUserId
                    }
                    Dim cardreSendaiCibleD As New CardreSendaiCibleD With {
                        .EvenementZoneId = evenementZone.Id,
                        .AspNetUserId = evenementZone.AspNetUserId
                    }
                    Dim AutreImpactHumainEtEconomique As New AutreImpactHumainEtEconomique With {
                        .EvenementZoneId = evenementZone.Id,
                        .AspNetUserId = evenementZone.AspNetUserId
                    }

                    Db.CardreSendaiCibleA.Add(cardreSendaiCibleA)
                    Db.CardreSendaiCibleB.Add(cardreSendaiCibleB)
                    Db.CardreSendaiCibleC.Add(cardreSendaiCibleC)
                    Db.CardreSendaiCibleD.Add(cardreSendaiCibleD)
                    Db.AutreImpactHumainEtEconomique.Add(AutreImpactHumainEtEconomique)
                    Try
                        Db.SaveChanges()
                        Return RedirectToAction("Index")
                    Catch ex As DbEntityValidationException
                        Util.GetError(ex, ModelState)
                    Catch ex As Exception
                        Util.GetError(ex, ModelState)
                    End Try
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try
            End If
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' GET: EvenementZone/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim EvenementZone As EvenementZone = Db.EvenementZone.Find(id)
            If IsNothing(EvenementZone) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New EvenementZoneViewModel(EvenementZone)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: EvenementZone/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As EvenementZoneViewModel) As ActionResult

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


        ' GET: EvenementZone/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim EvenementZone As EvenementZone = Db.EvenementZone.Find(id)
            If IsNothing(EvenementZone) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New EvenementZoneViewModel(EvenementZone)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: EvenementZone/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim EvenementZone As EvenementZone = Db.EvenementZone.Find(id)
            Db.EvenementZone.Remove(EvenementZone)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New EvenementZoneViewModel(EvenementZone))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
