@Imports SIPRECA.My.Resources
@Code
    ViewData("Title") = Resource.HomePage
    Layout = "~/Views/Shared/_LayoutPrincipal.vbhtml"
End Code

<div class="container-fluid">
    <!-- Breadcrumb-->
    <div class="page-header">
        @*<h1 class="page-title">@Resource.Menu_Home</h1>*@
        <ol class="breadcrumb">
            @*<li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>*@
            @*<li class="breadcrumb-item"><a href=@Url.Action("Index", "Account")>@Resource.ManageRegion</a></li>
                <li class="breadcrumb-item active">@Resource.ListRegion</li>*@
        </ol>
    </div>

    <!-- End Breadcrumb-->
    <h6 class="text-uppercase">@Resource.ModuleList</h6>
    <hr>
    @If AppSession.ModuleUserList.Contains(1) Or AppSession.ModuleUserList.Contains(2) Or AppSession.ModuleUserList.Contains(3) Or AppSession.ModuleUserList.Contains(4) Then
        @<div Class="row">
            @If AppSession.ModuleUserList.Contains(1) Then
                @<div Class="col-lg-3">
                    <div Class="card card-success">
                        <a href="javascript:void();" data-toggle="modal" data-target="#primarymodal"><img src="~/assets/images/gallery/1.jpg" Class="card-img-top" alt="Card image cap"></a>
                        <div Class="card-body">
                            <h5 Class="card-title text-primary" style="text-align:center">@Resource.ModuleSinistrer</h5>
                        </div>
                    </div>
                </div>

            End If

            @If AppSession.ModuleUserList.Contains(2) Then
                @<div Class="col-lg-3">
                    <div Class="card card-success">
                        <a href="@Url.Action("IndexSahana")"><img src="~/assets/images/gallery/Module_Sahana.jpg" Class="card-img-top" alt="Card image cap"></a>
                        <div Class="card-body">
                            <h5 Class="card-title text-primary" style="text-align:center">@Resource.ModuleSahana</h5>
                        </div>
                    </div>
                </div>

            End If

            @If AppSession.ModuleUserList.Contains(3) Then
                @<div Class="col-lg-3">
                    <div Class="card card-success">
                        <a href="@Url.Action("IndexDesinventar")"><img src="~/assets/images/gallery/1.jpg" Class="card-img-top" alt="Card image cap"></a>
                        <div Class="card-body">
                            <h5 Class="card-title text-primary" style="text-align:center">@Resource.ModuleDesinventar</h5>
                        </div>
                    </div>
                </div>
            End If

            @If AppSession.ModuleUserList.Contains(4) Then
                @<div Class="col-lg-3">
                    <div Class="card card-success">
                        <a href="@Url.Action("IndexCollecte")"><img src="~/assets/images/gallery/Collect-Form-Picture.png" Class="card-img-top" alt="Card image cap"></a>
                        <div Class="card-body">
                            <h5 Class="card-title text-primary" style="text-align:center">@Resource.ModuleCollecte</h5>
                        </div>
                    </div>
                </div>

            End If
        </div>
    End If

    @If AppSession.ModuleUserList.Contains(5) Or AppSession.ModuleUserList.Contains(6) Or AppSession.ModuleUserList.Contains(7) Then
        @<div class="row">
            @If AppSession.ModuleUserList.Contains(5) Then
                @<div class="col-lg-3">
                    <div class="card card-success">
                        <a href="@Url.Action("IndexAlertes")"><img src="~/assets/images/gallery/iconfinder_bell-notifications-notice-notify-alert_3993856.png" class="card-img-top" alt="Card image cap"></a>
                        <div class="card-body">
                            <h5 class="card-title text-primary" style="text-align:center">@Resource.ModuleAlerte</h5>
                        </div>
                    </div>
                </div>
            End If

            @If AppSession.ModuleUserList.Contains(6) Then
                @<div class="col-lg-3">
                    <div class="card card-success">
                        <a href="@Url.Action("IndexParam")"><img src="~/assets/images/gallery/iconfinder_freebies1_glyph-13_2920356.png" class="card-img-top" alt="Card image cap"></a>
                        <div class="card-body">
                            <h5 class="card-title text-primary" style="text-align:center">@Resource.Menu_UserManager</h5>
                        </div>
                    </div>
                </div>
            End If

            @If AppSession.ModuleUserList.Contains(7) Then
                @<div class="col-lg-3">
                    <div class="card card-success">
                        <a href="@Url.Action("IndexReport")"><img src="~/assets/images/gallery/analytics-1925495_1920.png" class="card-img-top" alt="Card image cap"></a>
                        <div class="card-body">
                            <h5 class="card-title text-primary" style="text-align:center">@Resource.ModuleReport</h5>
                        </div>
                    </div>
                </div>
            End If

        </div>
    End If
