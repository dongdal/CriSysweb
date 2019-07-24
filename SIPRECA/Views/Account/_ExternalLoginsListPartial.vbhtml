@Imports Microsoft.Owin.Security
@Code
    Dim loginProviders = Context.GetOwinContext().Authentication.GetExternalAuthenticationTypes()
End Code
<h4>Utilisez un autre service pour vous connecter.</h4>
<hr />
@If loginProviders.Count() = 0 Then
    @<div>
        <p>
            Il n'y a pas de services d'authentification externes configurés. Consultez <a href="http://go.microsoft.com/fwlink/?LinkId=313242">cet article</a>
            pour plus de détails sur la configuration de cette application ASP.NET afin de permettre la connexion via des services externes.
        </p>
    </div>
Else
    Dim action As String = Model.Action
    Dim returnUrl As String = Model.ReturnUrl
    @Using Html.BeginForm(action, "Account", New With {.ReturnUrl = returnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
        @Html.AntiForgeryToken()
        @<div id="socialLoginList">
           <p>
               @For Each p As AuthenticationDescription In loginProviders
                   @<button type="submit" class="btn btn-default" id="@p.AuthenticationType" name="provider" value="@p.AuthenticationType" title="Connectez-vous avec votre compte @p.Caption">@p.AuthenticationType</button>
               Next
           </p>
        </div>
    End Using
End If
