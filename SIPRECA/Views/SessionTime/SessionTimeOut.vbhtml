@ModelType LoginViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.SessionExpired
    Layout = "~/Views/Shared/_LayoutLogin.vbhtml"
End Code

<div class="card-authentication2 mx-auto my-5 animated fadeInDown">
    <div class="card-group">
        <div class="card mb-0">
            <div class="bg-signin2"></div>
            <div class="card-img-overlay rounded-left my-5">
                <h4 class="text-white">@Resource.AppTitle</h4>
                <h1 class="text-white">@Resource.Minatd</h1>
                <p class="card-text text-justify text-black pt-3">@Resource.CrisysIntro</p>
            </div>
        </div>
        <div class="card mb-0">
            <div class="card-body">
                <div class="card-content p-3">
                    <div class="card-title text-uppercase text-center pb-3">@Resource.SessionExpired</div>
                    <p Class="locked-user" style="color: black"> @ViewBag.UserName</p>
                    @Using Html.BeginForm("SessionTimeOut", "SessionTime", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.role = "form"})
                        @Html.AntiForgeryToken()
                        @Html.ValidationSummary(True)

                        @Html.HiddenFor(Function(m) m.UserName)

                        @<div Class="form-group">
                            <div Class="position-relative has-icon-left">
                                @Html.LabelFor(Function(m) m.Password, New With {.class = "sr-only"})
                                @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control", .placeholder = Resource.GestPassWord})
                                <div Class="form-control-position">
                                    <i Class="icon-lock"></i>
                                </div>
                            </div>
                        </div>

                        @<div Class="clearfix"></div>
                        @<div Class="text-center pt-3">
                            <hr>
                            <button type="submit" value="@Resource.BtnLogIn" class="btn btn-primary btn-block">@Resource.BtnLogIn</button>
                        </div>

                        @<div class="form-group">
                            <div class="clearfix"></div>
                            <div class="text-center pt-3">
                                <hr>
                                <p class="text-center pb-2"  style="color: black">@Resource.LockScreenMsg</p>
                                <p class="text-muted"><a href=@Url.Action("Login", "Logins")>@Resource.LockScreenMsgOther</a></p>
                            </div>
                        </div>

                    End Using
                </div>
            </div>
        </div>
    </div>
</div>

