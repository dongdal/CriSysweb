Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.Owin.Security
Imports SIPRECA.My.Resources

Public Class SessionTimeController
    Inherits Controller

    Private Function GetUsers() As ApplicationUser
        Dim id = User.Identity.GetUserId
        Return Db.Users.Find(id)
    End Function
    Private Function RecuperUserName() As String
        Return User.Identity.GetUserName
    End Function


    Public Sub New()
        Me.New(New UserManager(Of ApplicationUser)(New UserStore(Of ApplicationUser)(New ApplicationDbContext())))
    End Sub

    Public Sub New(manager As UserManager(Of ApplicationUser))
        If manager Is Nothing Then
            Throw New ArgumentNullException("manager")
        End If
        UserManager = manager
    End Sub

    Public Property UserManager As UserManager(Of ApplicationUser) '

    Private _Db As New ApplicationDbContext
    Public Property Db As ApplicationDbContext
        Get
            Return _Db
        End Get
        Set(value As ApplicationDbContext)
            If value Is Nothing Then
                Throw New ArgumentNullException("value")
            End If
            _Db = value
        End Set
    End Property

    Private Function AuthenticationManager() As IAuthenticationManager
        Return HttpContext.GetOwinContext().Authentication
    End Function

    Private Async Function SignInAsync(user As ApplicationUser, isPersistent As Boolean) As Task
        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie)
        Dim identity = Await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie)
        AuthenticationManager.SignIn(New AuthenticationProperties() With {.IsPersistent = isPersistent}, identity)
    End Function

    ' GET: /SessionTime/SessionTimeOut
    <AllowAnonymous>
    Public Function SessionTimeOut(returnUrl As String) As ActionResult
        ViewBag.ReturnUrl = returnUrl
        ViewBag.UserName = RecuperUserName()
        Return View(New LoginViewModel With {
            .UserName = RecuperUserName()
        })
    End Function


    ''' <summary>
    ''' Cette fonction permet d'attribuer une valeur aux différentes variable de session qui seront utilisées tout au long de l'exécution du programme. Il prend en paramètre l'utilisateur qui vient de se connecter
    ''' </summary>
    ''' <param name="appUser"></param>
    Private Sub InitAppSessionValues(ByVal appUser As ApplicationUser)
        AppSession.UserId = appUser.Id
        AppSession.NomUser = appUser.Nom
        AppSession.PrenomUser = appUser.Prenom
        AppSession.UserName = appUser.UserName
        AppSession.Niveau = appUser.Niveau
        Dim ListUserActionSousResource = (From e In Db.AspNetUserActionSousRessource Where e.AspNetUserId.Equals(AppSession.UserId) Select e).ToList()
        AppSession.ListUserActionSousResource = IIf(IsNothing(ListUserActionSousResource), New List(Of AspNetUserActionSousRessource), ListUserActionSousResource)
        AppSession.ModuleUserList = (From m In AppSession.ListUserActionSousResource Select m.ActionSousRessource.SousRessource.Ressource.Modules.Id).ToList()
        AppSession.ListRessources = (From res In AppSession.ListUserActionSousResource Select res.ActionSousRessource.SousRessource.Ressource.Id).ToList()
        AppSession.ListSousRessources = (From res In AppSession.ListUserActionSousResource Select res.ActionSousRessource.SousRessource.Id).ToList()
        AppSession.ListActionSousRessource = (From actRes In AppSession.ListUserActionSousResource Select actRes.ActionSousRessource).ToList()
        Long.TryParse(appUser.CommuneId.ToString, AppSession.CommuneId)
        Long.TryParse(appUser.DepartementId.ToString, AppSession.DepartementId)
        Long.TryParse(appUser.RegionId.ToString, AppSession.RegionId)
    End Sub

    '
    ' POST: /SessionTime/SessionTimeOut
    <HttpPost>
    <AllowAnonymous>
    <ValidateAntiForgeryToken>
    Public Async Function SessionTimeOut(model As LoginViewModel, returnUrl As String) As Task(Of ActionResult)
        If ModelState.IsValid Then
            ' Valider le mot de passe
            'Dim appUser = Await UserManager.FindAsync(model.UserName, model.Password)

            Dim appUser As ApplicationUser = Await UserManager.FindByNameAsync(model.UserName)
            ' Invalid user, fail login
            If appUser Is Nothing Then
                ModelState.AddModelError("", Resource.InvalidParam)
            ElseIf (Await UserManager.IsLockedOutAsync(appUser.Id) And Await UserManager.GetLockoutEndDateAsync(appUser.Id) > DateTime.UtcNow.AddHours(1)) Then
                Dim TempsRestant = DateDiff(DateInterval.Minute, appUser.LockoutEndDateUtc.Value, DateTime.UtcNow.AddHours(1)) 'appUser.LockoutEndDateUtc.Value.Subtract(DateTime.UtcNow.AddHours(1)).Seconds
                Return RedirectToAction("AccountLocked", "Logins", New With {TempsRestant, .MyAction = "Login", .Controleur = "Logins"})
            Else
                Dim result As Object = UserManager.PasswordHasher.VerifyHashedPassword(appUser.PasswordHash, model.Password)
                If result = PasswordVerificationResult.Success Then
                    InitAppSessionValues(appUser)
                    appUser.AccessFailedCount = 0
                    appUser.LockoutEndDateUtc = Nothing
                    appUser.LockoutEnabled = False
                    UserManager.Update(appUser)
                    Await SignInAsync(appUser, model.RememberMe)
                    Return RedirectToAction("Index", "Home")
                Else
                    ' Failed login, increment failed login counter
                    ' Lockout for 15 minutes if more than 10 failed attempts
                    Dim AccessFailedCount As Integer = ConfigurationManager.AppSettings("AccessFailedCount")

                    appUser.AccessFailedCount += 1
                    If appUser.AccessFailedCount >= AccessFailedCount Then
                        appUser.LockoutEndDateUtc = DateTime.UtcNow.AddHours(1).AddMinutes(10)
                        appUser.LockoutEnabled = True
                    End If
                    UserManager.Update(appUser)
                    Return View(model)
                End If
            End If
        End If
        ' Si nous sommes arrivés là, un échec s’est produit. Réafficher le formulaire
        Return View(model)
    End Function

    'Public Async Function SessionTimeOut(model As LoginViewModel, returnUrl As String) As Task(Of ActionResult)
    '    If ModelState.IsValid Then
    '        ' Valider le mot de passe

    '        If (Await UserManager.FindAsync(model.UserName, model.Password)) IsNot Nothing Then
    '            Await SignInAsync(Await UserManager.FindAsync(model.UserName, model.Password), model.RememberMe)
    '            Dim user = UserManager.Find(model.UserName, model.Password)
    '            AppSession.UserId = user.Id
    '            AppSession.NomUser = user.Nom
    '            AppSession.PrenomUser = user.Prenom
    '            AppSession.UserName = user.UserName
    '            AppSession.Niveau = user.Niveau
    '            Long.TryParse(user.CommuneId.ToString, AppSession.CommuneId)
    '            Long.TryParse(user.DepartementId.ToString, AppSession.DepartementId)
    '            Long.TryParse(user.RegionId.ToString, AppSession.RegionId)

    '            Return RedirectToAction("Index", "Home")
    '        Else
    '            'ModelState.AddModelError("", Resource.InvalidParam)
    '            Return RedirectToAction("SessionTimeOut", "SessionTime")
    '        End If
    '    End If

    '    ' Si nous sommes arrivés là, un échec s’est produit. Réafficher le formulaire
    '    Return View(model:=model)
    'End Function


    <HttpPost>
    <ValidateAntiForgeryToken>
    Public Function RedirectLogin() As ActionResult
        Session.Abandon()
        Session.RemoveAll()
        AuthenticationManager.SignOut()
        Return RedirectToAction("Login", "Logins")
    End Function

    '
    ' POST: /Account/LogOff
    <HttpPost>
    <ValidateAntiForgeryToken>
    Public Function LogOff() As ActionResult
        Session.Abandon()
        Session.RemoveAll()
        AuthenticationManager.SignOut()
        Return RedirectToAction("Login", "Account")
    End Function

End Class