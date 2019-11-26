@ModelType AeroportViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.DetailsAeroport
    Layout = "~/Views/Shared/_LayoutSahana.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.DetailsAeroport</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Aeroport")>@Resource.ManageAeroport</a></li>
        <li class="breadcrumb-item active">@Resource.DetailsAeroport</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <ul Class="nav nav-tabs nav-tabs-primary">
                <li Class="nav-item">
                    <a Class="nav-link active" data-toggle="tab" href="#tabe-1"><i class="icon-home"></i> <span class="hidden-xs">@Resource.DetailsAeroport</span></a>
                </li>
                
                <li Class="nav-item">
                    <a Class="nav-link" data-toggle="tab" href="#tabe-2"><i class="icon-wallet"></i> <span class="hidden-xs">@Resource.Materiel</span></a>
                </li>
            </ul>
            
            <div class="tab-content">
                <div id="tabe-1" class="container tab-pane active">
                    <div Class="row col-sm-12">

                        <div class="col-sm-6 form-group">

                            <div class="form-group">
                                <label for="UserName" class="col-form-label">@Resource.IATA : </label>
                                @Html.DisplayFor(Function(model) model.IATA, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="UserName" class="col-form-label">@Resource.ICAO : </label>
                                @Html.DisplayFor(Function(model) model.ICAO, New With {.Class = "form-control", .disabled = "disabled"})
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
                                <label for="LieuNaissance" class="col-form-label">@Resource.SurfaceDePiste : </label>
                                @Html.DisplayFor(Function(model) model.SurfaceDePiste.Libelle, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="LieuNaissance" class="col-form-label">@Resource.LongueurDePiste : </label>
                                @Html.DisplayFor(Function(model) model.LongueurDePiste, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="LieuNaissance" class="col-form-label">@Resource.LargeurDePiste : </label>
                                @Html.DisplayFor(Function(model) model.LargeurDePiste, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />


                        </div>

                        <div class="col-sm-6 form-group">

                            <div class="form-group">
                                <label for="LieuNaissance" class="col-form-label">@Resource.TailleDeAeronef : </label>
                                @Html.DisplayFor(Function(model) model.TailleDeAeronef.Libelle, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="LieuNaissance" class="col-form-label">@Resource.UsageHumanitaire : </label>
                                @Html.DisplayFor(Function(model) model.UsageHumanitaire.Libelle, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="Sexe" class="col-form-label">@Resource.Telephone : </label>
                                @Html.DisplayFor(Function(model) model.Telephone, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="Telephone2" class="col-form-label">@Resource.Telephone2 : </label>
                                @Html.DisplayFor(Function(model) model.Telephone2, New With {.Class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="Email" class="col-form-label">@Resource.Email : </label>
                                @Html.DisplayFor(Function(model) model.Email, New With {.class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />

                            <div class="form-group">
                                <label for="SiteWeb" class="col-form-label">@Resource.SiteWeb : </label>
                                @Html.DisplayFor(Function(model) model.SiteWeb, New With {.class = "form-control", .disabled = "disabled"})
                            </div>
                            <br />
                        </div>

                    </div>
                    <div Class="form-group row">
                        <Label Class="col-sm-2 col-form-label"></Label>
                        <div Class="col-sm-10">
                            <br />
                            <br />
                            @Html.ActionLink(Resource.BtnCancel, "Index", "Aeroport", New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                        </div>
                    </div>
                </div>

                <div id="tabe-2" class="container tab-pane">
                    <div class="row">

                        <table id="zero_config" class="table table-striped table-bordered">
                            <thead>
                                <tr>
                                    <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                        @Resource.Libelle
                                    </th>
                                    <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                        @Resource.Quantite
                                    </th>
                                   
                                </tr>
                            </thead>

                            <tbody>
                                @For Each item In Model.MaterielAeroport
                                    @<tr>

                                        <td>
                                            @item.Materiel.Libelle
                                        </td>
                                        <td>
                                            @item.Quantite
                                        </td>
                                        
                                    </tr>
                                Next
                            </tbody>

                        </table>
                    </div>
                </div>


            </div>

            </div>
        </div>
</div>