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
        <li class="sidebar-header">MAIN NAVIGATION</li>
        <li>
            <a href="index.html" class="waves-effect" style="font-size: 11px;">
                <i class="icon-settings"></i><span>@Resource.MenuSettings</span><i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="sidebar-submenu">
                <li><a href="@Url.Action("Index", "CategorieDArticles")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuCategoriArticle</a></li>
                <li><a href="@Url.Action("Index", "CategorieElements")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuCategorieElement</a></li>
                <li><a href="@Url.Action("Index", "Devises")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuDevises</a></li>
                <li><a href="@Url.Action("Index", "Materiels")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuMateriels</a></li>
                <li><a href="@Url.Action("Index", "MarqueElements")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuMarqueElement</a></li>
                <li><a href="@Url.Action("Index", "SurfaceDePistes")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuSurfaceDePiste</a></li>
                <li><a href="@Url.Action("Index", "TailleDeAeronefs")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuTailleDeAeronef</a></li>
                <li><a href="@Url.Action("Index", "TypeEntrepots")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuTypeEntrepot</a></li>
                <li><a href="@Url.Action("Index", "TypeHopitaux")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuTypeHopitaux</a></li>
                <li><a href="@Url.Action("Index", "TypeImmobilisations")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuTypeImmobilisation</a></li>
                <li><a href="@Url.Action("Index", "TypePersonnels")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuTypePersonnel</a></li>
                <li><a href="@Url.Action("Index", "Personnels")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuPersonnel</a></li>
                @*<li><a href="@Url.Action("Index", "TypeVehicules")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuTypeVehicule</a></li>*@
                <li><a href="@Url.Action("Index", "TypeAbris")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuTypeAbris</a></li>
                <li><a href="@Url.Action("Index", "UsageHumanitaires")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuUsageHumanitaire</a></li>
                @*<li><a href="@Url.Action("Index", "Indemmisations")"><i class="fa fa-long-arrow-right"></i> @Resource.MenuIndemnisation</a></li>*@

            </ul>
        </li>
        <li>
            <a href="javaScript:void();" class="waves-effect" style="font-size: 11px;">
                <i class="icon-handbag"></i><span>@Resource.MenuGestionDesMoyens</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="sidebar-submenu">
                <li><a href="@Url.Action("Index", "Abris")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuAbris</a></li>
                <li><a href="@Url.Action("Index", "Aeroport")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuAeroport</a></li>
                <li><a href="@Url.Action("Index", "Bureaux")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuBureau</a></li>
                <li><a href="@Url.Action("Index", "Entrepots")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuEntrepots</a></li>
                <li><a href="@Url.Action("Index", "Elements")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuElements</a></li>
                <li><a href="@Url.Action("Index", "Hopitaux")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuHopitaux</a></li>
                <li><a href="@Url.Action("Index", "Heliports")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuHeliport</a></li>
                <li><a href="@Url.Action("Index", "Immobilisations")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuImmobilisation</a></li>
                <li><a href="@Url.Action("Index", "Installations")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuInstallation</a></li>
                <li><a href="@Url.Action("Index", "PortDeMers")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuPortDeMer</a></li>
                <li><a href="@Url.Action("Index", "Projets")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuProjet</a></li>
                <li><a href="@Url.Action("Index", "Cartes")" style="font-size: 12px;"><i class="fa fa-long-arrow-right"></i> @Resource.MenuCartes</a></li>
            </ul>
        </li>

    </ul>

</div>
<!--End sidebar-wrapper-->
