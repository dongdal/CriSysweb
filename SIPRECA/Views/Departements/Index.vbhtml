@ModelType PagedList.IPagedList(Of Departement)
@Imports PagedList.Mvc
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.ListDepartement
End Code

<div class="page-header">
    <h1 class="page-title">@Resource.ManageDepartement</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Departements")>@Resource.ManageDepartement</a></li>
        <li class="breadcrumb-item active">@Resource.ListDepartement</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.ListDepartement</div>
            <hr>
            @Using Html.BeginForm("Index", "Departements", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()
                @<div Class="form-inline padding-bottom-1">
                    <div Class="row col-sm-12">
                        <div Class="col-sm-8">
                            <div Class="form-group">
                                @If AppSession.ListActionSousRessource.Contains(7, 1) Then
                                    @<a class="btn btn-round btn-primary waves-effect waves-light m-1" title="@Resource.Btn_nouveau" href="@Url.Action("Create")">
                                        <i Class="fa fa-plus" aria-hidden="true"></i>
                                        @Resource.Btn_nouveau
                                    </a>
                                End If
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
                            @Html.ActionLink(Resource.Code, "Index", New With {.sortOrder = ViewBag.CodeSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Libelle, "Index", New With {.sortOrder = ViewBag.LibelleSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.ChefLieu, "Index", New With {.sortOrder = ViewBag.ChefLieuSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Region, "Index", New With {.sortOrder = ViewBag.RegionSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Superficie, "Index", New With {.sortOrder = ViewBag.SuperficieSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Population, "Index", New With {.sortOrder = ViewBag.PopulationSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
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
                                @Html.DisplayFor(Function(modelItem) item.Code)
                            </td>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.Libelle)
                            </td>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.ChefLieu)
                            </td>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.Region.Libelle)
                            </td>
                            <td class="sorting_asc text-center">
                                @String.Format("{0:0,0}", item.Superficie)  Km²
                            </td>
                            <td class="sorting_asc text-center">
                                @String.Format("{0:0,0}", item.Population) Hbts
                            </td>
                            <td class="text-center">
                                @If AppSession.ListActionSousRessource.Contains(7, 3) Then
                                    @<a class="btn btn-round btn-warning waves-effect waves-light m-1" title="@Resource.Btn_Edit" href="@Url.Action("Edit", New With {.id = item.Id})">
                                        <i class="fa fa-edit" aria-hidden="true"></i>
                                    </a>
                                End If
                                @If AppSession.ListActionSousRessource.Contains(7, 4) Then
                                    @<a class="btn btn-round btn-danger waves-effect waves-light m-1" title="@Resource.Btn_Delete" href="@Url.Action("Delete", New With {.id = item.Id})">
                                        <i class="fa fa-trash" aria-hidden="true"></i>
                                    </a>
                                End If

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



