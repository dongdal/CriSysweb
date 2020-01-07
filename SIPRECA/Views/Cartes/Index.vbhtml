@ModelType FiltreViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.ListMoyenDereponse
    Layout = "~/Views/Shared/_LayoutSahana.vbhtml"
End Code
@Styles.Render("~/Assets/LeafletCSS")


<div class="page-header">
    <h1 class="page-title">@Resource.ManageMoyen</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Cartes")>@Resource.ManageMoyen</a></li>
        <li class="breadcrumb-item active">@Resource.ListMoyenDereponse</li>
    </ol>
</div>

@*@Html.Partial("_MyMapPartial")*@

@section css
    <style>
        #mapid {
            height: 500px;
        }
    </style>
End Section

<div id="mapid"></div>


<div class="container-fluid">

    <div class="card">
        <div class="card-body">

            <hr>
            @Using Html.BeginForm("Query", "Cartes", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()

                @<div Class="form-group row">

                    <div class="col-sm-4 form-group">
                        @Html.LabelFor(Function(m) m.OrganisationId, New With {.class = "col-form-label"})<br />
                        @Html.DropDownListFor(Function(m) m.OrganisationId, New SelectList(Model.LesOrganisations, "Value", "Text"),
New With {.class = "form-control", .multiple = "multiple", .tabindex = "2", .style = "font-size: 12px;"})
                        @Html.ValidationMessageFor(Function(m) m.OrganisationId, "", New With {.style = "color: #da0b0b"})
                    </div>

                    <div class="col-sm-4 form-group">
                        @Html.LabelFor(Function(m) m.VilleId, New With {.class = "col-form-label"})<br />
                        @Html.DropDownListFor(Function(m) m.VilleId, New SelectList(Model.LesVilles, "Value", "Text"),
New With {.class = "form-control", .multiple = "multiple", .tabindex = "2", .style = "font-size: 12px;"})
                        @Html.ValidationMessageFor(Function(m) m.VilleId, "", New With {.style = "color: #da0b0b"})
                    </div>

                </div>

                @<div Class="form-group row">
                    <div class="row col-md-12">
                        <fieldset style="border: ridge;" class="col-md-12">
                            <legend style="font-size: 14px">@Resource.SelectionAbris</legend>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="row">

                                        <div class="col-sm-2 form-group">
                                            @Html.CheckBoxFor(Function(model) model.Abris,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "1", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "}})
                                            <br />
                                            @Html.LabelFor(Function(m) m.Abris, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                        </div>
                                        <div class="col-sm-2 form-group">
                                            @Html.LabelFor(Function(m) m.TypeAbrisId, New With {.class = "col-form-label", .style = "font-size: 8px;  height: 25px; "})<br />
                                            @Html.DropDownListFor(Function(m) m.TypeAbrisId, New SelectList(Model.LesTypeAbris, "Value", "Text"),
New With {.class = "form-control", .multiple = "multiple", .tabindex = "2", .style = "font-size: 12px;"})
                                            @Html.ValidationMessageFor(Function(m) m.TypeAbrisId, "", New With {.style = "color: #da0b0b"})
                                        </div>

                                        <div class="col-sm-2 form-group">
                                            @Html.LabelFor(Function(m) m.MaterielAbrisId, New With {.class = "col-form-label", .style = "font-size: 8px;  height: 25px; "})<br />
                                            @Html.DropDownListFor(Function(m) m.MaterielAbrisId, New SelectList(Model.LesMaterielsAbris, "Value", "Text"),
New With {.class = "form-control", .multiple = "multiple", .tabindex = "2", .style = "font-size: 12px;"})
                                            @Html.ValidationMessageFor(Function(m) m.MaterielAbrisId, "", New With {.style = "color: #da0b0b"})
                                        </div>

                                        <div class="col-sm-2 form-group">
                                            @Html.LabelFor(Function(m) m.AbrisCapaciteMin, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                            @Html.EditorFor(Function(model) model.AbrisCapaciteMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.AbrisCapaciteMin, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                        <div class="col-sm-2 form-group">
                                            @Html.LabelFor(Function(m) m.AbrisCapaciteMAx, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                            @Html.EditorFor(Function(model) model.AbrisCapaciteMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.AbrisCapaciteMAx, "", New With {.style = "color: #da0b0b"})
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-sm-2 form-group">

                                        </div>
                                        <div class="col-sm-2 form-group">
                                            @Html.LabelFor(Function(m) m.AbrisEstimationPopulationMin, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                            @Html.EditorFor(Function(model) model.AbrisEstimationPopulationMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "1", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; "}})
                                            @Html.ValidationMessageFor(Function(m) m.AbrisEstimationPopulationMin, "", New With {.style = "color: #da0b0b"})

                                        </div>
                                        <div class="col-sm-2 form-group">
                                            @Html.LabelFor(Function(m) m.AbrisEstimationPopulationMAx, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                            @Html.EditorFor(Function(model) model.AbrisEstimationPopulationMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "1", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; "}})
                                            @Html.ValidationMessageFor(Function(m) m.AbrisEstimationPopulationMAx, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                        </fieldset>
                    </div>
                </div>


                @<div Class="form-group row">

                    <fieldset style="border: ridge;" class="col-md-12">
                        <legend style="font-size: 14px">@Resource.SelectionAeroport</legend>
                        <div class="row">

                            <div class="col-sm-2">
                                @Html.CheckBoxFor(Function(model) model.Aeroport,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "1", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "}})
                                <br />
                                @Html.LabelFor(Function(m) m.Aeroport, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.TailleDeAeronefId, New With {.class = "col-form-label", .style = "font-size: 8px;  height: 25px; "})<br />
                                @Html.DropDownListFor(Function(m) m.TailleDeAeronefId, New SelectList(Model.LesTailleDeAeronefs, "Value", "Text"),
New With {.class = "form-control", .multiple = "multiple", .tabindex = "2", .style = "font-size: 12px;"})
                                @Html.ValidationMessageFor(Function(m) m.TailleDeAeronefId, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.MaterielAeroportId, New With {.class = "col-form-label", .style = "font-size: 8px;  height: 25px; "})<br />
                                @Html.DropDownListFor(Function(m) m.MaterielAeroportId, New SelectList(Model.LesMaterielAeroport, "Value", "Text"),
New With {.class = "form-control", .multiple = "multiple", .tabindex = "2", .style = "font-size: 12px;"})
                                @Html.ValidationMessageFor(Function(m) m.MaterielAeroportId, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.AeroportLargeurDePisteMin, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                @Html.EditorFor(Function(model) model.AeroportLargeurDePisteMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                @Html.ValidationMessageFor(Function(m) m.AeroportLargeurDePisteMin, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.AeroportLargeurDePisteMAx, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                @Html.EditorFor(Function(model) model.AeroportLargeurDePisteMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                @Html.ValidationMessageFor(Function(m) m.AeroportLargeurDePisteMAx, "", New With {.style = "color: #da0b0b"})
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2">

                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.AeroportLongueurDePisteMin, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                @Html.EditorFor(Function(model) model.AeroportLongueurDePisteMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "1", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; "}})
                                @Html.ValidationMessageFor(Function(m) m.AeroportLongueurDePisteMin, "", New With {.style = "color: #da0b0b"})

                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.AeroportLongueurDePisteMAx, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                @Html.EditorFor(Function(model) model.AeroportLongueurDePisteMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "1", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; "}})
                                @Html.ValidationMessageFor(Function(m) m.AeroportLongueurDePisteMAx, "", New With {.style = "color: #da0b0b"})
                            </div>
                        </div>
                        <br />
                    </fieldset>
                </div>


                @<div Class="form-group row">

                    <fieldset style="border: ridge;" class="col-md-12">
                        <legend style="font-size: 14px">@Resource.SelectionEntrepot</legend>
                        <div class="row">

                            <div class="col-sm-2">
                                @Html.CheckBoxFor(Function(model) model.Entrepot,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "1", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "}})
                                <br />
                                @Html.LabelFor(Function(m) m.Entrepot, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.TypeEntrepotId, New With {.class = "col-form-label", .style = "font-size: 8px;  height: 25px; "})<br />
                                @Html.DropDownListFor(Function(m) m.TypeEntrepotId, New SelectList(Model.LesTypeEntrepots, "Value", "Text"),
New With {.class = "form-control", .multiple = "multiple", .tabindex = "2", .style = "font-size: 12px;"})
                                @Html.ValidationMessageFor(Function(m) m.TypeEntrepotId, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.MaterielEntrepotsId, New With {.class = "col-form-label", .style = "font-size: 8px;  height: 25px; "})<br />
                                @Html.DropDownListFor(Function(m) m.MaterielEntrepotsId, New SelectList(Model.LesMaterielEntrepots, "Value", "Text"),
New With {.class = "form-control", .multiple = "multiple", .tabindex = "2", .style = "font-size: 12px;"})
                                @Html.ValidationMessageFor(Function(m) m.MaterielEntrepotsId, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.EntrepotCapaciteDisponibleMin, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                @Html.EditorFor(Function(model) model.EntrepotCapaciteDisponibleMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                @Html.ValidationMessageFor(Function(m) m.EntrepotCapaciteDisponibleMin, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.EntrepotCapaciteDisponibleMAx, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                @Html.EditorFor(Function(model) model.EntrepotCapaciteDisponibleMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                @Html.ValidationMessageFor(Function(m) m.EntrepotCapaciteDisponibleMAx, "", New With {.style = "color: #da0b0b"})
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2">

                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.EntrepotCapaciteMin, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                @Html.EditorFor(Function(model) model.EntrepotCapaciteMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "1", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; "}})
                                @Html.ValidationMessageFor(Function(m) m.EntrepotCapaciteMin, "", New With {.style = "color: #da0b0b"})

                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.EntrepotCapaciteMAx, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                @Html.EditorFor(Function(model) model.EntrepotCapaciteMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "1", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; "}})
                                @Html.ValidationMessageFor(Function(m) m.EntrepotCapaciteMAx, "", New With {.style = "color: #da0b0b"})
                            </div>
                        </div>
                        <br />
                    </fieldset>
                </div>


                @<div Class="form-group row">

                    <fieldset style="border: ridge;" class="col-md-12">
                        <legend style="font-size: 14px">@Resource.SelectionHopitaux</legend>
                        <div class="row">
                            <div class="col-sm-2">
                                @Html.CheckBoxFor(Function(model) model.Hopitaux,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "1", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "}})
                                <br />
                                @Html.LabelFor(Function(m) m.Hopitaux, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.TypeHopitauxId, New With {.class = "col-form-label", .style = "font-size: 8px;  height: 25px; "})<br />
                                @Html.DropDownListFor(Function(m) m.TypeHopitauxId, New SelectList(Model.LesTypeHopitaux, "Value", "Text"),
New With {.class = "form-control", .multiple = "multiple", .tabindex = "2", .style = "font-size: 12px;"})
                                @Html.ValidationMessageFor(Function(m) m.TypeHopitauxId, "", New With {.style = "color: #da0b0b"})
                            </div>

                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.MaterielHopitauxId, New With {.class = "col-form-label", .style = "font-size: 8px;  height: 25px; "})<br />
                                @Html.DropDownListFor(Function(m) m.MaterielHopitauxId, New SelectList(Model.LesMaterielHopitaux, "Value", "Text"),
New With {.class = "form-control", .multiple = "multiple", .tabindex = "2", .style = "font-size: 12px;"})
                                @Html.ValidationMessageFor(Function(m) m.MaterielHopitauxId, "", New With {.style = "color: #da0b0b"})
                            </div>

                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.NombreDInfimiereMin, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                @Html.EditorFor(Function(model) model.NombreDInfimiereMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                @Html.ValidationMessageFor(Function(m) m.NombreDInfimiereMin, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.NombreDInfimiereMAx, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                @Html.EditorFor(Function(model) model.NombreDInfimiereMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                @Html.ValidationMessageFor(Function(m) m.NombreDInfimiereMAx, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.NombreDeMedecinMin, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                @Html.EditorFor(Function(model) model.NombreDeMedecinMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "1", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; "}})
                                @Html.ValidationMessageFor(Function(m) m.NombreDeMedecinMin, "", New With {.style = "color: #da0b0b"})
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-offset-2 col-sm-2">

                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.NombreDeMedecinMax, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                @Html.EditorFor(Function(model) model.NombreDeMedecinMax,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "1", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; "}})
                                @Html.ValidationMessageFor(Function(m) m.NombreDeMedecinMax, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <div class="col-md-offset-2 col-sm-2">
                                @Html.LabelFor(Function(m) m.NombreDePersonnelNonMedicalMin, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                @Html.EditorFor(Function(model) model.NombreDePersonnelNonMedicalMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "1", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; "}})
                                @Html.ValidationMessageFor(Function(m) m.NombreDePersonnelNonMedicalMin, "", New With {.style = "color: #da0b0b"})
                            </div>

                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.NombreDePersonnelNonMedicalMAx, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                @Html.EditorFor(Function(model) model.NombreDePersonnelNonMedicalMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                @Html.ValidationMessageFor(Function(m) m.NombreDePersonnelNonMedicalMAx, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.NombreDeLitMin, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                @Html.EditorFor(Function(model) model.NombreDeLitMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                @Html.ValidationMessageFor(Function(m) m.NombreDeLitMin, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.NombreDeLitMax, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                @Html.EditorFor(Function(model) model.NombreDeLitMax,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "1", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; "}})
                                @Html.ValidationMessageFor(Function(m) m.NombreDeLitMax, "", New With {.style = "color: #da0b0b"})
                            </div>

                        </div>
                        <br />
                    </fieldset>

                </div>

                @<div Class="form-group row">

                    <fieldset style="border: ridge;" class="col-md-12">
                        <legend style="font-size: 14px">@Resource.SelectionPortDeMer</legend>
                        <div class="row">
                            <div class="col-sm-2">
                                @Html.CheckBoxFor(Function(model) model.PortDeMer,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "1", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "}})
                                <br />
                                @Html.LabelFor(Function(m) m.PortDeMer, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                            </div>

                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.MaterielPortDeMerId, New With {.class = "col-form-label", .style = "font-size: 8px;  height: 25px; "})<br />
                                @Html.DropDownListFor(Function(m) m.MaterielPortDeMerId, New SelectList(Model.LesMaterielPortDeMer, "Value", "Text"),
New With {.class = "form-control", .multiple = "multiple", .tabindex = "2", .style = "font-size: 12px;"})
                                @Html.ValidationMessageFor(Function(m) m.MaterielPortDeMerId, "", New With {.style = "color: #da0b0b"})
                            </div>

                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.PortDeMerHauteurMaximumMin, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                @Html.EditorFor(Function(model) model.PortDeMerHauteurMaximumMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                @Html.ValidationMessageFor(Function(m) m.PortDeMerHauteurMaximumMin, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.PortDeMerHauteurMaximumMAx, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                @Html.EditorFor(Function(model) model.PortDeMerHauteurMaximumMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                @Html.ValidationMessageFor(Function(m) m.PortDeMerHauteurMaximumMAx, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.PortDeMerProfondeurQuaiChargementMin, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                @Html.EditorFor(Function(model) model.PortDeMerProfondeurQuaiChargementMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                @Html.ValidationMessageFor(Function(m) m.PortDeMerProfondeurQuaiChargementMin, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.PortDeMerProfondeurQuaiChargementMAx, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                @Html.EditorFor(Function(model) model.PortDeMerProfondeurQuaiChargementMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "1", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; "}})
                                @Html.ValidationMessageFor(Function(m) m.PortDeMerProfondeurQuaiChargementMAx, "", New With {.style = "color: #da0b0b"})

                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-2">

                            </div>

                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.PortDeMerProfondeurTerminalPetrolierMin, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                @Html.EditorFor(Function(model) model.PortDeMerProfondeurTerminalPetrolierMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "1", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; "}})
                                @Html.ValidationMessageFor(Function(m) m.PortDeMerProfondeurTerminalPetrolierMin, "", New With {.style = "color: #da0b0b"})
                            </div>

                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.PortDeProfondeurTerminalPetrolierMAx, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                @Html.EditorFor(Function(model) model.PortDeProfondeurTerminalPetrolierMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                @Html.ValidationMessageFor(Function(m) m.PortDeProfondeurTerminalPetrolierMAx, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.PortDeMerLongueurMaximaleNavireMin, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                @Html.EditorFor(Function(model) model.PortDeMerLongueurMaximaleNavireMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                @Html.ValidationMessageFor(Function(m) m.PortDeMerLongueurMaximaleNavireMin, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.PortDeMerLongueurMaximaleNavireMAx, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                @Html.EditorFor(Function(model) model.PortDeMerLongueurMaximaleNavireMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "1", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; "}})
                                @Html.ValidationMessageFor(Function(m) m.PortDeMerLongueurMaximaleNavireMAx, "", New With {.style = "color: #da0b0b"})
                            </div>

                        </div>
                        <br />
                    </fieldset>

                </div>

                @<div Class="form-group row">

                    <fieldset style="border: ridge;" class="col-md-12">
                        <legend style="font-size: 14px">@Resource.SelectionBureau</legend>
                        <div class="row">

                            <div class="col-sm-2">
                                @Html.CheckBoxFor(Function(model) model.Bureau,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "1", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "}})
                                <br />
                                @Html.LabelFor(Function(m) m.Bureau, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.TypeOfficeId, New With {.class = "col-form-label", .style = "font-size: 8px;  height: 25px; "})<br />
                                @Html.DropDownListFor(Function(m) m.TypeOfficeId, New SelectList(Model.LesTypeEntrepots, "Value", "Text"),
New With {.class = "form-control", .multiple = "multiple", .tabindex = "2", .style = "font-size: 12px;"})
                                @Html.ValidationMessageFor(Function(m) m.TypeOfficeId, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.MaterielBureauId, New With {.class = "col-form-label", .style = "font-size: 8px;  height: 25px; "})<br />
                                @Html.DropDownListFor(Function(m) m.MaterielBureauId, New SelectList(Model.LesMaterielBureau, "Value", "Text"),
New With {.class = "form-control", .multiple = "multiple", .tabindex = "2", .style = "font-size: 12px;"})
                                @Html.ValidationMessageFor(Function(m) m.MaterielBureauId, "", New With {.style = "color: #da0b0b"})
                            </div>

                        </div>
                        <br />
                    </fieldset>
                </div>

                @<div Class="form-group row">

                    <fieldset style="border: ridge;" class="col-md-12">
                        <legend style="font-size: 14px">@Resource.SelectionInstallation</legend>
                        <div class="row">

                            <div class="col-sm-2">
                                @Html.CheckBoxFor(Function(model) model.Instalation,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "1", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "}})
                                <br />
                                @Html.LabelFor(Function(m) m.Instalation, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.MaterielInstallationId, New With {.class = "col-form-label", .style = "font-size: 8px;  height: 25px; "})<br />
                                @Html.DropDownListFor(Function(m) m.MaterielInstallationId, New SelectList(Model.LesMaterielInstallation, "Value", "Text"),
New With {.class = "form-control", .multiple = "multiple", .tabindex = "2", .style = "font-size: 12px;"})
                                @Html.ValidationMessageFor(Function(m) m.MaterielInstallationId, "", New With {.style = "color: #da0b0b"})
                            </div>
                        </div>
                        <br />
                    </fieldset>
                </div>

                @<div Class="form-group row">

                    <fieldset style="border: ridge;" class="col-md-12">
                        <legend style="font-size: 14px">@Resource.SelectionHeliport</legend>
                        <div class="row">
                            <div class="col-sm-2">
                                @Html.CheckBoxFor(Function(model) model.Heliport,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "1", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "}})
                                <br />
                                @Html.LabelFor(Function(m) m.Heliport, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                            </div>
                            <div class="col-sm-2">
                                @Html.LabelFor(Function(m) m.MaterielHeliportId, New With {.class = "col-form-label", .style = "font-size: 8px;  height: 25px; "})<br />
                                @Html.DropDownListFor(Function(m) m.MaterielHeliportId, New SelectList(Model.LesMaterielHeliport, "Value", "Text"),
New With {.class = "form-control", .multiple = "multiple", .tabindex = "2", .style = "font-size: 12px;"})
                                @Html.ValidationMessageFor(Function(m) m.MaterielHeliportId, "", New With {.style = "color: #da0b0b"})
                            </div>
                        </div>
                        <br />
                    </fieldset>
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






@section Scripts
    <script>
        var mbAttr = 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
                mbUrl = 'https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token=pk.eyJ1IjoibGthbmtvIiwiYSI6ImNqcXMxa3ZwZzAyaHg0M3FjcnlodWdyN2gifQ.kZWy1_TOotLAnGCVb2qHXA';

        var grayscale = L.tileLayer(mbUrl, { id: 'mapbox.light', attribution: mbAttr }),
            streets = L.tileLayer(mbUrl, { id: 'mapbox.streets', attribution: mbAttr });

        var baseLayers = {
            "Grayscale": grayscale,
            "Streets": streets
        };

        var src = '@Url.Content("~/assets/images/leafIcon/iconfinder.png")';

        var heliportIcon = L.icon({
            iconUrl: src,

            iconSize: [20, 50],
            iconAnchor: [22, 94],
            popupAnchor: [-3, -76]
        });

        /*var ZoneARisque = L.tileLayer.wms("http://localhost:8080/geoserver/cite/wms", {
            layers: 'ZoneARisque',
            format: 'image/png',
            transparent: true,
        });*/


        var hopitauxLayer = new L.LayerGroup();
        var heliportsLayer = new L.LayerGroup();
        var aeroportsLayer = new L.LayerGroup();
        var abrisLayer = new L.LayerGroup();
        var instalLayer = new L.LayerGroup();
        var bureauLayer = new L.LayerGroup();
        var entrepLayer = new L.LayerGroup();
        var portsLayer = new L.LayerGroup();
        var zonesRisqueLayer = new L.LayerGroup();

        var overlayMaps = {
            "Hopitaux": hopitauxLayer,
            "Héliports": heliportsLayer,
            "Aeroports": aeroportsLayer,
            "Abris": abrisLayer,
            "Installations": instalLayer,
            "Bureaux": bureauLayer,
            "Entrenpots": entrepLayer,
            "Ports": portsLayer,
            "Zones à risque": zonesRisqueLayer
        };

        var mymap = L.map('mapid', {
            center: [3.863433, 11.528046],
            zoom: 6,
            //leyers activer par defaut
            layers: [streets, hopitauxLayer, heliportsLayer]
        });

        L.control.layers(baseLayers, overlayMaps).addTo(mymap);

        $.get( "@Url.Action("Hopitaux", "Cartes")", function(data) {
            //console.log(data);
            var hospitalIcon = L.icon({
                iconUrl: "@Url.Content("~/assets/plugins/leaflet/images/marker-icon-hospital.png")",
                shadowUrl: "@Url.Content("~/assets/plugins/leaflet/images/marker-shadow.png")",
                iconSize: [25, 41],
                iconAnchor: [12, 40],
                popupAnchor: [1, -32],
                shadowSize: [41, 41],
                shadowAnchor: [12, 40]
            });
            $.each(data, function (index, item) {
                hopitauxLayer.addLayer(L.marker([item.Lat, item.Long], {icon: hospitalIcon}).addTo(mymap)
                        .bindPopup('<b>' + item.Nom + '</b><br>' +
                            '<b>' + item.Organisation + '</b><br>' +
                            'Type : <b>' + item.TypeHopital + '</b><br>' +
                            'Nombre de médecins : <b>' + (item.NombreDeMedecin) + '</b><br>' +
                            'Nombre d\'infirmières : <b>' + (item.NombreDInfimiere) + '</b><br>' +
                            'Nombre de lits : <b>' + (item.NombreDeLitMin) + ' - ' + (item.NombreDeLitMax) + '</b><br>' +
                            'Téléphone : <b>' + item.Telephone + '</b><br>' +
                            'Téléphone d\'urgence : <b>' + ((item.TelephoneUrgence)?item.TelephoneUrgence:'N/C') + '</b><br>' +
                            `Détails : <a class=" " target="_blank" title="@Resource.Btn_Detail" href="@Url.Action("Details", "Hopitaux")/`+ item.Id + `">
                                    cliquer ici
                                </a>`
                        )
                    );
            });
        });

        $.get( "@Url.Action("Heliports", "Cartes")", function(data) {
            //console.log(data);
            var heliportIcon = L.icon({
                iconUrl: "@Url.Content("~/assets/plugins/leaflet/images/marker-icon-heliport.png")",
                shadowUrl: "@Url.Content("~/assets/plugins/leaflet/images/marker-shadow.png")",
                iconSize: [25, 41],
                iconAnchor: [12, 40],
                popupAnchor: [1, -32],
                shadowSize: [41, 41],
                shadowAnchor: [12, 40]
            });
            $.each(data, function (index, item) {
                heliportsLayer.addLayer(L.marker([item.Lat, item.Long], {icon: heliportIcon}).addTo(mymap)
                        .bindPopup('<b>' + item.Nom + '</b><br>' +
                            '<b>' + item.Organisation + '</b><br>' +
                            'Téléphone : <b>' + item.Telephone + '</b><br>' +
                            'Téléphone 2 : <b>' + ((item.TelephoneUrgence)?item.TelephoneUrgence:'N/C') + '</b><br>' +
                            `Détails : <a class=" " target="_blank" title="@Resource.Btn_Detail" href="@Url.Action("Details", "Heliports")/`+ item.Id + `">
                                    cliquer ici
                                </a>`
                        )
                    );
            });
        });

        $.get( "@Url.Action("Aeroport", "Cartes")", function(data) {
            //console.log(data);
            var aeroportIcon = L.icon({
                iconUrl: "@Url.Content("~/assets/plugins/leaflet/images/marker-icon-aeroport.png")",
                shadowUrl: "@Url.Content("~/assets/plugins/leaflet/images/marker-shadow.png")",
                iconSize: [25, 41],
                iconAnchor: [12, 40],
                popupAnchor: [1, -32],
                shadowSize: [41, 41],
                shadowAnchor: [12, 40]
            });
            $.each(data, function (index, item) {
                aeroportsLayer.addLayer(L.marker([item.Lat, item.Long], {icon: aeroportIcon}) //.addTo(mymap)
                        .bindPopup('<b>' + item.Nom + '</b><br>' +
                            'ICAO : <b>' + (item.ICAO) + '</b> - IATA : <b>' + (item.IATA) + '</b><br>' +
                            'Usage Humanitaire : <b>' + item.UsageHumanitaire + '</b><br>' +
                            '<b>' + item.Organisation + '</b><br>' +
                            'Surface de piste : <b>' + item.SurfacePiste + '</b><br>' +
                            'Longueur : <b>' + (item.LongueurDePiste) + '</b> - Largeur : <b>' + (item.LargeurDePiste) + '</b><br>' +
                            'Taille de l\'aeronef : <b>' + item.TailleDeAeronef + '</b><br>' +
                            'Téléphone : <b>' + item.Telephone + '</b><br>' +
                            'Téléphone 2 : <b>' + ((item.Telephone2)?item.Telephone2:'N/C') + '</b><br>' +
                            `Détails : <a class=" " target="_blank" title="@Resource.Btn_Detail" href="@Url.Action("Details", "Aeroport")/`+ item.Id + `">
                                    cliquer ici
                                </a>`
                        )
                    );
            });
        });

         $.get( "@Url.Action("Abris", "Cartes")", function(data) {
            //console.log(data);
            var abrisIcon = L.icon({
                iconUrl: "@Url.Content("~/assets/plugins/leaflet/images/marker-icon-abris.png")",
                shadowUrl: "@Url.Content("~/assets/plugins/leaflet/images/marker-shadow.png")",
                iconSize: [25, 41],
                iconAnchor: [12, 40],
                popupAnchor: [1, -32],
                shadowSize: [41, 41],
                shadowAnchor: [12, 40]
            });
            $.each(data, function (index, item) {
                abrisLayer.addLayer(L.marker([item.Lat, item.Long], {icon: abrisIcon}) //.addTo(mymap)
                        .bindPopup('<b>' + item.Nom + '</b><br>' +
                            '<b>' + item.Organisation + '</b><br>' +
                            'Type : <b>' + item.TypeAbris + '</b><br>' +
                            'Capacite : <b>' + item.Capacite + '</b><br>' +
                            'Estimation Population : <b>' + item.EstimationPopulation + '</b><br>' +
                            `Détails : <a class=" " target="_blank" title="@Resource.Btn_Detail" href="@Url.Action("Details", "Abris")/`+ item.Id + `">
                                    cliquer ici
                                </a>`
                        )
                    );
            });
        });

        $.get( "@Url.Action("Bureaux", "Cartes")", function(data) {
            //console.log(data);
            var infraIcon = L.icon({
                iconUrl: "@Url.Content("~/assets/plugins/leaflet/images/Bureau.png")",
                shadowUrl: "@Url.Content("~/assets/plugins/leaflet/images/marker-shadow.png")",
                iconSize: [25, 41],
                iconAnchor: [12, 40],
                popupAnchor: [1, -32],
                shadowSize: [41, 41],
                shadowAnchor: [12, 40]
            });
            $.each(data, function (index, item) {
                bureauLayer.addLayer(L.marker([item.Lat, item.Long], {icon: infraIcon}) //.addTo(mymap)
                        .bindPopup('<b>' + item.Code + ' - ' + item.Nom + '</b><br>' +
                            '<b>' + item.Organisation + '</b><br>' +
                            'Téléphone : <b>' + item.Telephone + '</b><br>' +
                            'Téléphone 2 : <b>' + ((item.TelephoneUrgence)?item.TelephoneUrgence:'N/C') + '</b><br>' +
                            'Code Postal : <b>' + ((item.CodePostale) ? item.CodePostale : 'N/C') + '</b><br>' +
                            'Téléphone 2 : <b>' + ((item.TelephoneUrgence) ? item.TelephoneUrgence : 'N/C') + '</b><br>' +
                            `Détails : <a class=" " target="_blank" title="@Resource.Btn_Detail" href="@Url.Action("Details", "Bureaux")/`+ item.Id + `">
                                    cliquer ici
                                </a>`
                        )
                    );
            });
        });

        $.get( "@Url.Action("Installations", "Cartes")", function(data) {
            //console.log(data);
            var infraIcon = L.icon({
                iconUrl: "@Url.Content("~/assets/plugins/leaflet/images/Installations.png")",
                shadowUrl: "@Url.Content("~/assets/plugins/leaflet/images/marker-shadow.png")",
                iconSize: [25, 41],
                iconAnchor: [12, 40],
                popupAnchor: [1, -32],
                shadowSize: [41, 41],
                shadowAnchor: [12, 40]
            });
            $.each(data, function (index, item) {
                instalLayer.addLayer(L.marker([item.Lat, item.Long], {icon: infraIcon}) //.addTo(mymap)
                        .bindPopup('<b>' + item.Code + ' - ' + item.Nom + '</b><br>' +
                            '<b>' + item.Organisation + '</b><br>' +
                            'Téléphone : <b>' + item.Telephone + '</b><br>' +
                            'Téléphone 2 : <b>' + ((item.TelephoneUrgence)?item.TelephoneUrgence:'N/C') + '</b><br>' +
                            'Code Postal : <b>' + ((item.CodePostale) ? item.CodePostale : 'N/C') + '</b><br>' +
                            'Téléphone 2 : <b>' + ((item.TelephoneUrgence) ? item.TelephoneUrgence : 'N/C') + '</b><br>' +
                            `Détails : <a class=" " target="_blank" title="@Resource.Btn_Detail" href="@Url.Action("Details", "Installations")/`+ item.Id + `">
                                    cliquer ici
                                </a>`
                        )
                    );
            });
        });

        $.get( "@Url.Action("Entrepots", "Cartes")", function(data) {
            //console.log(data);
            var infraIcon = L.icon({
                iconUrl: "@Url.Content("~/assets/plugins/leaflet/images/Entrepot.png")",
                shadowUrl: "@Url.Content("~/assets/plugins/leaflet/images/marker-shadow.png")",
                iconSize: [25, 41],
                iconAnchor: [12, 40],
                popupAnchor: [1, -32],
                shadowSize: [41, 41],
                shadowAnchor: [12, 40]
            });
            $.each(data, function (index, item) {
                entrepLayer.addLayer(L.marker([item.Lat, item.Long], {icon: infraIcon}) //.addTo(mymap)
                        .bindPopup('<b>' + item.Code + ' - ' + item.Nom + '</b><br>' +
                            '<b>' + item.Organisation + '</b><br>' +
                            'Téléphone : <b>' + item.Telephone + '</b><br>' +
                            'Téléphone 2 : <b>' + ((item.TelephoneUrgence)?item.TelephoneUrgence:'N/C') + '</b><br>' +
                            'Code Postal : <b>' + ((item.CodePostale) ? item.CodePostale : 'N/C') + '</b><br>' +
                            'Téléphone 2 : <b>' + ((item.TelephoneUrgence) ? item.TelephoneUrgence : 'N/C') + '</b><br>' +
                            `Détails : <a class=" " target="_blank" title="@Resource.Btn_Detail" href="@Url.Action("Details", "Entrepots")/`+ item.Id + `">
                                    cliquer ici
                                </a>`
                        )
                    );
            });
        });


        $.get( "@Url.Action("Ports", "Cartes")", function(data) {
            //console.log(data);
            var infraIcon = L.icon({
                iconUrl: "@Url.Content("~/assets/plugins/leaflet/images/marker-icon-ports.png")",
                shadowUrl: "@Url.Content("~/assets/plugins/leaflet/images/marker-shadow.png")",
                iconSize: [25, 41],
                iconAnchor: [12, 40],
                popupAnchor: [1, -32],
                shadowSize: [41, 41],
                shadowAnchor: [12, 40]
            });
            $.each(data, function (index, item) {
                portsLayer.addLayer(L.marker([item.Lat, item.Long], {icon: infraIcon}) //.addTo(mymap)
                        .bindPopup('<b>' + item.Code + ' - ' + item.Nom + '</b><br>' +
                            '<b>' + item.Organisation + '</b><br>' +
                            'Possession : <b>' + item.Possession + '</b><br>' +
                            'Téléphone : <b>' + item.Telephone + '</b><br>' +
                            'Téléphone 2 : <b>' + ((item.TelephoneUrgence) ? item.TelephoneUrgence : 'N/C') + '</b><br>' +
                            `Détails : <a class=" " target="_blank" title="@Resource.Btn_Detail" href="@Url.Action("Details", "PortDeMers")/`+ item.Id + `">
                                    cliquer ici
                                </a>`
                        )
                    );
            });
        });

        $.get( "@Url.Action("ZonesRisques", "Cartes")", function(data) {
            console.log(data);
            $.each(data, function (index, item) {
                zonesRisqueLayer.addLayer(L.circle([item.Lat, item.Long], { radius : item.Rayon, color : '#ff0000' }) //.addTo(mymap)
                        .bindPopup('<b>' + item.Libelle + '</b><br>' +
                            'Risques : <ul><li><b>' + item.Risques.join('</b></li><li><b>') + '</b></li></ul><br>')
                    );
            });
        });

    </script>

end section

@Scripts.Render("~/bundles/LeafletJS")
