@ModelType PagedList.IPagedList(Of BordereauTransfert)
@Imports PagedList.Mvc
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.ListBordereauTransfert
End Code

<div class="page-header">
    <h1 class="page-title">@Resource.ManageBordereauTransfert</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "BordereauTransferts")>@Resource.ManageBordereauTransfert</a></li>
        <li class="breadcrumb-item active">@Resource.ListBordereauTransfert</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.ListBordereauTransfert</div>
            <hr>
            @Using Html.BeginForm("Index", "BordereauTransferts", FormMethod.Post, New With {.autocomplete = "off"})
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

            @*<table class="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline form-material floating" id="exampleTableSearch" style="width: 100%;">*@
            <table id="default-datatable" class="table table-bordered dataTable" role="grid" aria-describedby="default-datatable_info">
                <thead>
                    <tr>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.NumeroBordereau, "Index", New With {.sortOrder = ViewBag.NumeroBordereauSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Libelle, "Index", New With {.sortOrder = ViewBag.LibelleSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.DateTransfert, "Index", New With {.sortOrder = ViewBag.DateTransfertSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
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
                                @Html.DisplayFor(Function(modelItem) item.NumeroBordereau)
                            </td>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.Libelle)
                            </td>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.DateTransfert)
                            </td>
                            <td class="text-center">
                                <a class="btn btn-round btn-dark waves-effect waves-light m-1" title="@Resource.BtnPrint" onclick="showReport(@item.Id)" href="#">
                                    <i class="fa fa-print" aria-hidden="true"></i>
                                </a>
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

<div class="modal fade" id="BordereauModal">
    <div class="modal-dialog modal-lg" style="max-width: 1000px !important;">
        <div class="modal-content animated jackInTheBox">
            <div class="modal-header">
                <h5 class="modal-title"><i class="fa fa-star"></i> @Resource.Btn_apercu</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <div Class="row col-sm-12">
                    <div class="embed-responsive embed-responsive-16by9">
                        <iframe id="ifrReport" class="embed-responsive-item"></iframe>
                    </div>
                </div>

            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal"><i class="fa fa-times"></i> @Resource.BtnClose</button>
            </div>
        </div>
    </div>
</div>

@Section Scripts

    @If TempData("BordereauId") IsNot Nothing Then
        @<script>

            $('#BordereauModal').modal('show');

            $('#ifrReport').attr('src', '@Url.Content("~/Report/Report.aspx")?BordereauId=' + @TempData("BordereauId") +  '&type=BordereauTransfert');
        </script>

    End If


    <script>


    function showReport(BordereauId) {
        $('#BordereauModal').modal('show');

        $('#ifrReport').attr('src', '@Url.Content("~/Report/Report.aspx")?BordereauId=' + BordereauId + '&type=BordereauTransfert');
    }
    </script>

End Section
