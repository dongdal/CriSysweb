@Imports SIPRECA.My.Resources
@Imports System.Data.Entity
@Imports Microsoft.AspNet.Identity
@Imports System.Web.SessionState
<!--Start topbar header-->
@If Request.IsAuthenticated = True Then

    Dim LeLienAnglais As RouteValueDictionary
    Dim LeLienFrancais As RouteValueDictionary

    LeLienFrancais = New RouteValueDictionary(ViewContext.RouteData.Values.ToDictionary(Function(r) r.Key, Function(r) IIf(r.Key = "culture", "fr-FR", r.Value))) From {
        {"type", ViewBag.TypeInstrument}}

    LeLienAnglais = New RouteValueDictionary(ViewContext.RouteData.Values.ToDictionary(Function(r) r.Key, Function(r) IIf(r.Key = "culture", "en", r.Value))) From {
{"type", ViewBag.TypeInstrument}}

    @Using Html.BeginForm("LogOff", "Account", FormMethod.Post, New With {.id = "LogoutForm"})
        @Html.AntiForgeryToken()


        @<header class="topbar-nav">
            <nav class="navbar navbar-expand fixed-top gradient-ibiza">
                <ul class="navbar-nav mr-auto align-items-center">
                    <li class="nav-item">
                        <a class="nav-link toggle-menu" href="javascript:void();">
                            <i class="icon-menu menu-icon"></i>
                        </a>
                    </li>
                </ul>

                <ul class="navbar-nav align-items-center right-nav-link">

                    <li class="nav-item dropdown-lg">
                        <a class="nav-link dropdown-toggle dropdown-toggle-nocaret waves-effect" data-toggle="dropdown" href="javascript:void();">
                            @Resource.AnneeBudgetaire : @AppSession.AnneeBudgetaire.Libelle
                            <i class="icon-list"></i>
                        </a>
                        <div class="dropdown-menu dropdown-menu-right animated fadeIn" style="width: 380px !important;">
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item d-flex justify-content-between align-items-center">
                                    @Resource.ComboAnneeBudgetaire
                                    @*<span class="badge badge-danger">4</span>*@
                                </li>
                                @If AppSession.LesAnneeBudgetaires IsNot Nothing Then
                                    For Each item In AppSession.LesAnneeBudgetaires
                                        @<li Class="list-group-item">
                                            <a href="@Url.Action("SetExercice", "Account", New With {.AnneeBudgetaireId = item.Id})">
                                                <div class="media">
                                                    <div class="media-body">
                                                        <h6 class="mt-0 msg-title" style="text-align: center">@Resource.AnneeBudgetaire - @item.Libelle</h6>
                                                    </div>
                                                </div>
                                            </a>
                                        </li>
                                    Next
                                End If

                            </ul>
                        </div>
                    </li>

                    <li Class="nav-item dropdown-lg">
                        <a Class="nav-link dropdown-toggle dropdown-toggle-nocaret waves-effect" data-toggle="dropdown" href="javascript:void();">
                            <i Class="icon-envelope-open"></i>
                        </a>
                        <div Class="dropdown-menu dropdown-menu-right animated fadeIn">
                            <ul Class="list-group list-group-flush">
                                <li Class="list-group-item d-flex justify-content-between align-items-center">
                                    You have 4 New messages
                                    <span Class="badge badge-danger">4</span>
                                </li>
                                <li Class="list-group-item">
                                    <a href="javaScript:void();">
                                        <div class="media">
                                            <div class="avatar"><img class="align-self-start mr-3" src="~/assets/images/avatars/avatar-1.png" alt="user avatar"></div>
                                            <div class="media-body">
                                                <h6 class="mt-0 msg-title">Jhon Deo</h6>
                                                <p class="msg-info">Lorem ipsum dolor sit amet...</p>
                                                <small>Today, 4:10 PM</small>
                                            </div>
                                        </div>
                                    </a>
                                </li>
                                <li Class="list-group-item">
                                    <a href="javaScript:void();">
                                        <div class="media">
                                            <div class="avatar"><img class="align-self-start mr-3" src="~/assets/images/avatars/avatar-2.png" alt="user avatar"></div>
                                            <div class="media-body">
                                                <h6 class="mt-0 msg-title">Sara Jen</h6>
                                                <p class="msg-info">Lorem ipsum dolor sit amet...</p>
                                                <small>Yesterday, 8:30 AM</small>
                                            </div>
                                        </div>
                                    </a>
                                </li>
                                <li Class="list-group-item">
                                    <a href="javaScript:void();">
                                        <div class="media">
                                            <div class="avatar"><img class="align-self-start mr-3" src="~/assets/images/avatars/avatar-3.png" alt="user avatar"></div>
                                            <div class="media-body">
                                                <h6 class="mt-0 msg-title">Dannish Josh</h6>
                                                <p class="msg-info">Lorem ipsum dolor sit amet...</p>
                                                <small>5/11/2018, 2:50 PM</small>
                                            </div>
                                        </div>
                                    </a>
                                </li>
                                <li Class="list-group-item">
                                    <a href="javaScript:void();">
                                        <div class="media">
                                            <div class="avatar"><img class="align-self-start mr-3" src="~/assets/images/avatars/avatar-4.png" alt="user avatar"></div>
                                            <div class="media-body">
                                                <h6 class="mt-0 msg-title">Katrina Mccoy</h6>
                                                <p class="msg-info">Lorem ipsum dolor sit amet.</p>
                                                <small>1/11/2018, 2:50 PM</small>
                                            </div>
                                        </div>
                                    </a>
                                </li>
                                <li Class="list-group-item"><a href="javaScript:void();">See All Messages</a></li>
                            </ul>
                        </div>
                    </li>
                    <li Class="nav-item dropdown-lg">
                        <a Class="nav-link dropdown-toggle dropdown-toggle-nocaret waves-effect" data-toggle="dropdown" href="javascript:void();">
                            <i Class="icon-bell"></i><span class="badge badge-primary badge-up">10</span>
                        </a>
                        <div Class="dropdown-menu dropdown-menu-right animated fadeIn">
                            <ul Class="list-group list-group-flush">
                                <li Class="list-group-item d-flex justify-content-between align-items-center">
                                    You have 10 Notifications
                                    <span Class="badge badge-primary">10</span>
                                </li>
                                <li Class="list-group-item">
                                    <a href="javaScript:void();">
                                        <div class="media">
                                            <i class="icon-people fa-2x mr-3 text-info"></i>
                                            <div class="media-body">
                                                <h6 class="mt-0 msg-title">New Registered Users</h6>
                                                <p class="msg-info">Lorem ipsum dolor sit amet...</p>
                                            </div>
                                        </div>
                                    </a>
                                </li>
                                <li Class="list-group-item">
                                    <a href="javaScript:void();">
                                        <div class="media">
                                            <i class="icon-cup fa-2x mr-3 text-warning"></i>
                                            <div class="media-body">
                                                <h6 class="mt-0 msg-title">New Received Orders</h6>
                                                <p class="msg-info">Lorem ipsum dolor sit amet...</p>
                                            </div>
                                        </div>
                                    </a>
                                </li>
                                <li Class="list-group-item">
                                    <a href="javaScript:void();">
                                        <div class="media">
                                            <i class="icon-bell fa-2x mr-3 text-danger"></i>
                                            <div class="media-body">
                                                <h6 class="mt-0 msg-title">New Updates</h6>
                                                <p class="msg-info">Lorem ipsum dolor sit amet...</p>
                                            </div>
                                        </div>
                                    </a>
                                </li>
                                <li Class="list-group-item"><a href="javaScript:void();">See All Notifications</a></li>
                            </ul>
                        </div>
                    </li>
                    <li Class="nav-item language">
                        <a Class="nav-link dropdown-toggle dropdown-toggle-nocaret waves-effect" data-toggle="dropdown" href="#">
                            @*<i class="flag-icon flag-icon-gb"></i>*@
                            @If ViewContext.RouteData.Values("culture").Equals("en") Then
                                @<i class=""></i> @Resource.EnglishLang
                            ElseIf ViewContext.RouteData.Values("culture").Equals("fr-FR") Then
                                @<i class=""></i> @Resource.FrenchLang
                            End If
                        </a>

                        <ul class="dropdown-menu dropdown-menu-right animated fadeIn">
                            <li class="dropdown-item">
                                <a href="@Url.RouteUrl(LeLienFrancais)">
                                    <i class=""></i> @Resource.FrenchLang (fr-FR)
                                </a>
                            </li>
                            <li class="dropdown-item">
                                <a href="@Url.RouteUrl(LeLienAnglais)">
                                    <i class=""></i> @Resource.EnglishLang (en-GB)
                                </a>
                            </li>
                        </ul>
                    </li>


                    <li class="nav-item">
                        <a class="nav-link dropdown-toggle dropdown-toggle-nocaret" data-toggle="dropdown" href="#">
                            <span class="user-profile"><img src="~/assets/images/avatars/avatar-17.png" class="img-circle" alt="user avatar"></span>
                        </a>
                        <ul class="dropdown-menu dropdown-menu-right animated fadeIn">
                            <li class="dropdown-item user-details">
                                <a href="javaScript:void();">
                                    <div class="media">
                                        <div class="avatar"><img class="align-self-start mr-3" src="~/assets/images/avatars/avatar-17.png" alt="user avatar"></div>
                                        <div class="media-body">
                                            <h6 class="mt-2 user-title">@AppSession.NomUser  @AppSession.PrenomUser</h6>
                                            <p class="user-subtitle">@AppSession.UserName</p>
                                        </div>
                                    </div>
                                </a>
                            </li>

                            <li class="dropdown-item">
                                <a href=@Url.Action("ChangeUserPassword", "Account") role="menuitem">
                                    <i class="icon-key mr-2" aria-hidden="true"></i> @Resource.ChgPwd <br />
                                </a>
                            </li>
                            <li class="dropdown-divider"></li>
                            <li class="dropdown-item">
                                <i class="icon-power mr-2"></i>
                                <a href="javascript:document.getElementById('LogoutForm').submit()" role="menuitem">
                                    @Resource.Disconnect
                                </a>
                            </li>
                        </ul>
                    </li>
                </ul>
            </nav>
        </header>
    End Using
End If
<!--End topbar header-->
