Imports System.Data.Entity
Imports System.Data.Entity.Spatial
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources

Namespace Controllers
    Public Class AlertesController
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

        Private Sub LoadComboBox(entityVM As AlertesViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)

            Dim Organisation = (From e In Db.Organisation Where e.StatutExistant = 1 Select e)
            Dim LesOrganisations As New List(Of SelectListItem)

            Dim Commune = (From e In Db.Commune Where e.StatutExistant = 1 Select e).ToList
            Dim LesCommunes As New List(Of SelectListItem)

            Dim TypeSinistre = (From e In Db.TypeSinistre Where e.StatutExistant = 1 Select e)
            Dim LesTypeSinistre As New List(Of SelectListItem)

            Dim Sinistre = (From e In Db.Sinistre Where e.StatutExistant = 1 Select e)
            Dim LesSinistres As New List(Of SelectListItem)

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

            For Each item In Commune
                LesCommunes.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In TypeSinistre
                LesTypeSinistre.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In Sinistre
                LesSinistres.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            entityVM.LesUtilisateurs = LesUtilisateurs
            entityVM.LesTypeSinistre = LesTypeSinistre
            entityVM.LesSinistres = LesSinistres
            entityVM.LesCommunes = LesCommunes
            entityVM.LesOrganisations = LesOrganisations
        End Sub

        ' GET: Alertes/AlertByGroupExisting
        Function AlertByGroupExisting() As ActionResult
            Dim entityVM As New AlertesViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        <HttpPost()>
        <ValidateAntiForgeryToken>
        Function AlertByGroupExisting(ByVal entityVM As AlertesViewModel) As ActionResult
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
                    CollectivitesString.Remove(CollectivitesString.Length - 2)
                    SendMailAndSms(Personnel, Sinistre, TypeSinistre, CollectivitesString, Organisation, entityVM.Contenu.ToUpper())
                    Return View(entityVM)
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try
            End If
            Return View()
        End Function

        Private Sub SendMailAndSms(personnel As List(Of String), sinistre As Sinistre, typeSinistre As TypeSinistre, collectivitesString As String, organisation As String, contenu As String)
            Dim sms As New StringBuilder
            sms.AppendFormat("ALERTE SINISTRE:  {0}. ", sinistre.Libelle.ToUpper())
            sms.AppendFormat("DATE SINISTRE:  {0}. ", sinistre.DateCreation.ToLongDateString())
            sms.AppendFormat("TYPE SINISTRE:  {0}. ", typeSinistre.Libelle.ToUpper())
            sms.AppendFormat("COLLECTIVITES:  {0}. ", collectivitesString.ToUpper())
            sms.AppendFormat("ORGANISATION CONCERNEE {0}. " & vbCrLf, organisation.ToUpper())
            sms.Append(contenu & vbCrLf & "MERCI.")

            'Dim ANSI As Encoding = Encoding.GetEncoding("utf-8")
            Dim msg_ansi = Util.RemoveAccent(sms.ToString).ToUpper ' ANSI.GetString(ANSI.GetBytes(sms.ToString))

            For Each phone In personnel
                If Not String.IsNullOrWhiteSpace(phone) Then
                    System.Threading.Thread.Sleep(2000)
                    Util.SendSms(phone, msg_ansi)
                    System.Threading.Thread.Sleep(2000)
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

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class

End Namespace
