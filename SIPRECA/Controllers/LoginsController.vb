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
        Dim aspuser = db.Users.Find(id)
        Return aspuser
    End Function
    Private Function RecuperUserName() As String
        Return User.Identity.GetUserName
    End Function

    Private db As New ApplicationDbContext

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
                'Return RedirectToAction("Login", "Account")
                ModelState.AddModelError("", Resource.InvalidParam)
            End If
        End If

        ' Si nous sommes arrivés là, un échec s’est produit. Réafficher le formulaire
        Return View(model)
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