</div>
<!-- End container-fluid-->
<!--Primary Modal -->
<div class="modal fade" id="primarymodal">
    <div class="modal-dialog">
        @Using Html.BeginForm("IndexSinistre", "Home", FormMethod.Post, New With {.autocomplete = "off"})
            @Html.AntiForgeryToken()
            @<div class="modal-content border-primary">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title text-white"><i class="fa fa-star"></i> @Resource.ComboAnneeBudgetaire</h5>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">

                    @Html.DropDownList("AnneeBudgetaireId", DirectCast(ViewBag.LesAnneesBudgetaires,
                                                 IEnumerable(Of SelectListItem)), Resource.ComboAnneeBudgetaire, New With {.class = "form-control single-select"})

                </div>
                <div class="modal-footer">
                    <button type="submit" class="btn btn-primary"><i class="fa fa-check-square-o"></i> @Resource.BtnValidate</button>
                    <button type="button" class="btn btn-inverse-primary" data-dismiss="modal"><i class="fa fa-times"></i> @Resource.BtnClose</button>
                </div>
            </div>
        End Using
    </div>
</div>

<!--End Modal -->
@*<div class="container-fluid">
        <!--Start Dashboard Content-->

        <div class="row mt-4">
            <div class="col-12 col-lg-6 col-xl-3">
                <div class="card gradient-purpink">
                    <div class="card-body">
                        <div class="media">
                            <div class="media-body text-left">
                                <h4 class="text-white">$4530</h4>
                                <span class="text-white">Revenue</span>
                            </div>
                            <div class="align-self-center"><span id="dash-chart-1"></span></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12 col-lg-6 col-xl-3">
                <div class="card gradient-scooter">
                    <div class="card-body">
                        <div class="media">
                            <div class="media-body text-left">
                                <h4 class="text-white">2500</h4>
                                <span class="text-white">Total Orders</span>
                            </div>
                            <div class="align-self-center"><span id="dash-chart-2"></span></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12 col-lg-6 col-xl-3">
                <div class="card gradient-ibiza">
                    <div class="card-body">
                        <div class="media">
                            <div class="media-body text-left">
                                <h4 class="text-white">7850</h4>
                                <span class="text-white">Comments</span>
                            </div>
                            <div class="align-self-center"><span id="dash-chart-3"></span></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12 col-lg-6 col-xl-3">
                <div class="card gradient-ohhappiness">
                    <div class="card-body">
                        <div class="media">
                            <div class="media-body text-left">
                                <h4 class="text-white">3524</h4>
                                <span class="text-white">Total Views</span>
                            </div>
                            <div class="align-self-center"><span id="dash-chart-4"></span></div>
                        </div>
                    </div>
                </div>
            </div>
        </div><!--End Row-->
        <div class="row">
            <div class="col-12 col-lg-12 col-xl-12">
                <div class="card">
                    <div class="card-header">
                        Product Sales
                        <div class="card-action">
                            <div class="dropdown">
                                <a href="javascript:void();" class="dropdown-toggle dropdown-toggle-nocaret" data-toggle="dropdown">
                                    <i class="icon-options"></i>
                                </a>
                                <div class="dropdown-menu animated fadeIn dropdown-menu-right">
                                    <a class="dropdown-item" href="javascript:void();">Action</a>
                                    <a class="dropdown-item" href="javascript:void();">Another action</a>
                                    <a class="dropdown-item" href="javascript:void();">Something else here</a>
                                    <div class="dropdown-divider"></div>
                                    <a class="dropdown-item" href="javascript:void();">Separated link</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <canvas id="dash-chart-5" height="100"></canvas>
                        <div class="row">
                            <div class="col-12">
                                <div class="card bg-transparent shadow-none mb-0">
                                    <div class="card-content">
                                        <div class="row row-group m-0">
                                            <div class="col-12 col-lg-6 col-xl-3">
                                                <div class="card-body text-center">
                                                    <h3 class="text-danger">$157</h3>
                                                    <span>Today's Sales</span>
                                                </div>
                                            </div>
                                            <div class="col-12 col-lg-6 col-xl-3">
                                                <div class="card-body text-center">
                                                    <h3 class="text-warning">$1423</h3>
                                                    <span>This Week Sales</span>
                                                </div>
                                            </div>
                                            <div class="col-12 col-lg-6 col-xl-3">
                                                <div class="card-body text-center">
                                                    <h3 class="text-success">$6500</h3>
                                                    <span>This Month Sales</span>
                                                </div>
                                            </div>
                                            <div class="col-12 col-lg-6 col-xl-3">
                                                <div class="card-body text-center">
                                                    <h3 class="text-info">$45,624</h3>
                                                    <span>This Year Sales</span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div><!--End Row-->
                    </div>
                </div>
            </div>
        </div><!--End Row-->

        <div class="row">
            <div class="col-12 col-lg-6 col-xl-6">
                <div class="card">
                    <div class="card-header">
                        Top Selling Categories
                        <div class="card-action">
                            <div class="dropdown">
                                <a href="javascript:void();" class="dropdown-toggle dropdown-toggle-nocaret" data-toggle="dropdown">
                                    <i class="icon-options"></i>
                                </a>
                                <div class="dropdown-menu animated fadeIn dropdown-menu-right">
                                    <a class="dropdown-item" href="javascript:void();">Action</a>
                                    <a class="dropdown-item" href="javascript:void();">Another action</a>
                                    <a class="dropdown-item" href="javascript:void();">Something else here</a>
                                    <div class="dropdown-divider"></div>
                                    <a class="dropdown-item" href="javascript:void();">Separated link</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <canvas id="dash-chart-6"></canvas>
                    </div>
                </div>
            </div>
            <div class="col-12 col-lg-6 col-xl-6">
                <div class="card">
                    <div class="card-header">
                        Product Views
                        <div class="card-action">
                            <div class="dropdown">
                                <a href="javascript:void();" class="dropdown-toggle dropdown-toggle-nocaret" data-toggle="dropdown">
                                    <i class="icon-options"></i>
                                </a>
                                <div class="dropdown-menu animated fadeIn dropdown-menu-right">
                                    <a class="dropdown-item" href="javascript:void();">Action</a>
                                    <a class="dropdown-item" href="javascript:void();">Another action</a>
                                    <a class="dropdown-item" href="javascript:void();">Something else here</a>
                                    <div class="dropdown-divider"></div>
                                    <a class="dropdown-item" href="javascript:void();">Separated link</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <canvas id="dash-chart-7"></canvas>
                    </div>
                </div>
            </div>
        </div><!--End Row-->
        <div class="row">
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-header border-0">
                        Recent Orders
                        <div class="card-action">
                            <div class="dropdown">
                                <a href="javascript:void();" class="dropdown-toggle dropdown-toggle-nocaret" data-toggle="dropdown">
                                    <i class="icon-options"></i>
                                </a>
                                <div class="dropdown-menu animated fadeIn dropdown-menu-right">
                                    <a class="dropdown-item" href="javascript:void();">Action</a>
                                    <a class="dropdown-item" href="javascript:void();">Another action</a>
                                    <a class="dropdown-item" href="javascript:void();">Something else here</a>
                                    <div class="dropdown-divider"></div>
                                    <a class="dropdown-item" href="javascript:void();">Separated link</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="table-responsive">
                        <table class="table align-items-center table-flush">
                            <thead>
                                <tr>
                                    <th>Photo</th>
                                    <th>Product</th>
                                    <th>Amount</th>
                                    <th>Status</th>
                                    <th>Completion</th>
                                    <th>Date</th>
                                </tr>
                            </thead>
                            <tr>
                                <td>
                                    <img alt="Image placeholder" src="~/assets/images/products/1.png" class="product-img">
                                </td>
                                <td>Headphone GL</td>
                                <td>$1,840 USD</td>
                                <td>
                                    <span class="badge-dot">
                                        <i class="bg-danger"></i> pending
                                    </span>
                                </td>
                                <td>
                                    <div class="progress shadow" style="height: 4px;">
                                        <div class="progress-bar gradient-ibiza" role="progressbar" style="width: 60%"></div>
                                    </div>
                                </td>
                                <td>10 July 2018</td>
                            </tr>
                            <tr>
                                <td>
                                    <img alt="Image placeholder" src="~/assets/images/products/2.png" class="product-img">
                                </td>
                                <td>Clasic Shoes</td>
                                <td>$1,520 USD</td>
                                <td>
                                    <span class="badge-dot">
                                        <i class="bg-success"></i> completed
                                    </span>
                                </td>
                                <td>
                                    <div class="progress shadow" style="height: 4px;">
                                        <div class="progress-bar gradient-ohhappiness" role="progressbar" style="width: 100%"></div>
                                    </div>
                                </td>
                                <td>12 July 2018</td>
                            </tr>
                            <tr>
                                <td>
                                    <img alt="Image placeholder" src="~/assets/images/products/3.png" class="product-img">
                                </td>
                                <td>Hand Watch</td>
                                <td>$1,620 USD</td>
                                <td>
                                    <span class="badge-dot">
                                        <i class="bg-warning"></i> delayed
                                    </span>
                                </td>
                                <td>
                                    <div class="progress shadow" style="height: 4px;">
                                        <div class="progress-bar gradient-orange" role="progressbar" style="width: 70%"></div>
                                    </div>
                                </td>
                                <td>14 July 2018</td>
                            </tr>
                            <tr>
                                <td>
                                    <img alt="Image placeholder" src="~/assets/images/products/4.png" class="product-img">
                                </td>
                                <td>Hand Camera</td>
                                <td>$2,220 USD</td>
                                <td>
                                    <span class="badge-dot">
                                        <i class="bg-info"></i> on schedule
                                    </span>
                                </td>
                                <td>
                                    <div class="progress shadow" style="height: 4px;">
                                        <div class="progress-bar gradient-scooter" role="progressbar" style="width: 85%"></div>
                                    </div>
                                </td>
                                <td>16 July 2018</td>
                            </tr>
                            <tr>
                                <td>
                                    <img alt="Image placeholder" src="~/assets/images/products/5.png" class="product-img">
                                </td>
                                <td>Iphone-X Pro</td>
                                <td>$9,890 USD</td>
                                <td>
                                    <span class="badge-dot">
                                        <i class="bg-success"></i> completed
                                    </span>
                                </td>
                                <td>
                                    <div class="progress shadow" style="height: 4px;">
                                        <div class="progress-bar gradient-ohhappiness" role="progressbar" style="width: 100%"></div>
                                    </div>
                                </td>
                                <td>17 July 2018</td>
                            </tr>
                            <tr>
                                <td>
                                    <img alt="Image placeholder" src="~/assets/images/products/6.png" class="product-img">
                                </td>
                                <td>Ladies Purse</td>
                                <td>$3,420 USD</td>
                                <td>
                                    <span class="badge-dot">
                                        <i class="bg-danger"></i> pending
                                    </span>
                                </td>
                                <td>
                                    <div class="progress shadow" style="height: 4px;">
                                        <div class="progress-bar gradient-ibiza" role="progressbar" style="width: 80%"></div>
                                    </div>
                                </td>
                                <td>18 July 2018</td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div><!--End Row-->
        <div class="row">
            <div class="col-12 col-lg-6 col-xl-6">
                <div class="card">
                    <div class="card-header">
                        Top Selling Country
                        <div class="card-action">
                            <div class="dropdown">
                                <a href="javascript:void();" class="dropdown-toggle dropdown-toggle-nocaret" data-toggle="dropdown">
                                    <i class="icon-options"></i>
                                </a>
                                <div class="dropdown-menu animated fadeIn dropdown-menu-right">
                                    <a class="dropdown-item" href="javascript:void();">Action</a>
                                    <a class="dropdown-item" href="javascript:void();">Another action</a>
                                    <a class="dropdown-item" href="javascript:void();">Something else here</a>
                                    <div class="dropdown-divider"></div>
                                    <a class="dropdown-item" href="javascript:void();">Separated link</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">

                        <div id="dashboard-map" style="height: 210px"></div>

                        <p><i class="flag-icon flag-icon-us mr-1"></i> USA <span class="float-right">50%</span></p>
                        <div class="progress" style="height: 5px;">
                            <div class="progress-bar gradient-royal" role="progressbar" style="width: 50%"></div>
                        </div>
                        <p class="mt-3"><i class="flag-icon flag-icon-ca mr-1"></i> Canada <span class="float-right">65%</span></p>
                        <div class="progress" style="height: 5px;">
                            <div class="progress-bar gradient-ibiza" role="progressbar" style="width: 65%"></div>
                        </div>
                        <p class="mt-3"><i class="flag-icon flag-icon-gb mr-1"></i> England <span class="float-right">85%</span></p>
                        <div class="progress" style="height: 5px;">
                            <div class="progress-bar gradient-meridian" role="progressbar" style="width: 85%"></div>
                        </div>
                        <p class="mt-3"><i class="flag-icon flag-icon-au mr-1"></i> Australia <span class="float-right">75%</span></p>
                        <div class="progress" style="height: 5px;">
                            <div class="progress-bar gradient-orange" role="progressbar" style="width: 75%"></div>
                        </div>
                        <p class="mt-3"><i class="flag-icon flag-icon-in mr-1"></i> India <span class="float-right">45%</span></p>
                        <div class="progress" style="height: 5px;">
                            <div class="progress-bar gradient-violet" role="progressbar" style="width: 55%"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12 col-lg-6 col-xl-6">

                <div class="card">
                    <div class="card-header border-0">
                        Traffic Resources
                        <div class="card-action">
                            <div class="dropdown">
                                <a href="javascript:void();" class="dropdown-toggle dropdown-toggle-nocaret" data-toggle="dropdown">
                                    <i class="icon-options"></i>
                                </a>
                                <div class="dropdown-menu animated fadeIn dropdown-menu-right">
                                    <a class="dropdown-item" href="javascript:void();">Action</a>
                                    <a class="dropdown-item" href="javascript:void();">Another action</a>
                                    <a class="dropdown-item" href="javascript:void();">Something else here</a>
                                    <div class="dropdown-divider"></div>
                                    <a class="dropdown-item" href="javascript:void();">Separated link</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="table-responsive">
                        <table class="table align-items-center table-flush">
                            <thead>
                                <tr>
                                    <th>Source</th>
                                    <th>Path</th>
                                    <th>Visits</th>
                                </tr>
                            </thead>
                            <tr>
                                <td><i class="fa fa-google-plus text-google"></i> Google</td>
                                <td>google.com</td>
                                <td>45 <span class="ml-3" id="dash-chart-8"></span></td>
                            </tr>
                            <tr>
                                <td><i class="fa fa-facebook-square text-facebook"></i> Facebook</td>
                                <td>facebook.com</td>
                                <td>56 <span class="ml-3" id="dash-chart-9"></span></td>
                            </tr>
                            <tr>
                                <td><i class="fa fa-twitter text-twitter"></i> Twitter</td>
                                <td>twitter.com</td>
                                <td>42 <span class="ml-3" id="dash-chart-10"></span></td>
                            </tr>
                            <tr>
                                <td><i class="fa fa-linkedin-square text-linkedin"></i> Linkedin</td>
                                <td>linkedin.com</td>
                                <td>52 <span class="ml-3" id="dash-chart-11"></span></td>
                            </tr>
                            <tr>
                                <td><i class="fa fa-behance text-behance"></i> Behance</td>
                                <td>behance.com</td>
                                <td>62 <span class="ml-3" id="dash-chart-12"></span></td>
                            </tr>
                            <tr>
                                <td><i class="fa fa-dribbble text-dribble"></i> Dribble</td>
                                <td>dribble.com</td>
                                <td>72 <span class="ml-3" id="dash-chart-13"></span></td>
                            </tr>
                            <tr>
                                <td><i class="fa fa-github text-github"></i> Github</td>
                                <td>github.com</td>
                                <td>33 <span class="ml-3" id="dash-chart-14"></span></td>
                            </tr>
                        </table>

                    </div>
                </div>

                <div class="card gradient-orange">
                    <div class="card-body">
                        <div class="media">
                            <div class="align-self-center"><span id="dash-chart-15"></span></div>
                            <div class="media-body text-right">
                                <h4 class="text-white">82.56 %</h4>
                                <span class="text-white">Bounce Rate</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div><!--End Row-->

        <div class="card-group">
            <div class="card border-right">
                <div class="card-header">
                    Sales This Week
                    <div class="card-action">
                        <div class="dropdown">
                            <a href="javascript:void();" class="dropdown-toggle dropdown-toggle-nocaret" data-toggle="dropdown">
                                <i class="icon-options"></i>
                            </a>
                            <div class="dropdown-menu animated fadeIn dropdown-menu-right">
                                <a class="dropdown-item" href="javascript:void();">Action</a>
                                <a class="dropdown-item" href="javascript:void();">Another action</a>
                                <a class="dropdown-item" href="javascript:void();">Something else here</a>
                                <div class="dropdown-divider"></div>
                                <a class="dropdown-item" href="javascript:void();">Separated link</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <canvas id="dash-chart-16" height="180"></canvas>
                </div>
                <ul class="list-group list-group-flush list shadow-none">
                    <li class="list-group-item d-flex justify-content-between align-items-center">Samsung <span class="badge gradient-purpink text-white badge-pill shadow">50</span></li>
                    <li class="list-group-item d-flex justify-content-between align-items-center">
                        Apple <span class="badge gradient-orange
                 text-white badge-pill shadow">50</span>
                    </li>
                    <li class="list-group-item d-flex justify-content-between align-items-center">Nokia <span class="badge gradient-meridian text-white badge-pill">50</span></li>
                </ul>
            </div>
            <div class="card border-right">
                <div class="card-header">
                    Profit Ratio
                    <div class="card-action">
                        <div class="dropdown">
                            <a href="javascript:void();" class="dropdown-toggle dropdown-toggle-nocaret" data-toggle="dropdown">
                                <i class="icon-options"></i>
                            </a>
                            <div class="dropdown-menu animated fadeIn dropdown-menu-right">
                                <a class="dropdown-item" href="javascript:void();">Action</a>
                                <a class="dropdown-item" href="javascript:void();">Another action</a>
                                <a class="dropdown-item" href="javascript:void();">Something else here</a>
                                <div class="dropdown-divider"></div>
                                <a class="dropdown-item" href="javascript:void();">Separated link</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <canvas id="dash-chart-17" height="180"></canvas>
                </div>
                <ul class="list-group list-group-flush list shadow-none">
                    <li class="list-group-item d-flex justify-content-between align-items-center">Gross Profit <span class="badge gradient-quepal text-white badge-pill shadow">05</span></li>
                    <li class="list-group-item d-flex justify-content-between align-items-center">
                        Revenue <span class="badge gradient-violet
                 text-white badge-pill shadow">08</span>
                    </li>
                    <li class="list-group-item d-flex justify-content-between align-items-center">Expense <span class="badge gradient-ibiza text-white badge-pill shadow">07</span></li>
                </ul>
            </div>
            <div class="card">
                <div class="card-header">
                    Trending Products
                    <div class="card-action">
                        <div class="dropdown">
                            <a href="javascript:void();" class="dropdown-toggle dropdown-toggle-nocaret" data-toggle="dropdown">
                                <i class="icon-options"></i>
                            </a>
                            <div class="dropdown-menu animated fadeIn dropdown-menu-right">
                                <a class="dropdown-item" href="javascript:void();">Action</a>
                                <a class="dropdown-item" href="javascript:void();">Another action</a>
                                <a class="dropdown-item" href="javascript:void();">Something else here</a>
                                <div class="dropdown-divider"></div>
                                <a class="dropdown-item" href="javascript:void();">Separated link</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <canvas id="dash-chart-18" height="180"></canvas>
                </div>
                <ul class="list-group list-group-flush list shadow-none">
                    <li class="list-group-item d-flex justify-content-between align-items-center">Jeans <span class="badge gradient-knight text-white badge-pill shadow">25</span></li>
                    <li class="list-group-item d-flex justify-content-between align-items-center">
                        T-Shirts <span class="badge gradient-dusk
                 text-white badge-pill shadow">25</span>
                    </li>
                    <li class="list-group-item d-flex justify-content-between align-items-center">Shoes <span class="badge gradient-yoda text-white badge-pill shadow">25</span></li>
                </ul>
            </div>
        </div>

        <!--End Dashboard Content-->
    </div>*@
