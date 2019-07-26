Imports System.Data.Entity
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

    '
    ' GET: /Account/Register
    <AllowAnonymous>
    Public Function Register() As ActionResult
        Dim model = New RegisterViewModel()
        Return View(model)
    End Function

    '
    ' POST: /Account/Register
    <HttpPost>
    <AllowAnonymous>
    <ValidateAntiForgeryToken>
    Public Async Function Register(model As RegisterViewModel) As Task(Of ActionResult)
        If ModelState.IsValid Then
            ' Créer un identifiant local avant de connecter l'utilisateur
            Dim user = model.GetUser ' New ApplicationUser() With {.UserName = model.UserName}
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

        Return View(model)
    End Function

    '<LocalizedAuthorize(Roles:="Administrateur")>
    Public Function Edit(id As String, Optional Message As ManageMessageId? = Nothing) As ActionResult
        If IsNothing(id) Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If
        Dim user = Db.Users.Find(id)
        If IsNothing(user) Then
            Return HttpNotFound()
        End If

        ViewBag.MessageId = Message
        Dim model As New EditUserViewModel(user:=user)
        Return View(model)
    End Function

    '<LocalizedAuthorize(Roles:="Administrateur")>
    <HttpPost>
    <ValidateAntiForgeryToken>
    Public Async Function Edit(model As EditUserViewModel) As Task(Of ActionResult)
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
        Return View(model)
    End Function

    'Get
    '<LocalizedAuthorize(Roles:="Administrateur")>
    Public Function UserRoles(id As String) As ActionResult
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
        If ModelState.IsValid Then
            Dim idManager = New IdentityManager()
            Dim user = Db.Users.Find(model.Id)
            idManager.ClearUserRoles(user.Id)
            For Each role As SelectRoleEditorViewModel In model.Roles
                If role.Selected Then
                    idManager.AddUserToRole(user.Id, role.RoleName)
                End If
            Next
            Return RedirectToAction("Index")
        End If
        Return View()
    End Function


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
    ' POST: /Account/Manage
    <HttpPost>
    <ValidateAntiForgeryToken>
    Public Async Function Manage(model As ManageUserViewModel) As Task(Of ActionResult)
        Dim hasLocalLogin As Boolean = HasPassword()
        ViewBag.HasLocalPassword = hasLocalLogin
        ViewBag.ReturnUrl = Url.Action("Manage")
        If hasLocalLogin Then
            If ModelState.IsValid Then
                Dim result As IdentityResult = Await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword)
                If result.Succeeded Then
                    Return RedirectToAction("Manage", New With {
                        .Message = ManageMessageId.ChangePasswordSuccess
                    })
                Else
                    AddErrors(result)
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
                    Return RedirectToAction("Manage", New With {
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
