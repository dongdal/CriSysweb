@ModelType SinistrerViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.DeleteSinistrer
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageSinistrer</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Sinistrers")>@Resource.ManageSinistrer</a></li>
        <li class="breadcrumb-item active">@Resource.DeleteSinistrer</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.DeleteSinistrer</div>
            <hr>
            @Using Html.BeginForm("Delete", "Sinistrers", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()
                @Html.ValidationSummary(True)
                @Html.HiddenFor(Function(m) m.Id)
                @Html.HiddenFor(Function(m) m.StatutExistant)
                @Html.HiddenFor(Function(m) m.DateCreation)
                @Html.HiddenFor(Function(m) m.AspNetUserId)

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Cni, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Cni, New With {.class = "form-control form-control-square", .readonly = "true", .tabindex = "1", .Placeholder = Resource.CNIPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Cni, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Nom, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Nom, New With {.class = "form-control form-control-square", .readonly = "true", .tabindex = "1", .Placeholder = Resource.NamePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Nom, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Prenom, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Prenom, New With {.class = "form-control form-control-square", .readonly = "true", .tabindex = "1", .Placeholder = Resource.CNIPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Prenom, "", New With {.style = "color: #da0b0b"})
                    </div>
                    @Html.LabelFor(Function(m) m.Sexe, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-md-4">
                        <div class="icheck-material-dark icheck-inline">
                            @Html.RadioButtonFor(Function(m) m.Sexe, "Male", New With {.id = "Male", .checked = "checked", .disabled = "disabled"})
                            @Html.Label(Resource.GenderMale, New With {.for = "Male", .tabindex = "6"})
                        </div>
                        <div class="icheck-material-dark icheck-inline">
                            @Html.RadioButtonFor(Function(m) m.Sexe, "Female", New With {.id = "Female", .disabled = "disabled"})
                            @Html.Label(Resource.GenderFemale, New With {.for = "Female", .tabindex = "7"})
                        </div>
                    </div>

                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Telephone, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Telephone, New With {.class = "form-control form-control-square", .readonly = "true", .tabindex = "1", .Placeholder = Resource.Telephone1Placeholder})
                        @Html.ValidationMessageFor(Function(m) m.Telephone, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Email, New With {.class = "col-sm-2 col-form-label "})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control form-control-square", .readonly = "true", .tabindex = "1", .Placeholder = Resource.EmailPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.DateDeNaissance, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.DateDeNaissance, New With {.class = "form-control form-control-square default-datepicker", .tabindex = "4", .Placeholder = Resource.DateNaissancePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.DateDeNaissance, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    <Label Class="col-sm-2 col-form-label"></Label>
                    <div Class="col-sm-10">
                        <Button type="submit" Class="btn btn-link btn-square bg-danger text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.Btn_Delete</Button>
                        &nbsp;&nbsp;&nbsp;
                        @Html.ActionLink(Resource.BtnCancel, "Index", Nothing, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                    </div>
                </div>

            End Using

        </div>
    </div>
</div>
