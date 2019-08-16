@Imports SIPRECA.My.Resources
@Code
    ViewData("Title") = Resource.AccountLockedTitle
    Layout = "~/Views/Shared/_LayoutAccountLocked.vbhtml"
End Code

<div class="container">
    <div class="row">
        <div class="col-md-12">
            <div class="text-center coming-soon">

                <h2 class="coming-soon-title text-danger">@Resource.AccountLockedTitle</h2>
                @*<h6 class="text-white text-uppercase">Lets Join and work with us</h6>*@
                <p class="text-light">@Resource.AccountLockedMessage <br>@Resource.AccountLockedMessageTimeLeft @ViewBag.TempsRestant  </p>
                <!--subscribe form-->
                @*<form class="form-inline justify-content-center py-4">
                    <div class="input-group">
                        <input type="text" class="form-control" placeholder="Enter your email....">
                        <div class="input-group-append">
                            <button class="btn btn-success" type="button">Subscribe</button>
                        </div>
                    </div>
                </form>*@
                <!--end subscribe form-->
                <div class="mt-4">
                    <a href="@Url.Action(ViewBag.Action, ViewBag.Controleur)" class="btn btn-outline-danger btn-round m-1">@Resource.GoToPreviousPage </a>
                </div>

                <div class="mt-4">
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
