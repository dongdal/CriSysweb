@ModelType PagedList.IPagedList(Of EvenementZone)
@Imports PagedList.Mvc
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.ListEvenementZone
    Layout = "~/Views/Shared/_LayoutDesinventar.vbhtml"
End Code

<div class="page-header">
    <h1 class="page-title">@Resource.ManageEvenementZone</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "EvenementZones")>@Resource.ManageEvenementZone</a></li>
        <li class="breadcrumb-item active">@Resource.ListEvenementZone</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.ListEvenementZone</div>
            <hr>
            @Using Html.BeginForm("Index", "EvenementZones", FormMethod.Post, New With {.autocomplete = "off"})
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
                            @Html.ActionLink(Resource.ZoneARisque, "Index", New With {.sortOrder = ViewBag.DateDeNaissanceSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Evenement, "Index", New With {.sortOrder = ViewBag.TelephoneSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
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
                                @Html.DisplayFor(Function(modelItem) item.ZoneARisque.Libelle)
                            </td>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.Evenement.Libelle)
                            </td>

                            <td class="text-center">
                                <a class="btn btn-round btn-warning waves-effect waves-light m-1" title="@Resource.Btn_Edit" href="@Url.Action("Edit", New With {.id = item.Id})">
                                    <i class="fa fa-edit" aria-hidden="true"></i>
                                </a>

                                <a class="btn btn-round btn-info waves-effect waves-light m-1 nav-link dropdown-toggle dropdown-toggle-nocaret waves-effect" 
                                   title="@Resource.CadreSendai" href="javascript:void();"  data-toggle="dropdown">
                                    <i class="icon-list" aria-hidden="true"></i>
                                </a>
                                <div Class="dropdown-menu dropdown-menu-right animated fadeIn">
                                    <ul Class="list-group list-group-flush">
                                        <li Class="list-group-item d-flex justify-content-between align-items-center" style="font-size: 12px;">
                                            @Resource.CadreSendai
                                        </li>
                                        <li Class="list-group-item">
                                            <a href="@Url.Action("Edit", "CardreSendaiCibleA", New With {.EvenementZoneId = item.Id})">
                                                <div class="media">
                                                    <i class="icon-note mr-3 text-info"></i>
                                                    <div class="media-body">
                                                        <h6 class="mt-0 msg-title" style="font-size: 12px;">@Resource.CadreSendaiA</h6>
                                                    </div>
                                                </div>
                                            </a>
                                        </li>
                                        <li Class="list-group-item">
                                            <a href="@Url.Action("Edit", "CardreSendaiCibleB", New With {.EvenementZoneId = item.Id})">
                                                <div class="media">
                                                    <i class="icon-note mr-3 text-info"></i>
                                                    <div class="media-body">
                                                        <h6 class="mt-0 msg-title" style="font-size: 12px;">@Resource.CadreSendaiB</h6>
                                                    </div>
                                                </div>
                                            </a>
                                        </li>
                                        <li Class="list-group-item">
                                            <a href="@Url.Action("Edit", "CardreSendaiCibleC", New With {.EvenementZoneId = item.Id})">
                                                <div class="media">
                                                    <i class="icon-note mr-3 text-info"></i>
                                                    <div class="media-body">
                                                        <h6 class="mt-0 msg-title" style="font-size: 12px;">@Resource.CadreSendaiC</h6>
                                                    </div>
                                                </div>
                                            </a>
                                        </li>
                                        <li Class="list-group-item">
                                            <a href="@Url.Action("Edit", "CardreSendaiCibleD", New With {.EvenementZoneId = item.Id})">
                                                <div class="media">
                                                    <i class="icon-note mr-3 text-info"></i>
                                                    <div class="media-body">
                                                        <h6 class="mt-0 msg-title" style="font-size: 12px;">@Resource.CadreSendaiD</h6>
                                                    </div>
                                                </div>
                                            </a>
                                        </li>
                                        <li Class="list-group-item">
                                            <a href="@Url.Action("Edit", "AutreImpactHumainEtEconomique", New With {.EvenementZoneId = item.Id})">
                                                <div class="media">
                                                    <i class="icon-note mr-3 text-info"></i>
                                                    <div class="media-body">
                                                        <h6 class="mt-0 msg-title" style="font-size: 12px;">@Resource.AutreImpactHumainEtEconomique</h6>
                                                    </div>
                                                </div>
                                            </a>
                                        </li>
                                    </ul>
                                </div>

                                @*<a class="btn btn-round btn-danger waves-effect waves-light m-1" title="@Resource.Btn_Delete" href="@Url.Action("Delete", New With {.id = item.Id})">
            <i class="fa fa-trash" aria-hidden="true"></i>
        </a>*@

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



