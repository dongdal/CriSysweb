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
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "EvenementZones")>@Resource.ManageEvenementZone</a></li>
        <li class="breadcrumb-item active">@Resource.EditIndicateursCibleC</li>
    </ol>
</div>


<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.EditIndicateursCibleC</div>
            <hr>
            @Using Html.BeginForm("Edit", "EvenementZones", FormMethod.Post, New With {.autocomplete = "off"})
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
                                        <button onclick="SommeBlesses();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
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
                                        <button onclick="SommeBlesses();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
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
                                        <button onclick="SommeAquacultureToucher();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
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
                                            <button onclick="SommeActifsProductifs();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
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

                @<fieldset style="border:ridge; margin:10px;" Class="col-md-4">
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
