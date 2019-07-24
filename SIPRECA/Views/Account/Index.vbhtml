@ModelType PagedList.IPagedList(Of ApplicationUser)
@Imports PagedList.Mvc
@Imports SIPRECA.My.Resources


@Code
    ViewBag.Title = Resource.GestUserIndex
End Code

<div class="page-header">
    <h1 class="page-title">@Resource.Menu_UserManager</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Account")>@Resource.Menu_UserManager</a></li>
        <li class="breadcrumb-item active">@Resource.GestUserIndex</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.GestUserIndex</div>
            <hr>
            @Using Html.BeginForm("Index", "Account", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()
                @<div Class="form-inline padding-bottom-1">
                    <div Class="row col-sm-12">
                        <div Class="col-sm-8">
                            <div Class="form-group">
                                <a class="btn btn-round btn-primary waves-effect waves-light m-1" title="@Resource.Btn_nouveau" href="@Url.Action("Register")">
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

            @*<table class="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline form-material floating" id="exampleTableSearch" style="width: 100%;">*@
            <table id="default-datatable" class="table table-bordered dataTable" role="grid" aria-describedby="default-datatable_info">
                <thead>
                    <tr>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.GestUserUserName, "Index", New With {.sortOrder = ViewBag.UserNameSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Noms, "Index", New With {.sortOrder = ViewBag.NomSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Prenoms, "Index", New With {.sortOrder = ViewBag.PrenomSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Sexe, "Index", New With {.sortOrder = ViewBag.SexeSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.CNI, "Index", New With {.sortOrder = ViewBag.CNISort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab})
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
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.UserName)
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.Nom)
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.Prenom)
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.Sexe)
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.CNI)
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.Telephone)
                            </td>
                            <td class="text-center">
                                <a class="btn btn-round btn-warning waves-effect waves-light m-1" title="@Resource.Btn_Edit" href="@Url.Action("Edit", New With {.id = item.Id})">
                                    <i class="fa fa-edit" aria-hidden="true"></i>
                                </a>
                                <a class="btn btn-round btn-info waves-effect waves-light m-1" title="@Resource.Btn_Detail" href="#" data-toggle="modal" data-target="#@item.UserName">
                                    <i class="fa fa-info" aria-hidden="true"></i>
                                </a>
                                <a class="btn btn-round btn-danger waves-effect waves-light m-1" title="@Resource.Btn_GestUserRoles" href="@Url.Action("UserRoles", New With {.id = item.Id})">
                                    <i class="fa fa-users" aria-hidden="true"></i>
                                </a>

                                <div class="modal fade" id="@item.UserName">
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
                                                            <label for="UserName" class="col-form-label">@Resource.GestUserName : </label>
                                                            @Html.DisplayFor(Function(m) item.UserName, New With {.class = "form-control", .disabled = "disabled"})
                                                        </div>
                                                        <br />

                                                        <div class="form-group">
                                                            <label for="Nom" class="col-form-label">@Resource.Noms : </label>
                                                            @Html.DisplayFor(Function(m) item.Nom, New With {.class = "form-control", .disabled = "disabled"})
                                                        </div>
                                                        <br />

                                                        <div class="form-group">
                                                            <label for="Prenom" class="col-form-label">@Resource.Prenoms : </label>
                                                            @Html.DisplayFor(Function(m) item.Prenom, New With {.class = "form-control", .disabled = "disabled"})
                                                        </div>
                                                        <br />

                                                        <div class="form-group">
                                                            <label for="DateNaissance" class="col-form-label">@Resource.DateNaissance : </label>
                                                            @Html.DisplayFor(Function(m) item.DateNaissance, New With {.class = "form-control", .disabled = "disabled"})
                                                        </div>
                                                        <br />

                                                        <div class="form-group">
                                                            <label for="LieuNaissance" class="col-form-label">@Resource.LieuNaissance : </label>
                                                            @Html.DisplayFor(Function(m) item.LieuNaissance, New With {.class = "form-control", .disabled = "disabled"})
                                                        </div>
                                                        <br />

                                                        <div class="form-group">
                                                            <label for="Sexe" class="col-form-label">@Resource.Sexe : </label>
                                                            @Html.DisplayFor(Function(m) item.Sexe, New With {.class = "form-control", .disabled = "disabled"})
                                                        </div>
                                                        <br />


                                                    </div>

                                                    <div class="col-sm-6 form-group">

                                                        <div class="form-group">
                                                            <label for="Telephone" class="col-form-label">@Resource.Telephone : </label>
                                                            @Html.DisplayFor(Function(m) item.Telephone, New With {.class = "form-control", .disabled = "disabled"})
                                                        </div>
                                                        <br />

                                                        <div class="form-group">
                                                            <label for="CNI" class="col-form-label">@Resource.CNI : </label>
                                                            @Html.DisplayFor(Function(m) item.CNI, New With {.class = "form-control", .disabled = "disabled"})
                                                        </div>
                                                        <br />

                                                        <div class="form-group">
                                                            <label for="DateDelivranceCNI" class="col-form-label">@Resource.DateDelivranceCNI : </label>
                                                            @Html.DisplayFor(Function(m) item.DateDelivranceCNI, New With {.class = "form-control", .disabled = "disabled"})
                                                        </div>
                                                        <br />

                                                        <div class="form-group">
                                                            <label for="DateExpirationCNI" class="col-form-label">@Resource.DateExpirationCNI : </label>
                                                            @Html.DisplayFor(Function(m) item.DateExpirationCNI, New With {.class = "form-control", .disabled = "disabled"})
                                                        </div>
                                                        <br />

                                                        <div class="form-group">
                                                            <label for="Email" class="col-form-label">@Resource.Email : </label>
                                                            @Html.DisplayFor(Function(m) item.Email, New With {.class = "form-control", .disabled = "disabled"})
                                                        </div>
                                                        <br />

                                                        <div class="form-group">
                                                            <label for="DateCreation" class="col-form-label">@Resource.DateCreation : </label>
                                                            @Html.DisplayFor(Function(m) item.DateCreation, New With {.class = "form-control", .disabled = "disabled"})
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



