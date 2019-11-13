@ModelType ZoneARisqueViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.EditZoneARisque
    Layout = "~/Views/Shared/_LayoutDesinventar.vbhtml"
    Dim Libelle = Model.Libelle
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageZoneARisque</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "ZoneARisques")>@Resource.ManageZoneARisque</a></li>
        <li class="breadcrumb-item active">@Resource.EditZoneARisque</li>
    </ol>
</div>

<div class="container-fluid">
    <h6 class="text-uppercase">@Resource.EditZoneARisque</h6>
    <hr>
    @Using Html.BeginForm("Edit", "ZoneARisques", FormMethod.Post, New With {.autocomplete = "off"})
        @Html.AntiForgeryToken()
        @Html.HiddenFor(Function(m) m.Id)
        @Html.HiddenFor(Function(m) m.StatutExistant)
        @Html.HiddenFor(Function(m) m.DateCreation)
        @Html.HiddenFor(Function(m) m.AspNetUserId)
        @<div class="row">
            <div class="col-lg-12">
                <div Class="card">
                    <div Class="card-body">
                        <ul class="nav nav-tabs nav-tabs-primary">
                            <li class="nav-item">
                                <a class="nav-link active" data-toggle="tab" href="#tabe-1"><i class="icon-home"></i> <span class="hidden-xs">@Resource.TabZoneARisque</span></a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" data-toggle="tab" href="#tabe-2"><i class="icon-location-pin"></i> <span class="hidden-xs">@Resource.TabLocalisation</span></a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" data-toggle="tab" href="#tabe-3"><i class="icon-event"></i> <span class="hidden-xs">@Resource.TabRisques</span></a>
                            </li>
                        </ul>
                        <div class="tab-content">
                            <div id="tabe-1" class="container tab-pane active">

                                <div Class="form-group row">
                                    @Html.LabelFor(Function(m) m.Libelle, New With {.class = "col-sm-2 col-form-label required_field"})
                                    <div class="col-sm-4">
                                        @Html.TextBoxFor(Function(m) m.Libelle, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.LibellePlaceholder})
                                        @Html.ValidationMessageFor(Function(m) m.Libelle, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                </div>

                                @Html.Partial("_MyMapEnterPartial")

                                <div Class="form-group row">
                                    <Label Class="col-sm-2 col-form-label"></Label>
                                    <div Class="col-sm-10">
                                        <Button type="button" onclick="EditZoneARisque();" Class="btn btn-link btn-square bg-warning text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.Btn_Edit</Button>
                                        &nbsp;&nbsp;&nbsp;
                                        @Html.ActionLink(Resource.BtnCancel, "Index", Nothing, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                                    </div>
                                </div>
                            </div>

                            <div id="tabe-2" class="container tab-pane fade">

                                <div Class="form-group row">
                                    @Html.LabelFor(Function(m) m.QuartierId, New With {.class = "col-sm-2 col-form-label required_field"})
                                    <div class="col-sm-4 form-group">
                                        @Html.DropDownListFor(Function(m) m.QuartierId, New SelectList(Model.LesQuartiers, "Value", "Text"), Resource.ComboQuartier,
New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboQuartier})
                                        @Html.ValidationMessageFor(Function(m) m.QuartierId, "", New With {.style = "color: #da0b0b"})
                                    </div>


                                </div>
                                <div Class="form-group row">
                                    <Label Class="col-sm-2 col-form-label"></Label>
                                    <div Class="col-sm-10">
                                        <input type="submit" value="@Resource.BtnSave" name="AddQuartier" class="btn btn-primary btn-sm" />
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
                                                @Resource.ActionList
                                            </th>
                                        </tr>
                                    </thead>

                                    <tbody>
                                        @For Each item In Model.ZoneLocalisations
                                            @<tr>

                                                <td>
                                                    @item.Quartier.Libelle
                                                </td>
                                                <td>
                                                    <a class="btn btn-round btn-danger waves-effect waves-light m-1 DeleteQuartier" title="@Resource.Btn_Delete" href="javascript:void(0);" data-id="@item.Id">
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
                                    @Html.LabelFor(Function(m) m.RisqueId, New With {.class = "col-sm-2 col-form-label required_field"})
                                    <div class="col-sm-4 form-group">
                                        @Html.DropDownListFor(Function(m) m.RisqueId, New SelectList(Model.LesRisques, "Value", "Text"), Resource.RisqueCombo,
New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.RisqueCombo})
                                        @Html.ValidationMessageFor(Function(m) m.RisqueId, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                    @Html.LabelFor(Function(m) m.NiveauDAlertId, New With {.class = "col-sm-2 col-form-label required_field"})
                                    <div class="col-sm-4 form-group">
                                        @Html.DropDownListFor(Function(m) m.NiveauDAlertId, New SelectList(Model.LesNiveauDAlerts, "Value", "Text"), Resource.NiveauDAlertCombo,
New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.NiveauDAlertCombo})
                                        @Html.ValidationMessageFor(Function(m) m.NiveauDAlertId, "", New With {.style = "color: #da0b0b"})
                                    </div>


                                </div>
                                <div Class="form-group row">
                                    <Label Class="col-sm-2 col-form-label"></Label>
                                    <div Class="col-sm-10">
                                        <input type="submit" value="@Resource.BtnSave" name="AddRisqueZone" class="btn btn-primary btn-sm" />
                                    </div>
                                </div>
                                <br />

                                <table id="zero_config" class="table table-striped table-bordered">
                                    <thead>
                                        <tr>

                                            <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                                @Resource.Risque
                                            </th>

                                            <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                                @Resource.NiveauDAlert
                                            </th>

                                            <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                                @Resource.ActionList
                                            </th>
                                        </tr>
                                    </thead>

                                    <tbody>
                                        @For Each item In Model.RisqueZones
                                            @<tr>

                                                <td>
                                                    @item.Risque.Libelle
                                                </td>
                                                <td>
                                                    @item.NiveauDAlert.Libelle
                                                </td>
                                                <td>
                                                    <a class="btn btn-round btn-danger waves-effect waves-light m-1 DeleteRisqueZone" title="@Resource.Btn_Delete" href="javascript:void(0);" data-id="@item.Id">
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


        function EditZoneARisque() {
                var Id = '#Id';
                var Libelle = '#Libelle';
		        

                //alert("You clicked the map at LAT: " + Latitude + " and LONG: " + Longitude);
                //alert("DateNaissance= " + DateNaissance);

            if (typeof $(Libelle).val() == "undefined" || $(Libelle).val() == "") {
                    //alert("Veuillez renseigner tous les champs obligatoires.");
                    $.alert('"Veuillez renseigner tous les champs obligatoires."');
                }
                else if (Latitude == 0.0 || Longitude == 0.0 || typeof Latitude == "undefined" || typeof Longitude == "undefined" ) {
                    $.alert('"Veuillez sélectionner un emplacement sur la carte."');
		        }
		        else{

                    var dataRow = {
                        'Id': $(Id).val(),
                        'Libelle': $(Libelle).val(),
                        'Latitude': Latitude,
                        'Longitude': Longitude
                    }

                    //alert("c'est moi le createPatient avant ajax");

                    $.ajax({
                        type: 'POST',
                        url: '@Url.Action("EditZoneARisque", "ZoneARisques")',
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(dataRow),

                        // here we are get value of selected country and passing same value as inputto json method GetStates.

                        success: function (response) {
                            if (response.Result == "OK") {
                                window.location.href = '@Url.Action("Index", "ZoneARisques")';
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

        $('.DeleteQuartier').click(function (e) {
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
                            url: '@Url.Action("DeleteQuartier")',
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


        $('.DeleteRisqueZone').click(function (e) {
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
                            url: '@Url.Action("DeleteRisqueZone")',
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