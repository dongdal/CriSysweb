@ModelType HopitauxViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.EditHopitaux
    Layout = "~/Views/Shared/_LayoutSahana.vbhtml"
    Dim Libelle = Model.Nom
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageHopitaux</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Hopitaux")>@Resource.ManageHopitaux</a></li>
        <li class="breadcrumb-item active">@Resource.EditHopitaux</li>
    </ol>
</div>

<div class="container-fluid">
    <h6 class="text-uppercase">@Resource.EditHopitaux</h6>
    <hr>
    @Using Html.BeginForm("Edit", "Hopitaux", FormMethod.Post, New With {.autocomplete = "off"})
        @Html.AntiForgeryToken()
        @Html.HiddenFor(Function(m) m.Id)
        @Html.HiddenFor(Function(m) m.StatutExistant)
        @Html.HiddenFor(Function(m) m.DateCreation)
        @Html.HiddenFor(Function(m) m.AspNetUserId)
        @*@Html.HiddenFor(Function(m) m.Location)*@

        @<div Class="col-lg-12">
            <div Class="card">
                <div Class="card-body">
                    <ul Class="nav nav-tabs nav-tabs-primary">
                        <li Class="nav-item">
                            <a Class="nav-link active" data-toggle="tab" href="#tabe-1"><i class="icon-home"></i> <span class="hidden-xs">@Resource.Hopitaux</span></a>
                        </li>
                        <li Class="nav-item">
                            <a Class="nav-link" data-toggle="tab" href="#tabe-2"><i class="icon-wallet"></i> <span class="hidden-xs">@Resource.Materiel</span></a>
                        </li>

                    </ul>
                    <div class="tab-content">
                        <div id="tabe-1" class="container tab-pane active">

                            <div Class="form-group row">
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

                            <div Class="form-group row">
                                @Html.LabelFor(Function(m) m.TypeHopitauxId, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4 form-group">
                                    @Html.DropDownListFor(Function(m) m.TypeHopitauxId, New SelectList(Model.LesTypeHopitauxs, "Value", "Text"), Resource.TypeHopitauxCombo,
           New With {.class = "form-control single-select", .tabindex = "3", .Placeholder = Resource.TypeHopitauxCombo})
                                    @Html.ValidationMessageFor(Function(m) m.TypeHopitauxId, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.OrganisationId, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4 form-group">
                                    @Html.DropDownListFor(Function(m) m.OrganisationId, New SelectList(Model.LesOrganisations, "Value", "Text"), Resource.ComboOrganisation,
                                New With {.class = "form-control single-select", .tabindex = "4", .Placeholder = Resource.ComboOrganisation})
                                    @Html.ValidationMessageFor(Function(m) m.OrganisationId, "", New With {.style = "color: #da0b0b"})
                                </div>

                            </div>

                            <div Class="form-group row">
                                @Html.LabelFor(Function(m) m.CommuneId, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4 form-group">
                                    @Html.DropDownListFor(Function(m) m.CommuneId, New SelectList(Model.LesCommunes, "Value", "Text"), Resource.CommuneCombo,
                     New With {.class = "form-control single-select", .tabindex = "5", .Placeholder = Resource.CommuneCombo})
                                    @Html.ValidationMessageFor(Function(m) m.CommuneId, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreDeMedecin, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4">
                                    @Html.TextBoxFor(Function(m) m.NombreDeMedecin, New With {.class = "form-control form-control-square", .tabindex = "6", .Placeholder = Resource.NombreDeMedecinPlaceholder})
                                    @Html.ValidationMessageFor(Function(m) m.NombreDeMedecin, "", New With {.style = "color: #da0b0b"})
                                </div>

                            </div>

                            <div Class="form-group row">
                                @Html.LabelFor(Function(m) m.NombreDInfimiere, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4">
                                    @Html.TextBoxFor(Function(m) m.NombreDInfimiere, New With {.class = "form-control form-control-square ", .tabindex = "7", .Placeholder = Resource.NombreDInfimierePlaceholder})
                                    @Html.ValidationMessageFor(Function(m) m.NombreDInfimiere, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreDePersonnelNonMedical, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4">
                                    @Html.TextBoxFor(Function(m) m.NombreDePersonnelNonMedical, New With {.class = "form-control form-control-square", .tabindex = "8", .Placeholder = Resource.NombreDePersonnelNonMedicalPlaceholder})
                                    @Html.ValidationMessageFor(Function(m) m.NombreDePersonnelNonMedical, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </div>

                            <div Class="form-group row">
                                @Html.LabelFor(Function(m) m.NombreDeLitMin, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4">
                                    @Html.TextBoxFor(Function(m) m.NombreDeLitMin, New With {.class = "form-control form-control-square ", .tabindex = "9", .Placeholder = Resource.NombreDeLitMinPlaceholder})
                                    @Html.ValidationMessageFor(Function(m) m.NombreDeLitMin, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreDeLitMax, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4">
                                    @Html.TextBoxFor(Function(m) m.NombreDeLitMax, New With {.class = "form-control form-control-square", .tabindex = "10", .Placeholder = Resource.NombreDeLitMaxPlaceholder})
                                    @Html.ValidationMessageFor(Function(m) m.NombreDeLitMax, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </div>

                            <div Class="form-group row">
                                @Html.LabelFor(Function(m) m.Telephone, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4">
                                    @Html.TextBoxFor(Function(m) m.Telephone, New With {.class = "form-control form-control-square ", .tabindex = "11", .Placeholder = Resource.TelephonePlaceholder})
                                    @Html.ValidationMessageFor(Function(m) m.Telephone, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.TelephoneUrgence, New With {.class = "col-sm-2 col-form-label"})
                                <div class="col-sm-4">
                                    @Html.TextBoxFor(Function(m) m.TelephoneUrgence, New With {.class = "form-control form-control-square", .tabindex = "12", .Placeholder = Resource.TelephoneUrgencePlaceholder})
                                    @Html.ValidationMessageFor(Function(m) m.TelephoneUrgence, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </div>

                            <div Class="form-group row">
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

                            <div Class="form-group row">
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


                            <br />
                            <div Class="form-group row">
                                <Label Class="col-sm-2 col-form-label"></Label>
                                <div Class="col-sm-10">
                                    <Button type="button" onclick="EditHopitaux();" Class="btn btn-link btn-square bg-primary text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.Btn_Edit</Button>
                                    &nbsp;&nbsp;&nbsp;
                                    @Html.ActionLink(Resource.BtnCancel, "Index", Nothing, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                                </div>
                            </div>

                        </div>

                        <div id="tabe-2" class="container tab-pane fade">

                            <div Class="form-group row">
                                @Html.LabelFor(Function(m) m.MaterielHopitauxId, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4 form-group">
                                    @Html.DropDownListFor(Function(m) m.MaterielHopitauxId, New SelectList(Model.LesMaterielHopitaux, "Value", "Text"), Resource.ComboMateriel,
New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboMateriel})
                                    @Html.ValidationMessageFor(Function(m) m.MaterielHopitauxId, "", New With {.style = "color: #da0b0b"})
                                </div>
                                <div class="col-sm-4">
                                    @Html.TextBoxFor(Function(m) m.Quantite, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.QantitePlaceholder})
                                    @Html.ValidationMessageFor(Function(m) m.Quantite, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </div>
                            <div Class="form-group row">
                                <Label Class="col-sm-2 col-form-label"></Label>
                                <div Class="col-sm-10">
                                    <input type="submit" value="@Resource.BtnSave" name="AddMateriel" class="btn btn-primary btn-sm" />
                                </div>
                            </div>
                            <br />

                            <table id="zero_config" class="table table-striped table-bordered">
                                <thead>
                                    <tr>
                                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                            @Resource.Libelle
                                        </th>
                                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                            @Resource.Quantite
                                        </th>
                                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                            @Resource.ActionList
                                        </th>
                                    </tr>
                                </thead>

                                <tbody>
                                    @For Each item In Model.MaterielHopitaux
                                        @<tr>

                                            <td>
                                                @item.Materiel.Libelle
                                            </td>
                                            <td>
                                                @item.Quantite    
                                            </td>
                                            <td>
                                                <a class="btn btn-round btn-danger waves-effect waves-light m-1 DeleteMateriel" title="@Resource.Btn_Delete" href="javascript:void(0);" data-id="@item.Id">
                                                    <i class="fa fa-trash" aria-hidden="true"></i>
                                                </a>
                                            </td>
                                        </tr>
                                    Next
                                </tbody>

                            </table>
                        </div>
                        <br/>
                    </div>
                </div>
            </div>
        </div>
    End Using

</div>
@Section Scripts

    <script>
    var GeoLatitude = '#GeoLatitude';
        var GeoLongitude = '#GeoLongitude';

        var oldLatitude = $(GeoLatitude).val().replace(",",".");
        var oldLongitude = $(GeoLongitude).val().replace(",", ".");;

    L.marker([oldLatitude, oldLongitude]).addTo(mymap)
        .bindPopup('<p><h6>' + 'Ancien emplacement : ' + '@Libelle.ToUpper()' + '</h6>. <br/><h6>Latitude: ' + oldLatitude + '</h6><br/><h6>Longitude: ' + oldLongitude + '</h6></p>')
        .openPopup();
    </script>

    <script>
        var Latitude = oldLatitude.replace(".", ",");
        var Longitude = oldLongitude.replace(".", ",");

        var popup = L.popup();

        function onMapClick(e) {
            popup
                .setLatLng(e.latlng)
                .setContent("You clicked the map at " + e.latlng.toString())
                .openOn(mymap);
        }

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
            theMarker = L.marker([lat, lon]).addTo(mymap).bindPopup('<p><h6>' + 'Nouvel emplacement de : ' + $('#Nom').val() + '</h6>. <br/><h6>Latitude: ' + Latitude + '</h6><br/><h6>Longitude: ' + Longitude + '</h6></p>').openPopup();
            //theMarker = L.polygon([lat, lon]).addTo(mymap).bindPopup("You clicked the map at LAT: " + lat + " and LONG: " + lon).openPopup();

        });



        function EditHopitaux() {
                var Id = '#Id';
		        var Code= '#Code';
		        var Nom= '#Nom';
                var CommuneId = '#CommuneId';
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
                  Latitude = $(GeoLatitude).val().replace(".", ",");
            Longitude = $(GeoLongitude).val().replace(".", ",");

            var regex = /^[-+]?(\d+(((\,))\d+)?)$/;
            if (!Latitude.match(regex) || !Longitude.match(regex)) {
                $.alert('@Resource.GeoLatitudeLongitudeError');
            }  else {

                if (typeof $(GeoLatitude).val() != "undefined" && $(GeoLatitude).val() != "" & typeof $(GeoLongitude).val() != "undefined" & $(GeoLongitude).val() != "") {
                    if ($(GeoLatitude).val() != oldLatitude.replace(".", ",") || $(GeoLongitude).val() != oldLongitude.replace(".", ",")) {
                        Latitude = $(GeoLatitude).val().replace(".", ",");
                        Longitude = $(GeoLongitude).val().replace(".", ",");
                    }
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
                        'Id': $(Id).val(),
                        'Code': $(Code).val(),
                        'Nom': $(Nom).val(),
                        'CommuneId': $(CommuneId).val(),
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
                        url: '@Url.Action("EditHopitaux", "Hopitaux")',
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
        }

    </script>

    <script>

        $('.DeleteMateriel').click(function (e) {
            e.preventDefault();
            var $ctrl = $(this);
            var Id = $(this).data("id");
            //$.alert("Identifiant= " + Id);
            $.confirm({
                title: '@Resource.Btn_Delete',
                content: '@Resource.ConfirmDelete',
                animationSpeed: 1000,
                animationBounce: 3,
                animation: 'rotatey',
                closeAnimation: 'scaley',
                theme: 'supervan',
                buttons: {
                    Confirmer: function () {
                        $.ajax({
                            url: '@Url.Action("DeleteMateriel")',
                            type: 'POST',
                            data: { id: Id }
                        }).done(function (data) {
                            if (data.Result == "OK") {
                                //$ctrl.closest('li').remove();
                                $.confirm({
                                    title: '@Resource.SuccessTitle',
                                    content: '@Resource.SuccessProcess',
                                    animationSpeed: 1000,
                                    animationBounce: 3,
                                    animation: 'rotatey',
                                    closeAnimation: 'scaley',
                                    theme: 'supervan',
                                    buttons: {
                                        OK: function () {
                                            window.location.reload();
                                        }
                                    }
                                });
                            }
                            else if (data.Result.Message) {
                                alert(data.Result.Message);
                            }
                        }).fail(function () {
                            @*//$.alert('@Resource.ErrorProcess');*@
                            $.confirm({
                                title: '@Resource.ErreurTitle',
                                content: '@Resource.ErrorProcess',
                                animationSpeed: 1000,
                                animationBounce: 3,
                                animation: 'rotatey',
                                closeAnimation: 'scaley',
                                theme: 'supervan',
                                buttons: {
                                    OK: function () {
                                    }
                                }
                            });
                        })
                    },
                    Annuler: function () {
                        $.confirm({
                            title: '@Resource.CancelingProcess',
                            content: '@Resource.CancelingConfirmed',
                            animationSpeed: 1000,
                            animationBounce: 3,
                            animation: 'rotatey',
                            closeAnimation: 'scaley',
                            theme: 'supervan',
                            buttons: {
                                OK: function () {
                                }
                            }
                        });
                    }
                }
            });
        });

    </script>

End Section                