@ModelType FiltreViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.ListMoyenDereponse
    Layout = "~/Views/Shared/_LayoutSahana.vbhtml"
End Code


<div class="page-header">
    <h1 class="page-title">@Resource.ManageMoyen</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Cartes")>@Resource.ManageMoyen</a></li>
        <li class="breadcrumb-item active">@Resource.ListMoyenDereponse</li>
    </ol>
</div>

@Html.Partial("_MyMapPartial")

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
                                            <br/>
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
                            <br/>
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
    @*<script src="https://unpkg.com/leaflet@1.5.1/dist/leaflet.js"
            integrity="sha512-GffPMF3RvMeYyc1LWMHtK8EbPv0iNZ8/oTtHPx9/cc2ILxQ+u905qIwdpULaqDkyBKgOaB57QTMg7ztg8Jm2Og=="
            crossorigin=""></script>
        <script>
            var mymap = L.map('mapid').setView([51.505, -0.09], 13);



            L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token={accessToken}', {
                attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
                maxZoom: 18,
                id: 'mapbox.streets',
                accessToken: 'pk.eyJ1IjoibGthbmtvIiwiYSI6ImNqcXMxa3ZwZzAyaHg0M3FjcnlodWdyN2gifQ.kZWy1_TOotLAnGCVb2qHXA'
            }).addTo(mymap);*@

    <script>
        var src = '@Url.Content("~/assets/images/leafIcon/iconfinder.png")';

        var heliportIcon = L.icon({
            iconUrl: src,

            iconSize: [20, 50],
            iconAnchor: [22, 94],
            popupAnchor: [-3, -76]
        });

        var heliports = L.tileLayer.wms("http://localhost:8080/geoserver/cite/wms", {
            layers: 'Heliport',
            format: 'image/png',
            icon: heliportIcon,
            transparent: true,
        });

        var Hopitaux = L.tileLayer.wms("http://localhost:8080/geoserver/cite/wms", {
            layers: 'Hopitaux',
            format: 'image/png',
            transparent: true,
        });

        var Aeroport = L.tileLayer.wms("http://localhost:8080/geoserver/cite/wms", {
            layers: 'Aeroport',
            format: 'image/png',
            transparent: true,
        });

        var Abris = L.tileLayer.wms("http://localhost:8080/geoserver/cite/wms", {
            layers: 'Abris',
            format: 'image/png',
            transparent: true,
        });

        var Infrastructure = L.tileLayer.wms("http://localhost:8080/geoserver/cite/wms", {
            layers: 'Infrastructure',
            format: 'image/png',
            icon: heliportIcon,
            transparent: true,
        });

        var PortDeMer = L.tileLayer.wms("http://localhost:8080/geoserver/cite/wms", {
            layers: 'PortDeMer',
            format: 'image/png',
            transparent: true,
        });

        var ZoneARisque = L.tileLayer.wms("http://localhost:8080/geoserver/cite/wms", {
            layers: 'ZoneARisque',
            format: 'image/png',
            transparent: true,
        });

        var overlayMaps = {
            "Hopitaux": Hopitaux,
            "Héliports": heliports,
            "Aeroports": Aeroport,
            "Abris": Abris,
            "Infrastructures": Infrastructure,
            "Ports": PortDeMer,
            "Zones à risque": ZoneARisque
        };

        //center: [51.505, -0.09],
        var mymap = L.map('mapid', {
            center: [6.420116, 13.091309],
            zoom: 6,
            //leyers activer par defaut
            layers: [streets, heliports, Hopitaux]
        });

        L.marker([6.490116, 13.091809], { icon: heliportIcon }).addTo(mymap);
        L.control.layers(baseLayers, overlayMaps).addTo(mymap);

    </script>

end section