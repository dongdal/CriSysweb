@ModelType RessourceViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.EditRessource
    Layout = "~/Views/Shared/_LayoutParam.vbhtml"
End Code

<div class="page-header">
    <h1 class="page-title">@Resource.ManageRessource</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Ressources")>@Resource.ManageRessource</a></li>
        <li class="breadcrumb-item active">@Resource.EditRessource</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.EditRessource</div>
            <hr>
            @Using Html.BeginForm("Edit", "Ressources", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()
                @Html.HiddenFor(Function(m) m.Id)
                @Html.HiddenFor(Function(m) m.StatutExistant)
                @Html.HiddenFor(Function(m) m.DateCreation)
                @Html.HiddenFor(Function(m) m.AspNetUserId)


                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Libelle, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Libelle, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.LibellePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Libelle, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.ModulesId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.ModulesId, New SelectList(Model.LesModules, "Value", "Text"), Resource.ModulesCombo,
 New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ModulesCombo})
                        @Html.ValidationMessageFor(Function(m) m.ModulesId, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Description, New With {.class = "col-sm-2 col-form-label "})
                    <div class="col-sm-4">
                        @Html.TextAreaFor(Function(m) m.Description, New With {.class = "form-control form-control-square", .tabindex = "3", .Placeholder = Resource.DescriptionPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Description, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    <Label Class="col-sm-2 col-form-label"></Label>
                    <div Class="col-sm-10">
                        <Button type="submit" Class="btn btn-link btn-square bg-warning text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.Btn_Edit</Button>
                        &nbsp;&nbsp;&nbsp;
                        @Html.ActionLink(Resource.BtnCancel, "Index", Nothing, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                    </div>
                </div>

            End Using

        </div>
    </div>
</div>
