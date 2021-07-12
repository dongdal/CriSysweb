Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.Owin.Security
Imports System.Threading
Imports SIPRECA.My.Resources

'<LocalizedAuthorize>
'<SessionExpireFilter>
Public Class LoginsController
    Inherits Controller

    Protected Overrides Function BeginExecuteCore(callback As AsyncCallback, state As Object) As IAsyncResult
        Dim cultureName As String = TryCast(RouteData.Values("culture"), String)

        ' Attempt to read the culture cookie from Request
        If cultureName Is Nothing Then
            cultureName = If(Request.UserLanguages IsNot Nothing AndAlso Request.UserLanguages.Length > 0, Request.UserLanguages(0), Nothing)
        End If
        ' obtain it from HTTP header AcceptLanguages
        ' Validate culture name
        cultureName = CultureHelper.GetImplementedCulture(cultureName)
        ' This is safe

        If TryCast(RouteData.Values("culture"), String) <> cultureName Then

            ' Force a valid culture in the URL
            RouteData.Values("culture") = cultureName.ToLowerInvariant()
            ' lower case too
            ' Redirect user
            Response.RedirectToRoute(RouteData.Values)
        End If


        ' Modify current thread's cultures            
        Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo(cultureName)
        Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture


        Return MyBase.BeginExecuteCore(callback, state)
    End Function

    Private Function GetUsers() As ApplicationUser
        Dim id = User.Identity.GetUserId
        Dim aspuser = Db.Users.Find(id)
        Return aspuser
    End Function
    Private Function RecuperUserName() As String
        Return User.Identity.GetUserName
    End Function

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

    Public Property UserManager As UserManager(Of ApplicationUser) '

    Private Function AuthenticationManager() As IAuthenticationManager
        Return HttpContext.GetOwinContext().Authentication
    End Function

    Private Async Function SignInAsync(user As ApplicationUser, isPersistent As Boolean) As Task
        AuthenticationManager.SignOut(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ExternalCookie)
        Dim identity = Await UserManager.CreateIdentityAsync(user, Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ApplicationCookie)
        AuthenticationManager.SignIn(New AuthenticationProperties() With {.IsPersistent = isPersistent}, identity)
    End Function


    '
    ' GET: /Account/Login
    <AllowAnonymous>
    Public Function Login(returnUrl As String) As ActionResult
        ViewBag.ReturnUrl = returnUrl
        Dim model As New LoginViewModel
        'LoadComboBox(model)
        Return View(model)
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

        AppSession.DateFormat = "dd-MM-yyyy"

        Long.TryParse(appUser.CommuneId.ToString, AppSession.CommuneId)
        Long.TryParse(appUser.DepartementId.ToString, AppSession.DepartementId)
        Long.TryParse(appUser.RegionId.ToString, AppSession.RegionId)
    End Sub

    '
    ' POST: /Account/Login
    <HttpPost>
    <AllowAnonymous>
    <ValidateAntiForgeryToken>
    Public Async Function Login(model As LoginViewModel, returnUrl As String) As Task(Of ActionResult)
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
        'LoadComboBox(model)
        Return View(model)
    End Function

    Function AccountLocked(TempsRestant As Long, Optional MyAction As String = "Login", Optional Controleur As String = "Logins") As ActionResult
        ViewBag.TempsRestant = TempsRestant * 60 & " Sec (" & TempsRestant & " Min)"
        ViewBag.Action = MyAction
        ViewBag.Controleur = Controleur
        Return View()
    End Function

    '
    ' POST: /Account/LogOff
    <HttpPost>
    <ValidateAntiForgeryToken>
    Public Function LogOff() As ActionResult
        Session.Abandon()
        Session.RemoveAll()
        AuthenticationManager.SignOut()
        Return RedirectToAction("Login", "Logins")
    End Function

End Class
