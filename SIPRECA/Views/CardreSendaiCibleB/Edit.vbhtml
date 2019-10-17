﻿@ModelType SIPRECA.CardreSendaiCibleBViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewData("Title") = Resource.EditIndicateursCibleB
    Layout = "~/Views/Shared/_LayoutDesinventar.vbhtml"
End Code

<div class="page-header">
    <h1 class="page-title">@Resource.ManageEvenementZone</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "EvenementZones")>@Resource.ManageEvenementZone</a></li>
        <li class="breadcrumb-item active">@Resource.EditIndicateursCibleB</li>
    </ol>
</div>


<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.EditIndicateursCibleB</div>
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
                        Veuillez enregistrer Dans cette section, les impacts humains et physiques nécessaires au calcul des indicateurs B2, B3, B4 et B5. Si possible, entrez des chiffres désagrégés et
                        utilisez le bouton "<strong>Faire Somme</strong>" pour calculer la somme de chaque sous-groupe.
                    </p>
                </div>

                @<fieldset style="border:ridge;">
                    <legend style="font-size: 14px">@Resource.NombrePersonnesBlesseesOuMalades</legend>
                    <br />
                    <br />
                    <div Class="form-group row">
                        <div Class="col-md-3">
                            @Html.LabelFor(Function(m) m.NombreTotalBlesse, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%"}) (B-2)
                            <div class="col-sm-8" style="max-width: 100%">
                                @Html.EditorFor(Function(model) model.NombreTotalBlesse,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                @Html.ValidationMessageFor(Function(m) m.NombreTotalBlesse, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <br />
                            &nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;
                            <button onclick="SommeB lesses();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
                        </div>

                        <div Class="col-md-3">
                            <fieldset style="border: ridge;">
                                <legend style="font-size: 14px">@Resource.ParSexe</legend>

                                @Html.LabelFor(Function(m) m.NombreBlesseFemme, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreBlesseFemme,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreBlesseFemme, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreBlesseHomme, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreBlesseHomme,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "4", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreBlesseHomme, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </fieldset>
                        </div>

                        <div Class="col-md-3">
                            <fieldset style="border: ridge;">
                                <legend style="font-size: 14px">@Resource.ParAge</legend>

                                @Html.LabelFor(Function(m) m.NombreBlesseEnfant, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%,"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreBlesseEnfant,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "5", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreBlesseEnfant, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreBlesseAdult, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreBlesseAdult,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "6", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreBlesseAdult, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreBlesseVieux, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%;max-width: 100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreBlesseVieux,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "7", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreBlesseVieux, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </fieldset>
                        </div>

                        <div Class="col-md-3">
                            <fieldset style="border: ridge;">
                                <legend style="font-size: 14px">@Resource.AutreDesagregation</legend>

                                @Html.LabelFor(Function(m) m.NombreBlesseHandicape, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%;max-width: 100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreBlesseHandicape,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "8", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreBlesseHandicape, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreBlessePauvre, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%;max-width: 100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreBlessePauvre,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "9", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreBlessePauvre, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </fieldset>
                        </div>

                    </div>

                </fieldset>

                @<br />
                @<br />

                @<fieldset style="border:ridge;">
                    <legend style="font-size: 14px">@Resource.NombrePersonnesLogementEndommagees</legend>
                    <br />
                    <br />
                    <div Class="form-group row">
                        <div Class="col-md-3">
                            @Html.LabelFor(Function(m) m.NombreTotalMaisonEndomage, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%;;max-width: 100%"})
                            <div class="col-sm-8" style="max-width: 100%">
                                @Html.EditorFor(Function(model) model.NombreTotalMaisonEndomage,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "10", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                @Html.ValidationMessageFor(Function(m) m.NombreTotalMaisonEndomage, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <br />
                            @Html.LabelFor(Function(m) m.NombreTotalPersonneMaisonEndomage, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%;;max-width: 100%"})
                            <div class="col-sm-8" style="max-width: 100%">
                                @Html.EditorFor(Function(model) model.NombreTotalPersonneMaisonEndomage,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "10", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                @Html.ValidationMessageFor(Function(m) m.NombreTotalPersonneMaisonEndomage, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <br />
                            &nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;
                            <button onclick="SommeEndommagees();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
                        </div>

                        <div Class="col-md-3">
                            <fieldset style="border: ridge;">
                                <legend style="font-size: 14px">@Resource.ParSexe</legend>

                                @Html.LabelFor(Function(m) m.NombreMaisonEndomageFemme, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreMaisonEndomageFemme,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "11", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreMaisonEndomageFemme, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreMaisonEndomageHomme, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreMaisonEndomageHomme,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "12", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreMaisonEndomageHomme, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </fieldset>
                        </div>

                        <div Class="col-md-3">
                            <fieldset style="border: ridge;">
                                <legend style="font-size: 14px">@Resource.ParAge</legend>

                                @Html.LabelFor(Function(m) m.NombreMaisonEndomageEnfant, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%,"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreMaisonEndomageEnfant,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "13", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreMaisonEndomageEnfant, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreMaisonEndomageAdult, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreMaisonEndomageAdult,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "14", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreMaisonEndomageAdult, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreMaisonEndomageVieux, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%;max-width: 100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreMaisonEndomageVieux,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "15", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreMaisonEndomageVieux, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </fieldset>
                        </div>

                        <div Class="col-md-3">
                            <fieldset style="border: ridge;">
                                <legend style="font-size: 14px">@Resource.AutreDesagregation</legend>

                                @Html.LabelFor(Function(m) m.NombreMaisonEndomageHandicape, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%;max-width: 100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreMaisonEndomageHandicape,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "16", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreMaisonEndomageHandicape, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreMaisonEndomagePauvre, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%;max-width: 100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreMaisonEndomagePauvre,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "17", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreMaisonEndomagePauvre, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </fieldset>


                        </div>

                    </div>

                </fieldset>

                @<br />
                @<br />

                @<fieldset style="border:ridge;">
                    <legend style="font-size: 14px">@Resource.NombrePersonnesLogementDetruits</legend>
                    <br />
                    <br />
                    <div Class="form-group row">
                        <div Class="col-md-3">
                            @Html.LabelFor(Function(m) m.NombreTotalMaisonDetruite, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%;;max-width: 100%"}) (B -4)
                            <div class="col-sm-8" style="max-width: 100%">
                                @Html.EditorFor(Function(model) model.NombreTotalMaisonDetruite,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "10", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                @Html.ValidationMessageFor(Function(m) m.NombreTotalMaisonDetruite, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <br />
                            @Html.LabelFor(Function(m) m.NombreTotalPersonneMaisonDetruite, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%;;max-width: 100%"})
                            <div class="col-sm-8" style="max-width: 100%">
                                @Html.EditorFor(Function(model) model.NombreTotalPersonneMaisonDetruite,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "10", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                @Html.ValidationMessageFor(Function(m) m.NombreTotalPersonneMaisonDetruite, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <br />
                            &nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;
                            <button onclick="SommeDetruite();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
                        </div>

                        <div Class="col-md-3">
                            <fieldset style="border: ridge;">
                                <legend style="font-size: 14px">@Resource.ParSexe</legend>

                                @Html.LabelFor(Function(m) m.NombreMaisonDetruiteFemme, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreMaisonDetruiteFemme,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "11", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreMaisonDetruiteFemme, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreMaisonDetruiteHomme, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreMaisonDetruiteHomme,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "12", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreMaisonDetruiteHomme, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </fieldset>
                        </div>

                        <div Class="col-md-3">
                            <fieldset style="border: ridge;">
                                <legend style="font-size: 14px">@Resource.ParAge</legend>

                                @Html.LabelFor(Function(m) m.NombreMaisonDetruiteEnfant, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%,"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreMaisonDetruiteEnfant,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "13", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreMaisonDetruiteEnfant, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreMaisonDetruiteAdult, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreMaisonDetruiteAdult,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "14", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreMaisonDetruiteAdult, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreMaisonEndomageVieux, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%;max-width: 100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreMaisonDetruiteVieux,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "15", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreMaisonDetruiteVieux, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </fieldset>
                        </div>

                        <div Class="col-md-3">
                            <fieldset style="border: ridge;">
                                <legend style="font-size: 14px">@Resource.AutreDesagregation</legend>

                                @Html.LabelFor(Function(m) m.NombreMaisonDetruiteHandicape, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%;max-width: 100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreMaisonDetruiteHandicape,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "16", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreMaisonDetruiteHandicape, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreMaisonEndomagePauvre, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%;max-width: 100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreMaisonDetruitePauvre,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "17", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreMaisonDetruitePauvre, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </fieldset>
                        </div>

                    </div>

                </fieldset>

                @<br />
                @<br />

                @<fieldset style="border:ridge;">
                     <legend style="font-size: 14px">@Resource.NombreImpactSurLesMoyensDeSubsistance</legend>
                    <br />
                    <br />
                    <div Class="form-group row">
                        <div Class="col-md-3">
                            @Html.LabelFor(Function(m) m.NombreTotalMoyenSubsistance, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%;;max-width: 100%"}) (B - 5)
                            <div class="col-sm-8" style="max-width: 100%">
                                @Html.EditorFor(Function(model) model.NombreTotalMoyenSubsistance,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "10", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                @Html.ValidationMessageFor(Function(m) m.NombreTotalMoyenSubsistance, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <br />
                            &nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;
                            <button onclick="SommeMoyenSubsistances();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
                        </div>

                        <div Class="col-md-3">
                            <fieldset style="border: ridge;">
                                <legend style="font-size: 14px">@Resource.ParSexe</legend>

                                @Html.LabelFor(Function(m) m.NombreMoyenSubsistanceFemme, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreMoyenSubsistanceFemme,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "11", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreMoyenSubsistanceFemme, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreMoyenSubsistanceHomme, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreMoyenSubsistanceHomme,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "12", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreMoyenSubsistanceHomme, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </fieldset>
                        </div>

                        <div Class="col-md-3">
                            <fieldset style="border: ridge;">
                                <legend style="font-size: 14px">@Resource.ParAge</legend>

                                @Html.LabelFor(Function(m) m.NombreMoyenSubsistanceEnfant, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%,"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreMoyenSubsistanceEnfant,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "13", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreMoyenSubsistanceEnfant, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreMoyenSubsistanceAdult, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreMoyenSubsistanceAdult,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "14", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreMoyenSubsistanceAdult, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreMoyenSubsistanceVieux, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%;max-width: 100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreMoyenSubsistanceVieux,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "15", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreMoyenSubsistanceVieux, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </fieldset>
                        </div>

                        <div Class="col-md-3">
                            <fieldset style="border: ridge;">
                                <legend style="font-size: 14px">@Resource.AutreDesagregation</legend>

                                @Html.LabelFor(Function(m) m.NombreMoyenSubsistanceHandicape, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%;max-width: 100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreMoyenSubsistanceHandicape,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "16", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreMoyenSubsistanceHandicape, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreMoyenSubsistancePauvre, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%;max-width: 100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreMoyenSubsistancePauvre,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "17", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreMoyenSubsistancePauvre, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </fieldset>


                        </div>

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
