@ModelType ImmobilisationViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.DetailsImmobilisations
    Layout = "~/Views/Shared/_LayoutSahana.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.DetailsImmobilisations</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Immobilisations")>@Resource.ManageImmobilisation</a></li>
        <li class="breadcrumb-item active">@Resource.DetailsImmobilisations</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <ul Class="nav nav-tabs nav-tabs-primary">
                <li Class="nav-item">
                    <a Class="nav-link active" data-toggle="tab" href="#tabe-1"><i class="icon-home"></i> <span class="hidden-xs">@Resource.DetailsImmobilisations</span></a>
                </li>
            </ul>
            
            <div class="tab-content">
                <div id="tabe-1" class="container tab-pane active">
                    <div Class="row col-sm-12">

                        <div class="col-sm-6 form-group">

                            <div class="form-group">
                                <label for="UserName" class="col-form-label">@Resource.NumeroImobilisation : </label>
                                @Html.DisplayFor(Function(model) model.NumeroImobilisation, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="Nom" class="col-form-label">@Resource.NumeroDeSerie : </label>
                                @Html.DisplayFor(Function(model) model.NumeroDeSerie, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />



                            <div class="form-group">
                                <label for="Prenom" class="col-form-label">@Resource.DateAchat : </label>
                                @Html.DisplayFor(Function(model) model.DateAchat, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateNaissance" class="col-form-label">@Resource.PrixAchat : </label>
                                @Html.DisplayFor(Function(model) model.PrixAchat, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateNaissance" class="col-form-label">@Resource.TypeImmobilisation : </label>
                                @Html.DisplayFor(Function(model) model.TypeImmobilisation.Libelle, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                        </div>

                        <div class="col-sm-6 form-group">

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.Infrastructure : </label>
                                @Html.DisplayFor(Function(model) model.Infrastructure.Nom, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.Fournisseur : </label>
                                @Html.DisplayFor(Function(model) model.Fournisseur.Nom, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="Email" class="col-form-label">@Resource.Element : </label>
                                @Html.DisplayFor(Function(model) model.Element.Nom, New With {.class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                        </div>

                    </div>
                    <div Class="form-group row">
                        <Label Class="col-sm-2 col-form-label"></Label>
                        <div Class="col-sm-10">
                            <br />
                            <br />
                            @Html.ActionLink(Resource.BtnCancel, "Index", "Immobilisations", New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                        </div>
                    </div>
                </div>

            </div>

            </div>
        </div>
</div>