@ModelType BordereauTransfertViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.CreateBordereauTransfert
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageBordereauTransfert</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "BordereauTransferts")>@Resource.ManageBordereauTransfert</a></li>
        <li class="breadcrumb-item active">@Resource.CreateBordereauTransfert</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.CreateBordereauTransfert</div>
            <hr>
            @Using Html.BeginForm("Create", "BordereauTransferts", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.NumeroBordereau, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.NumeroBordereau, New With {.class = "form-control form-control-square", .tabindex = "1"})
                        @Html.ValidationMessageFor(Function(m) m.NumeroBordereau, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>
                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Libelle, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Libelle, New With {.class = "form-control form-control-square", .tabindex = "2"})
                        @Html.ValidationMessageFor(Function(m) m.Libelle, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>
                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.DateTransfert, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.DateTransfert, New With {.class = "form-control form-control-square default-datepicker", .tabindex = "3"})
                        @Html.ValidationMessageFor(Function(m) m.DateTransfert, "", New With {.style = "color: #da0b0b"})
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
