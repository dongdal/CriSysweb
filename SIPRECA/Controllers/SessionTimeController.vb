Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.Owin.Security

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


    '
    ' POST: /SessionTime/SessionTimeOut
    <HttpPost>
    <AllowAnonymous>
    <ValidateAntiForgeryToken>
    Public Async Function SessionTimeOut(model As LoginViewModel, returnUrl As String) As Task(Of ActionResult)
        If ModelState.IsValid Then
            ' Valider le mot de passe

            If (Await UserManager.FindAsync(model.UserName, model.Password)) IsNot Nothing Then
                Await SignInAsync(Await UserManager.FindAsync(model.UserName, model.Password), model.RememberMe)

                AppSession.UserId = (Await UserManager.FindAsync(model.UserName, model.Password)).Id
                AppSession.NomUser = (Await UserManager.FindAsync(model.UserName, model.Password)).Nom
                AppSession.PrenomUser = (Await UserManager.FindAsync(model.UserName, model.Password)).Prenom
                AppSession.UserName = (Await UserManager.FindAsync(model.UserName, model.Password)).UserName

                Return RedirectToAction("Index", "Home")
            Else
                'ModelState.AddModelError("", Resource.InvalidParam)
                Return RedirectToAction("SessionTimeOut", "SessionTime")
            End If
        End If

        ' Si nous sommes arrivés là, un échec s’est produit. Réafficher le formulaire
        Return View(model:=model)
    End Function


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