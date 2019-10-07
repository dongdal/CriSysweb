@ModelType NiveauDAlertViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.CreateNiveauDAlert
    Layout = "~/Views/Shared/_LayoutDesinventar.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageNiveauDAlert</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "NiveauDAlerts")>@Resource.ManageNiveauDAlert</a></li>
        <li class="breadcrumb-item active">@Resource.CreateNiveauDAlert</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.CreateNiveauDAlert</div>
            <hr>
            @Using Html.BeginForm("Create", "NiveauDAlerts", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Libelle, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Libelle, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.LibellePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Libelle, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    <Label Class="col-sm-2 col-form-label"></Label>
                    <div Class="col-sm-10">
                        <Button type="submit" Class="btn btn-link btn-square bg-primary text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.BtnSave</Button>
                        &nbsp;&nbsp;&nbsp;
                        @Html.ActionLink(Resource.BtnCancel, "Index", Nothing, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                    </div>
                </div>

            End Using

        </div>
    </div>
</div>
