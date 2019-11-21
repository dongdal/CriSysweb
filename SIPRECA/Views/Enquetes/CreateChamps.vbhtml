@ModelType EnqueteViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.CreateChamps
    Layout = "~/Views/Shared/_LayoutCollecte.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageEnquete</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Enquetes")>@Resource.ManageEnquete</a></li>
        <li class="breadcrumb-item active">@Resource.CreateChamps</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">

            <div id="wizard-vertical">
                <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.CreateChamps</div>
                <hr>
                @Using Html.BeginForm("CreateChamps", "Enquetes", FormMethod.Post, New With {.autocomplete = "off"})
                    @Html.AntiForgeryToken()
                    @Html.ValidationSummary(True)
                    @Html.HiddenFor(Function(m) m.FormulaireId)
                    @Html.Hidden("PropositionViewModel.Libelle", "Libelle")

                    @<div Class="form-group row">
                        @Html.LabelFor(Function(m) m.SectionId, New With {.class = "col-sm-2 col-form-label required_field"})
                        <div class="col-sm-4 form-group">
                            @Html.DropDownListFor(Function(m) m.SectionId, New SelectList(Model.LesSections, "Value", "Text"), Resource.ComboSection,
                          New With {.class = "form-control single-select", .tabindex = "1", .Placeholder = Resource.ComboSection})
                            @Html.ValidationMessageFor(Function(m) m.SectionId, "", New With {.style = "color: #da0b0b"})
                        </div>

                        @Html.LabelFor(Function(m) m.TypeChampsId, New With {.class = "col-sm-2 col-form-label required_field"})
                        <div class="col-sm-4 form-group">
                            @Html.DropDownListFor(Function(m) m.TypeChampsId, New SelectList(Model.LesTypeChamps, "Value", "Text"), Resource.TypeChampsCombo,
                          New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.TypeChampsCombo})
                            @Html.ValidationMessageFor(Function(m) m.TypeChampsId, "", New With {.style = "color: #da0b0b"})
                        </div>

                    </div>


                    @<div Class="form-group row">
                        @Html.LabelFor(Function(m) m.TitreChamps, New With {.class = "col-sm-2 col-form-label required_field"})
                        <div class="col-sm-4">
                            @Html.TextBoxFor(Function(m) m.TitreChamps, New With {.class = "form-control form-control-square", .tabindex = "3", .Placeholder = Resource.LibellePlaceholder})
                            @Html.ValidationMessageFor(Function(m) m.TitreChamps, "", New With {.style = "color: #da0b0b"})
                        </div>

                        @Html.LabelFor(Function(m) m.DescriptionSection, New With {.class = "col-sm-2 col-form-label "})
                        <div class="col-sm-4">
                            @Html.TextAreaFor(Function(m) m.DescriptionSection, New With {.class = "form-control form-control-square", .tabindex = "4", .Placeholder = Resource.DescriptionPlaceholder})
                            @Html.ValidationMessageFor(Function(m) m.DescriptionSection, "", New With {.style = "color: #da0b0b"})
                        </div>

                    </div>

                    @<div Class="form-group row">
                        <div class="col-sm-12">
                            <Label Class="col-sm-5 col-form-label"></Label>
                            <Button type="submit" name="BtnSave" Class="col-sm-1 btn btn-round btn-success waves-effect waves-light m-1"> @Resource.btn_Add </Button>
                            <Label Class="col-sm-4 col-form-label"></Label>
                        </div>
                    </div>

                    @<table id="ListeChamps" style="font-size: 10px" class="table table-responsive table-bordered dataTable " role="grid" aria-describedby="default-datatable_info">
                        <thead>
                            <tr>

                                <th Class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                    @Resource.Titre
                                </th>
                                <th Class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                    @Resource.TypeChampsId
                                </th>
                                <th Class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                    @Resource.SectionId
                                </th>
                                <th Class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                    Propositions
                                </th>
                                <th Class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                    @Resource.ActionList
                                </th>
                            </tr>
                        </thead>

                        <tbody>
                            @For Each item In Model.ListeChamps
                                @<tr>
                                    <td class="sorting_asc text-left">
                                        @Html.DisplayFor(Function(modelItem) item.Titre)
                                    </td>
                                    <td class="sorting_asc text-left">
                                        @Html.DisplayFor(Function(modelItem) item.TypeChamps.Libelle)
                                    </td>
                                    <td class="sorting_asc text-left">
                                        @Html.DisplayFor(Function(modelItem) item.Section.Titre)
                                    </td>
                                    <td class="sorting_asc text-left" style="color: darkblue; font-weight:bold">
                                        @For Each prop In item.Proposition
                                            @<i class="fa fa-caret-right"></i> @Html.DisplayFor(Function(modelProp) prop.Libelle)
                                            @<br />
                                        Next
                                    </td>
                                    <td class="text-center">
                                        <a class="btn btn-round btn-success waves-effect waves-light m-1" title="@Resource.btn_Add Proposition" href="#" data-toggle="modal" data-target="#Proposition_@item.Id">
                                            <i class="fa fa-plus" aria-hidden="true"></i>
                                        </a>
                                        @*<a class="btn btn-round btn-danger waves-effect waves-light m-1" title="@Resource.Btn_Delete" href="@Url.Action("DeleteChamps", New With {.id = item.Id})">
                                                <i class="fa fa-trash" aria-hidden="true"></i>
                                            </a>*@
                                        <a class="btn btn-round btn-danger waves-effect waves-light m-1 DeleteChamps" title="@Resource.Btn_Delete" href="javascript:void(0);" data-id="@item.Id">
                                            <i class="fa fa-trash" aria-hidden="true"></i>
                                        </a>


                                        <!--Primary Modal -->
                                        <div class="modal fade" id="Proposition_@item.Id">
                                            <div Class="modal-dialog modal-lg">
                                                @Using Html.BeginForm()
                                                    @*New With {.role = "form", .id = "__AjaxAntiForgeryForm_" & item.Id}*@
                                                    @*@Html.AntiForgeryToken()*@
                                                    @Html.ValidationSummary(True)
                                                    @Html.Hidden("ChampsId_" & item.Id, item.Id)

                                                    @<div class="modal-content border-primary">
                                                        <div class="modal-header bg-primary">
                                                            <h5 class="modal-title text-white"><i class="fa fa-save"></i> @Resource.CreateProposition</h5>
                                                            <button type="button" class="close text-white" data-dismiss="modal" aria-label="Close">
                                                                <span aria-hidden="true">&times;</span>
                                                            </button>
                                                        </div>
                                                        <div class="modal-body">

                                                            <div Class="form-group row">
                                                                @Html.LabelFor(Function(model) model.PropositionViewModel.Libelle, New With {.class = "col-sm-2 col-form-label required_field", .for = "Libelle_" & item.Id})
                                                                <div class="col-sm-10">
                                                                    @Html.TextBoxFor(Function(model) model.PropositionViewModel.Libelle, New With {.class = "form-control form-control-square", .tabindex = "1",
.Placeholder = Resource.LibellePlaceholder, .id = "Libelle_" & item.Id})
                                                                    @Html.ValidationMessageFor(Function(model) model.PropositionViewModel.Libelle, "", New With {.style = "color: #da0b0b", .data_valmsg_for = "Libelle_" & item.Id})
                                                                </div>


                                                            </div>

                                                        </div>
                                                        <div class="modal-footer">
                                                            <button type="button" class="btn btn-primary" onclick="CreatePoposition($('#Libelle_@item.Id').val(), $('#ChampsId_@item.Id').val());">
                                                                <i class="fa fa-check-square-o"></i> @Resource.BtnValidate
                                                            </button>
                                                            <button type="button" class="btn btn-inverse-primary" data-dismiss="modal"><i class="fa fa-times"></i> @Resource.BtnClose</button>
                                                        </div>
                                                    </div>
                                                End Using
                                            </div>
                                        </div>

                                        <!--End Modal -->

                                    </td>
                                </tr>
                            Next
                        </tbody>

                    </table>

                    @<br />
                    @<br />


                    @<div Class="form-group row">
                        <Label Class="col-sm-5 col-form-label"></Label>
                        <div Class="col-sm-4">
                            <Button type="submit" name="BtnPrevious" Class="btn btn-link btn-square bg-white text-dark shadow px-5" @*style="color: white !important"*@> <i Class="icon-arrow-left"></i> @Resource.btn_Previous </Button>
                            &nbsp;&nbsp;&nbsp;
                            @Html.ActionLink(Resource.Btn_Terminer, "Index", Nothing, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                        </div>
                    </div>

                End Using

            </div>
        </div>
    </div>
</div>
@Section Scripts

    <script>
        function CreatePoposition(Libelle, ChampsId) {
            //var preForm ='#__AjaxAntiForgeryForm_' + ChampsId;
            //alert("Libelle= " + Libelle);
            //alert("ChampsId= " + ChampsId);

        if (typeof Libelle == "undefined" || Libelle == "" || typeof ChampsId == "undefined" || ChampsId == "" ) {
            //alert("Veuillez renseigner tous les champs obligatoires.");
            $.alert('"Veuillez renseigner tous les champs obligatoires."');

        } else {

            //var form = $(preForm);
            //var token = $('input[name="__RequestVerificationToken_' + ChampsId +' "]', form).val();
            var dataRow = {
                'Libelle': Libelle,
                'ChampsId': ChampsId
            }

            //    data: {
            //    __RequestVerificationToken: token,
            //        Libelle: Libelle,
            //            ChampsId: ChampsId
            //},
            //alert("c'est moi le createPatient avant ajax");

            $.ajax({
                type: 'POST',
                url: '@Url.Action("CreatePoposition")',
                dataType: "json",
                contentType: "application/json",
                data: JSON.stringify(dataRow),


                // here we are get value of selected country and passing same value as inputto json method GetStates.

                success: function (response) {
                            if (response.Result == "OK") {

                                //$.alert(response.Result);
                                window.location.href = '@Url.Action("CreateChamps", New With {.FormulaireId = ViewBag.FormulaireId})';
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
        //document.getElementById('PatientViewModel_Nom').value = "";
        //document.getElementById('PatientViewModel_Sexe').value = "";
        //document.getElementById('PatientViewModel_DateNaissance_dt_1').value = "";

        //document.getElementById("PatientViewModel_DateNaissance_dt_1").style.zIndex = "100";
        ////document.getElementById("PatientViewModel_DateDelivranceCNI_dt_1").style.zIndex = "100";
        ////document.getElementById("PatientViewModel_DateExpirationCNI_dt_1").style.zIndex = "100";
        //document.getElementById("DateFin_dt_1").style.zIndex = "2000";
        //document.getElementById("DateDebut_dt_1").style.zIndex = "2000";

        //ModalClose('myModal');
    }
    </script>

    <script>

        $('.DeleteChamps').click(function (e) {
            e.preventDefault();
            var $ctrl = $(this);
            var Id = $(this).data("id");
            //$.alert("Identifiant= " + Id);
            $.confirm({
                title: '@Resource.Btn_Delete',
                content: '@Resource.ConfirmDeleteBis',
                animationSpeed: 1000,
                animationBounce: 3,
                animation: 'rotatey',
                closeAnimation: 'scaley',
                theme: 'supervan',
                buttons: {
                    Confirmer: function () {
                        $.ajax({
                            url: '@Url.Action("DeleteChamps")',
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