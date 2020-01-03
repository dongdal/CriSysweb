@ModelType MailAlertesViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.SendMailDetails
    Layout = "~/Views/Shared/_LayoutAlertes.vbhtml"
End Code


<div class="page-header">
    <h1 class="page-title">@Resource.ManageAlert</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("IndexAlertes", "Home")>@Resource.ManageAlert</a></li>
        <li class="breadcrumb-item active">@Resource.SendMailDetails</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.SendMailDetails</div>
            <hr>
            @*@Using Html.BeginForm("SendMailDetails", "Alerts", FormMethod.Post, New With {.autocomplete = "off", .id = "__AjaxAntiForgeryForm"})
                @Html.AntiForgeryToken()*@

            <div Class="form-group row">
                @Html.Label("OrganisationId", Resource.Organisation, New With {.class = "col-sm-2 col-form-label"})
                <div class="col-sm-4">
                    @Html.TextBoxFor(Function(m) m.Organisation.Nom, New With {.class = "form-control form-control-square", .readonly = "true", .tabindex = "1"})
                </div>

                @Html.Label("SinistreId", Resource.SinistreConcernes, New With {.class = "col-sm-2 col-form-label"})
                <div class="col-sm-4">
                    @Html.TextBoxFor(Function(m) m.Sinistre.Libelle, New With {.class = "form-control form-control-square", .readonly = "true", .tabindex = "2"})
                </div>
            </div>


            <div Class="form-group row">

                @Html.Label("TypeSinistreId", Resource.TypeSinistre, New With {.class = "col-sm-2 col-form-label"})
                <div class="col-sm-4">
                    @Html.TextBoxFor(Function(m) m.Sinistre.TypeSinistre.Libelle, New With {.class = "form-control form-control-square", .readonly = "true", .tabindex = "3"})
                </div>

                @Html.LabelFor(Function(m) m.DateCreation, New With {.class = "col-sm-2 col-form-label"})
                <div class="col-sm-4">
                    @Html.TextBoxFor(Function(m) m.DateCreation, New With {.class = "form-control form-control-square", .tabindex = "4", .readonly = "true"})
                </div>
            </div>


            <div Class="form-group row">
                @Html.LabelFor(Function(m) m.Contenu, New With {.class = "col-sm-2 col-form-label required_field"})
                <div class="col-sm-10">
                    @Html.TextAreaFor(Function(m) m.Contenu, New With {.class = "form-control form-control-square summernoteEditor ", .tabindex = "4", .readonly = "true"})
                    @Html.ValidationMessageFor(Function(m) m.Contenu, "", New With {.style = "color: #da0b0b"})
                </div>

            </div>

            <div Class="form-group row">
                <Label Class="col-sm-2 col-form-label"></Label>
                <div Class="col-sm-10">
                    @Html.ActionLink(Resource.BtnCancel, "Index", Nothing, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                </div>
            </div>


        </div>
    </div>
</div>

@Section Scripts
    <script>

        $("#Contenu").summernote("disable");

    </script>
End Section