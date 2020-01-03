@Imports SIPRECA.My.Resources
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="icon" href="~/assets/images/favicon.ico" type="image/x-icon">
    <title>@ViewBag.Title - @Resource.SIPRECA_Text</title>
    <!-- Bootstrap core CSS-->
    <link rel="stylesheet" href="~/assets/plugins/c3/css/c3.min.css" />
    <!-- simplebar CSS-->
    <link href="~/assets/plugins/simplebar/css/simplebar.css" rel="stylesheet" />
    <!-- Bootstrap core CSS-->
    <link href="~/assets/css/bootstrap.min.css" rel="stylesheet" />
    <!-- animate CSS-->
    <link href="~/assets/css/animate.css" rel="stylesheet" type="text/css" />
    <!-- Icons CSS-->
    <link href="~/assets/css/icons.css" rel="stylesheet" type="text/css" />
    <!-- Sidebar CSS-->
    <link href="~/assets/css/sidebar-menu.css" rel="stylesheet" />
    <!-- Custom Style-->
    <link href="~/assets/css/app-style.css" rel="stylesheet" />

    @*@Scripts.Render("~/bundles/TemplateScript")*@

    @*@Scripts.Render("~/bundles/TemplateScript")*@

</head>
<body @*onload="info_noti()"*@>

    <!-- Start wrapper-->
    <div id="wrapper">

        <!--Start sidebar-wrapper-->
        @Html.Partial("_LeftSideBarSahana")
        <!--End sidebar-wrapper-->
        <!--Start topbar header-->
        @Html.Partial("_HeaderPrincipal")
        <!--End topbar header-->

        <div class="clearfix"></div>

        <!--Start content-wrapper-->
        <div class="content-wrapper">
            @RenderBody()
        </div>
        <!--End content-wrapper-->
        <!--Start Back To Top Button-->
        <a href="javaScript:void();" class="back-to-top"><i class="fa fa-angle-double-up"></i> </a>
        <!--End Back To Top Button-->
        <!--Start footer-->
        @Html.Partial("_Footer")
        <!--End footer-->

    </div>
    <!-- Bootstrap core JavaScript-->
    <script src="~/assets/js/jquery.min.js"></script>
    <script src="~/assets/js/popper.min.js"></script>
    <script src="~/assets/js/bootstrap.min.js"></script>

    <!-- simplebar js -->
    <script src="~/assets/plugins/simplebar/js/simplebar.js"></script>
    <!-- waves effect js -->
    <script src="~/assets/js/waves.js"></script>
    <!-- sidebar-menu js -->
    <script src="~/assets/js/sidebar-menu.js"></script>
    <!-- Custom scripts -->
    <script src="~/assets/js/app-script.js"></script>
    <!-- c3 Charts -->
    <script src="~/assets/plugins/d3/d3.min.js"></script>
    <script src="~/assets/plugins/c3/js/c3.min.js"></script>
    <script src="~/assets/plugins/c3/js/c3.js"></script>

    @RenderSection("scripts", required:=False)
</body>
</html>
