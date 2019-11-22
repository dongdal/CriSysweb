@ModelType Installation
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.DetailsInstallation
    Layout = "~/Views/Shared/_LayoutSahana.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.DetailsInstallation</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Installations")>@Resource.ManageInstallation</a></li>
        <li class="breadcrumb-item active">@Resource.DetailsInstallation</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.DetailsInstallation</div>
            <hr>

                <div Class="row col-sm-12">

                    <div class="col-sm-6 form-group">

                        <div class="form-group">
                            <label for="UserName" class="col-form-label">@Resource.Code : </label>
                            @Html.DisplayFor(Function(model) model.Code, New With {.Class = "form-control", .disabled = "disabled"})
                        </div>
                        <br />

                        <div class="form-group">
                            <label for="Nom" class="col-form-label">@Resource.Noms : </label>
                            @Html.DisplayFor(Function(model) model.Nom, New With {.Class = "form-control", .disabled = "disabled"})
                        </div>
                        <br />

                        <div class="form-group">
                            <label for="Prenom" class="col-form-label">@Resource.Organisation : </label>
                            @Html.DisplayFor(Function(model) model.Oganisation.Nom, New With {.Class = "form-control", .disabled = "disabled"})
                        </div>
                        <br />

                        <div class="form-group">
                            <label for="DateNaissance" class="col-form-label">@Resource.Commune : </label>
                            @Html.DisplayFor(Function(model) model.Commune.Libelle, New With {.Class = "form-control", .disabled = "disabled"})
                        </div>
                        <br />

                        <div class="form-group">
                            <label for="LieuNaissance" class="col-form-label">@Resource.CodePostale : </label>
                            @Html.DisplayFor(Function(model) model.CodePostale, New With {.Class = "form-control", .disabled = "disabled"})
                        </div>
                        <br />

                        <div class="form-group">
                            <label for="Sexe" class="col-form-label">@Resource.Telephone : </label>
                            @Html.DisplayFor(Function(model) model.Telephone, New With {.Class = "form-control", .disabled = "disabled"})
                        </div>
                        <br />


                    </div>

                    <div class="col-sm-6 form-group">

                        <div class="form-group">
                            <label for="Telephone" class="col-form-label">@Resource.HeureDOuverture : </label>
                            @Html.DisplayFor(Function(model) model.HeureDOuverture, New With {.class = "form-control", .disabled = "disabled"})
                        </div>
                        <br />

                        <div class="form-group">
                            <label for="CNI" class="col-form-label">@Resource.HeureFermeture : </label>
                            @Html.DisplayFor(Function(model) model.HeureFermeture, New With {.class = "form-control", .disabled = "disabled"})
                        </div>
                        <br />

                        <div class="form-group">
                            <label for="DateExpirationCNI" class="col-form-label">@Resource.DateCreation : </label>
                            @Html.DisplayFor(Function(model) model.DateCreation, New With {.class = "form-control", .disabled = "disabled"})
                        </div>
                        <br />

                        <div class="form-group">
                            <label for="Email" class="col-form-label">@Resource.Email : </label>
                            @Html.DisplayFor(Function(model) model.Email, New With {.class = "form-control", .disabled = "disabled"})
                        </div>
                        <br />

                        <div class="form-group">
                            <label for="DateCreation" class="col-form-label">@Resource.Telephone2 : </label>
                            @Html.DisplayFor(Function(model) model.Telephone2, New With {.Class = "form-control", .disabled = "disabled"})
                        </div>
                        <br />
                    </div>

                </div>

            </div>

        </div>
        </div>