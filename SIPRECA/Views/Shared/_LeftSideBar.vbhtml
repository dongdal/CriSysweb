@Imports SIPRECA.My.Resources
  <!--Start sidebar-wrapper-->
<div id="sidebar-wrapper" data-simplebar="" data-simplebar-auto-hide="true">
    <div class="brand-logo">
        <a href="@Url.Action("Index", "Home")">
            <img src="~/assets/images/logo-icon.png" class="logo-icon" alt="logo icon">
            <h5 class="logo-text"> @Resource.CrisisTitle</h5>
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
            <a href="index.html" class="waves-effect" style="font-size: 11px;">
                <i class="icon-settings"></i><span>@Resource.MenuSettings</span><i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="sidebar-submenu">
                <li><a href="@Url.Action("Index", "Account")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.Menu_UserManager</a></li>
                <li><a href="@Url.Action("Index", "AnneeBudgetaires")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.Menu_AnneeBudgetaire</a></li>
                <li><a href="@Url.Action("Index", "Communes")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.Menu_Communes</a></li>
                <li><a href="@Url.Action("Index", "Departements")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.Menu_Departements</a></li>
                <li><a href="@Url.Action("Index", "NatureAides")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuNatureAide</a></li>
                <li><a href="@Url.Action("Index", "Quartiers")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuQuartier</a></li>
                <li><a href="@Url.Action("Index", "Regions")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.Menu_Regions</a></li>
                <li><a href="@Url.Action("Index", "Sinistres")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuSinistre</a></li>
                <li><a href="@Url.Action("Index", "TypeAides")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuTypeAide</a></li>
                <li><a href="@Url.Action("Index", "TypeSinistres")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuTypeSinistres</a></li>
                <li><a href="@Url.Action("Index", "TypeSuivis")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuTypeSuivis</a></li>
                <li><a href="@Url.Action("Index", "Cartes")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuCartes</a></li>
            </ul>
        </li>
        <li>
            <a href="javaScript:void();" class="waves-effect" style="font-size: 11px;">
                <i class="icon-handbag"></i><span>@Resource.MenuGestionDesSinistre</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="sidebar-submenu">
                <li><a href="@Url.Action("Index", "Demandes")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.Menu_Demande</a></li>
                <li><a href="@Url.Action("Index", "CollectiviteSinistrees")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.Menu_Declarations</a></li>
                <li><a href="@Url.Action("Index", "Indemnisations")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuIndemnisation</a></li>
                <li><a href="@Url.Action("Index", "Suivis")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuSuivi</a></li>
                <li><a href="@Url.Action("Index", "Sinistrers")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuSinistrees</a></li>
            </ul>
        </li>
        
      
    </ul>

</div>
<!--End sidebar-wrapper-->
