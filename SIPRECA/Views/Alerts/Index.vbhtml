﻿@ModelType PagedList.IPagedList(Of Alert)
@Imports PagedList.Mvc
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.ListAlerts
    Layout = "~/Views/Shared/_LayoutAlertes.vbhtml"
End Code

<div class="page-header">
    <h1 class="page-title">@Resource.ManageDemande</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Alerts")>@Resource.ManageAlert</a></li>
        <li class="breadcrumb-item active">@Resource.ListAlerts</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.ListAlerts</div>
            <hr>
            @Using Html.BeginForm("Index", "Alerts", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()
                @<div Class="form-inline padding-bottom-1">
                     <div Class="row col-sm-12">
                         <div Class="col-sm-2">
                             <div Class="form-group">
                                 <a class="btn btn-round btn-primary waves-effect waves-light m-1"  title="@Resource.SendSMS" href="@Url.Action("SendSMS")">
                                     <i Class="fa fa-envelope" aria-hidden="true"></i>
                                     @Resource.SendSMS
                                 </a>
                             </div>
                         </div>
                         <div Class="col-sm-2">
                             <div Class="form-group">
                                 <a class="btn btn-round btn-primary waves-effect waves-light m-1" style="background:#7f00ff;" title="@Resource.SendMail" href="@Url.Action("SendMail")">
                                     <i Class="fa fa-send" aria-hidden="true"></i>
                                     @Resource.SendMail
                                 </a>
                             </div>
                         </div>

                         <div Class="col-sm-3">
                             <div Class="col-md-12">
                                 @Html.DropDownList("TypeAlerteFilter", DirectCast(ViewBag.TypeAlerte, IEnumerable(Of SelectListItem)), Resource.TypeAlerteCombo, New With {.class = "form-control single-select"})
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
            <table id="default-datatable" class="table table-responsive dataTable" role="grid" aria-describedby="default-datatable_info">
                <thead>
                    <tr>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Contenu, "Index", New With {.sortOrder = ViewBag.ContenuSort, .currentFilter = ViewBag.CurrentFilter, .TypeAlerteFilter = ViewBag.TypeAlerteFilter})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.SinistreConcernes, "Index", New With {.sortOrder = ViewBag.SinistrerSort, .currentFilter = ViewBag.CurrentFilter, .TypeAlerteFilter = ViewBag.TypeAlerteFilter})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Organisation, "Index", New With {.sortOrder = ViewBag.OrganisationSort, .currentFilter = ViewBag.CurrentFilter, .TypeAlerteFilter = ViewBag.TypeAlerteFilter})
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
                            <td class="text-center">
                                <a class="btn btn-round btn-warning waves-effect waves-light m-1" title="@Resource.Btn_Detail" href="@Url.Action("Detail", New With {.id = item.Id})">
                                    <i class="fa fa-edit" aria-hidden="true"></i>
                                </a>
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