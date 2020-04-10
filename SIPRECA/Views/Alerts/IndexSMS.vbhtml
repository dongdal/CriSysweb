@ModelType PagedList.IPagedList(Of Alert)
@Imports PagedList.Mvc
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.ListAlertsSMS
    Layout = "~/Views/Shared/_LayoutAlertes.vbhtml"
End Code

<div class="page-header">
    <h1 class="page-title">@Resource.ManageDemande</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Alerts")>@Resource.ManageAlert</a></li>
        <li class="breadcrumb-item active">@Resource.ListAlertsSMS</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.ListAlertsSMS</div>
            <hr>
            @Using Html.BeginForm("IndexSMS", "Alerts", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()
                @<div Class="form-inline padding-bottom-1">
                    <div Class="row col-sm-12">
                        <div Class="col-sm-2">
                            <div Class="form-group">
                                @If AppSession.ListActionSousRessource.Contains(59, 1) Then
                                    @<a class="btn btn-round btn-primary waves-effect waves-light m-1" title="@Resource.SendSMS" href="@Url.Action("SendSMS")">
                                        <i Class="fa fa-envelope" aria-hidden="true"></i>
                                        @Resource.SendSMS
                                    </a>
                                End If
                            </div>
                        </div>

                        <div class="col-sm-3 text-right">
                            <div class="input-group mb-4">
                                @Html.TextBox("SearchString", CStr(ViewBag.CurrentFilter), New With {.class = "form-control round", .placeholder = Resource.Find})
                                <div class="input-group-append">
                                    @*<button class="btn btn-primary" type="submit"><i class="fa fa-search"></i></button>*@
                                </div>
                            </div>
                        </div>

                        <div Class="col-sm-2">
                            <div Class="form-group">
                                <button class="btn btn-round  btn btn-dark" type="submit" value="@Resource.BtnFiltrer"> <i class="fa fa-search"></i> @Resource.BtnFiltrer</button>
                            </div>
                        </div>

                    </div>
                </div>

            End Using

            <br />

            <table id="default-datatable" class="table table-bordered dataTable" role="grid" aria-describedby="default-datatable_info">
                <thead>
                    <tr>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Contenu, "Index", New With {.sortOrder = ViewBag.ContenuSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.SinistreConcernes, "Index", New With {.sortOrder = ViewBag.SinistrerSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Organisation, "Index", New With {.sortOrder = ViewBag.OrganisationSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
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
                                @Html.DisplayFor(Function(modelItem) item.Contenu)
                            </td>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.Sinistre.Libelle)
                            </td>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.Organisation.Nom)
                            </td>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.DateCreation)
                            </td>

                            <td class="text-center">

                            </td>
                        </tr>
                    Next
                </tbody>

            </table>

            @Html.PagedListPager(Model, Function(page) Url.Action("Index",
                                                                                                                             New With {.page = page, .sortOrder = ViewBag.CurrentSort, .currentFilter = ViewBag.CurrentFilter, .RegionId = ViewBag.PageRegionId, .DepartementId = ViewBag.PageDepartementId, .CommuneId = ViewBag.PageCommuneId, .EtatAvancement = ViewBag.EtatAvancement}))
            Page @IIf(Model.PageCount < Model.PageNumber, 0, Model.PageNumber) @Resource.RecordsOn @Model.PageCount (@ViewBag.EnregCount @Resource.Records)

        </div>

    </div>
</div>