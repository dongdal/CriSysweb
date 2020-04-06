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

        @If AppSession.ListRessources.Contains(4) Then
            @<li>
                <a href="index.html" class="waves-effect" style="font-size: 11px;">
                    <i class="icon-settings"></i><span>@Resource.MenuBaseSettings</span><i class="fa fa-angle-left pull-right"></i>
                </a>
                <ul class="sidebar-submenu">
                    @If AppSession.ListSousRessources.Contains(17) Then
                        @<li><a href="@Url.Action("Index", "Devises")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuDevises</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(18) Then
                        @<li><a href="@Url.Action("Index", "Materiels")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuMateriels</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(19) Then
                        @<li><a href="@Url.Action("Index", "TypeOrganisations")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuTypeOrganisation</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(20) Then
                        @<li><a href="@Url.Action("Index", "Organisations")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuOrganisation</a></li>
                    End If
                </ul>
            </li>
        End If

        @If AppSession.ListRessources.Contains(5) Then
            @<li>
                <a href="index.html" class="waves-effect" style="font-size: 11px;">
                    <i class="icon-user"></i><span>@Resource.MenuGestionDuPersonnel</span><i class="fa fa-angle-left pull-right"></i>
                </a>
                <ul class="sidebar-submenu">
                    @If AppSession.ListSousRessources.Contains(21) Then
                        @<li><a href="@Url.Action("Index", "TypePersonnels")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuTypePersonnel</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(22) Then
                        @<li><a href="@Url.Action("Index", "Personnels")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuPersonnel</a></li>
                    End If
                </ul>
            </li>
        End If

        @If AppSession.ListRessources.Contains(6) Then
            @<li>
                <a href="index.html" class="waves-effect" style="font-size: 11px;">
                    <i class="fa fa-stethoscope"></i><span>@Resource.MenuGestionDesHopitaux</span><i class="fa fa-angle-left pull-right"></i>
                </a>
                <ul class="sidebar-submenu">
                    @If AppSession.ListSousRessources.Contains(23) Then
                        @<li><a href="@Url.Action("Index", "TypeHopitaux")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuTypeHopitaux</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(24) Then
                        @<li><a href="@Url.Action("Index", "Hopitaux")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuHopitaux</a></li>
                    End If
                </ul>
            </li>
        End If

        @If AppSession.ListRessources.Contains(7) Then
            @<li>
                <a href="index.html" class="waves-effect" style="font-size: 11px;">
                    <i class="icon-home"></i><span>@Resource.MenuGestionAbris</span><i class="fa fa-angle-left pull-right"></i>
                </a>
                <ul class="sidebar-submenu">
                    @If AppSession.ListSousRessources.Contains(25) Then
                        @<li><a href="@Url.Action("Index", "TypeAbris")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuTypeAbris</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(26) Then
                        @<li><a href="@Url.Action("Index", "Abris")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuAbris</a></li>
                    End If
                </ul>
            </li>
        End If

        @If AppSession.ListRessources.Contains(8) Then
            @<li>
                <a href="index.html" class="waves-effect" style="font-size: 11px;">
                    <i class="fa fa-plane"></i><span>@Resource.MenuGestionAeroport</span><i class="fa fa-angle-left pull-right"></i>
                </a>
                <ul class="sidebar-submenu">
                    @If AppSession.ListSousRessources.Contains(27) Then
                        @<li><a href="@Url.Action("Index", "SurfaceDePistes")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuSurfaceDePiste</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(28) Then
                        @<li><a href="@Url.Action("Index", "TailleDeAeronefs")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuTailleDeAeronef</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(29) Then
                        @<li><a href="@Url.Action("Index", "UsageHumanitaires")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuUsageHumanitaire</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(30) Then
                        @<li><a href="@Url.Action("Index", "Aeroport")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuAeroport</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(31) Then
                        @<li><a href="@Url.Action("Index", "Heliports")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuHeliport</a></li>
                    End If
                </ul>
            </li>
        End If

        @If AppSession.ListRessources.Contains(9) Then
            @<li>
                <a href="index.html" class="waves-effect" style="font-size: 11px;">
                    <i class="fa fa-institution"></i><span>@Resource.MenuGestionInfrastructures</span><i class="fa fa-angle-left pull-right"></i>
                </a>
                <ul class="sidebar-submenu">
                    @If AppSession.ListSousRessources.Contains(32) Then
                        @<li><a href="@Url.Action("Index", "TypeEntrepots")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuTypeEntrepot</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(33) Then
                        @<li><a href="@Url.Action("Index", "TypeOffices")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuTypeOffices</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(34) Then
                        @<li><a href="@Url.Action("Index", "Bureaux")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuBureau</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(35) Then
                        @<li><a href="@Url.Action("Index", "Entrepots")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuEntrepots</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(36) Then
                        @<li><a href="@Url.Action("Index", "Installations")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuInstallation</a></li>
                    End If
                </ul>
            </li>
        End If

        @If AppSession.ListRessources.Contains(10) Then
            @<li>
                <a href="index.html" class="waves-effect" style="font-size: 11px;">
                    <i class="fa fa-hand-stop-o"></i><span>@Resource.MenuGestionImmobilisation</span><i class="fa fa-angle-left pull-right"></i>
                </a>
                <ul class="sidebar-submenu">
                    @If AppSession.ListSousRessources.Contains(37) Then
                        @<li><a href="@Url.Action("Index", "CategorieElements")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuCategorieElement</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(38) Then
                        @<li><a href="@Url.Action("Index", "MarqueElements")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuMarqueElement</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(39) Then
                        @<li><a href="@Url.Action("Index", "TypeImmobilisations")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuTypeImmobilisation</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(40) Then
                        @<li><a href="@Url.Action("Index", "Elements")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuElements</a></li>
                    End If
                    @If AppSession.ListSousRessources.Contains(41) Then
                        @<li><a href="@Url.Action("Index", "Immobilisations")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuImmobilisation</a></li>
                    End If
                </ul>
            </li>
        End If

        @If AppSession.ListRessources.Contains(11) Then
            @<li>
                <a href="javaScript:void();" class="waves-effect" style="font-size: 11px;">
                    <i class="fa fa-ship"></i><span>@Resource.MenuGestionPort</span>
                    <i class="fa fa-angle-left pull-right"></i>
                </a>
                <ul class="sidebar-submenu">
                    @If AppSession.ListSousRessources.Contains(42) Then
                        @<li><a href="@Url.Action("Index", "PortDeMers")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuPortDeMer</a></li>
                    End If
                </ul>
            </li>
        End If

        @If AppSession.ListRessources.Contains(12) Then
            @<li>
                <a href="javaScript:void();" class="waves-effect" style="font-size: 11px;">
                    <i class="fa fa-bar-chart"></i><span>@Resource.MenuGestionProjet</span>
                    <i class="fa fa-angle-left pull-right"></i>
                </a>
                <ul class="sidebar-submenu">
                    @If AppSession.ListSousRessources.Contains(43) Then
                        @<li><a href="@Url.Action("Index", "Projets")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuProjet</a></li>
                    End If
                </ul>
            </li>
        End If

        @If AppSession.ListRessources.Contains(13) Then
            @<li>
                <a href="javaScript:void();" class="waves-effect" style="font-size: 11px;">
                    <i class="fa fa-bar-chart"></i><span>@Resource.MenuCartes</span>
                    <i class="fa fa-angle-left pull-right"></i>
                </a>
                <ul class="sidebar-submenu">
                    @If AppSession.ListSousRessources.Contains(44) Then
                        @<li><a href="@Url.Action("Index", "Cartes")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuCartes</a></li>
                    End If
                </ul>
            </li>
        End If


    </ul>

</div>
<!--End sidebar-wrapper-->
