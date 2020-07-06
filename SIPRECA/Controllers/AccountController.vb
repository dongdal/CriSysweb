Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.Owin.Security
Imports PagedList
Imports SIPRECA.My.Resources

<Authorize>
Public Class AccountController
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

    Public Sub New()
        Me.New(New UserManager(Of ApplicationUser)(New UserStore(Of ApplicationUser)(New ApplicationDbContext())))
    End Sub

    Public Sub New(manager As UserManager(Of ApplicationUser))
        UserManager = manager
    End Sub

    Public Property UserManager As UserManager(Of ApplicationUser)

    Public Function SetExercice(AnneeBudgetaireId As Long) As ActionResult
        'on recupere les infos de sessions
        Dim annee = Db.AnneeBudgetaires.Find(AnneeBudgetaireId)

        If annee IsNot Nothing Then
            AppSession.AnneeBudgetaire = annee
        End If

        Return Redirect(Request.UrlReferrer.ToString)
    End Function

    '<LocalizedAuthorize(Roles:="Administrateur")>
    Public Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
        If Not AppSession.ListActionSousRessource.Contains(66, 2) Then
            Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
        End If
        ViewBag.CurrentSort = sortOrder
        ViewBag.SexeSort = If(sortOrder = "Sexe", "Sexe_desc", "Sexe")
        ViewBag.LieuNaissanceSort = If(sortOrder = "LieuNaissance", "LieuNaissance_desc", "LieuNaissance")
        ViewBag.NomSort = If(sortOrder = "Noms", "Noms_desc", "Noms")
        ViewBag.PrenomSort = If(sortOrder = "Prenoms", "Prenoms_desc", "Prenoms")
        ViewBag.UserNameSort = If(sortOrder = "UserName", "UserName_desc", "UserName")
        ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
        ViewBag.CNISort = If(sortOrder = "CNI", "CNI_desc", "CNI")
        ViewBag.AdresseUserSort = If(sortOrder = "AdresseUser", "AdresseUser_desc", "AdresseUser")
        ViewBag.TelephoneSort = If(sortOrder = "Telephone", "Telephone_desc", "Telephone")
        ViewBag.EmailSort = If(sortOrder = "Email", "Email_desc", "Email")

        If Not String.IsNullOrEmpty(searchString) Then
            page = 1
        Else
            searchString = currentFilter
        End If

        ViewBag.CurrentFilter = searchString

        Dim entities = (From usr In Db.Users Where (usr.UserName <> "teamis") And (usr.UserName <> "toto2012") Select usr)
        If Not String.IsNullOrEmpty(searchString) Then
            entities = entities.Where(Function(usr) usr.UserName.ToUpper.Contains(value:=searchString.ToUpper) Or
                                          usr.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                          usr.Prenom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                          usr.CNI.ToUpper.Contains(value:=searchString.ToUpper) Or
                                          usr.AdresseUser.ToUpper.Contains(value:=searchString.ToUpper) Or
                                          usr.Telephone.ToUpper.Contains(value:=searchString.ToUpper) Or
                                          usr.Email.ToUpper.Contains(value:=searchString.ToUpper) Or
                                          usr.Sexe.ToUpper.Contains(value:=searchString.ToUpper) Or
                                          usr.UserName.ToUpper.Contains(value:=searchString.ToUpper))
        End If
        ViewBag.EnregCount = entities.Count

        Select Case sortOrder

            Case "LieuNaissance"
                entities = entities.OrderBy(Function(e) e.LieuNaissance)
            Case "LieuNaissance_desc"
                entities = entities.OrderByDescending(Function(e) e.LieuNaissance)

            Case "Email"
                entities = entities.OrderBy(Function(e) e.Email)
            Case "Email_desc"
                entities = entities.OrderByDescending(Function(e) e.Email)

            Case "CNI"
                entities = entities.OrderBy(Function(e) e.CNI)
            Case "CNI_desc"
                entities = entities.OrderByDescending(Function(e) e.CNI)

            Case "Telephone"
                entities = entities.OrderBy(Function(e) e.Telephone)
            Case "Telephone_desc"
                entities = entities.OrderByDescending(Function(e) e.Telephone)

            Case "UserName"
                entities = entities.OrderBy(Function(e) e.UserName)
            Case "UserName_desc"
                entities = entities.OrderByDescending(Function(e) e.UserName)

            Case "Noms"
                entities = entities.OrderBy(Function(e) e.Nom)
            Case "Noms_desc"
                entities = entities.OrderByDescending(Function(e) e.Nom)

            Case "Prenoms"
                entities = entities.OrderBy(Function(e) e.Prenom)
            Case "Prenoms_desc"
                entities = entities.OrderByDescending(Function(e) e.Prenom)

            Case "Sexe"
                entities = entities.OrderBy(Function(e) e.Sexe)
            Case "Sexe_desc"
                entities = entities.OrderByDescending(Function(e) e.Sexe)

            Case "AdresseUser"
                entities = entities.OrderBy(Function(e) e.AdresseUser)
            Case "AdresseUser_desc"
                entities = entities.OrderByDescending(Function(e) e.AdresseUser)


            Case Else
                entities = entities.OrderBy(Function(e) e.UserName)
                Exit Select
        End Select

        Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
        Dim pageNumber As Integer = If(page, 1)

        Return View(entities.ToPagedList(pageNumber, pageSize))
    End Function

    Public Function IndexRoles(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
        If Not AppSession.ListActionSousRessource.Contains(10012, 2) Then
            Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
        End If
        ViewBag.CurrentSort = sortOrder
        ViewBag.NameSort = If(sortOrder = "Name", "Name_desc", "Name")

        If Not String.IsNullOrEmpty(searchString) Then
            page = 1
        Else
            searchString = currentFilter
        End If

        ViewBag.CurrentFilter = searchString

        Dim entities = (From role In Db.Roles Select role)
        If Not String.IsNullOrEmpty(searchString) Then
            entities = entities.Where(Function(role) role.Name.ToUpper.Contains(value:=searchString.ToUpper))
        End If
        ViewBag.EnregCount = entities.Count

        Select Case sortOrder

            Case "Name"
                entities = entities.OrderBy(Function(e) e.Name)
            Case "Name_desc"
                entities = entities.OrderByDescending(Function(e) e.Name)

            Case Else
                entities = entities.OrderBy(Function(e) e.Id)
                Exit Select
        End Select

        Dim RoleList As New List(Of RolesViewModel)
        If Not IsNothing(entities) Then
            For Each item In entities
                Dim Role As New RolesViewModel With {
                    .Id = item.Id,
                    .Name = item.Name
                }
                RoleList.Add(Role)
            Next
        End If

        Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
        Dim pageNumber As Integer = If(page, 1)

        Return View(RoleList.ToPagedList(pageNumber, pageSize))
    End Function

    ' GET: Account/CreateRoles
    Function CreateRoles() As ActionResult
        If Not AppSession.ListActionSousRessource.Contains(10012, 1) Then
            Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
        End If
        Dim entityVM As New RolesViewModel
        Return View(entityVM)
    End Function

    ' POST: Account/CreateRoles
    'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
    'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
    <HttpPost()>
    <ValidateAntiForgeryToken()>
    Function CreateRoles(ByVal entityVM As RolesViewModel) As ActionResult
        If Not AppSession.ListActionSousRessource.Contains(10012, 1) Then
            Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
        Else
            If ModelState.IsValid Then
                Dim ListIdString = (From e In Db.Roles Select e.Id Order By Id Ascending).ToList
                Dim ListId As New List(Of Integer)
                For Each id In ListIdString
                    Dim temp As Integer = 0
                    Integer.TryParse(id, temp)
                    ListId.Add(temp)
                Next
                entityVM.Id = ListId.LastOrDefault + 1
                Db.Roles.Add(entityVM.GetEntity)
                Try
                    Db.SaveChanges()
                    Return RedirectToAction("IndexRoles")
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try
            End If
            Return View(entityVM)
        End If
    End Function

    ' GET: Account/EditRoles/5
    Function EditRoles(ByVal id As String) As ActionResult
        If Not AppSession.ListActionSousRessource.Contains(10012, 3) Then
            Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
        Else
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim roles As IdentityRole = Db.Roles.Find(id)
            If IsNothing(roles) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New RolesViewModel(roles)
            Return View(entityVM)
        End If
    End Function

    ' POST: Account/EditRoles/5
    'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
    'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
    <HttpPost()>
    <ValidateAntiForgeryToken()>
    Function EditRoles(ByVal entityVM As RolesViewModel) As ActionResult
        If Not AppSession.ListActionSousRessource.Contains(10012, 3) Then
            Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
        Else
            If ModelState.IsValid Then
                Db.Entry(entityVM.GetEntity).State = EntityState.Modified
                Try
                    Db.SaveChanges()
                    Return RedirectToAction("IndexRoles")
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try
            End If
            Return View(entityVM)
        End If
    End Function

    ' GET: Account/DeleteRoles/5
    Function DeleteRoles(ByVal id As String) As ActionResult
        If Not AppSession.ListActionSousRessource.Contains(10012, 4) Then
            Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
        Else
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim role As IdentityRole = Db.Roles.Find(id)
            If IsNothing(role) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New RolesViewModel(role)
            Return View(entityVM)
        End If
    End Function

    ' POST: Account/DeleteRoles/5
    <HttpPost()>
    <ActionName("DeleteRoles")>
    <ValidateAntiForgeryToken()>
    Function DeleteRolesConfirmed(ByVal id As String) As ActionResult
        If Not AppSession.ListActionSousRessource.Contains(10012, 4) Then
            Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
        Else
            Dim role As IdentityRole = Db.Roles.Find(id)
            Db.Roles.Remove(role)
            Db.SaveChanges()
            Return RedirectToAction("IndexRoles")
        End If
    End Function

    '
    ' GET: /Account/Login
    <AllowAnonymous>
    Public Function Login(returnUrl As String) As ActionResult
        ViewBag.ReturnUrl = returnUrl
        Return View()
    End Function

    '
    ' POST: /Account/Login
    <HttpPost>
    <AllowAnonymous>
    <ValidateAntiForgeryToken>
    Public Async Function Login(model As LoginViewModel, returnUrl As String) As Task(Of ActionResult)
        If ModelState.IsValid Then
            ' Valider le mot de passe
            Dim appUser = Await UserManager.FindAsync(model.UserName, model.Password)
            If appUser IsNot Nothing Then
                Await SignInAsync(appUser, model.RememberMe)

                AppSession.UserId = appUser.Id
                AppSession.NomUser = appUser.Nom
                AppSession.PrenomUser = appUser.Prenom
                AppSession.UserName = appUser.UserName

                Return RedirectToAction("Index", "Home")
            Else
                Return RedirectToAction("Login", "Account")
                'ModelState.AddModelError("", Resource.InvalidParam)
            End If
        End If

        ' Si nous sommes arrivés là, un échec s’est produit. Réafficher le formulaire
        Return View(model)
    End Function

    <HttpPost()>
    Public Function LoadCommunes() As ActionResult
        Dim results = (From e In Db.Commune Where e.StatutExistant = 1 Order By e.Libelle Select New SelectListItem With {.Value = e.Id, .Text = e.Libelle})
        Return Json(results, JsonRequestBehavior.AllowGet)
    End Function

    <HttpPost()>
    Public Function LoadDepartements() As ActionResult
        Dim results = (From e In Db.Departement Where e.StatutExistant = 1 Order By e.Libelle Select New SelectListItem With {.Value = e.Id, .Text = e.Libelle})
        Return Json(results, JsonRequestBehavior.AllowGet)
    End Function

    <HttpPost()>
    Public Function LoadRegions() As ActionResult
        Dim results = (From e In Db.Region Where e.StatutExistant = 1 Order By e.Libelle Select New SelectListItem With {.Value = e.Id, .Text = e.Libelle})
        Return Json(results, JsonRequestBehavior.AllowGet)
    End Function

    Private Sub LoadComboRegister(model As RegisterViewModel)
        'Dim Departement = (From e In Db.Departement Where e.StatutExistant = 1 Order By e.Libelle Select e)
        'Dim Departements As New List(Of SelectListItem)
        'For Each item In Departement
        '    Departements.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
        'Next

        'Dim Region = (From e In Db.Region Where e.StatutExistant = 1 Order By e.Libelle Select e)
        'Dim Regions As New List(Of SelectListItem)
        'For Each item In Region
        '    Regions.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
        'Next

        'Dim Commune = (From e In Db.Commune Where e.StatutExistant = 1 Order By e.Libelle Select e)
        'Dim LesCommunes As New List(Of SelectListItem)
        'For Each item In Commune
        '    LesCommunes.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
        'Next

        Dim LesNiveaux As New List(Of SelectListItem) From {
            New SelectListItem With {.Value = Util.UserLevel.Communal, .Text = Resource.NiveauCommunal},
            New SelectListItem With {.Value = Util.UserLevel.Departemental, .Text = Resource.NiveauDepartemental},
            New SelectListItem With {.Value = Util.UserLevel.Regional, .Text = Resource.NiveauRegional},
            New SelectListItem With {.Value = Util.UserLevel.National, .Text = Resource.NiveauNational},
            New SelectListItem With {.Value = Util.UserLevel.Autre, .Text = Resource.NiveauAutre}
        }

        model.LesNiveaux = LesNiveaux
        model.LesCommunes = New List(Of SelectListItem)
        model.Regions = New List(Of SelectListItem)
        model.Departements = New List(Of SelectListItem)
    End Sub

    Private Sub LoadComboEdit(model As EditUserViewModel)
        'Dim Departement = (From e In Db.Departement Where e.StatutExistant = 1 Order By e.Libelle Select e)
        'Dim Departements As New List(Of SelectListItem)
        'For Each item In Departement
        '    Departements.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
        'Next
        'Dim Region = (From e In Db.Region Where e.StatutExistant = 1 Order By e.Libelle Select e)
        'Dim Regions As New List(Of SelectListItem)

        'For Each item In Region
        '    Regions.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
        'Next

        'Dim Commune = (From e In Db.Commune Where e.StatutExistant = 1 Order By e.Libelle Select e)
        'Dim LesCommunes As New List(Of SelectListItem)
        'For Each item In Commune
        '    LesCommunes.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
        'Next

        Dim LesNiveaux As New List(Of SelectListItem) From {
            New SelectListItem With {.Value = Util.UserLevel.Communal, .Text = Resource.NiveauCommunal},
            New SelectListItem With {.Value = Util.UserLevel.Departemental, .Text = Resource.NiveauDepartemental},
            New SelectListItem With {.Value = Util.UserLevel.Regional, .Text = Resource.NiveauRegional},
            New SelectListItem With {.Value = Util.UserLevel.National, .Text = Resource.NiveauNational},
            New SelectListItem With {.Value = Util.UserLevel.Autre, .Text = Resource.NiveauAutre}
        }

        model.LesNiveaux = LesNiveaux
        model.LesCommunes = New List(Of SelectListItem)
        model.Regions = New List(Of SelectListItem)
        model.Departements = New List(Of SelectListItem)
    End Sub

    '
    ' GET: /Account/Register
    <AllowAnonymous>
    Public Function Register() As ActionResult
        If Not AppSession.ListActionSousRessource.Contains(66, 1) Then
            Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
        End If
        Dim model = New RegisterViewModel()
        LoadComboRegister(model)
        Return View(model)
    End Function

    '
    ' POST: /Account/Register
    <HttpPost>
    <AllowAnonymous>
    <ValidateAntiForgeryToken>
    Public Async Function Register(model As RegisterViewModel) As Task(Of ActionResult)
        If Not AppSession.ListActionSousRessource.Contains(66, 1) Then
            Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
        End If
        If ModelState.IsValid Then
            ' Créer un identifiant local avant de connecter l'utilisateur
            Dim user = model.GetUser ' New ApplicationUser() With {.UserName = model.UserName}
            If (user.Niveau.Equals("4") Or user.Niveau.Equals("5")) Then
                user.CommuneId = Nothing
                user.DepartementId = Nothing
                user.RegionId = Nothing
            ElseIf (user.Niveau.Equals("1")) Then
                user.DepartementId = Nothing
                user.RegionId = Nothing
            ElseIf (user.Niveau.Equals("2")) Then
                user.CommuneId = Nothing
                user.RegionId = Nothing
            ElseIf (user.Niveau.Equals("3")) Then
                user.CommuneId = Nothing
                user.DepartementId = Nothing
            End If
            Try
                Dim result = Await UserManager.CreateAsync(user, model.Password)
                If result.Succeeded Then
                    Return RedirectToAction("UserRoles", "Account", New With {user.Id})
                Else
                    AddErrors(result)
                End If
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
        End If
        LoadComboRegister(model)

        Return View(model)
    End Function

    '<LocalizedAuthorize(Roles:="Administrateur")>
    Public Function Edit(id As String, Optional Message As ManageMessageId? = Nothing) As ActionResult
        If Not AppSession.ListActionSousRessource.Contains(66, 3) Then
            Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
        End If
        If IsNothing(id) Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If
        Dim user = Db.Users.Find(id)
        If IsNothing(user) Then
            Return HttpNotFound()
        End If

        ViewBag.MessageId = Message
        Dim model As New EditUserViewModel(user:=user)
        LoadComboEdit(model)
        Return View(model)
    End Function

    '<LocalizedAuthorize(Roles:="Administrateur")>
    <HttpPost>
    <ValidateAntiForgeryToken>
    Public Async Function Edit(model As EditUserViewModel) As Task(Of ActionResult)
        If Not AppSession.ListActionSousRessource.Contains(66, 3) Then
            Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
        End If
        If model Is Nothing Then
            Throw New ArgumentNullException("model")
        End If
        If ModelState.IsValid Then
            Dim id = model.Id
            Dim user = Db.Users.Find(id)
            If IsNothing(user) Then
                Return HttpNotFound()
            End If

            Dim entity = model.GetEntity(user, Db)
            Db.Entry(entity:=entity).State = EntityState.Modified
            Try
                Await Db.SaveChangesAsync()

                ' Changer le mot de passe eventuellement
                If Not String.IsNullOrEmpty(model.Password) Then
                    UserManager.RemovePassword(model.Id)

                    Dim result = UserManager.AddPassword(model.Id, model.Password)
                    If result.Succeeded Then
                        Return RedirectToAction(actionName:="UserRoles", controllerName:="Account", routeValues:=New With {user.Id})
                    Else
                        AddErrors(result)
                    End If
                Else
                    Return RedirectToAction(actionName:="UserRoles", controllerName:="Account", routeValues:=New With {user.Id})
                End If

            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
        End If
        LoadComboEdit(model)
        Return View(model)
    End Function

    'Get
    '<LocalizedAuthorize(Roles:="Administrateur")>
    Public Function UserRoles(id As String) As ActionResult
        If Not AppSession.ListActionSousRessource.Contains(66, 15) Then
            Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
        End If
        If IsNothing(id) Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If
        Dim user = Db.Users.Find(id)
        If IsNothing(user) Then
            Return HttpNotFound()
        End If
        Return View(New SelectUserRolesViewModel(user))
    End Function

    '<LocalizedAuthorize(Roles:="Administrateur")>
    <HttpPost>
    <ValidateAntiForgeryToken>
    Public Function UserRoles(model As SelectUserRolesViewModel) As ActionResult
        If Not AppSession.ListActionSousRessource.Contains(66, 15) Then
            Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
        End If
        If ModelState.IsValid Then
            Dim idManager = New IdentityManager()
            Dim user = Db.Users.Find(model.Id)
            idManager.ClearUserRoles(user.Id)
            'Dim SelectedRoles As New List(Of IdentityRole)
            For Each role As SelectRoleEditorViewModel In model.Roles
                If role.Selected Then
                    idManager.AddUserToRole(user.Id, role.RoleName)
                    Dim tempoRole = (From e In Db.Roles Where e.Name.ToUpper().Equals(role.RoleName.ToUpper()) Select e).FirstOrDefault()
                    'SelectedRoles.Add(tempoRole)
                End If
            Next
            'Return RedirectToAction("Index")
            Return RedirectToAction(actionName:="AccessRightsManager", controllerName:="Account", routeValues:=New With {.UserId = user.Id})
        End If
        Return View()
    End Function

    <HttpGet>
    Public Function AccessRightsManager(UserId As String, Optional ErreurModel As String = "") As ActionResult
        If Not AppSession.ListActionSousRessource.Contains(66, 15) Then
            Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
        End If

        If IsNothing(UserId) Then 'on vérifie si l'id envoyé en paramètre est bel et bien non vide. S'il est vide, on renvoit une erreur de type HttpNotFount
            Return HttpNotFound()
        End If

        ' Depuis la table AspNetUserRole, on récupère les rôles aux quels l'utilisateur en cours de traitement a droit et on les charge dans une liste
        Dim UserRoles = (From userRole In Db.IdentityUserRole Where userRole.UserId.Equals(UserId) Select userRole).ToList()
        If IsNothing(UserRoles) Then 'on vérifie si la liste des rôles est vide. Si c'est le cas, on renvoit une erreur de type HttpNotFount
            Return HttpNotFound()
        End If
        'Dim ModuleRoleList As New List(Of ModuleRole)
        Dim entityVM As New AccessRightsManagerViewModel With {
            .LesModuleRoles = New List(Of ModuleRole),
            .LesRessources = New List(Of Ressource),
            .LesActions = New List(Of SelectListItem)
        }
        For Each userRole In UserRoles 'Pour chaque élément se trouvant dans la liste
            'On sélectionne les modules aux quels peut accéder l'utilisateur en cours de traitement. La sélection se fait en triant les modules en fonction de son(ses) rôle(s)
            Dim moduleRole = (From e In Db.ModuleRole Where e.AspNetRolesId = userRole.RoleId Select e Order By e.Id).ToList()
            For Each item In moduleRole
                If Not (entityVM.LesModuleRoles.Contains(item)) Then
                    entityVM.LesModuleRoles.Add(item) 'on charge la liste des modules et roles en se rassurant qu'il n'y aura pas d'élément en double d'où le "Not (entityVM.LesModuleRoles.Contains(item))"
                End If
            Next
        Next

        For Each item In entityVM.LesModuleRoles
            'On recherche toutes les ressources liées aux modules que nous avons sélectionné.
            For Each ressource In item.Modules.Ressource
                entityVM.LesRessources.Add(ressource)
            Next
        Next

        For Each ressource In entityVM.LesRessources
            'Loop and add the Parent Nodes.
            For Each sousRessource As SousRessource In ressource.SousRessource
                'On crée le groupe en fonction de la ressource en cours.
                Dim group As New SelectListGroup() With {
                    .Name = sousRessource.Ressource.Modules.Libelle.ToUpper() & "->" & sousRessource.Ressource.Libelle.ToUpper() & "->" & sousRessource.Libelle.ToUpper()
                }

                Dim ActionSousRessource = (From a In Db.ActionSousRessource Where a.StatutExistant = 1 And a.SousRessourceId = sousRessource.Id Select a).ToList
                'Pour chaque sous ressource, on charge les actions possibles pour la ressource et on les affecte au groupe correspondant à la sous ressource.
                For Each actSousRes In ActionSousRessource
                    entityVM.LesActions.Add(New SelectListItem() With {
                        .Value = actSousRes.Id,
                        .Text = actSousRes.Actions.Libelle,
                        .Group = group
                    })
                Next

                'On charge les actions et on les affecte au groupe correspondant à la sous ressource en cours.
                'For Each actions As Actions In Db.Actions.Where(Function(a) a.StatutExistant = 1)
                '    entityVM.LesActions.Add(New SelectListItem() With {
                '        .Value = sousRessource.Id & "-" & actions.Id,
                '        .Text = actions.Libelle,
                '        .Group = group
                '    })
                'Next
            Next
        Next
        ViewBag.ErreurModel = ErreurModel
        entityVM.SelectedAspNetUserId = UserId
        Return View(entityVM)
    End Function

    <HttpPost>
    <ValidateAntiForgeryToken>
    Public Function AccessRightsManager(entityVM As AccessRightsManagerViewModel) As ActionResult
        If Not AppSession.ListActionSousRessource.Contains(66, 15) Then
            Return RedirectToAction("Error404", "Home", New With {Resource.Error400_AccessRights, .MyAction = "Index", .Controleur = "Home"})
        End If
        If (IsNothing(entityVM.ActionsId)) Then
            ModelState.AddModelError("", Resource.MdlStatError_ActionList)
        End If
        If ModelState.IsValid Then
            'Dans un Premier temps, on procède au nettoyage de la base de données en supprimant les anciens droits d'accès de l'utilisateur sur lequel les traitements sont effectués
            DeleteAccessRights(entityVM.SelectedAspNetUserId)
            'Pour chaque élément dans la liste représentant l'identifiant d'un tuple de la table actionSousRessource, on enregistra dans la table aspnetuserAction....  
            'la valeur en cours à partir de laquelle il sera facile d'avoir l'action associée
            For Each item In entityVM.ActionsId
                Dim aspNetUserActionSousRessource As New AspNetUserActionSousRessource With {
                .ActionSousRessourceId = item,
                .AspNetUserId = entityVM.SelectedAspNetUserId,
                .DateCreation = Now,
                .StatutExistant = 1,
                .UserId = User.Identity.GetUserId()
                }
                Db.AspNetUserActionSousRessource.Add(aspNetUserActionSousRessource)
                Try
                    Db.SaveChanges()
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try
            Next
            Return RedirectToAction("Index")
        End If
        Dim MessagesBuilder As New StringBuilder()
        For Each StateModel In ViewData.ModelState.Values
            For Each msg In StateModel.Errors
                MessagesBuilder.Append(msg.ErrorMessage & vbCrLf)
            Next
        Next

        Return RedirectToAction(actionName:="AccessRightsManager", controllerName:="Account",
                                routeValues:=New With {.UserId = entityVM.SelectedAspNetUserId, .ErreurModel = MessagesBuilder.ToString})
    End Function

    '<HttpPost>
    '<ValidateAntiForgeryToken>
    'Public Function AccessRightsManager(entityVM As AccessRightsManagerViewModel) As ActionResult
    '    If (IsNothing(entityVM.ActionsId)) Then
    '        ModelState.AddModelError("", Resource.MdlStatError_ActionList)
    '    End If
    '    If ModelState.IsValid Then
    '        'Dans un Premier temps, on procède au nettoyage de la base de données en supprimant les anciens droits d'accès de l'utilisateur sur lequel les traitements sont effectués
    '        DeleteAccessRights(entityVM.SelectedAspNetUserId)
    '        For Each item In entityVM.ActionsId 'Pour chaque élément dans la liste (Ex: Id_ress-Id_act) on fera un split sur le "-" pour avoir l'id de la sous ressource et de l'action correspondante
    '            'Création d'un tableau IdArray  de chaînes de caractères qui recevra les deux identifiants après l'opération de split.
    '            'Le premier élément du tableau correspondra à l'identition de la sous ressource, et le second à l'identifiant de l'action.
    '            Dim IdArray As String() = item.Split(New Char() {"-"c})
    '            'Création d'un objet ActionSousRessource
    '            Dim actionSousRessource As New ActionSousRessource With {
    '            .ActionsId = IdArray(1),
    '            .SousRessourceId = IdArray(0),
    '            .AspNetUserId = entityVM.SelectedAspNetUserId,
    '            .DateCreation = Now,
    '            .StatutExistant = 1
    '            }
    '            Db.ActionSousRessource.Add(actionSousRessource)
    '            Try
    '                Db.SaveChanges()
    '            Catch ex As DbEntityValidationException
    '                Util.GetError(ex, ModelState)
    '            Catch ex As Exception
    '                Util.GetError(ex, ModelState)
    '            End Try
    '        Next
    '        Return RedirectToAction("Index")
    '    End If
    '    Return View(entityVM)
    'End Function

    ''' <summary>
    ''' Cette fonction permet de supprimer tous les anciens droits d'accès accordés à l'utilisateur dont l'identifiant est passé en paramètre.
    ''' </summary>
    ''' <param name="UserId"></param>
    Private Sub DeleteAccessRights(UserId As String)
        'On sélectionne tous les droits de l'utilsiateur
        Dim AllUserRights = (From e In Db.AspNetUserActionSousRessource Where e.AspNetUserId = UserId Select e).ToList()
        Db.AspNetUserActionSousRessource.RemoveRange(AllUserRights)
        Try
            Db.SaveChanges()
        Catch ex As DbEntityValidationException
            Util.GetError(ex, ModelState)
        Catch ex As Exception
            Util.GetError(ex, ModelState)
        End Try
    End Sub

    'Public Function Index() As ActionResult
    '    Dim items As New List(Of SelectListItem)()
    '    Dim entities As New VehiclesEntities()

    '    'Loop and add the Parent Nodes.
    '    For Each type As VehicleType In entities.VehicleTypes
    '        'Create the Group.
    '        Dim group As New SelectListGroup() With {
    '            .Name = type.Name
    '        }

    '        'Loop and add the Items.
    '        For Each subType As VehicleSubType In entities.VehicleSubTypes.Where(Function(v) v.VehicleTypeId = type.Id)
    '            items.Add(New SelectListItem() With {
    '                .Value = subType.Id.ToString(),
    '                .Text = subType.Name,
    '                .Group = group
    '            })
    '        Next
    '    Next

    '    Return View(items)
    'End Function
    '
    ' POST: /Account/Disassociate
    <HttpPost>
    <ValidateAntiForgeryToken>
    Public Async Function Disassociate(loginProvider As String, providerKey As String) As Task(Of ActionResult)
        Dim message As ManageMessageId? = Nothing
        Dim result As IdentityResult = Await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), New UserLoginInfo(loginProvider, providerKey))
        If result.Succeeded Then
            message = ManageMessageId.RemoveLoginSuccess
        Else
            message = ManageMessageId.UnknownError
        End If

        Return RedirectToAction("Manage", New With {
            message
        })
    End Function

    '
    ' GET: /Account/Manage
    Public Function ChangeUserPassword(ByVal message As ManageMessageId?) As ActionResult
        ViewData("StatusMessage") =
            If(message = ManageMessageId.ChangePasswordSuccess, Resource.GestUser_PwdModify,
            If(message = ManageMessageId.ChangePasswordImpossible, Resource.ChangePasswordImpossible,
                If(message = ManageMessageId.SetPasswordSuccess, Resource.GestUser_PwdDefine,
                    If(message = ManageMessageId.RemoveLoginSuccess, Resource.GestUser_DeleteConection,
                        If(message = ManageMessageId.UnknownError, Resource.GestUser_ErrorOccured,
                        "")))))
        ViewBag.HasLocalPassword = HasPassword()
        ViewBag.ReturnUrl = Url.Action("ChangeUserPassword")
        Return View()
    End Function

    '
    ' POST: /Account/ChangeUserPassword
    <HttpPost>
    <ValidateAntiForgeryToken>
    Public Async Function ChangeUserPassword(model As ManageUserViewModel) As Task(Of ActionResult)
        Dim hasLocalLogin As Boolean = HasPassword()
        ViewBag.HasLocalPassword = hasLocalLogin
        ViewBag.ReturnUrl = Url.Action("ChangeUserPassword")
        If hasLocalLogin Then
            If ModelState.IsValid Then
                Dim result As IdentityResult = Await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword)
                If result.Succeeded Then
                    Return RedirectToAction("ChangeUserPassword", New With {
                        .Message = ManageMessageId.ChangePasswordSuccess
                    })
                Else
                    'AddErrors(result)
                    Return RedirectToAction("ChangeUserPassword", New With {
                        .Message = ManageMessageId.ChangePasswordImpossible
                    })
                End If
            End If
        Else
            ' L’utilisateur ne possède pas de mot de passe local. Supprimez donc toutes les erreurs de validation causées par un champ OldPassword manquant
            Dim state As ModelState = ModelState("OldPassword")
            If state IsNot Nothing Then
                state.Errors.Clear()
            End If

            If ModelState.IsValid Then
                Dim result As IdentityResult = Await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword)
                If result.Succeeded Then
                    Return RedirectToAction("ChangeUserPassword", New With {
                        .Message = ManageMessageId.SetPasswordSuccess
                    })
                Else
                    AddErrors(result)
                End If
            End If
        End If

        ' Si nous sommes arrivés là, un échec s’est produit. Réafficher le formulaire
        Return View(model)
    End Function

    '
    ' POST: /Account/Manage
    '<HttpPost>
    '<ValidateAntiForgeryToken>
    'Public Async Function Manage(model As ManageUserViewModel) As Task(Of ActionResult)
    '    Dim hasLocalLogin As Boolean = HasPassword()
    '    ViewBag.HasLocalPassword = hasLocalLogin
    '    ViewBag.ReturnUrl = Url.Action("Manage")
    '    If hasLocalLogin Then
    '        If ModelState.IsValid Then
    '            Dim result As IdentityResult = Await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword)
    '            If result.Succeeded Then
    '                Return RedirectToAction("Manage", New With {
    '                    .Message = ManageMessageId.ChangePasswordSuccess
    '                })
    '            Else
    '                AddErrors(result)
    '            End If
    '        End If
    '    Else
    '        ' L’utilisateur ne possède pas de mot de passe local. Supprimez donc toutes les erreurs de validation causées par un champ OldPassword manquant
    '        Dim state As ModelState = ModelState("OldPassword")
    '        If state IsNot Nothing Then
    '            state.Errors.Clear()
    '        End If

    '        If ModelState.IsValid Then
    '            Dim result As IdentityResult = Await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword)
    '            If result.Succeeded Then
    '                Return RedirectToAction("Manage", New With {
    '                    .Message = ManageMessageId.SetPasswordSuccess
    '                })
    '            Else
    '                AddErrors(result)
    '            End If
    '        End If
    '    End If

    '    ' Si nous sommes arrivés là, un échec s’est produit. Réafficher le formulaire
    '    Return View(model)
    'End Function

    '
    ' POST: /Account/ExternalLogin
    <HttpPost>
    <AllowAnonymous>
    <ValidateAntiForgeryToken>
    Public Function ExternalLogin(provider As String, returnUrl As String) As ActionResult
        ' Demandez une redirection vers le fournisseur de connexions externe
        Return New ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", routeValues:=New With {returnUrl}))
    End Function

    '
    ' GET: /Account/ExternalLoginCallback
    <AllowAnonymous>
    Public Async Function ExternalLoginCallback(returnUrl As String) As Task(Of ActionResult)
        Dim loginInfo = Await AuthenticationManager.GetExternalLoginInfoAsync()
        If loginInfo Is Nothing Then
            Return RedirectToAction("Login")
        End If

        ' Sign in the user with this external login provider if the user already has a login
        Dim user = Await UserManager.FindAsync(loginInfo.Login)
        If user IsNot Nothing Then
            Await SignInAsync(user, isPersistent:=False)
            Return RedirectToLocal(returnUrl)
        Else
            ' If the user does not have an account, then prompt the user to create an account
            ViewBag.ReturnUrl = returnUrl
            ViewBag.LoginProvider = loginInfo.Login.LoginProvider
            Return View("ExternalLoginConfirmation", New ExternalLoginConfirmationViewModel() With {.UserName = loginInfo.DefaultUserName})
        End If
        Return View("ExternalLoginFailure")
    End Function

    '
    ' POST: /Account/LinkLogin
    <HttpPost>
    <ValidateAntiForgeryToken>
    Public Function LinkLogin(provider As String) As ActionResult
        ' Request a redirect to the external login provider to link a login for the current user
        Return New ChallengeResult(provider, Url.Action("LinkLoginCallback", "Account"), User.Identity.GetUserId())
    End Function

    '
    ' GET: /Account/LinkLoginCallback
    Public Async Function LinkLoginCallback() As Task(Of ActionResult)
        Dim loginInfo = Await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId())
        If loginInfo Is Nothing Then
            Return RedirectToAction("Manage", New With {
                .Message = ManageMessageId.UnknownError
            })
        End If
        Dim result = Await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login)
        If result.Succeeded Then
            Return RedirectToAction("Manage")
        End If
        Return RedirectToAction("Manage", New With {
            .Message = ManageMessageId.UnknownError
        })
    End Function

    '
    ' POST: /Account/ExternalLoginConfirmation
    <HttpPost>
    <AllowAnonymous>
    <ValidateAntiForgeryToken>
    Public Async Function ExternalLoginConfirmation(model As ExternalLoginConfirmationViewModel, returnUrl As String) As Task(Of ActionResult)
        If User.Identity.IsAuthenticated Then
            Return RedirectToAction("Manage")
        End If

        If ModelState.IsValid Then
            ' Obtenez des informations sur l’utilisateur auprès du fournisseur de connexions externe
            Dim info = Await AuthenticationManager.GetExternalLoginInfoAsync()
            If info Is Nothing Then
                Return View("ExternalLoginFailure")
            End If
            Dim user = New ApplicationUser() With {.UserName = model.UserName}
            Dim result = Await UserManager.CreateAsync(user)
            If result.Succeeded Then
                result = Await UserManager.AddLoginAsync(user.Id, info.Login)
                If result.Succeeded Then
                    Await SignInAsync(user, isPersistent:=False)
                    Return RedirectToLocal(returnUrl)
                End If
            End If
            AddErrors(result)
        End If

        ViewBag.ReturnUrl = returnUrl
        Return View(model)
    End Function

    '
    ' POST: /Account/LogOff
    <HttpPost>
    <ValidateAntiForgeryToken>
    Public Function LogOff() As ActionResult
        AuthenticationManager.SignOut()
        AppSession.AnneeBudgetaire = Nothing
        AppSession.LesAnneeBudgetaires = Nothing
        AppSession.CommuneId = Nothing
        AppSession.DepartementId = Nothing
        AppSession.RegionId = Nothing
        AppSession.UserId = Nothing
        AppSession.UserName = Nothing
        AppSession.NomUser = Nothing
        AppSession.PrenomUser = Nothing
        AppSession.ListEvenementZone = Nothing
        AppSession.Niveau = Nothing
        Return RedirectToAction("Login", "Logins")
    End Function

    '
    ' GET: /Account/ExternalLoginFailure
    <AllowAnonymous>
    Public Function ExternalLoginFailure() As ActionResult
        Return View()
    End Function

    <ChildActionOnly>
    Public Function RemoveAccountList() As ActionResult
        Dim linkedAccounts = UserManager.GetLogins(User.Identity.GetUserId())
        ViewBag.ShowRemoveButton = linkedAccounts.Count > 1 Or HasPassword()
        Return DirectCast(PartialView("_RemoveAccountPartial", linkedAccounts), ActionResult)
    End Function

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso UserManager IsNot Nothing Then
            UserManager.Dispose()
            UserManager = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Assistants"
    ' Used for XSRF protection when adding external logins
    Private Const XsrfKey As String = "XsrfId"

    Private Function AuthenticationManager() As IAuthenticationManager
        Return HttpContext.GetOwinContext().Authentication
    End Function

    Private Async Function SignInAsync(user As ApplicationUser, isPersistent As Boolean) As Task
        AuthenticationManager.SignOut(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ExternalCookie)
        Dim identity = Await UserManager.CreateIdentityAsync(user, Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ApplicationCookie)
        AuthenticationManager.SignIn(New AuthenticationProperties() With {.IsPersistent = isPersistent}, identity)
    End Function

    Private Sub AddErrors(result As IdentityResult)
        For Each [error] As String In result.Errors
            ModelState.AddModelError("", [error])
        Next
    End Sub

    Private Function HasPassword() As Boolean
        Dim appUser = UserManager.FindById(User.Identity.GetUserId())
        If (appUser IsNot Nothing) Then
            Return appUser.PasswordHash IsNot Nothing
        End If
        Return False
    End Function

    Private Function RedirectToLocal(returnUrl As String) As ActionResult
        If Url.IsLocalUrl(returnUrl) Then
            Return Redirect(returnUrl)
        Else
            Return RedirectToAction("Index", "Home")
        End If
    End Function

    Public Enum ManageMessageId
        ChangePasswordImpossible
        ChangePasswordSuccess
        SetPasswordSuccess
        RemoveLoginSuccess
        UnknownError
    End Enum

    Private Class ChallengeResult
        Inherits HttpUnauthorizedResult
        Public Sub New(provider As String, redirectUri As String)
            Me.New(provider, redirectUri, Nothing)
        End Sub
        Public Sub New(provider As String, redirectUri As String, userId As String)
            Me.LoginProvider = provider
            Me.RedirectUri = redirectUri
            Me.UserId = userId
        End Sub

        Public Property LoginProvider As String
        Public Property RedirectUri As String

        Public Property UserId As String

        Public Overrides Sub ExecuteResult(context As ControllerContext)
            Dim properties = New AuthenticationProperties() With {.RedirectUri = RedirectUri}
            If UserId IsNot Nothing Then
                properties.Dictionary(XsrfKey) = UserId
            End If
            context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider)
        End Sub
    End Class
#End Region

End Class
