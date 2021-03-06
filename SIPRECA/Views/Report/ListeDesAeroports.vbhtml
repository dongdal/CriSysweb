@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.MenuListeAeroports
    Layout = "~/Views/Shared/_LayoutReport.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageReport</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("ListeDesAeroports", "Report")>@Resource.ManageReport</a></li>
        <li class="breadcrumb-item active">@Resource.MenuListeAeroports</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.MenuListeAeroports</div>
            <hr>

            <div Class="form-group row">
                <div Class="col-sm-10">
                    <a class="btn btn-round btn-primary waves-effect waves-light m-1" id="PrintReport" data-toggle="modal" data-placement="Right" title="@Resource.BtnPrint" href="#">
                        <i Class="fa fa-print" aria-hidden="true"></i>
                        @Resource.BtnPrint
                    </a>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12" style="min-height:100px;">
                    <iframe id="ifrReport" class="embed-responsive-item col-lg-12" style="min-height:500px;"></iframe>
                </div>
            </div>

        </div>
    </div>
</div>


@Section Scripts
    <script>
        $('#PrintReport').on('click', function () {
        $('#myModal').modal('show');
            $('#ifrReport').attr('src', '@Url.Content("~/Report/Report.aspx")?type=ListeDesAeroports')
    });
    </script>
End Section