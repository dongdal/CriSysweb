@ModelType PortDeMerViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.DetailsPortDeMer
    Layout = "~/Views/Shared/_LayoutSahana.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.DetailsPortDeMer</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "PortDeMers")>@Resource.ManagePortDeMer</a></li>
        <li class="breadcrumb-item active">@Resource.DetailsPortDeMer</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <ul Class="nav nav-tabs nav-tabs-primary">
                <li Class="nav-item">
                    <a Class="nav-link active" data-toggle="tab" href="#tabe-1"><i class="icon-home"></i> <span class="hidden-xs">@Resource.DetailsPortDeMer</span></a>
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
                                <label for="Prenom" class="col-form-label">@Resource.Organisation : </label>
                                @Html.DisplayFor(Function(model) model.Organisation.Nom, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateNaissance" class="col-form-label">@Resource.Commune : </label>
                                @Html.DisplayFor(Function(model) model.Commune.Libelle, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.Possession : </label>
                                @Html.DisplayFor(Function(model) model.Possession, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.HauteurMaximum : </label>
                                @Html.DisplayFor(Function(model) model.HauteurMaximum, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.HauteurMaximumUnites : </label>
                                @Html.DisplayFor(Function(model) model.HauteurMaximumUnites, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.ProfondeurQuaiChargement : </label>
                                @Html.DisplayFor(Function(model) model.ProfondeurQuaiChargement, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="Email" class="col-form-label">@Resource.ProfondeurQuaiChargementUnites : </label>
                                @Html.DisplayFor(Function(model) model.ProfondeurQuaiChargementUnites, New With {.class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.ProfondeurTerminalPetrolier : </label>
                                @Html.DisplayFor(Function(model) model.ProfondeurTerminalPetrolier, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.ProfondeurTerminalPetrolierUnites : </label>
                                @Html.DisplayFor(Function(model) model.ProfondeurTerminalPetrolierUnites, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="Email" class="col-form-label">@Resource.CaleSeche : </label>
                                @Html.DisplayFor(Function(model) model.CaleSeche, New With {.class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.LongueurMaximaleNavire : </label>
                                @Html.DisplayFor(Function(model) model.LongueurMaximaleNavire, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="Email" class="col-form-label">@Resource.LongueurMaximaleNavireUnites : </label>
                                @Html.DisplayFor(Function(model) model.LongueurMaximaleNavireUnites, New With {.class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="Email" class="col-form-label">@Resource.LongueurMaximaleNavireUnites : </label>
                                @Html.DisplayFor(Function(model) model.LongueurMaximaleNavireUnites, New With {.class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.Reparations : </label>
                                @Html.DisplayFor(Function(model) model.Reparations, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="Email" class="col-form-label">@Resource.Abri : </label>
                                @Html.DisplayFor(Function(model) model.Abri, New With {.class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.CapaciteStockageEntreposage : </label>
                                @Html.DisplayFor(Function(model) model.CapaciteStockageEntreposage, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="Email" class="col-form-label">@Resource.CapaciteStockageSecurise : </label>
                                @Html.DisplayFor(Function(model) model.CapaciteStockageSecurise, New With {.class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                        </div>

                        <div class="col-sm-6 form-group">

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.CapaciteStockageEntrepotDouanier : </label>
                                @Html.DisplayFor(Function(model) model.CapaciteStockageEntrepotDouanier, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="Email" class="col-form-label">@Resource.NombreRemorqueur : </label>
                                @Html.DisplayFor(Function(model) model.NombreRemorqueur, New With {.class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.CapaciteRemorqueur : </label>
                                @Html.DisplayFor(Function(model) model.CapaciteRemorqueur, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.NombreBarge : </label>
                                @Html.DisplayFor(Function(model) model.NombreBarge, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="Email" class="col-form-label">@Resource.CapacietBarge : </label>
                                @Html.DisplayFor(Function(model) model.CapacietBarge, New With {.class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.EquipementChargement : </label>
                                @Html.DisplayFor(Function(model) model.EquipementChargement, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.CapaciteDouaniere : </label>
                                @Html.DisplayFor(Function(model) model.CapaciteDouaniere, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="Email" class="col-form-label">@Resource.Securite : </label>
                                @Html.DisplayFor(Function(model) model.Securite, New With {.class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.ProfondeurMareHaute : </label>
                                @Html.DisplayFor(Function(model) model.ProfondeurMareHaute, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.ProfondeurMareHauteUnites : </label>
                                @Html.DisplayFor(Function(model) model.ProfondeurMareHauteUnites, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="Email" class="col-form-label">@Resource.ProfondeurMareBasse : </label>
                                @Html.DisplayFor(Function(model) model.ProfondeurMareBasse, New With {.class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.ProfondeurMareBasseUnites : </label>
                                @Html.DisplayFor(Function(model) model.ProfondeurMareBasseUnites, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="Email" class="col-form-label">@Resource.ProfondeurInondation : </label>
                                @Html.DisplayFor(Function(model) model.ProfondeurInondation, New With {.class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.ProfondeurInondationUnites : </label>
                                @Html.DisplayFor(Function(model) model.ProfondeurInondationUnites, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.Telephone : </label>
                                @Html.DisplayFor(Function(model) model.Telephone, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="Email" class="col-form-label">@Resource.Telephone2 : </label>
                                @Html.DisplayFor(Function(model) model.Telephone2, New With {.class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.SiteWeb : </label>
                                @Html.DisplayFor(Function(model) model.SiteWeb, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="DateCreation" class="col-form-label">@Resource.Email : </label>
                                @Html.DisplayFor(Function(model) model.Email, New With {.Class = "form-control", .disabled = "disabled"})
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