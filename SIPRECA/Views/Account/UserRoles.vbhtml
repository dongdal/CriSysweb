@ModelType SelectUserRolesViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.GestUserRolesTilte
    Layout = "~/Views/Shared/_LayoutParam.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.Menu_UserManager</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Account")>@Resource.Menu_UserManager</a></li>
        <li class="breadcrumb-item active">@Resource.GestUserRoles</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card gradient-titanium">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.GestUserRoles</div>
            <hr>
            @Using Html.BeginForm("UserRoles", "Account", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()


                @<Button type="submit" Class="fv-hidden-submit" style="display: none; width: 0px; height: 0px;"></Button>
                @<div Class="row row-lg">
                    <h2>@Resource.GestUserRolesTo  @Html.DisplayFor(Function(m) m.UserName) </h2>

                    <div Class="form-group row col-sm-12">
                        <div Class="col-md-10">
                            @Html.HiddenFor(Function(m) m.UserName)
                        </div>
                    </div>

                    <div Class="form-group row  col-sm-12">
                        <Table style=" font-size:large; color: white" class="form-group row">
                            <thead>
                                <tr>
                                    <th style="text-align:right; width:50px"></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td> @Html.EditorFor(Function(Model) Model.Roles) </td>
                                </tr>
                            </tbody>
                        </Table>
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

@*<div class="form-group form-material floating">
        @Html.LabelFor(Function(m) m.Sexe, New With {.class = "floating-label"})
        <br />
        <div class="col-lg-12 col-sm-9">
            <div class="input-group">
                <div>
                    <div class="radio-custom radio-primary">
                        @Html.RadioButtonFor(Function(m) m.Sexe, "M")
                        @Html.Label(Resource.SexeMasculin, New With {.for = "M"})
                    </div>
                </div>
                <div>
                    <div class="radio-custom radio-primary">
                        @Html.RadioButtonFor(Function(m) m.Sexe, "F")
                        @Html.Label(Resource.SexeFeminin, New With {.for = "F"})
                    </div>
                </div>
            </div>
            @Html.ValidationMessageFor(Function(model) model.Sexe)
        </div>
    </div>*@




@*@ModelType RegisterViewModel
    @Code
        ViewBag.Title = "S’inscrire"
    End Code

    <h2>@ViewBag.Title.</h2>

    @Using Html.BeginForm("Register", "Account", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})

        @Html.AntiForgeryToken()

        @<text>
        <h4>Créer un nouveau compte.</h4>
        <hr />
        @Html.ValidationSummary()
        <div class="form-group">
            @Html.LabelFor(Function(m) m.UserName, New With {.class = "col-md-2 control-label"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(m) m.UserName, New With {.class = "form-control"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.Password, New With {.class = "col-md-2 control-label"})
            <div class="col-md-10">
                @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.ConfirmPassword, New With {.class = "col-md-2 control-label"})
            <div class="col-md-10">
                @Html.PasswordFor(Function(m) m.ConfirmPassword, New With {.class = "form-control"})
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" class="btn btn-default" value="S'enregistrer" />
            </div>
        </div>
        </text>
    End Using

    @section Scripts
        @Scripts.Render("~/bundles/jqueryval")
    End Section*@
