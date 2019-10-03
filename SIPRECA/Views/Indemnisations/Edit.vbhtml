@ModelType IndemnisationViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.EditIndemnisation
    Layout = "~/Views/Shared/_LayoutSahana.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.EditIndemnisation</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Indemnisations")>@Resource.ManageIndemnisation</a></li>
        <li class="breadcrumb-item active">@Resource.EditIndemnisation</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.EditIndemnisation</div>
            <hr>
            @Using Html.BeginForm("Edit", "Indemnisations", FormMethod.Post, New With {.enctype = "multipart/form-data"})
                @Html.AntiForgeryToken()
                @Html.HiddenFor(Function(m) m.Id)
                @Html.HiddenFor(Function(m) m.StatutExistant)
                @Html.HiddenFor(Function(m) m.DateCreation)
                @Html.HiddenFor(Function(m) m.AspNetUserId)
                @Html.HiddenFor(Function(m) m.Description)

                @<div Class="form-group row">

                    @Html.LabelFor(Function(m) m.DemandeId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.DemandeId, New SelectList(Model.LesDemande, "Value", "Text"), Resource.ComboDemande,
            New With {.class = "form-control single-select", .tabindex = "1", .Placeholder = Resource.ComboDemande})
                        @Html.ValidationMessageFor(Function(m) m.DemandeId, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Libelle, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Libelle, New With {.class = "form-control form-control-square", .tabindex = "2", .Placeholder = Resource.LibellePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Libelle, "", New With {.style = "color: #da0b0b"})
                    </div>

                </div>

                @<div Class="form-group row">

                    @Html.LabelFor(Function(m) m.NatureAideId, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.NatureAideId, New SelectList(Model.LesNatureAides, "Value", "Text"), Resource.NatureAideCombo,
                                                          New With {.class = "form-control single-select", .tabindex = "4", .Placeholder = Resource.NatureAideCombo})
                        @Html.ValidationMessageFor(Function(m) m.NatureAideId, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Quantite, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4 form-group">
                        <div class="input-group bootstrap-touchspin">
                            @Html.TextBoxFor(Function(m) m.Quantite, New With {.class = "form-control form-control-square number", .tabindex = "5", .Placeholder = Resource.Quantite})
                            @Html.ValidationMessageFor(Function(m) m.Quantite, "", New With {.style = "color: #da0b0b"})
                        </div>
                    </div>

                </div>


                @<div Class="form-group row">

                    @Html.LabelFor(Function(m) m.DescriptionAide, New With {.class = "col-sm-2 col-form-label "})
                    <div class="col-sm-4">
                        @Html.TextAreaFor(Function(m) m.DescriptionAide, New With {.class = "form-control form-control-square", .tabindex = "4", .Placeholder = Resource.DescriptionPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.DescriptionAide, "", New With {.style = "color: #da0b0b"})
                    </div>


                    @Html.Label(" ", New With {.class = "col-sm-2 col-form-label "})
                    <div class="col-sm-4 form-group">
                        @If Not (Model.StatutExistant = Util.ElementsSuiviDemandes.DecisionIndemnisation) Then
                            @<Button type="submit" name="AddDetailsIndemnisation" Class="btn btn-link btn-round bg-purple text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.AddItem</Button>
                        End If

                    </div>
                </div>

                @<table id="DetailsIndemnisation" Class="table table-bordered dataTable" role="grid" aria-describedby="default-datatable_info">
                    <thead>
                        <tr>

                            <th Class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                @Resource.NatureAide
                            </th>
                            <th Class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                @Resource.Quantite
                            </th>
                            <th Class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                @Resource.Description
                            </th>
                            <th Class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                @Resource.ActionList
                            </th>
                        </tr>
                    </thead>

                    <tbody>
                        @For Each item In Model.DetailsIndemnisation
                            @<tr>
                                <td class="sorting_asc text-center">
                                    @Html.DisplayFor(Function(modelItem) item.NatureAide.Libelle)
                                </td>
                                <td class="sorting_asc text-center">
                                    @Html.DisplayFor(Function(modelItem) item.Quantite)
                                </td>
                                <td class="sorting_asc text-center">
                                    @Html.DisplayFor(Function(modelItem) item.Description)
                                </td>
                                <td class="text-center">
                                    <a class="btn btn-round btn-danger waves-effect waves-light m-1" title="@Resource.Btn_Delete" href="@Url.Action("DeleteDetails", New With {.id = item.Id, .IndemnisationId = Model.Id})">
                                        <i class="fa fa-trash" aria-hidden="true"></i>
                                    </a>
                                </td>
                            </tr>
                        Next
                    </tbody>

                </table>
                @<br />

                @<div Class="form-group row">
                    <Label Class="col-sm-2 col-form-label"></Label>
                    <div Class="col-sm-10">
                        <Button type="button" onclick="validation()" Class="btn btn-link btn-square bg-warning text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.Btn_Edit</Button>
                        &nbsp;&nbsp;&nbsp;
                        @Html.ActionLink(Resource.BtnCancel, "Index", "Demandes", Nothing, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                    </div>
                </div>

                '<!--End Row-->
            End Using

        </div>
    </div>
</div>


@Section Scripts

    <script>

        function validation()
        {

            var DetailsIndemnisationId='@ViewBag.DetailsIndemnisation';
            //$.alert("Identifiant= " + Type);
            $.confirm({
                title: '@Resource.ValiderModification',
                content: '@Resource.ConfirmModification',
                animationSpeed: 1000,
                animationBounce: 3,
                animation: 'rotatey',
                closeAnimation: 'scaley',
                theme: 'supervan',
                buttons: {
                    Confirmer: function () {
                        $.ajax({
                            url: '@Url.Action("Indemnisation")',
                            type: 'POST',
                            data: { DetailsIndemnisationId: DetailsIndemnisationId}
                        }).done(function (data) {
                            if (data.Result == "OK") {
                                //$ctrl.closest('li').remove();
                                $.confirm({
                                    title: '@Resource.SuccessTitle',
                                    content: '@Resource.SuccessValidation',
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
                            content: '@Resource.CancelingIndemnisation',
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
        }

    </script>

End Section