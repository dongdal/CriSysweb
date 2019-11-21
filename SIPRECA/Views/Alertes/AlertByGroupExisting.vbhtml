@ModelType AlertesViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.ManageAlertCreate
    Layout = "~/Views/Shared/_LayoutAlertes.vbhtml"
End Code


<div class="page-header">
    <h1 class="page-title">@Resource.ManageAlert</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("IndexAlertes", "Home")>@Resource.ManageAlert</a></li>
        <li class="breadcrumb-item active">@Resource.ManageAlertCreate</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.ManageAlertCreate</div>
            <hr>
            @Using Html.BeginForm("AlertByGroupExisting", "Alertes", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.OrganisationId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.OrganisationId, New SelectList(Model.LesOrganisations, "Value", "Text"), Resource.ComboOrganisation,
New With {.class = "form-control single-select", .tabindex = "1", .Placeholder = Resource.ComboOrganisation})
                        @Html.ValidationMessageFor(Function(m) m.OrganisationId, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.TypeSinistreId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.TypeSinistreId, New SelectList(Model.LesTypeSinistre, "Value", "Text"), Resource.ComboTypeSinistre,
       New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboTypeSinistre})
                        @Html.ValidationMessageFor(Function(m) m.TypeSinistreId, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>


                @<div Class="form-group row">

                    @Html.LabelFor(Function(m) m.SinistreId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.SinistreId, New SelectList(Model.LesSinistres, "Value", "Text"), Resource.ComboSinistre,
              New With {.class = "form-control single-select", .tabindex = "3", .Placeholder = Resource.ComboSinistre})
                        @Html.ValidationMessageFor(Function(m) m.SinistreId, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.CommuneId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.CommuneId, New SelectList(Model.LesCommunes, "Value", "Text"), Resource.CommuneCombo,
New With {.class = "form-control multiple-select", .tabindex = "4", .Placeholder = Resource.CommuneCombo, .multiple = "multiple"})
                        @Html.ValidationMessageFor(Function(m) m.CommuneId, "", New With {.style = "color: #da0b0b"})
                    </div>

                </div>


                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Contenu, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-10">
                        @Html.TextAreaFor(Function(m) m.Contenu, New With {.class = "form-control form-control-square ", .tabindex = "4", .Placeholder = Resource.ContenuPlaceholde, .maxlength = 100})
                        @Html.ValidationMessageFor(Function(m) m.Contenu, "", New With {.style = "color: #da0b0b"})
                    </div>

                </div>

                @<div Class="form-group row">
                    <Label Class="col-sm-2 col-form-label"></Label>
                    <div Class="col-sm-10">
                        <Button type="submit" Class="btn btn-link btn-square bg-primary text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.BtnSave</Button>
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
        //alert("Le niveau sélectionné = " + $(cboPereId).val());
    var cboTypeSinistreId = '#TypeSinistreId ';
    var cboSinistreId = '#SinistreId';
    var cboCommuneId = '#CommuneId';
        var url = '';
        var MsgCombo = '@Resource.SinistreCombo';
        //Dropdownlist Selectedchange event
    $(cboTypeSinistreId).change(function () {
        url = '@Url.Action("SinistreByTypeSinistre")';
        $(cboSinistreId).empty();
        if ($(cboTypeSinistreId).val()) {

                    $.ajax({
                        type: 'POST',
                        url: url, // we are calling json method
                        dataType: 'json',
                        data: { TypeSinistreId: $(cboTypeSinistreId).val() },
                        // here we are get value of selected country and passing same value as inputto json method GetStates.

                        success: function (sinistre) {
                            // states contains the JSON formatted list
                            // of states passed from the controller

                            $(cboSinistreId).append('<option value="">' + MsgCombo + '</option>'); // ici on met d'abord unn premier elt vide
                            $.each(sinistre, function (i, sinistre) {
                                $(cboSinistreId).append('<option value="' + sinistre.Value + '">' + sinistre.Text + '</option>');
                                // here we are adding option for States

                            });
                        },
                        error: function (ex) {
                            //alert('Failed to retrieve states.' + ex);
                        }
                    });
                } else {
            $(cboSinistreId).append('<option value="">@Resource.SinistreCombo</option>');
                };

            return false;
    })

        
        //Dropdownlist Selectedchange event
        $(cboSinistreId).change(function () {
        url = '@Url.Action("CommuneBySinistre")';
        $(cboCommuneId).empty();
        if ($(cboSinistreId).val()) {
                    $.ajax({
                        type: 'POST',
                        url: url, // we are calling json method
                        dataType: 'json',
                        data: { SinistreId: $(cboSinistreId).val() },
                        // here we are get value of selected country and passing same value as inputto json method GetStates.

                        success: function (commune) {
                            // states contains the JSON formatted list
                            // of states passed from the controller

                            $(cboCommuneId).append('<option value="">' + MsgCombo + '</option>'); // ici on met d'abord unn premier elt vide
                            $.each(commune, function (i, commune) {
                                $(cboCommuneId).append('<option value="' + commune.Value + '">' + commune.Text + '</option>');
                                // here we are adding option for States

                            });
                        },
                        error: function (ex) {
                            //alert('Failed to retrieve states.' + ex);
                        }
                    });
                } else {
            $(cboCommuneId).append('<option value="">@Resource.CommuneCombo</option>');
                };

            return false;
        })

    </script>

End Section