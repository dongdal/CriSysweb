@ModelType PagedList.IPagedList(Of Organisation)
@Imports PagedList.Mvc
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.ListOrganisation
End Code

<div class="page-header">
    <h1 class="page-title">@Resource.ManageOrganisation</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Organisations")>@Resource.ManageOrganisation</a></li>
        <li class="breadcrumb-item active">@Resource.ListOrganisation</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.ListOrganisation</div>
            <hr>
            @Using Html.BeginForm("Index", "Organisations", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()
                @<div Class="form-inline padding-bottom-1">
                    <div Class="row col-sm-12">
                        <div Class="col-sm-8">
                            <div Class="form-group">
                                <a class="btn btn-round btn-primary waves-effect waves-light m-1" title="@Resource.Btn_nouveau" href="@Url.Action("Create")">
                                    <i Class="fa fa-plus" aria-hidden="true"></i>
                                    @Resource.Btn_nouveau
                                </a>
                            </div>
                        </div>

                        <div class="col-sm-4 text-right">
                            <div class="input-group mb-3">
                                @Html.TextBox("SearchString", CStr(ViewBag.CurrentFilter), New With {.class = "form-control round", .placeholder = Resource.Find})
                                <div class="input-group-append">
                                    <button class="btn btn-primary" type="submit"><i class="fa fa-search"></i></button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            End Using

            <table id="default-datatable" class="table table-bordered dataTable" role="grid" aria-describedby="default-datatable_info">
                <thead>
                    <tr>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Nom, "Index", New With {.sortOrder = ViewBag.NomSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Acronyme, "Index", New With {.sortOrder = ViewBag.NomSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.TypeOrganisation, "Index", New With {.sortOrder = ViewBag.TypeOrganisationSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Secteur, "Index", New With {.sortOrder = ViewBag.SecteurSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Ville, "Index", New With {.sortOrder = ViewBag.VilleSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Telephone, "Index", New With {.sortOrder = ViewBag.TelephoneSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.DateCreation, "Index", New With {.sortOrder = ViewBag.DateCreationSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Resource.ActionList
                        </th>
                    </tr>
                </thead>

                <tbody>
                    @For Each item In Model
                        @<tr>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.Nom)
                            </td>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.Acronyme)
                            </td>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.TypeOrganisation.Libelle)
                            </td>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.Secteur.Libelle)
                            </td>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.Ville.Libelle)
                            </td>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.StatutExistant)
                            </td>
                            <td class="text-center">
                                <a class="btn btn-round btn-warning waves-effect waves-light m-1" title="@Resource.Btn_Edit" href="@Url.Action("Edit", New With {.id = item.Id})">
                                    <i class="fa fa-edit" aria-hidden="true"></i>
                                </a>
                                <a class="btn btn-round btn-info waves-effect waves-light m-1" title="@Resource.Btn_Detail" href="#" data-toggle="modal" data-target="#@item.Id">
                                    <i class="fa fa-info" aria-hidden="true"></i>
                                </a>
                                <a class="btn btn-round btn-danger waves-effect waves-light m-1" title="@Resource.Btn_Delete" href="@Url.Action("Delete", New With {.id = item.Id})">
                                    <i class="fa fa-trash" aria-hidden="true"></i>
                                </a>

                                <div class="modal fade" id="@item.Id">
                                    <div class="modal-dialog modal-lg">
                                        <div class="modal-content animated jackInTheBox">
                                            <div class="modal-header">
                                                <h5 class="modal-title"><i class="fa fa-star"></i> @Resource.Btn_Detail</h5>
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>
                                            <div class="modal-body">
                                                <div Class="row col-sm-12">

                                                    <div class="col-sm-6 form-group">

                                                        <div class="form-group">
                                                            <label for="Nom" class="col-form-label">@Resource.Nom : </label>
                                                            @Html.DisplayFor(Function(m) item.Nom, New With {.class = "form-control", .disabled = "disabled"})
                                                        </div>
                                                        <br />

                                                        <div class="form-group">
                                                            <label for="Acronyme" class="col-form-label">@Resource.Acronyme : </label>
                                                            @Html.DisplayFor(Function(m) item.Acronyme, New With {.class = "form-control", .disabled = "disabled"})
                                                        </div>
                                                        <br />

                                                        <div class="form-group">
                                                            <label for="TypeOrganisation" class="col-form-label">@Resource.TypeOrganisation : </label>
                                                            @Html.DisplayFor(Function(m) item.TypeOrganisation.Libelle, New With {.class = "form-control", .disabled = "disabled"})
                                                        </div>
                                                        <br />

                                                        <div class="form-group">
                                                            <label for="Secteur" class="col-form-label">@Resource.Secteur : </label>
                                                            @Html.DisplayFor(Function(m) item.Secteur.Libelle, New With {.class = "form-control", .disabled = "disabled"})
                                                        </div>
                                                        <br />

                                                        <div class="form-group">
                                                            <label for="Ville" class="col-form-label">@Resource.Ville : </label>
                                                            @Html.DisplayFor(Function(m) item.Ville.Libelle, New With {.class = "form-control", .disabled = "disabled"})
                                                        </div>
                                                        <br />

                                                        <div class="form-group">
                                                            <label for="Telephone" class="col-form-label">@Resource.Telephone : </label>
                                                            @Html.DisplayFor(Function(m) item.Telephone, New With {.class = "form-control", .disabled = "disabled"})
                                                        </div>
                                                        <br />


                                                    </div>

                                                    <div class="col-sm-6 form-group">

                                                        <div class="form-group">
                                                            <label for="SiteWeb" class="col-form-label">@Resource.SiteWeb : </label>
                                                            @Html.DisplayFor(Function(m) item.SiteWeb, New With {.class = "form-control", .disabled = "disabled"})
                                                        </div>
                                                        <br />

                                                        <div class="form-group">
                                                            <label for="Email" class="col-form-label">@Resource.Email : </label>
                                                            @Html.DisplayFor(Function(m) item.Email, New With {.class = "form-control", .disabled = "disabled"})
                                                        </div>
                                                        <br />

                                                        <div class="form-group">
                                                            <label for="BoitePostale" class="col-form-label">@Resource.BoitePostale : </label>
                                                            @Html.DisplayFor(Function(m) item.BoitePostale, New With {.class = "form-control", .disabled = "disabled"})
                                                        </div>
                                                        <br />

                                                        <div class="form-group">
                                                            <label for="DateCreation" class="col-form-label">@Resource.DateCreation : </label>
                                                            @Html.DisplayFor(Function(m) item.DateCreation, New With {.class = "form-control", .disabled = "disabled"})
                                                        </div>
                                                        <br />

                                                        <div class="form-group">
                                                            <label for="StatutExistant" class="col-form-label">@Resource.StatutExistant : </label>
                                                            @Html.DisplayFor(Function(m) item.StatutExistant, New With {.class = "form-control", .disabled = "disabled"})
                                                        </div>
                                                        <br />

                                                        <div class="form-group">
                                                            <label for="Utilisateur" class="col-form-label">@Resource.SaveBy : </label>
                                                            @Html.DisplayFor(Function(m) item.AspNetUser.UserName, New With {.class = "form-control", .disabled = "disabled"})
                                                        </div>
                                                        <br />
                                                    </div>

                                                </div>

                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-secondary" data-dismiss="modal"><i class="fa fa-times"></i> Close</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </td>
                        </tr>
                    Next
                </tbody>

            </table>

            @Html.PagedListPager(Model, Function(page) Url.Action("Index",
                                                                                               New With {.page = page, .sortOrder = ViewBag.CurrentSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab}))
            Page @IIf(Model.PageCount < Model.PageNumber, 0, Model.PageNumber) @Resource.RecordsOn @Model.PageCount (@ViewBag.EnregCount @Resource.Records)

        </div>

    </div>
</div>



