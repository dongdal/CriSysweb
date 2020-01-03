﻿@ModelType DepartementViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.DeleteDepartement
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageDepartement</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Departements")>@Resource.ManageDepartement</a></li>
        <li class="breadcrumb-item active">@Resource.DeleteDepartement</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.ConfirmDelete</div>
            <hr>
            @Using Html.BeginForm("Delete", "Departements", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()
                @Html.HiddenFor(Function(m) m.Id)
                @Html.HiddenFor(Function(m) m.StatutExistant)
                @Html.HiddenFor(Function(m) m.DateCreation)
                @Html.HiddenFor(Function(m) m.AspNetUserId)

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Libelle, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Libelle, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.LibellePlaceholder, .readonly = "true"})
                    </div>

                    @Html.LabelFor(Function(m) m.ChefLieu, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.ChefLieu, New With {.class = "form-control form-control-square", .tabindex = "2", .Placeholder = Resource.LibellePlaceholder, .readonly = "true"})
                    </div>

                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Superficie, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Superficie, New With {.class = "form-control form-control-square", .tabindex = "3", .Placeholder = Resource.SuperficiePlaceholder, .readonly = "true"})
                    </div>

                    @Html.LabelFor(Function(m) m.Population, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Population, New With {.class = "form-control form-control-square", .tabindex = "4", .Placeholder = Resource.PopulationPlaceholder, .readonly = "true"})
                    </div>
                </div>

                @<div Class="form-group row">

                    @Html.LabelFor(Function(m) m.Region.Libelle, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Region.Libelle, New With {.class = "form-control form-control-square", .tabindex = "5", .Placeholder = Resource.LibellePlaceholder, .readonly = "true"})
                    </div>

                    @Html.LabelFor(Function(m) m.DateCreation, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.DateCreation, New With {.class = "form-control form-control-square", .tabindex = "6", .Placeholder = Resource.LibellePlaceholder, .readonly = "true"})
                    </div>
                </div>

                @<div Class="form-group row">

                    @Html.LabelFor(Function(m) m.Code, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Code, New With {.class = "form-control form-control-square", .tabindex = "7", .Placeholder = Resource.LibellePlaceholder, .readonly = "true"})
                    </div>

                    @Html.LabelFor(Function(m) m.StatutExistant, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.StatutExistant, New With {.class = "form-control form-control-square", .tabindex = "8", .Placeholder = Resource.LibellePlaceholder, .readonly = "true"})
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
