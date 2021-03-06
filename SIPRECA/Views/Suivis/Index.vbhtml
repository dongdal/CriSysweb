@ModelType PagedList.IPagedList(Of Suivi)
@Imports PagedList.Mvc
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.ListSuivi
End Code

<div class="page-header">
    <h1 class="page-title">@Resource.ManageSuivi</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Suivis")>@Resource.ManageSuivi</a></li>
        <li class="breadcrumb-item active">@Resource.ListSuivi</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.ListSuivi</div>
            <hr>
            @Using Html.BeginForm("Index", "Suivis", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()
                @<div Class="form-inline padding-bottom-1">
                    <div Class="row col-sm-12">
                        @*<div Class="col-sm-8">
                                <div Class="form-group">
                                    <a class="btn btn-round btn-primary waves-effect waves-light m-1" title="@Resource.Btn_nouveau" href="@Url.Action("Create")">
                                        <i Class="fa fa-plus" aria-hidden="true"></i>
                                        @Resource.Btn_nouveau
                                    </a>
                                </div>
                            </div>*@

                        <div class="col-sm-12 text-right">
                            <div class="input-group mb-3">
                                @Html.TextBox("SearchString", CStr(ViewBag.CurrentFilter), New With {.class = "form-control round", .placeholder = Resource.FindReferenceDemande})
                                <div class="input-group-append">
                                    <button class="btn btn-primary" type="submit"><i class="fa fa-search"></i></button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            End Using

            <div class="card-title text-uppercase"><i class="fa fa-key"></i> @Resource.ReferenceDemande : @ViewBag.CurrentFilter</div>

            <table id="default-datatable" class="table table-bordered dataTable" role="grid" aria-describedby="default-datatable_info">
                <thead>
                    <tr>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Libelle, "Index", New With {.sortOrder = ViewBag.LibelleSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Demande, "Index", New With {.sortOrder = ViewBag.DemandeSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.TypeSuivi, "Index", New With {.sortOrder = ViewBag.TypeSuiviSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Utilisateur, "Index", New With {.sortOrder = ViewBag.DateCreationSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.DateOperation, "Index", New With {.sortOrder = ViewBag.DateCreationSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>

                    </tr>
                </thead>

                <tbody>
                    @For Each item In Model
                        @<tr>
                            <td class="sorting_asc text-center" style="height: 30px;">
                                @Html.DisplayFor(Function(modelItem) item.Libelle)
                            </td>
                            <td class="sorting_asc text-center" style="height: 30px;">
                                @Html.DisplayFor(Function(modelItem) item.Demande.Reference)
                            </td>
                            <td class="sorting_asc text-center" style="height: 30px;">
                                @Html.DisplayFor(Function(modelItem) item.TypeSuivi.Libelle)
                            </td>
                            <td class="sorting_asc text-center" style="height: 30px;">
                                @item.AspNetUser.Nom @item.AspNetUser.Prenom
                            </td>
                            <td class="sorting_asc text-center" style="height: 30px;">
                                @Html.DisplayFor(Function(modelItem) item.DateCreation)
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



