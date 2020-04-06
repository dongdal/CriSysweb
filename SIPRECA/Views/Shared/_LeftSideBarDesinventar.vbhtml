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
        @If AppSession.ListRessources.Contains(14) Then
            @<li>
                <a href="index.html" class="waves-effect" style="font-size: 11px;">
                    <i class="icon-settings"></i><span>@Resource.MenuSettings</span><i class="fa fa-angle-left pull-right"></i>
                </a>
                <ul class="sidebar-submenu">
                    @If AppSession.ListSousRessources.Contains(45) Then
                        @<li><a href="@Url.Action("Index", "PerteBetails")" style="font-size: 11px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuPerteBetail</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(46) Then
                        @<li><a href="@Url.Action("Index", "DesagregationRecoltesAgricoles")" style="font-size: 11px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuRecoltesAgricoles</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(47) Then
                        @<li><a href="@Url.Action("Index", "Facteurs")" style="font-size: 11px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuFacteurs</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(48) Then
                        @<li><a href="@Url.Action("Index", "NiveauDAlerts")" style="font-size: 11px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuNiveauDAlert</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(49) Then
                        @<li><a href="@Url.Action("Index", "ServicesPubliquePertubes")" style="font-size: 11px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuServicesPubliquePertube</a></li>
                    End If
                </ul>
            </li>
        End If

        @If AppSession.ListRessources.Contains(15) Then
            @<li>
                <a href="javaScript:void();" class="waves-effect" style="font-size: 11px;">
                    <i class="icon-handbag"></i><span> @Resource.MenuManageRisks</span>
                    <i class="fa fa-angle-left pull-right"></i>
                </a>
                <ul class="sidebar-submenu">
                    @If AppSession.ListSousRessources.Contains(50) Then
                        @<li><a href="@Url.Action("Index", "Risques")" style="font-size: 11px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuRisques</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(51) Then
                        @<li><a href="@Url.Action("Index", "ZoneARisques")" style="font-size: 11px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuZoneARisques</a></li>
                    End If
                </ul>
            </li>
        End If

        @If AppSession.ListRessources.Contains(16) Then
            @<li>
                <a href="javaScript:void();" class="waves-effect" style="font-size: 11px;">
                    <i class="icon-handbag"></i><span> @Resource.MenuManageSolution</span>
                    <i class="fa fa-angle-left pull-right"></i>
                </a>
                <ul class="sidebar-submenu">
                    @If AppSession.ListSousRessources.Contains(52) Then
                        @<li><a href="@Url.Action("Index", "Solutions")" style="font-size: 11px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuSolutions</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(53) Then
                        @<li><a href="@Url.Action("Index", "TypeSolutions")" style="font-size: 11px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuTypeSolutions</a></li>
                    End If
                </ul>
            </li>
        End If

        @If AppSession.ListRessources.Contains(17) Then
            @<li>
                <a href="javaScript:void();" class="waves-effect" style="font-size: 11px;">
                    <i class="icon-diamond"></i><span>@Resource.MenuManageEvents</span>
                    <i class="fa fa-angle-left pull-right"></i>
                </a>
                <ul class="sidebar-submenu">
                    @If AppSession.ListSousRessources.Contains(54) Then
                        @<li><a href="@Url.Action("Index", "EvenementZones")" style="font-size: 11px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuEvenementZones</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(55) Then
                        @<li><a href="@Url.Action("Index", "Evenements")" style="font-size: 11px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuEvenements</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(56) Then
                        @<li><a href="@Url.Action("Query", "EvenementZones")" style="font-size: 11px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuRequeteur</a></li>
                    End If
                </ul>
            </li>
        End If

    </ul>

</div>
<!--End sidebar-wrapper-->
