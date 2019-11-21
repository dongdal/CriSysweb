@ModelType AeroportViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.EditAeroport
    Layout = "~/Views/Shared/_LayoutSahana.vbhtml"
    Dim Libelle = Model.Nom
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageAeroport</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Aeroport")>@Resource.ManageAeroport</a></li>
        <li class="breadcrumb-item active">@Resource.EditAeroport</li>
    </ol>
</div>

<div class="container-fluid">
    <h6 class="text-uppercase">@Resource.EditAeroport</h6>
    <hr>
    @Using Html.BeginForm("Edit", "Aeroport", FormMethod.Post, New With {.autocomplete = "off"})
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
                            <a Class="nav-link active" data-toggle="tab" href="#tabe-1"><i class="icon-home"></i> <span class="hidden-xs">@Resource.Aeroport</span></a>
                        </li>
                        <li Class="nav-item">
                            <a Class="nav-link" data-toggle="tab" href="#tabe-2"><i class="icon-wallet"></i> <span class="hidden-xs">@Resource.Materiel</span></a>
                        </li>

                    </ul>
                    <div class="tab-content">
                        <div id="tabe-1" class="container tab-pane active">

                            <div Class="form-group row">
                                @Html.LabelFor(Function(m) m.Nom, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4">
                                    @Html.TextBoxFor(Function(m) m.Nom, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.NamePlaceholder})
                                    @Html.ValidationMessageFor(Function(m) m.Nom, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.ICAO, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4">
                                    @Html.TextBoxFor(Function(m) m.ICAO, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.ICAOPlaceholder})
                                    @Html.ValidationMessageFor(Function(m) m.ICAO, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </div>

                            <div Class="form-group row">

                                @Html.LabelFor(Function(m) m.IATA, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4">
                                    @Html.TextBoxFor(Function(m) m.IATA, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.IATAPlaceholder})
                                    @Html.ValidationMessageFor(Function(m) m.IATA, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.OganisationId, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4 form-group">
                                    @Html.DropDownListFor(Function(m) m.OganisationId, New SelectList(Model.LesOrganisations, "Value", "Text"), Resource.ComboOrganisation,
           New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.TypeHopitauxCombo})
                                    @Html.ValidationMessageFor(Function(m) m.OganisationId, "", New With {.style = "color: #da0b0b"})
                                </div>


                            </div>

                            <div Class="form-group row">
                                @Html.LabelFor(Function(m) m.CommuneId, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4 form-group">
                                    @Html.DropDownListFor(Function(m) m.CommuneId, New SelectList(Model.LesCommunes, "Value", "Text"), Resource.CommuneCombo,
                  New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.CommuneCombo})
                                    @Html.ValidationMessageFor(Function(m) m.CommuneId, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.SurfaceDePisteId, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4 form-group">
                                    @Html.DropDownListFor(Function(m) m.SurfaceDePisteId, New SelectList(Model.LesSurfaceDePistes, "Value", "Text"), Resource.SurfaceDePisteCombo,
New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.SurfaceDePisteCombo})
                                    @Html.ValidationMessageFor(Function(m) m.SurfaceDePisteId, "", New With {.style = "color: #da0b0b"})
                                </div>

                            </div>

                            <div Class="form-group row">
                                @Html.LabelFor(Function(m) m.TailleDeAeronefId, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4 form-group">
                                    @Html.DropDownListFor(Function(m) m.TailleDeAeronefId, New SelectList(Model.LesTailleDeAeronefs, "Value", "Text"), Resource.TailleDeAeronefCombo,
New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.TailleDeAeronefCombo})
                                    @Html.ValidationMessageFor(Function(m) m.TailleDeAeronefId, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.UsageHumanitaireId, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4 form-group">
                                    @Html.DropDownListFor(Function(m) m.UsageHumanitaireId, New SelectList(Model.LesUsageHumanitaires, "Value", "Text"), Resource.UsageHumanitaireCombo,
New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.UsageHumanitaireCombo})
                                    @Html.ValidationMessageFor(Function(m) m.UsageHumanitaireId, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </div>

                            <div Class="form-group row">
                                @Html.LabelFor(Function(m) m.LongueurDePiste, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4">
                                    @Html.TextBoxFor(Function(m) m.LongueurDePiste, New With {.class = "form-control form-control-square ", .tabindex = "4", .Placeholder = Resource.LongueurDePistePlaceholder})
                                    @Html.ValidationMessageFor(Function(m) m.LongueurDePiste, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.LargeurDePiste, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4">
                                    @Html.TextBoxFor(Function(m) m.LargeurDePiste, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.LargeurDePistePlaceholder})
                                    @Html.ValidationMessageFor(Function(m) m.LargeurDePiste, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </div>

                            <div Class="form-group row">
                                @Html.LabelFor(Function(m) m.Telephone, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4">
                                    @Html.TextBoxFor(Function(m) m.Telephone, New With {.class = "form-control form-control-square ", .tabindex = "4", .Placeholder = Resource.TelephonePlaceholder})
                                    @Html.ValidationMessageFor(Function(m) m.Telephone, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.Telephone2, New With {.class = "col-sm-2 col-form-label"})
                                <div class="col-sm-4">
                                    @Html.TextBoxFor(Function(m) m.Telephone2, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.Telephone2Placeholder})
                                    @Html.ValidationMessageFor(Function(m) m.Telephone2, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </div>

                            <div Class="form-group row">
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

                            <div Class="form-group row">
                                <Label Class="col-sm-2 col-form-label"></Label>
                                <div Class="col-sm-10">
                                    <Button type="button" onclick="EditAeroport();" Class="btn btn-link btn-square bg-primary text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.BtnSave</Button>
                                    &nbsp;&nbsp;&nbsp;
                                    @Html.ActionLink(Resource.BtnCancel, "Index", Nothing, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                                </div>
                            </div>

                        </div>

                        <div id="tabe-2" class="container tab-pane fade">

                            <div Class="form-group row">
                                @Html.LabelFor(Function(m) m.MaterielAeroportId, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4 form-group">
                                    @Html.DropDownListFor(Function(m) m.MaterielAeroportId, New SelectList(Model.LesMaterielAeroport, "Value", "Text"), Resource.ComboMateriel,
New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboMateriel})
                                    @Html.ValidationMessageFor(Function(m) m.MaterielAeroportId, "", New With {.style = "color: #da0b0b"})
                                </div>
                                @Html.LabelFor(Function(m) m.Quantite, New With {.class = "col-sm-2 col-form-label required_field"})
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
                                    @For Each item In Model.MaterielAeroport
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
                    </div>
                </div>
            </div>
        </div>
    End Using
    </div>

    @Section Scripts

         <script>
    var oldLatitude = '@ViewBag.Latitude';
    var oldLongitude = '@ViewBag.Longitude';
    L.marker([oldLatitude, oldLongitude]).addTo(mymap)
        .bindPopup('<p><h6>' + 'Ancien emplacement : ' + '@Libelle.ToUpper()' + '</h6>. <br/><h6>Latitude: ' + oldLatitude + '</h6><br/><h6>Longitude: ' + oldLongitude + '</h6></p>')
        .openPopup();
    //$.alert('Longitude= ' + oldLongitude + ' Latitude= ' + oldLatitude);
        @*L.marker(['@Latitude', '@Longitude'])
            .bindPopup('<a href="' +'@Libelle' + '" target="_blank">' + '@Libelle' + '</a>')
            .addTo(mymap);*@

        @*$.alert('<a href="' +'@Libelle' + '" target="_blank">' + '@Libelle' + '</a>');*@
         </script>

        <script>
        var Latitude = oldLatitude.replace("." , ",");
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


            if (theMarker != undefined) {
                mymap.removeLayer(theMarker);
            };
            Longitude = lon;
            Latitude = lat;

            //Add a marker to show where you clicked.
            theMarker = L.marker([lat, lon]).addTo(mymap).bindPopup('<p><h6>' + 'Nouvel emplacement de : ' + $('#Nom').val() + '</h6>. <br/><h6>Latitude: ' + Latitude + '</h6><br/><h6>Longitude: ' + Longitude +'</h6></p>').openPopup();
            //theMarker = L.marker([lat, lon]).addTo(mymap).bindPopup("Nouvel emplacement de "+'@Libelle.ToUpper'+". Latitude: " + Latitude + " et Longitude: " + Longitude).openPopup();

        });


        function EditAeroport() {
            var Id = '#Id';
                var ICAO = '#ICAO';
                var IATA = '#IATA';
		        var Nom= '#Nom';
            var CommuneId = '#CommuneId';
                var OrganisationId = '#OganisationId';
                var SurfaceDePisteId = '#SurfaceDePisteId';
                var LongueurDePiste = '#LongueurDePiste';
                var LargeurDePiste = '#LargeurDePiste';
                var TailleDeAeronefId = '#TailleDeAeronefId';
                var UsageHumanitaireId = '#UsageHumanitaireId';
		        var Telephone= '#Telephone';
                var Telephone2 = '#Telephone2';
		        var SiteWeb= '#SiteWeb';
		        var Email= '#Email';
                //alert("You clicked the map at LAT: " + Latitude + " and LONG: " + Longitude);
                //alert("DateNaissance= " + DateNaissance);

            if (typeof $(ICAO).val() == "undefined" || $(ICAO).val() == "" || typeof $(Nom).val() == "undefined" || $(Nom).val() == "" || typeof $(CommuneId).val() == "undefined" || $(CommuneId).val() == "" ||typeof $(OrganisationId).val() == "undefined" || $(OrganisationId).val() == "" || typeof $(Telephone).val() == "undefined" || $(Telephone).val() == "" ) {
                    //alert("Veuillez renseigner tous les champs obligatoires.");
                    $.alert('"Veuillez renseigner tous les champs obligatoires."');
                }
                else if (Latitude == 0.0 || Longitude == 0.0 || typeof Latitude == "undefined" || typeof Longitude == "undefined" ) {
                    $.alert('"Veuillez sélectionner un emplacement sur la carte."');
		        }
		        else{

                    var dataRow = {
                        'Id': $(Id).val(),
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
                        url: '@Url.Action("EditAeroport", "Aeroport")',
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(dataRow),

                        // here we are get value of selected country and passing same value as inputto json method GetStates.

                        success: function (response) {
                            if (response.Result == "OK") {
                                window.location.href = '@Url.Action("Index", "Aeroport")';
                            }
                        },
                        error: function (theResponse) {
                            $.alert(theResponse.responseText);

                        }


                    });
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
