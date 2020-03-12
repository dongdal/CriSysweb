Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList
Imports SIPRECA.My.Resources

Namespace Controllers
    Public Class SinistrersController
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

        ' GET: Sinistrer
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.NomSort = If(sortOrder = "Nom", "Nom_desc", "Nom")
            ViewBag.PrenomSort = If(sortOrder = "Prenom", "Prenom_desc", "Prenom")
            ViewBag.TelephoneSort = If(sortOrder = "Telephone", "Telephone_desc", "Telephone")
            ViewBag.SexeSort = If(sortOrder = "Sexe", "Sexe_desc", "Sexe")
            ViewBag.EmailSort = If(sortOrder = "Email", "Email_desc", "Email")
            ViewBag.CniSort = If(sortOrder = "Cni", "Cni_desc", "Cni")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.Sinistrer Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Cni.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Email.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Telephone.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Sexe.ToUpper.Contains(value:=searchString.ToUpper))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Nom"
                    entities = entities.OrderBy(Function(e) e.Nom)
                Case "Nom_desc"
                    entities = entities.OrderByDescending(Function(e) e.Prenom)
                Case "Prenom"
                    entities = entities.OrderBy(Function(e) e.Nom)
                Case "Prenom_desc"
                    entities = entities.OrderByDescending(Function(e) e.Prenom)
                Case "Telephone"
                    entities = entities.OrderBy(Function(e) e.Telephone)
                Case "Telephone_desc"
                    entities = entities.OrderByDescending(Function(e) e.Telephone)
                Case "Sexe"
                    entities = entities.OrderBy(Function(e) e.Sexe)
                Case "Sexe_desc"
                    entities = entities.OrderByDescending(Function(e) e.Sexe)
                Case "Email"
                    entities = entities.OrderBy(Function(e) e.Email)
                Case "Email_desc"
                    entities = entities.OrderByDescending(Function(e) e.Email)
                Case "Cni"
                    entities = entities.OrderBy(Function(e) e.Cni)
                Case "Cni_desc"
                    entities = entities.OrderByDescending(Function(e) e.Cni)

                Case Else
                    entities = entities.OrderBy(Function(e) e.Nom)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Sinistrer/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim Sinistrer As Sinistrer = Db.Sinistrer.Find(id)
        '    If IsNothing(Sinistrer) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(Sinistrer)
        'End Function

        Private Sub LoadComboBox(entityVM As SinistrerViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            Dim CollectiviteSinistree = (From e In Db.CollectiviteSinistree Where e.StatutExistant = 1 And e.AnneeBudgetaireId = AppSession.AnneeBudgetaire.Id Select e).ToList()
            Dim LesCollectiviteSinistrees As New List(Of SelectListItem)
            For Each item In CollectiviteSinistree
                LesCollectiviteSinistrees.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle & " | " & item.Sinistre.Libelle & " | " & item.Commune.Libelle})
            Next
            Dim AnneeBudgetaire = (From e In Db.AnneeBudgetaires Where e.StatutExistant = 1 Select e)
            Dim LesAnneeBudgetaires As New List(Of SelectListItem)
            For Each item In AnneeBudgetaire
                LesAnneeBudgetaires.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            entityVM.LesCollectiviteSinistrees = LesCollectiviteSinistrees
            entityVM.LesAnneeBudgetaires = LesAnneeBudgetaires
            entityVM.LesUtilisateurs = LesUtilisateurs
        End Sub

        ' GET: Sinistrer/Create
        Function Create() As ActionResult
            Dim entityVM As New SinistrerViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Sinistrer/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As SinistrerViewModel) As ActionResult

            entityVM.AspNetUserId = GetCurrentUser.Id
            If (entityVM.CollectiviteSinistreeId <= 0) Then
                ModelState.AddModelError("CollectiviteSinistreeId", Resource.CollectiviteSinistreeIdModelError)
            End If

            If ModelState.IsValid Then
                Dim entity = entityVM.GetEntity
                Db.Sinistrer.Add(entity)
                Try
                    Db.SaveChanges()
                    entityVM.Id = entity.Id
                    If Request.Form("AddPieces") IsNot Nothing Then
                        Return AddDemandeAndRedirect(entityVM)
                    Else
                        Return AddDemande(entityVM)
                    End If
                    'Return RedirectToAction("Index")
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try
            End If
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' GET: Sinistrer/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Sinistrer As Sinistrer = Db.Sinistrer.Find(id)
            If IsNothing(Sinistrer) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New SinistrerViewModel(Sinistrer)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        Function AddDemande(entityVM As SinistrerViewModel) As ActionResult

            Dim Demande = New Demande()
            Demande.AspNetUserId = GetCurrentUser.Id

            If (AppSession.Niveau.Equals(1)) Then
                Demande.StatutExistant = Util.ElementsSuiviDemandes.CreationCommunal
            ElseIf (AppSession.Niveau.Equals(2)) Then
                Demande.StatutExistant = Util.ElementsSuiviDemandes.CreationDepartemental
            ElseIf (AppSession.Niveau.Equals(3)) Then
                Demande.StatutExistant = Util.ElementsSuiviDemandes.CreationRegional
            ElseIf (AppSession.Niveau.Equals(4)) Then
                Demande.StatutExistant = Util.ElementsSuiviDemandes.CreationNational
            End If
            'Dim LaCommune = (From e In Db.Commune Where e.StatutExistant = 1 And e.Id = entityVM.CollectiviteSinistreeId Select e).FirstOrDefault()
            Dim LaCommune = (From e In Db.CollectiviteSinistree Where e.StatutExistant = 1 And e.Id = entityVM.CollectiviteSinistreeId Select e.Commune).FirstOrDefault()

            Demande.AnneeBudgetaireId = AppSession.AnneeBudgetaire.Id
            Demande.Observation = entityVM.Observation
            Demande.Reference = LaCommune.Code
            Demande.CollectiviteSinistreeId = entityVM.CollectiviteSinistreeId
            Demande.DateDeclaration = entityVM.DateDeclaration
            Demande.SinistrerId = entityVM.Id
            Db.Demande.Add(Demande)

            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            LoadComboBox(entityVM)
            Return View("Create", entityVM)
        End Function

        Function AddDemandeAndRedirect(entityVM As SinistrerViewModel) As ActionResult

            Dim Demande = New Demande()
            Demande.AspNetUserId = GetCurrentUser.Id

            If (AppSession.Niveau.Equals(1)) Then
                Demande.StatutExistant = Util.ElementsSuiviDemandes.CreationCommunal
            ElseIf (AppSession.Niveau.Equals(2)) Then
                Demande.StatutExistant = Util.ElementsSuiviDemandes.CreationDepartemental
            ElseIf (AppSession.Niveau.Equals(3)) Then
                Demande.StatutExistant = Util.ElementsSuiviDemandes.CreationRegional
            ElseIf (AppSession.Niveau.Equals(4)) Then
                Demande.StatutExistant = Util.ElementsSuiviDemandes.CreationNational
            End If
            Dim LaCommune = (From e In Db.CollectiviteSinistree Where e.StatutExistant = 1 And e.Id = entityVM.CollectiviteSinistreeId Select e.Commune).FirstOrDefault()
            Demande.AnneeBudgetaireId = AppSession.AnneeBudgetaire.Id
            Demande.Observation = entityVM.Observation
            Demande.Reference = LaCommune.Code
            Demande.CollectiviteSinistreeId = entityVM.CollectiviteSinistreeId
            Demande.DateDeclaration = entityVM.DateDeclaration
            Demande.SinistrerId = entityVM.Id
            Db.Demande.Add(Demande)

            Try
                Db.SaveChanges()
                Return RedirectToAction("EditPieces", "Demandes", New With {.id = Demande.Id})
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            LoadComboBox(entityVM)
            Return View("Create", entityVM)
        End Function

        ' POST: Sinistrer/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As SinistrerViewModel) As ActionResult
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

        ' GET: Sinistrer/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Sinistrer As Sinistrer = Db.Sinistrer.Find(id)
            If IsNothing(Sinistrer) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New SinistrerViewModel(Sinistrer)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Sinistrer/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim Sinistrer As Sinistrer = Db.Sinistrer.Find(id)
            Sinistrer.StatutExistant = 0
            Db.Entry(Sinistrer).State = EntityState.Modified
            Try
                    Db.SaveChanges()
                    Return RedirectToAction("Index")
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try
            Return View(New SinistrerViewModel(Sinistrer))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
