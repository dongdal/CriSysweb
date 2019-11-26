@ModelType ProjetViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.DetailsProjet
    Layout = "~/Views/Shared/_LayoutSahana.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.DetailsProjet</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Projets")>@Resource.ManageProjet</a></li>
        <li class="breadcrumb-item active">@Resource.DetailsProjet</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <ul Class="nav nav-tabs nav-tabs-primary">
                <li Class="nav-item">
                    <a Class="nav-link active" data-toggle="tab" href="#tabe-1"><i class="icon-home"></i> <span class="hidden-xs">@Resource.DetailsProjet</span></a>
                </li>
                
            </ul>
            
            <div class="tab-content">
                <div id="tabe-1" class="container tab-pane active">
                    <div Class="row col-sm-12">

                        <div class="col-sm-6 form-group">

                            <div class="form-group">
                                <label for="UserName" class="col-form-label">@Resource.Organisation : </label>
                                @Html.DisplayFor(Function(model) model.Organisation.Nom, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="Nom" class="col-form-label">@Resource.Nom : </label>
                                @Html.DisplayFor(Function(model) model.Nom, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="Prenom" class="col-form-label">@Resource.Reference : </label>
                                @Html.DisplayFor(Function(model) model.Reference, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateNaissance" class="col-form-label">@Resource.Description : </label>
                                @Html.DisplayFor(Function(model) model.Description, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                        </div>

                        <div class="col-sm-6 form-group">

                            <div class="form-group">
                                <label for="Telephone" class="col-form-label">@Resource.Budget : </label>
                                @Html.DisplayFor(Function(model) model.Budget, New With {.class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="CNI" class="col-form-label">@Resource.Devise : </label>
                                @Html.DisplayFor(Function(model) model.Devise.Libelle, New With {.class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="Email" class="col-form-label">@Resource.DateDebut : </label>
                                @Html.DisplayFor(Function(model) model.DateDebut, New With {.class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.DateFin : </label>
                                @Html.DisplayFor(Function(model) model.DateFin, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />
                        </div>

                    </div>
                    <div Class="form-group row">
                        <Label Class="col-sm-2 col-form-label"></Label>
                        <div Class="col-sm-10">
                            <br />
                            <br />
                            @Html.ActionLink(Resource.BtnCancel, "Index", "Projets", New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                        </div>
                    </div>
                </div>

            </div>

            </div>
        </div>
</div>