@ModelType ImmobilisationViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.CreateImmobilisation
    Layout = "~/Views/Shared/_LayoutSahana.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageImmobilisation</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Immobilisations")>@Resource.ManageImmobilisation</a></li>
        <li class="breadcrumb-item active">@Resource.CreateImmobilisation</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.CreateImmobilisation</div>
            <hr>
            @Using Html.BeginForm("Create", "Immobilisations", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.NumeroImobilisation, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.NumeroImobilisation, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.NumeroImobilisationPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.NumeroImobilisation, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.NumeroDeSerie, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.NumeroDeSerie, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.NumeroDeSeriePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.NumeroDeSerie, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.DateAchat, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.DateAchat, New With {.class = "form-control form-control-square default-datepicker", .tabindex = "4", .Placeholder = Resource.DateAchatPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.DateAchat, "", New With {.style = "color: #da0b0b"})
                    </div>


                    @Html.LabelFor(Function(m) m.PrixAchat, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.PrixAchat, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.PrixAchatPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.PrixAchat, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.DeviseId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.DeviseId, New SelectList(Model.LesDevises, "Value", "Text"), Resource.ComboDevise,
     New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboDevise})
                        @Html.ValidationMessageFor(Function(m) m.DeviseId, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.TypeImmobilisationId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.TypeImmobilisationId, New SelectList(Model.LesTypeImmobilisations, "Value", "Text"), Resource.ComboTypeImmobilisation,
        New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboTypeImmobilisation})
                        @Html.ValidationMessageFor(Function(m) m.TypeImmobilisationId, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.InfrastructureId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.InfrastructureId, New SelectList(Model.LesInfrastructures, "Value", "Text"), Resource.ComboInfrastructure,
                  New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboInfrastructure})
                        @Html.ValidationMessageFor(Function(m) m.InfrastructureId, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.FournisseurId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.FournisseurId, New SelectList(Model.LesFournisseurs, "Value", "Text"), Resource.ComboFournisseur,
                           New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboFournisseur})
                        @Html.ValidationMessageFor(Function(m) m.FournisseurId, "", New With {.style = "color: #da0b0b"})
                    </div>

                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.ElementId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-10 form-group">
                        @Html.DropDownListFor(Function(m) m.ElementId, New SelectList(Model.LesElements, "Value", "Text"), Resource.ComboElement,
                     New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboElement})
                        @Html.ValidationMessageFor(Function(m) m.ElementId, "", New With {.style = "color: #da0b0b"})
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
