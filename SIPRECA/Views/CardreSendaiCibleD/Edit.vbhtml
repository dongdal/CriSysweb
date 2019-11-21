@ModelType SIPRECA.CardreSendaiCibleDViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewData("Title") = Resource.EditIndicateursCibleD
    Layout = "~/Views/Shared/_LayoutDesinventar.vbhtml"
End Code

<div class="page-header">
    <h1 class="page-title">@Resource.ManageEvenementZone</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "CardreSendaiCibleD")>@Resource.ManageEvenementZone</a></li>
        <li class="breadcrumb-item active">@Resource.EditIndicateursCibleD</li>
    </ol>
</div>


<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.EditIndicateursCibleD</div>
            <hr>
            @Using Html.BeginForm("Edit", "CardreSendaiCibleD", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()
                @Html.HiddenFor(Function(model) model.Id)
                @Html.HiddenFor(Function(model) model.AspNetUserId)
                @Html.HiddenFor(Function(model) model.StatutExistant)
                @Html.HiddenFor(Function(model) model.DateCreation)

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.EvenementZoneId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.EvenementZoneId, New SelectList(Model.LesEvenementsZone, "Value", "Text"), Resource.ComboEvenement,
        New With {.class = "form-control single-select", .tabindex = "1", .Placeholder = Resource.EvenementCombo})
                        @Html.ValidationMessageFor(Function(m) m.EvenementZoneId, "", New With {.style = "color: #da0b0b"})
                    </div>
                    <p style="text-indent: 25px; text-align:justify; font-style:italic; font-size: 10px; color: red">
                        Veuillez enregistrer dans cette section, les pertes économiques directes - Pertes agricoles , pertes dues aux dommages causés aux autres biens de production, aux infrastructures critiques et aux perturbations des services de base, entrez des chiffres désagrégés et
                        utilisez le bouton "<strong>Faire Somme</strong>" pour calculer la somme de chaque sous-groupe.
                    </p>
                </div>

                @<fieldset style="border:ridge;" Class="col-md-12">
                    <legend style="font-size: 14px">@Resource.DommagesPertesInfrastructuresCritiques </legend>
                    <div Class="form-group row">
                        <fieldset style="border:ridge;" Class="col-md-12">
                            <legend style="font-size: 14px">@Resource.DommagesPertesSecteurSante</legend>
                            <br />
                            <br />
                            <div Class="form-group row">
                                <div Class="col-md-4">
                                    @Html.LabelFor(Function(m) m.NombreTotaldesEtablissementDeSanteTouche, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreTotaldesEtablissementDeSanteTouche,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreTotaldesEtablissementDeSanteTouche, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>

                                <div Class="col-md-4">

                                    @Html.LabelFor(Function(m) m.NombreDesEtablissementsdeSanteEndommager, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreDesEtablissementsdeSanteEndommager,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreDesEtablissementsdeSanteEndommager, "", New With {.style = "color: #da0b0b"})
                                        &nbsp;&nbsp;&nbsp;
                                        <button onclick="SommeEtablissementDeSanteTouche();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
                                    </div>
                                </div>

                                <div Class="col-md-4">
                                    @Html.LabelFor(Function(m) m.NombreDesEtablissementsdeSantedetruits, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreDesEtablissementsdeSantedetruits,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "4", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreDesEtablissementsdeSantedetruits, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                    <br />
                                </div>

                            </div>

                        </fieldset>
                        <br />
                        <br />

                    </div>
                </fieldset>
                @<br />
                @<br />


                @<fieldset style="border:ridge;" Class="col-md-12">
                    <legend style="font-size: 14px">@Resource.DommagesPertesSecteurEducation </legend>
                    <div Class="form-group row">
                        <fieldset style="border:ridge;" Class="col-md-12">
                            <legend style="font-size: 14px">@Resource.PerteEconomiqueDommagesCausesEtablissementsEnseignement</legend>
                            <br />
                            <br />
                            <div Class="form-group row">
                                <div Class="col-md-4">
                                    @Html.LabelFor(Function(m) m.NombreTotaldesEtablissementEducationTouche, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreTotaldesEtablissementEducationTouche,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "5", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreTotaldesEtablissementEducationTouche, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>

                                <div Class="col-md-4">

                                    @Html.LabelFor(Function(m) m.NombreDesEtablissementsEducationEndommager, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreDesEtablissementsEducationEndommager,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "6", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreDesEtablissementsEducationEndommager, "", New With {.style = "color: #da0b0b"})
                                        &nbsp;&nbsp;&nbsp;
                                        <button onclick="SommeEtablissementEducationTouches();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
                                    </div>
                                </div>

                                <div Class="col-md-4">
                                    @Html.LabelFor(Function(m) m.NombreDesEtablissementsEducationDetruits, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreDesEtablissementsEducationDetruits,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "7", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreDesEtablissementsEducationDetruits, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                    <br />
                                </div>

                            </div>

                        </fieldset>
                        <br />
                        <br />

                    </div>
                </fieldset>
                @<br />
                @<br />

                @<fieldset style="border:ridge;" Class="col-md-12">
                    <legend style="font-size: 14px">@Resource.DommagesPertesCausesAutresInfrastructures </legend>
                    <div Class="form-group row">
                        <fieldset style="border:ridge;" Class="col-md-12">
                            <legend style="font-size: 14px">@Resource.PerteEconomiqueNombreInstallationsUnitesAutresInfrastructures </legend>
                            <br />
                            <br />
                            <div Class="form-group row">
                                <div Class="col-md-4">
                                    @Html.LabelFor(Function(m) m.NombreTotalAutreInfrastructureTouche, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreTotalAutreInfrastructureTouche,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "8", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreTotalAutreInfrastructureTouche, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>

                                <div Class="col-md-4">

                                    @Html.LabelFor(Function(m) m.NombreAutreInfrastructureEndommager, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreAutreInfrastructureEndommager,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "9", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreAutreInfrastructureEndommager, "", New With {.style = "color: #da0b0b"})
                                        &nbsp;&nbsp;&nbsp;
                                        <button onclick="SommeAutreInfrastructuresTouches();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
                                    </div>
                                </div>

                                <div Class="col-md-4">
                                    @Html.LabelFor(Function(m) m.NombreAutreInfrastructureDetruits, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreAutreInfrastructureDetruits,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "10", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreAutreInfrastructureDetruits, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                    <br />
                                </div>

                            </div>

                        </fieldset>
                        <br />
                        <br />

                    </div>
                </fieldset>
                @<br />
                @<br />

                @<fieldset style="border:ridge;" Class="col-md-12">
                    <legend style="font-size: 14px">@Resource.DommagesCausesAutresInfrastructures</legend>
                    <div Class="form-group row">
                        <fieldset style="border:ridge;" Class="col-md-12">
                            <legend style="font-size: 14px">@Resource.Disaggregation</legend>
                            <br />
                            <br />
                            <div Class="form-group row">
                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.PerteEconomiqueDuAuRoutes, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.PerteEconomiqueDuAuRoutes,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "11", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.PerteEconomiqueDuAuRoutes, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>

                                <div Class="col-md-3">

                                    @Html.LabelFor(Function(m) m.NombreTotalRoutesTouche, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreTotalRoutesTouche,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "12", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreTotalRoutesTouche, "", New With {.style = "color: #da0b0b"})
                                        &nbsp;&nbsp;&nbsp;
                                        <button onclick="SommeRoutesTouchees();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
                                    </div>
                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreRoutesEndommager, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreRoutesEndommager,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "13", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreRoutesEndommager, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                    <br />
                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreRoutesDetruits, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreRoutesDetruits,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "14", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreRoutesDetruits, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                    <br />
                                </div>

                            </div>

                        </fieldset>

                    </div>
                </fieldset>
                @<br />
                @<br />

                @<fieldset style="border:ridge;" Class="col-md-12">
                    <legend style="font-size: 14px">@Resource.InterruptionsServicesBase</legend>
                    <div Class="form-group row">

                        <fieldset style="border:ridge;" Class="col-md-12">
                            <legend style="font-size: 14px">@Resource.Disaggregation</legend>

                            <div Class="row">
                                @Html.LabelFor(Function(m) m.ServicesPubliqueId, New With {.class = "col-sm-3 col-form-label required_field"})
                                <div class="col-sm-4 form-group">
                                    @Html.DropDownListFor(Function(m) m.ServicesPubliqueId, New SelectList(Model.LesServicesPubliques, "Value", "Text"), Resource.ServicePubliqueCombo,
New With {.class = "form-control single-select", .tabindex = "15", .Placeholder = Resource.ServicePubliqueCombo})
                                    @Html.ValidationMessageFor(Function(m) m.ServicesPubliqueId, "", New With {.style = "color: #da0b0b"})
                                </div>
                                @*<button type="button" name="AddServicesPubliques" class="btn btn-round btn-primary waves-effect waves-light m-1"> @Resource.btn_Add</button>*@
                                <div class="col-sm-4 form-group">
                                    <button type="submit" name="AddServicesPubliques" class="btn btn-round bg-primary text-white shadow px-3"> @Resource.btn_Add</button>
                                </div>
                            </div>
                            <br />

                            <div Class="form-group row">
                                <table style="margin:10px;" id="default-datatable" class="table table-bordered dataTable" role="grid" aria-describedby="default-datatable_info">
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
                                        @For Each item In Model.CibleDServicesPublique
                                            @<tr>
                                                <td class="sorting_asc text-center">
                                                    @Html.DisplayFor(Function(modelItem) item.ServicesPubliquePertube.Libelle)
                                                </td>

                                                <td class="text-center">
                                                    <a class="btn btn-round btn-danger waves-effect waves-light m-1 DeleteServicesPublique" title="@Resource.Btn_Delete" href="javascript:void(0);" data-id="@item.Id">
                                                        <i class="fa fa-trash" aria-hidden="true"></i>
                                                    </a>
                                                </td>
                                            </tr>
                                        Next
                                    </tbody>

                                </table>

                            </div>

                        </fieldset>
                        <br />
                        <br />

                    </div>
                </fieldset>

                @<br />
                @<br />

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Source, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-10">
                        @Html.TextAreaFor(Function(m) m.Source, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.SourcePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Source, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<br />
                @<br />

                @<div Class="form-group row">

                    <Label Class="col-sm-1 col-form-label"></Label>
                    <div Class="col-sm-10">
                        <br />
                        <br />
                        <Button type="submit" Class="btn btn-link btn-square bg-warning text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.Btn_Edit</Button>
                        &nbsp;&nbsp;&nbsp;
                        @Html.ActionLink(Resource.BtnCancel, "Index", "EvenementZones", Nothing, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                    </div>
                </div>

            End Using

        </div>
    </div>
</div>

<script>

        $('.DeleteServicesPublique').click(function (e) {
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
                            url: '@Url.Action("DeleteServicesPublique")',
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
    var NombreTotaldesEtablissementDeSanteTouche = '#NombreTotaldesEtablissementDeSanteTouche';
    var NombreDesEtablissementsdeSanteEndommager = '#NombreDesEtablissementsdeSanteEndommager';
    var NombreDesEtablissementsdeSantedetruits = '#NombreDesEtablissementsdeSantedetruits';
    var totalEtablissementDeSanteTouche = null;

    var NombreTotaldesEtablissementEducationTouche = '#NombreTotaldesEtablissementEducationTouche';
    var NombreDesEtablissementsEducationEndommager = '#NombreDesEtablissementsEducationEndommager';
    var NombreDesEtablissementsEducationDetruits = '#NombreDesEtablissementsEducationDetruits';
    var totalEtablissementEducationTouches = null;

    var NombreTotalAutreInfrastructureTouche = '#NombreTotalAutreInfrastructureTouche';
    var NombreAutreInfrastructureEndommager = '#NombreAutreInfrastructureEndommager';
    var NombreAutreInfrastructureDetruits = '#NombreAutreInfrastructureDetruits';
    var totalAutresInfrastructuresTouches = null;

    var NombreTotalRoutesTouche = '#NombreTotalRoutesTouche';
    var NombreRoutesEndommager = '#NombreRoutesEndommager';
    var NombreRoutesDetruits = '#NombreRoutesDetruits';
    var totalRoutesTouchees = null;

    function SommeEtablissementDeSanteTouche() {
        initalisationPourEtablissementDeSanteTouche();
        var totalNombreTotaldesEtablissementDeSanteTouche = $(NombreTotaldesEtablissementDeSanteTouche).val();
        if (+totalEtablissementDeSanteTouche > 0) {
            if (+totalNombreTotaldesEtablissementDeSanteTouche > 0) {
                if (+totalNombreTotaldesEtablissementDeSanteTouche !== totalEtablissementDeSanteTouche) {
                    $.alert("Veuillez vous assurer que la somme des élements touchés et détruits donne le total entré en amont.");
                    document.getElementById("NombreTotaldesEtablissementDeSanteTouche").value = null;
                } else {
                    document.getElementById("NombreTotaldesEtablissementDeSanteTouche").value = totalNombreTotaldesEtablissementDeSanteTouche;
                }
            } else {
                document.getElementById("NombreTotaldesEtablissementDeSanteTouche").value = totalEtablissementDeSanteTouche;
            }
        }

    }

    function SommeEtablissementEducationTouches() {
        initalisationPourEtablissementEducationTouches();
        var totalNombreTotaldesEtablissementEducationTouche = $(NombreTotaldesEtablissementEducationTouche).val();
        if (+totalEtablissementEducationTouches > 0) {
            if (+totalNombreTotaldesEtablissementEducationTouche > 0) {
                if (+totalNombreTotaldesEtablissementEducationTouche !== totalEtablissementEducationTouches) {
                    $.alert("Veuillez vous assurer que la somme des élements touchés et détruits donne le total entré en amont.");
                    document.getElementById("NombreTotaldesEtablissementEducationTouche").value = null;
                } else {
                    document.getElementById("NombreTotaldesEtablissementEducationTouche").value = totalNombreTotaldesEtablissementEducationTouche;
                }
            } else {
                document.getElementById("NombreTotaldesEtablissementEducationTouche").value = totalEtablissementEducationTouches;
            }
        }

    }

    function SommeAutreInfrastructuresTouches() {
        initalisationPourAutreInfrastructuresTouches();
        var totalNombreTotalAutreInfrastructureTouche = $(NombreTotalAutreInfrastructureTouche).val();
        if (+totalAutresInfrastructuresTouches > 0) {
            if (+totalNombreTotalAutreInfrastructureTouche > 0) {
                if (+totalNombreTotalAutreInfrastructureTouche !== totalAutresInfrastructuresTouches) {
                    $.alert("Veuillez vous assurer que la somme des élements touchés et détruits donne le total entré en amont.");
                    document.getElementById("NombreTotalAutreInfrastructureTouche").value = null;
                } else {
                    document.getElementById("NombreTotalAutreInfrastructureTouche").value = totalNombreTotalAutreInfrastructureTouche;
                }
            } else {
                document.getElementById("NombreTotalAutreInfrastructureTouche").value = totalAutresInfrastructuresTouches;
            }
        }

    }

    function SommeRoutesTouchees() {
        initalisationPourRoutesTouches();
        var totalNombreTotalRoutesTouche = $(NombreTotalRoutesTouche).val();
        if (+totalRoutesTouchees > 0) {
            if (+totalNombreTotalRoutesTouche > 0) {
                if (+totalNombreTotalRoutesTouche !== totalRoutesTouchees) {
                    $.alert("Veuillez vous assurer que la somme des élements touchés et détruits donne le total entré en amont.");
                    document.getElementById("NombreTotalRoutesTouche").value = null;
                } else {
                    document.getElementById("NombreTotalRoutesTouche").value = totalNombreTotalRoutesTouche;
                }
            } else {
                document.getElementById("NombreTotalRoutesTouche").value = totalRoutesTouchees;
            }
        }

    }

    function initalisationPourEtablissementDeSanteTouche() {
        EtablissementsdeSanteEndommages = $(NombreDesEtablissementsdeSanteEndommager).val().replace(",", ".");
        EtablissementsdeSantedetruits = $(NombreDesEtablissementsdeSantedetruits).val().replace(",", ".");
        var arrayEtablissementsdeSanteTouches = [EtablissementsdeSanteEndommages, EtablissementsdeSantedetruits];
        totalEtablissementDeSanteTouche = checkItems(arrayEtablissementsdeSanteTouches);
    }

    function initalisationPourEtablissementEducationTouches() {
        EtablissementsEducationEndommages = $(NombreDesEtablissementsEducationEndommager).val().replace(",", ".");
        EtablissementsEducationdetruits = $(NombreDesEtablissementsEducationDetruits).val().replace(",", ".");
        var arrayEtablissementsEducationTouches = [EtablissementsEducationEndommages, EtablissementsEducationdetruits];
        totalEtablissementEducationTouches = checkItems(arrayEtablissementsEducationTouches);
    }

    function initalisationPourAutreInfrastructuresTouches() {

        AutresInfrastructuresEndommages = $(NombreAutreInfrastructureEndommager).val().replace(",", ".");
        AutresInfrastructuresdetruits = $(NombreAutreInfrastructureDetruits).val().replace(",", ".");
        var arrayAutresInfrastructuresTouches = [AutresInfrastructuresEndommages, AutresInfrastructuresdetruits];
        totalAutresInfrastructuresTouches = checkItems(arrayAutresInfrastructuresTouches);

    }

    function initalisationPourRoutesTouches() {

        RoutesToucheesEndommagees = $(NombreRoutesEndommager).val().replace(",", ".");
        RoutesToucheesdetruites = $(NombreRoutesDetruits).val().replace(",", ".");
        var arrayRoutesTouchees = [RoutesToucheesEndommagees, RoutesToucheesdetruites];
        totalRoutesTouchees = checkItems(arrayRoutesTouchees);

    }

    function checkItems(array) {
        var result = null;
        array.forEach(function (item) {
            if (item !== null && typeof (item) !== undefined) {
                result = (result === null) ? +item : (+result + +item);
            }
        });
        return result;
    }

</script>

