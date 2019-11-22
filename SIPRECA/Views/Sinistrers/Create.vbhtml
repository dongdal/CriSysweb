@ModelType SinistrerViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.CreateSinistrer
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageSinistrer</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Sinistrers")>@Resource.ManageSinistrer</a></li>
        <li class="breadcrumb-item active">@Resource.CreateSinistrer</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.CreateSinistrer</div>
            <hr>
            @Using Html.BeginForm("Create", "Sinistrers", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Cni, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Cni, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.CNIPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Cni, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Nom, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Nom, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.NamePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Nom, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Prenom, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Prenom, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.CNIPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Prenom, "", New With {.style = "color: #da0b0b"})
                    </div>
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

                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Telephone, New With {.class = "col-sm-2 col-form-label "})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Telephone, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.Telephone1Placeholder})
                        @Html.ValidationMessageFor(Function(m) m.Telephone, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Email, New With {.class = "col-sm-2 col-form-label "})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.EmailPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.DateDeNaissance, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.DateDeNaissance, New With {.class = "form-control form-control-square default-datepicker", .tabindex = "4", .Placeholder = Resource.DateSinistrePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.DateDeNaissance, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.DateDeclaration, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.DateDeclaration, New With {.class = "form-control form-control-square default-datepicker", .tabindex = "3", .Placeholder = Resource.DateDeclarationPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.DateDeclaration, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>
                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.CollectiviteSinistreeId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.CollectiviteSinistreeId, New SelectList(Model.LesCollectiviteSinistrees, "Value", "Text"), Resource.ComboCollectiviteSinistree,
New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboCollectiviteSinistree})
                        @Html.ValidationMessageFor(Function(m) m.CollectiviteSinistreeId, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Observation, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextAreaFor(Function(m) m.Observation, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.ReferencePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Observation, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    <Label Class="col-sm-2 col-form-label"></Label>
                    <div Class="col-sm-10">
                        <Button type="submit" Class="btn btn-link btn-square bg-primary text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.BtnSave</Button>
                        &nbsp;&nbsp;&nbsp;
                        @Html.ActionLink(Resource.BtnCancel, "Index", Nothing, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                        &nbsp;&nbsp;&nbsp;
                        <Button type="submit" Class="btn btn-link btn-square bg-info text-dark shadow px-5" name="AddPieces"><i Class="icon-docs"></i> @Resource.BtnPieces</Button>
                    </div>
                </div>

            End Using

        </div>
    </div>
</div>
