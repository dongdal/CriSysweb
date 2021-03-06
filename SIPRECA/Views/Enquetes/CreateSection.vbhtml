@ModelType EnqueteViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.CreateSection
    Layout = "~/Views/Shared/_LayoutCollecte.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageEnquete</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Enquetes")>@Resource.ManageEnquete</a></li>
        <li class="breadcrumb-item active">@Resource.CreateSection</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">

            <div id="wizard-vertical">
                <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.CreateSection</div>
                <hr>
                @Using Html.BeginForm("CreateSection", "Enquetes", FormMethod.Post, New With {.autocomplete = "off"})
                    @Html.AntiForgeryToken()

                    @<div Class="form-group row">
                        @Html.LabelFor(Function(m) m.TitreSection, New With {.class = "col-sm-2 col-form-label required_field"})
                        <div class="col-sm-4">
                            @Html.TextBoxFor(Function(m) m.TitreSection, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.LibellePlaceholder})
                            @Html.ValidationMessageFor(Function(m) m.TitreSection, "", New With {.style = "color: #da0b0b"})
                        </div>

                        @Html.LabelFor(Function(m) m.FormulaireId, New With {.class = "col-sm-2 col-form-label required_field"})
                        <div class="col-sm-4 form-group">
                            @Html.DropDownListFor(Function(m) m.FormulaireId, New SelectList(Model.LesFormulaires, "Value", "Text"),
New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboEnquete, .required = "required"})
                            @Html.ValidationMessageFor(Function(m) m.FormulaireId, "", New With {.style = "color: #da0b0b"})
                        </div>
                    </div>


                    @<div Class="form-group row">
                        @Html.LabelFor(Function(m) m.DescriptionSection, New With {.class = "col-sm-2 col-form-label "})
                        <div class="col-sm-4">
                            @Html.TextAreaFor(Function(m) m.DescriptionSection, New With {.class = "form-control form-control-square", .tabindex = "3", .Placeholder = Resource.DescriptionPlaceholder})
                            @Html.ValidationMessageFor(Function(m) m.DescriptionSection, "", New With {.style = "color: #da0b0b"})
                        </div>
                        <div class="col-sm-4">
                            <Button type="submit" name="BtnSave" Class="btn btn-round btn-success waves-effect waves-light m-1"> @Resource.btn_Add </Button>
                        </div>

                    </div>

                    @<table id="ListeSection" Class="table table-bordered dataTable" role="grid" aria-describedby="default-datatable_info">
                        <thead>
                            <tr>

                                <th Class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                    @Resource.Titre
                                </th>
                                <th Class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                    @Resource.FormulaireId
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
                            @For Each item In Model.ListeSections
                                @<tr>
                                    <td class="sorting_asc text-center">
                                        @Html.DisplayFor(Function(modelItem) item.Titre)
                                    </td>
                                    <td class="sorting_asc text-center">
                                        @Html.DisplayFor(Function(modelItem) item.Formulaire.Titre)
                                    </td>
                                    <td class="sorting_asc text-center">
                                        @Html.DisplayFor(Function(modelItem) item.Description)
                                    </td>
                                    <td class="text-center">

                                        <a class="btn btn-round btn-warning waves-effect waves-light m-1" title="@Resource.Btn_Edit" href="@Url.Action("EditSection", New With {.IdSection = item.Id})">
                                            <i class="fa fa-pencil" aria-hidden="true"></i>
                                        </a>

                                        <a class="btn btn-round btn-danger waves-effect waves-light m-1 DeleteSection" title="@Resource.Btn_Delete" href="javascript:void(0);" data-id="@item.Id">
                                            <i class="fa fa-trash" aria-hidden="true"></i>
                                        </a>
                                        @*<a class="btn btn-round btn-danger waves-effect waves-light m-1" title="@Resource.Btn_Delete" href="@Url.Action("DeleteSection", New With {.id = item.Id, .IndemnisationId = Model.Id})">
            <i class="fa fa-trash" aria-hidden="true"></i>
        </a>*@
                                    </td>
                                </tr>
                            Next
                        </tbody>

                    </table>

                    @<br />
                    @<br />


                    @<div Class="form-group row">
                        <Label Class="col-sm-4 col-form-label"></Label>
                        <div Class="col-sm-5">
                            <Button type="submit" name="BtnPrevious" Class="btn btn-link btn-square bg-white text-dark shadow px-5" @*style="color: white !important"*@> <i Class="icon-arrow-left"></i> @Resource.btn_Previous </Button>
                            &nbsp;&nbsp;&nbsp;
                            <Button type="submit" name="BtnNext" Class="btn btn-link btn-square bg-primary text-dark shadow px-5" @*style="color: white !important"*@> @Resource.btn_Next <i Class="icon-arrow-right"></i></Button>
                        </div>
                    </div>

                End Using

            </div>
        </div>
    </div>
</div>

@Section Scripts
    <script>

        $('.DeleteSection').click(function (e) {
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
                            url: '@Url.Action("DeleteSection")',
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