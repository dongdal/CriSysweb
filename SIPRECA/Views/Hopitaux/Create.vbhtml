@ModelType HopitauxViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.CreateHopitaux
    Layout = "~/Views/Shared/_LayoutSahana.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageHopitaux</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Hopitaux")>@Resource.ManageHopitaux</a></li>
        <li class="breadcrumb-item active">@Resource.CreateHopitaux</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.CreateHopitaux</div>
            <hr>
            @Using Html.BeginForm("Create", "Hopitaux", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Code, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Code, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.CODEPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Code, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Nom, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Nom, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.NamePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Nom, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.TypeHopitauxId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.TypeHopitauxId, New SelectList(Model.LesTypeHopitauxs, "Value", "Text"), Resource.TypeHopitauxCombo,
                 New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.TypeHopitauxCombo})
                        @Html.ValidationMessageFor(Function(m) m.TypeHopitauxId, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.OrganisationId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.OrganisationId, New SelectList(Model.LesOrganisations, "Value", "Text"), Resource.ComboOrganisation,
                                      New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboOrganisation})
                        @Html.ValidationMessageFor(Function(m) m.OrganisationId, "", New With {.style = "color: #da0b0b"})
                    </div>

                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.VilleId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.VilleId, New SelectList(Model.LesVilles, "Value", "Text"), Resource.VilleCombo,
                                 New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.VilleCombo})
                        @Html.ValidationMessageFor(Function(m) m.VilleId, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.NombreDeMedecin, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.NombreDeMedecin, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.NombreDeMedecinPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.NombreDeMedecin, "", New With {.style = "color: #da0b0b"})
                    </div>

                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.NombreDInfimiere, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.NombreDInfimiere, New With {.class = "form-control form-control-square ", .tabindex = "4", .Placeholder = Resource.NombreDInfimierePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.NombreDInfimiere, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.NombreDePersonnelNonMedical, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.NombreDePersonnelNonMedical, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.NombreDePersonnelNonMedicalPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.NombreDePersonnelNonMedical, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.NombreDeLitMin, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.NombreDeLitMin, New With {.class = "form-control form-control-square ", .tabindex = "4", .Placeholder = Resource.NombreDeLitMinPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.NombreDeLitMin, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.NombreDeLitMax, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.NombreDeLitMax, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.NombreDeLitMaxPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.NombreDeLitMax, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Telephone, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Telephone, New With {.class = "form-control form-control-square ", .tabindex = "4", .Placeholder = Resource.TelephonePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Telephone, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.TelephoneUrgence, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.TelephoneUrgence, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.TelephoneUrgencePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.TelephoneUrgence, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.SiteWeb, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.SiteWeb, New With {.class = "form-control form-control-square", .tabindex = "4", .Placeholder = Resource.SiteWebPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.SiteWeb, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Email, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.EmailPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @Html.Partial("_MyMapEnterPartial")



            End Using
            <br />
            <div Class="form-group row">
                <Label Class="col-sm-2 col-form-label"></Label>
                <div Class="col-sm-10">
                    <Button type="button" onclick="CreateHopitaux();" Class="btn btn-link btn-square bg-primary text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.BtnSave</Button>
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


        function CreateHopitaux() {
		        var Code= '#Code';
		        var Nom= '#Nom';
		        var VilleId= '#VilleId';
                var OrganisationId = '#OrganisationId';
                var TypeHopitauxId = '#TypeHopitauxId';
                var NombreDeLitMin = '#NombreDeLitMin';
                var NombreDeLitMax = '#NombreDeLitMax';
                var NombreDeMedecin = '#NombreDeMedecin';
                var NombreDInfimiere = '#NombreDInfimiere';
                var NombreDePersonnelNonMedical = '#NombreDePersonnelNonMedical';
		        var Telephone= '#Telephone';
                var TelephoneUrgence = '#TelephoneUrgence';
		        var SiteWeb= '#SiteWeb';
		        var Email= '#Email';
                //alert("You clicked the map at LAT: " + Latitude + " and LONG: " + Longitude);
                //alert("DateNaissance= " + DateNaissance);

                if (typeof $(Code).val() == "undefined" || $(Code).val() == "" || typeof $(Nom).val() == "undefined" || $(Nom).val() == "" ||typeof $(VilleId).val() == "undefined" || $(VilleId).val() == "" ||typeof $(OrganisationId).val() == "undefined" || $(OrganisationId).val() == "" || typeof $(Telephone).val() == "undefined" || $(Telephone).val() == "" ) {
                    //alert("Veuillez renseigner tous les champs obligatoires.");
                    $.alert('"Veuillez renseigner tous les champs obligatoires."');
                }
                else if (Latitude == 0.0 || Longitude == 0.0 || typeof Latitude == "undefined" || typeof Longitude == "undefined" ) {
                    $.alert('"Veuillez sélectionner un emplacement sur la carte."');
		        }
		        else{

                    var dataRow = {
                        'Code': $(Code).val(),
                        'Nom': $(Nom).val(),
                        'VilleId': $(VilleId).val(),
                        'OrganisationId': $(OrganisationId).val(),
                        'TypeHopitauxId': $(TypeHopitauxId).val(),
                        'NombreDeLitMin': $(NombreDeLitMin).val(),
                        'NombreDeLitMax': $(NombreDeLitMax).val(),
                        'NombreDeMedecin': $(NombreDeMedecin).val(),
                        'NombreDInfimiere': $(NombreDInfimiere).val(),
                        'NombreDePersonnelNonMedical': $(NombreDePersonnelNonMedical).val(),
                        'Telephone': $(Telephone).val(),
                        'TelephoneUrgence': $(TelephoneUrgence).val(),
                        'SiteWeb': $(SiteWeb).val(),
                        'Email': $(Email).val(),
                        'Latitude': Latitude,
                        'Longitude': Longitude
                    }

                    //alert("c'est moi le createPatient avant ajax");

                    $.ajax({
                        type: 'POST',
                        url: '@Url.Action("Create", "Hopitaux")',
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(dataRow),

                        // here we are get value of selected country and passing same value as inputto json method GetStates.

                        success: function (response) {
                            if (response.Result == "OK") {

                                //$.alert(response.Result);
                                window.location.href = '@Url.Action("Index", "Hopitaux")';
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

    </script>

End Section