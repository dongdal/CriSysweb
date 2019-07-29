@ModelType CollectiviteSinistreeViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.EditCollectiviteSinistree
End Code

<div class="page-header">
    <h1 class="page-title">@Resource.ManageCollectiviteSinistree</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "CollectiviteSinistrees")>@Resource.ManageCollectiviteSinistree</a></li>
        <li class="breadcrumb-item active">@Resource.EditCollectiviteSinistree</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.EditCollectiviteSinistree</div>
            <hr>
            @Using Html.BeginForm("Edit", "CollectiviteSinistrees", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()
                @Html.HiddenFor(Function(m) m.Id)
                @Html.HiddenFor(Function(m) m.StatutExistant)
                @Html.HiddenFor(Function(m) m.DateCreation)
                @Html.HiddenFor(Function(m) m.AspNetUserId)
                @Html.HiddenFor(Function(m) m.AnneeBudgetaireId)

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Libelle, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Libelle, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.LibellePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Libelle, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.SinistreId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.SinistreId, New SelectList(Model.LesSinistres, "Value", "Text"), Resource.ComboSinistre,
New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboSinistre})
                        @Html.ValidationMessageFor(Function(m) m.SinistreId, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.CollectiviteId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.CollectiviteId, New SelectList(Model.LesCollectivites, "Value", "Text"), Resource.ComboLocalite,
             New With {.class = "form-control single-select", .tabindex = "3", .Placeholder = Resource.ComboLocalite})
                        @Html.ValidationMessageFor(Function(m) m.CollectiviteId, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.DateSinistre, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.DateSinistre, New With {.class = "form-control form-control-square default-datepicker", .tabindex = "4", .Placeholder = Resource.DateSinistrePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.DateSinistre, "", New With {.style = "color: #da0b0b"})
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
