@ModelType EnqueteViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.CreateEnquete
    Layout = "~/Views/Shared/_LayoutCollecte.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageEnquete</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Enquetes")>@Resource.ManageEnquete</a></li>
        <li class="breadcrumb-item active">@Resource.CreateEnquete</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">

            <div id="wizard-vertical">
                <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.CreateEnquete</div>
                <hr>
                @Using Html.BeginForm("Create", "Enquetes", FormMethod.Post, New With {.autocomplete = "off"})
                    @Html.AntiForgeryToken()

                    @<div Class="form-group row">
                        @Html.LabelFor(Function(m) m.Titre, New With {.class = "col-sm-2 col-form-label required_field"})
                        <div class="col-sm-4">
                            @Html.TextBoxFor(Function(m) m.Titre, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.LibellePlaceholder, .required = "required"})
                            @Html.ValidationMessageFor(Function(m) m.Titre, "", New With {.style = "color: #da0b0b"})
                        </div>

                        @Html.LabelFor(Function(m) m.SinistreId, New With {.class = "col-sm-2 col-form-label required_field"})
                        <div class="col-sm-4 form-group">
                            @Html.DropDownListFor(Function(m) m.SinistreId, New SelectList(Model.LesSinistres, "Value", "Text"), Resource.ComboSinistre,
New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboSinistre, .required = "required"})
                            @Html.ValidationMessageFor(Function(m) m.SinistreId, "", New With {.style = "color: #da0b0b"})
                        </div>
                    </div>


                    @<div Class="form-group row">
                        @Html.LabelFor(Function(m) m.Description, New With {.class = "col-sm-2 col-form-label "})
                        <div class="col-sm-10">
                            @Html.TextAreaFor(Function(m) m.Description, New With {.class = "form-control form-control-square", .tabindex = "3", .Placeholder = Resource.DescriptionPlaceholder})
                            @Html.ValidationMessageFor(Function(m) m.Description, "", New With {.style = "color: #da0b0b"})
                        </div>


                    </div>



                    @<div Class="form-group row">
                        <Label Class="col-sm-4 col-form-label"></Label>
                        <div Class="col-sm-5">
                            @Html.ActionLink(Resource.BtnCancel, "Index", Nothing, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                            &nbsp;&nbsp;&nbsp;
                            <Button type="submit" Class="btn btn-link btn-square bg-primary text-dark shadow px-5" @*style="color: white !important"*@> @Resource.btn_Next <i Class="icon-arrow-right"></i></Button>
                        </div>
                    </div>

                End Using

            </div>
        </div>
    </div>
</div>
