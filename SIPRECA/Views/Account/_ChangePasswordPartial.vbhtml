@Imports Microsoft.AspNet.Identity
@Imports SIPRECA.My.Resources
@ModelType SIPRECA.ManageUserViewModel


<p class="text-info"><h4>@Resource.ConnectedAs <strong style="color: #3f51b5; font-weight:bolder">@User.Identity.GetUserName()</strong></h4></p>

<br />

<div Class="form-group row">
    @Html.LabelFor(Function(m) m.OldPassword, New With {.class = "col-sm-3 col-form-label required_field"})
    <div class="col-sm-4">
        @Html.PasswordFor(Function(m) m.OldPassword, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.GestUserActualPwd})
        @Html.ValidationMessageFor(Function(m) m.OldPassword, "", New With {.style = "color: #da0b0b"})
    </div>
</div>

<div Class="form-group row">
    @Html.LabelFor(Function(m) m.NewPassword, New With {.class = "col-sm-3 col-form-label required_field"})
    <div class="col-sm-4">
        @Html.PasswordFor(Function(m) m.NewPassword, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.GestUserPwdNew})
        @Html.ValidationMessageFor(Function(m) m.NewPassword, "", New With {.style = "color: #da0b0b"})
    </div>
</div>


<div Class="form-group row">
    @Html.LabelFor(Function(m) m.ConfirmPassword, New With {.Class = "col-sm-3 col-form-label required_field"})
    <div class="col-sm-4">
        @Html.PasswordFor(Function(m) m.ConfirmPassword, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.GestUserPwdConfNew})
        @Html.ValidationMessageFor(Function(m) m.ConfirmPassword, "", New With {.style = "color: #da0b0b"})
    </div>
</div>




