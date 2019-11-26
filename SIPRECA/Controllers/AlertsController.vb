Imports System.Data.Entity
Imports System.Data.Entity.Spatial
Imports System.Data.Entity.Validation
Imports System.Net
Imports System.Net.Mail
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources

Namespace Controllers
    Public Class AlertsController
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

        ' GET: Alerts
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?, TypeAlerteFilter As String) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.ContenuSort = If(sortOrder = "Contenu", "Contenu_desc", "Contenu")
            ViewBag.OrganisationSort = If(sortOrder = "Organisation", "Organisation_desc", "Organisation")
            ViewBag.SinistrerSort = If(sortOrder = "Sinistrer", "Sinistrer_desc", "Sinistrer")
            ViewBag.TypeSinistrerSort = If(sortOrder = "TypeSinistrer", "TypeSinistrer_desc", "TypeSinistrer")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")

            ViewBag.TypeAlerteFilter = TypeAlerteFilter

            Dim entities = Db.Alert.Include(Function(a) a.AspNetUser).Include(Function(a) a.Organisation).Include(Function(a) a.Sinistre)
            entities = FiltrerTypeAlerte(entities, TypeAlerteFilter)

            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Organisation.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or e.Sinistre.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Contenu.ToUpper.Contains(value:=searchString.ToUpper))
            End If

            Select Case sortOrder
                Case "Contenu"
                    entities = entities.OrderBy(Function(e) e.Contenu)
                Case "Contenu_desc"
                    entities = entities.OrderByDescending(Function(e) e.Contenu)
                Case "Sinistrer"
                    entities = entities.OrderBy(Function(e) e.Sinistre.Libelle)
                Case "Sinistrer_desc"
                    entities = entities.OrderByDescending(Function(e) e.Sinistre.Libelle)
                Case "Organisation"
                    entities = entities.OrderBy(Function(e) e.Organisation.Nom)
                Case "Organisation_desc"
                    entities = entities.OrderByDescending(Function(e) e.Organisation.Nom)
                Case "DateCreation"
                    entities = entities.OrderBy(Function(e) e.DateCreation)
                Case "DateCreation_desc"
                    entities = entities.OrderByDescending(Function(e) e.DateCreation)
                Case Else
                    entities = entities.OrderByDescending(Function(e) e.DateCreation)
                    Exit Select
            End Select

            Dim TypeAlerte As New List(Of SelectListItem) From {
                New SelectListItem With {.Value = Util.TypeAlerte.SMS, .Text = Resource.TypeSMS},
                New SelectListItem With {.Value = Util.TypeAlerte.Mail, .Text = Resource.TypeMail}
            }
            ViewBag.TypeAlerte = TypeAlerte

            ViewBag.EnregCount = entities.Count
            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        Private Shared Function FiltrerTypeAlerte(entities As IQueryable(Of Alert), TypeAlerte As String) As IQueryable(Of Alert)
            If Not String.IsNullOrEmpty(TypeAlerte) Then
                Select Case TypeAlerte
                    Case Util.TypeAlerte.SMS
                        entities = entities.Where(Function(e) e.StatutExistant > 1 And e.StatutExistant > 1)
                    Case Else
                        entities = entities.Where(Function(e) e.StatutExistant > 1 And e.StatutExistant > 1)
                        Exit Select
                End Select
            End If
            Return entities
        End Function

        ' GET: Alerts/Details/5
        Function Details(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim alert As Alert = Db.Alert.Find(id)
            If IsNothing(alert) Then
                Return HttpNotFound()
            End If
            Return View(alert)
        End Function

        ' GET: Alerts/Create
        Function Create() As ActionResult
            ViewBag.AspNetUserId = New SelectList(Db.Users, "Id", "Nom")
            ViewBag.OrganisationId = New SelectList(Db.Organisation, "Id", "Nom")
            ViewBag.SinistreId = New SelectList(Db.Sinistre, "Id", "LieuDuSinistre")
            Return View()
        End Function

        ' POST: Alerts/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,OrganisationId,SinistreId,Contenu,DateCreation,StatutExistant,AspNetUserId")> ByVal alert As Alert) As ActionResult
            If ModelState.IsValid Then
                Db.Alert.Add(alert)
                Db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.AspNetUserId = New SelectList(Db.Users, "Id", "Nom", alert.AspNetUserId)
            ViewBag.OrganisationId = New SelectList(Db.Organisation, "Id", "Nom", alert.OrganisationId)
            ViewBag.SinistreId = New SelectList(Db.Sinistre, "Id", "LieuDuSinistre", alert.SinistreId)
            Return View(alert)
        End Function

        ' GET: Alerts/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim alert As Alert = Db.Alert.Find(id)
            If IsNothing(alert) Then
                Return HttpNotFound()
            End If
            ViewBag.AspNetUserId = New SelectList(Db.Users, "Id", "Nom", alert.AspNetUserId)
            ViewBag.OrganisationId = New SelectList(Db.Organisation, "Id", "Nom", alert.OrganisationId)
            ViewBag.SinistreId = New SelectList(Db.Sinistre, "Id", "LieuDuSinistre", alert.SinistreId)
            Return View(alert)
        End Function

        ' POST: Alerts/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,OrganisationId,SinistreId,Contenu,DateCreation,StatutExistant,AspNetUserId")> ByVal alert As Alert) As ActionResult
            If ModelState.IsValid Then
                Db.Entry(alert).State = EntityState.Modified
                Db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.AspNetUserId = New SelectList(Db.Users, "Id", "Nom", alert.AspNetUserId)
            ViewBag.OrganisationId = New SelectList(Db.Organisation, "Id", "Nom", alert.OrganisationId)
            ViewBag.SinistreId = New SelectList(Db.Sinistre, "Id", "LieuDuSinistre", alert.SinistreId)
            Return View(alert)
        End Function

        ' GET: Alerts/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim alert As Alert = Db.Alert.Find(id)
            If IsNothing(alert) Then
                Return HttpNotFound()
            End If
            Return View(alert)
        End Function

        ' POST: Alerts/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim alert As Alert = Db.Alert.Find(id)
            Db.Alert.Remove(alert)
            Db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Private Sub LoadComboBox(entityVM As SMSAlertesViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)

            Dim Organisation = (From e In Db.Organisation Where e.StatutExistant = 1 Select e)
            Dim LesOrganisations As New List(Of SelectListItem)

            'Dim Commune = (From e In Db.Commune Where e.StatutExistant = 1 Select e).ToList
            Dim LesCommunes As New List(Of SelectListItem)

            Dim TypeSinistre = (From e In Db.TypeSinistre Where e.StatutExistant = 1 Select e)
            Dim LesTypeSinistre As New List(Of SelectListItem)

            'Dim Sinistre = (From e In Db.Sinistre Where e.StatutExistant = 1 Select e)
            Dim LesSinistres As New List(Of SelectListItem)

            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom.ToUpper()})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom.ToUpper() & " | " & item.Prenom.ToUpper()})
                End If
            Next

            For Each item In Organisation
                LesOrganisations.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom.ToUpper()})
            Next

            'For Each item In Commune
            '    LesCommunes.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle.ToUpper()})
            'Next

            For Each item In TypeSinistre
                LesTypeSinistre.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle.ToUpper()})
            Next

            'For Each item In Sinistre
            '    LesSinistres.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            'Next

            entityVM.LesUtilisateurs = LesUtilisateurs
            entityVM.LesTypeSinistre = LesTypeSinistre
            entityVM.LesSinistres = LesSinistres
            entityVM.LesCommunes = LesCommunes
            entityVM.LesOrganisations = LesOrganisations
        End Sub

        Private Sub LoadComboBox(entityVM As MailAlertesViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)

            Dim Organisation = (From e In Db.Organisation Where e.StatutExistant = 1 Select e)
            Dim LesOrganisations As New List(Of SelectListItem)

            'Dim Commune = (From e In Db.Commune Where e.StatutExistant = 1 Select e).ToList
            Dim LesCommunes As New List(Of SelectListItem)

            Dim TypeSinistre = (From e In Db.TypeSinistre Where e.StatutExistant = 1 Select e)
            Dim LesTypeSinistre As New List(Of SelectListItem)

            'Dim Sinistre = (From e In Db.Sinistre Where e.StatutExistant = 1 Select e)
            Dim LesSinistres As New List(Of SelectListItem)

            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom.ToUpper()})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom.ToUpper() & " | " & item.Prenom.ToUpper()})
                End If
            Next

            For Each item In Organisation
                LesOrganisations.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom.ToUpper()})
            Next

            'For Each item In Commune
            '    LesCommunes.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle.ToUpper()})
            'Next

            For Each item In TypeSinistre
                LesTypeSinistre.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle.ToUpper()})
            Next

            'For Each item In Sinistre
            '    LesSinistres.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            'Next

            entityVM.LesUtilisateurs = LesUtilisateurs
            entityVM.LesTypeSinistre = LesTypeSinistre
            entityVM.LesSinistres = LesSinistres
            entityVM.LesCommunes = LesCommunes
            entityVM.LesOrganisations = LesOrganisations
        End Sub

        ' GET: Alerts/SendMail
        Function SendMail() As ActionResult
            Dim entityVM As New MailAlertesViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function


        ' POST: Alerts/SendMail/5
        <HttpPost()>
        <ValidateAntiForgeryToken>
        Async Function SendMail(ByVal entityVM As MailAlertesViewModel) As Threading.Tasks.Task(Of JsonResult)
            If (IsNothing(entityVM.OrganisationId) Or IsNothing(entityVM.SinistreId) Or entityVM.CommuneId.Count <= 0) Then
                ModelState.AddModelError("", Resource.RequiredFields)
            End If

            If ModelState.IsValid Then
                Dim message As Object = New MailMessage()
                Try
                    Dim Organisation = (From e In Db.Organisation Where e.StatutExistant = 1 And e.Id = entityVM.OrganisationId Select e.Nom.ToUpper()).FirstOrDefault()
                    Dim PersonnelEmail = (From e In Db.Personnel Where e.StatutExistant = 1 And e.OganisationId = entityVM.OrganisationId Select e.Email).ToList()
                    Dim Sinistre = (From e In Db.Sinistre Where e.StatutExistant = 1 And e.Id = entityVM.SinistreId Select e).FirstOrDefault()
                    Dim TypeSinistre = Sinistre.TypeSinistre
                    Dim Collectivites = (From e In Db.CollectiviteSinistree Where e.StatutExistant = 1 And e.SinistreId = Sinistre.Id Select e).ToList()
                    Dim CollectivitesString As String = ""
                    For Each item In Collectivites
                        CollectivitesString = CollectivitesString & item.Commune.Libelle.ToUpper() & ", "
                    Next
                    CollectivitesString = CollectivitesString.Remove(CollectivitesString.Length - 2)
                    For Each email In PersonnelEmail
                        If (Not String.IsNullOrEmpty(email)) Then
                            message.To.Add(New MailAddress(email))
                        End If
                    Next

                    Dim subject As New StringBuilder
                    subject.AppendFormat("[{0}] - ", TypeSinistre.Libelle.ToUpper())
                    subject.AppendFormat("SINISTRE:  {0}", Sinistre.Libelle.ToUpper())
                    message.Subject = subject.ToString()
                    Dim FromName As String = ConfigurationManager.AppSettings("FromName")
                    Dim FromEmail As String = ConfigurationManager.AppSettings("FromEmail")

                    Dim Prebody As Object = "<p>EXPÉDITEUR DU MAIL: {0} ({1}).</p> <p>POINTS CONCERNÉS:</p><p>{2}</p><p>INSTRUCTIONS:</p><p>{3}</p>"
                    Dim body As New StringBuilder
                    body.AppendFormat("<p><strong>ALERTE SINISTRE:  {0}.</strong></p>", Sinistre.Libelle.ToUpper())
                    body.AppendFormat("<p><strong>DATE SINISTRE:  {0}.</strong></p>", Sinistre.DateCreation.ToString("dd-MM-yyyy"))
                    body.AppendFormat("<p><strong>TYPE SINISTRE:  {0}.</strong></p>", TypeSinistre.Libelle.ToUpper())
                    body.AppendFormat("<p><strong>COLLECTIVITES:  {0}.</strong></p>", CollectivitesString.ToUpper())
                    body.AppendFormat("<p><strong>ORGANISATION CONCERNEE {0}.</strong></p>", Organisation.ToUpper())
                    message.Body = String.Format(Prebody.ToString(), FromName, FromEmail, body.ToString(), entityVM.Contenu)
                    message.IsBodyHtml = True

                    Using smtp As Object = New SmtpClient()
                        Await smtp.SendMailAsync(message)
                    End Using

                    Dim alert As New Alert With {
                        .OrganisationId = entityVM.OrganisationId,
                        .SinistreId = entityVM.SinistreId,
                        .AspNetUserId = GetCurrentUser().Id,
                        .DateCreation = Now(),
                        .StatutExistant = 1,
                        .Contenu = entityVM.Contenu
                    }
                    Db.Alert.Add(alert)
                    Db.SaveChanges()
                    'ViewBag.Status = "Votre Mail a été envoyé avec succès."
                    Return Json(New With {.Result = "OK"})
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                    'ViewBag.Status = "Une erreur est survenue lors du processus. Veuillez réessayer. Si le problème persiste, veuillez contacter l'administrateur."
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                    'ViewBag.Status = "Une erreur est survenue lors du processus. Veuillez réessayer. Si le problème persiste, veuillez contacter l'administrateur."
                End Try
            End If
            Return Json(New With {.Result = "Error"})
        End Function


        ' GET: Alerts/SendSMS
        Function SendSMS() As ActionResult
            Dim entityVM As New SMSAlertesViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Alerts/SendSMS/5
        <HttpPost()>
        <ValidateAntiForgeryToken>
        Function SendSMS(ByVal entityVM As SMSAlertesViewModel) As JsonResult
            If (IsNothing(entityVM.OrganisationId) Or IsNothing(entityVM.SinistreId) Or entityVM.CommuneId.Count <= 0) Then
                ModelState.AddModelError("", Resource.RequiredFields)
            End If

            If ModelState.IsValid Then
                Try
                    Dim Organisation = (From e In Db.Organisation Where e.StatutExistant = 1 And e.Id = entityVM.OrganisationId Select e.Nom.ToUpper()).FirstOrDefault()
                    Dim Personnel = (From e In Db.Personnel Where e.StatutExistant = 1 And e.OganisationId = entityVM.OrganisationId Select e.Telephone).ToList()
                    Dim Sinistre = (From e In Db.Sinistre Where e.StatutExistant = 1 And e.Id = entityVM.SinistreId Select e).FirstOrDefault()
                    Dim TypeSinistre = Sinistre.TypeSinistre
                    Dim Collectivites = (From e In Db.CollectiviteSinistree Where e.StatutExistant = 1 And e.SinistreId = Sinistre.Id Select e).ToList()
                    Dim CollectivitesString As String = ""
                    For Each item In Collectivites
                        CollectivitesString = CollectivitesString & item.Commune.Libelle.ToUpper() & ", "
                    Next
                    CollectivitesString = CollectivitesString.Remove(CollectivitesString.Length - 2)
                    SendingSms(Personnel, Sinistre, TypeSinistre, CollectivitesString, Organisation, entityVM.Contenu.ToUpper())
                    Dim alert As New Alert With {
                        .OrganisationId = entityVM.OrganisationId,
                        .SinistreId = entityVM.SinistreId,
                        .AspNetUserId = GetCurrentUser().Id,
                        .DateCreation = Now(),
                        .StatutExistant = 1,
                        .Contenu = entityVM.Contenu
                    }
                    Db.Alert.Add(alert)
                    Db.SaveChanges()
                    Return Json(New With {.Result = "OK"})
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                    'ViewBag.Status = "Une erreur est survenue lors du processus. Veuillez réessayer. Si le problème persiste, veuillez contacter l'administrateur."
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                    'ViewBag.Status = "Une erreur est survenue lors du processus. Veuillez réessayer. Si le problème persiste, veuillez contacter l'administrateur."
                End Try
            End If
            Return Json(New With {.Result = "Error"})
        End Function

        Private Sub SendingSms(personnel As List(Of String), sinistre As Sinistre, typeSinistre As TypeSinistre, collectivitesString As String, organisation As String, contenu As String)
            Dim sms As New StringBuilder
            sms.AppendFormat("ALERTE SINISTRE:  {0}. " & vbCrLf, sinistre.Libelle.ToUpper())
            sms.AppendFormat("DATE SINISTRE:  {0}. " & vbCrLf, sinistre.DateCreation.ToString("dd-MM-yyyy"))
            'sms.AppendFormat("TYPE SINISTRE:  {0}. ", typeSinistre.Libelle.ToUpper())
            'sms.AppendFormat("COLLECTIVITES:  {0}. ", collectivitesString.ToUpper())
            'sms.AppendFormat("ORGANISATION CONCERNEE {0}. ", organisation.ToUpper())
            sms.Append(contenu)

            'Dim ANSI As Encoding = Encoding.GetEncoding("utf-8")
            Dim msg_ansi = Util.RemoveAccent(sms.ToString).ToUpper ' ANSI.GetString(ANSI.GetBytes(sms.ToString))

            For Each phone In personnel
                If Not String.IsNullOrWhiteSpace(phone) Then
                    System.Threading.Thread.Sleep(2000)
                    Util.SendSms(phone, msg_ansi)
                    System.Threading.Thread.Sleep(1000)
                End If
            Next
        End Sub

        <HttpPost>
        Public Function SinistreByTypeSinistre(TypeSinistreId As Long) As JsonResult
            If IsNothing(TypeSinistreId) Then
                Response.StatusCode = CType(HttpStatusCode.BadRequest, Integer)
                Return Json(New With {.Result = "Error"})
            End If
            Try
                Dim TypeSinistre = (From p In Db.TypeSinistre Where p.Id = TypeSinistreId Select p).ToList.FirstOrDefault()
                If TypeSinistre Is Nothing Then
                    Response.StatusCode = CType(HttpStatusCode.NotFound, Integer)
                    Return Json(New With {.Result = "Error"})
                End If

                Dim Results = (From e In Db.Sinistre Where e.TypeSinistreId = TypeSinistre.Id Order By e.Libelle Select New SelectListItem With {.Value = e.Id, .Text = e.Libelle.ToUpper()}).ToList()

                'Return Json(New With {.Result = "OK"})
                Return Json(Results, JsonRequestBehavior.AllowGet)
            Catch ex As Exception
                Return Json(New With {.Result = "Error"})
            End Try
        End Function

        <HttpPost>
        Public Function CommuneBySinistre(SinistreId As Long) As JsonResult
            If IsNothing(SinistreId) Then
                Response.StatusCode = CType(HttpStatusCode.BadRequest, Integer)
                Return Json(New With {.Result = "Error"})
            End If
            Try
                Dim Sinistre = (From p In Db.Sinistre Where p.Id = SinistreId Select p).ToList.FirstOrDefault()
                If Sinistre Is Nothing Then
                    Response.StatusCode = CType(HttpStatusCode.NotFound, Integer)
                    Return Json(New With {.Result = "Error"})
                End If

                Dim Results = (From e In Db.CollectiviteSinistree Where e.SinistreId = Sinistre.Id Order By e.Commune.Libelle Select New SelectListItem With {.Value = e.Commune.Id, .Text = e.Commune.Libelle.ToUpper()}).ToList()

                'Return Json(New With {.Result = "OK"})
                Return Json(Results, JsonRequestBehavior.AllowGet)
            Catch ex As Exception
                Return Json(New With {.Result = "Error"})
            End Try
        End Function


        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
