@ModelType PagedList.IPagedList(Of Sinistrer)
@Imports PagedList.Mvc
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.ListSinistrer
End Code

<div class="page-header">
    <h1 class="page-title">@Resource.ManageSinistrer</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Sinistrers")>@Resource.ManageSinistrer</a></li>
        <li class="breadcrumb-item active">@Resource.ListSinistrer</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.ListSinistrer</div>
            <hr>
            @Using Html.BeginForm("Index", "Sinistrers", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()
                @<div Class="form-inline padding-bottom-1">
                    <div Class="row col-sm-12">
                        <div Class="col-sm-8">
                            <div Class="form-group">
                                @If AppSession.ListActionSousRessource.Contains(12, 1) Then
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
                            @Html.ActionLink(Resource.Nom, "Index", New With {.sortOrder = ViewBag.NomSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Prenom, "Index", New With {.sortOrder = ViewBag.PrenomSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.CNI, "Index", New With {.sortOrder = ViewBag.CNISort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Sexe, "Index", New With {.sortOrder = ViewBag.SexeSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.DateDeNaissance, "Index", New With {.sortOrder = ViewBag.DateDeNaissanceSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Telephone, "Index", New With {.sortOrder = ViewBag.TelephoneSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
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
                                @Html.DisplayFor(Function(modelItem) item.Prenom)
                            </td>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.Cni)
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.Sexe)
                            </td>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.DateDeNaissance)
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.Telephone)
                            </td>
                            
                            <td class="text-center">
                                @If AppSession.ListActionSousRessource.Contains(12, 3) Then
                                    @<a class="btn btn-round btn-warning waves-effect waves-light m-1" title="@Resource.Btn_Edit" href="@Url.Action("Edit", New With {.id = item.Id})">
                                        <i class="fa fa-edit" aria-hidden="true"></i>
                                    </a>
                                End If
                                @If AppSession.ListActionSousRessource.Contains(11, 1) Then
                                    @<a class="btn btn-round btn-primary waves-effect waves-light m-1" title="@Resource.Btn_NewDem" href="@Url.Action("Create", "Demandes", New With {.id = item.Id})">
                                        <i class="fa fa-plus" aria-hidden="true"></i>
                                    </a>
                                End If

                                @If AppSession.ListActionSousRessource.Contains(12, 4) Then
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



