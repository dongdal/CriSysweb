@ModelType BureauViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.EditBureau
End Code

<div class="page-header">
    <h1 class="page-title">@Resource.ManageBureau</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Bureaux")>@Resource.ManageBureau</a></li>
        <li class="breadcrumb-item active">@Resource.EditBureau</li>
    </ol>
</div>

<div class="container-fluid">
    <h6 class="text-uppercase">@Resource.EditBureau</h6>
    <hr>
    @Using Html.BeginForm("Edit", "Bureaux", FormMethod.Post, New With {.autocomplete = "off"})
        @Html.AntiForgeryToken()
        @Html.HiddenFor(Function(m) m.Id)
        @Html.HiddenFor(Function(m) m.StatutExistant)
        @Html.HiddenFor(Function(m) m.DateCreation)
        @Html.HiddenFor(Function(m) m.AspNetUserId)

        @<div Class="col-lg-12">
            <div Class="card">
                <div Class="card-body">
                    <ul Class="nav nav-tabs nav-tabs-primary">
                        <li Class="nav-item">
                            <a Class="nav-link active" data-toggle="tab" href="#tabe-1"><i class="icon-home"></i> <span class="hidden-xs">Projet</span></a>
                        </li>
                        <li Class="nav-item">
                            <a Class="nav-link" data-toggle="tab" href="#tabe-2"><i class="icon-user"></i> <span class="hidden-xs">Personnels Bureau</span></a>
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
                                        @Html.TextBoxFor(Function(m) m.Nom, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.NamePlaceholder})
                                        @Html.ValidationMessageFor(Function(m) m.Nom, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                </div>

                                <div Class="form-group row">
                                    @Html.LabelFor(Function(m) m.TypeOfficeId, New With {.class = "col-sm-2 col-form-label required_field"})
                                    <div class="col-sm-4 form-group">
                                        @Html.DropDownListFor(Function(m) m.TypeOfficeId, New SelectList(Model.LesTypeOffices, "Value", "Text"), Resource.TypeOfficeCombo,
         New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.TypeOfficeCombo})
                                        @Html.ValidationMessageFor(Function(m) m.TypeOfficeId, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                    @Html.LabelFor(Function(m) m.OrganisationId, New With {.class = "col-sm-2 col-form-label required_field"})
                                    <div class="col-sm-4 form-group">
                                        @Html.DropDownListFor(Function(m) m.OrganisationId, New SelectList(Model.LesOrganisations, "Value", "Text"), Resource.ComboOrganisation,
                         New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboOrganisation})
                                        @Html.ValidationMessageFor(Function(m) m.OrganisationId, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>

                                <div Class="form-group row">
                                    @Html.LabelFor(Function(m) m.VilleId, New With {.class = "col-sm-2 col-form-label required_field"})
                                    <div class="col-sm-4 form-group">
                                        @Html.DropDownListFor(Function(m) m.VilleId, New SelectList(Model.LesVilles, "Value", "Text"), Resource.VilleCombo,
         New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.VilleCombo})
                                        @Html.ValidationMessageFor(Function(m) m.VilleId, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                    @Html.LabelFor(Function(m) m.CodePostale, New With {.class = "col-sm-2 col-form-label required_field"})
                                    <div class="col-sm-4">
                                        @Html.TextBoxFor(Function(m) m.CodePostale, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.CodePostalePlaceholder})
                                        @Html.ValidationMessageFor(Function(m) m.CodePostale, "", New With {.style = "color: #da0b0b"})
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

                                    @Html.LabelFor(Function(m) m.Email, New With {.class = "col-sm-2 col-form-label"})
                                    <div class="col-sm-10">
                                        @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.EmailPlaceholder})
                                        @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.style = "color: #da0b0b"})
                                    </div>


                                    @Html.Partial("_MyMapEnterPartial")

                                    <div Class="form-group row">
                                        <Label Class="col-sm-2 col-form-label"></Label>
                                        <div Class="col-sm-10">
                                            <Button type="submit" onclick="CreateBureaux();" Class="btn btn-link btn-square bg-primary text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.BtnSave</Button>
                                            &nbsp;&nbsp;&nbsp;
                                            @Html.ActionLink(Resource.BtnCancel, "Index", Nothing, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                                        </div>
                                    </div>
                                </div>
                           
                            </div>
                            <div id="tabe-2" class="container tab-pane fade">

                                <div Class="form-group row">
                                    @Html.LabelFor(Function(m) m.PersonnelBureauxId, New With {.class = "col-sm-2 col-form-label required_field"})
                                    <div class="col-sm-4 form-group">
                                        @Html.DropDownListFor(Function(m) m.PersonnelBureauxId, New SelectList(Model.LesPersonnelBureaux, "Value", "Text"), Resource.ComboPersonnel,
                         New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboPersonnel})
                                        @Html.ValidationMessageFor(Function(m) m.PersonnelBureauxId, "", New With {.style = "color: #da0b0b"})
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
                                        @For Each item In Model.PersonnelBureaux
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
                        </div>
                </div>
            </div>
        </div>

    End Using

</div>

@Section Scripts

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

End Section                