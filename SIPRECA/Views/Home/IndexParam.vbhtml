@Imports SIPRECA.My.Resources
@Code
    ViewData("Title") = Resource.ModuleParametrage
    Layout = "~/Views/Shared/_LayoutParam.vbhtml"
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
    <h6 class="text-uppercase">@Resource.ModuleParametrage</h6>
    <hr>
    <div class="row">

    </div>
</div>
<!-- End container-fluid-->
