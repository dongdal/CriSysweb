@Imports SIPRECA.My.Resources
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
            <a href="javaScript:void();" class="waves-effect" style="font-size: 11px;">
                <i class="fa fa-lock"></i><span>@Resource.Menu_BasicsDatas</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="sidebar-submenu">
                <li><a href="@Url.Action("Index", "ModuleRoles")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.Menu_ModuleRoles</a></li>
                <li><a href="@Url.Action("Index", "Actions")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.Menu_Actions</a></li>
                <li><a href="@Url.Action("Index", "Modules")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.Menu_Modules</a></li>
                <li><a href="@Url.Action("Index", "Ressources")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.Menu_Ressources</a></li>
                <li><a href="@Url.Action("Index", "SousRessources")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.Menu_SoursRessources</a></li>
            </ul>
        </li>

        <li>
            <a href="javaScript:void();" class="waves-effect" style="font-size: 11px;">
                <i class="fa fa-users"></i><span>@Resource.Menu_UserManager</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="sidebar-submenu">
                <li><a href="@Url.Action("Index", "Account")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.Menu_UserManager</a></li>
            </ul>
        </li>




    </ul>

</div>
<!--End sidebar-wrapper-->
