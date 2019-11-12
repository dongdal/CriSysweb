﻿@Imports SIPRECA.My.Resources
  <!--Start sidebar-wrapper-->
<div id="sidebar-wrapper" data-simplebar="" data-simplebar-auto-hide="true">
    <div class="brand-logo">
        <a href="@Url.Action("Index", "Home")">
            <img src="~/assets/images/logo-icon.png" class="logo-icon" alt="logo icon">
            <h5 class="logo-text">  @Resource.CrisisTitle.ToUpper()</h5>
        </a>
    </div>
    <div class="user-details">
        <div class="media align-items-center user-pointer collapsed" data-toggle="collapse" data-target="#user-dropdown">
            <div class="avatar"><img class="mr-3 side-user-img" src="~/assets/images/avatars/avatar-4.png" alt="user avatar"></div>
            <div class="media-body">
                <h6 class="side-user-name" style="font-size:12px">@AppSession.NomUser @AppSession.PrenomUser</h6>
            </div>
        </div>
        <div id="user-dropdown" class="collapse">
            <ul class="user-setting-menu">
                @*<li><a href="javaScript:void();"><i class="icon-user"></i>  My Profile</a></li>*@
                <li>
                    <a href="javaScript:void();" style="font-size:12px">
                        <i class="icon-user"></i>@AppSession.UserName
                    </a>
                </li>
                @*<li><a href="javaScript:void();"><i class="icon-settings"></i> Setting</a></li>*@
                <li>
                    <a href=@Url.Action("ChangeUserPassword", "Account") role="menuitem" style="font-size:12px">
                        <i class="icon-key mr-2" aria-hidden="true"></i> @Resource.ChgPwd <br />
                    </a>
                </li>
                @*<li><a href="javaScript:void();"><i class="icon-power"></i> Logout</a></li>*@
                <li>
                    <a href="javascript:document.getElementById('LogoutForm').submit()" role="menuitem" style="font-size:12px">
                        <i class="icon-power mr-2"></i>
                        @Resource.Disconnect
                    </a>
                </li>
            </ul>
        </div>
    </div>
    <ul class="sidebar-menu do-nicescrol">
        <li class="sidebar-header">@Resource.MainNavigation</li>
        <li>
            <a href="index.html" class="waves-effect"  style="font-size: 11px;">
                <i class="icon-settings"></i><span>@Resource.MenuSettings</span><i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="sidebar-submenu">
                <li><a href="@Url.Action("Index", "PerteBetails")" style="font-size: 11px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuPerteBetail</a></li>
                <li><a href="@Url.Action("Index", "DesagregationRecoltesAgricoles")" style="font-size: 11px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuRecoltesAgricoles</a></li>
                <li><a href="@Url.Action("Index", "Facteurs")" style="font-size: 11px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuFacteurs</a></li>
                <li><a href="@Url.Action("Index", "NiveauDAlerts")" style="font-size: 11px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuNiveauDAlert</a></li>
                <li><a href="@Url.Action("Index", "Risques")" style="font-size: 11px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuRisques</a></li>
                <li><a href="@Url.Action("Index", "Evenements")" style="font-size: 11px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuEvenements</a></li>
                <li><a href="@Url.Action("Index", "ServicesPubliquePertubes")" style="font-size: 11px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuServicesPubliquePertube</a></li>
                <li><a href="@Url.Action("Index", "Solutions")" style="font-size: 11px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuSolutions</a></li>
                <li><a href="@Url.Action("Index", "TypeSolutions")" style="font-size: 11px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuTypeSolutions</a></li>
                <li><a href="@Url.Action("Index", "ZoneARisques")" style="font-size: 11px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuZoneARisques</a></li>
                <li><a href="@Url.Action("Index", "Cartes")" style="font-size: 11px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuCartes</a></li>
                @*<li><a href="@Url.Action("Index", "Indemmisations")"><i class="fa fa-long-arrow-right"></i> @Resource.MenuIndemnisation</a></li>*@

            </ul>
        </li>
        <li>
            <a href="javaScript:void();" class="waves-effect" style="font-size: 11px;">
                <i class="icon-handbag"></i><span> @Resource.MenuManageRisks</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="sidebar-submenu">
                <li><a href="ui-lightbox-gallery.html"><i class="fa fa-long-arrow-right"></i> Lightbox gallery</a></li>
            </ul>
        </li>

        <li>
            <a href="javaScript:void();" class="waves-effect" style="font-size: 11px;">
                <i class="icon-diamond"></i><span>@Resource.MenuManageEvents</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="sidebar-submenu">
                <li><a href="@Url.Action("Index", "EvenementZones")" style="font-size: 11px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuEvenementZones</a></li>
            </ul>
        </li>
        
    </ul>

</div>
<!--End sidebar-wrapper-->
