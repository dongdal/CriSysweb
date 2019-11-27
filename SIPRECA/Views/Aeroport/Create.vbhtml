@ModelType AeroportViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.CreateAeroport
    Layout = "~/Views/Shared/_LayoutSahana.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageAeroport</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Aeroport")>@Resource.ManageAeroport</a></li>
        <li class="breadcrumb-item active">@Resource.CreateAeroport</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.CreateAeroport</div>
            <hr>
            @Using Html.BeginForm("Create", "Aeroport", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Nom, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Nom, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.NamePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Nom, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.ICAO, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.ICAO, New With {.class = "form-control form-control-square", .tabindex = "2", .Placeholder = Resource.ICAOPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.ICAO, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">

                    @Html.LabelFor(Function(m) m.IATA, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.IATA, New With {.class = "form-control form-control-square", .tabindex = "3", .Placeholder = Resource.IATAPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.IATA, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.OganisationId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.OganisationId, New SelectList(Model.LesOrganisations, "Value", "Text"), Resource.ComboOrganisation,
                  New With {.class = "form-control single-select", .tabindex = "4", .Placeholder = Resource.TypeHopitauxCombo})
                        @Html.ValidationMessageFor(Function(m) m.OganisationId, "", New With {.style = "color: #da0b0b"})
                    </div>


                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.CommuneId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.CommuneId, New SelectList(Model.LesCommunes, "Value", "Text"), Resource.CommuneCombo,
                  New With {.class = "form-control single-select", .tabindex = "5", .Placeholder = Resource.CommuneCombo})
                        @Html.ValidationMessageFor(Function(m) m.CommuneId, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.SurfaceDePisteId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.SurfaceDePisteId, New SelectList(Model.LesSurfaceDePistes, "Value", "Text"), Resource.SurfaceDePisteCombo,
               New With {.class = "form-control single-select", .tabindex = "6", .Placeholder = Resource.VilleCombo})
                        @Html.ValidationMessageFor(Function(m) m.SurfaceDePisteId, "", New With {.style = "color: #da0b0b"})
                    </div>

                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.TailleDeAeronefId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.TailleDeAeronefId, New SelectList(Model.LesTailleDeAeronefs, "Value", "Text"), Resource.TailleDeAeronefCombo,
New With {.class = "form-control single-select", .tabindex = "7", .Placeholder = Resource.VilleCombo})
                        @Html.ValidationMessageFor(Function(m) m.TailleDeAeronefId, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.UsageHumanitaireId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.UsageHumanitaireId, New SelectList(Model.LesUsageHumanitaires, "Value", "Text"), Resource.UsageHumanitaireCombo,
   New With {.class = "form-control single-select", .tabindex = "8", .Placeholder = Resource.VilleCombo})
                        @Html.ValidationMessageFor(Function(m) m.UsageHumanitaireId, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.LongueurDePiste, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.LongueurDePiste, New With {.class = "form-control form-control-square ", .tabindex = "9", .Placeholder = Resource.LongueurDePistePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.LongueurDePiste, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.LargeurDePiste, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.LargeurDePiste, New With {.class = "form-control form-control-square", .tabindex = "10", .Placeholder = Resource.LargeurDePistePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.LargeurDePiste, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Telephone, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Telephone, New With {.class = "form-control form-control-square ", .tabindex = "11", .Placeholder = Resource.TelephonePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Telephone, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Telephone2, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Telephone2, New With {.class = "form-control form-control-square", .tabindex = "12", .Placeholder = Resource.Telephone2Placeholder})
                        @Html.ValidationMessageFor(Function(m) m.Telephone2, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.SiteWeb, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.SiteWeb, New With {.class = "form-control form-control-square", .tabindex = "13", .Placeholder = Resource.SiteWebPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.SiteWeb, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Email, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control form-control-square", .tabindex = "14", .Placeholder = Resource.EmailPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.GeoLatitude, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.GeoLatitude, New With {.class = "form-control form-control-square", .tabindex = "15", .Placeholder = Resource.Latitude})
                        @Html.ValidationMessageFor(Function(m) m.GeoLatitude, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.GeoLongitude, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.GeoLongitude, New With {.class = "form-control form-control-square", .tabindex = "16", .Placeholder = Resource.Longitude})
                        @Html.ValidationMessageFor(Function(m) m.GeoLongitude, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @Html.Partial("_MyMapEnterPartial")



            End Using
            <div Class="form-group row">
                <Label Class="col-sm-2 col-form-label"></Label>
                <div Class="col-sm-10">
                    <Button type="button" onclick="CreateAeroport();" Class="btn btn-link btn-square bg-primary text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.BtnSave</Button>
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


        function CreateAeroport() {
                var ICAO = '#ICAO';
                var IATA = '#IATA';
		        var Nom = '#Nom';
            var CommuneId = '#CommuneId';
            var OrganisationId = '#OganisationId';
                var SurfaceDePisteId = '#SurfaceDePisteId';
                var LongueurDePiste = '#LongueurDePiste';
                var LargeurDePiste = '#LargeurDePiste';
                var TailleDeAeronefId = '#TailleDeAeronefId';
                var UsageHumanitaireId = '#UsageHumanitaireId';
		        var Telephone = '#Telephone';
                var Telephone2 = '#Telephone2';
		        var SiteWeb = '#SiteWeb';
		        var Email = '#Email';
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

            if (typeof $(ICAO).val() == "undefined" || $(ICAO).val() == "" || $(IATA).val() == "undefined" || $(IATA).val() == "" || typeof $(Nom).val() == "undefined" || $(Nom).val() == "" || typeof $(CommuneId).val() == "undefined" || $(CommuneId).val() == "" ||typeof $(OrganisationId).val() == "undefined" || $(OrganisationId).val() == "" || typeof $(Telephone).val() == "undefined" || $(Telephone).val() == "" ) {
                    //alert("Veuillez renseigner tous les champs obligatoires.");
                    $.alert('"Veuillez renseigner tous les champs obligatoires."');
            }else{

                    var dataRow = {
                        'ICAO': $(ICAO).val(),
                        'IATA': $(IATA).val(),
                        'Nom': $(Nom).val(),
                        'CommuneId': $(CommuneId).val(),
                        'OganisationId': $(OrganisationId).val(),
                        'SurfaceDePisteId': $(SurfaceDePisteId).val(),
                        'LongueurDePiste': $(LongueurDePiste).val(),
                        'LargeurDePiste': $(LargeurDePiste).val(),
                        'TailleDeAeronefId': $(TailleDeAeronefId).val(),
                        'UsageHumanitaireId': $(UsageHumanitaireId).val(),
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
                        url: '@Url.Action("Create", "Aeroport")',
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(dataRow),

                        // here we are get value of selected country and passing same value as inputto json method GetStates.

                        success: function (response) {
                            if (response.Result == "OK") {

                                //$.alert(response.Result);
                                window.location.href = '@Url.Action("Index", "Aeroport")';
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