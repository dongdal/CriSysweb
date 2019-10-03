@ModelType ProjetViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.CreateProjet
    Layout = "~/Views/Shared/_LayoutSahana.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageProjet</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Projets")>@Resource.ManageProjet</a></li>
        <li class="breadcrumb-item active">@Resource.CreateProjet</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.CreateProjet</div>
            <hr>
            @Using Html.BeginForm("Create", "Projets", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()

                @<div Class="form-group row">

                    @Html.LabelFor(Function(m) m.OrganisationId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.OrganisationId, New SelectList(Model.LesOrganisations, "Value", "Text"), Resource.ComboOrganisation,
                       New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboOrganisation})
                        @Html.ValidationMessageFor(Function(m) m.OrganisationId, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Nom, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Nom, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.NamePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Nom, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Reference, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Reference, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.Referencelaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Reference, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Description, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Description, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.DescriptionPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Description, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Budget, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Budget, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.BudgetPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Budget, "", New With {.style = "color: #da0b0b"})
                    </div>
                    @Html.LabelFor(Function(m) m.DeviseId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.DeviseId, New SelectList(Model.LesDevises, "Value", "Text"), Resource.ComboDevise,
        New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboDevise})
                        @Html.ValidationMessageFor(Function(m) m.DeviseId, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>


                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.DateDebut, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.DateDebut, New With {.class = "form-control form-control-square default-datepicker", .tabindex = "1", .Placeholder = Resource.DateDabutPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.DateDebut, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.DateFin, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.DateFin, New With {.class = "form-control form-control-square default-datepicker", .tabindex = "1", .Placeholder = Resource.DateFinPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.DateFin, "", New With {.style = "color: #da0b0b"})
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
