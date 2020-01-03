@ModelType RegisterViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.Register
    Layout = "~/Views/Shared/_LayoutParam.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.Menu_UserManager</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Account")>@Resource.Menu_UserManager</a></li>
        <li class="breadcrumb-item active">@Resource.RegisterUser</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.RegisterForm</div>
            <hr>
            @Using Html.BeginForm("Register", "Account", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Nom, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Nom, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.NamePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Nom, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Prenom, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Prenom, New With {.class = "form-control form-control-square", .tabindex = "2", .Placeholder = Resource.PrenomPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Prenom, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.DateNaissance, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.DateNaissance, New With {.class = "form-control form-control-square default-datepicker", .tabindex = "3", .Placeholder = Resource.DateNaissancePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.DateNaissance, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.LieuNaissance, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.LieuNaissance, New With {.class = "form-control form-control-square", .tabindex = "4", .Placeholder = Resource.LieuNaissancePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.LieuNaissance, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @*@Html.LabelFor(Function(m) m.Sexe, New With {.class = "col-sm-2 col-form-label"})
                        <div class="col-sm-4">
                            @Html.TextBoxFor(Function(m) m.Sexe, New With {.class = "form-control form-control-square", .tabindex = "5"})
                            @Html.ValidationMessageFor(Function(m) m.Sexe)
                        </div>*@
                    @Html.LabelFor(Function(m) m.Sexe, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-md-4">
                        <div class="icheck-material-dark icheck-inline">
                            @Html.RadioButtonFor(Function(m) m.Sexe, "Male", New With {.id = "Male", .checked = "checked"})
                            @Html.Label(Resource.GenderMale, New With {.for = "Male", .tabindex = "6"})
                        </div>
                        <div class="icheck-material-dark icheck-inline">
                            @Html.RadioButtonFor(Function(m) m.Sexe, "Female", New With {.id = "Female"})
                            @Html.Label(Resource.GenderFemale, New With {.for = "Female", .tabindex = "7"})
                        </div>
                    </div>

                    @Html.LabelFor(Function(m) m.CNI, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.CNI, New With {.class = "form-control form-control-square", .tabindex = "8", .Placeholder = Resource.CNIPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.CNI, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.DateDelivranceCNI, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.DateDelivranceCNI, New With {.class = "form-control form-control-square default-datepicker", .tabindex = "9", .Placeholder = Resource.DelivranceCNIPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.DateDelivranceCNI, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.DateExpirationCNI, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.DateExpirationCNI, New With {.class = "form-control form-control-square default-datepicker", .tabindex = "10", .Placeholder = Resource.ExpirationCNIPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.DateExpirationCNI, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Telephone, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Telephone, New With {.class = "form-control form-control-square", .tabindex = "11", .Placeholder = Resource.Telephone1Placeholder})
                        @Html.ValidationMessageFor(Function(m) m.Telephone, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Telephone2, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Telephone2, New With {.class = "form-control form-control-square", .tabindex = "12", .Placeholder = Resource.Telephone2Placeholder})
                        @Html.ValidationMessageFor(Function(m) m.Telephone2, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Email, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control form-control-square", .tabindex = "13", .Placeholder = Resource.EmailPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.AdresseUser, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextAreaFor(Function(m) m.AdresseUser, New With {.class = "form-control form-control-square", .tabindex = "14", .Placeholder = Resource.AdressePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.AdresseUser, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.UserName, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.UserName, New With {.class = "form-control form-control-square", .tabindex = "15", .Placeholder = Resource.UserNamePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.UserName, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Password, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control form-control-square", .tabindex = "16", .Placeholder = Resource.PasswordPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Password, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">

                    @Html.LabelFor(Function(m) m.ConfirmPassword, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.PasswordFor(Function(m) m.ConfirmPassword, New With {.class = "form-control form-control-square", .tabindex = "17", .Placeholder = Resource.ConfirmPasswordPlacehoder})
                        @Html.ValidationMessageFor(Function(m) m.ConfirmPassword, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Niveau, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.Niveau, New SelectList(Model.LesNiveaux, "Value", "Text"), Resource.NiveauCombo,
          New With {.class = "form-control", .tabindex = "18", .Placeholder = Resource.NiveauCombo})
                        @Html.ValidationMessageFor(Function(m) m.Niveau, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row" style="display: none" id="CommuneDiv">

                    @Html.LabelFor(Function(m) m.CommuneId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.CommuneId, New SelectList(Model.LesCommunes, "Value", "Text"), Resource.CommuneCombo,
                                                     New With {.class = "form-control single-select", .tabindex = "19", .Placeholder = Resource.CommuneCombo})
                        @Html.ValidationMessageFor(Function(m) m.CommuneId, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>
                @<div Class="form-group row" style="display: none" id="DepartementDiv">
                    @Html.LabelFor(Function(m) m.DepartementId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.DepartementId, New SelectList(Model.Departements, "Value", "Text"), Resource.ComboDepartement,
                             New With {.class = "form-control single-select", .tabindex = "20", .Placeholder = Resource.ComboDepartement})
                        @Html.ValidationMessageFor(Function(m) m.DepartementId, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>
                @<div Class="form-group row" style="display: none" id="RegionDiv">
                    @Html.LabelFor(Function(m) m.RegionId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.RegionId, New SelectList(Model.Regions, "Value", "Text"), Resource.ComboRegion,
                          New With {.class = "form-control single-select", .tabindex = "21", .Placeholder = Resource.ComboRegion})
                        @Html.ValidationMessageFor(Function(m) m.RegionId, "", New With {.style = "color: #da0b0b"})
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
        var cboPereId = '#Niveau';
        var cboFilsId = '';
        var CommuneDiv = 'CommuneDiv';
        var DepartementDiv = 'DepartementDiv';
        var RegionDiv = 'RegionDiv';
        var url = '';
        var MsgCombo = '';
        //Dropdownlist Selectedchange event
        $(cboPereId).change(function () {
            //alert("Le niveau sélectionné = " + $(cboPereId).val());
            var Niveau = $(cboPereId).val();
            if (Niveau == 1) {
                document.getElementById(CommuneDiv).style.display = '';
                document.getElementById(DepartementDiv).style.display = 'none';
                document.getElementById(RegionDiv).style.display = 'none';
                url = '@Url.Action("LoadCommunes")';
                cboFilsId = "#CommuneId";
                MsgCombo = '@Resource.CommuneCombo';
            }
            else if (Niveau == 2) {
                document.getElementById(CommuneDiv).style.display = 'none';
                document.getElementById(DepartementDiv).style.display = '';
                document.getElementById(RegionDiv).style.display = 'none';
                url = '@Url.Action("LoadDepartements")';
                cboFilsId = "#DepartementId";
                MsgCombo = '@Resource.ComboDepartement';
            }
            else if (Niveau == 3) {
                document.getElementById(CommuneDiv).style.display = 'none';
                document.getElementById(DepartementDiv).style.display = 'none';
                document.getElementById(RegionDiv).style.display = '';
                url = '@Url.Action("LoadRegions")';
                cboFilsId = "#RegionId";
                MsgCombo = '@Resource.ComboRegion';
            }
            else {
                document.getElementById(CommuneDiv).style.display = 'none';
                document.getElementById(DepartementDiv).style.display = 'none';
                document.getElementById(RegionDiv).style.display = 'none';
                MsgCombo = '';
            }
            //document.getElementById(CommuneDiv).style.display = (Niveau == 1) ? '' : 'none';
            if (Niveau == 1 || Niveau == 2 || Niveau == 3) {
                $(cboFilsId).empty();
                if ($(cboPereId).val()) {

                    $.ajax({
                        type: 'POST',
                        url: url, // we are calling json method

                        dataType: 'json',

                        data: {},
                        // here we are get value of selected country and passing same value as inputto json method GetStates.

                        success: function (states) {
                            // states contains the JSON formatted list
                            // of states passed from the controller

                            $(cboFilsId).append('<option value="">' + MsgCombo + '</option>'); // ici on met d'abord unn premier elt vide
                            $.each(states, function (i, state) {
                                $(cboFilsId).append('<option value="' + state.Value + '">' + state.Text + '</option>');
                                // here we are adding option for States

                            });
                        },
                        error: function (ex) {
                            //alert('Failed to retrieve states.' + ex);
                        }
                    });
                } else {
                    $(cboFilsId).append('<option value="">@Resource.NiveauAutre</option>');
                };
            }

            return false;
        })
    </script>
End Section