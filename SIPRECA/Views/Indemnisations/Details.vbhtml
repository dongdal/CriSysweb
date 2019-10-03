@ModelType IndemnisationViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.DetailsIndemnisations
    Layout = "~/Views/Shared/_LayoutSahana.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.DetailsIndemnisations</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Indemnisations")>@Resource.ManageIndemnisation</a></li>
        <li class="breadcrumb-item active">@Resource.DetailsIndemnisations</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.DetailsIndemnisations</div>
            <hr>
            @Using Html.BeginForm("Details", "Indemnisations", FormMethod.Post, New With {.enctype = "multipart/form-data"})
                @Html.AntiForgeryToken()
                @Html.HiddenFor(Function(m) m.Id)
                @Html.HiddenFor(Function(m) m.StatutExistant)
                @Html.HiddenFor(Function(m) m.DateCreation)
                @Html.HiddenFor(Function(m) m.AspNetUserId)

                @<div Class="form-group row">

                    @Html.LabelFor(Function(m) m.DemandeId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.TextBoxFor(Function(m) m.Demande.Reference, New With {.class = "form-control form-control-square", .tabindex = "2", .readonly = "true"})
                    </div>

                    @Html.LabelFor(Function(m) m.Libelle, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Libelle, New With {.class = "form-control form-control-square", .tabindex = "2", .readonly = "true"})
                    </div>
                </div>

                @<div Class="form-group row">

                    @Html.LabelFor(Function(m) m.Description, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextAreaFor(Function(m) m.Description, New With {.class = "form-control form-control-square", .tabindex = "4", .Placeholder = Resource.DescriptionPlaceholder, .readonly = "true"})
                    </div>
                </div>

                @<table id="DetailsIndemnisation" Class="table table-bordered dataTable" role="grid" aria-describedby="default-datatable_info">
                    <thead>
                        <tr>

                            <th Class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                @Resource.NatureAide
                            </th>
                            <th Class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                @Resource.Quantite
                            </th>

                        </tr>
                    </thead>

                    <tbody>
                        @For Each item In Model.DetailsIndemnisation
                            @<tr>
                                <td class="sorting_asc text-center">
                                    @Html.DisplayFor(Function(modelItem) item.NatureAide.Libelle)
                                </td>
                                <td class="sorting_asc text-center">
                                    @Html.DisplayFor(Function(modelItem) item.Quantite)
                                </td>
                            </tr>
                        Next
                    </tbody>

                </table>
                @<br />
                '<!--End Row-->
            End Using

            <div Class="form-group row">
                <Label Class="col-sm-5 col-form-label"></Label>
                <div Class="col-sm-6">

                    @*@Html.ActionLink(Resource.Btn_Edit, "Edit", New With {.id = Model.Id}, New With {.class = "btn btn-link btn-square bg-warning text-dark shadow px-5"})*@
                    &nbsp;&nbsp;&nbsp;
                    @Html.ActionLink(Resource.BtnCancel, "Index", "Demandes", Nothing, New With {.class = "btn btn-dark btn-square bg-white text-dark shadow px-5"})
                </div>
            </div>

        </div>
    </div>
</div>
