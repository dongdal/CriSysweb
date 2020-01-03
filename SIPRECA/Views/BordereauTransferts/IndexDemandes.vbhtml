@ModelType PagedList.IPagedList(Of Demande)
@Imports PagedList.Mvc
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.ListDemande
End Code

<div class="page-header">
    <h1 class="page-title">@Resource.ManageBordereauTransfert</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "BordereauTransferts")>@Resource.ManageDemande</a></li>
        <li class="breadcrumb-item active">@Resource.ListDemande</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.ListDemande</div>
            <hr>
            @Using Html.BeginForm("IndexDemandes", "BordereauTransferts", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()

                @<div Class="col-sm-12">

                     <div Class="row col-sm-12">
                         @If (AppSession.Niveau.Equals(Util.UserLevel.National) Or AppSession.Niveau.Equals(Util.UserLevel.Regional)) Then
                             @<div Class="col-md-4">
                                 @Html.DropDownList("RegionId", DirectCast(ViewBag.RegionIds, IEnumerable(Of SelectListItem)), Resource.ComboRegion, New With {.class = "form-control single-select", .onchange = "LoadDepartement()"})
                             </div>
                         End If

                         @If (AppSession.Niveau.Equals(Util.UserLevel.National) Or AppSession.Niveau.Equals(Util.UserLevel.Regional) Or AppSession.Niveau.Equals(Util.UserLevel.Departemental)) Then
                             @<div Class="col-md-4">
                                 @Html.DropDownList("DepartementId", DirectCast(ViewBag.DepartementIds, IEnumerable(Of SelectListItem)), Resource.ComboDepartement, New With {.class = "form-control single-select", .onchange = "LoadCommune()"})
                             </div>
                         End If

                         @If (AppSession.Niveau.Equals(Util.UserLevel.National) Or AppSession.Niveau.Equals(Util.UserLevel.Regional) Or AppSession.Niveau.Equals(Util.UserLevel.Departemental) Or AppSession.Niveau.Equals(Util.UserLevel.Communal)) Then
                             @<div Class="col-md-4">
                                 @Html.DropDownList("CommuneId", DirectCast(ViewBag.CommuneIds, IEnumerable(Of SelectListItem)), Resource.CommuneCombo, New With {.class = "form-control single-select"})
                             </div>
                         End If

                         <div class="col-sm-4 text-right">
                             <div class="input-group mb-4">
                                 @Html.TextBox("SearchString", CStr(ViewBag.CurrentFilter), New With {.class = "form-control round", .placeholder = Resource.Find})
                                 <div class="input-group-append">
                                 </div>
                             </div>
                         </div>
                         <div Class="col-sm-2">
                             <div Class="form-group">
                                 <Button Class="btn btn-round  btn btn-dark" type="submit" value="@Resource.BtnFiltrer"> <i class="fa fa-search"></i> @Resource.BtnFiltrer</Button>
                             </div>
                         </div>
                     </div>

                </div>
                @<br />

            End Using

            <br />

            @Using Html.BeginForm("Create", "BordereauTransferts", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()

                @<div Class="form-group row">
                    <Label Class="col-sm-2 col-form-label"></Label>
                    <div Class="col-sm-10">
                        <Button type="submit" Class="btn btn-link btn-square bg-primary text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.BtnTransferer</Button>
                    </div>
                </div>

                @<table id="default-datatable" class="table table-bordered dataTable" role="grid" aria-describedby="default-datatable_info">
                    <thead>
                        <tr>
                            <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                @Resource.ElementsATransferer
                            </th>
                            <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                @Html.ActionLink(Resource.Sinistre, "Index", New With {.sortOrder = ViewBag.CollectiviteSinistreeSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab, .RegionId = ViewBag.PageRegionId, .DepartementId = ViewBag.PageDepartementId, .CommuneId = ViewBag.PageCommuneId})
                            </th>
                            <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                @Html.ActionLink(Resource.LeSinistrer, "Index", New With {.sortOrder = ViewBag.SinistrerSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab, .RegionId = ViewBag.PageRegionId, .DepartementId = ViewBag.PageDepartementId, .CommuneId = ViewBag.PageCommuneId})
                            </th>
                            <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                @Html.ActionLink(Resource.DateDeclaration, "Index", New With {.sortOrder = ViewBag.DateDeclarationSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab, .RegionId = ViewBag.PageRegionId, .DepartementId = ViewBag.PageDepartementId, .CommuneId = ViewBag.PageCommuneId})
                            </th>
                        </tr>
                    </thead>

                    <tbody>
                        @For Each item In Model
                            @<tr>
                                <td class="sorting_asc text-center">
                                    <input type="checkbox" name="TransfertItem" value="@item.Id" style = "width: 19px; height: 19px; cursor: pointer; position: absolute; left: 2px; top: 2px; background: #fff; border: 1px solid #999; display: inline-block; position: relative; margin: 0 auto; float: left;" />
                                </td>
                                <td class="sorting_asc text-center">
                                    @Html.DisplayFor(Function(modelItem) item.CollectiviteSinistree.Sinistre.Libelle)
                                </td>
                                <td class="sorting_asc text-center">
                                    @item.Sinistrer.Nom @item.Sinistrer.Prenom <br /> @Resource.CNI:  @item.Sinistrer.Cni
                                </td>
                                <td class="sorting_asc text-center">
                                    @Html.DisplayFor(Function(modelItem) item.DateDeclaration)
                                </td>

                            </tr>
                        Next
                    </tbody>

                </table>
            End Using

            @Html.PagedListPager(Model, Function(page) Url.Action("Index",
                                                                                                                                  New With {.page = page, .sortOrder = ViewBag.CurrentSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab, .RegionId = ViewBag.PageRegionId, .DepartementId = ViewBag.PageDepartementId, .CommuneId = ViewBag.PageCommuneId}))
            Page @IIf(Model.PageCount < Model.PageNumber, 0, Model.PageNumber)  @Resource.RecordsOn  @Model.PageCount (@ViewBag.EnregCount  @Resource.Records)

        </div>

    </div>
</div>


@Section Scripts




End Section
