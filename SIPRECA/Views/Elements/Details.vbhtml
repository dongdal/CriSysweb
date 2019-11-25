@ModelType ElementViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.DetailsElement
    Layout = "~/Views/Shared/_LayoutSahana.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.DetailsElement</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Elements")>@Resource.ManageElement</a></li>
        <li class="breadcrumb-item active">@Resource.DetailsElement</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <ul Class="nav nav-tabs nav-tabs-primary">
                <li Class="nav-item">
                    <a Class="nav-link active" data-toggle="tab" href="#tabe-1"><i class="icon-home"></i> <span class="hidden-xs">@Resource.DetailsElement</span></a>
                </li>
            </ul>
            
            <div class="tab-content">
                <div id="tabe-1" class="container tab-pane active">
                    <div Class="row col-sm-12">

                        <div class="col-sm-6 form-group">

                            <div class="form-group">
                                <label for="UserName" class="col-form-label">@Resource.Code : </label>
                                @Html.DisplayFor(Function(model) model.Code, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="Nom" class="col-form-label">@Resource.Nom : </label>
                                @Html.DisplayFor(Function(model) model.Nom, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />



                            <div class="form-group">
                                <label for="Prenom" class="col-form-label">@Resource.CategorieElement : </label>
                                @Html.DisplayFor(Function(model) model.CategorieElement.Libelle, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateNaissance" class="col-form-label">@Resource.MarqueElement : </label>
                                @Html.DisplayFor(Function(model) model.MarqueElement.Libelle, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.UniteMesure : </label>
                                @Html.DisplayFor(Function(model) model.UniteMesure, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.ValeurParUnite : </label>
                                @Html.DisplayFor(Function(model) model.ValeurParUnité, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.Modele : </label>
                                @Html.DisplayFor(Function(model) model.Modele, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.AnneeFabrication : </label>
                                @Html.DisplayFor(Function(model) model.AnneeFabrication, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                        </div>

                        <div class="col-sm-6 form-group">

                            <div class="form-group">
                                <label for="Email" class="col-form-label">@Resource.Longueur : </label>
                                @Html.DisplayFor(Function(model) model.Longueur, New With {.class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.Largeur : </label>
                                @Html.DisplayFor(Function(model) model.Largeur, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="Email" class="col-form-label">@Resource.Hauteur : </label>
                                @Html.DisplayFor(Function(model) model.Hauteur, New With {.class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.Poids : </label>
                                @Html.DisplayFor(Function(model) model.Poids, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="Email" class="col-form-label">@Resource.PrixAchat : </label>
                                @Html.DisplayFor(Function(model) model.PrixAchat, New With {.class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.Devise : </label>
                                @Html.DisplayFor(Function(model) model.Devise.Libelle, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                        </div>

                    </div>
                    <div Class="form-group row">
                        <Label Class="col-sm-2 col-form-label"></Label>
                        <div Class="col-sm-10">
                            <br />
                            <br />
                            @Html.ActionLink(Resource.BtnCancel, "Index", "Elements", New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                        </div>
                    </div>
                </div>

            </div>

            </div>
        </div>
</div>