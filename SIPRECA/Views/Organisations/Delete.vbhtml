@ModelType OrganisationViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.DeleteOrganisation
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageOrganisation</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Organisations")>@Resource.ManageOrganisation</a></li>
        <li class="breadcrumb-item active">@Resource.DeleteOrganisation</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.ConfirmDelete</div>
            <hr>
            @Using Html.BeginForm("Delete", "Organisations", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()
                @Html.HiddenFor(Function(m) m.Id)
                @Html.HiddenFor(Function(m) m.StatutExistant)
                @Html.HiddenFor(Function(m) m.DateCreation)
                @Html.HiddenFor(Function(m) m.AspNetUserId)


                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Nom, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Nom, New With {.class = "form-control form-control-square", .tabindex = "1", .readonly = "true"})
                        @Html.ValidationMessageFor(Function(m) m.Nom, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Acronyme, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Acronyme, New With {.class = "form-control form-control-square", .tabindex = "2", .readonly = "true"})
                        @Html.ValidationMessageFor(Function(m) m.Acronyme, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.TypeOrganisationId, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4 form-group">
                        @Html.TextBoxFor(Function(m) m.TypeOrganisation.Libelle, New With {.class = "form-control form-control-square", .tabindex = "3"})
                        @Html.ValidationMessageFor(Function(m) m.TypeOrganisationId, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.VilleId, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4 form-group">
                        @Html.TextBoxFor(Function(m) m.Ville.Libelle, New With {.class = "form-control form-control-square", .tabindex = "5", .readonly = "true"})
                        @Html.ValidationMessageFor(Function(m) m.VilleId, "", New With {.style = "color: #da0b0b"})
                    </div>

                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Telephone, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Telephone, New With {.class = "form-control form-control-square", .tabindex = "6", .readonly = "true"})
                        @Html.ValidationMessageFor(Function(m) m.Telephone, "", New With {.style = "color: #da0b0b"})
                    </div>
                    @Html.LabelFor(Function(m) m.SiteWeb, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.SiteWeb, New With {.class = "form-control form-control-square", .tabindex = "7", .readonly = "true"})
                        @Html.ValidationMessageFor(Function(m) m.SiteWeb, "", New With {.style = "color: #da0b0b"})
                    </div>

                </div>

                @<div Class="form-group row">
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.BoitePostale, New With {.class = "form-control form-control-square", .tabindex = "8", .readonly = "true"})
                        @Html.ValidationMessageFor(Function(m) m.BoitePostale, "", New With {.style = "color: #da0b0b"})
                    </div>
                    @Html.LabelFor(Function(m) m.Email, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control form-control-square", .tabindex = "9", .readonly = "true"})
                        @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>


                @<div Class="form-group row">
                    <Label Class="col-sm-2 col-form-label"></Label>
                    <div Class="col-sm-10">
                        <Button type="submit" Class="btn btn-link btn-square bg-danger text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.Btn_Delete</Button>
                        &nbsp;&nbsp;&nbsp;
                        @Html.ActionLink(Resource.BtnCancel, "Index", Nothing, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                    </div>
                </div>

            End Using

        </div>
    </div>
</div>
