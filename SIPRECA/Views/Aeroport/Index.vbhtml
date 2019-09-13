﻿@ModelType PagedList.IPagedList(Of Aeroport)
@Imports PagedList.Mvc
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.ListAeroport
End Code

<div class="page-header">
    <h1 class="page-title">@Resource.ManageAeroport</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Aeroport")>@Resource.ManageAeroport</a></li>
        <li class="breadcrumb-item active">@Resource.ListAeroport</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.ListAeroport</div>
            <hr>
            @Using Html.BeginForm("Index", "Aeroport", FormMethod.Post, New With {.autocomplete = "off"})
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
                            @Html.ActionLink(Resource.ICAO, "Index", New With {.sortOrder = ViewBag.ICAOSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.IATA, "Index", New With {.sortOrder = ViewBag.IATASort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Ville, "Index", New With {.sortOrder = ViewBag.VilleSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Organisation, "Index", New With {.sortOrder = ViewBag.OrganisationSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.LongueurDePiste, "Index", New With {.sortOrder = ViewBag.LongueurDePisteSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.LargeurDePiste, "Index", New With {.sortOrder = ViewBag.LargeurDePisteSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.SurfaceDePiste, "Index", New With {.sortOrder = ViewBag.NombreDeLitMaxSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.TailleDeAeronef, "Index", New With {.sortOrder = ViewBag.NombreDeMedecinSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.UsageHumanitaire, "Index", New With {.sortOrder = ViewBag.NombreDInfimiereSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
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
                                @Html.DisplayFor(Function(modelItem) item.ICAO)
                            </td>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.IATA)
                            </td>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.Ville.Libelle)
                            </td>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.Oganisation.Nom)
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.LongueurDePiste)
                            </td>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.LargeurDePiste)
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.SurfaceDePiste.Libelle)
                            </td>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.TailleDeAeronef.Libelle)
                            </td>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.UsageHumanitaire.Libelle)
                            </td>
                            
                            <td class="text-center">
                                <a class="btn btn-round btn-warning waves-effect waves-light m-1" title="@Resource.Btn_Edit" href="@Url.Action("Edit", New With {.id = item.Id})">
                                    <i class="fa fa-edit" aria-hidden="true"></i>
                                </a>
                                <a class="btn btn-round btn-danger waves-effect waves-light m-1" title="@Resource.Btn_Delete" href="@Url.Action("Delete", New With {.id = item.Id})">
                                    <i class="fa fa-trash" aria-hidden="true"></i>
                                </a>

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



