@ModelType RegisterViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.Register
    Layout = "~/Views/Shared/_LayoutPrincipal.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.Menu_UserManager</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Account")>@Resource.Menu_UserManager</a></li>
        <li class="breadcrumb-item active">@Resource.RegisterUser</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.RegisterForm</div>
            <hr>
            @Using Html.BeginForm("Register", "Account", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Nom, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Nom, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.NamePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Nom, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Prenom, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Prenom, New With {.class = "form-control form-control-square", .tabindex = "2", .Placeholder = Resource.PrenomPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Prenom, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.DateNaissance, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.DateNaissance, New With {.class = "form-control form-control-square default-datepicker", .tabindex = "3", .Placeholder = Resource.DateNaissancePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.DateNaissance, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.LieuNaissance, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.LieuNaissance, New With {.class = "form-control form-control-square", .tabindex = "4", .Placeholder = Resource.LieuNaissancePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.LieuNaissance, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @*@Html.LabelFor(Function(m) m.Sexe, New With {.class = "col-sm-2 col-form-label"})
                        <div class="col-sm-4">
                            @Html.TextBoxFor(Function(m) m.Sexe, New With {.class = "form-control form-control-square", .tabindex = "5"})
                            @Html.ValidationMessageFor(Function(m) m.Sexe)
                        </div>*@
                    @Html.LabelFor(Function(m) m.Sexe, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-md-4">
                        <div class="icheck-material-dark icheck-inline">
                            @Html.RadioButtonFor(Function(m) m.Sexe, "Male", New With {.id = "Male", .checked = "checked"})
                            @Html.Label(Resource.GenderMale, New With {.for = "Male", .tabindex = "6"})
                        </div>
                        <div class="icheck-material-dark icheck-inline">
                            @Html.RadioButtonFor(Function(m) m.Sexe, "Female", New With {.id = "Female"})
                            @Html.Label(Resource.GenderFemale, New With {.for = "Female", .tabindex = "7"})
                        </div>
                    </div>

                    @Html.LabelFor(Function(m) m.CNI, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.CNI, New With {.class = "form-control form-control-square", .tabindex = "8", .Placeholder = Resource.CNIPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.CNI, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.DateDelivranceCNI, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.DateDelivranceCNI, New With {.class = "form-control form-control-square default-datepicker", .tabindex = "9", .Placeholder = Resource.DelivranceCNIPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.DateDelivranceCNI, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.DateExpirationCNI, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.DateExpirationCNI, New With {.class = "form-control form-control-square default-datepicker", .tabindex = "10", .Placeholder = Resource.ExpirationCNIPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.DateExpirationCNI, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Telephone, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Telephone, New With {.class = "form-control form-control-square", .tabindex = "11", .Placeholder = Resource.Telephone1Placeholder})
                        @Html.ValidationMessageFor(Function(m) m.Telephone, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Telephone2, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Telephone2, New With {.class = "form-control form-control-square", .tabindex = "12", .Placeholder = Resource.Telephone2Placeholder})
                        @Html.ValidationMessageFor(Function(m) m.Telephone2, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Email, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control form-control-square", .tabindex = "13", .Placeholder = Resource.EmailPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.AdresseUser, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextAreaFor(Function(m) m.AdresseUser, New With {.class = "form-control form-control-square", .tabindex = "14", .Placeholder = Resource.AdressePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.AdresseUser, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.UserName, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.UserName, New With {.class = "form-control form-control-square", .tabindex = "15", .Placeholder = Resource.UserNamePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.UserName, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Password, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control form-control-square", .tabindex = "16", .Placeholder = Resource.PasswordPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Password, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">

                    @Html.LabelFor(Function(m) m.ConfirmPassword, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.PasswordFor(Function(m) m.ConfirmPassword, New With {.class = "form-control form-control-square", .tabindex = "17", .Placeholder = Resource.ConfirmPasswordPlacehoder})
                        @Html.ValidationMessageFor(Function(m) m.ConfirmPassword, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    <Label Class="col-sm-2 col-form-label"></Label>
                    <div Class="col-sm-10">
                        <Button type="submit" Class="btn btn-link btn-square bg-primary text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.BtnSave</Button>
                        &nbsp;&nbsp;&nbsp;
                        @Html.ActionLink(Resource.BtnCancel, "Index", Nothing, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                    </div>
                </div>

            End Using

        </div>
    </div>
</div>
