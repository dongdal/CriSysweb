@ModelType LoginViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.ConnectTitle
    Layout = "~/Views/Shared/_LayoutLogin.vbhtml"
End Code


<div class="card-authentication2 mx-auto my-3 animated slideInLeft">
    <div class="card-group">
        <div class="card mb-0">
            <div class="bg-signin2"></div>
            <div class="card-img-overlay rounded-left my-5">
                <h4 class="text-white">@Resource.AppTitle</h4>
                <h1 class="text-white">@Resource.Minatd</h1>
                <p class="card-text text-white pt-3">There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.</p>
            </div>
        </div>
        <div class="card mb-0">
            <div class="card-body">
                <div class="card-content p-3">
                    <div class="text-center">
                        <img src="~/assets/images/logo-icon.png" />
                    </div>
                    <div class="card-title text-uppercase text-center py-2">@Resource.ConnectForm</div>

                    @Using Html.BeginForm("Login", "Logins", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.autocomplete = "off"})
                        @Html.AntiForgeryToken()


                        @<div Class="form-group">
                             <div Class="position-relative has-icon-left">
                                 @Html.LabelFor(Function(m) m.UserName, New With {.class = "sr-only"})
                                 @Html.TextBoxFor(Function(m) m.UserName, New With {.class = "form-control", .placeholder = Resource.GestUserName})
                                 @Html.ValidationMessageFor(Function(m) m.UserName, "", New With {.style = "color: red"})
                                 <div Class="form-control-position">
                                     <i Class="icon-user"></i>
                                 </div>
                             </div>
                        </div>


                        @<div Class="form-group">
                             <div Class="position-relative has-icon-left">
                                 @Html.LabelFor(Function(m) m.Password, New With {.class = "sr-only"})
                                 @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control", .placeholder = Resource.GestPassWord})
                                 @Html.ValidationMessageFor(Function(m) m.Password, "", New With {.style = "color: red"})
                                 <div Class="form-control-position">
                                     <i Class="icon-lock"></i>
                                 </div>
                             </div>
                        </div>

                        @<div class="form-group clearfix">

                            @Html.CheckBoxFor(Function(m) m.RememberMe, New With {.style = "width: 19px; height: 19px; cursor: pointer; position: absolute; left: 2px; top: 2px; background: #fff; border: 1px solid #999; display: inline-block; position: relative; margin: 0 auto; float: left;"})
                            &nbsp;&nbsp;
                            @Html.LabelFor(Function(m) m.RememberMe)
                        </div>
                        @<button type="submit" value="@Resource.BtnLogIn" class="btn btn-primary btn-block">@Resource.BtnLogIn</button>
                    End Using

                </div>
            </div>
        </div>
    </div>
</div>

