@ModelType CommuneViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.EditCommune
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageCommune</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Communes")>@Resource.ManageCommune</a></li>
        <li class="breadcrumb-item active">@Resource.EditCommune</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.EditCommune</div>
            <hr>
            @Using Html.BeginForm("Edit", "Communes", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()
                @Html.HiddenFor(Function(m) m.Id)
                @Html.HiddenFor(Function(m) m.StatutExistant)
                @Html.HiddenFor(Function(m) m.DateCreation)
                @Html.HiddenFor(Function(m) m.AspNetUserId)
                @Html.HiddenFor(Function(m) m.Longitude)
                @Html.HiddenFor(Function(m) m.Latitude)

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Libelle, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Libelle, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.LibellePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Libelle, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.DepartementId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.DepartementId, New SelectList(Model.Departements, "Value", "Text"), Resource.ComboDepartement,
        New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboDepartement})
                        @Html.ValidationMessageFor(Function(m) m.DepartementId, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Superficie, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Superficie, New With {.class = "form-control form-control-square", .tabindex = "3", .Placeholder = Resource.SuperficiePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Superficie, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Population, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Population, New With {.class = "form-control form-control-square", .tabindex = "4", .Placeholder = Resource.PopulationPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Population, "", New With {.style = "color: #da0b0b"})
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
