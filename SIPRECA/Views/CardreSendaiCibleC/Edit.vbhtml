@ModelType SIPRECA.CardreSendaiCibleCViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewData("Title") = Resource.EditIndicateursCibleC
    Layout = "~/Views/Shared/_LayoutDesinventar.vbhtml"
End Code

<div class="page-header">
    <h1 class="page-title">@Resource.ManageEvenementZone</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "CardreSendaiCibleC")>@Resource.ManageEvenementZone</a></li>
        <li class="breadcrumb-item active">@Resource.EditIndicateursCibleC</li>
    </ol>
</div>


<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.EditIndicateursCibleC</div>
            <hr>
            @Using Html.BeginForm("Edit", "CardreSendaiCibleC", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()
                @Html.HiddenFor(Function(model) model.Id)
                @Html.HiddenFor(Function(model) model.AspNetUserId)
                @Html.HiddenFor(Function(model) model.StatutExistant)
                @Html.HiddenFor(Function(model) model.DateCreation)

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.EvenementZoneId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.EvenementZoneId, New SelectList(Model.LesEvenementsZone, "Value", "Text"), Resource.ComboEvenement,
              New With {.class = "form-control single-select", .tabindex = "1", .Placeholder = Resource.EvenementCombo})
                        @Html.ValidationMessageFor(Function(m) m.EvenementZoneId, "", New With {.style = "color: #da0b0b"})
                    </div>
                    <p style="text-indent: 25px; text-align:justify; font-style:italic; font-size: 10px; color: red">
                        Veuillez enregistrer dans cette section, les pertes économiques directes - Pertes agricoles , pertes dues aux dommages causés aux autres biens de production, aux infrastructures critiques et aux perturbations des services de base, entrez des chiffres désagrégés et
                        utilisez le bouton "<strong>Faire Somme</strong>" pour calculer la somme de chaque sous-groupe.
                    </p>
                </div>

                @<fieldset style="border:ridge;" Class="col-md-12">
                    <legend style="font-size: 14px">@Resource.PerteDeRecolteAgricole</legend>
                    <div Class="form-group row">
                        <fieldset style="border:ridge;" Class="col-md-12">
                            <legend style="font-size: 14px">@Resource.PerteEconomiqueDommagesPhysiquesCultures</legend>
                            <br />
                            <br />
                            <div Class="form-group row">
                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.PerteEconomiqueDesCultureTouche, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.PerteEconomiqueDesCultureTouche,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.PerteEconomiqueDesCultureTouche, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>

                                <div Class="col-md-3">

                                    @Html.LabelFor(Function(m) m.HectaresTautauxDesCulturesTouche, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.HectaresTautauxDesCulturesTouche,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.HectaresTautauxDesCulturesTouche, "", New With {.style = "color: #da0b0b"})
                                        &nbsp;&nbsp;&nbsp;
                                        <button onclick="SommeCultures();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
                                    </div>
                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.HectaresEndomages, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.HectaresEndomages,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.HectaresEndomages, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                    <br />
                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.HectaresDetruits, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.HectaresDetruits,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.HectaresDetruits, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                    <br />
                                </div>

                            </div>

                        </fieldset>
                        <br />
                        <br />

                    </div>

                    <div Class="form-group row">
                        <fieldset style="border:ridge;" Class="col-md-12">
                            <legend style="font-size: 14px">@Resource.Disaggregation</legend>

                            <div Class="row">
                                @Html.LabelFor(Function(m) m.DesagregationRecoltesAgricoleId, New With {.class = "col-md-2 col-form-label required_field"})
                                <div class="col-md-4 form-group">
                                    @Html.DropDownListFor(Function(m) m.DesagregationRecoltesAgricoleId, New SelectList(Model.LesDesagregationRecoltesAgricoles, "Value", "Text"), Resource.CultureCombo,
New With {.class = "form-control single-select", .tabindex = "1", .Placeholder = Resource.CultureCombo})
                                    @Html.ValidationMessageFor(Function(m) m.DesagregationRecoltesAgricoleId, "", New With {.style = "color: #da0b0b"})

                                </div>
                                <button type="button" name="AddDsagregationAgricole" class="btn btn-round btn-primary waves-effect waves-light m-1"> @Resource.btn_Add</button>
                            </div>
                            <br />
                            <div Class="form-group row">

                                <div Class="col-md-3">

                                    @Html.LabelFor(Function(m) m.PerteEconomique, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.PerteEconomique,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.PerteEconomique, "", New With {.style = "color: #da0b0b"})
                                        &nbsp;&nbsp;&nbsp;
                                        <button onclick="SommeStockAgricoleToucher();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
                                    </div>
                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreHectarAfecter, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreHectarAfecter,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreHectarAfecter, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreHectarEndomager, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreHectarEndomager,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreHectarEndomager, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreHectarDetruit, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreHectarDetruit,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreHectarDetruit, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>

                            </div>
                            &nbsp;&nbsp;&nbsp;

                            <div Class="form-group row">
                                <table style="margin:10px;" id="default-datatable" class="table table-bordered dataTable" role="grid" aria-describedby="default-datatable_info">
                                    <thead>
                                        <tr>
                                            <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                                @Resource.Libelle
                                            </th>
                                            <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                                @Resource.PerteEconomique
                                            </th>
                                            <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                                @Resource.NombreHectarAfecter
                                            </th>
                                            <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                                @Resource.NombreHectarEndomager
                                            </th>
                                            <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                                @Resource.NombreHectarDetruit
                                            </th>
                                            <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                                @Resource.ActionList
                                            </th>
                                        </tr>
                                    </thead>

                                    <tbody>
                                        @For Each item In Model.CibleCDesagregationAgricole
                                            @<tr>
                                                <td class="sorting_asc text-center">
                                                    @Html.DisplayFor(Function(modelItem) item.DesagregationRecoltesAgricole.Libellle)
                                                </td>
                                                <td class="sorting_asc text-center">
                                                    @Html.DisplayFor(Function(modelItem) item.PerteEconomique)
                                                </td>
                                                <td class="sorting_asc text-center">
                                                    @Html.DisplayFor(Function(modelItem) item.NombreHectarAfecter)
                                                </td>
                                                <td class="sorting_asc text-center">
                                                    @Html.DisplayFor(Function(modelItem) item.NombreHectarEndomager)
                                                </td>
                                                <td class="sorting_asc text-center">
                                                    @Html.DisplayFor(Function(modelItem) item.NombreHectarDetruit)
                                                </td>
                                                <td class="text-center">
                                                    <a class="btn btn-round btn-danger waves-effect waves-light m-1 DeleteDsagregationAgricole" title="@Resource.Btn_Delete" href="javascript:void(0);" data-id="@item.Id">
                                                        <i class="fa fa-trash" aria-hidden="true"></i>
                                                    </a>
                                                </td>
                                            </tr>
                                        Next
                                    </tbody>

                                </table>

                            </div>

                        </fieldset>
                        <br />
                        <br />

                    </div>
                </fieldset>
                @<br />
                @<br />

                @<fieldset style="border:ridge;" Class="col-md-12">
                    <legend style="font-size: 14px">@Resource.PertesBetail</legend>
                    <div Class="form-group row">
                        <fieldset style="border:ridge;" Class="col-md-12">
                            <legend style="font-size: 14px">@Resource.DommagesPhysiquesBetail </legend>
                            <br />
                            <br />
                            <div Class="form-group row">
                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.PerteTotalDeBetailTouche, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.PerteTotalDeBetailTouche,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.PerteTotalDeBetailTouche, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>

                                <div Class="col-md-3">

                                    @Html.LabelFor(Function(m) m.NombreDanimauxToucheOuPerdu, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreDanimauxToucheOuPerdu,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreDanimauxToucheOuPerdu, "", New With {.style = "color: #da0b0b"})
                                        &nbsp;&nbsp;&nbsp;
                                        <button onclick="SommeBetails();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
                                    </div>
                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreDanimauxToucher, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreDanimauxToucher,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreDanimauxToucher, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                    <br />
                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreDanimauxPerdu, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreDanimauxPerdu,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreDanimauxPerdu, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                    <br />
                                </div>

                            </div>

                        </fieldset>
                        <br />
                        <br />

                    </div>

                    <div Class="form-group row">
                        <fieldset style="border:ridge;" Class="col-md-12">
                            <legend style="font-size: 14px">@Resource.Disaggregation</legend>

                            <div Class="row">
                                @Html.LabelFor(Function(m) m.PerteBetailId, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4 form-group">
                                    @Html.DropDownListFor(Function(m) m.PerteBetailId, New SelectList(Model.LesPerteBetails, "Value", "Text"), Resource.BetailCombo,
New With {.class = "form-control single-select", .tabindex = "1", .Placeholder = Resource.BetailCombo})
                                    @Html.ValidationMessageFor(Function(m) m.PerteBetailId, "", New With {.style = "color: #da0b0b"})
                                </div>
                                <button type="button" name="AddDsagregationBetail" class="btn btn-round btn-primary waves-effect waves-light m-1"> @Resource.btn_Add</button>
                            </div>
                            <br />

                            <div Class="form-group row">

                                <div Class="col-md-3">

                                    @Html.LabelFor(Function(m) m.PerteEconomiqueBetail, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.PerteEconomiqueBetail,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.PerteEconomiqueBetail, "", New With {.style = "color: #da0b0b"})
                                        &nbsp;&nbsp;&nbsp;
                                        <button onclick="SommeBlesses();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
                                    </div>
                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreTotalAfecter, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreTotalAfecter,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreTotalAfecter, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreTotalEndomager, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreTotalEndomager,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreTotalEndomager, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreDetruitDetruit, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreDetruitDetruit,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreDetruitDetruit, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>

                            </div>
                            &nbsp;&nbsp;&nbsp;


                            <div Class="form-group row">
                                <table style="margin:10px;" id="default-datatable" class="table table-bordered dataTable" role="grid" aria-describedby="default-datatable_info">
                                    <thead>
                                        <tr>
                                            <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                                @Resource.Libelle
                                            </th>
                                            <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                                @Resource.PerteEconomique
                                            </th>
                                            <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                                @Resource.NombreTotalAfecter
                                            </th>
                                            <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                                @Resource.NombreTotalEndomager
                                            </th>
                                            <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                                @Resource.NombreDetruitDetruit
                                            </th>
                                            <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                                @Resource.ActionList
                                            </th>
                                        </tr>
                                    </thead>

                                    <tbody>
                                        @For Each item In Model.CibleCPerteBetail
                                            @<tr>
                                                <td class="sorting_asc text-center">
                                                    @Html.DisplayFor(Function(modelItem) item.PerteBetail.Libelle)
                                                </td>
                                                <td class="sorting_asc text-center">
                                                    @Html.DisplayFor(Function(modelItem) item.PerteEconomique)
                                                </td>
                                                <td class="sorting_asc text-center">
                                                    @Html.DisplayFor(Function(modelItem) item.NombreTotalAfecter)
                                                </td>
                                                <td class="sorting_asc text-center">
                                                    @Html.DisplayFor(Function(modelItem) item.NombreTotalEndomager)
                                                </td>
                                                <td class="sorting_asc text-center">
                                                    @Html.DisplayFor(Function(modelItem) item.NombreDetruitDetruit)
                                                </td>
                                                <td class="text-center">
                                                    <a class="btn btn-round btn-danger waves-effect waves-light m-1 DeleteDsagregationBetail" title="@Resource.Btn_Delete" href="javascript:void(0);" data-id="@item.Id">
                                                        <i class="fa fa-trash" aria-hidden="true"></i>
                                                    </a>
                                                </td>
                                            </tr>
                                        Next
                                    </tbody>

                                </table>

                            </div>

                        </fieldset>
                        <br />
                        <br />

                    </div>
                </fieldset>
                @<br />
                @<br />

                @<fieldset style="border:ridge;" Class="col-md-12">
                    <legend style="font-size: 14px">@Resource.PertesForetsSylviculture</legend>
                    <div Class="form-group row">
                        <fieldset style="border:ridge;" Class="col-md-12">
                            <legend style="font-size: 14px">@Resource.PerteEconomiqueDommagesPhysiquesForets</legend>
                            <br />
                            <br />
                            <div Class="form-group row">
                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.PerteEconomiqueSurForet, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.PerteEconomiqueSurForet,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.PerteEconomiqueSurForet, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>

                                <div Class="col-md-3">

                                    @Html.LabelFor(Function(m) m.NombreTotalHectarForetToucher, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreTotalHectarForetToucher,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreTotalHectarForetToucher, "", New With {.style = "color: #da0b0b"})
                                        &nbsp;&nbsp;&nbsp;
                                        <button onclick="SommeForetToucher();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
                                    </div>
                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreHectarForetEndomager, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreHectarForetEndomager,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreHectarForetEndomager, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                    <br />
                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreHectarForetDetruit, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreHectarForetDetruit,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreHectarForetDetruit, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                    <br />
                                </div>

                            </div>

                        </fieldset>

                    </div>
                </fieldset>
                @<br />
                @<br />

                @<fieldset style="border:ridge;" Class="col-md-12">
                    <legend style="font-size: 14px">@Resource.PertesAquaculture</legend>
                    <div Class="form-group row">
                        <fieldset style="border:ridge;" Class="col-md-12">
                            <legend style="font-size: 14px">@Resource.PerteEconomiqueDommagesPhysiquesAquaculture</legend>
                            <br />
                            <br />
                            <div Class="form-group row">
                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.PerteEconomiqueAquaculture, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.PerteEconomiqueAquaculture,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.PerteEconomiqueAquaculture, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>

                                <div Class="col-md-3">

                                    @Html.LabelFor(Function(m) m.NombreTotalHectarAquacultureToucher, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreTotalHectarAquacultureToucher,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreTotalHectarAquacultureToucher, "", New With {.style = "color: #da0b0b"})
                                        &nbsp;&nbsp;&nbsp;
                                        <button onclick="SommeAquacultureToucher();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
                                    </div>
                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreHectarAquacultureEndomager, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreHectarAquacultureEndomager,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreHectarAquacultureEndomager, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                    <br />
                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreHectarAquacultureDetruit, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreHectarAquacultureDetruit,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreHectarAquacultureDetruit, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                    <br />
                                </div>

                            </div>

                        </fieldset>

                    </div>
                </fieldset>
                @<br />
                @<br />

                @<fieldset style="border:ridge;" Class="col-md-12">
                    <legend style="font-size: 14px">@Resource.PertesPecheries</legend>
                    <div Class="form-group row">
                        <fieldset style="border:ridge;" Class="col-md-12">
                            <legend style="font-size: 14px">@Resource.PerteEconomiqueDommagesPhysiquesPecheries</legend>
                            <br />
                            <br />
                            <div Class="form-group row">
                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.PerteEconomiqueDesNaviresAffecter, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.PerteEconomiqueDesNaviresAffecter,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.PerteEconomiqueDesNaviresAffecter, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>

                                <div Class="col-md-3">

                                    @Html.LabelFor(Function(m) m.NombreTotalNavireToucher, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreTotalNavireToucher,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreTotalNavireToucher, "", New With {.style = "color: #da0b0b"})
                                        &nbsp;&nbsp;&nbsp;
                                        <button onclick="SommeNavireToucher();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
                                    </div>
                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreNavireEndomager, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreNavireEndomager,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreNavireEndomager, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                    <br />
                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreNavireDetruit, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreNavireDetruit,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreNavireDetruit, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                    <br />
                                </div>

                            </div>

                        </fieldset>

                    </div>
                </fieldset>
                @<br />
                @<br />

                @<fieldset style="border:ridge;" Class="col-md-12">
                    <legend style="font-size: 14px">@Resource.PerteStockAgricole</legend>
                    <div Class="form-group row">
                        <fieldset style="border:ridge;" Class="col-md-12">
                            <legend style="font-size: 14px">@Resource.PerteEconomiqueDommagesStocksAgricoles</legend>
                            <br />
                            <br />
                            <div Class="form-group row">
                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.PerteEconomiqueDesStockAgricole, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.PerteEconomiqueDesStockAgricole,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.PerteEconomiqueDesStockAgricole, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>

                                <div Class="col-md-3">

                                    @Html.LabelFor(Function(m) m.NombreTotalDinstallationStockAgricoleToucher, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreTotalDinstallationStockAgricoleToucher,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreTotalDinstallationStockAgricoleToucher, "", New With {.style = "color: #da0b0b"})
                                        &nbsp;&nbsp;&nbsp;
                                        <button onclick="SommeStockAgricoleToucher();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
                                    </div>
                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreDinstallationStockAgricoleEndomager, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreDinstallationStockAgricoleEndomager,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreDinstallationStockAgricoleEndomager, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                    <br />
                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreDinstallationStockAgricoleDetruit, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreDinstallationStockAgricoleDetruit,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreDinstallationStockAgricoleDetruit, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                    <br />
                                </div>

                            </div>

                        </fieldset>

                    </div>
                </fieldset>
                @<br />
                @<br />

                @<fieldset style="border:ridge;" Class="col-md-12">
                    <legend style="font-size: 14px">@Resource.PertesProductionAgricole</legend>
                    <div Class="form-group row">
                        <fieldset style="border:ridge;" Class="col-md-12">
                            <legend style="font-size: 14px">@Resource.PerteEconomiqueDommagesCausesActifsProductionAgricoles</legend>
                            <br />
                            <br />
                            <div Class="form-group row">
                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.PerteEconomiqueActifsProductifAfricole, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.PerteEconomiqueActifsProductifAfricole,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.PerteEconomiqueActifsProductifAfricole, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>

                                <div Class="col-md-3">

                                    @Html.LabelFor(Function(m) m.NombreTotalActifsProductifAfricoleToucher, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreTotalActifsProductifAfricoleToucher,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreTotalActifsProductifAfricoleToucher, "", New With {.style = "color: #da0b0b"})
                                        &nbsp;&nbsp;&nbsp;
                                        <button onclick="SommeActifsProductifAfricole();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
                                    </div>
                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreActifsProductifAfricoleEndomager, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreActifsProductifAfricoleEndomager,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreActifsProductifAfricoleEndomager, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                    <br />
                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreActifsProductifAfricoleDetruit, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreActifsProductifAfricoleDetruit,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreActifsProductifAfricoleDetruit, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                    <br />
                                </div>

                            </div>

                        </fieldset>

                    </div>
                </fieldset>
                @<br />
                @<br />

                @<fieldset style="border:ridge;" Class="col-md-12">
                    <legend style="font-size: 14px">@Resource.DommagesPertesAutresActifsProductifs</legend>
                    <div Class="form-group row">
                        <fieldset style="border:ridge;" Class="col-md-12">
                            <legend style="font-size: 14px">@Resource.PerteEconomiqueDommagesCausesAutresActifsProductifs</legend>
                            <br />
                            <br />
                            <div Class="form-group row">
                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.PerteEconomiqueActifsProductifs, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.PerteEconomiqueActifsProductifs,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.PerteEconomiqueActifsProductifs, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>

                                <div Class="col-md-3">

                                    @Html.LabelFor(Function(m) m.NombreTotalInstallationActifsProductifsToucher, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreTotalInstallationActifsProductifsToucher,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreTotalInstallationActifsProductifsToucher, "", New With {.style = "color: #da0b0b"})
                                        &nbsp;&nbsp;&nbsp;
                                        <button onclick="SommeActifsProductifs();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
                                    </div>
                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreInstallationActifsProductifsEndomager, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreInstallationActifsProductifsEndomager,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreInstallationActifsProductifsEndomager, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                    <br />
                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreInstallationActifsProductifsDetruit, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreInstallationActifsProductifsDetruit,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreInstallationActifsProductifsDetruit, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                    <br />
                                </div>

                            </div>

                        </fieldset>

                    </div>
                </fieldset>
                @<br />
                @<br />

                @<div Class="form-group row">
                    <fieldset style="border:ridge; margin:10px;" Class="col-md-5">
                        <legend style="font-size: 14px">@Resource.SecteurLogement</legend>
                        <div Class="form-group row">
                            <fieldset style="border:ridge;" Class="col-md-12">
                                <legend style="font-size: 14px">@Resource.LogementsTouchesEndommagésDetruits</legend>
                                <br />
                                <br />
                                <div Class="form-group row">
                                    <div Class="col-md-6">
                                        @Html.LabelFor(Function(m) m.NombreTotalLogementEndommagerOuDetruit, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                        <div class="col-sm-8" style="max-width: 100%">
                                            @Html.EditorFor(Function(model) model.NombreTotalLogementEndommagerOuDetruit,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.NombreTotalLogementEndommagerOuDetruit, "", New With {.style = "color: #da0b0b"})
                                        </div>

                                    </div>

                                </div>
                            </fieldset>

                        </div>
                    </fieldset>

                    <fieldset style="border:ridge; margin:10px;" Class="col-md-5">
                        <legend style="font-size: 14px">@Resource.PerteEconomique</legend>
                        <div Class="form-group row">
                            <fieldset style="border:ridge;" Class="col-md-12">
                                <legend style="font-size: 14px">@Resource.CoutDesLogementsEndommagesDetruits</legend>
                                <br />
                                <br />
                                <div Class="form-group row">
                                    <div Class="col-md-6">
                                        @Html.LabelFor(Function(m) m.TotalEconomiqueLogementEndomagerOuDetruit, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                        <div class="col-sm-8" style="max-width: 100%">
                                            @Html.EditorFor(Function(model) model.TotalEconomiqueLogementEndomagerOuDetruit,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.TotalEconomiqueLogementEndomagerOuDetruit, "", New With {.style = "color: #da0b0b"})
                                            &nbsp;&nbsp;&nbsp;
                                            <button onclick="SommeLogementsEndommagesDetruits();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
                                        </div>
                                    </div>
                                    <br />

                                    <div Class="col-md-6">
                                        @Html.LabelFor(Function(m) m.ValeurEconomiqueDesMaisonsEndomager, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                        <div class="col-sm-8" style="max-width: 100%">
                                            @Html.EditorFor(Function(model) model.ValeurEconomiqueDesMaisonsEndomager,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.ValeurEconomiqueDesMaisonsEndomager, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                    </div>
                                    <br />

                                    <div Class="col-md-6">
                                        @Html.LabelFor(Function(m) m.ValeurEconomiqueDesMaisonsDetruites, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                        <div class="col-sm-8" style="max-width: 100%">
                                            @Html.EditorFor(Function(model) model.ValeurEconomiqueDesMaisonsDetruites,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.ValeurEconomiqueDesMaisonsDetruites, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                    </div>
                                    <br />
                                </div>

                            </fieldset>

                        </div>
                    </fieldset>
                </div>
                @<br />
                @<br />

                @<fieldset style="border:ridge;" Class="col-md-12">
                    <legend style="font-size: 14px">@Resource.DommagesPertesSecteurSante</legend>
                    <div Class="form-group row">
                        <fieldset style="border:ridge;" Class="col-md-12">
                            <legend style="font-size: 14px">@Resource.PerteEconomiqueDommagesCausesEtablissementsSante</legend>
                            <br />
                            <br />
                            <div Class="form-group row">
                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.PerteEconomiqueSecteurSante, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.PerteEconomiqueSecteurSante,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.PerteEconomiqueSecteurSante, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.PerteEconomiqueSecteurEducation, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.PerteEconomiqueSecteurEducation,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.PerteEconomiqueSecteurEducation, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.PerteEconomiqueInfrastructureToucher, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.PerteEconomiqueInfrastructureToucher,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.PerteEconomiqueInfrastructureToucher, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>

                            </div>

                        </fieldset>

                    </div>
                </fieldset>
                @<br />
                @<br />

                @<fieldset style="border:ridge; margin:10px;" Class="col-md-6">
                    <legend style="font-size: 14px">@Resource.DommagesPertesCausesPatrimoineCulturel</legend>
                    <div Class="form-group row">
                        <fieldset style="border:ridge;" Class="col-md-12">
                            <legend style="font-size: 14px">@Resource.HeritageCulturel</legend>
                            <br />
                            <br />
                            <div Class="form-group row">
                                <div Class="col-md-6">
                                    @Html.LabelFor(Function(m) m.CoutDeLaReabilitationHeritageCulturel, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div Class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.CoutDeLaReabilitationHeritageCulturel,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.CoutDeLaReabilitationHeritageCulturel, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>
                                <br />

                                <div Class="col-md-6">
                                    @Html.LabelFor(Function(m) m.CoutDeLaReabilitationMobileDetruit, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div Class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.CoutDeLaReabilitationMobileDetruit,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.CoutDeLaReabilitationMobileDetruit, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>
                                <br />

                                <div Class="col-md-6">
                                    @Html.LabelFor(Function(m) m.PerteEconomiqueDuAuActifsMobileDetruit, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div Class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.PerteEconomiqueDuAuActifsMobileDetruit,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.PerteEconomiqueDuAuActifsMobileDetruit, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>
                                <br />

                                <div Class="col-md-6">
                                    @Html.LabelFor(Function(m) m.NombreDeMonumentImmobiliersEndomager, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div Class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreDeMonumentImmobiliersEndomager,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreDeMonumentImmobiliersEndomager, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>
                                <br />

                                <div Class="col-md-6">
                                    @Html.LabelFor(Function(m) m.NombreMonumentImmobilierDetruits, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div Class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreMonumentImmobilierDetruits,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreMonumentImmobilierDetruits, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>
                                <br />

                                <div Class="col-md-6">
                                    @Html.LabelFor(Function(m) m.NombreDeBiensCulturelMobileEndomager, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div Class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreDeBiensCulturelMobileEndomager,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreDeBiensCulturelMobileEndomager, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>
                                <br />

                                <div Class="col-md-6">
                                    @Html.LabelFor(Function(m) m.NombreDeBiensCulturelMobileDetruits, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div Class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreDeBiensCulturelMobileDetruits,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreDeBiensCulturelMobileDetruits, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>
                                <br />
                            </div>
                        </fieldset>

                    </div>
                </fieldset>

                @<div Class="form-group row">

                    <Label Class="col-sm-1 col-form-label"></Label>
                    <div Class="col-sm-10">
                        <br />
                        <br />
                        <Button type="submit" Class="btn btn-link btn-square bg-warning text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.Btn_Edit</Button>
                        &nbsp;&nbsp;&nbsp;
                        @Html.ActionLink(Resource.BtnCancel, "Index", "EvenementZones", Nothing, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                    </div>
                </div>

            End Using

        </div>
    </div>
</div>

    <script>

        $('.DeleteDsagregationBetail').click(function (e) {
            e.preventDefault();
            var $ctrl = $(this);
            var Id = $(this).data("id");
            //$.alert("Identifiant= " + Id);
            $.confirm({
                title: '@Resource.Btn_Delete',
                content: '@Resource.ConfirmDelete',
                animationSpeed: 1000,
                animationBounce: 3,
                animation: 'rotatey',
                closeAnimation: 'scaley',
                theme: 'supervan',
                buttons: {
                    Confirmer: function () {
                        $.ajax({
                            url: '@Url.Action("DeleteDsagregationBetail")',
                            type: 'POST',
                            data: { id: Id }
                        }).done(function (data) {
                            if (data.Result == "OK") {
                                //$ctrl.closest('li').remove();
                                $.confirm({
                                    title: '@Resource.SuccessTitle',
                                    content: '@Resource.SuccessProcess',
                                    animationSpeed: 1000,
                                    animationBounce: 3,
                                    animation: 'rotatey',
                                    closeAnimation: 'scaley',
                                    theme: 'supervan',
                                    buttons: {
                                        OK: function () {
                                            window.location.reload();
                                        }
                                    }
                                });
                            }
                            else if (data.Result.Message) {
                                alert(data.Result.Message);
                            }
                        }).fail(function () {
                            @*//$.alert('@Resource.ErrorProcess');*@
                            $.confirm({
                                title: '@Resource.ErreurTitle',
                                content: '@Resource.ErrorProcess',
                                animationSpeed: 1000,
                                animationBounce: 3,
                                animation: 'rotatey',
                                closeAnimation: 'scaley',
                                theme: 'supervan',
                                buttons: {
                                    OK: function () {
                                    }
                                }
                            });
                        })
                    },
                    Annuler: function () {
                        $.confirm({
                            title: '@Resource.CancelingProcess',
                            content: '@Resource.CancelingConfirmed',
                            animationSpeed: 1000,
                            animationBounce: 3,
                            animation: 'rotatey',
                            closeAnimation: 'scaley',
                            theme: 'supervan',
                            buttons: {
                                OK: function () {
                                }
                            }
                        });
                    }
                }
            });
        });


        $('.DeleteDsagregationAgricole').click(function (e) {
            e.preventDefault();
            var $ctrl = $(this);
            var Id = $(this).data("id");
            //$.alert("Identifiant= " + Id);
            $.confirm({
                title: '@Resource.Btn_Delete',
                content: '@Resource.ConfirmDelete',
                animationSpeed: 1000,
                animationBounce: 3,
                animation: 'rotatey',
                closeAnimation: 'scaley',
                theme: 'supervan',
                buttons: {
                    Confirmer: function () {
                        $.ajax({
                            url: '@Url.Action("DeleteDsagregationAgricole")',
                            type: 'POST',
                            data: { id: Id }
                        }).done(function (data) {
                            if (data.Result == "OK") {
                                //$ctrl.closest('li').remove();
                                $.confirm({
                                    title: '@Resource.SuccessTitle',
                                    content: '@Resource.SuccessProcess',
                                    animationSpeed: 1000,
                                    animationBounce: 3,
                                    animation: 'rotatey',
                                    closeAnimation: 'scaley',
                                    theme: 'supervan',
                                    buttons: {
                                        OK: function () {
                                            window.location.reload();
                                        }
                                    }
                                });
                            }
                            else if (data.Result.Message) {
                                alert(data.Result.Message);
                            }
                        }).fail(function () {
                            @*//$.alert('@Resource.ErrorProcess');*@
                            $.confirm({
                                title: '@Resource.ErreurTitle',
                                content: '@Resource.ErrorProcess',
                                animationSpeed: 1000,
                                animationBounce: 3,
                                animation: 'rotatey',
                                closeAnimation: 'scaley',
                                theme: 'supervan',
                                buttons: {
                                    OK: function () {
                                    }
                                }
                            });
                        })
                    },
                    Annuler: function () {
                        $.confirm({
                            title: '@Resource.CancelingProcess',
                            content: '@Resource.CancelingConfirmed',
                            animationSpeed: 1000,
                            animationBounce: 3,
                            animation: 'rotatey',
                            closeAnimation: 'scaley',
                            theme: 'supervan',
                            buttons: {
                                OK: function () {
                                }
                            }
                        });
                    }
                }
            });
        });

    </script>

    <script>
        var HectaresTautauxDesCulturesTouche = '#HectaresTautauxDesCulturesTouche';
        var HectaresEndomages = '#HectaresEndomages';
        var HectaresDetruits = '#HectaresDetruits';
        var totalHectaresTouches = null;

        var NombreDanimauxToucheOuPerdu = '#NombreDanimauxToucheOuPerdu';
        var NombreDanimauxToucher = '#NombreDanimauxToucher';
        var NombreDanimauxPerdu = '#NombreDanimauxPerdu';
        var totalAnimauxTouches = null;

        var NombreTotalHectarForetToucher = '#NombreTotalHectarForetToucher';
        var NombreHectarForetEndomager = '#NombreHectarForetEndomager';
        var NombreHectarForetDetruit = '#NombreHectarForetDetruit';
        var totalForetTouches = null;

        var NombreTotalHectarAquacultureToucher = '#NombreTotalHectarAquacultureToucher';
        var NombreHectarAquacultureEndomager = '#NombreHectarAquacultureEndomager';
        var NombreHectarAquacultureDetruit = '#NombreHectarAquacultureDetruit';
        var totalHectaresAquaculturesTouches = null;

        var NombreTotalNavireToucher = '#NombreTotalNavireToucher';
        var NombreNavireEndomager = '#NombreNavireEndomager';
        var NombreNavireDetruit = '#NombreNavireDetruit';
        var totalNavireDetruits = null;

        var NombreTotalDinstallationStockAgricoleToucher = '#NombreTotalDinstallationStockAgricoleToucher';
        var NombreDinstallationStockAgricoleEndomager = '#NombreDinstallationStockAgricoleEndomager';
        var NombreDinstallationStockAgricoleDetruit = '#NombreDinstallationStockAgricoleDetruit';
        var totalStockAgricoleDetruit = null;

        var NombreTotalActifsProductifAfricoleToucher = '#NombreTotalActifsProductifAfricoleToucher';
        var NombreActifsProductifAfricoleEndomager = '#NombreActifsProductifAfricoleEndomager';
        var NombreActifsProductifAfricoleDetruit = '#NombreActifsProductifAfricoleDetruit';
        var totalActifsProductifAfricole = null;

        var NombreTotalInstallationActifsProductifsToucher = '#NombreTotalInstallationActifsProductifsToucher';
        var NombreInstallationActifsProductifsEndomager = '#NombreInstallationActifsProductifsEndomager';
        var NombreInstallationActifsProductifsDetruit = '#NombreInstallationActifsProductifsDetruit';
        var totalActifsProductifs = null;

        var TotalEconomiqueLogementEndomagerOuDetruit = '#TotalEconomiqueLogementEndomagerOuDetruit';
        var ValeurEconomiqueDesMaisonsEndomager = '#ValeurEconomiqueDesMaisonsEndomager';
        var ValeurEconomiqueDesMaisonsDetruites = '#ValeurEconomiqueDesMaisonsDetruites';
        var totalLogementEndomagerDetruit = null;


        function SommeCultures() {
            initalisationPourCultures();
            var totalHectaresTautauxDesCulturesTouche = $(HectaresTautauxDesCulturesTouche).val();
            //alert("totalHectaresTouches =" + totalHectaresTouches);
            if (+totalHectaresTouches > 0) {
                if (+totalHectaresTautauxDesCulturesTouche > 0) {
                    if (+totalHectaresTautauxDesCulturesTouche !== totalHectaresTouches) {
                        $.alert("Veuillez vous assurer que la somme des élements touchés et détruits donne le total entré en amont.");
                        document.getElementById("HectaresTautauxDesCulturesTouche").value = null;
                    } else {
                        document.getElementById("HectaresTautauxDesCulturesTouche").value = totalHectaresTautauxDesCulturesTouche;
                    }
                } else {
                    document.getElementById("HectaresTautauxDesCulturesTouche").value = totalHectaresTouches;
                }
            }
            //else {
            //    document.getElementById("HectaresTautauxDesCulturesTouche").value = null;
            //}
        }

        function SommeBetails() {
            initalisationPourBetails();
            var totalNombreDanimauxToucheOuPerdu = $(NombreDanimauxToucheOuPerdu).val();
            //alert("totalAnimauxTouches =" + totalAnimauxTouches);
            if (+totalAnimauxTouches > 0) {
                if (+totalNombreDanimauxToucheOuPerdu > 0) {
                    if (+totalNombreDanimauxToucheOuPerdu !== totalAnimauxTouches) {
                        $.alert("Veuillez vous assurer que la somme des élements touchés et détruits donne le total entré en amont.");
                        document.getElementById("NombreDanimauxToucheOuPerdu").value = null;
                    } else {
                        document.getElementById("NombreDanimauxToucheOuPerdu").value = totalNombreDanimauxToucheOuPerdu;
                    }
                } else {
                    document.getElementById("NombreDanimauxToucheOuPerdu").value = totalAnimauxTouches;
                }
            }

        }

        function SommeForetToucher() {
            initalisationPourForetToucher();
            var totalNombreTotalHectarForetToucher = $(NombreTotalHectarForetToucher).val();

            if (+totalForetTouches > 0) {
                if (+totalNombreTotalHectarForetToucher > 0) {
                    if (+totalNombreTotalHectarForetToucher !== totalForetTouches) {
                        $.alert("Veuillez vous assurer que la somme des élements touchés et détruits donne le total entré en amont.");
                        document.getElementById("NombreTotalHectarForetToucher").value = null;
                    } else {
                        document.getElementById("NombreTotalHectarForetToucher").value = totalNombreTotalHectarForetToucher;
                    }
                } else {
                    document.getElementById("NombreTotalHectarForetToucher").value = totalForetTouches;
                }
            }

        }

        function SommeAquacultureToucher() {
            initalisationPourAquacultures();
            var totalNombreTotalHectarAquacultureToucher = $(NombreTotalHectarAquacultureToucher).val();

            if (+totalHectaresAquaculturesTouches > 0) {
                if (+totalNombreTotalHectarAquacultureToucher > 0) {
                    if (+totalNombreTotalHectarAquacultureToucher !== totalHectaresAquaculturesTouches) {
                        $.alert("Veuillez vous assurer que la somme des élements touchés et détruits donne le total entré en amont.");
                        document.getElementById("NombreTotalHectarAquacultureToucher").value = null;
                    } else {
                        document.getElementById("NombreTotalHectarAquacultureToucher").value = totalNombreTotalHectarAquacultureToucher;
                    }
                } else {
                    document.getElementById("NombreTotalHectarAquacultureToucher").value = totalHectaresAquaculturesTouches;
                }
            }

        }

        function SommeNavireToucher() {
            initalisationPourNavires();
            var totalNombreTotalNavireToucher = $(NombreTotalNavireToucher).val();

            if (+totalNavireDetruits > 0) {
                if (+totalNombreTotalNavireToucher > 0) {
                    if (+totalNombreTotalNavireToucher !== totalNavireDetruits) {
                        $.alert("Veuillez vous assurer que la somme des élements touchés et détruits donne le total entré en amont.");
                        document.getElementById("NombreTotalNavireToucher").value = null;
                    } else {
                        document.getElementById("NombreTotalNavireToucher").value = totalNombreTotalNavireToucher;
                    }
                } else {
                    document.getElementById("NombreTotalNavireToucher").value = totalNavireDetruits;
                }
            }

        }

        function SommeStockAgricoleToucher() {
            initalisationPourStockAgricole();
            var totalNombreTotalDinstallationStockAgricoleToucher = $(NombreTotalDinstallationStockAgricoleToucher).val();

            if (+totalStockAgricoleDetruit > 0) {
                if (+totalNombreTotalDinstallationStockAgricoleToucher > 0) {
                    if (+totalNombreTotalDinstallationStockAgricoleToucher !== totalStockAgricoleDetruit) {
                        $.alert("Veuillez vous assurer que la somme des élements touchés et détruits donne le total entré en amont.");
                        document.getElementById("NombreTotalDinstallationStockAgricoleToucher").value = null;
                    } else {
                        document.getElementById("NombreTotalDinstallationStockAgricoleToucher").value = totalNombreTotalDinstallationStockAgricoleToucher;
                    }
                } else {
                    document.getElementById("NombreTotalDinstallationStockAgricoleToucher").value = totalStockAgricoleDetruit;
                }
            }

        }

        function SommeActifsProductifAfricole() {
            initalisationPourActifsProductifAfricole();
            var totalNombreTotalActifsProductifAfricoleToucher = $(NombreTotalActifsProductifAfricoleToucher).val();

            if (+totalActifsProductifAfricole > 0) {
                if (+totalNombreTotalActifsProductifAfricoleToucher > 0) {
                    if (+totalNombreTotalActifsProductifAfricoleToucher !== totalActifsProductifAfricole) {
                        $.alert("Veuillez vous assurer que la somme des élements touchés et détruits donne le total entré en amont.");
                        document.getElementById("NombreTotalActifsProductifAfricoleToucher").value = null;
                    } else {
                        document.getElementById("NombreTotalActifsProductifAfricoleToucher").value = totalNombreTotalActifsProductifAfricoleToucher;
                    }
                } else {
                    document.getElementById("NombreTotalActifsProductifAfricoleToucher").value = totalActifsProductifAfricole;
                }
            }

        }

        function SommeActifsProductifs() {
            initalisationPourActifsProductifs();
            var totalNombreTotalInstallationActifsProductifsToucher = $(NombreTotalInstallationActifsProductifsToucher).val();

            if (+totalActifsProductifs > 0) {
                if (+totalNombreTotalInstallationActifsProductifsToucher > 0) {
                    if (+totalNombreTotalInstallationActifsProductifsToucher !== totalActifsProductifs) {
                        $.alert("Veuillez vous assurer que la somme des élements touchés et détruits donne le total entré en amont.");
                        document.getElementById("NombreTotalInstallationActifsProductifsToucher").value = null;
                    } else {
                        document.getElementById("NombreTotalInstallationActifsProductifsToucher").value = totalNombreTotalInstallationActifsProductifsToucher;
                    }
                } else {
                    document.getElementById("NombreTotalInstallationActifsProductifsToucher").value = totalActifsProductifs;
                }
            }

        }

        function SommeLogementsEndommagesDetruits() {
            initalisationPourLogementsEndommagesDetruits();
            var totalTotalEconomiqueLogementEndomagerOuDetruit = $(TotalEconomiqueLogementEndomagerOuDetruit).val();

            if (+totalLogementEndomagerDetruit > 0) {
                if (+totalTotalEconomiqueLogementEndomagerOuDetruit > 0) {
                    if (+totalTotalEconomiqueLogementEndomagerOuDetruit !== totalLogementEndomagerDetruit) {
                        $.alert("Veuillez vous assurer que la somme des élements touchés et détruits donne le total entré en amont.");
                        document.getElementById("TotalEconomiqueLogementEndomagerOuDetruit").value = null;
                    } else {
                        document.getElementById("TotalEconomiqueLogementEndomagerOuDetruit").value = totalTotalEconomiqueLogementEndomagerOuDetruit;
                    }
                } else {
                    document.getElementById("TotalEconomiqueLogementEndomagerOuDetruit").value = totalLogementEndomagerDetruit;
                }
            }

        }

        function initalisationPourBetails() {
            animauxTouches = $(NombreDanimauxToucher).val().replace(",", ".");
            animauxPerdus = $(NombreDanimauxPerdu).val().replace(",", ".");
            var arrayBetails = [animauxTouches, animauxPerdus];
            totalAnimauxTouches = checkItems(arrayBetails);
        }

        function initalisationPourCultures() {
            //var totalHectaresTautauxDesCulturesTouche = $(NombreTotalDeces).val();

            culturesEndomagees = $(HectaresEndomages).val().replace(",", ".");
            culturesDetruites = $(HectaresDetruits).val().replace(",", ".");
            var arrayCultures = [culturesEndomagees, culturesDetruites];
            totalHectaresTouches = checkItems(arrayCultures);

        }

        function initalisationPourForetToucher() {
            foretsTouchees = $(NombreHectarForetEndomager).val().replace(",", ".");
            foretsPerdues = $(NombreHectarForetDetruit).val().replace(",", ".");
            var arrayForets = [foretsTouchees, foretsPerdues];
            totalForetTouches = checkItems(arrayForets);
        }

        function initalisationPourAquacultures() {
            AquaculturesEndomagees = $(NombreHectarAquacultureEndomager).val().replace(",", ".");
            AquaculturesDetruites = $(NombreHectarAquacultureDetruit).val().replace(",", ".");
            var arrayAquacultures = [AquaculturesEndomagees, AquaculturesDetruites];
            totalHectaresAquaculturesTouches = checkItems(arrayAquacultures);

        }

        function initalisationPourNavires() {
            naviresEndomagees = $(NombreNavireEndomager).val().replace(",", ".");
            naviresDetruites = $(NombreNavireDetruit).val().replace(",", ".");
            var arrayNavires = [naviresEndomagees, naviresDetruites];
            totalNavireDetruits = checkItems(arrayNavires);

        }

        function initalisationPourStockAgricole() {
            stockAgricoleEndomage = $(NombreDinstallationStockAgricoleEndomager).val().replace(",", ".");
            stockAgricoleDetruit = $(NombreDinstallationStockAgricoleDetruit).val().replace(",", ".");
            var arrayStockAgricole = [stockAgricoleEndomage, stockAgricoleDetruit];
            totalStockAgricoleDetruit = checkItems(arrayStockAgricole);

        }

        function initalisationPourActifsProductifAfricole() {
            stockActifsProductifEndomage = $(NombreActifsProductifAfricoleEndomager).val().replace(",", ".");
            stockActifsProductifDetruit = $(NombreActifsProductifAfricoleDetruit).val().replace(",", ".");
            var arrayActifsProductif = [stockActifsProductifEndomage, stockActifsProductifDetruit];
            totalActifsProductifAfricole = checkItems(arrayActifsProductif);

        }

        function initalisationPourActifsProductifs() {
            ActifsProductifsEndomages = $(NombreInstallationActifsProductifsEndomager).val().replace(",", ".");
            ActifsProductifsDetruits = $(NombreInstallationActifsProductifsDetruit).val().replace(",", ".");
            var arrayActifsProductifs = [ActifsProductifsEndomages, ActifsProductifsDetruits];
            totalActifsProductifs = checkItems(arrayActifsProductifs);

        }

        function initalisationPourLogementsEndommagesDetruits() {
            maisonsEndomagees = $(ValeurEconomiqueDesMaisonsEndomager).val().replace(",", ".");
            maisonsDetruites = $(ValeurEconomiqueDesMaisonsDetruites).val().replace(",", ".");
            var arrayLogements = [maisonsEndomagees, maisonsDetruites];
            totalLogementEndomagerDetruit = checkItems(arrayLogements);

        }

        function checkItems(array) {
            var result = null;
            array.forEach(function (item) {
                if (item !== null && typeof (item) !== undefined) {
                    result = (result === null) ? +item : (+result + +item);
                }
            });
            return result;
        }


    </script>