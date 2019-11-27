@ModelType AbrisViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.CreateAbris
    Layout = "~/Views/Shared/_LayoutSahana.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageAbris</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Abris")>@Resource.ManageAbris</a></li>
        <li class="breadcrumb-item active">@Resource.CreateAbris</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.CreateAbris</div>
            <hr>
            @Using Html.BeginForm("Create", "Abris", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()

                @<div Class="form-group row">

                    @Html.LabelFor(Function(m) m.Nom, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Nom, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.NamePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Nom, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.TypeAbrisId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.TypeAbrisId, New SelectList(Model.LesTypeAbris, "Value", "Text"), Resource.TypeAbrisCombo,
                         New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.TypeAbrisCombo})
                        @Html.ValidationMessageFor(Function(m) m.TypeAbrisId, "", New With {.style = "color: #da0b0b"})
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
                    @Html.LabelFor(Function(m) m.EstimationPopulation, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.EstimationPopulation, New With {.class = "form-control form-control-square ", .tabindex = "5", .Placeholder = Resource.EstimationPopulationPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.EstimationPopulation, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Capacite, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Capacite, New With {.class = "form-control form-control-square", .tabindex = "6", .Placeholder = Resource.CapacitePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Capacite, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>
                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.GeoLatitude, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.GeoLatitude, New With {.class = "form-control form-control-square", .tabindex = "7", .Placeholder = Resource.Latitude})
                        @Html.ValidationMessageFor(Function(m) m.GeoLatitude, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.GeoLongitude, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.GeoLongitude, New With {.class = "form-control form-control-square", .tabindex = "8", .Placeholder = Resource.Longitude})
                        @Html.ValidationMessageFor(Function(m) m.GeoLongitude, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @Html.Partial("_MyMapEnterPartial")

            @<br />


            End Using
            <div Class="form-group row">
                <Label Class="col-sm-2 col-form-label"></Label>
                <div Class="col-sm-10">
                    <Button type="button" onclick="CreateAbris();" Class="btn btn-link btn-square bg-primary text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.BtnSave</Button>
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


        function CreateAbris() {
		        var Nom= '#Nom';
            var CommuneId = '#CommuneId';
                var OrganisationId = '#OrganisationId';
                var TypeAbrisId = '#TypeAbrisId';
                var EstimationPopulation = '#EstimationPopulation';
                var Capacite = '#Capacite';
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


            if (typeof $(Nom).val() == "undefined" || $(Nom).val() == "" || typeof $(CommuneId).val() == "undefined" || $(CommuneId).val() == "" || typeof $(OrganisationId).val() == "undefined" || $(OrganisationId).val() == "" || typeof $(TypeAbrisId).val() == "undefined" || $(TypeAbrisId).val() == "" ) {
                    //alert("Veuillez renseigner tous les champs obligatoires.");
                    $.alert('"Veuillez renseigner tous les champs obligatoires."');
                }else{

                    var dataRow = {
                        'Nom': $(Nom).val(),
                        'CommuneId': $(CommuneId).val(),
                        'OrganisationId': $(OrganisationId).val(),
                        'TypeAbrisId': $(TypeAbrisId).val(),
                        'EstimationPopulation': $(EstimationPopulation).val(),
                        'Capacite': $(Capacite).val(),
                        'Latitude': Latitude,
                        'Longitude': Longitude
                    }
                    //alert("c'est moi le createPatient avant ajax");

                    $.ajax({
                        type: 'POST',
                        url: '@Url.Action("Create", "Abris")',
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(dataRow),

                        // here we are get value of selected country and passing same value as inputto json method GetStates.

                        success: function (response) {
                            if (response.Result == "OK") {

                                //$.alert(response.Result);
                                window.location.href = '@Url.Action("Index", "Abris")';
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