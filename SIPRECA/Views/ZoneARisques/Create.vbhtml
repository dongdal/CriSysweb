@ModelType ZoneARisqueViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.CreateZoneARisque
    Layout = "~/Views/Shared/_LayoutDesinventar.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageZoneARisque</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "ZoneARisques")>@Resource.ManageZoneARisque</a></li>
        <li class="breadcrumb-item active">@Resource.CreateZoneARisque</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.CreateZoneARisque</div>
            <hr>
            @Using Html.BeginForm("Create", "ZoneARisques", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Libelle, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Libelle, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.LibellePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Libelle, "", New With {.style = "color: #da0b0b"})
                    </div>
                    @Html.LabelFor(Function(m) m.Rayon, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Rayon, New With {.class = "form-control form-control-square", .tabindex = "7", .Placeholder = Resource.Rayon})
                        @Html.ValidationMessageFor(Function(m) m.Rayon, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>
                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.GeoLatitude, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.GeoLatitude, New With {.class = "form-control form-control-square", .tabindex = "7", .Placeholder = Resource.Latitude})
                        @Html.ValidationMessageFor(Function(m) m.GeoLatitude, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.GeoLongitude, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.GeoLongitude, New With {.class = "form-control form-control-square", .tabindex = "8", .Placeholder = Resource.Longitude})
                        @Html.ValidationMessageFor(Function(m) m.GeoLongitude, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @Html.Partial("_MyMapEnterPartial")

                @<div Class="form-group row">
                    <Label Class="col-sm-2 col-form-label"></Label>
                    <div Class="col-sm-10">
                        <Button type="button" onclick="CreateZoneARisque();" Class="btn btn-link btn-square bg-primary text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.BtnSave</Button>
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
            var GeoLatitude = '#GeoLatitude';
            var GeoLongitude = '#GeoLongitude';

            $(GeoLatitude).val(lat);
            $(GeoLongitude).val(lon);
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


        function CreateZoneARisque() {
            var Libelle = '#Libelle';
            var GeoLatitude = '#GeoLatitude';
            var GeoLongitude = '#GeoLongitude';
            var Rayon = '#Rayon';

            Latitude = $(GeoLatitude).val().replace(".", ",");
            Longitude = $(GeoLongitude).val().replace(".", ",");

            var regex = /^[-+]?(\d+(((\,))\d+)?)$/;
            if (!Latitude.match(regex) || !Longitude.match(regex)) {
                $.alert('@Resource.GeoLatitudeLongitudeError');
            } else {

                if (typeof $(GeoLatitude).val() != "undefined" && $(GeoLatitude).val() != "" & typeof $(GeoLongitude).val() != "undefined" & $(GeoLongitude).val() != "") {
                    Latitude = $(GeoLatitude).val().replace(".", ",");
                    Longitude = $(GeoLongitude).val().replace(".", ",");
                }

                var Coderegex = /[a-zA-Z0-9_]{1,5}/;


                if(typeof $(Libelle).val() == "undefined" || $(Libelle).val() == "" || typeof Rayon == "undefined" || typeof Rayon == "undefined") {
                    //alert("Veuillez renseigner tous les champs obligatoires.");
                    $.alert('"Veuillez renseigner tous les champs obligatoires."');
                }
                //else if (typeof Latitude == "undefined" || typeof Longitude == "undefined") {
                //    $.alert('"Veuillez sélectionner un emplacement sur la carte."');
                //}
                else {
                    var dataRow = {
                        'Libelle': $(Libelle).val(),
                        'Rayon': $(Rayon).val(),
                        'Latitude': Latitude,
                        'Longitude': Longitude,
                    }

                    $.ajax({
                        type: 'POST',
                        url: '@Url.Action("Create", "ZoneARisques")',
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(dataRow),

                        // here we are get value of selected country and passing same value as inputto json method GetStates.

                        success: function (response) {
                            if (response.Result == "OK") {

                                //$.alert(response.Result);
                                window.location.href = '@Url.Action("Index", "ZoneARisques")';
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
