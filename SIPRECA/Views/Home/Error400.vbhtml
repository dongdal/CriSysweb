@Imports SIPRECA.My.Resources
@Code
    ViewData("Title") = Resource.Error400_Title
    Layout = "~/Views/Shared/_LayoutError.vbhtml"
End Code

<div class="container">
    <div class="row">
        <div class="col-md-12">
            <div class="text-center error-pages">
                <h1 class="error-title text-danger"> 400</h1>
                <h2 class="error-sub-title text-white">@Resource.Error400_SubTitle</h2>
                <p class="error-message text-white text-uppercase">@Resource.Error400_Explain @ViewBag.Error400_SelectAnnee </p>

                <div class="mt-4">
                    <a href="@Url.Action(ViewBag.Action, ViewBag.Controleur)" class="btn btn-danger btn-round shadow-danger m-1">@Resource.GoToPreviousPage </a>
                </div>
                <div class="mt-4">
                    @*<p class="text-light">Copyright © 2018  <span class="text-danger">DashRock </span>| All rights reserved.</p>*@
                    Copyright © @DateTime.Now.Year <a href="@Resource.MinatSiteWeb">@Resource.MINATName</a> --- @Resource.PoweredBy <a href="@Resource.TeamisWebSite">@Resource.TeamisName</a>
                </div>
                <hr class="w-50">
                <div class="mt-2">
                    @*<a href="javascript:void()" class="btn-social btn-social-circle btn-facebook waves-effect waves-light m-1"><i class="fa fa-facebook"></i></a>
                        <a href="javascript:void()" class="btn-social btn-social-circle btn-google-plus waves-effect waves-light m-1"><i class="fa fa-google-plus"></i></a>
                        <a href="javascript:void()" class="btn-social btn-social-circle btn-behance waves-effect waves-light m-1"><i class="fa fa-behance"></i></a>
                        <a href="javascript:void()" class="btn-social btn-social-circle btn-dribbble waves-effect waves-light m-1"><i class="fa fa-dribbble"></i></a>*@
                </div>
            </div>
        </div>
    </div>
</div>
