@ModelType AccessRightsManagerViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.AccessRightsManagerTitle
    Layout = "~/Views/Shared/_LayoutParam.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.Menu_UserManager</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Account")>@Resource.Menu_UserManager</a></li>
        <li class="breadcrumb-item active">@Resource.AccessRightsManagerTitle</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card gradient-titanium">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.AccessRightsManagerTitle</div>
            <hr>
            @Using Html.BeginForm("AccessRightsManager", "Account", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()
                @<div Class="row">
                    <div Class="col-lg-12">
                        <div Class="card">
                            <div Class="card-body">
                                <div Class="row">
                                    <div Class="col-md-3">
                                        <ul Class="nav nav-pills nav-pills-dark flex-column top-icon" role="tablist">

                                            @For each moduleRole In Model.LesModuleRoles
                                                @<li Class="nav-item">
                                                    <a Class="nav-link " data-toggle="pill" href="#module-@moduleRole.Modules.Id.ToString()">
                                                        <i class="icon-home"></i>
                                                        <span class="hidden-xs">@moduleRole.Modules.Libelle.ToUpper()</span>
                                                    </a>
                                                </li>
                                            Next
                                        </ul>
                                    </div>

                                    <div Class="col-md-9">
                                        <!-- Tab panes -->
                                        <div Class="tab-content">
                                            @For Each moduleRole In Model.LesModuleRoles
                                                @<div id="module-@moduleRole.Modules.Id.ToString()" Class="container tab-pane ">
                                                    <h4> @moduleRole.Modules.Description.ToUpper()</h4>
                                                    <p> @moduleRole.Modules.Description.ToUpper() : There are many variations Of passages Of Lorem Ipsum available, but the majority have suffered alteration In some form, by injected humour, Or randomised words which don't look even slightly believable.</p>
                                                    <p>If you are going To use a passage Of Lorem Ipsum, you need To be sure there isn't anything embarrassing hidden in the middle of text.All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet</p>
                                                </div>
                                            Next

                                        </div>
                                    </div>
                                </div><!--End row-->
                            </div>
                        </div>
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
