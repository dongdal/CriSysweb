@ModelType EnqueteViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.EditSection
    Layout = "~/Views/Shared/_LayoutCollecte.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageEnquete</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Enquetes")>@Resource.ManageEnquete</a></li>
        <li class="breadcrumb-item active">@Resource.EditSection</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">

            <div id="wizard-vertical">
                <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.EditSection</div>
                <hr>
                @Using Html.BeginForm("EditSection", "Enquetes", FormMethod.Post, New With {.autocomplete = "off"})
                    @Html.AntiForgeryToken()
                    @Html.ValidationSummary(True)
                    @Html.HiddenFor(Function(m) m.IdSection)
                    @Html.HiddenFor(Function(m) m.StatutExistantSection)
                    @Html.HiddenFor(Function(m) m.DateCreationSection)
                    @Html.HiddenFor(Function(m) m.AspNetUserIdSection)


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