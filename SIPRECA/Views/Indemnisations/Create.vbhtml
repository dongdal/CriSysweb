@ModelType IndemnisationViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.CreateIndemnisation
    'Layout = "~/Views/Shared/_LayoutSahana.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageDemande</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Indemnisations")>@Resource.ManageIndemnisation</a></li>
        <li class="breadcrumb-item active">@Resource.CreateIndemnisation</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.CreateIndemnisation</div>
            <hr>
            @Using Html.BeginForm("Create", "Indemnisations", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()

                @<div Class="form-group row">

                    @Html.LabelFor(Function(m) m.DemandeId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.DemandeId, New SelectList(Model.LesDemande, "Value", "Text"), Resource.ComboDemande,
             New With {.class = "form-control single-select", .tabindex = "1", .Placeholder = Resource.ComboDemande})
                        @Html.ValidationMessageFor(Function(m) m.DemandeId, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Libelle, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Libelle, New With {.class = "form-control form-control-square", .tabindex = "2", .Placeholder = Resource.LibellePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Libelle, "", New With {.style = "color: #da0b0b"})
                    </div>

                </div>

                @<div Class="form-group row">

                    @Html.LabelFor(Function(m) m.Description, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextAreaFor(Function(m) m.Description, New With {.class = "form-control form-control-square", .tabindex = "4", .Placeholder = Resource.DescriptionPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Description, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    <Label Class="col-sm-2 col-form-label"></Label>
                    <div Class="col-sm-10">
                        <Button type="submit" Class="btn btn-link btn-square bg-primary text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.BtnSave</Button>
                        &nbsp;&nbsp;&nbsp;
                        @Html.ActionLink(Resource.BtnCancel, "Index", "Demandes", Nothing, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                    </div>
                </div>

            End Using

        </div>
    </div>
</div>
