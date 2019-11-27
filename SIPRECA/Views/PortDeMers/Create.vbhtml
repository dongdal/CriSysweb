@ModelType PortDeMerViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.CreatePortDeMer
    Layout = "~/Views/Shared/_LayoutSahana.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManagePortDeMer</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "PortDeMers")>@Resource.ManagePortDeMer</a></li>
        <li class="breadcrumb-item active">@Resource.CreatePortDeMer</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.CreatePortDeMer</div>
            <hr>
            @Using Html.BeginForm("Create", "PortDeMers", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Code, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Code, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.CODEPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Code, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Nom, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Nom, New With {.class = "form-control form-control-square", .tabindex = "2", .Placeholder = Resource.NamePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Nom, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">

                    @Html.LabelFor(Function(m) m.OrganisationId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.OrganisationId, New SelectList(Model.LesOrganisations, "Value", "Text"), Resource.ComboOrganisation,
                             New With {.class = "form-control single-select", .tabindex = "3", .Placeholder = Resource.ComboOrganisation})
                        @Html.ValidationMessageFor(Function(m) m.OrganisationId, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.CommuneId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.CommuneId, New SelectList(Model.LesCommunes, "Value", "Text"), Resource.CommuneCombo,
                  New With {.class = "form-control single-select", .tabindex = "4", .Placeholder = Resource.CommuneCombo})
                        @Html.ValidationMessageFor(Function(m) m.CommuneId, "", New With {.style = "color: #da0b0b"})
                    </div>

                </div>

                @<div Class="form-group row">

                    @Html.LabelFor(Function(m) m.Possession, New With {.class = "col-sm-2 col-form-label "})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Possession, New With {.class = "form-control form-control-square", .tabindex = "5", .Placeholder = Resource.PossessionPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Possession, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.HauteurMaximum, New With {.class = "col-sm-2 col-form-label "})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.HauteurMaximum, New With {.class = "form-control form-control-square", .tabindex = "6", .Placeholder = Resource.HauteurMaximumPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.HauteurMaximum, "", New With {.style = "color: #da0b0b"})
                    </div>

                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.HauteurMaximumUnites, New With {.class = "col-sm-2 col-form-label "})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.HauteurMaximumUnites, New With {.class = "form-control form-control-square ", .tabindex = "7", .Placeholder = Resource.HauteurMaximumUnitesPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.HauteurMaximumUnites, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.ProfondeurQuaiChargement, New With {.class = "col-sm-2 col-form-label "})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.ProfondeurQuaiChargement, New With {.class = "form-control form-control-square", .tabindex = "8", .Placeholder = Resource.ProfondeurQuaiChargementPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.ProfondeurQuaiChargement, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.ProfondeurQuaiChargementUnites, New With {.class = "col-sm-2 col-form-label "})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.ProfondeurQuaiChargementUnites, New With {.class = "form-control form-control-square ", .tabindex = "9", .Placeholder = Resource.ProfondeurQuaiChargementUnitesPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.ProfondeurQuaiChargementUnites, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.ProfondeurTerminalPetrolier, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.ProfondeurTerminalPetrolier, New With {.class = "form-control form-control-square", .tabindex = "10", .Placeholder = Resource.ProfondeurTerminalPetrolierPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.ProfondeurTerminalPetrolier, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>


                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.ProfondeurTerminalPetrolierUnites, New With {.class = "col-sm-2 col-form-label "})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.ProfondeurTerminalPetrolierUnites, New With {.class = "form-control form-control-square ", .tabindex = "11", .Placeholder = Resource.ProfondeurTerminalPetrolierUnitesPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.ProfondeurTerminalPetrolierUnites, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.CaleSeche, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.CaleSeche, New With {.class = "form-control form-control-square", .tabindex = "12", .Placeholder = Resource.CaleSechePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.CaleSeche, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.LongueurMaximaleNavire, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.LongueurMaximaleNavire, New With {.class = "form-control form-control-square ", .tabindex = "13", .Placeholder = Resource.LongueurMaximaleNavirePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.LongueurMaximaleNavire, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.LongueurMaximaleNavireUnites, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.LongueurMaximaleNavireUnites, New With {.class = "form-control form-control-square", .tabindex = "14", .Placeholder = Resource.LongueurMaximaleNavireUnitesPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.LongueurMaximaleNavireUnites, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Reparations, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Reparations, New With {.class = "form-control form-control-square ", .tabindex = "15", .Placeholder = Resource.ReparationsPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Reparations, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Abri, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Abri, New With {.class = "form-control form-control-square", .tabindex = "16", .Placeholder = Resource.AbriPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Abri, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.CapaciteStockageEntreposage, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.CapaciteStockageEntreposage, New With {.class = "form-control form-control-square ", .tabindex = "17", .Placeholder = Resource.CapaciteStockageEntreposagePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.CapaciteStockageEntreposage, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.CapaciteStockageSecurise, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.CapaciteStockageSecurise, New With {.class = "form-control form-control-square", .tabindex = "18", .Placeholder = Resource.CapaciteStockageSecurisePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.CapaciteStockageSecurise, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.CapaciteStockageEntrepotDouanier, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.CapaciteStockageEntrepotDouanier, New With {.class = "form-control form-control-square ", .tabindex = "19", .Placeholder = Resource.CapaciteStockageEntrepotDouanierPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.CapaciteStockageEntrepotDouanier, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.NombreRemorqueur, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.NombreRemorqueur, New With {.class = "form-control form-control-square", .tabindex = "20", .Placeholder = Resource.NombreRemorqueurPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.NombreRemorqueur, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.CapaciteRemorqueur, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.CapaciteRemorqueur, New With {.class = "form-control form-control-square ", .tabindex = "21", .Placeholder = Resource.CapaciteRemorqueurPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.CapaciteRemorqueur, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.NombreBarge, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.NombreBarge, New With {.class = "form-control form-control-square", .tabindex = "22", .Placeholder = Resource.NombreBargePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.NombreBarge, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.CapacietBarge, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.CapacietBarge, New With {.class = "form-control form-control-square ", .tabindex = "23", .Placeholder = Resource.CapacietBargePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.CapacietBarge, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.EquipementChargement, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.EquipementChargement, New With {.class = "form-control form-control-square", .tabindex = "24", .Placeholder = Resource.EquipementChargementPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.EquipementChargement, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.CapaciteDouaniere, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.CapaciteDouaniere, New With {.class = "form-control form-control-square ", .tabindex = "25", .Placeholder = Resource.CapaciteDouanierePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.CapaciteDouaniere, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Securite, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Securite, New With {.class = "form-control form-control-square", .tabindex = "26", .Placeholder = Resource.SecuritePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Securite, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.ProfondeurMareHaute, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.ProfondeurMareHaute, New With {.class = "form-control form-control-square ", .tabindex = "27", .Placeholder = Resource.ProfondeurMareHautePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.ProfondeurMareHaute, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.ProfondeurMareHauteUnites, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.ProfondeurMareHauteUnites, New With {.class = "form-control form-control-square", .tabindex = "28", .Placeholder = Resource.ProfondeurMareHauteUnitesPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.ProfondeurMareHauteUnites, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.ProfondeurMareBasse, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.ProfondeurMareBasse, New With {.class = "form-control form-control-square ", .tabindex = "29", .Placeholder = Resource.ProfondeurMareBassePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.ProfondeurMareBasse, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.ProfondeurMareBasseUnites, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.ProfondeurMareBasseUnites, New With {.class = "form-control form-control-square", .tabindex = "30", .Placeholder = Resource.ProfondeurMareBasseUnitesPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.ProfondeurMareBasseUnites, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.ProfondeurInondation, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.ProfondeurInondation, New With {.class = "form-control form-control-square ", .tabindex = "31", .Placeholder = Resource.ProfondeurInondationPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.ProfondeurInondation, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.ProfondeurInondationUnites, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.ProfondeurInondationUnites, New With {.class = "form-control form-control-square", .tabindex = "32", .Placeholder = Resource.ProfondeurInondationUnitesPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.ProfondeurInondationUnites, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Telephone, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Telephone, New With {.class = "form-control form-control-square ", .tabindex = "33", .Placeholder = Resource.TelephonePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Telephone, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Telephone2, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Telephone2, New With {.class = "form-control form-control-square", .tabindex = "34", .Placeholder = Resource.TelephoneUrgencePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Telephone2, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.SiteWeb, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.SiteWeb, New With {.class = "form-control form-control-square", .tabindex = "35", .Placeholder = Resource.SiteWebPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.SiteWeb, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Email, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control form-control-square", .tabindex = "36", .Placeholder = Resource.EmailPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.GeoLatitude, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.GeoLatitude, New With {.class = "form-control form-control-square", .tabindex = "37", .Placeholder = Resource.Latitude})
                        @Html.ValidationMessageFor(Function(m) m.GeoLatitude, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.GeoLongitude, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.GeoLongitude, New With {.class = "form-control form-control-square", .tabindex = "38", .Placeholder = Resource.Longitude})
                        @Html.ValidationMessageFor(Function(m) m.GeoLongitude, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>
                @<br/>

                @Html.Partial("_MyMapEnterPartial")



            End Using
            <div Class="form-group row">
                <Label Class="col-sm-2 col-form-label"></Label>
                <div Class="col-sm-10">
                    <Button type="button" onclick="CreatePortdeMer();" Class="btn btn-link btn-square bg-primary text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.BtnSave</Button>
                    &nbsp;&nbsp;&nbsp;
                    @Html.ActionLink(Resource.BtnCancel, "Index", Nothing, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                </div>
            </div>

        </div>
    </div>
</div>


@Section Scripts

    <script>
        var Latitude;
        var Longitude;
        //alert(Longitude);
        var popup = L.popup();

        function onMapClick(e) {
            popup
                .setLatLng(e.latlng)
                .setContent("You clicked the map at " + e.latlng.toString())
                .openOn(mymap);
        }


        //mymap.on('click', onMapClick);
        var theMarker = {};

        mymap.on('click', function (e) {
            lat = e.latlng.lat;
            lon = e.latlng.lng;
            //console.log("You clicked the map at LAT: " + lat + " and LONG: " + lon);
            //Clear existing marker,

            if (theMarker != undefined) {
                mymap.removeLayer(theMarker);
            };
            Longitude = lon;
            Latitude = lat;

            //Add a marker to show where you clicked.
            theMarker = L.marker([lat, lon]).addTo(mymap).bindPopup("You clicked the map at LAT: " + Latitude + " and LONG: " + Longitude).openPopup();
            //theMarker = L.polygon([lat, lon]).addTo(mymap).bindPopup("You clicked the map at LAT: " + lat + " and LONG: " + lon).openPopup();

        });

        function CreatePortdeMer() {
		        var Code= '#Code';
		        var Nom= '#Nom';
            var CommuneId = '#CommuneId';
                var OrganisationId = '#OrganisationId';
                var Possession = '#Possession';
                var HauteurMaximum = '#HauteurMaximum';
                var HauteurMaximumUnites = '#HauteurMaximumUnites';
                var ProfondeurQuaiChargement = '#ProfondeurQuaiChargement';
                var ProfondeurQuaiChargementUnites = '#ProfondeurQuaiChargementUnites';
                var ProfondeurTerminalPetrolier = '#ProfondeurTerminalPetrolier';
                var ProfondeurTerminalPetrolierUnites = '#ProfondeurTerminalPetrolierUnites';
                var CaleSeche = '#CaleSeche';
                var LongueurMaximaleNavire = '#LongueurMaximaleNavire';
                var LongueurMaximaleNavireUnites = '#LongueurMaximaleNavireUnites';
                var Reparations = '#Reparations';
                var Abri = '#Abri';
                var CapaciteStockageEntreposage = '#CapaciteStockageEntreposage';
                var CapaciteStockageSecurise = '#CapaciteStockageSecurise';
                var CapaciteStockageEntrepotDouanier = '#CapaciteStockageEntrepotDouanier';
                var NombreRemorqueur = '#NombreRemorqueur';
                var CapaciteRemorqueur = '#CapaciteRemorqueur';
                var NombreBarge = '#NombreBarge';
                var CapacietBarge = '#CapacietBarge';
                var EquipementChargement = '#EquipementChargement';
                var CapaciteDouaniere = '#CapaciteDouaniere';
                var Securite = '#Securite';
                var ProfondeurMareHaute = '#ProfondeurMareHaute';
                var ProfondeurMareHauteUnites = '#ProfondeurMareHauteUnites';
                var ProfondeurMareBasse = '#ProfondeurMareBasse';
                var ProfondeurMareBasseUnites = '#ProfondeurMareBasseUnites';
                var ProfondeurInondation = '#ProfondeurInondation';
                var ProfondeurInondationUnites = '#ProfondeurInondationUnites';
		        var Telephone= '#Telephone';
                var Telephone2 = '#Telephone2';
		        var SiteWeb= '#SiteWeb';
		        var Email= '#Email';
                var GeoLatitude = '#GeoLatitude';
                var GeoLongitude = '#GeoLongitude';

                //alert("DateNaissance= " + DateNaissance);
            var regex = /^[-+]?(\d+(((\,))\d+)?)$/;
            if (!$(GeoLatitude).val().match(regex) || !$(GeoLongitude).val().match(regex)) {
                $.alert('@Resource.GeoLatitudeLongitudeError');
            } else {

                if (typeof $(GeoLatitude).val() != "undefined" && $(GeoLatitude).val() != "" & typeof $(GeoLongitude).val() != "undefined" & $(GeoLongitude).val() != "") {
                    Latitude = $(GeoLatitude).val().replace(".",",");
                    Longitude = $(GeoLongitude).val().replace(".", ",");
               }

          //      else if (Latitude == 0.0 || Longitude == 0.0 ) {
          //          $.alert('"Veuillez sélectionner un emplacement sur la carte."');
		        //}
                var Coderegex = /[a-zA-Z0-9_]{1,5}/;

            if (typeof $(Code).val() == "undefined" || $(Code).val() == "" || typeof $(Nom).val() == "undefined" || $(Nom).val() == "" || typeof $(CommuneId).val() == "undefined" || $(CommuneId).val() == "" ||typeof $(OrganisationId).val() == "undefined" || $(OrganisationId).val() == "" || typeof $(Telephone).val() == "undefined" || $(Telephone).val() == "" ) {
                    //alert("Veuillez renseigner tous les champs obligatoires.");
                    $.alert('"Veuillez renseigner tous les champs obligatoires."');
            } else if (!$(Code).val().match(Coderegex)) {
                $.alert("Le champ code doit avoir maximum 5 caratères");
            }else{

                    var dataRow = {
                        'Code': $(Code).val(),
                        'Nom': $(Nom).val(),
                        'CommuneId': $(CommuneId).val(),
                        'OrganisationId': $(OrganisationId).val(),
                        'Possession': $(Possession).val(),
                        'HauteurMaximum': $(HauteurMaximum).val(),
                        'HauteurMaximumUnites': $(HauteurMaximumUnites).val(),
                        'ProfondeurQuaiChargement': $(ProfondeurQuaiChargement).val(),
                        'ProfondeurQuaiChargementUnites': $(ProfondeurQuaiChargementUnites).val(),
                        'ProfondeurTerminalPetrolier': $(ProfondeurTerminalPetrolier).val(),
                        'ProfondeurTerminalPetrolierUnites': $(ProfondeurTerminalPetrolierUnites).val(),
                        'CaleSeche': $(CaleSeche).val(),
                        'LongueurMaximaleNavire': $(LongueurMaximaleNavire).val(),
                        'LongueurMaximaleNavireUnites': $(LongueurMaximaleNavireUnites).val(),
                        'Reparations': $(Reparations).val(),
                        'Abri': $(Abri).val(),
                        'CapaciteStockageEntreposage': $(CapaciteStockageEntreposage).val(),
                        'CapaciteStockageSecurise': $(CapaciteStockageSecurise).val(),
                        'CapaciteStockageEntrepotDouanier': $(CapaciteStockageEntrepotDouanier).val(),
                        'NombreRemorqueur': $(NombreRemorqueur).val(),
                        'CapaciteRemorqueur': $(CapaciteRemorqueur).val(),
                        'NombreBarge': $(NombreBarge).val(),
                        'CapacietBarge': $(CapacietBarge).val(),
                        'EquipementChargement': $(EquipementChargement).val(),
                        'CapaciteDouaniere': $(CapaciteDouaniere).val(),
                        'Securite': $(Securite).val(),
                        'ProfondeurMareHaute': $(ProfondeurMareHaute).val(),
                        'ProfondeurMareHauteUnites': $(ProfondeurMareHauteUnites).val(),
                        'ProfondeurMareBasse': $(ProfondeurMareBasse).val(),
                        'ProfondeurMareBasseUnites': $(ProfondeurMareBasseUnites).val(),
                        'ProfondeurInondation': $(ProfondeurInondation).val(),
                        'ProfondeurInondationUnites': $(ProfondeurInondationUnites).val(),
                        'Telephone': $(Telephone).val(),
                        'Telephone2': $(Telephone2).val(),
                        'SiteWeb': $(SiteWeb).val(),
                        'Email': $(Email).val(),
                        'Latitude': Latitude,
                        'Longitude': Longitude
                    }

                    //alert("c'est moi le createPatient avant ajax");

                    $.ajax({
                        type: 'POST',
                        url: '@Url.Action("Create", "PortDeMers")',
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(dataRow),

                        // here we are get value of selected country and passing same value as inputto json method GetStates.

                        success: function (response) {
                            if (response.Result == "OK") {

                                //$.alert(response.Result);
                                window.location.href = '@Url.Action("Index", "PortDeMers")';
                            }
                            //else {
                            //    //$.alert(data[0]);
                            //}
                        },
                        error: function (theResponse) {
                            $.alert(theResponse.responseText);

                        }


                    });
                }
            }
            }

    </script>

End Section