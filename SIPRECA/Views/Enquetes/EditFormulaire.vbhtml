@ModelType EnqueteViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.EditFormulaire
    Layout = "~/Views/Shared/_LayoutCollecte.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageEnquete</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Enquetes")>@Resource.ManageEnquete</a></li>
        <li class="breadcrumb-item active">@Resource.EditFormulaire</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">

            <div id="wizard-vertical">
                <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.EditFormulaire</div>
                <hr>
                @Using Html.BeginForm("EditFormulaire", "Enquetes", FormMethod.Post, New With {.autocomplete = "off"})
                    @Html.AntiForgeryToken()
                    @Html.ValidationSummary(True)
                    @Html.HiddenFor(Function(m) m.IdFormulaire)
                    @Html.HiddenFor(Function(m) m.StatutExistantFormulaire)
                    @Html.HiddenFor(Function(m) m.DateCreationFormulaire)
                    @Html.HiddenFor(Function(m) m.AspNetUserIdFormulaire)

                    @<div Class="form-group row">
                        @Html.LabelFor(Function(m) m.TitreFormulaire, New With {.class = "col-sm-2 col-form-label required_field"})
                        <div class="col-sm-4">
                            @Html.TextBoxFor(Function(m) m.TitreFormulaire, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.LibellePlaceholder, .required = "required"})
                            @Html.ValidationMessageFor(Function(m) m.TitreFormulaire, "", New With {.style = "color: #da0b0b"})
                        </div>

                        @Html.LabelFor(Function(m) m.EnqueteId, New With {.class = "col-sm-2 col-form-label required_field"})
                        <div class="col-sm-4 form-group">
                            @Html.DropDownListFor(Function(m) m.EnqueteId, New SelectList(Model.LesEnquetes, "Value", "Text"),
New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboSinistre, .required = "required"})
                            @Html.ValidationMessageFor(Function(m) m.EnqueteId, "", New With {.style = "color: #da0b0b"})
                        </div>
                    </div>


                    @<div Class="form-group row">
                        @Html.LabelFor(Function(m) m.DescriptionFormulaire, New With {.class = "col-sm-2 col-form-label "})
                        <div class="col-sm-10">
                            @Html.TextAreaFor(Function(m) m.DescriptionFormulaire, New With {.class = "form-control form-control-square", .tabindex = "3", .Placeholder = Resource.DescriptionPlaceholder})
                            @Html.ValidationMessageFor(Function(m) m.DescriptionFormulaire, "", New With {.style = "color: #da0b0b"})
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
