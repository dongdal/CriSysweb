@ModelType QueryViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.CreateEvenementZone
    Layout = "~/Views/Shared/_LayoutDesinventar.vbhtml"
End Code

<div class="page-header">
    <h1 class="page-title">@Resource.ManageEvenementZone</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "EvenementZones")>@Resource.ManageEvenementZone</a></li>
        <li class="breadcrumb-item active">@Resource.CreateEvenementZone</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">

            <hr>
            @Using Html.BeginForm("Create", "EvenementZones", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()

                @<div Class="form-group row">

                    <div class="col-sm-2 form-group">
                        @Html.LabelFor(Function(m) m.EvenementId, New With {.class = "col-form-label"})<br />
                        @Html.DropDownListFor(Function(m) m.EvenementId, New SelectList(Model.LesEvenements, "Value", "Text"),
                         New With {.class = "form-control", .multiple = "multiple", .tabindex = "1", .style = "font-size: 12px;  height: 200px; "})
                        @Html.ValidationMessageFor(Function(m) m.EvenementId, "", New With {.style = "color: #da0b0b"})
                    </div>

                    <div class="col-sm-2 form-group">
                        @Html.LabelFor(Function(m) m.RegionId, New With {.class = "col-form-label"})<br />
                        @Html.DropDownListFor(Function(m) m.RegionId, New SelectList(Model.LesRegions, "Value", "Text"),
                         New With {.class = "form-control", .multiple = "multiple", .tabindex = "2", .style = "font-size: 12px;  height: 200px; "})
                        @Html.ValidationMessageFor(Function(m) m.RegionId, "", New With {.style = "color: #da0b0b"})
                    </div>
                    <div class="col-sm-2 form-group">
                        @Html.LabelFor(Function(m) m.DepartementId, New With {.class = "col-form-label"})<br />
                        @Html.DropDownListFor(Function(m) m.DepartementId, New SelectList(Model.LesDepartements, "Value", "Text"),
                         New With {.class = "form-control", .tabindex = "3", .multiple = "multiple", .style = "font-size: 12px;  height: 200px; "})
                        @Html.ValidationMessageFor(Function(m) m.DepartementId, "", New With {.style = "color: #da0b0b"})
                    </div>
                    <div class="col-sm-2 form-group">
                        @Html.LabelFor(Function(m) m.CommuneId, New With {.class = "col-form-label"})<br />
                        @Html.DropDownListFor(Function(m) m.CommuneId, New SelectList(Model.LesCommunes, "Value", "Text"),
                         New With {.class = "form-control ", .multiple = "multiple", .tabindex = "4", .style = "font-size: 12px;  height: 200px; "})
                        @Html.ValidationMessageFor(Function(m) m.CommuneId, "", New With {.style = "color: #da0b0b"})
                    </div>
                    <div class="col-sm-2 form-group">
                        @Html.LabelFor(Function(m) m.QuartiersId, New With {.class = "col-form-label"})<br />
                        @Html.DropDownListFor(Function(m) m.QuartiersId, New SelectList(Model.LesQuartiers, "Value", "Text"),
                         New With {.class = "form-control", .multiple = "multiple", .tabindex = "5", .style = "font-size: 12px;  height: 200px; "})
                        @Html.ValidationMessageFor(Function(m) m.QuartiersId, "", New With {.style = "color: #da0b0b"})
                    </div>
                    <div class="col-sm-2 form-group">
                        @Html.LabelFor(Function(m) m.FacteurId, New With {.class = "col-form-label"})<br />
                        @Html.DropDownListFor(Function(m) m.FacteurId, New SelectList(Model.LesFacteurs, "Value", "Text"),
                         New With {.class = "form-control", .multiple = "multiple", .tabindex = "6", .style = "font-size: 12px;  height: 200px; "})
                        @Html.ValidationMessageFor(Function(m) m.FacteurId, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>
                @<div Class="form-group row">

                    <div Class="col-md-7">
                        <fieldset style="border: ridge;">
                            <legend style="font-size: 14px">@Resource.SelectionEvenementAvec</legend>
                            <div class="row" style="margin:10px;">
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-sm-3">
                                            @Html.CheckBoxFor(Function(model) model.Deces,
                New With {.class = "form-control", .tabindex = "1", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "})
                                            @Html.LabelFor(Function(m) m.Deces, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                        </div>

                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.DecesMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.DecesMin, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.DecesMAx,
   New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.DecesMAx, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-3">
                                            @Html.CheckBoxFor(Function(model) model.MaisonDetruite,
                New With {.class = "form-control", .tabindex = "4", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "})
                                            @Html.LabelFor(Function(m) m.MaisonDetruite, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                        </div>

                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.MaisonDetruiteMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "5", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.MaisonDetruiteMin, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.MaisonDetruiteMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "6", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.MaisonDetruiteMAx, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                    </div>

                                    <div class="row">

                                        <div class="col-sm-3">
                                            @Html.CheckBoxFor(Function(model) model.Sinistrees,
New With {.class = "form-control", .tabindex = "7", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "})
                                            @Html.LabelFor(Function(m) m.Sinistrees, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.SinistreesMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "8", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.SinistreesMin, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.SinistreesMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "9", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.SinistreesMAx, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-3">
                                            @Html.EditorFor(Function(model) model.AffecteesIndirectment,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "10", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "}})
                                            @Html.ValidationMessageFor(Function(m) m.AffecteesIndirectment, "", New With {.style = "color: #da0b0b"})
                                            @Html.LabelFor(Function(m) m.AffecteesIndirectment, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.AffecteesIndirectmentMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "11", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.AffecteesIndirectmentMin, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.AffecteesIndirectmentMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "12", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.AffecteesIndirectmentMAx, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-3">
                                            @Html.EditorFor(Function(model) model.Hopitaux,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "13", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "}})
                                            @Html.ValidationMessageFor(Function(m) m.Hopitaux, "", New With {.style = "color: #da0b0b"})
                                            @Html.LabelFor(Function(m) m.Hopitaux, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.HopitauxMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "14", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.HopitauxMin, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.HopitauxMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "15", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.HopitauxMAx, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-3">
                                            @Html.EditorFor(Function(model) model.RoutesEndomages,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "16", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "}})
                                            @Html.ValidationMessageFor(Function(m) m.RoutesEndomages, "", New With {.style = "color: #da0b0b"})
                                            @Html.LabelFor(Function(m) m.RoutesEndomages, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.RoutesEndomagesMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "17", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.RoutesEndomagesMin, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.RoutesEndomagesMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "18", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.RoutesEndomagesMAx, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-3">
                                            @Html.EditorFor(Function(model) model.BetailPerdu,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "19", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "}})
                                            @Html.ValidationMessageFor(Function(m) m.BetailPerdu, "", New With {.style = "color: #da0b0b"})
                                            @Html.LabelFor(Function(m) m.BetailPerdu, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.BetailPerduMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "20", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.BetailPerduMin, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.BetailPerduMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "21", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.BetailPerduMAx, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-sm-3">
                                            @Html.EditorFor(Function(model) model.Blesse,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "22", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "}})
                                            @Html.ValidationMessageFor(Function(m) m.Blesse, "", New With {.style = "color: #da0b0b"})
                                            @Html.LabelFor(Function(m) m.Blesse, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.BlesseMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "23", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.BlesseMin, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.BlesseMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "24", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.BlesseMAx, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-3">
                                            @Html.EditorFor(Function(model) model.MaisonEndommages,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "25", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "}})
                                            @Html.ValidationMessageFor(Function(m) m.MaisonEndommages, "", New With {.style = "color: #da0b0b"})
                                            @Html.LabelFor(Function(m) m.MaisonEndommages, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.MaisonEndommagesMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "26", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.MaisonEndommagesMin, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.MaisonEndommagesMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "37", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.MaisonEndommagesMAx, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-3">
                                            @Html.EditorFor(Function(model) model.AffectesDirectment,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "28", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "}})
                                            @Html.ValidationMessageFor(Function(m) m.AffectesDirectment, "", New With {.style = "color: #da0b0b"})
                                            @Html.LabelFor(Function(m) m.AffectesDirectment, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.AffectesDirectmentMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "29", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.AffectesDirectmentMin, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.AffectesDirectmentMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "30", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.AffectesDirectmentMAx, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-3">
                                            @Html.EditorFor(Function(model) model.Deplacees,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "31", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "}})
                                            @Html.ValidationMessageFor(Function(m) m.Deplacees, "", New With {.style = "color: #da0b0b"})
                                            @Html.LabelFor(Function(m) m.Deplacees, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.DeplaceesMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "32", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.DeplaceesMin, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.DeplaceesMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "33", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.DeplaceesMAx, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-3">
                                            @Html.EditorFor(Function(model) model.Disparus,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "34", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "}})
                                            @Html.ValidationMessageFor(Function(m) m.Disparus, "", New With {.style = "color: #da0b0b"})
                                            @Html.LabelFor(Function(m) m.Disparus, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.DisparusMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "35", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.DisparusMin, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.DisparusMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "36", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.DisparusMAx, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-3">
                                            @Html.EditorFor(Function(model) model.CulturesBoisEndomages,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "37", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "}})
                                            @Html.ValidationMessageFor(Function(m) m.CulturesBoisEndomages, "", New With {.style = "color: #da0b0b"})
                                            @Html.LabelFor(Function(m) m.CulturesBoisEndomages, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.CulturesBoisEndomagesMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "38", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.CulturesBoisEndomagesMin, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.CulturesBoisEndomagesMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "39", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.CulturesBoisEndomagesMAx, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-3">
                                            @Html.EditorFor(Function(model) model.CentresEducationnels,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "40", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "}})
                                            @Html.ValidationMessageFor(Function(m) m.CentresEducationnels, "", New With {.style = "color: #da0b0b"})
                                            @Html.LabelFor(Function(m) m.CentresEducationnels, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.CentresEducationnelsMin,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "41", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.CentresEducationnelsMin, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.CentresEducationnelsMAx,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "42", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.CentresEducationnelsMAx, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                    </div>

                                </div>
                            </div>

                        </fieldset>
                    </div>
                    <div Class="col-md-4">
                        <fieldset style="border: ridge;">
                            <legend style="font-size: 14px">@Resource.SelectionEvenementAffecte</legend>

                            <div style="margin:10px;">

                                <div class="row">
                                    <div class="col-sm-2">
                                        @Html.CheckBoxFor(Function(model) model.AffecteSante,
New With {.class = "form-control", .tabindex = "43", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "})
                                    </div>
                                    @Html.LabelFor(Function(m) m.AffecteSante, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                </div>

                                <div class="row">
                                    <div class="col-sm-2">
                                        @Html.CheckBoxFor(Function(model) model.AffecteTransport,
New With {.class = "form-control", .tabindex = "44", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "})
                                    </div>
                                    @Html.LabelFor(Function(m) m.AffecteTransport, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                </div>

                                <div class="row">
                                    <div class="col-sm-2">
                                        @Html.CheckBoxFor(Function(model) model.AutresSecteurs,
New With {.class = "form-control", .tabindex = "47", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "})
                                    </div>
                                    @Html.LabelFor(Function(m) m.AutresSecteurs, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                </div>

                                <div class="row">
                                    <div class="col-sm-2">
                                        @Html.CheckBoxFor(Function(model) model.AffecteAgriculture,
New With {.class = "form-control", .tabindex = "46", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 10px; "})
                                    </div>
                                    @Html.LabelFor(Function(m) m.AffecteAgriculture, New With {.class = "", .style = "font-size: 8px;  height: 25px;"})
                                </div>

                            </div>
                        </fieldset>
                    </div>
                    <div Class="col-md-1">
                        <fieldset style="border: ridge;">
                            <legend style="font-size: 14px">@Resource.Logique</legend>

                            <div class="col-md-4">
                                <div class="icheck-material-dark icheck-inline">
                                    @Html.RadioButtonFor(Function(m) m.Logique, "OU", New With {.id = "OU", .checked = "checked", .style = "font-size: 8px;  height: 15px;"})
                                    @Html.Label(Resource.LogiqueOU, New With {.for = "OU", .tabindex = "47", .style = "font-size: 8px;  height: 25px;"})
                                </div>
                                <br />
                                <div class="icheck-material-dark icheck-inline">
                                    @Html.RadioButtonFor(Function(m) m.Logique, "ET", New With {.id = "ET", .style = "font-size: 8px;  height: 15px;"})
                                    @Html.Label(Resource.LogiqueET, New With {.for = "ET", .tabindex = "48", .style = "font-size: 8px;  height: 25px;"})
                                </div>
                            </div>

                        </fieldset>
                    </div>
                </div>

                @<div Class="form-group row">
                    <div Class="col-md-12">
                        <fieldset style="border: ridge;">
                            <legend style="font-size: 14px">Autres</legend>
                            <div class="row" style="margin:10px;">

                                <div class="col-md-6">
                                    <div Class="form-group row">
                                        @Html.LabelFor(Function(m) m.DateDe, New With {.class = "col-sm-2 col-form-label", .style = "font-size: 9px;  height: 25px; "})
                                        <div class="col-sm-4">
                                            @Html.TextBoxFor(Function(m) m.DateDe, New With {.class = "form-control form-control-square default-datepicker", .tabindex = "49", .Placeholder = Resource.DateDebut, .style = "font-size: 10px;  height: 25px; "})
                                            @Html.ValidationMessageFor(Function(m) m.DateDe, "", New With {.style = "color: #da0b0b"})
                                        </div>


                                        @Html.LabelFor(Function(m) m.DateA, New With {.class = "col-sm-2 col-form-label", .style = "font-size: 9px;  height: 25px; "})
                                        <div class="col-sm-4">
                                            @Html.TextBoxFor(Function(m) m.DateA, New With {.class = "form-control form-control-square default-datepicker", .tabindex = "50", .Placeholder = Resource.DateFin, .style = "font-size: 10px;  height: 25px; "})
                                            @Html.ValidationMessageFor(Function(m) m.DateA, "", New With {.style = "color: #da0b0b"})
                                        </div>

                                    </div>
                                </div>

                                <div class="col-md-6">
                                    @*<div Class="form-group row">

                                        @Html.LabelFor(Function(m) m.NombreGLIDE, New With {.class = "col-sm-3 col-form-label", .style = "font-size: 9px;  height: 25px; "})
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(m) m.NombreGLIDE, New With {.class = "form-control form-control-square", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 9px;  height: 25px; "})
                                            @Html.ValidationMessageFor(Function(m) m.NombreGLIDE, "", New With {.style = "color: #da0b0b"})
                                        </div>

                                    </div>*@

                                    <div Class="form-group row">
                                        @Html.LabelFor(Function(m) m.NombreGLIDE, New With {.class = "col-sm-2 col-form-label", .style = "font-size: 9px;  height: 25px; "})
                                        <div class="col-sm-4">
                                            @Html.EditorFor(Function(model) model.NombreGLIDE,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "51", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                            @Html.ValidationMessageFor(Function(m) m.NombreGLIDE, "", New With {.style = "color: #da0b0b"})
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </fieldset>
                    </div>
                </div>


                @<div Class="form-group row">
                    <div Class="col-md-12">
                        <fieldset style="border: ridge;">
                            <legend style="font-size: 14px">Trier les résultats par</legend>
                            <div class="row" style="margin:10px;">

                                <div class="col-md-6">
                                    <div Class="form-group row">

                                        @Html.LabelFor(Function(m) m.TrierLesResultats, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 9px;  height: 25px; "})
                                        <div class="col-sm-6">
                                            @Html.DropDownListFor(Function(m) m.TrierLesResultats, New SelectList(Model.TypeList, "Value", "Text"),
New With {.class = "form-control", .tabindex = "1", .style = "font-size: 12px;"})
                                            @Html.ValidationMessageFor(Function(m) m.MaisonEndommages, "", New With {.style = "color: #da0b0b"})
                                        </div>

                                    </div>
                                </div>
                            </div>

                        </fieldset>
                    </div>
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

@Section Scripts

    <script>
        //alert("Le niveau sélectionné = " + $(cboRegionId).val());
        var cboRegionId = '#RegionId';
        var cboDepartementId = '#DepartementId';
        var cboCommuneId = '#CommuneId';
        var cboQuartiersId = '#QuartiersId';
        var urlDepartements = '@Url.Action("LoadDepartements", "Departements")';
        var urlCommunes = '@Url.Action("LoadCommunes", "Communes")';
        var urlQuartiers = '@Url.Action("LoadQuartiers", "Quartiers")';
        var MsgCombo = '';
                //Chargement des départments en fonction des régions sélectionnées
        $(cboRegionId).change(function () {
            var ListOfRegionString = $(cboRegionId).val();
            var ListOfRegionArray = ListOfRegionString.toString().split(",");
                $(cboDepartementId).empty();
                if ($(cboRegionId).val()) {

                    $.ajax({
                        type: 'POST',
                        url: urlDepartements, // we are calling json method
                        dataType: 'json',
                        data: { ListOfRegion:ListOfRegionArray},
                        // here we are get value of selected country and passing same value as inputto json method GetStates.

                        success: function (states) {
                            // states contains the JSON formatted list
                            // of states passed from the controller

                            $(cboDepartementId).append('<option value="">' + MsgCombo + '</option>'); // ici on met d'abord unn premier elt vide
                            $.each(states, function (i, state) {
                                $(cboDepartementId).append('<option value="' + state.Value + '">' + state.Text + '</option>');
                                // here we are adding option for States

                            });
                        },
                        error: function (ex) {
                            //alert('Failed to retrieve states.' + ex);
                        }
                    });
                } else {
                    $(cboDepartementId).append('<option value="">@Resource.NiveauAutre</option>');
                };

            return false;
        })

                //Chargement des communes en fonction des départements sélectionnés
        $(cboDepartementId).change(function () {
            var ListOfDepartementsString = $(cboDepartementId).val();
            var ListOfDepartementsArray = ListOfDepartementsString.toString().split(",");
            $(cboCommuneId).empty();
            if ($(cboDepartementId).val()) {

                    $.ajax({
                        type: 'POST',
                        url: urlCommunes, // we are calling json method
                        dataType: 'json',
                        data: { ListOfDepartements: ListOfDepartementsArray},
                        // here we are get value of selected country and passing same value as inputto json method GetStates.

                        success: function (states) {
                            // states contains the JSON formatted list
                            // of states passed from the controller

                            $(cboCommuneId).append('<option value="">' + MsgCombo + '</option>'); // ici on met d'abord unn premier elt vide
                            $.each(states, function (i, state) {
                                $(cboCommuneId).append('<option value="' + state.Value + '">' + state.Text + '</option>');
                                // here we are adding option for States

                            });
                        },
                        error: function (ex) {
                            //alert('Failed to retrieve states.' + ex);
                        }
                    });
                } else {
                    $(cboCommuneId).append('<option value="">@Resource.NiveauAutre</option>');
                };

            return false;
        })


                //Chargement des quartiers en fonction des communes sélectionnées
        $(cboCommuneId).change(function () {
            var ListOfCommunesString = $(cboRegionId).val();
            var ListOfCommunesArray = ListOfCommunesString.toString().split(",");
                $(cboQuartiersId).empty();
            if ($(cboCommuneId).val()) {

                    $.ajax({
                        type: 'POST',
                        url: urlQuartiers, // we are calling json method
                        dataType: 'json',
                        data: { ListOfCommunes: ListOfCommunesArray},
                        // here we are get value of selected country and passing same value as inputto json method GetStates.

                        success: function (states) {
                            // states contains the JSON formatted list
                            // of states passed from the controller

                            $(cboQuartiersId).append('<option value="">' + MsgCombo + '</option>'); // ici on met d'abord unn premier elt vide
                            $.each(states, function (i, state) {
                                $(cboQuartiersId).append('<option value="' + state.Value + '">' + state.Text + '</option>');
                                // here we are adding option for States

                            });
                        },
                        error: function (ex) {
                            //alert('Failed to retrieve states.' + ex);
                        }
                    });
                } else {
                    $(cboQuartiersId).append('<option value="">@Resource.NiveauAutre</option>');
                };

            return false;
        })

    </script>

End Section