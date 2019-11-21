@ModelType AbrisViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.EditAbris
            Layout = "~/Views/Shared/_LayoutSahana.vbhtml"
            Dim Libelle = Model.Nom
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageAbris</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Abris")>@Resource.ManageAbris</a></li>
        <li class="breadcrumb-item active">@Resource.EditAbris</li>
    </ol>
</div>

<div class="container-fluid">
    <h6 class="text-uppercase">@Resource.EditAbris</h6>
    <hr>
    @Using Html.BeginForm("Edit", "Abris", FormMethod.Post, New With {.autocomplete = "off"})
        @Html.AntiForgeryToken()
        @Html.HiddenFor(Function(m) m.Id)
        @Html.HiddenFor(Function(m) m.StatutExistant)
        @Html.HiddenFor(Function(m) m.DateCreation)
        @Html.HiddenFor(Function(m) m.AspNetUserId)
        @Html.HiddenFor(Function(m) m.AspNetUserId)

        @<div Class="col-lg-12">
            <div Class="card">
                <div Class="card-body">
                    <ul Class="nav nav-tabs nav-tabs-primary">
                        <li Class="nav-item">
                            <a Class="nav-link active" data-toggle="tab" href="#tabe-1"><i class="icon-home"></i> <span class="hidden-xs">@Resource.Abris</span></a>
                        </li>
                        <li Class="nav-item">
                            <a Class="nav-link" data-toggle="tab" href="#tabe-2"><i class="icon-user"></i> <span class="hidden-xs">@Resource.PersonnelAbris</span></a>
                        </li>
                        <li Class="nav-item">
                            <a Class="nav-link" data-toggle="tab" href="#tabe-3"><i class="icon-wallet"></i> <span class="hidden-xs">@Resource.Materiel</span></a>
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

                                @Html.LabelFor(Function(m) m.TypeAbrisId, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4 form-group">
                                    @Html.DropDownListFor(Function(m) m.TypeAbrisId, New SelectList(Model.LesTypeAbris, "Value", "Text"), Resource.TypeAbrisCombo,
                               New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.TypeAbrisCombo})
                                    @Html.ValidationMessageFor(Function(m) m.TypeAbrisId, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </div>


                            <div Class="form-group row">

                                @Html.LabelFor(Function(m) m.OrganisationId, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4 form-group">
                                    @Html.DropDownListFor(Function(m) m.OrganisationId, New SelectList(Model.LesOrganisations, "Value", "Text"), Resource.ComboOrganisation,
                                         New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboOrganisation})
                                    @Html.ValidationMessageFor(Function(m) m.OrganisationId, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.CommuneId, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4 form-group">
                                    @Html.DropDownListFor(Function(m) m.CommuneId, New SelectList(Model.LesCommunes, "Value", "Text"), Resource.CommuneCombo,
                     New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.CommuneCombo})
                                    @Html.ValidationMessageFor(Function(m) m.CommuneId, "", New With {.style = "color: #da0b0b"})
                                </div>

                            </div>


                            <div Class="form-group row">
                                @Html.LabelFor(Function(m) m.EstimationPopulation, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4">
                                    @Html.TextBoxFor(Function(m) m.EstimationPopulation, New With {.class = "form-control form-control-square ", .tabindex = "4", .Placeholder = Resource.EstimationPopulationPlaceholder})
                                    @Html.ValidationMessageFor(Function(m) m.EstimationPopulation, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.Capacite, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4">
                                    @Html.TextBoxFor(Function(m) m.Capacite, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.CapacitePlaceholder})
                                    @Html.ValidationMessageFor(Function(m) m.Capacite, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </div>


                            @Html.Partial("_MyMapEnterPartial")

                            <div Class="form-group row">
                                <Label Class="col-sm-2 col-form-label"></Label>
                                <div Class="col-sm-10">
                                    <Button type="button" onclick="EditAbris();" Class="btn btn-link btn-square bg-primary text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.BtnSave</Button>
                                    &nbsp;&nbsp;&nbsp;
                                    @Html.ActionLink(Resource.BtnCancel, "Index", Nothing, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                                </div>
                            </div>

                        </div>

                        <div id="tabe-2" class="container tab-pane fade">


                            <div Class="form-group row">
                                @Html.LabelFor(Function(m) m.PersonnelAbrisId, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4 form-group">
                                    @Html.DropDownListFor(Function(m) m.PersonnelAbrisId, New SelectList(Model.LesPersonnelAbris, "Value", "Text"), Resource.ComboPersonnel,
New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboPersonnel})
                                    @Html.ValidationMessageFor(Function(m) m.PersonnelAbrisId, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.TitreDuPoste, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4">
                                    @Html.TextBoxFor(Function(m) m.TitreDuPoste, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.TitreDuPostePlaceholder})
                                    @Html.ValidationMessageFor(Function(m) m.TitreDuPoste, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </div>
                            <div Class="form-group row">
                                <Label Class="col-sm-2 col-form-label"></Label>
                                <div Class="col-sm-10">
                                    <input type="submit" value="@Resource.BtnSave" name="AddPersonnel" class="btn btn-primary btn-sm" />
                                </div>
                            </div>
                            <br />

                            <table id="zero_config" class="table table-striped table-bordered">
                                <thead>
                                    <tr>

                                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                            @Resource.Nom
                                        </th>
                                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                            @Resource.Prenom
                                        </th>
                                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                            @Resource.Sexe
                                        </th>
                                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                            @Resource.TitreDuPoste
                                        </th>
                                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                            @Resource.Organisation
                                        </th>
                                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                            @Resource.ActionList
                                        </th>
                                    </tr>
                                </thead>

                                <tbody>
                                    @For Each item In Model.PersonnelAbris
                                        @<tr>

                                            <td>
                                                @item.Personnel.Nom
                                            </td>

                                            <td class="text-center">

                                                @item.Personnel.Prenom

                                            </td>

                                            <td class="text-center">

                                                @item.Personnel.Sexe

                                            </td>

                                            <td class="text-center">

                                                @item.TitreDuPoste

                                            </td>

                                            <td class="text-center">

                                                @item.Personnel.Oganisation.Nom

                                            </td>

                                            <td>
                                                <a class="btn btn-round btn-danger waves-effect waves-light m-1 DeletePersonnel" title="@Resource.Btn_Delete" href="javascript:void(0);" data-id="@item.Id">
                                                    <i class="fa fa-trash" aria-hidden="true"></i>
                                                </a>
                                            </td>
                                        </tr>
                                    Next
                                </tbody>

                            </table>
                        </div>

                        <div id="tabe-3" class="container tab-pane fade">

                            <div Class="form-group row">
                                @Html.LabelFor(Function(m) m.MaterielAbrisId, New With {.class = "col-sm-2 col-form-label required_field"})
                                <div class="col-sm-4 form-group">
                                    @Html.DropDownListFor(Function(m) m.MaterielAbrisId, New SelectList(Model.LesMaterielAbris, "Value", "Text"), Resource.ComboMateriel,
New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboMateriel})
                                    @Html.ValidationMessageFor(Function(m) m.MaterielAbrisId, "", New With {.style = "color: #da0b0b"})
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
                                    @For Each item In Model.MaterielAbris
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


        function EditAbris() {
                var Id = '#Id';
		        var Nom= '#Nom';
            var CommuneId = '#CommuneId';
                var TypeAbrisId = '#TypeAbrisId';
                var OrganisationId = '#OrganisationId';
                var EstimationPopulation = '#EstimationPopulation';
                var Capacite = '#Capacite';
                
                //alert("You clicked the map at LAT: " + Latitude + " and LONG: " + Longitude);
                //alert("DateNaissance= " + DateNaissance);

            if (typeof $(Nom).val() == "undefined" || $(Nom).val() == "" || typeof $(CommuneId).val() == "undefined" || $(CommuneId).val() == "" || typeof $(TypeAbrisId).val() == "undefined" || $(TypeAbrisId).val() == "") {
                    //alert("Veuillez renseigner tous les champs obligatoires.");
                    $.alert('"Veuillez renseigner tous les champs obligatoires."');
                }
                else if (Latitude == 0.0 || Longitude == 0.0 || typeof Latitude == "undefined" || typeof Longitude == "undefined" ) {
                    $.alert('"Veuillez sélectionner un emplacement sur la carte."');
		        }
		        else{

                    var dataRow = {
                        'Id': $(Id).val(),
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
                        url: '@Url.Action("EditAbris", "Abris")',
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(dataRow),

                        // here we are get value of selected country and passing same value as inputto json method GetStates.

                        success: function (response) {
                            if (response.Result == "OK") {
                                window.location.href = '@Url.Action("Index", "Abris")';
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

        $('.DeletePersonnel').click(function (e) {
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
                            url: '@Url.Action("DeletePersonnel")',
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