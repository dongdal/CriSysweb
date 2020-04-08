@Imports SIPRECA.My.Resources
@Code
    ViewData("Title") = Resource.Error404_Title
    Layout = "~/Views/Shared/_LayoutError.vbhtml"
End Code

<div class="container">
    <div class="row">
        <div class="col-md-12">
            <div class="text-center error-pages">
                <h1 class="error-title text-danger"> 404</h1>
                <h2 class="error-sub-title text-white">@Resource.Error404_SubTitle.ToUpper()</h2>
                <p class="error-message text-white text-uppercase">@Resource.Error404_Explain.ToUpper() </p>

                <div class="mt-4">
                    <a href="@Url.Action(ViewBag.Action, ViewBag.Controleur)" class="btn btn-danger btn-round shadow-danger m-1">@Resource.GoToPreviousPage </a>
                </div>
                <div class="mt-4">
                    Copyright © @DateTime.Now.Year <a href="@Resource.MinatSiteWeb">@Resource.MINATName</a> --- @Resource.PoweredBy <a href="@Resource.TeamisWebSite">@Resource.TeamisName</a>
                </div>
                <hr class="w-50">
                <div class="mt-2">
                </div>
            </div>
        </div>
    </div>
</div>
