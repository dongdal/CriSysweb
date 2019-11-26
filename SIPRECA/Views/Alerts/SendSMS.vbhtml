@ModelType SMSAlertesViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.SendSMS
    Layout = "~/Views/Shared/_LayoutAlertes.vbhtml"
End Code


<div class="page-header">
    <h1 class="page-title">@Resource.ManageAlert</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("IndexAlertes", "Home")>@Resource.ManageAlert</a></li>
        <li class="breadcrumb-item active">@Resource.SendSMS</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.SendSMS</div>
            <hr>
            @Using Html.BeginForm("SendSMS", "Alerts", FormMethod.Post, New With {.autocomplete = "off", .id = "__AjaxAntiForgeryForm"})
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
                        @Html.TextAreaFor(Function(m) m.Contenu, New With {.class = "form-control form-control-square ", .tabindex = "4",
         .Placeholder = Resource.ContenuPlaceholde, .maxlength = 100, .onkeyup = "LimtCharacters(this,100,'lblcount');"})
                        <label id="lblcount" style="background-color:#E2EEF1;color:Red;font-weight:bold;">100</label>
                        @Html.ValidationMessageFor(Function(m) m.Contenu, "", New With {.style = "color: #da0b0b"})
                    </div>

                </div>

                @<div Class="form-group row">
                    <Label Class="col-sm-2 col-form-label"></Label>
                    <div Class="col-sm-10">
                        <Button type="button" onclick="SendingSMS();" Class="btn btn-primary waves-effect waves-light m-1">
                            <i Class="icon-send"></i>  <i class="fa fa-send"></i> <span>
                                @Resource.SendMessage
                            </span>
                        </Button>
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
        function SendingSMS() {
        var OrganisationId = '#OrganisationId';
        var TypeSinistreId = '#TypeSinistreId';
        var SinistreId = '#SinistreId';
        var CommuneId = '#CommuneId';
        var Contenu = '#Contenu';
        //var ListOfCommuneString = $(CommuneId).val();
        //var ListOfCommuneArray = ListOfCommuneString.toString().split(",");

        var form = $('#__AjaxAntiForgeryForm');
        var token = $('input[name="__RequestVerificationToken"]', form).val();

        $.ajax({
            type: 'POST',
            url: '@Url.Action("SendSMS")',
            dataType: "json",
            async: true,
            data: {
                __RequestVerificationToken: token,
                OrganisationId: $(OrganisationId).val(),
                TypeSinistreId: $(TypeSinistreId).val(),
                SinistreId: $(SinistreId).val(),
                CommuneId: $(CommuneId).val(),
                Contenu: $(Contenu).val()
            },
            //data: JSON.stringify(dataRow),

        // here we are get value of selected country and passing same value as inputto json method GetStates.

        success: function (response) {
        if (response.Result == "OK") {
            $.confirm({
                title: '@Resource.SuccessAlertTitle!',
                content: '@Resource.SendMailSucces',
                icon: 'fa fa-check',
                type: 'green',
                buttons: {
                    omg: {
                        text: '@Resource.BtnClose',
                        btnClass: 'btn-green',
                    },
                    close: function () {
                    }
                }
            });
        //$.alert(response.Result);
        @*window.location.href = '@Url.Action("Index", "Aeroport")';*@
        }
        else {
            $.confirm({
                title: '@Resource.ErreurTitle',
                content: '@Resource.SendingError',
                icon: 'fa fa-warning',
                type: 'red',
                buttons: {
                omg: {
                    text: '@Resource.BtnClose',
                    btnClass: 'btn-red',
                    },
                    close: function () {
                    }
                }
            });
            }
        },
        error: function (theResponse) {
        $.alert(theResponse.responseText);

        }


        });
}

    </script>
    <script>
        function LimtCharacters(txtMsg, CharLength, indicator) {
            chars = txtMsg.value.length;
            document.getElementById(indicator).innerHTML = CharLength - chars;
            if (chars > CharLength) {
                txtMsg.value = txtMsg.value.substring(0, CharLength);
            }
        }

        $(function () {
            $('#Contenu').keyup(function (e) {
                var max = 100;
                var len = $(this).val().length;
                var char = max - len;
                $('#text-counter').html(char);
            });
        });
    </script>

    <script>
        //alert("Le niveau sélectionné = " + $(cboPereId).val());
    var cboTypeSinistreId = '#TypeSinistreId ';
    var cboSinistreId = '#SinistreId';
    var cboCommuneId = '#CommuneId';
        var url = '';
        var MsgCombo = '@Resource.ComboSinistre';
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
            $(cboSinistreId).append('<option value="">@Resource.ComboSinistre</option>');
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